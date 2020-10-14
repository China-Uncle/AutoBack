using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using AutoBackup.Core;
using System.Windows.Forms;

namespace AutoBackup.Serialization
{
    /// <summary>
    /// 使用序列化对监视项进行序列化或反序列化操作
    /// </summary>
    public class SerializationHandler
    {
        BinaryFormatter bin;
        string datFileName;
        public SerializationHandler()
        {
            bin = new BinaryFormatter();
            datFileName = Application.StartupPath + "\\record.dat";
        }
        /// <summary>
        /// 序列化一个监视的List到dat文件
        /// </summary>
        /// <param name="watches"></param>
        public void Serialize(List<WatchInfo> watches)
        {
            try
            {
                FileStream fs = new FileStream(datFileName, FileMode.OpenOrCreate);
                bin.Serialize(fs, watches);
                fs.Flush();
                fs.Close();
                fs.Dispose();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 从dat文件中反序列化最后一次保存的监视List
        /// </summary>
        /// <returns>最后一次保存的监视List</returns>
        public List<WatchInfo> Deserialize()
        {
            if (!File.Exists(datFileName))
            {
                return null;
            }
            try
            {
                FileStream fs = new FileStream(datFileName, FileMode.Open);
                object graph = bin.Deserialize(fs);
                fs.Close();
                fs.Dispose();
                return graph as List<WatchInfo>;

            }
            catch(Exception ex) {
                throw ex;
            }
        }

    }
}
