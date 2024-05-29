using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace POSDocumentPrinter
{
    class Util
    {
        public void setErrorToControl(Control control, ErrorProvider errorProvider, string errorMessage)
        {
            if (string.IsNullOrEmpty(control.Text.Replace(" ","")))
            {
                errorProvider.SetError(control, errorMessage);
            }
            else
            {
                errorProvider.SetError(control, "");
            }
        }
        /// <summary>
        /// Encrypt encrypt using aes
        /// </summary>
        /// <param name="text">string to be encrypted</param>
        /// <param name="keyString">key to </param>
        /// <returns></returns>
        public static string EncryptString(string text, string keyString)
        {
            keyString = Convert.ToBase64String(Encoding.UTF8.GetBytes("1234567890"));
            var key = Encoding.UTF8.GetBytes(keyString);
            Console.WriteLine(Convert.ToBase64String(key));
            using (var aesAlg = Aes.Create())
            {
                byte[] result = EncryptStringToBytes_Aes(text, key, aesAlg.IV);
                string x = Convert.ToBase64String(result);
                Console.WriteLine(DecryptStringFromBytes_Aes(Convert.FromBase64String(x), key, aesAlg.IV));
                return Convert.ToBase64String(result);

            }
        }
        /// <summary>
        /// Decrypt string using aes
        /// </summary>
        /// <param name="cipherText">text to be encrypted</param>
        /// <param name="keyString"></param>
        /// <returns></returns>
        public static string DecryptString(string cipherText, string keyString)
        {
            var fullCipher = Convert.FromBase64String(cipherText);

            var iv = new byte[16];
            var cipher = new byte[16];

            keyString = Convert.ToBase64String(Encoding.UTF8.GetBytes("1234567890"));
            var key = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = Aes.Create())
            {
                return DecryptStringFromBytes_Aes(fullCipher, key, aesAlg.IV);
            }
        }


        public static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {

            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;


            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;


                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);


                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            return encrypted;
        }

        public static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {

            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");


            string plaintext = null;


            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;


                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);


                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {


                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
       

        
        public string ReadFile(string filePath)
        {
            FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            using (StreamReader sr = new StreamReader(fileStream, Encoding.UTF8))
            {
                return sr.ReadToEnd();
            }
        }
        public void SaveFile(string payload, string filepath)
        {
            try
            {
                if (filepath == "")
                {
                    filepath = "C:\\Program Files (x86)\\Master\\config";
                }

                FileStream fopen = File.Open(filepath, FileMode.OpenOrCreate);
                using (StreamWriter sw = new StreamWriter(fopen))
                {
                    sw.Write(payload);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }

        }
        public string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[]
                {
                    0x49,
                    0x76,
                    0x61,
                    0x6e,
                    0x20,
                    0x4d,
                    0x65,
                    0x64,
                    0x76,
                    0x65,
                    0x64,
                    0x65,
                    0x76
                });
                if (encryptor != null)
                {
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        clearText = Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            return clearText;
        }

        //decrypt password
        public string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[]
                {
                    0x49,
                    0x76,
                    0x61,
                    0x6e,
                    0x20,
                    0x4d,
                    0x65,
                    0x64,
                    0x76,
                    0x65,
                    0x64,
                    0x65,
                    0x76
                });
                if (encryptor != null)
                {
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            return cipherText;
        }

        
    }
}
