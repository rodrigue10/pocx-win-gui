using System;
using System.Drawing;
using System.Windows.Forms;
using PoCX.Common;

namespace PoCXMinerGUI
{
    public partial class UpdateDialog : Form
    {
        private readonly MinerUpdateCheckResult _updateInfo;
        private readonly MinerUpdateManager _updateManager;
        private readonly bool _missingExecutable;

        private Label lblTitle;
        private Label lblCurrentVersion;
        private Label lblLatestVersion;
        private Label lblVersionSelector;
        private ComboBox cmbVersionSelector;
        private Label lblReleaseDate;
        private TextBox txtReleaseNotes;
        private ProgressBar progressBar;
        private Label lblProgress;
        private Button btnDownload;
        private Button btnCancel;
        private CheckBox chkAutoCheck;
        private MinerReleaseInfo _selectedRelease;

        public UpdateDialog(MinerUpdateCheckResult updateInfo, MinerUpdateManager updateManager, bool missingExecutable = false)
        {
            _updateInfo = updateInfo;
            _updateManager = updateManager;
            _missingExecutable = missingExecutable;

            InitializeComponent();
            PopulateDialog();
        }

        private void InitializeComponent()
        {
            this.Text = _missingExecutable ? "Download Required Executable" : "Manage Miner Versions";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(600, 500);

            lblTitle = new Label
            {
                Location = new Point(20, 20),
                Size = new Size(560, 30),
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Text = _missingExecutable ? "Missing Miner Executable" : "Manage Miner Versions"
            };

            lblCurrentVersion = new Label
            {
                Location = new Point(20, 60),
                Size = new Size(560, 20),
                Text = $"Current Version: {_updateInfo.CurrentVersion}"
            };

            lblLatestVersion = new Label
            {
                Location = new Point(20, 85),
                Size = new Size(560, 20),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Text = $"Latest Version: {_updateInfo.LatestVersion}"
            };

            lblVersionSelector = new Label
            {
                Location = new Point(20, 115),
                Size = new Size(150, 20),
                Text = "Select Version:",
                Font = new Font("Segoe UI", 9F, FontStyle.Regular)
            };

            cmbVersionSelector = new ComboBox
            {
                Location = new Point(170, 113),
                Size = new Size(410, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbVersionSelector.SelectedIndexChanged += CmbVersionSelector_SelectedIndexChanged;

            lblReleaseDate = new Label
            {
                Location = new Point(20, 145),
                Size = new Size(560, 20),
                Text = _updateInfo.PublishedAt.HasValue
                    ? $"Released: {_updateInfo.PublishedAt.Value:yyyy-MM-dd HH:mm} UTC"
                    : ""
            };

            var lblNotesHeader = new Label
            {
                Location = new Point(20, 175),
                Size = new Size(560, 20),
                Text = "Release Notes:",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };

            txtReleaseNotes = new TextBox
            {
                Location = new Point(20, 200),
                Size = new Size(560, 115),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                ReadOnly = true,
                Text = _updateInfo.ReleaseNotes ?? "No release notes available."
            };

            progressBar = new ProgressBar
            {
                Location = new Point(20, 330),
                Size = new Size(560, 25),
                Visible = false
            };

            lblProgress = new Label
            {
                Location = new Point(20, 360),
                Size = new Size(560, 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = false
            };

            chkAutoCheck = new CheckBox
            {
                Location = new Point(20, 390),
                Size = new Size(300, 20),
                Text = "Automatically check for updates on startup",
                Checked = Properties.Settings.Default.AutoCheckForUpdates
            };
            chkAutoCheck.CheckedChanged += ChkAutoCheck_CheckedChanged;

            btnDownload = new Button
            {
                Location = new Point(370, 420),
                Size = new Size(100, 30),
                Text = _missingExecutable ? "Download" : "Update",
                Enabled = _updateInfo.IsMinerAvailable
            };
            btnDownload.Click += BtnDownload_Click;

            btnCancel = new Button
            {
                Location = new Point(480, 420),
                Size = new Size(100, 30),
                Text = _missingExecutable ? "Exit" : "Cancel",
                DialogResult = DialogResult.Cancel
            };

            this.Controls.Add(lblTitle);
            this.Controls.Add(lblCurrentVersion);
            this.Controls.Add(lblLatestVersion);
            this.Controls.Add(lblVersionSelector);
            this.Controls.Add(cmbVersionSelector);
            this.Controls.Add(lblReleaseDate);
            this.Controls.Add(lblNotesHeader);
            this.Controls.Add(txtReleaseNotes);
            this.Controls.Add(progressBar);
            this.Controls.Add(lblProgress);
            this.Controls.Add(chkAutoCheck);
            this.Controls.Add(btnDownload);
            this.Controls.Add(btnCancel);

            this.CancelButton = btnCancel;

            if (_missingExecutable)
            {
                this.ControlBox = false;
            }
        }

        private void PopulateDialog()
        {
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
                btnDownload.Enabled = selectedRelease.IsMinerAvailable;
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
                btnDownload.Enabled = false;
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

                btnDownload.Enabled = _updateInfo.IsMinerAvailable;
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
