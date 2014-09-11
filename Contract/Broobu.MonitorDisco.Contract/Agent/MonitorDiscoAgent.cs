// ***********************************************************************
// Assembly         : Broobu.MonitorDisco.Contract
// Author           : Rafael Lefever
// Created          : 12-25-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-01-2014
// ***********************************************************************
// <copyright file="MonitorDiscoAgent.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using Broobu.MonitorDisco.Contract.Domain;
using Broobu.MonitorDisco.Contract.Interfaces;
using Wulka.Networking.Wcf;

namespace Broobu.MonitorDisco.Contract.Agent
{
    /// <summary>
    /// Class MonitorDiscoAgent.
    /// </summary>
    class MonitorDiscoAgent : DiscoProxy<IMonitorDisco>, IMonitorDiscoAgent
    {
        #region IMonitorDiscoService Members

        /// <summary>
        /// Gets all endpoints.
        /// </summary>
        /// <returns>DiscoInfo[].</returns>
        public DiscoInfo[] GetAllEndpoints()
        {
            var clt = CreateClient();
            try 
            { 
                return clt.GetAllEndpoints();
            }
            finally
            {
                CloseClient(clt);
            }

        }





        #endregion

        #region IMonitorDiscoAgent Members

        /// <summary>
        /// Occurs when [get all endpoints completed].
        /// </summary>
        public event Action<DiscoInfo[]> GetAllEndpointsCompleted;

        /// <summary>
        /// Gets all endpoints async.
        /// </summary>
        public void GetAllEndpointsAsync()
        {
                    DiscoInfo[] result = null;
                    using (var wrk = new BackgroundWorker())
                    {
                        wrk.DoWork += (s, d) =>
                        {
                            result = GetAllEndpoints();
                        };
                        wrk.RunWorkerCompleted += (s, e) =>
                        {
                            if (GetAllEndpointsCompleted != null)
                                GetAllEndpointsCompleted(result);
                        };
                        wrk.RunWorkerAsync();
                    }
        }

        /// <summary>
        /// Gets all endpoints async.
        /// </summary>
        /// <param name="action">The action.</param>
        public void GetAllEndpointsAsync(Action<DiscoInfo[]> action)
        {
                DiscoInfo[] result = null;
                using (var wrk = new BackgroundWorker())
                {
                    wrk.DoWork += (s, d) =>
                    {
                        result = GetAllEndpoints();
                    };
                    wrk.RunWorkerCompleted += (s, e) =>
                    {
                        if (action != null)
                            action(result);
                    };
                    wrk.RunWorkerAsync();
                };
            
        }
        #endregion


        /// <summary>
        /// Gets the contract namespace.
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string GetContractNamespace()
        {
            return MonitorDiscoServiceConst.Namespace;
        }
    }
}
