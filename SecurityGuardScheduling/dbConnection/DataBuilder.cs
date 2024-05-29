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
        public string CREATED = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");
        public string CREATEDBY = "1000";
        public string UPDATED = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");
        public string UPDATEDBY = "1000";

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
                string appostrophy = "";
                for (int i = 0; i < primaryKeys.Length; i++)
                {
                    appostrophy = 
                        primaryKeys[i].ToString().Contains("_ID") ? "" : "'";
                    primaryColIDCondition +=
                        fieldSeparator+primaryKeys[i].ToString() +
                        fieldSeparator + " = " + appostrophy + dt.Rows[rowIndex][primaryKeys[i].ToString()] + appostrophy;
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
                    if ((dt.Rows[rowIndex][i].GetType().ToString() ==
                        "System.String" ||
                        dt.Rows[rowIndex][i].GetType().ToString() ==
                        "System.DateTime") && 
                        dt.Rows[rowIndex][i].ToString() != 
                        generalResultInformation.dbNull)
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
                            trsTime.ToString("dd-MMM-yyyy HH:mm:ss") +
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
                        theValue = 
                            theValue == generalResultInformation.dbNull ? 
                                                    "NULL" : theValue;

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
                    if(primaryKeys.Contains<string>(dt.Columns[i].Caption.ToString()))
                        continue;
                    if ((dt.Rows[rowIndex][i].GetType().ToString() ==
                        "System.String" ||
                        dt.Rows[rowIndex][i].GetType().ToString() ==
                        "System.DateTime") &&
                        dt.Rows[rowIndex][i].ToString() !=
                        generalResultInformation.dbNull)
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
                            trsTime.ToString("dd-MMM-yyyy HH:mm:ss") +
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

                        theValue =
                            theValue == generalResultInformation.dbNull ?
                                                    "NULL" : theValue;

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
                
        public object executeSqlOnDB(string sqlCommand)
        {
            dbCommitFailure.dbCommitError = false;
            dbCommitFailure.dbCommitWarnning = false;

            dbCommitFailure.dbCommitErrorMessage = "";
            dbCommitFailure.dbCommitWarnningMessage = "";


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
                " WHERE UCASE(NAME) = '" + tableName.ToUpperInvariant() + "'";
            DataTable primaryKey = (DataTable)this.executeSqlOnDB(getPrimaryKey);
            if (checkIfTableContainesData(primaryKey))
            {
                nextPrimaryKey = primaryKey.Rows[0][0].ToString();
                string setPrimaryKey = "UPDATE AD_SEQUENCE" +
                    " SET  CURRENTNEXT = CURRENTNEXT + 1" +
                    " WHERE UCASE(NAME) = '" + tableName.ToUpperInvariant() + "'";
                this.executeSqlOnDB(setPrimaryKey);
            }

            return nextPrimaryKey.ToString();
        }

        public string[] getTablePrimaryKey(string tableName)
        {
            string[] primarykeys = { "" };
            if (tableName == "AD_SEQUENCE")
            { primarykeys = new string[] { "AD_SEQUENCE_ID" }; }
            if (tableName == "GS_GAURD")
            { primarykeys = new string[] { "GS_GAURD_ID" }; }
            if (tableName == "GS_POST")
            { primarykeys = new string[] { "GS_POST_ID" }; }
            if (tableName == "GS_SHIFT")
            { primarykeys = new string[] { "GS_SHIFT_ID" }; }
            else if (tableName == "GS_EXCLUSION")
            { primarykeys = new string[] { "GS_EXCLUSION_ID" }; }
            else if (tableName == "GS_DAY_EXCLUSION")
            { primarykeys = new string[] { "GS_EXCLUSION_ID", "DAY_EXCLUDED" }; }
            else if (tableName == "GS_GAURD_EXCLUSION")
            { primarykeys = new string[] { "GS_EXCLUSION_ID", "GS_GAURD_ID" }; }
            else if (tableName == "GS_SHIFT_EXCLUSION")
            { primarykeys = new string[] { "GS_EXCLUSION_ID", "GS_SHIFT_ID" }; }
            else if (tableName == "GS_POST_EXCLUSION")
            { primarykeys = new string[] { "GS_EXCLUSION_ID", "GS_POST_ID" }; }
            else if (tableName == "GS_DUTY")
            { primarykeys = new string[] { "GS_DUTY_ID" }; }
                        
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
                    if ((_criteriaTable.Rows[rowCounter]["Value"].GetType().ToString() ==
                        "System.String" ||
                        _criteriaTable.Rows[rowCounter]["Value"].GetType().ToString() ==
                        "System.DateTime") && 
                        !(
                          _criteriaTable.Rows[rowCounter]["Value"].ToString().StartsWith("#") &&
                          _criteriaTable.Rows[rowCounter]["Value"].ToString().EndsWith("#") &&
                          dbSettingInformationHandler.compDataBaseType == 
                                supportedDbList.MsAccess_2007.ToString()
                         )
                        )
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

            string[] Tableprimarykeys = this.getTablePrimaryKey(tableName);
            
            string theWhereClose = "";
            if (Tableprimarykeys.Length > 0)
                if (Tableprimarykeys[0] != "")
                    theWhereClose = "WHERE ";
            string nullVal = "";
            foreach (string primaryKey in Tableprimarykeys)
            {
                nullVal = primaryKey.Contains("_ID") ? " = 0" : " = '0'";
                if (primaryKey != "")
                    theWhereClose = theWhereClose + primaryKey + nullVal + " AND ";
            }
            theWhereClose = theWhereClose.Remove(theWhereClose.LastIndexOf(" AND "),5);
            string getStructureForTable = "SELECT *" +
                                          " FROM " + tableName + " " + theWhereClose;
            DataTable result = (DataTable)executeSqlOnDB(getStructureForTable);
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


        public string getNextSequenceId(string Name, string AD_SEQUENCE_ID,
            bool incrementToNextSequence)
        {
            string nextPrimaryKey = "";
            string preFix = "";
            string suffix = "";

            if (Name == "" && AD_SEQUENCE_ID == "")
                return "";            
            
            DataTable sequenceRecord =
                this.getAD_SEQUENCEInfo(null, "", "", AD_SEQUENCE_ID, Name, true, false, "AND");

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
                    " UCASE(NAME) = '" + NAME.ToUpperInvariant().Replace("'", "''") + "'";


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
                    nextTablePrimaryKey = this.getNextSequenceId(tableNameToChangeData, "", true);
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


        # region "Application Specific Methods"

        public DataTable getGS_GAURDInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string GS_GAURD_ID, string CODE, string FIRSTNAME, string MIDDELNAME,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("GS_GAURD");
            }

            string whereClause = "WHERE ";

            if (onlyActiveRecords)
            {
                whereClause = whereClause + "ISACTIVE= 'Y'";
            }
            else
                whereClause = whereClause + "(ISACTIVE= 'Y' OR ISACTIVE= 'N')";

            if (GS_GAURD_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " GS_GAURD_ID = " + GS_GAURD_ID;

            if (CODE != "")
                whereClause = whereClause + " " + logicalConnector +
                    " UCASE(CODE) LIKE '%" + CODE + "%'";

            if (FIRSTNAME != "")
                whereClause = whereClause + " " + logicalConnector +
                    " UCASE(FIRSTNAME) LIKE '%" + FIRSTNAME + "%'";

            if (MIDDELNAME != "")
                whereClause = whereClause + " " + logicalConnector +
                    " UCASE(MIDDELNAME) LIKE '%" + MIDDELNAME + "%'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);
                        
            getRequestedTableInformation = "SELECT * " +
                                           "FROM GS_GAURD " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }

        public DataTable getGS_POSTInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string GS_POST_ID, string CODE, string NAME,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("GS_POST");
            }

            string whereClause = "WHERE ";

            if (onlyActiveRecords)
            {
                whereClause = whereClause + "ISACTIVE= 'Y'";
            }
            else
                whereClause = whereClause + "(ISACTIVE= 'Y' OR ISACTIVE= 'N')";

            if (GS_POST_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " GS_POST_ID = " + GS_POST_ID;

            if (CODE != "")
                whereClause = whereClause + " " + logicalConnector +
                    " UCASE(CODE) LIKE '%" + CODE + "%'";

            if (NAME != "")
                whereClause = whereClause + " " + logicalConnector +
                    " UCASE(NAME) LIKE '%" + NAME + "%'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM GS_POST " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }

        public DataTable getGS_SHIFTInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string GS_SHIFT_ID, string CODE, string NAME,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("GS_SHIFT");
            }

            string whereClause = "WHERE ";

            if (onlyActiveRecords)
            {
                whereClause = whereClause + "ISACTIVE= 'Y'";
            }
            else
                whereClause = whereClause + "(ISACTIVE= 'Y' OR ISACTIVE= 'N')";

            if (GS_SHIFT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " GS_SHIFT_ID = " + GS_SHIFT_ID;

            if (CODE != "")
                whereClause = whereClause + " " + logicalConnector +
                    " UCASE(CODE) LIKE '%" + CODE + "%'";

            if (NAME != "")
                whereClause = whereClause + " " + logicalConnector +
                    " UCASE(NAME) LIKE '%" + NAME + "%'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM GS_SHIFT " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="criteriaTable"></param>
        /// <param name="criteriaTableLogicalConnector"></param>
        /// <param name="GS_EXCLUSION_ID">"Specific GS_EXCLUSION_ID"</param>
        /// <param name="CODE">Exclusion Code</param>
        /// <param name="NAME">Name of Exclusion</param>
        /// <param name="onlyActiveRecords">Return Only Active Or All Records</param>
        /// <param name="structureOnly">Return Table Structure Only</param>
        /// <param name="logicalConnector">Logic to connect parameters "AND" or "OR"</param>
        /// <returns></returns>
        public DataTable getGS_EXCLUSIONInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
           string GS_EXCLUSION_ID, string CODE, string NAME,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            return this.getGS_EXCLUSIONInfo(criteriaTable, "", GS_EXCLUSION_ID, CODE, NAME, 
                triaStateBool.Ignor, triaStateBool.Ignor,triaStateBool.Ignor, triaStateBool.Ignor, 
                triaStateBool.Ignor, triaStateBool.Ignor, 
               onlyActiveRecords, structureOnly, logicalConnector);            
        }

        public DataTable getGS_EXCLUSIONInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
           string GS_EXCLUSION_ID, string CODE, string NAME,
            triaStateBool ISRANGE_EXCLUSION, triaStateBool ISDAY_EXCLUSION, triaStateBool ISDATE_EXCLUSION,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            return this.getGS_EXCLUSIONInfo(criteriaTable, "", GS_EXCLUSION_ID, CODE, NAME,
                ISRANGE_EXCLUSION, ISDAY_EXCLUSION, ISDATE_EXCLUSION,
                triaStateBool.Ignor, triaStateBool.Ignor, triaStateBool.Ignor,
               onlyActiveRecords, structureOnly, logicalConnector);            
        }

        public DataTable getGS_EXCLUSIONInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
           string GS_EXCLUSION_ID, string CODE, string NAME,
            triaStateBool ISGAURD_EXCLUSION,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            return this.getGS_EXCLUSIONInfo(criteriaTable, "", GS_EXCLUSION_ID, CODE, NAME,
                triaStateBool.Ignor, triaStateBool.Ignor, triaStateBool.Ignor,
                ISGAURD_EXCLUSION, triaStateBool.Ignor, triaStateBool.Ignor,
               onlyActiveRecords, structureOnly, logicalConnector);
                        
        }

        public DataTable getGS_EXCLUSIONInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string GS_EXCLUSION_ID, string CODE, string NAME,
            triaStateBool ISGAURD_EXCLUSION, triaStateBool ISSHIFT_EXCLUSION,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            return this.getGS_EXCLUSIONInfo(criteriaTable, "", GS_EXCLUSION_ID, CODE, NAME,
                triaStateBool.Ignor, triaStateBool.Ignor, triaStateBool.Ignor,
                ISGAURD_EXCLUSION, ISSHIFT_EXCLUSION, triaStateBool.Ignor,
               onlyActiveRecords, structureOnly, logicalConnector);            
        }

        public DataTable getGS_EXCLUSIONInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string GS_EXCLUSION_ID,
            triaStateBool ISGAURD_EXCLUSION, triaStateBool ISSHIFT_EXCLUSION, triaStateBool ISPOST_EXCLUSION,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            return this.getGS_EXCLUSIONInfo(criteriaTable, "", GS_EXCLUSION_ID, "", "",
                triaStateBool.Ignor, triaStateBool.Ignor, triaStateBool.Ignor,
                ISGAURD_EXCLUSION, ISSHIFT_EXCLUSION, ISPOST_EXCLUSION,
               onlyActiveRecords, structureOnly, logicalConnector);            
        }
        

        public DataTable getGS_EXCLUSIONInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string GS_EXCLUSION_ID, string CODE, string NAME,             
            triaStateBool ISRANGE_EXCLUSION, triaStateBool ISDAY_EXCLUSION, triaStateBool ISDATE_EXCLUSION,
            triaStateBool ISGAURD_EXCLUSION, triaStateBool ISSHIFT_EXCLUSION, triaStateBool ISPOST_EXCLUSION,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("GS_EXCLUSION");
            }

            string whereClause = "WHERE ";

            if (onlyActiveRecords)
            {
                whereClause = whereClause + "ISACTIVE= 'Y'";
            }
            else
                whereClause = whereClause + "(ISACTIVE= 'Y' OR ISACTIVE= 'N')";

            if (GS_EXCLUSION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " GS_EXCLUSION_ID = " + GS_EXCLUSION_ID;

            if (CODE != "")
                whereClause = whereClause + " " + logicalConnector +
                    " UCASE(CODE) LIKE '%" + CODE + "%'";

            if (NAME != "")
                whereClause = whereClause + " " + logicalConnector +
                    " UCASE(NAME) LIKE '%" + NAME + "%'";

            if (ISRANGE_EXCLUSION != triaStateBool.Ignor)
            { 
                if (ISRANGE_EXCLUSION == triaStateBool.yes)
                    whereClause = whereClause + " " + logicalConnector + " ISRANGE_EXCLUSION = 'Y'";
                else
                    whereClause = whereClause + " " + logicalConnector + " ISRANGE_EXCLUSION = 'N'";
            }


            if (ISDAY_EXCLUSION != triaStateBool.Ignor)
            {
                if (ISDAY_EXCLUSION == triaStateBool.yes)
                    whereClause = whereClause + " " + logicalConnector + " ISDAY_EXCLUSION = 'Y'";
                else
                    whereClause = whereClause + " " + logicalConnector + " ISDAY_EXCLUSION = 'N'";
            }


            if (ISDATE_EXCLUSION != triaStateBool.Ignor)
            {
                if (ISDATE_EXCLUSION == triaStateBool.yes)
                    whereClause = whereClause + " " + logicalConnector + " ISDATE_EXCLUSION = 'Y'";
                else
                    whereClause = whereClause + " " + logicalConnector + " ISDATE_EXCLUSION = 'N'";
            }


            if (ISGAURD_EXCLUSION != triaStateBool.Ignor)
            {
                if (ISGAURD_EXCLUSION == triaStateBool.yes)
                    whereClause = whereClause + " " + logicalConnector + " ISGAURD_EXCLUSION = 'Y'";
                else
                    whereClause = whereClause + " " + logicalConnector + " ISGAURD_EXCLUSION = 'N'";
            }


            if (ISSHIFT_EXCLUSION != triaStateBool.Ignor)
            {
                if (ISSHIFT_EXCLUSION == triaStateBool.yes)
                    whereClause = whereClause + " " + logicalConnector + " ISSHIFT_EXCLUSION = 'Y'";
                else
                    whereClause = whereClause + " " + logicalConnector + " ISSHIFT_EXCLUSION = 'N'";
            }


            if (ISPOST_EXCLUSION != triaStateBool.Ignor)
            {
                if (ISPOST_EXCLUSION == triaStateBool.yes)
                    whereClause = whereClause + " " + logicalConnector + " ISPOST_EXCLUSION = 'Y'";
                else
                    whereClause = whereClause + " " + logicalConnector + " ISPOST_EXCLUSION = 'N'";
            }


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM GS_EXCLUSION " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }


        public DataTable getGS_DAY_EXCLUSIONInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string GS_EXCLUSION_ID, daysOfWeek DAY_EXCLUDED,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("GS_DAY_EXCLUSION");
            }

            string whereClause = "WHERE ";

            if (onlyActiveRecords)
            {
                whereClause = whereClause + "ISACTIVE= 'Y'";
            }
            else
                whereClause = whereClause + "(ISACTIVE= 'Y' OR ISACTIVE= 'N')";

            if (GS_EXCLUSION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " GS_EXCLUSION_ID = " + GS_EXCLUSION_ID;

            if (DAY_EXCLUDED != daysOfWeek.A_None)
                whereClause = whereClause + " " + logicalConnector +
                    " DAY_EXCLUDED = '" + DAY_EXCLUDED.ToString() + "'";
            

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM GS_DAY_EXCLUSION " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }


        public DataTable getGS_GAURD_EXCLUSIONInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string GS_EXCLUSION_ID, string GS_GAURD_ID,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("GS_GAURD_EXCLUSION");
            }

            string whereClause = "WHERE ";

            if (onlyActiveRecords)
            {
                whereClause = whereClause + "ISACTIVE= 'Y'";
            }
            else
                whereClause = whereClause + "(ISACTIVE= 'Y' OR ISACTIVE= 'N')";

            if (GS_EXCLUSION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " GS_EXCLUSION_ID = " + GS_EXCLUSION_ID;

            if (GS_GAURD_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " GS_GAURD_ID = " + GS_GAURD_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM GS_GAURD_EXCLUSION " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }


        public DataTable getGS_SHIFT_EXCLUSIONInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string GS_EXCLUSION_ID, string GS_SHIFT_ID,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("GS_SHIFT_EXCLUSION");
            }

            string whereClause = "WHERE ";

            if (onlyActiveRecords)
            {
                whereClause = whereClause + "ISACTIVE= 'Y'";
            }
            else
                whereClause = whereClause + "(ISACTIVE= 'Y' OR ISACTIVE= 'N')";

            if (GS_EXCLUSION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " GS_EXCLUSION_ID = " + GS_EXCLUSION_ID;

            if (GS_SHIFT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " GS_SHIFT_ID = " + GS_SHIFT_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM GS_SHIFT_EXCLUSION " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }

        public DataTable getGS_POST_EXCLUSIONInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string GS_EXCLUSION_ID, string GS_POST_ID,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("GS_POST_EXCLUSION");
            }

            string whereClause = "WHERE ";

            if (onlyActiveRecords)
            {
                whereClause = whereClause + "ISACTIVE= 'Y'";
            }
            else
                whereClause = whereClause + "(ISACTIVE= 'Y' OR ISACTIVE= 'N')";

            if (GS_EXCLUSION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " GS_EXCLUSION_ID = " + GS_EXCLUSION_ID;

            if (GS_POST_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " GS_POST_ID = " + GS_POST_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM GS_POST_EXCLUSION " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }

        public DataTable getGS_DUTY(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string GS_DUTY_ID, DateTime DUTYDATE , bool useDUTYDATE, triaStateBool ISONDUTY,
            string GS_POST_ID, string GS_SHIFT_ID, string GS_GAURD_ID, 
            string GS_EXCLUSION_ID,
            bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("GS_DUTY");
            }

            string whereClause = "WHERE ";

            if (onlyActiveRecords)
            {
                whereClause = whereClause + "ISACTIVE= 'Y'";
            }
            else
                whereClause = whereClause + "(ISACTIVE= 'Y' OR ISACTIVE= 'N')";


            if (GS_DUTY_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " GS_DUTY_ID = " + GS_DUTY_ID;

            if (useDUTYDATE)
                whereClause = whereClause + " " + logicalConnector +
                    " ( DUTYDATE >= #" + DUTYDATE.ToString("dd-MMM-yyyy") + "#" +
                    " AND DUTYDATE < #" + DUTYDATE.AddDays(1).ToString("dd-MMM-yyyy") + "# )";


            if (ISONDUTY != triaStateBool.Ignor)
            {
                if (ISONDUTY == triaStateBool.yes)
                    whereClause = whereClause + " " + logicalConnector +
                        " ISONDUTY = 'Y'";
                else
                    whereClause = whereClause + " " + logicalConnector +
                        " ISONDUTY = 'N'";
            }
            
            if (GS_POST_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " GS_POST_ID = " + GS_POST_ID;
                        
            if (GS_SHIFT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " GS_SHIFT_ID = " + GS_SHIFT_ID;


            if (GS_GAURD_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " GS_GAURD_ID = " + GS_GAURD_ID;


            if (GS_EXCLUSION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " GS_EXCLUSION_ID = " + GS_EXCLUSION_ID;            


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM GS_DUTY " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }


        public DataTable getGS_DUTY(DataTable criteriaTable, string criteriaTableLogicalConnector,
            DateTime DUTYDATE, string GS_GAURD_ID,
            bool onlyActiveRecords, string logicalConnector)
        {
            return this.getGS_DUTY(criteriaTable, criteriaTableLogicalConnector,
                "", DUTYDATE, true, triaStateBool.Ignor, "", "", GS_GAURD_ID, "",
                onlyActiveRecords, false, logicalConnector);            
        }

        public DataTable getGS_DUTY(DataTable criteriaTable, string criteriaTableLogicalConnector,
            DateTime DUTYDATE, string GS_GAURD_ID, triaStateBool ISONDUTY,
            bool onlyActiveRecords, string logicalConnector)
        {
            return this.getGS_DUTY(criteriaTable, criteriaTableLogicalConnector,
                "", DUTYDATE, true, ISONDUTY, "", "", GS_GAURD_ID, "",
                onlyActiveRecords, false, logicalConnector);
        }

        #endregion
    
    }
        
}
