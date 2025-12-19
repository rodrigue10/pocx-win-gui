namespace PoCXMinerGUI
{
    partial class UpdateDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblCurrentVersion = new Label();
            lblLatestVersion = new Label();
            lblProgress = new Label();
            lblReleaseDate = new Label();
            txtReleaseNotes = new TextBox();
            chkAutoCheck = new CheckBox();
            cmbVersionSelector = new ComboBox();
            btnCancel = new Button();
            btnDownloadBoth = new Button();
            progressBar = new ProgressBar();
            lblNotesHeader = new Label();
            lblVersionSelector = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(652, 21);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "_missingExecutables ? \"Download Required Executables\" : \"Manage Miner Versions\"";
            // 
            // lblCurrentVersion
            // 
            lblCurrentVersion.AutoSize = true;
            lblCurrentVersion.Location = new Point(62, 71);
            lblCurrentVersion.Name = "lblCurrentVersion";
            lblCurrentVersion.Size = new Size(262, 15);
            lblCurrentVersion.TabIndex = 2;
            lblCurrentVersion.Text = "$\"Current Version: {_updateInfo.CurrentVersion}\"";
            // 
            // lblLatestVersion
            // 
            lblLatestVersion.AutoSize = true;
            lblLatestVersion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLatestVersion.Location = new Point(62, 108);
            lblLatestVersion.Name = "lblLatestVersion";
            lblLatestVersion.Size = new Size(263, 15);
            lblLatestVersion.TabIndex = 3;
            lblLatestVersion.Text = "$\"Latest Version: {_updateInfo.LatestVersion}\"";
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Location = new Point(140, 698);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(87, 15);
            lblProgress.TabIndex = 4;
            lblProgress.Text = "Progress Status";
            lblProgress.Visible = false;
            // 
            // lblReleaseDate
            // 
            lblReleaseDate.AutoSize = true;
            lblReleaseDate.Location = new Point(69, 177);
            lblReleaseDate.Name = "lblReleaseDate";
            lblReleaseDate.Size = new Size(599, 15);
            lblReleaseDate.TabIndex = 5;
            lblReleaseDate.Text = "_updateInfo.PublishedAt.HasValue ? $\"Released: {_updateInfo.PublishedAt.Value:yyyy-MM-dd HH:mm} UTC\" : \"\"";
            // 
            // txtReleaseNotes
            // 
            txtReleaseNotes.Location = new Point(12, 262);
            txtReleaseNotes.Multiline = true;
            txtReleaseNotes.Name = "txtReleaseNotes";
            txtReleaseNotes.ReadOnly = true;
            txtReleaseNotes.ScrollBars = ScrollBars.Both;
            txtReleaseNotes.Size = new Size(930, 383);
            txtReleaseNotes.TabIndex = 6;
            txtReleaseNotes.TabStop = false;
            txtReleaseNotes.Text = "_updateInfo.ReleaseNotes ?? \"No release notes available.\"";
            // 
            // chkAutoCheck
            // 
            chkAutoCheck.AutoSize = true;
            chkAutoCheck.Location = new Point(12, 784);
            chkAutoCheck.Name = "chkAutoCheck";
            chkAutoCheck.Size = new Size(254, 19);
            chkAutoCheck.TabIndex = 7;
            chkAutoCheck.Text = "Automatically check for updates on startup";
            chkAutoCheck.UseVisualStyleBackColor = true;
            chkAutoCheck.CheckedChanged += ChkAutoCheck_CheckedChanged;
            // 
            // cmbVersionSelector
            // 
            cmbVersionSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVersionSelector.FormattingEnabled = true;
            cmbVersionSelector.Location = new Point(193, 141);
            cmbVersionSelector.Name = "cmbVersionSelector";
            cmbVersionSelector.Size = new Size(522, 23);
            cmbVersionSelector.TabIndex = 8;
            cmbVersionSelector.SelectedIndexChanged += CmbVersionSelector_SelectedIndexChanged;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(774, 784);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnDownloadBoth
            // 
            btnDownloadBoth.Location = new Point(412, 784);
            btnDownloadBoth.Name = "btnDownloadBoth";
            btnDownloadBoth.Size = new Size(112, 34);
            btnDownloadBoth.TabIndex = 10;
            btnDownloadBoth.Text = "Update";
            btnDownloadBoth.UseVisualStyleBackColor = true;
            btnDownloadBoth.Click += BtnDownload_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(140, 661);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(746, 34);
            progressBar.TabIndex = 11;
            progressBar.Visible = false;
            // 
            // lblNotesHeader
            // 
            lblNotesHeader.AutoSize = true;
            lblNotesHeader.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNotesHeader.Location = new Point(12, 231);
            lblNotesHeader.Name = "lblNotesHeader";
            lblNotesHeader.Size = new Size(107, 19);
            lblNotesHeader.TabIndex = 12;
            lblNotesHeader.Text = "Release Notes:";
            // 
            // lblVersionSelector
            // 
            lblVersionSelector.AutoSize = true;
            lblVersionSelector.Location = new Point(62, 144);
            lblVersionSelector.Name = "lblVersionSelector";
            lblVersionSelector.Size = new Size(82, 15);
            lblVersionSelector.TabIndex = 15;
            lblVersionSelector.Text = "Select Version:";
            // 
            // UpdateDialog
            // 
            ClientSize = new Size(954, 834);
            Controls.Add(lblVersionSelector);
            Controls.Add(lblNotesHeader);
            Controls.Add(progressBar);
            Controls.Add(btnDownloadBoth);
            Controls.Add(btnCancel);
            Controls.Add(cmbVersionSelector);
            Controls.Add(chkAutoCheck);
            Controls.Add(txtReleaseNotes);
            Controls.Add(lblReleaseDate);
            Controls.Add(lblProgress);
            Controls.Add(lblLatestVersion);
            Controls.Add(lblCurrentVersion);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "UpdateDialog";
            Text = "_missingExecutables ? \"Download Required Executables\" : \"Manage Miner Versions\"";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblTitle;
        private Label lblCurrentVersion;
        private Label lblLatestVersion;
        private Label lblProgress;
        private Label lblReleaseDate;
        private TextBox txtReleaseNotes;
        private CheckBox chkAutoCheck;
        private ComboBox cmbVersionSelector;
        private Button btnCancel;
        private Button btnDownloadBoth;
        private ProgressBar progressBar;
        private Label lblNotesHeader;
        private Label lblVersionSelector;
    }
}