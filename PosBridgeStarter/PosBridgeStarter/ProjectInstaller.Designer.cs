namespace PosBridgeStarter
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.POSBridgeServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.POSBridgeServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // POSBridgeServiceProcessInstaller
            // 
            this.POSBridgeServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.POSBridgeServiceProcessInstaller.Password = null;
            this.POSBridgeServiceProcessInstaller.Username = null;
            // 
            // POSBridgeServiceInstaller
            // 
            this.POSBridgeServiceInstaller.ServiceName = "POS-Bridge Starter";
            this.POSBridgeServiceInstaller.ServicesDependedOn = new string[] {
        "MySQL",
        "OracleServiceMAINDB"};
            this.POSBridgeServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.POSBridgeServiceProcessInstaller,
            this.POSBridgeServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller POSBridgeServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller POSBridgeServiceInstaller;
    }
}