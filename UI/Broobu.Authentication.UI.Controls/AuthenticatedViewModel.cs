using System;
using System.Threading;
using Broobu.Fx.UI.Dialogs;
using Broobu.Fx.UI.MVVM;
using Wulka.Domain;
using Wulka.Domain.Authentication;


namespace Broobu.Authentication.UI.Controls
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public abstract class AuthenticatedViewModel : FxViewModelBase
    {


        /// <summary>
        /// Starts the authenticated session.
        /// </summary>
        /// <remarks></remarks>
        protected override void StartAuthenticatedSession()
        {
            AuthenticationHost.StartSessionAsync(loginCompletedAction: OnLoginCompleted);
        }


        /// <summary>
        /// Terminates the authenticated session.
        /// </summary>
        /// <param name="onSessionTerminated">The on session terminated.</param>
        /// <remarks></remarks>
        public override void TerminateAuthenticatedSession(Action onSessionTerminated = null)
        {
            AuthenticationHost.TerminateSessionAsync(onSessionTerminated);
        }



        /// <summary>
        /// Called when [login completed].
        /// </summary>
        /// <remarks></remarks>
        public void OnLoginCompleted()
        {
            PleaseWaitDialog.Show("User [{0}] authenticated.\nWelcome, {1}.",WulkaSession.Current.Username,
                WulkaSession.Current.FirstName);
            Thread.Sleep(1500);
            PleaseWaitDialog.Close();
            IsAuthenticated = true;
            IsBusy = false;
            InitializeInternal(InitializationParams);
        }



    }
}
