// ***********************************************************************
// Assembly         : Broobu.Fx.UI
// Author           : Rafael Lefever
// Created          : 07-24-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-28-2014
// ***********************************************************************
// <copyright file="DeamonHelper.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Ipc;
using System.ServiceModel;
using System.Windows;
using Broobu.Fx.UI.Addin;
using Broobu.Fx.UI.Addin.Utils;
using Broobu.Fx.UI.Interfaces;
using Broobu.Fx.UI.Verbs;
using DevExpress.Mvvm;
using NLog;
using Wulka.Core;
using Wulka.Exceptions;
using Wulka.Utils;

namespace Broobu.Fx.UI.Deamons
{
    /// <summary>
    ///     Class DeamonHelper.
    /// </summary>
    public class ComSink
    {
        /// <summary>
        ///     The _logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();


        /// <summary>
        ///     The _running apps
        /// </summary>
        public static Dictionary<string, string> RunningApps = new Dictionary<string, string>();

        private static ComSink _instance;
        private static decimal _addinCounter;

        //public void RunApplet(string url, RunMode mode, string appletName)
        //{
        //    Dispatcher d = Dispatcher.CurrentDispatcher;
        //    AppletName = appletName;
        //    Executable = url;
        //    d.Invoke(DispatcherPriority.Normal, new AppletHost.NoArgsDelegate(StartExecutable));
        //}
        /// <summary>
        ///     Fetches the and run applet.
        /// </summary>
        /// <param name="url">The tag.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="appletName">Name of the applet.</param>
        /// <returns>System.String.</returns>
        /// <summary>
        ///     The ipc channel
        /// </summary>
        public static readonly IpcServerChannel Channel = IpcUtils.RegisterServerChannel("BroobuAddInHost");

        public static ComSink Instance
        {
            get { return _instance ?? (_instance = new ComSink()); }
        }


        /// <summary>
        ///     Gets a value indicating whether this instance has running applicatios.
        /// </summary>
        /// <value><c>true</c> if this instance has running applications; otherwise, <c>false</c>.</value>
        public bool HasRunningApplications
        {
            get { return RunningApps.Any(); }
        }


        /// <summary>
        ///     Gets the launcher address.
        /// </summary>
        /// <param name="launcherId">The launcher identifier.</param>
        /// <returns>System.String.</returns>
        public string LauncherAddress
        {
            get { return String.Format("net.pipe://localhost/launcher_{0}", LauncherId); }
        }

        /// <summary>
        ///     Gets the applet address.
        /// </summary>
        /// <param name="appletName">Name of the applet.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>System.String.</returns>
        public string AppletAddress
        {
            get { return String.Format("net.pipe://localhost/{0}_{1}", AppletName, AppletId); }
        }


        public static string LauncherId { get; set; }

        public static string AppletName { get; set; }

        public string AppletId { get; set; }
        public static string Executable { get; set; }

        public static string Ipc { get; set; }

        /// <summary>
        ///     Broadcasts the specified verb info to the active plugins.
        ///     Any Plugins that respond to the message will return their info in the result array.
        /// </summary>
        /// <param name="verbInfo">The verb info.</param>
        public void Broadcast(VerbInfo verbInfo)
        {
            BroadCast(verbInfo, RunningApps);
        }

        /// <summary>
        ///     Kills running applets
        /// </summary>
        public void KillRunningApplets()
        {
            if (!HasRunningApplications) return;
            foreach (var pair in RunningApps)
            {
                AppletName = pair.Key;
                AppletId = pair.Value;
                KillApplet(AppletAddress);
            }
        }


