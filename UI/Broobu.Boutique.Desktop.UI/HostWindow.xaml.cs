// ***********************************************************************
// Assembly         : Iris.Desktop.UI
// Author           : ON8RL
// Created          : 12-04-2013
//
// Last Modified By : ON8RL
// Last Modified On : 07-24-2014
// ***********************************************************************
// <copyright file="HostWindow.xaml.cs" company="Broobu">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Broobu.Authentication.UI.Controls;
using Broobu.Boutique.Contract;
using Broobu.Boutique.Contract.Domain;
using Broobu.Boutique.UI.Controls.Interfaces;
using Broobu.Desktop.UI.Controls.Dialogs;
using Broobu.Fx.UI;
using Broobu.Fx.UI.Deamons;
using DevExpress.Utils;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Ribbon;
using DevExpress.Xpf.Ribbon.Customization;
using Iris.Fx.Authentication;
using Iris.Fx.Domain;
using Iris.Fx.Logging;
using NLog;


namespace Broobu.Desktop.UI
{
    /// <summary>
    /// Interaction logic for HostWindow.xaml
    /// </summary>
    public partial class HostWindow : IHostForm
    {
        /// <summary>
        /// The _SPLSH
        /// </summary>
        private readonly SplashWindow _splash = new SplashWindow();
        /// <summary>
        /// The _host
        /// </summary>
        private readonly LauncherHost _host;

        /// <summary>
        /// The _logger
        /// </summary>
        private readonly Logger _logger = LogManager.GetLogger("HostWindow");


        /// <summary>
        /// Initializes a new instance of the <see cref="HostWindow" /> class.
        /// </summary>
        public HostWindow()
        {
            ApplicationHelper.EnableExceptionHandling((nfo) =>  
            {
                IsEnabled = true;
                _splash.Close();
            });
            _splash.Show();
            if (LauncherConfigurationHelper.RunOnlyOneInstance)
            {
                string runningProcess = Process.GetCurrentProcess().ProcessName;
                var processes = Process.GetProcessesByName(runningProcess);
                if (processes.Length > 1)
                {
                    MessageBox.Show("Broobu Desktop is already running", "Stop", MessageBoxButton.OK, MessageBoxImage.Error);
                    Application.Current.Shutdown();
                }
            }
            IsEnabled = false;
            InitializeComponent();
            SizeToContent = SizeToContent.Height;
            Width = SystemParameters.PrimaryScreenWidth;
            Closing += (s, e) =>  AuthenticationHost.TerminateSessionAsync(ShutdownDesktop);
            AppBar.HostWindow = this;
            App.DoEvents();
            
            _host = new LauncherHost(this) {LauncherId = HostApplication.LauncherId};
            
            Loaded += (s, e) =>
            {
                ApplyTheme(LauncherConfigurationHelper.DefaultTheme);
                SizeToContent = SizeToContent.Height;
                var measuredHeight = Height;
                SizeToContent = SizeToContent.Manual;
                Height = measuredHeight;

                AppDomain.CurrentDomain.AssemblyLoad += (s1, e1) => SetSplashFeedback(String.Format("Loading : {0}",
                                                                                                  e1.LoadedAssembly.
                                                                                                 FullName));
                _host.PreloadAssemblies();
                Thread.Sleep(5000);                
                _splash.Close();
                IrisSession.Current = SessionFactory.CreateDefaultIrisSession();
                App.DoEvents();
                StartSessionAsync(GetBoutiqueUserInfo);
            };
            
        }

        /// <summary>
        /// Sets the splash feedback.
        /// </summary>
        /// <param name="feedback">The feedback.</param>
        private void SetSplashFeedback(string feedback)
        {
            if(_splash!=null)
                _splash.SetFeedback(feedback);
        }


        /// <summary>
        /// Activities after login has completed
        /// </summary>
        void GetBoutiqueUserInfo()
        {
            var s = IrisSession.Current;
            _logger.Info(String.Format("Getting UserInfo for user {0} from Boutique Service",s.Username));
            BoutiquePortal
                .Boutique
                .GetBoutiqueUserInfoAsync(ConfigureForUser);
        }


        /// <summary>
        /// Sets the feed back text.
        /// </summary>
        /// <param name="text">The text.</param>
        public void SetFeedBackText(string text)
        {
            BiMessage.Content = text;
        }


