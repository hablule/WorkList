using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using dbConnection;
using System.Data;
using System.Text.RegularExpressions;


namespace SyncMonitor
{

    enum dbState
    {
        Open,
        Close
    }
        
    class connectDB
    {

        private persistanceClass db;
        /*=
            new persistanceClass("Oracle", "",
                "maindb.glorious", "compiere", "compiere", "1521");*/

        private dbState _dbStatus;

        private string dbHostName = "glhqserver";
        private string dbHostIp1 = "192.168.63.3";
        private string dbHostIp2 = "192.168.63.2";


        private string connStatus;

        public bool startDb()
        {
            try
            {
                this.db = new persistanceClass("Oracle", dbHostName,
                "maindb.glorious", "compiere", "compiere", "1521");

                this.connStatus = this.db.connectToDataBase(db);
                if (this.connStatus == "Open")
                {
                    this._dbStatus = dbState.Open;
                    return true;
                }

                this.db = new persistanceClass("Oracle", dbHostIp1,
                "maindb.glorious", "compiere", "compiere", "1521");

                this.connStatus = this.db.connectToDataBase(db);
                if (this.connStatus == "Open")
                {
                    this._dbStatus = dbState.Open;
                    return true;
                }

                this.db = new persistanceClass("Oracle", dbHostIp2,
                    "maindb.glorious", "compiere", "compiere", "1521");

                this.connStatus = this.db.connectToDataBase(db);
                if (this.connStatus == "Open")
                {
                    this._dbStatus = dbState.Open;
                    return true;
                }
                else
                {
                    this._dbStatus = dbState.Close;
                    return false;
                }
            }
            catch (Exception e)
            {
                this._dbStatus = dbState.Close;
                return false;
            }

        }

        public void closeDB()
        {
            if (this._dbStatus == dbState.Open)
                this.db.closeConnection(this.db);
            this._dbStatus = dbState.Close;
        }

        public DataTable getData(string command)
        {
            DataTable resultData = new DataTable();

            if (this.startDb())
            {
                resultData = this.db.getDataBaseData(command, this.db);
                this.closeDB();
            }
            return resultData;
        }

        public int updateData(string command)
        {
            int result = -1;
            if (this.startDb())
            {                
                result = this.db.updateDataBaseData(command, this.db);
                this.closeDB();
            }
            return result;
        }

    }
    
    class syncFileInfo
    {
        string filePath;
        string readID;
        string srcDB;
        string trgtDB;

        DateTime readDateTime;

        public syncFileInfo(string _path, string _readID, DateTime _readDateTime)
        {
            if (!File.Exists(_path))
            {
                return;
            }

            this.filePath = _path;
            this.readID = _readID;
            this.readDateTime = _readDateTime;

            FileInfo fI = new FileInfo(_path);
            string[] dirName = fI.DirectoryName.Split(new char[] { '\\' });
            string remotestore = dirName[dirName.Length - 1];

            
            if (fI.Name.StartsWith(remotestore))
            {
                this.srcDB = remotestore;
                this.trgtDB = "HQ";
            }
            else
            {
                this.srcDB = "HQ";
                this.trgtDB = remotestore;
            }
        }

        public string getSyncFilePath(syncFileInfo syncFile)
        {
            return syncFile.filePath;
        }

        public string getSyncFileReadID(syncFileInfo syncFile)
        {
            return syncFile.readID;
        }

        public string getSyncFileSrc(syncFileInfo syncFile)
        {
            return syncFile.srcDB;
        }

        public string getSyncFileTrgt(syncFileInfo syncFile)
        {
            return syncFile.trgtDB;
        }

        public DateTime getSyncFileReadDate(syncFileInfo syncFile)
        {
            return syncFile.readDateTime;
        }


        ///////

        public string getSyncFilePath()
        {
            return this.filePath;
        }

        public string getSyncFileReadID()
        {
            return this.readID;
        }

        public string getSyncFileSrc()
        {
            return this.srcDB;
        }

