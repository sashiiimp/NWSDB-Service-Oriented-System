namespace NWSDB.Client
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            lblAccountNumber = new Label();
            txtAccountNumber = new TextBox();
            btnLogin = new Button();
            lblHint = new Label();
            lblServer = new Label();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(11, 79, 138);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(460, 110);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 17.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(46, 26);
            lblTitle.Name = "lblTitle";
            lblTitle.TabIndex = 0;
            lblTitle.Text = "NWSDB Water Billing System";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.ForeColor = Color.FromArgb(214, 228, 242);
            lblSubtitle.Location = new Point(49, 66);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Customer Self-Service Portal";
            // 
            // lblAccountNumber
            // 
            lblAccountNumber.AutoSize = true;
            lblAccountNumber.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAccountNumber.Location = new Point(50, 145);
            lblAccountNumber.Name = "lblAccountNumber";
            lblAccountNumber.TabIndex = 1;
            lblAccountNumber.Text = "Account Number";
            // 
            // txtAccountNumber
            // 
            txtAccountNumber.CharacterCasing = CharacterCasing.Upper;
            txtAccountNumber.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAccountNumber.Location = new Point(50, 170);
            txtAccountNumber.MaxLength = 20;
            txtAccountNumber.Name = "txtAccountNumber";
            txtAccountNumber.PlaceholderText = "e.g. NW-100001";
            txtAccountNumber.Size = new Size(360, 29);
            txtAccountNumber.TabIndex = 2;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(11, 79, 138);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderColor = Color.FromArgb(11, 79, 138);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(50, 218);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(360, 42);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblHint
            // 
            lblHint.AutoSize = true;
            lblHint.ForeColor = Color.FromArgb(90, 98, 110);
            lblHint.Location = new Point(50, 275);
            lblHint.Name = "lblHint";
            lblHint.TabIndex = 4;
            lblHint.Text = "Enter the account number printed on your water bill.";
            // 
            // lblServer
            // 
            lblServer.AutoSize = true;
            lblServer.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblServer.ForeColor = Color.FromArgb(90, 98, 110);
            lblServer.Location = new Point(50, 360);
            lblServer.Name = "lblServer";
            lblServer.TabIndex = 5;
            lblServer.Text = "Service:";
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(244, 247, 251);
            ClientSize = new Size(460, 400);
            Controls.Add(pnlHeader);
            Controls.Add(lblAccountNumber);
            Controls.Add(txtAccountNumber);
            Controls.Add(btnLogin);
            Controls.Add(lblHint);
            Controls.Add(lblServer);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NWSDB Customer Login";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblAccountNumber;
        private TextBox txtAccountNumber;
        private Button btnLogin;
        private Label lblHint;
        private Label lblServer;
    }
}
