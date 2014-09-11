using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using Broobu.Authentication.UI.Controls;
using Broobu.Boutique.Contract;
using Broobu.Boutique.Contract.Agent;
using Broobu.Boutique.Contract.Domain;
using Broobu.Boutique.UI.Controls.Interfaces;
using Broobu.Desktop.UI.Controls.Dialogs;
using Broobu.Fx.UI;
using Iris.Fx.Domain;
using NLog;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;

namespace Broobu.Desktop.UI
{
    /// <summary>
    /// Interaction logic for TrayWindow.xaml
    /// </summary>
    /// <remarks></remarks>
    public partial class TrayWindow : IHostForm
    {

        private string _launcherId;
        /// <summary>
        /// 
        /// </summary>
        private readonly SplashWindow _splsh = new SplashWindow();
        /// <summary>
        /// 
        /// </summary>
        private readonly LauncherHost _host;
        /// <summary>
        /// 
        /// </summary>
        NotifyIcon ni;
        /// <summary>
        /// 
        /// </summary>
        MenuItem miExit;
        /// <summary>
        /// 
        /// </summary>
        MenuItem miLogon;
        /// <summary>
        /// 
        /// </summary>
        MenuItem miAbout;
        /// <summary>
        /// 
        /// </summary>
        MenuItem miProfile;
        /// <summary>
        /// 
        /// </summary>
        MenuItem miApplications;
        /// <summary>
        /// 
        /// </summary>
        private readonly Logger _logger = LogManager.GetLogger("TrayWindow");


        /// <summary>
        /// Initializes a new instance of the <see cref="TrayWindow"/> class.
        /// </summary>
        /// <remarks></remarks>
        public TrayWindow()
        {
            if (LauncherConfigurationHelper.RunOnlyOneInstance)
            {
                string runningProcess = Process.GetCurrentProcess().ProcessName;
                Process[] processes = Process.GetProcessesByName(runningProcess);

                if (processes.Length > 1)
                {
                    MessageBox.Show("Application is already running", "Stop", MessageBoxButton.OK, MessageBoxImage.Error);
                    Application.Current.Shutdown();
                }
            }

            _launcherId = Guid.NewGuid().ToString();
            this.ToolTip = "Broobu Boutique";
            ShowInTaskbar = false;
            //WindowState = WindowState.Minimized;
            Width = 0;
            Height = 0;
            this.WindowStyle = WindowStyle.None;
            this.Left = -1;
            this.Top = -1;

            ApplicationHelper.EnableExceptionHandling((nfo) =>
            {
                IsEnabled = true;
                _splsh.Close();
            });
            _splsh.Show();
            IsEnabled = false;
            InitializeComponent();
            ni = CreateNotifyIcon();
            Closing += (s, e) => AuthenticationHost.TerminateSessionAsync(ShutdownDesktop);
            // Application.Current.Resources = MobiLauncherThemeHelper.ReadCommonThemes();
            App.DoEvents();
            _host = new LauncherHost(this);
            _host.LauncherId = HostApplication.LauncherId;
            Host.BroadcastReceived += new BroadcastReceivedEventHandler(BroadcastReceived);
            Host.RequestShellContextReceived += new RequestShellContextReceivedEventHandler(RequestShellContextReceived);
            Host.UnloadPluginReceived += new UnloadPluginReceivedEventHandler(UnloadPluginReceived);
            //PluginHost.Current = _host;
            Loaded += (s, e) =>
            {
                AppDomain.CurrentDomain.AssemblyLoad += (s1, e1) =>
                {
                    //SetFeedBackText("Iris Desktop is busy.", 
                    //    String.Format("Loading : {0}", e1.LoadedAssembly.FullName));

                };
                App.DoEvents();
                SetFeedBackText("Iris Desktop is busy.", "Please Wait...");
                _host.PreloadAssemblies();
                _splsh.Close();
                IrisSession.Current = SessionFactory.CreateDefaultIrisSession();
                StartSessionAsync(GetBoutiqueUserInfo, LoginCanceled);
            };
        }

        private void RequestShellContextReceived(object sender, EventArgs e)
        {
            _host.SendShellContext();
        }

        private void BroadcastReceived(object sender, ProcessVerbEventArgs e)
        {
            _host.Broadcast(e.VerbInfo);
        }

