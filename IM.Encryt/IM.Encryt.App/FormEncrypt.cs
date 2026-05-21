using IM.Encryt.Models.Entities;
using IM.Encryt.Models.Models;

namespace IM.Encryt.App
{
    public partial class FormEncrypt : Form
    {
        public FormEncrypt()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                string result;

                if (rdRSA.Checked)
                {
                    result = EncryptHelper.EncryptRsa(
                        txtText.Text,
                        txtPublicKey.Text);
                }
                else
                {
                    result = EncryptHelper.Encrypt(
                        txtText.Text,
                        txtSecretKey.Text,
                        rdLegacy.Checked
                            ? EncryptionVersion.Legacy
                            : EncryptionVersion.Modern);
                }

                txtResult.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnDecrypt_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                string result;

                if (rdRSA.Checked)
                {
                    result = EncryptHelper.DecryptRsa(
                        txtText.Text);
                }
                else
                {
                    result = EncryptHelper.Decrypt(
                        txtText.Text,
                        txtSecretKey.Text);
                }

                txtResult.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void rdRSA_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (rdRSA.Checked)
            {
                txtPublicKey.Text =
                    EncryptHelper.PublicKey;
            }
        }
    }
}
