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

        private void frmUsers_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                dgvUsers.DataSource = null;
                dgvUsers.DataSource = _userService.GetAll();

                if (dgvUsers.Columns.Count > 0)
                {
                    // Şifre hash'ini kullanıcıya gösterme
                    dgvUsers.Columns["PasswordHash"].Visible = false;
                    dgvUsers.Columns["Id"].Visible = false;
                    dgvUsers.Columns["RoleId"].Visible = false;
                    dgvUsers.Columns["Username"].HeaderText = "Kullanıcı Adı";
                    dgvUsers.Columns["RoleName"].HeaderText = "Rol";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcılar yüklenirken hata: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new frmUserDetail(null);
            form.ShowDialog();
            LoadUsers();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellenecek kullanıcıyı seçin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvUsers.SelectedRows[0];
            var user = new User
            {
                Id = (int)row.Cells["Id"].Value,
                Username = row.Cells["Username"].Value.ToString(),
                RoleId = (int)row.Cells["RoleId"].Value,
                RoleName = row.Cells["RoleName"].Value.ToString()
            };

            var form = new frmUserDetail(user);
            form.ShowDialog();
            LoadUsers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek kullanıcıyı seçin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvUsers.SelectedRows[0];
            string username = row.Cells["Username"].Value.ToString();

            var result = MessageBox.Show(
                $"'{username}' kullanıcısını silmek istediğinize emin misiniz?",
                "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            try
            {
                int id = (int)row.Cells["Id"].Value;
                _userService.Delete(id);
                MessageBox.Show("Kullanıcı başarıyla silindi.",
                    "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme sırasında hata: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
