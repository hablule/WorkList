using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dbConnection;

namespace BankPayments
{
    public partial class frmSearchPayment : Form
    {
        public frmSearchPayment()
        {
            InitializeComponent();
        }

        dataBuilder getDataFromDb = new dataBuilder();

        DataTable searchQuery = new DataTable();
        DataTable dtAllBankAccounts = new DataTable();
        
        string logicalConnector = "AND";


        private void enableDisableValueInsertionBox(string Logic, Control valueInsertionBox)
        {
            if (Logic == "IGNOR")
                valueInsertionBox.Enabled = false;
            else
                valueInsertionBox.Enabled = true;
        }

        private void addMoreCriteria(string field, string criterion, string valueFrom, string valueTo)
        {
            if (field == "" || criterion == "" || valueFrom == "")
                return;
            if (criterion == "In between of")
            {
                this.addMoreCriteria(field, "Greater or equals to", valueFrom, "");
                this.addMoreCriteria(field, "Lesser or equal to", valueTo, "");
            }
            else
            {
                DataRow criteriaValue = this.searchQuery.NewRow();

                criteriaValue["Field"] = field;
                criteriaValue["Criterion"] = this.generateEquivalentSymbol(criterion);
                if (criteriaValue["Criterion"].ToString() == "like")
                    criteriaValue["Value"] = "%" + valueFrom.ToUpper() + "%";
                else
                    criteriaValue["Value"] = valueFrom;
                this.searchQuery.Rows.Add(criteriaValue);
            }

        }

        private void establishSearchCriterion()
        {
            this.searchQuery.Clear();

            if (this.cmbDocumentNumberLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("DOCUMENTNO", this.cmbDocumentNumberLogic.SelectedItem.ToString(),
                    this.txtDocumentNumber.Text, "");
            }

            if (this.cmbDateLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("DATETRX", this.cmbDateLogic.SelectedItem.ToString(),
                    this.dtpDateFrom.Value.ToString("dd-MMM-yyyy"),
                    this.dtpDateTo.Value.ToString("dd-MMM-yyyy"));
            }

            if (this.cmbPayeeLogic.SelectedItem.ToString() != "IGNOR" &&
                this.ddgPayee.SelectedRowKey != null)
            {
                this.addMoreCriteria("C_BPARTNER_ID", this.cmbPayeeLogic.SelectedItem.ToString(),
                    this.ddgPayee.SelectedRowKey.ToString(), "");
            }

            if (this.cmbAmountPaidLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("PAYAMT", this.cmbAmountPaidLogic.SelectedItem.ToString(),
                    this.ntbAmountPaidFrom.Amount, this.ntbAmountPaidTo.Amount);
            }

            if (this.cmbBankAcctLogic.SelectedItem.ToString() != "IGNOR" &&
                this.ddgBankAcct.SelectedRowKey != null)
            {
                this.addMoreCriteria("C_BANKACCOUNT_ID", this.cmbBankAcctLogic.SelectedItem.ToString(),
                    this.ddgBankAcct.SelectedRowKey.ToString(), "");
            }

            if (this.cmbCheckNumberLogic.SelectedItem.ToString() != "IGNOR")
            {
                this.addMoreCriteria("CHECKNO", this.cmbCheckNumberLogic.SelectedItem.ToString(),
                    this.txtCheckNumber.Text, "");
            }

            if (this.ckAllocated.CheckState != CheckState.Indeterminate)
            {
                if (this.ckAllocated.CheckState == CheckState.Checked)
                    this.addMoreCriteria("ISALLOCATED", "Equals to", "Y", "");
                else if (this.ckAllocated.CheckState == CheckState.Unchecked)
                    this.addMoreCriteria("ISALLOCATED", "Not equals to", "N", "");
            }

            if (this.ckIssued.CheckState != CheckState.Indeterminate)
            {
                if (this.ckIssued.CheckState == CheckState.Checked)
                    this.addMoreCriteria("ISISSUED", "Equals to", "Y", "");
                else if (this.ckIssued.CheckState == CheckState.Unchecked)
                    this.addMoreCriteria("ISISSUED", "Not equals to", "N", "");
            }

        }

        private string generateEquivalentSymbol(string symbolInText)
        {
            if (symbolInText == "Equals to")
                return "=";
            if (symbolInText == "Not equals to")
                return "!=";
            if (symbolInText == "Similar to")
                return "like";
            if (symbolInText == "Not similar to")
                return "not like";
            if (symbolInText == "Greater than")
                return ">";
            if (symbolInText == "Greater or equals to")
                return ">=";
            if (symbolInText == "Less than")
                return "<";
            if (symbolInText == "Lesser or equal to")
                return "<=";
            return "";
        }


        private void frmSearchPayment_Load(object sender, EventArgs e)
        {

            this.cmbDocumentNumberLogic.SelectedItem = "IGNOR";
            this.cmbDateLogic.SelectedItem = "IGNOR";
            this.cmbPayeeLogic.SelectedItem = "IGNOR";
            this.cmbAmountPaidLogic.SelectedItem = "IGNOR";
            this.cmbBankAcctLogic.SelectedItem = "IGNOR";
            this.cmbCheckNumberLogic.SelectedItem = "IGNOR";


            this.searchQuery.Columns.Add("Field");
            this.searchQuery.Columns.Add("Criterion");
            this.searchQuery.Columns.Add("Value");

            generalResultInformation.searchResult.Clear();
            generalResultInformation.searchCritrion.Clear();



            this.dtAllBankAccounts =
                this.getDataFromDb.getC_BANKACCOUNTInfo(null, "", "", "", "", "", "", true, false, "AND");

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


        private void cmbDocumentNumberLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbDocumentNumberLogic.SelectedItem.ToString(),
                this.txtDocumentNumber);
        }

