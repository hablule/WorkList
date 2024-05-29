using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dbConnection;

namespace SecurityGuardScheduling
{
    public partial class frmGaurd : Form
    {
        public frmGaurd()
        {
            InitializeComponent();
        }

        string dbNull = generalResultInformation.dbNull;

        int dtgGaurdSelectedRowIndex = -1;

        int intCurrentGaurdID = -1;

        Color clNormalLableColor = Color.Black;
        Color clErrorLableColor = Color.Red;
        Color clChangedLableColor = Color.Blue;

        DataTable dtGaurd = new DataTable();
        DataTable dtNewGaurd = new DataTable();


        dataBuilder getDataFromDB = new dataBuilder();
        checkAndEstablishDbConnectionSettings dbCk =
                new checkAndEstablishDbConnectionSettings();

        private bool isFormComplete()
        {
            bool formIsComplete = true;

            if (this.txtCode.Text == "")
            {
                this.lblPersonnelID.ForeColor = this.clErrorLableColor;
                formIsComplete = false;
            }
            else
                this.lblPersonnelID.ForeColor = this.clNormalLableColor;


            if (this.txtFirstName.Text == "")
            {
                this.lblFirstName.ForeColor = this.clErrorLableColor;
                formIsComplete = false;
            }
            else
                this.lblFirstName.ForeColor = this.clNormalLableColor;


            if (this.txtMiddleName.Text == "")
            {
                this.lblMiddleName.ForeColor = this.clErrorLableColor;
                formIsComplete = false;
            }
            else
                this.lblMiddleName.ForeColor = this.clNormalLableColor;

            return formIsComplete;

        }


        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            this.intCurrentGaurdID = -1;

            this.txtCode.Text = "";
            this.txtFirstName.Text = "";
            this.txtMiddleName.Text = "";
            this.txtLastName.Text = "";

