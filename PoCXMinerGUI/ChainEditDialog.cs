using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PoCXMinerGUI
{
    public partial class ChainEditDialog : Form
    {
        private ChainConfig _chain;

        public ChainConfig Chain
        {
            get { return _chain; }
        }

        public ChainEditDialog(ChainConfig chain = null)
        {
            InitializeComponent();

            if (chain != null)
            {
                _chain = CloneChain(chain);
                this.Text = "Edit Chain";
            }
            else
            {
                _chain = new ChainConfig();
                this.Text = "Add Chain";
            }

            PopulateUI();
        }

        private ChainConfig CloneChain(ChainConfig source)
        {
            var clone = new ChainConfig
            {
                Name = source.Name,
                BaseUrl = source.BaseUrl,
                ApiPath = source.ApiPath,
                BlockTimeSeconds = source.BlockTimeSeconds,
                AuthToken = source.AuthToken,
                TargetQuality = source.TargetQuality,
                SubmissionMode = source.SubmissionMode,
                Headers = new Dictionary<string, string>(source.Headers),
                Accounts = new List<ChainAccount>()
            };

            foreach (var account in source.Accounts)
            {
                clone.Accounts.Add(new ChainAccount
                {
                    Account = account.Account,
                    TargetQuality = account.TargetQuality,
                    Headers = new Dictionary<string, string>(account.Headers)
                });
            }

            return clone;
        }

        private void PopulateUI()
        {
            txt_name.Text = _chain.Name;
            txt_baseurl.Text = _chain.BaseUrl;
            txt_apipath.Text = _chain.ApiPath;
            ud_blocktime.Value = _chain.BlockTimeSeconds;
            txt_authtoken.Text = _chain.AuthToken;

            if (_chain.SubmissionMode == SubmissionMode.Pool)
            {
                rb_pool.Checked = true;
            }
            else
            {
                rb_wallet.Checked = true;
            }

            if (_chain.TargetQuality.HasValue)
            {
                cb_target_quality.Checked = true;
                ud_target_quality.Value = _chain.TargetQuality.Value;
                ud_target_quality.Enabled = true;
            }
            else
            {
                cb_target_quality.Checked = false;
                ud_target_quality.Enabled = false;
            }

            // Populate headers
            dgv_headers.Rows.Clear();
            foreach (var header in _chain.Headers)
            {
                dgv_headers.Rows.Add(header.Key, header.Value);
            }

            // Populate accounts
            lv_accounts.Items.Clear();
            foreach (var account in _chain.Accounts)
            {
                var item = new ListViewItem(account.Account);
                item.SubItems.Add(account.TargetQuality?.ToString() ?? "");
                item.SubItems.Add(account.Headers.Count.ToString());
                item.Tag = account;
                lv_accounts.Items.Add(item);
            }
        }

        private void UpdateChainFromUI()
        {
            _chain.Name = txt_name.Text;
            _chain.BaseUrl = txt_baseurl.Text;
            _chain.ApiPath = txt_apipath.Text;
            _chain.BlockTimeSeconds = (ulong)ud_blocktime.Value;
            _chain.AuthToken = string.IsNullOrWhiteSpace(txt_authtoken.Text) ? null : txt_authtoken.Text;

            _chain.SubmissionMode = rb_pool.Checked ? SubmissionMode.Pool : SubmissionMode.Wallet;

            if (cb_target_quality.Checked)
            {
                _chain.TargetQuality = (ulong)ud_target_quality.Value;
            }
            else
            {
                _chain.TargetQuality = null;
            }

            // Update headers
            _chain.Headers.Clear();
            foreach (DataGridViewRow row in dgv_headers.Rows)
            {
                if (!row.IsNewRow && row.Cells[0].Value != null && row.Cells[1].Value != null)
                {
                    string key = row.Cells[0].Value.ToString();
                    string value = row.Cells[1].Value.ToString();
                    if (!string.IsNullOrWhiteSpace(key))
                    {
                        _chain.Headers[key] = value;
                    }
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txt_name.Text))
            {
                MessageBox.Show("Chain name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_baseurl.Text))
            {
                MessageBox.Show("Base URL is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!txt_baseurl.Text.StartsWith("http://") && !txt_baseurl.Text.StartsWith("https://"))
            {
                MessageBox.Show("Base URL must start with http:// or https://", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // API path is optional - can be empty
            // No other validation needed - the path_segments_mut().push() method handles formatting

            return true;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                this.DialogResult = DialogResult.None;
                return;
            }

            UpdateChainFromUI();
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

        private void btn_add_account_Click(object sender, EventArgs e)
        {
            using (var dialog = new AccountEditDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _chain.Accounts.Add(dialog.Account);

                    var item = new ListViewItem(dialog.Account.Account);
                    item.SubItems.Add(dialog.Account.TargetQuality?.ToString() ?? "");
                    item.SubItems.Add(dialog.Account.Headers.Count.ToString());
                    item.Tag = dialog.Account;
                    lv_accounts.Items.Add(item);
                }
            }
        }

        private void btn_edit_account_Click(object sender, EventArgs e)
        {
            if (lv_accounts.SelectedItems.Count == 0)
                return;

            var item = lv_accounts.SelectedItems[0];
            var account = item.Tag as ChainAccount;

            using (var dialog = new AccountEditDialog(account))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Update the account reference
                    int index = _chain.Accounts.IndexOf(account);
                    _chain.Accounts[index] = dialog.Account;

                    // Update ListView
                    item.Text = dialog.Account.Account;
                    item.SubItems[1].Text = dialog.Account.TargetQuality?.ToString() ?? "";
                    item.SubItems[2].Text = dialog.Account.Headers.Count.ToString();
                    item.Tag = dialog.Account;
                }
            }
        }

        private void btn_remove_account_Click(object sender, EventArgs e)
        {
            if (lv_accounts.SelectedItems.Count == 0)
                return;

            var item = lv_accounts.SelectedItems[0];
            var account = item.Tag as ChainAccount;

            var result = MessageBox.Show(
                $"Remove account {account.Account}?",
                "Confirm Remove",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _chain.Accounts.Remove(account);
                lv_accounts.Items.Remove(item);
            }
        }
    }
}
