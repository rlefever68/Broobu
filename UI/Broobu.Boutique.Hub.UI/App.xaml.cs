// ***********************************************************************
// Assembly         : Broobu.Boutique.Hub.UI
// Author           : Rafael Lefever
// Created          : 07-29-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-29-2014
// ***********************************************************************
// <copyright file="App.xaml.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using Broobu.Authentication.UI.Controls;
using Broobu.Boutique.Hub.UI.Controls;
using Broobu.Boutique.Hub.UI.Controls.DXSplashScreen;
using Broobu.Components.DevExpress;
using Broobu.Fx.UI;
using DevExpress.Xpf.Core;
using Wulka.Domain;
using Wulka.Domain.Authentication;

namespace Broobu.Boutique.Hub.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App 
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            
        }

        /// <summary>
        /// Handles the <see cref="E:Startup" /> event.
        /// </summary>
        /// <param name="e">The <see cref="StartupEventArgs"/> instance containing the event data.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            StartUp();
            base.OnStartup(e);
        }

        private void StartUp()
        {
            EnableExceptionHandling();
            ApplyTheme(LauncherConfigurationHelper.DefaultTheme);
            DXSplashScreen.Show<HubSplashWindow>();
            CheckSingleInstance();
            //AppDomain.CurrentDomain.AssemblyLoad += (s1, e1) => SetSplashFeedback(String.Format("Loading : {0}",
            //    e1.LoadedAssembly.
            //        FullName));
            PreloadAssemblies();
            Thread.Sleep(5000);
            WulkaSession.Current = SessionFactory.CreateDefaultWulkaSession();
            DoEvents();
        }

        private static void EnableExceptionHandling()
        {
            ApplicationHelper.EnableExceptionHandling((nfo) =>
            {
            });
        }

        /// <summary>
        /// Sets the splash feedback.
        /// </summary>
        /// <param name="feedback">The feedback.</param>
        private void SetSplashFeedback(string feedback)
        {

        }

        /// <summary>
        /// Applies the theme.
        /// </summary>
        /// <param name="themeName">Name of the theme.</param>
        private void ApplyTheme(string themeName)
        {
            ThemeManager.ApplicationThemeName = themeName;
        }

        /// <summary>
        /// Checks the single instance.
        /// </summary>
        private void CheckSingleInstance()
        {
            if (!LauncherConfigurationHelper.RunOnlyOneInstance) return;
            var runningProcess = Process.GetCurrentProcess().ProcessName;
            var processes = Process.GetProcessesByName(runningProcess);
            if (processes.Length <= 1) return;
            MessageBox.Show("Cloudeen is already running", "Stop", MessageBoxButton.OK, MessageBoxImage.Error);
            Current.Shutdown();
        }


        internal void PreloadAssemblies()
        {
            DevExpressLibraryPreloader.PreLoadCarousel();
            App.DoEvents();

            DevExpressLibraryPreloader.PreLoadChart();
            App.DoEvents();

            DevExpressLibraryPreloader.PreLoadFlowLayout();
            App.DoEvents();

            DevExpressLibraryPreloader.PreLoadGrid();
            App.DoEvents();

            DevExpressLibraryPreloader.PreLoadNavBar();
            App.DoEvents();

            DevExpressLibraryPreloader.PreLoadPivot();
            App.DoEvents();

            DevExpressLibraryPreloader.PreLoadPrinting();
            App.DoEvents();

            DevExpressLibraryPreloader.PreLoadRibbon();
            App.DoEvents();

            DevExpressLibraryPreloader.PreloadMap();
            App.DoEvents();

            AuthenticationHost.Register();


        }

            

    }
}
