namespace StockSalesApp.UI
{
    partial class frmSale
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
            txtQuantity = new TextBox();
            btnAddToCart = new Button();
            label3 = new Label();
            dgvCart = new DataGridView();
            btnClearCart = new Button();
            btnRemoveFromCart = new Button();
            label4 = new Label();
            lblTotal = new Label();
            btnCompleteSale = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(105, 15);
            label1.TabIndex = 0;
            label1.Text = "Barkod / Ürün Ara:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(140, 17);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 23);
            txtSearch.TabIndex = 1;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(116, 142, 191);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 11.25F);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(350, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(120, 31);
            btnSearch.TabIndex = 11;
            btnSearch.Text = "Ara";
            btnSearch.UseVisualStyleBackColor = false;
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
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(450, 250);
            dgvProducts.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 320);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 13;
            label2.Text = "Adet:";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(65, 317);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(60, 23);
            txtQuantity.TabIndex = 14;
            txtQuantity.KeyDown += txtQuantity_KeyDown;
            // 
            // btnAddToCart
            // 
            btnAddToCart.BackColor = Color.FromArgb(116, 142, 191);
            btnAddToCart.FlatAppearance.BorderSize = 0;
            btnAddToCart.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnAddToCart.FlatStyle = FlatStyle.Flat;
            btnAddToCart.Font = new Font("Segoe UI", 11.25F);
            btnAddToCart.ForeColor = Color.White;
            btnAddToCart.Location = new Point(140, 315);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(120, 31);
            btnAddToCart.TabIndex = 15;
            btnAddToCart.Text = "Sepete Ekle";
            btnAddToCart.UseVisualStyleBackColor = false;
            btnAddToCart.Click += btnAddToCart_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(500, 20);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 16;
            label3.Text = "Sepet";
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(500, 45);
            dgvCart.MultiSelect = false;
            dgvCart.Name = "dgvCart";
            dgvCart.ReadOnly = true;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(470, 300);
            dgvCart.TabIndex = 17;
            // 
            // btnClearCart
            // 
            btnClearCart.BackColor = Color.FromArgb(116, 142, 191);
            btnClearCart.FlatAppearance.BorderSize = 0;
            btnClearCart.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnClearCart.FlatStyle = FlatStyle.Flat;
            btnClearCart.Font = new Font("Segoe UI", 11.25F);
            btnClearCart.ForeColor = Color.White;
            btnClearCart.Location = new Point(626, 355);
            btnClearCart.Name = "btnClearCart";
            btnClearCart.Size = new Size(120, 31);
            btnClearCart.TabIndex = 19;
            btnClearCart.Text = "Sepeti Temizle";
            btnClearCart.UseVisualStyleBackColor = false;
            btnClearCart.Click += btnClearCart_Click;
            // 
            // btnRemoveFromCart
            // 
            btnRemoveFromCart.BackColor = Color.FromArgb(200, 80, 60);
            btnRemoveFromCart.FlatAppearance.BorderSize = 0;
            btnRemoveFromCart.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 100, 80);
            btnRemoveFromCart.FlatStyle = FlatStyle.Flat;
            btnRemoveFromCart.Font = new Font("Segoe UI", 11.25F);
            btnRemoveFromCart.ForeColor = Color.White;
            btnRemoveFromCart.Location = new Point(500, 355);
            btnRemoveFromCart.Name = "btnRemoveFromCart";
            btnRemoveFromCart.Size = new Size(120, 31);
            btnRemoveFromCart.TabIndex = 20;
            btnRemoveFromCart.Text = "Sil";
            btnRemoveFromCart.UseVisualStyleBackColor = false;
            btnRemoveFromCart.Click += btnRemoveFromCart_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.Location = new Point(500, 410);
            label4.Name = "label4";
            label4.Size = new Size(82, 15);
            label4.TabIndex = 21;
            label4.Text = "Toplam Tutar:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblTotal.Location = new Point(620, 410);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(66, 25);
            lblTotal.TabIndex = 22;
            lblTotal.Text = "0,00 ₺";
            // 
            // btnCompleteSale
            // 
            btnCompleteSale.BackColor = Color.FromArgb(116, 142, 191);
            btnCompleteSale.FlatAppearance.BorderSize = 0;
            btnCompleteSale.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnCompleteSale.FlatStyle = FlatStyle.Flat;
            btnCompleteSale.Font = new Font("Segoe UI", 11.25F);
            btnCompleteSale.ForeColor = Color.White;
            btnCompleteSale.Location = new Point(500, 450);
            btnCompleteSale.Name = "btnCompleteSale";
            btnCompleteSale.Size = new Size(200, 50);
            btnCompleteSale.TabIndex = 23;
            btnCompleteSale.Text = "SATIŞ TAMAMLA";
            btnCompleteSale.UseVisualStyleBackColor = false;
            btnCompleteSale.Click += btnCompleteSale_Click;
            // 
            // frmSale
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1859, 1097);
            Controls.Add(btnCompleteSale);
            Controls.Add(lblTotal);
            Controls.Add(label4);
            Controls.Add(btnRemoveFromCart);
            Controls.Add(btnClearCart);
            Controls.Add(dgvCart);
            Controls.Add(label3);
            Controls.Add(btnAddToCart);
            Controls.Add(txtQuantity);
            Controls.Add(label2);
            Controls.Add(dgvProducts);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "frmSale";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Satış";
            Load += frmSale_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvProducts;
        private Label label2;
        private TextBox txtQuantity;
        private Button btnAddToCart;
        private Label label3;
        private DataGridView dgvCart;
        private Button btnClearCart;
        private Button btnRemoveFromCart;
        private Label label4;
        private Label lblTotal;
        private Button btnCompleteSale;
    }
}