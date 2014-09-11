// ***********************************************************************
// Assembly         : Broobu.SessionProxy.Contract
// Author           : Rafael Lefever
// Created          : 12-24-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-15-2014
// ***********************************************************************
// <copyright file="SessionProxyPortal.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Broobu.SessionProxy.Contract.Agent;
using Broobu.SessionProxy.Contract.Interfaces;

namespace Broobu.SessionProxy.Contract
{
    /// <summary>
    ///     Class SessionProxyPortal.
    /// </summary>
    public static class SessionProxyPortal
    {
        /// <summary>
        ///     Gets the session proxy.
        /// </summary>
        /// <value>The session proxy.</value>
        public static ISessionProxyAgent SessionProxy
        {
            get { return new SessionProxyAgent(null); }
        }

        /// <summary>
        ///     Gets the query.
        /// </summary>
        /// <value>The query.</value>
        public static IQuerySessionAgent QuerySession
        {
            get { return new QuerySessionAgent(null); }
        }
    }
}