        /// <summary>
        ///     Starts the host deamon.
        /// </summary>
        /// <param name="launcherId">The launcher identifier.</param>
        /// <returns>ServiceHost.</returns>
        public void StartHostDeamon(string launcherId)
        {
            try
            {
                LauncherId = launcherId;
                Logger.Info("Starting Host Deamon [{0}]...", LauncherId);
                LauncherDeamon.OnRegisterApplet += (s, e1) =>
                {
                    Logger.Info("Applet [{0}-{1}] requesting registration...", e1.AppletName, e1.Id);
                    if (RunningApps.ContainsKey(e1.AppletName)) return;
                    RunningApps.Add(e1.AppletName, e1.Id);
                    Logger.Info("Applet [{0}-{1}] registered!", e1.AppletName, e1.Id);
                };
                LauncherDeamon.OnUnregisterApplet += (s, e1) =>
                {
                    Logger.Info("Applet [{0}-{1}] requesting removal...", e1.AppletName, e1.Id);
                    RunningApps.Remove(e1.AppletName);
                    Logger.Info("Applet [{0}-{1}] removed!", e1.AppletName, e1.Id);
                };
                LauncherDeamon.OnAppletLoaded +=
                    (s, e1) => Messenger.Default.Send(new AppletMvvmMessage
                    {
                        Id = e1.Id,
                        AppletName = e1.AppletName,
                        Action = AppletActionEnum.Loaded
                    });
                LauncherDeamon.Open(LauncherAddress);
                Logger.Info("Host Deamon [{0}] is listening!", launcherId);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.GetCombinedMessages);
            }
        }


        /// <summary>
        ///     Starts the applet deamon.
        /// </summary>
        /// <param name="appletName">Name of the applet.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>ServiceHost.</returns>
        public void StartAppletDeamon(string appletName, string id)
        {
            try
            {
                AppletName = appletName;
                AppletId = id;
                Logger.Info("Starting Applet Deamon [{0} - {1}]...", appletName, id);
                AppletDeamon.OnProcessVerb += (s, e) => Logger.Info("Received Verb {0}", e.VerbInfo);
                AppletDeamon.OnTerminate += (s, e) =>
                {
                    Logger.Info("Terminating Applet [{0} - {1}]...", appletName, id);
                    Application.Current.Shutdown();
                };
                AppletDeamon.Open(AppletAddress);
                Logger.Info("Applet Deamon [{0} - {1}] is listening!", appletName, id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.GetCombinedMessages);
            }
        }


