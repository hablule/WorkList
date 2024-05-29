using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CryptoXML;
using System.IO;

namespace BuySimple
{
    class businessRule
    {

        dataBuilder getDataFromDb = new dataBuilder();

        ctlNumberTextBox numberTextbox = new ctlNumberTextBox();
        

        public bool translateCharacterToBool(string _char)
        {
            if (_char == "Y")
                return true;
            else
                return false;
        }

        public string translateBoolToCharacter(bool _boolean)
        {
            if (_boolean)
                return "Y";
            else
                return "N";
        }

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

        public DataTable generatePaymentSource(bool onlyActiveRecords)
        {
            DataTable allBankAccounts =
                this.getDataFromDb.getC_BANKACCOUNT(null, "", "", "", "", "", "",
                onlyActiveRecords, false, "AND");

            allBankAccounts.Columns.Add("Main Source");
            allBankAccounts.Columns.Add("IS BANK ACCOUNT",Type.GetType("System.Boolean"));
            

            for (int rowCounter = allBankAccounts.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                allBankAccounts.Rows[rowCounter]["IS BANK ACCOUNT"] = true;
                allBankAccounts.Rows[rowCounter]["Main Source"] = 
                    this.getDataFromDb.getC_BANK(null,"","",
                                        allBankAccounts.Rows[rowCounter]["C_BANK_ID"].ToString(),
                                        "", onlyActiveRecords, false, "AND").Rows[0]["NAME"].ToString();
            }
            allBankAccounts.Columns["C_BANKACCOUNT_ID"].ColumnName = "SOURCE_ID";
            allBankAccounts.Columns["ACCOUNTNO"].ColumnName = "NAME";

            DataTable allCashBooks =
                this.getDataFromDb.getC_CASHBOOKInfo(null, "", "", "", "", onlyActiveRecords, false, "AND");
            allCashBooks.Columns.Add("IS BANK ACCOUNT", Type.GetType("System.Boolean"));

            for (int rowCounter = allCashBooks.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                allCashBooks.Rows[rowCounter]["IS BANK ACCOUNT"] = false;                
            }
            allCashBooks.Columns["C_CASHBOOK_ID"].ColumnName = "SOURCE_ID";
            DataTable paymentSource = this.getDataFromDb.mergeTables(allBankAccounts, allCashBooks, "", false);
            for (int columnCounter = paymentSource.Columns.Count - 1;
                columnCounter >= 0; columnCounter--)
            {
                if (paymentSource.Columns[columnCounter].ColumnName != "NAME" &&
                    paymentSource.Columns[columnCounter].ColumnName != "IS BANK ACCOUNT" &&
                    paymentSource.Columns[columnCounter].ColumnName != "Main Source" &&
                    paymentSource.Columns[columnCounter].ColumnName != "SOURCE_ID")
                    paymentSource.Columns.RemoveAt(columnCounter);
            }
            return paymentSource;
        }

        public DataTable generatePaymentReason(bool onlyActiveRecords)
        {
            DataTable chargesForOrganisation =
                this.getDataFromDb.getC_CHARGEInfo(null, "",
                            generalResultInformation.organiztionId, "", "", onlyActiveRecords, false, "AND");
            chargesForOrganisation.Columns["C_CHARGE_ID"].ColumnName = "REASON_ID";
            chargesForOrganisation.Columns.Add("IS A COST", Type.GetType("System.Boolean"));

            for (int rowCounter = chargesForOrganisation.Rows.Count - 1;
               rowCounter >= 0; rowCounter--)
            {
                chargesForOrganisation.Rows[rowCounter]["IS A COST"] = true;
            }

            DataTable purchaseTaxForOrganisation =
                this.getDataFromDb.getC_TAXInfo(null, "",
                            generalResultInformation.organiztionId, "", "", "", 
                            onlyActiveRecords, triaStateBool.no, triaStateBool.no, false, "AND");

            purchaseTaxForOrganisation.Columns["C_TAX_ID"].ColumnName = "REASON_ID";
            purchaseTaxForOrganisation.Columns.Add("IS A COST", Type.GetType("System.Boolean"));

            for (int rowCounter = purchaseTaxForOrganisation.Rows.Count - 1;
               rowCounter >= 0; rowCounter--)
            {
                if (DateTime.Compare(DateTime.Today, Convert.
                        ToDateTime(purchaseTaxForOrganisation.Rows[rowCounter]["VALIDFROM"])) < 0)
                {
                    purchaseTaxForOrganisation.Rows.RemoveAt(rowCounter);
                    continue;
                }
                purchaseTaxForOrganisation.Rows[rowCounter]["IS A COST"] = false;
            }

            DataTable paymentReason =
                this.getDataFromDb.mergeTables(chargesForOrganisation, purchaseTaxForOrganisation, "", false);

            for (int columnCounter = paymentReason.Columns.Count - 1;
                columnCounter >= 0; columnCounter--)
            {
                if (paymentReason.Columns[columnCounter].ColumnName != "NAME" &&
                    paymentReason.Columns[columnCounter].ColumnName != "IS A COST" &&
                    paymentReason.Columns[columnCounter].ColumnName != "REASON_ID")
                    paymentReason.Columns.RemoveAt(columnCounter);
            }
            return paymentReason;
        }

