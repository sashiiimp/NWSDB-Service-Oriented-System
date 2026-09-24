namespace NWSDB.Client
{
    partial class UsageHistoryForm
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
            dgvUsageHistory = new DataGridView();
            colReadingDate = new DataGridViewTextBoxColumn();
            colConnection = new DataGridViewTextBoxColumn();
            colPreviousReading = new DataGridViewTextBoxColumn();
            colCurrentReading = new DataGridViewTextBoxColumn();
            colUnitsConsumed = new DataGridViewTextBoxColumn();
            lblSummary = new Label();
            btnClose = new Button();
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblCustomer = new Label();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsageHistory).BeginInit();
            SuspendLayout();
            // 
            // dgvUsageHistory
            // 
            dgvUsageHistory.Columns.AddRange(new DataGridViewColumn[] { colReadingDate, colConnection, colPreviousReading, colCurrentReading, colUnitsConsumed });
            dgvUsageHistory.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvUsageHistory.Location = new Point(20, 110);
            dgvUsageHistory.Name = "dgvUsageHistory";
            dgvUsageHistory.Size = new Size(740, 320);
            dgvUsageHistory.TabIndex = 0;
            // 
            // colReadingDate
            // 
            colReadingDate.DataPropertyName = "ReadingDate";
            colReadingDate.FillWeight = 90F;
            colReadingDate.HeaderText = "Reading Date";
            colReadingDate.Name = "colReadingDate";
            colReadingDate.ReadOnly = true;
            // 
            // colConnection
            // 
            colConnection.DataPropertyName = "Connection";
            colConnection.FillWeight = 90F;
            colConnection.HeaderText = "Connection No.";
            colConnection.Name = "colConnection";
            colConnection.ReadOnly = true;
            // 
            // colPreviousReading
            // 
            colPreviousReading.DataPropertyName = "PreviousReading";
            colPreviousReading.FillWeight = 90F;
            colPreviousReading.HeaderText = "Previous Reading";
            colPreviousReading.Name = "colPreviousReading";
            colPreviousReading.ReadOnly = true;
            // 
            // colCurrentReading
            // 
            colCurrentReading.DataPropertyName = "CurrentReading";
            colCurrentReading.FillWeight = 90F;
            colCurrentReading.HeaderText = "Current Reading";
            colCurrentReading.Name = "colCurrentReading";
            colCurrentReading.ReadOnly = true;
            // 
            // colUnitsConsumed
            // 
            colUnitsConsumed.DataPropertyName = "UnitsConsumed";
            colUnitsConsumed.FillWeight = 90F;
            colUnitsConsumed.HeaderText = "Units Consumed";
            colUnitsConsumed.Name = "colUnitsConsumed";
            colUnitsConsumed.ReadOnly = true;
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.ForeColor = Color.FromArgb(90, 98, 110);
            lblSummary.Location = new Point(20, 84);
            lblSummary.Name = "lblSummary";
            lblSummary.TabIndex = 1;
            lblSummary.Text = "Loading...";
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
            btnClose.Location = new Point(650, 445);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(110, 38);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(11, 79, 138);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblCustomer);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(780, 72);
            pnlHeader.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Water Usage History";
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.ForeColor = Color.FromArgb(214, 228, 242);
            lblCustomer.Location = new Point(22, 42);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.TabIndex = 1;
            lblCustomer.Text = "Customer";
            // 
            // UsageHistoryForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(244, 247, 251);
            CancelButton = btnClose;
            ClientSize = new Size(780, 500);
            Controls.Add(dgvUsageHistory);
            Controls.Add(lblSummary);
            Controls.Add(btnClose);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UsageHistoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Usage History";
            Load += UsageHistoryForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsageHistory).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvUsageHistory;
        private DataGridViewTextBoxColumn colReadingDate;
        private DataGridViewTextBoxColumn colConnection;
        private DataGridViewTextBoxColumn colPreviousReading;
        private DataGridViewTextBoxColumn colCurrentReading;
        private DataGridViewTextBoxColumn colUnitsConsumed;
        private Label lblSummary;
        private Button btnClose;
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblCustomer;
    }
}
