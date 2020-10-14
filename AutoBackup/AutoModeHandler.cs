using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Win32;
using System.Windows.Forms;

namespace AutoBackup
{
    public class AutoModeHandler
    {
        private RegistryKey hklm;
        private RegistryKey run;
        string runKeyName ;
        string keyValue;
        public AutoModeHandler()
        {
            hklm = Registry.LocalMachine;
            run = hklm.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");//启动项键
            runKeyName = "autobackup";
            string appName = Application.ExecutablePath;//程序可执行文件名称
            string arg= " -automode";//启动参数
            keyValue = appName + arg;
        }

        /// <summary>
        /// 开启自动模式
        /// </summary>
        public void AutoModeOn()
        {
            try
            {
                run.SetValue(runKeyName, keyValue);
                run.Close();
                hklm.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 关闭自动模式
        /// </summary>
        public void AutoModeOff()
        {
            run.SetValue(runKeyName, false);
            run.Close();
            hklm.Close();
        }

        /// <summary>
        /// 是否已开启自动模式
        /// </summary>
        public bool IsAutoModeON
        {
            get
            {
                if (run.GetValue(runKeyName) !=null && run.GetValue(runKeyName).ToString() == keyValue)
                    return true;
                else
                    return false;
            }
        }
    }
}
