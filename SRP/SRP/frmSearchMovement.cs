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
    public partial class frmSearchMovement : Panel
    {
        public frmSearchMovement()
        {
            InitializeComponent();
        }

        DataTable searchQuery = new DataTable();
        DataTable dtExistingAllProductInformation = new DataTable();

        DataTable dtAccessableOrganisations = new DataTable();
        DataTable dtAllAccessableWarehouse = new DataTable();
        DataTable dtAllProductCategory = new DataTable();

        private dataBuilder getDatafromDataBase = new dataBuilder();
        private businessRule getDataAccordingToRule = new businessRule();        

        private void addMoreCriteria(string field, string criterion, 
            string valueFrom, string valueTo)
        {
            if (field == "" || criterion == "" || valueFrom == "")
                return;
            if (criterion == "In between of")
            {
                this.addMoreCriteria(field, "Greater or equals to", valueFrom, "");
                this.addMoreCriteria(field, "Lesser or equal to", valueTo, "");
            }
            else
            {
                DataRow criteriaValue = this.searchQuery.NewRow();

                criteriaValue["Field"] = field;
                criteriaValue["Criterion"] = this.generateEquivalentSymbol(criterion);
                if (criteriaValue["Criterion"].ToString() == "like")
                    criteriaValue["Value"] = "%" + valueFrom.ToUpper() + "%";
                else
                    criteriaValue["Value"] = valueFrom;
                this.searchQuery.Rows.Add(criteriaValue);
            }

        }


        private void establishSearchCriterion()
        {
            this.searchQuery.Rows.Clear();
                        
            if (this.cmbMovementLogicDate.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("MOVEDATE", 
                    this.cmbMovementLogicDate.SelectedItem.ToString(),
                    this.dtpMovementDateFrom.Value.ToString("yyyy-MM-dd"),
                    this.dtpMovementDateTo.Value.ToString("yyyy-MM-dd"));
            }

            if (this.cmbLogicStation.SelectedItem.ToString() != "IGNOR" &&
                this.cmbStations.SelectedIndex >= 0 &&
                this.cmbStations.SelectedIndex <= this.dtAccessableOrganisations.Rows.Count-1)
            {
                this.addMoreCriteria("AD_ORG_ID", 
                    this.cmbLogicStation.SelectedItem.ToString(),
                    this.dtAccessableOrganisations.
                        Rows[this.cmbStations.SelectedIndex]["AD_ORG_ID"].ToString(),
                      "");
            }

            if (this.cmbLogicWarehouseFrom.SelectedItem.ToString() != "IGNOR" &&
                this.cmbWarehouseFrom.SelectedIndex >= 0 &&
                this.cmbWarehouseFrom.SelectedIndex <= this.dtAllAccessableWarehouse.Rows.Count - 1)
            {
                this.addMoreCriteria("M_WAREHOUSEFROM_ID", 
                    this.cmbLogicWarehouseFrom.SelectedItem.ToString(),
                    this.dtAllAccessableWarehouse.
                        Rows[this.cmbWarehouseFrom.SelectedIndex]["M_WAREHOUSE_ID"].ToString(),                        
                      "");
            }

            if (this.cmbLogicWarehouseTo.SelectedItem.ToString() != "IGNOR" &&
                this.cmbLogicWarehouseTo.SelectedIndex >= 0 &&
                this.cmbLogicWarehouseTo.SelectedIndex <= this.dtAllAccessableWarehouse.Rows.Count - 1)
            {
                this.addMoreCriteria("M_WAREHOUSETO_ID",
                    this.cmbLogicWarehouseTo.SelectedItem.ToString(),
                    this.dtAllAccessableWarehouse.
                        Rows[this.cmbWarehouseTo.SelectedIndex]["M_WAREHOUSE_ID"].ToString(),
                      "");
            }

            if (this.cmbLogicCategory.SelectedItem.ToString() != "IGNOR" &&
                this.cmbCategory.SelectedIndex >= 0 &&
                this.cmbCategory.SelectedIndex <= this.dtAllProductCategory.Rows.Count - 1)
            {
                this.addMoreCriteria("M_PRODUCTCATEGORY_ID",
                    this.cmbLogicCategory.SelectedItem.ToString(),
                    this.dtAllProductCategory.
                        Rows[this.cmbCategory.SelectedIndex]["M_PRODUCTCATEGORY_ID"].ToString(),
                      "");
            }

            if (this.cmbLogicDocStatus.SelectedItem.ToString() != "IGNOR" &&
                this.cmbDocstatus.SelectedIndex >= 0)
            {
                this.addMoreCriteria("DOCSTATUS",
                    this.cmbLogicDocStatus.SelectedItem.ToString(),
                    this.cmbDocstatus.SelectedItem.ToString().
                        Substring(0, 2).ToUpperInvariant(),
                      "");
            }

            if (this.cmbLogicDocNo.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("DOCUMENTNO",
                    this.cmbLogicDocNo.SelectedItem.ToString(),
                    this.txtDocumentNo.Text,
                    "");
            }

            if (this.cmbMovementLogicProduct.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("M_PRODUCT_ID",
                    this.cmbMovementLogicProduct.SelectedItem.ToString(),
                    this.ddgMovedProduct.SelectedRowKey.ToString(),
                    "");
            }
                                    
            if (this.cmbMovementLogicQty.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("MOVEQUANTITY", 
                    this.cmbMovementLogicQty.SelectedItem.ToString(),
                    this.ntbMovedQtyFrom.Amount,
                    this.ntbMovedQtyTo.Amount);
            }
         }

        private string generateEquivalentSymbol(string symbolInText)
        {
            if (symbolInText == "Equals to")
                return "=";
            if (symbolInText == "Not equals to")
                return "!=";
            if (symbolInText == "Similar to")
                return "like";
            if (symbolInText == "Not similar to")
                return "not like";
            if (symbolInText == "Greater than")
                return ">";
            if (symbolInText == "Greater or equals to")
                return ">=";
            if (symbolInText == "Less than")
                return "<";
            if (symbolInText == "Lesser or equal to")
                return "<=";
            return "";
        }
        
        private void enableDisableValueInsertionBox(string Logic, Control valueInsertionBox)
        {
            if (Logic == "IGNOR")
                valueInsertionBox.Enabled = false;
            else
                valueInsertionBox.Enabled = true;
        }


        private void setUpOrganisations()
        {
            this.dtAccessableOrganisations =
                this.getDataAccordingToRule.getCurrentUserAccessableOrganisation(accessLevel.ReadOnly, 
                        triStateBool.ignor);

            this.dtAccessableOrganisations =
                this.getDatafromDataBase.mergeTables(this.dtAccessableOrganisations,
                    this.getDataAccordingToRule.
                        getCurrentUserAccessableOrganisation(accessLevel.ReadWite,
                                        triStateBool.ignor), 
                      "AD_ORG_ID", false);

            if (this.getDatafromDataBase.checkIfTableContainesData(this.dtAccessableOrganisations))
            {
                for (int rowCounter = 0;
                        rowCounter <= this.dtAccessableOrganisations.Rows.Count - 1; rowCounter++)
                {
                    this.cmbStations.Items.Add(
                            this.dtAccessableOrganisations.Rows[rowCounter]["NAME"].ToString());                
                }
            }                
        }

        private void setUpWarehouses()
        {
            this.dtAllAccessableWarehouse =
                this.getDataAccordingToRule.
                    getCurrentUserAccessableWarehouse(triStateBool.ignor, 
                            triStateBool.ignor, triStateBool.ignor, triStateBool.ignor, 
                            triStateBool.ignor, triStateBool.ignor, triStateBool.yes,
                            triStateBool.ignor, "AND");

            if (this.getDatafromDataBase.checkIfTableContainesData(this.dtAllAccessableWarehouse))
            {
                for (int rowCounter = 0;
                        rowCounter <= this.dtAllAccessableWarehouse.Rows.Count - 1; rowCounter++)
                {
                    this.cmbWarehouseFrom.Items.Add(
                            this.dtAllAccessableWarehouse.Rows[rowCounter]["NAME"].ToString());

                    this.cmbWarehouseTo.Items.Add(
                            this.dtAllAccessableWarehouse.Rows[rowCounter]["NAME"].ToString());
                }
            }
        }

        private void setUpProductCategory()
        {
            this.dtAllProductCategory =
                this.getDatafromDataBase.getM_PRODUCTCATEGORYInfo(null, "", 
                    "", "", triStateBool.ignor, false, "AND");

            if (this.getDatafromDataBase.checkIfTableContainesData(this.dtAllProductCategory))
            {
                for (int rowCounter = 0;
                        rowCounter <= this.dtAllProductCategory.Rows.Count - 1; rowCounter++)
                {
                    this.cmbCategory.Items.Add(
                            this.dtAllProductCategory.Rows[rowCounter]["NAME"].ToString());
                }
            }
        }

        private void setUpDocStatus()
        {
            this.cmbDocstatus.Items.Clear();            
            foreach (transactionStatus trxS in Enum.GetValues(typeof(transactionStatus)))
            {
                this.cmbDocstatus.Items.Add(trxS.ToString());
            }

            if (this.cmbDocstatus.Items.Contains("ignor"))
                this.cmbDocstatus.Items.Remove("igonor");            
        }

        private bool checkForReportSheet()
        {
            if (!System.IO.File.Exists("crptMovementSummary.rpt") ||
                !System.IO.File.Exists("crptMovementDetail.rpt"))                           
                return false;
            else
                return true;
        }


        private DataTable getRequiredInformation()
        {
            string stLogicalConnector = "AND";
            if (this.ckAllOrAny.Checked)
                stLogicalConnector = "OR";
                      
            this.establishSearchCriterion();

            return
                this.getDatafromDataBase.getV_MOVEMENTDETAILInfo(this.searchQuery,
                            stLogicalConnector, "", "", "", "", "", "", "", "",
                            new DateTime(), false, triStateBool.ignor,
                            triStateBool.ignor, transactionStatus.ignor, false, "AND");
        }

        private DataTable removeRecordForInactiveSations(DataTable recordsToClear)
        {
            if (!recordsToClear.Columns.Contains("AD_ORG_ID") ||
                !this.getDatafromDataBase.checkIfTableContainesData(this.dtAccessableOrganisations))
            {
                recordsToClear.Rows.Clear();
                return recordsToClear;
            }

            string[] stAccessableOrganisations = 
                new string[this.dtAccessableOrganisations.Rows.Count];

            for (int rowCounter = 0; 
                rowCounter <= this.dtAccessableOrganisations.Rows.Count - 1;
                rowCounter++)
            {
                stAccessableOrganisations[rowCounter] =
                    this.dtAccessableOrganisations.Rows[rowCounter]["AD_ORG_ID"].ToString();            
            }

            for (int rowCounter = recordsToClear.Rows.Count - 1; rowCounter >= 0; rowCounter--)
            {
                if (!stAccessableOrganisations.Contains<string>
                        (recordsToClear.Rows[rowCounter]["AD_ORG_ID"].ToString()))
                {
                    recordsToClear.Rows.RemoveAt(rowCounter); 
                }
            }

            return recordsToClear; 
        }


        public void frmSearchMovement_Load(object sender, EventArgs e)
        {
            this.setUpWarehouses();
            this.setUpOrganisations();
            this.setUpProductCategory();
            this.setUpDocStatus();

            this.cmbMovementLogicDate.SelectedItem = "IGNOR";
            this.cmbMovementLogicProduct.SelectedItem = "IGNOR";
            this.cmbLogicStation.SelectedItem = "IGNOR";
            this.cmbLogicDocNo.SelectedItem = "IGNOR";            
            this.cmbLogicWarehouseFrom.SelectedItem = "IGNOR";
            this.cmbLogicWarehouseTo.SelectedItem = "IGNOR";

            this.cmbMovementLogicQty.SelectedItem = "IGNOR";
            this.cmbLogicCategory.SelectedItem = "IGNOR";
            this.cmbLogicDocStatus.SelectedItem = "IGNOR";
                                            
            
            this.dtExistingAllProductInformation =
                this.getDatafromDataBase.getM_PRODUCTInfo(null, "", "",
                        "", "", "", "", "", "", "", 
                                triStateBool.yes, true, "AND",generalResultInformation.dbBulkDataRetrivalSize);

            this.searchQuery.Columns.Add("Field");
            this.searchQuery.Columns.Add("Criterion");
            this.searchQuery.Columns.Add("Value");

            if (!this.checkForReportSheet() &&
                generalResultInformation.currentTrx == transactionType.report)
            {
                MessageBox.Show("Unable To find Report Builder. \n " +
                    "Please Contact Your Administrator.",
                    "Printing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void ddgProduct_SelectedItemClicked(object sender, EventArgs e)
        {
            this.ddgMovedProduct.DataSource =
               this.getDatafromDataBase.getM_PRODUCTInfo(null, "", "", "", "", "",
                        this.ddgMovedProduct.SelectedItem, "", "", "",
                        triStateBool.yes, false, "AND", generalResultInformation.dbBulkDataRetrivalSize);
            this.ddgMovedProduct.DataTablePrimaryKey =
                Convert.ToUInt16(this.dtExistingAllProductInformation.Columns.IndexOf("M_PRODUCT_ID"));
            this.ddgMovedProduct.SelectedColomnIdex =
                this.dtExistingAllProductInformation.Columns.IndexOf("NAME");
            this.ddgMovedProduct.HiddenColoumns = new int[]
                                {
                                    this.dtExistingAllProductInformation.Columns.IndexOf("M_SHOP_ID"),
                                    this.dtExistingAllProductInformation.Columns.IndexOf("AD_ORG_ID"),
                                    this.dtExistingAllProductInformation.Columns.IndexOf("CREATED"),
                                    this.dtExistingAllProductInformation.Columns.IndexOf("UPDATED"),
                                    this.dtExistingAllProductInformation.Columns.IndexOf("M_PRODUCTCATEGORY_ID"),
                                    this.dtExistingAllProductInformation.Columns.IndexOf("M_UOM_ID"),
                                    this.dtExistingAllProductInformation.Columns.IndexOf("CREATEDBY"),
                                    this.dtExistingAllProductInformation.Columns.IndexOf("UPDATEDBY"),
                                    this.dtExistingAllProductInformation.Columns.IndexOf("ISACTIVE"),
                                    this.dtExistingAllProductInformation.Columns.IndexOf("DESCRIPTION"),
                                    this.dtExistingAllProductInformation.Columns.IndexOf("PRODUCTTYPE"),
                                    this.dtExistingAllProductInformation.Columns.IndexOf("IMAGEPATH"),
                                    this.dtExistingAllProductInformation.Columns.IndexOf("PURCHASEPRICE")
                                };
        }
                
        private void cmdShowPrdImageList_Click(object sender, EventArgs e)
        {
            this.ddgMovedProduct.SelectedRow.Clear();
            generalResultInformation.selectedProductId = "";
            frmProductImage frmProductImageList = new frmProductImage();
            frmProductImageList.ShowDialog();
            if (generalResultInformation.selectedProductId == "")
            {
                this.ddgMovedProduct.SelectedRowKey = null;
                this.ddgMovedProduct.SelectedItem = "";
            }
            else
            {
                DataTable dtProdcutInfo =
                    this.getDatafromDataBase.getM_PRODUCTInfo(null, "",
                                generalResultInformation.selectedProductId,
                                "", "", "", "", "", "", "", 
                                triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);

                this.ddgMovedProduct.SelectedItem = dtProdcutInfo.Rows[0]["NAME"].ToString();
                this.ddgMovedProduct.SelectedRowKey = dtProdcutInfo.Rows[0]["M_PRODUCT_ID"];
            }
        }


        private void cmdSearchAndShowResult_Click(object sender, EventArgs e)
        {
            if (!this.checkForReportSheet() &&
                generalResultInformation.currentTrx == transactionType.report)
            {
                MessageBox.Show("Unable To find Report Builder. \n " +
                    "Please Contact Your Administrator.",
                    "Printing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable dtSearchResult = this.getRequiredInformation();

            dtSearchResult = this.removeRecordForInactiveSations(dtSearchResult);
            
            if (!this.getDatafromDataBase.checkIfTableContainesData(dtSearchResult))
            {
                MessageBox.Show("No Result for current search Criterion.",
                    "SRP Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (generalResultInformation.currentTrx == transactionType.report)
            {
                string fileName = "";
                string dsDataTableName = "";
                if (generalResultInformation.currentRequestedRptLevel == reportLevel.Summary)
                {
                    dtSearchResult =
                        this.getDatafromDataBase.clearRedundantRow(dtSearchResult,
                            "T_MOVEMENT_ID");

                    fileName = "crptMovementSummary.rpt";
                    dsDataTableName = "dtMoveSummary";
                }
                else if (generalResultInformation.currentRequestedRptLevel == reportLevel.Detail)
                {
                    fileName = "crptMovementDetail.rpt";
                    dsDataTableName = "dtMoveDetail";
                }
                else
                {
                    return;
                }

                frmPrintViewer newPrintJobView = new frmPrintViewer();

                dtsReportData dsNewReport = new dtsReportData();

                dsNewReport.Tables[dsDataTableName].Clear();

                DataRow drNewReport;

                string stRptTBColumnName = "";
                Type tpRptTBColumnDataType;

                for (int rowCounter = 0;
                    rowCounter <= dtSearchResult.Rows.Count - 1; rowCounter++)
                {
                    drNewReport =
                        dsNewReport.Tables[dsDataTableName].NewRow();
                    for (int columnCounter = 0;
                        columnCounter <=
                            dsNewReport.
                                Tables[dsDataTableName].Columns.Count - 1;
                        columnCounter++)
                    {
                        stRptTBColumnName =
                            dsNewReport.Tables[dsDataTableName].Columns[columnCounter].ColumnName;
                        tpRptTBColumnDataType =
                            dsNewReport.Tables[dsDataTableName].Columns[columnCounter].DataType.GetType();
                        if (dtSearchResult.Columns.Contains(stRptTBColumnName))
                        {
                            drNewReport[stRptTBColumnName] =
                                dtSearchResult.Rows[rowCounter][stRptTBColumnName];
                        }
                    }
                    dsNewReport.Tables[dsDataTableName].Rows.Add(drNewReport);
                }

                newPrintJobView.setUpThePreviewArea(fileName, dsNewReport);
                newPrintJobView.ShowDialog(this);
            }
            else if (generalResultInformation.currentTrx == transactionType.Move)
            {
                DataTable dtTrxInfo = new DataTable();

                dtSearchResult =
                        this.getDatafromDataBase.clearRedundantRow(dtSearchResult,
                            "T_MOVEMENT_ID");

                this.searchQuery.Rows.Clear();
                for (int rowCounter = 0;
                    rowCounter <= dtSearchResult.Rows.Count - 1; rowCounter++)
                {
                    this.addMoreCriteria("T_MOVEMENT_ID", "Equals to",
                        dtSearchResult.
                            Rows[rowCounter]["T_MOVEMENT_ID"].ToString(),
                         "");
                }

                generalResultInformation.searchResult =
                    this.getDatafromDataBase.getT_MOVEMENTInfo(this.searchQuery,
                            "OR", "", "", "", "", new DateTime(), false,
                            triStateBool.ignor, triStateBool.ignor,
                            transactionStatus.ignor, false, "AND");

                this.Parent.Dispose();
            }            
        }
        

        private void cmbDateLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbMovementLogicDate.SelectedItem.ToString(),
                this.dtpMovementDateFrom);

            if (this.cmbMovementLogicDate.SelectedItem.ToString() == "In between of")
                this.dtpMovementDateTo.Visible = true;
            else
                this.dtpMovementDateTo.Visible = false;
        }

        private void cmbProductLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbMovementLogicProduct.SelectedItem.ToString(),
                this.ddgMovedProduct);

            this.enableDisableValueInsertionBox(this.cmbMovementLogicProduct.SelectedItem.ToString(),
                this.cmdShowPrdImageList);
        }

        private void cmbLogicStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbLogicStation.SelectedItem.ToString(),
                this.cmbStations);

            if (this.dtAccessableOrganisations.Rows.Count > 0)
                this.cmbStations.SelectedIndex = 0;
        }

        private void cmbLogicDocNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbLogicDocNo.SelectedItem.ToString(),
               this.txtDocumentNo);
        }
        
        private void cmbMovementLogicMovementQty_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbMovementLogicQty.SelectedItem.ToString(),
                this.ntbMovedQtyFrom);

            if (this.cmbMovementLogicQty.SelectedItem.ToString() == "In between of")
                this.ntbMovedQtyTo.Visible = true;
            else
                this.ntbMovedQtyTo.Visible = false;

            this.ntbMovedQtyFrom.Amount = "0";
            this.ntbMovedQtyTo.Amount = "0";
        }

        private void cmbLogicCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbLogicCategory.SelectedItem.ToString(),
               this.cmbCategory);

            if (this.dtAllProductCategory.Rows.Count > 0)
                this.cmbCategory.SelectedIndex = 0;
        }

        private void cmbTrxLogicDocStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbLogicDocStatus.SelectedItem.ToString(),
               this.cmbDocstatus);
            if (this.cmbDocstatus.Items.Count > 0)
                this.cmbDocstatus.SelectedIndex = 0;
        }

        private void cmbLogicWarehouseFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbLogicWarehouseFrom.SelectedItem.ToString(),
               this.cmbWarehouseFrom);

            if (this.dtAllAccessableWarehouse.Rows.Count > 0)
                this.cmbWarehouseFrom.SelectedIndex = 0;            
        }

        private void cmbLogicWarehouseTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbLogicWarehouseTo.SelectedItem.ToString(),
               this.cmbWarehouseTo);

            if (this.dtAllAccessableWarehouse.Rows.Count > 0)
                this.cmbWarehouseTo.SelectedIndex = 0;
        }

    }
}
