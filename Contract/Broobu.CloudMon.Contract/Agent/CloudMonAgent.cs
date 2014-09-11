// ***********************************************************************
// Assembly         : Broobu.CloudMon.Contract
// Author           : Rafael Lefever
// Created          : 01-17-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-17-2014
// ***********************************************************************
// <copyright file="CloudMonAgent.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using System.Linq;
using System.Net;
using Broobu.CloudMon.Contract.Domain;
using Broobu.CloudMon.Contract.Interfaces;
using Broobu.MonitorDisco.Contract.Domain;
using Iris.Fx.Utils;

namespace Broobu.CloudMon.Contract.Agent
{
    /// <summary>
    /// Class CloudMonAgent.
    /// </summary>
    class CloudMonAgent :  ICloudMonAgent
    {
        /// <summary>
        /// Gets all endpoints.
        /// </summary>
        /// <returns>DiscoInfo[][].</returns>
        public EndpointInfo[] GetEndpoints()
        {
            var req = WebRequest.Create("http://www.broobu.com/services/broobu/cloudmon/cloudmon.svc/GetAllEndpoints");
            var resp = req.GetResponse();
            var sIn = resp.GetResponseStream();
            return DomainSerializer<EndpointInfo>.DeserializeJsons(sIn).ToArray();
        }

    }
}
