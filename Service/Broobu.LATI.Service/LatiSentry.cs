// ***********************************************************************
// Assembly         : Broobu.LATI.Service
// Author           : Rafael Lefever
// Created          : 01-13-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-15-2014
// ***********************************************************************
// <copyright file="LatiSentry.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Broobu.LATI.Business;
using Broobu.LATI.Contract.Domain;
using Broobu.LATI.Contract.Interfaces;
using Wulka.Domain;
using Wulka.Extensions;
using Wulka.Networking.Wcf;

namespace Broobu.LATI.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    /// <summary>
    /// Class LatiSentry.
    /// </summary>
    public class LatiSentry : SentryBase, ILatiSentry
    {
        /// <summary>
        /// Registers the required domain objects.
        /// </summary>
        protected override void RegisterRequiredDomainObjects()
        {
            LatiProvider
                .Latis
                .InflateDomain();
        }

       



        public string RegisterLocation(string logItem)
        {
            return LatiProvider
                .Latis
                .RegisterLocation(logItem.Unzip<LocationLog>())
                .Zip();
        }


        /// <summary>
        /// Gets the point of interest.
        /// </summary>
        /// <param name="poIId">The po i identifier.</param>
        /// <returns>PointOfInterest.</returns>
        public string GetPointOfInterest(string poIId)
        {
            return LatiProvider
                .Latis
                .GetPointOfInterest(poIId)
                .Zip();
        }
    }
}
