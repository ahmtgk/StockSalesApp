using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockSalesApp.Business;
using StockSalesApp.Entities;

namespace StockSalesApp.UI
{
    public partial class frmLogin : Form
    {
        private readonly UserService _userService = new UserService();

        public frmLogin()
        {
            InitializeComponent();
        }

        // Giriş Yap butonuna tıklanınca
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Kullanıcı adı boş olamaz.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Şifre boş olamaz.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                User user = _userService.Login(
                    txtUsername.Text.Trim(),
                    txtPassword.Text);

                if (user == null)
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı.",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }

                // Giriş başarılı, ana formu aç
                frmMain mainForm = new frmMain(user);
                mainForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // CheckBox işaretlenince şifreyi göster/gizle
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
                txtPassword.PasswordChar = '\0'; // '\0' = karakter yok = düz metin göster
            else
                txtPassword.PasswordChar = '*';  // Tekrar yıldız yap
        }

        // Enter tuşuna basınca giriş yap
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btnLogin_Click(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}