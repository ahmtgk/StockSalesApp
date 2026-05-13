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
using Microsoft.Win32; // Registry için

namespace StockSalesApp.UI
{
    public partial class frmLogin : Form
    {
        private readonly UserService _userService = new UserService();

        // Registry'de kayıt için anahtar yolu
        private const string RegistryKey = @"SOFTWARE\StockSalesApp";

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            LoadRememberedUser();
        }

        // Kaydedilmiş kullanıcı adını Registry'den yükle
        private void LoadRememberedUser()
        {
            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey(RegistryKey))
                {
                    if (key == null) return;

                    string savedUser = key.GetValue("Username")?.ToString();
                    if (!string.IsNullOrEmpty(savedUser))
                    {
                        txtUsername.Text = savedUser;
                        chkRememberMe.Checked = true;
                        txtPassword.Focus();  // Şifre kutusuna geç
                    }
                }
            }
            catch { } // Registry hatası uygulamayı engellemesin
        }

        // Kullanıcı adını Registry'ye kaydet veya sil
        private void SaveRememberedUser(string username)
        {
            try
            {
                using (var key = Registry.CurrentUser.CreateSubKey(RegistryKey))
                {
                    if (chkRememberMe.Checked)
                        key.SetValue("Username", username);
                    else
                        key.DeleteValue("Username", false); // false = değer yoksa hata verme
                }
            }
            catch { }
        }

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

                if (user is null)
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı.",
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }

                // Beni hatırla — kaydet veya sil
                SaveRememberedUser(txtUsername.Text.Trim());

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

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }

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