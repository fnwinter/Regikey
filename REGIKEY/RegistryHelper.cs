using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Microsoft.Win32;

namespace REGIKEY
{
    class RegistryHelper
    {
        static RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        public static bool isExist()
        {
            String value = (String)rkApp.GetValue("REGIKEY");
            return value != null;
        }

        public static void registAs(bool check, string path)
        {
            if (check)
            {
                // Add the value in the registry so that the application runs at startup
                rkApp.SetValue("REGIKEY", path);
            }
            else
            {
                // Remove the value from the registry so that the application doesn't start
                rkApp.DeleteValue("REGIKEY", false);
            }
        }
    }
}
