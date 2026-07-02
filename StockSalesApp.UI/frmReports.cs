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

        // ─── BUTON OLAYLARI ──────────────────────────────────────────────

        private void frmReports_Load(object sender, EventArgs e)
        {
            InitializeDatePickers();
            InitializeStockFilter();
            LoadSalesReport();
            LoadTopProducts();
        }

        private void btnFilterSales_Click(object sender, EventArgs e)
        {
            LoadSalesReport();
        }

        private void btnFilterTop_Click(object sender, EventArgs e)
        {
            LoadTopProducts();
        }

        private void btnLoadStock_Click(object sender, EventArgs e)
        {
            LoadStockReport();
        }

        private void cmbStockFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Otomatik yükleme yok — butona basılınca yüklenir
        }

        // ─── PRIVATE METODLAR ────────────────────────────────────────────

        // Sadece tarih seçicileri başlangıç değerlerini ayarlar
        private void InitializeDatePickers()
        {
            dtpStart.Value = DateTime.Today;
            dtpEnd.Value = DateTime.Today;
            dtpTopStart.Value = DateTime.Today.AddDays(-30);
            dtpTopEnd.Value = DateTime.Today;
        }

        // Sadece stok filtre seçeneklerini yükler
        private void InitializeStockFilter()
        {
            cmbStockFilter.Items.Clear();
            cmbStockFilter.Items.Add("Tüm Ürünler");
            cmbStockFilter.Items.Add("Kritik Stok (≤ 5)");
            cmbStockFilter.Items.Add("Stok Yok (= 0)");
            cmbStockFilter.SelectedIndex = 0;
        }

        // Sadece satış raporunu yükler
        private void LoadSalesReport()
        {
            try
            {
                var sales = _saleService.GetByDateRange(dtpStart.Value, dtpEnd.Value);

                dgvSalesReport.DataSource = null;
                dgvSalesReport.DataSource = sales;
                SetSalesReportColumns();

                decimal total = CalculateTotalFromSales(sales);
                lblSalesSummary.Text =
                    $"Toplam {sales.Count} satış  |  Toplam Tutar: {total:N2} ₺";
            }
            catch (Exception ex)
            {
                ShowError("Satış raporu yüklenirken hata: " + ex.Message);
            }
        }

        // Sadece en çok satılan ürünleri yükler
        private void LoadTopProducts()
        {
            try
            {
                var topList = _saleService.GetTopProducts(
                    dtpTopStart.Value, dtpTopEnd.Value);

                dgvTopProducts.DataSource = null;
                dgvTopProducts.DataSource = topList;
                SetTopProductColumns();
            }
            catch (Exception ex)
            {
                ShowError("En çok satılan raporu yüklenirken hata: " + ex.Message);
            }
        }

        // Sadece stok durumu raporunu yükler
        private void LoadStockReport()
        {
            try
            {
                var products = GetFilteredProducts();

                dgvStockReport.DataSource = null;
                dgvStockReport.DataSource = products;
                SetStockReportColumns();
                ColorizeStockRows();
            }
            catch (Exception ex)
            {
                ShowError("Stok raporu yüklenirken hata: " + ex.Message);
            }
        }

        // Sadece filtreye göre ürün listesi döndürür
        private System.Collections.Generic.List<StockSalesApp.Entities.Product> GetFilteredProducts()
        {
            var all = _productService.GetAll();
            switch (cmbStockFilter.SelectedIndex)
            {
                case 1: return all.FindAll(p => p.StockQuantity <= 5);
                case 2: return all.FindAll(p => p.StockQuantity == 0);
                default: return all;
            }
        }

        // Sadece toplam tutarı hesaplar
        private decimal CalculateTotalFromSales(
            System.Collections.Generic.List<StockSalesApp.Entities.Sale> sales)
        {
            decimal total = 0;
            foreach (var s in sales) total += s.TotalAmount;
            return total;
        }

        // Sadece satış raporu sütunlarını ayarlar
        private void SetSalesReportColumns()
        {
            if (dgvSalesReport.Columns.Count == 0) return;
            dgvSalesReport.Columns["Id"].HeaderText = "Satış No";
            dgvSalesReport.Columns["UserId"].Visible = false;
            dgvSalesReport.Columns["TotalAmount"].HeaderText = "Tutar (₺)";
            dgvSalesReport.Columns["SaleDate"].HeaderText = "Tarih";
            dgvSalesReport.Columns["Username"].HeaderText = "Kasiyer";
        }

        // Sadece en çok satılan sütunlarını ayarlar
        private void SetTopProductColumns()
        {
            if (dgvTopProducts.Columns.Count == 0) return;
            dgvTopProducts.Columns["ProductName"].HeaderText = "Ürün Adı";
            dgvTopProducts.Columns["TotalQuantity"].HeaderText = "Satılan Adet";
            dgvTopProducts.Columns["TotalRevenue"].HeaderText = "Toplam Gelir (₺)";
        }

        // Sadece stok raporu sütunlarını ayarlar
        private void SetStockReportColumns()
        {
            if (dgvStockReport.Columns.Count == 0) return;
            dgvStockReport.Columns["Id"].Visible = false;
            dgvStockReport.Columns["PurchasePrice"].Visible = false;
            dgvStockReport.Columns["Name"].HeaderText = "Ürün Adı";
            dgvStockReport.Columns["Barcode"].HeaderText = "Barkod";
            dgvStockReport.Columns["SalePrice"].HeaderText = "Satış Fiyatı";
            dgvStockReport.Columns["StockQuantity"].HeaderText = "Stok Miktarı";
        }

        // Sadece stok satırlarını renklendirir
        private void ColorizeStockRows()
        {
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

        // Mesaj metodları
        private void ShowError(string msg) =>
            MessageBox.Show(msg, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}