        public string getSyncFileTrgt()
        {
            return this.trgtDB;
        }

        public DateTime getSyncFileReadDate()
        {
            return this.readDateTime;
        }
        
    }
    
    class GenerateBaseFiles
    {
        string baseFolder;
        string logReadID;
        DateTime logReadDateTime;

        List<syncFileInfo> syncFiles = new List<syncFileInfo>();

        private string getNextLogReadID()
        {
            connectDB db = new connectDB();

            string commandString = "SELECT MAX(LOGREAD_ID) + 1 FROM UTL_DATASYNCLOG";
            DataTable LogRead = new DataTable();
            LogRead = db.getData(commandString);

            if (LogRead.Rows.Count > 0)
            {
                return LogRead.Rows[0][0].ToString() == "" ? "1000000" : LogRead.Rows[0][0].ToString();
            }
            return "1000000"; 
        }
                        
        public GenerateBaseFiles(string _folder)
        {
            if (!Directory.Exists(_folder))
            {
                return;
            }

            this.baseFolder = _folder;
            this.logReadID = this.getNextLogReadID();
            this.logReadDateTime = DateTime.Now;

            foreach (string syncFile in Directory.GetFiles(_folder,"*.*", SearchOption.AllDirectories))
            {
                syncFiles.Add(new syncFileInfo(syncFile, this.logReadID, this.logReadDateTime));
            }            
        }

        public List<syncFileInfo> getSyncFileList()
        {
            return this.syncFiles;
        }

    }

    class parseSyncFile
    {
        const string carrageReturn = "\r";
        const string lineFeed = "\n";
        const string newLine = "\r\n";
        const string tabSeparator = "\t";

        const string newSession = "Sync started at ";
        string[] TABLE_NAME;

        string missingDBErrorTablepattern;
        string newSessionMatch;
        string syncCompleteMatch;
        string syncErrorTypeOne;
        string syncErrorTypeTwo;
        string syncErrorTypeThree;

        int syncLogID;
        int syncSessionID;
        DateTime syncDate;

        private void createTableList(string tableListPath)
        {
            this.TABLE_NAME = File.ReadAllLines(tableListPath);
        }

        private void setRegexPatter()
        {
            string tableList = "";

            foreach (string tableName in TABLE_NAME)
            {
                tableList = tableList + tableName + " |";
            }

            tableList = tableList.Remove(tableList.LastIndexOf("|"), 1);

            this.missingDBErrorTablepattern = "(No database selected - Could not get FIELD information for ')(.+?)" + "('.+?)";
            this.newSessionMatch = "(Sync started at )([A-Z]{1}[a-z]{2}[ ]{1}[A-Z]{1}[a-z]{2}[ ]{1}\\d{1,2}[ ]{1}\\d{1,2}[:]{1}\\d{1,2}[:]{1}\\d{1,2}[ ]{1}\\d{4})(\\t*)";
            this.syncCompleteMatch = "(" + tableList + ")([ ]+\\d+)([ ]+\\d+)([ ]+\\d+)([ ]+\\d+)([ ]+\\d+)\\t*";
            this.syncErrorTypeOne = "(" + tableList + ")([ ]+\\d+)([ ]+\\d+)([ ]*.*)\\t*";
            this.syncErrorTypeTwo = "(" + tableList + ")(\\s*.+)\\t*";
            this.syncErrorTypeThree = "(.+)\t*";           

        }

        private void setDBPrimaryKey()
        {
            connectDB db = new connectDB();

            string commandString = "SELECT MAX(UTL_DATASYNCLOG_ID) as LOGID, MAX(SYNCSESSION_ID) as SESSIONID FROM UTL_DATASYNCLOG";
            DataTable LogRead = new DataTable();
            LogRead = db.getData(commandString);

            if (LogRead.Rows.Count > 0)
            {
                this.syncLogID = LogRead.Rows[0]["LOGID"].ToString() == "" ? 999999 : int.Parse(LogRead.Rows[0]["LOGID"].ToString());
                this.syncSessionID = LogRead.Rows[0]["SESSIONID"].ToString() == "" ? 999999 : int.Parse(LogRead.Rows[0]["SESSIONID"].ToString());
            }
            else
            {
                this.syncLogID = 1000000;
                this.syncSessionID = 1000000;
            }
 
        }
        
