using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.IO;
using System.Windows.Forms;

namespace dbConnection
{
    public class LDAPConnection
    {
        private DirectoryEntry _directoryEntry;
        private Boolean directoryServiceConfigured;

        private bool getUser(string username)
        {
            DirectorySearcher searcher = new DirectorySearcher(_directoryEntry);

            try
            {
                SearchResult result = searcher.FindOne();
                foreach (var props in result.Properties.Values)
                {
                    Console.WriteLine(props.ToString());
                }
                return true;


            }
            catch (SystemException e)
            {
                //Console.WriteLine(e.Message);
                return false;
            }

        }

        public LDAPConnection()
        {
            var root = Directory.GetCurrentDirectory();
            var ldapenv = Path.Combine(root, ".env.LDAP");
            
            if (File.Exists(ldapenv))
            {
                DotnetEnv.Load(ldapenv);
                directoryServiceConfigured = true;
            }
            else if (generalResultInformation.LDAPConnectionSet)
            {               
                MessageBox.Show("Active Directory Service not Configured.\n Please Configure LDAP to proceed.", 
                        "LDAP Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
                generalResultInformation.useLDAPAuthentication = false;
                directoryServiceConfigured = false;
            }
        }

        public bool validateUser(string username, string password)
        {
            if (directoryServiceConfigured)
            {
                _directoryEntry = new DirectoryEntry(ldapPath(), username, password, AuthenticationTypes.Secure);
                string fullUsername = userFullID(username, Environment.GetEnvironmentVariable("LDAP_SERVER"));
                return getUser(fullUsername);
            }
            else            
            {
                return false;
            }
        }

        public bool validateUser(string server, string port, string username, string password)
        {
            _directoryEntry = new DirectoryEntry(ldapPath(server, port), username, password, AuthenticationTypes.Secure);
            string fullUsername = userFullID(username, server);
            return getUser(fullUsername);
        }

        private string userFullID(string username, string server)
        {
            return String.Format(@"{0}:{1}", username, server);
        }

        private string ldapPath()
        {
            return String.Format(@"LDAP://{0}:{1}", Environment.GetEnvironmentVariable("LDAP_SERVER"), Environment.GetEnvironmentVariable("LDAP_PORT"));
        }

        private string ldapPath(string server, string port)
        {
            return String.Format(@"LDAP://{0}:{1}", server, port);
        }

        public bool authenticateConnection()
        {           
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("USERNAME")) || 
                string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PASSWORD")))
            {
                return false;
            }

            string userName = Environment.GetEnvironmentVariable("USERNAME");
            string passWord = Environment.GetEnvironmentVariable("PASSWORD");

            return validateUser(userName, passWord);
        }

    }
}
