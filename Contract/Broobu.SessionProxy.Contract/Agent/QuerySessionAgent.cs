// ***********************************************************************
// Assembly         : Broobu.SessionProxy.Contract
// Author           : Rafael Lefever
// Created          : 12-24-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 12-31-2013
// ***********************************************************************
// <copyright file="QuerySessionAgent.cs" company="Broobu Systems Ltd.">
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
    ///     Class QuerySessionAgent.
    /// </summary>
    internal class QuerySessionAgent : DiscoProxy<IQuerySession>, IQuerySessionAgent
    {
        public QuerySessionAgent(string discoUrl) : base(discoUrl)
        {
        }

        /// <summary>
        ///     Gets the sessions asynchronous.
        /// </summary>
        public void GetSessionsAsync()
        {
            WulkaSession[] ss = null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, e) => { ss = Client.GetSessions(); };
                wrk.RunWorkerCompleted += (s, e) =>
                {
                    if (GetSessionsCompleted != null)
                        GetSessionsCompleted(ss);
                };
                wrk.RunWorkerAsync();
            }
        }

        /// <summary>
        ///     Occurs when [get sessions completed].
        /// </summary>
        public event Action<WulkaSession[]> GetSessionsCompleted;

        /// <summary>
        ///     Gets the sessions asynchronous.
        /// </summary>
        /// <param name="act">The act.</param>
        public void GetSessionsAsync(Action<WulkaSession[]> act)
        {
            WulkaSession[] ss = null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, e) => { ss = Client.GetSessions(); };
                wrk.RunWorkerCompleted += (s, e) => { act.Invoke(ss); };
                wrk.RunWorkerAsync();
            }
        }


        /// <summary>
        ///     Gets the sessions.
        /// </summary>
        /// <returns>WulkaSession[][].</returns>
        public WulkaSession[] GetSessions()
        {
            return Client.GetSessions();
        }


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