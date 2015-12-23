using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ChangeIt
{
    public class Library
    {
        public string LoadSetting(string key)
        {
            if (ApplicationData.Current.LocalSettings.Values[key] != null)
            {
                return ApplicationData.Current.LocalSettings.Values[key].ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public void SaveSetting(string key, string value)
        {
            ApplicationData.Current.LocalSettings.Values[key] = value;
        }
    }
}
