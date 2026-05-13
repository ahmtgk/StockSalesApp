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

            // Seçilen ürünün hareketlerini yükle
            LoadMovementsByProduct(_selectedProduct.Id);
        }

        // Belirli ürünün hareketlerini yükler
        private void LoadMovementsByProduct(int productId)
        {
            try
            {
                dgvMovements.DataSource = null;
                dgvMovements.DataSource = _stockService.GetByProductId(productId);

                if (dgvMovements.Columns.Count > 0)
                {
                    dgvMovements.Columns["Id"].Visible = false;
                    dgvMovements.Columns["ProductId"].Visible = false;
                    dgvMovements.Columns["ProductName"].Visible = false;
                    dgvMovements.Columns["Quantity"].HeaderText = "Miktar";
                    dgvMovements.Columns["MovementType"].HeaderText = "Tür";
                    dgvMovements.Columns["MovementDate"].HeaderText = "Tarih";

                    // IN yeşil, OUT kırmızı göster
                    foreach (DataGridViewRow r in dgvMovements.Rows)
                    {
                        string type = r.Cells["MovementType"].Value.ToString();
                        r.DefaultCellStyle.BackColor = type == "IN"
                            ? System.Drawing.Color.FromArgb(200, 240, 200)
                            : System.Drawing.Color.FromArgb(255, 200, 200);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hareketler yüklenirken hata: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                LoadProducts();
                if (_selectedProduct != null)
                    LoadMovementsByProduct(_selectedProduct.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnStockOut_Click(object sender, EventArgs e)
        {
            if (_selectedProduct == null)
            {
                MessageBox.Show("Lütfen listeden bir ürün seçin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir miktar girin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Onay al — stok çıkışı geri alınamaz
            var result = MessageBox.Show(
                $"'{_selectedProduct.Name}' ürününden {quantity} adet stok çıkışı yapılacak. Onaylıyor musunuz?",
                "Stok Çıkışı Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            try
            {
                _stockService.StockOut(_selectedProduct.Id, quantity);

                MessageBox.Show(
                    $"'{_selectedProduct.Name}' ürününden {quantity} adet stok çıkışı yapıldı.",
                    "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _selectedProduct = null;
                txtSelectedProduct.Clear();
                txtCurrentStock.Clear();
                txtQuantity.Clear();

                LoadProducts();
                if (_selectedProduct != null)
                    LoadMovementsByProduct(_selectedProduct.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Enter tuşu ile arama
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(null, null);
        }
    }
}
