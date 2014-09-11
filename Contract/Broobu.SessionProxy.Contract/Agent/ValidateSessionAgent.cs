using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pms.SessionProxy.Contract.Interfaces;
using Pms.Framework.Networking.Wcf;
using System.ComponentModel;

namespace Pms.SessionProxy.Contract.Agent
{
    public class ValidateSessionAgent : DiscoProxy<IValidateSession>,IValidateSessionAgent
    {
   

        #region IValidateSession Members
        
        public bool  Validate(string userName, string sessionId)
        {
            return Client.Validate(userName, sessionId);
        }
        #endregion

      

        #region IValidateSessionAgent Members


        public event Action<bool> ValidateCompleted;


        /// <summary>
        /// Validates the async.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="sessionId">The session id.</param>
        public void ValidateAsync(string userName, string sessionId)
        {
            bool b = false;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, e) =>
                {
                    b = Validate(userName, sessionId);
                };
                wrk.RunWorkerCompleted += (s, e) =>
                {
                    if (ValidateCompleted != null)
                        ValidateCompleted(b);
                };
                wrk.RunWorkerAsync();
            }
        }

        #endregion
    }
}
