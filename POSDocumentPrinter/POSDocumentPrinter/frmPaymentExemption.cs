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
    public partial class frmPaymentExemption : Form
    {
        public frmPaymentExemption()
        {
            InitializeComponent();
        }

        bool recordView = true;
        bool loadingSearchResult = false;

        int intCurrExemptionSelectedRowIndex = -1;
        int intCurrExemptionDtlSelectedRowIndex = -1;

        decimal dcCurrInvAllowedExemption = 0;
        decimal dcCurrInvExemptedAmt = 0;
        decimal dcTotalExemption = 0;
        decimal dcTotalBaseAmount = 0;
        
        string stBpartnerID = "";        

        Color normalFieldColor = Color.Black;
        Color missingFieldColor = Color.Red;
        Color ChangedFieldColor = Color.Blue;

        exemptionType exType;

        DataGridViewCellStyle cancelButtonStyle = new DataGridViewCellStyle();

        DataTable dtExistingExemption = new DataTable();
        DataTable dtNewExemptionDetail = new DataTable();
        

        DataTable dtCustomerList = new DataTable();
        DataTable dtIdenticalCustomersList = new DataTable();
        DataTable dtCustomerSalesList = new DataTable();

        DataTable dtActiveOrganisations = new DataTable();     

        dataBuilder getDataFromDb = new dataBuilder();


        private void newForm()
        {
            this.intCurrExemptionSelectedRowIndex = -1;
            this.intCurrExemptionDtlSelectedRowIndex = -1;

            this.dcCurrInvAllowedExemption = 0;
            this.dcCurrInvExemptedAmt = 0;
            this.dcTotalExemption = 0;
            this.dcTotalBaseAmount = 0;

            this.txtOrganisation.Text = "";
            if (this.cmbOrganisation.Items.Count > 0)
                this.cmbOrganisation.SelectedIndex = 0;
            this.txtDocumentNo.Text = "";
            this.txtDescription.Text = "";

            this.ddgCustomers.SelectedRowKey = null;
            this.ddgCustomers.SelectedRow.Clear();
            this.ddgCustomers.SelectedItem = "";

            this.rbtWithHolding.Checked = true;

            this.ntbTotalAmount.Amount = "0";
            
            this.ddgInvoice.SelectedRowKey = null;
            this.ddgInvoice.SelectedRow.Clear();
            this.ddgInvoice.SelectedItem = "";

            this.ntbAmount.Amount = "0";
            this.ntbExemptedAmount.Amount = "0";

            this.dtNewExemptionDetail.Clear();

            this.lblDocumentNo.ForeColor = normalFieldColor;
            this.lblCustomer.ForeColor = this.normalFieldColor;
            this.lbltotalExemption.ForeColor = normalFieldColor;

            this.txtOrganisation.Visible = false;
            this.cmbOrganisation.Visible = true;

            this.dtgInvoiceAmount.BackgroundColor = SystemColors.Control;
            this.dtgInvoiceAmount.Columns["remove"].Visible = true;

            this.dtpDocumentDate.Enabled = true;
            this.txtDocumentNo.Enabled = true;
            this.txtDescription.Enabled = true;

            this.ddgCustomers.Enabled = true;
            this.rbtWithHolding.Enabled = true;
            this.rbtVATExemption.Enabled = true;

            this.ntbTotalAmount.Enabled = true;

            this.dtNewExemptionDetail.Rows.Clear();

            this.tlsConfirm.Enabled = true;
        }

        private bool isSourceInvoiceCorrect()
        {
            bool sourceInvoiceCorrect = true;
            decimal salesAmount = 0M;
            
            for (int exemptionRowCounter = 0;
                 exemptionRowCounter <= this.dtNewExemptionDetail.Rows.Count - 1 && 
                 sourceInvoiceCorrect;
                 exemptionRowCounter++)
            {
                salesAmount =
                    decimal.Parse(this.dtNewExemptionDetail.Rows[exemptionRowCounter]["SALES_AMOUNT"].ToString());
                if (salesAmount < 10000)
                {
                    sourceInvoiceCorrect = false;

                    for (int exemptionRowCounter2 = 0;
                               exemptionRowCounter2 <= this.dtNewExemptionDetail.Rows.Count - 1;
                               exemptionRowCounter2++)
                    {
                        if (this.dtNewExemptionDetail.Rows[exemptionRowCounter]["SALES_ID"].ToString() ==
                            this.dtNewExemptionDetail.Rows[exemptionRowCounter2]["SALES_ID"].ToString())
                            continue;

                        if (this.dtNewExemptionDetail.Rows[exemptionRowCounter]["Date Sold"].ToString().
                            Equals(this.dtNewExemptionDetail.Rows[exemptionRowCounter2]["Date Sold"]))
                        {
                            salesAmount = salesAmount + 
                                decimal.Parse(this.dtNewExemptionDetail.Rows[exemptionRowCounter2]["SALES_AMOUNT"].ToString());                
                        }

                        if (salesAmount >= 10000)
                        {
                            sourceInvoiceCorrect = true;
                            break;
                        }
                    }

                    if (salesAmount < 10000)
                    { 

                    }
                }
                else
                {
                    sourceInvoiceCorrect = true;
                }
            }
            return sourceInvoiceCorrect;
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

            if (this.ddgCustomers.SelectedRowKey == null ||
                this.ddgCustomers.SelectedItem == "")
            {
                this.lblCustomer.ForeColor = this.missingFieldColor;
                formIsComplete = false;
            }
            else
                this.lblCustomer.ForeColor = this.normalFieldColor;

            if (this.ntbTotalAmount.Value == "" ||
                this.ntbTotalAmount.Value == "0")
            {
                this.lbltotalExemption.ForeColor = missingFieldColor;
                formIsComplete = false;
            }
            else
                this.lbltotalExemption.ForeColor = normalFieldColor;
            

            if (this.dtgInvoiceAmount.Rows.Count <= 0)
            {
                bool blAllowAmount = false;
                if (
                   MessageBox.Show("No Source Invoice Found." +
                       "\n Enter pass key to proceed.", "New Deposit",
                       MessageBoxButtons.OKCancel, MessageBoxIcon.Information,
                       MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    frmValidateSecurityKey allowAmount = new frmValidateSecurityKey();
                    allowAmount.TopMost = true;
                    allowAmount.ShowDialog();

                    if (generalResultInformation.securityPassKeyCorrect)
                    {
                        blAllowAmount = true;
                    }
                }
                if (!blAllowAmount)
                {
                    this.dtgInvoiceAmount.BackgroundColor = this.missingFieldColor;
                    formIsComplete = false;
                }
                else
                {
                    this.dtgInvoiceAmount.BackgroundColor = SystemColors.Control;
                }
            }
            else
                this.dtgInvoiceAmount.BackgroundColor = SystemColors.Control;
            
            return formIsComplete;
        }

        private bool exemptionInCurrentDetail(string salesID)
        {
            foreach (DataRow dr in this.dtNewExemptionDetail.Rows)
            {
                if (dr["SALES_ID"].ToString() == salesID)
                    return true;
            }
            return false;
        }

        private void enableNavigationButton()
        {
            if (this.dtgExemptionSummary.Rows.Count <= 1)
            {
                this.tlsFirstRecord.Enabled = false;
                this.tlsPreviousRecord.Enabled = false;
                this.tlsNextRecord.Enabled = false;
                this.tlsLastRecord.Enabled = false;
                return;
            }

            if (this.dtgExemptionSummary.SelectedRows[0].Index ==
                this.dtgExemptionSummary.Rows.Count - 1)
            {
                this.tlsFirstRecord.Enabled = true;
                this.tlsPreviousRecord.Enabled = true;
                this.tlsNextRecord.Enabled = false;
                this.tlsLastRecord.Enabled = false;
                return;
            }

            if (this.dtgExemptionSummary.SelectedRows[0].Index == 0)
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

        private void enableExemptionDetail(bool enabled)
        {
            //this.dtgInvoiceAmount.Enabled = enabled;
            this.ddgInvoice.Enabled = enabled;
            this.ntbAmount.Enabled = enabled;
            this.cmdAdd.Enabled = enabled;
        }

        private void createDetailExemptionTable()
        {
            this.dtNewExemptionDetail =
                this.getDataFromDb.getC_EXEMPTIONLINEInfo(null, "", "", "", "",
                    generalResultInformation.Station, false, true, "AND");

            this.dtNewExemptionDetail.Columns.Add("remove");
            this.dtNewExemptionDetail.Columns.Add("Sales");
            this.dtNewExemptionDetail.Columns.Add("Date Sold");

            this.dtNewExemptionDetail.Columns["remove"].SetOrdinal(0);
            this.dtNewExemptionDetail.Columns["Sales"].SetOrdinal(1);
            this.dtNewExemptionDetail.Columns["Date Sold"].SetOrdinal(3);
            this.dtNewExemptionDetail.Columns["SALES_AMOUNT"].SetOrdinal(4);
            this.dtNewExemptionDetail.Columns["EXEMPTABLE_AMOUNT"].SetOrdinal(5);
            this.dtNewExemptionDetail.Columns["EXEMPTED_AMOUNT"].SetOrdinal(6);
            this.dtNewExemptionDetail.Columns["REMAINING_EXEMPTION"].SetOrdinal(7);


            this.dtgInvoiceAmount.DataSource =
                this.dtNewExemptionDetail;

            this.dtgInvoiceAmount.Columns["C_EXEMPTIONLINE_ID"].Visible = false;
            this.dtgInvoiceAmount.Columns["AD_ORG_ID"].Visible = false; 
            this.dtgInvoiceAmount.Columns["C_EXEMPTION_ID"].Visible = false;
            this.dtgInvoiceAmount.Columns["CREATED"].Visible = false;
            this.dtgInvoiceAmount.Columns["CREATEDBY"].Visible = false;
            this.dtgInvoiceAmount.Columns["UPDATED"].Visible = false;
            this.dtgInvoiceAmount.Columns["UPDATEDBY"].Visible = false;
            this.dtgInvoiceAmount.Columns["ISACTIVE"].Visible = false;
            this.dtgInvoiceAmount.Columns["SALES_ID"].Visible = false;
            this.dtgInvoiceAmount.Columns["STATION_ID"].Visible = false;


            this.dtgInvoiceAmount.Columns["remove"].HeaderText = "";
            this.dtgInvoiceAmount.Columns["SALES_AMOUNT"].HeaderText = "Sales Amount";
            this.dtgInvoiceAmount.Columns["EXEMPTABLE_AMOUNT"].HeaderText = "Exemtable";
            this.dtgInvoiceAmount.Columns["EXEMPTED_AMOUNT"].HeaderText = "Amount Exempted";
            this.dtgInvoiceAmount.Columns["REMAINING_EXEMPTION"].HeaderText = "Remaing Amount";

            this.dtgInvoiceAmount.Columns["remove"].DefaultCellStyle = this.cancelButtonStyle;

            foreach (DataGridViewColumn columns in this.dtgInvoiceAmount.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DisplayIndex = columns.Index;
            }
        }

        private void fillDetailExemptionTable(string C_EXEMPTION_ID)
        {
            if (C_EXEMPTION_ID == "")
                return;
            this.dtNewExemptionDetail.Rows.Clear();
            
            DataTable exemptionDtlInfo =
                this.getDataFromDb.getC_EXEMPTIONLINEInfo(null, "", "", 
                    C_EXEMPTION_ID, "", "", false, false, "AND");

            foreach (DataRow dr in exemptionDtlInfo.Rows)
            {
                DataRow expDtl = this.dtNewExemptionDetail.NewRow();
                foreach (DataColumn dc in exemptionDtlInfo.Columns)
                {
                    string colName = dc.ColumnName;
                    expDtl[colName] = dr[colName];
                }
                expDtl["remove"] = "";

                DataTable salesInf =
                    this.getDataFromDb.getSalesInfo(null, "",
                        dr["SALES_ID"].ToString(), dr["STATION_ID"].ToString(),
                        "", "", "", triaStateBool.Ignor, 
                        false, false, false, "AND");
                if (this.getDataFromDb.checkIfTableContainesData(salesInf))
                {
                    expDtl["Sales"] = salesInf.Rows[0]["ref_no"].ToString();
                    expDtl["Date Sold"] = salesInf.Rows[0]["salesDateTime"].ToString();
                }
                else
                {
                    expDtl["Sales"] = '0';
                    expDtl["Date Sold"] = DateTime.Now.ToString(); 
                }

                this.dtNewExemptionDetail.Rows.Add(expDtl);                
            }

            this.dtgInvoiceAmount.Columns["remove"].Visible = false;
        }

        private void loadSearchResultDataToExistingMainRecord()
        {
            this.dtExistingExemption.Rows.Clear();
            DataRow drExistingExemption;
            for (int rowCounter = 0; 
                    rowCounter <= generalResultInformation.searchResult.Rows.Count - 1; 
                    rowCounter++)
            { 
                drExistingExemption = this.dtExistingExemption.NewRow();

                drExistingExemption["C_EXEMPTION_ID"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["C_EXEMPTION_ID"].ToString();
                drExistingExemption["AD_ORG_ID"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["AD_ORG_ID"].ToString();
                drExistingExemption["DOCUMENTNO"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["DOCUMENTNO"].ToString();
                drExistingExemption["DATEINVOICED"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["DATEINVOICED"].ToString();
                drExistingExemption["DESCRIPTION"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["DESCRIPTION"].ToString();
                drExistingExemption["C_BPARTNER_ID"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["C_BPARTNER_ID"].ToString();

                DataTable CustomerInfo = this.getDataFromDb.getCustomersInfo(null, "", 
                        generalResultInformation.searchResult.Rows[rowCounter]["C_BPARTNER_ID"].ToString(),
                        generalResultInformation.searchResult.Rows[rowCounter]["STATION_ID"].ToString()
                        , "", "", triaStateBool.Ignor, false, "AND");

                if (!this.getDataFromDb.checkIfTableContainesData(CustomerInfo))
                {
                    drExistingExemption["Customer"] = "NOT AVAILABLE";
                }
                else
                    drExistingExemption["Customer"] = CustomerInfo.Rows[0]["customer_name"].ToString();

                DataTable OrgInfo = this.getDataFromDb.getnodesInfo(null, "", "",
                        generalResultInformation.searchResult.Rows[rowCounter]["STATION_ID"].ToString(),
                        generalResultInformation.searchResult.Rows[rowCounter]["AD_ORG_ID"].ToString(),
                        triaStateBool.Ignor, false, "AND");

                if (!this.getDataFromDb.checkIfTableContainesData(OrgInfo))
                {
                    drExistingExemption["Organisation"] = "NOT AVAILABLE";
                }
                else
                    drExistingExemption["Organisation"] = OrgInfo.Rows[0]["node"].ToString();


                drExistingExemption["EXEMPTIONTYPE"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["EXEMPTIONTYPE"].ToString();
                drExistingExemption["BASEAMOUNT"] =
                    decimal.Parse(generalResultInformation.searchResult.Rows[rowCounter]["BASEAMOUNT"].ToString());
                drExistingExemption["EXEMPTEDAMT"] =
                    decimal.Parse(generalResultInformation.searchResult.Rows[rowCounter]["EXEMPTEDAMT"].ToString());
                drExistingExemption["STATION_ID"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["STATION_ID"].ToString();

                this.dtExistingExemption.Rows.Add(drExistingExemption);
            }
        }
        

        private void frmPaymentExemption_Load(object sender, EventArgs e)
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


            this.createDetailExemptionTable();

            this.enableExemptionDetail(false);

            this.dtExistingExemption =
                this.getDataFromDb.getC_EXEMPTIONInfo(null, "", "", "", "", DateTime.Now, false,
                        exemptionType.ignor, "", false, true, "AND");

            this.dtExistingExemption.Columns.Add("Customer");
            this.dtExistingExemption.Columns.Add("Organisation");
            
            this.dtgExemptionSummary.DataSource =
                this.dtExistingExemption;

            this.dtgExemptionSummary.Columns["C_EXEMPTION_ID"].Visible = false;
            this.dtgExemptionSummary.Columns["AD_ORG_ID"].Visible = false;
            this.dtgExemptionSummary.Columns["CREATED"].Visible = false;
            this.dtgExemptionSummary.Columns["CREATEDBY"].Visible = false;
            this.dtgExemptionSummary.Columns["UPDATED"].Visible = false;
            this.dtgExemptionSummary.Columns["UPDATEDBY"].Visible = false;
            this.dtgExemptionSummary.Columns["ISACTIVE"].Visible = false;
            this.dtgExemptionSummary.Columns["DESCRIPTION"].Visible = false;
            this.dtgExemptionSummary.Columns["C_BPARTNER_ID"].Visible = false;
            this.dtgExemptionSummary.Columns["PROCESSED"].Visible = false;
            this.dtgExemptionSummary.Columns["STATION_ID"].Visible = false;

            this.dtExistingExemption.Columns["Organisation"].SetOrdinal(0);
            this.dtExistingExemption.Columns["DOCUMENTNO"].SetOrdinal(1);
            this.dtExistingExemption.Columns["DATEINVOICED"].SetOrdinal(2);
            this.dtExistingExemption.Columns["Customer"].SetOrdinal(3);
            this.dtExistingExemption.Columns["EXEMPTIONTYPE"].SetOrdinal(4);            
            this.dtExistingExemption.Columns["BASEAMOUNT"].SetOrdinal(5);
            this.dtExistingExemption.Columns["EXEMPTEDAMT"].SetOrdinal(6);            

            this.dtgExemptionSummary.Columns["DOCUMENTNO"].HeaderText = "Document No";
            this.dtgExemptionSummary.Columns["DATEINVOICED"].HeaderText = "Date";
            this.dtgExemptionSummary.Columns["EXEMPTIONTYPE"].HeaderText = "Type";
            this.dtgExemptionSummary.Columns["BASEAMOUNT"].HeaderText = "Base Amount";
            this.dtgExemptionSummary.Columns["EXEMPTEDAMT"].HeaderText = "Amount Exempted";


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

            this.enableNavigationButton();           

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

            if (!this.isSourceInvoiceCorrect() && !this.rbtVATExemption.Checked)
            {
                bool blAllowAmount = false;
                if (
                   MessageBox.Show("Source Invoices are not correct." +
                       "\n Enter pass key to proceed.", "New Deposit",
                       MessageBoxButtons.OKCancel, MessageBoxIcon.Information,
                       MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    frmValidateSecurityKey allowAmount = new frmValidateSecurityKey();
                    allowAmount.TopMost = true;
                    allowAmount.ShowDialog();

                    if (generalResultInformation.securityPassKeyCorrect)
                    {
                        blAllowAmount = true;
                    }
                }
                if (!blAllowAmount)
                {
                    this.Enabled = true;
                    if (!this.recordView)
                        this.tlsChangeView_Click(sender, e);
                    MessageBox.Show("Some source invoices are under withholding amount.\n" +
                        " Check the invoices selected before you proceed.",
                        "Save record", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    return;
                }
            }

            if(Math.Abs(decimal.Parse(this.ntbTotalAmount.Amount) - this.dcTotalExemption) > 0.5M  )
            {
                bool blAllowAmount = false;
                if (
                   MessageBox.Show("Exempted amount not correct." +
                       "\n Enter pass key to proceed.", "New Deposit",
                       MessageBoxButtons.OKCancel, MessageBoxIcon.Information,
                       MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    frmValidateSecurityKey allowAmount = new frmValidateSecurityKey();
                    allowAmount.TopMost = true;
                    allowAmount.ShowDialog();

                    if (generalResultInformation.securityPassKeyCorrect)
                    {
                        blAllowAmount = true;
                    }
                }
                if (!blAllowAmount)
                {
                    this.Enabled = true;
                    if (!this.recordView)
                        this.tlsChangeView_Click(sender, e);
                    MessageBox.Show("Total Amount Exempted Does Not Match.\n" +
                        " Check amount entered before you proceed.",
                        "Save record", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    return;
                }
            }

            DataTable newExemptionSummary =
                this.getDataFromDb.getC_EXEMPTIONInfo(null, "", "", "", "", DateTime.Now, false,
                        exemptionType.ignor, "", false, true, "AND");

            DataRow drNewExemptionDetail = newExemptionSummary.NewRow();

            drNewExemptionDetail["AD_ORG_ID"] =
                this.dtActiveOrganisations.Rows[this.cmbOrganisation.SelectedIndex]["AD_ORG_ID"].ToString();
            drNewExemptionDetail["DOCUMENTNO"] = this.txtDocumentNo.Text;
            drNewExemptionDetail["DATEINVOICED"] = this.dtpDocumentDate.Value.ToString("yyyy-MM-dd");
            drNewExemptionDetail["DESCRIPTION"] = this.txtDescription.Text;
            drNewExemptionDetail["C_BPARTNER_ID"] = this.ddgCustomers.SelectedRowKey.ToString();
            drNewExemptionDetail["EXEMPTIONTYPE"] = this.rbtWithHolding.Checked ? "WITHHOLDING" : "VAT";
            drNewExemptionDetail["BASEAMOUNT"] = this.dcTotalBaseAmount;
            drNewExemptionDetail["EXEMPTEDAMT"] = this.dcTotalExemption;
            drNewExemptionDetail["STATION_ID"] = generalResultInformation.Station;

            newExemptionSummary.Rows.Add(drNewExemptionDetail);

            string[] recordId =
                this.getDataFromDb.changeDataBaseTableData(newExemptionSummary, "C_EXEMPTION", "INSERT", true);

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

            if (this.dtNewExemptionDetail.Rows.Count > 0)
            {

                for (int currentDetailRecord = 0;
                     currentDetailRecord <= this.dtNewExemptionDetail.Rows.Count - 1;
                     currentDetailRecord++)
                {
                    this.dtNewExemptionDetail.Rows[currentDetailRecord]["C_EXEMPTION_ID"] =
                        newRecordId[1];
                    this.dtNewExemptionDetail.Rows[currentDetailRecord]["AD_ORG_ID"] =
                        this.dtActiveOrganisations.Rows[this.cmbOrganisation.SelectedIndex]["AD_ORG_ID"].ToString();
                    this.dtNewExemptionDetail.Rows[currentDetailRecord]["STATION_ID"] =
                        generalResultInformation.Station;
                }

                this.getDataFromDb.changeDataBaseTableData(this.dtNewExemptionDetail.Copy(), "C_EXEMPTIONLINE", "INSERT", true);
            }
            
            DataRow drExistingExemption = 
                this.dtExistingExemption.NewRow();

            drExistingExemption["C_EXEMPTION_ID"] = 
                newRecordId[1];
            drExistingExemption["AD_ORG_ID"] =
                this.dtActiveOrganisations.Rows[this.cmbOrganisation.SelectedIndex]["AD_ORG_ID"].ToString();
            drExistingExemption["Organisation"] = 
                this.cmbOrganisation.SelectedItem.ToString();
            drExistingExemption["DOCUMENTNO"] = 
                this.txtDocumentNo.Text;
            drExistingExemption["DATEINVOICED"] = 
                this.dtpDocumentDate.Value.ToString("yyyy-MM-dd");
            drExistingExemption["DESCRIPTION"] = 
                this.txtDescription.Text;
            drExistingExemption["C_BPARTNER_ID"] = 
                this.ddgCustomers.SelectedRowKey.ToString();
            drExistingExemption["Customer"] = 
                this.ddgCustomers.SelectedItem;
            drExistingExemption["EXEMPTIONTYPE"] = 
                this.rbtWithHolding.Checked ? "WITHHOLDING" : "VAT";
            drExistingExemption["BASEAMOUNT"] = 
                this.dcTotalBaseAmount;
            drExistingExemption["EXEMPTEDAMT"] = 
                this.dcTotalExemption;
            drExistingExemption["STATION_ID"] = 
                generalResultInformation.Station;

            this.dtExistingExemption.Rows.Add(drExistingExemption);
            
            MessageBox.Show("New Record Saved Successfully.",
                    "Save record", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            this.Enabled = true;            
            this.tlsLastRecord_Click(sender, e);
            this.dtgExemptionSummary_CellClick(sender, e);
        }

        private void tlsSearch_Click(object sender, EventArgs e)
        {
            generalResultInformation.searchResult.Rows.Clear();            
            generalResultInformation.searchCritrion.Rows.Clear();

            this.dtExistingExemption.Rows.Clear();
            this.dtNewExemptionDetail.Rows.Clear();
            this.enableNavigationButton();
            this.newForm();
            
            frmSearchExemption newSearch = new frmSearchExemption();
            newSearch.ShowDialog(this);
            this.loadingSearchResult = true;
            this.loadSearchResultDataToExistingMainRecord();
            this.loadingSearchResult = false;

            if (this.dtgExemptionSummary.Rows.Count > 0 )
                this.dtgExemptionSummary.Rows[0].Selected = true;
            
            this.dtgExemptionSummary_CellClick(sender, new DataGridViewCellEventArgs(0, 0));            
            
        }

        private void tlsChangeView_Click(object sender, EventArgs e)
        {
            if (this.recordView)
            {
                this.recordView = false;
                this.dtgExemptionSummary.Size = new System.Drawing.Size(542, 315);
                this.dtgExemptionSummary.Visible = true;
                this.dtgExemptionSummary.BringToFront();
            }
            else
            {
                this.dtgExemptionSummary.Visible = false;
                this.dtgExemptionSummary.Size = new System.Drawing.Size(542, 11);
                this.recordView = true;
            }
        }


        private void tlsFirstRecord_Click(object sender, EventArgs e)
        {
            this.dtgExemptionSummary.Rows[0].Selected = true;
        }

        private void tlsPreviousRecord_Click(object sender, EventArgs e)
        {
            this.dtgExemptionSummary.Rows[this.intCurrExemptionSelectedRowIndex - 1].Selected = true;
        }

        private void tlsNextRecord_Click(object sender, EventArgs e)
        {
            this.dtgExemptionSummary.Rows[this.intCurrExemptionSelectedRowIndex + 1].Selected = true;
        }

        private void tlsLastRecord_Click(object sender, EventArgs e)
        {
            this.dtgExemptionSummary.Rows[this.dtgExemptionSummary.Rows.Count - 1].Selected = true;            
        }


        private void tlsPrint_Click(object sender, EventArgs e)
        {

        }

        private void tlsConfirm_Click(object sender, EventArgs e)
        {
            this.tlsSave_Click(sender, e);
        }


        private void tlsExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ddgCustomers_SelectedItemClicked(object sender, EventArgs e)
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

        private void ddgCustomers_selectedItemChanged(object sender, EventArgs e)
        {
            this.dtNewExemptionDetail.Rows.Clear();
            this.dtIdenticalCustomersList.Rows.Clear();
            this.ntbAmount.Amount = "0";
            this.ddgInvoice.SelectedRow.Clear();
            this.ddgInvoice.SelectedItem = "";
            this.ddgInvoice.SelectedRowKey = null;

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
                    
                this.enableExemptionDetail(true);
            }
            else
            {
                this.stBpartnerID = "";
                this.enableExemptionDetail(false);
            }
        }


        private void ddgInvoice_SelectedItemClicked(object sender, EventArgs e)
        {
            this.dtCustomerSalesList =
                this.getDataFromDb.getSalesInfo(this.dtIdenticalCustomersList, "OR", "", generalResultInformation.Station,
                            this.ddgInvoice.SelectedItem, generalResultInformation.concernedNode, 
                            this.dtIdenticalCustomersList.Rows.Count == 0 ? this.stBpartnerID : "",
                            triaStateBool.Ignor, false, false, false, "AND");
                        
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

        private void ddgInvoice_selectedItemChanged(object sender, EventArgs e)
        {
            this.dcCurrInvAllowedExemption = 0;
            this.dcCurrInvExemptedAmt = 0;

            if (this.ddgInvoice.SelectedRowKey == null ||
                this.ddgInvoice.SelectedRow == null)
            {
                this.ntbAmount.Amount = "0";
                this.ntbAmount.Enabled = false;
                return;
            }
            
            if (this.cmdAdd.Text != "Modify" &&
                this.exemptionInCurrentDetail(this.ddgInvoice.SelectedRowKey.ToString()))
            {
                MessageBox.Show("Duplicate Invoice Not Allowed.",
                    "New Exemption", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                this.ntbAmount.Amount = "0";
                this.ntbAmount.Enabled = false;
                return;
            }

            if (this.ddgInvoice.SelectedRow.Rows.Count > 0)
            {
                if (this.rbtWithHolding.Checked)
                {
                    this.dcCurrInvAllowedExemption =
                    decimal.Parse(this.ddgInvoice.SelectedRow.Rows[0]["Sub Total"].ToString());

                    //this.dcCurrInvAllowedExemption =
                    //    this.dcCurrInvAllowedExemption > 10000 ? this.dcCurrInvAllowedExemption * 0.02M : 0;

                    this.dcCurrInvAllowedExemption =
                        Math.Round(this.dcCurrInvAllowedExemption * 0.02M, 2);
                    this.dcCurrInvExemptedAmt =
                        decimal.Parse(this.ddgInvoice.SelectedRow.Rows[0]["Withholding"].ToString());
                }
                else
                {
                    this.dcCurrInvAllowedExemption =
                        decimal.Parse(this.ddgInvoice.SelectedRow.Rows[0]["VAT"].ToString());
                }
            }
            else
            {
                DataTable salesInfo =
                    this.getDataFromDb.getSalesInfo(null, "", this.ddgInvoice.SelectedRowKey.ToString(),
                            generalResultInformation.Station, "", "", "", triaStateBool.Ignor, false,
                            false, false, "AND");
                
                if (this.rbtWithHolding.Checked)
                {
                    this.dcCurrInvAllowedExemption =
                        decimal.Parse(salesInfo.Rows[0]["sub_total"].ToString());

                    //this.dcCurrInvAllowedExemption =
                    //    this.dcCurrInvAllowedExemption > 10000 ? this.dcCurrInvAllowedExemption * 0.02M : 0;

                    this.dcCurrInvAllowedExemption =
                        Math.Round(this.dcCurrInvAllowedExemption * 0.02M, 2);
                    this.dcCurrInvExemptedAmt =
                        decimal.Parse(salesInfo.Rows[0]["with_holding"].ToString());
                }
                else
                {
                    this.dcCurrInvAllowedExemption =
                        decimal.Parse(salesInfo.Rows[0]["total_tax"].ToString());
                }
            }

            if (this.dcCurrInvAllowedExemption > this.dcCurrInvExemptedAmt)
            {
                DataTable salesExemption =
                    this.getDataFromDb.getC_EXEMPTIONLINEInfo(null, "", "", "",
                        this.ddgInvoice.SelectedRowKey.ToString(), generalResultInformation.Station,
                        true, false, "AND");

                DataTable exemptionInfo = new DataTable();

                foreach (DataRow dr in salesExemption.Rows)
                {
                    exemptionInfo =
                        this.getDataFromDb.getC_EXEMPTIONInfo(null, "", dr["C_EXEMPTION_ID"].ToString(), "",
                                "", DateTime.Now, false, exType, generalResultInformation.Station,
                                true, false, "AND");
                    if (!this.getDataFromDb.checkIfTableContainesData(exemptionInfo))
                        continue;

                    this.dcCurrInvExemptedAmt +=
                        decimal.Parse(dr["EXEMPTED_AMOUNT"].ToString());
                }
            }

            this.dcCurrInvAllowedExemption -= this.dcCurrInvExemptedAmt;

            if (this.dcCurrInvAllowedExemption > 0)
                this.ntbAmount.Enabled = true;
            else
                this.ntbAmount.Enabled = false;

        }


        private void rbtVATExemption_CheckedChanged(object sender, EventArgs e)
        {
            this.exType = exemptionType.VAT;
            if(this.rbtVATExemption.Enabled)
                this.dtNewExemptionDetail.Rows.Clear();
        }

        private void rbtWithHolding_CheckedChanged(object sender, EventArgs e)
        {
            this.exType = exemptionType.WITHHOLDING;
            if(this.rbtWithHolding.Enabled)
                this.dtNewExemptionDetail.Rows.Clear();
        }


        private void cmdAdd_Click(object sender, EventArgs e)
        {
            decimal amount = decimal.Parse(this.ntbAmount.Amount);
            if ((amount - this.dcCurrInvAllowedExemption) > 0.5M)
            {
                MessageBox.Show("Amount Exceeds Maximum amount allowable.",
                    "New Exemption", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                return;
            }

            if (this.cmdAdd.Text == "Modify")
            {
                this.dcTotalBaseAmount -=
                    decimal.Parse(this.dtNewExemptionDetail.Rows[this.intCurrExemptionDtlSelectedRowIndex]["SALES_AMOUNT"].ToString());

                this.dcTotalExemption -=
                    decimal.Parse(this.dtNewExemptionDetail.Rows[this.intCurrExemptionDtlSelectedRowIndex]["EXEMPTED_AMOUNT"].ToString());
                this.dcTotalExemption += amount;
                this.ntbExemptedAmount.Amount = this.dcTotalExemption.ToString();

                DataTable salesInfo =
                    this.getDataFromDb.getSalesInfo(null, "", this.ddgInvoice.SelectedRowKey.ToString(),
                            generalResultInformation.Station, "", "", "", triaStateBool.Ignor, false,
                            false, false, "AND");


                this.dtNewExemptionDetail.Rows[this.intCurrExemptionDtlSelectedRowIndex]["SALES_ID"] =
                    int.Parse(this.ddgInvoice.SelectedRowKey.ToString());
                this.dtNewExemptionDetail.Rows[this.intCurrExemptionDtlSelectedRowIndex]["SALES_AMOUNT"] =
                    salesInfo.Rows[0]["sub_total"].ToString();
                this.dtNewExemptionDetail.Rows[this.intCurrExemptionDtlSelectedRowIndex]["EXEMPTABLE_AMOUNT"] =
                    this.dcCurrInvAllowedExemption.ToString("N02");
                this.dtNewExemptionDetail.Rows[this.intCurrExemptionDtlSelectedRowIndex]["EXEMPTED_AMOUNT"] =
                    amount.ToString("N02");
                this.dtNewExemptionDetail.Rows[this.intCurrExemptionDtlSelectedRowIndex]["REMAINING_EXEMPTION"] =
                    (this.dcCurrInvAllowedExemption - amount).ToString("N02");

                this.dtNewExemptionDetail.Rows[this.intCurrExemptionDtlSelectedRowIndex]["remove"] = "remove";
                this.dtNewExemptionDetail.Rows[this.intCurrExemptionDtlSelectedRowIndex]["Sales"] =
                    salesInfo.Rows[0]["ref_no"].ToString();
                this.dtNewExemptionDetail.Rows[this.intCurrExemptionDtlSelectedRowIndex]["Date Sold"] =
                    DateTime.Parse(salesInfo.Rows[0]["salesDateTime"].ToString()).ToString("dd-MM-yyyy");

                this.dcTotalBaseAmount +=
                    decimal.Parse(salesInfo.Rows[0]["sub_total"].ToString());
            }
            else
            {
                DataRow drNewExemptionDetail = this.dtNewExemptionDetail.NewRow();
                drNewExemptionDetail["SALES_ID"] =
                    int.Parse(this.ddgInvoice.SelectedRowKey.ToString());
                drNewExemptionDetail["SALES_AMOUNT"] =
                    this.ddgInvoice.SelectedRow.Rows[0]["Sub Total"].ToString();
                drNewExemptionDetail["EXEMPTABLE_AMOUNT"] =
                    this.dcCurrInvAllowedExemption.ToString("N02");
                drNewExemptionDetail["EXEMPTED_AMOUNT"] =
                    amount.ToString("N02");
                drNewExemptionDetail["REMAINING_EXEMPTION"] =
                    (this.dcCurrInvAllowedExemption - amount).ToString("N02");

                drNewExemptionDetail["remove"] = "remove";
                drNewExemptionDetail["Sales"] =
                    this.ddgInvoice.SelectedRow.Rows[0]["Reference"].ToString();
                drNewExemptionDetail["Date Sold"] =
                    DateTime.Parse(this.ddgInvoice.SelectedRow.Rows[0]["Date Sold"].ToString()).ToString("dd-MM-yyyy");

                this.dtNewExemptionDetail.Rows.Add(drNewExemptionDetail);

                this.dcTotalExemption += amount;
                this.ntbExemptedAmount.Amount = this.dcTotalExemption.ToString();

                this.dcTotalBaseAmount +=
                    decimal.Parse(this.ddgInvoice.SelectedRow.Rows[0]["Sub Total"].ToString());
            }

            this.ddgInvoice.SelectedItem = "";
            this.ddgInvoice.SelectedRow.Clear();
            this.ddgInvoice.SelectedRowKey = null;

            this.ddgInvoice_selectedItemChanged(sender, e);

            this.cmdAdd.Text = "ADD";        
        }


        private void dtgInvoiceAmount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgInvoiceAmount.SelectedRows.Count < 1 ||
                this.dtgInvoiceAmount.Enabled == false)
            {
                return;
            }
            if (this.dtgInvoiceAmount.Columns["remove"].Visible == false)
                return;

            this.intCurrExemptionDtlSelectedRowIndex = 
                this.dtgInvoiceAmount.SelectedRows[0].Index;

            if (this.dtgInvoiceAmount.CurrentCell != null)
            {
                if (this.dtgInvoiceAmount.CurrentCell.OwningColumn.Index == 0 &&
                    this.dtgInvoiceAmount.CurrentCell.OwningColumn.Name == "remove" &&
                    this.dtgInvoiceAmount.CurrentCell.Value.ToString() == "remove" &&
                    this.dtgInvoiceAmount.CurrentCell.OwningColumn.HeaderText == "")
                {
                    decimal removedExemptionAmount =
                        decimal.Parse(this.dtNewExemptionDetail.Rows[intCurrExemptionDtlSelectedRowIndex]["EXEMPTED_AMOUNT"].ToString());

                    this.dcTotalExemption -= removedExemptionAmount;
                    this.ntbExemptedAmount.Amount = this.dcTotalExemption.ToString();

                    this.dtNewExemptionDetail.Rows.RemoveAt(intCurrExemptionDtlSelectedRowIndex);

                    this.ddgInvoice.SelectedRowKey = null;
                    this.ddgInvoice.SelectedItem = "";
                    this.ddgInvoice.SelectedRow.Clear();
                    this.ddgInvoice_selectedItemChanged(sender, e);
                    this.cmdAdd.Text = "ADD";
                    this.intCurrExemptionDtlSelectedRowIndex = -1;
                }
                else
                {
                    this.cmdAdd.Text = "Modify";

                    this.ddgInvoice.SelectedRowKey =
                        this.dtgInvoiceAmount.Rows[intCurrExemptionDtlSelectedRowIndex].
                            Cells["SALES_ID"].Value.ToString();
                    this.ddgInvoice.SelectedItem =
                        this.dtgInvoiceAmount.Rows[intCurrExemptionDtlSelectedRowIndex].
                            Cells["Sales"].Value.ToString();

                    this.ddgInvoice_SelectedItemClicked(sender, e);
                    this.ddgInvoice_selectedItemChanged(sender, e);

                    this.ntbAmount.Amount =
                        this.dtgInvoiceAmount.Rows[intCurrExemptionDtlSelectedRowIndex].
                            Cells["EXEMPTED_AMOUNT"].Value.ToString();
                }
            }
        }


        private void dtgExemptionSummary_CellClick(object sender, EventArgs e)
        {
            if (this.dtgExemptionSummary.SelectedRows.Count < 1)
            {
                return;
            }

            this.intCurrExemptionSelectedRowIndex =
                this.dtgExemptionSummary.SelectedRows[0].Index;
            this.enableNavigationButton();

            this.tlsConfirm.Enabled = false;

            this.fillDetailExemptionTable(this.dtExistingExemption.Rows[this.intCurrExemptionSelectedRowIndex]["C_EXEMPTION_ID"].ToString());


            this.cmbOrganisation.Visible = false;
            this.txtOrganisation.Visible = true;

            this.dtpDocumentDate.Enabled = false;
            this.txtDocumentNo.Enabled = false;
            this.txtDescription.Enabled = false;

            this.ddgCustomers.Enabled = false;
            this.rbtWithHolding.Enabled = false;
            this.rbtVATExemption.Enabled = false;

            this.ntbTotalAmount.Enabled = false;
            this.enableExemptionDetail(false);
                        

            this.txtOrganisation.Text =
                this.dtExistingExemption.Rows[this.intCurrExemptionSelectedRowIndex]["Organisation"].ToString();

            this.dtpDocumentDate.Value =
                DateTime.Parse(this.dtExistingExemption.Rows[this.intCurrExemptionSelectedRowIndex]["DATEINVOICED"].ToString());

            this.txtDocumentNo.Text =
                this.dtExistingExemption.Rows[this.intCurrExemptionSelectedRowIndex]["DOCUMENTNO"].ToString();

            this.ddgCustomers.SelectedRowKey =
                this.dtExistingExemption.Rows[this.intCurrExemptionSelectedRowIndex]["C_BPARTNER_ID"].ToString();
            this.ddgCustomers.SelectedItem =
                this.dtExistingExemption.Rows[this.intCurrExemptionSelectedRowIndex]["Customer"].ToString();

            this.txtDescription.Text =
                this.dtExistingExemption.Rows[this.intCurrExemptionSelectedRowIndex]["DESCRIPTION"].ToString();

            if (this.dtExistingExemption.Rows[this.intCurrExemptionSelectedRowIndex]
                    ["EXEMPTIONTYPE"].ToString() == "WITHHOLDING")
                this.rbtWithHolding.Checked = true;
            else
                this.rbtVATExemption.Checked = true;

            this.ntbTotalAmount.Amount =
                this.dtExistingExemption.Rows[this.intCurrExemptionSelectedRowIndex]["EXEMPTEDAMT"].ToString();

        }

        private void dtgExemptionSummary_SelectionChanged(object sender, EventArgs e)
        {
            if (this.loadingSearchResult == false)
                this.dtgExemptionSummary_CellClick(sender, e);
            else
                return;
        }

        private void dtgExemptionSummary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dtgExemptionSummary_CellClick(sender, new EventArgs());
        }

        private void dtgExemptionSummary_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string colName = dtgExemptionSummary.Columns[e.ColumnIndex].Name;
            DataView dtView = this.dtExistingExemption.DefaultView;

            if (dtgExemptionSummary.SortOrder == SortOrder.Ascending)
            {
                dtView.Sort = colName + " ASC";
            }
            else
            {
                dtView.Sort = colName + " DESC";
            }

            this.dtExistingExemption = dtView.ToTable();

            this.dtgExemptionSummary_SelectionChanged(sender, new EventArgs());
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
        


    }
}
