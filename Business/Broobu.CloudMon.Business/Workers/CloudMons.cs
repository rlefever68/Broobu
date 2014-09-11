// ***********************************************************************
// Assembly         : Broobu.CloudMon.Business
// Author           : Rafael Lefever
// Created          : 01-18-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-18-2014
// ***********************************************************************
// <copyright file="CloudMons.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Linq;
using Broobu.CloudMon.Business.Interfaces;
using Broobu.CloudMon.Contract.Domain;
using Broobu.MonitorDisco.Business;

namespace Broobu.CloudMon.Business.Workers
{
    /// <summary>
    /// Class CloudMons.
    /// </summary>
    class CloudMons : ICloudMons
    {
        /// <summary>
        /// Gets the endpoints.
        /// </summary>
        /// <returns>EndpointInfo[][].</returns>
        public EndpointInfo[] GetEndpoints()
        {
            return  MonitorDiscoProvider
                .DiscoViewItems
                .GetAllEndpoints()
                .Select(discoInfo => discoInfo.ToEndpointInfo())
                .ToArray();
        }
    }
}
