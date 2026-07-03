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
        private const string RegistryKey = @"SOFTWARE\StockSalesApp";

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            LoadRememberedUser();
        }
        // Her buton sadece ilgili metodu çağıracak 

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;
            PerformLogin();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            TogglePasswordVisibility();
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

        // PRIVATE METODLAR 
        // Her metot tek bir iş yapar — SRP prensibi

        // Sadece giriş alanlarının boş olup olmadığını kontrol eder
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Kullanıcı adı boş olamaz.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Şifre boş olamaz.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // Sadece giriş işlemini gerçekleştirir
        private void PerformLogin()
        {
            try
            {
                User user = _userService.Login(
                    txtUsername.Text.Trim(),
                    txtPassword.Text);

                if (user is null)
                {
                    HandleFailedLogin();
                    return;
                }

                HandleSuccessfulLogin(user);
            }
            catch (Exception ex)
            {
                ShowError("Bir hata oluştu: " + ex.Message);
            }
        }

        // Sadece başarısız giriş durumunu yönetir
        private void HandleFailedLogin()
        {
            MessageBox.Show("Kullanıcı adı veya şifre hatalı.",
                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtPassword.Clear();
            txtPassword.Focus();
        }

        // Sadece başarılı giriş durumunu yönetir
        private void HandleSuccessfulLogin(User user)
        {
            SaveRememberedUser(txtUsername.Text.Trim());
            OpenMainForm(user);
        }

        // Sadece ana formu açar
        private void OpenMainForm(User user)
        {
            var mainForm = new frmMain(user);
            mainForm.Show();
            this.Close();
        }

        // Sadece şifre görünürlüğünü değiştirir
        private void TogglePasswordVisibility()
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }

        // Sadece kayıtlı kullanıcıyı yükler
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
                        txtPassword.Focus();
                    }
                }
            }
            catch { }
        }

        // Sadece kullanıcı adını kaydeder veya siler
        private void SaveRememberedUser(string username)
        {
            try
            {
                using (var key = Registry.CurrentUser.CreateSubKey(RegistryKey))
                {
                    if (chkRememberMe.Checked)
                        key.SetValue("Username", username);
                    else
                        key.DeleteValue("Username", false);
                }
            }
            catch { }
        }

        // Sadece hata mesajı gösterir
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Hata",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Login formu kapanınca açık başka form kalmadıysa uygulamayı kapat
            if (Application.OpenForms.Count == 0)
                Application.Exit();
        }
    }
}