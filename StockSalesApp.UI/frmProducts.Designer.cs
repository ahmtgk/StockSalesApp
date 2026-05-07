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
            btnSearch = new Button();
            panel1 = new Panel();
            label2 = new Label();
            panel2 = new Panel();
            close = new Button();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(12, 35);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 0;
            label1.Text = "Ürün Ara:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtSearch.Location = new Point(95, 32);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(509, 27);
            txtSearch.TabIndex = 1;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // btnListAll
            // 
            btnListAll.BackColor = Color.FromArgb(116, 142, 191);
            btnListAll.FlatAppearance.BorderSize = 0;
            btnListAll.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnListAll.FlatStyle = FlatStyle.Flat;
            btnListAll.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnListAll.ForeColor = Color.White;
            btnListAll.Location = new Point(796, 24);
            btnListAll.Name = "btnListAll";
            btnListAll.Size = new Size(180, 43);
            btnListAll.TabIndex = 2;
            btnListAll.Text = "Tümünü Listele";
            btnListAll.UseVisualStyleBackColor = false;
            btnListAll.Click += btnListAll_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.GridColor = Color.FromArgb(116, 142, 191);
            dgvProducts.Location = new Point(12, 46);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(964, 319);
            dgvProducts.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(116, 142, 191);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 11.25F);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(12, 117);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(180, 54);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Yeni Ürün Ekle";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(116, 142, 191);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 11.25F);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(216, 117);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(180, 54);
            btnEdit.TabIndex = 5;
            btnEdit.Text = "Güncelle";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(116, 142, 191);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 11.25F);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(424, 117);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(180, 54);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Sil";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(116, 142, 191);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(610, 24);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(180, 43);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "Ara";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dgvProducts);
            panel1.Location = new Point(12, 51);
            panel1.Name = "panel1";
            panel1.Size = new Size(989, 380);
            panel1.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(12, 15);
            label2.Name = "label2";
            label2.Size = new Size(105, 21);
            label2.TabIndex = 0;
            label2.Text = "Tüm Ürünler";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtSearch);
            panel2.Controls.Add(btnListAll);
            panel2.Controls.Add(btnEdit);
            panel2.Controls.Add(btnSearch);
            panel2.Controls.Add(btnAdd);
            panel2.Controls.Add(btnDelete);
            panel2.Location = new Point(12, 460);
            panel2.Name = "panel2";
            panel2.Size = new Size(989, 205);
            panel2.TabIndex = 10;
            // 
            // close
            // 
            close.BackColor = Color.Firebrick;
            close.FlatAppearance.BorderColor = Color.Black;
            close.FlatStyle = FlatStyle.Flat;
            close.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            close.ForeColor = Color.White;
            close.Location = new Point(962, 12);
            close.Name = "close";
            close.Size = new Size(39, 28);
            close.TabIndex = 11;
            close.Text = "X";
            close.UseVisualStyleBackColor = false;
            close.Click += close_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(12, 14);
            label3.Name = "label3";
            label3.Size = new Size(141, 25);
            label3.TabIndex = 12;
            label3.Text = "Ürün Yönetimi";
            // 
            // frmProducts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1013, 677);
            Controls.Add(label3);
            Controls.Add(close);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "frmProducts";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ürün Yönetimi";
            Load += frmProducts_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
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
        private Button btnListAll;
        private DataGridView dgvProducts;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnSearch;
        private Panel panel1;
        private Panel panel2;
        private Label label2;
        private Button close;
        private Label label3;
    }
}