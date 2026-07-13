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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            tabReports = new TabControl();
            tabPage1 = new TabPage();
            panel2 = new Panel();
            label1 = new Label();
            btnFilterSales = new Button();
            dtpStart = new DateTimePicker();
            label2 = new Label();
            lblSalesSummary = new Label();
            dtpEnd = new DateTimePicker();
            panel1 = new Panel();
            dgvSalesReport = new DataGridView();
            tabPage2 = new TabPage();
            panel4 = new Panel();
            dgvTopProducts = new DataGridView();
            panel3 = new Panel();
            label3 = new Label();
            label4 = new Label();
            btnFilterTop = new Button();
            dtpTopStart = new DateTimePicker();
            dtpTopEnd = new DateTimePicker();
            tabPage3 = new TabPage();
            panel6 = new Panel();
            dgvStockReport = new DataGridView();
            panel5 = new Panel();
            label5 = new Label();
            cmbStockFilter = new ComboBox();
            btnLoadStock = new Button();
            tabReports.SuspendLayout();
            tabPage1.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSalesReport).BeginInit();
            tabPage2.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopProducts).BeginInit();
            panel3.SuspendLayout();
            tabPage3.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStockReport).BeginInit();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // tabReports
            // 
            tabReports.Controls.Add(tabPage1);
            tabReports.Controls.Add(tabPage2);
            tabReports.Controls.Add(tabPage3);
            tabReports.Dock = DockStyle.Fill;
            tabReports.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            tabReports.Location = new Point(0, 0);
            tabReports.Name = "tabReports";
            tabReports.SelectedIndex = 0;
            tabReports.Size = new Size(1158, 749);
            tabReports.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.WhiteSmoke;
            tabPage1.Controls.Add(panel2);
            tabPage1.Controls.Add(panel1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1150, 716);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Günlük Satış Raporu";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(btnFilterSales);
            panel2.Controls.Add(dtpStart);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(lblSalesSummary);
            panel2.Controls.Add(dtpEnd);
            panel2.Location = new Point(20, 16);
            panel2.Name = "panel2";
            panel2.Size = new Size(1110, 115);
            panel2.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.Location = new Point(17, 43);
            label1.Name = "label1";
            label1.Size = new Size(78, 21);
            label1.TabIndex = 0;
            label1.Text = "Başlangıç:";
            // 
            // btnFilterSales
            // 
            btnFilterSales.BackColor = Color.FromArgb(116, 142, 191);
            btnFilterSales.FlatAppearance.BorderSize = 0;
            btnFilterSales.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnFilterSales.FlatStyle = FlatStyle.Flat;
            btnFilterSales.Font = new Font("Segoe UI", 11.25F);
            btnFilterSales.ForeColor = Color.White;
            btnFilterSales.Location = new Point(599, 39);
            btnFilterSales.Name = "btnFilterSales";
            btnFilterSales.Size = new Size(134, 27);
            btnFilterSales.TabIndex = 15;
            btnFilterSales.Text = "Filtrele";
            btnFilterSales.UseVisualStyleBackColor = false;
            btnFilterSales.Click += btnFilterSales_Click;
            // 
            // dtpStart
            // 
            dtpStart.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dtpStart.Location = new Point(101, 39);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(219, 27);
            dtpStart.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.Location = new Point(326, 43);
            label2.Name = "label2";
            label2.Size = new Size(42, 21);
            label2.TabIndex = 2;
            label2.Text = "Bitiş:";
            // 
            // lblSalesSummary
            // 
            lblSalesSummary.AutoSize = true;
            lblSalesSummary.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblSalesSummary.ForeColor = Color.FromArgb(30, 130, 70);
            lblSalesSummary.Location = new Point(739, 44);
            lblSalesSummary.Name = "lblSalesSummary";
            lblSalesSummary.Size = new Size(51, 20);
            lblSalesSummary.TabIndex = 5;
            lblSalesSummary.Text = "label3";
            // 
            // dtpEnd
            // 
            dtpEnd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dtpEnd.Location = new Point(374, 39);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(219, 27);
            dtpEnd.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(dgvSalesReport);
            panel1.Location = new Point(20, 150);
            panel1.Name = "panel1";
            panel1.Size = new Size(1110, 546);
            panel1.TabIndex = 1;
            // 
            // dgvSalesReport
            // 
            dgvSalesReport.AllowUserToAddRows = false;
            dgvSalesReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dgvSalesReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSalesReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvSalesReport.DefaultCellStyle = dataGridViewCellStyle2;
            dgvSalesReport.Location = new Point(17, 19);
            dgvSalesReport.Name = "dgvSalesReport";
            dgvSalesReport.ReadOnly = true;
            dgvSalesReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSalesReport.Size = new Size(1075, 508);
            dgvSalesReport.TabIndex = 6;
            dgvSalesReport.CellDoubleClick += dgvSalesReport_CellDoubleClick;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.WhiteSmoke;
            tabPage2.Controls.Add(panel4);
            tabPage2.Controls.Add(panel3);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1150, 716);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "En Çok Satılan Ürünler";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(dgvTopProducts);
            panel4.Location = new Point(20, 150);
            panel4.Name = "panel4";
            panel4.Size = new Size(1110, 546);
            panel4.TabIndex = 6;
            // 
            // dgvTopProducts
            // 
            dgvTopProducts.AllowUserToAddRows = false;
            dgvTopProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dgvTopProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvTopProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvTopProducts.DefaultCellStyle = dataGridViewCellStyle4;
            dgvTopProducts.Location = new Point(17, 19);
            dgvTopProducts.Name = "dgvTopProducts";
            dgvTopProducts.ReadOnly = true;
            dgvTopProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTopProducts.Size = new Size(1075, 508);
            dgvTopProducts.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(btnFilterTop);
            panel3.Controls.Add(dtpTopStart);
            panel3.Controls.Add(dtpTopEnd);
            panel3.Location = new Point(20, 16);
            panel3.Name = "panel3";
            panel3.Size = new Size(1110, 115);
            panel3.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label3.Location = new Point(17, 43);
            label3.Name = "label3";
            label3.Size = new Size(75, 20);
            label3.TabIndex = 0;
            label3.Text = "Başlangıç:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label4.Location = new Point(357, 43);
            label4.Name = "label4";
            label4.Size = new Size(40, 20);
            label4.TabIndex = 1;
            label4.Text = "Bitiş:";
            // 
            // btnFilterTop
            // 
            btnFilterTop.BackColor = Color.FromArgb(116, 142, 191);
            btnFilterTop.FlatAppearance.BorderSize = 0;
            btnFilterTop.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnFilterTop.FlatStyle = FlatStyle.Flat;
            btnFilterTop.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnFilterTop.ForeColor = Color.White;
            btnFilterTop.Location = new Point(637, 38);
            btnFilterTop.Name = "btnFilterTop";
            btnFilterTop.Size = new Size(134, 28);
            btnFilterTop.TabIndex = 3;
            btnFilterTop.Text = "Filtrele";
            btnFilterTop.UseVisualStyleBackColor = false;
            btnFilterTop.Click += btnFilterTop_Click;
            // 
            // dtpTopStart
            // 
            dtpTopStart.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dtpTopStart.Location = new Point(98, 39);
            dtpTopStart.Name = "dtpTopStart";
            dtpTopStart.Size = new Size(219, 27);
            dtpTopStart.TabIndex = 1;
            // 
            // dtpTopEnd
            // 
            dtpTopEnd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dtpTopEnd.Location = new Point(403, 38);
            dtpTopEnd.Name = "dtpTopEnd";
            dtpTopEnd.Size = new Size(219, 27);
            dtpTopEnd.TabIndex = 2;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.WhiteSmoke;
            tabPage3.Controls.Add(panel6);
            tabPage3.Controls.Add(panel5);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1150, 716);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Stok Durumu";
            // 
            // panel6
            // 
            panel6.BackColor = Color.White;
            panel6.Controls.Add(dgvStockReport);
            panel6.Location = new Point(20, 166);
            panel6.Name = "panel6";
            panel6.Size = new Size(1110, 546);
            panel6.TabIndex = 9;
            // 
            // dgvStockReport
            // 
            dgvStockReport.AllowUserToAddRows = false;
            dgvStockReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dgvStockReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvStockReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvStockReport.DefaultCellStyle = dataGridViewCellStyle6;
            dgvStockReport.Location = new Point(17, 19);
            dgvStockReport.Name = "dgvStockReport";
            dgvStockReport.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Control;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvStockReport.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvStockReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStockReport.Size = new Size(1075, 508);
            dgvStockReport.TabIndex = 7;
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(label5);
            panel5.Controls.Add(cmbStockFilter);
            panel5.Controls.Add(btnLoadStock);
            panel5.Location = new Point(20, 16);
            panel5.Name = "panel5";
            panel5.Size = new Size(1110, 115);
            panel5.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label5.Location = new Point(17, 41);
            label5.Name = "label5";
            label5.Size = new Size(57, 20);
            label5.TabIndex = 5;
            label5.Text = "Filtrele:";
            // 
            // cmbStockFilter
            // 
            cmbStockFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStockFilter.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            cmbStockFilter.FormattingEnabled = true;
            cmbStockFilter.Location = new Point(80, 38);
            cmbStockFilter.Name = "cmbStockFilter";
            cmbStockFilter.Size = new Size(250, 28);
            cmbStockFilter.TabIndex = 6;
            cmbStockFilter.SelectedIndexChanged += cmbStockFilter_SelectedIndexChanged;
            // 
            // btnLoadStock
            // 
            btnLoadStock.BackColor = Color.FromArgb(116, 142, 191);
            btnLoadStock.FlatAppearance.BorderSize = 0;
            btnLoadStock.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnLoadStock.FlatStyle = FlatStyle.Flat;
            btnLoadStock.Font = new Font("Segoe UI", 11.25F);
            btnLoadStock.ForeColor = Color.White;
            btnLoadStock.Location = new Point(346, 36);
            btnLoadStock.Name = "btnLoadStock";
            btnLoadStock.Size = new Size(191, 30);
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
            ClientSize = new Size(1158, 749);
            Controls.Add(tabReports);
            MaximizeBox = false;
            Name = "frmReports";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Raporlar";
            Load += frmReports_Load;
            tabReports.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSalesReport).EndInit();
            tabPage2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTopProducts).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tabPage3.ResumeLayout(false);
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStockReport).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabReports;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private DataGridView dgvSalesReport;
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
        private TabPage tabPage1;
        private Panel panel2;
        private Label label1;
        private Button btnFilterSales;
        private DateTimePicker dtpStart;
        private Label label2;
        private Label lblSalesSummary;
        private DateTimePicker dtpEnd;
        private Panel panel1;
        private Panel panel4;
        private Panel panel3;
        private Panel panel6;
        private Panel panel5;
    }
}