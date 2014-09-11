// ***********************************************************************
// Assembly         : Broobu.SessionProxy.Service
// Author           : Rafael Lefever
// Created          : 12-24-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 12-24-2013
// ***********************************************************************
// <copyright file="SessionCache.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Timers;
using Wulka.Configuration;
using Wulka.Domain;
using NLog;
using Wulka.Domain.Authentication;


namespace Broobu.SessionProxy.Service
{
    /// <summary>
    /// Class SessionCache.
    /// </summary>
    internal class SessionCache : IDisposable
    {

        /// <summary>
        /// The _sync
        /// </summary>
        private static object _sync = new object();


        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static SessionCache Instance
        {
            get
            {
                if (_instance != null) return _instance;
                if (_instance == null)
                        return _instance = new SessionCache();
                return _instance;
            }
        }

        /// <summary>
        /// The _timer
        /// </summary>
        private Timer _timer;


        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                if (_timer != null)
                {
                    _timer.Dispose();
                    _timer = null;
                }
        }
        /// <summary>
        /// Finalizes an instance of the <see cref="SessionCache"/> class.
        /// </summary>
        ~SessionCache()
        {
            Dispose(false);
        }
        /// <summary>
        /// Prevents a default instance of the <see cref="SessionCache"/> class from being created.
        /// </summary>
        private SessionCache()
        {
            _timer = new Timer();
            _timer.Elapsed += (s, e) => CheckSessions();
            if (ConfigurationHelper.SessionTimeout <= 0) return;
            _timer.Interval = 1000 * 60 * ConfigurationHelper.SessionTimeout;
            _timer.Start();
            Logger.Info("Starting Session Timer. Session Timeout={0} minutes", ConfigurationHelper.SessionTimeout);
        }


        /// <summary>
        /// The _instance
        /// </summary>
        private static SessionCache _instance;
        /// <summary>
        /// The _active sessions
        /// </summary>
        private static readonly Dictionary<string, WulkaSession> ActiveSessions = new Dictionary<string,WulkaSession>();
        private static readonly Logger Logger = LogManager.GetLogger("SessionCache");
        


        /// <summary>
        /// Adds the session.
        /// </summary>
        /// <param name="session">The nfo.</param>
        /// <returns>WulkaSession.</returns>
        internal WulkaSession AddSession(WulkaSession session)
        {
            if (session == null) 
                session=SessionFactory.CreateDefaultWulkaSession();
            session.SessionId = Guid.Empty.ToString();
            PrintSession(session,"Adding");
            lock (ActiveSessions)
            {
                session = Decorate(session);
                RemoveSession(session);
                ActiveSessions.Add(session.Id, session);
            }
            PrintSession(session, "Added");
            return session;
        }

        /// <summary>
        /// Decorates the specified session.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <returns>WulkaSession.</returns>
        private WulkaSession Decorate(WulkaSession session)
        {
            PrintSession(session, "Decorating");
            WulkaSession result = session;
            result.SessionId = session.Id;
            switch (session.AuthenticationMode)
            {
                case AuthenticationMode.Windows:
                    {
                        if (Validate(session.Username, session.Id))
                        {
                            result = ActiveSessions[session.Id];
                        }
                        else
                        {
                            result.Id = session.Id;
                            result.SessionId = session.Id;
                            result.LastRequest = DateTime.Now;
                            result.Username = session.Username;
                            result.IsKnown = session.IsKnown;
                            result.AuthenticationMode = session.AuthenticationMode;
                            result.ConnectionTime = DateTime.Now;
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            PrintSession(result, "Decorated");
            return result;
        }

        /// <summary>
        /// Prints the session.
        /// </summary>
        /// <param name="nfo">The nfo.</param>
        /// <param name="verb">The verb.</param>
        private void PrintSession(WulkaSession nfo, string verb)
        {
            if(nfo==null) 
                Logger.Debug("Calling PrintSession with no info....");
            else
                Logger.Info("{0} Session: [{1}] - User = {2}", verb, nfo.Id, nfo.Username);
        }

        /// <summary>
        /// Removes the session.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <returns>WulkaSession.</returns>
        internal WulkaSession RemoveSession(WulkaSession session)
        {
            if (session == null) 
                session = SessionFactory.CreateDefaultWulkaSession();
            PrintSession(session, "Removing");
            lock (ActiveSessions)
            {
                ActiveSessions.Remove(session.Id);
            }
            PrintSession(session, "Removed");
            return SessionFactory.CreateDefaultWulkaSession();
        }


        /// <summary>
        /// Validates the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="sessionId">The session id.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        internal bool Validate(string userName, string sessionId)
        {
            var session = Find(sessionId);
            if (session == null) return false;
            session.LastRequest = DateTime.Now;
            return (session.Username == userName);
        }



        /// <summary>
        /// Finds the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>WulkaSession.</returns>
        private WulkaSession Find(string id)
        {
            return ActiveSessions.ContainsKey(id) ? (ActiveSessions[id]) : null;
        }


        /// <summary>
        /// Gets the sessions.
        /// </summary>
        /// <returns>WulkaSession[][].</returns>
        internal WulkaSession[] GetSessions()
        {
            return ActiveSessions.Values.ToArray();
        }

        /// <summary>
        /// Checks the sessions.
        /// </summary>
        public void CheckSessions()
        {
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, e) =>
                                  {
                                      try
                                      {
                                          var src = new Dictionary<string, WulkaSession>(ActiveSessions);
                                          foreach (var it in
                                              src.Where(it => DateTime.Now>it.Value.LastRequest.AddMinutes(ConfigurationHelper.SessionTimeout)))
                                          {
                                              RemoveSession(it.Value);
                                              Logger.Info("Session {0} has timed out.",it.Key);
                                          }
                                      }
                                      catch
                                      {
                                          wrk.Dispose();
                                      }
                                  };
                wrk.RunWorkerAsync();
            }
        }
    }
}
