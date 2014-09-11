// ***********************************************************************
// Assembly         : Broobu.LATI.Service
// Author           : Rafael Lefever
// Created          : 01-13-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-14-2014
// ***********************************************************************
// <copyright file="CultureSentry.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Linq;
using Broobu.LATI.Business;
using Broobu.LATI.Contract.Interfaces;
using Wulka.Extensions;
using Wulka.Networking.Wcf;

namespace Broobu.LATI.Service
{
    /// <summary>
    /// Class CultureSentry.
    /// </summary>
    public class CultureSentry : SentryBase, ICultureSentry
    {
        /// <summary>
        /// Registers the required domain objects.
        /// </summary>
        protected override void RegisterRequiredDomainObjects()
        {
            LatiProvider
                .Cultures
                .InflateDomain();

        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Culture.</returns>
        public string GetById(string id)
        {
            return LatiProvider
                .Cultures
                .GetById(id)
                .Zip();
        }

        public string[] GetCultures(string id)
        {
            return LatiProvider
                .Cultures
                .GetCultures(id)
                .Zip()
                .ToArray();
        }

        public string[] GetRegions(string id)
        {
            return LatiProvider
                .Cultures
                .GetRegions(id)
                .Zip()
                .ToArray();
                
        }
    }
}
