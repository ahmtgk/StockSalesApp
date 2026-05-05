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

        public frmMain(User user)
        {
            InitializeComponent();
            _currentUser = user;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Hoşgeldiniz, {_currentUser.Username}  |  Rol: {_currentUser.RoleName}";

            // Kasiyer ise Kullanıcı Yönetimi butonu hiç görünmesin
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

                // Son satışları DataGridView'e yükle
                var lastSales = _saleService.GetLast5();
                dgvLastSales.DataSource = null;
                dgvLastSales.DataSource = lastSales;

                // Sütun başlıklarını Türkçe yap
                if (dgvLastSales.Columns.Count > 0)
                {
                    dgvLastSales.Columns["Id"].HeaderText = "Satış No";
                    dgvLastSales.Columns["UserId"].HeaderText = "Kullanıcı ID";
                    dgvLastSales.Columns["TotalAmount"].HeaderText = "Toplam Tutar";
                    dgvLastSales.Columns["SaleDate"].HeaderText = "Tarih";
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
            new frmProducts().ShowDialog();
            LoadDashboard(); // Form kapanınca dashboard'u yenile
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            new frmSale(_currentUser).ShowDialog();
            LoadDashboard(); // Satış yapılınca dashboard güncellensin
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
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
            Application.Exit();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Oturumu kapatmak istediğinize emin misiniz?", "Onay Mesajı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                this.Hide();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblSaleAmount_Click(object sender, EventArgs e)
        {

        }

        private void lblCriticalStock_Click(object sender, EventArgs e)
        {

        }

        private void lblProductCount_Click(object sender, EventArgs e)
        {

        }
    }
}
