using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace dbConnection
{
   public class DotnetEnv
    {
        public static void Load(string filePath)
        {

            if (!File.Exists(filePath)) return;
            var str = "";
            Util util = new Util();
            foreach (var x in File.ReadAllLines(filePath))
            {
                str = x;
                Console.WriteLine(x);
            }
            var fileContent = util.Base64Decode(str);
            var content = fileContent.Split(';');
            foreach (var line in content)
            {
                Console.WriteLine(line);
                var parts = line.Split('=');
                if (parts.Length != 2) continue;

                Environment.SetEnvironmentVariable(parts[0], parts[1]);
            }

        }

        public static void CreateEnvFile(string filePath, string inputTxt)
        {
            var file = File.Open(filePath, FileMode.OpenOrCreate);
            using (StreamWriter fs = new StreamWriter(file))
            {
                fs.Write(inputTxt);
                fs.Close();
            }


        }
    }
}
