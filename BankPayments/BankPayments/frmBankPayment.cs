using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using dbConnection;
using System.Text.RegularExpressions;

namespace BankPayments
{
    public partial class frmBankPayment : Form
    {
        public frmBankPayment()
        {
            InitializeComponent();
        }
        

        bool currentViewIsgridView = true;
        bool isAmountAllocated = false;
        bool previousPaymentCheckNumberChanged = false;
        bool previousBankAccountChanged = false;
        
        int intCurrentPaymentRowIndex = -1;

        decimal amountAllocated = 0;

        string styleName = "";
        string stPreviousCheckNo = "";

        string stPreviousBankAcctID = "";
        string stPreviousBankAcctName = "";

        string stCurrentPaymentId = "";
        string stCurrentPayeeId = "";
        string stCurrentBankAccountId = "";

        Color clMissingFieldColor = Color.Red;
        Color clChangedFieldColor = Color.Blue;
        Color clNormalFieldColor = Color.Black;
                
        DataTable dtAllBankAccounts = new DataTable();
        DataTable dtexistingPaymentRecord = new DataTable();

        dataBuilder getDataFromDb = new dataBuilder();

        dbConnection.businessRule dbConnectionRule = new dbConnection.businessRule();


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
            this.visualStyler2.LoadVisualStyle(this.getNextInterfaceName());
            dbSettingInformationHandler.theme = this.styleName;
        }

        private string generateNextCheckNumber()
        {
            string newCheckNumber = "";

            if (this.stPreviousCheckNo == "" || this.previousPaymentCheckNumberChanged ||
                this.previousBankAccountChanged)
            {
                DataTable lastBankCheck = this.getDataFromDb.getC_BANKCHECKInfo(null, "", "", 
                                "", this.stCurrentBankAccountId, "", "", DateTime.Now, false,
                                triStateBool.Ignor, triStateBool.Ignor, true, false, false, "AND");

                if (this.getDataFromDb.checkIfTableContainesData(lastBankCheck))
                {
                    this.stPreviousCheckNo = lastBankCheck.Rows[0]["CHECKNO"].ToString();
                }
            }

            if (this.stPreviousCheckNo != "")
            {
                string[] checkNumber = 
                    this.stPreviousCheckNo.Split(new string[] { " " }, StringSplitOptions.None);
                try
                {
                    newCheckNumber = checkNumber.Length == 2 ? checkNumber[0] + " " + (int.Parse(checkNumber[1]) + 1).ToString() :
                        (int.Parse(checkNumber[0]) + 1).ToString();
                }
                catch
                {
                    newCheckNumber = this.stPreviousCheckNo;
                }
            }

            return newCheckNumber;
        }

