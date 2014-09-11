// ***********************************************************************
// Assembly         : Broobu.LATI.Business
// Author           : Rafael Lefever
// Created          : 07-20-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-13-2014
// ***********************************************************************
// <copyright file="Latis.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Broobu.LATI.Business.Interfaces;
using Broobu.LATI.Contract.Domain;
using Wulka.Data;
using Wulka.Exceptions;
using NLog;

namespace Broobu.LATI.Business.Workers
{
    /// <summary>
    /// Class Latis.
    /// </summary>
    public class Latis : ILatis
    {

        /// <summary>
        /// The _logger
        /// </summary>
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();



        /// <summary>
        /// Inflates the domain.
        /// </summary>
        public void InflateDomain()
        {
        }


        /// <summary>
        /// Registers the location.
        /// </summary>
        /// <param name="logItem">The log item.</param>
        /// <returns>LocationLog.</returns>
        public LocationLog RegisterLocation(LocationLog logItem)
        {
            try
            {
                var poi = GetPointOfInterest(logItem.PoIId);
                return Provider<LocationLog>.Save(logItem);
            }
            catch (Exception exception)
            {
                logItem.AddError(exception.Message);
                _logger.Error(exception.GetCombinedMessages());
                return logItem;
            }
        }


        /// <summary>
        /// Gets the point of interest.
        /// </summary>
        /// <param name="poIId">The po i identifier.</param>
        /// <returns>PointOfInterest.</returns>
        public PointOfInterest GetPointOfInterest(string poIId)
        {
            var res = new PointOfInterest() { Id = poIId };
            try
            {
                res = Provider<PointOfInterest>.GetById(poIId) ?? 
                    Provider<PointOfInterest>.Save(res);
                return res;
            }
            catch (Exception exception)
            {
                res.AddError(exception.Message);
                _logger.Error(exception.GetCombinedMessages);
                return res;
            }
        }
    }
}
