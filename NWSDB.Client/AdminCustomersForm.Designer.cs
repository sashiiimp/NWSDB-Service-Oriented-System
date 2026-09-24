namespace NWSDB.Client
{
    partial class AdminCustomersForm
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
            dgvCustomers = new DataGridView();
            colAccountNumber = new DataGridViewTextBoxColumn();
            colFullName = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            colAddress = new DataGridViewTextBoxColumn();
            colConnectionCount = new DataGridViewTextBoxColumn();
            dgvCustomerConnections = new DataGridView();
            colConnectionNumber = new DataGridViewTextBoxColumn();
            colConnectionAddress = new DataGridViewTextBoxColumn();
            colConnectionStatus = new DataGridViewTextBoxColumn();
            lblSummary = new Label();
            lblConnectionsFor = new Label();
            btnClose = new Button();
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCustomerConnections).BeginInit();
            SuspendLayout();
            // 
            // dgvCustomers
            // 
            dgvCustomers.Columns.AddRange(new DataGridViewColumn[] { colAccountNumber, colFullName, colEmail, colPhone, colAddress, colConnectionCount });
            dgvCustomers.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvCustomers.Location = new Point(20, 110);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.Size = new Size(860, 220);
            dgvCustomers.TabIndex = 0;
            dgvCustomers.SelectionChanged += dgvCustomers_SelectionChanged;
            // 
            // colAccountNumber
            // 
            colAccountNumber.DataPropertyName = "AccountNumber";
            colAccountNumber.FillWeight = 70F;
            colAccountNumber.HeaderText = "Account No.";
            colAccountNumber.Name = "colAccountNumber";
            colAccountNumber.ReadOnly = true;
            // 
            // colFullName
            // 
            colFullName.DataPropertyName = "FullName";
            colFullName.FillWeight = 110F;
            colFullName.HeaderText = "Full Name";
            colFullName.Name = "colFullName";
            colFullName.ReadOnly = true;
            // 
            // colEmail
            // 
            colEmail.DataPropertyName = "Email";
            colEmail.FillWeight = 130F;
            colEmail.HeaderText = "Email";
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // colPhone
            // 
            colPhone.DataPropertyName = "Phone";
            colPhone.FillWeight = 75F;
            colPhone.HeaderText = "Phone";
            colPhone.Name = "colPhone";
            colPhone.ReadOnly = true;
            // 
            // colAddress
            // 
            colAddress.DataPropertyName = "Address";
            colAddress.FillWeight = 150F;
            colAddress.HeaderText = "Address";
            colAddress.Name = "colAddress";
            colAddress.ReadOnly = true;
            // 
            // colConnectionCount
            // 
            colConnectionCount.DataPropertyName = "ConnectionCount";
            colConnectionCount.FillWeight = 60F;
            colConnectionCount.HeaderText = "Connections";
            colConnectionCount.Name = "colConnectionCount";
            colConnectionCount.ReadOnly = true;
            // 
            // dgvCustomerConnections
            // 
            dgvCustomerConnections.Columns.AddRange(new DataGridViewColumn[] { colConnectionNumber, colConnectionAddress, colConnectionStatus });
            dgvCustomerConnections.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvCustomerConnections.Location = new Point(20, 368);
            dgvCustomerConnections.Name = "dgvCustomerConnections";
            dgvCustomerConnections.Size = new Size(860, 125);
            dgvCustomerConnections.TabIndex = 1;
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
            colConnectionAddress.FillWeight = 220F;
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
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.ForeColor = Color.FromArgb(90, 98, 110);
            lblSummary.Location = new Point(20, 84);
            lblSummary.Name = "lblSummary";
            lblSummary.TabIndex = 2;
            lblSummary.Text = "Loading...";
            // 
            // lblConnectionsFor
            // 
            lblConnectionsFor.AutoSize = true;
            lblConnectionsFor.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblConnectionsFor.ForeColor = Color.FromArgb(11, 79, 138);
            lblConnectionsFor.Location = new Point(20, 342);
            lblConnectionsFor.Name = "lblConnectionsFor";
            lblConnectionsFor.TabIndex = 3;
            lblConnectionsFor.Text = "Connections";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.White;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(11, 79, 138);
            btnClose.FlatAppearance.BorderSize = 1;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.FromArgb(11, 79, 138);
            btnClose.Location = new Point(770, 508);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(110, 38);
            btnClose.TabIndex = 4;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(11, 79, 138);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(900, 72);
            pnlHeader.TabIndex = 5;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Registered Customers";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.ForeColor = Color.FromArgb(214, 228, 242);
            lblSubtitle.Location = new Point(22, 42);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "All NWSDB customer accounts and their water connections";
            // 
            // AdminCustomersForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(244, 247, 251);
            CancelButton = btnClose;
            ClientSize = new Size(900, 560);
            Controls.Add(dgvCustomers);
            Controls.Add(dgvCustomerConnections);
            Controls.Add(lblSummary);
            Controls.Add(lblConnectionsFor);
            Controls.Add(btnClose);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AdminCustomersForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registered Customers";
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCustomerConnections).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCustomers;
        private DataGridViewTextBoxColumn colAccountNumber;
        private DataGridViewTextBoxColumn colFullName;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colPhone;
        private DataGridViewTextBoxColumn colAddress;
        private DataGridViewTextBoxColumn colConnectionCount;
        private DataGridView dgvCustomerConnections;
        private DataGridViewTextBoxColumn colConnectionNumber;
        private DataGridViewTextBoxColumn colConnectionAddress;
        private DataGridViewTextBoxColumn colConnectionStatus;
        private Label lblSummary;
        private Label lblConnectionsFor;
        private Button btnClose;
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
    }
}
