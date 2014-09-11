using System;
using Broobu.Fx.UI;
using System.Windows;
using Broobu.MonitorDisco.UI.Controls;

namespace Broobu.MonitorDisco.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App 
    {

        protected override Type GetAddInSourceType()
        {
            return typeof(MonitorCloudAddIn);
        }
    }
}
