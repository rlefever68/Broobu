// ***********************************************************************
// Assembly         : Broobu.Fx.UI
// Author           : Rafael Lefever
// Created          : 07-20-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-16-2014
// ***********************************************************************
// <copyright file="AppletApplication.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Deployment.Application;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using Broobu.Fx.UI.Addin.Interfaces;
using Broobu.Fx.UI.Addin.Utils;
using Broobu.Fx.UI.Deamons;
using DevExpress.Xpf.Core;
using NLog;
using Wulka.Agent;
using Wulka.Domain;
using Wulka.Domain.Interfaces;
using Wulka.Exceptions;
using Wulka.Utils;

namespace Broobu.Fx.UI
{
    /// <summary>
    ///     Class AppletApplication.
    /// </summary>
    public class AppletApplication : Application
    {
        /// <summary>
        ///     The _logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     The _id
        /// </summary>
        public static string ID = GuidUtils.NewCleanGuid;

        /// <summary>
        ///     The addin
        /// </summary>
        [Import(typeof (IXProcAddIn))] public IXProcAddIn Addin;


        /// <summary>
        ///     Gets the arguments.
        /// </summary>
        /// <value>The arguments.</value>
        protected Dictionary<string, string> Arguments;

        /// <summary>
        ///     Gets the launcher.
        /// </summary>
        /// <value>The launcher.</value>
        public string Launcher
        {
            get { return FindArgument("launcher"); }
        }

        /// <summary>
        ///     Gets the ipc.
        /// </summary>
        /// <value>The ipc.</value>
        public string Ipc
        {
            get { return FindArgument("ipc").Base64Decode(); }
        }


        /// <summary>
        ///     Gets the query string.
        /// </summary>
        /// <value>The query string.</value>
        private static string QueryString
        {
            get { return GetQueryString(); }
        }

        /// <summary>
        ///     Gets the application contract.
        /// </summary>
        /// <value>The application contract.</value>
        public IAppContract AppContract
        {
            get { return GetAppContract(); }
        }

        /// <summary>
        ///     Gets the type of the source.
        /// </summary>
        /// <value>The type of the source.</value>
        public Type SourceType
        {
            get { return GetAddInSourceType(); }
        }

        /// <summary>
        ///     Gets the name of the applet.
        /// </summary>
        /// <value>The name of the applet.</value>
        public static string AppletName
        {
            get
            {
                return Process
                    .GetCurrentProcess()
                    .ProcessName
                    .ToLower()
                    .Replace(".exe", "");
            }
        }

        /// <summary>
        ///     Gets the arguments.
        /// </summary>
        /// <returns>Dictionary&lt;System.String, System.String&gt;.</returns>
        private static Dictionary<string, string> GetArguments()
        {
            var nameValueTable = new Dictionary<string, string>();
            if (!ApplicationDeployment.IsNetworkDeployed) return (nameValueTable);
            if (ApplicationDeployment.CurrentDeployment.ActivationUri == null) return (nameValueTable);
            string queryString = ApplicationDeployment.CurrentDeployment.ActivationUri.Query;
            Logger.Info("QueryString = {0}", queryString);
            string[] qs = queryString.Split('?');
            foreach (var kv in qs.Select(s => s.Split('@')).Where(kv => kv.Length == 2))
            {
                Logger.Info("Adding '{0} = {1}' to Arguments table", kv[0], kv[1]);
                nameValueTable.Add(kv[0], kv[1]);
            }
            return (nameValueTable);
        }

        /// <summary>
        ///     Gets the arguments.
        /// </summary>
        /// <returns>Dictionary&lt;System.String, System.String&gt;.</returns>
        private static string GetQueryString()
        {
            if (!ApplicationDeployment.IsNetworkDeployed)
            {
                Logger.Warn("Applet is not Network Deployed.");
                return (String.Empty);
            }
            if (ApplicationDeployment.CurrentDeployment.ActivationUri == null)
            {
                Logger.Warn("Applet has no ActivationUri");
                return (String.Empty);
            }
            string q = ApplicationDeployment.CurrentDeployment.ActivationUri.Query;
            string[] qs = q.Split('?');
            var res = qs[1].Base64Decode();
            return res;
        }


        /// <summary>
        ///     Raises the <see cref="E:System.Windows.Application.Startup" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.StartupEventArgs" /> that contains the event data.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            Arguments = GetArguments();
            ShutdownMode = ShutdownMode.OnMainWindowClose;
            Logger.Info("**********\n\n\nLauncher [{0}] is starting applet [{1}]", Launcher, AppletName);
            ApplicationHelper.EnableExceptionHandling();
//            RegisterCloudApplet();

            ComSink.Instance.StartAppletDeamon(AppletName, ID);
            ComSink.Instance.RegisterApplet(Launcher, AppletName, ID);

