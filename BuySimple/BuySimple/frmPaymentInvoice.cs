using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BuySimple
{
    public partial class frmPurchasePaymentInvoice : Form
    {
        bool currentViewIsgridView = false;        
        bool currentPaymentIsFromCashBook = false;
        bool currentPaymentIsCollecatable = false;
        bool usersCanEditRecordDetail = true;
        bool changeIsMadeToCurrentRecord = false;
        bool paymentAmountHasChanged = false;
        bool paymentSourceHasChanged = false;
        bool paymentDistributableStatusChanged = false;
        bool paymentActiveStatusChanged = false;
        bool paymentEstimateStatusHasChanged = false;
        bool costClosed = false;

        int intCurrentPaymentRowIndex = -1;

        string styleName = "";

        string stCurrentPaymentId = "";
        string stDmlType = "";
        string stSettingFile = dbSettingInformationHandler.settingFilePath;        
        string stVendorId = "";
        string stCashBookId = "";        
        string stBankAccountId = "";
        string stChargeId = "";
        string stTaxId = "";

        Color clMissingFieldColor = Color.Red;
        Color clChangedFieldColor = Color.Blue;
        Color clNormalFieldColor = Color.Black;

        DataTable dtAllVendors = new DataTable();
        DataTable dtPaymentSource = new DataTable();
        DataTable dtPaymentReason = new DataTable();
        DataTable dtPurchaseOrders = new DataTable();
        DataTable dtOrderCommercialInvoice = new DataTable();
        DataTable dtCommercialInvoice = new DataTable();
        DataTable dtCommercialInvoiceLine = new DataTable();
        DataTable dtPayment_InvoceLine = new DataTable();
        DataTable dtNewPaymentRecord = new DataTable();
        DataTable dtexistingPaymentRecord = new DataTable();

        DataTable dtValidPurchaseOrders = new DataTable();
        DataTable dtValidCommercialInvoice = new DataTable();
        DataTable dtValidVendors = new DataTable();
        
        DataTable dtPaymentDetailInfo = new DataTable();
        DataTable dtInvoiceDetail = new DataTable();

        DataTable dtOrgSelectionCriterion = new DataTable();

        dataBuilder getDataFromDb = new dataBuilder();
        businessRule getDataAccordingToRule = new businessRule();

        public void resetLableColor()
        {
            this.lblInvoiceNumber.ForeColor = clNormalFieldColor;
            this.lblVendorName.ForeColor = clNormalFieldColor;
            this.lblInvoiceDate.ForeColor = clNormalFieldColor;
            this.lblPayedFrom.ForeColor = clNormalFieldColor;
            this.lblPaymentAmount.ForeColor = clNormalFieldColor;
            this.ckIsEstimateAmount.ForeColor = clNormalFieldColor;
            this.ckIsActive.ForeColor = clNormalFieldColor;
            this.ckIsAmountDistributed.ForeColor = clNormalFieldColor;
            this.lblDescriptionComment.ForeColor = clNormalFieldColor;
            this.lblOrderNumber.ForeColor = clNormalFieldColor;
            this.lblCommercialInvoice.ForeColor = this.clNormalFieldColor;
            this.lblPaymentReason.ForeColor = clNormalFieldColor;
            this.lblPaymentType.ForeColor = clNormalFieldColor;
            this.ckSelectAllLines.ForeColor = this.clNormalFieldColor;
        }

        public void clearForm()
        {
            this.stCurrentPaymentId = "";
            this.stVendorId = "";

            this.resetLableColor();

            this.txtInvoiceNumber.Enabled = true;
            this.dtpInvoiceDate.Enabled = true;
            this.ddgVendor.Enabled = true;
            this.ddgPayedFrom.Enabled = true;
            this.ddgPaymentReason.Enabled = true;
            this.ckIsActive.Enabled = true;
            this.ckIsEstimateAmount.Enabled = true;
            this.ckIsAmountDistributed.Enabled = true;
            this.ckSelectAllLines.Enabled = false;
            this.ntbAmount.Enabled = true;
            this.cmbPaymentType.Enabled = true;
            this.ddgPurchaseOrders.Enabled = true;
            this.ddgCommercialInvoice.Enabled = true;

            this.usersCanEditRecordDetail = true;
            this.costClosed = false;

            this.tscmdDelete.Enabled = true;

            this.txtAccumulatedAmount.Text = "0.00";
            this.txtDescriptionComment.Text = "";
            this.txtInvoiceNumber.Text = "";
            this.txtPaymentCount.Text = "0";
            this.txtPurchaseOrderDate.Text = "";
            this.txtStatus.Text = "";
            this.txtCollactableAmount.Text = "0.00";
            this.txtRemainingDistribution.Text = "0.00";
            this.txtRemainingDistributionP_tage.Text = "0.00%";

            this.ddgVendor.SelectedItem = "";
            this.ddgVendor.SelectedRowKey = null;
            this.ddgVendor.SelectedRow.Rows.Clear();            

            this.ddgPayedFrom.SelectedItem = "";
            this.ddgPayedFrom.SelectedRowKey = null;

            this.ddgPaymentReason.SelectedItem = "";
            this.ddgPaymentReason.SelectedRowKey = null;

            this.cmbPaymentType.SelectedIndex = 0;

            this.ddgPurchaseOrders.SelectedItem = "";
            this.ddgPurchaseOrders.SelectedRowKey = null;

            this.ddgCommercialInvoice.SelectedItem = "";
            this.ddgCommercialInvoice.SelectedRowKey = null;

            
            this.ntbAmount.Amount = "0";
            
            this.dtpInvoiceDate.Value = DateTime.Today;

            this.ckIsActive.Checked = true;
            this.ckIsEstimateAmount.Checked = false;
            this.ckIsAmountDistributed.Checked = false;

            this.dtgPaymentItemDetail.DataSource = null;

            this.txtInvoiceNumber.Focus();            
        }

        public void reLoadSearchResult()
        {
            this.Enabled = false;
            //if (generalResultInformation.searchCritrion.Columns.Count > 0 &&
            //    generalResultInformation.logicConnector != "")
            //{
            //    //generalResultInformation.searchResult =
            //    //    getDataFromDb.getPaymentRecordAccordingToCriterion(generalResultInformation.searchCritrion,
            //    //    generalResultInformation.logicConnector);
            //}

            //this.establishExistingPaymentRecordStructure();
            //this.filldtExistingPaymentRecordToPaymentGridView();
            //if (dtgPaymentGridView.Rows.Count > 0)
            //    dtgPaymentGridView.Rows[0].Selected = true;           
            //this.fillCurrentGirdDataToForm();
            //this.enableDisableNavigationButtons();
            //this.enableDisableSaveDeleteNewButtons();
            //this.Enabled = true;

            this.dtPaymentSource = this.getDataAccordingToRule.generatePaymentSource(true);
            this.dtPaymentReason = this.getDataAccordingToRule.generatePaymentReason(true);
            this.establishValidPerformaInvoices();
            this.dtCommercialInvoice =
                this.establishValidCommercialInvoices("");

        }
        
        public void enableDisableSaveDeleteNewButtons()
        {            
            if (generalResultInformation.userprevilageIsReadOnly )
            {
                this.tscmdDelete.Enabled = false;
                this.tscmdNew.Enabled = false;
                this.tscmdRecord.Enabled = false;
                this.tscmdRefresh.Enabled = false;
            }
            else if (this.dtgPaymentGridView.Rows.Count <= 0)
            {
                this.tscmdDelete.Enabled = false;
                this.tscmdNew.Enabled = true;
                this.tscmdRecord.Enabled = true;
            }
            else if(this.costClosed)
            {
                this.tscmdDelete.Enabled = false;
                this.tscmdNew.Enabled = true;
                this.tscmdRecord.Enabled = false;
                this.tscmdRefresh.Enabled = false;
            }
            else
            {
                this.tscmdDelete.Enabled = true;
                this.tscmdNew.Enabled = true;
                this.tscmdRecord.Enabled = true;
                this.tscmdRefresh.Enabled = true;
            }

        }
                
        public frmPurchasePaymentInvoice()
        {
            InitializeComponent();
        }
        
        public void enableDisableNavigationButtons()
        {
            if (this.dtgPaymentGridView.Rows.Count < 2 ||
                this.dtgPaymentGridView.SelectedRows.Count == 0)
            {
                this.tscmdFirstRecord.Enabled = false;
                this.tscmdPreviousRecord.Enabled = false;
                this.tscmdNextRecord.Enabled = false;
                this.tscmdLastRecord.Enabled = false;

            }

            else if (this.dtgPaymentGridView.SelectedRows[0].Index == 0)
            {
                this.tscmdFirstRecord.Enabled = false;
                this.tscmdPreviousRecord.Enabled = false;
                this.tscmdNextRecord.Enabled = true;
                this.tscmdLastRecord.Enabled = true;

            }

            else if (this.dtgPaymentGridView.SelectedRows[0].Index ==
                this.dtgPaymentGridView.Rows.Count - 1)
            {
                this.tscmdFirstRecord.Enabled = true;
                this.tscmdPreviousRecord.Enabled = true;
                this.tscmdNextRecord.Enabled = false;
                this.tscmdLastRecord.Enabled = false;

            }
            else
            {
                this.tscmdFirstRecord.Enabled = true;
                this.tscmdPreviousRecord.Enabled = true;
                this.tscmdNextRecord.Enabled = true;
                this.tscmdLastRecord.Enabled = true;
            }
        }

        public void enableDisableFormElement()
        {

            this.showRemainingDistibutableAmount();

        }

        public void showRemainingDistibutableAmount()
        {
            bool isRmngAmtVisible = 
                this.ckIsAmountDistributed.Checked && 
                !this.ntbAmount.Enabled && 
                this.cmbPaymentType.SelectedItem.ToString().ToUpperInvariant() != "PAYMENT" &&
                this.cmbPaymentType.SelectedItem.ToString().ToUpperInvariant() != "COLLATERAL";

            this.txtRemainingDistribution.Visible = isRmngAmtVisible;
            this.txtRemainingDistributionP_tage.Visible = isRmngAmtVisible;
            this.lblAmountRemaining.Visible = isRmngAmtVisible;
            this.lblPercentageRemaining.Visible = isRmngAmtVisible;

            decimal rmngAmt = 0;
            decimal distributedAmt = 0;

            ctlNumberTextBox ntbAmnt = new ctlNumberTextBox();
            ntbAmnt.Amount = "0.00";
            ntbAmnt.StandardPrecision = 2;

            this.txtRemainingDistribution.Text = "0.00";
            this.txtRemainingDistributionP_tage.Text = "0.00";


            decimal paymentAmt = decimal.Parse(this.ntbAmount.Amount);

            if (this.stCurrentPaymentId == "" || !isRmngAmtVisible || paymentAmt == 0)
            {
                return;
            }

            DataTable dtInvoiceLinePayment = 
                this.getDataFromDb.getPM_C_PPAYMENT_INVOCELINEInfo(null, "", "", "",
                        this.stCurrentPaymentId, "", "", "", "", triaStateBool.yes,
                        true, triaStateBool.Ignor, false, "AND");

            if (this.getDataFromDb.checkIfTableContainesData(dtInvoiceLinePayment))
            {
                for (int rowCounter = 0; rowCounter <= dtInvoiceLinePayment.Rows.Count - 1; rowCounter++)
                {
                    distributedAmt +=
                        decimal.Parse(dtInvoiceLinePayment.Rows[rowCounter]["AMOUNTSHARED"].ToString());
                }
            }
            rmngAmt = paymentAmt - distributedAmt;

            if (rmngAmt == 0)
            {
                this.txtRemainingDistribution.Visible = false;
                this.txtRemainingDistributionP_tage.Visible = false;
                this.lblAmountRemaining.Visible = false;
                this.lblPercentageRemaining.Visible = false;
                return;
            }

            ntbAmnt.StandardPrecision = 4;

            ntbAmnt.Amount = (rmngAmt).ToString();
            this.txtRemainingDistribution.Text = ntbAmnt.Value;

            ntbAmnt.Amount = ((rmngAmt / paymentAmt) * 100).ToString();
            this.txtRemainingDistributionP_tage.Text = ntbAmnt.Value + "%";

        }


        private bool paymetPeriodIsOpen()
        {
            DataTable dtDocPeriodInfo =
                this.getDataFromDb.getC_PERIODInfo(null, "", "", this.dtpInvoiceDate.Value, true, false, "AND");

            if (!this.getDataFromDb.checkIfTableContainesData(dtDocPeriodInfo))
            {
                MessageBox.Show("Buy Simple", "Period is not open", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string stDocumentBaseType = "API";
            string stDocPeriodId = dtDocPeriodInfo.Rows[0]["C_PERIOD_ID"].ToString();

            DataTable dtDocBasePeriodControlInfo =
                this.getDataFromDb.getC_PERIODCONTROLInfo(null, "", "", stDocPeriodId, stDocumentBaseType, true, false, "AND");

            if (!this.getDataFromDb.checkIfTableContainesData(dtDocBasePeriodControlInfo))
            {
                MessageBox.Show("Buy Simple", "Period is not open", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (dtDocBasePeriodControlInfo.Rows[0]["PERIODSTATUS"].ToString() != "O")
                {
                    MessageBox.Show("Buy Simple", "Period is not open", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                    return true;
            }
        }

        public bool checkAllFieldsExistForInsertion()
        {
            bool errorFound = false;
            if (this.txtInvoiceNumber.Text == "")
            {
                this.lblInvoiceNumber.ForeColor = this.clMissingFieldColor;
                errorFound = true;
            }
            else
            { this.lblInvoiceNumber.ForeColor = this.clNormalFieldColor; }

            if (this.cmbPaymentType.SelectedItem.ToString().ToUpperInvariant() != "INVOICE" &&
                this.cmbPaymentType.SelectedItem.ToString().ToUpperInvariant() != "NOTE")
            {
                if (this.ddgPayedFrom.SelectedRowKey == null)
                {
                    this.lblPayedFrom.ForeColor = this.clMissingFieldColor;
                    errorFound = true;
                }
                else
                { this.lblPayedFrom.ForeColor = this.clNormalFieldColor; }
            }
            else
            {
                if (this.ddgPayedFrom.SelectedRowKey != null)
                {
                    this.lblPayedFrom.ForeColor = this.clMissingFieldColor;
                    errorFound = true;
                }
                else
                { this.lblPayedFrom.ForeColor = this.clNormalFieldColor; } 
            }

            

            if (this.stVendorId == "")
            {
                this.lblVendorName.ForeColor = this.clMissingFieldColor;
                errorFound = true;
            }
            else
            { this.lblVendorName.ForeColor = this.clNormalFieldColor; }

            if (!paymetPeriodIsOpen())
            {
                this.lblInvoiceDate.ForeColor = this.clMissingFieldColor;
                errorFound = true;
            }
            else
            { this.lblInvoiceDate.ForeColor = this.clNormalFieldColor; }


            if (this.ntbAmount.Amount == "0" || this.ntbAmount.Amount == "")
            {
                this.lblPaymentAmount.ForeColor = this.clMissingFieldColor;
                errorFound = true;
            }
            else
            { this.lblPaymentAmount.ForeColor = this.clNormalFieldColor; }

            if (this.ddgPurchaseOrders.SelectedRowKey == null)
            {
                this.lblOrderNumber.ForeColor = this.clMissingFieldColor;
                errorFound = true;
            }
            else
            { this.lblOrderNumber.ForeColor = clNormalFieldColor; }

            bool checkedItemExist = false;
            if (!this.ckIsAmountDistributed.Checked &&
                this.cmbPaymentType.SelectedItem.ToString().ToUpperInvariant() != "COLLATERAL")
            {
                if (this.ddgCommercialInvoice.SelectedRowKey == null)
                {
                    this.lblCommercialInvoice.ForeColor = this.clMissingFieldColor;
                    errorFound = true;
                }
                else
                { this.lblCommercialInvoice.ForeColor = this.clNormalFieldColor; }


                if (this.cmbPaymentType.SelectedItem.ToString().ToUpperInvariant() != "PAYMENT")
                {
                    for (int rowCounter = this.dtCommercialInvoiceLine.Rows.Count - 1; rowCounter >= 0; rowCounter--)
                    {
                        if (Convert.ToBoolean(this.dtCommercialInvoiceLine.Rows[rowCounter]["Check"]))
                        {
                            checkedItemExist = true;
                            break;
                        }
                    }
                    if (!checkedItemExist)
                    {
                        errorFound = true;
                        this.ckSelectAllLines.ForeColor = this.clMissingFieldColor;
                    }
                    else
                    {
                        this.ckSelectAllLines.ForeColor = this.clNormalFieldColor;
                    }
                }
                else
                {
                    for (int rowCounter = this.dtCommercialInvoiceLine.Rows.Count - 1; rowCounter >= 0; rowCounter--)
                    {
                        if (Convert.ToBoolean(this.dtCommercialInvoiceLine.Rows[rowCounter]["Check"]))
                        {
                            checkedItemExist = true;
                            break;
                        }
                    }
                    if (checkedItemExist)
                    {
                        errorFound = true;
                        this.ckSelectAllLines.ForeColor = this.clMissingFieldColor;
                    }
                    else
                    {
                        this.ckSelectAllLines.ForeColor = this.clNormalFieldColor;
                    } 
                }                
            }
            else
            { this.lblCommercialInvoice.ForeColor = this.clNormalFieldColor; }

            if (this.ddgPaymentReason.SelectedRowKey == null)
            {
                this.lblPaymentReason.ForeColor = this.clMissingFieldColor;
                errorFound = true;
            }
            else
            { this.lblPaymentReason.ForeColor = this.clNormalFieldColor; }

            if (this.cmbPaymentType.SelectedIndex == 0)
            {
                this.lblPaymentType.ForeColor = this.clMissingFieldColor;
                errorFound = true;
            }
            else
            { this.lblPaymentType.ForeColor = this.clNormalFieldColor; }

            return errorFound;
        }

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


        private void insetDataIntoComboBox(ComboBox _comboBoxContorl, DataTable dataSourceTable,
            int columnIndexToFeed, int selectedIndex)
        {
            int arraySize = dataSourceTable.Rows.Count;
            string[] arrayItems = new string[arraySize];
            string[] tempArray = { "" };
            if (!getDataFromDb.checkIfTableContainesData(dataSourceTable))
                return;

            if (!dataSourceTable.Columns.Contains("_Index"))
            {
                dataSourceTable.Columns.Add("_Index", System.Type.GetType("System.Int16"));

                for (int rowCounter = 0; rowCounter < dataSourceTable.Rows.Count; rowCounter++)
                {
                    dataSourceTable.Rows[rowCounter]["_Index"] = rowCounter;                    
                }
            }

            for (int rowCounter = 0; rowCounter < dataSourceTable.Rows.Count; rowCounter++)
            {
                arrayItems[rowCounter] = dataSourceTable.Rows[rowCounter][columnIndexToFeed].ToString();                
            }
            _comboBoxContorl.Items.AddRange(arrayItems);

            if (selectedIndex >= 0 &&
                selectedIndex < _comboBoxContorl.Items.Count)
                _comboBoxContorl.SelectedIndex = selectedIndex;
        }

        private void comboItemFilter(ComboBox _comboBoxControl, DataTable tableToFill,
           KeyEventArgs e, string columnNameToInsert)
        {
            if (e.KeyCode != Keys.Enter)
                _comboBoxControl.DroppedDown = true;

            _comboBoxControl.Items.Clear();

            if (_comboBoxControl.Text == "")
            {
                this.insetDataIntoComboBox(_comboBoxControl, tableToFill,
                    tableToFill.Columns.IndexOf(columnNameToInsert), -1);
            }
            else
            {
                for (int currentRowIndex = tableToFill.Rows.Count - 1;
                    currentRowIndex >= 0; currentRowIndex--)
                {
                    if (!tableToFill
                            .Rows[currentRowIndex][columnNameToInsert].ToString().ToUpper().Contains
                                                (_comboBoxControl.Text.ToUpper()))
                        tableToFill.Rows.RemoveAt(currentRowIndex);
                }
                int selectedIndex = -1;
                if (tableToFill.Rows.Count == 1)
                    selectedIndex = 0;

                this.insetDataIntoComboBox(_comboBoxControl, tableToFill,
                    tableToFill.Columns.IndexOf(columnNameToInsert), selectedIndex);
            }
            _comboBoxControl.SelectionStart = _comboBoxControl.Text.Length;
            _comboBoxControl.SelectionLength = 0;
        }

        private void comboBoxDropDownClosed(ComboBox _comboBoxControl, DataTable tableDataFilledWith,
            EventHandler _comboSelectionChanged, object sender)
        {
            if (_comboBoxControl.SelectedIndex >= 0 &&
                _comboBoxControl.SelectedIndex <= _comboBoxControl.Items.Count - 1)
            {
                if (tableDataFilledWith.Rows.Count <=
                    _comboBoxControl.SelectedIndex)
                {
                    _comboBoxControl.Text = "";
                    _comboBoxControl.SelectedIndex = -1;
                    _comboBoxControl.SelectedItem = "";
                }
            }
            else
            {
                _comboBoxControl.Text = "";
                _comboBoxControl.SelectedIndex = -1;
                _comboBoxControl.SelectedItem = "";

            }

            object[] selectionChangedParameters = { new object(), new KeyEventArgs(Keys.Enter) };
            Invoke(_comboSelectionChanged, selectionChangedParameters);
        }

        public void establishValidPerformaInvoices()
        {
            this.dtPurchaseOrders =
                this.getDataFromDb.getC_ORDERInfo(null, "",
                            generalResultInformation.organiztionId, "", "", "", "",
                            "CL", "CO", "",triaStateBool.no,triaStateBool.yes,true,false,"AND");
            for (int columnCounter = this.dtPurchaseOrders.Columns.Count - 1;
                columnCounter >= 0; columnCounter--)
            {
                if (this.dtPurchaseOrders.Columns[columnCounter].ColumnName != "C_ORDER_ID" &&
                    this.dtPurchaseOrders.Columns[columnCounter].ColumnName != "DOCUMENTNO" &&
                    this.dtPurchaseOrders.Columns[columnCounter].ColumnName != "DATEORDERED" &&
                    this.dtPurchaseOrders.Columns[columnCounter].ColumnName != "TOTALLINES" &&
                    this.dtPurchaseOrders.Columns[columnCounter].ColumnName != "GRANDTOTAL" &&
                    this.dtPurchaseOrders.Columns[columnCounter].ColumnName != "C_BPARTNER_ID")
                    this.dtPurchaseOrders.Columns.RemoveAt(columnCounter);
            }
            this.dtPurchaseOrders.Columns.Add("ORDER FROM");
            for (int rowCounter = 0; rowCounter <= this.dtPurchaseOrders.Rows.Count - 1;
                rowCounter++)
            {
                this.dtPurchaseOrders.Rows[rowCounter]["ORDER FROM"] =
                    this.getDataFromDb.getC_BPARTNERInfo(null, "", "",
                              this.dtPurchaseOrders.Rows[rowCounter]["C_BPARTNER_ID"].ToString(),
                              "", triaStateBool.yes, triaStateBool.Ignor, triaStateBool.Ignor,
                              triaStateBool.Ignor, false, false, "AND").Rows[0]["NAME"].ToString();
            }
            this.dtPurchaseOrders.Columns.RemoveAt(this.dtPurchaseOrders.Columns.IndexOf("C_BPARTNER_ID"));
        }

        public DataTable establishValidCommercialInvoices(string C_ORDER_ID)
        {
            DataTable dtCommercilInvoices = 
                    this.getDataFromDb.getC_INVOICEInfo(null, "", generalResultInformation.organiztionId,
                                "", C_ORDER_ID, "", "", "", "CL", "CO", "", triaStateBool.no, triaStateBool.yes,
                                true, false, "AND");

            for (int columnCounter = dtCommercilInvoices.Columns.Count - 1;
                columnCounter >= 0; columnCounter--)
            {
                if (dtCommercilInvoices.Columns[columnCounter].ColumnName != "C_INVOICE_ID" &&
                dtCommercilInvoices.Columns[columnCounter].ColumnName != "DOCUMENTNO" &&
                dtCommercilInvoices.Columns[columnCounter].ColumnName != "DATEINVOICED" &&
                dtCommercilInvoices.Columns[columnCounter].ColumnName != "TOTALLINES" &&
                dtCommercilInvoices.Columns[columnCounter].ColumnName != "GRANDTOTAL" &&
                dtCommercilInvoices.Columns[columnCounter].ColumnName != "C_BPARTNER_ID" &&
                dtCommercilInvoices.Columns[columnCounter].ColumnName != "C_ORDER_ID")
                    dtCommercilInvoices.Columns.RemoveAt(columnCounter);
            }
            dtCommercilInvoices.Columns.Add("PAYED TO");
            for (int rowCounter = dtCommercilInvoices.Rows.Count - 1; 
                rowCounter >= 0; rowCounter--)
            {
                if (dtCommercilInvoices.Rows[rowCounter]["C_ORDER_ID"].ToString() == "")
                {
                    dtCommercilInvoices.Rows.RemoveAt(rowCounter);
                    continue;
                }
                dtCommercilInvoices.Rows[rowCounter]["PAYED TO"] =
                    this.getDataFromDb.getC_BPARTNERInfo(null, "", "",
                              dtCommercilInvoices.Rows[rowCounter]["C_BPARTNER_ID"].ToString(),
                              "", triaStateBool.yes, triaStateBool.Ignor, triaStateBool.Ignor,
                              triaStateBool.Ignor, false, false, "AND").Rows[0]["NAME"].ToString();
            }

            dtCommercilInvoices.Columns.RemoveAt(
                dtCommercilInvoices.Columns.IndexOf("C_BPARTNER_ID"));
            return dtCommercilInvoices;
        }

        public DataTable establishCommercialInvoeceDetail(string C_INVOICE_ID)
        {
            DataTable commercialInvoceLine = new DataTable();
            if (C_INVOICE_ID == "")
            {
                commercialInvoceLine.Columns.Add("Check",Type.GetType("System.Boolean"));
                commercialInvoceLine.Columns.Add("ITEM");
                commercialInvoceLine.Columns.Add("UNIT");
                commercialInvoceLine.Columns.Add("C_CHARGE_ID");
                commercialInvoceLine.Columns.Add("C_INVOICE_ID");
                commercialInvoceLine.Columns.Add("C_INVOICELINE_ID");
                commercialInvoceLine.Columns.Add("C_UOM_ID");
                commercialInvoceLine.Columns.Add("LINE");
                commercialInvoceLine.Columns.Add("M_PRODUCT_ID");
                commercialInvoceLine.Columns.Add("PRICEENTERED");
                commercialInvoceLine.Columns.Add("QTYENTERED");
                commercialInvoceLine.Columns.Add("C_ORDERLINE_ID");
                return commercialInvoceLine;
            }

            commercialInvoceLine =
                    this.getDataFromDb.getC_INVOICELINEInfo(null, "", "",
                            C_INVOICE_ID, "", "", "", triaStateBool.no, triaStateBool.Ignor,
                            true, false, "AND");

            for (int columnCounter = commercialInvoceLine.Columns.Count - 1;
                columnCounter >= 0; columnCounter--)
            {
                if (commercialInvoceLine.Columns[columnCounter].ColumnName != "C_CHARGE_ID" &&
                    commercialInvoceLine.Columns[columnCounter].ColumnName != "C_INVOICE_ID" &&
                    commercialInvoceLine.Columns[columnCounter].ColumnName != "C_INVOICELINE_ID" &&
                    commercialInvoceLine.Columns[columnCounter].ColumnName != "C_UOM_ID" &&
                    commercialInvoceLine.Columns[columnCounter].ColumnName != "LINE" &&
                    commercialInvoceLine.Columns[columnCounter].ColumnName != "M_PRODUCT_ID" &&
                    commercialInvoceLine.Columns[columnCounter].ColumnName != "PRICEENTERED" &&
                    commercialInvoceLine.Columns[columnCounter].ColumnName != "QTYENTERED" &&
                    commercialInvoceLine.Columns[columnCounter].ColumnName != "C_ORDERLINE_ID")
                {
                    commercialInvoceLine.Columns.RemoveAt(columnCounter);
                }
            }
            commercialInvoceLine.Columns.Add("Check",Type.GetType("System.Boolean"));
            commercialInvoceLine.Columns.Add("ITEM");
            commercialInvoceLine.Columns.Add("UNIT");

            DataTable commercialInvoicePaymentDetail = new DataTable();
            int [] rowIndex;
            if (this.stCurrentPaymentId != "")
            {
                commercialInvoicePaymentDetail =
                    this.getPurchasePaymentInvoiceDetail("","", this.stCurrentPaymentId);
                if(commercialInvoicePaymentDetail.Rows.Count > 0)
                    rowIndex = new int[commercialInvoicePaymentDetail.Rows.Count];
            }

            if (this.cmbPaymentType.SelectedItem.ToString().ToUpperInvariant() == "PAYMENT" ||
                this.cmbPaymentType.SelectedItem.ToString().ToUpperInvariant() == "CANCELLATION")
            {
                for (int rowCounter = 0; rowCounter <= commercialInvoceLine.Rows.Count - 1;
                    rowCounter++)
                {
                    commercialInvoceLine.Rows[rowCounter]["Check"] = false;
                }
            }
            else if(this.stCurrentPaymentId != "")
            {
                for(int rowCounter = 0; rowCounter <= commercialInvoceLine.Rows.Count-1;
                    rowCounter ++)
                {
                    if(commercialInvoicePaymentDetail.Rows.Count >0)
                    {
                        rowIndex =
                            this.searchTableRowIndex(commercialInvoicePaymentDetail,"C_INVOICELINE_ID",
                                        commercialInvoceLine.Rows[rowCounter]["C_INVOICELINE_ID"].ToString());
                        if(rowIndex[0] != -1 &&
                            rowIndex[0] <= commercialInvoicePaymentDetail.Rows.Count-1)
                                    commercialInvoceLine.Rows[rowCounter]["Check"] = true;
                        else
                            commercialInvoceLine.Rows[rowCounter]["Check"] = false;
                    }
                    else
                        commercialInvoceLine.Rows[rowCounter]["Check"] = false;
                }
            }
            else
            {
                for(int rowCounter = 0; rowCounter <= commercialInvoceLine.Rows.Count-1;
                    rowCounter ++)
                {
                    commercialInvoceLine.Rows[rowCounter]["Check"] = true;
                    //if (commercialInvoceLine.Rows[rowCounter]["C_ORDERLINE_ID"].ToString() != "")
                    //    commercialInvoceLine.Rows[rowCounter]["Check"] = true;
                    //else
                    //    commercialInvoceLine.Rows[rowCounter]["Check"] = false;
                }
            }

            for(int rowCounter = 0; rowCounter <= commercialInvoceLine.Rows.Count-1;
                rowCounter ++)
            {
                if(commercialInvoceLine.Rows[rowCounter]["M_PRODUCT_ID"].ToString() != "")
                {
                    try
                    {
                        commercialInvoceLine.Rows[rowCounter]["ITEM"] =
                            this.getDataFromDb.getM_PRODUCTInfo(null,"",
                                commercialInvoceLine.Rows[rowCounter]["M_PRODUCT_ID"].ToString(),
                                        false,false,"AND").Rows[0]["NAME"];
                    }
                    catch
                    {}
                }
                else if(commercialInvoceLine.Rows[rowCounter]["C_CHARGE_ID"].ToString() != "")
                {
                    try
                    {
                        commercialInvoceLine.Rows[rowCounter]["ITEM"] =
                            this.getDataFromDb.getC_CHARGEInfo(null,"","",
                                    commercialInvoceLine.Rows[rowCounter]["C_CHARGE_ID"].ToString(),
                                    "",false,false,"AND").Rows[0]["NAME"];
                    }
                    catch
                    {}
                }
                if(commercialInvoceLine.Rows[rowCounter]["C_UOM_ID"].ToString() != "")
                {
                    try
                    {
                        commercialInvoceLine.Rows[rowCounter]["UNIT"] =
                            this.getDataFromDb.getC_UOMInfo(null,"",
                                commercialInvoceLine.Rows[rowCounter]["C_UOM_ID"].ToString(),
                                false,false,"AND").Rows[0]["NAME"].ToString();
                    }
                    catch
                    {}
                }
            }

            return commercialInvoceLine;
        }

        public DataTable getPurchasePaymentInvoiceDetail(string C_INVOICE_ID,string C_INVOICELINE_ID,
            string PM_C_PURCHASEPAYMENT_ID)
        {
            DataTable PurchasPaymentInvoiceLineDetail =
                this.getDataFromDb.getPM_C_PPAYMENT_INVOCELINEInfo(null, "",
                        generalResultInformation.organiztionId, "", PM_C_PURCHASEPAYMENT_ID, C_INVOICELINE_ID,
                        C_INVOICE_ID, "", "",triaStateBool.Ignor, false, triaStateBool.Ignor, false, "AND");
            
            return PurchasPaymentInvoiceLineDetail;
        }

        private int[] searchTableRowIndex(DataTable tableToSearchIn,
            string columnNameToCheck, string criteriaToCheck)
        {
            if (!this.getDataFromDb.checkIfTableContainesData(tableToSearchIn))
            {
                return new int[] { -1 };
            }
            int[] resultRowIndex = new int[tableToSearchIn.Rows.Count];
            for (int arrayIndexCounter = 0;
                arrayIndexCounter <= resultRowIndex.Length - 1;
                arrayIndexCounter++)
                resultRowIndex[arrayIndexCounter] = -1;

            int matchingRowCount = 0;

            if (!this.getDataFromDb.checkIfTableContainesData(tableToSearchIn))
                return resultRowIndex;
            if (!tableToSearchIn.Columns.Contains(columnNameToCheck))
                return resultRowIndex;

            for (int rowCounter = 0; rowCounter <= tableToSearchIn.Rows.Count - 1;
                rowCounter++)
            {
                if (tableToSearchIn.Rows[rowCounter][columnNameToCheck].ToString() ==
                    criteriaToCheck)
                    resultRowIndex[matchingRowCount++] = rowCounter;
            }
            return resultRowIndex.Distinct().ToArray();
        }

        public void fillPaymentDetailGridView()
        {

            if (this.dtCommercialInvoiceLine.Columns.Count <= 0)
            {
                this.dtCommercialInvoiceLine =
                    this.establishCommercialInvoeceDetail("");
            }


            DataView dv1 = new DataView(this.dtCommercialInvoiceLine);
            dv1.Sort = "LINE Asc";
            this.dtCommercialInvoiceLine = dv1.ToTable();

            this.dtCommercialInvoiceLine.Columns["Check"].SetOrdinal(0);
            this.dtCommercialInvoiceLine.Columns["LINE"].SetOrdinal(1);
            this.dtCommercialInvoiceLine.Columns["ITEM"].SetOrdinal(2);
            this.dtCommercialInvoiceLine.Columns["QTYENTERED"].SetOrdinal(3);
            this.dtCommercialInvoiceLine.Columns["UNIT"].SetOrdinal(4);

            this.dtgPaymentItemDetail.DataSource = this.dtCommercialInvoiceLine;
            this.dtgPaymentItemDetail.Columns["Check"].HeaderText = "";
            
            foreach (DataGridViewColumn columns in this.dtgPaymentItemDetail.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DisplayIndex = columns.Index;
            }

            this.dtgPaymentItemDetail.Columns["C_CHARGE_ID"].Visible = false;
            this.dtgPaymentItemDetail.Columns["C_INVOICE_ID"].Visible = false;
            this.dtgPaymentItemDetail.Columns["C_INVOICELINE_ID"].Visible = false;
            this.dtgPaymentItemDetail.Columns["C_UOM_ID"].Visible = false;
            this.dtgPaymentItemDetail.Columns["M_PRODUCT_ID"].Visible = false;
            this.dtgPaymentItemDetail.Columns["C_ORDERLINE_ID"].Visible = false;
            

            if (this.cmbPaymentType.SelectedItem.ToString().ToUpperInvariant() != "PAYMENT")
            {
                this.ckSelectAllLines.Checked = true;
            }

        }

        private void determineIfCurrentRecordIsChanged()
        {
            this.changeIsMadeToCurrentRecord = false;

            DataTable dtcurrentPaymentOldRecord =
                this.getDataFromDb.getPM_C_PURCHASEPAYMENTInfo(null, "",
                            generalResultInformation.organiztionId, this.stCurrentPaymentId,
                            "", "", "", "", "", "", "", "", "", 
                            triaStateBool.no, triaStateBool.yes, triaStateBool.Ignor,
                            triaStateBool.Ignor, triaStateBool.Ignor, false, "AND");

            # region "Check If There is any change to current record and Alert for Update"
            if (dtcurrentPaymentOldRecord.Rows.Count == 1)
            {
                if (dtcurrentPaymentOldRecord.Rows[0]["DOCUMENTNO"].ToString() !=
                    this.txtInvoiceNumber.Text)
                {
                    lblInvoiceNumber.ForeColor = clChangedFieldColor;
                    this.changeIsMadeToCurrentRecord = true;
                }
                else
                { lblInvoiceNumber.ForeColor = clNormalFieldColor; }

                if (!this.dtpInvoiceDate.Value.Equals(dtcurrentPaymentOldRecord.Rows[0]["DATEINVOICED"]))
                {
                    this.lblInvoiceDate.ForeColor = clChangedFieldColor;
                    this.changeIsMadeToCurrentRecord = true;
                }
                else
                { this.lblInvoiceDate.ForeColor = clNormalFieldColor; }

                if (Convert.ToDecimal(dtcurrentPaymentOldRecord.Rows[0]["INVOICEAMOUNT"]) !=
                    Convert.ToDecimal(this.ntbAmount.Amount.Replace(",", "")))
                {
                    lblPaymentAmount.ForeColor = clChangedFieldColor;
                    this.changeIsMadeToCurrentRecord = true;
                    //Amount Has Changed\
                    this.paymentAmountHasChanged = true;
                }
                else
                {
                    lblPaymentAmount.ForeColor = clNormalFieldColor;
                    this.paymentAmountHasChanged = false;
                }


                if (dtcurrentPaymentOldRecord.Rows[0]["DESCRIPTION"].ToString() !=
                    this.txtDescriptionComment.Text)
                {
                    lblDescriptionComment.ForeColor = clChangedFieldColor;
                    this.changeIsMadeToCurrentRecord = true;
                }
                else
                { lblDescriptionComment.ForeColor = clNormalFieldColor; }


                if (
                    (this.currentPaymentIsCollecatable &&
                    (dtcurrentPaymentOldRecord.Rows[0]["C_TAX_ID"].ToString() == "" )) ||
                    (!this.currentPaymentIsCollecatable &&
                    (dtcurrentPaymentOldRecord.Rows[0]["C_CHARGE_ID"].ToString() == ""))
                    )
                {
                    lblPaymentReason.ForeColor = clChangedFieldColor;
                    this.changeIsMadeToCurrentRecord = true;
                }
                else
                {
                    if (this.currentPaymentIsCollecatable)
                    {
                        if (dtcurrentPaymentOldRecord.Rows[0]["C_TAX_ID"].ToString() !=
                            this.ddgPaymentReason.SelectedRowKey.ToString())
                        {
                            lblPaymentReason.ForeColor = clChangedFieldColor;
                            this.changeIsMadeToCurrentRecord = true;
                        }
                        else
                        { lblPaymentReason.ForeColor = clNormalFieldColor; }
                    }
                    else
                    {
                        if (dtcurrentPaymentOldRecord.Rows[0]["C_CHARGE_ID"].ToString() !=
                            this.ddgPaymentReason.SelectedRowKey.ToString())
                        {
                            lblPaymentReason.ForeColor = clChangedFieldColor;
                            this.changeIsMadeToCurrentRecord = true;
                        }
                        else
                        { lblPaymentReason.ForeColor = clNormalFieldColor; }
                    }
                }

                if (dtcurrentPaymentOldRecord.Rows[0]["PAYMENTTYPE"].ToString() !=
                    this.cmbPaymentType.SelectedItem.ToString())
                {
                    this.lblPaymentType.ForeColor = clChangedFieldColor;
                    this.changeIsMadeToCurrentRecord = true;
                }
                else
                { this.lblPaymentType.ForeColor = clNormalFieldColor; }

                if (dtcurrentPaymentOldRecord.Rows[0]["C_ORDER_ID"].ToString() !=
                    this.ddgPurchaseOrders.SelectedRowKey.ToString())
                {
                    this.lblOrderNumber.ForeColor = clChangedFieldColor;
                    this.changeIsMadeToCurrentRecord = true;
                }
                else
                { this.lblOrderNumber.ForeColor = clNormalFieldColor; }

                if (this.ddgCommercialInvoice.SelectedRowKey == null)
                {
                    if (dtcurrentPaymentOldRecord.Rows[0]["C_INVOICE_ID"].ToString() != "")
                    {
                        this.lblCommercialInvoice.ForeColor = clChangedFieldColor;
                        this.changeIsMadeToCurrentRecord = true;
                    }
                    else
                    { this.lblCommercialInvoice.ForeColor = clNormalFieldColor; }
                }
                else if (dtcurrentPaymentOldRecord.Rows[0]["C_INVOICE_ID"].ToString() !=
                    this.ddgCommercialInvoice.SelectedRowKey.ToString())
                {
                    this.lblCommercialInvoice.ForeColor = clChangedFieldColor;
                    this.changeIsMadeToCurrentRecord = true;
                }
                else
                { this.lblCommercialInvoice.ForeColor = clNormalFieldColor; }

                if (this.dtCommercialInvoiceLine.Rows.Count > 0)
                {
                    DataTable currentPaymentInvoiceLine =
                        this.getPurchasePaymentInvoiceDetail("","", this.stCurrentPaymentId);

                    this.ckSelectAllLines.ForeColor = this.clNormalFieldColor;
                    int numberOfCheckedLines = 0;
                    int[] searchResult;
                    for (int rowCounter = this.dtCommercialInvoiceLine.Rows.Count - 1;
                        rowCounter >= 0; rowCounter--)
                    {
                        if (!(Convert.ToBoolean(this.dtCommercialInvoiceLine.Rows[rowCounter]["Check"])))
                            continue;
                        numberOfCheckedLines++;
                        searchResult =
                            this.searchTableRowIndex(currentPaymentInvoiceLine, "C_INVOICELINE_ID",
                                this.dtCommercialInvoiceLine.Rows[rowCounter]["C_INVOICELINE_ID"].ToString());
                        if (searchResult.Length <= 0)
                        {
                            this.ckSelectAllLines.ForeColor = this.clChangedFieldColor;
                            this.changeIsMadeToCurrentRecord = true;
                            break;
                        }
                        else if(searchResult[0] == -1)
                        {
                            this.ckSelectAllLines.ForeColor = this.clChangedFieldColor;
                            this.changeIsMadeToCurrentRecord = true;
                            break;
                        }
                    }
                    if (numberOfCheckedLines != currentPaymentInvoiceLine.Rows.Count)
                    {
                        this.ckSelectAllLines.ForeColor = this.clChangedFieldColor;
                        this.changeIsMadeToCurrentRecord = true;
                    }
                }


                if (dtcurrentPaymentOldRecord.Rows[0]["C_BPARTNER_ID"].ToString() !=
                    this.stVendorId)
                {
                    this.lblVendorName.ForeColor = clChangedFieldColor;
                    this.changeIsMadeToCurrentRecord = true;
                }
                else
                { this.lblVendorName.ForeColor = clNormalFieldColor; }

                if (
                    (
                        Convert.ToString(this.ddgPayedFrom.SelectedRowKey) !=
                        dtcurrentPaymentOldRecord.Rows[0]["C_CASHBOOK_ID"].ToString()
                        ) &&
                    (
                        Convert.ToString(this.ddgPayedFrom.SelectedRowKey) !=
                        dtcurrentPaymentOldRecord.Rows[0]["C_BANKACCOUNT_ID"].ToString()
                        )
                    )
                {
                    lblPayedFrom.ForeColor = clChangedFieldColor;
                    this.changeIsMadeToCurrentRecord = true;
                    this.paymentSourceHasChanged = true;
                }
                else
                {
                    if (!this.currentPaymentIsFromCashBook)
                    {
                        if (dtcurrentPaymentOldRecord.Rows[0]["C_BANKACCOUNT_ID"].ToString() !=
                            Convert.ToString(this.ddgPayedFrom.SelectedRowKey))
                        {
                            this.lblPayedFrom.ForeColor = clChangedFieldColor;
                            this.changeIsMadeToCurrentRecord = true;
                            this.paymentSourceHasChanged = true;
                        }
                        else
                        { 
                            this.lblPayedFrom.ForeColor = clNormalFieldColor;
                            this.paymentSourceHasChanged = false;
                        }
                    }
                    else
                    {
                        if (dtcurrentPaymentOldRecord.Rows[0]["C_CASHBOOK_ID"].ToString() !=
                            Convert.ToString(this.ddgPayedFrom.SelectedRowKey))
                        {
                            this.lblPayedFrom.ForeColor = clChangedFieldColor;
                            this.changeIsMadeToCurrentRecord = true;
                            this.paymentSourceHasChanged = true;
                        }
                        else
                        { 
                            this.lblPayedFrom.ForeColor = clNormalFieldColor;
                            this.paymentSourceHasChanged = false;
                        }
                    }
                }


                if (dtcurrentPaymentOldRecord.Rows[0]["ISACTIVE"].ToString() == "N")
                {
                    if (this.ckIsActive.Checked)
                    {
                        this.ckIsActive.ForeColor = clChangedFieldColor;
                        this.changeIsMadeToCurrentRecord = true;
                        this.paymentActiveStatusChanged = true;
                    }
                    else
                    { 
                        this.ckIsActive.ForeColor = clNormalFieldColor;
                        this.paymentActiveStatusChanged = false;
                    }
                }
                else if (dtcurrentPaymentOldRecord.Rows[0]["ISACTIVE"].ToString() == "Y")
                {
                    if (!this.ckIsActive.Checked)
                    {
                        this.ckIsActive.ForeColor = clChangedFieldColor;
                        this.changeIsMadeToCurrentRecord = true;
                        this.paymentActiveStatusChanged = true;
                    }
                    else
                    {
                        this.ckIsActive.ForeColor = clNormalFieldColor;
                        this.paymentActiveStatusChanged = false;
                    }
                }


                if (dtcurrentPaymentOldRecord.Rows[0]["ISAMOUNTESTIMATE"].ToString() == "N")
                {
                    if (this.ckIsEstimateAmount.Checked)
                    {
                        this.ckIsEstimateAmount.ForeColor = clChangedFieldColor;
                        this.changeIsMadeToCurrentRecord = true;
                        this.paymentDistributableStatusChanged = true;
                    }
                    else
                    { 
                        this.ckIsEstimateAmount.ForeColor = clNormalFieldColor;
                        this.paymentDistributableStatusChanged = false;
                    }
                }
                else if (dtcurrentPaymentOldRecord.Rows[0]["ISAMOUNTESTIMATE"].ToString() == "Y")
                {
                    if (!this.ckIsEstimateAmount.Checked)
                    {
                        this.ckIsEstimateAmount.ForeColor = clChangedFieldColor;
                        this.changeIsMadeToCurrentRecord = true;
                        this.paymentEstimateStatusHasChanged = true;
                    }
                    else
                    {
                        this.ckIsEstimateAmount.ForeColor = clNormalFieldColor;
                        this.paymentEstimateStatusHasChanged = false;
                    }
                }


                if (dtcurrentPaymentOldRecord.Rows[0]["ISAMOUNTDISTRIBUTABLE"].ToString() == "N")
                {
                    if (this.ckIsAmountDistributed.Checked)
                    {
                        this.ckIsAmountDistributed.ForeColor = clChangedFieldColor;
                        this.changeIsMadeToCurrentRecord = true;
                        this.paymentDistributableStatusChanged = true;
                    }
                    else
                    {
                        this.ckIsAmountDistributed.ForeColor = clNormalFieldColor;
                        this.paymentDistributableStatusChanged = false;
                    }
                }
                else if (dtcurrentPaymentOldRecord.Rows[0]["ISAMOUNTDISTRIBUTABLE"].ToString() == "Y")
                {
                    if (!this.ckIsAmountDistributed.Checked)
                    {
                        this.ckIsAmountDistributed.ForeColor = clChangedFieldColor;
                        this.changeIsMadeToCurrentRecord = true;
                        //AMOUNT MADE DISTRIBUTABLE
                        this.paymentDistributableStatusChanged = true;
                    }
                    else
                    {
                        this.ckIsAmountDistributed.ForeColor = clNormalFieldColor;
                        this.paymentDistributableStatusChanged = false;
                    }
                }                
            }
            #endregion


            #region"The following code is meant to avoid warnings. It has no use at all"
            if (this.paymentAmountHasChanged || this.paymentActiveStatusChanged 
                || this.paymentEstimateStatusHasChanged)
            { }
            #endregion
                       

            
        }

        public void executeSaveUpadateDeletePaymentOperation()
        {
            //if To Delete record
            if (this.stDmlType.ToUpperInvariant() == "DELETE")
            {
                if (this.stCurrentPaymentId != "")
                {

                    int? indexOfRow =
                        this.dtexistingPaymentRecord.AsEnumerable()
                            .Select(row => row.Field<decimal>("PM_C_PURCHASEPAYMENT_ID"))
                            .ToList()
                            .FindIndex(col => col == decimal.Parse(this.stCurrentPaymentId));

                    if (indexOfRow.HasValue || indexOfRow.Value != -1)
                    {
                        this.dtexistingPaymentRecord.Rows.RemoveAt(indexOfRow.Value);
                    }                    

                    this.dtPayment_InvoceLine =
                        this.getDataFromDb.getPM_C_PPAYMENT_INVOCELINEInfo(null, "",
                                generalResultInformation.organiztionId, "", this.stCurrentPaymentId,"",
                                "", "", "",triaStateBool.no, false, triaStateBool.Ignor, false, "AND");                    

                    this.getDataFromDb.changeDataBaseTableData
                                (this.dtPayment_InvoceLine, "PM_C_PPAYMENT_INVOCELINE", 
                                    this.stDmlType.ToUpperInvariant());

                    this.dtNewPaymentRecord =
                        this.getDataFromDb.getPM_C_PURCHASEPAYMENTInfo(null, "", "",
                            this.stCurrentPaymentId, "", "", "", "", "", "", "", "", "",
                            triaStateBool.no, triaStateBool.yes, triaStateBool.Ignor, triaStateBool.Ignor,
                            triaStateBool.Ignor, false, "AND");

                    this.getDataFromDb.changeDataBaseTableData
                                (this.dtNewPaymentRecord, "PM_C_PURCHASEPAYMENT",
                                    this.stDmlType.ToUpperInvariant());

                    
                    //int? indexOfRow =
                    //(this.dtgPaymentGridView.Rows.Cast<DataGridViewRow>()
                    //            .Where(r => r.Cells["PM_C_PURCHASEPAYMENT_ID"].Value.ToString() == this.stCurrentPaymentId)
                    //            .Select(r => r.Index)).First();

                    //if (indexOfRow.HasValue && indexOfRow.Value != -1)
                    //{
                    //    this.dtgPaymentGridView.Rows[indexOfRow.Value].Selected = true;
                    //}
                }
                this.dtPayment_InvoceLine.Clear();
                this.dtNewPaymentRecord.Clear();
                return;                
            }

            //If to Update or Save Record
            if (this.stDmlType.ToUpperInvariant() == "UPDATE")
            {
                DataTable criterionTable = new DataTable();
                criterionTable.Columns.Add("Field");
                criterionTable.Columns.Add("Criterion");
                criterionTable.Columns.Add("Value");

                DataRow drPrimaryKey = criterionTable.NewRow();
                drPrimaryKey["Field"] = "PM_C_PURCHASEPAYMENT_ID";
                drPrimaryKey["Criterion"] = " = ";
                drPrimaryKey["Value"] = this.stCurrentPaymentId;

                criterionTable.Rows.Add(drPrimaryKey);

                if (this.lblPayedFrom.ForeColor.Equals(this.clChangedFieldColor) ||
                    this.paymentSourceHasChanged)
                {
                    this.getDataFromDb.resetDbTableColumn(criterionTable, "PM_C_PURCHASEPAYMENT",
                            "C_CASHBOOK_ID", "");
                    this.getDataFromDb.resetDbTableColumn(criterionTable, "PM_C_PURCHASEPAYMENT",
                            "C_BANKACCOUNT_ID", "");
                }
                if (this.lblPaymentReason.ForeColor.Equals(this.clChangedFieldColor))
                {
                    this.getDataFromDb.resetDbTableColumn(criterionTable, "PM_C_PURCHASEPAYMENT",
                               "C_TAX_ID", "");
                    this.getDataFromDb.resetDbTableColumn(criterionTable, "PM_C_PURCHASEPAYMENT",
                            "C_CHARGE_ID", "");
                }
                if ((this.ckIsAmountDistributed.ForeColor.Equals(this.clChangedFieldColor) ||
                    this.paymentDistributableStatusChanged) &&
                    this.ckIsAmountDistributed.Checked)
                    this.getDataFromDb.resetDbTableColumn(criterionTable, "PM_C_PURCHASEPAYMENT",
                            "C_INVOICE_ID", "");
            }
            
            string isActive = "";
            string isEstimate = "";            

            string[] purchaseRecordKey;

            this.dtNewPaymentRecord =
                this.getDataFromDb.getPM_C_PURCHASEPAYMENTInfo(null, "", "",
                                "", "", "", "", "", "", "", "", "", "",
                                triaStateBool.no, triaStateBool.yes, triaStateBool.Ignor,
                                triaStateBool.Ignor, triaStateBool.Ignor, true, "AND");

            DataRow dt = dtNewPaymentRecord.NewRow();
            if(this.stCurrentPaymentId != "")
                dt["PM_C_PURCHASEPAYMENT_ID"] = this.stCurrentPaymentId;


            dt["ISACTIVE"] = 
                this.translateBoolToCharacter(this.ckIsActive.Checked);            

            dt["AD_CLIENT_ID"] = generalResultInformation.clientId;
            dt["AD_ORG_ID"] = generalResultInformation.organiztionId;

            dt["DOCUMENTNO"] = this.txtInvoiceNumber.Text;
            dt["C_BPARTNER_ID"] = this.stVendorId;
            dt["DATEINVOICED"] = dtpInvoiceDate.Value.ToString("dd-MMM-yyyy");
            dt["INVOICEAMOUNT"] = ntbAmount.Amount.Replace(",", "");

            
            dt["ISAMOUNTESTIMATE"] = 
                this.translateBoolToCharacter(this.ckIsEstimateAmount.Checked);
            
            dt["ISAMOUNTDISTRIBUTABLE"] =
                    this.translateBoolToCharacter(this.ckIsAmountDistributed.Checked);

            if (this.stBankAccountId != "" || this.stCashBookId != "")
            {
                if (!this.currentPaymentIsFromCashBook)
                    dt["C_BANKACCOUNT_ID"] = this.stBankAccountId;
                else
                    dt["C_CASHBOOK_ID"] = this.stCashBookId;
            }

            dt["DESCRIPTION"] = this.txtDescriptionComment.Text;

            if (this.currentPaymentIsCollecatable)
                dt["C_TAX_ID"] = this.stTaxId;
            else
                dt["C_CHARGE_ID"] = this.stChargeId;

            dt["PAYMENTTYPE"] = this.cmbPaymentType.SelectedItem.ToString();

            dt["C_ORDER_ID"] = this.ddgPurchaseOrders.SelectedRowKey.ToString();
            if (this.ddgCommercialInvoice.SelectedRowKey != null)
                dt["C_INVOICE_ID"] = Convert.ToString(this.ddgCommercialInvoice.SelectedRowKey);           

            dt["USERINSERTED"] = "Y";
            dt["COSTCLOSED"] = "N";
            dt["PROCESSED"] = "N";
            dt["PROCESSING"] = "N";

            isActive = dt["ISACTIVE"].ToString();
            isEstimate = dt["ISAMOUNTESTIMATE"].ToString();           

            dtNewPaymentRecord.Rows.Add(dt);            

            purchaseRecordKey =
                this.getDataFromDb.changeDataBaseTableData
                            (this.dtNewPaymentRecord, "PM_C_PURCHASEPAYMENT", stDmlType);
            dt.Delete();
            this.dtNewPaymentRecord.Clear();
            // Record/Upadate Payment InvoiceLine Detail record.

            string[] newPrimaryKey;
            if (this.stCurrentPaymentId == "")
            {                
                if (purchaseRecordKey.Length < 1)
                {
                    MessageBox.Show("Un able to record Payment Detail. Please Try again.",
                        "Purchase Payments",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
                newPrimaryKey = purchaseRecordKey[0].Split(new string[] { " <(", ")>||" }, 
                    StringSplitOptions.RemoveEmptyEntries);

                if (!newPrimaryKey.Contains(this.getDataFromDb.getCompiereTablePrimaryKey
                                                ("PM_C_PURCHASEPAYMENT")[0]))
                {
                    MessageBox.Show("Un able to record Payment Detail. Please Try again.",
                        "Purchase Payments", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.stCurrentPaymentId = newPrimaryKey[1];
            }

            if (this.stCurrentPaymentId == "")
            {
                MessageBox.Show("Un able to record Payment Detail. Please Try again.",
                        "Purchase Payments", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.dtPayment_InvoceLine =
                this.getDataFromDb.getPM_C_PPAYMENT_INVOCELINEInfo(null, "",
                            generalResultInformation.organiztionId, "", this.stCurrentPaymentId, 
                            "","", "", "",triaStateBool.no, false,triaStateBool.Ignor, false, "AND");

            DataTable dtRemovePaymentInvoiceLine = this.dtPayment_InvoceLine.Copy();

            this.dtCommercialInvoiceLine.AsEnumerable()
                .Where(r => r.Field<Boolean>("Check") == true)
                .ToList().ForEach(row =>
                {
                    dtRemovePaymentInvoiceLine.AsEnumerable()
                        .Where(i => i.Field<decimal>("C_INVOICELINE_ID") == decimal.Parse(row["C_INVOICELINE_ID"].ToString()))
                        .ToList().ForEach(dRow => dRow.Delete());
                    dtRemovePaymentInvoiceLine.AcceptChanges();
                });

            this.dtCommercialInvoiceLine.AsEnumerable()
                .Where(r => r.Field<Boolean>("Check") == false)
                .ToList().ForEach(row =>
                {
                    this.dtPayment_InvoceLine.AsEnumerable()
                        .Where(i => i.Field<decimal>("C_INVOICELINE_ID") == decimal.Parse(row["C_INVOICELINE_ID"].ToString()))
                        .ToList().ForEach(dRow => dRow.Delete());
                    this.dtPayment_InvoceLine.AcceptChanges();
                });
                        

            //int[] rowIndex = new int[this.dtCommercialInvoiceLine.Rows.Count];
            //for (int rowCounter = dtRemovePaymentInvoiceLine.Rows.Count - 1; rowCounter >= 0; rowCounter--)
            //{
            //    rowIndex =
            //        this.searchTableRowIndex(this.dtCommercialInvoiceLine, "C_INVOICELINE_ID",
            //                            dtRemovePaymentInvoiceLine.Rows[rowCounter]["C_INVOICELINE_ID"].ToString());
            //    if (rowIndex[0] != -1 &&
            //               rowIndex[0] <= this.dtCommercialInvoiceLine.Rows.Count - 1)
            //    {
            //        if (Convert.ToBoolean(this.dtCommercialInvoiceLine.Rows[rowIndex[0]]["Check"]))
            //        {
            //            dtRemovePaymentInvoiceLine.Rows.RemoveAt(rowCounter);
            //        }
            //        else
            //        {
            //            this.dtPayment_InvoceLine.Rows.RemoveAt(rowCounter); 
            //        }
            //    }
            //    else
            //    {
            //        this.dtPayment_InvoceLine.Rows.RemoveAt(rowCounter);
            //    }
            //}

            this.getDataFromDb.changeDataBaseTableData
                            (dtRemovePaymentInvoiceLine, "PM_C_PPAYMENT_INVOCELINE", "DELETE");

            if (this.ckIsAmountDistributed.Checked ||
                this.cmbPaymentType.SelectedItem.ToString().ToUpperInvariant() == "PAYMENT" ||
                this.cmbPaymentType.SelectedItem.ToString().ToUpperInvariant() == "COLLATERAL" ||
                this.cmbPaymentType.SelectedItem.ToString().ToUpperInvariant() == "CANCELLATION")
            {

                this.getDataFromDb.changeDataBaseTableData
                                (this.dtPayment_InvoceLine, "PM_C_PPAYMENT_INVOCELINE", "DELETE");
                return;
            }

            //this.dtPayment_InvoceLine.Clear();
            DataRow drNewPaymentInvoceDetail;
            
            for (int rowCounter = this.dtCommercialInvoiceLine.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                if (!(Convert.ToBoolean(this.dtCommercialInvoiceLine.Rows[rowCounter]["Check"])))
                    continue;

                int? indexOfRow = 
                    this.dtPayment_InvoceLine.AsEnumerable()
                        .Select(row => row.Field<decimal>("C_INVOICELINE_ID"))
                        .ToList()
                        .FindIndex(col => col == decimal.Parse(this.dtCommercialInvoiceLine.Rows[rowCounter]["C_INVOICELINE_ID"].ToString()));

                if (!indexOfRow.HasValue || indexOfRow.Value == -1)
                {
                    drNewPaymentInvoceDetail = this.dtPayment_InvoceLine.NewRow();

                    drNewPaymentInvoceDetail["PM_C_PURCHASEPAYMENT_ID"] = this.stCurrentPaymentId;
                    drNewPaymentInvoceDetail["C_INVOICELINE_ID"] =
                        this.dtCommercialInvoiceLine.Rows[rowCounter]["C_INVOICELINE_ID"].ToString();

                    drNewPaymentInvoceDetail["C_INVOICE_ID"] =
                        this.dtCommercialInvoiceLine.Rows[rowCounter]["C_INVOICE_ID"].ToString();

                    drNewPaymentInvoceDetail["AD_CLIENT_ID"] =
                        generalResultInformation.clientId;
                    drNewPaymentInvoceDetail["AD_ORG_ID"] =
                        generalResultInformation.organiztionId;
                    drNewPaymentInvoceDetail["ISACTIVE"] = isActive;
                    drNewPaymentInvoceDetail["ISAMOUNTESTIMATE"] = isEstimate;
                    drNewPaymentInvoceDetail["AMOUNTSHARED"] = 0;

                    if (this.stTaxId != "")
                        drNewPaymentInvoceDetail["C_TAX_ID"] = this.stTaxId;
                    if (this.stChargeId != "")
                        drNewPaymentInvoceDetail["C_CHARGE_ID"] = this.stChargeId;

                    drNewPaymentInvoceDetail["COSTCLOSED"] = "N";

                    this.dtPayment_InvoceLine.Rows.Add(drNewPaymentInvoceDetail);
                }
                else
                {
                    this.dtPayment_InvoceLine.Rows[indexOfRow.Value]["AD_CLIENT_ID"] = generalResultInformation.clientId; ;
                    this.dtPayment_InvoceLine.Rows[indexOfRow.Value]["AD_ORG_ID"] = generalResultInformation.organiztionId; ;
                    this.dtPayment_InvoceLine.Rows[indexOfRow.Value]["ISACTIVE"] = isActive;
                    this.dtPayment_InvoceLine.Rows[indexOfRow.Value]["ISAMOUNTESTIMATE"] = isEstimate;

                    if (this.stTaxId != "")
                    {
                        this.dtPayment_InvoceLine.Rows[indexOfRow.Value]["C_TAX_ID"] = this.stTaxId;
                        this.dtPayment_InvoceLine.Rows[indexOfRow.Value]["C_CHARGE_ID"] = DBNull.Value;
                    }
                    if (this.stChargeId != "")
                    {
                        this.dtPayment_InvoceLine.Rows[indexOfRow.Value]["C_TAX_ID"] = DBNull.Value;
                        this.dtPayment_InvoceLine.Rows[indexOfRow.Value]["C_CHARGE_ID"] = this.stChargeId;
                    } 
                }
            }

            this.getDataFromDb.changeDataBaseTableData
                            (this.dtPayment_InvoceLine, "PM_C_PPAYMENT_INVOCELINE", "UPDATE");
            this.dtPayment_InvoceLine.Clear();
        }

        private bool translateCharacterToBool(string _char)
        {
            if (_char == "Y")
                return true;
            else
                return false;           
        }

        private string translateBoolToCharacter(bool _boolean)
        {
            if (_boolean)
                return "Y";
            else
                return "N";
        }

        public void insertOrUpdateRecordToExistingPaymentList()
        {  
 
            if (this.stCurrentPaymentId == "")
                return;

            int [] searchResult = 
                    this.searchTableRowIndex
                        (this.dtexistingPaymentRecord,"PM_C_PURCHASEPAYMENT_ID",this.stCurrentPaymentId);

            if(searchResult.Length == 0 ||
                searchResult[0] == -1)
            {
                DataRow drNewPayment =
                    this.dtexistingPaymentRecord.NewRow();

                drNewPayment["AD_CLIENT_ID"] = generalResultInformation.clientId;
                drNewPayment["AD_ORG_ID"] = generalResultInformation.organiztionId;
                drNewPayment["C_BPARTNER_ID"] = this.stVendorId;

                if (this.stCashBookId != "" || this.stBankAccountId != "")
                {
                    if (this.currentPaymentIsFromCashBook)
                        drNewPayment["C_CASHBOOK_ID"] = this.stCashBookId;
                    else
                        drNewPayment["C_BANKACCOUNT_ID"] = this.stBankAccountId;
                }

                if (this.currentPaymentIsCollecatable)
                    drNewPayment["C_TAX_ID"] = this.stTaxId;
                else
                    drNewPayment["C_CHARGE_ID"] = this.stChargeId;

                if (this.ddgCommercialInvoice.SelectedRowKey != null)
                {
                    drNewPayment["C_INVOICE_ID"] = Convert.ToString(this.ddgCommercialInvoice.SelectedRowKey);
                    drNewPayment["INVOICE"] = this.ddgCommercialInvoice.SelectedItem;
                }

                drNewPayment["C_ORDER_ID"] = this.ddgPurchaseOrders.SelectedRowKey.ToString();
                drNewPayment["DATEINVOICED"] = this.dtpInvoiceDate.Value;

                drNewPayment["DOCUMENTNO"] = this.txtInvoiceNumber.Text;
                drNewPayment["PM_C_PURCHASEPAYMENT_ID"] = this.stCurrentPaymentId;
                drNewPayment["ACTIVE"] = this.ckIsActive.Checked;
                drNewPayment["ESTIMATE"] = this.ckIsEstimateAmount.Checked;
                drNewPayment["DISTRIBUTED"] = this.ckIsAmountDistributed.Checked;
                drNewPayment["IS A BANK"] = !this.currentPaymentIsFromCashBook;
                drNewPayment["IS A COST"] = !this.currentPaymentIsCollecatable;
                drNewPayment["COST CLOSED"] = false;
                drNewPayment["PROCESSING"] = "N";
                drNewPayment["PROCESSED"] = "N";
                drNewPayment["VENDOR"] = this.ddgVendor.SelectedItem;
                drNewPayment["AMOUNT"] = this.ntbAmount.Amount;
                drNewPayment["PAYED FROM"] = this.ddgPayedFrom.SelectedItem;
                drNewPayment["PAYED FOR"] = this.ddgPaymentReason.SelectedItem;
                drNewPayment["PAYMENT TYPE"] = this.cmbPaymentType.SelectedItem.ToString();
                drNewPayment["ORDER"] = this.ddgPurchaseOrders.SelectedItem;

                this.dtexistingPaymentRecord.Rows.Add(drNewPayment);
            }
            else if(searchResult[0] >= 0 &&
                searchResult[0] <= this.dtexistingPaymentRecord.Rows.Count-1)
            {                 
                int rowIndex = searchResult[0];

                this.dtexistingPaymentRecord.Rows[rowIndex]["AD_CLIENT_ID"] = 
                    generalResultInformation.clientId;
                this.dtexistingPaymentRecord.Rows[rowIndex]["AD_ORG_ID"] = 
                    generalResultInformation.organiztionId;
                this.dtexistingPaymentRecord.Rows[rowIndex]["C_BPARTNER_ID"] = 
                    this.stVendorId;

                if (this.stCashBookId != "")
                {
                    this.dtexistingPaymentRecord.Rows[rowIndex]["C_CASHBOOK_ID"] =
                        this.stCashBookId;
                }
                else if (this.stBankAccountId != "")
                {
                    this.dtexistingPaymentRecord.Rows[rowIndex]["C_BANKACCOUNT_ID"] =
                        this.stBankAccountId;
                }

                if (this.stTaxId != "")
                {
                    this.dtexistingPaymentRecord.Rows[rowIndex]["C_TAX_ID"] =
                        this.stTaxId;
                }
                else
                {
                    this.dtexistingPaymentRecord.Rows[rowIndex]["C_CHARGE_ID"] =
                        this.stChargeId;
                }

                DBNull m = DBNull.Value;
                if (this.ddgCommercialInvoice.SelectedRowKey != null)
                {
                    this.dtexistingPaymentRecord.Rows[rowIndex]["C_INVOICE_ID"] =
                        this.ddgCommercialInvoice.SelectedRowKey.ToString();
                    this.dtexistingPaymentRecord.Rows[rowIndex]["INVOICE"] =
                        this.ddgCommercialInvoice.SelectedItem;
                }
                else
                {
                    this.dtexistingPaymentRecord.Rows[rowIndex]["C_INVOICE_ID"] =
                         m;
                    this.dtexistingPaymentRecord.Rows[rowIndex]["INVOICE"] =
                        "";
                }

                this.dtexistingPaymentRecord.Rows[rowIndex]["C_ORDER_ID"] = 
                    this.ddgPurchaseOrders.SelectedRowKey.ToString();

                this.dtexistingPaymentRecord.Rows[rowIndex]["DATEINVOICED"] = 
                    this.dtpInvoiceDate.Value.ToString("");
                this.dtexistingPaymentRecord.Rows[rowIndex]["DOCUMENTNO"] =
                    this.txtInvoiceNumber.Text;
                this.dtexistingPaymentRecord.Rows[rowIndex]["PM_C_PURCHASEPAYMENT_ID"] =
                    this.stCurrentPaymentId;
                this.dtexistingPaymentRecord.Rows[rowIndex]["ACTIVE"] =
                    this.ckIsActive.Checked;
                this.dtexistingPaymentRecord.Rows[rowIndex]["ESTIMATE"] =
                    this.ckIsEstimateAmount.Checked;
                this.dtexistingPaymentRecord.Rows[rowIndex]["DISTRIBUTED"] =
                    this.ckIsAmountDistributed.Checked;
                this.dtexistingPaymentRecord.Rows[rowIndex]["IS A BANK"] =
                    !this.currentPaymentIsFromCashBook;
                this.dtexistingPaymentRecord.Rows[rowIndex]["IS A COST"] =
                    !this.currentPaymentIsCollecatable;

                this.dtexistingPaymentRecord.Rows[rowIndex]["VENDOR"] =
                    this.ddgVendor.SelectedItem;
                this.dtexistingPaymentRecord.Rows[rowIndex]["AMOUNT"] =
                    this.ntbAmount.Amount;
                
                this.dtexistingPaymentRecord.Rows[rowIndex]["PAYED FROM"] =
                    this.ddgPayedFrom.SelectedItem;
                this.dtexistingPaymentRecord.Rows[rowIndex]["PAYED FOR"] =
                    this.ddgPaymentReason.SelectedItem;
                this.dtexistingPaymentRecord.Rows[rowIndex]["PAYMENT TYPE"] =
                    this.cmbPaymentType.SelectedItem;
                this.dtexistingPaymentRecord.Rows[rowIndex]["ORDER"] =
                    this.ddgPurchaseOrders.SelectedItem;
                this.dtexistingPaymentRecord.Rows[rowIndex]["DESCRIPTION"] =
                    this.txtDescriptionComment.Text;                
            }

        }

        public void establishExistingPaymentRecordStructure()
        {
            if (!this.getDataFromDb.checkIfTableContainesData
                (generalResultInformation.searchResult))
            {
                if (this.dtexistingPaymentRecord.Columns.Count <= 0)
                {
                    this.dtexistingPaymentRecord =
                        this.getDataFromDb.getPM_C_PURCHASEPAYMENTInfo(null, "", "", "",
                                "", "", "", "", "", "", "", "", "", triaStateBool.no,
                                triaStateBool.yes, triaStateBool.Ignor, triaStateBool.Ignor,
                                triaStateBool.Ignor, true, "AND");

                    this.dtexistingPaymentRecord.Columns.Add("ACTIVE", Type.GetType("System.Boolean"));
                    this.dtexistingPaymentRecord.Columns.Add("ESTIMATE", Type.GetType("System.Boolean"));
                    this.dtexistingPaymentRecord.Columns.Add("DISTRIBUTED", Type.GetType("System.Boolean"));
                    this.dtexistingPaymentRecord.Columns.Add("IS A BANK", Type.GetType("System.Boolean"));
                    this.dtexistingPaymentRecord.Columns.Add("IS A COST", Type.GetType("System.Boolean"));
                    this.dtexistingPaymentRecord.Columns.Add("COST CLOSED", Type.GetType("System.Boolean"));
                    this.dtexistingPaymentRecord.Columns.Add("VENDOR");
                    this.dtexistingPaymentRecord.Columns.Add("AMOUNT", Type.GetType("System.Decimal"));
                    this.dtexistingPaymentRecord.Columns.Add("PAYED FROM");
                    this.dtexistingPaymentRecord.Columns.Add("PAYED FOR");
                    this.dtexistingPaymentRecord.Columns.Add("PAYMENT TYPE");
                    this.dtexistingPaymentRecord.Columns.Add("ORDER");
                    this.dtexistingPaymentRecord.Columns.Add("INVOICE");

                    this.dtexistingPaymentRecord.Columns.RemoveAt(
                        this.dtexistingPaymentRecord.Columns.IndexOf("COSTCLOSED"));
                    this.dtexistingPaymentRecord.Columns.RemoveAt(
                        this.dtexistingPaymentRecord.Columns.IndexOf("INVOICEAMOUNT"));
                    this.dtexistingPaymentRecord.Columns.RemoveAt(
                        this.dtexistingPaymentRecord.Columns.IndexOf("ISACTIVE"));
                    this.dtexistingPaymentRecord.Columns.RemoveAt(
                        this.dtexistingPaymentRecord.Columns.IndexOf("ISAMOUNTDISTRIBUTABLE"));
                    this.dtexistingPaymentRecord.Columns.RemoveAt(
                        this.dtexistingPaymentRecord.Columns.IndexOf("ISAMOUNTESTIMATE"));
                    this.dtexistingPaymentRecord.Columns.RemoveAt(
                        this.dtexistingPaymentRecord.Columns.IndexOf("UPDATED"));
                    this.dtexistingPaymentRecord.Columns.RemoveAt(
                        this.dtexistingPaymentRecord.Columns.IndexOf("UPDATEDBY"));
                    this.dtexistingPaymentRecord.Columns.RemoveAt(
                        this.dtexistingPaymentRecord.Columns.IndexOf("USERINSERTED"));                    
                    this.dtexistingPaymentRecord.Columns.RemoveAt(
                        this.dtexistingPaymentRecord.Columns.IndexOf("CREATED"));
                    this.dtexistingPaymentRecord.Columns.RemoveAt(
                        this.dtexistingPaymentRecord.Columns.IndexOf("CREATEDBY"));
                    this.dtexistingPaymentRecord.Columns.RemoveAt(
                        this.dtexistingPaymentRecord.Columns.IndexOf("PAYMENTTYPE"));
                }
            }
            else
            {
                this.dtexistingPaymentRecord =
                    generalResultInformation.searchResult.Copy();
            }

            DataView dv1 = new DataView(this.dtexistingPaymentRecord);
            dv1.Sort = "DATEINVOICED, DOCUMENTNO Asc";
            this.dtexistingPaymentRecord = dv1.ToTable();

            //this.dtexistingPaymentRecord.Columns[""].d

            this.dtexistingPaymentRecord.Columns["DOCUMENTNO"].SetOrdinal(0);
            this.dtexistingPaymentRecord.Columns["VENDOR"].SetOrdinal(1);
            this.dtexistingPaymentRecord.Columns["DATEINVOICED"].SetOrdinal(2);
            this.dtexistingPaymentRecord.Columns["AMOUNT"].SetOrdinal(3);
            this.dtexistingPaymentRecord.Columns["ACTIVE"].SetOrdinal(4);
            this.dtexistingPaymentRecord.Columns["ESTIMATE"].SetOrdinal(5);
            this.dtexistingPaymentRecord.Columns["DISTRIBUTED"].SetOrdinal(6);
            this.dtexistingPaymentRecord.Columns["PAYED FROM"].SetOrdinal(7);
            this.dtexistingPaymentRecord.Columns["IS A BANK"].SetOrdinal(8);
            this.dtexistingPaymentRecord.Columns["PAYED FOR"].SetOrdinal(9);
            this.dtexistingPaymentRecord.Columns["PAYMENT TYPE"].SetOrdinal(11);
            this.dtexistingPaymentRecord.Columns["IS A COST"].SetOrdinal(12);
            this.dtexistingPaymentRecord.Columns["ORDER"].SetOrdinal(13);
            this.dtexistingPaymentRecord.Columns["INVOICE"].SetOrdinal(14);
            this.dtexistingPaymentRecord.Columns["COST CLOSED"].SetOrdinal(15);
        }

        public void filldtExistingPaymentRecordToPaymentGridView()
        {
            this.dtgPaymentGridView.DataSource = this.dtexistingPaymentRecord;
            
            foreach (DataGridViewColumn columns in this.dtgPaymentGridView.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.Automatic;
                columns.DisplayIndex = columns.Index;
            }
                        
            this.dtgPaymentGridView.Columns["AD_CLIENT_ID"].Visible = false;
            this.dtgPaymentGridView.Columns["AD_ORG_ID"].Visible = false;
            this.dtgPaymentGridView.Columns["C_BANKACCOUNT_ID"].Visible = false;
            this.dtgPaymentGridView.Columns["C_BPARTNER_ID"].Visible = false;
            this.dtgPaymentGridView.Columns["C_CASHBOOK_ID"].Visible = false;
            this.dtgPaymentGridView.Columns["C_CHARGE_ID"].Visible = false;
            this.dtgPaymentGridView.Columns["C_INVOICE_ID"].Visible = false;
            this.dtgPaymentGridView.Columns["C_ORDER_ID"].Visible = false;
            this.dtgPaymentGridView.Columns["C_TAX_ID"].Visible = false;
            this.dtgPaymentGridView.Columns["PM_C_PURCHASEPAYMENT_ID"].Visible = false;
            this.dtgPaymentGridView.Columns["DESCRIPTION"].Visible = false;

            this.dtgPaymentGridView.Columns["AMOUNT"].DefaultCellStyle.Format = "N2";
            this.dtgPaymentGridView.Columns["AMOUNT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            
        }

        public void fillCurrentGirdDataToForm()
        {
            resetLableColor();
            if (this.dtgPaymentGridView.Rows.Count < 1)
            {
                this.clearForm();
                return;
            }

            int rowIndex = this.dtgPaymentGridView.SelectedRows[0].Index;

            this.intCurrentPaymentRowIndex = this.dtgPaymentGridView.SelectedRows[0].Index;

            this.ddgPaymentReason.SelectedRow.Clear();
            this.ddgPayedFrom.SelectedRow.Clear();
            this.ddgPurchaseOrders.SelectedRow.Clear();

            this.stCurrentPaymentId =
                this.dtgPaymentGridView.Rows[rowIndex].Cells["PM_C_PURCHASEPAYMENT_ID"].Value.ToString();


            this.costClosed =
                Convert.ToBoolean(this.dtgPaymentGridView.Rows[rowIndex].Cells["COST CLOSED"].Value) ||
                Convert.ToString(this.dtgPaymentGridView.Rows[rowIndex].Cells["PROCESSING"].Value) == "Y" ||
                Convert.ToString(this.dtgPaymentGridView.Rows[rowIndex].Cells["PROCESSED"].Value) == "Y";

            this.txtInvoiceNumber.Text =
                this.dtgPaymentGridView.Rows[rowIndex].Cells["DOCUMENTNO"].Value.ToString();

            this.stVendorId =
                this.dtgPaymentGridView.Rows[rowIndex].Cells["C_BPARTNER_ID"].Value.ToString();
            this.ddgVendor.SelectedItem =
                this.dtgPaymentGridView.Rows[rowIndex].Cells["VENDOR"].Value.ToString();


            this.dtpInvoiceDate.Value =
                Convert.ToDateTime(this.dtgPaymentGridView.Rows[rowIndex].Cells["DATEINVOICED"].Value);

            if (Convert.ToString(this.dtgPaymentGridView.Rows[rowIndex].Cells["C_BANKACCOUNT_ID"].Value) != "")
            {
                this.stCashBookId = "";
                this.stBankAccountId = 
                    this.dtgPaymentGridView.Rows[rowIndex].Cells["C_BANKACCOUNT_ID"].Value.ToString();
                this.ddgPayedFrom.SelectedRowKey = this.stBankAccountId;
                this.ddgPayedFrom.SelectedItem =
                    this.dtgPaymentGridView.Rows[rowIndex].Cells["PAYED FROM"].Value.ToString();
                this.currentPaymentIsFromCashBook = false;
            }
            else if (Convert.ToString(this.dtgPaymentGridView.Rows[rowIndex].Cells["C_CASHBOOK_ID"].Value) != "")
            {
                this.stBankAccountId = "";
                this.stCashBookId =
                    this.dtgPaymentGridView.Rows[rowIndex].Cells["C_CASHBOOK_ID"].Value.ToString();
                this.ddgPayedFrom.SelectedRowKey = this.stCashBookId;
                this.ddgPayedFrom.SelectedItem =
                    this.dtgPaymentGridView.Rows[rowIndex].Cells["PAYED FROM"].Value.ToString();
                this.currentPaymentIsFromCashBook = true;
            }
            else
            {
                this.stBankAccountId = "";
                this.stCashBookId = "";
                this.ddgPayedFrom.SelectedRowKey = null;
                this.ddgPayedFrom.SelectedItem = "";
                this.currentPaymentIsFromCashBook = false; 
            }
            
            this.ntbAmount.Amount =
                this.dtgPaymentGridView.Rows[rowIndex].Cells["AMOUNT"].Value.ToString();

            this.ckIsEstimateAmount.Checked =
                Convert.ToBoolean(this.dtgPaymentGridView.Rows[rowIndex].Cells["ESTIMATE"].Value);

            this.ckIsActive.Checked =
                Convert.ToBoolean(this.dtgPaymentGridView.Rows[rowIndex].Cells["ACTIVE"].Value);

            this.ckIsAmountDistributed.Checked =
                Convert.ToBoolean(this.dtgPaymentGridView.Rows[rowIndex].Cells["DISTRIBUTED"].Value);

            this.txtDescriptionComment.Text =
               this.dtgPaymentGridView.Rows[rowIndex].Cells["DESCRIPTION"].Value.ToString();

            this.ddgPurchaseOrders.SelectedRowKey =
                this.dtgPaymentGridView.Rows[rowIndex].Cells["C_ORDER_ID"].Value.ToString();
            this.ddgPurchaseOrders.SelectedItem =
                this.dtgPaymentGridView.Rows[rowIndex].Cells["ORDER"].Value.ToString();
            
            string paymentTp =
                Convert.ToString(this.dtgPaymentGridView.Rows[rowIndex].Cells["PAYMENT TYPE"].Value);
            if (paymentTp != "-")
            {
                this.cmbPaymentType.SelectedItem = paymentTp;
            }
            else
            {
                this.cmbPaymentType.SelectedIndex = 0;
            }
            
            

            this.dtOrderCommercialInvoice =
                    this.establishValidCommercialInvoices(
                        this.ddgPurchaseOrders.SelectedRowKey.ToString());

            if (this.dtgPaymentGridView.Rows[rowIndex].Cells["C_INVOICE_ID"].Value.ToString() != "")
            {
                this.ddgCommercialInvoice.SelectedRowKey =
                    this.dtgPaymentGridView.Rows[rowIndex].Cells["C_INVOICE_ID"].Value.ToString();
                this.ddgCommercialInvoice.SelectedItem =
                    this.dtgPaymentGridView.Rows[rowIndex].Cells["INVOICE"].Value.ToString();
                this.dtCommercialInvoiceLine = 
                    this.establishCommercialInvoeceDetail
                        (this.dtgPaymentGridView.Rows[rowIndex].Cells["C_INVOICE_ID"].Value.ToString());
                this.fillPaymentDetailGridView();                    
            }


            if (!(Convert.ToBoolean(this.dtgPaymentGridView.Rows[rowIndex].Cells["IS A COST"].Value)))
            {
                this.stChargeId = "";
                this.stTaxId =
                    this.dtgPaymentGridView.Rows[rowIndex].Cells["C_TAX_ID"].Value.ToString();
                this.ddgPaymentReason.SelectedRowKey = this.stTaxId;                    
                this.ddgPaymentReason.SelectedItem =
                    this.dtgPaymentGridView.Rows[rowIndex].Cells["PAYED FOR"].Value.ToString();
                this.currentPaymentIsCollecatable = true;
            }
            else
            {
                this.stTaxId = "";
                this.stChargeId =
                    this.dtgPaymentGridView.Rows[rowIndex].Cells["C_CHARGE_ID"].Value.ToString();
                this.ddgPaymentReason.SelectedRowKey = this.stChargeId;                    
                this.ddgPaymentReason.SelectedItem =
                    this.dtgPaymentGridView.Rows[rowIndex].Cells["PAYED FOR"].Value.ToString();
                this.currentPaymentIsCollecatable = false;
            }

            this.changeInterFaceAccordingToPaymentStatus(this.costClosed);
            this.enableDisableSaveDeleteNewButtons();
        }

        public void changeInterFaceAccordingToPaymentStatus(bool cost_Closed)
        {            
            if(cost_Closed)
            {
                this.txtInvoiceNumber.Enabled = false;
                this.dtpInvoiceDate.Enabled = false;
                this.ddgVendor.Enabled = false;
                this.ddgPayedFrom.Enabled = false;
                this.ddgPaymentReason.Enabled = false;
                this.ckIsActive.Enabled = false;
                this.ckIsEstimateAmount.Enabled = false;
                this.ckIsAmountDistributed.Enabled = false;
                this.ckSelectAllLines.Enabled = false;
                this.ntbAmount.Enabled = false;
                this.cmbPaymentType.Enabled = false;
                this.ddgPurchaseOrders.Enabled = false;
                this.ddgCommercialInvoice.Enabled = false;

                this.usersCanEditRecordDetail = false;

                this.tscmdDelete.Enabled = false;

                
            }
            else
            {
                this.txtInvoiceNumber.Enabled = true;
                this.dtpInvoiceDate.Enabled = true;
                this.ddgVendor.Enabled = true;
                this.ddgPayedFrom.Enabled = true;
                this.ddgPaymentReason.Enabled = true;
                this.ckIsActive.Enabled = true;
                this.ckIsEstimateAmount.Enabled = true;
                this.ckIsAmountDistributed.Enabled = true;
                this.ntbAmount.Enabled = true;
                this.cmbPaymentType.Enabled = true;
                this.ddgPurchaseOrders.Enabled = true;

                this.usersCanEditRecordDetail = true;

                if (this.cmbPaymentType.SelectedItem.ToString().ToUpperInvariant() != "COLLATERAL" && 
                        this.cmbPaymentType.SelectedItem.ToString().ToUpperInvariant() != "PAYMENT" &&
                        !this.ckIsAmountDistributed.Checked)
                {
                    this.ckSelectAllLines.Enabled = true ;
                }

                if (this.cmbPaymentType.SelectedItem.ToString().ToUpperInvariant() != "COLLATERAL" &&
                        !this.ckIsAmountDistributed.Checked)
                {
                    this.ddgCommercialInvoice.Enabled = true; 
                }

                this.tscmdDelete.Enabled = true;
            }
        }

        public void prepareBpartner()
        {
            this.dtAllVendors =
                this.getDataFromDb.getC_BPARTNERInfo(null/*dtOrgSelectionCriterion*/, "", "", "",
                    this.ddgVendor.SelectedItem, triaStateBool.yes, triaStateBool.Ignor,
                                triaStateBool.Ignor, triaStateBool.Ignor, true, false, "AND");

            this.dtAllVendors.Columns.Remove("AD_CLIENT_ID");
            this.dtAllVendors.Columns.Remove("AD_ORG_ID");
            this.dtAllVendors.Columns.Remove("ISACTIVE");
            this.dtAllVendors.Columns.Remove("CREATED");
            this.dtAllVendors.Columns.Remove("CREATEDBY");
            this.dtAllVendors.Columns.Remove("UPDATED");
            this.dtAllVendors.Columns.Remove("UPDATEDBY");
            this.dtAllVendors.Columns.Remove("DESCRIPTION");
            this.dtAllVendors.Columns.Remove("VALUE");
            this.dtAllVendors.Columns.Remove("Name2");
            this.dtAllVendors.Columns.Remove("ISSUMMARY");
            this.dtAllVendors.Columns.Remove("C_BP_GROUP_ID");
            this.dtAllVendors.Columns.Remove("ISONETIME");
            this.dtAllVendors.Columns.Remove("ISPROSPECT");
            //this.dtAllVendors.Columns.Remove("ISVENDOR");
            //this.dtAllVendors.Columns.Remove("ISCUSTOMER");
            //this.dtAllVendors.Columns.Remove("ISEMPLOYEE");
            this.dtAllVendors.Columns.Remove("ISSALESREP");
            this.dtAllVendors.Columns.Remove("REFERENCENO");
            this.dtAllVendors.Columns.Remove("DUNS");
            this.dtAllVendors.Columns.Remove("URL");
            this.dtAllVendors.Columns.Remove("AD_LANGUAGE");
            this.dtAllVendors.Columns.Remove("TAXID");
            this.dtAllVendors.Columns.Remove("ISTAXEXEMPT");
            this.dtAllVendors.Columns.Remove("C_INVOICESCHEDULE_ID");
            this.dtAllVendors.Columns.Remove("RATING");
            this.dtAllVendors.Columns.Remove("SALESVOLUME");
            this.dtAllVendors.Columns.Remove("NUMBEREMPLOYEES");
            this.dtAllVendors.Columns.Remove("NAICS");
            this.dtAllVendors.Columns.Remove("FIRSTSALE");
            this.dtAllVendors.Columns.Remove("ACQUSITIONCOST");
            this.dtAllVendors.Columns.Remove("POTENTIALLIFETIMEVALUE");
            this.dtAllVendors.Columns.Remove("ACTUALLIFETIMEVALUE");
            this.dtAllVendors.Columns.Remove("SHAREOFCUSTOMER");
            this.dtAllVendors.Columns.Remove("PAYMENTRULE");
            this.dtAllVendors.Columns.Remove("SO_CREDITLIMIT");
            this.dtAllVendors.Columns.Remove("SO_CREDITUSED");
            this.dtAllVendors.Columns.Remove("C_PAYMENTTERM_ID");
            this.dtAllVendors.Columns.Remove("M_PRICELIST_ID");
            this.dtAllVendors.Columns.Remove("M_DISCOUNTSCHEMA_ID");
            this.dtAllVendors.Columns.Remove("C_DUNNING_ID");
            this.dtAllVendors.Columns.Remove("ISDISCOUNTPRINTED");
            this.dtAllVendors.Columns.Remove("SO_DESCRIPTION");
            this.dtAllVendors.Columns.Remove("POREFERENCE");
            this.dtAllVendors.Columns.Remove("PAYMENTRULEPO");
            this.dtAllVendors.Columns.Remove("PO_PRICELIST_ID");
            this.dtAllVendors.Columns.Remove("PO_DISCOUNTSCHEMA_ID");
            this.dtAllVendors.Columns.Remove("PO_PAYMENTTERM_ID");
            this.dtAllVendors.Columns.Remove("DOCUMENTCOPIES");
            this.dtAllVendors.Columns.Remove("C_GREETING_ID");
            this.dtAllVendors.Columns.Remove("INVOICERULE");
            this.dtAllVendors.Columns.Remove("DELIVERYRULE");
            this.dtAllVendors.Columns.Remove("FREIGHTCOSTRULE");
            this.dtAllVendors.Columns.Remove("DELIVERYVIARULE");
            this.dtAllVendors.Columns.Remove("SALESREP_ID");
            this.dtAllVendors.Columns.Remove("SENDEMAIL");
            this.dtAllVendors.Columns.Remove("BPARTNER_PARENT_ID");
            this.dtAllVendors.Columns.Remove("INVOICE_PRINTFORMAT_ID");
            this.dtAllVendors.Columns.Remove("SOCREDITSTATUS");
            this.dtAllVendors.Columns.Remove("SHELFLIFEMINPCT");
            this.dtAllVendors.Columns.Remove("AD_ORGBP_ID");
            this.dtAllVendors.Columns.Remove("FLATDISCOUNT");
            this.dtAllVendors.Columns.Remove("TOTALOPENBALANCE");
            this.dtAllVendors.Columns.Remove("C_CASHBOOK_ID");
        }

        //procedures of the form and its control
        private void frmPurchasePaymentInvoice_Load(object sender, EventArgs e)
        {

            this.establishExistingPaymentRecordStructure();
            this.filldtExistingPaymentRecordToPaymentGridView();            
            this.dtgPaymentGridView.Visible = false;

            this.enableDisableNavigationButtons();
            this.enableDisableSaveDeleteNewButtons();
            if (this.tscmdNew.Enabled)
                this.tscmdNew_Click(sender, e);
            else
                this.changeInterFaceAccordingToPaymentStatus(false);

            this.ntbAmount.AllowNegative = true;

            this.dtPaymentSource = this.getDataAccordingToRule.generatePaymentSource(true);
            this.dtPaymentReason = this.getDataAccordingToRule.generatePaymentReason(true);
            this.dtOrgSelectionCriterion =
                 this.getDataAccordingToRule.
                            buildOrganisationSelectionCriteria
                                (new string[] { generalResultInformation.organiztionId }, true);

            this.prepareBpartner();
            this.establishValidPerformaInvoices();
            this.dtCommercialInvoice =
                this.establishValidCommercialInvoices("");
            this.fillPaymentDetailGridView();
            this.getDataAccordingToRule.determineIfUserCanCloseCost();
            //this.mnuCloseInvoice.Visible = generalResultInformation.userCanCloseInvoiceCost;
            this.mnuPrintCostSheet.Visible = generalResultInformation.userCanCloseInvoiceCost;
            if (generalResultInformation.userCanEditSettings)
                this.mnuSettings.Visible = true;

            this.visualStyler1.LoadVisualStyle(dbSettingInformationHandler.theme);

        }
        
        private void dtgPaymentGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgPaymentGridView.SelectedRows.Count <=0 &&
                this.stCurrentPaymentId != "")
            {
                for (int rowCounter = 0;
                    rowCounter < this.dtgPaymentGridView.Rows.Count; rowCounter++)
                {
                    if (this.dtgPaymentGridView.Rows[rowCounter].
                        Cells["PM_C_PURCHASEPAYMENT_ID"].Value.ToString() ==
                                this.stCurrentPaymentId)
                    {
                        this.dtgPaymentGridView.Rows[rowCounter].Selected = true;
                        break;
                    }
                }
            }
            this.enableDisableNavigationButtons();
        }

        private void dtgPaymentGridView_SelectionChanged(object sender, EventArgs e)
        {
            
            if (this.dtgPaymentGridView.SelectedRows.Count == 1)
            {
                this.intCurrentPaymentRowIndex = this.dtgPaymentGridView.SelectedRows[0].Index;
                stCurrentPaymentId =
                    this.dtgPaymentGridView.Rows[intCurrentPaymentRowIndex].Cells["PM_C_PURCHASEPAYMENT_ID"].Value.ToString();
                this.fillCurrentGirdDataToForm();
            }
            else if (this.stCurrentPaymentId != "")
            {
                for (int rowCounter = 0; rowCounter < this.dtgPaymentGridView.Rows.Count; rowCounter++)
                {
                    if (this.dtgPaymentGridView.Rows[rowCounter].Cells["PM_C_PURCHASEPAYMENT_ID"].Value.ToString() == stCurrentPaymentId)
                    {
                        this.dtgPaymentGridView.Rows[rowCounter].Selected = true;
                        break;
                    }
                }
            }
        }

        private void dtgPaymentGridView_UserClickeCell(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgPaymentGridView.SelectedRows.Count < 1)
                return;

            this.intCurrentPaymentRowIndex = 
                this.dtgPaymentGridView.SelectedRows[0].Index;

            //this.fillCurrentGirdDataToForm();

        }


        private void dtgPaymentItemDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgPaymentItemDetail.SelectedRows.Count < 1 ||
                !this.usersCanEditRecordDetail ||
                this.costClosed)
                return;

            int currentSelectedRowIndex = this.dtgPaymentItemDetail.SelectedRows[0].Index;

            if (this.dtgPaymentItemDetail.CurrentCell.OwningColumn.Index == 0 &&
                this.dtgPaymentItemDetail.CurrentCell.OwningColumn.Name == "Check" &&
                this.dtgPaymentItemDetail.CurrentCell.OwningColumn.HeaderText == "")
            {

                this.dtgPaymentItemDetail.CurrentCell.Value =
                    !(Convert.ToBoolean(this.dtgPaymentItemDetail.CurrentCell.Value.ToString()));
                this.dtCommercialInvoiceLine.Rows[currentSelectedRowIndex]["Check"] =
                    (Convert.ToBoolean(this.dtgPaymentItemDetail.CurrentCell.Value.ToString()));

                //if (this.dtCommercialInvoiceLine.Rows[currentSelectedRowIndex]["C_ORDERLINE_ID"].ToString() != "")
                //{
                //    this.dtgPaymentItemDetail.CurrentCell.Value =
                //        !(Convert.ToBoolean(this.dtgPaymentItemDetail.CurrentCell.Value.ToString()));
                //    this.dtCommercialInvoiceLine.Rows[currentSelectedRowIndex]["Check"] =
                //        (Convert.ToBoolean(this.dtgPaymentItemDetail.CurrentCell.Value.ToString()));
                //}
                //else
                //{
                //    MessageBox.Show("No Order Line Exist for Current Invoice Line.",
                //        "Buy simple", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    this.dtgPaymentItemDetail.CurrentCell.Value = false;
                //    this.dtCommercialInvoiceLine.Rows[currentSelectedRowIndex]["Check"] = false;
                //}
            }
        }
        
        
        private void ddgPurchaseOrders_SelectedItemClicked(object sender, EventArgs e)
        {            
            this.ddgPurchaseOrders.DataSource = this.dtPurchaseOrders.Copy();
            this.ddgPurchaseOrders.DataTablePrimaryKey =
                Convert.ToUInt16(this.dtPurchaseOrders.Columns.IndexOf("C_ORDER_ID"));
            this.ddgPurchaseOrders.SelectedColomnIdex =
                this.dtPurchaseOrders.Columns.IndexOf("DOCUMENTNO");            
        }

        private void ddgPurchaseOrders_selectedItemChanged(object sender, EventArgs e)
        {
            if (this.ddgPurchaseOrders.SelectedRow.Rows.Count > 0 ||
                this.ddgPurchaseOrders.SelectedRowKey != null)
            {
                this.dtOrderCommercialInvoice =
                    this.establishValidCommercialInvoices(
                        this.ddgPurchaseOrders.SelectedRowKey.ToString());
            }
            else
            {
                this.dtOrderCommercialInvoice.Clear();
            }
        }


        private void ddgPayedFrom_SelectedItemClicked(object sender, EventArgs e)
        {            
            this.ddgPayedFrom.DataSource = this.dtPaymentSource.Copy();
            this.ddgPayedFrom.DataTablePrimaryKey = 
                Convert.ToUInt16(this.dtPaymentSource.Columns.IndexOf("SOURCE_ID"));
            this.ddgPayedFrom.SelectedColomnIdex = 
                this.dtPaymentSource.Columns.IndexOf("NAME");
        }

        private void ddgPayedFrom_selectedItemChanged(object sender, EventArgs e)
        {
            if (this.ddgPayedFrom.SelectedRow.Rows.Count > 0 ||
                this.ddgPayedFrom.SelectedRowKey != null)
            {
                if (Convert.ToBoolean(this.ddgPayedFrom.SelectedRow.Rows[0]["IS BANK ACCOUNT"]))
                {
                    this.stCashBookId = "";
                    this.currentPaymentIsFromCashBook = false;
                    this.stBankAccountId =
                        Convert.ToString(this.ddgPayedFrom.SelectedRowKey);
                }
                else
                {
                    this.stBankAccountId = "";
                    this.currentPaymentIsFromCashBook = true;
                    this.stCashBookId =
                        Convert.ToString(this.ddgPayedFrom.SelectedRowKey);
                }
            }
            else
            {
                this.stCashBookId = "";
                this.stBankAccountId = "";
            }
        }                          


        private void ddgPaymentReason_SelectedItemClicked(object sender, EventArgs e)
        {            
            this.ddgPaymentReason.DataSource = this.dtPaymentReason.Copy();
            this.ddgPaymentReason.DataTablePrimaryKey =
                Convert.ToUInt16(this.dtPaymentReason.Columns.IndexOf("REASON_ID"));
            this.ddgPaymentReason.SelectedColomnIdex =
                this.dtPaymentReason.Columns.IndexOf("NAME");
        }

        private void ddgPaymentReason_selectedItemChanged(object sender, EventArgs e)
        {
            if (this.ddgPaymentReason.SelectedRow.Rows.Count > 0 ||
                this.ddgPaymentReason.SelectedRowKey != null)
            {
                if (Convert.ToBoolean(this.ddgPaymentReason.SelectedRow.Rows[0]["IS A COST"]))
                {
                    this.stTaxId = "";
                    this.currentPaymentIsCollecatable = false;
                    this.stChargeId =
                        this.ddgPaymentReason.SelectedRowKey.ToString();
                }
                else
                {
                    this.stChargeId = "";
                    this.currentPaymentIsCollecatable = true;
                    this.stTaxId =
                        this.ddgPaymentReason.SelectedRowKey.ToString();
                }
            }
            else
            {
                this.stTaxId = "";
                this.stChargeId = "";
            }
        }



        private void ddgCommercialInvoice_SelectedItemClicked(object sender, EventArgs e)
        {
            
            if(this.ddgPurchaseOrders.SelectedRowKey != null)
                this.ddgCommercialInvoice.DataSource = this.dtOrderCommercialInvoice.Copy();
            else
                this.ddgCommercialInvoice.DataSource = this.dtCommercialInvoice.Copy();
            if (this.ddgCommercialInvoice.DataSource.Rows.Count > 0)
            {
                this.ddgCommercialInvoice.DataTablePrimaryKey =
                    Convert.ToUInt16(this.ddgCommercialInvoice.DataSource.Columns.IndexOf("C_INVOICE_ID"));
                this.ddgCommercialInvoice.SelectedColomnIdex =
                    this.ddgCommercialInvoice.DataSource.Columns.IndexOf("DOCUMENTNO");
                this.ddgCommercialInvoice.HiddenColoumns = new int[] 
                                        {this.ddgCommercialInvoice.DataSource.Columns.IndexOf("C_ORDER_ID")};
            }
        }

        private void ddgCommercialInvoice_selectedItemChanged(object sender, EventArgs e)
        {
            if (this.ddgCommercialInvoice.SelectedRow.Rows.Count > 0 ||
                this.ddgCommercialInvoice.SelectedRowKey != null)
            {
                this.dtCommercialInvoiceLine =
                    this.establishCommercialInvoeceDetail(
                        this.ddgCommercialInvoice.SelectedRowKey.ToString());
                this.fillPaymentDetailGridView();
                if (this.ddgPurchaseOrders.SelectedRowKey == null)
                {
                    this.ddgPurchaseOrders.SelectedRowKey =
                        this.ddgCommercialInvoice.SelectedRow.Rows[0]["C_ORDER_ID"];
                    this.ddgPurchaseOrders.SelectedItem =
                        this.getDataFromDb.getC_ORDERInfo(null, "", "",
                                this.ddgCommercialInvoice.SelectedRow.Rows[0]["C_ORDER_ID"].ToString(),
                                "", "", "", "", "", "",triaStateBool.no, triaStateBool.yes, false, false, "AND")
                              .Rows[0]["DOCUMENTNO"].ToString();
                    this.dtOrderCommercialInvoice =
                        this.establishValidCommercialInvoices(
                            this.ddgCommercialInvoice.SelectedRow.Rows[0]["C_ORDER_ID"].ToString());
                }
            }
            else
            {
                this.dtCommercialInvoiceLine.Clear();
            }
        }



        private void ddgVendor_SelectedItemClicked(object sender, EventArgs e)
        {
            this.prepareBpartner();
            this.ddgVendor.DataSource = this.dtAllVendors.Copy();
            this.ddgVendor.DataTablePrimaryKey =
                    Convert.ToUInt16(this.ddgVendor.DataSource.Columns.IndexOf("C_BPARTNER_ID"));
            this.ddgVendor.SelectedColomnIdex =
                this.ddgVendor.DataSource.Columns.IndexOf("NAME");

        }

        private void ddgVendor_selectedItemChanged(object sender, EventArgs e)
        {
            if (this.ddgVendor.SelectedRow.Rows.Count > 0 ||
                this.ddgVendor.SelectedRowKey != null)
            {
                this.stVendorId =
                    this.ddgVendor.SelectedRowKey.ToString();
            }
            else
            {
                this.stVendorId = "";
            }
        }

        

        private void ckIsAmountDistributed_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckIsAmountDistributed.Checked)
            {
                this.ddgCommercialInvoice.Enabled = false;
                this.ddgCommercialInvoice.SelectedItem = "";
                this.ddgCommercialInvoice.SelectedRowKey = null;
                this.ddgCommercialInvoice.SelectedRow.Clear();
                this.ddgCommercialInvoice_selectedItemChanged(sender, e);
                this.ckSelectAllLines.Checked = false;
                this.ckSelectAllLines.Enabled = false;
            }
            else
            {
                this.ddgCommercialInvoice.Enabled = true;
                this.ckSelectAllLines.Enabled = true;
            }
        }

        private void ckSelectAllLines_CheckedChanged(object sender, EventArgs e)
        {

            if (this.costClosed)
            {
                return;
            }

            if (this.dtCommercialInvoiceLine.Rows.Count <= 0 ||
                this.dtgPaymentItemDetail.Rows.Count <= 0)
                return;

            for (int rowCounter = this.dtCommercialInvoiceLine.Rows.Count-1; rowCounter >= 0; rowCounter--)
            {

                this.dtgPaymentItemDetail.Rows[rowCounter].Cells["Check"].Value =
                    this.ckSelectAllLines.Checked;
                this.dtCommercialInvoiceLine.Rows[rowCounter]["Check"] =
                    this.ckSelectAllLines.Checked;
                //if (this.dtCommercialInvoiceLine.Rows[rowCounter]["C_ORDERLINE_ID"].ToString() != "")
                //{
                //    this.dtgPaymentItemDetail.Rows[rowCounter].Cells["Check"].Value =
                //        this.ckSelectAllLines.Checked;
                //    this.dtCommercialInvoiceLine.Rows[rowCounter]["Check"] =
                //        this.ckSelectAllLines.Checked;
                //}
                //else
                //{
                //    this.dtgPaymentItemDetail.Rows[rowCounter].Cells["Check"].Value =
                //        false;
                //    this.dtCommercialInvoiceLine.Rows[rowCounter]["Check"] =
                //        false;
                //}
            }
        }

         
        private void tscmdRefresh_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            clearForm();
            this.reLoadSearchResult();
            this.Enabled = true;
        }

        private void tscmdNew_Click(object sender, EventArgs e)
        {
            this.Enabled = false;            
            this.stCurrentPaymentId = "";
            this.currentPaymentIsCollecatable = false;
            this.currentPaymentIsFromCashBook = false;            
            this.dtPaymentDetailInfo.Clear();            
            this.clearForm();
            this.enableDisableSaveDeleteNewButtons();
            this.enableDisableNavigationButtons();
            this.enableDisableFormElement();
            this.Enabled = true;
        }

        private void tscmdRecord_Click(object sender, EventArgs e)
        {
            if (checkAllFieldsExistForInsertion())
            {
                MessageBox.Show("Please Insert Required Entries Before You Proceed.",
                    "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Enabled = false;
            
            if (this.stCurrentPaymentId == "")
            {
                this.stDmlType = "Insert";
            }
            else
            {
                this.determineIfCurrentRecordIsChanged();
                if (this.changeIsMadeToCurrentRecord)
                {
                    this.Enabled = true;
                    if ((MessageBox.Show("Are You Sure You Like To Save The Highlited Changes?",
                        "Update Alert.", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.No)
                    {
                        this.resetLableColor();
                        return;
                    }
                }
                else
                {
                    this.Enabled = true;
                    this.resetLableColor();
                    return;
                }
                this.stDmlType = "Update";
            }
            this.Enabled = false;            
            this.executeSaveUpadateDeletePaymentOperation();
            this.insertOrUpdateRecordToExistingPaymentList();
            if (this.stDmlType == "Insert")
            {
                int? indexOfRow = 
                    (this.dtgPaymentGridView.Rows.Cast<DataGridViewRow>()
                                .Where(r => r.Cells["PM_C_PURCHASEPAYMENT_ID"].Value.ToString() == this.stCurrentPaymentId)
                                .Select(r => r.Index)).First();

                if (indexOfRow.HasValue && indexOfRow.Value != -1)
                {
                    this.dtgPaymentGridView.Rows[indexOfRow.Value].Selected = true;
                }
                else if (this.dtgPaymentGridView.Rows.Count > 0)
                    this.dtgPaymentGridView.Rows[this.dtgPaymentGridView.Rows.Count - 1].Selected = true;                
                
            }
            this.enableDisableNavigationButtons();
            this.enableDisableSaveDeleteNewButtons();
            this.resetLableColor();            
            this.Enabled = true;
        }

        private void tscmdDelete_Click(object sender, EventArgs e)
        {
            if (this.dtgPaymentGridView.SelectedRows.Count != 1 && stCurrentPaymentId == "")
                return;

            if (this.dtgPaymentGridView.SelectedRows[0].Cells["PM_C_PURCHASEPAYMENT_ID"].Value.ToString() != this.stCurrentPaymentId)
            {
                return; 
            }

            if (this.stCurrentPaymentId != "")
            {
                DialogResult result = MessageBox.Show("Do You Want to Delete the Current Payment Record ?",
                    "Delete Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;
                this.Enabled = false;
                this.stDmlType = "Delete";
                this.executeSaveUpadateDeletePaymentOperation();

                this.dtexistingPaymentRecord.AsEnumerable()
                    .Where(r => r.Field<decimal>("PM_C_PURCHASEPAYMENT_ID") == decimal.Parse(this.stCurrentPaymentId))
                    .ToList().ForEach(row => row.Delete());
                this.dtexistingPaymentRecord.AcceptChanges();

                if (((this.intCurrentPaymentRowIndex - 1) < this.dtgPaymentGridView.Rows.Count) &&
                ((this.intCurrentPaymentRowIndex - 1) > -1))
                {
                    this.dtgPaymentGridView.Rows[this.intCurrentPaymentRowIndex - 1].Selected = true;                    
                }
                else if (this.dtgPaymentGridView.Rows.Count > 0)
                {
                    this.dtgPaymentGridView.Rows[0].Selected = true;
                }
                else
                {
                    if (this.tscmdNew.Enabled)
                        this.tscmdNew_Click(sender, e);
                    else
                    {
                        this.dtexistingPaymentRecord.Clear();
                        this.clearForm();
                        this.changeInterFaceAccordingToPaymentStatus(true);
                    }
                }
                
                this.enableDisableNavigationButtons();
                this.enableDisableSaveDeleteNewButtons();
                this.Enabled = true;
            }
        }
                       

        private void tscmdSearch_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            frmSearchPayment searchPayments = new frmSearchPayment();            
            searchPayments.ShowDialog();
            this.establishExistingPaymentRecordStructure();
            this.filldtExistingPaymentRecordToPaymentGridView();
            if (dtgPaymentGridView.Rows.Count > 0)
                dtgPaymentGridView.Rows[0].Selected = true;
            this.enableDisableNavigationButtons();
            this.enableDisableSaveDeleteNewButtons();
            this.Enabled = true;
        }

        private void tscmdToggleView_Click(object sender, EventArgs e)
        {
            if (currentViewIsgridView)
            {
                
                this.dtgPaymentGridView.Visible = false;
                this.dtgPaymentGridView.Dock = DockStyle.None;
                this.dtgPaymentGridView.Size = new Size(585, 10);
                currentViewIsgridView = false;
            }
            else
            {
                this.dtgPaymentGridView.BringToFront();
                this.dtgPaymentGridView.Dock = DockStyle.Fill;
                this.dtgPaymentGridView.Visible = true;
                currentViewIsgridView = true;
            }
            this.enableDisableNavigationButtons();
            this.enableDisableSaveDeleteNewButtons();
        }
       

        private void tscmdFirstRecord_Click(object sender, EventArgs e)
        {
            if (this.dtgPaymentGridView.Rows.Count < 1)
                return;
            this.dtgPaymentGridView.Rows[0].Selected = true;
            this.enableDisableNavigationButtons();
            this.enableDisableFormElement();
            //this.dtgPaymentGridView_UserClickeCell(sender, new DataGridViewCellEventArgs(0, 0));
        }

        private void tscmdPreviousRecord_Click(object sender, EventArgs e)
        {
            if (this.dtgPaymentGridView.Rows.Count < 1)
                return;
            if (this.intCurrentPaymentRowIndex == 0)
                return;
            this.dtgPaymentGridView.Rows[this.intCurrentPaymentRowIndex - 1].Selected = true;
            this.enableDisableNavigationButtons();
            this.enableDisableFormElement();
            //this.dtgPaymentGridView_UserClickeCell(sender, new DataGridViewCellEventArgs(0,
            //    this.intCurrentPaymentRowIndex - 1));
        }

        private void tscmdNextRecord_Click(object sender, EventArgs e)
        {
            if (this.dtgPaymentGridView.Rows.Count < 1)
                return;
            if (this.intCurrentPaymentRowIndex ==
                this.dtgPaymentGridView.Rows.Count - 1)
                return;
            this.dtgPaymentGridView.Rows[this.intCurrentPaymentRowIndex + 1].Selected = true;
            this.enableDisableNavigationButtons();
            this.enableDisableFormElement();
            //this.dtgPaymentGridView_UserClickeCell(sender, new DataGridViewCellEventArgs(0,
            //    this.intCurrentPaymentRowIndex + 1));
        }

        private void tscmdLastRecord_Click(object sender, EventArgs e)
        {
            if (this.dtgPaymentGridView.Rows.Count < 1)
                return;
            this.dtgPaymentGridView.Rows[this.dtgPaymentGridView.Rows.Count - 1].Selected = true;
            this.enableDisableNavigationButtons();
            this.enableDisableFormElement();
            //this.dtgPaymentGridView_UserClickeCell(sender, new DataGridViewCellEventArgs(0,
            //    this.dtgPaymentGridView.Rows.Count - 1));
        }
        
        private void tscmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void mnuDistributeRemaining_Click(object sender, EventArgs e)
        {

            frmDistributeRemainingCost frmDistributeRmngCost = new frmDistributeRemainingCost();
            this.WindowState = FormWindowState.Minimized;
            frmDistributeRmngCost.WindowState = FormWindowState.Normal;
            frmDistributeRmngCost.ShowDialog(this);
            this.WindowState = FormWindowState.Normal;

        }


        private void mnuCloseInvoice_Click(object sender, EventArgs e)
        {
            frmGenerateItemCost closeInvoiceCost = new frmGenerateItemCost();
            this.WindowState = FormWindowState.Minimized;
            closeInvoiceCost.WindowState = FormWindowState.Normal;
            closeInvoiceCost.ShowDialog(this);
            this.dtexistingPaymentRecord.Clear();
            this.clearForm();
            this.WindowState = FormWindowState.Normal;
        }
        

        private void mnuPrintCostSheet_Click(object sender, EventArgs e)
        {
            frmGenerateCostSheet printCostSheet = new frmGenerateCostSheet();
            this.WindowState = FormWindowState.Minimized;
            printCostSheet.WindowState = FormWindowState.Normal;
            printCostSheet.ShowDialog(this);
            //this.dtexistingPaymentRecord.Clear();
            //this.clearForm();
            this.WindowState = FormWindowState.Normal;
        }


        private void mnuExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuSettings_Click(object sender, EventArgs e)
        {
            frmsettings frmDbSettings = new frmsettings();
            frmDbSettings.ShowDialog();
            MessageBox.Show("Change to setting parameter shall not take effect until you reopen this program.", 
                "Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void frmPurchasePaymentInvoice_DoubleClick(object sender, EventArgs e)
        {
            this.changeUserInterface();
        }

        private void frmPurchasePaymentInvoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataTable dtSettingsTable = new DataTable();
            string settingFile = dbSettingInformationHandler.settingFilePath;
            bool settingFound = false;

            dtSettingsTable.TableName = "Settings";
            dtSettingsTable.Columns.Add("Parameter_Name");
            dtSettingsTable.Columns.Add("Parameter_Value");

            if (File.Exists(settingFile))
            {
                try
                {
                    dtSettingsTable =
                        this.getDataAccordingToRule.readEncryptedXmlSettingFile(settingFile);

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
           
        }

        private void cmbPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.costClosed)
            {
                return;
            }

            if (this.cmbPaymentType.SelectedItem.ToString().ToUpperInvariant() == "INVOICE" ||
                this.cmbPaymentType.SelectedItem.ToString().ToUpperInvariant() == "NOTE")
            {
                this.ddgPayedFrom.Enabled = false;
                this.ddgPayedFrom.SelectedItem = "";
                this.ddgPayedFrom.SelectedRowKey = null;
                this.ddgPayedFrom.SelectedRow.Clear();
                this.ddgPayedFrom_selectedItemChanged(sender, e);
            }
            else
            {
                this.ddgPayedFrom.Enabled = true;
            }

            if (this.cmbPaymentType.SelectedItem.ToString().ToUpperInvariant() == "COLLATERAL")
            {
                this.ddgCommercialInvoice.Enabled = false;
                this.ddgCommercialInvoice.SelectedItem = "";
                this.ddgCommercialInvoice.SelectedRowKey = null;
                this.ddgCommercialInvoice.SelectedRow.Clear();
                this.ddgCommercialInvoice_selectedItemChanged(sender, e);

                this.ckSelectAllLines.Checked = false;
                this.ckSelectAllLines.Enabled = false;
            }
            else if (this.cmbPaymentType.SelectedItem.ToString().ToUpperInvariant() == "PAYMENT" ||
                this.cmbPaymentType.SelectedItem.ToString().ToUpperInvariant() == "CANCELLATION")
            {
                this.ddgCommercialInvoice.Enabled = true;
                this.ckSelectAllLines.Checked = false;
                this.ckSelectAllLines.Enabled = false;
            }
            else 
            {
                this.ddgCommercialInvoice.Enabled = !this.ckIsAmountDistributed.Checked;
                this.ckSelectAllLines.Enabled = !this.ckIsAmountDistributed.Checked;
            }
        }

        

    }
}
