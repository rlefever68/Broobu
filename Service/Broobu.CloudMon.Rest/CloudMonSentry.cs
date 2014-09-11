// ***********************************************************************
// Assembly         : Broobu.CloudMon.Rest
// Author           : Rafael Lefever
// Created          : 01-17-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-17-2014
// ***********************************************************************
// <copyright file="CloudMonSentry.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ServiceModel;
using Broobu.CloudMon.Business;
using Broobu.CloudMon.Contract.Domain;
using Broobu.CloudMon.Contract.Interfaces;


namespace Broobu.CloudMon.Rest
{

    /// <summary>
    /// Class CloudMonitorSentry.
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class CloudMonitorSentry : ICloudMon
    {
        /// <summary>
        /// Gets all endpoints.
        /// </summary>
        /// <returns>DiscoInfo[][].</returns>
        public EndpointInfo[] GetEndpoints()
        {
            return CloudMonProvider
                .CloudMons
                .GetEndpoints();
        }


    }
}