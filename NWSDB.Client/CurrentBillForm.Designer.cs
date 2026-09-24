namespace NWSDB.Client
{
    partial class CurrentBillForm
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
            grpBill = new GroupBox();
            lblBillNumberCaption = new Label();
            lblBillNumber = new Label();
            lblConnectionCaption = new Label();
            lblConnection = new Label();
            lblBillingPeriodCaption = new Label();
            lblBillingPeriod = new Label();
            lblUnitsConsumedCaption = new Label();
            lblUnitsConsumed = new Label();
            lblAmountCaption = new Label();
            lblAmount = new Label();
            lblAmountPaidCaption = new Label();
            lblAmountPaid = new Label();
            lblOutstandingCaption = new Label();
            lblOutstanding = new Label();
            lblIssuedDateCaption = new Label();
            lblIssuedDate = new Label();
            lblDueDateCaption = new Label();
            lblDueDate = new Label();
            lblStatusCaption = new Label();
            lblStatus = new Label();
            btnClose = new Button();
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblCustomer = new Label();
            grpBill.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // grpBill
            // 
            grpBill.BackColor = Color.White;
            grpBill.Controls.Add(lblBillNumberCaption);
            grpBill.Controls.Add(lblBillNumber);
            grpBill.Controls.Add(lblConnectionCaption);
            grpBill.Controls.Add(lblConnection);
            grpBill.Controls.Add(lblBillingPeriodCaption);
            grpBill.Controls.Add(lblBillingPeriod);
            grpBill.Controls.Add(lblUnitsConsumedCaption);
            grpBill.Controls.Add(lblUnitsConsumed);
            grpBill.Controls.Add(lblAmountCaption);
            grpBill.Controls.Add(lblAmount);
            grpBill.Controls.Add(lblAmountPaidCaption);
            grpBill.Controls.Add(lblAmountPaid);
            grpBill.Controls.Add(lblOutstandingCaption);
            grpBill.Controls.Add(lblOutstanding);
            grpBill.Controls.Add(lblIssuedDateCaption);
            grpBill.Controls.Add(lblIssuedDate);
            grpBill.Controls.Add(lblDueDateCaption);
            grpBill.Controls.Add(lblDueDate);
            grpBill.Controls.Add(lblStatusCaption);
            grpBill.Controls.Add(lblStatus);
            grpBill.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpBill.ForeColor = Color.FromArgb(11, 79, 138);
            grpBill.Location = new Point(30, 90);
            grpBill.Name = "grpBill";
            grpBill.Padding = new Padding(12, 8, 12, 12);
            grpBill.Size = new Size(500, 370);
            grpBill.TabIndex = 0;
            grpBill.TabStop = false;
            grpBill.Text = "Bill Details";
            // 
            // lblBillNumberCaption
            // 
            lblBillNumberCaption.AutoSize = true;
            lblBillNumberCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBillNumberCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblBillNumberCaption.Location = new Point(20, 35);
            lblBillNumberCaption.Name = "lblBillNumberCaption";
            lblBillNumberCaption.TabIndex = 0;
            lblBillNumberCaption.Text = "Bill Number";
            // 
            // lblBillNumber
            // 
            lblBillNumber.AutoEllipsis = true;
            lblBillNumber.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBillNumber.ForeColor = Color.FromArgb(33, 37, 41);
            lblBillNumber.Location = new Point(190, 35);
            lblBillNumber.Name = "lblBillNumber";
            lblBillNumber.Size = new Size(290, 23);
            lblBillNumber.TabIndex = 1;
            lblBillNumber.Text = "-";
            // 
            // lblConnectionCaption
            // 
            lblConnectionCaption.AutoSize = true;
            lblConnectionCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConnectionCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblConnectionCaption.Location = new Point(20, 67);
            lblConnectionCaption.Name = "lblConnectionCaption";
            lblConnectionCaption.TabIndex = 2;
            lblConnectionCaption.Text = "Connection";
            // 
            // lblConnection
            // 
            lblConnection.AutoEllipsis = true;
            lblConnection.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConnection.ForeColor = Color.FromArgb(33, 37, 41);
            lblConnection.Location = new Point(190, 67);
            lblConnection.Name = "lblConnection";
            lblConnection.Size = new Size(290, 23);
            lblConnection.TabIndex = 3;
            lblConnection.Text = "-";
            // 
            // lblBillingPeriodCaption
            // 
            lblBillingPeriodCaption.AutoSize = true;
            lblBillingPeriodCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBillingPeriodCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblBillingPeriodCaption.Location = new Point(20, 99);
            lblBillingPeriodCaption.Name = "lblBillingPeriodCaption";
            lblBillingPeriodCaption.TabIndex = 4;
            lblBillingPeriodCaption.Text = "Billing Period";
            // 
            // lblBillingPeriod
            // 
            lblBillingPeriod.AutoEllipsis = true;
            lblBillingPeriod.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBillingPeriod.ForeColor = Color.FromArgb(33, 37, 41);
            lblBillingPeriod.Location = new Point(190, 99);
            lblBillingPeriod.Name = "lblBillingPeriod";
            lblBillingPeriod.Size = new Size(290, 23);
            lblBillingPeriod.TabIndex = 5;
            lblBillingPeriod.Text = "-";
            // 
            // lblUnitsConsumedCaption
            // 
            lblUnitsConsumedCaption.AutoSize = true;
            lblUnitsConsumedCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUnitsConsumedCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblUnitsConsumedCaption.Location = new Point(20, 131);
            lblUnitsConsumedCaption.Name = "lblUnitsConsumedCaption";
            lblUnitsConsumedCaption.TabIndex = 6;
            lblUnitsConsumedCaption.Text = "Units Consumed";
            // 
            // lblUnitsConsumed
            // 
            lblUnitsConsumed.AutoEllipsis = true;
            lblUnitsConsumed.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUnitsConsumed.ForeColor = Color.FromArgb(33, 37, 41);
            lblUnitsConsumed.Location = new Point(190, 131);
            lblUnitsConsumed.Name = "lblUnitsConsumed";
            lblUnitsConsumed.Size = new Size(290, 23);
            lblUnitsConsumed.TabIndex = 7;
            lblUnitsConsumed.Text = "-";
            // 
            // lblAmountCaption
            // 
            lblAmountCaption.AutoSize = true;
            lblAmountCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAmountCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblAmountCaption.Location = new Point(20, 163);
            lblAmountCaption.Name = "lblAmountCaption";
            lblAmountCaption.TabIndex = 8;
            lblAmountCaption.Text = "Bill Amount";
            // 
            // lblAmount
            // 
            lblAmount.AutoEllipsis = true;
            lblAmount.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAmount.ForeColor = Color.FromArgb(33, 37, 41);
            lblAmount.Location = new Point(190, 163);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(290, 23);
            lblAmount.TabIndex = 9;
            lblAmount.Text = "-";
            // 
            // lblAmountPaidCaption
            // 
            lblAmountPaidCaption.AutoSize = true;
            lblAmountPaidCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAmountPaidCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblAmountPaidCaption.Location = new Point(20, 195);
            lblAmountPaidCaption.Name = "lblAmountPaidCaption";
            lblAmountPaidCaption.TabIndex = 10;
            lblAmountPaidCaption.Text = "Amount Paid";
            // 
            // lblAmountPaid
            // 
            lblAmountPaid.AutoEllipsis = true;
            lblAmountPaid.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAmountPaid.ForeColor = Color.FromArgb(33, 37, 41);
            lblAmountPaid.Location = new Point(190, 195);
            lblAmountPaid.Name = "lblAmountPaid";
            lblAmountPaid.Size = new Size(290, 23);
            lblAmountPaid.TabIndex = 11;
            lblAmountPaid.Text = "-";
            // 
            // lblOutstandingCaption
            // 
            lblOutstandingCaption.AutoSize = true;
            lblOutstandingCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOutstandingCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblOutstandingCaption.Location = new Point(20, 227);
            lblOutstandingCaption.Name = "lblOutstandingCaption";
            lblOutstandingCaption.TabIndex = 12;
            lblOutstandingCaption.Text = "Outstanding Amount";
            // 
            // lblOutstanding
            // 
            lblOutstanding.AutoEllipsis = true;
            lblOutstanding.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOutstanding.ForeColor = Color.FromArgb(33, 37, 41);
            lblOutstanding.Location = new Point(190, 227);
            lblOutstanding.Name = "lblOutstanding";
            lblOutstanding.Size = new Size(290, 23);
            lblOutstanding.TabIndex = 13;
            lblOutstanding.Text = "-";
            // 
            // lblIssuedDateCaption
            // 
            lblIssuedDateCaption.AutoSize = true;
            lblIssuedDateCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIssuedDateCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblIssuedDateCaption.Location = new Point(20, 259);
            lblIssuedDateCaption.Name = "lblIssuedDateCaption";
            lblIssuedDateCaption.TabIndex = 14;
            lblIssuedDateCaption.Text = "Issued Date";
            // 
            // lblIssuedDate
            // 
            lblIssuedDate.AutoEllipsis = true;
            lblIssuedDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIssuedDate.ForeColor = Color.FromArgb(33, 37, 41);
            lblIssuedDate.Location = new Point(190, 259);
            lblIssuedDate.Name = "lblIssuedDate";
            lblIssuedDate.Size = new Size(290, 23);
            lblIssuedDate.TabIndex = 15;
            lblIssuedDate.Text = "-";
            // 
            // lblDueDateCaption
            // 
            lblDueDateCaption.AutoSize = true;
            lblDueDateCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDueDateCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblDueDateCaption.Location = new Point(20, 291);
            lblDueDateCaption.Name = "lblDueDateCaption";
            lblDueDateCaption.TabIndex = 16;
            lblDueDateCaption.Text = "Due Date";
            // 
            // lblDueDate
            // 
            lblDueDate.AutoEllipsis = true;
            lblDueDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDueDate.ForeColor = Color.FromArgb(33, 37, 41);
            lblDueDate.Location = new Point(190, 291);
            lblDueDate.Name = "lblDueDate";
            lblDueDate.Size = new Size(290, 23);
            lblDueDate.TabIndex = 17;
            lblDueDate.Text = "-";
            // 
            // lblStatusCaption
            // 
            lblStatusCaption.AutoSize = true;
            lblStatusCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatusCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblStatusCaption.Location = new Point(20, 323);
            lblStatusCaption.Name = "lblStatusCaption";
            lblStatusCaption.TabIndex = 18;
            lblStatusCaption.Text = "Status";
            // 
            // lblStatus
            // 
            lblStatus.AutoEllipsis = true;
            lblStatus.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.FromArgb(33, 37, 41);
            lblStatus.Location = new Point(190, 323);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(290, 23);
            lblStatus.TabIndex = 19;
            lblStatus.Text = "-";
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
            btnClose.Location = new Point(420, 475);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(110, 38);
            btnClose.TabIndex = 1;
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
            pnlHeader.Size = new Size(560, 72);
            pnlHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Current Bill";
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
            // CurrentBillForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(244, 247, 251);
            CancelButton = btnClose;
            ClientSize = new Size(560, 530);
            Controls.Add(grpBill);
            Controls.Add(btnClose);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CurrentBillForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Current Bill";
            Load += CurrentBillForm_Load;
            grpBill.ResumeLayout(false);
            grpBill.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpBill;
        private Label lblBillNumberCaption;
        private Label lblBillNumber;
        private Label lblConnectionCaption;
        private Label lblConnection;
        private Label lblBillingPeriodCaption;
        private Label lblBillingPeriod;
        private Label lblUnitsConsumedCaption;
        private Label lblUnitsConsumed;
        private Label lblAmountCaption;
        private Label lblAmount;
        private Label lblAmountPaidCaption;
        private Label lblAmountPaid;
        private Label lblOutstandingCaption;
        private Label lblOutstanding;
        private Label lblIssuedDateCaption;
        private Label lblIssuedDate;
        private Label lblDueDateCaption;
        private Label lblDueDate;
        private Label lblStatusCaption;
        private Label lblStatus;
        private Button btnClose;
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblCustomer;
    }
}
