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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchProduct();
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            AddSelectedProductToCart();
        }

        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            RemoveFromCart();
        }

        private void btnReduceFromCart_Click(object sender, EventArgs e)
        {
            ReduceCartItem();
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            ClearCart();
        }

        private void btnCompleteSale_Click(object sender, EventArgs e)
        {
            CompleteSale();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SearchProduct();
        }

        private void nudQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) AddSelectedProductToCart();
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

        // Sadece ürün arama işlemini yapar
        private void SearchProduct()
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text)) return;

            if (TrySearchByBarcode()) return;
            SearchByName();
        }

        // Sadece barkodla arama dener — bulursa true döner
        private bool TrySearchByBarcode()
        {
            try
            {
                var product = _productService.GetByBarcode(txtSearch.Text.Trim());
                if (product == null) return false;

                AddToCart(product, 1);
                txtSearch.Clear();
                FocusProductInGrid(product.Id);
                return true;
            }
            catch { return false; }
        }

        // Sadece isme göre arama yapar
        private void SearchByName()
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

        // Sadece grid'de ürünü seçer ve odaklanır
        private void FocusProductInGrid(int productId)
        {
            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                if (row.Cells["Id"].Value != null &&
                    (int)row.Cells["Id"].Value == productId)
                {
                    dgvProducts.ClearSelection();
                    row.Selected = true;
                    dgvProducts.CurrentCell = row.Cells["Name"];
                    dgvProducts.Focus();
                    break;
                }
            }
        }

        // Sadece listeden seçili ürünü sepete ekler
        private void AddSelectedProductToCart()
        {
            if (!IsProductSelected()) return;

            int quantity = (int)nudQuantity.Value;
            var product = GetSelectedProduct();
            AddToCart(product, quantity);
            nudQuantity.Value = 1;
        }

        // Sadece ürünü sepete ekler — hem listeden hem barkoddan çağrılır
        private void AddToCart(Product product, int quantity)
        {
            if (!IsStockSufficient(product, quantity)) return;

            var existing = _cart.Find(c => c.ProductId == product.Id);
            if (existing != null)
                UpdateExistingCartItem(existing, product, quantity);
            else
                AddNewCartItem(product, quantity);

            RefreshCart();
        }

        // Sadece stok yeterliliğini kontrol eder
        private bool IsStockSufficient(Product product, int quantity)
        {
            if (quantity <= product.StockQuantity) return true;
            ShowWarning($"Yetersiz stok. Mevcut stok: {product.StockQuantity}");
            return false;
        }

        // Sadece sepetteki mevcut kalemi günceller
        private void UpdateExistingCartItem(SaleDetail existing, Product product, int quantity)
        {
            int newQty = existing.Quantity + quantity;
            if (newQty > product.StockQuantity)
            {
                ShowWarning($"Toplam adet stoku aşıyor. Mevcut stok: {product.StockQuantity}");
                return;
            }
            existing.Quantity = newQty;
            existing.TotalPrice = existing.UnitPrice * newQty;
        }

        // Sadece sepete yeni kalem ekler
        private void AddNewCartItem(Product product, int quantity)
        {
            _cart.Add(new SaleDetail
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Quantity = quantity,
                UnitPrice = product.SalePrice,
                TotalPrice = product.SalePrice * quantity
            });
        }

        // Sadece sepetten ürünü tamamen siler
        private void RemoveFromCart()
        {
            if (!IsCartRowSelected()) return;
            int productId = GetSelectedCartProductId();
            _cart.RemoveAll(c => c.ProductId == productId);
            RefreshCart();
        }

        // Sadece sepetteki ürün adetini azaltır
        private void ReduceCartItem()
        {
            if (!IsCartRowSelected()) return;

            int productId = GetSelectedCartProductId();
            string prodName = dgvCart.SelectedRows[0].Cells["ProductName"].Value.ToString();
            int reduceQty = (int)nudQuantity.Value;
            var existing = _cart.Find(c => c.ProductId == productId);
            if (existing == null) return;

            if (reduceQty >= existing.Quantity)
            {
                if (!ConfirmFullRemoval(prodName, existing.Quantity)) return;
                _cart.RemoveAll(c => c.ProductId == productId);
            }
            else
            {
                existing.Quantity -= reduceQty;
                existing.TotalPrice = existing.UnitPrice * existing.Quantity;
            }

            RefreshCart();
            nudQuantity.Value = 1;
        }

        // Sadece sepeti temizler
        private void ClearCart()
        {
            if (_cart.Count == 0) return;
            if (!ConfirmClearCart()) return;
            _cart.Clear();
            RefreshCart();
        }

        private void CompleteSale()
        {
            if (!IsCartNotEmpty()) return;
            decimal total = CalculateTotal();

            // Ödeme formunu aç
            var paymentForm = new frmPayment(total);
            if (paymentForm.ShowDialog() != DialogResult.OK) return;

            // Onaylanmış ödeme bilgisini al
            PaymentInfo payment = paymentForm.ConfirmedPayment;

            try
            {
                var sale = BuildSaleObject(total);
                _saleService.CompleteSale(sale, _cart, payment);

                ShowInfo($"Satış başarıyla tamamlandı!\nToplam: {total:N2} ₺");

                // Fiş PDF'ini otomatik aç
                OpenReceipt(payment);

                ResetAfterSale();
            }
            catch (Exception ex)
            {
                ShowError("Satış sırasında hata: " + ex.Message);
            }
        }

        // Sadece fiş PDF'ini açar
        private void OpenReceipt(PaymentInfo payment)
        {
            try
            {
                // En son oluşturulan fişi bul
                string folder = System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "StockSalesApp", "Receipts");

                if (!System.IO.Directory.Exists(folder)) return;

                // Klasördeki en yeni PDF dosyasını al
                var files = System.IO.Directory.GetFiles(folder, "*.pdf");
                if (files.Length == 0) return;

                // En son değiştirilen dosyayı bul
                string latestReceipt = files[0];
                foreach (var file in files)
                {
                    if (System.IO.File.GetLastWriteTime(file) >
                        System.IO.File.GetLastWriteTime(latestReceipt))
                        latestReceipt = file;
                }

                // PDF'i varsayılan uygulama ile aç
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = latestReceipt,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                ShowError("Fiş açılırken hata: " + ex.Message);
            }
        }

        // Sadece Sale nesnesini oluşturur
        private Sale BuildSaleObject(decimal total)
        {
            return new Sale
            {
                UserId = _currentUser.Id,
                TotalAmount = total
            };
        }

        // Sadece toplam tutarı hesaplar
        private decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var item in _cart) total += item.TotalPrice;
            return total;
        }

        // Sadece satış sonrası ekranı sıfırlar
        private void ResetAfterSale()
        {
            _cart.Clear();
            LoadProducts();
            RefreshCart();
        }

        // Sadece sepet görünümünü günceller
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

            lblTotal.Text = CalculateTotal().ToString("N2") + " ₺";
        }

        // Sadece ürün grid sütunlarını ayarlar
        private void SetProductColumns()
        {
            if (dgvProducts.Columns.Count == 0) return;
            dgvProducts.Columns["Id"].Visible = false;
            dgvProducts.Columns["PurchasePrice"].Visible = false;
            dgvProducts.Columns["Name"].HeaderText = "Ürün Adı";
            dgvProducts.Columns["Barcode"].HeaderText = "Barkod";
            dgvProducts.Columns["SalePrice"].HeaderText = "Fiyat";
            dgvProducts.Columns["StockQuantity"].HeaderText = "Stok";
        }

        // YARDIMCI KONTROL METODLARI

        private bool IsProductSelected()
        {
            if (dgvProducts.SelectedRows.Count > 0) return true;
            ShowWarning("Lütfen listeden bir ürün seçin.");
            return false;
        }

        private bool IsCartRowSelected()
        {
            if (dgvCart.SelectedRows.Count > 0) return true;
            ShowWarning("Lütfen sepetten bir ürün seçin.");
            return false;
        }

        private bool IsCartNotEmpty()
        {
            if (_cart.Count > 0) return true;
            ShowWarning("Sepet boş. Lütfen ürün ekleyin.");
            return false;
        }

        private int GetSelectedCartProductId() =>
            (int)dgvCart.SelectedRows[0].Cells["ProductId"].Value;

        private Product GetSelectedProduct()
        {
            var row = dgvProducts.SelectedRows[0];
            return new Product
            {
                Id = (int)row.Cells["Id"].Value,
                Name = row.Cells["Name"].Value.ToString(),
                SalePrice = (decimal)row.Cells["SalePrice"].Value,
                StockQuantity = (int)row.Cells["StockQuantity"].Value
            };
        }

        private bool ConfirmSale(decimal total) =>
            MessageBox.Show(
                $"Toplam {total:N2} ₺ tutarında satış tamamlanacak.\nOnaylıyor musunuz?",
                "Satış Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            == DialogResult.Yes;

        private bool ConfirmClearCart() =>
            MessageBox.Show("Sepeti temizlemek istediğinize emin misiniz?",
                "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            == DialogResult.Yes;

        private bool ConfirmFullRemoval(string name, int qty) =>
            MessageBox.Show(
                $"'{name}' ürününün tüm adeti ({qty}) sepetten çıkarılacak. Onaylıyor musunuz?",
                "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            == DialogResult.Yes;

        private void ShowError(string msg) =>
            MessageBox.Show(msg, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void ShowWarning(string msg) =>
            MessageBox.Show(msg, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void ShowInfo(string msg) =>
            MessageBox.Show(msg, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
