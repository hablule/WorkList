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
    public partial class frmShift : Form
    {
        public frmShift()
        {
            InitializeComponent();
        }


        string dbNull = generalResultInformation.dbNull;

        int dtgShiftSelectedRowIndex = -1;

        int intCurrentShiftID = -1;

        Color clNormalLableColor = Color.Black;
        Color clErrorLableColor = Color.Red;
        Color clChangedLableColor = Color.Blue;

        DataTable dtShift = new DataTable();
        DataTable dtNewShift = new DataTable();


        dataBuilder getDataFromDB = new dataBuilder();
        checkAndEstablishDbConnectionSettings dbCk =
                new checkAndEstablishDbConnectionSettings();

        private bool isFormComplete()
        {
            bool formIsComplete = true;

            if (this.txtCode.Text == "")
            {
                this.lblCode.ForeColor = this.clErrorLableColor;
                formIsComplete = false;
            }
            else
                this.lblCode.ForeColor = this.clNormalLableColor;

            if (dtpStartTime.Value == dtpEndTime.Value)
            {
                this.lblStartTime.ForeColor = this.clErrorLableColor;
                this.lblEndTime.ForeColor = this.clErrorLableColor;
            }
            else
            {
                this.lblStartTime.ForeColor = this.clNormalLableColor;
                this.lblEndTime.ForeColor = this.clNormalLableColor;
            }


            return formIsComplete;            
        }


        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            this.intCurrentShiftID = -1;

            this.txtCode.Text = "";
            this.txtName.Text = "";
            
            this.ckIsActive.Checked = true;
            this.txtDescription.Text = "";

            this.lblCode.ForeColor = this.clNormalLableColor;
            this.lblStartTime.ForeColor = this.clNormalLableColor;
            this.lblEndTime.ForeColor = this.clNormalLableColor;

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (!this.isFormComplete())
            {
                MessageBox.Show("Please complete missing form element before proceeding.",
                    "SAVE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.dtNewShift =
                getDataFromDB.getGS_SHIFTInfo(null,
                    "", "", "", "", false, true, "AND");

            DataRow drNewShift = this.dtNewShift.NewRow();

            if (this.intCurrentShiftID != -1)
                drNewShift["GS_SHIFT_ID"] = this.intCurrentShiftID;
            drNewShift["CODE"] = this.txtCode.Text;
            drNewShift["NAME"] =
                this.txtName.Text == "" ? dbNull : this.txtName.Text;

            drNewShift["STARTTIME"] =
                this.dtpStartTime.Value;
            drNewShift["ENDTIME"] =
                this.dtpEndTime.Value;
            
            drNewShift["ISACTIVE"] =
                this.ckIsActive.Checked ? "Y" : "N";
            drNewShift["DESCRIPTION"] =
                this.txtDescription.Text == "" ? dbNull : this.txtDescription.Text;

            this.dtNewShift.Rows.Add(drNewShift);

            string[] shiftId =
                this.getDataFromDB.changeDataBaseTableData(dtNewShift, "GS_SHIFT",
                this.intCurrentShiftID != -1 ? "UPDATE" : "INSERT");

            if (!dbCommitFailure.dbCommitError)
            {
                if (intCurrentShiftID == -1)
                {
                    DataRow drExistingShift = this.dtShift.NewRow();

                    drExistingShift["GS_SHIFT_ID"] = 
                        shiftId[0].Split(new string[] { "(", ")" }, StringSplitOptions.None)[1];
                    drExistingShift["CODE"] = this.txtCode.Text;
                    drExistingShift["NAME"] = this.txtName.Text;
                    drExistingShift["STARTTIME"] = this.dtpStartTime.Value;
                    drExistingShift["ENDTIME"] = this.dtpEndTime.Value;
                    drExistingShift["ISACTIVE"] = this.ckIsActive.Checked ? "Y" : "N";
                    drExistingShift["DESCRIPTION"] = this.txtDescription.Text;

                    this.dtShift.Rows.Add(drExistingShift);
                    this.dtgShifts.Rows[this.dtgShifts.Rows.Count - 1].Selected = true;
                }
                else
                {
                    if (this.dtgShiftSelectedRowIndex >= 0 &&
                        this.dtgShiftSelectedRowIndex < this.dtShift.Rows.Count)
                    {
                        if (int.Parse(this.dtShift.Rows[this.dtgShiftSelectedRowIndex]["GS_SHIFT_ID"].ToString()) == this.intCurrentShiftID)
                        {
                            this.dtShift.Rows[this.dtgShiftSelectedRowIndex]["CODE"] = this.txtCode.Text;
                            this.dtShift.Rows[this.dtgShiftSelectedRowIndex]["NAME"] = this.txtName.Text;
                            this.dtShift.Rows[this.dtgShiftSelectedRowIndex]["STARTTIME"] = this.dtpStartTime.Value;
                            this.dtShift.Rows[this.dtgShiftSelectedRowIndex]["ENDTIME"] = this.dtpEndTime.Value;
                            this.dtShift.Rows[this.dtgShiftSelectedRowIndex]["ISACTIVE"] = this.ckIsActive.Checked ? "Y" : "N";
                            this.dtShift.Rows[this.dtgShiftSelectedRowIndex]["DESCRIPTION"] = this.txtDescription.Text;
                            return;
                        }
                    }

                    for (int rowCounter = 0; rowCounter <= this.dtShift.Rows.Count - 1; rowCounter++)
                    {
                        if (int.Parse(this.dtShift.Rows[rowCounter]["GS_SHIFT_ID"].ToString()) == this.intCurrentShiftID)
                        {
                            this.dtShift.Rows[rowCounter]["CODE"] = this.txtCode.Text;
                            this.dtShift.Rows[rowCounter]["NAME"] = this.txtName.Text;
                            this.dtShift.Rows[rowCounter]["STARTTIME"] = this.dtpStartTime.Value;
                            this.dtShift.Rows[rowCounter]["ENDTIME"] = this.dtpEndTime.Value;
                            this.dtShift.Rows[rowCounter]["ISACTIVE"] = this.ckIsActive.Checked ? "Y" : "N";
                            this.dtShift.Rows[rowCounter]["DESCRIPTION"] = this.txtDescription.Text;
                            return;
                        }
                    }
                }
            }
        }

        private void searchToolStripButton_Click(object sender, EventArgs e)
        {
            this.dtShift =
                getDataFromDB.getGS_SHIFTInfo(null,
                    "", "", "", "", false, false, "AND");

            this.dtShift.Columns["CODE"].SetOrdinal(0);
            this.dtShift.Columns["NAME"].SetOrdinal(1);            
            this.dtShift.Columns["ISACTIVE"].SetOrdinal(2);
            this.dtShift.Columns["STARTTIME"].SetOrdinal(3);
            this.dtShift.Columns["ENDTIME"].SetOrdinal(4);

            this.dtgShifts.DataSource = this.dtShift;

            this.dtgShifts.Columns["CODE"].HeaderText = "Code";
            this.dtgShifts.Columns["NAME"].HeaderText = "Name";
            this.dtgShifts.Columns["STARTTIME"].HeaderText = "Starts";
            this.dtgShifts.Columns["ENDTIME"].HeaderText = "Ends";
            this.dtgShifts.Columns["ISACTIVE"].HeaderText = "Active";


            this.dtgShifts.Columns["GS_SHIFT_ID"].Visible = false;
            this.dtgShifts.Columns["CREATED"].Visible = false;
            this.dtgShifts.Columns["CREATEDBY"].Visible = false;
            this.dtgShifts.Columns["UPDATED"].Visible = false;
            this.dtgShifts.Columns["UPDATEDBY"].Visible = false;
            this.dtgShifts.Columns["DESCRIPTION"].Visible = false;
            
        }

        private void exitToolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void frmShift_Load(object sender, EventArgs e)
        {
            
            this.dtpStartTime.CustomFormat = "hh:mm:ss tt";
            this.dtpStartTime.Format = DateTimePickerFormat.Custom;

            this.dtpEndTime.CustomFormat = "hh:mm:ss tt";
            this.dtpEndTime.Format = DateTimePickerFormat.Custom;

            this.newToolStripButton_Click(sender, e);

            this.dtShift =
                getDataFromDB.getGS_SHIFTInfo(null,
                    "", "", "", "", false, true, "AND");

            this.dtShift.Columns["CODE"].SetOrdinal(0);
            this.dtShift.Columns["NAME"].SetOrdinal(1);
            this.dtShift.Columns["ISACTIVE"].SetOrdinal(2);
            this.dtShift.Columns["STARTTIME"].SetOrdinal(3);
            this.dtShift.Columns["ENDTIME"].SetOrdinal(4);

            this.dtgShifts.DataSource = this.dtShift;

            this.dtgShifts.Columns["CODE"].HeaderText = "Code";
            this.dtgShifts.Columns["NAME"].HeaderText = "Name";
            this.dtgShifts.Columns["STARTTIME"].HeaderText = "Starts";
            this.dtgShifts.Columns["ENDTIME"].HeaderText = "Ends";
            this.dtgShifts.Columns["ISACTIVE"].HeaderText = "Active";
            

            this.dtgShifts.Columns["GS_SHIFT_ID"].Visible = false;
            this.dtgShifts.Columns["CREATED"].Visible = false;
            this.dtgShifts.Columns["CREATEDBY"].Visible = false;
            this.dtgShifts.Columns["UPDATED"].Visible = false;
            this.dtgShifts.Columns["UPDATEDBY"].Visible = false;
            this.dtgShifts.Columns["DESCRIPTION"].Visible = false;
        }

        private void dtgShifts_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgShifts.SelectedRows.Count < 1)
            {
                this.intCurrentShiftID = -1;
                return;
            }
            int dtgselectedRowIndex =
                this.dtgShifts.SelectedRows[0].Index;

            this.intCurrentShiftID =
                int.Parse(this.dtgShifts.Rows[dtgselectedRowIndex].Cells["GS_SHIFT_ID"].Value.ToString());

            this.txtCode.Text =
                this.dtgShifts.Rows[dtgselectedRowIndex].Cells["CODE"].Value.ToString();

            this.txtName.Text =
                this.dtgShifts.Rows[dtgselectedRowIndex].Cells["NAME"].Value.ToString();

            this.dtpStartTime.Value =
                DateTime.Parse(this.dtgShifts.Rows[dtgselectedRowIndex].Cells["STARTTIME"].Value.ToString());

            this.dtpEndTime.Value =
                DateTime.Parse(this.dtgShifts.Rows[dtgselectedRowIndex].Cells["ENDTIME"].Value.ToString());

            this.ckIsActive.Checked =
                this.dtgShifts.Rows[dtgselectedRowIndex].Cells["ISACTIVE"].Value.ToString() == "Y" ? true : false;

            this.txtDescription.Text =
                this.dtgShifts.Rows[dtgselectedRowIndex].Cells["DESCRIPTION"].Value.ToString();
            
        }


    }
}
