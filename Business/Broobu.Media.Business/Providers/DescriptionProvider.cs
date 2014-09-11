// ***********************************************************************
// Assembly         : Broobu.Media.Business
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-22-2013
// ***********************************************************************
// <copyright file="MediaProvider.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Broobu.Media.Business.Interfaces;
using Iris.Fx.Data;
using Iris.Fx.Domain;
using log4net;

namespace Broobu.Media.Business.Providers
{
    /// <summary>
    /// Class MediaProvider.
    /// </summary>
    public class DescriptionProvider : ProviderBase<DescriptionItem>, IDescriptionProvider
    {
        /// <summary>
        /// The _logger
        /// </summary>
        private readonly ILog _logger = LogManager.GetLogger(typeof(DescriptionProvider));


        /// <summary>
        /// Gets the description item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>DescriptionItem.</returns>
        public DescriptionItem GetDescriptionItem(string id)
        {
            return GetById(id);
        }

        /// <summary>
        /// Gets the description items.
        /// </summary>
        /// <returns>DescriptionItem[][].</returns>
        public DescriptionItem[] GetDescriptionItems()
        {
            return GetAll();
        }

        /// <summary>
        /// Gets the description items for object.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>DescriptionItem[][].</returns>
        public DescriptionItem[] GetDescriptionItemsForObject(string objectId)
        {
            return new DescriptionItem[] {};
        }

        /// <summary>
        /// Gets the type of the description items for.
        /// </summary>
        /// <param name="typeId">The type id.</param>
        /// <returns>DescriptionItem[][].</returns>
        public DescriptionItem[] GetDescriptionItemsForType(string typeId)
        {
            return new DescriptionItem[] {};
        }

        /// <summary>
        /// Gets the description items for culture.
        /// </summary>
        /// <param name="cultureId">The culture id.</param>
        /// <returns>DescriptionItem[][].</returns>
        public DescriptionItem[] GetDescriptionItemsForCulture(string cultureId)
        {
            return new DescriptionItem[] {};
        }

        /// <summary>
        /// Gets the description items for object and culture.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <param name="cultureId">The culture id.</param>
        /// <returns>DescriptionItem[][].</returns>
        public DescriptionItem[] GetDescriptionItemsForObjectAndCulture(string objectId, string cultureId)
        {
            return new DescriptionItem[] {};
        }

        /// <summary>
        /// Gets the type of the description items for object and.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <param name="typeId">The type id.</param>
        /// <returns>DescriptionItem[][].</returns>
        public DescriptionItem[] GetDescriptionItemsForObjectAndType(string objectId, string typeId)
        {
            return new DescriptionItem[] {};
        }

        /// <summary>
        /// Gets the type of the description items for object culture and.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <param name="cultureId">The culture id.</param>
        /// <param name="typeId">The type id.</param>
        /// <returns>DescriptionItem[][].</returns>
        public DescriptionItem[] GetDescriptionItemsForObjectCultureAndType(string objectId, string cultureId, string typeId)
        {
            return new DescriptionItem[] {};
        }

        /// <summary>
        /// Gets the type of the description items for culture and.
        /// </summary>
        /// <param name="cultureId">The culture id.</param>
        /// <param name="typeId">The type id.</param>
        /// <returns>DescriptionItem[][].</returns>
        public DescriptionItem[] GetDescriptionItemsForCultureAndType(string cultureId, string typeId)
        {
            return new DescriptionItem[] {};
        }

        /// <summary>
        /// Gets the description items like title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>DescriptionItem[][].</returns>
        public DescriptionItem[] GetDescriptionItemsLikeTitle(string title)
        {
            return new DescriptionItem[] {};
        }

        /// <summary>
        /// Saves the description item.
        /// </summary>
        /// <param name="descriptionItem">The description item.</param>
        /// <returns>DescriptionItem.</returns>
        public DescriptionItem SaveDescription(DescriptionItem descriptionItem)
        {
            return Save(descriptionItem);
        }

        /// <summary>
        /// Deletes the description.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns>DescriptionItem.</returns>
        public DescriptionItem DeleteDescription(DescriptionItem description)
        {
            return Delete(description);
        }

        /// <summary>
        /// Saves the descriptions.
        /// </summary>
        /// <param name="descriptions">The descriptions.</param>
        /// <returns>DescriptionItem[][].</returns>
        public DescriptionItem[] SaveDescriptions(DescriptionItem[] descriptions)
        {
            return Save(descriptions);
        }

        /// <summary>
        /// Registers the domain objects.
        /// </summary>
        public void RegisterDomainObjects()
        {
            
        }

        /// <summary>
        /// Deletes the description item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>DescriptionItem.</returns>
        public DescriptionItem DeleteDescription(string id)
        {
            return Delete(id);
        }

    }
}
