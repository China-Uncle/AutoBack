using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using AutoBackup.Core;
using System.Reflection;

namespace AutoBackup
{
    class ModuleFactory
    {
        public static ISearchBackupFiles GetSearchBackupModule()
        {
            string searchBackupModuleFile = ConfigurationManager.AppSettings["SearchBackupModule"];
            object obj  = GetInterfaceObj("ISearchBackupFiles", searchBackupModuleFile);
            if (obj == null)
                obj = new XWXSearchBackup();
            return (ISearchBackupFiles)obj;
        }

        public static IRecord GetRecordModule()
        {
            string recordModuleFile = ConfigurationManager.AppSettings["RecordModule"];
            object obj = GetInterfaceObj("IRecorder", recordModuleFile);
            if (obj != null)
                return (IRecord)obj;
            else return null;
        }

        private static object GetInterfaceObj(string interfaceName, string moduleName)
        {
            if (string.IsNullOrEmpty(moduleName))
            {
                return null;
            }
            Assembly ass = Assembly.LoadFrom(moduleName);
            Type[] types = ass.GetTypes();
            object obj = null;
            foreach (Type type in types)
            {
                Type i = type.GetInterface(interfaceName);
                if (i != null)
                {
                    obj = Activator.CreateInstance(type);
                    break;
                }
            }
            return obj;
        }
    }
}
