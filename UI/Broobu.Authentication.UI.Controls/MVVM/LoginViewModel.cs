// ***********************************************************************
// Assembly         : Broobu.Authentication.UI.Controls
// Author           : Rafael Lefever
// Created          : 07-29-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-31-2014
// ***********************************************************************
// <copyright file="LoginViewModel.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Threading;
using Broobu.Authentication.Contract;
using Broobu.Authentication.UI.Controls.Views;
using Broobu.Fx.UI.Domain;
using Broobu.Fx.UI.MVVM;
using Broobu.Fx.UI.ValidationRules;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using Wulka.Core;
using Wulka.Crypto;
using Wulka.Domain;
using Wulka.Domain.Authentication;

namespace Broobu.Authentication.UI.Controls.Mvvm
{
    /// <summary>
    /// Class LoginViewModel.
    /// </summary>
    class LoginViewModel : FxViewModelBase
    {
        /// <summary>
        /// The _request
        /// </summary>
        private AuthRequest _request = new AuthRequest();
        /// <summary>
        /// The _feedback
        /// </summary>
        private string _feedback;

        /// <summary>
        /// Initializes the ViewModel the first time it is called.
        /// This method will be called from the View that implements the
        /// ViewModel
        /// </summary>
        /// <param name="parameters">The parameters used to initialize the ViewModel</param>
        protected override void InitializeInternal(object[] parameters)
        {}

        /// <summary>
        /// Gets or sets the request.
        /// </summary>
        /// <value>The request.</value>
        public AuthRequest Request
        {
            get { return _request; }
            set { _request = value; }
        }


        /// <summary>
        /// Gets or sets the feedback.
        /// </summary>
        /// <value>The feedback.</value>
        public string Feedback
        {
            get { return _feedback; }
            set { _feedback = value;
            RaisePropertyChanged("Feedback");}
        }


        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }
        /// <summary>
        /// Logins this instance.
        /// </summary>
        [Command(Name = "Login", UseCommandManager = true, CanExecuteMethodName = "CanLogin")]
        public void Login()
        {
            Request.Password    = CryptoEngine.Encrypt(Password);
            Feedback = String.Format("Authenticating user '{0}'", Request.UserName);
            AuthenticationPortal
                .Authentication
                .AuthenticateByUserNameAndPasswordAsync(Request.UserName, Request.Password,
                    OnNativeAuthenticationCompleted);
        }

        /// <summary>
        /// Determines whether this instance can login.
        /// </summary>
        /// <returns><c>true</c> if this instance can login; otherwise, <c>false</c>.</returns>
        public bool CanLogin()
        {
            var canLogin = !String.IsNullOrWhiteSpace(Request.UserName);
            var rule = new PasswordRule();
            var res = rule.Validate(Password, null);
            if(!res.IsValid)
            {
                canLogin = false;
            }
            return canLogin;
        }


        /// <summary>
        /// Signons the guest.
        /// </summary>
        [Command(Name = "SignonGuest", UseCommandManager = true)]
        public void SignonGuest()
        {
            Messenger.Default.Send(new SignonGuestMvvmMessage());
        }


        /// <summary>
        /// Called when [native authentication completed].
        /// </summary>
        /// <param name="session">The session.</param>
        private void OnNativeAuthenticationCompleted(WulkaSession session)
        {
            if (session == null)
            {
                Feedback =String.Format("Authentication for user '{0}' failed!", Request.UserName);
                WulkaSession.Current = null;
                Thread.Sleep(5000);
            }
            else
            {   
                Feedback                = String.Format("User '{0}' is authenticated!", Request.UserName);
                WulkaSession.Current     = session;
                WulkaCredentials.Current = new ExtendedCredentials(
                    WulkaSession.Current.Username,
                    WulkaSession.Current.Id,
                    WulkaSession.Current.ApplicationFunctionId);
                WulkaContext.Current.Add(WulkaContextKey.UserName, WulkaSession.Current.Username);
                WulkaContext.Current.Add(WulkaContextKey.SessionId, WulkaSession.Current.Id);
                WulkaContext.Current.Add(WulkaContextKey.ServiceCode, WulkaSession.Current.ApplicationFunctionId);
                Messenger.Default.Send(new AuthenticationResultMessage() { Session = session }); 
            }
        }

        /// <summary>
        /// Registers this instance.
        /// </summary>
        [Command(Name="Register",UseCommandManager = true)]
        public void Register()
        {
            Messenger.Default.Send(new NavigateMvvmMessage() { 
                ViewName = RegisterUserView.ID,
                Header="Registration Form"

            });
        }

        /// <summary>
        /// Goes the back.
        /// </summary>
        [Command(Name="GoBack",UseCommandManager=true)]
        public void GoBack()
        {
            Messenger.Default.Send(new NavigateMvvmMessage() 
            { 
                Header =LoginView.HEADER,
                ViewName = LoginView.ID 
            });
        }

        /// <summary>
        /// Resets the password.
        /// </summary>
        [Command(Name = "ResetPassword", UseCommandManager = true, CanExecuteMethodName = "CanResetPassword")]
        public void ResetPassword()
        {
            Feedback = "A mail was sent with a link to reset your password.";
            Thread.Sleep(5000);
            Messenger.Default.Send(message: new NavigateMvvmMessage() 
            { 
                Header = LoginView.HEADER,
                ViewName = LoginView.ID 
            });
        }


        /// <summary>
        /// Determines whether this instance [can reset password].
        /// </summary>
        /// <returns><c>true</c> if this instance [can reset password]; otherwise, <c>false</c>.</returns>
        public bool CanResetPassword()
        {
            return !String.IsNullOrWhiteSpace(Request.UserName);
        }
    }
}
