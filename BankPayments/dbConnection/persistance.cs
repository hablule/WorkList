using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Data.Odbc;


namespace dbConnection
{
    class persistanceClass
    {
        public string DBaseType = "";
        private string connectionString = "";

        //private string selectCommandString = "";
        //private string dmlCommandString = "";

        //variable to hold the type of DataAdabter, DataCommand and DataConnection
        //private object dataAdapter ;
        //private object dataCommand ;
        //private object dataConnection ;

        //Oracle Data Base utility objects
        
        private OracleDataAdapter oraDataAdapter;
        private OracleCommand oraDataCommand;
        private OracleConnection oraDataConnection;

        //odbc Data Base Utility objects
        private OdbcDataAdapter odbcDataAdapter;
        private OdbcCommand odbcDataCommand;
        private OdbcConnection odbcDataConnection;
        
        //variables to hold output data from dabase;
        private DataTable dtResulttable;
        private DataSet dsResultDataSet;
        
        //Constructor used to validate proper Data-Base...
        //paramenters are used and used to inistantiate...
        //the objects connection variable with such paramenters.
        public persistanceClass(string dataBaseType, string hostName,
            string dataBaseName, string userName, string passWord,string portAddress)
        {
            //Switch Statment to instantiate connection String.
            switch (dataBaseType)
            { 
                    //if Database is Oracle
                case "Oracle":
                    this.connectionString =
                        "Data Source=(DESCRIPTION=" +
                            "(ADDRESS=(PROTOCOL=TCP)(HOST=" + hostName + ")(PORT="+portAddress+"))"+
                            "(CONNECT_DATA="+
                                "(SERVER=DEDICATED)"+
                                "(SERVICE_NAME=" + dataBaseName +")));"+
                                "User Id="+ userName +";"+
                                "Password="+ passWord +";"+
                                "Unicode=True";
                    this.DBaseType = "Oracle";
                    this.oraDataConnection = new OracleConnection();
                    this.oraDataConnection.ConnectionString = this.connectionString;
                    
                    break;
                    //if Database is ms-Sql Server
                case "Microsoft SQL Server":
                    break;
                    //if Database is MySql
                case "MySql":
                    this.connectionString = "DRIVER={MySQL ODBC 3.51 Driver}; SERVER = "+
                        hostName + "; PORT=" + portAddress + "; DATABASE= " + dataBaseName + 
                        "; UID= "+ userName +";PWD= "+ passWord +";OPTION=3";
                    this.odbcDataConnection = new OdbcConnection();
                    this.odbcDataConnection.ConnectionString = this.connectionString;
                    this.DBaseType = "MySql";
                    break;
                default:
                    break;
             }

        }