        public DataTable getPaymentRecordAccordingToCriterion(DataTable criterionTable,
            bool getRecordThatFullifillAllOrAnyCriterion)
        {
            string logicalConnector = "OR";
            if (!getRecordThatFullifillAllOrAnyCriterion)
                logicalConnector = "AND";

            DataTable resultingPayment =
                this.getDataFromDb.getPM_C_PURCHASEPAYMENTInfo(criterionTable, logicalConnector, 
                                generalResultInformation.organiztionId, "", "", "", "",
                                "", "", "", "", "", "", triaStateBool.Ignor,
                                triaStateBool.Ignor, triaStateBool.Ignor,
                                triaStateBool.Ignor, triaStateBool.Ignor, false, "AND");

            resultingPayment.Columns.Add("ACTIVE", Type.GetType("System.Boolean"));
            resultingPayment.Columns.Add("ESTIMATE", Type.GetType("System.Boolean"));
            resultingPayment.Columns.Add("DISTRIBUTED", Type.GetType("System.Boolean"));
            resultingPayment.Columns.Add("IS A BANK", Type.GetType("System.Boolean"));
            resultingPayment.Columns.Add("IS A COST", Type.GetType("System.Boolean"));
            resultingPayment.Columns.Add("COST CLOSED", Type.GetType("System.Boolean"));
            resultingPayment.Columns.Add("VENDOR");
            resultingPayment.Columns.Add("AMOUNT", Type.GetType("System.Decimal"));
            resultingPayment.Columns.Add("PAYED FROM");
            resultingPayment.Columns.Add("PAYED FOR");
            resultingPayment.Columns.Add("ORDER");
            resultingPayment.Columns.Add("INVOICE");


            resultingPayment.Columns["PAYMENTTYPE"].ColumnName = "PAYMENT TYPE";
            

            for (int rowCounter = resultingPayment.Rows.Count - 1; 
                rowCounter >= 0; rowCounter--)
            {
                resultingPayment.Rows[rowCounter]["INVOICE"] =
                    this.getDataFromDb.getC_INVOICEInfo
                            (null, "", generalResultInformation.organiztionId,
                                     resultingPayment.Rows[rowCounter]["C_INVOICE_ID"].ToString(),
                                     "", "", "", "", "", "", "", triaStateBool.Ignor,
                                     triaStateBool.Ignor, false, false, "AND")
                                    .Rows[0]["DOCUMENTNO"].ToString();

                resultingPayment.Rows[rowCounter]["ACTIVE"] =
                    this.translateCharacterToBool(resultingPayment.
                            Rows[rowCounter]["ISACTIVE"].ToString());

                resultingPayment.Rows[rowCounter]["ESTIMATE"] =
                    this.translateCharacterToBool(resultingPayment.
                            Rows[rowCounter]["ISAMOUNTESTIMATE"].ToString());

                resultingPayment.Rows[rowCounter]["DISTRIBUTED"] =
                    this.translateCharacterToBool(resultingPayment.
                            Rows[rowCounter]["ISAMOUNTDISTRIBUTABLE"].ToString());


                if (resultingPayment.Rows[rowCounter]["C_BANKACCOUNT_ID"].ToString() != "")
                {
                    resultingPayment.Rows[rowCounter]["IS A BANK"] = true;
                    resultingPayment.Rows[rowCounter]["PAYED FROM"] =
                        this.getDataFromDb.getC_BANKACCOUNT(null, "", "", "",
                            resultingPayment.Rows[rowCounter]["C_BANKACCOUNT_ID"].ToString(), 
                            "", "", false, false, "AND")
                          .Rows[0]["ACCOUNTNO"].ToString();
                }
                else if (resultingPayment.Rows[rowCounter]["C_CASHBOOK_ID"].ToString() != "")
                {
                    resultingPayment.Rows[rowCounter]["IS A BANK"] = false;
                    resultingPayment.Rows[rowCounter]["PAYED FROM"] =
                        this.getDataFromDb.getC_CASHBOOKInfo(null, "", "",
                            resultingPayment.Rows[rowCounter]["C_CASHBOOK_ID"].ToString(), "",
                            false, false, "AND")
                          .Rows[0]["NAME"].ToString();
                }


                if (resultingPayment.Rows[rowCounter]["C_TAX_ID"].ToString() != "")
                {
                    resultingPayment.Rows[rowCounter]["IS A COST"] = false;
                    resultingPayment.Rows[rowCounter]["PAYED FOR"] =
                        this.getDataFromDb.getC_TAXInfo(null, "", "",
                               resultingPayment.Rows[rowCounter]["C_TAX_ID"].ToString(),
                               "", "", false, triaStateBool.Ignor, triaStateBool.Ignor,
                               false, "AND")
                            .Rows[0]["NAME"].ToString();
                }
                else
                {
                    resultingPayment.Rows[rowCounter]["IS A COST"] = true;
                    resultingPayment.Rows[rowCounter]["PAYED FOR"] =
                        this.getDataFromDb.getC_CHARGEInfo(null, "", "",
                                resultingPayment.Rows[rowCounter]["C_CHARGE_ID"].ToString(),
                                "", false, false, "AND")
                             .Rows[0]["NAME"].ToString();
                }

                resultingPayment.Rows[rowCounter]["COST CLOSED"] =
                    this.translateCharacterToBool(resultingPayment.
                                Rows[rowCounter]["COSTCLOSED"].ToString());

                resultingPayment.Rows[rowCounter]["VENDOR"] =
                    this.getDataFromDb.getC_BPARTNERInfo(null, "", "",
                              resultingPayment.Rows[rowCounter]["C_BPARTNER_ID"].ToString(),
                              "", triaStateBool.Ignor, triaStateBool.Ignor, 
                              triaStateBool.Ignor, triaStateBool.Ignor,
                              false, false, "AND")
                          .Rows[0]["NAME"].ToString();

                numberTextbox.AllowNegative = true;

                numberTextbox.Amount = 
                    resultingPayment.Rows[rowCounter]["INVOICEAMOUNT"].ToString();

                resultingPayment.Rows[rowCounter]["AMOUNT"] = numberTextbox.Amount;


                resultingPayment.Rows[rowCounter]["ORDER"] =
                    this.getDataFromDb.getC_ORDERInfo(null, "", "",
                            resultingPayment.Rows[rowCounter]["C_ORDER_ID"].ToString(),
                            "", "", "", "", "", "", triaStateBool.no, triaStateBool.Ignor, false, false, "AND")
                        .Rows[0]["DOCUMENTNO"].ToString();
            }

            
            resultingPayment.Columns.RemoveAt(
                        resultingPayment.Columns.IndexOf("COSTCLOSED"));
            resultingPayment.Columns.RemoveAt(
                resultingPayment.Columns.IndexOf("INVOICEAMOUNT"));
            resultingPayment.Columns.RemoveAt(
                resultingPayment.Columns.IndexOf("ISACTIVE"));
            resultingPayment.Columns.RemoveAt(
                resultingPayment.Columns.IndexOf("ISAMOUNTDISTRIBUTABLE"));
            resultingPayment.Columns.RemoveAt(
                resultingPayment.Columns.IndexOf("ISAMOUNTESTIMATE"));
            resultingPayment.Columns.RemoveAt(
                resultingPayment.Columns.IndexOf("UPDATED"));
            resultingPayment.Columns.RemoveAt(
                resultingPayment.Columns.IndexOf("UPDATEDBY"));
            resultingPayment.Columns.RemoveAt(
                resultingPayment.Columns.IndexOf("USERINSERTED"));
            resultingPayment.Columns.RemoveAt(
                resultingPayment.Columns.IndexOf("CREATED"));
            resultingPayment.Columns.RemoveAt(
                resultingPayment.Columns.IndexOf("CREATEDBY"));

            return resultingPayment;


        }

