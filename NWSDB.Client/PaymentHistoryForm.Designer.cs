namespace NWSDB.Client
{
    partial class PaymentHistoryForm
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
            dgvPaymentHistory = new DataGridView();
            colPaymentId = new DataGridViewTextBoxColumn();
            colPaymentDate = new DataGridViewTextBoxColumn();
            colBillNumber = new DataGridViewTextBoxColumn();
            colAmountPaid = new DataGridViewTextBoxColumn();
            colPaymentMethod = new DataGridViewTextBoxColumn();
            colSource = new DataGridViewTextBoxColumn();
            colTransactionReference = new DataGridViewTextBoxColumn();
            lblSummary = new Label();
            btnViewReceipt = new Button();
            btnClose = new Button();
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblCustomer = new Label();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPaymentHistory).BeginInit();
            SuspendLayout();
            // 
            // dgvPaymentHistory
            // 
            dgvPaymentHistory.Columns.AddRange(new DataGridViewColumn[] { colPaymentId, colPaymentDate, colBillNumber, colAmountPaid, colPaymentMethod, colSource, colTransactionReference });
            dgvPaymentHistory.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvPaymentHistory.Location = new Point(20, 110);
            dgvPaymentHistory.Name = "dgvPaymentHistory";
            dgvPaymentHistory.Size = new Size(860, 320);
            dgvPaymentHistory.TabIndex = 0;
            dgvPaymentHistory.CellDoubleClick += dgvPaymentHistory_CellDoubleClick;
            // 
            // colPaymentId
            // 
            colPaymentId.DataPropertyName = "PaymentId";
            colPaymentId.FillWeight = 60F;
            colPaymentId.HeaderText = "Payment ID";
            colPaymentId.Name = "colPaymentId";
            colPaymentId.ReadOnly = true;
            // 
            // colPaymentDate
            // 
            colPaymentDate.DataPropertyName = "PaymentDate";
            colPaymentDate.FillWeight = 100F;
            colPaymentDate.HeaderText = "Payment Date";
            colPaymentDate.Name = "colPaymentDate";
            colPaymentDate.ReadOnly = true;
            // 
            // colBillNumber
            // 
            colBillNumber.DataPropertyName = "BillNumber";
            colBillNumber.FillWeight = 55F;
            colBillNumber.HeaderText = "Bill No.";
            colBillNumber.Name = "colBillNumber";
            colBillNumber.ReadOnly = true;
            // 
            // colAmountPaid
            // 
            colAmountPaid.DataPropertyName = "AmountPaid";
            colAmountPaid.FillWeight = 80F;
            colAmountPaid.HeaderText = "Amount Paid";
            colAmountPaid.Name = "colAmountPaid";
            colAmountPaid.ReadOnly = true;
            // 
            // colPaymentMethod
            // 
            colPaymentMethod.DataPropertyName = "PaymentMethod";
            colPaymentMethod.FillWeight = 80F;
            colPaymentMethod.HeaderText = "Method";
            colPaymentMethod.Name = "colPaymentMethod";
            colPaymentMethod.ReadOnly = true;
            // 
            // colSource
            // 
            colSource.DataPropertyName = "Source";
            colSource.FillWeight = 90F;
            colSource.HeaderText = "Channel";
            colSource.Name = "colSource";
            colSource.ReadOnly = true;
            // 
            // colTransactionReference
            // 
            colTransactionReference.DataPropertyName = "TransactionReference";
            colTransactionReference.FillWeight = 150F;
            colTransactionReference.HeaderText = "Transaction Reference";
            colTransactionReference.Name = "colTransactionReference";
            colTransactionReference.ReadOnly = true;
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
            // btnViewReceipt
            // 
            btnViewReceipt.BackColor = Color.FromArgb(11, 79, 138);
            btnViewReceipt.Cursor = Cursors.Hand;
            btnViewReceipt.FlatAppearance.BorderColor = Color.FromArgb(11, 79, 138);
            btnViewReceipt.FlatAppearance.BorderSize = 0;
            btnViewReceipt.FlatStyle = FlatStyle.Flat;
            btnViewReceipt.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewReceipt.ForeColor = Color.White;
            btnViewReceipt.Location = new Point(620, 445);
            btnViewReceipt.Name = "btnViewReceipt";
            btnViewReceipt.Size = new Size(140, 38);
            btnViewReceipt.TabIndex = 2;
            btnViewReceipt.Text = "View Receipt";
            btnViewReceipt.UseVisualStyleBackColor = false;
            btnViewReceipt.Click += btnViewReceipt_Click;
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
            btnClose.Location = new Point(770, 445);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(110, 38);
            btnClose.TabIndex = 3;
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
            pnlHeader.Size = new Size(900, 72);
            pnlHeader.TabIndex = 4;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Payment History";
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
            // PaymentHistoryForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(244, 247, 251);
            CancelButton = btnClose;
            ClientSize = new Size(900, 500);
            Controls.Add(dgvPaymentHistory);
            Controls.Add(lblSummary);
            Controls.Add(btnViewReceipt);
            Controls.Add(btnClose);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PaymentHistoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Payment History";
            Load += PaymentHistoryForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPaymentHistory).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPaymentHistory;
        private DataGridViewTextBoxColumn colPaymentId;
        private DataGridViewTextBoxColumn colPaymentDate;
        private DataGridViewTextBoxColumn colBillNumber;
        private DataGridViewTextBoxColumn colAmountPaid;
        private DataGridViewTextBoxColumn colPaymentMethod;
        private DataGridViewTextBoxColumn colSource;
        private DataGridViewTextBoxColumn colTransactionReference;
        private Label lblSummary;
        private Button btnViewReceipt;
        private Button btnClose;
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblCustomer;
    }
}
