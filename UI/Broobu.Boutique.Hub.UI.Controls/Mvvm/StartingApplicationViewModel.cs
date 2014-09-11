using Broobu.Fx.UI.MVVM;
using DevExpress.Xpf.WindowsUI.Navigation;

namespace Broobu.Boutique.Hub.UI.Controls.Mvvm
{
    public class StartingApplicationViewModel : FxViewModelBase,INavigationAware
    {
        protected override void InitializeInternal(object[] parameters)
        {
            
        }


        public void NavigatedTo(NavigationEventArgs e)
        {
        }

        public void NavigatingFrom(NavigatingEventArgs e)
        {
            
        }

        public void NavigatedFrom(NavigationEventArgs e)
        {
        }
    }
}