        /// <summary>
        ///     Unregisters the applet.
        /// </summary>
        /// <param name="launcher">The launcher.</param>
        /// <param name="appletName">Name of the applet.</param>
        /// <param name="id">The identifier.</param>
        public void UnregisterApplet(string launcher, string appletName, string id)
        {
            try
            {
                LauncherId = launcher;
                AppletName = appletName;
                AppletId = id;
                Logger.Info("Unregistering applet [{0} - {1}] @ [{2}]...", appletName, id, launcher);
                var binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
                var pipeFactory = new ChannelFactory<IHost>(binding,
                    new EndpointAddress(LauncherAddress));
                IHost launcherHost = pipeFactory.CreateChannel();
                launcherHost.UnregisterApplet(appletName, id);
                Logger.Info("Unregistered applet [{0} - {1}] @ [{2}]!", appletName, id, launcher);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.GetCombinedMessages());
            }
        }

        /// <summary>
        ///     Sends the context to applet.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="appletEndpointAddress">The applet endpoint address.</param>
        public void SendContextToApplet(WulkaContext context, string appletEndpointAddress)
        {
            try
            {
                Logger.Info("Sending Shell Context @ {1}...", appletEndpointAddress);
                var binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
                var pipeFactory = new ChannelFactory<IPlugin>(binding,
                    new EndpointAddress(appletEndpointAddress));
                IPlugin pipeProxy = pipeFactory.CreateChannel();
                pipeProxy.SetContext(context);
                Logger.Info("Sent Shell Context @ {1}", appletEndpointAddress);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.GetCombinedMessages());
            }
        }

        /// <summary>
        ///     Kills the applet.
        /// </summary>
        /// <param name="appletEndpointAddress">The applet endpoint address.</param>
        public void KillApplet(string appletEndpointAddress)
        {
            try
            {
                Logger.Info("Killing Applet @ {0}...", appletEndpointAddress);
                var binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
                var pipeFactory = new ChannelFactory<IPlugin>(binding,
                    new EndpointAddress(appletEndpointAddress));
                IPlugin applet = pipeFactory.CreateChannel();
                applet.Terminate();
                Logger.Info("Applet @ {0} was killed!", appletEndpointAddress);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.GetCombinedMessages());
            }
        }

        /// <summary>
        ///     Broads the cast.
        /// </summary>
        /// <param name="verbInfo">The verb information.</param>
        /// <param name="runningApps">The running apps.</param>
        public void BroadCast(VerbInfo verbInfo, Dictionary<string, string> runningApps = null)
        {
            if (runningApps == null) runningApps = RunningApps;
            if (!HasRunningApplications) return;
            foreach (var pair in runningApps)
            {
                SendVerb(verbInfo, pair.Value);
            }
        }

        /// <summary>
        ///     Sends the verb.
        /// </summary>
        /// <param name="verbInfo">The verb information.</param>
        /// <param name="endpointAddress">The endpoint address.</param>
        private void SendVerb(VerbInfo verbInfo, string endpointAddress)
        {
            try
            {
                Logger.Info("Sending verb {0} @ {1}...", verbInfo.Verb, endpointAddress);
                var binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
                var pipeFactory = new ChannelFactory<IPlugin>(binding,
                    new EndpointAddress(endpointAddress));
                IPlugin plugin = pipeFactory.CreateChannel();
                plugin.ProcessVerb(verbInfo);
                Logger.Info("Verb {0} @ {1} was sent!", verbInfo.Verb, endpointAddress);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.GetCombinedMessages);
            }
        }

        /// <summary>
        ///     Registers the applet.
        /// </summary>
        /// <param name="launcher">The launcher.</param>
        /// <param name="appletName">Name of the applet.</param>
        /// <param name="id">The identifier.</param>
        public void RegisterApplet(string launcher, string appletName, string id)
        {
            try
            {
                LauncherId = launcher;
                AppletName = appletName;
                AppletId = id;

                Logger.Info("Registering Applet [{0} - {1}] @ {2}...", AppletName, AppletId, LauncherAddress);
                var binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
                var pipeFactory = new ChannelFactory<IHost>(binding,
                    new EndpointAddress(LauncherAddress));
                IHost launch = pipeFactory.CreateChannel();
                launch.RegisterApplet(AppletName, AppletId);
                Logger.Info("Applet [{0} - {1}] @ {2} was registered!", AppletName, AppletId, LauncherAddress);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.GetCombinedMessages);
            }
        }


        public void NotifyAppletLoaded()
        {
            try
            {
                //LauncherId = launcherId;
                //AppletId = appletId;
                //AppletName = appletName;

                Logger.Info("Notifying Applet [{0} - {1}] @ {2} <= Loaded...", AppletName, AppletId, LauncherAddress);
                var binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
                var pipeFactory = new ChannelFactory<IHost>(binding,
                    new EndpointAddress(LauncherAddress));
                IHost launch = pipeFactory.CreateChannel();
                launch.NotifyAppletLoaded(AppletName, AppletId);
                Logger.Info("Applet [{0} - {1}] @ {2} was loaded!", AppletName, AppletId, LauncherAddress);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.GetCombinedMessages);
            }
        }


        //public void ExecuteApplet(string url, RunMode mode)
        //{
        //    var ss = url.Split('/');
        //    var appletName = ss[ss.Length - 1].ToLower();
        //    RunApplet(url, mode, appletName);
        //}


        private static void RunApplet(string appletUri, XProcAddInHost host)
        {
            // Do all startup work asyncrhonously for better responsiveness.
            Action d = delegate
            {
                try
                {
                    var site = new XProcAddInSite(host);
                    // Register the site object with RemotingServices so that the add-in can connect to it.
                    string addinSiteUri = "site" + (++_addinCounter);
                    RemotingServices.Marshal(site, addinSiteUri);
                    addinSiteUri = Channel.GetChannelUri() + "/" + addinSiteUri;
                    Ipc = addinSiteUri.Base64Encode();
                    Executable = appletUri;
                    Channel.StartListening(null);
                    StartApplet(appletUri);
                }
                catch (Exception exception)
                {
                    Logger.Error(exception.GetCombinedMessages());
                }
            };
            d.BeginInvoke(null, null);
        }

        public static void StartApplet(string appletUri)
        {
            Logger.Info("Starting Applet [{0}]\nipc={1}\nlauncher={2}", appletUri, Ipc, LauncherId);
            Process.Start("rundll32.exe",
                String.Format("dfshim.dll,ShOpenVerbApplication {0}?ipc@{1}?launcher@{2}", Executable, Ipc, LauncherId));
        }


        public static void RunApplet(string appUrl, EventHandler onAddInAvailableAsync)
        {
            var host = new XProcAddInHost();
            host.AddInAvailableAsync += onAddInAvailableAsync;
            RunApplet(appUrl, host);
        }
    }
}