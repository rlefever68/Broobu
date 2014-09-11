// ***********************************************************************
// Assembly         : Broobu.Boutique.Hub.UI.Controls
// Author           : Rafael Lefever
// Created          : 07-29-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-01-2014
// ***********************************************************************
// <copyright file="HubViewModel.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Windows;
using System.Windows.Media;
using Broobu.Authentication.UI.Controls;
using Broobu.Authentication.UI.Controls.Mvvm;
using Broobu.Boutique.Contract;
using Broobu.Boutique.Contract.Domain;
using Broobu.Boutique.Hub.UI.Controls.Views;
using Broobu.EcoSpace.Contract.Domain.Account;
using Broobu.Fx.UI.Deamons;
using Broobu.Fx.UI.Domain;
using Broobu.Fx.UI.MVVM;
using Broobu.Fx.UI.Views;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.UI;
using DevExpress.Xpf.WindowsUI.Navigation;
using Wulka.Domain;
using Wulka.Domain.Authentication;
using Wulka.Exceptions;
using Wulka.Utils;
using NLog;

namespace Broobu.Boutique.Hub.UI.Controls.Mvvm
{
    /// <summary>
    /// Class HubViewModel.
    /// </summary>
    public class HubViewModel : FxViewModelBase
    {


        public INavigationService Navigator
        {
            get { return _navigatorService ?? (_navigatorService = ServiceContainer.GetService<INavigationService>()); }
            set 
            { 
                _navigatorService = value; 
            }
        }

        /// <summary>
        /// The _logger
        /// </summary>
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// The _feedback text
        /// </summary>
        private string _feedbackText;
        /// <summary>
        /// The _log button image
        /// </summary>
        private ImageSource _logButtonImage;

        /// <summary>
        /// The session
        /// </summary>
        public static readonly WulkaSession Session = new WulkaSession();
        /// <summary>
        /// The _log button text
        /// </summary>
        private string _logButtonText;


        /// <summary>
        /// The _info
        /// </summary>
        private UserEnvironmentInfo _info;
        /// <summary>
        /// The _current exception
        /// </summary>
        private Exception _currentException;

        public IViewLocator HubViewLocator
        {
            get { return _hubViewLocator ?? (_hubViewLocator = new HubViewLocator()); }
        }


        public bool IsLogVisible
        {
            get { return _isLogVisible; }
            set { _isLogVisible = value; RaisePropertyChanged("IsLogVisible"); }
        }

