using System.Windows.Media;
using Broobu.Boutique.Hub.UI.Controls.Properties;
using Broobu.Fx.UI.MVVM;

namespace Broobu.Boutique.Hub.UI.Controls.Mvvm
{
    public class GetMenuWaitInfo : WaitInfo
    {
        public GetMenuWaitInfo()
        {
            Header = "Just a second...";
            Title = "We are fetching your personal menu.";
            Reason = "";
            Description = "";
            var cvn = new ImageSourceConverter();
            if(cvn.CanConvertFrom(Resources.TodaysMenu.GetType()))
            {
                var i = cvn.ConvertFrom(Resources.TodaysMenu);
                Image = (ImageSource)i;
            }
        }
    }
}