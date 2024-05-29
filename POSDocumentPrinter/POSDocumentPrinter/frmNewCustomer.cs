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
    public partial class frmNewCustomer : Form
    {
        public frmNewCustomer()
        {
            InitializeComponent();
        }

        string logicalConnector = "AND";

        DataTable dtCustomerInfo;

        DataTable searchQuery = new DataTable();


        dataBuilder getDataFromDb = new dataBuilder();

        private void searchForCustomer()
        {
            this.dtCustomerInfo =
                this.getDataFromDb.getCustomersInfo(null, "",
                    "",
                    generalResultInformation.Station,
                    generalResultInformation.concernedNode,
                    this.txtCustomerName.Text, this.ntbTIN.Amount,
                    this.ntbRegularPhone.Amount, this.ntbMobilePhone.Amount,
                    triaStateBool.Ignor, false, "AND", 10);

            this.dtCustomerInfo.Columns.Remove("email");
            this.dtCustomerInfo.Columns.Remove("country");
            this.dtCustomerInfo.Columns.Remove("city");
            this.dtCustomerInfo.Columns.Remove("sub_city");
            this.dtCustomerInfo.Columns.Remove("kebele");
            this.dtCustomerInfo.Columns.Remove("house_number");
            this.dtCustomerInfo.Columns.Remove("is_regular");
            this.dtCustomerInfo.Columns.Remove("insert_user_id");
            this.dtCustomerInfo.Columns.Remove("update_user_id");
            this.dtCustomerInfo.Columns.Remove("insert_date");
            this.dtCustomerInfo.Columns.Remove("update_date");
            this.dtCustomerInfo.Columns.Remove("is_active");
            this.dtCustomerInfo.Columns.Remove("station");
            this.dtCustomerInfo.Columns.Remove("node");
            this.dtCustomerInfo.Columns.Remove("customerID");
            this.dtCustomerInfo.Columns.Remove("customer_category");
            this.dtCustomerInfo.Columns.Remove("account_no");
            this.dtCustomerInfo.Columns.Remove("customer_group");
            this.dtCustomerInfo.Columns.Remove("customer_department");
            this.dtCustomerInfo.Columns.Remove("comment");

            this.dtCustomerInfo.Columns["customer_name"].SetOrdinal(0);
            this.dtCustomerInfo.Columns["tin_number"].SetOrdinal(1);
            this.dtCustomerInfo.Columns["phone_mobile"].SetOrdinal(2);
            this.dtCustomerInfo.Columns["phone_office"].SetOrdinal(3);

            this.dtgCustomerList.DataSource =
                this.dtCustomerInfo;

            this.dtgCustomerList.Columns["id"].Visible = false;

            if (!this.getDataFromDb.checkIfTableContainesData(this.dtCustomerInfo))
            {
                this.cmdSaveCustomer.Enabled = true;
            }
            else
            {
                this.cmdSaveCustomer.Enabled = false;
            }            
        }


        private void frmNewCustomer_Load(object sender, EventArgs e)
        {
            this.searchQuery.Columns.Add("Field");
            this.searchQuery.Columns.Add("Criterion");
            this.searchQuery.Columns.Add("Value");

            DataRow drSearchQuery = this.searchQuery.NewRow();

            drSearchQuery["Field"] = "station";
            drSearchQuery["Criterion"] = " = ";
            drSearchQuery["Value"] = generalResultInformation.Station;

            this.searchQuery.Rows.Add(drSearchQuery);
            
            drSearchQuery = this.searchQuery.NewRow();
            
            drSearchQuery["Field"] = "node";
            drSearchQuery["Criterion"] = " = ";
            drSearchQuery["Value"] = generalResultInformation.concernedNode;

            this.searchQuery.Rows.Add(drSearchQuery);
            
            this.searchForCustomer();

            foreach (DataGridViewColumn columns in this.dtgCustomerList.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DisplayIndex = columns.Index;
            }            
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            this.searchForCustomer();
        }

        private void ntbTIN_Leave(object sender, EventArgs e)
        {
            this.searchForCustomer();
        }

        private void ntbMobilePhone_Leave(object sender, EventArgs e)
        {
            this.searchForCustomer();
        }

        private void ntbRegularPhone_Leave(object sender, EventArgs e)
        {
            this.searchForCustomer();
        }


        private void cmdSaveCustomer_Click(object sender, EventArgs e)
        {
            DataTable newCustomer =
                this.getDataFromDb.getCustomersInfo(null, "", "", "", "",
                    "", triaStateBool.Ignor, true, "AND");

            DataRow drNewCustomer = newCustomer.NewRow();

            drNewCustomer["customer_name"] = this.txtCustomerName.Text;
            drNewCustomer["tin_number"] = this.ntbTIN.Amount;
            drNewCustomer["phone_office"] = this.ntbRegularPhone.Amount;
            drNewCustomer["phone_mobile"] = this.ntbMobilePhone.Amount;
            drNewCustomer["country"] = "1";
            drNewCustomer["city"] = "1";
            drNewCustomer["sub_city"] = "1";
            drNewCustomer["is_regular"] = 1;
            drNewCustomer["insert_user_id"] = generalResultInformation.userId;
            drNewCustomer["update_user_id"] = generalResultInformation.userId;
            drNewCustomer["is_active"] = 1;            
            drNewCustomer["station"] = generalResultInformation.Station;
            drNewCustomer["node"] = generalResultInformation.concernedNode;
            drNewCustomer["customer_category"] = "0";
            drNewCustomer["customer_group"] = "0";
            drNewCustomer["customer_department"] = "0";

            newCustomer.Rows.Add(drNewCustomer);

            this.getDataFromDb.changeDataBaseTableData(newCustomer.Copy(), "customers", "INSERT", true, true);

            newCustomer =
                this.getDataFromDb.getCustomersInfo(null, "", "", 
                            generalResultInformation.Station, 
                            generalResultInformation.concernedNode, 
                            this.txtCustomerName.Text, this.ntbTIN.Amount,
                            this.ntbRegularPhone.Amount, 
                            this.ntbMobilePhone.Amount, triaStateBool.yes, 
                            false, "AND", 1);

            if (!this.getDataFromDb.checkIfTableContainesData(newCustomer))
            {
                this.Close();
                return;
            }

            generalResultInformation.CustomerID =
                newCustomer.Rows[0]["id"].ToString();

            this.Close();
            return;
        }

        private void dtgCustomerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgCustomerList.SelectedRows.Count < 1 ||
                this.dtgCustomerList.Enabled == false)
            {
                return;
            }

            generalResultInformation.CustomerID =
                this.dtgCustomerList.Rows[this.dtgCustomerList.SelectedRows[0].Index].
                           Cells["id"].Value.ToString();
            this.Close();
            return;
        }

    }
}
