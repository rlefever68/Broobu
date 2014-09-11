using Broobu.Fx.UI.MVVM;

namespace Broobu.Boutique.Hub.UI.Controls.Mvvm
{
    public class ShuttingDownWaitInfo : WaitInfo
    {
        public ShuttingDownWaitInfo()
        {
            Header = "Goodbye for now...";
            Title = "Thank you for using Cloudeen.";
            Reason = "We hope to see you again soon!";
            Description = "";
           // Image =  (ImageSource)new ImageSourceConverter().ConvertFrom(Resources.Goodbye);
        }
    }
}