using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Windows.Threading;
using System.Diagnostics;
using System.Threading;
using Broobu.Fx.UI.Addin.Interfaces;
using Broobu.Fx.UI.Addin.Utils;
using Iris.Fx.Configuration;
using Iris.Fx.Utils;
using NLog;

namespace AddIn
{

class Program
{




    /// <summary>
    /// Gets the arguments.
    /// </summary>
    /// <value>The arguments.</value>
    protected static Dictionary<string, string> Arguments;

    static readonly Logger Logger = LogManager.GetCurrentClassLogger();


    private static string QueryString { get { return GetQueryString(); } }

    /// <summary>
    /// Gets the arguments.
    /// </summary>
    /// <returns>Dictionary&lt;System.String, System.String&gt;.</returns>
    private static string GetQueryString()
    {
        var nameValueTable = new Dictionary<string, string>();
        if (!ApplicationDeployment.IsNetworkDeployed) return (String.Empty);
        if (ApplicationDeployment.CurrentDeployment.ActivationUri == null) return (String.Empty);
        var q = ApplicationDeployment.CurrentDeployment.ActivationUri.Query;
        var qs = q.Split('?');
        var res = qs[1].Base64Decode();
        Logger.Info("QueryString After Decode = {0}", res);
        return res;
    }



    [STAThread]
    public static void Main(string[] args)
    {
        // args[0] is expected to be the URI of the running remotable object implementing IXProcAddInSite.
        if(String.IsNullOrWhiteSpace(QueryString)) return;
        var site = (IXProcAddInSite)Activator.GetObject(typeof(IXProcAddInSite), QueryString);
        // Register a server channel so that the host can make calls to IXProcAddIn.
        // (Client channels are generally registere automatically.)
        var s = Process.GetCurrentProcess().ProcessName;
        Logger.Info("Registering Applet Process Server Channel '{0}'", s);
        IpcUtils.RegisterServerChannel(s);
        // Set up a watchdog thread to catch abnormal quitting of the host process.
        // For normal exist, IXProcAddIn.ShutDown() is expected to be called.
        var normalExit = false;
        new Thread(new ThreadStart(delegate
        {
            Thread.CurrentThread.IsBackground = true;
            Process.GetProcessById(site.HostProcessId).WaitForExit();
            if (normalExit) return;
            Logger.Warn("Host process quit unexpectedly.");
            Environment.Exit(2);
        })).Start();
        var addin = new MyAddIn();
        addin.Site = site;
        Dispatcher.Run();
        normalExit = true;
    }
};

}