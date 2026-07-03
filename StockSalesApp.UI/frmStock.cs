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
    public partial class frmStock : Form
    {
        private readonly StockService _stockService = new StockService();
        private readonly ProductService _productService = new ProductService();
        private Product _selectedProduct = null;

        public frmStock()
        {
            InitializeComponent();
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchProducts();
        }

        private void btnStockIn_Click(object sender, EventArgs e)
        {
            PerformStockIn();
        }

        private void btnStockOut_Click(object sender, EventArgs e)
        {
            PerformStockOut();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SearchProducts();
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            UpdateSelectedProduct();
        }

        // PRIVATE METODLAR

        // Sadece ürün listesini yükler
        private void LoadProducts()
        {
            try
            {
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = _productService.GetAll();
                SetProductColumns();
            }
            catch (Exception ex)
            {
                ShowError("Ürünler yüklenirken hata: " + ex.Message);
            }
        }

        // Sadece arama işlemini yapar
        private void SearchProducts()
        {
            try
            {
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = _productService.Search(txtSearch.Text);
                SetProductColumns();
            }
            catch (Exception ex)
            {
                ShowError("Arama hatası: " + ex.Message);
            }
        }

        // Sadece seçilen ürün bilgisini günceller
        private void UpdateSelectedProduct()
        {
            if (dgvProducts.SelectedRows.Count == 0) return;

            var row = dgvProducts.SelectedRows[0];
            _selectedProduct = new Product
            {
                Id = (int)row.Cells["Id"].Value,
                Name = row.Cells["Name"].Value.ToString(),
                StockQuantity = (int)row.Cells["StockQuantity"].Value
            };

            txtSelectedProduct.Text = _selectedProduct.Name;
            txtCurrentStock.Text = _selectedProduct.StockQuantity.ToString();
            txtQuantity.Clear();
            txtQuantity.Focus();

            LoadMovementsByProduct(_selectedProduct.Id);
        }

        // Sadece stok girişi yapar
        private void PerformStockIn()
        {
            if (!IsProductSelected()) return;
            if (!IsValidQuantity(out int quantity)) return;

            try
            {
                _stockService.StockIn(_selectedProduct.Id, quantity);
                ShowInfo($"'{_selectedProduct.Name}' ürününe {quantity} adet stok girişi yapıldı.");
                ResetSelectionArea();
                RefreshAfterOperation();
            }
            catch (Exception ex)
            {
                ShowError("Hata: " + ex.Message);
            }
        }

        // Sadece stok çıkışı yapar
        private void PerformStockOut()
        {
            if (!IsProductSelected()) return;
            if (!IsValidQuantity(out int quantity)) return;
            if (!ConfirmStockOut(quantity)) return;

            try
            {
                _stockService.StockOut(_selectedProduct.Id, quantity);
                ShowInfo($"'{_selectedProduct.Name}' ürününden {quantity} adet stok çıkışı yapıldı.");
                ResetSelectionArea();
                RefreshAfterOperation();
            }
            catch (Exception ex)
            {
                ShowError("Hata: " + ex.Message);
            }
        }

        // Sadece seçilen ürünün hareketlerini yükler
        private void LoadMovementsByProduct(int productId)
        {
            try
            {
                dgvMovements.DataSource = null;
                dgvMovements.DataSource = _stockService.GetByProductId(productId);
                SetMovementColumns();
                ColorizeMovementRows();
            }
            catch (Exception ex)
            {
                ShowError("Hareketler yüklenirken hata: " + ex.Message);
            }
        }

        // Sadece işlem sonrası verileri yeniler
        private void RefreshAfterOperation()
        {
            LoadProducts();
            if (_selectedProduct != null)
                LoadMovementsByProduct(_selectedProduct.Id);
        }

        // Sadece seçim alanını sıfırlar
        private void ResetSelectionArea()
        {
            _selectedProduct = null;
            txtSelectedProduct.Text = string.Empty;
            txtCurrentStock.Text = string.Empty;
            txtQuantity.Text = string.Empty;
        }

        // Sadece ürün sütun başlıklarını ayarlar
        private void SetProductColumns()
        {
            if (dgvProducts.Columns.Count == 0) return;
            dgvProducts.Columns["Id"].Visible = false;
            dgvProducts.Columns["PurchasePrice"].Visible = false;
            dgvProducts.Columns["SalePrice"].Visible = false;
            dgvProducts.Columns["Name"].HeaderText = "Ürün Adı";
            dgvProducts.Columns["Barcode"].HeaderText = "Barkod";
            dgvProducts.Columns["StockQuantity"].HeaderText = "Mevcut Stok";
        }

        // Sadece hareket sütun başlıklarını ayarlar
        private void SetMovementColumns()
        {
            if (dgvMovements.Columns.Count == 0) return;
            dgvMovements.Columns["Id"].Visible = false;
            dgvMovements.Columns["ProductId"].Visible = false;
            dgvMovements.Columns["ProductName"].Visible = false;
            dgvMovements.Columns["Quantity"].HeaderText = "Miktar";
            dgvMovements.Columns["MovementType"].HeaderText = "Tür";
            dgvMovements.Columns["MovementDate"].HeaderText = "Tarih";
        }

        // Sadece hareket satırlarını renklendirir
        private void ColorizeMovementRows()
        {
            foreach (DataGridViewRow row in dgvMovements.Rows)
            {
                string type = row.Cells["MovementType"].Value?.ToString();
                row.DefaultCellStyle.BackColor = type == "IN"
                    ? System.Drawing.Color.FromArgb(200, 240, 200)
                    : System.Drawing.Color.FromArgb(255, 200, 200);
            }
        }

        // YARDIMCI KONTROL METODLARI

        // Sadece ürün seçili mi kontrol eder
        private bool IsProductSelected()
        {
            if (_selectedProduct != null) return true;
            ShowWarning("Lütfen listeden bir ürün seçin.");
            return false;
        }

        // Sadece miktar geçerli mi kontrol eder
        private bool IsValidQuantity(out int quantity)
        {
            if (int.TryParse(txtQuantity.Text, out quantity) && quantity > 0)
                return true;
            ShowWarning("Lütfen geçerli bir miktar girin.");
            quantity = 0;
            return false;
        }

        // Sadece stok çıkışı onayı alır
        private bool ConfirmStockOut(int quantity) =>
            MessageBox.Show(
                $"'{_selectedProduct.Name}' ürününden {quantity} adet stok çıkışı yapılacak. Onaylıyor musunuz?",
                "Stok Çıkışı Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            == DialogResult.Yes;

        // Mesaj metodları
        private void ShowError(string msg) =>
            MessageBox.Show(msg, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void ShowWarning(string msg) =>
            MessageBox.Show(msg, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void ShowInfo(string msg) =>
            MessageBox.Show(msg, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
