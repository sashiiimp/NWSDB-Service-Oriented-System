namespace NWSDB.Client
{
    partial class BillHistoryForm
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
            dgvBillHistory = new DataGridView();
            colBillNumber = new DataGridViewTextBoxColumn();
            colConnection = new DataGridViewTextBoxColumn();
            colBillingPeriod = new DataGridViewTextBoxColumn();
            colUnits = new DataGridViewTextBoxColumn();
            colAmount = new DataGridViewTextBoxColumn();
            colAmountPaid = new DataGridViewTextBoxColumn();
            colOutstanding = new DataGridViewTextBoxColumn();
            colIssuedDate = new DataGridViewTextBoxColumn();
            colDueDate = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            lblSummary = new Label();
            btnClose = new Button();
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblCustomer = new Label();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBillHistory).BeginInit();
            SuspendLayout();
            // 
            // dgvBillHistory
            // 
            dgvBillHistory.Columns.AddRange(new DataGridViewColumn[] { colBillNumber, colConnection, colBillingPeriod, colUnits, colAmount, colAmountPaid, colOutstanding, colIssuedDate, colDueDate, colStatus });
            dgvBillHistory.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvBillHistory.Location = new Point(20, 110);
            dgvBillHistory.Name = "dgvBillHistory";
            dgvBillHistory.Size = new Size(940, 320);
            dgvBillHistory.TabIndex = 0;
            dgvBillHistory.CellFormatting += dgvBillHistory_CellFormatting;
            // 
            // colBillNumber
            // 
            colBillNumber.DataPropertyName = "BillNumber";
            colBillNumber.FillWeight = 55F;
            colBillNumber.HeaderText = "Bill No.";
            colBillNumber.Name = "colBillNumber";
            colBillNumber.ReadOnly = true;
            // 
            // colConnection
            // 
            colConnection.DataPropertyName = "Connection";
            colConnection.FillWeight = 70F;
            colConnection.HeaderText = "Connection";
            colConnection.Name = "colConnection";
            colConnection.ReadOnly = true;
            // 
            // colBillingPeriod
            // 
            colBillingPeriod.DataPropertyName = "BillingPeriod";
            colBillingPeriod.FillWeight = 150F;
            colBillingPeriod.HeaderText = "Billing Period";
            colBillingPeriod.Name = "colBillingPeriod";
            colBillingPeriod.ReadOnly = true;
            // 
            // colUnits
            // 
            colUnits.DataPropertyName = "UnitsConsumed";
            colUnits.FillWeight = 55F;
            colUnits.HeaderText = "Units";
            colUnits.Name = "colUnits";
            colUnits.ReadOnly = true;
            // 
            // colAmount
            // 
            colAmount.DataPropertyName = "Amount";
            colAmount.FillWeight = 80F;
            colAmount.HeaderText = "Amount";
            colAmount.Name = "colAmount";
            colAmount.ReadOnly = true;
            // 
            // colAmountPaid
            // 
            colAmountPaid.DataPropertyName = "AmountPaid";
            colAmountPaid.FillWeight = 80F;
            colAmountPaid.HeaderText = "Paid";
            colAmountPaid.Name = "colAmountPaid";
            colAmountPaid.ReadOnly = true;
            // 
            // colOutstanding
            // 
            colOutstanding.DataPropertyName = "Outstanding";
            colOutstanding.FillWeight = 80F;
            colOutstanding.HeaderText = "Outstanding";
            colOutstanding.Name = "colOutstanding";
            colOutstanding.ReadOnly = true;
            // 
            // colIssuedDate
            // 
            colIssuedDate.DataPropertyName = "IssuedDate";
            colIssuedDate.FillWeight = 75F;
            colIssuedDate.HeaderText = "Issued";
            colIssuedDate.Name = "colIssuedDate";
            colIssuedDate.ReadOnly = true;
            // 
            // colDueDate
            // 
            colDueDate.DataPropertyName = "DueDate";
            colDueDate.FillWeight = 75F;
            colDueDate.HeaderText = "Due";
            colDueDate.Name = "colDueDate";
            colDueDate.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "Status";
            colStatus.FillWeight = 75F;
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
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
            btnClose.Location = new Point(850, 445);
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
            pnlHeader.Size = new Size(980, 72);
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
            lblTitle.Text = "Bill History";
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
            // BillHistoryForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(244, 247, 251);
            CancelButton = btnClose;
            ClientSize = new Size(980, 500);
            Controls.Add(dgvBillHistory);
            Controls.Add(lblSummary);
            Controls.Add(btnClose);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BillHistoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bill History";
            Load += BillHistoryForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBillHistory).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvBillHistory;
        private DataGridViewTextBoxColumn colBillNumber;
        private DataGridViewTextBoxColumn colConnection;
        private DataGridViewTextBoxColumn colBillingPeriod;
        private DataGridViewTextBoxColumn colUnits;
        private DataGridViewTextBoxColumn colAmount;
        private DataGridViewTextBoxColumn colAmountPaid;
        private DataGridViewTextBoxColumn colOutstanding;
        private DataGridViewTextBoxColumn colIssuedDate;
        private DataGridViewTextBoxColumn colDueDate;
        private DataGridViewTextBoxColumn colStatus;
        private Label lblSummary;
        private Button btnClose;
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblCustomer;
    }
}
