using StockSalesApp.Business;
using StockSalesApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace StockSalesApp.UI
{
    public partial class frmProductDetail : Form
    {
        private readonly ProductService _productService = new ProductService();
        // Düzenlenecek ürün — null ise yeni ürün ekleme modu
        // null değilse güncelleme modu
        private readonly Product _product;

        public frmProductDetail(Product product)
        {
            InitializeComponent();
            _product = product;
        }

        private void frmProductDetail_Load(object sender, EventArgs e)
        {
            if (_product == null)
            {
                // Yeni ürün modu
                this.Text = "Yeni Ürün Ekle";
            }
            else
            {
                // Güncelleme modu — mevcut bilgileri kutulara doldur
                this.Text = "Ürün Güncelle";
                txtName.Text = _product.Name;
                txtBarcode.Text = _product.Barcode;
                txtPurchasePrice.Text = _product.PurchasePrice.ToString();
                txtSalePrice.Text = _product.SalePrice.ToString();
                txtStockQuantity.Text = _product.StockQuantity.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Boş alan kontrolleri
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Ürün adı boş olamaz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtBarcode.Text))
            {
                MessageBox.Show("Barkod boş olamaz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Sayısal alanları parse et — hatalı giriş varsa kullanıcıya bildir
            if (!decimal.TryParse(txtPurchasePrice.Text, out decimal purchasePrice))
            {
                MessageBox.Show("Alış fiyatı geçerli bir sayı olmalıdır.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtSalePrice.Text, out decimal salePrice))
            {
                MessageBox.Show("Satış fiyatı geçerli bir sayı olmalıdır.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtStockQuantity.Text, out int stockQty))
            {
                MessageBox.Show("Stok miktarı geçerli bir tam sayı olmalıdır.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_product == null)
                {
                    // Yeni ürün ekle
                    var newProduct = new Product
                    {
                        Name = txtName.Text.Trim(),
                        Barcode = txtBarcode.Text.Trim(),
                        PurchasePrice = purchasePrice,
                        SalePrice = salePrice,
                        StockQuantity = stockQty
                    };
                    _productService.Add(newProduct);
                    MessageBox.Show("Ürün başarıyla eklendi.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Mevcut ürünü güncelle
                    _product.Name = txtName.Text.Trim();
                    _product.Barcode = txtBarcode.Text.Trim();
                    _product.PurchasePrice = purchasePrice;
                    _product.SalePrice = salePrice;
                    // Stok miktarı burada güncellenmez
                    // Stok sadece Stok Girişi ekranından değiştirilir
                    _productService.Update(_product);
                    MessageBox.Show("Ürün başarıyla güncellendi.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close(); // Kaydedince formu kapat, frmProducts'a dön
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
