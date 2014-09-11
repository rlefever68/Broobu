using System;
using System.Collections.Generic;
using Broobu.Boutique.Hub.UI.Controls.Views;
using Broobu.EcoSpace.Contract.Domain.Menu;
using Broobu.Fx.UI.Deamons;
using Broobu.Fx.UI.Domain;
using Broobu.Fx.UI.MVVM;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Xpf.WindowsUI.Navigation;
using NLog;
using NavigationEventArgs = DevExpress.Xpf.WindowsUI.Navigation.NavigationEventArgs;

namespace Broobu.Boutique.Hub.UI.Controls.Mvvm
{
    //A View Model for a GroupedItemsPage
    public class MenuViewModel : FxViewModelBase, INavigationAware
    {

        public MenuButton ClickedButton { get; set; }


        IEnumerable<IMenuButton> _items;
        
        public MenuViewModel() 
        { 
            Messenger.Default.Register<MenuMvvmMessage>(this,null, (m) => 
            {
                Items = m.Menu.Buttons;
            });
        }

        public IEnumerable<IMenuButton> Items
        {
            get { return _items; }
            set 
            {
                _items = value;
                RaisePropertyChanged("Items");
            }
        }


        [Command(Name="RunApplet",UseCommandManager = true)]
        public void RunApplet(MenuButton button)
        {
            if (button == null) return;
            _logger.Info("Trying to start applet {0}",button.Applet);
            if (button.Applet.IsEmbedded)
                Messenger.Default.Send(new NavigateMvvmMessage()
                {
                    Header = button.Caption,
                    ViewName = AppHostView.ID,
                    Parameter = button
                });
            else
                ComSink.StartApplet(button.LaunchUrl);
        }
       


        #region INavigationAware Members
        public void NavigatedFrom(NavigationEventArgs e)
        {
           
        }
        
        public void NavigatedTo(NavigationEventArgs e)
        {
            _appUrl = String.Empty;
            Messenger.Default.Send(new MenuMvvmMessage() {Menu=null});
        }
        
        public void NavigatingFrom(NavigatingEventArgs e)
        {
            _appUrl = Convert.ToString(e.Parameter).ToLower();
        }
        #endregion

        string _appUrl;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        protected override void InitializeInternal(object[] parameters)
        {
            
        }
    }
}