        private string startSyncFileParse(syncFileInfo _syncFileInfo)
        {
            FileInfo flInfo = new FileInfo(_syncFileInfo.getSyncFilePath());
                        
            string fileContent = File.ReadAllText(_syncFileInfo.getSyncFilePath());

            if (fileContent == "")
                return fileContent;
                       
            //Remove All New Lines
            fileContent = Regex.Replace(fileContent, "[" + newLine + "]+", "\t");
            fileContent = Regex.Replace(fileContent, "[" + carrageReturn + "]+", "\t");
            fileContent = Regex.Replace(fileContent, "[" + lineFeed + "]+", "\t");

            //Remove Double Tab
            fileContent = Regex.Replace(fileContent, "[\t]+", tabSeparator);

            //Remove Table Demarcator
            fileContent = fileContent.Replace("`", "");

                       
            //Start New line for each new session
            fileContent = fileContent.Replace(newSession, newLine + newSession);

            //Start New line for each Missing DB Log
            fileContent = Regex.Replace(fileContent, missingDBErrorTablepattern, m => newLine + m.Groups[2].Value + "   " + m.Groups[1].Value + m.Groups[3].Value);
            fileContent = fileContent.Replace(" for '' in ", " in ");

            
            //Start New line for each new Table Sync
            foreach (string tableName in TABLE_NAME)
            {
                fileContent = fileContent.Replace(tableName, newLine + tableName); 
            }

            //Start New Line Missing Script File
            fileContent = fileContent.Replace("Error No. 1231", newLine + "Error No. 1231");

            //Start New Line Missing DB
            fileContent = fileContent.Replace("ERROR: 2003,", newLine + "ERROR: 2003,");

            ////Remove Double New Lines
            fileContent = Regex.Replace(fileContent, "[" + newLine + "]+", newLine);

            //Remove Double Tab
            fileContent = Regex.Replace(fileContent, "[\t]+", tabSeparator);

            //Remove EndOfLine Tab
            fileContent = Regex.Replace(fileContent, tabSeparator + newLine, newLine);

            return fileContent;
        }

