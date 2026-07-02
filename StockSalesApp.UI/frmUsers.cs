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
    public partial class frmUsers : Form
    {
        private readonly UserService _userService = new UserService();

        public frmUsers()
        {
            InitializeComponent();
        }

        // ─── BUTON OLAYLARI ──────────────────────────────────────────────

        private void frmUsers_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenAddForm();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OpenEditForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedUser();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchUsers();
        }

        private void btnListAll_Click(object sender, EventArgs e)
        {
            ClearSearchAndReload();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SearchUsers();
        }

        // ─── PRIVATE METODLAR ────────────────────────────────────────────

        // Sadece kullanıcıları yükler
        private void LoadUsers()
        {
            try
            {
                dgvUsers.DataSource = null;
                dgvUsers.DataSource = _userService.GetAll();
                SetColumnHeaders();
            }
            catch (Exception ex)
            {
                ShowError("Kullanıcılar yüklenirken hata: " + ex.Message);
            }
        }

        // Sadece arama yapar
        private void SearchUsers()
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadUsers();
                return;
            }

            try
            {
                var all = _userService.GetAll();
                var filtered = all.FindAll(u =>
                    u.Username.ToLower().Contains(txtSearch.Text.ToLower().Trim()));

                dgvUsers.DataSource = null;
                dgvUsers.DataSource = filtered;
                SetColumnHeaders();
            }
            catch (Exception ex)
            {
                ShowError("Arama hatası: " + ex.Message);
            }
        }

        // Sadece aramayı temizler ve listeyi yeniler
        private void ClearSearchAndReload()
        {
            txtSearch.Clear();
            LoadUsers();
        }

        // Sadece ekleme formunu açar
        private void OpenAddForm()
        {
            new frmUserDetail(null).ShowDialog();
            LoadUsers();
        }

        // Sadece düzenleme formunu açar
        private void OpenEditForm()
        {
            if (!IsRowSelected("güncellenecek")) return;
            var user = GetSelectedUser();
            new frmUserDetail(user).ShowDialog();
            LoadUsers();
        }

        // Sadece silme işlemini yönetir
        private void DeleteSelectedUser()
        {
            if (!IsRowSelected("silinecek")) return;
            if (!ConfirmDeletion()) return;

            try
            {
                int id = (int)dgvUsers.SelectedRows[0].Cells["Id"].Value;
                _userService.Delete(id);
                ShowInfo("Kullanıcı başarıyla silindi.");
                LoadUsers();
            }
            catch (Exception ex)
            {
                ShowError("Silme sırasında hata: " + ex.Message);
            }
        }

        // Sadece seçili satırdan User nesnesi oluşturur
        private User GetSelectedUser()
        {
            var row = dgvUsers.SelectedRows[0];
            return new User
            {
                Id = (int)row.Cells["Id"].Value,
                Username = row.Cells["Username"].Value.ToString(),
                RoleId = (int)row.Cells["RoleId"].Value,
                RoleName = row.Cells["RoleName"].Value.ToString()
            };
        }

        // Sadece sütun başlıklarını ayarlar
        private void SetColumnHeaders()
        {
            if (dgvUsers.Columns.Count == 0) return;
            dgvUsers.Columns["PasswordHash"].Visible = false;
            dgvUsers.Columns["Id"].Visible = false;
            dgvUsers.Columns["RoleId"].Visible = false;
            dgvUsers.Columns["Username"].HeaderText = "Kullanıcı Adı";
            dgvUsers.Columns["RoleName"].HeaderText = "Rol";
        }

        // Sadece satır seçili mi kontrol eder
        private bool IsRowSelected(string action)
        {
            if (dgvUsers.SelectedRows.Count > 0) return true;
            ShowWarning($"Lütfen {action} kullanıcıyı seçin.");
            return false;
        }

        // Sadece silme onayı alır
        private bool ConfirmDeletion()
        {
            string username = dgvUsers.SelectedRows[0].Cells["Username"].Value.ToString();
            return MessageBox.Show(
                $"'{username}' kullanıcısını silmek istediğinize emin misiniz?",
                "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes;
        }

        // Mesaj metodları
        private void ShowError(string msg) =>
            MessageBox.Show(msg, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void ShowWarning(string msg) =>
            MessageBox.Show(msg, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void ShowInfo(string msg) =>
            MessageBox.Show(msg, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
