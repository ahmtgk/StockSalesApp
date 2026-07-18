using StockSalesApp.Business;
using StockSalesApp.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StockSalesApp.UI
{
    public partial class frmReports : Form
    {
        private readonly SaleService _saleService = new SaleService();
        private readonly ProductService _productService = new ProductService();
        private readonly ExcelExportService _exportService = new ExcelExportService();

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

        private void btnExportSales_Click(object sender, EventArgs e)
        {
            ExportSalesReport();
        }

        private void btnExportTop_Click(object sender, EventArgs e)
        {
            ExportTopProducts();
        }

        private void btnExportStock_Click(object sender, EventArgs e)
        {
            ExportStockReport();
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
        private List<Product> GetFilteredProducts()
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
        private decimal CalculateTotalFromSales(List<Sale> sales)
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
            dgvSalesReport.Columns["PaymentMethod"].HeaderText = "Ödeme Yöntemi";
            dgvSalesReport.Columns["ReceiptPath"].Visible = false;
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

        // ─── EXPORT METODLARI ────────────────────────────────────────────

        // Sadece satış raporunu export eder
        private void ExportSalesReport()
        {
            try
            {
                var sales = _saleService.GetByDateRange(dtpStart.Value, dtpEnd.Value);
                if (sales.Count == 0)
                {
                    ShowError("Seçilen tarih aralığında satış bulunamadı.");
                    return;
                }

                string path = AskSavePath(
                    $"Satis_Raporu_{dtpStart.Value:ddMMyyyy}.xlsx");
                if (path == null) return;

                _exportService.ExportSalesReport(
                    sales, dtpStart.Value, dtpEnd.Value, path);
                ShowInfo("Excel dosyası başarıyla oluşturuldu.");
            }
            catch (Exception ex)
            {
                ShowError("Export sırasında hata: " + ex.Message);
            }
        }

        // Sadece en çok satılanları export eder
        private void ExportTopProducts()
        {
            try
            {
                var topList = _saleService.GetTopProducts(
                    dtpTopStart.Value, dtpTopEnd.Value);
                if (topList.Count == 0)
                {
                    ShowError("Seçilen tarih aralığında veri bulunamadı.");
                    return;
                }

                string path = AskSavePath(
                    $"EnCok_Satilan_{dtpTopStart.Value:ddMMyyyy}.xlsx");
                if (path == null) return;

                _exportService.ExportTopProducts(
                    topList, dtpTopStart.Value, dtpTopEnd.Value, path);
                ShowInfo("Excel dosyası başarıyla oluşturuldu.");
            }
            catch (Exception ex)
            {
                ShowError("Export sırasında hata: " + ex.Message);
            }
        }

        // Sadece stok raporunu export eder
        private void ExportStockReport()
        {
            try
            {
                var products = GetFilteredProducts();
                if (products.Count == 0)
                {
                    ShowError("Gösterilecek ürün bulunamadı.");
                    return;
                }

                string path = AskSavePath(
                    $"Stok_Raporu_{DateTime.Today:ddMMyyyy}.xlsx");
                if (path == null) return;

                _exportService.ExportStockReport(products, path);
                ShowInfo("Excel dosyası başarıyla oluşturuldu.");
            }
            catch (Exception ex)
            {
                ShowError("Export sırasında hata: " + ex.Message);
            }
        }

        // Sadece kayıt yeri sorar
        private string AskSavePath(string defaultFileName)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Excel Dosyası (*.xlsx)|*.xlsx";
                dialog.FileName = defaultFileName;
                return dialog.ShowDialog() == DialogResult.OK ? dialog.FileName : null;
            }
        }

        private void dgvSalesReport_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenReceipt();
        }

        private void OpenReceipt()
        {
            if (dgvSalesReport.SelectedRows.Count == 0) return;

            var receiptPath = dgvSalesReport.SelectedRows[0]
                .Cells["ReceiptPath"].Value?.ToString();

            if (string.IsNullOrEmpty(receiptPath) || !System.IO.File.Exists(receiptPath))
            {
                ShowError("Bu satışa ait fiş bulunamadı.");
                return;
            }

            // PDF'i varsayılan uygulama ile aç
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = receiptPath,
                UseShellExecute = true
            });
        }

        // ─── MESAJ METODLARI ─────────────────────────────────────────────

        private void ShowError(string msg) =>
            MessageBox.Show(msg, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void ShowInfo(string msg) =>
            MessageBox.Show(msg, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}