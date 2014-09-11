// ***********************************************************************
// Assembly         : Broobu.MonitorDisco.Business
// Author           : Rafael Lefever
// Created          : 12-24-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-18-2014
// ***********************************************************************
// <copyright file="DiscoViewItemMapper.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using Broobu.MonitorDisco.Contract.Domain;
using Wulka.Domain;

namespace Broobu.MonitorDisco.Business.Mappers
{
    /// <summary>
    /// Class DiscoViewItemMapper.
    /// </summary>
    public static class DiscoViewItemMapper 
    {

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <param name="segments">The segments.</param>
        /// <returns>System.String.</returns>
        private static string GetService(IList<string> segments)
        {
            return segments[segments.Count - 1];
        }

        /// <summary>
        /// Gets the application.
        /// </summary>
        /// <param name="segments">The segments.</param>
        /// <returns>System.String.</returns>
        private static string GetApplication(IList<string> segments)
        {
            return segments.Count >= 4 ? segments[3] : "<undefined>";
        }

        /// <summary>
        /// Gets the layer.
        /// </summary>
        /// <param name="segments">The segments.</param>
        /// <returns>System.String.</returns>
        private static string GetLayer(IList<string> segments)
        {
            return segments.Count >= 3 ? segments[2] : "<undefined>";
        }



        /// <summary>
        /// To the disco item.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>DiscoItem.</returns>
        public static DiscoItem ToDiscoItem(this DiscoInfo source)
        {
            return new DiscoItem()
            {
                Id = source.Id,
                Contract = source.Contract,
                CorrelationId = source.CorrelationId,
                Endpoint = source.Endpoint,
                Priority = source.Priority,
                SessionId = source.SessionId
            };

        }

        /// <summary>
        /// To the disco information.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns>DiscoInfo.</returns>
        public static DiscoInfo ToDiscoInfo(this DiscoItem target)
        {
            var ep = new Uri(target.Endpoint);
            return new DiscoInfo()
            {
                Layer = GetLayer(ep.Segments),
                Application = GetApplication(ep.Segments),
                Service = GetService(ep.Segments),
                Host = ep.DnsSafeHost,
                Port = Convert.ToString(ep.Port),
                Protocol = ep.Scheme,
                Contract = target.Contract,
                Endpoint = target.Endpoint
            };
        }
    }
}
