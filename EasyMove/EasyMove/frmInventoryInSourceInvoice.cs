using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EasyMove
{
    public partial class frmInventoryInSourceInvoice : Form
    {
        public frmInventoryInSourceInvoice()
        {
            InitializeComponent();
        }




        string[] stExistingC_InvoiceLine_ID;
        public string stBpartnerId = "";
        
        public int allowedLineCount = 0;
        int existingLineCount = 0;
        int selectedRowCount = 0;

        DataTable dtBPInvoiceList = new DataTable();
        DataTable dtNewInvoiceItemList = new DataTable();

        public DataTable dtExistingInvoiceItemList = new DataTable();


        dataBuilder getDataFromDb = new dataBuilder();


       
        private void frmInventoryInSourceInvoice_Load(object sender, EventArgs e)
        {
            if (this.stBpartnerId == "")
            {
                return;
            }

            generalResultInformation.incomingInventorySourceInvoice.Clear();

            this.dtNewInvoiceItemList =
                this.getDataFromDb.getINVOICEDETAILInfo(null, "", "", "", "",
                            "", "", "", false, true, "AND", "", "");

            this.dtNewInvoiceItemList.Columns.
                    Add("Select", Type.GetType("System.Boolean"));
            this.dtNewInvoiceItemList.Columns.Add("PRODUCT");
            this.dtNewInvoiceItemList.Columns.Add("UNIT");

            this.dtNewInvoiceItemList.Columns["Select"].SetOrdinal(0);
            this.dtNewInvoiceItemList.Columns["LINE"].SetOrdinal(1);
            this.dtNewInvoiceItemList.Columns["PRODUCT"].SetOrdinal(2);
            this.dtNewInvoiceItemList.Columns["QTYENTERED"].SetOrdinal(3);
            this.dtNewInvoiceItemList.Columns["QTYRECEIVED"].SetOrdinal(4);
            this.dtNewInvoiceItemList.Columns["DOCUMENTNO"].SetOrdinal(5);

            
            this.dtgInvoiceItems.DataSource = this.dtNewInvoiceItemList;

            foreach (DataGridViewColumn columns in this.dtgInvoiceItems.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DisplayIndex = columns.Index;
            }

            this.dtgInvoiceItems.Columns["C_INVOICE_ID"].Visible = false;
            this.dtgInvoiceItems.Columns["C_BPARTNER_ID"].Visible = false;
            this.dtgInvoiceItems.Columns["DOCSTATUS"].Visible = false;
            this.dtgInvoiceItems.Columns["PROCESSING"].Visible = false;
            this.dtgInvoiceItems.Columns["PROCESSED"].Visible = false;
            this.dtgInvoiceItems.Columns["C_ORDER_ID"].Visible = false;
            this.dtgInvoiceItems.Columns["ORDERNO"].Visible = false;
            this.dtgInvoiceItems.Columns["ISACTIVE"].Visible = false;
            this.dtgInvoiceItems.Columns["DATEORDERED"].Visible = false;
            this.dtgInvoiceItems.Columns["C_ORDERLINE_ID"].Visible = false;
            this.dtgInvoiceItems.Columns["C_INVOICELINE_ID"].Visible = false;
            this.dtgInvoiceItems.Columns["M_PRODUCT_ID"].Visible = false;
            this.dtgInvoiceItems.Columns["C_UOM_ID"].Visible = false;

            this.dtgInvoiceItems.Columns["Select"].HeaderText = "";
            this.dtgInvoiceItems.Columns["LINE"].HeaderText = "Sn";
            this.dtgInvoiceItems.Columns["PRODUCT"].HeaderText = "Product";
            this.dtgInvoiceItems.Columns["DOCUMENTNO"].HeaderText = "Invoice No";
            this.dtgInvoiceItems.Columns["QTYENTERED"].HeaderText = "Invoiced";
            this.dtgInvoiceItems.Columns["QTYRECEIVED"].HeaderText = "Received";

            

            this.dtBPInvoiceList =
                this.getDataFromDb.getINVOICEDETAILInfo(null, "", "", "", this.stBpartnerId,
                            "", "", "", true, false, "AND", "QTYENTERED > QTYRECEIVED", "AND");
                       
            this.dtBPInvoiceList.Columns.RemoveAt(this.dtBPInvoiceList.Columns.IndexOf("ISACTIVE"));
            this.dtBPInvoiceList.Columns.RemoveAt(this.dtBPInvoiceList.Columns.IndexOf("DOCSTATUS"));
            this.dtBPInvoiceList.Columns.RemoveAt(this.dtBPInvoiceList.Columns.IndexOf("PROCESSING"));
            this.dtBPInvoiceList.Columns.RemoveAt(this.dtBPInvoiceList.Columns.IndexOf("PROCESSED"));
            this.dtBPInvoiceList.Columns.RemoveAt(this.dtBPInvoiceList.Columns.IndexOf("C_ORDER_ID"));
            this.dtBPInvoiceList.Columns.RemoveAt(this.dtBPInvoiceList.Columns.IndexOf("ORDERNO"));
            this.dtBPInvoiceList.Columns.RemoveAt(this.dtBPInvoiceList.Columns.IndexOf("DATEORDERED"));
            this.dtBPInvoiceList.Columns.RemoveAt(this.dtBPInvoiceList.Columns.IndexOf("C_ORDERLINE_ID"));
            this.dtBPInvoiceList.Columns.RemoveAt(this.dtBPInvoiceList.Columns.IndexOf("LINE"));
            this.dtBPInvoiceList.Columns.RemoveAt(this.dtBPInvoiceList.Columns.IndexOf("M_PRODUCT_ID"));
            this.dtBPInvoiceList.Columns.RemoveAt(this.dtBPInvoiceList.Columns.IndexOf("C_UOM_ID"));
            this.dtBPInvoiceList.Columns.RemoveAt(this.dtBPInvoiceList.Columns.IndexOf("QTYENTERED"));
            this.dtBPInvoiceList.Columns.RemoveAt(this.dtBPInvoiceList.Columns.IndexOf("QTYRECEIVED"));

            this.dtBPInvoiceList =
                this.getDataFromDb.clearRedundantRow(this.dtBPInvoiceList, "C_INVOICE_ID");

            List<string> invoiceLineList = new List<string>();

            for (int rowCounter = 0; rowCounter <= this.dtExistingInvoiceItemList.Rows.Count - 1; rowCounter++)
            {
                invoiceLineList.Add(this.dtExistingInvoiceItemList.Rows[rowCounter]["C_INVOICELINE_ID"].ToString());
            }

            this.existingLineCount = this.dtExistingInvoiceItemList.Rows.Count;

            this.stExistingC_InvoiceLine_ID = 
                invoiceLineList.Distinct().ToArray();

        }



        private void ddgInvoice_SelectedItemClicked(object sender, EventArgs e)
        {
            ddgInvoice.DataSource = 
                this.dtBPInvoiceList.Copy();
            ddgInvoice.DataTablePrimaryKey =
                Convert.ToUInt16(this.dtBPInvoiceList.Columns.IndexOf("C_INVOICELINE_ID"));
            ddgInvoice.SelectedColomnIdex =
                this.dtBPInvoiceList.Columns.IndexOf("DOCUMENTNO");
            this.ddgInvoice.HiddenColoumns = new int[]{
                this.dtBPInvoiceList.Columns.IndexOf("C_INVOICE_ID"),
                this.dtBPInvoiceList.Columns.IndexOf("C_BPARTNER_ID")};
        }

        private void ddgInvoice_selectedItemChanged(object sender, EventArgs e)
        {
            if (ddgInvoice.SelectedRowKey == null)
            {
                this.dtNewInvoiceItemList.Clear();
            }

            DataTable dtInvoiceListInfo =
                this.getDataFromDb.getINVOICEDETAILInfo(null, "",
                        this.ddgInvoice.SelectedRow.Rows[0]["C_INVOICE_ID"].ToString(),
                        "", this.stBpartnerId, "", "", "", false, false, "AND", "QTYENTERED > QTYRECEIVED", "AND");

            dtInvoiceListInfo.Columns.
                   Add("Select", Type.GetType("System.Boolean"));
            dtInvoiceListInfo.Columns.Add("PRODUCT");
            dtInvoiceListInfo.Columns.Add("UNIT");

            dtInvoiceListInfo.Columns["Select"].SetOrdinal(0);
            dtInvoiceListInfo.Columns["LINE"].SetOrdinal(1);
            dtInvoiceListInfo.Columns["PRODUCT"].SetOrdinal(2);
            dtInvoiceListInfo.Columns["QTYENTERED"].SetOrdinal(3);
            dtInvoiceListInfo.Columns["QTYRECEIVED"].SetOrdinal(4);
            dtInvoiceListInfo.Columns["DOCUMENTNO"].SetOrdinal(5);

            for (int rowCounter = dtInvoiceListInfo.Rows.Count - 1; rowCounter >= 0; rowCounter--)
            {
                if (this.stExistingC_InvoiceLine_ID.Contains(dtInvoiceListInfo.Rows[rowCounter]["C_INVOICELINE_ID"].ToString()))
                {
                    dtInvoiceListInfo.Rows.RemoveAt(rowCounter);
                    continue;
                }

                dtInvoiceListInfo.Rows[rowCounter]["PRODUCT"] =
                        this.getDataFromDb.getEM_M_PRODUCTInfo(null, "",
                            dtInvoiceListInfo.Rows[rowCounter]["M_PRODUCT_ID"].ToString(),
                            false, triStateBool.ignor, triStateBool.ignor, false, "AND").Rows[0]["NAME"].ToString();

                dtInvoiceListInfo.Rows[rowCounter]["UNIT"] =
                        this.getDataFromDb.getEM_C_UOMInfo(null, "",
                                     dtInvoiceListInfo.Rows[rowCounter]["C_UOM_ID"].ToString(),
                                     false, false, "AND")
                                .Rows[0]["NAME"].ToString();

                dtInvoiceListInfo.Rows[rowCounter]["Select"] = false;
            }

            this.dtNewInvoiceItemList = dtInvoiceListInfo.Copy();
            this.dtgInvoiceItems.DataSource = this.dtNewInvoiceItemList;

            

        }



        private void dtgInvoiceItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgInvoiceItems.SelectedRows.Count < 1)
                return;

            int currentSelectedRowIndex =
                this.dtgInvoiceItems.SelectedRows[0].Index;

            if (this.dtgInvoiceItems.CurrentCell.OwningColumn.Index == 0 &&
                this.dtgInvoiceItems.CurrentCell.OwningColumn.Name == "Select" &&
                this.dtgInvoiceItems.CurrentCell.OwningColumn.HeaderText == "")
            {
                if (!(Convert.ToBoolean(this.dtgInvoiceItems.CurrentCell.Value.ToString())))
                {
                    if (selectedRowCount >= this.allowedLineCount)
                    {
                        MessageBox.Show("Selected Items Count Exceed allowed number.",
                            "Select record", MessageBoxButtons.OK,
                            MessageBoxIcon.Stop);
                        this.cmdAdd.Enabled = false;
                        return;
                    }

                    selectedRowCount++;
                }
                else
                {
                    selectedRowCount--;
                }                

                this.dtgInvoiceItems.CurrentCell.Value =
                        !(Convert.ToBoolean(this.dtgInvoiceItems.CurrentCell.Value.ToString()));
                this.dtNewInvoiceItemList.Rows[currentSelectedRowIndex]["Select"] =
                    (Convert.ToBoolean(this.dtgInvoiceItems.CurrentCell.Value.ToString()));
            }
        }


        private void ckSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int rowCounter = 0; rowCounter <= this.dtNewInvoiceItemList.Rows.Count - 1
                    && (rowCounter + existingLineCount) < this.allowedLineCount; rowCounter++)
            {
                this.dtNewInvoiceItemList.Rows[rowCounter]["Select"] =
                    !(Convert.ToBoolean(this.dtNewInvoiceItemList.Rows[rowCounter]["Select"].ToString()));
            }
        }


        private void cmdAdd_Click(object sender, EventArgs e)
        {
            int checkCount = 0;

            for (int rowCounter = this.dtNewInvoiceItemList.Rows.Count - 1; rowCounter >= 0; rowCounter--)
            {
                if (Convert.ToBoolean(this.dtNewInvoiceItemList.Rows[rowCounter]["Select"].ToString()))
                {
                    checkCount++;
                }
            }

            if ((checkCount + existingLineCount) > this.allowedLineCount)
            {
                MessageBox.Show("Selected Items Count Exceed allowed number.",
                    "Select record", MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                this.cmdAdd.Enabled = false;
                return;
            }

            for (int rowCounter = this.dtNewInvoiceItemList.Rows.Count - 1; rowCounter >= 0; rowCounter--)
            {
                if (!Convert.ToBoolean(this.dtNewInvoiceItemList.Rows[rowCounter]["Select"].ToString()))
                {
                    this.dtNewInvoiceItemList.Rows.RemoveAt(rowCounter);
                }
            }

            generalResultInformation.incomingInventorySourceInvoice = this.dtNewInvoiceItemList.Copy();
            this.Close();
        }



    }
}
