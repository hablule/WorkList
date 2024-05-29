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
    public partial class frmStationAccess : Panel
    {
        public frmStationAccess()
        {
            InitializeComponent();
        }

        bool isNewRecord = false;

        int intCurrentShopId = -1;
        int intCurrentUserId = -1;

        Color clNormalLableColor = Color.Black;
        Color clErrorLableColor = Color.Red;
        Color clChangedLableColor = Color.Blue;

        DataTable dtActiveshopList = new DataTable();
        DataTable dtActiveUserList = new DataTable();

        string[] stActiveShopName;
        string[] stActiveUserName;

        DataTable dtExistingStationAccess = new DataTable();
        DataTable dtNewStationAccess = new DataTable();

        dataBuilder getDatafromDataBase = new dataBuilder();

        private void completeExistingStationAccessInfo()
        {
            DataTable dtStationAccessLinkedInfo = new DataTable();
            for (int rowCounter = 0;
                 rowCounter <= this.dtExistingStationAccess.Rows.Count - 1; rowCounter++)
            {
                dtStationAccessLinkedInfo =
                    this.getDatafromDataBase.getU_USERInfo(null, "",
                            this.dtExistingStationAccess.Rows[rowCounter]["U_USER_ID"].ToString(),
                            "", "", "", triStateBool.ignor, false, "AND");

                if (dtStationAccessLinkedInfo.Rows.Count >= 1)
                    this.dtExistingStationAccess.Rows[rowCounter]["User"] =
                        dtStationAccessLinkedInfo.Rows[0]["USERNAME"].ToString();

                dtStationAccessLinkedInfo =
                    this.getDatafromDataBase.getM_SHOPInfo(null, "",
                        this.dtExistingStationAccess.Rows[rowCounter]["M_SHOP_ID"].ToString(),
                        "", triStateBool.ignor, false, "AND");

                if (dtStationAccessLinkedInfo.Rows.Count >= 1)
                    this.dtExistingStationAccess.Rows[rowCounter]["Shop"] =
                        dtStationAccessLinkedInfo.Rows[0]["NAME"].ToString();
            }
        }

        private void setGridControlData()
        {
            this.dtExistingStationAccess.Columns.Add("Shop");
            this.dtExistingStationAccess.Columns.Add("User");

            this.dtExistingStationAccess.Columns["Shop"].SetOrdinal(0);
            this.dtExistingStationAccess.Columns["User"].SetOrdinal(1);

            this.completeExistingStationAccessInfo();

            this.dtgShopAccessGridView.DataSource = this.dtExistingStationAccess;

            this.dtgShopAccessGridView.Columns["M_SHOP_ID"].Visible = false;            
            this.dtgShopAccessGridView.Columns["U_USER_ID"].Visible = false;
            this.dtgShopAccessGridView.Columns["CREATED"].Visible = false;
            this.dtgShopAccessGridView.Columns["CREATEDBY"].Visible = false;
            this.dtgShopAccessGridView.Columns["UPDATED"].Visible = false;
            this.dtgShopAccessGridView.Columns["UPDATEDBY"].Visible = false;
            this.dtgShopAccessGridView.Columns["DESCRIPTION"].Visible = false;
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

            if (this.cmbAccessLevel.SelectedIndex == 0)
            {
                this.lblAccessLevel.ForeColor = clErrorLableColor;
                foundError = true;
            }
            else
            {
                this.lblAccessLevel.ForeColor = clNormalLableColor;
            }

            return foundError;
        }




        public void frmStationAccess_Load(object sender, EventArgs e)
        {
            if (generalResultInformation.currentFormIsReadOnly)
            {
                this.tlsDelete.Visible = false;
                this.tlsNew.Visible = false;
                this.tlsSave.Visible = false;
            }
                        
            this.tlsNew_Click(sender, e);

            this.dtExistingStationAccess =
                this.getDatafromDataBase.getU_SHOPACCESS(null, "",
                    "", "", accessLevel.ignor, triStateBool.ignor, true, "");

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
                    this.stActiveShopName[rowCounter + 1] =
                        this.dtActiveshopList.Rows[rowCounter]["NAME"].ToString();
                }
            }

            this.dtActiveUserList =
                this.getDatafromDataBase.getU_USERInfo(null, "",
                    "", "", "", "", triStateBool.yes, false, "AND");

            this.stActiveUserName =
                new string[this.dtActiveUserList.Rows.Count + 1];
            this.stActiveUserName[0] = " - Select User - ";

            if (this.dtActiveUserList.Rows.Count >= 1)
            {
                for (int rowCounter = 0;
                    rowCounter <= this.dtActiveUserList.Rows.Count - 1;
                    rowCounter++)
                {
                    this.stActiveUserName[rowCounter + 1] =
                        this.dtActiveUserList.Rows[rowCounter]["USERNAME"].ToString();
                }
            }

            this.cmbStationList_DropDown(sender, e);
            this.cmbUserList_DropDown(sender, e);

            this.setGridControlData();

        }

        private void tlsNew_Click(object sender, EventArgs e)
        {
            this.isNewRecord = true;

            this.intCurrentShopId = -1;
            this.intCurrentUserId = -1;

            if (this.cmbAccessLevel.Items.Count > 0)
                this.cmbAccessLevel.SelectedIndex = 0;

            this.cmbStationList_DropDown(sender, e);
            this.cmbUserList_DropDown(sender, e);

            this.txtDescription.Text = "";
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

            this.dtNewStationAccess =
                 this.getDatafromDataBase.getU_SHOPACCESS(null, "",
                    this.intCurrentShopId.ToString(), this.intCurrentUserId.ToString(),
                    accessLevel.ignor, triStateBool.ignor, false, "AND");

            if (!this.isNewRecord || this.dtNewStationAccess.Rows.Count >= 1)
                stTypeOfChange = "UPDATE";

            DataRow drNewStationAccess = this.dtNewStationAccess.NewRow();

            drNewStationAccess["M_SHOP_ID"] = this.intCurrentShopId;
            drNewStationAccess["U_USER_ID"] = this.intCurrentUserId;
            drNewStationAccess["ACCESSLEVEL"] = this.cmbAccessLevel.SelectedItem.ToString();
            drNewStationAccess["DESCRIPTION"] = this.txtDescription.Text;

            this.dtNewStationAccess.Rows.Add(drNewStationAccess);

            string[] primaryKeySepartor = { " <(", ")>||" };
            string[] primaryKey =
                this.getDatafromDataBase.changeDataBaseTableData
                    (this.dtNewStationAccess, "U_SHOPACCESS", stTypeOfChange)[0]
                    .Split(primaryKeySepartor, StringSplitOptions.RemoveEmptyEntries);

            this.dtExistingStationAccess =
                this.getDatafromDataBase.getU_SHOPACCESS(null, "",
                    "", "", accessLevel.ignor, triStateBool.ignor, false, "");

            this.setGridControlData();
            if (this.dtExistingStationAccess.Rows.Count >= 1)
                this.dtgShopAccessGridView.
                    Rows[this.dtgShopAccessGridView.Rows.Count - 1].Selected = true;
        }

        private void tlsDelete_Click(object sender, EventArgs e)
        {
            this.dtNewStationAccess =
                 this.getDatafromDataBase.getU_SHOPACCESS(null, "",
                    this.intCurrentShopId.ToString(), this.intCurrentUserId.ToString(),
                    accessLevel.ignor, triStateBool.ignor, false, "AND");

            if (this.checkForCompleteNewRecord())
            {
                return;
            }

            string stTypeOfChange = "DELETE";

            this.getDatafromDataBase.changeDataBaseTableData
                    (this.dtNewStationAccess, "U_SHOPACCESS", stTypeOfChange);

            this.dtExistingStationAccess =
                this.getDatafromDataBase.getU_SHOPACCESS(null, "",
                    "", "", accessLevel.ignor, triStateBool.ignor, false, "");
            this.setGridControlData();
            if (this.dtExistingStationAccess.Rows.Count >= 1)
                this.dtgShopAccessGridView.
                    Rows[this.dtgShopAccessGridView.Rows.Count - 1].Selected = true;
            else
                this.tlsNew_Click(sender, e);
        }

        private void tlsSearch_Click(object sender, EventArgs e)
        {
            this.dtExistingStationAccess =
                this.getDatafromDataBase.getU_SHOPACCESS(null, "",
                    "", "", accessLevel.ignor, triStateBool.ignor, false, "");
            this.setGridControlData();
            if (this.dtExistingStationAccess.Rows.Count >= 1)
                this.dtgShopAccessGridView.Rows[0].Selected = true;
        }


        private void cmbStationList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbStationList.SelectedIndex > 0)
                this.intCurrentShopId =
                    int.Parse(this.dtActiveshopList.
                                Rows[this.cmbStationList.SelectedIndex - 1]["M_SHOP_ID"].
                                ToString());
            else
                this.intCurrentShopId = -1;
        }

        private void cmbUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbUserList.SelectedIndex > 0)
                this.intCurrentUserId =
                    int.Parse(this.dtActiveUserList.
                                Rows[this.cmbUserList.SelectedIndex - 1]["U_USER_ID"].
                                ToString());
            else
                this.intCurrentUserId = -1;
        }

        private void cmbStationList_DropDown(object sender, EventArgs e)
        {
            this.cmbStationList.Items.Clear();
            if (this.stActiveShopName != null)
            {
                this.cmbStationList.Items.AddRange(this.stActiveShopName);
                this.cmbStationList.SelectedIndex = 0;
            }
        }

        private void cmbUserList_DropDown(object sender, EventArgs e)
        {
            this.cmbUserList.Items.Clear();
            if (this.stActiveUserName != null)
            {
                this.cmbUserList.Items.AddRange(this.stActiveUserName);
                this.cmbUserList.SelectedIndex = 0;
            }
        }

        private void dtgShopAccessGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgShopAccessGridView.SelectedRows.Count < 1)
            {
                return;
            }

            int selectedStationAccessIndex =
                this.dtgShopAccessGridView.SelectedRows[0].Index;

            this.cmbStationList.SelectedIndex = 0;
            for (int rowCounter = 0;
                rowCounter <= this.dtActiveshopList.Rows.Count - 1; rowCounter++)
            {
                if (this.dtgShopAccessGridView.
                        Rows[selectedStationAccessIndex].
                                Cells["M_SHOP_ID"].Value.ToString() ==
                            this.dtActiveshopList.Rows[rowCounter]["M_SHOP_ID"].ToString())
                {
                    this.cmbStationList.SelectedIndex = rowCounter + 1;
                    break;
                }
            }

            this.cmbUserList.SelectedIndex = 0;
            for (int rowCounter = 0;
                rowCounter <= this.dtActiveUserList.Rows.Count - 1; rowCounter++)
            {
                if (this.dtgShopAccessGridView.
                        Rows[selectedStationAccessIndex].
                                Cells["U_USER_ID"].Value.ToString() ==
                            this.dtActiveUserList.Rows[rowCounter]["U_USER_ID"].ToString())
                {
                    this.cmbUserList.SelectedIndex = rowCounter + 1;
                    break;
                }
            }

            int indexOfAccessLevel =
                this.cmbAccessLevel.Items.IndexOf(
                        this.dtgShopAccessGridView.Rows[selectedStationAccessIndex].
                            Cells["ACCESSLEVEL"].Value.ToString());

            if (indexOfAccessLevel >= 0 &&
                indexOfAccessLevel <= this.cmbAccessLevel.Items.Count)
            {
                this.cmbAccessLevel.SelectedIndex = indexOfAccessLevel;
            }
            else
                this.cmbAccessLevel.SelectedIndex = 0;

            this.txtDescription.Text =
                this.dtgShopAccessGridView.Rows[selectedStationAccessIndex].
                            Cells["DESCRIPTION"].Value.ToString();
        }


        

    }
}
