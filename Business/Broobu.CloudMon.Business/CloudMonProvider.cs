// ***********************************************************************
// Assembly         : Broobu.CloudMon.Business
// Author           : Rafael Lefever
// Created          : 01-18-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-18-2014
// ***********************************************************************
// <copyright file="CloudMonProvider.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Broobu.CloudMon.Business.Interfaces;
using Broobu.CloudMon.Business.Workers;
using Broobu.CloudMon.Contract.Domain;
using Broobu.MonitorDisco.Contract.Domain;

namespace Broobu.CloudMon.Business
{
    /// <summary>
    /// Class CloudMonProvider.
    /// </summary>
    public static class CloudMonProvider
    {
        /// <summary>
        /// Gets the cloud mons.
        /// </summary>
        /// <value>The cloud mons.</value>
        public static ICloudMons CloudMons 
        {
            get 
            { 
                return new CloudMons();
            }
        }



        /// <summary>
        /// To the endpoint information.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>EndpointInfo.</returns>
        public static EndpointInfo ToEndpointInfo(this DiscoInfo item)
        {
            return new EndpointInfo() 
            {
                Application = item.Application,
                Contract = item.Contract,
                Endpoint = item.Endpoint,
                Host = item.Host,
                Layer = item.Layer,
                Port = item.Port,
                Protocol = item.Protocol,
                Service = item.Service,
                Status = item.Status
            };

        }
    }
}
