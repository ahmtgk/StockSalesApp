namespace StockSalesApp.UI
{
    partial class frmProductDetail
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtName = new TextBox();
            txtBarcode = new TextBox();
            txtPurchasePrice = new TextBox();
            txtSalePrice = new TextBox();
            txtStockQuantity = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F);
            label1.Location = new Point(28, 62);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 0;
            label1.Text = "Ürün Adı";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F);
            label2.Location = new Point(28, 102);
            label2.Name = "label2";
            label2.Size = new Size(56, 20);
            label2.TabIndex = 1;
            label2.Text = "Barkod";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F);
            label3.Location = new Point(28, 142);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 2;
            label3.Text = "Alış Fiyatı";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F);
            label4.Location = new Point(28, 182);
            label4.Name = "label4";
            label4.Size = new Size(79, 20);
            label4.TabIndex = 3;
            label4.Text = "Satış Fiyatı";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F);
            label5.Location = new Point(28, 222);
            label5.Name = "label5";
            label5.Size = new Size(88, 20);
            label5.TabIndex = 4;
            label5.Text = "Stok Miktarı";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 11.25F);
            txtName.Location = new Point(136, 62);
            txtName.Name = "txtName";
            txtName.Size = new Size(264, 27);
            txtName.TabIndex = 6;
            // 
            // txtBarcode
            // 
            txtBarcode.Font = new Font("Segoe UI", 11.25F);
            txtBarcode.Location = new Point(136, 99);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(264, 27);
            txtBarcode.TabIndex = 7;
            // 
            // txtPurchasePrice
            // 
            txtPurchasePrice.Font = new Font("Segoe UI", 11.25F);
            txtPurchasePrice.Location = new Point(136, 139);
            txtPurchasePrice.Name = "txtPurchasePrice";
            txtPurchasePrice.Size = new Size(264, 27);
            txtPurchasePrice.TabIndex = 8;
            // 
            // txtSalePrice
            // 
            txtSalePrice.Font = new Font("Segoe UI", 11.25F);
            txtSalePrice.Location = new Point(136, 179);
            txtSalePrice.Name = "txtSalePrice";
            txtSalePrice.Size = new Size(264, 27);
            txtSalePrice.TabIndex = 9;
            // 
            // txtStockQuantity
            // 
            txtStockQuantity.Font = new Font("Segoe UI", 11.25F);
            txtStockQuantity.Location = new Point(136, 219);
            txtStockQuantity.Name = "txtStockQuantity";
            txtStockQuantity.Size = new Size(264, 27);
            txtStockQuantity.TabIndex = 10;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(116, 142, 191);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11.25F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(136, 272);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(114, 45);
            btnSave.TabIndex = 12;
            btnSave.Text = "Kaydet";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(116, 142, 191);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11.25F);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(286, 272);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(114, 45);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "İptal";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtSalePrice);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtStockQuantity);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtPurchasePrice);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtBarcode);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(450, 377);
            panel1.TabIndex = 14;
            // 
            // frmProductDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(474, 401);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "frmProductDetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ürün Detay";
            Load += frmProductDetail_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtName;
        private TextBox txtBarcode;
        private TextBox txtPurchasePrice;
        private TextBox txtSalePrice;
        private TextBox txtStockQuantity;
        private Button btnSave;
        private Button btnCancel;
        private Panel panel1;
    }
}