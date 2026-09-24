namespace NWSDB.Client
{
    partial class MakePaymentForm
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
            grpPayment = new GroupBox();
            lblPaymentAmount = new Label();
            txtAmount = new TextBox();
            lblPaymentMethod = new Label();
            cmbPaymentMethod = new ComboBox();
            grpBill = new GroupBox();
            lblBillingPeriodCaption = new Label();
            lblBillingPeriod = new Label();
            lblAmountCaption = new Label();
            lblAmount = new Label();
            lblAmountPaidCaption = new Label();
            lblAmountPaid = new Label();
            lblOutstandingCaption = new Label();
            lblOutstanding = new Label();
            lblDueDateCaption = new Label();
            lblDueDate = new Label();
            cmbBill = new ComboBox();
            lblBill = new Label();
            btnPay = new Button();
            btnClose = new Button();
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblCustomer = new Label();
            grpPayment.SuspendLayout();
            grpBill.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // grpPayment
            // 
            grpPayment.BackColor = Color.White;
            grpPayment.Controls.Add(lblPaymentAmount);
            grpPayment.Controls.Add(txtAmount);
            grpPayment.Controls.Add(lblPaymentMethod);
            grpPayment.Controls.Add(cmbPaymentMethod);
            grpPayment.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpPayment.ForeColor = Color.FromArgb(11, 79, 138);
            grpPayment.Location = new Point(30, 305);
            grpPayment.Name = "grpPayment";
            grpPayment.Padding = new Padding(12, 8, 12, 12);
            grpPayment.Size = new Size(500, 130);
            grpPayment.TabIndex = 0;
            grpPayment.TabStop = false;
            grpPayment.Text = "Payment Details";
            // 
            // lblPaymentAmount
            // 
            lblPaymentAmount.AutoSize = true;
            lblPaymentAmount.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPaymentAmount.ForeColor = Color.FromArgb(90, 98, 110);
            lblPaymentAmount.Location = new Point(20, 38);
            lblPaymentAmount.Name = "lblPaymentAmount";
            lblPaymentAmount.TabIndex = 0;
            lblPaymentAmount.Text = "Amount (Rs.)";
            // 
            // txtAmount
            // 
            txtAmount.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAmount.ForeColor = SystemColors.WindowText;
            txtAmount.Location = new Point(190, 34);
            txtAmount.MaxLength = 12;
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(200, 25);
            txtAmount.TabIndex = 1;
            // 
            // lblPaymentMethod
            // 
            lblPaymentMethod.AutoSize = true;
            lblPaymentMethod.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPaymentMethod.ForeColor = Color.FromArgb(90, 98, 110);
            lblPaymentMethod.Location = new Point(20, 82);
            lblPaymentMethod.Name = "lblPaymentMethod";
            lblPaymentMethod.TabIndex = 2;
            lblPaymentMethod.Text = "Payment Method";
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentMethod.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbPaymentMethod.ForeColor = SystemColors.WindowText;
            cmbPaymentMethod.FormattingEnabled = true;
            cmbPaymentMethod.Location = new Point(190, 78);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(200, 25);
            cmbPaymentMethod.TabIndex = 3;
            // 
            // grpBill
            // 
            grpBill.BackColor = Color.White;
            grpBill.Controls.Add(lblBillingPeriodCaption);
            grpBill.Controls.Add(lblBillingPeriod);
            grpBill.Controls.Add(lblAmountCaption);
            grpBill.Controls.Add(lblAmount);
            grpBill.Controls.Add(lblAmountPaidCaption);
            grpBill.Controls.Add(lblAmountPaid);
            grpBill.Controls.Add(lblOutstandingCaption);
            grpBill.Controls.Add(lblOutstanding);
            grpBill.Controls.Add(lblDueDateCaption);
            grpBill.Controls.Add(lblDueDate);
            grpBill.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpBill.ForeColor = Color.FromArgb(11, 79, 138);
            grpBill.Location = new Point(30, 125);
            grpBill.Name = "grpBill";
            grpBill.Padding = new Padding(12, 8, 12, 12);
            grpBill.Size = new Size(500, 165);
            grpBill.TabIndex = 1;
            grpBill.TabStop = false;
            grpBill.Text = "Selected Bill";
            // 
            // lblBillingPeriodCaption
            // 
            lblBillingPeriodCaption.AutoSize = true;
            lblBillingPeriodCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBillingPeriodCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblBillingPeriodCaption.Location = new Point(20, 32);
            lblBillingPeriodCaption.Name = "lblBillingPeriodCaption";
            lblBillingPeriodCaption.TabIndex = 0;
            lblBillingPeriodCaption.Text = "Billing Period";
            // 
            // lblBillingPeriod
            // 
            lblBillingPeriod.AutoEllipsis = true;
            lblBillingPeriod.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBillingPeriod.ForeColor = Color.FromArgb(33, 37, 41);
            lblBillingPeriod.Location = new Point(190, 32);
            lblBillingPeriod.Name = "lblBillingPeriod";
            lblBillingPeriod.Size = new Size(290, 23);
            lblBillingPeriod.TabIndex = 1;
            lblBillingPeriod.Text = "-";
            // 
            // lblAmountCaption
            // 
            lblAmountCaption.AutoSize = true;
            lblAmountCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAmountCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblAmountCaption.Location = new Point(20, 58);
            lblAmountCaption.Name = "lblAmountCaption";
            lblAmountCaption.TabIndex = 2;
            lblAmountCaption.Text = "Bill Amount";
            // 
            // lblAmount
            // 
            lblAmount.AutoEllipsis = true;
            lblAmount.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAmount.ForeColor = Color.FromArgb(33, 37, 41);
            lblAmount.Location = new Point(190, 58);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(290, 23);
            lblAmount.TabIndex = 3;
            lblAmount.Text = "-";
            // 
            // lblAmountPaidCaption
            // 
            lblAmountPaidCaption.AutoSize = true;
            lblAmountPaidCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAmountPaidCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblAmountPaidCaption.Location = new Point(20, 84);
            lblAmountPaidCaption.Name = "lblAmountPaidCaption";
            lblAmountPaidCaption.TabIndex = 4;
            lblAmountPaidCaption.Text = "Amount Paid";
            // 
            // lblAmountPaid
            // 
            lblAmountPaid.AutoEllipsis = true;
            lblAmountPaid.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAmountPaid.ForeColor = Color.FromArgb(33, 37, 41);
            lblAmountPaid.Location = new Point(190, 84);
            lblAmountPaid.Name = "lblAmountPaid";
            lblAmountPaid.Size = new Size(290, 23);
            lblAmountPaid.TabIndex = 5;
            lblAmountPaid.Text = "-";
            // 
            // lblOutstandingCaption
            // 
            lblOutstandingCaption.AutoSize = true;
            lblOutstandingCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOutstandingCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblOutstandingCaption.Location = new Point(20, 110);
            lblOutstandingCaption.Name = "lblOutstandingCaption";
            lblOutstandingCaption.TabIndex = 6;
            lblOutstandingCaption.Text = "Outstanding Amount";
            // 
            // lblOutstanding
            // 
            lblOutstanding.AutoEllipsis = true;
            lblOutstanding.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOutstanding.ForeColor = Color.FromArgb(33, 37, 41);
            lblOutstanding.Location = new Point(190, 110);
            lblOutstanding.Name = "lblOutstanding";
            lblOutstanding.Size = new Size(290, 23);
            lblOutstanding.TabIndex = 7;
            lblOutstanding.Text = "-";
            // 
            // lblDueDateCaption
            // 
            lblDueDateCaption.AutoSize = true;
            lblDueDateCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDueDateCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblDueDateCaption.Location = new Point(20, 136);
            lblDueDateCaption.Name = "lblDueDateCaption";
            lblDueDateCaption.TabIndex = 8;
            lblDueDateCaption.Text = "Due Date";
            // 
            // lblDueDate
            // 
            lblDueDate.AutoEllipsis = true;
            lblDueDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDueDate.ForeColor = Color.FromArgb(33, 37, 41);
            lblDueDate.Location = new Point(190, 136);
            lblDueDate.Name = "lblDueDate";
            lblDueDate.Size = new Size(290, 23);
            lblDueDate.TabIndex = 9;
            lblDueDate.Text = "-";
            // 
            // cmbBill
            // 
            cmbBill.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBill.FormattingEnabled = true;
            cmbBill.Location = new Point(150, 88);
            cmbBill.Name = "cmbBill";
            cmbBill.Size = new Size(380, 25);
            cmbBill.TabIndex = 2;
            cmbBill.SelectedIndexChanged += cmbBill_SelectedIndexChanged;
            // 
            // lblBill
            // 
            lblBill.AutoSize = true;
            lblBill.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBill.Location = new Point(30, 91);
            lblBill.Name = "lblBill";
            lblBill.TabIndex = 3;
            lblBill.Text = "Bill to pay:";
            // 
            // btnPay
            // 
            btnPay.BackColor = Color.FromArgb(11, 79, 138);
            btnPay.Cursor = Cursors.Hand;
            btnPay.FlatAppearance.BorderColor = Color.FromArgb(11, 79, 138);
            btnPay.FlatAppearance.BorderSize = 0;
            btnPay.FlatStyle = FlatStyle.Flat;
            btnPay.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPay.ForeColor = Color.White;
            btnPay.Location = new Point(290, 455);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(120, 38);
            btnPay.TabIndex = 4;
            btnPay.Text = "Pay Now";
            btnPay.UseVisualStyleBackColor = false;
            btnPay.Click += btnPay_Click;
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
            btnClose.Location = new Point(420, 455);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(110, 38);
            btnClose.TabIndex = 5;
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
            pnlHeader.TabIndex = 6;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Make a Payment";
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
            // MakePaymentForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(244, 247, 251);
            CancelButton = btnClose;
            ClientSize = new Size(560, 520);
            Controls.Add(grpPayment);
            Controls.Add(grpBill);
            Controls.Add(cmbBill);
            Controls.Add(lblBill);
            Controls.Add(btnPay);
            Controls.Add(btnClose);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MakePaymentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Make Payment";
            Load += MakePaymentForm_Load;
            grpPayment.ResumeLayout(false);
            grpPayment.PerformLayout();
            grpBill.ResumeLayout(false);
            grpBill.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpPayment;
        private Label lblPaymentAmount;
        private TextBox txtAmount;
        private Label lblPaymentMethod;
        private ComboBox cmbPaymentMethod;
        private GroupBox grpBill;
        private Label lblBillingPeriodCaption;
        private Label lblBillingPeriod;
        private Label lblAmountCaption;
        private Label lblAmount;
        private Label lblAmountPaidCaption;
        private Label lblAmountPaid;
        private Label lblOutstandingCaption;
        private Label lblOutstanding;
        private Label lblDueDateCaption;
        private Label lblDueDate;
        private ComboBox cmbBill;
        private Label lblBill;
        private Button btnPay;
        private Button btnClose;
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblCustomer;
    }
}
