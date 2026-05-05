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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 30);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "Ürün Adı";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 70);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 1;
            label2.Text = "Barkod";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 110);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 2;
            label3.Text = "Alış Fiyatı";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 150);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 3;
            label4.Text = "Satış Fiyatı";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 190);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 4;
            label5.Text = "Stok Fiyatı";
            // 
            // txtName
            // 
            txtName.Location = new Point(130, 27);
            txtName.Name = "txtName";
            txtName.Size = new Size(220, 23);
            txtName.TabIndex = 6;
            // 
            // txtBarcode
            // 
            txtBarcode.Location = new Point(130, 67);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(220, 23);
            txtBarcode.TabIndex = 7;
            // 
            // txtPurchasePrice
            // 
            txtPurchasePrice.Location = new Point(130, 107);
            txtPurchasePrice.Name = "txtPurchasePrice";
            txtPurchasePrice.Size = new Size(220, 23);
            txtPurchasePrice.TabIndex = 8;
            // 
            // txtSalePrice
            // 
            txtSalePrice.Location = new Point(130, 147);
            txtSalePrice.Name = "txtSalePrice";
            txtSalePrice.Size = new Size(220, 23);
            txtSalePrice.TabIndex = 11;
            // 
            // txtStockQuantity
            // 
            txtStockQuantity.Location = new Point(130, 187);
            txtStockQuantity.Name = "txtStockQuantity";
            txtStockQuantity.Size = new Size(220, 23);
            txtStockQuantity.TabIndex = 10;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(130, 240);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 12;
            btnSave.Text = "Kaydet";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(245, 240);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "İptal";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmProductDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 341);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtSalePrice);
            Controls.Add(txtStockQuantity);
            Controls.Add(txtPurchasePrice);
            Controls.Add(txtBarcode);
            Controls.Add(txtName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "frmProductDetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ürün Detay";
            ResumeLayout(false);
            PerformLayout();
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
    }
}