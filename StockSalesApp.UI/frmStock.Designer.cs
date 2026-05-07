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
            label5 = new Label();
            dgvMovements = new DataGridView();
            panel1 = new Panel();
            btnStockOut = new Button();
            panel2 = new Panel();
            close = new Button();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMovements).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.Location = new Point(13, 28);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 0;
            label1.Text = "Ürün Ara";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtSearch.Location = new Point(86, 25);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(359, 27);
            txtSearch.TabIndex = 1;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(116, 142, 191);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(464, 22);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(167, 33);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Ara";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(13, 97);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(827, 300);
            dgvProducts.TabIndex = 3;
            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F);
            label2.Location = new Point(13, 27);
            label2.Name = "label2";
            label2.Size = new Size(94, 20);
            label2.TabIndex = 4;
            label2.Text = "Seçilen Ürün:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F);
            label3.Location = new Point(13, 82);
            label3.Name = "label3";
            label3.Size = new Size(93, 20);
            label3.TabIndex = 5;
            label3.Text = "Mevcut Stok:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F);
            label4.Location = new Point(13, 132);
            label4.Name = "label4";
            label4.Size = new Size(91, 20);
            label4.TabIndex = 6;
            label4.Text = "Stok Miktarı;";
            // 
            // txtSelectedProduct
            // 
            txtSelectedProduct.BackColor = Color.White;
            txtSelectedProduct.Font = new Font("Segoe UI", 11.25F);
            txtSelectedProduct.Location = new Point(113, 24);
            txtSelectedProduct.Name = "txtSelectedProduct";
            txtSelectedProduct.ReadOnly = true;
            txtSelectedProduct.Size = new Size(244, 27);
            txtSelectedProduct.TabIndex = 7;
            // 
            // txtCurrentStock
            // 
            txtCurrentStock.BackColor = Color.White;
            txtCurrentStock.Font = new Font("Segoe UI", 11.25F);
            txtCurrentStock.Location = new Point(113, 79);
            txtCurrentStock.Name = "txtCurrentStock";
            txtCurrentStock.ReadOnly = true;
            txtCurrentStock.Size = new Size(162, 27);
            txtCurrentStock.TabIndex = 8;
            // 
            // txtQuantity
            // 
            txtQuantity.Font = new Font("Segoe UI", 11.25F);
            txtQuantity.Location = new Point(113, 129);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(162, 27);
            txtQuantity.TabIndex = 9;
            // 
            // btnStockIn
            // 
            btnStockIn.BackColor = Color.FromArgb(116, 142, 191);
            btnStockIn.FlatAppearance.BorderSize = 0;
            btnStockIn.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnStockIn.FlatStyle = FlatStyle.Flat;
            btnStockIn.Font = new Font("Segoe UI", 11.25F);
            btnStockIn.ForeColor = Color.White;
            btnStockIn.Location = new Point(13, 197);
            btnStockIn.Name = "btnStockIn";
            btnStockIn.Size = new Size(150, 51);
            btnStockIn.TabIndex = 10;
            btnStockIn.Text = "Stok Girişi Yap";
            btnStockIn.UseVisualStyleBackColor = false;
            btnStockIn.Click += btnStockIn_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label5.Location = new Point(387, 11);
            label5.Name = "label5";
            label5.Size = new Size(166, 21);
            label5.TabIndex = 12;
            label5.Text = "Son Stok Hareketleri";
            // 
            // dgvMovements
            // 
            dgvMovements.AllowUserToAddRows = false;
            dgvMovements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMovements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovements.Location = new Point(387, 35);
            dgvMovements.Name = "dgvMovements";
            dgvMovements.ReadOnly = true;
            dgvMovements.Size = new Size(453, 251);
            dgvMovements.TabIndex = 13;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(dgvProducts);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(btnSearch);
            panel1.Location = new Point(12, 49);
            panel1.Name = "panel1";
            panel1.Size = new Size(856, 413);
            panel1.TabIndex = 14;
            // 
            // btnStockOut
            // 
            btnStockOut.BackColor = Color.FromArgb(200, 80, 60);
            btnStockOut.FlatAppearance.BorderSize = 0;
            btnStockOut.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 100, 80);
            btnStockOut.FlatStyle = FlatStyle.Flat;
            btnStockOut.Font = new Font("Segoe UI", 11.25F);
            btnStockOut.ForeColor = Color.White;
            btnStockOut.Location = new Point(207, 197);
            btnStockOut.Name = "btnStockOut";
            btnStockOut.Size = new Size(150, 51);
            btnStockOut.TabIndex = 15;
            btnStockOut.Text = "Stok Çıkışı Yap";
            btnStockOut.UseVisualStyleBackColor = false;
            btnStockOut.Click += btnStockOut_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(btnStockOut);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(dgvMovements);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtSelectedProduct);
            panel2.Controls.Add(txtQuantity);
            panel2.Controls.Add(btnStockIn);
            panel2.Controls.Add(txtCurrentStock);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(12, 485);
            panel2.Name = "panel2";
            panel2.Size = new Size(856, 303);
            panel2.TabIndex = 16;
            // 
            // close
            // 
            close.BackColor = Color.Firebrick;
            close.FlatAppearance.BorderColor = Color.Black;
            close.FlatStyle = FlatStyle.Flat;
            close.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            close.ForeColor = Color.White;
            close.Location = new Point(829, 15);
            close.Name = "close";
            close.Size = new Size(39, 28);
            close.TabIndex = 17;
            close.Text = "X";
            close.UseVisualStyleBackColor = false;
            close.Click += close_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label6.Location = new Point(12, 15);
            label6.Name = "label6";
            label6.Size = new Size(136, 25);
            label6.TabIndex = 18;
            label6.Text = "Stok Yönetimi";
            // 
            // frmStock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 801);
            Controls.Add(label6);
            Controls.Add(close);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "frmStock";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stok Girişi";
            Load += frmStock_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMovements).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private Label label5;
        private DataGridView dgvMovements;
        private Panel panel1;
        private Button btnStockOut;
        private Panel panel2;
        private Button close;
        private Label label6;
    }
}