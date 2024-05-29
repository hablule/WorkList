namespace POSDataBridge
{
    partial class frmPosCompiereBridge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPosCompiereBridge));
            this.mnuMainMenu = new System.Windows.Forms.MenuStrip();
            this.mnutask = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStartSynch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStartPOSToCompiere = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStartCompiereToPOS = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStartBoth = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStopSynch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStopPOSToCompiere = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStopCompiereToPOS = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStopBoth = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCleanChangeSequece = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCleanPOSSequence = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCleanCompiereSequence = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.bkwCompiereToPOSDataMapController = new System.ComponentModel.BackgroundWorker();
            this.bkwPOSToCompiereDataMapController = new System.ComponentModel.BackgroundWorker();
            this.tmrCompToPOSTimeSyncTimeController = new System.Windows.Forms.Timer(this.components);
            this.tmrPOSTOCompTimeSyncTimeController = new System.Windows.Forms.Timer(this.components);
            this.cmnTaskBarkContexMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuOpenControl = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuStartSynch = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuStartPOStoCompiere = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuStartCompiereToPOS = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuStartBoth = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuStopSynch = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuStopPOStoCompiere = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuStopCompiereToPOS = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuStopBoth = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblUpdatedCash = new System.Windows.Forms.Label();
            this.lblUpdatedCashLine = new System.Windows.Forms.Label();
            this.lblDeletedCash = new System.Windows.Forms.Label();
            this.lblDeletedCashLine = new System.Windows.Forms.Label();
            this.lblErrorOnCash = new System.Windows.Forms.Label();
            this.lblErrorOnCashLine = new System.Windows.Forms.Label();
            this.lblWarnningOnCash = new System.Windows.Forms.Label();
            this.lblWarnningOnCashLine = new System.Windows.Forms.Label();
            this.lblScriptsOnCash = new System.Windows.Forms.Label();
            this.lblScriptsOnCashLine = new System.Windows.Forms.Label();
            this.lblInsertedCashLine = new System.Windows.Forms.Label();
            this.lblInsertedCash = new System.Windows.Forms.Label();
            this.lblCashLine = new System.Windows.Forms.Label();
            this.lblCash = new System.Windows.Forms.Label();
            this.lblUpdatedAllocations = new System.Windows.Forms.Label();
            this.lblUpdatedAllocationLines = new System.Windows.Forms.Label();
            this.lblDeletedAllocations = new System.Windows.Forms.Label();
            this.lblDeletedAllocationLines = new System.Windows.Forms.Label();
            this.lblErrorOnAllocations = new System.Windows.Forms.Label();
            this.lblErrorOnAllocationLines = new System.Windows.Forms.Label();
            this.lblWarnningOnAllocations = new System.Windows.Forms.Label();
            this.lblWarnningOnAllocationLines = new System.Windows.Forms.Label();
            this.lblScriptsOnAllocations = new System.Windows.Forms.Label();
            this.lblScriptsOnAllocationLines = new System.Windows.Forms.Label();
            this.lblInsertedAllocationLines = new System.Windows.Forms.Label();
            this.lblInsertedAllocations = new System.Windows.Forms.Label();
            this.lblScriptsOnPaymentLines = new System.Windows.Forms.Label();
            this.lblWarnningOnPaymentLines = new System.Windows.Forms.Label();
            this.lblErrorOnPaymentLines = new System.Windows.Forms.Label();
            this.lblDeletedPaymentLines = new System.Windows.Forms.Label();
            this.lblUpdatedPaymentLines = new System.Windows.Forms.Label();
            this.lblInsertedPaymentLines = new System.Windows.Forms.Label();
            this.lblAllocationLine = new System.Windows.Forms.Label();
            this.lblAllocation = new System.Windows.Forms.Label();
            this.lblPaymentlines = new System.Windows.Forms.Label();
            this.lblUpdatedExemptionsLine = new System.Windows.Forms.Label();
            this.lblUpdatedPayments = new System.Windows.Forms.Label();
            this.lblDeletedExemptionsLine = new System.Windows.Forms.Label();
            this.lblDeletedPayments = new System.Windows.Forms.Label();
            this.lblErrorOnExemptionLine = new System.Windows.Forms.Label();
            this.lblErrorOnPayments = new System.Windows.Forms.Label();
            this.lblWarnningOnExemptionsLine = new System.Windows.Forms.Label();
            this.lblWarnningOnPayments = new System.Windows.Forms.Label();
            this.lblScriptsOnExemptionsLine = new System.Windows.Forms.Label();
            this.lblScriptsOnPayments = new System.Windows.Forms.Label();
            this.lblInsertedPayments = new System.Windows.Forms.Label();
            this.lblInsertedExemptionLine = new System.Windows.Forms.Label();
            this.lblScriptsOnExemptions = new System.Windows.Forms.Label();
            this.lblWarnningOnExemptions = new System.Windows.Forms.Label();
            this.lblErrorOnExemptions = new System.Windows.Forms.Label();
            this.lblDeletedExemptions = new System.Windows.Forms.Label();
            this.lblUpdatedExemptions = new System.Windows.Forms.Label();
            this.lblInsertedExemptions = new System.Windows.Forms.Label();
            this.lblPayment = new System.Windows.Forms.Label();
            this.lblExemptionLine = new System.Windows.Forms.Label();
            this.lblExemptions = new System.Windows.Forms.Label();
            this.lblCompierePOSStartTime = new System.Windows.Forms.Label();
            this.lblCompierePOSStatus = new System.Windows.Forms.Label();
            this.lblPosCompiereStartTime = new System.Windows.Forms.Label();
            this.lblUpdatedOrders = new System.Windows.Forms.Label();
            this.lblUpdatedOrderLines = new System.Windows.Forms.Label();
            this.lblDeletedOrders = new System.Windows.Forms.Label();
            this.lblDeletedOrderLines = new System.Windows.Forms.Label();
            this.lblErrorOnOrders = new System.Windows.Forms.Label();
            this.lblErrorOnOrderLines = new System.Windows.Forms.Label();
            this.lblWarnningOnOrders = new System.Windows.Forms.Label();
            this.lblWarnningOnOrderLines = new System.Windows.Forms.Label();
            this.lblScriptsOnOrders = new System.Windows.Forms.Label();
            this.lblScriptsOnOrderLines = new System.Windows.Forms.Label();
            this.lblUpdatedOrganisation = new System.Windows.Forms.Label();
            this.lblDeletedOrganisation = new System.Windows.Forms.Label();
            this.lblErrorOnOrganisation = new System.Windows.Forms.Label();
            this.lblWarnningOnOrganisation = new System.Windows.Forms.Label();
            this.lblScriptsOnOrganisation = new System.Windows.Forms.Label();
            this.lblUpdatedLocators = new System.Windows.Forms.Label();
            this.lblDeletedLocators = new System.Windows.Forms.Label();
            this.lblErrorOnLocators = new System.Windows.Forms.Label();
            this.lblWarnningOnLocators = new System.Windows.Forms.Label();
            this.lblScriptsOnLocators = new System.Windows.Forms.Label();
            this.lblUpdatedCategory = new System.Windows.Forms.Label();
            this.lblDeletedCategories = new System.Windows.Forms.Label();
            this.lblErrorOnCategories = new System.Windows.Forms.Label();
            this.lblWarnningOnCategories = new System.Windows.Forms.Label();
            this.lblScriptsOnCategories = new System.Windows.Forms.Label();
            this.lblUpdatedUOM = new System.Windows.Forms.Label();
            this.lblDeletedUOM = new System.Windows.Forms.Label();
            this.lblErrorOnUOM = new System.Windows.Forms.Label();
            this.lblWarnningOnUOM = new System.Windows.Forms.Label();
            this.lblScriptsOnUOM = new System.Windows.Forms.Label();
            this.lblUpdatedItems = new System.Windows.Forms.Label();
            this.lblDeletedItems = new System.Windows.Forms.Label();
            this.lblErrorOnItems = new System.Windows.Forms.Label();
            this.lblWarnningOnItems = new System.Windows.Forms.Label();
            this.lblScriptsOnItems = new System.Windows.Forms.Label();
            this.lblUpdatedPriceListVersion = new System.Windows.Forms.Label();
            this.lblDeletedPriceListVersion = new System.Windows.Forms.Label();
            this.lblErrorOnPriceListVersion = new System.Windows.Forms.Label();
            this.lblWarnningOnPriceListVersion = new System.Windows.Forms.Label();
            this.lblScriptsOnPriceListVersion = new System.Windows.Forms.Label();
            this.lblUpdatedProductPrice = new System.Windows.Forms.Label();
            this.lblDeletedProductPrice = new System.Windows.Forms.Label();
            this.lblErrorOnProductPrice = new System.Windows.Forms.Label();
            this.lblWarnningOnProductPrice = new System.Windows.Forms.Label();
            this.lblScriptsOnProductPrice = new System.Windows.Forms.Label();
            this.lblInsertedProductPrice = new System.Windows.Forms.Label();
            this.lblPosCompiereStatus = new System.Windows.Forms.Label();
            this.lblInsertedPriceListVersion = new System.Windows.Forms.Label();
            this.lblInsertedItems = new System.Windows.Forms.Label();
            this.lblInsertedUOM = new System.Windows.Forms.Label();
            this.lblInsertedCategories = new System.Windows.Forms.Label();
            this.lblInsertedLocators = new System.Windows.Forms.Label();
            this.lblInsertedOrganistion = new System.Windows.Forms.Label();
            this.lblInsertedOrderLines = new System.Windows.Forms.Label();
            this.lblInsertedOrders = new System.Windows.Forms.Label();
            this.lblScriptsOnCustomers = new System.Windows.Forms.Label();
            this.lblWarnningOnCustomers = new System.Windows.Forms.Label();
            this.lblErrorOnCustomers = new System.Windows.Forms.Label();
            this.lblDeletedCustomers = new System.Windows.Forms.Label();
            this.lblUpdatedCustomers = new System.Windows.Forms.Label();
            this.lblInsertedCustomers = new System.Windows.Forms.Label();
            this.lblProductPrice = new System.Windows.Forms.Label();
            this.lblPriceVersion = new System.Windows.Forms.Label();
            this.lblItems = new System.Windows.Forms.Label();
            this.lblUOM = new System.Windows.Forms.Label();
            this.lblCategories = new System.Windows.Forms.Label();
            this.lblLocators = new System.Windows.Forms.Label();
            this.lblOrganisation = new System.Windows.Forms.Label();
            this.lblCompiereToPOS = new System.Windows.Forms.Label();
            this.lblOrderLines = new System.Windows.Forms.Label();
            this.lblOrders = new System.Windows.Forms.Label();
            this.lblCustomers = new System.Windows.Forms.Label();
            this.lblPOSToCompiere = new System.Windows.Forms.Label();
            this.lblScript = new System.Windows.Forms.Label();
            this.lblWarnning = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.lblDelete = new System.Windows.Forms.Label();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.lblInsert = new System.Windows.Forms.Label();
            this.ntiTaskBarIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mnuMainMenu.SuspendLayout();
            this.cmnTaskBarkContexMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMainMenu
            // 
            this.mnuMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnutask});
            this.mnuMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMainMenu.Name = "mnuMainMenu";
            this.mnuMainMenu.Size = new System.Drawing.Size(610, 24);
            this.mnuMainMenu.TabIndex = 1;
            this.mnuMainMenu.Text = "menuStrip1";
            // 
            // mnutask
            // 
            this.mnutask.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSettings,
            this.mnuStartSynch,
            this.mnuStopSynch,
            this.mnuCleanChangeSequece,
            this.mnuExit});
            this.mnutask.Name = "mnutask";
            this.mnutask.Size = new System.Drawing.Size(41, 20);
            this.mnutask.Text = "Task";
            // 
            // mnuSettings
            // 
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(202, 22);
            this.mnuSettings.Text = "&Settings...";
            this.mnuSettings.Click += new System.EventHandler(this.mnuSettings_Click);
            // 
            // mnuStartSynch
            // 
            this.mnuStartSynch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStartPOSToCompiere,
            this.mnuStartCompiereToPOS,
            this.mnuStartBoth});
            this.mnuStartSynch.Name = "mnuStartSynch";
            this.mnuStartSynch.Size = new System.Drawing.Size(202, 22);
            this.mnuStartSynch.Text = "Start Synch";
            // 
            // mnuStartPOSToCompiere
            // 
            this.mnuStartPOSToCompiere.Name = "mnuStartPOSToCompiere";
            this.mnuStartPOSToCompiere.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.mnuStartPOSToCompiere.Size = new System.Drawing.Size(207, 22);
            this.mnuStartPOSToCompiere.Text = "POS to Compiere";
            this.mnuStartPOSToCompiere.Click += new System.EventHandler(this.mnuStartPOSToCompiere_Click);
            // 
            // mnuStartCompiereToPOS
            // 
            this.mnuStartCompiereToPOS.Name = "mnuStartCompiereToPOS";
            this.mnuStartCompiereToPOS.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuStartCompiereToPOS.Size = new System.Drawing.Size(207, 22);
            this.mnuStartCompiereToPOS.Text = "Compiere to POS";
            this.mnuStartCompiereToPOS.Click += new System.EventHandler(this.mnuStartCompiereToPOS_Click);
            // 
            // mnuStartBoth
            // 
            this.mnuStartBoth.Name = "mnuStartBoth";
            this.mnuStartBoth.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.mnuStartBoth.Size = new System.Drawing.Size(207, 22);
            this.mnuStartBoth.Text = "Both";
            this.mnuStartBoth.Click += new System.EventHandler(this.mnuStartBoth_Click);
            // 
            // mnuStopSynch
            // 
            this.mnuStopSynch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStopPOSToCompiere,
            this.mnuStopCompiereToPOS,
            this.mnuStopBoth});
            this.mnuStopSynch.Name = "mnuStopSynch";
            this.mnuStopSynch.Size = new System.Drawing.Size(202, 22);
            this.mnuStopSynch.Text = "Stop Synch";
            // 
            // mnuStopPOSToCompiere
            // 
            this.mnuStopPOSToCompiere.Name = "mnuStopPOSToCompiere";
            this.mnuStopPOSToCompiere.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.mnuStopPOSToCompiere.Size = new System.Drawing.Size(203, 22);
            this.mnuStopPOSToCompiere.Text = "POS to Compiere";
            this.mnuStopPOSToCompiere.Click += new System.EventHandler(this.mnuStopPOSToCompiere_Click);
            // 
            // mnuStopCompiereToPOS
            // 
            this.mnuStopCompiereToPOS.Name = "mnuStopCompiereToPOS";
            this.mnuStopCompiereToPOS.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.mnuStopCompiereToPOS.Size = new System.Drawing.Size(203, 22);
            this.mnuStopCompiereToPOS.Text = "Compiere to POS";
            this.mnuStopCompiereToPOS.Click += new System.EventHandler(this.mnuStopCompiereToPOS_Click);
            // 
            // mnuStopBoth
            // 
            this.mnuStopBoth.Name = "mnuStopBoth";
            this.mnuStopBoth.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.B)));
            this.mnuStopBoth.Size = new System.Drawing.Size(203, 22);
            this.mnuStopBoth.Text = "Both";
            this.mnuStopBoth.Click += new System.EventHandler(this.mnuStopBoth_Click);
            // 
            // mnuCleanChangeSequece
            // 
            this.mnuCleanChangeSequece.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCleanPOSSequence,
            this.mnuCleanCompiereSequence});
            this.mnuCleanChangeSequece.Name = "mnuCleanChangeSequece";
            this.mnuCleanChangeSequece.Size = new System.Drawing.Size(202, 22);
            this.mnuCleanChangeSequece.Text = "Clean Change Sequence";
            // 
            // mnuCleanPOSSequence
            // 
            this.mnuCleanPOSSequence.Name = "mnuCleanPOSSequence";
            this.mnuCleanPOSSequence.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.mnuCleanPOSSequence.Size = new System.Drawing.Size(226, 22);
            this.mnuCleanPOSSequence.Text = "POS sequence";
            this.mnuCleanPOSSequence.Click += new System.EventHandler(this.mnuCleanPOSSequence_Click);
            // 
            // mnuCleanCompiereSequence
            // 
            this.mnuCleanCompiereSequence.Name = "mnuCleanCompiereSequence";
            this.mnuCleanCompiereSequence.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Delete)));
            this.mnuCleanCompiereSequence.Size = new System.Drawing.Size(226, 22);
            this.mnuCleanCompiereSequence.Text = "Compiere sequence";
            this.mnuCleanCompiereSequence.Click += new System.EventHandler(this.mnuCleanCompiereSequence_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(202, 22);
            this.mnuExit.Text = "&Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // bkwCompiereToPOSDataMapController
            // 
            this.bkwCompiereToPOSDataMapController.WorkerReportsProgress = true;
            this.bkwCompiereToPOSDataMapController.WorkerSupportsCancellation = true;
            this.bkwCompiereToPOSDataMapController.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkwCompiereToPOSDataMapController_DoWork);
            this.bkwCompiereToPOSDataMapController.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bkwCompiereToPOSDataMapController_RunWorkerCompleted);
            this.bkwCompiereToPOSDataMapController.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bkwCompiereToPOSDataMapController_ProgressChanged);
            // 
            // bkwPOSToCompiereDataMapController
            // 
            this.bkwPOSToCompiereDataMapController.WorkerReportsProgress = true;
            this.bkwPOSToCompiereDataMapController.WorkerSupportsCancellation = true;
            this.bkwPOSToCompiereDataMapController.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkwPOSToCompiereDataMapController_DoWork);
            this.bkwPOSToCompiereDataMapController.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bkwPOSToCompiereDataMapController_RunWorkerCompleted);
            this.bkwPOSToCompiereDataMapController.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bkwPOSToCompiereDataMapController_ProgressChanged);
            // 
            // tmrCompToPOSTimeSyncTimeController
            // 
            this.tmrCompToPOSTimeSyncTimeController.Tick += new System.EventHandler(this.tmrCompToPOSTimeSyncTimeController_Tick);
            // 
            // tmrPOSTOCompTimeSyncTimeController
            // 
            this.tmrPOSTOCompTimeSyncTimeController.Tick += new System.EventHandler(this.tmrPOSTOCompTimeSyncTimeController_Tick);
            // 
            // cmnTaskBarkContexMenu
            // 
            this.cmnTaskBarkContexMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuOpenControl,
            this.cmnuStartSynch,
            this.cmnuStopSynch,
            this.cmnuExit});
            this.cmnTaskBarkContexMenu.Name = "contextMenuStrip1";
            this.cmnTaskBarkContexMenu.Size = new System.Drawing.Size(148, 92);
            // 
            // cmnuOpenControl
            // 
            this.cmnuOpenControl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmnuOpenControl.Name = "cmnuOpenControl";
            this.cmnuOpenControl.Size = new System.Drawing.Size(147, 22);
            this.cmnuOpenControl.Text = "&Open Control";
            this.cmnuOpenControl.Click += new System.EventHandler(this.cmnuOpenControl_Click);
            // 
            // cmnuStartSynch
            // 
            this.cmnuStartSynch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuStartPOStoCompiere,
            this.cmnuStartCompiereToPOS,
            this.cmnuStartBoth});
            this.cmnuStartSynch.Name = "cmnuStartSynch";
            this.cmnuStartSynch.Size = new System.Drawing.Size(147, 22);
            this.cmnuStartSynch.Text = "Start Synch";
            // 
            // cmnuStartPOStoCompiere
            // 
            this.cmnuStartPOStoCompiere.Name = "cmnuStartPOStoCompiere";
            this.cmnuStartPOStoCompiere.Size = new System.Drawing.Size(153, 22);
            this.cmnuStartPOStoCompiere.Text = "POS-Compiere";
            this.cmnuStartPOStoCompiere.Click += new System.EventHandler(this.cmnuStartPOStoCompiere_Click);
            // 
            // cmnuStartCompiereToPOS
            // 
            this.cmnuStartCompiereToPOS.Name = "cmnuStartCompiereToPOS";
            this.cmnuStartCompiereToPOS.Size = new System.Drawing.Size(153, 22);
            this.cmnuStartCompiereToPOS.Text = "Compiere-POS";
            this.cmnuStartCompiereToPOS.Click += new System.EventHandler(this.cmnuStartCompiereToPOS_Click);
            // 
            // cmnuStartBoth
            // 
            this.cmnuStartBoth.Name = "cmnuStartBoth";
            this.cmnuStartBoth.Size = new System.Drawing.Size(153, 22);
            this.cmnuStartBoth.Text = "Both";
            this.cmnuStartBoth.Click += new System.EventHandler(this.cmnuStartBoth_Click);
            // 
            // cmnuStopSynch
            // 
            this.cmnuStopSynch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuStopPOStoCompiere,
            this.cmnuStopCompiereToPOS,
            this.cmnuStopBoth});
            this.cmnuStopSynch.Name = "cmnuStopSynch";
            this.cmnuStopSynch.Size = new System.Drawing.Size(147, 22);
            this.cmnuStopSynch.Text = "Stop Synch";
            // 
            // cmnuStopPOStoCompiere
            // 
            this.cmnuStopPOStoCompiere.Name = "cmnuStopPOStoCompiere";
            this.cmnuStopPOStoCompiere.Size = new System.Drawing.Size(153, 22);
            this.cmnuStopPOStoCompiere.Text = "POS-Compiere";
            this.cmnuStopPOStoCompiere.Click += new System.EventHandler(this.cmnuStopPOStoCompiere_Click);
            // 
            // cmnuStopCompiereToPOS
            // 
            this.cmnuStopCompiereToPOS.Name = "cmnuStopCompiereToPOS";
            this.cmnuStopCompiereToPOS.Size = new System.Drawing.Size(153, 22);
            this.cmnuStopCompiereToPOS.Text = "Compiere-POS";
            this.cmnuStopCompiereToPOS.Click += new System.EventHandler(this.cmnuStopCompiereToPOS_Click);
            // 
            // cmnuStopBoth
            // 
            this.cmnuStopBoth.Name = "cmnuStopBoth";
            this.cmnuStopBoth.Size = new System.Drawing.Size(153, 22);
            this.cmnuStopBoth.Text = "Both";
            this.cmnuStopBoth.Click += new System.EventHandler(this.cmnuStopBoth_Click);
            // 
            // cmnuExit
            // 
            this.cmnuExit.Name = "cmnuExit";
            this.cmnuExit.Size = new System.Drawing.Size(147, 22);
            this.cmnuExit.Text = "Exit";
            this.cmnuExit.Click += new System.EventHandler(this.cmnuExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblUpdatedCash);
            this.groupBox1.Controls.Add(this.lblUpdatedCashLine);
            this.groupBox1.Controls.Add(this.lblDeletedCash);
            this.groupBox1.Controls.Add(this.lblDeletedCashLine);
            this.groupBox1.Controls.Add(this.lblErrorOnCash);
            this.groupBox1.Controls.Add(this.lblErrorOnCashLine);
            this.groupBox1.Controls.Add(this.lblWarnningOnCash);
            this.groupBox1.Controls.Add(this.lblWarnningOnCashLine);
            this.groupBox1.Controls.Add(this.lblScriptsOnCash);
            this.groupBox1.Controls.Add(this.lblScriptsOnCashLine);
            this.groupBox1.Controls.Add(this.lblInsertedCashLine);
            this.groupBox1.Controls.Add(this.lblInsertedCash);
            this.groupBox1.Controls.Add(this.lblCashLine);
            this.groupBox1.Controls.Add(this.lblCash);
            this.groupBox1.Controls.Add(this.lblUpdatedAllocations);
            this.groupBox1.Controls.Add(this.lblUpdatedAllocationLines);
            this.groupBox1.Controls.Add(this.lblDeletedAllocations);
            this.groupBox1.Controls.Add(this.lblDeletedAllocationLines);
            this.groupBox1.Controls.Add(this.lblErrorOnAllocations);
            this.groupBox1.Controls.Add(this.lblErrorOnAllocationLines);
            this.groupBox1.Controls.Add(this.lblWarnningOnAllocations);
            this.groupBox1.Controls.Add(this.lblWarnningOnAllocationLines);
            this.groupBox1.Controls.Add(this.lblScriptsOnAllocations);
            this.groupBox1.Controls.Add(this.lblScriptsOnAllocationLines);
            this.groupBox1.Controls.Add(this.lblInsertedAllocationLines);
            this.groupBox1.Controls.Add(this.lblInsertedAllocations);
            this.groupBox1.Controls.Add(this.lblScriptsOnPaymentLines);
            this.groupBox1.Controls.Add(this.lblWarnningOnPaymentLines);
            this.groupBox1.Controls.Add(this.lblErrorOnPaymentLines);
            this.groupBox1.Controls.Add(this.lblDeletedPaymentLines);
            this.groupBox1.Controls.Add(this.lblUpdatedPaymentLines);
            this.groupBox1.Controls.Add(this.lblInsertedPaymentLines);
            this.groupBox1.Controls.Add(this.lblAllocationLine);
            this.groupBox1.Controls.Add(this.lblAllocation);
            this.groupBox1.Controls.Add(this.lblPaymentlines);
            this.groupBox1.Controls.Add(this.lblUpdatedExemptionsLine);
            this.groupBox1.Controls.Add(this.lblUpdatedPayments);
            this.groupBox1.Controls.Add(this.lblDeletedExemptionsLine);
            this.groupBox1.Controls.Add(this.lblDeletedPayments);
            this.groupBox1.Controls.Add(this.lblErrorOnExemptionLine);
            this.groupBox1.Controls.Add(this.lblErrorOnPayments);
            this.groupBox1.Controls.Add(this.lblWarnningOnExemptionsLine);
            this.groupBox1.Controls.Add(this.lblWarnningOnPayments);
            this.groupBox1.Controls.Add(this.lblScriptsOnExemptionsLine);
            this.groupBox1.Controls.Add(this.lblScriptsOnPayments);
            this.groupBox1.Controls.Add(this.lblInsertedPayments);
            this.groupBox1.Controls.Add(this.lblInsertedExemptionLine);
            this.groupBox1.Controls.Add(this.lblScriptsOnExemptions);
            this.groupBox1.Controls.Add(this.lblWarnningOnExemptions);
            this.groupBox1.Controls.Add(this.lblErrorOnExemptions);
            this.groupBox1.Controls.Add(this.lblDeletedExemptions);
            this.groupBox1.Controls.Add(this.lblUpdatedExemptions);
            this.groupBox1.Controls.Add(this.lblInsertedExemptions);
            this.groupBox1.Controls.Add(this.lblPayment);
            this.groupBox1.Controls.Add(this.lblExemptionLine);
            this.groupBox1.Controls.Add(this.lblExemptions);
            this.groupBox1.Controls.Add(this.lblCompierePOSStartTime);
            this.groupBox1.Controls.Add(this.lblCompierePOSStatus);
            this.groupBox1.Controls.Add(this.lblPosCompiereStartTime);
            this.groupBox1.Controls.Add(this.lblUpdatedOrders);
            this.groupBox1.Controls.Add(this.lblUpdatedOrderLines);
            this.groupBox1.Controls.Add(this.lblDeletedOrders);
            this.groupBox1.Controls.Add(this.lblDeletedOrderLines);
            this.groupBox1.Controls.Add(this.lblErrorOnOrders);
            this.groupBox1.Controls.Add(this.lblErrorOnOrderLines);
            this.groupBox1.Controls.Add(this.lblWarnningOnOrders);
            this.groupBox1.Controls.Add(this.lblWarnningOnOrderLines);
            this.groupBox1.Controls.Add(this.lblScriptsOnOrders);
            this.groupBox1.Controls.Add(this.lblScriptsOnOrderLines);
            this.groupBox1.Controls.Add(this.lblUpdatedOrganisation);
            this.groupBox1.Controls.Add(this.lblDeletedOrganisation);
            this.groupBox1.Controls.Add(this.lblErrorOnOrganisation);
            this.groupBox1.Controls.Add(this.lblWarnningOnOrganisation);
            this.groupBox1.Controls.Add(this.lblScriptsOnOrganisation);
            this.groupBox1.Controls.Add(this.lblUpdatedLocators);
            this.groupBox1.Controls.Add(this.lblDeletedLocators);
            this.groupBox1.Controls.Add(this.lblErrorOnLocators);
            this.groupBox1.Controls.Add(this.lblWarnningOnLocators);
            this.groupBox1.Controls.Add(this.lblScriptsOnLocators);
            this.groupBox1.Controls.Add(this.lblUpdatedCategory);
            this.groupBox1.Controls.Add(this.lblDeletedCategories);
            this.groupBox1.Controls.Add(this.lblErrorOnCategories);
            this.groupBox1.Controls.Add(this.lblWarnningOnCategories);
            this.groupBox1.Controls.Add(this.lblScriptsOnCategories);
            this.groupBox1.Controls.Add(this.lblUpdatedUOM);
            this.groupBox1.Controls.Add(this.lblDeletedUOM);
            this.groupBox1.Controls.Add(this.lblErrorOnUOM);
            this.groupBox1.Controls.Add(this.lblWarnningOnUOM);
            this.groupBox1.Controls.Add(this.lblScriptsOnUOM);
            this.groupBox1.Controls.Add(this.lblUpdatedItems);
            this.groupBox1.Controls.Add(this.lblDeletedItems);
            this.groupBox1.Controls.Add(this.lblErrorOnItems);
            this.groupBox1.Controls.Add(this.lblWarnningOnItems);
            this.groupBox1.Controls.Add(this.lblScriptsOnItems);
            this.groupBox1.Controls.Add(this.lblUpdatedPriceListVersion);
            this.groupBox1.Controls.Add(this.lblDeletedPriceListVersion);
            this.groupBox1.Controls.Add(this.lblErrorOnPriceListVersion);
            this.groupBox1.Controls.Add(this.lblWarnningOnPriceListVersion);
            this.groupBox1.Controls.Add(this.lblScriptsOnPriceListVersion);
            this.groupBox1.Controls.Add(this.lblUpdatedProductPrice);
            this.groupBox1.Controls.Add(this.lblDeletedProductPrice);
            this.groupBox1.Controls.Add(this.lblErrorOnProductPrice);
            this.groupBox1.Controls.Add(this.lblWarnningOnProductPrice);
            this.groupBox1.Controls.Add(this.lblScriptsOnProductPrice);
            this.groupBox1.Controls.Add(this.lblInsertedProductPrice);
            this.groupBox1.Controls.Add(this.lblPosCompiereStatus);
            this.groupBox1.Controls.Add(this.lblInsertedPriceListVersion);
            this.groupBox1.Controls.Add(this.lblInsertedItems);
            this.groupBox1.Controls.Add(this.lblInsertedUOM);
            this.groupBox1.Controls.Add(this.lblInsertedCategories);
            this.groupBox1.Controls.Add(this.lblInsertedLocators);
            this.groupBox1.Controls.Add(this.lblInsertedOrganistion);
            this.groupBox1.Controls.Add(this.lblInsertedOrderLines);
            this.groupBox1.Controls.Add(this.lblInsertedOrders);
            this.groupBox1.Controls.Add(this.lblScriptsOnCustomers);
            this.groupBox1.Controls.Add(this.lblWarnningOnCustomers);
            this.groupBox1.Controls.Add(this.lblErrorOnCustomers);
            this.groupBox1.Controls.Add(this.lblDeletedCustomers);
            this.groupBox1.Controls.Add(this.lblUpdatedCustomers);
            this.groupBox1.Controls.Add(this.lblInsertedCustomers);
            this.groupBox1.Controls.Add(this.lblProductPrice);
            this.groupBox1.Controls.Add(this.lblPriceVersion);
            this.groupBox1.Controls.Add(this.lblItems);
            this.groupBox1.Controls.Add(this.lblUOM);
            this.groupBox1.Controls.Add(this.lblCategories);
            this.groupBox1.Controls.Add(this.lblLocators);
            this.groupBox1.Controls.Add(this.lblOrganisation);
            this.groupBox1.Controls.Add(this.lblCompiereToPOS);
            this.groupBox1.Controls.Add(this.lblOrderLines);
            this.groupBox1.Controls.Add(this.lblOrders);
            this.groupBox1.Controls.Add(this.lblCustomers);
            this.groupBox1.Controls.Add(this.lblPOSToCompiere);
            this.groupBox1.Controls.Add(this.lblScript);
            this.groupBox1.Controls.Add(this.lblWarnning);
            this.groupBox1.Controls.Add(this.lblError);
            this.groupBox1.Controls.Add(this.lblDelete);
            this.groupBox1.Controls.Add(this.lblUpdate);
            this.groupBox1.Controls.Add(this.lblInsert);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 530);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // lblUpdatedCash
            // 
            this.lblUpdatedCash.AutoSize = true;
            this.lblUpdatedCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedCash.Location = new System.Drawing.Point(256, 266);
            this.lblUpdatedCash.Name = "lblUpdatedCash";
            this.lblUpdatedCash.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedCash.TabIndex = 136;
            this.lblUpdatedCash.Text = "0";
            // 
            // lblUpdatedCashLine
            // 
            this.lblUpdatedCashLine.AutoSize = true;
            this.lblUpdatedCashLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedCashLine.Location = new System.Drawing.Point(256, 290);
            this.lblUpdatedCashLine.Name = "lblUpdatedCashLine";
            this.lblUpdatedCashLine.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedCashLine.TabIndex = 135;
            this.lblUpdatedCashLine.Text = "0";
            // 
            // lblDeletedCash
            // 
            this.lblDeletedCash.AutoSize = true;
            this.lblDeletedCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedCash.Location = new System.Drawing.Point(336, 266);
            this.lblDeletedCash.Name = "lblDeletedCash";
            this.lblDeletedCash.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedCash.TabIndex = 134;
            this.lblDeletedCash.Text = "0";
            // 
            // lblDeletedCashLine
            // 
            this.lblDeletedCashLine.AutoSize = true;
            this.lblDeletedCashLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedCashLine.Location = new System.Drawing.Point(336, 290);
            this.lblDeletedCashLine.Name = "lblDeletedCashLine";
            this.lblDeletedCashLine.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedCashLine.TabIndex = 133;
            this.lblDeletedCashLine.Text = "0";
            // 
            // lblErrorOnCash
            // 
            this.lblErrorOnCash.AutoSize = true;
            this.lblErrorOnCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnCash.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnCash.Location = new System.Drawing.Point(409, 266);
            this.lblErrorOnCash.Name = "lblErrorOnCash";
            this.lblErrorOnCash.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnCash.TabIndex = 132;
            this.lblErrorOnCash.Text = "0";
            // 
            // lblErrorOnCashLine
            // 
            this.lblErrorOnCashLine.AutoSize = true;
            this.lblErrorOnCashLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnCashLine.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnCashLine.Location = new System.Drawing.Point(409, 290);
            this.lblErrorOnCashLine.Name = "lblErrorOnCashLine";
            this.lblErrorOnCashLine.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnCashLine.TabIndex = 131;
            this.lblErrorOnCashLine.Text = "0";
            // 
            // lblWarnningOnCash
            // 
            this.lblWarnningOnCash.AutoSize = true;
            this.lblWarnningOnCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnCash.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnCash.Location = new System.Drawing.Point(482, 266);
            this.lblWarnningOnCash.Name = "lblWarnningOnCash";
            this.lblWarnningOnCash.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnCash.TabIndex = 130;
            this.lblWarnningOnCash.Text = "0";
            // 
            // lblWarnningOnCashLine
            // 
            this.lblWarnningOnCashLine.AutoSize = true;
            this.lblWarnningOnCashLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnCashLine.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnCashLine.Location = new System.Drawing.Point(482, 290);
            this.lblWarnningOnCashLine.Name = "lblWarnningOnCashLine";
            this.lblWarnningOnCashLine.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnCashLine.TabIndex = 129;
            this.lblWarnningOnCashLine.Text = "0";
            // 
            // lblScriptsOnCash
            // 
            this.lblScriptsOnCash.AutoSize = true;
            this.lblScriptsOnCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnCash.Location = new System.Drawing.Point(562, 266);
            this.lblScriptsOnCash.Name = "lblScriptsOnCash";
            this.lblScriptsOnCash.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnCash.TabIndex = 128;
            this.lblScriptsOnCash.Text = "0";
            // 
            // lblScriptsOnCashLine
            // 
            this.lblScriptsOnCashLine.AutoSize = true;
            this.lblScriptsOnCashLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnCashLine.Location = new System.Drawing.Point(562, 290);
            this.lblScriptsOnCashLine.Name = "lblScriptsOnCashLine";
            this.lblScriptsOnCashLine.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnCashLine.TabIndex = 127;
            this.lblScriptsOnCashLine.Text = "0";
            // 
            // lblInsertedCashLine
            // 
            this.lblInsertedCashLine.AutoSize = true;
            this.lblInsertedCashLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedCashLine.Location = new System.Drawing.Point(176, 290);
            this.lblInsertedCashLine.Name = "lblInsertedCashLine";
            this.lblInsertedCashLine.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedCashLine.TabIndex = 126;
            this.lblInsertedCashLine.Text = "0";
            // 
            // lblInsertedCash
            // 
            this.lblInsertedCash.AutoSize = true;
            this.lblInsertedCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedCash.Location = new System.Drawing.Point(176, 266);
            this.lblInsertedCash.Name = "lblInsertedCash";
            this.lblInsertedCash.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedCash.TabIndex = 125;
            this.lblInsertedCash.Text = "0";
            // 
            // lblCashLine
            // 
            this.lblCashLine.AutoSize = true;
            this.lblCashLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashLine.Location = new System.Drawing.Point(36, 290);
            this.lblCashLine.Name = "lblCashLine";
            this.lblCashLine.Size = new System.Drawing.Size(63, 13);
            this.lblCashLine.TabIndex = 124;
            this.lblCashLine.Text = "Cash Line";
            // 
            // lblCash
            // 
            this.lblCash.AutoSize = true;
            this.lblCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCash.Location = new System.Drawing.Point(36, 266);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(35, 13);
            this.lblCash.TabIndex = 123;
            this.lblCash.Text = "Cash";
            // 
            // lblUpdatedAllocations
            // 
            this.lblUpdatedAllocations.AutoSize = true;
            this.lblUpdatedAllocations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedAllocations.Location = new System.Drawing.Point(256, 221);
            this.lblUpdatedAllocations.Name = "lblUpdatedAllocations";
            this.lblUpdatedAllocations.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedAllocations.TabIndex = 122;
            this.lblUpdatedAllocations.Text = "0";
            // 
            // lblUpdatedAllocationLines
            // 
            this.lblUpdatedAllocationLines.AutoSize = true;
            this.lblUpdatedAllocationLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedAllocationLines.Location = new System.Drawing.Point(256, 245);
            this.lblUpdatedAllocationLines.Name = "lblUpdatedAllocationLines";
            this.lblUpdatedAllocationLines.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedAllocationLines.TabIndex = 121;
            this.lblUpdatedAllocationLines.Text = "0";
            // 
            // lblDeletedAllocations
            // 
            this.lblDeletedAllocations.AutoSize = true;
            this.lblDeletedAllocations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedAllocations.Location = new System.Drawing.Point(336, 221);
            this.lblDeletedAllocations.Name = "lblDeletedAllocations";
            this.lblDeletedAllocations.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedAllocations.TabIndex = 120;
            this.lblDeletedAllocations.Text = "0";
            // 
            // lblDeletedAllocationLines
            // 
            this.lblDeletedAllocationLines.AutoSize = true;
            this.lblDeletedAllocationLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedAllocationLines.Location = new System.Drawing.Point(336, 245);
            this.lblDeletedAllocationLines.Name = "lblDeletedAllocationLines";
            this.lblDeletedAllocationLines.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedAllocationLines.TabIndex = 119;
            this.lblDeletedAllocationLines.Text = "0";
            // 
            // lblErrorOnAllocations
            // 
            this.lblErrorOnAllocations.AutoSize = true;
            this.lblErrorOnAllocations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnAllocations.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnAllocations.Location = new System.Drawing.Point(409, 221);
            this.lblErrorOnAllocations.Name = "lblErrorOnAllocations";
            this.lblErrorOnAllocations.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnAllocations.TabIndex = 118;
            this.lblErrorOnAllocations.Text = "0";
            // 
            // lblErrorOnAllocationLines
            // 
            this.lblErrorOnAllocationLines.AutoSize = true;
            this.lblErrorOnAllocationLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnAllocationLines.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnAllocationLines.Location = new System.Drawing.Point(409, 245);
            this.lblErrorOnAllocationLines.Name = "lblErrorOnAllocationLines";
            this.lblErrorOnAllocationLines.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnAllocationLines.TabIndex = 117;
            this.lblErrorOnAllocationLines.Text = "0";
            // 
            // lblWarnningOnAllocations
            // 
            this.lblWarnningOnAllocations.AutoSize = true;
            this.lblWarnningOnAllocations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnAllocations.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnAllocations.Location = new System.Drawing.Point(482, 221);
            this.lblWarnningOnAllocations.Name = "lblWarnningOnAllocations";
            this.lblWarnningOnAllocations.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnAllocations.TabIndex = 116;
            this.lblWarnningOnAllocations.Text = "0";
            // 
            // lblWarnningOnAllocationLines
            // 
            this.lblWarnningOnAllocationLines.AutoSize = true;
            this.lblWarnningOnAllocationLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnAllocationLines.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnAllocationLines.Location = new System.Drawing.Point(482, 245);
            this.lblWarnningOnAllocationLines.Name = "lblWarnningOnAllocationLines";
            this.lblWarnningOnAllocationLines.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnAllocationLines.TabIndex = 115;
            this.lblWarnningOnAllocationLines.Text = "0";
            // 
            // lblScriptsOnAllocations
            // 
            this.lblScriptsOnAllocations.AutoSize = true;
            this.lblScriptsOnAllocations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnAllocations.Location = new System.Drawing.Point(562, 221);
            this.lblScriptsOnAllocations.Name = "lblScriptsOnAllocations";
            this.lblScriptsOnAllocations.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnAllocations.TabIndex = 114;
            this.lblScriptsOnAllocations.Text = "0";
            // 
            // lblScriptsOnAllocationLines
            // 
            this.lblScriptsOnAllocationLines.AutoSize = true;
            this.lblScriptsOnAllocationLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnAllocationLines.Location = new System.Drawing.Point(562, 245);
            this.lblScriptsOnAllocationLines.Name = "lblScriptsOnAllocationLines";
            this.lblScriptsOnAllocationLines.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnAllocationLines.TabIndex = 113;
            this.lblScriptsOnAllocationLines.Text = "0";
            // 
            // lblInsertedAllocationLines
            // 
            this.lblInsertedAllocationLines.AutoSize = true;
            this.lblInsertedAllocationLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedAllocationLines.Location = new System.Drawing.Point(176, 245);
            this.lblInsertedAllocationLines.Name = "lblInsertedAllocationLines";
            this.lblInsertedAllocationLines.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedAllocationLines.TabIndex = 112;
            this.lblInsertedAllocationLines.Text = "0";
            // 
            // lblInsertedAllocations
            // 
            this.lblInsertedAllocations.AutoSize = true;
            this.lblInsertedAllocations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedAllocations.Location = new System.Drawing.Point(176, 221);
            this.lblInsertedAllocations.Name = "lblInsertedAllocations";
            this.lblInsertedAllocations.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedAllocations.TabIndex = 111;
            this.lblInsertedAllocations.Text = "0";
            // 
            // lblScriptsOnPaymentLines
            // 
            this.lblScriptsOnPaymentLines.AutoSize = true;
            this.lblScriptsOnPaymentLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnPaymentLines.Location = new System.Drawing.Point(562, 198);
            this.lblScriptsOnPaymentLines.Name = "lblScriptsOnPaymentLines";
            this.lblScriptsOnPaymentLines.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnPaymentLines.TabIndex = 110;
            this.lblScriptsOnPaymentLines.Text = "0";
            // 
            // lblWarnningOnPaymentLines
            // 
            this.lblWarnningOnPaymentLines.AutoSize = true;
            this.lblWarnningOnPaymentLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnPaymentLines.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnPaymentLines.Location = new System.Drawing.Point(482, 198);
            this.lblWarnningOnPaymentLines.Name = "lblWarnningOnPaymentLines";
            this.lblWarnningOnPaymentLines.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnPaymentLines.TabIndex = 109;
            this.lblWarnningOnPaymentLines.Text = "0";
            // 
            // lblErrorOnPaymentLines
            // 
            this.lblErrorOnPaymentLines.AutoSize = true;
            this.lblErrorOnPaymentLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnPaymentLines.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnPaymentLines.Location = new System.Drawing.Point(409, 198);
            this.lblErrorOnPaymentLines.Name = "lblErrorOnPaymentLines";
            this.lblErrorOnPaymentLines.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnPaymentLines.TabIndex = 108;
            this.lblErrorOnPaymentLines.Text = "0";
            // 
            // lblDeletedPaymentLines
            // 
            this.lblDeletedPaymentLines.AutoSize = true;
            this.lblDeletedPaymentLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedPaymentLines.Location = new System.Drawing.Point(336, 198);
            this.lblDeletedPaymentLines.Name = "lblDeletedPaymentLines";
            this.lblDeletedPaymentLines.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedPaymentLines.TabIndex = 107;
            this.lblDeletedPaymentLines.Text = "0";
            // 
            // lblUpdatedPaymentLines
            // 
            this.lblUpdatedPaymentLines.AutoSize = true;
            this.lblUpdatedPaymentLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedPaymentLines.Location = new System.Drawing.Point(256, 198);
            this.lblUpdatedPaymentLines.Name = "lblUpdatedPaymentLines";
            this.lblUpdatedPaymentLines.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedPaymentLines.TabIndex = 106;
            this.lblUpdatedPaymentLines.Text = "0";
            // 
            // lblInsertedPaymentLines
            // 
            this.lblInsertedPaymentLines.AutoSize = true;
            this.lblInsertedPaymentLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedPaymentLines.Location = new System.Drawing.Point(176, 198);
            this.lblInsertedPaymentLines.Name = "lblInsertedPaymentLines";
            this.lblInsertedPaymentLines.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedPaymentLines.TabIndex = 105;
            this.lblInsertedPaymentLines.Text = "0";
            // 
            // lblAllocationLine
            // 
            this.lblAllocationLine.AutoSize = true;
            this.lblAllocationLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllocationLine.Location = new System.Drawing.Point(36, 245);
            this.lblAllocationLine.Name = "lblAllocationLine";
            this.lblAllocationLine.Size = new System.Drawing.Size(91, 13);
            this.lblAllocationLine.TabIndex = 104;
            this.lblAllocationLine.Text = "Allocation Line";
            // 
            // lblAllocation
            // 
            this.lblAllocation.AutoSize = true;
            this.lblAllocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllocation.Location = new System.Drawing.Point(36, 221);
            this.lblAllocation.Name = "lblAllocation";
            this.lblAllocation.Size = new System.Drawing.Size(63, 13);
            this.lblAllocation.TabIndex = 103;
            this.lblAllocation.Text = "Allocation";
            // 
            // lblPaymentlines
            // 
            this.lblPaymentlines.AutoSize = true;
            this.lblPaymentlines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentlines.Location = new System.Drawing.Point(36, 198);
            this.lblPaymentlines.Name = "lblPaymentlines";
            this.lblPaymentlines.Size = new System.Drawing.Size(105, 13);
            this.lblPaymentlines.TabIndex = 102;
            this.lblPaymentlines.Text = "Payment Allocate";
            // 
            // lblUpdatedExemptionsLine
            // 
            this.lblUpdatedExemptionsLine.AutoSize = true;
            this.lblUpdatedExemptionsLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedExemptionsLine.Location = new System.Drawing.Point(256, 152);
            this.lblUpdatedExemptionsLine.Name = "lblUpdatedExemptionsLine";
            this.lblUpdatedExemptionsLine.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedExemptionsLine.TabIndex = 101;
            this.lblUpdatedExemptionsLine.Text = "0";
            // 
            // lblUpdatedPayments
            // 
            this.lblUpdatedPayments.AutoSize = true;
            this.lblUpdatedPayments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedPayments.Location = new System.Drawing.Point(256, 176);
            this.lblUpdatedPayments.Name = "lblUpdatedPayments";
            this.lblUpdatedPayments.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedPayments.TabIndex = 100;
            this.lblUpdatedPayments.Text = "0";
            // 
            // lblDeletedExemptionsLine
            // 
            this.lblDeletedExemptionsLine.AutoSize = true;
            this.lblDeletedExemptionsLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedExemptionsLine.Location = new System.Drawing.Point(336, 152);
            this.lblDeletedExemptionsLine.Name = "lblDeletedExemptionsLine";
            this.lblDeletedExemptionsLine.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedExemptionsLine.TabIndex = 99;
            this.lblDeletedExemptionsLine.Text = "0";
            // 
            // lblDeletedPayments
            // 
            this.lblDeletedPayments.AutoSize = true;
            this.lblDeletedPayments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedPayments.Location = new System.Drawing.Point(336, 176);
            this.lblDeletedPayments.Name = "lblDeletedPayments";
            this.lblDeletedPayments.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedPayments.TabIndex = 98;
            this.lblDeletedPayments.Text = "0";
            // 
            // lblErrorOnExemptionLine
            // 
            this.lblErrorOnExemptionLine.AutoSize = true;
            this.lblErrorOnExemptionLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnExemptionLine.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnExemptionLine.Location = new System.Drawing.Point(409, 152);
            this.lblErrorOnExemptionLine.Name = "lblErrorOnExemptionLine";
            this.lblErrorOnExemptionLine.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnExemptionLine.TabIndex = 97;
            this.lblErrorOnExemptionLine.Text = "0";
            // 
            // lblErrorOnPayments
            // 
            this.lblErrorOnPayments.AutoSize = true;
            this.lblErrorOnPayments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnPayments.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnPayments.Location = new System.Drawing.Point(409, 176);
            this.lblErrorOnPayments.Name = "lblErrorOnPayments";
            this.lblErrorOnPayments.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnPayments.TabIndex = 96;
            this.lblErrorOnPayments.Text = "0";
            // 
            // lblWarnningOnExemptionsLine
            // 
            this.lblWarnningOnExemptionsLine.AutoSize = true;
            this.lblWarnningOnExemptionsLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnExemptionsLine.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnExemptionsLine.Location = new System.Drawing.Point(482, 152);
            this.lblWarnningOnExemptionsLine.Name = "lblWarnningOnExemptionsLine";
            this.lblWarnningOnExemptionsLine.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnExemptionsLine.TabIndex = 95;
            this.lblWarnningOnExemptionsLine.Text = "0";
            // 
            // lblWarnningOnPayments
            // 
            this.lblWarnningOnPayments.AutoSize = true;
            this.lblWarnningOnPayments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnPayments.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnPayments.Location = new System.Drawing.Point(482, 176);
            this.lblWarnningOnPayments.Name = "lblWarnningOnPayments";
            this.lblWarnningOnPayments.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnPayments.TabIndex = 94;
            this.lblWarnningOnPayments.Text = "0";
            // 
            // lblScriptsOnExemptionsLine
            // 
            this.lblScriptsOnExemptionsLine.AutoSize = true;
            this.lblScriptsOnExemptionsLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnExemptionsLine.Location = new System.Drawing.Point(562, 152);
            this.lblScriptsOnExemptionsLine.Name = "lblScriptsOnExemptionsLine";
            this.lblScriptsOnExemptionsLine.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnExemptionsLine.TabIndex = 93;
            this.lblScriptsOnExemptionsLine.Text = "0";
            // 
            // lblScriptsOnPayments
            // 
            this.lblScriptsOnPayments.AutoSize = true;
            this.lblScriptsOnPayments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnPayments.Location = new System.Drawing.Point(562, 176);
            this.lblScriptsOnPayments.Name = "lblScriptsOnPayments";
            this.lblScriptsOnPayments.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnPayments.TabIndex = 92;
            this.lblScriptsOnPayments.Text = "0";
            // 
            // lblInsertedPayments
            // 
            this.lblInsertedPayments.AutoSize = true;
            this.lblInsertedPayments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedPayments.Location = new System.Drawing.Point(176, 176);
            this.lblInsertedPayments.Name = "lblInsertedPayments";
            this.lblInsertedPayments.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedPayments.TabIndex = 91;
            this.lblInsertedPayments.Text = "0";
            // 
            // lblInsertedExemptionLine
            // 
            this.lblInsertedExemptionLine.AutoSize = true;
            this.lblInsertedExemptionLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedExemptionLine.Location = new System.Drawing.Point(176, 152);
            this.lblInsertedExemptionLine.Name = "lblInsertedExemptionLine";
            this.lblInsertedExemptionLine.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedExemptionLine.TabIndex = 90;
            this.lblInsertedExemptionLine.Text = "0";
            // 
            // lblScriptsOnExemptions
            // 
            this.lblScriptsOnExemptions.AutoSize = true;
            this.lblScriptsOnExemptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnExemptions.Location = new System.Drawing.Point(562, 129);
            this.lblScriptsOnExemptions.Name = "lblScriptsOnExemptions";
            this.lblScriptsOnExemptions.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnExemptions.TabIndex = 89;
            this.lblScriptsOnExemptions.Text = "0";
            // 
            // lblWarnningOnExemptions
            // 
            this.lblWarnningOnExemptions.AutoSize = true;
            this.lblWarnningOnExemptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnExemptions.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnExemptions.Location = new System.Drawing.Point(482, 129);
            this.lblWarnningOnExemptions.Name = "lblWarnningOnExemptions";
            this.lblWarnningOnExemptions.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnExemptions.TabIndex = 88;
            this.lblWarnningOnExemptions.Text = "0";
            // 
            // lblErrorOnExemptions
            // 
            this.lblErrorOnExemptions.AutoSize = true;
            this.lblErrorOnExemptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnExemptions.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnExemptions.Location = new System.Drawing.Point(409, 129);
            this.lblErrorOnExemptions.Name = "lblErrorOnExemptions";
            this.lblErrorOnExemptions.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnExemptions.TabIndex = 87;
            this.lblErrorOnExemptions.Text = "0";
            // 
            // lblDeletedExemptions
            // 
            this.lblDeletedExemptions.AutoSize = true;
            this.lblDeletedExemptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedExemptions.Location = new System.Drawing.Point(336, 129);
            this.lblDeletedExemptions.Name = "lblDeletedExemptions";
            this.lblDeletedExemptions.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedExemptions.TabIndex = 86;
            this.lblDeletedExemptions.Text = "0";
            // 
            // lblUpdatedExemptions
            // 
            this.lblUpdatedExemptions.AutoSize = true;
            this.lblUpdatedExemptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedExemptions.Location = new System.Drawing.Point(256, 129);
            this.lblUpdatedExemptions.Name = "lblUpdatedExemptions";
            this.lblUpdatedExemptions.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedExemptions.TabIndex = 85;
            this.lblUpdatedExemptions.Text = "0";
            // 
            // lblInsertedExemptions
            // 
            this.lblInsertedExemptions.AutoSize = true;
            this.lblInsertedExemptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedExemptions.Location = new System.Drawing.Point(176, 129);
            this.lblInsertedExemptions.Name = "lblInsertedExemptions";
            this.lblInsertedExemptions.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedExemptions.TabIndex = 84;
            this.lblInsertedExemptions.Text = "0";
            // 
            // lblPayment
            // 
            this.lblPayment.AutoSize = true;
            this.lblPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayment.Location = new System.Drawing.Point(36, 176);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(61, 13);
            this.lblPayment.TabIndex = 83;
            this.lblPayment.Text = "Payments";
            // 
            // lblExemptionLine
            // 
            this.lblExemptionLine.AutoSize = true;
            this.lblExemptionLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExemptionLine.Location = new System.Drawing.Point(36, 152);
            this.lblExemptionLine.Name = "lblExemptionLine";
            this.lblExemptionLine.Size = new System.Drawing.Size(83, 13);
            this.lblExemptionLine.TabIndex = 82;
            this.lblExemptionLine.Text = "Invoice Lines";
            // 
            // lblExemptions
            // 
            this.lblExemptions.AutoSize = true;
            this.lblExemptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExemptions.Location = new System.Drawing.Point(36, 129);
            this.lblExemptions.Name = "lblExemptions";
            this.lblExemptions.Size = new System.Drawing.Size(55, 13);
            this.lblExemptions.TabIndex = 81;
            this.lblExemptions.Text = "Invoices";
            // 
            // lblCompierePOSStartTime
            // 
            this.lblCompierePOSStartTime.AutoSize = true;
            this.lblCompierePOSStartTime.Location = new System.Drawing.Point(270, 336);
            this.lblCompierePOSStartTime.Name = "lblCompierePOSStartTime";
            this.lblCompierePOSStartTime.Size = new System.Drawing.Size(57, 13);
            this.lblCompierePOSStartTime.TabIndex = 80;
            this.lblCompierePOSStartTime.Text = "15:20:00";
            // 
            // lblCompierePOSStatus
            // 
            this.lblCompierePOSStatus.AutoSize = true;
            this.lblCompierePOSStatus.ForeColor = System.Drawing.Color.LawnGreen;
            this.lblCompierePOSStatus.Location = new System.Drawing.Point(150, 336);
            this.lblCompierePOSStatus.Name = "lblCompierePOSStatus";
            this.lblCompierePOSStatus.Size = new System.Drawing.Size(25, 13);
            this.lblCompierePOSStatus.TabIndex = 79;
            this.lblCompierePOSStatus.Text = "ON";
            // 
            // lblPosCompiereStartTime
            // 
            this.lblPosCompiereStartTime.AutoSize = true;
            this.lblPosCompiereStartTime.Location = new System.Drawing.Point(270, 36);
            this.lblPosCompiereStartTime.Name = "lblPosCompiereStartTime";
            this.lblPosCompiereStartTime.Size = new System.Drawing.Size(57, 13);
            this.lblPosCompiereStartTime.TabIndex = 4;
            this.lblPosCompiereStartTime.Text = "15:15:20";
            // 
            // lblUpdatedOrders
            // 
            this.lblUpdatedOrders.AutoSize = true;
            this.lblUpdatedOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedOrders.Location = new System.Drawing.Point(255, 83);
            this.lblUpdatedOrders.Name = "lblUpdatedOrders";
            this.lblUpdatedOrders.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedOrders.TabIndex = 78;
            this.lblUpdatedOrders.Text = "0";
            // 
            // lblUpdatedOrderLines
            // 
            this.lblUpdatedOrderLines.AutoSize = true;
            this.lblUpdatedOrderLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedOrderLines.Location = new System.Drawing.Point(255, 107);
            this.lblUpdatedOrderLines.Name = "lblUpdatedOrderLines";
            this.lblUpdatedOrderLines.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedOrderLines.TabIndex = 77;
            this.lblUpdatedOrderLines.Text = "0";
            // 
            // lblDeletedOrders
            // 
            this.lblDeletedOrders.AutoSize = true;
            this.lblDeletedOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedOrders.Location = new System.Drawing.Point(335, 83);
            this.lblDeletedOrders.Name = "lblDeletedOrders";
            this.lblDeletedOrders.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedOrders.TabIndex = 76;
            this.lblDeletedOrders.Text = "0";
            // 
            // lblDeletedOrderLines
            // 
            this.lblDeletedOrderLines.AutoSize = true;
            this.lblDeletedOrderLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedOrderLines.Location = new System.Drawing.Point(335, 107);
            this.lblDeletedOrderLines.Name = "lblDeletedOrderLines";
            this.lblDeletedOrderLines.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedOrderLines.TabIndex = 75;
            this.lblDeletedOrderLines.Text = "0";
            // 
            // lblErrorOnOrders
            // 
            this.lblErrorOnOrders.AutoSize = true;
            this.lblErrorOnOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnOrders.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnOrders.Location = new System.Drawing.Point(408, 83);
            this.lblErrorOnOrders.Name = "lblErrorOnOrders";
            this.lblErrorOnOrders.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnOrders.TabIndex = 74;
            this.lblErrorOnOrders.Text = "0";
            // 
            // lblErrorOnOrderLines
            // 
            this.lblErrorOnOrderLines.AutoSize = true;
            this.lblErrorOnOrderLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnOrderLines.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnOrderLines.Location = new System.Drawing.Point(408, 107);
            this.lblErrorOnOrderLines.Name = "lblErrorOnOrderLines";
            this.lblErrorOnOrderLines.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnOrderLines.TabIndex = 73;
            this.lblErrorOnOrderLines.Text = "0";
            // 
            // lblWarnningOnOrders
            // 
            this.lblWarnningOnOrders.AutoSize = true;
            this.lblWarnningOnOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnOrders.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnOrders.Location = new System.Drawing.Point(481, 83);
            this.lblWarnningOnOrders.Name = "lblWarnningOnOrders";
            this.lblWarnningOnOrders.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnOrders.TabIndex = 72;
            this.lblWarnningOnOrders.Text = "0";
            // 
            // lblWarnningOnOrderLines
            // 
            this.lblWarnningOnOrderLines.AutoSize = true;
            this.lblWarnningOnOrderLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnOrderLines.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnOrderLines.Location = new System.Drawing.Point(481, 107);
            this.lblWarnningOnOrderLines.Name = "lblWarnningOnOrderLines";
            this.lblWarnningOnOrderLines.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnOrderLines.TabIndex = 71;
            this.lblWarnningOnOrderLines.Text = "0";
            // 
            // lblScriptsOnOrders
            // 
            this.lblScriptsOnOrders.AutoSize = true;
            this.lblScriptsOnOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnOrders.Location = new System.Drawing.Point(561, 83);
            this.lblScriptsOnOrders.Name = "lblScriptsOnOrders";
            this.lblScriptsOnOrders.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnOrders.TabIndex = 70;
            this.lblScriptsOnOrders.Text = "0";
            // 
            // lblScriptsOnOrderLines
            // 
            this.lblScriptsOnOrderLines.AutoSize = true;
            this.lblScriptsOnOrderLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnOrderLines.Location = new System.Drawing.Point(561, 107);
            this.lblScriptsOnOrderLines.Name = "lblScriptsOnOrderLines";
            this.lblScriptsOnOrderLines.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnOrderLines.TabIndex = 69;
            this.lblScriptsOnOrderLines.Text = "0";
            // 
            // lblUpdatedOrganisation
            // 
            this.lblUpdatedOrganisation.AutoSize = true;
            this.lblUpdatedOrganisation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedOrganisation.Location = new System.Drawing.Point(255, 358);
            this.lblUpdatedOrganisation.Name = "lblUpdatedOrganisation";
            this.lblUpdatedOrganisation.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedOrganisation.TabIndex = 68;
            this.lblUpdatedOrganisation.Text = "0";
            // 
            // lblDeletedOrganisation
            // 
            this.lblDeletedOrganisation.AutoSize = true;
            this.lblDeletedOrganisation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedOrganisation.Location = new System.Drawing.Point(335, 358);
            this.lblDeletedOrganisation.Name = "lblDeletedOrganisation";
            this.lblDeletedOrganisation.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedOrganisation.TabIndex = 67;
            this.lblDeletedOrganisation.Text = "0";
            // 
            // lblErrorOnOrganisation
            // 
            this.lblErrorOnOrganisation.AutoSize = true;
            this.lblErrorOnOrganisation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnOrganisation.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnOrganisation.Location = new System.Drawing.Point(408, 358);
            this.lblErrorOnOrganisation.Name = "lblErrorOnOrganisation";
            this.lblErrorOnOrganisation.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnOrganisation.TabIndex = 66;
            this.lblErrorOnOrganisation.Text = "0";
            // 
            // lblWarnningOnOrganisation
            // 
            this.lblWarnningOnOrganisation.AutoSize = true;
            this.lblWarnningOnOrganisation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnOrganisation.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnOrganisation.Location = new System.Drawing.Point(481, 358);
            this.lblWarnningOnOrganisation.Name = "lblWarnningOnOrganisation";
            this.lblWarnningOnOrganisation.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnOrganisation.TabIndex = 65;
            this.lblWarnningOnOrganisation.Text = "0";
            // 
            // lblScriptsOnOrganisation
            // 
            this.lblScriptsOnOrganisation.AutoSize = true;
            this.lblScriptsOnOrganisation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnOrganisation.Location = new System.Drawing.Point(561, 358);
            this.lblScriptsOnOrganisation.Name = "lblScriptsOnOrganisation";
            this.lblScriptsOnOrganisation.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnOrganisation.TabIndex = 64;
            this.lblScriptsOnOrganisation.Text = "0";
            // 
            // lblUpdatedLocators
            // 
            this.lblUpdatedLocators.AutoSize = true;
            this.lblUpdatedLocators.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedLocators.Location = new System.Drawing.Point(255, 382);
            this.lblUpdatedLocators.Name = "lblUpdatedLocators";
            this.lblUpdatedLocators.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedLocators.TabIndex = 63;
            this.lblUpdatedLocators.Text = "0";
            // 
            // lblDeletedLocators
            // 
            this.lblDeletedLocators.AutoSize = true;
            this.lblDeletedLocators.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedLocators.Location = new System.Drawing.Point(335, 382);
            this.lblDeletedLocators.Name = "lblDeletedLocators";
            this.lblDeletedLocators.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedLocators.TabIndex = 62;
            this.lblDeletedLocators.Text = "0";
            // 
            // lblErrorOnLocators
            // 
            this.lblErrorOnLocators.AutoSize = true;
            this.lblErrorOnLocators.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnLocators.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnLocators.Location = new System.Drawing.Point(408, 382);
            this.lblErrorOnLocators.Name = "lblErrorOnLocators";
            this.lblErrorOnLocators.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnLocators.TabIndex = 61;
            this.lblErrorOnLocators.Text = "0";
            // 
            // lblWarnningOnLocators
            // 
            this.lblWarnningOnLocators.AutoSize = true;
            this.lblWarnningOnLocators.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnLocators.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnLocators.Location = new System.Drawing.Point(481, 382);
            this.lblWarnningOnLocators.Name = "lblWarnningOnLocators";
            this.lblWarnningOnLocators.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnLocators.TabIndex = 60;
            this.lblWarnningOnLocators.Text = "0";
            // 
            // lblScriptsOnLocators
            // 
            this.lblScriptsOnLocators.AutoSize = true;
            this.lblScriptsOnLocators.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnLocators.Location = new System.Drawing.Point(561, 382);
            this.lblScriptsOnLocators.Name = "lblScriptsOnLocators";
            this.lblScriptsOnLocators.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnLocators.TabIndex = 59;
            this.lblScriptsOnLocators.Text = "0";
            // 
            // lblUpdatedCategory
            // 
            this.lblUpdatedCategory.AutoSize = true;
            this.lblUpdatedCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedCategory.Location = new System.Drawing.Point(255, 406);
            this.lblUpdatedCategory.Name = "lblUpdatedCategory";
            this.lblUpdatedCategory.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedCategory.TabIndex = 58;
            this.lblUpdatedCategory.Text = "0";
            // 
            // lblDeletedCategories
            // 
            this.lblDeletedCategories.AutoSize = true;
            this.lblDeletedCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedCategories.Location = new System.Drawing.Point(335, 406);
            this.lblDeletedCategories.Name = "lblDeletedCategories";
            this.lblDeletedCategories.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedCategories.TabIndex = 57;
            this.lblDeletedCategories.Text = "0";
            // 
            // lblErrorOnCategories
            // 
            this.lblErrorOnCategories.AutoSize = true;
            this.lblErrorOnCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnCategories.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnCategories.Location = new System.Drawing.Point(408, 406);
            this.lblErrorOnCategories.Name = "lblErrorOnCategories";
            this.lblErrorOnCategories.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnCategories.TabIndex = 56;
            this.lblErrorOnCategories.Text = "0";
            // 
            // lblWarnningOnCategories
            // 
            this.lblWarnningOnCategories.AutoSize = true;
            this.lblWarnningOnCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnCategories.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnCategories.Location = new System.Drawing.Point(481, 406);
            this.lblWarnningOnCategories.Name = "lblWarnningOnCategories";
            this.lblWarnningOnCategories.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnCategories.TabIndex = 55;
            this.lblWarnningOnCategories.Text = "0";
            // 
            // lblScriptsOnCategories
            // 
            this.lblScriptsOnCategories.AutoSize = true;
            this.lblScriptsOnCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnCategories.Location = new System.Drawing.Point(561, 406);
            this.lblScriptsOnCategories.Name = "lblScriptsOnCategories";
            this.lblScriptsOnCategories.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnCategories.TabIndex = 54;
            this.lblScriptsOnCategories.Text = "0";
            // 
            // lblUpdatedUOM
            // 
            this.lblUpdatedUOM.AutoSize = true;
            this.lblUpdatedUOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedUOM.Location = new System.Drawing.Point(255, 430);
            this.lblUpdatedUOM.Name = "lblUpdatedUOM";
            this.lblUpdatedUOM.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedUOM.TabIndex = 53;
            this.lblUpdatedUOM.Text = "0";
            // 
            // lblDeletedUOM
            // 
            this.lblDeletedUOM.AutoSize = true;
            this.lblDeletedUOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedUOM.Location = new System.Drawing.Point(335, 430);
            this.lblDeletedUOM.Name = "lblDeletedUOM";
            this.lblDeletedUOM.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedUOM.TabIndex = 52;
            this.lblDeletedUOM.Text = "0";
            // 
            // lblErrorOnUOM
            // 
            this.lblErrorOnUOM.AutoSize = true;
            this.lblErrorOnUOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnUOM.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnUOM.Location = new System.Drawing.Point(408, 430);
            this.lblErrorOnUOM.Name = "lblErrorOnUOM";
            this.lblErrorOnUOM.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnUOM.TabIndex = 51;
            this.lblErrorOnUOM.Text = "0";
            // 
            // lblWarnningOnUOM
            // 
            this.lblWarnningOnUOM.AutoSize = true;
            this.lblWarnningOnUOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnUOM.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnUOM.Location = new System.Drawing.Point(481, 430);
            this.lblWarnningOnUOM.Name = "lblWarnningOnUOM";
            this.lblWarnningOnUOM.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnUOM.TabIndex = 50;
            this.lblWarnningOnUOM.Text = "0";
            // 
            // lblScriptsOnUOM
            // 
            this.lblScriptsOnUOM.AutoSize = true;
            this.lblScriptsOnUOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnUOM.Location = new System.Drawing.Point(561, 430);
            this.lblScriptsOnUOM.Name = "lblScriptsOnUOM";
            this.lblScriptsOnUOM.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnUOM.TabIndex = 49;
            this.lblScriptsOnUOM.Text = "0";
            // 
            // lblUpdatedItems
            // 
            this.lblUpdatedItems.AutoSize = true;
            this.lblUpdatedItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedItems.Location = new System.Drawing.Point(255, 454);
            this.lblUpdatedItems.Name = "lblUpdatedItems";
            this.lblUpdatedItems.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedItems.TabIndex = 48;
            this.lblUpdatedItems.Text = "0";
            // 
            // lblDeletedItems
            // 
            this.lblDeletedItems.AutoSize = true;
            this.lblDeletedItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedItems.Location = new System.Drawing.Point(335, 454);
            this.lblDeletedItems.Name = "lblDeletedItems";
            this.lblDeletedItems.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedItems.TabIndex = 47;
            this.lblDeletedItems.Text = "0";
            // 
            // lblErrorOnItems
            // 
            this.lblErrorOnItems.AutoSize = true;
            this.lblErrorOnItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnItems.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnItems.Location = new System.Drawing.Point(408, 454);
            this.lblErrorOnItems.Name = "lblErrorOnItems";
            this.lblErrorOnItems.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnItems.TabIndex = 46;
            this.lblErrorOnItems.Text = "0";
            // 
            // lblWarnningOnItems
            // 
            this.lblWarnningOnItems.AutoSize = true;
            this.lblWarnningOnItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnItems.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnItems.Location = new System.Drawing.Point(481, 454);
            this.lblWarnningOnItems.Name = "lblWarnningOnItems";
            this.lblWarnningOnItems.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnItems.TabIndex = 45;
            this.lblWarnningOnItems.Text = "0";
            // 
            // lblScriptsOnItems
            // 
            this.lblScriptsOnItems.AutoSize = true;
            this.lblScriptsOnItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnItems.Location = new System.Drawing.Point(561, 454);
            this.lblScriptsOnItems.Name = "lblScriptsOnItems";
            this.lblScriptsOnItems.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnItems.TabIndex = 44;
            this.lblScriptsOnItems.Text = "0";
            // 
            // lblUpdatedPriceListVersion
            // 
            this.lblUpdatedPriceListVersion.AutoSize = true;
            this.lblUpdatedPriceListVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedPriceListVersion.Location = new System.Drawing.Point(255, 478);
            this.lblUpdatedPriceListVersion.Name = "lblUpdatedPriceListVersion";
            this.lblUpdatedPriceListVersion.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedPriceListVersion.TabIndex = 43;
            this.lblUpdatedPriceListVersion.Text = "0";
            // 
            // lblDeletedPriceListVersion
            // 
            this.lblDeletedPriceListVersion.AutoSize = true;
            this.lblDeletedPriceListVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedPriceListVersion.Location = new System.Drawing.Point(335, 478);
            this.lblDeletedPriceListVersion.Name = "lblDeletedPriceListVersion";
            this.lblDeletedPriceListVersion.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedPriceListVersion.TabIndex = 42;
            this.lblDeletedPriceListVersion.Text = "0";
            // 
            // lblErrorOnPriceListVersion
            // 
            this.lblErrorOnPriceListVersion.AutoSize = true;
            this.lblErrorOnPriceListVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnPriceListVersion.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnPriceListVersion.Location = new System.Drawing.Point(408, 478);
            this.lblErrorOnPriceListVersion.Name = "lblErrorOnPriceListVersion";
            this.lblErrorOnPriceListVersion.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnPriceListVersion.TabIndex = 41;
            this.lblErrorOnPriceListVersion.Text = "0";
            // 
            // lblWarnningOnPriceListVersion
            // 
            this.lblWarnningOnPriceListVersion.AutoSize = true;
            this.lblWarnningOnPriceListVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnPriceListVersion.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnPriceListVersion.Location = new System.Drawing.Point(481, 478);
            this.lblWarnningOnPriceListVersion.Name = "lblWarnningOnPriceListVersion";
            this.lblWarnningOnPriceListVersion.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnPriceListVersion.TabIndex = 40;
            this.lblWarnningOnPriceListVersion.Text = "0";
            // 
            // lblScriptsOnPriceListVersion
            // 
            this.lblScriptsOnPriceListVersion.AutoSize = true;
            this.lblScriptsOnPriceListVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnPriceListVersion.Location = new System.Drawing.Point(561, 478);
            this.lblScriptsOnPriceListVersion.Name = "lblScriptsOnPriceListVersion";
            this.lblScriptsOnPriceListVersion.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnPriceListVersion.TabIndex = 39;
            this.lblScriptsOnPriceListVersion.Text = "0";
            // 
            // lblUpdatedProductPrice
            // 
            this.lblUpdatedProductPrice.AutoSize = true;
            this.lblUpdatedProductPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedProductPrice.Location = new System.Drawing.Point(255, 504);
            this.lblUpdatedProductPrice.Name = "lblUpdatedProductPrice";
            this.lblUpdatedProductPrice.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedProductPrice.TabIndex = 38;
            this.lblUpdatedProductPrice.Text = "0";
            // 
            // lblDeletedProductPrice
            // 
            this.lblDeletedProductPrice.AutoSize = true;
            this.lblDeletedProductPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedProductPrice.Location = new System.Drawing.Point(335, 502);
            this.lblDeletedProductPrice.Name = "lblDeletedProductPrice";
            this.lblDeletedProductPrice.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedProductPrice.TabIndex = 37;
            this.lblDeletedProductPrice.Text = "0";
            // 
            // lblErrorOnProductPrice
            // 
            this.lblErrorOnProductPrice.AutoSize = true;
            this.lblErrorOnProductPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnProductPrice.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnProductPrice.Location = new System.Drawing.Point(408, 502);
            this.lblErrorOnProductPrice.Name = "lblErrorOnProductPrice";
            this.lblErrorOnProductPrice.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnProductPrice.TabIndex = 36;
            this.lblErrorOnProductPrice.Text = "0";
            // 
            // lblWarnningOnProductPrice
            // 
            this.lblWarnningOnProductPrice.AutoSize = true;
            this.lblWarnningOnProductPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnProductPrice.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnProductPrice.Location = new System.Drawing.Point(481, 504);
            this.lblWarnningOnProductPrice.Name = "lblWarnningOnProductPrice";
            this.lblWarnningOnProductPrice.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnProductPrice.TabIndex = 35;
            this.lblWarnningOnProductPrice.Text = "0";
            // 
            // lblScriptsOnProductPrice
            // 
            this.lblScriptsOnProductPrice.AutoSize = true;
            this.lblScriptsOnProductPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnProductPrice.Location = new System.Drawing.Point(561, 504);
            this.lblScriptsOnProductPrice.Name = "lblScriptsOnProductPrice";
            this.lblScriptsOnProductPrice.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnProductPrice.TabIndex = 34;
            this.lblScriptsOnProductPrice.Text = "0";
            // 
            // lblInsertedProductPrice
            // 
            this.lblInsertedProductPrice.AutoSize = true;
            this.lblInsertedProductPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedProductPrice.Location = new System.Drawing.Point(175, 504);
            this.lblInsertedProductPrice.Name = "lblInsertedProductPrice";
            this.lblInsertedProductPrice.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedProductPrice.TabIndex = 33;
            this.lblInsertedProductPrice.Text = "0";
            // 
            // lblPosCompiereStatus
            // 
            this.lblPosCompiereStatus.AutoSize = true;
            this.lblPosCompiereStatus.ForeColor = System.Drawing.Color.LawnGreen;
            this.lblPosCompiereStatus.Location = new System.Drawing.Point(150, 38);
            this.lblPosCompiereStatus.Name = "lblPosCompiereStatus";
            this.lblPosCompiereStatus.Size = new System.Drawing.Size(25, 13);
            this.lblPosCompiereStatus.TabIndex = 32;
            this.lblPosCompiereStatus.Text = "ON";
            // 
            // lblInsertedPriceListVersion
            // 
            this.lblInsertedPriceListVersion.AutoSize = true;
            this.lblInsertedPriceListVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedPriceListVersion.Location = new System.Drawing.Point(175, 478);
            this.lblInsertedPriceListVersion.Name = "lblInsertedPriceListVersion";
            this.lblInsertedPriceListVersion.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedPriceListVersion.TabIndex = 31;
            this.lblInsertedPriceListVersion.Text = "0";
            // 
            // lblInsertedItems
            // 
            this.lblInsertedItems.AutoSize = true;
            this.lblInsertedItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedItems.Location = new System.Drawing.Point(175, 454);
            this.lblInsertedItems.Name = "lblInsertedItems";
            this.lblInsertedItems.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedItems.TabIndex = 30;
            this.lblInsertedItems.Text = "0";
            // 
            // lblInsertedUOM
            // 
            this.lblInsertedUOM.AutoSize = true;
            this.lblInsertedUOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedUOM.Location = new System.Drawing.Point(175, 430);
            this.lblInsertedUOM.Name = "lblInsertedUOM";
            this.lblInsertedUOM.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedUOM.TabIndex = 29;
            this.lblInsertedUOM.Text = "0";
            // 
            // lblInsertedCategories
            // 
            this.lblInsertedCategories.AutoSize = true;
            this.lblInsertedCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedCategories.Location = new System.Drawing.Point(175, 406);
            this.lblInsertedCategories.Name = "lblInsertedCategories";
            this.lblInsertedCategories.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedCategories.TabIndex = 28;
            this.lblInsertedCategories.Text = "0";
            // 
            // lblInsertedLocators
            // 
            this.lblInsertedLocators.AutoSize = true;
            this.lblInsertedLocators.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedLocators.Location = new System.Drawing.Point(175, 382);
            this.lblInsertedLocators.Name = "lblInsertedLocators";
            this.lblInsertedLocators.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedLocators.TabIndex = 27;
            this.lblInsertedLocators.Text = "0";
            // 
            // lblInsertedOrganistion
            // 
            this.lblInsertedOrganistion.AutoSize = true;
            this.lblInsertedOrganistion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedOrganistion.Location = new System.Drawing.Point(175, 358);
            this.lblInsertedOrganistion.Name = "lblInsertedOrganistion";
            this.lblInsertedOrganistion.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedOrganistion.TabIndex = 26;
            this.lblInsertedOrganistion.Text = "0";
            // 
            // lblInsertedOrderLines
            // 
            this.lblInsertedOrderLines.AutoSize = true;
            this.lblInsertedOrderLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedOrderLines.Location = new System.Drawing.Point(175, 107);
            this.lblInsertedOrderLines.Name = "lblInsertedOrderLines";
            this.lblInsertedOrderLines.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedOrderLines.TabIndex = 25;
            this.lblInsertedOrderLines.Text = "0";
            // 
            // lblInsertedOrders
            // 
            this.lblInsertedOrders.AutoSize = true;
            this.lblInsertedOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedOrders.Location = new System.Drawing.Point(175, 83);
            this.lblInsertedOrders.Name = "lblInsertedOrders";
            this.lblInsertedOrders.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedOrders.TabIndex = 24;
            this.lblInsertedOrders.Text = "0";
            // 
            // lblScriptsOnCustomers
            // 
            this.lblScriptsOnCustomers.AutoSize = true;
            this.lblScriptsOnCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnCustomers.Location = new System.Drawing.Point(561, 60);
            this.lblScriptsOnCustomers.Name = "lblScriptsOnCustomers";
            this.lblScriptsOnCustomers.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnCustomers.TabIndex = 23;
            this.lblScriptsOnCustomers.Text = "0";
            // 
            // lblWarnningOnCustomers
            // 
            this.lblWarnningOnCustomers.AutoSize = true;
            this.lblWarnningOnCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnCustomers.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnCustomers.Location = new System.Drawing.Point(481, 60);
            this.lblWarnningOnCustomers.Name = "lblWarnningOnCustomers";
            this.lblWarnningOnCustomers.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnCustomers.TabIndex = 22;
            this.lblWarnningOnCustomers.Text = "0";
            // 
            // lblErrorOnCustomers
            // 
            this.lblErrorOnCustomers.AutoSize = true;
            this.lblErrorOnCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnCustomers.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnCustomers.Location = new System.Drawing.Point(408, 60);
            this.lblErrorOnCustomers.Name = "lblErrorOnCustomers";
            this.lblErrorOnCustomers.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnCustomers.TabIndex = 21;
            this.lblErrorOnCustomers.Text = "0";
            // 
            // lblDeletedCustomers
            // 
            this.lblDeletedCustomers.AutoSize = true;
            this.lblDeletedCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedCustomers.Location = new System.Drawing.Point(335, 60);
            this.lblDeletedCustomers.Name = "lblDeletedCustomers";
            this.lblDeletedCustomers.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedCustomers.TabIndex = 20;
            this.lblDeletedCustomers.Text = "0";
            // 
            // lblUpdatedCustomers
            // 
            this.lblUpdatedCustomers.AutoSize = true;
            this.lblUpdatedCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedCustomers.Location = new System.Drawing.Point(255, 60);
            this.lblUpdatedCustomers.Name = "lblUpdatedCustomers";
            this.lblUpdatedCustomers.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedCustomers.TabIndex = 19;
            this.lblUpdatedCustomers.Text = "0";
            // 
            // lblInsertedCustomers
            // 
            this.lblInsertedCustomers.AutoSize = true;
            this.lblInsertedCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedCustomers.Location = new System.Drawing.Point(175, 60);
            this.lblInsertedCustomers.Name = "lblInsertedCustomers";
            this.lblInsertedCustomers.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedCustomers.TabIndex = 18;
            this.lblInsertedCustomers.Text = "0";
            // 
            // lblProductPrice
            // 
            this.lblProductPrice.AutoSize = true;
            this.lblProductPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductPrice.Location = new System.Drawing.Point(45, 504);
            this.lblProductPrice.Name = "lblProductPrice";
            this.lblProductPrice.Size = new System.Drawing.Size(84, 13);
            this.lblProductPrice.TabIndex = 17;
            this.lblProductPrice.Text = "Product Price";
            // 
            // lblPriceVersion
            // 
            this.lblPriceVersion.AutoSize = true;
            this.lblPriceVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceVersion.Location = new System.Drawing.Point(45, 478);
            this.lblPriceVersion.Name = "lblPriceVersion";
            this.lblPriceVersion.Size = new System.Drawing.Size(106, 13);
            this.lblPriceVersion.TabIndex = 16;
            this.lblPriceVersion.Text = "Price List Version";
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItems.Location = new System.Drawing.Point(45, 454);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(37, 13);
            this.lblItems.TabIndex = 15;
            this.lblItems.Text = "Items";
            // 
            // lblUOM
            // 
            this.lblUOM.AutoSize = true;
            this.lblUOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUOM.Location = new System.Drawing.Point(45, 430);
            this.lblUOM.Name = "lblUOM";
            this.lblUOM.Size = new System.Drawing.Size(125, 13);
            this.lblUOM.TabIndex = 14;
            this.lblUOM.Text = "Units Of Measurment";
            // 
            // lblCategories
            // 
            this.lblCategories.AutoSize = true;
            this.lblCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategories.Location = new System.Drawing.Point(45, 406);
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.Size = new System.Drawing.Size(67, 13);
            this.lblCategories.TabIndex = 13;
            this.lblCategories.Text = "Categories";
            // 
            // lblLocators
            // 
            this.lblLocators.AutoSize = true;
            this.lblLocators.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocators.Location = new System.Drawing.Point(45, 382);
            this.lblLocators.Name = "lblLocators";
            this.lblLocators.Size = new System.Drawing.Size(56, 13);
            this.lblLocators.TabIndex = 12;
            this.lblLocators.Text = "Locators";
            // 
            // lblOrganisation
            // 
            this.lblOrganisation.AutoSize = true;
            this.lblOrganisation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrganisation.Location = new System.Drawing.Point(45, 358);
            this.lblOrganisation.Name = "lblOrganisation";
            this.lblOrganisation.Size = new System.Drawing.Size(78, 13);
            this.lblOrganisation.TabIndex = 11;
            this.lblOrganisation.Text = "Organisation";
            // 
            // lblCompiereToPOS
            // 
            this.lblCompiereToPOS.AutoSize = true;
            this.lblCompiereToPOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompiereToPOS.Location = new System.Drawing.Point(8, 334);
            this.lblCompiereToPOS.Name = "lblCompiereToPOS";
            this.lblCompiereToPOS.Size = new System.Drawing.Size(113, 15);
            this.lblCompiereToPOS.TabIndex = 10;
            this.lblCompiereToPOS.Text = "CompiereToPOS";
            // 
            // lblOrderLines
            // 
            this.lblOrderLines.AutoSize = true;
            this.lblOrderLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderLines.Location = new System.Drawing.Point(35, 107);
            this.lblOrderLines.Name = "lblOrderLines";
            this.lblOrderLines.Size = new System.Drawing.Size(72, 13);
            this.lblOrderLines.TabIndex = 9;
            this.lblOrderLines.Text = "Order Lines";
            // 
            // lblOrders
            // 
            this.lblOrders.AutoSize = true;
            this.lblOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrders.Location = new System.Drawing.Point(35, 83);
            this.lblOrders.Name = "lblOrders";
            this.lblOrders.Size = new System.Drawing.Size(44, 13);
            this.lblOrders.TabIndex = 8;
            this.lblOrders.Text = "Orders";
            // 
            // lblCustomers
            // 
            this.lblCustomers.AutoSize = true;
            this.lblCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomers.Location = new System.Drawing.Point(35, 60);
            this.lblCustomers.Name = "lblCustomers";
            this.lblCustomers.Size = new System.Drawing.Size(65, 13);
            this.lblCustomers.TabIndex = 7;
            this.lblCustomers.Text = "Customers";
            // 
            // lblPOSToCompiere
            // 
            this.lblPOSToCompiere.AutoSize = true;
            this.lblPOSToCompiere.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPOSToCompiere.Location = new System.Drawing.Point(8, 36);
            this.lblPOSToCompiere.Name = "lblPOSToCompiere";
            this.lblPOSToCompiere.Size = new System.Drawing.Size(102, 15);
            this.lblPOSToCompiere.TabIndex = 6;
            this.lblPOSToCompiere.Text = "POS-Compiere";
            // 
            // lblScript
            // 
            this.lblScript.AutoSize = true;
            this.lblScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScript.Location = new System.Drawing.Point(540, 13);
            this.lblScript.Name = "lblScript";
            this.lblScript.Size = new System.Drawing.Size(66, 16);
            this.lblScript.TabIndex = 5;
            this.lblScript.Text = "Scripted";
            // 
            // lblWarnning
            // 
            this.lblWarnning.AutoSize = true;
            this.lblWarnning.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnning.Location = new System.Drawing.Point(460, 13);
            this.lblWarnning.Name = "lblWarnning";
            this.lblWarnning.Size = new System.Drawing.Size(81, 16);
            this.lblWarnning.TabIndex = 4;
            this.lblWarnning.Text = "Warnnings";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.Location = new System.Drawing.Point(387, 13);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(50, 16);
            this.lblError.TabIndex = 3;
            this.lblError.Text = "Errors";
            // 
            // lblDelete
            // 
            this.lblDelete.AutoSize = true;
            this.lblDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelete.Location = new System.Drawing.Point(314, 13);
            this.lblDelete.Name = "lblDelete";
            this.lblDelete.Size = new System.Drawing.Size(63, 16);
            this.lblDelete.TabIndex = 2;
            this.lblDelete.Text = "Deleted";
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdate.Location = new System.Drawing.Point(234, 13);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(59, 16);
            this.lblUpdate.TabIndex = 1;
            this.lblUpdate.Text = "Update";
            // 
            // lblInsert
            // 
            this.lblInsert.AutoSize = true;
            this.lblInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsert.Location = new System.Drawing.Point(154, 13);
            this.lblInsert.Name = "lblInsert";
            this.lblInsert.Size = new System.Drawing.Size(64, 16);
            this.lblInsert.TabIndex = 0;
            this.lblInsert.Text = "Inserted";
            // 
            // ntiTaskBarIcon
            // 
            this.ntiTaskBarIcon.ContextMenuStrip = this.cmnTaskBarkContexMenu;
            this.ntiTaskBarIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("ntiTaskBarIcon.Icon")));
            this.ntiTaskBarIcon.Text = "Pos Compiere Bridge";
            this.ntiTaskBarIcon.Visible = true;
            this.ntiTaskBarIcon.DoubleClick += new System.EventHandler(this.cmnuOpenControl_Click);
            // 
            // frmPosCompiereBridge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 561);
            this.Controls.Add(this.mnuMainMenu);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMainMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPosCompiereBridge";
            this.Text = "POS Bridge (v4.0a)";
            this.Load += new System.EventHandler(this.frmPosCompiereBridge_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPosCompiereBridge_FormClosing);
            this.mnuMainMenu.ResumeLayout(false);
            this.mnuMainMenu.PerformLayout();
            this.cmnTaskBarkContexMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMainMenu;
        private System.Windows.Forms.ToolStripMenuItem mnutask;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuStartSynch;
        private System.Windows.Forms.ToolStripMenuItem mnuStartPOSToCompiere;
        private System.Windows.Forms.ToolStripMenuItem mnuStartCompiereToPOS;
        private System.Windows.Forms.ToolStripMenuItem mnuStartBoth;
        private System.Windows.Forms.ToolStripMenuItem mnuStopSynch;
        private System.Windows.Forms.ToolStripMenuItem mnuStopPOSToCompiere;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuStopCompiereToPOS;
        private System.Windows.Forms.ToolStripMenuItem mnuStopBoth;
        private System.ComponentModel.BackgroundWorker bkwCompiereToPOSDataMapController;
        private System.ComponentModel.BackgroundWorker bkwPOSToCompiereDataMapController;
        private System.Windows.Forms.Timer tmrCompToPOSTimeSyncTimeController;
        private System.Windows.Forms.Timer tmrPOSTOCompTimeSyncTimeController;
        private System.Windows.Forms.ContextMenuStrip cmnTaskBarkContexMenu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblInsertedPriceListVersion;
        private System.Windows.Forms.Label lblInsertedItems;
        private System.Windows.Forms.Label lblInsertedUOM;
        private System.Windows.Forms.Label lblInsertedCategories;
        private System.Windows.Forms.Label lblInsertedLocators;
        private System.Windows.Forms.Label lblInsertedOrganistion;
        private System.Windows.Forms.Label lblInsertedOrderLines;
        private System.Windows.Forms.Label lblInsertedOrders;
        private System.Windows.Forms.Label lblScriptsOnCustomers;
        private System.Windows.Forms.Label lblWarnningOnCustomers;
        private System.Windows.Forms.Label lblErrorOnCustomers;
        private System.Windows.Forms.Label lblDeletedCustomers;
        private System.Windows.Forms.Label lblUpdatedCustomers;
        private System.Windows.Forms.Label lblInsertedCustomers;
        private System.Windows.Forms.Label lblProductPrice;
        private System.Windows.Forms.Label lblPriceVersion;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Label lblUOM;
        private System.Windows.Forms.Label lblCategories;
        private System.Windows.Forms.Label lblLocators;
        private System.Windows.Forms.Label lblOrganisation;
        private System.Windows.Forms.Label lblCompiereToPOS;
        private System.Windows.Forms.Label lblOrderLines;
        private System.Windows.Forms.Label lblOrders;
        private System.Windows.Forms.Label lblCustomers;
        private System.Windows.Forms.Label lblPOSToCompiere;
        private System.Windows.Forms.Label lblScript;
        private System.Windows.Forms.Label lblWarnning;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblDelete;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.Label lblInsert;
        private System.Windows.Forms.NotifyIcon ntiTaskBarIcon;
        private System.Windows.Forms.Label lblUpdatedOrders;
        private System.Windows.Forms.Label lblUpdatedOrderLines;
        private System.Windows.Forms.Label lblDeletedOrders;
        private System.Windows.Forms.Label lblDeletedOrderLines;
        private System.Windows.Forms.Label lblErrorOnOrders;
        private System.Windows.Forms.Label lblErrorOnOrderLines;
        private System.Windows.Forms.Label lblWarnningOnOrders;
        private System.Windows.Forms.Label lblWarnningOnOrderLines;
        private System.Windows.Forms.Label lblScriptsOnOrders;
        private System.Windows.Forms.Label lblScriptsOnOrderLines;
        private System.Windows.Forms.Label lblUpdatedOrganisation;
        private System.Windows.Forms.Label lblDeletedOrganisation;
        private System.Windows.Forms.Label lblErrorOnOrganisation;
        private System.Windows.Forms.Label lblWarnningOnOrganisation;
        private System.Windows.Forms.Label lblScriptsOnOrganisation;
        private System.Windows.Forms.Label lblUpdatedLocators;
        private System.Windows.Forms.Label lblDeletedLocators;
        private System.Windows.Forms.Label lblErrorOnLocators;
        private System.Windows.Forms.Label lblWarnningOnLocators;
        private System.Windows.Forms.Label lblScriptsOnLocators;
        private System.Windows.Forms.Label lblUpdatedCategory;
        private System.Windows.Forms.Label lblDeletedCategories;
        private System.Windows.Forms.Label lblErrorOnCategories;
        private System.Windows.Forms.Label lblWarnningOnCategories;
        private System.Windows.Forms.Label lblScriptsOnCategories;
        private System.Windows.Forms.Label lblUpdatedUOM;
        private System.Windows.Forms.Label lblDeletedUOM;
        private System.Windows.Forms.Label lblErrorOnUOM;
        private System.Windows.Forms.Label lblWarnningOnUOM;
        private System.Windows.Forms.Label lblScriptsOnUOM;
        private System.Windows.Forms.Label lblUpdatedItems;
        private System.Windows.Forms.Label lblDeletedItems;
        private System.Windows.Forms.Label lblErrorOnItems;
        private System.Windows.Forms.Label lblWarnningOnItems;
        private System.Windows.Forms.Label lblScriptsOnItems;
        private System.Windows.Forms.Label lblUpdatedPriceListVersion;
        private System.Windows.Forms.Label lblDeletedPriceListVersion;
        private System.Windows.Forms.Label lblErrorOnPriceListVersion;
        private System.Windows.Forms.Label lblWarnningOnPriceListVersion;
        private System.Windows.Forms.Label lblScriptsOnPriceListVersion;
        private System.Windows.Forms.Label lblUpdatedProductPrice;
        private System.Windows.Forms.Label lblDeletedProductPrice;
        private System.Windows.Forms.Label lblErrorOnProductPrice;
        private System.Windows.Forms.Label lblWarnningOnProductPrice;
        private System.Windows.Forms.Label lblScriptsOnProductPrice;
        private System.Windows.Forms.Label lblInsertedProductPrice;
        private System.Windows.Forms.Label lblPosCompiereStatus;
        private System.Windows.Forms.Label lblCompierePOSStartTime;
        private System.Windows.Forms.Label lblCompierePOSStatus;
        private System.Windows.Forms.Label lblPosCompiereStartTime;
        private System.Windows.Forms.ToolStripMenuItem cmnuOpenControl;
        private System.Windows.Forms.ToolStripMenuItem cmnuStartSynch;
        private System.Windows.Forms.ToolStripMenuItem cmnuStopSynch;
        private System.Windows.Forms.ToolStripMenuItem cmnuExit;
        private System.Windows.Forms.ToolStripMenuItem cmnuStartPOStoCompiere;
        private System.Windows.Forms.ToolStripMenuItem cmnuStartCompiereToPOS;
        private System.Windows.Forms.ToolStripMenuItem cmnuStartBoth;
        private System.Windows.Forms.ToolStripMenuItem cmnuStopPOStoCompiere;
        private System.Windows.Forms.ToolStripMenuItem cmnuStopCompiereToPOS;
        private System.Windows.Forms.ToolStripMenuItem cmnuStopBoth;
        private System.Windows.Forms.ToolStripMenuItem mnuCleanChangeSequece;
        private System.Windows.Forms.ToolStripMenuItem mnuCleanPOSSequence;
        private System.Windows.Forms.ToolStripMenuItem mnuCleanCompiereSequence;
        private System.Windows.Forms.Label lblUpdatedExemptionsLine;
        private System.Windows.Forms.Label lblUpdatedPayments;
        private System.Windows.Forms.Label lblDeletedExemptionsLine;
        private System.Windows.Forms.Label lblDeletedPayments;
        private System.Windows.Forms.Label lblErrorOnExemptionLine;
        private System.Windows.Forms.Label lblErrorOnPayments;
        private System.Windows.Forms.Label lblWarnningOnExemptionsLine;
        private System.Windows.Forms.Label lblWarnningOnPayments;
        private System.Windows.Forms.Label lblScriptsOnExemptionsLine;
        private System.Windows.Forms.Label lblScriptsOnPayments;
        private System.Windows.Forms.Label lblInsertedPayments;
        private System.Windows.Forms.Label lblInsertedExemptionLine;
        private System.Windows.Forms.Label lblScriptsOnExemptions;
        private System.Windows.Forms.Label lblWarnningOnExemptions;
        private System.Windows.Forms.Label lblErrorOnExemptions;
        private System.Windows.Forms.Label lblDeletedExemptions;
        private System.Windows.Forms.Label lblUpdatedExemptions;
        private System.Windows.Forms.Label lblInsertedExemptions;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.Label lblExemptionLine;
        private System.Windows.Forms.Label lblExemptions;
        private System.Windows.Forms.Label lblUpdatedCash;
        private System.Windows.Forms.Label lblUpdatedCashLine;
        private System.Windows.Forms.Label lblDeletedCash;
        private System.Windows.Forms.Label lblDeletedCashLine;
        private System.Windows.Forms.Label lblErrorOnCash;
        private System.Windows.Forms.Label lblErrorOnCashLine;
        private System.Windows.Forms.Label lblWarnningOnCash;
        private System.Windows.Forms.Label lblWarnningOnCashLine;
        private System.Windows.Forms.Label lblScriptsOnCash;
        private System.Windows.Forms.Label lblScriptsOnCashLine;
        private System.Windows.Forms.Label lblInsertedCashLine;
        private System.Windows.Forms.Label lblInsertedCash;
        private System.Windows.Forms.Label lblCashLine;
        private System.Windows.Forms.Label lblCash;
        private System.Windows.Forms.Label lblUpdatedAllocations;
        private System.Windows.Forms.Label lblUpdatedAllocationLines;
        private System.Windows.Forms.Label lblDeletedAllocations;
        private System.Windows.Forms.Label lblDeletedAllocationLines;
        private System.Windows.Forms.Label lblErrorOnAllocations;
        private System.Windows.Forms.Label lblErrorOnAllocationLines;
        private System.Windows.Forms.Label lblWarnningOnAllocations;
        private System.Windows.Forms.Label lblWarnningOnAllocationLines;
        private System.Windows.Forms.Label lblScriptsOnAllocations;
        private System.Windows.Forms.Label lblScriptsOnAllocationLines;
        private System.Windows.Forms.Label lblInsertedAllocationLines;
        private System.Windows.Forms.Label lblInsertedAllocations;
        private System.Windows.Forms.Label lblScriptsOnPaymentLines;
        private System.Windows.Forms.Label lblWarnningOnPaymentLines;
        private System.Windows.Forms.Label lblErrorOnPaymentLines;
        private System.Windows.Forms.Label lblDeletedPaymentLines;
        private System.Windows.Forms.Label lblUpdatedPaymentLines;
        private System.Windows.Forms.Label lblInsertedPaymentLines;
        private System.Windows.Forms.Label lblAllocationLine;
        private System.Windows.Forms.Label lblAllocation;
        private System.Windows.Forms.Label lblPaymentlines;
    }
}

