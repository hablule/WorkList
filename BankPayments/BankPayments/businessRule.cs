using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using dbConnection;

namespace BankPayments
{
    class businessRule
    {
        dataBuilder getDbInfo = new dataBuilder();

        public DataTable buildOrganisationSelectionCriteria(string[] _AD_ORG_ID,
            bool includeVisibleToAllOrganisation)
        {
            DataTable criteriaTable = new DataTable();
            criteriaTable.Columns.Add("Field");
            criteriaTable.Columns.Add("Criterion");
            criteriaTable.Columns.Add("Value");

            foreach (string organisation in _AD_ORG_ID)
            {
                if (organisation == null || organisation == "")
                    continue;
                DataRow dt = criteriaTable.NewRow();
                dt["Field"] = "AD_ORG_ID";
                dt["Criterion"] = "=";
                dt["Value"] = organisation;
                criteriaTable.Rows.Add(dt);
            }

            if (includeVisibleToAllOrganisation)
            {
                DataRow dt = criteriaTable.NewRow();
                dt["Field"] = "AD_ORG_ID";
                dt["Criterion"] = "=";
                dt["Value"] = generalResultInformation.allOrganisationRepresentativeKey;
                criteriaTable.Rows.Add(dt);
            }
            return criteriaTable;
        }


        public DataTable authenticateUser(string userName, string passWord)
        {
            DataTable userInfo = new DataTable();

            if (generalResultInformation.useLDAPAuthentication)
            {
                LDAPConnection authenticate = new LDAPConnection();

                userInfo =
                    this.getDbInfo.getAD_USERInfo(null, "", "", "", "", userName, true, false, "AND");

                if (!getDbInfo.checkIfTableContainesData(userInfo))
                {
                    return new DataTable();
                }

                if (userInfo.Rows.Count != 1)
                {
                    return new DataTable();
                }

                if (!authenticate.validateUser(userName, passWord))
                {
                    return new DataTable();
                }

                return userInfo;
            }
            else
            {
                userInfo =
                    this.getDbInfo.getAD_USERInfo(null, "", "", userName, passWord, "", true, false, "AND");

                if (!getDbInfo.checkIfTableContainesData(userInfo))
                {
                    return new DataTable();
                }

                if (userInfo.Rows.Count != 1)
                {
                    return new DataTable();
                }

                return userInfo;

            }
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

            userRoleResult = this.getDbInfo.getAD_USER_ROLESInfo(criteriaTable, "OR", AD_USER_ID, "", true, false, "AND");

            return this.getDbInfo.checkIfTableContainesData(userRoleResult);
        }
    }
}
