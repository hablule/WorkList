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
    public partial class frmOrganisation : Panel
    {
        public frmOrganisation()
        {
            InitializeComponent();
        }

        int intCurrentOrganisationId = -1;

        private Color clNormalLableColor = Color.Black;
        private Color clErrorLableColor = Color.Red;
        private Color clChangedLableColor = Color.Blue;

        DataTable dtNewOrganisationInformation = new DataTable();
        DataTable dtExistingOrganisationInformation = new DataTable();

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


        public void frmOrganisation_Load(object sender, EventArgs e)
        {
            if (generalResultInformation.currentFormIsReadOnly)
            {
                this.tlsDelete.Visible = false;
                this.tlsNew.Visible = false;
                this.tlsSave.Visible = false;                
            }

            this.dtExistingOrganisationInformation =
                    this.getDatafromDataBase.getAD_ORGInfo(null,
                            "", "", "", triStateBool.ignor, true, "");

            this.dtgOrganisationGridView.DataSource =
                this.dtExistingOrganisationInformation;

            this.dtgOrganisationGridView.Columns["AD_ORG_ID"].Visible = false;
            this.dtgOrganisationGridView.Columns["CREATED"].Visible = false;
            this.dtgOrganisationGridView.Columns["UPDATED"].Visible = false;
            this.dtgOrganisationGridView.Columns["CREATEDBY"].Visible = false;
            this.dtgOrganisationGridView.Columns["UPDATEDBY"].Visible = false;

        }

        private void tlsNew_Click(object sender, EventArgs e)
        {
            this.intCurrentOrganisationId = -1;

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

            this.dtNewOrganisationInformation =
               this.getDatafromDataBase.getAD_ORGInfo(null, "", "", "", triStateBool.ignor, true, "");

            DataRow drNewOrganisation = this.dtNewOrganisationInformation.NewRow();

            if (this.intCurrentOrganisationId != -1)
            {
                drNewOrganisation["AD_ORG_ID"] = this.intCurrentOrganisationId;
                stTypeOfChange = "UPDATE";
            }
            else
                stTypeOfChange = "INSERT";

            drNewOrganisation["NAME"] = this.txtName.Text;

            if (this.ckIsActive.Checked)
                drNewOrganisation["ISACTIVE"] = "Y";
            else
                drNewOrganisation["ISACTIVE"] = "N";

            drNewOrganisation["DESCRIPTION"] = this.txtDescription.Text;

            this.dtNewOrganisationInformation.Rows.Add(drNewOrganisation);

            string[] primaryKeySepartor = { " <(", ")>||" };
            string[] primaryKey =
                this.getDatafromDataBase.changeDataBaseTableData
                    (this.dtNewOrganisationInformation.Copy(), "AD_ORG", stTypeOfChange)[0]
                    .Split(primaryKeySepartor, StringSplitOptions.RemoveEmptyEntries);

            if (primaryKey.Length > 1 && stTypeOfChange == "INSERT")
            {
                this.intCurrentOrganisationId = int.Parse(primaryKey[1]);
                this.dtExistingOrganisationInformation =
                    this.getDatafromDataBase.getAD_ORGInfo(null,
                            "", "", "", triStateBool.ignor, false, "");

                this.dtgOrganisationGridView.DataSource =
                    this.dtExistingOrganisationInformation;
                if (this.dtExistingOrganisationInformation.Rows.Count > 0)
                    this.dtgOrganisationGridView.
                        Rows[this.dtExistingOrganisationInformation.Rows.Count - 1].Selected = true;
            }
        }

        private void tlsSearch_Click(object sender, EventArgs e)
        {
            this.dtExistingOrganisationInformation =
                    this.getDatafromDataBase.getAD_ORGInfo(null,
                            "", "", "", triStateBool.ignor, false, "");

            this.dtgOrganisationGridView.DataSource =
                this.dtExistingOrganisationInformation;
            if (this.dtExistingOrganisationInformation.Rows.Count > 0)
                this.dtgOrganisationGridView.Rows[0].Selected = true;

            this.dtgOrganisationGridView.Columns["AD_ORG_ID"].Visible = false;
            this.dtgOrganisationGridView.Columns["CREATED"].Visible = false;
            this.dtgOrganisationGridView.Columns["UPDATED"].Visible = false;
            this.dtgOrganisationGridView.Columns["CREATEDBY"].Visible = false;
            this.dtgOrganisationGridView.Columns["UPDATEDBY"].Visible = false;
        }

        private void dtgOrganisationGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgOrganisationGridView.SelectedRows.Count < 1)
            {
                return;
            }

            int selectedOrganisatinoIndex =
                this.dtgOrganisationGridView.SelectedRows[0].Index;
            this.intCurrentOrganisationId =
                int.Parse(this.dtgOrganisationGridView.Rows[selectedOrganisatinoIndex].
                        Cells["AD_ORG_ID"].Value.ToString());
            this.txtName.Text =
                this.dtgOrganisationGridView.Rows[selectedOrganisatinoIndex].Cells["NAME"].Value.ToString();
            this.txtDescription.Text =
                this.dtgOrganisationGridView.Rows[selectedOrganisatinoIndex].Cells["DESCRIPTION"].Value.ToString();

            if (this.dtgOrganisationGridView.Rows[selectedOrganisatinoIndex].
                    Cells["ISACTIVE"].Value.ToString() == "Y")
                this.ckIsActive.Checked = true;
            else
                this.ckIsActive.Checked = false;
        }
        
    }
}
