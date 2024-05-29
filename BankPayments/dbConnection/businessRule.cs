using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CryptoXML;
using System.IO;

namespace dbConnection
{
    public class businessRule
    {

        string un = "passMeIn";
        string pwd = "toMyEncryption";

        public DataTable readEncryptedXmlSettingFile(string file)
        {
            DataTable aDataTable = new DataTable();

            aDataTable.TableName = "Settings";
            aDataTable.Columns.Add("Parameter_Name");
            aDataTable.Columns.Add("Parameter_Value");

            if (File.Exists(file))
            {
                XMLEncryptor decryptSettings = new XMLEncryptor(un, pwd);
                aDataTable = decryptSettings.ReadEncryptedXML(file);
                //aDataTable.ReadXml(file);
            }
            else
            {
                this.createSettingFile(file);
            }
            
            return aDataTable;
        }

        public void writeDatatableToEncryptedXmlSettingFile(DataTable settings, string file)
        {
            XMLEncryptor encryptSettings = new XMLEncryptor(un, pwd);
            encryptSettings.WriteEncryptedXML(settings, file);
            //settings.WriteXml(file);
        }

        public void createSettingFile(string file)
        {
            DataTable aDataTable = new DataTable();

            aDataTable.TableName = "Settings";
            aDataTable.Columns.Add("Parameter_Name");
            aDataTable.Columns.Add("Parameter_Value");

            aDataTable.WriteXml(file);
        }



    }
}
