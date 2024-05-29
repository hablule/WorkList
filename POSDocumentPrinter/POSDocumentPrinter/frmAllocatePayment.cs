using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POSDocumentPrinter
{
    public partial class frmAllocatePayment : Form
    {
        public frmAllocatePayment()
        {
            InitializeComponent();
        }


        public string pstPayment_ID = "";
        public string pstBpartner_ID = "";
        public string pstOrganisation_ID = "";

        public string pstCustomerName = "";

        public bool pckIsBillingPartner = false;
        
        public decimal pdcUnallocatedAmt = 0;

        // int
        int intCurrReceiptDtlSelectedRowIndex = -1;
        

        // Decimals
        decimal dcCurrInvAllowedReceipt = 0;
        decimal dcCurrInvAmt = 0;
        decimal dcCurrInvReceivedAmt = 0;
        decimal dcCurrePaymentDetailTotal = 0;
        decimal dcCurrInvPreviousTotalReceipt = 0;
        decimal dcTotalReceipt = 0;

        DataTable dtNewReceiptDetail = new DataTable();
        
        DataTable dtCustomerSalesList = new DataTable();
        DataTable dtCustomerExemptionList = new DataTable();


        // Others
        Color normalFieldColor = Color.Black;
        Color missingFieldColor = Color.Red;
        Color ChangedFieldColor = Color.Blue;

        DataGridViewCellStyle cancelButtonStyle = new DataGridViewCellStyle();

        dataBuilder getDataFromDb = new dataBuilder();


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
            this.dtNewReceiptDetail.Columns.Add("C_BPARTNER_ID");
            

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
            this.dtgReceiptDtl.Columns["C_BPARTNER_ID"].Visible = false;
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

        private void enableReceiptDetail(bool enabled)
        {
            this.ckIsExemption.Enabled = enabled;
            //this.dtgReceiptDtl.Enabled = enabled;
            this.ddgInvoice.Enabled = enabled;
            this.ntbAmountPaid.Enabled = enabled;
            this.txtDescriptionDtl.Enabled = enabled;
            this.cmdAdd.Enabled = enabled;
        }


        private void loadExemptionInfoToInvoiceDDg()
        {
            this.dtCustomerExemptionList =
                this.getDataFromDb.getC_EXEMPTIONInfo(null, "", "",
                        this.ddgInvoice.SelectedItem, this.pstBpartner_ID,
                        DateTime.Now, false, exemptionType.ignor,
                        generalResultInformation.Station, true, false, "AND");

            this.dtCustomerExemptionList.Columns.Remove("AD_ORG_ID");
            this.dtCustomerExemptionList.Columns.Remove("CREATED");
            this.dtCustomerExemptionList.Columns.Remove("CREATEDBY");
            this.dtCustomerExemptionList.Columns.Remove("UPDATED");
            this.dtCustomerExemptionList.Columns.Remove("UPDATEDBY");
            this.dtCustomerExemptionList.Columns.Remove("ISACTIVE");
            this.dtCustomerExemptionList.Columns.Remove("DESCRIPTION");            
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
                this.getDataFromDb.getV_INVOICEDUEAMOUNTInfo(null, "", "", generalResultInformation.Station,
                        this.ddgInvoice.SelectedItem, generalResultInformation.concernedNode,
                        this.pckIsBillingPartner ? "" : this.pstBpartner_ID,
                        triaStateBool.Ignor, 0, triaStateBool.yes, "AND");
                           
            this.dtCustomerSalesList.Columns.Remove("flag");
            this.dtCustomerSalesList.Columns.Remove("date");
            this.dtCustomerSalesList.Columns.Remove("time");            
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


        private bool isFormComplete()
        {
            bool formIsComplete = true;

            if (this.dtgReceiptDtl.Rows.Count <= 0)
            {
                this.dtgReceiptDtl.BackgroundColor = this.missingFieldColor;
                formIsComplete = false;
            }
            else
                this.dtgReceiptDtl.BackgroundColor = SystemColors.Control;

            if (decimal.Parse(this.txtUnAllocatedAmount.Text).CompareTo(generalResultInformation.shortAmtLimit * -1) == -1)
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
                    generalResultInformation.CustomerName = this.pstCustomerName;
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


            return formIsComplete;
        }



        private void frmAllocatePayment_Load(object sender, EventArgs e)
        {
            this.txtUnAllocatedAmount.Text = this.pdcUnallocatedAmt.ToString("N02");
            this.dcTotalReceipt = this.pdcUnallocatedAmt;

            this.cancelButtonStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.cancelButtonStyle.BackColor = Color.FromKnownColor(KnownColor.ControlDark);
            this.cancelButtonStyle.ForeColor = Color.FromKnownColor(KnownColor.Desktop);
            this.cancelButtonStyle.SelectionForeColor = Color.FromKnownColor(KnownColor.DarkBlue);
            this.cancelButtonStyle.WrapMode = DataGridViewTriState.False;
            this.cancelButtonStyle.Font =
                new System.Drawing.Font("Microsoft Sans Serif", 8.25F,
                    System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.createDetailReceiptTable();

            //this.enableReceiptDetail(false);



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
                        decimal.Parse(salesInfo.Rows[0]["with_holding"].ToString());
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

        private void cmdAdd_Click(object sender, EventArgs e)
        {

            if (this.dcCurrInvReceivedAmt == 0)
            {
                MessageBox.Show("Amount Invalid.",
                    "New Receipt", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                return;
            }

            if ((this.dcCurrInvAllowedReceipt - this.dcCurrInvReceivedAmt).CompareTo(generalResultInformation.overAmtLimit) == -1)
            {
                if (
                   MessageBox.Show("Amount Exceeds Maximum Payment amount allowable." +
                       "\n Enter pass key to proceed.", "New Collection",
                       MessageBoxButtons.OKCancel, MessageBoxIcon.Information,
                       MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    generalResultInformation.CustomerName = this.pstCustomerName;
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

                    if (this.ckIsExemption.Checked)
                        this.dtNewReceiptDetail.Rows[this.intCurrReceiptDtlSelectedRowIndex]["C_BPARTNER_ID"] =
                            this.ddgInvoice.SelectedRow.Rows[0]["C_BPARTNER_ID"];
                    else
                        this.dtNewReceiptDetail.Rows[this.intCurrReceiptDtlSelectedRowIndex]["C_BPARTNER_ID"] =
                            this.ddgInvoice.SelectedRow.Rows[0]["customer_id"];                    
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

                        this.dtNewReceiptDetail.Rows[this.intCurrReceiptDtlSelectedRowIndex]["C_BPARTNER_ID"] =
                            trxInfo.Rows[0]["C_BPARTNER_ID"];
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

                        this.dtNewReceiptDetail.Rows[this.intCurrReceiptDtlSelectedRowIndex]["C_BPARTNER_ID"] =
                            trxInfo.Rows[0]["customer_id"];
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

                if (this.ckIsExemption.Checked)
                    drNewReceiptDetail["Invoiced"] =
                        this.ddgInvoice.SelectedRow.Rows[0]["EXEMPTEDAMT"];
                else
                    drNewReceiptDetail["Invoiced"] =
                        this.ddgInvoice.SelectedRow.Rows[0]["Grand Total"];

                drNewReceiptDetail["ISEXEMPTION"] =
                    this.ckIsExemption.Checked ? "Y" : "N";

                drNewReceiptDetail["C_INVOICE_ID"] =
                    int.Parse(this.ddgInvoice.SelectedRowKey.ToString());

                if (this.ckIsExemption.Checked)
                    drNewReceiptDetail["C_BPARTNER_ID"] =
                        this.ddgInvoice.SelectedRow.Rows[0]["C_BPARTNER_ID"];
                else
                    drNewReceiptDetail["C_BPARTNER_ID"] =
                        this.ddgInvoice.SelectedRow.Rows[0]["customer_id"];
                
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


        private void ntbAmountPaid_Leave(object sender, EventArgs e)
        {
            this.dcCurrInvReceivedAmt =
                decimal.Parse(this.ntbAmountPaid.Amount);
            if (this.ckIsExemption.Checked)
                this.dcCurrInvReceivedAmt *= -1;

            this.txtOverUnderAmt.Text =
                (this.dcCurrInvAllowedReceipt - this.dcCurrInvReceivedAmt).ToString("N02");
        }

        private void cmdConfirm_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            if (!this.isFormComplete())
            {
                this.Enabled = true;                
                MessageBox.Show("Please Insert the missing fields before you proceed.",
                    "Save record", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                return;
            }


            DataTable newAllocationHeader =
                this.getDataFromDb.getC_ALLOCATIONHDRInfo(null, "", "", "",  
                    DateTime.Now, false, "", true, "AND");

            DataRow drNewAllocationHeader = newAllocationHeader.NewRow();

            drNewAllocationHeader["AD_ORG_ID"] = this.pstOrganisation_ID;

            drNewAllocationHeader["DOCUMENTNO"] =
                this.getDataFromDb.getNextSequenceId("ALLOCATION_HDR", "", generalResultInformation.Station, "", true);
            
            drNewAllocationHeader["DATETRX"] = DateTime.Now.ToString("yyyy-MM-dd");
            drNewAllocationHeader["DATEACCT"] = DateTime.Now.ToString("yyyy-MM-dd");
            drNewAllocationHeader["STATION_ID"] = generalResultInformation.Station;

            newAllocationHeader.Rows.Add(drNewAllocationHeader);

            string[] recordId =
                this.getDataFromDb.changeDataBaseTableData(newAllocationHeader, "C_ALLOCATIONHDR", "INSERT", true);

            // If There Is A DB error Return)
            if (dbCommitFailure.dbCommitError)
            {
                this.sbStatusLabel.Text = "Record IS NOT Saved";
                this.Enabled = true;
                return;
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

            this.dtNewReceiptDetail.Columns["C_PAYMENTALLOCATE_ID"].ColumnName = "C_ALLOCATIONLINE_ID";
            this.dtNewReceiptDetail.Columns["C_PAYMENT_ID"].ColumnName = "C_ALLOCATIONHDR_ID";
                        
            this.dtNewReceiptDetail.Columns.Add("C_PAYMENT_ID");            

            for (int currentDetailRecord = 0;
                 currentDetailRecord <= this.dtNewReceiptDetail.Rows.Count - 1;
                 currentDetailRecord++)
            {
                this.dtNewReceiptDetail.Rows[currentDetailRecord]["C_ALLOCATIONHDR_ID"] =
                    newRecordId[1];

                this.dtNewReceiptDetail.Rows[currentDetailRecord]["C_PAYMENT_ID"] =
                    this.pstPayment_ID;
                this.dtNewReceiptDetail.Rows[currentDetailRecord]["C_BPARTNER_ID"] =
                    this.dtNewReceiptDetail.Rows[currentDetailRecord]["C_BPARTNER_ID"].ToString();

                this.dtNewReceiptDetail.Rows[currentDetailRecord]["AD_ORG_ID"] =
                    this.pstOrganisation_ID;
                this.dtNewReceiptDetail.Rows[currentDetailRecord]["STATION_ID"] =
                    generalResultInformation.Station;
            }

            this.getDataFromDb.changeDataBaseTableData(this.dtNewReceiptDetail.Copy(), "C_ALLOCATIONLINE", "INSERT", true);

            MessageBox.Show("New Record Saved Successfully.",
                    "Save record", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to leave" +
                    " before saving your change.","Save", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                this.Close();
        }

        private void cmdShowAllocation_Click(object sender, EventArgs e)
        {
            frmPaymentAllocation frmPymnAllocation = new frmPaymentAllocation();

            frmPymnAllocation.pstPayment_ID = this.pstPayment_ID;
            
            frmPymnAllocation.ShowDialog();
        }



    }
}
