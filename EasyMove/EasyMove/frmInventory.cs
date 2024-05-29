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
    public partial class frmInventory : Form
    {
        public frmInventory()
        {
            InitializeComponent();
        }


        string stProductId = "";
        string stProductName = "";
        string stStoreID = "";

        DataTable dtProductList = new DataTable();
        DataTable dtStoreList = new DataTable();
        DataTable dtStockResult = new DataTable();

        dataBuilder getDataFromDb = new dataBuilder();
        businessRule getDataAccordingToRule = new businessRule();

        DataTable searchQuery = new DataTable();

        private void frmInventory_Load(object sender, EventArgs e)
        {

            this.searchQuery.Columns.Add("Field");
            this.searchQuery.Columns.Add("Criterion");
            this.searchQuery.Columns.Add("Value");
             
            dtStockResult.Columns.Add("Code", System.Type.GetType("System.String"));
            dtStockResult.Columns.Add("Name", System.Type.GetType("System.String"));
            dtStockResult.Columns.Add("Warehouse", System.Type.GetType("System.String"));
            dtStockResult.Columns.Add("QTYONHAND", System.Type.GetType("System.Decimal"));
            dtStockResult.Columns.Add("QTYRESERVED", System.Type.GetType("System.Decimal"));
            dtStockResult.Columns.Add("QTYORDERED", System.Type.GetType("System.Decimal"));

            this.dtgStockResult.DataSource = this.dtStockResult;

            this.dtgStockResult.Columns["QTYONHAND"].HeaderText = "On Hand";
            this.dtgStockResult.Columns["QTYRESERVED"].HeaderText = "Reserved";
            this.dtgStockResult.Columns["QTYORDERED"].HeaderText = "On Order";

            this.dtStoreList =
                this.getDataFromDb.getEM_M_LOCATORInfo(null, "", "", true, false, "AND");

            
            DataView dtView = this.dtStoreList.DefaultView;

            if (dtView.Table.Columns.Contains("VALUE"))
                dtView.Sort = "VALUE ASC";

            this.dtStoreList = dtView.ToTable();

            this.cmbStores.Items.Add("*");
            DataRow drW;

            foreach (DataRow dr in this.dtStoreList.Rows)
            {
                drW = this.searchQuery.NewRow();
                drW["Field"] = "M_LOCATOR_ID";
                drW["Criterion"] = "=";
                drW["Value"] = dr["M_LOCATOR_ID"];
                this.searchQuery.Rows.Add(drW);

                this.cmbStores.Items.Add(dr["VALUE"]);
            }

            this.cmbStores.SelectedIndex = 0;            
        }


        private void ddgProduct_SelectedItemClicked(object sender, EventArgs e)
        {
            DataTable productInformation =
                this.getDataAccordingToRule.getProducts(true, true, triStateBool.ignor, triStateBool.ignor, triStateBool.ignor, triStateBool.ignor, true,
                                    this.ddgProduct.SelectedItem, "", true);
            ddgProduct.DataSource = productInformation;
            ddgProduct.DataTablePrimaryKey =
                Convert.ToUInt16(productInformation.Columns.IndexOf("M_PRODUCT_ID"));
            ddgProduct.SelectedColomnIdex =
                productInformation.Columns.IndexOf("NAME");
            this.ddgProduct.HiddenColoumns = new int[]{ productInformation.Columns.IndexOf("C_UOM_ID"), 
                                             productInformation.Columns.IndexOf("M_PRODUCT_CATEGORY_ID")};
        }

        private void ddgProduct_selectedItemChanged(object sender, EventArgs e)
        {
            if (this.ddgProduct.SelectedRowKey == null ||
                this.ddgProduct.SelectedItem == "")
            {
                this.stProductId = "";
                this.stProductName = "";
                return;
            }
            this.stProductId = this.ddgProduct.SelectedRowKey.ToString();
            this.stProductName = this.ddgProduct.SelectedItem;                     
        }

        private void cmbStores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbStores.SelectedIndex > 0)
                this.stStoreID = this.dtStoreList.Rows[this.cmbStores.SelectedIndex - 1]["M_LOCATOR_ID"].ToString();
            else
                this.stStoreID = "";
        }
               

        private void cmdShowStock_Click(object sender, EventArgs e)
        {
            if (this.stStoreID == "" && this.stProductId == "")
                return;

            //If the selected store is empty only show stores which are in the combobox
            DataTable dtStockInfo =
                this.getDataFromDb.getV_STOCKInfo(this.stStoreID == "" ? this.searchQuery : null, "OR", this.stProductId,
                this.stStoreID, "AND");

            dtStockInfo.Columns.Remove("M_PRODUCT_ID");
            dtStockInfo.Columns.Remove("M_LOCATOR_ID");
            dtStockInfo.Columns.Remove("AD_CLIENT_ID");
            dtStockInfo.Columns.Remove("ISACTIVE");

            this.dtgStockResult.DataSource = dtStockInfo;
        }
        
    }
}
