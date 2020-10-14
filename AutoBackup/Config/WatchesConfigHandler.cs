using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Xml;
using AutoBackup.Core;
using System.IO;

namespace AutoBackup.ConfigHandler
{
    public class WatchesConfigHandler : IConfigurationSectionHandler
    {
        const string N_Name =           "name";
        const string N_WatchedFolder =  "watchedFolder";
        const string N_BackupFolder =   "backupFolder";
        const string N_ChangeType =     "changeType";
        const string N_Enable =         "enable";
        public object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            //#warning 未有判断配置节中属性值拼写错误的情况
            List<WatchInfo> watches = new List<WatchInfo>();
            XmlNodeList nodeList = section.ChildNodes;
            foreach (XmlNode node in nodeList)
            {
                WatchInfo watch = new WatchInfo();
                //watch.Name = node.Attributes[N_Name].Value;
                watch.WatchedFolder = node.Attributes[N_WatchedFolder].Value;
                watch.BackupFolder = node.Attributes[N_BackupFolder].Value;
                string changeTypeVal = node.Attributes[N_ChangeType].Value;
                string[] changeTypeValArr = changeTypeVal.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                WatcherChangeTypes changeTypes = (WatcherChangeTypes)Enum.Parse(typeof(WatcherChangeTypes), changeTypeValArr[0], true);
                for (int i = 1; i < changeTypeValArr.Length; i++)
                {
                    WatcherChangeTypes changeType = (WatcherChangeTypes)Enum.Parse(typeof(WatcherChangeTypes), changeTypeValArr[i], true);
                    changeTypes = (changeTypes | changeType);
                }
                watch.ChangeTypes = changeTypes;
                watch.Enable = bool.Parse(node.Attributes[N_Enable].Value);
                watches.Add(watch);
            }
            return watches;
        }

    }
}
