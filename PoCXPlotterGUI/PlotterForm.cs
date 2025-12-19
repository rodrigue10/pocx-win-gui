using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Management;
using OpenCL.Net;
using System.Linq;
using PoCX.Common;

namespace PoCXPlotterGUI
{
    public partial class PlotterForm : Form
    {
        private bool _opencl = true;
        private bool _init = false;
        private readonly SettingsManager _settingsManager = new SettingsManager();
        private PlotterProcess _plotterProcess;
        private bool _isPlotting = false;

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetDiskFreeSpace(string lpRootPathName, out int lpSectorsPerCluster, out int lpBytesPerSector, out int lpNumberOfFreeClusters, out int lpTotalNumberOfClusters);

        struct Plotfile
        {
            public string account;
            public string seed;
            public ulong warps;
            public int compression;
        }

        // Constants
        private const string BUTTON_TEXT_START = "Start Plotting";
        private const string BUTTON_TEXT_STOP = "Stop Plotting";
        private const string DEVICE_TYPE_CPU = "CPU";
        private const int BYTES_PER_KIB = 1024;
        private const long BYTES_PER_MIB = 1024L * 1024;
        private const long BYTES_PER_GIB = 1024L * 1024 * 1024;
        private const long BYTES_PER_TIB = 1024L * 1024 * 1024 * 1024;
        private const int DEFAULT_SECTOR_SIZE = 4096;

        public PlotterForm()
        {
            InitializeComponent();
        }

        // plotter progress bar
        void TaskProgress(int progress)
        {
            if (statusStrip.InvokeRequired)
            {
                statusStrip.Invoke(new MethodInvoker(() => { TaskProgress(progress); }));
                return;
            }
            else
            {
                pbar.Value = progress;
            }
        }

        // plotter task status
        void TaskStatus(string text)
        {
            if (statusStrip.InvokeRequired)
            {
                statusStrip.Invoke(new MethodInvoker(() => { TaskStatus(text); }));
                return;
            }
            else
            {
                statusLabel1.Text = text;
            }
        }

        // plotter progress bar
        void TaskProgress2(int progress)
        {
            if (statusStrip.InvokeRequired)
            {
                statusStrip.Invoke(new MethodInvoker(() => { TaskProgress2(progress); }));
                return;
            }
            else
            {
                pbar2.Value = progress;
            }
        }

        // plotter task status
        void TaskStatus3(string text)
        {
            if (statusStrip.InvokeRequired)
            {
                statusStrip.Invoke(new MethodInvoker(() => { TaskStatus3(text); }));
                return;
            }
            else
            {
                StatusLabel3.Text = text;
            }
        }

        // plotter task status
        void TaskStatus2(string text)
        {
            if (statusStrip.InvokeRequired)
            {
                statusStrip.Invoke(new MethodInvoker(() => { TaskStatus2(text); }));
                return;
            }
            else
            {
                statusLabel2.Text = text;
            }
        }

        // plotter progress bar 1 tooltip
        void TaskTooltip(string text)
        {
            if (statusStrip.InvokeRequired)
            {
                statusStrip.Invoke(new MethodInvoker(() => { TaskTooltip(text); }));
                return;
            }
            else
            {
                pbar.ToolTipText = text;
            }
        }

        // plotter progress bar 2 tooltip
        void TaskTooltip2(string text)
        {
            if (statusStrip.InvokeRequired)
            {
                statusStrip.Invoke(new MethodInvoker(() => { TaskTooltip2(text); }));
                return;
            }
            else
            {
                pbar2.ToolTipText = text;
            }
        }

        // reset start button
        void ResetButton()
        {
            if (statusStrip.InvokeRequired)
            {
                btn_start.Invoke(new MethodInvoker(() => { ResetButton(); }));
                return;
            }
            else
            {
                btn_start.Text = BUTTON_TEXT_START;
            }
        }

