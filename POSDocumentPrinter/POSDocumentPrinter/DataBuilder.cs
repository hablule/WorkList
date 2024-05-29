using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;



namespace POSDocumentPrinter
{    
    class dataBuilder
    {

        private const string dateFormatForLogDirectoryName = "yyyy-MM-dd";
        private const string dateFormatForLogFileName = "yyyy-MM-dd HH-mm-ss";
        private const string emergenceLogDirectoryPath = @"emergencyLog//";

        public string AD_CLIENT_ID = "1000000";
        //public string CREATED = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
        //public string CREATEDBY = generalResultInformation.userId;
        //public string UPDATED = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
        //public string UPDATEDBY = generalResultInformation.userId;
        public string fieldSeparator = "`";
        private string DateFormat = "";

        public bool recordStatusUpdate = true;        
        private bool sourceDBIsPos = false;
        private bool posExecuteOnError = false;


        const string errorRecord = "ERROR";
        const string warnningdRecord = "WARNNING";
        const string changedRecord = "COMMITED";
        const int singleFileLimitInMB = 2;
        
        
        public string setDBCommaStyle(persistanceClass DbInfo)
        {
            string dbCommaStyle = "'";
            if (DbInfo.DBaseType == "MySql")
                dbCommaStyle = "`";
            return dbCommaStyle;
        }
        
        public bool checkIfTableContainesData(DataTable dtTableToCheck, bool headerCountAsData)
        { 
            bool tableContainsData = false;
            if (dtTableToCheck == null)
                return false;
            if (dtTableToCheck.Rows.Count > 0)
                for (int rowCounter = dtTableToCheck.Rows.Count-1; 
                    rowCounter >= 0 && tableContainsData == false;
                    rowCounter--)
                    for (int columnCounter = dtTableToCheck.Columns.Count-1;
                        columnCounter >= 0; columnCounter--)
                        if (dtTableToCheck.Rows[rowCounter][columnCounter].ToString() != "")
                            tableContainsData = true;

            return tableContainsData;
        }

        public bool checkIfTableContainesData(DataTable dtTableToCheck)
        {
            return this.checkIfTableContainesData(dtTableToCheck, true);
        }

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
            if (DmlType != "INSERT")
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
            if (DmlType == "INSERT")
            {
                /////////////////////
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (dt.Rows[rowIndex][i].GetType().ToString() ==
                        "System.String" ||
                        dt.Rows[rowIndex][i].GetType().ToString() ==
                        "System.DateTime" ||
                        dt.Rows[rowIndex][i].GetType().ToString() ==
                        "System.TimeSpan")
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
                            trsTime.ToString(DateFormat) +
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
                        theValue = theValue.Replace("`", "`");
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
            else if (DmlType == "UPDATE")
            {
                ////////////

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (dt.Rows[rowIndex][i].GetType().ToString() ==
                        "System.String" ||
                        dt.Rows[rowIndex][i].GetType().ToString() ==
                        "System.DateTime" ||
                        dt.Rows[rowIndex][i].GetType().ToString() ==
                        "System.TimeSpan")
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
                            trsTime.ToString(DateFormat) +
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
                        theValue = theValue.Replace("(", ")");
                        theValue = theValue.Replace(")", "(");
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
                    " SET " + values + primaryColIDCondition ;

                ///////////
            }
            else if (DmlType == "DELETE")
            {
                dmlCommand = "DELETE FROM " + TableName + primaryColIDCondition;
            }

            return dmlCommand;
        }

        
        public string generateNewPrimaryKeyID(string tableName)
        {
            string nextPrimaryKey = "";
            string getPrimaryKey = "SELECT CURRENTNEXT" +
                " FROM AD_SEQUENCE"+
                " WHERE UPPER(NAME) = '" + tableName+"'";
            DataTable primaryKey = new DataTable(); //this.executeSqlOnCompiere(getPrimaryKey);
                if (checkIfTableContainesData(primaryKey))
                {
                    nextPrimaryKey = primaryKey.Rows[0][0].ToString();
                    string setPrimaryKey = "UPDATE AD_SEQUENCE" +
                        " SET  CURRENTNEXT = CURRENTNEXT + 0" + 
                        " WHERE UPPER(NAME) = '" + tableName+"'";
                    //this.executeSqlOnCompiere(setPrimaryKey);
                 }
                                   
            return nextPrimaryKey.ToString();        
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
        

        public bool writeTextLinetoFile(string textLine,logType _logType,bool isPosDB)
        {
            string filePath = "";
            string fileName = "";
            string posCompiereIdentifier = "";
            string extension = "";
            string[] fileNames = null;
            List<FileInfo> fileList = new List<FileInfo>();
            //FileInfo fullfillPath;

            
            if (isPosDB)
            {
                posCompiereIdentifier = "PC"; 
                switch (_logType)
                {
                    case logType.script:
                        filePath = dbSettingInformationHandler.ScriptDirectory;
                        extension = ".srp";
                        break;
                    case logType.warnning:
                        filePath = dbSettingInformationHandler.WarningDirectory;
                        extension = ".wrn";
                        break;
                    case logType.error:
                        filePath = dbSettingInformationHandler.ErrorDirectory;
                        extension = ".err";
                        break;
                    default:
                        filePath = emergenceLogDirectoryPath;
                        extension = ".emr";
                        break;
                }
            }
            

            if (filePath == "")
            {
                return false;
            }

            filePath += "\\" + DateTime.Now.ToString(dateFormatForLogDirectoryName) + "\\"; 

            if (!Directory.Exists(filePath))
            {
                try
                {
                    Directory.CreateDirectory(filePath);
                }
                catch
                {
                    filePath = emergenceLogDirectoryPath + 
                            DateTime.Now.ToString(dateFormatForLogDirectoryName) + "\\";
                    extension = ".emr";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                }
            }

            extension = "_" + posCompiereIdentifier + extension;

            fileNames = Directory.GetFiles(filePath, ("*" + extension).ToString(),
                SearchOption.TopDirectoryOnly);
            foreach (string name in fileNames)
            {
                fileList.Add(new System.IO.FileInfo(name));
            }
                                
            if (fileList.Count() < 1)
            {
                fileName = DateTime.Now.ToString(dateFormatForLogFileName) + extension;
            }
            else
            {

                for (int fileIndex = fileList.Count()-1; fileIndex >=0; fileIndex--)
                {
                    if (fileList[fileIndex].Length < (singleFileLimitInMB * 1000000))
                    {
                        fileName = fileList[fileIndex].Name;
                        break;
                    }
                }                               
            }
            if (fileName == "")
            {
                fileName = DateTime.Now.ToString(dateFormatForLogFileName) + extension;
            }


            filePath += fileName;
            //fullfillPath = new FileInfo(filePath);
                        
            //if (!fullfillPath.Exists)
            //{
            //    fullfillPath.Create();
            //}
            //fullfillPath.

            //string v = fullfillPath.FullName;//Directory.ToString();
            //v = fullfillPath.FullName;
            string logTime = DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss") + " :- ";

            return this.writeToFile(logTime + textLine, filePath);
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


        public object executeSqlOnPOS(string sqlCommand)
        {
            
            DataTable resultOfQuery = new DataTable();             
            int rowsAffected = 0;
            string connectionStatus;
            string mySqlDataBaseType = dbSettingInformationHandler.DataBaseType;
            string mySqlHostName = dbSettingInformationHandler.ServerHostName;
            string mySqlDataBaseName = dbSettingInformationHandler.DataBaseName;
            string mySqlUserName = dbSettingInformationHandler.DBUserName;
            string mySqlPassWord = dbSettingInformationHandler.DBPassword;
            string mySqlPort = dbSettingInformationHandler.DBPort;
            this.posExecuteOnError = false;

            sqlCommand=sqlCommand.Replace("commSepartor", "`");

            persistanceClass easyMoveConnection = new persistanceClass(mySqlDataBaseType, mySqlHostName,
                mySqlDataBaseName, mySqlUserName, mySqlPassWord,mySqlPort);

            connectionStatus = easyMoveConnection.connectToDataBase(easyMoveConnection);
            if (connectionStatus == "Open")
            {
                if (sqlCommand.ToUpperInvariant().StartsWith("SELECT"))
                    resultOfQuery = easyMoveConnection.getDataBaseData(sqlCommand, easyMoveConnection);
                else if (sqlCommand.ToUpperInvariant().StartsWith("INSERT") ||
                    sqlCommand.ToUpperInvariant().StartsWith("UPDATE") ||
                    sqlCommand.ToUpperInvariant().StartsWith("DELETE"))
                {
                    rowsAffected = easyMoveConnection.updateDataBaseData(sqlCommand, easyMoveConnection);
                    easyMoveConnection.closeConnection(easyMoveConnection);
                    if (dbCommitFailure.dbCommitError)
                    {
                        //LOG ERROR TO DAILY ERROR LOG
                        this.writeTextLinetoFile("UNABLE TO PROCESS FOLLOWING COMMAND " + sqlCommand +
                                                    "/**" + dbCommitFailure.dbCommitErrorMessage,
                                                    logType.error, sourceDBIsPos);
                    }
                    if (dbCommitFailure.dbCommitWarnning || rowsAffected <= 0)
                    {
                        this.writeTextLinetoFile("WARNNING WHILE EXECUTING " + sqlCommand +
                                                    "/**" + dbCommitFailure.dbCommitWarnningMessage,
                                                    logType.warnning, sourceDBIsPos);
                    }
                    if ((!dbCommitFailure.dbCommitError && !dbCommitFailure.dbCommitWarnning) ||
                        (rowsAffected > 0))
                    {
                        if (dbSettingInformationHandler.LogChangeScript)
                            this.writeTextLinetoFile(sqlCommand, logType.script, sourceDBIsPos);
                    }
                    else
                    {
                        this.posExecuteOnError = true;
                    }
                    return rowsAffected;
                }                
            }
            easyMoveConnection.closeConnection(easyMoveConnection);
            
            return resultOfQuery;
        }


        public DataTable clearRedundantRow(DataTable tableToClear)
        {
            return this.clearRedundantRow(tableToClear, "");
        }

        public DataTable clearRedundantRow(DataTable tableToClear, string keyColumn)
        {
            return this.clearRedundantRow(tableToClear, keyColumn, new string[]{""});
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
                firstTable.Merge(secondTable,true, MissingSchemaAction.Add);
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
                if(!currentRowIsCommon)
                    firstTable.Rows.RemoveAt(firstTableCurrentRow);
            }

            return firstTable;
        }

        public string createTheCriteriaClause(DataTable _criteriaTable, string _criteriaLogicalConnector,
            string wherClauselogicalConnector, bool isPOSTable)
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
            string _fieldSeparator = "";
            if (isPOSTable)
                _fieldSeparator = "";
            
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
                            _fieldSeparator + _criteriaTable.Rows[rowCounter]["Field"].ToString().ToUpperInvariant() + _fieldSeparator +
                            " " + _criteriaTable.Rows[rowCounter]["Criterion"].ToString() +
                            " " + delimApostrophy + _criteriaTable.Rows[rowCounter]["Value"].ToString().Replace("'","''")
                            + delimApostrophy;
                    }
                    if ((rowCounter+1) <= _criteriaTable.Rows.Count-1)
                        theCriteriaClase = theCriteriaClase + " " + _criteriaLogicalConnector + " ";
                }

