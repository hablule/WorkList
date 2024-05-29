using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SRP
{
    public partial class frmStorageAccess : Panel
    {
        public frmStorageAccess()
        {
            InitializeComponent();
        }

        bool isNewRecord = false;

        int intCurrentShopId = -1;
        int intCurrentUserId = -1;
        int intCurrentWarehouse = -1;

        Color clNormalLableColor = Color.Black;
        Color clErrorLableColor = Color.Red;
        Color clChangedLableColor = Color.Blue;

        DataTable dtActiveshopList = new DataTable();
        DataTable dtActiveUserList = new DataTable();
        DataTable dtActiveWarehouseList = new DataTable();

        string[] stActiveShopName;
        string[] stActiveUserName;
        string[] stActiveWarehouseName;

        DataTable dtExistingStorageAccess = new DataTable();
        DataTable dtNewStorageAccess = new DataTable();

        dataBuilder getDatafromDataBase = new dataBuilder();

        private void completeExistingStorgaAccessInfo()
        {
            DataTable dtStorageAccessLinkedInfo = new DataTable();
            for (int rowCounter = 0; rowCounter <= this.dtExistingStorageAccess.Rows.Count - 1; rowCounter++)
            {
                dtStorageAccessLinkedInfo =
                    this.getDatafromDataBase.getU_USERInfo(null, "",
                            this.dtExistingStorageAccess.Rows[rowCounter]["U_USER_ID"].ToString(),
                            "", "", "", triStateBool.ignor, false, "AND");
                if(dtStorageAccessLinkedInfo.Rows.Count >= 1)
                    this.dtExistingStorageAccess.Rows[rowCounter]["User"] =
                        dtStorageAccessLinkedInfo.Rows[0]["FIRSTNAME"].ToString() + " " +
                        dtStorageAccessLinkedInfo.Rows[0]["MIDDLENAME"].ToString();

                dtStorageAccessLinkedInfo =
                    this.getDatafromDataBase.getM_SHOPInfo(null,"",
                        this.dtExistingStorageAccess.Rows[rowCounter]["M_SHOP_ID"].ToString(),
                        "",triStateBool.ignor,false,"AND");

                if (dtStorageAccessLinkedInfo.Rows.Count >= 1)
                    this.dtExistingStorageAccess.Rows[rowCounter]["Shop"] =
                        dtStorageAccessLinkedInfo.Rows[0]["NAME"].ToString();

                dtStorageAccessLinkedInfo =
                    this.getDatafromDataBase.getM_WarehouseInfo(null,"",
                            this.dtExistingStorageAccess.Rows[rowCounter]["M_WAREHOUSE_ID"].ToString(),
                            "", triStateBool.ignor, triStateBool.ignor, false, "AND");

                if (dtStorageAccessLinkedInfo.Rows.Count >= 1)
                    this.dtExistingStorageAccess.Rows[rowCounter]["Warehouse"] =
                        dtStorageAccessLinkedInfo.Rows[0]["NAME"].ToString();
            }
        }

        private void setGridControlData()
        {
            this.dtExistingStorageAccess.Columns.Add("Shop");
            this.dtExistingStorageAccess.Columns.Add("User");
            this.dtExistingStorageAccess.Columns.Add("Warehouse");

            this.dtExistingStorageAccess.Columns["Shop"].SetOrdinal(0);
            this.dtExistingStorageAccess.Columns["User"].SetOrdinal(1);
            this.dtExistingStorageAccess.Columns["Warehouse"].SetOrdinal(2);

            this.completeExistingStorgaAccessInfo();

            this.dtExistingStorageAccess.Columns["CANSALEFROM"].ColumnName = "Can Sale from";
            this.dtExistingStorageAccess.Columns["CANBUYFOR"].ColumnName = "Can Buy for";
            this.dtExistingStorageAccess.Columns["CANMOVETO"].ColumnName = "Can Move to";
            this.dtExistingStorageAccess.Columns["CANMOVEFORM"].ColumnName = "Can Move from";
            this.dtExistingStorageAccess.Columns["CANUSEFROM"].ColumnName = "Can Use from";
            this.dtExistingStorageAccess.Columns["CANCOUNT"].ColumnName = "Can Count";
            this.dtExistingStorageAccess.Columns["CANREAD"].ColumnName = "Can View";

            this.dtgStorageAccessView.DataSource = this.dtExistingStorageAccess;

            this.dtgStorageAccessView.Columns["M_SHOP_ID"].Visible = false;
            this.dtgStorageAccessView.Columns["U_USER_ID"].Visible = false;
            this.dtgStorageAccessView.Columns["M_WAREHOUSE_ID"].Visible = false;
            this.dtgStorageAccessView.Columns["CREATED"].Visible = false;
            this.dtgStorageAccessView.Columns["CREATEDBY"].Visible = false;
            this.dtgStorageAccessView.Columns["UPDATED"].Visible = false;
            this.dtgStorageAccessView.Columns["UPDATEDBY"].Visible = false;
            this.dtgStorageAccessView.Columns["DESCRIPTION"].Visible = false;
        }

        private bool checkForCompleteNewRecord()
        {
            bool foundError = false;

            if (this.intCurrentShopId == -1)
            {
                this.lblStation.ForeColor = clErrorLableColor;
                foundError = true;
            }
            else
            {
                this.lblStation.ForeColor = clNormalLableColor;
            }

            if (this.intCurrentUserId == -1)
            {
                this.lblUser.ForeColor = clErrorLableColor;
                foundError = true;
            }
            else
            {
                this.lblUser.ForeColor = clNormalLableColor;
            }

            if (this.intCurrentWarehouse == -1)
            {
                this.lblWarehouse.ForeColor = clErrorLableColor;
                foundError = true;
            }
            else
            {
                this.lblWarehouse.ForeColor = clNormalLableColor;
            }

            return foundError;
        }



        public void frmStorageAccess_Load(object sender, EventArgs e)
        {
            if (generalResultInformation.currentFormIsReadOnly)
            {
                this.tlsDelete.Visible = false;
                this.tlsNew.Visible = false;
                this.tlsSave.Visible = false;
            }

            this.tlsNew_Click(sender, e);

            this.dtExistingStorageAccess =
                this.getDatafromDataBase.getU_WAREHOUSEACCESS(null, "",
                    "", "", "", triStateBool.ignor, triStateBool.ignor,
                    triStateBool.ignor, triStateBool.ignor, triStateBool.ignor,
                    triStateBool.ignor, triStateBool.ignor, triStateBool.ignor, true, "");

            this.dtActiveshopList =
                this.getDatafromDataBase.getM_SHOPInfo(null, "",
                    "", "", triStateBool.yes, false, "AND");

            this.stActiveShopName =
                    new string[this.dtActiveshopList.Rows.Count + 1];
            this.stActiveShopName[0] = " - Select Shop - ";

            if (this.dtActiveshopList.Rows.Count >= 1)
            {                
                for (int rowCounter = 0;
                    rowCounter <= this.dtActiveshopList.Rows.Count - 1;
                    rowCounter++)
                {
                    this.stActiveShopName[rowCounter+1] =
                        this.dtActiveshopList.Rows[rowCounter]["NAME"].ToString();
                }
            }

            this.dtActiveUserList =
                this.getDatafromDataBase.getU_USERInfo(null, "",
                    "", "", "", "", triStateBool.yes, false, "AND");

            this.stActiveUserName = 
                new string[this.dtActiveUserList.Rows.Count+1];
            this.stActiveUserName[0] = " - Select User - ";
            
            if (this.dtActiveUserList.Rows.Count >= 1)
            {                
                for (int rowCounter = 0;
                    rowCounter <= this.dtActiveUserList.Rows.Count - 1;
                    rowCounter++)
                {
                    this.stActiveUserName[rowCounter+1] =
                        this.dtActiveUserList.Rows[rowCounter]["USERNAME"].ToString();
                }
            }

            this.dtActiveWarehouseList =
                this.getDatafromDataBase.getM_WarehouseInfo(null, "",
                    "", "", triStateBool.ignor, triStateBool.yes, false, "AND");

            this.stActiveWarehouseName =
                    new string[this.dtActiveWarehouseList.Rows.Count + 1];
            this.stActiveWarehouseName[0] = " - Select Warehouse - ";

            if (this.dtActiveWarehouseList.Rows.Count >= 1)
            {                
                for (int rowCounter = 0;
                    rowCounter <= this.dtActiveWarehouseList.Rows.Count - 1;
                    rowCounter++)
                {
                    this.stActiveWarehouseName[rowCounter+1] =
                        this.dtActiveWarehouseList.Rows[rowCounter]["NAME"].ToString();
                }
            }

            this.cmbStation_DropDown(sender, e);
            this.cmbUser_DropDown(sender, e);
            this.cmbWarehouse_DropDown(sender, e);

            this.setGridControlData();
        }

        private void cmbStation_DropDown(object sender, EventArgs e)
        {
            this.cmbStation.Items.Clear();
            if (this.stActiveShopName != null)
            {
                this.cmbStation.Items.AddRange(this.stActiveShopName);
                this.cmbStation.SelectedIndex = 0;
            }
        }

        private void cmbUser_DropDown(object sender, EventArgs e)
        {
            this.cmbUser.Items.Clear();
            if (this.stActiveUserName != null)
            {
                this.cmbUser.Items.AddRange(this.stActiveUserName);
                this.cmbUser.SelectedIndex = 0;
            }
        }

        private void cmbWarehouse_DropDown(object sender, EventArgs e)
        {
            this.cmbWarehouse.Items.Clear();
            if (this.stActiveWarehouseName != null)
            {
                this.cmbWarehouse.Items.AddRange(this.stActiveWarehouseName);
                this.cmbWarehouse.SelectedIndex = 0;
            }
        }

        private void tlsNew_Click(object sender, EventArgs e)
        {
            this.isNewRecord = true;

            this.intCurrentShopId = -1;
            this.intCurrentUserId = -1;
            this.intCurrentWarehouse = -1;

            this.cmbStation_DropDown(sender, e);
            this.cmbUser_DropDown(sender, e);
            this.cmbWarehouse_DropDown(sender, e);

            this.txtDescription.Text = "";

            this.ckIsActive.Checked = true;
            this.ckCanBuy.Checked = false;
            this.ckCanSale.Checked = false;
            this.ckCanMoveFrom.Checked = false;
            this.ckCanMoveTo.Checked = false;
            this.ckCanUse.Checked = false;
            this.ckCanCount.Checked = false;
            this.ckCanRead.Checked = true;
        }

        private void tlsSave_Click(object sender, EventArgs e)
        {
            if (this.checkForCompleteNewRecord())
            {                
                MessageBox.Show("Please complete the missing form element before proceeding.",
                    "SRP SAVE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string stTypeOfChange = "INSERT";
            
            this.dtNewStorageAccess =
                this.getDatafromDataBase.getU_WAREHOUSEACCESS(null, "",
                    this.intCurrentShopId.ToString(), this.intCurrentUserId.ToString(), 
                    this.intCurrentWarehouse.ToString(),
                    triStateBool.ignor, triStateBool.ignor, triStateBool.ignor, 
                    triStateBool.ignor,triStateBool.ignor, triStateBool.ignor,
                    triStateBool.ignor, triStateBool.ignor, false, "AND");

            if (!this.isNewRecord || this.dtNewStorageAccess.Rows.Count >= 1)
                    stTypeOfChange = "UPDATE";

            DataRow drNewStorageAccess = this.dtNewStorageAccess.NewRow();

            drNewStorageAccess["M_SHOP_ID"] = this.intCurrentShopId;
            drNewStorageAccess["U_USER_ID"] = this.intCurrentUserId;
            drNewStorageAccess["M_WAREHOUSE_ID"] = this.intCurrentWarehouse;

            drNewStorageAccess["DESCRIPTION"] = this.txtDescription.Text;

            if (this.ckIsActive.Checked)
                drNewStorageAccess["ISACTIVE"] = "Y";
            else
                drNewStorageAccess["ISACTIVE"] = "N";

            if (this.ckCanBuy.Checked)
                drNewStorageAccess["CANBUYFOR"] = "Y";
            else
                drNewStorageAccess["CANBUYFOR"] = "N";

            if (this.ckCanSale.Checked)
                drNewStorageAccess["CANSALEFROM"] = "Y";
            else
                drNewStorageAccess["CANSALEFROM"] = "N";

            if (this.ckCanMoveTo.Checked)
                drNewStorageAccess["CANMOVETO"] = "Y";
            else
                drNewStorageAccess["CANMOVETO"] = "N";

            if (this.ckCanMoveFrom.Checked)
                drNewStorageAccess["CANMOVEFORM"] = "Y";
            else
                drNewStorageAccess["CANMOVEFORM"] = "N";

            if (this.ckCanUse.Checked)
                drNewStorageAccess["CANUSEFROM"] = "Y";
            else
                drNewStorageAccess["CANUSEFROM"] = "N";

            if (this.ckCanCount.Checked)
                drNewStorageAccess["CANCOUNT"] = "Y";
            else
                drNewStorageAccess["CANCOUNT"] = "N";

            if (this.ckCanRead.Checked)
                drNewStorageAccess["CANREAD"] = "Y";
            else
                drNewStorageAccess["CANREAD"] = "N";

            this.dtNewStorageAccess.Rows.Add(drNewStorageAccess);

            string[] primaryKeySepartor = { " <(", ")>||" };
            string[] primaryKey =
                this.getDatafromDataBase.changeDataBaseTableData
                    (this.dtNewStorageAccess, "U_WAREHOUSEACCESS", stTypeOfChange)[0]
                    .Split(primaryKeySepartor, StringSplitOptions.RemoveEmptyEntries);

            this.dtExistingStorageAccess =
                this.getDatafromDataBase.getU_WAREHOUSEACCESS(null, "",
                    "", "", "", triStateBool.ignor, triStateBool.ignor,
                    triStateBool.ignor,triStateBool.ignor,
                    triStateBool.ignor, triStateBool.ignor,
                    triStateBool.ignor, triStateBool.ignor, false, "");
            this.setGridControlData();
            if (this.dtgStorageAccessView.Rows.Count >= 1)
                this.dtgStorageAccessView.
                    Rows[this.dtgStorageAccessView.Rows.Count - 1].Selected = true;
        }

        private void tlsDelete_Click(object sender, EventArgs e)
        {
            if (this.checkForCompleteNewRecord())
            {
                return;
            }

            string stTypeOfChange = "DELETE";

            this.dtNewStorageAccess =
                this.getDatafromDataBase.getU_WAREHOUSEACCESS(null, "",
                    this.intCurrentShopId.ToString(), this.intCurrentUserId.ToString(),
                    this.intCurrentWarehouse.ToString(),
                    triStateBool.ignor, triStateBool.ignor, triStateBool.ignor,
                    triStateBool.ignor, triStateBool.ignor, triStateBool.ignor,
                    triStateBool.ignor, triStateBool.ignor, false, "AND");


            this.getDatafromDataBase.changeDataBaseTableData
                    (this.dtNewStorageAccess, "U_WAREHOUSEACCESS", stTypeOfChange);

            this.dtExistingStorageAccess =
               this.getDatafromDataBase.getU_WAREHOUSEACCESS(null, "",
                   "", "", "", triStateBool.ignor, triStateBool.ignor,
                   triStateBool.ignor, triStateBool.ignor, triStateBool.ignor,
                   triStateBool.ignor, triStateBool.ignor, triStateBool.ignor, false, "");

            this.setGridControlData();
            if (this.dtgStorageAccessView.Rows.Count >= 1)
                this.dtgStorageAccessView.
                    Rows[this.dtgStorageAccessView.Rows.Count - 1].Selected = true;
            else
                this.tlsNew_Click(sender, e);
        }

        private void tlsSearch_Click(object sender, EventArgs e)
        {
            this.dtExistingStorageAccess =
                this.getDatafromDataBase.getU_WAREHOUSEACCESS(null, "",
                    "", "", "", triStateBool.ignor, triStateBool.ignor,
                    triStateBool.ignor, triStateBool.ignor, triStateBool.ignor,
                    triStateBool.ignor, triStateBool.ignor, triStateBool.ignor, false, "");
            this.setGridControlData();
            if (this.dtgStorageAccessView.Rows.Count >= 1)
                this.dtgStorageAccessView.Rows[0].Selected = true;
        }


        private void dtgStorageAccessView_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgStorageAccessView.SelectedRows.Count < 1)
            {
                return;
            }

            int selectedStorageAccessIndex =
                this.dtgStorageAccessView.SelectedRows[0].Index;

            if (this.dtgStorageAccessView.
                    Rows[selectedStorageAccessIndex].
                            Cells["ISACTIVE"].Value.ToString() == "Y")
                this.ckIsActive.Checked = true;
            else
                this.ckIsActive.Checked = false;


            if (this.dtgStorageAccessView.
                    Rows[selectedStorageAccessIndex].
                            Cells["Can Sale from"].Value.ToString() == "Y")
                this.ckCanSale.Checked = true;
            else
                this.ckCanSale.Checked = false;

            if (this.dtgStorageAccessView.
                    Rows[selectedStorageAccessIndex].
                            Cells["Can Buy for"].Value.ToString() == "Y")
                this.ckCanBuy.Checked = true;
            else
                this.ckCanBuy.Checked = false;

            if (this.dtgStorageAccessView.
                    Rows[selectedStorageAccessIndex].
                            Cells["Can Move to"].Value.ToString() == "Y")
                this.ckCanMoveTo.Checked = true;
            else
                this.ckCanMoveTo.Checked = false;

            if (this.dtgStorageAccessView.
                    Rows[selectedStorageAccessIndex].
                            Cells["Can Move from"].Value.ToString() == "Y")
                this.ckCanMoveFrom.Checked = true;
            else
                this.ckCanMoveFrom.Checked = false;

            if (this.dtgStorageAccessView.
                    Rows[selectedStorageAccessIndex].
                            Cells["Can Use from"].Value.ToString() == "Y")
                this.ckCanUse.Checked = true;
            else
                this.ckCanUse.Checked = false;

            if (this.dtgStorageAccessView.
                    Rows[selectedStorageAccessIndex].
                            Cells["Can Count"].Value.ToString() == "Y")
                this.ckCanCount.Checked = true;
            else
                this.ckCanCount.Checked = false;

            if (this.dtgStorageAccessView.
                    Rows[selectedStorageAccessIndex].
                            Cells["Can View"].Value.ToString() == "Y")
                this.ckCanRead.Checked = true;
            else
                this.ckCanRead.Checked = false;

            
            this.cmbStation.SelectedIndex = 0;
            for (int rowCounter = 0; 
                rowCounter <= this.dtActiveshopList.Rows.Count - 1; rowCounter++)
            {
                if (this.dtgStorageAccessView.
                        Rows[selectedStorageAccessIndex].
                                Cells["M_SHOP_ID"].Value.ToString() ==
                            this.dtActiveshopList.Rows[rowCounter]["M_SHOP_ID"].ToString())
                {
                    this.cmbStation.SelectedIndex = rowCounter+1;                    
                    break;
                }
            }

            this.cmbUser.SelectedIndex = 0;
            for (int rowCounter = 0;
                rowCounter <= this.dtActiveUserList.Rows.Count - 1; rowCounter++)
            {
                if (this.dtgStorageAccessView.
                        Rows[selectedStorageAccessIndex].
                                Cells["U_USER_ID"].Value.ToString() ==
                            this.dtActiveUserList.Rows[rowCounter]["U_USER_ID"].ToString())
                {
                    this.cmbUser.SelectedIndex = rowCounter+1;                    
                    break;
                }
            }

            this.cmbWarehouse.SelectedIndex = 0;
            for (int rowCounter = 0;
                rowCounter <= this.dtActiveWarehouseList.Rows.Count - 1; rowCounter++)
            {
                if (this.dtgStorageAccessView.
                        Rows[selectedStorageAccessIndex].
                                Cells["M_WAREHOUSE_ID"].Value.ToString() ==
                            this.dtActiveWarehouseList.Rows[rowCounter]["M_WAREHOUSE_ID"].ToString())
                {
                    this.cmbWarehouse.SelectedIndex = rowCounter+1;
                    break;
                }
            }

            this.txtDescription.Text =
                this.dtgStorageAccessView.Rows[selectedStorageAccessIndex].
                            Cells["DESCRIPTION"].Value.ToString();
        }

        private void cmbStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbStation.SelectedIndex > 0)
                this.intCurrentShopId =
                    int.Parse(this.dtActiveshopList.
                                Rows[this.cmbStation.SelectedIndex-1]["M_SHOP_ID"].
                                ToString());
            else
                this.intCurrentShopId = -1;
        }

        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbUser.SelectedIndex > 0)
                this.intCurrentUserId =
                    int.Parse(this.dtActiveUserList.
                                Rows[this.cmbUser.SelectedIndex-1]["U_USER_ID"].
                                ToString());
            else
                this.intCurrentUserId = -1;
        }

        private void cmbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbWarehouse.SelectedIndex > 0)
                this.intCurrentWarehouse =
                    int.Parse(this.dtActiveWarehouseList.
                                Rows[this.cmbWarehouse.SelectedIndex-1]["M_WAREHOUSE_ID"].
                                ToString());
            else
                this.intCurrentWarehouse = -1;
        }

        private void ckCanRead_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.ckCanRead.Checked)
            {
                this.ckCanBuy.Checked = false;
                this.ckCanSale.Checked = false;
                this.ckCanMoveFrom.Checked = false;
                this.ckCanMoveTo.Checked = false;
                this.ckCanUse.Checked = false;
                this.ckCanCount.Checked = false;

            }
        }           

                
    }
}
