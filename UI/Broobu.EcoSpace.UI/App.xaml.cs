using System;
using Broobu.EcoSpace.UI.Controls;
using Broobu.Fx.UI;

namespace Broobu.EcoSpace.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App 
    {

        protected override Type GetAddInSourceType()
        {
            return typeof(EcoSpaceAddIn);
        }
        
    }
}
