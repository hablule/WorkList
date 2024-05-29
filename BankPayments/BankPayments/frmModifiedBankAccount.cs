using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using dbConnection;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace BankPayments
{
    public partial class frmModifiedBankAccount : Form
    {
        public frmModifiedBankAccount()
        {
            InitializeComponent();
        }

        
        public changeType change = changeType.none;

        public string stPaymentID = "";
        public string stDocumentNumber = "";
                
        public string stPayeeID = "";
        public string stPayeeName = "";
        
        public decimal dcAmount = 0;
        
        public string stBankAccountID = "";
        public string stBankAccountNumber = "";
        
        public string stCheckNumber = "";

        public string stDescription = "";

        Color clMissingFieldColor = Color.Red;

        DataTable dtAllBankAccounts = new DataTable();
        DataTable dtexistingPaymentRecord = new DataTable();


        dataBuilder getDataFromDb = new dataBuilder();


        private bool isCheckNumberCorrectFormat()
        {
            Match match = Regex.Match(this.txtCheckNo.Text, @"^[A-Z]{0,3}\s{0,1}\d+$");
            if (match.Success)
            {
                if (!(match.Value.Equals(this.txtCheckNo.Text)))
                {                    
                    return false;
                }
            }
            else
            {                
                return false;
            }
            return true;
        }

        private bool isCheckNumberUsed()
        {
            DataTable lastBankCheck = this.getDataFromDb.getC_BANKCHECKInfo(null, "", "",
                            "", "", this.txtCheckNo.Text, "", DateTime.Now, false, triStateBool.Ignor,
                            triStateBool.Ignor, false, false, false, "AND");

            if (this.getDataFromDb.checkIfTableContainesData(lastBankCheck))
            {
                if (MessageBox.Show("Check Number  -- " +
                                lastBankCheck.Rows[0]["CHECKNO"].ToString() +
                                " -- is already in use on Payment number " +
                                lastBankCheck.Rows[0]["DOCUMENTNO"].ToString() +
                                " dated " +
                                DateTime.Parse(lastBankCheck.Rows[0]["DATETRX"].ToString()).ToString("dd-MMM-yyyy") +
                                "\n Do you like to proceed anyways",
                        "Bank Payments", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return true;
                }                
            }

            return false;
        }


        private void frmModifiedBankAccount_Load(object sender, EventArgs e)
        {   
            if (this.stPaymentID == "")
                this.Close();

            this.dtexistingPaymentRecord =
                this.getDataFromDb.getC_BANKCHECKInfo(null, "", this.stPaymentID, "", "", 
                        "", "", DateTime.Now, false, triStateBool.no, triStateBool.Ignor,
                        false, false, "AND");

            if (!this.getDataFromDb.checkIfTableContainesData(this.dtexistingPaymentRecord))
                this.Close();

            if (this.change == changeType.none)
                this.Close();

            switch (this.change)
            {
                case changeType.Payee:
                    this.ddgPayee.Enabled = true;
                    this.cmdNew.Enabled = true;
                    this.ckIsCustomer.Enabled = true;
                    this.ddgInvoice.Enabled = true;
                    break;
                case changeType.Amount:
                    this.ntbAmount.Enabled = true;
                    break;
                case changeType.Bank:
                    this.ddgBankAccount.Enabled = true;
                    break;
                case changeType.Check:
                    this.txtCheckNo.Enabled = true;
                    break;
                case changeType.Description:
                    this.txtDescription.Enabled = true;
                    break;
                default:
                    return;
            }

            this.txtDocumentNo.Text =
                this.stDocumentNumber;

            this.ddgPayee.SelectedRowKey =
                this.stPayeeID;
            this.ddgPayee.SelectedItem =
                this.stPayeeName;

            this.ntbAmount.Amount =
                this.dcAmount.ToString();
            
            this.ddgBankAccount.SelectedRowKey =
                this.stBankAccountID;
            this.ddgBankAccount.SelectedItem =
                this.stBankAccountNumber;

            this.txtCheckNo.Text = this.stCheckNumber;

            this.txtDescription.Text = this.stDescription;


            this.dtAllBankAccounts =
                this.getDataFromDb.getC_BANKACCOUNTInfo(null, "", "", "",
                            "", "", "", true, false, "AND");

            this.dtAllBankAccounts.Columns.Add("Bank");

            for (int rowCounter = this.dtAllBankAccounts.Rows.Count - 1; rowCounter >= 0; rowCounter--)
            {
                DataTable dtBankInfo =
                    this.getDataFromDb.getC_BANKInfo(null, "", "",
                        this.dtAllBankAccounts.Rows[rowCounter]["C_BANK_ID"].ToString(), "",
                        true, false, "AND");

                if (!this.getDataFromDb.checkIfTableContainesData(dtBankInfo))
                {
                    this.dtAllBankAccounts.Rows.RemoveAt(rowCounter);
                    continue;
                }
                this.dtAllBankAccounts.Rows[rowCounter]["Bank"] =
                    dtBankInfo.Rows[0]["NAME"].ToString();
            }

            this.dtAllBankAccounts.Columns.Remove("AD_CLIENT_ID");
            this.dtAllBankAccounts.Columns.Remove("AD_ORG_ID");
            this.dtAllBankAccounts.Columns.Remove("ISACTIVE");
            this.dtAllBankAccounts.Columns.Remove("CREATED");
            this.dtAllBankAccounts.Columns.Remove("CREATEDBY");
            this.dtAllBankAccounts.Columns.Remove("UPDATED");
            this.dtAllBankAccounts.Columns.Remove("UPDATEDBY");
            this.dtAllBankAccounts.Columns.Remove("C_BANK_ID");
            this.dtAllBankAccounts.Columns.Remove("C_CURRENCY_ID");
            this.dtAllBankAccounts.Columns.Remove("BANKACCOUNTTYPE");
            this.dtAllBankAccounts.Columns.Remove("CURRENTBALANCE");
            this.dtAllBankAccounts.Columns.Remove("CREDITLIMIT");
            this.dtAllBankAccounts.Columns.Remove("ISDEFAULT");
            this.dtAllBankAccounts.Columns.Remove("IBAN");
            this.dtAllBankAccounts.Columns.Remove("DESCRIPTION");
            this.dtAllBankAccounts.Columns.Remove("BBAN");


        }


        private void ddgPayee_SelectedItemClicked(object sender, EventArgs e)
        {
            DataTable dtBpartnerList =
                this.getDataFromDb.getC_BPARTNERInfo(null, "", "", "",
                this.ddgPayee.SelectedItem, triStateBool.Ignor,
                this.ckIsCustomer.CheckState == CheckState.Checked ?
                    triStateBool.yes :
                this.ckIsCustomer.CheckState == CheckState.Unchecked ?
                        triStateBool.no :
                      triStateBool.Ignor,
                triStateBool.Ignor, triStateBool.Ignor,
                        true, false, "AND");

            dtBpartnerList.Columns.Remove("AD_CLIENT_ID");
            dtBpartnerList.Columns.Remove("AD_ORG_ID");
            dtBpartnerList.Columns.Remove("ISACTIVE");
            dtBpartnerList.Columns.Remove("CREATED");
            dtBpartnerList.Columns.Remove("CREATEDBY");
            dtBpartnerList.Columns.Remove("UPDATED");
            dtBpartnerList.Columns.Remove("UPDATEDBY");
            dtBpartnerList.Columns.Remove("DESCRIPTION");
            dtBpartnerList.Columns.Remove("VALUE");
            dtBpartnerList.Columns.Remove("Name2");
            dtBpartnerList.Columns.Remove("ISSUMMARY");
            dtBpartnerList.Columns.Remove("C_BP_GROUP_ID");
            dtBpartnerList.Columns.Remove("ISONETIME");
            dtBpartnerList.Columns.Remove("ISPROSPECT");
            //dtBpartnerList.Columns.Remove("ISVENDOR");
            //dtBpartnerList.Columns.Remove("ISCUSTOMER");
            //dtBpartnerList.Columns.Remove("ISEMPLOYEE");
            dtBpartnerList.Columns.Remove("ISSALESREP");
            dtBpartnerList.Columns.Remove("REFERENCENO");
            dtBpartnerList.Columns.Remove("DUNS");
            dtBpartnerList.Columns.Remove("URL");
            dtBpartnerList.Columns.Remove("AD_LANGUAGE");
            dtBpartnerList.Columns.Remove("TAXID");
            dtBpartnerList.Columns.Remove("ISTAXEXEMPT");
            dtBpartnerList.Columns.Remove("C_INVOICESCHEDULE_ID");
            dtBpartnerList.Columns.Remove("RATING");
            dtBpartnerList.Columns.Remove("SALESVOLUME");
            dtBpartnerList.Columns.Remove("NUMBEREMPLOYEES");
            dtBpartnerList.Columns.Remove("NAICS");
            dtBpartnerList.Columns.Remove("FIRSTSALE");
            dtBpartnerList.Columns.Remove("ACQUSITIONCOST");
            dtBpartnerList.Columns.Remove("POTENTIALLIFETIMEVALUE");
            dtBpartnerList.Columns.Remove("ACTUALLIFETIMEVALUE");
            dtBpartnerList.Columns.Remove("SHAREOFCUSTOMER");
            dtBpartnerList.Columns.Remove("PAYMENTRULE");
            dtBpartnerList.Columns.Remove("SO_CREDITLIMIT");
            dtBpartnerList.Columns.Remove("SO_CREDITUSED");
            dtBpartnerList.Columns.Remove("C_PAYMENTTERM_ID");
            dtBpartnerList.Columns.Remove("M_PRICELIST_ID");
            dtBpartnerList.Columns.Remove("M_DISCOUNTSCHEMA_ID");
            dtBpartnerList.Columns.Remove("C_DUNNING_ID");
            dtBpartnerList.Columns.Remove("ISDISCOUNTPRINTED");
            dtBpartnerList.Columns.Remove("SO_DESCRIPTION");
            dtBpartnerList.Columns.Remove("POREFERENCE");
            dtBpartnerList.Columns.Remove("PAYMENTRULEPO");
            dtBpartnerList.Columns.Remove("PO_PRICELIST_ID");
            dtBpartnerList.Columns.Remove("PO_DISCOUNTSCHEMA_ID");
            dtBpartnerList.Columns.Remove("PO_PAYMENTTERM_ID");
            dtBpartnerList.Columns.Remove("DOCUMENTCOPIES");
            dtBpartnerList.Columns.Remove("C_GREETING_ID");
            dtBpartnerList.Columns.Remove("INVOICERULE");
            dtBpartnerList.Columns.Remove("DELIVERYRULE");
            dtBpartnerList.Columns.Remove("FREIGHTCOSTRULE");
            dtBpartnerList.Columns.Remove("DELIVERYVIARULE");
            dtBpartnerList.Columns.Remove("SALESREP_ID");
            dtBpartnerList.Columns.Remove("SENDEMAIL");
            dtBpartnerList.Columns.Remove("BPARTNER_PARENT_ID");
            dtBpartnerList.Columns.Remove("INVOICE_PRINTFORMAT_ID");
            dtBpartnerList.Columns.Remove("SOCREDITSTATUS");
            dtBpartnerList.Columns.Remove("SHELFLIFEMINPCT");
            dtBpartnerList.Columns.Remove("AD_ORGBP_ID");
            dtBpartnerList.Columns.Remove("FLATDISCOUNT");
            dtBpartnerList.Columns.Remove("TOTALOPENBALANCE");
            dtBpartnerList.Columns.Remove("C_CASHBOOK_ID");

            this.ddgPayee.DataSource = dtBpartnerList;
            this.ddgPayee.DataTablePrimaryKey =
                    Convert.ToUInt16(this.ddgPayee.DataSource.Columns.IndexOf("C_BPARTNER_ID"));
            this.ddgPayee.SelectedColomnIdex =
                this.ddgPayee.DataSource.Columns.IndexOf("NAME");

        }

        //private void ddgPayee_selectedItemChanged(object sender, EventArgs e)
        //{
        //    if (this.ddgPayee.SelectedRow != null &&
        //        this.ddgPayee.SelectedItem != null &&
        //        this.ddgPayee.SelectedRow.Rows.Count > 0)
        //        this.stCurrentPayeeId = this.ddgPayee.SelectedRowKey.ToString();
        //    else
        //        this.stCurrentPayeeId = "";
        //}

        private void cmdNew_Click(object sender, EventArgs e)
        {
            this.ddgPayee.SelectedRowKey = null;
            this.ddgPayee.SelectedRow.Rows.Clear();
            this.ddgPayee.SelectedItem = "";

            //this.ddgPayee_selectedItemChanged(sender, e);

            generalResultInformation.newBpartnerID = "";
            generalResultInformation.newBpartnerName = "";

            frmNewBpartner frmNewPartner = new frmNewBpartner();
            frmNewPartner.ShowDialog();

            if (generalResultInformation.newBpartnerID != "")
            {
                this.ddgPayee.SelectedRowKey = generalResultInformation.newBpartnerID;
                this.ddgPayee.SelectedItem = generalResultInformation.newBpartnerName;

                //this.stCurrentPayeeId = generalResultInformation.newBpartnerID;
            }

        }
        

        private void ckIsCustomer_CheckedChanged(object sender, EventArgs e)
        {
            this.ddgInvoice.Visible =
                this.ckIsCustomer.CheckState == CheckState.Checked ? true : false;
            this.lblInvoice.Visible =
                this.ckIsCustomer.CheckState == CheckState.Checked ? true : false;
        }

        private void ckIsCustomer_CheckStateChanged(object sender, EventArgs e)
        {
            this.ddgInvoice.Visible =
                this.ckIsCustomer.CheckState == CheckState.Checked ? true : false;
            this.lblInvoice.Visible =
                this.ckIsCustomer.CheckState == CheckState.Checked ? true : false;
        }


        private void ddgInvoice_SelectedItemClicked(object sender, EventArgs e)
        {
            this.ddgPayee.SelectedRowKey = null;
            this.ddgPayee.SelectedRow.Rows.Clear();
            this.ddgPayee.SelectedItem = "";

            this.ddgInvoice.DataSource =
                this.getDataFromDb.getC_ORDERInfo(null, "", "", "", "", "", "", "", "",
                        this.ddgInvoice.SelectedItem, triStateBool.yes, triStateBool.Ignor,
                        false, false, "AND");

            this.ddgInvoice.DataTablePrimaryKey =
                Convert.ToUInt16(this.ddgInvoice.DataSource.Columns.IndexOf("C_ORDER_ID"));

            this.ddgInvoice.SelectedColomnIdex =
                this.ddgInvoice.DataSource.Columns.IndexOf("DOCUMENTNO");

            this.ddgInvoice.HiddenColoumns =
                new int[] 
                {
                    this.ddgInvoice.DataSource.Columns.IndexOf("AD_CLIENT_ID"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("AD_ORG_ID"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("ISACTIVE"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("CREATED"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("CREATEDBY"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("UPDATED"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("UPDATEDBY"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("ISSOTRX"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("DOCSTATUS"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("DOCACTION"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("PROCESSING"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("PROCESSED"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("C_DOCTYPE_ID"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("C_DOCTYPETARGET_ID"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("DESCRIPTION"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("ISAPPROVED"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("ISCREDITAPPROVED"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("ISDELIVERED"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("ISINVOICED"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("ISPRINTED"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("ISTRANSFERRED"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("ISSELECTED"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("SALESREP_ID"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("DATEORDERED"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("DATEPROMISED"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("DATEPRINTED"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("DATEACCT"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("C_BPARTNER_ID"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("C_BPARTNER_LOCATION_ID"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("POREFERENCE"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("ISDISCOUNTPRINTED"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("C_CURRENCY_ID"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("PAYMENTRULE"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("C_PAYMENTTERM_ID"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("INVOICERULE"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("DELIVERYRULE"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("FREIGHTCOSTRULE"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("FREIGHTAMT"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("DELIVERYVIARULE"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("M_SHIPPER_ID"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("C_CHARGE_ID"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("CHARGEAMT"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("PRIORITYRULE"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("TOTALLINES"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("GRANDTOTAL"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("M_WAREHOUSE_ID"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("M_PRICELIST_ID"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("ISTAXINCLUDED"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("C_CAMPAIGN_ID"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("C_PROJECT_ID"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("C_ACTIVITY_ID"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("POSTED"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("C_PAYMENT_ID"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("C_CASHLINE_ID"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("SENDEMAIL"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("AD_USER_ID"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("COPYFROM"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("ISSELFSERVICE"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("AD_ORGTRX_ID"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("USER1_ID"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("USER2_ID"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("C_CONVERSIONTYPE_ID"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("BILL_BPARTNER_ID"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("BILL_LOCATION_ID"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("BILL_USER_ID"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("PAY_BPARTNER_ID"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("PAY_LOCATION_ID"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("REF_ORDER_ID"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("ISDROPSHIP"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("VOLUME"),
                    this.ddgInvoice.DataSource.Columns.IndexOf("WEIGHT")
                };
        }

        private void ddgInvoice_selectedItemChanged(object sender, EventArgs e)
        {
            if (this.ddgInvoice.SelectedRow.Rows.Count > 0 ||
                this.ddgInvoice.SelectedRowKey != null)
            {
                DataTable dtCustoemrInfo =
                    this.getDataFromDb.getC_BPARTNERInfo(null, "", "",
                        this.ddgInvoice.SelectedRow.Rows[0]["C_BPARTNER_ID"].ToString(),
                        "", triStateBool.Ignor, triStateBool.yes, triStateBool.Ignor,
                        triStateBool.Ignor, true, false, "AND");

                this.ddgPayee.SelectedRowKey =
                    this.ddgInvoice.SelectedRow.Rows[0]["C_BPARTNER_ID"].ToString();
                this.ddgPayee.SelectedItem =
                    dtCustoemrInfo.Rows[0]["NAME"].ToString();

                //this.stCurrentPayeeId =
                //    this.ddgInvoice.SelectedRow.Rows[0]["C_BPARTNER_ID"].ToString();
            }
            else
            {
                this.ddgPayee.SelectedRowKey = null;
                this.ddgPayee.SelectedRow.Rows.Clear();
                this.ddgPayee.SelectedItem = "";
            }
        }




        private void ddgBankAccount_SelectedItemClicked(object sender, EventArgs e)
        {
            this.ddgBankAccount.DataSource = this.dtAllBankAccounts.Copy();
            this.ddgBankAccount.DataTablePrimaryKey =
                    Convert.ToUInt16(this.ddgBankAccount.DataSource.Columns.IndexOf("C_BANKACCOUNT_ID"));
            this.ddgBankAccount.SelectedColomnIdex =
                this.ddgBankAccount.DataSource.Columns.IndexOf("ACCOUNTNO");
        }

        private void ddgBankAccount_selectedItemChanged(object sender, EventArgs e)
        {
            if (this.ddgBankAccount.SelectedRow != null &&
                this.ddgBankAccount.SelectedItem != "")
                this.stBankAccountID =
                    this.ddgBankAccount.SelectedRowKey.ToString();
            else
                this.stBankAccountID = "";
        }


        private void cmdChange_Click(object sender, EventArgs e)
        {
            if (this.change == changeType.Payee)
            {
                if (this.ddgPayee.SelectedRowKey == null)
                {
                    this.lblPayee.ForeColor = this.clMissingFieldColor;
                    MessageBox.Show("Payee Name Cannot be empty.\n" +
                              "Please select Payee to proceed.",
                              "Bank Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.dtexistingPaymentRecord.Rows[0]["C_BPARTNER_ID"] =
                    this.ddgPayee.SelectedRowKey.ToString();
            }

            if (this.change == changeType.Amount)
            {
                if (this.ntbAmount.Amount == "0" || this.ntbAmount.Amount == "")
                {
                    this.lblAmount.ForeColor = this.clMissingFieldColor;
                    MessageBox.Show("Amount Cannot be zero.\n" +
                              "Please enter Amount to proceed.",
                              "Bank Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.dtexistingPaymentRecord.Rows[0]["PAYAMT"] =
                    decimal.Parse(this.ntbAmount.Amount);
            }

            if (this.change == changeType.Check)
            {
                Match match =
                    Regex.Match(this.txtCheckNo.Text, @"^\s*$");
                if (match.Success)
                {
                    MessageBox.Show("Check Number Cannot be empty.\n" +
                              "Please enter check number to proceed.",
                              "Bank Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!this.isCheckNumberCorrectFormat())
                {
                    if (MessageBox.Show("Check Number Should be in the following Exact patter. {[XXX ##########}\n" +
                             "Do you like to proceed anyways",
                             "Bank Payments", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        return;
                    }
                }

                if (this.isCheckNumberUsed())
                {
                    return;
                }

                this.dtexistingPaymentRecord.Rows[0]["CHECKNO"] =
                    this.txtCheckNo.Text;
            }

            if (this.change == changeType.Bank)
            {
                if (this.ddgBankAccount.SelectedRowKey == null)
                {
                    MessageBox.Show("Bank Account Cannot be empty.\n" +
                              "Please select Bank Account to proceed.",
                              "Bank Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.dtexistingPaymentRecord.Rows[0]["C_BANKACCOUNT_ID"] =
                    this.ddgBankAccount.SelectedRowKey.ToString();
            }

            if (this.change == changeType.Description)
            {
                Match match =
                        Regex.Match(this.txtDescription.Text, @"^\s*$");
                if (match.Success)
                {
                    MessageBox.Show("Payment Reason Cannot be empty.\n" +
                              "Please enter Payment Reason to proceed.",
                              "Bank Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.dtexistingPaymentRecord.Rows[0]["DESCRIPTION"] =
                    this.txtDescription.Text;
            }
            
            this.getDataFromDb.changeDataBaseTableData
                            (this.dtexistingPaymentRecord, "C_BANKCHECK", "UPDATE");

            this.Close();
        }

    }
}
