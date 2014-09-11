using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pms.Framework.Domain;

namespace Pms.MobiLauncher.UI.Controls.Dialogs
{
    public class ExceptionDialog
    {
        public static bool Execute(ExceptionInfo info)
        {
            var f = new ExceptionMessageBox(info.TheException, info.TheException.Message);
            return (f.ShowDialog() == true);
        }
    }
}