        private bool isCheckNumberCorrectFormat()
        {
            Match match = Regex.Match(this.txtCheckNo.Text, @"^[A-Z]{0,3}\s{0,1}\d+$");
            if (match.Success)
            {
                if (!(match.Value.Equals(this.txtCheckNo.Text)))
                {
                    MessageBox.Show("Check Number Should be in the following Exact patter. {[XXX ]##########}\n" +
                        "Please check and and correct the check number entered",
                        "Bank Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Check Number Should be in the following Exact patter. {[XXX ]##########}\n" +
                        "Please check and and correct the check number entered",
                        "Bank Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Check Number  -- " + 
                                lastBankCheck.Rows[0]["CHECKNO"].ToString() + 
                                " -- is already in use on Payment number " +
                                lastBankCheck.Rows[0]["DOCUMENTNO"].ToString() +
                                " dated " + 
                                DateTime.Parse(lastBankCheck.Rows[0]["DATETRX"].ToString()).ToString("dd-MMM-yyyy") +
                                "\n Please use different check number",
                        "Bank Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            return false;

        }

        private void enableDisableToolBarIcon()
        {
            this.enableNavigationButton();
            this.enableProcessButtons();
        }

        private void enableNavigationButton()
        {
            if (this.dtgBankCheck.Rows.Count <= 1)
            {
                this.tscmdFirstRecord.Enabled = false;
                this.tscmdPreviousRecord.Enabled = false;
                this.tscmdNextRecord.Enabled = false;
                this.tscmdLastRecord.Enabled = false;
                return;
            }

            if (this.dtgBankCheck.SelectedRows[0].Index ==
                this.dtgBankCheck.Rows.Count - 1)
            {
                this.tscmdFirstRecord.Enabled = true;
                this.tscmdPreviousRecord.Enabled = true;
                this.tscmdNextRecord.Enabled = false;
                this.tscmdLastRecord.Enabled = false;
                return;
            }

            if (this.dtgBankCheck.SelectedRows[0].Index == 0)
            {
                this.tscmdFirstRecord.Enabled = false;
                this.tscmdPreviousRecord.Enabled = false;
                this.tscmdNextRecord.Enabled = true;
                this.tscmdLastRecord.Enabled = true;
                return;
            }

            this.tscmdFirstRecord.Enabled = true;
            this.tscmdPreviousRecord.Enabled = true;
            this.tscmdNextRecord.Enabled = true;
            this.tscmdLastRecord.Enabled = true;
        }

        private void enableProcessButtons()
        {
            if (this.stCurrentPaymentId == "" || this.intCurrentPaymentRowIndex == -1)
            {
                this.tscmdNew.Enabled = false;
                this.tscmdConfirm.Enabled = true;
                this.tscmdReject.Enabled = false;
                this.tscmdShowPrintPreview.Enabled = false;
                this.tscmdPrintDocument.Enabled = false;

                this.cmdIssueCheck.Enabled = false;
                this.cmdAllocate.Enabled = false;
            }
            else
            {
                this.tscmdNew.Enabled = true;
                this.tscmdConfirm.Enabled = false;
                this.tscmdReject.Enabled =
                    (this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["DOCSTATUS"].ToString() == "Cancelled") ||
                        this.ckAllocated.Checked || (
                                this.dtexistingPaymentRecord.
                            Rows[this.intCurrentPaymentRowIndex]["CREATEDBY"].
                                ToString() != generalResultInformation.userId) ? false : true;

                this.tscmdShowPrintPreview.Enabled =
                    (this.dtexistingPaymentRecord.
                            Rows[this.intCurrentPaymentRowIndex]["DOCSTATUS"].
                                ToString() == "Cancelled") || (
                                this.dtexistingPaymentRecord.
                            Rows[this.intCurrentPaymentRowIndex]["CREATEDBY"].
                                ToString() != generalResultInformation.userId)
                        ? false : true;
                this.tscmdPrintDocument.Enabled = (this.dtexistingPaymentRecord.
                            Rows[this.intCurrentPaymentRowIndex]["DOCSTATUS"].
                                ToString() == "Cancelled") || (
                                this.dtexistingPaymentRecord.
                            Rows[this.intCurrentPaymentRowIndex]["CREATEDBY"].
                                ToString() != generalResultInformation.userId)
                        ? false : true;                

                this.cmdIssueCheck.Enabled =
                    (this.dtexistingPaymentRecord.
                            Rows[this.intCurrentPaymentRowIndex]["DOCSTATUS"].
                                ToString() == "Cancelled")
                                ? false : 
                                !generalResultInformation.userprevilageIsReadOnly &&
                                !this.ckIssued.Checked;

                this.cmdAllocate.Enabled =
                    (this.dtexistingPaymentRecord.
                            Rows[this.intCurrentPaymentRowIndex]["DOCSTATUS"].
                                ToString() == "Cancelled")
                                ? false : 
                                !generalResultInformation.userprevilageIsReadOnly;
            }
        }


        private void enableDisableField(bool enable)
        {
            //this.txtDocumentNo.Enabled = enable;
            //this.dtpPayDate.Enabled = enable;
            this.ddgPayee.Enabled = enable;
            this.ntbAmount.Enabled = enable;
            this.ddgBankAccount.Enabled = enable;
            this.txtCheckNo.Enabled = enable;
            this.txtDescription.Enabled = enable;
            this.ckIsCustomer.Enabled = enable;
            this.cmdNew.Enabled = enable;
        }

        private void newRecord()
        {
            this.stCurrentBankAccountId = "";
            this.stCurrentPayeeId = "";
            this.stCurrentPaymentId = "";

            this.txtDocumentNo.Text =
                "<<" + this.getDataFromDb.getNextSequenceId("DOCUMENTNO_C_BANKCHECK", "", "", false) + ">>";
            this.dtpPayDate.Value = DateTime.Now;

            this.ddgPayee.SelectedRowKey = null;
            this.ddgPayee.SelectedRow.Clear();
            this.ddgPayee.SelectedItem = "";

            this.ntbAmount.Amount = "0";

            this.ddgBankAccount.SelectedRowKey = null;
            this.ddgBankAccount.SelectedRow.Clear();
            this.ddgBankAccount.SelectedItem = "";

            this.txtCheckNo.Text = this.generateNextCheckNumber();

            if (this.stPreviousBankAcctID == "" ||
                this.stPreviousBankAcctName == "")
            {
                DataTable lastBankCheck = this.getDataFromDb.getC_BANKCHECKInfo(null, "", "",
                            "", "", "", "", DateTime.Now, false, triStateBool.Ignor,
                            triStateBool.Ignor, true, false, false, "AND");

                if (this.getDataFromDb.checkIfTableContainesData(lastBankCheck))
                {
                    this.stPreviousBankAcctID =
                        lastBankCheck.Rows[0]["C_BANKACCOUNT_ID"].ToString();

                    lastBankCheck =
                        this.getDataFromDb.getC_BANKACCOUNTInfo(null, "", "", "",
                                this.stPreviousBankAcctID, "", "", true, false, "AND");

                    if (this.getDataFromDb.checkIfTableContainesData(lastBankCheck))
                    {
                        this.stPreviousBankAcctName =
                            lastBankCheck.Rows[0]["ACCOUNTNO"].ToString();
                    }
                    else
                    {
                        this.stPreviousBankAcctID = "";
                        this.stPreviousBankAcctName = "";
                    }
                }
            }
             
            if(this.stPreviousBankAcctName != "" && 
                this.stPreviousBankAcctID != "")
            {
                this.ddgBankAccount.SelectedItem = 
                    this.stPreviousBankAcctName;
                this.ddgBankAccount.SelectedRowKey = 
                    this.stPreviousBankAcctID;
                this.stCurrentBankAccountId =
                    this.stPreviousBankAcctID;
            }

            this.txtDescription.Text = "";

            this.ckAllocated.Checked = false;
            this.ckIssued.Checked = false;
            this.ckIsCustomer.CheckState = CheckState.Unchecked;

            this.enableDisableField(generalResultInformation.userprevilageIsReadOnly ? false : true);

            generalResultInformation.dtAllocation.Rows.Clear();
        }

        private bool isAllFieldsExistForInsertion()
        {
            bool errorFound = false;
            if (this.txtDocumentNo.Text == "")
            {
                this.lblDocumentNo.ForeColor = this.clMissingFieldColor;
                errorFound = true;
            }
            else
            { this.lblDocumentNo.ForeColor = this.clNormalFieldColor; }

            if (this.ddgPayee.SelectedRowKey == null || this.stCurrentPayeeId == "")
            {
                this.lblPayee.ForeColor = this.clMissingFieldColor;
                errorFound = true;
            }
            else
            { this.lblPayee.ForeColor = this.clNormalFieldColor; }
            

            if (this.ntbAmount.Amount == "0" || this.ntbAmount.Amount == "")
            {
                this.lblAmount.ForeColor = this.clMissingFieldColor;
                errorFound = true;
            }
            else
            { this.lblAmount.ForeColor = this.clNormalFieldColor; }

            if (this.ddgBankAccount.SelectedRowKey == null || this.stCurrentBankAccountId == "")
            {
                this.lblBankAccount.ForeColor = this.clMissingFieldColor;
                errorFound = true;
            }
            else
            { this.lblBankAccount.ForeColor = clNormalFieldColor; }


            if (this.txtCheckNo.Text == "" || !this.isCheckNumberCorrectFormat() || this.isCheckNumberUsed())
            {
                this.lblCheckNo.ForeColor = this.clMissingFieldColor;
                errorFound = true;
            }
            else
            { this.lblCheckNo.ForeColor = this.clNormalFieldColor; }
            

            return errorFound;
        }

        private bool saveNewRecord()
        {
            if (isAllFieldsExistForInsertion())
            {
                MessageBox.Show("Please Insert Required Entries Before You Proceed.",
                    "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            this.Enabled = false;

            DataTable dtNewBankCheck =
                getDataFromDb.getC_BANKCHECKInfo(null, "", "", "", "", "",
                            "", DateTime.Now, false, triStateBool.Ignor,
                            triStateBool.Ignor, false, true, "AND");

            DataRow drNewBankCheck = dtNewBankCheck.NewRow();

            drNewBankCheck["AD_ORG_ID"] = generalResultInformation.organiztionId;

            if (this.txtDocumentNo.Text.StartsWith("<<") && this.txtDocumentNo.Text.EndsWith(">>"))
            {
                drNewBankCheck["DOCUMENTNO"] = this.getDataFromDb.getNextSequenceId("DOCUMENTNO_C_BANKCHECK", "", "", true);
            }
            else 
                drNewBankCheck["DOCUMENTNO"] = this.txtDocumentNo.Text;

            drNewBankCheck["ISACTIVE"] = "Y";
            drNewBankCheck["C_BANKACCOUNT_ID"] = this.stCurrentBankAccountId;
            drNewBankCheck["CHECKNO"] = this.txtCheckNo.Text;
            drNewBankCheck["C_BPARTNER_ID"] = this.stCurrentPayeeId;
            drNewBankCheck["DATETRX"] = this.dtpPayDate.Value.ToString("dd-MMM-yyyy");
            drNewBankCheck["PAYAMT"] = decimal.Parse(this.ntbAmount.Amount);
            drNewBankCheck["DESCRIPTION"] = this.txtDescription.Text;
            drNewBankCheck["ISALLOCATED"] = "N";
            drNewBankCheck["ISISSUED"] = "N";
            drNewBankCheck["DOCSTATUS"] = "CO";

            dtNewBankCheck.Rows.Add(drNewBankCheck);

            string[] newBankCheck =
                this.getDataFromDb.changeDataBaseTableData
                            (dtNewBankCheck, "C_BANKCHECK", "INSERT");


            if (newBankCheck.Length < 1)
            {
                MessageBox.Show("Unable to record Payments. Please Try again.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            string[] newPrimaryKey = newBankCheck[0].Split(new string[] { " <(", ")>||" },
                StringSplitOptions.RemoveEmptyEntries);

            if (!newPrimaryKey.Contains(this.getDataFromDb.getTablePrimaryKey
                                            ("C_BANKCHECK")[0]))
            {
                MessageBox.Show("Unable to record Payment. Please Try again.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            this.stCurrentPaymentId = newPrimaryKey[1];

            drNewBankCheck = this.dtexistingPaymentRecord.NewRow();

            drNewBankCheck["AD_ORG_ID"] = generalResultInformation.organiztionId;
            drNewBankCheck["Organisation"] = this.txtOrganisation.Text;
            drNewBankCheck["C_BANKCHECK_ID"] = this.stCurrentPaymentId;
            drNewBankCheck["DOCUMENTNO"] = this.txtDocumentNo.Text.Replace("<<","").Replace(">>","");
            drNewBankCheck["ISACTIVE"] = "Y";
            drNewBankCheck["C_BANKACCOUNT_ID"] = this.stCurrentBankAccountId;
            drNewBankCheck["ACCOUNTNO"] = this.ddgBankAccount.SelectedItem;

            //DataTable bankAcctInfo = 
            //    this.getDataFromDb.getC_BANKACCOUNTInfo(null, "", "", "", 
            //            this.stCurrentBankAccountId, "", "", false, false, "AND");

            //if(this.getDataFromDb.checkIfTableContainesData(bankAcctInfo))
            //    drNewBankCheck["ACCOUNTNO"] = 
            //        bankAcctInfo.Rows[0]["ACCOUNTNO"].ToString();
            //else
            //    drNewBankCheck["ACCOUNTNO"] = "NA";

            drNewBankCheck["CHECKNO"] = this.txtCheckNo.Text;

            drNewBankCheck["C_BPARTNER_ID"] = this.stCurrentPayeeId;
            drNewBankCheck["Payee"] = this.ddgPayee.SelectedItem;

            //DataTable bpartnerInfo = 
            //    this.getDataFromDb.getC_BPARTNERInfo(null, "", "", 
            //            this.stCurrentPayeeId, "", triStateBool.Ignor, 
            //            triStateBool.Ignor, triStateBool.Ignor, triStateBool.Ignor, 
            //            false, false, "AND");

            //if (this.getDataFromDb.checkIfTableContainesData(bpartnerInfo))
            //    drNewBankCheck["Payee"] =
            //        bpartnerInfo.Rows[0]["NAME"].ToString();
            //else
            //    drNewBankCheck["Payee"] = "NA";


            drNewBankCheck["DATETRX"] = 
                this.dtpPayDate.Value.ToString("dd-MMM-yyyy");
            drNewBankCheck["PAYAMT"] = 
                decimal.Parse(this.ntbAmount.Amount);
            drNewBankCheck["DESCRIPTION"] = 
                this.txtDescription.Text;
            drNewBankCheck["ISALLOCATED"] = false;
            drNewBankCheck["ISISSUED"] = false;
            drNewBankCheck["DOCSTATUS"] = "COMPLETED";

            this.dtexistingPaymentRecord.Rows.Add(drNewBankCheck);

            this.dtgBankCheck.Rows[this.dtgBankCheck.Rows.Count - 1].Selected = true;

            this.dtgBankCheck_SelectionChanged(new object(), new EventArgs());

            MessageBox.Show("New payment Record saved successfully.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.stPreviousCheckNo = this.txtCheckNo.Text;

            this.Enabled = true;
            return true;
        }

        private void cancelRecord()
        {
            if (this.stCurrentPaymentId == "" || this.intCurrentPaymentRowIndex == -1)
                return;

            if (MessageBox.Show("Are you sure you want to cancell current payment.",
                    "Payments", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            
            if (this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["DOCSTATUS"].ToString() == "Cancelled")
                return;

            if (this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["ISISSUED"].ToString() == "Y")
            {
                MessageBox.Show("This payment record is issued." +
                    "\n It is not possible to cancel this record",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            DataTable dtAllocationInfo = 
                this.getDataFromDb.getC_BANKCHECKLINEInfo(null, "", "", 
                        this.stCurrentPaymentId, "", "", triStateBool.Ignor, 
                        false, false, "AND");

            if (this.getDataFromDb.checkIfTableContainesData(dtAllocationInfo))
            {
                MessageBox.Show("This payment record is already allocated." +
                   "\n It is not possible to cancel this record",
                   "Payments", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            

            DataTable dtBankCheck =
                getDataFromDb.getC_BANKCHECKInfo(null, "", this.stCurrentPaymentId, "", "", "",
                            "", DateTime.Now, false, triStateBool.Ignor,
                            triStateBool.Ignor, false, false, "AND");

            if (this.getDataFromDb.checkIfTableContainesData(dtBankCheck))
            {
                dtBankCheck.Rows[0]["DOCSTATUS"] = "VO";

                string[] newBankCheck =
                this.getDataFromDb.changeDataBaseTableData
                            (dtBankCheck, "C_BANKCHECK", "UPDATE");

                MessageBox.Show("payment Record cancelled successfully.",
                        "Payments", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["DOCSTATUS"] = "Cancelled";
            }
        }


        private void issueCheck()
        {
            if (this.stCurrentPaymentId == "" || this.intCurrentPaymentRowIndex == -1)
                return;
                        
            if (this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["DOCSTATUS"].ToString() == "Cancelled")
                return;

            if (Boolean.Parse(this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["ISISSUED"].ToString()))
            {
                MessageBox.Show("This payment record is issued.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }            

            DataTable dtBankCheck =
                getDataFromDb.getC_BANKCHECKInfo(null, "", this.stCurrentPaymentId, "", "", "",
                            "", DateTime.Now, false, triStateBool.Ignor,
                            triStateBool.Ignor, false, false, "AND");

            if (this.getDataFromDb.checkIfTableContainesData(dtBankCheck))
            {
                dtBankCheck.Rows[0]["ISISSUED"] = "Y";

                string[] newBankCheck =
                this.getDataFromDb.changeDataBaseTableData
                            (dtBankCheck, "C_BANKCHECK", "UPDATE");

                MessageBox.Show("payment Record issued successfully.",
                        "Payments", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["ISISSUED"] = true;
                this.ckIssued.Checked = true;
            }
        }


        #region "Code Used to Propagate PV to various table in Compiere"
        
        private string createChargeInvoice(string DocumentNo, string Description, string BpartnerID, 
            string BpartnerLocationID, DateTime dateInvoiced, 
            DataTable chargeInfo, decimal totalLines, decimal GrandTotal)
        {
            DataTable dtInvoice = this.getDataFromDb.getDataTableStructure("C_INVOICE");
            
            DataRow drInvoice = dtInvoice.NewRow();
            
            drInvoice["AD_CLIENT_ID"] = 1000000;
            drInvoice["AD_ORG_ID"] = generalResultInformation.organiztionId;
            drInvoice["ISACTIVE"] = "Y";
            drInvoice["CREATED"] = DateTime.Now;
            drInvoice["CREATEDBY"] = generalResultInformation.userId;
            drInvoice["UPDATED"] = DateTime.Now;
            drInvoice["UPDATEDBY"] = generalResultInformation.userId;
            drInvoice["ISSOTRX"] = "N";
            drInvoice["DOCUMENTNO"] = "PV-" + DocumentNo + "-CHRGS";
            drInvoice["DOCSTATUS"] = "CO";
            drInvoice["DOCACTION"] = "CL";
            drInvoice["PROCESSING"] = "N";
            drInvoice["PROCESSED"] = "Y";
            drInvoice["POSTED"] = "N";
            drInvoice["C_DOCTYPE_ID"] = 351000007;
            drInvoice["C_DOCTYPETARGET_ID"] = 351000007;
            drInvoice["DESCRIPTION"] = Description;
            drInvoice["ISAPPROVED"] = "Y";
            drInvoice["ISTRANSFERRED"] = "N";
            drInvoice["ISPRINTED"] = "N";
            drInvoice["SALESREP_ID"] = 1000000;
            drInvoice["DATEINVOICED"] = dateInvoiced.ToString("dd-MMM-yyyy");
            drInvoice["DATEACCT"] = dateInvoiced.ToString("dd-MMM-yyyy");
            drInvoice["C_BPARTNER_ID"] = BpartnerID;
            drInvoice["C_BPARTNER_LOCATION_ID"] = BpartnerLocationID;
            drInvoice["ISDISCOUNTPRINTED"] = "N";
            drInvoice["C_CURRENCY_ID"] = 204;
            drInvoice["PAYMENTRULE"] = "S";
            drInvoice["C_PAYMENTTERM_ID"] = 1000000;
            drInvoice["CHARGEAMT"] = 0;
            drInvoice["TOTALLINES"] = totalLines;
            drInvoice["GRANDTOTAL"] = GrandTotal;
            drInvoice["M_PRICELIST_ID"] = 351000002;
            drInvoice["ISTAXINCLUDED"] = "N";
            drInvoice["ISPAID"] = "Y";
            drInvoice["CREATEFROM"] = "N";
            drInvoice["GENERATETO"] = "N";
            drInvoice["SENDEMAIL"] = "N";
            drInvoice["COPYFROM"] = "N";
            drInvoice["ISSELFSERVICE"] = "N";
            drInvoice["C_CONVERSIONTYPE_ID"] = 114;
            drInvoice["ISPAYSCHEDULEVALID"] = "N";
            drInvoice["ISINDISPUTE"] = "N";

            dtInvoice.Rows.Add(drInvoice);

            string[] newInvoice =
                this.getDataFromDb.changeDataBaseTableData(dtInvoice, "C_INVOICE", "INSERT");

            if (newInvoice.Length < 1)
            {
                MessageBox.Show("Unable to record new Invoice. Please Try again.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }

            string[] newPrimaryKey = newInvoice[0].Split(new string[] { " <(", ")>||" },
                StringSplitOptions.RemoveEmptyEntries);

            if (!newPrimaryKey.Contains(this.getDataFromDb.getTablePrimaryKey
                                            ("C_INVOICE")[0]))
            {
                MessageBox.Show("Unable to record Invoice. Please Try again.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }

            DataTable dtInvoiceLine = this.getDataFromDb.getDataTableStructure("C_INVOICELINE");
            DataRow drInvoiceLine;

            for (int rowCounter = 0; rowCounter <= chargeInfo.Rows.Count - 1; rowCounter++)
            {
                drInvoiceLine = dtInvoiceLine.NewRow();

                drInvoiceLine["AD_CLIENT_ID"] = 1000000;
                drInvoiceLine["AD_ORG_ID"] = generalResultInformation.organiztionId;
                drInvoiceLine["ISACTIVE"] = "Y";
                drInvoiceLine["CREATED"] = DateTime.Now;
                drInvoiceLine["CREATEDBY"] = generalResultInformation.userId;
                drInvoiceLine["UPDATED"] = DateTime.Now;
                drInvoiceLine["UPDATEDBY"] = generalResultInformation.userId;
                drInvoiceLine["C_INVOICE_ID"] = newPrimaryKey[1];
                drInvoiceLine["LINE"] = (rowCounter + 1) * 10;
                drInvoiceLine["QTYINVOICED"] = 
                    1 * Math.Sign(decimal.Parse(chargeInfo.Rows[rowCounter]["AMOUNT"].ToString()));
                drInvoiceLine["PRICELIST"] = 0;
                drInvoiceLine["PRICEACTUAL"] = 
                        Math.Abs(decimal.Parse(chargeInfo.Rows[rowCounter]["AMOUNT"].ToString()));
                drInvoiceLine["PRICELIMIT"] = 0;
                drInvoiceLine["LINENETAMT"] =
                    decimal.Parse(chargeInfo.Rows[rowCounter]["AMOUNT"].ToString());
                drInvoiceLine["C_CHARGE_ID"] = 
                    chargeInfo.Rows[rowCounter]["C_CHARGE_ID"].ToString();
                drInvoiceLine["C_UOM_ID"] = 100;
                drInvoiceLine["C_TAX_ID"] = 1000001;
                drInvoiceLine["TAXAMT"] = 0;
                drInvoiceLine["M_ATTRIBUTESETINSTANCE_ID"] = 0;
                drInvoiceLine["ISDESCRIPTION"] = "N";
                drInvoiceLine["ISPRINTED"] = "Y";
                drInvoiceLine["LINETOTALAMT"] =
                    decimal.Parse(chargeInfo.Rows[rowCounter]["AMOUNT"].ToString());
                drInvoiceLine["PROCESSED"] = "Y";
                drInvoiceLine["QTYENTERED"] = drInvoiceLine["QTYINVOICED"];
                drInvoiceLine["PRICEENTERED"] = drInvoiceLine["PRICEACTUAL"];
                drInvoiceLine["RRAMT"] = 0;

                dtInvoiceLine.Rows.Add(drInvoiceLine);
            }

            string[] newInvoiceLine =
                this.getDataFromDb.changeDataBaseTableData(dtInvoiceLine, "C_INVOICELINE", "INSERT");

            if (newInvoiceLine.Length < 1)
            {
                MessageBox.Show("Unable to record new Invoice Line. Please Try again.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }


            string[] newPrimaryKey2 = newInvoiceLine[0].Split(new string[] { " <(", ")>||" },
                StringSplitOptions.RemoveEmptyEntries);

            if (!newPrimaryKey2.Contains(this.getDataFromDb.getTablePrimaryKey
                                            ("C_INVOICELINE")[0]))
            {
                MessageBox.Show("Unable to record Invoice line. Please Try again.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }



            DataTable dtbPartner =
                this.getDataFromDb.getC_BPARTNERInfo(null, "", "", BpartnerID,
                                "", triStateBool.Ignor, triStateBool.Ignor, triStateBool.Ignor,
                                triStateBool.Ignor, false, false, "AND");

            if (this.getDataFromDb.checkIfTableContainesData(dtbPartner))
            {
                dtbPartner.Rows[0]["TOTALOPENBALANCE"] =
                    decimal.Parse(dtbPartner.Rows[0]["TOTALOPENBALANCE"].ToString() == "" ? "0":
                                  dtbPartner.Rows[0]["TOTALOPENBALANCE"].ToString()) -
                                GrandTotal;

                this.getDataFromDb.changeDataBaseTableData(dtbPartner, "C_BPARTNER", "UPDATE");
            }

            return newPrimaryKey[1];
        }

        private string[] createChargeInvoice(string DocumentNo, string Description, string BpartnerID,            
            DataTable chargeInfo)
        {

            List<String> invoiceIdList = new List<String>();

            if(chargeInfo.Rows.Count <= 0)
            {
                MessageBox.Show("No invoice lines found.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return invoiceIdList.ToArray();
            }

            DataTable dtBpartnerLocation = 
                this.getDataFromDb.getC_BPARTNER_LOCATIONInfo(null, "", "", BpartnerID, "", "", false,
                    false, "AND");

            if (!this.getDataFromDb.checkIfTableContainesData(dtBpartnerLocation))
            {
                MessageBox.Show("Please Correct Address for Bpartner and Try again.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return invoiceIdList.ToArray();
            }

            string bpartnerLocationID = 
                dtBpartnerLocation.Rows[0]["C_BPARTNER_LOCATION_ID"].ToString();

            string newInvoiceID = "";
            int docCounter = 0;
            decimal totalLines = 0;
            decimal grandTotal = 0;
            DateTime chargeDate;
            DataTable chargeToInsert;
            

            do
            {
                newInvoiceID = "";
                docCounter++;
                chargeToInsert = chargeInfo.Copy();
                chargeDate = DateTime.Parse(chargeToInsert.Rows[0]["DATEINVOICED"].ToString());
                
                totalLines = 0;
                grandTotal = 0;
                
                for (int rowCounter = chargeToInsert.Rows.Count - 1; rowCounter >= 0; rowCounter--)
                {
                    if (!(DateTime.Parse(chargeToInsert.Rows[rowCounter]["DATEINVOICED"].ToString()).Equals(chargeDate)))
                        chargeToInsert.Rows.RemoveAt(rowCounter);
                    else
                    {
                        totalLines +=
                             decimal.Parse(chargeToInsert.Rows[rowCounter]["AMOUNT"].ToString());
                    }
                }

                for (int rowCounter = chargeInfo.Rows.Count - 1; rowCounter >= 0; rowCounter--)
                {
                    if ((DateTime.Parse(chargeInfo.Rows[rowCounter]["DATEINVOICED"].ToString()).Equals(chargeDate)))
                        chargeInfo.Rows.RemoveAt(rowCounter);
                }
                grandTotal = totalLines;

                newInvoiceID =
                    this.createChargeInvoice(DocumentNo + "_" + docCounter.ToString(), Description, BpartnerID,
                            bpartnerLocationID, chargeDate, chargeToInsert, totalLines, grandTotal);

                invoiceIdList.Add(newInvoiceID);

            } while (chargeInfo.Rows.Count > 0);


            return invoiceIdList.Distinct<String>().ToArray();

        }

        private void createPaymentForCashDeposit (string DocumentNo, string checkNo, DateTime trxDate,
            string BankAcct, decimal payAmount)
        {

            DataTable dtNewPayment =
                this.getDataFromDb.getC_PAYMENTInfo(null, "", "", "", "", "",
                    "", "", "", "", triStateBool.Ignor, triStateBool.Ignor, false,
                    true, "AND");

            DataRow drNewPayment = dtNewPayment.NewRow();

            drNewPayment["AD_CLIENT_ID"] = generalResultInformation.clientId;
            drNewPayment["AD_ORG_ID"] = generalResultInformation.organiztionId;
            drNewPayment["ISACTIVE"] = "Y";
            drNewPayment["CREATED"] = DateTime.Now;
            drNewPayment["CREATEDBY"] = generalResultInformation.userId;
            drNewPayment["UPDATED"] = DateTime.Now;
            drNewPayment["UPDATEDBY"] = generalResultInformation.userId;
            drNewPayment["DOCUMENTNO"] =
                checkNo != "" ? checkNo + " - PV-" + DocumentNo :
                                "PV-" + DocumentNo;
            drNewPayment["DATETRX"] = trxDate;
            drNewPayment["ISRECEIPT"] = "Y";
            drNewPayment["C_DOCTYPE_ID"] = 1000008;
            drNewPayment["TRXTYPE"] = "X";
            drNewPayment["C_BANKACCOUNT_ID"] = BankAcct;                        
            drNewPayment["TENDERTYPE"] = "X";            
            drNewPayment["C_CURRENCY_ID"] = 204;
            drNewPayment["PAYAMT"] = payAmount;
            drNewPayment["DISCOUNTAMT"] = 0;
            drNewPayment["WRITEOFFAMT"] = 0;
            drNewPayment["TAXAMT"] = 0;
            drNewPayment["ISAPPROVED"] = "N";
            drNewPayment["R_PNREF"] = DocumentNo;
            drNewPayment["R_AVSADDR"] = "X";
            drNewPayment["R_AVSZIP"] = "X";
            drNewPayment["PROCESSING"] = "N";
            drNewPayment["DOCSTATUS"] = "CL";
            drNewPayment["DOCACTION"] = "--";
            drNewPayment["ISRECONCILED"] = "N";
            drNewPayment["ISALLOCATED"] = "Y";
            drNewPayment["ISONLINE"] = "N";
            drNewPayment["PROCESSED"] = "Y";
            drNewPayment["POSTED"] = "Y";
            drNewPayment["ISOVERUNDERPAYMENT"] = "N";
            drNewPayment["OVERUNDERAMT"] = 0;
            drNewPayment["ISSELFSERVICE"] = "N";
            drNewPayment["CHARGEAMT"] = 0;
            drNewPayment["ISDELAYEDCAPTURE"] = "N";
            drNewPayment["DATEACCT"] = trxDate;
            drNewPayment["ISPREPAYMENT"] = "N";

            dtNewPayment.Rows.Add(drNewPayment);

            string[] newPayment =
                this.getDataFromDb.changeDataBaseTableData(dtNewPayment, "C_PAYMENT", "INSERT");

            if (newPayment.Length < 1)
            {
                MessageBox.Show("Unable to record new Payment. Please Try again.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] newPrimaryKey = newPayment[0].Split(new string[] { " <(", ")>||" },
                StringSplitOptions.RemoveEmptyEntries);

            if (!newPrimaryKey.Contains(this.getDataFromDb.getTablePrimaryKey
                                            ("C_PAYMENT")[0]))
            {
                MessageBox.Show("Unable to record Payment. Please Try again.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ;
            }

        }


        private string createPayment(string DocumentNo, string checkNo, string BpartnerID, DateTime trxDate,
            string BankAcct, string invoiceID, string chargeID,
            decimal payAmount, bool isReceipt, decimal OverUnder)
        {

            if (invoiceID != "" && chargeID != "")
            {

                return "";
            }

            DataTable dtNewPayment = 
                this.getDataFromDb.getC_PAYMENTInfo(null, "", "", "", "", "",
                    "", "", "", "", triStateBool.Ignor, triStateBool.Ignor, false,
                    true, "AND");

            DataRow drNewPayment = dtNewPayment.NewRow();
                        
            drNewPayment["AD_CLIENT_ID"] = generalResultInformation.clientId;
            drNewPayment["AD_ORG_ID"] = generalResultInformation.organiztionId;
            drNewPayment["ISACTIVE"] = "Y";
            drNewPayment["CREATED"] = DateTime.Now;
            drNewPayment["CREATEDBY"] = generalResultInformation.userId;
            drNewPayment["UPDATED"] = DateTime.Now;
            drNewPayment["UPDATEDBY"] = generalResultInformation.userId;
            drNewPayment["DOCUMENTNO"] = 
                checkNo != "" ? checkNo + " - PV-" + DocumentNo :
                                "PV-" + DocumentNo;
            drNewPayment["DATETRX"] = trxDate;
            drNewPayment["ISRECEIPT"] = isReceipt ? "Y" : "N";
            drNewPayment["C_DOCTYPE_ID"] = isReceipt ? 1000008 : 1000009;
            drNewPayment["TRXTYPE"] = "S";
            drNewPayment["C_BANKACCOUNT_ID"] = BankAcct;
            drNewPayment["DESCRIPTION"] = 
                checkNo != "" ? "System Generated for Check No. --" + checkNo :
                                "System Generated for PV No. --" + DocumentNo;
            drNewPayment["C_BPARTNER_ID"] = BpartnerID;
            if(invoiceID != "")
                drNewPayment["C_INVOICE_ID"] = invoiceID;
            if (chargeID != "")
                drNewPayment["C_CHARGE_ID"] = chargeID;
            drNewPayment["TENDERTYPE"] = "K";
            drNewPayment["CREDITCARDTYPE"] = "M";
            drNewPayment["CREDITCARDEXPMM"] = 1;
            drNewPayment["CREDITCARDEXPYY"] = 3;
            drNewPayment["CHECKNO"] = checkNo;
            drNewPayment["C_CURRENCY_ID"] = 204;
            drNewPayment["PAYAMT"] = payAmount;
            drNewPayment["DISCOUNTAMT"] = 0;
            drNewPayment["WRITEOFFAMT"] = 0;
            drNewPayment["TAXAMT"] = 0;
            drNewPayment["ISAPPROVED"] = "Y";
            drNewPayment["R_AVSADDR"] = "X";
            drNewPayment["R_AVSZIP"] = "X";
            drNewPayment["PROCESSING"] = "N";
            drNewPayment["OPROCESSING"] = "N";
            drNewPayment["DOCSTATUS"] = "CO";
            drNewPayment["DOCACTION"] = "CL";
            drNewPayment["ISRECONCILED"] = "N";
            drNewPayment["ISALLOCATED"] = "N";
            drNewPayment["ISONLINE"] = "N";
            drNewPayment["PROCESSED"] = "Y";
            drNewPayment["POSTED"] = "N";
            drNewPayment["ISOVERUNDERPAYMENT"] = OverUnder == 0 ? "N" : "Y";
            drNewPayment["OVERUNDERAMT"] = OverUnder;
            drNewPayment["ISSELFSERVICE"] = "N";
            drNewPayment["CHARGEAMT"] = 0;            
            drNewPayment["ISDELAYEDCAPTURE"] = "N";
            drNewPayment["R_CVV2MATCH"] = "N";
            drNewPayment["C_CONVERSIONTYPE_ID"] = 114;
            drNewPayment["DATEACCT"] = trxDate;
            drNewPayment["ISPREPAYMENT"] = "N";

            dtNewPayment.Rows.Add(drNewPayment);

            string[] newPayment =
                this.getDataFromDb.changeDataBaseTableData(dtNewPayment, "C_PAYMENT", "INSERT");

            if (newPayment.Length < 1)
            {
                MessageBox.Show("Unable to record new Payment. Please Try again.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }

            string[] newPrimaryKey = newPayment[0].Split(new string[] { " <(", ")>||" },
                StringSplitOptions.RemoveEmptyEntries);

            if (!newPrimaryKey.Contains(this.getDataFromDb.getTablePrimaryKey
                                            ("C_PAYMENT")[0]))
            {
                MessageBox.Show("Unable to record Payment. Please Try again.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }


            return newPrimaryKey[1];
        }

        private string createPayment(string DocumentNo, string checkNo, string BpartnerID, DateTime trxDate,
            string BankAcct, decimal payAmount, bool isReceipt)
        {

            if (BpartnerID == "" || BankAcct == "")
            {
                return "";
            }

            DataTable dtNewPayment =
                this.getDataFromDb.getC_PAYMENTInfo(null, "", "", "", "", "",
                    "", "", "", "", triStateBool.Ignor, triStateBool.Ignor, false,
                    true, "AND");

            DataRow drNewPayment = dtNewPayment.NewRow();

            drNewPayment["AD_CLIENT_ID"] = generalResultInformation.clientId;
            drNewPayment["AD_ORG_ID"] = generalResultInformation.organiztionId;
            drNewPayment["ISACTIVE"] = "Y";
            drNewPayment["CREATED"] = DateTime.Now;
            drNewPayment["CREATEDBY"] = generalResultInformation.userId;
            drNewPayment["UPDATED"] = DateTime.Now;
            drNewPayment["UPDATEDBY"] = generalResultInformation.userId;
            drNewPayment["DOCUMENTNO"] =
                checkNo != "" ? checkNo + " - PV-" + DocumentNo :
                                "PV-" + DocumentNo;
            drNewPayment["DATETRX"] = trxDate;
            drNewPayment["ISRECEIPT"] = isReceipt ? "Y" : "N";
            drNewPayment["C_DOCTYPE_ID"] = isReceipt ? 1000008 : 1000009;
            drNewPayment["TRXTYPE"] = "S";
            drNewPayment["C_BANKACCOUNT_ID"] = BankAcct;
            drNewPayment["DESCRIPTION"] =
                checkNo != "" ? "System Generated for Check No. --" + checkNo :
                                "System Generated for PV No. --" + DocumentNo;
            drNewPayment["C_BPARTNER_ID"] = BpartnerID;            
            drNewPayment["TENDERTYPE"] = "K";
            drNewPayment["CREDITCARDTYPE"] = "M";
            drNewPayment["CREDITCARDEXPMM"] = 1;
            drNewPayment["CREDITCARDEXPYY"] = 3;
            drNewPayment["CHECKNO"] = checkNo;
            drNewPayment["C_CURRENCY_ID"] = 204;
            drNewPayment["PAYAMT"] = payAmount;
            drNewPayment["DISCOUNTAMT"] = 0;
            drNewPayment["WRITEOFFAMT"] = 0;
            drNewPayment["TAXAMT"] = 0;
            drNewPayment["ISAPPROVED"] = "Y";
            drNewPayment["R_AVSADDR"] = "X";
            drNewPayment["R_AVSZIP"] = "X";
            drNewPayment["PROCESSING"] = "N";
            drNewPayment["OPROCESSING"] = "N";
            drNewPayment["DOCSTATUS"] = "CO";
            drNewPayment["DOCACTION"] = "CL";
            drNewPayment["ISRECONCILED"] = "N";
            drNewPayment["ISALLOCATED"] = "N";
            drNewPayment["ISONLINE"] = "N";
            drNewPayment["PROCESSED"] = "Y";
            drNewPayment["POSTED"] = "N";
            drNewPayment["ISOVERUNDERPAYMENT"] = "N";
            drNewPayment["OVERUNDERAMT"] = 0;
            drNewPayment["ISSELFSERVICE"] = "N";
            drNewPayment["CHARGEAMT"] = 0;            
            drNewPayment["ISDELAYEDCAPTURE"] = "N";
            drNewPayment["R_CVV2MATCH"] = "N";
            drNewPayment["C_CONVERSIONTYPE_ID"] = 114;
            drNewPayment["DATEACCT"] = trxDate;
            drNewPayment["ISPREPAYMENT"] = "N";

            dtNewPayment.Rows.Add(drNewPayment);

            string[] newPayment =
                this.getDataFromDb.changeDataBaseTableData(dtNewPayment, "C_PAYMENT", "INSERT");

            if (newPayment.Length < 1)
            {
                MessageBox.Show("Unable to record new Payment. Please Try again.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }

            string[] newPrimaryKey = newPayment[0].Split(new string[] { " <(", ")>||" },
                StringSplitOptions.RemoveEmptyEntries);

            if (!newPrimaryKey.Contains(this.getDataFromDb.getTablePrimaryKey
                                            ("C_PAYMENT")[0]))
            {
                MessageBox.Show("Unable to record Payment. Please Try again.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }


            return newPrimaryKey[1];
        }

        

        private void createAllocationForDoublePayments(string firstPaymentID, string secondaryPaymentID)
        {
            if (firstPaymentID == "" || secondaryPaymentID == "")
                return;

            DataTable dtPaymentInfo1 = new DataTable();
            DataTable dtPaymentInfo2 = new DataTable();

            dtPaymentInfo1 =
                    this.getDataFromDb.getC_PAYMENTInfo(null, "", "", firstPaymentID, "",
                            "", "", "", "", "", triStateBool.Ignor, triStateBool.Ignor,
                            false, false, "AND");

            decimal dcPaymentRemainingAmt1 =
                this.getDataFromDb.getPaymentRemainingAmount
                        (dtPaymentInfo1.Rows[0]["C_PAYMENT_ID"].ToString()) *
                        (dtPaymentInfo1.Rows[0]["ISRECEIPT"].ToString() == "N" ? -1 : 1);

            dtPaymentInfo2 =
                    this.getDataFromDb.getC_PAYMENTInfo(null, "", "", secondaryPaymentID, "",
                            "", "", "", "", "", triStateBool.Ignor, triStateBool.Ignor,
                            false, false, "AND");

            decimal dcPaymentRemainingAmt2 =
                this.getDataFromDb.getPaymentRemainingAmount
                        (dtPaymentInfo2.Rows[0]["C_PAYMENT_ID"].ToString()) *
                        (dtPaymentInfo2.Rows[0]["ISRECEIPT"].ToString() == "N" ? -1 : 1);

            if (Math.Abs(dcPaymentRemainingAmt1) > Math.Abs(dcPaymentRemainingAmt2))
            {
                dcPaymentRemainingAmt1 =
                    ((Math.Sign(dcPaymentRemainingAmt2)) * -1) * dcPaymentRemainingAmt2;
            }
            else if (Math.Abs(dcPaymentRemainingAmt1) < Math.Abs(dcPaymentRemainingAmt2))
            {
                dcPaymentRemainingAmt2 =
                    ((Math.Sign(dcPaymentRemainingAmt1)) * -1) * dcPaymentRemainingAmt1;
            }

            DataTable dtNewAllocationHDR =
                this.getDataFromDb.getDataTableStructure("C_ALLOCATIONHDR");

            DataRow drNewAllocationHDR = dtNewAllocationHDR.NewRow();

            drNewAllocationHDR["AD_CLIENT_ID"] = generalResultInformation.clientId;
            drNewAllocationHDR["AD_ORG_ID"] = generalResultInformation.organiztionId;
            drNewAllocationHDR["ISACTIVE"] = "Y";
            drNewAllocationHDR["CREATED"] = DateTime.Now;
            drNewAllocationHDR["CREATEDBY"] = generalResultInformation.userId;
            drNewAllocationHDR["UPDATED"] = DateTime.Now;
            drNewAllocationHDR["UPDATEDBY"] = generalResultInformation.userId;
            drNewAllocationHDR["DOCUMENTNO"] =
                this.getDataFromDb.getNextSequenceId("", "1000062", "", true);
            drNewAllocationHDR["C_CURRENCY_ID"] = 204;
            drNewAllocationHDR["APPROVALAMT"] = 0;
            drNewAllocationHDR["ISMANUAL"] = "N";
            drNewAllocationHDR["DOCSTATUS"] = "CO";
            drNewAllocationHDR["DOCACTION"] = "CL";
            drNewAllocationHDR["ISAPPROVED"] = "Y";
            drNewAllocationHDR["PROCESSING"] = "N";
            drNewAllocationHDR["PROCESSED"] = "Y";
            drNewAllocationHDR["POSTED"] = "N";

            drNewAllocationHDR["DESCRIPTION"] =
                    "Payment: " + dtPaymentInfo1.Rows[0]["DOCUMENTNO"].ToString();
            drNewAllocationHDR["DATETRX"] = dtPaymentInfo1.Rows[0]["DATETRX"];
            drNewAllocationHDR["DATEACCT"] = dtPaymentInfo1.Rows[0]["DATETRX"];

            dtNewAllocationHDR.Rows.Add(drNewAllocationHDR);

            string[] newAllocationHDR =
                this.getDataFromDb.changeDataBaseTableData(dtNewAllocationHDR, "C_ALLOCATIONHDR", "INSERT");

            if (newAllocationHDR.Length < 1)
            {
                MessageBox.Show("Unable to record new Allocation Header. Please Try again.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] newPrimaryKey = newAllocationHDR[0].Split(new string[] { " <(", ")>||" },
                StringSplitOptions.RemoveEmptyEntries);

            if (!newPrimaryKey.Contains(this.getDataFromDb.getTablePrimaryKey
                                            ("C_ALLOCATIONHDR")[0]))
            {
                MessageBox.Show("Unable to record new Allocation Header. Please Try again.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string allocationHDRID = newPrimaryKey[1];

            
            DataTable dtNewAllocationLine =
                this.getDataFromDb.getDataTableStructure("C_ALLOCATIONLINE");
            DataRow drNewAllocationLine;


            //Line for the first Payment
            drNewAllocationLine = dtNewAllocationLine.NewRow();

            drNewAllocationLine["AD_CLIENT_ID"] = generalResultInformation.clientId;
            drNewAllocationLine["AD_ORG_ID"] = generalResultInformation.organiztionId;
            drNewAllocationLine["ISACTIVE"] = "Y";
            drNewAllocationLine["CREATED"] = DateTime.Now;
            drNewAllocationLine["CREATEDBY"] = generalResultInformation.userId;
            drNewAllocationLine["UPDATED"] = DateTime.Now;
            drNewAllocationLine["UPDATEDBY"] = generalResultInformation.userId;
            drNewAllocationLine["ISMANUAL"] = "N";
            drNewAllocationLine["C_BPARTNER_ID"] =
                        dtPaymentInfo1.Rows[0]["C_BPARTNER_ID"].ToString();

            drNewAllocationLine["C_PAYMENT_ID"] = dtPaymentInfo1.Rows[0]["C_PAYMENT_ID"].ToString();
            drNewAllocationLine["OVERUNDERAMT"] = 0;
            drNewAllocationLine["AMOUNT"] = dcPaymentRemainingAmt1;

            drNewAllocationLine["DISCOUNTAMT"] = 0;
            drNewAllocationLine["WRITEOFFAMT"] = 0;
            drNewAllocationLine["POSTED"] = "N";
            drNewAllocationLine["C_ALLOCATIONHDR_ID"] = allocationHDRID;

            dtNewAllocationLine.Rows.Add(drNewAllocationLine);


            //Line for the second Payment
            drNewAllocationLine = dtNewAllocationLine.NewRow();

            drNewAllocationLine["AD_CLIENT_ID"] = generalResultInformation.clientId;
            drNewAllocationLine["AD_ORG_ID"] = generalResultInformation.organiztionId;
            drNewAllocationLine["ISACTIVE"] = "Y";
            drNewAllocationLine["CREATED"] = DateTime.Now;
            drNewAllocationLine["CREATEDBY"] = generalResultInformation.userId;
            drNewAllocationLine["UPDATED"] = DateTime.Now;
            drNewAllocationLine["UPDATEDBY"] = generalResultInformation.userId;
            drNewAllocationLine["ISMANUAL"] = "N";
            drNewAllocationLine["C_BPARTNER_ID"] =
                        dtPaymentInfo2.Rows[0]["C_BPARTNER_ID"].ToString();

            drNewAllocationLine["C_PAYMENT_ID"] = 
                dtPaymentInfo2.Rows[0]["C_PAYMENT_ID"].ToString();
            drNewAllocationLine["OVERUNDERAMT"] = 0;
            drNewAllocationLine["AMOUNT"] = dcPaymentRemainingAmt2;

            drNewAllocationLine["DISCOUNTAMT"] = 0;
            drNewAllocationLine["WRITEOFFAMT"] = 0;
            drNewAllocationLine["POSTED"] = "N";
            drNewAllocationLine["C_ALLOCATIONHDR_ID"] = allocationHDRID;

            dtNewAllocationLine.Rows.Add(drNewAllocationLine);
            

            this.getDataFromDb.changeDataBaseTableData(dtNewAllocationLine, "C_ALLOCATIONLINE", "INSERT");
            
        }

        private void createAllocation(string paymentID, string cashID)
        {
            if ((paymentID == "" && cashID == "") || (paymentID != "" && cashID != ""))
                return;

            bool isPayment = false;
            bool isPaymentAllocate = false;

            DataTable dtAllocationSourceInfo = new DataTable();
            DataTable dtAllocationSourceDetailInfo = new DataTable();
                       

            if (paymentID != "")
            {
                isPayment = true;

                dtAllocationSourceInfo =
                    this.getDataFromDb.getC_PAYMENTInfo(null, "", "", paymentID, "",
                            "", "", "", "", "", triStateBool.Ignor, triStateBool.Ignor,
                            false, false, "AND");
                
                if (!this.getDataFromDb.checkIfTableContainesData(dtAllocationSourceInfo))
                {
                    return;
                }

                if (dtAllocationSourceInfo.Rows[0]["C_CHARGE_ID"].ToString() != "")
                {
                    return;
                }

                if (dtAllocationSourceInfo.Rows[0]["C_INVOICE_ID"].ToString() == "" )
                {
                    dtAllocationSourceDetailInfo =
                        this.getDataFromDb.getC_PAYMENTALLOCATEInfo(null, "", "", 
                            paymentID, "", "", false, false, "AND");

                    if (!this.getDataFromDb.checkIfTableContainesData(dtAllocationSourceDetailInfo))
                    {
                        return;
                    }

                    isPaymentAllocate = true;
                }
            }
            else if (cashID != "")
            {
                isPayment = false;

                dtAllocationSourceInfo = 
                    this.getDataFromDb.getC_CASHInfo(null, "", "", cashID,
                            "", DateTime.Now, false, "", "", "", triStateBool.Ignor,
                            false, false, "AND");

                if (!this.getDataFromDb.checkIfTableContainesData(dtAllocationSourceInfo))
                {
                    return;
                }

                dtAllocationSourceDetailInfo =
                    this.getDataFromDb.getC_CASHLINEInfo(null, "", "", cashID, "", "", 
                            "", "", "I", triStateBool.Ignor, false, false, "AND");

                if (!this.getDataFromDb.checkIfTableContainesData(dtAllocationSourceDetailInfo))
                {
                    return;
                }
            }

            DataTable dtNewAllocationHDR =
                this.getDataFromDb.getDataTableStructure("C_ALLOCATIONHDR");

            DataRow drNewAllocationHDR = dtNewAllocationHDR.NewRow();

            drNewAllocationHDR["AD_CLIENT_ID"] = generalResultInformation.clientId;
            drNewAllocationHDR["AD_ORG_ID"] = generalResultInformation.organiztionId;
            drNewAllocationHDR["ISACTIVE"] = "Y";
            drNewAllocationHDR["CREATED"] = DateTime.Now;
            drNewAllocationHDR["CREATEDBY"] = generalResultInformation.userId;
            drNewAllocationHDR["UPDATED"] = DateTime.Now;
            drNewAllocationHDR["UPDATEDBY"] = generalResultInformation.userId;
            drNewAllocationHDR["DOCUMENTNO"] =
                this.getDataFromDb.getNextSequenceId("", "1000062", "", true);
            drNewAllocationHDR["C_CURRENCY_ID"] = 204;
            drNewAllocationHDR["APPROVALAMT"] = 0;
            drNewAllocationHDR["ISMANUAL"] = "N";
            drNewAllocationHDR["DOCSTATUS"] = "CO";
            drNewAllocationHDR["DOCACTION"] = "CL";
            drNewAllocationHDR["ISAPPROVED"] = "Y";
            drNewAllocationHDR["PROCESSING"] = "N";
            drNewAllocationHDR["PROCESSED"] = "Y";
            drNewAllocationHDR["POSTED"] = "N";


            if (isPayment)
            {
                drNewAllocationHDR["DESCRIPTION"] = 
                    "Payment: " + dtAllocationSourceInfo.Rows[0]["DOCUMENTNO"].ToString();
                drNewAllocationHDR["DATETRX"] = dtAllocationSourceInfo.Rows[0]["DATETRX"];
                drNewAllocationHDR["DATEACCT"] = dtAllocationSourceInfo.Rows[0]["DATETRX"];
            
            }
            else
            {
                drNewAllocationHDR["DESCRIPTION"] =
                    "Cash Journal: " + dtAllocationSourceInfo.Rows[0]["NAME"].ToString();
                drNewAllocationHDR["DATETRX"] = dtAllocationSourceInfo.Rows[0]["STATEMENTDATE"];
                drNewAllocationHDR["DATEACCT"] = dtAllocationSourceInfo.Rows[0]["DATEACCT"];
            
            }

            dtNewAllocationHDR.Rows.Add(drNewAllocationHDR);
            
            string[] newAllocationHDR =
                this.getDataFromDb.changeDataBaseTableData(dtNewAllocationHDR, "C_ALLOCATIONHDR", "INSERT");

            if (newAllocationHDR.Length < 1)
            {
                MessageBox.Show("Unable to record new Allocation Header. Please Try again.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] newPrimaryKey = newAllocationHDR[0].Split(new string[] { " <(", ")>||" },
                StringSplitOptions.RemoveEmptyEntries);

            if (!newPrimaryKey.Contains(this.getDataFromDb.getTablePrimaryKey
                                            ("C_ALLOCATIONHDR")[0]))
            {
                MessageBox.Show("Unable to record new Allocation Header. Please Try again.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable allocationLineInfo =
                dtAllocationSourceDetailInfo.Copy();

            if (isPayment)
            {
                if (!this.getDataFromDb.checkIfTableContainesData(allocationLineInfo))
                {                    
                    allocationLineInfo =
                        dtAllocationSourceInfo.Copy();
                }
            }

            this.createAllocationLine(newPrimaryKey[1], isPayment, isPaymentAllocate, allocationLineInfo);

        }

        private void createAllocationLine(string allocationHDRID, bool isPaymentAllocation, bool isPaymentLineAllocation,
            DataTable allocationLineInfo)
        {
            if (!this.getDataFromDb.checkIfTableContainesData(allocationLineInfo))
                return;

            DataTable dtNewAllocationLine = 
                this.getDataFromDb.getDataTableStructure("C_ALLOCATIONLINE");
            DataRow drNewAllocationLine;

            int multiplier = 1;
            DataTable dtPaymentInfo;

            foreach (DataRow dr in allocationLineInfo.Rows)
            {
                multiplier = 1;
                if (isPaymentAllocation)
                {
                    if (!isPaymentLineAllocation)
                    {
                        multiplier = dr["ISRECEIPT"].ToString() == "N" ? -1 : 1;
                    }
                    else
                    {
                        dtPaymentInfo =
                            this.getDataFromDb.getC_PAYMENTInfo(null, "", "",
                                    dr["C_PAYMENT_ID"].ToString(), "", "", "",
                                    "", "", "", triStateBool.no, triStateBool.Ignor, false, false, "AND");

                        if (this.getDataFromDb.checkIfTableContainesData(dtPaymentInfo))
                        { multiplier = -1; }
                        else
                        { multiplier = 1; }
                    }
                }

                drNewAllocationLine = dtNewAllocationLine.NewRow();
                                
                drNewAllocationLine["AD_CLIENT_ID"] = generalResultInformation.clientId;
                drNewAllocationLine["AD_ORG_ID"] = generalResultInformation.organiztionId;
                drNewAllocationLine["ISACTIVE"] = "Y";
                drNewAllocationLine["CREATED"] = DateTime.Now;
                drNewAllocationLine["CREATEDBY"] = generalResultInformation.userId;
                drNewAllocationLine["UPDATED"] = DateTime.Now;
                drNewAllocationLine["UPDATEDBY"] = generalResultInformation.userId;
                drNewAllocationLine["ISMANUAL"] = "N";
                drNewAllocationLine["C_INVOICE_ID"] = dr["C_INVOICE_ID"].ToString();

                DataTable dtInvoiceInfo =
                    this.getDataFromDb.getC_INVOICEInfo(null, "", "", dr["C_INVOICE_ID"].ToString(), 
                            "", "", "", "", "", "", "", "", triStateBool.Ignor, triStateBool.Ignor, 
                            triStateBool.Ignor, "", false, false, "AND");

                if (this.getDataFromDb.checkIfTableContainesData(dtInvoiceInfo))
                {
                    drNewAllocationLine["C_BPARTNER_ID"] = 
                        dtInvoiceInfo.Rows[0]["C_BPARTNER_ID"].ToString();

                    if (dtInvoiceInfo.Rows[0]["C_ORDER_ID"].ToString() != "")
                    {
                        drNewAllocationLine["C_ORDER_ID"] = 
                            dtInvoiceInfo.Rows[0]["C_ORDER_ID"].ToString();
                    }
                }
                if (isPaymentAllocation)
                {
                    drNewAllocationLine["C_PAYMENT_ID"] = dr["C_PAYMENT_ID"].ToString();
                    drNewAllocationLine["OVERUNDERAMT"] = 
                        decimal.Parse(dr["OVERUNDERAMT"].ToString()) * multiplier;
                    if (!isPaymentLineAllocation)
                        drNewAllocationLine["AMOUNT"] = 
                            decimal.Parse(dr["PAYAMT"].ToString()) * multiplier;
                    else
                        drNewAllocationLine["AMOUNT"] = 
                            decimal.Parse(dr["AMOUNT"].ToString()) * multiplier;
                }
                else
                {
                    drNewAllocationLine["C_CASHLINE_ID"] = dr["C_CASHLINE_ID"].ToString();
                    drNewAllocationLine["OVERUNDERAMT"] = 0;
                    drNewAllocationLine["AMOUNT"] = decimal.Parse(dr["AMOUNT"].ToString());
                }
                
                drNewAllocationLine["DISCOUNTAMT"] = 0;
                drNewAllocationLine["WRITEOFFAMT"] = 0;
                drNewAllocationLine["POSTED"] = "N";
                drNewAllocationLine["C_ALLOCATIONHDR_ID"] = allocationHDRID;

                dtNewAllocationLine.Rows.Add(drNewAllocationLine);
            }

            this.getDataFromDb.changeDataBaseTableData(dtNewAllocationLine, "C_ALLOCATIONLINE", "INSERT");

            if (isPaymentLineAllocation)
            {                
                DataTable dtAllocationInfo;

                foreach (DataRow dr in allocationLineInfo.Rows)
                {
                    dtAllocationInfo = 
                        this.getDataFromDb.getC_ALLOCATIONLINEInfo(null, "", "", "", "", "", "",
                            dr["C_PAYMENT_ID"].ToString(), "", dr["C_INVOICE_ID"].ToString(),
                            false, false, "AND");
                    if (this.getDataFromDb.checkIfTableContainesData(dtAllocationInfo))
                    {
                        dr["C_ALLOCATIONLINE_ID"] =
                            dtAllocationInfo.Rows[0]["C_ALLOCATIONLINE_ID"].ToString();
                    }
                }

                this.getDataFromDb.changeDataBaseTableData(allocationLineInfo.Copy(), "C_PAYMENTALLOCATE", "UPDATE");
            }


            DataTable dtInvoice;
            DataTable dtInvoicePaidAmount;
            DataTable dtbPartner;
            decimal amountAllocated = 0;

            foreach (DataRow dr in allocationLineInfo.Rows)
            {

                multiplier = 1;
                if (isPaymentAllocation)
                {
                    if (!isPaymentLineAllocation)
                    {
                        multiplier = dr["ISRECEIPT"].ToString() == "N" ? -1 : 1;
                    }
                    else
                    {
                        dtPaymentInfo =
                            this.getDataFromDb.getC_PAYMENTInfo(null, "", "",
                                    dr["C_PAYMENT_ID"].ToString(), "", "", "",
                                    "", "", "", triStateBool.no, triStateBool.Ignor, false, false, "AND");

                        if (this.getDataFromDb.checkIfTableContainesData(dtPaymentInfo))
                        { multiplier = -1; }
                        else
                        { multiplier = 1; }
                    }
                }

                if (isPaymentAllocation)
                {                   
                    if (!isPaymentLineAllocation)
                        amountAllocated =
                            decimal.Parse(dr["PAYAMT"].ToString()) * multiplier;
                    else
                        amountAllocated =
                            decimal.Parse(dr["AMOUNT"].ToString()) * multiplier;
                }
                else
                {
                    amountAllocated = decimal.Parse(dr["AMOUNT"].ToString());
                }


                if (dr["C_INVOICE_ID"].ToString() == "")
                {
                    continue;
                }
                dtInvoice =
                    this.getDataFromDb.getC_INVOICEInfo(null, "", "", dr["C_INVOICE_ID"].ToString(),
                                "", "", "", "", "", "", "", "", triStateBool.Ignor, triStateBool.Ignor,
                                triStateBool.Ignor, "", false, false, "AND");

                if (!this.getDataFromDb.checkIfTableContainesData(dtInvoice))
                {
                    continue;
                }

                dtInvoicePaidAmount =
                    this.getDataFromDb.getInvoicePaidAmount(dr["C_INVOICE_ID"].ToString());

                if (!this.getDataFromDb.checkIfTableContainesData(dtInvoicePaidAmount))
                {
                    goto updateBpartnerOpenBalance;
                }

                decimal paidAmount =
                    Math.Round(Math.Abs(decimal.Parse(dtInvoicePaidAmount.Rows[0][0].ToString())),2);
                decimal invoiceAmount =
                    Math.Round(Math.Abs(decimal.Parse(dtInvoice.Rows[0]["GRANDTOTAL"].ToString())),2);
                
                if (paidAmount.Equals(invoiceAmount))
                {
                    dtInvoice.Rows[0]["ISPAID"] = "Y";
                }
                else
                {
                    dtInvoice.Rows[0]["ISPAID"] = "N";
                }

                this.getDataFromDb.changeDataBaseTableData(dtInvoice, "C_INVOICE", "UPDATE");

            updateBpartnerOpenBalance:

                dtbPartner =
                        this.getDataFromDb.getC_BPARTNERInfo(null, "", "",
                                    dtInvoice.Rows[0]["C_BPARTNER_ID"].ToString(),
                                    "", triStateBool.Ignor, triStateBool.Ignor, triStateBool.Ignor,
                                    triStateBool.Ignor, false, false, "AND");

                if (!this.getDataFromDb.checkIfTableContainesData(dtbPartner))
                {
                    continue;
                }

                dtbPartner.Rows[0]["TOTALOPENBALANCE"] =
                    decimal.Parse(dtbPartner.Rows[0]["TOTALOPENBALANCE"].ToString() == "" ? "0" :
                                  dtbPartner.Rows[0]["TOTALOPENBALANCE"].ToString()) -
                    amountAllocated;

                this.getDataFromDb.changeDataBaseTableData(dtbPartner, "C_BPARTNER", "UPDATE");

            }
            
        }


        private decimal createPaymentLine(string paymentId, DataTable allocationInfo)
        {
            decimal sumAllocated = 0;

            if (!this.getDataFromDb.checkIfTableContainesData(allocationInfo))
                return sumAllocated;

            DataTable dtNewPaymentAllocation = this.getDataFromDb.getDataTableStructure("C_PAYMENTALLOCATE");
            DataRow drNewPaymenntAllocation;

            foreach (DataRow dr in allocationInfo.Rows)
            {
                sumAllocated += decimal.Parse(dr["AMOUNT"].ToString());

                drNewPaymenntAllocation = dtNewPaymentAllocation.NewRow();
                                
                drNewPaymenntAllocation["AD_CLIENT_ID"] = generalResultInformation.clientId;
                drNewPaymenntAllocation["AD_ORG_ID"] = generalResultInformation.organiztionId;
                drNewPaymenntAllocation["ISACTIVE"] = "Y";
                drNewPaymenntAllocation["CREATED"] = DateTime.Now;
                drNewPaymenntAllocation["CREATEDBY"] = generalResultInformation.userId;
                drNewPaymenntAllocation["UPDATED"] = DateTime.Now;
                drNewPaymenntAllocation["UPDATEDBY"] = generalResultInformation.userId;
                drNewPaymenntAllocation["C_PAYMENT_ID"] = paymentId;
                drNewPaymenntAllocation["C_INVOICE_ID"] = dr["C_INVOICE_ID"].ToString();
                drNewPaymenntAllocation["AMOUNT"] = decimal.Parse(dr["AMOUNT"].ToString());
                drNewPaymenntAllocation["DISCOUNTAMT"] = "0";
                drNewPaymenntAllocation["WRITEOFFAMT"] = "0";
                drNewPaymenntAllocation["OVERUNDERAMT"] = decimal.Parse(dr["OVERUNDERAMT"].ToString());
                drNewPaymenntAllocation["INVOICEAMT"] = decimal.Parse(dr["INVOICEAMT"].ToString());

                dtNewPaymentAllocation.Rows.Add(drNewPaymenntAllocation);
            }

            this.getDataFromDb.changeDataBaseTableData(dtNewPaymentAllocation, "C_PAYMENTALLOCATE", "INSERT");

            return sumAllocated;
        }

        private decimal createPaymentLine(string paymentId, List<String> invoiceList)
        {
            decimal sumAllocated = 0;

            if (invoiceList.Count<String>() <= 0)
                return sumAllocated;

            DataTable invoiceInfo;
            DataTable dtNewPaymentAllocation = this.getDataFromDb.getDataTableStructure("C_PAYMENTALLOCATE");
            DataRow drNewPaymenntAllocation;

            foreach (string invoiceID in invoiceList)
            {
                invoiceInfo =
                    this.getDataFromDb.getC_INVOICEInfo(null, "", "", invoiceID, "", "",
                            "", "", "", "", "", "", triStateBool.Ignor, triStateBool.Ignor,
                            triStateBool.Ignor, "", false, false, "AND");

                if (!this.getDataFromDb.checkIfTableContainesData(invoiceInfo))
                    continue;

                sumAllocated += decimal.Parse(invoiceInfo.Rows[0]["GRANDTOTAL"].ToString());

                drNewPaymenntAllocation = dtNewPaymentAllocation.NewRow();

                drNewPaymenntAllocation["AD_CLIENT_ID"] = generalResultInformation.clientId;
                drNewPaymenntAllocation["AD_ORG_ID"] = generalResultInformation.organiztionId;
                drNewPaymenntAllocation["ISACTIVE"] = "Y";
                drNewPaymenntAllocation["CREATED"] = DateTime.Now;
                drNewPaymenntAllocation["CREATEDBY"] = generalResultInformation.userId;
                drNewPaymenntAllocation["UPDATED"] = DateTime.Now;
                drNewPaymenntAllocation["UPDATEDBY"] = generalResultInformation.userId;
                drNewPaymenntAllocation["C_PAYMENT_ID"] = paymentId;
                drNewPaymenntAllocation["C_INVOICE_ID"] = invoiceID;
                drNewPaymenntAllocation["AMOUNT"] =
                    decimal.Parse(invoiceInfo.Rows[0]["GRANDTOTAL"].ToString());
                drNewPaymenntAllocation["DISCOUNTAMT"] = "0";
                drNewPaymenntAllocation["WRITEOFFAMT"] = "0";
                drNewPaymenntAllocation["OVERUNDERAMT"] = "0";
                drNewPaymenntAllocation["INVOICEAMT"] =
                    decimal.Parse(invoiceInfo.Rows[0]["GRANDTOTAL"].ToString());

                dtNewPaymentAllocation.Rows.Add(drNewPaymenntAllocation);
            }

            this.getDataFromDb.changeDataBaseTableData(dtNewPaymentAllocation, "C_PAYMENTALLOCATE", "INSERT");


            return sumAllocated;
        }

        
        private decimal getSumOfInvoiceGrandTotals(List<String> InvoiceList)
        {
            decimal sumOfGrandTotals = 0;
            DataTable invoiceInfo;

            foreach (string invoiceID in InvoiceList)
            {
                invoiceInfo =
                    this.getDataFromDb.getC_INVOICEInfo(null, "", "", invoiceID, 
                            "", "", "", "", "", "", "", "", triStateBool.Ignor, 
                            triStateBool.Ignor, triStateBool.Ignor, "", false, 
                            false, "AND");

                if (this.getDataFromDb.checkIfTableContainesData(invoiceInfo))
                {
                    sumOfGrandTotals +=
                        decimal.Parse(invoiceInfo.Rows[0]["GRANDTOTAL"].ToString());
                }
            }

            return sumOfGrandTotals;
        }

        private decimal getSumOfInvoiceGrandTotals(DataTable InvoiceList)
        {
            decimal sumOfGrandTotals = 0;
            DataTable invoiceInfo;

            foreach (DataRow invoiceID in InvoiceList.Rows)
            {
                invoiceInfo =
                    this.getDataFromDb.getC_INVOICEInfo(null, "", "", 
                            invoiceID["C_INVOICE_ID"].ToString(),
                            "", "", "", "", "", "", "", "", triStateBool.Ignor,
                            triStateBool.Ignor, triStateBool.Ignor, "", false,
                            false, "AND");

                if (this.getDataFromDb.checkIfTableContainesData(invoiceInfo))
                {
                    sumOfGrandTotals +=
                        decimal.Parse(invoiceInfo.Rows[0]["GRANDTOTAL"].ToString());
                }
            }

            return sumOfGrandTotals;
        }


        private string createNonCashBookPayments(string BpartnerID, string DocumentNo, string checkNo, 
            string Description, DateTime trxDate, decimal payAmount, bool isReceipt,
            string BankAcct, DataTable invoiceInfo, DataTable chargeInfo)
        {
            int chargeCount = chargeInfo.Rows.Count;
            int invoiceCount = invoiceInfo.Rows.Count;

            decimal amountInAllocation = 0;
            decimal amountInSalesAllocation = 0;

            string mainPaymentID = "";
            string salesPaymentID = "";
            
            List<String> chargeInvoiceList = new List<String>();

            DataTable dtSalesInvoices = new DataTable();

            if (invoiceCount > 0)
            {
                dtSalesInvoices = invoiceInfo.Copy();
                for (int rowCounter = dtSalesInvoices.Rows.Count - 1; rowCounter >= 0; rowCounter--)
                {
                    DataTable invInfo =
                        this.getDataFromDb.getC_INVOICEInfo(null, "", "",
                                    dtSalesInvoices.Rows[rowCounter]["C_INVOICE_ID"].ToString(), "", "", "",
                                    "", "", "", "", "", triStateBool.Ignor, triStateBool.Ignor,
                                    triStateBool.Ignor, "", false, false, "AND");

                    if (invInfo.Rows[0]["ISSOTRX"].ToString() == "N")
                        dtSalesInvoices.Rows.RemoveAt(rowCounter);
                    else
                        invoiceInfo.Rows.RemoveAt(rowCounter);
                }
            }

            invoiceCount = invoiceInfo.Rows.Count;
            int salesInvoiceCount = dtSalesInvoices.Rows.Count;

            if (chargeCount == 0 && invoiceCount == 0 && salesInvoiceCount == 0)
            {
                return mainPaymentID;
            }

            if (chargeCount > 0)
            {
                if (chargeCount > 1 ||
                    !DateTime.Parse(chargeInfo.Rows[0]["DATEINVOICED"].ToString()).Equals(trxDate) ||
                    !decimal.Parse(chargeInfo.Rows[0]["AMOUNT"].ToString()).Equals(payAmount) ||
                    invoiceCount > 0)
                {
                    //chargeInvoiceList =
                    //    this.createChargeInvoice("PV-" + this.txtDocumentNo.Text + "-CHRGS",
                    //            "System Generated for Check No. --" + this.txtCheckNo.Text,
                    //            BpartnerID, chargeInfo).ToList<String>();

                    //chargeInvoiceList =
                    //    this.createChargeInvoice(DocumentNo, Description,
                    //            BpartnerID, chargeInfo).ToList<String>();

                    //chargeInvoiceList =
                    //    this.createChargeInvoice("PV-" + DocumentNo + "-CHRGS",
                    //            Description,
                    //            BpartnerID, chargeInfo).ToList<String>();

                    chargeInvoiceList =
                        this.createChargeInvoice(DocumentNo,
                                ("System Generated for Check No. --" + checkNo + " " +  Description).Trim(),
                                BpartnerID, chargeInfo).ToList<String>();
                }
            }


            if (((chargeCount + invoiceCount + salesInvoiceCount == 1) ||
                (invoiceCount == 0 && chargeInvoiceList.Count<String>() == 1 && salesInvoiceCount == 0)) &&
                this.isAmountAllocated)
            {
                if (chargeCount > 0)
                {
                    if (chargeInvoiceList.Count<String>() > 0)
                    {
                        amountInAllocation =
                            this.getSumOfInvoiceGrandTotals(chargeInvoiceList);
                        mainPaymentID =
                            this.createPayment(DocumentNo, checkNo, BpartnerID, trxDate, BankAcct,
                                chargeInvoiceList[0], "", payAmount, isReceipt,
                                amountInAllocation - payAmount);
                    }
                    else
                    {
                        mainPaymentID =
                            this.createPayment(DocumentNo, checkNo, BpartnerID, trxDate, BankAcct,
                                        "", chargeInfo.Rows[0]["C_CHARGE_ID"].ToString(), 
                                        payAmount, isReceipt, 0);
                    }
                }
                else
                {
                    if (salesInvoiceCount == 1)
                    {
                        amountInAllocation =
                               this.getSumOfInvoiceGrandTotals(dtSalesInvoices);
                        mainPaymentID =
                            this.createPayment(DocumentNo, checkNo, BpartnerID, trxDate, BankAcct,
                                 dtSalesInvoices.Rows[0]["C_INVOICE_ID"].ToString(), "", payAmount * -1, true,
                                 amountInAllocation + payAmount);
                    }
                    else
                    {
                        amountInAllocation =
                                this.getSumOfInvoiceGrandTotals(invoiceInfo);
                        mainPaymentID =
                            this.createPayment(DocumentNo, checkNo, BpartnerID, trxDate, BankAcct,
                                 invoiceInfo.Rows[0]["C_INVOICE_ID"].ToString(), "", payAmount, isReceipt,
                                 amountInAllocation - payAmount);
                    }
                }
            }
            else if (invoiceCount <= 0 && chargeInvoiceList.Count<String>() <= 0 && this.isAmountAllocated)
            {
                mainPaymentID =
                        this.createPayment(DocumentNo, checkNo, BpartnerID, trxDate, BankAcct,
                             "", "", payAmount * -1, true, 0);

                amountInAllocation =
                    this.createPaymentLine(mainPaymentID, dtSalesInvoices);
            }
            else
            {
                if (invoiceCount <= 0 && chargeInvoiceList.Count<String>() <= 0)
                {
                    mainPaymentID =
                        this.createPayment(DocumentNo, checkNo, BpartnerID, trxDate, BankAcct,
                             "", "", payAmount * -1, true, 0);

                    amountInAllocation =
                        Math.Abs(this.createPaymentLine(mainPaymentID, dtSalesInvoices));
                }
                else
                {
                    mainPaymentID =
                            this.createPayment(DocumentNo, checkNo, BpartnerID, trxDate, BankAcct,
                                 "", "", payAmount, isReceipt, 0);

                    amountInAllocation =
                        this.createPaymentLine(mainPaymentID, invoiceInfo);

                    amountInAllocation +=
                        this.createPaymentLine(mainPaymentID, chargeInvoiceList);

                    if (salesInvoiceCount >= 1)
                    {
                        salesPaymentID =
                            this.createPayment(DocumentNo + "_S", checkNo, BpartnerID, trxDate, BankAcct,
                                 "", "", 0, true, 0);

                        amountInSalesAllocation =
                            Math.Abs(this.createPaymentLine(salesPaymentID, dtSalesInvoices));

                        this.createAllocation(salesPaymentID, "");
                    }
                }
            }

            DataTable paymentInfo =
                this.getDataFromDb.getC_PAYMENTInfo(null, "", "", mainPaymentID, "",
                        "", "", "", "", "", triStateBool.Ignor, triStateBool.Ignor,
                        false, false, "AND");
            

            if (this.getDataFromDb.checkIfTableContainesData(paymentInfo))
            {
                //string isAllocated = (amountInAllocation + 
                //        Math.Min(Math.Abs(amountInAllocation), Math.Abs(amountInSalesAllocation)) +
                //    this.getDataFromDb.getPaymentRemainingAmount(mainPaymentID)) == payAmount ? "Y" : "N";

                string isAllocated =
                    Math.Round(
                        ((Math.Abs(this.getDataFromDb.getPaymentRemainingAmount(mainPaymentID))) - 
                        (salesPaymentID != "" ?
                                Math.Abs(this.getDataFromDb.getPaymentRemainingAmount(salesPaymentID)) : 0))
                        ,2) == 0
                    ? "Y" : "N";

                paymentInfo.Rows[0]["ISALLOCATED"] = isAllocated;
                this.getDataFromDb.changeDataBaseTableData(paymentInfo, "C_PAYMENT", "UPDATE");
            }

            if (salesPaymentID != "")
            {
                paymentInfo =
                    this.getDataFromDb.getC_PAYMENTInfo(null, "", "", salesPaymentID, "",
                            "", "", "", "", "", triStateBool.Ignor, triStateBool.Ignor,
                            false, false, "AND");

                string isSalesPaymentAllocated = 
                     Math.Round(
                            (Math.Abs(this.getDataFromDb.getPaymentRemainingAmount(mainPaymentID)) -
                            Math.Abs(this.getDataFromDb.getPaymentRemainingAmount(salesPaymentID)))
                           ,2) == 0
                    ? "Y" : "N";


                if (this.getDataFromDb.checkIfTableContainesData(paymentInfo))
                {
                    paymentInfo.Rows[0]["ISALLOCATED"] = isSalesPaymentAllocated;
                    this.getDataFromDb.changeDataBaseTableData(paymentInfo, "C_PAYMENT", "UPDATE");
                }
            }

            this.createAllocation(mainPaymentID, "");

            if (salesInvoiceCount >= 1 &&
                (invoiceCount > 0 || chargeInvoiceList.Count<String>() > 0))
            {
                this.createAllocationForDoublePayments(mainPaymentID, salesPaymentID);
            }

            return mainPaymentID;            
        }
               

        private string createCash(string cashBookID, string cashBookOrg, string DocumentNo, 
            string checkNo, string Description, DateTime statementDate, decimal endingBalance)
        {

            if (DocumentNo == "" || cashBookID == "" || cashBookOrg == "")
            {
                MessageBox.Show("Missing info for payment distribution.",
                      "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return "";
            }

            DataTable dtNewCash =
                this.getDataFromDb.getC_CASHInfo(null, "", "", "", "", DateTime.Now, false,
                    "", "", "", triStateBool.Ignor, false, true, "AND");

            DataRow drNewCash = dtNewCash.NewRow();
                        
            drNewCash["AD_CLIENT_ID"] = generalResultInformation.clientId;
            drNewCash["AD_ORG_ID"] = cashBookOrg;
            drNewCash["ISACTIVE"] = "Y";
            drNewCash["CREATED"] = DateTime.Now;
            drNewCash["CREATEDBY"] = generalResultInformation.userId;
            drNewCash["UPDATED"] = DateTime.Now;
            drNewCash["UPDATEDBY"] = generalResultInformation.userId;
            drNewCash["C_CASHBOOK_ID"] = cashBookID;
            drNewCash["NAME"] = 
                checkNo != "" ? checkNo + " - PV-" + DocumentNo :
                                "PV-" + DocumentNo;
            drNewCash["DESCRIPTION"] = 
                checkNo != "" ? "System Generated for Check No. --" + checkNo + " - PV-" + DocumentNo :
                                "System Generated for PV-" + DocumentNo;
            drNewCash["STATEMENTDATE"] = DateTime.Parse(statementDate.ToString("dd-MMM-yyyy"));
            drNewCash["DATEACCT"] = DateTime.Parse(statementDate.ToString("dd-MMM-yyyy"));
            drNewCash["BEGINNINGBALANCE"] = 0;
            drNewCash["ENDINGBALANCE"] = endingBalance;
            drNewCash["STATEMENTDIFFERENCE"] = 0 + endingBalance;
            drNewCash["PROCESSING"] = "N";
            drNewCash["PROCESSED"] = "Y";
            drNewCash["POSTED"] = "N";
            drNewCash["ISAPPROVED"] = "Y";
            drNewCash["DOCSTATUS"] = "CO";
            drNewCash["DOCACTION"] = "CL";

            dtNewCash.Rows.Add(drNewCash);

            string[] newCash =
                this.getDataFromDb.changeDataBaseTableData(dtNewCash, "C_CASH", "INSERT");

            if (newCash.Length < 1)
            {
                MessageBox.Show("Unable to record new Cash. Please Try again.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }

            string[] newPrimaryKey = newCash[0].Split(new string[] { " <(", ")>||" },
                StringSplitOptions.RemoveEmptyEntries);

            if (!newPrimaryKey.Contains(this.getDataFromDb.getTablePrimaryKey
                                            ("C_CASH")[0]))
            {
                MessageBox.Show("Unable to record Cash. Please Try again.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }

            return newPrimaryKey[1];
        }

        private void createCashLine(string cashID, string cashBookOrg,
            decimal transferAmount, string BankAcct, string checkNo,
            string DocumentNo, DateTime statementDate, List<String> invoiceList,
            DataTable invoiceInfo, DataTable chargeInfo)
        {
            if (cashID == "" || cashBookOrg == "" ||
                ((transferAmount == 0) != (BankAcct == "") != (checkNo == "")) || 
                cashBookOrg == "")
            {
                MessageBox.Show("Missing info for payment distribution.",
                      "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            
            DataTable dtNewCashLine =
                this.getDataFromDb.getC_CASHLINEInfo(null, "", "", "", "",
                        "", "", "", "", triStateBool.Ignor, false, true, "AND");

            DataRow drNewCashLine;

            if (transferAmount != 0)
            { 
                drNewCashLine = dtNewCashLine.NewRow();
                                
                drNewCashLine["AD_CLIENT_ID"] = generalResultInformation.clientId;
                drNewCashLine["AD_ORG_ID"] = cashBookOrg;
                drNewCashLine["ISACTIVE"] = "Y";
                drNewCashLine["CREATED"] = DateTime.Now;
                drNewCashLine["CREATEDBY"] = generalResultInformation.userId;
                drNewCashLine["UPDATED"] = DateTime.Now;
                drNewCashLine["UPDATEDBY"] = generalResultInformation.userId;
                drNewCashLine["C_CASH_ID"] = cashID;
                drNewCashLine["LINE"] = ((dtNewCashLine.Rows.Count) + 1) * 10;
                drNewCashLine["DESCRIPTION"] = checkNo;
                drNewCashLine["CASHTYPE"] = "T";
                drNewCashLine["C_BANKACCOUNT_ID"] = BankAcct;                
                drNewCashLine["C_CURRENCY_ID"] = 204;
                drNewCashLine["AMOUNT"] = transferAmount;
                drNewCashLine["DISCOUNTAMT"] = 0;
                drNewCashLine["WRITEOFFAMT"] = 0;
                drNewCashLine["ISGENERATED"] = "N";
                drNewCashLine["PROCESSED"] = "Y";
                drNewCashLine["OVERUNDERAMT"] = 0;

                dtNewCashLine.Rows.Add(drNewCashLine);

                this.createPaymentForCashDeposit(DocumentNo, checkNo, statementDate, 
                    BankAcct, transferAmount * -1); 
            }

            foreach (DataRow dr in invoiceInfo.Rows)
            {
                drNewCashLine = dtNewCashLine.NewRow();
                                
                drNewCashLine["AD_CLIENT_ID"] = generalResultInformation.clientId;
                drNewCashLine["AD_ORG_ID"] = cashBookOrg;
                drNewCashLine["ISACTIVE"] = "Y";
                drNewCashLine["CREATED"] = DateTime.Now;
                drNewCashLine["CREATEDBY"] = generalResultInformation.userId;
                drNewCashLine["UPDATED"] = DateTime.Now;
                drNewCashLine["UPDATEDBY"] = generalResultInformation.userId;
                drNewCashLine["C_CASH_ID"] = cashID;
                drNewCashLine["LINE"] = (dtNewCashLine.Rows.Count + 1) * 10;
                drNewCashLine["DESCRIPTION"] = dr["DESCRIPTION"].ToString();
                drNewCashLine["CASHTYPE"] = "I";
                drNewCashLine["C_INVOICE_ID"] = dr["C_INVOICE_ID"].ToString();
                drNewCashLine["C_CURRENCY_ID"] = 204;
                drNewCashLine["AMOUNT"] = dr["AMOUNT"].ToString();
                drNewCashLine["DISCOUNTAMT"] = 0;
                drNewCashLine["WRITEOFFAMT"] = 0;
                drNewCashLine["ISGENERATED"] = "N";
                drNewCashLine["PROCESSED"] = "Y";
                drNewCashLine["OVERUNDERAMT"] = 0;

                dtNewCashLine.Rows.Add(drNewCashLine);
            }

            foreach (string invoice in invoiceList)
            {                
                DataTable invInfo =
                    this.getDataFromDb.getC_INVOICEInfo(null, "", "", invoice, "",
                                "", "", "", "", "", "", "", triStateBool.Ignor,
                                triStateBool.Ignor, triStateBool.Ignor, "", false,
                                false, "AND");

                if (!this.getDataFromDb.checkIfTableContainesData(invInfo))
                    continue;

                drNewCashLine = dtNewCashLine.NewRow();

                drNewCashLine["AD_CLIENT_ID"] = generalResultInformation.clientId;
                drNewCashLine["AD_ORG_ID"] = cashBookOrg;
                drNewCashLine["ISACTIVE"] = "Y";
                drNewCashLine["CREATED"] = DateTime.Now;
                drNewCashLine["CREATEDBY"] = generalResultInformation.userId;
                drNewCashLine["UPDATED"] = DateTime.Now;
                drNewCashLine["UPDATEDBY"] = generalResultInformation.userId;
                drNewCashLine["C_CASH_ID"] = cashID;
                drNewCashLine["LINE"] = (dtNewCashLine.Rows.Count + 1) * 10;
                drNewCashLine["DESCRIPTION"] = invInfo.Rows[0]["DESCRIPTION"].ToString();
                drNewCashLine["CASHTYPE"] = "I";
                drNewCashLine["C_INVOICE_ID"] = invoice;
                drNewCashLine["C_CURRENCY_ID"] = 204;
                drNewCashLine["AMOUNT"] =
                    decimal.Parse(invInfo.Rows[0]["GRANDTOTAL"].ToString()) *
                    (invInfo.Rows[0]["ISSOTRX"].ToString() == "Y" ? 1 : - 1);                
                drNewCashLine["DISCOUNTAMT"] = 0;
                drNewCashLine["WRITEOFFAMT"] = 0;
                drNewCashLine["ISGENERATED"] = "N";
                drNewCashLine["PROCESSED"] = "Y";
                drNewCashLine["OVERUNDERAMT"] = 0;

                dtNewCashLine.Rows.Add(drNewCashLine);
            }


            foreach (DataRow dr in chargeInfo.Rows)
            {
                drNewCashLine = dtNewCashLine.NewRow();

                drNewCashLine["AD_CLIENT_ID"] = generalResultInformation.clientId;
                drNewCashLine["AD_ORG_ID"] = cashBookOrg;
                drNewCashLine["ISACTIVE"] = "Y";
                drNewCashLine["CREATED"] = DateTime.Now;
                drNewCashLine["CREATEDBY"] = generalResultInformation.userId;
                drNewCashLine["UPDATED"] = DateTime.Now;
                drNewCashLine["UPDATEDBY"] = generalResultInformation.userId;
                drNewCashLine["C_CASH_ID"] = cashID;
                drNewCashLine["LINE"] = (dtNewCashLine.Rows.Count + 1) * 10;
                drNewCashLine["DESCRIPTION"] = dr["DESCRIPTION"].ToString();
                drNewCashLine["CASHTYPE"] = "C";
                drNewCashLine["C_CHARGE_ID"] = dr["C_CHARGE_ID"].ToString();
                drNewCashLine["C_CURRENCY_ID"] = 204;
                drNewCashLine["AMOUNT"] = dr["AMOUNT"].ToString();
                drNewCashLine["DISCOUNTAMT"] = 0;
                drNewCashLine["WRITEOFFAMT"] = 0;
                drNewCashLine["ISGENERATED"] = "N";
                drNewCashLine["PROCESSED"] = "Y";
                drNewCashLine["OVERUNDERAMT"] = 0;

                dtNewCashLine.Rows.Add(drNewCashLine);
            }

            string[] newCashLine =
                this.getDataFromDb.changeDataBaseTableData(dtNewCashLine, "C_CASHLINE", "INSERT");

            if (newCashLine.Length < 1)
            {
                MessageBox.Show("Unable to record new CashLine.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ;
            }

            string[] newPrimaryKey = newCashLine[0].Split(new string[] { " <(", ")>||" },
                StringSplitOptions.RemoveEmptyEntries);

            if (!newPrimaryKey.Contains(this.getDataFromDb.getTablePrimaryKey
                                            ("C_CASHLINE")[0]))
            {
                MessageBox.Show("Unable to record new CashLine.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ;
            }

        }

        private string createCashBookPayments(string BpartnerID, string DocumentNo, string checkNo, 
            string Description, DateTime statementDate, decimal transferAmount, bool isDeposit,
           string BankAcct, DataTable invoiceInfo, DataTable chargeInfo)
        {
            string mainCashID = "";

            string cashBookID = "";
            string cashBookOrg = "";

            if (BpartnerID == "")
            {
                MessageBox.Show("Buisness partner not valid for payment distribution.",
                      "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return mainCashID;
            }

            if (DocumentNo == "")
            {
                MessageBox.Show("Document Number missing for payment distribution.",
                      "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return mainCashID;
            }

            int invoiceCount = invoiceInfo.Rows.Count;
            int chargeCount = chargeInfo.Rows.Count;

            if (
                ((transferAmount == 0) != (BankAcct == "")) || 
                (invoiceCount == 0 && chargeCount == 0)
                )
            {
                MessageBox.Show("Missing info for payment distribution.",
                      "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return mainCashID;
            }

            DataTable bPratnerInfo =
                this.getDataFromDb.getC_BPARTNERInfo(null, "", "", BpartnerID, "",
                        triStateBool.Ignor, triStateBool.Ignor, triStateBool.yes,
                        triStateBool.Ignor, false, false, "AND");

            if (!this.getDataFromDb.checkIfTableContainesData(bPratnerInfo))
            {
                MessageBox.Show("Buisness partner not valid for payment distribution.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return mainCashID;
            }

            cashBookID = 
                bPratnerInfo.Rows[0]["C_CASHBOOK_ID"].ToString();

            if (cashBookID == "")
            {
                MessageBox.Show("Missing Cash Book for Buisness partner.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return mainCashID;
            }

            DataTable cashBookInfo = 
                this.getDataFromDb.getC_CASHBOOKInfo(null, "",
                        cashBookID, "", true, false, "AND");

            if (!this.getDataFromDb.checkIfTableContainesData(cashBookInfo))
            {
                MessageBox.Show("Missing Cash Book for Buisness partner.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return mainCashID;
            }

            cashBookOrg = 
                cashBookInfo.Rows[0]["AD_ORG_ID"].ToString();

            decimal chargeAmount = 0;
            decimal invoiceAmount = 0;
            decimal endingBalance = 0;

            DataTable invoiceInfo2;
            foreach (DataRow dr in invoiceInfo.Rows)
            {
                invoiceInfo2 = 
                    this.getDataFromDb.getC_INVOICEInfo(null, "", "", dr["C_INVOICE_ID"].ToString(),
                            "", "", "", "", "", "", "", "", triStateBool.Ignor, triStateBool.Ignor,
                            triStateBool.Ignor, "", false, false, "AND");

                if (!this.getDataFromDb.checkIfTableContainesData(invoiceInfo2))
                {
                    continue;
                }

                if (invoiceInfo2.Rows[0]["ISSOTRX"].ToString() == "N")
                {
                    dr["AMOUNT"] =
                        decimal.Parse(dr["AMOUNT"].ToString()) * -1;
                }

                invoiceAmount +=
                    decimal.Parse(dr["AMOUNT"].ToString());
            }

            DataTable dtDifferentDatedCharges =
                chargeInfo.Copy();
            for (int rowCounter = chargeInfo.Rows.Count - 1; rowCounter >= 0; rowCounter--)
            {
                if (!(DateTime.Parse(chargeInfo.Rows[rowCounter]
                        ["DATEINVOICED"].ToString()).Equals(statementDate)))
                {
                    chargeInfo.Rows.RemoveAt(rowCounter);
                }
            }

            for (int rowCounter = dtDifferentDatedCharges.Rows.Count - 1; rowCounter >= 0; rowCounter--)
            {
                if (DateTime.Parse(dtDifferentDatedCharges.Rows[rowCounter]
                            ["DATEINVOICED"].ToString()).Equals(statementDate))
                {
                    dtDifferentDatedCharges.Rows.RemoveAt(rowCounter);
                }
                else
                {
                    dtDifferentDatedCharges.Rows[rowCounter]["AMOUNT"] =
                        decimal.Parse(dtDifferentDatedCharges.Rows[rowCounter]["AMOUNT"].ToString()) * -1;                        
                }
            }

            List<String> invoiceList = new List<string>() {};

            if (this.getDataFromDb.checkIfTableContainesData(dtDifferentDatedCharges))
            {
                invoiceList =
                    this.createChargeInvoice(DocumentNo,
                        ("System Generated for Check No. --" + checkNo + " " + Description).Trim(),
                         BpartnerID, dtDifferentDatedCharges).ToList<String>();
            }


            foreach (DataRow dr in chargeInfo.Rows)
            {
                chargeAmount +=
                    decimal.Parse(dr["AMOUNT"].ToString());
            }

            endingBalance = transferAmount + chargeAmount + 
                invoiceAmount - (invoiceList.Count<String>() > 0 ? this.getSumOfInvoiceGrandTotals(invoiceList) : 0);

            mainCashID =
                this.createCash(cashBookID, cashBookOrg, DocumentNo, checkNo,
                    Description, statementDate, endingBalance);

            this.createCashLine(mainCashID, cashBookOrg, transferAmount, 
                    BankAcct, checkNo, DocumentNo, statementDate, invoiceList,
                    invoiceInfo, chargeInfo);

            this.createAllocation("", mainCashID);

            return mainCashID;

        }


        private string createEmptyCashBookPayments(string BpartnerID, string DocumentNo, string checkNo,
            string Description, DateTime statementDate, decimal transferAmount, bool isDeposit,
           string BankAcct)
        {
            string mainCashID = "";

            string cashBookID = "";
            string cashBookOrg = "";

            if (BpartnerID == "")
            {
                MessageBox.Show("Buisness partner not valid for payment distribution.",
                      "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return mainCashID;
            }

            if (DocumentNo == "")
            {
                MessageBox.Show("Document Number missing for payment distribution.",
                      "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return mainCashID;
            }


            if ( transferAmount == 0 || BankAcct == "" )
            {
                MessageBox.Show("Missing info for payment distribution.",
                      "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return mainCashID;
            }

            DataTable bPratnerInfo =
                this.getDataFromDb.getC_BPARTNERInfo(null, "", "", BpartnerID, "",
                        triStateBool.Ignor, triStateBool.Ignor, triStateBool.yes,
                        triStateBool.Ignor, false, false, "AND");

            if (!this.getDataFromDb.checkIfTableContainesData(bPratnerInfo))
            {
                MessageBox.Show("Buisness partner not valid for payment distribution.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return mainCashID;
            }

            cashBookID =
                bPratnerInfo.Rows[0]["C_CASHBOOK_ID"].ToString();

            if (cashBookID == "")
            {
                MessageBox.Show("Missing Cash Book for Buisness partner.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return mainCashID;
            }

            DataTable cashBookInfo =
                this.getDataFromDb.getC_CASHBOOKInfo(null, "",
                        cashBookID, "", true, false, "AND");

            if (!this.getDataFromDb.checkIfTableContainesData(cashBookInfo))
            {
                MessageBox.Show("Missing Cash Book for Buisness partner.",
                    "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return mainCashID;
            }

            cashBookOrg =
                cashBookInfo.Rows[0]["AD_ORG_ID"].ToString();
                        
            decimal endingBalance = 0;


            endingBalance = transferAmount;

            mainCashID =
                this.createCash(cashBookID, cashBookOrg, DocumentNo, checkNo,
                    Description, statementDate, endingBalance);

            this.createCashLine(mainCashID, cashBookOrg, transferAmount,
                    BankAcct, checkNo, DocumentNo, statementDate, new List<String>(),
                    new DataTable(), new DataTable());
            
            return mainCashID;

        }


        private void propagateAllocation()
        {
            if (this.stCurrentPaymentId == "" || this.stCurrentPayeeId == "")
            {
                return;
            }


            DataTable dtBpartnerInfo =
                this.getDataFromDb.getC_BPARTNERInfo(null, "", "", this.stCurrentPayeeId,
                            "", triStateBool.Ignor, triStateBool.Ignor, triStateBool.Ignor,
                            triStateBool.Ignor, false, false, "AND");

            if (!this.getDataFromDb.checkIfTableContainesData(dtBpartnerInfo))
            { 
                return;
            }

            string cashID = "";
            string paymentID = "";
            string GITcashID = "";
            string GITpaymentID = "";

            string gitBANKACCOUNTID = "351000020";

            bool bpartnerIsEmployee =
                ((dtBpartnerInfo.Rows[0]["ISEMPLOYEE"].ToString() == "Y") &&
                (dtBpartnerInfo.Rows[0]["C_CASHBOOK_ID"].ToString() != ""));

            decimal gitChargeAmount = 0;


            DataTable dtCheckLineInvoiceSet;
            DataTable dtCheckLineChargeSet;
            DataTable dtCheckLineGITChargeSet;


            DataTable dtCheckLineInfo =
                this.getDataFromDb.getC_BANKCHECKLINEInfo(null, "", "",
                        this.stCurrentPaymentId, "", "", triStateBool.Ignor,
                        true, false, "AND");


            if (!this.getDataFromDb.checkIfTableContainesData(dtCheckLineInfo))
            {
                if (bpartnerIsEmployee)
                {
                    cashID =
                        this.createEmptyCashBookPayments(this.stCurrentPayeeId, this.txtDocumentNo.Text, 
                                        this.txtCheckNo.Text, "", 
                                        DateTime.Parse(this.dtpPayDate.Value.ToString("dd-MMM-yyyy")),
                                        decimal.Parse(this.ntbAmount.Amount), false, this.stCurrentBankAccountId);
                }
                else
                {
                    paymentID =
                        this.createPayment(this.txtDocumentNo.Text, this.txtCheckNo.Text, this.stCurrentPayeeId,
                                     DateTime.Parse(this.dtpPayDate.Value.ToString("dd-MMM-yyyy")),
                                this.stCurrentBankAccountId, decimal.Parse(this.ntbAmount.Amount), false);                                
                }
            }
            else
            {
                dtCheckLineInvoiceSet = dtCheckLineInfo.Copy();
                dtCheckLineChargeSet = dtCheckLineInfo.Copy();
                dtCheckLineGITChargeSet = dtCheckLineInfo.Copy();

                for (int rowCounter = dtCheckLineInvoiceSet.Rows.Count - 1; rowCounter >= 0; rowCounter--)
                {
                    if (dtCheckLineInvoiceSet.Rows[rowCounter]["C_INVOICE_ID"].ToString() == "")
                    {
                        dtCheckLineInvoiceSet.Rows.RemoveAt(rowCounter);
                    }
                }


                for (int rowCounter = dtCheckLineChargeSet.Rows.Count - 1; rowCounter >= 0; rowCounter--)
                {
                    if (dtCheckLineChargeSet.Rows[rowCounter]["C_CHARGE_ID"].ToString() == "")
                    {
                        dtCheckLineChargeSet.Rows.RemoveAt(rowCounter);
                    }
                    else if (bpartnerIsEmployee)
                    {
                        dtCheckLineChargeSet.Rows[rowCounter]["AMOUNT"] =
                            decimal.Parse(dtCheckLineChargeSet.Rows[rowCounter]["AMOUNT"].ToString()) * -1;
                    }
                }

                for (int rowCounter = dtCheckLineGITChargeSet.Rows.Count - 1; rowCounter >= 0; rowCounter--)
                {
                    if (dtCheckLineGITChargeSet.Rows[rowCounter]["C_CHARGE_ID"].ToString() == "" ||
                        dtCheckLineGITChargeSet.Rows[rowCounter]["ISCOST"].ToString() == "N")
                    {
                        dtCheckLineGITChargeSet.Rows.RemoveAt(rowCounter);
                        continue;
                    }
                    else if (!bpartnerIsEmployee)
                    {
                        dtCheckLineGITChargeSet.Rows[rowCounter]["AMOUNT"] =
                            decimal.Parse(dtCheckLineGITChargeSet.Rows[rowCounter]["AMOUNT"].ToString()) * -1;
                    }
                    gitChargeAmount = gitChargeAmount +
                        decimal.Parse(dtCheckLineGITChargeSet.Rows[rowCounter]["AMOUNT"].ToString());
                }


                if (bpartnerIsEmployee)
                {
                    cashID =
                        this.createCashBookPayments(this.stCurrentPayeeId, this.txtDocumentNo.Text,
                            this.txtCheckNo.Text, "",
                            DateTime.Parse(this.dtpPayDate.Value.ToString("dd-MMM-yyyy")),
                                        decimal.Parse(this.ntbAmount.Amount), true, 
                                        this.stCurrentBankAccountId, dtCheckLineInvoiceSet,
                                        dtCheckLineChargeSet);
                    
                    if (this.getDataFromDb.checkIfTableContainesData(dtCheckLineGITChargeSet))
                    {
                        GITcashID =
                            this.createCashBookPayments(this.stCurrentPayeeId, this.txtDocumentNo.Text + "_GITex",
                                    this.txtCheckNo.Text, "",
                                    DateTime.Parse(this.dtpPayDate.Value.ToString("dd-MMM-yyyy")),
                                        gitChargeAmount * -1 , true, gitBANKACCOUNTID,
                                        new DataTable(), dtCheckLineGITChargeSet);
                    }
                }
                else
                {
                    paymentID =
                        this.createNonCashBookPayments(this.stCurrentPayeeId, this.txtDocumentNo.Text,
                                this.txtCheckNo.Text, "",
                                DateTime.Parse(this.dtpPayDate.Value.ToString("dd-MMM-yyyy")),
                                decimal.Parse(this.ntbAmount.Amount), false, this.stCurrentBankAccountId,
                                dtCheckLineInvoiceSet, dtCheckLineChargeSet);
                                        
                    if (this.getDataFromDb.checkIfTableContainesData(dtCheckLineGITChargeSet))
                    {
                        GITpaymentID =
                            this.createNonCashBookPayments(this.stCurrentPayeeId, this.txtDocumentNo.Text + "_GITex",
                                        this.txtCheckNo.Text, "",
                                        DateTime.Parse(this.dtpPayDate.Value.ToString("dd-MMM-yyyy")),
                                        gitChargeAmount , false, gitBANKACCOUNTID,
                                        new DataTable(), dtCheckLineGITChargeSet);
                    }
                }
            }

            DataTable checkInfo =
                this.getDataFromDb.getC_BANKCHECKInfo(null, "", this.stCurrentPaymentId,
                            "", "", "", "", DateTime.Now, false, triStateBool.Ignor, 
                            triStateBool.Ignor, false, false, "AND");

            if (this.getDataFromDb.checkIfTableContainesData(checkInfo) && (cashID != "" || paymentID != ""))
            {
                if (cashID != "")
                {
                    checkInfo.Rows[0]["C_CASH_ID"] = cashID;
                }

                if (paymentID != "")
                {
                    checkInfo.Rows[0]["C_PAYMENT_ID"] = paymentID;
                }

                this.getDataFromDb.changeDataBaseTableData(checkInfo, "C_BANKCHECK", "UPDATE");
            }

            if(GITcashID == "" && GITpaymentID == "")
                return;

            DataTable dtMatchInfo = this.getDataFromDb.getDataTableStructure("C_BANKCHECKMATCH");

            DataRow dr = dtMatchInfo.NewRow();         
            dr["AD_CLIENT_ID"] = generalResultInformation.clientId;
            dr["AD_ORG_ID"] = generalResultInformation.organiztionId;
            dr["CREATED"] = DateTime.Now;
            dr["CREATEDBY"] = generalResultInformation.userId;
            dr["UPDATED"] = DateTime.Now;
            dr["UPDATEDBY"] = generalResultInformation.userId;            
            dr["ISACTIVE"] = "Y";
            dr["C_BANKCHECK_ID"] = this.stCurrentPaymentId;

            if (GITcashID != "")
            {                       
                dr["C_CASH_ID"] = GITcashID;                
            }

            if (GITpaymentID != "")
            {                
                dr["C_PAYMENT_ID"] = GITpaymentID;                
            }
            dtMatchInfo.Rows.Add(dr);

            this.getDataFromDb.changeDataBaseTableData(dtMatchInfo, "C_BANKCHECKMATCH", "INSERT");

        }
        
        #endregion


        private void updateAllocationStatus()
        {
            if (this.stCurrentPaymentId == "" || this.intCurrentPaymentRowIndex == -1)
                return;
                        
            bool forceAllocation = false;
            this.isAmountAllocated = false;
            this.amountAllocated = 0;

            DataTable dtAllocationInfo = new DataTable();

            if(generalResultInformation.dtAllocation.Rows.Count <= 0)
                dtAllocationInfo = 
                    this.getDataFromDb.getC_BANKCHECKLINEInfo(null, "", "",
                        this.stCurrentPaymentId, "", "", triStateBool.Ignor,
                        false, false, "AND");
            else
                dtAllocationInfo = generalResultInformation.dtAllocation.Copy();

            

            DataTable invInfo = new DataTable();

            for (int rowCounter = 0; rowCounter <= dtAllocationInfo.Rows.Count - 1; rowCounter++)
            {
                if (dtAllocationInfo.Rows[rowCounter]["C_CHARGE_ID"].ToString() != "")
                {
                    amountAllocated +=
                        decimal.Parse(dtAllocationInfo.Rows[rowCounter]["AMOUNT"].ToString());
                }
                else
                {
                    invInfo =
                        this.getDataFromDb.getC_INVOICEInfo(null, "", "",
                                    dtAllocationInfo.Rows[rowCounter]["C_INVOICE_ID"].ToString(),
                                    "", "", "", "", "", "", "", "",
                                    triStateBool.Ignor, triStateBool.yes, 
                                    triStateBool.Ignor, "", false, false, "and");

                    if (!this.getDataFromDb.checkIfTableContainesData(invInfo))
                    {
                        amountAllocated +=
                            decimal.Parse(dtAllocationInfo.Rows[rowCounter]["AMOUNT"].ToString());
                    }
                    else
                    {
                        if (invInfo.Rows[0]["ISSOTRX"].ToString() == "Y")
                        {
                            amountAllocated -=
                                decimal.Parse(dtAllocationInfo.Rows[rowCounter]["AMOUNT"].ToString());
                        }
                        else
                        {
                            amountAllocated +=
                               decimal.Parse(dtAllocationInfo.Rows[rowCounter]["AMOUNT"].ToString());
                        }
                    }
                }

                    dtAllocationInfo.Rows[rowCounter]["AD_ORG_ID"] =
                        generalResultInformation.organiztionId;
            } 
                
            amountAllocated  =
                    decimal.Parse(this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["PAYAMT"].ToString()) -
                    amountAllocated;
            this.isAmountAllocated = amountAllocated == 0 ? true : false;
            
            if (!isAmountAllocated && generalResultInformation.allowAmountOverageShortage)
            {
                string over_Under = "un";
                if(Math.Sign(amountAllocated) < 0)
                    over_Under = "over";

                if (MessageBox.Show("The check has " + over_Under + 
                        " allocated amount of " + Math.Abs(amountAllocated).ToString("N02") 
                        + " birr. \n Would you like to proceed and force the allocation.",
                        "Bank check", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                            == DialogResult.Yes)
                    forceAllocation = true;
            }

        
            if (isAmountAllocated || forceAllocation)
            {
                
                DataTable dtBankCheck =
                    getDataFromDb.getC_BANKCHECKInfo(null, "", this.stCurrentPaymentId, "", "", "",
                                "", DateTime.Now, false, triStateBool.Ignor,
                                triStateBool.Ignor, false, false, "AND");

                if (!this.getDataFromDb.checkIfTableContainesData(dtBankCheck))
                {
                    MessageBox.Show("Unable to record Allocation. Please Try again.",
                        "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (this.getDataFromDb.checkIfTableContainesData(dtAllocationInfo))
                {
                    string[] newBankCheckAllocation =
                            this.getDataFromDb.changeDataBaseTableData
                                    (dtAllocationInfo, "C_BANKCHECKLINE", "INSERT");

                    string[] newRecordId = new string[(newBankCheckAllocation.Length * 2)];

                    string[] primaryKeySepartor = { " <(", ")>||" };

                    for (int arrayIndexCounter = 0;
                     arrayIndexCounter <= newBankCheckAllocation.Length - 1;
                     arrayIndexCounter++)
                    {
                        newBankCheckAllocation[arrayIndexCounter].Split(primaryKeySepartor,
                            StringSplitOptions.RemoveEmptyEntries).
                                CopyTo(newRecordId, (arrayIndexCounter * 2));
                    }

                    if (!newRecordId.Contains(this.getDataFromDb.getTablePrimaryKey
                                                ("C_BANKCHECKLINE")[0]))
                    {
                        MessageBox.Show("Unable to record Allocation. Please Try again.",
                            "Payments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                

                dtBankCheck.Rows[0]["ISALLOCATED"] = "Y";

                string[] newBankCheck =
                    this.getDataFromDb.changeDataBaseTableData
                                (dtBankCheck, "C_BANKCHECK", "UPDATE");

                MessageBox.Show("Amount has been allocated successfully.",
                        "Bank check", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["ISALLOCATED"] = true;
                this.ckAllocated.Checked = true;

                this.propagateAllocation();                
            }
        }


        private void loadSearchResultDataToExistingMainRecord()
        {
            this.dtexistingPaymentRecord.Rows.Clear();
            DataRow drExistingPayment;
            for (int rowCounter = 0;
                    rowCounter <= generalResultInformation.searchResult.Rows.Count - 1;
                    rowCounter++)
            {
                drExistingPayment = this.dtexistingPaymentRecord.NewRow();

                drExistingPayment["C_BANKCHECK_ID"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["C_BANKCHECK_ID"].ToString();
                drExistingPayment["AD_ORG_ID"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["AD_ORG_ID"].ToString();
                
                DataTable OrgInfo = this.getDataFromDb.getAD_ORGInfo(null, "",
                        generalResultInformation.searchResult.Rows[rowCounter]["AD_ORG_ID"].ToString(),
                        false, false, "AND");

                if (!this.getDataFromDb.checkIfTableContainesData(OrgInfo))
                {
                    drExistingPayment["Organisation"] = "NOT AVAILABLE";
                }
                else
                    drExistingPayment["Organisation"] = OrgInfo.Rows[0]["NAME"].ToString();

                drExistingPayment["CREATEDBY"] =
                   decimal.Parse(generalResultInformation.searchResult.Rows[rowCounter]["CREATEDBY"].ToString());
                   

                drExistingPayment["DOCUMENTNO"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["DOCUMENTNO"].ToString();
                drExistingPayment["C_BANKACCOUNT_ID"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["C_BANKACCOUNT_ID"].ToString();

                DataTable BankAccountInfo =
                    this.getDataFromDb.getC_BANKACCOUNTInfo(null, "", "", "",
                                generalResultInformation.searchResult.Rows[rowCounter]["C_BANKACCOUNT_ID"].ToString(),
                                "", "", false, false, "AND");

                if (!this.getDataFromDb.checkIfTableContainesData(BankAccountInfo))
                {
                    drExistingPayment["ACCOUNTNO"] = "NOT AVAILABLE";
                }
                else
                    drExistingPayment["ACCOUNTNO"] = BankAccountInfo.Rows[0]["ACCOUNTNO"].ToString();

                drExistingPayment["CHECKNO"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["CHECKNO"].ToString();

                drExistingPayment["C_BPARTNER_ID"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["C_BPARTNER_ID"].ToString();

                DataTable CustomerInfo = this.getDataFromDb.getC_BPARTNERInfo(null, "",
                            "", generalResultInformation.searchResult.Rows[rowCounter]["C_BPARTNER_ID"].ToString(),
                            "", triStateBool.Ignor, triStateBool.Ignor, triStateBool.Ignor, triStateBool.Ignor,
                            false, false, "AND");

                if (!this.getDataFromDb.checkIfTableContainesData(CustomerInfo))
                {
                    drExistingPayment["Payee"] = "NOT AVAILABLE";
                }
                else
                    drExistingPayment["Payee"] = CustomerInfo.Rows[0]["NAME"].ToString();

                
                
                drExistingPayment["DATETRX"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["DATETRX"].ToString();

                drExistingPayment["PAYAMT"] =
                    decimal.Parse(generalResultInformation.searchResult.Rows[rowCounter]["PAYAMT"].ToString());
                
                drExistingPayment["DESCRIPTION"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["DESCRIPTION"].ToString();
                
                drExistingPayment["ISALLOCATED"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["ISALLOCATED"].ToString() == "Y" ? true : false;
                drExistingPayment["ISISSUED"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["ISISSUED"].ToString() == "Y" ? true : false;

                drExistingPayment["DOCSTATUS"] =
                    generalResultInformation.searchResult.Rows[rowCounter]["DOCSTATUS"].ToString() == "CO" ? "Completed" : "Cancelled";
                                
                this.dtexistingPaymentRecord.Rows.Add(drExistingPayment);
            }
        }

        private void printCurrentDoc(bool previewDoc)
        {
            frmDocPrintPreview frmPrintDoc = new frmDocPrintPreview();
            frmPrintDoc.dtsDocumentPrintView.Tables["dtPaymentVoucher"].Clear();
            DataRow drdtPaymentVoucher =
                frmPrintDoc.dtsDocumentPrintView.Tables["dtPaymentVoucher"].NewRow();

            drdtPaymentVoucher["C_BANKCHECK_ID"] = this.stCurrentPaymentId;
            drdtPaymentVoucher["DOCUMENTNO"] = this.txtDocumentNo.Text;
            drdtPaymentVoucher["DATE"] = this.dtpPayDate.Value;
            drdtPaymentVoucher["PAYEE"] = this.ddgPayee.SelectedItem;
            drdtPaymentVoucher["AMOUNT"] = decimal.Parse(this.ntbAmount.Amount);
            drdtPaymentVoucher["AMOUNTINWORD"] =
                this.getDataFromDb.changeToWords(this.ntbAmount.Amount.Replace(",",""), true);
            drdtPaymentVoucher["PURPOSE"] = "";
            drdtPaymentVoucher["CHECKNO"] = this.txtCheckNo.Text;
            drdtPaymentVoucher["COMMENT"] = this.txtDescription.Text;

            DataTable dtBankInfo =
                    this.getDataFromDb.getC_BANKACCOUNTInfo(null, "", "",
                        "", this.stCurrentBankAccountId, "", "",
                        false, false, "AND");

            if (this.getDataFromDb.checkIfTableContainesData(dtBankInfo))
            {
                dtBankInfo =
                        this.getDataFromDb.getC_BANKInfo(null, "", "",
                            dtBankInfo.Rows[0]["C_BANK_ID"].ToString(), "",
                            true, false, "AND");
                if (!this.getDataFromDb.checkIfTableContainesData(dtBankInfo))
                {
                    drdtPaymentVoucher["BANK"] = "";
                }
                drdtPaymentVoucher["BANK"] =
                    dtBankInfo.Rows[0]["NAME"].ToString();
            }
            else
                drdtPaymentVoucher["BANK"] = "";
            

            drdtPaymentVoucher["ACCOUNTNO"] = this.ddgBankAccount.SelectedItem;

            drdtPaymentVoucher["BANK"] = drdtPaymentVoucher["BANK"] + " */* " +
                drdtPaymentVoucher["ACCOUNTNO"];

            DataTable dtBankCheckInfo =
                this.getDataFromDb.getC_BANKCHECKInfo(null, "", this.stCurrentPaymentId,
                            "", "", "", "", DateTime.Now, false,
                            triStateBool.Ignor, triStateBool.Ignor,
                            false, false, "AND");
            if (this.getDataFromDb.checkIfTableContainesData(dtBankCheckInfo))
            {
                DataTable userInfo =
                    this.getDataFromDb.getAD_USERInfo(null, "",
                        dtBankCheckInfo.Rows[0]["CREATEDBY"].ToString(), "",
                        "", "", false, false, "AND");

                if (this.getDataFromDb.checkIfTableContainesData(userInfo))
                {
                    string bPartnerID =
                        userInfo.Rows[0]["C_BPARTNER_ID"].ToString();

                    if (bPartnerID.Replace(" ", "") != "" &&
                        bPartnerID.Replace(" ", "") != "0")
                    {
                        userInfo =
                            this.getDataFromDb.getC_BPARTNERInfo(null, "", "",
                                    bPartnerID, "", triStateBool.Ignor, triStateBool.Ignor,
                                    triStateBool.Ignor, triStateBool.Ignor,
                                    false, false, "AND");

                        if (this.getDataFromDb.checkIfTableContainesData(userInfo))
                        {
                            drdtPaymentVoucher["PREPAREDBY"] =
                                userInfo.Rows[0]["NAME"].ToString();
                        }
                    }
                }
            }

            frmPrintDoc.dtsDocumentPrintView.Tables["dtPaymentVoucher"].Rows.Add(drdtPaymentVoucher);

            generalResultInformation.requestedPrintDocType = printDocType.paymentVoucher;
            frmPrintDoc.blPrintDocument = !previewDoc;

            frmPrintDoc.ShowDialog();
        }



        private void frmBankPayment_Load(object sender, EventArgs e)
        {
            this.visualStyler2.LoadVisualStyle(dbSettingInformationHandler.theme);
            
            this.tscmdNew_Click(sender,e);
                        
            this.dtexistingPaymentRecord =
                this.getDataFromDb.getC_BANKCHECKInfo(null, "", "", "", "", 
                        "", "", DateTime.Now, false, triStateBool.Ignor, 
                        triStateBool.Ignor, false, true, "AND");

            this.dtexistingPaymentRecord.Columns["ISALLOCATED"].DataType = 
                    Type.GetType("System.Boolean");
            this.dtexistingPaymentRecord.Columns["ISISSUED"].DataType =
                    Type.GetType("System.Boolean");

            this.dtexistingPaymentRecord.Columns.Add("Organisation");
            this.dtexistingPaymentRecord.Columns.Add("Payee");
            this.dtexistingPaymentRecord.Columns.Add("ACCOUNTNO");

            this.dtgBankCheck.DataSource =
                this.dtexistingPaymentRecord;

            this.dtgBankCheck.Columns["AD_CLIENT_ID"].Visible = false;
            this.dtgBankCheck.Columns["C_BANKCHECK_ID"].Visible = false;
            this.dtgBankCheck.Columns["AD_ORG_ID"].Visible = false;
            this.dtgBankCheck.Columns["CREATED"].Visible = false;
            this.dtgBankCheck.Columns["CREATEDBY"].Visible = false;
            this.dtgBankCheck.Columns["UPDATED"].Visible = false;
            this.dtgBankCheck.Columns["UPDATEDBY"].Visible = false;
            this.dtgBankCheck.Columns["ISACTIVE"].Visible = false;
            //this.dtgBankCheck.Columns["DESCRIPTION"].Visible = false;            
            this.dtgBankCheck.Columns["C_BPARTNER_ID"].Visible = false;
            this.dtgBankCheck.Columns["C_BANKACCOUNT_ID"].Visible = false;
            this.dtgBankCheck.Columns["C_CASH_ID"].Visible = false;
            this.dtgBankCheck.Columns["C_PAYMENT_ID"].Visible = false;

            this.dtexistingPaymentRecord.Columns["Organisation"].SetOrdinal(0);
            this.dtexistingPaymentRecord.Columns["DOCUMENTNO"].SetOrdinal(1);
            this.dtexistingPaymentRecord.Columns["DATETRX"].SetOrdinal(2);
            this.dtexistingPaymentRecord.Columns["Payee"].SetOrdinal(3);
            this.dtexistingPaymentRecord.Columns["PAYAMT"].SetOrdinal(4);
            this.dtexistingPaymentRecord.Columns["CHECKNO"].SetOrdinal(5);
            this.dtexistingPaymentRecord.Columns["ACCOUNTNO"].SetOrdinal(6);
            this.dtexistingPaymentRecord.Columns["DESCRIPTION"].SetOrdinal(7);
            this.dtexistingPaymentRecord.Columns["ISALLOCATED"].SetOrdinal(8);
            this.dtexistingPaymentRecord.Columns["ISISSUED"].SetOrdinal(9);            
            this.dtexistingPaymentRecord.Columns["DOCSTATUS"].SetOrdinal(10);

            this.dtgBankCheck.Columns["DOCUMENTNO"].HeaderText = "Document No";
            this.dtgBankCheck.Columns["DATETRX"].HeaderText = "Date";
            this.dtgBankCheck.Columns["CHECKNO"].HeaderText = "Check No";
            this.dtgBankCheck.Columns["PAYAMT"].HeaderText = "Amount";
            this.dtgBankCheck.Columns["ISALLOCATED"].HeaderText = "Allocated";
            this.dtgBankCheck.Columns["ISISSUED"].HeaderText = "Issued";
            this.dtgBankCheck.Columns["ACCOUNTNO"].HeaderText = "Account No";
            this.dtgBankCheck.Columns["DOCSTATUS"].HeaderText = "Status";
            this.dtgBankCheck.Columns["DESCRIPTION"].HeaderText = "Comment";

            //foreach (DataGridViewColumn columns in this.dtgBankCheck.Columns)
            //{
            //    columns.SortMode = DataGridViewColumnSortMode.NotSortable;
            //    columns.DisplayIndex = columns.Index;
            //}

            DataTable OrgInfo = this.getDataFromDb.getAD_ORGInfo(null, "",
                        generalResultInformation.organiztionId,
                        false, false, "AND");

            if (!this.getDataFromDb.checkIfTableContainesData(OrgInfo))
            {
                this.txtOrganisation.Text = "NOT AVAILABLE";
            }
            else
                this.txtOrganisation.Text = OrgInfo.Rows[0]["NAME"].ToString();

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

            this.mnuSettings.Visible = generalResultInformation.userCanEditSettings;
        }


        private void mnuSettings_Click(object sender, EventArgs e)
        {
            frmsettings frmDbSettings = new frmsettings();
            frmDbSettings.ShowDialog();
            MessageBox.Show("Change to setting parameter shall not take effect until you reopen this program.",
                "Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tscmdNew_Click(object sender, EventArgs e)
        {
            this.newRecord();
            this.enableDisableToolBarIcon();
        }

        private void tscmdConfirm_Click(object sender, EventArgs e)
        {
            if (this.saveNewRecord())
            {                
                this.enableDisableToolBarIcon();

                this.stPreviousBankAcctID =
                    this.stCurrentBankAccountId;

                this.stPreviousBankAcctName =
                    this.ddgBankAccount.SelectedItem;

                this.printCurrentDoc(true);
            }
        }

        private void tscmdReject_Click(object sender, EventArgs e)
        {
            this.cancelRecord();
            this.enableDisableToolBarIcon();
        }

        private void tscmdSearch_Click(object sender, EventArgs e)
        {
            frmSearchPayment newSearch = new frmSearchPayment();
            newSearch.ShowDialog(this);
            this.loadSearchResultDataToExistingMainRecord();
            if (this.dtgBankCheck.Rows.Count > 0)
                this.dtgBankCheck.Rows[0].Selected = true;
            this.dtgBankCheck_CellClick(sender, new DataGridViewCellEventArgs(0, 0));            
        }

        private void tscmdToggelView_Click(object sender, EventArgs e)
        {
            if (this.currentViewIsgridView)
            {
                this.currentViewIsgridView = false;
                this.dtgBankCheck.Size = new System.Drawing.Size(521, 300);
                this.dtgBankCheck.Visible = true;
                this.dtgBankCheck.BringToFront();
            }
            else
            {
                this.dtgBankCheck.Visible = false;
                this.dtgBankCheck.Size = new System.Drawing.Size(521, 10);
                this.currentViewIsgridView = true;
            }
        }


        private void tscmdFirstRecord_Click(object sender, EventArgs e)
        {
            generalResultInformation.dtAllocation.Rows.Clear();
            this.dtgBankCheck.Rows[0].Selected = true;
        }

        private void tscmdPreviousRecord_Click(object sender, EventArgs e)
        {
            generalResultInformation.dtAllocation.Rows.Clear();
            this.dtgBankCheck.Rows[this.intCurrentPaymentRowIndex - 1].Selected = true;
        }

        private void tscmdNextRecord_Click(object sender, EventArgs e)
        {
            generalResultInformation.dtAllocation.Rows.Clear();
            this.dtgBankCheck.Rows[this.intCurrentPaymentRowIndex + 1].Selected = true;
        }

        private void tscmdLastRecord_Click(object sender, EventArgs e)
        {
            generalResultInformation.dtAllocation.Rows.Clear();
            this.dtgBankCheck.Rows[this.dtgBankCheck.Rows.Count - 1].Selected = true;
        }


        private void tscmdShowPrintPreview_Click(object sender, EventArgs e)
        {
            this.printCurrentDoc(true);
        }

        private void tscmdPrintDocument_Click(object sender, EventArgs e)
        {
            this.printCurrentDoc(false);
        }

        private void tscmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void txtCheckNo_Leave(object sender, EventArgs e)
        {
            this.txtCheckNo.Text = 
                this.txtCheckNo.Text.Replace("  "," ").Trim().ToUpper();            
        }


        private void ddgPayee_SelectedItemClicked(object sender, EventArgs e)
        {
            DataTable dtBpartnerList =
                this.getDataFromDb.getC_BPARTNERInfo(null,"","","",
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

        private void ddgPayee_selectedItemChanged(object sender, EventArgs e)
        {
            if (this.ddgPayee.SelectedRow != null &&
                this.ddgPayee.SelectedItem != null &&
                this.ddgPayee.SelectedRow.Rows.Count > 0)
                this.stCurrentPayeeId = this.ddgPayee.SelectedRowKey.ToString();
            else
                this.stCurrentPayeeId = "";
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
            {
                this.previousBankAccountChanged = 
                    this.stCurrentBankAccountId != this.ddgBankAccount.SelectedRowKey.ToString() ? true : false;

                this.stCurrentBankAccountId =
                    this.ddgBankAccount.SelectedRowKey.ToString();

                if (this.previousBankAccountChanged)
                {
                    this.txtCheckNo.Text = this.generateNextCheckNumber();
                }                
            }
            else
            {
                this.stCurrentBankAccountId = "";
            }
        }

        

        private void dtgBankCheck_CellClick(object sender, EventArgs e)
        {
            if (this.dtgBankCheck.SelectedRows.Count < 1)
            {
                if (this.dtexistingPaymentRecord.Rows.Count <= 0)
                {
                    this.tscmdNew_Click(sender, e);                    
                }
                return;
            }

            this.intCurrentPaymentRowIndex =
                this.dtgBankCheck.SelectedRows[0].Index;

            if (this.dtexistingPaymentRecord.Rows.Count <= 0)
            {
                this.tscmdNew_Click(sender, e);
                return;
            }

            DataTable orgAccessInfo = this.getDataFromDb.getAD_USER_ORGACCESSInfo(
                    null, "",
                    this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["AD_ORG_ID"].ToString(),
                    generalResultInformation.userId, true, false, "AND");

            if (!this.getDataFromDb.checkIfTableContainesData(orgAccessInfo))
            {
                orgAccessInfo = this.getDataFromDb.getAD_USER_ORGACCESSInfo(
                            null, "",
                            generalResultInformation.allOrganisationRepresentativeKey,
                            generalResultInformation.userId, true, false, "AND");
                if (!this.getDataFromDb.checkIfTableContainesData(orgAccessInfo))
                {
                    generalResultInformation.userprevilageIsReadOnly = true;
                }
                else if (orgAccessInfo.Rows[0]["ISREADONLY"].ToString() == "Y")
                    generalResultInformation.userprevilageIsReadOnly = true;
                else
                    generalResultInformation.userprevilageIsReadOnly = false;
            }
            else if (orgAccessInfo.Rows[0]["ISREADONLY"].ToString() == "Y")
                generalResultInformation.userprevilageIsReadOnly = true;
            else
                generalResultInformation.userprevilageIsReadOnly = false;
            

            this.stCurrentBankAccountId =
                this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["C_BANKACCOUNT_ID"].ToString();

            this.stCurrentPayeeId =
                this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["C_BPARTNER_ID"].ToString();

            this.stCurrentPaymentId =
                this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["C_BANKCHECK_ID"].ToString();


            this.txtOrganisation.Text =
                this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["Organisation"].ToString();

            this.dtpPayDate.Value =
                DateTime.Parse(this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["DATETRX"].ToString());

            this.txtDocumentNo.Text =
                this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["DOCUMENTNO"].ToString();

            this.ddgPayee.SelectedRowKey =
                this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["C_BPARTNER_ID"].ToString();
            this.ddgPayee.SelectedItem =
                this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["Payee"].ToString();

            
            this.ntbAmount.Amount =
                this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["PAYAMT"].ToString();
            

            this.ddgBankAccount.SelectedRowKey =
                this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["C_BANKACCOUNT_ID"].ToString();
            this.ddgBankAccount.SelectedItem =
                this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["ACCOUNTNO"].ToString();

            
            this.txtCheckNo.Text =
                this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["CHECKNO"].ToString();
            
            
            this.txtDescription.Text =
                this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["DESCRIPTION"].ToString();

            if (Boolean.Parse(this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]
                    ["ISALLOCATED"].ToString()))
                this.ckAllocated.Checked = true;
            else
                this.ckAllocated.Checked = false;

            if (Boolean.Parse(this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]
                    ["ISISSUED"].ToString()))
                this.ckIssued.Checked = true;
            else
                this.ckIssued.Checked = false;

            this.ddgInvoice.Visible = false;

            this.enableDisableField(false);
            this.enableDisableToolBarIcon();

        }

        private void dtgBankCheck_SelectionChanged(object sender, EventArgs e)
        {
            this.dtgBankCheck_CellClick(sender, e);
        }

        private void dtgBankCheck_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dtgBankCheck_CellClick(sender, new EventArgs());
        }


        private void cmdIssueCheck_Click(object sender, EventArgs e)
        {
            if (this.stCurrentPaymentId == "" ||
                this.intCurrentPaymentRowIndex == -1)
                return;

            if (this.ckIssued.Checked)
                return;
            
            if (MessageBox.Show("Are you sure you would like to Issue this Check ",
                        "Bank check", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                            == DialogResult.No)
                return;

            this.issueCheck();
        }

        private void cmdAllocate_Click(object sender, EventArgs e)
        {
            if (this.stCurrentPaymentId == "" || 
                this.intCurrentPaymentRowIndex == -1)
                return;

            frmAllocate newAllocation = new frmAllocate();

            generalResultInformation.dtAllocation.Rows.Clear();
            generalResultInformation.allowAmountOverageShortage = false;
            
            newAllocation.stBpartnerID = this.stCurrentPayeeId;
            newAllocation.blAllocationCompleted = this.ckAllocated.Checked;
            newAllocation.stBankCheckID = this.stCurrentPaymentId;

            decimal amountAllocated = 0;

            if (generalResultInformation.dtAllocation.Rows.Count <= 0)
            {
                generalResultInformation.dtAllocation =
                    this.getDataFromDb.getC_BANKCHECKLINEInfo(null, "", "",
                            this.stCurrentPaymentId, "", "", triStateBool.Ignor,
                            false, this.stCurrentPaymentId == "" ? true : false, "AND");

                generalResultInformation.dtAllocation.Columns.Add("remove");
                generalResultInformation.dtAllocation.Columns.Add("Invoice");
                generalResultInformation.dtAllocation.Columns.Add("Charge");

                DataTable dtAllocationSourceInfo = new DataTable();


                for (int rowCounter = 0; rowCounter <= generalResultInformation.dtAllocation.Rows.Count - 1; rowCounter++)
                {
                    generalResultInformation.dtAllocation.Rows[rowCounter]["remove"] = "";
                    
                    if (generalResultInformation.dtAllocation.Rows[rowCounter]["C_INVOICE_ID"].ToString() != "")
                    {
                        dtAllocationSourceInfo =
                        this.getDataFromDb.getC_INVOICEInfo(null, "", "",
                                            generalResultInformation.dtAllocation.Rows[rowCounter]["C_INVOICE_ID"].ToString(),
                                            "", "", "", "", "", "", "", "",
                                            triStateBool.Ignor, triStateBool.Ignor,
                                            triStateBool.Ignor, "", false, false, "AND");
                        if (this.getDataFromDb.checkIfTableContainesData(dtAllocationSourceInfo))
                        {
                            generalResultInformation.dtAllocation.Rows[rowCounter]["Invoice"] =
                               dtAllocationSourceInfo.Rows[0]["DOCUMENTNO"].ToString();

                            if (dtAllocationSourceInfo.Rows[0]["ISSOTRX"].ToString() == "Y")
                            {
                                amountAllocated -=
                                    decimal.Parse(generalResultInformation.dtAllocation.
                                        Rows[rowCounter]["AMOUNT"].ToString());
                            }
                            else
                            {
                                amountAllocated +=
                                    decimal.Parse(generalResultInformation.dtAllocation.
                                        Rows[rowCounter]["AMOUNT"].ToString());
                            }
                        }
                        else
                        {
                            amountAllocated +=
                                decimal.Parse(generalResultInformation.dtAllocation.
                                            Rows[rowCounter]["AMOUNT"].ToString());
                        }
                    }
                    else if (generalResultInformation.dtAllocation.Rows[rowCounter]["C_CHARGE_ID"].ToString() != "")
                    {
                        dtAllocationSourceInfo =
                            this.getDataFromDb.getC_CHARGEInfo(null, "", "",
                                        generalResultInformation.dtAllocation.Rows[rowCounter]["C_CHARGE_ID"].ToString(),
                                        "", false, false, "AND");

                        if (this.getDataFromDb.checkIfTableContainesData(dtAllocationSourceInfo))
                        {
                            generalResultInformation.dtAllocation.Rows[rowCounter]["Charge"] =
                                dtAllocationSourceInfo.Rows[0]["NAME"].ToString();
                        }

                        amountAllocated +=
                            decimal.Parse(generalResultInformation.dtAllocation.
                                        Rows[rowCounter]["AMOUNT"].ToString());
                    }
                }
            }
            else
            {
                for (int rowCounter = 0; rowCounter <= generalResultInformation.dtAllocation.Rows.Count - 1; rowCounter++)
                {                 
                    amountAllocated +=
                        decimal.Parse(generalResultInformation.dtAllocation.
                                        Rows[rowCounter]["AMOUNT"].ToString());
                }
            }


            newAllocation.dcTotalAmtToAllocate =
                decimal.Parse(this.ntbAmount.Amount) - amountAllocated;

            newAllocation.ShowDialog();

            if (this.ckAllocated.Checked)
                return;

            if (MessageBox.Show("Are you sure you would like to finish allocation for this Check ",
                        "Bank check", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                            == DialogResult.No)
                return;
            
            this.updateAllocationStatus();
        }



        private void label1_DoubleClick(object sender, EventArgs e)
        {
            this.changeUserInterface();
        }

        private void frmBankPayment_FormClosing(object sender, FormClosingEventArgs e)
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
                        this.dbConnectionRule.readEncryptedXmlSettingFile(settingFile);
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
                    this.dbConnectionRule.writeDatatableToEncryptedXmlSettingFile(dtSettingsTable, settingFile);
                }
                catch
                {
                }
            }
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            this.ddgPayee.SelectedRowKey = null;
            this.ddgPayee.SelectedRow.Rows.Clear();
            this.ddgPayee.SelectedItem = "";

            this.ddgPayee_selectedItemChanged(sender, e);

            generalResultInformation.newBpartnerID = "";
            generalResultInformation.newBpartnerName = "";

            frmNewBpartner frmNewPartner = new frmNewBpartner();
            frmNewPartner.ShowDialog();

            if(generalResultInformation.newBpartnerID != "")
            {
                this.ddgPayee.SelectedRowKey = generalResultInformation.newBpartnerID;
                this.ddgPayee.SelectedItem = generalResultInformation.newBpartnerName;

                this.stCurrentPayeeId = generalResultInformation.newBpartnerID;
            }

        }

        private void dtgBankCheck_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string colName = dtgBankCheck.Columns[e.ColumnIndex].Name;
            DataView dtView = this.dtexistingPaymentRecord.DefaultView;

            if (dtgBankCheck.SortOrder == SortOrder.Ascending)
            {
                dtView.Sort = colName + " ASC";
            }
            else
            {
                dtView.Sort = colName + " DESC";
            }

            this.dtexistingPaymentRecord = dtView.ToTable();

            this.dtgBankCheck_SelectionChanged(sender, new EventArgs());
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

                this.stCurrentPayeeId = 
                    this.ddgInvoice.SelectedRow.Rows[0]["C_BPARTNER_ID"].ToString();
            }
            else
            {
                this.ddgPayee.SelectedRowKey = null;
                this.ddgPayee.SelectedRow.Rows.Clear();
                this.ddgPayee.SelectedItem = "";
            }
        }



        private void processPaymentRecordModification(changeType changeType)
        {
            if (this.stCurrentPaymentId == "")
                return;

            if (this.ckAllocated.Checked)
                return;

            if (this.dtexistingPaymentRecord.
                            Rows[this.intCurrentPaymentRowIndex]["CREATEDBY"].
                                ToString() != generalResultInformation.userId)
                return;

            frmModifiedBankAccount frmModifyAcct = new frmModifiedBankAccount();

            frmModifyAcct.change = changeType;

            frmModifyAcct.stPaymentID = this.stCurrentPayeeId;
            frmModifyAcct.stPayeeName = this.ddgPayee.SelectedItem;

            frmModifyAcct.dcAmount = decimal.Parse(this.ntbAmount.Amount);

            frmModifyAcct.stBankAccountID = this.stCurrentBankAccountId;
            frmModifyAcct.stBankAccountNumber = this.ddgBankAccount.SelectedItem;
            
            frmModifyAcct.stCheckNumber = this.txtCheckNo.Text;

            frmModifyAcct.stDescription = this.txtDescription.Text;

            frmModifyAcct.stDocumentNumber = this.txtDocumentNo.Text;
            frmModifyAcct.stPaymentID = this.stCurrentPaymentId;
            
            frmModifyAcct.ShowDialog();
            

            DataTable paymentInfo =
               this.getDataFromDb.getC_BANKCHECKInfo(null, "", this.stCurrentPaymentId, "", "",
                       "", "", DateTime.Now, false, triStateBool.no, triStateBool.Ignor,
                       false, false, "AND");

            if (this.getDataFromDb.checkIfTableContainesData(paymentInfo))
            {

                if (changeType == changeType.Bank)
                {
                    this.stPreviousBankAcctID = "";

                    this.stCurrentBankAccountId =
                        paymentInfo.Rows[0]["C_BANKACCOUNT_ID"].ToString();

                    this.ddgBankAccount.SelectedRowKey =
                        paymentInfo.Rows[0]["C_BANKACCOUNT_ID"].ToString();

                    this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["C_BANKACCOUNT_ID"] =
                        paymentInfo.Rows[0]["C_BANKACCOUNT_ID"].ToString();

                    DataTable accountInfo =
                       this.getDataFromDb.getC_BANKACCOUNTInfo(null, "", "", "",
                                   this.stCurrentBankAccountId, "", "", false, false, "AND");

                    if (this.getDataFromDb.checkIfTableContainesData(accountInfo))
                    {
                        this.ddgBankAccount.SelectedItem =
                               accountInfo.Rows[0]["ACCOUNTNO"].ToString();
                        this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["ACCOUNTNO"] =
                            accountInfo.Rows[0]["ACCOUNTNO"].ToString();
                    }
                }
                else if(changeType == changeType.Check)
                {
                    this.txtCheckNo.Text =
                        paymentInfo.Rows[0]["CHECKNO"].ToString();

                    this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["CHECKNO"] =
                        paymentInfo.Rows[0]["CHECKNO"].ToString();
                }
                else if (changeType == changeType.Payee)
                {
                    this.stCurrentPayeeId =
                        paymentInfo.Rows[0]["C_BPARTNER_ID"].ToString();

                    this.ddgPayee.SelectedRowKey =
                        paymentInfo.Rows[0]["C_BPARTNER_ID"].ToString();

                    this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["C_BPARTNER_ID"] =
                        paymentInfo.Rows[0]["C_BPARTNER_ID"].ToString();

                    DataTable payeeInfo =
                       this.getDataFromDb.getC_BPARTNERInfo(null, "", "", this.stCurrentPayeeId, "",
                                    triStateBool.Ignor, triStateBool.Ignor,
                                    triStateBool.Ignor, triStateBool.Ignor,
                                    false, false, "AND");

                    if (this.getDataFromDb.checkIfTableContainesData(payeeInfo))
                    {
                        this.ddgPayee.SelectedItem =
                               payeeInfo.Rows[0]["NAME"].ToString();
                        this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["PAYEE"] =
                            payeeInfo.Rows[0]["NAME"].ToString();
                    }
                }
                else if (changeType == changeType.Amount)
                {
                    this.ntbAmount.Amount =
                        paymentInfo.Rows[0]["PAYAMT"].ToString();

                    this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["PAYAMT"] =
                        paymentInfo.Rows[0]["PAYAMT"].ToString();
                }
                else if (changeType == changeType.Description)
                {
                    this.txtDescription.Text =
                        paymentInfo.Rows[0]["DESCRIPTION"].ToString();

                    this.dtexistingPaymentRecord.Rows[this.intCurrentPaymentRowIndex]["DESCRIPTION"] =
                        paymentInfo.Rows[0]["DESCRIPTION"].ToString();
                }
            }

            if (changeType == changeType.Bank || changeType == changeType.Check)
            { 
                this.previousPaymentCheckNumberChanged = true; 
            }
        }

        private void lblCheckNo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.processPaymentRecordModification(changeType.Check);            
        }

        private void lblBankAccount_MouseDoubleClick(object sender, MouseEventArgs e)
        {           
            this.processPaymentRecordModification(changeType.Bank);
        }

        private void lblPayee_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.processPaymentRecordModification(changeType.Payee);
        }

        private void lblAmount_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.processPaymentRecordModification(changeType.Amount);
        }

        private void lblDescription_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.processPaymentRecordModification(changeType.Description);
        }


    }


}
