﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace utldecm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            executeWarnings eW = new executeWarnings();
            Application.Run();
        }
    }
}
