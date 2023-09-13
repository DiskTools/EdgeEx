﻿using EdgeEx.WinUI3.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace EdgeEx.WinUI3.Toolkits
{
    /// <summary>
    /// Toolkit that control the settings of app
    /// </summary>
    public class LocalSettingsToolkit
    {
        /// <summary>
        /// Does the setting name exist in the local app settings
        /// </summary>
        /// <param name="settingName">setting name</param>
        public  bool Contains(LocalSettingName settingName)
        {
            return ApplicationData.Current.LocalSettings.Values.ContainsKey(settingName.ToString());
        }
        #region  Set
        private  void Set(LocalSettingName settingName, object value)
        {
            ApplicationData.Current.LocalSettings.Values[settingName.ToString()] = value;
        }
        public  void Set(LocalSettingName settingName, string value)
        {
            Set(settingName, (object)value);
        }
        public  void Set(LocalSettingName settingName, int value)
        {
            Set(settingName, (object)value);
        }
        public  void Set(LocalSettingName settingName, float value)
        {
            Set(settingName, (object)value);
        }
        public  void Set(LocalSettingName settingName, bool value)
        {
            Set(settingName, (object)value);
        }

        #endregion

        #region  Get
        public  object Get(LocalSettingName settingName)
        {
            if (Contains(settingName))
            {
                return ApplicationData.Current.LocalSettings.Values[settingName.ToString()];
            }
            return null;
        }
        public  string GetString(LocalSettingName settingName)
        {
            return (string)Get(settingName);
        }
        public  float GetFloat(LocalSettingName settingName)
        {
            return (float)Get(settingName);
        }
        public int GetInt32(LocalSettingName settingName)
        {
            return (int)Get(settingName);
        }
        public bool GetBoolean(LocalSettingName settingName)
        {
            return (bool)Get(settingName);
        }
        #endregion
    }
}
