using System;
using System.Configuration;
using System.Management;
using Broobu.Fx.UI.MVVM;

namespace Broobu.Desktop.UI.Controls
{
    /// <summary>
    /// Class AboutViewModel.
    /// </summary>
    public class AboutViewModel : ViewModelBase{
        /// <summary>
        /// The _framework version
        /// </summary>
        private string _frameworkVersion;
        /// <summary>
        /// Gets or sets the framework version.
        /// </summary>
        /// <value>The framework version.</value>
        public string FrameworkVersion
        {
            get
            {
                return _frameworkVersion;
            }
            set
            {
                _frameworkVersion = value;
                RaisePropertyChanged("FrameworkVersion");
            }
        }

        /// <summary>
        /// The _launcher version
        /// </summary>
        private string _launcherVersion;
        /// <summary>
        /// Gets or sets the launcher version.
        /// </summary>
        /// <value>The launcher version.</value>
        public string LauncherVersion
        {
            get
            {
                return _launcherVersion;
            }
            set
            {
                _launcherVersion = value;
                RaisePropertyChanged("LauncherVersion");
            }
        }

        /// <summary>
        /// The _framework UI version
        /// </summary>
        private string _frameworkUiVersion;
        /// <summary>
        /// Gets or sets the framework UI version.
        /// </summary>
        /// <value>The framework UI version.</value>
        public string FrameworkUiVersion
        {
            get
            {
                return _frameworkUiVersion;
            }
            set
            {
                _frameworkUiVersion = value;
                RaisePropertyChanged("FrameworkUiVersion");
            }
        }

        /// <summary>
        /// The _server address
        /// </summary>
        private string _serverAddress;
        /// <summary>
        /// Gets or sets the server address.
        /// </summary>
        /// <value>The server address.</value>
        public string ServerAddress
        {
            get
            {
                return _serverAddress;
            }
            set
            {
                _serverAddress = value;
                RaisePropertyChanged("ServerAddress");
            }
        }

        /// <summary>
        /// The _operating system name
        /// </summary>
        private string _operatingSystemName;
        /// <summary>
        /// Gets or sets the name of the operating system.
        /// </summary>
        /// <value>The name of the operating system.</value>
        public string OperatingSystemName
        {
            get
            {
                return _operatingSystemName;
            }
            set
            {
                _operatingSystemName = value;
                RaisePropertyChanged("OperatingSystemName");
            }
        }

        /// <summary>
        /// Starts the authenticated session.
        /// </summary>
        protected override void StartAuthenticatedSession()
        {

        }

        /// <summary>
        /// Terminates the authenticated session.
        /// </summary>
        /// <param name="onSessionTerminated">The on session terminated.</param>
        public override void TerminateAuthenticatedSession(Action onSessionTerminated)
        {

        }

        /// <summary>
        /// Initializes the internal.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        protected override void InitializeInternal(object[] parameters)
        {
            System.Version framework = System.Reflection.Assembly.Load("Iris.Fx").GetName().Version;
            System.Version launcher = System.Reflection.Assembly.Load("Iris.Desktop.UI").GetName().Version;
            System.Version frameworkUi = System.Reflection.Assembly.Load("Iris.Fx.UI").GetName().Version;

            ServerAddress = GetServerAddress();
            OperatingSystemName = GetOsFriendlyName();
            FrameworkVersion = framework.ToString();
            LauncherVersion = launcher.ToString();
            FrameworkUiVersion = frameworkUi.ToString();
        }

        /// <summary>
        /// Gets the name of the os friendly.
        /// </summary>
        /// <returns>System.String.</returns>
        private string GetOsFriendlyName()
        {
            string result = string.Empty;
            var searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
            foreach (ManagementObject os in searcher.Get())
            {
                result = os["Caption"].ToString();
                break;
            }
            return result;
        }

        /// <summary>
        /// Gets the server address.
        /// </summary>
        /// <returns>System.String.</returns>
        private string GetServerAddress()
        {
            string discoEndpoint = ConfigurationManager.AppSettings["Disco.Endpoint"];
            //Cut of http:// part of url
            discoEndpoint = discoEndpoint.Substring(7);
            //Split on "/" character
            var pieces = discoEndpoint.Split(new [] {@"/"}, StringSplitOptions.RemoveEmptyEntries);
            if (pieces.Length > 0)
            {
                return pieces[0];
            }
            return "";
        }
    }
}
