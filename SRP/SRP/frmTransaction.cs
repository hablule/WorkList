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
    public partial class frmTransaction : Panel
    {
        public frmTransaction()
        {
            InitializeComponent();            
        }

        string stringShopID = generalResultInformation.activeStation;
        
        string stOrganisationID = "";

        int intTransactionID = 0;
        int intProductID = 0;
        int intBpartnerID = 0;
        int intDispatchingStoreId = 0;
        
        int intDetailTrxPrdPreviousUnitIndex = -1;

        bool blcurrentTrxProcessed = false;
        bool blCurrentRecordIsReadOnly = false;
                
        static private Color clNormalLableColor = Color.Black;
        static private Color clErrorLableColor = Color.Red;
        static private Color clChangedLableColor = Color.Blue;
                
        DataTable dtNewTransactionInformation = new DataTable();
        DataTable dtNewDetailTransactionInformation = new DataTable();

        DataTable dtAccessableOrgInformation = new DataTable();
        DataTable dtExistingActiveProductInformation = new DataTable();
        DataTable dtExistingActiveBpartnerInformation = new DataTable();
        DataTable dtCrrUsrAccActiveWarehouse = new DataTable();
        
        DataTable dtExistingTransactionInformation = new DataTable();
        DataTable dtExistingDetailTransactionInformation = new DataTable();

        //DataTable dtDetailTrxItemStandardUnit = new DataTable();
        DataTable dtDetailTrxItemAlternateUnit = new DataTable();

        DataTable dtAllUOMInformation = new DataTable();
        DataTable dtTentativeTransactionDetail = new DataTable();

        private dataBuilder getDatafromDataBase = new dataBuilder();
        private businessRule getDataAccordingToRule = new businessRule();

        DataGridViewCellStyle cancelButtonStyle = new DataGridViewCellStyle();

        private void setUpOrganisations()
        {
            this.cmbOrganisation.Items.Clear();
            this.dtAccessableOrgInformation =
                this.getDataAccordingToRule.getCurrentUserAccessableOrganisation(accessLevel.ReadWite,
                        triStateBool.ignor);

            if (this.getDatafromDataBase.checkIfTableContainesData(this.dtAccessableOrgInformation))
            {
                for (int rowCounter = 0;
                        rowCounter <= this.dtAccessableOrgInformation.Rows.Count - 1; rowCounter++)
                {
                    this.cmbOrganisation.Items.Add(
                            this.dtAccessableOrgInformation.Rows[rowCounter]["NAME"].ToString());
                }
                this.cmbOrganisation.SelectedIndex = 0;
            }
            else
            {
                this.stOrganisationID = "";
            }
        }

        private void displayCurrentQtyStockAmount()
        {
            ctlNumberTextBox stkQty = new ctlNumberTextBox();
            stkQty.AllowNegative = true;
            stkQty.Amount = "0";
            
            if (this.intProductID > 0 &&
                this.intDispatchingStoreId > 0)
            {
                DataTable dtProductInfo =
                this.getDatafromDataBase.getM_PRODUCTInfo(null, "",
                    this.intProductID.ToString(), "", "", "", "",
                    "", "", "", triStateBool.ignor, false, "AND",
                    generalResultInformation.dbBulkDataRetrivalSize);

                DataTable dtUnitInfo =
                        this.getDatafromDataBase.getM_UOMInfo(null, "",
                            dtProductInfo.Rows[0]["M_UOM_ID"].ToString(), "", "",
                                triStateBool.ignor, false, "AND");

                if (this.getDatafromDataBase.checkIfTableContainesData(dtUnitInfo))
                {
                    stkQty.StandardPrecision =
                        int.Parse(dtUnitInfo.Rows[0]["STDPRECISION"].ToString());
                }

                DataTable dtStockQty =
                   this.getDatafromDataBase.getQ_STOCKInfo(null, "",
                               this.intProductID.ToString(), this.intDispatchingStoreId.ToString(),
                               triStateBool.yes, false, "AND");
                if (this.getDatafromDataBase.checkIfTableContainesData(dtStockQty))
                {
                    stkQty.Amount = dtStockQty.Rows[0]["CURRENTQTY"].ToString();
                }                          
            }

            this.txtDetailTrxStockQty.Text = stkQty.Value;
            if (decimal.Parse(stkQty.Value) <= 0)
                this.txtDetailTrxStockQty.ForeColor = Color.Red;
            else
                this.txtDetailTrxStockQty.ForeColor = Color.Black;
        }

        private bool createTransactionSummaryRecord()
        {
            DataTable dtTrxInfo = this.getDatafromDataBase.getT_TRANSACTIONInfo(null, "", 
                    this.intTransactionID.ToString(), "", "", new DateTime(), 
                    false, triStateBool.ignor, triStateBool.ignor, 
                    triStateBool.yes, transactionStatus.ignor, 
                    false, "AND");

            if (!this.getDatafromDataBase.checkIfTableContainesData(dtTrxInfo))
                return false;
            
            string docStatus = dtTrxInfo.Rows[0]["DOCSTATUS"].ToString();

            if (docStatus == "DR")
                return false;                

            DataTable dtCurrentTrnxDetail = 
                this.getDatafromDataBase.getT_TRXDETAILInfo(null, "", "", 
                        this.intTransactionID.ToString(), "", new DateTime(), false,
                        triStateBool.ignor, "", 
                        triStateBool.ignor, false, "AND");

            if (!this.getDatafromDataBase.checkIfTableContainesData(dtCurrentTrnxDetail))
                return false;

            DataTable dtNewMtransactionSummerizer = 
                this.getDatafromDataBase.getM_TRANSACTIONInfo(null, "", "", "",
                        "", "", new DateTime(), false, "", "", "", 
                        triStateBool.ignor, true, "AND");            

            for (int rowCounter = 0; rowCounter <= dtCurrentTrnxDetail.Rows.Count - 1; rowCounter++)
            {
                DataRow drNewMtrxSummaryRow = dtNewMtransactionSummerizer.NewRow();

                drNewMtrxSummaryRow["M_SHOP_ID"] =
                    dtCurrentTrnxDetail.Rows[rowCounter]["M_SHOP_ID"].ToString();

                drNewMtrxSummaryRow["AD_ORG_ID"] =
                    dtCurrentTrnxDetail.Rows[rowCounter]["AD_ORG_ID"].ToString();

                if (generalResultInformation.currentTrx == transactionType.InventoryOut)
                {
                    drNewMtrxSummaryRow["MOVEMENTTYPE"] = 
                        this.getDataAccordingToRule.getStringEquivelentOfMoveType(movementType.C_n);
                    
                    drNewMtrxSummaryRow["MOVEMENTQTY"] = -1 *
                        decimal.Parse(dtCurrentTrnxDetail.Rows[rowCounter]["TRXQUANTITY"].ToString());
                }
                else if (generalResultInformation.currentTrx == transactionType.InventoryIn)
                {
                    drNewMtrxSummaryRow["MOVEMENTTYPE"] =
                        this.getDataAccordingToRule.getStringEquivelentOfMoveType(movementType.V_p);
                    
                    drNewMtrxSummaryRow["MOVEMENTQTY"] = 
                        decimal.Parse(dtCurrentTrnxDetail.Rows[rowCounter]["TRXQUANTITY"].ToString());
                }

                if (docStatus == "RE")
                {
                    drNewMtrxSummaryRow["MOVEMENTQTY"] = -1 *
                        decimal.Parse(drNewMtrxSummaryRow["MOVEMENTQTY"].ToString());
                }                
                
                drNewMtrxSummaryRow["M_LOCATOR_ID"] =
                    dtCurrentTrnxDetail.Rows[rowCounter]["M_WAREHOUSE_ID"].ToString();

                drNewMtrxSummaryRow["M_PRODUCT_ID"] =
                    dtCurrentTrnxDetail.Rows[rowCounter]["M_PRODUCT_ID"].ToString();

                drNewMtrxSummaryRow["MOVEMENTDATE"] =
                    dtCurrentTrnxDetail.Rows[rowCounter]["TRXDATE"].ToString();                

                drNewMtrxSummaryRow["C_UOM_ID"] =
                    dtCurrentTrnxDetail.Rows[rowCounter]["M_UOM_ID"].ToString();
                
                drNewMtrxSummaryRow["M_INOUTLINE_ID"] =
                    dtCurrentTrnxDetail.Rows[rowCounter]["T_TRXDETAIL_ID"].ToString();

                dtNewMtransactionSummerizer.Rows.Add(drNewMtrxSummaryRow);
            }

            string[] primaryKeySepartor = { " <(", ")>||" };
            string[] primaryKey =
                this.getDatafromDataBase.changeDataBaseTableData
                        (dtNewMtransactionSummerizer.Copy(), "M_TRANSACTION", "INSERT")[0]
                            .Split(primaryKeySepartor, StringSplitOptions.RemoveEmptyEntries);

            if (primaryKey.Length < 2)
            {
                MessageBox.Show("Transaction Summary was not saved. Contact Your Admin.",
                    "SRP SAVE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            return true;

        }

        private bool saveRecord(bool blCompleteProcess)
        {
            string stTypeOfChange = "INSERT";
            this.dtNewTransactionInformation =
                this.getDatafromDataBase.getT_TRANSACTIONInfo(null, "",
                        "", "", "", new DateTime(), false, triStateBool.ignor,
                            triStateBool.ignor, triStateBool.ignor,
                            transactionStatus.ignor, true, "");

            DataRow drNewTransaction = this.dtNewTransactionInformation.NewRow();

            if (this.intTransactionID != 0)
            {
                stTypeOfChange = "UPDATE";
                drNewTransaction["T_TRANSACTION_ID"] = this.intTransactionID.ToString();
            }
            else
            {
                stTypeOfChange = "INSERT";
            }

            string stDocNumber = "";
            if (this.intTransactionID == 0 && this.txtTrxDocumentNo.Text.StartsWith("<") &&
                this.txtTrxDocumentNo.Text.EndsWith(">"))
            {
                DataTable dtSequenceInfo = new DataTable();

                string stDOCBASETYPE = "";

                if (generalResultInformation.currentTrx == transactionType.InventoryOut)
                {
                    stDOCBASETYPE = "SALES";
                }
                else if (generalResultInformation.currentTrx == transactionType.InventoryIn)
                {
                    stDOCBASETYPE = "PURCHASE";
                }

                dtSequenceInfo = getDatafromDataBase.getU_SEQUENCEInfo(null, "",
                            "", "", triStateBool.yes, triStateBool.No,
                            stDOCBASETYPE, false, "AND");
                if (dtSequenceInfo.Rows.Count > 0)
                {
                    string stDocSeqId =
                        dtSequenceInfo.Rows[0]["U_SEQUENCE_ID"].ToString();
                    stDocNumber =
                        this.getDatafromDataBase.getNextSequenceId(
                            dtSequenceInfo.Rows[0]["NAME"].ToString(),
                            dtSequenceInfo.Rows[0]["U_SEQUENCE_ID"].ToString(), triStateBool.No,
                            dtSequenceInfo.Rows[0]["BASEDOC"].ToString(), true);
                    if (stDocSeqId == "")
                    {
                        MessageBox.Show("There Seems to Be a problem while saving record.\n Please Try again.",
                            "SRP SAVE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            else
            {
                stDocNumber = this.txtTrxDocumentNo.Text;
            }

            drNewTransaction["M_SHOP_ID"] = this.stringShopID;
            drNewTransaction["AD_ORG_ID"] = this.stOrganisationID;
            drNewTransaction["DOCUMENTNO"] = stDocNumber;
            drNewTransaction["DESCRIPTION"] = this.txtDetailTrxDescription.Text;
            drNewTransaction["TRXDATE"] = this.dtpTrxDate.Value;
            drNewTransaction["M_BPARTNER_ID"] = this.ddgTrxBpartner.SelectedRowKey.ToString();
            if (generalResultInformation.currentTrx == transactionType.InventoryOut)
                drNewTransaction["ISSALESTRX"] = "Y";
            else if (generalResultInformation.currentTrx == transactionType.InventoryIn)
                drNewTransaction["ISSALESTRX"] = "N";
            drNewTransaction["SUBTRXAMOUNT"] = this.lblTransactionSubTotal.Text.Replace(",", "");
            drNewTransaction["TRXTAXAMOUNT"] = this.lblTransactionTax.Text.Replace(",", "");
            drNewTransaction["GRANDTRXAMOUNT"] = this.lblTransactionGrandTotal.Text.Replace(",", "");

            if (blCompleteProcess)
                drNewTransaction["PROCESSED"] = "Y";
            else
                drNewTransaction["PROCESSED"] = "N";

            if (!blCompleteProcess)
                drNewTransaction["DOCSTATUS"] = "DR";
            else
                drNewTransaction["DOCSTATUS"] = "CO";

            this.dtNewTransactionInformation.Rows.Add(drNewTransaction);

            string[] primaryKeySepartor = { " <(", ")>||" };
            string[] primaryKey =
                this.getDatafromDataBase.changeDataBaseTableData
                        (this.dtNewTransactionInformation.Copy(), "T_TRANSACTION", stTypeOfChange)[0]
                            .Split(primaryKeySepartor, StringSplitOptions.RemoveEmptyEntries);

            if (primaryKey.Length < 2 && stTypeOfChange == "INSERT")
            {
                MessageBox.Show("Unable To Process Your Request. Please Contact Your Admin.",
                    "SRP SAVE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (primaryKey.Length > 1 && stTypeOfChange == "INSERT")
            {
                this.intTransactionID = int.Parse(primaryKey[1]);
            }

            this.dtNewDetailTransactionInformation =
                this.getDatafromDataBase.getT_TRXDETAILInfo(null, "", "", "", "",
                                new DateTime(), false, triStateBool.ignor, "", triStateBool.ignor,
                                true, "AND");            

            for (int rowCounter = 0;
                rowCounter < this.dtTentativeTransactionDetail.Rows.Count; rowCounter++)
            {
                DataRow drNewTrxDetail = this.dtNewDetailTransactionInformation.NewRow();

                drNewTrxDetail["T_TRANSACTION_ID"] = this.intTransactionID.ToString();
                drNewTrxDetail["M_SHOP_ID"] = this.stringShopID;
                drNewTrxDetail["AD_ORG_ID"] = this.stOrganisationID;
                drNewTrxDetail["TRXDATE"] =
                    this.dtNewTransactionInformation.Rows[0]["TRXDATE"].ToString();
                drNewTrxDetail["M_BPARTNER_ID"] =
                    this.dtNewTransactionInformation.Rows[0]["M_BPARTNER_ID"].ToString();
                drNewTrxDetail["ISSALESTRX"] =
                    this.dtNewTransactionInformation.Rows[0]["ISSALESTRX"].ToString();

                if (this.dtTentativeTransactionDetail.Rows[rowCounter]["T_TRXDETAIL_ID"].ToString() != "")
                    drNewTrxDetail["T_TRXDETAIL_ID"] =
                        this.dtTentativeTransactionDetail.Rows[rowCounter]["T_TRXDETAIL_ID"].ToString();
                drNewTrxDetail["LINE"] =
                    this.dtTentativeTransactionDetail.Rows[rowCounter]["LINE"].ToString();
                drNewTrxDetail["M_PRODUCT_ID"] =
                    this.dtTentativeTransactionDetail.Rows[rowCounter]["M_PRODUCT_ID"].ToString();
                drNewTrxDetail["M_UOM_ID"] =
                    this.dtTentativeTransactionDetail.Rows[rowCounter]["M_UOM_ID"].ToString();
                drNewTrxDetail["M_WAREHOUSE_ID"] =
                    this.dtTentativeTransactionDetail.Rows[rowCounter]["M_WAREHOUSE_ID"].ToString();
                drNewTrxDetail["DESCRIPTION"] =
                    this.dtTentativeTransactionDetail.Rows[rowCounter]["DESCRIPTION"].ToString();
                drNewTrxDetail["TRXQUANTITY"] =
                    this.dtTentativeTransactionDetail.
                        Rows[rowCounter][this.lblDetailTrxQuantity.Text].ToString().Replace(",", "");
                drNewTrxDetail["UNITPRICE"] =
                    this.dtTentativeTransactionDetail.Rows[rowCounter]["PRICE"].ToString().Replace(",", "");
                drNewTrxDetail["LINENETAMT"] =
                    this.dtTentativeTransactionDetail.Rows[rowCounter]["LINE AMT"].ToString().Replace(",", "");
                drNewTrxDetail["LINETAXAMOUNT"] =
                    this.dtTentativeTransactionDetail.Rows[rowCounter]["TAX AMT"].ToString().Replace(",", "");

                drNewTrxDetail["DISCOUNTAMT"] =
                    this.dtTentativeTransactionDetail.Rows[rowCounter]["DISCOUNT AMT"].ToString().Replace(",", "");
                
                drNewTrxDetail["DISCOUNTRATE"] =
                    this.dtTentativeTransactionDetail.Rows[rowCounter]["DISCOUNT RATE"].ToString().Replace(",", "");

                drNewTrxDetail["MARGIN"] =
                    this.dtTentativeTransactionDetail.Rows[rowCounter]["MARGIN"].ToString().Replace(",", "");

                drNewTrxDetail["UNITCOST"] =
                    this.dtTentativeTransactionDetail.Rows[rowCounter]["UNITCOST"].ToString().Replace(",", "");

                this.dtNewDetailTransactionInformation.Rows.Add(drNewTrxDetail);
            }

            primaryKey =
                this.getDatafromDataBase.changeDataBaseTableData
                        (this.dtNewDetailTransactionInformation.Copy(), "T_TRXDETAIL", "UPDATE")[0]
                            .Split(primaryKeySepartor, StringSplitOptions.RemoveEmptyEntries);            

            if (primaryKey.Length < 2 && stTypeOfChange == "INSERT")
            {
                MessageBox.Show("Unable To Process You Request. Contact Your Admin.",
                    "SRP SAVE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!blCompleteProcess)
            {
                goto finalLine;
            }

            bool saveTrxSummary = this.createTransactionSummaryRecord();

            if (!saveTrxSummary)
            {
                goto finalLine;
            }

            int qtySingModifier = 0;
            for (int rowCounter = 0;
                rowCounter < this.dtNewDetailTransactionInformation.Rows.Count; rowCounter++)
            {
                DataTable dtProductInformation =
                    this.getDatafromDataBase.getM_PRODUCTInfo(null, "",
                            this.dtNewDetailTransactionInformation.
                                                    Rows[rowCounter]["M_PRODUCT_ID"].ToString(),
                            "", "", "", "", "", "", "", triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);
                
                // change in Q_cost
                DataTable dtProductCostInfo =
                    this.getDatafromDataBase.getQ_COSTInfo(null, "",
                        this.dtNewDetailTransactionInformation.
                                                    Rows[rowCounter]["M_PRODUCT_ID"].ToString(),
                        0, 0, 0, 0, triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);

                if (!this.getDatafromDataBase.checkIfTableContainesData(dtProductInformation) ||
                    !this.getDatafromDataBase.checkIfTableContainesData(dtProductCostInfo))
                {
                    MessageBox.Show("Missing Product Value. Contact Your Admin.",
                        "SRP SAVE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                if (generalResultInformation.currentTrx == transactionType.InventoryIn)
                {
                    qtySingModifier = 1;
                    dtProductCostInfo.Rows[0]["CURRENTCOST"] =
                       (
                         (
                          decimal.Parse(dtProductCostInfo.Rows[0]["CURRENTQTY"].ToString()) *
                          decimal.Parse(dtProductCostInfo.Rows[0]["CURRENTCOST"].ToString())
                         ) +
                         (
                          decimal.Parse(this.dtNewDetailTransactionInformation.
                                        Rows[rowCounter]["LINENETAMT"].ToString())
                         )
                       )
                            /
                       (
                          decimal.Parse(dtProductCostInfo.Rows[0]["CURRENTQTY"].ToString()) +
                          decimal.Parse(this.dtNewDetailTransactionInformation.
                                        Rows[rowCounter]["TRXQUANTITY"].ToString())
                       );

                    if (dtProductInformation.Rows[0]["PRODUCTTYPE"].ToString().ToUpperInvariant() == "I")
                    {
                        dtProductCostInfo.Rows[0]["ACCUMULATEDQTY"] =
                            decimal.Parse(dtProductCostInfo.Rows[0]["ACCUMULATEDQTY"].ToString()) +
                            decimal.Parse(this.dtNewDetailTransactionInformation.
                                            Rows[rowCounter]["TRXQUANTITY"].ToString());
                    }

                    dtProductCostInfo.Rows[0]["ACCUMULATEDCOST"] =
                        decimal.Parse(dtProductCostInfo.Rows[0]["ACCUMULATEDCOST"].ToString()) +
                        decimal.Parse(this.dtNewDetailTransactionInformation.
                                        Rows[rowCounter]["LINENETAMT"].ToString());

                }
                else if (generalResultInformation.currentTrx == transactionType.InventoryOut)
                {
                    qtySingModifier = -1;
                }
                primaryKey =
                    this.getDatafromDataBase.changeDataBaseTableData
                       (dtProductCostInfo.Copy(), "Q_COST", "UPDATE")[0]
                           .Split(primaryKeySepartor, StringSplitOptions.RemoveEmptyEntries);

                this.getDataAccordingToRule.adjustStock(
                        this.dtNewDetailTransactionInformation.Rows[rowCounter]["M_PRODUCT_ID"].ToString(),
                        this.dtNewDetailTransactionInformation.Rows[rowCounter]["M_WAREHOUSE_ID"].ToString(),
                            qtySingModifier *
                            decimal.Parse(this.dtNewDetailTransactionInformation.
                                            Rows[rowCounter]
                                                ["TRXQUANTITY"].ToString()
                                                    .Replace(",", "")));
            }

        finalLine:

            if (stTypeOfChange == "INSERT")
            {
                DataRow drNewExistingTrxRow =
                       this.dtExistingTransactionInformation.NewRow();
                drNewExistingTrxRow["T_TRANSACTION_ID"] = this.intTransactionID.ToString();
                drNewExistingTrxRow["DOCUMENTNO"] = this.txtTrxDocumentNo.Text;
                drNewExistingTrxRow["TRXDATE"] = this.dtpTrxDate.Value.ToString();
                drNewExistingTrxRow["DESCRIPTION"] = this.txtTrxDescription.Text;
                drNewExistingTrxRow["M_BPARTNER_ID"] = this.intBpartnerID.ToString();
                drNewExistingTrxRow["BIZ PARTNER"] = this.ddgTrxBpartner.SelectedItem.ToString();
                drNewExistingTrxRow["SUBTRXAMOUNT"] = this.lblTransactionSubTotal.Text;
                drNewExistingTrxRow["TRXTAXAMOUNT"] = this.lblTransactionTax.Text;
                drNewExistingTrxRow["GRANDTRXAMOUNT"] = this.lblTransactionGrandTotal.Text;
                if (generalResultInformation.currentTrx == transactionType.InventoryOut)
                    drNewExistingTrxRow["ISSALESTRX"] = "Y";
                else if (generalResultInformation.currentTrx == transactionType.InventoryIn)
                    drNewExistingTrxRow["ISSALESTRX"] = "N";
                if (blCompleteProcess)
                {
                    drNewExistingTrxRow["PROCESSED"] = "N";
                    drNewExistingTrxRow["DOCSTATUS"] = "DRAFTED";
                }
                else if (blCompleteProcess)
                {
                    drNewExistingTrxRow["PROCESSED"] = "Y";
                    drNewExistingTrxRow["DOCSTATUS"] = "COMPLETED";
                }

                this.dtExistingTransactionInformation.Rows.Add(drNewExistingTrxRow);
            }
            else if (stTypeOfChange == "UPDATE")
            {
                bool updateHasBeenMade = false;
                for (int rowCounter = 0;
                        rowCounter <= this.dtExistingTransactionInformation.Rows.Count - 1;
                        rowCounter++)
                {
                    if (this.intTransactionID.ToString() ==
                        this.dtExistingTransactionInformation.Rows[rowCounter]["T_TRANSACTION_ID"].ToString())
                    {

                        this.dtExistingTransactionInformation.
                            Rows[rowCounter]["DOCUMENTNO"] = this.txtTrxDocumentNo.Text;
                        this.dtExistingTransactionInformation.
                            Rows[rowCounter]["TRXDATE"] = this.dtpTrxDate.Value.ToString();
                        this.dtExistingTransactionInformation.
                            Rows[rowCounter]["DESCRIPTION"] = this.txtTrxDescription.Text;
                        this.dtExistingTransactionInformation.
                            Rows[rowCounter]["M_BPARTNER_ID"] = this.intBpartnerID.ToString();
                        this.dtExistingTransactionInformation.
                            Rows[rowCounter]["BIZ PARTNER"] = this.ddgTrxBpartner.SelectedItem.ToString();
                        this.dtExistingTransactionInformation.
                            Rows[rowCounter]["SUBTRXAMOUNT"] = this.lblTransactionSubTotal.Text;
                        this.dtExistingTransactionInformation.
                            Rows[rowCounter]["TRXTAXAMOUNT"] = this.lblTransactionTax.Text;
                        this.dtExistingTransactionInformation.
                            Rows[rowCounter]["GRANDTRXAMOUNT"] = this.lblTransactionGrandTotal.Text;
                        if (generalResultInformation.currentTrx == transactionType.InventoryOut)
                            this.dtExistingTransactionInformation.
                                Rows[rowCounter]["ISSALESTRX"] = "Y";
                        else if (generalResultInformation.currentTrx == transactionType.InventoryIn)
                            this.dtExistingTransactionInformation.
                                Rows[rowCounter]["ISSALESTRX"] = "N";
                        if (blCompleteProcess)
                        {
                            this.dtExistingTransactionInformation.
                                Rows[rowCounter]["PROCESSED"] = "N";
                            this.dtExistingTransactionInformation.
                             Rows[rowCounter]["DOCSTATUS"] = "DRAFTED";
                        }
                        else if (blCompleteProcess)
                        {
                            this.dtExistingTransactionInformation.
                                Rows[rowCounter]["PROCESSED"] = "Y";
                            this.dtExistingTransactionInformation.
                             Rows[rowCounter]["DOCSTATUS"] = "COMPLETED";
                        }

                        updateHasBeenMade = true;
                        break;
                    }
                }
                if (!updateHasBeenMade)
                {
                    this.dtExistingTransactionInformation.Clear();
                }

            }

            this.dtgTransactionGridView.DataSource = this.dtExistingTransactionInformation;
            return true;
        }

        private bool checkForCompleteNewRecord()
        {
            bool foundError = false;

            if (this.stOrganisationID == "" ||
                this.dtAccessableOrgInformation.Rows.Count <= 0)
            {
                this.lblOrganisation.ForeColor = clErrorLableColor;
                foundError = true;
            }
            else
            {
                this.lblOrganisation.ForeColor = clNormalLableColor;
            }

            if (this.txtTrxDocumentNo.Text == "")
            {
                this.lblTrxDocumentNo.ForeColor = clErrorLableColor;
                foundError = true;
            }
            else
            {
                this.lblTrxDocumentNo.ForeColor = clNormalLableColor;
            }

            if (this.intBpartnerID == 0 ||
                this.ddgTrxBpartner.SelectedRow == null ||
                this.ddgTrxBpartner.SelectedRowKey == null)
            {
                this.lblTrxBpartner.ForeColor = clErrorLableColor;
                foundError = true;
            }
            else
            {
                this.lblTrxBpartner.ForeColor = clNormalLableColor;
            }

            if (this.dtTentativeTransactionDetail.Rows.Count == 0)
            {
                this.dtgTransactionDetail.BackgroundColor = clErrorLableColor;
                foundError = true;
            }
            else
            {
                this.dtgTransactionDetail.BackgroundColor =
                    this.dtgTransactionGridView.BackgroundColor;
            }

            if (this.dtpTrxDate.Value == null)
            {
                this.lblTrxDate.ForeColor = clErrorLableColor;
                foundError = true;
            }
            else
            {
                this.lblTrxDate.ForeColor = clNormalLableColor;
            }

            return foundError;
        }

        private void updateTotalTrxAmountIndicators()
        {
            decimal subTotal = 0;
            decimal taxTotal = 0;
            decimal grandTotal = 0;

            ctlNumberTextBox converter = new ctlNumberTextBox();
            

            for (int rowCounter = 0; 
                this.dtTentativeTransactionDetail.Rows.Count > rowCounter; 
                rowCounter++)
            {
                subTotal +=
                    decimal.Parse(this.dtTentativeTransactionDetail.Rows[rowCounter]["LINE AMT"].ToString());
                taxTotal +=
                    decimal.Parse(this.dtTentativeTransactionDetail.Rows[rowCounter]["TAX AMT"].ToString()); 
            }
            grandTotal = subTotal + taxTotal;

            converter.Amount = subTotal.ToString();
            this.lblTransactionSubTotal.Text = converter.Value;
            converter.Amount = taxTotal.ToString();
            this.lblTransactionTax.Text = converter.Value;
            converter.Amount = grandTotal.ToString();
            this.lblTransactionGrandTotal.Text = converter.Value;

        }

        private void determinCurrentRecordReadOnlySatust()
        {
            if (this.intTransactionID <= 0)
                this.blCurrentRecordIsReadOnly = false;
            
            if (this.stOrganisationID == "")
                this.blCurrentRecordIsReadOnly = true;

            accessLevel userAccess =
                this.getDataAccordingToRule.getCurrentUserOrganisationAccessLevel(this.stOrganisationID);

            if (userAccess != accessLevel.ReadWite)
                this.blCurrentRecordIsReadOnly = true;
        }

        private void enableDisableFormElement()
        {
            if (this.intTransactionID == 0)
                this.blcurrentTrxProcessed = false;

            if (!this.blcurrentTrxProcessed)
            {
                this.determinCurrentRecordReadOnlySatust();
                if (this.blCurrentRecordIsReadOnly)
                    this.blcurrentTrxProcessed = true;
            }


            this.cmbOrganisation.Enabled = !this.blcurrentTrxProcessed;
            this.txtTrxDocumentNo.Enabled = !this.blcurrentTrxProcessed;
            this.dtpTrxDate.Enabled = !this.blcurrentTrxProcessed;
                        
            this.ddgDetailProduct.Enabled = !this.blcurrentTrxProcessed;
            this.ntbDetailTrxQuantity.Enabled = !this.blcurrentTrxProcessed;
            this.cmbDetailTrxOtherUOM.Enabled = !this.blcurrentTrxProcessed;
            this.ntbDetailTrxUnitPrice.Enabled = !this.blcurrentTrxProcessed;
            this.ntbDetailTrxTax.Enabled = !this.blcurrentTrxProcessed;
            this.cmdDetailTrxAddLine.Enabled = !this.blcurrentTrxProcessed;

            if (generalResultInformation.currentTrx == transactionType.InventoryOut)
            {
                this.cmdDetailTrxNewProduct.Visible = false;
            }
            else if (frmAccessPrivilages.accFrmProduct == accessLevel.ReadWite)
            {
                this.cmdDetailTrxNewProduct.Visible = true;
                this.cmdDetailTrxNewProduct.Enabled = !this.blcurrentTrxProcessed;
            }
            else
                this.cmdDetailTrxNewProduct.Visible = false;

            this.cmdDetailTrxProductImage.Enabled = !this.blcurrentTrxProcessed;
            this.txtDetailTrxDescription.Enabled = !this.blcurrentTrxProcessed;
            this.txtDetailTrxLineTotal.Enabled = !this.blcurrentTrxProcessed;
            this.cmbDetailTrxDispatchingStore.Enabled = !this.blcurrentTrxProcessed;

            this.dtgTransactionDetail.Columns["REMOVE"].Visible = 
                !this.blcurrentTrxProcessed;
            this.ddgTrxBpartner.Enabled = !this.blcurrentTrxProcessed;

            if (frmAccessPrivilages.accFrmBpartner == accessLevel.ReadWite)
            {
                this.cmdNewBpartner.Visible = true;
                this.cmdNewBpartner.Enabled = !this.blcurrentTrxProcessed;
            }
            else
                this.cmdNewBpartner.Visible = false;

            this.txtTrxDescription.Enabled = !this.blcurrentTrxProcessed;
            if(this.dtgTransactionGridView.SelectedRows.Count == 0)
                this.tlsDelete.Enabled = false;
            else if(this.dtgTransactionGridView.Rows
                    [this.dtgTransactionGridView.SelectedRows[0].Index].
                        Cells["PROCESSED"].Value.ToString().ToUpperInvariant() != "N")
                this.tlsDelete.Enabled = false;
            else
                this.tlsDelete.Enabled = true;

            this.tlsSave.Enabled = !this.blcurrentTrxProcessed;
            this.tlsReverse.Enabled = this.blcurrentTrxProcessed;
            this.tlsPrint.Enabled = false;
            if (this.intTransactionID != 0 || this.intTransactionID.ToString() != null)
                this.tlsPrint.Enabled = true;            
        }

        private void fillDetailTrxItemUOMComboBox()
        {
            this.cmbDetailTrxOtherUOM.Items.Clear();
            if (this.ddgDetailProduct.SelectedRowKey == null)
                return;

            DataTable dtPrdInfo =
                this.getDatafromDataBase.getM_PRODUCTInfo(null, "",
                    this.ddgDetailProduct.SelectedRowKey.ToString(), "", "", "", "", "",
                        "", "", triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);

            if (dtPrdInfo.Rows.Count <= 0)
                return;
            
            this.dtDetailTrxItemAlternateUnit =
                    this.getDatafromDataBase.getM_UOM_CONVERSIONInfo(null, "",
                        dtPrdInfo.Rows[0]["M_UOM_ID"].ToString(),
                        dtPrdInfo.Rows[0]["M_UOM_ID"].ToString(),
                        "", 0, triStateBool.ignor, false, "OR");

            for (int rowCounter = this.dtDetailTrxItemAlternateUnit.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                
                if (this.dtDetailTrxItemAlternateUnit.
                        Rows[rowCounter]["ISACTIVE"].ToString() != "Y")
                {
                    this.dtDetailTrxItemAlternateUnit.Rows.RemoveAt(rowCounter);
                    continue;
                }
                
                if(this.dtDetailTrxItemAlternateUnit.
                            Rows[rowCounter]["M_PRODUCT_ID"].ToString() != 
                        this.ddgDetailProduct.SelectedRowKey.ToString() &&
                        this.dtDetailTrxItemAlternateUnit.
                            Rows[rowCounter]["M_PRODUCT_ID"].ToString() != "" &&
                        this.dtDetailTrxItemAlternateUnit.
                            Rows[rowCounter]["M_PRODUCT_ID"].ToString() != "0"
                        )
                {
                    this.dtDetailTrxItemAlternateUnit.Rows.RemoveAt(rowCounter);
                    continue;
                }
            }


            for (int rowCounter = this.dtDetailTrxItemAlternateUnit.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {                
                if(this.dtDetailTrxItemAlternateUnit.
                    Rows[rowCounter]["M_PRODUCT_ID"].ToString() == "" ||
                   this.dtDetailTrxItemAlternateUnit.
                    Rows[rowCounter]["M_PRODUCT_ID"].ToString() == "0")
                {
                    for (int rowCounter2 = this.dtDetailTrxItemAlternateUnit.Rows.Count - 1;
                          rowCounter2 >= 0; rowCounter2--)
                    {
                        if((this.dtDetailTrxItemAlternateUnit.
                                Rows[rowCounter]["M_BASE_UOM_ID"].ToString() ==
                            this.dtDetailTrxItemAlternateUnit.
                                Rows[rowCounter2]["M_BASE_UOM_ID"].ToString() &&
                            this.dtDetailTrxItemAlternateUnit.
                                Rows[rowCounter]["M_DRIVED_UOM_ID"].ToString() ==
                            this.dtDetailTrxItemAlternateUnit.
                                Rows[rowCounter2]["M_DRIVED_UOM_ID"].ToString()) ||
                            (this.dtDetailTrxItemAlternateUnit.
                                Rows[rowCounter]["M_BASE_UOM_ID"].ToString() ==
                            this.dtDetailTrxItemAlternateUnit.
                                Rows[rowCounter2]["M_DRIVED_UOM_ID"].ToString() &&
                            this.dtDetailTrxItemAlternateUnit.
                                Rows[rowCounter]["M_BASE_UOM_ID"].ToString() ==
                            this.dtDetailTrxItemAlternateUnit.
                                Rows[rowCounter2]["M_DRIVED_UOM_ID"].ToString()))
                            
                        {                           
                            this.dtDetailTrxItemAlternateUnit.Rows.RemoveAt(rowCounter);                           
                            break;
                        }
                    }
                }
            }


            DataTable dtUnitInfo =
                    this.getDatafromDataBase.getM_UOMInfo(null, "",
                        dtPrdInfo.Rows[0]["M_UOM_ID"].ToString()
                        , "", "", triStateBool.ignor, false, "AND");
            if (dtUnitInfo.Rows.Count > 0)
            {
                this.cmbDetailTrxOtherUOM.Items.Insert(this.cmbDetailTrxOtherUOM.Items.Count,
                            dtUnitInfo.Rows[0]["ABBREVATION"].ToString());
                this.cmbDetailTrxOtherUOM.SelectedIndex = 0;
            }

            for (int rowCounter = 0; rowCounter <= this.dtDetailTrxItemAlternateUnit.Rows.Count - 1;
                rowCounter++)
            {

                string stUnitId = "";

                if (this.dtDetailTrxItemAlternateUnit.
                        Rows[rowCounter]["M_BASE_UOM_ID"].ToString() ==
                    dtPrdInfo.Rows[0]["M_UOM_ID"].ToString())
                    stUnitId = this.dtDetailTrxItemAlternateUnit.Rows[rowCounter]["M_DRIVED_UOM_ID"].ToString();
                else
                    stUnitId = this.dtDetailTrxItemAlternateUnit.Rows[rowCounter]["M_BASE_UOM_ID"].ToString();

                dtUnitInfo =
                    this.getDatafromDataBase.getM_UOMInfo(null, "",
                        stUnitId, "", "", triStateBool.ignor, false, "AND");
                if (dtUnitInfo.Rows.Count > 0)
                {
                    this.cmbDetailTrxOtherUOM.Items.Insert(this.cmbDetailTrxOtherUOM.Items.Count,
                                dtUnitInfo.Rows[0]["ABBREVATION"].ToString());
                }
            }
        }

        private void fillDispatchStoreList()
        {
            this.cmbDetailTrxDispatchingStore.Items.Clear();
            this.intDispatchingStoreId = 0;
            if (this.dtCrrUsrAccActiveWarehouse.Rows.Count > 0)
            {
                for (int rowCounter = 0; 
                     rowCounter <= this.dtCrrUsrAccActiveWarehouse.Rows.Count - 1; 
                     rowCounter++)
                {
                    this.cmbDetailTrxDispatchingStore.Items.Add(
                                        this.dtCrrUsrAccActiveWarehouse.
                                            Rows[rowCounter]
                                                ["NAME"].ToString());
                }
                this.cmbDetailTrxDispatchingStore.SelectedIndex = 0;
            }
        }

        private void convertItemInfoToStandardUnit()
        {
            if (this.cmbDetailTrxOtherUOM.SelectedIndex == 0)
                return;
            int intSelectedUnitIndex = this.cmbDetailTrxOtherUOM.SelectedIndex - 1;

            decimal dcMultiplier =
                decimal.Parse(this.dtDetailTrxItemAlternateUnit.
                    Rows[intSelectedUnitIndex]["MULTIPLIER"].ToString());
            ctlNumberTextBox converter = new ctlNumberTextBox();
            converter.Amount = dcMultiplier.ToString();
            dcMultiplier = decimal.Parse(converter.Amount);

            if (this.ddgDetailProduct.SelectedRow.Rows[0]["M_UOM_ID"].ToString() ==
                this.dtDetailTrxItemAlternateUnit.
                    Rows[intSelectedUnitIndex]["M_DRIVED_UOM_ID"].ToString())
            {
                this.ntbDetailTrxQuantity.Amount =
                    (decimal.Parse(this.ntbDetailTrxQuantity.Amount) *
                        dcMultiplier).ToString();

                this.ntbDetailTrxUnitPrice.Amount =
                    (decimal.Parse(this.ntbDetailTrxUnitPrice.Amount) *
                        dcMultiplier).ToString();

                //if (!this.ckDetailTrxLinePrctage.Checked)
                //{
                //    this.ntbDetailTrxTax.Amount =
                //    (decimal.Parse(this.ntbDetailTrxTax.Amount) *
                //        dcMultiplier).ToString(); 
                //}
            }
            else
            {
                this.ntbDetailTrxQuantity.Amount =
                    (decimal.Parse(this.ntbDetailTrxQuantity.Amount) /
                        dcMultiplier).ToString();

                this.ntbDetailTrxUnitPrice.Amount =
                    (decimal.Parse(this.ntbDetailTrxUnitPrice.Amount) /
                        dcMultiplier).ToString();

                //if (!this.ckDetailTrxLinePrctage.Checked)
                //{
                //    this.ntbDetailTrxTax.Amount =
                //    (decimal.Parse(this.ntbDetailTrxTax.Amount) /
                //        dcMultiplier).ToString();
                //}
            }

            this.cmbDetailTrxOtherUOM.SelectedIndex = 0;

        }

        private string getNextDocumentNumber()
        {
            string stNextSequenceNo = "";
            string stDOCBASETYPE = "";

            DataTable dtSequenceInfo = new DataTable();
                        
            if (generalResultInformation.currentTrx == transactionType.InventoryOut)
            {
                stDOCBASETYPE = "SALES";
            }
            else if (generalResultInformation.currentTrx == transactionType.InventoryIn)
            {
                stDOCBASETYPE = "PURCHASE";
            }

            dtSequenceInfo = getDatafromDataBase.getU_SEQUENCEInfo(null, "",
                        "", "", triStateBool.yes, triStateBool.No,
                        stDOCBASETYPE, false, "AND");

            if (dtSequenceInfo.Rows.Count > 0)
            {
                stNextSequenceNo = "<" +
                    dtSequenceInfo.Rows[0]["CURRENTNEXT"].ToString() + ">";
            }

            return stNextSequenceNo;
        }

        private void calculateLineTotal()
        {
            ctlNumberTextBox converter = new ctlNumberTextBox();
            converter.Amount =
                this.getDatafromDataBase.roundOff(
                    decimal.Parse(this.ntbDetailTrxUnitPrice.Amount) * 
                    decimal.Parse(this.ntbDetailTrxQuantity.Amount), 2)
                    .ToString();
            this.txtDetailTrxLineTotal.Text = converter.Value;
        }

        private void hidColumnsInDetailGriedView()
        {
            this.dtgTransactionDetail.Columns["M_SHOP_ID"].Visible = false;
            this.dtgTransactionDetail.Columns["AD_ORG_ID"].Visible = false;
            this.dtgTransactionDetail.Columns["M_PRODUCT_ID"].Visible = false;
            this.dtgTransactionDetail.Columns["M_UOM_ID"].Visible = false;
            this.dtgTransactionDetail.Columns["DESCRIPTION"].Visible = false;
            this.dtgTransactionDetail.Columns["T_TRANSACTION_ID"].Visible = false;
            this.dtgTransactionDetail.Columns["T_TRXDETAIL_ID"].Visible = false;
            this.dtgTransactionDetail.Columns["M_WAREHOUSE_ID"].Visible = false;
            this.dtgTransactionDetail.Columns["DISCOUNT RATE"].Visible = false;
            this.dtgTransactionDetail.Columns["DISCOUNT AMT"].Visible = false;
            this.dtgTransactionDetail.Columns["UNITCOST"].Visible = false;
            this.dtgTransactionDetail.Columns["MARGIN"].Visible = false;             
        }

        private void hidColumnsInMainGridView()
        {
            this.dtgTransactionGridView.Columns["M_SHOP_ID"].Visible = false;
            this.dtgTransactionGridView.Columns["AD_ORG_ID"].Visible = false;
            this.dtgTransactionGridView.Columns["T_TRANSACTION_ID"].Visible = false;
            this.dtgTransactionGridView.Columns["M_BPARTNER_ID"].Visible = false;
            this.dtgTransactionGridView.Columns["DESCRIPTION"].Visible = false;
            this.dtgTransactionGridView.Columns["ISSALESTRX"].Visible = false;
        }
        


        public void frmTransaction_Load(object sender, EventArgs e)
        {
            this.setUpOrganisations();

            if (generalResultInformation.currentTrx == transactionType.InventoryOut)
            {
                this.lblDetailTrxQuantity.Text = "Qty Sold";
                this.dtExistingActiveBpartnerInformation =
                    this.getDatafromDataBase.getM_BPARTNERInfo(null, "",
                            "", "", triStateBool.yes, triStateBool.ignor,
                            triStateBool.yes, false, "AND");
                this.cmdDetailTrxNewProduct.Visible = false;
                this.cmdNewBpartner.Visible = true;

                this.dtCrrUsrAccActiveWarehouse =
                    this.getDataAccordingToRule.
                            getCurrentUserAccessableWarehouse
                                (triStateBool.ignor, triStateBool.ignor,
                                 triStateBool.yes, triStateBool.ignor,
                                 triStateBool.ignor, triStateBool.ignor, 
                                 triStateBool.ignor,triStateBool.yes, "AND");

            }
            else if (generalResultInformation.currentTrx == transactionType.InventoryIn)
            {
                this.lblDetailTrxQuantity.Text = "Qty Bought";
                this.dtExistingActiveBpartnerInformation =
                   this.getDatafromDataBase.getM_BPARTNERInfo(null, "",
                           "", "", triStateBool.yes, triStateBool.yes,
                           triStateBool.ignor, false, "AND");
                this.cmdDetailTrxNewProduct.Visible = true;
                this.cmdNewBpartner.Visible = false;

                this.dtCrrUsrAccActiveWarehouse =
                    this.getDataAccordingToRule.
                            getCurrentUserAccessableWarehouse
                                (triStateBool.ignor, triStateBool.ignor,
                                 triStateBool.ignor, triStateBool.yes,
                                 triStateBool.ignor, triStateBool.ignor, triStateBool.ignor,
                                 triStateBool.yes, "AND");
            }

            this.dtExistingActiveBpartnerInformation.Columns["TIN"].
                SetOrdinal(this.dtExistingActiveBpartnerInformation.Columns.IndexOf("NAME") + 1);

            if (generalResultInformation.currentFormIsReadOnly)
            {
                this.tlsDelete.Visible = false;
                this.tlsNew.Visible = false;
                this.tlsSave.Visible = false;
                this.cmdNewBpartner.Visible = false;
                this.cmdDetailTrxAddLine.Visible = false;
                this.cmdDetailTrxNewProduct.Visible = false;
            }

            this.fillDispatchStoreList();

            this.dtExistingActiveProductInformation =
                this.getDatafromDataBase.getM_PRODUCTInfo(null, "", "",
                        "", "", "", "", "", "", "",
                                triStateBool.yes, true, "AND",
                                generalResultInformation.dbBulkDataRetrivalSize);

            

            this.ddgTrxBpartner.DataSource = 
                this.dtExistingActiveBpartnerInformation.Copy();
            this.ddgDetailProduct.DataSource = 
                this.dtExistingActiveProductInformation;


            this.cancelButtonStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.cancelButtonStyle.BackColor = Color.FromKnownColor(KnownColor.ControlDark);
            this.cancelButtonStyle.ForeColor = Color.FromKnownColor(KnownColor.Desktop);
            this.cancelButtonStyle.SelectionForeColor = Color.FromKnownColor(KnownColor.DarkBlue);
            this.cancelButtonStyle.WrapMode = DataGridViewTriState.False;
            this.cancelButtonStyle.Font =
                new System.Drawing.Font("Microsoft Sans Serif", 8.25F,
                    System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.dtTentativeTransactionDetail.Columns.Add("M_SHOP_ID");
            this.dtTentativeTransactionDetail.Columns.Add("AD_ORG_ID");
            this.dtTentativeTransactionDetail.Columns.Add("M_PRODUCT_ID");
            this.dtTentativeTransactionDetail.Columns.Add("REMOVE");
            this.dtTentativeTransactionDetail.Columns.Add("LINE",typeof(Int16));
            this.dtTentativeTransactionDetail.Columns.Add("NAME");
            this.dtTentativeTransactionDetail.Columns.Add(this.lblDetailTrxQuantity.Text);
            this.dtTentativeTransactionDetail.Columns.Add("UNIT");
            this.dtTentativeTransactionDetail.Columns.Add("STORE");
            this.dtTentativeTransactionDetail.Columns.Add("M_UOM_ID");
            this.dtTentativeTransactionDetail.Columns.Add("PRICE");
            this.dtTentativeTransactionDetail.Columns.Add("DISCOUNT AMT");
            this.dtTentativeTransactionDetail.Columns.Add("DISCOUNT RATE");
            this.dtTentativeTransactionDetail.Columns.Add("LINE AMT");
            this.dtTentativeTransactionDetail.Columns.Add("TAX AMT");
            this.dtTentativeTransactionDetail.Columns.Add("DESCRIPTION");
            this.dtTentativeTransactionDetail.Columns.Add("T_TRANSACTION_ID");
            this.dtTentativeTransactionDetail.Columns.Add("T_TRXDETAIL_ID");
            this.dtTentativeTransactionDetail.Columns.Add("M_WAREHOUSE_ID");

            this.dtTentativeTransactionDetail.Columns.Add("UNITCOST");
            this.dtTentativeTransactionDetail.Columns.Add("MARGIN");

            this.dtTentativeTransactionDetail.Columns["REMOVE"].SetOrdinal(1);

            this.dtgTransactionDetail.DataSource = this.dtTentativeTransactionDetail;

            this.dtgTransactionDetail.Columns["LINE"].HeaderText = "SN";

            this.dtgTransactionDetail.Columns["REMOVE"].HeaderText = "";
            this.dtgTransactionDetail.Columns["REMOVE"].DefaultCellStyle = this.cancelButtonStyle;



            this.dtExistingTransactionInformation.Columns.Add("M_SHOP_ID");
            this.dtExistingTransactionInformation.Columns.Add("AD_ORG_ID");
            this.dtExistingTransactionInformation.Columns.Add("T_TRANSACTION_ID");
            this.dtExistingTransactionInformation.Columns.Add("DOCUMENTNO");
            this.dtExistingTransactionInformation.Columns.Add("DESCRIPTION");
            this.dtExistingTransactionInformation.Columns.Add("TRXDATE");
            this.dtExistingTransactionInformation.Columns.Add("M_BPARTNER_ID");
            this.dtExistingTransactionInformation.Columns.Add("BIZ PARTNER");
            this.dtExistingTransactionInformation.Columns.Add("ISSALESTRX");
            this.dtExistingTransactionInformation.Columns.Add("SUBTRXAMOUNT");
            this.dtExistingTransactionInformation.Columns.Add("GRANDTRXAMOUNT");
            this.dtExistingTransactionInformation.Columns.Add("TRXTAXAMOUNT");
            this.dtExistingTransactionInformation.Columns.Add("PROCESSED");
            this.dtExistingTransactionInformation.Columns.Add("DOCSTATUS");

            this.dtgTransactionGridView.DataSource = this.dtExistingTransactionInformation;
            
            this.dtgTransactionGridView.Columns["TRXDATE"].HeaderText = "DATE";
            this.dtgTransactionGridView.Columns["SUBTRXAMOUNT"].HeaderText = "SUB TOTAL";
            this.dtgTransactionGridView.Columns["GRANDTRXAMOUNT"].HeaderText = "GRAND TOTAL";
            this.dtgTransactionGridView.Columns["TRXTAXAMOUNT"].HeaderText = "TAX TOTAL";
            

            this.tlsNew_Click(sender, e);

            this.hidColumnsInMainGridView();
            this.hidColumnsInDetailGriedView();
            
        }


        private void tlsNew_Click(object sender, EventArgs e)
        {
            this.blcurrentTrxProcessed = false;
            this.enableDisableFormElement();
            if (generalResultInformation.currentTrx == transactionType.InventoryOut)
            {
                this.lblTrxBpartner.Text = "Customer";
                this.lblDetailTrxQuantity.Text = "Qty Sold";
                this.lblDetailTrxWarehouse.Text = "Despatch From";
            }
            else if (generalResultInformation.currentTrx == transactionType.InventoryIn)
            {
                this.lblTrxBpartner.Text = "Vendor";
                this.lblDetailTrxQuantity.Text = "Qty Bought";
                this.lblDetailTrxWarehouse.Text = "Recevied To";
            }
                        
            this.intTransactionID = 0;
            this.intDetailTrxPrdPreviousUnitIndex = -1;

            this.txtTrxDocumentNo.Text = this.getNextDocumentNumber();
            this.txtTrxDescription.Text = "";
            this.dtpTrxDate.Value = DateTime.Today;
            if (this.dtExistingActiveBpartnerInformation.Rows.Count > 0)
            {
                this.ddgTrxBpartner.SelectedItem =
                    this.dtExistingActiveBpartnerInformation.Rows[0]["NAME"].ToString();
                this.ddgTrxBpartner.SelectedRowKey =
                    this.dtExistingActiveBpartnerInformation.Rows[0]["M_BPARTNER_ID"].ToString();
                this.intBpartnerID =
                    int.Parse(this.ddgTrxBpartner.SelectedRowKey.ToString());
            }

            this.ddgDetailProduct.SelectedItem = "";
            this.ddgDetailProduct.SelectedRow.Clear();
            this.ddgDetailProduct.SelectedRowKey = null;
            this.ddgDetailProduct_selectedItemChanged(sender, e);

            this.ntbDetailTrxQuantity.Amount = "0";
            this.ntbDetailTrxUnitPrice.Amount = "0";
            this.ntbDetailTrxTax.Amount = "15";
            this.cmbDetailTrxOtherUOM.Items.Clear();
            this.txtDetailTrxDescription.Text = "";

            this.txtDetailTrxLineTotal.Text = "0.00";
            this.lblTransactionSubTotal.Text = "0.00";
            this.lblTransactionTax.Text = "0.00";
            this.lblTransactionGrandTotal.Text = "0.00";            

            this.dtNewDetailTransactionInformation.Clear();
            this.dtNewTransactionInformation.Clear();

            this.dtTentativeTransactionDetail.Rows.Clear();

            this.cmdDetailTrxAddLine.Enabled = false;

            this.lblTrxDocumentNo.ForeColor = clNormalLableColor;
            this.lblTrxBpartner.ForeColor = clNormalLableColor;
            this.dtgTransactionDetail.BackgroundColor = 
                this.dtgTransactionGridView.BackgroundColor;
            this.lblTrxDate.ForeColor = clNormalLableColor;
        }
        
        private void tlsSave_Click(object sender, EventArgs e)
        {            
            if (this.checkForCompleteNewRecord())
            {
                MessageBox.Show("Please complete the missing form element before proceeding.",
                    "SRP SAVE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result =
                MessageBox.Show("Would you Like to Complete the Transaction", 
                                "SRP PROCESS", MessageBoxButtons.YesNoCancel,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            if (result == DialogResult.Cancel)
                return;

            bool recordSaved = false;

            if (result == DialogResult.Yes)
                recordSaved = this.saveRecord(true);
            else
                recordSaved = this.saveRecord(false);

            if (recordSaved)
            {
                MessageBox.Show("Process has Completed Successfully.",
                    "SRP SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);                           
            }
            this.tlsNew_Click(sender, e);
        }

        private void tlsReverse_Click(object sender, EventArgs e)
        {
            if (this.intTransactionID == 0)
                return;
                      
            DataTable dtExistingTrxInfo =
                this.getDatafromDataBase.getT_TRANSACTIONInfo(null, "",
                        this.intTransactionID.ToString(), "", "", new DateTime(),
                        false, triStateBool.ignor, triStateBool.ignor,
                        triStateBool.yes, transactionStatus.Complete, false, "AND");
            if (dtExistingTrxInfo.Rows.Count != 1)
                return;

            if (dtExistingTrxInfo.Rows[0]["DOCSTATUS"].ToString() == "RE" ||
                dtExistingTrxInfo.Rows[0]["DOCSTATUS"].ToString() == "DR")
                return;


            if (MessageBox.Show("Are you sure you want to REVERESE the effect of this Transacation.\n" +
                    "This will Alter the stock quantity and possible cost of Respective Items",
                    "SRP Warning", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                == DialogResult.No)
                return;            

            DataTable dtExistingTrxDetailInfo =
                this.getDatafromDataBase.getT_TRXDETAILInfo(null, "",
                    "", this.intTransactionID.ToString(), "", new DateTime(),
                    false, triStateBool.ignor, "",
                    triStateBool.ignor, false, "AND");

            DataTable dtUpdatedProducts =
                this.getDatafromDataBase.getQ_COSTInfo(null, "", "", 
                    0,0,0,0, 
                     triStateBool.ignor, true, "",generalResultInformation.dbBulkDataRetrivalSize);

            for (int columnCounter = dtUpdatedProducts.Columns.Count - 1;
                columnCounter >= 0; columnCounter--)
            {
                if (dtUpdatedProducts.Columns[columnCounter].ColumnName != "M_PRODUCT_ID" &&
                    dtUpdatedProducts.Columns[columnCounter].ColumnName != "ACCUMULATEDQTY" &&
                    dtUpdatedProducts.Columns[columnCounter].ColumnName != "CURRENTCOST" &&
                    dtUpdatedProducts.Columns[columnCounter].ColumnName != "ACCUMULATEDCOST" &&
                    dtUpdatedProducts.Columns[columnCounter].ColumnName != "CURRENTQTY")
                    dtUpdatedProducts.Columns.RemoveAt(columnCounter);
            }


            DataTable dtExistingPrdInfo = new DataTable();
            string stM_PRODUCT_ID = "";

            decimal dcCrrQty = 0;
            decimal dcCrrCost = 0;
            decimal dcTrxQty = 0;
            decimal dcTrxCost = 0;
            decimal dcCalculatedQty = 0;
            decimal dcCalculatedCost = 0;

            if (generalResultInformation.currentTrx == transactionType.InventoryOut)
            {
                dtUpdatedProducts.Columns.Remove("ACCUMULATEDQTY");
                dtUpdatedProducts.Columns.Remove("CURRENTCOST");
                dtUpdatedProducts.Columns.Remove("ACCUMULATEDCOST");
                for (int rowCounter = 0;
                      rowCounter <= dtExistingTrxDetailInfo.Rows.Count - 1; rowCounter++)
                {
                    stM_PRODUCT_ID = 
                        dtExistingTrxDetailInfo.
                                Rows[rowCounter]["M_PRODUCT_ID"].ToString();

                    if (stM_PRODUCT_ID == "0" ||
                        stM_PRODUCT_ID == "")
                    {
                        goto finalLine;
                    }

                    dtExistingPrdInfo =
                        this.getDatafromDataBase.getQ_COSTInfo(null, "",
                            stM_PRODUCT_ID, 0, 0, 0, 0, 
                            triStateBool.ignor, false, "AND", 
                            generalResultInformation.dbBulkDataRetrivalSize);

                    if (dtExistingPrdInfo.Rows.Count != 1)
                    {
                        goto finalLine;
                    }

                    dcCrrQty = 
                        decimal.Parse(dtExistingPrdInfo.Rows[0]["CURRENTQTY"].ToString());
                    dcTrxQty = 
                        decimal.Parse(dtExistingTrxDetailInfo.Rows[rowCounter]["TRXQUANTITY"].ToString());

                    dcCalculatedQty = dcCrrQty + dcTrxQty;

                    DataRow drUpdatedProduct = dtUpdatedProducts.NewRow();
                    
                    drUpdatedProduct["M_PRODUCT_ID"] =
                        dtExistingPrdInfo.Rows[0]["M_PRODUCT_ID"].ToString();
                    drUpdatedProduct["CURRENTQTY"] = 
                        dcCalculatedQty;

                    dtUpdatedProducts.Rows.Add(drUpdatedProduct);

                    this.getDataAccordingToRule.adjustStock(
                        dtExistingTrxDetailInfo.Rows[rowCounter]["M_PRODUCT_ID"].ToString(),
                        dtExistingTrxDetailInfo.Rows[rowCounter]["M_WAREHOUSE_ID"].ToString(),                            
                        decimal.Parse(
                                        dtExistingTrxDetailInfo.
                                                    Rows[rowCounter]
                                                        ["TRXQUANTITY"].ToString()
                                      ));
                }
            }
            else if (generalResultInformation.currentTrx == transactionType.InventoryIn)
            {
                for (int rowCounter = 0;
                      rowCounter <= dtExistingTrxDetailInfo.Rows.Count - 1; rowCounter++)
                {
                    stM_PRODUCT_ID = dtExistingTrxDetailInfo.Rows[rowCounter]["M_PRODUCT_ID"].ToString();

                    if (stM_PRODUCT_ID == "0" ||
                        stM_PRODUCT_ID == "")
                    {
                        goto finalLine;
                    }

                    dtExistingPrdInfo =
                        this.getDatafromDataBase.getQ_COSTInfo(null, "", 
                            stM_PRODUCT_ID,
                            0, 0, 0, 0, triStateBool.ignor, false,
                            "AND", generalResultInformation.dbBulkDataRetrivalSize);


                    if (dtExistingPrdInfo.Rows.Count != 1)
                    {
                        goto finalLine;
                    }

                    dcCrrQty = 
                        decimal.Parse(dtExistingPrdInfo.Rows[0]["CURRENTQTY"].ToString());
                    dcTrxQty = 
                        decimal.Parse(dtExistingTrxDetailInfo.Rows[rowCounter]["TRXQUANTITY"].ToString());
                    dcCrrCost=
                        decimal.Parse(dtExistingPrdInfo.Rows[0]["CURRENTCOST"].ToString());
                    dcTrxCost=
                        decimal.Parse(dtExistingTrxDetailInfo.Rows[rowCounter]["UNITPRICE"].ToString());

                    dcCalculatedQty = dcCrrQty - dcTrxQty;

                    if (dcCalculatedQty != 0)
                    {
                        dcCalculatedCost =
                            ((dcCrrCost * (dcTrxQty + dcCalculatedQty)) - (dcTrxCost * dcTrxQty)) /
                                dcCalculatedQty;
                    }
                    else
                    {
                        dcCalculatedCost =
                            decimal.Parse(dtExistingPrdInfo.
                                        Rows[rowCounter]["CURRENTCOST"].ToString());
                    }

                    DataRow drUpdatedProduct = dtUpdatedProducts.NewRow();
                    
                    drUpdatedProduct["M_PRODUCT_ID"] =
                        dtExistingPrdInfo.Rows[0]["M_PRODUCT_ID"].ToString();
                    drUpdatedProduct["CURRENTQTY"] = dcCalculatedQty.ToString();
                    drUpdatedProduct["ACCUMULATEDQTY"] =
                        (decimal.Parse(dtExistingPrdInfo.Rows[0]["ACCUMULATEDQTY"].ToString()) -
                                dcTrxQty).ToString();
                    drUpdatedProduct["CURRENTCOST"] = dcCalculatedCost;
                    drUpdatedProduct["ACCUMULATEDCOST"] =
                        (decimal.Parse(dtExistingPrdInfo.Rows[0]["ACCUMULATEDCOST"].ToString()) -
                                (dcTrxCost*dcTrxQty)).ToString();

                    dtUpdatedProducts.Rows.Add(drUpdatedProduct);

                    this.getDataAccordingToRule.adjustStock(
                        dtExistingTrxDetailInfo.Rows[rowCounter]["M_PRODUCT_ID"].ToString(),
                        dtExistingTrxDetailInfo.Rows[rowCounter]["M_WAREHOUSE_ID"].ToString(),
                        -1 * decimal.Parse(
                                            dtExistingTrxDetailInfo.
                                                    Rows[rowCounter]
                                                        ["TRXQUANTITY"].ToString()
                                      ));
                }
            }
            dtExistingTrxInfo.Rows[0]["DOCSTATUS"] = "RE";
     finalLine:
            if (dtUpdatedProducts.Rows.Count > 0)
            {
                this.getDatafromDataBase.changeDataBaseTableData(dtUpdatedProducts, "Q_COST", "UPDATE");
                this.getDatafromDataBase.changeDataBaseTableData(dtExistingTrxInfo, "T_TRANSACTION", "UPDATE");
                
                if (this.dtgTransactionGridView.SelectedRows.Count > 0)
                {
                    this.dtExistingTransactionInformation.
                        Rows[this.dtgTransactionGridView.SelectedRows[0].Index]["DOCSTATUS"] = "REVERSED";
                }

                bool saveTrxSummary = this.createTransactionSummaryRecord();

                if (!saveTrxSummary)
                {                    
                    return;
                }
                
                MessageBox.Show("Process has Completed Successfully.",
                    "SRP REVERSE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("There Seems A problem Processing Your Request Please Try Again Later.",
                    "SRP Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);                
            }            
        }

        private void tlsDelete_Click(object sender, EventArgs e)
        {
            if (this.intTransactionID == 0)
                return;

            DataTable dtExistingTrxInfo =
                this.getDatafromDataBase.getT_TRANSACTIONInfo(null, "",
                        this.intTransactionID.ToString(), "", "", new DateTime(),
                        false, triStateBool.ignor, triStateBool.ignor,
                        triStateBool.No, transactionStatus.Draft, false, "AND");
            if (dtExistingTrxInfo.Rows.Count != 1)
                return;

            if (MessageBox.Show("Are you sure you want to DELETE this Transacation.",
                "SRP Warning", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                == DialogResult.No)
                return;

            

            DataTable dtExistingTrxDetailInfo =
                this.getDatafromDataBase.getT_TRXDETAILInfo(null, "",
                    "", this.intTransactionID.ToString(), "", new DateTime(),
                    false, triStateBool.ignor, "",
                    triStateBool.ignor, false, "AND");

            this.getDatafromDataBase.changeDataBaseTableData(dtExistingTrxDetailInfo, "T_TRXDETAIL", "DELETE");
            this.getDatafromDataBase.changeDataBaseTableData(dtExistingTrxInfo, "T_TRANSACTION", "DELETE");

            MessageBox.Show("Process has Completed Successfully.",
                    "SRP DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (this.dtExistingTransactionInformation.Rows.Count > 0)
            {
                this.dtExistingTransactionInformation.Rows.RemoveAt(this.dtgTransactionGridView.SelectedRows[0].Index);
                this.dtExistingDetailTransactionInformation.Clear();
                if (this.dtExistingTransactionInformation.Rows.Count > 0)
                {
                    int intCrrSelectedRow =
                        this.dtgTransactionGridView.SelectedRows[0].Index;
                    if (intCrrSelectedRow < 0)
                        intCrrSelectedRow = 0;
                    this.dtgTransactionGridView.
                        Rows[intCrrSelectedRow - 1].Selected = true;
                    this.dtgTransactionGridView_CellClick(sender, new DataGridViewCellEventArgs(0, 0));
                }
            }
            else
            {
                this.tlsNew_Click(sender, e);
            }
        }
        
        private void tlsSearch_Click(object sender, EventArgs e)
        {
            this.dtExistingTransactionInformation.Rows.Clear();

            this.tlsNew_Click(sender, e);

            
            frmSearchTransaction frmSearchTrx = new frmSearchTransaction();            
            generalResultInformation.searchResult.Clear();

            Form newTrxSearchFrmHolder = new Form();
            newTrxSearchFrmHolder.Controls.Add(frmSearchTrx);
            newTrxSearchFrmHolder.AutoScroll = true;
            newTrxSearchFrmHolder.AutoSize = true;
            newTrxSearchFrmHolder.AutoSizeMode = AutoSizeMode.GrowOnly;
            frmSearchTrx.Dock = DockStyle.Fill;
            newTrxSearchFrmHolder.Text = "Inventory In/Outs";
            newTrxSearchFrmHolder.Load +=
                new EventHandler(frmSearchTrx.frmSearchTransaction_Load);
            newTrxSearchFrmHolder.ShowDialog();

            
            DataTable resultTable = generalResultInformation.searchResult.Copy();
            for (int rowCounter = 0; rowCounter <= resultTable.Rows.Count - 1; rowCounter++)
            {
                DataRow drNewExistingTrxRow =
                   this.dtExistingTransactionInformation.NewRow();
                drNewExistingTrxRow["M_SHOP_ID"] =
                    resultTable.Rows[rowCounter]["M_SHOP_ID"].ToString();
                drNewExistingTrxRow["AD_ORG_ID"] =
                    resultTable.Rows[rowCounter]["AD_ORG_ID"].ToString();
                drNewExistingTrxRow["T_TRANSACTION_ID"] =
                    resultTable.Rows[rowCounter]["T_TRANSACTION_ID"].ToString();
                drNewExistingTrxRow["DOCUMENTNO"] =
                    resultTable.Rows[rowCounter]["DOCUMENTNO"].ToString();
                drNewExistingTrxRow["TRXDATE"] =
                   resultTable.Rows[rowCounter]["TRXDATE"].ToString();
                drNewExistingTrxRow["DESCRIPTION"] =
                    resultTable.Rows[rowCounter]["DESCRIPTION"].ToString();
                drNewExistingTrxRow["M_BPARTNER_ID"] =
                    resultTable.Rows[rowCounter]["M_BPARTNER_ID"].ToString();
                drNewExistingTrxRow["BIZ PARTNER"] =
                    this.getDatafromDataBase.getM_BPARTNERInfo(null, "",
                        resultTable.Rows[rowCounter]["M_BPARTNER_ID"].ToString(),
                        "", triStateBool.ignor, triStateBool.ignor, 
                        triStateBool.ignor, false, "AND")
                            .Rows[0]["NAME"].ToString();

                drNewExistingTrxRow["SUBTRXAMOUNT"] =
                    resultTable.Rows[rowCounter]["SUBTRXAMOUNT"].ToString();
                drNewExistingTrxRow["TRXTAXAMOUNT"] =
                    resultTable.Rows[rowCounter]["TRXTAXAMOUNT"].ToString();
                drNewExistingTrxRow["GRANDTRXAMOUNT"] =
                    resultTable.Rows[rowCounter]["GRANDTRXAMOUNT"].ToString();
                if (generalResultInformation.currentTrx == transactionType.InventoryOut)
                    drNewExistingTrxRow["ISSALESTRX"] = "Y";
                else if (generalResultInformation.currentTrx == transactionType.InventoryIn)
                    drNewExistingTrxRow["ISSALESTRX"] = "N";
                drNewExistingTrxRow["PROCESSED"] =
                    resultTable.Rows[rowCounter]["PROCESSED"].ToString();

                if (resultTable.Rows[rowCounter]["DOCSTATUS"].ToString() == "DR")
                    drNewExistingTrxRow["DOCSTATUS"] = "DRAFTED";
                else if (resultTable.Rows[rowCounter]["DOCSTATUS"].ToString() == "CO")
                    drNewExistingTrxRow["DOCSTATUS"] = "COMPLETED";
                else if (resultTable.Rows[rowCounter]["DOCSTATUS"].ToString() == "RE")
                    drNewExistingTrxRow["DOCSTATUS"] = "REVERSED";

                this.dtExistingTransactionInformation.Rows.Add(drNewExistingTrxRow); 
            }
            if (this.dtExistingTransactionInformation.Rows.Count > 0)
                this.dtgTransactionGridView_CellClick(sender, new DataGridViewCellEventArgs(0, 0));                
            
            if (this.dtgTransactionDetail.SelectedCells.Count > 0)
                this.dtgTransactionDetail.CurrentCell.Selected = false;
        }

        private void tlsToogleView_Click(object sender, EventArgs e)
        {
            if (this.tlsToogleView.Text == "Grid View")
            {
                this.tlsToogleView.Text = "Record View";
                this.hidColumnsInMainGridView();
                this.dtgTransactionGridView.Visible = true;
                this.dtgTransactionGridView.BringToFront();
                this.dtgTransactionGridView.Size = 
                    new Size(this.Size.Width-20, this.dtgTransactionGridView.Size.Height);
            }
            else
            {
                this.tlsToogleView.Text = "Grid View";
                this.dtgTransactionGridView.SendToBack();
                this.dtgTransactionGridView.Size = 
                    new Size(11, this.dtgTransactionGridView.Size.Height);
                this.dtgTransactionGridView.Visible = false;
            }
        }

        private void tlsPrint_Click(object sender, EventArgs e)
        {
            if (generalResultInformation.currentTrx == transactionType.InventoryIn)
                return;

            if (!System.IO.File.Exists("crptProformaInvoice.rpt") ||
                !System.IO.File.Exists("crptAttachmentInvoice.rpt"))
            {                
                MessageBox.Show("Unable To find Report Builder. \n Please Contact Your Administrator.",
                    "Printing", MessageBoxButtons.OK, MessageBoxIcon.Error);                                
                return;
            }
            
            frmPrintViewer newPrintJobView = new frmPrintViewer();

            string fileName = "";
            dtsPOSDocumentData dsNewTransaction = new dtsPOSDocumentData();

            dsNewTransaction.Tables["dtAttachmentSummary"].Clear();
            dsNewTransaction.Tables["dtSalesDetail"].Clear();

            DataRow drNewTransaction =
                dsNewTransaction.Tables["dtAttachmentSummary"].NewRow();


            if (this.dtgTransactionGridView.Rows
                    [this.dtgTransactionGridView.SelectedRows[0].Index].
                        Cells["PROCESSED"].Value.ToString().ToUpperInvariant() != "N")
            {
                fileName = "crptAttachmentInvoice.rpt";
                drNewTransaction["DocumentName"] = "Attachment Invoice";                
            }
            else if (this.dtgTransactionGridView.Rows
                    [this.dtgTransactionGridView.SelectedRows[0].Index].
                        Cells["PROCESSED"].Value.ToString().ToUpperInvariant() == "N")
            {
                fileName = "crptProformaInvoice.rpt";
                drNewTransaction["DocumentName"] = "Proforma Invoice";
            }
            else
            {
                MessageBox.Show("Unable To Determine Current Transaction. \n Please Contact Your Administrator.",
                    "Printing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            drNewTransaction["transactionID"] = this.intTransactionID;
            drNewTransaction["stationID"] = "0";
            drNewTransaction["nodeID"] = "0";            
            drNewTransaction["transactionPerson"] = "";
            drNewTransaction["DepartmentStore"] = "";
            drNewTransaction["DeliveryOrderNumber"] = "";
            drNewTransaction["FSNumber"] = "";
            drNewTransaction["ReferenceNumber"] = 
                this.txtTrxDocumentNo.Text;
            drNewTransaction["Date"] = 
                this.dtpTrxDate.Value.ToString();

            DataTable dtBpartnerInfo =
                this.getDatafromDataBase.getM_BPARTNERInfo(null, "", this.intBpartnerID.ToString(),
                    "", triStateBool.ignor, triStateBool.ignor, triStateBool.ignor, false, "AND");

            string stName = "";
            string stTIN = "";
            string stVATRegNo = "";

            string stSubLocalityID = "";
            
            string stLocalityID = "";
            
            string stHouseNumber = "";
            string stPhoneNumber = "";

            DataTable dtAddressInfo;

            if (this.getDatafromDataBase.checkIfTableContainesData(dtBpartnerInfo))
            {
                stName = dtBpartnerInfo.Rows[0]["NAME"].ToString();
                stTIN = dtBpartnerInfo.Rows[0]["TIN"].ToString();
                stVATRegNo = dtBpartnerInfo.Rows[0]["VATREGNO"].ToString();

                stSubLocalityID = dtBpartnerInfo.Rows[0]["C_SUBLOCALITY_ID"].ToString();
                stLocalityID = dtBpartnerInfo.Rows[0]["C_LOCALITY_ID"].ToString();

                stHouseNumber = dtBpartnerInfo.Rows[0]["ADDRESS4"].ToString();
                stPhoneNumber = dtBpartnerInfo.Rows[0]["PHONE"].ToString();
                if(stPhoneNumber == "")
                    stPhoneNumber = dtBpartnerInfo.Rows[0]["PHONE2"].ToString();                

                dtAddressInfo =
                    this.getDatafromDataBase.getC_SUBLOCALITYInfo(null, "",
                        stSubLocalityID, "", "", "",
                        triStateBool.ignor, triStateBool.ignor, false, "AND");

                if (!this.getDatafromDataBase.checkIfTableContainesData(dtAddressInfo))
                {
                    drNewTransaction["BuyersKebele"] =
                        dtBpartnerInfo.Rows[0]["LOCALITYNAME"].ToString();
                }
                else
                {
                    drNewTransaction["BuyersKebele"] = dtAddressInfo.Rows[0]["NAME"].ToString();
                }


                dtAddressInfo =
                    this.getDatafromDataBase.getC_LOCALITYInfo(null, "",
                        stLocalityID,
                        "", "", "", triStateBool.ignor, triStateBool.ignor, false, "AND");

                if (!this.getDatafromDataBase.checkIfTableContainesData(dtAddressInfo))
                {
                    drNewTransaction["BuyersZoneORSubCity"] =
                       dtBpartnerInfo.Rows[0]["CITYNAME"].ToString();
                }
                else
                {
                    drNewTransaction["BuyersZoneORSubCity"] =
                        dtAddressInfo.Rows[0]["NAME"].ToString();
                }
            }

            drNewTransaction["BuyersTradeName"] = stName;

            drNewTransaction["BuyersTIN"] = stTIN;
            drNewTransaction["BuyersVAT"] = stVATRegNo;


            drNewTransaction["BuyersHouseNumber"] = stHouseNumber;
            drNewTransaction["BuyersPhoneNumber"] = stPhoneNumber; 

            drNewTransaction["transactionTotal"] =
                decimal.Parse(this.lblTransactionSubTotal.Text);
            drNewTransaction["transactionVAT"] = 
                decimal.Parse(this.lblTransactionTax.Text);
            drNewTransaction["transactionGrandTotal"] = 
                decimal.Parse(this.lblTransactionGrandTotal.Text);
            drNewTransaction["transactionWithHolding"] = "0";
            drNewTransaction["transactionNetPay"] = "0";
            drNewTransaction["transactionAmountInWord"] = "";
            drNewTransaction["transactionPaymentMethod"] = "0";
            drNewTransaction["MRC"] = "";
            drNewTransaction["Note"] = 
                this.txtTrxDescription.Text;
            drNewTransaction["numberOfRePrint"] = " ";

            for (int trxDetailCounter = 0; 
                 trxDetailCounter <= 
                    this.dtTentativeTransactionDetail.Rows.Count - 1; 
                 trxDetailCounter++)
            {
                DataRow drNewTransactionDetail =
                    dsNewTransaction.Tables["dtSalesDetail"].NewRow();

                drNewTransactionDetail["transactionDetailId"] =
                    this.dtTentativeTransactionDetail.Rows[trxDetailCounter]["T_TRXDETAIL_ID"].ToString();
                drNewTransactionDetail["transactionDetailStation"] = "0";
                drNewTransactionDetail["transactionDetailNode"] = "0";
                drNewTransactionDetail["transactionID"] = 
                    this.intTransactionID.ToString();
                drNewTransactionDetail["item_id"] =
                    this.dtTentativeTransactionDetail.Rows[trxDetailCounter]["M_PRODUCT_ID"].ToString();
                drNewTransactionDetail["locatorFromId"] =
                    this.dtTentativeTransactionDetail.Rows[trxDetailCounter]["M_WAREHOUSE_ID"].ToString();
                drNewTransactionDetail["Sn."] = trxDetailCounter + 1;
                drNewTransactionDetail["Description"] =
                    this.dtTentativeTransactionDetail.Rows[trxDetailCounter]["NAME"].ToString();
                drNewTransactionDetail["Quantity"] =
                    decimal.Parse(this.dtTentativeTransactionDetail.Rows[trxDetailCounter]
                        [this.lblDetailTrxQuantity.Text].ToString());
                drNewTransactionDetail["UOM"] =
                    this.dtTentativeTransactionDetail.Rows[trxDetailCounter]["UNIT"].ToString();
                drNewTransactionDetail["UnitPrice"] =
                    decimal.Parse(this.dtTentativeTransactionDetail.Rows[trxDetailCounter]["PRICE"].ToString());
                drNewTransactionDetail["TotalAmount"] =
                    decimal.Parse(this.dtTentativeTransactionDetail.Rows[trxDetailCounter]["LINE AMT"].ToString());
                drNewTransactionDetail["Comment"] =
                    this.dtTentativeTransactionDetail.Rows[trxDetailCounter]["DESCRIPTION"].ToString();

                DataTable itemInfo =
                    this.getDatafromDataBase.getM_PRODUCTInfo(null, "",
                                this.dtTentativeTransactionDetail.Rows[trxDetailCounter]["M_PRODUCT_ID"].ToString(),
                                "", "", "", "", "", "", "", triStateBool.ignor, false, "AND", 30);
                if (this.getDatafromDataBase.checkIfTableContainesData(itemInfo))
                {
                    drNewTransactionDetail["CODE"] =
                        itemInfo.Rows[0]["CODE"].ToString();
                    drNewTransactionDetail["CODE2"] =
                        itemInfo.Rows[0]["CODE2"].ToString();
                    drNewTransactionDetail["BAR"] = "*" +
                        itemInfo.Rows[0]["UPC_EAN"].ToString() + "*";
                }

                dsNewTransaction.Tables["dtSalesDetail"].
                    Rows.Add(drNewTransactionDetail);            
            }

            dsNewTransaction.Tables["dtAttachmentSummary"].
                    Rows.Add(drNewTransaction);
            newPrintJobView.setUpThePreviewArea(fileName, dsNewTransaction);

            newPrintJobView.ShowDialog(this);            

        }                   



        private void ddgTrxBpartner_SelectedItemClicked(object sender, EventArgs e)
        {
            this.ddgTrxBpartner.DataSource =
                this.dtExistingActiveBpartnerInformation.Copy();
            this.ddgTrxBpartner.DataTablePrimaryKey =
                Convert.ToUInt16(this.dtExistingActiveBpartnerInformation.Columns.IndexOf("M_BPARTNER_ID"));
            this.ddgTrxBpartner.SelectedColomnIdex =
                this.dtExistingActiveBpartnerInformation.Columns.IndexOf("NAME");
            this.ddgTrxBpartner.HiddenColoumns = new int[]
                                {
                                    this.dtExistingActiveBpartnerInformation.Columns.IndexOf("M_SHOP_ID"),
                                    this.dtExistingActiveBpartnerInformation.Columns.IndexOf("AD_ORG_ID"),
                                    this.dtExistingActiveBpartnerInformation.Columns.IndexOf("CREATED"),
                                    this.dtExistingActiveBpartnerInformation.Columns.IndexOf("UPDATED"),
                                    this.dtExistingActiveBpartnerInformation.Columns.IndexOf("CREATEDBY"),
                                    this.dtExistingActiveBpartnerInformation.Columns.IndexOf("DESCRIPTION"),
                                    this.dtExistingActiveBpartnerInformation.Columns.IndexOf("UPDATEDBY")
                                };
        }

        private void ddgTrxBpartner_selectedItemChanged(object sender, EventArgs e)
        {
            if (this.ddgTrxBpartner.SelectedRowKey == null ||
                this.ddgTrxBpartner.SelectedRow.Rows.Count <= 0)
            {
                this.intBpartnerID = 0;
                this.ddgTrxBpartner.SelectedItem = "";
            }
            else
            {
                this.intBpartnerID =
                    int.Parse(this.ddgTrxBpartner.SelectedRowKey.ToString());                
            }
        }


        private void ddgDetailProduct_SelectedItemClicked(object sender, EventArgs e)
        {
            this.dtExistingActiveProductInformation =
                this.getDatafromDataBase.getM_PRODUCTInfo(null, "", "", "", "", "",
                        this.ddgDetailProduct.SelectedItem, "", "", "", 
                        triStateBool.yes, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);
            this.ddgDetailProduct.DataSource =
                this.dtExistingActiveProductInformation;
            this.ddgDetailProduct.DataTablePrimaryKey =
                Convert.ToUInt16(this.dtExistingActiveProductInformation.Columns.IndexOf("M_PRODUCT_ID"));
            this.ddgDetailProduct.SelectedColomnIdex =
                this.dtExistingActiveProductInformation.Columns.IndexOf("NAME");
            this.ddgDetailProduct.HiddenColoumns = new int[]
                                {
                                    this.dtExistingActiveProductInformation.Columns.IndexOf("M_SHOP_ID"),
                                    this.dtExistingActiveProductInformation.Columns.IndexOf("AD_ORG_ID"),
                                    this.dtExistingActiveProductInformation.Columns.IndexOf("CREATED"),
                                    this.dtExistingActiveProductInformation.Columns.IndexOf("UPDATED"),
                                    this.dtExistingActiveProductInformation.Columns.IndexOf("M_PRODUCTCATEGORY_ID"),
                                    this.dtExistingActiveProductInformation.Columns.IndexOf("M_UOM_ID"),
                                    this.dtExistingActiveProductInformation.Columns.IndexOf("CREATEDBY"),
                                    this.dtExistingActiveProductInformation.Columns.IndexOf("UPDATEDBY"),
                                    this.dtExistingActiveProductInformation.Columns.IndexOf("ISACTIVE"),
                                    this.dtExistingActiveProductInformation.Columns.IndexOf("DESCRIPTION"),
                                    this.dtExistingActiveProductInformation.Columns.IndexOf("PRODUCTTYPE"),
                                    this.dtExistingActiveProductInformation.Columns.IndexOf("IMAGEPATH"),
                                    this.dtExistingActiveProductInformation.Columns.IndexOf("PURCHASEPRICE")                                    
                                };
        }

        private void ddgDetailProduct_selectedItemChanged(object sender, EventArgs e)
        {
            
            if (this.ddgDetailProduct.SelectedRow != null &&                
                this.ddgDetailProduct.SelectedRow.Rows.Count > 0)
            {
                this.intProductID =
                    int.Parse(this.ddgDetailProduct.SelectedRowKey.ToString());                
                this.ntbDetailTrxQuantity.Enabled = true;
                if (generalResultInformation.currentTrx == transactionType.InventoryIn)
                    this.ntbDetailTrxUnitPrice.Amount =
                        ddgDetailProduct.SelectedRow.Rows[0]["PURCHASEPRICE"].ToString();
                else if (generalResultInformation.currentTrx == transactionType.InventoryOut)
                    this.ntbDetailTrxUnitPrice.Amount =
                        ddgDetailProduct.SelectedRow.Rows[0]["SELLINGPRICE"].ToString();                
            }
            else
            {
                this.intProductID = 0;

                this.ntbDetailTrxQuantity.Amount = "0";                
                this.ntbDetailTrxUnitPrice.Amount = "0.00";
                this.ddgDetailProduct.SelectedItem = "";
                this.ntbDetailTrxQuantity.Enabled = false;
                this.cmbDetailTrxOtherUOM.Items.Clear();
                this.dtDetailTrxItemAlternateUnit.Rows.Clear();                
            }

            this.displayCurrentQtyStockAmount();
            this.fillDetailTrxItemUOMComboBox();
        }


        private void ntbDetailTrxQuantity_Enter(object sender, EventArgs e)
        {
            this.cmdDetailTrxAddLine.Enabled = true;
        }

        private void ntbDetailTrxQuantity_Leave(object sender, EventArgs e)
        {
            if (decimal.Parse(this.ntbDetailTrxQuantity.Amount) != 0)
            {
                this.cmdDetailTrxAddLine.Enabled = true;
            }
            else
            {
                this.cmdDetailTrxAddLine.Enabled = false;
            }
            this.calculateLineTotal();                
        }

        private void ntbDetailTrxUnitPrice_Leave(object sender, EventArgs e)
        {
            this.calculateLineTotal();
        }


        private void cmbDetailTrxOtherUOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbDetailTrxOtherUOM.Items.Count <= 0)
                return;

            if (this.cmbDetailTrxOtherUOM.SelectedIndex ==
                this.intDetailTrxPrdPreviousUnitIndex)
                return;

            DataTable dtProductInfo =
                this.getDatafromDataBase.getM_PRODUCTInfo(null, "",
                    this.ddgDetailProduct.SelectedRowKey.ToString(), "", "", "", "", "", "", "",
                     triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);
            if (dtProductInfo.Rows.Count <= 0)
                return;

            string stSTDUnitId = dtProductInfo.Rows[0]["M_UOM_ID"].ToString();
            decimal dcMultiplier = 1;

            if (this.cmbDetailTrxOtherUOM.SelectedIndex != 0)
            {
                if (stSTDUnitId ==
                    this.dtDetailTrxItemAlternateUnit.
                        Rows[this.cmbDetailTrxOtherUOM.SelectedIndex - 1]["M_BASE_UOM_ID"].ToString())
                {
                    stSTDUnitId =
                        this.dtDetailTrxItemAlternateUnit.
                        Rows[this.cmbDetailTrxOtherUOM.SelectedIndex - 1]["M_DRIVED_UOM_ID"].ToString();
                }
                else
                {
                    stSTDUnitId =
                        this.dtDetailTrxItemAlternateUnit.
                        Rows[this.cmbDetailTrxOtherUOM.SelectedIndex - 1]["M_BASE_UOM_ID"].ToString();
                }
            }

            if (this.cmbDetailTrxOtherUOM.SelectedIndex != 0)
            {
                if (this.intDetailTrxPrdPreviousUnitIndex == 0)
                {
                    if (dtProductInfo.Rows[0]["M_UOM_ID"].ToString() ==
                        this.dtDetailTrxItemAlternateUnit.
                            Rows[this.cmbDetailTrxOtherUOM.SelectedIndex - 1]["M_BASE_UOM_ID"].ToString())
                    {
                        dcMultiplier *=
                            decimal.Parse(this.dtDetailTrxItemAlternateUnit.
                                            Rows[this.cmbDetailTrxOtherUOM.SelectedIndex - 1]
                                                        ["MULTIPLIER"].ToString());
                    }
                    else
                    {
                        dcMultiplier /=
                            decimal.Parse(this.dtDetailTrxItemAlternateUnit.
                                            Rows[this.cmbDetailTrxOtherUOM.SelectedIndex - 1]
                                                        ["MULTIPLIER"].ToString());
                    }
                }
                else
                {
                    if (dtProductInfo.Rows[0]["M_UOM_ID"].ToString() ==
                        this.dtDetailTrxItemAlternateUnit.
                            Rows[this.intDetailTrxPrdPreviousUnitIndex - 1]["M_BASE_UOM_ID"].ToString())
                    {
                        dcMultiplier /=
                            decimal.Parse(this.dtDetailTrxItemAlternateUnit.
                                            Rows[this.intDetailTrxPrdPreviousUnitIndex - 1]
                                                        ["MULTIPLIER"].ToString());
                    }
                    else
                    {
                        dcMultiplier *=
                            decimal.Parse(this.dtDetailTrxItemAlternateUnit.
                                            Rows[this.intDetailTrxPrdPreviousUnitIndex - 1]
                                                        ["MULTIPLIER"].ToString());
                    }

                    if (dtProductInfo.Rows[0]["M_UOM_ID"].ToString() ==
                        this.dtDetailTrxItemAlternateUnit.
                            Rows[this.cmbDetailTrxOtherUOM.SelectedIndex - 1]["M_BASE_UOM_ID"].ToString())
                    {
                        dcMultiplier *=
                            decimal.Parse(this.dtDetailTrxItemAlternateUnit.
                                            Rows[this.cmbDetailTrxOtherUOM.SelectedIndex - 1]
                                                        ["MULTIPLIER"].ToString());
                    }
                    else
                    {
                        dcMultiplier /=
                            decimal.Parse(this.dtDetailTrxItemAlternateUnit.
                                            Rows[this.cmbDetailTrxOtherUOM.SelectedIndex - 1]
                                                        ["MULTIPLIER"].ToString());
                    }
                }
            }
            else if (this.intDetailTrxPrdPreviousUnitIndex > 0)
            {
                if (dtProductInfo.Rows[0]["M_UOM_ID"].ToString() ==
                        this.dtDetailTrxItemAlternateUnit.
                            Rows[this.intDetailTrxPrdPreviousUnitIndex - 1]["M_BASE_UOM_ID"].ToString())
                {
                    dcMultiplier /=
                        decimal.Parse(this.dtDetailTrxItemAlternateUnit.
                                        Rows[this.intDetailTrxPrdPreviousUnitIndex - 1]
                                                    ["MULTIPLIER"].ToString());
                }
                else
                {
                    dcMultiplier *=
                        decimal.Parse(this.dtDetailTrxItemAlternateUnit.
                                        Rows[this.intDetailTrxPrdPreviousUnitIndex - 1]
                                                    ["MULTIPLIER"].ToString());
                }
            }

            DataTable dtUnitInfo =
                    this.getDatafromDataBase.getM_UOMInfo(null, "",
                        stSTDUnitId, "", "", triStateBool.ignor, false, "AND");
            this.ntbDetailTrxQuantity.StandardPrecision =
                int.Parse(dtUnitInfo.Rows[0]["STDPRECISION"].ToString());
                        
            this.ntbDetailTrxQuantity.Amount =
                (this.getDatafromDataBase.roundOff(
                            (decimal.Parse(this.ntbDetailTrxQuantity.Amount) * dcMultiplier),
                            uint.Parse(this.ntbDetailTrxQuantity.StandardPrecision.ToString()))).ToString();

            this.ntbDetailTrxUnitPrice.Amount =
                (this.getDatafromDataBase.roundOff(
                        (decimal.Parse(this.ntbDetailTrxUnitPrice.Amount) / dcMultiplier),
                         uint.Parse(this.ntbDetailTrxUnitPrice.StandardPrecision.ToString()))).ToString();


            this.intDetailTrxPrdPreviousUnitIndex =
                this.cmbDetailTrxOtherUOM.SelectedIndex;
        }

        private void cmbDetailTrxDispatchingStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbDetailTrxDispatchingStore.Items.Count <= 0)
            {
                this.intDispatchingStoreId = 0;                
            }
            else
            {
                this.intDispatchingStoreId =
                    int.Parse(this.dtCrrUsrAccActiveWarehouse.
                                Rows[this.cmbDetailTrxDispatchingStore.SelectedIndex]
                                    ["M_WAREHOUSE_ID"].ToString()
                              );                
            }
            this.displayCurrentQtyStockAmount();
        }
        

        private void cmdDetailTrxProductImage_Click(object sender, EventArgs e)
        {
            this.ddgDetailProduct.SelectedRow.Clear();
            generalResultInformation.selectedProductId = "";
            frmProductImage frmProductImageList = new frmProductImage();
            frmProductImageList.ShowDialog();
            frmProductImageList.Dispose();
            if (generalResultInformation.selectedProductId == "")
            {
                this.ddgDetailProduct.SelectedRowKey = null;
                this.ddgDetailProduct.SelectedItem = "";
                this.intProductID = 0;
                this.ntbDetailTrxQuantity.Amount = "0";
                this.ntbDetailTrxUnitPrice.Amount = "0.00";
                this.ddgDetailProduct.SelectedItem = "";
                this.ntbDetailTrxQuantity.Enabled = false;
            }
            else
            {
                DataTable dtProdcutInfo =
                    this.getDatafromDataBase.getM_PRODUCTInfo(null, "",
                                generalResultInformation.selectedProductId,
                                "", "", "", "", "", "", "",  
                                triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);
                
                this.ddgDetailProduct.SelectedItem = dtProdcutInfo.Rows[0]["NAME"].ToString();
                this.intProductID = int.Parse(dtProdcutInfo.Rows[0]["M_PRODUCT_ID"].ToString());
                this.ddgDetailProduct.SelectedRowKey = dtProdcutInfo.Rows[0]["M_PRODUCT_ID"];

                if(generalResultInformation.currentTrx == transactionType.InventoryIn)
                    this.ntbDetailTrxUnitPrice.Amount =
                        dtProdcutInfo.Rows[0]["PURCHASEPRICE"].ToString();
                else if (generalResultInformation.currentTrx == transactionType.InventoryOut)
                    this.ntbDetailTrxUnitPrice.Amount =
                        dtProdcutInfo.Rows[0]["SELLINGPRICE"].ToString();
                                
                this.ntbDetailTrxQuantity.Enabled = true; 
            }
                        
            this.displayCurrentQtyStockAmount();
            this.fillDetailTrxItemUOMComboBox();
        }
                
        private void cmdDetailTrxAddLine_Click(object sender, EventArgs e)
        {
            if (this.intProductID.ToString() == "0" ||
                this.intProductID.ToString() == "" ||
                this.ntbDetailTrxQuantity.Amount == "" ||
                this.ntbDetailTrxQuantity.Amount == "0" ||
                this.intDispatchingStoreId.ToString() == "0" ||
                this.intDispatchingStoreId.ToString() == "")
            {
                return;
            }
            this.cmbDetailTrxOtherUOM.SelectedIndex = 0;

            DataTable dtProductInfo =
                this.getDatafromDataBase.getV_PRDUCTCOSTInfo(null, "", this.intProductID.ToString(),
                                         "", "", "", "", "", "", "", "", 0, 0, 0, 0,
                                         triStateBool.ignor, false, "AND",
                                         generalResultInformation.dbBulkDataRetrivalSize);
          
            DataTable dtStockInfo =
                this.getDatafromDataBase.getQ_STOCKInfo(null, "", 
                        this.intProductID.ToString(), 
                        this.intDispatchingStoreId.ToString(), 
                        triStateBool.yes, false, "AND");

            bool blUnderStockQuantity = false;
            if (dtStockInfo.Rows.Count <= 0)
                blUnderStockQuantity = true;
            else if (decimal.Parse(dtStockInfo.Rows[0]["CURRENTQTY"].ToString()) <
                     decimal.Parse(this.ntbDetailTrxQuantity.Amount))
                blUnderStockQuantity = true;                

            if (this.intProductID == 0 ||
                !this.getDatafromDataBase.checkIfTableContainesData(dtProductInfo))
            {
                goto finalLine;
            }

            if (generalResultInformation.currentTrx == transactionType.InventoryOut)
            {
                if (blUnderStockQuantity)
                {
                    DataTable dtWarehouseInfo = 
                        this.getDatafromDataBase.getM_WarehouseInfo(null, "", 
                                this.intDispatchingStoreId.ToString(), "", triStateBool.yes, 
                                triStateBool.ignor, false, "AND");
                    if (!this.getDatafromDataBase.checkIfTableContainesData(dtWarehouseInfo))
                    {
                        MessageBox.Show("No sufficient stock Exist ", "SRP STOCK", MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1);
                        return;
                    }
                    else
                    {
                        if (MessageBox.Show("No sufficient stock. " +
                                "Processing Could Result In Negative Inventory Quanity." +
                                " \n Would You like to continue.", "SRP STOCK", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button2) == DialogResult.No)
                            return;
                    }
                }
            }
                
            if (this.cmdDetailTrxAddLine.Text.ToUpperInvariant() == "ADD")
            {
                DataRow drNewTentaiveTrxDetail = this.dtTentativeTransactionDetail.NewRow();
                
                drNewTentaiveTrxDetail["REMOVE"] = "remove";
                drNewTentaiveTrxDetail["M_PRODUCT_ID"] = this.intProductID.ToString();
                drNewTentaiveTrxDetail["LINE"] = (this.dtTentativeTransactionDetail.Rows.Count + 1).ToString();
                drNewTentaiveTrxDetail["NAME"] = this.ddgDetailProduct.SelectedItem;
                drNewTentaiveTrxDetail[this.lblDetailTrxQuantity.Text] = 
                    this.ntbDetailTrxQuantity.Amount.Replace(",","");
                drNewTentaiveTrxDetail["UNIT"] = 
                    this.cmbDetailTrxOtherUOM.SelectedItem.ToString();

                DataTable dtUOMInfo =
                       this.getDatafromDataBase.getM_PRODUCTInfo(null, "", this.intProductID.ToString(),
                            "", "", "", "", "", "", "", 
                                    triStateBool.yes, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);
                if (this.getDatafromDataBase.checkIfTableContainesData(dtUOMInfo))
                {
                    drNewTentaiveTrxDetail["M_UOM_ID"] =
                        dtUOMInfo.Rows[0]["M_UOM_ID"].ToString();
                }

                drNewTentaiveTrxDetail["M_WAREHOUSE_ID"] = 
                    this.intDispatchingStoreId.ToString();
                drNewTentaiveTrxDetail["STORE"] =
                    this.cmbDetailTrxDispatchingStore.SelectedItem.ToString();
                drNewTentaiveTrxDetail["PRICE"] = this.ntbDetailTrxUnitPrice.Value;

                ctlNumberTextBox converter = new ctlNumberTextBox();

                if (!this.ckDetailTrxLinePrctage.Checked)
                    drNewTentaiveTrxDetail["TAX AMT"] = this.ntbDetailTrxTax.Value;
                else
                {
                    converter.Amount = 
                        (
                            (decimal.Parse(this.ntbDetailTrxTax.Amount) / 100) *
                            (decimal.Parse(this.ntbDetailTrxUnitPrice.Amount) *
                            decimal.Parse(this.ntbDetailTrxQuantity.Amount))
                        ).ToString();

                    drNewTentaiveTrxDetail["TAX AMT"] = converter.Value;                        
                }
                
                converter.Amount=
                    (decimal.Parse(this.ntbDetailTrxUnitPrice.Amount) *
                    decimal.Parse(this.ntbDetailTrxQuantity.Amount)).ToString();
                drNewTentaiveTrxDetail["LINE AMT"] = converter.Value;
                
                drNewTentaiveTrxDetail["DESCRIPTION"] = this.txtDetailTrxDescription.Text;
                

                decimal price = 0;
                
                if(dtProductInfo.Rows.Count == 1)
                {                    
                    if (generalResultInformation.currentTrx == transactionType.InventoryOut)
                    {
                        if (decimal.Parse(dtProductInfo.Rows[0]["SELLINGPRICE"].ToString()) != 0)
                        {
                            price =
                                decimal.Parse(dtProductInfo.Rows[0]["SELLINGPRICE"].ToString());
                        }
                    }
                    else if (generalResultInformation.currentTrx == transactionType.InventoryIn)
                    {
                        if (decimal.Parse(dtProductInfo.Rows[0]["PURCHASEPRICE"].ToString()) != 0)
                        {
                            price =
                                decimal.Parse(dtProductInfo.Rows[0]["PURCHASEPRICE"].ToString());
                        }
                    }
                }

                if (price != 0)
                {
                    converter.Amount =
                                (price -
                                decimal.Parse(this.ntbDetailTrxUnitPrice.Amount)).ToString();

                    drNewTentaiveTrxDetail["DISCOUNT AMT"] = converter.Value;

                    converter.Amount =
                        (decimal.Parse(converter.Amount) /
                         decimal.Parse(this.ntbDetailTrxUnitPrice.Amount)).ToString();

                    drNewTentaiveTrxDetail["DISCOUNT RATE"] = converter.Value;                    
                }
                else
                {
                    drNewTentaiveTrxDetail["DISCOUNT AMT"] = "0.00";
                    drNewTentaiveTrxDetail["DISCOUNT RATE"] = "0";
                }

                decimal UnitCost =
                    decimal.Parse(dtProductInfo.Rows[0]["CURRENTCOST"].ToString());

                decimal margin = 0;

                if(UnitCost != 0)
                    margin = (price - UnitCost) / UnitCost;

                converter.Amount = UnitCost.ToString();
                drNewTentaiveTrxDetail["UNITCOST"] = converter.Value;

                converter.Amount = margin.ToString();
                drNewTentaiveTrxDetail["MARGIN"] = converter.Value;
                
                this.dtTentativeTransactionDetail.Rows.Add(drNewTentaiveTrxDetail);
            }
            else if (this.cmdDetailTrxAddLine.Text.ToUpperInvariant() == "MODIFY")
            {
                if (this.dtgTransactionDetail.SelectedRows.Count < 1)
                {
                    goto finalLine;                    
                }
                int crrntSlctRwIndx =
                    this.dtgTransactionDetail.SelectedRows[0].Index;

                this.dtTentativeTransactionDetail.Rows[crrntSlctRwIndx]["REMOVE"] = "remove";
                this.dtTentativeTransactionDetail.Rows[crrntSlctRwIndx]["M_PRODUCT_ID"] = 
                        this.intProductID.ToString();                
                this.dtTentativeTransactionDetail.Rows[crrntSlctRwIndx]["NAME"] = 
                        this.ddgDetailProduct.SelectedItem;
                this.dtTentativeTransactionDetail.Rows[crrntSlctRwIndx][this.lblDetailTrxQuantity.Text] =
                        this.ntbDetailTrxQuantity.Value;
                this.dtTentativeTransactionDetail.Rows[crrntSlctRwIndx]["UNIT"] = 
                    this.cmbDetailTrxOtherUOM.SelectedItem.ToString();

                DataTable dtUOMInfo =
                       this.getDatafromDataBase.getM_PRODUCTInfo(null, "", this.intProductID.ToString(),
                            "", "", "", "", "", "", "", 
                                    triStateBool.yes, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);
                if (this.getDatafromDataBase.checkIfTableContainesData(dtUOMInfo))
                {
                    this.dtTentativeTransactionDetail.Rows[crrntSlctRwIndx]["M_UOM_ID"] =
                        dtUOMInfo.Rows[0]["M_UOM_ID"].ToString();
                }

                this.dtTentativeTransactionDetail.Rows[crrntSlctRwIndx]["M_WAREHOUSE_ID"] =
                    this.intDispatchingStoreId.ToString();
                this.dtTentativeTransactionDetail.Rows[crrntSlctRwIndx]["STORE"] =
                    this.cmbDetailTrxDispatchingStore.SelectedItem.ToString();
                this.dtTentativeTransactionDetail.Rows[crrntSlctRwIndx]["PRICE"] =
                        this.ntbDetailTrxUnitPrice.Value;

                ctlNumberTextBox converter = new ctlNumberTextBox();

                if (!this.ckDetailTrxLinePrctage.Checked)
                    this.dtTentativeTransactionDetail.Rows[crrntSlctRwIndx]["TAX AMT"] =
                        this.ntbDetailTrxTax.Value;
                else
                {
                    converter.Amount = 
                        (
                          (decimal.Parse(this.ntbDetailTrxTax.Value) / 100) *
                           decimal.Parse(this.ntbDetailTrxUnitPrice.Amount) *
                           decimal.Parse(this.ntbDetailTrxQuantity.Amount)
                        ).ToString();

                    this.dtTentativeTransactionDetail.Rows[crrntSlctRwIndx]["TAX AMT"] = 
                        converter.Value;
                }

                
                converter.Amount =
                    (decimal.Parse(this.ntbDetailTrxUnitPrice.Amount) *
                    decimal.Parse(this.ntbDetailTrxQuantity.Amount)).ToString();

                this.dtTentativeTransactionDetail.Rows[crrntSlctRwIndx]["LINE AMT"] = converter.Value;
                
                decimal price = 0;
                if (dtProductInfo.Rows.Count == 1)
                {
                    if (generalResultInformation.currentTrx == transactionType.InventoryOut)
                    {
                        if (decimal.Parse(dtProductInfo.Rows[0]["SELLINGPRICE"].ToString()) != 0)
                        {
                            price =
                                decimal.Parse(dtProductInfo.Rows[0]["SELLINGPRICE"].ToString());
                        }
                    }
                    else if (generalResultInformation.currentTrx == transactionType.InventoryIn)
                    {
                        if (decimal.Parse(dtProductInfo.Rows[0]["PURCHASEPRICE"].ToString()) != 0)
                        {
                            price =
                                decimal.Parse(dtProductInfo.Rows[0]["PURCHASEPRICE"].ToString());
                        }
                    }
                }

                if (price != 0)
                {
                    converter.Amount =
                        (price -
                            decimal.Parse(this.ntbDetailTrxUnitPrice.Amount)).ToString();

                    this.dtTentativeTransactionDetail.Rows[crrntSlctRwIndx]["DISCOUNT AMT"] =
                        converter.Value;

                    converter.Amount =
                        (decimal.Parse(converter.Amount) /
                         decimal.Parse(this.ntbDetailTrxUnitPrice.Amount)).ToString();

                    this.dtTentativeTransactionDetail.Rows[crrntSlctRwIndx]["DISCOUNT RATE"] =
                        converter.Value;                    
                }
                else
                {
                    this.dtTentativeTransactionDetail.Rows[crrntSlctRwIndx]["DISCOUNT AMT"] = "0.00";
                    this.dtTentativeTransactionDetail.Rows[crrntSlctRwIndx]["DISCOUNT RATE"] = "0";
                }

                decimal UnitCost =
                    decimal.Parse(dtProductInfo.Rows[0]["CURRENTCOST"].ToString());

                decimal margin = 0;

                if (UnitCost != 0)
                    margin = (price - UnitCost) / UnitCost;

                converter.Amount = UnitCost.ToString();
                this.dtTentativeTransactionDetail.Rows[crrntSlctRwIndx]["UNITCOST"] = 
                    converter.Value;

                converter.Amount = margin.ToString();
                this.dtTentativeTransactionDetail.Rows[crrntSlctRwIndx]["MARGIN"] = 
                    converter.Value;

                this.dtTentativeTransactionDetail.Rows[crrntSlctRwIndx]["DESCRIPTION"] = 
                        this.txtDetailTrxDescription.Text;
            }
            finalLine:
            this.intDetailTrxPrdPreviousUnitIndex = -1;

            this.cmdDetailTrxAddLine.Text = "ADD";
            this.cmdDetailTrxAddLine.Enabled = false;

            this.ddgDetailProduct.SelectedRow.Clear();
            this.ddgDetailProduct_selectedItemChanged(sender, e);

            this.ntbDetailTrxQuantity.Amount = "0";
            this.ntbDetailTrxUnitPrice.Amount = "0";
            this.ntbDetailTrxTax.Amount = "0";
            this.txtDetailTrxLineTotal.Text = "0.00";
            this.cmbDetailTrxOtherUOM.Items.Clear();
            this.txtDetailTrxDescription.Text = "";

            this.ckDetailTrxLinePrctage.Checked = true;
            this.ntbDetailTrxTax.Amount = "15";

            this.updateTotalTrxAmountIndicators();

            this.dtgTransactionDetail.BackgroundColor =
                this.dtgTransactionGridView.BackgroundColor;

            if (this.dtgTransactionDetail.SelectedCells.Count > 0)
                this.dtgTransactionDetail.CurrentCell.Selected = false;
        }


        private void dtgTransactionDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {   
            if (this.dtgTransactionDetail.SelectedRows.Count < 1 ||
                this.blcurrentTrxProcessed)
            {
                if (this.dtgTransactionDetail.SelectedCells.Count > 0) 
                    this.dtgTransactionDetail.CurrentCell.Selected = false;
                return;
            }

            int currentSelectedRowIndex = 
                this.dtgTransactionDetail.SelectedRows[0].Index;
            if (this.dtgTransactionDetail.CurrentCell.OwningColumn.Index == 1 &&
                this.dtgTransactionDetail.CurrentCell.OwningColumn.Name == "REMOVE" &&
                this.dtgTransactionDetail.CurrentCell.Value.ToString() == "remove" &&
                this.dtgTransactionDetail.CurrentCell.OwningColumn.HeaderText == "")
            {
                string stTrxDetailID =
                    this.dtTentativeTransactionDetail.
                        Rows[currentSelectedRowIndex]["T_TRXDETAIL_ID"].ToString();
                                
                if (stTrxDetailID != "" &&
                    this.intTransactionID > 0)
                {
                    DataTable dtTrxDetailInfo =
                        this.getDatafromDataBase.getT_TRXDETAILInfo(null, "",
                                stTrxDetailID, this.intTransactionID.ToString(),
                                "", new DateTime(), false, triStateBool.ignor, "",
                                triStateBool.ignor, false, "AND");

                    if (this.getDatafromDataBase.
                            checkIfTableContainesData(dtTrxDetailInfo))
                    {
                        this.getDatafromDataBase.
                                changeDataBaseTableData(dtTrxDetailInfo, 
                                    "T_TRXDETAIL", "DELETE");
                    }
                }

                this.dtTentativeTransactionDetail.Rows.
                        RemoveAt(currentSelectedRowIndex);

                this.updateTotalTrxAmountIndicators();
                for (int detailRowCounter = 0; 
                    detailRowCounter <= this.dtTentativeTransactionDetail.Rows.Count - 1; detailRowCounter++)
                {
                    this.dtTentativeTransactionDetail.Rows[detailRowCounter]["LINE"] = detailRowCounter + 1;
                }
            }
            else
            {
                this.cmdDetailTrxAddLine.Text = "Modify";

                this.ckDetailTrxLinePrctage.Checked = false;
                
                this.intProductID =
                    int.Parse(this.dtTentativeTransactionDetail.Rows[currentSelectedRowIndex]
                                                                ["M_PRODUCT_ID"].ToString());                

                this.ddgDetailProduct.SelectedRowKey = 
                    this.dtTentativeTransactionDetail.Rows[currentSelectedRowIndex]
                                                        ["M_PRODUCT_ID"].ToString();
                this.ddgDetailProduct.SelectedItem =
                    this.dtTentativeTransactionDetail.Rows[currentSelectedRowIndex]
                                                        ["NAME"].ToString();
                this.ntbDetailTrxQuantity.Amount =
                    this.dtTentativeTransactionDetail.Rows[currentSelectedRowIndex]
                                                        [this.lblDetailTrxQuantity.Text].ToString();
                this.fillDetailTrxItemUOMComboBox();

                this.cmbDetailTrxDispatchingStore.Text =
                    this.dtTentativeTransactionDetail.Rows[currentSelectedRowIndex]
                                                        ["STORE"].ToString();
                this.intDispatchingStoreId =
                    int.Parse(this.dtTentativeTransactionDetail.
                                                    Rows[currentSelectedRowIndex]
                                                        ["M_WAREHOUSE_ID"].ToString());

                this.txtDetailTrxDescription.Text =
                    this.dtTentativeTransactionDetail.Rows[currentSelectedRowIndex]
                                                        ["DESCRIPTION"].ToString();
                this.ntbDetailTrxTax.Amount = "15";
                    
                this.ckDetailTrxLinePrctage.Checked = true;
                this.ntbDetailTrxUnitPrice.Amount =
                    this.dtTentativeTransactionDetail.Rows[currentSelectedRowIndex]
                                                        ["PRICE"].ToString();

                this.cmdDetailTrxAddLine.Enabled = true;
                this.ntbDetailTrxQuantity.Enabled = true;
                this.calculateLineTotal();
            }
        }
                
        private void dtgTransactionGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgTransactionGridView.SelectedRows.Count < 1)
            {
                return;
            }

            int currentSelectedRowIndex =
                this.dtgTransactionGridView.SelectedRows[0].Index;

            this.intTransactionID =
                int.Parse(this.dtgTransactionGridView.Rows[currentSelectedRowIndex].
                        Cells["T_TRANSACTION_ID"].Value.ToString());
                        
            this.stOrganisationID =
                this.dtgTransactionGridView.Rows[currentSelectedRowIndex].
                        Cells["AD_ORG_ID"].Value.ToString();

            for (int rowCounter = 0; 
                rowCounter <= this.dtAccessableOrgInformation.Rows.Count - 1; rowCounter++)
            {
                if (this.dtAccessableOrgInformation.Rows[rowCounter]["AD_ORG_ID"].ToString() ==
                    this.stOrganisationID)
                    this.cmbOrganisation.SelectedIndex = rowCounter;
            }

            if (this.dtAccessableOrgInformation.Rows.Count >= this.cmbOrganisation.SelectedIndex &&
                this.cmbOrganisation.SelectedIndex >= 0)
            {
                if (this.dtgTransactionGridView.Rows[currentSelectedRowIndex].
                            Cells["AD_ORG_ID"].Value.ToString() !=
                            this.dtAccessableOrgInformation.
                                Rows[this.cmbOrganisation.SelectedIndex]["AD_ORG_ID"].ToString())
                {
                    this.cmbOrganisation.Items.Clear();
                    this.dtAccessableOrgInformation =
                        this.getDatafromDataBase.getAD_ORGInfo(null, "",
                            this.stOrganisationID, "", triStateBool.ignor, false, "AND");
                    if (this.getDatafromDataBase.checkIfTableContainesData(this.dtAccessableOrgInformation))
                    {
                        this.cmbOrganisation.Items.Add(this.dtAccessableOrgInformation.Rows[0]["NAME"].ToString());
                        this.cmbOrganisation.SelectedIndex = 0;
                    }
                    else
                    {
                        this.stOrganisationID = "";
                    }
                }
            }
            else
            {
                this.stOrganisationID = "";
            }


            this.txtTrxDocumentNo.Text =
                this.dtgTransactionGridView.Rows[currentSelectedRowIndex].
                        Cells["DOCUMENTNO"].Value.ToString();

            this.dtpTrxDate.Value =
                DateTime.Parse(this.dtgTransactionGridView.Rows[currentSelectedRowIndex].
                        Cells["TRXDATE"].Value.ToString());

            this.txtTrxDescription.Text =
                this.dtgTransactionGridView.Rows[currentSelectedRowIndex].
                        Cells["DESCRIPTION"].Value.ToString();

            this.ddgTrxBpartner.SelectedItem =
                this.dtgTransactionGridView.Rows[currentSelectedRowIndex].
                        Cells["BIZ PARTNER"].Value.ToString();

            this.ddgTrxBpartner.SelectedRowKey =
                this.dtgTransactionGridView.Rows[currentSelectedRowIndex].
                        Cells["M_BPARTNER_ID"].Value.ToString();

            this.intBpartnerID =
                int.Parse(this.dtgTransactionGridView.Rows[currentSelectedRowIndex].
                        Cells["M_BPARTNER_ID"].Value.ToString());

            if (this.dtgTransactionGridView.Rows[currentSelectedRowIndex].
                        Cells["PROCESSED"].Value.ToString() == "Y")
                this.blcurrentTrxProcessed = true;
            else
                this.blcurrentTrxProcessed = false;

            ctlNumberTextBox converter = new ctlNumberTextBox();
            converter.StandardPrecision = 2;
            converter.Amount = 
                this.dtgTransactionGridView.Rows[currentSelectedRowIndex].
                      Cells["SUBTRXAMOUNT"].Value.ToString();

            this.lblTransactionSubTotal.Text = converter.Value;

            converter.Amount =
                this.dtgTransactionGridView.Rows[currentSelectedRowIndex].
                      Cells["TRXTAXAMOUNT"].Value.ToString();

            this.lblTransactionTax.Text = converter.Value;

            converter.Amount =
                this.dtgTransactionGridView.Rows[currentSelectedRowIndex].
                      Cells["GRANDTRXAMOUNT"].Value.ToString();

            this.lblTransactionGrandTotal.Text = converter.Value;

            DataTable dtTrxDetailInformation =
                this.getDatafromDataBase.getT_TRXDETAILInfo(null, "", "",
                    this.intTransactionID.ToString(), "", new DateTime(),false, triStateBool.ignor,
                    "", triStateBool.ignor, false, "AND");

            this.enableDisableFormElement();
            this.dtTentativeTransactionDetail.Clear();

            ctlNumberTextBox numberFormater = new ctlNumberTextBox();

            for (int rowCounter = 0;
                rowCounter <= dtTrxDetailInformation.Rows.Count - 1;
                rowCounter++)
            {
                DataRow drExistingTrxDetailRow =
                    this.dtTentativeTransactionDetail.NewRow();

                drExistingTrxDetailRow["T_TRXDETAIL_ID"] =
                    dtTrxDetailInformation.Rows[rowCounter]["T_TRXDETAIL_ID"].ToString();
                drExistingTrxDetailRow["T_TRANSACTION_ID"] =
                    dtTrxDetailInformation.Rows[rowCounter]["T_TRANSACTION_ID"].ToString();

                drExistingTrxDetailRow["REMOVE"] = "remove";
                drExistingTrxDetailRow["LINE"] =
                    dtTrxDetailInformation.Rows[rowCounter]["LINE"].ToString();
                drExistingTrxDetailRow["M_PRODUCT_ID"] =
                    dtTrxDetailInformation.Rows[rowCounter]["M_PRODUCT_ID"].ToString();
                DataTable dtPrdInfo = 
                    this.getDatafromDataBase.getM_PRODUCTInfo(null, "",
                            dtTrxDetailInformation.Rows[rowCounter]["M_PRODUCT_ID"].ToString(),
                            "", "", "", "", "", "", "", 
                            triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);

                if(dtPrdInfo.Rows.Count > 0)
                {
                    drExistingTrxDetailRow["NAME"] =
                        dtPrdInfo.Rows[0]["NAME"].ToString();
                }

                DataTable dtUnitInfo =
                    this.getDatafromDataBase.getM_UOMInfo(null, "",
                            dtTrxDetailInformation.Rows[rowCounter]["M_UOM_ID"].ToString(),
                                "", "", triStateBool.ignor, false, "AND");

                if (dtUnitInfo.Rows.Count > 0)
                {
                    drExistingTrxDetailRow["UNIT"] =
                        dtUnitInfo.Rows[0]["ABBREVATION"].ToString();

                    numberFormater.StandardPrecision =
                        int.Parse(dtUnitInfo.Rows[0]["STDPRECISION"].ToString());
                }

                numberFormater.Amount = 
                    dtTrxDetailInformation.Rows[rowCounter]["TRXQUANTITY"].ToString();

                drExistingTrxDetailRow[this.lblDetailTrxQuantity.Text] = 
                    numberFormater.Value;

                numberFormater.StandardPrecision = 2;

                drExistingTrxDetailRow["M_WAREHOUSE_ID"] =
                    dtTrxDetailInformation.Rows[rowCounter]["M_WAREHOUSE_ID"].ToString();

                DataTable dtWareHouseInfo =
                    this.getDatafromDataBase.getM_WarehouseInfo(null, "",
                            dtTrxDetailInformation.Rows[rowCounter]["M_WAREHOUSE_ID"].ToString(),
                            "", triStateBool.ignor, triStateBool.ignor, false, "AND");

                if (dtWareHouseInfo.Rows.Count > 0)
                {
                    drExistingTrxDetailRow["STORE"] =
                        dtWareHouseInfo.Rows[0]["NAME"].ToString();
                }

                drExistingTrxDetailRow["M_UOM_ID"] =
                    dtTrxDetailInformation.Rows[rowCounter]["M_UOM_ID"].ToString();

                numberFormater.Amount =
                    dtTrxDetailInformation.Rows[rowCounter]["UNITPRICE"].ToString();
                drExistingTrxDetailRow["PRICE"] =
                    numberFormater.Value;

                numberFormater.Amount =
                    dtTrxDetailInformation.Rows[rowCounter]["LINENETAMT"].ToString();
                drExistingTrxDetailRow["LINE AMT"] = numberFormater.Value;
                
                numberFormater.Amount =
                    dtTrxDetailInformation.Rows[rowCounter]["LINETAXAMOUNT"].ToString();
                drExistingTrxDetailRow["TAX AMT"] = numberFormater.Value;
                    
                drExistingTrxDetailRow["DESCRIPTION"] =
                    dtTrxDetailInformation.Rows[rowCounter]["DESCRIPTION"].ToString();

                numberFormater.Amount = 
                    dtTrxDetailInformation.Rows[rowCounter]["DISCOUNTAMT"].ToString();
                drExistingTrxDetailRow["DISCOUNT AMT"] = numberFormater.Value;

                numberFormater.Amount = 
                    dtTrxDetailInformation.Rows[rowCounter]["MARGIN"].ToString();
                drExistingTrxDetailRow["MARGIN"] = numberFormater.Value;

                numberFormater.Amount =
                    dtTrxDetailInformation.Rows[rowCounter]["UNITCOST"].ToString();
                drExistingTrxDetailRow["UNITCOST"] = numberFormater.Value;
                    
                numberFormater.Amount =
                    dtTrxDetailInformation.Rows[rowCounter]["DISCOUNTRATE"].ToString();
                drExistingTrxDetailRow["DISCOUNT RATE"] = numberFormater.Value;                    

                this.dtTentativeTransactionDetail.Rows.Add(drExistingTrxDetailRow);
            }
            this.dtgTransactionDetail.DataSource = this.dtTentativeTransactionDetail;            
        }


        private void cmdDetailTrxNewProduct_Click(object sender, EventArgs e)
        {
            if (generalResultInformation.currentTrx == transactionType.InventoryIn)
            {
                frmProduct newProduct = new frmProduct();
                Form newProductFrmHolder = new Form();
                newProductFrmHolder.Controls.Add(newProduct);
                newProductFrmHolder.AutoScroll = true;
                newProductFrmHolder.AutoSize = true;
                newProductFrmHolder.AutoSizeMode = AutoSizeMode.GrowOnly;
                newProduct.Dock = DockStyle.Fill;
                newProductFrmHolder.Text = "Products";
                newProductFrmHolder.Load += 
                    new EventHandler(newProduct.frmProduct_Load);
                newProductFrmHolder.ShowDialog();
            }
        }

        private void cmdNewBpartner_Click(object sender, EventArgs e)
        {
            generalResultInformation.stNewCustomerId = "";
            frmBpartner newBpartner = new frmBpartner();            
            Form newBpartnerFrmHolder = new Form();
            newBpartnerFrmHolder.Controls.Add(newBpartner);
            newBpartnerFrmHolder.AutoScroll = true;
            newBpartnerFrmHolder.AutoSize = true;
            newBpartnerFrmHolder.AutoSizeMode = AutoSizeMode.GrowOnly;
            newBpartner.Dock = DockStyle.Fill;
            newBpartnerFrmHolder.Text = "New Customer";
            newBpartnerFrmHolder.Load += 
                new EventHandler(newBpartner.frmBpartner_Load);
            newBpartnerFrmHolder.ShowDialog();

            if (generalResultInformation.currentTrx == transactionType.InventoryOut)
            {                
                this.dtExistingActiveBpartnerInformation =
                    this.getDatafromDataBase.getM_BPARTNERInfo(null, "",
                            "", "", triStateBool.yes, triStateBool.ignor,
                            triStateBool.yes, false, "AND");
            }
            else if (generalResultInformation.currentTrx == transactionType.InventoryIn)
            {                
                this.dtExistingActiveBpartnerInformation =
                   this.getDatafromDataBase.getM_BPARTNERInfo(null, "",
                           "", "", triStateBool.yes, triStateBool.yes,
                           triStateBool.ignor, false, "AND");
            }

            this.dtExistingActiveBpartnerInformation.Columns["TIN"].
                SetOrdinal(this.dtExistingActiveBpartnerInformation.Columns.IndexOf("NAME") + 1);
                       
            if (generalResultInformation.stNewCustomerId != "")
            {
                triStateBool isVendor = triStateBool.ignor;
                triStateBool isCustmer = triStateBool.ignor;
                triStateBool isEmployee = triStateBool.ignor;

                if (generalResultInformation.currentTrx == transactionType.InventoryOut)
                    isCustmer = triStateBool.yes;

                if (generalResultInformation.currentTrx == transactionType.InventoryIn)
                    isVendor = triStateBool.yes;

                DataTable dtBpartnerInfo =
                    this.getDatafromDataBase.getM_BPARTNERInfo(null, "",
                            generalResultInformation.stNewCustomerId,
                            "", triStateBool.yes, isVendor,isCustmer,false, "AND");

                if (!this.getDatafromDataBase.checkIfTableContainesData(dtBpartnerInfo))
                    return;

                this.ddgTrxBpartner.SelectedItem = dtBpartnerInfo.Rows[0]["NAME"].ToString();
                this.intBpartnerID = int.Parse(dtBpartnerInfo.Rows[0]["M_BPARTNER_ID"].ToString());
                this.ddgTrxBpartner.SelectedRowKey = dtBpartnerInfo.Rows[0]["M_BPARTNER_ID"];                
            }
        }


        private void cmbOrganisation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbOrganisation.SelectedIndex >= 0 &&
                this.cmbOrganisation.SelectedIndex <=
                this.dtAccessableOrgInformation.Rows.Count - 1)
                this.stOrganisationID =
                   this.dtAccessableOrgInformation.
                        Rows[this.cmbOrganisation.SelectedIndex]["AD_ORG_ID"].ToString();
            else
                this.stOrganisationID = "";
        }

        private void cmbOrganisation_DropDown(object sender, EventArgs e)
        {            
            this.setUpOrganisations();
        }

        private void dtgTransactionDetail_Sorted(object sender, EventArgs e)
        {        
            this.intDetailTrxPrdPreviousUnitIndex = -1;

            this.cmdDetailTrxAddLine.Text = "ADD";
            this.cmdDetailTrxAddLine.Enabled = false;

            this.ddgDetailProduct.SelectedRow.Clear();
            this.ddgDetailProduct_selectedItemChanged(sender, e);

            this.ntbDetailTrxQuantity.Amount = "0";
            this.ntbDetailTrxUnitPrice.Amount = "0";
            this.ntbDetailTrxTax.Amount = "0";
            this.txtDetailTrxLineTotal.Text = "0.00";
            this.cmbDetailTrxOtherUOM.Items.Clear();
            this.txtDetailTrxDescription.Text = "";

            this.ckDetailTrxLinePrctage.Checked = true;
            this.ntbDetailTrxTax.Amount = "15";

            this.updateTotalTrxAmountIndicators();

            if (this.dtgTransactionDetail.SelectedCells.Count > 0) 
                this.dtgTransactionDetail.CurrentCell.Selected = false;
        }
                        
    }
}
