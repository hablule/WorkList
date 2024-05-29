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
    public partial class frmInternalUse : Panel
    {
        public frmInternalUse()
        {
            InitializeComponent();
        }

        string stringShopID = generalResultInformation.activeStation;
        string stOrganisationID = "";

        int intUsageID = -1;
        int intProductID = -1;
        int intUsedFromStoreID = -1;
        
        int intDetailUsagePrdPreviousUnitIndex = -1;

        bool blcurrentUsageProcessed = false;
        bool blCurrentRecordIsReadOnly = false;

        static private Color clNormalLableColor = Color.Black;
        static private Color clErrorLableColor = Color.Red;
        static private Color clChangedLableColor = Color.Blue;

        DataTable dtNewUsageInformation = new DataTable();
        DataTable dtNewDetailUsageInformation = new DataTable();
        DataTable dtExistingActiveProductInformation = new DataTable();
        DataTable dtUseFromAccActiveWarehouseInfo = new DataTable();

        DataTable dtAccessableOrgInformation = new DataTable();
        DataTable dtExistingUsageInformation = new DataTable();
        DataTable dtExistingDetailUsageInformation = new DataTable();
                
        DataTable dtDetailUsageItemAlternateUnit = new DataTable();

        DataTable dtAllUOMInformation = new DataTable();
        DataTable dtTentativeUsageDetail = new DataTable();

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
            DataTable dtUseInfo = this.getDatafromDataBase.getT_INVENTORYUSEInfo(null, "",
                    this.intUsageID.ToString(), "", "", new DateTime(),
                    false, triStateBool.ignor, triStateBool.yes,
                    transactionStatus.ignor, false, "AND");

            if (!this.getDatafromDataBase.checkIfTableContainesData(dtUseInfo))
                return false;

            string docStatus = dtUseInfo.Rows[0]["DOCSTATUS"].ToString();

            if (docStatus == "DR")
                return false;

            DataTable dtCurrentUseDetail =
                this.getDatafromDataBase.getT_INVENTORYUSEDETAILInfo(null, "", "",
                        this.intUsageID.ToString(), "", new DateTime(), false,
                        "", triStateBool.ignor, false, "AND");

            if (!this.getDatafromDataBase.checkIfTableContainesData(dtCurrentUseDetail))
                return false;

            DataTable dtNewMtransactionSummerizer =
                this.getDatafromDataBase.getM_TRANSACTIONInfo(null, "", "", "",
                        "", "", new DateTime(), false, "", "", "",
                        triStateBool.ignor, true, "AND");

            for (int rowCounter = 0; rowCounter <= dtCurrentUseDetail.Rows.Count - 1; rowCounter++)
            {
                DataRow drNewMtrxSummaryRow = dtNewMtransactionSummerizer.NewRow();

                drNewMtrxSummaryRow["M_SHOP_ID"] =
                    dtCurrentUseDetail.Rows[rowCounter]["M_SHOP_ID"].ToString();

                drNewMtrxSummaryRow["AD_ORG_ID"] =
                    dtCurrentUseDetail.Rows[rowCounter]["M_SHOP_ID"].ToString();
                
                drNewMtrxSummaryRow["MOVEMENTTYPE"] =
                    this.getDataAccordingToRule.getStringEquivelentOfMoveType(movementType.I_n);

                drNewMtrxSummaryRow["MOVEMENTQTY"] = -1 *
                    decimal.Parse(dtCurrentUseDetail.Rows[rowCounter]["USEDQUANTITY"].ToString());                

                if (docStatus == "RE")
                {
                    drNewMtrxSummaryRow["MOVEMENTQTY"] = -1 *
                        decimal.Parse(drNewMtrxSummaryRow["MOVEMENTQTY"].ToString());
                }

                drNewMtrxSummaryRow["M_LOCATOR_ID"] =
                    dtCurrentUseDetail.Rows[rowCounter]["M_WAREHOUSEFROM_ID"].ToString();

                drNewMtrxSummaryRow["M_PRODUCT_ID"] =
                    dtCurrentUseDetail.Rows[rowCounter]["M_PRODUCT_ID"].ToString();

                drNewMtrxSummaryRow["MOVEMENTDATE"] =
                    dtCurrentUseDetail.Rows[rowCounter]["USEDATE"].ToString();

                drNewMtrxSummaryRow["C_UOM_ID"] =
                    dtCurrentUseDetail.Rows[rowCounter]["M_UOM_ID"].ToString();

                drNewMtrxSummaryRow["T_INVENTORYUSEDETAIL_ID"] =
                    dtCurrentUseDetail.Rows[rowCounter]["T_INVENTORYUSEDETAIL_ID"].ToString();

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

            if (this.intUsedFromStoreID == -1)
            {
                this.lblUsedFrom.ForeColor = clErrorLableColor;
                foundError = true;
            }
            else
            {
                this.lblUsedFrom.ForeColor = clNormalLableColor;
            }
            
            if (this.dtTentativeUsageDetail.Rows.Count == 0)
            {
                this.dtgUsageLineGridView.BackgroundColor = clErrorLableColor;
                foundError = true;
            }
            else
            {
                this.dtgUsageLineGridView.BackgroundColor = 
                    this.dtgUsageGridView.BackgroundColor;
            }

            if (this.dtpUsedDate.Value == null)
            {
                this.lblUsedDate.ForeColor = clErrorLableColor;
                foundError = true;
            }
            else
            {
                this.lblUsedDate.ForeColor = clNormalLableColor;
            }            

            return foundError;
        }

        private void determinCurrentRecordReadOnlySatust()
        {
            if (this.intUsageID <= 0)
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
            if (this.intUsageID == -1)
                this.blcurrentUsageProcessed = false;

            if (!this.blcurrentUsageProcessed)
            {
                this.determinCurrentRecordReadOnlySatust();
                if (this.blCurrentRecordIsReadOnly)
                    this.blcurrentUsageProcessed = true;
            }

            this.cmbOrganisation.Enabled = !this.blcurrentUsageProcessed;
            this.txtDocumentNo.Enabled = !this.blcurrentUsageProcessed;

            this.ddgProduct.Enabled = !this.blcurrentUsageProcessed;
            this.ntbUsedQty.Enabled = !this.blcurrentUsageProcessed;
            this.cmbDetailUsageOtherUOM.Enabled = !this.blcurrentUsageProcessed;
            this.cmdAddUsageLine.Enabled = !this.blcurrentUsageProcessed;
            this.txtUsageLineDescription.Enabled = !this.blcurrentUsageProcessed;
            
            this.dtgUsageLineGridView.Columns["REMOVE"].Visible = 
                !this.blcurrentUsageProcessed;
            this.txtDescription.Enabled = !this.blcurrentUsageProcessed;
            if (this.dtgUsageGridView.SelectedRows.Count == 0)
                this.tlsDelete.Enabled = false;
            else if (this.dtgUsageGridView.Rows
                    [this.dtgUsageGridView.SelectedRows[0].Index].
                        Cells["PROCESSED"].Value.ToString().ToUpperInvariant() != "N")
                this.tlsDelete.Enabled = false;
            else
                this.tlsDelete.Enabled = true;

            this.tlsPrint.Enabled =
                !this.tlsDelete.Enabled && this.blcurrentUsageProcessed;

            this.cmbUsedFrom.Enabled = !this.blcurrentUsageProcessed;
            this.dtpUsedDate.Enabled = !this.blcurrentUsageProcessed;

            this.tlsSave.Enabled = !this.blcurrentUsageProcessed;
            this.tlsReverse.Enabled = this.blcurrentUsageProcessed;

            this.cmdDetailTrxProductImage.Enabled = !this.blcurrentUsageProcessed;
        }

        private void fillDetailTrxItemUOMComboBox()
        {
            this.cmbDetailUsageOtherUOM.Items.Clear();
            if (this.ddgProduct.SelectedRowKey == null)
                return;

            DataTable dtPrdInfo =
                this.getDatafromDataBase.getM_PRODUCTInfo(null, "",
                    this.ddgProduct.SelectedRowKey.ToString(), "", "", "", "", "",
                        "", "", triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);

            if (dtPrdInfo.Rows.Count <= 0)
                return;

            this.dtDetailUsageItemAlternateUnit =
                    this.getDatafromDataBase.getM_UOM_CONVERSIONInfo(null, "",
                        dtPrdInfo.Rows[0]["M_UOM_ID"].ToString(),
                        dtPrdInfo.Rows[0]["M_UOM_ID"].ToString(),
                        "", 0, triStateBool.ignor, false, "OR");

            for (int rowCounter = this.dtDetailUsageItemAlternateUnit.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {

                if (this.dtDetailUsageItemAlternateUnit.
                        Rows[rowCounter]["ISACTIVE"].ToString() != "Y")
                {
                    this.dtDetailUsageItemAlternateUnit.Rows.RemoveAt(rowCounter);
                    continue;
                }

                if (this.dtDetailUsageItemAlternateUnit.
                            Rows[rowCounter]["M_PRODUCT_ID"].ToString() !=
                        this.ddgProduct.SelectedRowKey.ToString() &&
                        this.dtDetailUsageItemAlternateUnit.
                            Rows[rowCounter]["M_PRODUCT_ID"].ToString() != "" &&
                        this.dtDetailUsageItemAlternateUnit.
                            Rows[rowCounter]["M_PRODUCT_ID"].ToString() != "0"
                        )
                {
                    this.dtDetailUsageItemAlternateUnit.Rows.RemoveAt(rowCounter);
                    continue;
                }
            }


            for (int rowCounter = this.dtDetailUsageItemAlternateUnit.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                if (this.dtDetailUsageItemAlternateUnit.
                    Rows[rowCounter]["M_PRODUCT_ID"].ToString() == "" ||
                   this.dtDetailUsageItemAlternateUnit.
                    Rows[rowCounter]["M_PRODUCT_ID"].ToString() == "0")
                {
                    for (int rowCounter2 = this.dtDetailUsageItemAlternateUnit.Rows.Count - 1;
                          rowCounter2 >= 0; rowCounter2--)
                    {
                        if ((this.dtDetailUsageItemAlternateUnit.
                                Rows[rowCounter]["M_BASE_UOM_ID"].ToString() ==
                            this.dtDetailUsageItemAlternateUnit.
                                Rows[rowCounter2]["M_BASE_UOM_ID"].ToString() &&
                            this.dtDetailUsageItemAlternateUnit.
                                Rows[rowCounter]["M_DRIVED_UOM_ID"].ToString() ==
                            this.dtDetailUsageItemAlternateUnit.
                                Rows[rowCounter2]["M_DRIVED_UOM_ID"].ToString()) ||
                            (this.dtDetailUsageItemAlternateUnit.
                                Rows[rowCounter]["M_BASE_UOM_ID"].ToString() ==
                            this.dtDetailUsageItemAlternateUnit.
                                Rows[rowCounter2]["M_DRIVED_UOM_ID"].ToString() &&
                            this.dtDetailUsageItemAlternateUnit.
                                Rows[rowCounter]["M_BASE_UOM_ID"].ToString() ==
                            this.dtDetailUsageItemAlternateUnit.
                                Rows[rowCounter2]["M_DRIVED_UOM_ID"].ToString()))
                        {
                            this.dtDetailUsageItemAlternateUnit.Rows.RemoveAt(rowCounter);
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
                this.cmbDetailUsageOtherUOM.Items.Insert
                    (this.cmbDetailUsageOtherUOM.Items.Count,
                     dtUnitInfo.Rows[0]["ABBREVATION"].ToString()
                    );
                this.cmbDetailUsageOtherUOM.SelectedIndex = 0;
            }

            for (int rowCounter = 0; rowCounter <= this.dtDetailUsageItemAlternateUnit.Rows.Count - 1;
                rowCounter++)
            {

                string stUnitId = "";

                if (this.dtDetailUsageItemAlternateUnit.
                        Rows[rowCounter]["M_BASE_UOM_ID"].ToString() ==
                    dtPrdInfo.Rows[0]["M_UOM_ID"].ToString())
                    stUnitId =
                        this.dtDetailUsageItemAlternateUnit.Rows[rowCounter]["M_DRIVED_UOM_ID"].ToString();
                else
                    stUnitId =
                        this.dtDetailUsageItemAlternateUnit.Rows[rowCounter]["M_BASE_UOM_ID"].ToString();

                dtUnitInfo =
                    this.getDatafromDataBase.getM_UOMInfo(null, "",
                        stUnitId, "", "", triStateBool.ignor, false, "AND");
                if (dtUnitInfo.Rows.Count > 0)
                {
                    this.cmbDetailUsageOtherUOM.Items.Insert
                        (this.cmbDetailUsageOtherUOM.Items.Count,
                         dtUnitInfo.Rows[0]["ABBREVATION"].ToString()
                        );
                }
            }
        }

        private void convertItemInfoToStandardUnit()
        {
            if (this.cmbDetailUsageOtherUOM.SelectedIndex == 0)
                return;
            int intSelectedUnitIndex = 
                this.cmbDetailUsageOtherUOM.SelectedIndex - 1;

            decimal dcMultiplier =
                decimal.Parse(this.dtDetailUsageItemAlternateUnit.
                    Rows[intSelectedUnitIndex]["MULTIPLIER"].ToString());
            ctlNumberTextBox converter = new ctlNumberTextBox();
            converter.Amount = dcMultiplier.ToString();
            dcMultiplier = decimal.Parse(converter.Amount);

            if (this.ddgProduct.SelectedRow.Rows[0]["M_UOM_ID"].ToString() ==
                this.dtDetailUsageItemAlternateUnit.
                    Rows[intSelectedUnitIndex]["M_DRIVED_UOM_ID"].ToString())
            {
                this.ntbUsedQty.Amount =
                    (decimal.Parse(this.ntbUsedQty.Amount) *
                        dcMultiplier).ToString();              
            }
            else
            {
                this.ntbUsedQty.Amount =
                    (decimal.Parse(this.ntbUsedQty.Amount) /
                        dcMultiplier).ToString();
            }

            this.cmbDetailUsageOtherUOM.SelectedIndex = 0;
        }
                
        private string getNextDocumentNumber()
        {
            string stNextSequenceNo = "";
            string stDOCBASETYPE = "";

            DataTable dtSequenceInfo = new DataTable();
            
            stDOCBASETYPE = "USE";            

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
            this.dtgUsageLineGridView.Columns["M_SHOP_ID"].Visible = false;
            this.dtgUsageLineGridView.Columns["AD_ORG_ID"].Visible = false;
            this.dtgUsageLineGridView.Columns["M_PRODUCT_ID"].Visible = false;
            this.dtgUsageLineGridView.Columns["M_UOM_ID"].Visible = false;
            this.dtgUsageLineGridView.Columns["DESCRIPTION"].Visible = false;
            this.dtgUsageLineGridView.Columns["T_INVENTORYUSE_ID"].Visible = false;
            this.dtgUsageLineGridView.Columns["T_INVENTORYUSEDETAIL_ID"].Visible = false;
            this.dtgUsageLineGridView.Columns["M_WAREHOUSEFROM_ID"].Visible = false; 
        }

        private void hidColumnsInMainGridView()
        {
            this.dtgUsageGridView.Columns["M_SHOP_ID"].Visible = false;
            this.dtgUsageGridView.Columns["AD_ORG_ID"].Visible = false;
            this.dtgUsageGridView.Columns["T_INVENTORYUSE_ID"].Visible = false;
            this.dtgUsageGridView.Columns["M_WAREHOUSEFROM_ID"].Visible = false;    
        }



        public void frmInternalUse_Load(object sender, EventArgs e)
        {
            this.setUpOrganisations();
            
            if (generalResultInformation.currentFormIsReadOnly)
            {
                this.tlsDelete.Visible = false;
                this.tlsNew.Visible = false;
                this.tlsSave.Visible = false;
                this.cmdAddUsageLine.Visible = false;
            }
            
            this.dtExistingActiveProductInformation =
                this.getDatafromDataBase.getM_PRODUCTInfo(null, "", "",
                        "", "", "", "", "", "", "", 
                                triStateBool.yes, true, "AND",generalResultInformation.dbBulkDataRetrivalSize);

            this.dtUseFromAccActiveWarehouseInfo =
                this.getDataAccordingToRule.getCurrentUserAccessableWarehouse(triStateBool.ignor, 
                                    triStateBool.ignor, triStateBool.ignor, triStateBool.ignor,
                                    triStateBool.ignor, triStateBool.yes, triStateBool.ignor,
                                    triStateBool.yes, "AND");

            this.cmbUsedFrom.Items.Add(" - Select Store - ");
            for (int rowCounter = 0;
                 rowCounter <= this.dtUseFromAccActiveWarehouseInfo.Rows.Count - 1;
                 rowCounter++)
            {
                this.cmbUsedFrom.Items.Add(
                    this.dtUseFromAccActiveWarehouseInfo.Rows[rowCounter]["NAME"].ToString());
            }

            this.cmbUsedFrom.SelectedIndex = 0;
                
            
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

            this.dtTentativeUsageDetail.Columns.Add("M_SHOP_ID");
            this.dtTentativeUsageDetail.Columns.Add("AD_ORG_ID");
            this.dtTentativeUsageDetail.Columns.Add("M_PRODUCT_ID");
            this.dtTentativeUsageDetail.Columns.Add("REMOVE");
            this.dtTentativeUsageDetail.Columns.Add("LINE",typeof(Int16));
            this.dtTentativeUsageDetail.Columns.Add("NAME");
            this.dtTentativeUsageDetail.Columns.Add("Used Qty");
            this.dtTentativeUsageDetail.Columns.Add("Unit");
            this.dtTentativeUsageDetail.Columns.Add("M_UOM_ID");
            this.dtTentativeUsageDetail.Columns.Add("M_WAREHOUSEFROM_ID");                       
            this.dtTentativeUsageDetail.Columns.Add("DESCRIPTION");
            this.dtTentativeUsageDetail.Columns.Add("T_INVENTORYUSE_ID");
            this.dtTentativeUsageDetail.Columns.Add("T_INVENTORYUSEDETAIL_ID");

            this.dtTentativeUsageDetail.Columns["REMOVE"].SetOrdinal(1);

            this.dtgUsageLineGridView.DataSource = this.dtTentativeUsageDetail;

            this.dtgUsageLineGridView.Columns["LINE"].HeaderText = "SN";

            this.dtgUsageLineGridView.Columns["REMOVE"].HeaderText = "";
            this.dtgUsageLineGridView.Columns["REMOVE"].DefaultCellStyle = this.cancelButtonStyle;

            this.dtExistingUsageInformation.Columns.Add("M_SHOP_ID");
            this.dtExistingUsageInformation.Columns.Add("AD_ORG_ID");
            this.dtExistingUsageInformation.Columns.Add("T_INVENTORYUSE_ID");
            this.dtExistingUsageInformation.Columns.Add("DOCUMENTNO");
            this.dtExistingUsageInformation.Columns.Add("DESCRIPTION");
            this.dtExistingUsageInformation.Columns.Add("USEDATE");
            this.dtExistingUsageInformation.Columns.Add("M_WAREHOUSEFROM_ID");
            this.dtExistingUsageInformation.Columns.Add("STORE FROM");            
            this.dtExistingUsageInformation.Columns.Add("PROCESSED");
            this.dtExistingUsageInformation.Columns.Add("DOCSTATUS");

            this.dtgUsageGridView.DataSource = 
                this.dtExistingUsageInformation;                    

            this.tlsNew_Click(sender, e);

            this.hidColumnsInMainGridView();
            this.hidColumnsInDetailGriedView();

        }


        private void tlsNew_Click(object sender, EventArgs e)
        {
            this.blcurrentUsageProcessed = false;
            this.enableDisableFormElement();

            this.cmbUsedFrom.SelectedIndex = 0;
            this.intUsageID = -1;            
            this.intDetailUsagePrdPreviousUnitIndex = -1;
            this.intUsedFromStoreID = -1;            

            this.txtDocumentNo.Text = 
                this.getNextDocumentNumber();
            this.txtDescription.Text = "";
            this.dtpUsedDate.Value = DateTime.Today;
            

            this.ddgProduct.SelectedItem = "";
            this.ddgProduct.SelectedRow.Clear();
            this.ddgProduct.SelectedRowKey = null;
            this.ddgProduct_selectedItemChanged(sender, e);

            this.ntbUsedQty.Amount = "0";
            
            this.cmbDetailUsageOtherUOM.Items.Clear();
            this.txtUsageLineDescription.Text = "";
            
            this.dtNewDetailUsageInformation.Clear();
            this.dtNewUsageInformation.Clear();

            this.dtTentativeUsageDetail.Rows.Clear();

            this.cmdAddUsageLine.Enabled = false;

            this.lblDocumentNo.ForeColor = clNormalLableColor;
            this.lblUsedFrom.ForeColor = clNormalLableColor;            
            this.dtgUsageLineGridView.BackgroundColor =
                this.dtgUsageGridView.BackgroundColor;
            this.lblUsedDate.ForeColor = clNormalLableColor;
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

            bool foundUnderStockInventory = false;
            for (int rowCounter = 0;
                rowCounter < this.dtTentativeUsageDetail.Rows.Count; rowCounter++)
            {
                DataTable stockQuanity =
                    this.getDatafromDataBase.getQ_STOCKInfo(null, "",
                            this.dtTentativeUsageDetail.Rows[rowCounter]["M_PRODUCT_ID"].ToString(),
                            this.intUsedFromStoreID.ToString(), triStateBool.ignor, false, "AND");
                if (stockQuanity.Rows.Count > 0)
                {
                    if (decimal.Parse(this.dtTentativeUsageDetail.Rows[rowCounter]["Used Qty"].ToString()) >
                        decimal.Parse(stockQuanity.Rows[0]["CURRENTQTY"].ToString()))
                    {
                        foundUnderStockInventory = true;
                        this.dtgUsageLineGridView.Rows[rowCounter].DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        this.dtgUsageLineGridView.Rows[rowCounter].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
                else
                {
                    foundUnderStockInventory = true;
                    this.dtgUsageLineGridView.Rows[rowCounter].DefaultCellStyle.ForeColor = Color.Red;
                }
            }

            if (foundUnderStockInventory)
            {
                DataTable dtWarehouseInfo =
                        this.getDatafromDataBase.getM_WarehouseInfo(null, "",
                                this.intUsedFromStoreID.ToString(), "", triStateBool.yes,
                                triStateBool.ignor, false, "AND");
                if (!this.getDatafromDataBase.checkIfTableContainesData(dtWarehouseInfo))
                {
                    MessageBox.Show("No sufficient stock Exist ", "SRP STOCK", MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                    return;
                }

                if (MessageBox.Show("There are under/insfficient Stock Items. \n Would you Like to Revise your Usage",
                                "SRP PROCESS", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    return;
            }

            DialogResult result =
                MessageBox.Show("Would you Like to Complete the Usage",
                                "SRP PROCESS", MessageBoxButtons.YesNoCancel,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            if (result == DialogResult.Cancel)
                return;
            
            this.dtNewUsageInformation =
                this.getDatafromDataBase.getT_INVENTORYUSEInfo(null, "",
                        "", "", "", new DateTime(), false, triStateBool.ignor,
                        triStateBool.ignor, transactionStatus.ignor, true, "");

            DataRow drNewUsage = this.dtNewUsageInformation.NewRow();

            if (this.intUsageID != -1)
            {
                stTypeOfChange = "UPDATE";
                drNewUsage["T_INVENTORYUSE_ID"] = this.intUsageID.ToString();
            }
            else
            {
                stTypeOfChange = "INSERT";
            }

            string stDocNumber = "";
            if (this.intUsageID == -1 && this.txtDocumentNo.Text.StartsWith("<") &&
                this.txtDocumentNo.Text.EndsWith(">"))
            {
                DataTable dtSequenceInfo = new DataTable();

                string stDOCBASETYPE = "USE";
                
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
            
            drNewUsage["M_SHOP_ID"] = this.stringShopID;
            drNewUsage["AD_ORG_ID"] = this.stOrganisationID;
            drNewUsage["DOCUMENTNO"] = stDocNumber;
            drNewUsage["DESCRIPTION"] = this.txtDescription.Text;
            drNewUsage["USEDATE"] = this.dtpUsedDate.Value;
            drNewUsage["M_WAREHOUSEFROM_ID"] = this.intUsedFromStoreID.ToString();            
            
            if (result == DialogResult.Yes)
                drNewUsage["PROCESSED"] = "Y";
            else
                drNewUsage["PROCESSED"] = "N";

            if (result == DialogResult.No)
                drNewUsage["DOCSTATUS"] = "DR";
            else if (result == DialogResult.Yes)
                drNewUsage["DOCSTATUS"] = "CO";

            this.dtNewUsageInformation.Rows.Add(drNewUsage);

            string[] primaryKeySepartor = { " <(", ")>||" };
            string[] primaryKey =
                this.getDatafromDataBase.changeDataBaseTableData
                        (this.dtNewUsageInformation.Copy(), "T_INVENTORYUSE", stTypeOfChange)[0]
                            .Split(primaryKeySepartor, StringSplitOptions.RemoveEmptyEntries);

            if (primaryKey.Length < 2 && stTypeOfChange == "INSERT")
            {
                MessageBox.Show("Unable To Process Your Request. Contact Your Admin.",
                    "SRP SAVE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (primaryKey.Length > 1 && stTypeOfChange == "INSERT")
            {
                this.intUsageID = int.Parse(primaryKey[1]);
            }

            this.dtNewDetailUsageInformation =
                this.getDatafromDataBase.getT_INVENTORYUSEDETAILInfo(null, "", "", "", "",
                                new DateTime(), false,"", triStateBool.ignor,
                                true, "AND");

            for (int rowCounter = 0;
                rowCounter < this.dtTentativeUsageDetail.Rows.Count; rowCounter++)
            {
                DataRow drNewUsageDetail = this.dtNewDetailUsageInformation.NewRow();

                drNewUsageDetail["T_INVENTORYUSE_ID"] = this.intUsageID.ToString();
                drNewUsageDetail["M_SHOP_ID"] = this.stringShopID;
                drNewUsageDetail["AD_ORG_ID"] = this.stOrganisationID;
                drNewUsageDetail["USEDATE"] =
                    this.dtNewUsageInformation.Rows[0]["USEDATE"].ToString();
                drNewUsageDetail["M_WAREHOUSEFROM_ID"] =
                    this.dtNewUsageInformation.Rows[0]["M_WAREHOUSEFROM_ID"].ToString();

                if (this.dtTentativeUsageDetail.Rows[rowCounter]["T_INVENTORYUSEDETAIL_ID"].ToString() != "")
                    drNewUsageDetail["T_INVENTORYUSEDETAIL_ID"] =
                        this.dtTentativeUsageDetail.Rows[rowCounter]["T_INVENTORYUSEDETAIL_ID"].ToString();
                drNewUsageDetail["LINE"] =
                    this.dtTentativeUsageDetail.Rows[rowCounter]["LINE"].ToString();
                drNewUsageDetail["M_PRODUCT_ID"] =
                    this.dtTentativeUsageDetail.Rows[rowCounter]["M_PRODUCT_ID"].ToString();
                drNewUsageDetail["M_UOM_ID"] =
                    this.dtTentativeUsageDetail.Rows[rowCounter]["M_UOM_ID"].ToString();
                drNewUsageDetail["DESCRIPTION"] =
                    this.dtTentativeUsageDetail.Rows[rowCounter]["DESCRIPTION"].ToString();
                drNewUsageDetail["USEDQUANTITY"] =
                    this.dtTentativeUsageDetail.
                        Rows[rowCounter]["Used Qty"].ToString().Replace(",", "");

                this.dtNewDetailUsageInformation.Rows.Add(drNewUsageDetail);
            }

            primaryKey =
                this.getDatafromDataBase.changeDataBaseTableData
                        (this.dtNewDetailUsageInformation.Copy(), "T_INVENTORYUSEDETAIL", "UPDATE")[0]
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
                rowCounter < this.dtNewDetailUsageInformation.Rows.Count; rowCounter++)
            {
                this.getDataAccordingToRule.adjustStock
                     (
                       this.dtNewDetailUsageInformation.Rows[rowCounter]["M_PRODUCT_ID"].ToString(),
                       this.dtNewUsageInformation.Rows[0]["M_WAREHOUSEFROM_ID"].ToString(),
                       (decimal.Parse(
                                this.dtNewDetailUsageInformation.Rows[rowCounter]["USEDQUANTITY"].ToString()
                                    )*-1)
                     );
            }

        finalLine:

            if (stTypeOfChange == "INSERT")
            {
                DataRow drNewExistingUsageRow =
                       this.dtExistingUsageInformation.NewRow();
                drNewExistingUsageRow["T_INVENTORYUSE_ID"] = this.intUsageID.ToString();
                drNewExistingUsageRow["DOCUMENTNO"] = this.txtDocumentNo.Text;
                drNewExistingUsageRow["USEDATE"] = this.dtpUsedDate.Value.ToString();
                drNewExistingUsageRow["DESCRIPTION"] = this.txtDescription.Text;
                drNewExistingUsageRow["M_WAREHOUSEFROM_ID"] = this.intUsedFromStoreID.ToString();
                drNewExistingUsageRow["STORE FROM"] = this.cmbUsedFrom.SelectedItem.ToString();               
                                
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

                this.dtExistingUsageInformation.Rows.Add(drNewExistingUsageRow);
            }
            else if (stTypeOfChange == "UPDATE")
            {
                bool updateHasBeenMade = false;
                for (int rowCounter = 0;
                        rowCounter <= this.dtExistingUsageInformation.Rows.Count - 1;
                        rowCounter++)
                {
                    if (this.intUsageID.ToString() ==
                        this.dtExistingUsageInformation.Rows[rowCounter]["T_INVENTORYUSE_ID"].ToString())
                    {

                        this.dtExistingUsageInformation.
                            Rows[rowCounter]["DOCUMENTNO"] = this.txtDocumentNo.Text;
                        this.dtExistingUsageInformation.
                            Rows[rowCounter]["USEDATE"] = this.dtpUsedDate.Value.ToString();
                        this.dtExistingUsageInformation.
                            Rows[rowCounter]["DESCRIPTION"] = this.txtDescription.Text;
                        this.dtExistingUsageInformation.
                            Rows[rowCounter]["M_WAREHOUSEFROM_ID"] = this.intUsedFromStoreID.ToString();
                        this.dtExistingUsageInformation.
                            Rows[rowCounter]["STORE FROM"] = this.cmbUsedFrom.SelectedItem.ToString();                        
                        
                        if (result == DialogResult.No)
                        {
                            this.dtExistingUsageInformation.
                                Rows[rowCounter]["PROCESSED"] = "N";
                            this.dtExistingUsageInformation.
                             Rows[rowCounter]["DOCSTATUS"] = "DRAFTED";
                        }
                        else if (result == DialogResult.Yes)
                        {
                            this.dtExistingUsageInformation.
                                Rows[rowCounter]["PROCESSED"] = "Y";
                            this.dtExistingUsageInformation.
                             Rows[rowCounter]["DOCSTATUS"] = "COMPLETED";
                        }

                        updateHasBeenMade = true;
                        break;
                    }
                }
                if (!updateHasBeenMade)
                {
                    this.dtExistingUsageInformation.Clear();
                }

            }

            this.dtgUsageGridView.DataSource = this.dtExistingUsageInformation;

            MessageBox.Show("Process has Completed Successfully.",
                    "SRP SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.tlsNew_Click(sender, e);
        }

        private void tlsDelete_Click(object sender, EventArgs e)
        {
            if (this.intUsageID == -1)
                return;

            DataTable dtExistingUsageInfo =
                this.getDatafromDataBase.getT_INVENTORYUSEInfo(null, "",
                        this.intUsageID.ToString(), "", "", new DateTime(),
                        false, triStateBool.ignor, triStateBool.No,
                        transactionStatus.Draft, false, "AND");

            if (dtExistingUsageInfo.Rows.Count != 1)
                return;

            if (MessageBox.Show("Are you sure you want to DELETE this Usage.",
                "SRP Warning", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                == DialogResult.No)
                return;



            DataTable dtExistingUsageDetailInfo =
                this.getDatafromDataBase.getT_INVENTORYUSEDETAILInfo(null, "",
                    "", this.intUsageID.ToString(), "", new DateTime(),
                    false,"", triStateBool.ignor, false, "AND");

            this.getDatafromDataBase.changeDataBaseTableData(dtExistingUsageDetailInfo, "T_INVENTORYUSEDETAIL", "DELETE");
            this.getDatafromDataBase.changeDataBaseTableData(dtExistingUsageInfo, "T_INVENTORYUSE", "DELETE");

            MessageBox.Show("Process has Completed Successfully.",
                    "SRP DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (this.dtExistingUsageInformation.Rows.Count > 0)
            {
                this.dtExistingUsageInformation.Rows.RemoveAt
                    (this.dtgUsageGridView.SelectedRows[0].Index);
                this.dtExistingDetailUsageInformation.Clear();
                if (this.dtExistingUsageInformation.Rows.Count > 0)
                {
                    int intCrrSelectedRow =
                        this.dtgUsageGridView.SelectedRows[0].Index;
                    if (intCrrSelectedRow < 0)
                        intCrrSelectedRow = 0;
                    this.dtgUsageGridView.
                        Rows[intCrrSelectedRow - 1].Selected = true;
                    this.dtgUsageGridView_CellClick(sender, new DataGridViewCellEventArgs(0, 0));
                }
            }
            else
            {
                this.tlsNew_Click(sender, e);
            }
        }

        private void tlsReverse_Click(object sender, EventArgs e)
        {
            if (this.intUsageID == -1)
                return;

            DataTable dtExistingUsageInfo =
                this.getDatafromDataBase.getT_INVENTORYUSEInfo(null, "",
                        this.intUsageID.ToString(), "", "", new DateTime(),
                        false, triStateBool.ignor, triStateBool.yes,
                        transactionStatus.Complete, false, "AND");

            if (dtExistingUsageInfo.Rows.Count != 1)
                return;

            if (dtExistingUsageInfo.Rows[0]["DOCSTATUS"].ToString() == "RE" ||
                dtExistingUsageInfo.Rows[0]["DOCSTATUS"].ToString() == "DR")
                return;


            if (MessageBox.Show("Are you sure you want to REVERESE the effect of this Usage.\n" +
                    "This will Alter the stock quantity Respective Items",
                    "SRP Warning", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                == DialogResult.No)
                return;

            DataTable dtExistingUsageDetailInfo =
                this.getDatafromDataBase.getT_INVENTORYUSEDETAILInfo(null, "",
                    "", this.intUsageID.ToString(), "", new DateTime(),
                    false, "", triStateBool.ignor, false, "AND");

            int intM_PRODUCT_ID = -1;
            int intM_WAREHOUSEFROM_ID = -1;            
            decimal dcUsageQuantity = 0;

            for (int rowCounter = 0; 
                 rowCounter <= dtExistingUsageDetailInfo.Rows.Count - 1; rowCounter++)
            {
                intM_PRODUCT_ID = 
                    int.Parse(dtExistingUsageDetailInfo.
                                    Rows[rowCounter]["M_PRODUCT_ID"].ToString());

                if (intM_PRODUCT_ID == -1 ||
                    intM_PRODUCT_ID == 0)
                {
                    goto finalLine;
                }

                intM_WAREHOUSEFROM_ID =
                    int.Parse(dtExistingUsageDetailInfo.
                                Rows[rowCounter]["M_WAREHOUSEFROM_ID"].ToString());

                if (intM_WAREHOUSEFROM_ID == -1 ||
                    intM_WAREHOUSEFROM_ID == 0)
                {
                    goto finalLine;
                }
                
                dcUsageQuantity =
                    decimal.Parse(dtExistingUsageDetailInfo.
                                    Rows[rowCounter]["USEDQUANTITY"].ToString());

                if (dcUsageQuantity == -1 ||
                    dcUsageQuantity == 0)
                {
                    continue;
                }

                this.getDataAccordingToRule.adjustStock(intM_PRODUCT_ID.ToString(), 
                                intM_WAREHOUSEFROM_ID.ToString(), dcUsageQuantity);                
            }

            dtExistingUsageInfo.Rows[0]["DOCSTATUS"] = "RE";

            this.getDatafromDataBase.
                changeDataBaseTableData(dtExistingUsageInfo, "T_INVENTORYUSE", "UPDATE");

            if (this.dtgUsageGridView.SelectedRows.Count > 0)
            {
                this.dtExistingUsageInformation.
                    Rows[this.dtgUsageGridView.SelectedRows[0].Index]["DOCSTATUS"] = "REVERSED";
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
            frmSearchUsage frmSearchUsage = new frmSearchUsage();
            this.dtExistingUsageInformation.Clear();
            generalResultInformation.searchResult.Clear();

            Form newSearchFrmHolder = new Form();
            newSearchFrmHolder.Controls.Add(frmSearchUsage);
            newSearchFrmHolder.AutoScroll = true;
            newSearchFrmHolder.AutoSize = true;
            newSearchFrmHolder.AutoSizeMode = AutoSizeMode.GrowOnly;
            frmSearchUsage.Dock = DockStyle.Fill;
            newSearchFrmHolder.Text = "Inventory Usage";
            newSearchFrmHolder.Load +=
                new EventHandler(frmSearchUsage.frmSearchUsage_Load);
            newSearchFrmHolder.ShowDialog();


            DataTable resultTable = 
                generalResultInformation.searchResult.Copy();
            generalResultInformation.searchResult.Clear();
            for (int rowCounter = 0; rowCounter <= resultTable.Rows.Count - 1; rowCounter++)
            {
                DataRow drNewExistingUsageRow =
                   this.dtExistingUsageInformation.NewRow();
                drNewExistingUsageRow["M_SHOP_ID"] =
                    resultTable.Rows[rowCounter]["M_SHOP_ID"].ToString();
                drNewExistingUsageRow["AD_ORG_ID"] =
                    resultTable.Rows[rowCounter]["AD_ORG_ID"].ToString();
                drNewExistingUsageRow["T_INVENTORYUSE_ID"] =
                    resultTable.Rows[rowCounter]["T_INVENTORYUSE_ID"].ToString();
                drNewExistingUsageRow["DOCUMENTNO"] =
                    resultTable.Rows[rowCounter]["DOCUMENTNO"].ToString();
                drNewExistingUsageRow["USEDATE"] =
                   resultTable.Rows[rowCounter]["USEDATE"].ToString();
                drNewExistingUsageRow["DESCRIPTION"] =
                    resultTable.Rows[rowCounter]["DESCRIPTION"].ToString();

                drNewExistingUsageRow["M_WAREHOUSEFROM_ID"] =
                    resultTable.Rows[rowCounter]["M_WAREHOUSEFROM_ID"].ToString();

                DataTable dtWareHouseInfo = 
                    this.getDatafromDataBase.getM_WarehouseInfo(null, "",
                        resultTable.Rows[rowCounter]["M_WAREHOUSEFROM_ID"].ToString(),
                        "", triStateBool.ignor, triStateBool.ignor, false, "AND");
                try
                {
                    drNewExistingUsageRow["STORE FROM"] =
                        dtWareHouseInfo.Rows[0]["NAME"].ToString();
                }
                catch
                {
                    drNewExistingUsageRow["STORE FROM"] = "Not Found";
                }


                drNewExistingUsageRow["PROCESSED"] =
                    resultTable.Rows[rowCounter]["PROCESSED"].ToString();

                if (resultTable.Rows[rowCounter]["DOCSTATUS"].ToString() == "DR")
                    drNewExistingUsageRow["DOCSTATUS"] = "DRAFTED";
                else if (resultTable.Rows[rowCounter]["DOCSTATUS"].ToString() == "CO")
                    drNewExistingUsageRow["DOCSTATUS"] = "COMPLETED";
                else if (resultTable.Rows[rowCounter]["DOCSTATUS"].ToString() == "RE")
                    drNewExistingUsageRow["DOCSTATUS"] = "REVERSED";

                this.dtExistingUsageInformation.Rows.Add(drNewExistingUsageRow);
            }
            if (this.dtExistingUsageInformation.Rows.Count > 0)            
                this.dtgUsageGridView_CellClick(sender, new DataGridViewCellEventArgs(0, 0));
            
            if (this.dtgUsageLineGridView.SelectedCells.Count > 0)
                this.dtgUsageLineGridView.CurrentCell.Selected = false;
        }

        private void tlsToogleView_Click(object sender, EventArgs e)
        {
            if (this.tlsToogleView.Text == "Grid View")
            {
                this.tlsToogleView.Text = "Record View";
                this.hidColumnsInMainGridView();                
                this.dtgUsageGridView.Visible = true;
                this.dtgUsageGridView.BringToFront();
                this.dtgUsageGridView.Size =
                    new Size(this.Size.Width - 12, this.dtgUsageGridView.Size.Height);
            }
            else
            {
                this.tlsToogleView.Text = "Grid View";
                this.dtgUsageGridView.SendToBack();
                this.dtgUsageGridView.Size =
                    new Size(11, this.dtgUsageGridView.Size.Height);
                this.dtgUsageGridView.Visible = false;
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
                this.ntbUsedQty.Enabled = true;                
            }
            else
            {
                this.intProductID = -1;

                this.ntbUsedQty.Amount = "0";                
                this.ddgProduct.SelectedItem = "";
                this.ntbUsedQty.Enabled = false;
                this.cmbDetailUsageOtherUOM.Items.Clear();
                this.dtDetailUsageItemAlternateUnit.Rows.Clear();
            }
            this.fillDetailTrxItemUOMComboBox();
        }


        private void cmbUseFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.intUsedFromStoreID = -1;
            if (this.cmbUsedFrom.SelectedIndex > 0)
                this.intUsedFromStoreID =
                    int.Parse(this.dtUseFromAccActiveWarehouseInfo.
                                Rows[this.cmbUsedFrom.SelectedIndex - 1]
                                    ["M_WAREHOUSE_ID"].ToString());            
        }


        private void ntbUsageQty_Enter(object sender, EventArgs e)
        {
            this.cmdAddUsageLine.Enabled = true;
        }

        private void ntbUsageQty_Leave(object sender, EventArgs e)
        {
            if (decimal.Parse(this.ntbUsedQty.Amount) != 0)
            {
                this.cmdAddUsageLine.Enabled = true;
            }
            else
            {
                this.cmdAddUsageLine.Enabled = false;
            }
        }

        private void cmbDetailUsageOtherUOM_SelectedIndexChanged
            (object sender, EventArgs e)
        {
            if (this.cmbDetailUsageOtherUOM.Items.Count <= 0)
                return;

            if (this.cmbDetailUsageOtherUOM.SelectedIndex ==
                this.intDetailUsagePrdPreviousUnitIndex)
                return;

            DataTable dtProductInfo =
                this.getDatafromDataBase.getM_PRODUCTInfo(null, "",
                    this.ddgProduct.SelectedRowKey.ToString(), "", "", "", "", "", "", "",
                     triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);
            if (dtProductInfo.Rows.Count <= 0)
                return;

            string stSTDUnitId = dtProductInfo.Rows[0]["M_UOM_ID"].ToString();
            decimal dcMultiplier = 1;

            if (this.cmbDetailUsageOtherUOM.SelectedIndex != 0)
            {
                if (stSTDUnitId ==
                    this.dtDetailUsageItemAlternateUnit.
                        Rows[this.cmbDetailUsageOtherUOM.SelectedIndex - 1]["M_BASE_UOM_ID"].ToString())
                {
                    stSTDUnitId =
                        this.dtDetailUsageItemAlternateUnit.
                        Rows[this.cmbDetailUsageOtherUOM.SelectedIndex - 1]["M_DRIVED_UOM_ID"].ToString();
                }
                else
                {
                    stSTDUnitId =
                        this.dtDetailUsageItemAlternateUnit.
                        Rows[this.cmbDetailUsageOtherUOM.SelectedIndex - 1]["M_BASE_UOM_ID"].ToString();
                }
            }

            if (this.cmbDetailUsageOtherUOM.SelectedIndex != 0)
            {
                if (this.intDetailUsagePrdPreviousUnitIndex == 0)
                {
                    if (dtProductInfo.Rows[0]["M_UOM_ID"].ToString() ==
                        this.dtDetailUsageItemAlternateUnit.
                            Rows[this.cmbDetailUsageOtherUOM.SelectedIndex - 1]["M_BASE_UOM_ID"].ToString())
                    {
                        dcMultiplier *=
                            decimal.Parse(this.dtDetailUsageItemAlternateUnit.
                                            Rows[this.cmbDetailUsageOtherUOM.SelectedIndex - 1]
                                                        ["MULTIPLIER"].ToString());
                    }
                    else
                    {
                        dcMultiplier /=
                            decimal.Parse(this.dtDetailUsageItemAlternateUnit.
                                            Rows[this.cmbDetailUsageOtherUOM.SelectedIndex - 1]
                                                        ["MULTIPLIER"].ToString());
                    }
                }
                else
                {
                    if (dtProductInfo.Rows[0]["M_UOM_ID"].ToString() ==
                        this.dtDetailUsageItemAlternateUnit.
                            Rows[this.intDetailUsagePrdPreviousUnitIndex - 1]["M_BASE_UOM_ID"].ToString())
                    {
                        dcMultiplier /=
                            decimal.Parse(this.dtDetailUsageItemAlternateUnit.
                                            Rows[this.intDetailUsagePrdPreviousUnitIndex - 1]
                                                        ["MULTIPLIER"].ToString());
                    }
                    else
                    {
                        dcMultiplier *=
                            decimal.Parse(this.dtDetailUsageItemAlternateUnit.
                                            Rows[this.intDetailUsagePrdPreviousUnitIndex - 1]
                                                        ["MULTIPLIER"].ToString());
                    }

                    if (dtProductInfo.Rows[0]["M_UOM_ID"].ToString() ==
                        this.dtDetailUsageItemAlternateUnit.
                            Rows[this.cmbDetailUsageOtherUOM.SelectedIndex - 1]["M_BASE_UOM_ID"].ToString())
                    {
                        dcMultiplier *=
                            decimal.Parse(this.dtDetailUsageItemAlternateUnit.
                                            Rows[this.cmbDetailUsageOtherUOM.SelectedIndex - 1]
                                                        ["MULTIPLIER"].ToString());
                    }
                    else
                    {
                        dcMultiplier /=
                            decimal.Parse(this.dtDetailUsageItemAlternateUnit.
                                            Rows[this.cmbDetailUsageOtherUOM.SelectedIndex - 1]
                                                        ["MULTIPLIER"].ToString());
                    }
                }
            }
            else if (this.intDetailUsagePrdPreviousUnitIndex > 0)
            {
                if (dtProductInfo.Rows[0]["M_UOM_ID"].ToString() ==
                        this.dtDetailUsageItemAlternateUnit.
                            Rows[this.intDetailUsagePrdPreviousUnitIndex - 1]["M_BASE_UOM_ID"].ToString())
                {
                    dcMultiplier /=
                        decimal.Parse(this.dtDetailUsageItemAlternateUnit.
                                        Rows[this.intDetailUsagePrdPreviousUnitIndex - 1]
                                                    ["MULTIPLIER"].ToString());
                }
                else
                {
                    dcMultiplier *=
                        decimal.Parse(this.dtDetailUsageItemAlternateUnit.
                                        Rows[this.intDetailUsagePrdPreviousUnitIndex - 1]
                                                    ["MULTIPLIER"].ToString());
                }
            }

            DataTable dtUnitInfo =
                    this.getDatafromDataBase.getM_UOMInfo(null, "",
                        stSTDUnitId, "", "", triStateBool.ignor, false, "AND");
            this.ntbUsedQty.StandardPrecision =
                int.Parse(dtUnitInfo.Rows[0]["STDPRECISION"].ToString());


            this.ntbUsedQty.Amount =
                (this.getDatafromDataBase.roundOff(
                            (decimal.Parse(this.ntbUsedQty.Amount) * dcMultiplier),
                            uint.Parse(this.ntbUsedQty.StandardPrecision.ToString()))).ToString();

            this.intDetailUsagePrdPreviousUnitIndex =
                this.cmbDetailUsageOtherUOM.SelectedIndex;
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
                this.ntbUsedQty.Amount = "0";
                this.ddgProduct.SelectedItem = "";
                this.ntbUsedQty.Enabled = false;
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

                this.ntbUsedQty.Enabled = true;
            }
            this.fillDetailTrxItemUOMComboBox();
        }
         

        private void cmdAddUseLine_Click(object sender, EventArgs e)
        {
            if (this.intProductID.ToString() == "0" ||
                this.intProductID.ToString() == "" ||
                this.ntbUsedQty.Amount == "" ||
                this.ntbUsedQty.Amount == "0")
            {
                return;
            }

            this.cmbDetailUsageOtherUOM.SelectedIndex = 0;
            DataTable dtProductInfo =
                this.getDatafromDataBase.getM_PRODUCTInfo(null, "", 
                        this.intProductID.ToString(),
                        "", "", "", "", "", "", "", triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);

            if (dtProductInfo.Rows.Count != 1 || this.intProductID == 0)
            {
                goto finalLine;
            }
   
            
            if (this.cmdAddUsageLine.Text.ToUpperInvariant() == "ADD")
            {
                DataRow drNewTentaiveUsageDetail = this.dtTentativeUsageDetail.NewRow();

                drNewTentaiveUsageDetail["REMOVE"] = "remove";
                drNewTentaiveUsageDetail["M_PRODUCT_ID"] = this.intProductID.ToString();
                drNewTentaiveUsageDetail["LINE"] = this.dtTentativeUsageDetail.Rows.Count + 1;
                drNewTentaiveUsageDetail["NAME"] = this.ddgProduct.SelectedItem;
                drNewTentaiveUsageDetail["Used Qty"] =
                    this.ntbUsedQty.Amount;
                drNewTentaiveUsageDetail["UNIT"] =
                    this.cmbDetailUsageOtherUOM.SelectedItem.ToString();

                DataTable dtUOMInfo =
                       this.getDatafromDataBase.getM_PRODUCTInfo(null, "", this.intProductID.ToString(),
                            "", "", "", "", "", "", "", 
                                    triStateBool.yes, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);
                if (this.getDatafromDataBase.checkIfTableContainesData(dtUOMInfo))
                {
                    drNewTentaiveUsageDetail["M_UOM_ID"] =
                        dtUOMInfo.Rows[0]["M_UOM_ID"].ToString();
                }
                
                drNewTentaiveUsageDetail["DESCRIPTION"] = this.txtUsageLineDescription.Text;

                this.dtTentativeUsageDetail.Rows.Add(drNewTentaiveUsageDetail);
            }
            else if (this.cmdAddUsageLine.Text.ToUpperInvariant() == "MODIFY")
            {
                if (this.dtgUsageLineGridView.SelectedRows.Count < 1)
                {
                    goto finalLine;
                }
                int crrntSlctRwIndx =
                    this.dtgUsageLineGridView.SelectedRows[0].Index;

                this.dtTentativeUsageDetail.Rows[crrntSlctRwIndx]["REMOVE"] = "remove";
                this.dtTentativeUsageDetail.Rows[crrntSlctRwIndx]["M_PRODUCT_ID"] =
                        this.intProductID.ToString();
                this.dtTentativeUsageDetail.Rows[crrntSlctRwIndx]["NAME"] =
                        this.ddgProduct.SelectedItem;
                this.dtTentativeUsageDetail.Rows[crrntSlctRwIndx]["Used Qty"] =
                        this.ntbUsedQty.Value;
                this.dtTentativeUsageDetail.Rows[crrntSlctRwIndx]["Unit"] =
                    this.cmbDetailUsageOtherUOM.SelectedItem.ToString();

                DataTable dtUOMInfo =
                       this.getDatafromDataBase.getM_PRODUCTInfo(null, "", this.intProductID.ToString(),
                            "", "", "", "", "", "", "", 
                                    triStateBool.yes, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);
                if (this.getDatafromDataBase.checkIfTableContainesData(dtUOMInfo))
                {
                    this.dtTentativeUsageDetail.Rows[crrntSlctRwIndx]["M_UOM_ID"] =
                        dtUOMInfo.Rows[0]["M_UOM_ID"].ToString();
                }

                this.dtTentativeUsageDetail.Rows[crrntSlctRwIndx]["DESCRIPTION"] =
                        this.txtUsageLineDescription.Text;
            }
        finalLine:
            this.intDetailUsagePrdPreviousUnitIndex = -1;

            this.cmdAddUsageLine.Text = "ADD";
            this.cmdAddUsageLine.Enabled = false;

            this.ddgProduct.SelectedRow.Clear();
            this.ddgProduct_selectedItemChanged(sender, e);

            this.ntbUsedQty.Amount = "0";
            this.cmbDetailUsageOtherUOM.Items.Clear();
            this.txtUsageLineDescription.Text = "";
            
            this.dtgUsageLineGridView.BackgroundColor = 
                this.dtgUsageGridView.BackgroundColor;

            if (this.dtgUsageLineGridView.SelectedCells.Count > 0)
                this.dtgUsageLineGridView.CurrentCell.Selected = false;

        }


        private void dtgUseLineGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgUsageLineGridView.SelectedRows.Count < 1 ||
                this.blcurrentUsageProcessed)
            {
                if (this.dtgUsageLineGridView.SelectedCells.Count > 0)
                    this.dtgUsageLineGridView.CurrentCell.Selected = false;
                return;
            }

            int currentSelectedRowIndex =
                this.dtgUsageLineGridView.SelectedRows[0].Index;
            if (this.dtgUsageLineGridView.CurrentCell.OwningColumn.Index == 1 &&
                this.dtgUsageLineGridView.CurrentCell.OwningColumn.Name == "REMOVE" &&
                this.dtgUsageLineGridView.CurrentCell.Value.ToString() == "remove" &&
                this.dtgUsageLineGridView.CurrentCell.OwningColumn.HeaderText == "")
            {
                string stUsageDetailID =
                    this.dtTentativeUsageDetail.
                        Rows[currentSelectedRowIndex]
                            ["T_INVENTORYUSEDETAIL_ID"].ToString();

                if (stUsageDetailID != "" &&
                    this.intUsageID > 0)
                {
                    DataTable dtUsageDetailInfo =
                        this.getDatafromDataBase.
                            getT_INVENTORYUSEDETAILInfo(null, "",
                                stUsageDetailID, this.intUsageID.ToString(),
                                "", new DateTime(), false, "", 
                                triStateBool.ignor, false, "AND");

                    if (this.getDatafromDataBase.
                            checkIfTableContainesData(dtUsageDetailInfo))
                    {
                        this.getDatafromDataBase.
                                changeDataBaseTableData(dtUsageDetailInfo,
                                    "T_INVENTORYUSEDETAIL", "DELETE");
                    }
                }

                this.dtTentativeUsageDetail.Rows.RemoveAt(currentSelectedRowIndex);
                for (int detailRowCounter = 0;
                    detailRowCounter <= this.dtTentativeUsageDetail.Rows.Count - 1; detailRowCounter++)
                {
                    this.dtTentativeUsageDetail.Rows[detailRowCounter]["LINE"] = detailRowCounter + 1;
                }
            }
            else
            {
                this.cmdAddUsageLine.Text = "Modify";

                this.intProductID =
                    int.Parse(this.dtTentativeUsageDetail.Rows[currentSelectedRowIndex]
                                                                ["M_PRODUCT_ID"].ToString());

                this.ddgProduct.SelectedRowKey =
                    this.dtTentativeUsageDetail.Rows[currentSelectedRowIndex]
                                                        ["M_PRODUCT_ID"].ToString();
                this.ddgProduct.SelectedItem =
                    this.dtTentativeUsageDetail.Rows[currentSelectedRowIndex]
                                                        ["NAME"].ToString();
                this.ntbUsedQty.Amount =
                    this.dtTentativeUsageDetail.Rows[currentSelectedRowIndex]
                                                        ["Used Qty"].ToString();
                this.fillDetailTrxItemUOMComboBox();

                this.txtUsageLineDescription.Text =
                    this.dtTentativeUsageDetail.Rows[currentSelectedRowIndex]
                                                        ["DESCRIPTION"].ToString();                

                this.cmdAddUsageLine.Enabled = true;
                this.ntbUsedQty.Enabled = true;                
            }
        }
        
        private void dtgUsageGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgUsageGridView.SelectedRows.Count < 1)
            {
                return;
            }

            int currentSelectedRowIndex =
                this.dtgUsageGridView.SelectedRows[0].Index;

            this.intUsageID =
                int.Parse(this.dtgUsageGridView.Rows[currentSelectedRowIndex].
                        Cells["T_INVENTORYUSE_ID"].Value.ToString());



            this.stOrganisationID =
                this.dtgUsageGridView.Rows[currentSelectedRowIndex].
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
                if (this.dtgUsageGridView.Rows[currentSelectedRowIndex].
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
                this.dtgUsageGridView.Rows[currentSelectedRowIndex].
                        Cells["DOCUMENTNO"].Value.ToString();

            this.dtpUsedDate.Value =
                DateTime.Parse(this.dtgUsageGridView.Rows[currentSelectedRowIndex].
                        Cells["USEDATE"].Value.ToString());

            this.txtDescription.Text =
                this.dtgUsageGridView.Rows[currentSelectedRowIndex].
                        Cells["DESCRIPTION"].Value.ToString();
            
            this.cmbUsedFrom.Text = 
                    this.dtgUsageGridView.Rows[currentSelectedRowIndex].
                        Cells["STORE FROM"].Value.ToString();

            this.intUsedFromStoreID =
                int.Parse(this.dtgUsageGridView.Rows[currentSelectedRowIndex].
                        Cells["M_WAREHOUSEFROM_ID"].Value.ToString());
            
            if (this.dtgUsageGridView.Rows[currentSelectedRowIndex].
                        Cells["PROCESSED"].Value.ToString() == "Y")
                this.blcurrentUsageProcessed = true;
            else
                this.blcurrentUsageProcessed = false;
            
                        
            DataTable dtUsageDetailInformation =
                this.getDatafromDataBase.getT_INVENTORYUSEDETAILInfo(null, "", "",
                    this.intUsageID.ToString(), "", new DateTime(), false,"", triStateBool.ignor,
                    false, "AND");

            this.dtTentativeUsageDetail.Clear();

            for (int rowCounter = 0;
                rowCounter <= dtUsageDetailInformation.Rows.Count - 1;
                rowCounter++)
            {
                DataRow drExistingUsageDetailRow =
                    this.dtTentativeUsageDetail.NewRow();

                drExistingUsageDetailRow["T_INVENTORYUSEDETAIL_ID"] =
                    dtUsageDetailInformation.Rows[rowCounter]["T_INVENTORYUSEDETAIL_ID"].ToString();
                drExistingUsageDetailRow["T_INVENTORYUSE_ID"] =
                    dtUsageDetailInformation.Rows[rowCounter]["T_INVENTORYUSE_ID"].ToString();

                drExistingUsageDetailRow["REMOVE"] = "remove";
                drExistingUsageDetailRow["LINE"] =
                    dtUsageDetailInformation.Rows[rowCounter]["LINE"].ToString();
                drExistingUsageDetailRow["M_PRODUCT_ID"] =
                    dtUsageDetailInformation.Rows[rowCounter]["M_PRODUCT_ID"].ToString();

                DataTable dtPrdInfo =
                    this.getDatafromDataBase.getM_PRODUCTInfo(null, "",
                            dtUsageDetailInformation.Rows[rowCounter]["M_PRODUCT_ID"].ToString(),
                            "", "", "", "", "", "", "", 
                            triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);

                if (dtPrdInfo.Rows.Count > 0)
                {
                    drExistingUsageDetailRow["NAME"] =
                        dtPrdInfo.Rows[0]["NAME"].ToString();
                }

                drExistingUsageDetailRow["Used Qty"] =
                    dtUsageDetailInformation.Rows[rowCounter]["USEDQUANTITY"].ToString();

                DataTable dtUnitInfo =
                    this.getDatafromDataBase.getM_UOMInfo(null, "",
                            dtUsageDetailInformation.Rows[rowCounter]["M_UOM_ID"].ToString(),
                                "", "", triStateBool.ignor, false, "AND");

                if (dtUnitInfo.Rows.Count > 0)
                {
                    drExistingUsageDetailRow["UNIT"] =
                        dtUnitInfo.Rows[0]["ABBREVATION"].ToString();
                }

                drExistingUsageDetailRow["M_UOM_ID"] =
                    dtUsageDetailInformation.Rows[rowCounter]["M_UOM_ID"].ToString();
                
                drExistingUsageDetailRow["DESCRIPTION"] =
                    dtUsageDetailInformation.Rows[rowCounter]["DESCRIPTION"].ToString();

                this.dtTentativeUsageDetail.Rows.Add(drExistingUsageDetailRow);
            }
            this.dtgUsageLineGridView.DataSource = this.dtTentativeUsageDetail;
            
            this.enableDisableFormElement();
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
            if (this.intUsageID <= 0)
                return;

            if (!System.IO.File.Exists("crptMaterialUsage.rpt"))
            {
                MessageBox.Show("Unable To find Report Builder. \n Please Contact Your Administrator.",
                    "Printing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmPrintViewer newPrintJobView = new frmPrintViewer();

            string fileName = "crptMaterialUsage.rpt";
            dtsPOSDocumentData dsNewUsage = new dtsPOSDocumentData();

            dsNewUsage.Tables["dtUsageSummary"].Clear();
            dsNewUsage.Tables["dtUsageDetail"].Clear();


            DataTable dtV_UsageDetail =
                this.getDatafromDataBase.getV_INVENTORYUSEDETAILInfo(null, "",
                                this.intUsageID.ToString(), "", "", "", "", "", "",
                                new DateTime(), false, triStateBool.ignor, triStateBool.ignor,
                                transactionStatus.ignor, false, "AND");

            if (!this.getDatafromDataBase.checkIfTableContainesData(dtV_UsageDetail))
            {
                MessageBox.Show("Unable To Build Report Data. \n Please Contact Your Administrator.",
                    "Printing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRow drNewCount =
                dsNewUsage.Tables["dtUsageSummary"].NewRow();

            drNewCount["UsageId"] =
                int.Parse(dtV_UsageDetail.Rows[0]["T_INVENTORYUSE_ID"].ToString());
            drNewCount["DocumentName"] = "Internal Use";
            drNewCount["StoreFrom"] =
                dtV_UsageDetail.Rows[0]["WAREHOUSE"].ToString();
            drNewCount["DocumentNumber"] =
                dtV_UsageDetail.Rows[0]["DOCUMENTNO"].ToString();
            drNewCount["DocumentDate"] =
                DateTime.Parse(dtV_UsageDetail.Rows[0]["USEDATE"].ToString()).ToString("MMM-dd-yyyy");
            drNewCount["DocumentNote"] =
                dtV_UsageDetail.Rows[0]["DESCRIPTION"].ToString();

            drNewCount["PreparedBy"] = "";
            drNewCount["CheckdBy"] = "";
            drNewCount["ApprovedBy"] = "";
            drNewCount["rePrint"] = "";

            dsNewUsage.Tables["dtUsageSummary"].Rows.Add(drNewCount);

            for (int countDetailCounter = 0;
                 countDetailCounter <=
                    dtV_UsageDetail.Rows.Count - 1;
                 countDetailCounter++)
            {
                DataRow drNewUsageDetail =
                    dsNewUsage.Tables["dtUsageDetail"].NewRow();

                drNewUsageDetail["UsageDetailId"] =
                    int.Parse(dtV_UsageDetail.
                        Rows[countDetailCounter]["T_INVENTORYUSEDETAIL_ID"].ToString());
                drNewUsageDetail["UsageId"] =
                    int.Parse(dtV_UsageDetail.
                        Rows[countDetailCounter]["T_INVENTORYUSE_ID"].ToString());
                drNewUsageDetail["Sn."] =
                    dtV_UsageDetail.
                        Rows[countDetailCounter]["LINE"].ToString();
                drNewUsageDetail["Description"] =
                    dtV_UsageDetail.
                        Rows[countDetailCounter]["PRODUCT"].ToString();
                drNewUsageDetail["Unit"] =
                    dtV_UsageDetail.
                        Rows[countDetailCounter]["UOM"].ToString();
                drNewUsageDetail["Quantity"] =
                    decimal.Parse(dtV_UsageDetail.
                        Rows[countDetailCounter]["USEDQUANTITY"].ToString());
                drNewUsageDetail["Remark"] = "";
                drNewUsageDetail["comment"] =
                    dtV_UsageDetail.
                        Rows[countDetailCounter]["LINE_DESCRIPTION"].ToString();

                drNewUsageDetail["CODE"] =
                    dtV_UsageDetail.
                        Rows[countDetailCounter]["CODE"].ToString();
                drNewUsageDetail["CODE2"] =
                    dtV_UsageDetail.
                        Rows[countDetailCounter]["CODE2"].ToString();
                drNewUsageDetail["BAR"] = "*" +
                    dtV_UsageDetail.
                        Rows[countDetailCounter]["BAR"].ToString() + "*";

                dsNewUsage.Tables["dtUsageDetail"].Rows.Add(drNewUsageDetail);
            }

            newPrintJobView.setUpThePreviewArea(fileName, dsNewUsage);

            newPrintJobView.ShowDialog(this);

        }

        private void dtgUsageLineGridView_Sorted(object sender, EventArgs e)
        {
            if(this.dtgUsageLineGridView.SelectedRows.Count > 0)
            {
                this.intDetailUsagePrdPreviousUnitIndex = -1;

                this.cmdAddUsageLine.Text = "ADD";
                this.cmdAddUsageLine.Enabled = false;

                this.ddgProduct.SelectedRow.Clear();
                this.ddgProduct_selectedItemChanged(sender, e);

                this.ntbUsedQty.Amount = "0";
                this.cmbDetailUsageOtherUOM.Items.Clear();
                this.txtUsageLineDescription.Text = "";

                this.dtgUsageLineGridView.BackgroundColor =
                    this.dtgUsageGridView.BackgroundColor;                
            }
            if (this.dtgUsageLineGridView.SelectedCells.Count > 0)
                this.dtgUsageLineGridView.CurrentCell.Selected = false;
        }
        

    }
}
