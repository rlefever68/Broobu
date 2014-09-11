using System;
using Broobu.Fx.UI.Controls;
using Iris.Fx.Domain;
using Iris.Fx.Exceptions;
using NLog;

namespace Broobu.Fx.UI.Dialogs
{
    public class ExceptionDialog
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public static bool Execute(ExceptionInfo info)
        {
            try
            {
                if (info == null) return true;
                if (info.TheException == null) return true;
                var f = new Views.ExceptionWindow {DataContext = info.TheException};
                return (f.ShowDialog() == true);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.GetCombinedMessages());
                return true;
            }
        }
    }
}