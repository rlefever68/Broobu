// ***********************************************************************
// Assembly         : Iris.Contact.Contract
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-20-2013
// ***********************************************************************
// <copyright file="ContactDomainGenerator.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Broobu.Taxonomy.Contract.Domain;
using log4net;

namespace Broobu.Contact.Contract.Domain
{
    /// <summary>
    /// Class ContactDomainGenerator.
    /// </summary>
    public class ContactDomainGenerator
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ContactDomainGenerator));
        /// <summary>
        /// Gets the countries.
        /// </summary>
        /// <returns>List{CountryItem}.</returns>
        public static List<Country> GetCountries()
        {
            // lijst van landen                                         => http://nl.wikipedia.org/wiki/Lijst_van_landen_in_2011
            // landcodes + vertaling ( pagina in het nl )               => http://nl.wikipedia.org/wiki/ISO_3166-1
            // English country names and code elements (iso official)   => http://www.iso.org/iso/iso_3166-1_en_xml.zip
            // French country names and code elements (iso official)    => http://www.iso.org/iso/iso_3166-1_fr_xml.zip

            var countries = new List<Country>() { new Country { Id = Guid.Empty.ToString(), DefaultName = "Unknown", TwoLetterIsoRegionName = String.Empty, ThreeLetterIsoRegionName = String.Empty } };
            var dic = new Dictionary<int, string>();

            foreach (CultureInfo cultureInfo in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                try
                {
                    var regionInfo = new RegionInfo(cultureInfo.LCID);
                    var key = regionInfo.GeoId;

                    if (!dic.ContainsKey(key))
                    {
                        dic.Add(key, regionInfo.Name);
                        var country = new Country
                                          {
                                              Id = new Guid(key, 0, 0, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 }).ToString(),
                                              DefaultName = regionInfo.EnglishName,
                                              TwoLetterIsoRegionName = regionInfo.TwoLetterISORegionName,
                                              ThreeLetterIsoRegionName = regionInfo.ThreeLetterISORegionName
                                          };

                        countries.Add(country);
                        Debug.WriteLine("Country added " + regionInfo);
                    }
                    else
                    {
                        Debug.WriteLine("Country " + regionInfo + " already exists");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return countries;
        }

        /// <summary>
        /// Gets the translated countries.
        /// </summary>
        /// <param name="countries">The countries.</param>
        /// <returns>List{CountryItem}.</returns>
        public static List<Country> GetTranslatedCountries(List<Country> countries)
        {
            var list = new List<Country>();

            if (countries != null)
            {
                var englishCountries = GetCountries();

                foreach (var englishCountry in englishCountries)
                {
                    string twoLetterIsoRegionName = englishCountry.TwoLetterIsoRegionName;
                    var translatedCountry = (from c in countries
                                             where c.TwoLetterIsoRegionName == twoLetterIsoRegionName
                                             select c).FirstOrDefault();

                    if (translatedCountry == null)
                    {
                        Logger.WarnFormat("No translation found for TwoLetterIsoRegionName = '{0}' DefaultName = '{1}'", englishCountry.TwoLetterIsoRegionName, englishCountry.DefaultName);
                        Debug.WriteLine(string.Format("No translation found for TwoLetterIsoRegionName = '{0}' DefaultName = '{1}'", englishCountry.TwoLetterIsoRegionName, englishCountry.DefaultName));
                    }
                    else
                    {
                        list.Add(new Country
                                     {
                                         Id = englishCountry.Id,
                                         TwoLetterIsoRegionName = englishCountry.TwoLetterIsoRegionName,
                                         ThreeLetterIsoRegionName = englishCountry.ThreeLetterIsoRegionName,
                                         DefaultName = translatedCountry.DefaultName
                                     });
                    }
                }
            }

            return list;
        }
    }
}
