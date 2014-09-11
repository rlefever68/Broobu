// ***********************************************************************
// Assembly         : Broobu.LATI.Business
// Author           : Rafael Lefever
// Created          : 01-14-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 03-24-2014
// ***********************************************************************
// <copyright file="Cultures.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Globalization;
using Broobu.LATI.Business.Interfaces;
using Broobu.LATI.Contract.Domain;
using Wulka.Data;
using Wulka.Domain;
using Wulka.Exceptions;
using Wulka.Interfaces;
using Wulka.Utils;
using NLog;

namespace Broobu.LATI.Business.Workers
{
    /// <summary>
    /// Class Cultures.
    /// </summary>
    public class Cultures : ICultures
    {

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
       


        /// <summary>
        /// Gets the region.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>Region.</returns>
        private static Region GetRegion(string culture)
        {
            RegionInfo regionInfo;
            try
            {
                regionInfo = new RegionInfo(culture);
            }
            catch (Exception)
            {
                regionInfo = null;
            }
            return regionInfo!=null ? regionInfo.ToRegion() : null;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Culture.</returns>
        public ICultureDocument GetById(string id)
        {
            return Provider<CultureDocument>.GetById(id);
        }

        public IEnumerable<IRegion> GetRegions(string id)
        {
            return Provider<CultureDocument>.GetById(id).Regions;
        }

        public IEnumerable<ICulture> GetCultures(string id)
        {
            return Provider<CultureDocument>.GetById(id).Cultures;
        }


        public CultureDocument InflateDomain()
        {
            var res = new CultureDocument();
            try
            {
                _logger.Info("Registering Cultures Domain.");
                foreach (var c in CurrentWindowsUser.AllCultures)
                {
                    var cult = c.ToCulture();
                    res.AddPart(cult);
                    //_logger.Info("Culture '{0}' saved. Revision [{1}]", cult.Id, cult.Rev);
                    var region = GetRegion(c.ToString());
                    if (region == null) continue;
                    res.AddPart(region);
                    //_logger.Info("Region '{0}' saved. Revision [{1}]", region.Id, region.Rev);
                    res.LinkCultureToRegion(cult, region);
                }
                _logger.Info("Done Registering Cultures Domain.");
                return Provider<CultureDocument>.Save(res);
            }
            catch (Exception exception)
            {
                res.AddError(exception.Message);
                _logger.Error(exception.GetCombinedMessages());
                return res;
            }
        }


       
    }
}