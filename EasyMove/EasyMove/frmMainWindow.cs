using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace EasyMove
{
    public partial class frmMainWindow : Form
    {
        public frmMainWindow()
        {
            InitializeComponent();
        }

        int recentOpenMovement = 0;
        string styleName = "";

        dataBuilder getDataFromDb = new dataBuilder();
        businessRule getDataAccordingToRule = new businessRule();


        private string getNextInterfaceName()
        {
            if (this.styleName == "Aero (Black).vssf")
            {
                this.styleName = "Aero (Blue).vssf";
                return "Skins\\Aero (Blue).vssf";
            }
            else if (this.styleName == "Aero (Blue).vssf")
            {
                this.styleName = "Aero (Silver).vssf";
                return "Skins\\Aero (Silver).vssf";
            }
            else if (this.styleName == "Aero (Silver).vssf")
            {
                this.styleName = "Office2007 (Black).vssf";
                return "Skins\\Office2007 (Black).vssf";
            }
            else if (this.styleName == "Office2007 (Black).vssf")
            {
                this.styleName = "Office2007 (Blue).vssf";
                return "Skins\\Office2007 (Blue).vssf";
            }
            else if (this.styleName == "Office2007 (Blue).vssf")
            {
                this.styleName = "Office2007 (Silver).vssf";
                return "Skins\\Office2007 (Silver).vssf";
            }
            else if (this.styleName == "Office2007 (Silver).vssf")
            {
                this.styleName = "OSX (Aqua).vssf";
                return "Skins\\OSX (Aqua).vssf";
            }
            else if (this.styleName == "OSX (Aqua).vssf")
            {
                this.styleName = "OSX (Brushed).vssf";
                return "Skins\\OSX (Brushed).vssf";
            }
            else if (this.styleName == "OSX (Brushed).vssf")
            {
                this.styleName = "OSX (iTunes).vssf";
                return "Skins\\OSX (iTunes).vssf";
            }
            else if (this.styleName == "OSX (iTunes).vssf")
            {
                this.styleName = "OSX (Leopard).vssf";
                return "Skins\\OSX (Leopard).vssf";
            }
            else if (this.styleName == "OSX (Leopard).vssf")
            {
                this.styleName = "OSX (Panther).vssf";
                return "Skins\\OSX (Panther).vssf";
            }
            else if (this.styleName == "OSX (Panther).vssf")
            {
                this.styleName = "OSX (Tiger).vssf";
                return "Skins\\OSX (Tiger).vssf";
            }
            else if (this.styleName == "OSX (Tiger).vssf")
            {
                this.styleName = "Vista (Aero).vssf";
                return "Skins\\Vista (Aero).vssf";
            }
            else if (this.styleName == "Vista (Aero).vssf")
            {
                this.styleName = "Vista (Basic).vssf";
                return "Skins\\Vista (Basic).vssf";
            }
            else if (this.styleName == "Vista (Basic).vssf")
            {
                this.styleName = "Vista (Black).vssf";
                return "Skins\\Vista (Black).vssf";
            }
            else if (this.styleName == "Vista (Black).vssf")
            {
                this.styleName = "Vista (Blue).vssf";
                return "Skins\\Vista (Blue).vssf";
            }
            else if (this.styleName == "Vista (Blue).vssf")
            {
                this.styleName = "Vista (Green).vssf";
                return "Skins\\Vista (Green).vssf";
            }
            else if (this.styleName == "Vista (Green).vssf")
            {
                this.styleName = "Vista (Silver).vssf";
                return "Skins\\Vista (Silver).vssf";
            }
            else if (this.styleName == "Vista (Silver).vssf")
            {
                this.styleName = "Vista (Teal).vssf";
                return "Skins\\Vista (Teal).vssf";
            }
            else if (this.styleName == "Vista (Teal).vssf")
            {
                this.styleName = "XP (Blue).vssf";
                return "Skins\\XP (Blue).vssf";
            }
            else if (this.styleName == "XP (Blue).vssf")
            {
                this.styleName = "XP (Olive).vssf";
                return "Skins\\XP (Olive).vssf";
            }
            else if (this.styleName == "XP (Olive).vssf")
            {
                this.styleName = "XP (Royale).vssf";
                return "Skins\\XP (Royale).vssf";
            }
            else if (this.styleName == "XP (Royale).vssf")
            {
                this.styleName = "XP (Silver).vssf";
                return "Skins\\XP (Silver).vssf";
            }
            else
            {
                this.styleName = "Aero (Black).vssf";
                return "Skins\\Aero (Black).vssf";
            }
        }

        private void changeUserInterface()
        {
            this.visualStyler1.LoadVisualStyle(this.getNextInterfaceName());
            dbSettingInformationHandler.theme = this.styleName;
        }

        private int getOpenSelesOrderRecord()
        {
            DataRow criteriaValue;

            DataTable openMovementCriterion = new DataTable();

            openMovementCriterion.Columns.Add("Field");
            openMovementCriterion.Columns.Add("Criterion");
            openMovementCriterion.Columns.Add("Value");

            criteriaValue = openMovementCriterion.NewRow();
            criteriaValue["Field"] = "QTYRESERVED";
            criteriaValue["Criterion"] = "!=";
            criteriaValue["Value"] = "0";
            openMovementCriterion.Rows.Add(criteriaValue);

            string query =
                this.getDataFromDb.createTheCriteriaClause(openMovementCriterion, "AND", "");

            openMovementCriterion.Rows.Clear();

            DataTable userViewableLocatorInfo =
                        this.getDataAccordingToRule.getUserAccessableLocators("", triStateBool.ignor, taskType.Out);


            for (int locatorRowCounter = userViewableLocatorInfo.Rows.Count - 1;
                locatorRowCounter >= 0; locatorRowCounter--)
            {
                criteriaValue = openMovementCriterion.NewRow();
                criteriaValue["Field"] = "M_WAREHOUSE_ID";
                criteriaValue["Criterion"] = "=";
                criteriaValue["Value"] = userViewableLocatorInfo.
                                                Rows[locatorRowCounter]["M_WAREHOUSE_ID"].ToString();
                openMovementCriterion.Rows.Add(criteriaValue);                
            }

            query = query + this.getDataFromDb.createTheCriteriaClause(openMovementCriterion, "OR", "AND");

            DataTable outstandingSalesOrder =
                this.getDataFromDb.getV_SALESORDERDETAILInfo(null, "", "", "", "", "", "", "",
                    "", "", true, false, "AND", query, "AND");

            if (!this.getDataFromDb.checkIfTableContainesData(outstandingSalesOrder))
                return 0;

            outstandingSalesOrder =
                this.getDataFromDb.clearRedundantRow(outstandingSalesOrder, "C_ORDER_ID");

            if (!this.getDataFromDb.checkIfTableContainesData(outstandingSalesOrder))
                return 0;

            return outstandingSalesOrder.Rows.Count;
        }

        
        private void cmdRequest_Click(object sender, EventArgs e)
        {
            generalResultInformation.searchCritrion.Clear();
            generalResultInformation.searchResult.Clear();

            this.tmrCloseWindow.Enabled = false;
            new frmInventoryRequest().ShowDialog();
            this.tmrCloseWindow.Enabled = true;
        }

        private void cmdOrder_Click(object sender, EventArgs e)
        {
            generalResultInformation.searchCritrion.Clear();
            generalResultInformation.searchResult.Clear();

            this.tmrCloseWindow.Enabled = false;
            new frmInventoryTransferOrder().ShowDialog();
            this.tmrCloseWindow.Enabled = true;
        }

        private void cmdMove_Click(object sender, EventArgs e)
        {
            if (!this.getDataFromDb.isStockCorrect())
            {
                MessageBox.Show("The system suffers negative stock." +
                        " Please correct them soon.\n ", "KPI info",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1);
            }

            generalResultInformation.searchCritrion.Clear();
            generalResultInformation.searchResult.Clear();

            generalResultInformation.openTransferCount = 
                this.recentOpenMovement;
            
            this.tmrCloseWindow.Enabled = false;
            new frmInventoryMove().ShowDialog();
            this.tmrCloseWindow.Enabled = true;
        }

        private void cmdPurchases_Click(object sender, EventArgs e)
        {
            generalResultInformation.searchCritrion.Clear();
            generalResultInformation.searchResult.Clear();

            this.tmrCloseWindow.Enabled = false;
            new frmInventoryIn().ShowDialog();
            this.tmrCloseWindow.Enabled = true;
        }
        
        private void cmdPurchaseMatching_Click(object sender, EventArgs e)
        {
            //generalResultInformation.searchCritrion.Clear();
            //generalResultInformation.searchResult.Clear();

            //this.tmrCloseWindow.Enabled = false;
            //new frmMatchInvoices().ShowDialog();
            //this.tmrCloseWindow.Enabled = true;

        }        
        
        private void cmdCustomerDispatch_Click(object sender, EventArgs e)
        {
            generalResultInformation.searchCritrion.Clear();
            generalResultInformation.searchResult.Clear();

            this.tmrCloseWindow.Enabled = false;
            new frmInventoryOut().ShowDialog();
            this.tmrCloseWindow.Enabled = true;
        }

        private void cmdProductionLine_Click(object sender, EventArgs e)
        {
            generalResultInformation.searchCritrion.Clear();
            generalResultInformation.searchResult.Clear();

            this.tmrCloseWindow.Enabled = false;
            new frmInventoryMake().ShowDialog();
            this.tmrCloseWindow.Enabled = true;
        }

        private void cmdBOMChangeRequest_Click(object sender, EventArgs e)
        {
            generalResultInformation.searchCritrion.Clear();
            generalResultInformation.searchResult.Clear();

            this.tmrCloseWindow.Enabled = false;
            new frmBOMChange().ShowDialog();
            this.tmrCloseWindow.Enabled = true;
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void frmMainWindow_Load(object sender, EventArgs e)
        {
            this.visualStyler1.LoadVisualStyle(dbSettingInformationHandler.theme);
            this.tmrCloseWindow.Enabled = true;

            this.mnuSettingsMenu.Enabled = generalResultInformation.userCanEditSettings;

            this.tmrUpdateOpenROMCount.Enabled = true;
            this.tmrUpdateOpenROMCount_Tick(sender, e);

            this.getDataAccordingToRule.setUpuserViewPrevilage(generalResultInformation.userId, 
                generalResultInformation.Station);

            this.cmdRequest.Enabled =
                userAccessPrevilageInformation.canViewRequest;
            this.cmdOrder.Enabled =
                userAccessPrevilageInformation.canViewOrder;
            this.cmdMove.Enabled =
                userAccessPrevilageInformation.canViewDispatch ||
                userAccessPrevilageInformation.canViewDelivery;
            this.cmdPurchases.Enabled =
                userAccessPrevilageInformation.canViewInventoryIn;
            this.cmdPurchaseMatching.Enabled =
                userAccessPrevilageInformation.canViewInventoryIn;
            this.cmdProductionLine.Enabled =
                userAccessPrevilageInformation.canViewInventoryMake;
            this.cmdCustomerDispatch.Enabled =
                userAccessPrevilageInformation.canViewInventoryOut;
            this.cmdBOMChangeRequest.Enabled =
                userAccessPrevilageInformation.canViewProductMakeUPChange;

            this.mnuDeliveryOrders.Enabled = userAccessPrevilageInformation.canViewInventoryOut;
            //this.mnuInventoryReciepts.Enabled = userAccessPrevilageInformation.canViewInventoryIn;
            this.mnuBOM.Enabled = userAccessPrevilageInformation.canViewInventoryMake ||
                    userAccessPrevilageInformation.canViewProductMakeUPChange;

        }

        private void frmMainWindow_DoubleClick(object sender, EventArgs e)
        {
            this.changeUserInterface();
        }

        private void frmMainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            string settingFile = dbSettingInformationHandler.settingFilePath;
            DataTable dtSettingsTable =
                this.getDataAccordingToRule.readEncryptedXmlSettingFile(settingFile);

            bool settingFound = false;

            try
            {
                foreach (DataRow dr in dtSettingsTable.Rows)
                {
                    if (dr["Parameter_Name"].ToString() == "theme")
                    {
                        dr["Parameter_Value"] = dbSettingInformationHandler.theme;
                        settingFound = true;
                        break;
                    }
                }
                if (!settingFound)
                {
                    DataRow dr = dtSettingsTable.NewRow();
                    dr["Parameter_Name"] = "theme";
                    dr["Parameter_Value"] = dbSettingInformationHandler.theme;
                    dtSettingsTable.Rows.Add(dr);
                }
                this.getDataAccordingToRule.writeDatatableToEncryptedXmlSettingFile(dtSettingsTable, settingFile);
            }
            catch
            {
            }
        }


        private void mnuDataBaseConnection_Click(object sender, EventArgs e)
        {
            this.tmrCloseWindow.Enabled = false;
            new frmsettings().ShowDialog(this);
            this.tmrCloseWindow.Enabled = true;
        }

        private void mnuStationAccess_Click(object sender, EventArgs e)
        {
            //this.tmrCloseWindow.Enabled = false;
            //new frmUserSationAccess().ShowDialog(this);
            //this.tmrCloseWindow.Enabled = true;
        }

        private void mnuProcessAccess_Click(object sender, EventArgs e)
        {
            this.tmrCloseWindow.Enabled = false;
            new frmUserProcessAccess().ShowDialog(this);
            this.tmrCloseWindow.Enabled = true;
        }

        private void mnuWarehouseAccess_Click(object sender, EventArgs e)
        {
            this.tmrCloseWindow.Enabled = false;
            new frmUserWarehouseAccess().ShowDialog(this);
            this.tmrCloseWindow.Enabled = true;
        }

        

        private void tmrUpdateOpenROMCount_Tick(object sender, EventArgs e)
        {
            DataTable openROMCount =
                this.getDataFromDb.getOPEN_ROMInfo();

            this.cmdRequest.Text = "Transfer Request";
            this.cmdOrder.Text = "Transfer Order";
            this.cmdMove.Text = "Transfers";
                        
            this.cmdCustomerDispatch.Text = "Customer Dispatch { " +
                this.getOpenSelesOrderRecord().ToString() + " }";

            if (this.getDataFromDb.checkIfTableContainesData(openROMCount))
            {
                this.cmdRequest.Text = "Transfer Request { " +
                    openROMCount.Rows[0]["OPEN_COUNT"].ToString() + " }";

                this.cmdOrder.Text = "Transfer Order { " +
                    openROMCount.Rows[1]["OPEN_COUNT"].ToString() + " }";

                this.cmdMove.Text = "Transfers { " +
                    openROMCount.Rows[2]["OPEN_COUNT"].ToString() + " }";

                this.recentOpenMovement = 
                    int.Parse(openROMCount.Rows[3]["OPEN_COUNT"].ToString());
            }

        }

        private void tmrCloseWindow_Tick(object sender, EventArgs e)
        {
            this.Close();
        }


        private void mnuDeliveryOrders_Click(object sender, EventArgs e)
        {            
            this.tmrCloseWindow.Enabled = false;

            if (!System.IO.File.Exists("crptDeliveryOrder.rpt"))
            {                
                MessageBox.Show("Unable To find Crystal Report. \n Contact Your Administrator.",
                    "Printing", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                return;
            }

            generalResultInformation.searchResult = new DataTable();
            frmSearchDeliveryOrder frmSearchDeliveryOrder = new frmSearchDeliveryOrder();

            frmSearchDeliveryOrder.ShowDialog();


            dtsMovementInfo dsDeliveryOrderInfo = new dtsMovementInfo();

            dsDeliveryOrderInfo.Tables["dtSalesOrderDetail"].Clear();

            DataTable deliveryOrderInfo = 
                generalResultInformation.searchResult.Copy();

            if (!this.getDataFromDb.checkIfTableContainesData(deliveryOrderInfo))
            {
                return;
            }

            deliveryOrderInfo.Columns["C_ORDER_ID"].ColumnName = "OrderID";
            deliveryOrderInfo.Columns["C_ORDERLINE_ID"].ColumnName = "OrderLineID";

            deliveryOrderInfo.Columns["DELIVERYORDERNO"].ColumnName = "DeliveryOrder";
            deliveryOrderInfo.Columns["DOCUMENTNO"].ColumnName = "SalesRef";
            deliveryOrderInfo.Columns["QTYORDERED"].ColumnName = "Ordered";
            deliveryOrderInfo.Columns["QTYDELIVERED"].ColumnName = "Delivered";
            deliveryOrderInfo.Columns["QTYRESERVED"].ColumnName = "Pending";



            deliveryOrderInfo.Columns["OrderID"].SetOrdinal(0);
            deliveryOrderInfo.Columns["OrderLineID"].SetOrdinal(1);
            deliveryOrderInfo.Columns["DeliveryOrder"].SetOrdinal(2);
            deliveryOrderInfo.Columns["Store"].SetOrdinal(3);
            deliveryOrderInfo.Columns["SalesRef"].SetOrdinal(4);
            deliveryOrderInfo.Columns["DateOrdered"].SetOrdinal(5);
            deliveryOrderInfo.Columns["Customer"].SetOrdinal(6);
            deliveryOrderInfo.Columns["Line"].SetOrdinal(7);
            deliveryOrderInfo.Columns["Product"].SetOrdinal(8);
            deliveryOrderInfo.Columns["Unit"].SetOrdinal(9);
            deliveryOrderInfo.Columns["Ordered"].SetOrdinal(10);
            deliveryOrderInfo.Columns["Delivered"].SetOrdinal(11);
            deliveryOrderInfo.Columns["Pending"].SetOrdinal(12);



            foreach (DataRow dr in deliveryOrderInfo.Rows)
            {
                dsDeliveryOrderInfo.Tables["dtSalesOrderDetail"].ImportRow(dr);
            }

            crptDeliveryOrder crptDeliveryOrder = new crptDeliveryOrder();

            crptDeliveryOrder.Refresh();
            crptDeliveryOrder.FileName = "crptDeliveryOrder.rpt";

            crptDeliveryOrder.SetDataSource(dsDeliveryOrderInfo);


            CrystalDecisions.Windows.Forms.CrystalReportViewer DOPrintPreview =
                new CrystalDecisions.Windows.Forms.CrystalReportViewer();

            Form preveiwForm = new Form();

            preveiwForm.Size = new System.Drawing.Size(700, 1000);

            preveiwForm.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            preveiwForm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            preveiwForm.ClientSize = new System.Drawing.Size(676, 688);

            preveiwForm.Controls.Add(DOPrintPreview);

            //preveiwForm.DoubleBuffered = true;
            preveiwForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            //preveiwForm.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));

            //preveiwForm.MaximizeBox = false;
            preveiwForm.Name = "frmPrintPreview";
            preveiwForm.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            preveiwForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            preveiwForm.Text = "Delivery Order";          
            
            this.ResumeLayout(false);
            this.PerformLayout();




            DOPrintPreview.ActiveViewIndex = 0;
            DOPrintPreview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            DOPrintPreview.DisplayGroupTree = false;
            DOPrintPreview.DisplayStatusBar = false;
            DOPrintPreview.EnableDrillDown = false;
            DOPrintPreview.Location = new System.Drawing.Point(3, 3);
            DOPrintPreview.Name = "DOPrintPreview";
            DOPrintPreview.ReportSource = crptDeliveryOrder;
            DOPrintPreview.ShowCloseButton = false;
            //DOPrintPreview.ShowExportButton = false;
            //DOPrintPreview.ShowGotoPageButton = false;
            DOPrintPreview.ShowGroupTreeButton = false;
            //DOPrintPreview.ShowPrintButton = false;
            DOPrintPreview.ShowRefreshButton = false;
            //DOPrintPreview.ShowTextSearchButton = false;
            DOPrintPreview.Size = new System.Drawing.Size(670, 54);
            DOPrintPreview.TabIndex = 17;
            DOPrintPreview.TabStop = false;
            DOPrintPreview.Visible = false;
            DOPrintPreview.Dock = DockStyle.Fill;
            
            DOPrintPreview.Zoom(100);
            DOPrintPreview.Show();

            preveiwForm.ShowDialog();

            this.tmrCloseWindow.Enabled = true;

        }

        private void mnuBOM_Click(object sender, EventArgs e)
        {
            this.tmrCloseWindow.Enabled = false;

            if (!System.IO.File.Exists("crptProductBOM.rpt"))
            {
                MessageBox.Show("Unable To find Crystal Report. \n Contact Your Administrator.",
                    "Printing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            generalResultInformation.searchResult = new DataTable();
            frmSearchBOM frmSearchBOM = new frmSearchBOM();

            frmSearchBOM.ShowDialog();


            dtsMovementInfo dsDeliveryOrderInfo = new dtsMovementInfo();

            dsDeliveryOrderInfo.Tables["dtSalesOrderDetail"].Clear();

            DataTable deliveryOrderInfo =
                generalResultInformation.searchResult.Copy();

            if (!this.getDataFromDb.checkIfTableContainesData(deliveryOrderInfo))
            {
                return;
            }

            deliveryOrderInfo.Columns["C_ORDER_ID"].ColumnName = "OrderID";
            deliveryOrderInfo.Columns["C_ORDERLINE_ID"].ColumnName = "OrderLineID";

            deliveryOrderInfo.Columns["QTYORDERED"].ColumnName = "Ordered";



            deliveryOrderInfo.Columns["OrderID"].SetOrdinal(0);
            deliveryOrderInfo.Columns["OrderLineID"].SetOrdinal(1);
            deliveryOrderInfo.Columns["Customer"].SetOrdinal(2);
            deliveryOrderInfo.Columns["Line"].SetOrdinal(3);
            deliveryOrderInfo.Columns["Product"].SetOrdinal(4);
            deliveryOrderInfo.Columns["Unit"].SetOrdinal(5);
            deliveryOrderInfo.Columns["Ordered"].SetOrdinal(6);



            foreach (DataRow dr in deliveryOrderInfo.Rows)
            {
                dsDeliveryOrderInfo.Tables["dtSalesOrderDetail"].ImportRow(dr);
            }

            crptDeliveryOrder crptDeliveryOrder = new crptDeliveryOrder();

            crptDeliveryOrder.Refresh();
            crptDeliveryOrder.FileName = "crptProductBOM.rpt";

            crptDeliveryOrder.SetDataSource(dsDeliveryOrderInfo);


            CrystalDecisions.Windows.Forms.CrystalReportViewer DOPrintPreview =
                new CrystalDecisions.Windows.Forms.CrystalReportViewer();

            Form preveiwForm = new Form();

            preveiwForm.Size = new System.Drawing.Size(700, 1000);

            preveiwForm.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            preveiwForm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            preveiwForm.ClientSize = new System.Drawing.Size(676, 688);

            preveiwForm.Controls.Add(DOPrintPreview);

            //preveiwForm.DoubleBuffered = true;
            preveiwForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            //preveiwForm.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));

            //preveiwForm.MaximizeBox = false;
            preveiwForm.Name = "frmPrintPreview";
            preveiwForm.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            preveiwForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            preveiwForm.Text = "Product Bill Of Material";

            this.ResumeLayout(false);
            this.PerformLayout();




            DOPrintPreview.ActiveViewIndex = 0;
            DOPrintPreview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            DOPrintPreview.DisplayGroupTree = false;
            DOPrintPreview.DisplayStatusBar = false;
            DOPrintPreview.EnableDrillDown = false;
            DOPrintPreview.Location = new System.Drawing.Point(3, 3);
            DOPrintPreview.Name = "DOPrintPreview";
            DOPrintPreview.ReportSource = crptDeliveryOrder;
            DOPrintPreview.ShowCloseButton = false;
            //DOPrintPreview.ShowExportButton = true;
            //DOPrintPreview.ShowGotoPageButton = false;
            DOPrintPreview.ShowGroupTreeButton = false;
            //DOPrintPreview.ShowPrintButton = false;
            DOPrintPreview.ShowRefreshButton = false;
            //DOPrintPreview.ShowTextSearchButton = false;
            DOPrintPreview.Size = new System.Drawing.Size(670, 54);
            DOPrintPreview.TabIndex = 17;
            DOPrintPreview.TabStop = false;
            DOPrintPreview.Visible = false;
            DOPrintPreview.Dock = DockStyle.Fill;

            DOPrintPreview.Zoom(100);
            DOPrintPreview.Show();

            preveiwForm.ShowDialog();

            this.tmrCloseWindow.Enabled = true;

            
        }

        private void mnuInventoryReciepts_Click(object sender, EventArgs e)
        {

        }



    }
}
