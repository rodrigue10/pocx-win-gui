using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PoCX.Common;

namespace PoCXMinerGUI
{
    public partial class AccountEditDialog : Form
    {
        private ChainAccount _account;

        public ChainAccount Account
        {
            get { return _account; }
        }

        public AccountEditDialog(ChainAccount account = null)
        {
            InitializeComponent();

            if (account != null)
            {
                _account = CloneAccount(account);
                this.Text = "Edit Account";
            }
            else
            {
                _account = new ChainAccount();
                this.Text = "Add Account";
            }

            PopulateUI();
        }

        private ChainAccount CloneAccount(ChainAccount source)
        {
            return new ChainAccount
            {
                Account = source.Account,
                TargetQuality = source.TargetQuality,
                Headers = new Dictionary<string, string>(source.Headers)
            };
        }

        private void PopulateUI()
        {
            txt_account.Text = _account.Account;

            if (_account.TargetQuality.HasValue)
            {
                cb_target_quality.Checked = true;
                ud_target_quality.Value = _account.TargetQuality.Value;
                ud_target_quality.Enabled = true;
            }
            else
            {
                cb_target_quality.Checked = false;
                ud_target_quality.Enabled = false;
            }

            // Populate headers
            dgv_headers.Rows.Clear();
            foreach (var header in _account.Headers)
            {
                dgv_headers.Rows.Add(header.Key, header.Value);
            }
        }

        private void UpdateAccountFromUI()
        {
            _account.Account = txt_account.Text;

            if (cb_target_quality.Checked)
            {
                _account.TargetQuality = (ulong)ud_target_quality.Value;
            }
            else
            {
                _account.TargetQuality = null;
            }

            // Update headers
            _account.Headers.Clear();
            foreach (DataGridViewRow row in dgv_headers.Rows)
            {
                if (!row.IsNewRow && row.Cells[0].Value != null && row.Cells[1].Value != null)
                {
                    string key = row.Cells[0].Value.ToString();
                    string value = row.Cells[1].Value.ToString();
                    if (!string.IsNullOrWhiteSpace(key))
                    {
                        _account.Headers[key] = value;
                    }
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txt_account.Text))
            {
                MessageBox.Show("Account address is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate address format
            var validationResult = AddressValidator.ValidateAddress(txt_account.Text);
            if (!validationResult.IsValid)
            {
                MessageBox.Show($"Invalid account address: {validationResult.ErrorMessage}",
                    "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                this.DialogResult = DialogResult.None;
                return;
            }

            UpdateAccountFromUI();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cb_target_quality_CheckedChanged(object sender, EventArgs e)
        {
            ud_target_quality.Enabled = cb_target_quality.Checked;
        }

        private void txt_account_TextChanged(object sender, EventArgs e)
        {
            // Validate address on change and show indicator
            if (string.IsNullOrWhiteSpace(txt_account.Text))
            {
                lbl_validation.Text = "";
                return;
            }

            var result = AddressValidator.ValidateAddress(txt_account.Text);
            if (result.IsValid)
            {
                lbl_validation.Text = $"✓ Valid {result.AddressType}";
                lbl_validation.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lbl_validation.Text = $"✗ {result.ErrorMessage}";
                lbl_validation.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
