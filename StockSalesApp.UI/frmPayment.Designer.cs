namespace StockSalesApp.UI
{
    partial class frmPayment
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
            lblTotalAmount = new Label();
            grpPaymentMethod = new GroupBox();
            rbCash = new RadioButton();
            rbBank = new RadioButton();
            rbMixed = new RadioButton();
            grpCash = new GroupBox();
            label2 = new Label();
            txtCashGiven = new TextBox();
            label3 = new Label();
            lblChange = new Label();
            grpBank = new GroupBox();
            label1 = new Label();
            cmbBank = new ComboBox();
            label4 = new Label();
            txtBankAmount = new TextBox();
            label5 = new Label();
            lblRemainingCash = new Label();
            grpMixedCash = new GroupBox();
            label6 = new Label();
            txtMixedCashGiven = new TextBox();
            label7 = new Label();
            lblMixedChange = new Label();
            btnConfirm = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblTotalAmount.Location = new Point(20, 118);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(217, 25);
            lblTotalAmount.TabIndex = 0;
            lblTotalAmount.Text = "Ödenecek Tutar: 0.00 ₺";
            // 
            // grpPaymentMethod
            // 
            grpPaymentMethod.Location = new Point(704, 219);
            grpPaymentMethod.Name = "grpPaymentMethod";
            grpPaymentMethod.Size = new Size(445, 60);
            grpPaymentMethod.TabIndex = 1;
            grpPaymentMethod.TabStop = false;
            grpPaymentMethod.Text = "Ödeme Yöntemi";
            // 
            // rbCash
            // 
            rbCash.Location = new Point(587, 141);
            rbCash.Name = "rbCash";
            rbCash.Size = new Size(100, 20);
            rbCash.TabIndex = 2;
            rbCash.TabStop = true;
            rbCash.Text = "Nakit";
            rbCash.UseVisualStyleBackColor = true;
            rbCash.CheckedChanged += rbCash_CheckedChanged;
            // 
            // rbBank
            // 
            rbBank.Location = new Point(704, 141);
            rbBank.Name = "rbBank";
            rbBank.Size = new Size(100, 20);
            rbBank.TabIndex = 3;
            rbBank.TabStop = true;
            rbBank.Text = "Kart";
            rbBank.UseVisualStyleBackColor = true;
            rbBank.CheckedChanged += rbBank_CheckedChanged;
            // 
            // rbMixed
            // 
            rbMixed.Location = new Point(789, 141);
            rbMixed.Name = "rbMixed";
            rbMixed.Size = new Size(150, 20);
            rbMixed.TabIndex = 4;
            rbMixed.TabStop = true;
            rbMixed.Text = "Karma (Nakit+Kart)";
            rbMixed.UseVisualStyleBackColor = true;
            rbMixed.CheckedChanged += rbMixed_CheckedChanged;
            // 
            // grpCash
            // 
            grpCash.Location = new Point(704, 318);
            grpCash.Name = "grpCash";
            grpCash.Size = new Size(445, 110);
            grpCash.TabIndex = 5;
            grpCash.TabStop = false;
            grpCash.Text = "Nakit Ödeme";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 336);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 6;
            label2.Text = "Alınan Nakit:";
            // 
            // txtCashGiven
            // 
            txtCashGiven.Location = new Point(120, 281);
            txtCashGiven.Name = "txtCashGiven";
            txtCashGiven.Size = new Size(150, 23);
            txtCashGiven.TabIndex = 7;
            txtCashGiven.TextChanged += txtCashGiven_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 237);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 8;
            label3.Text = "Para Üstü:";
            // 
            // lblChange
            // 
            lblChange.AutoSize = true;
            lblChange.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblChange.Location = new Point(328, 471);
            lblChange.Name = "lblChange";
            lblChange.Size = new Size(41, 15);
            lblChange.TabIndex = 9;
            lblChange.Text = "0,00 ₺";
            // 
            // grpBank
            // 
            grpBank.Location = new Point(704, 471);
            grpBank.Name = "grpBank";
            grpBank.Size = new Size(445, 110);
            grpBank.TabIndex = 10;
            grpBank.TabStop = false;
            grpBank.Text = "Kart Ödeme";
            grpBank.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(681, 47);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 11;
            label1.Text = "Banka Seçin:";
            // 
            // cmbBank
            // 
            cmbBank.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBank.FormattingEnabled = true;
            cmbBank.Location = new Point(299, 154);
            cmbBank.Name = "cmbBank";
            cmbBank.Size = new Size(200, 23);
            cmbBank.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 193);
            label4.Name = "label4";
            label4.Size = new Size(65, 15);
            label4.TabIndex = 13;
            label4.Text = "Kart Tutarı:";
            // 
            // txtBankAmount
            // 
            txtBankAmount.Location = new Point(120, 185);
            txtBankAmount.Name = "txtBankAmount";
            txtBankAmount.Size = new Size(150, 23);
            txtBankAmount.TabIndex = 14;
            txtBankAmount.TextChanged += txtBankAmount_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(429, 118);
            label5.Name = "label5";
            label5.Size = new Size(70, 15);
            label5.TabIndex = 15;
            label5.Text = "Kalan Nakit:";
            // 
            // lblRemainingCash
            // 
            lblRemainingCash.AutoSize = true;
            lblRemainingCash.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblRemainingCash.Location = new Point(458, 86);
            lblRemainingCash.Name = "lblRemainingCash";
            lblRemainingCash.Size = new Size(41, 15);
            lblRemainingCash.TabIndex = 16;
            lblRemainingCash.Text = "0,00 ₺";
            // 
            // grpMixedCash
            // 
            grpMixedCash.Location = new Point(704, 628);
            grpMixedCash.Name = "grpMixedCash";
            grpMixedCash.Size = new Size(445, 80);
            grpMixedCash.TabIndex = 17;
            grpMixedCash.TabStop = false;
            grpMixedCash.Text = "Karma — Nakit Kısım";
            grpMixedCash.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(5, 289);
            label6.Name = "label6";
            label6.Size = new Size(75, 15);
            label6.TabIndex = 18;
            label6.Text = "Alınan Nakit:";
            // 
            // txtMixedCashGiven
            // 
            txtMixedCashGiven.Location = new Point(120, 229);
            txtMixedCashGiven.Name = "txtMixedCashGiven";
            txtMixedCashGiven.Size = new Size(150, 23);
            txtMixedCashGiven.TabIndex = 19;
            txtMixedCashGiven.TextChanged += txtMixedCashGiven_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(309, 86);
            label7.Name = "label7";
            label7.Size = new Size(60, 15);
            label7.TabIndex = 20;
            label7.Text = "Para Üstü:";
            // 
            // lblMixedChange
            // 
            lblMixedChange.AutoSize = true;
            lblMixedChange.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblMixedChange.Location = new Point(458, 47);
            lblMixedChange.Name = "lblMixedChange";
            lblMixedChange.Size = new Size(41, 15);
            lblMixedChange.TabIndex = 21;
            lblMixedChange.Text = "0,00 ₺";
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.FromArgb(116, 142, 191);
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Font = new Font("Segoe UI", 11.25F);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.Location = new Point(704, 747);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(200, 45);
            btnConfirm.TabIndex = 23;
            btnConfirm.Text = "Ödemeyi Tamamla";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(200, 80, 60);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 100, 80);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(1010, 747);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(200, 45);
            btnCancel.TabIndex = 24;
            btnCancel.Text = "İptal";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmPayment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1278, 870);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(lblMixedChange);
            Controls.Add(label7);
            Controls.Add(txtMixedCashGiven);
            Controls.Add(label6);
            Controls.Add(grpMixedCash);
            Controls.Add(lblRemainingCash);
            Controls.Add(label5);
            Controls.Add(txtBankAmount);
            Controls.Add(label4);
            Controls.Add(cmbBank);
            Controls.Add(label1);
            Controls.Add(grpBank);
            Controls.Add(lblChange);
            Controls.Add(label3);
            Controls.Add(txtCashGiven);
            Controls.Add(label2);
            Controls.Add(grpCash);
            Controls.Add(rbMixed);
            Controls.Add(rbBank);
            Controls.Add(rbCash);
            Controls.Add(grpPaymentMethod);
            Controls.Add(lblTotalAmount);
            MaximizeBox = false;
            Name = "frmPayment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ödeme";
            Load += frmPayment_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTotalAmount;
        private GroupBox grpPaymentMethod;
        private RadioButton rbCash;
        private RadioButton rbBank;
        private RadioButton rbMixed;
        private GroupBox grpCash;
        private Label label2;
        private TextBox txtCashGiven;
        private Label label3;
        private Label lblChange;
        private GroupBox grpBank;
        private Label label1;
        private ComboBox cmbBank;
        private Label label4;
        private TextBox txtBankAmount;
        private Label label5;
        private Label lblRemainingCash;
        private GroupBox grpMixedCash;
        private Label label6;
        private TextBox txtMixedCashGiven;
        private Label label7;
        private Label lblMixedChange;
        private Button btnConfirm;
        private Button btnCancel;
    }
}