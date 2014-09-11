using System;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;
using DxNavigationControl.Common;
using System.Windows.Input;

namespace DxNavigationControl.ViewModels
{
    public class NavigationViewModel : ViewModel
    {
        private IViewLocator viewLocator;
        private ICommand onViewLoadedCommand;

        public IViewLocator ViewLocator
        {
            get
            {
                if (viewLocator == null)
                    viewLocator = new NaviViewLocator();
                return viewLocator;
            }
        }

        public ICommand OnViewLoadedCommand
        {
            get
            {
                if (onViewLoadedCommand == null)
                    onViewLoadedCommand = new DelegateCommand(OnViewLoaded);

                return onViewLoadedCommand;
            }
        }

        private void OnViewLoaded()
        {
            ServiceContainer.GetService<INavigationService>().Navigate("StartView", null, this);
        }

    }
}