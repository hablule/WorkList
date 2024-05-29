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
    public partial class frmBpartner : Panel
    {
        public frmBpartner()
        {
            InitializeComponent();                        
        }

        bool dtgBpartnerClicked = false;

        string stringShopID = generalResultInformation.activeStation;
        string stOrganisationID = "";
        int intBPartnerID = 0;
        int intCountryID = -1;
        int intCityID = -1;
        int intLocalityID = -1;
        int intSubLocalityID = -1;

        Color clNormalLableColor = Color.Black;
        Color clErrorLableColor = Color.Red;
        Color clChangedLableColor = Color.Blue;

        DataTable dtAccessableOrgInformation = new DataTable();
        
        DataTable dtNewBpartnerInformation = new DataTable();
        DataTable dtExistingBpartnerInformation = new DataTable();

        DataTable dtCountryList = new DataTable();
        DataTable dtCityList = new DataTable();
        DataTable dtLocalityList = new DataTable();
        DataTable dtSubLocalityList = new DataTable();

        dataBuilder getDatafromDataBase = new dataBuilder();
        businessRule getDataAccordingToRule = new businessRule();


        private void setUpOrganisations()
        {
            this.cmbOrganisation.Items.Clear();
            
            /*
            this.dtAccessableOrgInformation =
                this.getDatafromDataBase.mergeTables(this.dtAccessableOrgInformation,
                    this.getDataAccordingToRule.
                        getCurrentUserAccessableOrganisation(accessLevel.ReadOnly,
                                        triStateBool.ignor),
                      "AD_ORG_ID", false);
            */

            if (this.getDatafromDataBase.checkIfTableContainesData(this.dtAccessableOrgInformation))
            {
                for (int rowCounter = 0;
                        rowCounter <= this.dtAccessableOrgInformation.Rows.Count - 1; rowCounter++)
                {
                    this.cmbOrganisation.Items.Add(
                            this.dtAccessableOrgInformation.Rows[rowCounter]["NAME"].ToString());
                }
                this.cmbOrganisation.SelectedIndex = 0;
            }
            else
            {
                this.stOrganisationID = "";
            }
        }
        
        private bool checkForCompleteNewRecord()
        {
            bool foundError = false;

            if (this.stOrganisationID == "" ||
                this.dtAccessableOrgInformation.Rows.Count <= 0)
            {
                this.lblOrganisation.ForeColor = clErrorLableColor;
                foundError = true;
            }
            else
            {
                this.lblOrganisation.ForeColor = clNormalLableColor;
            }

            if (this.txtBpartnerName.Text == "")
            {
                this.lblBpartnerName.ForeColor = clErrorLableColor;
                foundError = true;
            }
            else
            {
                this.lblBpartnerName.ForeColor = clNormalLableColor;
            }

            if (this.intCountryID == -1)
            {
                this.lblBpartnerCountry.ForeColor = clErrorLableColor;
                foundError = true;
            }
            else
            {
                this.lblBpartnerCountry.ForeColor = clNormalLableColor;
            }

            if (this.ntbTIN.Amount.Length != 10 && 
                this.ntbTIN.Amount != "" && 
                this.ntbTIN.Amount != "0")
            {
                this.lblBpartnerTIN.ForeColor = clErrorLableColor;
                foundError = true;
            }
            else
            {
                this.lblBpartnerTIN.ForeColor = clNormalLableColor;
            }

            return foundError;
        }

        private void fillCountryList(string countryID)
        {
            this.cmbBpartnerCountry.Items.Clear();
            triStateBool onlyActiveRecords = triStateBool.yes;
            
            if (countryID != "")
            {
                onlyActiveRecords = triStateBool.ignor;
            }

            this.dtCountryList =
                this.getDatafromDataBase.getC_COUNTRYInfo(null, "", "",
                            "", onlyActiveRecords, triStateBool.ignor, false, "AND");

            int defaultCountryIndex = -1;

            if (countryID != "")
            {
                for (int countryRowCouter = this.dtCountryList.Rows.Count - 1;
                     countryRowCouter >= 0 && defaultCountryIndex == -1;
                     countryRowCouter--)
                {
                    if (this.dtCountryList.Rows[countryRowCouter]["C_COUNTRY_ID"].ToString() == countryID)
                    {
                        defaultCountryIndex = countryRowCouter;
                    }
                    else if (this.dtCountryList.Rows[countryRowCouter]["ISACTIVE"].ToString() != "Y")
                    {
                        this.dtCountryList.Rows.RemoveAt(countryRowCouter);
                    }
                }

                for (int countryRowCouter = defaultCountryIndex - 1;
                     countryRowCouter >= 0;
                     countryRowCouter--)
                {
                    if (this.dtCountryList.Rows[countryRowCouter]["ISACTIVE"].ToString() != "Y")
                    {
                        defaultCountryIndex--;
                        this.dtCountryList.Rows.RemoveAt(countryRowCouter);
                    }
                }
            }

            for (int countryRowCouter = 0;
                countryRowCouter <= this.dtCountryList.Rows.Count - 1;
                countryRowCouter++)
            {                
                this.cmbBpartnerCountry.Items.Add
                    (this.dtCountryList.Rows[countryRowCouter]["NAME"].ToString());                                
            }

            for (int countryRowCouter = 0;
                countryRowCouter <= this.dtCountryList.Rows.Count - 1 && defaultCountryIndex == -1;
                countryRowCouter++)
            {
                if (this.dtCountryList.Rows[countryRowCouter]["ISDEFAULT"].ToString() == "Y")
                {
                    defaultCountryIndex = countryRowCouter;
                    break;
                }
            }


            if (defaultCountryIndex >= 0 &&
                defaultCountryIndex <= this.cmbBpartnerCountry.Items.Count - 1)
            {                
                this.cmbBpartnerCountry.SelectedIndex = defaultCountryIndex;
            }
            else
            {
                if (this.cmbBpartnerCountry.Items.Count > 0)
                {                    
                    this.cmbBpartnerCountry.SelectedIndex = 0;
                }
            }
        }

        private void fillCityList(string cityID)
        {
            this.cmbBpartnerCity.Items.Clear();
            triStateBool onlyActiveRecords = triStateBool.yes;
            
            if (cityID != "")
            {
                onlyActiveRecords = triStateBool.ignor;                
            }

            this.dtCityList =
                this.getDatafromDataBase.getC_CITYInfo(null, "", "",
                            this.intCountryID.ToString(), "",
                            onlyActiveRecords, triStateBool.ignor, false, "AND");

            int defaultCityIndex = -1;

            if (cityID != "")
            {
                for (int cityRowCouter = this.dtCityList.Rows.Count - 1;
                    cityRowCouter >= 0 && defaultCityIndex == -1;
                    cityRowCouter--)
                {
                    if (this.dtCityList.Rows[cityRowCouter]["C_CITY_ID"].ToString() == cityID)
                    {
                        defaultCityIndex = cityRowCouter;
                    }
                    else if (this.dtCityList.Rows[cityRowCouter]["ISACTIVE"].ToString() != "Y")
                    {                        
                        this.dtCityList.Rows.RemoveAt(cityRowCouter);
                    }
                }

                for (int cityRowCouter = defaultCityIndex - 1;
                    cityRowCouter >= 0;
                    cityRowCouter--)
                {
                    if (this.dtCityList.Rows[cityRowCouter]["ISACTIVE"].ToString() != "Y")
                    {
                        defaultCityIndex--;
                        this.dtCityList.Rows.RemoveAt(cityRowCouter);
                    }
                }
            }

            this.cmbBpartnerCity.Items.Add("-- Select City --");            

            for (int cityRowCouter = 0; 
                cityRowCouter <= this.dtCityList.Rows.Count - 1; 
                cityRowCouter++)
            {
                this.cmbBpartnerCity.Items.Add
                    (this.dtCityList.Rows[cityRowCouter]["NAME"].ToString());                
            }           


            for (int cityRowCouter = 0;
                cityRowCouter <= this.dtCityList.Rows.Count - 1 && defaultCityIndex == -1;
                cityRowCouter++)
            {
                if (this.dtCityList.Rows[cityRowCouter]["ISDEFAULT"].ToString() == "Y")
                {
                    defaultCityIndex = cityRowCouter;
                    break;
                }
            }

            if (defaultCityIndex >= 0 &&
                defaultCityIndex <= this.cmbBpartnerCity.Items.Count - 1)
            {                
                this.cmbBpartnerCity.SelectedIndex = defaultCityIndex + 1;
            }
            else
            {
                if (this.cmbBpartnerCity.Items.Count > 0)
                {                    
                    this.cmbBpartnerCity.SelectedIndex = 0;
                }
            }
        }

        private void fillLocalityList(string localityID)
        {            
            this.cmbBpartnerLocality.Items.Clear();
            triStateBool onlyActiveRecords = triStateBool.yes;

            if (localityID != "")
            {
                onlyActiveRecords = triStateBool.ignor;
            }
            
            this.dtLocalityList =
                this.getDatafromDataBase.getC_LOCALITYInfo(null, "", "",
                            "", "", "", onlyActiveRecords, triStateBool.No, false, "AND");
            

            this.cmbBpartnerLocality.Items.Add(" -- Select Sub City --");
            
            int defaultIndex = -1;

            if (localityID != "")
            {
                for (int localityRowCouter = this.dtLocalityList.Rows.Count - 1;
                     localityRowCouter >= 0 && defaultIndex == -1;
                     localityRowCouter--)
                {
                    if (this.dtLocalityList.Rows[localityRowCouter]["C_LOCALITY_ID"].ToString() == localityID)
                    {
                        defaultIndex = localityRowCouter + 1;                        
                    }
                    else if (this.dtLocalityList.Rows[localityRowCouter]["ISACTIVE"].ToString() != "Y")
                    {
                        this.dtLocalityList.Rows.RemoveAt(localityRowCouter);                        
                    }
                }

                for (int localityRowCouter = defaultIndex - 1;
                     localityRowCouter >= 0;
                     localityRowCouter--)
                {
                    if (this.dtLocalityList.Rows[localityRowCouter]["ISACTIVE"].ToString() != "Y")
                    {
                        defaultIndex--;
                        this.dtLocalityList.Rows.RemoveAt(localityRowCouter);
                    }
                }
            }
            
            for (int localityRowCouter = 0;
                localityRowCouter <= this.dtLocalityList.Rows.Count - 1;
                localityRowCouter++)
            {
                this.cmbBpartnerLocality.Items.Add
                    (this.dtLocalityList.Rows[localityRowCouter]["NAME"].ToString());                
            }

            if(defaultIndex > 0 &&
                defaultIndex <= this.cmbBpartnerLocality.Items.Count - 1)
                this.cmbBpartnerLocality.SelectedIndex = defaultIndex;
            else
                this.cmbBpartnerLocality.SelectedIndex = 0;
        }

        private void fillSubLocalityList(string subLocalityID)
        {            
            this.cmbBpartnerSubLocality.Items.Clear();
            triStateBool onlyActiveRecords = triStateBool.yes;

            if (subLocalityID != "")
            {
                onlyActiveRecords = triStateBool.ignor;
            }
            this.dtSubLocalityList =
                this.getDatafromDataBase.getC_SUBLOCALITYInfo(null, "", "",
                                "", "", "", triStateBool.No, onlyActiveRecords, false, "AND");
            

            this.cmbBpartnerSubLocality.Items.Add(" -- Select Kebele --");

            int defaultIndex = -1;

            if (subLocalityID != "")
            {
                for (int subLocalityRowCouter = this.dtSubLocalityList.Rows.Count - 1;
                     subLocalityRowCouter >= 0 && defaultIndex == -1;
                     subLocalityRowCouter--)
                {
                    if (this.dtSubLocalityList.
                        Rows[subLocalityRowCouter]["C_SUBLOCALITY_ID"].ToString() == subLocalityID)
                    {
                        defaultIndex = subLocalityRowCouter + 1;
                    }
                    else if (this.dtSubLocalityList.Rows[subLocalityRowCouter]["ISACTIVE"].ToString() != "Y")
                    {
                        this.dtSubLocalityList.Rows.RemoveAt(subLocalityRowCouter);
                    }
                }
                for (int subLocalityRowCouter = defaultIndex - 1;
                     subLocalityRowCouter >= 0;
                     subLocalityRowCouter--)
                {
                    if (this.dtSubLocalityList.Rows[subLocalityRowCouter]["ISACTIVE"].ToString() != "Y")
                    {
                        defaultIndex--;
                        this.dtSubLocalityList.Rows.RemoveAt(subLocalityRowCouter);
                    }
                }
            }
            

            for (int subLocalityRowCouter = 0;
                subLocalityRowCouter <= this.dtSubLocalityList.Rows.Count - 1;
                subLocalityRowCouter++)
            {
                this.cmbBpartnerSubLocality.Items.Add
                    (this.dtSubLocalityList.Rows[subLocalityRowCouter]["NAME"].ToString());
            }

            if (defaultIndex > 0 &&
                defaultIndex <= this.cmbBpartnerSubLocality.Items.Count - 1)
                this.cmbBpartnerSubLocality.SelectedIndex = defaultIndex;
            else
                this.cmbBpartnerSubLocality.SelectedIndex = 0;
        }
        

        public void frmBpartner_Load(object sender, EventArgs e)
        {
            if (generalResultInformation.currentFormIsReadOnly)
            {
                this.tlsDelete.Visible = false;
                this.tlsNew.Visible = false;
                this.tlsSave.Visible = false;
            }

            this.tlsNew_Click(sender, e);
            this.dtExistingBpartnerInformation =
                       this.getDatafromDataBase.getM_BPARTNERInfo(null,
                               "", "", "", triStateBool.ignor, triStateBool.ignor,
                                   triStateBool.ignor, true, "");

            this.dtgBpartnerGridView.DataSource = 
                this.dtExistingBpartnerInformation;

            this.dtgBpartnerGridView.Columns["M_SHOP_ID"].Visible = false;
            this.dtgBpartnerGridView.Columns["AD_ORG_ID"].Visible = false;
            this.dtgBpartnerGridView.Columns["M_BPARTNER_ID"].Visible = false;
            this.dtgBpartnerGridView.Columns["DESCRIPTION"].Visible = false;
            this.dtgBpartnerGridView.Columns["C_COUNTRY_ID"].Visible = false;
            this.dtgBpartnerGridView.Columns["C_CITY_ID"].Visible = false;
            this.dtgBpartnerGridView.Columns["C_LOCALITY_ID"].Visible = false;
            this.dtgBpartnerGridView.Columns["C_SUBLOCALITY_ID"].Visible = false;
            this.dtgBpartnerGridView.Columns["CREATED"].Visible = false;
            this.dtgBpartnerGridView.Columns["UPDATED"].Visible = false;
            this.dtgBpartnerGridView.Columns["CREATEDBY"].Visible = false;
            this.dtgBpartnerGridView.Columns["UPDATEDBY"].Visible = false;

            this.dtAccessableOrgInformation =
                this.getDataAccordingToRule.
                    getCurrentUserAccessableOrganisation(accessLevel.ReadWite,
                        triStateBool.ignor, true);
            
            this.setUpOrganisations();
        }
        
        private void tlsNew_Click(object sender, EventArgs e)
        {
            this.intBPartnerID = 0;

            this.txtBpartnerName.Text = "";
            this.txtBpartnerDescription.Text = "";

            this.ckBpartnerIsActive.Checked = true;
            this.ckBpartnerIsCustomer.Checked = true;
            this.ckBpartnerIsVendor.Checked = false;

            this.lblBpartnerName.ForeColor = clNormalLableColor;
            this.lblBpartnerDescription.ForeColor = clNormalLableColor;
            this.lblBpartnerTIN.ForeColor = clNormalLableColor;
            this.lblBpartnerCountry.ForeColor = clNormalLableColor;

            this.ckBpartnerIsActive.ForeColor = clNormalLableColor;
            this.ckBpartnerIsCustomer.ForeColor = clNormalLableColor;
            this.ckBpartnerIsVendor.ForeColor = clNormalLableColor;

            this.txtBpartnerAdd1.Text = "";
            this.txtBpartnerAdd2.Text = "";
            this.txtBpartnerAdd3.Text = "";
            this.txtBpartnerAdd4.Text = "";

            this.txtBpartnerCityName.Text = "";
            this.txtBpartnerLocalityName.Text = "";

            this.txtBpartnerPhone.Text = "";
            this.txtBpartnerPhone2.Text = "";
            this.txtBpartnerFax.Text = "";
            this.txtBpartnerPostal.Text = "";

            this.ntbTIN.Amount = "";
            this.ntbVATRegNo.Amount = "";

            this.fillCountryList("");

            if (generalResultInformation.currentTrx == transactionType.InventoryOut)
            {
                this.ckBpartnerIsCustomer.Checked = true;
                this.ckBpartnerIsVendor.Checked = false;
            }

            if (generalResultInformation.currentTrx == transactionType.InventoryIn)
            {
                this.ckBpartnerIsCustomer.Checked = false;
                this.ckBpartnerIsVendor.Checked = true;
            }            
        }

        private void tlsSave_Click(object sender, EventArgs e)
        {
            string stTypeOfChange = "INSERT";
            if (this.checkForCompleteNewRecord())
            {
                MessageBox.Show("Please complete the missing form element before proceeding.",
                    "SRP SAVE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }           

            this.lblBpartnerName.ForeColor = clNormalLableColor;

            this.dtNewBpartnerInformation =
                this.getDatafromDataBase.getM_BPARTNERInfo(null,
                            "", "", "", triStateBool.ignor,triStateBool.ignor,
                                triStateBool.ignor, true, "");

            DataRow drNewBpartner = this.dtNewBpartnerInformation.NewRow();

            if (this.intBPartnerID != 0)
            {
                drNewBpartner["M_BPARTNER_ID"] = this.intBPartnerID;
                stTypeOfChange = "UPDATE";
            }
            else
                stTypeOfChange = "INSERT";

            drNewBpartner["M_SHOP_ID"] = this.stringShopID;
            drNewBpartner["AD_ORG_ID"] = this.stOrganisationID;
            drNewBpartner["NAME"] = this.txtBpartnerName.Text;
            drNewBpartner["NAME2"] = this.txtBpartnerName2.Text;
            drNewBpartner["DESCRIPTION"] = this.txtBpartnerDescription.Text;

            if (this.ckBpartnerIsActive.Checked)
                drNewBpartner["ISACTIVE"] = "Y";
            else
                drNewBpartner["ISACTIVE"] = "N";

            if (this.ckBpartnerIsCustomer.Checked)
                drNewBpartner["ISCUSTOMER"] = "Y";
            else
                drNewBpartner["ISCUSTOMER"] = "N";

            if (this.ckBpartnerIsVendor.Checked)
                drNewBpartner["ISVENDOR"] = "Y";
            else
                drNewBpartner["ISVENDOR"] = "N";

            if(this.ntbTIN.Amount != "" && 
                this.ntbTIN.Amount != "0")
                drNewBpartner["TIN"] = this.ntbTIN.Amount;

            if (this.ntbVATRegNo.Amount != "" &&
                this.ntbVATRegNo.Amount != "0")
                drNewBpartner["VATREGNO"] = this.ntbVATRegNo.Amount;

            drNewBpartner["ADDRESS1"] = this.txtBpartnerAdd1.Text;
            drNewBpartner["ADDRESS2"] = this.txtBpartnerAdd2.Text;
            drNewBpartner["ADDRESS3"] = this.txtBpartnerAdd3.Text;
            drNewBpartner["ADDRESS4"] = this.txtBpartnerAdd4.Text;

            if(this.intCityID != -1)
                drNewBpartner["C_CITY_ID"] = this.intCityID;

            drNewBpartner["CITYNAME"] = this.txtBpartnerCityName.Text;

            if (this.intLocalityID != -1)
                drNewBpartner["C_LOCALITY_ID"] = this.intLocalityID;

            drNewBpartner["LOCALITYNAME"] = this.txtBpartnerLocalityName.Text;

            if (this.intSubLocalityID != -1)
                drNewBpartner["C_SUBLOCALITY_ID"] = this.intSubLocalityID;

            if (this.intCountryID != -1)
                drNewBpartner["C_COUNTRY_ID"] = this.intCountryID;

            drNewBpartner["POSTAL"] = this.txtBpartnerPostal.Text;
            drNewBpartner["PHONE"] = this.txtBpartnerPhone.Text;
            drNewBpartner["PHONE2"] = this.txtBpartnerPhone2.Text;
            drNewBpartner["FAX"] = this.txtBpartnerFax.Text;

            this.dtNewBpartnerInformation.Rows.Add(drNewBpartner);

            string[] primaryKeySepartor = { " <(", ")>||" };
            string[] primaryKey =
                this.getDatafromDataBase.changeDataBaseTableData
                    (this.dtNewBpartnerInformation.Copy(), "M_BPARTNER", stTypeOfChange)[0]
                    .Split(primaryKeySepartor, StringSplitOptions.RemoveEmptyEntries);

            if (primaryKey.Length > 1 && stTypeOfChange == "INSERT")
            {
                this.intBPartnerID = int.Parse(primaryKey[1]);
                this.dtExistingBpartnerInformation =
                    this.getDatafromDataBase.getM_BPARTNERInfo(null,
                            "", "", "", triStateBool.ignor, triStateBool.ignor,
                                triStateBool.ignor, false, "");
                this.dtgBpartnerGridView.DataSource = this.dtExistingBpartnerInformation;
                if (this.dtExistingBpartnerInformation.Rows.Count > 0)
                    this.dtgBpartnerGridView.
                        Rows[this.dtExistingBpartnerInformation.Rows.Count - 1].Selected = true;
            }

            if (generalResultInformation.currentTrx == transactionType.InventoryIn ||
                generalResultInformation.currentTrx == transactionType.InventoryOut)
            {
                generalResultInformation.stNewCustomerId = this.intBPartnerID.ToString();
                this.Parent.Dispose();
            }  
        }

        private void tlsSearch_Click(object sender, EventArgs e)
        {
            this.dtExistingBpartnerInformation.Rows.Clear();
            this.tlsNew_Click(sender, e);
            frmSearchBpartner frmBpartnerSrchResult = new frmSearchBpartner();
            generalResultInformation.searchResult.Clear();
            frmBpartnerSrchResult.ShowDialog();
            if (generalResultInformation.searchResult.Rows.Count > 0)
                this.dtExistingBpartnerInformation =
                    generalResultInformation.searchResult.Copy();
                        
            this.dtgBpartnerGridView.DataSource = this.dtExistingBpartnerInformation;
            if (this.dtExistingBpartnerInformation.Rows.Count > 0)
                this.dtgBpartnerGridView.Rows[0].Selected = true;

            this.dtgBpartnerGridView.Columns["M_BPARTNER_ID"].Visible = false;
            this.dtgBpartnerGridView.Columns["CREATED"].Visible = false;
            this.dtgBpartnerGridView.Columns["UPDATED"].Visible = false;
        }


        private void dtgBpartnerGridView_SelectionChanged(object sender, EventArgs e)
        {
            this.dtgBpartnerClicked = true;

            if (this.dtgBpartnerGridView.SelectedRows.Count < 1)
            {
                return;
            }
            int selectedBparnterIndex =
                this.dtgBpartnerGridView.SelectedRows[0].Index;
            
            /*
            if (this.dtExistingBpartnerInformation.Rows["M_BPARTNER_ID"]
                    [this.dtgBpartnerGridView.SelectedRows[0].Index].ToString() =
                    this.dtgBpartnerGridView.SelectedRows[0].Cells["M_BPARTNER_ID"].Value.ToString())
                selectedBparnterIndex = rowCounter;
            else
            {
                for (int rowCounter = 0; rowCounter <= this.dtExistingBpartnerInformation.Rows.Count - 1; rowCounter++)
                {
                    if (this.dtExistingBpartnerInformation.Rows["M_BPARTNER_ID"][rowCounter].ToString() =
                        this.dtgBpartnerGridView.SelectedRows[0].Cells["M_BPARTNER_ID"].Value.ToString())
                        selectedBparnterIndex = rowCounter;
                }
            }
            */

            this.stOrganisationID =
                this.dtgBpartnerGridView.Rows[selectedBparnterIndex].
                        Cells["AD_ORG_ID"].Value.ToString();

            bool organisationIsReadWrite = false;
            int selectedOrgIndex = -1;

            for (int rowCounter = 0; 
                    rowCounter <= this.dtAccessableOrgInformation.Rows.Count - 1; 
                    rowCounter++)
            {
                if (this.dtAccessableOrgInformation.
                        Rows[rowCounter]["AD_ORG_ID"].ToString() == this.stOrganisationID)
                {
                    organisationIsReadWrite = true;
                    selectedOrgIndex = rowCounter;
                    break;
                }
            }

            if (organisationIsReadWrite)
            {
                if (this.cmbOrganisation.Items.Count <= 1)
                {
                    this.setUpOrganisations();
                }
                this.cmbOrganisation.SelectedIndex = selectedOrgIndex;
            }
            else
            {
                this.cmbOrganisation.Items.Clear();
                DataTable dtOrgInformation =
                    this.getDatafromDataBase.getAD_ORGInfo(null, "",
                        this.stOrganisationID, "", triStateBool.ignor, false, "AND");
                if (this.getDatafromDataBase.checkIfTableContainesData(dtOrgInformation))
                {
                    this.cmbOrganisation.Items.Add(dtOrgInformation.Rows[0]["NAME"].ToString());
                    this.cmbOrganisation.SelectedIndex = 0;
                }
                else
                {
                    this.stOrganisationID = "";
                }
            }

            this.intBPartnerID =
                int.Parse(this.dtgBpartnerGridView.Rows[selectedBparnterIndex].
                        Cells["M_BPARTNER_ID"].Value.ToString());
            this.txtBpartnerName.Text =
                this.dtgBpartnerGridView.Rows[selectedBparnterIndex].Cells["NAME"].Value.ToString();

            this.txtBpartnerName2.Text =
                this.dtgBpartnerGridView.Rows[selectedBparnterIndex].Cells["NAME2"].Value.ToString();

            this.txtBpartnerDescription.Text =
                this.dtgBpartnerGridView.Rows[selectedBparnterIndex].Cells["DESCRIPTION"].Value.ToString();

            if (this.dtgBpartnerGridView.Rows[selectedBparnterIndex].
                    Cells["ISACTIVE"].Value.ToString() == "Y")
                this.ckBpartnerIsActive.Checked = true;
            else
                this.ckBpartnerIsActive.Checked = false;

            if (this.dtgBpartnerGridView.Rows[selectedBparnterIndex].
                    Cells["ISVENDOR"].Value.ToString() == "Y")
                this.ckBpartnerIsVendor.Checked = true;
            else
                this.ckBpartnerIsVendor.Checked = false;

            if (this.dtgBpartnerGridView.Rows[selectedBparnterIndex].
                    Cells["ISCUSTOMER"].Value.ToString() == "Y")
                this.ckBpartnerIsCustomer.Checked = true;
            else
                this.ckBpartnerIsCustomer.Checked = false;

            this.ntbTIN.Amount =
                this.dtgBpartnerGridView.Rows[selectedBparnterIndex].Cells["TIN"].Value.ToString();

            this.ntbVATRegNo.Amount =
                this.dtgBpartnerGridView.Rows[selectedBparnterIndex].Cells["VATREGNO"].Value.ToString();

            this.txtBpartnerAdd1.Text =
                this.dtgBpartnerGridView.Rows[selectedBparnterIndex].Cells["ADDRESS1"].Value.ToString();
            this.txtBpartnerAdd2.Text =
                this.dtgBpartnerGridView.Rows[selectedBparnterIndex].Cells["ADDRESS2"].Value.ToString();
            this.txtBpartnerAdd3.Text =
                this.dtgBpartnerGridView.Rows[selectedBparnterIndex].Cells["ADDRESS3"].Value.ToString();
            this.txtBpartnerAdd4.Text =
                this.dtgBpartnerGridView.Rows[selectedBparnterIndex].Cells["ADDRESS4"].Value.ToString();

            this.txtBpartnerLocalityName.Text =
                this.dtgBpartnerGridView.Rows[selectedBparnterIndex].Cells["LOCALITYNAME"].Value.ToString();
            this.txtBpartnerCityName.Text =
                this.dtgBpartnerGridView.Rows[selectedBparnterIndex].Cells["CITYNAME"].Value.ToString();


            this.txtBpartnerPhone.Text =
                this.dtgBpartnerGridView.Rows[selectedBparnterIndex].Cells["PHONE"].Value.ToString();
            this.txtBpartnerPhone2.Text =
                this.dtgBpartnerGridView.Rows[selectedBparnterIndex].Cells["PHONE2"].Value.ToString();
            this.txtBpartnerFax.Text =
                this.dtgBpartnerGridView.Rows[selectedBparnterIndex].Cells["FAX"].Value.ToString();
            this.txtBpartnerPostal.Text =
                this.dtgBpartnerGridView.Rows[selectedBparnterIndex].Cells["POSTAL"].Value.ToString();


            
            if (this.dtgBpartnerGridView.Rows[selectedBparnterIndex].
                        Cells["C_COUNTRY_ID"].Value.ToString() != "")
            {
                this.intCountryID =
                    int.Parse(
                        this.dtgBpartnerGridView.Rows[selectedBparnterIndex].
                                    Cells["C_COUNTRY_ID"].Value.ToString());
                this.fillCountryList(this.intCountryID.ToString());
            }
            else
            {
                this.intCountryID = -1;
                this.fillCountryList("");
            }


            if (this.dtgBpartnerGridView.Rows[selectedBparnterIndex].
                        Cells["C_CITY_ID"].Value.ToString() != "")
            {
                this.intCityID =
                    int.Parse(
                        this.dtgBpartnerGridView.Rows[selectedBparnterIndex].
                                    Cells["C_CITY_ID"].Value.ToString());
                this.fillCityList(this.intCityID.ToString());
            }
            else
            {
                this.intCityID = -1;
                this.fillCityList("");
            }


            if (this.dtgBpartnerGridView.Rows[selectedBparnterIndex].
                        Cells["C_LOCALITY_ID"].Value.ToString() != "")
            {
                this.intLocalityID =
                    int.Parse(
                        this.dtgBpartnerGridView.Rows[selectedBparnterIndex].
                                    Cells["C_LOCALITY_ID"].Value.ToString());
                this.fillLocalityList(this.intLocalityID.ToString());
            }
            else
            {
                this.intLocalityID = -1;
                this.fillLocalityList("");
            }
                        
            if (this.dtgBpartnerGridView.Rows[selectedBparnterIndex].
                        Cells["C_SUBLOCALITY_ID"].Value.ToString() != "")
            {
                this.intSubLocalityID =
                    int.Parse(
                        this.dtgBpartnerGridView.Rows[selectedBparnterIndex].
                                    Cells["C_SUBLOCALITY_ID"].Value.ToString());
                this.fillSubLocalityList(this.intSubLocalityID.ToString());
            }
            else
            {                
                this.fillSubLocalityList("");
            }

            this.dtgBpartnerClicked = false;
            

            this.txtBpartnerName.Enabled = organisationIsReadWrite;
            this.txtBpartnerName2.Enabled = organisationIsReadWrite;
            this.txtBpartnerDescription.Enabled = organisationIsReadWrite;
            this.ckBpartnerIsActive.Enabled = organisationIsReadWrite;
            this.ckBpartnerIsVendor.Enabled = organisationIsReadWrite;
            this.ckBpartnerIsCustomer.Enabled = organisationIsReadWrite;
            this.ntbTIN.Enabled = organisationIsReadWrite;
            this.ntbVATRegNo.Enabled = organisationIsReadWrite;
            this.txtBpartnerAdd1.Enabled = organisationIsReadWrite;
            this.txtBpartnerAdd2.Enabled = organisationIsReadWrite;
            this.txtBpartnerAdd3.Enabled = organisationIsReadWrite;
            this.txtBpartnerAdd4.Enabled = organisationIsReadWrite;
            this.txtBpartnerLocalityName.Enabled = organisationIsReadWrite;
            this.txtBpartnerCityName.Enabled = organisationIsReadWrite;

            this.txtBpartnerPhone.Enabled = organisationIsReadWrite;
            this.txtBpartnerPhone2.Enabled = organisationIsReadWrite;
            this.txtBpartnerFax.Enabled = organisationIsReadWrite;
            this.txtBpartnerPostal.Enabled = organisationIsReadWrite;

            this.cmbOrganisation.Enabled = organisationIsReadWrite;
            this.cmbBpartnerCountry.Enabled = organisationIsReadWrite;
            this.cmbBpartnerCity.Enabled = organisationIsReadWrite;
            this.cmbBpartnerLocality.Enabled = organisationIsReadWrite;
            this.cmbBpartnerSubLocality.Enabled = organisationIsReadWrite;
        }

        private void dtgBpartnerGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (generalResultInformation.currentTrx == transactionType.InventoryIn ||
                generalResultInformation.currentTrx == transactionType.InventoryOut)
            {
                generalResultInformation.stNewCustomerId = 
                    this.intBPartnerID.ToString();
                this.Parent.Dispose();
            }
        }

        
        private void cmbBpartnerCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dtgBpartnerClicked)
                return;

            if (this.cmbBpartnerCountry.SelectedIndex >= 0 &&
                this.cmbBpartnerCountry.SelectedIndex <= this.dtCountryList.Rows.Count - 1)
            {
                this.intCountryID =
                    int.Parse(
                        this.dtCountryList.Rows
                            [this.cmbBpartnerCountry.SelectedIndex]["C_COUNTRY_ID"].ToString()
                            );
            }
            else
                this.intCountryID = -1;

            this.fillCityList("");

        }
        
        private void cmbBpartnerCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dtgBpartnerClicked)
                return;

            if (this.cmbBpartnerCity.SelectedIndex > 0 &&
                this.cmbBpartnerCity.SelectedIndex <= this.dtCityList.Rows.Count)
            {
                this.intCityID =
                    int.Parse(
                        this.dtCityList.Rows
                            [this.cmbBpartnerCity.SelectedIndex-1]["C_CITY_ID"].ToString()
                            );
            }
            else
                this.intCityID = -1;

            this.fillLocalityList("");
        }

        private void cmbBpartnerLocality_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dtgBpartnerClicked)
                return;

            if (this.cmbBpartnerLocality.SelectedIndex > 0 &&
                this.cmbBpartnerLocality.SelectedIndex <= this.dtLocalityList.Rows.Count)
            {
                this.intLocalityID =
                    int.Parse(
                        this.dtLocalityList.Rows
                            [this.cmbBpartnerLocality.SelectedIndex-1]["C_LOCALITY_ID"].ToString()
                            );
            }
            else
                this.intLocalityID = -1;

            this.fillSubLocalityList("");
        }

        private void cmbBpartnerSubLocality_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dtgBpartnerClicked)
                return;

            if (this.cmbBpartnerSubLocality.SelectedIndex > 0 &&
                this.cmbBpartnerSubLocality.SelectedIndex <= this.dtSubLocalityList.Rows.Count)
            {
                this.intSubLocalityID =
                    int.Parse(
                        this.dtSubLocalityList.Rows
                            [this.cmbBpartnerSubLocality.SelectedIndex-1]["C_SUBLOCALITY_ID"].ToString()
                            );
            }
            else
                this.intSubLocalityID = -1;            
        }

       

        private void cmbOrganisation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbOrganisation.SelectedIndex >= 0 &&
                this.cmbOrganisation.SelectedIndex <=
                this.dtAccessableOrgInformation.Rows.Count - 1)
                this.stOrganisationID =
                   this.dtAccessableOrgInformation.
                        Rows[this.cmbOrganisation.SelectedIndex]["AD_ORG_ID"].ToString();
            else
                this.stOrganisationID = "";
        }

        private void cmbOrganisation_DropDown(object sender, EventArgs e)
        {
            this.setUpOrganisations();
        }
        
        
    }
}
