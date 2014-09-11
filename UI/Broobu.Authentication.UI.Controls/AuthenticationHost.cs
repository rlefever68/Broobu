// ***********************************************************************
// Assembly         : Broobu.Authentication.UI.Controls
// Author           : ON8RL
// Created          : 12-16-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-16-2013
// ***********************************************************************
// <copyright file="AuthenticationHost.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Broobu.Authentication.Contract;
using Broobu.Authentication.UI.Controls.Views;
using Broobu.Fx.UI.Domain;
using Broobu.Fx.UI.MVVM;
using Broobu.Fx.UI.Views;
using DevExpress.Mvvm;
using Wulka.Authentication;
using Wulka.Domain;
using Wulka.Domain.Authentication;
using Wulka.Logging;
using NLog;


namespace Broobu.Authentication.UI.Controls
{
    /// <summary>
    /// Class AuthenticationHost.
    /// </summary>
    public class AuthenticationHost
    {

        /// <summary>
        /// The _login completed action
        /// </summary>
        private static Action _loginCompletedAction;
        /// <summary>
        /// The _login canceled action
        /// </summary>
        private static Action _loginCanceledAction;
        /// <summary>
        /// The _post logoff action
        /// </summary>
        private static Action _postLogoffAction;

        public static WaitInfo WaitInfo { get; set; }


        public static void Register()
        { }



        
        /// <summary>
        /// Starts the session.
        /// </summary>
        /// <param name="loginCompletedAction">The login completed action.</param>
        /// <param name="canceledAction"></param>
        /// <param name="loginCanceledAction">The login canceled action.</param>
        public static void StartSessionAsync(Action loginCompletedAction = null, 
            Action loginCanceledAction = null)
        {
            _loginCompletedAction = loginCompletedAction;
            _loginCanceledAction = loginCanceledAction;

            if ((WulkaSession.Current != null) && (!WulkaSession.Current.IsDefaultSession)) return;
            FxLog<AuthenticationHost>.InfoFormat("****************************");
            FxLog<AuthenticationHost>.InfoFormat("*     Starting Session     *");
            FxLog<AuthenticationHost>.InfoFormat("****************************");
            if (WulkaSession.Current != null)
            {
                FxLog<AuthenticationHost>.InfoFormat("Starting Session {0}", WulkaSession.Current.Id);
            }
            // By Default, we try to authenticate the user using Windows Authentication
            //TryWindowsAuthenticationAsync();
            TryNativeAuthentication();
        }

        /// <summary>
        /// Tries the native authentication.
        /// </summary>
        private static void TryNativeAuthentication()
        {
            FxLog<AuthenticationHost>.InfoFormat("Trying Native Authentication");
            Messenger.Default.Send(new NavigateMvvmMessage() 
            { 
                Header = LoginView.HEADER,
                ViewName = LoginView.ID 
            });
        }



        ///// <summary>
        ///// Tries the windows authentication.
        ///// </summary>
        ///// <returns></returns>
        /// <summary>
        /// Tries the windows authentication asynchronous.
        /// </summary>
        //private static void TryWindowsAuthenticationAsync()
        //{
        //    if (WindowsIdentity.GetCurrent() == null) return;
        //    try
        //    {
        //        OnWindowsAuthenticationCompleted(WulkaSession.Current);
        //        //_logger.DebugFormat("Try Windows Authentication");
        //        //PleaseWaitDialog.Show("Trying windows authentication for user [{0}]...", WindowsIdentity.GetCurrent().Name);
        //        //WinAuthenticationAgentFactory
        //        //    .CreateAgent()
        //        //    .AuthenticateUserCredentialsAsync(OnWindowsAuthenticationCompleted);
        //    }
        //    catch(Exception e)
        //    {
        //        // ReSharper disable once PossibleNullReferenceException
        //        FxLog<AuthenticationHost>.DebugFormat("Windows Authentication has failed for user: [{0}]", WindowsIdentity.GetCurrent().Name);
        //        WulkaSession.Current = null;
        //        // ReSharper disable once PossibleNullReferenceException
        //        PleaseWaitDialog.Show("Windows authentication for user [{0}] has failed.", WindowsIdentity.GetCurrent().Name);
                
        //    }
        //}


        /// <summary>
        /// Called when [windows authentication completed].
        /// </summary>
        /// <param name="session">The session.</param>
        //static void OnWindowsAuthenticationCompleted(WulkaSession session)
        //{
        //    PleaseWaitDialog.Close();
        //    WulkaSession.Current = session;
        //    if(WulkaSession.Current != null)
        //    {
        //        FxLog<AuthenticationHost>.DebugFormat("Windows Authentication has succeeded for user: [{0}]", WulkaSession.Current.Username);
               
        //        WulkaCredentials.Current = new WulkaASExtCredentials(WulkaSession.Current.Username, 
        //            WulkaSession.Current.Id, 
        //            WulkaSession.Current.ApplicationFunctionId);

        //        if(!WulkaSession.Current.IsKnown)
        //            RegisterNewUserDialog.Execute(WulkaSession.Current);
        //        if(_loginCompletedAction!=null)
        //            _loginCompletedAction();
        //    }
        //    else
        //    {
        //        TryNativeAuthentication();
        //    }
        //}


        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Terminates the session async.
        /// </summary>
        /// <param name="postLogoffAction">The act.</param>
        public static void TerminateSessionAsync(Action postLogoffAction = null)
        {
            Messenger.Default.Send(new NavigateMvvmMessage() 
            { 
                Header   = WaitInfo.Header,
                ViewName = WaitView.ID,
                Parameter = WaitInfo
            });
            Logger.Info("{0}, Reason: {1}", WaitInfo.Title,WaitInfo.Reason);
            FxLog<AuthenticationHost>.DebugFormat(WaitInfo.Title);
            _postLogoffAction = postLogoffAction;
            if (WulkaSession.Current != null) 
            {
                AuthenticationPortal
                    .Authentication
                    .TerminateSessionAsync(TerminateSessionAsyncCompleted);
            }
            else
            {
                if (_postLogoffAction != null) 
                    _postLogoffAction.Invoke();
            }
        }

        


        /// <summary>
        /// Terminates the session async completed.
        /// </summary>
        /// <param name="session">The session.</param>
        static void TerminateSessionAsyncCompleted(WulkaSession session)
        {
            WulkaSession.Current = session;
            WulkaCredentials.Current = new ExtendedCredentials(
                WulkaSession.Current.Username, 
                WulkaSession.Current.Id, 
                WulkaSession.Current.ApplicationFunctionId);
            AuthenticationPortal
                .Authentication
                .AuthenticateByUserNameAndPasswordAsync(AuthenticationDefaults.GuestUserName, AuthenticationDefaults.GuestEncPwd, OnGuestLogonCompleted);
        }


        /// <summary>
        /// Called when [guest logon completed].
        /// </summary>
        /// <param name="session">The session.</param>
        static void OnGuestLogonCompleted(WulkaSession session)
        {
            WulkaSession.Current = session;
            if (_postLogoffAction != null)
                _postLogoffAction();
        }

        /// <summary>
        /// Starts the native session asynchronous.
        /// </summary>
        /// <param name="loginCompletedAction">The login completed action.</param>
        public static void StartNativeSessionAsync(Action loginCompletedAction=null)
        {
            _loginCompletedAction = loginCompletedAction;
            if ((WulkaSession.Current == null) || (WulkaSession.Current.IsDefaultSession))
            {
                TryNativeAuthentication();
            }
        }
    }

    
}
