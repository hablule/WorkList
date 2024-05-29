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
    public partial class frmPaymentAllocation : Form
    {
        public frmPaymentAllocation()
        {
            InitializeComponent();
        }


        public string pstPayment_ID = "";

        DataTable dtNewReceiptDetail = new DataTable();

        dataBuilder getDataFromDb = new dataBuilder();

        DataGridViewCellStyle cancelButtonStyle = new DataGridViewCellStyle();


        private void createDetailReceiptTable()
        {
            this.dtNewReceiptDetail =
                this.getDataFromDb.getC_ALLOCATIONLINEInfo(null, "", "",
                        "", DateTime.Now, false, "", "", "",
                        triaStateBool.Ignor, "", false, true, "AND");

            this.dtNewReceiptDetail.Columns.Add("remove");
            this.dtNewReceiptDetail.Columns.Add("Sn");
            this.dtNewReceiptDetail.Columns.Add("Document No");
            this.dtNewReceiptDetail.Columns.Add("Date Sold");
            this.dtNewReceiptDetail.Columns.Add("Invoiced");
            this.dtNewReceiptDetail.Columns.Add("Customer");

            this.dtNewReceiptDetail.Columns["remove"].SetOrdinal(0);
            this.dtNewReceiptDetail.Columns["Sn"].SetOrdinal(1);
            this.dtNewReceiptDetail.Columns["Document No"].SetOrdinal(2);
            this.dtNewReceiptDetail.Columns["Customer"].SetOrdinal(3);
            this.dtNewReceiptDetail.Columns["Date Sold"].SetOrdinal(4);
            this.dtNewReceiptDetail.Columns["Invoiced"].SetOrdinal(5);
            this.dtNewReceiptDetail.Columns["INVOICEAMT"].SetOrdinal(6);
            this.dtNewReceiptDetail.Columns["AMOUNT"].SetOrdinal(7);
            this.dtNewReceiptDetail.Columns["OVERUNDERAMT"].SetOrdinal(8);


            this.dtgReceiptDtl.DataSource =
                this.dtNewReceiptDetail;

            this.dtgReceiptDtl.Columns["C_ALLOCATIONLINE_ID"].Visible = false;
            this.dtgReceiptDtl.Columns["AD_ORG_ID"].Visible = false;
            this.dtgReceiptDtl.Columns["C_ALLOCATIONHDR_ID"].Visible = false;
            this.dtgReceiptDtl.Columns["CREATED"].Visible = false;
            this.dtgReceiptDtl.Columns["CREATEDBY"].Visible = false;
            this.dtgReceiptDtl.Columns["UPDATED"].Visible = false;
            this.dtgReceiptDtl.Columns["UPDATEDBY"].Visible = false;
            this.dtgReceiptDtl.Columns["ISACTIVE"].Visible = false;
            this.dtgReceiptDtl.Columns["C_INVOICE_ID"].Visible = false;
            this.dtgReceiptDtl.Columns["C_BPARTNER_ID"].Visible = false;
            this.dtgReceiptDtl.Columns["C_PAYMENT_ID"].Visible = false;
            this.dtgReceiptDtl.Columns["DESCRIPTION"].Visible = false;
            this.dtgReceiptDtl.Columns["DISCOUNTAMT"].Visible = false;
            this.dtgReceiptDtl.Columns["WRITEOFFAMT"].Visible = false;
            this.dtgReceiptDtl.Columns["POSTED"].Visible = false;
            this.dtgReceiptDtl.Columns["DATETRX"].Visible = false;
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
        

        private void fillDetailReceiptTable()
        {
            if (this.pstPayment_ID == "")
                return;
            this.dtNewReceiptDetail.Rows.Clear();

            DataTable receiptDtlInfo =
                this.getDataFromDb.getC_ALLOCATIONLINEInfo(null, "", "",
                        "", DateTime.Now, false, "", "", this.pstPayment_ID, 
                        triaStateBool.Ignor, "", false, false, "AND");

            foreach (DataRow dr in receiptDtlInfo.Rows)
            {
                DataRow recptDtl = this.dtNewReceiptDetail.NewRow();
                foreach (DataColumn dc in receiptDtlInfo.Columns)
                {
                    string colName = dc.ColumnName;
                    recptDtl[colName] = dr[colName];
                }
                recptDtl["remove"] = "";

                DataTable customerInfo = this.getDataFromDb.getCustomersInfo(null, "",
                        dr["C_BPARTNER_ID"].ToString(), generalResultInformation.Station, "", "",
                         triaStateBool.Ignor, false, "AND");

                if (this.getDataFromDb.checkIfTableContainesData(customerInfo))
                    recptDtl["Customer"] =
                        customerInfo.Rows[0]["customer_name"].ToString();
                else
                    recptDtl["Customer"] = "NA";

                if (dr["ISEXEMPTION"].ToString() == "Y")
                {
                    DataTable salesInf =
                        this.getDataFromDb.getC_EXEMPTIONInfo(null, "",
                            dr["C_INVOICE_ID"].ToString(), "",
                            "", DateTime.Now, false, exemptionType.ignor, dr["STATION_ID"].ToString(),
                            false, false, "AND");
                    if (this.getDataFromDb.checkIfTableContainesData(salesInf))
                    {
                        recptDtl["Document No"] = salesInf.Rows[0]["DOCUMENTNO"].ToString();
                        recptDtl["Date Sold"] = salesInf.Rows[0]["DATEINVOICED"].ToString();
                        recptDtl["Invoiced"] = salesInf.Rows[0]["EXEMPTEDAMT"].ToString();
                    }
                    else
                    {
                        recptDtl["Document No"] = "0";
                        recptDtl["Date Sold"] = DateTime.Now.ToString();
                        recptDtl["Invoiced"] = "0"; 
                    }
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


        private void frmPaymentAllocation_Load(object sender, EventArgs e)
        {
            this.cancelButtonStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.cancelButtonStyle.BackColor = Color.FromKnownColor(KnownColor.ControlDark);
            this.cancelButtonStyle.ForeColor = Color.FromKnownColor(KnownColor.Desktop);
            this.cancelButtonStyle.SelectionForeColor = Color.FromKnownColor(KnownColor.DarkBlue);
            this.cancelButtonStyle.WrapMode = DataGridViewTriState.False;
            this.cancelButtonStyle.Font =
                new System.Drawing.Font("Microsoft Sans Serif", 8.25F,
                    System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


            this.createDetailReceiptTable();


            this.fillDetailReceiptTable();
        }
    }
}
