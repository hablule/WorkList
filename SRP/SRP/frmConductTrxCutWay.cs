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
    public partial class frmConductTrxCutWay : Form
    {
        public frmConductTrxCutWay()
        {
            InitializeComponent();
        }


        string stringShopID = generalResultInformation.activeStation;
        int intProductId = 0;
        int intDetailTrxPrdPreviousUnitIndex = -1;

        DataTable dtTrxInformation = new DataTable();
        DataTable dtTrxDetailInformation = new DataTable();

        DataTable dtDetailTrxItemAlternateUnit = new DataTable();
        DataTable dtExistingActiveBpartnerInformation = new DataTable();
        DataTable dtProductInformation = new DataTable();

        dataBuilder getDatafromDataBase = new dataBuilder();
              


        private void calculateLineTotal()
        {
            ctlNumberTextBox converter = new ctlNumberTextBox();
            converter.Amount =
                this.getDatafromDataBase.roundOff(
                    decimal.Parse(this.ntbCndtTrxSCQuantity.Amount) *
                    decimal.Parse(this.ntbCndtTrxSCUnitPrice.Amount), 2)
                    .ToString();
            this.txtCndtTrxSCTotalAmout.Text = converter.Value;

        }

        private void fillDetailTrxItemUOMComboBox()
        {

            this.cmbCndtTrxSCUnit.Items.Clear();
            if (intProductId == 0)
                return;

            DataTable dtPrdInfo =
                this.getDatafromDataBase.getM_PRODUCTInfo(null, "",
                    intProductId.ToString(), "", "", "", "", "",
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

                if (this.dtDetailTrxItemAlternateUnit.
                            Rows[rowCounter]["M_PRODUCT_ID"].ToString() !=
                        intProductId.ToString() &&
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
                if (this.dtDetailTrxItemAlternateUnit.
                    Rows[rowCounter]["M_PRODUCT_ID"].ToString() == "" ||
                   this.dtDetailTrxItemAlternateUnit.
                    Rows[rowCounter]["M_PRODUCT_ID"].ToString() == "0")
                {
                    for (int rowCounter2 = this.dtDetailTrxItemAlternateUnit.Rows.Count - 1;
                          rowCounter2 >= 0; rowCounter2--)
                    {
                        if ((this.dtDetailTrxItemAlternateUnit.
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
                this.cmbCndtTrxSCUnit.Items.Insert(this.cmbCndtTrxSCUnit.Items.Count,
                            dtUnitInfo.Rows[0]["ABBREVATION"].ToString());
                this.cmbCndtTrxSCUnit.SelectedIndex = 0;
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
                    this.cmbCndtTrxSCUnit.Items.Insert(this.cmbCndtTrxSCUnit.Items.Count,
                                dtUnitInfo.Rows[0]["ABBREVATION"].ToString());
                }
            }
        }


        private void frmConductTrxCutWay_Load(object sender, EventArgs e)
        {
            if (int.Parse(shortTransactionInformation.stProductId) == 0)
            {
                shortTransactionInformation.transactionConducted = false;
                return;
            }

            this.intProductId = int.Parse(shortTransactionInformation.stProductId);

            this.fillDetailTrxItemUOMComboBox();
            this.cmdCndtTrxSCProcessTrx.Enabled = false;

            if (shortTransactionInformation.ttTransactionType == transactionType.InventoryOut)
            {
                this.lblCndtTrxSCBpartner.Text = "Customer";
                this.dtExistingActiveBpartnerInformation =
                    this.getDatafromDataBase.getM_BPARTNERInfo(null, "",
                            "", "", triStateBool.yes, triStateBool.ignor,
                            triStateBool.yes, false, "AND");
            }
            else if (shortTransactionInformation.ttTransactionType == transactionType.InventoryIn)
            {
                this.lblCndtTrxSCBpartner.Text = "Vendor";
                this.dtExistingActiveBpartnerInformation =
                   this.getDatafromDataBase.getM_BPARTNERInfo(null, "",
                           "", "", triStateBool.yes, triStateBool.yes,
                           triStateBool.ignor, false, "AND");
            }

            this.ddgCndtTrxSCBpartner.DataSource =
                this.dtExistingActiveBpartnerInformation.Copy();

            this.dtProductInformation =
                this.getDatafromDataBase.getM_PRODUCTInfo(null, "",
                        this.intProductId.ToString(),
                        "", "", "", "", "", "", "", triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);

            if (!this.getDatafromDataBase.checkIfTableContainesData(this.dtProductInformation))
            {
                MessageBox.Show("Missing Product Value. Contact Your Admin.",
                        "SRP SAVE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                shortTransactionInformation.transactionConducted = false;
                Close();
            }

            this.txtCndtTrxSCProductName.Text =
                this.dtProductInformation.Rows[0]["NAME"].ToString();

            
            if (shortTransactionInformation.ttTransactionType == transactionType.InventoryOut)
                this.ntbCndtTrxSCUnitPrice.Amount =
                    dtProductInformation.Rows[0]["SELLINGPRICE"].ToString();
            else if (shortTransactionInformation.ttTransactionType == transactionType.InventoryIn)
                this.ntbCndtTrxSCUnitPrice.Amount =
                    dtProductInformation.Rows[0]["PURCHASEPRICE"].ToString();
            
        }


        private void cmbCndtTrxSCUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbCndtTrxSCUnit.Items.Count <= 0)
                return;

            if (this.cmbCndtTrxSCUnit.SelectedIndex ==
                this.intDetailTrxPrdPreviousUnitIndex)
                return;

            DataTable dtProductInfo =
                this.getDatafromDataBase.getM_PRODUCTInfo(null, "",
                    this.intProductId.ToString(), "", "", "", "", "", "", "",
                     triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);

            if (dtProductInfo.Rows.Count <= 0)
                return;

            string stSTDUnitId = dtProductInfo.Rows[0]["M_UOM_ID"].ToString();
            decimal dcMultiplier = 1;

            if (this.cmbCndtTrxSCUnit.SelectedIndex != 0)
            {
                if (stSTDUnitId ==
                    this.dtDetailTrxItemAlternateUnit.
                        Rows[this.cmbCndtTrxSCUnit.SelectedIndex - 1]["M_BASE_UOM_ID"].ToString())
                {
                    stSTDUnitId =
                        this.dtDetailTrxItemAlternateUnit.
                        Rows[this.cmbCndtTrxSCUnit.SelectedIndex - 1]["M_DRIVED_UOM_ID"].ToString();
                }
                else
                {
                    stSTDUnitId =
                        this.dtDetailTrxItemAlternateUnit.
                        Rows[this.cmbCndtTrxSCUnit.SelectedIndex - 1]["M_BASE_UOM_ID"].ToString();
                }
            }

            if (this.cmbCndtTrxSCUnit.SelectedIndex != 0)
            {
                if (this.intDetailTrxPrdPreviousUnitIndex == 0)
                {
                    if (dtProductInfo.Rows[0]["M_UOM_ID"].ToString() ==
                        this.dtDetailTrxItemAlternateUnit.
                            Rows[this.cmbCndtTrxSCUnit.SelectedIndex - 1]["M_BASE_UOM_ID"].ToString())
                    {
                        dcMultiplier *=
                            decimal.Parse(this.dtDetailTrxItemAlternateUnit.
                                            Rows[this.cmbCndtTrxSCUnit.SelectedIndex - 1]
                                                        ["MULTIPLIER"].ToString());
                    }
                    else
                    {
                        dcMultiplier /=
                            decimal.Parse(this.dtDetailTrxItemAlternateUnit.
                                            Rows[this.cmbCndtTrxSCUnit.SelectedIndex - 1]
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
                            Rows[this.cmbCndtTrxSCUnit.SelectedIndex - 1]["M_BASE_UOM_ID"].ToString())
                    {
                        dcMultiplier *=
                            decimal.Parse(this.dtDetailTrxItemAlternateUnit.
                                            Rows[this.cmbCndtTrxSCUnit.SelectedIndex - 1]
                                                        ["MULTIPLIER"].ToString());
                    }
                    else
                    {
                        dcMultiplier /=
                            decimal.Parse(this.dtDetailTrxItemAlternateUnit.
                                            Rows[this.cmbCndtTrxSCUnit.SelectedIndex - 1]
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
            this.ntbCndtTrxSCQuantity.StandardPrecision =
                int.Parse(dtUnitInfo.Rows[0]["STDPRECISION"].ToString());

            //decimal dcCrrQty = decimal.Parse(this.ntbDetailTrxQuantity.Amount);

            //this.ntbDetailTrxQuantity.Amount = "0";

            //ctlNumberTextBox converter = new ctlNumberTextBox();            
            //converter.Amount = dcMultiplier.ToString();
            //dcMultiplier = decimal.Parse(converter.Amount);


            this.ntbCndtTrxSCQuantity.Amount =
                (this.getDatafromDataBase.roundOff(
                            (decimal.Parse(this.ntbCndtTrxSCQuantity.Amount) * dcMultiplier),
                            uint.Parse(this.ntbCndtTrxSCQuantity.StandardPrecision.ToString()))).ToString();

            this.ntbCndtTrxSCUnitPrice.Amount =
                (this.getDatafromDataBase.roundOff(
                        (decimal.Parse(this.ntbCndtTrxSCUnitPrice.Amount) / dcMultiplier),
                         uint.Parse(this.ntbCndtTrxSCUnitPrice.StandardPrecision.ToString()))).ToString();


            this.intDetailTrxPrdPreviousUnitIndex =
                this.cmbCndtTrxSCUnit.SelectedIndex;
        }


        private void cmdCndtTrxSCNewCustomer_Click(object sender, EventArgs e)
        {
            Form frmNewBpartnerHolder = new Form();
            frmBpartner frmBpartner = new frmBpartner();
            frmNewBpartnerHolder.Controls.Add(frmBpartner);
            frmBpartner.Dock = DockStyle.Fill;
            frmNewBpartnerHolder.ShowDialog();

            if (shortTransactionInformation.ttTransactionType == transactionType.InventoryOut)
            {                
                this.dtExistingActiveBpartnerInformation =
                    this.getDatafromDataBase.getM_BPARTNERInfo(null, "",
                            "", "", triStateBool.yes, triStateBool.ignor,
                            triStateBool.yes, false, "AND");
            }
            else if (shortTransactionInformation.ttTransactionType == transactionType.InventoryIn)
            {                
                this.dtExistingActiveBpartnerInformation =
                   this.getDatafromDataBase.getM_BPARTNERInfo(null, "",
                           "", "", triStateBool.yes, triStateBool.yes,
                           triStateBool.ignor, false, "AND");
            }

            this.ddgCndtTrxSCBpartner.DataSource =
                this.dtExistingActiveBpartnerInformation.Copy();
            
        }

        private void cmdCndtTrxSCProcessTrx_Click(object sender, EventArgs e)
        {
            if (decimal.Parse(this.txtCndtTrxSCTotalAmout.Text.Replace(",", "")) == 0)
                return;

            this.cmbCndtTrxSCUnit.SelectedIndex = 0;

            if ( shortTransactionInformation.ttTransactionType == transactionType.InventoryOut)
            {
                if (decimal.Parse(this.dtProductInformation.Rows[0]["CURRENTQTY"].ToString()) <
                        decimal.Parse(this.ntbCndtTrxSCQuantity.Amount))
                {
                    if (MessageBox.Show("No sufficient stock. " +
                            "Processing Could Result In Negative Inventory Quanity." +
                            " \n Would You like to continue.", "", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2) == DialogResult.No)
                        return;
                }
            }

            string stTypeOfChange = "INSERT";

            this.dtTrxInformation =
                this.getDatafromDataBase.getT_TRANSACTIONInfo(null, "",
                        "", "", "", new DateTime(), false, triStateBool.ignor,
                            triStateBool.ignor, triStateBool.ignor,
                            transactionStatus.ignor, true, "");

            DataRow drNewTransaction = this.dtTrxInformation.NewRow();
            
            stTypeOfChange = "INSERT";
            
            string stDocNumber = "";
            DataTable dtSequenceInfo = new DataTable();
            
            string stDOCBASETYPE = "";

            if (shortTransactionInformation.ttTransactionType == transactionType.InventoryOut)
            {
                stDOCBASETYPE = "SALES";
            }
            else if (shortTransactionInformation.ttTransactionType == transactionType.InventoryIn)
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
                    shortTransactionInformation.transactionConducted = false;
                    return;
                }
            }

            drNewTransaction["M_SHOP_ID"] = this.stringShopID;
            drNewTransaction["DOCUMENTNO"] = stDocNumber;
            drNewTransaction["DESCRIPTION"] = this.txtCndtTrxSCDescription.Text;
            drNewTransaction["TRXDATE"] = DateTime.Now;
            drNewTransaction["M_BPARTNER_ID"] = this.ddgCndtTrxSCBpartner.SelectedRowKey.ToString();
            
            if (shortTransactionInformation.ttTransactionType == transactionType.InventoryOut)
                drNewTransaction["ISSALESTRX"] = "Y";
            else if (shortTransactionInformation.ttTransactionType == transactionType.InventoryIn)
                drNewTransaction["ISSALESTRX"] = "N";
            drNewTransaction["SUBTRXAMOUNT"] = 
                (decimal.Parse(this.ntbCndtTrxSCUnitPrice.Amount) * 
                 decimal.Parse(this.ntbCndtTrxSCQuantity.Amount));
            drNewTransaction["TRXTAXAMOUNT"] = this.ntbCndtTrxSCTaxAmt.Amount;
            drNewTransaction["GRANDTRXAMOUNT"] = 
                (decimal.Parse(drNewTransaction["SUBTRXAMOUNT"].ToString()) + 
                 decimal.Parse( drNewTransaction["SUBTRXAMOUNT"].ToString())).ToString();
            
            drNewTransaction["PROCESSED"] = "Y";
            drNewTransaction["DOCSTATUS"] = "CO";

            this.dtTrxInformation.Rows.Add(drNewTransaction);

            string[] primaryKeySepartor = { " <(", ")>||" };
            string[] primaryKey =
                this.getDatafromDataBase.changeDataBaseTableData
                        (this.dtTrxInformation.Copy(), "T_TRANSACTION", stTypeOfChange)[0]
                            .Split(primaryKeySepartor, StringSplitOptions.RemoveEmptyEntries);

            if (primaryKey.Length < 2 && stTypeOfChange == "INSERT")
            {
                MessageBox.Show("Unable To Process You Request. Contact Your Admin.",
                    "SRP SAVE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int intTransactionID = 0;

            if (primaryKey.Length > 1)
            {
                intTransactionID = int.Parse(primaryKey[1]);
            }

            this.dtTrxDetailInformation =
                this.getDatafromDataBase.getT_TRXDETAILInfo(null, "", "", "", "",
                                new DateTime(), false, triStateBool.ignor, "", triStateBool.ignor,
                                true, "AND");

            DataRow drNewTrxDetail = this.dtTrxDetailInformation.NewRow();
            
            drNewTrxDetail["T_TRANSACTION_ID"] = intTransactionID.ToString();
            drNewTrxDetail["M_SHOP_ID"] = this.stringShopID;
            drNewTrxDetail["TRXDATE"] =
                this.dtTrxInformation.Rows[0]["TRXDATE"].ToString();
            drNewTrxDetail["M_BPARTNER_ID"] =
                this.dtTrxInformation.Rows[0]["M_BPARTNER_ID"].ToString();
            drNewTrxDetail["ISSALESTRX"] =
                this.dtTrxInformation.Rows[0]["ISSALESTRX"].ToString();
                        
            drNewTrxDetail["M_PRODUCT_ID"] =
                this.intProductId.ToString();
            
            drNewTrxDetail["M_UOM_ID"] =
                this.dtProductInformation.Rows[0]["M_UOM_ID"].ToString();
            
            drNewTrxDetail["TRXQUANTITY"] =
                this.ntbCndtTrxSCQuantity.Amount;
            drNewTrxDetail["UNITPRICE"] =
                this.ntbCndtTrxSCUnitPrice.Amount;
            drNewTrxDetail["LINENETAMT"] =
                this.dtTrxInformation.Rows[0]["SUBTRXAMOUNT"].ToString();
            drNewTrxDetail["LINETAXAMOUNT"] =
                this.dtTrxInformation.Rows[0]["TRXTAXAMOUNT"].ToString();

            string stPriceColName = "";
            if (shortTransactionInformation.ttTransactionType == transactionType.InventoryOut)
            {
                stPriceColName = "SELLINGPRICE";
            }
            else if (shortTransactionInformation.ttTransactionType == transactionType.InventoryIn)
            {
                stPriceColName = "PURCHASEPRICE";
            }


            drNewTrxDetail["DISCOUNTAMT"] =
                (decimal.Parse(this.dtProductInformation.Rows[0][stPriceColName].ToString()) -
                 decimal.Parse(this.ntbCndtTrxSCUnitPrice.Amount)).ToString();
            drNewTrxDetail["DISCOUNTRATE"] =
                (decimal.Parse(drNewTrxDetail["DISCOUNTAMT"].ToString()) /
                decimal.Parse(this.dtProductInformation.Rows[0][stPriceColName].ToString()));

            this.dtTrxDetailInformation.Rows.Add(drNewTrxDetail);            

            primaryKey =
                this.getDatafromDataBase.changeDataBaseTableData
                        (this.dtTrxDetailInformation.Copy(), "T_TRXDETAIL", "UPDATE")[0]
                            .Split(primaryKeySepartor, StringSplitOptions.RemoveEmptyEntries);

            if (primaryKey.Length < 2)
            {
                MessageBox.Show("Unable To Process You Request. Contact Your Admin.",
                    "SRP SAVE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (shortTransactionInformation.ttTransactionType == transactionType.InventoryOut)
            {
                if (this.dtProductInformation.Rows[0]["PRODUCTTYPE"].ToString() == "I")
                        this.dtProductInformation.Rows[0]["CURRENTQTY"] =
                            decimal.Parse(this.dtProductInformation.Rows[0]["CURRENTQTY"].ToString()) -
                            decimal.Parse(this.dtTrxDetailInformation.
                                Rows[0]["TRXQUANTITY"].ToString());
            }

            else if (shortTransactionInformation.ttTransactionType == transactionType.InventoryIn)
            {
                this.dtProductInformation.Rows[0]["CURRENTCOST"] =
                    (
                        (
                            decimal.Parse(this.dtProductInformation.Rows[0]["CURRENTQTY"].ToString()) *
                            decimal.Parse(this.dtProductInformation.Rows[0]["CURRENTCOST"].ToString())
                         ) +
                         (
                            decimal.Parse(this.dtTrxDetailInformation.
                                Rows[0]["LINENETAMT"].ToString())
                         )
                    )
                        /
                    (
                        decimal.Parse(this.dtProductInformation.Rows[0]["CURRENTQTY"].ToString()) +
                        decimal.Parse(this.dtTrxDetailInformation.
                            Rows[0]["TRXQUANTITY"].ToString())
                    );
                
                if (this.dtProductInformation.Rows[0]["PRODUCTTYPE"].ToString().ToUpperInvariant() == "I")
                {
                    this.dtProductInformation.Rows[0]["CURRENTQTY"] =
                        decimal.Parse(this.dtProductInformation.Rows[0]["CURRENTQTY"].ToString()) +
                        decimal.Parse(this.dtTrxDetailInformation.
                                    Rows[0]["TRXQUANTITY"].ToString());
                    
                    this.dtProductInformation.Rows[0]["ACCUMULATEDQTY"] =
                        decimal.Parse(this.dtProductInformation.Rows[0]["ACCUMULATEDQTY"].ToString()) +
                        decimal.Parse(this.dtTrxDetailInformation.
                            Rows[0]["TRXQUANTITY"].ToString());
                }
                
                this.dtProductInformation.Rows[0]["ACCUMULATEDCOST"] =
                    decimal.Parse(this.dtProductInformation.Rows[0]["ACCUMULATEDCOST"].ToString()) +
                    decimal.Parse(this.dtTrxDetailInformation.
                        Rows[0]["LINENETAMT"].ToString());
            }
            
            primaryKey =
                this.getDatafromDataBase.changeDataBaseTableData
                    (this.dtProductInformation.Copy(), "M_PRODUCT", "UPDATE")[0]
                        .Split(primaryKeySepartor, StringSplitOptions.RemoveEmptyEntries);
            
            MessageBox.Show("Process has Completed Successfully.",
                "SRP SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);

            shortTransactionInformation.transactionConducted = true;
        }


        private void ntbCndtTrxSCQuantity_Leave(object sender, EventArgs e)
        {
            this.calculateLineTotal();
            if (decimal.Parse(this.txtCndtTrxSCTotalAmout.Text.Replace(",", "")) == 0 ||
                this.ddgCndtTrxSCBpartner.SelectedRowKey == null)
                this.cmdCndtTrxSCProcessTrx.Enabled = false;
            else
                this.cmdCndtTrxSCProcessTrx.Enabled = true;
        }


        private void ddgCndtTrxSCBpartner_SelectedItemClicked(object sender, EventArgs e)
        {
            this.ddgCndtTrxSCBpartner.DataSource =
                this.dtExistingActiveBpartnerInformation.Copy();
            this.ddgCndtTrxSCBpartner.DataTablePrimaryKey =
                Convert.ToUInt16(this.dtExistingActiveBpartnerInformation.Columns.IndexOf("M_BPARTNER_ID"));
            this.ddgCndtTrxSCBpartner.SelectedColomnIdex =
                this.dtExistingActiveBpartnerInformation.Columns.IndexOf("NAME");
            this.ddgCndtTrxSCBpartner.HiddenColoumns = new int[]
                                {
                                    this.dtExistingActiveBpartnerInformation.Columns.IndexOf("CREATED"),
                                    this.dtExistingActiveBpartnerInformation.Columns.IndexOf("UPDATED")
                                };
        }

        private void ddgCndtTrxSCBpartner_selectedItemChanged(object sender, EventArgs e)
        {
            if (decimal.Parse(this.txtCndtTrxSCTotalAmout.Text.Replace(",", "")) == 0 ||
                this.ddgCndtTrxSCBpartner.SelectedRowKey == null)
                this.cmdCndtTrxSCProcessTrx.Enabled = false;
            else
                this.cmdCndtTrxSCProcessTrx.Enabled = true;
        }

        
    }
}