        private void UnloadPluginReceived(object sender, UnloadPluginEventArgs e)
        {
            _host.UnloadPlugin(e.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        private BoutiqueUserInfo BoutiqueUserInfo;
        /// <summary>
        /// Creates the notify icon.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        private NotifyIcon CreateNotifyIcon()
        {
            _logger.Info("Creating NotificationIcon");
            var ni = new NotifyIcon();
            using (var bmp = new Bitmap(typeof(TrayWindow), "appico.ico"))
            {
                ni.Icon = System.Drawing.Icon.FromHandle(bmp.GetHicon());
            }
            ni.Visible = true;
            ni.ContextMenu = new ContextMenu();

            miApplications = ni.ContextMenu.MenuItems.Add("Applications");
            miLogon = ni.ContextMenu.MenuItems.Add("Logon", miLogon_Click);
            miLogon.Enabled = false;
            miProfile = ni.ContextMenu.MenuItems.Add("Account", miProfile_Click);
            miProfile.Enabled = false;
            miAbout = ni.ContextMenu.MenuItems.Add("About", miAbout_Click);
            miExit = ni.ContextMenu.MenuItems.Add("Exit", miExit_Click);
            return ni;
        }

        /// <summary>
        /// Handles the Click event of the miExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        void miExit_Click(object sender, EventArgs e)
        {
            bool close = true;
            if (_host.HasRunningApplications)
            {
                close = false;
                MessageBoxResult result = MessageBox.Show(
                    "Broobu Boutique and all applications will be closed. All unsaved data will be lost. Are u sure?",
                    "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    close = true;
                }
            }
            if (close)
            {
                AuthenticationHost.TerminateSessionAsync(ShutdownDesktop);
            }

        }

        /// <summary>
        /// Handles the Click event of the miLogon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        void miLogon_Click(object sender, EventArgs e)
        {
            if (IrisSession.Current.IsDefaultSession)
                StartSessionAsync(GetBoutiqueUserInfo, LoginCanceled);
            else
                AuthenticationHost.TerminateSessionAsync(OnTerminateSessionCompleted);
        }

        /// <summary>
        /// Handles the Click event of the miProfile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        void miProfile_Click(object sender, EventArgs e)
        {
            RegisterNewUserDialog.Execute(IrisSession.Current);
        }

        /// <summary>
        /// Handles the Click event of the miAbout control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        void miAbout_Click(object sender, EventArgs e)
        {
            AboutDialog.Execute();
        }

        /// <summary>
        /// Called when [terminate session completed].
        /// </summary>
        /// <remarks></remarks>
        void OnTerminateSessionCompleted()
        {
            _host.KillRunningApplets();
            IrisSession.Current = SessionFactory.CreateDefaultIrisSession();
            GetBoutiqueUserInfo();
        }

        void LoginCanceled()
        {
            miLogon.Enabled = true;
        }

        /// <summary>
        /// Activities after login has completed
        /// </summary>
        /// <remarks></remarks>
        void GetBoutiqueUserInfo()
        {
            _logger.Info("Getting UserInfo from Boutique Service");
            BoutiquePortal
                .Boutique
                .GetBoutiqueUserInfoAsync(ConfigureForUser);
        }

        /// <summary>
        /// Starts the session async.
        /// </summary>
        /// <param name="act">The act.</param>
        /// <param name="cancelAction">The cancel action.</param>
        void StartSessionAsync(Action act, Action cancelAction = null)
        {
            AuthenticationHost.StartSessionAsync(act, cancelAction);
        }


        /// <summary>
        /// Shutdowns the desktop.
        /// </summary>
        /// <remarks></remarks>
        void ShutdownDesktop()
        {
            if (_host != null) _host.KillRunningApplets();
            ni.Visible = false;
            System.Windows.Application.Current.Shutdown();
        }


        /// <summary>
        /// Sets the feed back text.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="text">The text.</param>
        /// <remarks></remarks>
        public void SetFeedBackText(string title, string text)
        {
            ni.BalloonTipTitle = title;
            ni.BalloonTipText = text;
            ni.ShowBalloonTip(15000);
        }


        #region IHostForm Members

        /// <summary>
        /// Configures for user.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <remarks></remarks>
        public void ConfigureForUser(BoutiqueUserInfo info)
        {
            miLogon.Enabled = true;

            BoutiqueUserInfo = info;
            SetFeedBackText("Welcome to MobiGuider Desktop.", info.Greeting);
            MenuBuilder.Build(miApplications, BoutiqueUserInfo.Menu.Items, _host.ExecuteApplet);
            if (IrisSession.Current.IsDefaultSession)
                miLogon.Text = "Login";
            else
            {
                miProfile.Enabled = true;
                miLogon.Text = String.Format("Logoff {0} {1}", IrisSession.Current.FirstName, IrisSession.Current.LastName);
            }

            IsEnabled = true;
        }

        #endregion

    }
}
