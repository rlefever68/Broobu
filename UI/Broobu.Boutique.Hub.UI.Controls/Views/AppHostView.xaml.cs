// ***********************************************************************
// Assembly         : HostApp
// Author           : Rafael Lefever
// Created          : 07-31-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-02-2014
// ***********************************************************************
// <copyright file="Window1.xaml.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using Broobu.EcoSpace.Contract.Domain.Menu;
using Broobu.Fx.UI.Addin;
using Broobu.Fx.UI.Deamons;
using DevExpress.Xpf.WindowsUI.Navigation;
using NLog;

namespace Broobu.Boutique.Hub.UI.Controls.Views
{

    /// <summary>
    /// Class AppHostView.
    /// </summary>
    public partial class AppHostView : INavigationAware
    {
        /// <summary>
        /// The full screen
        /// </summary>
        public static RoutedCommand FullScreen = 
            new RoutedUICommand("Switch to and from full screen", "FullScreen", typeof(AppHostView),
                new InputGestureCollection(new[] { new KeyGesture(Key.F11) }));

        /// <summary>
        /// Loads the add in.
        /// </summary>
        public void LoadAddIn()
        {
            //if (AddinPanel.Child != null) return;
            // Do the loading asynchronously to save startup time.
            ComSink.RunApplet(_appInfo.LaunchUrl, OnAddInAvailableAsync);
        }



        /// <summary>
        /// Gets or sets the application information.
        /// </summary>
        /// <value>The application information.</value>
        public MenuButton AppInfo
        {
            get { return _appInfo; }
            set 
            { 
                _appInfo = value;
                LoadAddIn();
            }
        }

        public static string ID = "AppHostView";


        //public string AppUrl
        //{
        //    get 
        //    { 
        //        return Convert.ToString(GetValue(AppUrlProperty)); }
        //    set 
        //    { 
        //    }
        //}


        /// <summary>
        /// Handles the <see cref="E:AddInAvailableAsync" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void OnAddInAvailableAsync(object sender, EventArgs e)
        {
            ((XProcAddInHost)sender).AddInAvailableAsync -= OnAddInAvailableAsync;
            // Go back to the UI thread and attach the add-in element to the tree.
            Dispatcher.BeginInvoke(new SendOrPostCallback((addinHost) =>
            {
                var host = (XProcAddInHost)addinHost;
                if(host!=null)
                {
                    AddinPanel.Child = host;
                }
            }), sender);
        }


        /// <summary>
        /// Unloads the add in.
        /// </summary>
        public void UnloadAddIn()
        {
            var pluginHost = (XProcAddInHost)AddinPanel.Child;
            if (pluginHost == null) return;
            AddinPanel.Child = null;
            pluginHost.Dispose();
        }




        /// <summary>
        /// Initializes a new instance of the <see cref="AppHostView" /> class.
        /// </summary>
        public AppHostView()
        {
            InitializeComponent();
            AddinPanel.DataContextChanged += (s, e) =>
            {

                if (e.NewValue is MenuButton)
                {
                    AppInfo = e.NewValue as MenuButton;
                }
            };
        }


        /// <summary>
        /// Invoked when an unhandled <see cref="E:System.Windows.Input.Keyboard.KeyDown" /> attached event reaches an element in its route that is derived from this class. Implement this method to add class handling for this event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.Windows.Input.KeyEventArgs" /> that contains the event data.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Handled || e.Key != Key.F5 ||
                e.KeyboardDevice.Modifiers != (ModifierKeys.Control | ModifierKeys.Shift)) return;
            e.Handled = true;
            // Do the unloading asynchronously to avoid a deadlock if the key press was bubbled from 
            // the add-in. Too much re-entrancy going on!
            Dispatcher.BeginInvoke(new Action(delegate
            {
                UnloadAddIn();
                LoadAddIn();
            }));
        }


        /// <summary>
        /// Sends the message to addin.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="subject">The subject.</param>
        public void SendMessageToAddin(string message, string subject)
        {
            
        }

        /// <summary>
        /// The _logger
        /// </summary>
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// The _app information
        /// </summary>
        private MenuButton _appInfo;

        /// <summary>
        /// Navigateds to.
        /// </summary>
        /// <param name="e">The <see cref="NavigationEventArgs"/> instance containing the event data.</param>
        public void NavigatedTo(NavigationEventArgs e)
        {
            _logger.Info("Navigated To AppHostView");
        }

        /// <summary>
        /// Navigatings from.
        /// </summary>
        /// <param name="e">The <see cref="NavigatingEventArgs"/> instance containing the event data.</param>
        public void NavigatingFrom(NavigatingEventArgs e)
        {
            _logger.Info("Navigating From AppHostView");
        }

        /// <summary>
        /// Called automatically after an application has successfully navigated from a View that implements the INavigationAware interface.
        /// </summary>
        /// <param name="e">A NavigationEventArgs object that contains event data.</param>
        public void NavigatedFrom(NavigationEventArgs e)
        {
            _logger.Info("Navigated From AppHostView");
        }
    };

}
