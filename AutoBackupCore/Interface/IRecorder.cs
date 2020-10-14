using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AutoBackup.Core
{
    public interface IRecord
    {
        void Record(XWXFileSystemWatcher watcher, FileSystemEventArgs e);
    }
}
