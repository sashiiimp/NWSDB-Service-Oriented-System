namespace NWSDB.Client
{
    partial class AdminDashboardForm
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
            dgvConnections = new DataGridView();
            colConnectionNumber = new DataGridViewTextBoxColumn();
            colCustomerName = new DataGridViewTextBoxColumn();
            colAccountNumber = new DataGridViewTextBoxColumn();
            colConnectionAddress = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colLatestReading = new DataGridViewTextBoxColumn();
            colLatestReadingDate = new DataGridViewTextBoxColumn();
            lblSummary = new Label();
            btnRecordReading = new Button();
            btnGenerateBill = new Button();
            btnCustomers = new Button();
            btnRefresh = new Button();
            btnLogout = new Button();
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvConnections).BeginInit();
            SuspendLayout();
            // 
            // dgvConnections
            // 
            dgvConnections.Columns.AddRange(new DataGridViewColumn[] { colConnectionNumber, colCustomerName, colAccountNumber, colConnectionAddress, colStatus, colLatestReading, colLatestReadingDate });
            dgvConnections.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvConnections.Location = new Point(20, 115);
            dgvConnections.Name = "dgvConnections";
            dgvConnections.Size = new Size(960, 380);
            dgvConnections.TabIndex = 0;
            dgvConnections.SelectionChanged += dgvConnections_SelectionChanged;
            // 
            // colConnectionNumber
            // 
            colConnectionNumber.DataPropertyName = "ConnectionNumber";
            colConnectionNumber.FillWeight = 80F;
            colConnectionNumber.HeaderText = "Connection No.";
            colConnectionNumber.Name = "colConnectionNumber";
            colConnectionNumber.ReadOnly = true;
            // 
            // colCustomerName
            // 
            colCustomerName.DataPropertyName = "CustomerName";
            colCustomerName.FillWeight = 110F;
            colCustomerName.HeaderText = "Customer";
            colCustomerName.Name = "colCustomerName";
            colCustomerName.ReadOnly = true;
            // 
            // colAccountNumber
            // 
            colAccountNumber.DataPropertyName = "AccountNumber";
            colAccountNumber.FillWeight = 80F;
            colAccountNumber.HeaderText = "Account No.";
            colAccountNumber.Name = "colAccountNumber";
            colAccountNumber.ReadOnly = true;
            // 
            // colConnectionAddress
            // 
            colConnectionAddress.DataPropertyName = "ConnectionAddress";
            colConnectionAddress.FillWeight = 170F;
            colConnectionAddress.HeaderText = "Connection Address";
            colConnectionAddress.Name = "colConnectionAddress";
            colConnectionAddress.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "Status";
            colStatus.FillWeight = 60F;
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // colLatestReading
            // 
            colLatestReading.DataPropertyName = "LatestReading";
            colLatestReading.FillWeight = 75F;
            colLatestReading.HeaderText = "Latest Reading";
            colLatestReading.Name = "colLatestReading";
            colLatestReading.ReadOnly = true;
            // 
            // colLatestReadingDate
            // 
            colLatestReadingDate.DataPropertyName = "LatestReadingDate";
            colLatestReadingDate.FillWeight = 80F;
            colLatestReadingDate.HeaderText = "Reading Date";
            colLatestReadingDate.Name = "colLatestReadingDate";
            colLatestReadingDate.ReadOnly = true;
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.ForeColor = Color.FromArgb(90, 98, 110);
            lblSummary.Location = new Point(20, 88);
            lblSummary.Name = "lblSummary";
            lblSummary.TabIndex = 1;
            lblSummary.Text = "Loading...";
            // 
            // btnRecordReading
            // 
            btnRecordReading.BackColor = Color.FromArgb(11, 79, 138);
            btnRecordReading.Cursor = Cursors.Hand;
            btnRecordReading.FlatAppearance.BorderColor = Color.FromArgb(11, 79, 138);
            btnRecordReading.FlatAppearance.BorderSize = 0;
            btnRecordReading.FlatStyle = FlatStyle.Flat;
            btnRecordReading.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRecordReading.ForeColor = Color.White;
            btnRecordReading.Location = new Point(20, 510);
            btnRecordReading.Name = "btnRecordReading";
            btnRecordReading.Size = new Size(200, 40);
            btnRecordReading.TabIndex = 2;
            btnRecordReading.Text = "Record Meter Reading";
            btnRecordReading.UseVisualStyleBackColor = false;
            btnRecordReading.Click += btnRecordReading_Click;
            // 
            // btnGenerateBill
            // 
            btnGenerateBill.BackColor = Color.FromArgb(11, 79, 138);
            btnGenerateBill.Cursor = Cursors.Hand;
            btnGenerateBill.FlatAppearance.BorderColor = Color.FromArgb(11, 79, 138);
            btnGenerateBill.FlatAppearance.BorderSize = 0;
            btnGenerateBill.FlatStyle = FlatStyle.Flat;
            btnGenerateBill.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenerateBill.ForeColor = Color.White;
            btnGenerateBill.Location = new Point(230, 510);
            btnGenerateBill.Name = "btnGenerateBill";
            btnGenerateBill.Size = new Size(240, 40);
            btnGenerateBill.TabIndex = 3;
            btnGenerateBill.Text = "Generate Bill (Latest Reading)";
            btnGenerateBill.UseVisualStyleBackColor = false;
            btnGenerateBill.Click += btnGenerateBill_Click;
            // 
            // btnCustomers
            // 
            btnCustomers.BackColor = Color.White;
            btnCustomers.Cursor = Cursors.Hand;
            btnCustomers.FlatAppearance.BorderColor = Color.FromArgb(11, 79, 138);
            btnCustomers.FlatAppearance.BorderSize = 1;
            btnCustomers.FlatStyle = FlatStyle.Flat;
            btnCustomers.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCustomers.ForeColor = Color.FromArgb(11, 79, 138);
            btnCustomers.Location = new Point(480, 510);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Size = new Size(150, 40);
            btnCustomers.TabIndex = 4;
            btnCustomers.Text = "View Customers";
            btnCustomers.UseVisualStyleBackColor = false;
            btnCustomers.Click += btnCustomers_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.White;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(11, 79, 138);
            btnRefresh.FlatAppearance.BorderSize = 1;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.ForeColor = Color.FromArgb(11, 79, 138);
            btnRefresh.Location = new Point(640, 510);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(110, 40);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
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
            btnLogout.Location = new Point(870, 510);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(110, 40);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(11, 79, 138);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1000, 72);
            pnlHeader.TabIndex = 7;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.TabIndex = 0;
            lblTitle.Text = "NWSDB Admin Console";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.ForeColor = Color.FromArgb(214, 228, 242);
            lblSubtitle.Location = new Point(22, 42);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Signed in";
            // 
            // AdminDashboardForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(244, 247, 251);
            ClientSize = new Size(1000, 570);
            Controls.Add(dgvConnections);
            Controls.Add(lblSummary);
            Controls.Add(btnRecordReading);
            Controls.Add(btnGenerateBill);
            Controls.Add(btnCustomers);
            Controls.Add(btnRefresh);
            Controls.Add(btnLogout);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AdminDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NWSDB Admin Console";
            Load += AdminDashboardForm_Load;
            FormClosed += AdminDashboardForm_FormClosed;
            ((System.ComponentModel.ISupportInitialize)dgvConnections).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvConnections;
        private DataGridViewTextBoxColumn colConnectionNumber;
        private DataGridViewTextBoxColumn colCustomerName;
        private DataGridViewTextBoxColumn colAccountNumber;
        private DataGridViewTextBoxColumn colConnectionAddress;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colLatestReading;
        private DataGridViewTextBoxColumn colLatestReadingDate;
        private Label lblSummary;
        private Button btnRecordReading;
        private Button btnGenerateBill;
        private Button btnCustomers;
        private Button btnRefresh;
        private Button btnLogout;
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
    }
}
