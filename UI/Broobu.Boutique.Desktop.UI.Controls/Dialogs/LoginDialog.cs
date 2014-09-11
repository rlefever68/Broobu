using Pms.Framework.Domain;

namespace Pms.MobiLauncher.UI.Controls.Dialogs
{
    public class LoginDialog
    {

        public static bool ShowLoginDialog(PMSAuthRequest request, PMSSession session, string viewType)
        {
            var vw = LoginViewFactory
                .CreateLoginView(viewType);
            vw.Request = request;
            vw.Session = session;
            return (bool) (vw.ShowDialog());
        }
    }
}
