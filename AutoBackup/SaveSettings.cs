using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AutoBackup.Core;
using AutoBackup.Serialization;
using System.Threading;

namespace AutoBackup
{
    public delegate void SettingChangedHandler();
    public partial class MainForm 
    {
        /// <summary>
        /// 当用户对监视程序进行任何改动时触发该事件
        /// </summary>
        private event SettingChangedHandler OnWatchSettingChanged;

        private void HandleWatchSettingChanged()
        {
            ThreadStart ts = new ThreadStart(SaveRecords);
            Thread thread = new Thread(ts);
            thread.Start();
        }

        //对目前的监视项进行保存
        private void SaveRecords()
        {
            List<WatchInfo> watches = new List<WatchInfo>();
            foreach (XWXFileSystemWatcher w in watcherList)
            {
                WatchInfo watchInfo = new WatchInfo(w.Path, w.BackupFolder, w.WatchingChangeTypes,w.IncludeSubdirectories, w.EnableRaisingEvents);
                watches.Add(watchInfo);
            }
            serializationHandler.Serialize(watches);
        }
    }
}
