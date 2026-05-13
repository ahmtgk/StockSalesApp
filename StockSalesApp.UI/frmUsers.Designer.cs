namespace StockSalesApp.UI
{
    partial class frmUsers
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
            dgvUsers = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            panel1 = new Panel();
            btnListAll = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(12, 57);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(632, 496);
            dgvUsers.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(116, 142, 191);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 11.25F);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(666, 160);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(141, 55);
            btnAdd.TabIndex = 16;
            btnAdd.Text = "Yeni Kullanıcı";
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
            btnEdit.Location = new Point(666, 286);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(141, 55);
            btnEdit.TabIndex = 17;
            btnEdit.Text = "Güncelle";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(200, 80, 60);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 100, 80);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 11.25F);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(666, 409);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(141, 55);
            btnDelete.TabIndex = 18;
            btnDelete.Text = "Sil";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnListAll);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dgvUsers);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnAdd);
            panel1.Controls.Add(btnEdit);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(822, 568);
            panel1.TabIndex = 19;
            // 
            // btnListAll
            // 
            btnListAll.BackColor = Color.FromArgb(116, 142, 191);
            btnListAll.FlatAppearance.BorderSize = 0;
            btnListAll.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnListAll.FlatStyle = FlatStyle.Flat;
            btnListAll.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnListAll.ForeColor = Color.White;
            btnListAll.Location = new Point(525, 10);
            btnListAll.Name = "btnListAll";
            btnListAll.Size = new Size(120, 31);
            btnListAll.TabIndex = 22;
            btnListAll.Text = "Tümünü Listele";
            btnListAll.UseVisualStyleBackColor = false;
            btnListAll.Click += btnListAll_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(116, 142, 191);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 11.25F);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(399, 10);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(120, 31);
            btnSearch.TabIndex = 21;
            btnSearch.Text = "Ara";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtSearch.Location = new Point(113, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(280, 27);
            txtSearch.TabIndex = 20;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(95, 20);
            label1.TabIndex = 19;
            label1.Text = "Kullanıcı Ara:";
            // 
            // frmUsers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(847, 592);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "frmUsers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kullanıcı Yönetimi";
            Load += frmUsers_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvUsers;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Panel panel1;
        private TextBox txtSearch;
        private Label label1;
        private Button btnSearch;
        private Button btnListAll;
    }
}