        // update plot size label
        private void DisplayPlotSize()
        {
            string hexAddress = PoCXAddressToHexString(txt_Address.Text);
            string compressionLevel = $"X{(int)nud_Compression.Value}";

            switch (cmb_Units.SelectedItem.ToString())
            {
                case "Warps":
                case "GiB":
                    lbl_PlotFilename.Text = hexAddress + "_" + "[SEED]" + "_" + nud_PlotSize.Value + "_" + compressionLevel + ".pocx";
                    lbl_PlotSize.Text = "(" + string.Format("{0:n0}", (ulong)nud_PlotSize.Value) + " GiB)";
                    break;
                case "TiB":
                    lbl_PlotFilename.Text = hexAddress + "_" + "[SEED]" + "_" + (nud_PlotSize.Value * BYTES_PER_KIB) + "_" + compressionLevel + ".pocx";
                    lbl_PlotSize.Text = "(" + string.Format("{0:n0}", (ulong)nud_PlotSize.Value * BYTES_PER_KIB) + " GiB)";
                    break;
            }
        }

        // pretty print bytes
        private string PrettyBytes(ulong bytes)
        {
            string result;
            if (bytes < BYTES_PER_KIB)
            {
                result = Math.Round((double)bytes, 1) + " B";
            }
            else if (bytes < BYTES_PER_MIB)
            {
                result = Math.Round((double)bytes / BYTES_PER_KIB, 1) + " KiB";
            }
            else if (bytes < BYTES_PER_GIB)
            {
                result = Math.Round((double)bytes / BYTES_PER_MIB, 1) + " MiB";
            }
            else if (bytes < BYTES_PER_TIB)
            {
                result = Math.Round((double)bytes / BYTES_PER_GIB, 1) + " GiB";
            }
            else
            {
                result = Math.Round((double)bytes / BYTES_PER_TIB, 1) + " TiB";
            }
            return result;
        }

        // load form and user settings
        private async void PlotterForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
            UpdateWarpsToPlot();
            Get_devices();

            // Check for missing executables
            bool executablesPresent = PlotterUpdateManager.AreExecutablesPresent(out bool cpuMissing, out bool gpuMissing);

            if (!executablesPresent)
            {
                // Show download dialog for missing executables
                await ShowDownloadDialogForMissingExecutables(cpuMissing, gpuMissing);
            }
            else
            {
                // Auto-check for updates if enabled
                if (Properties.Settings.Default.AutoCheckForUpdates)
                {
                    await CheckForUpdatesAsync(silent: true);
                }
            }
        }

