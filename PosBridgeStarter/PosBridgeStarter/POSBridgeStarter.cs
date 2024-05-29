using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using Toolkit;
using System.IO;

namespace PosBridgeStarter
{
    public partial class POSBridgeStarter : ServiceBase
    {
        public POSBridgeStarter()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Logfile.txt", "OPI");
            
            //String applicationName = "\"D:\\POSBridge\\POSDataBridge.exe\"";
            String applicationName = "POSDataBridge.exe";
            
            // launch the application
            ApplicationLoader.PROCESS_INFORMATION procInfo;
            ApplicationLoader.StartProcessAndBypassUAC(applicationName, out procInfo);
        }

        protected override void OnStop()
        {
            
        }
    }
}