        public string connectToDataBase(persistanceClass DBinfo)
        {
            switch (DBinfo.DBaseType)
            { 
                case "Oracle":

                    try
                    {
                        DBinfo.oraDataConnection.Open();
                        return DBinfo.oraDataConnection.State.ToString();
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                    
                case "Microsoft SQL Server":
                    try
                    {
                        DBinfo.odbcDataConnection.Open();
                        return DBinfo.odbcDataConnection.State.ToString();
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                    
                case "MySql":
                    try
                    {
                        DBinfo.odbcDataConnection.Open();
                        return DBinfo.odbcDataConnection.State.ToString();
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                    
                default:
                    try
                    {
                        DBinfo.odbcDataConnection.Open();
                        return DBinfo.odbcDataConnection.State.ToString();
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                                       
            }
            
        }

        ////Distructor code example
        //~persistanceClass()
        //{
        //    switch (this.DBaseType)
        //    {
        //        case "Oracle":
        //            this.oraDataConnection.Close();
        //            break;
        //        case "Microsoft SQL Server":
        //            this.odbcDataConnection.Close();
        //            break;
        //        case "MySql":
        //            this.odbcDataConnection.Close();
        //            break;
        //        default:
        //            this.odbcDataConnection.Close();
        //            break;

        //    }
        //}

        public void closeConnection(persistanceClass dbInfo)
        {
            switch (dbInfo.DBaseType)
            {
                case "Oracle":
                    dbInfo.oraDataConnection.Close();
                    break;
                case "Microsoft SQL Server":
                    dbInfo.odbcDataConnection.Close();
                    break;
                case "MySql":
                    dbInfo.odbcDataConnection.Close();
                    break;
                default:
                    dbInfo.odbcDataConnection.Close();
                    break;

            }
        }

        public DataSet getDataBaseSchema(string schemCommand, persistanceClass dbInfo)
        {
            dbInfo.dsResultDataSet = new DataSet();
            return dbInfo.dsResultDataSet;
        }

        public DataTable getDataBaseData(string dbCommand,persistanceClass dbInfo)
        {
            dbInfo.dtResulttable = new DataTable();
             switch (dbInfo.DBaseType)
             {
                  case "Oracle":
                        if (dbInfo.oraDataConnection.State.ToString() == "Open")
                        {
                            try
                            {
                                dbInfo.oraDataAdapter = new OracleDataAdapter(dbCommand, dbInfo.oraDataConnection);
                                dbInfo.oraDataAdapter.Fill(dtResulttable);
                                dbInfo.oraDataAdapter.Dispose();
                                
                            }
                            catch (Exception ex)
                            {
                                System.Windows.Forms.MessageBox.Show("Unable to Fetch Data With Error " +
                                   "message {"+ ex.Message+"}.");
                                 break;
                            }
                        }
                        else
                            System.Windows.Forms.MessageBox.Show("No open DataBase Connection Found." +
                                "Please First specify data Base Connection and connect.");

                        break;

                    case "Microsoft SQL Server":
                        dbInfo.odbcDataConnection.Close();
                        break;

                    case "MySql":

                        if (dbInfo.odbcDataConnection.State.ToString() == "Open")
                        {
                            try
                            {
                                dbInfo.odbcDataAdapter = new OdbcDataAdapter(dbCommand, dbInfo.odbcDataConnection);
                                dbInfo.odbcDataAdapter.Fill(dtResulttable);
                                dbInfo.odbcDataAdapter.Dispose();
                                
                            }
                            catch (Exception ex)
                            {
                                System.Windows.Forms.MessageBox.Show("Unable to Fetch Data With Error " +
                                   "message {" + ex.Message + "}.");
                                break;
                            }
                        }
                        else
                            System.Windows.Forms.MessageBox.Show("No open DataBase Connection Found." +
                                "Please First specify data Base Connection and connect.");
                        break;
                    default:
                        dbInfo.odbcDataConnection.Close();
                        break;

                }
             return dbInfo.dtResulttable;
                    
        }

        public int updateDataBaseData(string dbCommand, persistanceClass dbInfo)
        {
            int numberOfDmlEffect = 0;
            dbCommitFailure.dbCommitError = false;
            dbCommitFailure.dbCommitErrorMessage = "";

            dbCommitFailure.dbCommitWarnning = false;
            dbCommitFailure.dbCommitWarnningMessage = "";

            switch (dbInfo.DBaseType)
             {
                  case "Oracle":
                     if (dbInfo.oraDataConnection.State.ToString() == "Open")
                     {
                         try
                         {
                             dbInfo.oraDataCommand = new OracleCommand(dbCommand, dbInfo.oraDataConnection);
                             numberOfDmlEffect = dbInfo.oraDataCommand.ExecuteNonQuery();
                         }
                         catch (Exception ex)
                         {
                             System.Windows.Forms.MessageBox.Show("Unable to apply Change With Error " +
                                "message {"+ ex.Message+"}.");
                             dbCommitFailure.dbCommitError = true;
                             dbCommitFailure.dbCommitErrorMessage = "Unable to apply Change With Error " +
                                                         "message {" + ex.Message + "}.";
                         }
                     }
                     else                     
                     {
                         dbCommitFailure.dbCommitWarnning = true;
                         dbCommitFailure.dbCommitWarnningMessage = "No open DataBase Connection Found." +
                             "Please First specify data Base Connection and connect.";
                         System.Windows.Forms.MessageBox.Show("No open DataBase Connection Found." +
                             "Please First specify data Base Connection and connect.");
                     }
                     break;
                    case "Microsoft SQL Server":
                        dbInfo.odbcDataConnection.Close();
                        break;

                    case "MySql":

                        if (dbInfo.odbcDataConnection.State.ToString() == "Open")
                        {
                            try
                            {
                                dbInfo.odbcDataCommand = new OdbcCommand(dbCommand,dbInfo.odbcDataConnection);
                                numberOfDmlEffect = dbInfo.odbcDataCommand.ExecuteNonQuery();                                
                            }
                            catch (Exception ex)
                            {
                                System.Windows.Forms.MessageBox.Show("Unable to apply change With Error " +
                                   "message {" + ex.Message + "}.");
                                dbCommitFailure.dbCommitError = true;
                                dbCommitFailure.dbCommitErrorMessage = "Unable to apply Change With Error " +
                                                         "message {" + ex.Message + "}.";                                
                            }
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("No open DataBase Connection Found." +
                                "Please First specify data Base Connection and connect.");
                            dbCommitFailure.dbCommitWarnning = true;
                            dbCommitFailure.dbCommitWarnningMessage = "No open DataBase Connection Found." +
                                "Please First specify data Base Connection and connect.";
                        }
                        break;
                    default:
                        dbInfo.odbcDataConnection.Close();
                        break;

                }

            return numberOfDmlEffect;

        }

        
    }
}
