using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dbConnection;
using System.Data;
using System.Windows.Forms;


namespace utldecm
{
    enum dbState
    {
        Open,
        Close
    }

    enum level
    {
        New, 
        Leveled, 
        Overdue,
        None,
        System
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
        

        //public dbState dbStatus
        //{
        //    get
        //    {
        //        return this._dbStatus;
        //    }
        //    set
        //    {
        //        this._dbStatus = value;
        //    }
        //}
        

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
                    generalResultInformation.abortWarningExecution = true;
                    return false;
                }
            }
            catch (Exception e)
            {
                this._dbStatus = dbState.Close;
                generalResultInformation.abortWarningExecution = true;
                return false;
            }
            
        }

        public void closeDB()
        {
            if(this._dbStatus == dbState.Open)
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

        public void updateData(string command)
        {
            if (this.startDb())
            {
                this.db.updateDataBaseData(command, this.db);
                this.closeDB();
            }
        }
    
    }


    class passKeyVerify
    {
        connectDB db = new connectDB();
        

        public bool Verify(string pkey)
        {
            string commandString = "SELECT * FROM PASSKEY " +
                "WHERE USAGEREMAING > 0 AND KEYCODE = '" + pkey + "'";
            DataTable key = new DataTable();  
            key = this.db.getData(commandString);

            if (key.Rows.Count > 0)
            {
                commandString = "UPDATE PASSKEY SET USAGEREMAING = USAGEREMAING - 1 " +
                    "WHERE KEYCODE = '" + pkey + "'";
                this.db.updateData(commandString);
                return true;
            }
            return false;
        }

    }



    class raiseStatus
    {
        connectDB db = new connectDB();
        
        private DataTable opIncomingState;

        private level _stateLevel = level.None;
        private int _levelIntensity = 0;

        private level levelLimit = level.System;
        
        private string stateWarning;

        private Timer updateState = new Timer();


        public level stateLevel
        {
            get
            {
                return this._stateLevel;
            }
        }

        public int levelIntensity
        {
            get
            {
                return this._levelIntensity;
            }
        }

        public string warningText
        {
            get
            {
                return this.stateWarning;
            }
        }
        

        private void updateState_Tick(object sender, EventArgs e)
        {            
            this.getStatus();
            this.getStateWarning();
            this.getWarninglevel();
        }
               

        private void getStatus()
        {
            string commandString = "SELECT * FROM NEWINCOMINGS ORDER BY OPENDAYS ASC";
            opIncomingState = new DataTable();
            opIncomingState.Rows.Clear();
            opIncomingState.Columns.Clear();

            opIncomingState = this.db.getData(commandString);

            string commandString2 = "SELECT * FROM INCOMINGLEVELLIMIT";
            DataTable limit = this.db.getData(commandString2);
            if (limit.Rows.Count > 0)
            {
                string stLimit = limit.Rows[0][0].ToString();

                switch (stLimit)
                {
                    case "0":
                        this.levelLimit = level.None;                        
                        break;
                    case "A":
                        this.levelLimit = level.New;
                        break;
                    case "B":
                        this.levelLimit = level.Leveled;
                        break;
                    case "C":
                        this.levelLimit = level.Overdue;
                        break;
                    case "M":
                        this.levelLimit = level.System;
                        break;
                    default:
                        this.levelLimit = level.None;
                        break;
                }
            }
            else if(!this.db.startDb())
            {
                this.levelLimit = level.Leveled;
            }
            else
            {
                this.db.closeDB();
                this.levelLimit = level.None;
            }
        }

        private void getStateWarning()
        {
            if (this.opIncomingState.Rows.Count > 0)
            {
                if (int.Parse(this.opIncomingState.Rows[0]["OPENDAYS"].ToString()) == 0)
                {
                    stateWarning =
                        this.opIncomingState.Rows[0]["INCOMINGS"].ToString() + "\t New Incomings.\n";
                }
                else
                {
                    stateWarning =
                        this.opIncomingState.Rows[0]["OPENDAYS"].ToString() + "\t Days Passed for \t" +
                        this.opIncomingState.Rows[0]["INCOMINGS"].ToString() + "\t Incomings.\n";
                }

                for (int rowCounter = 1; rowCounter <= this.opIncomingState.Rows.Count - 1; rowCounter++)
                {
                    stateWarning =
                        stateWarning +
                        this.opIncomingState.Rows[rowCounter]["OPENDAYS"].ToString() + "\t Days Passed for \t" +
                        this.opIncomingState.Rows[rowCounter]["INCOMINGS"].ToString() + "\t Incomings.\n";
                }
            }
            else if (!this.db.startDb())
            {
                stateWarning = "Network Connection Missing. Please Contact your Administrator";
            }
            else
            {
                this.db.closeDB();
                stateWarning = "No Open Incomings"; 
            }
        }

        private void getWarninglevel()
        {
            if (this.opIncomingState.Rows.Count > 0)
            {
                if (this.levelLimit == level.None)
                {
                    this._stateLevel = level.None;
                    this._levelIntensity = 0;
                }
                else if (int.Parse(this.opIncomingState.Rows[this.opIncomingState.Rows.Count - 1]
                            ["OPENDAYS"].ToString()) >= 7)
                {
                    if (this.levelLimit == level.System ||
                        this.levelLimit == level.Overdue)
                    {
                        this._stateLevel = level.Overdue;
                        this._levelIntensity = 
                            int.Parse(this.opIncomingState.Rows[this.opIncomingState.Rows.Count - 1]
                                ["OPENDAYS"].ToString()) - 8;
                    }
                    else
                    {
                        this._stateLevel = this.levelLimit;
                        this._levelIntensity = 2;
                    }
                }
                else if (int.Parse(this.opIncomingState.Rows[this.opIncomingState.Rows.Count - 1]
                            ["OPENDAYS"].ToString()) >= 3)
                {
                    if (this.levelLimit == level.System ||
                        this.levelLimit == level.Overdue ||
                        this.levelLimit == level.Leveled)
                    {
                        this._stateLevel = level.Leveled;
                        this._levelIntensity = int.Parse(this.opIncomingState.Rows[this.opIncomingState.Rows.Count - 1]
                                ["OPENDAYS"].ToString()) - 3;
                    }
                    else
                    {
                        this._stateLevel = this.levelLimit;
                        this._levelIntensity = 2;
                    }
                }
                else
                {
                    if (this.levelLimit == level.System ||
                        this.levelLimit == level.Overdue ||
                        this.levelLimit == level.Leveled ||
                        this.levelLimit == level.New)
                    {
                        this._stateLevel = level.New;
                        this._levelIntensity = int.Parse(this.opIncomingState.Rows[this.opIncomingState.Rows.Count - 1]
                                ["OPENDAYS"].ToString()) - 0;
                    }
                    else
                    {
                        this._stateLevel = this.levelLimit;
                        this._levelIntensity = 2;
                    }
                }
            }
            else if (!this.db.startDb())
            {
                this._stateLevel = level.Leveled;
                this._levelIntensity = 3;
            }
            else
            {
                this.db.closeDB();
                this._stateLevel = level.None;
                this._levelIntensity = 0;
            }
        }

        public raiseStatus() 
        {
            try
            {
                this.updateState.Interval = 30000;
                this.updateState.Enabled = true;
                this.updateState.Tick += new EventHandler(updateState_Tick);
                this.updateState.Start();
                //this.updateState_Tick(new object(), new EventArgs());
            }
            catch (Exception e)
            {
                MessageBox.Show("New Incoming Inventory Report " +
                    "encountered Error.\n" + e.Message, "Incomings");
            }            
        }
 
    }
        

    class executeWarnings
    {
        raiseStatus newStatus = new raiseStatus();

        private Timer chakeState = new Timer();
        private Timer executeWarning = new Timer();
        private int executionRound = 0;

        private bool warningInprogress = false;

        level oldLevel = level.None;

        int oldLevelIntensity = 0;
        
         
        Random rnd0 = new Random();
        Random rnd1 = new Random();
        Random rnd2 = new Random();
        Random rnd3 = new Random();
        Random rnd4 = new Random();



        public executeWarnings()
        {
            try
            {
                this.chakeState.Interval = 60000 * 1;
                this.chakeState.Enabled = true;
                this.chakeState.Tick += new EventHandler(chakeState_Tick);

                this.executeWarning.Tick += new EventHandler(executeWarning_Tick);
                this.chakeState.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show("New Incoming Inventory Report " +
                    "encountered Error.\n" + e.Message, "Incomings");
            } 
        }

        private void chakeState_Tick(object sender, EventArgs e)
        {
            if (this.warningInprogress || 
                (this.newStatus.stateLevel == this.oldLevel && 
                this.newStatus.levelIntensity == this.oldLevelIntensity)
                )
            {
                return; 
            }

            if (this.warningInprogress)
            {
                this.executeWarning.Stop();
                this.executeWarning.Enabled = false;
                generalResultInformation.abortWarningExecution = true;
                return;
            }

            generalResultInformation.abortWarningExecution = false;

            this.oldLevel = this.newStatus.stateLevel;
            this.oldLevelIntensity = this.newStatus.levelIntensity;

            this.executeWarning.Enabled = false;                
            this.executionRound = 0;
                
            if (this.newStatus.stateLevel == level.Overdue)
            {
                this.executeWarning.Interval = (60000 * 60);
                this.executeWarning.Enabled = true;
                this.executeWarning.Start();
                this.executeWarning_Tick(sender, e);                                
            }
            else if (this.newStatus.stateLevel == level.Leveled)
            {
                this.executeWarning.Interval = int.Parse(((60000 * 60) / Math.Pow(2, this.newStatus.levelIntensity)).ToString());
                this.executeWarning.Enabled = true;
                this.executeWarning.Start();
                this.executeWarning_Tick(sender, e);                
            }
            else if (this.newStatus.stateLevel == level.New)
            {
                this.executeWarning.Interval = int.Parse(((60000 * 60 * 4) / Math.Pow(2, this.newStatus.levelIntensity)).ToString());
                this.executeWarning.Enabled = true;
                this.executeWarning.Start();
                this.executeWarning_Tick(sender, e);
            } 
        }

        private void executeWarning_Tick(object sender, EventArgs e)
        {
            if(this.warningInprogress)
            {
                return;
            }

            this.warningInprogress = true;
            this.executionRound++;

            if (this.newStatus.stateLevel == level.Overdue)
            {
                frmOpenIncomingInventory frmWarning = new frmOpenIncomingInventory();
                
                frmWarning.WaringText = this.newStatus.warningText;
                frmWarning.lifeTimeInSecond = 
                    int.Parse((Math.Min(60000 * (5 * Math.Pow(2, this.newStatus.levelIntensity)) * this.executionRound,(60000 * 40))).ToString());
                
                frmWarning.blinkContent = false;
                frmWarning.changeLocation = false;
                
                frmWarning.duplicateOnClose = false;
                frmWarning.followMouse = false;
                frmWarning.selfReplicate = false;

                frmWarning.showCloseCountDown = true;
                frmWarning.fillScreen = true;
                frmWarning.ignorCloseCommand = true;
                frmWarning.activateShadowBkg = true;
                frmWarning.acceptPassKey = true;

                frmWarning.ShowDialog();
            }
            else if (this.newStatus.stateLevel == level.Leveled)
            {
                frmOpenIncomingInventory frmWarning = new frmOpenIncomingInventory();

                frmWarning.WaringText = this.newStatus.warningText;
                frmWarning.lifeTimeInSecond =
                    int.Parse((Math.Min(10000 * Math.Pow(2, this.newStatus.levelIntensity) * this.executionRound,
                        Math.Min(this.executeWarning.Interval/3, (60000 * 5)))).ToString());


                frmWarning.blinkContent = (rnd0.Next(0, 100) % 2 == 0);
                frmWarning.changeLocation = (rnd1.Next(0, 100) % 3 == 0);

                if (this.newStatus.levelIntensity >= 1)
                {
                    frmWarning.duplicateOnClose = (rnd2.Next(0, 100) % 2 == 0);
                    frmWarning.followMouse = (rnd3.Next(0, 100) % 3 == 0);
                }

                if (this.newStatus.levelIntensity >= 2)
                {
                    frmWarning.selfReplicate = (rnd4.Next(0, 100) % 3 == 0);
                }

                frmWarning.showCloseCountDown = false;
                frmWarning.fillScreen = false;
                frmWarning.ignorCloseCommand = false;
                frmWarning.activateShadowBkg = false;
                frmWarning.acceptPassKey = false;
                frmWarning.ShowDialog();

            }
            else if (this.newStatus.stateLevel == level.New)
            {

                frmOpenIncomingInventory frmWarning = new frmOpenIncomingInventory();

                frmWarning.WaringText = this.newStatus.warningText;
                frmWarning.lifeTimeInSecond = (60000 * 5);

                frmWarning.blinkContent = (rnd2.Next(0, 100) % 2 == 0);
                frmWarning.changeLocation = 
                    this.newStatus.levelIntensity == 2 ? (rnd3.Next(0, 100) % 5 == 0) : false;

                frmWarning.duplicateOnClose = false;
                frmWarning.followMouse = false;
                frmWarning.selfReplicate = false;
                frmWarning.showCloseCountDown = false;
                frmWarning.fillScreen = false;
                frmWarning.ignorCloseCommand = false;
                frmWarning.activateShadowBkg = false;
                frmWarning.acceptPassKey = false;

                frmWarning.ShowDialog(); 
            }
            
            this.warningInprogress = false;            
        }


    }


}
