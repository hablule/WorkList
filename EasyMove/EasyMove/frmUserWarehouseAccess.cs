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
    public partial class frmUserWarehouseAccess : Form
    {
        public frmUserWarehouseAccess()
        {
            InitializeComponent();
        }

        DataTable dtAllUserNames = new DataTable();
        DataTable dtAllWarehouse = new DataTable();

        dataBuilder getDataFromDb = new dataBuilder();

        private void insetDataIntoComboBox(ComboBox _comboBoxContorl, DataTable dataSourceTable,
            int columnIndexToFeed, int selectedIndex)
        {
            int arraySize = dataSourceTable.Rows.Count;
            string[] arrayItems = new string[arraySize];
            string[] tempArray = { "" };
            if (!getDataFromDb.checkIfTableContainesData(dataSourceTable))
                return;

            if (!dataSourceTable.Columns.Contains("_Index"))
            {
                dataSourceTable.Columns.Add("_Index", System.Type.GetType("System.Int16"));

                for (int rowCounter = 0; rowCounter < dataSourceTable.Rows.Count; rowCounter++)
                {
                    dataSourceTable.Rows[rowCounter]["_Index"] = rowCounter;
                    //tempArray[0] = dataSourceTable.Rows[rowCounter][columnIndexToFeed].ToString();
                    //Array.Copy(tempArray, 0, arrayItems, rowCounter, 1);
                }
            }

            for (int rowCounter = 0; rowCounter < dataSourceTable.Rows.Count; rowCounter++)
            {
                arrayItems[rowCounter] = dataSourceTable.Rows[rowCounter][columnIndexToFeed].ToString();
                //Array.Copy(tempArray, 0, arrayItems, rowCounter, 1);
            }
            _comboBoxContorl.Items.AddRange(arrayItems);

            if (selectedIndex >= 0 &&
                selectedIndex < _comboBoxContorl.Items.Count)
                _comboBoxContorl.SelectedIndex = selectedIndex;
        }

        private void enableSetAccessButton()
        {
            if ((this.ddgUserName.SelectedRowKey != null) || (this.cmbWarehouse.SelectedIndex >= 0 &&
                     this.cmbWarehouse.SelectedIndex <= this.cmbWarehouse.Items.Count - 1))
                this.cmdSetUserWarehouseAccess.Enabled = true;
            else
                this.cmdSetUserWarehouseAccess.Enabled = false;
        }


        private void frmUserWarehouseAccess_Load(object sender, EventArgs e)
        {

            this.dtAllWarehouse =
                this.getDataFromDb.getEM_M_WAREHOUSEInfo(null, "", "", true, false, "AND");
            DataRow drWarehouse = this.dtAllWarehouse.NewRow();
            
            this.dtAllWarehouse.Columns.RemoveAt(this.dtAllWarehouse.Columns.IndexOf("AD_CLIENT_ID"));
            this.dtAllWarehouse.Columns.RemoveAt(this.dtAllWarehouse.Columns.IndexOf("AD_ORG_ID"));
            this.dtAllWarehouse.Columns.RemoveAt(this.dtAllWarehouse.Columns.IndexOf("CREATED"));
            this.dtAllWarehouse.Columns.RemoveAt(this.dtAllWarehouse.Columns.IndexOf("CREATEDBY"));
            this.dtAllWarehouse.Columns.RemoveAt(this.dtAllWarehouse.Columns.IndexOf("UPDATED"));
            this.dtAllWarehouse.Columns.RemoveAt(this.dtAllWarehouse.Columns.IndexOf("UPDATEDBY"));
            this.dtAllWarehouse.Columns.RemoveAt(this.dtAllWarehouse.Columns.IndexOf("DESCRIPTION"));            
            

            drWarehouse["M_WAREHOUSE_ID"] = generalResultInformation.allWarehouseRepresentativeKey;
            drWarehouse["ISACTIVE"] = 'Y';
            drWarehouse["VALUE"] = "*";
            drWarehouse["NAME"] = "*";

            this.dtAllWarehouse.Rows.InsertAt(drWarehouse, 0);

            this.insetDataIntoComboBox(this.cmbWarehouse, this.dtAllWarehouse,
                                        this.dtAllWarehouse.Columns.IndexOf("NAME"), 0);
            this.cmdSetUserWarehouseAccess.Enabled = false;
        }


        private void ddgUserName_selectedItemChanged(object sender, EventArgs e)
        {
            this.enableSetAccessButton();
        }

        private void ddgUserName_SelectedItemClicked(object sender, EventArgs e)
        {
            this.dtAllUserNames =
               this.getDataFromDb.getEM_AD_USERInfo(null, "", "", "", "", true, false, "AND");

            this.ddgUserName.DataSource = this.dtAllUserNames;
            this.ddgUserName.HiddenColoumns = new int[]{this.dtAllUserNames.Columns.IndexOf("AD_CLIENT_ID"),
                                                        this.dtAllUserNames.Columns.IndexOf("AD_ORG_ID"),
                                                        this.dtAllUserNames.Columns.IndexOf("ISACTIVE"),
                                                        this.dtAllUserNames.Columns.IndexOf("CREATED"),
                                                        this.dtAllUserNames.Columns.IndexOf("CREATEDBY"),
                                                        this.dtAllUserNames.Columns.IndexOf("UPDATED"),
                                                        this.dtAllUserNames.Columns.IndexOf("UPDATEDBY"),
                                                        this.dtAllUserNames.Columns.IndexOf("PASSWORD")};
            this.ddgUserName.SelectedColomnIdex = this.dtAllUserNames.Columns.IndexOf("NAME");
            this.ddgUserName.DataTablePrimaryKey =
                 Convert.ToUInt16(this.dtAllUserNames.Columns.IndexOf("AD_USER_ID"));

        }

        private void cmdSetUserWarehouseAccess_Click(object sender, EventArgs e)
        {
            DataTable userWareHouseAccess = null;
            //    this.getDataFromDb.getEM_AD_USER_WAREHOUSE_ACCESSInfo(null, "",
            //                    this.dtAllWarehouse.Rows[this.cmbWarehouse.SelectedIndex]["M_WAREHOUSE_ID"].ToString(),
            //                    this.ddgUserName.SelectedRowKey.ToString(), triStateBool.ignor, false, false, "AND");

            if (!getDataFromDb.checkIfTableContainesData(userWareHouseAccess))
            {
                DataRow newUserWareHouseAccess = userWareHouseAccess.NewRow();

                newUserWareHouseAccess["AD_CLIENT_ID"] = generalResultInformation.clientId;
                newUserWareHouseAccess["AD_USER_ID"] =
                    this.ddgUserName.SelectedRowKey.ToString();
                newUserWareHouseAccess["M_WAREHOUSE_ID"] =
                    this.dtAllWarehouse.Rows[this.cmbWarehouse.SelectedIndex]["M_WAREHOUSE_ID"].ToString();
                
                if (this.ckIsActive.Checked)
                    newUserWareHouseAccess["ISACTIVE"] = "Y";
                else
                    newUserWareHouseAccess["ISACTIVE"] = "N";

                newUserWareHouseAccess["CREATEDBY"] =
                    generalResultInformation.userId;
                newUserWareHouseAccess["UPDATEDBY"] =
                    generalResultInformation.userId;
                if (this.ckIsReadOnlyAccess.Checked)
                    newUserWareHouseAccess["ISREADONLY"] = "Y";
                else
                    newUserWareHouseAccess["ISREADONLY"] = "N";

                userWareHouseAccess.Rows.Add(newUserWareHouseAccess);
                this.getDataFromDb.changeDataBaseTableData(userWareHouseAccess, "EM_AD_USER_WAREHOUSE_ACCESS", "INSERT");
            }
            else
            {
                if (this.ckIsActive.Checked)
                    userWareHouseAccess.Rows[0]["ISACTIVE"] = "Y";
                else
                    userWareHouseAccess.Rows[0]["ISACTIVE"] = "N";

                if (this.ckIsReadOnlyAccess.Checked)
                    userWareHouseAccess.Rows[0]["ISREADONLY"] = "Y";
                else
                    userWareHouseAccess.Rows[0]["ISREADONLY"] = "N";
                this.getDataFromDb.changeDataBaseTableData(userWareHouseAccess, "EM_AD_USER_WAREHOUSE_ACCESS", "UPDATE");
            }
        }

        private void ckIsActive_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckIsActive.Checked)
                this.ckIsReadOnlyAccess.Enabled = true;
            else
            {
                this.ckIsReadOnlyAccess.Enabled = false;
                this.ckIsReadOnlyAccess.Checked = false;
            }
        }

        private void cmbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.enableSetAccessButton();
        }


    }
}
