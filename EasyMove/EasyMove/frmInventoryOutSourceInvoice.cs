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
    public partial class frmInventoryOutSourceInvoice : Form
    {
        public frmInventoryOutSourceInvoice()
        {
            InitializeComponent();
        }


        public string stBpartnerId = "";
        public string stWareHoseId = "";

        public int allowedLineCount = 0;
        int selectedRowCount = 0;

        DataTable dtBPOrderList = new DataTable();
        DataTable dtNewOrderItemList = new DataTable();

        public DataTable dtExistingOrderItemList = new DataTable();


        dataBuilder getDataFromDb = new dataBuilder();


       
        private void frmInventoryOutSourceInvoice_Load(object sender, EventArgs e)
        {
            if (this.stBpartnerId == "")
            {
                return;
            }

            if (this.stWareHoseId == "")
            {
                return;
            }

            generalResultInformation.OutgoingInventorySourceInvoice.Clear();

            this.dtNewOrderItemList =
                this.getDataFromDb.getV_SALESORDERDETAILInfo(null, "", "", "", "",
                            "", "", "", "", "", false, true, "AND", "", "");

            this.dtNewOrderItemList.Columns.
                    Add("Select", Type.GetType("System.Boolean"));
            //this.dtNewOrderItemList.Columns.Add("PRODUCT");
            //this.dtNewOrderItemList.Columns.Add("UNIT");

            this.dtNewOrderItemList.Columns["Select"].SetOrdinal(0);
            this.dtNewOrderItemList.Columns["DELIVERYORDERNO"].SetOrdinal(1);
            this.dtNewOrderItemList.Columns["LINE"].SetOrdinal(2);
            this.dtNewOrderItemList.Columns["PRODUCT"].SetOrdinal(3);
            this.dtNewOrderItemList.Columns["QTYORDERED"].SetOrdinal(4);
            this.dtNewOrderItemList.Columns["QTYDELIVERED"].SetOrdinal(5);
            this.dtNewOrderItemList.Columns["QTYRESERVED"].SetOrdinal(6);
            this.dtNewOrderItemList.Columns["UNIT"].SetOrdinal(7);
            this.dtNewOrderItemList.Columns["DOCUMENTNO"].SetOrdinal(8);
            this.dtNewOrderItemList.Columns["DATEORDERED"].SetOrdinal(9);
            
            
            this.dtgInvoiceItems.DataSource = this.dtNewOrderItemList;

            foreach (DataGridViewColumn columns in this.dtgInvoiceItems.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DisplayIndex = columns.Index;
            }

            this.dtgInvoiceItems.Columns["C_ORDER_ID"].Visible = false;
            this.dtgInvoiceItems.Columns["C_BPARTNER_ID"].Visible = false;
            this.dtgInvoiceItems.Columns["DOCSTATUS"].Visible = false;
            this.dtgInvoiceItems.Columns["PROCESSING"].Visible = false;
            this.dtgInvoiceItems.Columns["PROCESSED"].Visible = false;
            this.dtgInvoiceItems.Columns["ISACTIVE"].Visible = false;
            this.dtgInvoiceItems.Columns["C_ORDERLINE_ID"].Visible = false;
            this.dtgInvoiceItems.Columns["M_PRODUCT_ID"].Visible = false;
            this.dtgInvoiceItems.Columns["C_UOM_ID"].Visible = false;
            this.dtgInvoiceItems.Columns["M_WAREHOUSE_ID"].Visible = false;

            this.dtgInvoiceItems.Columns["Select"].HeaderText = "";
            this.dtgInvoiceItems.Columns["DELIVERYORDERNO"].HeaderText = "DO No.";
            this.dtgInvoiceItems.Columns["LINE"].HeaderText = "Sn";
            this.dtgInvoiceItems.Columns["PRODUCT"].HeaderText = "Product";
            this.dtgInvoiceItems.Columns["QTYORDERED"].HeaderText = "Ordered";
            this.dtgInvoiceItems.Columns["QTYDELIVERED"].HeaderText = "Dispatched";
            this.dtgInvoiceItems.Columns["QTYRESERVED"].HeaderText = "Reserved";
            this.dtgInvoiceItems.Columns["DOCUMENTNO"].HeaderText = "Sales No";
            this.dtgInvoiceItems.Columns["DATEORDERED"].HeaderText = "Sales Date";



            this.dtBPOrderList =
                this.getDataFromDb.getV_SALESORDERDETAILInfo(null, "", "", this.stBpartnerId,
                            "", "", "", this.stWareHoseId, "", "", true, false, "AND",
                            "QTYORDERED > QTYDELIVERED", "AND");

            this.dtBPOrderList.Columns.RemoveAt(this.dtBPOrderList.Columns.IndexOf("C_BPARTNER_ID"));
            this.dtBPOrderList.Columns.RemoveAt(this.dtBPOrderList.Columns.IndexOf("C_ORDER_ID"));
            this.dtBPOrderList.Columns.RemoveAt(this.dtBPOrderList.Columns.IndexOf("M_WAREHOUSE_ID"));
            this.dtBPOrderList.Columns.RemoveAt(this.dtBPOrderList.Columns.IndexOf("DOCUMENTNO"));
            this.dtBPOrderList.Columns.RemoveAt(this.dtBPOrderList.Columns.IndexOf("DATEORDERED"));
            this.dtBPOrderList.Columns.RemoveAt(this.dtBPOrderList.Columns.IndexOf("C_ORDERLINE_ID"));
            this.dtBPOrderList.Columns.RemoveAt(this.dtBPOrderList.Columns.IndexOf("ISACTIVE"));
            this.dtBPOrderList.Columns.RemoveAt(this.dtBPOrderList.Columns.IndexOf("DOCSTATUS"));
            this.dtBPOrderList.Columns.RemoveAt(this.dtBPOrderList.Columns.IndexOf("PROCESSING"));
            this.dtBPOrderList.Columns.RemoveAt(this.dtBPOrderList.Columns.IndexOf("PROCESSED"));
            this.dtBPOrderList.Columns.RemoveAt(this.dtBPOrderList.Columns.IndexOf("LINE"));
            this.dtBPOrderList.Columns.RemoveAt(this.dtBPOrderList.Columns.IndexOf("M_PRODUCT_ID"));
            this.dtBPOrderList.Columns.RemoveAt(this.dtBPOrderList.Columns.IndexOf("C_UOM_ID"));
            this.dtBPOrderList.Columns.RemoveAt(this.dtBPOrderList.Columns.IndexOf("QTYORDERED"));
            this.dtBPOrderList.Columns.RemoveAt(this.dtBPOrderList.Columns.IndexOf("QTYDELIVERED"));
            this.dtBPOrderList.Columns.RemoveAt(this.dtBPOrderList.Columns.IndexOf("QTYRESERVED"));

                       
            this.dtBPOrderList =
                this.getDataFromDb.clearRedundantRow(this.dtBPOrderList, "DELIVERYORDERNO");

            this.dtBPOrderList.Columns.Add("ID");

            for (int rowCounter = 0; rowCounter <= this.dtBPOrderList.Rows.Count - 1; rowCounter++)
            {
                this.dtBPOrderList.Rows[rowCounter]["ID"] =
                    this.dtBPOrderList.Rows[rowCounter]["DELIVERYORDERNO"]; 
            }

        }


        private void ddgInvoice_SelectedItemClicked(object sender, EventArgs e)
        {
            ddgInvoice.DataSource = 
                this.dtBPOrderList.Copy();
            ddgInvoice.DataTablePrimaryKey =
                Convert.ToUInt16(this.dtBPOrderList.Columns.IndexOf("ID"));
            ddgInvoice.SelectedColomnIdex =
                this.dtBPOrderList.Columns.IndexOf("DELIVERYORDERNO");
        }

        private void ddgInvoice_selectedItemChanged(object sender, EventArgs e)
        {
            if (ddgInvoice.SelectedRowKey == null)
            {
                this.dtNewOrderItemList.Clear();
            }

            DataTable dtInvoiceListInfo =
                this.getDataFromDb.getV_SALESORDERDETAILInfo(null, "", "", this.stBpartnerId, "",
                        this.ddgInvoice.SelectedRow.Rows[0]["DELIVERYORDERNO"].ToString(),
                        "", this.stWareHoseId, "", "", false, false, "AND",
                        "QTYORDERED > QTYDELIVERED", "AND");

            dtInvoiceListInfo.Columns.
                   Add("Select", Type.GetType("System.Boolean"));
            //dtInvoiceListInfo.Columns.Add("PRODUCT");
            //dtInvoiceListInfo.Columns.Add("UNIT");

            dtInvoiceListInfo.Columns["Select"].SetOrdinal(0);
            dtInvoiceListInfo.Columns["DELIVERYORDERNO"].SetOrdinal(1);
            dtInvoiceListInfo.Columns["LINE"].SetOrdinal(2);
            dtInvoiceListInfo.Columns["PRODUCT"].SetOrdinal(3);
            dtInvoiceListInfo.Columns["QTYORDERED"].SetOrdinal(4);
            dtInvoiceListInfo.Columns["QTYDELIVERED"].SetOrdinal(5);
            dtInvoiceListInfo.Columns["QTYRESERVED"].SetOrdinal(6);
            dtInvoiceListInfo.Columns["UNIT"].SetOrdinal(7);
            dtInvoiceListInfo.Columns["DOCUMENTNO"].SetOrdinal(8);
            dtInvoiceListInfo.Columns["DATEORDERED"].SetOrdinal(9);

           
            for (int rowCounter = dtInvoiceListInfo.Rows.Count - 1; rowCounter >= 0; rowCounter--)
            {  
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

            this.dtNewOrderItemList = dtInvoiceListInfo.Copy();
            this.dtgInvoiceItems.DataSource = this.dtNewOrderItemList;            

        }



        private void dtgInvoiceItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgInvoiceItems.SelectedRows.Count < 1)
                return;

            this.cmdAdd.Enabled = true;

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
                this.dtNewOrderItemList.Rows[currentSelectedRowIndex]["Select"] =
                    (Convert.ToBoolean(this.dtgInvoiceItems.CurrentCell.Value.ToString()));
            }
        }


        private void ckSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int rowCounter = 0; 
                rowCounter <= this.dtNewOrderItemList.Rows.Count - 1 && rowCounter < this.allowedLineCount; rowCounter++)
            {
                this.dtNewOrderItemList.Rows[rowCounter]["Select"] =
                    !(Convert.ToBoolean(this.dtNewOrderItemList.Rows[rowCounter]["Select"].ToString()));                
            }
        }


        private void cmdAdd_Click(object sender, EventArgs e)
        {
            int checkCount = 0;

            for (int rowCounter = this.dtNewOrderItemList.Rows.Count - 1; rowCounter >= 0; rowCounter--)
            {
                if (Convert.ToBoolean(this.dtNewOrderItemList.Rows[rowCounter]["Select"].ToString()))
                {
                    checkCount++;
                }
            }

            if (checkCount > this.allowedLineCount)
            {
                MessageBox.Show("Selected Items Count Exceed allowed number.",
                    "Select record", MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                this.cmdAdd.Enabled = false;
                return;
            }

            for (int rowCounter = this.dtNewOrderItemList.Rows.Count - 1; rowCounter >= 0; rowCounter--)
            {
                if (!Convert.ToBoolean(this.dtNewOrderItemList.Rows[rowCounter]["Select"].ToString()))
                {
                    this.dtNewOrderItemList.Rows.RemoveAt(rowCounter);
                }
            }           

            generalResultInformation.OutgoingInventorySourceInvoice = this.dtNewOrderItemList.Copy();
            this.Close();
        }

    }
}
