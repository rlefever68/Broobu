using System;
using System.ServiceModel;
using Broobu.Fx.UI.Interfaces;
using Broobu.Fx.UI.Verbs;

namespace Broobu.Fx.UI.Deamons
{
    /// <summary>
    ///     Class Host.
    /// </summary>
    public class LauncherDeamon : ServiceHost, IHost
    {
        /// <summary>
        ///     Delegate UnloadPluginReceivedEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="UnloadPluginEventArgs" /> instance containing the event data.</param>
        public delegate void AppletEvent(object sender, AppletEventArgs e);

        /// <summary>
        ///     Delegate BroadcastReceivedEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ProcessVerbEventArgs" /> instance containing the event data.</param>
        public delegate void BroadcastEvent(object sender, ProcessVerbEventArgs e);

        /// <summary>
        ///     Delegate RequestShellContextReceivedEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        public delegate void RequestShellContextEvent(object sender, EventArgs e);

        private static LauncherDeamon _launcherDeamon;


        public LauncherDeamon()
            : base(typeof (LauncherDeamon))
        {
        }


        /// <summary>
        ///     Broadcasts the specified verb information.
        /// </summary>
        /// <param name="verbInfo">The verb information.</param>
        public void Broadcast(VerbInfo verbInfo)
        {
            if (BroadcastReceived != null)
            {
                BroadcastReceived(this, new ProcessVerbEventArgs {VerbInfo = verbInfo});
            }
        }

        /// <summary>
        ///     Requests the shell context.
        /// </summary>
        public void RequestShellContext()
        {
            if (OnRequestShellContext != null)
            {
                OnRequestShellContext(this, new EventArgs());
            }
        }

        /// <summary>
        ///     Unloads the plugin.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="s"></param>
        public void UnregisterApplet(string appletName, string id)
        {
            if (OnUnregisterApplet != null)
            {
                OnUnregisterApplet(this, new AppletEventArgs {Id = id, AppletName = appletName});
            }
        }

        public void RegisterApplet(string appletName, string id)
        {
            if (OnRegisterApplet != null)
                OnRegisterApplet(this, new AppletEventArgs {Id = id, AppletName = appletName});
        }


        public void NotifyAppletLoaded(string appletName, string appletId)
        {
            if (OnAppletLoaded != null)
                OnAppletLoaded(this, new AppletEventArgs {Id = appletId, AppletName = appletName});
        }


        /// <summary>
        ///     Occurs when [broadcast received].
        /// </summary>
        public event BroadcastEvent BroadcastReceived;

        /// <summary>
        ///     Occurs when [request shell context received].
        /// </summary>
        public static event RequestShellContextEvent OnRequestShellContext;

        /// <summary>
        ///     Occurs when [unload plugin received].
        /// </summary>
        public static event AppletEvent OnUnregisterApplet;

        /// <summary>
        ///     Occurs when [register plugin received].
        /// </summary>
        public static event AppletEvent OnRegisterApplet;

        public static event AppletEvent OnAppletLoaded;

        internal static void Open(string hostAddress)
        {
            _launcherDeamon = new LauncherDeamon();
            var binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            _launcherDeamon.AddServiceEndpoint(typeof (IHost), binding, hostAddress);
            _launcherDeamon.Open();
        }

        public static void CloseDeamon()
        {
            _launcherDeamon.Close();
        }
    }
}