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
    public partial class frmShops : Panel
    {
        public frmShops()
        {
            InitializeComponent();
        }

        int intCurrentShopId = -1;

        private Color clNormalLableColor = Color.Black;
        private Color clErrorLableColor = Color.Red;
        private Color clChangedLableColor = Color.Blue;

        DataTable dtNewShopInformation = new DataTable();
        DataTable dtExistingShopInformation = new DataTable();

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


        public void frmShops_Load(object sender, EventArgs e)
        {
            if (generalResultInformation.currentFormIsReadOnly)
            {
                this.tlsDelete.Visible = false;
                this.tlsNew.Visible = false;
                this.tlsSave.Visible = false;                
            }

            this.dtExistingShopInformation =
                    this.getDatafromDataBase.getM_SHOPInfo(null,
                            "", "", "", triStateBool.ignor, true, "");

            this.dtgShopGridView.DataSource =
                this.dtExistingShopInformation;

            this.dtgShopGridView.Columns["M_SHOP_ID"].Visible = false;
            this.dtgShopGridView.Columns["CREATED"].Visible = false;
            this.dtgShopGridView.Columns["UPDATED"].Visible = false;
            this.dtgShopGridView.Columns["CREATEDBY"].Visible = false;
            this.dtgShopGridView.Columns["UPDATEDBY"].Visible = false;

        }

        private void tlsNew_Click(object sender, EventArgs e)
        {
            this.intCurrentShopId = -1;

            this.txtName.Text = "";
            this.ckIsActive.Checked = true;
            this.txtDescription.Text = "";                        
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

            this.dtNewShopInformation =
               this.getDatafromDataBase.getM_SHOPInfo(null, "", "", "", triStateBool.ignor, true, "");

            DataRow drNewShop = this.dtNewShopInformation.NewRow();

            if (this.intCurrentShopId != -1)
            {
                drNewShop["M_SHOP_ID"] = this.intCurrentShopId;
                stTypeOfChange = "UPDATE";
            }
            else
                stTypeOfChange = "INSERT";

            drNewShop["NAME"] = this.txtName.Text;

            if (this.ckIsActive.Checked)
                drNewShop["ISACTIVE"] = "Y";
            else
                drNewShop["ISACTIVE"] = "N";

            drNewShop["DESCRIPTION"] = this.txtDescription.Text;

            this.dtNewShopInformation.Rows.Add(drNewShop);

            string[] primaryKeySepartor = { " <(", ")>||" };
            string[] primaryKey =
                this.getDatafromDataBase.changeDataBaseTableData
                    (this.dtNewShopInformation.Copy(), "M_SHOP", stTypeOfChange)[0]
                    .Split(primaryKeySepartor, StringSplitOptions.RemoveEmptyEntries);

            if (primaryKey.Length > 1 && stTypeOfChange == "INSERT")
            {
                this.intCurrentShopId = int.Parse(primaryKey[1]);
                this.dtExistingShopInformation =
                    this.getDatafromDataBase.getM_SHOPInfo(null,
                            "", "", "", triStateBool.ignor, false, "");

                this.dtgShopGridView.DataSource =
                    this.dtExistingShopInformation;
                if (this.dtExistingShopInformation.Rows.Count > 0)
                    this.dtgShopGridView.
                        Rows[this.dtExistingShopInformation.Rows.Count - 1].Selected = true;
            }
        }

        private void tlsSearch_Click(object sender, EventArgs e)
        {
            this.dtExistingShopInformation =
                    this.getDatafromDataBase.getM_SHOPInfo(null,
                            "", "", "", triStateBool.ignor, false, "");

            this.dtgShopGridView.DataSource =
                this.dtExistingShopInformation;
            if (this.dtExistingShopInformation.Rows.Count > 0)
                this.dtgShopGridView.Rows[0].Selected = true;

            this.dtgShopGridView.Columns["M_SHOP_ID"].Visible = false;
            this.dtgShopGridView.Columns["CREATED"].Visible = false;
            this.dtgShopGridView.Columns["UPDATED"].Visible = false;
            this.dtgShopGridView.Columns["CREATEDBY"].Visible = false;
            this.dtgShopGridView.Columns["UPDATEDBY"].Visible = false;
        }

        private void dtgShopGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgShopGridView.SelectedRows.Count < 1)
            {
                return;
            }

            int selectedShopIndex =
                this.dtgShopGridView.SelectedRows[0].Index;
            this.intCurrentShopId =
                int.Parse(this.dtgShopGridView.Rows[selectedShopIndex].
                        Cells["M_SHOP_ID"].Value.ToString());
            this.txtName.Text =
                this.dtgShopGridView.Rows[selectedShopIndex].Cells["NAME"].Value.ToString();
            this.txtDescription.Text =
                this.dtgShopGridView.Rows[selectedShopIndex].Cells["DESCRIPTION"].Value.ToString();

            if (this.dtgShopGridView.Rows[selectedShopIndex].
                    Cells["ISACTIVE"].Value.ToString() == "Y")
                this.ckIsActive.Checked = true;
            else
                this.ckIsActive.Checked = false;
        }
        
    }
}
