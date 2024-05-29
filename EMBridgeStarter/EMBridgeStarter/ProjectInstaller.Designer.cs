namespace EMBridgeStarter
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
            this.EMBridgeServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.EMBridgeServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // EMBridgeServiceProcessInstaller
            // 
            this.EMBridgeServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.EMBridgeServiceProcessInstaller.Password = null;
            this.EMBridgeServiceProcessInstaller.Username = null;
            // 
            // EMBridgeServiceInstaller
            // 
            this.EMBridgeServiceInstaller.ServiceName = "EM-Bridge Starter";
            this.EMBridgeServiceInstaller.ServicesDependedOn = new string[] {
        "MySQL",
        "OracleServiceMAINDB"};
            this.EMBridgeServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.EMBridgeServiceProcessInstaller,
            this.EMBridgeServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller EMBridgeServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller EMBridgeServiceInstaller;
    }
}