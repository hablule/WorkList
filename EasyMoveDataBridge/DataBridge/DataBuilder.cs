using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Security.Cryptography;



namespace EasyMoveDataBridge
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
        private bool esayMoveExecuteOnError = false;
        private bool compExecuteOnError = false;
        private bool sourceDBIsEsayMove = false;


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

        
        //public string generateNewPrimaryKeyID(string tableName)
        //{
        //    string nextPrimaryKey = "";
        //    string getPrimaryKey = "SELECT CURRENTNEXT" +
        //        " FROM AD_SEQUENCE"+
        //        " WHERE UPPER(NAME) = '" + tableName+"'";
        //    DataTable primaryKey = new DataTable(); //this.executeSqlOnCompiere(getPrimaryKey);
        //        if (checkIfTableContainesData(primaryKey))
        //        {
        //            nextPrimaryKey = primaryKey.Rows[0][0].ToString();
        //            string setPrimaryKey = "UPDATE AD_SEQUENCE" +
        //                " SET  CURRENTNEXT = CURRENTNEXT + 0" + 
        //                " WHERE UPPER(NAME) = '" + tableName+"'";
        //            //this.executeSqlOnCompiere(setPrimaryKey);
        //         }
                                   
        //    return nextPrimaryKey.ToString();        
        //}
        
        
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
        

        public bool writeTextLinetoFile(string textLine,logType _logType,bool isEasyMoveDBTable)
        {
            string filePath = "";
            string fileName = "";
            string easyMoveCompiereIdentifier = "";
            string extension = "";
            string[] fileNames = null;
            List<FileInfo> fileList = new List<FileInfo>();
            //FileInfo fullfillPath;


            if (isEasyMoveDBTable)
            {
                easyMoveCompiereIdentifier = "EC"; 
                switch (_logType)
                {
                    case logType.script:
                        filePath = dbSettingInformationHandler.easyMoveScriptDirectory;
                        extension = ".srp";
                        break;
                    case logType.warnning:
                        filePath = dbSettingInformationHandler.easyMoveWarningDirectory;
                        extension = ".wrn";
                        break;
                    case logType.error:
                        filePath = dbSettingInformationHandler.easyMoveErrorDirectory;
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
                easyMoveCompiereIdentifier = "CE";
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

            extension = "_" + easyMoveCompiereIdentifier + extension;

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


        public object executeSqlOnEsayMove(string sqlCommand)
        {
            
            DataTable resultOfQuery = new DataTable();             
            int rowsAffected = 0;
            string connectionStatus;
            string mySqlDataBaseType = dbSettingInformationHandler.easyMoveDataBaseType;
            string mySqlHostName = dbSettingInformationHandler.easyMoveHostName;
            string mySqlDataBaseName = dbSettingInformationHandler.easyMoveDataBaseName;
            string mySqlUserName = dbSettingInformationHandler.easyMoveDBUserName;
            string mySqlPassWord = dbSettingInformationHandler.easyMoveDBPassword;
            string mySqlPort = dbSettingInformationHandler.easyMoveDBPort;
            this.esayMoveExecuteOnError = false;

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
                                                    logType.error, sourceDBIsEsayMove);
                    }
                    if (dbCommitFailure.dbCommitWarnning || rowsAffected <= 0)
                    {
                        this.writeTextLinetoFile("WARNNING WHILE EXECUTING " + sqlCommand +
                                                    "/**" + dbCommitFailure.dbCommitWarnningMessage,
                                                    logType.warnning, sourceDBIsEsayMove);
                    }
                    if ((!dbCommitFailure.dbCommitError && !dbCommitFailure.dbCommitWarnning) ||
                        (rowsAffected > 0))
                    {
                        if (dbSettingInformationHandler.easyMoveLogChangeScript)
                            this.writeTextLinetoFile(sqlCommand, logType.script, sourceDBIsEsayMove);
                    }
                    else
                    {
                        this.esayMoveExecuteOnError = true;
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
                                                    logType.error, sourceDBIsEsayMove);
                    }
                    if (dbCommitFailure.dbCommitWarnning || rowsAffected <= 0)
                    {
                        this.writeTextLinetoFile("WARNNING WHILE EXECUTING " + sqlCommand +
                                                    "/**" + dbCommitFailure.dbCommitWarnningMessage,
                                                    logType.warnning, sourceDBIsEsayMove);
                    }
                    if ((!dbCommitFailure.dbCommitError && !dbCommitFailure.dbCommitWarnning) || 
                            (rowsAffected > 0))
                    {
                        if (dbSettingInformationHandler.compLogChangeScript)
                            this.writeTextLinetoFile(sqlCommand, logType.script, sourceDBIsEsayMove);
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
            string wherClauselogicalConnector, bool isEasyMoveDBTable)
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
            if (isEasyMoveDBTable)
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
                            " " + delimApostrophy + _criteriaTable.Rows[rowCounter]["Value"].ToString().Replace("'","''")
                            + delimApostrophy;
                    }
                    if ((rowCounter+1) <= _criteriaTable.Rows.Count-1)
                        theCriteriaClase = theCriteriaClase + " " + _criteriaLogicalConnector + " ";
                }

                theCriteriaClase = theCriteriaClase + ")";
            return theCriteriaClase;
        }


        public string[] getEasyMoveDBTablePrimaryKey(string tableName)
        {
            //PROVIDE KEYS WHICH CONNECT POS TO COMPIERE (MAY NOT BE NECESSARILY PRIMARY KEY ON POS TABLE)

            tableName = tableName.ToUpperInvariant();
            string[] primarykeys = { "" };
            if (tableName == "EM_AD_CLIENT")
            { primarykeys = new string[] { "AD_CLIENT_ID" }; }
            else if (tableName == "EM_AD_ORG")
            { primarykeys = new string[] { "AD_ORG_ID" }; }
            else if (tableName == "EM_AD_SEQUENCE")
            { primarykeys = new string[] { "AD_SEQUENCE_ID", "EM_STATION_ID" }; }
            else if (tableName == "EM_AD_USER")
            { primarykeys = new string[] { "AD_USER_ID" }; }
            else if (tableName == "EM_AD_USER_ORGACCESS")
            { primarykeys = new string[] { "AD_ORG_ID", "AD_USER_ID" }; }
            else if (tableName == "EM_C_DOCTYPE")
            { primarykeys = new string[] { "C_DOCTYPE_ID" }; }
            else if (tableName == "EM_C_UOM")
            { primarykeys = new string[] { "C_UOM_ID" }; }
            else if (tableName == "EM_M_LOCATOR")
            { primarykeys = new string[] { "M_LOCATOR_ID" }; }
            else if (tableName == "EM_M_MOVEMENT")
            { primarykeys = new string[] { "M_MOVEMENT_ID" }; }
            else if (tableName == "EM_M_MOVEMENTDISPUTE")
            { primarykeys = new string[] { "M_MOVEMENTDISPUTE_ID" }; }
            else if (tableName == "EM_M_MOVEMENTLINE")
            { primarykeys = new string[] { "M_MOVEMENTLINE_ID" }; }
            else if (tableName == "EM_M_MOVEMENTLINEDISPUTE")
            { primarykeys = new string[] { "M_MOVEMENTLINEDISPUTE_ID" }; }
            else if (tableName == "EM_M_MOVEREQUEST")
            { primarykeys = new string[] { "M_MOVEREQUEST_ID" }; }
            else if (tableName == "EM_M_MOVEREQUESTLINE")
            { primarykeys = new string[] { "M_MOVEREQUESTLINE_ID" }; }
            else if (tableName == "EM_M_PRODUCT")
            { primarykeys = new string[] { "M_PRODUCT_ID" }; }
            else if (tableName == "M_PRODUCT_BOM")
            { primarykeys = new string[] { "M_PRODUCT_BOM_ID" }; }
            else if (tableName == "EM_M_PRODUCT_CATEGORY")
            { primarykeys = new string[] { "M_PRODUCT_CATEGORY_ID" }; }
            else if (tableName == "EM_M_STORAGE")
            { primarykeys = new string[] { "M_PRODUCT_ID", "M_LOCATOR_ID" }; }
            else if (tableName == "EM_M_WAREHOUSE")
            { primarykeys = new string[] { "M_WAREHOUSE_ID" }; }
            else if (tableName == "EM_MOVE_STATUS")
            { primarykeys = new string[] { "EM_MOVE_STATUS_ID", "EM_STATION_ID" }; }
            else if (tableName == "EM_MOVE_SYNCH_STATUS")
            { primarykeys = new string[] { "CHANGE_SEQ" }; }
            else if (tableName == "EM_PROCESS_ACCESS")
            { primarykeys = new string[] { "AD_ORG_ID", "AD_USER_ID", "EM_STATION_ID" }; }
            else if (tableName == "EM_STATION")
            { primarykeys = new string[] { "EM_STATION_ID" }; }
            else if (tableName == "EM_USER_STATIONACCESS")
            { primarykeys = new string[] { "AD_USER_ID", "EM_STATION_ID" }; }
            else if (tableName == "M_MOVEMENT")
            { primarykeys = new string[] { "M_MOVEMENT_ID" }; }
            else if (tableName == "M_MOVEMENTLINE")
            { primarykeys = new string[] { "M_MOVEMENTLINE_ID" }; }
            else if (tableName == "M_INOUT")
            { primarykeys = new string[] { "M_INOUT_ID" }; }            
            else if (tableName == "M_INOUTLINE")
            { primarykeys = new string[] { "M_INOUTLINE_ID" }; }
            else if (tableName == "M_PRODUCTION")
            { primarykeys = new string[] { "M_PRODUCTION_ID" }; }
            else if (tableName == "M_PRODUCTIONPLAN")
            { primarykeys = new string[] { "M_PRODUCTIONPLAN_ID" }; }
            else if (tableName == "M_PRODUCTIONLINE")
            { primarykeys = new string[] { "M_PRODUCTIONLINE_ID" }; }

            
            return primarykeys;
        }
        
        public string[] getCOMPIEREDBTablePrimaryKey(string tableName)
        {
            string[] primarykeys = { "" };
            if (tableName == "C_DOCTYPE")
            { primarykeys = new string[] { "C_DOCTYPE_ID" }; }
            else if (tableName == "	AD_USER_ORGACCESS")
            { primarykeys = new string[] { "AD_USER_ID", "AD_ORG_ID" }; }
            else if (tableName == "M_LOCATOR")
            { primarykeys = new string[] { "M_LOCATOR_ID" }; }            
            else if (tableName == "AD_ORG")
            { primarykeys = new string[] { "AD_ORG_ID" }; }            
            else if (tableName == "AD_USER")
            { primarykeys = new string[] { "AD_USER_ID" }; }
            else if (tableName == "M_PRODUCT")
            { primarykeys = new string[] { "M_PRODUCT_ID" }; }
            else if (tableName == "M_PRODUCT_BOM")
            { primarykeys = new string[] { "M_PRODUCT_BOM_ID" }; }
            else if (tableName == "M_PRODUCT_CATEGORY")
            { primarykeys = new string[] { "M_PRODUCT_CATEGORY_ID" }; }
            else if (tableName == "C_UOM")
            { primarykeys = new string[] { "C_UOM_ID" }; }
            else if (tableName == "M_MOVEMENT")
            { primarykeys = new string[] { "M_MOVEMENT_ID" }; }            
            else if (tableName == "M_MOVEMENTLINE")
            { primarykeys = new string[] { "M_MOVEMENTLINE_ID" }; }
            else if (tableName == "AD_CLIENT")
            { primarykeys = new string[] { "AD_CLIENT_ID" }; }
            else if (tableName == "M_WAREHOUSE")
            { primarykeys = new string[] { "M_WAREHOUSE_ID" }; }
            else if (tableName == "AD_SEQUENCE")
            { primarykeys = new string[] { "AD_SEQUENCE_ID" }; }
            else if (tableName == "DUP_EM_DMLSEQUENCE")
            { primarykeys = new string[] { "SEQUENCENO" }; }
            else if (tableName == "M_INOUT")
            { primarykeys = new string[] { "M_INOUT_ID" }; }
            else if (tableName == "M_INOUTLINE")
            { primarykeys = new string[] { "M_INOUTLINE_ID" }; }
            else if (tableName == "M_PRODUCTION")
            { primarykeys = new string[] { "M_PRODUCTION_ID" }; }
            else if (tableName == "M_PRODUCTIONPLAN")
            { primarykeys = new string[] { "M_PRODUCTIONPLAN_ID" }; }
            else if (tableName == "M_PRODUCTIONLINE")
            { primarykeys = new string[] { "M_PRODUCTIONLINE_ID" }; }
            
            
            return primarykeys;
        }
        
        private DataTable getDBTableStructure(string tableName, bool isEasyMoveDBTable)
        {
            string theWhereClose = "";

            string[] Tableprimarykeys;
            DataTable result = new DataTable();

            if (isEasyMoveDBTable)
            {
                Tableprimarykeys = 
                    this.getEasyMoveDBTablePrimaryKey(tableName);
                theWhereClose = "Where 1 ";
                foreach (string primaryKey in Tableprimarykeys)
                {
                    if (primaryKey != "")
                        theWhereClose = theWhereClose + " AND `" + primaryKey + "` = '0'";
                }
                string getStructureForTable = "SELECT *" +
                                              " FROM `" + tableName + "` " + theWhereClose;
                result = (DataTable)this.executeSqlOnEsayMove(getStructureForTable);
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

        private void recordNumberOfNewRecordChange(string tableName, string DmlOperation,
            bool isEasyMoveDBTable)
        {
            tableName = tableName.ToUpperInvariant();
            DmlOperation = DmlOperation.ToUpperInvariant();

            if (dbCommitFailure.dbCommitWarnning || dbCommitFailure.dbCommitError)
            {
                if (isEasyMoveDBTable)
                {
                    if (dbCommitFailure.dbCommitError)
                    {
                        if (tableName == "M_MOVEMENT")
                            generalResultInformation.synchResultMovementErros++;
                        else if (tableName == "M_MOVEMENTLINE")
                            generalResultInformation.synchResultMovementLineErros++;
                        else if (tableName == "M_INOUT")
                            generalResultInformation.synchResultInOutErros++;
                        else if (tableName == "M_INOUTLINE")
                            generalResultInformation.synchResultInOutLineErros++;
                        else if (tableName == "M_PRODUCTION")
                            generalResultInformation.synchResultProductionErros++;
                        else if (tableName == "M_PRODUCTIONPLAN")
                            generalResultInformation.synchResultProductionPlanErros++;
                        else if (tableName == "M_PRODUCTIONLINE")
                            generalResultInformation.synchResultProductionLineErros++;
                    }
                    if (dbCommitFailure.dbCommitWarnning)
                    {
                        if (tableName == "M_MOVEMENT")
                            generalResultInformation.synchResultMovementWarnnings++;
                        else if (tableName == "M_MOVEMENTLINE")
                            generalResultInformation.synchResultMovementLineWarnnings++;
                        else if (tableName == "M_INOUT")
                            generalResultInformation.synchResultInOutWarnnings++;
                        else if (tableName == "M_INOUTLINE")
                            generalResultInformation.synchResultInOutLineWarnnings++;
                        else if (tableName == "M_PRODUCTION")
                            generalResultInformation.synchResultProductionWarnnings++;
                        else if (tableName == "M_PRODUCTIONPLAN")
                            generalResultInformation.synchResultProductionPlanWarnnings++;
                        else if (tableName == "M_PRODUCTIONLINE")
                            generalResultInformation.synchResultProductionLineWarnnings++;
                    }
                }
                else
                {
                    if (dbCommitFailure.dbCommitError)
                    {
                        if (tableName == "AD_USER_ORGACCESS")
                            generalResultInformation.synchResultUserOrgAccessErros++;
                        else if (tableName == "M_PRODUCT")
                            generalResultInformation.synchResultProductErros++;
                        else if (tableName == "M_PRODUCT_BOM")
                            generalResultInformation.synchResultBOMErros++;
                        else if (tableName == "AD_CLIENT")
                            generalResultInformation.synchResultClientErros++;
                        else if (tableName == "AD_USER")
                            generalResultInformation.synchResultUserErros++;
                        else if (tableName == "M_PRODUCT_CATEGORY")
                            generalResultInformation.synchResultCatgoryErros++;
                        else if (tableName == "C_UOM")
                            generalResultInformation.synchResultUOMErros++;
                        else if (tableName == "M_LOCATOR")
                            generalResultInformation.synchResultStoreErros++;
                        else if (tableName == "AD_ORG")
                            generalResultInformation.synchResultOrganisationErros++;
                        else if (tableName == "M_WAREHOUSE")
                            generalResultInformation.synchResultWarehouseErros++;
                        else if (tableName == "C_DOCTYPE")
                            generalResultInformation.synchResultDocumentTypeErros++;
                    }
                    if (dbCommitFailure.dbCommitWarnning)
                    {
                        if (tableName == "AD_USER_ORGACCESS")
                            generalResultInformation.synchResultUserOrgAccessWarnnings++;
                        else if (tableName == "M_PRODUCT")
                            generalResultInformation.synchResultProductWarnnings++;
                        else if (tableName == "M_PRODUCT_BOM")
                            generalResultInformation.synchResultBOMWarnnings++;
                        else if (tableName == "AD_CLIENT")
                            generalResultInformation.synchResultClientWarnnings++;
                        else if (tableName == "AD_USER")
                            generalResultInformation.synchResultUserWarnnings++;
                        else if (tableName == "C_UOM")
                            generalResultInformation.synchResultUOMWarnnings++;
                        else if (tableName == "M_PRODUCT_CATEGORY")
                            generalResultInformation.synchResultCatgoryWarnnings++;
                        else if (tableName == "M_LOCATOR")
                            generalResultInformation.synchResultStoreWarnnings++;
                        else if (tableName == "AD_ORG")
                            generalResultInformation.synchResultOrganisationWarnnings++;
                        else if (tableName == "M_WAREHOUSE")
                            generalResultInformation.synchResultWarehouseWarnnings++;
                        else if (tableName == "C_DOCTYPE")
                            generalResultInformation.synchResultDocumentTypeWarnnings++;
                    }             
                }
                return;
            }

            if (isEasyMoveDBTable)
            {
                if (tableName == "M_MOVEMENT")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultMovementInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultMovementUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultMovementDelete++;

                    if(dbSettingInformationHandler.easyMoveLogChangeScript)
                        generalResultInformation.synchResultMovementScripts++;
                }
                else if (tableName == "M_MOVEMENTLINE")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultMovementLineInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultMovementLineUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultMovementLineDelete++;

                    if (dbSettingInformationHandler.easyMoveLogChangeScript)
                        generalResultInformation.synchResultMovementLineScripts++;
                }

                else if (tableName == "M_INOUT")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultInOutInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultInOutUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultInOutDelete++;

                    if (dbSettingInformationHandler.easyMoveLogChangeScript)
                        generalResultInformation.synchResultInOutScripts++;
                }

                else if (tableName == "M_INOUTLINE")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultInOutLineInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultInOutLineUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultInOutLineDelete++;

                    if (dbSettingInformationHandler.easyMoveLogChangeScript)
                        generalResultInformation.synchResultInOutLineScripts++;
                }

                else if (tableName == "M_PRODUCTION")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultProductionInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultProductionUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultProductionDelete++;

                    if (dbSettingInformationHandler.easyMoveLogChangeScript)
                        generalResultInformation.synchResultProductionScripts++;
                }

                else if (tableName == "M_PRODUCTIONPLAN")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultProductionPlanInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultProductionPlanUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultProductionPlanDelete++;

                    if (dbSettingInformationHandler.easyMoveLogChangeScript)
                        generalResultInformation.synchResultProductionPlanScripts++;
                }

                else if (tableName == "M_PRODUCTIONLINE")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultProductionLineInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultProductionLineUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultProductionLineDelete++;

                    if (dbSettingInformationHandler.easyMoveLogChangeScript)
                        generalResultInformation.synchResultProductionLineScripts++;
                }
            }
            else
            {
                if (tableName == "AD_USER_ORGACCESS")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultUserOrgAccessInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultUserOrgAccessUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultUserOrgAccessDelete++;

                    if (dbSettingInformationHandler.easyMoveLogChangeScript)
                        generalResultInformation.synchResultUserOrgAccessScripts++;
                }
                else if (tableName == "AD_CLIENT")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultClientInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultClientUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultClientDelete++;

                    if (dbSettingInformationHandler.easyMoveLogChangeScript)
                        generalResultInformation.synchResultClientScripts++;
                }
                else if (tableName == "M_PRODUCT")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultProductInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultProductUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultProductDelete++;

                    if (dbSettingInformationHandler.easyMoveLogChangeScript)
                        generalResultInformation.synchResultProductScripts++;
                }
                else if (tableName == "M_PRODUCT_BOM")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultBOMInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultBOMUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultBOMDelete++;

                    if (dbSettingInformationHandler.easyMoveLogChangeScript)
                        generalResultInformation.synchResultBOMScripts++;
                }
                else if (tableName == "M_PRODUCT_CATEGORY")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultCatgoryInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultCatgoryUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultCatgoryDelete++;

                    if (dbSettingInformationHandler.easyMoveLogChangeScript)
                        generalResultInformation.synchResultCatgoryScripts++;
                }
                else if (tableName == "C_UOM")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultUOMInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultUOMUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultUOMDelete++;

                    if (dbSettingInformationHandler.easyMoveLogChangeScript)
                        generalResultInformation.synchResultUOMScripts++;
                }
                else if (tableName == "AD_USER")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultUserInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultUserUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultUserDelete++;

                    if (dbSettingInformationHandler.easyMoveLogChangeScript)
                        generalResultInformation.synchResultUserScripts++;
                }
                else if (tableName == "M_LOCATOR")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultStoreInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultStoreUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultStoreDelete++;

                    if (dbSettingInformationHandler.easyMoveLogChangeScript)
                        generalResultInformation.synchResultStoreScripts++;
                }
                else if (tableName == "AD_ORG")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultOrganisationInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultOrganisationUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultOrganisationDelete++;

                    if (dbSettingInformationHandler.easyMoveLogChangeScript)
                        generalResultInformation.synchResultOrganisationScripts++;
                }
                else if (tableName == "M_WAREHOUSE")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultWarehouseInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultWarehouseUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultWarehouseDelete++;

                    if (dbSettingInformationHandler.easyMoveLogChangeScript)
                        generalResultInformation.synchResultWarehouseScripts++;
                }
                else if (tableName == "C_DOCTYPE")
                {
                    if (DmlOperation == "INSERT")
                        generalResultInformation.synchResultDocumentTypeInsert++;
                    else if (DmlOperation == "UPDATE")
                        generalResultInformation.synchResultDocumentTypeUpdate++;
                    else if (DmlOperation == "DELETE")
                        generalResultInformation.synchResultDocumentTypeDelete++;

                    if (dbSettingInformationHandler.easyMoveLogChangeScript)
                        generalResultInformation.synchResultDocumentTypeScripts++;
                }
            }
        }

        private void logSyncError(string synchId, string synchTable, 
            string AdditionalMesseage, bool isEasyMoveDBTable)
        {
            string commitErrorOn = " Compiere ";
            if (!isEasyMoveDBTable)
                commitErrorOn = " EasyMove ";

            this.writeTextLinetoFile("MISSING ITEM FOR DATA SYNCHRONISATION (SYNCH ID " +
                                        synchId + 
                                        "- SYNCH TABLE " + synchTable + ") When passing To "+ commitErrorOn+
                                        " DB /** " + AdditionalMesseage,
                                        logType.error, isEasyMoveDBTable);
            //Update recordChanged counter
                //If previous state of dbCommitError is true proceed.
            if (dbCommitFailure.dbCommitError)
            {
                this.recordNumberOfNewRecordChange(synchTable, "", isEasyMoveDBTable);
            }//else make state of dbCommitError is true and revert if to false after update.
            else
            {
                dbCommitFailure.dbCommitError = true;
                this.recordNumberOfNewRecordChange(synchTable, "", isEasyMoveDBTable);
                dbCommitFailure.dbCommitError = false;
            }

        }
        
        //The synchroniser functions
        public void synchroniseDataFromCompiereToEasyMove(BackgroundWorker _backGrounWorker)
        {            
            //this.sourceDBIsEsayMove = false;
            //bool isPos = false;
                        
            string synchId = "";
            string getNextSynchroniseRecord = "";
            string tableNameToSynchronise = "";
            string nextSynchRecordWhereClause = "";
            

            DataTable dtNextSynchroniseRecordInfo = new DataTable();
            DataTable dtNextSynchReocrd = new DataTable();
            
            
            startDataSynchronisation:
            _backGrounWorker.ReportProgress(1);
            this.sourceDBIsEsayMove = false;

            dtNextSynchroniseRecordInfo =
                this.getDUP_EM_DMLSEQUENCEinfo(null, "", "", "", changeType.UNKOWN, 
                            changeStatus.UNKOWN, true, false, "");
            if (!this.checkIfTableContainesData(dtNextSynchroniseRecordInfo) ||
                _backGrounWorker.CancellationPending)
                return;

            synchId =
                dtNextSynchroniseRecordInfo.Rows[0]["SEQUENCENO"].ToString();

            tableNameToSynchronise =
                dtNextSynchroniseRecordInfo.Rows[0]["TABLENAME"].ToString();

            nextSynchRecordWhereClause = dtNextSynchroniseRecordInfo.Rows[0]["PRIMARYKEYNAME"].ToString() + " = " +
                                         dtNextSynchroniseRecordInfo.Rows[0]["PRIMARYKEYVALUE"].ToString();

            if (tableNameToSynchronise == "AD_USER_ORGACCESS")
            {
                nextSynchRecordWhereClause = nextSynchRecordWhereClause + " AND " + 
                                         dtNextSynchroniseRecordInfo.Rows[0]["PRIMARYKEYNAME2"].ToString() + " = " +
                                         dtNextSynchroniseRecordInfo.Rows[0]["PRIMARYKEYVALUE2"].ToString();
            }

            string dmlChange = "";
            if (dtNextSynchroniseRecordInfo.Rows[0]["CHANGETYPE"].ToString().ToUpperInvariant() == "IN")
                dmlChange = "INSERT";
            else if (dtNextSynchroniseRecordInfo.Rows[0]["CHANGETYPE"].ToString().ToUpperInvariant() == "UP")
                dmlChange = "UPDATE";
            else if (dtNextSynchroniseRecordInfo.Rows[0]["CHANGETYPE"].ToString().ToUpperInvariant() == "DL")
                dmlChange = "DELETE";

            if (dmlChange == "DELETE")
            {
                string applyDeleteOnEasyMove = "DELETE " +
                                       "FROM " +
                                        ((tableNameToSynchronise != "M_PRODUCT_BOM") ?
                                           "EM_" + tableNameToSynchronise :
                                           tableNameToSynchronise) +
                                       " WHERE " + nextSynchRecordWhereClause;

                this.executeSqlOnEsayMove(applyDeleteOnEasyMove); 
            }
            else
            {
                getNextSynchroniseRecord = "SELECT * " +
                                       "FROM " + tableNameToSynchronise +
                                       " WHERE " + nextSynchRecordWhereClause;

                dtNextSynchReocrd = (DataTable)this.executeSqlOnCompiere(getNextSynchroniseRecord);

                if (!this.checkIfTableContainesData(dtNextSynchReocrd))
                {
                    //reportError
                    dtNextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(dtNextSynchroniseRecordInfo,
                                    "DUP_EM_DMLSEQUENCE", "UPDATE", false);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(synchId,
                        tableNameToSynchronise, "UNABLE TO FETHC DATA FROM :-" + tableNameToSynchronise, false);
                    goto startDataSynchronisation;
                }

                if (tableNameToSynchronise == "AD_USER")
                {
                    MD5 md5Hasher = MD5.Create();
                    byte[] data =
                        md5Hasher.ComputeHash(Encoding.Default.GetBytes(dtNextSynchReocrd.Rows[0]["PASSWORD"].ToString()));

                    StringBuilder sBuilder = new StringBuilder();


                    for (int i = 0; i < data.Length; i++)
                    {
                        sBuilder.Append(data[i].ToString("x2"));
                    }

                    dtNextSynchReocrd.Rows[0]["PASSWORD"] = sBuilder.ToString();
                }

                this.changeDataBaseTableData(dtNextSynchReocrd,
                       ((tableNameToSynchronise != "M_PRODUCT_BOM") ?
                                           "EM_" + tableNameToSynchronise :
                                           tableNameToSynchronise),
                               dmlChange, true);
            }
            
            

            this.recordNumberOfNewRecordChange(tableNameToSynchronise, dmlChange, false);

            if (this.esayMoveExecuteOnError)
            {
                dtNextSynchroniseRecordInfo.Rows[0]["STATUS"] = errorRecord;
                //LOG ERROR TO DAILY ERROR LOG
                this.logSyncError(synchId,
                            tableNameToSynchronise, 
                            "UNABLE TO " + dmlChange + " DATA ON " + tableNameToSynchronise, false);
            }
            else
                dtNextSynchroniseRecordInfo.Rows[0]["STATUS"] = changedRecord;

            this.changeDataBaseTableData(dtNextSynchroniseRecordInfo,
                                "DUP_EM_DMLSEQUENCE", "UPDATE", false);
            
            goto startDataSynchronisation;

        }

        public void synchroniseDataFromEasyMoveToCompiere(BackgroundWorker _backGrounWorker)
        {
            //bool isEasyMove = true;
            
            string stNextSynchRecordId = "";
            string stNextSynchRecordTableName = "";
            
            string stMainRecordId = "";
            string stDetailRecordId = "";
            string stDetailRecordDetailId = "";

            string stDeatilRecordTableName = "";
            string stDeatilRecordDetailTableName = "";

            DataTable dtNextSynchRecordInfo = new DataTable();            
            DataTable dtNextSynchMainRecordInfo = new DataTable();
            DataTable dtNextSynchDetailRecordInfo = new DataTable();

            DataTable dtNextSynchDetailRecordDetailInfo = new DataTable();

            DBNull nullValue = DBNull.Value;

          startDataSynchronisation:
            //isEasyMove = true;            
            _backGrounWorker.ReportProgress(1);
            this.sourceDBIsEsayMove = true;

            dtNextSynchRecordInfo =
                this.getEM_MOVE_SYNCH_STATUSInfo(null, "", "", "", true, false, "");

            if (!this.checkIfTableContainesData(dtNextSynchRecordInfo) ||
                _backGrounWorker.CancellationPending)
                return;

            stNextSynchRecordId =
                dtNextSynchRecordInfo.Rows[0]["RECORD_ID"].ToString();

            stNextSynchRecordTableName =
                dtNextSynchRecordInfo.Rows[0]["TABLE_NAME"].ToString();

            dtNextSynchMainRecordInfo.Clear();
            dtNextSynchDetailRecordInfo.Clear();
            dtNextSynchDetailRecordDetailInfo.Clear();

            if (stNextSynchRecordTableName == "M_MOVEMENT")
            {
                dtNextSynchMainRecordInfo =
                    this.getEM_M_MOVEMENTInfo(null, "", stNextSynchRecordId, "", "", true, false, "AND");

                dtNextSynchDetailRecordInfo =
                    this.getEM_M_MOVEMENTLINEInfo(null, "", "", stNextSynchRecordId, "", "", true, false, "AND");

                stMainRecordId = "M_MOVEMENT_ID";
                stDetailRecordId = "M_MOVEMENTLINE_ID";
                stDeatilRecordTableName = "M_MOVEMENTLINE";

            }
            else if (stNextSynchRecordTableName == "M_INOUT")
            {
                dtNextSynchMainRecordInfo =
                    this.getM_INOUTInfo(null, "", stNextSynchRecordId, "", true, false, "AND");

                dtNextSynchDetailRecordInfo =
                    this.getM_INOUTLINEInfo(null, "", "", stNextSynchRecordId, "", "", true, false, "AND");

                stMainRecordId = "M_INOUT_ID";
                stDetailRecordId = "M_INOUTLINE_ID";
                stDeatilRecordTableName = "M_INOUTLINE";
 
            }
            else if (stNextSynchRecordTableName == "M_PRODUCTION")
            {
                dtNextSynchMainRecordInfo =
                    this.getM_PRODUCTIONInfo(null, "", stNextSynchRecordId, "", true, false, "AND");

                dtNextSynchDetailRecordInfo =
                    this.getM_PRODUCTIONPLANInfo(null, "", "", stNextSynchRecordId, "", "", true, false, "AND");
                                
                stMainRecordId = "M_PRODUCTION_ID";

                stDeatilRecordTableName = "M_PRODUCTIONPLAN";
                stDetailRecordId = "M_PRODUCTIONPLAN_ID";

                stDeatilRecordDetailTableName = "M_PRODUCTIONLINE";
                stDetailRecordDetailId = "M_PRODUCTIONLINE_ID";
            }


            if (!this.checkIfTableContainesData(dtNextSynchMainRecordInfo))
            {
                //reportError
                dtNextSynchRecordInfo.Rows[0]["STATUS"] = errorRecord;
                this.changeDataBaseTableData(dtNextSynchRecordInfo,
                                "EM_MOVE_SYNCH_STATUS", "UPDATE", true);
                //LOG ERROR TO DAILY ERROR LOG
                this.logSyncError(stNextSynchRecordId,
                    stNextSynchRecordTableName, "Record INFO MISSING - " + stMainRecordId  + " :-" + stNextSynchRecordId, true);
                goto startDataSynchronisation;
            }

            if (!this.checkIfTableContainesData(dtNextSynchDetailRecordInfo))
            {
                //reportError
                dtNextSynchRecordInfo.Rows[0]["STATUS"] = errorRecord;
                this.changeDataBaseTableData(dtNextSynchRecordInfo,
                                "EM_MOVE_SYNCH_STATUS", "UPDATE", true);
                //LOG ERROR TO DAILY ERROR LOG
                this.logSyncError(stNextSynchRecordId,
                    stNextSynchRecordTableName + "line", "RecordLine INFO MISSING - " + stDetailRecordId + " :-" + stNextSynchRecordId, true);
                goto startDataSynchronisation;                
            }

            if (stNextSynchRecordTableName == "M_PRODUCTION")
            {
                string detailRecordId = "";
                DataTable productionLineInfo;
                for (int detailRowCounter = 0; detailRowCounter <= dtNextSynchDetailRecordInfo.Rows.Count - 1; detailRowCounter++)
                {
                    detailRecordId =
                        dtNextSynchDetailRecordInfo.Rows[detailRowCounter]
                            ["M_PRODUCTIONPLAN_ID"].ToString();

                    if (detailRecordId == "")
                    {
                        dtNextSynchDetailRecordDetailInfo.Rows.Clear();
                        break;
                    }

                    productionLineInfo = 
                        this.getM_PRODUCTIONLINEInfo(null, "", "",
                                            detailRecordId, "", "", true, false,
                                            "AND");

                    if (!this.checkIfTableContainesData(productionLineInfo))
                    {
                        dtNextSynchDetailRecordDetailInfo.Rows.Clear();
                        break;
                    }

                    dtNextSynchDetailRecordDetailInfo = 
                        this.mergeTables(dtNextSynchDetailRecordDetailInfo,
                                    productionLineInfo, "M_PRODUCTIONPLAN_ID", false);
                }

                if (!this.checkIfTableContainesData(dtNextSynchDetailRecordDetailInfo))
                {
                    //reportError
                    dtNextSynchRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(dtNextSynchRecordInfo,
                                    "EM_MOVE_SYNCH_STATUS", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(stNextSynchRecordId,
                        stNextSynchRecordTableName + "line", "RecordLine Detail INFO MISSING - " + stDetailRecordId + " :-" + stNextSynchRecordId, true);
                    goto startDataSynchronisation;
                }
            }

            dtNextSynchMainRecordInfo.Rows[0][stMainRecordId] = nullValue;
            if(stNextSynchRecordTableName == "M_INOUT")
            {
                dtNextSynchMainRecordInfo.Rows[0]["C_INVOICE_ID"] = nullValue;
            }

            string[] newMovementPrimaryKey =
                this.changeDataBaseTableData(dtNextSynchMainRecordInfo, stNextSynchRecordTableName, "INSERT", false);

            this.recordNumberOfNewRecordChange(stNextSynchRecordTableName, "INSERT", true);
                        
            if (this.compExecuteOnError)
            {                
                //reportError
                dtNextSynchRecordInfo.Rows[0]["STATUS"] = errorRecord;
                this.changeDataBaseTableData(dtNextSynchRecordInfo,
                                "EM_MOVE_SYNCH_STATUS", "UPDATE", true);
                //LOG ERROR TO DAILY ERROR LOG
                this.logSyncError(stNextSynchRecordId,
                            stNextSynchRecordTableName,
                            "Unable To Insert Record to Compiere -" + stMainRecordId + " :-" + 
                             stNextSynchRecordId, true);
                goto startDataSynchronisation;
                
            }

            string[] mainRecordPrimaryKeyColumnName =
                    this.getEasyMoveDBTablePrimaryKey(stNextSynchRecordTableName);

                        
            string recordTableIdName = stMainRecordId;
            string recordDetailTableIdName = stDetailRecordId;
            
            string[] newRecordId = new string[(newMovementPrimaryKey.Length * 2)];

            string[] primaryKeySepartor = { " <(", ")>||" };
            for (int arrayIndexCounter = 0;
                arrayIndexCounter <= newMovementPrimaryKey.Length - 1;
                arrayIndexCounter++)
            {
                newMovementPrimaryKey[arrayIndexCounter].Split(primaryKeySepartor,
                    StringSplitOptions.RemoveEmptyEntries).
                        CopyTo(newRecordId, (arrayIndexCounter * 2));
            }

            if (newRecordId.Length < 2)
            {
                //reportError
                dtNextSynchRecordInfo.Rows[0]["STATUS"] = errorRecord;
                this.changeDataBaseTableData(dtNextSynchRecordInfo,
                                "EM_MOVE_SYNCH_STATUS", "UPDATE", true);
                //LOG ERROR TO DAILY ERROR LOG
                this.logSyncError(stNextSynchRecordId,
                            stNextSynchRecordTableName + "line",
                            "No New Record Id Found -" + stMainRecordId + " :-" +
                             stNextSynchRecordId, true);
                goto startDataSynchronisation;
            }

            foreach (string RecordKey in mainRecordPrimaryKeyColumnName)
                if (!newRecordId.Contains(RecordKey))
                {
                    //reportError
                    dtNextSynchRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(dtNextSynchRecordInfo,
                                    "EM_MOVE_SYNCH_STATUS", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(stNextSynchRecordId,
                                stNextSynchRecordTableName + "line",
                                "No New Record Id Found -" + stMainRecordId + " :-" +
                                 stNextSynchRecordId, true);
                    goto startDataSynchronisation;
                }

            for (int currentDetailRecord = 0;
                    currentDetailRecord <= dtNextSynchDetailRecordInfo.Rows.Count - 1;
                    currentDetailRecord++)
            {
                dtNextSynchDetailRecordInfo.Rows[currentDetailRecord][recordDetailTableIdName] = nullValue;
                dtNextSynchDetailRecordInfo.Rows[currentDetailRecord][recordTableIdName] =
                    newRecordId[1];

                if (stNextSynchRecordTableName == "M_INOUT")
                {
                    dtNextSynchDetailRecordInfo.Rows[currentDetailRecord]["C_INVOICELINE_ID"] = nullValue;
                }
            }

            string[] newMovementDetailPrimaryKey = 
                this.changeDataBaseTableData(dtNextSynchDetailRecordInfo, stDeatilRecordTableName, "INSERT", false);

            if (this.compExecuteOnError)
            {
                //reportError
                dtNextSynchRecordInfo.Rows[0]["STATUS"] = errorRecord;                
                //LOG ERROR TO DAILY ERROR LOG
                this.logSyncError(stNextSynchRecordId,
                            stDeatilRecordTableName,
                            "Unable To Insert " + stDeatilRecordTableName + " to Compiere - " + recordTableIdName + " :-" +
                             stNextSynchRecordId, true);
            }
            else
                dtNextSynchRecordInfo.Rows[0]["STATUS"] = changedRecord;

            //==== For M_productionline ======

            if (stNextSynchRecordTableName == "M_PRODUCTION")
            {
                string[] detailRecordPrimaryKeyColumnName =
                    this.getEasyMoveDBTablePrimaryKey(stDeatilRecordTableName);

                string recordDetailTableDetailIdName = stDetailRecordDetailId;

                string[] newRecordId_2 = new string[(newMovementDetailPrimaryKey.Length * 2)];

                string[] primaryKeySepartor_2 = { " <(", ")>||" };
                for (int arrayIndexCounter = 0;
                    arrayIndexCounter <= newMovementDetailPrimaryKey.Length - 1;
                    arrayIndexCounter++)
                {
                    newMovementDetailPrimaryKey[arrayIndexCounter].Split(primaryKeySepartor_2,
                        StringSplitOptions.RemoveEmptyEntries).
                        CopyTo(newRecordId_2, (arrayIndexCounter * 2));
                }

                if (newRecordId_2.Length < 2)
                {
                    //reportError
                    dtNextSynchRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    this.changeDataBaseTableData(dtNextSynchRecordInfo,
                                    "EM_MOVE_SYNCH_STATUS", "UPDATE", true);
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(stNextSynchRecordId,
                                stNextSynchRecordTableName + "line",
                                "No New Record Detail Id Found -" + stMainRecordId + " :-" +
                                 stNextSynchRecordId, true);
                    goto startDataSynchronisation;
                }

                foreach (string RecordKey in detailRecordPrimaryKeyColumnName)
                    if (!newRecordId_2.Contains(RecordKey))
                    {
                        //reportError
                        dtNextSynchRecordInfo.Rows[0]["STATUS"] = errorRecord;
                        this.changeDataBaseTableData(dtNextSynchRecordInfo,
                                        "EM_MOVE_SYNCH_STATUS", "UPDATE", true);
                        //LOG ERROR TO DAILY ERROR LOG
                        this.logSyncError(stNextSynchRecordId,
                                    stNextSynchRecordTableName + "line",
                                    "No New Record Detail Id Found -" + stMainRecordId + " :-" +
                                     stNextSynchRecordId, true);
                        goto startDataSynchronisation;
                    }

                int recordDetailIDLocatorIndex = -1;
                string recordDetailID = "";

                for (int currentDetailRecordDetail = 0;
                        currentDetailRecordDetail <= dtNextSynchDetailRecordDetailInfo.Rows.Count - 1;
                        currentDetailRecordDetail++)
                {
                    dtNextSynchDetailRecordDetailInfo.Rows[currentDetailRecordDetail][recordDetailTableDetailIdName] = nullValue;

                    if (recordDetailID != dtNextSynchDetailRecordDetailInfo.Rows[currentDetailRecordDetail][recordDetailTableIdName].ToString())
                    {
                        recordDetailIDLocatorIndex += 2;
                        recordDetailID =
                            dtNextSynchDetailRecordDetailInfo.Rows[currentDetailRecordDetail]
                            [recordDetailTableIdName].ToString();
                    }

                    dtNextSynchDetailRecordDetailInfo.Rows[currentDetailRecordDetail][recordDetailTableIdName] =
                            newRecordId_2[recordDetailIDLocatorIndex];
                }

                this.changeDataBaseTableData(dtNextSynchDetailRecordDetailInfo, stDeatilRecordDetailTableName, "INSERT", false);

                if (this.compExecuteOnError)
                {
                    //reportError
                    dtNextSynchRecordInfo.Rows[0]["STATUS"] = errorRecord;
                    //LOG ERROR TO DAILY ERROR LOG
                    this.logSyncError(stNextSynchRecordId,
                                stDeatilRecordTableName,
                                "Unable To Insert " + stDeatilRecordTableName + " to Compiere - " + recordTableIdName + " :-" +
                                 stNextSynchRecordId, true);
                }
                else
                    dtNextSynchRecordInfo.Rows[0]["STATUS"] = changedRecord;
            }

            this.changeDataBaseTableData(dtNextSynchRecordInfo,
                                "EM_MOVE_SYNCH_STATUS", "UPDATE", true);
            
            goto startDataSynchronisation;
        }

        //Compiere table Info
        public DataTable getDUP_EM_DMLSEQUENCEinfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                        string sequenceNo, string tableName, changeType _changeType,
                        changeStatus status, bool nextNonSynchRecord,
                        bool structureOnly, string logicalConnector)
        {
            
            if (structureOnly)
                return this.getDBTableStructure("DUP_EM_DMLSEQUENCE", false);

            if (nextNonSynchRecord)
            {                
                string getMinimumSequenceId =
                    "SELECT MIN(SEQUENCENO)AS SEQUENCENO FROM DUP_EM_DMLSEQUENCE WHERE  STATUS = 'PENDING'";
                DataTable dtMinSequenceId = 
                    (DataTable)this.executeSqlOnCompiere (getMinimumSequenceId);
                if (this.checkIfTableContainesData(dtMinSequenceId))
                {
                    getMinimumSequenceId =
                        "SELECT * FROM DUP_EM_DMLSEQUENCE WHERE SEQUENCENO = " +
                                dtMinSequenceId.Rows[0]["SEQUENCENO"].ToString();
                    dtMinSequenceId =
                        (DataTable)this.executeSqlOnCompiere(getMinimumSequenceId);
                }
                return dtMinSequenceId;
            }

            string getRequestedTableInformation = "";
            

            string whereClause = "";

            if (sequenceNo != "")
                whereClause = whereClause + " SEQUENCENO = '" + sequenceNo + "'";

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
                                           "FROM DUP_EM_DMLSEQUENCE " + whereClause;

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
        
        //EasyMove Table info

        public DataTable getEM_MOVE_SYNCH_STATUSInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                        string RECORD_ID, string SYNCHSTATUS, bool nextNonSynchRecord,
                        bool structureOnly, string logicalConnector)
        {

            if (structureOnly)
                return this.getDBTableStructure("EM_MOVE_SYNCH_STATUS", true);

            if (nextNonSynchRecord)
            {
                string getMinimumSequenceId =
                    "SELECT MIN(`CHANGE_SEQ`) AS CHANGE_SEQ " +
                    "FROM `EM_MOVE_SYNCH_STATUS` " +
                    "WHERE  `STATUS` = 'PENDING' AND `RECORD_ID` IS NOT NULL";

                DataTable dtMinSequenceId =
                    (DataTable)this.executeSqlOnEsayMove(getMinimumSequenceId);
                if (this.checkIfTableContainesData(dtMinSequenceId))
                {
                    getMinimumSequenceId =
                        "SELECT * FROM `EM_MOVE_SYNCH_STATUS` " +
                        "WHERE `STATUS` = 'PENDING' AND `CHANGE_SEQ` = " +
                                dtMinSequenceId.Rows[0]["CHANGE_SEQ"].ToString();
                    dtMinSequenceId =
                        (DataTable)this.executeSqlOnEsayMove(getMinimumSequenceId);
                }
                return dtMinSequenceId;
            }

            string getRequestedTableInformation = "";


            string whereClause = "";

            if (RECORD_ID != "")
                whereClause = whereClause + " RECORD_ID = '" + RECORD_ID + "'";

            if (SYNCHSTATUS != "")
            {
                whereClause = whereClause + " " + logicalConnector +
                    " STATUS = " + SYNCHSTATUS;
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
                                           "FROM `EM_MOVE_SYNCH_STATUS` " + whereClause;

            return (DataTable)this.executeSqlOnEsayMove(getRequestedTableInformation);
        }

        public DataTable getEM_M_MOVEMENTInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_MOVEMENT_ID, string M_MOVEREQUEST_ID, string EM_STATION_ID, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("EM_M_MOVEMENT",true);
            }


            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (M_MOVEMENT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEMENT_ID` = " + M_MOVEMENT_ID;

            if (M_MOVEREQUEST_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEREQUEST_ID` = " + M_MOVEREQUEST_ID;

            if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + EM_STATION_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector,true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `EM_M_MOVEMENT` " + whereClause;

            return (DataTable)this.executeSqlOnEsayMove(getRequestedTableInformation);
        }

        public DataTable getEM_M_MOVEMENTLINEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_MOVEMENTLINE_ID, string M_MOVEMENT_ID, string M_MOVEREQUESTLINE_ID, string EM_STATION_ID,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("EM_M_MOVEMENTLINE",true);
            }


            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (M_MOVEMENTLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEMENTLINE_ID` = " + M_MOVEMENTLINE_ID;

            if (M_MOVEMENT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEMENT_ID` = " + M_MOVEMENT_ID;

            if (M_MOVEREQUESTLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEREQUESTLINE_ID` = " + M_MOVEREQUESTLINE_ID;

            if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + EM_STATION_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector,true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `EM_M_MOVEMENTLINE` " + whereClause;

            return (DataTable)this.executeSqlOnEsayMove(getRequestedTableInformation);
        }

        public DataTable getM_INOUTInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
             string M_INOUT_ID, string EM_STATION_ID, bool onlyActiveRecords,
             bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("M_INOUT",true);
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (M_INOUT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_INOUT_ID` = " + M_INOUT_ID;

            if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + EM_STATION_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `M_INOUT` " + whereClause;

            return (DataTable)this.executeSqlOnEsayMove(getRequestedTableInformation);
        }

        public DataTable getM_INOUTLINEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_INOUTLINE_ID, string M_INOUT_ID, string C_INVOICELINE_ID,
            string EM_STATION_ID, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("M_INOUTLINE",true);
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (M_INOUTLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_INOUTLINE_ID` = " + M_INOUTLINE_ID;

            if (M_INOUT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_INOUT_ID` = " + M_INOUT_ID;

            if (C_INVOICELINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_INVOICELINE_ID` = " + C_INVOICELINE_ID;

            if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + EM_STATION_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `M_INOUTLINE` " + whereClause;

            return (DataTable)this.executeSqlOnEsayMove(getRequestedTableInformation);
        }
        

        public DataTable getM_PRODUCTIONInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_PRODUCTION_ID, string EM_STATION_ID, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("M_PRODUCTION", true);
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (M_PRODUCTION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_PRODUCTION_ID` = " + M_PRODUCTION_ID;

            if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + EM_STATION_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `M_PRODUCTION` " + whereClause;

            return (DataTable)this.executeSqlOnEsayMove(getRequestedTableInformation);
        }

        public DataTable getM_PRODUCTIONPLANInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_PRODUCTIONPLAN_ID, string M_PRODUCTION_ID, string M_PRODUCT_ID,
            string EM_STATION_ID, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("M_PRODUCTIONPLAN", true);
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (M_PRODUCTIONPLAN_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_PRODUCTIONPLAN_ID` = " + M_PRODUCTIONPLAN_ID;

            if (M_PRODUCTION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_PRODUCTION_ID` = " + M_PRODUCTION_ID;

            if (M_PRODUCT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_PRODUCT_ID` = " + M_PRODUCT_ID;

            if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + EM_STATION_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `M_PRODUCTIONPLAN` " + whereClause;

            return (DataTable)this.executeSqlOnEsayMove(getRequestedTableInformation);
        }

        public DataTable getM_PRODUCTIONLINEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_PRODUCTIONLINE_ID, string M_PRODUCTIONPLAN_ID, string M_PRODUCT_ID,
            string EM_STATION_ID, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDBTableStructure("M_PRODUCTIONLINE", true);
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (M_PRODUCTIONLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_PRODUCTIONLINE_ID` = " + M_PRODUCTIONLINE_ID;

            if (M_PRODUCTIONPLAN_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_PRODUCTIONPLAN_ID` = " + M_PRODUCTIONPLAN_ID;

            if (M_PRODUCT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_PRODUCT_ID` = " + M_PRODUCT_ID;

            if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + EM_STATION_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector, true);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `M_PRODUCTIONLINE` " + whereClause;

            return (DataTable)this.executeSqlOnEsayMove(getRequestedTableInformation);
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
            string tableNameToChangeData, string dmlType, bool isEasyMove)
        {
            string[] primaryKeysForNewInsertion =
                new string[dataToEffectTheChange.Rows.Count];

            if (primaryKeysForNewInsertion.Length > 0)
                primaryKeysForNewInsertion[0] = "";

            if (!this.checkIfTableContainesData(dataToEffectTheChange))
                return primaryKeysForNewInsertion;

            DataTable structureOfTableToChangeData = 
                this.getDBTableStructure(tableNameToChangeData,isEasyMove);

            if (structureOfTableToChangeData == null)
                return primaryKeysForNewInsertion;

            if (structureOfTableToChangeData.Columns.Count < 1)
                return primaryKeysForNewInsertion;

            string[] tablePrimaryKeys;

            if (isEasyMove)
            {
                tablePrimaryKeys = 
                    this.getEasyMoveDBTablePrimaryKey(tableNameToChangeData);
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
                    this.changeDataBaseTableData(newDataTable, tableNameToChangeData, dmlType,isEasyMove);

                int numberOfResult = resultTablePrimarykey1.Length;
                while (numberOfResult > 0)
                {
                    dataToEffectTheChange.Rows.RemoveAt(0);
                    numberOfResult--;
                }
                string[] resultTablePrimarykey2 =
                   this.changeDataBaseTableData(dataToEffectTheChange, tableNameToChangeData, dmlType,isEasyMove);

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
            if (!isEasyMove)
            {
                foreach (string primaryKey in tablePrimaryKeys)
                    if (dataToEffectTheChange.Rows[0][primaryKey].ToString() == "")
                    {
                        nextTablePrimaryKey = 
                            this.getNextSequenceId(tableNameToChangeData, "", "", 
                                                    true,triaStateBool.yes, isEasyMove);
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
            if(isEasyMove)
                DateFormat = "yyyy-MM-dd HH-mm-ss";
            else
                DateFormat = "dd-MMM-yyyy";

            dmlStatementForTable =
                this.DMLScriptCreator(tableNameToChangeData, tablePrimaryKeys,
                this.removeEmptyColumnFromRow(dataToEffectTheChange), 0, dmlType.ToUpper());

            //Execute.

            if (dmlStatementForTable != "")
            {
                if (isEasyMove)
                    this.executeSqlOnEsayMove(dmlStatementForTable);
                else
                    this.executeSqlOnCompiere(dmlStatementForTable);
            }
            if (tableNameToChangeData == "M_MOVEMENTLINE" || tableNameToChangeData == "M_INOUTLINE" ||
                tableNameToChangeData == "M_PRODUCTIONPLAN" || tableNameToChangeData == "M_PRODUCTIONLINE")
            {
                this.recordNumberOfNewRecordChange(tableNameToChangeData, dmlType, true);
            }
            
            //The return Array Format is arrayIndex[0]=|primaryKeyName1forRowOne<("theNewPrimaryKey")>|| ...
            //primaryKeyName2forRowOne<("theNewPrimaryKey")>|| ...,
            //arrayIndex[1]=|primaryKeyName1forRow2<("theNewPrimaryKey")>||
            //primaryKeyName2forRow2<("theNewPrimaryKey")>||...
            return primaryKeysForNewInsertion;
        }
        
    }
}


        