        public bool IsMyAppsVisible
        {
            get { return _isMyAppsVisible; }
            set { _isMyAppsVisible = value; RaisePropertyChanged("IsMyAppsVisible"); }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="HubViewModel" /> class.
        /// </summary>
        public HubViewModel()
        {
            Messenger.Default.Register<GoBackMvvmMessage>(this, m => { 
                Navigator.GoBack();
            });
            Messenger.Default.Register<NavigateMvvmMessage>(this, m => { 
                NavigateTo = m; 
            });
            Messenger.Default.Register<AuthenticationResultMessage>(this, (s) =>
            {
                WulkaSession.Current = s.Session;
                GetUserEnvironmentInfo();
            });
            Messenger.Default.Register<MenuMvvmMessage>(this, (m) =>
            {
                if (m.Menu != null) return;
                if (Info == null) return;
                var msg = new MenuMvvmMessage {Menu = Info.Menu};
                Messenger.Default.Send(msg);
            });
            Messenger.Default.Register<AppletMvvmMessage>(this, m =>
            {
                if (m.Action == AppletActionEnum.Loaded)
                    Messenger.Default.Send(new NavigateMvvmMessage() 
                    {
                        Header = "Your Menu",
                        ViewName = MenuView.ID
                    });
            });
            Messenger.Default.Register<FeedbackMvvmMessage>(this, (f) => 
            {
                FeedbackText = f.Feedback;
            });
            Messenger.Default.Register<SignonGuestMvvmMessage>( this, (m) => {
                LogonGuest();
            });
            Messenger.Default.Register<ExceptionMvvmMsg>(this, m => {
                CurrentException = m.Exception;
            });
        }

        /// <summary>
        /// Gets or sets the current exception.
        /// </summary>
        /// <value>The current exception.</value>
        public Exception CurrentException
        {
            get 
            { 
                return _currentException; 
            }
            set 
            {
                _currentException = value;
                try
                {
                    NavigateTo = new NavigateMvvmMessage() 
                    {
                        Header = "Something unexpected happened.",
                        ViewName = ExceptionView.ID, 
                        Parameter = _currentException
                    };
                }
                catch (Exception exception)
                {
                    _logger.Error(exception.GetCombinedMessages());
                }
            }
        }

        /// <summary>
        /// Updates the login button.
        /// </summary>
        private void UpdateLoginButton()
        {
            if (!WulkaSession.Current.IsDefaultSession)
            {
                LogButtonImage = Controls.Properties.Resources.logout.ToImageSource();
                LogButtonText = "Logout";
            }
            else
            {
                LogButtonImage = Controls.Properties.Resources.login.ToImageSource();
                LogButtonText = "Login";
            }
        }


        /// <summary>
        /// Initializes the ViewModel the first time it is called.
        /// This method will be called from the View that implements the
        /// ViewModel
        /// </summary>
        /// <param name="parameters">The parameters used to initialize the ViewModel</param>
        protected override void InitializeInternal(object[] parameters)
        {
            DevExpress.Xpf.Core.DXSplashScreen.Close();
            AuthenticationHost.WaitInfo = new GetMenuWaitInfo();
            AuthenticationHost.StartSessionAsync(GetUserEnvironmentInfo);
            FeedbackText = "Welcome, Please sign in or register to continue.";
        }

        /// <summary>
        /// Mis the logon click.
        /// </summary>
        /// <exception cref="System.Exception">Hahaha Ho Ho Ho</exception>
        [Command(Name="LogonLogoff", UseCommandManager = true)]
        public void LogonLogoff()
        {
            if (WulkaSession.Current.IsDefaultSession)
            {
                AuthenticationHost.StartSessionAsync(GetUserEnvironmentInfo);
            }
            else
            {
                AuthenticationHost.TerminateSessionAsync(OnTerminateSessionCompleted);
            }
        }


       


        /// <summary>
        /// Exits this instance.
        /// </summary>
        [Command(Name="Exit", UseCommandManager = true)]
        public void Exit()
        {
            AuthenticationHost.WaitInfo = new ShuttingDownWaitInfo();
            AuthenticationHost.TerminateSessionAsync(ShutdownDesktop);
        }

        /// <summary>
        /// Shutdowns the desktop.
        /// </summary>
        static void ShutdownDesktop()
        {
            ComSink.Instance.KillRunningApplets();
            if(Application.Current.MainWindow!=null)
            {
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                Application.Current.MainWindow.Close();
            }
            else
                Application.Current.Shutdown();
        }

        /// <summary>
        /// Called when [terminate session completed].
        /// </summary>
        private void OnTerminateSessionCompleted()
        {
            ComSink.Instance.KillRunningApplets();
            LogonGuest();
        }


        private NavigateMvvmMessage _navigateTo;
        private INavigationService _navigatorService;
        private HubViewLocator _hubViewLocator;
        private bool _isLogVisible;
        private bool _isMyAppsVisible;

        public NavigateMvvmMessage NavigateTo
        {
            get { return _navigateTo; }
            set
            {
                _navigateTo = value;
                RaisePropertyChanged("NavigateTo");
                if (Navigator == null) return;
                try
                {
                    var n = (Navigator as FrameNavigationService);
                    if (n != null && n.ViewLocator == null)
                        n.ViewLocator = ViewLocator.Default;
                    Navigator.Navigate(_navigateTo.ViewName, _navigateTo.Parameter, this);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.GetCombinedMessages());
                }
            }
        }

