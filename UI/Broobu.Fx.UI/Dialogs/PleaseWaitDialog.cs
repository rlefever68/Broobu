using System;
using Broobu.Fx.UI.Controls;

namespace Broobu.Fx.UI.Dialogs
{
    public class PleaseWaitDialog
    {
        private static PleaseWaitWindow wnd;

        public static void Show(string message)
        {
            if (wnd == null)
            {
                wnd = new PleaseWaitWindow {DataContext = message};
            }
            wnd.DataContext = message;
            wnd.Show();
        }


        public static void Show(string message, params object[] its)
        {
            Show(String.Format(message, its));
        }


        public static void Close()
        {
            if (wnd == null) return;
            wnd.Close();
            wnd = null;
        }
    }
}