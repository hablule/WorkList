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
    public partial class frmManualSales : Form
    {
        public frmManualSales()
        {
            InitializeComponent();
        }

        
        # region "Top Level Variables"
        /// <Top Level Variables>
        /// variable to be used accross this form
        /// <\Top Level Variables>
        /// 

        // bool
        
        // int
        int intCurrSalesDtlSelectedRowIndex = -1;
        int intCurrSalesSelectedRowIndex = -1;
        
        // Strings
        string stpriceConditionID = "";
        string stSalesID = "";
        string stBpartnerID = "";
        string stCurrentProductUOM = "";        

        // Decimals
        decimal dcCurrProductPrice = 0;
        decimal dcCurrProductTaxRate = 0;
        decimal dcCurrLinePreviousTotal = 0;
        decimal dcCurrLinePreviousTAX = 0;
        decimal dcSalesTotal = 0;
        decimal dcVatTotal = 0;
        decimal dcGrandTotal = 0;        
        
        
        // Tables
        DataTable dtExistingSales = new DataTable();
        DataTable dtNewSalesDetail = new DataTable();


        DataTable dtCustomerList = new DataTable();
        DataTable dtProductList = new DataTable();

        DataTable dtActiveOrganisations = new DataTable();
        DataTable dtActiveStores = new DataTable();

        // Others
        Color normalFieldColor = Color.Black;
        Color missingFieldColor = Color.Red;
        Color ChangedFieldColor = Color.Blue;

        DataGridViewCellStyle cancelButtonStyle = new DataGridViewCellStyle();

        dataBuilder getDataFromDb = new dataBuilder();


        #endregion



        private void newForm()
        {   
            this.intCurrSalesDtlSelectedRowIndex = -1;

            this.stpriceConditionID = "";
            this.stSalesID = "";
            this.stBpartnerID = "";
            this.stCurrentProductUOM = "";

            this.dcCurrProductPrice = 0;
            this.dcCurrProductTaxRate = 0;
            this.dcCurrLinePreviousTotal = 0;
            this.dcCurrLinePreviousTAX = 0;
            this.dcSalesTotal = 0;
            this.dcVatTotal = 0;
            this.dcGrandTotal = 0;

            this.dtNewSalesDetail.Rows.Clear();

            this.txtOrganisation.Text = "";
            if (this.cmbOrganisation.Items.Count > 0)
                this.cmbOrganisation.SelectedIndex = 0;
                        
            this.txtDocumentNo.Text = "";

            this.dtpDate.Value = DateTime.Now;
            this.txtSoldDate.Text = "";
                        
            this.ddgCustomers.SelectedRowKey = null;
            this.ddgCustomers.SelectedRow.Clear();
            this.ddgCustomers.SelectedItem = "";
            
            this.txtDescriptionMain.Text = "";                        
            
            this.ddgProduct.SelectedRowKey = null;
            this.ddgProduct.SelectedRow.Clear();
            this.ddgProduct.SelectedItem = "";
            
            this.ntbQtySold.Amount = "0";
            
            this.txtQtyInStock.Text = "0";
            this.txtTotalAmount.Text = "0";
            this.txtDescriptionDtl.Text = "";

            if (this.cmbStores.Items.Count > 0)
            {
                if (this.cmbStores.Items.Count == 2)
                {
                    this.cmbStores.SelectedIndex = 1;
                }
                else
                    this.cmbStores.SelectedIndex = 0;
            }
                       

            this.lblDocumentNo.ForeColor = normalFieldColor;
            this.lblCustomers.ForeColor = this.normalFieldColor;
            
            this.dtgSalesDtl.Columns["remove"].Visible = true;

            this.txtOrganisation.Visible = false;
            this.cmbOrganisation.Visible = true;

            this.dtpDate.Enabled = true;
            this.txtDocumentNo.Enabled = true;            
            this.txtDescriptionMain.Enabled = true;
            
            this.ddgCustomers.Enabled = true;
            
            this.ddgProduct.Enabled = false;
            this.ntbQtySold.Enabled = false;
            this.cmbStores.Enabled = false;
            this.ntbUnitPrice.Enabled = false;

            this.txtDescriptionDtl.Enabled = false;
            this.cmdAdd.Enabled = false;
                        
            this.tlsConfirm.Enabled = true;

        }

        private bool isFormComplete()
        {
            bool formIsComplete = true;

            if (this.txtDocumentNo.Text == "")
            {
                this.lblDocumentNo.ForeColor = missingFieldColor;
                formIsComplete = false;
            }
            else if (this.isDocumentInUse())
            {
                MessageBox.Show("Document Number is already in use." +
                           "\n Enter a different Document number to proceed.", "New Collection",
                           MessageBoxButtons.OKCancel, MessageBoxIcon.Information,
                           MessageBoxDefaultButton.Button1);

                this.lblDocumentNo.ForeColor = missingFieldColor;
                formIsComplete = false;
            }
            else
                this.lblDocumentNo.ForeColor = normalFieldColor;

            if (this.txtSoldDate.Text == "" || 
                this.dtpDate.Value.CompareTo(DateTime.Now) == 1)
            {
                this.lblDate.ForeColor = missingFieldColor;
                formIsComplete = false;
            }
            else
                this.lblDate.ForeColor = normalFieldColor;

            if (this.ddgCustomers.SelectedRowKey == null ||
                this.ddgCustomers.SelectedItem == "")
            {
                this.lblCustomers.ForeColor = this.missingFieldColor;
                formIsComplete = false;
            }
            else
                this.lblCustomers.ForeColor = this.normalFieldColor;


            if (this.dtgSalesDtl.Rows.Count <= 0)
            {
                this.dtgSalesDtl.BackgroundColor = this.missingFieldColor;
                formIsComplete = false;
            }
            else
                this.dtgSalesDtl.BackgroundColor = SystemColors.Control;
                        
            return formIsComplete;
        }

        private bool isDocumentInUse()
        {
            if (this.txtDocumentNo.Text == "")
                return true;

            DataTable dtSalesInfo =
                this.getDataFromDb.getSalesInfo(null, "", "", generalResultInformation.Station, 
                        this.txtDocumentNo.Text, generalResultInformation.concernedNode, 
                        "", triaStateBool.Ignor, PAYMENTRULE.ignor, 0, false, false, false, "AND");
            
            if (!this.getDataFromDb.checkIfTableContainesData(dtSalesInfo))
            {
                return false; 
            }
            else
            {
                return true; 
            }
        }

        private void enableNavigationButton()
        {
            
        }

        private void enableSalesDetail(bool enabled)
        {            
            //this.dtgReceiptDtl.Enabled = enabled;
            this.ddgProduct.Enabled = enabled;
            this.ntbQtySold.Enabled = enabled;
            this.ntbUnitPrice.Enabled = enabled;
            this.cmbStores.Enabled = enabled;
            this.txtDescriptionDtl.Enabled = enabled;
            this.cmdAdd.Enabled = enabled;
        }

        private void createDetailSalesTable()
        {
            this.dtNewSalesDetail =
                this.getDataFromDb.getSalesItemsInfo(null, "", "", "", "", 
                        triaStateBool.Ignor, "", true, "AND");

            //this.dtNewSalesDetail.Columns.Remove("id");

            this.dtNewSalesDetail.Columns.Add("remove");
            this.dtNewSalesDetail.Columns.Add("Sn");            
            this.dtNewSalesDetail.Columns.Add("Sold From");
            this.dtNewSalesDetail.Columns.Add("Total");

            this.dtNewSalesDetail.Columns["remove"].SetOrdinal(0);
            this.dtNewSalesDetail.Columns["Sn"].SetOrdinal(1);
            this.dtNewSalesDetail.Columns["item_name"].SetOrdinal(2);
            this.dtNewSalesDetail.Columns["Sold From"].SetOrdinal(3);
            this.dtNewSalesDetail.Columns["quantity"].SetOrdinal(4);
            this.dtNewSalesDetail.Columns["item_unit_price"].SetOrdinal(5);
            this.dtNewSalesDetail.Columns["Total"].SetOrdinal(6);
            

            this.dtgSalesDtl.DataSource =
                this.dtNewSalesDetail;

            this.dtgSalesDtl.Columns["z_count"].Visible = false;
            this.dtgSalesDtl.Columns["flag"].Visible = false;
            this.dtgSalesDtl.Columns["cart_line"].Visible = false;
            this.dtgSalesDtl.Columns["attribute1"].Visible = false;
            this.dtgSalesDtl.Columns["attribute1_id"].Visible = false;
            this.dtgSalesDtl.Columns["attribute2"].Visible = false;
            this.dtgSalesDtl.Columns["attribute2_id"].Visible = false;
            this.dtgSalesDtl.Columns["adj_reason"].Visible = false;
            this.dtgSalesDtl.Columns["adj_approved_by"].Visible = false;
            this.dtgSalesDtl.Columns["item_cost"].Visible = false;
            this.dtgSalesDtl.Columns["sub_total_disc"].Visible = false;
            this.dtgSalesDtl.Columns["tax_disc"].Visible = false;
            this.dtgSalesDtl.Columns["is_void"].Visible = false;
            this.dtgSalesDtl.Columns["batch_id"].Visible = false;
            this.dtgSalesDtl.Columns["dept_id"].Visible = false;            
            this.dtgSalesDtl.Columns["discount"].Visible = false;
            this.dtgSalesDtl.Columns["discount_percent"].Visible = false;
            this.dtgSalesDtl.Columns["addon"].Visible = false;
            this.dtgSalesDtl.Columns["addon_percent"].Visible = false;
            this.dtgSalesDtl.Columns["currency"].Visible = false;

            this.dtgSalesDtl.Columns["sale_id"].Visible = false;
            this.dtgSalesDtl.Columns["item_id"].Visible = false;
            this.dtgSalesDtl.Columns["batch_number"].Visible = false;
            this.dtgSalesDtl.Columns["unit_of_measure_id"].Visible = false;
            this.dtgSalesDtl.Columns["sold_from_store_id"].Visible = false;
            this.dtgSalesDtl.Columns["comment"].Visible = false;
            this.dtgSalesDtl.Columns["id"].Visible = false;
            this.dtgSalesDtl.Columns["station"].Visible = false;
            this.dtgSalesDtl.Columns["node"].Visible = false;
            this.dtgSalesDtl.Columns["tax_percent"].Visible = false;
            this.dtgSalesDtl.Columns["disc_or_add"].Visible = false;
            this.dtgSalesDtl.Columns["currency_rate"].Visible = false;
            this.dtgSalesDtl.Columns["pieces"].Visible = false;
            this.dtgSalesDtl.Columns["thickness"].Visible = false;
            this.dtgSalesDtl.Columns["width"].Visible = false;
            this.dtgSalesDtl.Columns["w_length"].Visible = false;



            this.dtgSalesDtl.Columns["remove"].HeaderText = "";
            this.dtgSalesDtl.Columns["item_name"].HeaderText = "Product";
            this.dtgSalesDtl.Columns["item_unit_price"].HeaderText = "U.Price";
            this.dtgSalesDtl.Columns["quantity"].HeaderText = "Quantity";            
            

            this.dtgSalesDtl.Columns["remove"].DefaultCellStyle = this.cancelButtonStyle;

            foreach (DataGridViewColumn columns in this.dtgSalesDtl.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DisplayIndex = columns.Index;
            }
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
                MessageBox.Show("Please Insert the missing fields before you proceed.",
                    "Save record", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                return;
            }
            

            DataTable newSalesSummary =
                this.getDataFromDb.getSalesInfo(null, "", "", "", "", 
                        "", "", triaStateBool.Ignor, true, false, false, "AND");

            DataRow drNewSalesDetail = newSalesSummary.NewRow();
            
            drNewSalesDetail["flag"] = "0";
            drNewSalesDetail["date"] = DateTime.Now.ToString("yyyy-MM-dd");
            drNewSalesDetail["time"] = DateTime.Now.ToString("HH:mm:ss");
            drNewSalesDetail["sold_date"] = this.dtpDate.Value.ToString("yyyy-MM-dd");
            drNewSalesDetail["customer_id"] = this.ddgCustomers.SelectedRowKey.ToString();
            drNewSalesDetail["customer_name"] = this.ddgCustomers.SelectedItem.ToString();
            drNewSalesDetail["customer_tin"] = 
                this.ddgCustomers.SelectedRow.Rows[0]["TIN_NUMBER"].ToString();
            drNewSalesDetail["sub_total"] = this.dcSalesTotal;
            drNewSalesDetail["total_tax"] = this.dcVatTotal;
            drNewSalesDetail["total_amount"] = this.dcSalesTotal + this.dcVatTotal;            
            drNewSalesDetail["payment_type_id"] = this.rdbCash.Checked ? 1 : 3;
            drNewSalesDetail["items_sold"] = this.dtNewSalesDetail.Rows.Count;
            drNewSalesDetail["void_count"] = 0;
            drNewSalesDetail["cashier_id"] = generalResultInformation.userId;
            drNewSalesDetail["cashier_name"] = generalResultInformation.userFullName;
            drNewSalesDetail["sales_rep_id"] = "1";
            drNewSalesDetail["ref_no"] = 
                this.getDataFromDb.getSalesInfo(null,"","",
                                generalResultInformation.Station,"",
                                generalResultInformation.concernedNode,"",
                                triaStateBool.Ignor, false, true, false,
                                "AND").Rows[0]["ref_no"].ToString();
            drNewSalesDetail["table_no"] = " ";
            drNewSalesDetail["cheque_number"] = " ";
            drNewSalesDetail["cheque_date"] = DateTime.Now.ToString("yyyy-MM-dd");
            drNewSalesDetail["reference"] = 1;
            drNewSalesDetail["voucher_type"] = this.rdbCash.Checked ? "CSI" : "CRSI";
            drNewSalesDetail["ref_note"] = this.txtDocumentNo.Text;
            drNewSalesDetail["cash_credit"] = this.rdbCash.Checked ? "cash" : "credit";            
            drNewSalesDetail["comment"] = this.txtDescriptionMain.Text;
            drNewSalesDetail["station"] = generalResultInformation.Station;
            drNewSalesDetail["node"] = generalResultInformation.concernedNode;
            
            newSalesSummary.Rows.Add(drNewSalesDetail);

            this.getDataFromDb.changeDataBaseTableData(newSalesSummary.Copy(), "sales", "INSERT", true, true);

            // If There Is A DB error Return)
            if (dbCommitFailure.dbCommitError)
            {
                this.sbStatusLabel.Text = "Record IS NOT Saved";
                this.Enabled = true;
                return;
            }

            DataTable newSales =
                this.getDataFromDb.getSalesInfo(null, "", "",
                        generalResultInformation.Station, newSalesSummary.Rows[0]["ref_note"].ToString(),
                        generalResultInformation.concernedNode,
                        newSalesSummary.Rows[0]["customer_id"].ToString(),
                        triaStateBool.no, this.rdbCash.Checked ? PAYMENTRULE.Cash : PAYMENTRULE.Credit,
                        1, false, false, false, "AND");


            if (!this.getDataFromDb.checkIfTableContainesData(newSales))
            {
                this.Enabled = true;
                this.sbStatusLabel.Text = "Record IS NOT Saved";
                return;
            }

            for (int currentDetailRecord = 0;
                 currentDetailRecord <= this.dtNewSalesDetail.Rows.Count - 1;
                 currentDetailRecord++)
            {
                this.dtNewSalesDetail.Rows[currentDetailRecord]["sale_id"] =
                    newSales.Rows[0]["id"].ToString();
                this.dtNewSalesDetail.Rows[currentDetailRecord]["node"] =
                    generalResultInformation.concernedNode;
                this.dtNewSalesDetail.Rows[currentDetailRecord]["station"] =
                    generalResultInformation.Station;
            }

            this.getDataFromDb.changeDataBaseTableData(this.dtNewSalesDetail.Copy(), "sales_items", "INSERT", true, true);

            if (dbCommitFailure.dbCommitError)
            {
                this.sbStatusLabel.Text = "Record IS NOT Saved";
                this.getDataFromDb.changeDataBaseTableData(newSales, "sales", "DELETE", true, true);
                this.Enabled = true;
                return;
            }
                        
            MessageBox.Show("New Record Saved Successfully.",
                    "Save record", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            this.Enabled = true;
            this.tlsNew_Click(sender, e);
        }
        
        private void tlsConfirm_Click(object sender, EventArgs e)
        {
            this.tlsSave_Click(sender, e);            
        }

        private void tlsSearch_Click(object sender, EventArgs e)
        {
        
        }

        private void tlsChangeView_Click(object sender, EventArgs e)
        {
           

        }


        private void tlsFirstRecord_Click(object sender, EventArgs e)
        {
            this.dtgReceiptSummary.Rows[0].Selected = true;
        }

        private void tlsPreviousRecord_Click(object sender, EventArgs e)
        {
            if (this.intCurrSalesSelectedRowIndex == -1)
            {
                if (this.dtgReceiptSummary.SelectedRows.Count < 1)
                {
                    return;
                }
                else
                    this.intCurrSalesSelectedRowIndex =
                        this.dtgReceiptSummary.SelectedRows[0].Index;
            }

            this.dtgReceiptSummary.Rows[this.intCurrSalesSelectedRowIndex - 1].Selected = true;
        }

        private void tlsNextRecord_Click(object sender, EventArgs e)
        {
            if (this.intCurrSalesSelectedRowIndex == -1)
            {
                if (this.dtgReceiptSummary.SelectedRows.Count < 1)
                {
                    return;
                }
                else
                    this.intCurrSalesSelectedRowIndex =
                        this.dtgReceiptSummary.SelectedRows[0].Index;
            }

            this.dtgReceiptSummary.Rows[this.intCurrSalesSelectedRowIndex + 1].Selected = true;
        }

        private void tlsLastRecord_Click(object sender, EventArgs e)
        {
            this.dtgReceiptSummary.Rows[this.dtgReceiptSummary.Rows.Count - 1].Selected = true;
        }


        private void tlsPrint_Click(object sender, EventArgs e)
        {
        }

        private void tlsExit_Click(object sender, EventArgs e)
        {
            this.Close();
        } 



        private void frmManualSales_Load(object sender, EventArgs e)
        {
            this.cancelButtonStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.cancelButtonStyle.BackColor = Color.FromKnownColor(KnownColor.ControlDark);
            this.cancelButtonStyle.ForeColor = Color.FromKnownColor(KnownColor.Desktop);
            this.cancelButtonStyle.SelectionForeColor = Color.FromKnownColor(KnownColor.DarkBlue);
            this.cancelButtonStyle.WrapMode = DataGridViewTriState.False;
            this.cancelButtonStyle.Font =
                new System.Drawing.Font("Microsoft Sans Serif", 8.25F,
                    System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


            this.createDetailSalesTable();

            this.enableSalesDetail(false);
            
            this.dtActiveOrganisations =
                this.getDataFromDb.getnodesInfo(null, "", "", 
                    generalResultInformation.Station, triaStateBool.yes, false, "AND");

            for (int rowCounter = 0; rowCounter <= this.dtActiveOrganisations.Rows.Count - 1; rowCounter++)
            {
                this.cmbOrganisation.Items.Add(
                    this.dtActiveOrganisations.Rows[rowCounter]["node"].ToString());
            }

            this.dtActiveStores =
                this.getDataFromDb.getStoresInfo(null, "", "", "", "",
                        triaStateBool.yes, false, "AND");
            
            this.cmbStores.Items.Add("--Select Store--");

            for (int rowCounter = 0; rowCounter <= this.dtActiveStores.Rows.Count - 1; rowCounter++)
            {
                this.cmbStores.Items.Add(
                    this.dtActiveStores.Rows[rowCounter]["store_name"].ToString());
            }

            if (this.cmbStores.Items.Count > 1)
                this.cmbStores.SelectedIndex = 0;
            else
            {
                MessageBox.Show("No Store Available.",
                    "New Sales", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                this.Close();
            }

            DataTable priceCondition =
                this.getDataFromDb.getDefaultPriceListInfo(null, "", "",
                        "", false, "AND");

            if (this.getDataFromDb.checkIfTableContainesData(priceCondition))
            {
                this.stpriceConditionID =
                    priceCondition.Rows[0]["ID"].ToString();
            }
            else
            {
                MessageBox.Show("No Default Price List.",
                    "New Sales", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                this.Close();
            }

            this.newForm();
            
        }


        private void ddgCustomer_SelectedItemClicked(object sender, EventArgs e)
        {
            this.dtCustomerList = 
                this.getDataFromDb.getCustomersInfo(null, "", "",
                        generalResultInformation.Station, 
                        generalResultInformation.concernedNode,
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

            this.dtCustomerList.Columns["customer_name"].SetOrdinal(0);
            this.dtCustomerList.Columns["tin_number"].SetOrdinal(1);
            this.dtCustomerList.Columns["phone_mobile"].SetOrdinal(2);
            this.dtCustomerList.Columns["phone_office"].SetOrdinal(3);

            this.ddgCustomers.DataSource = this.dtCustomerList;
            this.ddgCustomers.DataTablePrimaryKey =
                Convert.ToUInt16(this.dtCustomerList.Columns.IndexOf("id"));
            this.ddgCustomers.SelectedColomnIdex =
                this.dtCustomerList.Columns.IndexOf("customer_name");
        }

        private void ddgCustomer_selectedItemChanged(object sender, EventArgs e)
        { 
            if (this.ddgCustomers.SelectedRow != null &&
                this.ddgCustomers.SelectedItem != "")
            {
                this.stBpartnerID = 
                    this.ddgCustomers.SelectedRowKey.ToString();
                this.enableSalesDetail(true);
                this.label1.Text =
                    this.ddgCustomers.SelectedRow.Rows[0]["tin_number"].ToString();

            }
            else
            {
                this.stBpartnerID = "";
                this.enableSalesDetail(false);
                this.label1.Text = "";

            }
        }


        private void ddgProduct_SelectedItemClicked(object sender, EventArgs e)
        {
            this.dtProductList = 
                this.getDataFromDb.getITEMInfo(null, "", "", 
                            this.ddgProduct.SelectedItem, "","","",
                            triaStateBool.yes, false,"AND");


            this.dtProductList.Columns.Remove("item_number");
            this.dtProductList.Columns.Remove("master_id");
            this.dtProductList.Columns.Remove("model");
            this.dtProductList.Columns.Remove("size");
            this.dtProductList.Columns.Remove("color");
            this.dtProductList.Columns.Remove("default_exp_date");
            this.dtProductList.Columns.Remove("notify_before");
            this.dtProductList.Columns.Remove("description");
            this.dtProductList.Columns.Remove("brand_id");
            this.dtProductList.Columns.Remove("category_id");
            this.dtProductList.Columns.Remove("dept_id");
            this.dtProductList.Columns.Remove("supplier_id");
            this.dtProductList.Columns.Remove("sales_store_id");
            this.dtProductList.Columns.Remove("purchases_store_id");
            //this.dtProductList.Columns.Remove("tax_type_id");
            this.dtProductList.Columns.Remove("is_fast");
            //this.dtProductList.Columns.Remove("unit_id");
            this.dtProductList.Columns.Remove("item_type_id");
            this.dtProductList.Columns.Remove("is_active");
            this.dtProductList.Columns.Remove("default_pack_id");
            this.dtProductList.Columns.Remove("work_center_id");
            this.dtProductList.Columns.Remove("stock_item");
            this.dtProductList.Columns.Remove("station");
            this.dtProductList.Columns.Remove("node");

            this.ddgProduct.DataSource = 
                this.dtProductList;
            this.ddgProduct.DataTablePrimaryKey =
                Convert.ToUInt16(this.dtProductList.Columns.IndexOf("id"));
            this.ddgProduct.HiddenColoumns =
                new int[] {this.dtProductList.Columns.IndexOf("unit_id"),
                    this.dtProductList.Columns.IndexOf("tax_type_id"),
                    this.dtProductList.Columns.IndexOf("Product_id")};
            this.ddgProduct.SelectedColomnIdex =
                this.dtProductList.Columns.IndexOf("item_name");                        
        }

        private void ddgProduct_selectedItemChanged(object sender, EventArgs e)
        {   
            if (this.ddgProduct.SelectedRowKey == null ||
                this.ddgProduct.SelectedRow == null)
            {
                this.ntbQtySold.Amount = "0";
                this.ntbUnitPrice.Amount = "0";
                this.txtTotalAmount.Text = "0";
                this.txtQtyInStock.Text = "0";
                if(this.cmbStores.Items.Count > 0)
                {
                    this.cmbStores.SelectedIndex = 
                        this.cmbStores.Items.Count == 2 ? 1 : 0;
                }

                this.dcCurrProductTaxRate = 0.15M;
                this.ntbQtySold.Enabled = false;
                this.cmbStores.Enabled = false;
                this.txtDescriptionDtl.Enabled = false;
                this.cmdAdd.Enabled = false;
                return;
            }
                        
            this.ntbQtySold.Amount = "0";
            this.ntbUnitPrice.Amount = "0";
            this.txtTotalAmount.Text = "0";
            this.txtQtyInStock.Text = "0";
            if (this.cmbStores.Items.Count > 0)
            {
                this.cmbStores.SelectedIndex =
                    this.cmbStores.Items.Count == 2 ? 1 : 0;
            }

            DataTable UOM = 
                this.getDataFromDb.getITEM_UNITInfo(null, "", "",
                        this.ddgProduct.SelectedRow.Rows[0]["unit_id"].ToString(),
                        "", "", triaStateBool.Ignor, false, "AND");
            
            if (this.getDataFromDb.checkIfTableContainesData(UOM))
            {
                this.ntbQtySold.StandardPrecision =
                    int.Parse(UOM.Rows[0]["precision"].ToString());
                this.stCurrentProductUOM =
                    UOM.Rows[0]["abbr"].ToString();
            }

            DataTable TaxRate = this.getDataFromDb.getTaxTypesInfo(null, "", "",
                this.ddgProduct.SelectedRow.Rows[0]["tax_type_id"].ToString(), "", "",
                triaStateBool.Ignor, false, "AND");

            if (this.getDataFromDb.checkIfTableContainesData(TaxRate))
                this.dcCurrProductTaxRate =
                    decimal.Parse(TaxRate.Rows[0]["tax_percent"].ToString()) / 100;
            else
                this.dcCurrProductTaxRate = 0.15M;

            DataTable productPrice =
                this.getDataFromDb.getPriceLevelsInfo(null, "",
                    this.ddgProduct.SelectedRowKey.ToString(), stpriceConditionID,
                    "", "", "", false, "AND");

            if (this.getDataFromDb.checkIfTableContainesData(productPrice))
                this.dcCurrProductPrice =
                    decimal.Parse(productPrice.Rows[0]["price"].ToString());
            else
                this.dcCurrProductPrice = 0m;

            this.ntbUnitPrice.Amount = Math.Round(this.dcCurrProductPrice,2).ToString();

            if (this.cmbStores.SelectedIndex > 0)
            {
                DataTable stock =
                    this.getDataFromDb.getV_STOCKInfo(null, "",
                        this.ddgProduct.SelectedRow.Rows[0]["Product_id"].ToString(),
                        this.dtActiveStores.Rows[this.cmbStores.SelectedIndex - 1]["store_number"].ToString(), "AND");

                if (this.getDataFromDb.checkIfTableContainesData(stock))
                    this.txtQtyInStock.Text =
                        decimal.Parse(stock.Rows[0]["QTYONHAND"].ToString()).ToString("N02");
                else
                    this.txtQtyInStock.Text = "0";
            }

            this.ntbQtySold.Enabled = true;
            this.ntbUnitPrice.Enabled = true;
            this.cmbStores.Enabled = true;
            this.txtDescriptionDtl.Enabled = true;
            this.cmdAdd.Enabled = true;
        }
        

        private void cmdAkdd_Click(object sender, EventArgs e)
        {
            if (this.cmbStores.Items.Count <= 0 || 
                this.cmbStores.SelectedIndex == 0)
            {
                MessageBox.Show("Select Store.",
                    "New Sales", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                return;
            }

            if(decimal.Parse(this.ntbQtySold.Amount) == 0)
            {
                MessageBox.Show("Enter Qty Sold.",
                    "New Sales", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                return;
            }

            if (decimal.Parse(this.ntbUnitPrice.Amount) == 0)
            {
                MessageBox.Show("Enter Sales Price.",
                    "New Sales", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                return;
            }


            if (this.cmdAdd.Text == "Modify")
            {
                this.dcSalesTotal -=
                    this.dcCurrLinePreviousTotal;
                this.dcVatTotal -=
                    this.dcCurrLinePreviousTAX;
                                
                this.dtNewSalesDetail.Rows[this.intCurrSalesDtlSelectedRowIndex]["Sold From"] =
                    this.cmbStores.SelectedItem.ToString();
                this.dtNewSalesDetail.Rows[this.intCurrSalesDtlSelectedRowIndex]["Total"] =
                    this.txtTotalAmount.Text;

                this.dtNewSalesDetail.Rows[this.intCurrSalesDtlSelectedRowIndex]["item_id"] =
                    this.ddgProduct.SelectedRowKey.ToString();
                this.dtNewSalesDetail.Rows[this.intCurrSalesDtlSelectedRowIndex]["item_name"] =
                    this.ddgProduct.SelectedItem;
                this.dtNewSalesDetail.Rows[this.intCurrSalesDtlSelectedRowIndex]["unit_of_measure"] =
                    this.stCurrentProductUOM;
                this.dtNewSalesDetail.Rows[this.intCurrSalesDtlSelectedRowIndex]["unit_of_measure_id"] =
                    this.ddgProduct.SelectedRow.Rows[0]["unit_id"].ToString();
                this.dtNewSalesDetail.Rows[this.intCurrSalesDtlSelectedRowIndex]["quantity"] =
                    this.ntbQtySold.Amount;
                this.dtNewSalesDetail.Rows[this.intCurrSalesDtlSelectedRowIndex]["sold_from_store_id"] =
                    int.Parse(this.dtActiveStores.Rows[this.cmbStores.SelectedIndex - 1]["id"].ToString());
                this.dtNewSalesDetail.Rows[this.intCurrSalesDtlSelectedRowIndex]["item_unit_price"] =
                    this.dcCurrProductPrice;
                this.dtNewSalesDetail.Rows[this.intCurrSalesDtlSelectedRowIndex]["price_adj_amount"] =
                    decimal.Parse(this.ntbUnitPrice.Amount);
                this.dtNewSalesDetail.Rows[this.intCurrSalesDtlSelectedRowIndex]["item_tax_amount"] =
                    decimal.Parse(this.txtTotalAmount.Text) * this.dcCurrProductTaxRate;
                this.dtNewSalesDetail.Rows[this.intCurrSalesDtlSelectedRowIndex]["comment"] =
                    this.txtDescriptionDtl.Text;
                this.dtNewSalesDetail.Rows[this.intCurrSalesDtlSelectedRowIndex]["tax_percent"] =
                    this.dcCurrProductTaxRate * 100;
                
            }
            else
            {
                DataRow drNewSalesDetail = this.dtNewSalesDetail.NewRow();
                
                drNewSalesDetail["remove"] = "remove";
                drNewSalesDetail["Sn"] =
                    this.dtNewSalesDetail.Rows.Count + 1;                
                drNewSalesDetail["Sold From"] =
                    this.cmbStores.SelectedItem.ToString();
                drNewSalesDetail["Total"] =
                    this.txtTotalAmount.Text;

                drNewSalesDetail["item_id"] = 
                    this.ddgProduct.SelectedRowKey.ToString();
                drNewSalesDetail["batch_number"] = " ";
                drNewSalesDetail["item_name"] = 
                    this.ddgProduct.SelectedItem;
                drNewSalesDetail["unit_of_measure"] = 
                    this.stCurrentProductUOM;
                drNewSalesDetail["unit_of_measure_id"] = 
                    this.ddgProduct.SelectedRow.Rows[0]["unit_id"].ToString();
                drNewSalesDetail["quantity"] = 
                    this.ntbQtySold.Amount;
                drNewSalesDetail["sold_from_store_id"] =
                    int.Parse(this.dtActiveStores.Rows[this.cmbStores.SelectedIndex - 1]["id"].ToString());
                drNewSalesDetail["item_unit_price"] =
                    decimal.Parse(this.ntbUnitPrice.Amount);
                drNewSalesDetail["price_adj_amount"] =
                    Math.Round(this.dcCurrProductPrice - decimal.Parse(this.ntbUnitPrice.Amount), 4);
                drNewSalesDetail["item_tax_amount"] = 
                    decimal.Parse(this.txtTotalAmount.Text) * this.dcCurrProductTaxRate;
                drNewSalesDetail["comment"] = 
                    this.txtDescriptionDtl.Text;
                drNewSalesDetail["station"] = 
                    int.Parse(generalResultInformation.Station);
                drNewSalesDetail["node"] = 
                    int.Parse(generalResultInformation.concernedNode);
                drNewSalesDetail["tax_percent"] =
                    this.dcCurrProductTaxRate * 100;
                drNewSalesDetail["disc_or_add"] = " ";
                drNewSalesDetail["currency_rate"] = 1;
                drNewSalesDetail["pieces"] = " ";
                drNewSalesDetail["thickness"] = " ";
                drNewSalesDetail["width"] = " ";
                drNewSalesDetail["w_length"] = " ";
               
                this.dtNewSalesDetail.Rows.Add(drNewSalesDetail);                
            }

            this.dcSalesTotal +=
                decimal.Parse(this.txtTotalAmount.Text);
            this.dcVatTotal +=
                decimal.Parse(this.txtTotalAmount.Text) * this.dcCurrProductTaxRate;

            this.dcGrandTotal = this.dcSalesTotal + this.dcVatTotal;
                        
            
            this.ddgProduct.SelectedItem = "";
            this.ddgProduct.SelectedRow.Clear();
            this.ddgProduct.SelectedRowKey = null;

            this.ddgProduct_selectedItemChanged(sender, e);

            this.txtDescriptionDtl.Text = "";

            this.cmdAdd.Text = "ADD";

            this.showSalesTotals();            
        }


        private void dtgReceiptSummary_CellClick(object sender, EventArgs e)
        {
                        
        }
        
        private void dtgReceiptSummary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dtgReceiptSummary_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dtgReceiptSummary_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }


        private void dtgSalesDtl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgSalesDtl.SelectedRows.Count < 1 ||
                this.dtgSalesDtl.Enabled == false)
            {
                return;
            }
            if (this.dtgSalesDtl.Columns["remove"].Visible == false)
                return;

            this.intCurrSalesDtlSelectedRowIndex =
                this.dtgSalesDtl.SelectedRows[0].Index;

            if (this.dtgSalesDtl.CurrentCell != null)
            {
                if (this.dtgSalesDtl.CurrentCell.OwningColumn.Index == 0 &&
                    this.dtgSalesDtl.CurrentCell.OwningColumn.Name == "remove" &&
                    this.dtgSalesDtl.CurrentCell.Value.ToString() == "remove" &&
                    this.dtgSalesDtl.CurrentCell.OwningColumn.HeaderText == "")
                {
                    this.dcSalesTotal -=
                        decimal.Parse(this.dtNewSalesDetail.Rows[intCurrSalesDtlSelectedRowIndex]["Total"].ToString());

                    this.dcVatTotal -=
                        decimal.Parse(this.dtNewSalesDetail.Rows[intCurrSalesDtlSelectedRowIndex]["item_tax_amount"].ToString());

                    this.dcGrandTotal = this.dcSalesTotal + this.dcVatTotal;

                    this.dtNewSalesDetail.Rows.RemoveAt(intCurrSalesDtlSelectedRowIndex);

                    this.ddgProduct.SelectedRowKey = null;
                    this.ddgProduct.SelectedItem = "";
                    this.ddgProduct.SelectedRow.Clear();
                    this.ddgProduct_selectedItemChanged(sender, e);

                    this.cmdAdd.Text = "ADD";
                    this.intCurrSalesDtlSelectedRowIndex = -1;
                    
                    this.showSalesTotals();
                }
                //else
                //{
                //    this.cmdAdd.Text = "Modify";

                //    this.ddgProduct.SelectedRowKey =
                //        this.dtgSalesDtl.Rows[intCurrSalesDtlSelectedRowIndex].
                //            Cells["item_id"].Value.ToString();
                //    this.ddgProduct.SelectedItem =
                //        this.dtgSalesDtl.Rows[intCurrSalesDtlSelectedRowIndex].
                //            Cells["item_name"].Value.ToString();


                //    //this.ddgProduct_selectedItemChanged(sender, e);

                //    this.dcCurrLinePreviousTotal =
                //        decimal.Parse(this.dtgSalesDtl.Rows[intCurrSalesDtlSelectedRowIndex].
                //            Cells["Total"].Value.ToString());

                //    this.dcCurrLinePreviousTAX =
                //        decimal.Parse(this.dtgSalesDtl.Rows[intCurrSalesDtlSelectedRowIndex].
                //            Cells["item_tax_amount"].Value.ToString());


                //    this.ntbQtySold.Amount =
                //        this.dtgSalesDtl.Rows[intCurrSalesDtlSelectedRowIndex].
                //            Cells["quantity"].Value.ToString();

                //    this.ntbUnitPrice.Text =
                //        this.dtgSalesDtl.Rows[intCurrSalesDtlSelectedRowIndex].
                //            Cells["item_unit_price"].Value.ToString();

                //    this.calculateTotal();

                //    this.txtDescriptionDtl.Text =
                //        this.dtgSalesDtl.Rows[intCurrSalesDtlSelectedRowIndex].
                //            Cells["comment"].Value.ToString();

                //    for (int rowCounter = 0; rowCounter <= this.dtActiveStores.Rows.Count - 1; rowCounter++)
                //    {
                //        if (this.dtActiveStores.Rows[rowCounter]["id"].ToString() ==
                //            this.dtgSalesDtl.Rows[intCurrSalesDtlSelectedRowIndex].
                //                Cells["sold_from_store_id"].Value.ToString())
                //        {
                //            this.cmbStores.SelectedIndex = rowCounter + 1;
                //            break;
                //        }
                //    }

                //    this.ntbQtySold.Enabled = true;
                //    this.ntbUnitPrice.Enabled = true;
                //    this.cmbStores.Enabled = true;
                //    this.txtDescriptionDtl.Enabled = true;                    
                //    this.cmdAdd.Enabled = true;
                    
                //}
            }

        }


        private void calculateTotal()
        {
            this.txtTotalAmount.Text =
                (decimal.Parse(this.ntbQtySold.Amount) * 
                decimal.Parse(this.ntbUnitPrice.Amount)).ToString("N02");
        }

        private void showSalesTotals()
        {
            this.txtSubTotal.Text = this.dcSalesTotal.ToString("N02");
            this.txtVatTotal.Text = this.dcVatTotal.ToString("N02");
            this.txtGrandTotal.Text = this.dcGrandTotal.ToString("N02");
        }

        private void ntbAmountPaid_Leave(object sender, EventArgs e)
        {
            this.calculateTotal();
        }

        private void ntbQtySold_Leave(object sender, EventArgs e)
        {
            this.calculateTotal();
        }

        private void cmbStores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddgProduct.SelectedRowKey != null &&
                this.ddgProduct.SelectedRow != null)
            {
                DataTable stock =
                    this.getDataFromDb.getV_STOCKInfo(null, "",
                        this.ddgProduct.SelectedRow.Rows[0]["Product_id"].ToString(),
                        this.dtActiveStores.Rows[this.cmbStores.SelectedIndex - 1]["store_number"].ToString(), "AND");

                if (this.getDataFromDb.checkIfTableContainesData(stock))
                    this.txtQtyInStock.Text =
                        decimal.Parse(stock.Rows[0]["QTYONHAND"].ToString()).ToString("N02");
                else
                    this.txtQtyInStock.Text = "0";
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            this.txtSoldDate.Text = this.dtpDate.Value.ToString("dd-MMM-yyyy");
        }

        private void cmdNewCustomer_Click(object sender, EventArgs e)
        {
            generalResultInformation.CustomerID = "";

            this.label1.Text = "";

            this.ddgCustomers.SelectedRowKey = null;
            this.ddgCustomers.SelectedRow.Clear();
            this.ddgCustomers.SelectedItem = "";

            //this.ddgCustomer_selectedItemChanged(sender, e);

            frmNewCustomer newCustomer = new frmNewCustomer();
            newCustomer.TopMost = true;
            newCustomer.ShowDialog();

            if (generalResultInformation.CustomerID == "")
            {
                return;
            }

            DataTable CustomerInfo =
                this.getDataFromDb.getCustomersInfo(null, "",
                    generalResultInformation.CustomerID, 
                    generalResultInformation.Station, 
                    generalResultInformation.concernedNode, "", 
                    triaStateBool.Ignor, false, "AND");

            CustomerInfo.Columns.Remove("email");
            CustomerInfo.Columns.Remove("country");
            CustomerInfo.Columns.Remove("city");
            CustomerInfo.Columns.Remove("sub_city");
            CustomerInfo.Columns.Remove("kebele");
            CustomerInfo.Columns.Remove("house_number");
            CustomerInfo.Columns.Remove("is_regular");
            CustomerInfo.Columns.Remove("insert_user_id");
            CustomerInfo.Columns.Remove("update_user_id");
            CustomerInfo.Columns.Remove("insert_date");
            CustomerInfo.Columns.Remove("update_date");
            CustomerInfo.Columns.Remove("is_active");
            CustomerInfo.Columns.Remove("station");
            CustomerInfo.Columns.Remove("node");
            CustomerInfo.Columns.Remove("customerID");
            CustomerInfo.Columns.Remove("customer_category");
            CustomerInfo.Columns.Remove("account_no");
            CustomerInfo.Columns.Remove("customer_group");
            CustomerInfo.Columns.Remove("customer_department");
            CustomerInfo.Columns.Remove("comment");

            CustomerInfo.Columns["customer_name"].SetOrdinal(0);
            CustomerInfo.Columns["tin_number"].SetOrdinal(1);
            CustomerInfo.Columns["phone_mobile"].SetOrdinal(2);
            CustomerInfo.Columns["phone_office"].SetOrdinal(3);

            this.ddgCustomers.DataSource = 
                CustomerInfo;
            this.ddgCustomers.SelectedRow = 
                CustomerInfo;
            this.ddgCustomers.SelectedItem = 
                CustomerInfo.Rows[0]["customer_name"].ToString();
            this.ddgCustomers.SelectedRowKey =
                CustomerInfo.Rows[0]["id"].ToString();
            this.ddgCustomers.DataTablePrimaryKey =
                Convert.ToUInt16(CustomerInfo.Columns.IndexOf("id"));
            this.ddgCustomers.SelectedColomnIdex =
                CustomerInfo.Columns.IndexOf("customer_name");

            this.stBpartnerID =
                    this.ddgCustomers.SelectedRowKey.ToString();
            this.enableSalesDetail(true);
            this.label1.Text =
                this.ddgCustomers.SelectedRow.Rows[0]["tin_number"].ToString();
        }

        private void txtDocumentNo_Leave(object sender, EventArgs e)
        {
            this.txtDocumentNo.Text =
                this.txtDocumentNo.Text.ToLower().EndsWith("m") ? 
                    this.txtDocumentNo.Text.ToLower() :
                    this.txtDocumentNo.Text + "m";

            Match match = Regex.Match(this.txtDocumentNo.Text, @"^\d{3,}m$");

            if (match.Success)
            {
                if (!(match.Value.Equals(this.txtDocumentNo.Text)))
                {
                    MessageBox.Show("Document Number Should be in the following Exact patter. {######m}\n" +
                        "Please check and and correct the Document number entered",
                        "Manual Sales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtDocumentNo.Text = "";
                    return;
                }
            }
            else
            {
                MessageBox.Show("Document Number Should be in the following Exact patter. {######m}\n" +
                        "Please check and and correct the Document number entered",
                        "Manual Sales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtDocumentNo.Text = "";
                return;
            }

            DataTable salesInfo = this.getDataFromDb.getSalesInfo(null, "", "",
                    generalResultInformation.Station, this.txtDocumentNo.Text,
                    generalResultInformation.concernedNode, "",
                    triaStateBool.Ignor, false, false, false, "AND");

            if (this.getDataFromDb.checkIfTableContainesData(salesInfo))
            {
                MessageBox.Show("Document Number  -- " +
                                salesInfo.Rows[0]["ref_note"].ToString() +
                                " -- is already in use on Sales dated " +
                                DateTime.Parse(salesInfo.Rows[0]["sold_date"].ToString()).ToString("dd-MMM-yyyy") +
                                "\n Please use different Document number",
                        "Manual Sales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtDocumentNo.Text = "";
                return;
            }
        }
                

    }
}
