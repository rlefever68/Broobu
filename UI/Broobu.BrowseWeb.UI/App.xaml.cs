using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows;

namespace Broobu.BrowseWeb.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App 
    {
        protected override Type GetAddInSourceType()
        {
            return typeof(BrowseAddIn);
        }
    }
}
