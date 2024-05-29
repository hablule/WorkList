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
    public partial class frmNewBpartner : Form
    {
        public frmNewBpartner()
        {
            InitializeComponent();
        }
               

        DataTable dtCashBookList;


        dataBuilder getDataFromDb = new dataBuilder();


        private void frmNewBpartner_Load(object sender, EventArgs e)
        {
            this.dtCashBookList = 
                this.getDataFromDb.getC_CASHBOOKInfo(null, "", "", "", true, false, "AND");

            this.cmbCashBook.Items.Add("   --NONE--   ");

            foreach (DataRow dr in this.dtCashBookList.Rows)
            {
                this.cmbCashBook.Items.Add(dr["NAME"].ToString());
            }
        }


        private void ckIsEmployee_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbCashBook.Visible = this.ckIsEmployee.Checked;
            this.label5.Visible = this.ckIsEmployee.Checked;

            this.cmbCashBook.SelectedIndex = 0;

        }

        private void cmdSaveAndUse_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Please enter valid name before you proceed", "Missing Field", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.ckIsCustomer.Checked)
            {
                DialogResult dlr = MessageBox.Show("Customers May have already been registered. " +
                    "Do you like to proceed anyways", 
                    "Missing Field",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                if (dlr == DialogResult.No)
                    return;
            }

            if (!this.ckIsCustomer.Checked && !this.ckIsEmployee.Checked && !this.ckIsVendor.Checked)
            {
                MessageBox.Show("Please indicate type of buisness partner before you roceed", "Missing Field",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            DataTable newBpartner = 
                this.getDataFromDb.getC_BPARTNERInfo(null, "", "", "", "", triStateBool.Ignor,
                        triStateBool.Ignor, triStateBool.Ignor, triStateBool.Ignor, 
                        false, true, "AND");

            DataRow dr = newBpartner.NewRow();
                        
            dr["AD_CLIENT_ID"] = generalResultInformation.clientId;
            dr["AD_ORG_ID"] = generalResultInformation.organiztionId;
            dr["ISACTIVE"] = "Y";
            dr["CREATED"] = DateTime.Now;
            dr["CREATEDBY"] = generalResultInformation.userId;
            dr["UPDATED"] = DateTime.Now;
            dr["UPDATEDBY"] = generalResultInformation.userId;
            dr["VALUE"] = 
                this.getDataFromDb.getNextSequenceId("DocumentNo_C_BPartner".ToUpper(),"","", generalResultInformation.clientId, true);
            dr["NAME"] = this.txtName.Text;
            dr["NAME2"] = "";
            dr["DESCRIPTION"] = "";
            dr["ISSUMMARY"] = "N";
            string groupId = "";


            if (this.ckIsCustomer.Checked)
            {
                groupId = "1000000";
            }

            if (this.ckIsEmployee.Checked)
            {
                groupId = groupId == "" ? "1000002" : "351000001";
            }

            if (this.ckIsVendor.Checked)
            {
                groupId = groupId == "" ? "1000001" : "351000001";
            }


            dr["C_BP_GROUP_ID"] = groupId;
            dr["ISONETIME"] = "N";
            dr["ISPROSPECT"] = "N";
            dr["ISVENDOR"] = this.ckIsVendor.Checked ? "Y" : "N";
            dr["ISCUSTOMER"] = this.ckIsCustomer.Checked ? "Y" : "N";
            dr["ISEMPLOYEE"] = this.ckIsEmployee.Checked ? "Y" : "N";
            dr["ISSALESREP"] = "N";
            //dr["REFERENCENO"] = "";
            //dr["DUNS"] = "";
            //dr["URL"] = "";
            //dr["AD_LANGUAGE"] = "";
            dr["TAXID"] = this.ntbTIN.ToString();
            dr["ISTAXEXEMPT"] = "N";
            //dr["C_INVOICESCHEDULE_ID"] = "";
            //dr["RATING"] = "";
            //dr["SALESVOLUME"] = "";
            //dr["NUMBEREMPLOYEES"] = "";
            //dr["NAICS"] = "";
            //dr["FIRSTSALE"] = "";
            //dr["ACQUSITIONCOST"] = "";
            //dr["POTENTIALLIFETIMEVALUE"] = "";
            //dr["ACTUALLIFETIMEVALUE"] = "";
            //dr["SHAREOFCUSTOMER"] = "";
            //dr["PAYMENTRULE"] = "";
            //dr["SO_CREDITLIMIT"] = "";
            //dr["SO_CREDITUSED"] = "";
            //dr["C_PAYMENTTERM_ID"] = "";
            //dr["M_PRICELIST_ID"] = "";
            //dr["M_DISCOUNTSCHEMA_ID"] = "";
            //dr["C_DUNNING_ID"] = "";
            dr["ISDISCOUNTPRINTED"] = "N";
            //dr["SO_DESCRIPTION"] = "";
            //dr["POREFERENCE"] = "";
            //dr["PAYMENTRULEPO"] = "";
            //dr["PO_PRICELIST_ID"] = "";
            //dr["PO_DISCOUNTSCHEMA_ID"] = "";
            //dr["PO_PAYMENTTERM_ID"] = "";
            //dr["DOCUMENTCOPIES"] = "";
            //dr["C_GREETING_ID"] = "";
            //dr["INVOICERULE"] = "";
            //dr["DELIVERYRULE"] = "";
            //dr["FREIGHTCOSTRULE"] = "";
            //dr["DELIVERYVIARULE"] = "";
            //dr["SALESREP_ID"] = "";
            dr["SENDEMAIL"] = "N";
            //dr["BPARTNER_PARENT_ID"] = "";
            //dr["INVOICE_PRINTFORMAT_ID"] = "";
            //dr["SOCREDITSTATUS"] = "";
            //dr["SHELFLIFEMINPCT"] = "";
            //dr["AD_ORGBP_ID"] = "";
            //dr["FLATDISCOUNT"] = "";
            //dr["TOTALOPENBALANCE"] = "";
                
            if(this.cmbCashBook.SelectedIndex > 0 && this.ckIsEmployee.Checked)
            {
                dr["C_CASHBOOK_ID"] =
                    this.dtCashBookList.Rows[this.cmbCashBook.SelectedIndex - 1]["C_CASHBOOK_ID"].ToString();
            }

            newBpartner.Rows.Add(dr);
            string[] newbBpartner =
                this.getDataFromDb.changeDataBaseTableData(newBpartner, "C_BPARTNER", "INSERT");

            if (newbBpartner.Length < 1)
            {
                MessageBox.Show("Unable to record Business Partner. Please Try again.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] newPrimaryKey = newbBpartner[0].Split(new string[] { " <(", ")>||" },
                StringSplitOptions.RemoveEmptyEntries);

            if (!newPrimaryKey.Contains(this.getDataFromDb.getTablePrimaryKey
                                            ("C_BPARTNER")[0]))
            {
                MessageBox.Show("Unable to record Partner. Please Try again.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable partnerLocation = 
                this.getDataFromDb.getDataTableStructure("C_BPARTNER_LOCATION");

            DataRow dr2 = partnerLocation.NewRow();
                        
            dr2["AD_CLIENT_ID"] = generalResultInformation.clientId;
            dr2["AD_ORG_ID"] = generalResultInformation.allOrganisationRepresentativeKey;
            dr2["ISACTIVE"] = "Y";
            dr2["CREATED"] = DateTime.Now;
            dr2["CREATEDBY"] = generalResultInformation.userId;
            dr2["UPDATED"] = DateTime.Now;
            dr2["UPDATEDBY"] = generalResultInformation.userId;
            dr2["NAME"] = "NOT AVAILABLE";
            dr2["ISBILLTO"] = "Y";
            dr2["ISSHIPTO"] = "Y";
            dr2["ISPAYFROM"] = "Y";
            dr2["ISREMITTO"] = "Y";
            dr2["PHONE"] = this.txtPhone.Text;
            dr2["PHONE2"] = "";
            dr2["FAX"] = this.txtFax.Text;
            dr2["ISDN"] = "";
            //dr2["C_SALESREGION_ID"] = "";
            dr2["C_BPARTNER_ID"] = newPrimaryKey[1];
            dr2["C_LOCATION_ID"] = "351235630";


            partnerLocation.Rows.Add(dr2);
            string[] newbBpartnerlocation =
                this.getDataFromDb.changeDataBaseTableData(partnerLocation, "C_BPARTNER_LOCATION", "INSERT");

            if (newbBpartnerlocation.Length < 1)
            {
                MessageBox.Show("Unable to record Business Partner location." +
                    " Please Contact your Administrator.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
            }

            string[] newPrimaryKey2 = newbBpartnerlocation[0].Split(new string[] { " <(", ")>||" },
                StringSplitOptions.RemoveEmptyEntries);

            if (!newPrimaryKey2.Contains(this.getDataFromDb.getTablePrimaryKey
                                            ("C_BPARTNER_LOCATION")[0]))
            {
                MessageBox.Show("Unable to record Business Partner location. " +
                    "Please Contact your Administrator.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
            }

            //Record Default Accounts

            //Vendor Account
            DataTable dtVendorAcctInfo = this.getDataFromDb.getDataTableStructure("C_BP_VENDOR_ACCT");
            DataRow drNewVendorAcct = dtVendorAcctInfo.NewRow();
            drNewVendorAcct["C_BPARTNER_ID"] = newPrimaryKey[1]; ;
            drNewVendorAcct["C_ACCTSCHEMA_ID"] = 1000000;
            drNewVendorAcct["AD_CLIENT_ID"] = 1000000;
            drNewVendorAcct["AD_ORG_ID"] = 0;
            drNewVendorAcct["CREATEDBY"] = generalResultInformation.userId;
            drNewVendorAcct["UPDATEDBY"] = generalResultInformation.userId;
            drNewVendorAcct["V_LIABILITY_ACCT"] = 1000026;
            drNewVendorAcct["V_LIABILITY_SERVICES_ACCT"] = 1000027;
            drNewVendorAcct["V_PREPAYMENT_ACCT"] = 1000028;

            dtVendorAcctInfo.Rows.Add(drNewVendorAcct);

            this.getDataFromDb.changeDataBaseTableData(dtVendorAcctInfo, "C_BP_VENDOR_ACCT", "INSERT");

            //Customers Account
            DataTable dtCustomerAcctInfo = this.getDataFromDb.getDataTableStructure("C_BP_CUSTOMER_ACCT");
            DataRow drNewCustAcct = dtCustomerAcctInfo.NewRow();
            drNewCustAcct["C_BPARTNER_ID"] = newPrimaryKey[1];
            drNewCustAcct["C_ACCTSCHEMA_ID"] = 1000000;
            drNewCustAcct["AD_CLIENT_ID"] = 1000000;
            drNewCustAcct["AD_ORG_ID"] = 0;
            drNewCustAcct["CREATEDBY"] = generalResultInformation.userId;
            drNewCustAcct["UPDATEDBY"] = generalResultInformation.userId;
            drNewCustAcct["C_RECEIVABLE_ACCT"] = 1000023;
            drNewCustAcct["C_PREPAYMENT_ACCT"] = 1000025;
            drNewCustAcct["C_RECEIVABLE_SERVICES_ACCT"] = 1000024;

            dtCustomerAcctInfo.Rows.Add(drNewCustAcct);

            this.getDataFromDb.changeDataBaseTableData(dtCustomerAcctInfo, "C_BP_CUSTOMER_ACCT", "INSERT");

            //Employee Account
            DataTable dtEmployeeAcctInfo = this.getDataFromDb.getDataTableStructure("C_BP_EMPLOYEE_ACCT");
            DataRow drNewEmpAcct = dtEmployeeAcctInfo.NewRow();
            drNewEmpAcct["C_BPARTNER_ID"] = newPrimaryKey[1]; ;
            drNewEmpAcct["C_ACCTSCHEMA_ID"] = 1000000;
            drNewEmpAcct["AD_CLIENT_ID"] = 1000000;
            drNewEmpAcct["AD_ORG_ID"] = 0;
            drNewEmpAcct["CREATEDBY"] = generalResultInformation.userId;
            drNewEmpAcct["UPDATEDBY"] = generalResultInformation.userId;
            drNewEmpAcct["E_EXPENSE_ACCT"] = 1000038;
            drNewEmpAcct["E_PREPAYMENT_ACCT"] = 1000037;

            dtEmployeeAcctInfo.Rows.Add(drNewEmpAcct);

            this.getDataFromDb.changeDataBaseTableData(dtEmployeeAcctInfo, "C_BP_EMPLOYEE_ACCT", "INSERT");


            generalResultInformation.newBpartnerID = newPrimaryKey[1];
            generalResultInformation.newBpartnerName = this.txtName.Text;

            this.Close();

        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            this.txtName.Text = 
                System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(this.txtName.Text.Trim().Replace("  ", " ").ToLower());                        
        }

        

    }
}