        // locate plot output directory
        private void Btn_OutputFolder_Click(object sender, EventArgs e)
        {
            if (chk_FixedSeed.Checked && lv_OutputPaths.Items.Count >= 1)
            {
                MessageBox.Show("Fixed seed mode allows only one output path.", "Fixed Seed Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string folder = folderBrowserDialog.SelectedPath;
                AddFolder(folder);
            }
        }

        // add Path
        private void AddFolder(string folder)
        {
            // get space and sector size
            string space = "";
            int sector_size = 0;
            try
            {
                if (Directory.Exists(folder))
                {
                    space = PrettyBytes(GetFreeSpaceOfPathInBytes(folder));
                    sector_size = GetSectorSize(folder);
                }
            }
            catch
            {
                // Silently ignore errors when getting folder space/sector size
                // The folder will still be added with empty space values
            }

            ListViewItem item = new ListViewItem(folder)
            {
                Text = folder,
                Name = folder
            };
            item.SubItems.Add(space);
            item.SubItems.Add(sector_size.ToString());
            lv_OutputPaths.Items.Add(item);
        }

        // load user settings
        private void LoadSettings()
        {
            var settings = _settingsManager.LoadSettings();

            chk_MemoryLimit.Checked = settings.UseMemoryLimit;
            chk_LowPriority.Checked = settings.LowPriority;
            chk_DirectIO.Checked = settings.DirectIo;
            cmb_Units.SelectedIndex = settings.Unit;
            txt_Address.Text = settings.AccountId ?? "";
            nud_MemoryLimit.Value = settings.MemoryLimit;

            rb_PlotSizeValue.Checked = !settings.MaxNonces;
            rb_PlotSizeMaximum.Checked = settings.MaxNonces;
            nud_PlotSize.Value = settings.Warps;

            chk_Benchmark.Checked = settings.Benchmark;
            chk_ZeroCopyBuffers.Checked = settings.ZeroCopyBuffers;
            nud_Encounters.Value = settings.Encounters;
            nud_Compression.Value = settings.CompressionRatio;
            nud_WorkGroupSize.Value = settings.WorkGroups;
            chk_CustomEncounters.Checked = settings.UseCustomEncounters;
            chk_CustomWorkGroupSize.Checked = settings.UseCustomWorkGroups;
            nud_FilesToPlot.Value = settings.NumFiles;
        }

        // start plotting
        private void Start_Click(object sender, EventArgs e)
        {
            if (btn_start.Text == BUTTON_TEXT_START)
            {
                btn_start.Text = BUTTON_TEXT_STOP;
                _isPlotting = true;
                txt_PlotOutput.Text = "";
                pbar.Value = 0;
                pbar.ToolTipText = "Hasher Progress";
                statusLabel1.Text = "(idle)";
                pbar2.Value = 0;
                pbar2.ToolTipText = "Writer Progress";
                statusLabel2.Text = "(idle)";
                StatusLabel3.Text = "";

                // Build config from form
                var config = BuildPlotterConfig();

                // Create and start plotter process
                _plotterProcess = new PlotterProcess();

                // Wire up events
                _plotterProcess.HashProgressUpdated += OnHashProgressUpdated;
                _plotterProcess.WriteProgressUpdated += OnWriteProgressUpdated;
                _plotterProcess.StandardOutputReceived += OnStandardOutputReceived;
                _plotterProcess.ErrorOutputReceived += OnErrorOutputReceived;
                _plotterProcess.ProcessExited += OnProcessExited;

                // Start plotting
                _plotterProcess.Start(config);

                // Disable update menu item while plotting
                UpdateMenuItemState();
            }
            else
            {
                if (MessageBox.Show("Plotting in progress, are you sure you want to stop?", BUTTON_TEXT_STOP, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _plotterProcess?.Stop();
                    _isPlotting = false;
                    ResetButton();
                    UpdateMenuItemState();
                }
            }
        }

        // Event handlers for PlotterProcess

        private void OnHashProgressUpdated(object sender, HashProgressEventArgs e)
        {
            TaskProgress(e.Percent);
            TaskStatus($"{e.MibPerSecond:F2} MiB/s");
            TaskTooltip(e.RawProgressString);
        }

        private void OnWriteProgressUpdated(object sender, WriteProgressEventArgs e)
        {
            TaskProgress2(e.Percent);
            TaskStatus2($"{e.MibPerSecond:F2} MiB/s");
            TaskStatus3($"ETA: {e.EtaString}");
            TaskTooltip2(e.RawProgressString);
        }

        private void OnStandardOutputReceived(object sender, OutputEventArgs e)
        {
            if (txt_PlotOutput.InvokeRequired)
            {
                txt_PlotOutput.Invoke(new MethodInvoker(() => OnStandardOutputReceived(sender, e)));
                return;
            }
            txt_PlotOutput.AppendText(e.Data + "\r\n");
        }

        private void OnErrorOutputReceived(object sender, OutputEventArgs e)
        {
            if (txt_PlotOutput.InvokeRequired)
            {
                txt_PlotOutput.Invoke(new MethodInvoker(() => OnErrorOutputReceived(sender, e)));
                return;
            }
            txt_PlotOutput.AppendText(e.Data + "\r\n");
        }

        private void OnProcessExited(object sender, EventArgs e)
        {
            _isPlotting = false;
            ResetButton();
            TaskStatus3("Plotting ended.");

            // Re-enable update menu item when plotting stops
            UpdateMenuItemState();
        }

        // below this line all GUI handling

        private void Address_TextChanged(object sender, EventArgs e)
        {
            // Always save the address, even if not yet valid
            _settingsManager.SaveAccountId(txt_Address.Text);

            // Detect and display address format
            var format = AddressValidator.DetectFormat(txt_Address.Text);
            switch (format)
            {
                case AddressFormat.Base58:
                    lbl_AddressFormat.Text = "BASE58";
                    DisplayPlotSize();
                    break;
                case AddressFormat.Bech32:
                    lbl_AddressFormat.Text = "BECH32";
                    DisplayPlotSize();
                    break;
                case AddressFormat.Unknown:
                default:
                    lbl_AddressFormat.Text = "UNKNOWN";
                    break;
            }
        }

        private void MemoryLimit_ValueChanged(object sender, EventArgs e)
        {
            _settingsManager.SaveMemoryLimit((int)nud_MemoryLimit.Value);
        }

        private void PlotSizeMaximum_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWarpsToPlot();
            _settingsManager.SaveMaxNonces(rb_PlotSizeMaximum.Checked);
        }

        private void PlotSize_ValueChanged(object sender, EventArgs e)
        {
            DisplayPlotSize();
            _settingsManager.SaveWarps(nud_PlotSize.Value);
        }


        // update nonces to plot label
        private void UpdateWarpsToPlot()
        {
            // TODO: When Maximum is selected, could auto-calculate available space
            // from selected output paths and set nud_PlotSize accordingly.
            // For now, user must manually specify size even when Maximum is checked.
        }

        private void PlotSize_Enter(object sender, EventArgs e)
        {
            rb_PlotSizeValue.Checked = true;
        }

        private bool IsPoCXPlotFileName(string filename)
        {
            Regex pocx = new Regex(@"(.)*(\\)+[a-zA-Z0-9]{40}(_)[a-zA-Z0-9]{64}(_)\d+(_)X\d.tmp$");

            if (pocx.IsMatch(filename))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Plotfile ParsePlotFileName(string filename)
        {
            string[] temp = filename.Split('\\');
            string[] pfn = temp[temp.GetLength(0) - 1].Split('_');
            Plotfile result;
            result.account = pfn[0];
            result.seed = pfn[1];
            result.warps = Convert.ToUInt64(pfn[2]);
            temp = pfn[3].Split('.');
            result.compression = Convert.ToInt32(temp[0].Substring(1));
            return result;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // check if plotting is active
            if (btn_start.Text == BUTTON_TEXT_START)
            {
                Application.Exit();
            }
            else
            {
                if (MessageBox.Show("Plotting in progress, are you sure you want to exit?", BUTTON_TEXT_STOP, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _plotterProcess?.Stop();
                    Application.Exit();
                }
            }
        }

        private void ResumeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Temporary PoCX Plot files|*_*_X?.tmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (IsPoCXPlotFileName(openFileDialog.FileName))
                {
                    Plotfile temp = ParsePlotFileName(openFileDialog.FileName);
                    
                    txt_Address.Text = HexStringToPoCXAddress(temp.account);
                    rb_PlotSizeValue.Checked = true;
                    nud_PlotSize.Value = (decimal)temp.warps;
                    cmb_Units.SelectedIndex = 0;
                    nud_Compression.Value = (decimal)temp.compression;
                    chk_FixedSeed.Checked = true;
                    txt_Seed.Text = temp.seed;                    
                    lv_OutputPaths.Items.Clear();                    
                    AddFolder(Path.GetDirectoryName(openFileDialog.FileName));
                }
            }
        }

        private string HexStringToPoCXAddress(string hex)
        {
            byte[] bytes = StringToByteArray(hex);
            // Use Bech32 encoding with "pocx" as HRP
            var encoder = NBitcoin.DataEncoders.Encoders.Bech32("pocx");
            return encoder.Encode(0, bytes);
        }

        private string PoCXAddressToHexString(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                return "[ADDRESS]";

            try
            {
                var format = AddressValidator.DetectFormat(address);

                if (format == AddressFormat.Base58)
                {
                    // Decode Base58Check and remove version byte (0x55)
                    byte[] decoded = NBitcoin.DataEncoders.Encoders.Base58Check.DecodeData(address);
                    if (decoded.Length > 1 && decoded[0] == 0x55)
                    {
                        byte[] payload = new byte[decoded.Length - 1];
                        Array.Copy(decoded, 1, payload, 0, payload.Length);
                        return ByteArrayToString(payload);
                    }
                }
                else if (format == AddressFormat.Bech32)
                {
                    // Decode Bech32 and get payload
                    string hrp = AddressValidator.GetBech32Hrp(address);
                    if (!string.IsNullOrEmpty(hrp))
                    {
                        var encoder = NBitcoin.DataEncoders.Encoders.Bech32(hrp);
                        byte[] decoded = encoder.Decode(address, out byte witnessVersion);
                        return ByteArrayToString(decoded);
                    }
                }

                return address; // Fallback to original address if can't decode
            }
            catch
            {
                return "[ADDRESS]"; // Show placeholder if conversion fails
            }
        }

        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public static string ByteArrayToString(byte[] bytes)
        {
            return BitConverter.ToString(bytes).Replace("-", "").ToLowerInvariant();
        }

        private void Units_SelectedIndexChanged(object sender, EventArgs e)
        {
            _settingsManager.SaveUnit(cmb_Units.SelectedIndex);
            switch (cmb_Units.SelectedItem.ToString())
            {
                case "Nonces":
                    nud_PlotSize.Increment = 1000;
                    break;
                case "MiB":
                    nud_PlotSize.Increment = 100;
                    break;
                case "GiB":
                    nud_PlotSize.Increment = 100;
                    break;
                case "TiB":
                    nud_PlotSize.Increment = 1;
                    break;
            }
            PlotSize_ValueChanged(null, null);
        }

        private void LowPriority_CheckedChanged(object sender, EventArgs e)
        {
            _settingsManager.SaveLowPriority(chk_LowPriority.Checked);
        }

        private void MemoryLimit_CheckedChanged(object sender, EventArgs e)
        {
            nud_MemoryLimit.Enabled = chk_MemoryLimit.Checked;
            _settingsManager.SaveMemoryLimitEnabled(chk_MemoryLimit.Checked);
        }

        private void DirectIO_CheckedChanged(object sender, EventArgs e)
        {
            _settingsManager.SaveDirectIo(chk_DirectIO.Checked);
        }

        private void AboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/PoC-Consortium/pocx/wiki");
        }

