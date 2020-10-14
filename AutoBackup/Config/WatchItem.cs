using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace AutoBackup.Config
{

    class WatchItem:ConfigurationElement
    {
        //[ConfigurationProperty("name", IsRequired = true)]
        //public String Name
        //{
        //    get
        //    { return (String)this["name"]; }
        //    set
        //    { this["name"] = value; }
        //}

        [ConfigurationProperty("watchedFolder", IsRequired = true)]
        public String WatchedFolder
        {
            get
            { return (String)this["watchedFolder"]; }
            set
            { this["watchedFolder"] = value; }
        }

        [ConfigurationProperty("backupFolder", IsRequired = true)]
        public String BackupFolder
        {
            get
            { return (String)this["backupFolder"]; }
            set
            { this["backupFolder"] = value; }
        }

        [ConfigurationProperty("changeType", IsRequired = true)]
        public String ChangeType
        {
            get
            { return (String)this["changeType"]; }
            set
            { this["changeType"] = value; }
        }

        [ConfigurationProperty("enable", IsRequired = true)]
        public String Enable
        {
            get
            { return (String)this["enable"]; }
            set
            { this["enable"] = value; }
        }
    }
}
