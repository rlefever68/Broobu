// ***********************************************************************
// Assembly         : Broobu.LATI.Business
// Author           : Rafael Lefever
// Created          : 01-14-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-14-2014
// ***********************************************************************
// <copyright file="Regions.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Broobu.LATI.Business.Interfaces;
using Broobu.LATI.Contract.Domain;
using Wulka.Data;

namespace Broobu.LATI.Business.Workers
{
    /// <summary>
    /// Class Regions.
    /// </summary>
    class RegionsSentry : IRegionsSentry
    {
        /// <summary>
        /// Saves the region.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <returns>Region.</returns>
        public Region SaveRegion(Region region)
        {
            return Provider<Region>.Save(region);
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Region.</returns>
        public Region GetById(string id)
        {
            return Provider<Region>.GetById(id);
        }
    }
}
