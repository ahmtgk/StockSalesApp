using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockSalesApp.Entities;
using StockSalesApp.Business;

namespace StockSalesApp.UI
{
    public partial class frmMain : Form
    {
        private readonly User _currentUser;
        private readonly SaleService _saleService = new SaleService();
        private readonly ProductService _productService = new ProductService();
        private bool _isLogout = false;

        public frmMain(User user)
        {
            InitializeComponent();
            _currentUser = user;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Hoşgeldiniz, {_currentUser.Username}  |  Rol: {_currentUser.RoleName}";

            // Kasiyer bu butonları görmesin
            btnProducts.Visible = _currentUser.RoleName == "Admin";
            btnStock.Visible = _currentUser.RoleName == "Admin";
            btnUsers.Visible = _currentUser.RoleName == "Admin";

            LoadDashboard();
        }
        // Dashboard kartlarını ve son satışları doldurur
        // Her form açılıp kapandıktan sonra da çağırılır — veriler güncel kalır
        public void LoadDashboard()
        {
            try
            {
                // Kartları doldur
                lblSaleAmount.Text = _saleService.GetTodayTotalAmount().ToString("N2") + " ₺";
                lblProductCount.Text = _productService.GetTotalCount().ToString();
                lblCriticalStock.Text = _productService.GetCriticalStockCount().ToString();
                lblSaleCount.Text = _saleService.GetTodaySaleCount().ToString();

                // Kritik stok varsa paneli yanıp sönsün gibi kırmızı yap
                pnlCriticalStock.BackColor = _productService.GetCriticalStockCount() > 0
                    ? System.Drawing.Color.FromArgb(200, 50, 50)   // Koyu kırmızı — dikkat!
                    : System.Drawing.Color.FromArgb(220, 80, 60);  // Normal renk

                // Son 10 satışı yükle
                var lastSales = _saleService.GetLast10();
                dgvLastSales.DataSource = null;
                dgvLastSales.DataSource = lastSales;

                if (dgvLastSales.Columns.Count > 0)
                {
                    // Sütun sıralamasını manuel ayarla — ID her zaman görünsün
                    dgvLastSales.Columns["Id"].HeaderText = "Satış No";
                    dgvLastSales.Columns["Id"].DisplayIndex = 0;
                    dgvLastSales.Columns["Username"].HeaderText = "Kasiyer";
                    dgvLastSales.Columns["Username"].DisplayIndex = 1;
                    dgvLastSales.Columns["TotalAmount"].HeaderText = "Tutar (₺)";
                    dgvLastSales.Columns["TotalAmount"].DisplayIndex = 2;
                    dgvLastSales.Columns["SaleDate"].HeaderText = "Tarih";
                    dgvLastSales.Columns["SaleDate"].DisplayIndex = 3;
                    dgvLastSales.Columns["UserId"].Visible = false;

                    dgvLastSales.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dashboard yüklenirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            if (_currentUser.RoleName != "Admin")
            {
                MessageBox.Show("Ürün yönetimi sadece Admin tarafından yapılabilir.",
                    "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            new frmProducts().ShowDialog();
            LoadDashboard();
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            new frmSale(_currentUser).ShowDialog();
            LoadDashboard(); // Satış yapılınca dashboard güncellensin
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            if (_currentUser.RoleName != "Admin")
            {
                MessageBox.Show("Stok yönetimi sadece Admin tarafından yapılabilir.",
                    "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            new frmStock().ShowDialog();
            LoadDashboard();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            new frmReports().ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            if (_currentUser.RoleName != "Admin")
            {
                MessageBox.Show("Bu ekrana erişim yetkiniz yok.",
                    "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            new frmUsers().ShowDialog();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_isLogout)
                Application.Exit();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?",
                "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            _isLogout = true;
            var loginForm = new frmLogin();
            loginForm.Show();
            this.Close();
        }
    }
    
}
