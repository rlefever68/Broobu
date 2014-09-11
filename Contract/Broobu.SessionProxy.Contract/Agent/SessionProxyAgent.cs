// ***********************************************************************
// Assembly         : Broobu.SessionProxy.Contract
// Author           : Rafael Lefever
// Created          : 12-24-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 12-31-2013
// ***********************************************************************
// <copyright file="SessionProxyAgent.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel;
using Broobu.SessionProxy.Contract.Interfaces;
using Wulka.Domain;
using Wulka.Domain.Authentication;
using Wulka.Networking.Wcf;

namespace Broobu.SessionProxy.Contract.Agent
{
    /// <summary>
    ///     Class SessionProxyAgent.
    /// </summary>
    internal class SessionProxyAgent : DiscoProxy<ISessionProxy>, ISessionProxyAgent
    {
        #region ISessionProxyAgent Members

        public SessionProxyAgent(string discoUrl) : base(discoUrl)
        {
        }

        /// <summary>
        ///     Starts the session async.
        /// </summary>
        /// <param name="session">The session.</param>
        public void StartSessionAsync(WulkaSession session)
        {
            var ss = (WulkaSession) null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, e) => { ss = Client.StartSession(session); };
                wrk.RunWorkerCompleted += (s, e) =>
                {
                    if (StartSessionCompleted != null)
                        StartSessionCompleted(ss);
                };
                wrk.RunWorkerAsync();
            }
        }


        /// <summary>
        ///     Ends the session async.
        /// </summary>
        /// <param name="session">The session.</param>
        public void EndSessionAsync(WulkaSession session)
        {
            var ss = (WulkaSession) null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, e) => { ss = Client.EndSession(session); };
                wrk.RunWorkerCompleted += (s, e) =>
                {
                    if (EndSessionCompleted != null)
                        EndSessionCompleted(ss);
                };
                wrk.RunWorkerAsync();
            }
        }


        /// <summary>
        ///     Occurs when [end session completed].
        /// </summary>
        public event Action<WulkaSession> EndSessionCompleted;

        /// <summary>
        ///     Occurs when [start session completed].
        /// </summary>
        public event Action<WulkaSession> StartSessionCompleted;

        #endregion

        #region ISessionProxyService Members

        /// <summary>
        ///     Ends the session.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <returns>WulkaSession.</returns>
        public WulkaSession EndSession(WulkaSession session)
        {
            return Client.EndSession(session);
        }

        /// <summary>
        ///     Starts the session.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <returns>WulkaSession.</returns>
        public WulkaSession StartSession(WulkaSession session)
        {
            return Client.StartSession(session);
        }

        #endregion

        /// <summary>
        ///     Gets the contract namespace.
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string GetContractNamespace()
        {
            return SessionServiceConst.Namespace;
        }
    }
}