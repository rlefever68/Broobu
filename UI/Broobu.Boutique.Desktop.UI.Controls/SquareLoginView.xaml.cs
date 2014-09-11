using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Pms.MobiLauncher.UI.Controls.Interfaces;
using Pms.Framework.Domain;
using Pms.Shell.UI;

namespace Pms.MobiLauncher.UI.Controls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SquareLoginView : ILoginWindow, IPluginForm
    {
        public SquareLoginView()
        {
            InitializeComponent();
            Loaded += (s, e) => { ((LoginViewModel)grdLogin.DataContext).Initialize(); };
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public PMSAuthRequest Request { get; set;}
        public PMSSession Session { get; set; }
    }
}
