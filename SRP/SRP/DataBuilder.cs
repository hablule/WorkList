using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;



namespace SRP
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
                        fieldSeparator+ " = '" + dt.Rows[rowIndex][primaryKeys[i].ToString()];
                    if ((i + 1) < primaryKeys.Length)
                    { primaryColIDCondition += "' and "; }
                    else
                    { primaryColIDCondition += "' )"; }
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


        public decimal roundOff(decimal number, uint precision)
        {
            string stNumber = number.ToString();
            if (!stNumber.Contains("."))
                return number;

            string[] numberSplited = stNumber.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            string intNumber = numberSplited[0];
            string floatNumber = numberSplited[1];
            if (precision >= floatNumber.Length)
                return number;
            string stroundedNumber = "";
            string truncatedfloatNumber = "";
            if (precision > 0)
            {
                truncatedfloatNumber = floatNumber.Substring(Convert.ToInt16(precision));
                stroundedNumber = stNumber.Remove((intNumber.Length + Convert.ToInt16(precision) + 1));
            }
            else
            {
                truncatedfloatNumber = floatNumber;
                stroundedNumber = intNumber;
            }
            string theRoundOffIndex = truncatedfloatNumber.Substring(0, 1);

            int roundoffIndex = Convert.ToInt16(theRoundOffIndex);
            decimal roundedNumber = Convert.ToDecimal(stroundedNumber);

            if (roundoffIndex < 5)
                return roundedNumber;
            return (roundedNumber + Convert.ToDecimal(1 / Math.Pow(10, Convert.ToDouble(precision))));
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
            
            dt = (DataTable)this.executeSqlOnSRP(getFileWithSpace);
            if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() != "")
            {
                fileName = (string)dt.Rows[0][0];
                filePath += fileName;
            }
            else
            {
                string getNextFileNumber = "Select count(FileName) From FileSize";
                Int32 newFileNo = Convert.ToInt32(((DataTable)this.executeSqlOnSRP(getNextFileNumber)).Rows[0][0]) + 1;
                string createNextFileNumber = "Insert into FileSize " +
                    "(FileName,ScripteNo) values ('LogSync_" +
                    "" + newFileNo.ToString() + ".sql',0)";
                this.executeSqlOnSRP(createNextFileNumber);
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
            dt3 = (DataTable)this.executeSqlOnSRP(theFilesize);
            Int32 fileNo = Convert.ToInt32(dt3.Rows[0][0]) + 1;
            string dmlIncreaseFileWriteSize = 
                "Update FileSize "+
                " set ScripteNo = " + fileNo.ToString() + 
                " Where FileName = '" + fileName + "'";
            this.executeSqlOnSRP(dmlIncreaseFileWriteSize);
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
                    filePath = dbSettingInformationHandler.SRPScriptDirectory;
                    extension = ".srp";
                    break;
                case "posWARINING":
                    filePath = dbSettingInformationHandler.SRPWarningDirectory;
                    extension = ".wrn";
                    break;
                case "posERROR":
                    filePath = dbSettingInformationHandler.SRPErrorDirectory;
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

        public object executeSqlOnSRP(string sqlCommand)
        {
            DataTable resultOfQuery = new DataTable();             
            int rowsAffected = 0;
            string connectionStatus;
            string mySqlDataBaseType = dbSettingInformationHandler.SRPDataBaseType;
            string mySqlHostName = dbSettingInformationHandler.SRPHostName;
            string mySqlDataBaseName = dbSettingInformationHandler.SRPDataBaseName;
            string mySqlUserName = dbSettingInformationHandler.SRPDBUserName;
            string mySqlPassWord = dbSettingInformationHandler.SRPDBPassword;
            string mySqlPort = dbSettingInformationHandler.SRPDBPort;            

            sqlCommand=sqlCommand.Replace("commSepartor", "`");

            persistanceClass SRPConnection = new persistanceClass(mySqlDataBaseType, mySqlHostName,
                mySqlDataBaseName, mySqlUserName, mySqlPassWord,mySqlPort);

            connectionStatus = SRPConnection.connectToDataBase(SRPConnection);
            if (connectionStatus == "Open")
            {
                if (sqlCommand.ToUpperInvariant().StartsWith("SELECT"))
                    resultOfQuery = SRPConnection.getDataBaseData(sqlCommand, SRPConnection);
                else if (sqlCommand.ToUpperInvariant().StartsWith("INSERT") ||
                    sqlCommand.ToUpperInvariant().StartsWith("UPDATE") ||
                    sqlCommand.ToUpperInvariant().StartsWith("DELETE"))
                {
                    rowsAffected = SRPConnection.updateDataBaseData(sqlCommand, SRPConnection);
                    SRPConnection.closeConnection(SRPConnection);
                    return rowsAffected;
                }
                
            }
            SRPConnection.closeConnection(SRPConnection);
            
            return resultOfQuery;
        }

       
        public DataTable clearRedundantRow(DataTable tableToClear)
        {
            return this.clearRedundantRow(tableToClear,new string [] {});
        }

        public DataTable clearRedundantRow(DataTable tableToClear, string PrimaryColumnName)
        {
            if (PrimaryColumnName == "")
                return this.clearRedundantRow(tableToClear, new string[] {});            
            return this.clearRedundantRow(tableToClear, new string[] { PrimaryColumnName });
        }
        
        private DataTable clearRedundantRow(DataTable tableToClear, string[] PrimaryColumnNames)
        {
            if (!this.checkIfTableContainesData(tableToClear))
                return tableToClear;
            

            foreach (string PrimaryColumnName in PrimaryColumnNames)
            {
                if (PrimaryColumnName != "" &&
                    !tableToClear.Columns.Contains(PrimaryColumnName))
                {
                    tableToClear.Rows.Clear();
                    return tableToClear;
                }
            }

            bool rowIsRedundant = true;
            if (PrimaryColumnNames.Length > 0 && PrimaryColumnNames[0] != "")
            {
                for (int rowCounter = tableToClear.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
                {                    
                    for (int rowCounter2 = rowCounter - 1;
                        rowCounter2 >= 0; rowCounter2--)
                    {
                        rowIsRedundant = true;
                        foreach (string PrimaryColumnName in PrimaryColumnNames)
                        {
                            if (tableToClear.Rows[rowCounter][PrimaryColumnName].ToString() !=
                                  tableToClear.Rows[rowCounter2][PrimaryColumnName].ToString())
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
            }
            else
            {
                for (int rowCounter = tableToClear.Rows.Count - 1;
                rowCounter >= 0; rowCounter--)
                {                    
                    for (int rowCounter2 = rowCounter - 1; rowCounter2 >= 0; rowCounter2--)
                    {
                        rowIsRedundant = true;
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
            }
            
            return tableToClear;
        }


        public DataTable mergeTables(DataTable firstTable, DataTable secondTable, 
            string comparisionColumnName, bool mergeOnlyCommonRows)
        {
            
            ///In case of schema miss match b/n the two table, comparisioncolumn should exist
            /// If the second table contains muliple rows which contains similar value for comparision
            /// column, only the first record will be reflected on the final merger.

            firstTable = clearRedundantRow(firstTable, comparisionColumnName);
            secondTable = clearRedundantRow(secondTable, comparisionColumnName);

            bool schemaDoesNotMatch = false;
            bool schemaMatchingError = false;
            
            // the if block is used only to hide the variable inside the block
            if (true)
            {
                //Check if Schema of both tables are similar

                string secondTableColumnName = "";
                Type secondTableColumnDType = typeof(String);
                for (int secondTbColCounter = 0;
                     secondTbColCounter <= secondTable.Columns.Count - 1;
                     secondTbColCounter++)
                {
                    secondTableColumnName = secondTable.Columns[secondTbColCounter].ColumnName;
                    secondTableColumnDType = secondTable.Columns[secondTbColCounter].DataType;
                    if (!firstTable.Columns.Contains(secondTableColumnName))
                    {
                        schemaDoesNotMatch = true;
                        firstTable.Columns.Add(secondTableColumnName, secondTableColumnDType);
                    }
                    else if (firstTable.Columns[secondTableColumnName].DataType != secondTableColumnDType)
                    {
                        schemaDoesNotMatch = true;
                        schemaMatchingError = true;
                    }
                }
            }

     //If schema is unmatchable return empty table
            if (schemaMatchingError)
            {
                firstTable.Clear();
                return firstTable;
            }

     //If schema is different yet matchable... ...
            if (schemaDoesNotMatch)
            {
                //... check commonality column and match
                if (comparisionColumnName != "" &&
                    firstTable.Columns.Contains(comparisionColumnName) &&
                    secondTable.Columns.Contains(comparisionColumnName))
                {
                    string secondTableColumnName = "";

                    //If it is union merge migrate the content of the second table to the first ... 

                    if (!mergeOnlyCommonRows)
                    {
                        // ... first those with mathcing record in the first table
                        for (int firTbRowCounter = firstTable.Rows.Count - 1;
                            firTbRowCounter >= 0; firTbRowCounter--)
                        {
                            for (int scndTbRowCounter = secondTable.Rows.Count - 1;
                                scndTbRowCounter >= 0; scndTbRowCounter--)
                            {
                                if (firstTable.Rows[firTbRowCounter][comparisionColumnName].ToString() ==
                                    secondTable.Rows[scndTbRowCounter][comparisionColumnName].ToString())
                                {
                                    for (int scndTbColumnCounter = 0;
                                        scndTbColumnCounter <= secondTable.Columns.Count - 1;
                                        scndTbColumnCounter++)
                                    {
                                        secondTableColumnName =
                                            secondTable.Columns[scndTbColumnCounter].ColumnName;

                                        firstTable.Rows[firTbRowCounter][secondTableColumnName] =
                                            secondTable.Rows[scndTbRowCounter][secondTableColumnName];
                                    }
                                    secondTable.Rows.RemoveAt(scndTbRowCounter);
                                }
                            }
                        }

                        //... then try to add what is left in the second table to the first

                        for (int scndTbRowCounter = secondTable.Rows.Count - 1;
                                scndTbRowCounter >= 0; scndTbRowCounter--)
                        {
                            DataRow dtNewFirstTableDataRow = firstTable.NewRow();

                            for (int scndTbColumnCounter = 0;
                                 scndTbColumnCounter <= secondTable.Columns.Count - 1;
                                 scndTbColumnCounter++)
                            {
                                secondTableColumnName =
                                    secondTable.Columns[scndTbColumnCounter].ColumnName;

                                dtNewFirstTableDataRow[secondTableColumnName] =
                                    secondTable.Rows[scndTbRowCounter][secondTableColumnName];
                            }

                            try
                            {
                                firstTable.Rows.Add(dtNewFirstTableDataRow);
                            }
                            catch (Exception e)
                            { }
                        }

                        // return the merged first table
                        return firstTable;
                    }
                    // If the merge type is common(intersection)
                    else
                    {
                        bool recordFounInSecondTable = false;

                        for (int firTbRowCounter = firstTable.Rows.Count - 1;
                            firTbRowCounter >= 0; firTbRowCounter--)
                        {
                            recordFounInSecondTable = false;

                            // ... check if each record in first row exist in second table ...
                            for (int scndTbRowCounter = secondTable.Rows.Count - 1;
                                scndTbRowCounter >= 0; scndTbRowCounter--)
                            {
                                //.... if so map the record in the second table to the first
                                if (firstTable.Rows[firTbRowCounter][comparisionColumnName].ToString() ==
                                    secondTable.Rows[scndTbRowCounter][comparisionColumnName].ToString())
                                {
                                    for (int scndTbColumnCounter = 0;
                                        scndTbColumnCounter <= secondTable.Columns.Count - 1;
                                        scndTbColumnCounter++)
                                    {
                                        secondTableColumnName =
                                            secondTable.Columns[scndTbColumnCounter].ColumnName;

                                        firstTable.Rows[firTbRowCounter][secondTableColumnName] =
                                            secondTable.Rows[scndTbRowCounter][secondTableColumnName];
                                    }
                                    secondTable.Rows.RemoveAt(scndTbRowCounter);
                                    recordFounInSecondTable = true;
                                }
                            }
                            //.... if it does not discard the record in the first table.
                            if (!recordFounInSecondTable)
                            {
                                firstTable.Rows.RemoveAt(firTbRowCounter);
                            }
                        }

                        //... and Return what is left in the first table.
                        return firstTable;
                    }
                }

                //... if commonality column is not given consider cardinality b/n first and Second Table

                //... else return empty table
                else
                {
                    firstTable.Clear();
                    return firstTable;
                }
            }

      //If schema is perfectly Similar

            // if the merge type is Union
                // merge the two tables remove redundunt row and return the resulting table
            if (!mergeOnlyCommonRows)
            {
                firstTable.Merge(secondTable,true, MissingSchemaAction.Add);
                firstTable = clearRedundantRow(firstTable, comparisionColumnName);
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

            string criterionField = "";
            string criterionLogic = "";
            string criterionValue = "";
            
                for (int rowCounter = 0; rowCounter <= _criteriaTable.Rows.Count - 1; rowCounter++)
                {
                    criterionField = _criteriaTable.Rows[rowCounter]["Field"].ToString();
                    criterionLogic = _criteriaTable.Rows[rowCounter]["Criterion"].ToString();
                    criterionValue = _criteriaTable.Rows[rowCounter]["Value"].ToString();

                    if (criterionField == "" ||
                        criterionLogic == "" ||
                        criterionValue == "")
                    {
                        continue;
                    }
                        if (_criteriaTable.Rows[rowCounter]["Value"].GetType().ToString() ==
                            "System.String" ||
                            _criteriaTable.Rows[rowCounter]["Value"].GetType().ToString() ==
                            "System.DateTime")
                            delimApostrophy = "'";
                        else
                            delimApostrophy = "";

                        if (criterionLogic.ToUpperInvariant() != "LIKE")
                            theLikeConnector = "";
                        else
                        {
                            delimApostrophy = "'";
                            theLikeConnector = "%";
                            criterionValue = criterionValue.Replace(" ", "%");
                        }
                    
                        theCriteriaClase = theCriteriaClase +
                            "`" + criterionField.ToUpperInvariant() + "`" +
                            " " + criterionLogic +
                            " " + delimApostrophy + theLikeConnector +
                            criterionValue.Replace("'", "''").Replace("\\","\\\\") + theLikeConnector +
                            delimApostrophy;
                    
                    if ((rowCounter+1) <= _criteriaTable.Rows.Count-1)
                        if(_criteriaTable.Rows[rowCounter+1]["Field"].ToString() != "" ||
                            _criteriaTable.Rows[rowCounter+1]["Criterion"].ToString() != "" ||
                            _criteriaTable.Rows[rowCounter+1]["Value"].ToString() != "")
                            theCriteriaClase = theCriteriaClase + " " + _criteriaLogicalConnector + " ";
                }

                theCriteriaClase = theCriteriaClase + ")";
                if (theCriteriaClase.Length <= (4 + wherClauselogicalConnector.Length))
                    theCriteriaClase = "";
            return theCriteriaClase.Replace("  "," ");
        }


        public string[] getSRPDBTablePrimaryKey(string tableName)
        {
            string[] primarykeys = { "" };
            tableName = tableName.ToUpperInvariant();

            if (tableName == "C_COUNTRY")
            { primarykeys = new string[] { "C_COUNTRY_ID" }; }
            else if (tableName == "C_CITY")
            { primarykeys = new string[] { "C_CITY_ID" }; }
            else if (tableName == "C_LOCALITY")
            { primarykeys = new string[] { "C_LOCALITY_ID" }; }
            else if (tableName == "C_SUBLOCALITY")
            { primarykeys = new string[] { "C_SUBLOCALITY_ID" }; }
            else if (tableName == "M_UOM")
            { primarykeys = new string[] { "M_UOM_ID" }; }
            else if (tableName == "M_PRODUCTCATEGORY")
            { primarykeys = new string[] { "M_PRODUCTCATEGORY_ID" }; }
            else if (tableName == "M_PRODUCT" || tableName == "V_PRDUCTCOST" || tableName == "V_STORAGESUMMARY")
            { primarykeys = new string[] { "M_PRODUCT_ID" }; }
            else if (tableName == "M_UOM_CONVERSION")
            { primarykeys = new string[] { "M_UOM_CONVERSION_ID" }; }            
            else if (tableName == "M_BPARTNER")
            { primarykeys = new string[] { "M_BPARTNER_ID" }; }
            else if (tableName == "M_SHOP")
            { primarykeys = new string[] { "M_SHOP_ID" }; }
            else if (tableName == "AD_ORG")
            { primarykeys = new string[] { "AD_ORG_ID" }; }
            else if (tableName == "U_USER")
            { primarykeys = new string[] { "U_USER_ID" }; }
            else if (tableName == "U_SEQUENCE")
            { primarykeys = new string[] { "U_SEQUENCE_ID" }; }
            else if (tableName == "T_TRANSACTION")
            { primarykeys = new string[] { "T_TRANSACTION_ID" }; }
            else if (tableName == "T_TRXDETAIL" || tableName == "V_TRXDETAIL")
            { primarykeys = new string[] { "T_TRXDETAIL_ID" }; }
            else if (tableName == "T_MOVEMENTDETAIL" || tableName == "V_MOVEMENTDETAIL")
            { primarykeys = new string[] { "T_MOVEMENTDETAIL_ID" }; }
            else if (tableName == "T_MOVEMENT")
            { primarykeys = new string[] { "T_MOVEMENT_ID" }; }
            else if (tableName == "M_WAREHOUSE")
            { primarykeys = new string[] { "M_WAREHOUSE_ID" }; }
            else if (tableName == "U_ORGACCESS")
            { primarykeys = new string[] {"AD_ORG_ID", "M_SHOP_ID", "U_USER_ID" }; }
            else if (tableName == "U_FORMACCESS")
            { primarykeys = new string[] { "M_SHOP_ID", "U_USER_ID", "FORMNAME" }; }
            else if (tableName == "U_SHOPACCESS")
            { primarykeys = new string[] { "M_SHOP_ID", "U_USER_ID" }; }
            else if (tableName == "U_WAREHOUSEACCESS")
            { primarykeys = new string[] { "M_SHOP_ID", "U_USER_ID", "M_WAREHOUSE_ID" }; }
            else if (tableName == "Q_STOCK" || tableName == "V_STORAGEDETAIL")
            { primarykeys = new string[] { "M_PRODUCT_ID", "M_WAREHOUSE_ID" }; }
            else if (tableName == "Q_COST")
            { primarykeys = new string[] { "M_PRODUCT_ID"}; }
            else if (tableName == "U_ACTIVESHOPID")
            { primarykeys = new string[] { "M_SHOP_ID" }; }
            else if (tableName == "T_INVENTORYUSEDETAIL" || tableName == "V_INVENTORYUSEDETAIL")
            { primarykeys = new string[] { "T_INVENTORYUSEDETAIL_ID" }; }
            else if (tableName == "T_INVENTORYUSE")
            { primarykeys = new string[] { "T_INVENTORYUSE_ID" }; }
            else if (tableName == "T_PHYSICALCOUNT")
            { primarykeys = new string[] { "T_PHYSICALCOUNT_ID" }; }
            else if (tableName == "T_PHYSICALCOUNTDETAIL" || tableName == "V_PHYSICALCOUNTDETAIL")
            { primarykeys = new string[] { "T_PHYSICALCOUNTDETAIL_ID" }; }
            else if (tableName == "M_TRANSACTION" || tableName == "V_TRANSACTIONSUMMARY")
            { primarykeys = new string[] { "M_TRANSACTION_ID" }; }
            return primarykeys;
        }
        
        private DataTable getDataTableStructure(string tableName)
        {

            string[] Tableprimarykeys = this.getSRPDBTablePrimaryKey(tableName);
            
            string theWhereClose = "Where 1 ";
            foreach (string primaryKey in Tableprimarykeys)
            {
                if (primaryKey != "")
                    theWhereClose = theWhereClose + " AND `" + primaryKey + "` = '0'";
            }
            string getStructureForTable = "SELECT *" +
                                          " FROM `" + tableName + "` " + theWhereClose;
            DataTable result = (DataTable)executeSqlOnSRP(getStructureForTable);
            result.Clear();
            //result.Columns.RemoveAt(result.Columns.IndexOf("CREATED"));
            //result.Columns.RemoveAt(result.Columns.IndexOf("UPDATED"));
            return result;
        }

        public DataTable getC_COUNTRYInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_COUNTRY_ID, string NAME, triStateBool ActiveRecords,
                triStateBool DefaultRecord, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("C_COUNTRY");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (DefaultRecord != triStateBool.ignor)
            {
                if (DefaultRecord == triStateBool.yes)
                    whereClause += logicalConnector + "`ISDEFAULT` = 'Y'";
                else if (DefaultRecord == triStateBool.No)
                    whereClause += logicalConnector + "`ISDEFAULT` = 'N'";
            }

            if (C_COUNTRY_ID != "")
                whereClause += logicalConnector + "`C_COUNTRY_ID` = " + C_COUNTRY_ID;

            if (NAME != "")
                whereClause += logicalConnector + "`NAME` = '" + NAME + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) &&
                logicalConnector.Replace(" ", "").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `C_COUNTRY` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }
        
        public DataTable getC_CITYInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_CITY_ID, string C_COUNTRY_ID, string NAME, triStateBool ActiveRecords,
                triStateBool DefaultRecord, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("C_CITY");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (DefaultRecord != triStateBool.ignor)
            {
                if (DefaultRecord == triStateBool.yes)
                    whereClause += logicalConnector + "`ISDEFAULT` = 'Y'";
                else if (DefaultRecord == triStateBool.No)
                    whereClause += logicalConnector + "`ISDEFAULT` = 'N'";
            }

            if (C_CITY_ID != "")
                whereClause += logicalConnector + "`C_CITY_ID` = " + C_CITY_ID;

            if (C_COUNTRY_ID != "")
                whereClause += logicalConnector + "`C_COUNTRY_ID` = " + C_COUNTRY_ID;

            if (NAME != "")
                whereClause += logicalConnector + "`NAME` = '" + NAME + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE ";
            if (whereClause.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length >= 3)
            {
                whereClause = stWhereClauseStarter + whereClause;
                whereClause = whereClause.Replace(stWhereClauseStarter + logicalConnector, stWhereClauseStarter);
            }

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `C_CITY` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }

        public DataTable getC_LOCALITYInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_LOCALITY_ID, string C_CITY_ID, string M_PARENTLOCALITY_ID, string NAME, 
                triStateBool ActiveRecords, triStateBool ISSUMMARY, bool structureOnly,
                string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("C_LOCALITY");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (ISSUMMARY != triStateBool.ignor)
            {
                if (ISSUMMARY == triStateBool.yes)
                    whereClause += logicalConnector + "`ISSUMMARY` = 'Y'";
                else if (ISSUMMARY == triStateBool.No)
                    whereClause += logicalConnector + "`ISSUMMARY` = 'N'";
            }

            if (C_LOCALITY_ID != "")
                whereClause += logicalConnector + "`C_LOCALITY_ID` = " + C_LOCALITY_ID;

            if (M_PARENTLOCALITY_ID != "")
                whereClause += logicalConnector + "`M_PARENTLOCALITY_ID` = " + M_PARENTLOCALITY_ID;

            if (C_CITY_ID != "")
                whereClause += logicalConnector + "`C_CITY_ID` = " + C_CITY_ID;

            if (NAME != "")
                whereClause += logicalConnector + "`NAME` = '" + NAME + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) && 
                logicalConnector.Replace(" ","").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `C_LOCALITY` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }

        public DataTable getC_SUBLOCALITYInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string C_SUBLOCALITY_ID, string C_LOCALITY_ID, string NAME, string M_PARENTSUBLOC_ID,
                triStateBool ISSUMMARY, triStateBool ActiveRecords,
                bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("C_SUBLOCALITY");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (ISSUMMARY != triStateBool.ignor)
            {
                if (ISSUMMARY == triStateBool.yes)
                    whereClause += logicalConnector + "`ISSUMMARY` = 'Y'";
                else if (ISSUMMARY == triStateBool.No)
                    whereClause += logicalConnector + "`ISSUMMARY` = 'N'";
            }

            if (C_LOCALITY_ID != "")
                whereClause += logicalConnector + "`C_LOCALITY_ID` = " + C_LOCALITY_ID;

            if (C_SUBLOCALITY_ID != "")
                whereClause += logicalConnector + "`C_SUBLOCALITY_ID` = " + C_SUBLOCALITY_ID;

            if (M_PARENTSUBLOC_ID != "")
                whereClause += logicalConnector + "`M_PARENTSUBLOC_ID` = " + M_PARENTSUBLOC_ID;

            if (NAME != "")
                whereClause += logicalConnector + "`NAME` = '" + NAME + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) && 
                logicalConnector.Replace(" ","").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `C_SUBLOCALITY` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }

        public DataTable getM_UOMInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_UOM_ID, string ABBRIVATION, string NAME, triStateBool ActiveRecords,
                bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("M_UOM");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (M_UOM_ID != "")
                whereClause += logicalConnector + "`M_UOM_ID` = " + M_UOM_ID;

            if (ABBRIVATION != "")
                whereClause += logicalConnector + "`ABBRIVATION` = " + ABBRIVATION;

            if (NAME != "")
                whereClause += logicalConnector + "`NAME` = '" + NAME + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) && 
                logicalConnector.Replace(" ","").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `M_UOM` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }

        public DataTable getM_PRODUCTCATEGORYInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_PRODUCTCATEGORY_ID, string NAME, triStateBool ActiveRecords,
                bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("M_PRODUCTCATEGORY");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (M_PRODUCTCATEGORY_ID != "")
                whereClause += logicalConnector + "`M_PRODUCTCATEGORY_ID` = " + M_PRODUCTCATEGORY_ID;

            if (NAME != "")
                whereClause += logicalConnector + "`NAME` = '" + NAME + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) && 
                logicalConnector.Replace(" ","").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `M_PRODUCTCATEGORY` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }

        public DataTable getM_PRODUCTInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_PRODUCT_ID, string M_UOM_ID, string M_PRODUCTCATEGORY_ID, string CODE, string NAME,
			string PRODUCTTYPE, string UPC_EAN, string IMAGEPATH, triStateBool ActiveRecords, 
            bool structureOnly, string logicalConnector, int resultLimit)
		{
			string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("M_PRODUCT");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }
			
			if (M_PRODUCT_ID != "")
                whereClause += logicalConnector + "`M_PRODUCT_ID` = " + M_PRODUCT_ID;
				
			if (M_UOM_ID != "")
                whereClause += logicalConnector + "`M_UOM_ID` = " + M_UOM_ID;

            if (M_PRODUCTCATEGORY_ID != "")
                whereClause += logicalConnector + "`M_PRODUCTCATEGORY_ID` = " + M_PRODUCTCATEGORY_ID;
			
			if (CODE != "")
                whereClause += logicalConnector + "`CODE` LIKE '%" + CODE + "%'";
			
            if (NAME != "")
                whereClause += logicalConnector + "`NAME` LIKE '%" + NAME + "%'";
				
			if (PRODUCTTYPE != "")
                whereClause += logicalConnector + "`PRODUCTTYPE` = '" + PRODUCTTYPE + "'";
			
			if (UPC_EAN != "")
                whereClause += logicalConnector + "`UPC_EAN` = '" + UPC_EAN + "'";
			
			if (IMAGEPATH != "")
                whereClause += logicalConnector + "`IMAGEPATH` = '" + IMAGEPATH + "'";
			
            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) && 
                logicalConnector.Replace(" ","").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                               "FROM `M_PRODUCT` " + whereClause;
            if (resultLimit > 0)         
                getRequestedTableInformation = 
                    getRequestedTableInformation + " LIMIT 0 ," + resultLimit;
            

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
		}

        public DataTable getM_UOM_CONVERSIONInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_BASE_UOM_ID, string M_DRIVED_UOM_ID, string M_PRODUCT_ID, decimal MULTIPLIER,
                triStateBool ActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("M_UOM_CONVERSION");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (M_BASE_UOM_ID != "")
                whereClause += logicalConnector + "`M_BASE_UOM_ID` = " + M_BASE_UOM_ID;

            if (M_DRIVED_UOM_ID != "")
                whereClause += logicalConnector + "`M_DRIVED_UOM_ID` = " + M_DRIVED_UOM_ID;

            if (M_PRODUCT_ID != "")
                whereClause += logicalConnector + "`M_PRODUCT_ID` = " + M_PRODUCT_ID;

            if (MULTIPLIER != 0)
                whereClause += logicalConnector + "`MULTIPLIER` = " + MULTIPLIER.ToString();

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) &&
                logicalConnector.Replace(" ", "").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `M_UOM_CONVERSION` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }
        
        public DataTable getM_BPARTNERInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_BPARTNER_ID, string NAME, triStateBool ActiveRecords, 
            triStateBool ISVENDOR, triStateBool ISCUSTOMER, bool structureOnly, 
            string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("M_BPARTNER");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (ISVENDOR != triStateBool.ignor)
            {
                if (ISVENDOR == triStateBool.yes)
                    whereClause += logicalConnector + "`ISVENDOR` = 'Y'";
                else if (ISVENDOR == triStateBool.No)
                    whereClause += logicalConnector + "`ISVENDOR` = 'N'";
            }

            if (ISCUSTOMER != triStateBool.ignor)
            {
                if (ISCUSTOMER == triStateBool.yes)
                    whereClause += logicalConnector + "`ISCUSTOMER` = 'Y'";
                else if (ISCUSTOMER == triStateBool.No)
                    whereClause += logicalConnector + "`ISCUSTOMER` = 'N'";
            }

            if (M_BPARTNER_ID != "")
                whereClause += logicalConnector + "`M_BPARTNER_ID` = " + M_BPARTNER_ID;

            if (NAME != "")
                whereClause += logicalConnector + "`NAME` = '" + NAME + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) && 
                logicalConnector.Replace(" ","").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `M_BPARTNER` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }

        public DataTable getAD_ORGInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string AD_ORG_ID, string NAME, triStateBool ActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("AD_ORG");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (AD_ORG_ID != "")
                whereClause += logicalConnector + "`AD_ORG_ID` = " + AD_ORG_ID;

            if (NAME != "")
                whereClause += logicalConnector + "`NAME` = '" + NAME + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) &&
                logicalConnector.Replace(" ", "").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `AD_ORG` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }
        

        
        public DataTable getM_SHOPInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_SHOP_ID, string NAME, triStateBool ActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("M_SHOP");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (M_SHOP_ID != "")
                whereClause += logicalConnector + "`M_SHOP_ID` = " + M_SHOP_ID;

            if (NAME != "")
                whereClause += logicalConnector + "`NAME` = '" + NAME + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) && 
                logicalConnector.Replace(" ","").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `M_SHOP` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }
        
        public DataTable getM_WarehouseInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_WAREHOUSE_ID, string NAME, triStateBool AllowNegative, triStateBool ActiveRecords,
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("M_WAREHOUSE");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (AllowNegative != triStateBool.ignor)
            {
                if (AllowNegative == triStateBool.yes)
                    whereClause += logicalConnector + "`ALLOWNEGATIVE` = 'Y'";
                else if (AllowNegative == triStateBool.No)
                    whereClause += logicalConnector + "`ALLOWNEGATIVE` = 'N'";
            }            

            if (M_WAREHOUSE_ID != "")
                whereClause += logicalConnector + "`M_WAREHOUSE_ID` = " + M_WAREHOUSE_ID;

            if (NAME != "")
                whereClause += logicalConnector + "`NAME` = '" + NAME + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) &&
                logicalConnector.Replace(" ", "").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `M_WAREHOUSE` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }

        public DataTable getU_USERInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
               string U_USER_ID, string NAME, string USERNAME, string PASSWORD,
                   triStateBool ActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("U_USER");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (U_USER_ID != "")
                whereClause += logicalConnector + "`U_USER_ID` = '" + U_USER_ID + "'";

            if (USERNAME != "")
                whereClause += logicalConnector + "`USERNAME` = '" + USERNAME + "'";

            if (PASSWORD != "")
                whereClause += logicalConnector + "`PASSWORD` = '" + PASSWORD + "'";

            if (NAME != "")
                whereClause += logicalConnector + "`NAME` = '" + NAME + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) && 
                logicalConnector.Replace(" ","").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `U_USER` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }


        public DataTable getU_SEQUENCEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
               string U_SEQUENCE_ID, string NAME, triStateBool ActiveRecords, triStateBool ISTABLEID,
               string BASEDOC, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("U_SEQUENCE");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                whereClause += logicalConnector + "`ISACTIVE` = '" + 
                        ActiveRecords.ToString().Substring(0, 1).ToUpperInvariant() + "'";
            }

            if (ISTABLEID != triStateBool.ignor)
            {
                whereClause += logicalConnector + "`ISTABLEID` = '" +
                        ISTABLEID.ToString().Substring(0, 1).ToUpperInvariant() + "'";
            }



            if (U_SEQUENCE_ID != "")
                whereClause += logicalConnector + "`U_SEQUENCE_ID` = " + U_SEQUENCE_ID;

            if (NAME != "")
                whereClause += logicalConnector + 
                    "UCASE(`NAME`) = '" + NAME.Replace("'", "''") + "'";

            if (BASEDOC != "")
                whereClause += logicalConnector +
                    "UCASE(`BASEDOC`) = '" + BASEDOC.Replace("'", "''").ToUpperInvariant() + "'";



            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) && 
                logicalConnector.Replace(" ","").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `U_SEQUENCE` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }

        public DataTable getU_FORMACCESS(DataTable criteriaTable, string criteriaTableLogicalConnector,
                string M_SHOP_ID, string U_USER_ID, string FORMNAME, accessLevel userAccess,
                triStateBool ActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("U_FORMACCESS");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (userAccess != accessLevel.ignor)
            {
                whereClause += 
                    logicalConnector + "`ACCESSLEVEL` = '"+ userAccess.ToString() +"'";
            }

            if (M_SHOP_ID != "")
                whereClause +=
                    logicalConnector + "`M_SHOP_ID` = " + M_SHOP_ID;

            if (U_USER_ID != "")
                whereClause +=
                    logicalConnector + "`U_USER_ID` = " + U_USER_ID;

            if (FORMNAME != "")
                whereClause +=
                    logicalConnector + "`FORMNAME` = '" + FORMNAME + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) &&
                logicalConnector.Replace(" ", "").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `U_FORMACCESS` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }

        public DataTable getU_SHOPACCESS(DataTable criteriaTable, string criteriaTableLogicalConnector,
                string M_SHOP_ID, string U_USER_ID, accessLevel userAccess,
                triStateBool ActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("U_SHOPACCESS");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (userAccess != accessLevel.ignor)
            {
                whereClause +=
                    logicalConnector + "`ACCESSLEVEL` = '" + userAccess.ToString() + "'";
            }

            if (M_SHOP_ID != "")
                whereClause +=
                    logicalConnector + "`M_SHOP_ID` = " + M_SHOP_ID;

            if (U_USER_ID != "")
                whereClause +=
                    logicalConnector + "`U_USER_ID` = " + U_USER_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) &&
                logicalConnector.Replace(" ", "").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `U_SHOPACCESS` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }


        public DataTable getU_ORGACCESS(DataTable criteriaTable, string criteriaTableLogicalConnector,
                string M_SHOP_ID, string AD_ORG_ID, string U_USER_ID, accessLevel userAccess,
                triStateBool ActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("U_ORGACCESS");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (userAccess != accessLevel.ignor)
            {
                whereClause +=
                    logicalConnector + "`ACCESSLEVEL` = '" + userAccess.ToString() + "'";
            }

            if (M_SHOP_ID != "")
                whereClause +=
                    logicalConnector + "`M_SHOP_ID` = " + M_SHOP_ID;
            
            if (AD_ORG_ID != "")
                whereClause +=
                    logicalConnector + "`AD_ORG_ID` = " + AD_ORG_ID;

            if (U_USER_ID != "")
                whereClause +=
                    logicalConnector + "`U_USER_ID` = " + U_USER_ID;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) &&
                logicalConnector.Replace(" ", "").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `U_ORGACCESS` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }


        public DataTable getU_ACTIVESHOPID(bool structureOnly)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("U_ACTIVESHOPID");
            }

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `U_ACTIVESHOPID` ";

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }

        public DataTable getU_WAREHOUSEACCESS(DataTable criteriaTable, string criteriaTableLogicalConnector,
                string M_SHOP_ID, string U_USER_ID, string M_WAREHOUSE_ID, triStateBool ActiveRecords,
                triStateBool CANSALEFROM, triStateBool CANBUYFOR, triStateBool CANMOVEFORM,triStateBool CANMOVETO,
                triStateBool CANUSEFROM, triStateBool CANCOUNT, triStateBool CANREAD, bool structureOnly, 
                string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("U_WAREHOUSEACCESS");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (M_SHOP_ID != "")
                whereClause += 
                    logicalConnector + "`M_SHOP_ID` = " + M_SHOP_ID;

            if (U_USER_ID != "")
                whereClause += 
                    logicalConnector + "`U_USER_ID` = " + U_USER_ID;

            if (M_WAREHOUSE_ID != "")
                whereClause += 
                    logicalConnector + "`M_WAREHOUSE_ID` = " + M_WAREHOUSE_ID;

            if (CANSALEFROM != triStateBool.ignor)
            {
                if (CANSALEFROM == triStateBool.yes)
                    whereClause += logicalConnector + "`CANSALEFROM` = 'Y'";
                else if (CANSALEFROM == triStateBool.No)
                    whereClause += logicalConnector + "`CANSALEFROM` = 'N'";
            }

            if (CANBUYFOR != triStateBool.ignor)
            {
                if (CANBUYFOR == triStateBool.yes)
                    whereClause += logicalConnector + "`CANBUYFOR` = 'Y'";
                else if (CANBUYFOR == triStateBool.No)
                    whereClause += logicalConnector + "`CANBUYFOR` = 'N'";
            }

            if (CANMOVEFORM != triStateBool.ignor)
            {
                if (CANMOVEFORM == triStateBool.yes)
                    whereClause += logicalConnector + "`CANMOVEFORM` = 'Y'";
                else if (CANMOVEFORM == triStateBool.No)
                    whereClause += logicalConnector + "`CANMOVEFORM` = 'N'";
            }

            if (CANMOVETO != triStateBool.ignor)
            {
                if (CANMOVETO == triStateBool.yes)
                    whereClause += logicalConnector + "`CANMOVETO` = 'Y'";
                else if (CANMOVETO == triStateBool.No)
                    whereClause += logicalConnector + "`CANMOVETO` = 'N'";
            }

            if (CANUSEFROM != triStateBool.ignor)
            {
                if (CANUSEFROM == triStateBool.yes)
                    whereClause += logicalConnector + "`CANUSEFROM` = 'Y'";
                else if (CANUSEFROM == triStateBool.No)
                    whereClause += logicalConnector + "`CANUSEFROM` = 'N'";
            }

            if (CANCOUNT != triStateBool.ignor)
            {
                if (CANCOUNT == triStateBool.yes)
                    whereClause += logicalConnector + "`CANCOUNT` = 'Y'";
                else if (CANCOUNT == triStateBool.No)
                    whereClause += logicalConnector + "`CANCOUNT` = 'N'";
            }


            if (CANREAD != triStateBool.ignor)
            {
                if (CANREAD == triStateBool.yes)
                    whereClause += logicalConnector + "`CANREAD` = 'Y'";
                else if (CANREAD == triStateBool.No)
                    whereClause += logicalConnector + "`CANREAD` = 'N'";
            }

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) &&
                logicalConnector.Replace(" ", "").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `U_WAREHOUSEACCESS` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);

        }
        
        public DataTable getT_TRANSACTIONInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                string T_TRANSACTION_ID, string DOCUMENTNO, string M_BPARTNER_ID, DateTime TRXDATE,
                    bool considerDatePrameter, triStateBool ISSALESTRX, triStateBool ActiveRecords,
                    triStateBool PROCESSED, transactionStatus DOCSTATUS,
				    bool structureOnly, string logicalConnector)
		{
			string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("T_TRANSACTION");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }
			
			if (ISSALESTRX != triStateBool.ignor)
            {
                if (ISSALESTRX == triStateBool.yes)
                    whereClause += logicalConnector + "`ISSALESTRX` = 'Y'";
                else if (ISSALESTRX == triStateBool.No)
                    whereClause += logicalConnector + "`ISSALESTRX` = 'N'";
            }

            if (PROCESSED != triStateBool.ignor)
            {
                if (PROCESSED == triStateBool.yes)
                    whereClause += logicalConnector + "`PROCESSED` = 'Y'";
                else if (PROCESSED == triStateBool.No)
                    whereClause += logicalConnector + "`PROCESSED` = 'N'";
            }

            if (DOCSTATUS != transactionStatus.ignor)
            {
                whereClause += logicalConnector + 
                    "`DOCSTATUS` = '"+ 
                        DOCSTATUS.ToString().Substring(0,2).ToUpperInvariant() +"'";
            }

            if (T_TRANSACTION_ID != "")
                whereClause += logicalConnector + "`T_TRANSACTION_ID` = " + T_TRANSACTION_ID;

            if (M_BPARTNER_ID != "")
                whereClause += logicalConnector + "`M_BPARTNER_ID` = " + M_BPARTNER_ID;

            if (TRXDATE.ToString() != "" && considerDatePrameter)
                whereClause += logicalConnector + "`TRXDATE` = " + TRXDATE.ToString("yyyy-MM-dd");
			
			if (DOCUMENTNO != "")
                whereClause += logicalConnector + "`DOCUMENTNO` = '" + DOCUMENTNO + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) && 
                logicalConnector.Replace(" ","").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `T_TRANSACTION` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);			
		}
        
        public DataTable getT_TRXDETAILInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                string T_TRXDETAIL_ID, string T_TRANSACTION_ID, string M_BPARTNER_ID, DateTime TRXDATE, 
                    bool considerDatePrameter, triStateBool ISSALESTRX, string M_PRODUCT_ID,
				    triStateBool ActiveRecords, bool structureOnly, string logicalConnector)
		{
			string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("T_TRXDETAIL");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }
			
			if (ISSALESTRX != triStateBool.ignor)
            {
                if (ISSALESTRX == triStateBool.yes)
                    whereClause += logicalConnector + "`ISSALESTRX` = 'Y'";
                else if (ISSALESTRX == triStateBool.No)
                    whereClause += logicalConnector + "`ISSALESTRX` = 'N'";
            }
			
			if (T_TRXDETAIL_ID != "")
                whereClause += logicalConnector + "`T_TRXDETAIL` = " + T_TRXDETAIL_ID;

            if (T_TRANSACTION_ID != "")
                whereClause += logicalConnector + "`T_TRANSACTION_ID` = " + T_TRANSACTION_ID;

            if (M_BPARTNER_ID != "")
                whereClause += logicalConnector + "`M_BPARTNER_ID` = " + M_BPARTNER_ID;
			
			if (TRXDATE.ToString() != "" && considerDatePrameter)
                whereClause += logicalConnector + "`TRXDATE` = " + TRXDATE.ToString("yyyy-MM-dd");
			
			if (M_PRODUCT_ID != "")
                whereClause += logicalConnector + "`M_PRODUCT_ID` = " + M_PRODUCT_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);
            
         string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) && logicalConnector.Replace(" ","").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `T_TRXDETAIL` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
		}

        public DataTable getT_MOVEMENTInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                string T_MOVEMENT_ID, string DOCUMENTNO, string M_WAREHOUSEFROM_ID,
                    string M_WAREHOUSETO_ID, DateTime MOVEDATE, bool considerDatePrameter,
                    triStateBool ActiveRecords, triStateBool PROCESSED,
                    transactionStatus DOCSTATUS, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("T_MOVEMENT");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (PROCESSED != triStateBool.ignor)
            {
                if (PROCESSED == triStateBool.yes)
                    whereClause += logicalConnector + "`PROCESSED` = 'Y'";
                else if (PROCESSED == triStateBool.No)
                    whereClause += logicalConnector + "`PROCESSED` = 'N'";
            }

            if (DOCSTATUS != transactionStatus.ignor)
            {
                whereClause += logicalConnector +
                    "`DOCSTATUS` = '" +
                        DOCSTATUS.ToString().Substring(0, 2).ToUpperInvariant() + "'";
            }

            if (T_MOVEMENT_ID != "")
                whereClause += logicalConnector + "`T_MOVEMENT_ID` = " + T_MOVEMENT_ID;

            if (M_WAREHOUSEFROM_ID != "")
                whereClause += logicalConnector + "`M_WAREHOUSEFROM_ID` = " + M_WAREHOUSEFROM_ID;

            if (M_WAREHOUSETO_ID != "")
                whereClause += logicalConnector + "`M_WAREHOUSETO_ID` = " + M_WAREHOUSETO_ID;

            if (MOVEDATE.ToString() != "" && considerDatePrameter)
                whereClause += logicalConnector + "`MOVEDATE` = " + MOVEDATE.ToString("yyyy-MM-dd");

            if (DOCUMENTNO != "")
                whereClause += logicalConnector + "`DOCUMENTNO` = '" + DOCUMENTNO + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) &&
                logicalConnector.Replace(" ", "").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `T_MOVEMENT` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }
        
        public DataTable getT_MOVEMENTDETAILInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                string T_MOVEMENTDETAIL_ID, string T_MOVEMENT_ID, string M_WAREHOUSEFROM_ID, string M_WAREHOUSETO_ID,
                    DateTime MOVEDATE, bool considerDatePrameter, string M_PRODUCT_ID,
                    triStateBool ActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("T_MOVEMENTDETAIL");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (T_MOVEMENTDETAIL_ID != "")
                whereClause += logicalConnector + "`T_MOVEMENTDETAIL_ID` = " + T_MOVEMENTDETAIL_ID;

            if (T_MOVEMENT_ID != "")
                whereClause += logicalConnector + "`T_MOVEMENT_ID` = " + T_MOVEMENT_ID;

            if (M_WAREHOUSEFROM_ID != "")
                whereClause += logicalConnector + "`M_WAREHOUSEFROM_ID` = " + M_WAREHOUSEFROM_ID;

            if (M_WAREHOUSETO_ID != "")
                whereClause += logicalConnector + "`M_WAREHOUSETO_ID` = " + M_WAREHOUSETO_ID;

            if (MOVEDATE.ToString() != "" && considerDatePrameter)
                whereClause += logicalConnector + "`MOVEDATE` = " + MOVEDATE.ToString("yyyy-MM-dd");

            if (M_PRODUCT_ID != "")
                whereClause += logicalConnector + "`M_PRODUCT_ID` = " + M_PRODUCT_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) && logicalConnector.Replace(" ", "").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `T_MOVEMENTDETAIL` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }

        public DataTable getT_INVENTORYUSEInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                string T_INVENTORYUSE_ID, string DOCUMENTNO, string M_WAREHOUSEFROM_ID,
                    DateTime USEDDATE, bool considerDatePrameter,
                    triStateBool ActiveRecords, triStateBool PROCESSED,
                    transactionStatus DOCSTATUS, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("T_INVENTORYUSE");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (PROCESSED != triStateBool.ignor)
            {
                if (PROCESSED == triStateBool.yes)
                    whereClause += logicalConnector + "`PROCESSED` = 'Y'";
                else if (PROCESSED == triStateBool.No)
                    whereClause += logicalConnector + "`PROCESSED` = 'N'";
            }

            if (DOCSTATUS != transactionStatus.ignor)
            {
                whereClause += logicalConnector +
                    "`DOCSTATUS` = '" +
                        DOCSTATUS.ToString().Substring(0, 2).ToUpperInvariant() + "'";
            }

            if (T_INVENTORYUSE_ID != "")
                whereClause += logicalConnector + "`T_INVENTORYUSE_ID` = " + T_INVENTORYUSE_ID;

            if (M_WAREHOUSEFROM_ID != "")
                whereClause += logicalConnector + "`M_WAREHOUSEFROM_ID` = " + M_WAREHOUSEFROM_ID;

            if (USEDDATE.ToString() != "" && considerDatePrameter)
                whereClause += logicalConnector + "`USEDDATE` = " + USEDDATE.ToString("yyyy-MM-dd");

            if (DOCUMENTNO != "")
                whereClause += logicalConnector + "`DOCUMENTNO` = '" + DOCUMENTNO + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) &&
                logicalConnector.Replace(" ", "").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `T_INVENTORYUSE` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }

        public DataTable getT_INVENTORYUSEDETAILInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                string T_INVENTORYUSEDETAIL_ID, string T_INVENTORYUSE_ID, string M_WAREHOUSEFROM_ID,
                    DateTime USEDATE, bool considerDatePrameter, string M_PRODUCT_ID,
                    triStateBool ActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("T_INVENTORYUSEDETAIL");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (T_INVENTORYUSEDETAIL_ID != "")
                whereClause += logicalConnector + "`T_INVENTORYUSEDETAIL_ID` = " + T_INVENTORYUSEDETAIL_ID;

            if (T_INVENTORYUSE_ID != "")
                whereClause += logicalConnector + "`T_INVENTORYUSE_ID` = " + T_INVENTORYUSE_ID;

            if (M_WAREHOUSEFROM_ID != "")
                whereClause += logicalConnector + "`M_WAREHOUSEFROM_ID` = " + M_WAREHOUSEFROM_ID;

            if (USEDATE.ToString() != "" && considerDatePrameter)
                whereClause += logicalConnector + "`USEDDATE` = " + USEDATE.ToString("yyyy-MM-dd");

            if (M_PRODUCT_ID != "")
                whereClause += logicalConnector + "`M_PRODUCT_ID` = " + M_PRODUCT_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) && logicalConnector.Replace(" ", "").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `T_INVENTORYUSEDETAIL` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }
        
        public DataTable getT_PHYSICALCOUNTInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                string T_PHYSICALCOUNT_ID, string DOCUMENTNO, string M_WAREHOUSE_ID,
                    DateTime COUNTDATE, bool considerDatePrameter,
                    triStateBool ActiveRecords, triStateBool PROCESSED,
                    transactionStatus DOCSTATUS, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("T_PHYSICALCOUNT");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (PROCESSED != triStateBool.ignor)
            {
                if (PROCESSED == triStateBool.yes)
                    whereClause += logicalConnector + "`PROCESSED` = 'Y'";
                else if (PROCESSED == triStateBool.No)
                    whereClause += logicalConnector + "`PROCESSED` = 'N'";
            }

            if (DOCSTATUS != transactionStatus.ignor)
            {
                whereClause += logicalConnector +
                    "`DOCSTATUS` = '" +
                        DOCSTATUS.ToString().Substring(0, 2).ToUpperInvariant() + "'";
            }

            if (T_PHYSICALCOUNT_ID != "")
                whereClause += logicalConnector + "`T_PHYSICALCOUNT_ID` = " + T_PHYSICALCOUNT_ID;

            if (M_WAREHOUSE_ID != "")
                whereClause += logicalConnector + "`M_WAREHOUSE_ID` = " + M_WAREHOUSE_ID;

            if (COUNTDATE.ToString() != "" && considerDatePrameter)
                whereClause += logicalConnector + "`COUNTDATE` = " + COUNTDATE.ToString("yyyy-MM-dd");

            if (DOCUMENTNO != "")
                whereClause += logicalConnector + "`DOCUMENTNO` = '" + DOCUMENTNO + "'";


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) &&
                logicalConnector.Replace(" ", "").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `T_PHYSICALCOUNT` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }

        public DataTable getT_PHYSICALCOUNTDETAILInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                string T_PHYSICALCOUNTDETAIL_ID, string T_PHYSICALCOUNT_ID, string M_WAREHOUSE_ID,
                    DateTime COUNTDATE, bool considerDatePrameter, string M_PRODUCT_ID,
                    triStateBool ActiveRecords, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("T_PHYSICALCOUNTDETAIL");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (T_PHYSICALCOUNTDETAIL_ID != "")
                whereClause += logicalConnector + "`T_PHYSICALCOUNTDETAIL_ID` = " + T_PHYSICALCOUNTDETAIL_ID;

            if (T_PHYSICALCOUNT_ID != "")
                whereClause += logicalConnector + "`T_PHYSICALCOUNT_ID` = " + T_PHYSICALCOUNT_ID;

            if (M_WAREHOUSE_ID != "")
                whereClause += logicalConnector + "`M_WAREHOUSE_ID` = " + M_WAREHOUSE_ID;

            if (COUNTDATE.ToString() != "" && considerDatePrameter)
                whereClause += logicalConnector + "`COUNTDATE` = " + COUNTDATE.ToString("yyyy-MM-dd");

            if (M_PRODUCT_ID != "")
                whereClause += logicalConnector + "`M_PRODUCT_ID` = " + M_PRODUCT_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) && logicalConnector.Replace(" ", "").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `T_PHYSICALCOUNTDETAIL` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }

        public DataTable getM_TRANSACTIONInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_TRANSACTION_ID, string MOVEMENTTYPE, string M_LOCATOR_ID, string M_PRODUCT_ID,
            DateTime MOVEMENTDATE, bool considerDatePrameter, string M_INVENTORYLINE_ID,
            string M_MOVEMENTLINE_ID, string M_INOUTLINE_ID, triStateBool ActiveRecords, 
            bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("M_TRANSACTION");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (M_TRANSACTION_ID != "")
                whereClause += logicalConnector + "`M_TRANSACTION_ID` = " + M_TRANSACTION_ID;

            if (MOVEMENTTYPE != "")
                whereClause += logicalConnector + "`MOVEMENTTYPE` = " + MOVEMENTTYPE;

            if (M_LOCATOR_ID != "")
                whereClause += logicalConnector + "`M_LOCATOR_ID` = " + M_LOCATOR_ID;

            if (MOVEMENTDATE.ToString() != "" && considerDatePrameter)
                whereClause += logicalConnector + "`MOVEMENTDATE` = " + MOVEMENTDATE.ToString("yyyy-MM-dd");

            if (M_PRODUCT_ID != "")
                whereClause += logicalConnector + "`M_PRODUCT_ID` = " + M_PRODUCT_ID;

            if (M_INVENTORYLINE_ID != "")
                whereClause += logicalConnector + "`M_INVENTORYLINE_ID` = " + M_INVENTORYLINE_ID;
            if (M_MOVEMENTLINE_ID != "")
                whereClause += logicalConnector + "`M_MOVEMENTLINE_ID` = " + M_MOVEMENTLINE_ID;
            if (M_INOUTLINE_ID != "")
                whereClause += logicalConnector + "`M_INOUTLINE_ID` = " + M_INOUTLINE_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) && logicalConnector.Replace(" ", "").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `M_TRANSACTION` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);            
        }
        
        public DataTable getQ_STOCKInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                    string M_PRODUCT_ID, string M_WAREHOUSE_ID, triStateBool ActiveRecords, 
                        bool structureOnly, string logicalConnector)
     {
         string getRequestedTableInformation = "";
         if (structureOnly)
         {
             return this.getDataTableStructure("Q_STOCK");
         }

         logicalConnector += " ";
         logicalConnector = " " + logicalConnector;

         string whereClause = "WHERE 1 ";

         if (ActiveRecords != triStateBool.ignor)
         {
             if (ActiveRecords == triStateBool.yes)
                 whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
             else if (ActiveRecords == triStateBool.No)
                 whereClause += logicalConnector + "`ISACTIVE` = 'N'";
         }
         
         if (M_PRODUCT_ID != "")
             whereClause += logicalConnector + "`M_PRODUCT_ID` = " + M_PRODUCT_ID;

         if (M_WAREHOUSE_ID != "")
             whereClause += logicalConnector + "`M_WAREHOUSE_ID` = " + M_WAREHOUSE_ID;
         
         whereClause = whereClause +
             this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

         string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
         if (whereClause.Length > ("WHERE 1 ".Length) && logicalConnector.Replace(" ", "").ToUpperInvariant() == "OR")
             whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

         getRequestedTableInformation = "SELECT * " +
                                        "FROM `Q_STOCK` " + whereClause;

         return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
     }

        public DataTable getQ_COSTInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_PRODUCT_ID, decimal CURRENTQTY, decimal CURRENTCOST, decimal ACCUMULATEDQTY, 
            decimal ACCUMULATEDCOST, triStateBool ActiveRecords, bool structureOnly, 
            string logicalConnector, int resultLimit)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("Q_COST");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (M_PRODUCT_ID != "")
                whereClause += logicalConnector + "`M_PRODUCT_ID` = " + M_PRODUCT_ID;
            
            if (CURRENTQTY != 0)
                whereClause += logicalConnector + "`CURRENTQTY` = " + CURRENTQTY;

            if (CURRENTCOST != 0)
                whereClause += logicalConnector + "`CURRENTCOST` = " + CURRENTCOST;

            if (ACCUMULATEDQTY != 0)
                whereClause += logicalConnector + "`ACCUMULATEDQTY` = " + ACCUMULATEDQTY;

            if (ACCUMULATEDCOST != 0)
                whereClause += logicalConnector + "`ACCUMULATEDCOST` = " + ACCUMULATEDCOST;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) &&
                logicalConnector.Replace(" ", "").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `Q_COST` " + whereClause;
            if(resultLimit > 0)
                getRequestedTableInformation = 
                    getRequestedTableInformation + " LIMIT 0 ," + resultLimit;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }

        public DataTable getV_PRDUCTCOSTInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
            string M_PRODUCT_ID, string M_UOM_ID, string M_PRODUCTCATEGORY_ID, string CODE, string CODE2,
            string NAME, string PRODUCTTYPE, string UPC_EAN, string IMAGEPATH, decimal CURRENTQTY, 
            decimal CURRENTCOST, decimal ACCUMULATEDQTY, decimal ACCUMULATEDCOST, 
            triStateBool ActiveRecords, bool structureOnly, string logicalConnector, 
            int resultLimit)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("V_PRDUCTCOST");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (M_PRODUCT_ID != "")
                whereClause += logicalConnector + "`M_PRODUCT_ID` = " + M_PRODUCT_ID;

            if (M_UOM_ID != "")
                whereClause += logicalConnector + "`M_UOM_ID` = " + M_UOM_ID;

            if (M_PRODUCTCATEGORY_ID != "")
                whereClause += logicalConnector + "`M_PRODUCTCATEGORY_ID` = " + M_PRODUCTCATEGORY_ID;

            if (CODE != "")
                whereClause += logicalConnector + "`CODE` LIKE '%" + CODE + "%'";

            if (CODE2 != "")
                whereClause += logicalConnector + "`CODE2` LIKE '%" + CODE2 + "%'";

            if (NAME != "")
                whereClause += logicalConnector + "`NAME` LIKE '%" + NAME + "%'";

            if (PRODUCTTYPE != "")
                whereClause += logicalConnector + "`PRODUCTTYPE` = '" + PRODUCTTYPE + "'";

            if (UPC_EAN != "")
                whereClause += logicalConnector + "`UPC_EAN` = '" + UPC_EAN + "'";

            if (IMAGEPATH != "")
                whereClause += logicalConnector + "`IMAGEPATH` = '" + IMAGEPATH + "'";

            if (CURRENTQTY != 0)
                whereClause += logicalConnector + "`CURRENTQTY` = " + CURRENTQTY;

            if (CURRENTCOST != 0)
                whereClause += logicalConnector + "`CURRENTCOST` = " + CURRENTCOST;

            if (ACCUMULATEDQTY != 0)
                whereClause += logicalConnector + "`ACCUMULATEDQTY` = " + ACCUMULATEDQTY;

            if (ACCUMULATEDCOST != 0)
                whereClause += logicalConnector + "`ACCUMULATEDCOST` = " + ACCUMULATEDCOST;

            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) &&
                logicalConnector.Replace(" ", "").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                               "FROM `V_PRDUCTCOST` " + whereClause;
            if (resultLimit > 0)
                getRequestedTableInformation =
                    getRequestedTableInformation + " LIMIT 0 ," + resultLimit;


            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }

        public DataTable getV_TRXDETAILInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                string T_TRANSACTION_ID, string T_TRXDETAIL_ID, string DOCUMENTNO, string M_BPARTNER_ID,
                string M_PRODUCT_ID, string M_WAREHOUSE_ID, string M_SHOP_ID, string M_PRODUCTCATEGORY_ID,
                DateTime TRXDATE, bool considerDatePrameter, triStateBool ISSALESTRX, triStateBool ActiveRecords,
                triStateBool PROCESSED, transactionStatus DOCSTATUS, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("V_TRXDETAIL");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (ISSALESTRX != triStateBool.ignor)
            {
                if (ISSALESTRX == triStateBool.yes)
                    whereClause += logicalConnector + "`ISSALESTRX` = 'Y'";
                else if (ISSALESTRX == triStateBool.No)
                    whereClause += logicalConnector + "`ISSALESTRX` = 'N'";
            }

            if (PROCESSED != triStateBool.ignor)
            {
                if (PROCESSED == triStateBool.yes)
                    whereClause += logicalConnector + "`PROCESSED` = 'Y'";
                else if (PROCESSED == triStateBool.No)
                    whereClause += logicalConnector + "`PROCESSED` = 'N'";
            }

            if (DOCSTATUS != transactionStatus.ignor)
            {
                whereClause += logicalConnector +
                    "`DOCSTATUS` = '" +
                        DOCSTATUS.ToString().Substring(0, 2).ToUpperInvariant() + "'";
            }

            if (TRXDATE.ToString() != "" && considerDatePrameter)
                whereClause += logicalConnector + "`TRXDATE` = " + TRXDATE.ToString("yyyy-MM-dd");

            if (DOCUMENTNO != "")
                whereClause += logicalConnector + "`DOCUMENTNO` = '" + DOCUMENTNO + "'";

            if (T_TRANSACTION_ID != "")
                whereClause += logicalConnector + "`T_TRANSACTION_ID` = " + T_TRANSACTION_ID;

            if (T_TRXDETAIL_ID != "")
                whereClause += logicalConnector + "`T_TRXDETAIL_ID` = " + T_TRXDETAIL_ID;

            if (M_BPARTNER_ID != "")
                whereClause += logicalConnector + "`M_BPARTNER_ID` = " + M_BPARTNER_ID;

            if (M_PRODUCT_ID != "")
                whereClause += logicalConnector + "`M_PRODUCT_ID` = " + M_PRODUCT_ID;

            if (M_WAREHOUSE_ID != "")
                whereClause += logicalConnector + "`M_WAREHOUSE_ID` = " + M_WAREHOUSE_ID;

            if (M_SHOP_ID != "")
                whereClause += logicalConnector + "`M_SHOP_ID` = " + M_SHOP_ID;

            if (M_PRODUCTCATEGORY_ID != "")
                whereClause += logicalConnector + "`M_PRODUCTCATEGORY_ID` = " + M_PRODUCTCATEGORY_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) &&
                logicalConnector.Replace(" ", "").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `V_TRXDETAIL` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }

        public DataTable getV_PHYSICALCOUNTDETAILInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                string T_PHYSICALCOUNT_ID, string T_PHYSICALCOUNTDETAIL_ID, string DOCUMENTNO, string M_PRODUCT_ID,
                string M_WAREHOUSE_ID, string M_SHOP_ID, string M_PRODUCTCATEGORY_ID,
                DateTime COUNTDATE, bool considerDatePrameter, triStateBool ActiveRecords,
                triStateBool PROCESSED, transactionStatus DOCSTATUS, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("V_PHYSICALCOUNTDETAIL");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (PROCESSED != triStateBool.ignor)
            {
                if (PROCESSED == triStateBool.yes)
                    whereClause += logicalConnector + "`PROCESSED` = 'Y'";
                else if (PROCESSED == triStateBool.No)
                    whereClause += logicalConnector + "`PROCESSED` = 'N'";
            }

            if (DOCSTATUS != transactionStatus.ignor)
            {
                whereClause += logicalConnector +
                    "`DOCSTATUS` = '" +
                        DOCSTATUS.ToString().Substring(0, 2).ToUpperInvariant() + "'";
            }

            if (COUNTDATE.ToString() != "" && considerDatePrameter)
                whereClause += logicalConnector + "`COUNTDATE` = " + COUNTDATE.ToString("yyyy-MM-dd");

            if (DOCUMENTNO != "")
                whereClause += logicalConnector + "`DOCUMENTNO` = '" + DOCUMENTNO + "'";

            if (T_PHYSICALCOUNT_ID != "")
                whereClause += logicalConnector + "`T_PHYSICALCOUNT_ID` = " + T_PHYSICALCOUNT_ID;

            if (T_PHYSICALCOUNTDETAIL_ID != "")
                whereClause += logicalConnector + "`T_PHYSICALCOUNTDETAIL_ID` = " + T_PHYSICALCOUNTDETAIL_ID;

            if (M_PRODUCT_ID != "")
                whereClause += logicalConnector + "`M_PRODUCT_ID` = " + M_PRODUCT_ID;

            if (M_WAREHOUSE_ID != "")
                whereClause += logicalConnector + "`M_WAREHOUSE_ID` = " + M_WAREHOUSE_ID;

            if (M_SHOP_ID != "")
                whereClause += logicalConnector + "`M_SHOP_ID` = " + M_SHOP_ID;

            if (M_PRODUCTCATEGORY_ID != "")
                whereClause += logicalConnector + "`M_PRODUCTCATEGORY_ID` = " + M_PRODUCTCATEGORY_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) &&
                logicalConnector.Replace(" ", "").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `V_PHYSICALCOUNTDETAIL` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }

        public DataTable getV_INVENTORYUSEDETAILInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                string T_INVENTORYUSE_ID, string T_INVENTORYUSEDETAIL_ID, string DOCUMENTNO, string M_PRODUCT_ID,
                string M_WAREHOUSEFROM_ID, string M_SHOP_ID, string M_PRODUCTCATEGORY_ID,
                DateTime USEDATE, bool considerDatePrameter, triStateBool ActiveRecords,
                triStateBool PROCESSED, transactionStatus DOCSTATUS, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("V_INVENTORYUSEDETAIL");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (PROCESSED != triStateBool.ignor)
            {
                if (PROCESSED == triStateBool.yes)
                    whereClause += logicalConnector + "`PROCESSED` = 'Y'";
                else if (PROCESSED == triStateBool.No)
                    whereClause += logicalConnector + "`PROCESSED` = 'N'";
            }

            if (DOCSTATUS != transactionStatus.ignor)
            {
                whereClause += logicalConnector +
                    "`DOCSTATUS` = '" +
                        DOCSTATUS.ToString().Substring(0, 2).ToUpperInvariant() + "'";
            }

            if (USEDATE.ToString() != "" && considerDatePrameter)
                whereClause += logicalConnector + "`USEDATE` = " + USEDATE.ToString("yyyy-MM-dd");

            if (DOCUMENTNO != "")
                whereClause += logicalConnector + "`DOCUMENTNO` = '" + DOCUMENTNO + "'";

            if (T_INVENTORYUSE_ID != "")
                whereClause += logicalConnector + "`T_INVENTORYUSE_ID` = " + T_INVENTORYUSE_ID;

            if (T_INVENTORYUSEDETAIL_ID != "")
                whereClause += logicalConnector + "`T_INVENTORYUSEDETAIL_ID` = " + T_INVENTORYUSEDETAIL_ID;

            if (M_PRODUCT_ID != "")
                whereClause += logicalConnector + "`M_PRODUCT_ID` = " + M_PRODUCT_ID;

            if (M_WAREHOUSEFROM_ID != "")
                whereClause += logicalConnector + "`M_WAREHOUSEFROM_ID` = " + M_WAREHOUSEFROM_ID;

            if (M_SHOP_ID != "")
                whereClause += logicalConnector + "`M_SHOP_ID` = " + M_SHOP_ID;

            if (M_PRODUCTCATEGORY_ID != "")
                whereClause += logicalConnector + "`M_PRODUCTCATEGORY_ID` = " + M_PRODUCTCATEGORY_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) &&
                logicalConnector.Replace(" ", "").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `V_INVENTORYUSEDETAIL` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }

        public DataTable getV_MOVEMENTDETAILInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
                string T_MOVEMENT_ID, string T_MOVEMENTDETAIL_ID, string DOCUMENTNO, string M_PRODUCT_ID,
                string M_WAREHOUSEFROM_ID, string M_WAREHOUSETO_ID, string M_SHOP_ID, string M_PRODUCTCATEGORY_ID,
                DateTime MOVEDATE, bool considerDatePrameter, triStateBool ActiveRecords,
                triStateBool PROCESSED, transactionStatus DOCSTATUS, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("V_MOVEMENTDETAIL");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (ActiveRecords != triStateBool.ignor)
            {
                if (ActiveRecords == triStateBool.yes)
                    whereClause += logicalConnector + "`ISACTIVE` = 'Y'";
                else if (ActiveRecords == triStateBool.No)
                    whereClause += logicalConnector + "`ISACTIVE` = 'N'";
            }

            if (PROCESSED != triStateBool.ignor)
            {
                if (PROCESSED == triStateBool.yes)
                    whereClause += logicalConnector + "`PROCESSED` = 'Y'";
                else if (PROCESSED == triStateBool.No)
                    whereClause += logicalConnector + "`PROCESSED` = 'N'";
            }

            if (DOCSTATUS != transactionStatus.ignor)
            {
                whereClause += logicalConnector +
                    "`DOCSTATUS` = '" +
                        DOCSTATUS.ToString().Substring(0, 2).ToUpperInvariant() + "'";
            }

            if (MOVEDATE.ToString() != "" && considerDatePrameter)
                whereClause += logicalConnector + "`MOVEDATE` = " + MOVEDATE.ToString("yyyy-MM-dd");

            if (DOCUMENTNO != "")
                whereClause += logicalConnector + "`DOCUMENTNO` = '" + DOCUMENTNO + "'";

            if (T_MOVEMENT_ID != "")
                whereClause += logicalConnector + "`T_MOVEMENT_ID` = " + T_MOVEMENT_ID;

            if (T_MOVEMENTDETAIL_ID != "")
                whereClause += logicalConnector + "`T_MOVEMENTDETAIL_ID` = " + T_MOVEMENTDETAIL_ID;

            if (M_PRODUCT_ID != "")
                whereClause += logicalConnector + "`M_PRODUCT_ID` = " + M_PRODUCT_ID;

            if (M_WAREHOUSEFROM_ID != "")
                whereClause += logicalConnector + "`M_WAREHOUSEFROM_ID` = " + M_WAREHOUSEFROM_ID;

            if (M_WAREHOUSETO_ID != "")
                whereClause += logicalConnector + "`M_WAREHOUSETO_ID` = " + M_WAREHOUSETO_ID;

            if (M_SHOP_ID != "")
                whereClause += logicalConnector + "`M_SHOP_ID` = " + M_SHOP_ID;

            if (M_PRODUCTCATEGORY_ID != "")
                whereClause += logicalConnector + "`M_PRODUCTCATEGORY_ID` = " + M_PRODUCTCATEGORY_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) &&
                logicalConnector.Replace(" ", "").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `V_MOVEMENTDETAIL` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }


        public DataTable getV_TRANSACTIONSUMMARYInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
               string M_TRANSACTION_ID, string M_INOUTLINE_ID, string M_MOVEMENTLINE_ID,
               string M_INVENTORYLINE_ID, string T_INVENTORYUSEDETAIL_ID,
               string DOCUMENTNO, string M_PRODUCT_ID, string AD_ORG_ID, string M_SHOP_ID,
               string M_LOCATOR_ID, string M_PRODUCTCATEGORY_ID,
               DateTime MOVEMENTDATE, bool considerDatePrameter,
               movementType MOVEMENTTYPE, bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("V_TRANSACTIONSUMMARY");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (M_TRANSACTION_ID != "")
                whereClause += logicalConnector + "`M_TRANSACTION_ID` = " + M_TRANSACTION_ID;

            if (M_INOUTLINE_ID != "")
                whereClause += logicalConnector + "`M_INOUTLINE_ID` = " + M_INOUTLINE_ID;

            if (M_MOVEMENTLINE_ID != "")
                whereClause += logicalConnector + "`M_MOVEMENTLINE_ID` = " + M_MOVEMENTLINE_ID;

            if (M_INVENTORYLINE_ID != "")
                whereClause += logicalConnector + "`M_INVENTORYLINE_ID` = " + M_INVENTORYLINE_ID;

            if (T_INVENTORYUSEDETAIL_ID != "")
                whereClause += logicalConnector + "`T_INVENTORYUSEDETAIL_ID` = " + T_INVENTORYUSEDETAIL_ID;


            if (MOVEMENTTYPE != movementType.BL)
            {
                whereClause += logicalConnector +
                    "`MOVEMENTTYPE` = '" +
                        new businessRule().
                            getStringEquivelentOfMoveType(MOVEMENTTYPE) + "'";
            }

            if (MOVEMENTDATE.ToString() != "" && considerDatePrameter)
                whereClause += logicalConnector + "`MOVEMENTDATE` = " + MOVEMENTDATE.ToString("yyyy-MM-dd");

            if (DOCUMENTNO != "")
                whereClause += logicalConnector + "`DOCUMENTNO` = '" + DOCUMENTNO + "'";


            if (M_PRODUCT_ID != "")
                whereClause += logicalConnector + "`M_PRODUCT_ID` = " + M_PRODUCT_ID;

            if (M_SHOP_ID != "")
                whereClause += logicalConnector + "`M_SHOP_ID` = " + M_SHOP_ID;

            if (AD_ORG_ID != "")
                whereClause += logicalConnector + "`AD_ORG_ID` = " + AD_ORG_ID;

            if (M_LOCATOR_ID != "")
                whereClause += logicalConnector + "`M_LOCATOR_ID` = " + M_LOCATOR_ID;

            if (M_PRODUCTCATEGORY_ID != "")
                whereClause += logicalConnector + "`M_PRODUCTCATEGORY_ID` = " + M_PRODUCTCATEGORY_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) &&
                logicalConnector.Replace(" ", "").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `V_TRANSACTIONSUMMARY` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }

        public DataTable getV_STORAGEDETAILInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
               string M_PRODUCT_ID, string M_WAREHOUSE_ID, string M_PRODUCTCATEGORY_ID,
               bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("V_STORAGEDETAIL");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (M_PRODUCT_ID != "")
                whereClause += logicalConnector + "`M_PRODUCT_ID` = " + M_PRODUCT_ID;

            if (M_WAREHOUSE_ID != "")
                whereClause += logicalConnector + "`M_WAREHOUSE_ID` = " + M_WAREHOUSE_ID;

            if (M_PRODUCTCATEGORY_ID != "")
                whereClause += logicalConnector + "`M_PRODUCTCATEGORY_ID` = " + M_PRODUCTCATEGORY_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) &&
                logicalConnector.Replace(" ", "").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `V_STORAGEDETAIL` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }

        public DataTable getV_STORAGESUMMARYInfo(DataTable criteriaTable, string criteriaTableLogicalConnector,
               string M_PRODUCT_ID, string M_PRODUCTCATEGORY_ID,
               bool structureOnly, string logicalConnector)
        {
            string getRequestedTableInformation = "";
            if (structureOnly)
            {
                return this.getDataTableStructure("V_STORAGESUMMARY");
            }

            logicalConnector += " ";
            logicalConnector = " " + logicalConnector;

            string whereClause = "WHERE 1 ";

            if (M_PRODUCT_ID != "")
                whereClause += logicalConnector + "`M_PRODUCT_ID` = " + M_PRODUCT_ID;
                        
            if (M_PRODUCTCATEGORY_ID != "")
                whereClause += logicalConnector + "`M_PRODUCTCATEGORY_ID` = " + M_PRODUCTCATEGORY_ID;


            whereClause = whereClause +
                this.createTheCriteriaClause(criteriaTable, criteriaTableLogicalConnector, logicalConnector);

            string stWhereClauseStarter = "WHERE 1 " + logicalConnector;
            if (whereClause.Length > ("WHERE 1 ".Length) &&
                logicalConnector.Replace(" ", "").ToUpperInvariant() == "OR")
                whereClause = whereClause.Replace(stWhereClauseStarter, "WHERE ");

            getRequestedTableInformation = "SELECT * " +
                                           "FROM `V_STORAGESUMMARY` " + whereClause;

            return (DataTable)this.executeSqlOnSRP(getRequestedTableInformation);
        }
        

        public string getNextSequenceId(string Name, string U_SEQUENCE_ID,
            triStateBool ISTABLEID,string BASEDOC,
            bool incrementToNextSequence)
        {
            string nextPrimaryKey = "";

            if (Name == "" && U_SEQUENCE_ID == "")
                return "";

            DataTable sequenceRecord =
                this.getU_SEQUENCEInfo(null, "", U_SEQUENCE_ID,
                                    Name, triStateBool.yes, ISTABLEID, BASEDOC, false, "AND");

            if (sequenceRecord.Rows.Count <= 0)
                return "";
            nextPrimaryKey = sequenceRecord.Rows[0]["CURRENTNEXT"].ToString();

            if (incrementToNextSequence)
            {
                sequenceRecord.Rows[0]["CURRENTNEXT"] = int.Parse(nextPrimaryKey) + 1;
                this.changeDataBaseTableData(sequenceRecord, "U_SEQUENCE", "Update");
            }                        

            return nextPrimaryKey;
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


            string[] tablePrimaryKeys = this.getSRPDBTablePrimaryKey(tableNameToChangeData);
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
                    nextTablePrimaryKey = this.getNextSequenceId(tableNameToChangeData, "",
                            triStateBool.yes,"", true);
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
                        this.removeEmptyColumnFromRow(dataToEffectTheChange),
                        0, dmlType.ToUpper());

                    //Execute.
            
            if (dmlStatementForTable != "")
                this.executeSqlOnSRP(dmlStatementForTable);
                        
            //The return Array Format is arrayIndex[0]=|primaryKeyName1forRowOne<("theNewPrimaryKey")>|| ...
            //primaryKeyName2forRowOne<("theNewPrimaryKey")>|| ...,
            //arrayIndex[1]=|primaryKeyName1forRow2<("theNewPrimaryKey")>||
            //primaryKeyName2forRow2<("theNewPrimaryKey")>||...
            return primaryKeysForNewInsertion;
        }
        
    }
}
