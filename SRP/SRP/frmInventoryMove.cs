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
    public partial class frmInventoryMove : Panel
    {
        public frmInventoryMove()
        {
            InitializeComponent();
        }

        string stringShopID = generalResultInformation.activeStation;

        string stOrganisationID = "";

        int intMovementID = -1;
        int intProductID = -1;
        int intMoveFromStoreID = -1;
        int intMoveToStoreID = -1;

        int intDetailMovementPrdPreviousUnitIndex = -1;

        bool blcurrentMovementProcessed = false;
        bool blCurrentRecordIsReadOnly = false;

        static private Color clNormalLableColor = Color.Black;
        static private Color clErrorLableColor = Color.Red;
        static private Color clChangedLableColor = Color.Blue;

        DataTable dtNewMovementInformation = new DataTable();
        DataTable dtNewDetailMovementInformation = new DataTable();
        DataTable dtExistingActiveProductInformation = new DataTable();
        DataTable dtMoveFromAccActiveWarehouseInfo = new DataTable();        
        DataTable dtMoveToAccActiveWarehouseInfo = new DataTable();

        DataTable dtAccessableOrgInformation = new DataTable();
        DataTable dtExistingMovementInformation = new DataTable();
        DataTable dtExistingDetailMovementInformation = new DataTable();

        //DataTable dtDetailTrxItemStandardUnit = new DataTable();
        DataTable dtDetailMovementItemAlternateUnit = new DataTable();

        DataTable dtAllUOMInformation = new DataTable();
        DataTable dtTentativeMovementDetail = new DataTable();

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
            DataTable dtMoveInfo = this.getDatafromDataBase.getT_MOVEMENTInfo(null, "",
                    this.intMovementID.ToString(), "", "","", new DateTime(),
                    false, triStateBool.ignor, triStateBool.yes,
                    transactionStatus.ignor, false, "AND");

            if (!this.getDatafromDataBase.checkIfTableContainesData(dtMoveInfo))
                return false;

            string docStatus = dtMoveInfo.Rows[0]["DOCSTATUS"].ToString();

            if (docStatus == "DR")
                return false;

            DataTable dtCurrentMoveDetail =
                this.getDatafromDataBase.getT_MOVEMENTDETAILInfo(null, "","",
                        this.intMovementID.ToString(),"", "", new DateTime(), false,
                        "", triStateBool.ignor, false, "AND");

            if (!this.getDatafromDataBase.checkIfTableContainesData(dtCurrentMoveDetail))
                return false;

            DataTable dtNewMtransactionSummerizer =
                this.getDatafromDataBase.getM_TRANSACTIONInfo(null, "", "", "",
                        "", "", new DateTime(), false, "", "", "",
                        triStateBool.ignor, true, "AND");

            DataRow drNewMtrxSummaryRow;

            for (int rowCounter = 0; rowCounter <= dtCurrentMoveDetail.Rows.Count - 1; rowCounter++)
            {
                // Transaction for the sending store

                drNewMtrxSummaryRow = dtNewMtransactionSummerizer.NewRow();

                drNewMtrxSummaryRow["M_SHOP_ID"] =
                    dtCurrentMoveDetail.Rows[rowCounter]["M_SHOP_ID"].ToString();

                drNewMtrxSummaryRow["AD_ORG_ID"] =
                    dtCurrentMoveDetail.Rows[rowCounter]["M_SHOP_ID"].ToString();

                drNewMtrxSummaryRow["MOVEMENTTYPE"] =
                    this.getDataAccordingToRule.getStringEquivelentOfMoveType(movementType.M_n);

                drNewMtrxSummaryRow["MOVEMENTQTY"] = -1 *
                    decimal.Parse(dtCurrentMoveDetail.Rows[rowCounter]["MOVEQUANTITY"].ToString());

                if (docStatus == "RE")
                {
                    drNewMtrxSummaryRow["MOVEMENTQTY"] = -1 *
                        decimal.Parse(drNewMtrxSummaryRow["MOVEMENTQTY"].ToString());
                }

                drNewMtrxSummaryRow["M_LOCATOR_ID"] =
                    dtCurrentMoveDetail.Rows[rowCounter]["M_WAREHOUSEFROM_ID"].ToString();

                drNewMtrxSummaryRow["M_PRODUCT_ID"] =
                    dtCurrentMoveDetail.Rows[rowCounter]["M_PRODUCT_ID"].ToString();

                drNewMtrxSummaryRow["MOVEMENTDATE"] =
                    dtCurrentMoveDetail.Rows[rowCounter]["MOVEDATE"].ToString();

                drNewMtrxSummaryRow["C_UOM_ID"] =
                    dtCurrentMoveDetail.Rows[rowCounter]["M_UOM_ID"].ToString();

                drNewMtrxSummaryRow["M_MOVEMENTLINE_ID"] =
                    dtCurrentMoveDetail.Rows[rowCounter]["T_MOVEMENTDETAIL_ID"].ToString();

                dtNewMtransactionSummerizer.Rows.Add(drNewMtrxSummaryRow);

                // Transaction for the receiving store

                drNewMtrxSummaryRow = dtNewMtransactionSummerizer.NewRow();

                drNewMtrxSummaryRow["M_SHOP_ID"] =
                    dtCurrentMoveDetail.Rows[rowCounter]["M_SHOP_ID"].ToString();

                drNewMtrxSummaryRow["AD_ORG_ID"] =
                    dtCurrentMoveDetail.Rows[rowCounter]["M_SHOP_ID"].ToString();

                drNewMtrxSummaryRow["MOVEMENTTYPE"] =
                    this.getDataAccordingToRule.getStringEquivelentOfMoveType(movementType.M_p);

                drNewMtrxSummaryRow["MOVEMENTQTY"] =
                    decimal.Parse(dtCurrentMoveDetail.Rows[rowCounter]["MOVEQUANTITY"].ToString());

                if (docStatus == "RE")
                {
                    drNewMtrxSummaryRow["MOVEMENTQTY"] = -1 *
                        decimal.Parse(drNewMtrxSummaryRow["MOVEMENTQTY"].ToString());
                }

                drNewMtrxSummaryRow["M_LOCATOR_ID"] =
                    dtCurrentMoveDetail.Rows[rowCounter]["M_WAREHOUSETO_ID"].ToString();

                drNewMtrxSummaryRow["M_PRODUCT_ID"] =
                    dtCurrentMoveDetail.Rows[rowCounter]["M_PRODUCT_ID"].ToString();

                drNewMtrxSummaryRow["MOVEMENTDATE"] =
                    dtCurrentMoveDetail.Rows[rowCounter]["MOVEDATE"].ToString();

                drNewMtrxSummaryRow["C_UOM_ID"] =
                    dtCurrentMoveDetail.Rows[rowCounter]["M_UOM_ID"].ToString();

                drNewMtrxSummaryRow["M_MOVEMENTLINE_ID"] =
                    dtCurrentMoveDetail.Rows[rowCounter]["T_MOVEMENTDETAIL_ID"].ToString();

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

            if (this.intMoveFromStoreID == -1)
            {
                this.lblMoveFrom.ForeColor = clErrorLableColor;
                foundError = true;
            }
            else
            {
                this.lblMoveFrom.ForeColor = clNormalLableColor;
            }

            if (this.intMoveToStoreID == -1)
            {
                this.lblMoveTo.ForeColor = clErrorLableColor;
                foundError = true;
            }
            else
            {
                this.lblMoveTo.ForeColor = clNormalLableColor;
            }

            if (this.dtTentativeMovementDetail.Rows.Count == 0)
            {
                this.dtgMoveLineGridView.BackgroundColor = clErrorLableColor;
                foundError = true;
            }
            else
            {
                this.dtgMoveLineGridView.BackgroundColor = 
                    this.dtgMovementGridView.BackgroundColor;
            }

            if (this.dtpMoveDate.Value == null)
            {
                this.lblMovementDate.ForeColor = clErrorLableColor;
                foundError = true;
            }
            else
            {
                this.lblMovementDate.ForeColor = clNormalLableColor;
            }            

            return foundError;
        }

        private void determinCurrentRecordReadOnlySatust()
        {
            if (this.intMovementID <= 0)
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
            if (this.intMovementID == -1)
                this.blcurrentMovementProcessed = false;

            if (!this.blcurrentMovementProcessed)
            {
                this.determinCurrentRecordReadOnlySatust();
                if (this.blCurrentRecordIsReadOnly)
                    this.blcurrentMovementProcessed = true;
            }

            this.cmbOrganisation.Enabled = !this.blcurrentMovementProcessed;
            this.txtDocumentNo.Enabled = !this.blcurrentMovementProcessed;

            this.ddgProduct.Enabled = !this.blcurrentMovementProcessed;
            this.ntbMovementQty.Enabled = !this.blcurrentMovementProcessed;
            this.cmbDetailMovementOtherUOM.Enabled = !this.blcurrentMovementProcessed;
            this.cmdAddMoveLine.Enabled = !this.blcurrentMovementProcessed;
            this.txtMoveLineDescription.Enabled = !this.blcurrentMovementProcessed;
            
            this.dtgMoveLineGridView.Columns["REMOVE"].Visible = 
                !this.blcurrentMovementProcessed;
            this.txtDescription.Enabled = !this.blcurrentMovementProcessed;
            if (this.dtgMovementGridView.SelectedRows.Count == 0)
                this.tlsDelete.Enabled = false;
            else if (this.dtgMovementGridView.Rows
                    [this.dtgMovementGridView.SelectedRows[0].Index].
                        Cells["PROCESSED"].Value.ToString().ToUpperInvariant() != "N")
                this.tlsDelete.Enabled = false;
            else
                this.tlsDelete.Enabled = true;

            this.tlsPrint.Enabled =
                !this.tlsDelete.Enabled && this.blcurrentMovementProcessed;

            this.cmbMoveFrom.Enabled = !this.blcurrentMovementProcessed;
            this.cmbMoveTo.Enabled = !this.blcurrentMovementProcessed;

            this.dtpMoveDate.Enabled = !this.blcurrentMovementProcessed;

            this.tlsSave.Enabled = !this.blcurrentMovementProcessed;
            this.tlsReverse.Enabled = this.blcurrentMovementProcessed;

            this.cmdDetailTrxProductImage.Enabled = !this.blcurrentMovementProcessed;
        }

        private void fillDetailTrxItemUOMComboBox()
        {
            this.cmbDetailMovementOtherUOM.Items.Clear();
            if (this.ddgProduct.SelectedRowKey == null)
                return;

            DataTable dtPrdInfo =
                this.getDatafromDataBase.getM_PRODUCTInfo(null, "",
                    this.ddgProduct.SelectedRowKey.ToString(), "", "", "", "", "",
                        "", "", triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);

            if (dtPrdInfo.Rows.Count <= 0)
                return;

            this.dtDetailMovementItemAlternateUnit =
                    this.getDatafromDataBase.getM_UOM_CONVERSIONInfo(null, "",
                        dtPrdInfo.Rows[0]["M_UOM_ID"].ToString(),
                        dtPrdInfo.Rows[0]["M_UOM_ID"].ToString(),
                        "", 0, triStateBool.ignor, false, "OR");

            for (int rowCounter = this.dtDetailMovementItemAlternateUnit.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {

                if (this.dtDetailMovementItemAlternateUnit.
                        Rows[rowCounter]["ISACTIVE"].ToString() != "Y")
                {
                    this.dtDetailMovementItemAlternateUnit.Rows.RemoveAt(rowCounter);
                    continue;
                }

                if (this.dtDetailMovementItemAlternateUnit.
                            Rows[rowCounter]["M_PRODUCT_ID"].ToString() !=
                        this.ddgProduct.SelectedRowKey.ToString() &&
                        this.dtDetailMovementItemAlternateUnit.
                            Rows[rowCounter]["M_PRODUCT_ID"].ToString() != "" &&
                        this.dtDetailMovementItemAlternateUnit.
                            Rows[rowCounter]["M_PRODUCT_ID"].ToString() != "0"
                        )
                {
                    this.dtDetailMovementItemAlternateUnit.Rows.RemoveAt(rowCounter);
                    continue;
                }
            }


            for (int rowCounter = this.dtDetailMovementItemAlternateUnit.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                if (this.dtDetailMovementItemAlternateUnit.
                    Rows[rowCounter]["M_PRODUCT_ID"].ToString() == "" ||
                   this.dtDetailMovementItemAlternateUnit.
                    Rows[rowCounter]["M_PRODUCT_ID"].ToString() == "0")
                {
                    for (int rowCounter2 = this.dtDetailMovementItemAlternateUnit.Rows.Count - 1;
                          rowCounter2 >= 0; rowCounter2--)
                    {
                        if ((this.dtDetailMovementItemAlternateUnit.
                                Rows[rowCounter]["M_BASE_UOM_ID"].ToString() ==
                            this.dtDetailMovementItemAlternateUnit.
                                Rows[rowCounter2]["M_BASE_UOM_ID"].ToString() &&
                            this.dtDetailMovementItemAlternateUnit.
                                Rows[rowCounter]["M_DRIVED_UOM_ID"].ToString() ==
                            this.dtDetailMovementItemAlternateUnit.
                                Rows[rowCounter2]["M_DRIVED_UOM_ID"].ToString()) ||
                            (this.dtDetailMovementItemAlternateUnit.
                                Rows[rowCounter]["M_BASE_UOM_ID"].ToString() ==
                            this.dtDetailMovementItemAlternateUnit.
                                Rows[rowCounter2]["M_DRIVED_UOM_ID"].ToString() &&
                            this.dtDetailMovementItemAlternateUnit.
                                Rows[rowCounter]["M_BASE_UOM_ID"].ToString() ==
                            this.dtDetailMovementItemAlternateUnit.
                                Rows[rowCounter2]["M_DRIVED_UOM_ID"].ToString()))
                        {
                            this.dtDetailMovementItemAlternateUnit.Rows.RemoveAt(rowCounter);
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
                this.cmbDetailMovementOtherUOM.Items.Insert
                    (this.cmbDetailMovementOtherUOM.Items.Count,
                     dtUnitInfo.Rows[0]["ABBREVATION"].ToString()
                    );
                this.cmbDetailMovementOtherUOM.SelectedIndex = 0;
            }

            for (int rowCounter = 0; rowCounter <= this.dtDetailMovementItemAlternateUnit.Rows.Count - 1;
                rowCounter++)
            {

                string stUnitId = "";

                if (this.dtDetailMovementItemAlternateUnit.
                        Rows[rowCounter]["M_BASE_UOM_ID"].ToString() ==
                    dtPrdInfo.Rows[0]["M_UOM_ID"].ToString())
                    stUnitId =
                        this.dtDetailMovementItemAlternateUnit.Rows[rowCounter]["M_DRIVED_UOM_ID"].ToString();
                else
                    stUnitId =
                        this.dtDetailMovementItemAlternateUnit.Rows[rowCounter]["M_BASE_UOM_ID"].ToString();

                dtUnitInfo =
                    this.getDatafromDataBase.getM_UOMInfo(null, "",
                        stUnitId, "", "", triStateBool.ignor, false, "AND");
                if (dtUnitInfo.Rows.Count > 0)
                {
                    this.cmbDetailMovementOtherUOM.Items.Insert
                        (this.cmbDetailMovementOtherUOM.Items.Count,
                         dtUnitInfo.Rows[0]["ABBREVATION"].ToString()
                        );
                }
            }
        }

        private void convertItemInfoToStandardUnit()
        {
            if (this.cmbDetailMovementOtherUOM.SelectedIndex == 0)
                return;
            int intSelectedUnitIndex = 
                this.cmbDetailMovementOtherUOM.SelectedIndex - 1;

            decimal dcMultiplier =
                decimal.Parse(this.dtDetailMovementItemAlternateUnit.
                    Rows[intSelectedUnitIndex]["MULTIPLIER"].ToString());
            ctlNumberTextBox converter = new ctlNumberTextBox();
            converter.Amount = dcMultiplier.ToString();
            dcMultiplier = decimal.Parse(converter.Amount);

            if (this.ddgProduct.SelectedRow.Rows[0]["M_UOM_ID"].ToString() ==
                this.dtDetailMovementItemAlternateUnit.
                    Rows[intSelectedUnitIndex]["M_DRIVED_UOM_ID"].ToString())
            {
                this.ntbMovementQty.Amount =
                    (decimal.Parse(this.ntbMovementQty.Amount) *
                        dcMultiplier).ToString();              
            }
            else
            {
                this.ntbMovementQty.Amount =
                    (decimal.Parse(this.ntbMovementQty.Amount) /
                        dcMultiplier).ToString();
            }

            this.cmbDetailMovementOtherUOM.SelectedIndex = 0;
        }

        private void fillDestinationStore()
        {
            this.dtMoveToAccActiveWarehouseInfo =
                this.getDataAccordingToRule.getCurrentUserAccessableWarehouse(triStateBool.ignor,
                                    triStateBool.yes, triStateBool.ignor, triStateBool.ignor,
                                    triStateBool.ignor, triStateBool.ignor, triStateBool.ignor,
                                    triStateBool.yes, "AND");

            this.cmbMoveTo.Items.Clear();
            this.cmbMoveTo.Items.Add(" - Select Store - ");
            this.cmbMoveTo.SelectedIndex = 0;
            if (this.cmbMoveFrom.SelectedIndex > 0)
            {
                for (int rowCounter = 0; rowCounter <= this.dtMoveToAccActiveWarehouseInfo.Rows.Count - 1; rowCounter++)
                {
                    if (this.dtMoveFromAccActiveWarehouseInfo.
                            Rows[this.cmbMoveFrom.SelectedIndex - 1]["M_WAREHOUSE_ID"].ToString()
                                !=
                        this.dtMoveToAccActiveWarehouseInfo.
                            Rows[rowCounter]["M_WAREHOUSE_ID"].ToString())
                    {
                        this.cmbMoveTo.Items.Add(
                                this.dtMoveToAccActiveWarehouseInfo.Rows[rowCounter]["NAME"].ToString());
                    }
                    else
                    {
                        this.dtMoveToAccActiveWarehouseInfo.Rows.RemoveAt(rowCounter);
                        rowCounter--;
                    }
                }
            }              
        }

        private string getNextDocumentNumber()
        {
            string stNextSequenceNo = "";
            string stDOCBASETYPE = "";

            DataTable dtSequenceInfo = new DataTable();
            
            stDOCBASETYPE = "MOVE";            

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
            this.dtgMoveLineGridView.Columns["M_SHOP_ID"].Visible = false;
            this.dtgMoveLineGridView.Columns["AD_ORG_ID"].Visible = false;
            this.dtgMoveLineGridView.Columns["M_PRODUCT_ID"].Visible = false;
            this.dtgMoveLineGridView.Columns["M_UOM_ID"].Visible = false;
            this.dtgMoveLineGridView.Columns["DESCRIPTION"].Visible = false;
            this.dtgMoveLineGridView.Columns["T_MOVEMENT_ID"].Visible = false;
            this.dtgMoveLineGridView.Columns["T_MOVEMENTDETAIL_ID"].Visible = false;
            this.dtgMoveLineGridView.Columns["M_WAREHOUSEFROM_ID"].Visible = false;
            this.dtgMoveLineGridView.Columns["M_WAREHOUSETO_ID"].Visible = false;
        }

        private void hidColumnsInMainGridView()
        {
            this.dtgMovementGridView.Columns["M_SHOP_ID"].Visible = false;
            this.dtgMovementGridView.Columns["AD_ORG_ID"].Visible = false;
            this.dtgMovementGridView.Columns["T_MOVEMENT_ID"].Visible = false;
            this.dtgMovementGridView.Columns["M_WAREHOUSEFROM_ID"].Visible = false;
            this.dtgMovementGridView.Columns["M_WAREHOUSETO_ID"].Visible = false;

        }
        

        public void frmInventoryMove_Load(object sender, EventArgs e)
        {
            this.setUpOrganisations();

            if (generalResultInformation.currentFormIsReadOnly)
            {
                this.tlsDelete.Visible = false;
                this.tlsNew.Visible = false;
                this.tlsSave.Visible = false;
                this.cmdAddMoveLine.Visible = false;
            }
            
            this.dtExistingActiveProductInformation =
                this.getDatafromDataBase.getM_PRODUCTInfo(null, "", "",
                        "", "", "", "", "", "", "", 
                                triStateBool.yes, true, "AND",generalResultInformation.dbBulkDataRetrivalSize);

            this.dtMoveFromAccActiveWarehouseInfo =
                this.getDataAccordingToRule.getCurrentUserAccessableWarehouse(triStateBool.yes, 
                                    triStateBool.ignor, triStateBool.ignor, triStateBool.ignor,
                                    triStateBool.ignor, triStateBool.ignor, triStateBool.ignor,
                                    triStateBool.yes, "AND");            

            this.cmbMoveFrom.Items.Add(" - Select Store - ");
            for (int rowCounter = 0;
                 rowCounter <= this.dtMoveFromAccActiveWarehouseInfo.Rows.Count - 1;
                 rowCounter++)
            {
                this.cmbMoveFrom.Items.Add(
                    this.dtMoveFromAccActiveWarehouseInfo.Rows[rowCounter]["NAME"].ToString());
            }

            this.cmbMoveFrom.SelectedIndex = 0;
                
            
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

            this.dtTentativeMovementDetail.Columns.Add("M_SHOP_ID");
            this.dtTentativeMovementDetail.Columns.Add("AD_ORG_ID");
            this.dtTentativeMovementDetail.Columns.Add("M_PRODUCT_ID");
            this.dtTentativeMovementDetail.Columns.Add("REMOVE");
            this.dtTentativeMovementDetail.Columns.Add("LINE",typeof(Int16));
            this.dtTentativeMovementDetail.Columns.Add("NAME");
            this.dtTentativeMovementDetail.Columns.Add("Move Qty");
            this.dtTentativeMovementDetail.Columns.Add("UNIT");
            this.dtTentativeMovementDetail.Columns.Add("M_UOM_ID");
            this.dtTentativeMovementDetail.Columns.Add("M_WAREHOUSEFROM_ID");
            this.dtTentativeMovementDetail.Columns.Add("M_WAREHOUSETO_ID");            
            this.dtTentativeMovementDetail.Columns.Add("DESCRIPTION");
            this.dtTentativeMovementDetail.Columns.Add("T_MOVEMENT_ID");
            this.dtTentativeMovementDetail.Columns.Add("T_MOVEMENTDETAIL_ID");

            this.dtTentativeMovementDetail.Columns["REMOVE"].SetOrdinal(1);

            this.dtgMoveLineGridView.DataSource = this.dtTentativeMovementDetail;

            this.dtgMoveLineGridView.Columns["REMOVE"].HeaderText = "SN";
            this.dtgMoveLineGridView.Columns["REMOVE"].HeaderText = "";
            this.dtgMoveLineGridView.Columns["REMOVE"].DefaultCellStyle = this.cancelButtonStyle;

            this.dtExistingMovementInformation.Columns.Add("M_SHOP_ID");
            this.dtExistingMovementInformation.Columns.Add("AD_ORG_ID");
            this.dtExistingMovementInformation.Columns.Add("T_MOVEMENT_ID");
            this.dtExistingMovementInformation.Columns.Add("DOCUMENTNO");
            this.dtExistingMovementInformation.Columns.Add("DESCRIPTION");
            this.dtExistingMovementInformation.Columns.Add("MOVEDATE");
            this.dtExistingMovementInformation.Columns.Add("M_WAREHOUSEFROM_ID");
            this.dtExistingMovementInformation.Columns.Add("STORE FROM");
            this.dtExistingMovementInformation.Columns.Add("M_WAREHOUSETO_ID");
            this.dtExistingMovementInformation.Columns.Add("STORE TO");            
            this.dtExistingMovementInformation.Columns.Add("PROCESSED");
            this.dtExistingMovementInformation.Columns.Add("DOCSTATUS");

            this.dtgMovementGridView.DataSource = 
                this.dtExistingMovementInformation;
                        
            this.tlsNew_Click(sender, e);

            this.hidColumnsInMainGridView();
            this.hidColumnsInDetailGriedView();

        }

        private void tlsNew_Click(object sender, EventArgs e)
        {
            this.blcurrentMovementProcessed = false;
            this.enableDisableFormElement();

            this.cmbMoveFrom.SelectedIndex = 0;
            this.intMovementID = -1;            
            this.intDetailMovementPrdPreviousUnitIndex = -1;
            this.intMoveFromStoreID = -1;
            this.intMoveToStoreID = -1;

            this.txtDocumentNo.Text = 
                this.getNextDocumentNumber();
            this.txtDescription.Text = "";
            this.dtpMoveDate.Value = DateTime.Today;
            

            this.ddgProduct.SelectedItem = "";
            this.ddgProduct.SelectedRow.Clear();
            this.ddgProduct.SelectedRowKey = null;
            this.ddgProduct_selectedItemChanged(sender, e);

            this.ntbMovementQty.Amount = "0";
            
            this.cmbDetailMovementOtherUOM.Items.Clear();
            this.txtMoveLineDescription.Text = "";
            
            this.dtNewDetailMovementInformation.Clear();
            this.dtNewMovementInformation.Clear();

            this.dtTentativeMovementDetail.Rows.Clear();

            this.cmdAddMoveLine.Enabled = false;

            this.lblDocumentNo.ForeColor = clNormalLableColor;
            this.lblMoveFrom.ForeColor = clNormalLableColor;
            this.lblMoveTo.ForeColor = clNormalLableColor;
            this.dtgMoveLineGridView.BackgroundColor =
                this.dtgMovementGridView.BackgroundColor;
            this.lblMovementDate.ForeColor = clNormalLableColor;
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
                rowCounter < this.dtTentativeMovementDetail.Rows.Count; rowCounter++)
            {
                DataTable stockQuanity =
                    this.getDatafromDataBase.getQ_STOCKInfo(null, "",
                            this.dtTentativeMovementDetail.Rows[rowCounter]["M_PRODUCT_ID"].ToString(),
                            this.intMoveFromStoreID.ToString(), triStateBool.ignor, false, "AND");
                if (stockQuanity.Rows.Count > 0)
                {
                    if (decimal.Parse(this.dtTentativeMovementDetail.Rows[rowCounter]["Move Qty"].ToString()) >
                        decimal.Parse(stockQuanity.Rows[0]["CURRENTQTY"].ToString()))
                    {
                        foundUnderStockInventory = true;
                        this.dtgMoveLineGridView.Rows[rowCounter].DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        this.dtgMoveLineGridView.Rows[rowCounter].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
                else
                {
                    foundUnderStockInventory = true;
                    this.dtgMoveLineGridView.Rows[rowCounter].DefaultCellStyle.ForeColor = Color.Red;
                }
            }

            if (foundUnderStockInventory)
            {
                DataTable dtWarehouseInfo =
                        this.getDatafromDataBase.getM_WarehouseInfo(null, "",
                                this.intMoveFromStoreID.ToString(), "", triStateBool.yes,
                                triStateBool.ignor, false, "AND");
                if (!this.getDatafromDataBase.checkIfTableContainesData(dtWarehouseInfo))
                {
                    MessageBox.Show("No sufficient stock Exist ", "SRP PROCESS", MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                    return;
                }
                if (MessageBox.Show("There are under stocked Items. \n Would you Like to Revise your Movement",
                                "SRP PROCESS", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    return;
            }

            DialogResult result =
                MessageBox.Show("Would you Like to Complete the Movement",
                                "SRP PROCESS", MessageBoxButtons.YesNoCancel,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            if (result == DialogResult.Cancel)
                return;
            
            this.dtNewMovementInformation =
                this.getDatafromDataBase.getT_MOVEMENTInfo(null, "",
                        "", "", "","", new DateTime(), false, triStateBool.ignor,
                        triStateBool.ignor, transactionStatus.ignor, true, "");

            DataRow drNewMovement = this.dtNewMovementInformation.NewRow();

            if (this.intMovementID != -1)
            {
                stTypeOfChange = "UPDATE";
                drNewMovement["T_MOVEMENT_ID"] = this.intMovementID.ToString();
            }
            else
            {
                stTypeOfChange = "INSERT";
            }

            string stDocNumber = "";
            if (this.intMovementID == -1 && this.txtDocumentNo.Text.StartsWith("<") &&
                this.txtDocumentNo.Text.EndsWith(">"))
            {
                DataTable dtSequenceInfo = new DataTable();

                string stDOCBASETYPE = "MOVE";
                
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

            drNewMovement["M_SHOP_ID"] = this.stringShopID;
            drNewMovement["AD_ORG_ID"] = this.stOrganisationID;
            drNewMovement["DOCUMENTNO"] = stDocNumber;
            drNewMovement["DESCRIPTION"] = this.txtDescription.Text;
            drNewMovement["MOVEDATE"] = this.dtpMoveDate.Value;
            drNewMovement["M_WAREHOUSEFROM_ID"] = this.intMoveFromStoreID.ToString();
            drNewMovement["M_WAREHOUSETO_ID"] = this.intMoveToStoreID.ToString();
            
            if (result == DialogResult.Yes)
                drNewMovement["PROCESSED"] = "Y";
            else
                drNewMovement["PROCESSED"] = "N";

            if (result == DialogResult.No)
                drNewMovement["DOCSTATUS"] = "DR";
            else if (result == DialogResult.Yes)
                drNewMovement["DOCSTATUS"] = "CO";

            this.dtNewMovementInformation.Rows.Add(drNewMovement);

            string[] primaryKeySepartor = { " <(", ")>||" };
            string[] primaryKey =
                this.getDatafromDataBase.changeDataBaseTableData
                        (this.dtNewMovementInformation.Copy(), "T_MOVEMENT", stTypeOfChange)[0]
                            .Split(primaryKeySepartor, StringSplitOptions.RemoveEmptyEntries);

            if (primaryKey.Length < 2 && stTypeOfChange == "INSERT")
            {
                MessageBox.Show("Unable To Process Your Request. Contact Your Admin.",
                    "SRP SAVE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (primaryKey.Length > 1 && stTypeOfChange == "INSERT")
            {
                this.intMovementID = int.Parse(primaryKey[1]);
            }

            this.dtNewDetailMovementInformation =
                this.getDatafromDataBase.getT_MOVEMENTDETAILInfo(null, "", "", "", "",
                                "",new DateTime(), false,"", triStateBool.ignor,
                                true, "AND");

            for (int rowCounter = 0;
                rowCounter < this.dtTentativeMovementDetail.Rows.Count; rowCounter++)
            {
                DataRow drNewMovementDetail = this.dtNewDetailMovementInformation.NewRow();

                drNewMovementDetail["M_SHOP_ID"] = this.stringShopID;
                drNewMovementDetail["AD_ORG_ID"] = this.stOrganisationID;
                drNewMovementDetail["T_MOVEMENT_ID"] = this.intMovementID.ToString();

                drNewMovementDetail["MOVEDATE"] =
                    this.dtNewMovementInformation.Rows[0]["MOVEDATE"].ToString();
                drNewMovementDetail["M_WAREHOUSEFROM_ID"] =
                    this.dtNewMovementInformation.Rows[0]["M_WAREHOUSEFROM_ID"].ToString();
                drNewMovementDetail["M_WAREHOUSETO_ID"] =
                    this.dtNewMovementInformation.Rows[0]["M_WAREHOUSETO_ID"].ToString();

                if (this.dtTentativeMovementDetail.Rows[rowCounter]["T_MOVEMENTDETAIL_ID"].ToString() != "")
                    drNewMovementDetail["T_MOVEMENTDETAIL_ID"] =
                        this.dtTentativeMovementDetail.Rows[rowCounter]["T_MOVEMENTDETAIL_ID"].ToString();
                drNewMovementDetail["LINE"] =
                    this.dtTentativeMovementDetail.Rows[rowCounter]["LINE"].ToString();
                drNewMovementDetail["M_PRODUCT_ID"] =
                    this.dtTentativeMovementDetail.Rows[rowCounter]["M_PRODUCT_ID"].ToString();
                drNewMovementDetail["M_UOM_ID"] =
                    this.dtTentativeMovementDetail.Rows[rowCounter]["M_UOM_ID"].ToString();
                drNewMovementDetail["DESCRIPTION"] =
                    this.dtTentativeMovementDetail.Rows[rowCounter]["DESCRIPTION"].ToString();
                drNewMovementDetail["MOVEQUANTITY"] =
                    this.dtTentativeMovementDetail.
                        Rows[rowCounter]["Move Qty"].ToString().Replace(",", "");

                this.dtNewDetailMovementInformation.Rows.Add(drNewMovementDetail);
            }

            primaryKey =
                this.getDatafromDataBase.changeDataBaseTableData
                        (this.dtNewDetailMovementInformation.Copy(), "T_MOVEMENTDETAIL", "UPDATE")[0]
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
                rowCounter < this.dtNewDetailMovementInformation.Rows.Count; rowCounter++)
            {
                this.getDataAccordingToRule.adjustStock
                     (
                       this.dtNewDetailMovementInformation.Rows[rowCounter]["M_PRODUCT_ID"].ToString(),
                       this.dtNewMovementInformation.Rows[0]["M_WAREHOUSEFROM_ID"].ToString(),
                       (decimal.Parse(
                                this.dtNewDetailMovementInformation.Rows[rowCounter]["MOVEQUANTITY"].ToString()
                                    )*-1)
                     );

                this.getDataAccordingToRule.adjustStock
                     (
                       this.dtNewDetailMovementInformation.Rows[rowCounter]["M_PRODUCT_ID"].ToString(),
                       this.dtNewMovementInformation.Rows[0]["M_WAREHOUSETO_ID"].ToString(),
                       decimal.Parse(
                                this.dtNewDetailMovementInformation.Rows[rowCounter]["MOVEQUANTITY"].ToString()
                                    )
                     );
            }

        finalLine:

            if (stTypeOfChange == "INSERT")
            {
                DataRow drNewExistingMovementRow =
                       this.dtExistingMovementInformation.NewRow();
                drNewExistingMovementRow["T_MOVEMENT_ID"] = this.intMovementID.ToString();
                drNewExistingMovementRow["DOCUMENTNO"] = this.txtDocumentNo.Text;
                drNewExistingMovementRow["MOVEDATE"] = this.dtpMoveDate.Value.ToString();
                drNewExistingMovementRow["DESCRIPTION"] = this.txtDescription.Text;
                drNewExistingMovementRow["M_WAREHOUSEFROM_ID"] = this.intMoveFromStoreID.ToString();
                drNewExistingMovementRow["STORE FROM"] = this.cmbMoveFrom.SelectedItem.ToString();
                drNewExistingMovementRow["M_WAREHOUSETO_ID"] = this.intMoveToStoreID.ToString();
                drNewExistingMovementRow["STORE TO"] = this.cmbMoveTo.SelectedItem.ToString();
                
                if (result == DialogResult.No)
                {
                    drNewExistingMovementRow["PROCESSED"] = "N";
                    drNewExistingMovementRow["DOCSTATUS"] = "DRAFTED";
                }
                else if (result == DialogResult.Yes)
                {
                    drNewExistingMovementRow["PROCESSED"] = "Y";
                    drNewExistingMovementRow["DOCSTATUS"] = "COMPLETED";
                }

                this.dtExistingMovementInformation.Rows.Add(drNewExistingMovementRow);
            }
            else if (stTypeOfChange == "UPDATE")
            {
                bool updateHasBeenMade = false;
                for (int rowCounter = 0;
                        rowCounter <= this.dtExistingMovementInformation.Rows.Count - 1;
                        rowCounter++)
                {
                    if (this.intMovementID.ToString() ==
                        this.dtExistingMovementInformation.Rows[rowCounter]["T_MOVEMENT_ID"].ToString())
                    {

                        this.dtExistingMovementInformation.
                            Rows[rowCounter]["DOCUMENTNO"] = this.txtDocumentNo.Text;
                        this.dtExistingMovementInformation.
                            Rows[rowCounter]["MOVEDATE"] = this.dtpMoveDate.Value.ToString();
                        this.dtExistingMovementInformation.
                            Rows[rowCounter]["DESCRIPTION"] = this.txtDescription.Text;
                        this.dtExistingMovementInformation.
                            Rows[rowCounter]["M_WAREHOUSEFROM_ID"] = this.intMoveFromStoreID.ToString();
                        this.dtExistingMovementInformation.
                            Rows[rowCounter]["STORE FROM"] = this.cmbMoveFrom.SelectedItem.ToString();
                        this.dtExistingMovementInformation.
                            Rows[rowCounter]["M_WAREHOUSETO_ID"] = this.intMoveToStoreID.ToString();
                        this.dtExistingMovementInformation.
                            Rows[rowCounter]["STORE TO"] = this.cmbMoveTo.SelectedItem.ToString();
                        if (result == DialogResult.No)
                        {
                            this.dtExistingMovementInformation.
                                Rows[rowCounter]["PROCESSED"] = "N";
                            this.dtExistingMovementInformation.
                             Rows[rowCounter]["DOCSTATUS"] = "DRAFTED";
                        }
                        else if (result == DialogResult.Yes)
                        {
                            this.dtExistingMovementInformation.
                                Rows[rowCounter]["PROCESSED"] = "Y";
                            this.dtExistingMovementInformation.
                             Rows[rowCounter]["DOCSTATUS"] = "COMPLETED";
                        }

                        updateHasBeenMade = true;
                        break;
                    }
                }
                if (!updateHasBeenMade)
                {
                    this.dtExistingMovementInformation.Clear();
                }

            }

            this.dtgMovementGridView.DataSource = this.dtExistingMovementInformation;

            MessageBox.Show("Process has Completed Successfully.",
                    "SRP SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.tlsNew_Click(sender, e);
        }

        private void tlsDelete_Click(object sender, EventArgs e)
        {
            if (this.intMovementID == -1)
                return;

            DataTable dtExistingMovementInfo =
                this.getDatafromDataBase.getT_MOVEMENTInfo(null, "",
                        this.intMovementID.ToString(), "", "","", new DateTime(),
                        false, triStateBool.ignor, triStateBool.No,
                        transactionStatus.Draft, false, "AND");

            if (dtExistingMovementInfo.Rows.Count != 1)
                return;

            if (MessageBox.Show("Are you sure you want to DELETE this Movement.",
                "SRP Warning", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                == DialogResult.No)
                return;



            DataTable dtExistingMovementDetailInfo =
                this.getDatafromDataBase.getT_MOVEMENTDETAILInfo(null, "",
                    "", this.intMovementID.ToString(), "","", new DateTime(),
                    false,"", triStateBool.ignor, false, "AND");

            this.getDatafromDataBase.changeDataBaseTableData(dtExistingMovementDetailInfo, "T_MOVEMENTDETAIL", "DELETE");
            this.getDatafromDataBase.changeDataBaseTableData(dtExistingMovementInfo, "T_MOVEMENT", "DELETE");

            MessageBox.Show("Process has Completed Successfully.",
                    "SRP DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (this.dtExistingMovementInformation.Rows.Count > 0)
            {
                this.dtExistingMovementInformation.Rows.RemoveAt
                    (this.dtgMovementGridView.SelectedRows[0].Index);
                this.dtExistingDetailMovementInformation.Clear();
                if (this.dtExistingMovementInformation.Rows.Count > 0)
                {
                    int intCrrSelectedRow =
                        this.dtgMovementGridView.SelectedRows[0].Index;
                    if (intCrrSelectedRow < 0)
                        intCrrSelectedRow = 0;                    
                    this.dtgMovementGridView_CellClick(sender, new DataGridViewCellEventArgs(0, 0));
                }
            }
            else
            {
                this.tlsNew_Click(sender, e);
            }
        }

        private void tlsReverse_Click(object sender, EventArgs e)
        {
            if (this.intMovementID == -1)
                return;

            DataTable dtExistingMovementInfo =
                this.getDatafromDataBase.getT_MOVEMENTInfo(null, "",
                        this.intMovementID.ToString(), "", "","", new DateTime(),
                        false, triStateBool.ignor, triStateBool.yes,
                        transactionStatus.Complete, false, "AND");

            if (dtExistingMovementInfo.Rows.Count != 1)
                return;

            if (dtExistingMovementInfo.Rows[0]["DOCSTATUS"].ToString() == "RE" ||
                dtExistingMovementInfo.Rows[0]["DOCSTATUS"].ToString() == "DR")
                return;


            if (MessageBox.Show("Are you sure you want to REVERESE the effect of this Movement.\n" +
                    "This will Alter the stock quantity Respective Items",
                    "SRP Warning", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                == DialogResult.No)
                return;

            DataTable dtExistingMovementDetailInfo =
                this.getDatafromDataBase.getT_MOVEMENTDETAILInfo(null, "",
                    "", this.intMovementID.ToString(), "","", new DateTime(),
                    false, "", triStateBool.ignor, false, "AND");

            int intM_PRODUCT_ID = -1;
            int intM_WAREHOUSEFROM_ID = -1;
            int intM_WAREHOUSETO_ID = -1;
            decimal dcMovementQuantity = 0;

            for (int rowCounter = 0; 
                 rowCounter <= dtExistingMovementDetailInfo.Rows.Count - 1; rowCounter++)
            {
                intM_PRODUCT_ID = 
                    int.Parse(dtExistingMovementDetailInfo.
                                    Rows[rowCounter]["M_PRODUCT_ID"].ToString());

                if (intM_PRODUCT_ID == -1 ||
                    intM_PRODUCT_ID == 0)
                {
                    goto finalLine;
                }

                intM_WAREHOUSEFROM_ID =
                    int.Parse(dtExistingMovementDetailInfo.
                                Rows[rowCounter]["M_WAREHOUSEFROM_ID"].ToString());

                if (intM_WAREHOUSEFROM_ID == -1 ||
                    intM_WAREHOUSEFROM_ID == 0)
                {
                    goto finalLine;
                }

                intM_WAREHOUSETO_ID =
                    int.Parse(dtExistingMovementDetailInfo.
                                Rows[rowCounter]["M_WAREHOUSETO_ID"].ToString());

                if (intM_WAREHOUSETO_ID == -1 ||
                    intM_WAREHOUSETO_ID == 0)
                {
                    goto finalLine;
                }

                dcMovementQuantity =
                    decimal.Parse(dtExistingMovementDetailInfo.
                                    Rows[rowCounter]["MOVEQUANTITY"].ToString());

                if (dcMovementQuantity == -1 ||
                    dcMovementQuantity == 0)
                {
                    continue;
                }

                this.getDataAccordingToRule.adjustStock(intM_PRODUCT_ID.ToString(), 
                                intM_WAREHOUSEFROM_ID.ToString(), dcMovementQuantity);
                this.getDataAccordingToRule.adjustStock(intM_PRODUCT_ID.ToString(),
                                intM_WAREHOUSETO_ID.ToString(), dcMovementQuantity * -1);
            }

            dtExistingMovementInfo.Rows[0]["DOCSTATUS"] = "RE";

            this.getDatafromDataBase.
                changeDataBaseTableData(dtExistingMovementInfo, "T_MOVEMENT", "UPDATE");

            if (this.dtgMovementGridView.SelectedRows.Count > 0)
            {
                this.dtExistingMovementInformation.
                    Rows[this.dtgMovementGridView.SelectedRows[0].Index]["DOCSTATUS"] = "REVERSED";
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
            frmSearchMovement frmSearchMvmnt = new frmSearchMovement();
            this.dtExistingMovementInformation.Clear();
            generalResultInformation.searchResult.Clear();

            Form newSearchFrmHolder = new Form();
            newSearchFrmHolder.Controls.Add(frmSearchMvmnt);
            newSearchFrmHolder.AutoScroll = true;
            newSearchFrmHolder.AutoSize = true;
            newSearchFrmHolder.AutoSizeMode = AutoSizeMode.GrowOnly;
            frmSearchMvmnt.Dock = DockStyle.Fill;
            newSearchFrmHolder.Text = "Inventory Movements";
            newSearchFrmHolder.Load +=
                new EventHandler(frmSearchMvmnt.frmSearchMovement_Load);
            newSearchFrmHolder.ShowDialog();

            
            DataTable resultTable = 
                generalResultInformation.searchResult.Copy();
            generalResultInformation.searchResult.Clear();
            for (int rowCounter = 0; rowCounter <= resultTable.Rows.Count - 1; rowCounter++)
            {
                DataRow drNewExistingMovementRow =
                   this.dtExistingMovementInformation.NewRow();
                drNewExistingMovementRow["M_SHOP_ID"] =
                    resultTable.Rows[rowCounter]["M_SHOP_ID"].ToString();
                drNewExistingMovementRow["AD_ORG_ID"] =
                    resultTable.Rows[rowCounter]["AD_ORG_ID"].ToString();
                drNewExistingMovementRow["T_MOVEMENT_ID"] =
                    resultTable.Rows[rowCounter]["T_MOVEMENT_ID"].ToString();
                drNewExistingMovementRow["DOCUMENTNO"] =
                    resultTable.Rows[rowCounter]["DOCUMENTNO"].ToString();
                drNewExistingMovementRow["MOVEDATE"] =
                   resultTable.Rows[rowCounter]["MOVEDATE"].ToString();
                drNewExistingMovementRow["DESCRIPTION"] =
                    resultTable.Rows[rowCounter]["DESCRIPTION"].ToString();

                drNewExistingMovementRow["M_WAREHOUSEFROM_ID"] =
                    resultTable.Rows[rowCounter]["M_WAREHOUSEFROM_ID"].ToString();

                DataTable dtWareHouseInfo = 
                    this.getDatafromDataBase.getM_WarehouseInfo(null, "",
                        resultTable.Rows[rowCounter]["M_WAREHOUSEFROM_ID"].ToString(),
                        "", triStateBool.ignor, triStateBool.ignor, false, "AND");
                try
                {
                    drNewExistingMovementRow["STORE FROM"] =
                        dtWareHouseInfo.Rows[0]["NAME"].ToString();
                }
                catch
                {
                    drNewExistingMovementRow["STORE FROM"] = "Not Found";
                }


                drNewExistingMovementRow["M_WAREHOUSETO_ID"] =
                    resultTable.Rows[rowCounter]["M_WAREHOUSETO_ID"].ToString();

                dtWareHouseInfo =
                    this.getDatafromDataBase.getM_WarehouseInfo(null, "",
                        resultTable.Rows[rowCounter]["M_WAREHOUSETO_ID"].ToString(),
                        "", triStateBool.ignor, triStateBool.ignor, false, "AND");
                try
                {
                    drNewExistingMovementRow["STORE TO"] =
                        dtWareHouseInfo.Rows[0]["NAME"].ToString();
                }
                catch
                {
                    drNewExistingMovementRow["STORE TO"] = "Not Found";
                }


                drNewExistingMovementRow["PROCESSED"] =
                    resultTable.Rows[rowCounter]["PROCESSED"].ToString();

                if (resultTable.Rows[rowCounter]["DOCSTATUS"].ToString() == "DR")
                    drNewExistingMovementRow["DOCSTATUS"] = "DRAFTED";
                else if (resultTable.Rows[rowCounter]["DOCSTATUS"].ToString() == "CO")
                    drNewExistingMovementRow["DOCSTATUS"] = "COMPLETED";
                else if (resultTable.Rows[rowCounter]["DOCSTATUS"].ToString() == "RE")
                    drNewExistingMovementRow["DOCSTATUS"] = "REVERSED";

                this.dtExistingMovementInformation.Rows.Add(drNewExistingMovementRow);
            }
            if (this.dtExistingMovementInformation.Rows.Count > 0)            
                this.dtgMovementGridView_CellClick(sender, new DataGridViewCellEventArgs(0, 0));
                            
            if(this.dtgMoveLineGridView.SelectedCells.Count > 0)
                this.dtgMovementGridView.CurrentCell.Selected = false;
        }

        private void tlsToogleView_Click(object sender, EventArgs e)
        {
            if (this.tlsToogleView.Text == "Grid View")
            {
                this.tlsToogleView.Text = "Record View";
                this.hidColumnsInMainGridView();
                this.dtgMovementGridView.Visible = true;
                this.dtgMovementGridView.BringToFront();
                this.dtgMovementGridView.Size =
                    new Size(this.Size.Width - 12, this.dtgMovementGridView.Size.Height);
            }
            else
            {
                this.tlsToogleView.Text = "Grid View";
                this.dtgMovementGridView.SendToBack();
                this.dtgMovementGridView.Size =
                    new Size(11, this.dtgMovementGridView.Size.Height);
                this.dtgMovementGridView.Visible = false;
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
                this.ntbMovementQty.Enabled = true;                
            }
            else
            {
                this.intProductID = -1;

                this.ntbMovementQty.Amount = "0";                
                this.ddgProduct.SelectedItem = "";
                this.ntbMovementQty.Enabled = false;
                this.cmbDetailMovementOtherUOM.Items.Clear();
                this.dtDetailMovementItemAlternateUnit.Rows.Clear();
            }
            this.fillDetailTrxItemUOMComboBox();
        }


        private void cmbMoveFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.intMoveFromStoreID = -1;
            if (this.cmbMoveFrom.SelectedIndex > 0)
                this.intMoveFromStoreID =
                    int.Parse(this.dtMoveFromAccActiveWarehouseInfo.
                                Rows[this.cmbMoveFrom.SelectedIndex - 1]
                                    ["M_WAREHOUSE_ID"].ToString());
            
            this.fillDestinationStore();
        }

        private void cmbMoveTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.intMoveToStoreID = -1;
            if (this.cmbMoveTo.SelectedIndex > 0)
                this.intMoveToStoreID =
                    int.Parse(this.dtMoveToAccActiveWarehouseInfo.
                                Rows[this.cmbMoveTo.SelectedIndex - 1]
                                    ["M_WAREHOUSE_ID"].ToString());
        }


        private void ntbMovementQty_Enter(object sender, EventArgs e)
        {
            this.cmdAddMoveLine.Enabled = true;
        }

        private void ntbMovementQty_Leave(object sender, EventArgs e)
        {
            if (decimal.Parse(this.ntbMovementQty.Amount) != 0)
            {
                this.cmdAddMoveLine.Enabled = true;
            }
            else
            {
                this.cmdAddMoveLine.Enabled = false;
            }
        }


        private void cmbDetailMovementOtherUOM_SelectedIndexChanged
            (object sender, EventArgs e)
        {
            if (this.cmbDetailMovementOtherUOM.Items.Count <= 0)
                return;

            if (this.cmbDetailMovementOtherUOM.SelectedIndex ==
                this.intDetailMovementPrdPreviousUnitIndex)
                return;

            DataTable dtProductInfo =
                this.getDatafromDataBase.getM_PRODUCTInfo(null, "",
                    this.ddgProduct.SelectedRowKey.ToString(), "", "", "", "", "", "", "",
                     triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);
            if (dtProductInfo.Rows.Count <= 0)
                return;

            string stSTDUnitId = dtProductInfo.Rows[0]["M_UOM_ID"].ToString();
            decimal dcMultiplier = 1;

            if (this.cmbDetailMovementOtherUOM.SelectedIndex != 0)
            {
                if (stSTDUnitId ==
                    this.dtDetailMovementItemAlternateUnit.
                        Rows[this.cmbDetailMovementOtherUOM.SelectedIndex - 1]["M_BASE_UOM_ID"].ToString())
                {
                    stSTDUnitId =
                        this.dtDetailMovementItemAlternateUnit.
                        Rows[this.cmbDetailMovementOtherUOM.SelectedIndex - 1]["M_DRIVED_UOM_ID"].ToString();
                }
                else
                {
                    stSTDUnitId =
                        this.dtDetailMovementItemAlternateUnit.
                        Rows[this.cmbDetailMovementOtherUOM.SelectedIndex - 1]["M_BASE_UOM_ID"].ToString();
                }
            }

            if (this.cmbDetailMovementOtherUOM.SelectedIndex != 0)
            {
                if (this.intDetailMovementPrdPreviousUnitIndex == 0)
                {
                    if (dtProductInfo.Rows[0]["M_UOM_ID"].ToString() ==
                        this.dtDetailMovementItemAlternateUnit.
                            Rows[this.cmbDetailMovementOtherUOM.SelectedIndex - 1]["M_BASE_UOM_ID"].ToString())
                    {
                        dcMultiplier *=
                            decimal.Parse(this.dtDetailMovementItemAlternateUnit.
                                            Rows[this.cmbDetailMovementOtherUOM.SelectedIndex - 1]
                                                        ["MULTIPLIER"].ToString());
                    }
                    else
                    {
                        dcMultiplier /=
                            decimal.Parse(this.dtDetailMovementItemAlternateUnit.
                                            Rows[this.cmbDetailMovementOtherUOM.SelectedIndex - 1]
                                                        ["MULTIPLIER"].ToString());
                    }
                }
                else
                {
                    if (dtProductInfo.Rows[0]["M_UOM_ID"].ToString() ==
                        this.dtDetailMovementItemAlternateUnit.
                            Rows[this.intDetailMovementPrdPreviousUnitIndex - 1]["M_BASE_UOM_ID"].ToString())
                    {
                        dcMultiplier /=
                            decimal.Parse(this.dtDetailMovementItemAlternateUnit.
                                            Rows[this.intDetailMovementPrdPreviousUnitIndex - 1]
                                                        ["MULTIPLIER"].ToString());
                    }
                    else
                    {
                        dcMultiplier *=
                            decimal.Parse(this.dtDetailMovementItemAlternateUnit.
                                            Rows[this.intDetailMovementPrdPreviousUnitIndex - 1]
                                                        ["MULTIPLIER"].ToString());
                    }

                    if (dtProductInfo.Rows[0]["M_UOM_ID"].ToString() ==
                        this.dtDetailMovementItemAlternateUnit.
                            Rows[this.cmbDetailMovementOtherUOM.SelectedIndex - 1]["M_BASE_UOM_ID"].ToString())
                    {
                        dcMultiplier *=
                            decimal.Parse(this.dtDetailMovementItemAlternateUnit.
                                            Rows[this.cmbDetailMovementOtherUOM.SelectedIndex - 1]
                                                        ["MULTIPLIER"].ToString());
                    }
                    else
                    {
                        dcMultiplier /=
                            decimal.Parse(this.dtDetailMovementItemAlternateUnit.
                                            Rows[this.cmbDetailMovementOtherUOM.SelectedIndex - 1]
                                                        ["MULTIPLIER"].ToString());
                    }
                }
            }
            else if (this.intDetailMovementPrdPreviousUnitIndex > 0)
            {
                if (dtProductInfo.Rows[0]["M_UOM_ID"].ToString() ==
                        this.dtDetailMovementItemAlternateUnit.
                            Rows[this.intDetailMovementPrdPreviousUnitIndex - 1]["M_BASE_UOM_ID"].ToString())
                {
                    dcMultiplier /=
                        decimal.Parse(this.dtDetailMovementItemAlternateUnit.
                                        Rows[this.intDetailMovementPrdPreviousUnitIndex - 1]
                                                    ["MULTIPLIER"].ToString());
                }
                else
                {
                    dcMultiplier *=
                        decimal.Parse(this.dtDetailMovementItemAlternateUnit.
                                        Rows[this.intDetailMovementPrdPreviousUnitIndex - 1]
                                                    ["MULTIPLIER"].ToString());
                }
            }

            DataTable dtUnitInfo =
                    this.getDatafromDataBase.getM_UOMInfo(null, "",
                        stSTDUnitId, "", "", triStateBool.ignor, false, "AND");
            this.ntbMovementQty.StandardPrecision =
                int.Parse(dtUnitInfo.Rows[0]["STDPRECISION"].ToString());


            this.ntbMovementQty.Amount =
                (this.getDatafromDataBase.roundOff(
                            (decimal.Parse(this.ntbMovementQty.Amount) * dcMultiplier),
                            uint.Parse(this.ntbMovementQty.StandardPrecision.ToString()))).ToString();

            this.intDetailMovementPrdPreviousUnitIndex =
                this.cmbDetailMovementOtherUOM.SelectedIndex;
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
                this.ntbMovementQty.Amount = "0";
                this.ddgProduct.SelectedItem = "";
                this.ntbMovementQty.Enabled = false;
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

                this.ntbMovementQty.Enabled = true;
            }
            this.fillDetailTrxItemUOMComboBox();
        }
                
        private void cmdAddMoveLine_Click(object sender, EventArgs e)
        {
            if (this.intProductID.ToString() == "0" ||
                this.intProductID.ToString() == "" ||
                this.ntbMovementQty.Amount == "" ||
                this.ntbMovementQty.Amount == "0")
            {
                return;
            }

            this.cmbDetailMovementOtherUOM.SelectedIndex = 0;
            DataTable dtProductInfo =
                this.getDatafromDataBase.getM_PRODUCTInfo(null, "", 
                        this.intProductID.ToString(),
                        "", "", "", "", "", "", "", triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);

            if (dtProductInfo.Rows.Count != 1 || this.intProductID == 0)
            {
                goto finalLine;
            }
   
            
            if (this.cmdAddMoveLine.Text.ToUpperInvariant() == "ADD")
            {
                DataRow drNewTentaiveMovementDetail = this.dtTentativeMovementDetail.NewRow();

                drNewTentaiveMovementDetail["REMOVE"] = "remove";
                drNewTentaiveMovementDetail["M_PRODUCT_ID"] = this.intProductID.ToString();
                drNewTentaiveMovementDetail["LINE"] = this.dtTentativeMovementDetail.Rows.Count + 1;
                drNewTentaiveMovementDetail["NAME"] = this.ddgProduct.SelectedItem;
                drNewTentaiveMovementDetail["Move Qty"] =
                    this.ntbMovementQty.Amount;
                drNewTentaiveMovementDetail["UNIT"] =
                    this.cmbDetailMovementOtherUOM.SelectedItem.ToString();

                DataTable dtUOMInfo =
                       this.getDatafromDataBase.getM_PRODUCTInfo(null, "", this.intProductID.ToString(),
                            "", "", "", "", "", "", "", 
                                    triStateBool.yes, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);
                if (this.getDatafromDataBase.checkIfTableContainesData(dtUOMInfo))
                {
                    drNewTentaiveMovementDetail["M_UOM_ID"] =
                        dtUOMInfo.Rows[0]["M_UOM_ID"].ToString();
                }
                
                drNewTentaiveMovementDetail["DESCRIPTION"] = this.txtMoveLineDescription.Text;

                this.dtTentativeMovementDetail.Rows.Add(drNewTentaiveMovementDetail);
            }
            else if (this.cmdAddMoveLine.Text.ToUpperInvariant() == "MODIFY")
            {
                if (this.dtgMoveLineGridView.SelectedRows.Count < 1)
                {
                    goto finalLine;
                }
                int crrntSlctRwIndx =
                    this.dtgMoveLineGridView.SelectedRows[0].Index;

                this.dtTentativeMovementDetail.Rows[crrntSlctRwIndx]["REMOVE"] = "remove";
                this.dtTentativeMovementDetail.Rows[crrntSlctRwIndx]["M_PRODUCT_ID"] =
                        this.intProductID.ToString();
                this.dtTentativeMovementDetail.Rows[crrntSlctRwIndx]["NAME"] =
                        this.ddgProduct.SelectedItem;
                this.dtTentativeMovementDetail.Rows[crrntSlctRwIndx]["Move Qty"] =
                        this.ntbMovementQty.Value;
                this.dtTentativeMovementDetail.Rows[crrntSlctRwIndx]["UNIT"] =
                    this.cmbDetailMovementOtherUOM.SelectedItem.ToString();

                DataTable dtUOMInfo =
                       this.getDatafromDataBase.getM_PRODUCTInfo(null, "", this.intProductID.ToString(),
                            "", "", "", "", "", "", "", 
                                    triStateBool.yes, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);
                if (this.getDatafromDataBase.checkIfTableContainesData(dtUOMInfo))
                {
                    this.dtTentativeMovementDetail.Rows[crrntSlctRwIndx]["M_UOM_ID"] =
                        dtUOMInfo.Rows[0]["M_UOM_ID"].ToString();
                }

                this.dtTentativeMovementDetail.Rows[crrntSlctRwIndx]["DESCRIPTION"] =
                        this.txtMoveLineDescription.Text;
            }
        finalLine:
            this.intDetailMovementPrdPreviousUnitIndex = -1;

            this.cmdAddMoveLine.Text = "ADD";
            this.cmdAddMoveLine.Enabled = false;

            this.ddgProduct.SelectedRow.Clear();
            this.ddgProduct_selectedItemChanged(sender, e);

            this.ntbMovementQty.Amount = "0";
            this.cmbDetailMovementOtherUOM.Items.Clear();
            this.txtMoveLineDescription.Text = "";

            this.dtgMoveLineGridView.BackgroundColor =
                this.dtgMovementGridView.BackgroundColor;

            if(this.dtgMoveLineGridView.SelectedCells.Count > 0)
                this.dtgMoveLineGridView.CurrentCell.Selected = false;
        }


        private void dtgMoveLineGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgMoveLineGridView.SelectedRows.Count < 1 ||
                this.blcurrentMovementProcessed)
            {
                if (this.dtgMoveLineGridView.SelectedCells.Count > 0)
                    this.dtgMoveLineGridView.CurrentCell.Selected = false;
                return;
            }

            int currentSelectedRowIndex =
                this.dtgMoveLineGridView.SelectedRows[0].Index;
            if (this.dtgMoveLineGridView.CurrentCell.OwningColumn.Index == 1 &&
                this.dtgMoveLineGridView.CurrentCell.OwningColumn.Name == "REMOVE" &&
                this.dtgMoveLineGridView.CurrentCell.Value.ToString() == "remove" &&
                this.dtgMoveLineGridView.CurrentCell.OwningColumn.HeaderText == "")
            {
                string stMovementDetailID =
                    this.dtTentativeMovementDetail.
                        Rows[currentSelectedRowIndex]
                            ["T_MOVEMENTDETAIL_ID"].ToString();

                if (stMovementDetailID != "" &&
                    this.intMovementID > 0)
                {
                    DataTable dtMovementDetailInfo =
                        this.getDatafromDataBase.getT_MOVEMENTDETAILInfo(null, "",
                                stMovementDetailID, this.intMovementID.ToString(),
                                "", "", new DateTime(), false, "", 
                                triStateBool.ignor, false, "AND");

                    if (this.getDatafromDataBase.
                            checkIfTableContainesData(dtMovementDetailInfo))
                    {
                        this.getDatafromDataBase.
                                changeDataBaseTableData(dtMovementDetailInfo,
                                    "T_MOVEMENTDETAIL", "DELETE");
                    }
                }

                this.dtTentativeMovementDetail.Rows.RemoveAt(currentSelectedRowIndex);
                for (int detailRowCounter = 0;
                   detailRowCounter <= this.dtTentativeMovementDetail.Rows.Count - 1; detailRowCounter++)
                {
                    this.dtTentativeMovementDetail.Rows[detailRowCounter]["LINE"] = detailRowCounter + 1;
                }
            }
            else
            {
                this.cmdAddMoveLine.Text = "Modify";

                this.intProductID =
                    int.Parse(this.dtTentativeMovementDetail.Rows[currentSelectedRowIndex]
                                                                ["M_PRODUCT_ID"].ToString());

                this.ddgProduct.SelectedRowKey =
                    this.dtTentativeMovementDetail.Rows[currentSelectedRowIndex]
                                                        ["M_PRODUCT_ID"].ToString();
                this.ddgProduct.SelectedItem =
                    this.dtTentativeMovementDetail.Rows[currentSelectedRowIndex]
                                                        ["NAME"].ToString();
                this.ntbMovementQty.Amount =
                    this.dtTentativeMovementDetail.Rows[currentSelectedRowIndex]
                                                        ["Move Qty"].ToString();
                this.fillDetailTrxItemUOMComboBox();

                this.txtMoveLineDescription.Text =
                    this.dtTentativeMovementDetail.Rows[currentSelectedRowIndex]
                                                        ["DESCRIPTION"].ToString();                

                this.cmdAddMoveLine.Enabled = true;
                this.ntbMovementQty.Enabled = true;                
            }
        }
        
        private void dtgMovementGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgMovementGridView.SelectedRows.Count < 1)
            {
                return;
            }

            int currentSelectedRowIndex =
                this.dtgMovementGridView.SelectedRows[0].Index;

            this.intMovementID =
                int.Parse(this.dtgMovementGridView.Rows[currentSelectedRowIndex].
                        Cells["T_MOVEMENT_ID"].Value.ToString());


            this.stOrganisationID =
                this.dtgMovementGridView.Rows[currentSelectedRowIndex].
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
                if (this.dtgMovementGridView.Rows[currentSelectedRowIndex].
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
                this.dtgMovementGridView.Rows[currentSelectedRowIndex].
                        Cells["DOCUMENTNO"].Value.ToString();

            this.dtpMoveDate.Value =
                DateTime.Parse(this.dtgMovementGridView.Rows[currentSelectedRowIndex].
                        Cells["MOVEDATE"].Value.ToString());

            this.txtDescription.Text =
                this.dtgMovementGridView.Rows[currentSelectedRowIndex].
                        Cells["DESCRIPTION"].Value.ToString();
            
            this.cmbMoveFrom.Text = 
                    this.dtgMovementGridView.Rows[currentSelectedRowIndex].
                        Cells["STORE FROM"].Value.ToString();

            this.intMoveFromStoreID =
                int.Parse(this.dtgMovementGridView.Rows[currentSelectedRowIndex].
                        Cells["M_WAREHOUSEFROM_ID"].Value.ToString());
            
            this.cmbMoveTo.Text =
                this.dtgMovementGridView.Rows[currentSelectedRowIndex].
                        Cells["STORE TO"].Value.ToString();

            this.intMoveToStoreID =
                int.Parse(this.dtgMovementGridView.Rows[currentSelectedRowIndex].
                        Cells["M_WAREHOUSETO_ID"].Value.ToString());
            
            if (this.dtgMovementGridView.Rows[currentSelectedRowIndex].
                        Cells["PROCESSED"].Value.ToString() == "Y")
                this.blcurrentMovementProcessed = true;
            else
                this.blcurrentMovementProcessed = false;
            
                        
            DataTable dtMovementDetailInformation =
                this.getDatafromDataBase.getT_MOVEMENTDETAILInfo(null, "", "",
                    this.intMovementID.ToString(), "", "", new DateTime(), false,"", triStateBool.ignor,
                    false, "AND");

            this.dtTentativeMovementDetail.Clear();

            for (int rowCounter = 0;
                rowCounter <= dtMovementDetailInformation.Rows.Count - 1;
                rowCounter++)
            {
                DataRow drExistingMovementDetailRow =
                    this.dtTentativeMovementDetail.NewRow();

                drExistingMovementDetailRow["T_MOVEMENTDETAIL_ID"] =
                    dtMovementDetailInformation.Rows[rowCounter]["T_MOVEMENTDETAIL_ID"].ToString();
                drExistingMovementDetailRow["T_MOVEMENT_ID"] =
                    dtMovementDetailInformation.Rows[rowCounter]["T_MOVEMENT_ID"].ToString();

                drExistingMovementDetailRow["REMOVE"] = "remove";
                drExistingMovementDetailRow["LINE"] =
                    dtMovementDetailInformation.Rows[rowCounter]["LINE"].ToString();
                drExistingMovementDetailRow["M_PRODUCT_ID"] =
                    dtMovementDetailInformation.Rows[rowCounter]["M_PRODUCT_ID"].ToString();

                DataTable dtPrdInfo =
                    this.getDatafromDataBase.getM_PRODUCTInfo(null, "",
                            dtMovementDetailInformation.Rows[rowCounter]["M_PRODUCT_ID"].ToString(),
                            "", "", "", "", "", "", "", 
                            triStateBool.ignor, false, "AND",generalResultInformation.dbBulkDataRetrivalSize);

                if (dtPrdInfo.Rows.Count > 0)
                {
                    drExistingMovementDetailRow["NAME"] =
                        dtPrdInfo.Rows[0]["NAME"].ToString();
                }

                drExistingMovementDetailRow["Move Qty"] =
                    dtMovementDetailInformation.Rows[rowCounter]["MOVEQUANTITY"].ToString();

                DataTable dtUnitInfo =
                    this.getDatafromDataBase.getM_UOMInfo(null, "",
                            dtMovementDetailInformation.Rows[rowCounter]["M_UOM_ID"].ToString(),
                                "", "", triStateBool.ignor, false, "AND");

                if (dtUnitInfo.Rows.Count > 0)
                {
                    drExistingMovementDetailRow["UNIT"] =
                        dtUnitInfo.Rows[0]["ABBREVATION"].ToString();
                }

                drExistingMovementDetailRow["M_UOM_ID"] =
                    dtMovementDetailInformation.Rows[rowCounter]["M_UOM_ID"].ToString();
                
                drExistingMovementDetailRow["DESCRIPTION"] =
                    dtMovementDetailInformation.Rows[rowCounter]["DESCRIPTION"].ToString();

                this.dtTentativeMovementDetail.Rows.Add(drExistingMovementDetailRow);
            }
            this.dtgMoveLineGridView.DataSource = this.dtTentativeMovementDetail;
            
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
            if (this.intMovementID <= 0)
                return;

            if (!System.IO.File.Exists("crptMaterialMovement.rpt"))
            {
                MessageBox.Show("Unable To find Report Builder. \n Please Contact Your Administrator.",
                    "Printing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmPrintViewer newPrintJobView = new frmPrintViewer();

            string fileName = "crptMaterialMovement.rpt";
            dtsPOSDocumentData dsNewMovement = new dtsPOSDocumentData();

            dsNewMovement.Tables["dtMovementSummary"].Clear();
            dsNewMovement.Tables["dtMovementDetail"].Clear();
                       

            DataTable dtV_MomentDetail =
                this.getDatafromDataBase.getV_MOVEMENTDETAILInfo(null, "", 
                                this.intMovementID.ToString(), "", "", "", "", "", "", "",
                                new DateTime(), false, triStateBool.ignor, triStateBool.ignor,
                                transactionStatus.ignor, false, "AND");

            if (!this.getDatafromDataBase.checkIfTableContainesData(dtV_MomentDetail))
            {
                MessageBox.Show("Unable To Build Report Data. \n Please Contact Your Administrator.",
                    "Printing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRow drNewMovement =
                dsNewMovement.Tables["dtMovementSummary"].NewRow();

            drNewMovement["MovementId"] =
                int.Parse(dtV_MomentDetail.Rows[0]["T_MOVEMENT_ID"].ToString());
            drNewMovement["DocumentName"] = "Material Movement";
            drNewMovement["StoreFrom"] =
                dtV_MomentDetail.Rows[0]["MOVEDFROM"].ToString();
            drNewMovement["StoreTo"] =
                dtV_MomentDetail.Rows[0]["MOVEDTO"].ToString(); 
            drNewMovement["RequestNumber"] = "";
            drNewMovement["DocumentNumber"] =
                dtV_MomentDetail.Rows[0]["DOCUMENTNO"].ToString();
            drNewMovement["DocumentDate"] =
                DateTime.Parse(dtV_MomentDetail.Rows[0]["MOVEDATE"].ToString()).ToString("MMM-dd-yyyy");
            drNewMovement["DocumentNote"] =
                dtV_MomentDetail.Rows[0]["DESCRIPTION"].ToString();

            drNewMovement["PreparedBy"] = "";
            drNewMovement["CheckdBy"] = "";
            drNewMovement["ApprovedBy"] = "";
            drNewMovement["rePrint"] = "";

            dsNewMovement.Tables["dtMovementSummary"].Rows.Add(drNewMovement);

            for (int movementDetailCounter = 0;
                 movementDetailCounter <=
                    dtV_MomentDetail.Rows.Count - 1;
                 movementDetailCounter++)
            {
                DataRow drNewMovementDetail =
                    dsNewMovement.Tables["dtMovementDetail"].NewRow();

                drNewMovementDetail["MovementDetailId"] =
                    int.Parse(dtV_MomentDetail.
                        Rows[movementDetailCounter]["T_MOVEMENTDETAIL_ID"].ToString());
                drNewMovementDetail["MovementId"] =
                    int.Parse(dtV_MomentDetail.
                        Rows[movementDetailCounter]["T_MOVEMENT_ID"].ToString());
                drNewMovementDetail["Sn."] =
                    dtV_MomentDetail.
                        Rows[movementDetailCounter]["LINE"].ToString();
                drNewMovementDetail["Description"] =
                    dtV_MomentDetail.
                        Rows[movementDetailCounter]["PRODUCT"].ToString();
                drNewMovementDetail["Unit"] =
                    dtV_MomentDetail.
                        Rows[movementDetailCounter]["UOM"].ToString();
                drNewMovementDetail["Quantity"] =
                    decimal.Parse(dtV_MomentDetail.
                        Rows[movementDetailCounter]["MOVEQUANTITY"].ToString());
                drNewMovementDetail["Remark"] = "";
                drNewMovementDetail["comment"] =
                    dtV_MomentDetail.
                        Rows[movementDetailCounter]["LINE_DESCRIPTION"].ToString();

                drNewMovementDetail["CODE2"] =
                    dtV_MomentDetail.
                        Rows[movementDetailCounter]["CODE2"].ToString();
                drNewMovementDetail["BAR"] = "*" +
                    dtV_MomentDetail.
                        Rows[movementDetailCounter]["BAR"].ToString() + "*";

                dsNewMovement.Tables["dtMovementDetail"].Rows.Add(drNewMovementDetail);
            }

            newPrintJobView.setUpThePreviewArea(fileName, dsNewMovement);

            newPrintJobView.ShowDialog(this);

        }

        private void dtgMoveLineGridView_Sorted(object sender, EventArgs e)
        {        
            this.intDetailMovementPrdPreviousUnitIndex = -1;

            this.cmdAddMoveLine.Text = "ADD";
            this.cmdAddMoveLine.Enabled = false;

            this.ddgProduct.SelectedRow.Clear();
            this.ddgProduct_selectedItemChanged(sender, e);

            this.ntbMovementQty.Amount = "0";
            this.cmbDetailMovementOtherUOM.Items.Clear();
            this.txtMoveLineDescription.Text = "";

            this.dtgMoveLineGridView.BackgroundColor =
                this.dtgMovementGridView.BackgroundColor;
            
            if (this.dtgMoveLineGridView.SelectedCells.Count > 0)
                this.dtgMoveLineGridView.CurrentCell.Selected = false;
        }
        

    }
}
