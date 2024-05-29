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
    public partial class frmExclusion : Form
    {
        public frmExclusion()
        {
            InitializeComponent();
        }

        string dbNull = generalResultInformation.dbNull;

        int dtgExclusionSelectedRowIndex = -1;

        int intCurrentExclusionID = -1;

        Color clNormalLableColor = Color.Black;
        Color clErrorLableColor = Color.Red;
        Color clChangedLableColor = Color.Blue;

        DataTable dtExclusion = new DataTable();

        DataTable dtAllActiveGaurds = new DataTable();
        DataTable dtAllActivePosts = new DataTable();
        DataTable dtAllActiveShifts = new DataTable();
        

        DataTable dtNewExclusion = new DataTable();


        dataBuilder getDataFromDB = new dataBuilder();
        checkAndEstablishDbConnectionSettings dbCk =
                new checkAndEstablishDbConnectionSettings();


        private daysOfWeek getCorrespondingDayOfWeek(string dOw)
        {
            List<daysOfWeek> lsDaysOfWeek = 
                new List<daysOfWeek>((daysOfWeek [])Enum.GetValues(typeof(daysOfWeek)));

            foreach (daysOfWeek day in lsDaysOfWeek)
            { 
                if(day.ToString().ToUpper() == dOw.ToUpper())
                    return day;
            }
            return daysOfWeek.A_None;
        }

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

            if (this.clbDaysOfWeek.CheckedItems.Count < 1 &&
                this.cmbDateLogic.SelectedIndex == 0)
            {                
                this.lblDaysOfWeek.ForeColor = this.clErrorLableColor;
                this.lblDate.ForeColor = this.clErrorLableColor;
                formIsComplete = false;
            }
            else
            {
                this.lblDaysOfWeek.ForeColor = this.clNormalLableColor;
                this.lblDate.ForeColor = this.clNormalLableColor;
            }



            if (this.ckIsGaurdExclusion.Checked &&
                this.clbGaurdsExcluded.CheckedItems.Count <= 0)
            {
                this.ckIsGaurdExclusion.ForeColor = this.clErrorLableColor;
                formIsComplete = false;
            }
            else
                this.ckIsGaurdExclusion.ForeColor = this.clNormalLableColor;

            
            if (this.ckIsPostExclusion.Checked &&
                this.clbPostsExcluded.CheckedItems.Count <= 0)
            {
                this.ckIsPostExclusion.ForeColor = this.clErrorLableColor;
                formIsComplete = false;
            }
            else
                this.ckIsPostExclusion.ForeColor = this.clNormalLableColor;
            

            if (this.ckIsShiftExclusion.Checked &&
                this.clbShiftsExcluded.CheckedItems.Count <= 0)
            {
                this.ckIsShiftExclusion.ForeColor = this.clErrorLableColor;
                formIsComplete = false;
            }
            else
                this.ckIsShiftExclusion.ForeColor = this.clNormalLableColor;
            
                        
            return formIsComplete;
        }


        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            this.intCurrentExclusionID = -1;

            this.txtCode.Text = "";
            this.txtName.Text = "";
                        
            foreach (int index in this.clbDaysOfWeek.CheckedIndices)
            {
                this.clbDaysOfWeek.SetItemChecked(index, false);
            }

            foreach (int index in this.clbGaurdsExcluded.CheckedIndices)
            {
                this.clbGaurdsExcluded.SetItemChecked(index, false);
            }            

            foreach (int index in this.clbPostsExcluded.CheckedIndices)
            {
                this.clbPostsExcluded.SetItemChecked(index, false);
            } 
            
            foreach (int index in this.clbShiftsExcluded.CheckedIndices)
            {
                this.clbShiftsExcluded.SetItemChecked(index, false);
            }

            this.ckAndOr.Checked = true;
            this.ckIsActive.Checked = true;
            this.ckIsGaurdExclusion.Checked = false;
            this.ckIsPostExclusion.Checked = false;
            this.ckIsShiftExclusion.Checked = false;

            this.txtDescription.Text = "";

            this.lblCode.ForeColor = this.clNormalLableColor;
            this.lblDaysOfWeek.ForeColor = this.clNormalLableColor;
            this.lblDate.ForeColor = this.clNormalLableColor;

            this.cmbDateLogic.SelectedIndex = 0;            
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (!this.isFormComplete())
            {
                MessageBox.Show("Please complete missing form element before proceeding.",
                    "SAVE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //Insert Or Update To GS_EXCLUSION.
                //Begins...
            this.dtNewExclusion =
                getDataFromDB.getGS_EXCLUSIONInfo(null,
                    "", "", "", "",triaStateBool.Ignor, triaStateBool.Ignor, triaStateBool.Ignor,
                        triaStateBool.Ignor, triaStateBool.Ignor, 
                        triaStateBool.Ignor, false, true, "AND");

            DataRow drNewExclusion = this.dtNewExclusion.NewRow();

            if (this.intCurrentExclusionID != -1)
                drNewExclusion["GS_EXCLUSION_ID"] = this.intCurrentExclusionID;

            drNewExclusion["ISACTIVE"] =
                this.ckIsActive.Checked ? "Y" : "N";

            drNewExclusion["CODE"] =
                this.txtCode.Text == "" ? dbNull : this.txtCode.Text;
            
            drNewExclusion["NAME"] =
                this.txtName.Text == "" ? dbNull : this.txtName.Text;

            drNewExclusion["DESCRIPTION"] =
                this.txtDescription.Text == "" ? dbNull : this.txtDescription.Text;

            if (this.intCurrentExclusionID != -1)
            {
                string stClearDateRange = "UPDATE GS_EXCLUSION " +
                                        "SET EXCLUSION_DATE_BEGIN = NULL, " +
                                        "EXCULSION_DATE_END = NULL " +
                                        "WHERE GS_EXCLUSION_ID = " + this.intCurrentExclusionID.ToString();

                this.getDataFromDB.executeSqlOnDB(stClearDateRange);
            }

            if (
                 (this.cmbDateLogic.SelectedItem.ToString() == "Equals to") ||
                 (this.cmbDateLogic.SelectedItem.ToString() == "Greater or equals to") ||
                 (this.cmbDateLogic.SelectedItem.ToString() == "In between of")
               )
            {
                drNewExclusion["EXCLUSION_DATE_BEGIN"] =
                    this.dtpFromDate.Value.ToString("dd-MMM-yyyy");
            }

            if (
                 (this.cmbDateLogic.SelectedItem.ToString() == "Lesser or equal to") ||
                 (this.cmbDateLogic.SelectedItem.ToString() == "In between of")
               )
            {
                drNewExclusion["EXCULSION_DATE_END"] =
                    this.dtpToDate.Value.ToString("dd-MMM-yyyy");
            }

            drNewExclusion["ISDAY_DATE_COMBINATION"] =
                !this.ckAndOr.Checked ? "Y" : "N";

            drNewExclusion["ISDAY_EXCLUSION"] =
                this.clbDaysOfWeek.CheckedItems.Count > 0 ? "Y" : "N";
            
            drNewExclusion["ISDATE_EXCLUSION"] =
                this.cmbDateLogic.SelectedItem.ToString() != "Not Applicable" ? "Y" : "N";

            drNewExclusion["ISRANGE_EXCLUSION"] =
                (
                 (this.cmbDateLogic.SelectedItem.ToString() != "Equals to") &&
                 (this.cmbDateLogic.SelectedItem.ToString() != "Not Applicable")
                 )
                 ? "Y" : "N";
            
            drNewExclusion["ISGAURD_EXCLUSION"] =
                this.ckIsGaurdExclusion.Checked ? "Y" : "N";
            drNewExclusion["ISSHIFT_EXCLUSION"] =
                this.ckIsShiftExclusion.Checked ? "Y" : "N";
            drNewExclusion["ISPOST_EXCLUSION"] =
                this.ckIsPostExclusion.Checked ? "Y" : "N";

            this.dtNewExclusion.Rows.Add(drNewExclusion);

            string[] exclusionId =
                this.getDataFromDB.changeDataBaseTableData(this.dtNewExclusion.Copy(), "GS_EXCLUSION",
                    this.intCurrentExclusionID != -1 ? "UPDATE" : "INSERT");
            //Insertion to GS_EXCLUSION Ends....

            string GS_EXCLUSION_ID = 
                this.intCurrentExclusionID != -1 ? this.intCurrentExclusionID.ToString() :
                exclusionId[0].Split(new string[] { "(", ")" }, StringSplitOptions.None)[1];

                        
            DataTable dtExclusionInfo =
                this.getDataFromDB.getGS_EXCLUSIONInfo(null, "", GS_EXCLUSION_ID, "", "",
                    triaStateBool.Ignor, triaStateBool.Ignor, triaStateBool.Ignor,
                    triaStateBool.Ignor, triaStateBool.Ignor, triaStateBool.Ignor,
                    false, false, "AND");

            if (!this.getDataFromDB.checkIfTableContainesData(dtExclusionInfo))
                return ;

            //Insertion to GS_DAY_EXCLUSION
            if (!this.recordOrUpdateDayExclusion(GS_EXCLUSION_ID))
                return;

            //Insertion to GS_DAY_EXCLUSION
            if (!this.recordUpdateGaurdExclusion(GS_EXCLUSION_ID))
                return;

            //Insertion to GS_DAY_EXCLUSION
            if (!this.recordUpdatePostExclusion(GS_EXCLUSION_ID))
                return;

            //Insertion to GS_DAY_EXCLUSION
            if (!this.recordUpdateShiftExclusion(GS_EXCLUSION_ID))
                return;


            if (!dbCommitFailure.dbCommitError)
            {
                if (intCurrentExclusionID == -1)
                {
                    DataRow drExistingExclusion = this.dtExclusion.NewRow();

                    drExistingExclusion["GS_EXCLUSION_ID"] = GS_EXCLUSION_ID;
                    drExistingExclusion["CODE"] = this.dtNewExclusion.Rows[0]["CODE"].ToString();
                    drExistingExclusion["NAME"] = this.dtNewExclusion.Rows[0]["NAME"].ToString();
                    if (this.dtNewExclusion.Rows[0]["EXCLUSION_DATE_BEGIN"].ToString() != "")
                    {
                        drExistingExclusion["EXCLUSION_DATE_BEGIN"] = this.dtNewExclusion.Rows[0]["EXCLUSION_DATE_BEGIN"].ToString();
                    }
                    if (this.dtNewExclusion.Rows[0]["EXCULSION_DATE_END"].ToString() != "")
                    {
                        drExistingExclusion["EXCULSION_DATE_END"] = this.dtNewExclusion.Rows[0]["EXCULSION_DATE_END"].ToString();
                    }
                    drExistingExclusion["ISDAY_DATE_COMBINATION"] = this.dtNewExclusion.Rows[0]["ISDAY_DATE_COMBINATION"].ToString();
                    drExistingExclusion["ISRANGE_EXCLUSION"] = this.dtNewExclusion.Rows[0]["ISRANGE_EXCLUSION"].ToString();
                    drExistingExclusion["ISDAY_EXCLUSION"] = this.dtNewExclusion.Rows[0]["ISDAY_EXCLUSION"].ToString();
                    drExistingExclusion["ISDATE_EXCLUSION"] = this.dtNewExclusion.Rows[0]["ISDATE_EXCLUSION"].ToString();
                    drExistingExclusion["ISGAURD_EXCLUSION"] = this.dtNewExclusion.Rows[0]["ISGAURD_EXCLUSION"].ToString();
                    drExistingExclusion["ISSHIFT_EXCLUSION"] = this.dtNewExclusion.Rows[0]["ISSHIFT_EXCLUSION"].ToString();
                    drExistingExclusion["ISPOST_EXCLUSION"] = this.dtNewExclusion.Rows[0]["ISPOST_EXCLUSION"].ToString();
                    drExistingExclusion["ISACTIVE"] = this.dtNewExclusion.Rows[0]["ISACTIVE"].ToString();
                    drExistingExclusion["DESCRIPTION"] = this.dtNewExclusion.Rows[0]["DESCRIPTION"].ToString();

                    this.dtExclusion.Rows.Add(drExistingExclusion);
                    this.dtgExclusion.Rows[this.dtgExclusion.Rows.Count - 1].Selected = true;
                }
                else
                {
                    if (this.dtgExclusionSelectedRowIndex >= 0 &&
                        this.dtgExclusionSelectedRowIndex < this.dtExclusion.Rows.Count)
                    {
                        if (int.Parse(this.dtExclusion.Rows[this.dtgExclusionSelectedRowIndex]["GS_EXCLUSION_ID"].ToString()) == this.intCurrentExclusionID)
                        {
                            this.dtExclusion.Rows[this.dtgExclusionSelectedRowIndex]["CODE"] = this.dtNewExclusion.Rows[0]["CODE"].ToString();
                            this.dtExclusion.Rows[this.dtgExclusionSelectedRowIndex]["NAME"] = this.dtNewExclusion.Rows[0]["NAME"].ToString();
                            if (this.dtNewExclusion.Rows[0]["EXCLUSION_DATE_BEGIN"].ToString() != "")
                            {
                                this.dtExclusion.Rows[this.dtgExclusionSelectedRowIndex]["EXCLUSION_DATE_BEGIN"] = this.dtNewExclusion.Rows[0]["EXCLUSION_DATE_BEGIN"].ToString();
                            }
                            if (this.dtNewExclusion.Rows[0]["EXCULSION_DATE_END"].ToString() != "")
                            {
                                this.dtExclusion.Rows[this.dtgExclusionSelectedRowIndex]["EXCULSION_DATE_END"] = this.dtNewExclusion.Rows[0]["EXCULSION_DATE_END"].ToString();
                            }
                            
                            this.dtExclusion.Rows[this.dtgExclusionSelectedRowIndex]["ISDAY_DATE_COMBINATION"] = this.dtNewExclusion.Rows[0]["ISDAY_DATE_COMBINATION"].ToString();
                            this.dtExclusion.Rows[this.dtgExclusionSelectedRowIndex]["ISRANGE_EXCLUSION"] = this.dtNewExclusion.Rows[0]["ISRANGE_EXCLUSION"].ToString();
                            this.dtExclusion.Rows[this.dtgExclusionSelectedRowIndex]["ISDAY_EXCLUSION"] = this.dtNewExclusion.Rows[0]["ISDAY_EXCLUSION"].ToString();
                            this.dtExclusion.Rows[this.dtgExclusionSelectedRowIndex]["ISDATE_EXCLUSION"] = this.dtNewExclusion.Rows[0]["ISDATE_EXCLUSION"].ToString();
                            this.dtExclusion.Rows[this.dtgExclusionSelectedRowIndex]["ISGAURD_EXCLUSION"] = this.dtNewExclusion.Rows[0]["ISGAURD_EXCLUSION"].ToString();
                            this.dtExclusion.Rows[this.dtgExclusionSelectedRowIndex]["ISSHIFT_EXCLUSION"] = this.dtNewExclusion.Rows[0]["ISSHIFT_EXCLUSION"].ToString();
                            this.dtExclusion.Rows[this.dtgExclusionSelectedRowIndex]["ISPOST_EXCLUSION"] = this.dtNewExclusion.Rows[0]["ISPOST_EXCLUSION"].ToString();
                            this.dtExclusion.Rows[this.dtgExclusionSelectedRowIndex]["ISACTIVE"] = this.dtNewExclusion.Rows[0]["ISACTIVE"].ToString();
                            this.dtExclusion.Rows[this.dtgExclusionSelectedRowIndex]["DESCRIPTION"] = this.dtNewExclusion.Rows[0]["DESCRIPTION"].ToString();
                            return;
                        }
                    }

                    for (int rowCounter = 0; rowCounter <= this.dtExclusion.Rows.Count - 1; rowCounter++)
                    {
                        if (int.Parse(this.dtExclusion.Rows[rowCounter]["GS_EXCLUSION_ID"].ToString()) == this.intCurrentExclusionID)
                        {
                            this.dtExclusion.Rows[rowCounter]["CODE"] = this.dtNewExclusion.Rows[0]["CODE"].ToString();
                            this.dtExclusion.Rows[rowCounter]["NAME"] = this.dtNewExclusion.Rows[0]["NAME"].ToString();

                            if (this.dtNewExclusion.Rows[0]["EXCLUSION_DATE_BEGIN"].ToString() != "")
                            {
                                this.dtExclusion.Rows[rowCounter]["EXCLUSION_DATE_BEGIN"] = this.dtNewExclusion.Rows[0]["EXCLUSION_DATE_BEGIN"].ToString();
                            }
                            if (this.dtNewExclusion.Rows[0]["EXCULSION_DATE_END"].ToString() != "")
                            {
                                this.dtExclusion.Rows[rowCounter]["EXCULSION_DATE_END"] = this.dtNewExclusion.Rows[0]["EXCULSION_DATE_END"].ToString();
                            }
                            
                            this.dtExclusion.Rows[rowCounter]["ISDAY_DATE_COMBINATION"] = this.dtNewExclusion.Rows[0]["ISDAY_DATE_COMBINATION"].ToString();
                            this.dtExclusion.Rows[rowCounter]["ISRANGE_EXCLUSION"] = this.dtNewExclusion.Rows[0]["ISRANGE_EXCLUSION"].ToString();
                            this.dtExclusion.Rows[rowCounter]["ISDAY_EXCLUSION"] = this.dtNewExclusion.Rows[0]["ISDAY_EXCLUSION"].ToString();
                            this.dtExclusion.Rows[rowCounter]["ISDATE_EXCLUSION"] = this.dtNewExclusion.Rows[0]["ISDATE_EXCLUSION"].ToString();
                            this.dtExclusion.Rows[rowCounter]["ISGAURD_EXCLUSION"] = this.dtNewExclusion.Rows[0]["ISGAURD_EXCLUSION"].ToString();
                            this.dtExclusion.Rows[rowCounter]["ISSHIFT_EXCLUSION"] = this.dtNewExclusion.Rows[0]["ISSHIFT_EXCLUSION"].ToString();
                            this.dtExclusion.Rows[rowCounter]["ISPOST_EXCLUSION"] = this.dtNewExclusion.Rows[0]["ISPOST_EXCLUSION"].ToString();
                            this.dtExclusion.Rows[rowCounter]["ISACTIVE"] = this.dtNewExclusion.Rows[0]["ISACTIVE"].ToString();
                            this.dtExclusion.Rows[rowCounter]["DESCRIPTION"] = this.dtNewExclusion.Rows[0]["DESCRIPTION"].ToString();
                            return;
                        }
                    }
                }
            }
        }


        private bool recordOrUpdateDayExclusion(string GS_EXCLUSION_ID)
        {
            if (GS_EXCLUSION_ID == "")
                return false;

            foreach (string dayOfWeek in this.clbDaysOfWeek.Items)
            {
                if(this.clbDaysOfWeek.CheckedItems.Contains(dayOfWeek))
                    continue;

                string stDeleteDayExclusion = "DELETE FROM GS_DAY_EXCLUSION " +
                                              "WHERE GS_EXCLUSION_ID = " + GS_EXCLUSION_ID +
                                              " AND DAY_EXCLUDED = '" + dayOfWeek + "'";

                this.getDataFromDB.executeSqlOnDB(stDeleteDayExclusion);
            }

            DataTable dtNewDayExclusion = new DataTable();
                

            foreach (string dayOfWeek in this.clbDaysOfWeek.CheckedItems)
            {
                daysOfWeek dow = this.getCorrespondingDayOfWeek(dayOfWeek);

                if (dow == daysOfWeek.A_None)
                    continue;

                string dmlType = "";
                
                dtNewDayExclusion =
                    this.getDataFromDB.getGS_DAY_EXCLUSIONInfo(null, "", GS_EXCLUSION_ID,
                        dow, false, false, "AND");
                
                if (this.getDataFromDB.checkIfTableContainesData(dtNewDayExclusion))
                {
                    dtNewDayExclusion.Rows[0]["ISACTIVE"] = 
                        this.ckIsActive.Checked ? "Y" : "N";
                    dmlType = "UPDATE";
                }
                else
                {
                    dmlType = "INSERT";
                    DataRow drNewDayExclusion = dtNewDayExclusion.NewRow();

                    drNewDayExclusion["GS_EXCLUSION_ID"] = GS_EXCLUSION_ID;
                    drNewDayExclusion["DAY_EXCLUDED"] = dayOfWeek;
                    drNewDayExclusion["ISACTIVE"] =
                        this.ckIsActive.Checked ? "Y" : "N";

                    dtNewDayExclusion.Rows.Add(drNewDayExclusion);
                }

                if (this.getDataFromDB.checkIfTableContainesData(dtNewDayExclusion))
                {
                    this.getDataFromDB.changeDataBaseTableData(dtNewDayExclusion, "GS_DAY_EXCLUSION", dmlType);

                    if (dbCommitFailure.dbCommitError)
                    {
                        return false;
                    }
                    
                }
            }

            

            return true;

        }

        private bool recordUpdateGaurdExclusion(string GS_EXCLUSION_ID)
        {
            if (GS_EXCLUSION_ID == "")
                return false;

            string stGaurdId = "";
            string dmlType = "";

            for (int listCounter = 0; listCounter <= this.clbGaurdsExcluded.Items.Count - 1; listCounter++)
            {
                stGaurdId = 
                    this.dtAllActiveGaurds.Rows[listCounter]["GS_GAURD_ID"].ToString();

                if (!this.clbGaurdsExcluded.CheckedIndices.Contains(listCounter))
                {
                    string stDeleteGaurdExclusion = 
                                    "DELETE FROM GS_GAURD_EXCLUSION " +
                                    "WHERE GS_EXCLUSION_ID = " + GS_EXCLUSION_ID +
                                    " AND GS_GAURD_ID = " + stGaurdId;

                    this.getDataFromDB.executeSqlOnDB(stDeleteGaurdExclusion);
                    continue;
                }

                DataTable dtNewGaurdExclusion =
                    this.getDataFromDB.getGS_GAURD_EXCLUSIONInfo(null, "", GS_EXCLUSION_ID,
                        stGaurdId, false, false, "AND");

                if (this.getDataFromDB.checkIfTableContainesData(dtNewGaurdExclusion))
                {
                    dtNewGaurdExclusion.Rows[0]["ISACTIVE"] =
                        this.ckIsActive.Checked ? "Y" : "N";
                    dmlType = "UPDATE";
                }
                else
                {
                    dmlType = "INSERT";
                    DataRow drNewGaurdExclusion = dtNewGaurdExclusion.NewRow();

                    drNewGaurdExclusion["GS_EXCLUSION_ID"] = GS_EXCLUSION_ID;
                    drNewGaurdExclusion["GS_GAURD_ID"] = stGaurdId;
                    drNewGaurdExclusion["ISACTIVE"] =
                        this.ckIsActive.Checked ? "Y" : "N";

                    dtNewGaurdExclusion.Rows.Add(drNewGaurdExclusion);
                }
                this.getDataFromDB.changeDataBaseTableData(dtNewGaurdExclusion, "GS_GAURD_EXCLUSION", dmlType);

                if (dbCommitFailure.dbCommitError)
                {                    
                    return false;
                }
            }

            return true;
        }

        private bool recordUpdatePostExclusion(string GS_EXCLUSION_ID)
        {
            if (GS_EXCLUSION_ID == "")
                return false;
                        

            string stPostId = "";
            string dmlType = "";

            for (int listCounter = 0; listCounter <= this.clbPostsExcluded.Items.Count - 1; listCounter++)
            {
                stPostId =
                    this.dtAllActivePosts.Rows[listCounter]["GS_POST_ID"].ToString();

                if (!this.clbPostsExcluded.CheckedIndices.Contains(listCounter))
                {
                    string stDeletePostExclusion =
                                    "DELETE FROM GS_POST_EXCLUSION " +
                                    "WHERE GS_EXCLUSION_ID = " + GS_EXCLUSION_ID +
                                    " AND GS_POST_ID = " + stPostId;

                    this.getDataFromDB.executeSqlOnDB(stDeletePostExclusion);
                    continue;
                }

                DataTable dtNewPostExclusion =
                    this.getDataFromDB.getGS_POST_EXCLUSIONInfo(null, "", GS_EXCLUSION_ID,
                        stPostId, false, false, "AND");

                if (this.getDataFromDB.checkIfTableContainesData(dtNewPostExclusion))
                {
                    dtNewPostExclusion.Rows[0]["ISACTIVE"] =
                        this.ckIsActive.Checked ? "Y" : "N";
                    dmlType = "UPDATE";
                }
                else
                {
                    dmlType = "INSERT";
                    DataRow drNewPostExclusion = dtNewPostExclusion.NewRow();

                    drNewPostExclusion["GS_EXCLUSION_ID"] = GS_EXCLUSION_ID;
                    drNewPostExclusion["GS_POST_ID"] = stPostId;
                    drNewPostExclusion["ISACTIVE"] =
                        this.ckIsActive.Checked ? "Y" : "N";

                    dtNewPostExclusion.Rows.Add(drNewPostExclusion);
                }
                this.getDataFromDB.changeDataBaseTableData(dtNewPostExclusion, "GS_POST_EXCLUSION", dmlType);

                if (dbCommitFailure.dbCommitError)
                {
                    return false;
                }
            }

            return true;
        }

        private bool recordUpdateShiftExclusion(string GS_EXCLUSION_ID)
        {
            if (GS_EXCLUSION_ID == "")
                return false;


            string stShiftId = "";
            string dmlType = "";

            for (int listCounter = 0; listCounter <= this.clbShiftsExcluded.Items.Count - 1; listCounter++)
            {
                stShiftId =
                    this.dtAllActiveShifts.Rows[listCounter]["GS_SHIFT_ID"].ToString();

                if (!this.clbShiftsExcluded.CheckedIndices.Contains(listCounter))
                {
                    string stDeleteShiftExclusion =
                                    "DELETE FROM GS_SHIFT_EXCLUSION " +
                                    "WHERE GS_EXCLUSION_ID = " + GS_EXCLUSION_ID +
                                    " AND GS_SHIFT_ID = " + stShiftId;

                    this.getDataFromDB.executeSqlOnDB(stDeleteShiftExclusion);
                    continue;
                }

                DataTable dtNewShiftExclusion =
                    this.getDataFromDB.getGS_SHIFT_EXCLUSIONInfo(null, "", GS_EXCLUSION_ID,
                        stShiftId, false, false, "AND");

                if (this.getDataFromDB.checkIfTableContainesData(dtNewShiftExclusion))
                {
                    dtNewShiftExclusion.Rows[0]["ISACTIVE"] =
                        this.ckIsActive.Checked ? "Y" : "N";
                    dmlType = "UPDATE";
                }
                else
                {
                    dmlType = "INSERT";
                    DataRow drNewShiftExclusion = dtNewShiftExclusion.NewRow();

                    drNewShiftExclusion["GS_EXCLUSION_ID"] = GS_EXCLUSION_ID;
                    drNewShiftExclusion["GS_SHIFT_ID"] = stShiftId;
                    drNewShiftExclusion["ISACTIVE"] =
                        this.ckIsActive.Checked ? "Y" : "N";

                    dtNewShiftExclusion.Rows.Add(drNewShiftExclusion);
                }
                this.getDataFromDB.changeDataBaseTableData(dtNewShiftExclusion, "GS_SHIFT_EXCLUSION", dmlType);

                if (dbCommitFailure.dbCommitError)
                {
                    return false;
                }
            }

            return true;
        }


        private void searchToolStripButton_Click(object sender, EventArgs e)
        {
            this.dtExclusion =
                getDataFromDB.getGS_EXCLUSIONInfo(null,
                    "", "", "", "", false, false, "AND");

            this.dtExclusion.Columns["CODE"].SetOrdinal(0);
            this.dtExclusion.Columns["NAME"].SetOrdinal(1);            
            this.dtExclusion.Columns["ISACTIVE"].SetOrdinal(4);
            this.dtExclusion.Columns["ISDAY_DATE_COMBINATION"].SetOrdinal(5);
            this.dtExclusion.Columns["ISDAY_EXCLUSION"].SetOrdinal(6);
            this.dtExclusion.Columns["ISDATE_EXCLUSION"].SetOrdinal(7);
            this.dtExclusion.Columns["ISGAURD_EXCLUSION"].SetOrdinal(8);
            this.dtExclusion.Columns["ISSHIFT_EXCLUSION"].SetOrdinal(9);
            this.dtExclusion.Columns["ISPOST_EXCLUSION"].SetOrdinal(10);

            this.dtgExclusion.DataSource = this.dtExclusion;

            this.dtgExclusion.Columns["CODE"].HeaderText = "Code";
            this.dtgExclusion.Columns["NAME"].HeaderText = "Name";
            this.dtgExclusion.Columns["ISACTIVE"].HeaderText = "Active";
            this.dtgExclusion.Columns["ISDAY_DATE_COMBINATION"].HeaderText = "For Day In Range";
            this.dtgExclusion.Columns["ISDAY_EXCLUSION"].HeaderText = "For Days Of Week";
            this.dtgExclusion.Columns["ISDATE_EXCLUSION"].HeaderText = "For Date";
            this.dtgExclusion.Columns["ISGAURD_EXCLUSION"].HeaderText = "Excludes Gaurds";
            this.dtgExclusion.Columns["ISSHIFT_EXCLUSION"].HeaderText = "Excludes Shifts";
            this.dtgExclusion.Columns["ISPOST_EXCLUSION"].HeaderText = "Excludes Posts";
            
            


            this.dtgExclusion.Columns["GS_EXCLUSION_ID"].Visible = false;
            this.dtgExclusion.Columns["CREATED"].Visible = false;
            this.dtgExclusion.Columns["CREATEDBY"].Visible = false;
            this.dtgExclusion.Columns["UPDATED"].Visible = false;
            this.dtgExclusion.Columns["UPDATEDBY"].Visible = false;
            this.dtgExclusion.Columns["DESCRIPTION"].Visible = false;
            this.dtgExclusion.Columns["EXCLUSION_DATE_BEGIN"].Visible = false;
            this.dtgExclusion.Columns["EXCULSION_DATE_END"].Visible = false;
            this.dtgExclusion.Columns["ISRANGE_EXCLUSION"].Visible = false;
        }

        private void exitToolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbDateLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbDateLogic.SelectedItem.ToString() == "Not Applicable")
            {
                this.dtpFromDate.Enabled = false;
                this.dtpToDate.Enabled = false;
            }
            else if (this.cmbDateLogic.SelectedItem.ToString() == "Equals to" ||
                this.cmbDateLogic.SelectedItem.ToString() == "Greater or equals to")                
            {
                this.dtpFromDate.Enabled = true;
                this.dtpToDate.Enabled = false;
            }
            else if (this.cmbDateLogic.SelectedItem.ToString() == "Lesser or equal to")                
            {
                this.dtpFromDate.Enabled = false;
                this.dtpToDate.Enabled = true;
            }
            else if (this.cmbDateLogic.SelectedItem.ToString() == "In between of")
            {
                this.dtpFromDate.Enabled = true;
                this.dtpToDate.Enabled = true;
            }
        }


        private void frmExclusion_Load(object sender, EventArgs e)
        {            
            this.newToolStripButton_Click(sender, e);

            this.clbGaurdsExcluded.Items.Clear();
            this.clbPostsExcluded.Items.Clear();
            this.clbShiftsExcluded.Items.Clear();
            
            this.dtAllActiveGaurds = 
                this.getDataFromDB.getGS_GAURDInfo
                    (null, "", "", "", "", "", true, false, "AD");

            string firstName = "";
            string middleName = "";

            for (int rowCounter = 0; rowCounter <= this.dtAllActiveGaurds.Rows.Count - 1; 
                rowCounter++)
            {
                firstName = 
                    this.dtAllActiveGaurds.Rows[rowCounter]["FIRSTNAME"].ToString();
                middleName = 
                    this.dtAllActiveGaurds.Rows[rowCounter]["MIDDELNAME"].ToString();

                this.clbGaurdsExcluded.Items.Add(firstName + " " + middleName);
            }

            if (this.dtAllActiveGaurds.Rows.Count > 0)
            {
                this.ckIsGaurdExclusion.Enabled = true;
            }
            else
                this.ckIsGaurdExclusion.Enabled = false;

            this.ckIsGaurdExclusion.Checked = false;
            this.clbGaurdsExcluded.Enabled = false;



            this.dtAllActivePosts =
                this.getDataFromDB.getGS_POSTInfo(null, "", "", "", "", true, false, "AND");

            string postName = "";

            for (int rowCounter = 0; rowCounter <= this.dtAllActivePosts.Rows.Count - 1;
                rowCounter++)
            {
                postName =
                    this.dtAllActivePosts.Rows[rowCounter]["NAME"].ToString();

                this.clbPostsExcluded.Items.Add(postName);
            }

            if (this.dtAllActivePosts.Rows.Count > 0)
            {
                this.ckIsPostExclusion.Enabled = true;
            }
            else
                this.ckIsPostExclusion.Enabled = false;

            this.ckIsPostExclusion.Checked = false;
            this.clbPostsExcluded.Enabled = false;




            this.dtAllActiveShifts =
                this.getDataFromDB.getGS_SHIFTInfo(null, "", "", "", "", true, false, "AND");

            string shiftName = "";

            for (int rowCounter = 0; rowCounter <= this.dtAllActiveShifts.Rows.Count - 1;
                rowCounter++)
            {
                shiftName =
                    this.dtAllActiveShifts.Rows[rowCounter]["NAME"].ToString();

                this.clbShiftsExcluded.Items.Add(shiftName);
            }

            if (this.dtAllActiveShifts.Rows.Count > 0)
            {
                this.ckIsShiftExclusion.Enabled = true;
            }
            else
                this.ckIsShiftExclusion.Enabled = false;

            this.ckIsShiftExclusion.Checked = false;
            this.clbShiftsExcluded.Enabled = false;



            this.dtExclusion =
                this.getDataFromDB.getGS_EXCLUSIONInfo(null, "", "", "", 
                "", false, true, "AND");

            this.dtExclusion.Columns["CODE"].SetOrdinal(0);
            this.dtExclusion.Columns["NAME"].SetOrdinal(1);
            this.dtExclusion.Columns["ISACTIVE"].SetOrdinal(4);
            this.dtExclusion.Columns["ISDAY_DATE_COMBINATION"].SetOrdinal(5);
            this.dtExclusion.Columns["ISDAY_EXCLUSION"].SetOrdinal(6);
            this.dtExclusion.Columns["ISDATE_EXCLUSION"].SetOrdinal(7);
            this.dtExclusion.Columns["ISGAURD_EXCLUSION"].SetOrdinal(8);
            this.dtExclusion.Columns["ISSHIFT_EXCLUSION"].SetOrdinal(9);
            this.dtExclusion.Columns["ISPOST_EXCLUSION"].SetOrdinal(10);

            this.dtgExclusion.DataSource = this.dtExclusion;

            this.dtgExclusion.Columns["CODE"].HeaderText = "Code";
            this.dtgExclusion.Columns["NAME"].HeaderText = "Name";
            this.dtgExclusion.Columns["ISACTIVE"].HeaderText = "Active";
            this.dtgExclusion.Columns["ISDAY_DATE_COMBINATION"].HeaderText = "For Days In Range";
            this.dtgExclusion.Columns["ISDAY_EXCLUSION"].HeaderText = "For Days Of Week";
            this.dtgExclusion.Columns["ISDATE_EXCLUSION"].HeaderText = "For Date Range";
            this.dtgExclusion.Columns["ISGAURD_EXCLUSION"].HeaderText = "Excludes Gaurds";
            this.dtgExclusion.Columns["ISSHIFT_EXCLUSION"].HeaderText = "Excludes Shifts";
            this.dtgExclusion.Columns["ISPOST_EXCLUSION"].HeaderText = "Excludes Posts";
            

            this.dtgExclusion.Columns["GS_EXCLUSION_ID"].Visible = false;
            this.dtgExclusion.Columns["CREATED"].Visible = false;
            this.dtgExclusion.Columns["CREATEDBY"].Visible = false;
            this.dtgExclusion.Columns["UPDATED"].Visible = false;
            this.dtgExclusion.Columns["UPDATEDBY"].Visible = false;
            this.dtgExclusion.Columns["DESCRIPTION"].Visible = false;
            this.dtgExclusion.Columns["EXCLUSION_DATE_BEGIN"].Visible = false;
            this.dtgExclusion.Columns["EXCULSION_DATE_END"].Visible = false;
            this.dtgExclusion.Columns["ISRANGE_EXCLUSION"].Visible = false;


        }

        private void dtgExclusion_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgExclusion.SelectedRows.Count < 1)
            {
                this.intCurrentExclusionID = -1;
                return;
            }

            int dtgselectedRowIndex =
                this.dtgExclusion.SelectedRows[0].Index;

            this.intCurrentExclusionID =
                int.Parse(this.dtgExclusion.Rows[dtgselectedRowIndex].
                    Cells["GS_EXCLUSION_ID"].Value.ToString());

            this.txtCode.Text =
                this.dtgExclusion.Rows[dtgselectedRowIndex].
                    Cells["CODE"].Value.ToString();

            this.txtName.Text =
                this.dtgExclusion.Rows[dtgselectedRowIndex].
                    Cells["NAME"].Value.ToString();

            this.ckIsActive.Checked =
                this.dtgExclusion.Rows[dtgselectedRowIndex].
                    Cells["ISACTIVE"].Value.ToString() == "Y" ? true : false;

            this.txtDescription.Text =
                this.dtgExclusion.Rows[dtgselectedRowIndex].
                    Cells["DESCRIPTION"].Value.ToString();


            this.ckAndOr.Checked =
                this.dtgExclusion.Rows[dtgselectedRowIndex].
                    Cells["ISDAY_DATE_COMBINATION"].Value.ToString() == "Y" ? false : true;


            this.ckIsGaurdExclusion.Checked =
                this.dtgExclusion.Rows[dtgselectedRowIndex].
                    Cells["ISGAURD_EXCLUSION"].Value.ToString() == "Y" ? true : false;

            this.ckIsShiftExclusion.Checked =
                this.dtgExclusion.Rows[dtgselectedRowIndex].
                    Cells["ISSHIFT_EXCLUSION"].Value.ToString() == "Y" ? true : false;

            this.ckIsPostExclusion.Checked =
                this.dtgExclusion.Rows[dtgselectedRowIndex].
                    Cells["ISPOST_EXCLUSION"].Value.ToString() == "Y" ? true : false;

            if (this.dtgExclusion.Rows[dtgselectedRowIndex].
                    Cells["ISDATE_EXCLUSION"].Value.ToString() == "Y")
            {
                string stDtFrom = this.dtgExclusion.Rows[dtgselectedRowIndex].
                     Cells["EXCLUSION_DATE_BEGIN"].Value.ToString();

                string stDtTo = this.dtgExclusion.Rows[dtgselectedRowIndex].
                    Cells["EXCULSION_DATE_END"].Value.ToString();

                if (stDtFrom != "")
                    this.dtpFromDate.Value = DateTime.Parse (stDtFrom);
                else
                    this.dtpFromDate.Value = DateTime.Now;
                

                if (stDtTo != "")
                    this.dtpToDate.Value = DateTime.Parse(stDtTo);
                else
                    this.dtpToDate.Value = DateTime.Now;


                if (this.dtgExclusion.Rows[dtgselectedRowIndex].
                    Cells["ISRANGE_EXCLUSION"].Value.ToString() == "Y")
                {
                    if (stDtFrom != "" && stDtTo != "")
                        this.cmbDateLogic.SelectedItem = "In between of";
                    else if(stDtFrom != "")
                        this.cmbDateLogic.SelectedItem = "Greater or equals to";
                    else if (stDtTo != "")
                        this.cmbDateLogic.SelectedItem = "Lesser or equal to";
                }
                else
                    this.cmbDateLogic.SelectedItem = "Equals to";
            }
            else
            {
                this.cmbDateLogic.SelectedItem = "Not Applicable";
            }


            if (this.dtgExclusion.Rows[dtgselectedRowIndex].
                    Cells["ISDAY_EXCLUSION"].Value.ToString() == "Y")
            {
                this.showExcludedDays();
            }
            else
            {
                foreach (int index in this.clbDaysOfWeek.CheckedIndices)
                {
                    this.clbDaysOfWeek.SetItemChecked(index, false);
                }
            }


            if (this.dtgExclusion.Rows[dtgselectedRowIndex].
                    Cells["ISGAURD_EXCLUSION"].Value.ToString() == "Y")
            {
                this.showExcludedGaurds();
            }

            if (this.dtgExclusion.Rows[dtgselectedRowIndex].
                    Cells["ISPOST_EXCLUSION"].Value.ToString() == "Y")
            {
                this.showExcludedPosts();
            }

            if (this.dtgExclusion.Rows[dtgselectedRowIndex].
                    Cells["ISSHIFT_EXCLUSION"].Value.ToString() == "Y")
            {
                this.showExcludedShifts();
            }

        }


        private void showExcludedDays()
        {
            if (this.intCurrentExclusionID == -1)
                return;

            foreach (int index in this.clbDaysOfWeek.CheckedIndices)
            {
                this.clbDaysOfWeek.SetItemChecked(index, false);
            }

            DataTable dtExcludedDays = 
                this.getDataFromDB.getGS_DAY_EXCLUSIONInfo(null, "", 
                    this.intCurrentExclusionID.ToString(), daysOfWeek.A_None, 
                    false, false, "AND");

            if (!this.getDataFromDB.checkIfTableContainesData(dtExcludedDays))
                return;
            
            string stDayExcluded = "";
            int indexOfDayInclbDaysOfWeek = -1;

            for (int rowCounter = 0; rowCounter <= dtExcludedDays.Rows.Count - 1; rowCounter++)
            {
                stDayExcluded = 
                    dtExcludedDays.Rows[rowCounter]["DAY_EXCLUDED"].ToString();
                indexOfDayInclbDaysOfWeek = 
                    this.clbDaysOfWeek.Items.IndexOf(stDayExcluded);
                
                if( indexOfDayInclbDaysOfWeek >= 0 && indexOfDayInclbDaysOfWeek <= this.clbDaysOfWeek.Items.Count - 1)
                {
                    this.clbDaysOfWeek.SetItemChecked(indexOfDayInclbDaysOfWeek, true);
                }                
            }
        }

        private void showExcludedGaurds()
        {
            if (this.intCurrentExclusionID == -1)
                return;

            foreach (int index in this.clbGaurdsExcluded.CheckedIndices)
            {
                this.clbGaurdsExcluded.SetItemChecked(index, false);
            }

            DataTable dtExcludedGaurds =
                this.getDataFromDB.getGS_GAURD_EXCLUSIONInfo(null, 
                    "", this.intCurrentExclusionID.ToString(), "", 
                    false, false, "AND");

            if (!this.getDataFromDB.checkIfTableContainesData(dtExcludedGaurds))
                return;

            string stGaurdIDExcluded = "";            

            for (int rowCounter = 0; rowCounter <= dtExcludedGaurds.Rows.Count - 1; rowCounter++)
            {
                stGaurdIDExcluded =
                    dtExcludedGaurds.Rows[rowCounter]["GS_GAURD_ID"].ToString();
                
                for (int rowCounter2 = 0; rowCounter2 <= this.dtAllActiveGaurds.Rows.Count - 1; rowCounter2++)
                {
                    if (this.dtAllActiveGaurds.Rows[rowCounter2]["GS_GAURD_ID"].ToString() == stGaurdIDExcluded)
                    {
                        this.clbGaurdsExcluded.SetItemChecked(rowCounter2, true);
                        break;
                    }
                }
            }
        }

        private void showExcludedPosts()
        {
            if (this.intCurrentExclusionID == -1)
                return;

            foreach (int index in this.clbPostsExcluded.CheckedIndices)
            {
                this.clbPostsExcluded.SetItemChecked(index, false);
            }

            DataTable dtExcludedPosts =
                this.getDataFromDB.getGS_POST_EXCLUSIONInfo(null,
                    "", this.intCurrentExclusionID.ToString(), "",
                    false, false, "AND");

            if (!this.getDataFromDB.checkIfTableContainesData(dtExcludedPosts))
                return;

            string stPostIDExcluded = "";

            for (int rowCounter = 0; rowCounter <= dtExcludedPosts.Rows.Count - 1; rowCounter++)
            {
                stPostIDExcluded =
                    dtExcludedPosts.Rows[rowCounter]["GS_POST_ID"].ToString();

                for (int rowCounter2 = 0; rowCounter2 <= this.dtAllActivePosts.Rows.Count - 1; rowCounter2++)
                {
                    if (this.dtAllActivePosts.Rows[rowCounter2]["GS_POST_ID"].ToString() == stPostIDExcluded)
                    {
                        this.clbPostsExcluded.SetItemChecked(rowCounter2, true);
                        break;
                    }
                }
            }
        }

        private void showExcludedShifts()
        {
            if (this.intCurrentExclusionID == -1)
                return;

            foreach (int index in this.clbShiftsExcluded.CheckedIndices)
            {
                this.clbShiftsExcluded.SetItemChecked(index, false);
            }

            DataTable dtExcludedShifts =
                this.getDataFromDB.getGS_SHIFT_EXCLUSIONInfo(null,
                    "", this.intCurrentExclusionID.ToString(), "",
                    false, false, "AND");

            if (!this.getDataFromDB.checkIfTableContainesData(dtExcludedShifts))
                return;

            string stShiftIDExcluded = "";

            for (int rowCounter = 0; rowCounter <= dtExcludedShifts.Rows.Count - 1; rowCounter++)
            {
                stShiftIDExcluded =
                    dtExcludedShifts.Rows[rowCounter]["GS_SHIFT_ID"].ToString();

                for (int rowCounter2 = 0; rowCounter2 <= this.dtAllActiveShifts.Rows.Count - 1; rowCounter2++)
                {
                    if (this.dtAllActiveShifts.Rows[rowCounter2]["GS_SHIFT_ID"].ToString() == stShiftIDExcluded)
                    {
                        this.clbShiftsExcluded.SetItemChecked(rowCounter2, true);
                        break;
                    }
                }
            }
        }


        private void ckIsGaurdExclusion_CheckedChanged(object sender, EventArgs e)
        {
            this.clbGaurdsExcluded.Enabled = this.ckIsGaurdExclusion.Checked;
            if (!this.ckIsGaurdExclusion.Checked)
            {
                foreach (int index in this.clbGaurdsExcluded.CheckedIndices)
                {
                    this.clbGaurdsExcluded.SetItemChecked(index, false);
                }
            }
        }

        private void ckIsPostExclusion_CheckedChanged(object sender, EventArgs e)
        {
            this.clbPostsExcluded.Enabled = this.ckIsPostExclusion.Checked;
            if (!this.ckIsPostExclusion.Checked)
            {
                foreach (int index in this.clbPostsExcluded.CheckedIndices)
                {
                    this.clbPostsExcluded.SetItemChecked(index, false);
                }                
            }
        }

        private void ckIsShiftExclusion_CheckedChanged(object sender, EventArgs e)
        {
            this.clbShiftsExcluded.Enabled = this.ckIsShiftExclusion.Checked;
            if (!this.ckIsShiftExclusion.Checked)
            {
                foreach (int index in this.clbShiftsExcluded.CheckedIndices)
                {
                    this.clbShiftsExcluded.SetItemChecked(index, false);
                }
            }
        }


    }
}
