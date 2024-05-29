using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using Toolkit;

namespace EMBridgeStarter
{
    public partial class EMService : ServiceBase
    {
        public EMService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            String applicationName = "EasyMoveDataBridge.exe";

            // launch the application
            ApplicationLoader.PROCESS_INFORMATION procInfo;
            ApplicationLoader.StartProcessAndBypassUAC(applicationName, out procInfo);
        }

        protected override void OnStop()
        {
        }
    }
}
