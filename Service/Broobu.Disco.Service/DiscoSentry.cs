// ***********************************************************************
// Assembly         : Broobu.Disco.Service
// Author           : Rafael Lefever
// Created          : 12-24-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 12-25-2013
// ***********************************************************************
// <copyright file="DiscoService.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ServiceModel;
using Broobu.Disco.Business;
using Wulka.Domain;
using Wulka.Interfaces;
using Wulka.Logging;


namespace Broobu.Disco.Service
{

    /// <summary>
    /// Class DiscoService.
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class DiscoSentry : IDisco
    {


       


        /// <summary>
        /// Gets the endpoints.
        /// </summary>
        /// <param name="contractType">The scope.</param>
        /// <returns>SerializableEndpoint[][].</returns>
        public SerializableEndpoint[] GetEndpoints(string contractType)
        {
            try
            {
                return DiscoProvider
                    .Discos
                    .GetEndpoints(contractType);
            }
            catch (Exception exception)
            {
                FxLog<DiscoSentry>.DebugFormat("Error getting Endpoints from {0}. Error: {1}", contractType, exception.Message);
                throw;
            }
        }


        //protected override void RegisterRequiredDomainObjects()
        //{     
        //    _FxLog<DiscoSentry>.DebugFormat("Hello");
        //}

        #region IDiscoService Members


        /// <summary>
        /// Gets all endpoints.
        /// </summary>
        /// <returns>SerializableEndpoint[][].</returns>
        public SerializableEndpoint[] GetAllEndpoints()
        {
            try
            {
                return Business.DiscoProvider
                    .Discos
                    .GetAllEndpoints();
            }
            catch (Exception exception)
            {
                FxLog<DiscoSentry>.LogException(exception);
                throw;
            }
        }

        #endregion



        #region IDiscoService Members


        /// <summary>
        /// Gets all endpoint addresses.
        /// </summary>
        /// <returns>DiscoItem[][].</returns>
        public DiscoItem[] GetAllEndpointAddresses()
        {
            try
            {
                return Business.DiscoProvider
                    .Discos
                    .GetAllEndpointAddresses();
            }
            catch (Exception exception)
            {
                FxLog<DiscoSentry>.DebugFormat("Error getting all endpoint addresses. Error: {0}", exception.Message);
                throw;
            }
        }

        #endregion
    }
}
