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
    public partial class frmPost : Form
    {
        public frmPost()
        {
            InitializeComponent();
        }

        string dbNull = generalResultInformation.dbNull;

        int dtgPostSelectedRowIndex = -1;

        int intCurrentPostID = -1;

        Color clNormalLableColor = Color.Black;
        Color clErrorLableColor = Color.Red;
        Color clChangedLableColor = Color.Blue;

        DataTable dtPost = new DataTable();
        DataTable dtNewPost = new DataTable();


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
                        
            return formIsComplete;

        }


        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            this.intCurrentPostID = -1;

            this.txtCode.Text = "";
            this.txtName.Text = "";
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



            this.dtNewPost =
                getDataFromDB.getGS_POSTInfo(null,
                    "", "", "", "", false, true, "AND");

            DataRow drNewPost = this.dtNewPost.NewRow();

            if (this.intCurrentPostID != -1)
                drNewPost["GS_POST_ID"] = this.intCurrentPostID;
            drNewPost["CODE"] = this.txtCode.Text;
            drNewPost["NAME"] =
                this.txtName.Text == "" ? dbNull : this.txtName.Text;
            drNewPost["ISACTIVE"] =
                this.ckIsActive.Checked ? "Y" : "N";
            drNewPost["DESCRIPTION"] =
                this.txtDescription.Text == "" ? dbNull : this.txtDescription.Text;

            this.dtNewPost.Rows.Add(drNewPost);

            string[] postId =
                this.getDataFromDB.changeDataBaseTableData(dtNewPost, "GS_POST",
                this.intCurrentPostID != -1 ? "UPDATE" : "INSERT");

            if (!dbCommitFailure.dbCommitError)
            {
                if (intCurrentPostID == -1)
                {
                    DataRow drExistingPost = this.dtPost.NewRow();

                    drExistingPost["GS_POST_ID"] = postId[0].Split(new string[] { "(", ")" }, StringSplitOptions.None)[1];
                    drExistingPost["CODE"] = this.txtCode.Text;
                    drExistingPost["NAME"] = this.txtName.Text;                    
                    drExistingPost["ISACTIVE"] = this.ckIsActive.Checked ? "Y" : "N";
                    drExistingPost["DESCRIPTION"] = this.txtDescription.Text;

                    this.dtPost.Rows.Add(drExistingPost);
                    this.dtgPosts.Rows[this.dtgPosts.Rows.Count - 1].Selected = true;
                }
                else
                {
                    if (this.dtgPostSelectedRowIndex >= 0 &&
                        this.dtgPostSelectedRowIndex < this.dtPost.Rows.Count)
                    {
                        if (int.Parse(this.dtPost.Rows[this.dtgPostSelectedRowIndex]["GS_POST_ID"].ToString()) == this.intCurrentPostID)
                        {
                            this.dtPost.Rows[this.dtgPostSelectedRowIndex]["CODE"] = this.txtCode.Text;
                            this.dtPost.Rows[this.dtgPostSelectedRowIndex]["NAME"] = this.txtName.Text;
                            this.dtPost.Rows[this.dtgPostSelectedRowIndex]["ISACTIVE"] = this.ckIsActive.Checked ? "Y" : "N";
                            this.dtPost.Rows[this.dtgPostSelectedRowIndex]["DESCRIPTION"] = this.txtDescription.Text;
                            return;
                        }
                    }

                    for (int rowCounter = 0; rowCounter <= this.dtPost.Rows.Count - 1; rowCounter++)
                    {
                        if (int.Parse(this.dtPost.Rows[rowCounter]["GS_POST_ID"].ToString()) == this.intCurrentPostID)
                        {
                            this.dtPost.Rows[rowCounter]["CODE"] = this.txtCode.Text;
                            this.dtPost.Rows[rowCounter]["NAME"] = this.txtName.Text;
                            this.dtPost.Rows[rowCounter]["ISACTIVE"] = this.ckIsActive.Checked ? "Y" : "N";
                            this.dtPost.Rows[rowCounter]["DESCRIPTION"] = this.txtDescription.Text;
                            return;
                        }
                    }
                }
            }
        }

        private void searchToolStripButton_Click(object sender, EventArgs e)
        {
            this.dtPost =
                getDataFromDB.getGS_POSTInfo(null,
                    "", "", "", "", false, false, "AND");

            this.dtPost.Columns["CODE"].SetOrdinal(0);
            this.dtPost.Columns["NAME"].SetOrdinal(1);            
            this.dtPost.Columns["ISACTIVE"].SetOrdinal(4);

            this.dtgPosts.DataSource = this.dtPost;

            this.dtgPosts.Columns["CODE"].HeaderText = "Code";
            this.dtgPosts.Columns["NAME"].HeaderText = "Name";
            this.dtgPosts.Columns["ISACTIVE"].HeaderText = "Active";


            this.dtgPosts.Columns["GS_POST_ID"].Visible = false;
            this.dtgPosts.Columns["CREATED"].Visible = false;
            this.dtgPosts.Columns["CREATEDBY"].Visible = false;
            this.dtgPosts.Columns["UPDATED"].Visible = false;
            this.dtgPosts.Columns["UPDATEDBY"].Visible = false;
            this.dtgPosts.Columns["DESCRIPTION"].Visible = false;
        }

        private void exitToolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPost_Load(object sender, EventArgs e)
        {            

            this.newToolStripButton_Click(sender, e);

            this.dtPost =
                getDataFromDB.getGS_POSTInfo(null,
                    "", "", "", "", false, true, "AND");

            this.dtPost.Columns["CODE"].SetOrdinal(0);
            this.dtPost.Columns["NAME"].SetOrdinal(1);
            this.dtPost.Columns["ISACTIVE"].SetOrdinal(4);

            this.dtgPosts.DataSource = this.dtPost;

            this.dtgPosts.Columns["CODE"].HeaderText = "Code";
            this.dtgPosts.Columns["NAME"].HeaderText = "Name";            
            this.dtgPosts.Columns["ISACTIVE"].HeaderText = "Active";


            this.dtgPosts.Columns["GS_POST_ID"].Visible = false;
            this.dtgPosts.Columns["CREATED"].Visible = false;
            this.dtgPosts.Columns["CREATEDBY"].Visible = false;
            this.dtgPosts.Columns["UPDATED"].Visible = false;
            this.dtgPosts.Columns["UPDATEDBY"].Visible = false;
            this.dtgPosts.Columns["DESCRIPTION"].Visible = false;

        }

        private void dtgPosts_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgPosts.SelectedRows.Count < 1)
            {
                this.intCurrentPostID = -1;
                return;
            }
            int dtgselectedRowIndex =
                this.dtgPosts.SelectedRows[0].Index;

            this.intCurrentPostID =
                int.Parse(this.dtgPosts.Rows[dtgselectedRowIndex].Cells["GS_POST_ID"].Value.ToString());

            this.txtCode.Text =
                this.dtgPosts.Rows[dtgselectedRowIndex].Cells["CODE"].Value.ToString();

            this.txtName.Text =
                this.dtgPosts.Rows[dtgselectedRowIndex].Cells["NAME"].Value.ToString();
                        
            this.ckIsActive.Checked =
                this.dtgPosts.Rows[dtgselectedRowIndex].Cells["ISACTIVE"].Value.ToString() == "Y" ? true : false;

            this.txtDescription.Text =
                this.dtgPosts.Rows[dtgselectedRowIndex].Cells["DESCRIPTION"].Value.ToString();
            
        }

    }
}
