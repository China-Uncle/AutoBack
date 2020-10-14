using System;
using System.Collections.Generic;
using System.Text;
using AutoBackup.Core;
using System.IO;

namespace AutoBackup.Core
{
    public class BackupHelper
    {
        public static void Backup(XWXFileSystemWatcher watcher, FileSystemEventArgs e, IRecord recorder)
        {
            if (e.Name.IndexOf(".") > -1)
            {
                return;
            } 
            FileAttributes attrs = File.GetAttributes(e.FullPath);
            //判断改路径是一个文件还是一个目录
            bool isFolder = ((attrs & FileAttributes.Directory) == FileAttributes.Directory);
            //如果是一个目录，则在备份目录中创建一个同名目录
            if (isFolder)
            {
                string backupDir = watcher.BackupFolder + "\\" + e.Name;
                //如果备份文件夹中不存在该目录，则创建之
                if (!Directory.Exists(backupDir))
                {
                    Directory.CreateDirectory(backupDir);
                }
            }
            else//如果是一个文件，则备份文件
            {

                string destFileName = watcher.BackupFolder + "\\" + e.Name;
                //备份文件的后缀(格式为:".yyyy_MM_dd_HH_mm_ss.changedType",例如:2013_02_28_14_12_32.created)
                string extendName = DateTime.Now.ToString("@yyyy_MM_dd_HH_mm_ss") + "." + System.Enum.GetName(e.ChangeType.GetType(), e.ChangeType);
                string backupFileName = destFileName + extendName;

                //检查文件是否已经存在，存在则不进行操作
                if (File.Exists(backupFileName))
                {
                    return;
                }
                try
                {
                    //将文件复制到备份目录进行备份，并记录入日志
                    FileHelper.SaveCopy(e.FullPath, backupFileName, false);
                    if (recorder != null)
                    {
                        recorder.Record(watcher, e);
                    }
                    Logger.LogBackup(watcher, DateTime.Now, Enum.GetName(e.ChangeType.GetType(), e.ChangeType), "成功", e.FullPath, backupFileName, string.Empty);
                }
                catch (Exception ex)
                {
                    //如果发生IO异常，则记录日志，以便追踪
                    Logger.LogBackup(watcher, DateTime.Now, Enum.GetName(typeof(WatcherChangeTypes), e.ChangeType), "失败", e.FullPath, backupFileName, ex.Message);
                }
            }
        }
        public static void Backup(XWXFileSystemWatcher watcher, RenamedEventArgs e, IRecord recorder)
        {
            try
            { 
            FileAttributes attrs = File.GetAttributes(e.FullPath);
            //判断改路径是一个文件还是一个目录
            bool isFolder = ((attrs & FileAttributes.Directory) == FileAttributes.Directory);
            //如果是一个目录，则在备份目录中创建一个同名目录
            if (isFolder)
            {
                string backupDir = watcher.BackupFolder + "\\" + e.Name;
                //如果备份文件夹中不存在该目录，则创建之
                if (!Directory.Exists(backupDir))
                {
                    Directory.CreateDirectory(backupDir);
                }
            }
            else//如果是一个文件，则备份文件
            {
                string destFileName = watcher.BackupFolder + "\\" + e.Name;
                //备份文件的后缀(格式为:".yyyy_MM_dd_HH_mm_ss.changedType",例如:2013_02_28_14_12_32.created)
                string extendName = DateTime.Now.ToString("@yyyy_MM_dd_HH_mm_ss") + "." + System.Enum.GetName(e.ChangeType.GetType(), e.ChangeType);
                string backupFileName = destFileName + extendName;

                //检查文件是否已经存在，存在则不进行操作
                if (File.Exists(backupFileName))
                {
                    return;
                }
                try
                {
                    //将文件复制到备份目录进行备份，并记录入日志
                    FileHelper.SaveCopy(e.FullPath, backupFileName, false);
                    if (recorder != null)
                    {
                        recorder.Record(watcher, e);
                    }
                    Logger.LogBackup(watcher, DateTime.Now, Enum.GetName(e.ChangeType.GetType(), e.ChangeType), "成功", e.FullPath, backupFileName, string.Empty);
                }
                catch (Exception ex)
                {
                    //如果发生IO异常，则记录日志，以便追踪
                    Logger.LogBackup(watcher, DateTime.Now, Enum.GetName(typeof(WatcherChangeTypes), e.ChangeType), "失败", e.FullPath, backupFileName, ex.Message);
                }
            }
            }
            catch (Exception ex)
            {
                Logger.LogBackup(watcher, DateTime.Now, Enum.GetName(typeof(WatcherChangeTypes), e.ChangeType), "失败", e.FullPath, "", ex.Message);
            }
        }
    }

}
