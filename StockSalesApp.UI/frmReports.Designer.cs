namespace StockSalesApp.UI
{
    partial class frmReports
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
            tabReports = new TabControl();
            tabPage1 = new TabPage();
            btnFilterSales = new Button();
            dgvSalesReport = new DataGridView();
            lblSalesSummary = new Label();
            dtpEnd = new DateTimePicker();
            label2 = new Label();
            dtpStart = new DateTimePicker();
            label1 = new Label();
            tabPage2 = new TabPage();
            btnFilterTop = new Button();
            dtpTopEnd = new DateTimePicker();
            dtpTopStart = new DateTimePicker();
            dgvTopProducts = new DataGridView();
            label4 = new Label();
            label3 = new Label();
            tabPage3 = new TabPage();
            dgvStockReport = new DataGridView();
            cmbStockFilter = new ComboBox();
            label5 = new Label();
            btnLoadStock = new Button();
            tabReports.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSalesReport).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopProducts).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStockReport).BeginInit();
            SuspendLayout();
            // 
            // tabReports
            // 
            tabReports.Controls.Add(tabPage1);
            tabReports.Controls.Add(tabPage2);
            tabReports.Controls.Add(tabPage3);
            tabReports.Dock = DockStyle.Fill;
            tabReports.Location = new Point(0, 0);
            tabReports.Name = "tabReports";
            tabReports.SelectedIndex = 0;
            tabReports.Size = new Size(884, 561);
            tabReports.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnFilterSales);
            tabPage1.Controls.Add(dgvSalesReport);
            tabPage1.Controls.Add(lblSalesSummary);
            tabPage1.Controls.Add(dtpEnd);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(dtpStart);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(876, 533);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Günlük Satış Raporu";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnFilterSales
            // 
            btnFilterSales.BackColor = Color.FromArgb(116, 142, 191);
            btnFilterSales.FlatAppearance.BorderSize = 0;
            btnFilterSales.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnFilterSales.FlatStyle = FlatStyle.Flat;
            btnFilterSales.Font = new Font("Segoe UI", 11.25F);
            btnFilterSales.ForeColor = Color.White;
            btnFilterSales.Location = new Point(450, 11);
            btnFilterSales.Name = "btnFilterSales";
            btnFilterSales.Size = new Size(80, 25);
            btnFilterSales.TabIndex = 15;
            btnFilterSales.Text = "Filtrele";
            btnFilterSales.UseVisualStyleBackColor = false;
            btnFilterSales.Click += btnFilterSales_Click;
            // 
            // dgvSalesReport
            // 
            dgvSalesReport.AllowUserToAddRows = false;
            dgvSalesReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSalesReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSalesReport.Location = new Point(10, 45);
            dgvSalesReport.Name = "dgvSalesReport";
            dgvSalesReport.ReadOnly = true;
            dgvSalesReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSalesReport.Size = new Size(800, 380);
            dgvSalesReport.TabIndex = 6;
            // 
            // lblSalesSummary
            // 
            lblSalesSummary.AutoSize = true;
            lblSalesSummary.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblSalesSummary.ForeColor = Color.FromArgb(30, 130, 70);
            lblSalesSummary.Location = new Point(545, 15);
            lblSalesSummary.Name = "lblSalesSummary";
            lblSalesSummary.Size = new Size(40, 15);
            lblSalesSummary.TabIndex = 5;
            lblSalesSummary.Text = "label3";
            // 
            // dtpEnd
            // 
            dtpEnd.Location = new Point(285, 12);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(150, 23);
            dtpEnd.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(245, 15);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 2;
            label2.Text = "Bitiş:";
            // 
            // dtpStart
            // 
            dtpStart.Location = new Point(80, 12);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(150, 23);
            dtpStart.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 15);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 0;
            label1.Text = "Başlangıç:";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnFilterTop);
            tabPage2.Controls.Add(dtpTopEnd);
            tabPage2.Controls.Add(dtpTopStart);
            tabPage2.Controls.Add(dgvTopProducts);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label3);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(876, 533);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "En Çok Satılan Ürünler";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnFilterTop
            // 
            btnFilterTop.BackColor = Color.FromArgb(116, 142, 191);
            btnFilterTop.FlatAppearance.BorderSize = 0;
            btnFilterTop.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnFilterTop.FlatStyle = FlatStyle.Flat;
            btnFilterTop.Font = new Font("Segoe UI", 11.25F);
            btnFilterTop.ForeColor = Color.White;
            btnFilterTop.Location = new Point(450, 11);
            btnFilterTop.Name = "btnFilterTop";
            btnFilterTop.Size = new Size(80, 25);
            btnFilterTop.TabIndex = 3;
            btnFilterTop.Text = "Filtrele";
            btnFilterTop.UseVisualStyleBackColor = false;
            btnFilterTop.Click += btnFilterTop_Click;
            // 
            // dtpTopEnd
            // 
            dtpTopEnd.Location = new Point(285, 12);
            dtpTopEnd.Name = "dtpTopEnd";
            dtpTopEnd.Size = new Size(150, 23);
            dtpTopEnd.TabIndex = 2;
            // 
            // dtpTopStart
            // 
            dtpTopStart.Location = new Point(80, 12);
            dtpTopStart.Name = "dtpTopStart";
            dtpTopStart.Size = new Size(150, 23);
            dtpTopStart.TabIndex = 1;
            // 
            // dgvTopProducts
            // 
            dgvTopProducts.AllowUserToAddRows = false;
            dgvTopProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTopProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTopProducts.Location = new Point(10, 45);
            dgvTopProducts.Name = "dgvTopProducts";
            dgvTopProducts.ReadOnly = true;
            dgvTopProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTopProducts.Size = new Size(800, 380);
            dgvTopProducts.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(245, 15);
            label4.Name = "label4";
            label4.Size = new Size(32, 15);
            label4.TabIndex = 1;
            label4.Text = "Bitiş:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 15);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 0;
            label3.Text = "Başlangıç:";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dgvStockReport);
            tabPage3.Controls.Add(cmbStockFilter);
            tabPage3.Controls.Add(label5);
            tabPage3.Controls.Add(btnLoadStock);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(876, 533);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Stok Durumu";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvStockReport
            // 
            dgvStockReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStockReport.Location = new Point(10, 50);
            dgvStockReport.Name = "dgvStockReport";
            dgvStockReport.Size = new Size(800, 380);
            dgvStockReport.TabIndex = 7;
            // 
            // cmbStockFilter
            // 
            cmbStockFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStockFilter.FormattingEnabled = true;
            cmbStockFilter.Location = new Point(235, 12);
            cmbStockFilter.Name = "cmbStockFilter";
            cmbStockFilter.Size = new Size(150, 23);
            cmbStockFilter.TabIndex = 6;
            cmbStockFilter.SelectedIndexChanged += cmbStockFilter_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(185, 15);
            label5.Name = "label5";
            label5.Size = new Size(45, 15);
            label5.TabIndex = 5;
            label5.Text = "Filtrele:";
            // 
            // btnLoadStock
            // 
            btnLoadStock.BackColor = Color.FromArgb(116, 142, 191);
            btnLoadStock.FlatAppearance.BorderSize = 0;
            btnLoadStock.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnLoadStock.FlatStyle = FlatStyle.Flat;
            btnLoadStock.Font = new Font("Segoe UI", 11.25F);
            btnLoadStock.ForeColor = Color.White;
            btnLoadStock.Location = new Point(10, 10);
            btnLoadStock.Name = "btnLoadStock";
            btnLoadStock.Size = new Size(160, 30);
            btnLoadStock.TabIndex = 4;
            btnLoadStock.Text = "Stok Durumunu Yükle";
            btnLoadStock.UseVisualStyleBackColor = false;
            btnLoadStock.Click += btnLoadStock_Click;
            // 
            // frmReports
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(884, 561);
            Controls.Add(tabReports);
            MaximizeBox = false;
            Name = "frmReports";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Raporlar";
            Load += frmReports_Load;
            tabReports.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSalesReport).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopProducts).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStockReport).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabReports;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private DataGridView dgvSalesReport;
        private Label lblSalesSummary;
        private DateTimePicker dtpEnd;
        private Label label2;
        private DateTimePicker dtpStart;
        private Label label1;
        private Button btnFilterSales;
        private DateTimePicker dtpTopEnd;
        private DateTimePicker dtpTopStart;
        private DataGridView dgvTopProducts;
        private Label label4;
        private Label label3;
        private Button btnFilterTop;
        private DataGridView dgvStockReport;
        private ComboBox cmbStockFilter;
        private Label label5;
        private Button btnLoadStock;
    }
}