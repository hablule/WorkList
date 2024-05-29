using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;



namespace EasyMove
{    
    class dataBuilder
    {

        public string AD_CLIENT_ID = "1000000";
        public string CREATED = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
        public string CREATEDBY = "1000002";
        public string UPDATED = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
        public string UPDATEDBY = "1000002";
        public string fieldSeparator = "`";
        
        public bool recordStatusUpdate = true;
        //private bool esayMoveExecuteOnError = false;

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
                        columnCounter >= 0 && tableContainsData == false;
                        columnCounter--)
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
                            trsTime.ToString("yyyy-MM-dd HH-mm-ss") +
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
                    + " (" + fieldNames + ") VALUES (" + values + ");";
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
                            trsTime.ToString("yyyy-MM-dd HH-mm-ss") +
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
                        theValue = theValue.Replace(";", "';");
                        theValue = theValue.Replace("/", "/");
                        theValue = theValue.Replace("\\", "\\\\");

                        values += fieldSeparator + dt.Columns[i].Caption.ToString() +
                            fieldSeparator + " = " + delimitingApostrophe + theValue +
                            delimitingApostrophe + theComma;
                    }

                }
                dmlCommand = "UPDATE " + TableName +
                    " SET " + values + primaryColIDCondition + ";";

                ///////////
            }
            else if (DmlType == "DELETE")
            {
                dmlCommand = "DELETE FROM " + TableName + primaryColIDCondition + ";";
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
                
        public void writeCommandToFile(string dmlCommand)
        {
            string filePath = @"C:\pos-compiere integration\dmlDir\";
            string fileName = "";
            string getFileWithSpace = "Select FileName From FileSize" +
                " where ScripteNo < 1200";
            DataTable dt = new DataTable();
            
            dt = (DataTable)this.executeSqlOnEasyMove(getFileWithSpace);
            if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() != "")
            {
                fileName = (string)dt.Rows[0][0];
                filePath += fileName;
            }
            else
            {
                string getNextFileNumber = "Select count(FileName) From FileSize";
                Int32 newFileNo = Convert.ToInt32(((DataTable)this.executeSqlOnEasyMove(getNextFileNumber)).Rows[0][0]) + 1;
                string createNextFileNumber = "Insert into FileSize " +
                    "(FileName,ScripteNo) values ('LogSync_" +
                    "" + newFileNo.ToString() + ".sql',0)";
                this.executeSqlOnEasyMove(createNextFileNumber);
                fileName = "LogSync_" + newFileNo + ".sql";
                filePath += fileName;
            }
            /////
            this.writeToFile(dmlCommand, filePath);

            string theFilesize = 
                "select ScripteNo "+
                " From FileSize where " +
                " FileName = '" + fileName + "'";

            DataTable dt3 = new DataTable();
            dt3 = (DataTable)this.executeSqlOnEasyMove(theFilesize);
            Int32 fileNo = Convert.ToInt32(dt3.Rows[0][0]) + 1;
            string dmlIncreaseFileWriteSize = 
                "Update FileSize "+
                " set ScripteNo = " + fileNo.ToString() + 
                " Where FileName = '" + fileName + "'";
            this.executeSqlOnEasyMove(dmlIncreaseFileWriteSize);
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
                case "posSCRIPT":
                    filePath = dbSettingInformationHandler.ScriptDirectory;
                    extension = ".srp";
                    break;
                case "posWARINING":
                    filePath = dbSettingInformationHandler.WarningDirectory;
                    extension = ".wrn";
                    break;
                case "posERROR":
                    filePath = dbSettingInformationHandler.ErrorDirectory;
                    extension = ".err";
                    break;
                default:
                    filePath = @"//...//emergencyLog//";
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

        public object executeSqlOnEasyMove(string sqlCommand)
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
            //this.esayMoveExecuteOnError = false;

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
                                continue;
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
            string theLikeConnector = "%";
            
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

                        if (_criteriaTable.Rows[rowCounter]["Criterion"].ToString().ToUpperInvariant() != "LIKE")
                            theLikeConnector = "";
                        else
                        {
                            delimApostrophy = "'";
                            theLikeConnector = "%";
                        }

                        theCriteriaClase = theCriteriaClase + 
                            "`" + _criteriaTable.Rows[rowCounter]["Field"].ToString().ToUpperInvariant() + "`" +
                            " " + _criteriaTable.Rows[rowCounter]["Criterion"].ToString() +
                            " " + delimApostrophy + theLikeConnector +
                            _criteriaTable.Rows[rowCounter]["Value"].ToString().Replace("'", "''") + theLikeConnector +
                            delimApostrophy;
                    }
                    if ((rowCounter+1) <= _criteriaTable.Rows.Count-1)
                        theCriteriaClase = theCriteriaClase + " " + _criteriaLogicalConnector + " ";
                }

                theCriteriaClase = theCriteriaClase + ")";
            return theCriteriaClase;
        }


        public string[] getEasyMoveDBTablePrimaryKey(string tableName)
        {
            string[] primarykeys = { "" };
            if (tableName == "EM_AD_CLIENT")
            { primarykeys = new string[] { "AD_CLIENT_ID" }; }
            else if (tableName == "EM_AD_ORG")
            { primarykeys = new string[] { "AD_ORG_ID" }; }
            else if (tableName == "EM_AD_USER")
            { primarykeys = new string[] { "AD_USER_ID" }; }
            else if (tableName == "EM_AD_USER_ORGACCESS")
            { primarykeys = new string[] { "AD_ORG_ID", "AD_USER_ID" }; }
            else if (tableName == "EM_C_DOCTYPE")
            { primarykeys = new string[] { "C_DOCTYPE_ID" }; }
            else if (tableName == "EM_C_UOM")
            { primarykeys = new string[] { "C_UOM_ID" }; }
            else if (tableName == "EM_M_PRODUCT_CATEGORY")
            { primarykeys = new string[] { "M_PRODUCT_CATEGORY_ID" }; }
            else if (tableName == "EM_M_PRODUCT")
            { primarykeys = new string[] { "M_PRODUCT_ID" }; }
            else if (tableName == "EM_M_WAREHOUSE")
            { primarykeys = new string[] { "M_WAREHOUSE_ID" }; }
            else if (tableName == "EM_AD_USER_WAREHOUSE_ACCESS")
            { primarykeys = new string[] { "AD_USER_ID", "M_WAREHOUSE_ID" }; }
            else if (tableName == "EM_M_LOCATOR")
            { primarykeys = new string[] { "M_LOCATOR_ID" }; }
            else if (tableName == "EM_M_STORAGE")
            { primarykeys = new string[] { "M_PRODUCT_ID","M_LOCATOR_ID","M_ATTRIBUTESETINSTANCE_ID" }; }           
            else if (tableName == "EM_AD_SEQUENCE")
            { primarykeys = new string[] { "AD_SEQUENCE_ID", "EM_STATION_ID" }; }
            else if (tableName == "EM_ROLE")
            { primarykeys = new string[] { "EM_ROLE_ID" }; }
            else if (tableName == "EM_USER_ROLE")
            { primarykeys = new string[] { "EM_ROLE_ID", "EM_AD_USER_ID" }; }
            else if (tableName == "EM_PROCESS_ACCESS")
            { primarykeys = new string[] { "AD_USER_ID", "M_WAREHOUSE_ID", "EM_STATION_ID", }; }
            else if (tableName == "EM_USER_STATIONACCESS")
            { primarykeys = new string[] { "AD_USER_ID", "EM_STATION_ID" }; }
            else if (tableName == "EM_STATION")
            { primarykeys = new string[] { "EM_STATION_ID" }; }
            else if (tableName == "EM_MOVE_STATUS")
            { primarykeys = new string[] { "EM_MOVE_STATUS_ID" }; }
            else if (tableName == "EM_M_MOVEREQUEST")
            { primarykeys = new string[] { "M_MOVEREQUEST_ID" }; }
            else if (tableName == "EM_M_MOVEREQUESTLINE")
            { primarykeys = new string[] { "M_MOVEREQUESTLINE_ID" }; }
            else if (tableName == "EM_M_MOVEMENT")
            { primarykeys = new string[] { "M_MOVEMENT_ID" }; }
            else if (tableName == "EM_M_MOVEMENTLINE")
            { primarykeys = new string[] { "M_MOVEMENTLINE_ID" }; }
            else if (tableName == "EM_M_MOVEMENTDISPUTE")
            { primarykeys = new string[] { "M_MOVEMENTDISPUTE_ID" }; }
            else if (tableName == "EM_M_MOVEMENTLINEDISPUTE")
            { primarykeys = new string[] { "M_MOVEMENTLINEDISPUTE_ID" }; }
            else if (tableName == "EM_PRINTJOB")
            { primarykeys = new string[] { "EM_PRINTJOB_ID" }; }
            else if (tableName == "M_MOVEORDER")
            { primarykeys = new string[] { "M_MOVEORDER_ID" }; }
            else if (tableName == "M_MOVEORDERLINE")
            { primarykeys = new string[] { "M_MOVEORDERLINE_ID" }; }
            else if (tableName == "M_INOUT")
            { primarykeys = new string[] { "M_INOUT_ID" }; }
            else if (tableName == "M_INOUTLINE")
            { primarykeys = new string[] { "M_INOUTLINE_ID" }; }
            else if (tableName == "C_BPARTNER")
            { primarykeys = new string[] { "C_BPARTNER_ID" }; }
            else if (tableName == "INVOICEDETAIL")
            { primarykeys = new string[] { "C_INVOICELINE_ID" }; }
            else if (tableName == "M_PRODUCTION")
            { primarykeys = new string[] { "M_PRODUCTION_ID" }; }
            else if (tableName == "M_PRODUCTIONPLAN")
            { primarykeys = new string[] { "M_PRODUCTIONPLAN_ID" }; }
            else if (tableName == "M_PRODUCTIONLINE")
            { primarykeys = new string[] { "M_PRODUCTIONLINE_ID" }; }
            else if (tableName == "M_PRODUCT_BOM")
            { primarykeys = new string[] { "M_PRODUCT_BOM_ID" }; }
            else if (tableName == "SALESORDERDETAIL")
            { primarykeys = new string[] { "C_ORDERLINE_ID" }; }
            else if (tableName == "V_SALESORDERDETAIL")
            { primarykeys = new string[] { "C_ORDERLINE_ID" }; }                
            else if (tableName == "UTL_SETTINGS")
            { primarykeys = new string[] { "UTL_SETTINGS_ID" }; }
            else if (tableName == "M_MATCHINV")
            { primarykeys = new string[] { "M_MATCHINV_ID" }; }
            else if (tableName == "M_BOM_CHANGE")
            { primarykeys = new string[] { "M_BOM_CHANGE_ID" }; }
            else if (tableName == "M_BOM_CHANGE_LINE")
            { primarykeys = new string[] { "M_BOM_CHANGE_LINE_ID" }; }
            else if (tableName == "M_BOM_CAHNGE_ORDER")
            { primarykeys = new string[] { "M_BOM_CAHNGE_ORDER_ID" }; }
            else if (tableName == "EM_AD_USER_ROLES")
            { primarykeys = new string[] { "AD_ROLE_ID", "AD_USER_ID" }; }
            
            
            return primarykeys;
        }
        
        private DataTable getDataTableStructure(string tableName)
        {

            string[] Tableprimarykeys = this.getEasyMoveDBTablePrimaryKey(tableName);
            
            string theWhereClose = "Where 1 ";
            foreach (string primaryKey in Tableprimarykeys)
            {
                if (primaryKey != "")
                    theWhereClose = theWhereClose + " AND `" + primaryKey + "` = '0'";
            }
            string getStructureForTable = "SELECT *" +
                                          " FROM `" + tableName + "` " + theWhereClose;
            DataTable result = (DataTable)executeSqlOnEasyMove(getStructureForTable);
            result.Clear();
            return result;
        }

        public DataTable getEM_AD_CLIENTInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_CLIENT_ID, bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("EM_AD_CLIENT");
            }
           
            
            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (AD_CLIENT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `AD_CLIENT_ID` = " + AD_CLIENT_ID;

            whereClause = whereClause + 
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector,logicalConnector);
                        
            getRequestedTableInformation = "SELECT * " +
                                           "FROM `EM_AD_CLIENT` " + whereClause;
            
            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }

        public DataTable getEM_AD_ORGInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("EM_AD_ORG");
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


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector,logicalConnector);
                                    
            getRequestedTableInformation = "SELECT * " +
                                           "FROM `EM_AD_ORG` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }

        public DataTable getEM_AD_USER_ORGACCESSInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string AD_USER_ID, triStateBool readOnly,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("EM_AD_USER_ORGACCESS");
            }


            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (readOnly != triStateBool.ignor)
            {
                if (readOnly == triStateBool.yes)
                {
                    whereClause = whereClause + " " + logicalConnector + " `ISREADONLY` = 'Y'";
                }
                else
                    whereClause = whereClause + " " + logicalConnector + " `ISREADONLY` = 'N'";
            }

            if (AD_ORG_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `AD_ORG_ID` = " + AD_ORG_ID;

            if (AD_USER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `AD_USER_ID` = " + AD_USER_ID;

            whereClause = whereClause + 
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector,logicalConnector);
            
            getRequestedTableInformation = "SELECT * " +
                                           "FROM `EM_AD_USER_ORGACCESS` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }

        public DataTable getEM_AD_USER_ROLESInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_USER_ID, string AD_ROLE_ID, bool onlyActiveRecords, 
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("EM_AD_USER_ROLES");
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

            if (AD_ROLE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `AD_ROLE_ID` = " + AD_ROLE_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `EM_AD_USER_ROLES` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }

        public DataTable getEM_AD_USERInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_USER_ID, string UserName, string PassWord, bool onlyActiveRecords, 
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("EM_AD_USER");
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
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);
                        
            getRequestedTableInformation = "SELECT * " +
                                           "FROM `EM_AD_USER` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }

        public DataTable getEM_STATIONInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string EM_STATION_ID, bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("EM_STATION");
            }


            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + EM_STATION_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);
            
            getRequestedTableInformation = "SELECT * " +
                                           "FROM `EM_STATION` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }

        public DataTable getEM_PROCESS_ACCESSInfo(DataTable criteriaTable, 
            string criteriaTableLogicalConnector,
            string M_WAREHOUSE_ID, string AD_USER_ID, string AD_STATION_ID, 
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("EM_PROCESS_ACCESS");
            }


            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (M_WAREHOUSE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_WAREHOUSE_ID` = " + M_WAREHOUSE_ID;

            if (AD_USER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `AD_USER_ID` = " + AD_USER_ID;

            if (AD_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + AD_STATION_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `EM_PROCESS_ACCESS` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }

        public DataTable getC_BPARTNERInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_BPARTNER_ID, string NAME, 
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            
            return getC_BPARTNERInfo(criteriaTable, criteriaTableLogicalConnector,
                        C_BPARTNER_ID, NAME, triStateBool.ignor, triStateBool.ignor,
                        onlyActiveRecords, structureOnly, logicalConnector);
        }

        public DataTable getC_BPARTNERInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_BPARTNER_ID, string NAME, triStateBool ISVENDOR, triStateBool ISCUSTOMER,
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
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (C_BPARTNER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_BPARTNER_ID` = " + C_BPARTNER_ID;

            if (NAME != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `NAME` LIKE '%" + NAME + "%'";

            if (ISVENDOR != triStateBool.ignor)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " `ISVENDOR` = " + ((ISVENDOR == triStateBool.yes) ? "'Y'" : "'N'");
            }

            if (ISCUSTOMER != triStateBool.ignor)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " `ISCUSTOMER` = " + ((ISCUSTOMER == triStateBool.yes) ? "'Y'" : "'N'");
            }


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `C_BPARTNER` " + whereClause + " LIMIT 0 , 10 ";

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }


        public DataTable getEM_C_DOCTYPEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_DOCTYPE_ID, bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("EM_C_DOCTYPE");
            }
            
            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (C_DOCTYPE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_DOCTYPE_ID` = " + C_DOCTYPE_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);
                        
            getRequestedTableInformation = "SELECT * " +
                                           "FROM `EM_C_DOCTYPE` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }

        public DataTable getEM_C_UOMInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_UOM_ID, bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("EM_C_UOM");
            }
           

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (C_UOM_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_UOM_ID` = " + C_UOM_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);
                        
            getRequestedTableInformation = "SELECT * " +
                                           "FROM `EM_C_UOM` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }

        public DataTable getEM_M_PRODUCT_CATEGORYInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_PRODUCT_CATEGORY_ID, bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("EM_M_PRODUCT_CATEGORY");
            }
           

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (M_PRODUCT_CATEGORY_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_PRODUCT_CATEGORY_ID` = " + M_PRODUCT_CATEGORY_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);
                        
            getRequestedTableInformation = "SELECT * " +
                                           "FROM `EM_M_PRODUCT_CATEGORY` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }

        public DataTable getEM_M_PRODUCTInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_PRODUCT_ID, bool onlyActiveRecords, triStateBool isPurchased, triStateBool isMoved,
            bool structureOnly, string logicalConnector)
        {
            return this.getEM_M_PRODUCTInfo(criteriaTable, criteriaTableLogicalConnector,
                            M_PRODUCT_ID, onlyActiveRecords, isPurchased, isMoved,
                            triStateBool.ignor, structureOnly, logicalConnector);
        }

        public DataTable getEM_M_PRODUCTInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_PRODUCT_ID, bool onlyActiveRecords, triStateBool isPurchased,
            triStateBool isMoved, triStateBool isBOM,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("EM_M_PRODUCT");
            }
            
            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (M_PRODUCT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_PRODUCT_ID` = " + M_PRODUCT_ID;

            if (isPurchased != triStateBool.ignor)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " `ISPURCHASED` = " + ((isPurchased == triStateBool.yes) ? "'Y'" : "'N'");
            }

            if (isMoved != triStateBool.ignor)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " `ISMOVED` = " + ((isMoved == triStateBool.yes) ? "'Y'" : "'N'"); 
            }

            if (isBOM != triStateBool.ignor)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " `ISBOM` = " + ((isBOM == triStateBool.yes) ? "'Y'" : "'N'");
            }


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);
                        
            getRequestedTableInformation = "SELECT * " +
                                           "FROM `EM_M_PRODUCT` " + whereClause + " LIMIT 0 , 10 ";

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }

        public DataTable getM_PRODUCT_BOMInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_PRODUCT_BOM_ID, string M_PRODUCT_ID, string M_PRODUCTBOM_ID,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("M_PRODUCT_BOM");
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (M_PRODUCT_BOM_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_PRODUCT_BOM_ID` = " + M_PRODUCT_BOM_ID;

            if (M_PRODUCT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_PRODUCT_ID` = " + M_PRODUCT_ID;

            if (M_PRODUCTBOM_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_PRODUCTBOM_ID` = " + M_PRODUCTBOM_ID;
                        

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `M_PRODUCT_BOM` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }


        public DataTable getEM_M_WAREHOUSEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_WAREHOUSE_ID, bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("EM_M_WAREHOUSE");
            }
           

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (M_WAREHOUSE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_WAREHOUSE_ID` = " + M_WAREHOUSE_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);
                        
            getRequestedTableInformation = "SELECT * " +
                                           "FROM `EM_M_WAREHOUSE` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }

        public DataTable getEM_AD_USER_WAREHOUSE_LACCESSInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_WAREHOUSE_ID, string AD_USER_ID, triStateBool readOnly,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("EM_AD_USER_WAREHOUSE_ACCESS");
            }


            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (readOnly != triStateBool.ignor)
            {
                if (readOnly == triStateBool.yes)
                {
                    whereClause = whereClause + " " + logicalConnector + " `ISREADONLY` = 'Y'";
                }
                else
                    whereClause = whereClause + " " + logicalConnector + " `ISREADONLY` = 'N'";
            }


            if (M_WAREHOUSE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_WAREHOUSE_ID` = " + M_WAREHOUSE_ID;

            if (AD_USER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `AD_USER_ID` = " + AD_USER_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `EM_AD_USER_WAREHOUSE_ACCESS` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }

        public DataTable getEM_M_LOCATORInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_LOCATOR_ID, bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("EM_M_LOCATOR");
            }
            
            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (M_LOCATOR_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_LOCATOR_ID` = " + M_LOCATOR_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);
                        
            getRequestedTableInformation = "SELECT * " +
                                           "FROM `EM_M_LOCATOR` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }

        public DataTable getINVOICEDETAILInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_INVOICE_ID, string DOCUMENTNO, string C_BPARTNER_ID,
            string C_INVOICELINE_ID, string M_PRODUCT_ID,
            string EM_STATION_ID, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector,
            string queryClause, string queryClauseConnector)
        {
            return this.getINVOICEDETAILInfo(criteriaTable, criteriaTableLogicalConnector,
                            C_INVOICE_ID, DOCUMENTNO, C_BPARTNER_ID, C_INVOICELINE_ID, "",
                            "", M_PRODUCT_ID, EM_STATION_ID, onlyActiveRecords, 
                            structureOnly, logicalConnector, queryClause, queryClauseConnector);
        }

        public DataTable getINVOICEDETAILInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_INVOICE_ID, string DOCUMENTNO, string C_BPARTNER_ID,
            string C_INVOICELINE_ID, string C_ORDER_ID,
            string C_ORDERLINE_ID, string M_PRODUCT_ID,
            string EM_STATION_ID, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector,
            string queryClause, string queryClauseConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("INVOICEDETAIL");
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (C_INVOICE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_INVOICE_ID` = " + C_INVOICE_ID;

            if (DOCUMENTNO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `DOCUMENTNO` LIKE '%" + DOCUMENTNO + "%'";

            if (C_BPARTNER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_BPARTNER_ID` = " + C_BPARTNER_ID;

            if (C_INVOICELINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_INVOICELINE_ID` = " + C_INVOICELINE_ID;

            if (C_ORDER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_ORDER_ID` = " + C_ORDER_ID;

            if (C_ORDERLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_ORDERLINE_ID` = " + C_ORDERLINE_ID;


            if (M_PRODUCT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_PRODUCT_ID` = " + M_PRODUCT_ID;

            if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + EM_STATION_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            if (queryClause != "")
                whereClause = whereClause + " " + queryClauseConnector + " " + queryClause;

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `INVOICEDETAIL` " + whereClause + " LIMIT 0, 50";

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }

        public DataTable getM_INOUTInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_INOUT_ID, string EM_STATION_ID, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("M_INOUT");
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
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `M_INOUT_ID` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }

        public DataTable getM_INOUTLINEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_INOUTLINE_ID, string M_INOUT_ID, string C_INVOICELINE_ID,
            string EM_STATION_ID, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("M_INOUTLINE");
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
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `M_INOUTLINE` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }

        public DataTable getM_MATCHINVInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_MATCHINV_ID, string M_INOUTLINE_ID, string C_INVOICELINE_ID,
            string EM_STATION_ID, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("M_MATCHINV");
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (M_MATCHINV_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MATCHINV_ID` = " + M_MATCHINV_ID;

            if (M_INOUTLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_INOUTLINE_ID` = " + M_INOUTLINE_ID;

            if (C_INVOICELINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_INVOICELINE_ID` = " + C_INVOICELINE_ID;

            if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + EM_STATION_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `M_MATCHINV` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }
        

        public DataTable getEM_M_MOVEREQUESTInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_MOVEREQUEST_ID, string EM_STATION_ID, bool onlyActiveRecords, 
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("EM_M_MOVEREQUEST");
            }
            
            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (M_MOVEREQUEST_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEREQUEST_ID` = " + M_MOVEREQUEST_ID;

            if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + EM_STATION_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);
            
            getRequestedTableInformation = "SELECT * " +
                                           "FROM `EM_M_MOVEREQUEST` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }

        public DataTable getEM_M_MOVEREQUESTLINEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector, 
            string M_MOVEREQUESTLINE_ID, string M_MOVEREQUEST_ID, string EM_STATION_ID, bool onlyActiveRecords, 
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("EM_M_MOVEREQUESTLINE");
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (M_MOVEREQUESTLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEREQUESTLINE_ID` = " + M_MOVEREQUESTLINE_ID;

            if (M_MOVEREQUEST_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEREQUEST_ID` = " + M_MOVEREQUEST_ID;

            if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + EM_STATION_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);
            
            getRequestedTableInformation = "SELECT * " +
                                           "FROM `EM_M_MOVEREQUESTLINE` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }
        
        public DataTable getM_MOVEORDERInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_MOVEORDER_ID, string M_MOVEREQUEST_ID, string EM_STATION_ID, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("M_MOVEORDER");
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (M_MOVEORDER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEORDER_ID` = " + M_MOVEORDER_ID;

            if (M_MOVEREQUEST_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEREQUEST_ID` = " + M_MOVEREQUEST_ID;

            if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + EM_STATION_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `M_MOVEORDER` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }

        public DataTable getM_MOVEORDERLINEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_MOVEORDERLINE_ID, string M_MOVEORDER_ID, string M_MOVEREQUESTLINE_ID,
            string EM_STATION_ID, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("M_MOVEORDERLINE");
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (M_MOVEORDERLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEORDERLINE_ID` = " + M_MOVEORDERLINE_ID;

            if (M_MOVEORDER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEORDER_ID` = " + M_MOVEORDER_ID;

            if (M_MOVEREQUESTLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEREQUESTLINE_ID` = " + M_MOVEREQUESTLINE_ID;
                        
            if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + EM_STATION_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `M_MOVEORDERLINE` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }


        public DataTable getEM_M_MOVEMENTInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_MOVEMENT_ID, string M_MOVEORDER_ID, string EM_STATION_ID, bool onlyActiveRecords, 
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("EM_M_MOVEMENT");
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

            if (M_MOVEORDER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEORDER_ID` = " + M_MOVEORDER_ID;

           if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + EM_STATION_ID;
            
           whereClause = whereClause +
               this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);
                        
            getRequestedTableInformation = "SELECT * " +
                                           "FROM `EM_M_MOVEMENT` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }

        public DataTable getEM_M_MOVEMENTLINEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_MOVEMENTLINE_ID, string M_MOVEMENT_ID, string M_MOVEORDERLINE_ID, string EM_STATION_ID, 
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("EM_M_MOVEMENTLINE");
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

            if (M_MOVEORDERLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEORDERLINE_ID` = " + M_MOVEORDERLINE_ID;

            if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + EM_STATION_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);
                        
            getRequestedTableInformation = "SELECT * " +
                                           "FROM `EM_M_MOVEMENTLINE` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }

        public DataTable getEM_M_MOVEMENTDISPUTEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_MOVEMENTDISPUTE_ID, string M_MOVEMENT_ID, string EM_STATION_ID, bool onlyActiveRecords, 
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("EM_M_MOVEMENTDISPUTE");
            }
           

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (M_MOVEMENTDISPUTE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEMENTDISPUTE_ID` = " + M_MOVEMENTDISPUTE_ID;

            if (M_MOVEMENT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEMENTDISPUTE_ID` = " + M_MOVEMENTDISPUTE_ID;

            if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEMENTDISPUTE_ID` = " + M_MOVEMENTDISPUTE_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);
                        
            getRequestedTableInformation = "SELECT * " +
                                           "FROM `EM_M_MOVEMENTDISPUTE` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }

        public DataTable getEM_M_MOVEMENTLINEDISPUTEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_MOVEMENTDISPUTE_ID, string M_MOVEMENTLINEDISPUTE_ID, string M_MOVEMENT_ID, 
            string M_MOVEMENTLINE_ID, string EM_STATION_ID, bool onlyActiveRecords, 
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("EM_M_MOVEMENTLINEDISPUTE");
            }
           

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (M_MOVEMENTDISPUTE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEMENTDISPUTE_ID` = " + M_MOVEMENTDISPUTE_ID;

            if (M_MOVEMENTLINEDISPUTE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEMENTLINEDISPUTE_ID` = " + M_MOVEMENTLINEDISPUTE_ID;

            if (M_MOVEMENT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEMENT_ID` = " + M_MOVEMENT_ID;

            if (M_MOVEMENTLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEMENTLINE_ID` = " + M_MOVEMENTLINE_ID;

            if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + EM_STATION_ID;
            
            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);
                        
            getRequestedTableInformation = "SELECT * " +
                                           "FROM `EM_M_MOVEMENTDISPUTE` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }


        public DataTable getM_PRODUCTIONInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_PRODUCTION_ID, string EM_STATION_ID, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("M_PRODUCTION");
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
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `M_PRODUCTION` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }

        public DataTable getM_PRODUCTIONPLANInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_PRODUCTIONPLAN_ID, string M_PRODUCTION_ID, string M_PRODUCT_ID,
            string EM_STATION_ID, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("M_PRODUCTIONPLAN");
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
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `M_PRODUCTIONPLAN` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }
        
        public DataTable getM_PRODUCTIONLINEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_PRODUCTIONLINE_ID, string M_PRODUCTIONPLAN_ID, string M_PRODUCT_ID,
            string EM_STATION_ID, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("M_PRODUCTIONLINE");
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
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `M_PRODUCTIONLINE` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }



        public DataTable getM_BOM_CHANGEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_BOM_CHANGE_ID, string M_PRODUCT_ID, string EM_STATION_ID, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("M_BOM_CHANGE");
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (M_BOM_CHANGE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_BOM_CHANGE_ID` = " + M_BOM_CHANGE_ID;
            
            if (M_PRODUCT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_PRODUCT_ID` = " + M_PRODUCT_ID;

            if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + EM_STATION_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `M_BOM_CHANGE` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }


        public DataTable getM_BOM_CHANGE_LINEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_BOM_CHANGE_LINE_ID, string M_BOM_CHANGE_ID, string M_PRODUCT_ID, 
            string EM_STATION_ID, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("M_BOM_CHANGE_LINE");
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (M_BOM_CHANGE_LINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_BOM_CHANGE_LINE_ID` = " + M_BOM_CHANGE_LINE_ID;

            if (M_BOM_CHANGE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_BOM_CHANGE_ID` = " + M_BOM_CHANGE_ID;

            if (M_PRODUCT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_PRODUCT_ID` = " + M_PRODUCT_ID;

            if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + EM_STATION_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `M_BOM_CHANGE_LINE` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }


        public DataTable getM_BOM_CAHNGE_ORDERInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_BOM_CAHNGE_ORDER_ID, string M_BOM_CHANGE_ID, string M_BOM_CHANGE_LINE_ID,
            string M_PRODUCT_ID, string M_BOM_PRODUCT_ID,
            string EM_STATION_ID, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("M_BOM_CAHNGE_ORDER");
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (M_BOM_CHANGE_LINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_BOM_CHANGE_LINE_ID` = " + M_BOM_CHANGE_LINE_ID;

            if (M_BOM_CHANGE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_BOM_CHANGE_ID` = " + M_BOM_CHANGE_ID;

            if (M_PRODUCT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_PRODUCT_ID` = " + M_PRODUCT_ID;

            if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + EM_STATION_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `M_BOM_CAHNGE_ORDER` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }



        public DataTable getEM_M_STORAGEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_PRODUCT_ID, string M_LOCATOR_ID, string M_ATTRIBUTESETINSTANCE_ID,
            decimal QTYONHAND, decimal QTYRESERVED, decimal QTYORDERED,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("EM_M_STORAGE");
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (M_PRODUCT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_PRODUCT_ID` = " + M_PRODUCT_ID;

            if (M_LOCATOR_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_LOCATOR_ID` = " + M_LOCATOR_ID;

            if (M_ATTRIBUTESETINSTANCE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_ATTRIBUTESETINSTANCE_ID` = " + M_ATTRIBUTESETINSTANCE_ID;
            
            whereClause = whereClause + " " + logicalConnector +
                    " `QTYONHAND` = " + QTYONHAND;
            
            whereClause = whereClause + " " + logicalConnector +
                    " `QTYRESERVED` = " + QTYRESERVED;

            whereClause = whereClause + " " + logicalConnector +
                    " `QTYORDERED` = " + QTYORDERED;
            
            
            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `EM_M_STORAGE` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }

        public DataTable getEM_M_STORAGEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_PRODUCT_ID, string M_LOCATOR_ID,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("EM_M_STORAGE");
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (M_PRODUCT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_PRODUCT_ID` = " + M_PRODUCT_ID;

            if (M_LOCATOR_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_LOCATOR_ID` = " + M_LOCATOR_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `EM_M_STORAGE` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }
        

        private string getEM_MOVE_STATUSInfo_SubProcedure(string fieldName, string fieldValue, 
            bool OnlyLatestValue, string connector)
        {
            string whereClause = "";
            if (OnlyLatestValue)
            {
                whereClause = " " + connector + " (`" + fieldName + "` = " + fieldValue +
                            " AND `CREATED` = (SELECT MAX(`CREATED`) " +
                                              "FROM `EM_MOVE_STATUS` " +
                                              "WHERE `" + fieldName + "` = " + fieldValue + "))";
            }
            else
                whereClause = " " + connector +
                        " `" + fieldName + "` = " + fieldValue;

            return whereClause;
        }

        private DataTable pickTheLatestMoveStatusRecord(DataTable statusInfo)
        {
            if (statusInfo.Rows[statusInfo.Rows.Count - 1]["M_MOVEMENT_ID"].ToString() != "")
            {
                for (int arrayCounter = 0; 
                    arrayCounter <= statusSequence.moveTransactionSequence.Length - 1
                    && statusInfo.Rows.Count > 1; arrayCounter++)
                {
                    for (int rowCounter = statusInfo.Rows.Count - 1; rowCounter >= 0; rowCounter--)
                    {
                        if (statusInfo.Rows[rowCounter]["STATUS"].ToString() ==
                            statusSequence.moveTransactionSequence[arrayCounter])
                        {
                            statusInfo.Rows.RemoveAt(rowCounter);
                        }
                    }
                }
            }
            else
            {
                for (int arrayCounter = 0;                
                    arrayCounter <= statusSequence.requestTransactionSequence.Length - 1                
                    && statusInfo.Rows.Count > 1; arrayCounter++)
                {
                    for (int rowCounter = statusInfo.Rows.Count - 1; rowCounter >= 0; rowCounter--)
                    {
                        if (statusInfo.Rows[rowCounter]["STATUS"].ToString() ==
                            statusSequence.requestTransactionSequence[arrayCounter])
                        {
                            statusInfo.Rows.RemoveAt(rowCounter);
                        }
                    }
                }
            }
            return statusInfo;
        }

        public DataTable getEM_MOVE_STATUSInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string EM_MOVE_STATUS_ID, string M_MOVEREQUEST_ID, string M_MOVEMENT_ID,
            string M_MOVEMENTDISPUTE_ID, string EM_STATION_ID, string status, 
            bool onlyLatestOfTheRecord, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("EM_MOVE_STATUS");

            }
            
            string whereClause = "WHERE 1";
                        
            if (EM_MOVE_STATUS_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_MOVE_STATUS_ID` = " + EM_MOVE_STATUS_ID;
            

            if (M_MOVEREQUEST_ID != "")
                whereClause = whereClause +
                    getEM_MOVE_STATUSInfo_SubProcedure("M_MOVEREQUEST_ID", M_MOVEREQUEST_ID,
                    onlyLatestOfTheRecord, logicalConnector);

            if (M_MOVEMENT_ID != "")
                whereClause = whereClause +
                    getEM_MOVE_STATUSInfo_SubProcedure("M_MOVEMENT_ID", M_MOVEMENT_ID,
                    onlyLatestOfTheRecord, logicalConnector);

            if (M_MOVEMENTDISPUTE_ID != "")
                whereClause = whereClause +
                    getEM_MOVE_STATUSInfo_SubProcedure("M_MOVEMENTDISPUTE_ID", M_MOVEMENTDISPUTE_ID,
                    onlyLatestOfTheRecord, logicalConnector);

            if (EM_STATION_ID != "")
                whereClause = whereClause +
                    getEM_MOVE_STATUSInfo_SubProcedure("EM_STATION_ID", EM_STATION_ID,
                    onlyLatestOfTheRecord, logicalConnector);
            
            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);
            
            getRequestedTableInformation = "SELECT * " +
                                           "FROM `EM_MOVE_STATUS` " + whereClause;

            DataTable dtResult = (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
            if (onlyLatestOfTheRecord && dtResult.Rows.Count > 1)
            {
                dtResult = this.pickTheLatestMoveStatusRecord(dtResult);
            }
            return dtResult;
        }

        public string getNextSequenceId(string Name, string EM_SEQUENCE_ID,string EM_STATION_ID, 
            string AD_ORG_ID, bool incrementToNextSequence)
        {
            string nextPrimaryKey = "";
            string preFix = "";
            string suffix = "";

            if (Name == "" && EM_SEQUENCE_ID == "")
                return "";
            if (EM_STATION_ID == "")
                EM_STATION_ID = generalResultInformation.Station;

            DataTable orgCriterion = new DataTable();
            if (AD_ORG_ID != "")
            { 
                businessRule moveBusinessRule = new businessRule();
                string [] organisationList = {AD_ORG_ID};
                orgCriterion = 
                    moveBusinessRule.buildOrganisationSelectionCriteria(organisationList,false);
            }

            DataTable sequenceRecord =
                this.getEM_SEQUENCEInfo(orgCriterion, "", EM_STATION_ID, EM_SEQUENCE_ID, 
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
                this.changeDataBaseTableData(sequenceRecord, "EM_AD_SEQUENCE", "Update");
            }
                        

            return preFix + nextPrimaryKey + suffix;
        }

        public DataTable getEM_SEQUENCEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string EM_STATION_ID, string EM_SEQUENCE_ID, string NAME, bool onlyActiveRecords,
             bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("EM_AD_SEQUENCE");
            }


            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + EM_STATION_ID;

            if (EM_SEQUENCE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `AD_SEQUENCE_ID` = " + EM_SEQUENCE_ID;

            if (NAME != "")
                whereClause = whereClause + " " + logicalConnector +
                    " UCASE(`NAME`) = '" + NAME.Replace("'", "''") + "'";
            

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `EM_AD_SEQUENCE` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }

        public DataTable getEM_PRINTJOBInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string EM_PRINTJOB_ID, string RECORDTABLENAME, string RECORD_ID, string EM_STATION_ID,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("EM_PRINTJOB");
            }

            string whereClause = "WHERE 1";
            
            if (EM_PRINTJOB_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_PRINTJOB_ID` = " + EM_PRINTJOB_ID;

            if (RECORDTABLENAME != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `RECORDTABLENAME` = '" + RECORDTABLENAME + "'";

            if (RECORD_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `RECORD_ID` = " + RECORD_ID;

            if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + EM_STATION_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `EM_PRINTJOB` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }

        public DataTable getUTL_SETTINGSInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string UTL_SETTINGS_ID, string ATTRIBUTE, string VALUE,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("UTL_SETTINGS");
            }

            string whereClause = "WHERE 1";

            if (UTL_SETTINGS_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `UTL_SETTINGS_ID` = " + UTL_SETTINGS_ID;

            if (ATTRIBUTE != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ATTRIBUTE` = '" + ATTRIBUTE + "'";

            if (VALUE != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `VALUE` = " + VALUE;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `UTL_SETTINGS` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
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
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `V_STOCK` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }

        public bool isStockCorrect()
        {
            string getRequestedTableInformation = "";

            getRequestedTableInformation = "SELECT M_PRODUCT_ID, M_LOCATOR_ID, SUM(QTYONHAND) " +
                                           "FROM V_STOCK " +
                                           "WHERE M_LOCATOR_ID IN (SELECT M_LOCATOR_ID FROM easymove.station_warehouse ) " +
                                           "GROUP BY M_PRODUCT_ID, M_LOCATOR_ID " +
                                           "HAVING SUM(QTYONHAND) < 0";

            return !this.checkIfTableContainesData((DataTable)executeSqlOnEasyMove(getRequestedTableInformation));
        }
        

        public DataTable getV_INOUTDETAILInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_INOUT_ID, string M_INOUTLINE_ID, string EM_STATION_ID,
            string C_INVOICELINE_ID, string DOCUMENTNO, 
            bool onlyActiveRecords, bool structureOnly, string logicalConnector,
            string queryClause, string queryClauseConnector)
        {
            return getV_INOUTDETAILInfo(criteriaTable, criteriaTableLogicalConnector,
                                M_INOUT_ID, M_INOUTLINE_ID, EM_STATION_ID, C_INVOICELINE_ID,
                                DOCUMENTNO, triStateBool.ignor, onlyActiveRecords, structureOnly,
                                logicalConnector, queryClause, queryClauseConnector);

        }

        public DataTable getV_INOUTDETAILInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_INOUT_ID, string M_INOUTLINE_ID, string EM_STATION_ID,
            string C_INVOICELINE_ID, string DOCUMENTNO, triStateBool ISSOTRX,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector,
            string queryClause, string queryClauseConnector)
        {
            string getRequestedTableInformation = "";

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

            if (M_INOUTLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_INOUTLINE_ID` = " + M_INOUTLINE_ID;

            if (C_INVOICELINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_INVOICELINE_ID` = " + C_INVOICELINE_ID;

            if (DOCUMENTNO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `DOCUMENTNO` LIKE '%" + DOCUMENTNO + "%'";

            if (ISSOTRX != triStateBool.ignor)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " `ISSOTRX` = " + ((ISSOTRX == triStateBool.yes) ? "'Y'" : "'N'");
            }


            if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + EM_STATION_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            if (queryClause != "")
                whereClause = whereClause + " " + queryClauseConnector + " " + queryClause;

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `V_INOUTDETAIL` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);

        }


        public DataTable getV_PRODUCTIONDETAILInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_PRODUCTION_ID, string M_PRODUCTIONPLAN_ID, string EM_STATION_ID,
            string M_PRODUCTIONLINE_ID, string NAME,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector,
            string queryClause, string queryClauseConnector)
        {
            string getRequestedTableInformation = "";

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

            if (M_PRODUCTIONPLAN_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEORDER_ID` = " + M_PRODUCTIONPLAN_ID;

            if (M_PRODUCTIONLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_PRODUCTIONPLAN_ID` = " + M_PRODUCTIONLINE_ID;

            
            if (NAME != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `NAME` LIKE '%" + NAME + "%'";

            
            if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + EM_STATION_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            if (queryClause != "")
                whereClause = whereClause + " " + queryClauseConnector + " " + queryClause;

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `V_PRODUCTIONDETAIL` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);

        }


        public DataTable getV_MOVEMENTDETAILInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_MOVEMENT_ID, string M_MOVEORDER_ID, string EM_STATION_ID,
            string M_MOVEMENTLINE_ID, string M_MOVEORDERLINE_ID,
            string DOCUMENTNO, string MOVESTATUS,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector,
            string queryClause, string queryClauseConnector)
        {
            string getRequestedTableInformation = "";

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

            if (M_MOVEORDER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEORDER_ID` = " + M_MOVEORDER_ID;
                        
            if (M_MOVEMENTLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEMENTLINE_ID` = " + M_MOVEMENTLINE_ID;

            if (M_MOVEORDERLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEORDERLINE_ID` = " + M_MOVEORDERLINE_ID;

            if (DOCUMENTNO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `DOCUMENTNO` LIKE '%" + DOCUMENTNO + "%'";

            if (MOVESTATUS != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `MOVESTATUS` = '" + MOVESTATUS + "'";


            if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + EM_STATION_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            if (queryClause != "")
                whereClause = whereClause + " " + queryClauseConnector + " " + queryClause;

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `V_MOVEMENTDETAIL` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);

        }

        public DataTable getV_MOVEORDERDETAILInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_MOVEORDER_ID, string M_MOVEORDERLINE_ID, string EM_STATION_ID,
            string M_MOVEREQUEST_ID, string M_MOVEREQUESTLINE_ID,
            string DOCUMENTNO, string ORDERSTATUS,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector,
            string queryClause, string queryClauseConnector)
        {
            string getRequestedTableInformation = "";

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (M_MOVEREQUEST_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEREQUEST_ID` = " + M_MOVEREQUEST_ID;

            if (M_MOVEORDER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEORDER_ID` = " + M_MOVEORDER_ID;

            if (M_MOVEREQUESTLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEREQUESTLINE_ID` = " + M_MOVEREQUESTLINE_ID;

            if (M_MOVEORDERLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEORDERLINE_ID` = " + M_MOVEORDERLINE_ID;

            if (DOCUMENTNO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `DOCUMENTNO` LIKE '%" + DOCUMENTNO + "%'";

            if (ORDERSTATUS != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `ORDERSTATUS` = '" + ORDERSTATUS + "'";


            if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + EM_STATION_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            if (queryClause != "")
                whereClause = whereClause + " " + queryClauseConnector + " " + queryClause;

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `V_MOVEORDERDETAIL` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);

        }
        
        public DataTable getV_REQUESTDETAILInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_MOVEREQUEST_ID, string EM_STATION_ID,
            string M_MOVEREQUESTLINE_ID, string DOCUMENTNO, string REQUESTSTATUS,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector,
            string queryClause, string queryClauseConnector)
        {
            string getRequestedTableInformation = "";

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";
            
            if (M_MOVEREQUEST_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEREQUEST_ID` = " + M_MOVEREQUEST_ID;

            if (M_MOVEREQUESTLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_MOVEREQUESTLINE_ID` = " + M_MOVEREQUESTLINE_ID;

            if (DOCUMENTNO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `DOCUMENTNO` LIKE '%" + DOCUMENTNO + "%'";

            if (REQUESTSTATUS != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `REQUESTSTATUS` = '" + REQUESTSTATUS + "'";

            if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + EM_STATION_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            if(queryClause != "")
                whereClause = whereClause + " " + queryClauseConnector + " " + queryClause;

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `V_REQUESTDETAIL` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);

        }
        
        public DataTable getV_SALESORDERDETAILInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_ORDER_ID, string C_BPARTNER_ID, string DOCUMENTNO,
            string DELIVERYORDERNO, string C_ORDERLINE_ID,
            string M_WAREHOUSE_ID, string M_PRODUCT_ID,
            string EM_STATION_ID, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector,
            string queryClause, string queryClauseConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("V_SALESORDERDETAIL");
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (C_ORDER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_ORDER_ID` = " + C_ORDER_ID;

            if (C_BPARTNER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_BPARTNER_ID` = " + C_BPARTNER_ID;

            if (DOCUMENTNO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `DOCUMENTNO` LIKE '%" + DOCUMENTNO + "%'";

            if (DELIVERYORDERNO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `DELIVERYORDERNO` LIKE '%" + DELIVERYORDERNO + "%'";

            if (C_ORDERLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_ORDERLINE_ID` = " + C_ORDERLINE_ID;

            if (M_WAREHOUSE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_WAREHOUSE_ID` = " + M_WAREHOUSE_ID;

            if (M_PRODUCT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_PRODUCT_ID` = " + M_PRODUCT_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            if (queryClause != "")
                whereClause = whereClause + " " + queryClauseConnector + " " + queryClause;

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `V_SALESORDERDETAIL` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }


        public DataTable getV_SALESORDERDETAIL_SUMMARYInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_ORDER_ID, string C_BPARTNER_ID, string DOCUMENTNO,
            bool onlyActiveRecords,
            bool structureOnly, string logicalConnector,
            string queryClause, string queryClauseConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("V_SALESORDERDETAIL");
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (C_ORDER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_ORDER_ID` = " + C_ORDER_ID;

            if (C_BPARTNER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_BPARTNER_ID` = " + C_BPARTNER_ID;

            if (DOCUMENTNO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `DOCUMENTNO` LIKE '%" + DOCUMENTNO + "%'";

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            if (queryClause != "")
                whereClause = whereClause + " " + queryClauseConnector + " " + queryClause;

            getRequestedTableInformation =
                    "SELECT DISTINCT C_ORDER_ID, `DOCUMENTNO`, " +
                        "`DATEORDERED` , `CUSTOMER` " +
                     "FROM `V_salesorderdetail` " + whereClause + " LIMIT 0, 50";

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }


        public DataTable getV_SALESORDERDELIVERYORDER_SUMMARYInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_ORDER_ID, string C_BPARTNER_ID, string DELIVERYORDERNO,
            bool onlyActiveRecords,
            bool structureOnly, string logicalConnector,
            string queryClause, string queryClauseConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("V_SALESORDERDETAIL");
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (C_ORDER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_ORDER_ID` = " + C_ORDER_ID;

            if (C_BPARTNER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_BPARTNER_ID` = " + C_BPARTNER_ID;

            if (DELIVERYORDERNO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `DELIVERYORDERNO` LIKE '%" + DELIVERYORDERNO + "%'";

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            if (queryClause != "")
                whereClause = whereClause + " " + queryClauseConnector + " " + queryClause;

            getRequestedTableInformation =
                    "SELECT DISTINCT `C_ORDER_ID`, `DELIVERYORDERNO`, " +
                        "`DATEORDERED` , `CUSTOMER` " +
                     "FROM `V_salesorderdetail` " + whereClause + " LIMIT 0, 50";

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);
        }


        public DataTable getV_UNMATCHEDRECEIPTSInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_INOUT_ID, string EM_STATION_ID, string C_BPARTNER_ID, 
            string M_INOUTLINE_ID, string M_LOCATOR_ID, string M_PRODUCT_ID,
            string DOCUMENTNO, 
            bool onlyActiveRecords, bool structureOnly, string logicalConnector,
            string queryClause, string queryClauseConnector)
        {
            string getRequestedTableInformation = "";

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

            if (C_BPARTNER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_BPARTNER_ID` = " + C_BPARTNER_ID;

            if (M_INOUTLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_INOUTLINE_ID` = " + M_INOUTLINE_ID;
            
            if (M_LOCATOR_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_LOCATOR_ID` = '" + M_LOCATOR_ID + "'";

            if (M_PRODUCT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_PRODUCT_ID` = '" + M_PRODUCT_ID + "'";


            if (DOCUMENTNO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `DOCUMENTNO` LIKE '%" + DOCUMENTNO + "%'";

            if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + EM_STATION_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            if (queryClause != "")
                whereClause = whereClause + " " + queryClauseConnector + " " + queryClause;

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `V_UNMATCHEDRECEIPTS` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);

        }


        public DataTable getV_UNMATCHEDINVOICEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_INVOICE_ID, string C_BPARTNER_ID,
            string C_INVOICELINE_ID, string M_PRODUCT_ID,
            string DOCUMENTNO,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector,
            string queryClause, string queryClauseConnector)
        {
            string getRequestedTableInformation = "";

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (C_INVOICE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_INVOICE_ID` = " + C_INVOICE_ID;

            if (C_BPARTNER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_BPARTNER_ID` = " + C_BPARTNER_ID;

            if (C_INVOICELINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `C_INVOICELINE_ID` = " + C_INVOICELINE_ID;
                        
            if (M_PRODUCT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_PRODUCT_ID` = '" + M_PRODUCT_ID + "'";


            if (DOCUMENTNO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `DOCUMENTNO` LIKE '%" + DOCUMENTNO + "%'";            

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            if (queryClause != "")
                whereClause = whereClause + " " + queryClauseConnector + " " + queryClause;

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `V_UNMATCHEDINVOICE` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);

        }


        public DataTable getV_BOMCHANGEDETAILInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_BOM_CHANGE_ID, string M_BOM_CHANGE_LINE_ID, string EM_STATION_ID,
            string M_PRODUCT_ID, string M_BOM_PRODUCT_ID, string DOCUMENTNO, triStateBool ISAPPROVED,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector,
            string queryClause, string queryClauseConnector)
        {
            string getRequestedTableInformation = "";

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE `ISACTIVE` = 'Y'";
            }
            else
                whereClause = "WHERE (`ISACTIVE` = 'Y' || `ISACTIVE` = 'N')";

            if (M_BOM_CHANGE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_BOM_CHANGE_ID` = " + M_BOM_CHANGE_ID;

            if (M_BOM_CHANGE_LINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_BOM_CHANGE_LINE_ID` = " + M_BOM_CHANGE_LINE_ID;

            if (M_PRODUCT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_PRODUCT_ID` = " + M_PRODUCT_ID;

            if (M_BOM_PRODUCT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `M_BOM_PRODUCT_ID` = " + M_BOM_PRODUCT_ID;

            if (DOCUMENTNO != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `DOCUMENTNO` LIKE '%" + DOCUMENTNO + "%'";

            if (ISAPPROVED != triStateBool.ignor)
            {
                whereClause = whereClause + " " + logicalConnector +
                    " `ISAPPROVED` = " + ((ISAPPROVED == triStateBool.yes) ? "'Y'" : "'N'");
            }


            if (EM_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " `EM_STATION_ID` = " + EM_STATION_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            if (queryClause != "")
                whereClause = whereClause + " " + queryClauseConnector + " " + queryClause;

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `V_BOMCHANGEDETAIL` " + whereClause;

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);

        }



        public string [] changeDataBaseTableData(DataTable dataToEffectTheChange, 
            string tableNameToChangeData, string dmlType)
        {
            string[] primaryKeysForNewInsertion = 
                new string[dataToEffectTheChange.Rows.Count];

            if (primaryKeysForNewInsertion.Length > 0)
                primaryKeysForNewInsertion[0] = "";

            if(!this.checkIfTableContainesData(dataToEffectTheChange))
                return primaryKeysForNewInsertion;
            DataTable structureOfTableToChangeData = this.getDataTableStructure(tableNameToChangeData);
            if (structureOfTableToChangeData == null)
                return primaryKeysForNewInsertion;

            if (structureOfTableToChangeData.Columns.Count < 1)
                return primaryKeysForNewInsertion;


            string[] tablePrimaryKeys = this.getEasyMoveDBTablePrimaryKey(tableNameToChangeData);
            foreach (string primaryKey in tablePrimaryKeys)
                if (!dataToEffectTheChange.Columns.Contains(primaryKey))
                    return primaryKeysForNewInsertion;

            //Check if the given table has more than one row
                //.. if it does 
                // 1. Elemenate the last row from the copy table of 
                    //the given table and re-call function with the copyed one
                // 2. then delete as much rows as the returned number of array elements
                    // ....from the original table and re-call function.
            if(dataToEffectTheChange.Rows.Count>1)
            {
                DataTable newDataTable = dataToEffectTheChange.Copy();
                newDataTable.Rows.RemoveAt(newDataTable.Rows.Count - 1);
                string[] resultTablePrimarykey1 = 
                    this.changeDataBaseTableData(newDataTable,tableNameToChangeData,dmlType);

                int numberOfResult = resultTablePrimarykey1.Length;
                while (numberOfResult > 0)
                {
                    dataToEffectTheChange.Rows.RemoveAt(0);
                    numberOfResult--;
                }
                string[] resultTablePrimarykey2 =
                   this.changeDataBaseTableData(dataToEffectTheChange, tableNameToChangeData, dmlType);
                
                Array.Copy(resultTablePrimarykey1, 0,
                    primaryKeysForNewInsertion,0,
                    resultTablePrimarykey1.Length);

                Array.Copy(resultTablePrimarykey2,0,
                    primaryKeysForNewInsertion,resultTablePrimarykey1.Length,
                    resultTablePrimarykey2.Length);

                return primaryKeysForNewInsertion;
            }

            //Check if the Modifyied Table primary key fields contain data.
            //... if they do not, Generate New Primary key.
            string nextTablePrimaryKey = "";
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
                        return primaryKeysForNewInsertion;
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
                dataToEffectTheChange.Columns.Add("UPDATED",Type.GetType("System.DateTime"));

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
            dmlStatementForTable =
                this.DMLScriptCreator(tableNameToChangeData, tablePrimaryKeys,
                this.removeEmptyColumnFromRow(dataToEffectTheChange), 0, dmlType.ToUpper());

                    //Execute.
            
            if (dmlStatementForTable != "")
                this.executeSqlOnEasyMove(dmlStatementForTable);

            if ((tableNameToChangeData == "EM_M_MOVEMENT" ||
                tableNameToChangeData == "EM_M_MOVEREQUEST" ||
                tableNameToChangeData == "M_MOVEORDER") &&
                this.recordStatusUpdate)
            {
                string tableStatus = "";
                string talbeId = "";

                if (tableNameToChangeData == "EM_M_MOVEMENT")
                {
                    tableStatus = "MOVESTATUS";
                    talbeId = "M_MOVEMENT_ID";
                }
                else if (tableNameToChangeData == "EM_M_MOVEREQUEST")
                {
                    tableStatus = "REQUESTSTATUS";
                    talbeId = "M_MOVEREQUEST_ID";
                }
                else if (tableNameToChangeData == "M_MOVEORDER")
                {
                    tableStatus = "ORDERSTATUS";
                    talbeId = "M_MOVEORDER_ID";
                }
                else
                {
                    return primaryKeysForNewInsertion;
                }

                DataTable moveStatus = 
                    this.getEM_MOVE_STATUSInfo(null, "", "", "", "", "", "", "", false, true, "AND");

                DataRow drNewMoveStatus = moveStatus.NewRow();

                if (!dataToEffectTheChange.Columns.Contains(tableStatus))
                {
                    return primaryKeysForNewInsertion;
                }
                if ((transactionStatusInformation.newRequest == 
                    dataToEffectTheChange.Rows[0][tableStatus].ToString()) ||
                    (transactionStatusInformation.newOrder == 
                    dataToEffectTheChange.Rows[0][tableStatus].ToString()) ||
                    (transactionStatusInformation.newDispatch ==
                    dataToEffectTheChange.Rows[0][tableStatus].ToString())) 
                {
                    return primaryKeysForNewInsertion;
                }

                if ((transactionStatusInformation.confirmedRequest == 
                    dataToEffectTheChange.Rows[0][tableStatus].ToString()) ||
                    (transactionStatusInformation.approvedRequest == 
                    dataToEffectTheChange.Rows[0][tableStatus].ToString()) ||
                    (transactionStatusInformation.confirmedDispatch == 
                    dataToEffectTheChange.Rows[0][tableStatus].ToString())||
                    (transactionStatusInformation.deliveryReceived == 
                    dataToEffectTheChange.Rows[0][tableStatus].ToString()) ||
                    (transactionStatusInformation.approvedOrder ==
                    dataToEffectTheChange.Rows[0][tableStatus].ToString()))
                         drNewMoveStatus["ISCONFORMATION"] = "Y";

                if (transactionStatusInformation.deliveryDisputed == 
                    dataToEffectTheChange.Rows[0][tableStatus].ToString()) 
                    drNewMoveStatus["ISDISPUTE"] = "Y";

                if (transactionStatusInformation.disputeRejected == 
                    dataToEffectTheChange.Rows[0][tableStatus].ToString()) 
                    drNewMoveStatus["ISDESPUTERESPONSE"] = "Y";

                if ((transactionStatusInformation.satisfiedRequest == 
                    dataToEffectTheChange.Rows[0][tableStatus].ToString()) ||
                    (transactionStatusInformation.deliveryAccepted == 
                    dataToEffectTheChange.Rows[0][tableStatus].ToString())||
                    (transactionStatusInformation.disputeAccepted == 
                    dataToEffectTheChange.Rows[0][tableStatus].ToString())||
                    (transactionStatusInformation.rejectedRequest ==
                    dataToEffectTheChange.Rows[0][tableStatus].ToString()) ||
                    (transactionStatusInformation.approvedOrder ==
                    dataToEffectTheChange.Rows[0][tableStatus].ToString()))
                        drNewMoveStatus["ISCLOSURE"] = "Y";
                                
                drNewMoveStatus["EM_STATION_ID"] =
                    generalResultInformation.Station;
                drNewMoveStatus["AD_CLIENT_ID"] =
                    generalResultInformation.clientId;
                drNewMoveStatus["AD_ORG_ID"] =
                    dataToEffectTheChange.Rows[0]["AD_ORG_ID"].ToString();                
                drNewMoveStatus["CREATEDBY"] =
                    generalResultInformation.userId;
                drNewMoveStatus[talbeId] =
                    dataToEffectTheChange.Rows[0][talbeId].ToString();
                //if(dataToEffectTheChange.Columns.Contains("M_MOVEREQUEST_ID"))
                //    drNewMoveStatus["M_MOVEREQUEST_ID"] =
                //        dataToEffectTheChange.Rows[0]["M_MOVEREQUEST_ID"].ToString();
                drNewMoveStatus["STATUS"] = 
                    dataToEffectTheChange.Rows[0][tableStatus].ToString();

                moveStatus.Rows.Add(drNewMoveStatus);

                this.changeDataBaseTableData(moveStatus, "EM_MOVE_STATUS", "INSERT");
            }
            //The return Array Format is arrayIndex[0]=|primaryKeyName1forRowOne<("theNewPrimaryKey")>|| ...
            //primaryKeyName2forRowOne<("theNewPrimaryKey")>|| ...,
            //arrayIndex[1]=|primaryKeyName1forRow2<("theNewPrimaryKey")>||
            //primaryKeyName2forRow2<("theNewPrimaryKey")>||...
            return primaryKeysForNewInsertion;
        }


        public void updateMovementAndRequestStatusToLatestStatus(string movementId, string requestId,
            bool checkAllMovement, bool checkAllRequest)
        {
            if (movementId == "" && requestId == "")
            {
                if (checkAllMovement)
                {
                    DataTable criterionTable = new DataTable();
                    criterionTable.Columns.Add("Field");
                    criterionTable.Columns.Add("Criterion");
                    criterionTable.Columns.Add("Value");

                    DataRow dt = criterionTable.NewRow();
                    dt["Field"] = "MOVESTATUS";
                    dt["Criterion"] = "!=";
                    dt["Value"] = transactionStatusInformation.deliveryAccepted;
                    criterionTable.Rows.Add(dt);

                    dt = criterionTable.NewRow();
                    dt["Field"] = "MOVESTATUS";
                    dt["Criterion"] = "!=";
                    dt["Value"] = transactionStatusInformation.disputeAccepted;
                    criterionTable.Rows.Add(dt);


                    DataTable nonClosedMovementRecords =
                        this.getEM_M_MOVEMENTInfo(criterionTable, "AND", "", "", "", false, false, "AND");

                    if (!this.checkIfTableContainesData(nonClosedMovementRecords))
                        return;
                    for (int moveRecordRowCounter = 0;
                        moveRecordRowCounter <= nonClosedMovementRecords.Rows.Count - 1;
                        moveRecordRowCounter++)
                    {
                        this.updateMovementAndRequestStatusToLatestStatus(
                                    nonClosedMovementRecords.Rows[moveRecordRowCounter]
                                        ["M_MOVEMENT_ID"].ToString(),
                                    "", false, false);
                    }
                }

                if (checkAllRequest)
                {
                    DataTable criterionTable = new DataTable();
                    criterionTable.Columns.Add("Field");
                    criterionTable.Columns.Add("Criterion");
                    criterionTable.Columns.Add("Value");

                    DataRow dt = criterionTable.NewRow();
                    dt["Field"] = "REQUESTSTATUS";
                    dt["Criterion"] = "!=";
                    dt["Value"] = transactionStatusInformation.satisfiedRequest;
                    criterionTable.Rows.Add(dt);

                    dt = criterionTable.NewRow();
                    dt["Field"] = "REQUESTSTATUS";
                    dt["Criterion"] = "!=";
                    dt["Value"] = transactionStatusInformation.rejectedRequest;
                    criterionTable.Rows.Add(dt);


                    DataTable nonClosedRequestRecords =
                        this.getEM_M_MOVEREQUESTInfo(criterionTable, "AND", "", "", false, false, "AND");

                    if (!this.checkIfTableContainesData(nonClosedRequestRecords))
                        return;
                    for (int requestRecordRowCounter = 0;
                        requestRecordRowCounter <= nonClosedRequestRecords.Rows.Count - 1;
                        requestRecordRowCounter++)
                    {
                        this.updateMovementAndRequestStatusToLatestStatus("",
                                    nonClosedRequestRecords.Rows[requestRecordRowCounter]
                                            ["M_MOVEREQUEST_ID"].ToString(),
                                    false, false);
                    }
                }
                return;
            }

            if (movementId != "")
            {
                DataTable moveStatus =
                    this.getEM_MOVE_STATUSInfo
                    (null, "", "", "", movementId, "", "", "", true, false, "AND");
                if (!this.checkIfTableContainesData(moveStatus))
                    return;
                
                DataTable moveRecord =
                    this.getEM_M_MOVEMENTInfo(null, "", movementId, "", "", false, false, "AND");

                if (!this.checkIfTableContainesData(moveRecord))
                    return;

                if (moveRecord.Rows[0]["MOVESTATUS"].ToString() !=
                    moveStatus.Rows[0]["STATUS"].ToString())
                {
                    moveRecord.Rows[0]["UPDATEDBY"] = 
                        moveStatus.Rows[0]["CREATEDBY"].ToString();
                    moveRecord.Rows[0]["MOVESTATUS"] = 
                        moveStatus.Rows[0]["STATUS"].ToString();

                    this.recordStatusUpdate = false;
                    this.changeDataBaseTableData(moveRecord, "EM_M_MOVEMENT", "UPDATE");
                    this.recordStatusUpdate = true;
                }
            }

            if (requestId != "")
            {

                DataTable criterionTable = new DataTable();
                criterionTable.Columns.Add("Field");
                criterionTable.Columns.Add("Criterion");
                criterionTable.Columns.Add("Value");

                DataRow dt = criterionTable.NewRow();
                dt["Field"] = "QTYPENDING";
                dt["Criterion"] = ">";
                dt["Value"] = "0";
                criterionTable.Rows.Add(dt);

                DataTable openRequestDetail =
                    this.getV_REQUESTDETAILInfo(criterionTable, "AND", requestId,
                            "", "", "", "", true, false, "AND", "", "");

                if (this.checkIfTableContainesData(openRequestDetail))
                    return;

                DataTable requestRecord =
                    this.getEM_M_MOVEREQUESTInfo(null, "", requestId, "", false, false, "AND");

                if (!this.checkIfTableContainesData(requestRecord))
                    return;

                if (requestRecord.Rows[0]["REQUESTSTATUS"].ToString() !=
                    transactionStatusInformation.satisfiedRequest)
                {                    
                    requestRecord.Rows[0]["REQUESTSTATUS"] =
                        transactionStatusInformation.satisfiedRequest;

                    this.recordStatusUpdate = false;
                    this.changeDataBaseTableData(requestRecord, "EM_M_MOVEREQUEST", "UPDATE");
                    this.recordStatusUpdate = true;
                }
            }

        }

        public void deleteOldDraftRecords(bool leaveCurrentStationRecord, int dateInterval)
        {
            string deleteOldDraftRecord_SUB = "DELETE FROM `EM_M_MOVEMENTLINE` " +
                                              "WHERE M_MOVEMENT_ID IN " +
                                              "( " +
                                              "	SELECT M_MOVEMENT_ID " +
                                              "	FROM `EM_M_MOVEMENT` " +
                                              "	WHERE MOVESTATUS = 'Draft_Dispatch' " +
                                              "	AND UPDATED <= DATE_SUB(CURDATE(),INTERVAL " + dateInterval.ToString() + " DAY) " +
                                              ")	AND M_MOVEREQUESTLINE_ID IS NULL";
            if(leaveCurrentStationRecord)
                deleteOldDraftRecord_SUB = deleteOldDraftRecord_SUB + 
                    " AND EM_STATION_ID != " + generalResultInformation.Station;
            
            string deleteOldDraftRecord_MAIN = "DELETE FROM `EM_M_MOVEMENT` " +
                                               "WHERE MOVESTATUS = 'Draft_Dispatch' " +
                                               "AND UPDATED <= DATE_SUB(CURDATE(),INTERVAL " + dateInterval.ToString() + " DAY)" +
                                               " AND M_MOVEREQUEST_ID IS NULL";

            if (leaveCurrentStationRecord)
                deleteOldDraftRecord_MAIN = deleteOldDraftRecord_MAIN +
                    " AND EM_STATION_ID != " + generalResultInformation.Station;

            this.executeSqlOnEasyMove(deleteOldDraftRecord_SUB);
            this.executeSqlOnEasyMove(deleteOldDraftRecord_MAIN);
        }

        public string getAccessableLocatorList(taskType taskT, bool viewOnly) {

            DataTable accesableLctLst;

            string getAccessableLctrList = "";
            string accessableLocatorList = "";
            string accessableWrhList = "";
            string taskFilter = "";
            if (viewOnly)
            {
                switch (taskT)
                {
                    case taskType.Request:
                        taskFilter = "VIEWREQUEST = 'Y'";
                        break;
                    case taskType.Order:
                        taskFilter = "VIEWDISPATCHORDER = 'Y'";
                        break;
                    case taskType.Dispatch:
                        taskFilter = "(VIEWDISPATCH = 'Y' OR VIEWDISPUTE = 'Y')";
                        break;
                    case taskType.Receive:
                        taskFilter = "(VIEWDELIVERY = 'Y' OR VIEWDISPUTE = 'Y')";
                        break;
                    case taskType.In:
                        taskFilter = "VIEWINVENTORYIN = 'Y'";
                        break;
                    case taskType.Make:
                        taskFilter = "VIEWINVENTORYMAKE = 'Y'";
                        break;
                    case taskType.Out:
                        taskFilter = "VIEWINVENTORYOUT = 'Y'";
                        break;
                    default:
                        taskFilter = "";
                        break;
                }
            }
            else
            {
                switch (taskT)
                {
                    case taskType.Request:
                        taskFilter = "(CREATEREQUEST = 'Y' OR CONFIRMREQUEST = 'Y' OR APPROVEREQUEST = 'Y' OR REJECTREQUEST = 'Y')";
                        break;
                    case taskType.Order:
                        taskFilter = "(CREATEDISPATCHORDER = 'Y' OR CONFIRMDISPATCHORDER = 'Y')";
                        break;
                    case taskType.Dispatch:
                        taskFilter = "(CREATEDISPATCH = 'Y' OR CONFIRMDISPATCH = 'Y' OR REFUSEDISPATCH = 'Y')";
                        break;
                    case taskType.Receive:
                        taskFilter = "(ACCEPTDELIVERY = 'Y' OR CONFIRMRECIPT = 'Y' OR REJECTDELIVERY = 'Y' OR DISPUTEDELIVERY = 'Y')";
                        break;
                    case taskType.In:
                        taskFilter = "(CREATEINVENTORYIN = 'Y' OR CONFIRMINVENTORYIN = 'Y')";
                        break;
                    case taskType.Make:
                        taskFilter = "(CREATEINVENTORYMAKE = 'Y' OR CONFIRMINVENTORYMAKE = 'Y')";
                        break;
                    case taskType.Out:
                        taskFilter = "(CREATEINVENTORYOUT = 'Y' OR CONFIRMINVENTORYOUT = 'Y')";
                        break;
                    default:
                        taskFilter = "";
                        break;
                }
            }

            
            string getAccessableWarehouseList =                 
                    "SELECT M_WAREHOUSE_ID " +
                    "FROM EM_PROCESS_ACCESS " +
                    "WHERE AD_USER_ID = " + generalResultInformation.userId +
                        " AND (EM_STATION_ID = " + generalResultInformation.Station +
                            " OR EM_STATION_ID = " + generalResultInformation.allStationRepresentativeKey + ") " +
                            " AND ISACTIVE = 'Y'" + (taskFilter !="" ?  " AND " + taskFilter : "");

            DataTable accessableWrHLst = (DataTable)executeSqlOnEasyMove(getAccessableWarehouseList);

            if (this.checkIfTableContainesData(accessableWrHLst))
            {
                for (int rowCounter = 0; rowCounter <= accessableWrHLst.Rows.Count - 1; rowCounter++)
                {
                    if (accessableWrHLst.Rows[rowCounter]["M_WAREHOUSE_ID"].ToString() == 
                        generalResultInformation.allWarehouseRepresentativeKey)
                    {
                        goto returnAllLocator;
                    }
                    else {
                        accessableWrhList = accessableWrhList + "," + accessableWrHLst.Rows[rowCounter]["M_WAREHOUSE_ID"].ToString();
                    }
                }
                accessableWrhList = accessableWrhList.Remove(0, 1);
            }

            if (accessableWrhList != "") 
            {                
                getAccessableLctrList = "SELECT M_LOCATOR_ID "+ 
                                               "FROM EM_M_LOCATOR "+
                                               "WHERE M_WAREHOUSE_ID IN (" + accessableWrhList + ")";

                accesableLctLst = (DataTable)executeSqlOnEasyMove(getAccessableLctrList);
                if (this.checkIfTableContainesData(accesableLctLst))
                {

                    for (int rowCounter = 0; rowCounter <= accesableLctLst.Rows.Count - 1; rowCounter++)
                    {
                        accessableLocatorList = accessableLocatorList + "," +
                                accesableLctLst.Rows[rowCounter]["M_LOCATOR_ID"].ToString();                        
                    }
                    accessableLocatorList = accessableLocatorList.Remove(0, 1);
                }                    
            }

            return (accessableLocatorList == "" ? "0" : accessableLocatorList) ;

        returnAllLocator:
            getAccessableLctrList = "SELECT M_LOCATOR_ID FROM EM_M_LOCATOR";
            accesableLctLst = (DataTable)executeSqlOnEasyMove(getAccessableLctrList);
            if (this.checkIfTableContainesData(accesableLctLst))
            {
                for (int rowCounter = 0; rowCounter <= accesableLctLst.Rows.Count - 1; rowCounter++)
                {
                    accessableLocatorList = accessableLocatorList + "," +
                            accesableLctLst.Rows[rowCounter]["M_LOCATOR_ID"].ToString();
                }
                accessableLocatorList = accessableLocatorList.Remove(0, 1);
            }

            return (accessableLocatorList == "" ? "0" : accessableLocatorList);
            
        }

        public DataTable getOPEN_ROMInfo()
        {            
            string getRequestedTableInformation = 
                    "SELECT * FROM (( " +
                        "SELECT 10 RECORD_ID, COUNT(DISTINCT (M_MOVEREQUEST_ID)) OPEN_COUNT " +
                        "FROM V_REQUESTDETAIL " +
                        "WHERE REQUESTSTATUS IN ('Requested') AND " +
                            "( " +
                             "M_LOCATOR_ID IN " +
                             "( " +
                                this.getAccessableLocatorList(taskType.Request, true) +
                             ") OR " +
                             "M_LOCATORTO_ID IN " +
                             "( " +
                                this.getAccessableLocatorList(taskType.Request, true) +
                             ") " +
                            ") " +
                    ") UNION ( " +
                        "SELECT 11 RECORD_ID, COUNT(DISTINCT (M_MOVEORDER_ID)) OPEN_COUNT " +
                        "FROM V_MOVEORDERDETAIL " +
                        "WHERE ORDERSTATUS NOT IN ('Pacified','Closed') AND " +
                            "( " +
                             "M_LOCATOR_ID IN " +
                             "( " +
                                this.getAccessableLocatorList(taskType.Order, true) +
                             ") OR " +
                             "M_LOCATORTO_ID IN " +
                             "( " +
                                this.getAccessableLocatorList(taskType.Order, true) +
                             ") " +
                            ") " +
                    ") UNION( " +
                        "SELECT 12 RECORD_ID, COUNT(DISTINCT (M_MOVEMENT_ID)) OPEN_COUNT " +
                        "FROM V_MOVEMENTDETAIL " +
                        "WHERE MOVESTATUS NOT IN ('Received','Cancelled') AND " +
                            "( " +
                             "M_LOCATOR_ID IN " +
                             "( " +
                                this.getAccessableLocatorList(taskType.Dispatch, true) + "," +
                                this.getAccessableLocatorList(taskType.Receive, true) +
                             ") OR " +
                             "M_LOCATORTO_ID IN " +
                             "( " +
                                this.getAccessableLocatorList(taskType.Dispatch, true) + "," +
                                this.getAccessableLocatorList(taskType.Receive, true) +
                             ") " +
                            ") " +
                    ") UNION ( " +
                        "SELECT 13 RECORD_ID, COUNT(DISTINCT (M_MOVEMENT_ID)) OPEN_COUNT " +
                        "FROM V_MOVEMENTDETAIL " +
                        "WHERE MOVESTATUS NOT IN ('Received','Cancelled') AND " +
                            "( " +
                             "M_LOCATOR_ID IN " +
                             "( " +
                                this.getAccessableLocatorList(taskType.Dispatch, true) + "," +
                                this.getAccessableLocatorList(taskType.Receive, true) +
                             ") OR " +
                             "M_LOCATORTO_ID IN " +
                             "( " +
                                this.getAccessableLocatorList(taskType.Dispatch, true) + "," +
                                this.getAccessableLocatorList(taskType.Receive, true) +
                             ") " +
                            ") AND MOVEMENTDATE <= (SELECT SUBDATE(CURDATE(),3)) " +
                    "))rslt";

            return (DataTable)executeSqlOnEasyMove(getRequestedTableInformation);            
        }

    }
}
