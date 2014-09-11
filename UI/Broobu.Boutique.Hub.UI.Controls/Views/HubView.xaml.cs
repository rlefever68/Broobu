using Broobu.Boutique.Hub.UI.Controls.ViewModel;
using DevExpress.Mvvm.UI;

namespace Broobu.Boutique.Hub.UI.Controls.Views
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
            Vm.Navigator = NavService;
            var vm = new HubViewModel {Navigator = NavService};
            DataContext = vm;
        }
    }
}
