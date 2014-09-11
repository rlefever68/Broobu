// ***********************************************************************
// Assembly         : Broobu.Media.Business
// Author           : ON8RL
// Created          : 12-22-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-22-2013
// ***********************************************************************
// <copyright file="RelationProvider.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Linq;
using Broobu.Media.Business.Interfaces;
using Broobu.Media.Contract.Domain;
using Iris.Fx.Data;
using Iris.Fx.Domain;


namespace Broobu.Media.Business.Providers
{
    /// <summary>
    /// Class RelationProviderBase.
    /// </summary>
    public class LinkProvider : ProviderBase<LinkItem>, ILinkProvider
    {





        /// <summary>
        /// Links the specified from.
        /// </summary>
        /// <param name="fromItem">From item.</param>
        /// <param name="toItem">To item.</param>
        /// <param name="relationType">Type of the relation.</param>
        /// <returns>RelationItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public LinkItem Link(string fromItem, string toItem, string relationType)
        {
            var res = new LinkItem() 
            {
                RelationFrom = fromItem, 
                RelationTo = toItem, 
                RelationType = relationType
            };
            return Save(res);
        }




        /// <summary>
        /// Uns the link.
        /// </summary>
        /// <param name="fromItem">From item.</param>
        /// <param name="toItem">To.</param>
        /// <param name="relationType">Type of the relation.</param>
        /// <returns>RelationItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public LinkItem UnLink(string fromItem, string toItem, string relationType)
        {
            LinkItem res = null;
            try
            {
                res = Query("doc.RelationType && doc.RelationType=='{0}' " +
                            "&& doc.RelationFrom && doc.RelationFrom=='{1}' " +
                            "&& doc.RelationTo && doc.RelationTo=='{2}'",
                            relationType,
                            fromItem,
                            toItem)
                            .FirstOrDefault();
                if (res != null)
                {
                    return Delete(res);
                }
                res = new LinkItem();
                res.AddError("The relation between both items could not be found.");
                return res;
            }
            catch (Exception exception)
            {
                res.AddError(exception.Message);
                return res;
            }
        }

        /// <summary>
        /// Gets the relations to.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="relationType">Type of the relation.</param>
        /// <returns>RelationItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public LinkItem[] GetRelationsTo(string id, string relationType)
        {
            return Query("doc.RelationType && doc.RelationType=='{0}' " +
                      "&& doc.RelationTo && doc.RelationTo=='{1}'",
                      relationType,
                       id);
        }

        /// <summary>
        /// Gets the relations from.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="relationType">Type of the relation.</param>
        /// <returns>RelationItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public LinkItem[] GetRelationsFrom(string id, string relationType)
        {
            return Query("doc.RelationType && doc.RelationType=='{0}' " +
                      "&& doc.RelationFrom && doc.RelationFrom=='{1}'",
                      relationType,
                      id);
        }

        /// <summary>
        /// Deletes the relations to.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="relationType">Type of the relation.</param>
        /// <returns>RelationItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public LinkItem[] DeleteRelationsTo(string id, string relationType)
        {
            var res = GetRelationsTo(id, relationType);
            return Delete(res);
        }

        /// <summary>
        /// Deletes the get relations from.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="relationType">Type of the relation.</param>
        /// <returns>RelationItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public LinkItem[] DeleteRelationsFrom(string id, string relationType)
        {
            var res = GetRelationsFrom(id, relationType);
            return Delete(res);
        }

        /// <summary>
        /// Registers the required domain object.
        /// </summary>
        public void RegisterRequiredDomainObject()
        {
           
        }
    }
}
