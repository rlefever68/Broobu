using System.Windows;
using Pms.MobiLauncher.UI.Controls;
using Pms.MobiLauncher.UI.Controls.Interfaces;
using Pms.Framework.Domain;
using Pms.Shell.UI;

namespace Pms.MobiLauncher.UI.Controls
{
    /// <summary>
    /// Interaction logic for Method2.xaml
    /// </summary>
    public partial class RoundLoginView : ILoginWindow,IPluginForm
    {
        public RoundLoginView()
        {
            InitializeComponent();
            Loaded += (s, e) =>
                          {
                              DataContext = new LoginViewModel();
                          };
        }


        

        public PMSAuthRequest Request { get; set;}
        public PMSSession Session { get; set;}
    }
}
