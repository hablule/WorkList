using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;



namespace dbConnection
{
    public class dataBuilder
    {
        //private string AD_CLIENT_ID = "";
        //private string AD_ORG_ID = "";
        //public string CREATED = DateTime.Now.ToString("dd-MMM-yyyy");
        //public string CREATEDBY = "1000000";
        //public string UPDATED = DateTime.Now.ToString("dd-MMM-yyyy");
        //public string UPDATEDBY = "1000000";
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
                        values += "TO_DATE(" + delimitingApostrophe + 
                            trsTime.ToString("dd-MMM-yyyy HH:mm:ss") +
                            delimitingApostrophe + ", 'dd-mm-yyyy HH24:MI:SS')" + theComma;
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
                            " = " + "TO_DATE(" + delimitingApostrophe +
                            trsTime.ToString("dd-MMM-yyyy HH:mm:ss") +
                            delimitingApostrophe + ", 'dd-mm-yyyy HH24:MI:SS')" + theComma;
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
                    filePath = dbSettingInformationHandler.scriptDirectory;
                    extension = ".srp";
                    break;
                case "compWARINING":
                    filePath = dbSettingInformationHandler.warningDirectory;
                    extension = ".wrn";
                    break;
                case "compERROR":
                    filePath = dbSettingInformationHandler.errorDirectory;
                    extension = ".err";
                    break;
                case "posSCRIPT":
                    filePath = dbSettingInformationHandler.scriptDirectory;
                    extension = ".srp";
                    break;
                case "posWARINING":
                    filePath = dbSettingInformationHandler.warningDirectory;
                    extension = ".wrn";
                    break;
                case "posERROR":
                    filePath = dbSettingInformationHandler.errorDirectory;
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
                
        public object executeSqlOnDB(string sqlCommand)
        {
            DataTable resultOfQuery= new DataTable();
            int rowsAffected = 0;
            persistanceClass compiereConnection;
            string connectionStatus;
            string oraDataBaseType = dbSettingInformationHandler.dbDataBaseType;
            string oraHostName = dbSettingInformationHandler.dbHostName;
            string oraDataBaseName = dbSettingInformationHandler.dataBaseName;
            string oraUserName = dbSettingInformationHandler.dbUsername;
            string oraPassWord = dbSettingInformationHandler.dbPassword;
            string oraPort = dbSettingInformationHandler.dbPort;

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
            DataTable primaryKey = (DataTable)this.executeSqlOnDB(getPrimaryKey);
            if (checkIfTableContainesData(primaryKey))
            {
                nextPrimaryKey = primaryKey.Rows[0][0].ToString();
                string setPrimaryKey = "UPDATE AD_SEQUENCE" +
                    " SET  CURRENTNEXT = CURRENTNEXT + 1" +
                    " WHERE UPPER(NAME) = '" + tableName.ToUpperInvariant() + "'";
                this.executeSqlOnDB(setPrimaryKey);
            }

            return nextPrimaryKey.ToString();
        }

