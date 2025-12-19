using PoCX.Common;

namespace PoCXMinerGUI
{
    public partial class UpdateDialog : Form
    {
        private readonly MinerUpdateCheckResult _updateInfo;
        private readonly MinerUpdateManager _updateManager;
        private readonly bool _missingExecutable;
        private readonly bool _cpuMissing;
        private readonly bool _gpuMissing;

        private MinerReleaseInfo _selectedRelease;

    

        public UpdateDialog(MinerUpdateCheckResult updateInfo, MinerUpdateManager updateManager, bool missingExecutable = false, bool cpuMissing = false, bool gpuMissing = false)
        {
            _updateInfo = updateInfo;
            _updateManager = updateManager;
            _missingExecutable = missingExecutable;
            _cpuMissing = cpuMissing;
            _gpuMissing = gpuMissing;

            InitializeComponent();

            PopulateDialog();
        }


        private void PopulateDialog()
        {
            btnCancel.Text = _missingExecutable ? "Exit" : "Cancel";
            Text = _missingExecutable ? "Download Required Executables" : "Manage Miner Versions";
            chkAutoCheck.Checked = Properties.Settings.Default.AutoCheckForUpdates;
            btnDownloadBoth.Text = _missingExecutable ? "Download" : "Update";
            lblReleaseDate.Text = _updateInfo.PublishedAt.HasValue ? $"Released: {_updateInfo.PublishedAt.Value:yyyy-MM-dd HH:mm} UTC" : "";
            lblNotesHeader.Text = "Release Notes:";
            txtReleaseNotes.Text = _updateInfo.ReleaseNotes ?? "No release notes available.";
            lblTitle.Text = _missingExecutable ? "Missing Miner Executables" : "Manage Miner Versions";
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

            if (_missingExecutable)
            {
                lblTitle.ForeColor = Color.Red;
                lblCurrentVersion.Text = "Required executable is missing!";
                lblLatestVersion.Text = "Miner executable needs to be downloaded.";
            }



        }



        private void CmbVersionSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVersionSelector.SelectedItem is MinerReleaseInfo selectedRelease)
            {
                _selectedRelease = selectedRelease;

                lblReleaseDate.Text = selectedRelease.PublishedAt.HasValue
                    ? $"Released: {selectedRelease.PublishedAt.Value:yyyy-MM-dd HH:mm} UTC"
                    : "";

                txtReleaseNotes.Text = selectedRelease.ReleaseNotes ?? "No release notes available.";
                btnDownloadBoth.Enabled = selectedRelease.IsMinerAvailable;
            }
        }

        private void ChkAutoCheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoCheckForUpdates = chkAutoCheck.Checked;
            Properties.Settings.Default.Save();
        }

        private async void BtnDownload_Click(object sender, EventArgs e)
        {
            await DownloadUpdate();
        }

        private async System.Threading.Tasks.Task DownloadUpdate()
        {
            try
            {
                btnDownloadBoth.Enabled = false;
                btnCancel.Enabled = false;

                progressBar.Visible = true;
                lblProgress.Visible = true;
                lblProgress.Text = "Downloading...";

                _updateManager.DownloadProgressChanged += UpdateManager_DownloadProgressChanged;

                await _updateManager.DownloadAndInstallAsync(_selectedRelease);

                lblProgress.Text = "Update completed successfully!";
                MessageBox.Show(
                    "Update completed successfully!\n\n" +
                    "The following files were updated:\n" +
                    "- pocx_miner.exe\n" +
                    "- default_config.yaml (if included in release)\n\n" +
                    "Previous versions backed up as .bak files.",
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

                btnDownloadBoth.Enabled = _updateInfo.IsMinerAvailable;
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
