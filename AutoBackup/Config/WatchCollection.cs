using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace AutoBackup.Config
{
    [ConfigurationCollection(typeof(WatchItem))]
    public class WatchCollection : ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        protected override string ElementName
        {
            get
            {
                return "watch";
            }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new WatchItem();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((WatchItem)element).WatchedFolder;
        }
    }
}
