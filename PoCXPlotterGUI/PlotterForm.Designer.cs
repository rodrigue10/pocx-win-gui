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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlotterForm));
            folderBrowserDialog = new FolderBrowserDialog();
            openFileDialog = new OpenFileDialog();
            btn_start = new Button();
            btn_CopyCommand = new Button();
            statusStrip = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            pbar = new ToolStripProgressBar();
            statusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            pbar2 = new ToolStripProgressBar();
            statusLabel2 = new ToolStripStatusLabel();
            StatusLabel3 = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            resumeFileToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            checkForUpdatesToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            aboutToolStripMenuItem2 = new ToolStripMenuItem();
            tabControl1 = new TabControl();
            tab_BasicSettings = new TabPage();
            txt_Seed = new TextBox();
            chk_FixedSeed = new CheckBox();
            btn_RemovePath = new Button();
            lv_OutputPaths = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            lbl_AddressFormat = new Label();
            nud_FilesToPlot = new NumericUpDown();
            lbl_FilesToPlot = new Label();
            lbl_PlotSize = new Label();
            cmb_Units = new ComboBox();
            lbl_Output = new Label();
            txt_PlotOutput = new TextBox();
            rb_PlotSizeValue = new RadioButton();
            rb_PlotSizeMaximum = new RadioButton();
            txt_Address = new TextBox();
            lbl_ID = new Label();
            lbl_PlotFilename = new Label();
            lbl_PlotPreview = new Label();
            btn_OutputFolder = new Button();
            nud_PlotSize = new NumericUpDown();
            lbl_target = new Label();
            lbl_SizeToPlot = new Label();
            tab_AdvancedSettings = new TabPage();
            nud_Compression = new NumericUpDown();
            lbl_CompressionX = new Label();
            chk_CustomEncounters = new CheckBox();
            nud_Encounters = new NumericUpDown();
            lbl_GPU = new Label();
            chk_CustomWorkGroupSize = new CheckBox();
            nud_WorkGroupSize = new NumericUpDown();
            dgv_Devices = new DataGridView();
            Column1 = new DataGridViewCheckBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            chk_ZeroCopyBuffers = new CheckBox();
            lbl_XPU = new Label();
            lbl_OPT = new Label();
            chk_Benchmark = new CheckBox();
            chk_LowPriority = new CheckBox();
            chk_DirectIO = new CheckBox();
            lbl_IO = new Label();
            lbl_RAM = new Label();
            chk_MemoryLimit = new CheckBox();
            lbl_RAM2 = new Label();
            nud_MemoryLimit = new NumericUpDown();
            toolTips = new ToolTip(components);
            statusStrip.SuspendLayout();
            menuStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tab_BasicSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_FilesToPlot).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_PlotSize).BeginInit();
            tab_AdvancedSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_Compression).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_Encounters).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_WorkGroupSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_Devices).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_MemoryLimit).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "PoCX Plot files|*_*_*_*.*;*_*_*.*";
            // 
            // btn_start
            // 
            btn_start.Location = new Point(662, 454);
            btn_start.Margin = new Padding(5, 6, 5, 6);
            btn_start.Name = "btn_start";
            btn_start.Size = new Size(255, 58);
            btn_start.TabIndex = 18;
            btn_start.Text = "Start Plotting";
            btn_start.UseVisualStyleBackColor = true;
            btn_start.Click += Start_Click;
            // 
            // btn_CopyCommand
            // 
            btn_CopyCommand.Location = new Point(927, 454);
            btn_CopyCommand.Margin = new Padding(5, 6, 5, 6);
            btn_CopyCommand.Name = "btn_CopyCommand";
            btn_CopyCommand.Size = new Size(50, 58);
            btn_CopyCommand.TabIndex = 19;
            btn_CopyCommand.Text = "📋";
            toolTips.SetToolTip(btn_CopyCommand, "Copy command to clipboard");
            btn_CopyCommand.UseVisualStyleBackColor = true;
            btn_CopyCommand.Click += BtnCopyCommand_Click;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(24, 24);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, pbar, statusLabel1, toolStripStatusLabel2, pbar2, statusLabel2, StatusLabel3 });
            statusStrip.Location = new Point(0, 934);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(2, 0, 23, 0);
            statusStrip.ShowItemToolTips = true;
            statusStrip.Size = new Size(1030, 35);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(67, 28);
            toolStripStatusLabel1.Text = "Hasher";
            // 
            // pbar
            // 
            pbar.Name = "pbar";
            pbar.Size = new Size(167, 27);
            pbar.ToolTipText = "Hasher Progress";
            // 
            // statusLabel1
            // 
            statusLabel1.Name = "statusLabel1";
            statusLabel1.Size = new Size(50, 28);
            statusLabel1.Text = "(idle)";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(60, 28);
            toolStripStatusLabel2.Text = "Writer";
            // 
            // pbar2
            // 
            pbar2.Name = "pbar2";
            pbar2.Size = new Size(167, 27);
            pbar2.ToolTipText = "Writer Progress";
            // 
            // statusLabel2
            // 
            statusLabel2.Name = "statusLabel2";
            statusLabel2.Size = new Size(50, 28);
            statusLabel2.Text = "(idle)";
            // 
            // StatusLabel3
            // 
            StatusLabel3.Name = "StatusLabel3";
            StatusLabel3.Size = new Size(32, 28);
            StatusLabel3.Text = "    ";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(10, 4, 0, 4);
            menuStrip1.Size = new Size(1030, 37);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { resumeFileToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(54, 29);
            fileToolStripMenuItem.Text = "&File";
            // 
            // resumeFileToolStripMenuItem
            // 
            resumeFileToolStripMenuItem.Name = "resumeFileToolStripMenuItem";
            resumeFileToolStripMenuItem.Size = new Size(219, 34);
            resumeFileToolStripMenuItem.Text = "&Resume File...";
            resumeFileToolStripMenuItem.Click += ResumeFileToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(216, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(219, 34);
            exitToolStripMenuItem.Text = "&Exit";
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem1, toolStripSeparator2, checkForUpdatesToolStripMenuItem, toolStripSeparator3, aboutToolStripMenuItem2 });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(65, 29);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem1
            // 
            aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            aboutToolStripMenuItem1.Size = new Size(272, 34);
            aboutToolStripMenuItem1.Text = "&Help";
            aboutToolStripMenuItem1.Click += AboutToolStripMenuItem1_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(269, 6);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            checkForUpdatesToolStripMenuItem.Size = new Size(272, 34);
            checkForUpdatesToolStripMenuItem.Text = "Check for &Updates...";
            checkForUpdatesToolStripMenuItem.Click += MenuItemCheckForUpdates_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(269, 6);
            // 
            // aboutToolStripMenuItem2
            // 
            aboutToolStripMenuItem2.Name = "aboutToolStripMenuItem2";
            aboutToolStripMenuItem2.Size = new Size(272, 34);
            aboutToolStripMenuItem2.Text = "&About";
            aboutToolStripMenuItem2.Click += AboutToolStripMenuItem2_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tab_BasicSettings);
            tabControl1.Controls.Add(tab_AdvancedSettings);
            tabControl1.Location = new Point(20, 43);
            tabControl1.Margin = new Padding(5, 6, 5, 6);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(996, 885);
            tabControl1.TabIndex = 1;
            // 
            // tab_BasicSettings
            // 
            tab_BasicSettings.Controls.Add(txt_Seed);
            tab_BasicSettings.Controls.Add(chk_FixedSeed);
            tab_BasicSettings.Controls.Add(btn_RemovePath);
            tab_BasicSettings.Controls.Add(lv_OutputPaths);
            tab_BasicSettings.Controls.Add(lbl_AddressFormat);
            tab_BasicSettings.Controls.Add(nud_FilesToPlot);
            tab_BasicSettings.Controls.Add(lbl_FilesToPlot);
            tab_BasicSettings.Controls.Add(lbl_PlotSize);
            tab_BasicSettings.Controls.Add(cmb_Units);
            tab_BasicSettings.Controls.Add(lbl_Output);
            tab_BasicSettings.Controls.Add(txt_PlotOutput);
            tab_BasicSettings.Controls.Add(rb_PlotSizeValue);
            tab_BasicSettings.Controls.Add(rb_PlotSizeMaximum);
            tab_BasicSettings.Controls.Add(txt_Address);
            tab_BasicSettings.Controls.Add(btn_start);
            tab_BasicSettings.Controls.Add(btn_CopyCommand);
            tab_BasicSettings.Controls.Add(lbl_ID);
            tab_BasicSettings.Controls.Add(lbl_PlotFilename);
            tab_BasicSettings.Controls.Add(lbl_PlotPreview);
            tab_BasicSettings.Controls.Add(btn_OutputFolder);
            tab_BasicSettings.Controls.Add(nud_PlotSize);
            tab_BasicSettings.Controls.Add(lbl_target);
            tab_BasicSettings.Controls.Add(lbl_SizeToPlot);
            tab_BasicSettings.Location = new Point(4, 34);
            tab_BasicSettings.Margin = new Padding(5, 6, 5, 6);
            tab_BasicSettings.Name = "tab_BasicSettings";
            tab_BasicSettings.Padding = new Padding(5, 6, 5, 6);
            tab_BasicSettings.Size = new Size(988, 847);
            tab_BasicSettings.TabIndex = 0;
            tab_BasicSettings.Text = "Basic Settings";
            tab_BasicSettings.UseVisualStyleBackColor = true;
            // 
            // txt_Seed
            // 
            txt_Seed.Enabled = false;
            txt_Seed.Location = new Point(455, 288);
            txt_Seed.Margin = new Padding(5, 6, 5, 6);
            txt_Seed.MaxLength = 64;
            txt_Seed.Name = "txt_Seed";
            txt_Seed.Size = new Size(466, 31);
            txt_Seed.TabIndex = 30;
            toolTips.SetToolTip(txt_Seed, "plot seed value (64 hex characters)");
            // 
            // chk_FixedSeed
            // 
            chk_FixedSeed.AutoSize = true;
            chk_FixedSeed.Location = new Point(313, 294);
            chk_FixedSeed.Margin = new Padding(5, 6, 5, 6);
            chk_FixedSeed.Name = "chk_FixedSeed";
            chk_FixedSeed.Size = new Size(123, 29);
            chk_FixedSeed.TabIndex = 29;
            chk_FixedSeed.Text = "Fixed Seed";
            toolTips.SetToolTip(chk_FixedSeed, "use same seed for all plot files");
            chk_FixedSeed.UseVisualStyleBackColor = true;
            chk_FixedSeed.CheckedChanged += FixedSeed_CheckedChanged;
            // 
            // btn_RemovePath
            // 
            btn_RemovePath.Location = new Point(15, 179);
            btn_RemovePath.Margin = new Padding(5, 6, 5, 6);
            btn_RemovePath.Name = "btn_RemovePath";
            btn_RemovePath.Size = new Size(110, 38);
            btn_RemovePath.TabIndex = 28;
            btn_RemovePath.Text = "Remove";
            toolTips.SetToolTip(btn_RemovePath, "remove selected output path");
            btn_RemovePath.UseVisualStyleBackColor = true;
            btn_RemovePath.Click += RemovePath_Click;
            // 
            // lv_OutputPaths
            // 
            lv_OutputPaths.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            lv_OutputPaths.FullRowSelect = true;
            lv_OutputPaths.Location = new Point(170, 81);
            lv_OutputPaths.Margin = new Padding(5, 6, 5, 6);
            lv_OutputPaths.Name = "lv_OutputPaths";
            lv_OutputPaths.Size = new Size(751, 196);
            lv_OutputPaths.TabIndex = 27;
            lv_OutputPaths.UseCompatibleStateImageBehavior = false;
            lv_OutputPaths.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Path";
            columnHeader1.Width = 280;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Available GiB";
            columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Sector Size";
            columnHeader3.Width = 88;
            // 
            // lbl_AddressFormat
            // 
            lbl_AddressFormat.AutoSize = true;
            lbl_AddressFormat.Location = new Point(672, 29);
            lbl_AddressFormat.Margin = new Padding(5, 0, 5, 0);
            lbl_AddressFormat.Name = "lbl_AddressFormat";
            lbl_AddressFormat.Size = new Size(0, 25);
            lbl_AddressFormat.TabIndex = 26;
            // 
            // nud_FilesToPlot
            // 
            nud_FilesToPlot.Location = new Point(170, 292);
            nud_FilesToPlot.Margin = new Padding(5, 6, 5, 6);
            nud_FilesToPlot.Maximum = new decimal(new int[] { -1, -1, 0, 0 });
            nud_FilesToPlot.Name = "nud_FilesToPlot";
            nud_FilesToPlot.Size = new Size(82, 31);
            nud_FilesToPlot.TabIndex = 25;
            nud_FilesToPlot.TextAlign = HorizontalAlignment.Right;
            nud_FilesToPlot.ThousandsSeparator = true;
            toolTips.SetToolTip(nud_FilesToPlot, "number of plot files to create");
            nud_FilesToPlot.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nud_FilesToPlot.ValueChanged += FilesToPlot_ValueChanged;
            // 
            // lbl_FilesToPlot
            // 
            lbl_FilesToPlot.AutoSize = true;
            lbl_FilesToPlot.Location = new Point(10, 296);
            lbl_FilesToPlot.Margin = new Padding(5, 0, 5, 0);
            lbl_FilesToPlot.Name = "lbl_FilesToPlot";
            lbl_FilesToPlot.Size = new Size(105, 25);
            lbl_FilesToPlot.TabIndex = 24;
            lbl_FilesToPlot.Text = "Files to plot";
            // 
            // lbl_PlotSize
            // 
            lbl_PlotSize.AutoSize = true;
            lbl_PlotSize.Location = new Point(747, 356);
            lbl_PlotSize.Margin = new Padding(5, 0, 5, 0);
            lbl_PlotSize.Name = "lbl_PlotSize";
            lbl_PlotSize.Size = new Size(90, 25);
            lbl_PlotSize.TabIndex = 15;
            lbl_PlotSize.Text = "(available)";
            // 
            // cmb_Units
            // 
            cmb_Units.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_Units.FormattingEnabled = true;
            cmb_Units.Items.AddRange(new object[] { "Warps", "GiB", "TiB" });
            cmb_Units.Location = new Point(620, 350);
            cmb_Units.Margin = new Padding(5, 6, 5, 6);
            cmb_Units.Name = "cmb_Units";
            cmb_Units.Size = new Size(97, 33);
            cmb_Units.TabIndex = 14;
            cmb_Units.Tag = "";
            cmb_Units.SelectedIndexChanged += Units_SelectedIndexChanged;
            // 
            // lbl_Output
            // 
            lbl_Output.AutoSize = true;
            lbl_Output.Location = new Point(13, 492);
            lbl_Output.Margin = new Padding(5, 0, 5, 0);
            lbl_Output.Name = "lbl_Output";
            lbl_Output.Size = new Size(69, 25);
            lbl_Output.TabIndex = 19;
            lbl_Output.Text = "Output";
            // 
            // txt_PlotOutput
            // 
            txt_PlotOutput.Font = new Font("Lucida Console", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_PlotOutput.Location = new Point(13, 523);
            txt_PlotOutput.Margin = new Padding(5, 6, 5, 6);
            txt_PlotOutput.Multiline = true;
            txt_PlotOutput.Name = "txt_PlotOutput";
            txt_PlotOutput.ReadOnly = true;
            txt_PlotOutput.ScrollBars = ScrollBars.Vertical;
            txt_PlotOutput.Size = new Size(966, 314);
            txt_PlotOutput.TabIndex = 20;
            // 
            // rb_PlotSizeValue
            // 
            rb_PlotSizeValue.AutoSize = true;
            rb_PlotSizeValue.Location = new Point(313, 352);
            rb_PlotSizeValue.Margin = new Padding(5, 6, 5, 6);
            rb_PlotSizeValue.Name = "rb_PlotSizeValue";
            rb_PlotSizeValue.Size = new Size(79, 29);
            rb_PlotSizeValue.TabIndex = 12;
            rb_PlotSizeValue.Text = "Value";
            toolTips.SetToolTip(rb_PlotSizeValue, "specify plot file size");
            rb_PlotSizeValue.UseVisualStyleBackColor = true;
            // 
            // rb_PlotSizeMaximum
            // 
            rb_PlotSizeMaximum.AutoSize = true;
            rb_PlotSizeMaximum.Checked = true;
            rb_PlotSizeMaximum.Location = new Point(170, 352);
            rb_PlotSizeMaximum.Margin = new Padding(5, 6, 5, 6);
            rb_PlotSizeMaximum.Name = "rb_PlotSizeMaximum";
            rb_PlotSizeMaximum.Size = new Size(116, 29);
            rb_PlotSizeMaximum.TabIndex = 11;
            rb_PlotSizeMaximum.TabStop = true;
            rb_PlotSizeMaximum.Text = "Maximum";
            toolTips.SetToolTip(rb_PlotSizeMaximum, "plot all available space");
            rb_PlotSizeMaximum.UseVisualStyleBackColor = true;
            rb_PlotSizeMaximum.CheckedChanged += PlotSizeMaximum_CheckedChanged;
            // 
            // txt_Address
            // 
            txt_Address.Location = new Point(170, 23);
            txt_Address.Margin = new Padding(5, 6, 5, 6);
            txt_Address.Name = "txt_Address";
            txt_Address.Size = new Size(489, 31);
            txt_Address.TabIndex = 1;
            toolTips.SetToolTip(txt_Address, "your PoCX address");
            txt_Address.TextChanged += Address_TextChanged;
            // 
            // lbl_ID
            // 
            lbl_ID.AutoSize = true;
            lbl_ID.Location = new Point(10, 29);
            lbl_ID.Margin = new Padding(5, 0, 5, 0);
            lbl_ID.Name = "lbl_ID";
            lbl_ID.Size = new Size(77, 25);
            lbl_ID.TabIndex = 0;
            lbl_ID.Text = "Address";
            // 
            // lbl_PlotFilename
            // 
            lbl_PlotFilename.AutoSize = true;
            lbl_PlotFilename.Location = new Point(165, 415);
            lbl_PlotFilename.Margin = new Padding(5, 0, 5, 0);
            lbl_PlotFilename.Name = "lbl_PlotFilename";
            lbl_PlotFilename.Size = new Size(90, 25);
            lbl_PlotFilename.TabIndex = 17;
            lbl_PlotFilename.Text = "(available)";
            // 
            // lbl_PlotPreview
            // 
            lbl_PlotPreview.AutoSize = true;
            lbl_PlotPreview.Location = new Point(10, 415);
            lbl_PlotPreview.Margin = new Padding(5, 0, 5, 0);
            lbl_PlotPreview.Name = "lbl_PlotPreview";
            lbl_PlotPreview.Size = new Size(108, 25);
            lbl_PlotPreview.TabIndex = 16;
            lbl_PlotPreview.Text = "Plot Preview";
            // 
            // btn_OutputFolder
            // 
            btn_OutputFolder.Location = new Point(15, 129);
            btn_OutputFolder.Margin = new Padding(5, 6, 5, 6);
            btn_OutputFolder.Name = "btn_OutputFolder";
            btn_OutputFolder.Size = new Size(110, 38);
            btn_OutputFolder.TabIndex = 4;
            btn_OutputFolder.Text = "Add...";
            toolTips.SetToolTip(btn_OutputFolder, "Locate output folder...");
            btn_OutputFolder.UseVisualStyleBackColor = true;
            btn_OutputFolder.Click += Btn_OutputFolder_Click;
            // 
            // nud_PlotSize
            // 
            nud_PlotSize.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            nud_PlotSize.Location = new Point(410, 352);
            nud_PlotSize.Margin = new Padding(5, 6, 5, 6);
            nud_PlotSize.Maximum = new decimal(new int[] { -1, -1, 0, 0 });
            nud_PlotSize.Name = "nud_PlotSize";
            nud_PlotSize.Size = new Size(200, 31);
            nud_PlotSize.TabIndex = 13;
            nud_PlotSize.TextAlign = HorizontalAlignment.Right;
            nud_PlotSize.ThousandsSeparator = true;
            toolTips.SetToolTip(nud_PlotSize, "size you want to plot");
            nud_PlotSize.ValueChanged += PlotSize_ValueChanged;
            nud_PlotSize.Enter += PlotSize_Enter;
            // 
            // lbl_target
            // 
            lbl_target.AutoSize = true;
            lbl_target.Location = new Point(10, 81);
            lbl_target.Margin = new Padding(5, 0, 5, 0);
            lbl_target.Name = "lbl_target";
            lbl_target.Size = new Size(126, 25);
            lbl_target.TabIndex = 2;
            lbl_target.Text = "Output Path(s)";
            // 
            // lbl_SizeToPlot
            // 
            lbl_SizeToPlot.AutoSize = true;
            lbl_SizeToPlot.Location = new Point(10, 356);
            lbl_SizeToPlot.Margin = new Padding(5, 0, 5, 0);
            lbl_SizeToPlot.Name = "lbl_SizeToPlot";
            lbl_SizeToPlot.Size = new Size(102, 25);
            lbl_SizeToPlot.TabIndex = 10;
            lbl_SizeToPlot.Text = "Size to plot";
            // 
            // tab_AdvancedSettings
            // 
            tab_AdvancedSettings.Controls.Add(nud_Compression);
            tab_AdvancedSettings.Controls.Add(lbl_CompressionX);
            tab_AdvancedSettings.Controls.Add(chk_CustomEncounters);
            tab_AdvancedSettings.Controls.Add(nud_Encounters);
            tab_AdvancedSettings.Controls.Add(lbl_GPU);
            tab_AdvancedSettings.Controls.Add(chk_CustomWorkGroupSize);
            tab_AdvancedSettings.Controls.Add(nud_WorkGroupSize);
            tab_AdvancedSettings.Controls.Add(dgv_Devices);
            tab_AdvancedSettings.Controls.Add(chk_ZeroCopyBuffers);
            tab_AdvancedSettings.Controls.Add(lbl_XPU);
            tab_AdvancedSettings.Controls.Add(lbl_OPT);
            tab_AdvancedSettings.Controls.Add(chk_Benchmark);
            tab_AdvancedSettings.Controls.Add(chk_LowPriority);
            tab_AdvancedSettings.Controls.Add(chk_DirectIO);
            tab_AdvancedSettings.Controls.Add(lbl_IO);
            tab_AdvancedSettings.Controls.Add(lbl_RAM);
            tab_AdvancedSettings.Controls.Add(chk_MemoryLimit);
            tab_AdvancedSettings.Controls.Add(lbl_RAM2);
            tab_AdvancedSettings.Controls.Add(nud_MemoryLimit);
            tab_AdvancedSettings.Location = new Point(4, 34);
            tab_AdvancedSettings.Margin = new Padding(5, 6, 5, 6);
            tab_AdvancedSettings.Name = "tab_AdvancedSettings";
            tab_AdvancedSettings.Padding = new Padding(5, 6, 5, 6);
            tab_AdvancedSettings.Size = new Size(988, 847);
            tab_AdvancedSettings.TabIndex = 1;
            tab_AdvancedSettings.Text = "Advanced Settings";
            tab_AdvancedSettings.UseVisualStyleBackColor = true;
            // 
            // nud_Compression
            // 
            nud_Compression.Location = new Point(100, 546);
            nud_Compression.Margin = new Padding(5, 6, 5, 6);
            nud_Compression.Maximum = new decimal(new int[] { -1, -1, 0, 0 });
            nud_Compression.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nud_Compression.Name = "nud_Compression";
            nud_Compression.Size = new Size(82, 31);
            nud_Compression.TabIndex = 32;
            nud_Compression.TextAlign = HorizontalAlignment.Right;
            nud_Compression.ThousandsSeparator = true;
            toolTips.SetToolTip(nud_Compression, "Compression (X1 = default)");
            nud_Compression.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nud_Compression.ValueChanged += Compression_ValueChanged;
            // 
            // lbl_CompressionX
            // 
            lbl_CompressionX.AutoSize = true;
            lbl_CompressionX.Location = new Point(20, 550);
            lbl_CompressionX.Margin = new Padding(5, 0, 5, 0);
            lbl_CompressionX.Name = "lbl_CompressionX";
            lbl_CompressionX.Size = new Size(23, 25);
            lbl_CompressionX.TabIndex = 31;
            lbl_CompressionX.Text = "X";
            // 
            // chk_CustomEncounters
            // 
            chk_CustomEncounters.AutoSize = true;
            chk_CustomEncounters.Location = new Point(455, 306);
            chk_CustomEncounters.Margin = new Padding(5, 6, 5, 6);
            chk_CustomEncounters.Name = "chk_CustomEncounters";
            chk_CustomEncounters.Size = new Size(225, 29);
            chk_CustomEncounters.TabIndex = 29;
            chk_CustomEncounters.Text = "Buffer Multiplier (tweak)";
            toolTips.SetToolTip(chk_CustomEncounters, "enable custom encounters (PoW difficulty)");
            chk_CustomEncounters.UseVisualStyleBackColor = true;
            chk_CustomEncounters.CheckedChanged += CustomEncounters_CheckedChanged;
            // 
            // nud_Encounters
            // 
            nud_Encounters.Enabled = false;
            nud_Encounters.Location = new Point(692, 304);
            nud_Encounters.Margin = new Padding(5, 6, 5, 6);
            nud_Encounters.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
            nud_Encounters.Name = "nud_Encounters";
            nud_Encounters.Size = new Size(82, 31);
            nud_Encounters.TabIndex = 30;
            nud_Encounters.TextAlign = HorizontalAlignment.Right;
            toolTips.SetToolTip(nud_Encounters, "encounters multiplier for PoW generation");
            nud_Encounters.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nud_Encounters.ValueChanged += Encounters_ValueChanged;
            // 
            // lbl_GPU
            // 
            lbl_GPU.AutoSize = true;
            lbl_GPU.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_GPU.Location = new Point(20, 492);
            lbl_GPU.Margin = new Padding(5, 0, 5, 0);
            lbl_GPU.Name = "lbl_GPU";
            lbl_GPU.Size = new Size(45, 20);
            lbl_GPU.TabIndex = 25;
            lbl_GPU.Text = "GPU";
            // 
            // chk_CustomWorkGroupSize
            // 
            chk_CustomWorkGroupSize.AutoSize = true;
            chk_CustomWorkGroupSize.Location = new Point(100, 490);
            chk_CustomWorkGroupSize.Margin = new Padding(5, 6, 5, 6);
            chk_CustomWorkGroupSize.Name = "chk_CustomWorkGroupSize";
            chk_CustomWorkGroupSize.Size = new Size(299, 29);
            chk_CustomWorkGroupSize.TabIndex = 26;
            chk_CustomWorkGroupSize.Text = "WorkgroupSize overwrite (tweak)";
            toolTips.SetToolTip(chk_CustomWorkGroupSize, "enable custom GPU work group size");
            chk_CustomWorkGroupSize.UseVisualStyleBackColor = true;
            chk_CustomWorkGroupSize.CheckedChanged += CustomWorkGroupSize_CheckedChanged;
            // 
            // nud_WorkGroupSize
            // 
            nud_WorkGroupSize.Enabled = false;
            nud_WorkGroupSize.Location = new Point(412, 488);
            nud_WorkGroupSize.Margin = new Padding(5, 6, 5, 6);
            nud_WorkGroupSize.Maximum = new decimal(new int[] { 1024, 0, 0, 0 });
            nud_WorkGroupSize.Name = "nud_WorkGroupSize";
            nud_WorkGroupSize.Size = new Size(90, 31);
            nud_WorkGroupSize.TabIndex = 27;
            nud_WorkGroupSize.TextAlign = HorizontalAlignment.Right;
            toolTips.SetToolTip(nud_WorkGroupSize, "GPU work group size (OpenCL parameter)");
            nud_WorkGroupSize.Value = new decimal(new int[] { 512, 0, 0, 0 });
            nud_WorkGroupSize.ValueChanged += WorkGroupSize_ValueChanged;
            // 
            // dgv_Devices
            // 
            dgv_Devices.AllowUserToAddRows = false;
            dgv_Devices.AllowUserToDeleteRows = false;
            dgv_Devices.AllowUserToResizeColumns = false;
            dgv_Devices.AllowUserToResizeRows = false;
            dgv_Devices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Devices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Devices.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            dgv_Devices.EditMode = DataGridViewEditMode.EditOnEnter;
            dgv_Devices.Location = new Point(27, 69);
            dgv_Devices.Margin = new Padding(5, 6, 5, 6);
            dgv_Devices.MultiSelect = false;
            dgv_Devices.Name = "dgv_Devices";
            dgv_Devices.RowHeadersVisible = false;
            dgv_Devices.RowHeadersWidth = 62;
            dgv_Devices.ScrollBars = ScrollBars.Vertical;
            dgv_Devices.Size = new Size(930, 208);
            dgv_Devices.TabIndex = 24;
            toolTips.SetToolTip(dgv_Devices, "choose hashing devices and optionally limit the number of threads to use");
            dgv_Devices.CellValidating += Devices_CellValidating;
            dgv_Devices.CellValueChanged += Devices_CellValueChanged;
            // 
            // Column1
            // 
            Column1.FillWeight = 60.9137F;
            Column1.HeaderText = "Enabled";
            Column1.MinimumWidth = 8;
            Column1.Name = "Column1";
            Column1.Resizable = DataGridViewTriState.True;
            // 
            // Column2
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            Column2.DefaultCellStyle = dataGridViewCellStyle1;
            Column2.FillWeight = 205.9229F;
            Column2.HeaderText = "Device";
            Column2.MinimumWidth = 8;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            dataGridViewCellStyle2.BackColor = Color.FromArgb(224, 224, 224);
            Column3.DefaultCellStyle = dataGridViewCellStyle2;
            Column3.FillWeight = 66.58172F;
            Column3.HeaderText = "Cores";
            Column3.MinimumWidth = 8;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            Column4.FillWeight = 66.58172F;
            Column4.HeaderText = "Thread Limit";
            Column4.MinimumWidth = 8;
            Column4.Name = "Column4";
            Column4.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // chk_ZeroCopyBuffers
            // 
            chk_ZeroCopyBuffers.AutoSize = true;
            chk_ZeroCopyBuffers.Location = new Point(455, 429);
            chk_ZeroCopyBuffers.Margin = new Padding(5, 6, 5, 6);
            chk_ZeroCopyBuffers.Name = "chk_ZeroCopyBuffers";
            chk_ZeroCopyBuffers.Size = new Size(237, 29);
            chk_ZeroCopyBuffers.TabIndex = 22;
            chk_ZeroCopyBuffers.Text = "GPU Zero Copy Buffering";
            toolTips.SetToolTip(chk_ZeroCopyBuffers, "use zero copy buffers - enable this if you are using GPUs with shared memory");
            chk_ZeroCopyBuffers.UseVisualStyleBackColor = true;
            chk_ZeroCopyBuffers.CheckedChanged += ZeroCopyBuffers_CheckedChanged;
            // 
            // lbl_XPU
            // 
            lbl_XPU.AutoSize = true;
            lbl_XPU.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_XPU.Location = new Point(18, 29);
            lbl_XPU.Margin = new Padding(5, 0, 5, 0);
            lbl_XPU.Name = "lbl_XPU";
            lbl_XPU.Size = new Size(43, 20);
            lbl_XPU.TabIndex = 15;
            lbl_XPU.Text = "XPU";
            // 
            // lbl_OPT
            // 
            lbl_OPT.AutoSize = true;
            lbl_OPT.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_OPT.Location = new Point(20, 431);
            lbl_OPT.Margin = new Padding(5, 0, 5, 0);
            lbl_OPT.Name = "lbl_OPT";
            lbl_OPT.Size = new Size(43, 20);
            lbl_OPT.TabIndex = 14;
            lbl_OPT.Text = "OPT";
            // 
            // chk_Benchmark
            // 
            chk_Benchmark.AutoSize = true;
            chk_Benchmark.Location = new Point(248, 429);
            chk_Benchmark.Margin = new Padding(5, 6, 5, 6);
            chk_Benchmark.Name = "chk_Benchmark";
            chk_Benchmark.Size = new Size(177, 29);
            chk_Benchmark.TabIndex = 13;
            chk_Benchmark.Text = "Benchmark mode";
            toolTips.SetToolTip(chk_Benchmark, "enable benchmark mode");
            chk_Benchmark.UseVisualStyleBackColor = true;
            chk_Benchmark.CheckedChanged += Benchmark_CheckedChanged;
            // 
            // chk_LowPriority
            // 
            chk_LowPriority.AutoSize = true;
            chk_LowPriority.Location = new Point(100, 429);
            chk_LowPriority.Margin = new Padding(5, 6, 5, 6);
            chk_LowPriority.Name = "chk_LowPriority";
            chk_LowPriority.Size = new Size(132, 29);
            chk_LowPriority.TabIndex = 4;
            chk_LowPriority.Text = "Low priority";
            toolTips.SetToolTip(chk_LowPriority, "run plotter as low priority process");
            chk_LowPriority.UseVisualStyleBackColor = true;
            chk_LowPriority.CheckedChanged += LowPriority_CheckedChanged;
            // 
            // chk_DirectIO
            // 
            chk_DirectIO.AutoSize = true;
            chk_DirectIO.Checked = true;
            chk_DirectIO.CheckState = CheckState.Checked;
            chk_DirectIO.Location = new Point(100, 367);
            chk_DirectIO.Margin = new Padding(5, 6, 5, 6);
            chk_DirectIO.Name = "chk_DirectIO";
            chk_DirectIO.Size = new Size(115, 29);
            chk_DirectIO.TabIndex = 10;
            chk_DirectIO.Text = "Direct I/O";
            toolTips.SetToolTip(chk_DirectIO, "enable direct i/o - direct disk writes without buffering");
            chk_DirectIO.UseVisualStyleBackColor = true;
            chk_DirectIO.CheckedChanged += DirectIO_CheckedChanged;
            // 
            // lbl_IO
            // 
            lbl_IO.AutoSize = true;
            lbl_IO.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_IO.Location = new Point(20, 369);
            lbl_IO.Margin = new Padding(5, 0, 5, 0);
            lbl_IO.Name = "lbl_IO";
            lbl_IO.Size = new Size(31, 20);
            lbl_IO.TabIndex = 9;
            lbl_IO.Text = "I/O";
            // 
            // lbl_RAM
            // 
            lbl_RAM.AutoSize = true;
            lbl_RAM.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_RAM.Location = new Point(20, 308);
            lbl_RAM.Margin = new Padding(5, 0, 5, 0);
            lbl_RAM.Name = "lbl_RAM";
            lbl_RAM.Size = new Size(46, 20);
            lbl_RAM.TabIndex = 5;
            lbl_RAM.Text = "RAM";
            // 
            // chk_MemoryLimit
            // 
            chk_MemoryLimit.AutoSize = true;
            chk_MemoryLimit.Location = new Point(100, 306);
            chk_MemoryLimit.Margin = new Padding(5, 6, 5, 6);
            chk_MemoryLimit.Name = "chk_MemoryLimit";
            chk_MemoryLimit.Size = new Size(144, 29);
            chk_MemoryLimit.TabIndex = 6;
            chk_MemoryLimit.Text = "Memory limit";
            toolTips.SetToolTip(chk_MemoryLimit, "enable memory limit");
            chk_MemoryLimit.UseVisualStyleBackColor = true;
            chk_MemoryLimit.CheckedChanged += MemoryLimit_CheckedChanged;
            // 
            // lbl_RAM2
            // 
            lbl_RAM2.AutoSize = true;
            lbl_RAM2.Location = new Point(365, 308);
            lbl_RAM2.Margin = new Padding(5, 0, 5, 0);
            lbl_RAM2.Name = "lbl_RAM2";
            lbl_RAM2.Size = new Size(42, 25);
            lbl_RAM2.TabIndex = 8;
            lbl_RAM2.Text = "MiB";
            // 
            // nud_MemoryLimit
            // 
            nud_MemoryLimit.Enabled = false;
            nud_MemoryLimit.Location = new Point(248, 304);
            nud_MemoryLimit.Margin = new Padding(5, 6, 5, 6);
            nud_MemoryLimit.Maximum = new decimal(new int[] { 1024000, 0, 0, 0 });
            nud_MemoryLimit.Name = "nud_MemoryLimit";
            nud_MemoryLimit.Size = new Size(107, 31);
            nud_MemoryLimit.TabIndex = 7;
            nud_MemoryLimit.TextAlign = HorizontalAlignment.Right;
            toolTips.SetToolTip(nud_MemoryLimit, "set memory limit");
            nud_MemoryLimit.Value = new decimal(new int[] { 4096, 0, 0, 0 });
            nud_MemoryLimit.ValueChanged += MemoryLimit_ValueChanged;
            // 
            // PlotterForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1030, 969);
            Controls.Add(tabControl1);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            MaximizeBox = false;
            MaximumSize = new Size(1052, 1025);
            MinimumSize = new Size(1052, 1025);
            Name = "PlotterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PoCX Plotter GUI v.1.0.0";
            FormClosing += PlotterForm_FormClosing;
            Load += PlotterForm_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tab_BasicSettings.ResumeLayout(false);
            tab_BasicSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nud_FilesToPlot).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_PlotSize).EndInit();
            tab_AdvancedSettings.ResumeLayout(false);
            tab_AdvancedSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nud_Compression).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_Encounters).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_WorkGroupSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_Devices).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_MemoryLimit).EndInit();
            ResumeLayout(false);
            PerformLayout();

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

