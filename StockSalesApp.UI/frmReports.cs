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
    public partial class frmReports : Form
    {
        private readonly SaleService _saleService = new SaleService();
        private readonly ProductService _productService = new ProductService();

        public frmReports()
        {
            InitializeComponent();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            // Tarih seçicileri bugüne set et
            dtpStart.Value = DateTime.Today;
            dtpEnd.Value = DateTime.Today;
            dtpTopStart.Value = DateTime.Today.AddDays(-30); // Son 30 gün
            dtpTopEnd.Value = DateTime.Today;

            // Stok filtre seçeneklerini ekle
            cmbStockFilter.Items.Clear();
            cmbStockFilter.Items.Add("Tüm Ürünler");
            cmbStockFilter.Items.Add("Kritik Stok (≤ 5)");
            cmbStockFilter.Items.Add("Stok Yok (= 0)");
            cmbStockFilter.SelectedIndex = 0;

            // Formlar açılınca her sekmeyi yükle
            LoadSalesReport();
            LoadTopProducts();
            LoadStockReport();
        }

        // SEKME 1: Günlük Satış Raporu 

        private void LoadSalesReport()
        {
            try
            {
                var sales = _saleService.GetByDateRange(
                    dtpStart.Value, dtpEnd.Value);

                dgvSalesReport.DataSource = null;
                dgvSalesReport.DataSource = sales;

                if (dgvSalesReport.Columns.Count > 0)
                {
                    dgvSalesReport.Columns["Id"].HeaderText = "Satış No";
                    dgvSalesReport.Columns["UserId"].Visible = false;
                    dgvSalesReport.Columns["TotalAmount"].HeaderText = "Tutar (₺)";
                    dgvSalesReport.Columns["SaleDate"].HeaderText = "Tarih";
                    dgvSalesReport.Columns["Username"].HeaderText = "Kasiyer";
                }

                // Toplam tutarı hesapla ve göster
                decimal total = 0;
                foreach (var s in sales) total += s.TotalAmount;

                lblSalesSummary.Text = $"Toplam {sales.Count} satış  |  Toplam Tutar: {total:N2} ₺";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rapor yüklenirken hata: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilterSales_Click(object sender, EventArgs e)
        {
            LoadSalesReport();
        }

        // SEKME 2: En Çok Satılan Ürünler

        private void LoadTopProducts()
        {
            try
            {
                var topList = _saleService.GetTopProducts(
                    dtpTopStart.Value, dtpTopEnd.Value);

                dgvTopProducts.DataSource = null;
                dgvTopProducts.DataSource = topList;

                if (dgvTopProducts.Columns.Count > 0)
                {
                    dgvTopProducts.Columns["ProductName"].HeaderText = "Ürün Adı";
                    dgvTopProducts.Columns["TotalQuantity"].HeaderText = "Satılan Adet";
                    dgvTopProducts.Columns["TotalRevenue"].HeaderText = "Toplam Gelir (₺)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rapor yüklenirken hata: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilterTop_Click(object sender, EventArgs e)
        {
            LoadTopProducts();
        }

        // SEKME 3: Stok Durumu

        private void LoadStockReport()
        {
            try
            {
                var products = _productService.GetAll();

                // Seçilen filtreye göre listele
                switch (cmbStockFilter.SelectedIndex)
                {
                    case 1: // Kritik stok
                        products = products.FindAll(p => p.StockQuantity <= 5);
                        break;
                    case 2: // Stok yok
                        products = products.FindAll(p => p.StockQuantity == 0);
                        break;
                        // case 0: Tüm ürünler — filtreleme yok
                }

                dgvStockReport.DataSource = null;
                dgvStockReport.DataSource = products;

                if (dgvStockReport.Columns.Count > 0)
                {
                    dgvStockReport.Columns["Id"].Visible = false;
                    dgvStockReport.Columns["PurchasePrice"].Visible = false;
                    dgvStockReport.Columns["Name"].HeaderText = "Ürün Adı";
                    dgvStockReport.Columns["Barcode"].HeaderText = "Barkod";
                    dgvStockReport.Columns["SalePrice"].HeaderText = "Satış Fiyatı";
                    dgvStockReport.Columns["StockQuantity"].HeaderText = "Stok Miktarı";

                    // Stoku 0 olan satırları kırmızı yap
                    foreach (DataGridViewRow row in dgvStockReport.Rows)
                    {
                        int stock = (int)row.Cells["StockQuantity"].Value;
                        if (stock == 0)
                            row.DefaultCellStyle.BackColor =
                                System.Drawing.Color.FromArgb(255, 200, 200);
                        else if (stock <= 5)
                            row.DefaultCellStyle.BackColor =
                                System.Drawing.Color.FromArgb(255, 240, 200);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Stok raporu yüklenirken hata: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadStock_Click(object sender, EventArgs e)
        {
            LoadStockReport();
        }

        private void cmbStockFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStockReport();
        }
    }
}