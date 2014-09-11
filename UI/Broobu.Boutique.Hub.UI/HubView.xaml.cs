using Broobu.Boutique.Hub.UI.Controls.Mvvm;
using DevExpress.Mvvm.UI;

namespace Broobu.Boutique.Hub.UI
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class HubView 
    {
        public HubView()
        {
            InitializeComponent();
            ViewLocator.Default = new HubViewLocator();
            HubViewModel.Navigator = NavService;
            Loaded += (s, e) => HubViewModel.Initialize(null);
        }
    }
}
