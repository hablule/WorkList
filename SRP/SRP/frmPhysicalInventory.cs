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
    public partial class frmPhysicalInventory : Panel
    {
        public frmPhysicalInventory()
        {
            InitializeComponent();
        }

        string stringShopID = generalResultInformation.activeStation;
        string stOrganisationID = "";

        int intCountID = -1;
        int intProductID = -1;
        int intCountedStoreID = -1;
        
        int intDetailCountPrdPreviousUnitIndex = -1;

        bool blcurrentCountProcessed = false;
        bool blCurrentRecordIsReadOnly = false;

        static private Color clNormalLableColor = Color.Black;
        static private Color clErrorLableColor = Color.Red;
        static private Color clChangedLableColor = Color.Blue;

        DataTable dtNewCountInformation = new DataTable();
        DataTable dtNewDetailCountInformation = new DataTable();
        DataTable dtExistingActiveProductInformation = new DataTable();
        DataTable dtCountAccActiveWarehouseInfo = new DataTable();

        DataTable dtAccessableOrgInformation = new DataTable();
        DataTable dtExistingCountInformation = new DataTable();
        DataTable dtExistingDetailCountInformation = new DataTable();
                
        DataTable dtDetailCountItemAlternateUnit = new DataTable();

        DataTable dtAllUOMInformation = new DataTable();
        DataTable dtTentativeCountDetail = new DataTable();

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


        private bool createTransactionSummaryRecord()
        {
            DataTable dtCountInfo = this.getDatafromDataBase.getT_PHYSICALCOUNTInfo(null, "",
                    this.intCountID.ToString(), "", "", new DateTime(),
                    false, triStateBool.ignor, triStateBool.yes,
                    transactionStatus.ignor, false, "AND");

            if (!this.getDatafromDataBase.checkIfTableContainesData(dtCountInfo))
                return false;

            string docStatus = dtCountInfo.Rows[0]["DOCSTATUS"].ToString();

            if (docStatus == "DR")
                return false;

            DataTable dtCurrentCountDetail =
                this.getDatafromDataBase.getT_PHYSICALCOUNTDETAILInfo(null, "", "",
                        this.intCountID.ToString(), "", new DateTime(), false,
                        "", triStateBool.ignor, false, "AND");

            if (!this.getDatafromDataBase.checkIfTableContainesData(dtCurrentCountDetail))
                return false;

            DataTable dtNewMtransactionSummerizer =
                this.getDatafromDataBase.getM_TRANSACTIONInfo(null, "", "", "",
                        "", "", new DateTime(), false, "", "", "",
                        triStateBool.ignor, true, "AND");

            for (int rowCounter = 0; rowCounter <= dtCurrentCountDetail.Rows.Count - 1; rowCounter++)
            {
                DataRow drNewMtrxSummaryRow = dtNewMtransactionSummerizer.NewRow();

                drNewMtrxSummaryRow["M_SHOP_ID"] =
                    dtCurrentCountDetail.Rows[rowCounter]["M_SHOP_ID"].ToString();

                drNewMtrxSummaryRow["AD_ORG_ID"] =
                    dtCurrentCountDetail.Rows[rowCounter]["M_SHOP_ID"].ToString();

                drNewMtrxSummaryRow["MOVEMENTTYPE"] =
                    this.getDataAccordingToRule.getStringEquivelentOfMoveType(movementType.I_p);

                drNewMtrxSummaryRow["MOVEMENTQTY"] =
                    decimal.Parse(dtCurrentCountDetail.Rows[rowCounter]["COUNTQUANTITY"].ToString())
                    -
                    decimal.Parse(dtCurrentCountDetail.Rows[rowCounter]["BOOKQUANTITY"].ToString());

                if (docStatus == "RE")
                {
                    drNewMtrxSummaryRow["MOVEMENTQTY"] = -1 *
                        decimal.Parse(drNewMtrxSummaryRow["MOVEMENTQTY"].ToString());
                }

                drNewMtrxSummaryRow["M_LOCATOR_ID"] =
                    dtCurrentCountDetail.Rows[rowCounter]["M_WAREHOUSE_ID"].ToString();

                drNewMtrxSummaryRow["M_PRODUCT_ID"] =
                    dtCurrentCountDetail.Rows[rowCounter]["M_PRODUCT_ID"].ToString();

                drNewMtrxSummaryRow["MOVEMENTDATE"] =
                    dtCurrentCountDetail.Rows[rowCounter]["COUNTDATE"].ToString();

                drNewMtrxSummaryRow["C_UOM_ID"] =
                    dtCurrentCountDetail.Rows[rowCounter]["M_UOM_ID"].ToString();

                drNewMtrxSummaryRow["M_INVENTORYLINE_ID"] =
                    dtCurrentCountDetail.Rows[rowCounter]["T_PHYSICALCOUNTDETAIL_ID"].ToString();

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

            if (this.txtDocumentNo.Text == "")
            {
                this.lblDocumentNo.ForeColor = clErrorLableColor;
                foundError = true;
            }
            else
            {
                this.lblDocumentNo.ForeColor = clNormalLableColor;
            }

            if (this.intCountedStoreID == -1)
            {
                this.lblCountStore.ForeColor = clErrorLableColor;
                foundError = true;
            }
            else
            {
                this.lblCountStore.ForeColor = clNormalLableColor;
            }
            
            if (this.dtTentativeCountDetail.Rows.Count == 0)
            {
                this.dtgCountLineGridView.BackgroundColor = clErrorLableColor;
                foundError = true;
            }
            else
            {
                this.dtgCountLineGridView.BackgroundColor = 
                    this.dtgCountGridView.BackgroundColor;
            }

            if (this.dtpCountDate.Value == null)
            {
                this.lblCountDate.ForeColor = clErrorLableColor;
                foundError = true;
            }
            else
            {
                this.lblCountDate.ForeColor = clNormalLableColor;
            }            

            return foundError;
        }

        private void determinCurrentRecordReadOnlySatust()
        {
            if (this.intCountID <= 0)
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
            if (this.intCountID == -1)
                this.blcurrentCountProcessed = false;

            if (!this.blcurrentCountProcessed)
            {
                this.determinCurrentRecordReadOnlySatust();
                if (this.blCurrentRecordIsReadOnly)
                    this.blcurrentCountProcessed = true;
            }

            this.cmbOrganisation.Enabled = !this.blcurrentCountProcessed;
            this.txtDocumentNo.Enabled = !this.blcurrentCountProcessed;

            this.ddgProduct.Enabled = !this.blcurrentCountProcessed;
            this.ntbCountQty.Enabled = !this.blcurrentCountProcessed;
            this.cmbDetailCountOtherUOM.Enabled = !this.blcurrentCountProcessed;
            this.cmdAddCountLine.Enabled = !this.blcurrentCountProcessed;
            this.txtCountLineDescription.Enabled = !this.blcurrentCountProcessed;
            
            this.dtgCountLineGridView.Columns["REMOVE"].Visible = 
                !this.blcurrentCountProcessed;
            this.txtDescription.Enabled = !this.blcurrentCountProcessed;
            if (this.dtgCountGridView.SelectedRows.Count == 0)
                this.tlsDelete.Enabled = false;
            else if (this.dtgCountGridView.Rows
                    [this.dtgCountGridView.SelectedRows[0].Index].
                        Cells["PROCESSED"].Value.ToString().ToUpperInvariant() != "N")
                this.tlsDelete.Enabled = false;
            else
                this.tlsDelete.Enabled = true;

            this.tlsPrint.Enabled =
                !this.tlsDelete.Enabled && this.blcurrentCountProcessed;

            this.tlsSave.Enabled = !this.blcurrentCountProcessed;
            this.tlsReverse.Enabled = this.blcurrentCountProcessed;
            this.cmdCreateInventoryCount.Enabled = 
                (!this.blcurrentCountProcessed && this.intCountedStoreID != -1);

            this.cmbCountStore.Enabled = !this.blcurrentCountProcessed;
            this.dtpCountDate.Enabled = !this.blcurrentCountProcessed;

            this.ddgProduct.Enabled = (this.intCountedStoreID != -1 && !this.blcurrentCountProcessed);
            this.cmdDetailTrxProductImage.Enabled = !this.blcurrentCountProcessed;
            
        }

        private void fillDetailTrxItemUOMComboBox()
        {
            this.cmbDetailCountOtherUOM.Items.Clear();
            if (this.ddgProduct.SelectedRowKey == null)
                return;

            DataTable dtPrdInfo =
                this.getDatafromDataBase.getM_PRODUCTInfo(null, "",
                    this.ddgProduct.SelectedRowKey.ToString(), "", "", "", "", "",
                        "", "", triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);

            if (dtPrdInfo.Rows.Count <= 0)
                return;

            this.dtDetailCountItemAlternateUnit =
                    this.getDatafromDataBase.getM_UOM_CONVERSIONInfo(null, "",
                        dtPrdInfo.Rows[0]["M_UOM_ID"].ToString(),
                        dtPrdInfo.Rows[0]["M_UOM_ID"].ToString(),
                        "", 0, triStateBool.ignor, false, "OR");

            for (int rowCounter = this.dtDetailCountItemAlternateUnit.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {

                if (this.dtDetailCountItemAlternateUnit.
                        Rows[rowCounter]["ISACTIVE"].ToString() != "Y")
                {
                    this.dtDetailCountItemAlternateUnit.Rows.RemoveAt(rowCounter);
                    continue;
                }

                if (this.dtDetailCountItemAlternateUnit.
                            Rows[rowCounter]["M_PRODUCT_ID"].ToString() !=
                        this.ddgProduct.SelectedRowKey.ToString() &&
                        this.dtDetailCountItemAlternateUnit.
                            Rows[rowCounter]["M_PRODUCT_ID"].ToString() != "" &&
                        this.dtDetailCountItemAlternateUnit.
                            Rows[rowCounter]["M_PRODUCT_ID"].ToString() != "0"
                        )
                {
                    this.dtDetailCountItemAlternateUnit.Rows.RemoveAt(rowCounter);
                    continue;
                }
            }


            for (int rowCounter = this.dtDetailCountItemAlternateUnit.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                if (this.dtDetailCountItemAlternateUnit.
                    Rows[rowCounter]["M_PRODUCT_ID"].ToString() == "" ||
                   this.dtDetailCountItemAlternateUnit.
                    Rows[rowCounter]["M_PRODUCT_ID"].ToString() == "0")
                {
                    for (int rowCounter2 = this.dtDetailCountItemAlternateUnit.Rows.Count - 1;
                          rowCounter2 >= 0; rowCounter2--)
                    {
                        if ((this.dtDetailCountItemAlternateUnit.
                                Rows[rowCounter]["M_BASE_UOM_ID"].ToString() ==
                            this.dtDetailCountItemAlternateUnit.
                                Rows[rowCounter2]["M_BASE_UOM_ID"].ToString() &&
                            this.dtDetailCountItemAlternateUnit.
                                Rows[rowCounter]["M_DRIVED_UOM_ID"].ToString() ==
                            this.dtDetailCountItemAlternateUnit.
                                Rows[rowCounter2]["M_DRIVED_UOM_ID"].ToString()) ||
                            (this.dtDetailCountItemAlternateUnit.
                                Rows[rowCounter]["M_BASE_UOM_ID"].ToString() ==
                            this.dtDetailCountItemAlternateUnit.
                                Rows[rowCounter2]["M_DRIVED_UOM_ID"].ToString() &&
                            this.dtDetailCountItemAlternateUnit.
                                Rows[rowCounter]["M_BASE_UOM_ID"].ToString() ==
                            this.dtDetailCountItemAlternateUnit.
                                Rows[rowCounter2]["M_DRIVED_UOM_ID"].ToString()))
                        {
                            this.dtDetailCountItemAlternateUnit.Rows.RemoveAt(rowCounter);
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
                this.cmbDetailCountOtherUOM.Items.Insert
                    (this.cmbDetailCountOtherUOM.Items.Count,
                     dtUnitInfo.Rows[0]["ABBREVATION"].ToString()
                    );
                this.cmbDetailCountOtherUOM.SelectedIndex = 0;
            }

            for (int rowCounter = 0; rowCounter <= this.dtDetailCountItemAlternateUnit.Rows.Count - 1;
                rowCounter++)
            {

                string stUnitId = "";

                if (this.dtDetailCountItemAlternateUnit.
                        Rows[rowCounter]["M_BASE_UOM_ID"].ToString() ==
                    dtPrdInfo.Rows[0]["M_UOM_ID"].ToString())
                    stUnitId =
                        this.dtDetailCountItemAlternateUnit.Rows[rowCounter]["M_DRIVED_UOM_ID"].ToString();
                else
                    stUnitId =
                        this.dtDetailCountItemAlternateUnit.Rows[rowCounter]["M_BASE_UOM_ID"].ToString();

                dtUnitInfo =
                    this.getDatafromDataBase.getM_UOMInfo(null, "",
                        stUnitId, "", "", triStateBool.ignor, false, "AND");
                if (dtUnitInfo.Rows.Count > 0)
                {
                    this.cmbDetailCountOtherUOM.Items.Insert
                        (this.cmbDetailCountOtherUOM.Items.Count,
                         dtUnitInfo.Rows[0]["ABBREVATION"].ToString()
                        );
                }
            }
        }

        private void convertItemInfoToStandardUnit()
        {
            if (this.cmbDetailCountOtherUOM.SelectedIndex == 0)
                return;
            int intSelectedUnitIndex = 
                this.cmbDetailCountOtherUOM.SelectedIndex - 1;

            decimal dcMultiplier =
                decimal.Parse(this.dtDetailCountItemAlternateUnit.
                    Rows[intSelectedUnitIndex]["MULTIPLIER"].ToString());
            ctlNumberTextBox converter = new ctlNumberTextBox();
            converter.Amount = dcMultiplier.ToString();
            dcMultiplier = decimal.Parse(converter.Amount);

            if (this.ddgProduct.SelectedRow.Rows[0]["M_UOM_ID"].ToString() ==
                this.dtDetailCountItemAlternateUnit.
                    Rows[intSelectedUnitIndex]["M_DRIVED_UOM_ID"].ToString())
            {
                this.ntbCountQty.Amount =
                    (decimal.Parse(this.ntbCountQty.Amount) *
                        dcMultiplier).ToString();              
            }
            else
            {
                this.ntbCountQty.Amount =
                    (decimal.Parse(this.ntbCountQty.Amount) /
                        dcMultiplier).ToString();
            }

            this.cmbDetailCountOtherUOM.SelectedIndex = 0;
        }
                
        private string getNextDocumentNumber()
        {
            string stNextSequenceNo = "";
            string stDOCBASETYPE = "";

            DataTable dtSequenceInfo = new DataTable();
            
            stDOCBASETYPE = "COUNT";            

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

        private void hidColumnsInDetailGriedView()
        {
            this.dtgCountLineGridView.Columns["M_SHOP_ID"].Visible = false;
            this.dtgCountLineGridView.Columns["AD_ORG_ID"].Visible = false;
            this.dtgCountLineGridView.Columns["M_PRODUCT_ID"].Visible = false;
            this.dtgCountLineGridView.Columns["M_UOM_ID"].Visible = false;
            this.dtgCountLineGridView.Columns["DESCRIPTION"].Visible = false;
            this.dtgCountLineGridView.Columns["T_PHYSICALCOUNT_ID"].Visible = false;
            this.dtgCountLineGridView.Columns["T_PHYSICALCOUNTDETAIL_ID"].Visible = false;
            this.dtgCountLineGridView.Columns["M_WAREHOUSE_ID"].Visible = false;                        
        }

        private void hidColumnsInMainGridView()
        {
            this.dtgCountGridView.Columns["M_SHOP_ID"].Visible = false;
            this.dtgCountGridView.Columns["AD_ORG_ID"].Visible = false;
            this.dtgCountGridView.Columns["T_PHYSICALCOUNT_ID"].Visible = false;
            this.dtgCountGridView.Columns["M_WAREHOUSE_ID"].Visible = false;
        }


        public void frmPhysicalInventory_Load(object sender, EventArgs e)
        {
            this.setUpOrganisations();

            if (generalResultInformation.currentFormIsReadOnly)
            {
                this.tlsDelete.Visible = false;
                this.tlsNew.Visible = false;
                this.tlsSave.Visible = false;
                this.cmdAddCountLine.Visible = false;
            }
            
            this.dtExistingActiveProductInformation =
                this.getDatafromDataBase.getM_PRODUCTInfo(null, "", "",
                        "", "", "", "", "", "", "", 
                                triStateBool.yes, true, "AND",generalResultInformation.dbBulkDataRetrivalSize);

            this.dtCountAccActiveWarehouseInfo =
                this.getDataAccordingToRule.getCurrentUserAccessableWarehouse(triStateBool.ignor, 
                                    triStateBool.ignor, triStateBool.ignor, triStateBool.ignor,
                                    triStateBool.yes, triStateBool.ignor, triStateBool.ignor,
                                    triStateBool.yes, "AND");

            this.cmbCountStore.Items.Add(" - Select Store - ");
            for (int rowCounter = 0;
                 rowCounter <= this.dtCountAccActiveWarehouseInfo.Rows.Count - 1;
                 rowCounter++)
            {
                this.cmbCountStore.Items.Add(
                    this.dtCountAccActiveWarehouseInfo.Rows[rowCounter]["NAME"].ToString());
            }
            if(this.cmbCountStore.Items.Count > 1)
                this.cmbCountStore.SelectedIndex = 1;
            else
                this.cmbCountStore.SelectedIndex = 0;
                
            
            this.ddgProduct.DataSource =
                this.dtExistingActiveProductInformation;

            this.cancelButtonStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.cancelButtonStyle.BackColor = Color.FromKnownColor(KnownColor.ControlDark);
            this.cancelButtonStyle.ForeColor = Color.FromKnownColor(KnownColor.Desktop);
            this.cancelButtonStyle.SelectionForeColor = Color.FromKnownColor(KnownColor.DarkBlue);
            this.cancelButtonStyle.WrapMode = DataGridViewTriState.False;
            this.cancelButtonStyle.Font =
                new System.Drawing.Font("Microsoft Sans Serif", 8.25F,
                    System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            
            this.dtTentativeCountDetail.Columns.Add("M_PRODUCT_ID");
            this.dtTentativeCountDetail.Columns.Add("REMOVE");
            this.dtTentativeCountDetail.Columns.Add("LINE",typeof(Int16));
            this.dtTentativeCountDetail.Columns.Add("NAME");
            this.dtTentativeCountDetail.Columns.Add("Book Qty");
            this.dtTentativeCountDetail.Columns.Add("Count Qty");
            this.dtTentativeCountDetail.Columns.Add("Unit");
            this.dtTentativeCountDetail.Columns.Add("M_UOM_ID");
            this.dtTentativeCountDetail.Columns.Add("M_WAREHOUSE_ID");
            this.dtTentativeCountDetail.Columns.Add("DESCRIPTION");
            this.dtTentativeCountDetail.Columns.Add("T_PHYSICALCOUNT_ID");
            this.dtTentativeCountDetail.Columns.Add("T_PHYSICALCOUNTDETAIL_ID");
            this.dtTentativeCountDetail.Columns.Add("M_SHOP_ID");
            this.dtTentativeCountDetail.Columns.Add("AD_ORG_ID");

            this.dtTentativeCountDetail.Columns["REMOVE"].SetOrdinal(1);

            this.dtgCountLineGridView.DataSource = this.dtTentativeCountDetail;


            this.dtgCountLineGridView.Columns["LINE"].HeaderText = "SN";

            this.dtgCountLineGridView.Columns["REMOVE"].HeaderText = "";
            this.dtgCountLineGridView.Columns["REMOVE"].DefaultCellStyle = this.cancelButtonStyle;

            this.dtExistingCountInformation.Columns.Add("M_SHOP_ID");
            this.dtExistingCountInformation.Columns.Add("AD_ORG_ID");
            this.dtExistingCountInformation.Columns.Add("T_PHYSICALCOUNT_ID");
            this.dtExistingCountInformation.Columns.Add("DOCUMENTNO");
            this.dtExistingCountInformation.Columns.Add("DESCRIPTION");
            this.dtExistingCountInformation.Columns.Add("COUNTDATE");
            this.dtExistingCountInformation.Columns.Add("M_WAREHOUSE_ID");            
            this.dtExistingCountInformation.Columns.Add("Store");            
            this.dtExistingCountInformation.Columns.Add("PROCESSED");
            this.dtExistingCountInformation.Columns.Add("DOCSTATUS");

            this.dtgCountGridView.DataSource = 
                this.dtExistingCountInformation;
                        
            this.tlsNew_Click(sender, e);

            this.hidColumnsInMainGridView();
            this.hidColumnsInDetailGriedView();
            
        }

        private void tlsNew_Click(object sender, EventArgs e)
        {
            this.blcurrentCountProcessed = false;
            this.enableDisableFormElement();

            if (this.cmbCountStore.Items.Count > 1)
                this.cmbCountStore.SelectedIndex = 1;
            else
                this.cmbCountStore.SelectedIndex = 0;

            this.intCountID = -1;            
            this.intDetailCountPrdPreviousUnitIndex = -1;            

            this.txtDocumentNo.Text = 
                this.getNextDocumentNumber();
            this.txtDescription.Text = "";
            this.dtpCountDate.Value = DateTime.Today;
            

            this.ddgProduct.SelectedItem = "";
            this.ddgProduct.SelectedRow.Clear();
            this.ddgProduct.SelectedRowKey = null;
            this.ddgProduct_selectedItemChanged(sender, e);

            this.ntbBookQty.Amount = "0";
            this.ntbCountQty.Amount = "0";
            
            this.cmbDetailCountOtherUOM.Items.Clear();
            this.txtCountLineDescription.Text = "";
            
            this.dtNewDetailCountInformation.Clear();
            this.dtNewCountInformation.Clear();

            this.dtTentativeCountDetail.Rows.Clear();

            this.cmdAddCountLine.Enabled = false;

            this.lblDocumentNo.ForeColor = clNormalLableColor;
            this.lblCountStore.ForeColor = clNormalLableColor;            
            this.dtgCountLineGridView.BackgroundColor = 
                this.dtgCountGridView.BackgroundColor;
            this.lblCountDate.ForeColor = clNormalLableColor;
        }

        private void tlsSave_Click(object sender, EventArgs e)
        {
            string stTypeOfChange = "INSERT";
            if (this.checkForCompleteNewRecord())
            {
                MessageBox.Show("Please complete the missing form element before proceeding.",
                    "SRP SAVE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool foundChangedInventory = false;
            decimal stockQuanity;
            for (int rowCounter = 0;
                rowCounter < this.dtTentativeCountDetail.Rows.Count; rowCounter++)
            {
                stockQuanity =
                    decimal.Parse(this.dtTentativeCountDetail.Rows[rowCounter]["Book Qty"].ToString());

                if (stockQuanity != 0)
                {
                    if (decimal.Parse(this.dtTentativeCountDetail.Rows[rowCounter]["Count Qty"].ToString()) !=
                        decimal.Parse(this.dtTentativeCountDetail.Rows[rowCounter]["Book Qty"].ToString()))
                    {
                        foundChangedInventory = true;
                        this.dtgCountLineGridView.Rows[rowCounter].DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        this.dtgCountLineGridView.Rows[rowCounter].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
                else
                {
                    foundChangedInventory = true;
                    this.dtgCountLineGridView.Rows[rowCounter].DefaultCellStyle.ForeColor = Color.Red;
                }
            }

            if (foundChangedInventory)
            {
                if (MessageBox.Show("There are Altered Or Zero Count Items. \n Would you Like to Revise your Count",
                                "SRP PROCESS", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    return;
            }

            DialogResult result =
                MessageBox.Show("Would you Like to Complete the Count",
                                "SRP PROCESS", MessageBoxButtons.YesNoCancel,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            
            if (result == DialogResult.Cancel)
                return;
            
            this.dtNewCountInformation =
                this.getDatafromDataBase.getT_PHYSICALCOUNTInfo(null, "",
                        "", "", "", new DateTime(), false, triStateBool.ignor,
                        triStateBool.ignor, transactionStatus.ignor, true, "");

            DataRow drNewCount = this.dtNewCountInformation.NewRow();

            if (this.intCountID != -1)
            {
                stTypeOfChange = "UPDATE";
                drNewCount["T_PHYSICALCOUNT_ID"] = this.intCountID.ToString();
            }
            else
            {
                stTypeOfChange = "INSERT";
            }

            string stDocNumber = "";
            if (this.intCountID == -1 && this.txtDocumentNo.Text.StartsWith("<") &&
                this.txtDocumentNo.Text.EndsWith(">"))
            {
                DataTable dtSequenceInfo = new DataTable();

                string stDOCBASETYPE = "COUNT";
                
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
                        return;
                    }
                }

            }
            else
            {
                stDocNumber = this.txtDocumentNo.Text;
            }

            drNewCount["M_SHOP_ID"] = this.stringShopID;
            drNewCount["AD_ORG_ID"] = this.stOrganisationID;            
            drNewCount["DOCUMENTNO"] = stDocNumber;
            drNewCount["DESCRIPTION"] = this.txtDescription.Text;
            drNewCount["COUNTDATE"] = this.dtpCountDate.Value;
            drNewCount["M_WAREHOUSE_ID"] = this.intCountedStoreID.ToString();            
            
            if (result == DialogResult.Yes)
                drNewCount["PROCESSED"] = "Y";
            else
                drNewCount["PROCESSED"] = "N";

            if (result == DialogResult.No)
                drNewCount["DOCSTATUS"] = "DR";
            else if (result == DialogResult.Yes)
                drNewCount["DOCSTATUS"] = "CO";

            this.dtNewCountInformation.Rows.Add(drNewCount);

            string[] primaryKeySepartor = { " <(", ")>||" };
            string[] primaryKey =
                this.getDatafromDataBase.changeDataBaseTableData
                        (this.dtNewCountInformation.Copy(), "T_PHYSICALCOUNT", stTypeOfChange)[0]
                            .Split(primaryKeySepartor, StringSplitOptions.RemoveEmptyEntries);

            if (primaryKey.Length < 2 && stTypeOfChange == "INSERT")
            {
                MessageBox.Show("Unable To Process Your Request. Contact Your Admin.",
                    "SRP SAVE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (primaryKey.Length > 1 && stTypeOfChange == "INSERT")
            {
                this.intCountID = int.Parse(primaryKey[1]);
            }

            this.dtNewDetailCountInformation =
                this.getDatafromDataBase.getT_PHYSICALCOUNTDETAILInfo(null, "", "", "", "",
                                new DateTime(), false,"", triStateBool.ignor,
                                true, "AND");

            for (int rowCounter = 0;
                rowCounter < this.dtTentativeCountDetail.Rows.Count; rowCounter++)
            {
                DataRow drNewUsageDetail = this.dtNewDetailCountInformation.NewRow();

                drNewUsageDetail["T_PHYSICALCOUNT_ID"] = this.intCountID.ToString();
                drNewUsageDetail["M_SHOP_ID"] = this.stringShopID;
                drNewUsageDetail["AD_ORG_ID"] = this.stOrganisationID;                
                drNewUsageDetail["COUNTDATE"] =
                    this.dtNewCountInformation.Rows[0]["COUNTDATE"].ToString();
                drNewUsageDetail["M_WAREHOUSE_ID"] =
                    this.dtNewCountInformation.Rows[0]["M_WAREHOUSE_ID"].ToString();

                if (this.dtTentativeCountDetail.Rows[rowCounter]["T_PHYSICALCOUNTDETAIL_ID"].ToString() != "")
                    drNewUsageDetail["T_PHYSICALCOUNTDETAIL_ID"] =
                        this.dtTentativeCountDetail.Rows[rowCounter]["T_PHYSICALCOUNTDETAIL_ID"].ToString();
                drNewUsageDetail["LINE"] =
                    this.dtTentativeCountDetail.Rows[rowCounter]["LINE"].ToString();
                drNewUsageDetail["M_PRODUCT_ID"] =
                    this.dtTentativeCountDetail.Rows[rowCounter]["M_PRODUCT_ID"].ToString();
                drNewUsageDetail["M_UOM_ID"] =
                    this.dtTentativeCountDetail.Rows[rowCounter]["M_UOM_ID"].ToString();
                drNewUsageDetail["DESCRIPTION"] =
                    this.dtTentativeCountDetail.Rows[rowCounter]["DESCRIPTION"].ToString();
                drNewUsageDetail["BOOKQUANTITY"] =
                    this.dtTentativeCountDetail.
                        Rows[rowCounter]["Book Qty"].ToString().Replace(",", "");
                drNewUsageDetail["COUNTQUANTITY"] =
                    this.dtTentativeCountDetail.
                        Rows[rowCounter]["Count Qty"].ToString().Replace(",", "");

                this.dtNewDetailCountInformation.Rows.Add(drNewUsageDetail);
            }

            primaryKey =
                this.getDatafromDataBase.changeDataBaseTableData
                        (this.dtNewDetailCountInformation.Copy(), "T_PHYSICALCOUNTDETAIL", "UPDATE")[0]
                            .Split(primaryKeySepartor, StringSplitOptions.RemoveEmptyEntries);

            if (primaryKey.Length < 2 && stTypeOfChange == "INSERT")
            {
                MessageBox.Show("Unable To Process You Request. Contact Your Admin.",
                    "SRP SAVE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (result == DialogResult.No)
            {
                goto finalLine;
            }

            bool saveTrxSummary = this.createTransactionSummaryRecord();

            if (!saveTrxSummary)
            {
                goto finalLine;
            }
            
            for (int rowCounter = 0;
                rowCounter < this.dtNewDetailCountInformation.Rows.Count; rowCounter++)
            {
                this.getDataAccordingToRule.adjustStock
                     (
                       this.dtNewDetailCountInformation.Rows[rowCounter]["M_PRODUCT_ID"].ToString(),
                       this.dtNewCountInformation.Rows[0]["M_WAREHOUSE_ID"].ToString(),
                       (
                        decimal.Parse(
                                this.dtNewDetailCountInformation.Rows[rowCounter]["COUNTQUANTITY"].ToString()
                                    )
                                    -
                        decimal.Parse(
                                this.dtNewDetailCountInformation.Rows[rowCounter]["BOOKQUANTITY"].ToString())                                
                        
                       )
                     );
            }

        finalLine:

            if (stTypeOfChange == "INSERT")
            {
                DataRow drNewExistingUsageRow =
                       this.dtExistingCountInformation.NewRow();
                drNewExistingUsageRow["T_PHYSICALCOUNT_ID"] = this.intCountID.ToString();
                drNewExistingUsageRow["DOCUMENTNO"] = this.txtDocumentNo.Text;
                drNewExistingUsageRow["COUNTDATE"] = this.dtpCountDate.Value.ToString();
                drNewExistingUsageRow["DESCRIPTION"] = this.txtDescription.Text;
                drNewExistingUsageRow["M_WAREHOUSE_ID"] = this.intCountedStoreID.ToString();
                drNewExistingUsageRow["STORE"] = this.cmbCountStore.SelectedItem.ToString();               
                                
                if (result == DialogResult.No)
                {
                    drNewExistingUsageRow["PROCESSED"] = "N";
                    drNewExistingUsageRow["DOCSTATUS"] = "DRAFTED";
                }
                else if (result == DialogResult.Yes)
                {
                    drNewExistingUsageRow["PROCESSED"] = "Y";
                    drNewExistingUsageRow["DOCSTATUS"] = "COMPLETED";
                }

                this.dtExistingCountInformation.Rows.Add(drNewExistingUsageRow);
            }
            else if (stTypeOfChange == "UPDATE")
            {
                bool updateHasBeenMade = false;
                for (int rowCounter = 0;
                        rowCounter <= this.dtExistingCountInformation.Rows.Count - 1;
                        rowCounter++)
                {
                    if (this.intCountID.ToString() ==
                        this.dtExistingCountInformation.Rows[rowCounter]["T_PHYSICALCOUNT_ID"].ToString())
                    {

                        this.dtExistingCountInformation.
                            Rows[rowCounter]["DOCUMENTNO"] = this.txtDocumentNo.Text;
                        this.dtExistingCountInformation.
                            Rows[rowCounter]["COUNTDATE"] = this.dtpCountDate.Value.ToString();
                        this.dtExistingCountInformation.
                            Rows[rowCounter]["DESCRIPTION"] = this.txtDescription.Text;
                        this.dtExistingCountInformation.
                            Rows[rowCounter]["M_WAREHOUSE_ID"] = this.intCountedStoreID.ToString();
                        this.dtExistingCountInformation.
                            Rows[rowCounter]["STORE"] = this.cmbCountStore.SelectedItem.ToString();                        
                        
                        if (result == DialogResult.No)
                        {
                            this.dtExistingCountInformation.
                                Rows[rowCounter]["PROCESSED"] = "N";
                            this.dtExistingCountInformation.
                             Rows[rowCounter]["DOCSTATUS"] = "DRAFTED";
                        }
                        else if (result == DialogResult.Yes)
                        {
                            this.dtExistingCountInformation.
                                Rows[rowCounter]["PROCESSED"] = "Y";
                            this.dtExistingCountInformation.
                             Rows[rowCounter]["DOCSTATUS"] = "COMPLETED";
                        }

                        updateHasBeenMade = true;
                        break;
                    }
                }
                if (!updateHasBeenMade)
                {
                    this.dtExistingCountInformation.Clear();
                }

            }

            this.dtgCountGridView.DataSource = this.dtExistingCountInformation;

            MessageBox.Show("Process has Completed Successfully.",
                    "SRP SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.tlsNew_Click(sender, e);
        }

        private void tlsDelete_Click(object sender, EventArgs e)
        {
            if (this.intCountID == -1)
                return;

            DataTable dtExistingCountInfo =
                this.getDatafromDataBase.getT_PHYSICALCOUNTInfo(null, "",
                        this.intCountID.ToString(), "", "", new DateTime(),
                        false, triStateBool.ignor, triStateBool.No,
                        transactionStatus.Draft, false, "AND");

            if (dtExistingCountInfo.Rows.Count != 1)
                return;

            if (MessageBox.Show("Are you sure you want to DELETE this Count.",
                "SRP Warning", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                == DialogResult.No)
                return;



            DataTable dtExistingCountDetailInfo =
                this.getDatafromDataBase.getT_PHYSICALCOUNTDETAILInfo(null, "",
                    "", this.intCountID.ToString(), "", new DateTime(),
                    false,"", triStateBool.ignor, false, "AND");

            this.getDatafromDataBase.changeDataBaseTableData(dtExistingCountDetailInfo, "T_PHYSICALCOUNTDETAIL", "DELETE");
            this.getDatafromDataBase.changeDataBaseTableData(dtExistingCountInfo, "T_PHYSICALCOUNT", "DELETE");

            MessageBox.Show("Process has Completed Successfully.",
                    "SRP DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (this.dtExistingCountInformation.Rows.Count > 0)
            {
                this.dtExistingCountInformation.Rows.RemoveAt
                    (this.dtgCountGridView.SelectedRows[0].Index);
                this.dtExistingDetailCountInformation.Clear();
                if (this.dtExistingCountInformation.Rows.Count > 0)
                {
                    int intCrrSelectedRow =
                        this.dtgCountGridView.SelectedRows[0].Index;
                    if (intCrrSelectedRow < 0)
                        intCrrSelectedRow = 0;
                    this.dtgCountGridView.
                        Rows[intCrrSelectedRow - 1].Selected = true;
                    this.dtgCountGridView_CellClick(sender, new DataGridViewCellEventArgs(0, 0));
                }
            }
            else
            {
                this.tlsNew_Click(sender, e);
            }
        }

        private void tlsReverse_Click(object sender, EventArgs e)
        {
            if (this.intCountID == -1)
                return;

            DataTable dtExistingCountInfo =
                this.getDatafromDataBase.getT_PHYSICALCOUNTInfo(null, "",
                        this.intCountID.ToString(), "", "", new DateTime(),
                        false, triStateBool.ignor, triStateBool.yes,
                        transactionStatus.Complete, false, "AND");

            if (dtExistingCountInfo.Rows.Count != 1)
                return;

            if (dtExistingCountInfo.Rows[0]["DOCSTATUS"].ToString() == "RE" ||
                dtExistingCountInfo.Rows[0]["DOCSTATUS"].ToString() == "DR")
                return;


            if (MessageBox.Show("Are you sure you want to REVERESE the effect of this Count.\n" +
                    "This will Alter the stock quantity Respective Items",
                    "SRP Warning", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                == DialogResult.No)
                return;

            DataTable dtExistingCountDetailInfo =
                this.getDatafromDataBase.getT_PHYSICALCOUNTDETAILInfo(null, "",
                    "", this.intCountID.ToString(), "", new DateTime(),
                    false, "", triStateBool.ignor, false, "AND");

            int intM_PRODUCT_ID = -1;
            int intM_WAREHOUSE_ID = -1;            
            decimal dcBookQuantity = 0;
            decimal dcCountQuantity = 0;

            for (int rowCounter = 0; 
                 rowCounter <= dtExistingCountDetailInfo.Rows.Count - 1; rowCounter++)
            {
                intM_PRODUCT_ID = 
                    int.Parse(dtExistingCountDetailInfo.
                                    Rows[rowCounter]["M_PRODUCT_ID"].ToString());

                if (intM_PRODUCT_ID == -1 ||
                    intM_PRODUCT_ID == 0)
                {
                    goto finalLine;
                }

                intM_WAREHOUSE_ID =
                    int.Parse(dtExistingCountDetailInfo.
                                Rows[rowCounter]["M_WAREHOUSE_ID"].ToString());

                if (intM_WAREHOUSE_ID == -1 ||
                    intM_WAREHOUSE_ID == 0)
                {
                    goto finalLine;
                }
                
                dcBookQuantity =
                    decimal.Parse(dtExistingCountDetailInfo.
                                    Rows[rowCounter]["BOOKQUANTITY"].ToString());

                dcCountQuantity =
                    decimal.Parse(dtExistingCountDetailInfo.
                                    Rows[rowCounter]["COUNTQUANTITY"].ToString());

                                
                this.getDataAccordingToRule.adjustStock
                    (intM_PRODUCT_ID.ToString(),intM_WAREHOUSE_ID.ToString(),
                       (dcCountQuantity - dcBookQuantity) * -1
                    );
            }

            dtExistingCountInfo.Rows[0]["DOCSTATUS"] = "RE";

            this.getDatafromDataBase.
                changeDataBaseTableData(dtExistingCountInfo, "T_PHYSICALCOUNT", "UPDATE");

            if (this.dtgCountGridView.SelectedRows.Count > 0)
            {
                this.dtExistingCountInformation.
                    Rows[this.dtgCountGridView.SelectedRows[0].Index]["DOCSTATUS"] = "REVERSED";
            }

            bool saveTrxSummary = this.createTransactionSummaryRecord();

            if (!saveTrxSummary)
            {
                return;
            }

            MessageBox.Show("Process has Completed Successfully.",
                "SRP REVERSE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;

        finalLine:
            MessageBox.Show("There Seems A problem Processing Your Request Please Try Again Later.",
                "SRP Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);            
        }

        private void tlsSearch_Click(object sender, EventArgs e)
        {
            this.dtExistingCountInformation.Rows.Clear();

            this.tlsNew_Click(sender, e);
                        
            this.dtExistingCountInformation.Rows.Clear();
            generalResultInformation.searchResult.Clear();

            frmSearchCount frmSearchCount = new frmSearchCount();
            Form newCountSearchFrmHolder = new Form();
            newCountSearchFrmHolder.Controls.Add(frmSearchCount);
            newCountSearchFrmHolder.AutoScroll = true;
            newCountSearchFrmHolder.AutoSize = true;
            newCountSearchFrmHolder.AutoSizeMode = AutoSizeMode.GrowOnly;
            frmSearchCount.Dock = DockStyle.Fill;
            newCountSearchFrmHolder.Text = "Physical Inventory";
            newCountSearchFrmHolder.Load +=
                new EventHandler(frmSearchCount.frmSearchCount_Load);
            newCountSearchFrmHolder.ShowDialog();

            DataTable resultTable = 
                generalResultInformation.searchResult.Copy();
            generalResultInformation.searchResult.Clear();
            for (int rowCounter = 0; rowCounter <= resultTable.Rows.Count - 1; rowCounter++)
            {
                DataRow drNewExistingCountRow =
                   this.dtExistingCountInformation.NewRow();
                drNewExistingCountRow["M_SHOP_ID"] =
                    resultTable.Rows[rowCounter]["M_SHOP_ID"].ToString();
                drNewExistingCountRow["AD_ORG_ID"] =
                    resultTable.Rows[rowCounter]["AD_ORG_ID"].ToString();
                drNewExistingCountRow["T_PHYSICALCOUNT_ID"] =
                    resultTable.Rows[rowCounter]["T_PHYSICALCOUNT_ID"].ToString();
                drNewExistingCountRow["DOCUMENTNO"] =
                    resultTable.Rows[rowCounter]["DOCUMENTNO"].ToString();
                drNewExistingCountRow["COUNTDATE"] =
                   resultTable.Rows[rowCounter]["COUNTDATE"].ToString();
                drNewExistingCountRow["DESCRIPTION"] =
                    resultTable.Rows[rowCounter]["DESCRIPTION"].ToString();

                drNewExistingCountRow["M_WAREHOUSE_ID"] =
                    resultTable.Rows[rowCounter]["M_WAREHOUSE_ID"].ToString();

                DataTable dtWareHouseInfo = 
                    this.getDatafromDataBase.getM_WarehouseInfo(null, "",
                        resultTable.Rows[rowCounter]["M_WAREHOUSE_ID"].ToString(),
                        "", triStateBool.ignor, triStateBool.ignor, false, "AND");
                try
                {
                    drNewExistingCountRow["STORE"] =
                        dtWareHouseInfo.Rows[0]["NAME"].ToString();
                }
                catch
                {
                    drNewExistingCountRow["STORE"] = "Not Found";
                }

                drNewExistingCountRow["PROCESSED"] =
                    resultTable.Rows[rowCounter]["PROCESSED"].ToString();

                if (resultTable.Rows[rowCounter]["DOCSTATUS"].ToString() == "DR")
                    drNewExistingCountRow["DOCSTATUS"] = "DRAFTED";
                else if (resultTable.Rows[rowCounter]["DOCSTATUS"].ToString() == "CO")
                    drNewExistingCountRow["DOCSTATUS"] = "COMPLETED";
                else if (resultTable.Rows[rowCounter]["DOCSTATUS"].ToString() == "RE")
                    drNewExistingCountRow["DOCSTATUS"] = "REVERSED";

                this.dtExistingCountInformation.Rows.Add(drNewExistingCountRow);
            }
            if (this.dtExistingCountInformation.Rows.Count > 0)
            {
                this.dtgCountGridView.Rows[0].Selected = true;
                this.dtgCountGridView_CellClick(sender, new DataGridViewCellEventArgs(0, 0));                
            }            
            if(this.dtgCountLineGridView.SelectedRows.Count > 0)
                this.dtgCountLineGridView.CurrentRow.Selected = false;            
        }

        private void tlsToogleView_Click(object sender, EventArgs e)
        {
            if (this.tlsToogleView.Text == "Grid View")
            {
                this.tlsToogleView.Text = "Record View";
                this.hidColumnsInMainGridView();
                this.dtgCountGridView.Visible = true;
                this.dtgCountGridView.BringToFront();
                this.dtgCountGridView.Size =
                    new Size(this.Size.Width - 12, this.dtgCountGridView.Size.Height);
            }
            else
            {
                this.tlsToogleView.Text = "Grid View";
                this.dtgCountGridView.SendToBack();
                this.dtgCountGridView.Size =
                    new Size(11, this.dtgCountGridView.Size.Height);
                this.dtgCountGridView.Visible = false;
            }
        }


        private void ddgProduct_SelectedItemClicked(object sender, EventArgs e)
        {
            this.dtExistingActiveProductInformation =
               this.getDatafromDataBase.getM_PRODUCTInfo(null, "", "", "", "", "",
                       this.ddgProduct.SelectedItem, "", "", "", 
                       triStateBool.yes, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);
            this.ddgProduct.DataSource =
                this.dtExistingActiveProductInformation;
            this.ddgProduct.DataTablePrimaryKey =
                Convert.ToUInt16(this.dtExistingActiveProductInformation.Columns.IndexOf("M_PRODUCT_ID"));
            this.ddgProduct.SelectedColomnIdex =
                this.dtExistingActiveProductInformation.Columns.IndexOf("NAME");
            this.ddgProduct.HiddenColoumns = new int[]
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

        private void ddgProduct_selectedItemChanged(object sender, EventArgs e)
        {       
            if (this.ddgProduct.SelectedRow != null &&
                this.ddgProduct.SelectedRow.Rows.Count > 0)
            {
                this.intProductID =
                        int.Parse(this.ddgProduct.SelectedRowKey.ToString());
                int countLineIndex = -1;
                for (int exitingCountLineCounter = 0;
                    exitingCountLineCounter <= this.dtTentativeCountDetail.Rows.Count - 1;
                    exitingCountLineCounter++)
                {
                    if (intProductID.ToString() == this.dtTentativeCountDetail.Rows[exitingCountLineCounter]["M_PRODUCT_ID"].ToString())
                    {
                        countLineIndex = exitingCountLineCounter;
                        break;
                    }
                }

                if (countLineIndex != -1)
                {
                    this.dtgCountLineGridView.Rows[countLineIndex].Selected = true;
                    this.dtgCountLineGridView.CurrentCell = 
                        this.dtgCountLineGridView.Rows[countLineIndex].Cells[2];
                    this.dtgCountLineGridView_CellClick(this.dtgCountLineGridView,
                        new DataGridViewCellEventArgs(2,this.dtgCountLineGridView.SelectedRows[0].Index));
                }
                else
                {                    
                    this.ntbCountQty.Enabled = true;
                    DataTable stockInfo =
                        this.getDatafromDataBase.getQ_STOCKInfo(null, "", 
                                        this.intProductID.ToString(),
                                        this.intCountedStoreID.ToString(), 
                                        triStateBool.ignor, false, "AND");
                    if (stockInfo.Rows.Count > 0)
                        this.ntbBookQty.Amount = stockInfo.Rows[0]["CURRENTQTY"].ToString();
                    else
                        this.ntbBookQty.Amount = "0";
                }
            }
            else
            {
                this.intProductID = -1;

                this.ntbBookQty.Amount = "0";
                this.ntbCountQty.Amount = "0";                
                this.ddgProduct.SelectedItem = "";
                this.ntbCountQty.Enabled = false;
                this.cmbDetailCountOtherUOM.Items.Clear();
                this.dtDetailCountItemAlternateUnit.Rows.Clear();
            }
            this.fillDetailTrxItemUOMComboBox();
        }


        private void cmbCountFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.intCountedStoreID = -1;
            if (this.cmbCountStore.SelectedIndex > 0)
                this.intCountedStoreID =
                    int.Parse(this.dtCountAccActiveWarehouseInfo.
                                Rows[this.cmbCountStore.SelectedIndex - 1]
                                    ["M_WAREHOUSE_ID"].ToString());

            this.cmdCreateInventoryCount.Enabled = (this.intCountedStoreID != -1);

            this.ddgProduct.Enabled = (this.intCountedStoreID != -1);

            this.intDetailCountPrdPreviousUnitIndex = -1;

            this.ddgProduct.SelectedItem = "";
            this.ddgProduct.SelectedRow.Clear();
            this.ddgProduct.SelectedRowKey = null;
            this.ddgProduct_selectedItemChanged(sender, e);

            this.ntbBookQty.Amount = "0";
            this.ntbCountQty.Amount = "0";

            this.cmbDetailCountOtherUOM.Items.Clear();
            this.txtCountLineDescription.Text = "";

            this.dtNewDetailCountInformation.Clear();
            this.dtNewCountInformation.Clear();

            this.dtTentativeCountDetail.Rows.Clear();

            this.cmdAddCountLine.Enabled = false;
            
        }


        private void ntbCountQty_Enter(object sender, EventArgs e)
        {
            this.cmdAddCountLine.Enabled = true;
        }
        
        private void ntbCountQty_Leave(object sender, EventArgs e)
        {
            if (this.ntbCountQty.Amount != "")
            {
                this.cmdAddCountLine.Enabled = true;
            }
            else
            {
                this.cmdAddCountLine.Enabled = true;
            }
        }


        private void cmbDetailCountOtherUOM_SelectedIndexChanged
            (object sender, EventArgs e)
        {
            if (this.cmbDetailCountOtherUOM.Items.Count <= 0)
                return;

            if (this.cmbDetailCountOtherUOM.SelectedIndex ==
                this.intDetailCountPrdPreviousUnitIndex)
                return;

            DataTable dtProductInfo =
                this.getDatafromDataBase.getM_PRODUCTInfo(null, "",
                    this.ddgProduct.SelectedRowKey.ToString(), "", "", "", "", "", "", "",
                     triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);
            if (dtProductInfo.Rows.Count <= 0)
                return;

            string stSTDUnitId = dtProductInfo.Rows[0]["M_UOM_ID"].ToString();
            decimal dcMultiplier = 1;

            if (this.cmbDetailCountOtherUOM.SelectedIndex != 0)
            {
                if (stSTDUnitId ==
                    this.dtDetailCountItemAlternateUnit.
                        Rows[this.cmbDetailCountOtherUOM.SelectedIndex - 1]["M_BASE_UOM_ID"].ToString())
                {
                    stSTDUnitId =
                        this.dtDetailCountItemAlternateUnit.
                        Rows[this.cmbDetailCountOtherUOM.SelectedIndex - 1]["M_DRIVED_UOM_ID"].ToString();
                }
                else
                {
                    stSTDUnitId =
                        this.dtDetailCountItemAlternateUnit.
                        Rows[this.cmbDetailCountOtherUOM.SelectedIndex - 1]["M_BASE_UOM_ID"].ToString();
                }
            }

            if (this.cmbDetailCountOtherUOM.SelectedIndex != 0)
            {
                if (this.intDetailCountPrdPreviousUnitIndex == 0)
                {
                    if (dtProductInfo.Rows[0]["M_UOM_ID"].ToString() ==
                        this.dtDetailCountItemAlternateUnit.
                            Rows[this.cmbDetailCountOtherUOM.SelectedIndex - 1]["M_BASE_UOM_ID"].ToString())
                    {
                        dcMultiplier *=
                            decimal.Parse(this.dtDetailCountItemAlternateUnit.
                                            Rows[this.cmbDetailCountOtherUOM.SelectedIndex - 1]
                                                        ["MULTIPLIER"].ToString());
                    }
                    else
                    {
                        dcMultiplier /=
                            decimal.Parse(this.dtDetailCountItemAlternateUnit.
                                            Rows[this.cmbDetailCountOtherUOM.SelectedIndex - 1]
                                                        ["MULTIPLIER"].ToString());
                    }
                }
                else
                {
                    if (dtProductInfo.Rows[0]["M_UOM_ID"].ToString() ==
                        this.dtDetailCountItemAlternateUnit.
                            Rows[this.intDetailCountPrdPreviousUnitIndex - 1]["M_BASE_UOM_ID"].ToString())
                    {
                        dcMultiplier /=
                            decimal.Parse(this.dtDetailCountItemAlternateUnit.
                                            Rows[this.intDetailCountPrdPreviousUnitIndex - 1]
                                                        ["MULTIPLIER"].ToString());
                    }
                    else
                    {
                        dcMultiplier *=
                            decimal.Parse(this.dtDetailCountItemAlternateUnit.
                                            Rows[this.intDetailCountPrdPreviousUnitIndex - 1]
                                                        ["MULTIPLIER"].ToString());
                    }

                    if (dtProductInfo.Rows[0]["M_UOM_ID"].ToString() ==
                        this.dtDetailCountItemAlternateUnit.
                            Rows[this.cmbDetailCountOtherUOM.SelectedIndex - 1]["M_BASE_UOM_ID"].ToString())
                    {
                        dcMultiplier *=
                            decimal.Parse(this.dtDetailCountItemAlternateUnit.
                                            Rows[this.cmbDetailCountOtherUOM.SelectedIndex - 1]
                                                        ["MULTIPLIER"].ToString());
                    }
                    else
                    {
                        dcMultiplier /=
                            decimal.Parse(this.dtDetailCountItemAlternateUnit.
                                            Rows[this.cmbDetailCountOtherUOM.SelectedIndex - 1]
                                                        ["MULTIPLIER"].ToString());
                    }
                }
            }
            else if (this.intDetailCountPrdPreviousUnitIndex > 0)
            {
                if (dtProductInfo.Rows[0]["M_UOM_ID"].ToString() ==
                        this.dtDetailCountItemAlternateUnit.
                            Rows[this.intDetailCountPrdPreviousUnitIndex - 1]["M_BASE_UOM_ID"].ToString())
                {
                    dcMultiplier /=
                        decimal.Parse(this.dtDetailCountItemAlternateUnit.
                                        Rows[this.intDetailCountPrdPreviousUnitIndex - 1]
                                                    ["MULTIPLIER"].ToString());
                }
                else
                {
                    dcMultiplier *=
                        decimal.Parse(this.dtDetailCountItemAlternateUnit.
                                        Rows[this.intDetailCountPrdPreviousUnitIndex - 1]
                                                    ["MULTIPLIER"].ToString());
                }
            }

            DataTable dtUnitInfo =
                    this.getDatafromDataBase.getM_UOMInfo(null, "",
                        stSTDUnitId, "", "", triStateBool.ignor, false, "AND");
            this.ntbCountQty.StandardPrecision =
                int.Parse(dtUnitInfo.Rows[0]["STDPRECISION"].ToString());


            this.ntbCountQty.Amount =
                (this.getDatafromDataBase.roundOff(
                            (decimal.Parse(this.ntbCountQty.Amount) * dcMultiplier),
                            uint.Parse(this.ntbCountQty.StandardPrecision.ToString()))).ToString();

            this.intDetailCountPrdPreviousUnitIndex =
                this.cmbDetailCountOtherUOM.SelectedIndex;
        }

        private void cmdDetailTrxProductImage_Click(object sender, EventArgs e)
        {
            this.ddgProduct.SelectedRow.Clear();
            generalResultInformation.selectedProductId = "";
            frmProductImage frmProductImageList = new frmProductImage();
            frmProductImageList.ShowDialog();
            if (generalResultInformation.selectedProductId == "")
            {
                this.ddgProduct.SelectedRowKey = null;
                this.ddgProduct.SelectedItem = "";
                this.intProductID = 0;
                this.ntbBookQty.Amount = "0";
                this.ntbCountQty.Amount = "0";
                this.ddgProduct.SelectedItem = "";
                this.ntbCountQty.Enabled = false;
            }
            else
            {
                DataTable dtProdcutInfo =
                    this.getDatafromDataBase.getM_PRODUCTInfo(null, "",
                                generalResultInformation.selectedProductId,
                                "", "", "", "", "", "", "", 
                                triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);

                this.ddgProduct.SelectedItem = dtProdcutInfo.Rows[0]["NAME"].ToString();
                this.intProductID = int.Parse(dtProdcutInfo.Rows[0]["M_PRODUCT_ID"].ToString());
                this.ddgProduct.SelectedRowKey = dtProdcutInfo.Rows[0]["M_PRODUCT_ID"];

                this.ntbCountQty.Enabled = true;
                DataTable dtStockInfo = 
                    this.getDatafromDataBase.getQ_STOCKInfo(null, "", this.intProductID.ToString(),
                                this.intCountedStoreID.ToString(), triStateBool.ignor, false, "AND");
                if (this.getDatafromDataBase.checkIfTableContainesData(dtStockInfo))
                {
                    this.ntbBookQty.Amount =
                        dtStockInfo.Rows[0]["CURRENTQTY"].ToString();
                }
                else
                    this.ntbBookQty.Amount = "0";
            }
            this.fillDetailTrxItemUOMComboBox();
        }
         

        private void cmdAddCountLine_Click(object sender, EventArgs e)
        {
            if (this.intProductID.ToString() == "0" ||
                this.intProductID.ToString() == "" ||
                this.ntbCountQty.Amount == "")
            {
                return;
            }

            this.cmbDetailCountOtherUOM.SelectedIndex = 0;
            DataTable dtProductInfo =
                this.getDatafromDataBase.getM_PRODUCTInfo(null, "", 
                        this.intProductID.ToString(),
                        "", "", "", "", "", "", "", triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);

            if (dtProductInfo.Rows.Count != 1 || this.intProductID == 0)
            {
                goto finalLine;
            }
   
            
            if (this.cmdAddCountLine.Text.ToUpperInvariant() == "ADD")
            {
                DataRow drNewTentaiveCountDetail = this.dtTentativeCountDetail.NewRow();

                drNewTentaiveCountDetail["REMOVE"] = "remove";
                drNewTentaiveCountDetail["M_PRODUCT_ID"] = this.intProductID.ToString();
                drNewTentaiveCountDetail["LINE"] = this.dtTentativeCountDetail.Rows.Count + 1;
                drNewTentaiveCountDetail["NAME"] = this.ddgProduct.SelectedItem;
                drNewTentaiveCountDetail["Book Qty"] =
                    this.ntbBookQty.Amount;
                drNewTentaiveCountDetail["Count Qty"] =
                    this.ntbCountQty.Amount;
                drNewTentaiveCountDetail["UNIT"] =
                    this.cmbDetailCountOtherUOM.SelectedItem.ToString();

                DataTable dtUOMInfo =
                       this.getDatafromDataBase.getM_PRODUCTInfo(null, "", this.intProductID.ToString(),
                            "", "", "", "", "", "", "", 
                                    triStateBool.yes, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);
                if (this.getDatafromDataBase.checkIfTableContainesData(dtUOMInfo))
                {
                    drNewTentaiveCountDetail["M_UOM_ID"] =
                        dtUOMInfo.Rows[0]["M_UOM_ID"].ToString();
                }
                
                drNewTentaiveCountDetail["DESCRIPTION"] = this.txtCountLineDescription.Text;

                this.dtTentativeCountDetail.Rows.Add(drNewTentaiveCountDetail);
            }
            else if (this.cmdAddCountLine.Text.ToUpperInvariant() == "MODIFY")
            {
                if (this.dtgCountLineGridView.SelectedRows.Count < 1)
                {
                    goto finalLine;
                }
                int crrntSlctRwIndx =
                    this.dtgCountLineGridView.SelectedRows[0].Index;

                this.dtTentativeCountDetail.Rows[crrntSlctRwIndx]["REMOVE"] = "remove";
                this.dtTentativeCountDetail.Rows[crrntSlctRwIndx]["M_PRODUCT_ID"] =
                        this.intProductID.ToString();
                this.dtTentativeCountDetail.Rows[crrntSlctRwIndx]["NAME"] =
                        this.ddgProduct.SelectedItem;
                this.dtTentativeCountDetail.Rows[crrntSlctRwIndx]["Book Qty"] =
                        this.ntbBookQty.Value;
                this.dtTentativeCountDetail.Rows[crrntSlctRwIndx]["Count Qty"] =
                        this.ntbCountQty.Value;
                this.dtTentativeCountDetail.Rows[crrntSlctRwIndx]["Unit"] =
                    this.cmbDetailCountOtherUOM.SelectedItem.ToString();

                DataTable dtUOMInfo =
                       this.getDatafromDataBase.getM_PRODUCTInfo(null, "", this.intProductID.ToString(),
                            "", "", "", "", "", "", "", 
                                    triStateBool.yes, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);
                if (this.getDatafromDataBase.checkIfTableContainesData(dtUOMInfo))
                {
                    this.dtTentativeCountDetail.Rows[crrntSlctRwIndx]["M_UOM_ID"] =
                        dtUOMInfo.Rows[0]["M_UOM_ID"].ToString();
                }

                this.dtTentativeCountDetail.Rows[crrntSlctRwIndx]["DESCRIPTION"] =
                        this.txtCountLineDescription.Text;
            }
        finalLine:
            this.intDetailCountPrdPreviousUnitIndex = -1;

            this.cmdAddCountLine.Text = "ADD";
            this.cmdAddCountLine.Enabled = false;

            this.ddgProduct.SelectedRow.Clear();
            this.ddgProduct_selectedItemChanged(sender, e);

            this.ntbBookQty.Amount = "0";
            this.ntbCountQty.Amount = "0";
            this.cmbDetailCountOtherUOM.Items.Clear();
            this.txtCountLineDescription.Text = "";

            this.dtgCountLineGridView.BackgroundColor = 
                this.dtgCountGridView.BackgroundColor;

            if(this.dtgCountLineGridView.SelectedCells.Count > 0)
                this.dtgCountLineGridView.CurrentCell.Selected = false;
        }


        private void dtgCountLineGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgCountLineGridView.SelectedRows.Count < 1 ||
                this.blcurrentCountProcessed)
            {
                if (this.dtgCountLineGridView.SelectedCells.Count > 0) 
                    this.dtgCountLineGridView.CurrentCell.Selected = false;
                return;
            }

            int currentSelectedRowIndex =
                this.dtgCountLineGridView.SelectedRows[0].Index;
            if (this.dtgCountLineGridView.CurrentCell.OwningColumn.Index == 1 &&
                this.dtgCountLineGridView.CurrentCell.OwningColumn.Name == "REMOVE" &&
                this.dtgCountLineGridView.CurrentCell.Value.ToString() == "remove" &&
                this.dtgCountLineGridView.CurrentCell.OwningColumn.HeaderText == "")
            {
                string stCountDetailID =
                    this.dtTentativeCountDetail.
                        Rows[currentSelectedRowIndex]
                            ["T_PHYSICALCOUNTDETAIL_ID"].ToString();

                if (stCountDetailID != "" &&
                   this.intCountID > 0)
                {
                    DataTable dtCountDetailInfo =
                        this.getDatafromDataBase.getT_PHYSICALCOUNTDETAILInfo(null, "",
                                stCountDetailID, this.intCountID.ToString(),
                                "", new DateTime(), false, "",
                                triStateBool.ignor, false, "AND");

                    if (this.getDatafromDataBase.
                            checkIfTableContainesData(dtCountDetailInfo))
                    {
                        this.getDatafromDataBase.
                                changeDataBaseTableData(dtCountDetailInfo,
                                    "T_PHYSICALCOUNTDETAIL", "DELETE");
                    }
                }

                this.dtTentativeCountDetail.Rows.RemoveAt(currentSelectedRowIndex);
                for (int detailRowCounter = 0;
                    detailRowCounter <= this.dtTentativeCountDetail.Rows.Count - 1; detailRowCounter++)
                {
                    this.dtTentativeCountDetail.Rows[detailRowCounter]["LINE"] = detailRowCounter + 1;
                }
            }
            else
            {
                this.cmdAddCountLine.Text = "Modify";

                this.intProductID =
                    int.Parse(this.dtTentativeCountDetail.Rows[currentSelectedRowIndex]
                                                                ["M_PRODUCT_ID"].ToString());

                this.ddgProduct.SelectedRowKey =
                    this.dtTentativeCountDetail.Rows[currentSelectedRowIndex]
                                                        ["M_PRODUCT_ID"].ToString();
                this.ddgProduct.SelectedItem =
                    this.dtTentativeCountDetail.Rows[currentSelectedRowIndex]
                                                        ["NAME"].ToString();

                this.ntbBookQty.Amount =
                    this.dtTentativeCountDetail.Rows[currentSelectedRowIndex]
                                                        ["Book Qty"].ToString();

                this.ntbCountQty.Amount =
                    this.dtTentativeCountDetail.Rows[currentSelectedRowIndex]
                                                        ["Count Qty"].ToString();
                this.fillDetailTrxItemUOMComboBox();

                this.txtCountLineDescription.Text =
                    this.dtTentativeCountDetail.Rows[currentSelectedRowIndex]
                                                        ["DESCRIPTION"].ToString();                

                this.cmdAddCountLine.Enabled = true;
                this.ntbCountQty.Enabled = true;                
            }
        }
                
        private void dtgCountGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            if (this.dtgCountGridView.SelectedRows.Count < 1)
            {
                return;
            }

            int currentSelectedRowIndex =
                this.dtgCountGridView.SelectedRows[0].Index;

            this.intCountID =
                int.Parse(this.dtgCountGridView.Rows[currentSelectedRowIndex].
                        Cells["T_PHYSICALCOUNT_ID"].Value.ToString());

            
            this.stOrganisationID =
                this.dtgCountGridView.Rows[currentSelectedRowIndex].
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
                if (this.dtgCountGridView.Rows[currentSelectedRowIndex].
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

            this.txtDocumentNo.Text =
                this.dtgCountGridView.Rows[currentSelectedRowIndex].
                        Cells["DOCUMENTNO"].Value.ToString();

            this.dtpCountDate.Value =
                DateTime.Parse(this.dtgCountGridView.Rows[currentSelectedRowIndex].
                        Cells["COUNTDATE"].Value.ToString());

            this.txtDescription.Text =
                this.dtgCountGridView.Rows[currentSelectedRowIndex].
                        Cells["DESCRIPTION"].Value.ToString();
            
            this.cmbCountStore.Text = 
                    this.dtgCountGridView.Rows[currentSelectedRowIndex].
                        Cells["STORE"].Value.ToString();

            this.intCountedStoreID =
                int.Parse(this.dtgCountGridView.Rows[currentSelectedRowIndex].
                        Cells["M_WAREHOUSE_ID"].Value.ToString());
            
            if (this.dtgCountGridView.Rows[currentSelectedRowIndex].
                        Cells["PROCESSED"].Value.ToString() == "Y")
                this.blcurrentCountProcessed = true;
            else
                this.blcurrentCountProcessed = false;
            
                        
            DataTable dtCountDetailInformation =
                this.getDatafromDataBase.getT_PHYSICALCOUNTDETAILInfo(null, "", "",
                    this.intCountID.ToString(), "", new DateTime(), false,"", triStateBool.ignor,
                    false, "AND");

            this.enableDisableFormElement();
            this.dtTentativeCountDetail.Rows.Clear();

            for (int rowCounter = 0;
                rowCounter <= dtCountDetailInformation.Rows.Count - 1;
                rowCounter++)
            {
                DataRow drExistingCountDetailRow =
                    this.dtTentativeCountDetail.NewRow();

                drExistingCountDetailRow["T_PHYSICALCOUNTDETAIL_ID"] =
                    dtCountDetailInformation.Rows[rowCounter]["T_PHYSICALCOUNTDETAIL_ID"].ToString();
                drExistingCountDetailRow["T_PHYSICALCOUNT_ID"] =
                    dtCountDetailInformation.Rows[rowCounter]["T_PHYSICALCOUNT_ID"].ToString();

                drExistingCountDetailRow["REMOVE"] = "remove";
                drExistingCountDetailRow["LINE"] =
                    dtCountDetailInformation.Rows[rowCounter]["LINE"].ToString();
                drExistingCountDetailRow["M_PRODUCT_ID"] =
                    dtCountDetailInformation.Rows[rowCounter]["M_PRODUCT_ID"].ToString();

                DataTable dtPrdInfo =
                    this.getDatafromDataBase.getM_PRODUCTInfo(null, "",
                            dtCountDetailInformation.Rows[rowCounter]["M_PRODUCT_ID"].ToString(),
                            "", "", "", "", "", "", "", 
                            triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);

                if (dtPrdInfo.Rows.Count > 0)
                {
                    drExistingCountDetailRow["NAME"] =
                        dtPrdInfo.Rows[0]["NAME"].ToString();
                }

                drExistingCountDetailRow["Book Qty"] =
                    dtCountDetailInformation.Rows[rowCounter]["BOOKQUANTITY"].ToString();

                drExistingCountDetailRow["Count Qty"] =
                    dtCountDetailInformation.Rows[rowCounter]["COUNTQUANTITY"].ToString();

                DataTable dtUnitInfo =
                    this.getDatafromDataBase.getM_UOMInfo(null, "",
                            dtCountDetailInformation.Rows[rowCounter]["M_UOM_ID"].ToString(),
                                "", "", triStateBool.ignor, false, "AND");

                if (dtUnitInfo.Rows.Count > 0)
                {
                    drExistingCountDetailRow["UNIT"] =
                        dtUnitInfo.Rows[0]["ABBREVATION"].ToString();
                }

                drExistingCountDetailRow["M_UOM_ID"] =
                    dtCountDetailInformation.Rows[rowCounter]["M_UOM_ID"].ToString();
                
                drExistingCountDetailRow["DESCRIPTION"] =
                    dtCountDetailInformation.Rows[rowCounter]["DESCRIPTION"].ToString();

                this.dtTentativeCountDetail.Rows.Add(drExistingCountDetailRow);
            }
            
            this.dtgCountLineGridView.DataSource = this.dtTentativeCountDetail;
        }


        private void cmdCreateInventoryCount_Click(object sender, EventArgs e)
        {
            if (this.intCountedStoreID == -1)
            {
                this.cmdCreateInventoryCount.Enabled = false;
                return;
            }
            DataTable currentStoreStockCount =
                this.getDatafromDataBase.getQ_STOCKInfo(null, 
                    "", "", this.intCountedStoreID.ToString(), triStateBool.ignor, 
                    false, "AND");
            
            int countLineIndex = -1;

            DataTable dtUOMInfo = new DataTable();
            DataTable productName = new DataTable();

            for (int rowCounter = 0; 
                    rowCounter <= currentStoreStockCount.Rows.Count - 1; 
                    rowCounter++)
            {                
                countLineIndex = -1;
                
                for (int exitingCountLineCounter = 0;
                    exitingCountLineCounter <= this.dtTentativeCountDetail.Rows.Count - 1; 
                    exitingCountLineCounter++)
                {
                    if (currentStoreStockCount.Rows[rowCounter]["M_PRODUCT_ID"].ToString() ==
                        this.dtTentativeCountDetail.Rows[exitingCountLineCounter]["M_PRODUCT_ID"].ToString())
                    {
                        countLineIndex = exitingCountLineCounter;
                        break;
                    }
                }

                if (countLineIndex != -1)
                {                    
                    continue;
                }

                DataRow drNewTentaiveCountDetail = 
                    this.dtTentativeCountDetail.NewRow();

                drNewTentaiveCountDetail["REMOVE"] = "remove";
                drNewTentaiveCountDetail["M_PRODUCT_ID"] =
                    currentStoreStockCount.Rows[rowCounter]["M_PRODUCT_ID"].ToString();

                drNewTentaiveCountDetail["LINE"] =
                    this.dtTentativeCountDetail.Rows.Count + 1;
                                
                productName = 
                    this.getDatafromDataBase.getM_PRODUCTInfo(null,"",
                        currentStoreStockCount.Rows[rowCounter]["M_PRODUCT_ID"].ToString(),"","","","",
                            "","","", triStateBool.ignor,false,"AND",generalResultInformation.dbBulkDataRetrivalSize);

                drNewTentaiveCountDetail["DESCRIPTION"] = "";

                if (this.getDatafromDataBase.checkIfTableContainesData(productName))
                {
                    drNewTentaiveCountDetail["NAME"] =
                        productName.Rows[0]["NAME"].ToString();
                    drNewTentaiveCountDetail["M_UOM_ID"] =
                        productName.Rows[0]["M_UOM_ID"].ToString();

                    dtUOMInfo = this.getDatafromDataBase.getM_UOMInfo(null, "",
                                           productName.Rows[0]["M_UOM_ID"].ToString(), "", "",
                                           triStateBool.ignor, false, "AND");

                }
                else
                {
                    drNewTentaiveCountDetail["NAME"] =
                        "Name Not Found Pls Contact Admin";
                    drNewTentaiveCountDetail["M_UOM_ID"] = "0";
                    drNewTentaiveCountDetail["DESCRIPTION"] =
                        "Name Not Found Pls Contact Admin";

                    dtUOMInfo.Clear();
                }

                

                if (this.getDatafromDataBase.checkIfTableContainesData(dtUOMInfo))
                {
                    drNewTentaiveCountDetail["UNIT"] =
                        dtUOMInfo.Rows[0]["ABBREVATION"].ToString();
                }
                else
                {
                    drNewTentaiveCountDetail["UNIT"] = "NA";
                }


                drNewTentaiveCountDetail["Book Qty"] =
                    currentStoreStockCount.Rows[rowCounter]["CURRENTQTY"].ToString();
                drNewTentaiveCountDetail["Count Qty"] =
                    currentStoreStockCount.Rows[rowCounter]["CURRENTQTY"].ToString();

                this.dtTentativeCountDetail.Rows.Add(drNewTentaiveCountDetail);
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

        private void tlsPrint_Click(object sender, EventArgs e)
        {
            if (this.intCountID <= 0)
                return;

            if (!System.IO.File.Exists("crptPhysicalCount.rpt"))
            {
                MessageBox.Show("Unable To find Report Builder. \n Please Contact Your Administrator.",
                    "Printing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmPrintViewer newPrintJobView = new frmPrintViewer();

            string fileName = "crptPhysicalCount.rpt";
            dtsPOSDocumentData dsNewCount = new dtsPOSDocumentData();

            dsNewCount.Tables["dtCountSummary"].Clear();
            dsNewCount.Tables["dtCountDetail"].Clear();


            DataTable dtV_CountDetail =
                this.getDatafromDataBase.getV_PHYSICALCOUNTDETAILInfo(null, "",
                                this.intCountID.ToString(), "", "", "", "", "", "",
                                new DateTime(), false, triStateBool.ignor, triStateBool.ignor,
                                transactionStatus.ignor, false, "AND");

            if (!this.getDatafromDataBase.checkIfTableContainesData(dtV_CountDetail))
            {
                MessageBox.Show("Unable To Build Report Data. \n Please Contact Your Administrator.",
                    "Printing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRow drNewCount =
                dsNewCount.Tables["dtCountSummary"].NewRow();

            drNewCount["CountId"] =
                int.Parse(dtV_CountDetail.Rows[0]["T_PHYSICALCOUNT_ID"].ToString());
            drNewCount["DocumentName"] = "Inventory Count";
            drNewCount["Store"] =
                dtV_CountDetail.Rows[0]["WAREHOUSE"].ToString();                        
            drNewCount["DocumentNumber"] =
                dtV_CountDetail.Rows[0]["DOCUMENTNO"].ToString();
            drNewCount["DocumentDate"] =
                DateTime.Parse(dtV_CountDetail.Rows[0]["COUNTDATE"].ToString()).ToString("MMM-dd-yyyy");
            drNewCount["DocumentNote"] =
                dtV_CountDetail.Rows[0]["DESCRIPTION"].ToString();

            drNewCount["PreparedBy"] = "";
            drNewCount["CheckdBy"] = "";
            drNewCount["ApprovedBy"] = "";
            drNewCount["rePrint"] = "";

            dsNewCount.Tables["dtCountSummary"].Rows.Add(drNewCount);

            for (int countDetailCounter = 0;
                 countDetailCounter <=
                    dtV_CountDetail.Rows.Count - 1;
                 countDetailCounter++)
            {
                DataRow drNewCountDetail =
                    dsNewCount.Tables["dtCountDetail"].NewRow();

                drNewCountDetail["CountDetailId"] =
                    int.Parse(dtV_CountDetail.
                        Rows[countDetailCounter]["T_PHYSICALCOUNTDETAIL_ID"].ToString());
                drNewCountDetail["CountId"] =
                    int.Parse(dtV_CountDetail.
                        Rows[countDetailCounter]["T_PHYSICALCOUNT_ID"].ToString());
                drNewCountDetail["Sn."] =
                    dtV_CountDetail.
                        Rows[countDetailCounter]["LINE"].ToString();
                drNewCountDetail["Description"] =
                    dtV_CountDetail.
                        Rows[countDetailCounter]["PRODUCT"].ToString();
                drNewCountDetail["Unit"] =
                    dtV_CountDetail.
                        Rows[countDetailCounter]["UOM"].ToString();
                drNewCountDetail["Book Qty"] =
                    decimal.Parse(dtV_CountDetail.
                        Rows[countDetailCounter]["BOOKQUANTITY"].ToString());
                drNewCountDetail["Count Qty"] =
                    decimal.Parse(dtV_CountDetail.
                        Rows[countDetailCounter]["COUNTQUANTITY"].ToString());
                drNewCountDetail["Remark"] = "";
                drNewCountDetail["comment"] =
                    dtV_CountDetail.
                        Rows[countDetailCounter]["LINE_DESCRIPTION"].ToString();

                drNewCountDetail["CODE"] =
                    dtV_CountDetail.
                        Rows[countDetailCounter]["CODE"].ToString();
                drNewCountDetail["CODE2"] =
                    dtV_CountDetail.
                        Rows[countDetailCounter]["CODE2"].ToString();
                drNewCountDetail["BAR"] = "*" + 
                    dtV_CountDetail.
                        Rows[countDetailCounter]["BAR"].ToString() + "*";

                dsNewCount.Tables["dtCountDetail"].Rows.Add(drNewCountDetail);
            }

            newPrintJobView.setUpThePreviewArea(fileName, dsNewCount);

            newPrintJobView.ShowDialog(this);

        }

        private void dtgCountLineGridView_Sorted(object sender, EventArgs e)
        {
            if (this.dtgCountLineGridView.SelectedRows.Count > 0)
            {
                this.intDetailCountPrdPreviousUnitIndex = -1;

                this.cmdAddCountLine.Text = "ADD";
                this.cmdAddCountLine.Enabled = false;

                this.ddgProduct.SelectedRow.Clear();
                this.ddgProduct_selectedItemChanged(sender, e);

                this.ntbBookQty.Amount = "0";
                this.ntbCountQty.Amount = "0";
                this.cmbDetailCountOtherUOM.Items.Clear();
                this.txtCountLineDescription.Text = "";

                this.dtgCountLineGridView.BackgroundColor =
                    this.dtgCountGridView.BackgroundColor;                
            }
            if (this.dtgCountLineGridView.SelectedCells.Count > 0) 
                this.dtgCountLineGridView.CurrentCell.Selected = false;
        }
        
    }
}
