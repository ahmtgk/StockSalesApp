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
    public partial class frmSale : Form
    {
        private readonly SaleService _saleService = new SaleService();
        private readonly ProductService _productService = new ProductService();
        private readonly User _currentUser;
        // Form kapanana kadar bellekte tutulur, satış tamamlanınca veritabanına yazılır
        private readonly List<SaleDetail> _cart = new List<SaleDetail>();

        public frmSale(User user)
        {
            InitializeComponent();
            _currentUser = user;
        }

        private void frmSale_Load(object sender, EventArgs e)
        {
            LoadProducts();
            RefreshCart();
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
                    dgvProducts.Columns["PurchasePrice"].Visible = false;
                    dgvProducts.Columns["Name"].HeaderText = "Ürün Adı";
                    dgvProducts.Columns["Barcode"].HeaderText = "Barkod";
                    dgvProducts.Columns["SalePrice"].HeaderText = "Fiyat";
                    dgvProducts.Columns["StockQuantity"].HeaderText = "Stok";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünler yüklenirken hata: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Arama butonu — barkod veya isimle ara
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // Önce barkodla tam eşleşme dene
                var byBarcode = _productService.GetByBarcode(txtSearch.Text.Trim());
                if (byBarcode != null)
                {
                    // Barkod bulundu — direkt sepete ekle, adet 1
                    AddToCart(byBarcode, 1);
                    txtSearch.Clear();
                    return;
                }
            }
            catch { }

            // Barkodla bulunamazsa isimle ara
            try
            {
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = _productService.Search(txtSearch.Text);

                if (dgvProducts.Columns.Count > 0)
                {
                    dgvProducts.Columns["Id"].Visible = false;
                    dgvProducts.Columns["PurchasePrice"].Visible = false;
                    dgvProducts.Columns["Name"].HeaderText = "Ürün Adı";
                    dgvProducts.Columns["Barcode"].HeaderText = "Barkod";
                    dgvProducts.Columns["SalePrice"].HeaderText = "Fiyat";
                    dgvProducts.Columns["StockQuantity"].HeaderText = "Stok";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Arama hatası: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sepete Ekle butonu
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen listeden bir ürün seçin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir adet girin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvProducts.SelectedRows[0];
            var product = new Product
            {
                Id = (int)row.Cells["Id"].Value,
                Name = row.Cells["Name"].Value.ToString(),
                SalePrice = (decimal)row.Cells["SalePrice"].Value,
                StockQuantity = (int)row.Cells["StockQuantity"].Value
            };

            AddToCart(product, quantity);
            txtQuantity.Clear();
        }

        // Ürünü sepete ekleyen yardımcı metot
        // Hem butondan hem barkod okutunca çağrılır
        private void AddToCart(Product product, int quantity)
        {
            // Stok yeterli mi kontrol et
            if (quantity > product.StockQuantity)
            {
                MessageBox.Show(
                    $"Yetersiz stok. Mevcut stok: {product.StockQuantity}",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ürün sepette zaten var mı kontrol et
            var existing = _cart.Find(c => c.ProductId == product.Id);
            if (existing != null)
            {
                // Varsa adetini artır
                int newQty = existing.Quantity + quantity;
                if (newQty > product.StockQuantity)
                {
                    MessageBox.Show(
                        $"Toplam adet stok miktarını aşıyor. Mevcut stok: {product.StockQuantity}",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                existing.Quantity = newQty;
                existing.TotalPrice = existing.UnitPrice * newQty;
            }
            else
            {
                // Yoksa yeni satır ekle
                _cart.Add(new SaleDetail
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Quantity = quantity,
                    UnitPrice = product.SalePrice,
                    TotalPrice = product.SalePrice * quantity
                });
            }

            RefreshCart();
        }

        // Sepet DataGridView'ini günceller
        private void RefreshCart()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = new System.ComponentModel.BindingList<SaleDetail>(_cart);

            if (dgvCart.Columns.Count > 0)
            {
                dgvCart.Columns["Id"].Visible = false;
                dgvCart.Columns["SaleId"].Visible = false;
                dgvCart.Columns["ProductId"].Visible = false;
                dgvCart.Columns["ProductName"].HeaderText = "Ürün";
                dgvCart.Columns["Quantity"].HeaderText = "Adet";
                dgvCart.Columns["UnitPrice"].HeaderText = "Birim Fiyat";
                dgvCart.Columns["TotalPrice"].HeaderText = "Toplam";
            }

            // Toplam tutarı hesapla ve göster
            decimal total = 0;
            foreach (var item in _cart)
                total += item.TotalPrice;

            lblTotal.Text = total.ToString("N2") + " ₺";
        }

        // Sepetten ürün sil
        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen sepetten silinecek ürünü seçin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productId = (int)dgvCart.SelectedRows[0].Cells["ProductId"].Value;
            _cart.RemoveAll(c => c.ProductId == productId);
            RefreshCart();
        }

        // Sepeti tamamen temizle
        private void btnClearCart_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0) return;

            var result = MessageBox.Show("Sepeti temizlemek istediğinize emin misiniz?",
                "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _cart.Clear();
                RefreshCart();
            }
        }

        // Satışı tamamla
        private void btnCompleteSale_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0)
            {
                MessageBox.Show("Sepet boş. Lütfen ürün ekleyin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Toplam tutarı hesapla
            decimal total = 0;
            foreach (var item in _cart)
                total += item.TotalPrice;

            // Onay al
            var result = MessageBox.Show(
                $"Toplam {total:N2} ₺ tutarında satış tamamlanacak. Onaylıyor musunuz?",
                "Satış Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            try
            {
                // Sale nesnesini oluştur
                var sale = new Sale
                {
                    UserId = _currentUser.Id,
                    TotalAmount = total
                };

                // Business katmanına gönder — transaction orada yönetiliyor
                _saleService.CompleteSale(sale, _cart);

                MessageBox.Show(
                    $"Satış başarıyla tamamlandı!\nToplam Tutar: {total:N2} ₺",
                    "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Sepeti temizle, listeyi yenile
                _cart.Clear();
                LoadProducts(); // Stok miktarları güncellensin
                RefreshCart();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Satış sırasında hata: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Enter tuşu ile arama veya sepete ekleme
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(null, null);
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAddToCart_Click(null, null);
        }
    }
}
