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
    public partial class frmSearchTransaction : Panel
    {
        public frmSearchTransaction()
        {
            InitializeComponent();
        }

        DataTable searchQuery = new DataTable();
        DataTable dtExistingAllProductInformation = new DataTable();
        DataTable dtExistingAllBpartnerInformation = new DataTable();

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
                        
            if (this.cmbTrxLogicDate.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("TRXDATE", this.cmbTrxLogicDate.SelectedItem.ToString(),
                    this.dtpTrxDateFrom.Value.ToString("yyyy-MM-dd"),
                    this.dtpTrxDateTo.Value.ToString("yyyy-MM-dd"));
            }

            if (this.cmbTrxLogicStation.SelectedItem.ToString() != "IGNOR" &&
                this.cmbStations.SelectedIndex >= 0 &&
                this.cmbStations.SelectedIndex <= this.dtAccessableOrganisations.Rows.Count-1)
            {
                this.addMoreCriteria("AD_ORG_ID", 
                    this.cmbTrxLogicStation.SelectedItem.ToString(),
                    this.dtAccessableOrganisations.
                        Rows[this.cmbStations.SelectedIndex]["AD_ORG_ID"].ToString(),
                      "");
            }

            if (this.cmbTrxLogicWarehouse.SelectedItem.ToString() != "IGNOR" &&
                this.cmbWarehouse.SelectedIndex >= 0 &&
                this.cmbWarehouse.SelectedIndex <= this.dtAllAccessableWarehouse.Rows.Count - 1)
            {
                this.addMoreCriteria("M_WAREHOUSE_ID", 
                    this.cmbTrxLogicWarehouse.SelectedItem.ToString(),
                    this.dtAllAccessableWarehouse.
                        Rows[this.cmbWarehouse.SelectedIndex]["M_WAREHOUSE_ID"].ToString(),                        
                      "");
            }

            if (this.cmbTrxLogicCategory.SelectedItem.ToString() != "IGNOR" &&
                this.cmbCategory.SelectedIndex >= 0 &&
                this.cmbCategory.SelectedIndex <= this.dtAllProductCategory.Rows.Count - 1)
            {
                this.addMoreCriteria("M_PRODUCTCATEGORY_ID",
                    this.cmbTrxLogicCategory.SelectedItem.ToString(),
                    this.dtAllProductCategory.
                        Rows[this.cmbCategory.SelectedIndex]["M_PRODUCTCATEGORY_ID"].ToString(),
                      "");
            }

            if (this.cmbTrxLogicDocStatus.SelectedItem.ToString() != "IGNOR" &&
                this.cmbTrxDocstatus.SelectedIndex >= 0)
            {
                this.addMoreCriteria("DOCSTATUS",
                    this.cmbTrxLogicDocStatus.SelectedItem.ToString(),
                    this.cmbTrxDocstatus.SelectedItem.ToString().
                        Substring(0, 2).ToUpperInvariant(),
                      "");
            }


            if (this.cmbTrxLogicBpartner.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("M_BPARTNER_ID",
                    this.cmbTrxLogicBpartner.SelectedItem.ToString(),
                    this.ddgTrxBpartner.SelectedRowKey.ToString(),
                    "");
            }

            if (this.cmbTrxLogicDocNo.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("DOCUMENTNO",
                    this.cmbTrxLogicDocNo.SelectedItem.ToString(),
                    this.txtDocumentNo.Text,
                    "");
            }

            if (this.cmbTrxLogicProduct.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("M_PRODUCT_ID",
                    this.cmbTrxLogicProduct.SelectedItem.ToString(),
                    this.ddgTrxProduct.SelectedRowKey.ToString(),
                    "");
            }

            if (this.cmbTrxLogicSubTotal.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("SUBTRXAMOUNT",
                    this.cmbTrxLogicSubTotal.SelectedItem.ToString(),
                    this.ntbSubTotalFrom.Amount, 
                    this.ntbSubTotalTo.Amount);
            }


            if (this.cmbTrxLogicGrandTotal.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("GRANDTRXAMOUNT", 
                    this.cmbTrxLogicGrandTotal.SelectedItem.ToString(),
                    this.ntbGrandTotalFrom.Amount,
                    this.ntbGrandTotalTo.Amount);
            }

            if (this.cmbTrxLogicTaxTotal.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("TRXTAXAMOUNT",
                    this.cmbTrxLogicTaxTotal.SelectedItem.ToString(),
                    this.ntbTaxTotalFrom.Amount,
                    this.ntbTaxTotalTo.Amount);
            }

            if (this.cmbTrxLogicPrice.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("UNITPRICE", 
                    this.cmbTrxLogicPrice.SelectedItem.ToString(),
                    this.ntbTrxPriceFrom.Amount,
                    this.ntbTrxPriceTo.Amount);
            }

            if (this.cmbTrxLogicQuantity.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("TRXQUANTITY", 
                    this.cmbTrxLogicQuantity.SelectedItem.ToString(),
                    this.ntbTrxQtyFrom.Amount,
                    this.ntbTrxQtyTo.Amount);
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

        private void setUpDocStatus()
        {
            this.cmbTrxDocstatus.Items.Clear();            
            foreach (transactionStatus trxS in Enum.GetValues(typeof(transactionStatus)))
            {
                this.cmbTrxDocstatus.Items.Add(trxS.ToString());
            }

            if (this.cmbTrxDocstatus.Items.Contains("ignor"))
                this.cmbTrxDocstatus.Items.Remove("igonor");            
        }

        private bool checkForReportSheet()
        {
            if (!System.IO.File.Exists("crptTrxSummary.rpt") ||
                !System.IO.File.Exists("crptTrxSummary.rpt"))                           
                return false;
            else
                return true;
        }


        private DataTable getRequiredInformation()
        {
            string stLogicalConnector = "AND";
            if (this.ckAllOrAny.Checked)
                stLogicalConnector = "OR";

            triStateBool isSalesTrx = triStateBool.ignor;
            if (this.ckIsTrxSales.CheckState == CheckState.Checked)
                isSalesTrx = triStateBool.yes;
            else if (this.ckIsTrxSales.CheckState == CheckState.Unchecked)
                isSalesTrx = triStateBool.No;
                      
            this.establishSearchCriterion();
                        
            return
                this.getDatafromDataBase.getV_TRXDETAILInfo(this.searchQuery,
                            stLogicalConnector, "", "", "", "", "", "", "", "",
                            new DateTime(), false, isSalesTrx, triStateBool.ignor, 
                            triStateBool.ignor,transactionStatus.ignor, false, "AND");
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


        public void frmSearchTransaction_Load(object sender, EventArgs e)
        {
            this.setUpWarehouses();
            this.setUpOrganisations();
            this.setUpProductCategory();
            this.setUpDocStatus();

            this.cmbTrxLogicDate.SelectedItem = "IGNOR";
            this.cmbTrxLogicProduct.SelectedItem = "IGNOR";
            this.cmbTrxLogicStation.SelectedItem = "IGNOR";
            this.cmbTrxLogicDocNo.SelectedItem = "IGNOR";
            this.cmbTrxLogicBpartner.SelectedItem = "IGNOR";
            this.cmbTrxLogicSubTotal.SelectedItem = "IGNOR";
            this.cmbTrxLogicTaxTotal.SelectedItem = "IGNOR";
            this.cmbTrxLogicGrandTotal.SelectedItem = "IGNOR";
            this.cmbTrxLogicWarehouse.SelectedItem = "IGNOR";

            this.cmbTrxLogicPrice.SelectedItem = "IGNOR";
            this.cmbTrxLogicQuantity.SelectedItem = "IGNOR";
            this.cmbTrxLogicCategory.SelectedItem = "IGNOR";
            this.cmbTrxLogicDocStatus.SelectedItem = "IGNOR";

            if (generalResultInformation.currentTrx == transactionType.InventoryOut)
            {
                this.dtExistingAllBpartnerInformation =
                    this.getDatafromDataBase.getM_BPARTNERInfo(null, "",
                            "", "", triStateBool.yes, triStateBool.ignor,
                            triStateBool.yes, false, "AND");
            }
            else if (generalResultInformation.currentTrx == transactionType.InventoryIn)
            {
                this.dtExistingAllBpartnerInformation =
                   this.getDatafromDataBase.getM_BPARTNERInfo(null, "",
                           "", "", triStateBool.yes, triStateBool.yes,
                           triStateBool.ignor, false, "AND");
            }

            if (generalResultInformation.currentTrx == transactionType.InventoryIn)
            {
                this.ckIsTrxSales.CheckState = CheckState.Unchecked;
                this.ckIsTrxSales.Enabled = false;
            }
            else if (generalResultInformation.currentTrx == transactionType.InventoryOut)
            {
                this.ckIsTrxSales.CheckState = CheckState.Checked;
                this.ckIsTrxSales.Enabled = false;
            }
            else if (generalResultInformation.currentTrx == transactionType.report)
            {
                this.ckIsTrxSales.Enabled = false;

                if(generalResultInformation.currentRequestedRptType == reportType.InventoryIn)
                    this.ckIsTrxSales.CheckState = CheckState.Unchecked;
                else if (generalResultInformation.currentRequestedRptType == reportType.InventoryOut)
                    this.ckIsTrxSales.CheckState = CheckState.Checked;                
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

        
        private void ddgTrxProduct_SelectedItemClicked(object sender, EventArgs e)
        {
            this.ddgTrxProduct.DataSource =
               this.getDatafromDataBase.getM_PRODUCTInfo(null, "", "",
                        "", "", "", this.ddgTrxProduct.SelectedItem, "", "", "", 
                               triStateBool.yes, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);
            this.ddgTrxProduct.DataTablePrimaryKey =
                Convert.ToUInt16(this.dtExistingAllProductInformation.Columns.IndexOf("M_PRODUCT_ID"));
            this.ddgTrxProduct.SelectedColomnIdex =
                this.dtExistingAllProductInformation.Columns.IndexOf("NAME");
            this.ddgTrxProduct.HiddenColoumns = new int[]
                                {
                                    this.dtExistingAllProductInformation.Columns.IndexOf("CREATED"),
                                    this.dtExistingAllProductInformation.Columns.IndexOf("UPDATED"),
                                    this.dtExistingAllProductInformation.Columns.IndexOf("M_PRODUCTCATEGORY_ID"),
                                    this.dtExistingAllProductInformation.Columns.IndexOf("M_UOM_ID"),
                                };
        }

        private void ddgTrxBpartner_SelectedItemClicked(object sender, EventArgs e)
        {
            this.ddgTrxBpartner.DataSource =
                this.dtExistingAllBpartnerInformation.Copy();
            this.ddgTrxBpartner.DataTablePrimaryKey =
                Convert.ToUInt16(this.dtExistingAllBpartnerInformation.Columns.IndexOf("M_BPARTNER_ID"));
            this.ddgTrxBpartner.SelectedColomnIdex =
                this.dtExistingAllBpartnerInformation.Columns.IndexOf("NAME");
            this.ddgTrxBpartner.HiddenColoumns = new int[]
                                {
                                    this.dtExistingAllBpartnerInformation.Columns.IndexOf("M_SHOP_ID"),
                                    this.dtExistingAllBpartnerInformation.Columns.IndexOf("AD_ORG_ID"),
                                    this.dtExistingAllBpartnerInformation.Columns.IndexOf("CREATED"),
                                    this.dtExistingAllBpartnerInformation.Columns.IndexOf("UPDATED"),
                                    this.dtExistingAllBpartnerInformation.Columns.IndexOf("CREATEDBY"),
                                    this.dtExistingAllBpartnerInformation.Columns.IndexOf("DESCRIPTION"),
                                    this.dtExistingAllBpartnerInformation.Columns.IndexOf("UPDATEDBY")
                                };
        }

        private void cmdShowPrdImageList_Click(object sender, EventArgs e)
        {
            this.ddgTrxProduct.SelectedRow.Clear();
            generalResultInformation.selectedProductId = "";
            frmProductImage frmProductImageList = new frmProductImage();
            frmProductImageList.ShowDialog();
            if (generalResultInformation.selectedProductId == "")
            {
                this.ddgTrxProduct.SelectedRowKey = null;
                this.ddgTrxProduct.SelectedItem = "";
            }
            else
            {
                DataTable dtProdcutInfo =
                    this.getDatafromDataBase.getM_PRODUCTInfo(null, "",
                                generalResultInformation.selectedProductId,
                                "", "", "", "", "", "", "", 
                                triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);

                this.ddgTrxProduct.SelectedItem = dtProdcutInfo.Rows[0]["NAME"].ToString();
                this.ddgTrxProduct.SelectedRowKey = dtProdcutInfo.Rows[0]["M_PRODUCT_ID"];
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
                            "T_TRANSACTION_ID");

                    fileName = "crptTrxSummary.rpt";
                    dsDataTableName = "dtTrxSummary";
                }
                else if (generalResultInformation.currentRequestedRptLevel == reportLevel.Detail)
                {
                    fileName = "crptTrxDetail.rpt";
                    dsDataTableName = "dtTrxDetail";
                }
                else
                {
                    return;
                }

                frmPrintViewer newPrintJobView = new frmPrintViewer();
                                
                dtsReportData dsNewTransactionReport = new dtsReportData();

                dsNewTransactionReport.Tables[dsDataTableName].Clear();

                DataRow drNewTransactionReport;

                string stRptTBColumnName = "";
                Type tpRptTBColumnDataType;

                for (int rowCounter = 0;
                    rowCounter <= dtSearchResult.Rows.Count - 1; rowCounter++)
                {
                    drNewTransactionReport =
                        dsNewTransactionReport.Tables[dsDataTableName].NewRow();
                    for (int columnCounter = 0;
                        columnCounter <=
                            dsNewTransactionReport.
                                Tables[dsDataTableName].Columns.Count - 1;
                        columnCounter++)
                    {
                        stRptTBColumnName =
                            dsNewTransactionReport.Tables[dsDataTableName].Columns[columnCounter].ColumnName;
                        tpRptTBColumnDataType =
                            dsNewTransactionReport.Tables[dsDataTableName].Columns[columnCounter].DataType.GetType();
                        if (dtSearchResult.Columns.Contains(stRptTBColumnName))
                        {
                            drNewTransactionReport[stRptTBColumnName] =
                                dtSearchResult.Rows[rowCounter][stRptTBColumnName];
                        }
                    }
                    dsNewTransactionReport.Tables[dsDataTableName].Rows.Add(drNewTransactionReport);
                }

                newPrintJobView.setUpThePreviewArea(fileName, dsNewTransactionReport);
                newPrintJobView.ShowDialog(this);

            }
            else if (generalResultInformation.currentTrx == transactionType.InventoryIn ||
                generalResultInformation.currentTrx == transactionType.InventoryOut)
            {
                DataTable dtTrxInfo = new DataTable();

                dtSearchResult =
                        this.getDatafromDataBase.clearRedundantRow(dtSearchResult,
                            "T_TRANSACTION_ID");

                this.searchQuery.Rows.Clear();
                for (int rowCounter = 0;
                    rowCounter <= dtSearchResult.Rows.Count - 1; rowCounter++)
                {
                    this.addMoreCriteria("T_TRANSACTION_ID", "Equals to",
                        dtSearchResult.
                            Rows[rowCounter]["T_TRANSACTION_ID"].ToString(),
                         "");
                }

                generalResultInformation.searchResult =
                    this.getDatafromDataBase.getT_TRANSACTIONInfo(this.searchQuery,
                            "OR", "", "", "", new DateTime(), false,
                            triStateBool.ignor, triStateBool.ignor,
                            triStateBool.ignor, transactionStatus.ignor,
                            false, "AND");

                this.Parent.Dispose();
            }
            
        }




        private void cmbTrxDateLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbTrxLogicDate.SelectedItem.ToString(),
                this.dtpTrxDateFrom);

            if (this.cmbTrxLogicDate.SelectedItem.ToString() == "In between of")
                this.dtpTrxDateTo.Visible = true;
            else
                this.dtpTrxDateTo.Visible = false;
        }

        private void cmbTrxProductLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbTrxLogicProduct.SelectedItem.ToString(),
                this.ddgTrxProduct);

            this.enableDisableValueInsertionBox(this.cmbTrxLogicProduct.SelectedItem.ToString(),
                this.cmdShowPrdImageList);
        }

        private void cmbTrxLogicStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbTrxLogicStation.SelectedItem.ToString(),
                this.cmbStations);

            if (this.dtAccessableOrganisations.Rows.Count > 0)
                this.cmbStations.SelectedIndex = 0;
        }

        private void cmbTrxLogicDocNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbTrxLogicDocNo.SelectedItem.ToString(),
               this.txtDocumentNo);
        }

        private void cmbTrxLogicBpartner_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbTrxLogicBpartner.SelectedItem.ToString(),
               this.ddgTrxBpartner);
        }

        private void cmbTrxLogicSubTotal_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbTrxLogicSubTotal.SelectedItem.ToString(),
                this.ntbSubTotalFrom);

            if (this.cmbTrxLogicSubTotal.SelectedItem.ToString() == "In between of")
                this.ntbSubTotalTo.Visible = true;
            else
                this.ntbSubTotalTo.Visible = false;

            this.ntbSubTotalFrom.Amount = "0";
            this.ntbSubTotalTo.Amount = "0";
        }

        private void cmbTrxLogicTaxTotal_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbTrxLogicTaxTotal.SelectedItem.ToString(),
                this.ntbTaxTotalFrom);

            if (this.cmbTrxLogicTaxTotal.SelectedItem.ToString() == "In between of")
                this.ntbTaxTotalTo.Visible = true;
            else
                this.ntbTaxTotalTo.Visible = false;

            this.ntbTaxTotalTo.Amount = "0";
            this.ntbTaxTotalFrom.Amount = "0";
        }

        private void cmbTrxLogicGrandTotal_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbTrxLogicGrandTotal.SelectedItem.ToString(),
                this.ntbGrandTotalFrom);

            if (this.cmbTrxLogicGrandTotal.SelectedItem.ToString() == "In between of")
                this.ntbGrandTotalTo.Visible = true;
            else
                this.ntbGrandTotalTo.Visible = false;

            this.ntbGrandTotalFrom.Amount = "0";
            this.ntbGrandTotalTo.Amount = "0";
        }

        private void cmbTrxLogicPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbTrxLogicPrice.SelectedItem.ToString(),
                this.ntbTrxPriceFrom);

            if (this.cmbTrxLogicPrice.SelectedItem.ToString() == "In between of")
                this.ntbTrxPriceTo.Visible = true;
            else
                this.ntbTrxPriceTo.Visible = false;

            this.ntbTrxPriceFrom.Amount = "0";
            this.ntbTrxPriceTo.Amount = "0";
        }

        private void cmbTrxLogicQuantity_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbTrxLogicQuantity.SelectedItem.ToString(),
                this.ntbTrxQtyFrom);

            if (this.cmbTrxLogicQuantity.SelectedItem.ToString() == "In between of")
                this.ntbTrxQtyTo.Visible = true;
            else
                this.ntbTrxQtyTo.Visible = false;

            this.ntbTrxQtyFrom.Amount = "0";
            this.ntbTrxQtyTo.Amount = "0";
        }

        private void cmbTrxLogicCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbTrxLogicCategory.SelectedItem.ToString(),
               this.cmbCategory);

            if (this.dtAllProductCategory.Rows.Count > 0)
                this.cmbCategory.SelectedIndex = 0;
        }

        private void cmbTrxLogicDocStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbTrxLogicDocStatus.SelectedItem.ToString(),
               this.cmbTrxDocstatus);
            if (this.cmbTrxDocstatus.Items.Count > 0)
                this.cmbTrxDocstatus.SelectedIndex = 0;
        }

        private void cmbTrxLogicWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbTrxLogicWarehouse.SelectedItem.ToString(),
               this.cmbWarehouse);

            if (this.dtAllAccessableWarehouse.Rows.Count > 0)
                this.cmbWarehouse.SelectedIndex = 0;            
        }

    }
}
