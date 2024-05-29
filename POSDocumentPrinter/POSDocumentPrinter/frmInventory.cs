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
                this.getDataFromDb.getStoresInfo(null, "", "", "", "", 
                triaStateBool.Ignor, false, "AND");

            
            DataView dtView = this.dtStoreList.DefaultView;

            if (dtView.Table.Columns.Contains("store_name"))
                dtView.Sort = "store_name ASC";

            this.dtStoreList = dtView.ToTable();

            this.cmbStores.Items.Add("*");
            DataRow drW;

            foreach (DataRow dr in this.dtStoreList.Rows)
            {
                drW = this.searchQuery.NewRow();
                drW["Field"] = "M_LOCATOR_ID";
                drW["Criterion"] = "=";
                drW["Value"] = dr["store_number"];
                this.searchQuery.Rows.Add(drW);

                this.cmbStores.Items.Add(dr["store_name"]);
            }

            this.cmbStores.SelectedIndex = 0;

            this.cmdActivate.Enabled = false;
        }


        private void ddgProduct_SelectedItemClicked(object sender, EventArgs e)
        {
            this.cmdActivate.Enabled = false;
            DataTable productInformation =
                this.getDataFromDb.getITEMInfo(null, "", "",this.ddgProduct.SelectedItem,  "" , "", "" , 
                    triaStateBool.Ignor, false, "AND");

            productInformation.Columns.Remove("master_id");
            productInformation.Columns.Remove("model");
            productInformation.Columns.Remove("size");
            productInformation.Columns.Remove("color");
            productInformation.Columns.Remove("default_exp_date");
            productInformation.Columns.Remove("notify_before");
            productInformation.Columns.Remove("description");
            productInformation.Columns.Remove("brand_id");
            productInformation.Columns.Remove("category_id");
            productInformation.Columns.Remove("dept_id");
            productInformation.Columns.Remove("supplier_id");
            productInformation.Columns.Remove("sales_store_id");
            productInformation.Columns.Remove("purchases_store_id");
            productInformation.Columns.Remove("tax_type_id");
            productInformation.Columns.Remove("is_fast");
            productInformation.Columns.Remove("unit_id");
            productInformation.Columns.Remove("item_type_id");
            productInformation.Columns.Remove("is_active");
            productInformation.Columns.Remove("default_pack_id");
            productInformation.Columns.Remove("work_center_id");
            productInformation.Columns.Remove("stock_item");
            //productInformation.Columns.Remove("Product_id");
            productInformation.Columns.Remove("id");
            productInformation.Columns.Remove("station");
            productInformation.Columns.Remove("node");

            productInformation.Columns["item_number"].SetOrdinal(0);
            productInformation.Columns["item_name"].SetOrdinal(1);
            
            ddgProduct.DataSource = productInformation;
            ddgProduct.DataTablePrimaryKey = Convert.ToUInt16(productInformation.Columns.IndexOf("Product_id"));
            ddgProduct.SelectedColomnIdex = productInformation.Columns.IndexOf("item_name");
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
            this.cmdActivate.Enabled = true;            
        }

        private void cmbStores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbStores.SelectedIndex > 0)
                this.stStoreID = 
                    this.dtStoreList.Rows[this.cmbStores.SelectedIndex - 1]["STORE_NUMBER"].ToString();
            else
                this.stStoreID = "";
        }

        private void cmdActivate_Click(object sender, EventArgs e)
        {
            if (this.stProductId == "")
                return;

            generalResultInformation.ProductName = this.stProductName;

            this.Enabled = false;
            frmValidateSecurityKey activateProduct = new frmValidateSecurityKey();
            activateProduct.TopMost = true;
            activateProduct.ShowDialog();

            if (generalResultInformation.securityPassKeyCorrect)
            {
                string sql = "UPDATE ITEMS SET IS_ACTIVE = 1 WHERE PRODUCT_ID = " + this.stProductId;

                this.getDataFromDb.executeSqlOnPOS(sql);

                MessageBox.Show("Product has been Activated.", "Stock",
                    MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }            

            this.Enabled = true;
            this.Close();
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
