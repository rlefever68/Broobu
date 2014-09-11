using System;
using System.Collections.Generic;
using System.ComponentModel;
using Pms.MobiLauncher.UI.Controls.Interfaces;
using Pms.Framework.UI;
using Pms.Shell.Contract.Domain;
using Pms.Shell.Contract.Agent;
using Pms.Shell.Contract.Interfaces;
using System.Linq;
using Pms.Framework.Domain;

namespace Pms.MobiLauncher.UI.Controls
{
    /// <summary>
    /// Exposes Properties and Commands for logging in a user and application
    /// </summary>
    public class LoginViewModel : ViewModelBase, ILoginViewModel
    {

        ///<summary>
        /// Exposes a list of properties for the current ViewModel
        ///</summary>
        public class Properties
        {
            public const string ErrorStatus = "ErrorStatus";
            public const string LoginProgressStatus = "LoginProgressStatus";
            public const string Username = "Username";
            public const string Password = "Password";
            public const string Application = "Application";
            public const string ApplicationPassword = "ApplicationPassword";
            public const string AuthenticationModes = "AuthenticationModes";
        }


        private IShellAgent _shellAgent;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginViewModel"/> class.
        /// </summary>
        public LoginViewModel()
        {
            _shellAgent = ShellAgentFactory.CreateAgent(ShellAgentFactory.Key.Instance);
            _shellAgent.GetAuthenticationModesCompleted += (p) => { AuthenticationModes = p.ToList(); };
            _shellAgent.LoginUserCompleted += (s) => { PMSSession.Current = s; };
        }

    
        private static void LoginUser(object sender, DoWorkEventArgs e)
        {
            //var agt = AuthenticationAgentFactory
            //    .CreateAgent(AuthenticationAgentFactory.Key.Instance)
            //    .LoginUser(PMSContext.Current[PMSContextKey.UserName],
            //    PMSContext.Current[PMSContextKey.PasswordEnc]);
        }
        

        private string _username = string.Empty;

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username
        {
            get { return _username; }
            set { _username = value; RaisePropertyChanged(Properties.Username); }
        }

        private string _password = string.Empty;

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password
        {
            get { return _password; }
            set { _password = value; RaisePropertyChanged(Properties.Password); }
        }

        private string _application = string.Empty;

        /// <summary>
        /// Gets or sets the application.
        /// </summary>
        /// <value>The application.</value>
        public string ApplicationCode
        {
            get { return _application; }
            set { _application = value; RaisePropertyChanged(Properties.Application); }
        }

        private string _applicationPassword = string.Empty;

        /// <summary>
        /// Gets or sets the application password.
        /// </summary>
        /// <value>The application password.</value>
        public string ApplicationPassword
        {
            get { return _applicationPassword; }
            set { _applicationPassword = value; RaisePropertyChanged(Properties.ApplicationPassword); }
        }


        /// <summary>
        /// Gets or sets the login command.
        /// </summary>
        /// <value>The login command.</value>
        public DelegateCommand LoginCommand { get; set; }

        /// <summary>
        /// Gets or sets the close command.
        /// </summary>
        /// <value>The close command.</value>
        public DelegateCommand CloseCommand { get; set; }


        private IEnumerable<AuthenticationModeViewItem> _authenticationModes;
        public IEnumerable<AuthenticationModeViewItem> AuthenticationModes
        {
            get
            {
                return _authenticationModes;
            }
            set 
            {
                _authenticationModes = value;
                RaisePropertyChanged(Properties.AuthenticationModes);
            }
        }


        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        protected override void InitializeInternal(object[] parameters)
        {
            _shellAgent.GetAuthenticationModesAsync();
        }

    
    }
}