using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Broobu.Engine.Service
{
    public static class ServiceHelper
    {

        private static readonly Logger Logger = LogManager.GetLogger(AppDomain.CurrentDomain.GetType().FullName);
        public static void EnableExceptionHandling()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            Logger.Info("Enabling Exception handling for '{0}'", AppDomain.CurrentDomain.FriendlyName);
            currentDomain.UnhandledException += (s, e) => {
                var o = e.ExceptionObject as Exception;
                if (o == null) return;
                Logger.Error("");
                Logger.Error(o.Message);
                Logger.Error("StackTrace:\n");
                Logger.Error(o.StackTrace);
                if(e.IsTerminating)
                    Logger.Error("Terminating the service\n");
            };
        }

    }
}
