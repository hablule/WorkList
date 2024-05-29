using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;


namespace POSDataBridge
{    
    class dataBuilder
    {

        private const string dateFormatForLogDirectoryName = "yyyy-MM-dd";
        private const string dateFormatForLogFileName = "yyyy-MM-dd HH-mm-ss";
        private const string emergenceLogDirectoryPath = @"emergencyLog//";

        public string AD_CLIENT_ID = "1000000";
        public string CREATED = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
        public string CREATEDBY = "1000002";
        public string UPDATED = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
        public string UPDATEDBY = "1000002";
        public string fieldSeparator = "`";
        private string DateFormat = "";

        public bool recordStatusUpdate = true;
        private bool posExecuteOnError = false;
        private bool compExecuteOnError = false;
        private bool sourceDBIsPos = false;


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
        
        public bool checkIfTableContainesData(DataTable dtTableToCheck)
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
                        fieldSeparator + primaryKeys[i].ToString() +
                        fieldSeparator + " = ";
                    if (dt.Rows[rowIndex][primaryKeys[i].ToString()].
                                GetType().ToString() == "System.String")
                    {
                        primaryColIDCondition += "'" + 
                            dt.Rows[rowIndex][primaryKeys[i].ToString()].ToString() + "'";
                    }
                    else if(dt.Rows[rowIndex][primaryKeys[i].ToString()].
                                GetType().ToString() == "System.DateTime")
                    {
                        primaryColIDCondition += "'" +
                            ((DateTime) dt.Rows[rowIndex][primaryKeys[i].ToString()])
                                    .ToString(DateFormat) + "'";
                    }                    
                    else
                    {
                        primaryColIDCondition +=
                            dt.Rows[rowIndex][primaryKeys[i].ToString()].ToString();
                    }                    

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
                        filePath = dbSettingInformationHandler.posScriptDirectory;
                        extension = ".srp";
                        break;
                    case logType.warnning:
                        filePath = dbSettingInformationHandler.posWarningDirectory;
                        extension = ".wrn";
                        break;
                    case logType.error:
                        filePath = dbSettingInformationHandler.posErrorDirectory;
                        extension = ".err";
                        break;
                    default:
                        filePath = emergenceLogDirectoryPath;
                        extension = ".emr";
                        break;
                }
            }
            else
            {
                posCompiereIdentifier = "CP";
                switch (_logType)
                {
                    case logType.script:
                        filePath = dbSettingInformationHandler.compScriptDirectory;
                        extension = ".srp";
                        break;
                    case logType.warnning:
                        filePath = dbSettingInformationHandler.compWarningDirectory;
                        extension = ".wrn";
                        break;
                    case logType.error:
                        filePath = dbSettingInformationHandler.compErrorDirectory;
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
            string mySqlDataBaseType = dbSettingInformationHandler.posDataBaseType;
            string mySqlHostName = dbSettingInformationHandler.posHostName;
            string mySqlDataBaseName = dbSettingInformationHandler.posDataBaseName;
            string mySqlUserName = dbSettingInformationHandler.posDBUserName;
            string mySqlPassWord = dbSettingInformationHandler.posDBPassword;
            string mySqlPort = dbSettingInformationHandler.posDBPort;
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
                        if (dbSettingInformationHandler.posLogChangeScript)
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

        public object executeSqlOnCompiere(string sqlCommand)
        {
            DataTable resultOfQuery = new DataTable();
            int rowsAffected = 0;
            persistanceClass compiereConnection;
            string connectionStatus;
            string oraDataBaseType = dbSettingInformationHandler.compDataBaseType;
            string oraHostName = dbSettingInformationHandler.compHostName;
            string oraDataBaseName = dbSettingInformationHandler.compDataBaseName;
            string oraUserName = dbSettingInformationHandler.compDBUsername;
            string oraPassWord = dbSettingInformationHandler.compDBPassword;
            string oraPort = dbSettingInformationHandler.compDBPort;
            this.compExecuteOnError = false;

            sqlCommand = sqlCommand.Replace("commSepartor", "");

            compiereConnection = new persistanceClass(oraDataBaseType, oraHostName,
                oraDataBaseName, oraUserName, oraPassWord, oraPort);

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
                        if (dbSettingInformationHandler.compLogChangeScript)
                            this.writeTextLinetoFile(sqlCommand, logType.script, sourceDBIsPos);
                    }
                    else
                    {
                        this.compExecuteOnError = true;
                    }
                    return rowsAffected;
                }
            }
            compiereConnection.closeConnection(compiereConnection);
            return resultOfQuery;
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
                _fieldSeparator = "`";
            
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
                            " " + delimApostrophy + _criteriaTable.Rows[rowCounter]["Value"].ToString().Replace("'", "''")
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
            //PROVIDE KEYS WHICH CONNECT POS TO COMPIERE (MAY NOT BE NECESSARILY PRIMARY KEY ON POS TABLE)
            
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
            else if (tableName == "C_BP_CUSTOMER_ACCT")
            { primarykeys = new string[] { "C_ACCTSCHEMA_ID", "C_BPARTNER_ID" }; }
            else if (tableName == "DUP_C_LOCATION" ||
                     tableName == "DUP_C_BPARTNER" ||
                     tableName == "DUP_C_BPARTNER_LOCATION" ||
                     tableName == "DUP_C_ORDER" ||
                     tableName == "DUP_C_ORDERLINE" ||
                     tableName == "UTL_CHANGE_ORDER"
                     )
            { primarykeys = new string[] { "CHANGE_SEQUENCE_ID" }; }
            else if (tableName == "DTN_C_BPARTNER")
            { primarykeys = new string[] { "ID","STATION" }; }

            else if (tableName == "DTN_C_ORDER" ||
                     tableName == "DTN_C_ORDERLINE"
                     )
            { primarykeys = new string[] { "ID", "STATION","TYPE" }; }
            else if (tableName == "DTN_C_BPARTNER")
            { primarykeys = new string[] { "ID", "STATION" }; }

            else if (tableName == "DTN_C_PAYMENT" || tableName == "DTN_C_PAYMENTALLOCATE" ||
                     tableName == "DTN_C_ALLOCATIONHDR" || tableName == "DTN_C_ALLOCATIONLINE" ||
                     tableName == "DTN_C_EXEMPTION" || tableName == "DTN_C_EXEMPTIONLINE" ||
                     tableName == "DTN_C_CASH" || tableName == "DTN_C_CASHLINE" )
            { primarykeys = new string[] { "ID", "STATION" }; }

            else if (tableName == "C_EXEMPTION")
            { primarykeys = new string[] { "C_EXEMPTION_ID" }; }
            else if (tableName == "C_EXEMPTIONLINE")
            { primarykeys = new string[] { "C_EXEMPTIONLINE_ID" }; }

            else if (tableName == "C_PAYMENT" || tableName == "C_PAYMENTALLOCATE" ||
                     tableName == "C_ALLOCATIONHDR" || tableName == "C_ALLOCATIONLINE" ||
                     tableName == "C_CASH" || tableName == "C_CASHLINE" ||
                     tableName == "C_CASHBOOK")
            { primarykeys = new string[] { tableName + "_ID" }; }
            
            return primarykeys;
        }
        
        public string[] getCOMPIEREDBTablePrimaryKey(string tableName)
        {
            string[] primarykeys = { "" };
            if (tableName == "DUP_DMLSEQUENCE")
            { primarykeys = new string[] { "SEQUENCENO" }; }
            else if (tableName == "	DUP_CATEGORIES")            
            { primarykeys = new string[] { "SEQUENCENO" }; }
            else if (tableName == "DUP_ITEM_UNITS")
            { primarykeys = new string[] { "SEQUENCENO" }; }
            else if (tableName == "DUP_ITEMS")
            { primarykeys = new string[] { "SEQUENCENO" }; }
            else if (tableName == "	DUP_PRICE_CONDITIONS")
            { primarykeys = new string[] { "SEQUENCENO" }; }
            else if (tableName == "DUP_PRICE_LEVELS")
            { primarykeys = new string[] { "SEQUENCENO" }; }
            else if (tableName == "DUP_NODES")
            { primarykeys = new string[] { "SEQUENCENO" }; }
            else if (tableName == "DUP_STORES")
            { primarykeys = new string[] { "SEQUENCENO" }; }
            else if (tableName == "C_LOCATION")
            { primarykeys = new string[] { "C_LOCATION_ID" }; }
            else if (tableName == "C_BPARTNER")
            { primarykeys = new string[] { "C_BPARTNER_ID" }; }
            else if (tableName == "C_BPARTNER_LOCATION")
            { primarykeys = new string[] { "C_BPARTNER_LOCATION_ID" }; }
            else if (tableName == "C_ORDER")
            { primarykeys = new string[] { "C_ORDER_ID" }; }
            else if (tableName == "C_ORDERLINE")
            { primarykeys = new string[] { "C_ORDERLINE_ID" }; }
            else if (tableName == "M_WAREHOUSE")
            { primarykeys = new string[] { "M_WAREHOUSE_ID" }; }
            else if (tableName == "AD_SEQUENCE")
            { primarykeys = new string[] { "AD_SEQUENCE_ID" }; }
            else if (tableName == "C_BP_CUSTOMER_ACCT" || 
                     tableName == "C_BP_EMPLOYEE_ACCT" ||
                     tableName == "C_BP_VENDOR_ACCT")
            { primarykeys = new string[] { "C_BPARTNER_ID", "C_ACCTSCHEMA_ID" }; }
            else if (tableName == "C_EXEMPTION")
            { primarykeys = new string[] { "C_INVOICE_ID" }; }
            else if (tableName == "C_EXEMPTIONLINE")
            { primarykeys = new string[] { "C_INVOICELINE_ID" }; }
            else if (tableName == "C_INVOICE")
            { primarykeys = new string[] { "C_INVOICE_ID" }; }
            else if (tableName == "C_INVOICELINE")
            { primarykeys = new string[] { "C_INVOICELINE_ID" }; }
            else if (tableName == "C_CASHLINESOURCE")
            { primarykeys = new string[] { "C_CASHLINE_ID" }; }
            else if (tableName == "C_PAYMENT" || tableName == "C_PAYMENTALLOCATE" ||
                     tableName == "C_ALLOCATIONHDR" || tableName == "C_ALLOCATIONLINE" ||
                     tableName == "C_CASH" || tableName == "C_CASHLINE" ||
                     tableName == "C_CASHBOOK")
            { primarykeys = new string[] { tableName+ "_ID" }; }
          
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
            else
            {
                Tableprimarykeys = 
                    this.getCOMPIEREDBTablePrimaryKey(tableName);
                
                foreach (string primaryKey in Tableprimarykeys)
                {
                    if (primaryKey != "")
                        theWhereClose = theWhereClose + "AND " + primaryKey + " = '0' ";
                }
                if (theWhereClose != "")
                {
                    theWhereClose = theWhereClose.Remove(0, 3); //Remove the leding "AND"
                    string getStructureForTable = "SELECT *" +
                                                 " FROM " + tableName + " WHERE " + theWhereClose;
                    result = (DataTable)this.executeSqlOnCompiere(getStructureForTable);
                }
            }
            
            result.Clear();
            return result;
        }

        private void recordNumberOfNewRecordChange(string tableName, string DmlOperation, bool isPOS)
        {
            tableName = tableName.ToUpperInvariant();
            DmlOperation = DmlOperation.ToUpperInvariant();

            if (dbCommitFailure.dbCommitWarnning || dbCommitFailure.dbCommitError)
            {
                if (isPOS)
                {
                    if (dbCommitFailure.dbCommitError)
                    {
                        if (tableName == "C_BPARTNER" || tableName == "C_BPARTNER_LOCATION"
                            || tableName == "C_LOCATION")
                            generalResultInformation.synchResultCustomerErros++;
                        else if (tableName == "C_ORDER")
                            generalResultInformation.synchResultOrderErros++;
                        else if (tableName == "C_ORDERLINE")
                            generalResultInformation.synchResultOrderLineErros++;
                        else if (tableName == "C_EXEMPTION")
                            generalResultInformation.synchResultExemptionErrors++;
                        else if (tableName == "C_EXEMPTIONLINE")
                            generalResultInformation.synchResultExemptionLineErrors++;
                        else if (tableName == "C_PAYMENT")
                            generalResultInformation.synchResultPaymentErrors++;
                        else if (tableName == "C_PAYMENTALLOCATE")
                            generalResultInformation.synchResultPaymentLineErrors++;
                        else if (tableName == "C_ALLOCATIONHDR")
                            generalResultInformation.synchResultAllocationErrors++;
                        else if (tableName == "C_ALLOCATIONLINE")
                            generalResultInformation.synchResultAllocationLineErrors++;
                        else if (tableName == "C_CASH")
                            generalResultInformation.synchResultCashErrors++;
                        else if (tableName == "C_CASHLINE")
                            generalResultInformation.synchResultCashLineErrors++;	
                    }
                    if (dbCommitFailure.dbCommitWarnning)
                    {
                        if (tableName == "C_BPARTNER" || tableName == "C_BPARTNER_LOCATION"
                            || tableName == "C_LOCATION")
                            generalResultInformation.synchResultCustomerWarnnings++;
                        else if (tableName == "C_ORDER")
                            generalResultInformation.synchResultOrderWarnnings++;
                        else if (tableName == "C_ORDERLINE")
                            generalResultInformation.synchResultOrderLineWarnnings++;
                        else if (tableName == "C_EXEMPTION")
                            generalResultInformation.synchResultExemptionWarnnings++;
                        else if (tableName == "C_EXEMPTIONLINE")
                            generalResultInformation.synchResultExemptionLineWarnnings++;
                        else if (tableName == "C_PAYMENT")
                            generalResultInformation.synchResultPaymentWarnnings++;
                        else if (tableName == "C_PAYMENTALLOCATE")
                            generalResultInformation.synchResultPaymentLineWarnnings++;
                        else if (tableName == "C_ALLOCATIONHDR")
                            generalResultInformation.synchResultAllocationWarnnings++;
                        else if (tableName == "C_ALLOCATIONLINE")
                            generalResultInformation.synchResultAllocationLineWarnnings++;
                        else if (tableName == "C_CASH")
                            generalResultInformation.synchResultCashWarnnings++;
                        else if (tableName == "C_CASHLINE")
                            generalResultInformation.synchResultCashLineWarnnings++;	
                    }
                }
                else
                {
                    if (dbCommitFailure.dbCommitError)
                    {
                        if (tableName == "PRICE_LEVELS")
                            generalResultInformation.synchResultPriceErros++;                                                
                        else if (tableName == "ITEMS")
                            generalResultInformation.synchResultProductErros++;
                        else if (tableName == "PRICE_CONDITIONS")
                            generalResultInformation.synchResultPriceVersionErros++;                        
                        else if (tableName == "CATEGORIES")
                            generalResultInformation.synchResultCatgoryErros++;
                        else if (tableName == "ITEM_UNITS")
                            generalResultInformation.synchResultUOMErros++;                        
                        else if (tableName == "STORES")
                            generalResultInformation.synchResultStoreErros++;
                        else if (tableName == "NODES")
                            generalResultInformation.synchResultOrganisationErros++;                        
                    }
                    if (dbCommitFailure.dbCommitWarnning)
                    {
                        if (tableName == "PRICE_LEVELS")
                            generalResultInformation.synchResultPriceWarnnings++;
                        else if (tableName == "ITEMS")
                            generalResultInformation.synchResultProductWarnnings++;
                        else if (tableName == "PRICE_CONDITIONS")
                            generalResultInformation.synchResultPriceVersionWarnnings++;                        
                        else if (tableName == "ITEM_UNITS")
                            generalResultInformation.synchResultUOMWarnnings++;                        
                        else if (tableName == "CATEGORIES")
                            generalResultInformation.synchResultCatgoryWarnnings++;                                                
                        else if (tableName == "STORES")
                            generalResultInformation.synchResultStoreWarnnings++;
                        else if (tableName == "NODES")
                            generalResultInformation.synchResultOrganisationWarnnings++;
                    }             
                }
                return;
            }

            if (isPOS)
            {
                if (tableName == "C_BPARTNER" || tableName == "C_BPARTNER_LOCATION" || tableName == "C_LOCATION")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultCustomerInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultCustomerUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultCustomerDelete++;

                    if(dbSettingInformationHandler.posLogChangeScript)
                        generalResultInformation.synchResultCustomerScripts++;
                }
                else if (tableName == "C_ORDER")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultOrderInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultOrderUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultOrderDelete++;

                    if (dbSettingInformationHandler.posLogChangeScript)
                        generalResultInformation.synchResultOrderScripts++;
                }
                else if (tableName == "C_ORDERLINE")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultOrderLineInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultOrderLineUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultOrderLineDelete++;

                    if (dbSettingInformationHandler.posLogChangeScript)
                        generalResultInformation.synchResultOrderLineScripts++;
                }

                else if (tableName == "C_EXEMPTION")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultExemptionInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultExemptionUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultExemptionDelete++;

                    if (dbSettingInformationHandler.posLogChangeScript)
                        generalResultInformation.synchResultExemptionScripts++;
                }
                else if (tableName == "C_EXEMPTIONLINE")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultExemptionLineInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultExemptionLineUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultExemptionLineDelete++;

                    if (dbSettingInformationHandler.posLogChangeScript)
                        generalResultInformation.synchResultExemptionLineScripts++;
                }

                else if (tableName == "C_PAYMENT")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultPaymentInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultPaymentUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultPaymentDelete++;

                    if (dbSettingInformationHandler.posLogChangeScript)
                        generalResultInformation.synchResultPaymentScripts++;
                }
                else if (tableName == "C_PAYMENTALLOCATE")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultPaymentLineInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultPaymentLineUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultPaymentLineDelete++;

                    if (dbSettingInformationHandler.posLogChangeScript)
                        generalResultInformation.synchResultPaymentLineScripts++;
                }
                else if (tableName == "C_ALLOCATIONHDR")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultAllocationInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultAllocationUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultAllocationDelete++;

                    if (dbSettingInformationHandler.posLogChangeScript)
                        generalResultInformation.synchResultAllocationScripts++;
                }
                else if (tableName == "C_ALLOCATIONLINE")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultAllocationLineInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultAllocationLineUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultAllocationLineDelete++;

                    if (dbSettingInformationHandler.posLogChangeScript)
                        generalResultInformation.synchResultAllocationLineScripts++;
                }
                else if (tableName == "C_CASH")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultCashInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultCashUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultCashDelete++;

                    if (dbSettingInformationHandler.posLogChangeScript)
                        generalResultInformation.synchResultCashScripts++;
                }
                else if (tableName == "C_CASHLINE")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultCashLineInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultCashLineUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultCashLineDelete++;

                    if (dbSettingInformationHandler.posLogChangeScript)
                        generalResultInformation.synchResultCashLineScripts++;
                }

            }
            else
            {
                if (tableName == "PRICE_LEVELS")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultPriceInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultPriceUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultPriceDelete++;

                    if (dbSettingInformationHandler.posLogChangeScript)
                        generalResultInformation.synchResultPriceScripts++;
                }
                else if (tableName == "ITEMS")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultProductInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultProductUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultProductDelete++;

                    if (dbSettingInformationHandler.posLogChangeScript)
                        generalResultInformation.synchResultProductScripts++;
                }
                else if (tableName == "CATEGORIES")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultCatgoryInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultCatgoryUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultCatgoryDelete++;

                    if (dbSettingInformationHandler.posLogChangeScript)
                        generalResultInformation.synchResultCatgoryScripts++;
                }                
                else if (tableName == "ITEM_UNITS")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultUOMInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultUOMUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultUOMDelete++;

                    if (dbSettingInformationHandler.posLogChangeScript)
                        generalResultInformation.synchResultUOMScripts++;
                }                
                else if (tableName == "PRICE_CONDITIONS")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultPriceVersionInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultPriceVersionUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultPriceVersionDelete++;

                    if (dbSettingInformationHandler.posLogChangeScript)
                        generalResultInformation.synchResultPriceVersionScripts++;
                }                
                else if (tableName == "STORES")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultStoreInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultStoreUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultStoreDelete++;

                    if (dbSettingInformationHandler.posLogChangeScript)
                        generalResultInformation.synchResultStoreScripts++;
                }
                else if (tableName == "NODES")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultOrganisationInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultOrganisationUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultOrganisationDelete++;

                    if (dbSettingInformationHandler.posLogChangeScript)
                        generalResultInformation.synchResultOrganisationScripts++;
                }
            }
        }


        private void logSyncError(string synchId, string synchTable, string AdditionalMesseage,bool isPos)
        {
            string commitErrorOn = " Compiere ";
            if (!isPos)
                commitErrorOn = " POS ";

            this.writeTextLinetoFile("MISSING ITEM FOR DATA SYNCHRONISATION (SYNCH ID " +
                                        synchId + 
                                        "- SYNCH TABLE " + synchTable + ") When passing To "+ commitErrorOn+
                                        " DB /** " + AdditionalMesseage,
                                        logType.error, isPos);
            //Update recordChanged counter
                //If previous state of dbCommitError is true proceed.
            if (dbCommitFailure.dbCommitError)
            {
                this.recordNumberOfNewRecordChange(synchTable.Replace("DUP_", ""), "", isPos);
            }//else make state of dbCommitError is true and revert if to false after update.
            else
            {
                dbCommitFailure.dbCommitError = true;
                this.recordNumberOfNewRecordChange(synchTable.Replace("DUP_", ""), "", isPos);
                dbCommitFailure.dbCommitError = false;
            }

        }
        
        //The synchroniser functions
        public void synchroniseDataFromCompiereToPOS(BackgroundWorker _backGrounWorker )
        {            
            this.sourceDBIsPos = false;
            bool isPos = false;
            DataTable nextSynchroniseRecordInfoCP = new DataTable();
            DataTable nextSynchReocrdCP = new DataTable();
            string getNextSynchroniseRecordCP = "";
            string tableNameToSynchroniseCP = "";
            string synchIdCP = "";

            startDataSynchronisation:
            _backGrounWorker.ReportProgress(1);
            nextSynchroniseRecordInfoCP =
                this.getDUP_DMLSEQUENCEinfo(null, "", "", "", changeType.UNKOWN, 
                changeStatus.UNKOWN, true, false, "AND");

            if (!this.checkIfTableContainesData(nextSynchroniseRecordInfoCP) || 
                _backGrounWorker.CancellationPending)
                return;

            tableNameToSynchroniseCP =
                nextSynchroniseRecordInfoCP.Rows[0]["TABLENAME"].ToString();

            string posTableNameToSynchronise = tableNameToSynchroniseCP.Replace("DUP_", "");

            synchIdCP =
                nextSynchroniseRecordInfoCP.Rows[0]["SEQUENCENO"].ToString();

            getNextSynchroniseRecordCP = "SELECT * FROM " + tableNameToSynchroniseCP +
                                           " WHERE SEQUENCENO = " + synchIdCP;
            nextSynchReocrdCP =
                (DataTable)this.executeSqlOnCompiere(getNextSynchroniseRecordCP);

            if (!this.checkIfTableContainesData(nextSynchReocrdCP))
                goto startDataSynchronisation;

            if (tableNameToSynchroniseCP == "DUP_PRICE_LEVELS")
            {
                DataTable itemInfo =
                    this.getITEMInfo(null, "", nextSynchReocrdCP.Rows[0]["ITEM_ID"].ToString(),
                                        triaStateBool.Ignor, false, "AND");
                if(!this.checkIfTableContainesData(itemInfo))
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfoCP.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfoCP, "DUP_DMLSEQUENCE", "UPDATE", false);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchIdCP, tableNameToSynchroniseCP, "", isPos);
                    itemInfo.Dispose();
                    goto startDataSynchronisation;                                        
                }
                //itemInfo.Dispose();

                nextSynchReocrdCP.Rows[0]["ITEM_ID"] = itemInfo.Rows[0]["id"].ToString();

                DataTable priceConditionInfo =
                    this.getPRICE_CONDITIONInfo(null, "", nextSynchReocrdCP.Rows[0]["CONDITION"].ToString(),
                                                triaStateBool.Ignor, false, "AND");
                if (!this.checkIfTableContainesData(priceConditionInfo))
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfoCP.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfoCP, "DUP_DMLSEQUENCE", "UPDATE", false);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchIdCP, tableNameToSynchroniseCP, "", isPos);
                    priceConditionInfo.Dispose();
                    goto startDataSynchronisation;
                }
                //priceConditionInfo.Dispose();

                nextSynchReocrdCP.Rows[0]["CONDITION"] = 
                    priceConditionInfo.Rows[0]["id"].ToString();

                nextSynchReocrdCP.Rows[0]["PRICE_COND_ID"] =
                    priceConditionInfo.Rows[0]["id"].ToString();

                if (nextSynchReocrdCP.Rows[0]["CHANGETYPE"].ToString() == changeType.UP.ToString() ||
                    nextSynchReocrdCP.Rows[0]["CHANGETYPE"].ToString() == changeType.DL.ToString())
                {
                    DataTable priceLevelInfo =
                    this.getPRICE_LEVELInfo(null, "", nextSynchReocrdCP.Rows[0]["ITEM_ID"].ToString(),
                                            nextSynchReocrdCP.Rows[0]["CONDITION"].ToString(),
                                            triaStateBool.Ignor, false, "AND");
                    
                    if (!this.checkIfTableContainesData(priceLevelInfo))
                    {
                        if (nextSynchReocrdCP.Rows[0]["CHANGETYPE"].ToString() == changeType.UP.ToString())
                        {
                            nextSynchReocrdCP.Rows[0]["CHANGETYPE"] = changeType.IN.ToString();
                        }
                        else
                        {
                            //PASS ERROR FOR STATUS
                            nextSynchroniseRecordInfoCP.Rows[0]["STATUS"] = errorRecord;
                            this.changeDataBaseTableData(nextSynchroniseRecordInfoCP,
                                        "DUP_DMLSEQUENCE", "UPDATE", false);
                            //LOG ERROR TO DAILY ERROR LOG
                            this.logSyncError(synchIdCP, tableNameToSynchroniseCP, "", isPos);
                            priceLevelInfo.Dispose();
                            goto startDataSynchronisation;
                        }
                    }
                    //priceLevelInfo.Dispose();
                }
                goto commitTheSynchronisation;
            }

            if (tableNameToSynchroniseCP == "DUP_ITEMS")
            {
                DataTable dtCatagoryInfo =
                    this.getCATAGORYInfo(null, "",
                                            nextSynchReocrdCP.Rows[0]["category_id"].ToString(),
                                            triaStateBool.Ignor, false, "AND");

                if (!this.checkIfTableContainesData(dtCatagoryInfo))
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfoCP.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfoCP,
                                "DUP_DMLSEQUENCE", "UPDATE", false);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchIdCP, tableNameToSynchroniseCP, "", isPos);
                    dtCatagoryInfo.Dispose();
                    goto startDataSynchronisation;
                }

                DataTable dtUnitInfo =
                    this.getITEM_UNITInfo(null, "",
                                          nextSynchReocrdCP.Rows[0]["unit_id"].ToString(),
                                           triaStateBool.Ignor, false, "AND");

                if (!this.checkIfTableContainesData(dtUnitInfo))
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfoCP.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfoCP,
                                "DUP_DMLSEQUENCE", "UPDATE", false);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchIdCP, tableNameToSynchroniseCP, "", isPos);
                    dtUnitInfo.Dispose();
                    goto startDataSynchronisation;
                }

                nextSynchReocrdCP.Rows[0]["category_id"] = dtCatagoryInfo.Rows[0]["id"].ToString();
                nextSynchReocrdCP.Rows[0]["unit_id"] = dtUnitInfo.Rows[0]["id"].ToString();
            }
            
            if (nextSynchReocrdCP.Rows[0]["CHANGETYPE"].ToString() == changeType.UP.ToString() ||
                nextSynchReocrdCP.Rows[0]["CHANGETYPE"].ToString() == changeType.DL.ToString())
            {
                string whereClause = "";
                string[] POSPrimayKey =
                    this.getPOSDBTableConnectorKey(posTableNameToSynchronise);
                foreach (string key in POSPrimayKey)
                {
                    if (key != "")
                    {
                        whereClause = whereClause + "AND `" + key + "` = '" + 
                                            nextSynchReocrdCP.Rows[0][key].ToString() + "'";
                    }
                }
                if (whereClause != "")
                    whereClause = whereClause.Remove(0, 3);

                string dmlCheckExistingRecord = "SELECT * FROM `" + posTableNameToSynchronise +
                                                "` WHERE " + whereClause;
                DataTable existingRecordInfo =
                    (DataTable)this.executeSqlOnPOS(dmlCheckExistingRecord);

                if (!this.checkIfTableContainesData(existingRecordInfo))
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfoCP.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfoCP, "DUP_DMLSEQUENCE", "UPDATE", false);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchIdCP, tableNameToSynchroniseCP, "", isPos);
                    existingRecordInfo.Dispose();
                    goto startDataSynchronisation;
                }
                //existingRecordInfo.Dispose();
            }


            commitTheSynchronisation:
            string dmlChange = "";
            if (nextSynchReocrdCP.Rows[0]["CHANGETYPE"].ToString().ToUpperInvariant() == "IN")
                dmlChange = "INSERT";
            else if (nextSynchReocrdCP.Rows[0]["CHANGETYPE"].ToString().ToUpperInvariant() == "UP")
                dmlChange = "UPDATE";
            else if (nextSynchReocrdCP.Rows[0]["CHANGETYPE"].ToString().ToUpperInvariant() == "DL")
                dmlChange = "DELETE";

            this.changeDataBaseTableData(nextSynchReocrdCP, posTableNameToSynchronise, dmlChange, true);

            this.recordNumberOfNewRecordChange(posTableNameToSynchronise, dmlChange, isPos);

            if(!this.posExecuteOnError)
                nextSynchroniseRecordInfoCP.Rows[0]["STATUS"] = changedRecord;
            else
                nextSynchroniseRecordInfoCP.Rows[0]["STATUS"] = errorRecord;

            this.changeDataBaseTableData(nextSynchroniseRecordInfoCP, "DUP_DMLSEQUENCE", "UPDATE", false);            

            goto startDataSynchronisation;

        }

        public void synchroniseDataFromPOSToCompiere(BackgroundWorker _backGrounWorker)
        {            
            
            bool isPos = true;
            DataTable nextSynchroniseRecordInfo = new DataTable();
            DataTable nextSynchReocrd = new DataTable();
            string getNextSynchroniseRecord = "";
            string tableNameToSynchronise = "";
            string synchId = "";

            string recordId = "";
            string recordStation = "";
            string trxType = "";

        startDataSynchronisation:
            this.sourceDBIsPos = true;
            isPos = true;
            _backGrounWorker.ReportProgress(1);
            nextSynchroniseRecordInfo =
                this.getUTL_CHANGE_ORDER(null, "", "", "", changeType.UNKOWN,"", true, false, "AND");

            if (!this.checkIfTableContainesData(nextSynchroniseRecordInfo) || 
                _backGrounWorker.CancellationPending)
                return;

            tableNameToSynchronise =
                nextSynchroniseRecordInfo.Rows[0]["TABLE_NAME"].ToString();

            string compiereTableNameToSynchronise = tableNameToSynchronise.Replace("DUP_", "");
            string alternateCompTableNameToSynchronise = "";

            synchId =
                nextSynchroniseRecordInfo.Rows[0]["CHANGE_SEQUENCE_ID"].ToString();

            
            if (tableNameToSynchronise == "C_EXEMPTION" || tableNameToSynchronise == "C_EXEMPTIONLINE" ||
                tableNameToSynchronise == "C_PAYMENT" || tableNameToSynchronise == "C_PAYMENTALLOCATE" ||
                tableNameToSynchronise == "C_ALLOCATIONHDR" || tableNameToSynchronise == "C_ALLOCATIONLINE" ||
                tableNameToSynchronise == "C_CASH" || tableNameToSynchronise == "C_CASHLINE")
            {

                getNextSynchroniseRecord = "SELECT * FROM " + tableNameToSynchronise +
                                " WHERE " + tableNameToSynchronise + "_ID = " +
                                nextSynchroniseRecordInfo.Rows[0]["ID"].ToString() +
                                " AND STATION_ID = " +
                                nextSynchroniseRecordInfo.Rows[0]["STATION"].ToString();
            }
            else
            {
                getNextSynchroniseRecord = "SELECT * FROM " + tableNameToSynchronise +
                                       " WHERE CHANGE_SEQUENCE_ID = " + synchId;              
            }

            nextSynchReocrd =
                (DataTable)this.executeSqlOnPOS(getNextSynchroniseRecord);

            if (!this.checkIfTableContainesData(nextSynchReocrd))
            {
                //PASS ERROR FOR STATUS
                nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                //LOG ERROR TO DAILY ERROR LOG
                this.logSyncError(synchId, tableNameToSynchronise, "PARENT SYNCH RECORD MISSING", isPos);                
                goto startDataSynchronisation;
            }

            if (tableNameToSynchronise == "C_EXEMPTION")
                alternateCompTableNameToSynchronise = "C_INVOICE";
            else if (tableNameToSynchronise == "C_EXEMPTIONLINE")
                alternateCompTableNameToSynchronise = "C_INVOICELINE";
            else if (tableNameToSynchronise == "C_CASHLINESOURCE")
                alternateCompTableNameToSynchronise = "C_CASHLINE";
            else
                alternateCompTableNameToSynchronise = "";

            if (tableNameToSynchronise == "C_EXEMPTION" || tableNameToSynchronise == "C_EXEMPTIONLINE" ||
                tableNameToSynchronise == "C_PAYMENT" || tableNameToSynchronise == "C_PAYMENTALLOCATE" ||
                tableNameToSynchronise == "C_ALLOCATIONHDR" || tableNameToSynchronise == "C_ALLOCATIONLINE" ||
                tableNameToSynchronise == "C_CASH" || tableNameToSynchronise == "C_CASHLINE" ||
                tableNameToSynchronise == "C_CASHLINESOURCE")
            {
                recordId = nextSynchReocrd.Rows[0][tableNameToSynchronise + "_ID"].ToString();
                recordStation = nextSynchReocrd.Rows[0]["STATION_ID"].ToString();
            }
            else
            {
                recordId = nextSynchReocrd.Rows[0]["ID"].ToString();
                recordStation = nextSynchReocrd.Rows[0]["STATION"].ToString();
            }
            

            if (tableNameToSynchronise == "DUP_C_BPARTNER_LOCATION")
            {
                DataTable BPInformation =
                    this.getDTN_C_BPARTNER(null, "", "", "", "",
                                        recordId, recordStation, false, "AND");

                if (!this.checkIfTableContainesData(BPInformation))
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_BPARTNER INFO MISSING", isPos);
                    BPInformation.Dispose();
                    goto startDataSynchronisation;
                }

                nextSynchReocrd.Rows[0]["C_BPARTNER_ID"] =
                     BPInformation.Rows[0]["C_BPARTNER_ID"];

                nextSynchReocrd.Rows[0]["C_LOCATION_ID"] =
                    BPInformation.Rows[0]["C_LOCATION_ID"];

                if (nextSynchReocrd.Rows[0]["C_BPARTNER_ID"].ToString() == "" ||
                    nextSynchReocrd.Rows[0]["C_BPARTNER_ID"].ToString() == "0" ||
                    nextSynchReocrd.Rows[0]["C_LOCATION_ID"].ToString() == "" ||
                    nextSynchReocrd.Rows[0]["C_LOCATION_ID"].ToString() == "0")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_BPARTNER INFO MISSING", isPos);
                    BPInformation.Dispose();
                    goto startDataSynchronisation;
                }
            }
            else if (tableNameToSynchronise == "DUP_C_ORDER")
            {
                //C_BPARTNER_ID
                string posCustomerId = nextSynchReocrd.Rows[0]["C_BPARTNER_ID"].ToString();
                
                trxType = nextSynchReocrd.Rows[0]["TYPE"].ToString();

                if (posCustomerId == "" || posCustomerId == "0" || posCustomerId == " ")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_BPARTNER INFO MISSING", isPos);                    
                    goto startDataSynchronisation;
                }

                DataTable BPInformation =
                    this.getDTN_C_BPARTNER(null, "", "", "", "",
                                           posCustomerId, recordStation, false, "AND");
                
                if (!this.checkIfTableContainesData(BPInformation))
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_BPARTNER INFO MISSING", isPos);
                    BPInformation.Dispose();
                    goto startDataSynchronisation;
                }
                if (BPInformation.Rows[0]["C_BPARTNER_ID"].ToString() == "" ||
                    BPInformation.Rows[0]["C_BPARTNER_ID"].ToString() == "0" ||
                    BPInformation.Rows[0]["C_BPARTNER_LOCATION_ID"].ToString() == "" ||
                    BPInformation.Rows[0]["C_BPARTNER_LOCATION_ID"].ToString() == "0")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_BPARTNER INFO MISSING", isPos);
                    BPInformation.Dispose();
                    goto startDataSynchronisation;
                }

                DataTable defaultWareHouseInformation =
                    this.getM_WAREHOUSEInfo(null, "", nextSynchReocrd.Rows[0]["AD_ORG_ID"].ToString(),
                                "", triaStateBool.yes, false, "AND");
                
                if (!this.checkIfTableContainesData(defaultWareHouseInformation))
                    defaultWareHouseInformation =
                        this.getM_WAREHOUSEInfo(null, "", nextSynchReocrd.Rows[0]["AD_ORG_ID"].ToString(),
                                "", triaStateBool.Ignor, false, "AND");

                if (!this.checkIfTableContainesData(defaultWareHouseInformation))
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "M_WAREHOUSE_ID MISSING", isPos);
                    defaultWareHouseInformation.Dispose();
                    goto startDataSynchronisation;
                }

                if (defaultWareHouseInformation.Rows[0]["M_WAREHOUSE_ID"].ToString() == "" ||
                    defaultWareHouseInformation.Rows[0]["M_WAREHOUSE_ID"].ToString() == "0")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "M_WAREHOUSE_ID MISSING", isPos);
                    defaultWareHouseInformation.Dispose();
                    goto startDataSynchronisation;
                }

                nextSynchReocrd.Rows[0]["C_BPARTNER_ID"] =
                    BPInformation.Rows[0]["C_BPARTNER_ID"];

                nextSynchReocrd.Rows[0]["C_BPARTNER_LOCATION_ID"] =
                    BPInformation.Rows[0]["C_BPARTNER_LOCATION_ID"];

                nextSynchReocrd.Rows[0]["BILL_BPARTNER_ID"] =
                    BPInformation.Rows[0]["C_BPARTNER_ID"];

                nextSynchReocrd.Rows[0]["BILL_LOCATION_ID"] =
                    BPInformation.Rows[0]["C_BPARTNER_LOCATION_ID"];
                
                nextSynchReocrd.Rows[0]["M_WAREHOUSE_ID"] =
                        defaultWareHouseInformation.Rows[0]["M_WAREHOUSE_ID"];
            }
            else if (tableNameToSynchronise == "DUP_C_ORDERLINE")
            {
                string posCustomerId = nextSynchReocrd.Rows[0]["C_BPARTNER_ID"].ToString();
                if (posCustomerId == "" || posCustomerId == "0" || posCustomerId == " ")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_BPARTNER_ID MISSING", isPos);                    
                    goto startDataSynchronisation;
                }                

                string posOrderId = nextSynchReocrd.Rows[0]["C_ORDER_ID"].ToString();                
                trxType = nextSynchReocrd.Rows[0]["TYPE"].ToString();

                if (posOrderId == "" || posOrderId == "0" || posOrderId == " ")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_ORDER_ID MISSING", isPos);                    
                    goto startDataSynchronisation;
                }

                if (trxType == "" || trxType == "0" || trxType == " ")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_ORDER_ID MISSING", isPos);
                    goto startDataSynchronisation;
                }

                DataTable BPInformation =
                    this.getDTN_C_BPARTNER(null, "", "", "", "",
                                           posCustomerId, recordStation, false, "AND");

                if (!this.checkIfTableContainesData(BPInformation))
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_BPARTNER_ID MISSING", isPos);
                    BPInformation.Dispose();
                    goto startDataSynchronisation;
                }
                if (BPInformation.Rows[0]["C_BPARTNER_ID"].ToString() == "" ||
                    BPInformation.Rows[0]["C_BPARTNER_ID"].ToString() == "0" ||
                    BPInformation.Rows[0]["C_BPARTNER_LOCATION_ID"].ToString() == "" ||
                    BPInformation.Rows[0]["C_BPARTNER_LOCATION_ID"].ToString() == "0")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_BPARTNER_ID MISSING", isPos);
                    BPInformation.Dispose();
                    goto startDataSynchronisation;
                }

                DataTable orderInformation =
                    this.getDTN_C_ORDER(null, "", "",
                                        posOrderId, recordStation, false,trxType, "AND");

                if (!this.checkIfTableContainesData(orderInformation))
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_ORDER_ID MISSING", isPos);
                    orderInformation.Dispose();
                    goto startDataSynchronisation;
                }
                if (orderInformation.Rows[0]["C_ORDER_ID"].ToString() == "" ||
                    orderInformation.Rows[0]["C_ORDER_ID"].ToString() == "0")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_ORDER_ID MISSING", isPos);
                    orderInformation.Dispose();
                    goto startDataSynchronisation;
                }
                
                nextSynchReocrd.Rows[0]["C_ORDER_ID"] =
                        orderInformation.Rows[0]["C_ORDER_ID"];

                nextSynchReocrd.Rows[0]["C_BPARTNER_ID"] =
                    BPInformation.Rows[0]["C_BPARTNER_ID"];

                nextSynchReocrd.Rows[0]["C_BPARTNER_LOCATION_ID"] =
                    BPInformation.Rows[0]["C_BPARTNER_LOCATION_ID"];
            }
            else if (tableNameToSynchronise == "C_EXEMPTION")
            {
                string posCustomerId = nextSynchReocrd.Rows[0]["C_BPARTNER_ID"].ToString();
                if (posCustomerId == "" || posCustomerId == "0" || posCustomerId == " ")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_BPARTNER_ID MISSING", isPos);
                    goto startDataSynchronisation;
                }

                DataTable BPInformation =
                    this.getDTN_C_BPARTNER(null, "", "", "", "",
                                           posCustomerId, recordStation, false, "AND");

                if (!this.checkIfTableContainesData(BPInformation))
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_BPARTNER_ID MISSING", isPos);
                    BPInformation.Dispose();
                    goto startDataSynchronisation;
                }
                if (BPInformation.Rows[0]["C_BPARTNER_ID"].ToString() == "" ||
                    BPInformation.Rows[0]["C_BPARTNER_ID"].ToString() == "0" ||
                    BPInformation.Rows[0]["C_BPARTNER_LOCATION_ID"].ToString() == "" ||
                    BPInformation.Rows[0]["C_BPARTNER_LOCATION_ID"].ToString() == "0")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_BPARTNER_ID MISSING", isPos);
                    BPInformation.Dispose();
                    goto startDataSynchronisation;
                }

                DataTable dtNewInvoice = this.getDBTableStructure("C_INVOICE", false);

                DataRow drNewInvoice = dtNewInvoice.NewRow();

                drNewInvoice["AD_CLIENT_ID"] = "1000000";
                drNewInvoice["AD_ORG_ID"] = nextSynchReocrd.Rows[0]["AD_ORG_ID"];
                drNewInvoice["ISACTIVE"] = "Y";
                drNewInvoice["CREATEDBY"] = "1000000";
                drNewInvoice["UPDATEDBY"] = "1000000";
                drNewInvoice["ISSOTRX"] = "Y";
                drNewInvoice["DOCUMENTNO"] = 
                    nextSynchReocrd.Rows[0]["DOCUMENTNO"].ToString() + "_" + 
                    nextSynchReocrd.Rows[0]["EXEMPTIONTYPE"].ToString();
                drNewInvoice["DOCSTATUS"] = "IN";
                drNewInvoice["DOCACTION"] = "CO";
                drNewInvoice["PROCESSING"] = "Y";
                drNewInvoice["PROCESSED"] = "Y";
                drNewInvoice["POSTED"] = "N";
                drNewInvoice["C_DOCTYPE_ID"] = "1000002";
                drNewInvoice["C_DOCTYPETARGET_ID"] = "1000002";
                drNewInvoice["DESCRIPTION"] = nextSynchReocrd.Rows[0]["DESCRIPTION"].ToString();
                drNewInvoice["ISAPPROVED"] = "Y";
                drNewInvoice["ISTRANSFERRED"] = "N";
                drNewInvoice["ISPRINTED"] = "N";
                drNewInvoice["DATEINVOICED"] = nextSynchReocrd.Rows[0]["DATEINVOICED"].ToString();
                drNewInvoice["DATEACCT"] = nextSynchReocrd.Rows[0]["DATEINVOICED"].ToString();
                drNewInvoice["C_BPARTNER_ID"] = BPInformation.Rows[0]["C_BPARTNER_ID"];
                drNewInvoice["C_BPARTNER_LOCATION_ID"] = BPInformation.Rows[0]["C_BPARTNER_LOCATION_ID"];
                drNewInvoice["ISDISCOUNTPRINTED"] = "Y";
                drNewInvoice["C_CURRENCY_ID"] = 204;
                drNewInvoice["PAYMENTRULE"] = "P";
                drNewInvoice["C_PAYMENTTERM_ID"] = "1000000";                
                drNewInvoice["CHARGEAMT"] = "0";
                drNewInvoice["TOTALLINES"] =
                    decimal.Parse(nextSynchReocrd.Rows[0]["EXEMPTEDAMT"].ToString()) * -1;                                  
                drNewInvoice["GRANDTOTAL"] =
                    decimal.Parse(nextSynchReocrd.Rows[0]["EXEMPTEDAMT"].ToString()) * -1;
                drNewInvoice["M_PRICELIST_ID"] =
                    nextSynchReocrd.Rows[0]["AD_ORG_ID"].ToString() == "1000000" ||
                    nextSynchReocrd.Rows[0]["AD_ORG_ID"].ToString() == "1000012" ?
                    "1000000" : "1000001";
                drNewInvoice["ISTAXINCLUDED"] = "N";
                drNewInvoice["ISPAID"] = "N";
                drNewInvoice["CREATEFROM"] = "N";
                drNewInvoice["GENERATETO"] = "N";
                drNewInvoice["SENDEMAIL"] = "N";
                drNewInvoice["COPYFROM"] = "N";
                drNewInvoice["ISSELFSERVICE"] = "N";
                drNewInvoice["C_CONVERSIONTYPE_ID"] = "114";
                drNewInvoice["ISPAYSCHEDULEVALID"] = "N";
                drNewInvoice["ISINDISPUTE"] = "N";

                dtNewInvoice.Rows.Add(drNewInvoice);

                nextSynchReocrd = dtNewInvoice.Copy();

                nextSynchReocrd.Columns.Add("CHANGE_TYPE");
                nextSynchReocrd.Rows[0]["CHANGE_TYPE"] = "IN";

                dtNewInvoice.Dispose();
            }
            else if (tableNameToSynchronise == "C_EXEMPTIONLINE")
            {
                string posExemptionId = nextSynchReocrd.Rows[0]["C_EXEMPTION_ID"].ToString();

                if (posExemptionId == "" || posExemptionId == "0" || posExemptionId == " ")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_EXEMPTION_ID MISSING", isPos);
                    goto startDataSynchronisation;
                }

                DataTable exemptionInformation =
                    this.getDTN_C_EXEMPTION(null, "", posExemptionId, recordStation, "", false, "AND");

                if (!this.checkIfTableContainesData(exemptionInformation))
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_INVOICE_ID MISSING", isPos);
                    exemptionInformation.Dispose();
                    goto startDataSynchronisation;
                }
                if (exemptionInformation.Rows[0]["C_INVOICE_ID"].ToString() == "" ||
                    exemptionInformation.Rows[0]["C_INVOICE_ID"].ToString() == "0")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_INVOICE_ID MISSING", isPos);
                    exemptionInformation.Dispose();
                    goto startDataSynchronisation;
                }

                DataTable exemptionInformation2 =
                    this.getC_EXEMPTIONInfo(null, "", posExemptionId, "", "", 
                                DateTime.Now, false, exemptionType.ignor, 
                                recordStation, false, false, "AND");

                if (!this.checkIfTableContainesData(exemptionInformation2))
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_EXEMPTION_ID MISSING", isPos);
                    exemptionInformation.Dispose();
                    goto startDataSynchronisation;
                }
                if (exemptionInformation2.Rows[0]["C_EXEMPTION_ID"].ToString() == "" ||
                    exemptionInformation2.Rows[0]["C_EXEMPTION_ID"].ToString() == "0")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_EXEMPTION_ID MISSING", isPos);
                    exemptionInformation.Dispose();
                    goto startDataSynchronisation;
                }

                DataTable dtNewInvoiceDtl = this.getDBTableStructure("C_INVOICELINE", false);

                DataRow drNewInvoiceDtl = dtNewInvoiceDtl.NewRow();

                drNewInvoiceDtl["AD_CLIENT_ID"] = "1000000";
                drNewInvoiceDtl["AD_ORG_ID"] = nextSynchReocrd.Rows[0]["AD_ORG_ID"];
                drNewInvoiceDtl["ISACTIVE"] = "Y";
                drNewInvoiceDtl["CREATEDBY"] = "1000000";
                drNewInvoiceDtl["UPDATEDBY"] = "1000000";
                drNewInvoiceDtl["C_INVOICE_ID"] =
                    exemptionInformation.Rows[0]["C_INVOICE_ID"];
                drNewInvoiceDtl["LINE"] = "10";
                drNewInvoiceDtl["QTYINVOICED"] = "-1";
                drNewInvoiceDtl["PRICELIST"] = "0";
                drNewInvoiceDtl["PRICEACTUAL"] =
                    nextSynchReocrd.Rows[0]["EXEMPTED_AMOUNT"];
                drNewInvoiceDtl["PRICELIMIT"] = "0";
                drNewInvoiceDtl["LINENETAMT"] =
                    decimal.Parse(nextSynchReocrd.Rows[0]["EXEMPTED_AMOUNT"].ToString()) * -1;
                drNewInvoiceDtl["C_CHARGE_ID"] =
                    exemptionInformation2.Rows[0]["EXEMPTIONTYPE"].ToString()
                                    == "WITHHOLDING" ? "351000076" : "351000097";
                drNewInvoiceDtl["C_UOM_ID"] = "100";
                drNewInvoiceDtl["C_TAX_ID"] = "1000001";
                drNewInvoiceDtl["TAXAMT"] = "0";
                drNewInvoiceDtl["M_ATTRIBUTESETINSTANCE_ID"] = "0";
                drNewInvoiceDtl["ISDESCRIPTION"] = "N";
                drNewInvoiceDtl["ISPRINTED"] = "Y";
                drNewInvoiceDtl["LINETOTALAMT"] =
                    decimal.Parse(nextSynchReocrd.Rows[0]["EXEMPTED_AMOUNT"].ToString()) * -1;
                drNewInvoiceDtl["PROCESSED"] = "Y";
                drNewInvoiceDtl["QTYENTERED"] = "-1";
                drNewInvoiceDtl["PRICEENTERED"] =
                    nextSynchReocrd.Rows[0]["EXEMPTED_AMOUNT"];
                drNewInvoiceDtl["RRAMT"] = "0";


                dtNewInvoiceDtl.Rows.Add(drNewInvoiceDtl);

                nextSynchReocrd = dtNewInvoiceDtl.Copy();

                nextSynchReocrd.Columns.Add("CHANGE_TYPE");
                nextSynchReocrd.Rows[0]["CHANGE_TYPE"] = "IN";

                dtNewInvoiceDtl.Dispose();

            }
            else if (tableNameToSynchronise == "C_PAYMENT")
            {
                string posCustomerId = nextSynchReocrd.Rows[0]["C_BPARTNER_ID"].ToString();
                if (posCustomerId == "" || posCustomerId == "0" || posCustomerId == " ")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_BPARTNER_ID MISSING", isPos);
                    goto startDataSynchronisation;
                }

                DataTable BPInformation =
                    this.getDTN_C_BPARTNER(null, "", "", "", "",
                                           posCustomerId, recordStation, false, "AND");

                if (!this.checkIfTableContainesData(BPInformation))
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_BPARTNER_ID MISSING", isPos);
                    BPInformation.Dispose();
                    goto startDataSynchronisation;
                }
                if (BPInformation.Rows[0]["C_BPARTNER_ID"].ToString() == "" ||
                    BPInformation.Rows[0]["C_BPARTNER_ID"].ToString() == "0" ||
                    BPInformation.Rows[0]["C_BPARTNER_LOCATION_ID"].ToString() == "" ||
                    BPInformation.Rows[0]["C_BPARTNER_LOCATION_ID"].ToString() == "0")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_BPARTNER_ID MISSING", isPos);
                    BPInformation.Dispose();
                    goto startDataSynchronisation;
                }

                DataTable dtNewPayment = this.getDBTableStructure("C_PAYMENT", false);

                DataRow drNewPayment = dtNewPayment.NewRow();

                drNewPayment["AD_CLIENT_ID"] = "1000000";
                drNewPayment["AD_ORG_ID"] = nextSynchReocrd.Rows[0]["AD_ORG_ID"];
                drNewPayment["ISACTIVE"] = "Y";
                drNewPayment["CREATEDBY"] = "1000000";
                drNewPayment["UPDATEDBY"] = "1000000";
                drNewPayment["DOCUMENTNO"] = "CRV-" + nextSynchReocrd.Rows[0]["DOCUMENTNO"];
                drNewPayment["DATETRX"] = nextSynchReocrd.Rows[0]["DATETRX"];
                drNewPayment["ISRECEIPT"] = "Y";
                drNewPayment["C_DOCTYPE_ID"] = "1000008";
                drNewPayment["TRXTYPE"] = "S";
                drNewPayment["C_BANKACCOUNT_ID"] = "351000015";
                drNewPayment["C_BPARTNER_ID"] =
                    BPInformation.Rows[0]["C_BPARTNER_ID"].ToString();
                drNewPayment["TENDERTYPE"] = "K";
                drNewPayment["CREDITCARDTYPE"] = "M";
                drNewPayment["CREDITCARDEXPMM"] = "1";
                drNewPayment["CREDITCARDEXPYY"] = "3";
                drNewPayment["C_CURRENCY_ID"] = "204";
                drNewPayment["PAYAMT"] = nextSynchReocrd.Rows[0]["PAYAMT"];
                drNewPayment["C_CHARGE_ID"] = nextSynchReocrd.Rows[0]["C_CHARGE_ID"];
                drNewPayment["DISCOUNTAMT"] = "0";
                drNewPayment["WRITEOFFAMT"] = "0";
                drNewPayment["TAXAMT"] = "0";
                drNewPayment["ISAPPROVED"] = "N";
                drNewPayment["R_AVSADDR"] = "X";
                drNewPayment["R_AVSZIP"] = "X";
                drNewPayment["PROCESSING"] = "Y";
                drNewPayment["OPROCESSING"] = "N";
                drNewPayment["DOCSTATUS"] = "IN";
                drNewPayment["DOCACTION"] = "CO";
                drNewPayment["ISRECONCILED"] = "N";
                drNewPayment["ISALLOCATED"] = "N";
                drNewPayment["ISONLINE"] = "N";
                drNewPayment["PROCESSED"] = "Y";
                drNewPayment["POSTED"] = "N";
                drNewPayment["ISOVERUNDERPAYMENT"] = "N";
                drNewPayment["OVERUNDERAMT"] = "0";
                drNewPayment["ISSELFSERVICE"] = "N";
                drNewPayment["CHARGEAMT"] = "0";
                drNewPayment["ISDELAYEDCAPTURE"] = "N";
                drNewPayment["R_CVV2MATCH"] = "N";
                drNewPayment["C_CONVERSIONTYPE_ID"] = "114";
                drNewPayment["DESCRIPTION"] = 
                    nextSynchReocrd.Rows[0]["DESCRIPTION"].ToString();
                drNewPayment["DATEACCT"] = 
                    nextSynchReocrd.Rows[0]["DATETRX"];
                drNewPayment["ISPREPAYMENT"] = 
                    nextSynchReocrd.Rows[0]["ISADVANCE"];

                dtNewPayment.Rows.Add(drNewPayment);

                nextSynchReocrd = dtNewPayment.Copy();

                nextSynchReocrd.Columns.Add("CHANGE_TYPE");
                nextSynchReocrd.Rows[0]["CHANGE_TYPE"] = "IN";

                dtNewPayment.Dispose();
                
            }
            else if (tableNameToSynchronise == "C_PAYMENTALLOCATE")
            {
                // Check if Payment is recorded
                string posPaymentId = nextSynchReocrd.Rows[0]["C_PAYMENT_ID"].ToString();

                if (posPaymentId == "" || posPaymentId == "0" || posPaymentId == " ")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_PAYMENT_ID MISSING", isPos);
                    goto startDataSynchronisation;
                }

                DataTable paymentInformation =
                    this.getDTN_C_PAYMENT(null, "", posPaymentId, recordStation, "", false, "AND");

                if (!this.checkIfTableContainesData(paymentInformation))
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_PAYMENT_ID MISSING", isPos);
                    paymentInformation.Dispose();
                    goto startDataSynchronisation;
                }
                if (paymentInformation.Rows[0]["C_PAYMENT_ID"].ToString() == "" ||
                    paymentInformation.Rows[0]["C_PAYMENT_ID"].ToString() == "0")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_PAYMENT_ID MISSING", isPos);
                    paymentInformation.Dispose();
                    goto startDataSynchronisation;
                }


                //Check if there is a valid Invoice for the allocation

                string posSalesInvoiceId = nextSynchReocrd.Rows[0]["C_INVOICE_ID"].ToString();

                if (posSalesInvoiceId == "" || posSalesInvoiceId == "0" || posSalesInvoiceId == " ")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_INVOICE_ID MISSING", isPos);
                    goto startDataSynchronisation;
                }

                DataTable salesInformation = new DataTable();

                if (nextSynchReocrd.Rows[0]["ISEXEMPTION"].ToString() == "N")
                {
                    salesInformation =
                        this.getDTN_C_ORDER(null, "", "", posSalesInvoiceId, recordStation, false, "SLE", "AND");

                    if (!this.checkIfTableContainesData(salesInformation))
                    {
                        //PASS ERROR FOR STATUS
                        nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                        this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                        //LOG ERROR TO DAILY ERROR LOG
                        this.logSyncError(synchId, tableNameToSynchronise, "C_ORDER_ID MISSING", isPos);
                        salesInformation.Dispose();
                        goto startDataSynchronisation;
                    }
                    if (salesInformation.Rows[0]["C_ORDER_ID"].ToString() == "" ||
                        salesInformation.Rows[0]["C_ORDER_ID"].ToString() == "0")
                    {
                        //PASS ERROR FOR STATUS
                        nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                        this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                        //LOG ERROR TO DAILY ERROR LOG
                        this.logSyncError(synchId, tableNameToSynchronise, "C_ORDER_ID MISSING", isPos);
                        salesInformation.Dispose();
                        goto startDataSynchronisation;
                    }
                }

                if (nextSynchReocrd.Rows[0]["ISEXEMPTION"].ToString() == "N")
                {
                    salesInformation =
                        this.getC_INVOICEInfo(null, "", "", "",
                                        salesInformation.Rows[0]["C_ORDER_ID"].ToString(),
                                        "", "", "", "CL", "CO", "", triaStateBool.yes,
                                        triaStateBool.yes, false, false, "AND");
                }
                else
                {
                    salesInformation =
                        this.getDTN_C_EXEMPTION(null, "",
                                nextSynchReocrd.Rows[0]["C_INVOICE_ID"].ToString(),
                                nextSynchReocrd.Rows[0]["STATION_ID"].ToString(),
                                "", false, "AND");

                    if (this.checkIfTableContainesData(salesInformation))
                    {
                        
                        salesInformation =
                            this.getC_INVOICEInfo(null, "", "",
                                    (salesInformation.Rows[0]["C_INVOICE_ID"].ToString() == "" ||
                                    salesInformation.Rows[0]["C_INVOICE_ID"].ToString() == "0") ? "0" :
                                    salesInformation.Rows[0]["C_INVOICE_ID"].ToString(),
                                    "", "", "", "", "", "", "",
                                    triaStateBool.yes, triaStateBool.yes,
                                    false, false, "AND");
                    }
                }

                if (!this.checkIfTableContainesData(salesInformation))
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_INVOICE_ID MISSING", isPos);
                    salesInformation.Dispose();
                    goto startDataSynchronisation;
                }
                if (salesInformation.Rows[0]["C_INVOICE_ID"].ToString() == "" ||
                    salesInformation.Rows[0]["C_INVOICE_ID"].ToString() == "0")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_INVOICE_ID MISSING", isPos);
                    salesInformation.Dispose();
                    goto startDataSynchronisation;
                }

                //Check If there are more than one Invoices in Payment

                DataTable dtPaymentAllocationInfo =
                    this.getC_PAYMENTALLOCATEInfo(null, "", "",
                                    posPaymentId, "", triaStateBool.Ignor, recordStation,
                                    false, false, "AND");

                if (!this.checkIfTableContainesData(dtPaymentAllocationInfo))
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "Payment Detail MISSING", isPos);
                    salesInformation.Dispose();
                    goto startDataSynchronisation;
                }

                if (dtPaymentAllocationInfo.Rows.Count == 1)
                {

                    compiereTableNameToSynchronise = "C_PAYMENT";

                    //Sorry to break your tradition Ammar. But this is the only time, I promise.
                    string getCurrentPaymentInfo = "SELECT * FROM C_PAYMENT " +
                                                   "WHERE C_PAYMENT_ID = " +
                                paymentInformation.Rows[0]["C_PAYMENT_ID"].ToString();

                    DataTable dtPaymentInfo =
                        (DataTable) this.executeSqlOnCompiere(getCurrentPaymentInfo);

                    if (!this.checkIfTableContainesData(dtPaymentInfo))
                    {
                        //PASS ERROR FOR STATUS
                        nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                        this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                        //LOG ERROR TO DAILY ERROR LOG
                        this.logSyncError(synchId, tableNameToSynchronise, "Payment Info MISSING", isPos);
                        salesInformation.Dispose();
                        goto startDataSynchronisation;
                    }

                    dtPaymentInfo.Rows[0]["C_INVOICE_ID"] =
                        salesInformation.Rows[0]["C_INVOICE_ID"].ToString();
                    //dtPaymentInfo.Rows[0]["AMOUNT"] =
                    //    nextSynchReocrd.Rows[0]["AMOUNT"];
                    dtPaymentInfo.Rows[0]["DISCOUNTAMT"] = "0";
                    dtPaymentInfo.Rows[0]["WRITEOFFAMT"] = "0";
                    dtPaymentInfo.Rows[0]["OVERUNDERAMT"] =
                        nextSynchReocrd.Rows[0]["OVERUNDERAMT"];
                    //dtPaymentInfo.Rows[0]["INVOICEAMT"] =
                    //    nextSynchReocrd.Rows[0]["INVOICEAMT"];
                    dtPaymentInfo.Rows[0]["ISOVERUNDERPAYMENT"] =
                        decimal.Parse(nextSynchReocrd.Rows[0]["OVERUNDERAMT"].ToString()).
                                    Equals(0) ? "N" : "Y";

                    nextSynchReocrd = dtPaymentInfo.Copy();

                    nextSynchReocrd.Columns.Add("CHANGE_TYPE");
                    nextSynchReocrd.Rows[0]["CHANGE_TYPE"] = "UP";


                    string getCurrentPaymentAllocateDTNInfo =
                        "SELECT * FROM DTN_C_PAYMENTALLOCATE WHERE ID = " + recordId +
                                                    " AND STATION = " + recordStation;

                    DataTable dtCurrentPaymentAllocateDTNInfo =
                        (DataTable) this.executeSqlOnPOS(getCurrentPaymentAllocateDTNInfo);

                    if (this.checkIfTableContainesData(dtCurrentPaymentAllocateDTNInfo))
                    {
                        dtCurrentPaymentAllocateDTNInfo.Rows[0]["C_PAYMENT_ID"] =
                            dtPaymentInfo.Rows[0]["C_PAYMENT_ID"].ToString();

                        this.changeDataBaseTableData(dtCurrentPaymentAllocateDTNInfo, "DTN_C_PAYMENTALLOCATE",
                                    "UPDATE", true);
                    }

                }
                else
                {

                    DataTable dtNewPaymentAllocate = 
                        this.getDBTableStructure("C_PAYMENTALLOCATE", false);

                    DataRow drNewPaymentAllocate = dtNewPaymentAllocate.NewRow();

                    drNewPaymentAllocate["AD_CLIENT_ID"] = "1000000";
                    drNewPaymentAllocate["AD_ORG_ID"] = nextSynchReocrd.Rows[0]["AD_ORG_ID"];
                    drNewPaymentAllocate["ISACTIVE"] = "Y";
                    drNewPaymentAllocate["CREATEDBY"] = "1000000";
                    drNewPaymentAllocate["UPDATEDBY"] = "1000000";
                    drNewPaymentAllocate["C_PAYMENT_ID"] =
                        paymentInformation.Rows[0]["C_PAYMENT_ID"].ToString();
                    drNewPaymentAllocate["C_INVOICE_ID"] =
                        salesInformation.Rows[0]["C_INVOICE_ID"].ToString();
                    drNewPaymentAllocate["AMOUNT"] = 
                        nextSynchReocrd.Rows[0]["AMOUNT"];
                    drNewPaymentAllocate["DISCOUNTAMT"] = "0";
                    drNewPaymentAllocate["WRITEOFFAMT"] = "0";
                    drNewPaymentAllocate["OVERUNDERAMT"] =
                        nextSynchReocrd.Rows[0]["OVERUNDERAMT"];
                    drNewPaymentAllocate["INVOICEAMT"] = 
                        nextSynchReocrd.Rows[0]["INVOICEAMT"];


                    dtNewPaymentAllocate.Rows.Add(drNewPaymentAllocate);

                    nextSynchReocrd = dtNewPaymentAllocate.Copy();

                    nextSynchReocrd.Columns.Add("CHANGE_TYPE");
                    nextSynchReocrd.Rows[0]["CHANGE_TYPE"] = "IN";

                    dtNewPaymentAllocate.Dispose();
                }
                
            }
            else if (tableNameToSynchronise == "C_ALLOCATIONHDR")
            {

                DataTable dtNewAllocationHdr = 
                    this.getDBTableStructure("C_ALLOCATIONHDR", false);

                DataRow drNewAllocationHdr = dtNewAllocationHdr.NewRow();
                                
                drNewAllocationHdr["AD_CLIENT_ID"] = "1000000";
                drNewAllocationHdr["AD_ORG_ID"] = nextSynchReocrd.Rows[0]["AD_ORG_ID"];
                drNewAllocationHdr["ISACTIVE"] = "Y";                
                drNewAllocationHdr["CREATEDBY"] = "1000000";                
                drNewAllocationHdr["UPDATEDBY"] = "1000000";
                drNewAllocationHdr["DOCUMENTNO"] = nextSynchReocrd.Rows[0]["DOCUMENTNO"];
                drNewAllocationHdr["DESCRIPTION"] = "";
                drNewAllocationHdr["DATETRX"] = nextSynchReocrd.Rows[0]["DATETRX"];
                drNewAllocationHdr["DATEACCT"] = nextSynchReocrd.Rows[0]["DATEACCT"];
                drNewAllocationHdr["C_CURRENCY_ID"] = "204";
                drNewAllocationHdr["APPROVALAMT"] = "0";
                drNewAllocationHdr["ISMANUAL"] = "Y";
                drNewAllocationHdr["DOCSTATUS"] = "IN";
                drNewAllocationHdr["DOCACTION"] = "CO";
                drNewAllocationHdr["ISAPPROVED"] = "N";
                drNewAllocationHdr["PROCESSING"] = "Y";
                drNewAllocationHdr["PROCESSED"] = "Y";
                drNewAllocationHdr["POSTED"] = "N";

                dtNewAllocationHdr.Rows.Add(drNewAllocationHdr);

                nextSynchReocrd = dtNewAllocationHdr.Copy();

                nextSynchReocrd.Columns.Add("CHANGE_TYPE");
                nextSynchReocrd.Rows[0]["CHANGE_TYPE"] = "IN";

                dtNewAllocationHdr.Dispose();                
            }
            else if (tableNameToSynchronise == "C_ALLOCATIONLINE")
            {
                //Check if there is a valid Allocation HDR for the allocation

                string posAllocationId = nextSynchReocrd.Rows[0]["C_ALLOCATIONHDR_ID"].ToString();

                if (posAllocationId == "" || posAllocationId == "0" || posAllocationId == " ")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_ALLOCATIONHDR_ID MISSING", isPos);
                    goto startDataSynchronisation;
                }

                DataTable allocationInformation =
                    this.getDTN_C_ALLOCATIONHDR(null, "", posAllocationId, recordStation, "", false, "AND");

                if (!this.checkIfTableContainesData(allocationInformation))
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_ALLOCATIONHDR_ID MISSING", isPos);
                    allocationInformation.Dispose();
                    goto startDataSynchronisation;
                }
                if (allocationInformation.Rows[0]["C_ALLOCATIONHDR_ID"].ToString() == "" ||
                    allocationInformation.Rows[0]["C_ALLOCATIONHDR_ID"].ToString() == "0")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_ALLOCATIONHDR_ID MISSING", isPos);
                    allocationInformation.Dispose();
                    goto startDataSynchronisation;
                }


                //Check if there is a valid Payment for the allocation

                string posPaymentId = nextSynchReocrd.Rows[0]["C_PAYMENT_ID"].ToString();

                if (posPaymentId == "" || posPaymentId == "0" || posPaymentId == " ")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_PAYMENT_ID MISSING", isPos);
                    goto startDataSynchronisation;
                }

                DataTable paymentInformation =
                    this.getDTN_C_PAYMENT(null, "", posPaymentId, recordStation, "", false, "AND");

                if (!this.checkIfTableContainesData(paymentInformation))
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_PAYMENT_ID MISSING", isPos);
                    paymentInformation.Dispose();
                    goto startDataSynchronisation;
                }
                if (paymentInformation.Rows[0]["C_PAYMENT_ID"].ToString() == "" ||
                    paymentInformation.Rows[0]["C_PAYMENT_ID"].ToString() == "0")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_PAYMENT_ID MISSING", isPos);
                    paymentInformation.Dispose();
                    goto startDataSynchronisation;
                }


                //Check if there is a valid Invoice for the allocation

                string posSalesInvoiceId = nextSynchReocrd.Rows[0]["C_INVOICE_ID"].ToString();

                if (posSalesInvoiceId == "" || posSalesInvoiceId == "0" || posSalesInvoiceId == " ")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_INVOICE_ID MISSING", isPos);
                    goto startDataSynchronisation;
                }

                DataTable salesInformation =
                    this.getDTN_C_ORDER(null, "", "", posSalesInvoiceId, recordStation, false, "SLE", "AND");

                if (!this.checkIfTableContainesData(salesInformation))
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_ORDER_ID MISSING", isPos);
                    salesInformation.Dispose();
                    goto startDataSynchronisation;
                }
                if (salesInformation.Rows[0]["C_ORDER_ID"].ToString() == "" ||
                    salesInformation.Rows[0]["C_ORDER_ID"].ToString() == "0")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_ORDER_ID MISSING", isPos);
                    salesInformation.Dispose();
                    goto startDataSynchronisation;
                }

                string ORDER_ID =
                    salesInformation.Rows[0]["C_ORDER_ID"].ToString();

                salesInformation =
                    this.getC_INVOICEInfo(null, "", "", "",
                                    ORDER_ID,
                                    "", "", "", "CL", "CO", "", triaStateBool.yes,
                                    triaStateBool.yes, false, false, "AND");

                if (!this.checkIfTableContainesData(salesInformation))
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_INVOICE_ID MISSING", isPos);
                    salesInformation.Dispose();
                    goto startDataSynchronisation;
                }
                if (salesInformation.Rows[0]["C_INVOICE_ID"].ToString() == "" ||
                    salesInformation.Rows[0]["C_INVOICE_ID"].ToString() == "0")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_INVOICE_ID MISSING", isPos);
                    salesInformation.Dispose();
                    goto startDataSynchronisation;
                }


                // Check if Bp Exist for Invooice

                string posCustomerId = nextSynchReocrd.Rows[0]["C_BPARTNER_ID"].ToString();
                if (posCustomerId == "" || posCustomerId == "0" || posCustomerId == " ")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_BPARTNER_ID MISSING", isPos);
                    goto startDataSynchronisation;
                }

                DataTable BPInformation =
                    this.getDTN_C_BPARTNER(null, "", "", "", "",
                                           posCustomerId, recordStation, false, "AND");

                if (!this.checkIfTableContainesData(BPInformation))
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_BPARTNER_ID MISSING", isPos);
                    BPInformation.Dispose();
                    goto startDataSynchronisation;
                }
                if (BPInformation.Rows[0]["C_BPARTNER_ID"].ToString() == "" ||
                    BPInformation.Rows[0]["C_BPARTNER_ID"].ToString() == "0" ||
                    BPInformation.Rows[0]["C_BPARTNER_LOCATION_ID"].ToString() == "" ||
                    BPInformation.Rows[0]["C_BPARTNER_LOCATION_ID"].ToString() == "0")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_BPARTNER_ID MISSING", isPos);
                    BPInformation.Dispose();
                    goto startDataSynchronisation;
                }


                DataTable dtNewAllocationLine = 
                    this.getDBTableStructure("C_ALLOCATIONLINE", false);

                DataRow drAllocationLine = dtNewAllocationLine.NewRow();

                drAllocationLine["AD_CLIENT_ID"] = "1000000";
                drAllocationLine["AD_ORG_ID"] = nextSynchReocrd.Rows[0]["AD_ORG_ID"];
                drAllocationLine["ISACTIVE"] = "Y";
                drAllocationLine["CREATEDBY"] = "1000000";
                drAllocationLine["UPDATEDBY"] = "1000000";
                drAllocationLine["DATETRX"] = nextSynchReocrd.Rows[0]["DATETRX"];
                drAllocationLine["ISMANUAL"] = "Y";
                drAllocationLine["C_INVOICE_ID"] = 
                    salesInformation.Rows[0]["C_INVOICE_ID"].ToString();
                drAllocationLine["C_BPARTNER_ID"] =
                    BPInformation.Rows[0]["C_BPARTNER_ID"].ToString();
                drAllocationLine["C_ORDER_ID"] = 
                    ORDER_ID;
                drAllocationLine["C_PAYMENT_ID"] =
                    paymentInformation.Rows[0]["C_PAYMENT_ID"].ToString();
                drAllocationLine["AMOUNT"] = 
                    nextSynchReocrd.Rows[0]["AMOUNT"];
                drAllocationLine["DISCOUNTAMT"] = "0";
                drAllocationLine["WRITEOFFAMT"] = "0";
                drAllocationLine["POSTED"] = "N";
                drAllocationLine["OVERUNDERAMT"] = 
                    nextSynchReocrd.Rows[0]["OVERUNDERAMT"];
                drAllocationLine["C_ALLOCATIONHDR_ID"] =
                    allocationInformation.Rows[0]["C_ALLOCATIONHDR_ID"].ToString();


                dtNewAllocationLine.Rows.Add(drAllocationLine);

                nextSynchReocrd = dtNewAllocationLine.Copy();

                nextSynchReocrd.Columns.Add("CHANGE_TYPE");
                nextSynchReocrd.Rows[0]["CHANGE_TYPE"] = "IN";

                dtNewAllocationLine.Dispose();
            }
            else if (tableNameToSynchronise == "C_CASH")
            {
                DataTable defaultCashBookInfo =
                    this.getC_CASHBOOKInfo(null, "", 
                        nextSynchReocrd.Rows[0]["AD_ORG_ID"].ToString(), "", "", 
                        triaStateBool.yes, true, false, "AND");

                if (!this.checkIfTableContainesData(defaultCashBookInfo))
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_CASHBOOK_ID MISSING", isPos);
                    defaultCashBookInfo.Dispose();
                    goto startDataSynchronisation;
                }
                if (defaultCashBookInfo.Rows[0]["C_CASHBOOK_ID"].ToString() == "" ||
                    defaultCashBookInfo.Rows[0]["C_CASHBOOK_ID"].ToString() == "0")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_CASHBOOK_ID MISSING", isPos);
                    defaultCashBookInfo.Dispose();
                    goto startDataSynchronisation;
                }

                DataTable dtNewCash =
                    this.getDBTableStructure("C_CASH", false);

                DataRow drCash = dtNewCash.NewRow();

                drCash["AD_CLIENT_ID"] = "1000000";
                drCash["AD_ORG_ID"] = nextSynchReocrd.Rows[0]["AD_ORG_ID"];
                drCash["ISACTIVE"] = "Y";
                drCash["CREATEDBY"] = "1000000";
                drCash["UPDATEDBY"] = "1000000";
                drCash["C_CASHBOOK_ID"] = defaultCashBookInfo.Rows[0]["C_CASHBOOK_ID"];
                drCash["NAME"] = nextSynchReocrd.Rows[0]["NAME"].ToString() + "_Cash Deposit Slip";
                drCash["DESCRIPTION"] = nextSynchReocrd.Rows[0]["DESCRIPTION"].ToString();
                drCash["STATEMENTDATE"] = nextSynchReocrd.Rows[0]["STATEMENTDATE"];
                drCash["DATEACCT"] = nextSynchReocrd.Rows[0]["DATEACCT"];
                drCash["BEGINNINGBALANCE"] = "0";
                drCash["ENDINGBALANCE"] = nextSynchReocrd.Rows[0]["ENDINGBALANCE"];
                drCash["STATEMENTDIFFERENCE"] = nextSynchReocrd.Rows[0]["STATEMENTDIFFERENCE"];
                drCash["PROCESSING"] = "Y";
                drCash["PROCESSED"] = "Y";
                drCash["POSTED"] = "N";
                drCash["ISAPPROVED"] = "N";
                drCash["DOCSTATUS"] = "IN";
                drCash["DOCACTION"] = "CO";

                dtNewCash.Rows.Add(drCash);

                nextSynchReocrd = dtNewCash.Copy();

                nextSynchReocrd.Columns.Add("CHANGE_TYPE");
                nextSynchReocrd.Rows[0]["CHANGE_TYPE"] = "IN";

                dtNewCash.Dispose();
            }
            else if (tableNameToSynchronise == "C_CASHLINE")
            {

                //Check if there is a valid Cash Journal for the Cashline

                string posCashId = nextSynchReocrd.Rows[0]["C_CASH_ID"].ToString();

                if (posCashId == "" || posCashId == "0" || posCashId == " ")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_CASH_ID MISSING", isPos);
                    goto startDataSynchronisation;
                }

                DataTable cashInformation =
                    this.getDTN_C_CASH(null, "", posCashId, recordStation, "", false, "AND");

                if (!this.checkIfTableContainesData(cashInformation))
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_CASH_ID MISSING", isPos);
                    cashInformation.Dispose();
                    goto startDataSynchronisation;
                }
                if (cashInformation.Rows[0]["C_CASH_ID"].ToString() == "" ||
                    cashInformation.Rows[0]["C_CASH_ID"].ToString() == "0")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_CASH_ID MISSING", isPos);
                    cashInformation.Dispose();
                    goto startDataSynchronisation;
                }

                DataTable dtNewCashLine =
                    this.getDBTableStructure("C_CASHLINE", false);

                DataRow drCashLine = dtNewCashLine.NewRow();

                drCashLine["AD_CLIENT_ID"] = "1000000";
                drCashLine["AD_ORG_ID"] = nextSynchReocrd.Rows[0]["AD_ORG_ID"];
                drCashLine["ISACTIVE"] = "Y";
                drCashLine["CREATEDBY"] = "1000000";
                drCashLine["UPDATEDBY"] = "1000000";
                drCashLine["C_CASH_ID"] = cashInformation.Rows[0]["C_CASH_ID"];
                drCashLine["LINE"] =
                    nextSynchReocrd.Rows[0]["LINE"];
                drCashLine["DESCRIPTION"] =
                    (nextSynchReocrd.Rows[0]["TENDERTYPE"].ToString() + " - " +
                    nextSynchReocrd.Rows[0]["CHECKNO"].ToString() + " - " +
                    nextSynchReocrd.Rows[0]["DESCRIPTION"].ToString()).Replace(" -  - ", " - ");
                drCashLine["CASHTYPE"] =
                    nextSynchReocrd.Rows[0]["CASHTYPE"].ToString();
                drCashLine["C_BANKACCOUNT_ID"] = 
                    nextSynchReocrd.Rows[0]["C_BANKACCOUNT_ID"];
                drCashLine["C_CURRENCY_ID"] = "204";
                drCashLine["AMOUNT"] = 
                    decimal.Parse(nextSynchReocrd.Rows[0]["AMOUNT"].ToString()) * -1;
                drCashLine["DISCOUNTAMT"] = "0";
                drCashLine["WRITEOFFAMT"] = "0";
                drCashLine["ISGENERATED"] = "N";
                drCashLine["PROCESSED"] = "Y";
                drCashLine["OVERUNDERAMT"] = "0";


                dtNewCashLine.Rows.Add(drCashLine);

                nextSynchReocrd = dtNewCashLine.Copy();

                nextSynchReocrd.Columns.Add("CHANGE_TYPE");
                nextSynchReocrd.Rows[0]["CHANGE_TYPE"] = "IN";

                dtNewCashLine.Dispose();

            }
            else if (tableNameToSynchronise == "C_CASHLINESOURCE")
            {
                //Check if there is a valid Cash Line for the Cashline Source

                string posCashLineId = nextSynchReocrd.Rows[0]["C_CASHLINE_ID"].ToString();

                if (posCashLineId == "" || posCashLineId == "0" || posCashLineId == " ")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_CASH_ID MISSING", isPos);
                    goto startDataSynchronisation;
                }

                DataTable cashLineInformation =
                    this.getDTN_C_CASHLINE(null, "", posCashLineId, recordStation, "", false, "AND");

                if (!this.checkIfTableContainesData(cashLineInformation))
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_CASHLINE_ID MISSING", isPos);
                    cashLineInformation.Dispose();
                    goto startDataSynchronisation;
                }
                if (cashLineInformation.Rows[0]["C_CASHLINE_ID"].ToString() == "" ||
                    cashLineInformation.Rows[0]["C_CASHLINE_ID"].ToString() == "0")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_CASHLINE_ID MISSING", isPos);
                    cashLineInformation.Dispose();
                    goto startDataSynchronisation;
                }
                                
                cashLineInformation =
                    this.getC_CASHLINEInfo(null, "", "", "",
                        cashLineInformation.Rows[0]["C_CASHLINE_ID"].ToString(), "", "",
                        "", "", triaStateBool.Ignor, false, false, "AND");

                if (!this.checkIfTableContainesData(cashLineInformation))
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_CASHLINE_ID MISSING", isPos);
                    cashLineInformation.Dispose();
                    goto startDataSynchronisation;
                }
                if (cashLineInformation.Rows[0]["C_CASHLINE_ID"].ToString() == "" ||
                    cashLineInformation.Rows[0]["C_CASHLINE_ID"].ToString() == "0")
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_CASHLINE_ID MISSING", isPos);
                    cashLineInformation.Dispose();
                    goto startDataSynchronisation;
                }

                string _CASH_ID = 
                    cashLineInformation.Rows[0]["C_CASH_ID"].ToString();

                cashLineInformation =
                    this.getC_CASHLINEInfo(null, "", "", _CASH_ID, "", "", "",
                        "", "", triaStateBool.Ignor, false, false, "AND");

                DataTable cashInfo =
                    this.getC_CASHInfo(null, "", "",
                            cashLineInformation.Rows[0]["C_CASH_ID"].ToString(), "",
                            DateTime.Now, false, "", "", "", triaStateBool.Ignor,
                            false, false, "AND");

                if (!this.checkIfTableContainesData(cashInfo))
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "C_CASH_ID MISSING", isPos);
                    cashInfo.Dispose();
                    goto startDataSynchronisation;
                }

                decimal amount = 0;

                if (nextSynchReocrd.Rows[0]["SOURCETYPE"].ToString() == "Refund")
                {
                    //Check if there is a valid Invoice for the Return

                    string posSalesInvoiceId = nextSynchReocrd.Rows[0]["C_INVOICE_ID"].ToString();

                    if (posSalesInvoiceId == "" || posSalesInvoiceId == "0" || posSalesInvoiceId == " ")
                    {
                        //PASS ERROR FOR STATUS
                        nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                        this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                        //LOG ERROR TO DAILY ERROR LOG
                        this.logSyncError(synchId, tableNameToSynchronise, "C_INVOICE_ID MISSING", isPos);
                        goto startDataSynchronisation;
                    }

                    DataTable salesInformation =
                        this.getDTN_C_ORDER(null, "", "", posSalesInvoiceId, recordStation, false, "REF", "AND");

                    if (!this.checkIfTableContainesData(salesInformation))
                    {
                        //PASS ERROR FOR STATUS
                        nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                        this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                        //LOG ERROR TO DAILY ERROR LOG
                        this.logSyncError(synchId, tableNameToSynchronise, "C_ORDER_ID MISSING", isPos);
                        salesInformation.Dispose();
                        goto startDataSynchronisation;
                    }
                    if (salesInformation.Rows[0]["C_ORDER_ID"].ToString() == "" ||
                        salesInformation.Rows[0]["C_ORDER_ID"].ToString() == "0")
                    {
                        //PASS ERROR FOR STATUS
                        nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                        this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                        //LOG ERROR TO DAILY ERROR LOG
                        this.logSyncError(synchId, tableNameToSynchronise, "C_ORDER_ID MISSING", isPos);
                        salesInformation.Dispose();
                        goto startDataSynchronisation;
                    }

                    salesInformation =
                        this.getC_INVOICEInfo(null, "", "", "",
                                        salesInformation.Rows[0]["C_ORDER_ID"].ToString(),
                                        "", "", "", "CL", "CO", "", triaStateBool.yes,
                                        triaStateBool.yes, false, false, "AND");

                    if (!this.checkIfTableContainesData(salesInformation))
                    {
                        //PASS ERROR FOR STATUS
                        nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                        this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                        //LOG ERROR TO DAILY ERROR LOG
                        this.logSyncError(synchId, tableNameToSynchronise, "C_INVOICE_ID MISSING", isPos);
                        salesInformation.Dispose();
                        goto startDataSynchronisation;
                    }
                    if (salesInformation.Rows[0]["C_INVOICE_ID"].ToString() == "" ||
                        salesInformation.Rows[0]["C_INVOICE_ID"].ToString() == "0")
                    {
                        //PASS ERROR FOR STATUS
                        nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                        this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                        //LOG ERROR TO DAILY ERROR LOG
                        this.logSyncError(synchId, tableNameToSynchronise, "C_INVOICE_ID MISSING", isPos);
                        salesInformation.Dispose();
                        goto startDataSynchronisation;
                    }

                    amount = decimal.Parse(salesInformation.Rows[0]["GRANDTOTAL"].ToString());

                }
                else if (nextSynchReocrd.Rows[0]["SOURCETYPE"].ToString() == "Exemption")
                {

                    //Check Invoice for Exempiton
                    DataTable invoiceInformation =
                        this.getDTN_C_EXEMPTION(null, "",
                            nextSynchReocrd.Rows[0]["C_INVOICE_ID"].ToString(),
                            recordStation, "", false, "AND");

                    if (!this.checkIfTableContainesData(invoiceInformation))
                    {
                        //PASS ERROR FOR STATUS
                        nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                        this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                        //LOG ERROR TO DAILY ERROR LOG
                        this.logSyncError(synchId, tableNameToSynchronise, "C_INVOICE_ID MISSING", isPos);
                        invoiceInformation.Dispose();
                        goto startDataSynchronisation;
                    }
                    if (invoiceInformation.Rows[0]["C_INVOICE_ID"].ToString() == "" ||
                        invoiceInformation.Rows[0]["C_INVOICE_ID"].ToString() == "0")
                    {
                        //PASS ERROR FOR STATUS
                        nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                        this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                        //LOG ERROR TO DAILY ERROR LOG
                        this.logSyncError(synchId, tableNameToSynchronise, "C_INVOICE_ID MISSING", isPos);
                        invoiceInformation.Dispose();
                        goto startDataSynchronisation;
                    }

                    invoiceInformation =
                        this.getC_INVOICEInfo(null, "", "",
                                invoiceInformation.Rows[0]["C_INVOICE_ID"].ToString(),
                                "", "", "", "", "CL", "CO", "", triaStateBool.yes,
                                triaStateBool.yes, false, false, "AND");

                    amount = decimal.Parse(invoiceInformation.Rows[0]["GRANDTOTAL"].ToString());
                }
                else
                {
                    //PASS ERROR FOR STATUS
                    nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId, tableNameToSynchronise, "UNKNOWN RECORD", isPos);                    
                    goto startDataSynchronisation;
                }



                cashInfo.Rows[0]["STATEMENTDIFFERENCE"] =
                    decimal.Parse(cashInfo.Rows[0]["STATEMENTDIFFERENCE"].ToString()) -
                    amount;

                cashInfo.Rows[0]["ENDINGBALANCE"] =
                    decimal.Parse(cashInfo.Rows[0]["ENDINGBALANCE"].ToString()) +
                    amount;

                this.changeDataBaseTableData(cashInfo, "C_CASH", "UPDATE", false);


                DataTable dtNewCashLine =
                    this.getDBTableStructure("C_CASHLINE", false);

                DataRow drCashLine = dtNewCashLine.NewRow();

                drCashLine["AD_CLIENT_ID"] = "1000000";
                drCashLine["AD_ORG_ID"] = nextSynchReocrd.Rows[0]["AD_ORG_ID"];
                drCashLine["ISACTIVE"] = "Y";
                drCashLine["CREATEDBY"] = "1000000";
                drCashLine["UPDATEDBY"] = "1000000";
                drCashLine["C_CASH_ID"] =
                    cashLineInformation.Rows[0]["C_CASH_ID"];
                drCashLine["LINE"] =
                    (cashLineInformation.Rows.Count + 1) * 10;                
                drCashLine["CASHTYPE"] = "I";
                drCashLine["C_CURRENCY_ID"] = "204";
                drCashLine["AMOUNT"] =
                    amount;
                drCashLine["DISCOUNTAMT"] = "0";
                drCashLine["WRITEOFFAMT"] = "0";
                drCashLine["ISGENERATED"] = "N";
                drCashLine["PROCESSED"] = "Y";
                drCashLine["OVERUNDERAMT"] = "0";


                dtNewCashLine.Rows.Add(drCashLine);

                nextSynchReocrd = dtNewCashLine.Copy();

                nextSynchReocrd.Columns.Add("CHANGE_TYPE");
                nextSynchReocrd.Rows[0]["CHANGE_TYPE"] = "IN";

                dtNewCashLine.Dispose();
            }

            string dmlChange = "";
            if (nextSynchReocrd.Rows[0]["CHANGE_TYPE"].ToString().ToUpperInvariant() == "IN")
                dmlChange = "INSERT";
            else if (nextSynchReocrd.Rows[0]["CHANGE_TYPE"].ToString().ToUpperInvariant() == "UP")
                dmlChange = "UPDATE";
            else if (nextSynchReocrd.Rows[0]["CHANGE_TYPE"].ToString().ToUpperInvariant() == "DL")
                dmlChange = "DELETE";

            
            string[] primaryKeysForNewInsertion =
                this.changeDataBaseTableData(nextSynchReocrd.Copy(), 
                                    alternateCompTableNameToSynchronise == "" ? 
                                    compiereTableNameToSynchronise :
                                    alternateCompTableNameToSynchronise, dmlChange, false);

            this.recordNumberOfNewRecordChange(compiereTableNameToSynchronise, dmlChange, isPos);
            
            if (!this.compExecuteOnError)
            {
                nextSynchroniseRecordInfo.Rows[0]["STATUS"] = changedRecord;
                if (dmlChange == "INSERT")
                {
                    string dictionayDML = "UPDATE";
                    string[] RecordPrimaryKeyColumnName =
                        this.getCOMPIEREDBTablePrimaryKey(compiereTableNameToSynchronise);

                    string[] primaryKeySepartor = { " <(", ")>||" };
                    string[] newPrimaryKeys = new string[(primaryKeysForNewInsertion.Length * 2)];
                    for (int arrayIndexCounter = 0; 
                            arrayIndexCounter <= primaryKeysForNewInsertion.Length - 1;
                            arrayIndexCounter++)
                    {
                        primaryKeysForNewInsertion[arrayIndexCounter].Split(primaryKeySepartor,
                            StringSplitOptions.RemoveEmptyEntries).
                                CopyTo(newPrimaryKeys, (arrayIndexCounter * 2));
                    }                    
                    if (newPrimaryKeys.Length < 2)
                    {
                        //PASS ERROR FOR STATUS
                        nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                        this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                        //LOG ERROR TO DAILY ERROR LOG
                        this.logSyncError(synchId, tableNameToSynchronise, "DICTIONARY ELEMENT MISSING", isPos);                        
                        goto startDataSynchronisation;
                    }
                    foreach (string RecordKey in RecordPrimaryKeyColumnName)
                        if (!newPrimaryKeys.Contains(RecordKey))
                        {
                            //PASS ERROR FOR STATUS
                            nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                            this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE", true);
                            //LOG ERROR TO DAILY ERROR LOG
                            this.logSyncError(synchId, tableNameToSynchronise, "DICTIONARY ELEMENT MISSING", isPos);
                            goto startDataSynchronisation;
                        }
                    string dictionaryTableName = "DTN_" + compiereTableNameToSynchronise;
                    if (compiereTableNameToSynchronise == "C_LOCATION" ||
                        compiereTableNameToSynchronise == "C_BPARTNER_LOCATION")
                    {
                        dictionaryTableName = "DTN_C_BPARTNER";
                    }
                    string getDictionayRecordToUpdate = "SELECT * FROM " + dictionaryTableName + 
                                                    " WHERE ID = " + recordId + 
                                                    " AND STATION = " + recordStation;
                    if (compiereTableNameToSynchronise == "C_ORDER" ||
                        compiereTableNameToSynchronise == "C_ORDERLINE")
                    {
                        getDictionayRecordToUpdate = getDictionayRecordToUpdate + " AND TYPE = '" + trxType + "'";
                    }
                    DataTable dictionaryRecordToUpdate =
                        (DataTable)this.executeSqlOnPOS(getDictionayRecordToUpdate);

                    if (!this.checkIfTableContainesData(dictionaryRecordToUpdate))
                    {
                        dictionayDML = "INSERT";
                        DataRow drNewDictionaryRecord = dictionaryRecordToUpdate.NewRow();
                        drNewDictionaryRecord["ID"] = recordId;
                        drNewDictionaryRecord["STATION"] = recordStation;

                        if (compiereTableNameToSynchronise == "C_ORDER" ||
                        compiereTableNameToSynchronise == "C_ORDERLINE")
                        {
                            drNewDictionaryRecord["TYPE"] = trxType;
                        }
                        dictionaryRecordToUpdate.Rows.Add(drNewDictionaryRecord);                        
                    }

                    for (int arrayCounter = 0;
                        arrayCounter <= newPrimaryKeys.Length - 1; 
                        arrayCounter += 2)
                    {
                        if (dictionaryRecordToUpdate.Columns.Contains(newPrimaryKeys[arrayCounter]))
                            dictionaryRecordToUpdate.Rows[0][newPrimaryKeys[arrayCounter]] =
                                newPrimaryKeys[arrayCounter + 1];
                    }

                    this.changeDataBaseTableData(dictionaryRecordToUpdate, dictionaryTableName,
                        dictionayDML, true);
                }
                
                //If record is Bpartner Create Bpartner Customer, Vendor and Employee
                // acct Record.
                
                if (tableNameToSynchronise == "DUP_C_BPARTNER")
                {
                    DataTable C_Bpartner_Type_Acct = new DataTable();

                    DataTable BPInformation =
                        this.getDTN_C_BPARTNER(null, "", "", "", "",
                                            recordId, recordStation, false, "AND");
                    string C_BPARTNER_ID = BPInformation.Rows[0]["C_BPARTNER_ID"].ToString();
                    string TEMPLATE_ACCT_TABLE_NAME = "";
                    string getPartnerAcctTemplate = "SELECT * FROM ";
                    //Inserting Bpartner ...
                    //Customer Acct
                    TEMPLATE_ACCT_TABLE_NAME = "UTL_C_BP_CUSTOMER_ACCT";
                    getPartnerAcctTemplate = "SELECT * FROM " + TEMPLATE_ACCT_TABLE_NAME;
                    C_Bpartner_Type_Acct = (DataTable) executeSqlOnPOS(getPartnerAcctTemplate);
                    if (this.checkIfTableContainesData(C_Bpartner_Type_Acct))
                    {
                        C_Bpartner_Type_Acct.Rows[0]["C_BPARTNER_ID"] = C_BPARTNER_ID;
                        if (C_Bpartner_Type_Acct.Rows[0]["C_ACCTSCHEMA_ID"].ToString() == "")
                            C_Bpartner_Type_Acct.Rows[0]["C_ACCTSCHEMA_ID"] = "1000000";

                        this.changeDataBaseTableData(C_Bpartner_Type_Acct,
                                        TEMPLATE_ACCT_TABLE_NAME.Replace("UTL_",""),"INSERT",false);

                    }                   

                    //Inserting Bpartner ...
                    //Employee Acct
                    TEMPLATE_ACCT_TABLE_NAME = "UTL_C_BP_EMPLOYEE_ACCT";
                    getPartnerAcctTemplate = "SELECT * FROM " + TEMPLATE_ACCT_TABLE_NAME;
                    C_Bpartner_Type_Acct = (DataTable) executeSqlOnPOS(getPartnerAcctTemplate);
                    if (this.checkIfTableContainesData(C_Bpartner_Type_Acct))
                    {
                        C_Bpartner_Type_Acct.Rows[0]["C_BPARTNER_ID"] = C_BPARTNER_ID;
                        if (C_Bpartner_Type_Acct.Rows[0]["C_ACCTSCHEMA_ID"].ToString() == "")
                            C_Bpartner_Type_Acct.Rows[0]["C_ACCTSCHEMA_ID"] = "1000000";

                        this.changeDataBaseTableData(C_Bpartner_Type_Acct,
                                        TEMPLATE_ACCT_TABLE_NAME.Replace("UTL_", ""), "INSERT", false);
                    }

                    //Inserting Bpartner ...
                    //Vendor Acct
                    TEMPLATE_ACCT_TABLE_NAME = "UTL_C_BP_VENDOR_ACCT";
                    getPartnerAcctTemplate = "SELECT * FROM " + TEMPLATE_ACCT_TABLE_NAME;
                    C_Bpartner_Type_Acct = (DataTable) executeSqlOnPOS(getPartnerAcctTemplate);
                    if (this.checkIfTableContainesData(C_Bpartner_Type_Acct))
                    {
                        C_Bpartner_Type_Acct.Rows[0]["C_BPARTNER_ID"] = C_BPARTNER_ID;
                        if (C_Bpartner_Type_Acct.Rows[0]["C_ACCTSCHEMA_ID"].ToString() == "")
                            C_Bpartner_Type_Acct.Rows[0]["C_ACCTSCHEMA_ID"] = "1000000";

                        this.changeDataBaseTableData(C_Bpartner_Type_Acct,
                                        TEMPLATE_ACCT_TABLE_NAME.Replace("UTL_", ""), "INSERT", false);
                    }
                }


                if (tableNameToSynchronise == "C_PAYMENT")
                {
                    bool cashBookFound = true;

                    DataTable defaultCashBookInfo =
                        this.getC_CASHBOOKInfo(null, "",
                            nextSynchReocrd.Rows[0]["AD_ORG_ID"].ToString(), "", "",
                            triaStateBool.yes, true, false, "AND");

                    if (!this.checkIfTableContainesData(defaultCashBookInfo))
                    {
                        //LOG ERROR TO DAILY ERROR LOG
                        this.logSyncError(synchId, tableNameToSynchronise, "C_CASHBOOK_ID MISSING FOR CRV Collection", isPos);
                        defaultCashBookInfo.Dispose();
                        cashBookFound = false;
                    }
                    if (defaultCashBookInfo.Rows[0]["C_CASHBOOK_ID"].ToString() == "" ||
                        defaultCashBookInfo.Rows[0]["C_CASHBOOK_ID"].ToString() == "0")
                    {                        
                        //LOG ERROR TO DAILY ERROR LOG
                        this.logSyncError(synchId, tableNameToSynchronise, "C_CASHBOOK_ID MISSING FOR CRV Collection", isPos);
                        defaultCashBookInfo.Dispose();
                        cashBookFound = false;
                    }

                    if (cashBookFound)
                    {

                        DataTable dtNewCash =
                            this.getDBTableStructure("C_CASH", false);

                        DataRow drCash = dtNewCash.NewRow();

                        drCash["AD_CLIENT_ID"] = "1000000";
                        drCash["AD_ORG_ID"] = nextSynchReocrd.Rows[0]["AD_ORG_ID"];
                        drCash["ISACTIVE"] = "Y";
                        drCash["CREATEDBY"] = "1000000";
                        drCash["UPDATEDBY"] = "1000000";
                        drCash["C_CASHBOOK_ID"] = defaultCashBookInfo.Rows[0]["C_CASHBOOK_ID"];
                        drCash["NAME"] = nextSynchReocrd.Rows[0]["DOCUMENTNO"].ToString() + "_CRV cash Collected";
                        drCash["DESCRIPTION"] = nextSynchReocrd.Rows[0]["DESCRIPTION"].ToString();
                        drCash["STATEMENTDATE"] = nextSynchReocrd.Rows[0]["DATETRX"];
                        drCash["DATEACCT"] = nextSynchReocrd.Rows[0]["DATETRX"];
                        drCash["BEGINNINGBALANCE"] = "0";
                        drCash["ENDINGBALANCE"] = nextSynchReocrd.Rows[0]["PAYAMT"];
                        drCash["STATEMENTDIFFERENCE"] = nextSynchReocrd.Rows[0]["PAYAMT"];
                        drCash["PROCESSING"] = "Y";
                        drCash["PROCESSED"] = "Y";
                        drCash["POSTED"] = "N";
                        drCash["ISAPPROVED"] = "N";
                        drCash["DOCSTATUS"] = "IN";
                        drCash["DOCACTION"] = "CO";

                        dtNewCash.Rows.Add(drCash);

                        string[] primaryKeys =
                            this.changeDataBaseTableData(dtNewCash, "C_CASH", "INSERT", false);
                        
                        string[] RecordPrimaryKeyName =
                                this.getCOMPIEREDBTablePrimaryKey("C_CASH");

                        string[] primaryKeySepartor = { " <(", ")>||" };
                        string[] newPrimaryKey = new string[(primaryKeys.Length * 2)];
                        for (int arrayIndexCounter = 0;
                                arrayIndexCounter <= primaryKeys.Length - 1;
                                arrayIndexCounter++)
                        {
                            primaryKeys[arrayIndexCounter].Split(primaryKeySepartor,
                                StringSplitOptions.RemoveEmptyEntries).
                                    CopyTo(newPrimaryKey, (arrayIndexCounter * 2));
                        }
                        if (newPrimaryKey.Length < 2)
                        {
                            //LOG ERROR TO DAILY ERROR LOG
                            this.logSyncError(synchId, tableNameToSynchronise, "CRV C_CASH_ID MISSING", isPos);
                            cashBookFound = false; ;
                        }
                        foreach (string RecordKey in RecordPrimaryKeyName)
                            if (!newPrimaryKey.Contains(RecordKey))
                            {
                                //LOG ERROR TO DAILY ERROR LOG
                                this.logSyncError(synchId, tableNameToSynchronise, "CRV C_CASH_ID MISSING", isPos);
                                cashBookFound = false; ;
                            }

                        dtNewCash.Dispose();


                        if (cashBookFound)
                        {

                            DataTable dtNewCashLine =
                                this.getDBTableStructure("C_CASHLINE", false);

                            DataRow drCashLine = dtNewCashLine.NewRow();

                            drCashLine["AD_CLIENT_ID"] = "1000000";
                            drCashLine["AD_ORG_ID"] = nextSynchReocrd.Rows[0]["AD_ORG_ID"];
                            drCashLine["ISACTIVE"] = "Y";
                            drCashLine["CREATEDBY"] = "1000000";
                            drCashLine["UPDATEDBY"] = "1000000";
                            drCashLine["C_CASH_ID"] = newPrimaryKey[1];
                            drCashLine["LINE"] = "10";
                            drCashLine["DESCRIPTION"] = "";
                            drCashLine["CASHTYPE"] = "T";
                            drCashLine["C_BANKACCOUNT_ID"] = "351000015";
                            drCashLine["C_CURRENCY_ID"] = "204";
                            drCashLine["AMOUNT"] =
                                nextSynchReocrd.Rows[0]["PAYAMT"];
                            drCashLine["DISCOUNTAMT"] = "0";
                            drCashLine["WRITEOFFAMT"] = "0";
                            drCashLine["ISGENERATED"] = "N";
                            drCashLine["PROCESSED"] = "N";
                            drCashLine["OVERUNDERAMT"] = "0";


                            dtNewCashLine.Rows.Add(drCashLine);

                        primaryKeys =
                            this.changeDataBaseTableData(dtNewCashLine, "C_CASHLINE", "INSERT", false);                        
                            
                            dtNewCashLine.Dispose();
                        }
                    }
                }

            }
            else
                nextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;

            this.changeDataBaseTableData(nextSynchroniseRecordInfo, "UTL_CHANGE_ORDER", "UPDATE",true);

            goto startDataSynchronisation;
        }


        //Compiere table Info
        public DataTable getDUP_DMLSEQUENCEinfo (DataTable criteriaTable, string criteriaTableLogicalConnector,
                        string sequenceId, string tableName, changeType _changeType,
                        changeStatus status, bool nextNonSynchRecord,
                        bool structureOnly, string logicalConnector)
        {
            
            if (structureOnly)
                return this.getDBTableStructure("DUP_DMLSEQUENCE", false);

            if (nextNonSynchRecord)
            {                
                string getMinimumSequenceId =
                    "SELECT MIN(SEQUENCENO)AS SEQUENCENO FROM DUP_DMLSEQUENCE WHERE  STATUS = 'PENDING'";
                DataTable dtMinSequenceId = 
                    (DataTable)this.executeSqlOnCompiere (getMinimumSequenceId);
                if (this.checkIfTableContainesData(dtMinSequenceId))
                {
                    getMinimumSequenceId =
                        "SELECT * FROM DUP_DMLSEQUENCE WHERE SEQUENCENO = " +
                                dtMinSequenceId.Rows[0]["SEQUENCENO"].ToString();
                    dtMinSequenceId =
                        (DataTable)this.executeSqlOnCompiere(getMinimumSequenceId);
                }
                return dtMinSequenceId;
            }

            string getRequestedTableInformation = "";
            

            string whereClause = "";

            if (sequenceId != "")
                whereClause = whereClause + " SEQUENCENO = '" + sequenceId + "'";

            if(tableName != "")
                whereClause = whereClause + " " + logicalConnector +
                    " TABLENAME = '" + tableName + "'";

            if(_changeType != changeType.UNKOWN)
                whereClause = whereClause + " " + logicalConnector +
                    " CHANGETYPE = '" + _changeType.ToString() + "'";

            if(status != changeStatus.UNKOWN)
                whereClause = whereClause + " " + logicalConnector +
                    " STATUS = '" + status.ToString() + "'";

            if (whereClause != "")
            {
                if(whereClause.StartsWith(logicalConnector))
                    whereClause = whereClause.Remove(0,logicalConnector.Length);
                whereClause = "WHERE " + whereClause;
            }

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, 
                        criteriaTableLogicalConnector, logicalConnector,false);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM DUP_DMLSEQUENCE " + whereClause;

            return (DataTable)executeSqlOnCompiere (getRequestedTableInformation);
            
        }

        public DataTable getAD_SEQUENCEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_SEQUENCE_ID, string NAME, triaStateBool onlyActiveRecords,
            bool structureOnly,triaStateBool isTableID, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("AD_SEQUENCE",false);
            }

            string whereClause = "";

            if (isTableID != triaStateBool.yes)
                whereClause = whereClause + " AD_CLIENT_ID = " + AD_CLIENT_ID;
            else
                whereClause = whereClause + " ISTABLEID = 'Y'";
            

            if (onlyActiveRecords == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector + " ISACTIVE = 'Y'";
            }
            else if (onlyActiveRecords == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector + " ISACTIVE = 'N'";
            
            if (AD_SEQUENCE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_SEQUENCE_ID = " + AD_SEQUENCE_ID;

            if (NAME != "")
                whereClause = whereClause + " " + logicalConnector +
                    " UPPER(NAME) = '" + NAME.ToUpperInvariant() + "'";

            if (whereClause != "")
            {
                if (whereClause.StartsWith(logicalConnector))
                    whereClause = whereClause.Remove(0, logicalConnector.Length);
                whereClause = "WHERE " + whereClause;
            }

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, 
                    criteriaTableLogicalConnector, logicalConnector,false);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM AD_SEQUENCE " + whereClause;

            return (DataTable)executeSqlOnCompiere(getRequestedTableInformation);
        }

        public DataTable getM_WAREHOUSEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string AD_ORG_ID, string M_WAREHOUSE_ID, triaStateBool onlyActiveRecords, 
                    bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("M_WAREHOUSE",false);
            }


            string whereClause = "";

            if (onlyActiveRecords == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector + " ISACTIVE = 'Y'";
            }
            else if (onlyActiveRecords == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector + " ISACTIVE = 'N'";

            if (AD_ORG_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_ORG_ID = " + AD_ORG_ID;

            if (M_WAREHOUSE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " M_WAREHOUSE_ID = " + M_WAREHOUSE_ID;

            if (whereClause != "")
            {
                if (whereClause.StartsWith(" " + logicalConnector))
                    whereClause = whereClause.Remove(0, logicalConnector.Length+1);
                whereClause = "WHERE " + whereClause;
            }


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector,false);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM M_WAREHOUSE " + whereClause;

            return (DataTable)this.executeSqlOnCompiere(getRequestedTableInformation);
        }

        public DataTable getC_CASHBOOKInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string C_CASHBOOK_ID, string NAME, triaStateBool ISDEFAULT,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("C_CASHBOOK", false);
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

            if (ISDEFAULT == triaStateBool.yes)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " ISDEFAULT = 'Y'";
            }
            else if (ISDEFAULT == triaStateBool.no)
                whereClause = whereClause + " " + logicalConnector +
                    " ISDEFAULT = 'N'";

            if (NAME != "")
                whereClause = whereClause + " " + logicalConnector +
                    " NAME = '" + NAME.Replace("'", "''") + "'";

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, false);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_CASHBOOK " + whereClause;

            return (DataTable)executeSqlOnCompiere(getRequestedTableInformation);
        }
        
        

        //Pos Table info

        public DataTable getUTL_CHANGE_ORDER(DataTable criteriaTable, string criteriaTableLogicalConnector,
                        string CHANGE_SEQUENCE_ID, string TABLE_NAME, changeType _changeType,
                        string STATUS, bool nextNonSynchRecord,
                        bool structureOnly, string logicalConnector)
        {

            if (structureOnly)
                return this.getDBTableStructure("UTL_CHANGE_ORDER", true);

            if (nextNonSynchRecord)
            {
                string getMinimumSequenceId =
                    "SELECT MIN(`CHANGE_SEQUENCE_ID`)AS SEQUENCENO " +
                    "FROM `UTL_CHANGE_ORDER` WHERE  STATUS = 'PENDING'";
                DataTable dtMinSequenceId =
                    (DataTable)this.executeSqlOnPOS(getMinimumSequenceId);
                if (this.checkIfTableContainesData(dtMinSequenceId))
                {
                    getMinimumSequenceId =
                        "SELECT * FROM `UTL_CHANGE_ORDER` WHERE `CHANGE_SEQUENCE_ID` = " +
                                dtMinSequenceId.Rows[0]["SEQUENCENO"].ToString();
                    dtMinSequenceId =
                        (DataTable)this.executeSqlOnPOS(getMinimumSequenceId);
                }
                return dtMinSequenceId;
            }

            string getRequestedTableInformation = "";


            string whereClause = "";

            if (CHANGE_SEQUENCE_ID != "")
                whereClause = whereClause + " CHANGE_SEQUENCE_ID = '" + CHANGE_SEQUENCE_ID + "'";

            if (TABLE_NAME != "")
                whereClause = whereClause + " " + logicalConnector +
                    " TABLE_NAME = '" + TABLE_NAME + "'";

            if (_changeType != changeType.UNKOWN)
                whereClause = whereClause + " " + logicalConnector +
                    " CHANGE_TYPE = '" + _changeType.ToString() + "'";

            if (STATUS != "")
            {
                whereClause = whereClause + " " + logicalConnector +
                    " STATUS = " + STATUS;
            }            

            if (whereClause != "")
            {
                if (whereClause.StartsWith(" " +logicalConnector))
                    whereClause = whereClause.Remove(0, logicalConnector.Length+1);
                whereClause = "WHERE " + whereClause;
            }

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable,
                        criteriaTableLogicalConnector, logicalConnector,true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM UTL_CHANGE_ORDER " + whereClause;

            return (DataTable)this.executeSqlOnPOS(getRequestedTableInformation);
        }

        public DataTable getITEMInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string PRODUCT_ID, triaStateBool onlyActiveRecords, 
                        bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("items",true);
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


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector,true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `items` " + whereClause + " LIMIT 0 , 10 ";

            return (DataTable)executeSqlOnPOS (getRequestedTableInformation);
        }

        public DataTable getPRICE_CONDITIONInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string M_PRICELIST_VERSION_ID, triaStateBool onlyActiveRecords, 
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

            if (M_PRICELIST_VERSION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_PRICELIST_VERSION_ID` = " + M_PRICELIST_VERSION_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector,true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `price_conditions` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }


        public DataTable getPRICE_LEVELInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string ITEM_ID,string CONDITION, triaStateBool onlyActiveRecords, bool structureOnly, 
                        string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("price_levels", true);
            }

            string whereClause = "WHERE 1";

            if (ITEM_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `item_id` = " + ITEM_ID;

            if (ITEM_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `condition` = " + CONDITION;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector,true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `price_levels` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }

        public DataTable getITEM_UNITInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string UNIT_ID, triaStateBool onlyActiveRecords,
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


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `item_units` " + whereClause + " LIMIT 0 , 50 ";

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }

        public DataTable getCATAGORYInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string CATAGORY_CODE, triaStateBool onlyActiveRecords,
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


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `categories` " + whereClause + " LIMIT 0 , 50 ";

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }
        
            //Pos Dictionary Tables
        public DataTable getDUP_C_LOCATION(DataTable criteriaTable, string criteriaTableLogicalConnector,
                        string C_LOCATION_ID,string ID,string STATION,
                        bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("DUP_C_LOCATION", true);
            }

            string whereClause = "WHERE 1";
            
            if (C_LOCATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_LOCATION_ID` = " + C_LOCATION_ID;

            if (ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ID` = " + ID;

            if (STATION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION` = " + ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `DUP_C_LOCATION` " + whereClause + " LIMIT 0 , 50 ";

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }

        public DataTable getDUP_C_BPARTNER(DataTable criteriaTable, string criteriaTableLogicalConnector,
                        string C_BPARTNER_ID, string ID, string STATION,
                        bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("DUP_C_BPARTNER", true);
            }

            string whereClause = "WHERE 1";
            
            if (C_BPARTNER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_BPARTNER_ID` = " + C_BPARTNER_ID;

            if (ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ID` = " + ID;

            if (STATION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION` = " + ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `DUP_C_BPARTNER` " + whereClause + " LIMIT 0 , 50 ";

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }


        public DataTable getC_INVOICEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string C_INVOICE_ID, string C_ORDER_ID, string C_DOCTYPE_ID, string C_DOCTYPETARGET_ID,
            string C_PAYMENT_ID, string DOCACTION, string DOCSTATUS, string DOCUMENTNO,
            triaStateBool ISSOTRX, triaStateBool PROCESSED, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("C_INVOICE", false);
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
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, false);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_INVOICE " + whereClause;

            return (DataTable)executeSqlOnCompiere(getRequestedTableInformation);
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

            if (EXEMPTIONTYPE != exemptionType.ignor)
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
                                           "FROM `C_PAYMENTALLOCATE` " + whereClause;

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }

        public DataTable getC_CASHInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string C_CASH_ID, string C_CASHBOOK_ID, DateTime STATEMENTDATE, bool useDate,
            string DOCACTION, string DOCSTATUS,
            string NAME, triaStateBool PROCESSED,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("C_CASH", false);
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
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, false) + " AND ROWNUM <= 5";

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_CASH " + whereClause;

            return (DataTable)executeSqlOnCompiere(getRequestedTableInformation);
        }


        public DataTable getC_CASHLINEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string C_CASH_ID, string C_CASHLINE_ID,
            string C_BANKACCOUNT_ID, string C_CHARGE_ID,
            string C_INVOICE_ID, string CASHTYPE, triaStateBool PROCESSED,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("C_CASHLINE", false);
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
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, false) + " AND ROWNUM <= 5";

            getRequestedTableInformation = "SELECT * " +
                                           "FROM C_CASHLINE " + whereClause;

            return (DataTable)executeSqlOnCompiere(getRequestedTableInformation);
        }



        public DataTable getDTN_C_BPARTNER(DataTable criteriaTable, string criteriaTableLogicalConnector,
                        string C_BPARTNER_LOCATION_ID, string C_BPARTNER_ID, string C_LOCATION_ID, string ID,
                        string STATION, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("DTN_C_BPARTNER", true);
            }

            string whereClause = "WHERE 1";
            
            if (C_BPARTNER_LOCATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_BPARTNER_LOCATION_ID` = " + C_BPARTNER_LOCATION_ID;

            if (C_BPARTNER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_BPARTNER_ID` = " + C_LOCATION_ID;

            if (C_LOCATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_LOCATION_ID` = " + C_LOCATION_ID;

            if (ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ID` = " + ID;

            if (STATION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION` = " + STATION;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `DTN_C_BPARTNER` " + whereClause + " LIMIT 0 , 50 ";

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }

        public DataTable getDTN_C_ORDER(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string C_ORDER_ID, string ID, string STATION, bool structureOnly, string trxType, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("DTN_C_ORDER", true);
            }

            string whereClause = "WHERE 1";
            
            if (C_ORDER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_ORDER_ID` = " + C_ORDER_ID;
                        
            if (ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ID` = " + ID;

            if (STATION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION` = " + STATION;

            if (trxType != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `TYPE` = '" + trxType + "'";

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `DTN_C_ORDER` " + whereClause + " LIMIT 0 , 50 ";

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }


        public DataTable getDTN_C_EXEMPTION(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string ID, string STATION, string C_INVOICE_ID,
                    bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("DTN_C_EXEMPTION", true);
            }

            string whereClause = "WHERE 1";

            if (C_INVOICE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_INVOICE_ID` = " + C_INVOICE_ID;

            if (ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ID` = " + ID;

            if (STATION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION` = " + STATION;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `DTN_C_EXEMPTION` " + whereClause + " LIMIT 0 , 50 ";

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }
        
        public DataTable getDTN_C_PAYMENT(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string ID, string STATION, string C_PAYMENT_ID,
                    bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("DTN_C_PAYMENT", true);
            }

            string whereClause = "WHERE 1";

            if (C_PAYMENT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_PAYMENT_ID` = " + C_PAYMENT_ID;

            if (ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ID` = " + ID;

            if (STATION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION` = " + STATION;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `DTN_C_PAYMENT` " + whereClause + " LIMIT 0 , 50 ";

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }
        
        public DataTable getDTN_C_ALLOCATIONHDR(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string ID, string STATION, string C_ALLOCATIONHDR_ID,
                    bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("DTN_C_ALLOCATIONHDR", true);
            }

            string whereClause = "WHERE 1";

            if (C_ALLOCATIONHDR_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_ALLOCATIONHDR_ID` = " + C_ALLOCATIONHDR_ID;

            if (ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ID` = " + ID;

            if (STATION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION` = " + STATION;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `DTN_C_ALLOCATIONHDR` " + whereClause + " LIMIT 0 , 50 ";

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }
        
        public DataTable getDTN_C_CASH(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string ID, string STATION, string C_CASH_ID,
                    bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("DTN_C_CASH", true);
            }

            string whereClause = "WHERE 1";

            if (C_CASH_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_CASH` = " + C_CASH_ID;

            if (ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ID` = " + ID;

            if (STATION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION` = " + STATION;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `DTN_C_CASH` " + whereClause + " LIMIT 0 , 50 ";

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }

        public DataTable getDTN_C_CASHLINE(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string ID, string STATION, string C_CASHLINE_ID,
                    bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("DTN_C_CASHLINE", true);
            }

            string whereClause = "WHERE 1";

            if (C_CASHLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_CASHLINE_ID` = " + C_CASHLINE_ID;

            if (ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ID` = " + ID;

            if (STATION != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `STATION` = " + STATION;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `DTN_C_CASHLINE` " + whereClause + " LIMIT 0 , 50 ";

            return (DataTable)executeSqlOnPOS(getRequestedTableInformation);
        }
          
                
        //General Functions
        public string getNextSequenceId(string Name, string AD_SEQUENCE_ID,
            string AD_ORG_ID, bool incrementToNextSequence, triaStateBool isTableID, bool isPOSDB)
        {
            string nextPrimaryKey = "";
            string preFix = "";
            string suffix = "";

            if (Name == "" && AD_SEQUENCE_ID == "")
                return "";            
            
            DataTable sequenceRecord =
                this.getAD_SEQUENCEInfo(null, "", AD_SEQUENCE_ID, Name, triaStateBool.yes, 
                                        false,isTableID, "AND");

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
                this.changeDataBaseTableData(sequenceRecord, "AD_SEQUENCE", "Update", isPOSDB);
            }
            return preFix + nextPrimaryKey + suffix;
        }
        
        public string[] changeDataBaseTableData(DataTable dataToEffectTheChange,
            string tableNameToChangeData, string dmlType, bool isPOSDB)
        {
            string[] primaryKeysForNewInsertion =
                new string[dataToEffectTheChange.Rows.Count];

            if (primaryKeysForNewInsertion.Length > 0)
                primaryKeysForNewInsertion[0] = "";

            if (!this.checkIfTableContainesData(dataToEffectTheChange))
                return primaryKeysForNewInsertion;

            DataTable structureOfTableToChangeData = 
                this.getDBTableStructure(tableNameToChangeData,isPOSDB);

            if (structureOfTableToChangeData == null)
                return primaryKeysForNewInsertion;

            if (structureOfTableToChangeData.Columns.Count < 1)
                return primaryKeysForNewInsertion;

            string[] tablePrimaryKeys;

            if (isPOSDB)
            {
                tablePrimaryKeys = 
                    this.getPOSDBTableConnectorKey(tableNameToChangeData);
                this.fieldSeparator = "`";
            }
            else
            {
                tablePrimaryKeys =
                    this.getCOMPIEREDBTablePrimaryKey(tableNameToChangeData);
                this.fieldSeparator = "";
            }

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
                    this.changeDataBaseTableData(newDataTable, tableNameToChangeData, dmlType,isPOSDB);

                int numberOfResult = resultTablePrimarykey1.Length;
                while (numberOfResult > 0)
                {
                    dataToEffectTheChange.Rows.RemoveAt(0);
                    numberOfResult--;
                }
                string[] resultTablePrimarykey2 =
                   this.changeDataBaseTableData(dataToEffectTheChange, tableNameToChangeData, dmlType,isPOSDB);

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
            if (!isPOSDB)
            {
                foreach (string primaryKey in tablePrimaryKeys)
                    if (dataToEffectTheChange.Rows[0][primaryKey].ToString() == "")
                    {
                        nextTablePrimaryKey = 
                            this.getNextSequenceId(tableNameToChangeData, "", "", 
                                                    true,triaStateBool.yes, isPOSDB);
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
            }

            if (dmlType.ToUpper() == "INSERT")
            {
                if (!dataToEffectTheChange.Columns.Contains("CREATED"))
                    dataToEffectTheChange.Columns.Add("CREATED", Type.GetType("System.DateTime"));

                if (!dataToEffectTheChange.Columns.Contains("CREATEDBY"))
                    dataToEffectTheChange.Columns.Add("CREATEDBY");

                dataToEffectTheChange.Rows[0]["CREATED"] = DateTime.Now;
                dataToEffectTheChange.Rows[0]["CREATEDBY"] = CREATEDBY;
            }


            if (!dataToEffectTheChange.Columns.Contains("UPDATED"))
                dataToEffectTheChange.Columns.Add("UPDATED", Type.GetType("System.DateTime"));

            if (!dataToEffectTheChange.Columns.Contains("UPDATEDBY"))
                dataToEffectTheChange.Columns.Add("UPDATEDBY");


            dataToEffectTheChange.Rows[0]["UPDATED"] = DateTime.Now;
            dataToEffectTheChange.Rows[0]["UPDATEDBY"] = UPDATEDBY;


            for (int currentModifyDataTableColumn = dataToEffectTheChange.Columns.Count - 1;
                currentModifyDataTableColumn >= 0; currentModifyDataTableColumn--)
            {
                if (!structureOfTableToChangeData.Columns.Contains(
                    dataToEffectTheChange.Columns[currentModifyDataTableColumn].ColumnName))
                    dataToEffectTheChange.Columns.RemoveAt(currentModifyDataTableColumn);
            }

            
            string dmlStatementForTable = "";
            if(isPOSDB)
                DateFormat = "yyyy-MM-dd HH-mm-ss";
            else
                DateFormat = "dd-MMM-yyyy";

            dmlStatementForTable =
                this.DMLScriptCreator(tableNameToChangeData, tablePrimaryKeys,
                this.removeEmptyColumnFromRow(dataToEffectTheChange), 0, dmlType.ToUpper());

            //Execute.

            if (dmlStatementForTable != "")
            {
                if (isPOSDB)
                    this.executeSqlOnPOS(dmlStatementForTable);
                else
                    this.executeSqlOnCompiere(dmlStatementForTable);
            }
            
            //The return Array Format is arrayIndex[0]=|primaryKeyName1forRowOne<("theNewPrimaryKey")>|| ...
            //primaryKeyName2forRowOne<("theNewPrimaryKey")>|| ...,
            //arrayIndex[1]=|primaryKeyName1forRow2<("theNewPrimaryKey")>||
            //primaryKeyName2forRow2<("theNewPrimaryKey")>||...
            return primaryKeysForNewInsertion;
        }
        
    }
}


        