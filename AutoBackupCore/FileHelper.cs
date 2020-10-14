using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AutoBackup.Core
{
    public class FileHelper
    {
        /// <summary>
        /// 复制文件(如果目标文件所在的目录路径不存在则创建该路径)
        /// </summary>
        /// <param name="sourceFileName">源文件</param>
        /// <param name="destFileName">目标文件</param>
        /// <param name="overwrite">是否覆盖同名文件</param>
        public static void SaveCopy(string sourceFileName, string destFileName, bool overwrite)
        {
            string destDir = destFileName.Substring(0, destFileName.LastIndexOf("\\"));
            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }
            File.Copy(sourceFileName, destFileName, overwrite);
        }
    }
}
