using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;



namespace BankPayments
{
    class dataBuilder
    {
        //private string AD_CLIENT_ID = "";
        //private string AD_ORG_ID = "";
        //public string CREATED = DateTime.Now.ToString("dd-MMM-yyyy");
        //public string CREATEDBY = "1000002";
        //public string UPDATED = DateTime.Now.ToString("dd-MMM-yyyy");
        //public string UPDATEDBY = "1000002";
        public string fieldSeparator = "";
                
        public string DMLScriptCreator(string TableName, string[]
            primaryKeys, DataTable dt, int rowIndex, string DmlType)
        {
            string fieldNames = "";
            string values = "";
            string delimitingApostrophe = "";
            string theComma = "";
            string dmlCommand = "";
            string primaryColIDCondition = " WHERE ( ";
            string theValue = "";

            DateTime trsTime;
            if (DmlType.ToUpperInvariant() != "INSERT")
            {
                for (int i = 0; i < primaryKeys.Length; i++)
                {
                    primaryColIDCondition +=
                        fieldSeparator+primaryKeys[i].ToString() + 
                        fieldSeparator+ " = " + dt.Rows[rowIndex][primaryKeys[i].ToString()];
                    if ((i + 1) < primaryKeys.Length)
                    { primaryColIDCondition += " and "; }
                    else
                    { primaryColIDCondition += " )"; }
                }
            }
            if (DmlType.ToUpperInvariant() == "INSERT")
            {
                /////////////////////
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (dt.Rows[rowIndex][i].GetType().ToString() ==
                        "System.String" ||
                        dt.Rows[rowIndex][i].GetType().ToString() ==
                        "System.DateTime")
                    { delimitingApostrophe = "'"; }
                    else
                    { delimitingApostrophe = ""; }

                    if ((i + 1) < dt.Columns.Count)
                    { theComma = ", "; }
                    else
                    { theComma = ""; }

                    fieldNames += 
                        fieldSeparator + dt.Columns[i].Caption.ToString() + fieldSeparator + theComma;

                    if (dt.Rows[rowIndex][i].GetType().ToString() ==
                        "System.DateTime")
                    {
                        trsTime = (DateTime)dt.Rows[rowIndex][i];
                        values += delimitingApostrophe +
                            trsTime.ToString("dd-MMM-yyyy") +
                            delimitingApostrophe + theComma;
                    }
                    else if (dt.Rows[rowIndex][i].ToString() == "")
                    {
                        values += "''" + theComma;
                    }
                    else
                    {
                        theValue = dt.Rows[rowIndex][i].ToString();
                        theValue = theValue.Replace("(", "(");
                        theValue = theValue.Replace(")", ")");
                        theValue = theValue.Replace("%", "%");
                        theValue = theValue.Replace("&", "&");
                        theValue = theValue.Replace("'", "''");
                        theValue = theValue.Replace(";", ";");
                        theValue = theValue.Replace("/", "/");                        
                        theValue = theValue.Replace("\\", "\\\\");

                        values += delimitingApostrophe +
                            theValue +
                            delimitingApostrophe + theComma;
                    }

                }
                dmlCommand = "INSERT INTO " + TableName
                    + " (" + fieldNames + ") VALUES (" + values + ")";
                ///////////////
            }
            else if (DmlType.ToUpperInvariant() == "UPDATE")
            {
                ////////////

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (dt.Rows[rowIndex][i].GetType().ToString() ==
                        "System.String" ||
                        dt.Rows[rowIndex][i].GetType().ToString() ==
                        "System.DateTime")
                    { delimitingApostrophe = "'"; }
                    else
                    { delimitingApostrophe = ""; }

                    if ((i + 1) < dt.Columns.Count)
                    { theComma = ", "; }
                    else
                    { theComma = ""; }

                    if (dt.Rows[rowIndex][i].GetType().ToString() ==
                        "System.DateTime")
                    {
                        trsTime = (DateTime)dt.Rows[rowIndex][i];
                        values += dt.Columns[i].Caption.ToString() +
                            " = " + delimitingApostrophe +
                            trsTime.ToString("dd-MMM-yyyy") +
                            delimitingApostrophe + theComma;
                    }
                    else if (dt.Rows[rowIndex][i].ToString() == "")
                    {
                        values += dt.Columns[i].Caption.ToString() +
                            " = ''" + theComma;
                    }
                    else
                    {
                        theValue = dt.Rows[rowIndex][i].ToString();
                        theValue = theValue.Replace("(", "(");
                        theValue = theValue.Replace(")", ")");
                        theValue = theValue.Replace("%", "%");
                        theValue = theValue.Replace("&", "&");
                        theValue = theValue.Replace("'", "''");
                        theValue = theValue.Replace(";", ";");
                        theValue = theValue.Replace("/", "/");                        
                        theValue = theValue.Replace("\\", "\\\\");

                        values += fieldSeparator + dt.Columns[i].Caption.ToString() +
                            fieldSeparator + " = " + delimitingApostrophe + theValue +
                            delimitingApostrophe + theComma;
                    }

                }
                dmlCommand = "UPDATE " + TableName +
                    " SET " + values + primaryColIDCondition + "";

                ///////////
            }
            else if (DmlType.ToUpperInvariant() == "DELETE")
            {
                dmlCommand = "DELETE " + TableName + primaryColIDCondition + "";
            }

