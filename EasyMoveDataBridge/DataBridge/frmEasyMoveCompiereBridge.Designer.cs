namespace EasyMoveDataBridge
{
    partial class frmEasyMoveCompiereBridge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEasyMoveCompiereBridge));
            this.mnuMainMenu = new System.Windows.Forms.MenuStrip();
            this.mnutask = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStartSynch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStartEasyMoveToCompiere = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStartCompiereToEasyMove = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStartBoth = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStopSynch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStopEasyMoveToCompiere = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStopCompiereToEasyMove = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStopBoth = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCleanChangeSequence = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCleanEasyMoveSequecnce = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCleanCompiereSequence = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.bkwCompiereToEasyMoveDataMapController = new System.ComponentModel.BackgroundWorker();
            this.bkwEasyMoveToCompiereDataMapController = new System.ComponentModel.BackgroundWorker();
            this.tmrCompToEasyMoveTimeSyncTimeController = new System.Windows.Forms.Timer(this.components);
            this.tmrEasyMoveTOCompTimeSyncTimeController = new System.Windows.Forms.Timer(this.components);
            this.cmnTaskBarkContexMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuOpenControl = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuStartSynch = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuStartEasyMovetoCompiere = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuStartCompiereToEasyMove = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuStartBoth = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuStopSynch = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuStopEasyMovetoCompiere = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuStopCompiereToEasyMove = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuStopBoth = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblUpdatedProductionLine = new System.Windows.Forms.Label();
            this.lblUpdatedProductionPlan = new System.Windows.Forms.Label();
            this.lblUpdatedInOutLine = new System.Windows.Forms.Label();
            this.lblDeletedProductionLine = new System.Windows.Forms.Label();
            this.lblDeletedProductionPlan = new System.Windows.Forms.Label();
            this.lblDeletedInOutLine = new System.Windows.Forms.Label();
            this.lblErrorOnProductionLine = new System.Windows.Forms.Label();
            this.lblErrorOnProductionPlan = new System.Windows.Forms.Label();
            this.lblErrorOnInOutLine = new System.Windows.Forms.Label();
            this.lblWarnningOnProductionLine = new System.Windows.Forms.Label();
            this.lblWarnningOnProductionPlan = new System.Windows.Forms.Label();
            this.lblWarnningOnInOutLine = new System.Windows.Forms.Label();
            this.lblScriptsOnProductionLine = new System.Windows.Forms.Label();
            this.lblScriptsOnProductionPlan = new System.Windows.Forms.Label();
            this.lblScriptsOnInOutLine = new System.Windows.Forms.Label();
            this.lblInsertedProductionLine = new System.Windows.Forms.Label();
            this.lblInsertedProductionPlan = new System.Windows.Forms.Label();
            this.lblInsertedInOutLine = new System.Windows.Forms.Label();
            this.lblScriptsOnProduction = new System.Windows.Forms.Label();
            this.lblScriptsOnInOut = new System.Windows.Forms.Label();
            this.lblWarnningOnProduction = new System.Windows.Forms.Label();
            this.lblWarnningOnInOut = new System.Windows.Forms.Label();
            this.lblErrorOnProduction = new System.Windows.Forms.Label();
            this.lblErrorOnInOut = new System.Windows.Forms.Label();
            this.lblDeletedProduction = new System.Windows.Forms.Label();
            this.lblDeletedInOut = new System.Windows.Forms.Label();
            this.lblUpdatedProduction = new System.Windows.Forms.Label();
            this.lblUpdatedInOut = new System.Windows.Forms.Label();
            this.lblInsertedProduction = new System.Windows.Forms.Label();
            this.lblInsertedInOut = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInOutLine = new System.Windows.Forms.Label();
            this.lblInOut = new System.Windows.Forms.Label();
            this.lblCompiereEasyMoveStartTime = new System.Windows.Forms.Label();
            this.lblCompiereEasyMoveStatus = new System.Windows.Forms.Label();
            this.lblEasyMoveCompiereStartTime = new System.Windows.Forms.Label();
            this.lblUpdatedMovementLine = new System.Windows.Forms.Label();
            this.lblUpdatedClient = new System.Windows.Forms.Label();
            this.lblDeletedMovementLine = new System.Windows.Forms.Label();
            this.lblDeletedClient = new System.Windows.Forms.Label();
            this.lblErrorOnMovementLine = new System.Windows.Forms.Label();
            this.lblErrorOnClient = new System.Windows.Forms.Label();
            this.lblWarnningOnMovementLine = new System.Windows.Forms.Label();
            this.lblWarnningOnClient = new System.Windows.Forms.Label();
            this.lblScriptsOnMovementLine = new System.Windows.Forms.Label();
            this.lblScriptsOnClient = new System.Windows.Forms.Label();
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
            this.lblUpdatedBOMs = new System.Windows.Forms.Label();
            this.lblUpdatedItems = new System.Windows.Forms.Label();
            this.lblDeletedBOMs = new System.Windows.Forms.Label();
            this.lblDeletedItems = new System.Windows.Forms.Label();
            this.lblErrorOnBOMs = new System.Windows.Forms.Label();
            this.lblErrorOnItems = new System.Windows.Forms.Label();
            this.lblWarnningOnBOMs = new System.Windows.Forms.Label();
            this.lblWarnningOnItems = new System.Windows.Forms.Label();
            this.lblScriptsOnBOMs = new System.Windows.Forms.Label();
            this.lblScriptsOnItems = new System.Windows.Forms.Label();
            this.lblUpdatedWarehouse = new System.Windows.Forms.Label();
            this.lblUpdatedUser = new System.Windows.Forms.Label();
            this.lblDeletedWarehouse = new System.Windows.Forms.Label();
            this.lblDeletedUser = new System.Windows.Forms.Label();
            this.lblErrorOnWarehouse = new System.Windows.Forms.Label();
            this.lblErrorOnUser = new System.Windows.Forms.Label();
            this.lblWarnningOnWarehouse = new System.Windows.Forms.Label();
            this.lblWarnningOnUser = new System.Windows.Forms.Label();
            this.lblScriptsOnWarehouse = new System.Windows.Forms.Label();
            this.lblScriptsOnUser = new System.Windows.Forms.Label();
            this.lblUpdatedDocumentType = new System.Windows.Forms.Label();
            this.lblUpdatedUserOrgAccess = new System.Windows.Forms.Label();
            this.lblDeletedDocumentType = new System.Windows.Forms.Label();
            this.lblDeletedUserOrgAccess = new System.Windows.Forms.Label();
            this.lblErrorOnDocumentType = new System.Windows.Forms.Label();
            this.lblErrorOnUserOrgAccess = new System.Windows.Forms.Label();
            this.lblWarnningOnDocumentType = new System.Windows.Forms.Label();
            this.lblWarnningOnUserOrgAccess = new System.Windows.Forms.Label();
            this.lblScriptsOnDocumentType = new System.Windows.Forms.Label();
            this.lblScriptsOnUserOrgAccess = new System.Windows.Forms.Label();
            this.lblInsertedDocumentType = new System.Windows.Forms.Label();
            this.lblInsertedUserOrgAccess = new System.Windows.Forms.Label();
            this.lblEasyMoveCompiereStatus = new System.Windows.Forms.Label();
            this.lblInsertedWarehouse = new System.Windows.Forms.Label();
            this.lblInsertedUser = new System.Windows.Forms.Label();
            this.lblInsertedBOMs = new System.Windows.Forms.Label();
            this.lblInsertedItems = new System.Windows.Forms.Label();
            this.lblInsertedUOM = new System.Windows.Forms.Label();
            this.lblInsertedCategories = new System.Windows.Forms.Label();
            this.lblInsertedLocators = new System.Windows.Forms.Label();
            this.lblInsertedOrganistion = new System.Windows.Forms.Label();
            this.lblInsertedClient = new System.Windows.Forms.Label();
            this.lblInsertedMovementLine = new System.Windows.Forms.Label();
            this.lblScriptsOnMovement = new System.Windows.Forms.Label();
            this.lblWarnningOnMovement = new System.Windows.Forms.Label();
            this.lblErrorOnMovement = new System.Windows.Forms.Label();
            this.lblDeletedMovement = new System.Windows.Forms.Label();
            this.lblUpdatedMovement = new System.Windows.Forms.Label();
            this.lblInsertedMovement = new System.Windows.Forms.Label();
            this.lblDocumentType = new System.Windows.Forms.Label();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.lblUserOrgAccess = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblBOM = new System.Windows.Forms.Label();
            this.lblItems = new System.Windows.Forms.Label();
            this.lblUOM = new System.Windows.Forms.Label();
            this.lblCategories = new System.Windows.Forms.Label();
            this.lblLocators = new System.Windows.Forms.Label();
            this.lblOrganisation = new System.Windows.Forms.Label();
            this.lblCompiereToEsayMove = new System.Windows.Forms.Label();
            this.lblOrderLines = new System.Windows.Forms.Label();
            this.lblMovementLine = new System.Windows.Forms.Label();
            this.lblMovement = new System.Windows.Forms.Label();
            this.lblEsayMoveToCompiere = new System.Windows.Forms.Label();
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
            this.mnuMainMenu.Size = new System.Drawing.Size(603, 24);
            this.mnuMainMenu.TabIndex = 1;
            this.mnuMainMenu.Text = "menuStrip1";
            // 
            // mnutask
            // 
            this.mnutask.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSettings,
            this.mnuStartSynch,
            this.mnuStopSynch,
            this.mnuCleanChangeSequence,
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
            this.mnuStartEasyMoveToCompiere,
            this.mnuStartCompiereToEasyMove,
            this.mnuStartBoth});
            this.mnuStartSynch.Name = "mnuStartSynch";
            this.mnuStartSynch.Size = new System.Drawing.Size(202, 22);
            this.mnuStartSynch.Text = "Start Synch";
            // 
            // mnuStartEasyMoveToCompiere
            // 
            this.mnuStartEasyMoveToCompiere.Name = "mnuStartEasyMoveToCompiere";
            this.mnuStartEasyMoveToCompiere.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuStartEasyMoveToCompiere.Size = new System.Drawing.Size(264, 22);
            this.mnuStartEasyMoveToCompiere.Text = "EasyMove to Compiere";
            this.mnuStartEasyMoveToCompiere.Click += new System.EventHandler(this.mnuStartEasyMoveToCompiere_Click);
            // 
            // mnuStartCompiereToEasyMove
            // 
            this.mnuStartCompiereToEasyMove.Name = "mnuStartCompiereToEasyMove";
            this.mnuStartCompiereToEasyMove.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.C)));
            this.mnuStartCompiereToEasyMove.Size = new System.Drawing.Size(264, 22);
            this.mnuStartCompiereToEasyMove.Text = "Compiere to EasyMove";
            this.mnuStartCompiereToEasyMove.Click += new System.EventHandler(this.mnuStartCompiereToEasyMove_Click);
            // 
            // mnuStartBoth
            // 
            this.mnuStartBoth.Name = "mnuStartBoth";
            this.mnuStartBoth.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.B)));
            this.mnuStartBoth.Size = new System.Drawing.Size(264, 22);
            this.mnuStartBoth.Text = "Both";
            this.mnuStartBoth.Click += new System.EventHandler(this.mnuStartBoth_Click);
            // 
            // mnuStopSynch
            // 
            this.mnuStopSynch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStopEasyMoveToCompiere,
            this.mnuStopCompiereToEasyMove,
            this.mnuStopBoth});
            this.mnuStopSynch.Name = "mnuStopSynch";
            this.mnuStopSynch.Size = new System.Drawing.Size(202, 22);
            this.mnuStopSynch.Text = "Stop Synch";
            // 
            // mnuStopEasyMoveToCompiere
            // 
            this.mnuStopEasyMoveToCompiere.Name = "mnuStopEasyMoveToCompiere";
            this.mnuStopEasyMoveToCompiere.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.mnuStopEasyMoveToCompiere.Size = new System.Drawing.Size(260, 22);
            this.mnuStopEasyMoveToCompiere.Text = "EasyMove to Compiere";
            this.mnuStopEasyMoveToCompiere.Click += new System.EventHandler(this.mnuStopEasyMoveToCompiere_Click);
            // 
            // mnuStopCompiereToEasyMove
            // 
            this.mnuStopCompiereToEasyMove.Name = "mnuStopCompiereToEasyMove";
            this.mnuStopCompiereToEasyMove.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.C)));
            this.mnuStopCompiereToEasyMove.Size = new System.Drawing.Size(260, 22);
            this.mnuStopCompiereToEasyMove.Text = "Compiere to EasyMove";
            this.mnuStopCompiereToEasyMove.Click += new System.EventHandler(this.mnuStopCompiereToEasyMove_Click);
            // 
            // mnuStopBoth
            // 
            this.mnuStopBoth.Name = "mnuStopBoth";
            this.mnuStopBoth.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.B)));
            this.mnuStopBoth.Size = new System.Drawing.Size(260, 22);
            this.mnuStopBoth.Text = "Both";
            this.mnuStopBoth.Click += new System.EventHandler(this.mnuStopBoth_Click);
            // 
            // mnuCleanChangeSequence
            // 
            this.mnuCleanChangeSequence.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCleanEasyMoveSequecnce,
            this.mnuCleanCompiereSequence});
            this.mnuCleanChangeSequence.Name = "mnuCleanChangeSequence";
            this.mnuCleanChangeSequence.Size = new System.Drawing.Size(202, 22);
            this.mnuCleanChangeSequence.Text = "Clean Change Sequence";
            // 
            // mnuCleanEasyMoveSequecnce
            // 
            this.mnuCleanEasyMoveSequecnce.Name = "mnuCleanEasyMoveSequecnce";
            this.mnuCleanEasyMoveSequecnce.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.Delete)));
            this.mnuCleanEasyMoveSequecnce.Size = new System.Drawing.Size(266, 22);
            this.mnuCleanEasyMoveSequecnce.Text = "EasyMove Sequecnce";
            this.mnuCleanEasyMoveSequecnce.Click += new System.EventHandler(this.mnuCleanEasyMoveSequecnce_Click);
            // 
            // mnuCleanCompiereSequence
            // 
            this.mnuCleanCompiereSequence.Name = "mnuCleanCompiereSequence";
            this.mnuCleanCompiereSequence.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.Delete)));
            this.mnuCleanCompiereSequence.Size = new System.Drawing.Size(266, 22);
            this.mnuCleanCompiereSequence.Text = "Compiere Sequence";
            this.mnuCleanCompiereSequence.Click += new System.EventHandler(this.mnuCleanCompiereSequence_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(202, 22);
            this.mnuExit.Text = "&Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // bkwCompiereToEasyMoveDataMapController
            // 
            this.bkwCompiereToEasyMoveDataMapController.WorkerReportsProgress = true;
            this.bkwCompiereToEasyMoveDataMapController.WorkerSupportsCancellation = true;
            this.bkwCompiereToEasyMoveDataMapController.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkwCompiereToEasyMoveDataMapController_DoWork);
            this.bkwCompiereToEasyMoveDataMapController.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bkwCompiereToEasyMoveDataMapController_RunWorkerCompleted);
            this.bkwCompiereToEasyMoveDataMapController.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bkwCompiereToEasyMoveDataMapController_ProgressChanged);
            // 
            // bkwEasyMoveToCompiereDataMapController
            // 
            this.bkwEasyMoveToCompiereDataMapController.WorkerReportsProgress = true;
            this.bkwEasyMoveToCompiereDataMapController.WorkerSupportsCancellation = true;
            this.bkwEasyMoveToCompiereDataMapController.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkwEasyMoveToCompiereDataMapController_DoWork);
            this.bkwEasyMoveToCompiereDataMapController.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bkwEasyMoveToCompiereDataMapController_RunWorkerCompleted);
            this.bkwEasyMoveToCompiereDataMapController.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bkwEasyMoveToCompiereDataMapController_ProgressChanged);
            // 
            // tmrCompToEasyMoveTimeSyncTimeController
            // 
            this.tmrCompToEasyMoveTimeSyncTimeController.Tick += new System.EventHandler(this.tmrCompToEasyMoveTimeSyncTimeController_Tick);
            // 
            // tmrEasyMoveTOCompTimeSyncTimeController
            // 
            this.tmrEasyMoveTOCompTimeSyncTimeController.Tick += new System.EventHandler(this.tmrEasyMoveTOCompTimeSyncTimeController_Tick);
            // 
            // cmnTaskBarkContexMenu
            // 
            this.cmnTaskBarkContexMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuOpenControl,
            this.cmnuStartSynch,
            this.cmnuStopSynch,
            this.cmnuExit});
            this.cmnTaskBarkContexMenu.Name = "contextMenuStrip1";
            this.cmnTaskBarkContexMenu.Size = new System.Drawing.Size(159, 92);
            // 
            // cmnuOpenControl
            // 
            this.cmnuOpenControl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmnuOpenControl.Name = "cmnuOpenControl";
            this.cmnuOpenControl.Size = new System.Drawing.Size(158, 22);
            this.cmnuOpenControl.Text = "&Open Control";
            this.cmnuOpenControl.Click += new System.EventHandler(this.cmnuOpenControl_Click);
            // 
            // cmnuStartSynch
            // 
            this.cmnuStartSynch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuStartEasyMovetoCompiere,
            this.cmnuStartCompiereToEasyMove,
            this.cmnuStartBoth});
            this.cmnuStartSynch.Name = "cmnuStartSynch";
            this.cmnuStartSynch.Size = new System.Drawing.Size(158, 22);
            this.cmnuStartSynch.Text = "Start Synch";
            // 
            // cmnuStartEasyMovetoCompiere
            // 
            this.cmnuStartEasyMovetoCompiere.Name = "cmnuStartEasyMovetoCompiere";
            this.cmnuStartEasyMovetoCompiere.Size = new System.Drawing.Size(183, 22);
            this.cmnuStartEasyMovetoCompiere.Text = "EasyMove-Compiere";
            this.cmnuStartEasyMovetoCompiere.Click += new System.EventHandler(this.cmnuStartEasyMovetoCompiere_Click);
            // 
            // cmnuStartCompiereToEasyMove
            // 
            this.cmnuStartCompiereToEasyMove.Name = "cmnuStartCompiereToEasyMove";
            this.cmnuStartCompiereToEasyMove.Size = new System.Drawing.Size(183, 22);
            this.cmnuStartCompiereToEasyMove.Text = "Compiere-EasyMove";
            this.cmnuStartCompiereToEasyMove.Click += new System.EventHandler(this.cmnuStartCompiereToEasyMove_Click);
            // 
            // cmnuStartBoth
            // 
            this.cmnuStartBoth.Name = "cmnuStartBoth";
            this.cmnuStartBoth.Size = new System.Drawing.Size(183, 22);
            this.cmnuStartBoth.Text = "Both";
            this.cmnuStartBoth.Click += new System.EventHandler(this.cmnuStartBoth_Click);
            // 
            // cmnuStopSynch
            // 
            this.cmnuStopSynch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuStopEasyMovetoCompiere,
            this.cmnuStopCompiereToEasyMove,
            this.cmnuStopBoth});
            this.cmnuStopSynch.Name = "cmnuStopSynch";
            this.cmnuStopSynch.Size = new System.Drawing.Size(158, 22);
            this.cmnuStopSynch.Text = "Stop Synch";
            // 
            // cmnuStopEasyMovetoCompiere
            // 
            this.cmnuStopEasyMovetoCompiere.Name = "cmnuStopEasyMovetoCompiere";
            this.cmnuStopEasyMovetoCompiere.Size = new System.Drawing.Size(183, 22);
            this.cmnuStopEasyMovetoCompiere.Text = "EasyMove-Compiere";
            this.cmnuStopEasyMovetoCompiere.Click += new System.EventHandler(this.cmnuStopEasyMovetoCompiere_Click);
            // 
            // cmnuStopCompiereToEasyMove
            // 
            this.cmnuStopCompiereToEasyMove.Name = "cmnuStopCompiereToEasyMove";
            this.cmnuStopCompiereToEasyMove.Size = new System.Drawing.Size(183, 22);
            this.cmnuStopCompiereToEasyMove.Text = "Compiere-EasyMove";
            this.cmnuStopCompiereToEasyMove.Click += new System.EventHandler(this.cmnuStopCompiereToEasyMove_Click);
            // 
            // cmnuStopBoth
            // 
            this.cmnuStopBoth.Name = "cmnuStopBoth";
            this.cmnuStopBoth.Size = new System.Drawing.Size(183, 22);
            this.cmnuStopBoth.Text = "Both";
            this.cmnuStopBoth.Click += new System.EventHandler(this.cmnuStopBoth_Click);
            // 
            // cmnuExit
            // 
            this.cmnuExit.Name = "cmnuExit";
            this.cmnuExit.Size = new System.Drawing.Size(158, 22);
            this.cmnuExit.Text = "Exit";
            this.cmnuExit.Click += new System.EventHandler(this.cmnuExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblUpdatedProductionLine);
            this.groupBox1.Controls.Add(this.lblUpdatedProductionPlan);
            this.groupBox1.Controls.Add(this.lblUpdatedInOutLine);
            this.groupBox1.Controls.Add(this.lblDeletedProductionLine);
            this.groupBox1.Controls.Add(this.lblDeletedProductionPlan);
            this.groupBox1.Controls.Add(this.lblDeletedInOutLine);
            this.groupBox1.Controls.Add(this.lblErrorOnProductionLine);
            this.groupBox1.Controls.Add(this.lblErrorOnProductionPlan);
            this.groupBox1.Controls.Add(this.lblErrorOnInOutLine);
            this.groupBox1.Controls.Add(this.lblWarnningOnProductionLine);
            this.groupBox1.Controls.Add(this.lblWarnningOnProductionPlan);
            this.groupBox1.Controls.Add(this.lblWarnningOnInOutLine);
            this.groupBox1.Controls.Add(this.lblScriptsOnProductionLine);
            this.groupBox1.Controls.Add(this.lblScriptsOnProductionPlan);
            this.groupBox1.Controls.Add(this.lblScriptsOnInOutLine);
            this.groupBox1.Controls.Add(this.lblInsertedProductionLine);
            this.groupBox1.Controls.Add(this.lblInsertedProductionPlan);
            this.groupBox1.Controls.Add(this.lblInsertedInOutLine);
            this.groupBox1.Controls.Add(this.lblScriptsOnProduction);
            this.groupBox1.Controls.Add(this.lblScriptsOnInOut);
            this.groupBox1.Controls.Add(this.lblWarnningOnProduction);
            this.groupBox1.Controls.Add(this.lblWarnningOnInOut);
            this.groupBox1.Controls.Add(this.lblErrorOnProduction);
            this.groupBox1.Controls.Add(this.lblErrorOnInOut);
            this.groupBox1.Controls.Add(this.lblDeletedProduction);
            this.groupBox1.Controls.Add(this.lblDeletedInOut);
            this.groupBox1.Controls.Add(this.lblUpdatedProduction);
            this.groupBox1.Controls.Add(this.lblUpdatedInOut);
            this.groupBox1.Controls.Add(this.lblInsertedProduction);
            this.groupBox1.Controls.Add(this.lblInsertedInOut);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblInOutLine);
            this.groupBox1.Controls.Add(this.lblInOut);
            this.groupBox1.Controls.Add(this.lblCompiereEasyMoveStartTime);
            this.groupBox1.Controls.Add(this.lblCompiereEasyMoveStatus);
            this.groupBox1.Controls.Add(this.lblEasyMoveCompiereStartTime);
            this.groupBox1.Controls.Add(this.lblUpdatedMovementLine);
            this.groupBox1.Controls.Add(this.lblUpdatedClient);
            this.groupBox1.Controls.Add(this.lblDeletedMovementLine);
            this.groupBox1.Controls.Add(this.lblDeletedClient);
            this.groupBox1.Controls.Add(this.lblErrorOnMovementLine);
            this.groupBox1.Controls.Add(this.lblErrorOnClient);
            this.groupBox1.Controls.Add(this.lblWarnningOnMovementLine);
            this.groupBox1.Controls.Add(this.lblWarnningOnClient);
            this.groupBox1.Controls.Add(this.lblScriptsOnMovementLine);
            this.groupBox1.Controls.Add(this.lblScriptsOnClient);
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
            this.groupBox1.Controls.Add(this.lblUpdatedBOMs);
            this.groupBox1.Controls.Add(this.lblUpdatedItems);
            this.groupBox1.Controls.Add(this.lblDeletedBOMs);
            this.groupBox1.Controls.Add(this.lblDeletedItems);
            this.groupBox1.Controls.Add(this.lblErrorOnBOMs);
            this.groupBox1.Controls.Add(this.lblErrorOnItems);
            this.groupBox1.Controls.Add(this.lblWarnningOnBOMs);
            this.groupBox1.Controls.Add(this.lblWarnningOnItems);
            this.groupBox1.Controls.Add(this.lblScriptsOnBOMs);
            this.groupBox1.Controls.Add(this.lblScriptsOnItems);
            this.groupBox1.Controls.Add(this.lblUpdatedWarehouse);
            this.groupBox1.Controls.Add(this.lblUpdatedUser);
            this.groupBox1.Controls.Add(this.lblDeletedWarehouse);
            this.groupBox1.Controls.Add(this.lblDeletedUser);
            this.groupBox1.Controls.Add(this.lblErrorOnWarehouse);
            this.groupBox1.Controls.Add(this.lblErrorOnUser);
            this.groupBox1.Controls.Add(this.lblWarnningOnWarehouse);
            this.groupBox1.Controls.Add(this.lblWarnningOnUser);
            this.groupBox1.Controls.Add(this.lblScriptsOnWarehouse);
            this.groupBox1.Controls.Add(this.lblScriptsOnUser);
            this.groupBox1.Controls.Add(this.lblUpdatedDocumentType);
            this.groupBox1.Controls.Add(this.lblUpdatedUserOrgAccess);
            this.groupBox1.Controls.Add(this.lblDeletedDocumentType);
            this.groupBox1.Controls.Add(this.lblDeletedUserOrgAccess);
            this.groupBox1.Controls.Add(this.lblErrorOnDocumentType);
            this.groupBox1.Controls.Add(this.lblErrorOnUserOrgAccess);
            this.groupBox1.Controls.Add(this.lblWarnningOnDocumentType);
            this.groupBox1.Controls.Add(this.lblWarnningOnUserOrgAccess);
            this.groupBox1.Controls.Add(this.lblScriptsOnDocumentType);
            this.groupBox1.Controls.Add(this.lblScriptsOnUserOrgAccess);
            this.groupBox1.Controls.Add(this.lblInsertedDocumentType);
            this.groupBox1.Controls.Add(this.lblInsertedUserOrgAccess);
            this.groupBox1.Controls.Add(this.lblEasyMoveCompiereStatus);
            this.groupBox1.Controls.Add(this.lblInsertedWarehouse);
            this.groupBox1.Controls.Add(this.lblInsertedUser);
            this.groupBox1.Controls.Add(this.lblInsertedBOMs);
            this.groupBox1.Controls.Add(this.lblInsertedItems);
            this.groupBox1.Controls.Add(this.lblInsertedUOM);
            this.groupBox1.Controls.Add(this.lblInsertedCategories);
            this.groupBox1.Controls.Add(this.lblInsertedLocators);
            this.groupBox1.Controls.Add(this.lblInsertedOrganistion);
            this.groupBox1.Controls.Add(this.lblInsertedClient);
            this.groupBox1.Controls.Add(this.lblInsertedMovementLine);
            this.groupBox1.Controls.Add(this.lblScriptsOnMovement);
            this.groupBox1.Controls.Add(this.lblWarnningOnMovement);
            this.groupBox1.Controls.Add(this.lblErrorOnMovement);
            this.groupBox1.Controls.Add(this.lblDeletedMovement);
            this.groupBox1.Controls.Add(this.lblUpdatedMovement);
            this.groupBox1.Controls.Add(this.lblInsertedMovement);
            this.groupBox1.Controls.Add(this.lblDocumentType);
            this.groupBox1.Controls.Add(this.lblWarehouse);
            this.groupBox1.Controls.Add(this.lblUserOrgAccess);
            this.groupBox1.Controls.Add(this.lblUser);
            this.groupBox1.Controls.Add(this.lblBOM);
            this.groupBox1.Controls.Add(this.lblItems);
            this.groupBox1.Controls.Add(this.lblUOM);
            this.groupBox1.Controls.Add(this.lblCategories);
            this.groupBox1.Controls.Add(this.lblLocators);
            this.groupBox1.Controls.Add(this.lblOrganisation);
            this.groupBox1.Controls.Add(this.lblCompiereToEsayMove);
            this.groupBox1.Controls.Add(this.lblOrderLines);
            this.groupBox1.Controls.Add(this.lblMovementLine);
            this.groupBox1.Controls.Add(this.lblMovement);
            this.groupBox1.Controls.Add(this.lblEsayMoveToCompiere);
            this.groupBox1.Controls.Add(this.lblScript);
            this.groupBox1.Controls.Add(this.lblWarnning);
            this.groupBox1.Controls.Add(this.lblError);
            this.groupBox1.Controls.Add(this.lblDelete);
            this.groupBox1.Controls.Add(this.lblUpdate);
            this.groupBox1.Controls.Add(this.lblInsert);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(601, 525);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // lblUpdatedProductionLine
            // 
            this.lblUpdatedProductionLine.AutoSize = true;
            this.lblUpdatedProductionLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedProductionLine.Location = new System.Drawing.Point(255, 197);
            this.lblUpdatedProductionLine.Name = "lblUpdatedProductionLine";
            this.lblUpdatedProductionLine.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedProductionLine.TabIndex = 94;
            this.lblUpdatedProductionLine.Text = "0";
            // 
            // lblUpdatedProductionPlan
            // 
            this.lblUpdatedProductionPlan.AutoSize = true;
            this.lblUpdatedProductionPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedProductionPlan.Location = new System.Drawing.Point(255, 173);
            this.lblUpdatedProductionPlan.Name = "lblUpdatedProductionPlan";
            this.lblUpdatedProductionPlan.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedProductionPlan.TabIndex = 94;
            this.lblUpdatedProductionPlan.Text = "0";
            // 
            // lblUpdatedInOutLine
            // 
            this.lblUpdatedInOutLine.AutoSize = true;
            this.lblUpdatedInOutLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedInOutLine.Location = new System.Drawing.Point(255, 127);
            this.lblUpdatedInOutLine.Name = "lblUpdatedInOutLine";
            this.lblUpdatedInOutLine.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedInOutLine.TabIndex = 94;
            this.lblUpdatedInOutLine.Text = "0";
            // 
            // lblDeletedProductionLine
            // 
            this.lblDeletedProductionLine.AutoSize = true;
            this.lblDeletedProductionLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedProductionLine.Location = new System.Drawing.Point(335, 197);
            this.lblDeletedProductionLine.Name = "lblDeletedProductionLine";
            this.lblDeletedProductionLine.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedProductionLine.TabIndex = 93;
            this.lblDeletedProductionLine.Text = "0";
            // 
            // lblDeletedProductionPlan
            // 
            this.lblDeletedProductionPlan.AutoSize = true;
            this.lblDeletedProductionPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedProductionPlan.Location = new System.Drawing.Point(335, 173);
            this.lblDeletedProductionPlan.Name = "lblDeletedProductionPlan";
            this.lblDeletedProductionPlan.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedProductionPlan.TabIndex = 93;
            this.lblDeletedProductionPlan.Text = "0";
            // 
            // lblDeletedInOutLine
            // 
            this.lblDeletedInOutLine.AutoSize = true;
            this.lblDeletedInOutLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedInOutLine.Location = new System.Drawing.Point(335, 127);
            this.lblDeletedInOutLine.Name = "lblDeletedInOutLine";
            this.lblDeletedInOutLine.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedInOutLine.TabIndex = 93;
            this.lblDeletedInOutLine.Text = "0";
            // 
            // lblErrorOnProductionLine
            // 
            this.lblErrorOnProductionLine.AutoSize = true;
            this.lblErrorOnProductionLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnProductionLine.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnProductionLine.Location = new System.Drawing.Point(408, 197);
            this.lblErrorOnProductionLine.Name = "lblErrorOnProductionLine";
            this.lblErrorOnProductionLine.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnProductionLine.TabIndex = 92;
            this.lblErrorOnProductionLine.Text = "0";
            // 
            // lblErrorOnProductionPlan
            // 
            this.lblErrorOnProductionPlan.AutoSize = true;
            this.lblErrorOnProductionPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnProductionPlan.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnProductionPlan.Location = new System.Drawing.Point(408, 173);
            this.lblErrorOnProductionPlan.Name = "lblErrorOnProductionPlan";
            this.lblErrorOnProductionPlan.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnProductionPlan.TabIndex = 92;
            this.lblErrorOnProductionPlan.Text = "0";
            // 
            // lblErrorOnInOutLine
            // 
            this.lblErrorOnInOutLine.AutoSize = true;
            this.lblErrorOnInOutLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnInOutLine.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnInOutLine.Location = new System.Drawing.Point(408, 127);
            this.lblErrorOnInOutLine.Name = "lblErrorOnInOutLine";
            this.lblErrorOnInOutLine.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnInOutLine.TabIndex = 92;
            this.lblErrorOnInOutLine.Text = "0";
            // 
            // lblWarnningOnProductionLine
            // 
            this.lblWarnningOnProductionLine.AutoSize = true;
            this.lblWarnningOnProductionLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnProductionLine.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnProductionLine.Location = new System.Drawing.Point(481, 197);
            this.lblWarnningOnProductionLine.Name = "lblWarnningOnProductionLine";
            this.lblWarnningOnProductionLine.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnProductionLine.TabIndex = 91;
            this.lblWarnningOnProductionLine.Text = "0";
            // 
            // lblWarnningOnProductionPlan
            // 
            this.lblWarnningOnProductionPlan.AutoSize = true;
            this.lblWarnningOnProductionPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnProductionPlan.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnProductionPlan.Location = new System.Drawing.Point(481, 173);
            this.lblWarnningOnProductionPlan.Name = "lblWarnningOnProductionPlan";
            this.lblWarnningOnProductionPlan.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnProductionPlan.TabIndex = 91;
            this.lblWarnningOnProductionPlan.Text = "0";
            // 
            // lblWarnningOnInOutLine
            // 
            this.lblWarnningOnInOutLine.AutoSize = true;
            this.lblWarnningOnInOutLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnInOutLine.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnInOutLine.Location = new System.Drawing.Point(481, 127);
            this.lblWarnningOnInOutLine.Name = "lblWarnningOnInOutLine";
            this.lblWarnningOnInOutLine.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnInOutLine.TabIndex = 91;
            this.lblWarnningOnInOutLine.Text = "0";
            // 
            // lblScriptsOnProductionLine
            // 
            this.lblScriptsOnProductionLine.AutoSize = true;
            this.lblScriptsOnProductionLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnProductionLine.Location = new System.Drawing.Point(561, 197);
            this.lblScriptsOnProductionLine.Name = "lblScriptsOnProductionLine";
            this.lblScriptsOnProductionLine.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnProductionLine.TabIndex = 90;
            this.lblScriptsOnProductionLine.Text = "0";
            // 
            // lblScriptsOnProductionPlan
            // 
            this.lblScriptsOnProductionPlan.AutoSize = true;
            this.lblScriptsOnProductionPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnProductionPlan.Location = new System.Drawing.Point(561, 173);
            this.lblScriptsOnProductionPlan.Name = "lblScriptsOnProductionPlan";
            this.lblScriptsOnProductionPlan.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnProductionPlan.TabIndex = 90;
            this.lblScriptsOnProductionPlan.Text = "0";
            // 
            // lblScriptsOnInOutLine
            // 
            this.lblScriptsOnInOutLine.AutoSize = true;
            this.lblScriptsOnInOutLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnInOutLine.Location = new System.Drawing.Point(561, 127);
            this.lblScriptsOnInOutLine.Name = "lblScriptsOnInOutLine";
            this.lblScriptsOnInOutLine.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnInOutLine.TabIndex = 90;
            this.lblScriptsOnInOutLine.Text = "0";
            // 
            // lblInsertedProductionLine
            // 
            this.lblInsertedProductionLine.AutoSize = true;
            this.lblInsertedProductionLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedProductionLine.Location = new System.Drawing.Point(175, 197);
            this.lblInsertedProductionLine.Name = "lblInsertedProductionLine";
            this.lblInsertedProductionLine.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedProductionLine.TabIndex = 89;
            this.lblInsertedProductionLine.Text = "0";
            // 
            // lblInsertedProductionPlan
            // 
            this.lblInsertedProductionPlan.AutoSize = true;
            this.lblInsertedProductionPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedProductionPlan.Location = new System.Drawing.Point(175, 173);
            this.lblInsertedProductionPlan.Name = "lblInsertedProductionPlan";
            this.lblInsertedProductionPlan.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedProductionPlan.TabIndex = 89;
            this.lblInsertedProductionPlan.Text = "0";
            // 
            // lblInsertedInOutLine
            // 
            this.lblInsertedInOutLine.AutoSize = true;
            this.lblInsertedInOutLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedInOutLine.Location = new System.Drawing.Point(175, 127);
            this.lblInsertedInOutLine.Name = "lblInsertedInOutLine";
            this.lblInsertedInOutLine.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedInOutLine.TabIndex = 89;
            this.lblInsertedInOutLine.Text = "0";
            // 
            // lblScriptsOnProduction
            // 
            this.lblScriptsOnProduction.AutoSize = true;
            this.lblScriptsOnProduction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnProduction.Location = new System.Drawing.Point(561, 150);
            this.lblScriptsOnProduction.Name = "lblScriptsOnProduction";
            this.lblScriptsOnProduction.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnProduction.TabIndex = 88;
            this.lblScriptsOnProduction.Text = "0";
            // 
            // lblScriptsOnInOut
            // 
            this.lblScriptsOnInOut.AutoSize = true;
            this.lblScriptsOnInOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnInOut.Location = new System.Drawing.Point(561, 104);
            this.lblScriptsOnInOut.Name = "lblScriptsOnInOut";
            this.lblScriptsOnInOut.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnInOut.TabIndex = 88;
            this.lblScriptsOnInOut.Text = "0";
            // 
            // lblWarnningOnProduction
            // 
            this.lblWarnningOnProduction.AutoSize = true;
            this.lblWarnningOnProduction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnProduction.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnProduction.Location = new System.Drawing.Point(481, 150);
            this.lblWarnningOnProduction.Name = "lblWarnningOnProduction";
            this.lblWarnningOnProduction.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnProduction.TabIndex = 87;
            this.lblWarnningOnProduction.Text = "0";
            // 
            // lblWarnningOnInOut
            // 
            this.lblWarnningOnInOut.AutoSize = true;
            this.lblWarnningOnInOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnInOut.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnInOut.Location = new System.Drawing.Point(481, 104);
            this.lblWarnningOnInOut.Name = "lblWarnningOnInOut";
            this.lblWarnningOnInOut.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnInOut.TabIndex = 87;
            this.lblWarnningOnInOut.Text = "0";
            // 
            // lblErrorOnProduction
            // 
            this.lblErrorOnProduction.AutoSize = true;
            this.lblErrorOnProduction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnProduction.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnProduction.Location = new System.Drawing.Point(408, 150);
            this.lblErrorOnProduction.Name = "lblErrorOnProduction";
            this.lblErrorOnProduction.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnProduction.TabIndex = 86;
            this.lblErrorOnProduction.Text = "0";
            // 
            // lblErrorOnInOut
            // 
            this.lblErrorOnInOut.AutoSize = true;
            this.lblErrorOnInOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnInOut.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnInOut.Location = new System.Drawing.Point(408, 104);
            this.lblErrorOnInOut.Name = "lblErrorOnInOut";
            this.lblErrorOnInOut.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnInOut.TabIndex = 86;
            this.lblErrorOnInOut.Text = "0";
            // 
            // lblDeletedProduction
            // 
            this.lblDeletedProduction.AutoSize = true;
            this.lblDeletedProduction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedProduction.Location = new System.Drawing.Point(335, 150);
            this.lblDeletedProduction.Name = "lblDeletedProduction";
            this.lblDeletedProduction.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedProduction.TabIndex = 85;
            this.lblDeletedProduction.Text = "0";
            // 
            // lblDeletedInOut
            // 
            this.lblDeletedInOut.AutoSize = true;
            this.lblDeletedInOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedInOut.Location = new System.Drawing.Point(335, 104);
            this.lblDeletedInOut.Name = "lblDeletedInOut";
            this.lblDeletedInOut.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedInOut.TabIndex = 85;
            this.lblDeletedInOut.Text = "0";
            // 
            // lblUpdatedProduction
            // 
            this.lblUpdatedProduction.AutoSize = true;
            this.lblUpdatedProduction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedProduction.Location = new System.Drawing.Point(255, 150);
            this.lblUpdatedProduction.Name = "lblUpdatedProduction";
            this.lblUpdatedProduction.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedProduction.TabIndex = 84;
            this.lblUpdatedProduction.Text = "0";
            // 
            // lblUpdatedInOut
            // 
            this.lblUpdatedInOut.AutoSize = true;
            this.lblUpdatedInOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedInOut.Location = new System.Drawing.Point(255, 104);
            this.lblUpdatedInOut.Name = "lblUpdatedInOut";
            this.lblUpdatedInOut.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedInOut.TabIndex = 84;
            this.lblUpdatedInOut.Text = "0";
            // 
            // lblInsertedProduction
            // 
            this.lblInsertedProduction.AutoSize = true;
            this.lblInsertedProduction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedProduction.Location = new System.Drawing.Point(175, 150);
            this.lblInsertedProduction.Name = "lblInsertedProduction";
            this.lblInsertedProduction.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedProduction.TabIndex = 83;
            this.lblInsertedProduction.Text = "0";
            // 
            // lblInsertedInOut
            // 
            this.lblInsertedInOut.AutoSize = true;
            this.lblInsertedInOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedInOut.Location = new System.Drawing.Point(175, 104);
            this.lblInsertedInOut.Name = "lblInsertedInOut";
            this.lblInsertedInOut.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedInOut.TabIndex = 83;
            this.lblInsertedInOut.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(35, 197);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 13);
            this.label15.TabIndex = 82;
            this.label15.Text = "Production Line";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 82;
            this.label2.Text = "Production Plan";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 81;
            this.label1.Text = "Production";
            // 
            // lblInOutLine
            // 
            this.lblInOutLine.AutoSize = true;
            this.lblInOutLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInOutLine.Location = new System.Drawing.Point(35, 127);
            this.lblInOutLine.Name = "lblInOutLine";
            this.lblInOutLine.Size = new System.Drawing.Size(66, 13);
            this.lblInOutLine.TabIndex = 82;
            this.lblInOutLine.Text = "In OutLine";
            // 
            // lblInOut
            // 
            this.lblInOut.AutoSize = true;
            this.lblInOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInOut.Location = new System.Drawing.Point(35, 104);
            this.lblInOut.Name = "lblInOut";
            this.lblInOut.Size = new System.Drawing.Size(48, 13);
            this.lblInOut.TabIndex = 81;
            this.lblInOut.Text = "In Outs";
            // 
            // lblCompiereEasyMoveStartTime
            // 
            this.lblCompiereEasyMoveStartTime.AutoSize = true;
            this.lblCompiereEasyMoveStartTime.Location = new System.Drawing.Point(270, 235);
            this.lblCompiereEasyMoveStartTime.Name = "lblCompiereEasyMoveStartTime";
            this.lblCompiereEasyMoveStartTime.Size = new System.Drawing.Size(57, 13);
            this.lblCompiereEasyMoveStartTime.TabIndex = 80;
            this.lblCompiereEasyMoveStartTime.Text = "15:20:00";
            // 
            // lblCompiereEasyMoveStatus
            // 
            this.lblCompiereEasyMoveStatus.AutoSize = true;
            this.lblCompiereEasyMoveStatus.ForeColor = System.Drawing.Color.LawnGreen;
            this.lblCompiereEasyMoveStatus.Location = new System.Drawing.Point(150, 235);
            this.lblCompiereEasyMoveStatus.Name = "lblCompiereEasyMoveStatus";
            this.lblCompiereEasyMoveStatus.Size = new System.Drawing.Size(25, 13);
            this.lblCompiereEasyMoveStatus.TabIndex = 79;
            this.lblCompiereEasyMoveStatus.Text = "ON";
            // 
            // lblEasyMoveCompiereStartTime
            // 
            this.lblEasyMoveCompiereStartTime.AutoSize = true;
            this.lblEasyMoveCompiereStartTime.Location = new System.Drawing.Point(270, 36);
            this.lblEasyMoveCompiereStartTime.Name = "lblEasyMoveCompiereStartTime";
            this.lblEasyMoveCompiereStartTime.Size = new System.Drawing.Size(57, 13);
            this.lblEasyMoveCompiereStartTime.TabIndex = 4;
            this.lblEasyMoveCompiereStartTime.Text = "15:15:20";
            // 
            // lblUpdatedMovementLine
            // 
            this.lblUpdatedMovementLine.AutoSize = true;
            this.lblUpdatedMovementLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedMovementLine.Location = new System.Drawing.Point(255, 83);
            this.lblUpdatedMovementLine.Name = "lblUpdatedMovementLine";
            this.lblUpdatedMovementLine.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedMovementLine.TabIndex = 78;
            this.lblUpdatedMovementLine.Text = "0";
            // 
            // lblUpdatedClient
            // 
            this.lblUpdatedClient.AutoSize = true;
            this.lblUpdatedClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedClient.Location = new System.Drawing.Point(255, 260);
            this.lblUpdatedClient.Name = "lblUpdatedClient";
            this.lblUpdatedClient.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedClient.TabIndex = 77;
            this.lblUpdatedClient.Text = "0";
            // 
            // lblDeletedMovementLine
            // 
            this.lblDeletedMovementLine.AutoSize = true;
            this.lblDeletedMovementLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedMovementLine.Location = new System.Drawing.Point(335, 83);
            this.lblDeletedMovementLine.Name = "lblDeletedMovementLine";
            this.lblDeletedMovementLine.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedMovementLine.TabIndex = 76;
            this.lblDeletedMovementLine.Text = "0";
            // 
            // lblDeletedClient
            // 
            this.lblDeletedClient.AutoSize = true;
            this.lblDeletedClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedClient.Location = new System.Drawing.Point(335, 260);
            this.lblDeletedClient.Name = "lblDeletedClient";
            this.lblDeletedClient.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedClient.TabIndex = 75;
            this.lblDeletedClient.Text = "0";
            // 
            // lblErrorOnMovementLine
            // 
            this.lblErrorOnMovementLine.AutoSize = true;
            this.lblErrorOnMovementLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnMovementLine.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnMovementLine.Location = new System.Drawing.Point(408, 83);
            this.lblErrorOnMovementLine.Name = "lblErrorOnMovementLine";
            this.lblErrorOnMovementLine.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnMovementLine.TabIndex = 74;
            this.lblErrorOnMovementLine.Text = "0";
            // 
            // lblErrorOnClient
            // 
            this.lblErrorOnClient.AutoSize = true;
            this.lblErrorOnClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnClient.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnClient.Location = new System.Drawing.Point(408, 260);
            this.lblErrorOnClient.Name = "lblErrorOnClient";
            this.lblErrorOnClient.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnClient.TabIndex = 73;
            this.lblErrorOnClient.Text = "0";
            // 
            // lblWarnningOnMovementLine
            // 
            this.lblWarnningOnMovementLine.AutoSize = true;
            this.lblWarnningOnMovementLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnMovementLine.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnMovementLine.Location = new System.Drawing.Point(481, 83);
            this.lblWarnningOnMovementLine.Name = "lblWarnningOnMovementLine";
            this.lblWarnningOnMovementLine.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnMovementLine.TabIndex = 72;
            this.lblWarnningOnMovementLine.Text = "0";
            // 
            // lblWarnningOnClient
            // 
            this.lblWarnningOnClient.AutoSize = true;
            this.lblWarnningOnClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnClient.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnClient.Location = new System.Drawing.Point(481, 260);
            this.lblWarnningOnClient.Name = "lblWarnningOnClient";
            this.lblWarnningOnClient.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnClient.TabIndex = 71;
            this.lblWarnningOnClient.Text = "0";
            // 
            // lblScriptsOnMovementLine
            // 
            this.lblScriptsOnMovementLine.AutoSize = true;
            this.lblScriptsOnMovementLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnMovementLine.Location = new System.Drawing.Point(561, 83);
            this.lblScriptsOnMovementLine.Name = "lblScriptsOnMovementLine";
            this.lblScriptsOnMovementLine.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnMovementLine.TabIndex = 70;
            this.lblScriptsOnMovementLine.Text = "0";
            // 
            // lblScriptsOnClient
            // 
            this.lblScriptsOnClient.AutoSize = true;
            this.lblScriptsOnClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnClient.Location = new System.Drawing.Point(561, 260);
            this.lblScriptsOnClient.Name = "lblScriptsOnClient";
            this.lblScriptsOnClient.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnClient.TabIndex = 69;
            this.lblScriptsOnClient.Text = "0";
            // 
            // lblUpdatedOrganisation
            // 
            this.lblUpdatedOrganisation.AutoSize = true;
            this.lblUpdatedOrganisation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedOrganisation.Location = new System.Drawing.Point(255, 284);
            this.lblUpdatedOrganisation.Name = "lblUpdatedOrganisation";
            this.lblUpdatedOrganisation.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedOrganisation.TabIndex = 68;
            this.lblUpdatedOrganisation.Text = "0";
            // 
            // lblDeletedOrganisation
            // 
            this.lblDeletedOrganisation.AutoSize = true;
            this.lblDeletedOrganisation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedOrganisation.Location = new System.Drawing.Point(335, 284);
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
            this.lblErrorOnOrganisation.Location = new System.Drawing.Point(408, 284);
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
            this.lblWarnningOnOrganisation.Location = new System.Drawing.Point(481, 284);
            this.lblWarnningOnOrganisation.Name = "lblWarnningOnOrganisation";
            this.lblWarnningOnOrganisation.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnOrganisation.TabIndex = 65;
            this.lblWarnningOnOrganisation.Text = "0";
            // 
            // lblScriptsOnOrganisation
            // 
            this.lblScriptsOnOrganisation.AutoSize = true;
            this.lblScriptsOnOrganisation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnOrganisation.Location = new System.Drawing.Point(561, 284);
            this.lblScriptsOnOrganisation.Name = "lblScriptsOnOrganisation";
            this.lblScriptsOnOrganisation.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnOrganisation.TabIndex = 64;
            this.lblScriptsOnOrganisation.Text = "0";
            // 
            // lblUpdatedLocators
            // 
            this.lblUpdatedLocators.AutoSize = true;
            this.lblUpdatedLocators.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedLocators.Location = new System.Drawing.Point(255, 308);
            this.lblUpdatedLocators.Name = "lblUpdatedLocators";
            this.lblUpdatedLocators.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedLocators.TabIndex = 63;
            this.lblUpdatedLocators.Text = "0";
            // 
            // lblDeletedLocators
            // 
            this.lblDeletedLocators.AutoSize = true;
            this.lblDeletedLocators.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedLocators.Location = new System.Drawing.Point(335, 308);
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
            this.lblErrorOnLocators.Location = new System.Drawing.Point(408, 308);
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
            this.lblWarnningOnLocators.Location = new System.Drawing.Point(481, 308);
            this.lblWarnningOnLocators.Name = "lblWarnningOnLocators";
            this.lblWarnningOnLocators.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnLocators.TabIndex = 60;
            this.lblWarnningOnLocators.Text = "0";
            // 
            // lblScriptsOnLocators
            // 
            this.lblScriptsOnLocators.AutoSize = true;
            this.lblScriptsOnLocators.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnLocators.Location = new System.Drawing.Point(561, 308);
            this.lblScriptsOnLocators.Name = "lblScriptsOnLocators";
            this.lblScriptsOnLocators.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnLocators.TabIndex = 59;
            this.lblScriptsOnLocators.Text = "0";
            // 
            // lblUpdatedCategory
            // 
            this.lblUpdatedCategory.AutoSize = true;
            this.lblUpdatedCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedCategory.Location = new System.Drawing.Point(255, 332);
            this.lblUpdatedCategory.Name = "lblUpdatedCategory";
            this.lblUpdatedCategory.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedCategory.TabIndex = 58;
            this.lblUpdatedCategory.Text = "0";
            // 
            // lblDeletedCategories
            // 
            this.lblDeletedCategories.AutoSize = true;
            this.lblDeletedCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedCategories.Location = new System.Drawing.Point(335, 332);
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
            this.lblErrorOnCategories.Location = new System.Drawing.Point(408, 332);
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
            this.lblWarnningOnCategories.Location = new System.Drawing.Point(481, 332);
            this.lblWarnningOnCategories.Name = "lblWarnningOnCategories";
            this.lblWarnningOnCategories.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnCategories.TabIndex = 55;
            this.lblWarnningOnCategories.Text = "0";
            // 
            // lblScriptsOnCategories
            // 
            this.lblScriptsOnCategories.AutoSize = true;
            this.lblScriptsOnCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnCategories.Location = new System.Drawing.Point(561, 332);
            this.lblScriptsOnCategories.Name = "lblScriptsOnCategories";
            this.lblScriptsOnCategories.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnCategories.TabIndex = 54;
            this.lblScriptsOnCategories.Text = "0";
            // 
            // lblUpdatedUOM
            // 
            this.lblUpdatedUOM.AutoSize = true;
            this.lblUpdatedUOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedUOM.Location = new System.Drawing.Point(255, 356);
            this.lblUpdatedUOM.Name = "lblUpdatedUOM";
            this.lblUpdatedUOM.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedUOM.TabIndex = 53;
            this.lblUpdatedUOM.Text = "0";
            // 
            // lblDeletedUOM
            // 
            this.lblDeletedUOM.AutoSize = true;
            this.lblDeletedUOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedUOM.Location = new System.Drawing.Point(335, 356);
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
            this.lblErrorOnUOM.Location = new System.Drawing.Point(408, 356);
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
            this.lblWarnningOnUOM.Location = new System.Drawing.Point(481, 356);
            this.lblWarnningOnUOM.Name = "lblWarnningOnUOM";
            this.lblWarnningOnUOM.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnUOM.TabIndex = 50;
            this.lblWarnningOnUOM.Text = "0";
            // 
            // lblScriptsOnUOM
            // 
            this.lblScriptsOnUOM.AutoSize = true;
            this.lblScriptsOnUOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnUOM.Location = new System.Drawing.Point(561, 356);
            this.lblScriptsOnUOM.Name = "lblScriptsOnUOM";
            this.lblScriptsOnUOM.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnUOM.TabIndex = 49;
            this.lblScriptsOnUOM.Text = "0";
            // 
            // lblUpdatedBOMs
            // 
            this.lblUpdatedBOMs.AutoSize = true;
            this.lblUpdatedBOMs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedBOMs.Location = new System.Drawing.Point(255, 402);
            this.lblUpdatedBOMs.Name = "lblUpdatedBOMs";
            this.lblUpdatedBOMs.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedBOMs.TabIndex = 48;
            this.lblUpdatedBOMs.Text = "0";
            // 
            // lblUpdatedItems
            // 
            this.lblUpdatedItems.AutoSize = true;
            this.lblUpdatedItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedItems.Location = new System.Drawing.Point(255, 380);
            this.lblUpdatedItems.Name = "lblUpdatedItems";
            this.lblUpdatedItems.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedItems.TabIndex = 48;
            this.lblUpdatedItems.Text = "0";
            // 
            // lblDeletedBOMs
            // 
            this.lblDeletedBOMs.AutoSize = true;
            this.lblDeletedBOMs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedBOMs.Location = new System.Drawing.Point(335, 402);
            this.lblDeletedBOMs.Name = "lblDeletedBOMs";
            this.lblDeletedBOMs.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedBOMs.TabIndex = 47;
            this.lblDeletedBOMs.Text = "0";
            // 
            // lblDeletedItems
            // 
            this.lblDeletedItems.AutoSize = true;
            this.lblDeletedItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedItems.Location = new System.Drawing.Point(335, 380);
            this.lblDeletedItems.Name = "lblDeletedItems";
            this.lblDeletedItems.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedItems.TabIndex = 47;
            this.lblDeletedItems.Text = "0";
            // 
            // lblErrorOnBOMs
            // 
            this.lblErrorOnBOMs.AutoSize = true;
            this.lblErrorOnBOMs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnBOMs.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnBOMs.Location = new System.Drawing.Point(408, 402);
            this.lblErrorOnBOMs.Name = "lblErrorOnBOMs";
            this.lblErrorOnBOMs.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnBOMs.TabIndex = 46;
            this.lblErrorOnBOMs.Text = "0";
            // 
            // lblErrorOnItems
            // 
            this.lblErrorOnItems.AutoSize = true;
            this.lblErrorOnItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnItems.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnItems.Location = new System.Drawing.Point(408, 380);
            this.lblErrorOnItems.Name = "lblErrorOnItems";
            this.lblErrorOnItems.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnItems.TabIndex = 46;
            this.lblErrorOnItems.Text = "0";
            // 
            // lblWarnningOnBOMs
            // 
            this.lblWarnningOnBOMs.AutoSize = true;
            this.lblWarnningOnBOMs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnBOMs.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnBOMs.Location = new System.Drawing.Point(481, 402);
            this.lblWarnningOnBOMs.Name = "lblWarnningOnBOMs";
            this.lblWarnningOnBOMs.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnBOMs.TabIndex = 45;
            this.lblWarnningOnBOMs.Text = "0";
            // 
            // lblWarnningOnItems
            // 
            this.lblWarnningOnItems.AutoSize = true;
            this.lblWarnningOnItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnItems.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnItems.Location = new System.Drawing.Point(481, 380);
            this.lblWarnningOnItems.Name = "lblWarnningOnItems";
            this.lblWarnningOnItems.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnItems.TabIndex = 45;
            this.lblWarnningOnItems.Text = "0";
            // 
            // lblScriptsOnBOMs
            // 
            this.lblScriptsOnBOMs.AutoSize = true;
            this.lblScriptsOnBOMs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnBOMs.Location = new System.Drawing.Point(561, 402);
            this.lblScriptsOnBOMs.Name = "lblScriptsOnBOMs";
            this.lblScriptsOnBOMs.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnBOMs.TabIndex = 44;
            this.lblScriptsOnBOMs.Text = "0";
            // 
            // lblScriptsOnItems
            // 
            this.lblScriptsOnItems.AutoSize = true;
            this.lblScriptsOnItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnItems.Location = new System.Drawing.Point(561, 380);
            this.lblScriptsOnItems.Name = "lblScriptsOnItems";
            this.lblScriptsOnItems.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnItems.TabIndex = 44;
            this.lblScriptsOnItems.Text = "0";
            // 
            // lblUpdatedWarehouse
            // 
            this.lblUpdatedWarehouse.AutoSize = true;
            this.lblUpdatedWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedWarehouse.Location = new System.Drawing.Point(255, 475);
            this.lblUpdatedWarehouse.Name = "lblUpdatedWarehouse";
            this.lblUpdatedWarehouse.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedWarehouse.TabIndex = 43;
            this.lblUpdatedWarehouse.Text = "0";
            // 
            // lblUpdatedUser
            // 
            this.lblUpdatedUser.AutoSize = true;
            this.lblUpdatedUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedUser.Location = new System.Drawing.Point(255, 425);
            this.lblUpdatedUser.Name = "lblUpdatedUser";
            this.lblUpdatedUser.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedUser.TabIndex = 43;
            this.lblUpdatedUser.Text = "0";
            // 
            // lblDeletedWarehouse
            // 
            this.lblDeletedWarehouse.AutoSize = true;
            this.lblDeletedWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedWarehouse.Location = new System.Drawing.Point(335, 475);
            this.lblDeletedWarehouse.Name = "lblDeletedWarehouse";
            this.lblDeletedWarehouse.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedWarehouse.TabIndex = 42;
            this.lblDeletedWarehouse.Text = "0";
            // 
            // lblDeletedUser
            // 
            this.lblDeletedUser.AutoSize = true;
            this.lblDeletedUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedUser.Location = new System.Drawing.Point(335, 425);
            this.lblDeletedUser.Name = "lblDeletedUser";
            this.lblDeletedUser.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedUser.TabIndex = 42;
            this.lblDeletedUser.Text = "0";
            // 
            // lblErrorOnWarehouse
            // 
            this.lblErrorOnWarehouse.AutoSize = true;
            this.lblErrorOnWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnWarehouse.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnWarehouse.Location = new System.Drawing.Point(408, 475);
            this.lblErrorOnWarehouse.Name = "lblErrorOnWarehouse";
            this.lblErrorOnWarehouse.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnWarehouse.TabIndex = 41;
            this.lblErrorOnWarehouse.Text = "0";
            // 
            // lblErrorOnUser
            // 
            this.lblErrorOnUser.AutoSize = true;
            this.lblErrorOnUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnUser.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnUser.Location = new System.Drawing.Point(408, 425);
            this.lblErrorOnUser.Name = "lblErrorOnUser";
            this.lblErrorOnUser.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnUser.TabIndex = 41;
            this.lblErrorOnUser.Text = "0";
            // 
            // lblWarnningOnWarehouse
            // 
            this.lblWarnningOnWarehouse.AutoSize = true;
            this.lblWarnningOnWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnWarehouse.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnWarehouse.Location = new System.Drawing.Point(481, 475);
            this.lblWarnningOnWarehouse.Name = "lblWarnningOnWarehouse";
            this.lblWarnningOnWarehouse.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnWarehouse.TabIndex = 40;
            this.lblWarnningOnWarehouse.Text = "0";
            // 
            // lblWarnningOnUser
            // 
            this.lblWarnningOnUser.AutoSize = true;
            this.lblWarnningOnUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnUser.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnUser.Location = new System.Drawing.Point(481, 425);
            this.lblWarnningOnUser.Name = "lblWarnningOnUser";
            this.lblWarnningOnUser.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnUser.TabIndex = 40;
            this.lblWarnningOnUser.Text = "0";
            // 
            // lblScriptsOnWarehouse
            // 
            this.lblScriptsOnWarehouse.AutoSize = true;
            this.lblScriptsOnWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnWarehouse.Location = new System.Drawing.Point(561, 475);
            this.lblScriptsOnWarehouse.Name = "lblScriptsOnWarehouse";
            this.lblScriptsOnWarehouse.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnWarehouse.TabIndex = 39;
            this.lblScriptsOnWarehouse.Text = "0";
            // 
            // lblScriptsOnUser
            // 
            this.lblScriptsOnUser.AutoSize = true;
            this.lblScriptsOnUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnUser.Location = new System.Drawing.Point(561, 425);
            this.lblScriptsOnUser.Name = "lblScriptsOnUser";
            this.lblScriptsOnUser.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnUser.TabIndex = 39;
            this.lblScriptsOnUser.Text = "0";
            // 
            // lblUpdatedDocumentType
            // 
            this.lblUpdatedDocumentType.AutoSize = true;
            this.lblUpdatedDocumentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedDocumentType.Location = new System.Drawing.Point(255, 500);
            this.lblUpdatedDocumentType.Name = "lblUpdatedDocumentType";
            this.lblUpdatedDocumentType.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedDocumentType.TabIndex = 38;
            this.lblUpdatedDocumentType.Text = "0";
            // 
            // lblUpdatedUserOrgAccess
            // 
            this.lblUpdatedUserOrgAccess.AutoSize = true;
            this.lblUpdatedUserOrgAccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedUserOrgAccess.Location = new System.Drawing.Point(255, 450);
            this.lblUpdatedUserOrgAccess.Name = "lblUpdatedUserOrgAccess";
            this.lblUpdatedUserOrgAccess.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedUserOrgAccess.TabIndex = 38;
            this.lblUpdatedUserOrgAccess.Text = "0";
            // 
            // lblDeletedDocumentType
            // 
            this.lblDeletedDocumentType.AutoSize = true;
            this.lblDeletedDocumentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedDocumentType.Location = new System.Drawing.Point(335, 498);
            this.lblDeletedDocumentType.Name = "lblDeletedDocumentType";
            this.lblDeletedDocumentType.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedDocumentType.TabIndex = 37;
            this.lblDeletedDocumentType.Text = "0";
            // 
            // lblDeletedUserOrgAccess
            // 
            this.lblDeletedUserOrgAccess.AutoSize = true;
            this.lblDeletedUserOrgAccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedUserOrgAccess.Location = new System.Drawing.Point(335, 448);
            this.lblDeletedUserOrgAccess.Name = "lblDeletedUserOrgAccess";
            this.lblDeletedUserOrgAccess.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedUserOrgAccess.TabIndex = 37;
            this.lblDeletedUserOrgAccess.Text = "0";
            // 
            // lblErrorOnDocumentType
            // 
            this.lblErrorOnDocumentType.AutoSize = true;
            this.lblErrorOnDocumentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnDocumentType.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnDocumentType.Location = new System.Drawing.Point(408, 498);
            this.lblErrorOnDocumentType.Name = "lblErrorOnDocumentType";
            this.lblErrorOnDocumentType.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnDocumentType.TabIndex = 36;
            this.lblErrorOnDocumentType.Text = "0";
            // 
            // lblErrorOnUserOrgAccess
            // 
            this.lblErrorOnUserOrgAccess.AutoSize = true;
            this.lblErrorOnUserOrgAccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnUserOrgAccess.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnUserOrgAccess.Location = new System.Drawing.Point(408, 448);
            this.lblErrorOnUserOrgAccess.Name = "lblErrorOnUserOrgAccess";
            this.lblErrorOnUserOrgAccess.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnUserOrgAccess.TabIndex = 36;
            this.lblErrorOnUserOrgAccess.Text = "0";
            // 
            // lblWarnningOnDocumentType
            // 
            this.lblWarnningOnDocumentType.AutoSize = true;
            this.lblWarnningOnDocumentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnDocumentType.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnDocumentType.Location = new System.Drawing.Point(481, 500);
            this.lblWarnningOnDocumentType.Name = "lblWarnningOnDocumentType";
            this.lblWarnningOnDocumentType.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnDocumentType.TabIndex = 35;
            this.lblWarnningOnDocumentType.Text = "0";
            // 
            // lblWarnningOnUserOrgAccess
            // 
            this.lblWarnningOnUserOrgAccess.AutoSize = true;
            this.lblWarnningOnUserOrgAccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnUserOrgAccess.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnUserOrgAccess.Location = new System.Drawing.Point(481, 450);
            this.lblWarnningOnUserOrgAccess.Name = "lblWarnningOnUserOrgAccess";
            this.lblWarnningOnUserOrgAccess.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnUserOrgAccess.TabIndex = 35;
            this.lblWarnningOnUserOrgAccess.Text = "0";
            // 
            // lblScriptsOnDocumentType
            // 
            this.lblScriptsOnDocumentType.AutoSize = true;
            this.lblScriptsOnDocumentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnDocumentType.Location = new System.Drawing.Point(561, 500);
            this.lblScriptsOnDocumentType.Name = "lblScriptsOnDocumentType";
            this.lblScriptsOnDocumentType.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnDocumentType.TabIndex = 34;
            this.lblScriptsOnDocumentType.Text = "0";
            // 
            // lblScriptsOnUserOrgAccess
            // 
            this.lblScriptsOnUserOrgAccess.AutoSize = true;
            this.lblScriptsOnUserOrgAccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnUserOrgAccess.Location = new System.Drawing.Point(561, 450);
            this.lblScriptsOnUserOrgAccess.Name = "lblScriptsOnUserOrgAccess";
            this.lblScriptsOnUserOrgAccess.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnUserOrgAccess.TabIndex = 34;
            this.lblScriptsOnUserOrgAccess.Text = "0";
            // 
            // lblInsertedDocumentType
            // 
            this.lblInsertedDocumentType.AutoSize = true;
            this.lblInsertedDocumentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedDocumentType.Location = new System.Drawing.Point(175, 500);
            this.lblInsertedDocumentType.Name = "lblInsertedDocumentType";
            this.lblInsertedDocumentType.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedDocumentType.TabIndex = 33;
            this.lblInsertedDocumentType.Text = "0";
            // 
            // lblInsertedUserOrgAccess
            // 
            this.lblInsertedUserOrgAccess.AutoSize = true;
            this.lblInsertedUserOrgAccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedUserOrgAccess.Location = new System.Drawing.Point(175, 450);
            this.lblInsertedUserOrgAccess.Name = "lblInsertedUserOrgAccess";
            this.lblInsertedUserOrgAccess.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedUserOrgAccess.TabIndex = 33;
            this.lblInsertedUserOrgAccess.Text = "0";
            // 
            // lblEasyMoveCompiereStatus
            // 
            this.lblEasyMoveCompiereStatus.AutoSize = true;
            this.lblEasyMoveCompiereStatus.ForeColor = System.Drawing.Color.LawnGreen;
            this.lblEasyMoveCompiereStatus.Location = new System.Drawing.Point(150, 38);
            this.lblEasyMoveCompiereStatus.Name = "lblEasyMoveCompiereStatus";
            this.lblEasyMoveCompiereStatus.Size = new System.Drawing.Size(25, 13);
            this.lblEasyMoveCompiereStatus.TabIndex = 32;
            this.lblEasyMoveCompiereStatus.Text = "ON";
            // 
            // lblInsertedWarehouse
            // 
            this.lblInsertedWarehouse.AutoSize = true;
            this.lblInsertedWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedWarehouse.Location = new System.Drawing.Point(175, 475);
            this.lblInsertedWarehouse.Name = "lblInsertedWarehouse";
            this.lblInsertedWarehouse.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedWarehouse.TabIndex = 31;
            this.lblInsertedWarehouse.Text = "0";
            // 
            // lblInsertedUser
            // 
            this.lblInsertedUser.AutoSize = true;
            this.lblInsertedUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedUser.Location = new System.Drawing.Point(175, 425);
            this.lblInsertedUser.Name = "lblInsertedUser";
            this.lblInsertedUser.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedUser.TabIndex = 31;
            this.lblInsertedUser.Text = "0";
            // 
            // lblInsertedBOMs
            // 
            this.lblInsertedBOMs.AutoSize = true;
            this.lblInsertedBOMs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedBOMs.Location = new System.Drawing.Point(175, 402);
            this.lblInsertedBOMs.Name = "lblInsertedBOMs";
            this.lblInsertedBOMs.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedBOMs.TabIndex = 30;
            this.lblInsertedBOMs.Text = "0";
            // 
            // lblInsertedItems
            // 
            this.lblInsertedItems.AutoSize = true;
            this.lblInsertedItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedItems.Location = new System.Drawing.Point(175, 380);
            this.lblInsertedItems.Name = "lblInsertedItems";
            this.lblInsertedItems.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedItems.TabIndex = 30;
            this.lblInsertedItems.Text = "0";
            // 
            // lblInsertedUOM
            // 
            this.lblInsertedUOM.AutoSize = true;
            this.lblInsertedUOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedUOM.Location = new System.Drawing.Point(175, 356);
            this.lblInsertedUOM.Name = "lblInsertedUOM";
            this.lblInsertedUOM.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedUOM.TabIndex = 29;
            this.lblInsertedUOM.Text = "0";
            // 
            // lblInsertedCategories
            // 
            this.lblInsertedCategories.AutoSize = true;
            this.lblInsertedCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedCategories.Location = new System.Drawing.Point(175, 332);
            this.lblInsertedCategories.Name = "lblInsertedCategories";
            this.lblInsertedCategories.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedCategories.TabIndex = 28;
            this.lblInsertedCategories.Text = "0";
            // 
            // lblInsertedLocators
            // 
            this.lblInsertedLocators.AutoSize = true;
            this.lblInsertedLocators.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedLocators.Location = new System.Drawing.Point(175, 308);
            this.lblInsertedLocators.Name = "lblInsertedLocators";
            this.lblInsertedLocators.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedLocators.TabIndex = 27;
            this.lblInsertedLocators.Text = "0";
            // 
            // lblInsertedOrganistion
            // 
            this.lblInsertedOrganistion.AutoSize = true;
            this.lblInsertedOrganistion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedOrganistion.Location = new System.Drawing.Point(175, 284);
            this.lblInsertedOrganistion.Name = "lblInsertedOrganistion";
            this.lblInsertedOrganistion.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedOrganistion.TabIndex = 26;
            this.lblInsertedOrganistion.Text = "0";
            // 
            // lblInsertedClient
            // 
            this.lblInsertedClient.AutoSize = true;
            this.lblInsertedClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedClient.Location = new System.Drawing.Point(175, 260);
            this.lblInsertedClient.Name = "lblInsertedClient";
            this.lblInsertedClient.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedClient.TabIndex = 25;
            this.lblInsertedClient.Text = "0";
            // 
            // lblInsertedMovementLine
            // 
            this.lblInsertedMovementLine.AutoSize = true;
            this.lblInsertedMovementLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedMovementLine.Location = new System.Drawing.Point(175, 83);
            this.lblInsertedMovementLine.Name = "lblInsertedMovementLine";
            this.lblInsertedMovementLine.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedMovementLine.TabIndex = 24;
            this.lblInsertedMovementLine.Text = "0";
            // 
            // lblScriptsOnMovement
            // 
            this.lblScriptsOnMovement.AutoSize = true;
            this.lblScriptsOnMovement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScriptsOnMovement.Location = new System.Drawing.Point(561, 60);
            this.lblScriptsOnMovement.Name = "lblScriptsOnMovement";
            this.lblScriptsOnMovement.Size = new System.Drawing.Size(13, 13);
            this.lblScriptsOnMovement.TabIndex = 23;
            this.lblScriptsOnMovement.Text = "0";
            // 
            // lblWarnningOnMovement
            // 
            this.lblWarnningOnMovement.AutoSize = true;
            this.lblWarnningOnMovement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnningOnMovement.ForeColor = System.Drawing.Color.Red;
            this.lblWarnningOnMovement.Location = new System.Drawing.Point(481, 60);
            this.lblWarnningOnMovement.Name = "lblWarnningOnMovement";
            this.lblWarnningOnMovement.Size = new System.Drawing.Size(14, 13);
            this.lblWarnningOnMovement.TabIndex = 22;
            this.lblWarnningOnMovement.Text = "0";
            // 
            // lblErrorOnMovement
            // 
            this.lblErrorOnMovement.AutoSize = true;
            this.lblErrorOnMovement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorOnMovement.ForeColor = System.Drawing.Color.Red;
            this.lblErrorOnMovement.Location = new System.Drawing.Point(408, 60);
            this.lblErrorOnMovement.Name = "lblErrorOnMovement";
            this.lblErrorOnMovement.Size = new System.Drawing.Size(14, 13);
            this.lblErrorOnMovement.TabIndex = 21;
            this.lblErrorOnMovement.Text = "0";
            // 
            // lblDeletedMovement
            // 
            this.lblDeletedMovement.AutoSize = true;
            this.lblDeletedMovement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletedMovement.Location = new System.Drawing.Point(335, 60);
            this.lblDeletedMovement.Name = "lblDeletedMovement";
            this.lblDeletedMovement.Size = new System.Drawing.Size(13, 13);
            this.lblDeletedMovement.TabIndex = 20;
            this.lblDeletedMovement.Text = "0";
            // 
            // lblUpdatedMovement
            // 
            this.lblUpdatedMovement.AutoSize = true;
            this.lblUpdatedMovement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatedMovement.Location = new System.Drawing.Point(255, 60);
            this.lblUpdatedMovement.Name = "lblUpdatedMovement";
            this.lblUpdatedMovement.Size = new System.Drawing.Size(13, 13);
            this.lblUpdatedMovement.TabIndex = 19;
            this.lblUpdatedMovement.Text = "0";
            // 
            // lblInsertedMovement
            // 
            this.lblInsertedMovement.AutoSize = true;
            this.lblInsertedMovement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertedMovement.Location = new System.Drawing.Point(175, 60);
            this.lblInsertedMovement.Name = "lblInsertedMovement";
            this.lblInsertedMovement.Size = new System.Drawing.Size(13, 13);
            this.lblInsertedMovement.TabIndex = 18;
            this.lblInsertedMovement.Text = "0";
            // 
            // lblDocumentType
            // 
            this.lblDocumentType.AutoSize = true;
            this.lblDocumentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumentType.Location = new System.Drawing.Point(40, 500);
            this.lblDocumentType.Name = "lblDocumentType";
            this.lblDocumentType.Size = new System.Drawing.Size(96, 13);
            this.lblDocumentType.TabIndex = 17;
            this.lblDocumentType.Text = "Document Type";
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarehouse.Location = new System.Drawing.Point(40, 475);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(71, 13);
            this.lblWarehouse.TabIndex = 16;
            this.lblWarehouse.Text = "Warehouse";
            // 
            // lblUserOrgAccess
            // 
            this.lblUserOrgAccess.AutoSize = true;
            this.lblUserOrgAccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserOrgAccess.Location = new System.Drawing.Point(40, 450);
            this.lblUserOrgAccess.Name = "lblUserOrgAccess";
            this.lblUserOrgAccess.Size = new System.Drawing.Size(102, 13);
            this.lblUserOrgAccess.TabIndex = 17;
            this.lblUserOrgAccess.Text = "User Org Access";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(40, 425);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(33, 13);
            this.lblUser.TabIndex = 16;
            this.lblUser.Text = "User";
            // 
            // lblBOM
            // 
            this.lblBOM.AutoSize = true;
            this.lblBOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBOM.Location = new System.Drawing.Point(40, 402);
            this.lblBOM.Name = "lblBOM";
            this.lblBOM.Size = new System.Drawing.Size(34, 13);
            this.lblBOM.TabIndex = 15;
            this.lblBOM.Text = "BOM";
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItems.Location = new System.Drawing.Point(40, 380);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(37, 13);
            this.lblItems.TabIndex = 15;
            this.lblItems.Text = "Items";
            // 
            // lblUOM
            // 
            this.lblUOM.AutoSize = true;
            this.lblUOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUOM.Location = new System.Drawing.Point(40, 356);
            this.lblUOM.Name = "lblUOM";
            this.lblUOM.Size = new System.Drawing.Size(125, 13);
            this.lblUOM.TabIndex = 14;
            this.lblUOM.Text = "Units Of Measurment";
            // 
            // lblCategories
            // 
            this.lblCategories.AutoSize = true;
            this.lblCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategories.Location = new System.Drawing.Point(40, 332);
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.Size = new System.Drawing.Size(67, 13);
            this.lblCategories.TabIndex = 13;
            this.lblCategories.Text = "Categories";
            // 
            // lblLocators
            // 
            this.lblLocators.AutoSize = true;
            this.lblLocators.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocators.Location = new System.Drawing.Point(40, 308);
            this.lblLocators.Name = "lblLocators";
            this.lblLocators.Size = new System.Drawing.Size(56, 13);
            this.lblLocators.TabIndex = 12;
            this.lblLocators.Text = "Locators";
            // 
            // lblOrganisation
            // 
            this.lblOrganisation.AutoSize = true;
            this.lblOrganisation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrganisation.Location = new System.Drawing.Point(40, 284);
            this.lblOrganisation.Name = "lblOrganisation";
            this.lblOrganisation.Size = new System.Drawing.Size(78, 13);
            this.lblOrganisation.TabIndex = 11;
            this.lblOrganisation.Text = "Organisation";
            // 
            // lblCompiereToEsayMove
            // 
            this.lblCompiereToEsayMove.AutoSize = true;
            this.lblCompiereToEsayMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompiereToEsayMove.Location = new System.Drawing.Point(8, 233);
            this.lblCompiereToEsayMove.Name = "lblCompiereToEsayMove";
            this.lblCompiereToEsayMove.Size = new System.Drawing.Size(138, 15);
            this.lblCompiereToEsayMove.TabIndex = 10;
            this.lblCompiereToEsayMove.Text = "Compiere-EasyMove";
            // 
            // lblOrderLines
            // 
            this.lblOrderLines.AutoSize = true;
            this.lblOrderLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderLines.Location = new System.Drawing.Point(40, 260);
            this.lblOrderLines.Name = "lblOrderLines";
            this.lblOrderLines.Size = new System.Drawing.Size(39, 13);
            this.lblOrderLines.TabIndex = 9;
            this.lblOrderLines.Text = "Client";
            // 
            // lblMovementLine
            // 
            this.lblMovementLine.AutoSize = true;
            this.lblMovementLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovementLine.Location = new System.Drawing.Point(35, 83);
            this.lblMovementLine.Name = "lblMovementLine";
            this.lblMovementLine.Size = new System.Drawing.Size(93, 13);
            this.lblMovementLine.TabIndex = 8;
            this.lblMovementLine.Text = "Movement Line";
            // 
            // lblMovement
            // 
            this.lblMovement.AutoSize = true;
            this.lblMovement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovement.Location = new System.Drawing.Point(35, 60);
            this.lblMovement.Name = "lblMovement";
            this.lblMovement.Size = new System.Drawing.Size(65, 13);
            this.lblMovement.TabIndex = 7;
            this.lblMovement.Text = "Movement";
            // 
            // lblEsayMoveToCompiere
            // 
            this.lblEsayMoveToCompiere.AutoSize = true;
            this.lblEsayMoveToCompiere.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEsayMoveToCompiere.Location = new System.Drawing.Point(8, 36);
            this.lblEsayMoveToCompiere.Name = "lblEsayMoveToCompiere";
            this.lblEsayMoveToCompiere.Size = new System.Drawing.Size(138, 15);
            this.lblEsayMoveToCompiere.TabIndex = 6;
            this.lblEsayMoveToCompiere.Text = "EasyMove-Compiere";
            // 
            // lblScript
            // 
            this.lblScript.AutoSize = true;
            this.lblScript.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScript.Location = new System.Drawing.Point(540, 13);
            this.lblScript.Name = "lblScript";
            this.lblScript.Size = new System.Drawing.Size(57, 15);
            this.lblScript.TabIndex = 5;
            this.lblScript.Text = "Scripted";
            // 
            // lblWarnning
            // 
            this.lblWarnning.AutoSize = true;
            this.lblWarnning.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarnning.Location = new System.Drawing.Point(460, 13);
            this.lblWarnning.Name = "lblWarnning";
            this.lblWarnning.Size = new System.Drawing.Size(76, 15);
            this.lblWarnning.TabIndex = 4;
            this.lblWarnning.Text = "Warnnings";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.Location = new System.Drawing.Point(387, 13);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(48, 15);
            this.lblError.TabIndex = 3;
            this.lblError.Text = "Errors";
            // 
            // lblDelete
            // 
            this.lblDelete.AutoSize = true;
            this.lblDelete.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelete.Location = new System.Drawing.Point(314, 13);
            this.lblDelete.Name = "lblDelete";
            this.lblDelete.Size = new System.Drawing.Size(52, 15);
            this.lblDelete.TabIndex = 2;
            this.lblDelete.Text = "Deleted";
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdate.Location = new System.Drawing.Point(234, 13);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(49, 15);
            this.lblUpdate.TabIndex = 1;
            this.lblUpdate.Text = "Update";
            // 
            // lblInsert
            // 
            this.lblInsert.AutoSize = true;
            this.lblInsert.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsert.Location = new System.Drawing.Point(154, 13);
            this.lblInsert.Name = "lblInsert";
            this.lblInsert.Size = new System.Drawing.Size(57, 15);
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
            // frmEasyMoveCompiereBridge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 556);
            this.Controls.Add(this.mnuMainMenu);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMainMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEasyMoveCompiereBridge";
            this.Text = "Movement Bridge (v.4.3a)";
            this.Load += new System.EventHandler(this.frmEasyMoveCompiereBridge_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEasyMoveCompiereBridge_FormClosing);
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
        private System.Windows.Forms.ToolStripMenuItem mnuStartEasyMoveToCompiere;
        private System.Windows.Forms.ToolStripMenuItem mnuStartCompiereToEasyMove;
        private System.Windows.Forms.ToolStripMenuItem mnuStartBoth;
        private System.Windows.Forms.ToolStripMenuItem mnuStopSynch;
        private System.Windows.Forms.ToolStripMenuItem mnuStopEasyMoveToCompiere;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuStopCompiereToEasyMove;
        private System.Windows.Forms.ToolStripMenuItem mnuStopBoth;
        private System.ComponentModel.BackgroundWorker bkwCompiereToEasyMoveDataMapController;
        private System.ComponentModel.BackgroundWorker bkwEasyMoveToCompiereDataMapController;
        private System.Windows.Forms.Timer tmrCompToEasyMoveTimeSyncTimeController;
        private System.Windows.Forms.Timer tmrEasyMoveTOCompTimeSyncTimeController;
        private System.Windows.Forms.ContextMenuStrip cmnTaskBarkContexMenu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblInsertedUser;
        private System.Windows.Forms.Label lblInsertedItems;
        private System.Windows.Forms.Label lblInsertedUOM;
        private System.Windows.Forms.Label lblInsertedCategories;
        private System.Windows.Forms.Label lblInsertedLocators;
        private System.Windows.Forms.Label lblInsertedOrganistion;
        private System.Windows.Forms.Label lblInsertedClient;
        private System.Windows.Forms.Label lblInsertedMovementLine;
        private System.Windows.Forms.Label lblScriptsOnMovement;
        private System.Windows.Forms.Label lblWarnningOnMovement;
        private System.Windows.Forms.Label lblErrorOnMovement;
        private System.Windows.Forms.Label lblDeletedMovement;
        private System.Windows.Forms.Label lblUpdatedMovement;
        private System.Windows.Forms.Label lblInsertedMovement;
        private System.Windows.Forms.Label lblUserOrgAccess;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Label lblUOM;
        private System.Windows.Forms.Label lblCategories;
        private System.Windows.Forms.Label lblLocators;
        private System.Windows.Forms.Label lblOrganisation;
        private System.Windows.Forms.Label lblCompiereToEsayMove;
        private System.Windows.Forms.Label lblOrderLines;
        private System.Windows.Forms.Label lblMovementLine;
        private System.Windows.Forms.Label lblMovement;
        private System.Windows.Forms.Label lblEsayMoveToCompiere;
        private System.Windows.Forms.Label lblScript;
        private System.Windows.Forms.Label lblWarnning;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblDelete;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.Label lblInsert;
        private System.Windows.Forms.NotifyIcon ntiTaskBarIcon;
        private System.Windows.Forms.Label lblUpdatedMovementLine;
        private System.Windows.Forms.Label lblUpdatedClient;
        private System.Windows.Forms.Label lblDeletedMovementLine;
        private System.Windows.Forms.Label lblDeletedClient;
        private System.Windows.Forms.Label lblErrorOnMovementLine;
        private System.Windows.Forms.Label lblErrorOnClient;
        private System.Windows.Forms.Label lblWarnningOnMovementLine;
        private System.Windows.Forms.Label lblWarnningOnClient;
        private System.Windows.Forms.Label lblScriptsOnMovementLine;
        private System.Windows.Forms.Label lblScriptsOnClient;
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
        private System.Windows.Forms.Label lblUpdatedUser;
        private System.Windows.Forms.Label lblDeletedUser;
        private System.Windows.Forms.Label lblErrorOnUser;
        private System.Windows.Forms.Label lblWarnningOnUser;
        private System.Windows.Forms.Label lblScriptsOnUser;
        private System.Windows.Forms.Label lblUpdatedUserOrgAccess;
        private System.Windows.Forms.Label lblDeletedUserOrgAccess;
        private System.Windows.Forms.Label lblErrorOnUserOrgAccess;
        private System.Windows.Forms.Label lblWarnningOnUserOrgAccess;
        private System.Windows.Forms.Label lblScriptsOnUserOrgAccess;
        private System.Windows.Forms.Label lblInsertedUserOrgAccess;
        private System.Windows.Forms.Label lblEasyMoveCompiereStatus;
        private System.Windows.Forms.Label lblCompiereEasyMoveStartTime;
        private System.Windows.Forms.Label lblCompiereEasyMoveStatus;
        private System.Windows.Forms.Label lblEasyMoveCompiereStartTime;
        private System.Windows.Forms.ToolStripMenuItem cmnuOpenControl;
        private System.Windows.Forms.ToolStripMenuItem cmnuStartSynch;
        private System.Windows.Forms.ToolStripMenuItem cmnuStopSynch;
        private System.Windows.Forms.ToolStripMenuItem cmnuExit;
        private System.Windows.Forms.ToolStripMenuItem cmnuStartEasyMovetoCompiere;
        private System.Windows.Forms.ToolStripMenuItem cmnuStartCompiereToEasyMove;
        private System.Windows.Forms.ToolStripMenuItem cmnuStartBoth;
        private System.Windows.Forms.ToolStripMenuItem cmnuStopEasyMovetoCompiere;
        private System.Windows.Forms.ToolStripMenuItem cmnuStopCompiereToEasyMove;
        private System.Windows.Forms.ToolStripMenuItem cmnuStopBoth;
        private System.Windows.Forms.Label lblUpdatedWarehouse;
        private System.Windows.Forms.Label lblDeletedWarehouse;
        private System.Windows.Forms.Label lblErrorOnWarehouse;
        private System.Windows.Forms.Label lblWarnningOnWarehouse;
        private System.Windows.Forms.Label lblScriptsOnWarehouse;
        private System.Windows.Forms.Label lblUpdatedDocumentType;
        private System.Windows.Forms.Label lblDeletedDocumentType;
        private System.Windows.Forms.Label lblErrorOnDocumentType;
        private System.Windows.Forms.Label lblWarnningOnDocumentType;
        private System.Windows.Forms.Label lblScriptsOnDocumentType;
        private System.Windows.Forms.Label lblInsertedDocumentType;
        private System.Windows.Forms.Label lblInsertedWarehouse;
        private System.Windows.Forms.Label lblDocumentType;
        private System.Windows.Forms.Label lblWarehouse;
        private System.Windows.Forms.ToolStripMenuItem mnuCleanChangeSequence;
        private System.Windows.Forms.ToolStripMenuItem mnuCleanEasyMoveSequecnce;
        private System.Windows.Forms.ToolStripMenuItem mnuCleanCompiereSequence;
        private System.Windows.Forms.Label lblUpdatedInOutLine;
        private System.Windows.Forms.Label lblDeletedInOutLine;
        private System.Windows.Forms.Label lblErrorOnInOutLine;
        private System.Windows.Forms.Label lblWarnningOnInOutLine;
        private System.Windows.Forms.Label lblScriptsOnInOutLine;
        private System.Windows.Forms.Label lblInsertedInOutLine;
        private System.Windows.Forms.Label lblScriptsOnInOut;
        private System.Windows.Forms.Label lblWarnningOnInOut;
        private System.Windows.Forms.Label lblErrorOnInOut;
        private System.Windows.Forms.Label lblDeletedInOut;
        private System.Windows.Forms.Label lblUpdatedInOut;
        private System.Windows.Forms.Label lblInsertedInOut;
        private System.Windows.Forms.Label lblInOutLine;
        private System.Windows.Forms.Label lblInOut;
        private System.Windows.Forms.Label lblUpdatedProductionLine;
        private System.Windows.Forms.Label lblUpdatedProductionPlan;
        private System.Windows.Forms.Label lblDeletedProductionLine;
        private System.Windows.Forms.Label lblDeletedProductionPlan;
        private System.Windows.Forms.Label lblErrorOnProductionLine;
        private System.Windows.Forms.Label lblErrorOnProductionPlan;
        private System.Windows.Forms.Label lblWarnningOnProductionLine;
        private System.Windows.Forms.Label lblWarnningOnProductionPlan;
        private System.Windows.Forms.Label lblScriptsOnProductionLine;
        private System.Windows.Forms.Label lblScriptsOnProductionPlan;
        private System.Windows.Forms.Label lblInsertedProductionLine;
        private System.Windows.Forms.Label lblInsertedProductionPlan;
        private System.Windows.Forms.Label lblScriptsOnProduction;
        private System.Windows.Forms.Label lblWarnningOnProduction;
        private System.Windows.Forms.Label lblErrorOnProduction;
        private System.Windows.Forms.Label lblDeletedProduction;
        private System.Windows.Forms.Label lblUpdatedProduction;
        private System.Windows.Forms.Label lblInsertedProduction;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUpdatedBOMs;
        private System.Windows.Forms.Label lblDeletedBOMs;
        private System.Windows.Forms.Label lblErrorOnBOMs;
        private System.Windows.Forms.Label lblWarnningOnBOMs;
        private System.Windows.Forms.Label lblScriptsOnBOMs;
        private System.Windows.Forms.Label lblInsertedBOMs;
        private System.Windows.Forms.Label lblBOM;
    }
}

