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
    public partial class frmProducts : Form
    {
        private readonly ProductService _productService = new ProductService();

        public frmProducts()
        {
            InitializeComponent();
        }

        // Form açılınca tüm ürünleri yükle
        private void frmProducts_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        // Ürünleri DataGridView'e yükler
        private void LoadProducts()
        {
            try
            {
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = _productService.GetAll();

                // Sütun başlıklarını Türkçe yap
                if (dgvProducts.Columns.Count > 0)
                {
                    dgvProducts.Columns["Id"].HeaderText = "ID";
                    dgvProducts.Columns["Name"].HeaderText = "Ürün Adı";
                    dgvProducts.Columns["Barcode"].HeaderText = "Barkod";
                    dgvProducts.Columns["PurchasePrice"].HeaderText = "Alış Fiyatı";
                    dgvProducts.Columns["SalePrice"].HeaderText = "Satış Fiyatı";
                    dgvProducts.Columns["StockQuantity"].HeaderText = "Stok";

                    // ID sütununu gizle — kullanıcının görmesine gerek yok
                    dgvProducts.Columns["Id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünler yüklenirken hata: " + ex.Message,
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
                    dgvProducts.Columns["Name"].HeaderText = "Ürün Adı";
                    dgvProducts.Columns["Barcode"].HeaderText = "Barkod";
                    dgvProducts.Columns["PurchasePrice"].HeaderText = "Alış Fiyatı";
                    dgvProducts.Columns["SalePrice"].HeaderText = "Satış Fiyatı";
                    dgvProducts.Columns["StockQuantity"].HeaderText = "Stok";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Arama sırasında hata: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tümünü listele butonu
        private void btnListAll_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadProducts();
        }

        // Yeni ürün ekle butonu
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Ürün ekleme/düzenleme için ayrı bir form açıyoruz
            // null gönderiyoruz çünkü yeni ürün — düzenlenecek ürün yok
            var form = new frmProductDetail(null);
            form.ShowDialog();
            LoadProducts(); // Form kapanınca listeyi yenile
        }

        // Güncelle butonu
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Listede seçili satır var mı kontrol et
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellenecek ürünü seçin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Seçili satırdan ürün bilgilerini al
            var row = dgvProducts.SelectedRows[0];
            var product = new Product
            {
                // DataGridView'deki değerleri Product nesnesine aktar
                Id = (int)row.Cells["Id"].Value,
                Name = row.Cells["Name"].Value.ToString(),
                Barcode = row.Cells["Barcode"].Value.ToString(),
                PurchasePrice = (decimal)row.Cells["PurchasePrice"].Value,
                SalePrice = (decimal)row.Cells["SalePrice"].Value,
                StockQuantity = (int)row.Cells["StockQuantity"].Value
            };

            // Mevcut ürünü gönderiyoruz — form düzenleme modunda açılır
            var form = new frmProductDetail(product);
            form.ShowDialog();
            LoadProducts();
        }

        // Sil butonu
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek ürünü seçin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvProducts.SelectedRows[0];
            string productName = row.Cells["Name"].Value.ToString();

            // Silmeden önce onay al
            var result = MessageBox.Show(
                $"'{productName}' ürününü silmek istediğinize emin misiniz?",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int id = (int)row.Cells["Id"].Value;
                    _productService.Delete(id);
                    MessageBox.Show("Ürün başarıyla silindi.",
                        "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Silme sırasında hata: " + ex.Message,
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Kapat butonu
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Enter tuşu ile arama yapsın
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(null, null);
        }
    }
}