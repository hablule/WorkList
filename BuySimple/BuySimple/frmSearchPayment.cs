using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BuySimple
{
    public partial class frmSearchPayment : Form
    {
        public frmSearchPayment()
        {
            InitializeComponent();
        }

        string stVendorId = "";

        DataTable dtAllVendors = new DataTable();
        DataTable searchQuery = new DataTable();
        DataTable dtPurchaseOrders = new DataTable();        
        DataTable dtCommercialInvoice = new DataTable();
        DataTable dtPaymentSource = new DataTable();
        DataTable dtPaymentReason = new DataTable();

        dataBuilder getDataFromDb = new dataBuilder();
        businessRule getDataAccordingToRule = new businessRule();
        

        private void enableDisableValueInsertionBox(string Logic, Control valueInsertionBox)
        {            
            if (Logic == "IGNOR")
                valueInsertionBox.Enabled = false;
            else
                valueInsertionBox.Enabled = true;
        }

        private string generateEquivalentSymbol(string symbolInText)
        { 
            if(symbolInText=="Equals to")
                return "=";
            if(symbolInText=="Not equals to")
                return "!=";
            if(symbolInText=="Similar to")
                return "like";
            if(symbolInText=="Not similar to")
                return "not like";
            if(symbolInText=="Greater than")
                return ">";
            if(symbolInText=="Greater or equals to")
                return ">=";
            if (symbolInText == "Less than")
                return "<";
            if(symbolInText=="Lesser or equal to")
                return "<=";
            return "";
        }

        private void establishSearchCriteria()
        {
            if (cmbInvoiceNumberLogic.SelectedItem.ToString() != "IGNOR")
            {

                if (cmbInvoiceNumberLogic.SelectedItem.ToString() == "In between of")
                {
                    DataRow criteriaValue = this.searchQuery.NewRow();

                    criteriaValue["Field"] = "DOCUMENTNO";
                    criteriaValue["Criterion"] = ">=";
                    criteriaValue["Value"] = txtInvoiceNumberFrom.Text;
                    this.searchQuery.Rows.Add(criteriaValue);

                    criteriaValue = this.searchQuery.NewRow();
                    criteriaValue["Field"] = "DOCUMENTNO";
                    criteriaValue["Criterion"] = "<=";
                    criteriaValue["Value"] = txtInvoiceNumberTo.Text;
                    this.searchQuery.Rows.Add(criteriaValue);
                }
                else
                {
                    DataRow criteriaValue = this.searchQuery.NewRow();
                    criteriaValue["Field"] = "DOCUMENTNO";
                    criteriaValue["Criterion"] = 
                        generateEquivalentSymbol(cmbInvoiceNumberLogic.SelectedItem.ToString());
                    if (criteriaValue["Criterion"].ToString() == "like")
                        criteriaValue["Value"] = "%" + txtInvoiceNumberFrom.Text + "%";
                    else
                        criteriaValue["Value"] = txtInvoiceNumberFrom.Text;
                    this.searchQuery.Rows.Add(criteriaValue);
                }
            }

            if (cmbVendorNameLogic.SelectedItem.ToString() != "IGNOR" && 
                this.stVendorId != "")
                
            {
                DataRow criteriaValue = this.searchQuery.NewRow();
                criteriaValue["Field"] = "C_BPARTNER_ID";
                criteriaValue["Criterion"] =
                    generateEquivalentSymbol(cmbVendorNameLogic.SelectedItem.ToString());
                if (criteriaValue["Criterion"].ToString() == "like")
                    criteriaValue["Value"] = "%" + this.stVendorId + "%";
                else
                    criteriaValue["Value"] = this.stVendorId;
                this.searchQuery.Rows.Add(criteriaValue);
            }
            if (cmbInvoiceDateLogic.SelectedItem.ToString() != "IGNOR")
            {
                if (cmbInvoiceDateLogic.SelectedItem.ToString() == "In between of")
                {
                    DataRow criteriaValue = this.searchQuery.NewRow();

                    criteriaValue["Field"] = "DATEINVOICED";
                    criteriaValue["Criterion"] = ">=";
                    criteriaValue["Value"] = dtpInvoiceDateFrom.Value.ToString("dd-MMM-yyyy");
                    this.searchQuery.Rows.Add(criteriaValue);

                    criteriaValue = this.searchQuery.NewRow();
                    criteriaValue["Field"] = "DATEINVOICED";
                    criteriaValue["Criterion"] = "<=";
                    criteriaValue["Value"] = dtpInvoiceDateTo.Value.ToString("dd-MMM-yyyy");
                    this.searchQuery.Rows.Add(criteriaValue);
                }
                else
                {
                    DataRow criteriaValue = this.searchQuery.NewRow();
                    criteriaValue["Field"] = "DATEINVOICED";
                    criteriaValue["Criterion"] =
                        generateEquivalentSymbol(cmbInvoiceDateLogic.SelectedItem.ToString());
                    if (criteriaValue["Criterion"].ToString() == "like")
                        criteriaValue["Value"] = "%" + dtpInvoiceDateFrom.Value.ToString("dd-MMM-yyyy") + "%";
                    else
                        criteriaValue["Value"] = dtpInvoiceDateFrom.Value.ToString("dd-MMM-yyyy");
                    this.searchQuery.Rows.Add(criteriaValue);
                }
            }

            if (cmbPayedFromLogic.SelectedItem.ToString() != "IGNOR" && 
                ddgPayedFrom.SelectedRowKey != null)
            {
                DataRow criteriaValue = this.searchQuery.NewRow();
                if (ddgPayedFrom.SelectedRow.Rows[0]["Type"].ToString() == "Cash Book")
                    criteriaValue["Field"] = "C_CASHBOOK_ID";
                else
                    criteriaValue["Field"] = "C_BANKACCOUNT_ID";
                criteriaValue["Criterion"] =
                    generateEquivalentSymbol(cmbPayedFromLogic.SelectedItem.ToString());
                if (criteriaValue["Criterion"].ToString() == "like")
                    criteriaValue["Value"] = "%" + ddgPayedFrom.SelectedRowKey.ToString() + "%";
                else
                    criteriaValue["Value"] = ddgPayedFrom.SelectedRowKey.ToString();
                this.searchQuery.Rows.Add(criteriaValue);
            }

            if (cmbAmountPaidLogic.SelectedItem.ToString() != "IGNOR")
            {
                if (cmbAmountPaidLogic.SelectedItem.ToString() == "In between of")
                {
                    DataRow criteriaValue = this.searchQuery.NewRow();

                    criteriaValue["Field"] = "INVOICEAMOUNT";
                    criteriaValue["Criterion"] = ">=";
                    criteriaValue["Value"] = ntbInvoiceAmountFrom.Amount.Replace(",", "");
                    this.searchQuery.Rows.Add(criteriaValue);

                    criteriaValue = this.searchQuery.NewRow();
                    criteriaValue["Field"] = "INVOICEAMOUNT";
                    criteriaValue["Criterion"] = "<=";
                    criteriaValue["Value"] = ntbInvoiceAmountTo.Amount.Replace(",", ""); ;
                    this.searchQuery.Rows.Add(criteriaValue);
                }
                else
                {
                    DataRow criteriaValue = this.searchQuery.NewRow();
                    criteriaValue["Field"] = "INVOICEAMOUNT";
                    criteriaValue["Criterion"] =
                        generateEquivalentSymbol(cmbAmountPaidLogic.SelectedItem.ToString());
                    if (criteriaValue["Criterion"].ToString() == "like")
                        criteriaValue["Value"] = "%" + 
                            ntbInvoiceAmountFrom.Amount.Replace(",", "").ToUpperInvariant() + "%";
                    else
                        criteriaValue["Value"] = ntbInvoiceAmountFrom.Amount.Replace(",", "");
                    this.searchQuery.Rows.Add(criteriaValue);
                }
                
            }

            if (this.ckIsEstimate.CheckState != CheckState.Indeterminate)
            {
                DataRow criteriaValue = this.searchQuery.NewRow();
                criteriaValue["Field"] = "ISAMOUNTESTIMATE";
                criteriaValue["Criterion"] = "=";
                if (this.ckIsEstimate.CheckState == CheckState.Checked)
                    criteriaValue["Value"] = 'Y';
                else
                    criteriaValue["Value"] = 'N';
                this.searchQuery.Rows.Add(criteriaValue);
            }

            if (this.ckIsActive.CheckState != CheckState.Indeterminate)
            {
                DataRow criteriaValue = this.searchQuery.NewRow();
                criteriaValue["Field"] = "ISACTIVE";
                criteriaValue["Criterion"] = "=";
                if (this.ckIsActive.CheckState == CheckState.Checked)
                    criteriaValue["Value"] = 'Y';
                else
                    criteriaValue["Value"] = 'N';
                this.searchQuery.Rows.Add(criteriaValue);
            }

            if (this.ckIsDistributable.CheckState != CheckState.Indeterminate)
            {
                DataRow criteriaValue = this.searchQuery.NewRow();
                criteriaValue["Field"] = "ISAMOUNTDISTRIBUTABLE";
                criteriaValue["Criterion"] = "=";
                if (this.ckIsDistributable.CheckState == CheckState.Checked)
                    criteriaValue["Value"] = 'Y';
                else
                    criteriaValue["Value"] = 'N';
                this.searchQuery.Rows.Add(criteriaValue);
            }

            if (cmbPurchaseOrderLogic.SelectedItem.ToString() != "IGNOR" && 
                ddgPurchaseOrder.SelectedRowKey != null)
            {
                DataRow criteriaValue = this.searchQuery.NewRow();
                criteriaValue["Field"] = "C_ORDER_ID";
                criteriaValue["Criterion"] =
                    generateEquivalentSymbol(cmbPurchaseOrderLogic.SelectedItem.ToString());
                if (criteriaValue["Criterion"].ToString() == "like")
                    criteriaValue["Value"] = "%" + ddgPurchaseOrder.SelectedRowKey.ToString() + "%";
                else
                    criteriaValue["Value"] = ddgPurchaseOrder.SelectedRowKey.ToString();
                this.searchQuery.Rows.Add(criteriaValue);
            }

            if (cmbCommercialInvoiceLogic.SelectedItem.ToString() != "IGNOR" &&
                ddgCommercialInvoice.SelectedRowKey != null)
            {
                DataRow criteriaValue = this.searchQuery.NewRow();
                criteriaValue["Field"] = "C_INVOICE_ID";
                criteriaValue["Criterion"] =
                    generateEquivalentSymbol(cmbCommercialInvoiceLogic.SelectedItem.ToString());
                if (criteriaValue["Criterion"].ToString() == "like")
                    criteriaValue["Value"] = "%" + ddgCommercialInvoice.SelectedRowKey.ToString() + "%";
                else
                    criteriaValue["Value"] = ddgCommercialInvoice.SelectedRowKey.ToString();
                this.searchQuery.Rows.Add(criteriaValue);
            }

            if (cmbPaymentReasonLogic.SelectedItem.ToString() != "IGNOR" && 
                ddgPaymentReason.SelectedRowKey != null)
            {
                DataRow criteriaValue = this.searchQuery.NewRow();
                if (ddgPaymentReason.SelectedRow.Rows[0]["Type"].ToString() == "Collecatable Tax")
                    criteriaValue["Field"] = "C_TAX_ID";
                else
                    criteriaValue["Field"] = "C_CHARGE_ID";
                criteriaValue["Criterion"] =
                    generateEquivalentSymbol(cmbPaymentReasonLogic.SelectedItem.ToString());
                if (criteriaValue["Criterion"].ToString() == "like")
                    criteriaValue["Value"] = "%" + ddgPaymentReason.SelectedRowKey.ToString() + "%";
                else
                    criteriaValue["Value"] = ddgPaymentReason.SelectedRowKey.ToString();
                this.searchQuery.Rows.Add(criteriaValue);
            }
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
                            "CL", "CO", "", triaStateBool.no, triaStateBool.yes, true, false, "AND");
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
            for (int rowCounter = 0; rowCounter <= dtCommercilInvoices.Rows.Count - 1;
                rowCounter++)
            {
                if (dtCommercilInvoices.Rows[rowCounter]["C_ORDER_ID"] == null)
                    continue;
                dtCommercilInvoices.Rows[rowCounter]["PAYED TO"] =
                    this.getDataFromDb.getC_BPARTNERInfo(null, "", "",
                              dtCommercilInvoices.Rows[rowCounter]["C_BPARTNER_ID"].ToString(),
                              "", triaStateBool.Ignor, triaStateBool.Ignor, triaStateBool.Ignor,
                              triaStateBool.Ignor, false, false, "AND").Rows[0]["NAME"].ToString();
            }
            dtCommercilInvoices.Columns.RemoveAt(
                dtCommercilInvoices.Columns.IndexOf("C_BPARTNER_ID"));
            return dtCommercilInvoices;
        }



        //procedures of the form and its control
        private void frmSearchPayment_Load(object sender, EventArgs e)
        {
            generalResultInformation.searchResult.Clear();
            generalResultInformation.searchCritrion.Clear();
            generalResultInformation.logicConnector = "";

            this.cmbAmountPaidLogic.SelectedItem = "IGNOR";
            this.cmbInvoiceDateLogic.SelectedItem = "IGNOR";
            this.cmbInvoiceNumberLogic.SelectedItem = "IGNOR";
            this.cmbPayedFromLogic.SelectedItem = "IGNOR";
            this.cmbPaymentReasonLogic.SelectedItem = "IGNOR";
            this.cmbPurchaseOrderLogic.SelectedItem = "IGNOR";
            this.cmbCommercialInvoiceLogic.SelectedItem = "IGNOR";
            this.cmbVendorNameLogic.SelectedItem = "IGNOR";

            this.dtpInvoiceDateFrom.Value = DateTime.Today;
            this.dtpInvoiceDateTo.Value = DateTime.Today;
            this.ckIsActive.CheckState = CheckState.Indeterminate;
            this.ckIsEstimate.CheckState = CheckState.Indeterminate;
            this.ckIsDistributable.CheckState = CheckState.Indeterminate;            

            this.searchQuery.Columns.Add("Field");
            this.searchQuery.Columns.Add("Criterion");
            this.searchQuery.Columns.Add("Value");

            this.cmbVendors_KeyUp(sender, new KeyEventArgs(Keys.Enter));
            this.dtPaymentSource = this.getDataAccordingToRule.generatePaymentSource(true);
            this.dtPaymentReason = this.getDataAccordingToRule.generatePaymentReason(true);
            this.establishValidPerformaInvoices();
            this.dtCommercialInvoice =
                this.establishValidCommercialInvoices("");
        }
                
        private void cmbInvoiceNumberLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableDisableValueInsertionBox(cmbInvoiceNumberLogic.SelectedItem.ToString(),
                txtInvoiceNumberFrom);
            if (cmbInvoiceNumberLogic.SelectedItem.ToString() == "In between of")
                txtInvoiceNumberTo.Visible = true;
            else
            {
                txtInvoiceNumberTo.Visible = false;
                txtInvoiceNumberTo.Text = "";
            }

        }
        

        private void cmbVendors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbVendors.SelectedIndex >= 0 &&
                this.cmbVendors.SelectedIndex <= this.dtAllVendors.Rows.Count - 1)
            {
                this.stVendorId =
                    this.dtAllVendors.Rows[this.cmbVendors.SelectedIndex]
                            ["C_BPARTNER_ID"].ToString();
            }
            else
            {
                this.stVendorId = "";
            }
        }

        private void cmbVendors_KeyUp(object sender, KeyEventArgs e)
        {
            this.dtAllVendors =
                this.getDataFromDb.getC_BPARTNERInfo(
                        this.getDataAccordingToRule.
                            buildOrganisationSelectionCriteria
                                (new string[] { generalResultInformation.organiztionId }, true),
                                "OR", "", "", "", triaStateBool.yes, triaStateBool.Ignor,
                                triaStateBool.Ignor, triaStateBool.Ignor, false, false, "AND");
            this.comboItemFilter(this.cmbVendors, this.dtAllVendors, e, "NAME");
        }

        private void cmbVendors_DropDownClosed(object sender, EventArgs e)
        {
            if (this.cmbVendors.SelectedItem != null)
                this.cmbVendors.Text = this.cmbVendors.SelectedItem.ToString();

            this.cmbVendors_KeyUp(sender, new KeyEventArgs(Keys.Enter));

            this.comboBoxDropDownClosed(this.cmbVendors, this.dtAllVendors,
                this.cmbVendors_SelectedIndexChanged, sender);
        }
       

        private void cmbVendorNameLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableDisableValueInsertionBox(cmbVendorNameLogic.SelectedItem.ToString(),
                this.cmbVendors);
        }

        private void cmbInvoiceDateLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableDisableValueInsertionBox(cmbInvoiceDateLogic.SelectedItem.ToString(),
                dtpInvoiceDateFrom);
            if (cmbInvoiceDateLogic.SelectedItem.ToString() == "In between of")
            {
                dtpInvoiceDateTo.Visible = true;
                dtpInvoiceDateTo.Value = DateTime.Today;
            }
            else
            {
                dtpInvoiceDateTo.Visible = false;
                dtpInvoiceDateTo.Value = DateTime.Today;
            }
        }

        private void cmbPayedFromLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableDisableValueInsertionBox(cmbPayedFromLogic.SelectedItem.ToString(),
                ddgPayedFrom);    
        }

        private void cmbAmountPaidLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableDisableValueInsertionBox(cmbAmountPaidLogic.SelectedItem.ToString(),
                ntbInvoiceAmountFrom);
            if (cmbAmountPaidLogic.SelectedItem.ToString() == "In between of")
                ntbInvoiceAmountTo.Visible = true;
            else
            {
                ntbInvoiceAmountTo.Visible = false;
                ntbInvoiceAmountTo.Amount = "";
            }
        }

        private void cmbPurchaseOrderLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableDisableValueInsertionBox(cmbPurchaseOrderLogic.SelectedItem.ToString(),
                ddgPurchaseOrder);
        }

        private void cmbCommercialInvoiceLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableDisableValueInsertionBox(cmbCommercialInvoiceLogic.SelectedItem.ToString(),
                ddgCommercialInvoice);
        }
        
        private void cmbPaymentReasonLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableDisableValueInsertionBox(cmbPaymentReasonLogic.SelectedItem.ToString(),
                ddgPaymentReason);   
        }
        

        private void ddgPayedFrom_SelectedItemClicked(object sender, EventArgs e)
        {
            this.ddgPayedFrom.DataSource = this.dtPaymentSource.Copy();
            this.ddgPayedFrom.DataTablePrimaryKey =
                Convert.ToUInt16(this.dtPaymentSource.Columns.IndexOf("SOURCE_ID"));
            this.ddgPayedFrom.SelectedColomnIdex =
                this.dtPaymentSource.Columns.IndexOf("NAME");
        }
        
        private void ddgPurchaseOrder_SelectedItemClicked(object sender, EventArgs e)
        {
            this.ddgPurchaseOrder.DataSource = this.dtPurchaseOrders.Copy();
            this.ddgPurchaseOrder.DataTablePrimaryKey =
                Convert.ToUInt16(this.dtPurchaseOrders.Columns.IndexOf("C_ORDER_ID"));
            this.ddgPurchaseOrder.SelectedColomnIdex =
                this.dtPurchaseOrders.Columns.IndexOf("DOCUMENTNO");
        }

        private void ddgCommercialInvoice_SelectedItemClicked(object sender, EventArgs e)
        {
            this.ddgCommercialInvoice.DataSource = this.dtCommercialInvoice.Copy();
            if (this.ddgCommercialInvoice.DataSource.Rows.Count > 0)
            {
                this.ddgCommercialInvoice.DataTablePrimaryKey =
                    Convert.ToUInt16(this.ddgCommercialInvoice.DataSource.Columns.IndexOf("C_INVOICE_ID"));
                this.ddgCommercialInvoice.SelectedColomnIdex =
                    this.ddgCommercialInvoice.DataSource.Columns.IndexOf("DOCUMENTNO");
                this.ddgCommercialInvoice.HiddenColoumns = new int[] { this.ddgCommercialInvoice.DataSource.Columns.IndexOf("C_ORDER_ID") };
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


        private void cmdSearch_Click(object sender, EventArgs e)
        {
            DialogResult considerPreviousCriteria =
                MessageBox.Show("Should New Search Result Consider Previous Criterion", "Look Up",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (considerPreviousCriteria == DialogResult.Cancel)
                return;

            this.Enabled = false;

            DataTable currentSearchCriteriaResult = new DataTable();

            this.searchQuery.Clear();
            this.establishSearchCriteria();
            currentSearchCriteriaResult =
                this.getDataAccordingToRule.
                    getPaymentRecordAccordingToCriterion(this.searchQuery, this.ckAllOrAny.Checked);

            if (considerPreviousCriteria == DialogResult.Yes)
            {
                if (!this.getDataFromDb.checkIfTableContainesData
                (currentSearchCriteriaResult))
                {
                    MessageBox.Show("No Record Found For Search Query",
                        "Look Up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    generalResultInformation.searchResult.Clear();
                    this.Enabled = true;
                    return;
                }
                if (generalResultInformation.searchResult.Rows.Count <= 0)
                {
                    generalResultInformation.searchResult =
                        currentSearchCriteriaResult.Copy();
                }
                else
                {
                    generalResultInformation.searchResult =
                        this.getDataFromDb.mergeTables(generalResultInformation.searchResult,
                        currentSearchCriteriaResult, "PM_C_PURCHASEPAYMENT_ID", true);
                }
            }

            else if (considerPreviousCriteria == DialogResult.No)
            {
                generalResultInformation.searchResult =
                    this.getDataFromDb.mergeTables(generalResultInformation.searchResult,
                            currentSearchCriteriaResult, "PM_C_PURCHASEPAYMENT_ID", false);
            }
            this.Enabled = true;
        }

        private void cmbShowRestult_Click(object sender, EventArgs e)
        {
            if (generalResultInformation.searchResult.Rows.Count > 0)
            {
                if (this.ckAllOrAny.Checked)
                    generalResultInformation.logicConnector = "OR";
                else
                    generalResultInformation.logicConnector = "AND";
                this.Close();
            }
            else
                MessageBox.Show("No Payment Results Found", "Search Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
          
    }
}
