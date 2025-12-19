namespace PoCXPlotterGUI
{
    partial class PlotterForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlotterForm));
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_CopyCommand = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbar = new System.Windows.Forms.ToolStripProgressBar();
            this.statusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbar2 = new System.Windows.Forms.ToolStripProgressBar();
            this.statusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_BasicSettings = new System.Windows.Forms.TabPage();
            this.txt_Seed = new System.Windows.Forms.TextBox();
            this.chk_FixedSeed = new System.Windows.Forms.CheckBox();
            this.btn_RemovePath = new System.Windows.Forms.Button();
            this.lv_OutputPaths = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbl_AddressFormat = new System.Windows.Forms.Label();
            this.nud_FilesToPlot = new System.Windows.Forms.NumericUpDown();
            this.lbl_FilesToPlot = new System.Windows.Forms.Label();
            this.lbl_PlotSize = new System.Windows.Forms.Label();
            this.cmb_Units = new System.Windows.Forms.ComboBox();
            this.lbl_Output = new System.Windows.Forms.Label();
            this.txt_PlotOutput = new System.Windows.Forms.TextBox();
            this.rb_PlotSizeValue = new System.Windows.Forms.RadioButton();
            this.rb_PlotSizeMaximum = new System.Windows.Forms.RadioButton();
            this.txt_Address = new System.Windows.Forms.TextBox();
            this.lbl_ID = new System.Windows.Forms.Label();
            this.lbl_PlotFilename = new System.Windows.Forms.Label();
            this.lbl_PlotPreview = new System.Windows.Forms.Label();
            this.btn_OutputFolder = new System.Windows.Forms.Button();
            this.nud_PlotSize = new System.Windows.Forms.NumericUpDown();
            this.lbl_target = new System.Windows.Forms.Label();
            this.lbl_SizeToPlot = new System.Windows.Forms.Label();
            this.tab_AdvancedSettings = new System.Windows.Forms.TabPage();
            this.nud_Compression = new System.Windows.Forms.NumericUpDown();
            this.lbl_CompressionX = new System.Windows.Forms.Label();
            this.chk_CustomEncounters = new System.Windows.Forms.CheckBox();
            this.nud_Encounters = new System.Windows.Forms.NumericUpDown();
            this.lbl_GPU = new System.Windows.Forms.Label();
            this.chk_CustomWorkGroupSize = new System.Windows.Forms.CheckBox();
            this.nud_WorkGroupSize = new System.Windows.Forms.NumericUpDown();
            this.dgv_Devices = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chk_ZeroCopyBuffers = new System.Windows.Forms.CheckBox();
            this.lbl_XPU = new System.Windows.Forms.Label();
            this.lbl_OPT = new System.Windows.Forms.Label();
            this.chk_Benchmark = new System.Windows.Forms.CheckBox();
            this.chk_LowPriority = new System.Windows.Forms.CheckBox();
            this.chk_DirectIO = new System.Windows.Forms.CheckBox();
            this.lbl_IO = new System.Windows.Forms.Label();
            this.lbl_RAM = new System.Windows.Forms.Label();
            this.chk_MemoryLimit = new System.Windows.Forms.CheckBox();
            this.lbl_RAM2 = new System.Windows.Forms.Label();
            this.nud_MemoryLimit = new System.Windows.Forms.NumericUpDown();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tab_BasicSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_FilesToPlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_PlotSize)).BeginInit();
            this.tab_AdvancedSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Compression)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Encounters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_WorkGroupSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Devices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MemoryLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "PoCX Plot files|*_*_*_*.*;*_*_*.*";
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(397, 236);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(153, 30);
            this.btn_start.TabIndex = 18;
            this.btn_start.Text = "Start Plotting";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.Start_Click);
            // 
            // btn_CopyCommand
            // 
            this.btn_CopyCommand.Location = new System.Drawing.Point(556, 236);
            this.btn_CopyCommand.Name = "btn_CopyCommand";
            this.btn_CopyCommand.Size = new System.Drawing.Size(30, 30);
            this.btn_CopyCommand.TabIndex = 19;
            this.btn_CopyCommand.Text = "📋";
            this.toolTips.SetToolTip(this.btn_CopyCommand, "Copy command to clipboard");
            this.btn_CopyCommand.UseVisualStyleBackColor = true;
            this.btn_CopyCommand.Click += new System.EventHandler(this.BtnCopyCommand_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.pbar,
            this.statusLabel1,
            this.toolStripStatusLabel2,
            this.pbar2,
            this.statusLabel2,
            this.StatusLabel3});
            this.statusStrip.Location = new System.Drawing.Point(0, 499);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.ShowItemToolTips = true;
            this.statusStrip.Size = new System.Drawing.Size(624, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel1.Text = "Hasher";
            //
            // pbar
            //
            this.pbar.AutoToolTip = false;
            this.pbar.Name = "pbar";
            this.pbar.Size = new System.Drawing.Size(100, 16);
            this.pbar.ToolTipText = "Hasher Progress";
            // 
            // statusLabel1
            // 
            this.statusLabel1.Name = "statusLabel1";
            this.statusLabel1.Size = new System.Drawing.Size(34, 17);
            this.statusLabel1.Text = "(idle)";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel2.Text = "Writer";
            //
            // pbar2
            //
            this.pbar2.AutoToolTip = false;
            this.pbar2.Name = "pbar2";
            this.pbar2.Size = new System.Drawing.Size(100, 16);
            this.pbar2.ToolTipText = "Writer Progress";
            // 
            // statusLabel2
            // 
            this.statusLabel2.Name = "statusLabel2";
            this.statusLabel2.Size = new System.Drawing.Size(34, 17);
            this.statusLabel2.Text = "(idle)";
            // 
            // StatusLabel3
            // 
            this.StatusLabel3.Name = "StatusLabel3";
            this.StatusLabel3.Size = new System.Drawing.Size(19, 17);
            this.StatusLabel3.Text = "    ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resumeFileToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // resumeFileToolStripMenuItem
            // 
            this.resumeFileToolStripMenuItem.Name = "resumeFileToolStripMenuItem";
            this.resumeFileToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.resumeFileToolStripMenuItem.Text = "&Resume File...";
            this.resumeFileToolStripMenuItem.Click += new System.EventHandler(this.ResumeFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1,
            this.toolStripSeparator2,
            this.checkForUpdatesToolStripMenuItem,
            this.toolStripSeparator3,
            this.aboutToolStripMenuItem2});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem1.Text = "&Help";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.AboutToolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check for &Updates...";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.MenuItemCheckForUpdates_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // aboutToolStripMenuItem2
            // 
            this.aboutToolStripMenuItem2.Name = "aboutToolStripMenuItem2";
            this.aboutToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem2.Text = "&About";
            this.aboutToolStripMenuItem2.Click += new System.EventHandler(this.AboutToolStripMenuItem2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_BasicSettings);
            this.tabControl1.Controls.Add(this.tab_AdvancedSettings);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(600, 469);
            this.tabControl1.TabIndex = 1;
            // 
            // tab_BasicSettings
            // 
            this.tab_BasicSettings.Controls.Add(this.txt_Seed);
            this.tab_BasicSettings.Controls.Add(this.chk_FixedSeed);
            this.tab_BasicSettings.Controls.Add(this.btn_RemovePath);
            this.tab_BasicSettings.Controls.Add(this.lv_OutputPaths);
            this.tab_BasicSettings.Controls.Add(this.lbl_AddressFormat);
            this.tab_BasicSettings.Controls.Add(this.nud_FilesToPlot);
            this.tab_BasicSettings.Controls.Add(this.lbl_FilesToPlot);
            this.tab_BasicSettings.Controls.Add(this.lbl_PlotSize);
            this.tab_BasicSettings.Controls.Add(this.cmb_Units);
            this.tab_BasicSettings.Controls.Add(this.lbl_Output);
            this.tab_BasicSettings.Controls.Add(this.txt_PlotOutput);
            this.tab_BasicSettings.Controls.Add(this.rb_PlotSizeValue);
            this.tab_BasicSettings.Controls.Add(this.rb_PlotSizeMaximum);
            this.tab_BasicSettings.Controls.Add(this.txt_Address);
            this.tab_BasicSettings.Controls.Add(this.btn_start);
            this.tab_BasicSettings.Controls.Add(this.btn_CopyCommand);
            this.tab_BasicSettings.Controls.Add(this.lbl_ID);
            this.tab_BasicSettings.Controls.Add(this.lbl_PlotFilename);
            this.tab_BasicSettings.Controls.Add(this.lbl_PlotPreview);
            this.tab_BasicSettings.Controls.Add(this.btn_OutputFolder);
            this.tab_BasicSettings.Controls.Add(this.nud_PlotSize);
            this.tab_BasicSettings.Controls.Add(this.lbl_target);
            this.tab_BasicSettings.Controls.Add(this.lbl_SizeToPlot);
            this.tab_BasicSettings.Location = new System.Drawing.Point(4, 22);
            this.tab_BasicSettings.Name = "tab_BasicSettings";
            this.tab_BasicSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tab_BasicSettings.Size = new System.Drawing.Size(592, 443);
            this.tab_BasicSettings.TabIndex = 0;
            this.tab_BasicSettings.Text = "Basic Settings";
            this.tab_BasicSettings.UseVisualStyleBackColor = true;
            // 
            // txt_Seed
            // 
            this.txt_Seed.Enabled = false;
            this.txt_Seed.Location = new System.Drawing.Point(273, 150);
            this.txt_Seed.MaxLength = 64;
            this.txt_Seed.Name = "txt_Seed";
            this.txt_Seed.Size = new System.Drawing.Size(281, 20);
            this.txt_Seed.TabIndex = 30;
            this.toolTips.SetToolTip(this.txt_Seed, "plot seed value (64 hex characters)");
            // 
            // chk_FixedSeed
            // 
            this.chk_FixedSeed.AutoSize = true;
            this.chk_FixedSeed.Location = new System.Drawing.Point(188, 153);
            this.chk_FixedSeed.Name = "chk_FixedSeed";
            this.chk_FixedSeed.Size = new System.Drawing.Size(79, 17);
            this.chk_FixedSeed.TabIndex = 29;
            this.chk_FixedSeed.Text = "Fixed Seed";
            this.toolTips.SetToolTip(this.chk_FixedSeed, "use same seed for all plot files");
            this.chk_FixedSeed.UseVisualStyleBackColor = true;
            this.chk_FixedSeed.CheckedChanged += new System.EventHandler(this.FixedSeed_CheckedChanged);
            // 
            // btn_RemovePath
            // 
            this.btn_RemovePath.Location = new System.Drawing.Point(9, 93);
            this.btn_RemovePath.Name = "btn_RemovePath";
            this.btn_RemovePath.Size = new System.Drawing.Size(66, 20);
            this.btn_RemovePath.TabIndex = 28;
            this.btn_RemovePath.Text = "Remove";
            this.toolTips.SetToolTip(this.btn_RemovePath, "remove selected output path");
            this.btn_RemovePath.UseVisualStyleBackColor = true;
            this.btn_RemovePath.Click += new System.EventHandler(this.RemovePath_Click);
            // 
            // lv_OutputPaths
            // 
            this.lv_OutputPaths.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lv_OutputPaths.FullRowSelect = true;
            this.lv_OutputPaths.HideSelection = false;
            this.lv_OutputPaths.Location = new System.Drawing.Point(102, 42);
            this.lv_OutputPaths.Name = "lv_OutputPaths";
            this.lv_OutputPaths.Size = new System.Drawing.Size(452, 104);
            this.lv_OutputPaths.TabIndex = 27;
            this.lv_OutputPaths.UseCompatibleStateImageBehavior = false;
            this.lv_OutputPaths.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Path";
            this.columnHeader1.Width = 280;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Available GiB";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Sector Size";
            this.columnHeader3.Width = 88;
            // 
            // lbl_AddressFormat
            // 
            this.lbl_AddressFormat.AutoSize = true;
            this.lbl_AddressFormat.Location = new System.Drawing.Point(403, 15);
            this.lbl_AddressFormat.Name = "lbl_AddressFormat";
            this.lbl_AddressFormat.Size = new System.Drawing.Size(0, 13);
            this.lbl_AddressFormat.TabIndex = 26;
            // 
            // nud_FilesToPlot
            // 
            this.nud_FilesToPlot.Location = new System.Drawing.Point(102, 152);
            this.nud_FilesToPlot.Maximum = new decimal(new int[] {
            -1,
            -1,
            0,
            0});
            this.nud_FilesToPlot.Name = "nud_FilesToPlot";
            this.nud_FilesToPlot.Size = new System.Drawing.Size(49, 20);
            this.nud_FilesToPlot.TabIndex = 25;
            this.nud_FilesToPlot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_FilesToPlot.ThousandsSeparator = true;
            this.toolTips.SetToolTip(this.nud_FilesToPlot, "number of plot files to create");
            this.nud_FilesToPlot.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_FilesToPlot.ValueChanged += new System.EventHandler(this.FilesToPlot_ValueChanged);
            // 
            // lbl_FilesToPlot
            // 
            this.lbl_FilesToPlot.AutoSize = true;
            this.lbl_FilesToPlot.Location = new System.Drawing.Point(6, 154);
            this.lbl_FilesToPlot.Name = "lbl_FilesToPlot";
            this.lbl_FilesToPlot.Size = new System.Drawing.Size(60, 13);
            this.lbl_FilesToPlot.TabIndex = 24;
            this.lbl_FilesToPlot.Text = "Files to plot";
            // 
            // lbl_PlotSize
            // 
            this.lbl_PlotSize.AutoSize = true;
            this.lbl_PlotSize.Location = new System.Drawing.Point(448, 185);
            this.lbl_PlotSize.Name = "lbl_PlotSize";
            this.lbl_PlotSize.Size = new System.Drawing.Size(55, 13);
            this.lbl_PlotSize.TabIndex = 15;
            this.lbl_PlotSize.Text = "(available)";
            // 
            // cmb_Units
            // 
            this.cmb_Units.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Units.FormattingEnabled = true;
            this.cmb_Units.Items.AddRange(new object[] {
            "Warps",
            "GiB",
            "TiB"});
            this.cmb_Units.Location = new System.Drawing.Point(372, 182);
            this.cmb_Units.Name = "cmb_Units";
            this.cmb_Units.Size = new System.Drawing.Size(60, 21);
            this.cmb_Units.TabIndex = 14;
            this.cmb_Units.Tag = "";
            this.cmb_Units.SelectedIndexChanged += new System.EventHandler(this.Units_SelectedIndexChanged);
            // 
            // lbl_Output
            // 
            this.lbl_Output.AutoSize = true;
            this.lbl_Output.Location = new System.Drawing.Point(8, 256);
            this.lbl_Output.Name = "lbl_Output";
            this.lbl_Output.Size = new System.Drawing.Size(39, 13);
            this.lbl_Output.TabIndex = 19;
            this.lbl_Output.Text = "Output";
            // 
            // txt_PlotOutput
            // 
            this.txt_PlotOutput.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PlotOutput.Location = new System.Drawing.Point(8, 272);
            this.txt_PlotOutput.Multiline = true;
            this.txt_PlotOutput.Name = "txt_PlotOutput";
            this.txt_PlotOutput.ReadOnly = true;
            this.txt_PlotOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_PlotOutput.Size = new System.Drawing.Size(581, 165);
            this.txt_PlotOutput.TabIndex = 20;
            // 
            // rb_PlotSizeValue
            // 
            this.rb_PlotSizeValue.AutoSize = true;
            this.rb_PlotSizeValue.Location = new System.Drawing.Point(188, 183);
            this.rb_PlotSizeValue.Name = "rb_PlotSizeValue";
            this.rb_PlotSizeValue.Size = new System.Drawing.Size(52, 17);
            this.rb_PlotSizeValue.TabIndex = 12;
            this.rb_PlotSizeValue.Text = "Value";
            this.toolTips.SetToolTip(this.rb_PlotSizeValue, "specify plot file size");
            this.rb_PlotSizeValue.UseVisualStyleBackColor = true;
            // 
            // rb_PlotSizeMaximum
            // 
            this.rb_PlotSizeMaximum.AutoSize = true;
            this.rb_PlotSizeMaximum.Checked = true;
            this.rb_PlotSizeMaximum.Location = new System.Drawing.Point(102, 183);
            this.rb_PlotSizeMaximum.Name = "rb_PlotSizeMaximum";
            this.rb_PlotSizeMaximum.Size = new System.Drawing.Size(69, 17);
            this.rb_PlotSizeMaximum.TabIndex = 11;
            this.rb_PlotSizeMaximum.TabStop = true;
            this.rb_PlotSizeMaximum.Text = "Maximum";
            this.toolTips.SetToolTip(this.rb_PlotSizeMaximum, "plot all available space");
            this.rb_PlotSizeMaximum.UseVisualStyleBackColor = true;
            this.rb_PlotSizeMaximum.CheckedChanged += new System.EventHandler(this.PlotSizeMaximum_CheckedChanged);
            // 
            // txt_Address
            // 
            this.txt_Address.Location = new System.Drawing.Point(102, 12);
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.Size = new System.Drawing.Size(295, 20);
            this.txt_Address.TabIndex = 1;
            this.toolTips.SetToolTip(this.txt_Address, "your PoCX address");
            this.txt_Address.TextChanged += new System.EventHandler(this.Address_TextChanged);
            // 
            // lbl_ID
            // 
            this.lbl_ID.AutoSize = true;
            this.lbl_ID.Location = new System.Drawing.Point(6, 15);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(45, 13);
            this.lbl_ID.TabIndex = 0;
            this.lbl_ID.Text = "Address";
            // 
            // lbl_PlotFilename
            // 
            this.lbl_PlotFilename.AutoSize = true;
            this.lbl_PlotFilename.Location = new System.Drawing.Point(99, 216);
            this.lbl_PlotFilename.Name = "lbl_PlotFilename";
            this.lbl_PlotFilename.Size = new System.Drawing.Size(55, 13);
            this.lbl_PlotFilename.TabIndex = 17;
            this.lbl_PlotFilename.Text = "(available)";
            // 
            // lbl_PlotPreview
            // 
            this.lbl_PlotPreview.AutoSize = true;
            this.lbl_PlotPreview.Location = new System.Drawing.Point(6, 216);
            this.lbl_PlotPreview.Name = "lbl_PlotPreview";
            this.lbl_PlotPreview.Size = new System.Drawing.Size(66, 13);
            this.lbl_PlotPreview.TabIndex = 16;
            this.lbl_PlotPreview.Text = "Plot Preview";
            // 
            // btn_OutputFolder
            // 
            this.btn_OutputFolder.Location = new System.Drawing.Point(9, 67);
            this.btn_OutputFolder.Name = "btn_OutputFolder";
            this.btn_OutputFolder.Size = new System.Drawing.Size(66, 20);
            this.btn_OutputFolder.TabIndex = 4;
            this.btn_OutputFolder.Text = "Add...";
            this.toolTips.SetToolTip(this.btn_OutputFolder, "Locate output folder...");
            this.btn_OutputFolder.UseVisualStyleBackColor = true;
            this.btn_OutputFolder.Click += new System.EventHandler(this.Btn_OutputFolder_Click);
            // 
            // nud_PlotSize
            // 
            this.nud_PlotSize.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nud_PlotSize.Location = new System.Drawing.Point(246, 183);
            this.nud_PlotSize.Maximum = new decimal(new int[] {
            -1,
            -1,
            0,
            0});
            this.nud_PlotSize.Name = "nud_PlotSize";
            this.nud_PlotSize.Size = new System.Drawing.Size(120, 20);
            this.nud_PlotSize.TabIndex = 13;
            this.nud_PlotSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_PlotSize.ThousandsSeparator = true;
            this.toolTips.SetToolTip(this.nud_PlotSize, "size you want to plot");
            this.nud_PlotSize.ValueChanged += new System.EventHandler(this.PlotSize_ValueChanged);
            this.nud_PlotSize.Enter += new System.EventHandler(this.PlotSize_Enter);
            // 
            // lbl_target
            // 
            this.lbl_target.AutoSize = true;
            this.lbl_target.Location = new System.Drawing.Point(6, 42);
            this.lbl_target.Name = "lbl_target";
            this.lbl_target.Size = new System.Drawing.Size(75, 13);
            this.lbl_target.TabIndex = 2;
            this.lbl_target.Text = "Output Path(s)";
            // 
            // lbl_SizeToPlot
            // 
            this.lbl_SizeToPlot.AutoSize = true;
            this.lbl_SizeToPlot.Location = new System.Drawing.Point(6, 185);
            this.lbl_SizeToPlot.Name = "lbl_SizeToPlot";
            this.lbl_SizeToPlot.Size = new System.Drawing.Size(59, 13);
            this.lbl_SizeToPlot.TabIndex = 10;
            this.lbl_SizeToPlot.Text = "Size to plot";
            // 
            // tab_AdvancedSettings
            // 
            this.tab_AdvancedSettings.Controls.Add(this.nud_Compression);
            this.tab_AdvancedSettings.Controls.Add(this.lbl_CompressionX);
            this.tab_AdvancedSettings.Controls.Add(this.chk_CustomEncounters);
            this.tab_AdvancedSettings.Controls.Add(this.nud_Encounters);
            this.tab_AdvancedSettings.Controls.Add(this.lbl_GPU);
            this.tab_AdvancedSettings.Controls.Add(this.chk_CustomWorkGroupSize);
            this.tab_AdvancedSettings.Controls.Add(this.nud_WorkGroupSize);
            this.tab_AdvancedSettings.Controls.Add(this.dgv_Devices);
            this.tab_AdvancedSettings.Controls.Add(this.chk_ZeroCopyBuffers);
            this.tab_AdvancedSettings.Controls.Add(this.lbl_XPU);
            this.tab_AdvancedSettings.Controls.Add(this.lbl_OPT);
            this.tab_AdvancedSettings.Controls.Add(this.chk_Benchmark);
            this.tab_AdvancedSettings.Controls.Add(this.chk_LowPriority);
            this.tab_AdvancedSettings.Controls.Add(this.chk_DirectIO);
            this.tab_AdvancedSettings.Controls.Add(this.lbl_IO);
            this.tab_AdvancedSettings.Controls.Add(this.lbl_RAM);
            this.tab_AdvancedSettings.Controls.Add(this.chk_MemoryLimit);
            this.tab_AdvancedSettings.Controls.Add(this.lbl_RAM2);
            this.tab_AdvancedSettings.Controls.Add(this.nud_MemoryLimit);
            this.tab_AdvancedSettings.Location = new System.Drawing.Point(4, 22);
            this.tab_AdvancedSettings.Name = "tab_AdvancedSettings";
            this.tab_AdvancedSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tab_AdvancedSettings.Size = new System.Drawing.Size(592, 443);
            this.tab_AdvancedSettings.TabIndex = 1;
            this.tab_AdvancedSettings.Text = "Advanced Settings";
            this.tab_AdvancedSettings.UseVisualStyleBackColor = true;
            // 
            // nud_Compression
            // 
            this.nud_Compression.Location = new System.Drawing.Point(60, 284);
            this.nud_Compression.Maximum = new decimal(new int[] {
            -1,
            -1,
            0,
            0});
            this.nud_Compression.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Compression.Name = "nud_Compression";
            this.nud_Compression.Size = new System.Drawing.Size(49, 20);
            this.nud_Compression.TabIndex = 32;
            this.nud_Compression.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_Compression.ThousandsSeparator = true;
            this.toolTips.SetToolTip(this.nud_Compression, "Compression (X1 = default)");
            this.nud_Compression.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Compression.ValueChanged += new System.EventHandler(this.Compression_ValueChanged);
            // 
            // lbl_CompressionX
            // 
            this.lbl_CompressionX.AutoSize = true;
            this.lbl_CompressionX.Location = new System.Drawing.Point(12, 286);
            this.lbl_CompressionX.Name = "lbl_CompressionX";
            this.lbl_CompressionX.Size = new System.Drawing.Size(14, 13);
            this.lbl_CompressionX.TabIndex = 31;
            this.lbl_CompressionX.Text = "X";
            // 
            // chk_CustomEncounters
            // 
            this.chk_CustomEncounters.AutoSize = true;
            this.chk_CustomEncounters.Location = new System.Drawing.Point(273, 159);
            this.chk_CustomEncounters.Name = "chk_CustomEncounters";
            this.chk_CustomEncounters.Size = new System.Drawing.Size(136, 17);
            this.chk_CustomEncounters.TabIndex = 29;
            this.chk_CustomEncounters.Text = "Buffer Multiplier (tweak)";
            this.toolTips.SetToolTip(this.chk_CustomEncounters, "enable custom encounters (PoW difficulty)");
            this.chk_CustomEncounters.UseVisualStyleBackColor = true;
            this.chk_CustomEncounters.CheckedChanged += new System.EventHandler(this.CustomEncounters_CheckedChanged);
            // 
            // nud_Encounters
            // 
            this.nud_Encounters.Enabled = false;
            this.nud_Encounters.Location = new System.Drawing.Point(415, 158);
            this.nud_Encounters.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.nud_Encounters.Name = "nud_Encounters";
            this.nud_Encounters.Size = new System.Drawing.Size(49, 20);
            this.nud_Encounters.TabIndex = 30;
            this.nud_Encounters.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTips.SetToolTip(this.nud_Encounters, "encounters multiplier for PoW generation");
            this.nud_Encounters.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Encounters.ValueChanged += new System.EventHandler(this.Encounters_ValueChanged);
            // 
            // lbl_GPU
            // 
            this.lbl_GPU.AutoSize = true;
            this.lbl_GPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GPU.Location = new System.Drawing.Point(12, 256);
            this.lbl_GPU.Name = "lbl_GPU";
            this.lbl_GPU.Size = new System.Drawing.Size(30, 13);
            this.lbl_GPU.TabIndex = 25;
            this.lbl_GPU.Text = "GPU";
            // 
            // chk_CustomWorkGroupSize
            // 
            this.chk_CustomWorkGroupSize.AutoSize = true;
            this.chk_CustomWorkGroupSize.Location = new System.Drawing.Point(60, 255);
            this.chk_CustomWorkGroupSize.Name = "chk_CustomWorkGroupSize";
            this.chk_CustomWorkGroupSize.Size = new System.Drawing.Size(183, 17);
            this.chk_CustomWorkGroupSize.TabIndex = 26;
            this.chk_CustomWorkGroupSize.Text = "WorkgroupSize overwrite (tweak)";
            this.toolTips.SetToolTip(this.chk_CustomWorkGroupSize, "enable custom GPU work group size");
            this.chk_CustomWorkGroupSize.UseVisualStyleBackColor = true;
            this.chk_CustomWorkGroupSize.CheckedChanged += new System.EventHandler(this.CustomWorkGroupSize_CheckedChanged);
            // 
            // nud_WorkGroupSize
            // 
            this.nud_WorkGroupSize.Enabled = false;
            this.nud_WorkGroupSize.Location = new System.Drawing.Point(247, 254);
            this.nud_WorkGroupSize.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nud_WorkGroupSize.Name = "nud_WorkGroupSize";
            this.nud_WorkGroupSize.Size = new System.Drawing.Size(54, 20);
            this.nud_WorkGroupSize.TabIndex = 27;
            this.nud_WorkGroupSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTips.SetToolTip(this.nud_WorkGroupSize, "GPU work group size (OpenCL parameter)");
            this.nud_WorkGroupSize.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.nud_WorkGroupSize.ValueChanged += new System.EventHandler(this.WorkGroupSize_ValueChanged);
            // 
            // dgv_Devices
            // 
            this.dgv_Devices.AllowUserToAddRows = false;
            this.dgv_Devices.AllowUserToDeleteRows = false;
            this.dgv_Devices.AllowUserToResizeColumns = false;
            this.dgv_Devices.AllowUserToResizeRows = false;
            this.dgv_Devices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Devices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Devices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgv_Devices.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_Devices.Location = new System.Drawing.Point(16, 36);
            this.dgv_Devices.MultiSelect = false;
            this.dgv_Devices.Name = "dgv_Devices";
            this.dgv_Devices.RowHeadersVisible = false;
            this.dgv_Devices.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_Devices.Size = new System.Drawing.Size(558, 108);
            this.dgv_Devices.TabIndex = 24;
            this.toolTips.SetToolTip(this.dgv_Devices, "choose hashing devices and optionally limit the number of threads to use");
            this.dgv_Devices.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.Devices_CellValidating);
            this.dgv_Devices.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Devices_CellValueChanged);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 60.9137F;
            this.Column1.HeaderText = "Enabled";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column2
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column2.FillWeight = 205.9229F;
            this.Column2.HeaderText = "Device";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3.FillWeight = 66.58172F;
            this.Column3.HeaderText = "Cores";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 66.58172F;
            this.Column4.HeaderText = "Thread Limit";
            this.Column4.Name = "Column4";
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // chk_ZeroCopyBuffers
            // 
            this.chk_ZeroCopyBuffers.AutoSize = true;
            this.chk_ZeroCopyBuffers.Location = new System.Drawing.Point(273, 223);
            this.chk_ZeroCopyBuffers.Name = "chk_ZeroCopyBuffers";
            this.chk_ZeroCopyBuffers.Size = new System.Drawing.Size(146, 17);
            this.chk_ZeroCopyBuffers.TabIndex = 22;
            this.chk_ZeroCopyBuffers.Text = "GPU Zero Copy Buffering";
            this.toolTips.SetToolTip(this.chk_ZeroCopyBuffers, "use zero copy buffers - enable this if you are using GPUs with shared memory");
            this.chk_ZeroCopyBuffers.UseVisualStyleBackColor = true;
            this.chk_ZeroCopyBuffers.CheckedChanged += new System.EventHandler(this.ZeroCopyBuffers_CheckedChanged);
            // 
            // lbl_XPU
            // 
            this.lbl_XPU.AutoSize = true;
            this.lbl_XPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_XPU.Location = new System.Drawing.Point(11, 15);
            this.lbl_XPU.Name = "lbl_XPU";
            this.lbl_XPU.Size = new System.Drawing.Size(29, 13);
            this.lbl_XPU.TabIndex = 15;
            this.lbl_XPU.Text = "XPU";
            // 
            // lbl_OPT
            // 
            this.lbl_OPT.AutoSize = true;
            this.lbl_OPT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_OPT.Location = new System.Drawing.Point(12, 224);
            this.lbl_OPT.Name = "lbl_OPT";
            this.lbl_OPT.Size = new System.Drawing.Size(29, 13);
            this.lbl_OPT.TabIndex = 14;
            this.lbl_OPT.Text = "OPT";
            // 
            // chk_Benchmark
            // 
            this.chk_Benchmark.AutoSize = true;
            this.chk_Benchmark.Location = new System.Drawing.Point(149, 223);
            this.chk_Benchmark.Name = "chk_Benchmark";
            this.chk_Benchmark.Size = new System.Drawing.Size(109, 17);
            this.chk_Benchmark.TabIndex = 13;
            this.chk_Benchmark.Text = "Benchmark mode";
            this.toolTips.SetToolTip(this.chk_Benchmark, "enable benchmark mode");
            this.chk_Benchmark.UseVisualStyleBackColor = true;
            this.chk_Benchmark.CheckedChanged += new System.EventHandler(this.Benchmark_CheckedChanged);
            // 
            // chk_LowPriority
            // 
            this.chk_LowPriority.AutoSize = true;
            this.chk_LowPriority.Location = new System.Drawing.Point(60, 223);
            this.chk_LowPriority.Name = "chk_LowPriority";
            this.chk_LowPriority.Size = new System.Drawing.Size(79, 17);
            this.chk_LowPriority.TabIndex = 4;
            this.chk_LowPriority.Text = "Low priority";
            this.toolTips.SetToolTip(this.chk_LowPriority, "run plotter as low priority process");
            this.chk_LowPriority.UseVisualStyleBackColor = true;
            this.chk_LowPriority.CheckedChanged += new System.EventHandler(this.LowPriority_CheckedChanged);
            // 
            // chk_DirectIO
            // 
            this.chk_DirectIO.AutoSize = true;
            this.chk_DirectIO.Checked = true;
            this.chk_DirectIO.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_DirectIO.Location = new System.Drawing.Point(60, 191);
            this.chk_DirectIO.Name = "chk_DirectIO";
            this.chk_DirectIO.Size = new System.Drawing.Size(73, 17);
            this.chk_DirectIO.TabIndex = 10;
            this.chk_DirectIO.Text = "Direct I/O";
            this.toolTips.SetToolTip(this.chk_DirectIO, "enable direct i/o - direct disk writes without buffering");
            this.chk_DirectIO.UseVisualStyleBackColor = true;
            this.chk_DirectIO.CheckedChanged += new System.EventHandler(this.DirectIO_CheckedChanged);
            // 
            // lbl_IO
            // 
            this.lbl_IO.AutoSize = true;
            this.lbl_IO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_IO.Location = new System.Drawing.Point(12, 192);
            this.lbl_IO.Name = "lbl_IO";
            this.lbl_IO.Size = new System.Drawing.Size(23, 13);
            this.lbl_IO.TabIndex = 9;
            this.lbl_IO.Text = "I/O";
            // 
            // lbl_RAM
            // 
            this.lbl_RAM.AutoSize = true;
            this.lbl_RAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_RAM.Location = new System.Drawing.Point(12, 160);
            this.lbl_RAM.Name = "lbl_RAM";
            this.lbl_RAM.Size = new System.Drawing.Size(31, 13);
            this.lbl_RAM.TabIndex = 5;
            this.lbl_RAM.Text = "RAM";
            // 
            // chk_MemoryLimit
            // 
            this.chk_MemoryLimit.AutoSize = true;
            this.chk_MemoryLimit.Location = new System.Drawing.Point(60, 159);
            this.chk_MemoryLimit.Name = "chk_MemoryLimit";
            this.chk_MemoryLimit.Size = new System.Drawing.Size(83, 17);
            this.chk_MemoryLimit.TabIndex = 6;
            this.chk_MemoryLimit.Text = "Memory limit";
            this.toolTips.SetToolTip(this.chk_MemoryLimit, "enable memory limit");
            this.chk_MemoryLimit.UseVisualStyleBackColor = true;
            this.chk_MemoryLimit.CheckedChanged += new System.EventHandler(this.MemoryLimit_CheckedChanged);
            // 
            // lbl_RAM2
            // 
            this.lbl_RAM2.AutoSize = true;
            this.lbl_RAM2.Location = new System.Drawing.Point(219, 160);
            this.lbl_RAM2.Name = "lbl_RAM2";
            this.lbl_RAM2.Size = new System.Drawing.Size(25, 13);
            this.lbl_RAM2.TabIndex = 8;
            this.lbl_RAM2.Text = "MiB";
            // 
            // nud_MemoryLimit
            // 
            this.nud_MemoryLimit.Enabled = false;
            this.nud_MemoryLimit.Location = new System.Drawing.Point(149, 158);
            this.nud_MemoryLimit.Maximum = new decimal(new int[] {
            1024000,
            0,
            0,
            0});
            this.nud_MemoryLimit.Name = "nud_MemoryLimit";
            this.nud_MemoryLimit.Size = new System.Drawing.Size(64, 20);
            this.nud_MemoryLimit.TabIndex = 7;
            this.nud_MemoryLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTips.SetToolTip(this.nud_MemoryLimit, "set memory limit");
            this.nud_MemoryLimit.Value = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.nud_MemoryLimit.ValueChanged += new System.EventHandler(this.MemoryLimit_ValueChanged);
            // 
            // PlotterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 521);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(640, 560);
            this.MinimumSize = new System.Drawing.Size(640, 560);
            this.Name = "PlotterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PoCX Plotter GUI v.1.0.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlotterForm_FormClosing);
            this.Load += new System.EventHandler(this.PlotterForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tab_BasicSettings.ResumeLayout(false);
            this.tab_BasicSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_FilesToPlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_PlotSize)).EndInit();
            this.tab_AdvancedSettings.ResumeLayout(false);
            this.tab_AdvancedSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Compression)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Encounters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_WorkGroupSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Devices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MemoryLimit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_CopyCommand;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel2;
        private System.Windows.Forms.ToolStripProgressBar pbar;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumeFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_BasicSettings;
        private System.Windows.Forms.RadioButton rb_PlotSizeValue;
        private System.Windows.Forms.RadioButton rb_PlotSizeMaximum;
        private System.Windows.Forms.TextBox txt_Address;
        private System.Windows.Forms.Label lbl_ID;
        private System.Windows.Forms.Label lbl_PlotFilename;
        private System.Windows.Forms.Label lbl_PlotPreview;
        private System.Windows.Forms.Button btn_OutputFolder;
        private System.Windows.Forms.NumericUpDown nud_PlotSize;
        private System.Windows.Forms.Label lbl_target;
        private System.Windows.Forms.Label lbl_SizeToPlot;
        private System.Windows.Forms.TabPage tab_AdvancedSettings;
        private System.Windows.Forms.CheckBox chk_LowPriority;
        private System.Windows.Forms.CheckBox chk_DirectIO;
        private System.Windows.Forms.Label lbl_IO;
        private System.Windows.Forms.Label lbl_RAM;
        private System.Windows.Forms.CheckBox chk_MemoryLimit;
        private System.Windows.Forms.Label lbl_RAM2;
        private System.Windows.Forms.NumericUpDown nud_MemoryLimit;
        private System.Windows.Forms.Label lbl_Output;
        private System.Windows.Forms.TextBox txt_PlotOutput;
        private System.Windows.Forms.ComboBox cmb_Units;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.Label lbl_PlotSize;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripProgressBar pbar2;
        private System.Windows.Forms.Label lbl_XPU;
        private System.Windows.Forms.Label lbl_OPT;
        private System.Windows.Forms.CheckBox chk_Benchmark;
        private System.Windows.Forms.CheckBox chk_ZeroCopyBuffers;
        private System.Windows.Forms.DataGridView dgv_Devices;
        private System.Windows.Forms.CheckBox chk_CustomEncounters;
        private System.Windows.Forms.Label lbl_GPU;
        private System.Windows.Forms.CheckBox chk_CustomWorkGroupSize;
        private System.Windows.Forms.NumericUpDown nud_Encounters;
        private System.Windows.Forms.NumericUpDown nud_WorkGroupSize;
        private System.Windows.Forms.ListView lv_OutputPaths;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btn_RemovePath;
        private System.Windows.Forms.NumericUpDown nud_FilesToPlot;
        private System.Windows.Forms.Label lbl_FilesToPlot;
        private System.Windows.Forms.Label lbl_AddressFormat;
        private System.Windows.Forms.NumericUpDown nud_Compression;
        private System.Windows.Forms.Label lbl_CompressionX;
        private System.Windows.Forms.TextBox txt_Seed;
        private System.Windows.Forms.CheckBox chk_FixedSeed;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}

