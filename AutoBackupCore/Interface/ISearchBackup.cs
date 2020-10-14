using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AutoBackup.Core
{
    public interface ISearchBackupFiles
    {
        List<BackupInfo> SearchBackupFiles(string path,DateTime startingDate, DateTime endingDate, string fileNameKeyword, WatcherChangeTypes changeType, bool includeSubdir); 
    }
}
