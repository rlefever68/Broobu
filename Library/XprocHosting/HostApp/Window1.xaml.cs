using System;
using System.Windows;
using System.Windows.Threading;
using System.Threading;
using System.Windows.Input;
using Broobu.Fx.UI.Addin;

namespace HostApp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public static RoutedCommand FullScreen = 
            new RoutedUICommand("Switch to and from full screen", "FullScreen", typeof(Window1),
                new InputGestureCollection(new KeyGesture[] { new KeyGesture(Key.F11) }));

        public Window1()
        {
            InitializeComponent();
        }


        private void OnFullScreenCommand(object sender, ExecutedRoutedEventArgs e)
        {
            if(WindowState != WindowState.Maximized)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (!e.Handled && e.Key == Key.F5 && 
                e.KeyboardDevice.Modifiers == (ModifierKeys.Control|ModifierKeys.Shift))
            {
                e.Handled = true;
                // Do the unloading asynchronously to avoid a deadlock if the key press was bubbled from 
                // the add-in. Too much re-entrancy going on!
                Dispatcher.BeginInvoke(delegate
                {
                });
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            HostView.AppUrl = "http://www.broobu.com/clickonce/broobu/addin/addin.application";
            //HostView.AppUrl = "http://www.broobu.com/clickonce/broobu/underconstruction/broobu.underconstruction.ui.application";
        }

        private void ButtonBase_OnClick__(object sender, RoutedEventArgs e)
        {
            HostView.SendMessageToAddin("SetTheme", "MetropolisDark");
        }
    };
}
