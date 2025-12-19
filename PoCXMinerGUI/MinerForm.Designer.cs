namespace PoCXMinerGUI
{
    partial class MinerForm
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MinerForm));
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.sl_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbar = new System.Windows.Forms.ToolStripProgressBar();
            this.statusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToDefaultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tc_Main = new System.Windows.Forms.TabControl();
            this.tab_Status = new System.Windows.Forms.TabPage();
            this.lbl_Log = new System.Windows.Forms.Label();
            this.txt_MinerOutput = new System.Windows.Forms.TextBox();
            this.lv_sub = new System.Windows.Forms.ListView();
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbl_SubmissionHistory = new System.Windows.Forms.Label();
            this.lbl_MinerQueue = new System.Windows.Forms.Label();
            this.lv_queue = new System.Windows.Forms.ListView();
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_chains = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbl_ChainStates = new System.Windows.Forms.Label();
            this.lv_capa = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbl_Capacity = new System.Windows.Forms.Label();
            this.lbl_bs58valid = new System.Windows.Forms.Label();
            this.cb_autostart = new System.Windows.Forms.CheckBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.space2 = new System.Windows.Forms.Label();
            this.tab_BasicConfig = new System.Windows.Forms.TabPage();
            this.lbl_RestartWarning = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btn_RemoveDir = new System.Windows.Forms.Button();
            this.btn_AddDir = new System.Windows.Forms.Button();
            this.lv_dirs = new System.Windows.Forms.ListView();
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_EditChain = new System.Windows.Forms.Button();
            this.btn_MoveChainDown = new System.Windows.Forms.Button();
            this.btn_MoveChainUp = new System.Windows.Forms.Button();
            this.btn_RemoveChain = new System.Windows.Forms.Button();
            this.btn_AddChain = new System.Windows.Forms.Button();
            this.lv_csetup = new System.Windows.Forms.ListView();
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tab_AdvancedConfig = new System.Windows.Forms.TabPage();
            this.label_warning = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.rb_benchmark_cpu = new System.Windows.Forms.RadioButton();
            this.rb_benchmark_io = new System.Windows.Forms.RadioButton();
            this.rb_benchmark_disabled = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txt_logfile_pattern = new System.Windows.Forms.TextBox();
            this.txt_console_pattern = new System.Windows.Forms.TextBox();
            this.ud_logfile_size = new System.Windows.Forms.NumericUpDown();
            this.ud_logfile_count = new System.Windows.Forms.NumericUpDown();
            this.cb_logfile_level = new System.Windows.Forms.ComboBox();
            this.cb_console_level = new System.Windows.Forms.ComboBox();
            this.label_logfile_pattern = new System.Windows.Forms.Label();
            this.label_console_pattern = new System.Windows.Forms.Label();
            this.label_logfile_size = new System.Windows.Forms.Label();
            this.label_logfile_count = new System.Windows.Forms.Label();
            this.label_logfile_level = new System.Windows.Forms.Label();
            this.label_console_level = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cb_onthefly = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label_timeout = new System.Windows.Forms.Label();
            this.label_poll = new System.Windows.Forms.Label();
            this.ud_timeout = new System.Windows.Forms.NumericUpDown();
            this.ud_poll = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_CpuThreads = new System.Windows.Forms.Label();
            this.ud_CpuThreads = new System.Windows.Forms.NumericUpDown();
            this.cb_ThreadPinning = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_Seconds = new System.Windows.Forms.Label();
            this.lbl_Warps = new System.Windows.Forms.Label();
            this.lbl_ReadCache = new System.Windows.Forms.Label();
            this.ud_cache = new System.Windows.Forms.NumericUpDown();
            this.ud_wakeup = new System.Windows.Forms.NumericUpDown();
            this.cb_wakeup = new System.Windows.Forms.CheckBox();
            this.cb_dio = new System.Windows.Forms.CheckBox();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tc_Main.SuspendLayout();
            this.tab_Status.SuspendLayout();
            this.tab_BasicConfig.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tab_AdvancedConfig.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_logfile_size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_logfile_count)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_timeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_poll)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_CpuThreads)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_cache)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_wakeup)).BeginInit();
            this.SuspendLayout();
            //
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sl_status,
            this.pbar,
            this.statusLabel1,
            this.StatusLabel3,
            this.StatusLabel4});
            this.statusStrip.Location = new System.Drawing.Point(0, 619);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.ShowItemToolTips = true;
            this.statusStrip.Size = new System.Drawing.Size(644, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip";
            // 
            // sl_status
            // 
            this.sl_status.Name = "sl_status";
            this.sl_status.Size = new System.Drawing.Size(52, 17);
            this.sl_status.Text = "Progress";
            // 
            // pbar
            // 
            this.pbar.Name = "pbar";
            this.pbar.Size = new System.Drawing.Size(100, 16);
            this.pbar.ToolTipText = "Hasher Progress";
            // 
            // statusLabel1
            // 
            this.statusLabel1.Name = "statusLabel1";
            this.statusLabel1.Size = new System.Drawing.Size(46, 17);
            this.statusLabel1.Text = "(status)";
            // 
            // StatusLabel3
            // 
            this.StatusLabel3.Name = "StatusLabel3";
            this.StatusLabel3.Size = new System.Drawing.Size(19, 17);
            this.StatusLabel3.Text = "    ";
            // 
            // StatusLabel4
            // 
            this.StatusLabel4.Name = "StatusLabel4";
            this.StatusLabel4.Size = new System.Drawing.Size(19, 17);
            this.StatusLabel4.Text = "    ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(644, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToDefaultsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // resetToDefaultsToolStripMenuItem
            // 
            this.resetToDefaultsToolStripMenuItem.Name = "resetToDefaultsToolStripMenuItem";
            this.resetToDefaultsToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.resetToDefaultsToolStripMenuItem.Text = "Reset &Config to Defaults...";
            this.resetToDefaultsToolStripMenuItem.Click += new System.EventHandler(this.ResetToDefaultsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(207, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
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
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.CheckForUpdatesToolStripMenuItem_Click);
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
            // tc_Main
            // 
            this.tc_Main.Controls.Add(this.tab_Status);
            this.tc_Main.Controls.Add(this.tab_BasicConfig);
            this.tc_Main.Controls.Add(this.tab_AdvancedConfig);
            this.tc_Main.Location = new System.Drawing.Point(12, 27);
            this.tc_Main.Name = "tc_Main";
            this.tc_Main.SelectedIndex = 0;
            this.tc_Main.Size = new System.Drawing.Size(620, 589);
            this.tc_Main.TabIndex = 1;
            // 
            // tab_Status
            // 
            this.tab_Status.Controls.Add(this.lbl_Log);
            this.tab_Status.Controls.Add(this.txt_MinerOutput);
            this.tab_Status.Controls.Add(this.lv_sub);
            this.tab_Status.Controls.Add(this.lbl_SubmissionHistory);
            this.tab_Status.Controls.Add(this.lbl_MinerQueue);
            this.tab_Status.Controls.Add(this.lv_queue);
            this.tab_Status.Controls.Add(this.lv_chains);
            this.tab_Status.Controls.Add(this.lbl_ChainStates);
            this.tab_Status.Controls.Add(this.lv_capa);
            this.tab_Status.Controls.Add(this.lbl_Capacity);
            this.tab_Status.Controls.Add(this.lbl_bs58valid);
            this.tab_Status.Controls.Add(this.cb_autostart);
            this.tab_Status.Controls.Add(this.btn_start);
            this.tab_Status.Controls.Add(this.space2);
            this.tab_Status.Location = new System.Drawing.Point(4, 22);
            this.tab_Status.Name = "tab_Status";
            this.tab_Status.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Status.Size = new System.Drawing.Size(612, 563);
            this.tab_Status.TabIndex = 0;
            this.tab_Status.Text = "Main";
            this.tab_Status.UseVisualStyleBackColor = true;
            // 
            // lbl_Log
            // 
            this.lbl_Log.AutoSize = true;
            this.lbl_Log.Location = new System.Drawing.Point(6, 466);
            this.lbl_Log.Name = "lbl_Log";
            this.lbl_Log.Size = new System.Drawing.Size(25, 13);
            this.lbl_Log.TabIndex = 41;
            this.lbl_Log.Text = "Log";
            // 
            // txt_MinerOutput
            // 
            this.txt_MinerOutput.Font = new System.Drawing.Font("Lucida Console", 8F);
            this.txt_MinerOutput.Location = new System.Drawing.Point(6, 482);
            this.txt_MinerOutput.Multiline = true;
            this.txt_MinerOutput.Name = "txt_MinerOutput";
            this.txt_MinerOutput.ReadOnly = true;
            this.txt_MinerOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_MinerOutput.Size = new System.Drawing.Size(600, 75);
            this.txt_MinerOutput.TabIndex = 21;
            this.txt_MinerOutput.WordWrap = false;
            // 
            // lv_sub
            // 
            this.lv_sub.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader16,
            this.columnHeader15,
            this.columnHeader23});
            this.lv_sub.FullRowSelect = true;
            this.lv_sub.HideSelection = false;
            this.lv_sub.Location = new System.Drawing.Point(6, 286);
            this.lv_sub.Name = "lv_sub";
            this.lv_sub.Size = new System.Drawing.Size(600, 135);
            this.lv_sub.TabIndex = 40;
            this.lv_sub.UseCompatibleStateImageBehavior = false;
            this.lv_sub.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Chain";
            this.columnHeader12.Width = 80;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Account";
            this.columnHeader13.Width = 225;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Height";
            this.columnHeader14.Width = 58;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "GenSig";
            this.columnHeader16.Width = 133;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Best Quality";
            this.columnHeader15.Width = 86;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "PoC Time";
            this.columnHeader23.Width = 70;
            // 
            // lbl_SubmissionHistory
            // 
            this.lbl_SubmissionHistory.AutoSize = true;
            this.lbl_SubmissionHistory.Location = new System.Drawing.Point(6, 270);
            this.lbl_SubmissionHistory.Name = "lbl_SubmissionHistory";
            this.lbl_SubmissionHistory.Size = new System.Drawing.Size(119, 13);
            this.lbl_SubmissionHistory.TabIndex = 39;
            this.lbl_SubmissionHistory.Text = "Best Submission History";
            // 
            // lbl_MinerQueue
            // 
            this.lbl_MinerQueue.AutoSize = true;
            this.lbl_MinerQueue.Location = new System.Drawing.Point(6, 142);
            this.lbl_MinerQueue.Name = "lbl_MinerQueue";
            this.lbl_MinerQueue.Size = new System.Drawing.Size(68, 13);
            this.lbl_MinerQueue.TabIndex = 38;
            this.lbl_MinerQueue.Text = "Miner Queue";
            // 
            // lv_queue
            // 
            this.lv_queue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader17,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.lv_queue.FullRowSelect = true;
            this.lv_queue.HideSelection = false;
            this.lv_queue.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lv_queue.Location = new System.Drawing.Point(6, 158);
            this.lv_queue.Name = "lv_queue";
            this.lv_queue.Size = new System.Drawing.Size(220, 100);
            this.lv_queue.TabIndex = 37;
            this.lv_queue.UseCompatibleStateImageBehavior = false;
            this.lv_queue.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "#";
            this.columnHeader17.Width = 18;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Chain";
            this.columnHeader9.Width = 80;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Height";
            this.columnHeader10.Width = 58;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Progress";
            this.columnHeader11.Width = 58;
            // 
            // lv_chains
            // 
            this.lv_chains.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader24,
            this.ColumnHeader7,
            this.columnHeader22,
            this.columnHeader8});
            this.lv_chains.FullRowSelect = true;
            this.lv_chains.HideSelection = false;
            this.lv_chains.Location = new System.Drawing.Point(6, 31);
            this.lv_chains.Name = "lv_chains";
            this.lv_chains.Size = new System.Drawing.Size(600, 100);
            this.lv_chains.TabIndex = 31;
            this.lv_chains.UseCompatibleStateImageBehavior = false;
            this.lv_chains.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Chain";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Height";
            this.columnHeader5.Width = 77;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Difficulty";
            this.columnHeader6.Width = 78;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "Network Size";
            this.columnHeader24.Width = 95;
            // 
            // ColumnHeader7
            // 
            this.ColumnHeader7.Text = "GenSig";
            this.ColumnHeader7.Width = 69;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Compression";
            this.columnHeader22.Width = 85;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Last Update";
            this.columnHeader8.Width = 126;
            // 
            // lbl_ChainStates
            // 
            this.lbl_ChainStates.AutoSize = true;
            this.lbl_ChainStates.Location = new System.Drawing.Point(6, 15);
            this.lbl_ChainStates.Name = "lbl_ChainStates";
            this.lbl_ChainStates.Size = new System.Drawing.Size(67, 13);
            this.lbl_ChainStates.TabIndex = 30;
            this.lbl_ChainStates.Text = "Chain States";
            // 
            // lv_capa
            // 
            this.lv_capa.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lv_capa.FullRowSelect = true;
            this.lv_capa.HideSelection = false;
            this.lv_capa.Location = new System.Drawing.Point(232, 158);
            this.lv_capa.Name = "lv_capa";
            this.lv_capa.Size = new System.Drawing.Size(374, 100);
            this.lv_capa.TabIndex = 29;
            this.lv_capa.UseCompatibleStateImageBehavior = false;
            this.lv_capa.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Summary";
            this.columnHeader1.Width = 213;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Capacity";
            this.columnHeader2.Width = 69;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Drives";
            this.columnHeader3.Width = 88;
            // 
            // lbl_Capacity
            // 
            this.lbl_Capacity.AutoSize = true;
            this.lbl_Capacity.Location = new System.Drawing.Point(233, 142);
            this.lbl_Capacity.Name = "lbl_Capacity";
            this.lbl_Capacity.Size = new System.Drawing.Size(48, 13);
            this.lbl_Capacity.TabIndex = 28;
            this.lbl_Capacity.Text = "Capacity";
            // 
            // lbl_bs58valid
            // 
            this.lbl_bs58valid.AutoSize = true;
            this.lbl_bs58valid.Location = new System.Drawing.Point(403, 15);
            this.lbl_bs58valid.Name = "lbl_bs58valid";
            this.lbl_bs58valid.Size = new System.Drawing.Size(0, 13);
            this.lbl_bs58valid.TabIndex = 26;
            // 
            // cb_autostart
            // 
            this.cb_autostart.AutoSize = true;
            this.cb_autostart.Location = new System.Drawing.Point(360, 443);
            this.cb_autostart.Name = "cb_autostart";
            this.cb_autostart.Size = new System.Drawing.Size(68, 17);
            this.cb_autostart.TabIndex = 41;
            this.cb_autostart.Text = "Autostart";
            this.cb_autostart.UseVisualStyleBackColor = true;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(453, 436);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(153, 30);
            this.btn_start.TabIndex = 18;
            this.btn_start.Text = "Start Mining";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // space2
            // 
            this.space2.AutoSize = true;
            this.space2.Location = new System.Drawing.Point(326, 154);
            this.space2.Name = "space2";
            this.space2.Size = new System.Drawing.Size(52, 13);
            this.space2.TabIndex = 6;
            this.space2.Text = "               ";
            // 
            // tab_BasicConfig
            // 
            this.tab_BasicConfig.Controls.Add(this.lbl_RestartWarning);
            this.tab_BasicConfig.Controls.Add(this.groupBox6);
            this.tab_BasicConfig.Controls.Add(this.groupBox3);
            this.tab_BasicConfig.Location = new System.Drawing.Point(4, 22);
            this.tab_BasicConfig.Name = "tab_BasicConfig";
            this.tab_BasicConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tab_BasicConfig.Size = new System.Drawing.Size(612, 563);
            this.tab_BasicConfig.TabIndex = 1;
            this.tab_BasicConfig.Text = "Basic Settings";
            this.tab_BasicConfig.UseVisualStyleBackColor = true;
            // 
            // lbl_RestartWarning
            // 
            this.lbl_RestartWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_RestartWarning.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_RestartWarning.Location = new System.Drawing.Point(6, 16);
            this.lbl_RestartWarning.Name = "lbl_RestartWarning";
            this.lbl_RestartWarning.Size = new System.Drawing.Size(600, 13);
            this.lbl_RestartWarning.TabIndex = 48;
            this.lbl_RestartWarning.Text = "RESTART MINING FOR CHANGES TO TAKE EFFECT";
            this.lbl_RestartWarning.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btn_RemoveDir);
            this.groupBox6.Controls.Add(this.btn_AddDir);
            this.groupBox6.Controls.Add(this.lv_dirs);
            this.groupBox6.Location = new System.Drawing.Point(14, 212);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(582, 345);
            this.groupBox6.TabIndex = 35;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Plot Directories";
            // 
            // btn_RemoveDir
            // 
            this.btn_RemoveDir.Location = new System.Drawing.Point(501, 48);
            this.btn_RemoveDir.Name = "btn_RemoveDir";
            this.btn_RemoveDir.Size = new System.Drawing.Size(75, 23);
            this.btn_RemoveDir.TabIndex = 32;
            this.btn_RemoveDir.Text = "Remove";
            this.btn_RemoveDir.UseVisualStyleBackColor = true;
            this.btn_RemoveDir.Click += new System.EventHandler(this.btn_RemoveDir_Click);
            // 
            // btn_AddDir
            // 
            this.btn_AddDir.Location = new System.Drawing.Point(501, 19);
            this.btn_AddDir.Name = "btn_AddDir";
            this.btn_AddDir.Size = new System.Drawing.Size(75, 23);
            this.btn_AddDir.TabIndex = 31;
            this.btn_AddDir.Text = "Add...";
            this.btn_AddDir.UseVisualStyleBackColor = true;
            this.btn_AddDir.Click += new System.EventHandler(this.btn_AddDir_Click);
            // 
            // lv_dirs
            // 
            this.lv_dirs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader21});
            this.lv_dirs.FullRowSelect = true;
            this.lv_dirs.HideSelection = false;
            this.lv_dirs.Location = new System.Drawing.Point(10, 19);
            this.lv_dirs.Name = "lv_dirs";
            this.lv_dirs.Size = new System.Drawing.Size(485, 320);
            this.lv_dirs.TabIndex = 30;
            this.lv_dirs.UseCompatibleStateImageBehavior = false;
            this.lv_dirs.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Directory";
            this.columnHeader21.Width = 464;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_EditChain);
            this.groupBox3.Controls.Add(this.btn_MoveChainDown);
            this.groupBox3.Controls.Add(this.btn_MoveChainUp);
            this.groupBox3.Controls.Add(this.btn_RemoveChain);
            this.groupBox3.Controls.Add(this.btn_AddChain);
            this.groupBox3.Controls.Add(this.lv_csetup);
            this.groupBox3.Location = new System.Drawing.Point(14, 42);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(582, 164);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chains";
            // 
            // btn_EditChain
            // 
            this.btn_EditChain.Location = new System.Drawing.Point(501, 48);
            this.btn_EditChain.Name = "btn_EditChain";
            this.btn_EditChain.Size = new System.Drawing.Size(75, 23);
            this.btn_EditChain.TabIndex = 35;
            this.btn_EditChain.Text = "Edit...";
            this.btn_EditChain.UseVisualStyleBackColor = true;
            this.btn_EditChain.Click += new System.EventHandler(this.btn_EditChain_Click);
            // 
            // btn_MoveChainDown
            // 
            this.btn_MoveChainDown.Location = new System.Drawing.Point(501, 128);
            this.btn_MoveChainDown.Name = "btn_MoveChainDown";
            this.btn_MoveChainDown.Size = new System.Drawing.Size(32, 23);
            this.btn_MoveChainDown.TabIndex = 34;
            this.btn_MoveChainDown.Text = "˅";
            this.btn_MoveChainDown.UseVisualStyleBackColor = true;
            this.btn_MoveChainDown.Click += new System.EventHandler(this.btn_MoveChainDown_Click);
            // 
            // btn_MoveChainUp
            // 
            this.btn_MoveChainUp.Location = new System.Drawing.Point(501, 106);
            this.btn_MoveChainUp.Name = "btn_MoveChainUp";
            this.btn_MoveChainUp.Size = new System.Drawing.Size(32, 23);
            this.btn_MoveChainUp.TabIndex = 33;
            this.btn_MoveChainUp.Text = "˄";
            this.btn_MoveChainUp.UseVisualStyleBackColor = true;
            this.btn_MoveChainUp.Click += new System.EventHandler(this.btn_MoveChainUp_Click);
            // 
            // btn_RemoveChain
            // 
            this.btn_RemoveChain.Location = new System.Drawing.Point(501, 77);
            this.btn_RemoveChain.Name = "btn_RemoveChain";
            this.btn_RemoveChain.Size = new System.Drawing.Size(75, 23);
            this.btn_RemoveChain.TabIndex = 32;
            this.btn_RemoveChain.Text = "Remove";
            this.btn_RemoveChain.UseVisualStyleBackColor = true;
            this.btn_RemoveChain.Click += new System.EventHandler(this.btn_RemoveChain_Click);
            // 
            // btn_AddChain
            // 
            this.btn_AddChain.Location = new System.Drawing.Point(501, 19);
            this.btn_AddChain.Name = "btn_AddChain";
            this.btn_AddChain.Size = new System.Drawing.Size(75, 23);
            this.btn_AddChain.TabIndex = 31;
            this.btn_AddChain.Text = "Add...";
            this.btn_AddChain.UseVisualStyleBackColor = true;
            this.btn_AddChain.Click += new System.EventHandler(this.btn_AddChain_Click);
            // 
            // lv_csetup
            // 
            this.lv_csetup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader26});
            this.lv_csetup.FullRowSelect = true;
            this.lv_csetup.HideSelection = false;
            this.lv_csetup.Location = new System.Drawing.Point(6, 19);
            this.lv_csetup.Name = "lv_csetup";
            this.lv_csetup.Size = new System.Drawing.Size(485, 139);
            this.lv_csetup.TabIndex = 30;
            this.lv_csetup.UseCompatibleStateImageBehavior = false;
            this.lv_csetup.View = System.Windows.Forms.View.Details;
            this.lv_csetup.DoubleClick += new System.EventHandler(this.lv_csetup_DoubleClick);
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Name";
            this.columnHeader18.Width = 123;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Server";
            this.columnHeader19.Width = 231;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Api-Path";
            this.columnHeader20.Width = 124;
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "Block Time";
            this.columnHeader26.Width = 80;
            // 
            // tab_AdvancedConfig
            // 
            this.tab_AdvancedConfig.Controls.Add(this.label_warning);
            this.tab_AdvancedConfig.Controls.Add(this.groupBox9);
            this.tab_AdvancedConfig.Controls.Add(this.groupBox5);
            this.tab_AdvancedConfig.Controls.Add(this.groupBox7);
            this.tab_AdvancedConfig.Controls.Add(this.groupBox4);
            this.tab_AdvancedConfig.Controls.Add(this.groupBox2);
            this.tab_AdvancedConfig.Controls.Add(this.groupBox1);
            this.tab_AdvancedConfig.Location = new System.Drawing.Point(4, 22);
            this.tab_AdvancedConfig.Name = "tab_AdvancedConfig";
            this.tab_AdvancedConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tab_AdvancedConfig.Size = new System.Drawing.Size(612, 563);
            this.tab_AdvancedConfig.TabIndex = 2;
            this.tab_AdvancedConfig.Text = "Advanced Settings";
            this.tab_AdvancedConfig.UseVisualStyleBackColor = true;
            // 
            // label_warning
            // 
            this.label_warning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_warning.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label_warning.Location = new System.Drawing.Point(6, 16);
            this.label_warning.Name = "label_warning";
            this.label_warning.Size = new System.Drawing.Size(600, 13);
            this.label_warning.TabIndex = 47;
            this.label_warning.Text = "RESTART MINING FOR CHANGES TO TAKE EFFECT";
            this.label_warning.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.rb_benchmark_cpu);
            this.groupBox9.Controls.Add(this.rb_benchmark_io);
            this.groupBox9.Controls.Add(this.rb_benchmark_disabled);
            this.groupBox9.Location = new System.Drawing.Point(6, 204);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(600, 59);
            this.groupBox9.TabIndex = 46;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Benchmark";
            // 
            // rb_benchmark_cpu
            // 
            this.rb_benchmark_cpu.AutoSize = true;
            this.rb_benchmark_cpu.Location = new System.Drawing.Point(186, 25);
            this.rb_benchmark_cpu.Name = "rb_benchmark_cpu";
            this.rb_benchmark_cpu.Size = new System.Drawing.Size(104, 17);
            this.rb_benchmark_cpu.TabIndex = 2;
            this.rb_benchmark_cpu.Text = "CPU Benchmark";
            this.rb_benchmark_cpu.UseVisualStyleBackColor = true;
            // 
            // rb_benchmark_io
            // 
            this.rb_benchmark_io.AutoSize = true;
            this.rb_benchmark_io.Location = new System.Drawing.Point(82, 25);
            this.rb_benchmark_io.Name = "rb_benchmark_io";
            this.rb_benchmark_io.Size = new System.Drawing.Size(98, 17);
            this.rb_benchmark_io.TabIndex = 1;
            this.rb_benchmark_io.Text = "I/O Benchmark";
            this.rb_benchmark_io.UseVisualStyleBackColor = true;
            // 
            // rb_benchmark_disabled
            // 
            this.rb_benchmark_disabled.AutoSize = true;
            this.rb_benchmark_disabled.Checked = true;
            this.rb_benchmark_disabled.Location = new System.Drawing.Point(10, 25);
            this.rb_benchmark_disabled.Name = "rb_benchmark_disabled";
            this.rb_benchmark_disabled.Size = new System.Drawing.Size(66, 17);
            this.rb_benchmark_disabled.TabIndex = 0;
            this.rb_benchmark_disabled.TabStop = true;
            this.rb_benchmark_disabled.Text = "Disabled";
            this.rb_benchmark_disabled.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txt_logfile_pattern);
            this.groupBox5.Controls.Add(this.txt_console_pattern);
            this.groupBox5.Controls.Add(this.ud_logfile_size);
            this.groupBox5.Controls.Add(this.ud_logfile_count);
            this.groupBox5.Controls.Add(this.cb_logfile_level);
            this.groupBox5.Controls.Add(this.cb_console_level);
            this.groupBox5.Controls.Add(this.label_logfile_pattern);
            this.groupBox5.Controls.Add(this.label_console_pattern);
            this.groupBox5.Controls.Add(this.label_logfile_size);
            this.groupBox5.Controls.Add(this.label_logfile_count);
            this.groupBox5.Controls.Add(this.label_logfile_level);
            this.groupBox5.Controls.Add(this.label_console_level);
            this.groupBox5.Location = new System.Drawing.Point(6, 416);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(600, 139);
            this.groupBox5.TabIndex = 45;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Logging";
            // 
            // txt_logfile_pattern
            // 
            this.txt_logfile_pattern.Location = new System.Drawing.Point(150, 109);
            this.txt_logfile_pattern.Name = "txt_logfile_pattern";
            this.txt_logfile_pattern.Size = new System.Drawing.Size(420, 20);
            this.txt_logfile_pattern.TabIndex = 11;
            this.txt_logfile_pattern.Text = "{({d(%Y-%m-%d %H:%M:%S)} [{l}]):26.26} {m}{n}";
            // 
            // txt_console_pattern
            // 
            this.txt_console_pattern.Location = new System.Drawing.Point(150, 82);
            this.txt_console_pattern.Name = "txt_console_pattern";
            this.txt_console_pattern.Size = new System.Drawing.Size(420, 20);
            this.txt_console_pattern.TabIndex = 10;
            this.txt_console_pattern.Text = "{({d(%H:%M:%S)} [{l}]):16.16} {m}{n}";
            // 
            // ud_logfile_size
            // 
            this.ud_logfile_size.Location = new System.Drawing.Point(422, 52);
            this.ud_logfile_size.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ud_logfile_size.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ud_logfile_size.Name = "ud_logfile_size";
            this.ud_logfile_size.Size = new System.Drawing.Size(60, 20);
            this.ud_logfile_size.TabIndex = 9;
            this.ud_logfile_size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ud_logfile_size.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // ud_logfile_count
            // 
            this.ud_logfile_count.Location = new System.Drawing.Point(422, 22);
            this.ud_logfile_count.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ud_logfile_count.Name = "ud_logfile_count";
            this.ud_logfile_count.Size = new System.Drawing.Size(60, 20);
            this.ud_logfile_count.TabIndex = 8;
            this.ud_logfile_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ud_logfile_count.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // cb_logfile_level
            // 
            this.cb_logfile_level.FormattingEnabled = true;
            this.cb_logfile_level.Items.AddRange(new object[] {
            "off",
            "error",
            "warn",
            "info",
            "debug",
            "trace"});
            this.cb_logfile_level.Location = new System.Drawing.Point(150, 52);
            this.cb_logfile_level.Name = "cb_logfile_level";
            this.cb_logfile_level.Size = new System.Drawing.Size(100, 21);
            this.cb_logfile_level.TabIndex = 7;
            // 
            // cb_console_level
            // 
            this.cb_console_level.FormattingEnabled = true;
            this.cb_console_level.Items.AddRange(new object[] {
            "off",
            "error",
            "warn",
            "info",
            "debug",
            "trace"});
            this.cb_console_level.Location = new System.Drawing.Point(150, 22);
            this.cb_console_level.Name = "cb_console_level";
            this.cb_console_level.Size = new System.Drawing.Size(100, 21);
            this.cb_console_level.TabIndex = 6;
            // 
            // label_logfile_pattern
            // 
            this.label_logfile_pattern.AutoSize = true;
            this.label_logfile_pattern.Location = new System.Drawing.Point(10, 112);
            this.label_logfile_pattern.Name = "label_logfile_pattern";
            this.label_logfile_pattern.Size = new System.Drawing.Size(99, 13);
            this.label_logfile_pattern.TabIndex = 5;
            this.label_logfile_pattern.Text = "Logfile Log Pattern:";
            // 
            // label_console_pattern
            // 
            this.label_console_pattern.AutoSize = true;
            this.label_console_pattern.Location = new System.Drawing.Point(10, 85);
            this.label_console_pattern.Name = "label_console_pattern";
            this.label_console_pattern.Size = new System.Drawing.Size(106, 13);
            this.label_console_pattern.TabIndex = 4;
            this.label_console_pattern.Text = "Console Log Pattern:";
            // 
            // label_logfile_size
            // 
            this.label_logfile_size.AutoSize = true;
            this.label_logfile_size.Location = new System.Drawing.Point(282, 55);
            this.label_logfile_size.Name = "label_logfile_size";
            this.label_logfile_size.Size = new System.Drawing.Size(117, 13);
            this.label_logfile_size.TabIndex = 3;
            this.label_logfile_size.Text = "Max Size per File [MiB]:";
            // 
            // label_logfile_count
            // 
            this.label_logfile_count.AutoSize = true;
            this.label_logfile_count.Location = new System.Drawing.Point(282, 25);
            this.label_logfile_count.Name = "label_logfile_count";
            this.label_logfile_count.Size = new System.Drawing.Size(72, 13);
            this.label_logfile_count.TabIndex = 2;
            this.label_logfile_count.Text = "Max Log Files";
            // 
            // label_logfile_level
            // 
            this.label_logfile_level.AutoSize = true;
            this.label_logfile_level.Location = new System.Drawing.Point(10, 55);
            this.label_logfile_level.Name = "label_logfile_level";
            this.label_logfile_level.Size = new System.Drawing.Size(88, 13);
            this.label_logfile_level.TabIndex = 1;
            this.label_logfile_level.Text = "Logfile Log Level";
            // 
            // label_console_level
            // 
            this.label_console_level.AutoSize = true;
            this.label_console_level.Location = new System.Drawing.Point(10, 25);
            this.label_console_level.Name = "label_console_level";
            this.label_console_level.Size = new System.Drawing.Size(95, 13);
            this.label_console_level.TabIndex = 0;
            this.label_console_level.Text = "Console Log Level";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cb_onthefly);
            this.groupBox7.Location = new System.Drawing.Point(6, 355);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(600, 55);
            this.groupBox7.TabIndex = 44;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Mining";
            // 
            // cb_onthefly
            // 
            this.cb_onthefly.AutoSize = true;
            this.cb_onthefly.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cb_onthefly.Location = new System.Drawing.Point(6, 20);
            this.cb_onthefly.Name = "cb_onthefly";
            this.cb_onthefly.Size = new System.Drawing.Size(133, 17);
            this.cb_onthefly.TabIndex = 0;
            this.cb_onthefly.Text = "On-the-fly compression";
            this.cb_onthefly.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label_timeout);
            this.groupBox4.Controls.Add(this.label_poll);
            this.groupBox4.Controls.Add(this.ud_timeout);
            this.groupBox4.Controls.Add(this.ud_poll);
            this.groupBox4.Location = new System.Drawing.Point(6, 269);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(600, 80);
            this.groupBox4.TabIndex = 43;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Network";
            // 
            // label_timeout
            // 
            this.label_timeout.AutoSize = true;
            this.label_timeout.Location = new System.Drawing.Point(6, 46);
            this.label_timeout.Name = "label_timeout";
            this.label_timeout.Size = new System.Drawing.Size(67, 13);
            this.label_timeout.TabIndex = 17;
            this.label_timeout.Text = "Timeout [ms]";
            // 
            // label_poll
            // 
            this.label_poll.AutoSize = true;
            this.label_poll.Location = new System.Drawing.Point(6, 20);
            this.label_poll.Name = "label_poll";
            this.label_poll.Size = new System.Drawing.Size(84, 13);
            this.label_poll.TabIndex = 16;
            this.label_poll.Text = "Poll Interval [ms]";
            // 
            // ud_timeout
            // 
            this.ud_timeout.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ud_timeout.Location = new System.Drawing.Point(110, 44);
            this.ud_timeout.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.ud_timeout.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ud_timeout.Name = "ud_timeout";
            this.ud_timeout.Size = new System.Drawing.Size(55, 20);
            this.ud_timeout.TabIndex = 15;
            this.ud_timeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ud_timeout.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // ud_poll
            // 
            this.ud_poll.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ud_poll.Location = new System.Drawing.Point(110, 18);
            this.ud_poll.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ud_poll.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ud_poll.Name = "ud_poll";
            this.ud_poll.Size = new System.Drawing.Size(55, 20);
            this.ud_poll.TabIndex = 12;
            this.ud_poll.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ud_poll.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl_CpuThreads);
            this.groupBox2.Controls.Add(this.ud_CpuThreads);
            this.groupBox2.Controls.Add(this.cb_ThreadPinning);
            this.groupBox2.Location = new System.Drawing.Point(6, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(600, 78);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CPU";
            // 
            // lbl_CpuThreads
            // 
            this.lbl_CpuThreads.AutoSize = true;
            this.lbl_CpuThreads.Location = new System.Drawing.Point(6, 20);
            this.lbl_CpuThreads.Name = "lbl_CpuThreads";
            this.lbl_CpuThreads.Size = new System.Drawing.Size(102, 13);
            this.lbl_CpuThreads.TabIndex = 10;
            this.lbl_CpuThreads.Text = "CPU Threads (0=all)";
            // 
            // ud_CpuThreads
            // 
            this.ud_CpuThreads.Location = new System.Drawing.Point(115, 18);
            this.ud_CpuThreads.Name = "ud_CpuThreads";
            this.ud_CpuThreads.Size = new System.Drawing.Size(55, 20);
            this.ud_CpuThreads.TabIndex = 6;
            this.ud_CpuThreads.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cb_ThreadPinning
            // 
            this.cb_ThreadPinning.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cb_ThreadPinning.Location = new System.Drawing.Point(6, 45);
            this.cb_ThreadPinning.Name = "cb_ThreadPinning";
            this.cb_ThreadPinning.Size = new System.Drawing.Size(100, 17);
            this.cb_ThreadPinning.TabIndex = 5;
            this.cb_ThreadPinning.Text = "Thread pinning";
            this.cb_ThreadPinning.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_Seconds);
            this.groupBox1.Controls.Add(this.lbl_Warps);
            this.groupBox1.Controls.Add(this.lbl_ReadCache);
            this.groupBox1.Controls.Add(this.ud_cache);
            this.groupBox1.Controls.Add(this.ud_wakeup);
            this.groupBox1.Controls.Add(this.cb_wakeup);
            this.groupBox1.Controls.Add(this.cb_dio);
            this.groupBox1.Location = new System.Drawing.Point(6, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 71);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HDD";
            // 
            // lbl_Seconds
            // 
            this.lbl_Seconds.AutoSize = true;
            this.lbl_Seconds.Location = new System.Drawing.Point(162, 43);
            this.lbl_Seconds.Name = "lbl_Seconds";
            this.lbl_Seconds.Size = new System.Drawing.Size(24, 13);
            this.lbl_Seconds.TabIndex = 8;
            this.lbl_Seconds.Text = "sec";
            // 
            // lbl_Warps
            // 
            this.lbl_Warps.AutoSize = true;
            this.lbl_Warps.Location = new System.Drawing.Point(360, 20);
            this.lbl_Warps.Name = "lbl_Warps";
            this.lbl_Warps.Size = new System.Drawing.Size(35, 13);
            this.lbl_Warps.TabIndex = 7;
            this.lbl_Warps.Text = "warps";
            // 
            // lbl_ReadCache
            // 
            this.lbl_ReadCache.AutoSize = true;
            this.lbl_ReadCache.Location = new System.Drawing.Point(226, 20);
            this.lbl_ReadCache.Name = "lbl_ReadCache";
            this.lbl_ReadCache.Size = new System.Drawing.Size(67, 13);
            this.lbl_ReadCache.TabIndex = 6;
            this.lbl_ReadCache.Text = "Read Cache";
            // 
            // ud_cache
            // 
            this.ud_cache.Location = new System.Drawing.Point(299, 18);
            this.ud_cache.Name = "ud_cache";
            this.ud_cache.Size = new System.Drawing.Size(55, 20);
            this.ud_cache.TabIndex = 5;
            this.ud_cache.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ud_wakeup
            // 
            this.ud_wakeup.Location = new System.Drawing.Point(102, 38);
            this.ud_wakeup.Name = "ud_wakeup";
            this.ud_wakeup.Size = new System.Drawing.Size(55, 20);
            this.ud_wakeup.TabIndex = 3;
            this.ud_wakeup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cb_wakeup
            // 
            this.cb_wakeup.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cb_wakeup.Location = new System.Drawing.Point(6, 39);
            this.cb_wakeup.Name = "cb_wakeup";
            this.cb_wakeup.Size = new System.Drawing.Size(90, 17);
            this.cb_wakeup.TabIndex = 2;
            this.cb_wakeup.Text = "Wakeup after";
            this.cb_wakeup.UseVisualStyleBackColor = true;
            // 
            // cb_dio
            // 
            this.cb_dio.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cb_dio.Location = new System.Drawing.Point(6, 16);
            this.cb_dio.Name = "cb_dio";
            this.cb_dio.Size = new System.Drawing.Size(90, 17);
            this.cb_dio.TabIndex = 0;
            this.cb_dio.Text = "Use direct i/o";
            this.cb_dio.UseVisualStyleBackColor = true;
            // 
            // MinerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 641);
            this.Controls.Add(this.tc_Main);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(660, 680);
            this.MinimumSize = new System.Drawing.Size(660, 680);
            this.Name = "MinerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PoCX Miner GUI v.1.0.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MinerForm_FormClosing);
            this.Load += new System.EventHandler(this.MinerForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tc_Main.ResumeLayout(false);
            this.tab_Status.ResumeLayout(false);
            this.tab_Status.PerformLayout();
            this.tab_BasicConfig.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tab_AdvancedConfig.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_logfile_size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_logfile_count)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_timeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_poll)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_CpuThreads)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_cache)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_wakeup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar pbar;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToDefaultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.TabControl tc_Main;
        private System.Windows.Forms.TabPage tab_BasicConfig;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel sl_status;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel4;
        private System.Windows.Forms.TabPage tab_Status;
        private System.Windows.Forms.Label lbl_MinerQueue;
        private System.Windows.Forms.ListView lv_queue;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ListView lv_chains;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.ColumnHeader ColumnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.Label lbl_ChainStates;
        private System.Windows.Forms.ListView lv_capa;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label lbl_Capacity;
        private System.Windows.Forms.Label lbl_bs58valid;
        private System.Windows.Forms.CheckBox cb_autostart;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Label space2;
        private System.Windows.Forms.ListView lv_sub;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.Label lbl_SubmissionHistory;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.TextBox txt_MinerOutput;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Label lbl_Log;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btn_RemoveDir;
        private System.Windows.Forms.Button btn_AddDir;
        private System.Windows.Forms.ListView lv_dirs;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_MoveChainDown;
        private System.Windows.Forms.Button btn_MoveChainUp;
        private System.Windows.Forms.Button btn_RemoveChain;
        private System.Windows.Forms.Button btn_AddChain;
        private System.Windows.Forms.ListView lv_csetup;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader26;
        private System.Windows.Forms.TabPage tab_AdvancedConfig;
        private System.Windows.Forms.Label label_warning;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.RadioButton rb_benchmark_cpu;
        private System.Windows.Forms.RadioButton rb_benchmark_io;
        private System.Windows.Forms.RadioButton rb_benchmark_disabled;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txt_logfile_pattern;
        private System.Windows.Forms.TextBox txt_console_pattern;
        private System.Windows.Forms.NumericUpDown ud_logfile_size;
        private System.Windows.Forms.NumericUpDown ud_logfile_count;
        private System.Windows.Forms.ComboBox cb_logfile_level;
        private System.Windows.Forms.ComboBox cb_console_level;
        private System.Windows.Forms.Label label_logfile_pattern;
        private System.Windows.Forms.Label label_console_pattern;
        private System.Windows.Forms.Label label_logfile_size;
        private System.Windows.Forms.Label label_logfile_count;
        private System.Windows.Forms.Label label_logfile_level;
        private System.Windows.Forms.Label label_console_level;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox cb_onthefly;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label_timeout;
        private System.Windows.Forms.Label label_poll;
        private System.Windows.Forms.NumericUpDown ud_timeout;
        private System.Windows.Forms.NumericUpDown ud_poll;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl_CpuThreads;
        private System.Windows.Forms.NumericUpDown ud_CpuThreads;
        private System.Windows.Forms.CheckBox cb_ThreadPinning;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_Seconds;
        private System.Windows.Forms.Label lbl_Warps;
        private System.Windows.Forms.Label lbl_ReadCache;
        private System.Windows.Forms.NumericUpDown ud_cache;
        private System.Windows.Forms.NumericUpDown ud_wakeup;
        private System.Windows.Forms.CheckBox cb_wakeup;
        private System.Windows.Forms.CheckBox cb_dio;
        private System.Windows.Forms.Button btn_EditChain;
        private System.Windows.Forms.Label lbl_RestartWarning;
    }
}

