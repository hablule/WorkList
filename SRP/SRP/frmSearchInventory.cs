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
    public partial class frmSearchInventory : Panel
    {
        public frmSearchInventory()
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
            
            if (this.cmbLogicWarehouse.SelectedItem.ToString() != "IGNOR" &&
                this.cmbWarehouse.SelectedIndex >= 0 &&
                this.cmbWarehouse.SelectedIndex <= this.dtAllAccessableWarehouse.Rows.Count - 1)
            {
                this.addMoreCriteria("M_WAREHOUSE_ID", 
                    this.cmbLogicWarehouse.SelectedItem.ToString(),
                    this.dtAllAccessableWarehouse.
                        Rows[this.cmbWarehouse.SelectedIndex]["M_WAREHOUSE_ID"].ToString(),                        
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

            if (this.cmbLogicProduct.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("M_PRODUCT_ID",
                    this.cmbLogicProduct.SelectedItem.ToString(),
                    this.ddgProduct.SelectedRowKey.ToString(),
                    "");
            }
                                    
            if (this.cmbLogicQuantity.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("CURRENTQTY", 
                    this.cmbLogicQuantity.SelectedItem.ToString(),
                    this.ntbQtyFrom.Amount,
                    this.ntbQtyTo.Amount);
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
                    this.cmbWarehouse.Items.Add(
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


        private bool checkForReportSheet()
        {
            if (!System.IO.File.Exists("crptSummarisedStorage.rpt") ||
                !System.IO.File.Exists("crptDetailStorage.rpt"))                           
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
                        
            if (generalResultInformation.currentRequestedRptLevel == reportLevel.Detail)
            {
                return
                    this.getDatafromDataBase.getV_STORAGEDETAILInfo(this.searchQuery,
                                stLogicalConnector, "", "", "", false, "AND");
            }
            else if (generalResultInformation.currentRequestedRptLevel == reportLevel.Summary)
            {
                return
                    this.getDatafromDataBase.getV_STORAGESUMMARYInfo(this.searchQuery,
                                stLogicalConnector, "", "", false, "AND");
            }
            else
            {
                return new DataTable();
            }
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


        public void frmSearchInventory_Load(object sender, EventArgs e)
        {
            this.setUpWarehouses();
            this.setUpProductCategory();
                        
            this.cmbLogicProduct.SelectedItem = "IGNOR";                       
            this.cmbLogicWarehouse.SelectedItem = "IGNOR";

            this.cmbLogicQuantity.SelectedItem = "IGNOR";
            this.cmbLogicCategory.SelectedItem = "IGNOR";

            if (generalResultInformation.currentRequestedRptLevel == reportLevel.Summary)
            {
                this.lblWareHouse.Visible = false;
                this.cmbLogicWarehouse.Visible = false;
                this.cmbWarehouse.Visible = false;
            }
                                      
            
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
            this.ddgProduct.DataSource =
               this.getDatafromDataBase.getM_PRODUCTInfo(null, "", "", "", "", "",
                        this.ddgProduct.SelectedItem, "", "", "",
                        triStateBool.yes, false, "AND", generalResultInformation.dbBulkDataRetrivalSize);
            this.ddgProduct.DataTablePrimaryKey =
                Convert.ToUInt16(this.dtExistingAllProductInformation.Columns.IndexOf("M_PRODUCT_ID"));
            this.ddgProduct.SelectedColomnIdex =
                this.dtExistingAllProductInformation.Columns.IndexOf("NAME");
            this.ddgProduct.HiddenColoumns = new int[]
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
            this.ddgProduct.SelectedRow.Clear();
            generalResultInformation.selectedProductId = "";
            frmProductImage frmProductImageList = new frmProductImage();
            frmProductImageList.ShowDialog();
            if (generalResultInformation.selectedProductId == "")
            {
                this.ddgProduct.SelectedRowKey = null;
                this.ddgProduct.SelectedItem = "";
            }
            else
            {
                DataTable dtProdcutInfo =
                    this.getDatafromDataBase.getM_PRODUCTInfo(null, "",
                                generalResultInformation.selectedProductId,
                                "", "", "", "", "", "", "", 
                                triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);

                this.ddgProduct.SelectedItem = dtProdcutInfo.Rows[0]["NAME"].ToString();
                this.ddgProduct.SelectedRowKey = dtProdcutInfo.Rows[0]["M_PRODUCT_ID"];
            }
        }


        private void cmdSearchAndShowResult_Click(object sender, EventArgs e)
        {
            if (!this.checkForReportSheet())
            {
                MessageBox.Show("Unable To find Report Builder. \n " +
                    "Please Contact Your Administrator.",
                    "Printing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable dtSearchResult = this.getRequiredInformation();

            if (!this.getDatafromDataBase.checkIfTableContainesData(dtSearchResult))
            {
                MessageBox.Show("No Result for current search Criterion.",
                    "SRP Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string fileName = "";
            string dsDataTableName = "dtInventory";
            if (generalResultInformation.currentRequestedRptLevel == reportLevel.Summary)
            {
                fileName = "crptSummarisedStorage.rpt";
            }
            else if (generalResultInformation.currentRequestedRptLevel == reportLevel.Detail)
            {
                fileName = "crptDetailStorage.rpt";
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
        

        
        private void cmbTrxProductLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbLogicProduct.SelectedItem.ToString(),
                this.ddgProduct);

            this.enableDisableValueInsertionBox(this.cmbLogicProduct.SelectedItem.ToString(),
                this.cmdShowPrdImageList);
        }
        
        private void cmbLogicQuantity_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbLogicQuantity.SelectedItem.ToString(),
                this.ntbQtyFrom);

            if (this.cmbLogicQuantity.SelectedItem.ToString() == "In between of")
                this.ntbQtyTo.Visible = true;
            else
                this.ntbQtyTo.Visible = false;

            this.ntbQtyFrom.Amount = "0";
            this.ntbQtyTo.Amount = "0";
        }

        private void cmbTrxLogicCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbLogicCategory.SelectedItem.ToString(),
               this.cmbCategory);

            if (this.dtAllProductCategory.Rows.Count > 0)
                this.cmbCategory.SelectedIndex = 0;
        }

        private void cmbTrxLogicWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbLogicWarehouse.SelectedItem.ToString(),
               this.cmbWarehouse);

            if (this.dtAllAccessableWarehouse.Rows.Count > 0)
                this.cmbWarehouse.SelectedIndex = 0;            
        }

    }
}
