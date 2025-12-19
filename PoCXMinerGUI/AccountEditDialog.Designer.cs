namespace PoCXMinerGUI
{
    partial class AccountEditDialog
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
            this.lbl_validation = new System.Windows.Forms.Label();
            this.txt_account = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ud_target_quality = new System.Windows.Forms.NumericUpDown();
            this.cb_target_quality = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_headers = new System.Windows.Forms.DataGridView();
            this.col_header_key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_header_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_target_quality)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_headers)).BeginInit();
            this.SuspendLayout();
            //
            // groupBox1
            //
            this.groupBox1.Controls.Add(this.lbl_validation);
            this.groupBox1.Controls.Add(this.txt_account);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account";
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Address:";
            //
            // txt_account
            //
            this.txt_account.Location = new System.Drawing.Point(80, 22);
            this.txt_account.Name = "txt_account";
            this.txt_account.Size = new System.Drawing.Size(365, 20);
            this.txt_account.TabIndex = 1;
            this.txt_account.TextChanged += new System.EventHandler(this.txt_account_TextChanged);
            //
            // lbl_validation
            //
            this.lbl_validation.AutoSize = true;
            this.lbl_validation.Location = new System.Drawing.Point(80, 50);
            this.lbl_validation.Name = "lbl_validation";
            this.lbl_validation.Size = new System.Drawing.Size(0, 13);
            this.lbl_validation.TabIndex = 2;
            //
            // groupBox2
            //
            this.groupBox2.Controls.Add(this.ud_target_quality);
            this.groupBox2.Controls.Add(this.cb_target_quality);
            this.groupBox2.Location = new System.Drawing.Point(12, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(460, 60);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Optional Settings";
            //
            // cb_target_quality
            //
            this.cb_target_quality.AutoSize = true;
            this.cb_target_quality.Location = new System.Drawing.Point(18, 25);
            this.cb_target_quality.Name = "cb_target_quality";
            this.cb_target_quality.Size = new System.Drawing.Size(93, 17);
            this.cb_target_quality.TabIndex = 0;
            this.cb_target_quality.Text = "Target Quality:";
            this.cb_target_quality.UseVisualStyleBackColor = true;
            this.cb_target_quality.CheckedChanged += new System.EventHandler(this.cb_target_quality_CheckedChanged);
            //
            // ud_target_quality
            //
            this.ud_target_quality.Enabled = false;
            this.ud_target_quality.Location = new System.Drawing.Point(117, 24);
            this.ud_target_quality.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.ud_target_quality.Name = "ud_target_quality";
            this.ud_target_quality.Size = new System.Drawing.Size(120, 20);
            this.ud_target_quality.TabIndex = 1;
            //
            // groupBox3
            //
            this.groupBox3.Controls.Add(this.dgv_headers);
            this.groupBox3.Location = new System.Drawing.Point(12, 164);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(460, 180);
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
            this.dgv_headers.Size = new System.Drawing.Size(454, 161);
            this.dgv_headers.TabIndex = 0;
            //
            // col_header_key
            //
            this.col_header_key.HeaderText = "Key";
            this.col_header_key.Name = "col_header_key";
            this.col_header_key.Width = 150;
            //
            // col_header_value
            //
            this.col_header_value.HeaderText = "Value";
            this.col_header_value.Name = "col_header_value";
            this.col_header_value.Width = 250;
            //
            // btn_ok
            //
            this.btn_ok.Location = new System.Drawing.Point(316, 350);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 3;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            //
            // btn_cancel
            //
            this.btn_cancel.Location = new System.Drawing.Point(397, 350);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 4;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            //
            // AccountEditDialog
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 385);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountEditDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Account";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_target_quality)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_headers)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_validation;
        private System.Windows.Forms.TextBox txt_account;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown ud_target_quality;
        private System.Windows.Forms.CheckBox cb_target_quality;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_headers;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_header_key;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_header_value;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
    }
}
