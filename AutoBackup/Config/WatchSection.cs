using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace AutoBackup.Config
{
    public class WatchSection : ConfigurationSection
    {
        [ConfigurationProperty("",IsDefaultCollection=true)]
        public WatchCollection Watches
        {
            get
            {
                return (WatchCollection)this[""];
            }
        }
    }


}
