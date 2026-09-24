namespace NWSDB.Client
{
    partial class DashboardForm
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
            grpConnections = new GroupBox();
            dgvConnections = new DataGridView();
            colConnectionNumber = new DataGridViewTextBoxColumn();
            colConnectionAddress = new DataGridViewTextBoxColumn();
            colConnectionStatus = new DataGridViewTextBoxColumn();
            grpProfile = new GroupBox();
            lblNameCaption = new Label();
            lblName = new Label();
            lblAccountNumberCaption = new Label();
            lblAccountNumber = new Label();
            lblEmailCaption = new Label();
            lblEmail = new Label();
            lblPhoneCaption = new Label();
            lblPhone = new Label();
            lblAddressCaption = new Label();
            lblAddress = new Label();
            pnlNav = new Panel();
            btnCurrentUsage = new Button();
            btnUsageHistory = new Button();
            btnCurrentBill = new Button();
            btnBillHistory = new Button();
            btnMakePayment = new Button();
            btnPaymentHistory = new Button();
            btnLogout = new Button();
            pnlHeader = new Panel();
            lblWelcome = new Label();
            lblAccountHeader = new Label();
            grpConnections.SuspendLayout();
            grpProfile.SuspendLayout();
            pnlNav.SuspendLayout();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvConnections).BeginInit();
            SuspendLayout();
            // 
            // grpConnections
            // 
            grpConnections.BackColor = Color.White;
            grpConnections.Controls.Add(dgvConnections);
            grpConnections.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpConnections.ForeColor = Color.FromArgb(11, 79, 138);
            grpConnections.Location = new Point(230, 300);
            grpConnections.Name = "grpConnections";
            grpConnections.Padding = new Padding(12, 8, 12, 12);
            grpConnections.Size = new Size(650, 260);
            grpConnections.TabIndex = 0;
            grpConnections.TabStop = false;
            grpConnections.Text = "Water Connections";
            // 
            // dgvConnections
            // 
            dgvConnections.Columns.AddRange(new DataGridViewColumn[] { colConnectionNumber, colConnectionAddress, colConnectionStatus });
            dgvConnections.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvConnections.Location = new Point(12, 30);
            dgvConnections.Name = "dgvConnections";
            dgvConnections.Size = new Size(626, 218);
            dgvConnections.TabIndex = 0;
            // 
            // colConnectionNumber
            // 
            colConnectionNumber.DataPropertyName = "ConnectionNumber";
            colConnectionNumber.FillWeight = 80F;
            colConnectionNumber.HeaderText = "Connection No.";
            colConnectionNumber.Name = "colConnectionNumber";
            colConnectionNumber.ReadOnly = true;
            // 
            // colConnectionAddress
            // 
            colConnectionAddress.DataPropertyName = "ConnectionAddress";
            colConnectionAddress.FillWeight = 170F;
            colConnectionAddress.HeaderText = "Connection Address";
            colConnectionAddress.Name = "colConnectionAddress";
            colConnectionAddress.ReadOnly = true;
            // 
            // colConnectionStatus
            // 
            colConnectionStatus.DataPropertyName = "Status";
            colConnectionStatus.FillWeight = 60F;
            colConnectionStatus.HeaderText = "Status";
            colConnectionStatus.Name = "colConnectionStatus";
            colConnectionStatus.ReadOnly = true;
            // 
            // grpProfile
            // 
            grpProfile.BackColor = Color.White;
            grpProfile.Controls.Add(lblNameCaption);
            grpProfile.Controls.Add(lblName);
            grpProfile.Controls.Add(lblAccountNumberCaption);
            grpProfile.Controls.Add(lblAccountNumber);
            grpProfile.Controls.Add(lblEmailCaption);
            grpProfile.Controls.Add(lblEmail);
            grpProfile.Controls.Add(lblPhoneCaption);
            grpProfile.Controls.Add(lblPhone);
            grpProfile.Controls.Add(lblAddressCaption);
            grpProfile.Controls.Add(lblAddress);
            grpProfile.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpProfile.ForeColor = Color.FromArgb(11, 79, 138);
            grpProfile.Location = new Point(230, 95);
            grpProfile.Name = "grpProfile";
            grpProfile.Padding = new Padding(12, 8, 12, 12);
            grpProfile.Size = new Size(650, 190);
            grpProfile.TabIndex = 1;
            grpProfile.TabStop = false;
            grpProfile.Text = "Customer Profile";
            // 
            // lblNameCaption
            // 
            lblNameCaption.AutoSize = true;
            lblNameCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNameCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblNameCaption.Location = new Point(20, 32);
            lblNameCaption.Name = "lblNameCaption";
            lblNameCaption.TabIndex = 0;
            lblNameCaption.Text = "Full Name";
            // 
            // lblName
            // 
            lblName.AutoEllipsis = true;
            lblName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.FromArgb(33, 37, 41);
            lblName.Location = new Point(170, 32);
            lblName.Name = "lblName";
            lblName.Size = new Size(460, 23);
            lblName.TabIndex = 1;
            lblName.Text = "-";
            // 
            // lblAccountNumberCaption
            // 
            lblAccountNumberCaption.AutoSize = true;
            lblAccountNumberCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAccountNumberCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblAccountNumberCaption.Location = new Point(20, 62);
            lblAccountNumberCaption.Name = "lblAccountNumberCaption";
            lblAccountNumberCaption.TabIndex = 2;
            lblAccountNumberCaption.Text = "Account Number";
            // 
            // lblAccountNumber
            // 
            lblAccountNumber.AutoEllipsis = true;
            lblAccountNumber.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAccountNumber.ForeColor = Color.FromArgb(33, 37, 41);
            lblAccountNumber.Location = new Point(170, 62);
            lblAccountNumber.Name = "lblAccountNumber";
            lblAccountNumber.Size = new Size(460, 23);
            lblAccountNumber.TabIndex = 3;
            lblAccountNumber.Text = "-";
            // 
            // lblEmailCaption
            // 
            lblEmailCaption.AutoSize = true;
            lblEmailCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmailCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblEmailCaption.Location = new Point(20, 92);
            lblEmailCaption.Name = "lblEmailCaption";
            lblEmailCaption.TabIndex = 4;
            lblEmailCaption.Text = "Email";
            // 
            // lblEmail
            // 
            lblEmail.AutoEllipsis = true;
            lblEmail.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.FromArgb(33, 37, 41);
            lblEmail.Location = new Point(170, 92);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(460, 23);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "-";
            // 
            // lblPhoneCaption
            // 
            lblPhoneCaption.AutoSize = true;
            lblPhoneCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPhoneCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblPhoneCaption.Location = new Point(20, 122);
            lblPhoneCaption.Name = "lblPhoneCaption";
            lblPhoneCaption.TabIndex = 6;
            lblPhoneCaption.Text = "Phone";
            // 
            // lblPhone
            // 
            lblPhone.AutoEllipsis = true;
            lblPhone.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPhone.ForeColor = Color.FromArgb(33, 37, 41);
            lblPhone.Location = new Point(170, 122);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(460, 23);
            lblPhone.TabIndex = 7;
            lblPhone.Text = "-";
            // 
            // lblAddressCaption
            // 
            lblAddressCaption.AutoSize = true;
            lblAddressCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddressCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblAddressCaption.Location = new Point(20, 152);
            lblAddressCaption.Name = "lblAddressCaption";
            lblAddressCaption.TabIndex = 8;
            lblAddressCaption.Text = "Address";
            // 
            // lblAddress
            // 
            lblAddress.AutoEllipsis = true;
            lblAddress.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddress.ForeColor = Color.FromArgb(33, 37, 41);
            lblAddress.Location = new Point(170, 152);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(460, 23);
            lblAddress.TabIndex = 9;
            lblAddress.Text = "-";
            // 
            // pnlNav
            // 
            pnlNav.BackColor = Color.White;
            pnlNav.Controls.Add(btnCurrentUsage);
            pnlNav.Controls.Add(btnUsageHistory);
            pnlNav.Controls.Add(btnCurrentBill);
            pnlNav.Controls.Add(btnBillHistory);
            pnlNav.Controls.Add(btnMakePayment);
            pnlNav.Controls.Add(btnPaymentHistory);
            pnlNav.Controls.Add(btnLogout);
            pnlNav.Dock = DockStyle.Left;
            pnlNav.Location = new Point(0, 80);
            pnlNav.Name = "pnlNav";
            pnlNav.Size = new Size(210, 500);
            pnlNav.TabIndex = 2;
            // 
            // btnCurrentUsage
            // 
            btnCurrentUsage.BackColor = Color.White;
            btnCurrentUsage.Cursor = Cursors.Hand;
            btnCurrentUsage.FlatAppearance.BorderColor = Color.FromArgb(11, 79, 138);
            btnCurrentUsage.FlatAppearance.BorderSize = 1;
            btnCurrentUsage.FlatStyle = FlatStyle.Flat;
            btnCurrentUsage.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCurrentUsage.ForeColor = Color.FromArgb(11, 79, 138);
            btnCurrentUsage.Location = new Point(15, 20);
            btnCurrentUsage.Name = "btnCurrentUsage";
            btnCurrentUsage.Padding = new Padding(10, 0, 0, 0);
            btnCurrentUsage.Size = new Size(180, 42);
            btnCurrentUsage.TabIndex = 0;
            btnCurrentUsage.Text = "Current Usage";
            btnCurrentUsage.TextAlign = ContentAlignment.MiddleLeft;
            btnCurrentUsage.UseVisualStyleBackColor = false;
            btnCurrentUsage.Click += btnCurrentUsage_Click;
            // 
            // btnUsageHistory
            // 
            btnUsageHistory.BackColor = Color.White;
            btnUsageHistory.Cursor = Cursors.Hand;
            btnUsageHistory.FlatAppearance.BorderColor = Color.FromArgb(11, 79, 138);
            btnUsageHistory.FlatAppearance.BorderSize = 1;
            btnUsageHistory.FlatStyle = FlatStyle.Flat;
            btnUsageHistory.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUsageHistory.ForeColor = Color.FromArgb(11, 79, 138);
            btnUsageHistory.Location = new Point(15, 72);
            btnUsageHistory.Name = "btnUsageHistory";
            btnUsageHistory.Padding = new Padding(10, 0, 0, 0);
            btnUsageHistory.Size = new Size(180, 42);
            btnUsageHistory.TabIndex = 1;
            btnUsageHistory.Text = "Usage History";
            btnUsageHistory.TextAlign = ContentAlignment.MiddleLeft;
            btnUsageHistory.UseVisualStyleBackColor = false;
            btnUsageHistory.Click += btnUsageHistory_Click;
            // 
            // btnCurrentBill
            // 
            btnCurrentBill.BackColor = Color.White;
            btnCurrentBill.Cursor = Cursors.Hand;
            btnCurrentBill.FlatAppearance.BorderColor = Color.FromArgb(11, 79, 138);
            btnCurrentBill.FlatAppearance.BorderSize = 1;
            btnCurrentBill.FlatStyle = FlatStyle.Flat;
            btnCurrentBill.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCurrentBill.ForeColor = Color.FromArgb(11, 79, 138);
            btnCurrentBill.Location = new Point(15, 124);
            btnCurrentBill.Name = "btnCurrentBill";
            btnCurrentBill.Padding = new Padding(10, 0, 0, 0);
            btnCurrentBill.Size = new Size(180, 42);
            btnCurrentBill.TabIndex = 2;
            btnCurrentBill.Text = "Current Bill";
            btnCurrentBill.TextAlign = ContentAlignment.MiddleLeft;
            btnCurrentBill.UseVisualStyleBackColor = false;
            btnCurrentBill.Click += btnCurrentBill_Click;
            // 
            // btnBillHistory
            // 
            btnBillHistory.BackColor = Color.White;
            btnBillHistory.Cursor = Cursors.Hand;
            btnBillHistory.FlatAppearance.BorderColor = Color.FromArgb(11, 79, 138);
            btnBillHistory.FlatAppearance.BorderSize = 1;
            btnBillHistory.FlatStyle = FlatStyle.Flat;
            btnBillHistory.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBillHistory.ForeColor = Color.FromArgb(11, 79, 138);
            btnBillHistory.Location = new Point(15, 176);
            btnBillHistory.Name = "btnBillHistory";
            btnBillHistory.Padding = new Padding(10, 0, 0, 0);
            btnBillHistory.Size = new Size(180, 42);
            btnBillHistory.TabIndex = 3;
            btnBillHistory.Text = "Bill History";
            btnBillHistory.TextAlign = ContentAlignment.MiddleLeft;
            btnBillHistory.UseVisualStyleBackColor = false;
            btnBillHistory.Click += btnBillHistory_Click;
            // 
            // btnMakePayment
            // 
            btnMakePayment.BackColor = Color.White;
            btnMakePayment.Cursor = Cursors.Hand;
            btnMakePayment.FlatAppearance.BorderColor = Color.FromArgb(11, 79, 138);
            btnMakePayment.FlatAppearance.BorderSize = 1;
            btnMakePayment.FlatStyle = FlatStyle.Flat;
            btnMakePayment.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMakePayment.ForeColor = Color.FromArgb(11, 79, 138);
            btnMakePayment.Location = new Point(15, 228);
            btnMakePayment.Name = "btnMakePayment";
            btnMakePayment.Padding = new Padding(10, 0, 0, 0);
            btnMakePayment.Size = new Size(180, 42);
            btnMakePayment.TabIndex = 4;
            btnMakePayment.Text = "Make Payment";
            btnMakePayment.TextAlign = ContentAlignment.MiddleLeft;
            btnMakePayment.UseVisualStyleBackColor = false;
            btnMakePayment.Click += btnMakePayment_Click;
            // 
            // btnPaymentHistory
            // 
            btnPaymentHistory.BackColor = Color.White;
            btnPaymentHistory.Cursor = Cursors.Hand;
            btnPaymentHistory.FlatAppearance.BorderColor = Color.FromArgb(11, 79, 138);
            btnPaymentHistory.FlatAppearance.BorderSize = 1;
            btnPaymentHistory.FlatStyle = FlatStyle.Flat;
            btnPaymentHistory.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPaymentHistory.ForeColor = Color.FromArgb(11, 79, 138);
            btnPaymentHistory.Location = new Point(15, 280);
            btnPaymentHistory.Name = "btnPaymentHistory";
            btnPaymentHistory.Padding = new Padding(10, 0, 0, 0);
            btnPaymentHistory.Size = new Size(180, 42);
            btnPaymentHistory.TabIndex = 5;
            btnPaymentHistory.Text = "Payment History";
            btnPaymentHistory.TextAlign = ContentAlignment.MiddleLeft;
            btnPaymentHistory.UseVisualStyleBackColor = false;
            btnPaymentHistory.Click += btnPaymentHistory_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(11, 79, 138);
            btnLogout.BackColor = Color.FromArgb(200, 35, 51);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderColor = Color.FromArgb(11, 79, 138);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(15, 440);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(180, 42);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(11, 79, 138);
            pnlHeader.Controls.Add(lblWelcome);
            pnlHeader.Controls.Add(lblAccountHeader);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(900, 80);
            pnlHeader.TabIndex = 3;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(20, 10);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome";
            // 
            // lblAccountHeader
            // 
            lblAccountHeader.AutoSize = true;
            lblAccountHeader.ForeColor = Color.FromArgb(214, 228, 242);
            lblAccountHeader.Location = new Point(22, 46);
            lblAccountHeader.Name = "lblAccountHeader";
            lblAccountHeader.TabIndex = 1;
            lblAccountHeader.Text = "Account No:";
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(244, 247, 251);
            ClientSize = new Size(900, 580);
            Controls.Add(grpConnections);
            Controls.Add(grpProfile);
            Controls.Add(pnlNav);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NWSDB Water Billing System - Dashboard";
            Load += DashboardForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvConnections).EndInit();
            grpConnections.ResumeLayout(false);
            grpProfile.ResumeLayout(false);
            grpProfile.PerformLayout();
            pnlNav.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpConnections;
        private DataGridView dgvConnections;
        private DataGridViewTextBoxColumn colConnectionNumber;
        private DataGridViewTextBoxColumn colConnectionAddress;
        private DataGridViewTextBoxColumn colConnectionStatus;
        private GroupBox grpProfile;
        private Label lblNameCaption;
        private Label lblName;
        private Label lblAccountNumberCaption;
        private Label lblAccountNumber;
        private Label lblEmailCaption;
        private Label lblEmail;
        private Label lblPhoneCaption;
        private Label lblPhone;
        private Label lblAddressCaption;
        private Label lblAddress;
        private Panel pnlNav;
        private Button btnCurrentUsage;
        private Button btnUsageHistory;
        private Button btnCurrentBill;
        private Button btnBillHistory;
        private Button btnMakePayment;
        private Button btnPaymentHistory;
        private Button btnLogout;
        private Panel pnlHeader;
        private Label lblWelcome;
        private Label lblAccountHeader;
    }
}
