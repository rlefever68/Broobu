using Pms.MobiLauncher.UI.Controls;
using Pms.MobiLauncher.UI.Controls.Interfaces;

namespace Pms.MobiLauncher.UI.Controls
{
    public class LoginViewFactory
    {

        public class Key
        {
            public const string Round = "Round";
            public const string Square = "Square";
        }



        public static ILoginWindow CreateLoginView(string key)
        {
            switch (key)
            {
                case Key.Round:
                    return new RoundLoginView();
                case Key.Square:
                default:
                    return new SquareLoginView();
            }
        }




    }
}
