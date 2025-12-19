using PoCX.Common;

namespace PoCXPlotterGUI
{
    public partial class UpdateDialog : Form
    {
        private readonly PlotterUpdateCheckResult _updateInfo;
        private readonly PlotterUpdateManager _updateManager;
        private readonly bool _missingExecutables;
        private readonly bool _cpuMissing;
        private readonly bool _gpuMissing;



        private PlotterReleaseInfo _selectedRelease;

        public UpdateDialog(PlotterUpdateCheckResult updateInfo, PlotterUpdateManager updateManager, bool missingExecutables = false, bool cpuMissing = false, bool gpuMissing = false)
        {
            _updateInfo = updateInfo;
            _updateManager = updateManager;
            _missingExecutables = missingExecutables;
            _cpuMissing = cpuMissing;
            _gpuMissing = gpuMissing;

            InitializeComponent();

            PopulateDialog();
        }


        private void PopulateDialog()
        {
            Text = _missingExecutables ? "Download Required Executables" : "Manage Plotter Versions";

            chkAutoCheck.Checked = Properties.Settings.Default.AutoCheckForUpdates;
            btnDownloadBoth.Enabled = _updateInfo.IsCpuAvailable && _updateInfo.IsGpuAvailable;

            btnDownloadBoth.Text = _missingExecutables ? "Download" : "Update";

            lblReleaseDate.Text = _updateInfo.PublishedAt.HasValue ? $"Released: {_updateInfo.PublishedAt.Value:yyyy-MM-dd HH:mm} UTC" : "";


            lblNotesHeader.Text = "Release Notes:";

            txtReleaseNotes.Text = _updateInfo.ReleaseNotes ?? "No release notes available.";

            lblTitle.Text = _missingExecutables ? "Missing Plotter Executables" : "Manage Plotter Versions";
            lblCurrentVersion.Text = $"Current Version: {_updateInfo.CurrentVersion}";
            lblLatestVersion.Text = $"Latest Version: {_updateInfo.LatestVersion}";


            if (_updateInfo.AvailableReleases != null && _updateInfo.AvailableReleases.Count > 0)
            {
                cmbVersionSelector.Items.Clear();
                foreach (var release in _updateInfo.AvailableReleases)
                {
                    cmbVersionSelector.Items.Add(release);
                }

                cmbVersionSelector.SelectedIndex = 0;
                _selectedRelease = _updateInfo.AvailableReleases[0];
            }

            if (_missingExecutables)
            {
                lblTitle.ForeColor = Color.Red;
                lblCurrentVersion.Text = "Required executables are missing!";
                lblLatestVersion.Text = "CPU and GPU plotters will be downloaded.";
            }
        }

        private void CmbVersionSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVersionSelector.SelectedItem is PlotterReleaseInfo selectedRelease)
            {
                _selectedRelease = selectedRelease;

                lblReleaseDate.Text = selectedRelease.PublishedAt.HasValue
                    ? $"Released: {selectedRelease.PublishedAt.Value:yyyy-MM-dd HH:mm} UTC"
                    : "";

                txtReleaseNotes.Text = selectedRelease.ReleaseNotes ?? "No release notes available.";
                btnDownloadBoth.Enabled = selectedRelease.IsCpuAvailable && selectedRelease.IsGpuAvailable;
            }
        }

        private void ChkAutoCheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoCheckForUpdates = chkAutoCheck.Checked;
            Properties.Settings.Default.Save();
        }

        private async void BtnDownloadCpu_Click(object sender, EventArgs e)
        {
            await DownloadUpdate(ExecutableType.CPU);
        }

        private async void BtnDownloadGpu_Click(object sender, EventArgs e)
        {
            await DownloadUpdate(ExecutableType.GPU);
        }

        private async void BtnDownloadBoth_Click(object sender, EventArgs e)
        {
            await DownloadUpdate(ExecutableType.Both);
        }

        private async Task DownloadUpdate(ExecutableType type)
        {
            try
            {
                btnDownloadBoth.Enabled = false;
                btnCancel.Enabled = false;

                progressBar.Visible = true;
                lblProgress.Visible = true;
                lblProgress.Text = "Downloading...";

                _updateManager.DownloadProgressChanged += UpdateManager_DownloadProgressChanged;

                await _updateManager.DownloadAndInstallAsync(type, _selectedRelease);

                lblProgress.Text = "Update completed successfully!";
                MessageBox.Show(
                    "Update completed successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                lblProgress.Text = "Update failed!";
                MessageBox.Show(
                    $"Failed to download update: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                btnDownloadBoth.Enabled = _updateInfo.IsCpuAvailable && _updateInfo.IsGpuAvailable;
                btnCancel.Enabled = true;
                progressBar.Visible = false;
                lblProgress.Visible = false;
            }
            finally
            {
                _updateManager.DownloadProgressChanged -= UpdateManager_DownloadProgressChanged;
            }
        }

        private void UpdateManager_DownloadProgressChanged(object sender, DownloadProgressEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler<DownloadProgressEventArgs>(UpdateManager_DownloadProgressChanged), sender, e);
                return;
            }

            progressBar.Value = e.ProgressPercentage;
            lblProgress.Text = $"Downloading {e.FileName}: {e.ProgressPercentage}% ({DownloadProgressEventArgs.FormatBytes(e.BytesReceived)} / {DownloadProgressEventArgs.FormatBytes(e.TotalBytes)})";
        }

     
    }
}
