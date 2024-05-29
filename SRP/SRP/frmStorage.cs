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
    public partial class frmStorage : Panel
    {
        public frmStorage()
        {
            InitializeComponent();
        }

        string stringShopID = generalResultInformation.activeStation;
        int intCurrentWarehouseId = -1;

        private Color clNormalLableColor = Color.Black;
        private Color clErrorLableColor = Color.Red;
        private Color clChangedLableColor = Color.Blue;

        DataTable dtNewWarehouseInformation = new DataTable();
        DataTable dtExistingWarehouseInformation = new DataTable();

        private dataBuilder getDatafromDataBase = new dataBuilder();


        private bool checkForCompleteNewRecord()
        {
            bool foundError = true;

            if (this.txtName.Text == "")
            {
                this.lblName.ForeColor = clErrorLableColor;
                foundError = false;
            }
            else
            {
                this.lblName.ForeColor = clNormalLableColor;
            }

            return foundError;
        }

        public void frmStorage_Load(object sender, EventArgs e)
        {
            if (generalResultInformation.currentFormIsReadOnly)
            {
                this.tlsDelete.Visible = false;
                this.tlsNew.Visible = false;
                this.tlsSave.Visible = false;
            }

            this.dtExistingWarehouseInformation =
                    this.getDatafromDataBase.getM_WarehouseInfo(null,
                            "", "", "", triStateBool.ignor, triStateBool.ignor, true, "");

            this.dtgWarehouseGridView.DataSource =
                this.dtExistingWarehouseInformation;

            this.dtgWarehouseGridView.Columns["M_SHOP_ID"].Visible = false;
            this.dtgWarehouseGridView.Columns["AD_ORG_ID"].Visible = false;
            this.dtgWarehouseGridView.Columns["M_WAREHOUSE_ID"].Visible = false;
            this.dtgWarehouseGridView.Columns["CREATED"].Visible = false;
            this.dtgWarehouseGridView.Columns["UPDATED"].Visible = false;
            this.dtgWarehouseGridView.Columns["CREATEDBY"].Visible = false;
            this.dtgWarehouseGridView.Columns["UPDATEDBY"].Visible = false;
        }

        private void tlsNew_Click(object sender, EventArgs e)
        {

            this.intCurrentWarehouseId = -1;

            this.txtName.Text = "";
            this.txtDescription.Text = "";
            this.ckIsActive.Checked = true;
            this.ckAllowNegative.Checked = false;
        }

        private void tlsSave_Click(object sender, EventArgs e)
        {
            string stTypeOfChange = "INSERT";
            if (!this.checkForCompleteNewRecord())
            {
                MessageBox.Show("Please complete the missing form element before proceeding.",
                    "SRP SAVE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.dtNewWarehouseInformation =
                this.getDatafromDataBase.getM_WarehouseInfo(null, "", "", "", triStateBool.ignor,
                                            triStateBool.ignor, true, "");

            DataRow drNewWarehouse = this.dtNewWarehouseInformation.NewRow();

            if (this.intCurrentWarehouseId != -1)
            {
                drNewWarehouse["M_WAREHOUSE_ID"] = this.intCurrentWarehouseId;
                stTypeOfChange = "UPDATE";
            }
            else
                stTypeOfChange = "INSERT";

            drNewWarehouse["M_SHOP_ID"] = this.stringShopID;
            drNewWarehouse["NAME"] = this.txtName.Text;

            if (this.ckIsActive.Checked)
                drNewWarehouse["ISACTIVE"] = "Y";
            else
                drNewWarehouse["ISACTIVE"] = "N";

            if (this.ckAllowNegative.Checked)
                drNewWarehouse["ALLOWNEGATIVE"] = "Y";
            else
                drNewWarehouse["ALLOWNEGATIVE"] = "N";

            drNewWarehouse["DESCRIPTION"] = this.txtDescription.Text;

            this.dtNewWarehouseInformation.Rows.Add(drNewWarehouse);

            string[] primaryKeySepartor = { " <(", ")>||" };
            string[] primaryKey =
                this.getDatafromDataBase.changeDataBaseTableData
                    (this.dtNewWarehouseInformation.Copy(), "M_WAREHOUSE", stTypeOfChange)[0]
                    .Split(primaryKeySepartor, StringSplitOptions.RemoveEmptyEntries);

            if (primaryKey.Length > 1 && stTypeOfChange == "INSERT")
            {
                this.intCurrentWarehouseId = int.Parse(primaryKey[1]);
                this.dtExistingWarehouseInformation =
                    this.getDatafromDataBase.getM_WarehouseInfo(null,
                            "", "", "", triStateBool.ignor, triStateBool.ignor, false, "");

                this.dtgWarehouseGridView.DataSource =
                    this.dtExistingWarehouseInformation;
                if (this.dtExistingWarehouseInformation.Rows.Count > 0)
                    this.dtgWarehouseGridView.
                        Rows[this.dtExistingWarehouseInformation.Rows.Count - 1].Selected = true;
            }              

        }

        private void tlsSearch_Click(object sender, EventArgs e)
        {
            this.dtExistingWarehouseInformation =
                    this.getDatafromDataBase.getM_WarehouseInfo(null,
                            "", "", "", triStateBool.ignor, triStateBool.ignor, false, "");

            this.dtgWarehouseGridView.DataSource =
                this.dtExistingWarehouseInformation;
            if (this.dtExistingWarehouseInformation.Rows.Count > 0)
                this.dtgWarehouseGridView.Rows[0].Selected = true;

            this.dtgWarehouseGridView.Columns["M_WAREHOUSE_ID"].Visible = false;
            this.dtgWarehouseGridView.Columns["CREATED"].Visible = false;
            this.dtgWarehouseGridView.Columns["UPDATED"].Visible = false;
            this.dtgWarehouseGridView.Columns["CREATEDBY"].Visible = false;
            this.dtgWarehouseGridView.Columns["UPDATEDBY"].Visible = false;
        }

        private void dtgWarehouseGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgWarehouseGridView.SelectedRows.Count < 1)
            {
                return;
            }

            int selectedUserIndex =
                this.dtgWarehouseGridView.SelectedRows[0].Index;
            this.intCurrentWarehouseId =
                int.Parse(this.dtgWarehouseGridView.Rows[selectedUserIndex].
                        Cells["M_WAREHOUSE_ID"].Value.ToString());
            this.txtName.Text =
                this.dtgWarehouseGridView.Rows[selectedUserIndex].Cells["NAME"].Value.ToString();
            this.txtDescription.Text =
                this.dtgWarehouseGridView.Rows[selectedUserIndex].Cells["DESCRIPTION"].Value.ToString();

            if (this.dtgWarehouseGridView.Rows[selectedUserIndex].
                    Cells["ISACTIVE"].Value.ToString() == "Y")
                this.ckIsActive.Checked = true;
            else
                this.ckIsActive.Checked = false;

            if (this.dtgWarehouseGridView.Rows[selectedUserIndex].
                    Cells["ALLOWNEGATIVE"].Value.ToString() == "Y")
                this.ckAllowNegative.Checked = true;
            else
                this.ckAllowNegative.Checked = false;
            
        }

    }
}
