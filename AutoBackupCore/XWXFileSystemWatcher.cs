using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AutoBackup.Core
{
    public class WatchStatusChangedEventArgs:EventArgs
    {
        private bool isWatching;
        public bool IsWatching
        {
            get { return isWatching; }
            set { isWatching = value; }
        }
    }

    public delegate void WatchStatusChangedHandler(object sender,WatchStatusChangedEventArgs e);

    public class XWXFileSystemWatcher : FileSystemWatcher
    {

        public XWXFileSystemWatcher(string watchingFloder): base(watchingFloder)
        {
        }

        /// <summary>
        /// 当监视的状态发生改变时触发该事件
        /// </summary>
        public event WatchStatusChangedHandler OnWatchStatusChanged;

        private string _backupFolder;
        /// <summary>
        /// 该监控的备份目录
        /// </summary>
        public string BackupFolder
        {
            get { return _backupFolder; }
            set { _backupFolder = value; }
        }

        /// <summary>
        /// 是否处于监视状态(该属性只读)
        /// </summary>
        public new bool EnableRaisingEvents
        {
            //掩盖父类EnableRaisingEvents属性，确保只能使用StartWatch()和StopWatch()方法来启动或停止监视
            get
            {
                return base.EnableRaisingEvents;
            }
        }

        /// <summary>
        /// 开始进行监控
        /// </summary>
        public void StartWatch()
        {
            if (base.EnableRaisingEvents != true)
            {
                WatchStatusChangedEventArgs e = new WatchStatusChangedEventArgs();
                base.EnableRaisingEvents = e.IsWatching = true;
                OnWatchStatusChanged(this, e);
            }
            
        }

        /// <summary>
        /// 停止监控
        /// </summary>
        public void StopWatch()
        {
            if (base.EnableRaisingEvents != false)
            {
                WatchStatusChangedEventArgs e = new WatchStatusChangedEventArgs();
                base.EnableRaisingEvents = e.IsWatching = false;
                OnWatchStatusChanged(this, e);
            }
        }

        
        private WatcherChangeTypes watchingChangeTypes = 0;
        /// <summary>
        /// 正在监视的变更类型,默认值为0，即没有变更类型被监视
        /// </summary>
        public WatcherChangeTypes WatchingChangeTypes
        {
            get { return watchingChangeTypes; }
            set { watchingChangeTypes = value; }
        }
    }
}