            if (Current.StartupUri == null)
            {
                ShutdownMode = ShutdownMode.OnExplicitShutdown;
                var site = (IXProcAddInSite) Activator.GetObject(typeof (IXProcAddInSite), Ipc);
                // Register a server channel so that the host can make calls to IXProcAddIn.
                // (Client channels are generally registere automatically.)
                Logger.Info("\tRegistering Channel to [{0}]'", Ipc);
                string procName = Process.GetCurrentProcess().ProcessName;
                Logger.Info("Registering Applet Process Server Channel '{0}'", procName);
                IpcUtils.RegisterServerChannel(procName);
                //IpcUtils.RegisterServerChannel(QueryString);
                // Set up a watchdog thread to catch abnormal quitting of the host process.
                // For normal exist, IXProcAddIn.ShutDown() is expected to be called.
                bool normalExit = false;
                new Thread(new ThreadStart(delegate
                {
                    Thread.CurrentThread.IsBackground = true;
                    Process.GetProcessById(site.HostProcessId).WaitForExit();
                    if (normalExit) return;
                    Logger.Warn("Host process quit unexpectedly.");
                    Environment.Exit(2);
                })).Start();
                CompositionHelper.ComposeParts(this, SourceType);
                if (Addin != null)
                {
                    Logger.Info("Created Addin [{0}] for site {1}", Addin.GetType().Name, site.HostProcessId);
                    Addin.Site = site;
                    Dispatcher.Run();
                    normalExit = true;
                }
                else
                {
                    Logger.Info("No Addin found in package, shutting down.");
                    if (Current.ShutdownMode == ShutdownMode.OnMainWindowClose)
                    {
                        if (Current.MainWindow == null)
                        {
                            Current.MainWindow.Close();
                        }
                        Current.Shutdown();
                    }
                    else
                    {
                        Current.Shutdown();
                    }
                }
            }
        }

        /// <summary>
        ///     Registers the cloud applet.
        /// </summary>
        private void RegisterCloudApplet()
        {
            DiscoPortal
                .AppContracts
                .RegisterAppUsageAsync(AppContract, null);
        }

        /// <summary>
        ///     Gets the application contract.
        /// </summary>
        /// <returns>IAppContract.</returns>
        protected virtual IAppContract GetAppContract()
        {
            return new DefaultAppContract(this);
        }

        /// <summary>
        ///     Gets the type of the add-in, for composition purposes source.
        /// </summary>
        /// <returns>Type.</returns>
        protected virtual Type GetAddInSourceType()
        {
            return GetType();
        }

        //protected void ComposeParts()
        //{
        //    if (ConfigurationHelper.LogComposition)
        //        Logger.Info("Composing Parts...");
        //    var catalog = new AggregateCatalog();
        //    var assembly = SourceType.Assembly;
        //    if (ConfigurationHelper.LogComposition)
        //        Logger.Info("Checking assembly [{0}]", assembly.FullName);
        //    catalog.Catalogs.Add(new AssemblyCatalog(assembly));
        //    _composer = new CompositionContainer(catalog);
        //    try
        //    {
        //        _composer.ComposeParts(this);
        //    }
        //    catch (CompositionException exception)
        //    {
        //        Logger.Error("---> Error Composing Parts <----");
        //        Logger.Error(exception.GetCombinedMessages());
        //    }
        //}


        /// <summary>
        ///     Sets the launcher.
        /// </summary>
        /// <param name="launcher">The launcher.</param>
        private void SetLauncher(string launcher)
        {
        }

        /// <summary>
        ///     Sets the theme.
        /// </summary>
        /// <param name="theme">The theme.</param>
        private void SetTheme(string theme)
        {
            if (String.IsNullOrWhiteSpace(theme)) return;
            Logger.Info(String.Format("Setting Theme to {0}", theme));
            ThemeManager.ApplicationThemeName = theme;
        }

        /// <summary>
        ///     Finds the argument.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.String.</returns>
        private string FindArgument(string key)
        {
            try
            {
                return Arguments[key];
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }


        /// <summary>
        ///     Raises the <see cref="E:System.Windows.Application.Exit" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.Windows.ExitEventArgs" /> that contains the event data.</param>
        protected override void OnExit(ExitEventArgs e)
        {
            try
            {
                Logger.Info("The applet is going to exit with code ({0}) ", e.ApplicationExitCode);
                ComSink.Instance.UnregisterApplet(Launcher, AppletName, ID);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.GetCombinedMessages());
            }
            finally
            {
                AppletDeamon.CloseDeamon();
            }
            base.OnExit(e);
        }


        //[STAThread]
        //public static int Main(string[] args)
        //{
        //    Logger.Info("Entering Main Thread");
        //    var app = new AppletApplication();
        //    app.Run();
        //    return 0;
        //}
    }

    /// <summary>
    ///     Class DefaultAppContract.
    /// </summary>
    public class DefaultAppContract : AppContract
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DefaultAppContract" /> class.
        /// </summary>
        /// <param name="applet">The applet.</param>
        public DefaultAppContract(AppletApplication applet)
        {
        }

        /// <summary>
        ///     Gets the type of the taxo factory.
        /// </summary>
        /// <returns>Type.</returns>
        protected override Type GetTaxoFactoryType()
        {
            return GetType();
        }
    }
}