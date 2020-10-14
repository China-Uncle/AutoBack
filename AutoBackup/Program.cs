using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AutoBackup
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm form=null;
            foreach (string arg in System.Environment.GetCommandLineArgs())
            {
                if (arg == "-automode")
                {
                    form = new MainForm(arg);
                    break;
                }
            }
            if (form == null)
            {
                form = new MainForm("");
            }
            Application.Run(form);
          
        }
    }
}
