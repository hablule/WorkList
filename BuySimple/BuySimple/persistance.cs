using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Data.Odbc;


namespace BuySimple
{
    class persistanceClass
    {
        public string DBaseType = "";
        private string connectionString = "";
        
        //Oracle Data Base utility objects
        
        private OracleDataAdapter oraDataAdapter;
        private OracleCommand oraDataCommand;
        private OracleConnection oraDataConnection;
        
        //variables to hold output data from dabase;
        private DataTable dtResulttable;
        private DataSet dsResultDataSet;
       
        public persistanceClass(string dataBaseType, string hostName,
            string dataBaseName, string userName, string passWord,string portAddress)
        {
            //Switch Statment to instantiate connection String.
            this.connectionString =
                "Data Source=(DESCRIPTION=" +
                    "(ADDRESS=(PROTOCOL=TCP)(HOST=" + hostName + ")(PORT=" + portAddress + "))" +
                    "(CONNECT_DATA=" +
                        "(SERVER=DEDICATED)" +
                        "(SERVICE_NAME=" + dataBaseName + ")));" +
                        "User Id=" + userName + ";" +
                        "Password=" + passWord + ";" +
                        "Unicode=True";                    
            this.DBaseType = "Oracle";
            this.oraDataConnection = new OracleConnection();
            this.oraDataConnection.ConnectionString = this.connectionString;
            
        }

        public string connectToDataBase(persistanceClass DBinfo)
        {
            try
            {
                DBinfo.oraDataConnection.Open();
                return DBinfo.oraDataConnection.State.ToString();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Unable to Connect to "+DBinfo.DBaseType +" DB With Error " +
                        "message {" + ex.Message + "}.","Data Base Error",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Exclamation);
                return ex.Message;
            }
        }
                        
        public void closeConnection(persistanceClass dbInfo)
        {
            dbInfo.oraDataConnection.Close();            
        }

        public DataSet getDataBaseSchema(string schemCommand, persistanceClass dbInfo)
        {
            dbInfo.dsResultDataSet = new DataSet();
            return dbInfo.dsResultDataSet;
        }

        public DataTable getDataBaseData(string dbCommand,persistanceClass dbInfo)
        {
            dbInfo.dtResulttable = new DataTable();
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
                 }
             }
             else
                 System.Windows.Forms.MessageBox.Show("No open DataBase Connection Found." +
                     "Please First check you DataBase Connection Setting and try Again.", 
                     "Data Base Error",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Exclamation);

            return dbInfo.dtResulttable;
                    
        }

        public int updateDataBaseData(string dbCommand, persistanceClass dbInfo)
        {
            int numberOfDmlEffect = 0;
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
                        "message {" + ex.Message + "}.",
                        "Data Base Error",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Exclamation);
                }
            }
            else
                System.Windows.Forms.MessageBox.Show("No open DataBase Connection Found." +
                        "Please First check you DataBase Connection Setting and try Again.",
                        "Data Base Error",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Exclamation);
            return numberOfDmlEffect;
        }
                
    }
}