        private void cmbDateLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbDateLogic.SelectedItem.ToString(),
                this.dtpDateFrom);

            if (this.cmbDateLogic.SelectedItem.ToString() == "In between of")
                this.dtpDateTo.Visible = true;
            else
                this.dtpDateTo.Visible = false;
        }

        private void cmbPayeeLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbPayeeLogic.SelectedItem.ToString(),
                this.ddgPayee);
        }

        private void cmbAmountPaidLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbAmountPaidLogic.SelectedItem.ToString(),
                this.ntbAmountPaidFrom);

            if (this.cmbAmountPaidLogic.SelectedItem.ToString() == "In between of")
                this.ntbAmountPaidTo.Visible = true;
            else
                this.ntbAmountPaidTo.Visible = false;
        }

        private void cmbBankAcctLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbBankAcctLogic.SelectedItem.ToString(),
                this.ddgBankAcct);
        }

        private void cmbCheckNumberLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableDisableValueInsertionBox(this.cmbCheckNumberLogic.SelectedItem.ToString(),
                this.txtCheckNumber);
        }
        

        private void ddgPayee_SelectedItemClicked(object sender, EventArgs e)
        {
            DataTable dtBpartnerList =
                this.getDataFromDb.getC_BPARTNERInfo(null, "", "", "",
                        this.ddgPayee.SelectedItem, triStateBool.Ignor,
                        triStateBool.Ignor, triStateBool.Ignor, triStateBool.Ignor,
                        true, false, "AND");

            dtBpartnerList.Columns.Remove("AD_CLIENT_ID");
            dtBpartnerList.Columns.Remove("AD_ORG_ID");
            dtBpartnerList.Columns.Remove("ISACTIVE");
            dtBpartnerList.Columns.Remove("CREATED");
            dtBpartnerList.Columns.Remove("CREATEDBY");
            dtBpartnerList.Columns.Remove("UPDATED");
            dtBpartnerList.Columns.Remove("UPDATEDBY");
            dtBpartnerList.Columns.Remove("DESCRIPTION");
            dtBpartnerList.Columns.Remove("ISSUMMARY");
            dtBpartnerList.Columns.Remove("C_BP_GROUP_ID");
            dtBpartnerList.Columns.Remove("ISONETIME");
            dtBpartnerList.Columns.Remove("ISPROSPECT");
            dtBpartnerList.Columns.Remove("ISVENDOR");
            dtBpartnerList.Columns.Remove("ISCUSTOMER");
            dtBpartnerList.Columns.Remove("ISEMPLOYEE");
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

        private void ddgBankAccount_SelectedItemClicked(object sender, EventArgs e)
        {
            this.ddgBankAcct.DataSource = this.dtAllBankAccounts.Copy();
            this.ddgBankAcct.DataTablePrimaryKey =
                    Convert.ToUInt16(this.ddgBankAcct.DataSource.Columns.IndexOf("C_BANKACCOUNT_ID"));
            this.ddgBankAcct.SelectedColomnIdex =
                this.ddgBankAcct.DataSource.Columns.IndexOf("ACCOUNTNO");
        }


        private void ckAllOrAny_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void cmbSearchAndIncludeToPreviousResult_Click(object sender, EventArgs e)
        {
            DialogResult considerPreviousCriteria =
                MessageBox.Show("Should New Search Result Consider Previous Criterion", "Look Up",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (considerPreviousCriteria == DialogResult.Cancel)
                return;

            this.Enabled = false;

            DataTable previousSearchResult = new DataTable();
            DataTable currentSearchCriteriaResult = new DataTable();

            this.establishSearchCriterion();
            currentSearchCriteriaResult =
                this.getDataFromDb.getC_BANKCHECKInfo(this.searchQuery, this.logicalConnector, "", "", "",
                     "", "", DateTime.Now, false, 
                     triStateBool.Ignor, triStateBool.Ignor, false, false, "AND");

            currentSearchCriteriaResult =
                this.getDataFromDb.clearRedundantRow(currentSearchCriteriaResult, "C_BANKCHECK_ID");


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

                if (previousSearchResult.Columns.Count <= 0)
                {
                    previousSearchResult = currentSearchCriteriaResult.Copy();
                }
                else
                    previousSearchResult =
                        this.getDataFromDb.mergeTables(previousSearchResult,
                            currentSearchCriteriaResult, "C_BANKCHECK_ID", true);
            }
            else if (considerPreviousCriteria == DialogResult.No)
            {
                previousSearchResult =
                        this.getDataFromDb.mergeTables(previousSearchResult,
                            currentSearchCriteriaResult, "C_BANKCHECK_ID", false);
            }
            generalResultInformation.searchResult =
                previousSearchResult.Copy();
            this.Enabled = true;
        }


        private void cmdSearch_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            generalResultInformation.searchCritrion = this.searchQuery;
            generalResultInformation.logicConnector = this.logicalConnector;

            if (!this.getDataFromDb.checkIfTableContainesData
                (generalResultInformation.searchResult))
            {
                MessageBox.Show("No Record Found For Search Query",
                    "Look Up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Enabled = true;
            }
            else
            {
                this.Enabled = true;
                this.Close();
            }  
        }



    }
}
