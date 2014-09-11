// ***********************************************************************
// Assembly         : Broobu.Taxonomy.Business
// Author           : Rafael Lefever
// Created          : 12-24-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-19-2014
// ***********************************************************************
// <copyright file="LinkProvider.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
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
using Wulka.Domain.Interfaces;
using Wulka.Extensions;



namespace Broobu.Taxonomy.Business.Workers
{
    /// <summary>
    /// Class RelationProviderBase.
    /// </summary>
    public class Links : ILinks
    {
        /// <summary>
        /// Activates the specified link.
        /// </summary>
        /// <param name="link">The link.</param>
        /// <returns>ILink.</returns>
        public ILink Activate(ILink link)
        {
            var res = Find(link);
            var s = res == null 
                ? link.Zip() 
                : res.Zip();
            var theLink = s.Unzip<Link>();
            theLink.IsActive = true;
            return Provider<Link>.Save(theLink);
        }


        /// <summary>
        /// Finds the specified link.
        /// </summary>
        /// <param name="link">The link.</param>
        /// <returns>ILink.</returns>
        private ILink Find(ILink link)
        {
            var req = new RequestBase() 
            { 
                Function = String.Format("if(doc.SourceId=='{0}' " +
                                         "&& doc.TargetId=='{1}' " +
                                         "&& doc.RelationType=='{2}') emit(doc.Id,doc)",
                                         link.SourceId,
                                         link.TargetId,
                                         link.RelationType)
            };
            return Provider<Link>.Query(req).FirstOrDefault();
        }

        /// <summary>
        /// Deactivates the specified link.
        /// </summary>
        /// <param name="link">The link.</param>
        /// <returns>ILink.</returns>
        public ILink Deactivate(ILink link)
        {
            var res = Find(link);
            var s = res == null
                ? link.Zip()
                : res.Zip();
            var theLink = s.Unzip<Link>();
            theLink.IsActive = false;
            return Provider<Link>.Save(theLink);
        }

        /// <summary>
        /// Gets the targets.
        /// </summary>
        /// <param name="link">The link.</param>
        /// <param name="activeOnly">if set to <c>true</c> [active only].</param>
        /// <returns>IEnumerable&lt;ILink&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<ILink> GetTargets(ILink link, bool activeOnly = true)
        {
            var req = new RequestBase()
            {
                Function = String.Format("if(doc.SourceId=='{0}' " +
                                         "&& doc.RelationType=='{1}') emit(doc.Id,doc)",
                                         link.SourceId,
                                         link.RelationType)
            };
            return Provider<Link>.Query(req);
        }

        /// <summary>
        /// Gets the sources.
        /// </summary>
        /// <param name="link">The link.</param>
        /// <param name="activeOnly">if set to <c>true</c> [active only].</param>
        /// <returns>IEnumerable&lt;ILink&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<ILink> GetSources(ILink link, bool activeOnly = true)
        {
            var req = new RequestBase()
            {
                Function = String.Format("if(doc.TargetId=='{0}' " +
                                         "&& doc.RelationType=='{1}') emit(doc.Id,doc)",
                                         link.TargetId,
                                         link.RelationType)
            };
            return Provider<Link>.Query(req);
        }

        /// <summary>
        /// Registers the required domain object.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void RegisterRequiredDomainObject()
        {
        }
    }
}
