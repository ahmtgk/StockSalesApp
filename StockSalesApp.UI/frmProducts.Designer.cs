namespace StockSalesApp.UI
{
    partial class frmProducts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtSearch = new TextBox();
            btnListAll = new Button();
            dgvProducts = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnClose = new Button();
            btnSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 0;
            label1.Text = "Ürün Ara:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(90, 17);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 23);
            txtSearch.TabIndex = 1;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // btnListAll
            // 
            btnListAll.Location = new Point(385, 16);
            btnListAll.Name = "btnListAll";
            btnListAll.Size = new Size(110, 25);
            btnListAll.TabIndex = 2;
            btnListAll.Text = "Tümünü Listele";
            btnListAll.UseVisualStyleBackColor = true;
            btnListAll.Click += btnListAll_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(20, 55);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(640, 480);
            dgvProducts.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(680, 55);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(180, 40);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Yeni Ürün Ekle";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(680, 105);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(180, 40);
            btnEdit.TabIndex = 5;
            btnEdit.Text = "Güncelle";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(680, 155);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(180, 40);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Sil";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(680, 520);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(180, 40);
            btnClose.TabIndex = 7;
            btnClose.Text = "Kapat";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(300, 16);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 25);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "Ara";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // frmProducts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1184, 861);
            Controls.Add(btnSearch);
            Controls.Add(btnClose);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dgvProducts);
            Controls.Add(btnListAll);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "frmProducts";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ürün Yönetimi";
            Load += frmProducts_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSearch;
        private Button btnListAll;
        private DataGridView dgvProducts;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnClose;
        private Button btnSearch;
    }
}