        private void AboutToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/PoC-Consortium/pocx/blob/master/pocx_miner/README.md");
        }

        private int GetSectorSize(string path)
        {
            int bytesPerSector = DEFAULT_SECTOR_SIZE;
            try
            {
                string root;

                if (Path.GetPathRoot(path) == path)
                {
                    root = path;
                }
                else
                {
                    FileInfo file = new FileInfo(path);
                    root = file.Directory.Root.FullName;
                }

                DriveInfo drive = new DriveInfo(root);

                GetDiskFreeSpace(drive.Name, out int sectorsPerCluster, out bytesPerSector,
                                 out int numberOfFreeClusters, out int totalNumberOfClusters);
            }
            catch (Exception)
            {
                // Silently fall back to default sector size if path is invalid or inaccessible
                // Default 4096 bytes is safe for modern systems
            }

            return bytesPerSector;
        }


        // https://stackoverflow.com/questions/1393711/get-free-disk-space
        public static ulong GetFreeSpaceOfPathInBytes(string path)
        {
            if ((new Uri(path)).IsUnc)
            {
                throw new NotImplementedException("Cannot find free space for UNC path " + path);
            }

            ulong freeSpace = 0;
            int prevVolumeNameLength = 0;

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * from Win32_Volume"))
            using (ManagementObjectCollection volumes = searcher.Get())
            {
                foreach (ManagementObject volume in volumes)
                {
                    using (volume)
                    {
                        string name = volume["Name"]?.ToString();
                        if (!path.EndsWith(@"\\", StringComparison.Ordinal))
                        {
                            path += @"\\";
                        }
                        if (volume["DriveType"] != null &&
                            uint.Parse(volume["DriveType"].ToString()) > 1 &&                              // Is Volume mounted on host
                            volume["Name"] != null &&                                                       // Volume has a root directory
                            path.StartsWith(volume["Name"].ToString(), StringComparison.OrdinalIgnoreCase)  // Required Path is under Volume's root directory
                            )
                        {
                            // If multiple volumes have their root directory matching the required path,
                            // one with most nested (longest) Volume Name is given preference.
                            // Case: CSV volumes mounted under other drive volumes.

                            int currVolumeNameLength = volume["Name"].ToString().Length;

                            if ((prevVolumeNameLength == 0 || currVolumeNameLength > prevVolumeNameLength) &&
                                volume["FreeSpace"] != null
                                )
                            {
                                freeSpace = ulong.Parse(volume["FreeSpace"].ToString());
                                prevVolumeNameLength = volume["Name"].ToString().Length;
                            }
                        }
                    }
                }
            }

            if (prevVolumeNameLength > 0)
            {
                return freeSpace;
            }

            throw new Exception("Could not find Volume Information for path " + path);
        }

        private void PlotterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // check if plotting is active
            if (btn_start.Text == BUTTON_TEXT_STOP)
            {
                if (MessageBox.Show("Plotting in progress, are you sure you want to exit?", BUTTON_TEXT_STOP, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _plotterProcess?.Stop();
                } else
                {
                    e.Cancel = true;
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Get_devices();
        }

        private void Get_devices()
        {
            var deviceManager = new DeviceManager();
            var result = deviceManager.DetectDevices();

            // Load saved settings
            var settings = new SettingsManager().LoadSettings();

            // Populate devices grid
            foreach (var device in result.Devices)
            {
                bool enabled = false;
                int threads = 0;

                if (device.Type == ComputeDevice.DeviceType.CPU)
                {
                    enabled = settings.CpuEnabled;
                    threads = settings.CpuThreads;
                }
                else
                {
                    // GPU - determine which GPU index this is
                    int gpuIndex = dgv_Devices.Rows.Count - 1; // -1 because CPU is row 0
                    switch (gpuIndex)
                    {
                        case 0:
                            enabled = settings.Gpu1Enabled;
                            threads = settings.Gpu1Threads;
                            break;
                        case 1:
                            enabled = settings.Gpu2Enabled;
                            threads = settings.Gpu2Threads;
                            break;
                        case 2:
                            enabled = settings.Gpu3Enabled;
                            threads = settings.Gpu3Threads;
                            break;
                        case 3:
                            enabled = settings.Gpu4Enabled;
                            threads = settings.Gpu4Threads;
                            break;
                    }
                }

                dgv_Devices.Rows.Add(enabled, device.Name, device.ComputeUnits, threads);
            }

            // Handle OpenCL availability
            if (!result.OpenClAvailable)
            {
                _opencl = false;
                chk_ZeroCopyBuffers.Checked = false;
                chk_ZeroCopyBuffers.Enabled = false;
            }

            _init = true;
        }

        private void Devices_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (!uint.TryParse(Convert.ToString(e.FormattedValue), out uint i))
                {
                    MessageBox.Show("Please enter a value between 0 and " + dgv_Devices.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString(), "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
                else
                {
                    // Get compute units as int (stored type) and convert to uint for comparison
                    int computeUnits = Convert.ToInt32(dgv_Devices.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value);
                    uint maxThreads = (uint)(2 * computeUnits);

                    if (i > maxThreads)
                    {
                        MessageBox.Show("Please enter a value between 0 and " + maxThreads.ToString(), "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }
            }
        }

        private void Benchmark_CheckedChanged(object sender, EventArgs e)
        {
            _settingsManager.SaveBenchmark(chk_Benchmark.Checked);
        }

        private void ZeroCopyBuffers_CheckedChanged(object sender, EventArgs e)
        {
            _settingsManager.SaveZeroCopyBuffers(chk_ZeroCopyBuffers.Checked);
        }

        private void Devices_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Save_devices();
        }

        private void Save_devices()
        {
            if (!_init) return;

            var deviceSettings = new List<DeviceSettings>();

            foreach (System.Windows.Forms.DataGridViewRow row in dgv_Devices.Rows)
            {
                var deviceName = row.Cells[1].Value.ToString();
                var deviceType = deviceName.StartsWith(DEVICE_TYPE_CPU, StringComparison.Ordinal) ?
                    DeviceSettings.DeviceType.CPU :
                    DeviceSettings.DeviceType.GPU;

                deviceSettings.Add(new DeviceSettings
                {
                    Type = deviceType,
                    Enabled = (bool)row.Cells[0].Value,
                    Threads = int.Parse(row.Cells[3].Value.ToString())
                });
            }

            _settingsManager.SaveDeviceSettings(deviceSettings);
        }

        private void Startnonce_ValueChanged(object sender, EventArgs e)
        {
            DisplayPlotSize();
        }

        private void RemovePath_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem row in lv_OutputPaths.SelectedItems){
                lv_OutputPaths.Items.Remove(row);
            }
        }

        private void FixedSeed_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;

            if (checkbox.Checked)
            {
                // Show confirmation dialog
                DialogResult result = MessageBox.Show(
                    "Fixed seed mode creates only one plot file on one output path.\n\n" +
                    "Additional paths will be removed and number of files will be set to 1.\n\n" +
                    "Do you want to continue?",
                    "Fixed Seed Mode",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    // Remove additional paths (keep only first)
                    while (lv_OutputPaths.Items.Count > 1)
                    {
                        lv_OutputPaths.Items.RemoveAt(1);
                    }

                    // Set files to 1 and disable
                    nud_FilesToPlot.Value = 1;
                    nud_FilesToPlot.Enabled = false;

                    // Enable seed textbox
                    txt_Seed.Enabled = true;
                }
                else
                {
                    // User cancelled, uncheck the checkbox
                    checkbox.Checked = false;
                }
            }
            else
            {
                // Re-enable num control
                nud_FilesToPlot.Enabled = true;
                txt_Seed.Enabled = false;
            }
        }

        private void CustomWorkGroupSize_CheckedChanged(object sender, EventArgs e)
        {
            nud_WorkGroupSize.Enabled = chk_CustomWorkGroupSize.Checked;
            _settingsManager.SaveCustomWorkGroupsEnabled(chk_CustomWorkGroupSize.Checked);
        }

        private void CustomEncounters_CheckedChanged(object sender, EventArgs e)
        {
            nud_Encounters.Enabled = chk_CustomEncounters.Checked;
            _settingsManager.SaveCustomEncountersEnabled(chk_CustomEncounters.Checked);
        }

        private void WorkGroupSize_ValueChanged(object sender, EventArgs e)
        {
            _settingsManager.SaveWorkGroups(nud_WorkGroupSize.Value);
        }

        private void Compression_ValueChanged(object sender, EventArgs e)
        {
            _settingsManager.SaveCompressionRatio(nud_Compression.Value);
            DisplayPlotSize();
        }

        private void Encounters_ValueChanged(object sender, EventArgs e)
        {
            _settingsManager.SaveEncounters(nud_Encounters.Value);
        }

        private void FilesToPlot_ValueChanged(object sender, EventArgs e)
        {
            _settingsManager.SaveNumFiles(nud_FilesToPlot.Value);
        }

        // Update-related methods

        /// <summary>
        /// Updates the enabled state of the "Check for Updates" menu item based on plotting status
        /// </summary>
        private void UpdateMenuItemState()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => UpdateMenuItemState()));
                return;
            }

            checkForUpdatesToolStripMenuItem.Enabled = !_isPlotting;
            checkForUpdatesToolStripMenuItem.ToolTipText = _isPlotting
                ? "Stop plotting to check for updates"
                : "Check for new plotter versions on GitHub";
        }

        private async System.Threading.Tasks.Task ShowDownloadDialogForMissingExecutables(bool cpuMissing, bool gpuMissing)
        {
            try
            {
                using (var updateManager = new PlotterUpdateManager())
                {
                    var updateInfo = await updateManager.CheckForUpdatesAsync();

                    using (var dialog = new UpdateDialog(updateInfo, updateManager, missingExecutables: true, cpuMissing: cpuMissing, gpuMissing: gpuMissing))
                    {
                        var result = dialog.ShowDialog(this);

                        if (result != DialogResult.OK)
                        {
                            // User cancelled or failed to download - exit application
                            MessageBox.Show(
                                "Required executables are missing. Application will now exit.",
                                "Missing Executables",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                            Application.Exit();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to check for updates: {ex.Message}\n\nPlease download the executables manually from:\nhttps://github.com/PoC-Consortium/pocx/releases",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                Application.Exit();
            }
        }

        private async System.Threading.Tasks.Task CheckForUpdatesAsync(bool silent = false)
        {
            try
            {
                using (var updateManager = new PlotterUpdateManager())
                {
                    var updateInfo = await updateManager.CheckForUpdatesAsync();

                    // Update last check time
                    Properties.Settings.Default.LastUpdateCheck = DateTime.UtcNow.ToString("o");
                    Properties.Settings.Default.Save();

                    // Always show dialog (allows downgrades and reinstalls, not just upgrades)
                    if (!silent)
                    {
                        using (var dialog = new UpdateDialog(updateInfo, updateManager))
                        {
                            dialog.ShowDialog(this);
                        }
                    }
                    else if (updateInfo.UpdateAvailable)
                    {
                        // Silent mode only shows dialog if update is available
                        using (var dialog = new UpdateDialog(updateInfo, updateManager))
                        {
                            dialog.ShowDialog(this);
                        }
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
                        MessageBoxIcon.Warning
                    );
                }
            }
        }

        private async void MenuItemCheckForUpdates_Click(object sender, EventArgs e)
        {
            await CheckForUpdatesAsync(silent: false);
        }

        // Copy command to clipboard
        private void BtnCopyCommand_Click(object sender, EventArgs e)
        {
            try
            {
                var config = BuildPlotterConfig();
                string commandLine = PlotterProcess.GetFullCommandLine(config);
                Clipboard.SetText(commandLine);
                MessageBox.Show(
                    "Command copied to clipboard!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to copy command: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // Build plotter configuration from current form settings
        private PlotterConfig BuildPlotterConfig()
        {
            // Calculate warps to plot
            decimal warps_to_plot;
            switch (cmb_Units.SelectedItem.ToString())
            {
                case "Warps":
                case "GiB":
                    warps_to_plot = nud_PlotSize.Value;
                    break;
                case "TiB":
                    warps_to_plot = nud_PlotSize.Value * BYTES_PER_KIB;
                    break;
                default:
                    warps_to_plot = nud_PlotSize.Value;
                    break;
            }

            // Build config
            var config = new PlotterConfig
            {
                AccountAddress = txt_Address.Text,
                Warps = warps_to_plot,
                PlotMaximumSize = rb_PlotSizeMaximum.Checked,
                OutputPaths = lv_OutputPaths.Items.OfType<ListViewItem>().Select(x => x.Text).ToList(),
                NumFiles = (int)nud_FilesToPlot.Value,
                UseMemoryLimit = chk_MemoryLimit.Checked,
                MemoryLimitMiB = (int)nud_MemoryLimit.Value,
                DirectIo = chk_DirectIO.Checked,
                LowPriority = chk_LowPriority.Checked,
                Benchmark = chk_Benchmark.Checked,
                ZeroCopyBuffers = chk_ZeroCopyBuffers.Checked && _opencl,
                UseCustomEncounters = chk_CustomEncounters.Checked,
                Encounters = nud_Encounters.Value,
                CompressionRatio = nud_Compression.Value,
                UseCustomWorkGroups = chk_CustomWorkGroupSize.Checked && _opencl,
                WorkGroups = nud_WorkGroupSize.Value,
                UseOpenCl = _opencl,
                UseFixedSeed = chk_FixedSeed.Checked,
                Seed = txt_Seed.Text,
                Devices = new List<DeviceConfig>()
            };

            // Add devices
            for (int i = 0; i < dgv_Devices.Rows.Count; i++)
            {
                if ((bool)dgv_Devices.Rows[i].Cells[0].Value)
                {
                    bool isCpu = dgv_Devices.Rows[i].Cells[1].Value.ToString().StartsWith(DEVICE_TYPE_CPU, StringComparison.Ordinal);
                    string gpuId = "";
                    if (!isCpu)
                    {
                        // Extract GPU ID from "GPU[0:0]: Name" format
                        string deviceName = dgv_Devices.Rows[i].Cells[1].Value.ToString();
                        int startIdx = deviceName.IndexOf('[') + 1;
                        int endIdx = deviceName.IndexOf(']');
                        gpuId = deviceName.Substring(startIdx, endIdx - startIdx);
                    }

                    config.Devices.Add(new DeviceConfig
                    {
                        IsCpu = isCpu,
                        GpuId = gpuId,
                        ThreadCount = int.Parse(dgv_Devices.Rows[i].Cells[3].Value.ToString())
                    });
                }
            }

            return config;
        }
    }
}
