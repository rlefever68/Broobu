using System;
using System.ComponentModel;
using System.Net;
using Iris.Fx.Domain;
using Iris.Fx.Networking.Wcf;
using Iris.WinAuthentication.Contract.Interfaces;

namespace Iris.WinAuthentication.Contract.Agent
{
    class WinAuthenticationAgent : DiscoProxy<IWinAuthentication>, IWinAuthenticationAgent
    {

        public WinAuthenticationAgent()
        {
            ServicePointManager.ServerCertificateValidationCallback = ((p1, p2, p3, p4) => true );
        }

        #region IWindowsAuthenticationAgent Members

  //      public event Action<IrisSession> ValidateUserCredentialsCompleted;

        public void AuthenticateUserCredentialsAsync(Action<IrisSession> act)
        {
            var sess = (IrisSession)null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, e) =>
                {
                    try
                    {
                        sess = AuthenticateUserCredentials();
                    }
                    catch (Exception ex)
                    {
                        wrk.Dispose();
                        throw ex;
                    }
                };
                wrk.RunWorkerCompleted += (s, e) =>
                {
                    wrk.Dispose();
                    if (act != null)
                        act(sess);
                };
                wrk.RunWorkerAsync();
            }
        }

        #endregion

        #region IWindowsAuthenticationService Members

        public IrisSession AuthenticateUserCredentials()
        {
            return Client.AuthenticateUserCredentials();
        }

        #endregion
    

    }
}
