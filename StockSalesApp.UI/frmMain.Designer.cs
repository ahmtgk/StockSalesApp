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
            lblSaleAmount = new Label();
            lblSaleAmountTitle = new Label();
            pnlProductCount = new Panel();
            lblProductCount = new Label();
            lblProductCountTitle = new Label();
            pnlCriticalStock = new Panel();
            lblCriticalStock = new Label();
            lblCriticalTitle = new Label();
            pnlSaleCount = new Panel();
            lblSaleCount = new Label();
            lblSaleCountTitle = new Label();
            btnProducts = new Button();
            btnSale = new Button();
            btnStock = new Button();
            btnReports = new Button();
            btnUsers = new Button();
            lblLastSalesTitle = new Label();
            dgvLastSales = new DataGridView();
            panel1 = new Panel();
            label1 = new Label();
            close = new Button();
            panel2 = new Panel();
            btnLogout = new Button();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            pnlSaleAmount.SuspendLayout();
            pnlProductCount.SuspendLayout();
            pnlCriticalStock.SuspendLayout();
            pnlSaleCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLastSales).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.BackColor = Color.Transparent;
            lblWelcome.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(12, 192);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(109, 23);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Hoşgeldiniz,";
            lblWelcome.Click += lblWelcome_Click;
            // 
            // pnlSaleAmount
            // 
            pnlSaleAmount.BackColor = Color.SteelBlue;
            pnlSaleAmount.BorderStyle = BorderStyle.FixedSingle;
            pnlSaleAmount.Controls.Add(lblSaleAmount);
            pnlSaleAmount.Controls.Add(lblSaleAmountTitle);
            pnlSaleAmount.Location = new Point(924, 16);
            pnlSaleAmount.Name = "pnlSaleAmount";
            pnlSaleAmount.Size = new Size(285, 260);
            pnlSaleAmount.TabIndex = 1;
            // 
            // lblSaleAmount
            // 
            lblSaleAmount.AutoSize = true;
            lblSaleAmount.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblSaleAmount.ForeColor = Color.White;
            lblSaleAmount.Location = new Point(10, 113);
            lblSaleAmount.Name = "lblSaleAmount";
            lblSaleAmount.Size = new Size(97, 65);
            lblSaleAmount.TabIndex = 1;
            lblSaleAmount.Text = "0 ₺";
            lblSaleAmount.Click += lblSaleAmount_Click;
            // 
            // lblSaleAmountTitle
            // 
            lblSaleAmountTitle.AutoSize = true;
            lblSaleAmountTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblSaleAmountTitle.ForeColor = Color.White;
            lblSaleAmountTitle.Location = new Point(10, 10);
            lblSaleAmountTitle.Name = "lblSaleAmountTitle";
            lblSaleAmountTitle.Size = new Size(155, 30);
            lblSaleAmountTitle.TabIndex = 0;
            lblSaleAmountTitle.Text = "Bugünkü Satış";
            // 
            // pnlProductCount
            // 
            pnlProductCount.BackColor = Color.MediumSeaGreen;
            pnlProductCount.BorderStyle = BorderStyle.FixedSingle;
            pnlProductCount.Controls.Add(lblProductCount);
            pnlProductCount.Controls.Add(lblProductCountTitle);
            pnlProductCount.Location = new Point(324, 16);
            pnlProductCount.Name = "pnlProductCount";
            pnlProductCount.Size = new Size(285, 260);
            pnlProductCount.TabIndex = 2;
            // 
            // lblProductCount
            // 
            lblProductCount.AutoSize = true;
            lblProductCount.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblProductCount.ForeColor = Color.White;
            lblProductCount.Location = new Point(10, 113);
            lblProductCount.Name = "lblProductCount";
            lblProductCount.Size = new Size(56, 65);
            lblProductCount.TabIndex = 1;
            lblProductCount.Text = "0";
            lblProductCount.Click += lblProductCount_Click;
            // 
            // lblProductCountTitle
            // 
            lblProductCountTitle.AutoSize = true;
            lblProductCountTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblProductCountTitle.ForeColor = Color.White;
            lblProductCountTitle.Location = new Point(10, 10);
            lblProductCountTitle.Name = "lblProductCountTitle";
            lblProductCountTitle.Size = new Size(140, 30);
            lblProductCountTitle.TabIndex = 0;
            lblProductCountTitle.Text = "Toplam Ürün";
            // 
            // pnlCriticalStock
            // 
            pnlCriticalStock.BackColor = Color.FromArgb(220, 80, 60);
            pnlCriticalStock.BorderStyle = BorderStyle.FixedSingle;
            pnlCriticalStock.Controls.Add(lblCriticalStock);
            pnlCriticalStock.Controls.Add(lblCriticalTitle);
            pnlCriticalStock.Location = new Point(624, 16);
            pnlCriticalStock.Name = "pnlCriticalStock";
            pnlCriticalStock.Size = new Size(285, 260);
            pnlCriticalStock.TabIndex = 3;
            // 
            // lblCriticalStock
            // 
            lblCriticalStock.AutoSize = true;
            lblCriticalStock.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblCriticalStock.ForeColor = Color.White;
            lblCriticalStock.Location = new Point(10, 113);
            lblCriticalStock.Name = "lblCriticalStock";
            lblCriticalStock.Size = new Size(56, 65);
            lblCriticalStock.TabIndex = 1;
            lblCriticalStock.Text = "0";
            lblCriticalStock.Click += lblCriticalStock_Click;
            // 
            // lblCriticalTitle
            // 
            lblCriticalTitle.AutoSize = true;
            lblCriticalTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblCriticalTitle.ForeColor = Color.White;
            lblCriticalTitle.Location = new Point(10, 10);
            lblCriticalTitle.Name = "lblCriticalTitle";
            lblCriticalTitle.Size = new Size(117, 30);
            lblCriticalTitle.TabIndex = 0;
            lblCriticalTitle.Text = "Kritik Stok";
            // 
            // pnlSaleCount
            // 
            pnlSaleCount.BackColor = Color.Orange;
            pnlSaleCount.BorderStyle = BorderStyle.FixedSingle;
            pnlSaleCount.Controls.Add(lblSaleCount);
            pnlSaleCount.Controls.Add(lblSaleCountTitle);
            pnlSaleCount.Location = new Point(24, 16);
            pnlSaleCount.Name = "pnlSaleCount";
            pnlSaleCount.Size = new Size(285, 260);
            pnlSaleCount.TabIndex = 4;
            // 
            // lblSaleCount
            // 
            lblSaleCount.AutoSize = true;
            lblSaleCount.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblSaleCount.ForeColor = Color.White;
            lblSaleCount.Location = new Point(10, 113);
            lblSaleCount.Name = "lblSaleCount";
            lblSaleCount.Size = new Size(56, 65);
            lblSaleCount.TabIndex = 1;
            lblSaleCount.Text = "0";
            // 
            // lblSaleCountTitle
            // 
            lblSaleCountTitle.AutoSize = true;
            lblSaleCountTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblSaleCountTitle.ForeColor = Color.White;
            lblSaleCountTitle.Location = new Point(10, 10);
            lblSaleCountTitle.Name = "lblSaleCountTitle";
            lblSaleCountTitle.Size = new Size(219, 30);
            lblSaleCountTitle.TabIndex = 0;
            lblSaleCountTitle.Text = "Bugünkü Satış Adedi";
            // 
            // btnProducts
            // 
            btnProducts.BackColor = Color.FromArgb(116, 142, 191);
            btnProducts.FlatAppearance.BorderSize = 0;
            btnProducts.FlatAppearance.MouseDownBackColor = Color.FromArgb(98, 120, 162);
            btnProducts.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnProducts.ForeColor = Color.White;
            btnProducts.Location = new Point(12, 266);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(280, 45);
            btnProducts.TabIndex = 5;
            btnProducts.Text = "Ürün Yönetimi";
            btnProducts.UseVisualStyleBackColor = false;
            btnProducts.Click += btnProducts_Click;
            // 
            // btnSale
            // 
            btnSale.BackColor = Color.FromArgb(116, 142, 191);
            btnSale.FlatAppearance.BorderSize = 0;
            btnSale.FlatAppearance.MouseDownBackColor = Color.FromArgb(98, 120, 162);
            btnSale.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnSale.FlatStyle = FlatStyle.Flat;
            btnSale.Font = new Font("Segoe UI", 14.25F);
            btnSale.ForeColor = Color.Transparent;
            btnSale.Location = new Point(12, 317);
            btnSale.Name = "btnSale";
            btnSale.Size = new Size(280, 45);
            btnSale.TabIndex = 6;
            btnSale.Text = "Satış Yap";
            btnSale.UseVisualStyleBackColor = false;
            btnSale.Click += btnSale_Click;
            // 
            // btnStock
            // 
            btnStock.BackColor = Color.FromArgb(116, 142, 191);
            btnStock.FlatAppearance.BorderSize = 0;
            btnStock.FlatAppearance.MouseDownBackColor = Color.FromArgb(98, 120, 162);
            btnStock.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnStock.FlatStyle = FlatStyle.Flat;
            btnStock.Font = new Font("Segoe UI", 14.25F);
            btnStock.ForeColor = Color.Transparent;
            btnStock.Location = new Point(12, 368);
            btnStock.Name = "btnStock";
            btnStock.Size = new Size(280, 45);
            btnStock.TabIndex = 7;
            btnStock.Text = "Stok Girişi";
            btnStock.UseVisualStyleBackColor = false;
            btnStock.Click += btnStock_Click;
            // 
            // btnReports
            // 
            btnReports.BackColor = Color.FromArgb(116, 142, 191);
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatAppearance.MouseDownBackColor = Color.FromArgb(98, 120, 162);
            btnReports.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 14.25F);
            btnReports.ForeColor = Color.Transparent;
            btnReports.Location = new Point(12, 419);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(280, 45);
            btnReports.TabIndex = 8;
            btnReports.Text = "Raporlar";
            btnReports.UseVisualStyleBackColor = false;
            btnReports.Click += btnReports_Click;
            // 
            // btnUsers
            // 
            btnUsers.BackColor = Color.FromArgb(116, 142, 191);
            btnUsers.FlatAppearance.BorderSize = 0;
            btnUsers.FlatAppearance.MouseDownBackColor = Color.FromArgb(98, 120, 162);
            btnUsers.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.Font = new Font("Segoe UI", 14.25F);
            btnUsers.ForeColor = Color.Transparent;
            btnUsers.Location = new Point(12, 470);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(280, 45);
            btnUsers.TabIndex = 9;
            btnUsers.Text = "Kullanıcı Yönetimi";
            btnUsers.UseVisualStyleBackColor = false;
            btnUsers.Click += btnUsers_Click;
            // 
            // lblLastSalesTitle
            // 
            lblLastSalesTitle.AutoSize = true;
            lblLastSalesTitle.BackColor = Color.White;
            lblLastSalesTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblLastSalesTitle.ForeColor = Color.Black;
            lblLastSalesTitle.Location = new Point(321, 441);
            lblLastSalesTitle.Name = "lblLastSalesTitle";
            lblLastSalesTitle.Size = new Size(128, 30);
            lblLastSalesTitle.TabIndex = 10;
            lblLastSalesTitle.Text = "Son Satışlar";
            // 
            // dgvLastSales
            // 
            dgvLastSales.AllowUserToAddRows = false;
            dgvLastSales.AllowUserToDeleteRows = false;
            dgvLastSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLastSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLastSales.Location = new Point(320, 479);
            dgvLastSales.Name = "dgvLastSales";
            dgvLastSales.ReadOnly = true;
            dgvLastSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLastSales.Size = new Size(1233, 490);
            dgvLastSales.TabIndex = 11;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(close);
            panel1.Dock = DockStyle.Top;
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1565, 60);
            panel1.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(231, 23);
            label1.TabIndex = 13;
            label1.Text = "Stok ve Satış Takip Sistemi ";
            // 
            // close
            // 
            close.BackColor = Color.Firebrick;
            close.FlatAppearance.BorderColor = Color.Black;
            close.FlatStyle = FlatStyle.Flat;
            close.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            close.ForeColor = Color.White;
            close.Location = new Point(1512, 12);
            close.Name = "close";
            close.Size = new Size(41, 38);
            close.TabIndex = 8;
            close.Text = "X";
            close.UseVisualStyleBackColor = false;
            close.Click += close_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(116, 142, 191);
            panel2.Controls.Add(btnLogout);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(lblWelcome);
            panel2.Controls.Add(btnProducts);
            panel2.Controls.Add(btnUsers);
            panel2.Controls.Add(btnSale);
            panel2.Controls.Add(btnReports);
            panel2.Controls.Add(btnStock);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 60);
            panel2.Name = "panel2";
            panel2.Size = new Size(304, 921);
            panel2.TabIndex = 13;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(116, 142, 191);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseDownBackColor = Color.FromArgb(98, 120, 162);
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnLogout.ForeColor = Color.Transparent;
            btnLogout.Location = new Point(12, 864);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(280, 45);
            btnLogout.TabIndex = 10;
            btnLogout.Text = "Çıkış Yap";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(78, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(143, 144);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(pnlProductCount);
            panel3.Controls.Add(pnlSaleCount);
            panel3.Controls.Add(pnlSaleAmount);
            panel3.Controls.Add(pnlCriticalStock);
            panel3.ForeColor = Color.White;
            panel3.Location = new Point(320, 80);
            panel3.Name = "panel3";
            panel3.Size = new Size(1233, 291);
            panel3.TabIndex = 14;
            panel3.Paint += panel3_Paint;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1565, 981);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dgvLastSales);
            Controls.Add(lblLastSalesTitle);
            ForeColor = Color.WhiteSmoke;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " ";
            FormClosed += frmMain_FormClosed;
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
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private Panel panel1;
        private Button close;
        private Label label1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Button btnLogout;
        private Panel panel3;
        private Label lblProductCountTitle;
    }
}