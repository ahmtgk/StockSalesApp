namespace StockSalesApp.UI
{
    partial class frmMain
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
            lblWelcome = new Label();
            pnlSaleAmount = new Panel();
            pnlProductCount = new Panel();
            pnlCriticalStock = new Panel();
            pnlSaleCount = new Panel();
            lblSaleAmountTitle = new Label();
            lblSaleAmount = new Label();
            lblProductCountTitle = new Label();
            lblProductCount = new Label();
            lblCriticalTitle = new Label();
            lblCriticalStock = new Label();
            lblSaleCountTitle = new Label();
            lblSaleCount = new Label();
            btnProducts = new Button();
            btnSale = new Button();
            btnStock = new Button();
            btnReports = new Button();
            btnUsers = new Button();
            lblLastSalesTitle = new Label();
            dgvLastSales = new DataGridView();
            pnlSaleAmount.SuspendLayout();
            pnlProductCount.SuspendLayout();
            pnlCriticalStock.SuspendLayout();
            pnlSaleCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLastSales).BeginInit();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblWelcome.Location = new Point(20, 15);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(104, 23);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Hoşgeldiniz";
            // 
            // pnlSaleAmount
            // 
            pnlSaleAmount.BackColor = Color.SteelBlue;
            pnlSaleAmount.BorderStyle = BorderStyle.FixedSingle;
            pnlSaleAmount.Controls.Add(lblSaleAmount);
            pnlSaleAmount.Controls.Add(lblSaleAmountTitle);
            pnlSaleAmount.Location = new Point(20, 55);
            pnlSaleAmount.Name = "pnlSaleAmount";
            pnlSaleAmount.Size = new Size(185, 90);
            pnlSaleAmount.TabIndex = 1;
            // 
            // pnlProductCount
            // 
            pnlProductCount.BackColor = Color.MediumSeaGreen;
            pnlProductCount.BorderStyle = BorderStyle.FixedSingle;
            pnlProductCount.Controls.Add(lblProductCount);
            pnlProductCount.Controls.Add(lblProductCountTitle);
            pnlProductCount.Location = new Point(215, 55);
            pnlProductCount.Name = "pnlProductCount";
            pnlProductCount.Size = new Size(185, 90);
            pnlProductCount.TabIndex = 2;
            // 
            // pnlCriticalStock
            // 
            pnlCriticalStock.BackColor = Color.FromArgb(220, 80, 60);
            pnlCriticalStock.BorderStyle = BorderStyle.FixedSingle;
            pnlCriticalStock.Controls.Add(lblCriticalStock);
            pnlCriticalStock.Controls.Add(lblCriticalTitle);
            pnlCriticalStock.Location = new Point(410, 55);
            pnlCriticalStock.Name = "pnlCriticalStock";
            pnlCriticalStock.Size = new Size(185, 90);
            pnlCriticalStock.TabIndex = 3;
            // 
            // pnlSaleCount
            // 
            pnlSaleCount.BackColor = Color.Orange;
            pnlSaleCount.BorderStyle = BorderStyle.FixedSingle;
            pnlSaleCount.Controls.Add(lblSaleCount);
            pnlSaleCount.Controls.Add(lblSaleCountTitle);
            pnlSaleCount.Location = new Point(605, 55);
            pnlSaleCount.Name = "pnlSaleCount";
            pnlSaleCount.Size = new Size(185, 90);
            pnlSaleCount.TabIndex = 4;
            // 
            // lblSaleAmountTitle
            // 
            lblSaleAmountTitle.AutoSize = true;
            lblSaleAmountTitle.ForeColor = Color.White;
            lblSaleAmountTitle.Location = new Point(10, 10);
            lblSaleAmountTitle.Name = "lblSaleAmountTitle";
            lblSaleAmountTitle.Size = new Size(82, 15);
            lblSaleAmountTitle.TabIndex = 0;
            lblSaleAmountTitle.Text = "Bugünkü Satış";
            // 
            // lblSaleAmount
            // 
            lblSaleAmount.AutoSize = true;
            lblSaleAmount.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblSaleAmount.ForeColor = Color.White;
            lblSaleAmount.Location = new Point(10, 40);
            lblSaleAmount.Name = "lblSaleAmount";
            lblSaleAmount.Size = new Size(49, 32);
            lblSaleAmount.TabIndex = 1;
            lblSaleAmount.Text = "0 ₺";
            // 
            // lblProductCountTitle
            // 
            lblProductCountTitle.AutoSize = true;
            lblProductCountTitle.ForeColor = Color.White;
            lblProductCountTitle.Location = new Point(10, 10);
            lblProductCountTitle.Name = "lblProductCountTitle";
            lblProductCountTitle.Size = new Size(76, 15);
            lblProductCountTitle.TabIndex = 0;
            lblProductCountTitle.Text = "Toplam Ürün";
            // 
            // lblProductCount
            // 
            lblProductCount.AutoSize = true;
            lblProductCount.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblProductCount.ForeColor = Color.White;
            lblProductCount.Location = new Point(10, 40);
            lblProductCount.Name = "lblProductCount";
            lblProductCount.Size = new Size(28, 32);
            lblProductCount.TabIndex = 1;
            lblProductCount.Text = "0";
            // 
            // lblCriticalTitle
            // 
            lblCriticalTitle.AutoSize = true;
            lblCriticalTitle.ForeColor = Color.White;
            lblCriticalTitle.Location = new Point(10, 10);
            lblCriticalTitle.Name = "lblCriticalTitle";
            lblCriticalTitle.Size = new Size(60, 15);
            lblCriticalTitle.TabIndex = 0;
            lblCriticalTitle.Text = "Kritik Stok";
            // 
            // lblCriticalStock
            // 
            lblCriticalStock.AutoSize = true;
            lblCriticalStock.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblCriticalStock.ForeColor = Color.White;
            lblCriticalStock.Location = new Point(10, 40);
            lblCriticalStock.Name = "lblCriticalStock";
            lblCriticalStock.Size = new Size(28, 32);
            lblCriticalStock.TabIndex = 1;
            lblCriticalStock.Text = "0";
            // 
            // lblSaleCountTitle
            // 
            lblSaleCountTitle.AutoSize = true;
            lblSaleCountTitle.ForeColor = Color.White;
            lblSaleCountTitle.Location = new Point(10, 10);
            lblSaleCountTitle.Name = "lblSaleCountTitle";
            lblSaleCountTitle.Size = new Size(116, 15);
            lblSaleCountTitle.TabIndex = 0;
            lblSaleCountTitle.Text = "Bugünkü Satış Adedi";
            // 
            // lblSaleCount
            // 
            lblSaleCount.AutoSize = true;
            lblSaleCount.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblSaleCount.ForeColor = Color.White;
            lblSaleCount.Location = new Point(10, 40);
            lblSaleCount.Name = "lblSaleCount";
            lblSaleCount.Size = new Size(28, 32);
            lblSaleCount.TabIndex = 1;
            lblSaleCount.Text = "0";
            // 
            // btnProducts
            // 
            btnProducts.BackColor = Color.FromArgb(50, 50, 70);
            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnProducts.ForeColor = Color.White;
            btnProducts.Location = new Point(20, 165);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(180, 45);
            btnProducts.TabIndex = 5;
            btnProducts.Text = "Ürün Yönetimi";
            btnProducts.UseVisualStyleBackColor = false;
            btnProducts.Click += btnProducts_Click;
            // 
            // btnSale
            // 
            btnSale.BackColor = Color.FromArgb(50, 50, 70);
            btnSale.FlatStyle = FlatStyle.Flat;
            btnSale.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnSale.ForeColor = Color.Transparent;
            btnSale.Location = new Point(20, 220);
            btnSale.Name = "btnSale";
            btnSale.Size = new Size(180, 45);
            btnSale.TabIndex = 6;
            btnSale.Text = "Satış Yap";
            btnSale.UseVisualStyleBackColor = false;
            btnSale.Click += btnSale_Click;
            // 
            // btnStock
            // 
            btnStock.BackColor = Color.FromArgb(50, 50, 70);
            btnStock.FlatStyle = FlatStyle.Flat;
            btnStock.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnStock.ForeColor = Color.Transparent;
            btnStock.Location = new Point(20, 275);
            btnStock.Name = "btnStock";
            btnStock.Size = new Size(180, 45);
            btnStock.TabIndex = 7;
            btnStock.Text = "Stok Girişi";
            btnStock.UseVisualStyleBackColor = false;
            // 
            // btnReports
            // 
            btnReports.BackColor = Color.FromArgb(50, 50, 70);
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnReports.ForeColor = Color.Transparent;
            btnReports.Location = new Point(20, 330);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(180, 45);
            btnReports.TabIndex = 8;
            btnReports.Text = "Raporlar";
            btnReports.UseVisualStyleBackColor = false;
            // 
            // btnUsers
            // 
            btnUsers.BackColor = Color.FromArgb(50, 50, 70);
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnUsers.ForeColor = Color.Transparent;
            btnUsers.Location = new Point(20, 385);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(180, 45);
            btnUsers.TabIndex = 9;
            btnUsers.Text = "Kullanıcı Yönetimi";
            btnUsers.UseVisualStyleBackColor = false;
            // 
            // lblLastSalesTitle
            // 
            lblLastSalesTitle.AutoSize = true;
            lblLastSalesTitle.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblLastSalesTitle.Location = new Point(215, 165);
            lblLastSalesTitle.Name = "lblLastSalesTitle";
            lblLastSalesTitle.Size = new Size(90, 20);
            lblLastSalesTitle.TabIndex = 10;
            lblLastSalesTitle.Text = "Son Satışlar";
            // 
            // dgvLastSales
            // 
            dgvLastSales.AllowUserToAddRows = false;
            dgvLastSales.AllowUserToDeleteRows = false;
            dgvLastSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLastSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLastSales.Location = new Point(215, 195);
            dgvLastSales.Name = "dgvLastSales";
            dgvLastSales.ReadOnly = true;
            dgvLastSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLastSales.Size = new Size(630, 330);
            dgvLastSales.TabIndex = 11;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(900, 600);
            Controls.Add(dgvLastSales);
            Controls.Add(lblLastSalesTitle);
            Controls.Add(btnUsers);
            Controls.Add(btnReports);
            Controls.Add(btnStock);
            Controls.Add(btnSale);
            Controls.Add(btnProducts);
            Controls.Add(pnlSaleCount);
            Controls.Add(pnlCriticalStock);
            Controls.Add(pnlProductCount);
            Controls.Add(pnlSaleAmount);
            Controls.Add(lblWelcome);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ana Menü";
            Load += frmMain_Load;
            pnlSaleAmount.ResumeLayout(false);
            pnlSaleAmount.PerformLayout();
            pnlProductCount.ResumeLayout(false);
            pnlProductCount.PerformLayout();
            pnlCriticalStock.ResumeLayout(false);
            pnlCriticalStock.PerformLayout();
            pnlSaleCount.ResumeLayout(false);
            pnlSaleCount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLastSales).EndInit();
            ResumeLayout(false);
            PerformLayout();

            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
        }

        #endregion

        private Label lblWelcome;
        private Panel pnlSaleAmount;
        private Label lblSaleAmount;
        private Label lblSaleAmountTitle;
        private Panel pnlProductCount;
        private Panel pnlCriticalStock;
        private Panel pnlSaleCount;
        private Label lblProductCount;
        private Label lblProductCountTitle;
        private Label lblCriticalStock;
        private Label lblCriticalTitle;
        private Label lblSaleCount;
        private Label lblSaleCountTitle;
        private Button btnProducts;
        private Button btnSale;
        private Button btnStock;
        private Button btnReports;
        private Button btnUsers;
        private Label lblLastSalesTitle;
        private DataGridView dgvLastSales;
    }
}