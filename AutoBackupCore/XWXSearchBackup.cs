using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AutoBackup.Core
{
    public class XWXSearchBackup : ISearchBackupFiles
    {
        #region ISearchBackupFiles 成员

        public List<BackupInfo> SearchBackupFiles(string path,DateTime startingDate, DateTime endingDate, string fileNameKeyword, WatcherChangeTypes changeType, bool includeSubdir)
        {
            List<string> searchFileResults = new List<string>();//定义一个集合来存储所有搜索到的文件的名称

            SearchFiles(path, changeType, includeSubdir, ref searchFileResults);
            List<BackupInfo> searchResults = new List<BackupInfo>();
            foreach (string backupFullFileName in searchFileResults)
            {
                DateTime date = DateTime.MinValue;
                string displayedName = null;
                string fileName = null;
                WatcherChangeTypes _changeType = WatcherChangeTypes.Created;
                if (SplitFileName(backupFullFileName, ref displayedName, ref fileName, ref date, ref _changeType))
                {
                    if (date >= startingDate && date <= endingDate)//如果该文件时间是在开始时间和结束时间内的，则显示在列表中
                    {
                        if (string.IsNullOrEmpty(fileNameKeyword) || displayedName.Contains(fileNameKeyword))
                        {
                            BackupInfo bak = new BackupInfo(backupFullFileName,date, _changeType);
                            searchResults.Add(bak);
                        }
                    }
                }
            }
            return searchResults;
        }


        /// <summary>
        /// 搜索一个目录下的备份文件
        /// </summary>
        /// <param name="dir">目录路径</param>
        /// <param name="action">动作</param>
        /// <param name="includeSubDir">是否搜索子目录</param>
        /// <param name="results">搜索结果</param>
        public void SearchFiles(string dir, WatcherChangeTypes changeType, bool includeSubDir, ref List<string> results)
        {
            if ((changeType & WatcherChangeTypes.Changed)==WatcherChangeTypes.Changed && (changeType & WatcherChangeTypes.Created) == WatcherChangeTypes.Created && (changeType & WatcherChangeTypes.Renamed) == WatcherChangeTypes.Renamed)
            {
                string[] arrCreated = Directory.GetFiles(dir, "*.Created");
                string[] arrChanged = Directory.GetFiles(dir, "*.Changed");
                string[] arrRenamed = Directory.GetFiles(dir, "*.Renamed");
                results.AddRange(arrCreated.ToList<string>());
                results.AddRange(arrChanged.ToList<string>()); 
                results.AddRange(arrRenamed.ToList<string>());
            }
            else if (changeType == WatcherChangeTypes.Created)
            {
                string[] fileNames = Directory.GetFiles(dir, "*.Created");
                results.AddRange(fileNames.ToList<string>());
            }
            else if (changeType == WatcherChangeTypes.Changed)
            {
                string[] fileNames = Directory.GetFiles(dir, "*.Changed");
                results.AddRange(fileNames.ToList<string>());
            }
            else
            {
                string[] fileNames = Directory.GetFiles(dir, "*.Renamed");
                results.AddRange(fileNames.ToList<string>());
            }

            //如果包含子目录，则递归
            if (includeSubDir)
            {
                string[] subDirs = Directory.GetDirectories(dir);
                if (subDirs == null || subDirs.Length == 0)
                {
                    return;
                }
                foreach (string subDir in subDirs)
                {
                    SearchFiles(subDir, changeType, true, ref results);
                }
            }
            return;
        }


        /// <summary>
        /// 对一个备份文件名称进行分解，分别获得该备份文件的源文件名称，动作时间和备份动作
        /// </summary>
        /// <param name="backupFileName">备份文件名称</param>
        /// <param name="fileName">源文件的名称</param>
        /// <param name="datetime">备份时间</param>
        /// <param name="action">动作名称</param>
        /// <returns></returns>
        public bool SplitFileName(string backupFullFileName, ref string displayedName, ref string fileName, ref DateTime datetime, ref WatcherChangeTypes changeType)
        {
            //eg:abc.txt@2013_03_01_11_20_49.Created
            int minLen = 25;//min len of a backupName,len of @2013_03_01_11_20_49.Created/Changed
            if (backupFullFileName.Length < minLen)
            {
                return false;
            }
            int pos = backupFullFileName.LastIndexOf("@");
            if (pos <= 0)
            {
                return false;
            }
            try
            {
                int lenOfDate = 19;//length of "yyyy_MM_dd_HH_mm_ss"
                displayedName = backupFullFileName.Substring(0, pos);
                fileName = displayedName.Substring(displayedName.LastIndexOf("\\") + 1);
                string datetimeStr = backupFullFileName.Substring(pos + 1, lenOfDate);
                string[] dateArr = datetimeStr.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                datetime = new DateTime(Convert.ToInt32(dateArr[0]),
                                        Convert.ToInt32(dateArr[1]),
                                        Convert.ToInt32(dateArr[2]),
                                        Convert.ToInt32(dateArr[3]),
                                        Convert.ToInt32(dateArr[4]),
                                        Convert.ToInt32(dateArr[5]));
                changeType = (WatcherChangeTypes)Enum.Parse(typeof(WatcherChangeTypes),backupFullFileName.Substring(pos + 1 + lenOfDate + 1));
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