        public string generateSyncFileDBequivelant(syncFileInfo _syncFileInfo, string tableListPath, string syncDB)
        {
            this.createTableList(tableListPath);

            this.setRegexPatter();
            
            string[] syncParssedFile = 
                this.startSyncFileParse(_syncFileInfo).Split( new string[]{ "\r\n" },StringSplitOptions.RemoveEmptyEntries );

            string syncSqlEquivalent = "";

            if (syncParssedFile.Count() == 0)
                return syncSqlEquivalent;

            this.setDBPrimaryKey();

            string SYNCDB = syncDB;
            string SYNCTABLENAME = "";
            string SRCDATASIZE = "";
            string TRGDATASIZE = "";
            string INSERTED = "";
            string UPDATED = "";
            string DELETED = "";
            string SYNCTYPE = _syncFileInfo.getSyncFilePath().ToUpper().Contains("ALL") ? "'All'" : "'Recent'";
            string STATUS = "";
            string REMARK = "";

            bool hasMatched = false;

            foreach (string syncFileLine in syncParssedFile)
            {
                hasMatched = false;
                if (Regex.IsMatch(syncFileLine, newSessionMatch))
                {
                   //System.Windows.Forms.MessageBox.Show(

                    this.syncDate = DateTime.ParseExact(Regex.Match(syncFileLine, newSessionMatch).Groups[2].ToString(), "ddd MMM dd HH:mm:ss yyyy", null);
                    this.syncSessionID++;
                    continue;
                }
                else if (Regex.IsMatch(syncFileLine, syncCompleteMatch))
                {
                    SYNCTABLENAME = Regex.Match(syncFileLine, syncCompleteMatch).Groups[1].ToString().Trim();
                    SRCDATASIZE = Regex.Match(syncFileLine, syncCompleteMatch).Groups[2].ToString().Trim();
                    TRGDATASIZE = Regex.Match(syncFileLine, syncCompleteMatch).Groups[3].ToString().Trim();
                    INSERTED = Regex.Match(syncFileLine, syncCompleteMatch).Groups[4].ToString().Trim();
                    UPDATED = Regex.Match(syncFileLine, syncCompleteMatch).Groups[5].ToString().Trim();
                    DELETED = Regex.Match(syncFileLine, syncCompleteMatch).Groups[6].ToString().Trim();
                    STATUS = "'SUCCESS'";
                    REMARK = "";

                    hasMatched = true;
                }
                else if (Regex.IsMatch(syncFileLine, syncErrorTypeOne))
                {
                    SYNCTABLENAME = Regex.Match(syncFileLine, syncErrorTypeOne).Groups[1].ToString().Trim();
                    SRCDATASIZE = Regex.Match(syncFileLine, syncErrorTypeOne).Groups[2].ToString().Trim();
                    TRGDATASIZE = Regex.Match(syncFileLine, syncErrorTypeOne).Groups[3].ToString().Trim();
                    INSERTED = "-1";
                    UPDATED = "-1";
                    DELETED = "-1";
                    STATUS = "'FAIL'";
                    REMARK = Regex.Match(syncFileLine, syncErrorTypeOne).Groups[4].ToString().Trim().
                                    Replace("\t", " ").Replace("'", "''").Replace("&", "' || chr(38) || '");

                    hasMatched = true;
                }
                else if (Regex.IsMatch(syncFileLine, syncErrorTypeTwo))
                {
                    SYNCTABLENAME = Regex.Match(syncFileLine, syncErrorTypeTwo).Groups[1].ToString().Trim();
                    SRCDATASIZE = "-1";
                    TRGDATASIZE = "-1";
                    INSERTED = "-1";
                    UPDATED = "-1";
                    DELETED = "-1";
                    STATUS = "'FAIL'";
                    REMARK = Regex.Match(syncFileLine, syncErrorTypeTwo).Groups[2].ToString().Trim().
                                    Replace("\t", " ").Replace("'", "''").Replace("&", "' || chr(38) || '");

                    hasMatched = true;
                }
                else if (Regex.IsMatch(syncFileLine, syncErrorTypeThree))
                {
                    SYNCTABLENAME = "NOTAVAILABLE";
                    SRCDATASIZE = "-1";
                    TRGDATASIZE = "-1";
                    INSERTED = "-1";
                    UPDATED = "-1";
                    DELETED = "-1";
                    STATUS = "'FAIL'";
                    REMARK = Regex.Match(syncFileLine, syncErrorTypeThree).Groups[1].ToString().Trim().
                                    Replace("\t", " ").Replace("'", "''").Replace("&", "' || chr(38) || '");

                    hasMatched = true;
                }

                if (hasMatched)
                {
                    if (REMARK.Length > 1000)
                    {
                        REMARK = REMARK.Remove(996);
                        while (REMARK.EndsWith("'"))
                        {
                            REMARK = REMARK.Remove(REMARK.Length - 1);
                        }
                        REMARK = REMARK + "...";
                                                
                    }
                    syncSqlEquivalent = syncSqlEquivalent +
                             "SELECT " + (++this.syncLogID).ToString() + 
                                        ", TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss") + 
                                        "', 'DD-MON-YYYY HH24:MI:SS'), " +
                                         _syncFileInfo.getSyncFileReadID() + 
                                         ", TO_DATE('" + _syncFileInfo.getSyncFileReadDate().ToString("dd-MMM-yyyy HH:mm:ss") + 
                                         "', 'DD-MON-YYYY HH24:MI:SS'), " +
                                         this.syncSessionID.ToString() + ", '" +
                                         SYNCDB + "', " + 
                                         " TO_DATE('" + this.syncDate.ToString("dd-MMM-yyyy HH:mm:ss") + 
                                         "', 'DD-MON-YYYY HH24:MI:SS'), " +
                                         "(SELECT AD_STATION_ID FROM AD_STATION WHERE VALUE = '" + _syncFileInfo.getSyncFileSrc() + "'), " +
                                         "(SELECT AD_STATION_ID FROM AD_STATION WHERE VALUE = '" + _syncFileInfo.getSyncFileTrgt() + "'), '" +
                                         SYNCTABLENAME + "', " +
                                         SRCDATASIZE + ", " +
                                         TRGDATASIZE + ", " +
                                         INSERTED + ", " +
                                         UPDATED + ", " +
                                         DELETED + ", " +
                                         SYNCTYPE + ", " +
                                         STATUS + ", " +
                                         "'" + REMARK + "'" +
                                         " FROM DUAL UNION ALL ";
                }
                
            }
            if (syncSqlEquivalent != "")
            {
                syncSqlEquivalent = syncSqlEquivalent.Remove(syncSqlEquivalent.Length - 11, 11);
                syncSqlEquivalent = syncSqlEquivalent.Replace(" FROM DUAL UNION ALL ", " FROM DUAL UNION ALL \r\n");
                syncSqlEquivalent = "INSERT INTO UTL_DATASYNCLOG(UTL_DATASYNCLOG_ID, CREATED, " +
                                     "LOGREAD_ID, LOGREADDATE, SYNCSESSION_ID, SYNCDB, " +
                                     "SYNCDATE, SOURCE, TARGET, SYNCTABLE, SRCDATASIZE, TRGDATASIZE, " +
                                     "INSERTED, UPDATED, DELETED, SYNCTYPE, STATUS, REMARK)\r\n" +
                                     syncSqlEquivalent + "";
            }
            return syncSqlEquivalent;            
        }
    
    }


    class writeSyncLog
    {
        const string newLine = "\r\n";

        public int writeDB(syncFileInfo _syncFileInfo, string tableListPath, string syncDB)
        {
            string syncSqlEquivalent =
                new parseSyncFile().generateSyncFileDBequivelant(_syncFileInfo, tableListPath, syncDB);

            if (syncSqlEquivalent == "")
                return 0;

            connectDB db = new connectDB();
            int result = db.updateData(syncSqlEquivalent);
            //If Reading is successfull transfer syncLog File to backup
            if (result != -1)
            {
                FileInfo flInfo = new FileInfo(_syncFileInfo.getSyncFilePath());

                // Creates a TextInfo based on the "en-US" culture.
                TextInfo myTI = new CultureInfo("en-US",false).TextInfo;

                string bkpFileDirPath = 
                    myTI.ToTitleCase(flInfo.DirectoryName.ToLower()).Replace("Logs", "Logs_Bkp");

                if (!Directory.Exists(bkpFileDirPath))
                {
                    Directory.CreateDirectory(bkpFileDirPath);
                }

                string fileContent = File.ReadAllText(_syncFileInfo.getSyncFilePath());

                string bkpFileContentToWrite =
                    newLine + "============\tLog Read On " + _syncFileInfo.getSyncFileReadDate() + "\t============\tLog Read ID " + _syncFileInfo.getSyncFileReadID() + "\t============" +
                            newLine + fileContent + newLine + 
                            "<<<<<<<<<<<<<<<<<-------<<<<<<<<<<<<<<>>>>>>>>>>>>>>------->>>>>>>>>>>>>>>>>" + 
                            newLine;

                File.AppendAllText(bkpFileDirPath + "\\" + flInfo.Name, bkpFileContentToWrite);
                File.WriteAllText(_syncFileInfo.getSyncFilePath(), "");
            }
            return result;
        }
 
    }


}
