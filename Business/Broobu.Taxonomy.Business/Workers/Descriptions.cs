// ***********************************************************************
// Assembly         : Broobu.Media.Business
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 05-02-2014
// ***********************************************************************
// <copyright file="MediaProvider.cs" company="Broobu">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using Broobu.Taxonomy.Business.Interfaces;
using Broobu.Taxonomy.Contract.Domain;
using Wulka.Data;
using Wulka.Domain;
using NLog;


namespace Broobu.Taxonomy.Business.Workers
{
    /// <summary>
    /// Class MediaProvider.
    /// </summary>
    public class Descriptions :  IDescriptions
    {
        /// <summary>
        /// The _logger
        /// </summary>
        /// <value>The logger.</value>

        private static Logger Logger
        {
            get
            {
                return LogManager.GetCurrentClassLogger();
            }
        }



        /// <summary>
        /// Gets the description item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>Description.</returns>
        public Description GetDescription(string id)
        {
            return Provider<Description>.GetById(id);
        }

        /// <summary>
        /// Gets the description items.
        /// </summary>
        /// <returns>Description[][].</returns>
        public Description[] GetDescriptions()
        {
            return Provider<Description>.GetAll();
        }

        /// <summary>
        /// Gets the description items for object.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <param name="displayName"></param>
        /// <returns>Description[][].</returns>
        public Description[] GetDescriptionsForObject(string objectId, string displayName)
        {
           var req = new WhereRequest() {Field="ObjectId", Value = objectId};
           var res = Provider<Description>
               .Where(req);
            if(res.Length==0)
            {
               res=TaxonomyDomainGenerator.InflateDefaultDescriptions(objectId, displayName);
            }
            return res;
        }

       

       

        /// <summary>
        /// Gets the type of the description items for.
        /// </summary>
        /// <param name="typeId">The type id.</param>
        /// <returns>Description[][].</returns>
        public Description[] GetDescriptionsForType(string typeId)
        {
            var req = new WhereRequest() { Field = "TypeId", Value = typeId };
            return Provider<Description>.Where(req);
        }

        /// <summary>
        /// Gets the description items for culture.
        /// </summary>
        /// <param name="cultureId">The culture id.</param>
        /// <returns>Description[][].</returns>
        public Description[] GetDescriptionsForCulture(string cultureId)
        {
            var req = new WhereRequest() { Field = "CultureId", Value = cultureId};
            return Provider<Description>.Where(req);
        }

        /// <summary>
        /// Gets the description items for object and culture.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <param name="cultureId">The culture id.</param>
        /// <returns>Description[][].</returns>
        public Description[] GetDescriptionsForObjectAndCulture(string objectId, string cultureId)
        {
            var req = new RequestBase() 
            { 
                Function = String.Format("if(doc.ObjectId=='{0}' && doc.CultureId=='{1}') emit(doc.Id,doc)", objectId, cultureId),
                KeyField = "Id"
            };
            return Provider<Description>.Query(req);
        }

        /// <summary>
        /// Gets the type of the description items for object and.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <param name="typeId">The type id.</param>
        /// <returns>Description[][].</returns>
        public Description[] GetDescriptionsForObjectAndType(string objectId, string typeId)
        {
            var req = new RequestBase()
            {
                Function = String.Format("if(doc.ObjectId=='{0}' && doc.TypeId=='{1}') emit(doc.Id,doc)", objectId, typeId),
                KeyField = "Id"
            };
            return Provider<Description>.Query(req);
        }

        /// <summary>
        /// Gets the type of the description items for object culture and.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <param name="cultureId">The culture id.</param>
        /// <param name="typeId">The type id.</param>
        /// <returns>Description[][].</returns>
        public Description[] GetDescriptionsForObjectCultureAndType(string objectId, string cultureId, string typeId)
        {
            var req = new RequestBase() { 
                KeyField = "Id",
                Function = String.Format("if(doc.ObjectId=='{0}' " +
                                               "&& doc.CultureId=='{1}' " +
                                               "&& doc.TypeId='{2}') emit(doc.Id,doc)", objectId, cultureId, typeId)
            };
            return Provider<Description>.Query(req);
        }

        /// <summary>
        /// Gets the type of the description items for culture and.
        /// </summary>
        /// <param name="cultureId">The culture id.</param>
        /// <param name="typeId">The type id.</param>
        /// <returns>Description[][].</returns>
        public Description[] GetDescriptionsForCultureAndType(string cultureId, string typeId)
        {
            var req = new RequestBase() { 
                KeyField = "Id",
                Function = String.Format("if(doc.CultureId=='{0}' " +
                                               "&& doc.TypeId='{1}') emit(doc.Id,doc)", cultureId, typeId)
            };
            return Provider<Description>.Query(req);
        }

        /// <summary>
        /// Gets the description items like title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>Description[][].</returns>
        public Description[] GetDescriptionsLikeTitle(string title)
        {
            return new Description[] {};
        }

        /// <summary>
        /// Saves the description item.
        /// </summary>
        /// <param name="description">The description item.</param>
        /// <returns>Description.</returns>
        public Description SaveDescription(Description description)
        {
            return Provider<Description>.Save(description);
        }

        /// <summary>
        /// Deletes the description.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns>Description.</returns>
        public Description DeleteDescription(Description description)
        {
            return Provider<Description>.Delete(description);
        }

        /// <summary>
        /// Saves the descriptions.
        /// </summary>
        /// <param name="descriptions">The descriptions.</param>
        /// <returns>Description[][].</returns>
        public Description[] SaveDescriptions(Description[] descriptions)
        {
            return Provider<Description>.Save(descriptions);
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
        /// <returns>Description.</returns>
        public Description DeleteDescription(string id)
        {
            return Provider<Description>.Delete(id);
        }

    }
}