        public string[] getTablePrimaryKey(string tableName)
        {
            string[] primarykeys = { "" };
            if (tableName == "C_BANKCHECK")
            { primarykeys = new string[] { "C_BANKCHECK_ID" }; }
            else if (tableName == "C_BANKCHECKLINE")
            { primarykeys = new string[] { "C_BANKCHECKLINE_ID" }; }
            else if (tableName == "AD_SEQUENCE")
            { primarykeys = new string[] { "AD_SEQUENCE_ID" }; }
            else if (tableName == "C_BANK")
            { primarykeys = new string[] { "C_BANK_ID" }; }
            else if (tableName == "C_BANKACCOUNT")
            { primarykeys = new string[] { "C_BANKACCOUNT_ID" }; }
            else if (tableName == "C_INVOICE")
            { primarykeys = new string[] { "C_INVOICE_ID" }; }
            else if (tableName == "C_INVOICELINE")
            { primarykeys = new string[] { "C_INVOICELINE_ID" }; }
            else if (tableName == "C_CHARGES")
            { primarykeys = new string[] { "C_CHARGES_ID" }; }
            else if (tableName == "C_CASHBOOK")
            { primarykeys = new string[] { "C_CASHBOOK_ID" }; }
            else if (tableName == "C_BPARTNER")
            { primarykeys = new string[] { "C_BPARTNER_ID" }; }
            else if (tableName == "C_BPARTNER_LOCATION")
            { primarykeys = new string[] { "C_BPARTNER_LOCATION_ID" }; }
            else if (tableName == "C_BP_VENDOR_ACCT")
            { primarykeys = new string[] { "C_BPARTNER_ID", "C_ACCTSCHEMA_ID" }; }
            else if (tableName == "C_BP_CUSTOMER_ACCT")
            { primarykeys = new string[] { "C_BPARTNER_ID", "C_ACCTSCHEMA_ID" }; }
            else if (tableName == "C_BP_EMPLOYEE_ACCT")
            { primarykeys = new string[] { "C_BPARTNER_ID", "C_ACCTSCHEMA_ID" }; }
            else if (tableName == "C_PAYMENT")
            { primarykeys = new string[] { "C_PAYMENT_ID" }; }
            else if (tableName == "C_PAYMENTALLOCATE")
            { primarykeys = new string[] { "C_PAYMENTALLOCATE_ID" }; }
            else if (tableName == "C_CASH")
            { primarykeys = new string[] { "C_CASH_ID" }; }
            else if (tableName == "C_CASHLINE")
            { primarykeys = new string[] { "C_CASHLINE_ID" }; }
            else if (tableName == "C_ALLOCATIONHDR")
            { primarykeys = new string[] { "C_ALLOCATIONHDR_ID" }; }
            else if (tableName == "C_ALLOCATIONLINE")
            { primarykeys = new string[] { "C_ALLOCATIONLINE_ID" }; }
            else if (tableName == "C_BANKCHECKMATCH")
            { primarykeys = new string[] { "C_BANKCHECKMATCH_ID" }; }
            else if (tableName == "AD_USER_ROLES")
            { primarykeys = new string[] { "AD_USER_ID", "AD_ROLE_ID" }; }


            return primarykeys;
        }

