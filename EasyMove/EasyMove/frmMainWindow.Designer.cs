namespace EasyMove
{
    partial class frmMainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainWindow));
            this.cmdRequest = new System.Windows.Forms.Button();
            this.cmdOrder = new System.Windows.Forms.Button();
            this.cmdMove = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuSettingsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDataBaseConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStaitonAccess = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProcessAccess = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWarehouseAccess = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReports = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBOM = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInventoryReciepts = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeliveryOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrUpdateOpenROMCount = new System.Windows.Forms.Timer(this.components);
            this.cmdPurchases = new System.Windows.Forms.Button();
            this.cmdCustomerDispatch = new System.Windows.Forms.Button();
            this.visualStyler1 = new SkinSoft.VisualStyler.VisualStyler(this.components);
            this.cmdProductionLine = new System.Windows.Forms.Button();
            this.tmrCloseWindow = new System.Windows.Forms.Timer(this.components);
            this.cmdPurchaseMatching = new System.Windows.Forms.Button();
            this.cmdBOMChangeRequest = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visualStyler1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdRequest
            // 
            this.cmdRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRequest.Location = new System.Drawing.Point(42, 52);
            this.cmdRequest.Name = "cmdRequest";
            this.cmdRequest.Size = new System.Drawing.Size(233, 37);
            this.cmdRequest.TabIndex = 0;
            this.cmdRequest.Text = "Transfer Request";
            this.cmdRequest.UseVisualStyleBackColor = true;
            this.cmdRequest.Click += new System.EventHandler(this.cmdRequest_Click);
            // 
            // cmdOrder
            // 
            this.cmdOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOrder.Location = new System.Drawing.Point(63, 99);
            this.cmdOrder.Name = "cmdOrder";
            this.cmdOrder.Size = new System.Drawing.Size(191, 41);
            this.cmdOrder.TabIndex = 1;
            this.cmdOrder.Text = "Transfer Order";
            this.cmdOrder.UseVisualStyleBackColor = true;
            this.cmdOrder.Click += new System.EventHandler(this.cmdOrder_Click);
            // 
            // cmdMove
            // 
            this.cmdMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMove.Location = new System.Drawing.Point(25, 151);
            this.cmdMove.Name = "cmdMove";
            this.cmdMove.Size = new System.Drawing.Size(266, 38);
            this.cmdMove.TabIndex = 2;
            this.cmdMove.Text = "Transfers";
            this.cmdMove.UseVisualStyleBackColor = true;
            this.cmdMove.Click += new System.EventHandler(this.cmdMove_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.ForeColor = System.Drawing.Color.Red;
            this.cmdExit.Location = new System.Drawing.Point(25, 216);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(511, 41);
            this.cmdExit.TabIndex = 3;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 271);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(548, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSettingsMenu,
            this.mnuReports});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(548, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuSettingsMenu
            // 
            this.mnuSettingsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDataBaseConnection,
            this.mnuStaitonAccess,
            this.mnuProcessAccess,
            this.mnuWarehouseAccess});
            this.mnuSettingsMenu.Enabled = false;
            this.mnuSettingsMenu.Name = "mnuSettingsMenu";
            this.mnuSettingsMenu.Size = new System.Drawing.Size(61, 20);
            this.mnuSettingsMenu.Text = "Settings";
            // 
            // mnuDataBaseConnection
            // 
            this.mnuDataBaseConnection.Name = "mnuDataBaseConnection";
            this.mnuDataBaseConnection.Size = new System.Drawing.Size(190, 22);
            this.mnuDataBaseConnection.Text = "Data Base Connection";
            this.mnuDataBaseConnection.Click += new System.EventHandler(this.mnuDataBaseConnection_Click);
            // 
            // mnuStaitonAccess
            // 
            this.mnuStaitonAccess.Name = "mnuStaitonAccess";
            this.mnuStaitonAccess.Size = new System.Drawing.Size(190, 22);
            this.mnuStaitonAccess.Text = "Staiton Access";
            this.mnuStaitonAccess.Click += new System.EventHandler(this.mnuStationAccess_Click);
            // 
            // mnuProcessAccess
            // 
            this.mnuProcessAccess.Name = "mnuProcessAccess";
            this.mnuProcessAccess.Size = new System.Drawing.Size(190, 22);
            this.mnuProcessAccess.Text = "Process Access";
            this.mnuProcessAccess.Click += new System.EventHandler(this.mnuProcessAccess_Click);
            // 
            // mnuWarehouseAccess
            // 
            this.mnuWarehouseAccess.Name = "mnuWarehouseAccess";
            this.mnuWarehouseAccess.Size = new System.Drawing.Size(190, 22);
            this.mnuWarehouseAccess.Text = "Warehouse Access";
            this.mnuWarehouseAccess.Click += new System.EventHandler(this.mnuWarehouseAccess_Click);
            // 
            // mnuReports
            // 
            this.mnuReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBOM,
            this.mnuInventoryReciepts,
            this.mnuDeliveryOrders});
            this.mnuReports.Name = "mnuReports";
            this.mnuReports.Size = new System.Drawing.Size(59, 20);
            this.mnuReports.Text = "Reports";
            // 
            // mnuBOM
            // 
            this.mnuBOM.Enabled = false;
            this.mnuBOM.Name = "mnuBOM";
            this.mnuBOM.Size = new System.Drawing.Size(171, 22);
            this.mnuBOM.Text = "Bill Of Material";
            this.mnuBOM.Click += new System.EventHandler(this.mnuBOM_Click);
            // 
            // mnuInventoryReciepts
            // 
            this.mnuInventoryReciepts.Enabled = false;
            this.mnuInventoryReciepts.Name = "mnuInventoryReciepts";
            this.mnuInventoryReciepts.Size = new System.Drawing.Size(171, 22);
            this.mnuInventoryReciepts.Text = "Inventory Reciepts";
            this.mnuInventoryReciepts.Click += new System.EventHandler(this.mnuInventoryReciepts_Click);
            // 
            // mnuDeliveryOrders
            // 
            this.mnuDeliveryOrders.Enabled = false;
            this.mnuDeliveryOrders.Name = "mnuDeliveryOrders";
            this.mnuDeliveryOrders.Size = new System.Drawing.Size(171, 22);
            this.mnuDeliveryOrders.Text = "Delivery Orders";
            this.mnuDeliveryOrders.Click += new System.EventHandler(this.mnuDeliveryOrders_Click);
            // 
            // tmrUpdateOpenROMCount
            // 
            this.tmrUpdateOpenROMCount.Interval = 120000;
            this.tmrUpdateOpenROMCount.Tick += new System.EventHandler(this.tmrUpdateOpenROMCount_Tick);
            // 
            // cmdPurchases
            // 
            this.cmdPurchases.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPurchases.Location = new System.Drawing.Point(313, 39);
            this.cmdPurchases.Name = "cmdPurchases";
            this.cmdPurchases.Size = new System.Drawing.Size(109, 48);
            this.cmdPurchases.TabIndex = 6;
            this.cmdPurchases.Text = "Incoming Inventory";
            this.cmdPurchases.UseVisualStyleBackColor = true;
            this.cmdPurchases.Click += new System.EventHandler(this.cmdPurchases_Click);
            // 
            // cmdCustomerDispatch
            // 
            this.cmdCustomerDispatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCustomerDispatch.Location = new System.Drawing.Point(337, 95);
            this.cmdCustomerDispatch.Name = "cmdCustomerDispatch";
            this.cmdCustomerDispatch.Size = new System.Drawing.Size(183, 48);
            this.cmdCustomerDispatch.TabIndex = 6;
            this.cmdCustomerDispatch.Text = "Customer Dispatch";
            this.cmdCustomerDispatch.UseVisualStyleBackColor = true;
            this.cmdCustomerDispatch.Click += new System.EventHandler(this.cmdCustomerDispatch_Click);
            // 
            // visualStyler1
            // 
            this.visualStyler1.HookVisualStyles = true;
            this.visualStyler1.License = ((SkinSoft.VisualStyler.Licensing.VisualStylerLicense)(resources.GetObject("visualStyler1.License")));
            this.visualStyler1.LoadVisualStyle("Office2007 (Blue).vssf");
            // 
            // cmdProductionLine
            // 
            this.cmdProductionLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdProductionLine.Location = new System.Drawing.Point(313, 150);
            this.cmdProductionLine.Name = "cmdProductionLine";
            this.cmdProductionLine.Size = new System.Drawing.Size(109, 48);
            this.cmdProductionLine.TabIndex = 6;
            this.cmdProductionLine.Text = "Production Advice";
            this.cmdProductionLine.UseVisualStyleBackColor = true;
            this.cmdProductionLine.Click += new System.EventHandler(this.cmdProductionLine_Click);
            // 
            // tmrCloseWindow
            // 
            this.tmrCloseWindow.Interval = 180000;
            this.tmrCloseWindow.Tick += new System.EventHandler(this.tmrCloseWindow_Tick);
            // 
            // cmdPurchaseMatching
            // 
            this.cmdPurchaseMatching.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPurchaseMatching.Location = new System.Drawing.Point(427, 39);
            this.cmdPurchaseMatching.Name = "cmdPurchaseMatching";
            this.cmdPurchaseMatching.Size = new System.Drawing.Size(109, 48);
            this.cmdPurchaseMatching.TabIndex = 6;
            this.cmdPurchaseMatching.Text = "Match to Invoice";
            this.cmdPurchaseMatching.UseVisualStyleBackColor = true;
            this.cmdPurchaseMatching.Click += new System.EventHandler(this.cmdPurchaseMatching_Click);
            // 
            // cmdBOMChangeRequest
            // 
            this.cmdBOMChangeRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBOMChangeRequest.Location = new System.Drawing.Point(427, 150);
            this.cmdBOMChangeRequest.Name = "cmdBOMChangeRequest";
            this.cmdBOMChangeRequest.Size = new System.Drawing.Size(109, 48);
            this.cmdBOMChangeRequest.TabIndex = 6;
            this.cmdBOMChangeRequest.Text = "BOM Change Request";
            this.cmdBOMChangeRequest.UseVisualStyleBackColor = true;
            this.cmdBOMChangeRequest.Click += new System.EventHandler(this.cmdBOMChangeRequest_Click);
            // 
            // frmMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 293);
            this.Controls.Add(this.cmdBOMChangeRequest);
            this.Controls.Add(this.cmdProductionLine);
            this.Controls.Add(this.cmdCustomerDispatch);
            this.Controls.Add(this.cmdPurchaseMatching);
            this.Controls.Add(this.cmdPurchases);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdMove);
            this.Controls.Add(this.cmdOrder);
            this.Controls.Add(this.cmdRequest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMainWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  Materials Management (9.0a)";
            this.Load += new System.EventHandler(this.frmMainWindow_Load);
            this.DoubleClick += new System.EventHandler(this.frmMainWindow_DoubleClick);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMainWindow_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visualStyler1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdRequest;
        private System.Windows.Forms.Button cmdOrder;
        private System.Windows.Forms.Button cmdMove;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuSettingsMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuDataBaseConnection;
        private System.Windows.Forms.ToolStripMenuItem mnuStaitonAccess;
        private System.Windows.Forms.ToolStripMenuItem mnuProcessAccess;
        private System.Windows.Forms.ToolStripMenuItem mnuWarehouseAccess;
        private System.Windows.Forms.Timer tmrUpdateOpenROMCount;
        private System.Windows.Forms.Button cmdPurchases;
        private System.Windows.Forms.Button cmdCustomerDispatch;
        private SkinSoft.VisualStyler.VisualStyler visualStyler1;
        private System.Windows.Forms.Button cmdProductionLine;
        private System.Windows.Forms.Timer tmrCloseWindow;
        private System.Windows.Forms.Button cmdPurchaseMatching;
        private System.Windows.Forms.ToolStripMenuItem mnuReports;
        private System.Windows.Forms.ToolStripMenuItem mnuInventoryReciepts;
        private System.Windows.Forms.ToolStripMenuItem mnuDeliveryOrders;
        private System.Windows.Forms.Button cmdBOMChangeRequest;
        private System.Windows.Forms.ToolStripMenuItem mnuBOM;
    }
}