namespace BankPayments
{
    partial class frmBankPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBankPayment));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tscmdNew = new System.Windows.Forms.ToolStripButton();
            this.tscmdRefresh = new System.Windows.Forms.ToolStripButton();
            this.tscmdSave = new System.Windows.Forms.ToolStripButton();
            this.tscmdDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tscmdConfirm = new System.Windows.Forms.ToolStripButton();
            this.tscmdReject = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tscmdSearch = new System.Windows.Forms.ToolStripButton();
            this.tscmdToggelView = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tscmdFirstRecord = new System.Windows.Forms.ToolStripButton();
            this.tscmdPreviousRecord = new System.Windows.Forms.ToolStripButton();
            this.tscmdNextRecord = new System.Windows.Forms.ToolStripButton();
            this.tscmdLastRecord = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tscmdShowPrintPreview = new System.Windows.Forms.ToolStripButton();
            this.tscmdPrintDocument = new System.Windows.Forms.ToolStripButton();
            this.tscmdHelp = new System.Windows.Forms.ToolStripButton();
            this.tscmdExit = new System.Windows.Forms.ToolStripButton();
            this.lblOrganisation = new System.Windows.Forms.Label();
            this.lblDocumentNo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblBankAccount = new System.Windows.Forms.Label();
            this.lblPayee = new System.Windows.Forms.Label();
            this.lblCheckNo = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.ckAllocated = new System.Windows.Forms.CheckBox();
            this.ckIssued = new System.Windows.Forms.CheckBox();
            this.cmdIssueCheck = new System.Windows.Forms.Button();
            this.cmdAllocate = new System.Windows.Forms.Button();
            this.txtOrganisation = new System.Windows.Forms.TextBox();
            this.txtDocumentNo = new System.Windows.Forms.TextBox();
            this.dtpPayDate = new System.Windows.Forms.DateTimePicker();
            this.txtCheckNo = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.visualStyler2 = new SkinSoft.VisualStyler.VisualStyler(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.ddgInvoice = new customControls.DropDownDataGrid();
            this.ckIsCustomer = new System.Windows.Forms.CheckBox();
            this.dtgBankCheck = new System.Windows.Forms.DataGridView();
            this.cmdNew = new System.Windows.Forms.Button();
            this.ntbAmount = new customControls.ctlNumberTextBox();
            this.ddgBankAccount = new customControls.DropDownDataGrid();
            this.ddgPayee = new customControls.DropDownDataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.mnuMainMenu = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visualStyler2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBankCheck)).BeginInit();
            this.mnuMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscmdNew,
            this.tscmdRefresh,
            this.tscmdSave,
            this.tscmdDelete,
            this.toolStripSeparator1,
            this.tscmdConfirm,
            this.tscmdReject,
            this.toolStripSeparator2,
            this.tscmdSearch,
            this.tscmdToggelView,
            this.toolStripSeparator3,
            this.tscmdFirstRecord,
            this.tscmdPreviousRecord,
            this.tscmdNextRecord,
            this.tscmdLastRecord,
            this.toolStripSeparator4,
            this.toolStripSeparator5,
            this.tscmdShowPrintPreview,
            this.tscmdPrintDocument,
            this.tscmdHelp,
            this.tscmdExit});
            this.tsMain.Location = new System.Drawing.Point(0, 24);
            this.tsMain.Margin = new System.Windows.Forms.Padding(1);
            this.tsMain.Name = "tsMain";
            this.tsMain.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tsMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsMain.Size = new System.Drawing.Size(528, 54);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "Malin Tool Bar";
            // 
            // tscmdNew
            // 
            this.tscmdNew.Image = ((System.Drawing.Image)(resources.GetObject("tscmdNew.Image")));
            this.tscmdNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdNew.Name = "tscmdNew";
            this.tscmdNew.Size = new System.Drawing.Size(36, 51);
            this.tscmdNew.Text = "New";
            this.tscmdNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdNew.ToolTipText = "New";
            this.tscmdNew.Click += new System.EventHandler(this.tscmdNew_Click);
            // 
            // tscmdRefresh
            // 
            this.tscmdRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tscmdRefresh.Image")));
            this.tscmdRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdRefresh.Name = "tscmdRefresh";
            this.tscmdRefresh.Size = new System.Drawing.Size(50, 51);
            this.tscmdRefresh.Text = "Refresh";
            this.tscmdRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdRefresh.ToolTipText = "Cancel";
            this.tscmdRefresh.Visible = false;
            // 
            // tscmdSave
            // 
            this.tscmdSave.Enabled = false;
            this.tscmdSave.Image = ((System.Drawing.Image)(resources.GetObject("tscmdSave.Image")));
            this.tscmdSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdSave.Name = "tscmdSave";
            this.tscmdSave.Size = new System.Drawing.Size(36, 51);
            this.tscmdSave.Text = "Save";
            this.tscmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdSave.ToolTipText = "Save";
            this.tscmdSave.Visible = false;
            // 
            // tscmdDelete
            // 
            this.tscmdDelete.Enabled = false;
            this.tscmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("tscmdDelete.Image")));
            this.tscmdDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdDelete.Name = "tscmdDelete";
            this.tscmdDelete.Size = new System.Drawing.Size(44, 51);
            this.tscmdDelete.Text = "Delete";
            this.tscmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdDelete.ToolTipText = "Delete";
            this.tscmdDelete.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 54);
            // 
            // tscmdConfirm
            // 
            this.tscmdConfirm.Image = ((System.Drawing.Image)(resources.GetObject("tscmdConfirm.Image")));
            this.tscmdConfirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdConfirm.Name = "tscmdConfirm";
            this.tscmdConfirm.Size = new System.Drawing.Size(55, 51);
            this.tscmdConfirm.Text = "Confirm";
            this.tscmdConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdConfirm.ToolTipText = "Confirm";
            this.tscmdConfirm.Click += new System.EventHandler(this.tscmdConfirm_Click);
            // 
            // tscmdReject
            // 
            this.tscmdReject.Image = ((System.Drawing.Image)(resources.GetObject("tscmdReject.Image")));
            this.tscmdReject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdReject.Name = "tscmdReject";
            this.tscmdReject.Size = new System.Drawing.Size(43, 51);
            this.tscmdReject.Text = "Reject";
            this.tscmdReject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdReject.ToolTipText = "Reject";
            this.tscmdReject.Click += new System.EventHandler(this.tscmdReject_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 54);
            // 
            // tscmdSearch
            // 
            this.tscmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("tscmdSearch.Image")));
            this.tscmdSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdSearch.Name = "tscmdSearch";
            this.tscmdSearch.Size = new System.Drawing.Size(46, 51);
            this.tscmdSearch.Text = "Search";
            this.tscmdSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdSearch.ToolTipText = "search";
            this.tscmdSearch.Click += new System.EventHandler(this.tscmdSearch_Click);
            // 
            // tscmdToggelView
            // 
            this.tscmdToggelView.Image = ((System.Drawing.Image)(resources.GetObject("tscmdToggelView.Image")));
            this.tscmdToggelView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdToggelView.Name = "tscmdToggelView";
            this.tscmdToggelView.Size = new System.Drawing.Size(36, 51);
            this.tscmdToggelView.Text = "Grid";
            this.tscmdToggelView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdToggelView.ToolTipText = "toogle View";
            this.tscmdToggelView.Click += new System.EventHandler(this.tscmdToggelView_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 54);
            // 
            // tscmdFirstRecord
            // 
            this.tscmdFirstRecord.Image = ((System.Drawing.Image)(resources.GetObject("tscmdFirstRecord.Image")));
            this.tscmdFirstRecord.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tscmdFirstRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdFirstRecord.Name = "tscmdFirstRecord";
            this.tscmdFirstRecord.Size = new System.Drawing.Size(36, 51);
            this.tscmdFirstRecord.Text = "First";
            this.tscmdFirstRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdFirstRecord.ToolTipText = "first Record";
            this.tscmdFirstRecord.Click += new System.EventHandler(this.tscmdFirstRecord_Click);
            // 
            // tscmdPreviousRecord
            // 
            this.tscmdPreviousRecord.Image = ((System.Drawing.Image)(resources.GetObject("tscmdPreviousRecord.Image")));
            this.tscmdPreviousRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdPreviousRecord.Name = "tscmdPreviousRecord";
            this.tscmdPreviousRecord.Size = new System.Drawing.Size(56, 51);
            this.tscmdPreviousRecord.Text = "Previous";
            this.tscmdPreviousRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdPreviousRecord.ToolTipText = "Previous record";
            this.tscmdPreviousRecord.Click += new System.EventHandler(this.tscmdPreviousRecord_Click);
            // 
            // tscmdNextRecord
            // 
            this.tscmdNextRecord.Image = ((System.Drawing.Image)(resources.GetObject("tscmdNextRecord.Image")));
            this.tscmdNextRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdNextRecord.Name = "tscmdNextRecord";
            this.tscmdNextRecord.Size = new System.Drawing.Size(36, 51);
            this.tscmdNextRecord.Text = "Next";
            this.tscmdNextRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdNextRecord.ToolTipText = "Next Record";
            this.tscmdNextRecord.Click += new System.EventHandler(this.tscmdNextRecord_Click);
            // 
            // tscmdLastRecord
            // 
            this.tscmdLastRecord.Image = ((System.Drawing.Image)(resources.GetObject("tscmdLastRecord.Image")));
            this.tscmdLastRecord.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tscmdLastRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdLastRecord.Name = "tscmdLastRecord";
            this.tscmdLastRecord.Size = new System.Drawing.Size(36, 51);
            this.tscmdLastRecord.Text = "Last";
            this.tscmdLastRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdLastRecord.ToolTipText = "Last Record";
            this.tscmdLastRecord.Click += new System.EventHandler(this.tscmdLastRecord_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 54);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 54);
            // 
            // tscmdShowPrintPreview
            // 
            this.tscmdShowPrintPreview.CheckOnClick = true;
            this.tscmdShowPrintPreview.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tscmdShowPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("tscmdShowPrintPreview.Image")));
            this.tscmdShowPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdShowPrintPreview.Name = "tscmdShowPrintPreview";
            this.tscmdShowPrintPreview.Size = new System.Drawing.Size(36, 51);
            this.tscmdShowPrintPreview.Text = "view";
            this.tscmdShowPrintPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdShowPrintPreview.ToolTipText = "print preview";
            this.tscmdShowPrintPreview.Click += new System.EventHandler(this.tscmdShowPrintPreview_Click);
            // 
            // tscmdPrintDocument
            // 
            this.tscmdPrintDocument.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tscmdPrintDocument.ForeColor = System.Drawing.Color.Red;
            this.tscmdPrintDocument.Image = ((System.Drawing.Image)(resources.GetObject("tscmdPrintDocument.Image")));
            this.tscmdPrintDocument.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdPrintDocument.Name = "tscmdPrintDocument";
            this.tscmdPrintDocument.Size = new System.Drawing.Size(36, 51);
            this.tscmdPrintDocument.Text = "Print";
            this.tscmdPrintDocument.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdPrintDocument.ToolTipText = "print";
            this.tscmdPrintDocument.Click += new System.EventHandler(this.tscmdPrintDocument_Click);
            // 
            // tscmdHelp
            // 
            this.tscmdHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdHelp.Name = "tscmdHelp";
            this.tscmdHelp.Size = new System.Drawing.Size(36, 19);
            this.tscmdHelp.Text = "Help";
            this.tscmdHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdHelp.ToolTipText = "help";
            this.tscmdHelp.Visible = false;
            // 
            // tscmdExit
            // 
            this.tscmdExit.Image = ((System.Drawing.Image)(resources.GetObject("tscmdExit.Image")));
            this.tscmdExit.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tscmdExit.Name = "tscmdExit";
            this.tscmdExit.Size = new System.Drawing.Size(36, 51);
            this.tscmdExit.Text = "Exit";
            this.tscmdExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdExit.ToolTipText = "exit";
            this.tscmdExit.Click += new System.EventHandler(this.tscmdExit_Click);
            // 
            // lblOrganisation
            // 
            this.lblOrganisation.AutoSize = true;
            this.lblOrganisation.Location = new System.Drawing.Point(19, 22);
            this.lblOrganisation.Name = "lblOrganisation";
            this.lblOrganisation.Size = new System.Drawing.Size(66, 13);
            this.lblOrganisation.TabIndex = 2;
            this.lblOrganisation.Text = "Organisation";
            this.lblOrganisation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDocumentNo
            // 
            this.lblDocumentNo.AutoSize = true;
            this.lblDocumentNo.Location = new System.Drawing.Point(12, 48);
            this.lblDocumentNo.Name = "lblDocumentNo";
            this.lblDocumentNo.Size = new System.Drawing.Size(73, 13);
            this.lblDocumentNo.TabIndex = 3;
            this.lblDocumentNo.Text = "Document No";
            this.lblDocumentNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(266, 48);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date";
            // 
            // lblBankAccount
            // 
            this.lblBankAccount.AutoSize = true;
            this.lblBankAccount.Location = new System.Drawing.Point(13, 183);
            this.lblBankAccount.Name = "lblBankAccount";
            this.lblBankAccount.Size = new System.Drawing.Size(75, 13);
            this.lblBankAccount.TabIndex = 5;
            this.lblBankAccount.Text = "Bank Account";
            this.lblBankAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblBankAccount.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lblBankAccount_MouseDoubleClick);
            // 
            // lblPayee
            // 
            this.lblPayee.AutoSize = true;
            this.lblPayee.Location = new System.Drawing.Point(23, 94);
            this.lblPayee.Name = "lblPayee";
            this.lblPayee.Size = new System.Drawing.Size(37, 13);
            this.lblPayee.TabIndex = 6;
            this.lblPayee.Text = "Payee";
            this.lblPayee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPayee.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lblPayee_MouseDoubleClick);
            // 
            // lblCheckNo
            // 
            this.lblCheckNo.AutoSize = true;
            this.lblCheckNo.Location = new System.Drawing.Point(207, 213);
            this.lblCheckNo.Name = "lblCheckNo";
            this.lblCheckNo.Size = new System.Drawing.Size(55, 13);
            this.lblCheckNo.TabIndex = 7;
            this.lblCheckNo.Text = "Check No";
            this.lblCheckNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCheckNo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lblCheckNo_MouseDoubleClick);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(43, 153);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(43, 13);
            this.lblAmount.TabIndex = 8;
            this.lblAmount.Text = "Amount";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAmount.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lblAmount_MouseDoubleClick);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(11, 253);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(51, 13);
            this.lblDescription.TabIndex = 9;
            this.lblDescription.Text = "Comment";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDescription.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lblDescription_MouseDoubleClick);
            // 
            // ckAllocated
            // 
            this.ckAllocated.AutoSize = true;
            this.ckAllocated.Enabled = false;
            this.ckAllocated.Location = new System.Drawing.Point(126, 319);
            this.ckAllocated.Name = "ckAllocated";
            this.ckAllocated.Size = new System.Drawing.Size(70, 17);
            this.ckAllocated.TabIndex = 10;
            this.ckAllocated.TabStop = false;
            this.ckAllocated.Text = "Allocated";
            this.ckAllocated.UseVisualStyleBackColor = true;
            // 
            // ckIssued
            // 
            this.ckIssued.AutoSize = true;
            this.ckIssued.Enabled = false;
            this.ckIssued.Location = new System.Drawing.Point(296, 319);
            this.ckIssued.Name = "ckIssued";
            this.ckIssued.Size = new System.Drawing.Size(57, 17);
            this.ckIssued.TabIndex = 11;
            this.ckIssued.TabStop = false;
            this.ckIssued.Text = "Issued";
            this.ckIssued.UseVisualStyleBackColor = true;
            // 
            // cmdIssueCheck
            // 
            this.cmdIssueCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdIssueCheck.Location = new System.Drawing.Point(59, 346);
            this.cmdIssueCheck.Name = "cmdIssueCheck";
            this.cmdIssueCheck.Size = new System.Drawing.Size(399, 40);
            this.cmdIssueCheck.TabIndex = 6;
            this.cmdIssueCheck.Text = "Issue Check";
            this.cmdIssueCheck.UseVisualStyleBackColor = true;
            this.cmdIssueCheck.Click += new System.EventHandler(this.cmdIssueCheck_Click);
            // 
            // cmdAllocate
            // 
            this.cmdAllocate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAllocate.Location = new System.Drawing.Point(103, 392);
            this.cmdAllocate.Name = "cmdAllocate";
            this.cmdAllocate.Size = new System.Drawing.Size(310, 32);
            this.cmdAllocate.TabIndex = 7;
            this.cmdAllocate.Text = "Allocate Payment";
            this.cmdAllocate.UseVisualStyleBackColor = true;
            this.cmdAllocate.Click += new System.EventHandler(this.cmdAllocate_Click);
            // 
            // txtOrganisation
            // 
            this.txtOrganisation.Enabled = false;
            this.txtOrganisation.Location = new System.Drawing.Point(89, 19);
            this.txtOrganisation.Name = "txtOrganisation";
            this.txtOrganisation.Size = new System.Drawing.Size(207, 20);
            this.txtOrganisation.TabIndex = 14;
            this.txtOrganisation.TabStop = false;
            // 
            // txtDocumentNo
            // 
            this.txtDocumentNo.Enabled = false;
            this.txtDocumentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumentNo.Location = new System.Drawing.Point(90, 45);
            this.txtDocumentNo.Name = "txtDocumentNo";
            this.txtDocumentNo.Size = new System.Drawing.Size(163, 21);
            this.txtDocumentNo.TabIndex = 17;
            this.txtDocumentNo.TabStop = false;
            // 
            // dtpPayDate
            // 
            this.dtpPayDate.Enabled = false;
            this.dtpPayDate.Location = new System.Drawing.Point(301, 45);
            this.dtpPayDate.Name = "dtpPayDate";
            this.dtpPayDate.Size = new System.Drawing.Size(196, 20);
            this.dtpPayDate.TabIndex = 18;
            // 
            // txtCheckNo
            // 
            this.txtCheckNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckNo.Location = new System.Drawing.Point(268, 209);
            this.txtCheckNo.Name = "txtCheckNo";
            this.txtCheckNo.Size = new System.Drawing.Size(187, 21);
            this.txtCheckNo.TabIndex = 4;
            this.txtCheckNo.Leave += new System.EventHandler(this.txtCheckNo_Leave);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(67, 239);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(418, 67);
            this.txtDescription.TabIndex = 5;
            // 
            // visualStyler2
            // 
            this.visualStyler2.License = ((SkinSoft.VisualStyler.Licensing.VisualStylerLicense)(resources.GetObject("visualStyler2.License")));
            this.visualStyler2.LoadVisualStyle(null, "Office2007 (Blue).vssf");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblInvoice);
            this.groupBox1.Controls.Add(this.ddgInvoice);
            this.groupBox1.Controls.Add(this.ckIsCustomer);
            this.groupBox1.Controls.Add(this.dtgBankCheck);
            this.groupBox1.Controls.Add(this.cmdNew);
            this.groupBox1.Controls.Add(this.lblOrganisation);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.lblDocumentNo);
            this.groupBox1.Controls.Add(this.txtCheckNo);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.ntbAmount);
            this.groupBox1.Controls.Add(this.lblBankAccount);
            this.groupBox1.Controls.Add(this.dtpPayDate);
            this.groupBox1.Controls.Add(this.lblPayee);
            this.groupBox1.Controls.Add(this.txtDocumentNo);
            this.groupBox1.Controls.Add(this.lblCheckNo);
            this.groupBox1.Controls.Add(this.ddgBankAccount);
            this.groupBox1.Controls.Add(this.lblAmount);
            this.groupBox1.Controls.Add(this.ddgPayee);
            this.groupBox1.Controls.Add(this.lblDescription);
            this.groupBox1.Controls.Add(this.txtOrganisation);
            this.groupBox1.Controls.Add(this.ckAllocated);
            this.groupBox1.Controls.Add(this.cmdAllocate);
            this.groupBox1.Controls.Add(this.ckIssued);
            this.groupBox1.Controls.Add(this.cmdIssueCheck);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 431);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // lblInvoice
            // 
            this.lblInvoice.AutoSize = true;
            this.lblInvoice.Location = new System.Drawing.Point(218, 125);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(71, 13);
            this.lblInvoice.TabIndex = 24;
            this.lblInvoice.Text = "Sales Invoice";
            this.lblInvoice.Visible = false;
            // 
            // ddgInvoice
            // 
            this.ddgInvoice.AutoFilter = true;
            this.ddgInvoice.AutoSize = true;
            this.ddgInvoice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgInvoice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgInvoice.ClearButtonEnabled = true;
            this.ddgInvoice.DataTablePrimaryKey = ((ushort)(0));
            this.ddgInvoice.FindButtonEnabled = true;
            this.ddgInvoice.HiddenColoumns = new int[0];
            this.ddgInvoice.Image = null;
            this.ddgInvoice.Location = new System.Drawing.Point(292, 116);
            this.ddgInvoice.Margin = new System.Windows.Forms.Padding(0);
            this.ddgInvoice.Name = "ddgInvoice";
            this.ddgInvoice.NewButtonEnabled = true;
            this.ddgInvoice.RefreshButtonEnabled = true;
            this.ddgInvoice.SelectedColomnIdex = 0;
            this.ddgInvoice.SelectedItem = "";
            this.ddgInvoice.SelectedRowKey = null;
            this.ddgInvoice.ShowGridFunctions = false;
            this.ddgInvoice.Size = new System.Drawing.Size(144, 31);
            this.ddgInvoice.TabIndex = 23;
            this.ddgInvoice.Visible = false;
            this.ddgInvoice.SelectedItemClicked += new System.EventHandler(this.ddgInvoice_SelectedItemClicked);
            this.ddgInvoice.selectedItemChanged += new System.EventHandler(this.ddgInvoice_selectedItemChanged);
            // 
            // ckIsCustomer
            // 
            this.ckIsCustomer.AutoSize = true;
            this.ckIsCustomer.Checked = true;
            this.ckIsCustomer.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.ckIsCustomer.Location = new System.Drawing.Point(103, 121);
            this.ckIsCustomer.Name = "ckIsCustomer";
            this.ckIsCustomer.Size = new System.Drawing.Size(81, 17);
            this.ckIsCustomer.TabIndex = 22;
            this.ckIsCustomer.Text = "Is Customer";
            this.ckIsCustomer.ThreeState = true;
            this.ckIsCustomer.UseVisualStyleBackColor = true;
            this.ckIsCustomer.CheckStateChanged += new System.EventHandler(this.ckIsCustomer_CheckStateChanged);
            this.ckIsCustomer.CheckedChanged += new System.EventHandler(this.ckIsCustomer_CheckedChanged);
            // 
            // dtgBankCheck
            // 
            this.dtgBankCheck.AllowUserToAddRows = false;
            this.dtgBankCheck.AllowUserToDeleteRows = false;
            this.dtgBankCheck.AllowUserToOrderColumns = true;
            this.dtgBankCheck.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgBankCheck.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgBankCheck.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgBankCheck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBankCheck.Location = new System.Drawing.Point(4, 7);
            this.dtgBankCheck.MultiSelect = false;
            this.dtgBankCheck.Name = "dtgBankCheck";
            this.dtgBankCheck.ReadOnly = true;
            this.dtgBankCheck.RowHeadersWidth = 20;
            this.dtgBankCheck.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBankCheck.Size = new System.Drawing.Size(521, 10);
            this.dtgBankCheck.TabIndex = 20;
            this.dtgBankCheck.Visible = false;
            this.dtgBankCheck.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgBankCheck_ColumnHeaderMouseClick);
            this.dtgBankCheck.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBankCheck_CellClick);
            this.dtgBankCheck.SelectionChanged += new System.EventHandler(this.dtgBankCheck_SelectionChanged);
            // 
            // cmdNew
            // 
            this.cmdNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNew.Location = new System.Drawing.Point(443, 89);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(40, 23);
            this.cmdNew.TabIndex = 19;
            this.cmdNew.Text = "New";
            this.cmdNew.UseVisualStyleBackColor = true;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // ntbAmount
            // 
            this.ntbAmount.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbAmount.AllowedLength = 0;
            this.ntbAmount.AllowLeadingZeros = false;
            this.ntbAmount.AllowNegative = false;
            this.ntbAmount.Amount = "0";
            this.ntbAmount.defaultAmount = "0";
            this.ntbAmount.Location = new System.Drawing.Point(91, 149);
            this.ntbAmount.Name = "ntbAmount";
            this.ntbAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbAmount.ShowThousandSeparetor = true;
            this.ntbAmount.Size = new System.Drawing.Size(187, 23);
            this.ntbAmount.StandardPrecision = 2;
            this.ntbAmount.TabIndex = 2;
            // 
            // ddgBankAccount
            // 
            this.ddgBankAccount.AutoFilter = true;
            this.ddgBankAccount.AutoSize = true;
            this.ddgBankAccount.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgBankAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgBankAccount.ClearButtonEnabled = true;
            this.ddgBankAccount.DataTablePrimaryKey = ((ushort)(0));
            this.ddgBankAccount.FindButtonEnabled = true;
            this.ddgBankAccount.HiddenColoumns = new int[0];
            this.ddgBankAccount.Image = null;
            this.ddgBankAccount.Location = new System.Drawing.Point(89, 175);
            this.ddgBankAccount.Margin = new System.Windows.Forms.Padding(0);
            this.ddgBankAccount.Name = "ddgBankAccount";
            this.ddgBankAccount.NewButtonEnabled = true;
            this.ddgBankAccount.RefreshButtonEnabled = true;
            this.ddgBankAccount.SelectedColomnIdex = 0;
            this.ddgBankAccount.SelectedItem = "";
            this.ddgBankAccount.SelectedRowKey = null;
            this.ddgBankAccount.ShowGridFunctions = false;
            this.ddgBankAccount.Size = new System.Drawing.Size(316, 31);
            this.ddgBankAccount.TabIndex = 3;
            this.ddgBankAccount.SelectedItemClicked += new System.EventHandler(this.ddgBankAccount_SelectedItemClicked);
            this.ddgBankAccount.selectedItemChanged += new System.EventHandler(this.ddgBankAccount_selectedItemChanged);
            // 
            // ddgPayee
            // 
            this.ddgPayee.AutoFilter = true;
            this.ddgPayee.AutoSize = true;
            this.ddgPayee.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgPayee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgPayee.ClearButtonEnabled = true;
            this.ddgPayee.DataTablePrimaryKey = ((ushort)(0));
            this.ddgPayee.FindButtonEnabled = true;
            this.ddgPayee.HiddenColoumns = new int[0];
            this.ddgPayee.Image = null;
            this.ddgPayee.Location = new System.Drawing.Point(60, 86);
            this.ddgPayee.Margin = new System.Windows.Forms.Padding(0);
            this.ddgPayee.Name = "ddgPayee";
            this.ddgPayee.NewButtonEnabled = true;
            this.ddgPayee.RefreshButtonEnabled = true;
            this.ddgPayee.SelectedColomnIdex = 0;
            this.ddgPayee.SelectedItem = "";
            this.ddgPayee.SelectedRowKey = null;
            this.ddgPayee.ShowGridFunctions = false;
            this.ddgPayee.Size = new System.Drawing.Size(380, 31);
            this.ddgPayee.TabIndex = 1;
            this.ddgPayee.SelectedItemClicked += new System.EventHandler(this.ddgPayee_SelectedItemClicked);
            this.ddgPayee.selectedItemChanged += new System.EventHandler(this.ddgPayee_selectedItemChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(522, 412);
            this.label1.TabIndex = 21;
            this.label1.DoubleClick += new System.EventHandler(this.label1_DoubleClick);
            // 
            // mnuMainMenu
            // 
            this.mnuMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.mnuMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMainMenu.Name = "mnuMainMenu";
            this.mnuMainMenu.Size = new System.Drawing.Size(528, 24);
            this.mnuMainMenu.TabIndex = 20;
            this.mnuMainMenu.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSettings});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuSettings
            // 
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(116, 22);
            this.mnuSettings.Text = "Settings";
            this.mnuSettings.Click += new System.EventHandler(this.mnuSettings_Click);
            // 
            // frmBankPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 509);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.mnuMainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMainMenu;
            this.MaximizeBox = false;
            this.Name = "frmBankPayment";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bank Payments (v10.1a)";
            this.Load += new System.EventHandler(this.frmBankPayment_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBankPayment_FormClosing);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visualStyler2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBankCheck)).EndInit();
            this.mnuMainMenu.ResumeLayout(false);
            this.mnuMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tscmdNew;
        private System.Windows.Forms.ToolStripButton tscmdDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tscmdSave;
        private System.Windows.Forms.ToolStripButton tscmdRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tscmdSearch;
        private System.Windows.Forms.ToolStripButton tscmdToggelView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tscmdFirstRecord;
        private System.Windows.Forms.ToolStripButton tscmdPreviousRecord;
        private System.Windows.Forms.ToolStripButton tscmdNextRecord;
        private System.Windows.Forms.ToolStripButton tscmdLastRecord;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tscmdHelp;
        private System.Windows.Forms.ToolStripButton tscmdConfirm;
        private System.Windows.Forms.ToolStripButton tscmdReject;
        private System.Windows.Forms.ToolStripButton tscmdExit;        
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tscmdPrintDocument;
        private System.Windows.Forms.ToolStripButton tscmdShowPrintPreview;
        private System.Windows.Forms.Label lblOrganisation;
        private System.Windows.Forms.Label lblDocumentNo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblBankAccount;
        private System.Windows.Forms.Label lblPayee;
        private System.Windows.Forms.Label lblCheckNo;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.CheckBox ckAllocated;
        private System.Windows.Forms.CheckBox ckIssued;
        private System.Windows.Forms.Button cmdIssueCheck;
        private System.Windows.Forms.Button cmdAllocate;
        private System.Windows.Forms.TextBox txtOrganisation;
        private customControls.DropDownDataGrid ddgPayee;
        private customControls.DropDownDataGrid ddgBankAccount;
        private System.Windows.Forms.TextBox txtDocumentNo;
        private System.Windows.Forms.DateTimePicker dtpPayDate;
        private customControls.ctlNumberTextBox ntbAmount;
        private System.Windows.Forms.TextBox txtCheckNo;
        private System.Windows.Forms.TextBox txtDescription;
        private SkinSoft.VisualStyler.VisualStyler visualStyler2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdNew;
        private System.Windows.Forms.DataGridView dtgBankCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckIsCustomer;
        private customControls.DropDownDataGrid ddgInvoice;
        private System.Windows.Forms.Label lblInvoice;
        private System.Windows.Forms.MenuStrip mnuMainMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        
    }
}