        public DataTable getDataTableStructure(string tableName)
        {

            string[] Tableprimarykeys = this.getTablePrimaryKey(tableName);

            string theWhereClose = "";
            if (Tableprimarykeys.Length > 0)
                if (Tableprimarykeys[0] != "")
                    theWhereClose = "WHERE ";
            foreach (string primaryKey in Tableprimarykeys)
            {
                if (primaryKey != "")
                    theWhereClose = theWhereClose + primaryKey + " = '0'" + " AND ";
            }
            theWhereClose = theWhereClose.Remove(theWhereClose.LastIndexOf("AND"), 3);
            string getStructureForTable = "SELECT *" +
                                          " FROM " + tableName + " " + theWhereClose;
            DataTable result = (DataTable)executeSqlOnDB(getStructureForTable);
            result.Clear();
            return result;
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


        public DataTable clearRedundantRow(DataTable tableToClear)
        {
            return this.clearRedundantRow(tableToClear, "");
        }

        public DataTable clearRedundantRow(DataTable tableToClear, string keyColumn)
        {
            return this.clearRedundantRow(tableToClear, keyColumn, new string[] { "" });
        }

        public DataTable clearRedundantRow(DataTable tableToClear, string keyColumn, string[] keyColumns)
        {
            if (!this.checkIfTableContainesData(tableToClear))
                return tableToClear;
            bool rowIsRedundant = true;
            for (int rowCounter = tableToClear.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                for (int rowCounter2 = rowCounter - 1;
                    rowCounter2 >= 0; rowCounter2--)
                {
                    rowIsRedundant = true;
                    if (keyColumn != "")
                    {
                        if (tableToClear.Columns.Contains(keyColumn))
                        {
                            if (tableToClear.Rows[rowCounter][keyColumn].ToString() !=
                                tableToClear.Rows[rowCounter2][keyColumn].ToString())
                            {
                                rowIsRedundant = false;
                                break;
                            }
                        }
                    }
                    else if (keyColumns.Length > 0)
                    {
                        foreach (string keyName in keyColumns)
                        {
                            if (tableToClear.Columns.Contains(keyName))
                            {
                                if (tableToClear.Rows[rowCounter][keyName].ToString() !=
                                tableToClear.Rows[rowCounter2][keyName].ToString())
                                {
                                    rowIsRedundant = false;
                                    break;
                                }
                            }
                            else
                            {
                                rowIsRedundant = false;
                            }
                        }
                    }
                    else
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

        //Function to generate word equivelent of digits

        public String changeToWords(String numb, bool isCurrency)
        {
            String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "",
                wholeStr = "", begStr = "Birr";
            String endStr = (isCurrency) ? ("Only") : ("");
            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (numb.Contains("."))
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = (isCurrency) ? ("and") : ("point");// just to separate whole numbers from points
                        endStr = (isCurrency) ? ("cents " + endStr) : ("");
                        pointStr = translatePoints(points);
                        pointStr = pointStr.Trim();
                    }
                }
                if (wholeNo == "")
                    wholeNo = "0";
                if (Convert.ToInt32(wholeNo) <= 0)
                { andStr = ""; begStr = ""; }
                else
                {
                    wholeStr = translateWholeNumber(wholeNo).Trim();
                }
                val = String.Format("{0} {1} {2} {3} {4}", begStr, wholeStr, andStr, pointStr, endStr);
                val = val.Replace("   ", " ");

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            return val.Trim();
        }

        private String translateWholeNumber(String number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;//tests for 0XX
                bool isDone = false;//test if already translated
                double dblAmt = (Convert.ToDouble(number));
                //if ((dblAmt > 0) && number.StartsWith("0"))

                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric
                    beginsZero = number.StartsWith("0");
                    while (beginsZero)
                    {
                        if (number.Length > 1)
                            number = number.Substring(1);
                        beginsZero = number.StartsWith("0");
                    }
                    int numDigits = number.Length;
                    int pos = 0;//store digit grouping
                    String place = "";//digit grouping name:hundres,thousand,etc...
                    switch (numDigits)
                    {
                        case 1://ones' range
                            word = ones(number);
                            isDone = true;
                            break;
                        case 2://tens' range
                            word = tens(number);
                            isDone = true;
                            break;
                        case 3://hundreds' range
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands' range
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 7://millions' range
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10://Billions's range
                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        //add extra case options for anything above Billion...
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {//if transalation is not done, continue...(Recursion comes in now!!)
                        word = translateWholeNumber(number.Substring(0, pos)) + place + translateWholeNumber(number.Substring(pos));
                        //check for trailing zeros
                        //if (beginsZero) word = " and " + word.Trim();
                        if (beginsZero) word = word.Trim();
                    }
                    //ignore digit grouping names
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch
            {
                ;
            }
            return word.Trim();
        }

        private String tens(String digit)
        {
            int digt = Convert.ToInt32(digit);
            String name = null;
            switch (digt)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (digt > 0)
                    {
                        name = tens(digit.Substring(0, 1) + "0") + " " + ones(digit.Substring(1));
                    }
                    break;
            }
            return name;
        }

        private String ones(String digit)
        {
            int digt = Convert.ToInt32(digit);
            String name = "";
            switch (digt)
            {
                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }

        private String translatePoints(String decimals)
        {
            //String cts = "", digit = "", engOne = "";
            //for (int i = 0; i < decimals.Length; i++)
            //{
            //    digit = decimals[i].ToString();
            //    if (digit.Equals("0"))
            //    {
            //        engOne = "Zero";
            //    }
            //    else
            //    {
            //        engOne = ones(digit);
            //    }
            //    cts += " " + engOne;
            //}
            if (decimals.Length == 1)
                decimals = decimals + "0";
            decimals = decimals.Trim();
            String cts = this.translateWholeNumber(decimals);
            return cts;
        }

        //


        //Pos Table info
        



        #region "Application Specific Data Fetch"

        public DataTable getOpenBalanceInfo(string C_INVOICE_ID)
        {
            if (C_INVOICE_ID == "")
                return null;

            string getRequestedTableInformation = "SELECT * " +
                                           "FROM RV_OPENITEM " +
                                           "WHERE C_INVOICE_ID = " + C_INVOICE_ID;

            return (DataTable) executeSqlOnDB(getRequestedTableInformation);

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

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
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

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }

        public DataTable getAD_USERInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_USER_ID, string UserName, string PassWord, string LDAPUSER, bool onlyActiveRecords,
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

            if (LDAPUSER != "")
                whereClause = whereClause + " " + logicalConnector +
                    " LDAPUSER = '" + LDAPUSER.Replace("'", "''") + "'";

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM AD_USER " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }

        public DataTable getAD_USER_ROLESInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_USER_ID, string AD_ROLE_ID, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("AD_USER_ROLES");
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

            if (AD_ROLE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_ROLE_ID = '" + AD_ROLE_ID + "'";
            
            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM AD_USER_ROLES " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }


        public DataTable getC_BPARTNERInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string C_BPARTNER_ID, string NAME, triStateBool ISVENDOR,
            triStateBool ISCUSTOMER, triStateBool ISEMPLOYEE, triStateBool ISSALESREP,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("C_BPARTNER");
            }


            string whereClause = "WHERE ROWNUM < 30 AND ";

            if (onlyActiveRecords)
            {
                whereClause = whereClause + " ISACTIVE = 'Y'";
            }
            else
                whereClause = whereClause + " (ISACTIVE = 'Y' OR ISACTIVE = 'N')";

            whereClause = whereClause + " " + logicalConnector + " AD_CLIENT_ID = '" + generalResultInformation.clientId + "'";

            if (ISVENDOR == triStateBool.yes)
                whereClause = whereClause + " " + logicalConnector +
                            " ISVENDOR = 'Y'";
            else if (ISVENDOR == triStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                            " ISVENDOR = 'N'";

            if (ISCUSTOMER == triStateBool.yes)
                whereClause = whereClause + " " + logicalConnector +
                    " ISCUSTOMER = 'Y'";
            else if (ISCUSTOMER == triStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                    " ISCUSTOMER = 'N'";


            if (ISEMPLOYEE == triStateBool.yes)
                whereClause = whereClause + " " + logicalConnector +
                    " ISEMPLOYEE = 'Y'";
            else if (ISEMPLOYEE == triStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                    " ISEMPLOYEE = 'N'";

            if (ISSALESREP == triStateBool.yes)
                whereClause = whereClause + " " + logicalConnector +
                    " ISSALESREP = 'Y'";
            else if (ISSALESREP == triStateBool.no)
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
                    " UPPER(NAME) LIKE '%" + NAME.Replace("'", "''").ToUpper() + "%'";

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_BPARTNER " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }


        public DataTable getC_BPARTNER_LOCATIONInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string C_BPARTNER_ID, string NAME, string C_LOCATION_ID,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("C_BPARTNER_LOCATION");
            }

            string whereClause = "WHERE ROWNUM < 30 AND ";

            if (onlyActiveRecords)
            {
                whereClause = whereClause + " ISACTIVE = 'Y'";
            }
            else
                whereClause = whereClause + " (ISACTIVE = 'Y' OR ISACTIVE = 'N')";

            whereClause = whereClause + " " + logicalConnector + " AD_CLIENT_ID = '" + generalResultInformation.clientId + "'";

            if (AD_ORG_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_ORG_ID = '" + AD_ORG_ID + "'";

            if (C_BPARTNER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_BPARTNER_ID = " + C_BPARTNER_ID;

            if (C_LOCATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_LOCATION_ID = " + C_LOCATION_ID;

            if (NAME != "")
                whereClause = whereClause + " " + logicalConnector +
                    " UPPER(NAME) LIKE '%" + NAME.Replace("'", "''").ToUpper() + "%'";

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_BPARTNER_LOCATION " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }


        public DataTable getC_INVOICEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string C_INVOICE_ID, string C_ORDER_ID, string C_DOCTYPE_ID, string C_DOCTYPETARGET_ID,
            string C_PAYMENT_ID, string DOCACTION, string DOCSTATUS, string DOCUMENTNO, string C_BPARTNER_ID, 
            triStateBool ISPAID, triStateBool ISSOTRX, triStateBool PROCESSED, string PAYMENTRULE,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
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

            if (ISSOTRX != triStateBool.Ignor)
            {
                if (ISSOTRX == triStateBool.yes)
                {
                    whereClause = whereClause + " " + logicalConnector +
                        " ISSOTRX = 'Y'";
                }
                else if (ISSOTRX == triStateBool.no)
                    whereClause = whereClause + " " + logicalConnector +
                        " ISSOTRX = 'N'";
            }

            if (ISPAID != triStateBool.Ignor)
            {
                if (ISPAID == triStateBool.yes)
                {
                    whereClause = whereClause + " " + logicalConnector +
                        " ISPAID = 'Y'";
                }
                else if (ISPAID == triStateBool.no)
                    whereClause = whereClause + " " + logicalConnector +
                        " ISPAID = 'N'";
            }
            
            if (PROCESSED != triStateBool.Ignor)
            {
                if (PROCESSED == triStateBool.yes)
                {
                    whereClause = whereClause + " " + logicalConnector +
                        " PROCESSED = 'Y'";
                }
                else if (PROCESSED == triStateBool.no)
                    whereClause = whereClause + " " + logicalConnector +
                        " PROCESSED = 'N'";
            }

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

            if (C_BPARTNER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_BPARTNER_ID = " + C_BPARTNER_ID;


            if (DOCACTION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " DOCACTION = '" + DOCACTION + "'";

            if (DOCSTATUS != "")
                whereClause = whereClause + " " + logicalConnector +
                    " DOCSTATUS = '" + DOCSTATUS + "'";

            if (PAYMENTRULE != "")
                whereClause = whereClause + " " + logicalConnector +
                    " PAYMENTRULE = '" + PAYMENTRULE + "'";

            if (DOCUMENTNO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " DOCUMENTNO LIKE '%" + DOCUMENTNO.Replace("'", "''") + "%'";

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector) + " AND ROWNUM <= 30";

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_INVOICE " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }

        public DataTable getInvoicePaidAmount(string C_INVOICE_ID)
        {
            if (C_INVOICE_ID == "")
                return null;

            string getRequestedTableInformation = "SELECT INVOICEPAID(" + C_INVOICE_ID + ", 204, 1) " +
                                                  "FROM DUAL ";

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);

        }


        public DataTable getC_CHARGEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string C_CHARGE_ID, string NAME, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            return this.getC_CHARGEInfo(criteriaTable, criteriaTableLogicalConnector, AD_ORG_ID, 
                    C_CHARGE_ID, NAME, triStateBool.Ignor, onlyActiveRecords, 
                    structureOnly, logicalConnector);
        }


        public DataTable getC_CHARGEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string C_CHARGE_ID, string NAME, triStateBool ISCOST,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
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

            if (ISCOST != triStateBool.Ignor)
            {
                if (ISCOST == triStateBool.yes)
                    whereClause = whereClause + " " + logicalConnector +
                        " ISCOST = 'Y'";
                else
                    whereClause = whereClause + " " + logicalConnector +
                        " ISCOST = 'N'";
            }

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_CHARGE " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }
        

        public DataTable getC_BANKInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
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

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }

        public DataTable getC_BANKACCOUNTInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
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

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }
        


        public DataTable getC_BANKCHECKInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_BANKCHECK_ID, string DOCUMENTNO, string C_BANKACCOUNT_ID,
            string CHECKNO, string C_BPARTNER_ID, DateTime DATETRX, bool useDate,
            triStateBool ISALLOCATED, triStateBool ISISSUED, 
            bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            return this.getC_BANKCHECKInfo(criteriaTable, criteriaTableLogicalConnector, C_BANKCHECK_ID, 
                DOCUMENTNO, C_BANKACCOUNT_ID, CHECKNO, C_BPARTNER_ID, DATETRX, useDate, ISALLOCATED, 
                ISISSUED, false, onlyActiveRecords, structureOnly, logicalConnector); 
        }


        public DataTable getC_BANKCHECKInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_BANKCHECK_ID, string DOCUMENTNO, string C_BANKACCOUNT_ID,
            string CHECKNO, string C_BPARTNER_ID, DateTime DATETRX, bool useDate,
            triStateBool ISALLOCATED, triStateBool ISISSUED,
            bool onlyLastRecord, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("C_BANKCHECK");
            }

            if (onlyLastRecord)
            {
                

                if (C_BANKACCOUNT_ID != "")
                {
                    getRequestedTableInformation = "SELECT * " +
                                               "FROM C_BANKCHECK " +
                                               "WHERE C_BANKCHECK_ID = " +
                                                    "(" +
                                                        "SELECT MAX(C_BANKCHECK_ID) " +
                                                        "FROM C_BANKCHECK " +
                                                        "WHERE C_BANKACCOUNT_ID = " + C_BANKACCOUNT_ID +
                                                    " )";
                }
                else
                {
                    getRequestedTableInformation = "SELECT * " +
                                                   "FROM C_BANKCHECK " +
                                                   "WHERE C_BANKCHECK_ID = " +
                                                   "(SELECT MAX(C_BANKCHECK_ID) FROM C_BANKCHECK)";
                }
                
                return (DataTable)executeSqlOnDB(getRequestedTableInformation);
            }


            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE (ISACTIVE = 'Y' OR ISACTIVE = 'N')";

            whereClause = whereClause + " " + logicalConnector + " AD_CLIENT_ID = '" + generalResultInformation.clientId + "'";

            if (C_BANKCHECK_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_BANKCHECK_ID = '" + C_BANKCHECK_ID + "'";

            if (C_BPARTNER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_BPARTNER_ID = '" + C_BPARTNER_ID + "'";

            if (C_BANKACCOUNT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_BANKACCOUNT_ID = '" + C_BANKACCOUNT_ID + "'";

            if (DOCUMENTNO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " DOCUMENTNO LIKE '%" + DOCUMENTNO.Replace("'", "''") + "%'";

            if (CHECKNO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " CHECKNO LIKE '%" + CHECKNO.Replace("'", "''") + "%'";

            if (useDate)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " DATETRX = '" + DATETRX.ToString("dd-MMM-yyyy") + "'";
            }

            if (ISALLOCATED != triStateBool.Ignor)
            {
                if (ISALLOCATED == triStateBool.yes)
                    whereClause = whereClause + " " + logicalConnector +
                        " ISALLOCATED = 'Y'";
                else
                    whereClause = whereClause + " " + logicalConnector +
                        " ISALLOCATED = 'N'";
            }


            if (ISISSUED != triStateBool.Ignor)
            {
                if (ISISSUED == triStateBool.yes)
                    whereClause = whereClause + " " + logicalConnector +
                        " ISISSUED = 'Y'";
                else
                    whereClause = whereClause + " " + logicalConnector +
                        " ISISSUED = 'N'";
            }

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_BANKCHECK " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }


        public DataTable getC_BANKCHECKLINEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_BANKCHECKLINE_ID, string C_BANKCHECK_ID, string C_INVOICE_ID,
            string C_CHARGE_ID, triStateBool ISCOST,
            bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("C_BANKCHECKLINE");
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE (ISACTIVE = 'Y' OR ISACTIVE = 'N')";

            whereClause = whereClause + " " + logicalConnector + " AD_CLIENT_ID = '" + generalResultInformation.clientId + "'";

            if (C_BANKCHECKLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_BANKCHECKLINE_ID = '" + C_BANKCHECKLINE_ID + "'";

            if (C_BANKCHECK_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_BANKCHECK_ID = '" + C_BANKCHECK_ID + "'";
            

            if (C_INVOICE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_INVOICE_ID = '" + C_INVOICE_ID + "'";

            if (C_CHARGE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_CHARGE_ID = '" + C_CHARGE_ID + "'";

            if (ISCOST != triStateBool.Ignor)
            {
                if (ISCOST == triStateBool.yes)
                    whereClause = whereClause + " " + logicalConnector +
                        " ISCOST = 'Y'";
                else
                    whereClause = whereClause + " " + logicalConnector +
                        " ISCOST = 'N'";
            }
             

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_BANKCHECKLINE " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }


        public DataTable getC_CASHBOOKInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_CASHBOOK_ID, string NAME, bool onlyActiveRecords, 
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

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }


        public DataTable getC_PAYMENTInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string C_PAYMENT_ID, string C_DOCTYPE_ID, string C_ORDER_ID,
            string C_INVOICE_ID, string DOCACTION, string DOCSTATUS,
            string DOCUMENTNO, triStateBool ISRECEIPT, triStateBool PROCESSED,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("C_PAYMENT");
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

            if (ISRECEIPT == triStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " ISRECEIPT = 'Y'";
            }
            else if (ISRECEIPT == triStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                    " ISRECEIPT = 'N'";

            if (PROCESSED == triStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " PROCESSED = 'Y'";
            }
            else if (PROCESSED == triStateBool.no)
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

            if (C_INVOICE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_INVOICE_ID = '" + C_INVOICE_ID + "'";

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
                    " DOCUMENTNO LIKE '%" + DOCUMENTNO.Replace("'", "''") + "%'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_PAYMENT " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }


        public DataTable getC_PAYMENTALLOCATEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string C_PAYMENT_ID, string C_PAYMENTALLOCATE_ID, string C_INVOICE_ID,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("C_PAYMENTALLOCATE");
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

            
            if (AD_ORG_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_ORG_ID = '" + AD_ORG_ID + "'";


            if (C_PAYMENTALLOCATE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_PAYMENTALLOCATE_ID = '" + C_PAYMENTALLOCATE_ID + "'";

            if (C_INVOICE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_INVOICE_ID = '" + C_INVOICE_ID + "'";

            if (C_PAYMENT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_PAYMENT_ID = '" + C_PAYMENT_ID + "'";
                       

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_PAYMENTALLOCATE " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }


        public DataTable getC_ALLOCATIONLINEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string C_ALLOCATIONLINE_ID, string C_ALLOCATIONHDR_ID,
            string C_ORDER_ID, string C_CASHLINE_ID, 
            string C_PAYMENT_ID, string C_BPARTNER_ID, string C_INVOICE_ID,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("C_ALLOCATIONLINE");
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


            if (AD_ORG_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_ORG_ID = '" + AD_ORG_ID + "'";

            if (C_ALLOCATIONLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_ALLOCATIONLINE_ID = '" + C_ALLOCATIONLINE_ID + "'";

            if (C_ALLOCATIONHDR_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_ALLOCATIONHDR_ID = '" + C_ALLOCATIONHDR_ID + "'";

            if (C_ORDER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_ORDER_ID = '" + C_ORDER_ID + "'";

            if (C_CASHLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_CASHLINE_ID = '" + C_CASHLINE_ID + "'";

            if (C_BPARTNER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_BPARTNER_ID = '" + C_BPARTNER_ID + "'";

            if (C_INVOICE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_INVOICE_ID = '" + C_INVOICE_ID + "'";

            if (C_PAYMENT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_PAYMENT_ID = '" + C_PAYMENT_ID + "'";

            
            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_ALLOCATIONLINE " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }


        public DataTable getC_CASHInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string C_CASH_ID, string C_CASHBOOK_ID, DateTime STATEMENTDATE, bool useDate,
            string DOCACTION, string DOCSTATUS,
            string NAME, triStateBool PROCESSED,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("C_CASH");
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

            
            if (PROCESSED == triStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " PROCESSED = 'Y'";
            }
            else if (PROCESSED == triStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                    " PROCESSED = 'N'";



            if (AD_ORG_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_ORG_ID = '" + AD_ORG_ID + "'";
                        
            if (C_CASHBOOK_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_CASHBOOK_ID = '" + C_CASHBOOK_ID + "'";

            if (C_CASH_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_CASH_ID = '" + C_CASH_ID + "'";

            if (DOCACTION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " DOCACTION = '" + DOCACTION + "'";

            if (DOCSTATUS != "")
                whereClause = whereClause + " " + logicalConnector +
                    " DOCSTATUS = '" + DOCSTATUS + "'";

            if (NAME != "")
                whereClause = whereClause + " " + logicalConnector +
                    " NAME LIKE '%" + NAME.Replace("'", "''") + "%'";

            if (useDate)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " STATEMENTDATE = '" + STATEMENTDATE.ToString("dd-MMM-yyyy") + "'";
            }


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_CASH " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }


        public DataTable getC_CASHLINEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string C_CASH_ID, string C_CASHLINE_ID,
            string C_BANKACCOUNT_ID, string C_CHARGE_ID,
            string C_INVOICE_ID, string CASHTYPE, triStateBool PROCESSED,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("C_CASHLINE");
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


            if (PROCESSED == triStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " PROCESSED = 'Y'";
            }
            else if (PROCESSED == triStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                    " PROCESSED = 'N'";



            if (AD_ORG_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_ORG_ID = '" + AD_ORG_ID + "'";

            if (C_CASHLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_CASHLINE_ID = '" + C_CASHLINE_ID + "'";

            if (C_CASH_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_CASH_ID = '" + C_CASH_ID + "'";

            if (C_BANKACCOUNT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_BANKACCOUNT_ID = '" + C_BANKACCOUNT_ID + "'";

            if (C_CHARGE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_CHARGE_ID = '" + C_CHARGE_ID + "'";

            if (CASHTYPE != "")
                whereClause = whereClause + " " + logicalConnector +
                    " CASHTYPE = '" + CASHTYPE + "'";


            if (C_INVOICE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_INVOICE_ID = '" + C_INVOICE_ID + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_CASHLINE " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }

        public DataTable getC_ORDERInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string C_ORDER_ID, string C_DOCTYPE_ID, string C_DOCTYPETARGET_ID,
            string C_PAYMENT_ID, string DOCACTION, string DOCSTATUS, string DOCUMENTNO,
            triStateBool ISSOTRX, triStateBool PROCESSED, bool onlyActiveRecords,
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
                whereClause = "WHERE ROWNUM < 30 AND ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE ROWNUM < 30 AND (ISACTIVE = 'Y' OR ISACTIVE = 'N')";

            whereClause = whereClause + " " + logicalConnector + " AD_CLIENT_ID = '" + generalResultInformation.clientId + "'";

            if (ISSOTRX == triStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " ISSOTRX = 'Y'";
            }
            else if (ISSOTRX == triStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                    " ISSOTRX = 'N'";

            if (PROCESSED == triStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " PROCESSED = 'Y'";
            }
            else if (PROCESSED == triStateBool.no)
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
                    " DOCUMENTNO LIKE '%" + DOCUMENTNO.Replace("'", "''") + "%'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_ORDER " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }

        public decimal getPaymentRemainingAmount(string C_PAYMENT_ID)
        {
            if (C_PAYMENT_ID == "")
                return 0;

            string getRequestedTableInformation = "";

            getRequestedTableInformation = "SELECT SUM(AMOUNT) " +
                                          "FROM C_PAYMENTALLOCATE " +
                                          "WHERE C_PAYMENT_ID = " + C_PAYMENT_ID;
            DataTable paymentAllocationInfo =
                (DataTable)executeSqlOnDB(getRequestedTableInformation);

            decimal allocatedPaymentAmount = 0;
            if (checkIfTableContainesData(paymentAllocationInfo))
            {
                allocatedPaymentAmount =
                    decimal.Parse(paymentAllocationInfo.Rows[0][0].ToString());
            }

            DataTable paymentInfo = 
                this.getC_PAYMENTInfo(null, "", "", C_PAYMENT_ID,
                    "", "", "", "", "", "", triStateBool.Ignor, triStateBool.Ignor,
                    false, false, "AND");

            if (!checkIfTableContainesData(paymentInfo))
            {
                return 0;
            }

            if (paymentInfo.Rows[0]["C_CHARGE_ID"].ToString() != "" ||
                paymentInfo.Rows[0]["C_INVOICE_ID"].ToString() != "")
            {
                return 0;
            }

            return Decimal.Parse(paymentInfo.Rows[0]["PAYAMT"].ToString()) - allocatedPaymentAmount;

        }
        

        #endregion
        
        
        public string getNextSequenceId(string Name, string AD_SEQUENCE_ID,
            string AD_ORG_ID, bool incrementToNextSequence)
        {
            return this.getNextSequenceId(Name, AD_SEQUENCE_ID, AD_ORG_ID, "", incrementToNextSequence);
        }

        public string getNextSequenceId(string Name, string AD_SEQUENCE_ID,
            string AD_ORG_ID, string AD_CLIENT_ID, bool incrementToNextSequence)
        {
            string nextPrimaryKey = "";
            string preFix = "";
            string suffix = "";

            if (Name == "" && AD_SEQUENCE_ID == "")
                return "";

            DataTable sequenceRecord =
                this.getAD_SEQUENCEInfo(null, "", "", AD_CLIENT_ID, AD_SEQUENCE_ID, Name, true, false, "AND");

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
            string AD_ORG_ID, string AD_CLIENT_ID, string AD_SEQUENCE_ID, string NAME, bool onlyActiveRecords,
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
                whereClause = "WHERE  ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE  (ISACTIVE = 'Y' || ISACTIVE = 'N')";

            if (AD_ORG_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_ORG_ID = " + AD_ORG_ID;

            if (AD_CLIENT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_CLIENT_ID = " + AD_CLIENT_ID;

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

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
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


            string[] tablePrimaryKeys = this.getTablePrimaryKey(tableNameToChangeData);
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
                //if(dataToEffectTheChange.Rows[0]["CREATED"].ToString() == "")
                //    dataToEffectTheChange.Rows[0]["CREATED"] = DateTime.Now;
                //if (dataToEffectTheChange.Rows[0]["CREATEDBY"].ToString() == "")
                //    dataToEffectTheChange.Rows[0]["CREATEDBY"] = generalResultInformation.userId;

                dataToEffectTheChange.Rows[0]["CREATED"] = DateTime.Now;
                dataToEffectTheChange.Rows[0]["CREATEDBY"] = generalResultInformation.userId;
            }


            if (!dataToEffectTheChange.Columns.Contains("UPDATED"))
                dataToEffectTheChange.Columns.Add("UPDATED",
                    Type.GetType("System.DateTime"));

            if (!dataToEffectTheChange.Columns.Contains("UPDATEDBY"))
                dataToEffectTheChange.Columns.Add("UPDATEDBY");

            //if(dataToEffectTheChange.Rows[0]["UPDATED"].ToString() == "")
            //    dataToEffectTheChange.Rows[0]["UPDATED"] = DateTime.Now;
            //if (dataToEffectTheChange.Rows[0]["UPDATEDBY"].ToString() == "")
            //    dataToEffectTheChange.Rows[0]["UPDATEDBY"] = generalResultInformation.userId;

            dataToEffectTheChange.Rows[0]["UPDATED"] = DateTime.Now;
            dataToEffectTheChange.Rows[0]["UPDATEDBY"] = generalResultInformation.userId;

            if (!dataToEffectTheChange.Columns.Contains("AD_CLIENT_ID"))
                dataToEffectTheChange.Columns.Add("AD_CLIENT_ID",
                    Type.GetType("System.int"));

            dataToEffectTheChange.Rows[0]["AD_CLIENT_ID"] = generalResultInformation.clientId;

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
                this.executeSqlOnDB(dmlStatementForTable);

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
                this.getTablePrimaryKey(tableName);
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

            this.executeSqlOnDB(resetScript);

        }
    }
        
}
