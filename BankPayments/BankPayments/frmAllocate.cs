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
    public partial class frmAllocate : Form
    {
        public frmAllocate()
        {
            InitializeComponent();
        }

        public bool blAllocationCompleted = false;

        public string stBpartnerID = "";
        public string stBankCheckID = "";
        public decimal dcTotalAmtToAllocate = 0;

        bool isCustomer = false;
        bool isVendor = false;
        bool isEmployee = false;
        bool bPHasCashBook = false;

        bool isSOTRX = false;


        string invDocNumber = "";
        string InvoiceID = "";

        string ChargeID = "";

        int intCurrAllocationSelectedRowIndex = -1;

        decimal invoiceAmount = 0;
        decimal paymentAmount = 0;
        decimal overUnderPayAmount = 0;
        decimal dcCurrInvReceivedAmt = 0;

        DateTime dateInvoiced;
        
        DataTable dtPaymentAllocation = new DataTable();
        DataTable dtGITCharges = new DataTable();
        DataTable dtNonGITCharges = new DataTable();

        DataTable dtOpenInvoices;
        

        DataGridViewCellStyle cancelButtonStyle = new DataGridViewCellStyle();

        dataBuilder getDataFromDb = new dataBuilder();

        private void getOpenInvoiceInfo()
        {
            this.dtOpenInvoices =
                    this.getDataFromDb.getC_INVOICEInfo(null, "", "",
                                "", "", "", "", "", "CL", "CO", this.invDocNumber, 
                                this.ckIsBillingPartener.Checked ? "" : this.stBpartnerID,
                                triStateBool.no, 
                                isEmployee || (isCustomer && isVendor) ? 
                                        triStateBool.Ignor : 
                                        isCustomer ? triStateBool.yes : triStateBool.no ,
                                        triStateBool.yes,
                                "", true, false, "AND");

            for (int columnCounter = this.dtOpenInvoices.Columns.Count - 1;
                columnCounter >= 0; columnCounter--)
            {
                if (this.dtOpenInvoices.Columns[columnCounter].ColumnName != "C_INVOICE_ID" &&
                this.dtOpenInvoices.Columns[columnCounter].ColumnName != "DOCUMENTNO" &&
                this.dtOpenInvoices.Columns[columnCounter].ColumnName != "DATEINVOICED" &
                this.dtOpenInvoices.Columns[columnCounter].ColumnName != "TOTALLINES" &&
                this.dtOpenInvoices.Columns[columnCounter].ColumnName != "GRANDTOTAL" &&
                this.dtOpenInvoices.Columns[columnCounter].ColumnName != "C_BPARTNER_ID" &&
                this.dtOpenInvoices.Columns[columnCounter].ColumnName != "ISSOTRX" &&
                this.dtOpenInvoices.Columns[columnCounter].ColumnName != "C_ORDER_ID")
                    this.dtOpenInvoices.Columns.RemoveAt(columnCounter);
            }
            this.dtOpenInvoices.Columns.Add("CUSTOMER");
            this.dtOpenInvoices.Columns.Add("Open");

            DataTable dtInvInfo = new DataTable();
            customControls.ctlNumberTextBox converter = new customControls.ctlNumberTextBox();
            converter.AllowNegative = true;
            converter.ShowThousandSeparetor = true;

            for (int rowCounter = this.dtOpenInvoices.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                dtInvInfo =
                    getDataFromDb.getOpenBalanceInfo
                            (this.dtOpenInvoices.Rows[rowCounter]["C_INVOICE_ID"].ToString());

                if (!this.getDataFromDb.checkIfTableContainesData(dtInvInfo))
                {
                    this.dtOpenInvoices.Rows.RemoveAt(rowCounter);
                    continue;
                }
                converter.Amount = dtInvInfo.Rows[0]["OPENAMT"].ToString();
                this.dtOpenInvoices.Rows[rowCounter]["Open"] = converter.Value;

                this.dtOpenInvoices.Rows[rowCounter]["CUSTOMER"] =
                    this.getDataFromDb.getC_BPARTNERInfo(null, "", "",
                              this.dtOpenInvoices.Rows[rowCounter]["C_BPARTNER_ID"].ToString(),
                              "", triStateBool.Ignor, triStateBool.Ignor, triStateBool.Ignor,
                              triStateBool.Ignor, false, false, "AND").Rows[0]["NAME"].ToString();
            }

            this.dtOpenInvoices.Columns.RemoveAt(
                this.dtOpenInvoices.Columns.IndexOf("C_BPARTNER_ID"));
        }


        private void enableDisableForm()
        {
            this.ddgInvoice.Enabled = !this.blAllocationCompleted;
            this.cmbCharge.Enabled = !this.blAllocationCompleted;
            this.ckIsGIT.Enabled = !this.blAllocationCompleted;
            this.dtpChargeDate.Enabled = !this.blAllocationCompleted;
            this.ntbAmount.Enabled = !this.blAllocationCompleted;

            this.cmdAdd.Enabled = !this.blAllocationCompleted && 
                ((this.ddgInvoice.SelectedRowKey == null && 
                this.cmbCharge.SelectedIndex <= 0) ? false : true);

            this.txtDescription.Enabled = !this.blAllocationCompleted;

            this.dtgAllocationLine.Columns["remove"].Visible = !this.blAllocationCompleted;
            
        }

        private bool invoiceExistInCurrentAllocation(string invID)
        {
            if (invID == "")
                return false;

            for (int rowCounter = 0; rowCounter <= this.dtPaymentAllocation.Rows.Count - 1; rowCounter++)
            {
                if (this.dtPaymentAllocation.Rows[rowCounter]["C_INVOICE_ID"].ToString() == invID)
                {
                    return true;
                }
            }
            return false;
        }

        private void fillChargeComboBox(DataTable dtDataToFill)
        {
            this.cmbCharge.Items.Clear();

            for (int rowCounter = 0; rowCounter <= dtDataToFill.Rows.Count - 1; rowCounter++)
            {
                this.cmbCharge.Items.Add(dtDataToFill.Rows[rowCounter]["NAME"].ToString());
            }
        }


        private void frmAllocate_Load(object sender, EventArgs e)
        {
            

            this.ntbCheckAmount.Amount = this.dcTotalAmtToAllocate.ToString();
                      
            this.cancelButtonStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.cancelButtonStyle.BackColor = Color.FromKnownColor(KnownColor.ControlDark);
            this.cancelButtonStyle.ForeColor = Color.FromKnownColor(KnownColor.Desktop);
            this.cancelButtonStyle.SelectionForeColor = Color.FromKnownColor(KnownColor.DarkBlue);
            this.cancelButtonStyle.WrapMode = DataGridViewTriState.False;
            this.cancelButtonStyle.Font =
                new System.Drawing.Font("Microsoft Sans Serif", 8.25F,
                    System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.dtPaymentAllocation =
                generalResultInformation.dtAllocation.Copy();

            
            this.dtPaymentAllocation.Columns["remove"].SetOrdinal(0);
            this.dtPaymentAllocation.Columns["LINE"].SetOrdinal(1);
            this.dtPaymentAllocation.Columns["Invoice"].SetOrdinal(2);
            this.dtPaymentAllocation.Columns["Charge"].SetOrdinal(3);
            this.dtPaymentAllocation.Columns["INVOICEAMT"].SetOrdinal(4);
            this.dtPaymentAllocation.Columns["AMOUNT"].SetOrdinal(5);
            this.dtPaymentAllocation.Columns["OVERUNDERAMT"].SetOrdinal(6);
            this.dtPaymentAllocation.Columns["DATEINVOICED"].SetOrdinal(7);
            

            this.dtgAllocationLine.DataSource =
                this.dtPaymentAllocation;

            this.dtgAllocationLine.Columns["C_BANKCHECKLINE_ID"].Visible = false;
            this.dtgAllocationLine.Columns["AD_CLIENT_ID"].Visible = false;
            this.dtgAllocationLine.Columns["C_BANKCHECK_ID"].Visible = false;
            this.dtgAllocationLine.Columns["AD_ORG_ID"].Visible = false;
            this.dtgAllocationLine.Columns["CREATED"].Visible = false;
            this.dtgAllocationLine.Columns["CREATEDBY"].Visible = false;
            this.dtgAllocationLine.Columns["UPDATED"].Visible = false;
            this.dtgAllocationLine.Columns["UPDATEDBY"].Visible = false;
            this.dtgAllocationLine.Columns["ISACTIVE"].Visible = false;
            this.dtgAllocationLine.Columns["DESCRIPTION"].Visible = false;
            this.dtgAllocationLine.Columns["C_INVOICE_ID"].Visible = false;
            this.dtgAllocationLine.Columns["C_CHARGE_ID"].Visible = false;
            this.dtgAllocationLine.Columns["ISCOST"].Visible = false;
            

            this.dtgAllocationLine.Columns["remove"].HeaderText = "";
            this.dtgAllocationLine.Columns["LINE"].HeaderText = "Line";
            this.dtgAllocationLine.Columns["AMOUNT"].HeaderText = "Amount";
            this.dtgAllocationLine.Columns["OVERUNDERAMT"].HeaderText = "Over/Under Amt";
            this.dtgAllocationLine.Columns["INVOICEAMT"].HeaderText = "Invoice Amount";
            this.dtgAllocationLine.Columns["DATEINVOICED"].HeaderText = "Dated";


            this.dtgAllocationLine.Columns["remove"].DefaultCellStyle = this.cancelButtonStyle;

            foreach (DataGridViewColumn columns in this.dtgAllocationLine.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DisplayIndex = columns.Index;
            }


            this.dtGITCharges = 
                this.getDataFromDb.getC_CHARGEInfo(null,"","","","", 
                        triStateBool.yes, true, false, "AND");

            DataView dvCharges = this.dtGITCharges.DefaultView;
            if (dvCharges.Table.Columns.Contains("NAME"))
                dvCharges.Sort = "NAME ASC";
            
            this.dtGITCharges = dvCharges.ToTable();

            DataRow drGit = this.dtGITCharges.NewRow();
            drGit["C_CHARGE_ID"] = 0;
            drGit["NAME"] = "";
            this.dtGITCharges.Rows.InsertAt(drGit, 0);
            

            this.dtNonGITCharges =
                this.getDataFromDb.getC_CHARGEInfo(null, "", "", "", "",
                        triStateBool.no, true, false, "AND");

            dvCharges = this.dtNonGITCharges.DefaultView;
            if (dvCharges.Table.Columns.Contains("NAME"))
                dvCharges.Sort = "NAME ASC";

            this.dtNonGITCharges = dvCharges.ToTable();
            
            drGit = this.dtNonGITCharges.NewRow();
            drGit["C_CHARGE_ID"] = 0;
            drGit["NAME"] = "";
            this.dtNonGITCharges.Rows.InsertAt(drGit,0);

            this.fillChargeComboBox(this.dtNonGITCharges);

            DataTable dtBPartnerInfo =
                this.getDataFromDb.getC_BPARTNERInfo(null, "", "",
                              this.stBpartnerID, "", triStateBool.Ignor, triStateBool.Ignor, triStateBool.Ignor,
                              triStateBool.Ignor, false, false, "AND");
            if (this.getDataFromDb.checkIfTableContainesData(dtBPartnerInfo))
            {
                this.isEmployee =
                    dtBPartnerInfo.Rows[0]["ISEMPLOYEE"].ToString() == "Y" ? true : false;
                this.isVendor =
                    dtBPartnerInfo.Rows[0]["ISVENDOR"].ToString() == "Y" ? true : false;
                this.isCustomer =
                    dtBPartnerInfo.Rows[0]["ISCUSTOMER"].ToString() == "Y" ? true : false;
            }
            else
            {
                this.isEmployee = false;
                this.isVendor = false;
                this.isCustomer = false;
            }

            if (this.isEmployee)
            {
                DataTable dtEmpInfo =
                    this.getDataFromDb.getC_BPARTNERInfo(null, "", "", this.stBpartnerID,
                            "", triStateBool.Ignor, triStateBool.Ignor, triStateBool.Ignor, 
                            triStateBool.Ignor, false, false, "AND");

                if (this.getDataFromDb.checkIfTableContainesData(dtEmpInfo))
                {
                    bPHasCashBook = 
                        dtEmpInfo.Rows[0]["C_CASHBOOK_ID"].ToString() == "" ? false : true;
                }

            }

            this.enableDisableForm();

        }


        private void ckIsGIT_CheckedChanged(object sender, EventArgs e)
        {
            if (ckIsGIT.Checked)            
                this.fillChargeComboBox(this.dtGITCharges);            
            else
                this.fillChargeComboBox(this.dtNonGITCharges);

            if (this.cmbCharge.Items.Count > 0)
                this.cmbCharge.SelectedIndex = 0;
        }



        private void ddgInvoice_SelectedItemClicked(object sender, EventArgs e)
        {
            this.invDocNumber = this.ddgInvoice.SelectedItem;
            this.getOpenInvoiceInfo();

            this.ddgInvoice.DataSource = this.dtOpenInvoices.Copy();
            this.ddgInvoice.DataTablePrimaryKey =
                Convert.ToUInt16(this.dtOpenInvoices.Columns.IndexOf("C_INVOICE_ID"));
            this.ddgInvoice.HiddenColoumns =
                new int[] { this.dtOpenInvoices.Columns.IndexOf("C_ORDER_ID"),
                            this.dtOpenInvoices.Columns.IndexOf("ISSOTRX") };
            this.ddgInvoice.SelectedColomnIdex =
                this.dtOpenInvoices.Columns.IndexOf("DOCUMENTNO");
        }

        private void ddgInvoice_selectedItemChanged(object sender, EventArgs e)
        {
            if (this.ddgInvoice.SelectedRow.Rows.Count > 0 &&
                this.ddgInvoice.SelectedRowKey != null)
            {
                this.InvoiceID =
                    this.ddgInvoice.SelectedRowKey.ToString();

                this.invoiceAmount =
                    decimal.Parse(this.ddgInvoice.SelectedRow.Rows[0]["Open"].ToString());

                this.ntbAmount.Amount = this.invoiceAmount.ToString();
                
                if (bPHasCashBook)
                {
                    this.ntbAmount.Enabled = false;
                }
                else
                {
                    this.ntbAmount.Enabled = true;
                }
                
                this.cmbCharge.Enabled = false;
                this.ckIsGIT.Enabled = false;
                this.dtpChargeDate.Enabled = false;

                this.isSOTRX = 
                    this.ddgInvoice.SelectedRow.Rows[0]["ISSOTRX"].ToString() == "Y" ? true : false;

                this.cmdAdd.Enabled = true;
            }
            else
            {
                this.InvoiceID = "";

                this.invoiceAmount = 0;                    

                this.cmbCharge.Enabled = true;
                this.cmbCharge.SelectedIndex = 0;

                this.ckIsGIT.Enabled = true;
                this.dtpChargeDate.Enabled = true;
                this.cmdAdd.Enabled = false;
            }
            if(this.cmbCharge.Items.Count > 0)
                this.cmbCharge.SelectedIndex = 0;

            this.ntbAmount.Amount = this.invoiceAmount.ToString();
            this.ntbInvoiceAmt.Amount = this.invoiceAmount.ToString();
            this.paymentAmount = this.invoiceAmount;
            this.overUnderPayAmount = 0;
            this.ntbOverUnderAmt.Amount = this.overUnderPayAmount.ToString();
        }


        private void ntbAmount_Leave(object sender, EventArgs e)
        {
            if (this.InvoiceID != "")
            {
                this.overUnderPayAmount =
                    this.invoiceAmount -
                        decimal.Parse(this.ntbAmount.Amount);
            }
            else
                this.overUnderPayAmount = 0;

            this.ntbOverUnderAmt.Amount = 
                this.overUnderPayAmount.ToString();

            if (ntbAmount.Amount == "" ||
                ntbAmount.Amount == "0")
            {
                this.cmdAdd.Enabled = false;
            }
            else
            {
                this.cmdAdd.Enabled = true;
            }

        }
                
        private void cmbCharge_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbCharge.SelectedIndex > 0)
            {
                this.InvoiceID = "";
                this.invDocNumber = "";

                this.invoiceAmount = 0;

                this.ddgInvoice.Enabled = false;
                this.ddgInvoice.SelectedItem = "";
                this.ddgInvoice.SelectedRowKey = null;

                this.ckIsBillingPartener.Checked = false;
                this.ckIsBillingPartener.Enabled = false;

                this.ntbAmount.Amount = this.invoiceAmount.ToString();
                this.ntbInvoiceAmt.Amount = this.invoiceAmount.ToString();
                this.paymentAmount = this.invoiceAmount;
                this.overUnderPayAmount = 0;

                this.cmdAdd.Enabled = true;
            }
            else
            {
                this.ddgInvoice.Enabled = true;
                this.ckIsBillingPartener.Enabled = true;

                this.cmdAdd.Enabled = false;
            }
        }


        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (this.ddgInvoice.SelectedRowKey == null &&
                this.cmbCharge.SelectedIndex <= 0)
            {
                MessageBox.Show("Please Input Reason for Allocation", "Allocation",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cmdAdd.Enabled = false;
                return;
            }

            if ((decimal.Parse(this.ntbOverUnderAmt.Amount) < 0 && !this.isSOTRX) ||
                (decimal.Parse(this.ntbOverUnderAmt.Amount) > 0 && this.isSOTRX))
            {
                MessageBox.Show("Amount paid exceeds due amount", "Allocation", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (decimal.Parse(this.ntbAmount.Amount) == 0)
            {
                MessageBox.Show("Input the Amount paid", "Allocation", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.invoiceExistInCurrentAllocation(this.InvoiceID) &&
                this.cmdAdd.Text == "Add")
            {
                MessageBox.Show("Invoice Already in Allocation", "Allocation",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.cmdAdd.Text == "Modify")
            {
                if (!this.isSOTRX)
                {
                    this.dcTotalAmtToAllocate +=
                        decimal.Parse(this.dtPaymentAllocation.
                            Rows[this.intCurrAllocationSelectedRowIndex]["AMOUNT"].ToString());
                }
                else
                {
                    this.dcTotalAmtToAllocate -=
                        decimal.Parse(this.dtPaymentAllocation.
                            Rows[this.intCurrAllocationSelectedRowIndex]["AMOUNT"].ToString());
                }

                if (this.ddgInvoice.SelectedRowKey == null)
                {
                    this.dtPaymentAllocation.Rows[this.intCurrAllocationSelectedRowIndex]["C_INVOICE_ID"] = 
                        DBNull.Value;

                    this.dtPaymentAllocation.Rows[this.intCurrAllocationSelectedRowIndex]["ISCOST"] =
                        this.ckIsGIT.Checked ? "Y" : "N";

                    this.dateInvoiced =DateTime.Parse(this.dtpChargeDate.Value.ToString("dd/MMM/yyyy"));

                    if (this.ckIsGIT.Checked)
                    {
                        this.dtPaymentAllocation.Rows[this.intCurrAllocationSelectedRowIndex]["C_CHARGE_ID"] = 
                            int.Parse(this.dtGITCharges.Rows[this.cmbCharge.SelectedIndex]
                                ["C_CHARGE_ID"].ToString());                        
                    }
                    else
                    {
                        this.dtPaymentAllocation.Rows[this.intCurrAllocationSelectedRowIndex]["C_CHARGE_ID"] =
                            int.Parse(this.dtNonGITCharges.Rows[this.cmbCharge.SelectedIndex]
                                ["C_CHARGE_ID"].ToString()); ;  
                    }
                }
                else
                {
                    this.dtPaymentAllocation.Rows[this.intCurrAllocationSelectedRowIndex]["C_INVOICE_ID"] =
                        int.Parse(this.ddgInvoice.SelectedRowKey.ToString());

                    this.dtPaymentAllocation.Rows[this.intCurrAllocationSelectedRowIndex]["C_CHARGE_ID"] = DBNull.Value;
                    this.dtPaymentAllocation.Rows[this.intCurrAllocationSelectedRowIndex]["ISCOST"] = "N";

                    if (this.ddgInvoice.SelectedRow.Rows.Count <= 0)
                    {
                        DataTable invInf =
                            this.getDataFromDb.getC_INVOICEInfo(null, "", "", 
                                    this.ddgInvoice.SelectedRowKey.ToString(), "", "", "", "", "",
                                    "", "", "", triStateBool.Ignor, triStateBool.Ignor, 
                                    triStateBool.Ignor, "", false, false, "AND");

                        this.dateInvoiced = DateTime.Parse(invInf.Rows[0]["DATEINVOICED"].ToString());

                    }
                    else
                    {
                        this.dateInvoiced = DateTime.Parse(this.ddgInvoice.SelectedRow.Rows[0]["DATEINVOICED"].ToString());
                    }                    
                }

                
                this.dtPaymentAllocation.Rows[this.intCurrAllocationSelectedRowIndex]["INVOICEAMT"] =
                    decimal.Parse(this.ntbInvoiceAmt.Amount).ToString("N02");

                this.dtPaymentAllocation.Rows[this.intCurrAllocationSelectedRowIndex]["Invoice"] =
                    this.invDocNumber;
                this.dtPaymentAllocation.Rows[this.intCurrAllocationSelectedRowIndex]["Charge"] =
                    this.cmbCharge.SelectedItem.ToString();

                this.dtPaymentAllocation.Rows[this.intCurrAllocationSelectedRowIndex]["C_BANKCHECK_ID"] =
                    int.Parse(this.stBankCheckID);

                this.dtPaymentAllocation.Rows[this.intCurrAllocationSelectedRowIndex]["DATEINVOICED"] =
                    this.dateInvoiced;

                this.dtPaymentAllocation.Rows[this.intCurrAllocationSelectedRowIndex]["AMOUNT"] =
                    decimal.Parse(this.ntbAmount.Amount).ToString("N02");
                this.dtPaymentAllocation.Rows[this.intCurrAllocationSelectedRowIndex]["OVERUNDERAMT"] =
                    decimal.Parse(this.ntbOverUnderAmt.Amount).ToString("N02");

                this.dtPaymentAllocation.Rows[this.intCurrAllocationSelectedRowIndex]["DESCRIPTION"] =
                    this.txtDescription.Text;

                this.dtPaymentAllocation.Rows[this.intCurrAllocationSelectedRowIndex]["remove"] = "remove";
            }
            else
            {

                DataRow drNewAllocation = this.dtPaymentAllocation.NewRow();

                drNewAllocation["remove"] = "remove";
                drNewAllocation["Invoice"] = this.invDocNumber;
                drNewAllocation["Charge"] = this.cmbCharge.SelectedItem.ToString();
                drNewAllocation["C_BANKCHECK_ID"] = int.Parse(this.stBankCheckID);
                drNewAllocation["LINE"] = this.dtPaymentAllocation.Rows.Count + 1;

                if (this.ddgInvoice.SelectedRowKey != null)
                {
                    drNewAllocation["C_INVOICE_ID"] =
                        int.Parse(this.ddgInvoice.SelectedRowKey.ToString());
                    drNewAllocation["ISCOST"] = "N";

                    this.dateInvoiced = 
                        DateTime.Parse(this.ddgInvoice.SelectedRow.Rows[0]["DATEINVOICED"].ToString());                    
                }
                else
                {
                    if (this.ckIsGIT.Checked)
                    {
                        drNewAllocation["ISCOST"] = "Y";
                        drNewAllocation["C_CHARGE_ID"] =
                            int.Parse(this.dtGITCharges.Rows[this.cmbCharge.SelectedIndex]
                                ["C_CHARGE_ID"].ToString());
                    }
                    else
                    {
                        drNewAllocation["ISCOST"] = "N";
                        drNewAllocation["C_CHARGE_ID"] =
                            int.Parse(this.dtNonGITCharges.Rows[this.cmbCharge.SelectedIndex]
                                ["C_CHARGE_ID"].ToString());
                    }
                    this.dateInvoiced = DateTime.Parse(this.dtpChargeDate.Value.ToString("dd/MMM/yyyy"));
                }

                drNewAllocation["AMOUNT"] =
                    decimal.Parse(this.ntbAmount.Amount);
                drNewAllocation["OVERUNDERAMT"] =
                    decimal.Parse(this.ntbOverUnderAmt.Amount);
                drNewAllocation["INVOICEAMT"] =
                    decimal.Parse(this.ntbInvoiceAmt.Amount);
                drNewAllocation["DATEINVOICED"] =
                    this.dateInvoiced;
                drNewAllocation["DESCRIPTION"] =
                    this.txtDescription.Text;

                this.dtPaymentAllocation.Rows.Add(drNewAllocation);
            }

            if (this.isSOTRX && this.ddgInvoice.SelectedRowKey != null)
            {
                this.dcTotalAmtToAllocate += decimal.Parse(this.ntbAmount.Amount);
            }
            else
            {
                this.dcTotalAmtToAllocate -= decimal.Parse(this.ntbAmount.Amount);
            }

            this.ntbCheckAmount.Amount = this.dcTotalAmtToAllocate.ToString();


            this.ddgInvoice.SelectedItem = "";
            this.ddgInvoice.SelectedRow.Clear();
            this.ddgInvoice.SelectedRowKey = null;

            this.ddgInvoice_selectedItemChanged(sender, e);

            if(this.cmbCharge.Items.Count > 0)
                this.cmbCharge.SelectedIndex = 0;

            this.ckIsGIT.Checked = false;
            this.ckIsBillingPartener.Checked = false;

            this.ntbAmount.Enabled = true;

            this.txtDescription.Text = "";

            this.cmdAdd.Text = "Add";
            this.cmdAdd.Enabled = false;

        }


        private void dtgAllocationLine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgAllocationLine.SelectedRows.Count < 1 ||
                this.blAllocationCompleted)
            {
                return;
            }

            if (this.dtgAllocationLine.Columns["remove"].Visible == false)
                return;

            this.intCurrAllocationSelectedRowIndex =
                this.dtgAllocationLine.SelectedRows[0].Index;


            this.InvoiceID =
                        this.dtgAllocationLine.Rows[intCurrAllocationSelectedRowIndex].
                            Cells["C_INVOICE_ID"].Value.ToString();

            this.ChargeID =
                this.dtgAllocationLine.Rows[intCurrAllocationSelectedRowIndex].
                    Cells["C_CHARGE_ID"].Value.ToString();

            if (this.InvoiceID != "")
            {
                DataTable invInfo =
                    this.getDataFromDb.getC_INVOICEInfo(null, "", "",
                                this.InvoiceID,
                                "", "", "", "", "", "", "", "", triStateBool.Ignor,
                                triStateBool.Ignor, triStateBool.Ignor, "",
                                false, false, "AND");

                this.isSOTRX =
                    invInfo.Rows[0]["ISSOTRX"].ToString() == "Y" ? true : false;
            }
            else
                this.isSOTRX = false;            
                  

            if (this.dtgAllocationLine.CurrentCell != null)
            {
                if (this.dtgAllocationLine.CurrentCell.OwningColumn.Index == 0 &&
                    this.dtgAllocationLine.CurrentCell.OwningColumn.Name == "remove" &&
                    this.dtgAllocationLine.CurrentCell.Value.ToString() == "remove" &&
                    this.dtgAllocationLine.CurrentCell.OwningColumn.HeaderText == "")
                {
                    decimal removedAllocationAmount =
                        decimal.Parse(this.dtPaymentAllocation.Rows[intCurrAllocationSelectedRowIndex]["AMOUNT"].ToString());

                    if (!this.isSOTRX)
                    {
                        this.dcTotalAmtToAllocate += removedAllocationAmount;
                    }
                    else
                    {
                        this.dcTotalAmtToAllocate -= removedAllocationAmount;
                    }

                    this.ntbCheckAmount.Amount = this.dcTotalAmtToAllocate.ToString();

                    this.dtPaymentAllocation.Rows.RemoveAt(intCurrAllocationSelectedRowIndex);

                    this.ddgInvoice.SelectedRowKey = null;
                    this.ddgInvoice.SelectedItem = "";
                    this.ddgInvoice.SelectedRow.Clear();
                    this.ddgInvoice_selectedItemChanged(sender, e);

                    this.cmdAdd.Text = "ADD";
                    this.intCurrAllocationSelectedRowIndex = -1;
                }
                else
                {
                    this.cmdAdd.Text = "Modify";

                    
                    if (this.InvoiceID != "")
                    {
                        this.ddgInvoice.SelectedRowKey = this.InvoiceID;
                        

                        this.ddgInvoice.SelectedItem =
                            this.dtgAllocationLine.Rows[intCurrAllocationSelectedRowIndex].
                                Cells["Invoice"].Value.ToString();

                        this.invoiceAmount =
                            decimal.Parse(this.dtgAllocationLine.Rows[intCurrAllocationSelectedRowIndex].
                                Cells["INVOICEAMT"].Value.ToString());

                        this.ntbInvoiceAmt.Amount =
                            this.invoiceAmount.ToString();

                        this.ddgInvoice.Enabled = true;

                        this.cmbCharge.Enabled = false;
                        this.ckIsGIT.Enabled = false;
                        this.dtpChargeDate.Enabled = false;

                        if (bPHasCashBook)
                        {
                            this.ntbAmount.Enabled = false;
                        }
                        else
                        {
                            this.ntbAmount.Enabled = true;
                        }
                
                    }
                    else if (this.ChargeID != "")
                    {
                        if (this.dtgAllocationLine.Rows[intCurrAllocationSelectedRowIndex].
                                Cells["ISCOST"].Value.ToString() == "Y")
                        {
                            this.ckIsGIT.Checked = true;
                            this.fillChargeComboBox(this.dtGITCharges);

                            for (int rowCounter = 0;
                                rowCounter <= this.dtGITCharges.Rows.Count - 1;
                                rowCounter++)
                            {
                                if (this.dtGITCharges.Rows[rowCounter]["C_CHARGE_ID"].ToString() == this.ChargeID)
                                {
                                    this.cmbCharge.SelectedIndex = rowCounter;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            this.ckIsGIT.Checked = false;
                            this.fillChargeComboBox(this.dtNonGITCharges);

                            for (int rowCounter = 0;
                                rowCounter <= this.dtNonGITCharges.Rows.Count - 1;
                                rowCounter++)
                            {
                                if (this.dtNonGITCharges.Rows[rowCounter]["C_CHARGE_ID"].ToString() == this.ChargeID)
                                {
                                    this.cmbCharge.SelectedIndex = rowCounter;
                                    break;
                                }
                            }
                        }

                        this.cmbCharge.Enabled = true;
                        this.ckIsGIT.Enabled = true;
                        this.dtpChargeDate.Enabled = true;
                    }

                    this.dcCurrInvReceivedAmt =
                        decimal.Parse(this.dtgAllocationLine.Rows[intCurrAllocationSelectedRowIndex].
                            Cells["AMOUNT"].Value.ToString());

                    this.ntbAmount.Amount =
                        this.dcCurrInvReceivedAmt.ToString();

                    this.paymentAmount = this.dcCurrInvReceivedAmt;

                    this.overUnderPayAmount =
                        decimal.Parse(this.dtgAllocationLine.Rows[intCurrAllocationSelectedRowIndex].
                            Cells["OVERUNDERAMT"].Value.ToString());

                    this.ntbOverUnderAmt.Amount =
                        this.overUnderPayAmount.ToString();

                    this.txtDescription.Text =
                        this.dtgAllocationLine.Rows[intCurrAllocationSelectedRowIndex].
                            Cells["DESCRIPTION"].Value.ToString();
                    
                    this.dtpChargeDate.Value =
                        DateTime.Parse(this.dtgAllocationLine.Rows[intCurrAllocationSelectedRowIndex].
                            Cells["DATEINVOICED"].Value.ToString());

                    this.cmdAdd.Enabled = true;
                }
            }

        }
        

        private void cmdComplete_Click(object sender, EventArgs e)
        {
            if (
                    Math.Abs(decimal.Parse(this.ntbCheckAmount.Amount)) > 
                    generalResultInformation.allowedOverageShortageAmount
                )
            {
                if(!generalResultInformation.allowOverageShortagePassKey)
                {
                    MessageBox.Show("Amount has over/under Allocation." +
                       "\n Please Correct allocation to proceed.", "New Deposit",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (
                    MessageBox.Show("Amount has over/under Allocation." +
                       "\n Enter pass key to proceed.", "New Deposit",
                       MessageBoxButtons.OKCancel, MessageBoxIcon.Information,
                       MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    frmAllowOverageShortage allowAmount = new frmAllowOverageShortage();
                    allowAmount.TopMost = true;
                    allowAmount.ShowDialog();

                    if (generalResultInformation.allowAmountOverageShortage)
                    {
                        this.Close();
                    }
                }
                else
                {                    
                    return;
                }
            }
            else
            {
                if (Math.Abs(decimal.Parse(this.ntbCheckAmount.Amount)) > 0)
                {
                    generalResultInformation.allowAmountOverageShortage = true;
                }
                this.Close();
            }
        }

        private void frmAllocate_FormClosing(object sender, FormClosingEventArgs e)
        {
            generalResultInformation.dtAllocation =
                this.dtPaymentAllocation.Copy();            
        }


    }
}
