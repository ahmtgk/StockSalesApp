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
    public partial class frmUserDetail : Form
    {
        private readonly UserService _userService = new UserService();
        private readonly User _user;

        public frmUserDetail(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void frmUserDetail_Load(object sender, EventArgs e)
        {
            // ComboBox'a rolleri ekle
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Kasiyer");
            cmbRole.SelectedIndex = 1; // Varsayılan Kasiyer

            if (_user == null)
            {
                // Yeni kullanıcı modu
                this.Text = "Yeni Kullanıcı Ekle";
                lblPasswordInfo.Text = "Şifre zorunludur.";
            }
            else
            {
                // Güncelleme modu
                this.Text = "Kullanıcı Güncelle";
                txtUsername.Text = _user.Username;
                lblPasswordInfo.Text = "Şifreyi değiştirmek istemiyorsanız boş bırakın.";

                // Mevcut rolü seç
                cmbRole.SelectedItem = _user.RoleName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Kullanıcı adı kontrolü
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Kullanıcı adı boş olamaz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Rol seçimi kontrolü
            if (cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir rol seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Yeni kullanıcıda şifre zorunlu
            if (_user == null && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Yeni kullanıcı için şifre zorunludur.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Şifre girilmişse eşleşiyor mu kontrol et
            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                if (txtPassword.Text != txtPasswordConfirm.Text)
                {
                    MessageBox.Show("Şifreler eşleşmiyor.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtPassword.Text.Length < 4)
                {
                    MessageBox.Show("Şifre en az 4 karakter olmalıdır.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                // Seçilen rol adından RoleId belirle
                // Admin = 1, Kasiyer = 2 (veritabanındaki sırayla)
                int roleId = cmbRole.SelectedItem.ToString() == "Admin" ? 1 : 2;

                if (_user == null)
                {
                    // Yeni kullanıcı ekle
                    var newUser = new User
                    {
                        Username = txtUsername.Text.Trim(),
                        RoleId = roleId
                    };
                    _userService.Add(newUser, txtPassword.Text);
                    MessageBox.Show("Kullanıcı başarıyla eklendi.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Mevcut kullanıcıyı güncelle
                    _user.Username = txtUsername.Text.Trim();
                    _user.RoleId = roleId;
                    _user.RoleName = cmbRole.SelectedItem.ToString();

                    // Şifre girilmişse güncelle, girilmemişse mevcut hash korunur
                    string newPassword = string.IsNullOrWhiteSpace(txtPassword.Text)
                        ? null
                        : txtPassword.Text;

                    _userService.Update(_user, newPassword);
                    MessageBox.Show("Kullanıcı başarıyla güncellendi.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtPasswordConfirm.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtPasswordConfirm.PasswordChar = '*';
            }
        }

    }
}