            return dmlCommand;
        }
                
        
        public DataTable removeEmptyColumnFromRow(DataTable dtTableToClear)
        {
            if (checkIfTableContainesData(dtTableToClear))
            { 
                for (int columnCounter = dtTableToClear.Columns.Count-1;
                    columnCounter >= 0;columnCounter--)
                    if (dtTableToClear.Rows[0][columnCounter].ToString() == "")
                    {
                        dtTableToClear.Columns.Remove(dtTableToClear.Columns[columnCounter].Caption);
                    }
            }
            return dtTableToClear;
        }
               
        public bool writeTextLinetoFile(string textLine,string logType)
        {
            string filePath = "";
            string fileName = "";
            string extension = "";
            string[] fileNames = null;
            List<FileInfo> fileList = new List<FileInfo>();
            FileInfo fullfillPath;

            switch(logType)
            {
                case "compSCRIPT":
                    filePath = dbSettingInformationHandler.compScriptDirectory;
                    extension = ".srp";
                    break;
                case "compWARINING":
                    filePath = dbSettingInformationHandler.compWarningDirectory;
                    extension = ".wrn";
                    break;
                case "compERROR":
                    filePath = dbSettingInformationHandler.compErrorDirectory;
                    extension = ".err";
                    break;
                case "posSCRIPT":
                    filePath = dbSettingInformationHandler.compScriptDirectory;
                    extension = ".srp";
                    break;
                case "posWARINING":
                    filePath = dbSettingInformationHandler.compWarningDirectory;
                    extension = ".wrn";
                    break;
                case "posERROR":
                    filePath = dbSettingInformationHandler.compErrorDirectory;
                    extension = ".err";
                    break;
                default:
                    filePath = @"...//...//emergencyLog//";
                    extension = ".emr";
                    break;
            }

            if (filePath == "")
            {
                return false;
            }

            filePath += "\\"+DateTime.Today.ToString("dd-yyyy-MM") + "\\"; 

            if (!Directory.Exists(filePath))
            {
                try
                {
                    Directory.CreateDirectory(filePath);
                }
                catch
                {
                    filePath = @"...//...//emergencyLog//" + DateTime.Today.ToString("dd-yyyy-MM") + "//";
                    extension = ".emr";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                }
            }

            
            
            fileNames = Directory.GetFiles(filePath, ("*" + extension).ToString(),
                SearchOption.TopDirectoryOnly);
            foreach (string name in fileNames)
            {
                fileList.Add(new System.IO.FileInfo(name));
            }
                                
            if (fileList.Count() < 1)
            {
                fileName = DateTime.Today.ToString("dd-yyyy-MM")+ "_0" + extension;
            }
            else
            {

                for (int fileIndex = fileList.Count()-1; fileIndex >=0; fileIndex--)
                {
                    if (fileList[fileIndex].Length < 500000)
                    {
                        fileName = fileList[fileIndex].Name;
                        break;
                    }
                }                               
            }
            if (fileName == "")
            {
                fileName = DateTime.Today.ToString("dd-yyyy-MM") + "_"
                    + (fileList.Count).ToString() + extension;
            }


            filePath += fileName;
            fullfillPath = new FileInfo(filePath);

            if (!fullfillPath.Exists)
            {
                fullfillPath.Create();
            }

            string v = fullfillPath.Directory.ToString();
            v = fullfillPath.FullName;

            return this.writeToFile(textLine, fullfillPath.FullName);   
            
            
        }

        public bool writeToFile(string textToWrite, string filePath)
        {
            StreamWriter sw = File.AppendText(filePath);
            try
            {
                sw.WriteLine(textToWrite);
                sw.Close();
                return true;
            }
            catch
            {
                sw.Close();
                return false;
            }

        }
                
        public object executeSqlOnCompiere(string sqlCommand)
        {
            DataTable resultOfQuery= new DataTable();
            int rowsAffected = 0;
            persistanceClass compiereConnection;
            string connectionStatus;
            string oraDataBaseType = dbSettingInformationHandler.compDataBaseType;
            string oraHostName = dbSettingInformationHandler.compHostName;
            string oraDataBaseName = dbSettingInformationHandler.compDataBaseName;
            string oraUserName = dbSettingInformationHandler.compUsername;
            string oraPassWord = dbSettingInformationHandler.compPassword;
            string oraPort = dbSettingInformationHandler.compPort;

            sqlCommand=sqlCommand.Replace("commSepartor", "");

            compiereConnection = new persistanceClass(oraDataBaseType, oraHostName,
                oraDataBaseName, oraUserName, oraPassWord,oraPort);

            connectionStatus = compiereConnection.connectToDataBase(compiereConnection);
            if (connectionStatus == "Open")
            {
                if (sqlCommand.ToUpperInvariant().StartsWith("SELECT"))
                    resultOfQuery = compiereConnection.getDataBaseData(sqlCommand, compiereConnection);
                else if (sqlCommand.ToUpperInvariant().StartsWith("INSERT") ||
                    sqlCommand.ToUpperInvariant().StartsWith("UPDATE") ||
                    sqlCommand.ToUpperInvariant().StartsWith("DELETE"))
                {
                    rowsAffected = compiereConnection.updateDataBaseData(sqlCommand, compiereConnection);
                    compiereConnection.closeConnection(compiereConnection);
                    return rowsAffected;
                }

            }            
            compiereConnection.closeConnection(compiereConnection);
            return resultOfQuery;
        }
              
        
        //Get data from Data base

        public string generateNewPrimaryKeyID(string tableName)
        {
            string nextPrimaryKey = "";
            string getPrimaryKey = "SELECT CURRENTNEXT" +
                " FROM AD_SEQUENCE" +
                " WHERE UPPER(NAME) = '" + tableName.ToUpperInvariant() + "'";
            DataTable primaryKey = (DataTable)this.executeSqlOnCompiere(getPrimaryKey);
            if (checkIfTableContainesData(primaryKey))
            {
                nextPrimaryKey = primaryKey.Rows[0][0].ToString();
                string setPrimaryKey = "UPDATE AD_SEQUENCE" +
                    " SET  CURRENTNEXT = CURRENTNEXT + 1" +
                    " WHERE UPPER(NAME) = '" + tableName.ToUpperInvariant() + "'";
                this.executeSqlOnCompiere(setPrimaryKey);
            }

            return nextPrimaryKey.ToString();
        }

        public string[] getCompiereTablePrimaryKey(string tableName)
        {
            string[] primarykeys = { "" };
            if (tableName == "AD_USER")
            { primarykeys = new string[] { "AD_USER_ID" }; }
            else if (tableName == "AD_ORG")
            { primarykeys = new string[] { "AD_ORG_ID" }; }
            else if (tableName == "AD_SEQUENCE")
            { primarykeys = new string[] { "AD_SEQUENCE_ID" }; }
            else if (tableName == "AD_ORGACCESS")
            { primarykeys = new string[] { "AD_USER_ID", "AD_ORG_ID" }; }
            else if (tableName == "C_BPARTNER")
            { primarykeys = new string[] { "C_BPARTNER_ID" }; }
            else if (tableName == "C_CHARGES")
            { primarykeys = new string[] { "C_CHARGES_ID" }; }
            else if (tableName == "C_TAX")
            { primarykeys = new string[] { "C_TAX_ID" }; }
            else if (tableName == "C_CASHBOOK")
            { primarykeys = new string[] { "C_CASHBOOK_ID" }; }
            else if (tableName == "C_BANK")
            { primarykeys = new string[] { "C_BANK_ID" }; }            
            else if (tableName == "C_BANKACCOUNT")
            { primarykeys = new string[] { "C_BANKACCOUNT_ID" }; }
            else if (tableName == "C_ORDER")
            { primarykeys = new string[] { "C_ORDER_ID" }; }
            else if (tableName == "C_INVOICE")
            { primarykeys = new string[] { "C_INVOICE_ID" }; }
            else if (tableName == "C_INVOICETAX")
            { primarykeys = new string[] { "C_TAX_ID", "C_INVOICE_ID" }; }
            else if (tableName == "C_INVOICELINE")
            { primarykeys = new string[] { "C_INVOICELINE_ID" }; }
            else if (tableName == "M_MATCHPO")
            { primarykeys = new string[] { "M_MATCHPO_ID" }; }
            else if (tableName == "PM_C_PURCHASEPAYMENT")
            { primarykeys = new string[] { "PM_C_PURCHASEPAYMENT_ID" }; }
            else if (tableName == "PM_C_PPAYMENT_INVOCELINE")
            { primarykeys = new string[] { "PM_C_PURCHASEPAYMENT_ID", "C_INVOICELINE_ID" }; }
            else if (tableName == "PM_PAYMENT_INVOCESHARE")
            { primarykeys = new string[] { "PM_C_PURCHASEPAYMENT_ID", "C_INVOICE_ID" }; }
            else if (tableName == "C_DOCTYPE")
            { primarykeys = new string[] { "C_DOCTYPE_ID" }; }
            else if (tableName == "C_PERIOD")
            { primarykeys = new string[] { "C_PERIOD_ID" }; }
            else if (tableName == "C_PERIODCONTROL")
            { primarykeys = new string[] { "C_PERIODCONTROL_ID" }; }
            else if (tableName == "C_ORDERLINE")
            { primarykeys = new string[] { "C_ORDERLINE_ID" }; }
            
            return primarykeys;
        }

        private string createTheCriteriaClause(DataTable _criteriaTable, string _criteriaLogicalConnector,
            string wherClauselogicalConnector)
        {
            if (!this.checkIfTableContainesData(_criteriaTable))
                return "";

            if (!_criteriaTable.Columns.Contains("Field") ||
                !_criteriaTable.Columns.Contains("Criterion") ||
                !_criteriaTable.Columns.Contains("Value")
               )
                return "";

            _criteriaTable = this.clearRedundantRow(_criteriaTable);

            string theCriteriaClase = " " + wherClauselogicalConnector + " (";
            string delimApostrophy = "";

            for (int rowCounter = 0; rowCounter <= _criteriaTable.Rows.Count - 1; rowCounter++)
            {
                if (_criteriaTable.Rows[rowCounter]["Field"].ToString() != "" ||
                    _criteriaTable.Rows[rowCounter]["Criterion"].ToString() != "" ||
                    _criteriaTable.Rows[rowCounter]["Value"].ToString() != "")
                {
                    if (_criteriaTable.Rows[rowCounter]["Value"].GetType().ToString() ==
                        "System.String" ||
                        _criteriaTable.Rows[rowCounter]["Value"].GetType().ToString() ==
                        "System.DateTime")
                        delimApostrophy = "'";
                    else
                        delimApostrophy = "";

                    theCriteriaClase = theCriteriaClase +
                        _criteriaTable.Rows[rowCounter]["Field"].ToString().ToUpperInvariant() + 
                        " " + _criteriaTable.Rows[rowCounter]["Criterion"].ToString() +
                        " " + delimApostrophy + _criteriaTable.Rows[rowCounter]["Value"].ToString().Replace("'", "''")
                        + delimApostrophy;
                }
                if ((rowCounter + 1) <= _criteriaTable.Rows.Count - 1)
                    theCriteriaClase = theCriteriaClase + " " + _criteriaLogicalConnector + " ";
            }

            theCriteriaClase = theCriteriaClase + ")";
            return theCriteriaClase;
        }

        public bool checkIfTableContainesData(DataTable dtTableToCheck)
        {
            bool tableContainsData = false;
            if (dtTableToCheck == null)
                return false;
            if (dtTableToCheck.Rows.Count > 0)
                for (int rowCounter = dtTableToCheck.Rows.Count - 1;
                    rowCounter >= 0 && tableContainsData == false;
                    rowCounter--)
                    for (int columnCounter = dtTableToCheck.Columns.Count - 1;
                        columnCounter >= 0 && tableContainsData == false;
                        columnCounter--)
                        if (dtTableToCheck.Rows[rowCounter][columnCounter].ToString() != "")
                            tableContainsData = true;

            return tableContainsData;
        }

        private DataTable getDataTableStructure(string tableName)
        {

            string[] Tableprimarykeys = this.getCompiereTablePrimaryKey(tableName);
            
            string theWhereClose = "";
            if (Tableprimarykeys.Length > 0)
                if (Tableprimarykeys[0] != "")
                    theWhereClose = "WHERE ";
            foreach (string primaryKey in Tableprimarykeys)
            {
                if (primaryKey != "")
                    theWhereClose = theWhereClose + primaryKey + " = '0'" + " AND ";
            }
            theWhereClose = theWhereClose.Remove(theWhereClose.LastIndexOf("AND"),3);
            string getStructureForTable = "SELECT *" +
                                          " FROM " + tableName + " " + theWhereClose;
            DataTable result = (DataTable)executeSqlOnCompiere(getStructureForTable);
            result.Clear();
            return result;
        }

        public DataTable clearRedundantRow(DataTable tableToClear)
        {
            if (!this.checkIfTableContainesData(tableToClear))
                return tableToClear;
            bool rowIsRedundant = true;
            for (int rowCounter = tableToClear.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                rowIsRedundant = true;
                for (int rowCounter2 = rowCounter - 1;
                    rowCounter2 >= 0; rowCounter2--)
                {
                    for (int columnCounter = tableToClear.Columns.Count - 1;
                        columnCounter >= 0; columnCounter--)
                    {
                        if (tableToClear.Rows[rowCounter][columnCounter].ToString() !=
                        tableToClear.Rows[rowCounter2][columnCounter].ToString())
                        {
                            rowIsRedundant = false;
                            break;
                        }
                    }
                    if (rowIsRedundant)
                    {
                        tableToClear.Rows.RemoveAt(rowCounter);
                        break;
                    }
                }
            }
            return tableToClear;
        }

        public DataTable mergeTables(DataTable firstTable, DataTable secondTable,
           string comparisionColumnName, bool mergeOnlyCommonRows)
        {
            firstTable = clearRedundantRow(firstTable);
            secondTable = clearRedundantRow(secondTable);

            // if the merge type is Union
            // merge the two tables remove redundunt row and return the resulting table
            if (!mergeOnlyCommonRows)
            {
                firstTable.Merge(secondTable, true, MissingSchemaAction.Add);
                firstTable = clearRedundantRow(firstTable);
                return firstTable;
            }
            // If the merge type is common(intersection)
            //... if any of the tables are empty return empty result.
            if (!this.checkIfTableContainesData(secondTable) ||
                !this.checkIfTableContainesData(firstTable))
            {
                firstTable.Clear();
                return firstTable;
            }


            bool currentRowIsCommon = true;
            string currentColumnName = "";


            //.... if column is given for commonality check                    
            if (comparisionColumnName != "")
            {
                // ... if any of the table luck the column name return empty resut
                if (!firstTable.Columns.Contains(comparisionColumnName) ||
                    !secondTable.Columns.Contains(comparisionColumnName))
                {
                    firstTable.Clear();
                    return firstTable;
                }
                // ... if both table have the column
                //... check existance of each row in the first table in the second table
                //... if it does not exist delete that row
                //... finaly return the first table.
                for (int firstTableCurrentRow = firstTable.Rows.Count - 1;
                    firstTableCurrentRow >= 0; firstTableCurrentRow--)
                {
                    currentRowIsCommon = false;
                    for (int secondTableCurrentRow = secondTable.Rows.Count - 1;
                        secondTableCurrentRow >= 0; secondTableCurrentRow--)
                    {
                        if (firstTable.Rows[firstTableCurrentRow][comparisionColumnName].ToString() ==
                            secondTable.Rows[secondTableCurrentRow][comparisionColumnName].ToString())
                        {
                            currentRowIsCommon = true;
                            break;
                        }
                    }
                    if (!currentRowIsCommon)
                        firstTable.Rows.RemoveAt(firstTableCurrentRow);
                }
                return firstTable;
            }


            //.... if column is not given for commonality check 
            //... if both table does not contain the same number of columns return empty result
            if (firstTable.Columns.Count != secondTable.Columns.Count)
            {
                firstTable.Clear();
                return firstTable;
            }

            //... or if both tables does not contain same column name return empty result
            for (int firstTableColumnCounter = firstTable.Columns.Count - 1;
                firstTableColumnCounter >= 0; firstTableColumnCounter++)
                if (!secondTable.Columns.Contains(firstTable.Columns[firstTableColumnCounter].ColumnName))
                {
                    firstTable.Clear();
                    return firstTable;
                }

            //... if Both table Contain same column size and column name
            //...check if each row in the first table has identical row in the second table
            //... if it does not have remove that row and finaly return the firts table.
            for (int firstTableCurrentRow = firstTable.Rows.Count - 1;
                firstTableCurrentRow >= 0; firstTableCurrentRow--)
            {
                for (int secondTableCurrentRow = secondTable.Rows.Count - 1;
                    secondTableCurrentRow >= 0; secondTableCurrentRow--)
                {
                    currentRowIsCommon = true;
                    for (int firstTableColumnCournter = firstTable.Columns.Count - 1;
                        firstTableColumnCournter >= 0; firstTableColumnCournter--)
                    {
                        currentColumnName =
                            firstTable.Columns[firstTableColumnCournter].ColumnName;
                        if (firstTable.Rows[firstTableCurrentRow][currentColumnName].ToString() !=
                            secondTable.Rows[secondTableCurrentRow][currentColumnName].ToString())
                        {
                            currentRowIsCommon = false;
                            break;
                        }
                    }
                    if (currentRowIsCommon)
                    {
                        currentRowIsCommon = true;
                        break;
                    }
                }
                if (!currentRowIsCommon)
                    firstTable.Rows.RemoveAt(firstTableCurrentRow);
            }

            return firstTable;
        }


        public DataTable getAD_ORGInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("AD_ORG");
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE (ISACTIVE = 'Y' OR ISACTIVE = 'N')";

            whereClause = whereClause + " " + logicalConnector + " AD_CLIENT_ID = '" + generalResultInformation.clientId + "'";

            if (AD_ORG_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_ORG_ID = '" + AD_ORG_ID + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM AD_ORG " + whereClause;

            return (DataTable)executeSqlOnCompiere(getRequestedTableInformation);
        }

        public DataTable getAD_USER_ORGACCESSInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string AD_USER_ID, bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("AD_USER_ORGACCESS");
            }


            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE (ISACTIVE = 'Y' OR ISACTIVE = 'N')";

            if (AD_ORG_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_ORG_ID = '" + AD_ORG_ID + "'";

            if (AD_USER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_USER_ID = " + AD_USER_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM AD_USER_ORGACCESS " + whereClause;

            return (DataTable)executeSqlOnCompiere(getRequestedTableInformation);
        }

        public DataTable getAD_USERInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_USER_ID, string UserName, string PassWord, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("AD_USER");
            }


            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE (ISACTIVE = 'Y' OR ISACTIVE = 'N')";

            whereClause = whereClause + " " + logicalConnector + " AD_CLIENT_ID = '" + generalResultInformation.clientId + "'";

            if (AD_USER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_USER_ID = " + AD_USER_ID;

            if (UserName != "")
                whereClause = whereClause + " " + logicalConnector +
                    " NAME = '" + UserName.Replace("'", "''") + "'";

            if (PassWord != "")
                whereClause = whereClause + " " + logicalConnector +
                    " PASSWORD = '" + PassWord.Replace("'", "''") + "'";

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM AD_USER " + whereClause;

            return (DataTable)executeSqlOnCompiere(getRequestedTableInformation);
        }

        public DataTable getC_BPARTNERInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string C_BPARTNER_ID, string NAME, triaStateBool ISVENDOR, 
            triaStateBool ISCUSTOMER, triaStateBool ISEMPLOYEE, triaStateBool ISSALESREP,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("C_BPARTNER");
            }


            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE (ISACTIVE = 'Y' OR ISACTIVE = 'N')";

            whereClause = whereClause + " " + logicalConnector + " AD_CLIENT_ID = '" + generalResultInformation.clientId + "'";

            if (ISVENDOR == triaStateBool.yes)
                whereClause = whereClause + " " + logicalConnector +
                            " ISVENDOR = 'Y'";
            else if(ISVENDOR == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                            " ISVENDOR = 'N'";

            if (ISCUSTOMER == triaStateBool.yes)
                whereClause = whereClause + " " + logicalConnector +
                    " ISCUSTOMER = 'Y'";
            else if(ISCUSTOMER == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                    " ISCUSTOMER = 'N'";


            if (ISEMPLOYEE == triaStateBool.yes)
                whereClause = whereClause + " " + logicalConnector +
                    " ISEMPLOYEE = 'Y'";
            else if(ISEMPLOYEE == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                    " ISEMPLOYEE = 'N'";

            if (ISSALESREP == triaStateBool.yes)
                whereClause = whereClause + " " + logicalConnector +
                    " ISSALESREP = 'Y'";
            else if (ISSALESREP == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                    " ISSALESREP = 'N'";

            if (AD_ORG_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_ORG_ID = '" + AD_ORG_ID + "'";

            if (C_BPARTNER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_BPARTNER_ID = " + C_BPARTNER_ID;

            if (NAME != "")
                whereClause = whereClause + " " + logicalConnector +
                    " NAME = " + NAME.Replace("'", "''");

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_BPARTNER " + whereClause;

            return (DataTable)executeSqlOnCompiere(getRequestedTableInformation);
        }
        
        public DataTable getC_CHARGEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string C_CHARGE_ID, string NAME, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("C_CHARGE");
            }


            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE (ISACTIVE = 'Y' OR ISACTIVE = 'N')";

            whereClause = whereClause + " " + logicalConnector + " AD_CLIENT_ID = '" + generalResultInformation.clientId + "'";

            if (AD_ORG_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_ORG_ID = '" + AD_ORG_ID + "'";

            if (C_CHARGE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_CHARGE_ID = '" + C_CHARGE_ID + "'";

            if (NAME != "")
                whereClause = whereClause + " " + logicalConnector +
                    " NAME = '" + NAME.Replace("'", "''") + "'";

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_CHARGE " + whereClause;

            return (DataTable)executeSqlOnCompiere(getRequestedTableInformation);
        }
        
        public DataTable getC_TAXInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string C_TAX_ID, string NAME, string VALIDFROM,
            bool onlyActiveRecords, triaStateBool ISSALESTAX, triaStateBool ISSUMMARY,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("C_TAX");
            }


            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE (ISACTIVE = 'Y' OR ISACTIVE = 'N')";

            whereClause = whereClause + " " + logicalConnector + " AD_CLIENT_ID = '" + generalResultInformation.clientId + "'";

            if (ISSALESTAX == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " ISSALESTAX = 'Y'";
            }
            else if (ISSALESTAX == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                    " ISSALESTAX = 'N'";

            if (ISSUMMARY == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " ISSUMMARY = 'Y'";
            }
            else if (ISSUMMARY == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                    " ISSUMMARY = 'N'";

            if (VALIDFROM!= "")
                whereClause = whereClause + " " + logicalConnector +
                    " VALIDFROM >= " + VALIDFROM;


            if (AD_ORG_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_ORG_ID = '" + AD_ORG_ID + "'";

            if (C_TAX_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_TAX_ID = '" + C_TAX_ID + "'";

            if (NAME != "")
                whereClause = whereClause + " " + logicalConnector +
                    " NAME = '" + NAME.Replace("'", "''") + "'";

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_TAX " + whereClause;

            return (DataTable)executeSqlOnCompiere(getRequestedTableInformation);
        }
        
        public DataTable getC_CASHBOOKInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string C_CASHBOOK_ID, string NAME, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("C_CASHBOOK");
            }


            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE (ISACTIVE = 'Y' OR ISACTIVE = 'N')";

            whereClause = whereClause + " " + logicalConnector + " AD_CLIENT_ID = '" + generalResultInformation.clientId + "'";

            if (AD_ORG_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_ORG_ID = '" + AD_ORG_ID + "'";

            if (C_CASHBOOK_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_CASHBOOK_ID = '" + C_CASHBOOK_ID + "'";

            if (NAME != "")
                whereClause = whereClause + " " + logicalConnector +
                    " NAME = '" + NAME.Replace("'", "''") + "'";

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_CASHBOOK " + whereClause;

            return (DataTable)executeSqlOnCompiere(getRequestedTableInformation);
        }
        
        public DataTable getC_BANK(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string C_BANK_ID, string NAME, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("C_BANK");
            }


            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE (ISACTIVE = 'Y' OR ISACTIVE = 'N')";

            whereClause = whereClause + " " + logicalConnector + " AD_CLIENT_ID = '" + generalResultInformation.clientId + "'";

            if (AD_ORG_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_ORG_ID = '" + AD_ORG_ID + "'";

            if (C_BANK_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_BANK_ID = '" + C_BANK_ID + "'";

            if (NAME != "")
                whereClause = whereClause + " " + logicalConnector +
                    " NAME = '" + NAME.Replace("'", "''") + "'";

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_BANK " + whereClause;

            return (DataTable)executeSqlOnCompiere(getRequestedTableInformation);
        }
        
        public DataTable getC_BANKACCOUNT(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string C_BANK_ID, string C_BANKACCOUNT_ID, string ACCOUNTNO,
            string BANKACCOUNTTYPE, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("C_BANKACCOUNT");
            }


            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE (ISACTIVE = 'Y' OR ISACTIVE = 'N')";

            whereClause = whereClause + " " + logicalConnector + " AD_CLIENT_ID = '" + generalResultInformation.clientId + "'";

            if (AD_ORG_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_ORG_ID = '" + AD_ORG_ID + "'";

            if (C_BANK_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_BANK_ID = '" + C_BANK_ID + "'";

            if (C_BANKACCOUNT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                   " C_BANKACCOUNT_ID = '" + C_BANKACCOUNT_ID + "'";            

            if (ACCOUNTNO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " ACCOUNTNO = '" + ACCOUNTNO.Replace("'", "''") + "'";

            if (BANKACCOUNTTYPE != "")
                whereClause = whereClause + " " + logicalConnector +
                    " BANKACCOUNTTYPE = '" + BANKACCOUNTTYPE + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_BANKACCOUNT " + whereClause;

            return (DataTable)executeSqlOnCompiere(getRequestedTableInformation);
        }
        
        public DataTable getC_ORDERInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string C_ORDER_ID, string C_DOCTYPE_ID, string C_DOCTYPETARGET_ID,
            string C_PAYMENT_ID, string DOCACTION, string DOCSTATUS, string DOCUMENTNO,
            triaStateBool ISSOTRX, triaStateBool PROCESSED, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("C_ORDER");
            }


            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE (ISACTIVE = 'Y' OR ISACTIVE = 'N')";

            whereClause = whereClause + " " + logicalConnector + " AD_CLIENT_ID = '" + generalResultInformation.clientId + "'";

            if (ISSOTRX == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " ISSOTRX = 'Y'";
            }
            else if (ISSOTRX == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                    " ISSOTRX = 'N'";

            if (PROCESSED == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " PROCESSED = 'Y'";
            }
            else if (PROCESSED == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                    " PROCESSED = 'N'";

            if (AD_ORG_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_ORG_ID = '" + AD_ORG_ID + "'";

            if (C_ORDER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_ORDER_ID = '" + C_ORDER_ID + "'";

            if (C_DOCTYPE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_DOCTYPE_ID = '" + C_DOCTYPE_ID + "'";

            if (C_DOCTYPETARGET_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_DOCTYPETARGET_ID = '" + C_DOCTYPETARGET_ID + "'";
            
            if (C_PAYMENT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_PAYMENT_ID = '" + C_PAYMENT_ID + "'";

            if (DOCACTION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " DOCACTION = '" + DOCACTION + "'";

            if (DOCSTATUS != "")
                whereClause = whereClause + " " + logicalConnector +
                    " DOCSTATUS = '" + DOCSTATUS + "'";

            if (DOCUMENTNO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " DOCUMENTNO = '" + DOCUMENTNO.Replace("'", "''") + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_ORDER " + whereClause;

            return (DataTable)executeSqlOnCompiere(getRequestedTableInformation);
        }
        
        //

        public DataTable getC_INVOICEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string C_INVOICE_ID, string C_ORDER_ID, string C_DOCTYPE_ID, string C_DOCTYPETARGET_ID,
            string C_PAYMENT_ID, string DOCACTION, string DOCSTATUS, string DOCUMENTNO,
            triaStateBool ISSOTRX, triaStateBool PROCESSED, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("C_INVOICE");
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE (ISACTIVE = 'Y' OR ISACTIVE = 'N')";

            whereClause = whereClause + " " + logicalConnector + " AD_CLIENT_ID = '" + generalResultInformation.clientId + "'";

            if (ISSOTRX == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " ISSOTRX = 'Y'";
            }
            else if (ISSOTRX == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                    " ISSOTRX = 'N'";

            if (PROCESSED == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " PROCESSED = 'Y'";
            }
            else if (PROCESSED == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                    " PROCESSED = 'N'";

            if (AD_ORG_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_ORG_ID = '" + AD_ORG_ID + "'";

            if (C_INVOICE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_INVOICE_ID = " + C_INVOICE_ID;

            if (C_ORDER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_ORDER_ID = '" + C_ORDER_ID + "'";

            if (C_DOCTYPE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_DOCTYPE_ID = '" + C_DOCTYPE_ID + "'";

            if (C_DOCTYPETARGET_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_DOCTYPETARGET_ID = '" + C_DOCTYPETARGET_ID + "'";

            if (C_PAYMENT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_PAYMENT_ID = '" + C_PAYMENT_ID + "'";

            if (DOCACTION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " DOCACTION = '" + DOCACTION + "'";

            if (DOCSTATUS != "")
                whereClause = whereClause + " " + logicalConnector +
                    " DOCSTATUS = '" + DOCSTATUS + "'";

            if (DOCUMENTNO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " DOCUMENTNO = '" + DOCUMENTNO.Replace("'", "''") + "'";

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_INVOICE " + whereClause;

            return (DataTable)executeSqlOnCompiere(getRequestedTableInformation);
        }
        
        public DataTable getC_INVOICELINEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string C_INVOICE_ID, string C_INVOICELINE_ID, string C_TAX_ID,
            string M_PRODUCT_ID, triaStateBool ISDESCRIPTION, triaStateBool PROCESSED, 
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("C_INVOICELINE");
            }


            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE (ISACTIVE = 'Y' OR ISACTIVE = 'N')";

            whereClause = whereClause + " " + logicalConnector + " AD_CLIENT_ID = '" + generalResultInformation.clientId + "'";

            if (ISDESCRIPTION == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " ISDESCRIPTION = 'Y'";
            }
            else if (ISDESCRIPTION == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                    " ISDESCRIPTION = 'N'";

            if (PROCESSED == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " PROCESSED = 'Y'";
            }
            else if (PROCESSED == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                    " PROCESSED = 'N'";

            if (AD_ORG_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_ORG_ID = '" + AD_ORG_ID + "'";

            if (C_INVOICE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_INVOICE_ID = " + C_INVOICE_ID;

            if (C_INVOICELINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_INVOICELINE_ID = '" + C_INVOICELINE_ID + "'";

            if (C_TAX_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_TAX_ID = '" + C_TAX_ID + "'";            

            if (M_PRODUCT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " M_PRODUCT_ID = '" + M_PRODUCT_ID + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_INVOICELINE " + whereClause;

            return (DataTable)executeSqlOnCompiere(getRequestedTableInformation);
        }

        public DataTable getC_INVOICETAXInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
           string AD_ORG_ID, string C_INVOICE_ID, string C_TAX_ID,
           triaStateBool ISTAXINCLUDED, triaStateBool PROCESSED, bool onlyActiveRecords,
           bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("C_INVOICETAX");
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE (ISACTIVE = 'Y' OR ISACTIVE = 'N')";

            whereClause = whereClause + " " + logicalConnector + 
                " AD_CLIENT_ID = '" + generalResultInformation.clientId + "'";

            if (ISTAXINCLUDED == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " ISTAXINCLUDED = 'Y'";
            }
            else if (ISTAXINCLUDED == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                    " ISTAXINCLUDED = 'N'";

            if (PROCESSED == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " PROCESSED = 'Y'";
            }
            else if (PROCESSED == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                    " PROCESSED = 'N'";

            if (AD_ORG_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_ORG_ID = '" + AD_ORG_ID + "'";

            if (C_INVOICE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_INVOICE_ID = " + C_INVOICE_ID;

            if (C_TAX_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_TAX_ID = '" + C_TAX_ID + "'";

            

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_INVOICETAX " + whereClause;

            return (DataTable)executeSqlOnCompiere(getRequestedTableInformation);
        }        
        
        public DataTable getPM_C_PURCHASEPAYMENTInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string PM_C_PURCHASEPAYMENT_ID, string DATEINVOICED, string DOCUMENTNO,
            string C_ORDER_ID, string C_INVOICE_ID, string C_BPARTNER_ID,
            string C_BANKACCOUNT_ID, string C_CASHBOOK_ID, string C_TAX_ID, string C_CHARGE_ID,
            triaStateBool COSTCLOSED, triaStateBool USERINSERTED, triaStateBool ISAMOUNTDISTRIBUTABLE,
            triaStateBool ISAMOUNTESTIMATE, triaStateBool ActiveRecords, bool structureOnly, 
            string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)//
            {
                return this.getDataTableStructure("PM_C_PURCHASEPAYMENT");
            }


            string whereClause = "WHERE AD_CLIENT_ID = '" + generalResultInformation.clientId + "'";

            if (ActiveRecords == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector + " ISACTIVE = 'Y'";
            }
            else if (ActiveRecords == triaStateBool.no)
            {
                whereClause = whereClause + " " + logicalConnector + " ISACTIVE = 'N'";
            }            

            if (ISAMOUNTDISTRIBUTABLE == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " ISAMOUNTDISTRIBUTABLE = 'Y'";
            }
            else if (ISAMOUNTDISTRIBUTABLE == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                    " ISAMOUNTDISTRIBUTABLE = 'N'";

            if (ISAMOUNTESTIMATE == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " ISAMOUNTESTIMATE = 'Y'";
            }
            else if (ISAMOUNTESTIMATE == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                    " ISAMOUNTESTIMATE = 'N'";

            if (COSTCLOSED == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " COSTCLOSED = 'Y'";
            }
            else if (COSTCLOSED == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                    " COSTCLOSED = 'N'";


            if (USERINSERTED == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " USERINSERTED = 'Y'";
            }
            else if (USERINSERTED == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                    " USERINSERTED = 'N'";

            if (AD_ORG_ID != "")//
                whereClause = whereClause + " " + logicalConnector +
                    " AD_ORG_ID = '" + AD_ORG_ID + "'";

            if (C_INVOICE_ID != "")//
                whereClause = whereClause + " " + logicalConnector +
                    " C_INVOICE_ID = " + C_INVOICE_ID;

            if (C_BANKACCOUNT_ID != "")//
                whereClause = whereClause + " " + logicalConnector +
                    " C_BANKACCOUNT_ID = '" + C_BANKACCOUNT_ID + "'";

            if (C_TAX_ID != "")//
                whereClause = whereClause + " " + logicalConnector +
                    " C_TAX_ID = '" + C_TAX_ID + "'";

            if (C_BPARTNER_ID != "")//
                whereClause = whereClause + " " + logicalConnector +
                    " C_BPARTNER_ID = '" + C_BPARTNER_ID + "'";
            

            if (PM_C_PURCHASEPAYMENT_ID != "")//
                whereClause = whereClause + " " + logicalConnector +
                    " PM_C_PURCHASEPAYMENT_ID = '" + PM_C_PURCHASEPAYMENT_ID + "'";


            if (C_CASHBOOK_ID != "")//
                whereClause = whereClause + " " + logicalConnector +
                    " C_CASHBOOK_ID = '" + C_CASHBOOK_ID + "'";

            if (C_CHARGE_ID != "")//
                whereClause = whereClause + " " + logicalConnector +
                    " C_CHARGE_ID = '" + C_CHARGE_ID + "'";

            if (C_ORDER_ID != "")//
                whereClause = whereClause + " " + logicalConnector +
                    " C_ORDER_ID = '" + C_ORDER_ID + "'";

            if (DOCUMENTNO != "")//
                whereClause = whereClause + " " + logicalConnector +
                    " DOCUMENTNO = '" + DOCUMENTNO.Replace("'", "''") + "'";

            if (DATEINVOICED != "")//
                whereClause = whereClause + " " + logicalConnector +
                    " DATEINVOICED = '" + DATEINVOICED + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM PM_C_PURCHASEPAYMENT " + whereClause;

            return (DataTable)executeSqlOnCompiere(getRequestedTableInformation);
        }
        
        public DataTable getPM_C_PPAYMENT_INVOCELINEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string PM_C_PURCHASEPAYMENT_ID, string C_INVOICELINE_ID,string C_INVOICE_ID,
            string C_CHARGE_ID, string C_TAX_ID, triaStateBool COSTCLOSED,
            bool onlyActiveRecords, triaStateBool ISAMOUNTESTIMATE, 
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("PM_C_PPAYMENT_INVOCELINE");
            }


            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE (ISACTIVE = 'Y' OR ISACTIVE = 'N')";

            whereClause = whereClause + " " + logicalConnector + " AD_CLIENT_ID = '" + generalResultInformation.clientId + "'";

            if (ISAMOUNTESTIMATE == triaStateBool.yes)
            {
                whereClause = "WHERE ISAMOUNTESTIMATE = 'Y'";
            }
            else if (ISAMOUNTESTIMATE == triaStateBool.no)
                whereClause = "WHERE ISAMOUNTESTIMATE = 'N'";

            if (COSTCLOSED == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " COSTCLOSED = 'Y'";
            }
            else if (COSTCLOSED == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                    " COSTCLOSED = 'N'";
            
            if (AD_ORG_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_ORG_ID = '" + AD_ORG_ID + "'";

            if (PM_C_PURCHASEPAYMENT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " PM_C_PURCHASEPAYMENT_ID = '" + PM_C_PURCHASEPAYMENT_ID + "'";

            if (C_INVOICELINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_INVOICELINE_ID = '" + C_INVOICELINE_ID + "'";

            if (C_INVOICE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_INVOICE_ID = '" + C_INVOICE_ID + "'";

            if (C_CHARGE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_CHARGE_ID = '" + C_CHARGE_ID + "'";

            if (C_TAX_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_TAX_ID = '" + C_TAX_ID + "'";

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM PM_C_PPAYMENT_INVOCELINE " + whereClause;

            return (DataTable)executeSqlOnCompiere(getRequestedTableInformation);
        }

        public DataTable getPM_PAYMENT_INVOCESHAREInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string PM_C_PURCHASEPAYMENT_ID, string C_INVOICE_ID, 
            string C_TAX_ID, string C_CHARGE_ID, 
            triaStateBool ISAMOUNTESTIMATE, bool onlyActiveRecords, bool structureOnly,
            string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)//
            {
                return this.getDataTableStructure("PM_PAYMENT_INVOCESHARE");
            }


            string whereClause = "";

            if (onlyActiveRecords)//
            {
                whereClause = "WHERE ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE (ISACTIVE = 'Y' OR ISACTIVE = 'N')";

            whereClause = whereClause + " " + logicalConnector + 
                " AD_CLIENT_ID = '" + generalResultInformation.clientId + "'";
            
            if (ISAMOUNTESTIMATE == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " ISAMOUNTESTIMATE = 'Y'";
            }
            else if (ISAMOUNTESTIMATE == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                    " ISAMOUNTESTIMATE = 'N'";
            
            if (AD_ORG_ID != "")//
                whereClause = whereClause + " " + logicalConnector +
                    " AD_ORG_ID = '" + AD_ORG_ID + "'";

            if (C_INVOICE_ID != "")//
                whereClause = whereClause + " " + logicalConnector +
                    " C_INVOICE_ID = " + C_INVOICE_ID;

            if (C_TAX_ID != "")//
                whereClause = whereClause + " " + logicalConnector +
                    " C_TAX_ID = '" + C_TAX_ID + "'";
            
            if (PM_C_PURCHASEPAYMENT_ID != "")//
                whereClause = whereClause + " " + logicalConnector +
                    " PM_C_PURCHASEPAYMENT_ID = '" + PM_C_PURCHASEPAYMENT_ID + "'";
                                    
            if (C_CHARGE_ID != "")//
                whereClause = whereClause + " " + logicalConnector +
                    " C_CHARGE_ID = '" + C_CHARGE_ID + "'";
            
            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, 
                        criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM PM_PAYMENT_INVOCESHARE " + whereClause;

            return (DataTable)executeSqlOnCompiere(getRequestedTableInformation);
        }

        public DataTable getC_UOMInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_UOM_ID, bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("C_UOM");
            }


            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE ISACTIVE= 'Y'";
            }
            else
                whereClause = "WHERE (ISACTIVE= 'Y' OR ISACTIVE= 'N')";

            if (C_UOM_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_UOM_ID = " + C_UOM_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_UOM " + whereClause;

            return (DataTable)executeSqlOnCompiere(getRequestedTableInformation);
        }

        public DataTable getM_PRODUCTInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_PRODUCT_ID, bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("M_PRODUCT");
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE ISACTIVE= 'Y'";
            }
            else
                whereClause = "WHERE (ISACTIVE= 'Y' OR ISACTIVE= 'N')";

            if (M_PRODUCT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " M_PRODUCT_ID = " + M_PRODUCT_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM M_PRODUCT " + whereClause;

            return (DataTable)executeSqlOnCompiere(getRequestedTableInformation);
        }

        public DataTable getM_MATCHPOInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string M_MATCHPO_ID, string C_ORDERLINE_ID,
            string M_INOUTLINE_ID, string C_INVOICELINE_ID,
            bool onlyActiveRecords, bool structureOnly,
            string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)//
            {
                return this.getDataTableStructure("M_MATCHPO");
            }


            string whereClause = "";

            if (onlyActiveRecords)//
            {
                whereClause = "WHERE ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE (ISACTIVE = 'Y' OR ISACTIVE = 'N')";

            whereClause = whereClause + " " + logicalConnector +
                " AD_CLIENT_ID = '" + generalResultInformation.clientId + "'";
            
            if (AD_ORG_ID != "")//
                whereClause = whereClause + " " + logicalConnector +
                    " AD_ORG_ID = '" + AD_ORG_ID + "'";

            if (C_INVOICELINE_ID != "")//
                whereClause = whereClause + " " + logicalConnector +
                    " C_INVOICELINE_ID = " + C_INVOICELINE_ID;

            if (M_MATCHPO_ID != "")//
                whereClause = whereClause + " " + logicalConnector +
                    " M_MATCHPO_ID = '" + M_MATCHPO_ID + "'";

            if (C_ORDERLINE_ID != "")//
                whereClause = whereClause + " " + logicalConnector +
                    " C_ORDERLINE_ID = '" + C_ORDERLINE_ID + "'";

            if (M_INOUTLINE_ID != "")//
                whereClause = whereClause + " " + logicalConnector +
                    " M_INOUTLINE_ID = '" + M_INOUTLINE_ID + "'";

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable,
                        criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM M_MATCHPO " + whereClause;

            return (DataTable)executeSqlOnCompiere(getRequestedTableInformation);
        }
        


        public DataTable getC_DOCTYPEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_DOCTYPE_ID, string NAME, string DOCBASETYPE, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";

            string whereClause = "";

            if (structureOnly)//
            {
                return this.getDataTableStructure("C_DOCTYPE");
            }

            if (onlyActiveRecords)//
            {
                whereClause = "WHERE ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE (ISACTIVE = 'Y' OR ISACTIVE = 'N')";

            if (NAME != "")//
                whereClause = whereClause + " " + logicalConnector +
                    " NAME = '" + NAME + "'";

            if (C_DOCTYPE_ID != "")//
                whereClause = whereClause + " " + logicalConnector +
                    " C_DOCTYPE_ID = '" + C_DOCTYPE_ID + "'";

            if (DOCBASETYPE != "")//
                whereClause = whereClause + " " + logicalConnector +
                    " DOCBASETYPE = '" + DOCBASETYPE + "'";

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable,
                        criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_DOCTYPE " + whereClause;

            return (DataTable)executeSqlOnCompiere(getRequestedTableInformation);
        }

        public DataTable getC_PERIODInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_PERIOD_ID, DateTime PERIOD_DATE, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("C_PERIOD");
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE ISACTIVE= 'Y'";
            }
            else
                whereClause = "WHERE (ISACTIVE= 'Y' OR ISACTIVE= 'N')";

            if (C_PERIOD_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_PERIOD_ID = " + C_PERIOD_ID;

            if (PERIOD_DATE != null)
                whereClause = whereClause + " " + logicalConnector +
                    " (STARTDATE <= '" + PERIOD_DATE.ToString("dd-MMM-yyyy") +
                    "' AND ENDDATE >= '" + PERIOD_DATE.ToString("dd-MMM-yyyy") + "')";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_PERIOD " + whereClause;

            return (DataTable)executeSqlOnCompiere(getRequestedTableInformation);
        }

        public DataTable getC_PERIODCONTROLInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_PERIODCONTROL_ID, string C_PERIOD_ID, string DOCBASETYPE,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("C_PERIODCONTROL");
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE ISACTIVE= 'Y'";
            }
            else
                whereClause = "WHERE (ISACTIVE= 'Y' OR ISACTIVE= 'N')";

            if (C_PERIODCONTROL_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_PERIODCONTROL_ID = " + C_PERIODCONTROL_ID;

            if (C_PERIOD_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_PERIOD_ID = " + C_PERIOD_ID;

            if (DOCBASETYPE != "")
                whereClause = whereClause + " " + logicalConnector +
                    " DOCBASETYPE = '" + DOCBASETYPE + "'";
            
            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_PERIODCONTROL " + whereClause;

            return (DataTable)executeSqlOnCompiere(getRequestedTableInformation);
        }

        public DataTable getC_ORDERLINEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string C_ORDER_ID, string C_ORDERLINE_ID, string C_TAX_ID,
            string M_PRODUCT_ID, triaStateBool ISDESCRIPTION, triaStateBool PROCESSED,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("C_ORDERLINE");
            }


            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE (ISACTIVE = 'Y' OR ISACTIVE = 'N')";

            whereClause = whereClause + " " + logicalConnector + 
                    " AD_CLIENT_ID = '" + generalResultInformation.clientId + "'";

            if (ISDESCRIPTION == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " ISDESCRIPTION = 'Y'";
            }
            else if (ISDESCRIPTION == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                    " ISDESCRIPTION = 'N'";

            if (PROCESSED == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " PROCESSED = 'Y'";
            }
            else if (PROCESSED == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                    " PROCESSED = 'N'";

            if (AD_ORG_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_ORG_ID = '" + AD_ORG_ID + "'";

            if (C_ORDER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_ORDER_ID = " + C_ORDER_ID;

            if (C_ORDERLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_ORDERLINE_ID = '" + C_ORDERLINE_ID + "'";

            if (C_TAX_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_TAX_ID = '" + C_TAX_ID + "'";

            if (M_PRODUCT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " M_PRODUCT_ID = '" + M_PRODUCT_ID + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_ORDERLINE " + whereClause;

            return (DataTable)executeSqlOnCompiere(getRequestedTableInformation);
        }
        

        public string getNextSequenceId(string Name, string AD_SEQUENCE_ID,
            string AD_ORG_ID, bool incrementToNextSequence)
        {
            string nextPrimaryKey = "";
            string preFix = "";
            string suffix = "";

            if (Name == "" && AD_SEQUENCE_ID == "")
                return "";            

            DataTable orgCriterion = new DataTable();
            if (AD_ORG_ID != "")
            {
                businessRule moveBusinessRule = new businessRule();
                string[] organisationList = { AD_ORG_ID };
                orgCriterion =
                    moveBusinessRule.buildOrganisationSelectionCriteria(organisationList, false);
            }

            DataTable sequenceRecord =
                this.getAD_SEQUENCEInfo(orgCriterion, "", "", AD_SEQUENCE_ID, Name, true, false, "AND");

            nextPrimaryKey = sequenceRecord.Rows[0]["CURRENTNEXT"].ToString();

            if (sequenceRecord.Rows[0]["ISTABLEID"].ToString() != "Y")
            {
                if (sequenceRecord.Rows[0]["PREFIX"].ToString() != "")
                    preFix = sequenceRecord.Rows[0]["PREFIX"].ToString();
                if (sequenceRecord.Rows[0]["SUFFIX"].ToString() != "")
                    suffix = sequenceRecord.Rows[0]["SUFFIX"].ToString();
            }

            if (incrementToNextSequence)
            {
                sequenceRecord.Rows[0]["CURRENTNEXT"] = int.Parse(nextPrimaryKey) + 1;
                this.changeDataBaseTableData(sequenceRecord, "AD_SEQUENCE", "Update");
            }

            return preFix + nextPrimaryKey + suffix;
        }

        public DataTable getAD_SEQUENCEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string AD_SEQUENCE_ID, string NAME, bool onlyActiveRecords,
             bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("AD_SEQUENCE");
            }


            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE (ISACTIVE = 'Y' || ISACTIVE = 'N')";

            if (AD_ORG_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_ORG_ID = " + AD_ORG_ID;

            if (AD_SEQUENCE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_SEQUENCE_ID = " + AD_SEQUENCE_ID;

            if (NAME != "")
                whereClause = whereClause + " " + logicalConnector +
                    " UPPER(NAME) = '" + NAME.ToUpperInvariant().Replace("'", "''") + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM AD_SEQUENCE " + whereClause;

            return (DataTable)executeSqlOnCompiere(getRequestedTableInformation);
        }

        public string[] changeDataBaseTableData(DataTable dataToEffectTheChange,
            string tableNameToChangeData, string dmlType)
        {
            string[] primaryKeysForNewInsertion =
                new string[dataToEffectTheChange.Rows.Count];

            if (primaryKeysForNewInsertion.Length > 0)
                primaryKeysForNewInsertion[0] = "";

            if (!this.checkIfTableContainesData(dataToEffectTheChange))
                return primaryKeysForNewInsertion;
            DataTable structureOfTableToChangeData = this.getDataTableStructure(tableNameToChangeData);
            if (structureOfTableToChangeData == null)
                return primaryKeysForNewInsertion;

            if (structureOfTableToChangeData.Columns.Count < 1)
                return primaryKeysForNewInsertion;


            string[] tablePrimaryKeys = this.getCompiereTablePrimaryKey(tableNameToChangeData);
            foreach (string primaryKey in tablePrimaryKeys)
                if (!dataToEffectTheChange.Columns.Contains(primaryKey))
                    return primaryKeysForNewInsertion;

            //Check if the given table has more than one row
            //.. if it does 
            // 1. Elemenate the last row from the copy table of 
            //the given table and re-call function with the copyed one
            // 2. then delete as much rows as the returned number of array elements
            // ....from the original table and re-call function.
            if (dataToEffectTheChange.Rows.Count > 1)
            {
                DataTable newDataTable = dataToEffectTheChange.Copy();
                newDataTable.Rows.RemoveAt(newDataTable.Rows.Count - 1);
                string[] resultTablePrimarykey1 =
                    this.changeDataBaseTableData(newDataTable, tableNameToChangeData, dmlType);

                int numberOfResult = resultTablePrimarykey1.Length;
                while (numberOfResult > 0)
                {
                    dataToEffectTheChange.Rows.RemoveAt(0);
                    numberOfResult--;
                }
                string[] resultTablePrimarykey2 =
                   this.changeDataBaseTableData(dataToEffectTheChange, tableNameToChangeData, dmlType);

                Array.Copy(resultTablePrimarykey1, 0,
                    primaryKeysForNewInsertion, 0,
                    resultTablePrimarykey1.Length);

                Array.Copy(resultTablePrimarykey2, 0,
                    primaryKeysForNewInsertion, resultTablePrimarykey1.Length,
                    resultTablePrimarykey2.Length);

                return primaryKeysForNewInsertion;
            }

            //Check if the Modifyied Table primary key fields contain data.
            //... if they do not, Generate New Primary key.
            string nextTablePrimaryKey = "";
            foreach (string primaryKey in tablePrimaryKeys)
                if (dataToEffectTheChange.Rows[0][primaryKey].ToString() == "")
                {
                    nextTablePrimaryKey = this.getNextSequenceId(tableNameToChangeData, "", "", true);
                    if (nextTablePrimaryKey != "")
                    {
                        dataToEffectTheChange.Rows[0][primaryKey] = nextTablePrimaryKey;
                        dmlType = "INSERT";
                        primaryKeysForNewInsertion[0] = primaryKeysForNewInsertion[0] +
                            primaryKey + " <(" + nextTablePrimaryKey + ")>||";
                    }
                    else
                        return primaryKeysForNewInsertion;
                }

            if (dmlType.ToUpper() == "INSERT")
            {
                if (!dataToEffectTheChange.Columns.Contains("CREATED"))
                    dataToEffectTheChange.Columns.Add("CREATED");

                if (!dataToEffectTheChange.Columns.Contains("CREATEDBY"))
                    dataToEffectTheChange.Columns.Add("CREATEDBY",Type.GetType("System.DateTime"));
                if(dataToEffectTheChange.Rows[0]["CREATED"].ToString() == "")
                    dataToEffectTheChange.Rows[0]["CREATED"] = DateTime.Now;
                if (dataToEffectTheChange.Rows[0]["CREATEDBY"].ToString() == "")
                    dataToEffectTheChange.Rows[0]["CREATEDBY"] = generalResultInformation.userId;
            }


            if (!dataToEffectTheChange.Columns.Contains("UPDATED"))
                dataToEffectTheChange.Columns.Add("UPDATED",
                    Type.GetType("System.DateTime"));

            if (!dataToEffectTheChange.Columns.Contains("UPDATEDBY"))
                dataToEffectTheChange.Columns.Add("UPDATEDBY");

            if(dataToEffectTheChange.Rows[0]["UPDATED"].ToString() == "")
                dataToEffectTheChange.Rows[0]["UPDATED"] = DateTime.Now;
            if (dataToEffectTheChange.Rows[0]["UPDATEDBY"].ToString() == "")
                dataToEffectTheChange.Rows[0]["UPDATEDBY"] = generalResultInformation.userId;


            for (int currentModifyDataTableColumn = dataToEffectTheChange.Columns.Count - 1;
                currentModifyDataTableColumn >= 0; currentModifyDataTableColumn--)
            {
                if (!structureOfTableToChangeData.Columns.Contains(
                    dataToEffectTheChange.Columns[currentModifyDataTableColumn].ColumnName))
                    dataToEffectTheChange.Columns.RemoveAt(currentModifyDataTableColumn);
            }

            string dmlStatementForTable = "";
            dmlStatementForTable =
                this.DMLScriptCreator(tableNameToChangeData, tablePrimaryKeys,
                this.removeEmptyColumnFromRow(dataToEffectTheChange), 0, dmlType.ToUpper());

            //Execute.

            if (dmlStatementForTable != "")
                this.executeSqlOnCompiere(dmlStatementForTable);

            //The return Array Format is arrayIndex[0]=|primaryKeyName1forRowOne<("theNewPrimaryKey")>|| ...
                //primaryKeyName2forRowOne<("theNewPrimaryKey")>|| ...,
            //arrayIndex[1]=|primaryKeyName1forRow2<("theNewPrimaryKey")>||
                //primaryKeyName2forRow2<("theNewPrimaryKey")>||...
            return primaryKeysForNewInsertion;
        }

        public void resetDbTableColumn(DataTable conditionCriterion, string tableName,
                string columnNameToReset, string resetValue)
        {
            string[] primaryKeys =
                this.getCompiereTablePrimaryKey(tableName);
            if (primaryKeys.Length <= 0)
                return;
            else if (primaryKeys[0] == "")
                return;

            DataTable tableStructure = this.getDataTableStructure(tableName);
            if (!tableStructure.Columns.Contains(columnNameToReset))
                return;
            string stCriterion = 
                this.createTheCriteriaClause(conditionCriterion,"AND","");
            string resetScript = "UPDATE " + tableName + " " +
                                 "SET " + columnNameToReset + " = '" + resetValue + "'";
            if (stCriterion != "")
                resetScript = resetScript + " WHERE " + stCriterion;

            this.executeSqlOnCompiere(resetScript);

        }
    }
        
}
