using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Xpf.WindowsUI.Navigation;

namespace Broobu.Fx.UI.MVVM
{
    public class WaitViewModel : FxViewModelBase, INavigationAware
    {
        private WaitInfo _waitInfo;

        public WaitInfo WaitInfo
        {
            get { return _waitInfo; }
            set
            {
                _waitInfo = value;
                RaisePropertyChanged("WaitInfo");
            }
        }


        public void NavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is WaitInfo)
                WaitInfo = e.Parameter as WaitInfo;
        }

        public void NavigatingFrom(NavigatingEventArgs e)
        {
        }

        public void NavigatedFrom(NavigationEventArgs e)
        {
            if (e.Parameter is WaitInfo)
                WaitInfo = e.Parameter as WaitInfo;
        }

        protected override void InitializeInternal(object[] parameters)
        {
        }


        [Command(Name = "Close", UseCommandManager = true)]
        public void Close()
        {
        }
    }
}