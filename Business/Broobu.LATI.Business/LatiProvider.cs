// ***********************************************************************
// Assembly         : Broobu.LATI.Business
// Author           : Rafael Lefever
// Created          : 01-13-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-14-2014
// ***********************************************************************
// <copyright file="LatiProvider.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Globalization;
using Broobu.LATI.Business.Interfaces;
using Broobu.LATI.Business.Workers;
using Broobu.LATI.Contract.Domain;


namespace Broobu.LATI.Business
{
    /// <summary>
    /// Class Lati.
    /// </summary>
    public static class LatiProvider
    {
        /// <summary>
        /// Gets the cultures.
        /// </summary>
        /// <value>The cultures.</value>
        public static ICultures Cultures
        {
            get
            {
                return new Cultures();
            }
        }

        /// <summary>
        /// Gets the regions.
        /// </summary>
        /// <value>The regions.</value>
        public static IRegionsSentry RegionsSentry 
        {
            get 
            {
                return new RegionsSentry();
            }
        }

        public static ILatis Latis 
        {
            get 
            { 
                return new Latis();
            }
        }


        /// <summary>
        /// To the region.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <returns>Region.</returns>
        public static Region ToRegion(this RegionInfo info)
        {
            return new Region() 
            { 
                Id = info.ThreeLetterISORegionName,
                CurrencyEnglishName = info.CurrencyEnglishName,
                CurrencyNativeName = info.CurrencyNativeName,
                CurrencySymbol = info.CurrencySymbol,
                DisplayName = info.DisplayName,
                EnglishName = info.EnglishName,
                GeoId = info.GeoId,
                ISOCurrencySymbol = info.ISOCurrencySymbol,
                IsMetric = info.IsMetric,
                Name = info.Name,
                NativeName = info.NativeName,
                ThreeLetterISORegionName = info.ThreeLetterISORegionName,
                ThreeLetterWindowsRegionName = info.ThreeLetterWindowsRegionName,
                TwoLetterISORegionName = info.TwoLetterISORegionName
            };
        }



        /// <summary>
        /// To the culture.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <returns>Culture.</returns>
        public static Culture ToCulture(this CultureInfo info)
        {
            return new Culture()
            {
                Id = info.IetfLanguageTag,
                ThreeLetterWindowsLanguageName = info.ThreeLetterWindowsLanguageName,
                DisplayName = info.DisplayName,
                EnglishName = info.EnglishName,
                IsNeutralCulture = info.IsNeutralCulture,
                LCID = info.LCID,
                NativeName = info.NativeName,
                ParentId = info.Parent.IetfLanguageTag,
                ThreeLetterISOLanguageName = info.ThreeLetterISOLanguageName
            };
        }




    }
}
