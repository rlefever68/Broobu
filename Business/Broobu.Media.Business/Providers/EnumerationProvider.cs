// ***********************************************************************
// Assembly         : Broobu.Media.Business
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-22-2013
// ***********************************************************************
// <copyright file="EnumerationProvider.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Broobu.Media.Business.Interfaces;
using Broobu.Media.Contract.Domain;
using Iris.Fx.Data;
using Iris.Fx.Domain;

namespace Broobu.Media.Business.Providers
{
    /// <summary>
    /// Class EnumerationProvider.
    /// </summary>
    public class EnumerationProvider : ProviderBase<EnumerationItem>, IEnumerationProvider
    {
        public EnumerationItem RegisterEnumerationType(EnumerationItem item)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the type of the enumeration items for.
        /// </summary>
        /// <param name="baseTypeMedia">The base type media.</param>
        /// <returns>EnumerationItem[][].</returns>
        public EnumerationItem[] GetEnumerationItemsForType(string baseTypeMedia)
        {
            return Where("TypeId", baseTypeMedia);
        }

        /// <summary>
        /// Saves the enumerations.
        /// </summary>
        /// <param name="enums">The enums.</param>
        /// <returns>EnumerationItem[][].</returns>
        public EnumerationItem[] SaveEnumerations(EnumerationItem[] enums)
        {
            return Save(enums);
        }

        public EnumerationItem[] DeleteEnumerations(EnumerationItem[] enums)
        {
            throw new System.NotImplementedException();
        }

        public EnumerationItem DeleteEnumerationItem(EnumerationItem item)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Registers the required domain objects.
        /// </summary>
        public void RegisterRequiredDomainObjects()
        {
            var items = MediaDomainGenerator.CreateEnumerationDefaults();
            Save(items);
        }
    }
}