        public void determineIfUserCanCloseCost()
        {
            generalResultInformation.userCanCloseInvoiceCost = false;
            if (generalResultInformation.userId == "")
                return;            

            string dmlGetuserRoles = "SELECT AD_ROLE_ID "+
                                     "FROM AD_USER_ROLES "+
                                     "WHERE AD_USER_ID = '" + generalResultInformation.userId + 
                                     "' AND ISACTIVE = 'Y'";
            DataTable dtUserRoles = (DataTable)this.getDataFromDb.executeSqlOnCompiere(dmlGetuserRoles);
            if (dtUserRoles.Rows.Count <= 0)
                return;
            string dmlgetRoleWindowAccess;
            DataTable dtRoleWindowAccess;

            for (int rowCounter = 0; rowCounter <= dtUserRoles.Rows.Count - 1; rowCounter++)
            {
                dmlgetRoleWindowAccess = "SELECT * " +
                                         "FROM AD_WINDOW_ACCESS " + 
                                         "WHERE AD_WINDOW_ID = '" + generalResultInformation.invoiceVendorWindowId +
                                         "' AND AD_ROLE_ID = '" + dtUserRoles.Rows[rowCounter]["AD_ROLE_ID"].ToString() +
                                         "' AND ISACTIVE = 'Y' AND ISREADWRITE = 'Y'";

                dtRoleWindowAccess = (DataTable)this.getDataFromDb.executeSqlOnCompiere(dmlgetRoleWindowAccess);
                if (dtRoleWindowAccess.Rows.Count > 0)
                {
                    generalResultInformation.userCanCloseInvoiceCost = true;
                    return;
                }
            }
        }



