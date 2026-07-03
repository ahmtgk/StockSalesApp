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

        private void frmProducts_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchProducts();
        }

        private void btnListAll_Click(object sender, EventArgs e)
        {
            ClearSearchAndReload();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenAddForm();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OpenEditForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedProduct();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SearchProducts();
        }

        // PRIVATE METODLAR

        // Sadece ürünleri yükler ve grid'e bağlar
        private void LoadProducts()
        {
            try
            {
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = _productService.GetAll();
                SetColumnHeaders();
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
                SetColumnHeaders();
            }
            catch (Exception ex)
            {
                ShowError("Arama sırasında hata: " + ex.Message);
            }
        }

        // Sadece aramayı temizler ve listeyi yeniler
        private void ClearSearchAndReload()
        {
            txtSearch.Clear();
            LoadProducts();
        }

        // Sadece ekleme formunu açar
        private void OpenAddForm()
        {
            new frmProductDetail(null).ShowDialog();
            LoadProducts();
        }

        // Sadece düzenleme formunu açar
        private void OpenEditForm()
        {
            if (!IsRowSelected("güncellenecek")) return;
            var product = GetSelectedProduct();
            new frmProductDetail(product).ShowDialog();
            LoadProducts();
        }

        // Sadece silme işlemini yönetir
        private void DeleteSelectedProduct()
        {
            if (!IsRowSelected("silinecek")) return;
            if (!ConfirmDeletion()) return;

            try
            {
                int id = GetSelectedId();
                _productService.Delete(id);
                ShowInfo("Ürün başarıyla silindi.");
                LoadProducts();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        // Sadece sütun başlıklarını ayarlar
        private void SetColumnHeaders()
        {
            if (dgvProducts.Columns.Count == 0) return;

            dgvProducts.Columns["Id"].Visible = false;
            dgvProducts.Columns["Name"].HeaderText = "Ürün Adı";
            dgvProducts.Columns["Barcode"].HeaderText = "Barkod";
            dgvProducts.Columns["PurchasePrice"].HeaderText = "Alış Fiyatı";
            dgvProducts.Columns["SalePrice"].HeaderText = "Satış Fiyatı";
            dgvProducts.Columns["StockQuantity"].HeaderText = "Stok";
        }

        // Sadece seçili satırdan Product nesnesi oluşturur
        private Product GetSelectedProduct()
        {
            var row = dgvProducts.SelectedRows[0];
            return new Product
            {
                Id = (int)row.Cells["Id"].Value,
                Name = row.Cells["Name"].Value.ToString(),
                Barcode = row.Cells["Barcode"].Value.ToString(),
                PurchasePrice = (decimal)row.Cells["PurchasePrice"].Value,
                SalePrice = (decimal)row.Cells["SalePrice"].Value,
                StockQuantity = (int)row.Cells["StockQuantity"].Value
            };
        }

        // Sadece seçili satırın ID'sini döndürür
        private int GetSelectedId()
        {
            return (int)dgvProducts.SelectedRows[0].Cells["Id"].Value;
        }

        // Sadece satır seçili mi kontrol eder
        private bool IsRowSelected(string action)
        {
            if (dgvProducts.SelectedRows.Count > 0) return true;
            ShowWarning($"Lütfen {action} ürünü seçin.");
            return false;
        }

        // Sadece silme onayı alır
        private bool ConfirmDeletion()
        {
            string name = dgvProducts.SelectedRows[0].Cells["Name"].Value.ToString();
            return MessageBox.Show(
                $"'{name}' ürününü silmek istediğinize emin misiniz?",
                "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes;
        }

        // Mesaj metodları — tek yerden yönetim
        private void ShowError(string msg) =>
            MessageBox.Show(msg, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void ShowWarning(string msg) =>
            MessageBox.Show(msg, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void ShowInfo(string msg) =>
            MessageBox.Show(msg, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}