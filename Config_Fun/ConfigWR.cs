using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wafer_System.Log_Fun;

namespace Wafer_System.Config_Fun
{
    public class ConfigWR
    {
        private LogRW logRW;

        public ConfigWR(LogRW logRW)
        {
            this.logRW = logRW;
        }

        public bool WriteSettings(string key, string value)
        {
            try
            {
                var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configuration.AppSettings.Settings;               
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }

                configuration.Save(ConfigurationSaveMode.Minimal);
                ConfigurationManager.RefreshSection(configuration.AppSettings.SectionInformation.Name);
                return true;    
            }
            catch (Exception e)
            {
                logRW.WriteLog("WriteSettings " + e, "Config RW");
                return false;
            }
        }
        public string ReadSettings(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not found";
                Console.WriteLine(result);
                return result;
            }
            catch (Exception e)
            {
                logRW.WriteLog("ReadSettings " + e, "Config RW");

                return "";
            }
        }
        public bool ReadAllSettings()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                if (appSettings.Count == 0)
                {
                    logRW.WriteLog("AppSettings is empty " , "Config RW");
                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {
                        Console.WriteLine("key: {0}, Value: {1}", key, appSettings[key]);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                logRW.WriteLog("ReadAllSettings " + e, "Config RW");               
                return false;
            }
        }
    }
}
