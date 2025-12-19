using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PoCXMinerGUI
{
    public partial class MinerForm : Form
    {
        // Constants
        private const string BUTTON_TEXT_START = "Start Mining";
        private const string BUTTON_TEXT_STOP = "Stop Mining";

        private readonly MinerProcess _minerProcess;
        private readonly ProgressParser _progressParser;
        private MinerConfig _config;
        private string _configFilePath;
        private string _minerExecutablePath;
        private FileSystemWatcher _configWatcher;
        private bool _isLoadingConfig = false; // Prevent recursive updates

        public MinerForm()
        {
            InitializeComponent();
            _minerProcess = new MinerProcess();
            _minerProcess.OutputReceived += OnMinerOutputReceived;
            _minerProcess.ProcessExited += OnMinerProcessExited;

            // Initialize progress parser
            _progressParser = new ProgressParser();
            _progressParser.ScanProgressUpdated += OnScanProgressUpdated;
            _progressParser.ChainStateChanged += OnChainStateChanged;
            _progressParser.CapacityUpdated += OnCapacityUpdated;
            _progressParser.QueueUpdated += OnQueueUpdated;
            _progressParser.DeadlineSubmitted += OnDeadlineSubmitted;
            _progressParser.ScanStatusChanged += OnScanStatusChanged;
        }

        #region UI Update Helpers

        /// <summary>
        /// Updates progress bar (thread-safe)
        /// </summary>
        private void UpdateProgress(int progress)
        {
            if (statusStrip.InvokeRequired)
            {
                statusStrip.Invoke(new MethodInvoker(() => UpdateProgress(progress)));
                return;
            }

            pbar.Value = Math.Min(Math.Max(progress, 0), 100);
        }

        /// <summary>
        /// Updates progress bar tooltip (thread-safe)
        /// </summary>
        private void UpdateProgressTooltip(string text)
        {
            if (statusStrip.InvokeRequired)
            {
                statusStrip.Invoke(new MethodInvoker(() => UpdateProgressTooltip(text)));
                return;
            }

            pbar.ToolTipText = text;
        }

        /// <summary>
        /// Updates status label (thread-safe)
        /// </summary>
        private void UpdateStatusLabel(string text)
        {
            if (statusStrip.InvokeRequired)
            {
                statusStrip.Invoke(new MethodInvoker(() => UpdateStatusLabel(text)));
                return;
            }

            statusLabel1.Text = text;
        }

        #endregion

        private async void MinerForm_Load(object sender, EventArgs e)
        {
            // Wire up auto-save events for all controls
            WireUpAutoSaveEvents();

            // Wire up checkbox event for hdd_wakeup_after enable/disable
            cb_wakeup.CheckedChanged += cb_wakeup_CheckedChanged;

            // Wire up autostart checkbox to save setting
            cb_autostart.CheckedChanged += cb_autostart_CheckedChanged;

            // Load settings from application settings
            SettingsManager.LoadWindowSettings(this);
            _configFilePath = SettingsManager.GetConfigPath();
            _minerExecutablePath = SettingsManager.LoadMinerPath();

            // Load autostart setting
            cb_autostart.Checked = Properties.Settings.Default.Autostart;

            // Check if miner executable exists
            if (!MinerUpdateManager.IsMinerExecutablePresent())
            {
                // Show download dialog for missing executable
                await ShowDownloadDialogForMissingExecutable();
            }

            // Load configuration
            LoadConfiguration();

            // Initialize FileSystemWatcher for live YAML sync
            InitializeConfigWatcher();

            // Update UI state
            UpdateUIState();

            // Auto-check for updates if enabled
            if (Properties.Settings.Default.AutoCheckForUpdates)
            {
                await CheckForUpdatesAsync(silent: true);
            }

            // Autostart mining if enabled
            if (Properties.Settings.Default.Autostart)
            {
                StartMining();
            }
        }

        private void InitializeConfigWatcher()
        {
            try
            {
                if (string.IsNullOrEmpty(_configFilePath) || !File.Exists(_configFilePath))
                    return;

                string directory = Path.GetDirectoryName(_configFilePath);
                string fileName = Path.GetFileName(_configFilePath);

                // If path is relative, use current directory
                if (string.IsNullOrEmpty(directory))
                    directory = Directory.GetCurrentDirectory();

                if (!Directory.Exists(directory))
                    return;

                _configWatcher = new FileSystemWatcher(directory, fileName)
                {
                    NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size,
                    EnableRaisingEvents = true
                };
                _configWatcher.Changed += OnConfigFileChanged;
            }
            catch
            {
                // Silently fail if FileSystemWatcher cannot be initialized
                // The application will still work, just without live reload
            }
        }

        private void OnConfigFileChanged(object sender, FileSystemEventArgs e)
        {
            // Debounce: wait a bit for file write to complete
            System.Threading.Thread.Sleep(100);

            if (InvokeRequired)
            {
                Invoke(new Action(() => OnConfigFileChanged(sender, e)));
                return;
            }

            // Prevent recursive updates
            if (_isLoadingConfig)
                return;

            try
            {
                // Reload configuration from disk
                LoadConfiguration();
            }
            catch
            {
                // Silently ignore errors during live reload (file might be mid-write)
                // TODO: Could add a status bar message or log
            }
        }

        private void MinerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Dispose FileSystemWatcher
            if (_configWatcher != null)
            {
                _configWatcher.EnableRaisingEvents = false;
                _configWatcher.Dispose();
            }

            // Check if mining is active
            if (_minerProcess.IsRunning)
            {
                var result = MessageBox.Show(
                    "Mining in progress. Are you sure you want to exit?",
                    "Confirm Exit",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                _minerProcess.Stop();
            }

            // Save window settings
            SettingsManager.SaveWindowSettings(this);
        }

        private void LoadConfiguration()
        {
            try
            {
                _isLoadingConfig = true;
                _config = SettingsManager.LoadConfig(_configFilePath);
                PopulateUIFromConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading configuration: {ex.Message}\n\nUsing default configuration.",
                    "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _config = new MinerConfig();
            }
            finally
            {
                _isLoadingConfig = false;
            }
        }

        private void SaveConfiguration()
        {
            try
            {
                SaveConfigurationInternal();
                MessageBox.Show("Configuration saved successfully.", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving configuration: {ex.Message}",
                    "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveConfigurationInternal()
        {
            // Prevent recursive saves when FileSystemWatcher detects the change
            if (_isLoadingConfig)
                return;

            _isLoadingConfig = true;
            try
            {
                UpdateConfigFromUI();
                SettingsManager.SaveConfig(_config, _configFilePath);
            }
            catch (Exception ex)
            {
                // Log error but don't crash the application
                System.Diagnostics.Debug.WriteLine($"Error saving configuration: {ex.Message}");
            }
            finally
            {
                _isLoadingConfig = false;
            }
        }

        private void WireUpAutoSaveEvents()
        {
            // HDD settings
            cb_dio.CheckedChanged += (s, e) => SaveConfigurationInternal();
            cb_wakeup.CheckedChanged += (s, e) => SaveConfigurationInternal();
            ud_wakeup.ValueChanged += (s, e) => SaveConfigurationInternal();
            ud_cache.ValueChanged += (s, e) => SaveConfigurationInternal();

            // CPU settings
            ud_CpuThreads.ValueChanged += (s, e) => SaveConfigurationInternal();
            cb_ThreadPinning.CheckedChanged += (s, e) => SaveConfigurationInternal();

            // Network settings
            ud_poll.ValueChanged += (s, e) => SaveConfigurationInternal();
            ud_timeout.ValueChanged += (s, e) => SaveConfigurationInternal();

            // Mining settings
            cb_onthefly.CheckedChanged += (s, e) => SaveConfigurationInternal();

            // Logging settings
            cb_console_level.SelectedIndexChanged += (s, e) => SaveConfigurationInternal();
            cb_logfile_level.SelectedIndexChanged += (s, e) => SaveConfigurationInternal();
            ud_logfile_count.ValueChanged += (s, e) => SaveConfigurationInternal();
            ud_logfile_size.ValueChanged += (s, e) => SaveConfigurationInternal();
            txt_console_pattern.TextChanged += (s, e) => SaveConfigurationInternal();
            txt_logfile_pattern.TextChanged += (s, e) => SaveConfigurationInternal();

            // Benchmark mode
            rb_benchmark_disabled.CheckedChanged += (s, e) => SaveConfigurationInternal();
            rb_benchmark_io.CheckedChanged += (s, e) => SaveConfigurationInternal();
            rb_benchmark_cpu.CheckedChanged += (s, e) => SaveConfigurationInternal();
        }

        private void PopulateUIFromConfig()
        {
            // Clear existing lists
            lv_csetup.Items.Clear(); // Chain setup on settings tab
            lv_dirs.Items.Clear();

            // Populate chain configuration list (lv_csetup on settings tab)
            foreach (var chain in _config.Chains)
            {
                var item = new ListViewItem(chain.Name);
                item.SubItems.Add(chain.BaseUrl);
                item.SubItems.Add(chain.ApiPath);
                item.SubItems.Add(chain.BlockTimeSeconds.ToString());
                item.Tag = chain;
                lv_csetup.Items.Add(item);
            }

            // Populate plot directories
            foreach (var dir in _config.PlotDirs)
            {
                lv_dirs.Items.Add(dir);
            }

            // HDD settings
            cb_dio.Checked = _config.HddUseDirectIo;

            // hdd_wakeup_after: 0 or negative = disabled, positive = enabled
            if (_config.HddWakeupAfter > 0)
            {
                cb_wakeup.Checked = true;
                ud_wakeup.Enabled = true;
                ud_wakeup.Value = _config.HddWakeupAfter;
            }
            else
            {
                cb_wakeup.Checked = false;
                ud_wakeup.Enabled = false;
                ud_wakeup.Value = 30; // Default value when disabled
            }

            ud_cache.Value = (decimal)_config.HddReadCacheInWarps;

            // CPU settings
            ud_CpuThreads.Value = _config.CpuThreads;
            cb_ThreadPinning.Checked = _config.CpuThreadPinning;

            // Network settings
            ud_poll.Value = _config.GetMiningInfoInterval;
            ud_timeout.Value = _config.Timeout;

            // Mining settings
            cb_onthefly.Checked = _config.EnableOnTheFlyCompression;

            // Logging settings
            cb_console_level.SelectedItem = _config.ConsoleLogLevel;
            cb_logfile_level.SelectedItem = _config.LogfileLogLevel;
            ud_logfile_count.Value = _config.LogfileMaxCount;
            ud_logfile_size.Value = _config.LogfileMaxSize;
            txt_console_pattern.Text = _config.ConsoleLogPattern;
            txt_logfile_pattern.Text = _config.LogfileLogPattern;

            // Benchmark mode
            switch (_config.Benchmark)
            {
                case BenchmarkMode.Io:
                    rb_benchmark_io.Checked = true;
                    break;
                case BenchmarkMode.Cpu:
                    rb_benchmark_cpu.Checked = true;
                    break;
                default:
                    rb_benchmark_disabled.Checked = true;
                    break;
            }
        }

        private void UpdateConfigFromUI()
        {
            // HDD settings
            _config.HddUseDirectIo = cb_dio.Checked;

            // hdd_wakeup_after: checkbox controls enable/disable (0 = disabled)
            _config.HddWakeupAfter = cb_wakeup.Checked ? (long)ud_wakeup.Value : 0;

            _config.HddReadCacheInWarps = (ulong)ud_cache.Value;

            // Plot directories
            _config.PlotDirs.Clear();
            foreach (ListViewItem item in lv_dirs.Items)
            {
                _config.PlotDirs.Add(item.Text);
            }

            // CPU settings
            _config.CpuThreads = (int)ud_CpuThreads.Value;
            _config.CpuThreadPinning = cb_ThreadPinning.Checked;

            // Network settings
            _config.GetMiningInfoInterval = (ulong)ud_poll.Value;
            _config.Timeout = (ulong)ud_timeout.Value;

            // Mining settings
            _config.EnableOnTheFlyCompression = cb_onthefly.Checked;

            // Logging settings
            _config.ConsoleLogLevel = cb_console_level.SelectedItem?.ToString() ?? "info";
            _config.LogfileLogLevel = cb_logfile_level.SelectedItem?.ToString() ?? "warn";
            _config.LogfileMaxCount = (uint)ud_logfile_count.Value;
            _config.LogfileMaxSize = (ulong)ud_logfile_size.Value;
            _config.ConsoleLogPattern = txt_console_pattern.Text;
            _config.LogfileLogPattern = txt_logfile_pattern.Text;

            // Benchmark mode
            if (rb_benchmark_io.Checked)
                _config.Benchmark = BenchmarkMode.Io;
            else if (rb_benchmark_cpu.Checked)
                _config.Benchmark = BenchmarkMode.Cpu;
            else
                _config.Benchmark = BenchmarkMode.Disabled;
        }

        private void UpdateUIState()
        {
            bool isMining = _minerProcess.IsRunning;

            btn_start.Text = isMining ? BUTTON_TEXT_STOP : BUTTON_TEXT_START;
            btn_start.Enabled = true;

            // Disable configuration editing while mining
            tc_Main.Enabled = !isMining || tc_Main.SelectedIndex == 0;

            // Update check for updates menu item state
            UpdateMenuItemState();
        }

        /// <summary>
        /// Updates the enabled state of the "Check for Updates" menu item based on mining status
        /// </summary>
        private void UpdateMenuItemState()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => UpdateMenuItemState()));
                return;
            }

            bool isMining = _minerProcess.IsRunning;
            checkForUpdatesToolStripMenuItem.Enabled = !isMining;
            checkForUpdatesToolStripMenuItem.ToolTipText = isMining
                ? "Stop mining to check for updates"
                : "Check for new miner versions on GitHub";
        }

        private void OnMinerOutputReceived(object sender, MinerOutputEventArgs e)
        {
            if (txt_MinerOutput.InvokeRequired)
            {
                // Use BeginInvoke to avoid blocking the process output thread
                txt_MinerOutput.BeginInvoke(new Action(() => OnMinerOutputReceived(sender, e)));
                return;
            }

            // Parse line for mining events and check if it should be displayed
            string line = e.Line;
            if (!string.IsNullOrEmpty(line))
            {
                bool shouldDisplay = _progressParser.ParseLine(line);

                // Only display non-progress lines in the log
                if (shouldDisplay)
                {
                    txt_MinerOutput.AppendText(line + Environment.NewLine);

                    // Limit output buffer to prevent memory issues (keep last 1000 lines)
                    if (txt_MinerOutput.Lines.Length > 1000)
                    {
                        var lines = txt_MinerOutput.Lines.Skip(txt_MinerOutput.Lines.Length - 1000).ToArray();
                        txt_MinerOutput.Lines = lines;
                        txt_MinerOutput.SelectionStart = txt_MinerOutput.Text.Length;
                        txt_MinerOutput.ScrollToCaret();
                    }
                }
            }
        }

        private void OnMinerProcessExited(object sender, int exitCode)
        {
            if (InvokeRequired)
            {
                // Use BeginInvoke to avoid deadlock when Stop() is called from UI thread
                BeginInvoke(new Action(() => OnMinerProcessExited(sender, exitCode)));
                return;
            }

            UpdateUIState();

            // Exit code -1 means process was killed (normal user stop)
            // Exit code 0 means process exited normally
            // Any other code is an actual error
            if (exitCode != 0 && exitCode != -1)
            {
                MessageBox.Show(
                    $"Mining stopped with error code: {exitCode}",
                    "Mining Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            // Don't show message for normal exits (0) or user stops (-1)
        }

        /// <summary>
        /// Start mining (only if not already running)
        /// </summary>
        private void StartMining()
        {
            if (_minerProcess.IsRunning)
                return;

            try
            {
                // Save current configuration before starting
                UpdateConfigFromUI();
                SettingsManager.SaveConfig(_config, _configFilePath);

                // Update miner process paths
                _minerProcess.SetMinerPath(_minerExecutablePath);
                _minerProcess.SetConfigPath(_configFilePath);

                // Clear runtime information on main tab (not configuration!)
                txt_MinerOutput.Clear();
                lv_chains.Items.Clear();  // Runtime chain status
                lv_capa.Items.Clear();     // Capacity info
                lv_queue.Items.Clear();    // Mining queue
                lv_sub.Items.Clear();      // Submissions
                // Note: lv_csetup (chain config on settings tab) is NOT cleared

                // Reset progress parser state
                _progressParser.Reset();

                // Start miner
                _minerProcess.Start();
                UpdateUIState();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to start miner: {ex.Message}",
                    "Start Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (_minerProcess.IsRunning)
            {
                // Stop mining
                var result = MessageBox.Show(
                    "Are you sure you want to stop mining?",
                    "Confirm Stop",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _minerProcess.Stop();
                    UpdateUIState();
                }
            }
            else
            {
                // Start mining
                StartMining();
            }
        }

        private void btn_EditChain_Click(object sender, EventArgs e)
        {
            // Edit chain
            if (lv_csetup.SelectedItems.Count == 0)
                return;

            var item = lv_csetup.SelectedItems[0];
            var chain = item.Tag as ChainConfig;

            using (var dialog = new ChainEditDialog(chain))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Update the chain reference
                    int index = _config.Chains.IndexOf(chain);
                    _config.Chains[index] = dialog.Chain;

                    // Update ListView
                    item.Text = dialog.Chain.Name;
                    item.SubItems[1].Text = dialog.Chain.BaseUrl;
                    item.SubItems[2].Text = dialog.Chain.ApiPath;
                    item.SubItems[3].Text = dialog.Chain.BlockTimeSeconds.ToString();
                    item.Tag = dialog.Chain;

                    // Auto-save
                    SaveConfigurationInternal();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Save configuration
            SaveConfiguration();
        }


        private void ResetToDefaultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Reset to defaults from menu
            ResetToDefaults();
        }

        private void ResetToDefaults()
        {
            var result = MessageBox.Show(
                "This will reset all settings to defaults from default_config.yaml. Continue?",
                "Confirm Reset",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Try to load from default_config.yaml in PoCX data folder
                    string defaultConfigPath = PoCX.Common.UpdateManagerBase.GetExecutablePath("default_config.yaml");

                    if (File.Exists(defaultConfigPath))
                    {
                        _config = SettingsManager.LoadConfig(defaultConfigPath);
                        PopulateUIFromConfig();
                        SaveConfigurationInternal(); // Auto-save the reset config
                        MessageBox.Show("Settings reset to defaults successfully.",
                            "Reset Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Fallback: create new config with hardcoded defaults
                        _config = new MinerConfig();
                        PopulateUIFromConfig();
                        SaveConfigurationInternal();
                        MessageBox.Show(
                            "default_config.yaml not found. Reset to hardcoded defaults.",
                            "Reset Complete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error resetting to defaults: {ex.Message}\n\nUsing hardcoded defaults.",
                        "Reset Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _config = new MinerConfig();
                    PopulateUIFromConfig();
                    SaveConfigurationInternal();
                }
            }
        }

        private void btn_AddDir_Click(object sender, EventArgs e)
        {
            // Add plot directory
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select plot directory";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string folder = dialog.SelectedPath;
                    if (!_config.PlotDirs.Contains(folder))
                    {
                        lv_dirs.Items.Add(folder);

                        // Auto-save
                        SaveConfigurationInternal();
                    }
                }
            }
        }

        private void btn_RemoveDir_Click(object sender, EventArgs e)
        {
            // Remove selected plot directories
            if (lv_dirs.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lv_dirs.SelectedItems)
                {
                    lv_dirs.Items.Remove(item);
                }

                // Auto-save
                SaveConfigurationInternal();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/PoC-Consortium/pocx/wiki");
        }

        private void AboutToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "PoCX Miner GUI\n\n" +
                "A graphical interface for the PoCX mining client.\n\n" +
                "Part of the PoCX - A neXt generation Proof of Capacity Framework\n" +
                "by the Proof of Capacity Consortium",
                "About",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private async void CheckForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await CheckForUpdatesAsync(silent: false);
        }

        private async System.Threading.Tasks.Task CheckForUpdatesAsync(bool silent = false)
        {
            try
            {
                using (var updateManager = new MinerUpdateManager())
                {
                    var updateInfo = await updateManager.CheckForUpdatesAsync();

                    // Update last check time
                    Properties.Settings.Default.LastUpdateCheck = DateTime.UtcNow.ToString("o");
                    Properties.Settings.Default.Save();

                    // Always show dialog (allows downgrades and reinstalls, not just upgrades)
                    if (!silent)
                    {
                        ShowDownloadDialogForUpdate(updateInfo);
                    }
                    else if (updateInfo.UpdateAvailable)
                    {
                        // Silent mode only shows dialog if update is available
                        ShowDownloadDialogForUpdate(updateInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                if (!silent)
                {
                    MessageBox.Show(
                        $"Failed to check for updates: {ex.Message}",
                        "Update Check Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }

        private void ShowDownloadDialogForUpdate(MinerUpdateCheckResult updateInfo)
        {
            using (var updateManager = new MinerUpdateManager())
            using (var dialog = new UpdateDialog(updateInfo, updateManager))
            {
                dialog.ShowDialog(this);
            }
        }

        private void btn_AddChain_Click(object sender, EventArgs e)
        {
            // Add chain
            using (var dialog = new ChainEditDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _config.Chains.Add(dialog.Chain);

                    var item = new ListViewItem(dialog.Chain.Name);
                    item.SubItems.Add(dialog.Chain.BaseUrl);
                    item.SubItems.Add(dialog.Chain.ApiPath);
                    item.SubItems.Add(dialog.Chain.BlockTimeSeconds.ToString());
                    item.Tag = dialog.Chain;
                    lv_csetup.Items.Add(item);

                    // Auto-save
                    SaveConfigurationInternal();
                }
            }
        }

        private void btn_RemoveChain_Click(object sender, EventArgs e)
        {
            // Remove chain
            if (lv_csetup.SelectedItems.Count == 0)
                return;

            var item = lv_csetup.SelectedItems[0];
            var chain = item.Tag as ChainConfig;

            var result = MessageBox.Show(
                $"Remove chain '{chain.Name}'?",
                "Confirm Remove",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _config.Chains.Remove(chain);
                lv_csetup.Items.Remove(item);

                // Auto-save
                SaveConfigurationInternal();
            }
        }

        private void btn_MoveChainUp_Click(object sender, EventArgs e)
        {
            // Move chain up
            if (lv_csetup.SelectedItems.Count == 0)
                return;

            var item = lv_csetup.SelectedItems[0];
            int index = item.Index;

            if (index == 0)
                return; // Already at top

            var chain = item.Tag as ChainConfig;

            // Update config list
            _config.Chains.RemoveAt(index);
            _config.Chains.Insert(index - 1, chain);

            // Update ListView
            lv_csetup.Items.RemoveAt(index);
            var newItem = new ListViewItem(chain.Name);
            newItem.SubItems.Add(chain.BaseUrl);
            newItem.SubItems.Add(chain.ApiPath);
            newItem.SubItems.Add(chain.BlockTimeSeconds.ToString());
            newItem.Tag = chain;
            lv_csetup.Items.Insert(index - 1, newItem);
            newItem.Selected = true;

            // Auto-save
            SaveConfigurationInternal();
        }

        private void btn_MoveChainDown_Click(object sender, EventArgs e)
        {
            // Move chain down
            if (lv_csetup.SelectedItems.Count == 0)
                return;

            var item = lv_csetup.SelectedItems[0];
            int index = item.Index;

            if (index == lv_csetup.Items.Count - 1)
                return; // Already at bottom

            var chain = item.Tag as ChainConfig;

            // Update config list
            _config.Chains.RemoveAt(index);
            _config.Chains.Insert(index + 1, chain);

            // Update ListView
            lv_csetup.Items.RemoveAt(index);
            var newItem = new ListViewItem(chain.Name);
            newItem.SubItems.Add(chain.BaseUrl);
            newItem.SubItems.Add(chain.ApiPath);
            newItem.SubItems.Add(chain.BlockTimeSeconds.ToString());
            newItem.Tag = chain;
            lv_csetup.Items.Insert(index + 1, newItem);
            newItem.Selected = true;

            // Auto-save
            SaveConfigurationInternal();
        }

        private void lv_csetup_DoubleClick(object sender, EventArgs e)
        {
            // Edit chain on double-click
            if (lv_csetup.SelectedItems.Count == 0)
                return;

            var item = lv_csetup.SelectedItems[0];
            var chain = item.Tag as ChainConfig;

            using (var dialog = new ChainEditDialog(chain))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Update the chain reference
                    int index = _config.Chains.IndexOf(chain);
                    _config.Chains[index] = dialog.Chain;

                    // Update ListView
                    item.Text = dialog.Chain.Name;
                    item.SubItems[1].Text = dialog.Chain.BaseUrl;
                    item.SubItems[2].Text = dialog.Chain.ApiPath;
                    item.SubItems[3].Text = dialog.Chain.BlockTimeSeconds.ToString();
                    item.Tag = dialog.Chain;

                    // Auto-save
                    SaveConfigurationInternal();
                }
            }
        }

        private void cb_wakeup_CheckedChanged(object sender, EventArgs e)
        {
            // Enable/disable ud_wakeup based on checkbox state
            ud_wakeup.Enabled = cb_wakeup.Checked;

            // If unchecked, grey it out and it will be saved as 0 (disabled)
            // If checked, enable it and use the value in the control
        }

        private void cb_autostart_CheckedChanged(object sender, EventArgs e)
        {
            // Save autostart setting to application settings
            Properties.Settings.Default.Autostart = cb_autostart.Checked;
            Properties.Settings.Default.Save();
        }

        #region Mining Event Handlers

        /// <summary>
        /// Chain state changed - update lv_chains
        /// </summary>
        private void OnChainStateChanged(object sender, ChainStateEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => OnChainStateChanged(sender, e)));
                return;
            }

            // Find or create chain item in lv_chains
            ListViewItem item = null;
            foreach (ListViewItem existing in lv_chains.Items)
            {
                if (existing.Text == e.ChainName)
                {
                    item = existing;
                    break;
                }
            }

            if (item == null)
            {
                item = new ListViewItem(e.ChainName);
                item.SubItems.Add(""); // Height
                item.SubItems.Add(""); // Difficulty
                item.SubItems.Add(""); // Network Size
                item.SubItems.Add(""); // GenSig
                item.SubItems.Add(""); // Compression
                item.SubItems.Add(""); // Last Update
                lv_chains.Items.Add(item);
            }

            // Update columns: Chain | Height | Difficulty (BaseTarget) | Network Size | GenSig | Compression | Last Update
            item.SubItems[0].Text = e.ChainName;
            item.SubItems[1].Text = e.Height.ToString();
            item.SubItems[2].Text = e.BaseTarget.ToString();
            item.SubItems[3].Text = e.NetworkCapacity; // Network capacity
            item.SubItems[4].Text = "..." + e.GenSig;
            item.SubItems[5].Text = e.CompressionRange; // Show POCX range
            item.SubItems[6].Text = e.Timestamp.ToString("HH:mm:ss");

            // Auto-resize columns to fill available space
            for (int i = 0; i < lv_chains.Columns.Count - 1; i++)
            {
                lv_chains.Columns[i].Width = -2; // -2 = auto-size to longest content or header
            }
            lv_chains.Columns[lv_chains.Columns.Count - 1].Width = -2; // Last column fills remaining space
        }

        /// <summary>
        /// Capacity updated - update lv_capa
        /// </summary>
        private void OnCapacityUpdated(object sender, CapacityEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => OnCapacityUpdated(sender, e)));
                return;
            }

            // Clear and repopulate lv_capa
            lv_capa.Items.Clear();

            // Group by account and show total capacity per account
            // For now, show total capacity as a single row
            var item = new ListViewItem("Total");
            item.SubItems.Add($"{e.TotalCapacityTiB:F2} TiB");
            item.SubItems.Add($"{e.TotalDrives} drives");
            lv_capa.Items.Add(item);

            // Auto-resize columns to fill available space
            for (int i = 0; i < lv_capa.Columns.Count - 1; i++)
            {
                lv_capa.Columns[i].Width = -2; // -2 = auto-size to longest content or header
            }
            lv_capa.Columns[lv_capa.Columns.Count - 1].Width = -2; // Last column fills remaining space

            // TODO: Parse plot files to extract account info and show per-account capacity
        }

        /// <summary>
        /// Queue updated - update lv_queue
        /// </summary>
        private void OnQueueUpdated(object sender, QueueEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => OnQueueUpdated(sender, e)));
                return;
            }

            // Clear and repopulate lv_queue
            lv_queue.Items.Clear();

            foreach (var qitem in e.Queue)
            {
                var item = new ListViewItem(qitem.Position.ToString());
                item.SubItems.Add(qitem.Chain);
                item.SubItems.Add(qitem.Height.ToString());
                item.SubItems.Add($"{qitem.Progress:F2}%");
                lv_queue.Items.Add(item);
            }

            // Auto-resize columns to fill available space
            for (int i = 0; i < lv_queue.Columns.Count - 1; i++)
            {
                lv_queue.Columns[i].Width = -2; // -2 = auto-size to longest content or header
            }
            lv_queue.Columns[lv_queue.Columns.Count - 1].Width = -2; // Last column fills remaining space
        }

        /// <summary>
        /// Deadline submitted - update lv_sub (Best Submission History)
        /// </summary>
        private void OnDeadlineSubmitted(object sender, SubmissionEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => OnDeadlineSubmitted(sender, e)));
                return;
            }

            // Add to lv_sub (Best Submission History)
            // Columns: Chain | Account | Height | GenSig | Best Quality | PoC Time

            // Check if we already have a submission for this chain+height
            ListViewItem existingItem = null;
            foreach (ListViewItem item in lv_sub.Items)
            {
                if (item.Text == e.Chain && item.SubItems[2].Text == e.Height.ToString())
                {
                    existingItem = item;
                    break;
                }
            }

            // Only keep the best quality (lowest number)
            if (existingItem != null)
            {
                ulong existingQuality = ulong.Parse(existingItem.SubItems[4].Text);
                if (e.Quality < existingQuality)
                {
                    // Update with better quality
                    existingItem.SubItems[1].Text = "..." + e.Account;
                    existingItem.SubItems[3].Text = "..." + e.GenSig;
                    existingItem.SubItems[4].Text = e.Quality.ToString();
                    existingItem.SubItems[5].Text = string.IsNullOrEmpty(e.PocTime) ? "" : e.PocTime;
                }
            }
            else
            {
                // Add new submission at top (newest first)
                var item = new ListViewItem(e.Chain);
                item.SubItems.Add("..." + e.Account);
                item.SubItems.Add(e.Height.ToString());
                item.SubItems.Add("..." + e.GenSig);
                item.SubItems.Add(e.Quality.ToString());
                item.SubItems.Add(string.IsNullOrEmpty(e.PocTime) ? "" : e.PocTime);
                lv_sub.Items.Insert(0, item);

                // Keep only last 50 submissions (remove from bottom)
                while (lv_sub.Items.Count > 50)
                {
                    lv_sub.Items.RemoveAt(lv_sub.Items.Count - 1);
                }
            }

            // Auto-resize columns to fill available space
            for (int i = 0; i < lv_sub.Columns.Count - 1; i++)
            {
                lv_sub.Columns[i].Width = -2; // -2 = auto-size to longest content or header
            }
            lv_sub.Columns[lv_sub.Columns.Count - 1].Width = -2; // Last column fills remaining space
        }

        /// <summary>
        /// Scan progress updated - update progress bar and status
        /// </summary>
        private void OnScanProgressUpdated(object sender, ScanProgressEventArgs e)
        {
            UpdateProgress(e.Percent);
            UpdateProgressTooltip($"{e.CurrentWarps} of {e.TotalWarps} warps");

            // Update status label with scan speed and ETA
            string statusText = $"{e.WarpsPerSecond:F1} warps/s";
            if (e.EtaSeconds > 0 && e.EtaSeconds < double.MaxValue)
            {
                statusText += $" - ETA: {e.EtaSeconds:F1}s";
            }
            UpdateStatusLabel(statusText);
        }

        /// <summary>
        /// Scan status changed - update status bar when scan finishes
        /// </summary>
        private void OnScanStatusChanged(object sender, ScanEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => OnScanStatusChanged(sender, e)));
                return;
            }

            // When scan finishes, show completion message
            if (e.Status == "finished")
            {
                UpdateProgress(100); // Ensure progress bar shows 100%
                UpdateStatusLabel($"done after {e.Duration:F2}s");
            }
            else if (e.Status == "scanning" || e.Status == "resuming")
            {
                UpdateProgress(0); // Reset progress bar
                UpdateStatusLabel($"{e.Status}...");
            }
            else if (e.Status == "paused")
            {
                UpdateStatusLabel($"paused at {e.Progress:F1}%");
            }
        }

        #endregion

        #region Update Methods

        /// <summary>
        /// Shows download dialog when miner executable is missing
        /// </summary>
        private async System.Threading.Tasks.Task ShowDownloadDialogForMissingExecutable()
        {
            try
            {
                using (var updateManager = new MinerUpdateManager())
                {
                    var updateInfo = await updateManager.CheckForUpdatesAsync();

                    using (var dialog = new UpdateDialog(updateInfo, updateManager, missingExecutable: true))
                    {
                        var result = dialog.ShowDialog(this);

                        if (result == DialogResult.OK)
                        {
                            // Download succeeded
                            _minerExecutablePath = MinerUpdateManager.GetMinerPath();
                            SettingsManager.SaveMinerPath(_minerExecutablePath);
                        }
                        else
                        {
                            // User cancelled or download failed
                            Application.Exit();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to check for updates: {ex.Message}\n\nPlease download the miner manually from:\nhttps://github.com/PoC-Consortium/pocx/releases",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                Application.Exit();
            }
        }

        #endregion
    }
}
