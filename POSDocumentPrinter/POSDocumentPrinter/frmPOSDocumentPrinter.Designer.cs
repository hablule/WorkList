namespace POSDocumentPrinter
{
    partial class frmPOSDocumentPrinter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPOSDocumentPrinter));
            this.mnuMainMenu = new System.Windows.Forms.MenuStrip();
            this.mnutask = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.printDeliveryOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printAttachmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printRefundBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printCashReceiptVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.printBankDepositSlipSummary = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrPOSDocumentRefreshTime = new System.Windows.Forms.Timer(this.components);
            this.ntiTaskBarIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.txtInvoiceReferenceNumber = new System.Windows.Forms.TextBox();
            this.txtRefundReferenceNumber = new System.Windows.Forms.TextBox();
            this.cmdDeliveryOrder = new System.Windows.Forms.Button();
            this.cmdAttachment = new System.Windows.Forms.Button();
            this.cmbRefundBook = new System.Windows.Forms.Button();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.cmdPaymentExemption = new System.Windows.Forms.Button();
            this.cmdCRV = new System.Windows.Forms.Button();
            this.cmdDepositSlip = new System.Windows.Forms.Button();
            this.cmdInventory = new System.Windows.Forms.Button();
            this.visualStyler1 = new SkinSoft.VisualStyler.VisualStyler(this.components);
            this.cmdDiminish = new System.Windows.Forms.Button();
            this.cmdManualSales = new System.Windows.Forms.Button();
            this.lblLastReportedSales = new System.Windows.Forms.Label();
            this.tmrUserLogionSession = new System.Windows.Forms.Timer(this.components);
            this.ckAutoHidePin = new System.Windows.Forms.CheckBox();
            this.mnuMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visualStyler1)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMainMenu
            // 
            this.mnuMainMenu.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.mnuMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnutask,
            this.reportToolStripMenuItem});
            this.mnuMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMainMenu.Name = "mnuMainMenu";
            this.mnuMainMenu.Size = new System.Drawing.Size(327, 24);
            this.mnuMainMenu.TabIndex = 1;
            this.mnuMainMenu.Text = "menuStrip1";
            // 
            // mnutask
            // 
            this.mnutask.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSettings,
            this.printDeliveryOrderToolStripMenuItem,
            this.printAttachmentToolStripMenuItem,
            this.printRefundBookToolStripMenuItem,
            this.printCashReceiptVoucher,
            this.printBankDepositSlipSummary,
            this.mnuExit});
            this.mnutask.Name = "mnutask";
            this.mnutask.Size = new System.Drawing.Size(41, 20);
            this.mnutask.Text = "Task";
            // 
            // mnuSettings
            // 
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(249, 22);
            this.mnuSettings.Text = "&Settings...";
            this.mnuSettings.Click += new System.EventHandler(this.mnuSettings_Click);
            // 
            // printDeliveryOrderToolStripMenuItem
            // 
            this.printDeliveryOrderToolStripMenuItem.Name = "printDeliveryOrderToolStripMenuItem";
            this.printDeliveryOrderToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.printDeliveryOrderToolStripMenuItem.Text = "Print Delivery Order";
            // 
            // printAttachmentToolStripMenuItem
            // 
            this.printAttachmentToolStripMenuItem.Name = "printAttachmentToolStripMenuItem";
            this.printAttachmentToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.printAttachmentToolStripMenuItem.Text = "Print Attachment";
            // 
            // printRefundBookToolStripMenuItem
            // 
            this.printRefundBookToolStripMenuItem.Name = "printRefundBookToolStripMenuItem";
            this.printRefundBookToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.printRefundBookToolStripMenuItem.Text = "Print Refund Book";
            // 
            // printCashReceiptVoucher
            // 
            this.printCashReceiptVoucher.Name = "printCashReceiptVoucher";
            this.printCashReceiptVoucher.Size = new System.Drawing.Size(249, 22);
            this.printCashReceiptVoucher.Text = "Print Cash Receipt Voucher (CRV)";
            this.printCashReceiptVoucher.Click += new System.EventHandler(this.cmdCRV_Click);
            // 
            // printBankDepositSlipSummary
            // 
            this.printBankDepositSlipSummary.Name = "printBankDepositSlipSummary";
            this.printBankDepositSlipSummary.Size = new System.Drawing.Size(249, 22);
            this.printBankDepositSlipSummary.Text = "Print Bank Deposit Slip Summary";
            this.printBankDepositSlipSummary.Click += new System.EventHandler(this.cmdDepositSlip_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(249, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openInvoiceToolStripMenuItem});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportToolStripMenuItem.Text = "Reports";
            // 
            // openInvoiceToolStripMenuItem
            // 
            this.openInvoiceToolStripMenuItem.Name = "openInvoiceToolStripMenuItem";
            this.openInvoiceToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.openInvoiceToolStripMenuItem.Text = "Open Invoice";
            this.openInvoiceToolStripMenuItem.Click += new System.EventHandler(this.openInvoiceToolStripMenuItem_Click);
            // 
            // tmrPOSDocumentRefreshTime
            // 
            this.tmrPOSDocumentRefreshTime.Interval = 1000;
            this.tmrPOSDocumentRefreshTime.Tick += new System.EventHandler(this.tmrPOSDocumentRefreshTime_Tick);
            // 
            // ntiTaskBarIcon
            // 
            this.ntiTaskBarIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("ntiTaskBarIcon.Icon")));
            this.ntiTaskBarIcon.Text = "Pos Compiere Bridge";
            this.ntiTaskBarIcon.Visible = true;
            // 
            // txtInvoiceReferenceNumber
            // 
            this.txtInvoiceReferenceNumber.BackColor = System.Drawing.Color.Silver;
            this.txtInvoiceReferenceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceReferenceNumber.Location = new System.Drawing.Point(7, 104);
            this.txtInvoiceReferenceNumber.Name = "txtInvoiceReferenceNumber";
            this.txtInvoiceReferenceNumber.Size = new System.Drawing.Size(103, 20);
            this.txtInvoiceReferenceNumber.TabIndex = 2;
            this.txtInvoiceReferenceNumber.TabStop = false;
            this.txtInvoiceReferenceNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInvoiceReferenceNumber.Click += new System.EventHandler(this.txtInvoiceReferenceNumber_Click);
            this.txtInvoiceReferenceNumber.Leave += new System.EventHandler(this.txtInvoiceReferenceNumber_Leave);
            this.txtInvoiceReferenceNumber.Enter += new System.EventHandler(this.txtInvoiceReferenceNumber_Click);
            // 
            // txtRefundReferenceNumber
            // 
            this.txtRefundReferenceNumber.BackColor = System.Drawing.Color.Silver;
            this.txtRefundReferenceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefundReferenceNumber.Location = new System.Drawing.Point(7, 146);
            this.txtRefundReferenceNumber.Name = "txtRefundReferenceNumber";
            this.txtRefundReferenceNumber.Size = new System.Drawing.Size(103, 20);
            this.txtRefundReferenceNumber.TabIndex = 3;
            this.txtRefundReferenceNumber.TabStop = false;
            this.txtRefundReferenceNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRefundReferenceNumber.Click += new System.EventHandler(this.txtRefunReferenceNumber_Click);
            this.txtRefundReferenceNumber.Leave += new System.EventHandler(this.txtRefunReferenceNumber_Leave);
            this.txtRefundReferenceNumber.Enter += new System.EventHandler(this.txtRefunReferenceNumber_Click);
            // 
            // cmdDeliveryOrder
            // 
            this.cmdDeliveryOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDeliveryOrder.Location = new System.Drawing.Point(112, 96);
            this.cmdDeliveryOrder.Name = "cmdDeliveryOrder";
            this.cmdDeliveryOrder.Size = new System.Drawing.Size(112, 38);
            this.cmdDeliveryOrder.TabIndex = 5;
            this.cmdDeliveryOrder.Text = "Delivery Order";
            this.cmdDeliveryOrder.UseVisualStyleBackColor = true;
            this.cmdDeliveryOrder.Click += new System.EventHandler(this.cmdDeliveryOrder_Click);
            // 
            // cmdAttachment
            // 
            this.cmdAttachment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAttachment.Location = new System.Drawing.Point(226, 96);
            this.cmdAttachment.Name = "cmdAttachment";
            this.cmdAttachment.Size = new System.Drawing.Size(93, 38);
            this.cmdAttachment.TabIndex = 6;
            this.cmdAttachment.Text = "Attachment";
            this.cmdAttachment.UseVisualStyleBackColor = true;
            this.cmdAttachment.Click += new System.EventHandler(this.cmdAttachment_Click);
            // 
            // cmbRefundBook
            // 
            this.cmbRefundBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRefundBook.ForeColor = System.Drawing.Color.Maroon;
            this.cmbRefundBook.Location = new System.Drawing.Point(124, 140);
            this.cmbRefundBook.Name = "cmbRefundBook";
            this.cmbRefundBook.Size = new System.Drawing.Size(195, 35);
            this.cmbRefundBook.TabIndex = 7;
            this.cmbRefundBook.Text = "Refund Book";
            this.cmbRefundBook.UseVisualStyleBackColor = true;
            this.cmbRefundBook.Click += new System.EventHandler(this.cmbRefundBook_Click);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRefresh.Image = ((System.Drawing.Image)(resources.GetObject("cmdRefresh.Image")));
            this.cmdRefresh.Location = new System.Drawing.Point(278, 57);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(37, 29);
            this.cmdRefresh.TabIndex = 9;
            this.cmdRefresh.UseVisualStyleBackColor = true;
            // 
            // cmdPaymentExemption
            // 
            this.cmdPaymentExemption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPaymentExemption.ForeColor = System.Drawing.Color.Blue;
            this.cmdPaymentExemption.Location = new System.Drawing.Point(6, 222);
            this.cmdPaymentExemption.Name = "cmdPaymentExemption";
            this.cmdPaymentExemption.Size = new System.Drawing.Size(87, 54);
            this.cmdPaymentExemption.TabIndex = 10;
            this.cmdPaymentExemption.Text = "Payment Exemption";
            this.cmdPaymentExemption.UseVisualStyleBackColor = true;
            this.cmdPaymentExemption.Click += new System.EventHandler(this.cmdPaymentExemption_Click);
            // 
            // cmdCRV
            // 
            this.cmdCRV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCRV.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.cmdCRV.Location = new System.Drawing.Point(95, 232);
            this.cmdCRV.Name = "cmdCRV";
            this.cmdCRV.Size = new System.Drawing.Size(127, 34);
            this.cmdCRV.TabIndex = 11;
            this.cmdCRV.Text = "Cash Receipt Voucher";
            this.cmdCRV.UseVisualStyleBackColor = true;
            this.cmdCRV.Click += new System.EventHandler(this.cmdCRV_Click);
            // 
            // cmdDepositSlip
            // 
            this.cmdDepositSlip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDepositSlip.ForeColor = System.Drawing.Color.Green;
            this.cmdDepositSlip.Location = new System.Drawing.Point(225, 222);
            this.cmdDepositSlip.Name = "cmdDepositSlip";
            this.cmdDepositSlip.Size = new System.Drawing.Size(101, 54);
            this.cmdDepositSlip.TabIndex = 12;
            this.cmdDepositSlip.Text = "Bank Deposit Advice";
            this.cmdDepositSlip.UseVisualStyleBackColor = true;
            this.cmdDepositSlip.Click += new System.EventHandler(this.cmdDepositSlip_Click);
            // 
            // cmdInventory
            // 
            this.cmdInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdInventory.ForeColor = System.Drawing.Color.Red;
            this.cmdInventory.Location = new System.Drawing.Point(138, 59);
            this.cmdInventory.Name = "cmdInventory";
            this.cmdInventory.Size = new System.Drawing.Size(125, 23);
            this.cmdInventory.TabIndex = 13;
            this.cmdInventory.Text = "Inventory";
            this.cmdInventory.UseVisualStyleBackColor = true;
            this.cmdInventory.Click += new System.EventHandler(this.cmdInventory_Click);
            // 
            // visualStyler1
            // 
            this.visualStyler1.HookVisualStyles = true;
            this.visualStyler1.License = ((SkinSoft.VisualStyler.Licensing.VisualStylerLicense)(resources.GetObject("visualStyler1.License")));
            this.visualStyler1.LoadVisualStyle(null, "Office2007 (Blue).vssf");
            // 
            // cmdDiminish
            // 
            this.cmdDiminish.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDiminish.ForeColor = System.Drawing.Color.Green;
            this.cmdDiminish.Image = ((System.Drawing.Image)(resources.GetObject("cmdDiminish.Image")));
            this.cmdDiminish.Location = new System.Drawing.Point(273, 1);
            this.cmdDiminish.Name = "cmdDiminish";
            this.cmdDiminish.Size = new System.Drawing.Size(53, 40);
            this.cmdDiminish.TabIndex = 14;
            this.cmdDiminish.UseVisualStyleBackColor = true;
            this.cmdDiminish.Click += new System.EventHandler(this.cmdDiminish_Click);
            // 
            // cmdManualSales
            // 
            this.cmdManualSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdManualSales.ForeColor = System.Drawing.Color.Fuchsia;
            this.cmdManualSales.Location = new System.Drawing.Point(12, 181);
            this.cmdManualSales.Name = "cmdManualSales";
            this.cmdManualSales.Size = new System.Drawing.Size(307, 35);
            this.cmdManualSales.TabIndex = 15;
            this.cmdManualSales.Text = "Manual Sales";
            this.cmdManualSales.UseVisualStyleBackColor = true;
            this.cmdManualSales.Click += new System.EventHandler(this.cmdManualSales_Click);
            // 
            // lblLastReportedSales
            // 
            this.lblLastReportedSales.ForeColor = System.Drawing.Color.Red;
            this.lblLastReportedSales.Location = new System.Drawing.Point(23, 24);
            this.lblLastReportedSales.Name = "lblLastReportedSales";
            this.lblLastReportedSales.Size = new System.Drawing.Size(244, 15);
            this.lblLastReportedSales.TabIndex = 16;
            this.lblLastReportedSales.Text = "Last Audited Sales Thursday, March 30- 2016";
            this.lblLastReportedSales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrUserLogionSession
            // 
            this.tmrUserLogionSession.Interval = 3600000;
            this.tmrUserLogionSession.Tick += new System.EventHandler(this.tmrUserLogionSession_Tick);
            // 
            // ckAutoHidePin
            // 
            this.ckAutoHidePin.Appearance = System.Windows.Forms.Appearance.Button;
            this.ckAutoHidePin.Image = global::POSDocumentPrinter.Properties.Resources.UnPin;
            this.ckAutoHidePin.Location = new System.Drawing.Point(12, 48);
            this.ckAutoHidePin.Name = "ckAutoHidePin";
            this.ckAutoHidePin.Size = new System.Drawing.Size(49, 45);
            this.ckAutoHidePin.TabIndex = 18;
            this.ckAutoHidePin.UseVisualStyleBackColor = true;
            this.ckAutoHidePin.CheckedChanged += new System.EventHandler(this.ckAutoHidePin_CheckedChanged);
            // 
            // frmPOSDocumentPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 281);
            this.Controls.Add(this.ckAutoHidePin);
            this.Controls.Add(this.lblLastReportedSales);
            this.Controls.Add(this.cmdManualSales);
            this.Controls.Add(this.cmdDiminish);
            this.Controls.Add(this.cmdInventory);
            this.Controls.Add(this.cmdDepositSlip);
            this.Controls.Add(this.cmdCRV);
            this.Controls.Add(this.cmdPaymentExemption);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.cmbRefundBook);
            this.Controls.Add(this.cmdAttachment);
            this.Controls.Add(this.cmdDeliveryOrder);
            this.Controls.Add(this.txtRefundReferenceNumber);
            this.Controls.Add(this.txtInvoiceReferenceNumber);
            this.Controls.Add(this.mnuMainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMainMenu;
            this.MaximizeBox = false;
            this.Name = "frmPOSDocumentPrinter";
            this.Opacity = 0.9;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "POS Document Printer (v12.1a)";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmPOSDocumentPrinter_Load);
            this.DoubleClick += new System.EventHandler(this.frmPOSDocumentPrinter_DoubleClick);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPosCompiereBridge_FormClosing);
            this.mnuMainMenu.ResumeLayout(false);
            this.mnuMainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visualStyler1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMainMenu;
        private System.Windows.Forms.ToolStripMenuItem mnutask;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.Timer tmrPOSDocumentRefreshTime;
        private System.Windows.Forms.NotifyIcon ntiTaskBarIcon;
        private System.Windows.Forms.ToolStripMenuItem printDeliveryOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printAttachmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printRefundBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.TextBox txtInvoiceReferenceNumber;
        private System.Windows.Forms.TextBox txtRefundReferenceNumber;
        private System.Windows.Forms.Button cmdDeliveryOrder;
        private System.Windows.Forms.Button cmdAttachment;
        private System.Windows.Forms.Button cmbRefundBook;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.ToolStripMenuItem printCashReceiptVoucher;
        private System.Windows.Forms.ToolStripMenuItem printBankDepositSlipSummary;
        private System.Windows.Forms.Button cmdPaymentExemption;
        private System.Windows.Forms.Button cmdCRV;
        private System.Windows.Forms.Button cmdDepositSlip;
        private System.Windows.Forms.Button cmdInventory;
        private SkinSoft.VisualStyler.VisualStyler visualStyler1;
        private System.Windows.Forms.Button cmdDiminish;
        private System.Windows.Forms.Button cmdManualSales;
        private System.Windows.Forms.Label lblLastReportedSales;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openInvoiceToolStripMenuItem;
        private System.Windows.Forms.Timer tmrUserLogionSession;
        private System.Windows.Forms.CheckBox ckAutoHidePin;
    }
}

