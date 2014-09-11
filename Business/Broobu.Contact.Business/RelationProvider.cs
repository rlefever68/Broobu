// ***********************************************************************
// Assembly         : Iris.Contact.Business
// Author           : rlefever
// Created          : 11-25-2013
//
// Last Modified By : rlefever
// Last Modified On : 11-25-2013
// ***********************************************************************
// <copyright file="RelationProvider.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Broobu.Contact.Business.Interfaces;
using Broobu.Contact.Contract.Domain;
using Iris.Fx.Data;

namespace Broobu.Contact.Business
{
    /// <summary>
    /// Class RelationProvider.
    /// </summary>
    public class RelationProvider :  IRelationProvider
    {
        /// <summary>
        /// Gets the relation item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>RelationItem.</returns>
        public Relation GetRelationItem(string id)
        {
            return Provider<Relation>.GetById(id);
        }

        /// <summary>
        /// Gets the relation items.
        /// </summary>
        /// <returns>RelationItem[][].</returns>
        public Relation[] GetRelationItems()
        {
            return Provider<Relation>.GetAll();
        }

        /// <summary>
        /// Saves the relation item.
        /// </summary>
        /// <param name="relationItem">The relation item.</param>
        /// <returns>RelationItem.</returns>
        public Relation SaveRelationItem(Relation relationItem)
        {
            return Provider<Relation>.Save(relationItem);
        }

        /// <summary>
        /// Registers the required objects.
        /// </summary>
        public void RegisterRequiredObjects()
        {
            
        }
    }
}