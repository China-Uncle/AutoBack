using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AutoBackup.Core
{
    public class BackupInfo
    {
        public BackupInfo(string backupFullFileName, DateTime changeDate, WatcherChangeTypes changeType)
        {
            _backupFullFileName = backupFullFileName;
            _changeDate = changeDate;
            _changeType = changeType;
        }

        string _backupFullFileName;
        public string BackupFullFileName
        {
            get { return _backupFullFileName; }
            set { _backupFullFileName = value; }
        }

        DateTime _changeDate;
        public DateTime ChangeDate
        {
            get { return _changeDate; }
            set { _changeDate = value; }
        }

        WatcherChangeTypes _changeType;
        public WatcherChangeTypes ChangeType
        {
            get { return _changeType; }
            set { _changeType = value; }
        }
    }
}
