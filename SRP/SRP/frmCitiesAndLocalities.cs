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
    public partial class frmCitiesAndLocalities : Panel
    {
        public frmCitiesAndLocalities()
        {
            InitializeComponent();            
        }


        string stringShopID = generalResultInformation.activeStation;

        private int intCountryID = 0;
        private int intCityID = 0;
        private int intLocalityID = 0;
        private int intSubLocalityID = 0;

        enum CurrentTab {Country, City,Locality,SubLocality};

        CurrentTab visibleTab = new CurrentTab();

        static private Color clNormalLableColor = Color.Black;
        static private Color clErrorLableColor = Color.Red;
        static private Color clChangedLableColor = Color.Blue;

        private DataTable dtNewCountryInformation = new DataTable();
        private DataTable dtNewCityInformation = new DataTable();
        private DataTable dtNewLocalityInformation = new DataTable();
        private DataTable dtNewSubLocalityInformation = new DataTable();


        private DataTable dtExistingCountryInformation = new DataTable();
        private DataTable dtExistingCityInformation = new DataTable();
        private DataTable dtExistingLocalityInformation = new DataTable();
        private DataTable dtExistingSubLocalityInformation = new DataTable();

        private DataTable dtSummaryLocalities = new DataTable();
        private DataTable dtSummarySubLocalities = new DataTable();

        private dataBuilder getDatafromDataBase = new dataBuilder();

                

        private void PrepareForNewRecord()
        {
            foreach (Control formControl in 
                this.tbcCityAndLocality.SelectedTab.Controls)
            {
                if (formControl.GetType().Equals(typeof(Label)))
                    formControl.ForeColor = clNormalLableColor;

                if (formControl.GetType().Equals(typeof(TextBox)))
                    formControl.Text = "";                
            }
        }

        private bool checkForCompleteNewRecord()
        {
            if (this.visibleTab == CurrentTab.Country)
            {
                if (this.txtCountryName.Text == "")
                {
                    this.lblCountryName.ForeColor = clErrorLableColor;
                    return false;
                }
                else
                {
                    this.lblCountryName.ForeColor = clNormalLableColor;
                }

                if (this.txtCountryISOCode.Text == "")
                {
                    this.lblCounrtyISOCode.ForeColor = clErrorLableColor;
                    return false;
                }
                else
                {
                    this.lblCounrtyISOCode.ForeColor = clNormalLableColor;
                }
            }
            else if (this.visibleTab == CurrentTab.City)
            {
                if (this.txtCityName.Text == "")
                {
                    this.lblCityName.ForeColor = clErrorLableColor;
                    return false;
                }
                else
                {
                    this.lblCityName.ForeColor = clNormalLableColor;
                }
            }
            else if (this.visibleTab == CurrentTab.Locality)
            {
                if (this.intCityID == 0 &&
                    this.txtLocalityName.Text == "")
                {
                    this.txtLocalityName.ForeColor = clErrorLableColor;
                    return true;
                }
                else
                {
                    this.txtLocalityName.ForeColor = clNormalLableColor;
                }
            }
            else if (this.visibleTab == CurrentTab.SubLocality)
            {
                if (this.intLocalityID == 0 &&
                    this.txtSubLocalityName.Text == "")
                {
                    this.txtSubLocalityName.ForeColor = clErrorLableColor;
                    return false;
                }
                else
                {
                    this.txtSubLocalityName.ForeColor = clNormalLableColor;
                }
            }
            return true; 
        }

        private void DetermineTheVisibleTab()
        {
            if (this.tbcCityAndLocality.SelectedTab.Name == "tbpCountry")
                this.visibleTab = CurrentTab.Country;
            else if (this.tbcCityAndLocality.SelectedTab.Name == "tbpCity")
                this.visibleTab = CurrentTab.City;
            else if (this.tbcCityAndLocality.SelectedTab.Name == "tbpLocality")
                this.visibleTab = CurrentTab.Locality;
            else if (this.tbcCityAndLocality.SelectedTab.Name == "tbpSubLocality")
                this.visibleTab = CurrentTab.SubLocality;
        }

        private void setGridVisibleColumns()
        {
            //if (this.visibleTab == CurrentTab.City)
            //{
                this.dtExistingCountryInformation =
                    this.getDatafromDataBase.
                        getC_COUNTRYInfo(null, "", "", "", triStateBool.ignor,
                                            triStateBool.ignor, true, "");
                this.dtgCountryGridView.DataSource = this.dtExistingCountryInformation;

                this.dtgCountryGridView.Columns["M_SHOP_ID"].Visible = false;
                this.dtgCountryGridView.Columns["AD_ORG_ID"].Visible = false;
                this.dtgCountryGridView.Columns["C_COUNTRY_ID"].Visible = false;
                this.dtgCountryGridView.Columns["CREATED"].Visible = false;
                this.dtgCountryGridView.Columns["UPDATED"].Visible = false;
                this.dtgCountryGridView.Columns["CREATEDBY"].Visible = false;
                this.dtgCountryGridView.Columns["UPDATEDBY"].Visible = false;
            // }
            // else if (this.visibleTab == CurrentTab.City)
            //{
                this.dtExistingCityInformation =
                    this.getDatafromDataBase.
                        getC_CITYInfo(null, "", "", "", "", triStateBool.ignor, triStateBool.ignor,true, "");
                this.dtgCityGrid.DataSource = this.dtExistingCityInformation;

                this.dtgCityGrid.Columns["M_SHOP_ID"].Visible = false;
                this.dtgCityGrid.Columns["AD_ORG_ID"].Visible = false;
                this.dtgCityGrid.Columns["C_CITY_ID"].Visible = false;
                this.dtgCityGrid.Columns["C_COUNTRY_ID"].Visible = false;
                this.dtgCityGrid.Columns["CREATED"].Visible = false;
                this.dtgCityGrid.Columns["UPDATED"].Visible = false;
                this.dtgCityGrid.Columns["CREATEDBY"].Visible = false;
                this.dtgCityGrid.Columns["UPDATEDBY"].Visible = false;
           // }
           // else if (this.visibleTab == CurrentTab.Locality)
            //{
                this.dtExistingLocalityInformation =
                    this.getDatafromDataBase.getC_LOCALITYInfo(null, "", "",
                            this.intCityID.ToString(), "", "",
                            triStateBool.ignor, triStateBool.ignor,true, "AND");
                this.dtgLocalityGridView.DataSource = this.dtExistingLocalityInformation;

                this.dtgLocalityGridView.Columns["M_SHOP_ID"].Visible = false;
                this.dtgLocalityGridView.Columns["AD_ORG_ID"].Visible = false;
                this.dtgLocalityGridView.Columns["C_CITY_ID"].Visible = false;
                this.dtgLocalityGridView.Columns["CREATED"].Visible = false;
                this.dtgLocalityGridView.Columns["UPDATED"].Visible = false;
                this.dtgLocalityGridView.Columns["CREATEDBY"].Visible = false;
                this.dtgLocalityGridView.Columns["UPDATEDBY"].Visible = false;
                this.dtgLocalityGridView.Columns["C_LOCALITY_ID"].Visible = false;
                this.dtgLocalityGridView.Columns["M_PARENTLOCALITY_ID"].Visible = false;
            /*}
            else if (this.visibleTab == CurrentTab.SubLocality)
            {*/
                this.dtExistingSubLocalityInformation =
                    this.getDatafromDataBase.getC_SUBLOCALITYInfo(null, "", "",
                            this.intLocalityID.ToString(), "", "",
                            triStateBool.ignor, triStateBool.ignor,true, "AND");
                this.dtgSubLocalityGridView.DataSource = this.dtExistingSubLocalityInformation;

                this.dtgSubLocalityGridView.Columns["M_SHOP_ID"].Visible = false;
                this.dtgSubLocalityGridView.Columns["AD_ORG_ID"].Visible = false;
                this.dtgSubLocalityGridView.Columns["C_SUBLOCALITY_ID"].Visible = false;
                this.dtgSubLocalityGridView.Columns["CREATED"].Visible = false;
                this.dtgSubLocalityGridView.Columns["UPDATED"].Visible = false;
                this.dtgSubLocalityGridView.Columns["CREATEDBY"].Visible = false;
                this.dtgSubLocalityGridView.Columns["UPDATEDBY"].Visible = false;
                this.dtgSubLocalityGridView.Columns["C_LOCALITY_ID"].Visible = false;
                this.dtgSubLocalityGridView.Columns["M_PARENTSUBLOC_ID"].Visible = false;
            //}
        }



        public void frmCitiesAndLocalities_Load(object sender, EventArgs e)
        {
            if (generalResultInformation.currentFormIsReadOnly)
            {
                this.tlsDelete.Visible = false;
                this.tlsNew.Visible = false;
                this.tlsSave.Visible = false;
            }

            this.DetermineTheVisibleTab();
            this.setGridVisibleColumns();
            this.PrepareForNewRecord();
            this.tlsSearch_Click(sender, e);

        }

        
        private void ckLocalityIsSummary_CheckedChanged(object sender, EventArgs e)
        {
            bool showParentField = !this.ckLocalityIsSummary.Checked;
            this.lblLocalityParentLocality.Visible = showParentField;
            this.cmdLacalityParentLocality.Visible = showParentField;       
        }

        private void ckSubLocalityIsSummary_CheckedChanged(object sender, EventArgs e)
        {
            bool showParentField = !this.ckSubLocalityIsSummary.Checked;
            this.lblSubLocalityParentSubLocality.Visible = showParentField;
            this.cmdSubLocalityParentSubLocality.Visible = showParentField;
        }

        
        private void txtCityCountry_TextChanged(object sender, EventArgs e)
        {
            if (this.visibleTab != CurrentTab.City)
                return;

            bool enableForm;
            if (this.txtCityCountry.Text != "" &&
                this.intCountryID != 0)
                enableForm = true;
            else
                enableForm = false;

            this.txtCityName.Enabled = enableForm;
            this.txtCityDescription.Enabled = enableForm;
            this.ckCityIsActive.Enabled = enableForm;
            
            this.tlsCommandToolBar.Enabled = enableForm;
        }

        private void txtLocalityCity_TextChanged(object sender, EventArgs e)
        {
            if (this.visibleTab != CurrentTab.Locality)
                return;

            bool enableForm;
            if (this.txtLocalityCity.Text != "" &&
                this.intCityID != 0)
                enableForm = true;
            else
                enableForm = false;

            this.txtLocalityName.Enabled = enableForm;
            this.txtLocalityDescritpion.Enabled = enableForm;
            this.ckLocalityIsActive.Enabled = enableForm;
            this.ckLocalityIsSummary.Enabled = enableForm;
            this.cmdLacalityParentLocality.Enabled = enableForm;

            this.tlsCommandToolBar.Enabled = enableForm;
        }

        private void txtSubLocalityLocality_TextChanged(object sender, EventArgs e)
        {
            if (this.visibleTab != CurrentTab.SubLocality)
                return;

            bool enableForm;
            if (this.txtSubLocalityLocality.Text != "" &&
                this.intLocalityID != 0)
                enableForm = true;
            else
                enableForm = false;

            this.txtSubLocalityName.Enabled = enableForm;
            this.txtSubLocalityDescritption.Enabled = enableForm;
            this.ckSubLocalityIsActive.Enabled = enableForm;
            this.ckSubLocalityIsSummary.Enabled = enableForm;
            this.cmdSubLocalityParentSubLocality.Enabled = enableForm;

            this.tlsCommandToolBar.Enabled = enableForm;
            
        }


        private void tbcCityAndLocality_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DetermineTheVisibleTab();

            if (this.visibleTab == CurrentTab.City)
            {                
                if (this.intCountryID == 0)
                {
                    this.txtCityCountry.Text = "";
                    this.dtExistingCityInformation.Rows.Clear();
                    this.tlsCommandToolBar.Enabled = false;
                }
                else
                {
                    this.tlsCommandToolBar.Enabled = true;
                    this.txtCityCountry.Text =
                        this.getDatafromDataBase.
                            getC_COUNTRYInfo(null, "", this.intCountryID.ToString(),
                                "", triStateBool.ignor, triStateBool.ignor, false, "AND")
                                    .Rows[0]["NAME"].ToString();
                    this.tlsNew_Click(sender, e);
                    this.tlsSearch_Click(sender, e);
                }
            }
            else if (this.visibleTab == CurrentTab.Locality)
            {
                this.cmdLacalityParentLocality_DropDown(sender, e);
                if (this.intCityID == 0)
                {
                    this.txtLocalityCity.Text = "";
                    this.dtExistingLocalityInformation.Rows.Clear();
                    this.tlsCommandToolBar.Enabled = false;
                }
                else
                {                   
                    this.tlsCommandToolBar.Enabled = true;
                    this.txtLocalityCity.Text =
                        this.getDatafromDataBase.
                            getC_CITYInfo(null, "", this.intCityID.ToString(),
                                "", "", triStateBool.ignor, triStateBool.ignor, false, "AND")
                                    .Rows[0]["NAME"].ToString();
                    this.tlsNew_Click(sender, e);
                    this.tlsSearch_Click(sender, e);
                }
            }
            else if (this.visibleTab == CurrentTab.SubLocality)
            {
                this.cmdSubLocalityParentSubLocality_DropDown(sender, e);

                if (this.intLocalityID == 0)
                {
                    this.txtSubLocalityLocality.Text = "";
                    this.dtExistingSubLocalityInformation.Rows.Clear();
                    this.tlsCommandToolBar.Enabled = false;
                }
                else
                {
                    string stSummary =
                    this.getDatafromDataBase.getC_LOCALITYInfo(null, "",
                        this.intLocalityID.ToString(), "", "", "", triStateBool.ignor,
                        triStateBool.ignor, false, "AND").Rows[0]["ISSUMMARY"].ToString();
                    if (stSummary == "Y")
                    {
                        this.txtSubLocalityLocality.Text = "";
                        this.dtExistingSubLocalityInformation.Rows.Clear();
                        this.tlsCommandToolBar.Enabled = false;
                    }
                    else
                    {                        
                        this.tlsCommandToolBar.Enabled = true;
                        this.txtSubLocalityLocality.Text =
                            this.getDatafromDataBase.
                                getC_LOCALITYInfo(null, "", this.intLocalityID.ToString(),
                                        "", "", "", triStateBool.ignor, triStateBool.ignor, false, "AND")
                                        .Rows[0]["NAME"].ToString();
                        this.tlsNew_Click(sender, e);
                        this.tlsSearch_Click(sender, e);
 
                    }   
                }
            }
            else if (this.visibleTab == CurrentTab.Country)
            {
                this.tlsCommandToolBar.Enabled = true;
            }                            
        }


        private void tlsNew_Click(object sender, EventArgs e)
        {
            if (this.visibleTab == CurrentTab.Country)
            {
                this.intCountryID = 0;

                this.txtCountryName.Text = "";
                this.txtCountryDescription.Text = "";
                this.ckCounrtyIsActive.Checked = true;

                this.intCityID = 0;

                this.txtCityName.Text = "";
                this.txtCityDescription.Text = "";
                this.ckCityIsActive.Checked = true;

                this.intLocalityID = 0;

                this.txtLocalityName.Text = "";
                this.txtLocalityDescritpion.Text = "";
                this.ckLocalityIsActive.Checked = true;
                this.ckLocalityIsSummary.Checked = false;

                this.intSubLocalityID = 0;

                this.txtSubLocalityName.Text = "";
                this.txtSubLocalityDescritption.Text = "";
                this.ckSubLocalityIsActive.Checked = true;
                this.ckSubLocalityIsSummary.Checked = false;

            }            
            else if (this.visibleTab == CurrentTab.City)
            {
                this.intCityID = 0;

                this.txtCityName.Text = "";
                this.txtCityDescription.Text = "";
                this.ckCityIsActive.Checked = true;

                this.intLocalityID = 0;

                this.txtLocalityName.Text = "";
                this.txtLocalityDescritpion.Text = "";
                this.ckLocalityIsActive.Checked = true;
                this.ckLocalityIsSummary.Checked = false;

                this.intSubLocalityID = 0;

                this.txtSubLocalityName.Text = "";
                this.txtSubLocalityDescritption.Text = "";
                this.ckSubLocalityIsActive.Checked = true;
                this.ckSubLocalityIsSummary.Checked = false;

            }
            else if (this.visibleTab == CurrentTab.Locality)
            {
                this.intLocalityID = 0;

                this.txtLocalityName.Text = "";
                this.txtLocalityDescritpion.Text = "";
                this.ckLocalityIsActive.Checked = true;
                this.ckLocalityIsSummary.Checked = false;

                this.intSubLocalityID = 0;

                this.txtSubLocalityName.Text = "";
                this.txtSubLocalityDescritption.Text = "";
                this.ckSubLocalityIsActive.Checked = true;
                this.ckSubLocalityIsSummary.Checked = false;
                
            }
            else if (this.visibleTab == CurrentTab.SubLocality)
            {
                this.intSubLocalityID = 0;

                this.txtSubLocalityName.Text = "";
                this.txtSubLocalityDescritption.Text = "";
                this.ckSubLocalityIsActive.Checked = true;
                this.ckSubLocalityIsSummary.Checked = false;
            }
        }

        private void tlsSave_Click(object sender, EventArgs e)
        {
            string stTypeOfChange = "";
            if (!this.checkForCompleteNewRecord())
            {
                MessageBox.Show("Please complete the missing form element before proceeding.", 
                    "SRP SAVE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.visibleTab == CurrentTab.Country)
            {
                this.dtNewCountryInformation =
                    this.getDatafromDataBase.getC_COUNTRYInfo
                        (null, "", "", "", triStateBool.ignor, triStateBool.ignor, true, "");
                DataRow drNewCountry =
                    this.dtNewCountryInformation.NewRow();

                drNewCountry["M_SHOP_ID"] = this.stringShopID;
                drNewCountry["NAME"] = this.txtCountryName.Text;
                drNewCountry["ISOCODE"] = this.txtCountryISOCode.Text;
                drNewCountry["DESCRIPTION"] = this.txtCountryDescription.Text;
                if (this.ckCityIsActive.Checked)
                    drNewCountry["ISACTIVE"] = "Y";
                else
                    drNewCountry["ISACTIVE"] = "N";
                
                if (this.intCityID != 0)
                {
                    drNewCountry["C_COUNTRY_ID"] = this.intCityID;
                    stTypeOfChange = "UPDATE";
                }
                else
                    stTypeOfChange = "INSERT";

                this.dtNewCountryInformation.Rows.Add(drNewCountry);

                string[] primaryKeySepartor = { " <(", ")>||" };
                string[] primaryKey =
                    this.getDatafromDataBase.changeDataBaseTableData
                        (this.dtNewCountryInformation.Copy(), "C_COUNTRY", stTypeOfChange)[0]
                        .Split(primaryKeySepartor, StringSplitOptions.RemoveEmptyEntries);

                if (primaryKey.Length > 1 && stTypeOfChange == "INSERT")
                {
                    this.intCountryID = int.Parse(primaryKey[1]);
                    this.tlsSearch_Click(sender, e);
                    if (this.dtExistingCountryInformation.Rows.Count > 0)
                        this.dtgCountryGridView.Rows
                            [this.dtExistingCountryInformation.Rows.Count - 1].Selected = true;
                }
            }
            else if (this.visibleTab == CurrentTab.City)
            {
                this.dtNewCityInformation = 
                    this.getDatafromDataBase.getC_CITYInfo
                        (null, "", "", "", "", triStateBool.ignor, triStateBool.ignor, true, "");
                DataRow drNewCity =
                    this.dtNewCityInformation.NewRow();

                drNewCity["M_SHOP_ID"] = this.stringShopID;
                drNewCity["NAME"] = this.txtCityName.Text;
                drNewCity["DESCRIPTION"] = this.txtCityDescription.Text;
                if (this.ckCityIsActive.Checked)
                    drNewCity["ISACTIVE"] = "Y";
                else
                    drNewCity["ISACTIVE"] = "N";
                drNewCity["C_COUNTRY_ID"] = this.intCountryID;

                if (this.intCityID != 0)
                {
                    drNewCity["C_CITY_ID"] = this.intCityID;
                    stTypeOfChange = "UPDATE";
                }
                else
                    stTypeOfChange = "INSERT";

                this.dtNewCityInformation.Rows.Add(drNewCity);
                
                string[] primaryKeySepartor = { " <(", ")>||" };
                string[] primaryKey =
                    this.getDatafromDataBase.changeDataBaseTableData
                        (this.dtNewCityInformation.Copy(), "C_CITY", stTypeOfChange)[0]
                        .Split(primaryKeySepartor, StringSplitOptions.RemoveEmptyEntries);

                if (primaryKey.Length > 1 && stTypeOfChange == "INSERT")
                {
                    this.intCityID = int.Parse(primaryKey[1]);
                    this.tlsSearch_Click(sender, e);
                    if(this.dtExistingCityInformation.Rows.Count > 0)
                        this.dtgCityGrid.Rows
                            [this.dtExistingCityInformation.Rows.Count - 1].Selected = true;
                }
            }
            else if (this.visibleTab == CurrentTab.Locality)
            {
                this.dtNewLocalityInformation =
                    this.getDatafromDataBase.getC_LOCALITYInfo
                            (null, "", "", "", "", "", triStateBool.ignor,
                                triStateBool.ignor, true, "");
                DataRow drNewLocality = 
                    this.dtNewLocalityInformation.NewRow();

                if (this.intLocalityID != 0)
                {
                    drNewLocality["C_LOCALITY_ID"] = this.intLocalityID;
                    stTypeOfChange = "UPDATE";
                }
                else
                    stTypeOfChange = "INSERT";
                
                drNewLocality["M_SHOP_ID"] = this.stringShopID;
                drNewLocality["C_CITY_ID"] = this.intCityID;
                drNewLocality["NAME"] = this.txtLocalityName.Text;
                drNewLocality["DESCRIPTION"] = this.txtLocalityDescritpion.Text;
                if (this.ckLocalityIsActive.Checked)
                    drNewLocality["ISACTIVE"] = "Y";
                else
                    drNewLocality["ISACTIVE"] = "N";

                if (this.ckLocalityIsSummary.Checked)
                    drNewLocality["ISSUMMARY"] = "Y";
                else
                    drNewLocality["ISSUMMARY"] = "N";

                if (this.cmdLacalityParentLocality.SelectedIndex >= 0 &&
                    this.cmdLacalityParentLocality.SelectedIndex < 
                    this.cmdLacalityParentLocality.Items.Count)
                    drNewLocality["M_PARENTLOCALITY_ID"] = 
                        this.dtSummaryLocalities.
                             Rows[this.cmdLacalityParentLocality.SelectedIndex]["C_LOCALITY_ID"];

                this.dtNewLocalityInformation.Rows.Add(drNewLocality);

                string[] primaryKeySepartor = { " <(", ")>||" };
                string[] primaryKey =
                    this.getDatafromDataBase.changeDataBaseTableData
                        (this.dtNewLocalityInformation.Copy(), "C_LOCALITY", stTypeOfChange)[0]
                        .Split(primaryKeySepartor, StringSplitOptions.RemoveEmptyEntries);

                if (primaryKey.Length > 1 && stTypeOfChange == "INSERT")
                {
                    this.intLocalityID = int.Parse(primaryKey[1]);
                    this.tlsSearch_Click(sender, e);
                    if (this.dtExistingLocalityInformation.Rows.Count > 0)
                        this.dtgLocalityGridView.Rows
                            [this.dtExistingLocalityInformation.Rows.Count - 1].Selected = true;
                }                                                
            }
            else if (this.visibleTab == CurrentTab.SubLocality)
            {
                this.dtNewSubLocalityInformation =
                    this.getDatafromDataBase.
                            getC_SUBLOCALITYInfo(null, "", "", "", "", 
                                    "", triStateBool.ignor, triStateBool.ignor, 
                                    true, "");

                DataRow drNewSubLocality =
                    this.dtNewSubLocalityInformation.NewRow();

                if (this.intSubLocalityID != 0)
                {
                    drNewSubLocality["C_SUBLOCALITY_ID"] = this.intSubLocalityID;
                    stTypeOfChange = "UPDATE";
                }
                else
                    stTypeOfChange = "INSERT";

                drNewSubLocality["M_SHOP_ID"] = this.stringShopID;
                drNewSubLocality["C_LOCALITY_ID"] = this.intLocalityID;
                drNewSubLocality["NAME"] = this.txtSubLocalityName.Text;
                drNewSubLocality["DESCRIPTION"] = this.txtSubLocalityDescritption.Text;
                if (this.ckSubLocalityIsActive.Checked)
                    drNewSubLocality["ISACTIVE"] = "Y";
                else
                    drNewSubLocality["ISACTIVE"] = "N";

                if (this.ckSubLocalityIsSummary.Checked)
                    drNewSubLocality["ISSUMMARY"] = "Y";
                else
                    drNewSubLocality["ISSUMMARY"] = "N";

                if (this.cmdSubLocalityParentSubLocality.SelectedIndex >= 0 &&
                    this.cmdSubLocalityParentSubLocality.SelectedIndex < 
                    this.cmdSubLocalityParentSubLocality.Items.Count)
                    drNewSubLocality["M_PARENTSUBLOCALITY_ID"] =
                        this.dtSummarySubLocalities.
                             Rows[this.cmdSubLocalityParentSubLocality.SelectedIndex]["C_SUBLOCALITY_ID"];

                this.dtNewSubLocalityInformation.Rows.Add(drNewSubLocality);

                string[] primaryKeySepartor = { " <(", ")>||" };
                string[] primaryKey =
                    this.getDatafromDataBase.changeDataBaseTableData
                        (this.dtNewSubLocalityInformation.Copy(), "C_SUBLOCALITY", stTypeOfChange)[0]
                            .Split(primaryKeySepartor, StringSplitOptions.RemoveEmptyEntries);

                if (primaryKey.Length > 1 && stTypeOfChange == "INSERT")
                {
                    this.intSubLocalityID = int.Parse(primaryKey[1]);
                    this.tlsSearch_Click(sender, e);
                    if (this.dtExistingSubLocalityInformation.Rows.Count > 0)
                        this.dtgSubLocalityGridView.Rows
                            [this.dtExistingSubLocalityInformation.Rows.Count - 1].Selected = true;
                } 
            }
        }

        private void tlsSearch_Click(object sender, EventArgs e)
        {
            if (this.visibleTab == CurrentTab.Country)
            {
                this.dtExistingCountryInformation =
                    this.getDatafromDataBase.
                        getC_COUNTRYInfo(null, "", "", "", triStateBool.ignor, triStateBool.ignor, false, "");
                this.dtgCountryGridView.DataSource = this.dtExistingCountryInformation;
                if (this.dtExistingCountryInformation.Rows.Count > 0)
                    this.dtgCountryGridView.Rows[0].Selected = true;
            }
            else if (this.visibleTab == CurrentTab.City)
            {
                this.dtExistingCityInformation =
                    this.getDatafromDataBase.
                        getC_CITYInfo(null, "", "", this.intCountryID.ToString(),
                            "", triStateBool.ignor, triStateBool.ignor, false, "");
                this.dtgCityGrid.DataSource = this.dtExistingCityInformation;
                if (this.dtExistingCityInformation.Rows.Count > 0)
                    this.dtgCityGrid.Rows[0].Selected = true;          
            }
            else if (this.visibleTab == CurrentTab.Locality)
            {
                this.dtExistingLocalityInformation =
                    this.getDatafromDataBase.getC_LOCALITYInfo(null,"","",
                            this.intCityID.ToString(),"","",
                            triStateBool.ignor,triStateBool.ignor,false,"AND");
                this.dtgLocalityGridView.DataSource = this.dtExistingLocalityInformation;
                if (this.dtExistingLocalityInformation.Rows.Count > 0)
                    this.dtgLocalityGridView.Rows[0].Selected = true;
            }
            else if (this.visibleTab == CurrentTab.SubLocality)
            {
                this.dtExistingSubLocalityInformation =
                    this.getDatafromDataBase.getC_SUBLOCALITYInfo(null, "", "",
                            this.intLocalityID.ToString(), "", "",
                            triStateBool.ignor, triStateBool.ignor, false, "AND");
                this.dtgSubLocalityGridView.DataSource = this.dtExistingSubLocalityInformation;
                if(this.dtExistingSubLocalityInformation.Rows.Count > 0)
                    this.dtgSubLocalityGridView.Rows[0].Selected = true;                                
            }
        }


        private void dtgCountryGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgCountryGridView.SelectedRows.Count < 1)
            {
                return;
            }

            int selectedCountryIndex =
                this.dtgCountryGridView.SelectedRows[0].Index;
            this.intCountryID =
                int.Parse(this.dtgCountryGridView.Rows[selectedCountryIndex].Cells["C_COUNTRY_ID"].Value.ToString());
            this.txtCountryName.Text =
                this.dtgCountryGridView.Rows[selectedCountryIndex].Cells["NAME"].Value.ToString();
            this.txtCountryISOCode.Text =
                this.dtgCountryGridView.Rows[selectedCountryIndex].Cells["ISOCODE"].Value.ToString();
            this.txtCountryDescription.Text =
                this.dtgCountryGridView.Rows[selectedCountryIndex].Cells["DESCRIPTION"].Value.ToString();

            if (this.dtgCountryGridView.Rows[selectedCountryIndex].
                    Cells["ISACTIVE"].Value.ToString() == "Y")
                this.ckCityIsActive.Checked = true;
            else
                this.ckCityIsActive.Checked = false;

        }

        private void dtgCityGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgCityGrid.SelectedRows.Count < 1)
            {
                return;
            }

            int selectedCityIndex =
                this.dtgCityGrid.SelectedRows[0].Index;
            this.intCityID =
                int.Parse(this.dtgCityGrid.Rows[selectedCityIndex].Cells["C_CITY_ID"].Value.ToString());
            this.txtCityName.Text =
                this.dtgCityGrid.Rows[selectedCityIndex].Cells["NAME"].Value.ToString();
            this.txtCityDescription.Text =
                this.dtgCityGrid.Rows[selectedCityIndex].Cells["DESCRIPTION"].Value.ToString();
           
            if (this.dtgCityGrid.Rows[selectedCityIndex].
                    Cells["ISACTIVE"].Value.ToString() == "Y")
                this.ckCityIsActive.Checked = true;
            else
                this.ckCityIsActive.Checked = false;

        }

        private void dtgLocalityGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgLocalityGridView.SelectedRows.Count < 1)
            {
                return;
            }

            int selectedCityIndex =
                this.dtgLocalityGridView.SelectedRows[0].Index;
            this.intLocalityID =
                int.Parse(this.dtgLocalityGridView.Rows[selectedCityIndex]
                    .Cells["C_LOCALITY_ID"].Value.ToString());
            this.txtLocalityName.Text =
                this.dtgLocalityGridView.Rows[selectedCityIndex].Cells["NAME"].Value.ToString();

            if(this.dtgLocalityGridView.Rows[selectedCityIndex].
                    Cells["ISACTIVE"].Value.ToString() == "Y")
                this.ckLocalityIsActive.Checked = true;
            else
                this.ckLocalityIsActive.Checked = false;

            if (this.dtgLocalityGridView.Rows[selectedCityIndex]
                .Cells["ISSUMMARY"].Value.ToString() == "Y")
                this.ckLocalityIsSummary.Checked = true;
            else
                this.ckLocalityIsSummary.Checked = false;

            if (this.dtgLocalityGridView.Rows[selectedCityIndex]
                    .Cells["M_PARENTLOCALITY_ID"].Value.ToString() != "0")
            {
                string stLocalityName =
                    this.getDatafromDataBase.getC_LOCALITYInfo(null, "",
                        this.dtgLocalityGridView.Rows[selectedCityIndex]
                            .Cells["M_PARENTLOCALITY_ID"].Value.ToString(),
                            "", "", "", triStateBool.ignor, triStateBool.ignor, false, "AND")
                                .Rows[0]["NAME"].ToString();
                for (int rowCounter = 0;
                    rowCounter < this.dtSummaryLocalities.Rows.Count; rowCounter++)
                {
                    if (this.dtSummaryLocalities.Rows[rowCounter]["C_LOCALITY_ID"].ToString() ==
                        this.dtgLocalityGridView.Rows[selectedCityIndex]
                            .Cells["M_PARENTLOCALITY_ID"].Value.ToString())
                    {
                        this.cmdLacalityParentLocality.SelectedIndex = rowCounter;
                        break;
                    }                    
                }
                if (this.cmdLacalityParentLocality.SelectedIndex < 0 ||
                    this.cmdLacalityParentLocality.SelectedIndex >
                    this.cmdLacalityParentLocality.Items.Count)
                {
                    this.cmdLacalityParentLocality.Items.Insert
                        (this.cmdLacalityParentLocality.Items.Count, stLocalityName);
                    this.cmdLacalityParentLocality.SelectedIndex =
                        this.cmdLacalityParentLocality.Items.Count - 1; 
                }
                else if (this.cmdLacalityParentLocality.SelectedItem.ToString() !=
                    stLocalityName)
                {
                    this.cmdLacalityParentLocality.Items.Insert
                        (this.cmdLacalityParentLocality.Items.Count, stLocalityName);
                    this.cmdLacalityParentLocality.SelectedIndex =
                        this.cmdLacalityParentLocality.Items.Count - 1;
                }                    
                    
            }

            this.txtLocalityDescritpion.Text =
                this.dtgLocalityGridView.Rows[selectedCityIndex]
                        .Cells["DESCRIPTION"].Value.ToString();
        }

        private void dtgSubLocalityGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgSubLocalityGridView.SelectedRows.Count < 1)
            {
                return;
            }

            int selectedCityIndex =
                this.dtgSubLocalityGridView.SelectedRows[0].Index;

            this.intSubLocalityID =
                int.Parse(this.dtgSubLocalityGridView.Rows[selectedCityIndex]
                        .Cells["C_SUBLOCALITY_ID"].Value.ToString());
            this.txtSubLocalityName.Text =
                this.dtgSubLocalityGridView.Rows[selectedCityIndex].Cells["NAME"].Value.ToString();

            if (this.dtgSubLocalityGridView.Rows[selectedCityIndex].
                    Cells["ISACTIVE"].Value.ToString() == "Y")
                this.ckSubLocalityIsActive.Checked = true;
            else
                this.ckSubLocalityIsActive.Checked = false;

            if (this.dtgSubLocalityGridView.Rows[selectedCityIndex]
                .Cells["ISSUMMARY"].Value.ToString() == "Y")
                this.ckSubLocalityIsSummary.Checked = true;
            else
                this.ckSubLocalityIsSummary.Checked = false;

            if (this.dtgSubLocalityGridView.Rows[selectedCityIndex]
                    .Cells["M_PARENTSUBLOC_ID"].Value.ToString() != "0")
            {
                string stSubLocalityName =
                    this.getDatafromDataBase.getC_LOCALITYInfo(null, "",
                        this.dtgSubLocalityGridView.Rows[selectedCityIndex]
                            .Cells["M_PARENTSUBLOC_ID"].Value.ToString(),
                            "", "", "", triStateBool.ignor, triStateBool.yes, false, "AND")
                                .Rows[0]["NAME"].ToString();

                for (int rowCounter = 0;
                    rowCounter < this.dtSummarySubLocalities.Rows.Count; rowCounter++)
                {
                    if (this.dtSummarySubLocalities.Rows[rowCounter]["C_SUBLOCALITY_ID"].ToString() ==
                        this.dtgSubLocalityGridView.Rows[selectedCityIndex]
                            .Cells["M_PARENTSUBLOC_ID"].Value.ToString())
                    {
                        this.cmdSubLocalityParentSubLocality.SelectedIndex = rowCounter;
                        break;
                    }                    
                }

                if (this.cmdSubLocalityParentSubLocality.SelectedIndex < 0 ||
                    this.cmdSubLocalityParentSubLocality.SelectedIndex >
                    this.cmdSubLocalityParentSubLocality.Items.Count)
                {
                    this.cmdSubLocalityParentSubLocality.Items.Insert
                        (this.cmdSubLocalityParentSubLocality.Items.Count, stSubLocalityName);
                    this.cmdSubLocalityParentSubLocality.SelectedIndex =
                        this.cmdLacalityParentLocality.Items.Count - 1;
                }
                else if (this.cmdSubLocalityParentSubLocality.SelectedItem.ToString() !=
                    stSubLocalityName)
                {
                    this.cmdSubLocalityParentSubLocality.Items.Insert
                        (this.cmdSubLocalityParentSubLocality.Items.Count, stSubLocalityName);
                    this.cmdSubLocalityParentSubLocality.SelectedIndex =
                        this.cmdLacalityParentLocality.Items.Count - 1;
                }
            }

            this.txtSubLocalityDescritption.Text =
                this.dtgSubLocalityGridView.Rows[selectedCityIndex]
                        .Cells["DESCRIPTION"].Value.ToString();
        }


        private void cmdLacalityParentLocality_DropDown(object sender, EventArgs e)
        {
            this.cmdLacalityParentLocality.Items.Clear();

            this.dtSummaryLocalities =
                        this.getDatafromDataBase.getC_LOCALITYInfo(null, "", "",
                                    this.intCityID.ToString(), "", "", triStateBool.yes,
                                    triStateBool.yes, false, "AND");
            
            for(int rowCounter = 0;
                rowCounter < this.dtSummaryLocalities.Rows.Count;rowCounter++)
                this.cmdLacalityParentLocality.Items.Insert(
                    this.cmdLacalityParentLocality.Items.Count,
                    this.dtSummaryLocalities.Rows[rowCounter]["NAME"].ToString());
            //this.cmdLacalityParentLocality.Items.Insert(
            //    this.cmdLacalityParentLocality.Items.Count, "--Not Applicable--");

        }

        private void cmdSubLocalityParentSubLocality_DropDown(object sender, EventArgs e)
        {
            this.dtSummarySubLocalities =
                            this.getDatafromDataBase.getC_SUBLOCALITYInfo(null, "", "",
                            this.intLocalityID.ToString(), "", "", triStateBool.yes,
                            triStateBool.yes, false, "AND");

            this.cmdSubLocalityParentSubLocality.Items.Clear();
            
            for (int rowCounter = 0; 
                rowCounter < this.dtSummarySubLocalities.Rows.Count; rowCounter++)
                this.cmdSubLocalityParentSubLocality.Items.Insert(
                    this.cmdSubLocalityParentSubLocality.Items.Count,
                    this.dtSummarySubLocalities.Rows[rowCounter]["NAME"].ToString());
            //this.cmdSubLocalityParentSubLocality.Items.Insert(
            //    this.cmdSubLocalityParentSubLocality.Items.Count, "--Not Applicable--");
        }


    }
}
    