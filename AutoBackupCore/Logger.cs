using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AutoBackup.Core
{
   public class Logger
    {
        /// <summary>
        /// 对备份操作进行日志记录
        /// </summary>
        /// <param name="date">备份的时间</param>
        /// <param name="action">引起备份的动作</param>
        /// <param name="backupResult">备份执行结果</param>
        /// <param name="sourceFile">源文件</param>
        /// <param name="destFile">目标文件</param>
        /// <param name="remark">备注</param>
        public static void LogBackup(XWXFileSystemWatcher watcher, DateTime date, string action, string backupResult, string sourceFile, string destFile, string remark)
        {
            string logFolder = GetOrCreateLogFilePath();
            string logFile = GetBackupLogFileName(watcher);
            string logString = string.Format("【备份时间:{0} 动作:{1} 执行结果:{2} 源:\"{3}\" 目标:\"{4}\" 备注:{5} 】\r\n\r\n",
                                            date.ToString("yyyy-MM-dd HH:mm:ss"),
                                            action,
                                            backupResult,
                                            sourceFile,
                                            destFile,
                                            remark
                                            );
            FileInfo file = new FileInfo(logFile);
            FileStream fs = file.Open(FileMode.Append, FileAccess.Write);
            byte[] bytes = Encoding.UTF8.GetBytes(logString);
            fs.Write(bytes, 0, bytes.Length);
            fs.Flush();
            fs.Close();
            fs.Dispose();
        }
        public static void LogBackup(string logString)
        {
            string logFolder = GetOrCreateLogFilePath();
            string logFile = logFolder+"\\log.txt";
            FileInfo file = new FileInfo(logFile);
            FileStream fs = file.Open(FileMode.Append, FileAccess.Write);
            byte[] bytes = Encoding.UTF8.GetBytes(logString);
            fs.Write(bytes, 0, bytes.Length);
            fs.Flush();
            fs.Close();
            fs.Dispose();
        }

        //获取备份目录路径，如果不存在则创建
        private static string GetOrCreateLogFilePath()
        {
            string backupFolder = System.Environment.CurrentDirectory + "\\log";
            if (!Directory.Exists(backupFolder))
                Directory.CreateDirectory(backupFolder);
            return backupFolder;
        }

        private static string GetBackupLogFileName(XWXFileSystemWatcher watcher)
        {
            //为每个监视独立建立一个日志。日志名称格式为:log__监视路径__.txt,例如:log__c_folder1_folder2__.txt 代表监视"c:\folder1\folder2"的日志
            string logFileId = watcher.Path.Replace(":\\", "_").Replace("\\", "_");
            return GetOrCreateLogFilePath() + "\\log__" + logFileId + "__.txt";
        }
    }
}
