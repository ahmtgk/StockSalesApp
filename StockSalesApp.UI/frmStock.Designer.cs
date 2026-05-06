namespace StockSalesApp.UI
{
    partial class frmStock
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
            btnSearch = new Button();
            dgvProducts = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtSelectedProduct = new TextBox();
            txtCurrentStock = new TextBox();
            txtQuantity = new TextBox();
            btnStockIn = new Button();
            btnClose = new Button();
            label5 = new Label();
            dgvMovements = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMovements).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "Ürün Ara";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(90, 17);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 23);
            txtSearch.TabIndex = 1;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(300, 16);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 25);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Ara";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(20, 55);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
            dgvProducts.Size = new Size(500, 300);
            dgvProducts.TabIndex = 3;
            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 375);
            label2.Name = "label2";
            label2.Size = new Size(76, 15);
            label2.TabIndex = 4;
            label2.Text = "Seçilen Ürün:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 410);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 5;
            label3.Text = "Mevcut Stok:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 445);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 6;
            label4.Text = "Giriş Miktarı;";
            // 
            // txtSelectedProduct
            // 
            txtSelectedProduct.Location = new Point(130, 372);
            txtSelectedProduct.Name = "txtSelectedProduct";
            txtSelectedProduct.ReadOnly = true;
            txtSelectedProduct.Size = new Size(250, 23);
            txtSelectedProduct.TabIndex = 7;
            // 
            // txtCurrentStock
            // 
            txtCurrentStock.Location = new Point(130, 407);
            txtCurrentStock.Name = "txtCurrentStock";
            txtCurrentStock.ReadOnly = true;
            txtCurrentStock.Size = new Size(100, 23);
            txtCurrentStock.TabIndex = 8;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(130, 442);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(100, 23);
            txtQuantity.TabIndex = 9;
            // 
            // btnStockIn
            // 
            btnStockIn.Location = new Point(250, 438);
            btnStockIn.Name = "btnStockIn";
            btnStockIn.Size = new Size(150, 35);
            btnStockIn.TabIndex = 10;
            btnStockIn.Text = "Stok Girişi Yap";
            btnStockIn.UseVisualStyleBackColor = true;
            btnStockIn.Click += btnStockIn_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(650, 480);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(110, 35);
            btnClose.TabIndex = 11;
            btnClose.Text = "Kapat";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label5.Location = new Point(540, 55);
            label5.Name = "label5";
            label5.Size = new Size(124, 15);
            label5.TabIndex = 12;
            label5.Text = "Son Stok Hareketleri";
            // 
            // dgvMovements
            // 
            dgvMovements.AllowUserToAddRows = false;
            dgvMovements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMovements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovements.Location = new Point(540, 80);
            dgvMovements.Name = "dgvMovements";
            dgvMovements.ReadOnly = true;
            dgvMovements.Size = new Size(230, 275);
            dgvMovements.TabIndex = 13;
            // 
            // frmStock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 511);
            Controls.Add(dgvMovements);
            Controls.Add(label5);
            Controls.Add(btnClose);
            Controls.Add(btnStockIn);
            Controls.Add(txtQuantity);
            Controls.Add(txtCurrentStock);
            Controls.Add(txtSelectedProduct);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dgvProducts);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmStock";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stok Girişi";
            Load += frmStock_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMovements).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvProducts;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtSelectedProduct;
        private TextBox txtCurrentStock;
        private TextBox txtQuantity;
        private Button btnStockIn;
        private Button btnClose;
        private Label label5;
        private DataGridView dgvMovements;
    }
}