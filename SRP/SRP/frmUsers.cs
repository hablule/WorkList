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
    public partial class frmUsers : Panel
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        string stringShopID = generalResultInformation.activeStation;
        int intCurrentUserId = -1;

        Color clNormalLableColor = Color.Black;
        Color clErrorLableColor = Color.Red;
        Color clChangedLableColor = Color.Blue;

        DataTable dtNewUserInformation = new DataTable();
        DataTable dtExistingUserInformation = new DataTable();

        dataBuilder getDatafromDataBase = new dataBuilder();


        private bool checkFormCompleteness()
        {
            bool formComplere = true;
            if (this.txtUserName.Text == "")
            {
                this.lblUserName.ForeColor = clErrorLableColor;
                formComplere = false;
            }
            else
                this.lblUserName.ForeColor = clNormalLableColor;

            if (this.txtPassword.Text == "")
            {
                this.lblPassword.ForeColor = clErrorLableColor;
                formComplere = false;
            }
            else
                this.lblPassword.ForeColor = clNormalLableColor;

            if (this.txtFirstName.Text == "")
            {
                this.lblFirstName.ForeColor = clErrorLableColor;
                formComplere = false;
            }
            else
                this.lblFirstName.ForeColor = clNormalLableColor;

            return formComplere;
        }


        public void frmUsers_Load(object sender, EventArgs e)
        {
            if (generalResultInformation.currentFormIsReadOnly)
            {
                this.tlsDelete.Visible = false;
                this.tlsNew.Visible = false;
                this.tlsSave.Visible = false;
            }

            this.dtExistingUserInformation =
                this.getDatafromDataBase.getU_USERInfo(null, "", 
                    "", "", "", "", triStateBool.ignor, true, "");

            this.dtgUsersGridView.DataSource = this.dtExistingUserInformation;

            this.dtgUsersGridView.Columns["M_SHOP_ID"].Visible = false;
            this.dtgUsersGridView.Columns["AD_ORG_ID"].Visible = false;
            this.dtgUsersGridView.Columns["U_USER_ID"].Visible = false;
            this.dtgUsersGridView.Columns["CREATED"].Visible = false;
            this.dtgUsersGridView.Columns["UPDATED"].Visible = false;
            this.dtgUsersGridView.Columns["CREATEDBY"].Visible = false;
            this.dtgUsersGridView.Columns["UPDATEDBY"].Visible = false;
            this.dtgUsersGridView.Columns["PASSWORD"].Visible = false;
        }

        private void tlsNew_Click(object sender, EventArgs e)
        {
            this.intCurrentUserId = -1;

            this.lblFirstName.ForeColor = clNormalLableColor;
            this.lblMiddleName.ForeColor = clNormalLableColor;
            this.lblUserName.ForeColor = clNormalLableColor;
            this.lblPassword.ForeColor = clNormalLableColor;

            this.txtFirstName.Text = "";
            this.txtMiddleName.Text = "";
            this.txtUserName.Text = "";
            this.txtPassword.Text = "";
            this.ckIsActive.Checked = true;
            this.txtDescription.Text = "";                        
        }

        private void tlsSave_Click(object sender, EventArgs e)
        {
            string stTypeOfChange = "INSERT";
            if (!this.checkFormCompleteness())
            {                
                MessageBox.Show("Please complete the missing form element before proceeding.",
                    "SRP SAVE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.dtNewUserInformation =
               this.getDatafromDataBase.getU_USERInfo(null, "",
                   "", "", "", "", triStateBool.ignor, true, "");

            DataRow drNewUser = this.dtNewUserInformation.NewRow();

            if (this.intCurrentUserId != -1)
            {
                drNewUser["U_USER_ID"] = this.intCurrentUserId;
                stTypeOfChange = "UPDATE";
            }
            else
                stTypeOfChange = "INSERT";

            drNewUser["M_SHOP_ID"] = this.stringShopID;
            drNewUser["FIRSTNAME"] = this.txtFirstName.Text;
            drNewUser["MIDDLENAME"] = this.txtMiddleName.Text;

            drNewUser["USERNAME"] = this.txtUserName.Text;
            drNewUser["PASSWORD"] = this.txtPassword.Text;

            if (this.ckIsActive.Checked)
                drNewUser["ISACTIVE"] = "Y";
            else
                drNewUser["ISACTIVE"] = "N";

            drNewUser["DESCRIPTION"] = this.txtDescription.Text;

            this.dtNewUserInformation.Rows.Add(drNewUser);

            string[] primaryKeySepartor = { " <(", ")>||" };
            string[] primaryKey =
                this.getDatafromDataBase.changeDataBaseTableData
                    (this.dtNewUserInformation.Copy(), "U_USER", stTypeOfChange)[0]
                    .Split(primaryKeySepartor, StringSplitOptions.RemoveEmptyEntries);

            if (primaryKey.Length > 1 && stTypeOfChange == "INSERT")
            {
                this.intCurrentUserId = int.Parse(primaryKey[1]);
                this.dtExistingUserInformation =
                    this.getDatafromDataBase.getU_USERInfo(null,
                            "","", "","","", triStateBool.ignor,false, "");

                this.dtgUsersGridView.DataSource =
                    this.dtExistingUserInformation;
                if (this.dtExistingUserInformation.Rows.Count > 0)
                    this.dtgUsersGridView.
                        Rows[this.dtExistingUserInformation.Rows.Count - 1].Selected = true;
            }              
        }

        private void tlsSearch_Click(object sender, EventArgs e)
        {
            this.dtExistingUserInformation =
                    this.getDatafromDataBase.getU_USERInfo(null,
                            "", "", "", "", "", triStateBool.ignor, false, "");

            this.dtgUsersGridView.DataSource =
                    this.dtExistingUserInformation;
            if (this.dtExistingUserInformation.Rows.Count > 0)
                this.dtgUsersGridView.Rows[0].Selected = true;

            this.dtgUsersGridView.Columns["U_USER_ID"].Visible = false;
            this.dtgUsersGridView.Columns["CREATED"].Visible = false;
            this.dtgUsersGridView.Columns["UPDATED"].Visible = false;
            this.dtgUsersGridView.Columns["PASSWORD"].Visible = false;
        }

        private void dtgUsersGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgUsersGridView.SelectedRows.Count < 1)
            {
                return;
            }

            int selectedUserIndex =
                this.dtgUsersGridView.SelectedRows[0].Index;
            this.intCurrentUserId =
                int.Parse(this.dtgUsersGridView.Rows[selectedUserIndex].
                        Cells["U_USER_ID"].Value.ToString());
            this.txtFirstName.Text =
                this.dtgUsersGridView.Rows[selectedUserIndex].Cells["FIRSTNAME"].Value.ToString();
            this.txtMiddleName.Text =
                this.dtgUsersGridView.Rows[selectedUserIndex].Cells["MIDDLENAME"].Value.ToString();
            this.txtDescription.Text =
                this.dtgUsersGridView.Rows[selectedUserIndex].Cells["DESCRIPTION"].Value.ToString();
            this.txtUserName.Text =
                this.dtgUsersGridView.Rows[selectedUserIndex].Cells["USERNAME"].Value.ToString();
            this.txtPassword.Text =
                this.dtgUsersGridView.Rows[selectedUserIndex].Cells["PASSWORD"].Value.ToString();

            if (this.dtgUsersGridView.Rows[selectedUserIndex].
                    Cells["ISACTIVE"].Value.ToString() == "Y")
                this.ckIsActive.Checked = true;
            else
                this.ckIsActive.Checked = false;

        }
    }
}