            this.ckIsActive.Checked = true;
            this.txtDescription.Text = "";
            
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (!this.isFormComplete())
            {
                MessageBox.Show("Please complete missing form element before proceeding.",
                    "SAVE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            

            this.dtNewGaurd =
                getDataFromDB.getGS_GAURDInfo(null,
                    "", "", "", "", "", false, true, "AND");

            DataRow drNewGaurd = this.dtNewGaurd.NewRow();

            if(this.intCurrentGaurdID != -1)
                drNewGaurd["GS_GAURD_ID"] = this.intCurrentGaurdID;
            drNewGaurd["CODE"] = this.txtCode.Text;
            drNewGaurd["FIRSTNAME"] =
                this.txtFirstName.Text == "" ? dbNull : this.txtFirstName.Text;
            drNewGaurd["MIDDELNAME"] =
                this.txtMiddleName.Text == "" ? dbNull : this.txtMiddleName.Text;
            drNewGaurd["LASTNAME"] =
                this.txtLastName.Text == "" ? dbNull : this.txtLastName.Text;
            drNewGaurd["ISACTIVE"] =
                this.ckIsActive.Checked ? "Y" : "N";
            drNewGaurd["DESCRIPTION"] =
                this.txtDescription.Text == "" ? dbNull : this.txtDescription.Text;

            this.dtNewGaurd.Rows.Add(drNewGaurd);

            string[] gaurdId =
                this.getDataFromDB.changeDataBaseTableData(dtNewGaurd, "GS_GAURD",
                this.intCurrentGaurdID != -1 ? "UPDATE" : "INSERT");

            if (!dbCommitFailure.dbCommitError)
            {
                if (intCurrentGaurdID == -1)
                {
                    DataRow drExistingGaurd = this.dtGaurd.NewRow();

                    drExistingGaurd["GS_GAURD_ID"] = gaurdId[0].Split(new string[] { "(", ")" }, StringSplitOptions.None)[1];
                    drExistingGaurd["CODE"] = this.txtCode.Text;
                    drExistingGaurd["FIRSTNAME"] = this.txtFirstName.Text;
                    drExistingGaurd["MIDDELNAME"] = this.txtMiddleName.Text;
                    drExistingGaurd["LASTNAME"] = this.txtLastName.Text;
                    drExistingGaurd["ISACTIVE"] = this.ckIsActive.Checked ? "Y" : "N";
                    drExistingGaurd["DESCRIPTION"] = this.txtDescription.Text;

                    this.dtGaurd.Rows.Add(drExistingGaurd);
                    this.dtgGaurds.Rows[this.dtgGaurds.Rows.Count - 1].Selected = true;
                }
                else
                {
                    if(this.dtgGaurdSelectedRowIndex >= 0 &&
                        this.dtgGaurdSelectedRowIndex < this.dtGaurd.Rows.Count)
                    {
                        if (int.Parse(this.dtGaurd.Rows[this.dtgGaurdSelectedRowIndex]["GS_GAURD_ID"].ToString()) == this.intCurrentGaurdID)
                        {
                            this.dtGaurd.Rows[this.dtgGaurdSelectedRowIndex]["CODE"] = this.txtCode.Text;
                            this.dtGaurd.Rows[this.dtgGaurdSelectedRowIndex]["FIRSTNAME"] = this.txtFirstName.Text;
                            this.dtGaurd.Rows[this.dtgGaurdSelectedRowIndex]["MIDDELNAME"] = this.txtFirstName.Text;
                            this.dtGaurd.Rows[this.dtgGaurdSelectedRowIndex]["LASTNAME"] = this.txtFirstName.Text;
                            this.dtGaurd.Rows[this.dtgGaurdSelectedRowIndex]["ISACTIVE"] = this.ckIsActive.Checked ? "Y" : "N";
                            this.dtGaurd.Rows[this.dtgGaurdSelectedRowIndex]["DESCRIPTION"] = this.txtDescription.Text;
                            return;
                        }
                    }
                    
                    for (int rowCounter = 0; rowCounter <= this.dtGaurd.Rows.Count - 1; rowCounter++)
                    {
                        if (int.Parse(this.dtGaurd.Rows[rowCounter]["GS_GAURD_ID"].ToString()) == this.intCurrentGaurdID)
                        {
                            this.dtGaurd.Rows[rowCounter]["CODE"] = this.txtCode.Text;
                            this.dtGaurd.Rows[rowCounter]["FIRSTNAME"] = this.txtFirstName.Text;
                            this.dtGaurd.Rows[rowCounter]["MIDDELNAME"] = this.txtFirstName.Text;
                            this.dtGaurd.Rows[rowCounter]["LASTNAME"] = this.txtFirstName.Text;
                            this.dtGaurd.Rows[rowCounter]["ISACTIVE"] = this.ckIsActive.Checked ? "Y" : "N";
                            this.dtGaurd.Rows[rowCounter]["DESCRIPTION"] = this.txtDescription.Text;
                            return;
                        }
                    }
                }
            }
        }

        private void searchToolStripButton_Click(object sender, EventArgs e)
        {
            this.dtGaurd =
                getDataFromDB.getGS_GAURDInfo(null,
                    "", "", "", "", "", false, false, "AND");

            this.dtGaurd.Columns["CODE"].SetOrdinal(0);
            this.dtGaurd.Columns["FIRSTNAME"].SetOrdinal(1);
            this.dtGaurd.Columns["MIDDELNAME"].SetOrdinal(2);
            this.dtGaurd.Columns["LASTNAME"].SetOrdinal(3);
            this.dtGaurd.Columns["ISACTIVE"].SetOrdinal(4);

            this.dtgGaurds.DataSource = this.dtGaurd;

            this.dtgGaurds.Columns["CODE"].HeaderText = "Personnel ID";
            this.dtgGaurds.Columns["FIRSTNAME"].HeaderText = "First Name";
            this.dtgGaurds.Columns["MIDDELNAME"].HeaderText = "Middle Name";
            this.dtgGaurds.Columns["LASTNAME"].HeaderText = "Last Name";
            this.dtgGaurds.Columns["ISACTIVE"].HeaderText = "Active";


            this.dtgGaurds.Columns["GS_GAURD_ID"].Visible = false;
            this.dtgGaurds.Columns["CREATED"].Visible = false;
            this.dtgGaurds.Columns["CREATEDBY"].Visible = false;
            this.dtgGaurds.Columns["UPDATED"].Visible = false;
            this.dtgGaurds.Columns["UPDATEDBY"].Visible = false;
            this.dtgGaurds.Columns["DESCRIPTION"].Visible = false;
        }

        private void exitToolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGaurd_Load(object sender, EventArgs e)
        {            

            this.newToolStripButton_Click(sender, e);

            this.dtGaurd =
                getDataFromDB.getGS_GAURDInfo(null,
                    "", "", "", "", "", false, true, "AND");

            this.dtGaurd.Columns["CODE"].SetOrdinal(0);
            this.dtGaurd.Columns["FIRSTNAME"].SetOrdinal(1);
            this.dtGaurd.Columns["MIDDELNAME"].SetOrdinal(2);
            this.dtGaurd.Columns["LASTNAME"].SetOrdinal(3);
            this.dtGaurd.Columns["ISACTIVE"].SetOrdinal(4);

            this.dtgGaurds.DataSource = this.dtGaurd;

            this.dtgGaurds.Columns["CODE"].HeaderText = "Personnel ID";
            this.dtgGaurds.Columns["FIRSTNAME"].HeaderText = "First Name";
            this.dtgGaurds.Columns["MIDDELNAME"].HeaderText = "Middle Name";
            this.dtgGaurds.Columns["LASTNAME"].HeaderText = "Last Name";
            this.dtgGaurds.Columns["ISACTIVE"].HeaderText = "Active";
                       
            
            this.dtgGaurds.Columns["GS_GAURD_ID"].Visible = false;
            this.dtgGaurds.Columns["CREATED"].Visible = false;
            this.dtgGaurds.Columns["CREATEDBY"].Visible = false;
            this.dtgGaurds.Columns["UPDATED"].Visible = false;
            this.dtgGaurds.Columns["UPDATEDBY"].Visible = false;
            this.dtgGaurds.Columns["DESCRIPTION"].Visible = false;

            
            
        }
        
        private void dtgGaurds_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgGaurds.SelectedRows.Count < 1)
            {
                this.intCurrentGaurdID = -1;
                return;
            }
            int dtgselectedRowIndex = 
                this.dtgGaurds.SelectedRows[0].Index;

            this.intCurrentGaurdID = 
                int.Parse(this.dtgGaurds.Rows[dtgselectedRowIndex].Cells["GS_GAURD_ID"].Value.ToString());

            this.txtCode.Text =
                this.dtgGaurds.Rows[dtgselectedRowIndex].Cells["CODE"].Value.ToString();

            this.txtFirstName.Text =
                this.dtgGaurds.Rows[dtgselectedRowIndex].Cells["FIRSTNAME"].Value.ToString();

            this.txtMiddleName.Text =
                this.dtgGaurds.Rows[dtgselectedRowIndex].Cells["MIDDELNAME"].Value.ToString();

            this.txtLastName.Text =
                this.dtgGaurds.Rows[dtgselectedRowIndex].Cells["LASTNAME"].Value.ToString();

            this.ckIsActive.Checked =
                this.dtgGaurds.Rows[dtgselectedRowIndex].Cells["ISACTIVE"].Value.ToString() == "Y" ? true : false;

            this.txtDescription.Text =
                this.dtgGaurds.Rows[dtgselectedRowIndex].Cells["DESCRIPTION"].Value.ToString();
            
        }
        
    }
}
