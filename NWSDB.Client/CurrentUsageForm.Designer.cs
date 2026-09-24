namespace NWSDB.Client
{
    partial class CurrentUsageForm
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
            lblConnectionAddressCaption = new Label();
            lblConnectionAddress = new Label();
            lblReadingDateCaption = new Label();
            lblReadingDate = new Label();
            lblPreviousReadingCaption = new Label();
            lblPreviousReading = new Label();
            lblCurrentReadingCaption = new Label();
            lblCurrentReading = new Label();
            lblUnitsConsumedCaption = new Label();
            lblUnitsConsumed = new Label();
            cmbConnection = new ComboBox();
            lblConnection = new Label();
            btnClose = new Button();
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblCustomer = new Label();
            grpReading.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // grpReading
            // 
            grpReading.BackColor = Color.White;
            grpReading.Controls.Add(lblConnectionAddressCaption);
            grpReading.Controls.Add(lblConnectionAddress);
            grpReading.Controls.Add(lblReadingDateCaption);
            grpReading.Controls.Add(lblReadingDate);
            grpReading.Controls.Add(lblPreviousReadingCaption);
            grpReading.Controls.Add(lblPreviousReading);
            grpReading.Controls.Add(lblCurrentReadingCaption);
            grpReading.Controls.Add(lblCurrentReading);
            grpReading.Controls.Add(lblUnitsConsumedCaption);
            grpReading.Controls.Add(lblUnitsConsumed);
            grpReading.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpReading.ForeColor = Color.FromArgb(11, 79, 138);
            grpReading.Location = new Point(30, 130);
            grpReading.Name = "grpReading";
            grpReading.Padding = new Padding(12, 8, 12, 12);
            grpReading.Size = new Size(500, 230);
            grpReading.TabIndex = 0;
            grpReading.TabStop = false;
            grpReading.Text = "Latest Meter Reading";
            // 
            // lblConnectionAddressCaption
            // 
            lblConnectionAddressCaption.AutoSize = true;
            lblConnectionAddressCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConnectionAddressCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblConnectionAddressCaption.Location = new Point(20, 35);
            lblConnectionAddressCaption.Name = "lblConnectionAddressCaption";
            lblConnectionAddressCaption.TabIndex = 0;
            lblConnectionAddressCaption.Text = "Connection Address";
            // 
            // lblConnectionAddress
            // 
            lblConnectionAddress.AutoEllipsis = true;
            lblConnectionAddress.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConnectionAddress.ForeColor = Color.FromArgb(33, 37, 41);
            lblConnectionAddress.Location = new Point(190, 35);
            lblConnectionAddress.Name = "lblConnectionAddress";
            lblConnectionAddress.Size = new Size(290, 23);
            lblConnectionAddress.TabIndex = 1;
            lblConnectionAddress.Text = "-";
            // 
            // lblReadingDateCaption
            // 
            lblReadingDateCaption.AutoSize = true;
            lblReadingDateCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReadingDateCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblReadingDateCaption.Location = new Point(20, 71);
            lblReadingDateCaption.Name = "lblReadingDateCaption";
            lblReadingDateCaption.TabIndex = 2;
            lblReadingDateCaption.Text = "Reading Date";
            // 
            // lblReadingDate
            // 
            lblReadingDate.AutoEllipsis = true;
            lblReadingDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReadingDate.ForeColor = Color.FromArgb(33, 37, 41);
            lblReadingDate.Location = new Point(190, 71);
            lblReadingDate.Name = "lblReadingDate";
            lblReadingDate.Size = new Size(290, 23);
            lblReadingDate.TabIndex = 3;
            lblReadingDate.Text = "-";
            // 
            // lblPreviousReadingCaption
            // 
            lblPreviousReadingCaption.AutoSize = true;
            lblPreviousReadingCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPreviousReadingCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblPreviousReadingCaption.Location = new Point(20, 107);
            lblPreviousReadingCaption.Name = "lblPreviousReadingCaption";
            lblPreviousReadingCaption.TabIndex = 4;
            lblPreviousReadingCaption.Text = "Previous Reading";
            // 
            // lblPreviousReading
            // 
            lblPreviousReading.AutoEllipsis = true;
            lblPreviousReading.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPreviousReading.ForeColor = Color.FromArgb(33, 37, 41);
            lblPreviousReading.Location = new Point(190, 107);
            lblPreviousReading.Name = "lblPreviousReading";
            lblPreviousReading.Size = new Size(290, 23);
            lblPreviousReading.TabIndex = 5;
            lblPreviousReading.Text = "-";
            // 
            // lblCurrentReadingCaption
            // 
            lblCurrentReadingCaption.AutoSize = true;
            lblCurrentReadingCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentReadingCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblCurrentReadingCaption.Location = new Point(20, 143);
            lblCurrentReadingCaption.Name = "lblCurrentReadingCaption";
            lblCurrentReadingCaption.TabIndex = 6;
            lblCurrentReadingCaption.Text = "Current Reading";
            // 
            // lblCurrentReading
            // 
            lblCurrentReading.AutoEllipsis = true;
            lblCurrentReading.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCurrentReading.ForeColor = Color.FromArgb(33, 37, 41);
            lblCurrentReading.Location = new Point(190, 143);
            lblCurrentReading.Name = "lblCurrentReading";
            lblCurrentReading.Size = new Size(290, 23);
            lblCurrentReading.TabIndex = 7;
            lblCurrentReading.Text = "-";
            // 
            // lblUnitsConsumedCaption
            // 
            lblUnitsConsumedCaption.AutoSize = true;
            lblUnitsConsumedCaption.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUnitsConsumedCaption.ForeColor = Color.FromArgb(90, 98, 110);
            lblUnitsConsumedCaption.Location = new Point(20, 179);
            lblUnitsConsumedCaption.Name = "lblUnitsConsumedCaption";
            lblUnitsConsumedCaption.TabIndex = 8;
            lblUnitsConsumedCaption.Text = "Units Consumed";
            // 
            // lblUnitsConsumed
            // 
            lblUnitsConsumed.AutoEllipsis = true;
            lblUnitsConsumed.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUnitsConsumed.ForeColor = Color.FromArgb(33, 37, 41);
            lblUnitsConsumed.Location = new Point(190, 179);
            lblUnitsConsumed.Name = "lblUnitsConsumed";
            lblUnitsConsumed.Size = new Size(290, 23);
            lblUnitsConsumed.TabIndex = 9;
            lblUnitsConsumed.Text = "-";
            // 
            // cmbConnection
            // 
            cmbConnection.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbConnection.FormattingEnabled = true;
            cmbConnection.Location = new Point(150, 88);
            cmbConnection.Name = "cmbConnection";
            cmbConnection.Size = new Size(380, 25);
            cmbConnection.TabIndex = 1;
            cmbConnection.SelectedIndexChanged += cmbConnection_SelectedIndexChanged;
            // 
            // lblConnection
            // 
            lblConnection.AutoSize = true;
            lblConnection.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblConnection.Location = new Point(30, 91);
            lblConnection.Name = "lblConnection";
            lblConnection.TabIndex = 2;
            lblConnection.Text = "Connection:";
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
            btnClose.Location = new Point(420, 380);
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
            pnlHeader.Size = new Size(560, 72);
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
            lblTitle.Text = "Current Water Usage";
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
            // CurrentUsageForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(244, 247, 251);
            CancelButton = btnClose;
            ClientSize = new Size(560, 440);
            Controls.Add(grpReading);
            Controls.Add(cmbConnection);
            Controls.Add(lblConnection);
            Controls.Add(btnClose);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CurrentUsageForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Current Usage";
            Load += CurrentUsageForm_Load;
            grpReading.ResumeLayout(false);
            grpReading.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpReading;
        private Label lblConnectionAddressCaption;
        private Label lblConnectionAddress;
        private Label lblReadingDateCaption;
        private Label lblReadingDate;
        private Label lblPreviousReadingCaption;
        private Label lblPreviousReading;
        private Label lblCurrentReadingCaption;
        private Label lblCurrentReading;
        private Label lblUnitsConsumedCaption;
        private Label lblUnitsConsumed;
        private ComboBox cmbConnection;
        private Label lblConnection;
        private Button btnClose;
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblCustomer;
    }
}
