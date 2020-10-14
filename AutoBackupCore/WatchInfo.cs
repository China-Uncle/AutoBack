using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AutoBackup.Core
{
    /// <summary>
    /// 一个监视实例
    /// </summary>
    [Serializable]
    public class WatchInfo
    {
        private string watchedFolder = string.Empty;
        private string backupFolder = string.Empty;
        private WatcherChangeTypes changeTypes;
        private bool enable;
        private bool includeSubdirectories;
        public WatchInfo(string watchedFolder, string backupFolder, WatcherChangeTypes changeType,bool includeSubdirectories, bool enable)
        {
            this.watchedFolder = watchedFolder;
            this.backupFolder = backupFolder;
            this.changeTypes = changeType;
            this.includeSubdirectories = includeSubdirectories;
            this.enable = enable;
        }
        public WatchInfo()
        { }


        /// <summary>
        /// 被监视的目录
        /// </summary>
        public string WatchedFolder
        {
            get { return watchedFolder; }
            set { watchedFolder = value; }
        }

        /// <summary>
        /// 备份目录
        /// </summary>
        public string BackupFolder
        {
            get { return backupFolder; }
            set { backupFolder = value; }
        }

        /// <summary>
        /// 监视的变更类型
        /// </summary>
        public WatcherChangeTypes ChangeTypes
        {
            get { return changeTypes; }
            set { changeTypes = value; }
        }

        /// <summary>
        /// 是否启用(处于运行或停止)
        /// </summary>
        public bool Enable
        {
            get { return enable; }
            set { enable = value; }
        }


        /// <summary>
        /// 是否包含子目录
        /// </summary>
        public bool IncludeSubdirectories
        {
            get { return includeSubdirectories; }
            set { includeSubdirectories = value; }
        }
    }
}
