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
                            trsTime.ToString(generalResultInformation.dateFormat) +
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
                            trsTime.ToString(generalResultInformation.dateFormat) +
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
                    filePath = dbSettingInformationHandler.ScriptDirectory;
                    extension = ".srp";
                    break;
                case "compWARINING":
                    filePath = dbSettingInformationHandler.WarningDirectory;
                    extension = ".wrn";
                    break;
                case "compERROR":
                    filePath = dbSettingInformationHandler.ErrorDirectory;
                    extension = ".err";
                    break;
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
            string oraDataBaseType = dbSettingInformationHandler.DataBaseType;
            string oraHostName = dbSettingInformationHandler.ServerHostName;
            string oraDataBaseName = dbSettingInformationHandler.DataBaseName;
            string oraUserName = dbSettingInformationHandler.DBUserName;
            string oraPassWord = dbSettingInformationHandler.DBPassword;
            string oraPort = dbSettingInformationHandler.DBPort;

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
                " WHERE " + dbSettingInformationHandler.upperCaseFunction + "(NAME) = '" + tableName.ToUpperInvariant() + "'";
            DataTable primaryKey = (DataTable)this.executeSqlOnDB(getPrimaryKey);
            if (checkIfTableContainesData(primaryKey))
            {
                nextPrimaryKey = primaryKey.Rows[0][0].ToString();
                string setPrimaryKey = "UPDATE AD_SEQUENCE" +
                    " SET  CURRENTNEXT = CURRENTNEXT + 1" +
                    " WHERE " + dbSettingInformationHandler.upperCaseFunction + "(NAME) = '" + tableName.ToUpperInvariant() + "'";
                this.executeSqlOnDB(setPrimaryKey);
            }

            return nextPrimaryKey.ToString();
        }

        public string[] getTablePrimaryKey(string tableName)
        {
            string[] primarykeys = { "" };
            if (tableName == dbSettingInformationHandler.dbTablePrefix + "M_WAREHOUSE")
            { primarykeys = new string[] { "M_WAREHOUSE_ID" }; }
            else if (tableName == dbSettingInformationHandler.dbTablePrefix + "M_LOCATOR")
            { primarykeys = new string[] { "M_LOCATOR_ID" }; }
            else if (tableName == dbSettingInformationHandler.dbTablePrefix + "AD_SEQUENCE")
            { primarykeys = new string[] { "AD_SEQUENCE_ID" }; }
            else if (tableName == dbSettingInformationHandler.dbTablePrefix + "M_PRODUCT_CATEGORY")
            { primarykeys = new string[] { "M_PRODUCT_CATEGORY_ID" }; }
            else if (tableName == dbSettingInformationHandler.dbTablePrefix + "C_UOM")
            { primarykeys = new string[] { "C_UOM_ID" }; }
            else if (tableName == dbSettingInformationHandler.dbTablePrefix + "M_PRODUCT")
            { primarykeys = new string[] { "M_PRODUCT_ID" }; }
            else if (tableName == dbSettingInformationHandler.dbTablePrefix + "M_MOVEMENTLINE")
            { primarykeys = new string[] { "M_PRODUCT_ID" }; }
            else if (tableName == dbSettingInformationHandler.dbTablePrefix + "AD_ORG")
            { primarykeys = new string[] { "AD_ORG_ID" }; }
            else if (tableName == dbSettingInformationHandler.dbTablePrefix + "AD_USER_ORGACCESS")
            { primarykeys = new string[] { "AD_ORG_ID", "AD_USER_ID" }; }
            else if (tableName == dbSettingInformationHandler.dbTablePrefix + "AD_USER_WAREHOUSE_ACCESS")
            { primarykeys = new string[] { "M_WAREHOUSE_ID", "AD_USER_ID" }; }
            else if (tableName == dbSettingInformationHandler.dbTablePrefix + "AD_USER")
            { primarykeys = new string[] { "AD_USER_ID" }; }
            else if (tableName == "RV_DETAIL_STOCK_ACTIVITY_RPT")
            { primarykeys = new string[] { "M_TRANSACTION_ID" }; }
            else if (tableName == "EM_PROCESS_ACCESS")
            { primarykeys = new string[] { "AD_USER_ID", "M_WAREHOUSE_ID", "EM_STATION_ID", }; }
            else if (tableName == dbSettingInformationHandler.dbTablePrefix + "AD_USER_ROLES")
            { primarykeys = new string[] { "AD_ROLE_ID", "AD_USER_ID" }; }
            
            return primarykeys;
        }

        private DataTable getDataTableStructure(string tableName)
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





        #region "Application Specific Data Fetch"


        public DataTable getAD_ORGInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure(dbSettingInformationHandler.dbTablePrefix + "AD_ORG");
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
                                           "FROM " + dbSettingInformationHandler.dbTablePrefix + "AD_ORG " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }

        public DataTable getAD_USER_ORGACCESSInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string AD_USER_ID, bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure(dbSettingInformationHandler.dbTablePrefix + "AD_USER_ORGACCESS");
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
                                           "FROM " + dbSettingInformationHandler.dbTablePrefix + "AD_USER_ORGACCESS " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }

        public DataTable getAD_USER_WAREHOUSE_ACCESSInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_WAREHOUSE_ID, string AD_USER_ID, bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure(dbSettingInformationHandler.dbTablePrefix + "AD_USER_WAREHOUSE_ACCESS");
            }

            if (dbSettingInformationHandler.DataBaseType == "MySql")
            {
                DataTable userWareHouseAccess =
                this.getAD_USER_WAREHOUSE_ACCESSInfo(null, "", "", "", false, true, "AND");

                DataTable userWarehouseProcessAccess =
                    this.getEM_PROCESS_ACCESSInfo(null, "", "", AD_USER_ID, "", onlyActiveRecords, false, "AND");

                if (this.checkIfTableContainesData(userWareHouseAccess))
                {
                    foreach (DataRow dr in userWarehouseProcessAccess.Rows)
                    {
                        if (dr["ISACTIVE"].ToString() == "Y")
                        {
                            userWareHouseAccess.Rows.Add(
                                    new object[] { dr["AD_CLINET_ID"],
                                               dr["AD_USER_ID"],
                                               dr["M_WAREHOUSE_ID"],
                                               dr["ISACTIVE"],
                                               dr["CREATED"],
                                               dr["CREATEDBY"],
                                               dr["UPDATED"],
                                               dr["UPDATEDBY"],
                                               "Y" });

                        }
                    }
                }

                return userWarehouseProcessAccess;
            }
            else
            {
                string whereClause = "";

                if (onlyActiveRecords)
                {
                    whereClause = "WHERE ISACTIVE = 'Y'";
                }
                else
                    whereClause = "WHERE (ISACTIVE = 'Y' OR ISACTIVE = 'N')";

                if (M_WAREHOUSE_ID != "")
                    whereClause = whereClause + " " + logicalConnector +
                        " M_WAREHOUSE_ID = '" + M_WAREHOUSE_ID + "'";

                if (AD_USER_ID != "")
                    whereClause = whereClause + " " + logicalConnector +
                        " AD_USER_ID = " + AD_USER_ID;

                whereClause = whereClause +
                    this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

                getRequestedTableInformation = "SELECT * " +
                                               "FROM " + dbSettingInformationHandler.dbTablePrefix + "AD_USER_WAREHOUSE_ACCESS " + whereClause;

                return (DataTable)executeSqlOnDB(getRequestedTableInformation);

            }            
        }
        
        public DataTable getAD_USER_ROLESInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_USER_ID, string AD_ROLE_ID, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure(dbSettingInformationHandler.dbTablePrefix + "AD_USER_ROLES");
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE (ISACTIVE = 'Y' || ISACTIVE = 'N')";


            if (AD_USER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_USER_ID = " + AD_USER_ID;

            if (AD_ROLE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_ROLE_ID = " + AD_ROLE_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM " + dbSettingInformationHandler.dbTablePrefix + "AD_USER_ROLES " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }

        public DataTable getAD_USERInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_USER_ID, string UserName, string PassWord, bool onlyActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure(dbSettingInformationHandler.dbTablePrefix + "AD_USER");
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
                                           "FROM " + dbSettingInformationHandler.dbTablePrefix + "AD_USER " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }


        public DataTable getM_WAREHOUSEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string M_WAREHOUSE_ID, bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure(dbSettingInformationHandler.dbTablePrefix + "M_WAREHOUSE");
            }


            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE AD_CLIENT_ID = 1000000 AND ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE AD_CLIENT_ID = 1000000 AND (ISACTIVE = 'Y' OR ISACTIVE = 'N')";

            if (M_WAREHOUSE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " M_WAREHOUSE_ID = " + M_WAREHOUSE_ID;

            if (AD_ORG_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_ORG_ID = '" + AD_ORG_ID + "'";
            
            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM " + dbSettingInformationHandler.dbTablePrefix + "M_WAREHOUSE " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }
        
        public DataTable getM_LOCATORInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_LOCATOR_ID, string M_WAREHOUSE_ID, bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure(dbSettingInformationHandler.dbTablePrefix + "M_LOCATOR");
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE AD_CLIENT_ID = 1000000 AND ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE AD_CLIENT_ID = 1000000 AND (ISACTIVE = 'Y' OR ISACTIVE = 'N')";

            if (M_LOCATOR_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " M_LOCATOR_ID = " + M_LOCATOR_ID;

            if (M_WAREHOUSE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " M_WAREHOUSE_ID = " + M_WAREHOUSE_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM " + dbSettingInformationHandler.dbTablePrefix + "M_LOCATOR " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }

        public DataTable getM_PRODUCT_CATEGORYInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_PRODUCT_CATEGORY_ID, bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure(dbSettingInformationHandler.dbTablePrefix + "M_PRODUCT_CATEGORY");
            }


            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE AD_CLIENT_ID = 1000000 AND ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE AD_CLIENT_ID = 1000000 AND (ISACTIVE = 'Y' OR ISACTIVE = 'N')";

            if (M_PRODUCT_CATEGORY_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " M_PRODUCT_CATEGORY_ID = " + M_PRODUCT_CATEGORY_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM " + dbSettingInformationHandler.dbTablePrefix + "M_PRODUCT_CATEGORY " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }

        public DataTable getC_UOMInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_UOM_ID, bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure(dbSettingInformationHandler.dbTablePrefix + "C_UOM");
            }


            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE  AD_CLIENT_ID = 1000000 AND ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE  AD_CLIENT_ID = 1000000 AND (ISACTIVE = 'Y' OR ISACTIVE = 'N')";

            if (C_UOM_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " C_UOM_ID = " + C_UOM_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM " + dbSettingInformationHandler.dbTablePrefix + "C_UOM " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }
        

        public DataTable getM_PRODUCTInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_PRODUCT_ID, bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure(dbSettingInformationHandler.dbTablePrefix + "M_PRODUCT");
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = whereClause + "ISACTIVE= 'Y'";
            }
            else
                whereClause = whereClause + "(ISACTIVE= 'Y' OR ISACTIVE= 'N')";

            if (M_PRODUCT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " M_PRODUCT_ID = " + M_PRODUCT_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string resultLimit = dbSettingInformationHandler.dbTablePrefix == "MySql" ? "" : "" ;

            if (dbSettingInformationHandler.DataBaseType == "MySql")
            {
                if (whereClause == "")
                    whereClause = "WHERE AD_CLIENT_ID = 1000000 limit 0 , 10";
                else
                    whereClause = "WHERE AD_CLIENT_ID = 1000000 AND ( " + whereClause + ") LIMIT 0 , 10";

            }
            else if (dbSettingInformationHandler.DataBaseType == "Oracle")
            {
                if (whereClause == "")
                    whereClause = "WHERE ROWNUM < 10 AND AD_CLIENT_ID = 1000000";
                else
                    whereClause = "WHERE ROWNUM < 10 AND AD_CLIENT_ID = 1000000 AND ( " + whereClause + ")";
            }

            
            getRequestedTableInformation = "SELECT * " +
                                           "FROM " + dbSettingInformationHandler.dbTablePrefix + "M_PRODUCT " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }


        public DataTable getM_MOVEMENTLINEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_MOVEMENTLINE_ID, string M_MOVEMENT_ID, bool onlyActiveRecords, 
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure(dbSettingInformationHandler.dbTablePrefix + "M_MOVEMENTLINE");
            }
            
            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = "WHERE ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE (ISACTIVE = 'Y' OR ISACTIVE = 'N')";

            if (M_MOVEMENTLINE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " M_MOVEMENTLINE_ID = " + M_MOVEMENTLINE_ID;

            if (M_MOVEMENT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " M_MOVEMENT_ID = " + M_MOVEMENT_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM " + dbSettingInformationHandler.dbTablePrefix + "M_MOVEMENTLINE " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }



        public DataTable getRV_DETAIL_STOCK_ACTIVITY_RPT(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_PRODUCT_ID, string M_LOCATOR_ID, bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("RV_DETAIL_STOCK_ACTIVITY_RPT");
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = whereClause + "ISACTIVE= 'Y'";
            }
            else
                whereClause = whereClause + "(ISACTIVE= 'Y' OR ISACTIVE= 'N')";

            if (M_PRODUCT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " M_PRODUCT_ID = " + M_PRODUCT_ID;

            if (M_LOCATOR_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " M_LOCATOR_ID = " + M_LOCATOR_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            if (whereClause == "")
                whereClause = "";// "WHERE ROWNUM < 10 AND AD_CLIENT_ID = 1000000";
            else
                whereClause = "WHERE " + whereClause;

            getRequestedTableInformation = "SELECT * " +
                                           "FROM RV_DETAIL_STOCK_ACTIVITY_RPT " + whereClause +
                                           " ORDER BY MOVEMENTDATE, M_TRANSACTION_ID ";
                                

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);

        }


        public DataTable getRV_SUMMARY_STOCK_ACTIVITY_RPT(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_PRODUCT_ID, string M_LOCATOR_ID, bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("RV_DETAIL_STOCK_ACTIVITY_RPT");
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = whereClause + "ISACTIVE= 'Y'";
            }
            else
                whereClause = whereClause + "(ISACTIVE= 'Y' OR ISACTIVE= 'N')";

            if (M_PRODUCT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " M_PRODUCT_ID = " + M_PRODUCT_ID;

            if (M_LOCATOR_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " M_LOCATOR_ID = " + M_LOCATOR_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            if (whereClause == "")
                whereClause = "";// "WHERE ROWNUM < 10 AND AD_CLIENT_ID = 1000000";
            else
                whereClause = "WHERE " + whereClause;

            getRequestedTableInformation = "SELECT M_PRODUCT_ID, NAME, M_LOCATOR_ID, VALUE, MOVEMENTTYPE, " +
                                                "SUM(MOVEMENTQTY) AS MOVEMENTQTY " +
                                           "FROM RV_DETAIL_STOCK_ACTIVITY_RPT " + whereClause + 
                                           " " + // Space between Where clause and Groupby Clause
                                           "GROUP BY M_PRODUCT_ID, NAME, M_LOCATOR_ID, VALUE, MOVEMENTTYPE " +
                                           "ORDER BY M_LOCATOR_ID, VALUE, NAME";

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }

        
        public DataTable getRV_DETAIL_STOCK_ACTIVITY_RPTproductList(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_PRODUCT_ID, string M_LOCATOR_ID, bool onlyActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("RV_DETAIL_STOCK_ACTIVITY_RPT");
            }

            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = whereClause + "ISACTIVE= 'Y'";
            }
            else
                whereClause = whereClause + "(ISACTIVE= 'Y' OR ISACTIVE= 'N')";

            if (M_PRODUCT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " M_PRODUCT_ID = " + M_PRODUCT_ID;

            if (M_LOCATOR_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " M_LOCATOR_ID = " + M_LOCATOR_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            if (whereClause == "")
                whereClause = "";// "WHERE ROWNUM < 10 AND AD_CLIENT_ID = 1000000";
            else
                whereClause = "WHERE " + whereClause;

            getRequestedTableInformation = "SELECT M_PRODUCT_ID, NAME " +
                                           "FROM RV_DETAIL_STOCK_ACTIVITY_RPT " + whereClause + 
                                           " GROUP BY M_PRODUCT_ID, NAME ORDER BY NAME";

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);

        }

        public DataTable getRV_STOCK_BALANCE_RPT(string M_PRODUCT_ID, string M_LOCATOR_ID, DateTime MOVEMENTDATE,
            bool onlyActiveRecords, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            
            string whereClause = "";

            if (onlyActiveRecords)
            {
                whereClause = whereClause + "ISACTIVE= 'Y'";
            }
            else
                whereClause = whereClause + "(ISACTIVE= 'Y' OR ISACTIVE= 'N')";

            if (M_PRODUCT_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " M_PRODUCT_ID = " + M_PRODUCT_ID;

            if (M_LOCATOR_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " M_LOCATOR_ID = " + M_LOCATOR_ID;

            if (MOVEMENTDATE == null)
                MOVEMENTDATE = DateTime.Now;
            
            whereClause = "(" + whereClause + ") " + " AND " +
                "MOVEMENTDATE <= '" +
                    MOVEMENTDATE.ToString(generalResultInformation.dateFormat) + "'";
            
            if (whereClause == "")
                whereClause = "";// "WHERE ROWNUM < 10 AND AD_CLIENT_ID = 1000000";
            else
                whereClause = "WHERE " + whereClause;

            getRequestedTableInformation = "SELECT M_PRODUCT_ID, NAME, M_LOCATOR_ID, VALUE, SUM(MOVEMENTQTY) AS ENDBALANCE " +
                                           "FROM RV_DETAIL_STOCK_ACTIVITY_RPT " + 
                                           whereClause + 
                                           " " +
                                           "GROUP BY M_PRODUCT_ID, NAME , M_LOCATOR_ID, VALUE " +
                                           "HAVING SUM(MOVEMENTQTY) != 0 " +
                                           "ORDER BY VALUE, NAME";

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
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
                whereClause = "WHERE ISACTIVE = 'Y'";
            }
            else
                whereClause = "WHERE (ISACTIVE = 'Y' || ISACTIVE = 'N')";

            if (M_WAREHOUSE_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " M_WAREHOUSE_ID = " + M_WAREHOUSE_ID;

            if (AD_USER_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " AD_USER_ID = " + AD_USER_ID;

            if (AD_STATION_ID != "")
                whereClause = whereClause + " " + logicalConnector +
                    " EM_STATION_ID = " + AD_STATION_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM EM_PROCESS_ACCESS " + whereClause;

            return (DataTable)executeSqlOnDB(getRequestedTableInformation);
        }

        #endregion
        



        public string getNextSequenceId(string Name, string AD_SEQUENCE_ID,
            string AD_ORG_ID, bool incrementToNextSequence)
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
                return this.getDataTableStructure(dbSettingInformationHandler.dbTablePrefix + "AD_SEQUENCE");
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
                    " " + dbSettingInformationHandler.upperCaseFunction + "(NAME) = '" + NAME.ToUpperInvariant().Replace("'", "''") + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            getRequestedTableInformation = "SELECT * " +
                                           "FROM " + dbSettingInformationHandler.dbTablePrefix + "AD_SEQUENCE " + whereClause;

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
    }
        
}
