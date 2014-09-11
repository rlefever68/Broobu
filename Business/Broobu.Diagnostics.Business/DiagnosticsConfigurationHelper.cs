using System;
using System.Configuration;
using System.Web.Hosting;
using log4net;

namespace Pms.Diagnostics.Business
{
    public class DiagnosticsConfigurationHelper
    {

       private static ILog _logger = LogManager.GetLogger(typeof(DiagnosticsConfigurationHelper));
       private class Key
       {
            public const string DiagnosticsLoc = "Diagnostics.Location";
        }


        private class Default
        {
            public const string DiagnosticsLoc= "~/bin";
        }

        public DiagnosticsConfigurationHelper()
        {

        }


        public static string DiagnosticsLocation 
        { 
            get 
            {
                try
                {
                    return HostingEnvironment.MapPath(String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings[Key.DiagnosticsLoc]) ? 
                        Default.DiagnosticsLoc : 
                        ConfigurationManager.AppSettings[Key.DiagnosticsLoc]);
                }
                catch (Exception ex)
                {
                    return HostingEnvironment.MapPath(Default.DiagnosticsLoc);
                }
            }
        }







    }
}
