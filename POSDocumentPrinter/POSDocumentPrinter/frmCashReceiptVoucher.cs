using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace POSDocumentPrinter
{
    public partial class frmCashReceiptVoucher : Form
    {
        public frmCashReceiptVoucher()
        {
            InitializeComponent();
        }

        
        # region "Top Level Variables"
        /// <Top Level Variables>
        /// variable to be used accross this form
        /// <\Top Level Variables>
        /// 

        // bool
        bool recordView = true;

        // int
        int intCurrReceiptSelectedRowIndex = -1;
        int intCurrReceiptDtlSelectedRowIndex = -1;
        
        // Strings
        string stPaymentID = "";
        string stBpartnerID = "";
        string stOtherIncomeID = "";

        // Decimals
        decimal dcCurrInvAllowedReceipt = 0;
        decimal dcCurrInvAmt = 0;
        decimal dcCurrInvReceivedAmt = 0;
        decimal dcCurrePaymentDetailTotal = 0;
        decimal dcCurrInvPreviousTotalReceipt = 0;
        decimal dcTotalReceipt = 0;
        
        
        // Tables
        DataTable dtExistingReceipt = new DataTable();
        DataTable dtNewReceiptDetail = new DataTable();


        DataTable dtCustomerList = new DataTable();
        DataTable dtCustomerSalesList = new DataTable();
        DataTable dtCustomerExemptionList = new DataTable();
        DataTable dtIdenticalCustomersList = new DataTable();

        DataTable dtOtherIncomeList = new DataTable();

        DataTable dtActiveOrganisations = new DataTable();        

        // Others
        Color normalFieldColor = Color.Black;
        Color missingFieldColor = Color.Red;
        Color ChangedFieldColor = Color.Blue;

        DataGridViewCellStyle cancelButtonStyle = new DataGridViewCellStyle();

        dataBuilder getDataFromDb = new dataBuilder();


        #endregion



        private void newForm()
        {
            this.intCurrReceiptSelectedRowIndex = -1;
            this.intCurrReceiptDtlSelectedRowIndex = -1;

            this.dcCurrInvAllowedReceipt = 0;
            this.dcCurrInvAmt = 0;
            this.dcCurrInvReceivedAmt = 0;
            this.dcCurrePaymentDetailTotal = 0;
            this.dcTotalReceipt = 0;
            this.dcCurrInvPreviousTotalReceipt = 0;

            this.stBpartnerID = "";
            this.stPaymentID = "";
            this.stOtherIncomeID = "";

            this.txtOrganisation.Text = "";
            if (this.cmbOrganisation.Items.Count > 0)
                this.cmbOrganisation.SelectedIndex = 0;
            this.txtDocumentNo.Text = "";
            this.dtpDate.Value = DateTime.Now;
            
            this.ddgCustomers.SelectedRowKey = null;
            this.ddgCustomers.SelectedRow.Clear();
            this.ddgCustomers.SelectedItem = "";

            
            this.ntbTotalPayedAmount.Amount = "0";

            this.cmbTenderType.SelectedIndex = 0;
            this.txtInstrumentNo.Text = "";

            this.txtDescriptionMain.Text = "";

            this.txtUnAllocatedAmount.Text = "0";

            this.ckIsBillingPartener.Checked = false;            
            this.ckIsDownPayment.Checked = false;
            this.ckIsExemption.Checked = false;
            this.ckIsOtherIncome.Checked = false;

            
            this.ddgInvoice.SelectedRowKey = null;
            this.ddgInvoice.SelectedRow.Clear();
            this.ddgInvoice.SelectedItem = "";


            this.ddgOtherIncome.SelectedRowKey = null;
            this.ddgOtherIncome.SelectedRow.Clear();
            this.ddgOtherIncome.SelectedItem = "";
            
            this.ntbAmountPaid.Amount = "0";
            
            this.txtAmountDue.Text = "0";
            this.txtOverUnderAmt.Text = "0";
            this.txtDescriptionDtl.Text = "";
                       

            this.lblDocumentNo.ForeColor = normalFieldColor;
            this.lblCustomers.ForeColor = this.normalFieldColor;
            this.lblPaidBy.ForeColor = this.normalFieldColor;


            this.dtNewReceiptDetail.Rows.Clear();
            
            this.dtgReceiptDtl.Columns["remove"].Visible = true;

            this.txtOrganisation.Visible = false;
            this.cmbOrganisation.Visible = true;

            this.dtpDate.Enabled = true;
            this.txtDocumentNo.Enabled = true;
            this.cmbTenderType.Enabled = true;
            this.txtInstrumentNo.Enabled = true;
            this.txtDescriptionMain.Enabled = true;
            this.ckIsDownPayment.Enabled = true;
            this.ckIsBillingPartener.Enabled = true;

            this.ddgCustomers.Enabled = true;

            this.ddgOtherIncome.Enabled = false;
            
            this.ntbTotalPayedAmount.Enabled = true;

            this.dtNewReceiptDetail.Rows.Clear();

            this.ddgInvoice.Enabled = false;
            this.ntbAmountPaid.Enabled = false;
            this.txtDescriptionDtl.Enabled = false;
            this.cmdAdd.Enabled = false;

            this.cmdAllocate.Visible = false;
            this.cmdAllocate.Enabled = false;

            this.tlsConfirm.Enabled = true;

            this.sbStatus.Text = "";
        }

        private bool isFormComplete()
        {
            bool formIsComplete = true;

            if (this.txtDocumentNo.Text == "")
            {
                this.lblDocumentNo.ForeColor = missingFieldColor;
                formIsComplete = false;
            }
            else
                this.lblDocumentNo.ForeColor = normalFieldColor;

            if (this.isDocumentInUse())
            {
                MessageBox.Show("Document Number is already in use." +
                           "\n Enter a different Document number to proceed.", "New Collection",
                           MessageBoxButtons.OKCancel, MessageBoxIcon.Information,
                           MessageBoxDefaultButton.Button1);

                this.lblDocumentNo.ForeColor = missingFieldColor;
                formIsComplete = false;
            }
            else
                this.lblDocumentNo.ForeColor = normalFieldColor;

                                   


            if (this.ddgCustomers.SelectedRowKey == null ||
                this.ddgCustomers.SelectedItem == "")
            {
                this.lblCustomers.ForeColor = this.missingFieldColor;
                formIsComplete = false;
            }
            else
                this.lblCustomers.ForeColor = this.normalFieldColor;

            if ((this.ddgOtherIncome.SelectedRowKey == null ||
                this.ddgOtherIncome.SelectedItem == "") &&
                this.ckIsOtherIncome.Checked)
            {
                this.lblOtherIncome.ForeColor = this.missingFieldColor;
                formIsComplete = false;
            }
            else
                this.lblOtherIncome.ForeColor = this.normalFieldColor;


            if (this.dtgReceiptDtl.Rows.Count <= 0 && !this.ckIsDownPayment.Checked && !this.ckIsOtherIncome.Checked)
            {
                this.dtgReceiptDtl.BackgroundColor = this.missingFieldColor;
                formIsComplete = false;
            }
            else
                this.dtgReceiptDtl.BackgroundColor = SystemColors.Control;

            if (this.txtInstrumentNo.Visible && 
                this.txtInstrumentNo.Text == "")
            {
                this.lblPaidBy.ForeColor = this.missingFieldColor;
                formIsComplete = false;
            }
            else
                this.lblPaidBy.ForeColor = SystemColors.Control;

            if (!this.ckIsDownPayment.Checked && !this.ckIsOtherIncome.Checked)
            {

                if (decimal.Parse(this.txtUnAllocatedAmount.Text).CompareTo(generalResultInformation.overAmtLimit * -1) == 1 ||
                    decimal.Parse(this.txtUnAllocatedAmount.Text).CompareTo(generalResultInformation.shortAmtLimit * -1) == -1)
                {
                    if (!formIsComplete)
                    {
                        this.lblUnallocatedAmt.ForeColor = missingFieldColor;
                        formIsComplete = false;
                    }
                    else if (
                       MessageBox.Show("Total Amount Is not Balance." +
                           "\n Enter pass key to proceed.", "New Collection",
                           MessageBoxButtons.OKCancel, MessageBoxIcon.Information,
                           MessageBoxDefaultButton.Button1) == DialogResult.OK)
                    {
                        generalResultInformation.CustomerName = this.ddgCustomers.SelectedItem;
                        generalResultInformation.InvoiceNumber = "*";

                        frmValidateSecurityKey allowAmount = new frmValidateSecurityKey();
                        allowAmount.TopMost = true;
                        allowAmount.ShowDialog();

                        if (generalResultInformation.securityPassKeyCorrect)
                        {
                            this.lblUnallocatedAmt.ForeColor = normalFieldColor;
                        }
                        else
                        {
                            this.lblUnallocatedAmt.ForeColor = missingFieldColor;
                            formIsComplete = false;
                        }

                    }
                    else
                    {
                        this.lblUnallocatedAmt.ForeColor = missingFieldColor;
                        formIsComplete = false;
                    }
                }
                else if (decimal.Parse(this.txtUnAllocatedAmount.Text).CompareTo(new decimal(-0.5)) == -1 ||
                    decimal.Parse(this.txtUnAllocatedAmount.Text).CompareTo(new decimal(0.5)) == 1)
                {
                    if (
                        MessageBox.Show("Total Amount Is not Balance." +
                            " Do you want to proceed.", "New Collection",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1) == DialogResult.No)
                    {
                        this.lblUnallocatedAmt.ForeColor = missingFieldColor;
                        formIsComplete = false;
                    }
                    else
                        this.lblUnallocatedAmt.ForeColor = normalFieldColor;
                }
                else
                    this.lblUnallocatedAmt.ForeColor = normalFieldColor;
            }


            return formIsComplete;
        }

        private bool isDocumentInUse()
        {
            if (this.txtDocumentNo.Text == "")
                return true;

            DataTable dtCRVinfo =
                this.getDataFromDb.getC_PAYMENTInfo(null, "", "", this.txtDocumentNo.Text, 
                        "", DateTime.Now, false, tenderType.ignor, "", generalResultInformation.Station,
                        false, false, "AND");
            if (!this.getDataFromDb.checkIfTableContainesData(dtCRVinfo))
            {
                return false; 
            }
            else
            {
                return true; 
            }
        }

        private bool invoiceInCurrentDetail(string salesID)
        {
            string isExmp = this.ckIsExemption.Checked ? "Y" : "N";
            foreach (DataRow dr in this.dtNewReceiptDetail.Rows)
            {
                if (dr["C_INVOICE_ID"].ToString() == salesID &&
                    dr["ISEXEMPTION"].ToString() == isExmp)
                    return true;
            }            
            return false;
        }

        private void enableNavigationButton()
        {
            if (this.dtgReceiptSummary.Rows.Count <= 1)
            {
                this.tlsFirstRecord.Enabled = false;
                this.tlsPreviousRecord.Enabled = false;
                this.tlsNextRecord.Enabled = false;
                this.tlsLastRecord.Enabled = false;
                return;
            }

            if (this.dtgReceiptSummary.SelectedRows[0].Index ==
                this.dtgReceiptSummary.Rows.Count - 1)
            {
                this.tlsFirstRecord.Enabled = true;
                this.tlsPreviousRecord.Enabled = true;
                this.tlsNextRecord.Enabled = false;
                this.tlsLastRecord.Enabled = false;
                return;
            }

            if (this.dtgReceiptSummary.SelectedRows[0].Index == 0)
            {
                this.tlsFirstRecord.Enabled = false;
                this.tlsPreviousRecord.Enabled = false;
                this.tlsNextRecord.Enabled = true;
                this.tlsLastRecord.Enabled = true;
                return;
            }

            this.tlsFirstRecord.Enabled = true;
            this.tlsPreviousRecord.Enabled = true;
            this.tlsNextRecord.Enabled = true;
            this.tlsLastRecord.Enabled = true;
        }

        private void enableReceiptDetail(bool enabled)
        {
            this.ckIsExemption.Enabled = enabled;
            //this.dtgReceiptDtl.Enabled = enabled;
            this.ddgInvoice.Enabled = enabled;
            this.ntbAmountPaid.Enabled = enabled;
            this.txtDescriptionDtl.Enabled = enabled;
            this.cmdAdd.Enabled = enabled;
        }

        private void createDetailReceiptTable()
        {
            this.dtNewReceiptDetail =
                this.getDataFromDb.getC_PAYMENTALLOCATEInfo(null, "", "", "", "",
                    triaStateBool.Ignor, generalResultInformation.Station, false, true, "AND");

            this.dtNewReceiptDetail.Columns.Add("remove");
            this.dtNewReceiptDetail.Columns.Add("Sn");
            this.dtNewReceiptDetail.Columns.Add("Document No");
            this.dtNewReceiptDetail.Columns.Add("Date Sold");
            this.dtNewReceiptDetail.Columns.Add("Invoiced");            

            this.dtNewReceiptDetail.Columns["remove"].SetOrdinal(0);
            this.dtNewReceiptDetail.Columns["Sn"].SetOrdinal(1);
            this.dtNewReceiptDetail.Columns["Document No"].SetOrdinal(2);
            this.dtNewReceiptDetail.Columns["Date Sold"].SetOrdinal(3);
            this.dtNewReceiptDetail.Columns["Invoiced"].SetOrdinal(4);
            this.dtNewReceiptDetail.Columns["INVOICEAMT"].SetOrdinal(5);
            this.dtNewReceiptDetail.Columns["AMOUNT"].SetOrdinal(6);
            this.dtNewReceiptDetail.Columns["OVERUNDERAMT"].SetOrdinal(7);


            this.dtgReceiptDtl.DataSource = 
                this.dtNewReceiptDetail;

            this.dtgReceiptDtl.Columns["C_PAYMENTALLOCATE_ID"].Visible = false;
            this.dtgReceiptDtl.Columns["AD_ORG_ID"].Visible = false;            
            this.dtgReceiptDtl.Columns["C_PAYMENT_ID"].Visible = false;
            this.dtgReceiptDtl.Columns["CREATED"].Visible = false;
            this.dtgReceiptDtl.Columns["CREATEDBY"].Visible = false;
            this.dtgReceiptDtl.Columns["UPDATED"].Visible = false;
            this.dtgReceiptDtl.Columns["UPDATEDBY"].Visible = false;
            this.dtgReceiptDtl.Columns["ISACTIVE"].Visible = false;
            this.dtgReceiptDtl.Columns["C_INVOICE_ID"].Visible = false;
            this.dtgReceiptDtl.Columns["DESCRIPTION"].Visible = false;
            this.dtgReceiptDtl.Columns["STATION_ID"].Visible = false;


            this.dtgReceiptDtl.Columns["remove"].HeaderText = "";
            this.dtgReceiptDtl.Columns["INVOICEAMT"].HeaderText = "Due";
            this.dtgReceiptDtl.Columns["AMOUNT"].HeaderText = "Paid";            
            this.dtgReceiptDtl.Columns["OVERUNDERAMT"].HeaderText = "Remaing";
            this.dtgReceiptDtl.Columns["ISEXEMPTION"].HeaderText = "Exmption";

            this.dtgReceiptDtl.Columns["remove"].DefaultCellStyle = this.cancelButtonStyle;

            foreach (DataGridViewColumn columns in this.dtgReceiptDtl.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DisplayIndex = columns.Index;
            }
        }

        private void fillDetailReceiptTable(string C_PAYMENT_ID)
        {
            if (C_PAYMENT_ID == "")
                return;
            this.dtNewReceiptDetail.Rows.Clear();

            DataTable receiptDtlInfo =
                this.getDataFromDb.getC_PAYMENTALLOCATEInfo(null, "", "",
                    C_PAYMENT_ID, "",  triaStateBool.Ignor, "", false, false, "AND");

            foreach (DataRow dr in receiptDtlInfo.Rows)
            {
                DataRow recptDtl = this.dtNewReceiptDetail.NewRow();
                foreach (DataColumn dc in receiptDtlInfo.Columns)
                {
                    string colName = dc.ColumnName;
                    recptDtl[colName] = dr[colName];
                }
                recptDtl["remove"] = "";

                if (dr["ISEXEMPTION"].ToString() == "Y")
                {
                    DataTable salesInf =
                        this.getDataFromDb.getC_EXEMPTIONInfo(null, "",
                            dr["C_INVOICE_ID"].ToString(), "",
                            "", DateTime.Now, false, exemptionType.ignor, dr["STATION_ID"].ToString(),
                            false, false, "AND");

                    recptDtl["Document No"] = salesInf.Rows[0]["DOCUMENTNO"].ToString();
                    recptDtl["Date Sold"] = salesInf.Rows[0]["DATEINVOICED"].ToString();
                    recptDtl["Invoiced"] = salesInf.Rows[0]["EXEMPTEDAMT"].ToString();
                }
                else
                {

                    DataTable salesInf =
                        this.getDataFromDb.getSalesInfo(null, "",
                            dr["C_INVOICE_ID"].ToString(), dr["STATION_ID"].ToString(),
                            "", "", "", triaStateBool.Ignor,
                            false, false, false, "AND");
                    if (this.getDataFromDb.checkIfTableContainesData(salesInf))
                    {
                        recptDtl["Document No"] = salesInf.Rows[0]["ref_no"].ToString();
                        recptDtl["Date Sold"] = salesInf.Rows[0]["salesDateTime"].ToString();
                        recptDtl["Invoiced"] = salesInf.Rows[0]["total_amount"].ToString();
                    }
                    else
                    {
                        recptDtl["Document No"] = "0";
                        recptDtl["Date Sold"] = DateTime.Now.ToString();
                        recptDtl["Invoiced"] = "0";
                    }
                }

                recptDtl["Sn"] = this.dtNewReceiptDetail.Rows.Count + 1;

                this.dtNewReceiptDetail.Rows.Add(recptDtl);
            }

            this.dtgReceiptDtl.Columns["remove"].Visible = false;
        }

        private void loadSearchResultDataToExistingMainRecord()
        {
            this.dtExistingReceipt.Rows.Clear();
            DataRow drExistingReceipt;
            for (int rowCounter = 0;
                    rowCounter <= generalResultInformation.searchResult.Rows.Count - 1;
                    rowCounter++)
            {
                drExistingReceipt = this.dtExistingReceipt.NewRow();

                drExistingReceipt["C_PAYMENT_ID"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["C_PAYMENT_ID"].ToString();
                drExistingReceipt["AD_ORG_ID"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["AD_ORG_ID"].ToString();
                drExistingReceipt["DOCUMENTNO"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["DOCUMENTNO"].ToString();
                drExistingReceipt["DATETRX"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["DATETRX"].ToString();
                drExistingReceipt["DESCRIPTION"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["DESCRIPTION"].ToString();
                drExistingReceipt["C_BPARTNER_ID"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["C_BPARTNER_ID"].ToString();
                if (generalResultInformation.searchResult.Rows[rowCounter]["C_CHARGE_ID"].ToString() != "")
                {
                    drExistingReceipt["C_CHARGE_ID"] =
                        generalResultInformation.searchResult.Rows[rowCounter]["C_CHARGE_ID"].ToString();
                }
                drExistingReceipt["TENDERTYPE"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["TENDERTYPE"].ToString();
                drExistingReceipt["CHECKNO"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["CHECKNO"].ToString();

                
                DataTable CustomerInfo = this.getDataFromDb.getCustomersInfo(null, "",
                        generalResultInformation.searchResult.Rows[rowCounter]["C_BPARTNER_ID"].ToString(),
                        generalResultInformation.searchResult.Rows[rowCounter]["STATION_ID"].ToString()
                        , "", "", triaStateBool.Ignor, false, "AND");

                if (!this.getDataFromDb.checkIfTableContainesData(CustomerInfo))
                {
                    drExistingReceipt["Customer"] = "NOT AVAILABLE";
                }
                else
                    drExistingReceipt["Customer"] = CustomerInfo.Rows[0]["customer_name"].ToString();

                DataTable OtherIncomeInfo = this.getDataFromDb.getC_CHARGEInfo(null, "",
                        generalResultInformation.searchResult.Rows[rowCounter]["C_CHARGE_ID"].ToString(), "", 
                        generalResultInformation.centralStation, 
                        false, false, "AND");

                if (!this.getDataFromDb.checkIfTableContainesData(OtherIncomeInfo))
                {
                    drExistingReceipt["Other Income"] = "NOT AVAILABLE";
                }
                else
                    drExistingReceipt["Other Income"] = OtherIncomeInfo.Rows[0]["NAME"].ToString();

                DataTable OrgInfo = this.getDataFromDb.getnodesInfo(null, "", "",
                        generalResultInformation.searchResult.Rows[rowCounter]["STATION_ID"].ToString(),
                        generalResultInformation.searchResult.Rows[rowCounter]["AD_ORG_ID"].ToString(),
                        triaStateBool.Ignor, false, "AND");

                if (!this.getDataFromDb.checkIfTableContainesData(OrgInfo))
                {
                    drExistingReceipt["Organisation"] = "NOT AVAILABLE";
                }
                else
                    drExistingReceipt["Organisation"] = OrgInfo.Rows[0]["node"].ToString();


                drExistingReceipt["PAYAMT"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["PAYAMT"].ToString();
                drExistingReceipt["ISADVANCE"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["ISADVANCE"].ToString();
                drExistingReceipt["ISBILLINGPARTNER"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["ISBILLINGPARTNER"].ToString();


                drExistingReceipt["STATION_ID"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["STATION_ID"].ToString();

                this.dtExistingReceipt.Rows.Add(drExistingReceipt);
            }
        }


        private void tlsNew_Click(object sender, EventArgs e)
        {
            this.newForm();
        }

        private void tlsSave_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            if (!this.isFormComplete())
            {
                this.Enabled = true;
                if (!this.recordView)
                    this.tlsChangeView_Click(sender, e);
                MessageBox.Show("Please Insert the missing fields before you proceed.",
                    "Save record", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                return;
            }
            

            DataTable newReceiptSummary =
                this.getDataFromDb.getC_PAYMENTInfo(null, "", "", "", "", DateTime.Now, false,
                         tenderType.ignor, "", "", false, true, "AND");

            DataRow drNewReceiptDetail = newReceiptSummary.NewRow();

            drNewReceiptDetail["AD_ORG_ID"] =
                this.dtActiveOrganisations.Rows[this.cmbOrganisation.SelectedIndex]["AD_ORG_ID"].ToString();
            drNewReceiptDetail["DOCUMENTNO"] = this.txtDocumentNo.Text;
            drNewReceiptDetail["DATETRX"] = this.dtpDate.Value.ToString("yyyy-MM-dd");
            drNewReceiptDetail["DESCRIPTION"] = this.txtDescriptionMain.Text;
            drNewReceiptDetail["C_BPARTNER_ID"] = this.ddgCustomers.SelectedRowKey.ToString();
            if (this.ckIsOtherIncome.Checked)
            {
                drNewReceiptDetail["C_CHARGE_ID"] = this.ddgOtherIncome.SelectedRowKey.ToString();
            }
            drNewReceiptDetail["TENDERTYPE"] = this.cmbTenderType.SelectedItem.ToString();
            drNewReceiptDetail["CHECKNO"] = this.txtInstrumentNo.Text;
            drNewReceiptDetail["PAYAMT"] = this.ntbTotalPayedAmount.Amount;
            drNewReceiptDetail["ISADVANCE"] = 
                this.ckIsDownPayment.Checked ? "Y" : "N";
            drNewReceiptDetail["STATION_ID"] = generalResultInformation.Station;
            

            newReceiptSummary.Rows.Add(drNewReceiptDetail);

            dbCommitFailure.dbCommitError = false;
            string[] recordId =
                this.getDataFromDb.changeDataBaseTableData(newReceiptSummary, "C_PAYMENT", "INSERT", true);

            // If There Is A DB error Return)
            if (dbCommitFailure.dbCommitError)
            {
                this.sbStatus.Text = "Record IS NOT Saved";
                this.Enabled = true;
                return;
            }
            else
            {
                this.sbStatus.Text = ""; 
            }

            string[] newRecordId = new string[(recordId.Length * 2)];

            string[] primaryKeySepartor = { " <(", ")>||" };
            for (int arrayIndexCounter = 0;
                 arrayIndexCounter <= recordId.Length - 1;
                 arrayIndexCounter++)
            {
                recordId[arrayIndexCounter].Split(primaryKeySepartor,
                    StringSplitOptions.RemoveEmptyEntries).
                        CopyTo(newRecordId, (arrayIndexCounter * 2));
            }

            if (newRecordId.Length < 2)
            {
                this.Enabled = true;
                this.sbStatusLabel.Text = "Record IS NOT Saved";
                return;
            }

            for (int currentDetailRecord = 0;
                 currentDetailRecord <= this.dtNewReceiptDetail.Rows.Count - 1;
                 currentDetailRecord++)
            {
                this.dtNewReceiptDetail.Rows[currentDetailRecord]["C_PAYMENT_ID"] =
                    newRecordId[1];
                this.dtNewReceiptDetail.Rows[currentDetailRecord]["AD_ORG_ID"] =
                    this.dtActiveOrganisations.Rows[this.cmbOrganisation.SelectedIndex]["AD_ORG_ID"].ToString();
                this.dtNewReceiptDetail.Rows[currentDetailRecord]["STATION_ID"] =
                    generalResultInformation.Station;
            }

            this.getDataFromDb.changeDataBaseTableData(this.dtNewReceiptDetail.Copy(), "C_PAYMENTALLOCATE", "INSERT", true);

            DataRow drExistingReceipt = this.dtExistingReceipt.NewRow();

            drExistingReceipt["C_PAYMENT_ID"] = newRecordId[1];
            drExistingReceipt["AD_ORG_ID"] =
                this.dtActiveOrganisations.Rows[this.cmbOrganisation.SelectedIndex]["AD_ORG_ID"].ToString();
            drExistingReceipt["Organisation"] = this.cmbOrganisation.SelectedItem.ToString();
            drExistingReceipt["DOCUMENTNO"] = this.txtDocumentNo.Text;
            drExistingReceipt["DATETRX"] = this.dtpDate.Value.ToString("yyyy-MM-dd");
            drExistingReceipt["DESCRIPTION"] = this.txtDescriptionMain.Text;
            drExistingReceipt["C_BPARTNER_ID"] = this.ddgCustomers.SelectedRowKey.ToString();
            drExistingReceipt["Customer"] = this.ddgCustomers.SelectedItem;
            if (this.ckIsOtherIncome.Checked)
            {
                drExistingReceipt["C_CHARGE_ID"] = this.ddgOtherIncome.SelectedRowKey.ToString();
            }
            drExistingReceipt["Other Income"] = this.ddgOtherIncome.SelectedItem;
            drExistingReceipt["TENDERTYPE"] = this.cmbTenderType.SelectedItem.ToString();
            drExistingReceipt["CHECKNO"] = this.txtInstrumentNo.Text;
            drExistingReceipt["PAYAMT"] = this.ntbTotalPayedAmount.Amount;
            drExistingReceipt["STATION_ID"] = generalResultInformation.Station;

            this.dtExistingReceipt.Rows.Add(drExistingReceipt);

            MessageBox.Show("New Record Saved Successfully.",
                    "Save record", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            this.Enabled = true;
            this.tlsLastRecord_Click(sender, e);
            this.dtgReceiptSummary_CellClick(sender, e);
        }


        private void tlsConfirm_Click(object sender, EventArgs e)
        {
            this.tlsSave_Click(sender, e);            
        }

        private void tlsSearch_Click(object sender, EventArgs e)
        {
            generalResultInformation.searchResult.Rows.Clear();
            generalResultInformation.searchCritrion.Rows.Clear();

            this.dtExistingReceipt.Rows.Clear();
            this.dtNewReceiptDetail.Rows.Clear();
            this.enableNavigationButton();
            this.newForm();

            frmSearchPayment newSearch = new frmSearchPayment();
            newSearch.ShowDialog(this);
            this.loadSearchResultDataToExistingMainRecord();
            if (this.dtgReceiptSummary.Rows.Count > 0)
            {
                this.dtgReceiptSummary.Rows[0].Selected = true;
                this.dtgReceiptSummary_CellClick(sender, new DataGridViewCellEventArgs(0, 0));
            }
            
        }

        private void tlsChangeView_Click(object sender, EventArgs e)
        {
            if (this.recordView)
            {
                this.recordView = false;
                this.dtgReceiptSummary.Size = new System.Drawing.Size(538, 406);
                this.dtgReceiptSummary.Visible = true;
                this.dtgReceiptSummary.BringToFront();
            }
            else
            {
                this.dtgReceiptSummary.Visible = false;
                this.dtgReceiptSummary.Size = new System.Drawing.Size(538, 11);
                this.recordView = true;
            }
        }


        private void tlsFirstRecord_Click(object sender, EventArgs e)
        {
            this.dtgReceiptSummary.Rows[0].Selected = true;
        }

        private void tlsPreviousRecord_Click(object sender, EventArgs e)
        {
            if (this.intCurrReceiptSelectedRowIndex == -1)
            {
                if (this.dtgReceiptSummary.SelectedRows.Count < 1)
                {
                    return;
                }
                else
                    this.intCurrReceiptSelectedRowIndex =
                        this.dtgReceiptSummary.SelectedRows[0].Index;
            }

            this.dtgReceiptSummary.Rows[this.intCurrReceiptSelectedRowIndex - 1].Selected = true;
        }

        private void tlsNextRecord_Click(object sender, EventArgs e)
        {
            if (this.intCurrReceiptSelectedRowIndex == -1)
            {
                if (this.dtgReceiptSummary.SelectedRows.Count < 1)
                {
                    return;
                }
                else
                    this.intCurrReceiptSelectedRowIndex =
                        this.dtgReceiptSummary.SelectedRows[0].Index;
            }

            this.dtgReceiptSummary.Rows[this.intCurrReceiptSelectedRowIndex + 1].Selected = true;
        }

        private void tlsLastRecord_Click(object sender, EventArgs e)
        {
            this.dtgReceiptSummary.Rows[this.dtgReceiptSummary.Rows.Count - 1].Selected = true;
        }


        private void tlsPrint_Click(object sender, EventArgs e)
        {
            if (this.stPaymentID == "")
                return;

            //dtsPOSDocumentData dtsNewCRV = new dtsPOSDocumentData();
            generalResultInformation.dtsDocumentPrintView.Tables["dtPaymentSummary"].Clear();
            generalResultInformation.dtsDocumentPrintView.Tables["dtPaymentDetail"].Clear();

            DataRow drNewPaymentSummary = 
                generalResultInformation.dtsDocumentPrintView.Tables["dtPaymentSummary"].NewRow();

            drNewPaymentSummary["C_PAYMENT_ID"] = this.stPaymentID;
            drNewPaymentSummary["Store"] = this.txtOrganisation.Text;
            drNewPaymentSummary["Received From"] = this.ddgCustomers.SelectedItem;
            drNewPaymentSummary["Date"] = this.dtpDate.Value;
            drNewPaymentSummary["Reference"] = this.txtDocumentNo.Text;
            drNewPaymentSummary["Tender Type"] = this.cmbTenderType.SelectedItem.ToString();
            drNewPaymentSummary["Tender No."] = this.txtInstrumentNo.Text;
            drNewPaymentSummary["Other Income"] = this.ddgOtherIncome.SelectedItem;
            drNewPaymentSummary["Amount"] = decimal.Parse(this.ntbTotalPayedAmount.Value);
            drNewPaymentSummary["Amount In Word"] = this.getDataFromDb.changeToWords(this.ntbTotalPayedAmount.Amount, true);
            drNewPaymentSummary["Description"] = 
                this.ckIsDownPayment.Checked? "[This is Advance Payment]" + this.txtDescriptionMain.Text : this.txtDescriptionMain.Text;
            drNewPaymentSummary["UnAllocated Amt"] = decimal.Parse(this.txtUnAllocatedAmount.Text);

            generalResultInformation.dtsDocumentPrintView.Tables["dtPaymentSummary"].Rows.Add(drNewPaymentSummary);

            DataTable paymentInfo =
                this.getDataFromDb.getC_PAYMENTInfo(null, "AND", this.stPaymentID, "",
                    "", DateTime.Now, false, tenderType.ignor, "",
                    generalResultInformation.Station, false, false, "AND");

            if (this.getDataFromDb.checkIfTableContainesData(paymentInfo))
            {
                this.getDataFromDb.getUserFullName(paymentInfo.Rows[0]["CREATEDBY"].ToString());
            }
            else
            {
                this.getDataFromDb.getUserFullName("");
            }
            

            DataRow drNewPaymentDetail;

            if (this.dtNewReceiptDetail.Rows.Count <= 0)
            {
                drNewPaymentDetail =
                    generalResultInformation.dtsDocumentPrintView.Tables["dtPaymentDetail"].NewRow();

                drNewPaymentDetail["C_PAYMENTALLOCATE_ID"] = DBNull.Value;
                drNewPaymentDetail["C_PAYMENT_ID"] = this.stPaymentID;
                drNewPaymentDetail["Sn"] = DBNull.Value;
                drNewPaymentDetail["Invoice"] = DBNull.Value;
                drNewPaymentDetail["Dated"] = DBNull.Value;
                drNewPaymentDetail["Invoiced"] = DBNull.Value;
                drNewPaymentDetail["Pending"] = DBNull.Value;
                drNewPaymentDetail["Paid"] = DBNull.Value;
                drNewPaymentDetail["Remaining"] = DBNull.Value;
                drNewPaymentDetail["Description"] = DBNull.Value;

                generalResultInformation.dtsDocumentPrintView.Tables["dtPaymentDetail"].Rows.Add(drNewPaymentDetail);

            }
            else
            {
                for (int rowCounter = 0; rowCounter <= this.dtNewReceiptDetail.Rows.Count - 1; rowCounter++)
                {
                    drNewPaymentDetail =
                        generalResultInformation.dtsDocumentPrintView.Tables["dtPaymentDetail"].NewRow();

                    drNewPaymentDetail["C_PAYMENTALLOCATE_ID"] =
                        this.dtNewReceiptDetail.Rows[rowCounter]["C_PAYMENTALLOCATE_ID"].ToString();
                    drNewPaymentDetail["C_PAYMENT_ID"] =
                        this.dtNewReceiptDetail.Rows[rowCounter]["C_PAYMENT_ID"].ToString();
                    drNewPaymentDetail["Sn"] =
                        this.dtNewReceiptDetail.Rows[rowCounter]["Sn"].ToString();
                    drNewPaymentDetail["Invoice"] =
                        this.dtNewReceiptDetail.Rows[rowCounter]["Document No"].ToString();
                    drNewPaymentDetail["Dated"] =
                        DateTime.Parse(this.dtNewReceiptDetail.Rows[rowCounter]["Date Sold"].ToString());
                    drNewPaymentDetail["Invoiced"] =
                        decimal.Parse(this.dtNewReceiptDetail.Rows[rowCounter]["Invoiced"].ToString());
                    drNewPaymentDetail["Pending"] =
                        decimal.Parse(this.dtNewReceiptDetail.Rows[rowCounter]["INVOICEAMT"].ToString());
                    drNewPaymentDetail["Paid"] =
                        decimal.Parse(this.dtNewReceiptDetail.Rows[rowCounter]["AMOUNT"].ToString());
                    drNewPaymentDetail["Remaining"] =
                        decimal.Parse(this.dtNewReceiptDetail.Rows[rowCounter]["OVERUNDERAMT"].ToString());
                    drNewPaymentDetail["Description"] =
                        this.dtNewReceiptDetail.Rows[rowCounter]["DESCRIPTION"].ToString();

                    generalResultInformation.dtsDocumentPrintView.Tables["dtPaymentDetail"].Rows.Add(drNewPaymentDetail);
                }
            }

            generalResultInformation.requestedReport = reportType.CashReceiptVoucher;
            frmDocPrintPreview frmCRVPrintPreview = new frmDocPrintPreview();
            frmCRVPrintPreview.ShowDialog();

            this.Enabled = true;
        }

        private void tlsExit_Click(object sender, EventArgs e)
        {
            this.Close();
        } 



        private void frmCashReceiptVoucher_Load(object sender, EventArgs e)
        {
            this.dtIdenticalCustomersList.Columns.Add("Field");
            this.dtIdenticalCustomersList.Columns.Add("Criterion");
            this.dtIdenticalCustomersList.Columns.Add("Value");
            
            this.cancelButtonStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.cancelButtonStyle.BackColor = Color.FromKnownColor(KnownColor.ControlDark);
            this.cancelButtonStyle.ForeColor = Color.FromKnownColor(KnownColor.Desktop);
            this.cancelButtonStyle.SelectionForeColor = Color.FromKnownColor(KnownColor.DarkBlue);
            this.cancelButtonStyle.WrapMode = DataGridViewTriState.False;
            this.cancelButtonStyle.Font =
                new System.Drawing.Font("Microsoft Sans Serif", 8.25F,
                    System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


            this.createDetailReceiptTable();

            this.enableReceiptDetail(false);


            this.dtExistingReceipt =
                this.getDataFromDb.getC_PAYMENTInfo(null, "", "", "", "", DateTime.Now, false,
                         tenderType.ignor, "", "",  false, true, "AND");

            this.dtExistingReceipt.Columns.Add("Customer");
            this.dtExistingReceipt.Columns.Add("Organisation");
            this.dtExistingReceipt.Columns.Add("Other Income");

            this.dtgReceiptSummary.DataSource =
                this.dtExistingReceipt;

            this.dtgReceiptSummary.Columns["C_PAYMENT_ID"].Visible = false;
            this.dtgReceiptSummary.Columns["AD_ORG_ID"].Visible = false;
            this.dtgReceiptSummary.Columns["CREATED"].Visible = false;
            this.dtgReceiptSummary.Columns["CREATEDBY"].Visible = false;
            this.dtgReceiptSummary.Columns["UPDATED"].Visible = false;
            this.dtgReceiptSummary.Columns["UPDATEDBY"].Visible = false;
            this.dtgReceiptSummary.Columns["ISACTIVE"].Visible = false;
            this.dtgReceiptSummary.Columns["DESCRIPTION"].Visible = false;
            this.dtgReceiptSummary.Columns["C_BPARTNER_ID"].Visible = false;
            this.dtgReceiptSummary.Columns["C_CHARGE_ID"].Visible = false;
            this.dtgReceiptSummary.Columns["PROCESSED"].Visible = false;
            this.dtgReceiptSummary.Columns["STATION_ID"].Visible = false;

            this.dtExistingReceipt.Columns["Organisation"].SetOrdinal(0);
            this.dtExistingReceipt.Columns["DOCUMENTNO"].SetOrdinal(1);
            this.dtExistingReceipt.Columns["DATETRX"].SetOrdinal(2);
            this.dtExistingReceipt.Columns["Customer"].SetOrdinal(3);
            this.dtExistingReceipt.Columns["ISBILLINGPARTNER"].SetOrdinal(4);
            this.dtExistingReceipt.Columns["Other Income"].SetOrdinal(5);
            this.dtExistingReceipt.Columns["TENDERTYPE"].SetOrdinal(6);
            this.dtExistingReceipt.Columns["CHECKNO"].SetOrdinal(7);
            this.dtExistingReceipt.Columns["PAYAMT"].SetOrdinal(8);

            this.dtgReceiptSummary.Columns["DOCUMENTNO"].HeaderText = "Document No";
            this.dtgReceiptSummary.Columns["DATETRX"].HeaderText = "Date";
            this.dtgReceiptSummary.Columns["TENDERTYPE"].HeaderText = "Paid By";
            this.dtgReceiptSummary.Columns["CHECKNO"].HeaderText = "Check/CPO No";
            this.dtgReceiptSummary.Columns["PAYAMT"].HeaderText = "Total Paid";
            this.dtgReceiptSummary.Columns["ISADVANCE"].HeaderText = "Is Advance";
            this.dtgReceiptSummary.Columns["ISBILLINGPARTNER"].HeaderText = "Is Paying";

            
            this.enableNavigationButton();
            
            this.cmbTenderType.SelectedIndex = 0;

            this.dtActiveOrganisations =
                this.getDataFromDb.getnodesInfo(null, "", "", 
                    generalResultInformation.Station, triaStateBool.yes, false, "AND");

            for (int rowCounter = 0; rowCounter <= this.dtActiveOrganisations.Rows.Count - 1; rowCounter++)
            {
                this.cmbOrganisation.Items.Add(
                    this.dtActiveOrganisations.Rows[rowCounter]["node"].ToString());
            }

            if (this.dtActiveOrganisations.Rows.Count > 0)
                this.cmbOrganisation.SelectedIndex = 0;

            this.newForm();
            
        }


        private void ddgCustomer_SelectedItemClicked(object sender, EventArgs e)
        {
            this.dtCustomerList = this.getDataFromDb.getCustomersInfo(null, "", "",
                generalResultInformation.Station, generalResultInformation.concernedNode,
                this.ddgCustomers.SelectedItem, triaStateBool.yes, false, "AND");

            this.dtCustomerList.Columns.Remove("email");
            this.dtCustomerList.Columns.Remove("country");
            this.dtCustomerList.Columns.Remove("city");
            this.dtCustomerList.Columns.Remove("sub_city");
            this.dtCustomerList.Columns.Remove("kebele");
            this.dtCustomerList.Columns.Remove("house_number");
            this.dtCustomerList.Columns.Remove("is_regular");
            this.dtCustomerList.Columns.Remove("insert_user_id");
            this.dtCustomerList.Columns.Remove("update_user_id");
            this.dtCustomerList.Columns.Remove("insert_date");
            this.dtCustomerList.Columns.Remove("update_date");
            this.dtCustomerList.Columns.Remove("is_active");
            this.dtCustomerList.Columns.Remove("station");
            this.dtCustomerList.Columns.Remove("node");
            this.dtCustomerList.Columns.Remove("customerID");
            this.dtCustomerList.Columns.Remove("customer_category");
            this.dtCustomerList.Columns.Remove("account_no");
            this.dtCustomerList.Columns.Remove("customer_group");
            this.dtCustomerList.Columns.Remove("customer_department");
            this.dtCustomerList.Columns.Remove("comment");

            this.ddgCustomers.DataSource = this.dtCustomerList;
            this.ddgCustomers.DataTablePrimaryKey =
                Convert.ToUInt16(this.dtCustomerList.Columns.IndexOf("id"));
            this.ddgCustomers.SelectedColomnIdex =
                this.dtCustomerList.Columns.IndexOf("customer_name");
        }

        private void ddgCustomer_selectedItemChanged(object sender, EventArgs e)
        {
            this.dtNewReceiptDetail.Rows.Clear();
            this.dtIdenticalCustomersList.Rows.Clear();
            this.ntbAmountPaid.Amount = "0";
            this.ddgInvoice.SelectedRow.Clear();
            this.ddgInvoice.SelectedItem = "";
            this.ddgInvoice.SelectedRowKey = null;
            this.ddgOtherIncome.SelectedItem = "";
            this.ddgOtherIncome.SelectedRowKey = null;
            this.ckIsExemption.Checked = false;
            this.ckIsOtherIncome.Checked = false;

            this.dcCurrePaymentDetailTotal = 0;
            this.dcCurrInvAllowedReceipt = 0;
            this.dcCurrInvAmt = 0;
            this.dcCurrInvPreviousTotalReceipt = 0;
            this.dcCurrInvReceivedAmt = 0;

            if (this.ddgCustomers.SelectedRow != null &&
                this.ddgCustomers.SelectedItem != "")
            {
                this.stBpartnerID = this.ddgCustomers.SelectedRowKey.ToString();
                string stBpartnerTin = this.ddgCustomers.SelectedRow.Rows[0]["tin_number"].ToString();

                DataTable dtSameBpartners =
                    this.getDataFromDb.getCustomersInfo(null, "", "",
                        generalResultInformation.Station, generalResultInformation.concernedNode,
                        "", stBpartnerTin != "" ? stBpartnerTin : "-1-1-1-1-1-1-1",
                        triaStateBool.yes, false, "AND");

                string bpIdentificationField = 
                    this.ckIsExemption.Checked ? "C_BPARTNER_ID" : "customer_id";

                if (this.getDataFromDb.checkIfTableContainesData(dtSameBpartners))
                {
                    DataRow drCustomerID = this.dtIdenticalCustomersList.NewRow();
                    drCustomerID["Field"] = "customer_id";
                    drCustomerID["Criterion"] = " = ";
                    drCustomerID["Value"] = this.stBpartnerID;
                    this.dtIdenticalCustomersList.Rows.Add(drCustomerID);

                    for (int rowCounter = 0; rowCounter <= dtSameBpartners.Rows.Count - 1 &&
                         dtSameBpartners.Rows.Count > 1; rowCounter++)
                    {
                        drCustomerID = this.dtIdenticalCustomersList.NewRow();
                        drCustomerID["Field"] = "customer_id";
                        drCustomerID["Criterion"] = " = ";
                        drCustomerID["Value"] = dtSameBpartners.Rows[rowCounter]["ID"].ToString();
                        this.dtIdenticalCustomersList.Rows.Add(drCustomerID);
                    }
                } 

                this.enableReceiptDetail(true && !this.ckIsDownPayment.Checked && !this.ckIsOtherIncome.Checked);

            }
            else
            {
                this.stBpartnerID = "";
                this.enableReceiptDetail(false);
            }


            this.txtUnAllocatedAmount.Text =
                (this.dcTotalReceipt - this.dcCurrePaymentDetailTotal).ToString("N02");
        }


        private void cmbTenderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbTenderType.SelectedItem.ToString() == "Cash")
                this.txtInstrumentNo.Visible = false;
            else
                this.txtInstrumentNo.Visible = true;
        }


        
        private void ddgInvoice_SelectedItemClicked(object sender, EventArgs e)
        {
            if (this.ckIsExemption.Checked)
                this.loadExemptionInfoToInvoiceDDg();
            else
                this.loadSalesInfoToInvoiceDDg();            
        }

        private void ddgInvoice_selectedItemChanged(object sender, EventArgs e)
        {
            
            this.dcCurrInvPreviousTotalReceipt = 0;
            this.dcCurrInvAllowedReceipt = 0;
            this.dcCurrInvReceivedAmt = 0;
            this.dcCurrInvAmt = 0;            
            

            if (this.ddgInvoice.SelectedRowKey == null ||
                this.ddgInvoice.SelectedRow == null)
            {
                this.ntbAmountPaid.Amount = "0";
                this.txtOverUnderAmt.Text = "0";
                this.txtAmountDue.Text = "0";
                this.ntbAmountPaid.Enabled = false;
                this.txtDescriptionDtl.Enabled = false;
                this.cmdAdd.Enabled = false;
                return;
            }

            if (this.cmdAdd.Text != "Modify" &&
                this.invoiceInCurrentDetail(this.ddgInvoice.SelectedRowKey.ToString()))
            {
                MessageBox.Show("Duplicate Invoice Not Allowed.",
                    "New Receipt", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                this.ntbAmountPaid.Amount = "0";
                this.txtOverUnderAmt.Text = "0";
                this.txtAmountDue.Text = "0";
                this.ntbAmountPaid.Enabled = false;
                this.txtDescriptionDtl.Enabled = false;
                this.cmdAdd.Enabled = false;
                return;
            }

            DataTable paymentDtlInfo =
                   this.getDataFromDb.getC_PAYMENTALLOCATEInfo(null, "", "", "",
                        this.ddgInvoice.SelectedRowKey.ToString(),
                        this.ckIsExemption.Checked ? triaStateBool.yes : triaStateBool.no,
                        generalResultInformation.Station, false, false, "AND");

            for (int rowCounter = 0; rowCounter <= paymentDtlInfo.Rows.Count - 1; rowCounter++)
            {
                this.dcCurrInvPreviousTotalReceipt = this.dcCurrInvPreviousTotalReceipt +
                    decimal.Parse(paymentDtlInfo.Rows[rowCounter]["AMOUNT"].ToString());
            }


            paymentDtlInfo =
                   this.getDataFromDb.getC_ALLOCATIONLINEInfo(null, "", "", "",
                        DateTime.Now, false, this.ddgInvoice.SelectedRowKey.ToString(),
                        "", "", this.ckIsExemption.Checked ? triaStateBool.yes : triaStateBool.no,
                        generalResultInformation.Station, false, false, "AND");

            for (int rowCounter = 0; rowCounter <= paymentDtlInfo.Rows.Count - 1; rowCounter++)
            {
                this.dcCurrInvPreviousTotalReceipt =
                    this.dcCurrInvPreviousTotalReceipt +
                    decimal.Parse(paymentDtlInfo.Rows[rowCounter]["AMOUNT"].ToString());
            }

            //this.dcCurrInvPreviousTotalReceipt =
            //    decimal.Parse(this.ddgInvoice.SelectedRow.Rows[0]["total_amount"].ToString()) -
            //    decimal.Parse(this.ddgInvoice.SelectedRow.Rows[0]["DUE"].ToString());

            if (this.ckIsExemption.Checked)
            {
                if (this.dcCurrInvPreviousTotalReceipt != 0)
                    this.dcCurrInvAllowedReceipt = 0;
                else
                {
                    DataTable exemptionInfo =
                        this.getDataFromDb.getC_EXEMPTIONInfo(null, "",
                                this.ddgInvoice.SelectedRowKey.ToString(), "", "",
                                DateTime.Now, false, exemptionType.ignor,
                                generalResultInformation.Station, false, false, "AND");
                    this.dcCurrInvAllowedReceipt = 0;
                    if (this.getDataFromDb.checkIfTableContainesData(exemptionInfo))
                    {
                        this.dcCurrInvAmt =
                            decimal.Parse(exemptionInfo.Rows[0]["EXEMPTEDAMT"].ToString());
                        this.dcCurrInvAllowedReceipt =
                            decimal.Parse(exemptionInfo.Rows[0]["EXEMPTEDAMT"].ToString());
                    }
                }
                this.dcCurrInvAllowedReceipt *= -1;
                this.ntbAmountPaid.Amount = this.dcCurrInvAllowedReceipt.ToString();
                this.dcCurrInvReceivedAmt = this.dcCurrInvAllowedReceipt;
            }
            else
            {
                DataTable salesInfo =
                    this.getDataFromDb.getSalesInfo(null, "", 
                        this.ddgInvoice.SelectedRowKey.ToString(), 
                        generalResultInformation.Station, "", "", "", 
                        triaStateBool.no, false, false, false, "AND");

                if (!this.getDataFromDb.checkIfTableContainesData(salesInfo))
                {
                    this.dcCurrInvAllowedReceipt = 0;
                }
                else
                {
                    this.dcCurrInvAmt =
                        decimal.Parse(salesInfo.Rows[0]["total_amount"].ToString());
                    this.dcCurrInvAllowedReceipt =
                        this.dcCurrInvAmt - this.dcCurrInvPreviousTotalReceipt -
                        decimal.Parse(salesInfo.Rows[0]["with_holding"].ToString()) ;
                }
                                
                this.ntbAmountPaid.Amount = "0";                
            }


            this.txtAmountDue.Text = this.dcCurrInvAllowedReceipt.ToString("N03");
            this.txtOverUnderAmt.Text =
                (this.dcCurrInvAllowedReceipt - this.dcCurrInvReceivedAmt).ToString("N03");

            this.ntbAmountPaid.Enabled = 
                this.ckIsExemption.Checked ? false : true;
            this.txtDescriptionDtl.Enabled = true;            
            this.cmdAdd.Enabled = true;
        }


        private void loadExemptionInfoToInvoiceDDg()
        {
            this.dtCustomerExemptionList =
                this.getDataFromDb.getC_EXEMPTIONInfo(this.ckIsBillingPartener.Checked ? null : this.dtIdenticalCustomersList, this.ckIsBillingPartener.Checked ? "" : "OR", "", 
                        this.ddgInvoice.SelectedItem,
                        this.dtIdenticalCustomersList.Rows.Count == 0 ? this.stBpartnerID : "", 
                        DateTime.Now, false, exemptionType.ignor, 
                        generalResultInformation.Station, true, false, "AND");

            this.dtCustomerExemptionList.Columns.Remove("AD_ORG_ID");
            this.dtCustomerExemptionList.Columns.Remove("CREATED");
            this.dtCustomerExemptionList.Columns.Remove("CREATEDBY");
            this.dtCustomerExemptionList.Columns.Remove("UPDATED");
            this.dtCustomerExemptionList.Columns.Remove("UPDATEDBY");
            this.dtCustomerExemptionList.Columns.Remove("ISACTIVE");
            this.dtCustomerExemptionList.Columns.Remove("DESCRIPTION");
            this.dtCustomerExemptionList.Columns.Remove("C_BPARTNER_ID");
            this.dtCustomerExemptionList.Columns.Remove("PROCESSED");
            this.dtCustomerExemptionList.Columns.Remove("STATION_ID");


            this.ddgInvoice.DataSource =
                this.dtCustomerExemptionList;

            this.ddgInvoice.DataTablePrimaryKey =
                Convert.ToUInt16(this.dtCustomerExemptionList.Columns.IndexOf("C_EXEMPTION_ID"));
            this.ddgInvoice.SelectedColomnIdex =
                this.dtCustomerExemptionList.Columns.IndexOf("DOCUMENTNO");
        }

        private void loadSalesInfoToInvoiceDDg()
        {
            this.dtCustomerSalesList =
                this.getDataFromDb.getV_INVOICEDUEAMOUNTInfo(this.ckIsBillingPartener.Checked ? null : this.dtIdenticalCustomersList, this.ckIsBillingPartener.Checked ? "" : "OR", "", generalResultInformation.Station,
                        this.ddgInvoice.SelectedItem, generalResultInformation.concernedNode,
                        this.ckIsBillingPartener.Checked ? "" : this.dtIdenticalCustomersList.Rows.Count == 0 ? this.stBpartnerID : "",
                        triaStateBool.Ignor, 0, triaStateBool.yes, "AND");

            this.dtCustomerSalesList.Columns.Remove("flag");
            this.dtCustomerSalesList.Columns.Remove("date");
            this.dtCustomerSalesList.Columns.Remove("time");
            this.dtCustomerSalesList.Columns.Remove("customer_id");
            this.dtCustomerSalesList.Columns.Remove("customer_name");
            this.dtCustomerSalesList.Columns.Remove("customer_tin");
            this.dtCustomerSalesList.Columns.Remove("discount");
            this.dtCustomerSalesList.Columns.Remove("discount_percent");
            this.dtCustomerSalesList.Columns.Remove("add_on");
            this.dtCustomerSalesList.Columns.Remove("add_on_percent");
            this.dtCustomerSalesList.Columns.Remove("disc_or_add");
            this.dtCustomerSalesList.Columns.Remove("comm_witholding");
            this.dtCustomerSalesList.Columns.Remove("payment_type_id");
            this.dtCustomerSalesList.Columns.Remove("amount_recieved");
            this.dtCustomerSalesList.Columns.Remove("void_count");
            this.dtCustomerSalesList.Columns.Remove("cashier_id");
            this.dtCustomerSalesList.Columns.Remove("cashier_name");
            this.dtCustomerSalesList.Columns.Remove("sales_rep_id");
            this.dtCustomerSalesList.Columns.Remove("bill_no");
            this.dtCustomerSalesList.Columns.Remove("table_no");
            this.dtCustomerSalesList.Columns.Remove("is_paid");
            this.dtCustomerSalesList.Columns.Remove("cheque_number");
            this.dtCustomerSalesList.Columns.Remove("cheque_date");
            this.dtCustomerSalesList.Columns.Remove("cash_ref_no");
            this.dtCustomerSalesList.Columns.Remove("credit_ref_no");
            this.dtCustomerSalesList.Columns.Remove("reference");
            this.dtCustomerSalesList.Columns.Remove("voucher_type");
            this.dtCustomerSalesList.Columns.Remove("ref_note");
            this.dtCustomerSalesList.Columns.Remove("cash_credit");
            this.dtCustomerSalesList.Columns.Remove("is_refunded");
            this.dtCustomerSalesList.Columns.Remove("transfer_id");
            this.dtCustomerSalesList.Columns.Remove("comment");
            this.dtCustomerSalesList.Columns.Remove("is_canceled");
            this.dtCustomerSalesList.Columns.Remove("station");
            this.dtCustomerSalesList.Columns.Remove("node");
            this.dtCustomerSalesList.Columns.Remove("sold_date");

            this.dtCustomerSalesList.Columns["ref_no"].SetOrdinal(0);
            this.dtCustomerSalesList.Columns["salesDateTime"].SetOrdinal(1);
            this.dtCustomerSalesList.Columns["fs_no"].SetOrdinal(2);
            this.dtCustomerSalesList.Columns["sub_total"].SetOrdinal(3);
            this.dtCustomerSalesList.Columns["total_tax"].SetOrdinal(4);
            this.dtCustomerSalesList.Columns["total_amount"].SetOrdinal(5);
            this.dtCustomerSalesList.Columns["with_holding"].SetOrdinal(6);
            this.dtCustomerSalesList.Columns["items_sold"].SetOrdinal(7);

            this.dtCustomerSalesList.Columns["salesDateTime"].ColumnName = "Date Sold";
            this.dtCustomerSalesList.Columns["sub_total"].ColumnName = "Sub Total";
            this.dtCustomerSalesList.Columns["total_tax"].ColumnName = "VAT";
            this.dtCustomerSalesList.Columns["total_amount"].ColumnName = "Grand Total";
            this.dtCustomerSalesList.Columns["with_holding"].ColumnName = "Withholding";
            this.dtCustomerSalesList.Columns["ref_no"].ColumnName = "Reference";
            this.dtCustomerSalesList.Columns["items_sold"].ColumnName = "Item Count";
            this.dtCustomerSalesList.Columns["fs_no"].ColumnName = "FS Number";


            this.ddgInvoice.DataSource =
                this.dtCustomerSalesList;

            this.ddgInvoice.DataTablePrimaryKey =
                Convert.ToUInt16(this.dtCustomerSalesList.Columns.IndexOf("id"));
            this.ddgInvoice.SelectedColomnIdex =
                this.dtCustomerSalesList.Columns.IndexOf("Reference");

        }



        private void cmdAdd_Click(object sender, EventArgs e)
        {

            if (this.dcCurrInvReceivedAmt == 0)
            {
                MessageBox.Show("Amount Invalid.",
                    "New Receipt", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                return;
            }

            if ( (this.dcCurrInvAllowedReceipt - this.dcCurrInvReceivedAmt).CompareTo(generalResultInformation.overAmtLimit) == -1)
            {
                if (
                   MessageBox.Show("Amount Exceeds Maximum Payment amount allowable." +
                       "\n Enter pass key to proceed.", "New Collection",
                       MessageBoxButtons.OKCancel, MessageBoxIcon.Information,
                       MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    generalResultInformation.CustomerName = this.ddgCustomers.SelectedItem;
                    generalResultInformation.InvoiceNumber = this.ddgInvoice.SelectedItem;
                    frmValidateSecurityKey allowAmount = new frmValidateSecurityKey();
                    allowAmount.TopMost = true;
                    allowAmount.ShowDialog();

                    if (!generalResultInformation.securityPassKeyCorrect)
                    {
                        MessageBox.Show("Amount Exceeds Maximum Payment amount allowable.",
                        "New Receipt", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Amount Exceeds Maximum Payment amount allowable.",
                        "New Receipt", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                    return;
                }
            }
            else if ((this.dcCurrInvAllowedReceipt - this.dcCurrInvReceivedAmt).CompareTo(new decimal(-0.5)) == -1)
            {
                if (MessageBox.Show("Amount Exceeds Maximum amount allowable. Do you want to proceed.",
                    "New Receipt", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information) == DialogResult.No)
                    return;
            }

            if (this.cmdAdd.Text == "Modify")
            {
                this.dcCurrePaymentDetailTotal -=
                    decimal.Parse(this.dtNewReceiptDetail.Rows[this.intCurrReceiptDtlSelectedRowIndex]["AMOUNT"].ToString());
                
                this.dtNewReceiptDetail.Rows[this.intCurrReceiptDtlSelectedRowIndex]["ISEXEMPTION"] =
                    this.ckIsExemption.Checked ? "Y" : "N";
                
                this.dtNewReceiptDetail.Rows[this.intCurrReceiptDtlSelectedRowIndex]["C_INVOICE_ID"] =
                    int.Parse(this.ddgInvoice.SelectedRowKey.ToString());
                this.dtNewReceiptDetail.Rows[this.intCurrReceiptDtlSelectedRowIndex]["AMOUNT"] =
                    this.dcCurrInvReceivedAmt.ToString("N02");
                this.dtNewReceiptDetail.Rows[this.intCurrReceiptDtlSelectedRowIndex]["INVOICEAMT"] =
                    this.dcCurrInvAllowedReceipt.ToString("N02");

                this.dtNewReceiptDetail.Rows[this.intCurrReceiptDtlSelectedRowIndex]["Document No"] =
                    this.ddgInvoice.SelectedItem;

                this.dtNewReceiptDetail.Rows[this.intCurrReceiptDtlSelectedRowIndex]["OVERUNDERAMT"] =
                    decimal.Parse(this.txtOverUnderAmt.Text).ToString("N02");

                this.dtNewReceiptDetail.Rows[this.intCurrReceiptDtlSelectedRowIndex]["DESCRIPTION"] =
                    this.txtDescriptionDtl.Text;

                this.dtNewReceiptDetail.Rows[this.intCurrReceiptDtlSelectedRowIndex]["remove"] = "remove";

                if (this.ddgInvoice.SelectedRow != null &&
                    this.ddgInvoice.SelectedRow.Rows.Count > 0)
                {
                    if (this.ckIsExemption.Checked)
                        this.dtNewReceiptDetail.Rows[this.intCurrReceiptDtlSelectedRowIndex]["Date Sold"] =
                            this.ddgInvoice.SelectedRow.Rows[0]["DATEINVOICED"];
                    else
                        this.dtNewReceiptDetail.Rows[this.intCurrReceiptDtlSelectedRowIndex]["Date Sold"] =
                            this.ddgInvoice.SelectedRow.Rows[0]["Date Sold"];

                    if (this.ckIsExemption.Checked)
                        this.dtNewReceiptDetail.Rows[this.intCurrReceiptDtlSelectedRowIndex]["Invoiced"] =
                            this.ddgInvoice.SelectedRow.Rows[0]["EXEMPTEDAMT"];
                    else
                        this.dtNewReceiptDetail.Rows[this.intCurrReceiptDtlSelectedRowIndex]["Invoiced"] =
                            this.ddgInvoice.SelectedRow.Rows[0]["Grand Total"];
                }
                else
                {

                    DataTable trxInfo = new DataTable();

                    if (this.ckIsExemption.Checked)
                    {
                        trxInfo =
                            this.getDataFromDb.getC_EXEMPTIONInfo(null, "", this.ddgInvoice.SelectedRowKey.ToString(),
                                "", "", DateTime.Now, false, exemptionType.ignor, generalResultInformation.Station, false,
                                false, "AND");

                        this.dtNewReceiptDetail.Rows[this.intCurrReceiptDtlSelectedRowIndex]["Invoiced"] =
                            trxInfo.Rows[0]["EXEMPTEDAMT"];

                        this.dtNewReceiptDetail.Rows[this.intCurrReceiptDtlSelectedRowIndex]["Date Sold"] =
                            trxInfo.Rows[0]["DATEINVOICED"];
                    }
                    else
                    {
                        trxInfo =
                            this.getDataFromDb.getSalesInfo(null, "", this.ddgInvoice.SelectedRowKey.ToString(),
                                generalResultInformation.Station, "", "", "", triaStateBool.Ignor, false,
                                false, false, "AND");

                        this.dtNewReceiptDetail.Rows[this.intCurrReceiptDtlSelectedRowIndex]["Invoiced"] =
                            trxInfo.Rows[0]["total_amount"];

                        this.dtNewReceiptDetail.Rows[this.intCurrReceiptDtlSelectedRowIndex]["Date Sold"] =
                            trxInfo.Rows[0]["sold_date"];
                    }
                }
                
            }
            else
            {
                DataRow drNewReceiptDetail = this.dtNewReceiptDetail.NewRow();
                
                drNewReceiptDetail["remove"] = "remove";

                drNewReceiptDetail["Sn"] =
                    this.dtNewReceiptDetail.Rows.Count + 1;

                drNewReceiptDetail["Document No"] =
                    this.ddgInvoice.SelectedItem;

                if (this.ckIsExemption.Checked)
                    drNewReceiptDetail["Date Sold"] =
                        this.ddgInvoice.SelectedRow.Rows[0]["DATEINVOICED"];
                else
                    drNewReceiptDetail["Date Sold"] =
                        this.ddgInvoice.SelectedRow.Rows[0]["Date Sold"];

                if(this.ckIsExemption.Checked)
                    drNewReceiptDetail["Invoiced"] =
                        this.ddgInvoice.SelectedRow.Rows[0]["EXEMPTEDAMT"];
                else
                    drNewReceiptDetail["Invoiced"] =
                        this.ddgInvoice.SelectedRow.Rows[0]["Grand Total"];

                drNewReceiptDetail["ISEXEMPTION"] =
                    this.ckIsExemption.Checked ? "Y" : "N";

                drNewReceiptDetail["C_INVOICE_ID"] =
                    int.Parse(this.ddgInvoice.SelectedRowKey.ToString());
                drNewReceiptDetail["AMOUNT"] =
                    this.dcCurrInvReceivedAmt.ToString("N02");
                drNewReceiptDetail["OVERUNDERAMT"] =
                    decimal.Parse(this.txtOverUnderAmt.Text).ToString("N02");
                drNewReceiptDetail["INVOICEAMT"] =
                    this.dcCurrInvAllowedReceipt.ToString("N02");
                drNewReceiptDetail["DESCRIPTION"] =
                    this.txtDescriptionDtl.Text;

                this.dtNewReceiptDetail.Rows.Add(drNewReceiptDetail);                
            }

            this.dcCurrePaymentDetailTotal += this.dcCurrInvReceivedAmt;
            this.txtUnAllocatedAmount.Text =
                (this.dcTotalReceipt - this.dcCurrePaymentDetailTotal).ToString("N02");

            this.ckIsExemption.Checked = false;

            this.ddgInvoice.SelectedItem = "";
            this.ddgInvoice.SelectedRow.Clear();
            this.ddgInvoice.SelectedRowKey = null;

            this.ddgInvoice_selectedItemChanged(sender, e);

            this.txtDescriptionDtl.Text = "";

            this.cmdAdd.Text = "ADD";
            
        }


        private void dtgReceiptSummary_CellClick(object sender, EventArgs e)
        {
            if (this.dtgReceiptSummary.SelectedRows.Count < 1)
            {
                return;
            }

            this.intCurrReceiptSelectedRowIndex =
                this.dtgReceiptSummary.SelectedRows[0].Index;
            this.enableNavigationButton();

            this.tlsConfirm.Enabled = false;

            this.fillDetailReceiptTable(this.dtExistingReceipt.Rows[this.intCurrReceiptSelectedRowIndex]["C_PAYMENT_ID"].ToString());

            this.cmbOrganisation.Visible = false;
            this.txtOrganisation.Visible = true;

            this.ckIsBillingPartener.Enabled = false;

            this.ckIsDownPayment.Enabled = false;

            this.dtpDate.Enabled = false;
            this.txtDocumentNo.Enabled = false;
            this.txtDescriptionMain.Enabled = false;
            this.ddgCustomers.Enabled = false;
            this.ddgOtherIncome.Enabled = false;
            this.ntbTotalPayedAmount.Enabled = false;
            this.cmbTenderType.Enabled = false;
            this.txtInstrumentNo.Enabled = false;

            this.ckIsOtherIncome.Enabled = false;
                       

            this.enableReceiptDetail(false);

            this.stPaymentID =
                this.dtExistingReceipt.Rows[this.intCurrReceiptSelectedRowIndex]["C_PAYMENT_ID"].ToString();

            this.stBpartnerID =
                this.dtExistingReceipt.Rows[this.intCurrReceiptSelectedRowIndex]["C_BPARTNER_ID"].ToString();

            this.stOtherIncomeID =
                this.dtExistingReceipt.Rows[this.intCurrReceiptSelectedRowIndex]["C_CHARGE_ID"].ToString();
            
            this.txtOrganisation.Text =
                this.dtExistingReceipt.Rows[this.intCurrReceiptSelectedRowIndex]["Organisation"].ToString();

            this.dtpDate.Value =
                DateTime.Parse(this.dtExistingReceipt.Rows[this.intCurrReceiptSelectedRowIndex]["DATETRX"].ToString());

            this.txtDocumentNo.Text =
                this.dtExistingReceipt.Rows[this.intCurrReceiptSelectedRowIndex]["DOCUMENTNO"].ToString();

            this.ddgCustomers.SelectedRowKey =
                this.dtExistingReceipt.Rows[this.intCurrReceiptSelectedRowIndex]["C_BPARTNER_ID"].ToString();
            this.ddgCustomers.SelectedItem =
                this.dtExistingReceipt.Rows[this.intCurrReceiptSelectedRowIndex]["Customer"].ToString();


            this.ddgOtherIncome.SelectedRowKey =
                this.dtExistingReceipt.Rows[this.intCurrReceiptSelectedRowIndex]["C_CHARGE_ID"].ToString();
            this.ddgOtherIncome.SelectedItem =
                this.dtExistingReceipt.Rows[this.intCurrReceiptSelectedRowIndex]["Other Income"].ToString();

            if (this.ddgOtherIncome.SelectedRowKey.ToString() != "")
            {
                this.ckIsOtherIncome.Checked = true;
            }

            this.ntbTotalPayedAmount.Amount =
                this.dtExistingReceipt.Rows[this.intCurrReceiptSelectedRowIndex]["PAYAMT"].ToString();

            this.txtDescriptionMain.Text =
                this.dtExistingReceipt.Rows[this.intCurrReceiptSelectedRowIndex]["DESCRIPTION"].ToString();

            this.cmbTenderType.SelectedItem =
                this.dtExistingReceipt.Rows[this.intCurrReceiptSelectedRowIndex]["TENDERTYPE"].ToString();

            this.txtInstrumentNo.Text =
                this.dtExistingReceipt.Rows[this.intCurrReceiptSelectedRowIndex]["CHECKNO"].ToString();

            this.ckIsBillingPartener.Checked =
                this.dtExistingReceipt.Rows[this.intCurrReceiptSelectedRowIndex]["ISBILLINGPARTNER"].ToString() == "Y" ? true : false;

            this.ckIsDownPayment.Checked =
                this.dtExistingReceipt.Rows[this.intCurrReceiptSelectedRowIndex]["ISADVANCE"].ToString() == "Y" ? true : false;


            decimal unAllocatedAmount = 0;

            if (this.ddgOtherIncome.SelectedRowKey.ToString() == "")
            {
                for (int rowCounter = 0; rowCounter <= this.dtNewReceiptDetail.Rows.Count - 1; rowCounter++)
                {
                    unAllocatedAmount = unAllocatedAmount +
                        decimal.Parse(this.dtNewReceiptDetail.Rows[rowCounter]["AMOUNT"].ToString());
                }


                DataTable paymentDtlInfo =
                       this.getDataFromDb.getC_ALLOCATIONLINEInfo(null, "", "", "",
                            DateTime.Now, false, "", "", this.stPaymentID,
                            this.ckIsExemption.Checked ? triaStateBool.yes : triaStateBool.no,
                            generalResultInformation.Station, false, false, "AND");

                for (int rowCounter = 0; rowCounter <= paymentDtlInfo.Rows.Count - 1; rowCounter++)
                {
                    unAllocatedAmount = unAllocatedAmount +
                        decimal.Parse(paymentDtlInfo.Rows[rowCounter]["AMOUNT"].ToString());
                }

                unAllocatedAmount = decimal.Parse(this.ntbTotalPayedAmount.Amount)
                    - unAllocatedAmount;
            }

            this.txtUnAllocatedAmount.Text = unAllocatedAmount.ToString("N02");

            if (unAllocatedAmount > 0)
            {
                this.cmdAllocate.Enabled = true;
                this.cmdAllocate.Visible = true;
            }
            else
            {
                this.cmdAllocate.Enabled = false;
                this.cmdAllocate.Visible = false;
            }
            
        }
        
        private void dtgReceiptSummary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dtgReceiptSummary_CellClick(sender, new EventArgs());
        }

        private void dtgReceiptSummary_SelectionChanged(object sender, EventArgs e)
        {
            this.dtgReceiptSummary_CellClick(sender, e);
        }

        private void dtgReceiptSummary_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string colName = dtgReceiptSummary.Columns[e.ColumnIndex].Name;
            DataView dtView = this.dtExistingReceipt.DefaultView;

            if (dtgReceiptSummary.SortOrder == SortOrder.Ascending)
            {
                dtView.Sort = colName + " ASC";
            }
            else
            {
                dtView.Sort = colName + " DESC";
            }

            this.dtExistingReceipt = dtView.ToTable();

            this.dtgReceiptSummary_SelectionChanged(sender, new EventArgs());
        }


        private void dtgReceiptDtl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgReceiptDtl.SelectedRows.Count < 1 ||
                this.dtgReceiptDtl.Enabled == false)
            {
                return;
            }
            if (this.dtgReceiptDtl.Columns["remove"].Visible == false)
                return;

            this.intCurrReceiptDtlSelectedRowIndex =
                this.dtgReceiptDtl.SelectedRows[0].Index;

            if (this.dtgReceiptDtl.CurrentCell != null)
            {
                if (this.dtgReceiptDtl.CurrentCell.OwningColumn.Index == 0 &&
                    this.dtgReceiptDtl.CurrentCell.OwningColumn.Name == "remove" &&
                    this.dtgReceiptDtl.CurrentCell.Value.ToString() == "remove" &&
                    this.dtgReceiptDtl.CurrentCell.OwningColumn.HeaderText == "")
                {
                    decimal removedReceiptAmount =
                        decimal.Parse(this.dtNewReceiptDetail.Rows[intCurrReceiptDtlSelectedRowIndex]["AMOUNT"].ToString());

                    //this.dtgInvoiceAmount.Rows[intCurrExemptionDtlSelectedRowIndex].
                    //        Cells["ISEXEMPTION"].Value.ToString() == "Y" ?
                    //        this.dcCurrePaymentDetailTotal += removedExemptionAmount :
                    this.dcCurrePaymentDetailTotal -= removedReceiptAmount;

                    this.txtUnAllocatedAmount.Text =
                        (this.dcTotalReceipt - this.dcCurrePaymentDetailTotal).ToString("N02");

                    this.dtNewReceiptDetail.Rows.RemoveAt(intCurrReceiptDtlSelectedRowIndex);

                    this.ddgInvoice.SelectedRowKey = null;
                    this.ddgInvoice.SelectedItem = "";
                    this.ddgInvoice.SelectedRow.Clear();
                    this.ddgInvoice_selectedItemChanged(sender, e);
                    this.cmdAdd.Text = "ADD";
                    this.intCurrReceiptDtlSelectedRowIndex = -1;
                }
                else
                {
                    this.ckIsExemption.Checked =
                        this.dtgReceiptDtl.Rows[intCurrReceiptDtlSelectedRowIndex].
                            Cells["ISEXEMPTION"].Value.ToString() == "Y" ? true : false;


                    this.cmdAdd.Text = "Modify";

                    this.ddgInvoice.SelectedRowKey =
                        this.dtgReceiptDtl.Rows[intCurrReceiptDtlSelectedRowIndex].
                            Cells["C_INVOICE_ID"].Value.ToString();
                    this.ddgInvoice.SelectedItem =
                        this.dtgReceiptDtl.Rows[intCurrReceiptDtlSelectedRowIndex].
                            Cells["Document No"].Value.ToString();
                                        
                    
                    this.ddgInvoice_selectedItemChanged(sender, e);

                    this.dcCurrInvReceivedAmt =
                        decimal.Parse(this.dtgReceiptDtl.Rows[intCurrReceiptDtlSelectedRowIndex].
                            Cells["AMOUNT"].Value.ToString());

                    this.ntbAmountPaid.Amount =
                        this.dcCurrInvReceivedAmt.ToString();

                    this.txtAmountDue.Text =
                        this.dtgReceiptDtl.Rows[intCurrReceiptDtlSelectedRowIndex].
                            Cells["INVOICEAMT"].Value.ToString();

                    this.txtDescriptionDtl.Text =
                        this.dtgReceiptDtl.Rows[intCurrReceiptDtlSelectedRowIndex].
                            Cells["DESCRIPTION"].Value.ToString();

                    this.txtOverUnderAmt.Text =
                        (this.dcCurrInvAllowedReceipt - this.dcCurrInvReceivedAmt).ToString("N03");

                    this.cmdAdd.Enabled = true;
                }
            }
        }



        private void ckIsExemption_CheckedChanged(object sender, EventArgs e)
        {
            this.ntbAmountPaid.Enabled = !this.ckIsExemption.Checked;
            this.ntbAmountPaid.AllowNegative = 
                this.ckIsExemption.Checked ? true : false;

            this.dcCurrInvAllowedReceipt = 0;
            this.dcCurrInvReceivedAmt = 0;
            this.dcCurrInvAmt = 0;

            this.ddgInvoice.SelectedRowKey = null;
            this.ddgInvoice.SelectedRow.Clear();
            this.ddgInvoice.SelectedItem = "";

            this.ntbAmountPaid.Amount = "0";
            this.txtOverUnderAmt.Text = "0";
            this.txtAmountDue.Text = "0";
            this.ntbAmountPaid.Enabled = false;
            this.txtDescriptionDtl.Enabled = false;
            this.cmdAdd.Enabled = false;

            string bpIdentificationField =
                    this.ckIsExemption.Checked ? "C_BPARTNER_ID" : "customer_id";
            for (int rowCounter = 0; rowCounter <= this.dtIdenticalCustomersList.Rows.Count - 1; rowCounter++)
            {
                this.dtIdenticalCustomersList.Rows[rowCounter]["Field"] = bpIdentificationField;
            }
            return;           
        }

        
        private void ntbAmountPaid_Leave(object sender, EventArgs e)
        {
            this.dcCurrInvReceivedAmt = 
                decimal.Parse(this.ntbAmountPaid.Amount);
            if (this.ckIsExemption.Checked)
                this.dcCurrInvReceivedAmt *= -1;

            if (!this.ckIsOtherIncome.Checked)
            {
                this.txtOverUnderAmt.Text =
                    (this.dcCurrInvAllowedReceipt - this.dcCurrInvReceivedAmt).ToString("N02");
            }
        }

        private void ntbTotalPayedAmount_Leave(object sender, EventArgs e)
        {
            this.dcTotalReceipt = 
                decimal.Parse(this.ntbTotalPayedAmount.Amount);

            if (!this.ckIsOtherIncome.Checked)
            {
                this.txtUnAllocatedAmount.Text =
                    (this.dcTotalReceipt - this.dcCurrePaymentDetailTotal).ToString("N02");
            }
            
        }


        private void ckIsDownPayment_CheckedChanged(object sender, EventArgs e)
        {
            this.dtNewReceiptDetail.Rows.Clear();

            this.dcCurrePaymentDetailTotal = 0;
            if (!this.ckIsOtherIncome.Checked)
            {
                this.txtUnAllocatedAmount.Text =
                    (this.dcTotalReceipt - this.dcCurrePaymentDetailTotal).ToString("N02");
            }


            bool enableDisableDetail = false;

            if (this.ddgCustomers.SelectedRow != null &&
                this.ddgCustomers.SelectedItem != "")
            {
                enableDisableDetail = true;
            }
            else
            {
                enableDisableDetail = false;
            }

            this.enableReceiptDetail(!this.ckIsDownPayment.Checked && enableDisableDetail);
            
        }

        private void cmdAllocate_Click(object sender, EventArgs e)
        {
            if (decimal.Parse(this.txtUnAllocatedAmount.Text) != 0)
            {
                frmAllocatePayment frmAllocatePymnt = new frmAllocatePayment();

                frmAllocatePymnt.pdcUnallocatedAmt = decimal.Parse(this.txtUnAllocatedAmount.Text);
                frmAllocatePymnt.pstPayment_ID = this.stPaymentID;
                frmAllocatePymnt.pstBpartner_ID = this.stBpartnerID;
                frmAllocatePymnt.pstOrganisation_ID =
                    this.dtExistingReceipt.Rows[this.intCurrReceiptSelectedRowIndex]["AD_ORG_ID"].ToString();

                frmAllocatePymnt.ShowDialog();
            }
            else
            {
                frmPaymentAllocation frmPymnAllocation = new frmPaymentAllocation();
                frmPymnAllocation.pstPayment_ID = this.stPaymentID;
                frmPymnAllocation.ShowDialog();
            }
        }

        private void txtDocumentNo_Leave(object sender, EventArgs e)
        {
            Match match = Regex.Match(this.txtDocumentNo.Text, @"^\d{3,}$");

            if (match.Success)
            {
                if (!(match.Value.Equals(this.txtDocumentNo.Text)))
                {
                    MessageBox.Show("Document Number Should be in the following Exact patter. {######}\n" +
                        "Please check and and correct the Document number entered",
                        "Manual Sales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtDocumentNo.Text = "";
                    return;
                }
            }
            else
            {
                MessageBox.Show("Document Number Should be in the following Exact patter. {######}\n" +
                        "Please check and and correct the Document number entered",
                        "Manual Sales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtDocumentNo.Text = "";
                return;
            }         
        }

        private void txtInstrumentNo_Leave(object sender, EventArgs e)
        {
            this.txtInstrumentNo.Text =
                Regex.Replace(
                    Regex.Replace(this.txtInstrumentNo.Text.ToUpper().Trim(), @"\s+", " "),
                    @"\s+", "-");

            this.txtInstrumentNo.Text =
                Regex.Replace(this.txtInstrumentNo.Text.ToUpper(), @"[^0-9a-zA-Z\-]+", "");

            DataTable depositInfo = 
                this.getDataFromDb.getC_PAYMENTInfo(null, "", "",
                    "", "", DateTime.Now, false, 
                    this.cmbTenderType.SelectedItem.ToString().GettenderType(), 
                    this.txtInstrumentNo.Text, 
                    generalResultInformation.Station, false, false, "AND");

            if (this.getDataFromDb.checkIfTableContainesData(depositInfo))
            {
                MessageBox.Show("Cheque Number  -- " +
                                depositInfo.Rows[0]["CHECKNO"].ToString() +
                                " -- is already in use." +
                                " \n Please use different Document number",
                        "Deposit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtInstrumentNo.Text = "";
                return;
            }
        }

        private void ckIsOtherIncome_CheckedChanged(object sender, EventArgs e)
        {

            this.ddgOtherIncome.Enabled = this.ckIsOtherIncome.Checked && this.stBpartnerID != "";            
            this.ckIsDownPayment.Enabled = !this.ckIsOtherIncome.Checked;

            if (this.ckIsOtherIncome.Checked)
            {
                this.dtNewReceiptDetail.Rows.Clear();
                this.ntbAmountPaid.Amount = "0";
                this.ddgInvoice.SelectedRow.Clear();
                this.ddgInvoice.SelectedItem = "";
                this.ddgInvoice.SelectedRowKey = null;
                this.ckIsExemption.Checked = false;
                this.enableReceiptDetail(false);
                this.ckIsDownPayment.Checked = false;
                
                this.dcCurrePaymentDetailTotal = 0;
                this.dcCurrInvAllowedReceipt = 0;
                this.dcCurrInvAmt = 0;
                this.dcCurrInvPreviousTotalReceipt = 0;
                this.dcCurrInvReceivedAmt = 0;

                this.txtUnAllocatedAmount.Text = (0).ToString("N02");
            }
            else
            {
                this.enableReceiptDetail(this.stBpartnerID != "" && !this.ckIsDownPayment.Checked && !this.ckIsOtherIncome.Checked);
                this.ddgOtherIncome.SelectedItem = "";
                this.ddgOtherIncome.SelectedRowKey = null;

                this.txtUnAllocatedAmount.Text =
                    (this.dcTotalReceipt - this.dcCurrePaymentDetailTotal).ToString("N02");
            }
        }

        private void ddgOtherIncome_SelectedItemClicked(object sender, EventArgs e)
        {
            this.dtOtherIncomeList =
                this.getDataFromDb.getC_CHARGEInfo(null, "", "", 
                                this.ddgOtherIncome.SelectedItem, 
                                generalResultInformation.centralStation, true, false, "AND");

            this.dtOtherIncomeList.Columns.Remove("AD_CLIENT_ID");
            this.dtOtherIncomeList.Columns.Remove("AD_ORG_ID");
            this.dtOtherIncomeList.Columns.Remove("ISACTIVE");
            this.dtOtherIncomeList.Columns.Remove("CREATED");
            this.dtOtherIncomeList.Columns.Remove("CREATEDBY");
            this.dtOtherIncomeList.Columns.Remove("UPDATED");
            this.dtOtherIncomeList.Columns.Remove("UPDATEDBY");
            this.dtOtherIncomeList.Columns.Remove("DESCRIPTION");
            this.dtOtherIncomeList.Columns.Remove("CHARGEAMT");
            this.dtOtherIncomeList.Columns.Remove("ISSAMETAX");
            this.dtOtherIncomeList.Columns.Remove("ISSAMECURRENCY");
            this.dtOtherIncomeList.Columns.Remove("C_TAXCATEGORY_ID");
            this.dtOtherIncomeList.Columns.Remove("ISTAXINCLUDED");
            this.dtOtherIncomeList.Columns.Remove("C_BPARTNER_ID");
            this.dtOtherIncomeList.Columns.Remove("ISCOST");
            this.dtOtherIncomeList.Columns.Remove("C_TAX_ID");
            this.dtOtherIncomeList.Columns.Remove("STATION_ID");

            this.ddgOtherIncome.DataSource = this.dtOtherIncomeList;
            this.ddgOtherIncome.DataTablePrimaryKey =
                Convert.ToUInt16(this.dtOtherIncomeList.Columns.IndexOf("C_CHARGE_ID"));
            this.ddgOtherIncome.SelectedColomnIdex =
                this.dtOtherIncomeList.Columns.IndexOf("NAME");
        }
        
        private void ddgOtherIncome_selectedItemChanged(object sender, EventArgs e)
        {
            this.stOtherIncomeID = this.ddgOtherIncome.SelectedRowKey.ToString();
        }


    }
}