        /// <summary>
        /// Logons the guest.
        /// </summary>
        private void LogonGuest()
        {
            WulkaSession.Current = SessionFactory.CreateDefaultWulkaSession();
            WulkaCredentials.Current = WulkaSession.Current.Credentials;
            AuthenticationHost.TerminateSessionAsync(GetUserEnvironmentInfo);
        }

        /// <summary>
        /// Activities after login has completed
        /// </summary>
        void GetUserEnvironmentInfo()
        {
            var s = WulkaSession.Current;
            WulkaCredentials.Current = s.Credentials;
            _logger.Info(String.Format("Getting UserInfo for user {0} from Boutique Service", s.Username));
            BoutiquePortal
                .Boutique
                .GetUserEnvironmentInfoAsync(ConfigureForUser);
        }


        /// <summary>
        /// Gets or sets the log button image.
        /// </summary>
        /// <value>The log button image.</value>
        public ImageSource LogButtonImage
        {
            get { return _logButtonImage; }
            set { _logButtonImage = value;
            RaisePropertyChanged("LogButtonImage");}
        }


        /// <summary>
        /// Gets or sets the log button text.
        /// </summary>
        /// <value>The log button text.</value>
        public string LogButtonText
        {
            get { return _logButtonText; }
            set
            {
                _logButtonText = value;
                RaisePropertyChanged("LogButtonText");
            }
        }


        /// <summary>
        /// Configures for user.
        /// </summary>
        /// <param name="info">The info.</param>
        public void ConfigureForUser(UserEnvironmentInfo info)
        {
            if (info != null)
            {
                IsMyAppsVisible = true;
                IsLogVisible = true;
                Info = info;
                _logger.Info("**************************************************************************");
                _logger.Info(" Start Configuration Sequence for user {0}", WulkaSession.Current.Username);
                _logger.Info("**************************************************************************");
                _logger.Info("Current Credentials User Name:\t{0}", WulkaCredentials.Current.UserName);
                _logger.Info("Current Wulka Session:\tUser: {0}\tSession:{1}", WulkaSession.Current.Username,
                    WulkaSession.Current.Id);
                _logger.Info("Received Boutique Info:\tGreeting: {0}\n", info.Greeting);
                FeedbackText = info.Greeting;
                IsEnabled = true;
                UpdateLoginButton();
                GotoMyApps();
            }
            else
            {
                IsMyAppsVisible = false;
                IsLogVisible = true;
            }
        }

        [Command(Name="GotoMyApps", UseCommandManager = true)]
        public void GotoMyApps()
        {
            NavigateTo = new NavigateMvvmMessage
            {
                ViewName = MenuView.ID,
                Header = "My Apps"
            };
        }


        /// <summary>
        /// Gets or sets the information.
        /// </summary>
        /// <value>The information.</value>
        public UserEnvironmentInfo Info
        {
            get { return _info; }
            set { _info = value; RaisePropertyChanged("Info"); }
        }


        /// <summary>
        /// Gets or sets the feedback text.
        /// </summary>
        /// <value>The feedback text.</value>
        public string FeedbackText
        {
            get { return _feedbackText; }
            set 
            { 
                _feedbackText = value;
                RaisePropertyChanged("FeedbackText");
            }
        }


        /// <summary>
        /// Called when [view loaded].
        /// </summary>
        [Command(Name="OnViewLoaded", UseCommandManager = true)]
        public void OnViewLoaded()
        {
            //NavigateTo = new NavigateMvvmMessage() {ViewName = LoginView.ID};
        }



        /// <summary>
        /// Gets or sets a value indicating whether this instance is enabled.
        /// </summary>
        /// <value><c>true</c> if this instance is enabled; otherwise, <c>false</c>.</value>
        public bool IsEnabled { get; set; }
    }
}