        string un = "passMeIn";
        string pwd = "toMyEncryption";

        public DataTable readEncryptedXmlSettingFile(string file)
        {
            DataTable aDataTable = new DataTable();

            aDataTable.TableName = "Settings";
            aDataTable.Columns.Add("Parameter_Name");
            aDataTable.Columns.Add("Parameter_Value");

            if (File.Exists(file))
            {
                XMLEncryptor decryptSettings = new XMLEncryptor(un, pwd);
                aDataTable = decryptSettings.ReadEncryptedXML(file);
                //aDataTable.ReadXml(file);
            }
            else
            {
                this.createSettingFile(file);
            }

            return aDataTable;
        }

        public void writeDatatableToEncryptedXmlSettingFile(DataTable settings, string file)
        {
            XMLEncryptor encryptSettings = new XMLEncryptor(un, pwd);
            encryptSettings.WriteEncryptedXML(settings, file);
            //settings.WriteXml(file);
        }

        public void createSettingFile(string file)
        {
            DataTable aDataTable = new DataTable();

            aDataTable.TableName = "Settings";
            aDataTable.Columns.Add("Parameter_Name");
            aDataTable.Columns.Add("Parameter_Value");

            aDataTable.WriteXml(file);
        }


        public DataTable authenticateUser(string userName, string passWord)
        {
            DataTable userInfo = new DataTable();

            if (generalResultInformation.useLDAPAuthentication)
            {
                LDAPConnection authenticate = new LDAPConnection();

                userInfo =
                    this.getDataFromDb.getAD_USERInfo(null, "", "", "", "", userName, true, false, "AND");

                if (!getDataFromDb.checkIfTableContainesData(userInfo))
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
                    this.getDataFromDb.getAD_USERInfo(null, "", "", userName, passWord, "", true, false, "AND");

                if (!getDataFromDb.checkIfTableContainesData(userInfo))
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

            userRoleResult = this.getDataFromDb.getAD_USER_ROLESInfo(criteriaTable, "OR", AD_USER_ID, "", true, false, "AND");

            return this.getDataFromDb.checkIfTableContainesData(userRoleResult);
        }
    
    }
}
