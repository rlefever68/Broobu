// ***********************************************************************
// Assembly         : Iris.Contact.Business
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-23-2013
// ***********************************************************************
// <copyright file="CountryProvider.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Linq;
using Broobu.Contact.Business.Interfaces;
using Broobu.Contact.Contract.Domain;
using Broobu.Taxonomy.Contract;
using Broobu.Taxonomy.Contract.Domain;
using Iris.Fx.Data;

namespace Broobu.Contact.Business
{
    /// <summary>
    /// Class CountryProvider.
    /// </summary>
    class CountryProvider :  ICountryProvider
    {
        /// <summary>
        /// Saves the country item.
        /// </summary>
        /// <param name="countryItem">The country item.</param>
        /// <returns>CountryItem.</returns>
        public Country SaveCountryItem(Country countryItem)
        {
            return Provider<Country>.Save(countryItem);
        }

        /// <summary>
        /// Deletes the country item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>CountryItem.</returns>
        public Country DeleteCountryItem(Country item)
        {
            return Provider<Country>.Delete(item);
        }


        /// <summary>
        /// Gets the country item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>CountryItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Country GetCountryItem(string id)
        {
            return Provider<Country>.GetById(id);
        }

        /// <summary>
        /// Gets the name of the country item by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>CountryItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Country GetCountryItemByName(string name)
        {
            return Provider<Country>.Where("DefaultName", name).FirstOrDefault();
        }

        /// <summary>
        /// Gets the name of the country item by two letter iso region.
        /// </summary>
        /// <param name="twoLetterIsoRegionName">Name of the two letter iso region.</param>
        /// <returns>CountryItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Country GetCountryItemByTwoLetterIsoRegionName(string twoLetterIsoRegionName)
        {
            return Provider<Country>.Where("TwoLetterIsoRegionName", twoLetterIsoRegionName).FirstOrDefault();
        }

        /// <summary>
        /// Gets the name of the country item by three letter iso region.
        /// </summary>
        /// <param name="threeLetterIsoRegionName">Name of the three letter iso region.</param>
        /// <returns>CountryItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Country GetCountryItemByThreeLetterIsoRegionName(string threeLetterIsoRegionName)
        {
            return Provider<Country>.Where("ThreeLetterIsoRegionName", threeLetterIsoRegionName).FirstOrDefault();
        }

        /// <summary>
        /// Gets the country items.
        /// </summary>
        /// <returns>CountryItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Country[] GetCountryItems()
        {
            return Provider<Country>.GetAll();
        }

        /// <summary>
        /// Gets the country items for culture.
        /// </summary>
        /// <param name="cultureName">Name of the culture.</param>
        /// <returns>CountryItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Country[] GetCountryItemsForCulture(string cultureName)
        {
            return Provider<Country>.Where("TwoLetterIsoRegionName", cultureName);
        }

        /// <summary>
        /// Registers the required objects.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void RegisterRequiredObjects()
        {
            var c = ContactBusinessGenerator.GetCountryItems();
            Provider<Country>.Save(c);
            var d = ContactBusinessGenerator.GetCountryDescriptions();
            TaxonomyPortal
                .Descriptions
                .SaveDescriptions(d);

        }
    }
}
