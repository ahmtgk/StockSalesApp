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
            btnAddToCart = new Button();
            label3 = new Label();
            dgvCart = new DataGridView();
            btnClearCart = new Button();
            btnRemoveFromCart = new Button();
            label4 = new Label();
            lblTotal = new Label();
            btnCompleteSale = new Button();
            panel1 = new Panel();
            btnReduceFromCart = new Button();
            nudQuantity = new NumericUpDown();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(182, 25);
            label1.TabIndex = 0;
            label1.Text = "Barkod / Ürün Ara:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtSearch.Location = new Point(200, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(428, 27);
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
            btnSearch.Location = new Point(634, 18);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(129, 31);
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
            dgvProducts.Location = new Point(12, 58);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(751, 763);
            dgvProducts.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(13, 853);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 13;
            label2.Text = "Adet:";
            // 
            // btnAddToCart
            // 
            btnAddToCart.BackColor = Color.FromArgb(116, 142, 191);
            btnAddToCart.FlatAppearance.BorderSize = 0;
            btnAddToCart.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnAddToCart.FlatStyle = FlatStyle.Flat;
            btnAddToCart.Font = new Font("Segoe UI", 11.25F);
            btnAddToCart.ForeColor = Color.White;
            btnAddToCart.Location = new Point(372, 852);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(120, 30);
            btnAddToCart.TabIndex = 15;
            btnAddToCart.Text = "Sepete Ekle";
            btnAddToCart.UseVisualStyleBackColor = false;
            btnAddToCart.Click += btnAddToCart_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(16, 19);
            label3.Name = "label3";
            label3.Size = new Size(62, 25);
            label3.TabIndex = 16;
            label3.Text = "Sepet";
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(16, 58);
            dgvCart.MultiSelect = false;
            dgvCart.Name = "dgvCart";
            dgvCart.ReadOnly = true;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(711, 763);
            dgvCart.TabIndex = 17;
            // 
            // btnClearCart
            // 
            btnClearCart.BackColor = Color.FromArgb(116, 142, 191);
            btnClearCart.FlatAppearance.BorderSize = 0;
            btnClearCart.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnClearCart.FlatStyle = FlatStyle.Flat;
            btnClearCart.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnClearCart.ForeColor = Color.White;
            btnClearCart.Location = new Point(643, 852);
            btnClearCart.Name = "btnClearCart";
            btnClearCart.Size = new Size(120, 30);
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
            btnRemoveFromCart.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnRemoveFromCart.ForeColor = Color.White;
            btnRemoveFromCart.Location = new Point(412, 842);
            btnRemoveFromCart.Name = "btnRemoveFromCart";
            btnRemoveFromCart.Size = new Size(150, 49);
            btnRemoveFromCart.TabIndex = 20;
            btnRemoveFromCart.Text = "Ürünü Sil";
            btnRemoveFromCart.UseVisualStyleBackColor = false;
            btnRemoveFromCart.Click += btnRemoveFromCart_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.Location = new Point(16, 849);
            label4.Name = "label4";
            label4.Size = new Size(149, 30);
            label4.TabIndex = 21;
            label4.Text = "Toplam Tutar:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblTotal.Location = new Point(171, 849);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(73, 30);
            lblTotal.TabIndex = 22;
            lblTotal.Text = "0,00 ₺";
            // 
            // btnCompleteSale
            // 
            btnCompleteSale.BackColor = Color.FromArgb(116, 142, 191);
            btnCompleteSale.FlatAppearance.BorderSize = 0;
            btnCompleteSale.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnCompleteSale.FlatStyle = FlatStyle.Flat;
            btnCompleteSale.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnCompleteSale.ForeColor = Color.White;
            btnCompleteSale.Location = new Point(577, 842);
            btnCompleteSale.Name = "btnCompleteSale";
            btnCompleteSale.Size = new Size(150, 49);
            btnCompleteSale.TabIndex = 23;
            btnCompleteSale.Text = "SATIŞ TAMAMLA";
            btnCompleteSale.UseVisualStyleBackColor = false;
            btnCompleteSale.Click += btnCompleteSale_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnReduceFromCart);
            panel1.Controls.Add(nudQuantity);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(btnClearCart);
            panel1.Controls.Add(dgvProducts);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnAddToCart);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 902);
            panel1.TabIndex = 24;
            // 
            // btnReduceFromCart
            // 
            btnReduceFromCart.BackColor = Color.FromArgb(200, 80, 60);
            btnReduceFromCart.FlatAppearance.BorderSize = 0;
            btnReduceFromCart.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 100, 80);
            btnReduceFromCart.FlatStyle = FlatStyle.Flat;
            btnReduceFromCart.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnReduceFromCart.ForeColor = Color.White;
            btnReduceFromCart.Location = new Point(508, 852);
            btnReduceFromCart.Name = "btnReduceFromCart";
            btnReduceFromCart.Size = new Size(120, 30);
            btnReduceFromCart.TabIndex = 22;
            btnReduceFromCart.Text = "Ürünü Sil";
            btnReduceFromCart.UseVisualStyleBackColor = false;
            btnReduceFromCart.Click += btnReduceFromCart_Click;
            // 
            // nudQuantity
            // 
            nudQuantity.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            nudQuantity.Location = new Point(78, 853);
            nudQuantity.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            nudQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new Size(277, 27);
            nudQuantity.TabIndex = 21;
            nudQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudQuantity.KeyDown += nudQuantity_KeyDown;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(dgvCart);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(lblTotal);
            panel2.Controls.Add(btnCompleteSale);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(btnRemoveFromCart);
            panel2.Location = new Point(812, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(743, 902);
            panel2.TabIndex = 25;
            // 
            // frmSale
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1567, 929);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "frmSale";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Satış";
            Load += frmSale_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvProducts;
        private Label label2;
        private Button btnAddToCart;
        private Label label3;
        private DataGridView dgvCart;
        private Button btnClearCart;
        private Button btnRemoveFromCart;
        private Label label4;
        private Label lblTotal;
        private Button btnCompleteSale;
        private Panel panel1;
        private Panel panel2;
        private NumericUpDown nudQuantity;
        private Button btnReduceFromCart;
    }
}