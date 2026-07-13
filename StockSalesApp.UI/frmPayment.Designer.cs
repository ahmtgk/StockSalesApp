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
            lblMixedChange = new Label();
            txtMixedCashGiven = new TextBox();
            label7 = new Label();
            btnConfirm = new Button();
            btnCancel = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            grpPaymentMethod.SuspendLayout();
            grpCash.SuspendLayout();
            grpBank.SuspendLayout();
            grpMixedCash.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblTotalAmount.Location = new Point(790, 414);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(217, 25);
            lblTotalAmount.TabIndex = 0;
            lblTotalAmount.Text = "Ödenecek Tutar: 0.00 ₺";
            // 
            // grpPaymentMethod
            // 
            grpPaymentMethod.Controls.Add(panel3);
            grpPaymentMethod.Controls.Add(panel2);
            grpPaymentMethod.Controls.Add(panel1);
            grpPaymentMethod.Controls.Add(btnCancel);
            grpPaymentMethod.Controls.Add(btnConfirm);
            grpPaymentMethod.Controls.Add(rbMixed);
            grpPaymentMethod.Controls.Add(lblTotalAmount);
            grpPaymentMethod.Controls.Add(rbBank);
            grpPaymentMethod.Controls.Add(rbCash);
            grpPaymentMethod.Location = new Point(12, 12);
            grpPaymentMethod.Name = "grpPaymentMethod";
            grpPaymentMethod.Size = new Size(1185, 525);
            grpPaymentMethod.TabIndex = 1;
            grpPaymentMethod.TabStop = false;
            grpPaymentMethod.Text = "Ödeme Yöntemi";
            // 
            // rbCash
            // 
            rbCash.AutoSize = true;
            rbCash.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            rbCash.Location = new Point(26, 40);
            rbCash.Name = "rbCash";
            rbCash.Size = new Size(70, 25);
            rbCash.TabIndex = 2;
            rbCash.TabStop = true;
            rbCash.Text = "Nakit";
            rbCash.UseVisualStyleBackColor = true;
            rbCash.CheckedChanged += rbCash_CheckedChanged;
            // 
            // rbBank
            // 
            rbBank.AutoSize = true;
            rbBank.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            rbBank.Location = new Point(416, 40);
            rbBank.Name = "rbBank";
            rbBank.Size = new Size(59, 25);
            rbBank.TabIndex = 3;
            rbBank.TabStop = true;
            rbBank.Text = "Kart";
            rbBank.UseVisualStyleBackColor = true;
            rbBank.CheckedChanged += rbBank_CheckedChanged;
            // 
            // rbMixed
            // 
            rbMixed.AutoSize = true;
            rbMixed.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            rbMixed.Location = new Point(806, 40);
            rbMixed.Name = "rbMixed";
            rbMixed.Size = new Size(177, 25);
            rbMixed.TabIndex = 4;
            rbMixed.TabStop = true;
            rbMixed.Text = "Karma (Nakit+Kart)";
            rbMixed.UseVisualStyleBackColor = true;
            rbMixed.CheckedChanged += rbMixed_CheckedChanged;
            // 
            // grpCash
            // 
            grpCash.BackColor = Color.WhiteSmoke;
            grpCash.Controls.Add(label2);
            grpCash.Controls.Add(txtCashGiven);
            grpCash.Controls.Add(label3);
            grpCash.Controls.Add(lblChange);
            grpCash.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            grpCash.Location = new Point(16, 18);
            grpCash.Name = "grpCash";
            grpCash.Size = new Size(350, 279);
            grpCash.TabIndex = 5;
            grpCash.TabStop = false;
            grpCash.Text = "Nakit Ödeme";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.Location = new Point(6, 36);
            label2.Name = "label2";
            label2.Size = new Size(93, 20);
            label2.TabIndex = 6;
            label2.Text = "Alınan Nakit:";
            // 
            // txtCashGiven
            // 
            txtCashGiven.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtCashGiven.Location = new Point(105, 29);
            txtCashGiven.Name = "txtCashGiven";
            txtCashGiven.Size = new Size(200, 27);
            txtCashGiven.TabIndex = 7;
            txtCashGiven.TextChanged += txtCashGiven_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(6, 85);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 8;
            label3.Text = "Para Üstü:";
            // 
            // lblChange
            // 
            lblChange.AutoSize = true;
            lblChange.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblChange.Location = new Point(93, 85);
            lblChange.Name = "lblChange";
            lblChange.Size = new Size(53, 20);
            lblChange.TabIndex = 9;
            lblChange.Text = "0,00 ₺";
            // 
            // grpBank
            // 
            grpBank.BackColor = Color.WhiteSmoke;
            grpBank.Controls.Add(label1);
            grpBank.Controls.Add(cmbBank);
            grpBank.Controls.Add(label4);
            grpBank.Controls.Add(txtBankAmount);
            grpBank.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            grpBank.Location = new Point(16, 18);
            grpBank.Name = "grpBank";
            grpBank.Size = new Size(350, 279);
            grpBank.TabIndex = 10;
            grpBank.TabStop = false;
            grpBank.Text = "Kart Ödeme";
            grpBank.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.Location = new Point(18, 72);
            label1.Name = "label1";
            label1.Size = new Size(91, 20);
            label1.TabIndex = 11;
            label1.Text = "Banka Seçin:";
            // 
            // cmbBank
            // 
            cmbBank.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBank.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            cmbBank.FormattingEnabled = true;
            cmbBank.Location = new Point(115, 69);
            cmbBank.Name = "cmbBank";
            cmbBank.Size = new Size(200, 28);
            cmbBank.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label4.Location = new Point(18, 162);
            label4.Name = "label4";
            label4.Size = new Size(81, 20);
            label4.TabIndex = 13;
            label4.Text = "Kart Tutarı:";
            // 
            // txtBankAmount
            // 
            txtBankAmount.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtBankAmount.Location = new Point(115, 159);
            txtBankAmount.Name = "txtBankAmount";
            txtBankAmount.Size = new Size(200, 27);
            txtBankAmount.TabIndex = 14;
            txtBankAmount.TextChanged += txtBankAmount_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label5.Location = new Point(6, 69);
            label5.Name = "label5";
            label5.Size = new Size(94, 20);
            label5.TabIndex = 15;
            label5.Text = "Kalan Nakit:";
            // 
            // lblRemainingCash
            // 
            lblRemainingCash.AutoSize = true;
            lblRemainingCash.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblRemainingCash.Location = new Point(106, 69);
            lblRemainingCash.Name = "lblRemainingCash";
            lblRemainingCash.Size = new Size(53, 20);
            lblRemainingCash.TabIndex = 16;
            lblRemainingCash.Text = "0,00 ₺";
            // 
            // grpMixedCash
            // 
            grpMixedCash.BackColor = Color.WhiteSmoke;
            grpMixedCash.Controls.Add(label5);
            grpMixedCash.Controls.Add(lblRemainingCash);
            grpMixedCash.Controls.Add(label6);
            grpMixedCash.Controls.Add(lblMixedChange);
            grpMixedCash.Controls.Add(txtMixedCashGiven);
            grpMixedCash.Controls.Add(label7);
            grpMixedCash.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            grpMixedCash.Location = new Point(16, 18);
            grpMixedCash.Name = "grpMixedCash";
            grpMixedCash.Size = new Size(350, 279);
            grpMixedCash.TabIndex = 17;
            grpMixedCash.TabStop = false;
            grpMixedCash.Text = "Karma — Nakit Kısım";
            grpMixedCash.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label6.Location = new Point(6, 139);
            label6.Name = "label6";
            label6.Size = new Size(93, 20);
            label6.TabIndex = 18;
            label6.Text = "Alınan Nakit:";
            // 
            // lblMixedChange
            // 
            lblMixedChange.AutoSize = true;
            lblMixedChange.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblMixedChange.Location = new Point(93, 208);
            lblMixedChange.Name = "lblMixedChange";
            lblMixedChange.Size = new Size(53, 20);
            lblMixedChange.TabIndex = 21;
            lblMixedChange.Text = "0,00 ₺";
            // 
            // txtMixedCashGiven
            // 
            txtMixedCashGiven.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtMixedCashGiven.Location = new Point(105, 136);
            txtMixedCashGiven.Name = "txtMixedCashGiven";
            txtMixedCashGiven.Size = new Size(200, 27);
            txtMixedCashGiven.TabIndex = 19;
            txtMixedCashGiven.TextChanged += txtMixedCashGiven_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label7.Location = new Point(6, 208);
            label7.Name = "label7";
            label7.Size = new Size(81, 20);
            label7.TabIndex = 20;
            label7.Text = "Para Üstü:";
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.FromArgb(116, 142, 191);
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Font = new Font("Segoe UI", 11.25F);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.Location = new Point(995, 466);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(179, 45);
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
            btnCancel.Location = new Point(790, 466);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(179, 45);
            btnCancel.TabIndex = 24;
            btnCancel.Text = "İptal";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(grpCash);
            panel1.Location = new Point(10, 82);
            panel1.Name = "panel1";
            panel1.Size = new Size(384, 313);
            panel1.TabIndex = 25;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Window;
            panel2.Controls.Add(grpBank);
            panel2.Location = new Point(400, 82);
            panel2.Name = "panel2";
            panel2.Size = new Size(384, 313);
            panel2.TabIndex = 26;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(grpMixedCash);
            panel3.Location = new Point(790, 82);
            panel3.Name = "panel3";
            panel3.Size = new Size(384, 313);
            panel3.TabIndex = 27;
            // 
            // frmPayment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1209, 550);
            Controls.Add(grpPaymentMethod);
            MaximizeBox = false;
            Name = "frmPayment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ödeme";
            Load += frmPayment_Load;
            grpPaymentMethod.ResumeLayout(false);
            grpPaymentMethod.PerformLayout();
            grpCash.ResumeLayout(false);
            grpCash.PerformLayout();
            grpBank.ResumeLayout(false);
            grpBank.PerformLayout();
            grpMixedCash.ResumeLayout(false);
            grpMixedCash.PerformLayout();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
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
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
    }
}