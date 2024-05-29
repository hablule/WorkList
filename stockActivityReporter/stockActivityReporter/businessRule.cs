using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using dbConnection;

namespace stockActivityReporter
{


    class businessRule
    {

        private dataBuilder getDbInformation = new dataBuilder();
        dbConnection.businessRule dbConnectionRule = new dbConnection.businessRule();
                

        public DataTable getProducts(bool onlyActive, triStateBool isSold, triStateBool isDiscontinued,
            bool IncludeSummaryProducts, string ProductName, string AD_ORG_ID,
            bool includeVisibleToAllOrganisation)
        {
            DataTable Products = new DataTable();
            Products.Columns.Add("Field");
            Products.Columns.Add("Criterion");
            Products.Columns.Add("Value");

            string[] organisation = { AD_ORG_ID };
            
            if (!IncludeSummaryProducts)
            {
                DataRow dt = Products.NewRow();
                dt["Field"] = "ISSUMMARY";
                dt["Criterion"] = "=";
                dt["Value"] = "N";
                Products.Rows.Add(dt);
            }

            if (isSold == triStateBool.yes)
            {
                DataRow dt = Products.NewRow();
                dt["Field"] = "ISSOLD";
                dt["Criterion"] = "=";
                dt["Value"] = "Y";
                Products.Rows.Add(dt);
            }
            else if (isSold == triStateBool.no)
            {
                DataRow dt = Products.NewRow();
                dt["Field"] = "ISSOLD";
                dt["Criterion"] = "=";
                dt["Value"] = "N";
                Products.Rows.Add(dt);
            }

            if (isDiscontinued == triStateBool.yes)
            {
                DataRow dt = Products.NewRow();
                dt["Field"] = "DISCONTINUED";
                dt["Criterion"] = "=";
                dt["Value"] = "Y";
                Products.Rows.Add(dt);
            }
            else if (isDiscontinued == triStateBool.no)
            {
                DataRow dt = Products.NewRow();
                dt["Field"] = "DISCONTINUED";
                dt["Criterion"] = "=";
                dt["Value"] = "N";
                Products.Rows.Add(dt);
            }

            DataRow dt2 = Products.NewRow();
            dt2["Field"] = "" + dbSettingInformationHandler.upperCaseFunction + "(NAME)";
            dt2["Criterion"] = "like";
            dt2["Value"] = "%" + ProductName.ToUpper() + "%";
            Products.Rows.Add(dt2);

            Products =
                getDbInformation.getM_PRODUCTInfo(Products, "AND", "", onlyActive, false, "AND");
                       

            if (!getDbInformation.checkIfTableContainesData(Products))
            {
                return Products;
            }
            //remove unneccessary fields.
            for (int columnCounter = Products.Columns.Count - 1;
                columnCounter >= 0; columnCounter--)
            {
                if (Products.Columns[columnCounter].ColumnName != "M_PRODUCT_ID" &&
                    Products.Columns[columnCounter].ColumnName != "VALUE" &&
                    Products.Columns[columnCounter].ColumnName != "NAME" &&
                    Products.Columns[columnCounter].ColumnName != "C_UOM_ID" &&
                    Products.Columns[columnCounter].ColumnName != "M_PRODUCT_CATEGORY_ID")
                    Products.Columns.Remove(Products.Columns[columnCounter].ColumnName);
            }

            //Get Proudct's Catagory Name
            Products.Columns.Add("Category");

            for (int rowCounter = Products.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                Products.Rows[rowCounter]["Category"] =
                    getDbInformation.getM_PRODUCT_CATEGORYInfo(null, "", Products.Rows[rowCounter]["M_PRODUCT_CATEGORY_ID"].ToString(),
                                    false, false, "AND").Rows[0]["NAME"].ToString();

                if (Products.Rows[rowCounter]["Category"].ToString() == "")
                    Products.Rows.RemoveAt(rowCounter);
            }

            //Get Product's UOM Name
            Products.Columns.Add("UOM");

            for (int rowCounter = Products.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                Products.Rows[rowCounter]["UOM"] =
                    getDbInformation.getC_UOMInfo(null, "", Products.Rows[rowCounter]["C_UOM_ID"].ToString(),
                                    false, false, "AND").Rows[0]["NAME"].ToString();

                if (Products.Rows[rowCounter]["UOM"].ToString() == "")
                    Products.Rows.RemoveAt(rowCounter);
            }

            return Products;
        }


        public bool validateUser(string userName, string passWord)
        {
            DataTable userInfo = new DataTable();

            if (generalResultInformation.useLDAPAuthentication)
            {
                LDAPConnection authenticate = new LDAPConnection();

                userInfo =
                    this.getDbInformation.getAD_USERInfo(null, "", "", userName, "", true, false, "AND");

                if (!getDbInformation.checkIfTableContainesData(userInfo))
                {
                    return false;
                }

                if (userInfo.Rows.Count != 1)
                {
                    return false;
                }

                if (!authenticate.validateUser(userName, passWord))
                {
                    return false;
                }
            }
            else
            {
                if (dbSettingInformationHandler.DataBaseType == "MySql")
                {
                    MD5 md5Hasher = MD5.Create();
                    byte[] data =
                        md5Hasher.ComputeHash(Encoding.Default.GetBytes(passWord));

                    StringBuilder sBuilder = new StringBuilder();

                    for (int i = 0; i < data.Length; i++)
                    {
                        sBuilder.Append(data[i].ToString("x2"));
                    }

                    userInfo =
                        getDbInformation.getAD_USERInfo(null, "AND", "", userName,
                                sBuilder.ToString(), true, false, "AND");
                }
                else
                {
                    userInfo =
                        getDbInformation.getAD_USERInfo(null, "AND", "", userName,
                                passWord, true, false, "AND"); 
                }

                if (!getDbInformation.checkIfTableContainesData(userInfo) ||
                    userInfo.Rows.Count != 1)
                {
                    return false;
                }
            }

            userInfo.Dispose();
            return true;

        }
        
        public bool userCanModifySettings(string AD_USER_ID)
        {
            DataTable criteriaTable = new DataTable();
            DataTable userRoleResult = new DataTable();

            string[] allowedRoles = new string[] { "1000000", "351000003", "0" };

            criteriaTable.Columns.Add("Field");
            criteriaTable.Columns.Add("Criterion");
            criteriaTable.Columns.Add("Value");

            for (int counter = 0; counter <= allowedRoles.Length - 1; counter++)
            {
                DataRow criteriaValue = criteriaTable.NewRow();

                criteriaValue["Field"] = "AD_ROLE_ID";
                criteriaValue["Criterion"] = "=";
                criteriaValue["Value"] = allowedRoles[counter];
                criteriaTable.Rows.Add(criteriaValue);
            }

            userRoleResult = this.getDbInformation.getAD_USER_ROLESInfo(criteriaTable, "OR", AD_USER_ID, "", true, false, "AND");

            return this.getDbInformation.checkIfTableContainesData(userRoleResult);
        }
    
    }
}
