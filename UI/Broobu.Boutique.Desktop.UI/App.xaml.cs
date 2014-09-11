using System;
using System.Windows;
using System.Windows.Threading;
using Broobu.Components.LogicNP;
using Broobu.Fx.UI;
using Broobu.Fx.UI.Deamons;
using Iris.Fx.Configuration;
using Iris.Fx.Domain;
using NLog;


namespace Broobu.Desktop.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App 
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public static readonly IrisSession Session = new IrisSession();




        public App()
        {
            LogicNPLicenseManager.RegisterShellObjects();
        }


    }
}
