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

        // Listeden seçilen ürünü saklıyoruz
        // Stok girişi yaparken hangi ürüne giriş yapıldığını bilmek için
        private Product _selectedProduct = null;

        public frmStock()
        {
            InitializeComponent();
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadMovements();
        }

        // Ürün listesini yükler
        private void LoadProducts()
        {
            try
            {
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = _productService.GetAll();

                if (dgvProducts.Columns.Count > 0)
                {
                    dgvProducts.Columns["Id"].Visible = false;
                    dgvProducts.Columns["PurchasePrice"].Visible = false; // Bu ekranda gerek yok
                    dgvProducts.Columns["SalePrice"].Visible = false; // Bu ekranda gerek yok
                    dgvProducts.Columns["Name"].HeaderText = "Ürün Adı";
                    dgvProducts.Columns["Barcode"].HeaderText = "Barkod";
                    dgvProducts.Columns["StockQuantity"].HeaderText = "Mevcut Stok";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünler yüklenirken hata: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Stok hareketlerini yükler
        private void LoadMovements()
        {
            try
            {
                dgvMovements.DataSource = null;
                dgvMovements.DataSource = _stockService.GetAll();

                if (dgvMovements.Columns.Count > 0)
                {
                    dgvMovements.Columns["Id"].Visible = false;
                    dgvMovements.Columns["ProductId"].Visible = false;
                    dgvMovements.Columns["ProductName"].HeaderText = "Ürün";
                    dgvMovements.Columns["Quantity"].HeaderText = "Miktar";
                    dgvMovements.Columns["MovementType"].HeaderText = "Tür";
                    dgvMovements.Columns["MovementDate"].HeaderText = "Tarih";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Stok hareketleri yüklenirken hata: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Listeden ürün seçilince alt kısımdaki bilgileri doldur
        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0) return;

            var row = dgvProducts.SelectedRows[0];

            // Seçilen ürünü nesneye aktar
            _selectedProduct = new Product
            {
                Id = (int)row.Cells["Id"].Value,
                Name = row.Cells["Name"].Value.ToString(),
                StockQuantity = (int)row.Cells["StockQuantity"].Value
            };

            // Alt kısımdaki kutulara seçilen ürünün bilgilerini yaz
            txtSelectedProduct.Text = _selectedProduct.Name;
            txtCurrentStock.Text = _selectedProduct.StockQuantity.ToString();
            txtQuantity.Clear();
            txtQuantity.Focus();
        }

        // Arama butonu
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = _productService.Search(txtSearch.Text);

                if (dgvProducts.Columns.Count > 0)
                {
                    dgvProducts.Columns["Id"].Visible = false;
                    dgvProducts.Columns["PurchasePrice"].Visible = false;
                    dgvProducts.Columns["SalePrice"].Visible = false;
                    dgvProducts.Columns["Name"].HeaderText = "Ürün Adı";
                    dgvProducts.Columns["Barcode"].HeaderText = "Barkod";
                    dgvProducts.Columns["StockQuantity"].HeaderText = "Mevcut Stok";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Arama hatası: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Stok girişi yap butonu
        private void btnStockIn_Click(object sender, EventArgs e)
        {
            // Ürün seçilmemiş kontrolü
            if (_selectedProduct == null)
            {
                MessageBox.Show("Lütfen listeden bir ürün seçin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Miktar kontrolü
            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir miktar girin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Business katmanında stok girişi yap
                _stockService.StockIn(_selectedProduct.Id, quantity);

                MessageBox.Show(
                    $"'{_selectedProduct.Name}' ürününe {quantity} adet stok girişi yapıldı.",
                    "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ekranı güncelle
                _selectedProduct = null;
                txtSelectedProduct.Clear();
                txtCurrentStock.Clear();
                txtQuantity.Clear();

                LoadProducts();  // Güncel stok miktarı gösterilsin
                LoadMovements(); // Yeni hareket listeye eklensin
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Enter tuşu ile arama
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(null, null);
        }
    }
}
