namespace NWSDB.Client
{
    partial class RecordMeterReadingForm
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
            grpReading = new GroupBox();
            lblReadingDate = new Label();
            dtpReadingDate = new DateTimePicker();
            lblPreviousReading = new Label();
            nudPreviousReading = new NumericUpDown();
            lblCurrentReading = new Label();
            nudCurrentReading = new NumericUpDown();
            lblUnitsConsumedCaption = new Label();
            lblUnitsConsumed = new Label();
            grpConnection = new GroupBox();
            lblConnectionNumberCaption = new Label();
            lblConnectionNumber = new Label();
            lblCustomerCaption = new Label();
            lblCustomer = new Label();
            lblConnectionAddressCaption = new Label();
            lblConnectionAddress = new Label();
            lblLatestReadingCaption = new Label();
            lblLatestReading = new Label();
            btnSave = new Button();
            btnClose = new Button();
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            grpReading.SuspendLayout();
            grpConnection.SuspendLayout();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPreviousReading).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCurrentReading).BeginInit();
            SuspendLayout();
            // 
            // grpReading
            // 
            grpReading.BackColor = Color.White;
            grpReading.Controls.Add(lblReadingDate);
            grpReading.Controls.Add(dtpReadingDate);
            grpReading.Controls.Add(lblPreviousReading);
            grpReading.Controls.Add(nudPreviousReading);
            grpReading.Controls.Add(lblCurrentReading);
            grpReading.Controls.Add(nudCurrentReading);
            grpReading.Controls.Add(lblUnitsConsumedCaption);
            grpReading.Controls.Add(lblUnitsConsumed);
            grpReading.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpReading.ForeColor = Color.FromArgb(11, 79, 138);
            grpReading.Location = new Point(25, 245);
            grpReading.Name = "grpReading";
            grpReading.Padding = new Padding(12, 8, 12, 12);
            grpReading.Size = new Size(470, 195);
            grpReading.TabIndex = 0;
            grpReading.TabStop = false;
            grpReading.Text = "New Reading";
            // 
            // lblReadingDate
            // 
            lblReadingDate.AutoSize = true;
            lblReadingDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReadingDate.ForeColor = Color.FromArgb(90, 98, 110);
            lblReadingDate.Location = new Point(20, 37);
            lblReadingDate.Name = "lblReadingDate";
            lblReadingDate.TabIndex = 0;
            lblReadingDate.Text = "Reading Date";
            // 
            // dtpReadingDate
            // 
            dtpReadingDate.CustomFormat = "dd MMM yyyy";
            dtpReadingDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpReadingDate.Format = DateTimePickerFormat.Custom;
            dtpReadingDate.Location = new Point(190, 33);
            dtpReadingDate.Name = "dtpReadingDate";
            dtpReadingDate.Size = new Size(200, 25);
            dtpReadingDate.TabIndex = 1;
            // 
            // lblPreviousReading
            // 
            lblPreviousReading.AutoSize = true;
            lblPreviousReading.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPreviousReading.ForeColor = Color.FromArgb(90, 98, 110);
            lblPreviousReading.Location = new Point(20, 77);
            lblPreviousReading.Name = "lblPreviousReading";
            lblPreviousReading.TabIndex = 2;
            lblPreviousReading.Text = "Previous Reading";
            // 
            // nudPreviousReading
            // 
            nudPreviousReading.DecimalPlaces = 2;
            nudPreviousReading.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudPreviousReading.Location = new Point(190, 73);
            nudPreviousReading.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            nudPreviousReading.Name = "nudPreviousReading";
            nudPreviousReading.Size = new Size(200, 25);
            nudPreviousReading.TabIndex = 3;
            nudPreviousReading.ThousandsSeparator = true;
            nudPreviousReading.ValueChanged += ReadingValue_Changed;
            // 
            // lblCurrentReading
            // 
            lblCurrentReading.AutoSize = true;
            lblCurrentReading.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentReading.ForeColor = Color.FromArgb(90, 98, 110);
            lblCurrentReading.Location = new Point(20, 117);
            lblCurrentReading.Name = "lblCurrentReading";
            lblCurrentReading.TabIndex = 4;
            lblCurrentReading.Text = "Current Reading";
            // 
            // nudCurrentReading
            // 
            nudCurrentReading.DecimalPlaces = 2;
            nudCurrentReading.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudCurrentReading.Location = new Point(190, 113);
            nudCurrentReading.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            nudCurrentReading.Name = "nudCurrentReading";
            nudCurrentReading.Size = new Size(200, 25);
            nudCurrentReading.TabIndex = 5;
            nudCurrentReading.ThousandsSeparator = true;
            nudCurrentReading.ValueChanged += ReadingValue_Changed;
            // 
            // lblUnitsConsumedCaption
            // 
            lblUnitsConsumedCaption.AutoSize = true;
            lblUnitsConsumedCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUnitsConsumedCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblUnitsConsumedCaption.Location = new Point(20, 157);
            lblUnitsConsumedCaption.Name = "lblUnitsConsumedCaption";
            lblUnitsConsumedCaption.TabIndex = 6;
            lblUnitsConsumedCaption.Text = "Units Consumed";
            // 
            // lblUnitsConsumed
            // 
            lblUnitsConsumed.AutoEllipsis = true;
            lblUnitsConsumed.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUnitsConsumed.ForeColor = Color.FromArgb(33, 37, 41);
            lblUnitsConsumed.Location = new Point(190, 157);
            lblUnitsConsumed.Name = "lblUnitsConsumed";
            lblUnitsConsumed.Size = new Size(260, 23);
            lblUnitsConsumed.TabIndex = 7;
            lblUnitsConsumed.Text = "-";
            // 
            // grpConnection
            // 
            grpConnection.BackColor = Color.White;
            grpConnection.Controls.Add(lblConnectionNumberCaption);
            grpConnection.Controls.Add(lblConnectionNumber);
            grpConnection.Controls.Add(lblCustomerCaption);
            grpConnection.Controls.Add(lblCustomer);
            grpConnection.Controls.Add(lblConnectionAddressCaption);
            grpConnection.Controls.Add(lblConnectionAddress);
            grpConnection.Controls.Add(lblLatestReadingCaption);
            grpConnection.Controls.Add(lblLatestReading);
            grpConnection.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpConnection.ForeColor = Color.FromArgb(11, 79, 138);
            grpConnection.Location = new Point(25, 88);
            grpConnection.Name = "grpConnection";
            grpConnection.Padding = new Padding(12, 8, 12, 12);
            grpConnection.Size = new Size(470, 140);
            grpConnection.TabIndex = 1;
            grpConnection.TabStop = false;
            grpConnection.Text = "Connection";
            // 
            // lblConnectionNumberCaption
            // 
            lblConnectionNumberCaption.AutoSize = true;
            lblConnectionNumberCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConnectionNumberCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblConnectionNumberCaption.Location = new Point(20, 30);
            lblConnectionNumberCaption.Name = "lblConnectionNumberCaption";
            lblConnectionNumberCaption.TabIndex = 0;
            lblConnectionNumberCaption.Text = "Connection No.";
            // 
            // lblConnectionNumber
            // 
            lblConnectionNumber.AutoEllipsis = true;
            lblConnectionNumber.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConnectionNumber.ForeColor = Color.FromArgb(33, 37, 41);
            lblConnectionNumber.Location = new Point(190, 30);
            lblConnectionNumber.Name = "lblConnectionNumber";
            lblConnectionNumber.Size = new Size(265, 23);
            lblConnectionNumber.TabIndex = 1;
            lblConnectionNumber.Text = "-";
            // 
            // lblCustomerCaption
            // 
            lblCustomerCaption.AutoSize = true;
            lblCustomerCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomerCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblCustomerCaption.Location = new Point(20, 55);
            lblCustomerCaption.Name = "lblCustomerCaption";
            lblCustomerCaption.TabIndex = 2;
            lblCustomerCaption.Text = "Customer";
            // 
            // lblCustomer
            // 
            lblCustomer.AutoEllipsis = true;
            lblCustomer.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomer.ForeColor = Color.FromArgb(33, 37, 41);
            lblCustomer.Location = new Point(190, 55);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(265, 23);
            lblCustomer.TabIndex = 3;
            lblCustomer.Text = "-";
            // 
            // lblConnectionAddressCaption
            // 
            lblConnectionAddressCaption.AutoSize = true;
            lblConnectionAddressCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConnectionAddressCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblConnectionAddressCaption.Location = new Point(20, 80);
            lblConnectionAddressCaption.Name = "lblConnectionAddressCaption";
            lblConnectionAddressCaption.TabIndex = 4;
            lblConnectionAddressCaption.Text = "Address";
            // 
            // lblConnectionAddress
            // 
            lblConnectionAddress.AutoEllipsis = true;
            lblConnectionAddress.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConnectionAddress.ForeColor = Color.FromArgb(33, 37, 41);
            lblConnectionAddress.Location = new Point(190, 80);
            lblConnectionAddress.Name = "lblConnectionAddress";
            lblConnectionAddress.Size = new Size(265, 23);
            lblConnectionAddress.TabIndex = 5;
            lblConnectionAddress.Text = "-";
            // 
            // lblLatestReadingCaption
            // 
            lblLatestReadingCaption.AutoSize = true;
            lblLatestReadingCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLatestReadingCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblLatestReadingCaption.Location = new Point(20, 105);
            lblLatestReadingCaption.Name = "lblLatestReadingCaption";
            lblLatestReadingCaption.TabIndex = 6;
            lblLatestReadingCaption.Text = "Latest Reading";
            // 
            // lblLatestReading
            // 
            lblLatestReading.AutoEllipsis = true;
            lblLatestReading.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLatestReading.ForeColor = Color.FromArgb(33, 37, 41);
            lblLatestReading.Location = new Point(190, 105);
            lblLatestReading.Name = "lblLatestReading";
            lblLatestReading.Size = new Size(265, 23);
            lblLatestReading.TabIndex = 7;
            lblLatestReading.Text = "-";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(11, 79, 138);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderColor = Color.FromArgb(11, 79, 138);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(255, 455);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(130, 38);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save Reading";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
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
            btnClose.Location = new Point(395, 455);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 38);
            btnClose.TabIndex = 3;
            btnClose.Text = "Cancel";
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
            pnlHeader.Size = new Size(520, 72);
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
            lblTitle.Text = "Record Meter Reading";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.ForeColor = Color.FromArgb(214, 228, 242);
            lblSubtitle.Location = new Point(22, 42);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Connection";
            // 
            // RecordMeterReadingForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(244, 247, 251);
            CancelButton = btnClose;
            ClientSize = new Size(520, 510);
            Controls.Add(grpReading);
            Controls.Add(grpConnection);
            Controls.Add(btnSave);
            Controls.Add(btnClose);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RecordMeterReadingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Record Meter Reading";
            ((System.ComponentModel.ISupportInitialize)nudPreviousReading).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCurrentReading).EndInit();
            grpReading.ResumeLayout(false);
            grpReading.PerformLayout();
            grpConnection.ResumeLayout(false);
            grpConnection.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpReading;
        private Label lblReadingDate;
        private DateTimePicker dtpReadingDate;
        private Label lblPreviousReading;
        private NumericUpDown nudPreviousReading;
        private Label lblCurrentReading;
        private NumericUpDown nudCurrentReading;
        private Label lblUnitsConsumedCaption;
        private Label lblUnitsConsumed;
        private GroupBox grpConnection;
        private Label lblConnectionNumberCaption;
        private Label lblConnectionNumber;
        private Label lblCustomerCaption;
        private Label lblCustomer;
        private Label lblConnectionAddressCaption;
        private Label lblConnectionAddress;
        private Label lblLatestReadingCaption;
        private Label lblLatestReading;
        private Button btnSave;
        private Button btnClose;
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
    }
}
