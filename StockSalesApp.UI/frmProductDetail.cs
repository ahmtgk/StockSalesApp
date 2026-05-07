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
                this.Text = "Yeni Ürün Ekle";
                txtStockQuantity.Text = "0"; // Yeni ürün için başlangıç stok 0
            }
            else
            {
                this.Text = "Ürün Güncelle";
                txtName.Text = _product.Name;
                txtBarcode.Text = _product.Barcode;
                txtPurchasePrice.Text = _product.PurchasePrice.ToString();
                txtSalePrice.Text = _product.SalePrice.ToString();
                txtStockQuantity.Text = _product.StockQuantity.ToString();

                // Güncelleme modunda stok değiştirilemez
                // Stok sadece Stok Girişi/Çıkışı ekranından değiştirilir
                txtStockQuantity.ReadOnly = true;
                txtStockQuantity.BackColor = System.Drawing.SystemColors.Control;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
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

            try
            {
                if (_product == null)
                {
                    // Yeni ürün modunda stok girilebilir
                    if (!int.TryParse(txtStockQuantity.Text, out int stockQty) || stockQty < 0)
                    {
                        MessageBox.Show("Stok miktarı geçerli bir sayı olmalıdır.", "Uyarı",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

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
                    // Güncelleme modunda stok değişmez — mevcut değer korunur
                    _product.Name = txtName.Text.Trim();
                    _product.Barcode = txtBarcode.Text.Trim();
                    _product.PurchasePrice = purchasePrice;
                    _product.SalePrice = salePrice;
                    // _product.StockQuantity değiştirilmiyor
                    _productService.Update(_product);
                    MessageBox.Show("Ürün başarıyla güncellendi.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();
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
