namespace StockSalesApp.UI
{
    partial class frmUserDetail
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
            txtUsername = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            lblPasswordInfo = new Label();
            txtPassword = new TextBox();
            txtPasswordConfirm = new TextBox();
            cmbRole = new ComboBox();
            btnSave = new Button();
            chkShowPassword = new CheckBox();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F);
            label1.Location = new Point(23, 30);
            label1.Name = "label1";
            label1.Size = new Size(95, 20);
            label1.TabIndex = 0;
            label1.Text = "Kullanıcı Adı:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 11.25F);
            txtUsername.Location = new Point(124, 27);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(221, 27);
            txtUsername.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F);
            label2.Location = new Point(23, 80);
            label2.Name = "label2";
            label2.Size = new Size(42, 20);
            label2.TabIndex = 2;
            label2.Text = "Şifre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F);
            label3.Location = new Point(23, 130);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 3;
            label3.Text = "Şifre Tekrar:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F);
            label4.Location = new Point(23, 180);
            label4.Name = "label4";
            label4.Size = new Size(34, 20);
            label4.TabIndex = 4;
            label4.Text = "Rol:";
            // 
            // lblPasswordInfo
            // 
            lblPasswordInfo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblPasswordInfo.ForeColor = Color.Gray;
            lblPasswordInfo.Location = new Point(23, 346);
            lblPasswordInfo.Name = "lblPasswordInfo";
            lblPasswordInfo.Size = new Size(320, 30);
            lblPasswordInfo.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 11.25F);
            txtPassword.Location = new Point(124, 77);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(221, 27);
            txtPassword.TabIndex = 6;
            // 
            // txtPasswordConfirm
            // 
            txtPasswordConfirm.Font = new Font("Segoe UI", 11.25F);
            txtPasswordConfirm.Location = new Point(124, 127);
            txtPasswordConfirm.Name = "txtPasswordConfirm";
            txtPasswordConfirm.PasswordChar = '*';
            txtPasswordConfirm.Size = new Size(221, 27);
            txtPasswordConfirm.TabIndex = 7;
            // 
            // cmbRole
            // 
            cmbRole.Font = new Font("Segoe UI", 11.25F);
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(124, 177);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(221, 28);
            cmbRole.TabIndex = 8;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(116, 142, 191);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(133, 163, 219);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11.25F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(124, 280);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(221, 30);
            btnSave.TabIndex = 14;
            btnSave.Text = "Kaydet";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            chkShowPassword.Location = new Point(229, 230);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(116, 24);
            chkShowPassword.TabIndex = 15;
            chkShowPassword.Text = "Şifreyi Göster";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(cmbRole);
            panel1.Controls.Add(chkShowPassword);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtPasswordConfirm);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(lblPasswordInfo);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(398, 343);
            panel1.TabIndex = 16;
            // 
            // frmUserDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(422, 367);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "frmUserDetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kullanıcı Detay";
            Load += frmUserDetail_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox txtUsername;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblPasswordInfo;
        private TextBox txtPassword;
        private TextBox txtPasswordConfirm;
        private ComboBox cmbRole;
        private Button btnSave;
        private CheckBox chkShowPassword;
        private Panel panel1;
    }
}