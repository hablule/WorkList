namespace EasyMove
{
    partial class frmInventoryIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventoryIn));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mnuMainMenu = new System.Windows.Forms.MenuStrip();
            this.mnuTaskMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewTask = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewMovement = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewRequest = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveReocord = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteReocrd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConfirmReocrd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRejectRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSearchRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToggleView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGoTo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFirstRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPreviousRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNextRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLastRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettingsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDataBaseConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStationAccess = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProcessAccess = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWarehouseAccess = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tscmdViewStock = new System.Windows.Forms.ToolStripButton();
            this.tscmdExit = new System.Windows.Forms.ToolStripButton();
            this.lblUOM = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblProcut = new System.Windows.Forms.Label();
            this.lblDocumentNumber = new System.Windows.Forms.Label();
            this.lblDocumentType = new System.Windows.Forms.Label();
            this.lblMovementDate = new System.Windows.Forms.Label();
            this.lblWareHouse = new System.Windows.Forms.Label();
            this.txtDocumentNumber = new System.Windows.Forms.TextBox();
            this.cmbDocumentType = new System.Windows.Forms.ComboBox();
            this.dtpMoveDate = new System.Windows.Forms.DateTimePicker();
            this.cmbMoveFrom = new System.Windows.Forms.ComboBox();
            this.panelMainContainer = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ddgProduct = new EasyMove.DropDownDataGrid();
            this.cmdCreateLinesFrom = new System.Windows.Forms.Button();
            this.crvPrintPreview = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.crptMaterialMovement = new EasyMove.crptMaterialMovement();
            this.lblInStockQty = new System.Windows.Forms.Label();
            this.txtRecordDetailDescription = new System.Windows.Forms.TextBox();
            this.lblRecordDetailDescription = new System.Windows.Forms.Label();
            this.cmdAddOrModifyRecordDetail = new System.Windows.Forms.Button();
            this.ntbQuantity = new EasyMove.ctlNumberTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ddgBpartner = new EasyMove.DropDownDataGrid();
            this.lblBpartner = new System.Windows.Forms.Label();
            this.cmbOrganisation = new System.Windows.Forms.ComboBox();
            this.lblOrganisation = new System.Windows.Forms.Label();
            this.dtgMoveSummary = new System.Windows.Forms.DataGridView();
            this.txtDescriptionOrComment = new System.Windows.Forms.TextBox();
            this.lblDescriptionOrComment = new System.Windows.Forms.Label();
            this.dtgMoveLine = new System.Windows.Forms.DataGridView();
            this.ssMainStatusBar = new System.Windows.Forms.StatusStrip();
            this.sbStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.updateRecordStatusToLatestStatus = new System.ComponentModel.BackgroundWorker();
            this.prtPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.prtShowPrintDialogue = new System.Windows.Forms.PrintDialog();
            this.tmrCloseWindow = new System.Windows.Forms.Timer(this.components);
            this.mnuMainMenu.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.panelMainContainer.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMoveSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMoveLine)).BeginInit();
            this.ssMainStatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMainMenu
            // 
            this.mnuMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTaskMenu,
            this.mnuViewMenu,
            this.mnuSettingsMenu});
            this.mnuMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMainMenu.Name = "mnuMainMenu";
            this.mnuMainMenu.Size = new System.Drawing.Size(676, 24);
            this.mnuMainMenu.TabIndex = 0;
            this.mnuMainMenu.Text = "menuStrip1";
            // 
            // mnuTaskMenu
            // 
            this.mnuTaskMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewTask,
            this.mnuSaveReocord,
            this.mnuDeleteReocrd,
            this.mnuConfirmReocrd,
            this.mnuRejectRecord,
            this.mnuExit});
            this.mnuTaskMenu.Name = "mnuTaskMenu";
            this.mnuTaskMenu.Size = new System.Drawing.Size(41, 20);
            this.mnuTaskMenu.Text = "Task";
            // 
            // mnuNewTask
            // 
            this.mnuNewTask.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewMovement,
            this.mnuNewRequest});
            this.mnuNewTask.Name = "mnuNewTask";
            this.mnuNewTask.Size = new System.Drawing.Size(159, 22);
            this.mnuNewTask.Text = "New";
            // 
            // mnuNewMovement
            // 
            this.mnuNewMovement.Name = "mnuNewMovement";
            this.mnuNewMovement.Size = new System.Drawing.Size(135, 22);
            this.mnuNewMovement.Text = "Movement";
            this.mnuNewMovement.Click += new System.EventHandler(this.mnuNewMovement_Click);
            // 
            // mnuNewRequest
            // 
            this.mnuNewRequest.Name = "mnuNewRequest";
            this.mnuNewRequest.Size = new System.Drawing.Size(135, 22);
            this.mnuNewRequest.Text = "Request";
            this.mnuNewRequest.Click += new System.EventHandler(this.mnuNewRequest_Click);
            // 
            // mnuSaveReocord
            // 
            this.mnuSaveReocord.Name = "mnuSaveReocord";
            this.mnuSaveReocord.Size = new System.Drawing.Size(159, 22);
            this.mnuSaveReocord.Text = "Save Record";
            this.mnuSaveReocord.Click += new System.EventHandler(this.mnuSaveReocord_Click);
            // 
            // mnuDeleteReocrd
            // 
            this.mnuDeleteReocrd.Name = "mnuDeleteReocrd";
            this.mnuDeleteReocrd.Size = new System.Drawing.Size(159, 22);
            this.mnuDeleteReocrd.Text = "Delete Record";
            this.mnuDeleteReocrd.Click += new System.EventHandler(this.mnuDeleteReocrd_Click);
            // 
            // mnuConfirmReocrd
            // 
            this.mnuConfirmReocrd.Name = "mnuConfirmReocrd";
            this.mnuConfirmReocrd.Size = new System.Drawing.Size(159, 22);
            this.mnuConfirmReocrd.Text = "Confirm Record";
            this.mnuConfirmReocrd.Click += new System.EventHandler(this.mnuConfirmReocrd_Click);
            // 
            // mnuRejectRecord
            // 
            this.mnuRejectRecord.Name = "mnuRejectRecord";
            this.mnuRejectRecord.Size = new System.Drawing.Size(159, 22);
            this.mnuRejectRecord.Text = "Reject Record";
            this.mnuRejectRecord.Click += new System.EventHandler(this.mnuRejectRecord_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(159, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuViewMenu
            // 
            this.mnuViewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSearchRecord,
            this.mnuToggleView,
            this.mnuGoTo});
            this.mnuViewMenu.Name = "mnuViewMenu";
            this.mnuViewMenu.Size = new System.Drawing.Size(41, 20);
            this.mnuViewMenu.Text = "View";
            // 
            // mnuSearchRecord
            // 
            this.mnuSearchRecord.Name = "mnuSearchRecord";
            this.mnuSearchRecord.Size = new System.Drawing.Size(155, 22);
            this.mnuSearchRecord.Text = "Search Record";
            this.mnuSearchRecord.Click += new System.EventHandler(this.mnuSearchRecord_Click);
            // 
            // mnuToggleView
            // 
            this.mnuToggleView.Name = "mnuToggleView";
            this.mnuToggleView.Size = new System.Drawing.Size(155, 22);
            this.mnuToggleView.Text = "Toggle View";
            this.mnuToggleView.Click += new System.EventHandler(this.mnuToggleView_Click);
            // 
            // mnuGoTo
            // 
            this.mnuGoTo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFirstRecord,
            this.mnuPreviousRecord,
            this.mnuNextRecord,
            this.mnuLastRecord});
            this.mnuGoTo.Name = "mnuGoTo";
            this.mnuGoTo.Size = new System.Drawing.Size(155, 22);
            this.mnuGoTo.Text = "Go to";
            // 
            // mnuFirstRecord
            // 
            this.mnuFirstRecord.Name = "mnuFirstRecord";
            this.mnuFirstRecord.Size = new System.Drawing.Size(163, 22);
            this.mnuFirstRecord.Text = "First Record";
            this.mnuFirstRecord.Click += new System.EventHandler(this.mnuFirstRecord_Click);
            // 
            // mnuPreviousRecord
            // 
            this.mnuPreviousRecord.Name = "mnuPreviousRecord";
            this.mnuPreviousRecord.Size = new System.Drawing.Size(163, 22);
            this.mnuPreviousRecord.Text = "Previous Reocrd";
            this.mnuPreviousRecord.Click += new System.EventHandler(this.mnuPreviousRecord_Click);
            // 
            // mnuNextRecord
            // 
            this.mnuNextRecord.Name = "mnuNextRecord";
            this.mnuNextRecord.Size = new System.Drawing.Size(163, 22);
            this.mnuNextRecord.Text = "Next Record";
            this.mnuNextRecord.Click += new System.EventHandler(this.mnuNextRecord_Click);
            // 
            // mnuLastRecord
            // 
            this.mnuLastRecord.Name = "mnuLastRecord";
            this.mnuLastRecord.Size = new System.Drawing.Size(163, 22);
            this.mnuLastRecord.Text = "Last Record";
            this.mnuLastRecord.Click += new System.EventHandler(this.mnuLastRecord_Click);
            // 
            // mnuSettingsMenu
            // 
            this.mnuSettingsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDataBaseConnection,
            this.mnuStationAccess,
            this.mnuProcessAccess,
            this.mnuWarehouseAccess});
            this.mnuSettingsMenu.Name = "mnuSettingsMenu";
            this.mnuSettingsMenu.Size = new System.Drawing.Size(58, 20);
            this.mnuSettingsMenu.Text = "Settings";
            this.mnuSettingsMenu.Visible = false;
            // 
            // mnuDataBaseConnection
            // 
            this.mnuDataBaseConnection.Name = "mnuDataBaseConnection";
            this.mnuDataBaseConnection.Size = new System.Drawing.Size(191, 22);
            this.mnuDataBaseConnection.Text = "Data Base Connection";
            this.mnuDataBaseConnection.Click += new System.EventHandler(this.mnuDataBaseConnection_Click);
            // 
            // mnuStationAccess
            // 
            this.mnuStationAccess.Name = "mnuStationAccess";
            this.mnuStationAccess.Size = new System.Drawing.Size(191, 22);
            this.mnuStationAccess.Text = "Staiton Access";
            this.mnuStationAccess.Click += new System.EventHandler(this.mnuStationAccess_Click);
            // 
            // mnuProcessAccess
            // 
            this.mnuProcessAccess.Name = "mnuProcessAccess";
            this.mnuProcessAccess.Size = new System.Drawing.Size(191, 22);
            this.mnuProcessAccess.Text = "Process Access";
            this.mnuProcessAccess.Click += new System.EventHandler(this.mnuProcessAccess_Click);
            // 
            // mnuWarehouseAccess
            // 
            this.mnuWarehouseAccess.Name = "mnuWarehouseAccess";
            this.mnuWarehouseAccess.Size = new System.Drawing.Size(191, 22);
            this.mnuWarehouseAccess.Text = "Warehouse Access";
            this.mnuWarehouseAccess.Click += new System.EventHandler(this.mnuWarehouseAccess_Click);
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
            this.tscmdViewStock,
            this.tscmdExit});
            this.tsMain.Location = new System.Drawing.Point(0, 24);
            this.tsMain.Margin = new System.Windows.Forms.Padding(1);
            this.tsMain.Name = "tsMain";
            this.tsMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsMain.Size = new System.Drawing.Size(676, 52);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "Malin Tool Bar";
            // 
            // tscmdNew
            // 
            this.tscmdNew.Image = ((System.Drawing.Image)(resources.GetObject("tscmdNew.Image")));
            this.tscmdNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdNew.Name = "tscmdNew";
            this.tscmdNew.Size = new System.Drawing.Size(36, 49);
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
            this.tscmdRefresh.Size = new System.Drawing.Size(49, 49);
            this.tscmdRefresh.Text = "Refresh";
            this.tscmdRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdRefresh.ToolTipText = "Cancel";
            this.tscmdRefresh.Visible = false;
            this.tscmdRefresh.Click += new System.EventHandler(this.tscmdRefresh_Click);
            // 
            // tscmdSave
            // 
            this.tscmdSave.Image = ((System.Drawing.Image)(resources.GetObject("tscmdSave.Image")));
            this.tscmdSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdSave.Name = "tscmdSave";
            this.tscmdSave.Size = new System.Drawing.Size(36, 49);
            this.tscmdSave.Text = "Save";
            this.tscmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdSave.ToolTipText = "Save";
            this.tscmdSave.Click += new System.EventHandler(this.tscmdSave_Click);
            // 
            // tscmdDelete
            // 
            this.tscmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("tscmdDelete.Image")));
            this.tscmdDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdDelete.Name = "tscmdDelete";
            this.tscmdDelete.Size = new System.Drawing.Size(42, 49);
            this.tscmdDelete.Text = "Delete";
            this.tscmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdDelete.ToolTipText = "Delete";
            this.tscmdDelete.Visible = false;
            this.tscmdDelete.Click += new System.EventHandler(this.tscmdDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 52);
            // 
            // tscmdConfirm
            // 
            this.tscmdConfirm.Image = ((System.Drawing.Image)(resources.GetObject("tscmdConfirm.Image")));
            this.tscmdConfirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdConfirm.Name = "tscmdConfirm";
            this.tscmdConfirm.Size = new System.Drawing.Size(48, 49);
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
            this.tscmdReject.Size = new System.Drawing.Size(42, 49);
            this.tscmdReject.Text = "Reject";
            this.tscmdReject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdReject.ToolTipText = "Reject";
            this.tscmdReject.Click += new System.EventHandler(this.tscmdReject_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 52);
            // 
            // tscmdSearch
            // 
            this.tscmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("tscmdSearch.Image")));
            this.tscmdSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdSearch.Name = "tscmdSearch";
            this.tscmdSearch.Size = new System.Drawing.Size(44, 49);
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
            this.tscmdToggelView.Size = new System.Drawing.Size(36, 49);
            this.tscmdToggelView.Text = "Grid";
            this.tscmdToggelView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdToggelView.ToolTipText = "toogle View";
            this.tscmdToggelView.Click += new System.EventHandler(this.tscmdToggelView_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 52);
            // 
            // tscmdFirstRecord
            // 
            this.tscmdFirstRecord.Image = ((System.Drawing.Image)(resources.GetObject("tscmdFirstRecord.Image")));
            this.tscmdFirstRecord.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tscmdFirstRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdFirstRecord.Name = "tscmdFirstRecord";
            this.tscmdFirstRecord.Size = new System.Drawing.Size(36, 49);
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
            this.tscmdPreviousRecord.Size = new System.Drawing.Size(52, 49);
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
            this.tscmdNextRecord.Size = new System.Drawing.Size(36, 49);
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
            this.tscmdLastRecord.Size = new System.Drawing.Size(36, 49);
            this.tscmdLastRecord.Text = "Last";
            this.tscmdLastRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdLastRecord.ToolTipText = "Last Record";
            this.tscmdLastRecord.Click += new System.EventHandler(this.tscmdLastRecord_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 52);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 52);
            // 
            // tscmdShowPrintPreview
            // 
            this.tscmdShowPrintPreview.CheckOnClick = true;
            this.tscmdShowPrintPreview.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tscmdShowPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("tscmdShowPrintPreview.Image")));
            this.tscmdShowPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdShowPrintPreview.Name = "tscmdShowPrintPreview";
            this.tscmdShowPrintPreview.Size = new System.Drawing.Size(36, 49);
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
            this.tscmdPrintDocument.Size = new System.Drawing.Size(36, 49);
            this.tscmdPrintDocument.Text = "Print";
            this.tscmdPrintDocument.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdPrintDocument.ToolTipText = "print";
            this.tscmdPrintDocument.Click += new System.EventHandler(this.tscmdPrintDocument_Click);
            // 
            // tscmdHelp
            // 
            this.tscmdHelp.Image = global::EasyMove.Properties.Resources.help;
            this.tscmdHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscmdHelp.Name = "tscmdHelp";
            this.tscmdHelp.Size = new System.Drawing.Size(36, 49);
            this.tscmdHelp.Text = "Help";
            this.tscmdHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdHelp.ToolTipText = "help";
            this.tscmdHelp.Visible = false;
            // 
            // tscmdViewStock
            // 
            this.tscmdViewStock.Image = ((System.Drawing.Image)(resources.GetObject("tscmdViewStock.Image")));
            this.tscmdViewStock.ImageTransparentColor = System.Drawing.Color.White;
            this.tscmdViewStock.Name = "tscmdViewStock";
            this.tscmdViewStock.Size = new System.Drawing.Size(37, 49);
            this.tscmdViewStock.Text = "Stock";
            this.tscmdViewStock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdViewStock.Click += new System.EventHandler(this.tscmdViewStock_Click);
            // 
            // tscmdExit
            // 
            this.tscmdExit.Image = ((System.Drawing.Image)(resources.GetObject("tscmdExit.Image")));
            this.tscmdExit.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tscmdExit.Name = "tscmdExit";
            this.tscmdExit.Size = new System.Drawing.Size(36, 49);
            this.tscmdExit.Text = "Exit";
            this.tscmdExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscmdExit.ToolTipText = "exit";
            this.tscmdExit.Click += new System.EventHandler(this.tscmdExit_Click);
            // 
            // lblUOM
            // 
            this.lblUOM.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUOM.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblUOM.Location = new System.Drawing.Point(303, 265);
            this.lblUOM.Name = "lblUOM";
            this.lblUOM.Size = new System.Drawing.Size(48, 23);
            this.lblUOM.TabIndex = 2;
            this.lblUOM.Text = "Pcs.";
            this.lblUOM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblQuantity
            // 
            this.lblQuantity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblQuantity.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblQuantity.Location = new System.Drawing.Point(68, 265);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(51, 21);
            this.lblQuantity.TabIndex = 1;
            this.lblQuantity.Text = "Quantity";
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProcut
            // 
            this.lblProcut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblProcut.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblProcut.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblProcut.Location = new System.Drawing.Point(64, 233);
            this.lblProcut.Name = "lblProcut";
            this.lblProcut.Size = new System.Drawing.Size(54, 22);
            this.lblProcut.TabIndex = 0;
            this.lblProcut.Text = "Product";
            this.lblProcut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDocumentNumber
            // 
            this.lblDocumentNumber.Location = new System.Drawing.Point(9, 33);
            this.lblDocumentNumber.Name = "lblDocumentNumber";
            this.lblDocumentNumber.Size = new System.Drawing.Size(95, 20);
            this.lblDocumentNumber.TabIndex = 3;
            this.lblDocumentNumber.Text = "Document Number";
            this.lblDocumentNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDocumentNumber.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lblDocumentNumber_MouseDoubleClick);
            // 
            // lblDocumentType
            // 
            this.lblDocumentType.Location = new System.Drawing.Point(9, 56);
            this.lblDocumentType.Name = "lblDocumentType";
            this.lblDocumentType.Size = new System.Drawing.Size(95, 20);
            this.lblDocumentType.TabIndex = 4;
            this.lblDocumentType.Text = "Document Type";
            this.lblDocumentType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMovementDate
            // 
            this.lblMovementDate.Location = new System.Drawing.Point(347, 35);
            this.lblMovementDate.Name = "lblMovementDate";
            this.lblMovementDate.Size = new System.Drawing.Size(55, 20);
            this.lblMovementDate.TabIndex = 5;
            this.lblMovementDate.Text = "Date";
            this.lblMovementDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMovementDate.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lblMovementDate_MouseDoubleClick);
            // 
            // lblWareHouse
            // 
            this.lblWareHouse.Location = new System.Drawing.Point(9, 117);
            this.lblWareHouse.Name = "lblWareHouse";
            this.lblWareHouse.Size = new System.Drawing.Size(95, 20);
            this.lblWareHouse.TabIndex = 6;
            this.lblWareHouse.Text = "WareHouse";
            this.lblWareHouse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDocumentNumber
            // 
            this.txtDocumentNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumentNumber.Location = new System.Drawing.Point(110, 33);
            this.txtDocumentNumber.Name = "txtDocumentNumber";
            this.txtDocumentNumber.Size = new System.Drawing.Size(223, 20);
            this.txtDocumentNumber.TabIndex = 15;
            // 
            // cmbDocumentType
            // 
            this.cmbDocumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocumentType.FormattingEnabled = true;
            this.cmbDocumentType.Location = new System.Drawing.Point(110, 57);
            this.cmbDocumentType.Name = "cmbDocumentType";
            this.cmbDocumentType.Size = new System.Drawing.Size(201, 21);
            this.cmbDocumentType.TabIndex = 20;
            this.cmbDocumentType.SelectedIndexChanged += new System.EventHandler(this.cmbDocumentType_SelectedIndexChanged);
            this.cmbDocumentType.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbDocumentType_KeyUp);
            this.cmbDocumentType.DropDownClosed += new System.EventHandler(this.cmbDocumentType_SelectedIndexChanged);
            // 
            // dtpMoveDate
            // 
            this.dtpMoveDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpMoveDate.Location = new System.Drawing.Point(407, 34);
            this.dtpMoveDate.Name = "dtpMoveDate";
            this.dtpMoveDate.Size = new System.Drawing.Size(241, 20);
            this.dtpMoveDate.TabIndex = 25;
            // 
            // cmbMoveFrom
            // 
            this.cmbMoveFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoveFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMoveFrom.FormattingEnabled = true;
            this.cmbMoveFrom.Location = new System.Drawing.Point(110, 117);
            this.cmbMoveFrom.Name = "cmbMoveFrom";
            this.cmbMoveFrom.Size = new System.Drawing.Size(189, 21);
            this.cmbMoveFrom.TabIndex = 30;
            this.cmbMoveFrom.SelectedIndexChanged += new System.EventHandler(this.cmbMoveFrom_SelectedIndexChanged);
            this.cmbMoveFrom.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbMoveFrom_KeyUp);
            this.cmbMoveFrom.DropDownClosed += new System.EventHandler(this.cmbMoveFrom_DropDownClosed);
            // 
            // panelMainContainer
            // 
            this.panelMainContainer.Controls.Add(this.splitContainer1);
            this.panelMainContainer.Location = new System.Drawing.Point(0, 78);
            this.panelMainContainer.Name = "panelMainContainer";
            this.panelMainContainer.Size = new System.Drawing.Size(676, 585);
            this.panelMainContainer.TabIndex = 14;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ddgProduct);
            this.splitContainer1.Panel1.Controls.Add(this.cmdCreateLinesFrom);
            this.splitContainer1.Panel1.Controls.Add(this.crvPrintPreview);
            this.splitContainer1.Panel1.Controls.Add(this.lblInStockQty);
            this.splitContainer1.Panel1.Controls.Add(this.txtRecordDetailDescription);
            this.splitContainer1.Panel1.Controls.Add(this.lblRecordDetailDescription);
            this.splitContainer1.Panel1.Controls.Add(this.cmdAddOrModifyRecordDetail);
            this.splitContainer1.Panel1.Controls.Add(this.lblProcut);
            this.splitContainer1.Panel1.Controls.Add(this.ntbQuantity);
            this.splitContainer1.Panel1.Controls.Add(this.lblUOM);
            this.splitContainer1.Panel1.Controls.Add(this.lblQuantity);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.ddgBpartner);
            this.splitContainer1.Panel1.Controls.Add(this.lblBpartner);
            this.splitContainer1.Panel1.Controls.Add(this.cmbOrganisation);
            this.splitContainer1.Panel1.Controls.Add(this.lblOrganisation);
            this.splitContainer1.Panel1.Controls.Add(this.dtgMoveSummary);
            this.splitContainer1.Panel1.Controls.Add(this.txtDescriptionOrComment);
            this.splitContainer1.Panel1.Controls.Add(this.lblDescriptionOrComment);
            this.splitContainer1.Panel1.Controls.Add(this.lblDocumentNumber);
            this.splitContainer1.Panel1.Controls.Add(this.lblDocumentType);
            this.splitContainer1.Panel1.Controls.Add(this.cmbMoveFrom);
            this.splitContainer1.Panel1.Controls.Add(this.lblMovementDate);
            this.splitContainer1.Panel1.Controls.Add(this.dtpMoveDate);
            this.splitContainer1.Panel1.Controls.Add(this.lblWareHouse);
            this.splitContainer1.Panel1.Controls.Add(this.cmbDocumentType);
            this.splitContainer1.Panel1.Controls.Add(this.txtDocumentNumber);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dtgMoveLine);
            this.splitContainer1.Size = new System.Drawing.Size(676, 585);
            this.splitContainer1.SplitterDistance = 377;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // ddgProduct
            // 
            this.ddgProduct.AutoFilter = true;
            this.ddgProduct.AutoSize = true;
            this.ddgProduct.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgProduct.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ddgProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgProduct.ClearButtonEnabled = true;
            this.ddgProduct.DataTablePrimaryKey = ((ushort)(0));
            this.ddgProduct.Enabled = false;
            this.ddgProduct.FindButtonEnabled = true;
            this.ddgProduct.HiddenColoumns = new int[0];
            this.ddgProduct.Image = null;
            this.ddgProduct.Location = new System.Drawing.Point(122, 229);
            this.ddgProduct.Margin = new System.Windows.Forms.Padding(0);
            this.ddgProduct.Name = "ddgProduct";
            this.ddgProduct.NewButtonEnabled = true;
            this.ddgProduct.RefreshButtonEnabled = true;
            this.ddgProduct.SelectedColomnIdex = 0;
            this.ddgProduct.SelectedItem = "";
            this.ddgProduct.SelectedRowKey = null;
            this.ddgProduct.ShowGridFunctions = false;
            this.ddgProduct.Size = new System.Drawing.Size(447, 31);
            this.ddgProduct.TabIndex = 63;
            this.ddgProduct.SelectedItemClicked += new System.EventHandler(this.ddgProduct_SelectedItemClicked);
            this.ddgProduct.selectedItemChanged += new System.EventHandler(this.ddgProduct_selectedItemChanged);
            // 
            // cmdCreateLinesFrom
            // 
            this.cmdCreateLinesFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCreateLinesFrom.Location = new System.Drawing.Point(525, 81);
            this.cmdCreateLinesFrom.Name = "cmdCreateLinesFrom";
            this.cmdCreateLinesFrom.Size = new System.Drawing.Size(123, 80);
            this.cmdCreateLinesFrom.TabIndex = 62;
            this.cmdCreateLinesFrom.Text = "Create Lines From";
            this.cmdCreateLinesFrom.UseVisualStyleBackColor = true;
            this.cmdCreateLinesFrom.Click += new System.EventHandler(this.cmdCreateLinesFrom_Click);
            // 
            // crvPrintPreview
            // 
            this.crvPrintPreview.ActiveViewIndex = 0;
            this.crvPrintPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvPrintPreview.DisplayGroupTree = false;
            this.crvPrintPreview.DisplayStatusBar = false;
            this.crvPrintPreview.EnableDrillDown = false;
            this.crvPrintPreview.Location = new System.Drawing.Point(3, 89);
            this.crvPrintPreview.Name = "crvPrintPreview";
            this.crvPrintPreview.ReportSource = this.crptMaterialMovement;
            this.crvPrintPreview.ShowCloseButton = false;
            this.crvPrintPreview.ShowExportButton = false;
            this.crvPrintPreview.ShowGotoPageButton = false;
            this.crvPrintPreview.ShowGroupTreeButton = false;
            this.crvPrintPreview.ShowPrintButton = false;
            this.crvPrintPreview.ShowRefreshButton = false;
            this.crvPrintPreview.ShowTextSearchButton = false;
            this.crvPrintPreview.Size = new System.Drawing.Size(670, 54);
            this.crvPrintPreview.TabIndex = 17;
            this.crvPrintPreview.TabStop = false;
            this.crvPrintPreview.Visible = false;
            // 
            // lblInStockQty
            // 
            this.lblInStockQty.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblInStockQty.Location = new System.Drawing.Point(422, 277);
            this.lblInStockQty.Name = "lblInStockQty";
            this.lblInStockQty.Size = new System.Drawing.Size(105, 19);
            this.lblInStockQty.TabIndex = 61;
            this.lblInStockQty.Text = "0";
            this.lblInStockQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRecordDetailDescription
            // 
            this.txtRecordDetailDescription.Location = new System.Drawing.Point(125, 297);
            this.txtRecordDetailDescription.Multiline = true;
            this.txtRecordDetailDescription.Name = "txtRecordDetailDescription";
            this.txtRecordDetailDescription.Size = new System.Drawing.Size(278, 74);
            this.txtRecordDetailDescription.TabIndex = 55;
            // 
            // lblRecordDetailDescription
            // 
            this.lblRecordDetailDescription.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblRecordDetailDescription.Location = new System.Drawing.Point(55, 304);
            this.lblRecordDetailDescription.Name = "lblRecordDetailDescription";
            this.lblRecordDetailDescription.Size = new System.Drawing.Size(64, 62);
            this.lblRecordDetailDescription.TabIndex = 18;
            this.lblRecordDetailDescription.Text = "Description/Comment";
            this.lblRecordDetailDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdAddOrModifyRecordDetail
            // 
            this.cmdAddOrModifyRecordDetail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdAddOrModifyRecordDetail.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cmdAddOrModifyRecordDetail.Location = new System.Drawing.Point(436, 318);
            this.cmdAddOrModifyRecordDetail.Name = "cmdAddOrModifyRecordDetail";
            this.cmdAddOrModifyRecordDetail.Size = new System.Drawing.Size(94, 32);
            this.cmdAddOrModifyRecordDetail.TabIndex = 60;
            this.cmdAddOrModifyRecordDetail.Text = "ADD";
            this.cmdAddOrModifyRecordDetail.UseVisualStyleBackColor = false;
            this.cmdAddOrModifyRecordDetail.Click += new System.EventHandler(this.cmdAddOrModifyRecordDetail_Click);
            // 
            // ntbQuantity
            // 
            this.ntbQuantity.Align = System.Windows.Forms.HorizontalAlignment.Left;
            this.ntbQuantity.AllowedLength = 0;
            this.ntbQuantity.AllowLeadingZeros = false;
            this.ntbQuantity.AllowNegative = false;
            this.ntbQuantity.Amount = "0";
            this.ntbQuantity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ntbQuantity.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ntbQuantity.defaultAmount = "0";
            this.ntbQuantity.Location = new System.Drawing.Point(125, 265);
            this.ntbQuantity.Name = "ntbQuantity";
            this.ntbQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ntbQuantity.ShowThousandSeparetor = true;
            this.ntbQuantity.Size = new System.Drawing.Size(172, 23);
            this.ntbQuantity.StandardPrecision = 2;
            this.ntbQuantity.TabIndex = 50;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Enabled = false;
            this.label10.Location = new System.Drawing.Point(46, 223);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(551, 150);
            this.label10.TabIndex = 15;
            // 
            // ddgBpartner
            // 
            this.ddgBpartner.AutoFilter = true;
            this.ddgBpartner.AutoSize = true;
            this.ddgBpartner.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ddgBpartner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ddgBpartner.ClearButtonEnabled = true;
            this.ddgBpartner.DataTablePrimaryKey = ((ushort)(0));
            this.ddgBpartner.FindButtonEnabled = true;
            this.ddgBpartner.HiddenColoumns = new int[0];
            this.ddgBpartner.Image = null;
            this.ddgBpartner.Location = new System.Drawing.Point(105, 81);
            this.ddgBpartner.Margin = new System.Windows.Forms.Padding(0);
            this.ddgBpartner.Name = "ddgBpartner";
            this.ddgBpartner.NewButtonEnabled = true;
            this.ddgBpartner.RefreshButtonEnabled = true;
            this.ddgBpartner.SelectedColomnIdex = 0;
            this.ddgBpartner.SelectedItem = "";
            this.ddgBpartner.SelectedRowKey = null;
            this.ddgBpartner.ShowGridFunctions = false;
            this.ddgBpartner.Size = new System.Drawing.Size(396, 31);
            this.ddgBpartner.TabIndex = 10;
            this.ddgBpartner.SelectedItemClicked += new System.EventHandler(this.ddgBpartner_SelectedItemClicked);
            this.ddgBpartner.selectedItemChanged += new System.EventHandler(this.ddgBpartner_selectedItemChanged);
            // 
            // lblBpartner
            // 
            this.lblBpartner.Location = new System.Drawing.Point(9, 85);
            this.lblBpartner.Name = "lblBpartner";
            this.lblBpartner.Size = new System.Drawing.Size(95, 20);
            this.lblBpartner.TabIndex = 21;
            this.lblBpartner.Text = "Vendor";
            this.lblBpartner.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbOrganisation
            // 
            this.cmbOrganisation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrganisation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOrganisation.FormattingEnabled = true;
            this.cmbOrganisation.Location = new System.Drawing.Point(109, 7);
            this.cmbOrganisation.Name = "cmbOrganisation";
            this.cmbOrganisation.Size = new System.Drawing.Size(202, 21);
            this.cmbOrganisation.TabIndex = 5;
            this.cmbOrganisation.SelectedIndexChanged += new System.EventHandler(this.cmbOrganisation_SelectedIndexChanged);
            this.cmbOrganisation.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbOrganisation_KeyUp);
            this.cmbOrganisation.DropDownClosed += new System.EventHandler(this.cmbOrganisation_DropDownClosed);
            // 
            // lblOrganisation
            // 
            this.lblOrganisation.Location = new System.Drawing.Point(9, 8);
            this.lblOrganisation.Name = "lblOrganisation";
            this.lblOrganisation.Size = new System.Drawing.Size(95, 20);
            this.lblOrganisation.TabIndex = 19;
            this.lblOrganisation.Text = "Organisation";
            this.lblOrganisation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtgMoveSummary
            // 
            this.dtgMoveSummary.AllowUserToAddRows = false;
            this.dtgMoveSummary.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dtgMoveSummary.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgMoveSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgMoveSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgMoveSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMoveSummary.Location = new System.Drawing.Point(0, 5);
            this.dtgMoveSummary.MultiSelect = false;
            this.dtgMoveSummary.Name = "dtgMoveSummary";
            this.dtgMoveSummary.ReadOnly = true;
            this.dtgMoveSummary.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgMoveSummary.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgMoveSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMoveSummary.Size = new System.Drawing.Size(673, 10);
            this.dtgMoveSummary.TabIndex = 18;
            this.dtgMoveSummary.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMoveSummary_UserClickeCell);
            // 
            // txtDescriptionOrComment
            // 
            this.txtDescriptionOrComment.Location = new System.Drawing.Point(110, 146);
            this.txtDescriptionOrComment.Multiline = true;
            this.txtDescriptionOrComment.Name = "txtDescriptionOrComment";
            this.txtDescriptionOrComment.Size = new System.Drawing.Size(409, 72);
            this.txtDescriptionOrComment.TabIndex = 40;
            // 
            // lblDescriptionOrComment
            // 
            this.lblDescriptionOrComment.Location = new System.Drawing.Point(33, 146);
            this.lblDescriptionOrComment.Name = "lblDescriptionOrComment";
            this.lblDescriptionOrComment.Size = new System.Drawing.Size(71, 61);
            this.lblDescriptionOrComment.TabIndex = 16;
            this.lblDescriptionOrComment.Text = "Description/Comment";
            this.lblDescriptionOrComment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtgMoveLine
            // 
            this.dtgMoveLine.AllowUserToAddRows = false;
            this.dtgMoveLine.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dtgMoveLine.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgMoveLine.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgMoveLine.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Schoolbook", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgMoveLine.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgMoveLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgMoveLine.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtgMoveLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgMoveLine.GridColor = System.Drawing.SystemColors.ControlText;
            this.dtgMoveLine.Location = new System.Drawing.Point(0, 0);
            this.dtgMoveLine.Margin = new System.Windows.Forms.Padding(0);
            this.dtgMoveLine.MultiSelect = false;
            this.dtgMoveLine.Name = "dtgMoveLine";
            this.dtgMoveLine.ReadOnly = true;
            this.dtgMoveLine.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgMoveLine.RowHeadersVisible = false;
            this.dtgMoveLine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMoveLine.Size = new System.Drawing.Size(676, 207);
            this.dtgMoveLine.TabIndex = 3;
            this.dtgMoveLine.TabStop = false;
            this.dtgMoveLine.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMoveLine_UserClickedCellContent);
            // 
            // ssMainStatusBar
            // 
            this.ssMainStatusBar.GripMargin = new System.Windows.Forms.Padding(0);
            this.ssMainStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbStatusLabel});
            this.ssMainStatusBar.Location = new System.Drawing.Point(0, 666);
            this.ssMainStatusBar.Name = "ssMainStatusBar";
            this.ssMainStatusBar.Size = new System.Drawing.Size(676, 22);
            this.ssMainStatusBar.SizingGrip = false;
            this.ssMainStatusBar.TabIndex = 16;
            // 
            // sbStatusLabel
            // 
            this.sbStatusLabel.Name = "sbStatusLabel";
            this.sbStatusLabel.Size = new System.Drawing.Size(0, 17);
            this.sbStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // prtPrintDocument
            // 
            this.prtPrintDocument.OriginAtMargins = true;
            // 
            // prtShowPrintDialogue
            // 
            this.prtShowPrintDialogue.UseEXDialog = true;
            // 
            // tmrCloseWindow
            // 
            this.tmrCloseWindow.Enabled = true;
            this.tmrCloseWindow.Interval = 600000;
            this.tmrCloseWindow.Tick += new System.EventHandler(this.tmrCloseWindow_Tick);
            // 
            // frmInventoryIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 688);
            this.Controls.Add(this.ssMainStatusBar);
            this.Controls.Add(this.panelMainContainer);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.mnuMainMenu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMainMenu;
            this.MaximizeBox = false;
            this.Name = "frmInventoryIn";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory In";
            this.Load += new System.EventHandler(this.frmInventoryIn_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInventoryIn_FormClosing);
            this.mnuMainMenu.ResumeLayout(false);
            this.mnuMainMenu.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.panelMainContainer.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMoveSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMoveLine)).EndInit();
            this.ssMainStatusBar.ResumeLayout(false);
            this.ssMainStatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMainMenu;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.Label lblDocumentNumber;
        private System.Windows.Forms.Label lblUOM;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblProcut;
        private System.Windows.Forms.Label lblDocumentType;
        private System.Windows.Forms.Label lblMovementDate;
        private System.Windows.Forms.Label lblWareHouse;
        private System.Windows.Forms.TextBox txtDocumentNumber;
        private System.Windows.Forms.ComboBox cmbDocumentType;
        private System.Windows.Forms.DateTimePicker dtpMoveDate;
        private System.Windows.Forms.ComboBox cmbMoveFrom;
        private System.Windows.Forms.Panel panelMainContainer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ctlNumberTextBox ntbQuantity;
        private System.Windows.Forms.Label lblDescriptionOrComment;
        private System.Windows.Forms.TextBox txtDescriptionOrComment;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dtgMoveLine;
        private System.Windows.Forms.StatusStrip ssMainStatusBar;
        private System.Windows.Forms.Button cmdAddOrModifyRecordDetail;
        private System.Windows.Forms.DataGridView dtgMoveSummary;
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
        private System.Windows.Forms.ComboBox cmbOrganisation;
        private System.Windows.Forms.Label lblOrganisation;
        private System.Windows.Forms.ToolStripButton tscmdConfirm;
        private System.Windows.Forms.ToolStripButton tscmdReject;
        private System.Windows.Forms.ToolStripButton tscmdExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private DropDownDataGrid ddgBpartner;
        private System.Windows.Forms.Label lblBpartner;
        private System.Windows.Forms.Label lblRecordDetailDescription;
        private System.Windows.Forms.TextBox txtRecordDetailDescription;
        private System.Windows.Forms.ToolStripStatusLabel sbStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem mnuTaskMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuNewTask;
        private System.Windows.Forms.ToolStripMenuItem mnuNewMovement;
        private System.Windows.Forms.ToolStripMenuItem mnuNewRequest;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveReocord;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteReocrd;
        private System.Windows.Forms.ToolStripMenuItem mnuConfirmReocrd;
        private System.Windows.Forms.ToolStripMenuItem mnuRejectRecord;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuViewMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuSearchRecord;
        private System.Windows.Forms.ToolStripMenuItem mnuToggleView;
        private System.Windows.Forms.ToolStripMenuItem mnuGoTo;
        private System.Windows.Forms.ToolStripMenuItem mnuFirstRecord;
        private System.Windows.Forms.ToolStripMenuItem mnuPreviousRecord;
        private System.Windows.Forms.ToolStripMenuItem mnuNextRecord;
        private System.Windows.Forms.ToolStripMenuItem mnuLastRecord;
        private System.Windows.Forms.ToolStripMenuItem mnuSettingsMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuDataBaseConnection;
        private System.Windows.Forms.ToolStripMenuItem mnuStationAccess;
        private System.Windows.Forms.ToolStripMenuItem mnuProcessAccess;
        private System.ComponentModel.BackgroundWorker updateRecordStatusToLatestStatus;
        private System.Windows.Forms.ToolStripButton tscmdPrintDocument;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPrintPreview;
        private System.Drawing.Printing.PrintDocument prtPrintDocument;
        private System.Windows.Forms.ToolStripButton tscmdShowPrintPreview;
        private System.Windows.Forms.PrintDialog prtShowPrintDialogue;
        private crptMaterialMovement crptMaterialMovement;
        private System.Windows.Forms.ToolStripMenuItem mnuWarehouseAccess;
        private System.Windows.Forms.ToolStripButton tscmdViewStock;
        private System.Windows.Forms.Label lblInStockQty;
        private System.Windows.Forms.Button cmdCreateLinesFrom;
        private DropDownDataGrid ddgProduct;
        private System.Windows.Forms.Timer tmrCloseWindow;
    }
}

