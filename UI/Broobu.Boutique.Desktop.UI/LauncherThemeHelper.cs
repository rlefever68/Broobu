using System;
using System.Windows;
using Broobu.Fx.UI;

namespace Broobu.Desktop.UI
{
    public class LauncherThemeHelper
   {

        public static ResourceDictionary ReadCommonThemes()
        {
            var sri = Application.GetResourceStream(
                new Uri("/Iris.Desktop.UI;component/CommonThemes.xaml", UriKind.Relative));
            if (sri != null)
            {
                return (ResourceDictionary)BamlReader.Load(sri.Stream);
            }
            return new ResourceDictionary();
        }

    }
}