        /// <summary>
        /// Configures for user.
        /// </summary>
        /// <param name="info">The info.</param>
        public void ConfigureForUser(BoutiqueUserInfo info)
        {
            _logger.Info("**************************************************************************");
            _logger.Info(" Start Configuration Sequence for user {0}", IrisSession.Current.Username);
            _logger.Info("**************************************************************************");
            _logger.Info("Current Credentials User Name:\t{0}", IrisCredentials.Current.UserName);
            _logger.Info("Current Iris Session:\tUser: {0}\tSession:{1}", IrisSession.Current.Username, IrisSession.Current.Id);
            _logger.Info("Received Boutique Info:\tGreeting: {0}\n", info.Greeting);
            LogonLogoffLink.BarItemName = IrisSession.Current.IsDefaultSession ? "BiLogon" : "BiLogout";
            RibbonBuilder.Build(RibbonControl, info.Menu, _host.ExecuteApplet);
            ApplyTheme(ThemeManager.ApplicationThemeName);
            SetFeedBackText(info.Greeting);
            IsEnabled = true;
        }



        /// <summary>
        /// Shutdowns the desktop.
        /// </summary>
        static void ShutdownDesktop()
        {
            ComSink.Instance.KillRunningApplets();
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Mis the logon click.
        /// </summary>
        public void LogonLogoff()
        {
            if (IrisSession.Current.IsDefaultSession)
            {
                StartSessionAsync(GetBoutiqueUserInfo);
            }
            else
            {
                AuthenticationHost.TerminateSessionAsync(OnTerminateSessionCompleted);
            }
        }

        /// <summary>
        /// Called when [terminate session completed].
        /// </summary>
        void OnTerminateSessionCompleted()
        {
            ComSink.Instance.KillRunningApplets();
            IrisSession.Current = SessionFactory.CreateDefaultIrisSession();
            GetBoutiqueUserInfo();
        }

        /// <summary>
        /// Starts the session asynchronous.
        /// </summary>
        /// <param name="act">The act.</param>
        void StartSessionAsync(Action act)
        {
            AuthenticationHost.StartSessionAsync(loginCompletedAction: act);
        }


        /// <summary>
        /// Optionses the click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ActiproSoftware.Windows.Controls.Ribbon.Controls.ExecuteRoutedEventArgs" /> instance containing the event data.</param>
        private void OptionsClick(object sender, RoutedEventArgs e)
        {
           // BoutiqueOptionsDialog.Execute();
        }

        /// <summary>
        /// Mis the logon admin click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ExecuteRoutedEventArgs" /> instance containing the event data.</param>
        private void MiLogonAdminClick(object sender, RoutedEventArgs e)
        {
            IrisSession.Current.Username = AuthenticationDefaults.RootUserName;
            AuthenticationHost.StartNativeSessionAsync();
        }


        /// <summary>
        /// Handles the OnItemClick event of the BiLogout control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ItemClickEventArgs"/> instance containing the event data.</param>
        private void BiLogout_OnItemClick(object sender, ItemClickEventArgs e)
        {
            LogonLogoff();
        }

        /// <summary>
        /// Handles the <see cref="E:ThemeDropDownGalleryInit" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DropDownGalleryEventArgs"/> instance containing the event data.</param>
        private void OnThemeDropDownGalleryInit(object sender, DropDownGalleryEventArgs e)
        {
            Gallery gallery = e.DropDownGallery.Gallery;
            gallery.AllowHoverImages = false;
            gallery.IsItemCaptionVisible = true;
            gallery.ItemGlyphLocation = Dock.Top;
            gallery.IsGroupCaptionVisible = DefaultBoolean.True;
        }

        /// <summary>
        /// Handles the <see cref="E:ThemeItemClick" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="GalleryItemEventArgs"/> instance containing the event data.</param>
        private void OnThemeItemClick(object sender, GalleryItemEventArgs e)
        {
            var themeName = (string) e.Item.Tag;
            ApplyTheme(themeName);
        }

        /// <summary>
        /// Applies the theme.
        /// </summary>
        /// <param name="themeName">Name of the theme.</param>
        private void ApplyTheme(string themeName)
        {
            ThemeManager.SetThemeName(this, themeName);
            ThemeManager.ApplicationThemeName = themeName;
            SizeToContent = SizeToContent.Height;
            SizeToContent = SizeToContent.Manual;
            AppBar.AutoHide = true;
        }


        /// <summary>
        /// Bis the exit click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ItemClickEventArgs"/> instance containing the event data.</param>
        private void BiExitClick(object sender, ItemClickEventArgs e)
        {
            AuthenticationHost.TerminateSessionAsync(ShutdownDesktop);
        }
    }
}
