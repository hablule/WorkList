using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SRP
{
    public partial class frmMainWindow : Form
    {
        public frmMainWindow()
        {
            InitializeComponent();
        }

       
        string[] readOnlyFormList;
        string styleName = "";
        int formListCounter = 0;

        dataBuilder getDatafromDataBase = new dataBuilder();

        private void setCurrentUserFormAccessPrivilages()
        {
            if (!generalResultInformation.formNameList.Contains<String>("ndUsers"))
                frmAccessPrivilages.accFrmUsers = accessLevel.InActive;
            else if (generalResultInformation.hiddenFormNameList.Contains<String>("ndUsers"))
                frmAccessPrivilages.accFrmUsers = accessLevel.ReadOnly;
            else
                frmAccessPrivilages.accFrmUsers = accessLevel.ReadWite;


            if (!generalResultInformation.formNameList.Contains<String>("ndStations"))
                frmAccessPrivilages.accFrmStations = accessLevel.InActive;
            else if (generalResultInformation.hiddenFormNameList.Contains<String>("ndStations"))
                frmAccessPrivilages.accFrmStations = accessLevel.ReadOnly;
            else
                frmAccessPrivilages.accFrmStations = accessLevel.ReadWite;


            if (!generalResultInformation.formNameList.Contains<String>("ndCityAndLocality"))
                frmAccessPrivilages.accFrmCitiesAndLocalites = accessLevel.InActive;
            else if (generalResultInformation.hiddenFormNameList.Contains<String>("ndCityAndLocality"))
                frmAccessPrivilages.accFrmCitiesAndLocalites = accessLevel.ReadOnly;
            else
                frmAccessPrivilages.accFrmCitiesAndLocalites = accessLevel.ReadWite;


            if (!generalResultInformation.formNameList.Contains<String>("ndBpartner"))
                frmAccessPrivilages.accFrmBpartner = accessLevel.InActive;
            else if (generalResultInformation.hiddenFormNameList.Contains<String>("ndBpartner"))
                frmAccessPrivilages.accFrmBpartner = accessLevel.ReadOnly;
            else
                frmAccessPrivilages.accFrmBpartner = accessLevel.ReadWite;


            if (!generalResultInformation.formNameList.Contains<String>("ndUOM"))
                frmAccessPrivilages.accFrmUOM = accessLevel.InActive;
            else if (generalResultInformation.hiddenFormNameList.Contains<String>("ndUOM"))
                frmAccessPrivilages.accFrmUOM = accessLevel.ReadOnly;
            else
                frmAccessPrivilages.accFrmUOM = accessLevel.ReadWite;


            if (!generalResultInformation.formNameList.Contains<String>("ndUnitConversion"))
                frmAccessPrivilages.accFrmUOMConversion = accessLevel.InActive;
            else if (generalResultInformation.hiddenFormNameList.Contains<String>("ndUnitConversion"))
                frmAccessPrivilages.accFrmUOMConversion = accessLevel.ReadOnly;
            else
                frmAccessPrivilages.accFrmUOMConversion = accessLevel.ReadWite;

            if (!generalResultInformation.formNameList.Contains<String>("ndCategory"))
                frmAccessPrivilages.accFrmPrdCategory = accessLevel.InActive;
            else if (generalResultInformation.hiddenFormNameList.Contains<String>("ndCategory"))
                frmAccessPrivilages.accFrmPrdCategory = accessLevel.ReadOnly;
            else
                frmAccessPrivilages.accFrmPrdCategory = accessLevel.ReadWite;

            if (!generalResultInformation.formNameList.Contains<String>("ndProducts"))
                frmAccessPrivilages.accFrmProduct = accessLevel.InActive;
            else if (generalResultInformation.hiddenFormNameList.Contains<String>("ndProducts"))
                frmAccessPrivilages.accFrmProduct = accessLevel.ReadOnly;
            else
                frmAccessPrivilages.accFrmProduct = accessLevel.ReadWite;


            if (!generalResultInformation.formNameList.Contains<String>("ndWarehouse"))
                frmAccessPrivilages.accFrmWareHouse = accessLevel.InActive;
            else if (generalResultInformation.hiddenFormNameList.Contains<String>("ndWarehouse"))
                frmAccessPrivilages.accFrmWareHouse = accessLevel.ReadOnly;
            else
                frmAccessPrivilages.accFrmWareHouse = accessLevel.ReadWite;


            if (!generalResultInformation.formNameList.Contains<String>("ndInventoryIn"))
                frmAccessPrivilages.accFrmInventoryIn = accessLevel.InActive;
            else if (generalResultInformation.hiddenFormNameList.Contains<String>("ndInventoryIn"))
                frmAccessPrivilages.accFrmInventoryIn = accessLevel.ReadOnly;
            else
                frmAccessPrivilages.accFrmInventoryIn = accessLevel.ReadWite;


            if (!generalResultInformation.formNameList.Contains<String>("ndInventoryOut"))
                frmAccessPrivilages.accFrmInventoryOut = accessLevel.InActive;
            else if (generalResultInformation.hiddenFormNameList.Contains<String>("ndInventoryOut"))
                frmAccessPrivilages.accFrmInventoryOut = accessLevel.ReadOnly;
            else
                frmAccessPrivilages.accFrmInventoryOut = accessLevel.ReadWite;

            if (!generalResultInformation.formNameList.Contains<String>("ndInventoryMove"))
                frmAccessPrivilages.accFrmInventoryMove = accessLevel.InActive;
            else if (generalResultInformation.hiddenFormNameList.Contains<String>("ndInventoryMove"))
                frmAccessPrivilages.accFrmInventoryMove = accessLevel.ReadOnly;
            else
                frmAccessPrivilages.accFrmInventoryMove = accessLevel.ReadWite;


            if (!generalResultInformation.formNameList.Contains<String>("ndPhysicalInventory"))
                frmAccessPrivilages.accFrmPhysicalInventory = accessLevel.InActive;
            else if (generalResultInformation.hiddenFormNameList.Contains<String>("ndPhysicalInventory"))
                frmAccessPrivilages.accFrmPhysicalInventory = accessLevel.ReadOnly;
            else
                frmAccessPrivilages.accFrmPhysicalInventory = accessLevel.ReadWite;


            if (!generalResultInformation.formNameList.Contains<String>("ndInternalUse"))
                frmAccessPrivilages.accFrmInventoryUse = accessLevel.InActive;
            else if (generalResultInformation.hiddenFormNameList.Contains<String>("ndInternalUse"))
                frmAccessPrivilages.accFrmInventoryUse = accessLevel.ReadOnly;
            else
                frmAccessPrivilages.accFrmInventoryUse = accessLevel.ReadWite;


            if (!generalResultInformation.formNameList.Contains<String>("ndMergeEntity"))
                frmAccessPrivilages.accFrmMergeEntity = accessLevel.InActive;
            else if (generalResultInformation.hiddenFormNameList.Contains<String>("ndMergeEntity"))
                frmAccessPrivilages.accFrmMergeEntity = accessLevel.ReadOnly;
            else
                frmAccessPrivilages.accFrmMergeEntity = accessLevel.ReadWite;

            if (!generalResultInformation.formNameList.Contains<String>("ndCleanStorage"))
                frmAccessPrivilages.accFrmCleanStorage = accessLevel.InActive;
            else if (generalResultInformation.hiddenFormNameList.Contains<String>("ndCleanStorage"))
                frmAccessPrivilages.accFrmCleanStorage = accessLevel.ReadOnly;
            else
                frmAccessPrivilages.accFrmCleanStorage = accessLevel.ReadWite;


            if (!generalResultInformation.formNameList.Contains<String>("ndStationAccess"))
                frmAccessPrivilages.accFrmStationAccess = accessLevel.InActive;
            else if (generalResultInformation.hiddenFormNameList.Contains<String>("ndStationAccess"))
                frmAccessPrivilages.accFrmStationAccess = accessLevel.ReadOnly;
            else
                frmAccessPrivilages.accFrmStationAccess = accessLevel.ReadWite;


            if (!generalResultInformation.formNameList.Contains<String>("ndFormAccess"))
                frmAccessPrivilages.accFrmFormAccess = accessLevel.InActive;
            else if (generalResultInformation.hiddenFormNameList.Contains<String>("ndFormAccess"))
                frmAccessPrivilages.accFrmFormAccess = accessLevel.ReadOnly;
            else
                frmAccessPrivilages.accFrmFormAccess = accessLevel.ReadWite;


            if (!generalResultInformation.formNameList.Contains<String>("ndOperationAccess"))
                frmAccessPrivilages.accFrmOperationAccess = accessLevel.InActive;
            else if (generalResultInformation.hiddenFormNameList.Contains<String>("ndOperationAccess"))
                frmAccessPrivilages.accFrmOperationAccess = accessLevel.ReadOnly;
            else
                frmAccessPrivilages.accFrmOperationAccess = accessLevel.ReadWite;

            if (!generalResultInformation.formNameList.Contains<String>("ndWarehouseAccess"))
                frmAccessPrivilages.accFrmWareHouseAccess = accessLevel.InActive;
            else if (generalResultInformation.hiddenFormNameList.Contains<String>("ndWarehouseAccess"))
                frmAccessPrivilages.accFrmWareHouseAccess = accessLevel.ReadOnly;
            else
                frmAccessPrivilages.accFrmWareHouseAccess = accessLevel.ReadWite;


            if (!generalResultInformation.formNameList.Contains<String>("ndClearLog"))
                frmAccessPrivilages.accFrmClearLog = accessLevel.InActive;
            else if (generalResultInformation.hiddenFormNameList.Contains<String>("dbClearLog"))
                frmAccessPrivilages.accFrmClearLog = accessLevel.ReadOnly;
            else
                frmAccessPrivilages.accFrmClearLog = accessLevel.ReadWite;
        }

        private void changeUserInterface()
        {
            if (this.styleName == "Aero (Black).vssf")
            {
                this.styleName = "Aero (Blue).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\Aero (Blue).vssf");
            }
            else if (this.styleName == "Aero (Blue).vssf")
            {
                this.styleName = "Aero (Silver).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\Aero (Silver).vssf");
            }
            else if (this.styleName == "Aero (Silver).vssf")
            {
                this.styleName = "Office2007 (Black).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\Office2007 (Black).vssf");
            }
            else if (this.styleName == "Office2007 (Black).vssf")
            {
                this.styleName = "Office2007 (Blue).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\Office2007 (Blue).vssf");
            }
            else if (this.styleName == "Office2007 (Blue).vssf")
            {
                this.styleName = "Office2007 (Silver).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\Office2007 (Silver).vssf");
            }
            else if (this.styleName == "Office2007 (Silver).vssf")
            {
                this.styleName = "OSX (Aqua).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\OSX (Aqua).vssf");
            }
            else if (this.styleName == "OSX (Aqua).vssf")
            {
                this.styleName = "OSX (Brushed).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\OSX (Brushed).vssf");
            }
            else if (this.styleName == "OSX (Brushed).vssf")
            {
                this.styleName = "OSX (iTunes).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\OSX (iTunes).vssf");
            }
            else if (this.styleName == "OSX (iTunes).vssf")
            {
                this.styleName = "OSX (Leopard).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\OSX (Leopard).vssf");
            }
            else if (this.styleName == "OSX (Leopard).vssf")
            {
                this.styleName = "OSX (Panther).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\OSX (Panther).vssf");
            }
            else if (this.styleName == "OSX (Panther).vssf")
            {
                this.styleName = "OSX (Tiger).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\OSX (Tiger).vssf");
            }
            else if (this.styleName == "OSX (Tiger).vssf")
            {
                this.styleName = "Vista (Aero).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\Vista (Aero).vssf");
            }
            else if (this.styleName == "Vista (Aero).vssf")
            {
                this.styleName = "Vista (Basic).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\Vista (Basic).vssf");
            }
            else if (this.styleName == "Vista (Basic).vssf")
            {
                this.styleName = "Vista (Black).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\Vista (Black).vssf");
            }
            else if (this.styleName == "Vista (Black).vssf")
            {
                this.styleName = "Vista (Blue).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\Vista (Blue).vssf");
            }
            else if (this.styleName == "Vista (Blue).vssf")
            {
                this.styleName = "Vista (Green).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\Vista (Green).vssf");
            }
            else if (this.styleName == "Vista (Green).vssf")
            {
                this.styleName = "Vista (Silver).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\Vista (Silver).vssf");
            }
            else if (this.styleName == "Vista (Silver).vssf")
            {
                this.styleName = "Vista (Teal).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\Vista (Teal).vssf");
            }
            else if (this.styleName == "Vista (Teal).vssf")
            {
                this.styleName = "XP (Blue).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\XP (Blue).vssf");
            }
            else if (this.styleName == "XP (Blue).vssf")
            {
                this.styleName = "XP (Olive).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\XP (Olive).vssf");
            }
            else if (this.styleName == "XP (Olive).vssf")
            {
                this.styleName = "XP (Royale).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\XP (Royale).vssf");
            }
            else if (this.styleName == "XP (Royale).vssf")
            {
                this.styleName = "XP (Silver).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\XP (Silver).vssf");
            }
            else
            {
                this.styleName = "Aero (Black).vssf";
                this.visualStyler1.LoadVisualStyle("Skins\\Aero (Black).vssf");
            }                 
        }

        private void formCurrentUserMenu(TreeNodeCollection formMenuTree)
        {            
            for (int nodeCounter = 0; nodeCounter <= formMenuTree.Count - 1; nodeCounter++)
            {
                generalResultInformation.formNameList[formListCounter++] = 
                    formMenuTree[nodeCounter].Name;
                if (formMenuTree[nodeCounter].Nodes.Count > 0)
                {                    
                    this.formCurrentUserMenu(formMenuTree[nodeCounter].Nodes);
                }
            }            
        }

        private DataTable getAllSubNodes(string formName)
        {
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("FORMNAME");

            if (generalResultInformation.formNameList.Contains<string>(formName))
            {
                DataRow dtRsRow = dtResult.NewRow();
                dtRsRow["FORMNAME"] = formName;
                dtResult.Rows.Add(dtRsRow);

                TreeNode nodeLocation = null;
                
                foreach (TreeNode node in this.trvMainMenu.Nodes)
                {
                    nodeLocation = this.getNode(node, formName);
                    if (nodeLocation != null)
                    {
                        if (nodeLocation.Name == formName)
                            break;
                    }
                }

                if (nodeLocation == null || nodeLocation.Name == "")
                    return dtResult;
                
                if (nodeLocation.Nodes.Count > 0)
                {
                    foreach (TreeNode node in nodeLocation.Nodes)
                    {
                        dtResult =
                            this.getDatafromDataBase.mergeTables(dtResult,
                                this.getAllSubNodes(node.Name), "FORMNAME", false);                        
                    }
                }
            }
            return dtResult;
        }

        private TreeNode getNode(TreeNode nodes, string nodeName)
        {
            TreeNode tncResult = null;

            if (nodes == null || nodes.Name == "")
                return tncResult;
            
            TreeNodeCollection childNodes = null;

            if (nodes.Name == nodeName)
            {
                tncResult = nodes;
            }
            else if(nodes.Nodes.Count > 0)
            {
                childNodes = nodes.Nodes;

                foreach (TreeNode node in childNodes)
                {
                    if (node.Name == nodeName)
                    {
                        tncResult = node;
                        break;
                    }
                    else if (node.Nodes.Count > 0)
                    {
                        tncResult = this.getNode(node, nodeName);
                        if (tncResult != null)
                        {
                            if (tncResult.Name == nodeName)
                                break;
                        }
                    }                    
                }
            }       
            
            return tncResult;
        }

        private void frmMainWindow_Load(object sender, EventArgs e)
        {   
            generalResultInformation.formNameList = 
                new string[this.trvMainMenu.GetNodeCount(true)];
            
            this.trvMainMenu.Nodes["ndConduct"].Expand();
            this.formCurrentUserMenu(this.trvMainMenu.Nodes);            

            DataTable dtHiddenForm =
                this.getDatafromDataBase.getU_FORMACCESS(null, "",
                                        generalResultInformation.Station,
                                        generalResultInformation.userId, "",
                                        accessLevel.InActive, triStateBool.yes,            
                                        false, "AND");

            DataTable dtAllStationHiddenForm =
                this.getDatafromDataBase.getU_FORMACCESS(null, "",
                                        generalResultInformation.allStationRepresentativeKey,
                                        generalResultInformation.userId, "",
                                        accessLevel.InActive, triStateBool.yes,
                                        false, "AND");


            dtHiddenForm = this.getDatafromDataBase.mergeTables(dtHiddenForm,
                    dtAllStationHiddenForm, "", false);

            for (int rowCounter = 0; rowCounter <= dtHiddenForm.Rows.Count - 1; rowCounter++)
            {
                TreeNode nodeLocation = null;
                string formName = dtHiddenForm.Rows[rowCounter]["FORMNAME"].ToString();

                foreach (TreeNode node in this.trvMainMenu.Nodes)
                {
                    nodeLocation = this.getNode(node, formName);
                    if (nodeLocation != null)
                    {
                        if (nodeLocation.Name == formName)
                            break;
                    }
                }

                if (nodeLocation == null || nodeLocation.Name == "")
                    continue;

                nodeLocation.Remove();
            } 

            DataTable dtReadOnlyForm =
                this.getDatafromDataBase.getU_FORMACCESS(null, "",
                                        generalResultInformation.Station,
                                        generalResultInformation.userId, "",
                                        accessLevel.ReadOnly, triStateBool.yes,
                                        false, "AND");

            DataTable dtAllStationReadOnlyForm =
                this.getDatafromDataBase.getU_FORMACCESS(null, "",
                                        generalResultInformation.allStationRepresentativeKey,
                                        generalResultInformation.userId, "",
                                        accessLevel.ReadOnly, triStateBool.yes,
                                        false, "AND");


            dtReadOnlyForm = this.getDatafromDataBase.mergeTables(dtReadOnlyForm,
                    dtAllStationReadOnlyForm, "", false);

            if (this.getDatafromDataBase.checkIfTableContainesData(dtReadOnlyForm))
            {
                DataTable readOnlyTables = new DataTable();
                readOnlyTables.Columns.Add("FORMNAME");

                for (int rowCounter = 0; rowCounter <= dtReadOnlyForm.Rows.Count - 1; rowCounter++)
                {
                    readOnlyTables = this.getDatafromDataBase.mergeTables(readOnlyTables,
                            this.getAllSubNodes(dtReadOnlyForm.Rows[rowCounter]["FORMNAME"].ToString()), 
                            "FORMNAME", false);                    
                }

                readOnlyTables = this.getDatafromDataBase.clearRedundantRow(readOnlyTables, "FORMNAME");

                this.readOnlyFormList =
                    new string[readOnlyTables.Rows.Count];

                for (int rowCounter = 0; rowCounter <= readOnlyTables.Rows.Count - 1; rowCounter++)
                {
                    this.readOnlyFormList[rowCounter] =
                        readOnlyTables.Rows[rowCounter]["FORMNAME"].ToString();
                }
                
                generalResultInformation.hiddenFormNameList =
                    new string [this.readOnlyFormList.Length];

                this.readOnlyFormList.CopyTo
                    (generalResultInformation.hiddenFormNameList, 0);
            }
            this.setCurrentUserFormAccessPrivilages();
        }
                
        private void trvMainMenu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {            
            string stSelectedNodeName = this.trvMainMenu.SelectedNode.Name;

         if (stSelectedNodeName == "ndChangeTheme")
            {
                this.changeUserInterface();
                return;
            }
                
            if (this.tlpMainFormOrganiser.Controls.Count > 1)
            {
                this.tlpMainFormOrganiser.Controls[1].Dispose();//.RemoveAt(1);                
            }
            if (this.readOnlyFormList != null)
            {
                if (this.readOnlyFormList.Contains(stSelectedNodeName))
                    generalResultInformation.currentFormIsReadOnly = true;
                else
                    generalResultInformation.currentFormIsReadOnly = false;
            }

            if (stSelectedNodeName == "ndUsers")
            {
                generalResultInformation.currentTrx = transactionType.None;

                frmUsers frmUsers = new frmUsers();
                this.tlpMainFormOrganiser.Controls.Add(frmUsers, 1, 0);
                frmUsers.Dock = DockStyle.Fill;
                frmUsers.frmUsers_Load(frmUsers, new EventArgs());
            }
            else if (stSelectedNodeName == "ndCityAndLocality")
            {
                generalResultInformation.currentTrx = transactionType.None;

                frmCitiesAndLocalities cityAndLocality = new frmCitiesAndLocalities();
                this.tlpMainFormOrganiser.Controls.Add(cityAndLocality, 1, 0);
                cityAndLocality.Dock = DockStyle.Fill;
                cityAndLocality.frmCitiesAndLocalities_Load(cityAndLocality, new EventArgs());
            }
            else if (stSelectedNodeName == "ndBpartner")
            {
                generalResultInformation.currentTrx = transactionType.None;

                frmBpartner bPartner = new frmBpartner();
                this.tlpMainFormOrganiser.Controls.Add(bPartner, 1, 0);
                bPartner.Dock = DockStyle.Fill;
                bPartner.frmBpartner_Load(bPartner, new EventArgs());
            }
            else if (stSelectedNodeName == "ndUOM")
            {
                generalResultInformation.currentTrx = transactionType.None;

                frmUOM UOM = new frmUOM();
                this.tlpMainFormOrganiser.Controls.Add(UOM, 1, 0);
                UOM.Dock = DockStyle.Fill;
                UOM.frmUOM_Load(UOM, new EventArgs());
            }
            else if (stSelectedNodeName == "ndCategory")
            {
                generalResultInformation.currentTrx = transactionType.None;

                frmPrdCategory prdCategory = new frmPrdCategory();                
                this.tlpMainFormOrganiser.Controls.Add(prdCategory, 1, 0);
                prdCategory.Dock = DockStyle.Fill;
                prdCategory.frmPrdCategory_Load(prdCategory, new EventArgs());
            }
            else if (stSelectedNodeName == "ndProducts")
            {
                generalResultInformation.currentTrx = transactionType.None;

                frmProduct Product = new frmProduct();                
                this.tlpMainFormOrganiser.Controls.Add(Product, 1, 0);
                Product.Dock = DockStyle.Fill;
                Product.frmProduct_Load(Product, new EventArgs());
            }
            else if (stSelectedNodeName == "ndInventoryOut")
            {
                generalResultInformation.currentTrx = transactionType.InventoryOut;

                frmTransaction Transaction = new frmTransaction();
                this.tlpMainFormOrganiser.Controls.Add(Transaction, 1, 0);
                Transaction.Dock = DockStyle.Fill;
                Transaction.frmTransaction_Load(Transaction, new EventArgs());
            }
            else if (stSelectedNodeName == "ndInventoryIn")
            {
                generalResultInformation.currentTrx = transactionType.InventoryIn;

                frmTransaction Transaction = new frmTransaction();                                
                this.tlpMainFormOrganiser.Controls.Add(Transaction, 1, 0);
                Transaction.Dock = DockStyle.Fill;
                Transaction.frmTransaction_Load(Transaction, new EventArgs());
            }
            else if (stSelectedNodeName == "ndInventoryMove")
            {
                generalResultInformation.currentTrx = transactionType.Move;

                frmInventoryMove frminvMove = new frmInventoryMove();
                this.tlpMainFormOrganiser.Controls.Add(frminvMove, 1, 0);
                frminvMove.Dock = DockStyle.Fill;
                frminvMove.frmInventoryMove_Load(frminvMove, new EventArgs());
            }
            else if (stSelectedNodeName == "ndInternalUse")
            {
                generalResultInformation.currentTrx = transactionType.Use;

                frmInternalUse frminvUse = new frmInternalUse();
                this.tlpMainFormOrganiser.Controls.Add(frminvUse, 1, 0);
                frminvUse.Dock = DockStyle.Fill;
                frminvUse.frmInternalUse_Load(frminvUse, new EventArgs());
            }
            else if (stSelectedNodeName == "ndPhysicalInventory")
            {
                generalResultInformation.currentTrx = transactionType.Count;

                frmPhysicalInventory frmPhysicalInv = new frmPhysicalInventory();
                this.tlpMainFormOrganiser.Controls.Add(frmPhysicalInv, 1, 0);
                frmPhysicalInv.Dock = DockStyle.Fill;
                frmPhysicalInv.frmPhysicalInventory_Load(frmPhysicalInv, new EventArgs());
            }
            
            else if (stSelectedNodeName == "ndWarehouse")
            {
                generalResultInformation.currentTrx = transactionType.None;

                frmStorage frmStorage = new frmStorage();
                this.tlpMainFormOrganiser.Controls.Add(frmStorage, 1, 0);
                frmStorage.Dock = DockStyle.Fill;
                frmStorage.frmStorage_Load(frmStorage, new EventArgs());
            }
            else if (stSelectedNodeName == "ndStations")
            {
                generalResultInformation.currentTrx = transactionType.None;

                frmShops frmShops = new frmShops();
                this.tlpMainFormOrganiser.Controls.Add(frmShops, 1, 0);
                frmShops.Dock = DockStyle.Fill;
                frmShops.frmShops_Load(frmShops, new EventArgs());
            }
            else if (stSelectedNodeName == "ndOrganisation")
            {
                generalResultInformation.currentTrx = transactionType.None;

                frmOrganisation frmOrganisation = new frmOrganisation();
                this.tlpMainFormOrganiser.Controls.Add(frmOrganisation, 1, 0);
                frmOrganisation.Dock = DockStyle.Fill;
                frmOrganisation.frmOrganisation_Load(frmOrganisation, new EventArgs());
            }
            else if (stSelectedNodeName == "ndUnitConversion")
            {
                generalResultInformation.currentTrx = transactionType.None;

                frmUnitConversion frmUnitCnvrt = new frmUnitConversion();                
                this.tlpMainFormOrganiser.Controls.Add(frmUnitCnvrt, 1, 0);
                frmUnitCnvrt.Dock = DockStyle.Fill;
                frmUnitCnvrt.frmUnitConversion_Load (frmUnitCnvrt, new EventArgs()); 
            }
            else if (stSelectedNodeName == "ndOrganisationAccess")
            {
                generalResultInformation.currentTrx = transactionType.None;

                frmOrganisationAccess frmOrganisationAccess = new frmOrganisationAccess();
                this.tlpMainFormOrganiser.Controls.Add(frmOrganisationAccess, 1, 0);
                frmOrganisationAccess.Dock = DockStyle.Fill;
                frmOrganisationAccess.frmOrganisationAccess_Load(frmOrganisationAccess, new EventArgs());
            }
            else if (stSelectedNodeName == "ndWarehouseAccess")
            {
                generalResultInformation.currentTrx = transactionType.None;

                frmStorageAccess frmStrgAccess = new frmStorageAccess();
                this.tlpMainFormOrganiser.Controls.Add(frmStrgAccess, 1, 0);
                frmStrgAccess.Dock = DockStyle.Fill;
                frmStrgAccess.frmStorageAccess_Load(frmStrgAccess, new EventArgs());
            }
            else if (stSelectedNodeName == "ndFormAccess")
            {
                generalResultInformation.currentTrx = transactionType.None;

                frmFormAccess frmFrmAccess = new frmFormAccess();
                this.tlpMainFormOrganiser.Controls.Add(frmFrmAccess, 1, 0);
                frmFrmAccess.Dock = DockStyle.Fill;
                frmFrmAccess.frmFormAccess_Load(frmFrmAccess, new EventArgs());                
            }
            else if (stSelectedNodeName == "ndStationAccess")
            {
                generalResultInformation.currentTrx = transactionType.None;

                frmStationAccess frmStationAccess = new frmStationAccess();
                this.tlpMainFormOrganiser.Controls.Add(frmStationAccess, 1, 0);
                frmStationAccess.Dock = DockStyle.Fill;
                frmStationAccess.frmStationAccess_Load(frmStationAccess, new EventArgs());
            }
            else if (stSelectedNodeName == "ndSummaryInventoryInRprt" ||
                stSelectedNodeName == "ndDetailInventoryInRprt")
            {
                generalResultInformation.currentTrx = transactionType.report;                
                generalResultInformation.currentRequestedRptType = reportType.InventoryIn;

                if(stSelectedNodeName == "ndSummaryInventoryInRprt")
                    generalResultInformation.currentRequestedRptLevel = reportLevel.Summary;
                else
                    generalResultInformation.currentRequestedRptLevel = reportLevel.Detail;

                frmSearchTransaction frmSearchTrx = new frmSearchTransaction();
                this.tlpMainFormOrganiser.Controls.Add(frmSearchTrx, 1, 0);
                frmSearchTrx.Dock = DockStyle.Fill;
                frmSearchTrx.frmSearchTransaction_Load(frmSearchTrx, new EventArgs());
            }
            else if (stSelectedNodeName == "ndSummaryInventoryOutRprt" ||
                     stSelectedNodeName == "ndDetailInventoryOutRprt")
            {
                generalResultInformation.currentTrx = transactionType.report;
                if (stSelectedNodeName == "ndSummaryInventoryOutRprt")
                    generalResultInformation.currentRequestedRptLevel = reportLevel.Summary;
                else
                    generalResultInformation.currentRequestedRptLevel = reportLevel.Detail;
                generalResultInformation.currentRequestedRptType = reportType.InventoryOut;

                frmSearchTransaction frmSearchTrx = new frmSearchTransaction();
                this.tlpMainFormOrganiser.Controls.Add(frmSearchTrx, 1, 0);
                frmSearchTrx.Dock = DockStyle.Fill;
                frmSearchTrx.frmSearchTransaction_Load(frmSearchTrx, new EventArgs());
            }
            else if (stSelectedNodeName == "ndSummaryInventoryMoveRprt" ||
                     stSelectedNodeName == "ndDetailInventoryMoveRprt")
            {
                generalResultInformation.currentTrx = transactionType.report;
                if (stSelectedNodeName == "ndSummaryInventoryMoveRprt")
                    generalResultInformation.currentRequestedRptLevel = reportLevel.Summary;
                else
                    generalResultInformation.currentRequestedRptLevel = reportLevel.Detail;
                generalResultInformation.currentRequestedRptType = reportType.InventoryMove;

                frmSearchMovement frmSearchMovement = new frmSearchMovement();
                this.tlpMainFormOrganiser.Controls.Add(frmSearchMovement, 1, 0);
                frmSearchMovement.Dock = DockStyle.Fill;
                frmSearchMovement.frmSearchMovement_Load(frmSearchMovement, new EventArgs());

            }            
            else if (stSelectedNodeName == "ndSummaryInventoryUseRprt"||
                     stSelectedNodeName == "ndDetailInventoryUseRprt")
            {
                generalResultInformation.currentTrx = transactionType.report;
                if (stSelectedNodeName == "ndSummaryInventoryUseRprt")
                    generalResultInformation.currentRequestedRptLevel = reportLevel.Summary;
                else
                    generalResultInformation.currentRequestedRptLevel = reportLevel.Detail;
                generalResultInformation.currentRequestedRptType = reportType.InventoryUse;

                frmSearchUsage frmSearchUsage = new frmSearchUsage();
                this.tlpMainFormOrganiser.Controls.Add(frmSearchUsage, 1, 0);
                frmSearchUsage.Dock = DockStyle.Fill;
                frmSearchUsage.frmSearchUsage_Load(frmSearchUsage, new EventArgs());
            }
            else if (stSelectedNodeName == "ndSummaryInventoryCountRprt" ||
                     stSelectedNodeName == "ndDetailInventoryCountRprt")
            {
                generalResultInformation.currentTrx = transactionType.report;
                if (stSelectedNodeName == "ndSummaryInventoryCountRprt")
                    generalResultInformation.currentRequestedRptLevel = reportLevel.Summary;
                else
                    generalResultInformation.currentRequestedRptLevel = reportLevel.Detail;
                generalResultInformation.currentRequestedRptType = reportType.InventoryCount;

                frmSearchCount frmSearchCount = new frmSearchCount();
                this.tlpMainFormOrganiser.Controls.Add(frmSearchCount, 1, 0);
                frmSearchCount.Dock = DockStyle.Fill;
                frmSearchCount.frmSearchCount_Load(frmSearchCount, new EventArgs());
            }            
            else if (stSelectedNodeName == "ndInventoryActivityRprt")
            {
                generalResultInformation.currentTrx = transactionType.report;
                generalResultInformation.currentRequestedRptLevel = reportLevel.Detail;
                generalResultInformation.currentRequestedRptType = reportType.TransactionSummary;

                frmSearchMaterialTransaction frmSearchMaterialTransaction = new frmSearchMaterialTransaction();
                this.tlpMainFormOrganiser.Controls.Add(frmSearchMaterialTransaction, 1, 0);
                frmSearchMaterialTransaction.Dock = DockStyle.Fill;
                frmSearchMaterialTransaction.frmSearchMaterialTransaction_Load(frmSearchMaterialTransaction, new EventArgs());
            }
            else if (stSelectedNodeName == "ndSummarizedInventoryRprt")
            {
                generalResultInformation.currentTrx = transactionType.report;
                generalResultInformation.currentRequestedRptLevel = reportLevel.Summary;
                generalResultInformation.currentRequestedRptType = reportType.InventoryQuantity;

                frmSearchInventory frmSearchInventory = new frmSearchInventory();
                this.tlpMainFormOrganiser.Controls.Add(frmSearchInventory, 1, 0);
                frmSearchInventory.Dock = DockStyle.Fill;
                frmSearchInventory.frmSearchInventory_Load(frmSearchInventory, new EventArgs());
            }
            else if (stSelectedNodeName == "ndDetailInventoryRprt")
            {
                generalResultInformation.currentTrx = transactionType.report;
                generalResultInformation.currentRequestedRptLevel = reportLevel.Detail;
                generalResultInformation.currentRequestedRptType = reportType.InventoryQuantity;

                frmSearchInventory frmSearchInventory = new frmSearchInventory();
                this.tlpMainFormOrganiser.Controls.Add(frmSearchInventory, 1, 0);
                frmSearchInventory.Dock = DockStyle.Fill;
                frmSearchInventory.frmSearchInventory_Load(frmSearchInventory, new EventArgs());
            }

        }

        private void tmrGarbageCollector_Tick(object sender, EventArgs e)
        {
            GC.Collect();
        }          

    }
}
