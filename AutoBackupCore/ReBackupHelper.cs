using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AutoBackup.Core
{
    public class ReBackupHelper
    {

        public static void Rebackup(List<BackupInfo> backupFileInfos,string backupFolder, string destFolder)
        {
            foreach (BackupInfo bf in backupFileInfos)
            {
                string backupFileNameExtless = bf.BackupFullFileName.Substring(0, bf.BackupFullFileName.LastIndexOf("@"));
                string destFileName = destFolder + bf.BackupFullFileName.Replace(backupFolder, string.Empty);
                destFileName = destFileName.Substring(0, destFileName.LastIndexOf("@"));
                if (File.Exists(destFileName))
                {
                    DialogResult dialogResult = MessageBox.Show(string.Format("文件:{0} \r\n描述:于{1} 执行 {2} 备份\r\n\r\n在目录{3} 中已经存在同名文件,是否覆盖?\r\n点击\"是\":覆盖同名文件\r\n点击\"否\":重命名该文件\r\n点击\"取消\":忽略该文件", destFileName, bf.ChangeDate.ToString("yyyy-MM-dd HH:mm:ss"), Enum.GetName(bf.ChangeType.GetType(), bf.ChangeType), destFolder), "发现同名文件", MessageBoxButtons.YesNoCancel);
                    if (dialogResult == DialogResult.Yes)//覆盖文件
                    {
                        File.Copy(bf.BackupFullFileName, destFileName, true);
                    }
                    else if (dialogResult == DialogResult.No)//重命名
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Title = string.Format("正在将文件 {0} 另存为...", backupFileNameExtless);
                        sfd.InitialDirectory = destFolder;
                        sfd.Filter = "所有文件(*.*)|*.*";
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            File.Copy(bf.BackupFullFileName, sfd.FileName, true);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else//忽略该文件
                    {
                        continue;
                    }
                }
                FileHelper.SaveCopy(bf.BackupFullFileName, destFileName, true);
            }
        }
    }
}
