namespace PoCXMinerGUI
{
    partial class ChainEditDialog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ud_blocktime = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_apipath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_baseurl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rb_pool = new System.Windows.Forms.RadioButton();
            this.rb_wallet = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.ud_target_quality = new System.Windows.Forms.NumericUpDown();
            this.cb_target_quality = new System.Windows.Forms.CheckBox();
            this.txt_authtoken = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_headers = new System.Windows.Forms.DataGridView();
            this.col_header_key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_header_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_remove_account = new System.Windows.Forms.Button();
            this.btn_edit_account = new System.Windows.Forms.Button();
            this.btn_add_account = new System.Windows.Forms.Button();
            this.lv_accounts = new System.Windows.Forms.ListView();
            this.col_account = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_quality = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_headers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_blocktime)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_target_quality)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_headers)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_pool);
            this.groupBox1.Controls.Add(this.ud_blocktime);
            this.groupBox1.Controls.Add(this.rb_wallet);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_apipath);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_baseurl);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 130);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic Settings";
            // 
            // ud_blocktime
            // 
            this.ud_blocktime.Location = new System.Drawing.Point(100, 100);
            this.ud_blocktime.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.ud_blocktime.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ud_blocktime.Name = "ud_blocktime";
            this.ud_blocktime.Size = new System.Drawing.Size(100, 20);
            this.ud_blocktime.TabIndex = 7;
            this.ud_blocktime.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Block Time (s):";
            // 
            // txt_apipath
            // 
            this.txt_apipath.Location = new System.Drawing.Point(100, 74);
            this.txt_apipath.Name = "txt_apipath";
            this.txt_apipath.Size = new System.Drawing.Size(440, 20);
            this.txt_apipath.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "API Path:";
            // 
            // txt_baseurl
            // 
            this.txt_baseurl.Location = new System.Drawing.Point(100, 48);
            this.txt_baseurl.Name = "txt_baseurl";
            this.txt_baseurl.Size = new System.Drawing.Size(440, 20);
            this.txt_baseurl.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Base URL:";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(100, 22);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(440, 20);
            this.txt_name.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ud_target_quality);
            this.groupBox2.Controls.Add(this.cb_target_quality);
            this.groupBox2.Controls.Add(this.txt_authtoken);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 80);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Optional Settings";
            // 
            // rb_pool
            // 
            this.rb_pool.AutoSize = true;
            this.rb_pool.Location = new System.Drawing.Point(389, 101);
            this.rb_pool.Name = "rb_pool";
            this.rb_pool.Size = new System.Drawing.Size(46, 17);
            this.rb_pool.TabIndex = 6;
            this.rb_pool.Text = "Pool";
            this.rb_pool.UseVisualStyleBackColor = true;
            // 
            // rb_wallet
            // 
            this.rb_wallet.AutoSize = true;
            this.rb_wallet.Checked = true;
            this.rb_wallet.Location = new System.Drawing.Point(328, 101);
            this.rb_wallet.Name = "rb_wallet";
            this.rb_wallet.Size = new System.Drawing.Size(55, 17);
            this.rb_wallet.TabIndex = 5;
            this.rb_wallet.TabStop = true;
            this.rb_wallet.Text = "Wallet";
            this.rb_wallet.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(229, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Submission Mode:";
            // 
            // ud_target_quality
            // 
            this.ud_target_quality.Enabled = false;
            this.ud_target_quality.Location = new System.Drawing.Point(117, 50);
            this.ud_target_quality.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.ud_target_quality.Name = "ud_target_quality";
            this.ud_target_quality.Size = new System.Drawing.Size(120, 20);
            this.ud_target_quality.TabIndex = 3;
            // 
            // cb_target_quality
            // 
            this.cb_target_quality.AutoSize = true;
            this.cb_target_quality.Location = new System.Drawing.Point(18, 51);
            this.cb_target_quality.Name = "cb_target_quality";
            this.cb_target_quality.Size = new System.Drawing.Size(95, 17);
            this.cb_target_quality.TabIndex = 2;
            this.cb_target_quality.Text = "Target Quality:";
            this.cb_target_quality.UseVisualStyleBackColor = true;
            this.cb_target_quality.CheckedChanged += new System.EventHandler(this.cb_target_quality_CheckedChanged);
            // 
            // txt_authtoken
            // 
            this.txt_authtoken.Location = new System.Drawing.Point(100, 22);
            this.txt_authtoken.Name = "txt_authtoken";
            this.txt_authtoken.Size = new System.Drawing.Size(440, 20);
            this.txt_authtoken.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Auth Token:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv_headers);
            this.groupBox3.Location = new System.Drawing.Point(12, 234);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(560, 150);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Custom Headers";
            // 
            // dgv_headers
            // 
            this.dgv_headers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_headers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_header_key,
            this.col_header_value});
            this.dgv_headers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_headers.Location = new System.Drawing.Point(3, 16);
            this.dgv_headers.Name = "dgv_headers";
            this.dgv_headers.Size = new System.Drawing.Size(554, 131);
            this.dgv_headers.TabIndex = 0;
            // 
            // col_header_key
            // 
            this.col_header_key.HeaderText = "Key";
            this.col_header_key.Name = "col_header_key";
            this.col_header_key.Width = 200;
            // 
            // col_header_value
            // 
            this.col_header_value.HeaderText = "Value";
            this.col_header_value.Name = "col_header_value";
            this.col_header_value.Width = 300;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_remove_account);
            this.groupBox4.Controls.Add(this.btn_edit_account);
            this.groupBox4.Controls.Add(this.btn_add_account);
            this.groupBox4.Controls.Add(this.lv_accounts);
            this.groupBox4.Location = new System.Drawing.Point(12, 390);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(560, 180);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Accounts";
            // 
            // btn_remove_account
            // 
            this.btn_remove_account.Location = new System.Drawing.Point(168, 145);
            this.btn_remove_account.Name = "btn_remove_account";
            this.btn_remove_account.Size = new System.Drawing.Size(75, 23);
            this.btn_remove_account.TabIndex = 3;
            this.btn_remove_account.Text = "Remove";
            this.btn_remove_account.UseVisualStyleBackColor = true;
            this.btn_remove_account.Click += new System.EventHandler(this.btn_remove_account_Click);
            // 
            // btn_edit_account
            // 
            this.btn_edit_account.Location = new System.Drawing.Point(87, 145);
            this.btn_edit_account.Name = "btn_edit_account";
            this.btn_edit_account.Size = new System.Drawing.Size(75, 23);
            this.btn_edit_account.TabIndex = 2;
            this.btn_edit_account.Text = "Edit";
            this.btn_edit_account.UseVisualStyleBackColor = true;
            this.btn_edit_account.Click += new System.EventHandler(this.btn_edit_account_Click);
            // 
            // btn_add_account
            // 
            this.btn_add_account.Location = new System.Drawing.Point(6, 145);
            this.btn_add_account.Name = "btn_add_account";
            this.btn_add_account.Size = new System.Drawing.Size(75, 23);
            this.btn_add_account.TabIndex = 1;
            this.btn_add_account.Text = "Add";
            this.btn_add_account.UseVisualStyleBackColor = true;
            this.btn_add_account.Click += new System.EventHandler(this.btn_add_account_Click);
            // 
            // lv_accounts
            // 
            this.lv_accounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_account,
            this.col_quality,
            this.col_headers});
            this.lv_accounts.FullRowSelect = true;
            this.lv_accounts.HideSelection = false;
            this.lv_accounts.Location = new System.Drawing.Point(6, 19);
            this.lv_accounts.Name = "lv_accounts";
            this.lv_accounts.Size = new System.Drawing.Size(548, 120);
            this.lv_accounts.TabIndex = 0;
            this.lv_accounts.UseCompatibleStateImageBehavior = false;
            this.lv_accounts.View = System.Windows.Forms.View.Details;
            // 
            // col_account
            // 
            this.col_account.Text = "Account";
            this.col_account.Width = 300;
            // 
            // col_quality
            // 
            this.col_quality.Text = "Target Quality";
            this.col_quality.Width = 120;
            // 
            // col_headers
            // 
            this.col_headers.Text = "Headers";
            this.col_headers.Width = 100;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(416, 576);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 4;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(497, 576);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 5;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // ChainEditDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 611);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChainEditDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Chain";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_blocktime)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_target_quality)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_headers)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown ud_blocktime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_apipath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_baseurl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown ud_target_quality;
        private System.Windows.Forms.CheckBox cb_target_quality;
        private System.Windows.Forms.TextBox txt_authtoken;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rb_wallet;
        private System.Windows.Forms.RadioButton rb_pool;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_headers;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_header_key;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_header_value;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_remove_account;
        private System.Windows.Forms.Button btn_edit_account;
        private System.Windows.Forms.Button btn_add_account;
        private System.Windows.Forms.ListView lv_accounts;
        private System.Windows.Forms.ColumnHeader col_account;
        private System.Windows.Forms.ColumnHeader col_quality;
        private System.Windows.Forms.ColumnHeader col_headers;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
    }
}
