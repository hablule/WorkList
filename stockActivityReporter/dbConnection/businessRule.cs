using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace dbConnection
{
    public class businessRule
    {

        string un = "passMeIn";
        string pwd = "toMyEncryption";

        public DataTable readEncryptedXmlSettingFile(string file)
        {
            DataTable aDataTable = new DataTable();


            XMLEncryptor decryptSettings = new XMLEncryptor(un, pwd);
            aDataTable = decryptSettings.ReadEncryptedXML(file);

            if (aDataTable == null)
            {
                aDataTable = new DataTable();
                aDataTable.TableName = "Settings";
                aDataTable.Columns.Add("Parameter_Name");
                aDataTable.Columns.Add("Parameter_Value");
            }

            return aDataTable;
        }

        public void writeDatatableToEncryptedXmlSettingFile(DataTable settings, string file)
        {
            XMLEncryptor encryptSettings = new XMLEncryptor(un, pwd);
            encryptSettings.WriteEncryptedXML(settings, file);
        }



    }
}