                theCriteriaClase = theCriteriaClase + ")";
            return theCriteriaClase;
        }


        public string[] getPOSDBTableConnectorKey(string tableName)
        {
            //PROVIDE KEYS WHICH CONNECT POS TO COMPIERE....
            // (MAY NOT BE NECESSARILY PRIMARY KEY ON POS TABLE)
            
            tableName = tableName.ToUpperInvariant();
            string[] primarykeys = { "" };
            if (tableName == "CATEGORIES")
            { primarykeys = new string[] { "CATEGORY_CODE" }; }
            else if (tableName == "ITEM_UNITS")
            { primarykeys = new string[] { "unit_code" }; }
            else if (tableName == "ITEMS")
            { primarykeys = new string[] { "Product_id" }; }
            else if (tableName == "PRICE_CONDITIONS")
            { primarykeys = new string[] { "M_PRICELIST_VERSION_ID" }; }
            else if (tableName == "STORES")
            { primarykeys = new string[] { "store_number" }; }
            else if (tableName == "NODES")
            { primarykeys = new string[] { "AD_ORG_ID" }; }
            else if (tableName == "PRICE_LEVELS")
            { primarykeys = new string[] { "item_id", "condition" }; }
            else if (tableName == "CUSTOMER_DISPATCH")
            { primarykeys = new string[] { "SALES_ID", "SOLD_FROM_STORE_ID" }; }

            else if (tableName == "C_EXEMPTION")
            { primarykeys = new string[] { "C_EXEMPTION_ID" }; }
            else if (tableName == "C_EXEMPTIONLINE")
            { primarykeys = new string[] { "C_EXEMPTIONLINE_ID" }; }

            else if (tableName == "C_PAYMENT")
            { primarykeys = new string[] { "C_PAYMENT_ID" }; }
            else if (tableName == "C_PAYMENTALLOCATE")
            { primarykeys = new string[] { "C_PAYMENTALLOCATE_ID" }; }

            else if (tableName == "C_ALLOCATIONHDR")
            { primarykeys = new string[] { "C_ALLOCATIONHDR_ID" }; }
            else if (tableName == "C_ALLOCATIONLINE")
            { primarykeys = new string[] { "C_ALLOCATIONLINE_ID" }; }

            else if (tableName == "C_CASH")
            { primarykeys = new string[] { "C_CASH_ID" }; }
            else if (tableName == "C_CASHLINE")
            { primarykeys = new string[] { "C_CASHLINE_ID" }; }
            else if (tableName == "C_CASHLINESOURCE")
            { primarykeys = new string[] { "C_CASHLINESOURCE_ID" }; }

            else if (tableName == "C_BANKACCOUNT")
            { primarykeys = new string[] { "C_BANKACCOUNT_ID" }; }



            else if (tableName == "AD_USER_ORGACCESS")
            { primarykeys = new string[] { "AD_USER_ID", "AD_ORG_ID" }; }
            else if (tableName == "AD_USER")
            { primarykeys = new string[] { "AD_USER_ID" }; }
            else if (tableName == "STATION")
            { primarykeys = new string[] { "ID" }; }
            else if (tableName == "USER_STATIONACCESS")
            { primarykeys = new string[] { "C_PAYMENTALLOCATE_ID" }; }
            else if (tableName == "AD_SEQUENCE")
            { primarykeys = new string[] { "AD_SEQUENCE_ID" }; }
            else if (tableName == "C_PAYMENT")
            { primarykeys = new string[] { "C_PAYMENT_ID"}; }
            else if (tableName == "C_PAYMENTALLOCATE")
            { primarykeys = new string[] { "C_PAYMENTALLOCATE_ID"}; }
            

                //
            else if (tableName == "DUP_C_LOCATION" ||
                     tableName == "DUP_C_BPARTNER" ||
                     tableName == "DUP_C_BPARTNER_LOCATION" ||
                     tableName == "DUP_C_ORDER" ||
                     tableName == "DUP_C_ORDERLINE" ||
                     tableName == "UTL_CHANGE_ORDER"
                     )
            { primarykeys = new string[] { "CHANGE_SEQUENCE_ID" }; }
            else if (tableName == "DTN_C_BPARTNER" ||
                     tableName == "DTN_C_ORDER" ||
                     tableName == "DTN_C_ORDERLINE" 
                     )
            { primarykeys = new string[] { "ID", "STATION" }; }

            else if (tableName == "C_CHARGE")
            { primarykeys = new string[] { "C_CHARGE_ID" }; }

            else 
            { primarykeys = new string[] { "ID", "STATION" }; }
            
            return primarykeys;
        }
                
        private DataTable getDBTableStructure(string tableName, bool isPOSDBTable)
        {
            string theWhereClose = "";

            string[] Tableprimarykeys;
            DataTable result = new DataTable();

            if (isPOSDBTable)
            {
                Tableprimarykeys = 
                    this.getPOSDBTableConnectorKey(tableName);
                theWhereClose = "Where 1 ";
                foreach (string primaryKey in Tableprimarykeys)
                {
                    if (primaryKey != "")
                        theWhereClose = theWhereClose + " AND `" + primaryKey + "` = '0'";
                }
                string getStructureForTable = "SELECT *" +
                                              " FROM `" + tableName + "` " + theWhereClose;
                result = (DataTable)this.executeSqlOnPOS(getStructureForTable);
            }            
            
            result.Clear();
            return result;
        }              
              
        //User name builder for Reports and receipts
        public string getUserFullName(string userId)
        {
            string userFullName = " ";

            generalResultInformation.dtsDocumentPrintView.Tables["dtUserInfo"].Clear();

            if (userId == "0" || userId == "")
            {
                userFullName = " ";
            }
            else
            {

                DataTable user =
                    this.getUsersInfo(null, "", "",
                               "", "", userId, generalResultInformation.Station,
                               generalResultInformation.concernedNode,
                               triaStateBool.Ignor, false, "AND");

                if (!this.checkIfTableContainesData(user))
                {
                    userFullName = " ";
                }
                else
                {
                    userFullName = user.Rows[0]["full_name"].ToString();
                }
            }


            DataRow drUserInfo =
                        generalResultInformation.dtsDocumentPrintView.Tables["dtUserInfo"].NewRow();

            drUserInfo["FullUserName"] = userFullName;

            generalResultInformation.dtsDocumentPrintView.Tables["dtUserInfo"].
                            Rows.Add(drUserInfo);

            return userFullName;
        }
        
        
        //Report Builders

        public void establishSellerInformation(string salesId, string station, string node)
        {
            generalResultInformation.dtsDocumentPrintView.Tables["dtSaleDepartmentInfo"].Clear();

            DataTable dtCompanyInfo =
                this.getCompanyInfo(null, "", "", "", triaStateBool.Ignor, false, "AND");
            if (this.checkIfTableContainesData(dtCompanyInfo))
            {
                DataRow drSalesDepartmentInfo =
                    generalResultInformation.dtsDocumentPrintView.Tables["dtSaleDepartmentInfo"].NewRow();

                drSalesDepartmentInfo["SubCity"] =
                    dtCompanyInfo.Rows[0]["sub_city"];
                drSalesDepartmentInfo["kebele"] =
                    dtCompanyInfo.Rows[0]["kebele"];
                drSalesDepartmentInfo["HouseNumber"] =
                    dtCompanyInfo.Rows[0]["house_number"];
                drSalesDepartmentInfo["VATRegistrationNumber"] =
                    dtCompanyInfo.Rows[0]["vat"];
                drSalesDepartmentInfo["TINNumber"] =
                    dtCompanyInfo.Rows[0]["tin"];
                drSalesDepartmentInfo["DateRegistered"] =
                    dtCompanyInfo.Rows[0]["date_of_registration"];
                generalResultInformation.dtsDocumentPrintView.Tables["dtSaleDepartmentInfo"].
                    Rows.Add(drSalesDepartmentInfo);
            }

        }


        public void establishSalesInformation(string salesId, string station, string node, bool autoGenerateDoc)
        {
            generalResultInformation.dtsDocumentPrintView.Tables["dtAttachmentSummary"].Clear();            
            DataTable dtSalesInfo =
                this.getSalesInfo(null, "", salesId, station, "", node, "",
                    triaStateBool.Ignor, false, false, false, "AND");

            string customerId = dtSalesInfo.Rows[0]["customer_id"].ToString();

            DataTable dtCustomerInfo =
                this.getCustomersInfo(null, "", customerId, station, node, "", triaStateBool.Ignor, false, "AND");

            DataTable dtSalesDispatchInfo =
               this.getCustomerDispatchInfo(null, "", salesId, customerId, "", station,
                                               "", node, false, "AND");
            string deliveryOrderNumber = "";
            for (int rowCounter = 0; 
                rowCounter <= dtSalesDispatchInfo.Rows.Count - 1; rowCounter++)
            {
                if (dtSalesDispatchInfo.Rows[rowCounter]["REF_NO"].ToString() != "")
                {
                    deliveryOrderNumber =
                        deliveryOrderNumber + dtSalesDispatchInfo.Rows[rowCounter]["REF_NO"].ToString();
                }
                if (rowCounter < dtSalesDispatchInfo.Rows.Count - 1)
                {
                    deliveryOrderNumber =
                        deliveryOrderNumber + "/";
                }
            }

            DataRow drAttachementSummary =
                generalResultInformation.dtsDocumentPrintView.Tables["dtAttachmentSummary"].NewRow();

            drAttachementSummary["salesID"] = dtSalesInfo.Rows[0]["id"].ToString();
            drAttachementSummary["stationID"] = dtSalesInfo.Rows[0]["station"].ToString();
            drAttachementSummary["nodeID"] = dtSalesInfo.Rows[0]["node"].ToString();
            drAttachementSummary["DeliveryOrderNumber"] = deliveryOrderNumber;

            if (this.checkIfTableContainesData(dtCustomerInfo))
            {
                drAttachementSummary["BuyersTradeName"] = dtCustomerInfo.Rows[0]["customer_name"].ToString();
                if (dtCustomerInfo.Rows[0]["trade_name"].ToString() != "")
                    drAttachementSummary["BuyersTradeName"] =
                        drAttachementSummary["BuyersTradeName"] +
                        "\\" + dtCustomerInfo.Rows[0]["trade_name"].ToString();

                drAttachementSummary["BuyersTIN"] =
                    dtCustomerInfo.Rows[0]["tin_number"].ToString();
                drAttachementSummary["BuyersVAT"] =
                    dtCustomerInfo.Rows[0]["vat_number"].ToString();

                if (dtCustomerInfo.Rows[0]["phone_mobile"].ToString() != "")
                    drAttachementSummary["BuyersPhoneNumber"] =
                        dtCustomerInfo.Rows[0]["phone_mobile"].ToString();
                else
                    drAttachementSummary["BuyersPhoneNumber"] =
                        dtCustomerInfo.Rows[0]["phone_office"].ToString();

                drAttachementSummary["BuyersZoneORSubCity"] =
                    dtCustomerInfo.Rows[0]["sub_city"].ToString();
                drAttachementSummary["BuyersKebele"] =
                    dtCustomerInfo.Rows[0]["kebele"].ToString();
                drAttachementSummary["BuyersHouseNumber"] =
                    dtCustomerInfo.Rows[0]["house_number"].ToString();
            }

            string salesDate = dtSalesInfo.Rows[0]["salesDateTime"].ToString();

            DateTime salesDateTime = Convert.ToDateTime(salesDate);
            drAttachementSummary["Date"] = salesDateTime;
            //Convert.ToDateTime(salesDateTime.ToString("dd-MM-yy HH:mm:ss"));            
            drAttachementSummary["SalesTotal"] =
                decimal.Parse(dtSalesInfo.Rows[0]["sub_total"].ToString());
            drAttachementSummary["SalesVAT"] =
                decimal.Parse(dtSalesInfo.Rows[0]["total_tax"].ToString());
            drAttachementSummary["SalesGrandTotal"] =
                decimal.Parse(dtSalesInfo.Rows[0]["total_amount"].ToString());
            if (dtSalesInfo.Rows[0]["with_holding"].ToString() != "")
                drAttachementSummary["SalesWithHolding"] =
                    decimal.Parse(dtSalesInfo.Rows[0]["with_holding"].ToString());
            else
                drAttachementSummary["SalesWithHolding"] = 0;
            drAttachementSummary["ReferenceNumber"] =
                dtSalesInfo.Rows[0]["ref_no"].ToString();
            if (dtSalesInfo.Rows[0]["cash_credit"].ToString().ToUpperInvariant() == "CREDIT")
                drAttachementSummary["DocumentName"] = "Attachment Credit Invoice";
            else if (dtSalesInfo.Rows[0]["cash_credit"].ToString().ToUpperInvariant() == "CASH")
                drAttachementSummary["DocumentName"] = "Attachment Cash Invoice";
            else
                drAttachementSummary["DocumentName"] = "Attachment Invoice";
            

     checkForDocumentReference :

            if (generalResultInformation.requestedDocumenType == reportType.attachment)
            {
                generalResultInformation.stDocumentReferenceNumber =
                    dtSalesInfo.Rows[0]["fs_no"].ToString();
                generalResultInformation.stDocumentNote =
                    dtSalesInfo.Rows[0]["comment"].ToString();

                if (generalResultInformation.stDocumentReferenceNumber == "0" ||
                    generalResultInformation.stDocumentReferenceNumber == "")
                {
                    generalResultInformation.stDocumentReferenceNumber =
                        this.getNextMachineSerialNumber(true);
                }


                if (!autoGenerateDoc || 
                    generalResultInformation.stDocumentReferenceNumber == "0" ||
                    generalResultInformation.stDocumentReferenceNumber == "")
                {
                    frmDocumentReference frmAttachmentReference = new frmDocumentReference();
                    frmAttachmentReference.ShowDialog();
                }

                if (generalResultInformation.documentRequestInfoCancelled)
                {
                    return;
                }

                if (generalResultInformation.stDocumentNote != 
                            dtSalesInfo.Rows[0]["comment"].ToString() ||
                    generalResultInformation.stDocumentReferenceNumber !=
                            dtSalesInfo.Rows[0]["fs_no"].ToString())
                {
                    DataTable dtSalesInfoToUpdate =
                        this.getSalesInfo(null, "", salesId, station, "", node, "",
                                triaStateBool.Ignor, false, false, false, "AND");
                    if (!this.checkIfTableContainesData(dtSalesInfoToUpdate))
                    {
                        System.Windows.Forms.MessageBox.Show("There has been Error. Please Re-try. \n" +
                            " If error repeats again contact your Administrator.", 
                            "Generating Attachment", 
                            System.Windows.Forms.MessageBoxButtons.OK, 
                            System.Windows.Forms.MessageBoxIcon.Exclamation);
                        goto checkForDocumentReference;
                    }
                    dtSalesInfoToUpdate.Rows[0]["comment"] =
                        generalResultInformation.stDocumentNote;
                    dtSalesInfoToUpdate.Rows[0]["fs_no"] = 
                        generalResultInformation.stDocumentReferenceNumber;

                    for (int columnCounter = dtSalesInfoToUpdate.Columns.Count - 1;
                        columnCounter >= 0; columnCounter--)
                    {
                        if (dtSalesInfoToUpdate.Columns[columnCounter].ColumnName != "comment" &&
                            dtSalesInfoToUpdate.Columns[columnCounter].ColumnName != "fs_no" &&
                            dtSalesInfoToUpdate.Columns[columnCounter].ColumnName != "id" &&
                            dtSalesInfoToUpdate.Columns[columnCounter].ColumnName != "station")
                            dtSalesInfoToUpdate.Columns.RemoveAt(columnCounter);
                    }                    

                    this.changeDataBaseTableData(dtSalesInfoToUpdate, "SALES", "UPDATE", true);


                    dtSalesInfo.Rows[0]["comment"] =
                        generalResultInformation.stDocumentNote;
                    dtSalesInfo.Rows[0]["fs_no"] =
                        generalResultInformation.stDocumentReferenceNumber;
                }
            }

            drAttachementSummary["FSNumber"] = dtSalesInfo.Rows[0]["fs_no"].ToString();
            drAttachementSummary["Note"] = dtSalesInfo.Rows[0]["comment"].ToString();

            DataTable nodeName =
                this.getnodesInfo(null, "", dtSalesInfo.Rows[0]["node"].ToString(),
                        "", triaStateBool.Ignor, false, "AND");
            if (this.checkIfTableContainesData(nodeName))
                drAttachementSummary["DepartmentStore"] = nodeName.Rows[0]["node"].ToString();

            DataTable paymentMethodName =
                this.getPaymentTypesInfo(null, "",
                        dtSalesInfo.Rows[0]["payment_type_id"].ToString(),
                        generalResultInformation.centralStation, "",
                        triaStateBool.Ignor, false, "AND");

            if (this.checkIfTableContainesData(paymentMethodName))
            {
                drAttachementSummary["SalesPaymentMethod"] = paymentMethodName.Rows[0]["payment_type"].ToString();
                if (dtSalesInfo.Rows[0]["cheque_number"].ToString() != "")
                    drAttachementSummary["SalesPaymentMethod"] +=
                        " [" + dtSalesInfo.Rows[0]["cheque_number"].ToString() + "] ";
            }

            drAttachementSummary["MRC"] = generalResultInformation.machineRegistrationNumber;
            drAttachementSummary["SalesNetPay"] = (decimal)(
                (decimal)drAttachementSummary["SalesGrandTotal"] -
                (decimal)drAttachementSummary["SalesWithHolding"]);
            drAttachementSummary["SalesAmountInWord"] =
                this.changeToWords(decimal.Round(
                                                (decimal)drAttachementSummary["SalesGrandTotal"]
                                                        , 2).ToString(),true);

            DataTable dtPrintInfo = new DataTable();
            string numberOfPrints = "";

            if (drAttachementSummary["ReferenceNumber"].ToString() != "" ||
                drAttachementSummary["ReferenceNumber"].ToString() != "0")
            {
                dtPrintInfo =
                    this.getPrintJobInfo(null, "", "", station, node,
                                         drAttachementSummary["ReferenceNumber"].ToString(),
                                         "SALES", false, "AND");
                if (dtPrintInfo.Rows.Count > 0)
                {
                    numberOfPrints = "rePrint " + dtPrintInfo.Rows.Count.ToString();
                }
            }
            drAttachementSummary["numberOfRePrint"] = numberOfPrints;            

            generalResultInformation.dtsDocumentPrintView.Tables["dtAttachmentSummary"].
                            Rows.Add(drAttachementSummary);

        }

        public void establishSalesDetailInformation(string salesId, string station, string node)
        {
            generalResultInformation.dtsDocumentPrintView.Tables["dtSalesDetail"].Clear();


            DataTable dtSalesDetailInformation =
                this.getSalesItemsInfo(null, "", "", station, node,
                    triaStateBool.Ignor, salesId, false, "AND");

            dtSalesDetailInformation.Columns.Add("Sn.");
            dtSalesDetailInformation.Columns.Add("TotalAmount");

            dtSalesDetailInformation.Columns["sale_id"].ColumnName = "salesID";
            dtSalesDetailInformation.Columns["item_name"].ColumnName = "Description";
            dtSalesDetailInformation.Columns["unit_of_measure"].ColumnName = "UOM";
            dtSalesDetailInformation.Columns["quantity"].ColumnName = "Quantity";
            dtSalesDetailInformation.Columns["sold_from_store_id"].ColumnName = "locatorFromId";
            dtSalesDetailInformation.Columns["item_unit_price"].ColumnName = "UnitPrice";
            dtSalesDetailInformation.Columns["comment"].ColumnName = "Comment";
            dtSalesDetailInformation.Columns["id"].ColumnName = "salesDetailId";
            dtSalesDetailInformation.Columns["station"].ColumnName = "salesDetailStation";
            dtSalesDetailInformation.Columns["node"].ColumnName = "salesDetailNode";

            dtSalesDetailInformation.Columns.RemoveAt(
                dtSalesDetailInformation.Columns.IndexOf("price_adj_amount"));
            dtSalesDetailInformation.Columns.RemoveAt(
                dtSalesDetailInformation.Columns.IndexOf("adj_reason"));
            dtSalesDetailInformation.Columns.RemoveAt(
                dtSalesDetailInformation.Columns.IndexOf("adj_approved_by"));
            dtSalesDetailInformation.Columns.RemoveAt(
                dtSalesDetailInformation.Columns.IndexOf("item_cost"));
            dtSalesDetailInformation.Columns.RemoveAt(
                dtSalesDetailInformation.Columns.IndexOf("item_tax_amount"));
            dtSalesDetailInformation.Columns.RemoveAt(
                dtSalesDetailInformation.Columns.IndexOf("is_void"));
            dtSalesDetailInformation.Columns.RemoveAt(
                dtSalesDetailInformation.Columns.IndexOf("batch_id"));
            dtSalesDetailInformation.Columns.RemoveAt(
                dtSalesDetailInformation.Columns.IndexOf("dept_id"));

            for (int rowCounter = dtSalesDetailInformation.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                dtSalesDetailInformation.Rows[rowCounter]["TotalAmount"] = decimal.Round(
                    decimal.Parse(dtSalesDetailInformation.Rows[rowCounter]["Quantity"].ToString()) *
                    decimal.Parse(dtSalesDetailInformation.Rows[rowCounter]["UnitPrice"].ToString())
                    , 2, MidpointRounding.ToEven);

                DataTable dtProductInfo =
                    this.getITEMInfo(null, "", "",
                            dtSalesDetailInformation.Rows[rowCounter]["item_id"].ToString(),
                            generalResultInformation.centralStation, "", triaStateBool.Ignor,
                            false, "AND");

                DataTable dtUnitInfo = new DataTable();

                if (dtSalesDetailInformation.Rows[rowCounter]["Description"].ToString() == "")
                {
                    if (this.checkIfTableContainesData(dtProductInfo))
                        dtSalesDetailInformation.Rows[rowCounter]["Description"] =
                            dtProductInfo.Rows[0]["item_name"].ToString();
                }
                if (dtSalesDetailInformation.Rows[rowCounter]["UOM"].ToString() == "")
                {
                    if (this.checkIfTableContainesData(dtProductInfo))
                    {
                        dtUnitInfo =
                            this.getITEM_UNITInfo(null, "", "",
                                    dtProductInfo.Rows[0]["unit_id"].ToString(),
                                    generalResultInformation.centralStation, "",
                                    triaStateBool.Ignor, false, "AND");

                        if (this.checkIfTableContainesData(dtUnitInfo))
                            dtSalesDetailInformation.Rows[rowCounter]["UOM"] =
                                dtUnitInfo.Rows[0]["abbr"].ToString();
                    }
                }
                dtSalesDetailInformation.Rows[rowCounter]["Sn."] = rowCounter + 1;
            }

            //for (int rowCounter = dtSalesDetailInformation.Columns.Count - 1;
            //        rowCounter >= 0; rowCounter--)
            //    if (!generalResultInformation.dtsDocumentPrintView.Tables["dtSalesDetail"].Columns.Contains
            //            (dtMovementDetailInfo.Columns[rowCounter].ColumnName))
            //        dtSalesDetailInformation.Columns.RemoveAt(rowCounter);

            DataRow drNewSalesDetail;
            for (int rowCounter = 0;
                rowCounter <= dtSalesDetailInformation.Rows.Count - 1; rowCounter++)
            {
                drNewSalesDetail =
                    generalResultInformation.dtsDocumentPrintView.Tables["dtSalesDetail"].NewRow();

                drNewSalesDetail["salesDetailId"] =
                    dtSalesDetailInformation.Rows[rowCounter]["salesDetailId"];
                drNewSalesDetail["salesDetailStation"] =
                    dtSalesDetailInformation.Rows[rowCounter]["salesDetailStation"];
                drNewSalesDetail["salesDetailNode"] =
                    dtSalesDetailInformation.Rows[rowCounter]["salesDetailNode"];
                drNewSalesDetail["salesID"] =
                    dtSalesDetailInformation.Rows[rowCounter]["salesID"];
                drNewSalesDetail["item_id"] =
                    dtSalesDetailInformation.Rows[rowCounter]["item_id"];
                drNewSalesDetail["locatorFromId"] =
                    dtSalesDetailInformation.Rows[rowCounter]["locatorFromId"];
                drNewSalesDetail["Sn."] =
                    dtSalesDetailInformation.Rows[rowCounter]["Sn."];
                drNewSalesDetail["Description"] =
                    dtSalesDetailInformation.Rows[rowCounter]["Description"];
                drNewSalesDetail["Quantity"] =
                    dtSalesDetailInformation.Rows[rowCounter]["Quantity"];
                drNewSalesDetail["UOM"] =
                    dtSalesDetailInformation.Rows[rowCounter]["UOM"];
                drNewSalesDetail["UnitPrice"] =
                    dtSalesDetailInformation.Rows[rowCounter]["UnitPrice"];
                drNewSalesDetail["TotalAmount"] =
                    dtSalesDetailInformation.Rows[rowCounter]["TotalAmount"];
                drNewSalesDetail["Comment"] =
                    dtSalesDetailInformation.Rows[rowCounter]["Comment"];

                generalResultInformation.dtsDocumentPrintView.Tables["dtSalesDetail"].Rows.Add(drNewSalesDetail);
            }
        }


        public void establishCustomerDisaptchInformation(string salesId, string dispatchingStoreId,
            string station, string node)
        {
            generalResultInformation.dtsDocumentPrintView.Tables["dtDispatchSummary"].Clear();
            DataTable dtCustomerDispatchInfo =
                this.getCustomerDispatchInfo(null, "", salesId, "", dispatchingStoreId, station,
                                                "", node, false, "AND");

            string stDispatchingStore = "";
            DataTable dtdispatchingStoreInfo =
                this.getStoresInfo(null, "", dispatchingStoreId, generalResultInformation.centralStation, "",
                            triaStateBool.Ignor, false, "AND");

            if (this.checkIfTableContainesData(dtdispatchingStoreInfo))
            {
                stDispatchingStore = dtdispatchingStoreInfo.Rows[0]["store_name"].ToString();
            }

            string stDeliveryOrderNumber = "";
            DataTable dtDeliveryOrderInfo =
                this.getCustomerDispatchInfo(null, "", salesId, "", dispatchingStoreId,
                                station, "", node, false, "AND");

            if (this.checkIfTableContainesData(dtDeliveryOrderInfo))
            {
                stDeliveryOrderNumber =
                    dtDeliveryOrderInfo.Rows[0]["REF_NO"].ToString();
                    /*dtDeliveryOrderInfo.Rows[0]["REF_NOTE"].ToString() != "" ?
                    dtDeliveryOrderInfo.Rows[0]["REF_NOTE"].ToString() + " _ " +
                    dtDeliveryOrderInfo.Rows[0]["REF_NO"].ToString():
                    dtDeliveryOrderInfo.Rows[0]["REF_NO"].ToString();*/
            }

            DataTable dtPrintInfo = new DataTable();
            string numberOfPrints = "";

            if (this.checkIfTableContainesData(dtDeliveryOrderInfo))
            {
                dtPrintInfo =
                    this.getPrintJobInfo(null, "", "", station, node,
                                     dtDeliveryOrderInfo.Rows[0]["REF_NO"].ToString(),
                                     "CUSTOMER_DISPATCH", false, "AND");
                if (dtPrintInfo.Rows.Count > 0)
                {
                    numberOfPrints = "rePrint " + dtPrintInfo.Rows.Count.ToString();
                }
            }

            DataRow drDispatchSummary =
                generalResultInformation.dtsDocumentPrintView.Tables["dtDispatchSummary"].NewRow();

            drDispatchSummary["DocumentName"] = "CUSTOMER DISPATCH ORDER";
            drDispatchSummary["DeliveryOrderNumber"] = stDeliveryOrderNumber;
            drDispatchSummary["DispatchFrom"] = stDispatchingStore;
            drDispatchSummary["numberOfRePrint"] = numberOfPrints;

            generalResultInformation.dtsDocumentPrintView.Tables["dtDispatchSummary"].
                            Rows.Add(drDispatchSummary);
        }
        
        public void establishCustomerDispatchDetailInformation(string salesId, string station,
            string node, string dispatchingStoreId)
        {
            generalResultInformation.dtsDocumentPrintView.Tables["dtDispatchDetail"].Clear();


            DataTable dtSalesDetailInformation =
                this.getSalesItemsInfo(null, "", "", station, node,
                    triaStateBool.Ignor, salesId, false, "AND");

            dtSalesDetailInformation.Columns.Add("Sn.");
            
            dtSalesDetailInformation.Columns["sale_id"].ColumnName = "salesID";
            dtSalesDetailInformation.Columns["item_name"].ColumnName = "Description";
            dtSalesDetailInformation.Columns["unit_of_measure"].ColumnName = "UOM";
            dtSalesDetailInformation.Columns["quantity"].ColumnName = "Quantity";
            dtSalesDetailInformation.Columns["sold_from_store_id"].ColumnName = "locatorFromId";            
            dtSalesDetailInformation.Columns["comment"].ColumnName = "Comment";
            dtSalesDetailInformation.Columns["id"].ColumnName = "salesDetailId";
            dtSalesDetailInformation.Columns["station"].ColumnName = "salesDetailStation";
            dtSalesDetailInformation.Columns["node"].ColumnName = "salesDetailNode";

            dtSalesDetailInformation.Columns.RemoveAt(
                dtSalesDetailInformation.Columns.IndexOf("item_unit_price"));
            dtSalesDetailInformation.Columns.RemoveAt(
                dtSalesDetailInformation.Columns.IndexOf("price_adj_amount"));
            dtSalesDetailInformation.Columns.RemoveAt(
                dtSalesDetailInformation.Columns.IndexOf("adj_reason"));
            dtSalesDetailInformation.Columns.RemoveAt(
                dtSalesDetailInformation.Columns.IndexOf("adj_approved_by"));
            dtSalesDetailInformation.Columns.RemoveAt(
                dtSalesDetailInformation.Columns.IndexOf("item_cost"));
            dtSalesDetailInformation.Columns.RemoveAt(
                dtSalesDetailInformation.Columns.IndexOf("item_tax_amount"));
            dtSalesDetailInformation.Columns.RemoveAt(
                dtSalesDetailInformation.Columns.IndexOf("is_void"));
            dtSalesDetailInformation.Columns.RemoveAt(
                dtSalesDetailInformation.Columns.IndexOf("batch_id"));
            dtSalesDetailInformation.Columns.RemoveAt(
                dtSalesDetailInformation.Columns.IndexOf("dept_id"));

            for (int rowCounter = dtSalesDetailInformation.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                if (dtSalesDetailInformation.Rows[rowCounter]["locatorFromId"].ToString()
                    != dispatchingStoreId)
                {
                    dtSalesDetailInformation.Rows.RemoveAt(rowCounter);
                    continue;
                }

                DataTable dtProductInfo =
                    this.getITEMInfo(null, "", "",
                            dtSalesDetailInformation.Rows[rowCounter]["item_id"].ToString(),
                            generalResultInformation.centralStation, "", triaStateBool.Ignor,
                            false, "AND");

                DataTable dtUnitInfo = new DataTable();

                if (dtSalesDetailInformation.Rows[rowCounter]["Description"].ToString() == "")
                {
                    if (this.checkIfTableContainesData(dtProductInfo))
                        dtSalesDetailInformation.Rows[rowCounter]["Description"] =
                            dtProductInfo.Rows[0]["item_name"].ToString();
                }
                if (dtSalesDetailInformation.Rows[rowCounter]["UOM"].ToString() == "")
                {
                    if (this.checkIfTableContainesData(dtProductInfo))
                    {
                        dtUnitInfo =
                            this.getITEM_UNITInfo(null, "", "",
                                    dtProductInfo.Rows[0]["unit_id"].ToString(),
                                    generalResultInformation.centralStation, "",
                                    triaStateBool.Ignor, false, "AND");

                        if (this.checkIfTableContainesData(dtUnitInfo))
                            dtSalesDetailInformation.Rows[rowCounter]["UOM"] =
                                dtUnitInfo.Rows[0]["abbr"].ToString();
                    }
                }
                dtSalesDetailInformation.Rows[rowCounter]["Sn."] = rowCounter + 1;
            }

            DataRow drDispatchDetail;
            for (int rowCounter = 0;
                rowCounter <= dtSalesDetailInformation.Rows.Count - 1; rowCounter++)
            {
                drDispatchDetail =
                    generalResultInformation.dtsDocumentPrintView.Tables["dtDispatchDetail"].NewRow();

                drDispatchDetail["salesDetailId"] =
                    dtSalesDetailInformation.Rows[rowCounter]["salesDetailId"];
                drDispatchDetail["salesDetailStation"] =
                    dtSalesDetailInformation.Rows[rowCounter]["salesDetailStation"];
                drDispatchDetail["salesDetailNode"] =
                    dtSalesDetailInformation.Rows[rowCounter]["salesDetailNode"];
                drDispatchDetail["salesID"] =
                    dtSalesDetailInformation.Rows[rowCounter]["salesID"];
                drDispatchDetail["item_id"] =
                    dtSalesDetailInformation.Rows[rowCounter]["item_id"];
                drDispatchDetail["locatorFromId"] =
                    dtSalesDetailInformation.Rows[rowCounter]["locatorFromId"];
                drDispatchDetail["Sn."] =
                    dtSalesDetailInformation.Rows[rowCounter]["Sn."];
                drDispatchDetail["Description"] =
                    dtSalesDetailInformation.Rows[rowCounter]["Description"];
                drDispatchDetail["Quantity"] =
                    dtSalesDetailInformation.Rows[rowCounter]["Quantity"];
                drDispatchDetail["UOM"] =
                    dtSalesDetailInformation.Rows[rowCounter]["UOM"];
                drDispatchDetail["Comment"] =
                    dtSalesDetailInformation.Rows[rowCounter]["Comment"];

                generalResultInformation.dtsDocumentPrintView.
                    Tables["dtDispatchDetail"].Rows.Add(drDispatchDetail);
            }
        }



        public string establishRefundInformation(string refundId, string station, string node)
        {
            DataTable dtRefundInfo =
                this.getRefundsInfo(null, "", refundId, station, "", node, "", false, false, "AND");
            
            if (!this.checkIfTableContainesData(dtRefundInfo))
                return "";

            generalResultInformation.dtsDocumentPrintView.Tables["dtRefundSummary"].Clear();
            
            string refundNumber = dtRefundInfo.Rows[0]["ref_no"].ToString();
            
            DataRow drRefundSummary =
                generalResultInformation.dtsDocumentPrintView.Tables["dtRefundSummary"].NewRow();
            
            string stRefundDateTime = dtRefundInfo.Rows[0]["refundDateTime"].ToString();
            string salesId = dtRefundInfo.Rows[0]["SALES_ID"].ToString();
            DateTime refundDateTime = Convert.ToDateTime(stRefundDateTime);

            //Convert.ToDateTime(salesDateTime.ToString("dd-MM-yy HH:mm:ss"));  
            drRefundSummary["refundDateAndTime"] = refundDateTime;
                                   
            //drRefundSummary["refundBy"] = dtRefundInfo.Rows[0]["user_id"].ToString();
                        
            drRefundSummary["refundId"] = dtRefundInfo.Rows[0]["id"].ToString();
            drRefundSummary["refundNumber"] = dtRefundInfo.Rows[0]["ref_no"].ToString();
            drRefundSummary["refundStation"] = dtRefundInfo.Rows[0]["station"].ToString();
            drRefundSummary["refundNode"] = dtRefundInfo.Rows[0]["node"].ToString();

            drRefundSummary["RefundTotal"] =
                decimal.Parse(dtRefundInfo.Rows[0]["sub_total"].ToString());
            drRefundSummary["RefundVAT"] =
                decimal.Parse(dtRefundInfo.Rows[0]["total_tax"].ToString());
            drRefundSummary["RefundGrandTotal"] =
                decimal.Parse(dtRefundInfo.Rows[0]["total_amount"].ToString());

            

        checkForDocumentReference:

            if (generalResultInformation.requestedDocumenType == reportType.refundBook)
            {
                generalResultInformation.stDocumentReferenceNumber =
                    dtRefundInfo.Rows[0]["fs_no"].ToString();
                generalResultInformation.stRefundSalesReferenceNumber =
                    dtRefundInfo.Rows[0]["SALES_ID"].ToString();
                generalResultInformation.stDocumentNote =
                    dtRefundInfo.Rows[0]["comment"].ToString();

                if (generalResultInformation.stDocumentReferenceNumber == "")
                {
                    generalResultInformation.stDocumentReferenceNumber =
                        this.getNextMachineSerialNumber(false);
                }

                DataTable salesInfo = new DataTable();
                do
                {                    
                    if (salesId != "")
                    {
                        salesInfo =
                            this.getSalesInfo(null, "", salesId,
                                    dtRefundInfo.Rows[0]["station"].ToString(), "", "", "",
                                    triaStateBool.Ignor, false, false, false, "AND");
                        if (!this.checkIfTableContainesData(salesInfo))
                        {
                            frmDocumentReference frmAttachmentReference = new frmDocumentReference();
                            frmAttachmentReference.ShowDialog();

                            if (generalResultInformation.documentRequestInfoCancelled)
                            {
                                return "";
                            }

                            salesInfo =
                                this.getSalesInfo(null, "", "",
                                        dtRefundInfo.Rows[0]["station"].ToString(),
                                        generalResultInformation.stRefundSalesReferenceNumber, "", "",
                                        triaStateBool.Ignor, false, false, false, "AND");
                        }
                    }
                    else
                    {
                        frmDocumentReference frmAttachmentReference = new frmDocumentReference();
                        frmAttachmentReference.ShowDialog();

                        salesInfo =
                            this.getSalesInfo(null, "", "",
                                    dtRefundInfo.Rows[0]["station"].ToString(),
                                    generalResultInformation.stRefundSalesReferenceNumber, "", "",
                                    triaStateBool.Ignor, false, false, false, "AND");
                    }

                    if (!this.checkIfTableContainesData(salesInfo))
                    {
                        System.Windows.Forms.MessageBox.Show("Sales Information not found. " +
                            "\n Please try again", "Refund",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Error);
                        continue;
                    }                                        

                    if (!(salesInfo.Rows[0]["customer_id"].Equals(dtRefundInfo.Rows[0]["customer_id"])))
                    {
                        System.Windows.Forms.MessageBox.Show("Sales Customer Information Does Not match. " +
                            "\n Please try again", "Refund", 
                            System.Windows.Forms.MessageBoxButtons.OK, 
                            System.Windows.Forms.MessageBoxIcon.Error);
                        continue;
                    }

                    if (decimal.Parse(salesInfo.Rows[0]["sub_total"].ToString()).
                            CompareTo(decimal.Parse(dtRefundInfo.Rows[0]["sub_total"].ToString())) == -1)
                    {
                        System.Windows.Forms.MessageBox.Show("Sales Sub total Does Not match. " +
                            "\n Please try again", "Refund",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Error);
                        continue;
                    }

                    if (decimal.Parse(salesInfo.Rows[0]["total_amount"].ToString()).
                            CompareTo(decimal.Parse(dtRefundInfo.Rows[0]["total_amount"].ToString())) == -1)
                    {
                        System.Windows.Forms.MessageBox.Show("Sales Grand total Does Not match. " +
                            "\n Please try again", "Refund",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Error);
                        continue;
                    }

                    break;
                    
                } while (true);

                salesId = salesInfo.Rows[0]["id"].ToString();
                
                if (generalResultInformation.stDocumentNote !=
                            dtRefundInfo.Rows[0]["comment"].ToString() ||
                    generalResultInformation.stDocumentReferenceNumber !=
                            dtRefundInfo.Rows[0]["fs_no"].ToString() ||
                    generalResultInformation.stRefundSalesReferenceNumber !=
                            dtRefundInfo.Rows[0]["SALES_ID"].ToString())
                {
                    DataTable dtRefundInfoToUpdate =
                        this.getRefundsInfo(null, "", refundId, station, "", node, "",
                        false, false, "AND");

                    if (!this.checkIfTableContainesData(dtRefundInfoToUpdate))
                    {
                        System.Windows.Forms.MessageBox.Show("There has been Error. Please Re-try. \n" +
                            " If error repeats again contact your Administrator.",
                            "Generating Attachment",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Exclamation);
                        goto checkForDocumentReference;
                    }
                    dtRefundInfoToUpdate.Rows[0]["comment"] =
                        generalResultInformation.stDocumentNote;
                    dtRefundInfoToUpdate.Rows[0]["fs_no"] =
                        generalResultInformation.stDocumentReferenceNumber;
                    dtRefundInfoToUpdate.Rows[0]["SALES_ID"] =
                        salesId;


                    for (int columnCounter = dtRefundInfoToUpdate.Columns.Count - 1;
                        columnCounter >= 0; columnCounter--)
                    {
                        if (
                            dtRefundInfoToUpdate.Columns[columnCounter].ColumnName != "fs_no" &&
                            dtRefundInfoToUpdate.Columns[columnCounter].ColumnName != "comment" &&
                            dtRefundInfoToUpdate.Columns[columnCounter].ColumnName != "SALES_ID" &&
                            dtRefundInfoToUpdate.Columns[columnCounter].ColumnName != "id" &&
                            dtRefundInfoToUpdate.Columns[columnCounter].ColumnName != "station")
                            dtRefundInfoToUpdate.Columns.RemoveAt(columnCounter);
                    }                    


                    this.changeDataBaseTableData(dtRefundInfoToUpdate, "REFUNDS", "UPDATE", true);

                    dtRefundInfo.Rows[0]["comment"] =
                        generalResultInformation.stDocumentNote;
                    dtRefundInfo.Rows[0]["fs_no"] =
                        generalResultInformation.stDocumentReferenceNumber;
                }
            }
                       
            drRefundSummary["RFNumber"] = dtRefundInfo.Rows[0]["fs_no"].ToString();
            drRefundSummary["refundReason"] = dtRefundInfo.Rows[0]["comment"].ToString();
            drRefundSummary["salesId"] = salesId;

            DataTable dtPrintInfo = new DataTable();
            string numberOfPrints = "";

            if (drRefundSummary["refundNumber"].ToString() != "" ||
                drRefundSummary["refundNumber"].ToString() != "0")
            {
                dtPrintInfo =
                    this.getPrintJobInfo(null, "", "", station, node,
                                         drRefundSummary["refundNumber"].ToString(),
                                         "REFUNDS", false, "AND");
                if (dtPrintInfo.Rows.Count > 0)
                {
                    numberOfPrints = "rePrint " + dtPrintInfo.Rows.Count.ToString();
                }
            }
            drRefundSummary["numberOfRePrint"] = numberOfPrints;

            generalResultInformation.dtsDocumentPrintView.Tables["dtRefundSummary"].
                            Rows.Add(drRefundSummary);

            return salesId;

        }

        public void establishRefundDetailInformation(string refundId, string station, string node)
        {
            generalResultInformation.dtsDocumentPrintView.Tables["dtRefundDetail"].Clear();


            DataTable dtRefundDetailInformation =
                this.getRefundsItemsInfo(null, "", "", station, node,
                    triaStateBool.Ignor, refundId, false, "AND");

            dtRefundDetailInformation.Columns.Add("Sn.");
            dtRefundDetailInformation.Columns.Add("TotalAmount");

            dtRefundDetailInformation.Columns["sale_id"].ColumnName = "refundID";
            dtRefundDetailInformation.Columns["item_name"].ColumnName = "Description";
            dtRefundDetailInformation.Columns["unit_of_measure"].ColumnName = "UOM";
            dtRefundDetailInformation.Columns["quantity"].ColumnName = "Quantity";
            dtRefundDetailInformation.Columns["sold_from_store_id"].ColumnName = "locatorFromId";
            dtRefundDetailInformation.Columns["item_unit_price"].ColumnName = "UnitPrice";
            dtRefundDetailInformation.Columns["comment"].ColumnName = "Comment";
            dtRefundDetailInformation.Columns["id"].ColumnName = "refundDetailId";
            dtRefundDetailInformation.Columns["station"].ColumnName = "refundDetailStation";
            dtRefundDetailInformation.Columns["node"].ColumnName = "refundDetailNode";

            dtRefundDetailInformation.Columns.RemoveAt(
                dtRefundDetailInformation.Columns.IndexOf("price_adj_amount"));
            dtRefundDetailInformation.Columns.RemoveAt(
                dtRefundDetailInformation.Columns.IndexOf("adj_reason"));
            dtRefundDetailInformation.Columns.RemoveAt(
                dtRefundDetailInformation.Columns.IndexOf("adj_approved_by"));
            dtRefundDetailInformation.Columns.RemoveAt(
                dtRefundDetailInformation.Columns.IndexOf("item_cost"));
            dtRefundDetailInformation.Columns.RemoveAt(
                dtRefundDetailInformation.Columns.IndexOf("item_tax_amount"));
            dtRefundDetailInformation.Columns.RemoveAt(
                dtRefundDetailInformation.Columns.IndexOf("is_void"));
            dtRefundDetailInformation.Columns.RemoveAt(
                dtRefundDetailInformation.Columns.IndexOf("batch_id"));
            dtRefundDetailInformation.Columns.RemoveAt(
                dtRefundDetailInformation.Columns.IndexOf("dept_id"));

            for (int rowCounter = dtRefundDetailInformation.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
            {
                dtRefundDetailInformation.Rows[rowCounter]["TotalAmount"] = decimal.Round(
                    decimal.Parse(dtRefundDetailInformation.Rows[rowCounter]["Quantity"].ToString()) *
                    decimal.Parse(dtRefundDetailInformation.Rows[rowCounter]["UnitPrice"].ToString())
                    , 2, MidpointRounding.ToEven);

                DataTable dtProductInfo =
                    this.getITEMInfo(null, "", "",
                            dtRefundDetailInformation.Rows[rowCounter]["item_id"].ToString(),
                            generalResultInformation.centralStation, "", triaStateBool.Ignor,
                            false, "AND");

                DataTable dtUnitInfo = new DataTable();

                if (dtRefundDetailInformation.Rows[rowCounter]["Description"].ToString() == "")
                {
                    if (this.checkIfTableContainesData(dtProductInfo))
                        dtRefundDetailInformation.Rows[rowCounter]["Description"] =
                            dtProductInfo.Rows[0]["item_name"].ToString();
                }
                if (dtRefundDetailInformation.Rows[rowCounter]["UOM"].ToString() == "")
                {
                    if (this.checkIfTableContainesData(dtProductInfo))
                    {
                        dtUnitInfo =
                            this.getITEM_UNITInfo(null, "", "",
                                    dtProductInfo.Rows[0]["unit_id"].ToString(),
                                    generalResultInformation.centralStation, "",
                                    triaStateBool.Ignor, false, "AND");

                        if (this.checkIfTableContainesData(dtUnitInfo))
                            dtRefundDetailInformation.Rows[rowCounter]["UOM"] =
                                dtUnitInfo.Rows[0]["abbr"].ToString();
                    }
                }
                dtRefundDetailInformation.Rows[rowCounter]["Sn."] = rowCounter + 1;
            }

            //for (int rowCounter = dtSalesDetailInformation.Columns.Count - 1;
            //        rowCounter >= 0; rowCounter--)
            //    if (!generalResultInformation.dtsDocumentPrintView.Tables["dtSalesDetail"].Columns.Contains
            //            (dtMovementDetailInfo.Columns[rowCounter].ColumnName))
            //        dtSalesDetailInformation.Columns.RemoveAt(rowCounter);

            DataRow drNewRefundDetail;
            for (int rowCounter = 0;
                rowCounter <= dtRefundDetailInformation.Rows.Count - 1; rowCounter++)
            {
                drNewRefundDetail =
                    generalResultInformation.dtsDocumentPrintView.Tables["dtrefundDetail"].NewRow();

                drNewRefundDetail["refundDetailId"] =
                    dtRefundDetailInformation.Rows[rowCounter]["refundDetailId"];
                drNewRefundDetail["refundDetailStation"] =
                    dtRefundDetailInformation.Rows[rowCounter]["refundDetailStation"];
                drNewRefundDetail["refundDetailNode"] =
                    dtRefundDetailInformation.Rows[rowCounter]["refundDetailNode"];
                drNewRefundDetail["refundID"] =
                    dtRefundDetailInformation.Rows[rowCounter]["refundID"];
                drNewRefundDetail["item_id"] =
                    dtRefundDetailInformation.Rows[rowCounter]["item_id"];
                drNewRefundDetail["locatorFromId"] =
                    dtRefundDetailInformation.Rows[rowCounter]["locatorFromId"];
                drNewRefundDetail["Sn."] =
                    dtRefundDetailInformation.Rows[rowCounter]["Sn."];
                drNewRefundDetail["Description"] =
                    dtRefundDetailInformation.Rows[rowCounter]["Description"];
                drNewRefundDetail["Quantity"] =
                    dtRefundDetailInformation.Rows[rowCounter]["Quantity"];
                drNewRefundDetail["UOM"] =
                    dtRefundDetailInformation.Rows[rowCounter]["UOM"];
                drNewRefundDetail["UnitPrice"] =
                    dtRefundDetailInformation.Rows[rowCounter]["UnitPrice"];
                drNewRefundDetail["TotalAmount"] =
                    dtRefundDetailInformation.Rows[rowCounter]["TotalAmount"];
                drNewRefundDetail["Comment"] =
                    dtRefundDetailInformation.Rows[rowCounter]["Comment"];

                generalResultInformation.dtsDocumentPrintView.Tables["dtrefundDetail"].Rows.Add(drNewRefundDetail);
            }
        }

                

        public void generateAttachmentReport(string salesId, string station, string node, bool autoGenerate)
        {
            generalResultInformation.requestedDocumenType = reportType.attachment;
            this.establishSalesInformation(salesId, station, node, autoGenerate);
            if (generalResultInformation.documentRequestInfoCancelled)
            {
                return;
            }
            this.establishSalesDetailInformation(salesId, station, node);
            this.establishSellerInformation(salesId, station, node);
            generalResultInformation.requestedDocumenType = reportType.UNKOWN;
        }

        public void generateCustomerDispatchInvoice(string salesId, string station,
                string node, string dispatchStoreId)
        {
            //this.establishSalesInformation(salesId, station, node);
            this.establishCustomerDisaptchInformation(salesId, dispatchStoreId, station, node);
            this.establishCustomerDispatchDetailInformation(salesId, station, node, dispatchStoreId);
        }

        public void generateSalesRefundBook(string refundId, string station, string node)
        {
            generalResultInformation.requestedDocumenType = reportType.refundBook;
            string salesId =
                this.establishRefundInformation(refundId, station, node);

            if (generalResultInformation.documentRequestInfoCancelled)
            {
                return; 
            }
            this.establishRefundDetailInformation(refundId, station, node);

            this.establishSalesInformation(salesId, station, node, false);
            this.establishSalesDetailInformation(salesId, station, node);
            
            //generalResultInformation.requestedDocumenType = reportType.UNKOWN;
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
                        if(number.Length > 1)
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

        public DataTable getUsersInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string USERNAME, string PASSWORD, string USER_TYPE, 
                    string ID, string STATION, string NODE, triaStateBool IS_ACTIVE,
                    bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("USERS", true);
            }

            string whereClause = "WHERE 1";

            if (IS_ACTIVE == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector + " `IS_ACTIVE` = 1";
            }
            else if (IS_ACTIVE == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector + " `IS_ACTIVE` = 0";

            if (USERNAME != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `USERNAME` = '" + USERNAME + "'";

            if (PASSWORD != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `PASSWORD` = '" + PASSWORD + "'";

            if (USER_TYPE != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `USER_TYPE` = '" + USER_TYPE + "'";

            if (ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ID` = " + ID;

            if (STATION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION` = " + STATION;

            if (NODE != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `NODE` = " + NODE;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `USERS` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }


        public DataTable getITEMInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string PRODUCT_ID, string ID, string STATION, string NODE, triaStateBool onlyActiveRecords, 
                        bool structureOnly, string logicalConnector)
        {
            return this.getITEMInfo(criteriaTable, criteriaTableLogicalConnector,
                    PRODUCT_ID, "", ID, STATION, NODE,
                    onlyActiveRecords, structureOnly, logicalConnector);
            
        }

        public DataTable getITEMInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string PRODUCT_ID, string ITEM_NAME, string ID, string STATION, string NODE, triaStateBool onlyActiveRecords,
                        bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("items", true);
            }

            string whereClause = "WHERE 1";

            if (onlyActiveRecords == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector + " `is_active` = 1";
            }
            else if (onlyActiveRecords == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector + " `is_active` = 0";

            if (PRODUCT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `Product_id` = " + PRODUCT_ID;

            if (ITEM_NAME != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ITEM_NAME` LIKE '%" + ITEM_NAME + "%'";

            if (ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ID` = " + ID;

            if (STATION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION` = " + STATION;

            if (NODE != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `NODE` = " + NODE;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `items` " + whereClause + " LIMIT 0 , 10 ";

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }
        
        public DataTable getITEM_UNITInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string UNIT_ID, string ID, string STATION, string NODE, triaStateBool onlyActiveRecords,
                        bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("item_units", true);
            }

            string whereClause = "WHERE 1";

            if (onlyActiveRecords == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector + " `is_active` = 1";
            }
            else if (onlyActiveRecords == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector + " `is_active` = 0";

            if (UNIT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `unit_code` = " + UNIT_ID;

            if (ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ID` = " + ID;

            if (STATION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION` = " + STATION;

            if (NODE != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `NODE` = " + NODE;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `item_units` " + whereClause ;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }

        public DataTable getCATAGORYInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string CATAGORY_CODE, string ID, string STATION, string NODE, triaStateBool onlyActiveRecords,
                        bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("categories", true);
            }

            string whereClause = "WHERE 1";

            if (onlyActiveRecords == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector + " `is_active` = 1";
            }
            else if (onlyActiveRecords == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector + " `is_active` = 0";

            if (CATAGORY_CODE != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `category_code` = " + CATAGORY_CODE;

            if (ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ID` = " + ID;

            if (STATION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION` = " + STATION;

            if (NODE != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `NODE` = " + NODE;
            
            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `categories` " + whereClause + " LIMIT 0 , 50 ";

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }

        public DataTable getTaxTypesInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string tax_type_name, string ID, string STATION, string NODE, triaStateBool onlyActiveRecords,
                        bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("tax_types", true);
            }

            string whereClause = "WHERE 1";

            if (onlyActiveRecords == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector + " `is_active` = 1";
            }
            else if (onlyActiveRecords == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector + " `is_active` = 0";

            if (tax_type_name != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `tax_type_name` = " + tax_type_name;

            if (ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ID` = " + ID;

            if (STATION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION` = " + STATION;

            if (NODE != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `NODE` = " + NODE;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `tax_types` " + whereClause + " LIMIT 0 , 50 ";

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }

        public DataTable getPriceConditionsInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string name, string short_, string ID, string STATION, string NODE, triaStateBool onlyActiveRecords,
                        bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("price_conditions", true);
            }

            string whereClause = "WHERE 1";

            if (onlyActiveRecords == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector + " `is_active` = 1";
            }
            else if (onlyActiveRecords == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector + " `is_active` = 0";

            if (name != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `name` = " + name;

            if (short_ != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `short` = " + short_;

            if (ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ID` = " + ID;

            if (STATION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION` = " + STATION;

            if (NODE != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `NODE` = " + NODE;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `price_conditions` " + whereClause + " LIMIT 0 , 50 ";

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }


        public DataTable getPriceLevelsInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string item_id, string price_cond_id, string ID, string STATION, string NODE,
                    bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("price_levels", true);
            }

            string whereClause = "WHERE 1";
            
            if (item_id != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `item_id` = " + item_id;

            if (price_cond_id != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `price_cond_id` = " + price_cond_id;

            if (ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ID` = " + ID;

            if (STATION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION` = " + STATION;

            if (NODE != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `NODE` = " + NODE;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `price_levels` " + whereClause + " LIMIT 0 , 50 ";

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }



        public DataTable getSalesInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string ID, string STATION, string REF_NO, string NODE, string CUSTOMER_ID, triaStateBool IS_REFUNDED,
                    bool structureOnly, bool latestForStationAndNode, bool latestRefundForStationAndNode,
                    string logicalConnector)
        {
            return this.getSalesInfo(criteriaTable, criteriaTableLogicalConnector, 
                ID, STATION, REF_NO, NODE, CUSTOMER_ID, 
                IS_REFUNDED, PAYMENTRULE.ignor, 0, structureOnly, 
                latestForStationAndNode, latestRefundForStationAndNode, 
                logicalConnector);
        }

        public DataTable getSalesInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string ID, string STATION, string REF_NO, string NODE, string CUSTOMER_ID, triaStateBool IS_REFUNDED,
                    int LIMIT, bool structureOnly, bool latestForStationAndNode, bool latestRefundForStationAndNode,
                    string logicalConnector)
        {
            return this.getSalesInfo(criteriaTable, criteriaTableLogicalConnector,
                ID, STATION, REF_NO, NODE, CUSTOMER_ID,
                IS_REFUNDED, PAYMENTRULE.ignor, LIMIT, structureOnly,
                latestForStationAndNode, latestRefundForStationAndNode,
                logicalConnector);
        }


        public DataTable getSalesInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string ID, string STATION, string REF_NO, string NODE, string CUSTOMER_ID,
                    triaStateBool IS_REFUNDED, PAYMENTRULE PAYMENT_RULE, int LIMIT,
                    bool structureOnly, bool latestForStationAndNode, bool latestRefundForStationAndNode,
                    string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("SALES", true);
            }
            string whereClause = "WHERE 1";

            if (latestForStationAndNode)
            {
                string refundStatus = "";
                if (IS_REFUNDED == triaStateBool.yes)
                {
                    refundStatus = " AND `IS_REFUNDED` = 1";
                }
                else if (IS_REFUNDED == triaStateBool.no)
                    refundStatus = " AND `IS_REFUNDED` = 0";

                string stGetLatestSalesInof =
                        "SELECT *,concat( `date` , ' ', `time` ) as salesDateTime " +
                        "FROM `sales` " +
                        "WHERE `id` = ( " +
                            "SELECT max( `id` ) FROM `sales` " +
                            "WHERE `station` = " + generalResultInformation.Station + " AND " +
                            "`node` = " + generalResultInformation.concernedNode + refundStatus + " ) " +
                        "AND `station` =" + generalResultInformation.Station;

                return (DataTable)executeSqlOnPOS(stGetLatestSalesInof);
            }
            if (latestRefundForStationAndNode)
            {
                DataTable latestRefundInfo =
                    this.getRefundsInfo(null, "", "",
                            generalResultInformation.Station, "",
                            generalResultInformation.concernedNode, "",
                            false, true, "AND");
                //if (!this.checkIfTableContainesData(latestRefundInfo))
                return latestRefundInfo;
                //return this.getSalesInfo(null, "",
                //        latestRefundInfo.Rows[0]["SALE_ID"].ToString(), generalResultInformation.Station, "",
                //        generalResultInformation.concernedNode, "", triaStateBool.yes, false, false, false, "AND");
            }

            //if (IS_REFUNDED == triaStateBool.yes)
            //{
            //    whereClause = whereClause + " " + logicalConnector + " `IS_REFUNDED` = 1";
            //}
            //else if (IS_REFUNDED == triaStateBool.no)
            //    whereClause = whereClause + " " + logicalConnector + " `IS_REFUNDED` = 0";

            if (ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ID` = " + ID;

            if (STATION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION` = " + STATION;

            //if (REF_NO != "")
            //    whereClause = whereClause + " " + logicalConnector +
            //        " (`REF_NO` LIKE '%" + REF_NO + "%'" +
            //        " OR `REF_NOTE` LIKE '%" + REF_NO + "%')";

            //if (REF_NOTE != "")
            //    whereClause = whereClause + " " + logicalConnector +
            //        " (`REF_NOTE` LIKE '%" + REF_NOTE + "%'" +
            //        " OR `REF_NO` LIKE '%" + REF_NOTE + "%')";

            //if (REF_NOTE != "")
            //    REF_NO = REF_NOTE;

            if (REF_NO != "")
            {
                if (generalResultInformation.transationPerf == transactionPerformed.Attachement ||
                generalResultInformation.transationPerf == transactionPerformed.DeliveryOrder ||
                generalResultInformation.transationPerf == transactionPerformed.Refund)
                {
                    whereClause = whereClause + " " + logicalConnector +
                        " COALESCE(CASE `ref_note` WHEN '' THEN NULL " +
                        "ELSE `ref_note` END , REF_NO ) = '" + REF_NO + "'";
                }
                else
                {
                    whereClause = whereClause + " " + logicalConnector +
                        " COALESCE(CASE `ref_note` WHEN '' THEN NULL " +
                        "ELSE `ref_note` END , REF_NO ) LIKE '%" + REF_NO + "%'";
 
                }
            }

            if (NODE != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `NODE` = " + NODE;

            if (CUSTOMER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `customer_id` = " + CUSTOMER_ID;

            if (PAYMENT_RULE != PAYMENTRULE.ignor)
            {
                if (PAYMENT_RULE == PAYMENTRULE.Cash)
                    whereClause = whereClause + " " + logicalConnector +
                        " `cash_credit` = 'CASH'";
                else if (PAYMENT_RULE == PAYMENTRULE.Credit)
                    whereClause = whereClause + " " + logicalConnector +
                        " `cash_credit` = 'CREDIT'";
            }



            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT `flag`, `date`, `time`, `sold_date`, `customer_id`, `customer_name`, `customer_tin`," +
                                           " `discount`, `discount_percent`, `add_on`, `add_on_percent`, `disc_or_add`, `total_tax`, `total_amount`," +
                                           " `with_holding`, `comm_witholding`, `payment_type_id`, `amount_recieved`, `items_sold`, `void_count`," +
                                           " `cashier_id`, `cashier_name`, `sales_rep_id`," +
                                           " CASE WHEN `ref_note` != '' THEN `ref_note` ELSE `ref_no` END AS `ref_no` , `ref_note`, `bill_no`," +
                                           " `table_no`, `is_paid`, `cheque_number`, `cheque_date`, `cash_ref_no`, `credit_ref_no`, `reference`," +
                                           " `voucher_type`, `cash_credit`, `is_refunded`, `transfer_id`, `fs_no`, `comment`, `is_canceled`, `id`," +
                                           " `station`, `node`," +
                                           " `sub_total`, STR_TO_DATE(concat( `date` , ' ', `time` ),'%Y-%m-%d %H:%i:%s') as salesDateTime " +
                                           "FROM `SALES` " +
                                           whereClause +
                                            ((LIMIT.CompareTo(0) != 1) ? (" LIMIT 0, 30") : (" LIMIT 0, " + LIMIT.ToString()));
            
            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }

        public String getNextMachineSerialNumber(bool isSales)
        {
            string stNextMachineSerialNumber = "";

            if (isSales)
            {
                stNextMachineSerialNumber =
                        "SELECT COALESCE(fs_no, 0) + 1 " +
                        "FROM `sales` " +
                        "WHERE `id` = ( " +
                            "SELECT max( `id` ) FROM `sales` " +
                            "WHERE `station` = " + generalResultInformation.Station + " AND " +
                            "`node` = " + generalResultInformation.concernedNode + " AND " +
                            "`fs_no` IS NOT NULL AND `fs_no` != 0 AND `ref_note` = '' ) " +  
                        "AND `station` =" + generalResultInformation.Station;                

            }
            else
            {
                stNextMachineSerialNumber =
                        "SELECT COALESCE(MAX(fs_no), 0) + 1 " +
                        "FROM `refunds` " +
                        "WHERE fs_no IS NOT NULL AND `fs_no` != 0"; 
            }

            DataTable FSINFO = (DataTable)executeSqlOnPOS(stNextMachineSerialNumber);
            if (this.checkIfTableContainesData(FSINFO))
            {
                return FSINFO.Rows[0][0].ToString();
            }
            else
            {
                return "0";
            }
        }



        public DataTable getV_INVOICEDUEAMOUNTInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string ID, string STATION, string REF_NO, string NODE, string CUSTOMER_ID,
                    triaStateBool IS_REFUNDED, int LIMIT, triaStateBool hasUnpaidAmount,
                    string logicalConnector)
        {
            string getRequestedTableInformation = "";
            
            string whereClause = "WHERE 1";
                        
            if (ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ID` = " + ID;

            if (STATION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION` = " + STATION;

            if (REF_NO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `REF_NO` LIKE '%" + REF_NO + "%'";

            if (NODE != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `NODE` = " + NODE;

            if (CUSTOMER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `customer_id` = " + CUSTOMER_ID;

            if (hasUnpaidAmount != triaStateBool.Ignor)
            {
                if (hasUnpaidAmount == triaStateBool.yes)
                    whereClause = whereClause + " " + logicalConnector +
                        " `DUE` != 0";
                else if (hasUnpaidAmount == triaStateBool.no)
                    whereClause = whereClause + " " + logicalConnector +
                         " `DUE` = 0";
            }


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT *,concat( `date` , ' ', `time` ) as salesDateTime " +
                "FROM `V_INVOICEDUEAMOUNT` " +
                whereClause +
                ((LIMIT.CompareTo(0) != 1) ? (" LIMIT 0, 30") : (" LIMIT 0, " + LIMIT.ToString()));

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }



        public DataTable getSalesItemsInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string ID, string STATION, string NODE, triaStateBool IS_ACTIVE,
                    string SALE_ID, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("SALES_ITEMS", true);
            }

            string whereClause = "WHERE 1";
                        
            if (ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ID` = " + ID;

            if (SALE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `SALE_ID` = " + SALE_ID;

            if (STATION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION` = " + STATION;

            if (NODE != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `NODE` = " + NODE;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `SALES_ITEMS` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }


        public DataTable getRefundsInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string ID, string STATION, string REF_NO, string NODE, string SALE_ID, 
                    bool structureOnly, bool latestForStationAndNode, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("refunds", true);
            }
            string whereClause = "WHERE 1";

            if (latestForStationAndNode)
            {
                string stGetLatestRefundInfo =
                        "SELECT * " +
                        "FROM `refunds` " +
                        "WHERE `id` = ( " +
                            "SELECT max( `id` ) FROM `REFUNDS` " +
                            "WHERE `station` = " + generalResultInformation.Station + " AND " +
                            "`node` = " + generalResultInformation.concernedNode + " ) " +
                        "AND `station` =" + generalResultInformation.Station;

                return (DataTable)executeSqlOnPOS(stGetLatestRefundInfo);
            }
            
            //if (SALE_ID != "")
            //    whereClause = whereClause + " " + logicalConnector +
            //        " `SALE_ID` = " + SALE_ID;

            if (ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ID` = " + ID;

            if (STATION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION` = " + STATION;

            if (REF_NO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `REF_NO` LIKE '%" + REF_NO + "%'";

            if (NODE != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `NODE` = " + NODE;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT *,concat( `date` , ' ', `time` ) as refundDateTime " +
                                           "FROM `refunds` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }

        public DataTable getRefundsItemsInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string ID, string STATION, string NODE, triaStateBool IS_ACTIVE,
                    string REFUND_ID, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("REFUNDS_ITEMS", true);
            }

            string whereClause = "WHERE 1";

            if (ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ID` = " + ID;

            if (REFUND_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `SALE_ID` = " + REFUND_ID;

            if (STATION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION` = " + STATION;

            if (NODE != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `NODE` = " + NODE;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `REFUNDS_ITEMS` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }


        public DataTable getCustomersInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string ID, string STATION, string NODE, string customer_name, triaStateBool IS_ACTIVE,
                    bool structureOnly, string logicalConnector)
        {
            return this.getCustomersInfo(criteriaTable, criteriaTableLogicalConnector,
                    ID, STATION, NODE, customer_name, "", IS_ACTIVE, structureOnly,
                    logicalConnector);
        }

        public DataTable getCustomersInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string ID, string STATION, string NODE, string customer_name, string tin_number,
                    triaStateBool IS_ACTIVE, bool structureOnly, string logicalConnector)
        {
            return this.getCustomersInfo(criteriaTable, criteriaTableLogicalConnector,
                    ID, STATION, NODE, customer_name, tin_number, "", "", IS_ACTIVE, structureOnly,
                    logicalConnector, 0);
        }

        public DataTable getCustomersInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string ID, string STATION, string NODE, string customer_name, string tin_number,
                    string phone_office, string phone_mobile, triaStateBool IS_ACTIVE, 
                    bool structureOnly, string logicalConnector, int limit)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("CUSTOMERS", true);
            }

            string whereClause = "WHERE 1";

            if (IS_ACTIVE == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector + " `IS_ACTIVE` = 1";
            }
            else if (IS_ACTIVE == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector + " `IS_ACTIVE` = 0";

            if (ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ID` = " + ID;

            if (STATION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION` = " + STATION;

            if (NODE != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `NODE` = " + NODE;

            if (customer_name != "")
                whereClause = whereClause + " " + logicalConnector +
                    " UCASE(`customer_name`) LIKE '%" + customer_name.ToUpper() + "%'";

            if (tin_number != "")
                whereClause = whereClause + " " + logicalConnector +
                    " UCASE(`tin_number`) LIKE '%" + tin_number.ToUpper() + "%'";

            if (phone_office != "")
                whereClause = whereClause + " " + logicalConnector +
                    " UCASE(`phone_office`) LIKE '%" + phone_office.ToUpper() + "%'";

            if (phone_mobile != "")
                whereClause = whereClause + " " + logicalConnector +
                    " UCASE(`phone_mobile`) LIKE '%" + phone_mobile.ToUpper() + "%'";



            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `CUSTOMERS` " + whereClause + 
                                           " LIMIT 0, " + 
                                           (limit != 0 ? limit.ToString() : "30") ;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }


        public DataTable getStoresInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string ID, string STATION, string NODE, triaStateBool IS_ACTIVE,
                    bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("STORES", true);
            }

            string whereClause = "WHERE 1";

            if (IS_ACTIVE == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector + " `IS_ACTIVE` = 1";
            }
            else if (IS_ACTIVE == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector + " `IS_ACTIVE` = 0";

            if (ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ID` = " + ID;

            if (STATION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION` = " + STATION;

            if (NODE != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `NODE` = " + NODE;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `STORES` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }

        public DataTable getDefaultPriceListInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string ID, string STATION, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("default_price_lst", true);
            }

            string whereClause = "WHERE 1";
                        
            if (ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ID` = " + ID;

            if (STATION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION` = " + STATION;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `default_price_lst` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }


        public DataTable getPaymentTypesInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string ID, string STATION, string NODE, triaStateBool IS_ACTIVE,
                    bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("PAYMENT_TYPES", true);
            }

            string whereClause = "WHERE 1";

            if (IS_ACTIVE == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector + " `IS_ACTIVE` = 1";
            }
            else if (IS_ACTIVE == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector + " `IS_ACTIVE` = 0";

            if (ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ID` = " + ID;

            if (STATION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION` = " + STATION;

            if (NODE != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `NODE` = " + NODE;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `PAYMENT_TYPES` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }

        public DataTable getnodesInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string ID, string STATION, triaStateBool IS_ACTIVE,
                    bool structureOnly, string logicalConnector)
        {
            return this.getnodesInfo(criteriaTable, criteriaTableLogicalConnector,
                    ID, STATION, "", IS_ACTIVE,
                    structureOnly, logicalConnector);
        }

        public DataTable getnodesInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string ID, string STATION, string AD_ORG_ID, triaStateBool IS_ACTIVE,
                    bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("NODES", true);
            }

            string whereClause = "WHERE 1";

            if (IS_ACTIVE == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector + " `IS_ACTIVE` = 1";
            }
            else if (IS_ACTIVE == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector + " `IS_ACTIVE` = 0";

            if (ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ID` = " + ID;

            if (STATION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION` = " + STATION;

            if (AD_ORG_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `AD_ORG_ID` = " + AD_ORG_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `NODES` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }
        

        public DataTable getCompanyInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string ID, string STATION, triaStateBool IS_ACTIVE,
                    bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            //if (structureOnly)
            //{
            //    return this.getDBTableStructure("COMPANY_INFO", true);
            //}

            string whereClause = "WHERE 1";

            //if (IS_ACTIVE == triaStateBool.yes)
            //{
            //    whereClause = whereClause + " " + logicalConnector + " `IS_ACTIVE` = 1";
            //}
            //else if (IS_ACTIVE == triaStateBool.no)
            //    whereClause = whereClause + " " + logicalConnector + " `IS_ACTIVE` = 0";

            if (ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ID` = " + ID;

            //if (STATION != "")
            //    whereClause = whereClause + " " + logicalConnector +
            //        " `STATION` = " + STATION;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `COMPANY_INFO` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }

        public DataTable getCustomerDispatchInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string SALESID, string CUSTOMERID, string STOREID, string STATION, string REF_NO,
                    string NODE, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("CUSTOMER_DISPATCH", true);
            }
            string whereClause = "WHERE 1";

            if (SALESID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `SALES_ID` = " + SALESID;

            if (CUSTOMERID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `CUSTOMER_ID` = " + CUSTOMERID;

            if (STOREID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `SOLD_FROM_STORE_ID` = " + STOREID;

            if (STATION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION` = " + STATION;

            if (REF_NO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `REF_NO` = " + REF_NO;

            if (NODE != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `NODE` = " + NODE;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `CUSTOMER_DISPATCH` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }


        public DataTable getPrintJobInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string ID, string STATION, string NODE, string REF_NO, string TABLENAME,
                    bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("PRINT_JOB", true);
            }
            string whereClause = "WHERE 1";

            if (ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ID` = " + ID;

            if (STATION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION` = " + STATION;          

            if (NODE != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `NODE` = " + NODE;

            if (TABLENAME != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `TABLENAME` = '" + TABLENAME + "'";

            if (REF_NO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `RECORDREFERENCE` = " + REF_NO;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `PRINT_JOB` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }


        public DataTable getAD_SEQUENCEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string STATION_ID, string AD_SEQUENCE_ID, string NAME, bool onlyActiveRecords,
             bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("AD_SEQUENCE_ID",true);
            }


            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION_ID` = " + STATION_ID;

            if (AD_SEQUENCE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `AD_SEQUENCE_ID` = " + AD_SEQUENCE_ID;

            if (NAME != "")
                whereClause = whereClause + " " + logicalConnector +
                    " UCASE(`NAME`) = '" + NAME.Replace("'", "''") + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `AD_SEQUENCE` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }

        
        public DataTable getAD_USER_ORGACCESSInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string AD_USER_ID, bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("AD_USER_ORGACCESS", true);
            }


            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (AD_ORG_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `AD_ORG_ID` = " + AD_ORG_ID;

            if (AD_USER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `AD_USER_ID` = " + AD_USER_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `AD_USER_ORGACCESS` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }

        public DataTable getAD_USERInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_USER_ID, string UserName, string PassWord, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("AD_USER", true);
            }


            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (AD_USER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `AD_USER_ID` = " + AD_USER_ID;

            if (UserName != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `NAME` = '" + UserName.Replace("'", "''") + "'";

            if (PassWord != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `PASSWORD` = '" + PassWord.Replace("'", "''") + "'";

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `AD_USER` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }

        public DataTable getSTATIONInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string STATION_ID, bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("STATION", true);
            }
            
            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ID` = " + STATION_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `STATION` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }

        public DataTable getUSER_STATIONACCESSInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string STATION_ID, string AD_USER_ID, bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("USER_STATIONACCESS", true);
            }


            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION_ID` = " + STATION_ID;

            if (AD_USER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `AD_USER_ID` = " + AD_USER_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `USER_STATIONACCESS` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }

        



        public DataTable getC_EXEMPTIONInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_EXEMPTION_ID, string DOCUMENTNO, string C_BPARTNER_ID, DateTime DATEINVOICED, bool useDate,
            exemptionType EXEMPTIONTYPE, string STATION_ID,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("C_EXEMPTION", true);
            }


            string whereClause = "WHERE 1";

            if (onlyActiveRecords)
                whereClause = whereClause + " " + logicalConnector + 
                    " `ISACTIVE` = 'Y'";            

            if (C_EXEMPTION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_EXEMPTION_ID` = " + C_EXEMPTION_ID;

            if (DOCUMENTNO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `DOCUMENTNO` LIKE '%" + DOCUMENTNO.Replace("'", "''") + "%'";

            if (C_BPARTNER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_BPARTNER_ID` = " + C_BPARTNER_ID;

            if (useDate != false)
                whereClause = whereClause + " " + logicalConnector +
                    " `DATEINVOICED` = '" + DATEINVOICED.ToString("yyyy-MM-dd");

            if (EXEMPTIONTYPE !=  exemptionType.ignor)
                whereClause = whereClause + " " + logicalConnector +
                    " `EXEMPTIONTYPE` = '" + EXEMPTIONTYPE.ToString() + "'";

            if (STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION_ID` = " + STATION_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `C_EXEMPTION` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }


        public DataTable getC_EXEMPTIONLINEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_EXEMPTIONLINE_ID, string C_EXEMPTION_ID,
            string SALES_ID, string STATION_ID,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("C_EXEMPTIONLINE", true);
            }
            
            string whereClause = "WHERE 1";

            if (onlyActiveRecords)
                whereClause = whereClause + " " + logicalConnector +
                    " `ISACTIVE` = 'Y'";

            if (C_EXEMPTION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_EXEMPTION_ID` = " + C_EXEMPTION_ID;

            if (C_EXEMPTIONLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_EXEMPTIONLINE_ID` = " + C_EXEMPTIONLINE_ID;

            if (SALES_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `SALES_ID` = " + SALES_ID;

            if (STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION_ID` = " + STATION_ID;

            
            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `C_EXEMPTIONLINE` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }


        public DataTable getV_EXEMPTIONDTLInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_EXEMPTION_ID, string DOCUMENTNO, string C_BPARTNER_ID, 
            DateTime DATEINVOICED, bool useDate, exemptionType EXEMPTIONTYPE, 
            string STATION_ID, string SALES_ID,
            bool onlyActiveRecords, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            
            string whereClause = "WHERE 1";

            if (onlyActiveRecords)
                whereClause = whereClause + " " + logicalConnector +
                    " `ISACTIVE` = 'Y'";

            if (C_EXEMPTION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_EXEMPTION_ID` = " + C_EXEMPTION_ID;

            if (DOCUMENTNO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `DOCUMENTNO` LIKE '%" + DOCUMENTNO.Replace("'", "''") + "%'";

            if (C_BPARTNER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_BPARTNER_ID` = " + C_BPARTNER_ID;

            if (useDate != false)
                whereClause = whereClause + " " + logicalConnector +
                    " `DATEINVOICED` = '" + DATEINVOICED.ToString("yyyy-MM-dd") + "'";

            if (EXEMPTIONTYPE != exemptionType.ignor)
                whereClause = whereClause + " " + logicalConnector +
                    " `EXEMPTIONTYPE` = '" + EXEMPTIONTYPE.ToString() + "'";

            if (STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION_ID` = " + STATION_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `V_EXEMPTIONDTL` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }


        public DataTable getC_PAYMENTInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_PAYMENT_ID, string DOCUMENTNO, string C_BPARTNER_ID, DateTime DATETRX, bool useDate,
            tenderType TENDERTYPE, string CHECKNO, string STATION_ID,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("C_PAYMENT", true);
            }


            string whereClause = "WHERE 1";

            if (onlyActiveRecords)
                whereClause = whereClause + " " + logicalConnector +
                    " `ISACTIVE` = 'Y'";

            if (C_PAYMENT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_PAYMENT_ID` = " + C_PAYMENT_ID;

            if (DOCUMENTNO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `DOCUMENTNO` LIKE '%" + DOCUMENTNO.Replace("'", "''") + "%'";

            if (C_BPARTNER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_BPARTNER_ID` = " + C_BPARTNER_ID;

            if (useDate != false)
                whereClause = whereClause + " " + logicalConnector +
                    " `DATETRX` = '" + DATETRX.ToString("yyyy-MM-dd") + "'";

            if (TENDERTYPE != tenderType.ignor)
                whereClause = whereClause + " " + logicalConnector +
                    " `TENDERTYPE` = '" + TENDERTYPE.ToString() + "'";

            if (CHECKNO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `CHECKNO` = " + CHECKNO;

            if (STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION_ID` = " + STATION_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `C_PAYMENT` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }


        public DataTable getC_PAYMENTALLOCATEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_PAYMENTALLOCATE_ID, string C_PAYMENT_ID,
            string C_INVOICE_ID, triaStateBool ISEXEMPTION, string STATION_ID,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("C_PAYMENTALLOCATE", true);
            }

            string whereClause = "WHERE 1";

            if (onlyActiveRecords)
                whereClause = whereClause + " " + logicalConnector +
                    " `ISACTIVE` = 'Y'";

            if (C_PAYMENT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_PAYMENT_ID` = " + C_PAYMENT_ID;

            if (C_PAYMENTALLOCATE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_PAYMENTALLOCATE_ID` = " + C_PAYMENTALLOCATE_ID;

            if (C_INVOICE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_INVOICE_ID` = " + C_INVOICE_ID;

            if (STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION_ID` = " + STATION_ID;

            if (ISEXEMPTION != triaStateBool.Ignor)
            { 
                if( ISEXEMPTION == triaStateBool.yes)
                    whereClause = whereClause + " " + logicalConnector +
                        " `ISEXEMPTION` = 'Y'";
                else
                    whereClause = whereClause + " " + logicalConnector +
                        " `ISEXEMPTION` = 'N'";
            }


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `C_PAYMENTALLOCATE` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }
        

        public DataTable getV_PAYMENTDTLInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_PAYMENT_ID, string DOCUMENTNO, string C_BPARTNER_ID,
            DateTime DATETRX, bool useDate, tenderType TENDERTYPE,
            string STATION_ID, string SALES_ID,
            bool onlyActiveRecords, string logicalConnector)
        {
            string getRequestedTableInformation = "";

            string whereClause = "WHERE 1";

            if (onlyActiveRecords)
                whereClause = whereClause + " " + logicalConnector +
                    " `ISACTIVE` = 'Y'";

            if (C_PAYMENT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_PAYMENT_ID` = " + C_PAYMENT_ID;

            if (DOCUMENTNO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `DOCUMENTNO` = '" + DOCUMENTNO.Replace("'", "''") + "'";

            if (C_BPARTNER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_BPARTNER_ID` = " + C_BPARTNER_ID;

            if (useDate != false)
                whereClause = whereClause + " " + logicalConnector +
                    " `DATETRX` = '" + DATETRX.ToString("yyyy-MM-dd") + "'";

            if (TENDERTYPE != tenderType.ignor)
                whereClause = whereClause + " " + logicalConnector +
                    " `TENDERTYPE` = '" + TENDERTYPE.ToString() + "'";

            if (STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION_ID` = " + STATION_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `V_PAYMENTDTL` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }



        public DataTable getC_ALLOCATIONHDRInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_ALLOCATIONHDR_ID, string DOCUMENTNO, DateTime DATETRX, bool useDate,
            string STATION_ID, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("C_ALLOCATIONHDR", true);
            }


            string whereClause = "WHERE 1";

            if (C_ALLOCATIONHDR_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_ALLOCATIONHDR_ID` = " + C_ALLOCATIONHDR_ID;

            if (DOCUMENTNO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `DOCUMENTNO` LIKE '%" + DOCUMENTNO.Replace("'", "''") + "%'";

            if (useDate != false)
                whereClause = whereClause + " " + logicalConnector +
                    " `DATETRX` = '" + DATETRX.ToString("yyyy-MM-dd") + "'";

            if (STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION_ID` = " + STATION_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `C_ALLOCATIONHDR` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }


        public DataTable getC_ALLOCATIONLINEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_ALLOCATIONLINE_ID, string C_ALLOCATIONHDR_ID, DateTime DATETRX, bool useDate,
            string C_INVOICE_ID, string C_BPARTNER_ID, string C_PAYMENT_ID,
            triaStateBool ISEXEMPTION, string STATION_ID,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("C_ALLOCATIONLINE", true);
            }

            string whereClause = "WHERE 1";

            if (onlyActiveRecords)
                whereClause = whereClause + " " + logicalConnector +
                    " `ISACTIVE` = 'Y'";

            if (C_ALLOCATIONHDR_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_ALLOCATIONHDR_ID` = " + C_ALLOCATIONHDR_ID;

            if (C_ALLOCATIONLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_ALLOCATIONLINE_ID` = " + C_ALLOCATIONLINE_ID;

            if (C_INVOICE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_INVOICE_ID` = " + C_INVOICE_ID;

            if (C_PAYMENT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_PAYMENT_ID` = " + C_PAYMENT_ID;

            if (C_BPARTNER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_BPARTNER_ID` = " + C_BPARTNER_ID;


            if (STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION_ID` = " + STATION_ID;

            if (ISEXEMPTION != triaStateBool.Ignor)
            {
                if (ISEXEMPTION == triaStateBool.yes)
                    whereClause = whereClause + " " + logicalConnector +
                        " `ISEXEMPTION` = 'Y'";
                else
                    whereClause = whereClause + " " + logicalConnector +
                        " `ISEXEMPTION` = 'N'";
            }


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `C_ALLOCATIONLINE` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }
                


        public DataTable getC_CASHInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_CASH_ID, string C_CASHBOOK_ID, string NAME, DateTime STATEMENTDATE, bool useDate,
            string STATION_ID,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("C_CASH", true);
            }


            string whereClause = "WHERE 1";

            if (onlyActiveRecords)
                whereClause = whereClause + " " + logicalConnector +
                    " `ISACTIVE` = 'Y'";

            if (C_CASH_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_CASH_ID` = " + C_CASH_ID;

            if (NAME != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `NAME` LIKE '%" + NAME.Replace("'", "''") + "%'";

            if (C_CASHBOOK_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_CASHBOOK_ID` = " + C_CASHBOOK_ID;

            if (useDate != false)
                whereClause = whereClause + " " + logicalConnector +
                    " `STATEMENTDATE` = '" + STATEMENTDATE.ToString("yyyy-MM-dd") + "'";
            
            if (STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION_ID` = " + STATION_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `C_CASH` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }



        public DataTable getC_CASHLINEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_CASHLINE_ID, string C_BANKACCOUNT_ID, string C_CASH_ID, string STATION_ID,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {            
            return this.getC_CASHLINEInfo(criteriaTable, criteriaTableLogicalConnector,
            C_CASHLINE_ID, C_BANKACCOUNT_ID, C_CASH_ID, "", STATION_ID,
            onlyActiveRecords, structureOnly, logicalConnector);
        }

        public DataTable getC_CASHLINEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_CASHLINE_ID, string C_BANKACCOUNT_ID, string C_CASH_ID,
            string CHECKNO, string STATION_ID,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("C_CASHLINE", true);
            }


            string whereClause = "WHERE 1";

            if (onlyActiveRecords)
                whereClause = whereClause + " " + logicalConnector +
                    " `ISACTIVE` = 'Y'";

            if (C_CASHLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_CASHLINE_ID` = " + C_CASHLINE_ID;

            if (C_BANKACCOUNT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_BANKACCOUNT_ID` = " + C_BANKACCOUNT_ID;

            if (CHECKNO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `CHECKNO` LIKE '%" + CHECKNO + "%'";

            if (C_CASH_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_CASH_ID` = " + C_CASH_ID;

            if (STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION_ID` = " + STATION_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `C_CASHLINE` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }


        public DataTable getC_CASHLINESOURCEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_CASHLINESOURCE_ID, string C_CASHLINE_ID, CashSourceType SOURCETYPE,
            string C_PAYMENT_ID, string C_INVOICE_ID, string C_EXEMPTION_ID,
            string STATION_ID,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("C_CASHLINESOURCE", true);
            }


            string whereClause = "WHERE 1";

            if (onlyActiveRecords)
                whereClause = whereClause + " " + logicalConnector +
                    " `ISACTIVE` = 'Y'";

            if (C_CASHLINESOURCE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_CASHLINESOURCE_ID` = " + C_CASHLINESOURCE_ID;

            if (C_CASHLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_CASHLINE_ID` = " + C_CASHLINE_ID;

            if (SOURCETYPE != CashSourceType.ignor)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " `SOURCETYPE` = '" + SOURCETYPE.ToString() + "'";
            }


            if (C_PAYMENT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_PAYMENT_ID` = " + C_PAYMENT_ID;

            if (C_INVOICE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_INVOICE_ID` = " + C_INVOICE_ID;

            if (C_EXEMPTION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_EXEMPTION_ID` = " + C_EXEMPTION_ID;


            if (STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION_ID` = " + STATION_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `C_CASHLINESOURCE` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }


        public DataTable getV_DEPOSITDTLInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_CASH_ID, string C_CASHBOOK_ID, string NAME, DateTime STATEMENTDATE, bool useDate,
            string C_CASHLINE_ID, string C_BANKACCOUNT_ID,
            string C_CASHLINESOURCE_ID, CashSourceType SOURCETYPE,
            string C_PAYMENT_ID, string C_INVOICE_ID, string C_EXEMPTION_ID,
            string STATION_ID,
            bool onlyActiveRecords, string logicalConnector)
        {
            string getRequestedTableInformation = "";

            string whereClause = "WHERE 1";

            if (onlyActiveRecords)
                whereClause = whereClause + " " + logicalConnector +
                    " `ISACTIVE` = 'Y'";

            if (C_CASH_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_CASH_ID` = " + C_CASH_ID;

            if (NAME != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `NAME` = '" + NAME.Replace("'", "''") + "'";

            if (C_CASHBOOK_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_CASHBOOK_ID` = " + C_CASHBOOK_ID;

            if (useDate != false)
                whereClause = whereClause + " " + logicalConnector +
                    " `STATEMENTDATE` = '" + STATEMENTDATE.ToString("yyyy-MM-dd") + "'";

            if (C_CASHLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_CASHLINE_ID` = " + C_CASHLINE_ID;

            if (C_BANKACCOUNT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_BANKACCOUNT_ID` = " + C_BANKACCOUNT_ID;

            if (C_CASHLINESOURCE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_CASHLINESOURCE_ID` = " + C_CASHLINESOURCE_ID;
            
            if (SOURCETYPE != CashSourceType.ignor)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " `SOURCETYPE` = '" + SOURCETYPE.ToString() + "'";
            }
            
            if (C_PAYMENT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_PAYMENT_ID` = " + C_PAYMENT_ID;

            if (C_INVOICE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_INVOICE_ID` = " + C_INVOICE_ID;

            if (C_EXEMPTION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_EXEMPTION_ID` = " + C_EXEMPTION_ID;

            

            if (STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION_ID` = " + STATION_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `V_DEPOSITDTL` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }
        

        public DataTable getC_BANKACCOUNTInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_BANKACCOUNT_ID, string ACCOUNTNO,            
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("C_BANKACCOUNT", true);
            }


            string whereClause = "WHERE 1";

            if (onlyActiveRecords)
                whereClause = whereClause + " " + logicalConnector +
                    " `ISACTIVE` = 'Y'";

            if (C_BANKACCOUNT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_BANKACCOUNT_ID` = " + C_BANKACCOUNT_ID;

            if (ACCOUNTNO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ACCOUNTNO` like '%" + ACCOUNTNO.Replace("'", "''") + "%'";
                        

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `C_BANKACCOUNT` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }



        public DataTable getC_CHARGEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_CHARGE_ID, string NAME, string STATION_ID,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("C_CHARGE", true);
            }


            string whereClause = "WHERE 1";

            if (onlyActiveRecords)
                whereClause = whereClause + " " + logicalConnector +
                    " `ISACTIVE` = 'Y'";

            if (C_CHARGE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_CHARGE_ID` = " + C_CHARGE_ID;

            if (NAME != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `NAME` LIKE '%" + NAME.Replace("'", "''") + "%'";
            
            if (STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION_ID` = " + STATION_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `C_CHARGE` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }



        public DataTable getV_STOCKInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_PRODUCT_ID, string M_LOCATOR_ID, string logicalConnector)
        {
            string getRequestedTableInformation = "";

            string whereClause = "WHERE 1";

            if (M_PRODUCT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_PRODUCT_ID` = " + M_PRODUCT_ID;

            if (M_LOCATOR_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_LOCATOR_ID` = " + M_LOCATOR_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `V_STOCK` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }

        public bool isStockCorrect()
        {
            string getRequestedTableInformation = "";

            getRequestedTableInformation = "SELECT M_PRODUCT_ID, M_LOCATOR_ID, SUM(QTYONHAND) " +
                                           "FROM V_STOCK " +
                                           "WHERE M_LOCATOR_ID IN (SELECT M_LOCATOR_ID FROM easymove.station_warehouse ) " +
                                           "GROUP BY M_PRODUCT_ID, M_LOCATOR_ID " +
                                           "HAVING SUM(QTYONHAND) < 0";

            return !this.checkIfTableContainesData((DataTable)executeSqlOnPOS(getRequestedTableInformation), false);
        }

        
        //General Functions

        
        public string getNextSequenceId(string Name, string AD_SEQUENCE_ID, string STATION_ID,
            string AD_ORG_ID, bool incrementToNextSequence)
        {
            string nextPrimaryKey = "";
            string preFix = "";
            string suffix = "";

            if (Name == "" && AD_SEQUENCE_ID == "")
                return "";
            if (STATION_ID == "")
                STATION_ID = generalResultInformation.Station;

            DataTable sequenceRecord =
                this.getAD_SEQUENCEInfo(null, "", STATION_ID, AD_SEQUENCE_ID,
                                    Name, true, false, "AND");

            if (sequenceRecord.Rows.Count <= 0)
                return "";
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
                this.changeDataBaseTableData(sequenceRecord, "AD_SEQUENCE", "Update", true);
            }


            return preFix + nextPrimaryKey + suffix;
        }

                
        public string[] changeDataBaseTableData(DataTable dataToEffectTheChange,
            string tableNameToChangeData, string dmlType, bool isPOSDB)
        {
            return this.changeDataBaseTableData(dataToEffectTheChange, 
                    tableNameToChangeData, dmlType, isPOSDB, false);
        }


        public string[] changeDataBaseTableData(DataTable dataToEffectTheChange,
            string tableNameToChangeData, string dmlType, bool isPOSDB, bool primaryKeyIsDBBased)
        {
            string[] primaryKeysForNewInsertion =
                new string[dataToEffectTheChange.Rows.Count];

            if (primaryKeysForNewInsertion.Length > 0)
                primaryKeysForNewInsertion[0] = "";

            if (!this.checkIfTableContainesData(dataToEffectTheChange))
                return primaryKeysForNewInsertion;

            DataTable structureOfTableToChangeData =
                this.getDBTableStructure(tableNameToChangeData, isPOSDB);

            if (structureOfTableToChangeData == null)
            {
                dbCommitFailure.dbCommitError = true;
                dbCommitFailure.dbCommitErrorMessage = "Table Structure not found";
                return primaryKeysForNewInsertion;
            }

            if (structureOfTableToChangeData.Columns.Count < 1)
            {
                dbCommitFailure.dbCommitError = true;
                dbCommitFailure.dbCommitErrorMessage = "Table Structure not found";
                return primaryKeysForNewInsertion;
            }

            string[] tablePrimaryKeys;

            tablePrimaryKeys =
                this.getPOSDBTableConnectorKey(tableNameToChangeData);
            this.fieldSeparator = "`";

            foreach (string primaryKey in tablePrimaryKeys)
                if (!dataToEffectTheChange.Columns.Contains(primaryKey))
                {
                    dbCommitFailure.dbCommitError = true;
                    dbCommitFailure.dbCommitErrorMessage = "Primary Key Column not found";
                    return primaryKeysForNewInsertion;
                }
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
                    this.changeDataBaseTableData(newDataTable, tableNameToChangeData, 
                            dmlType, isPOSDB, primaryKeyIsDBBased);

                int numberOfResult = resultTablePrimarykey1.Length;
                while (numberOfResult > 0)
                {
                    dataToEffectTheChange.Rows.RemoveAt(0);
                    numberOfResult--;
                }
                string[] resultTablePrimarykey2 =
                   this.changeDataBaseTableData(dataToEffectTheChange, tableNameToChangeData,
                        dmlType, isPOSDB, primaryKeyIsDBBased);

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
            if (!primaryKeyIsDBBased)
            {
                foreach (string primaryKey in tablePrimaryKeys)
                    if (dataToEffectTheChange.Rows[0][primaryKey].ToString() == "")
                    {
                        nextTablePrimaryKey = this.getNextSequenceId(tableNameToChangeData, "", "", "", true);
                        if (nextTablePrimaryKey != "")
                        {
                            dataToEffectTheChange.Rows[0][primaryKey] = nextTablePrimaryKey;
                            dmlType = "INSERT";
                            primaryKeysForNewInsertion[0] = primaryKeysForNewInsertion[0] +
                                primaryKey + " <(" + nextTablePrimaryKey + ")>||";
                        }
                        else
                        {
                            dbCommitFailure.dbCommitError = true;
                            dbCommitFailure.dbCommitErrorMessage = "Primary Key Can not be generated";
                            return primaryKeysForNewInsertion;
                        }
                    }
            }

            if (dmlType.ToUpper() == "INSERT")
            {
                if (!dataToEffectTheChange.Columns.Contains("CREATED"))
                    dataToEffectTheChange.Columns.Add("CREATED", Type.GetType("System.DateTime"));

                if (!dataToEffectTheChange.Columns.Contains("CREATEDBY"))
                    dataToEffectTheChange.Columns.Add("CREATEDBY");

                dataToEffectTheChange.Rows[0]["CREATED"] = DateTime.Now;
                dataToEffectTheChange.Rows[0]["CREATEDBY"] = generalResultInformation.userId;
            }


            if (!dataToEffectTheChange.Columns.Contains("UPDATED"))
                dataToEffectTheChange.Columns.Add("UPDATED", Type.GetType("System.DateTime"));

            if (!dataToEffectTheChange.Columns.Contains("UPDATEDBY"))
                dataToEffectTheChange.Columns.Add("UPDATEDBY");


            dataToEffectTheChange.Rows[0]["UPDATED"] = DateTime.Now;
            dataToEffectTheChange.Rows[0]["UPDATEDBY"] = generalResultInformation.userId;


            for (int currentModifyDataTableColumn = dataToEffectTheChange.Columns.Count - 1;
                currentModifyDataTableColumn >= 0; currentModifyDataTableColumn--)
            {
                if (!structureOfTableToChangeData.Columns.Contains(
                    dataToEffectTheChange.Columns[currentModifyDataTableColumn].ColumnName))
                    dataToEffectTheChange.Columns.RemoveAt(currentModifyDataTableColumn);
            }


            string dmlStatementForTable = "";
            if (isPOSDB)
                DateFormat = "yyyy-MM-dd HH-mm-ss";
            else
                DateFormat = "dd-MMM-yyyy";

            dmlStatementForTable =
                this.DMLScriptCreator(tableNameToChangeData, tablePrimaryKeys,
                this.removeEmptyColumnFromRow(dataToEffectTheChange), 0, dmlType.ToUpper());

            //Execute.

            if (dmlStatementForTable != "")
            {
                this.executeSqlOnPOS(dmlStatementForTable);
            }

            //The return Array Format is arrayIndex[0]=|primaryKeyName1forRowOne<("theNewPrimaryKey")>|| ...
            //primaryKeyName2forRowOne<("theNewPrimaryKey")>|| ...,
            //arrayIndex[1]=|primaryKeyName1forRow2<("theNewPrimaryKey")>||
            //primaryKeyName2forRow2<("theNewPrimaryKey")>||...
            return primaryKeysForNewInsertion;
        }

        // Station Performance Checker

        public void updateStationOverAllPerformance()
        {
            string getRequestedTableInformation = 
                        "SELECT PER_OPENRECORDCOUNT(" + generalResultInformation.Station + ")";

            executeSqlOnPOS(getRequestedTableInformation);
        }

        public DataTable getPER_OPENRECORDInfo()
        {
            string getRequestedTableInformation =
                        "SELECT * FROM PER_OPENRECORD";

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }

        public DateTime getLastAuditedSalesDate()
        {
            string getRequestedTableInformation =
                        "SELECT * FROM PER_AUDITREPORT" +
                        " WHERE STATION_ID = " + generalResultInformation.Station;

            DateTime lastReportDate = 
                DateTime.Now.AddDays(-2);

            DataTable reportInfo =
                (DataTable) executeSqlOnPOS(getRequestedTableInformation);

            if (this.checkIfTableContainesData(reportInfo))
            {
                lastReportDate =
                    DateTime.Parse(reportInfo.Rows[0]["REPORTEDDATE"].ToString());
            }

            return lastReportDate;
        }

        public DateTime getKPIExemptedDate()
        {
            string getRequestedTableInformation =
                        "SELECT * FROM PER_SKIP_KPI_CHECK" +
                        " WHERE STATION_ID = " + generalResultInformation.Station;

            DateTime lastReportDate =
                DateTime.Now.AddDays(-2);

            DataTable reportInfo =
                (DataTable)executeSqlOnPOS(getRequestedTableInformation);

            if (this.checkIfTableContainesData(reportInfo))
            {
                lastReportDate =
                    DateTime.Parse(reportInfo.Rows[0]["DATESKIPPED"].ToString());
            }

            return lastReportDate;
        }

        public void updatePER_SKIP_KPI_CHECK()
        {
            string updateScript = "UPDATE PER_SKIP_KPI_CHECK " +
                                  "SET DATESKIPPED = '" + DateTime.Now.ToString("yyyy-MM-dd") + "', " +
                                  "STATION_ID = " + generalResultInformation.Station;

            this.executeSqlOnPOS(updateScript);
        }
    

    }
}


        