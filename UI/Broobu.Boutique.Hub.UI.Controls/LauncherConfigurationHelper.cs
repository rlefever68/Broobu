using System;
using System.Configuration;

namespace Broobu.Boutique.Hub.UI.Controls
{
    public class LauncherConfigurationHelper
    {
        public static bool RunOnlyOneInstance
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["Boutique.Singleton"]);
            }
        }

        public static string DefaultTheme 
        { 
            get
            {
                var s = ConfigurationManager.AppSettings["Boutique.Theme"];
                return String.IsNullOrWhiteSpace(s) ? "TouchlineDark" : Convert.ToString(s);
            }
        }
    }
}
