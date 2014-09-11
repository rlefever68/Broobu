// ***********************************************************************
// Assembly         : Broobu.Taxonomy.Service
// Author           : Rafael Lefever
// Created          : 12-24-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-19-2014
// ***********************************************************************
// <copyright file="LinkService.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Linq;
using System.ServiceModel;
using Broobu.Taxonomy.Business;
using Broobu.Taxonomy.Contract.Domain;
using Broobu.Taxonomy.Contract.Interfaces;
using Wulka.Extensions;
using Wulka.Networking.Wcf;

namespace Broobu.Taxonomy.Service
{
    /// <summary>
    /// Class RelationService.
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class LinkSentry : SentryBase, ILinkSentry
    {
        /// <summary>
        /// Registers the required domain objects.
        /// </summary>
        protected override void RegisterRequiredDomainObjects()
        {
           
        }

        /// <summary>
        /// Activates the specified link.
        /// </summary>
        /// <param name="link">The link.</param>
        /// <returns>System.String.</returns>
        public string Activate(string link)
        {
            return TaxonomyProvider
                .Links
                .Activate(link.Unzip<Link>())
                .Zip();
        }

        /// <summary>
        /// Deactivates the specified link.
        /// </summary>
        /// <param name="link">The link.</param>
        /// <returns>System.String.</returns>
        public string Deactivate(string link)
        {
            return TaxonomyProvider
                .Links
                .Deactivate(link.Unzip<Link>())
                .Zip();
        }

        /// <summary>
        /// Gets the targets.
        /// </summary>
        /// <param name="link">The link.</param>
        /// <param name="activeOnly">if set to <c>true</c> [active only].</param>
        /// <returns>System.String[].</returns>
        public string[] GetTargets(string link, bool activeOnly = true)
        {
            return TaxonomyProvider
                .Links
                .GetTargets(link.Unzip<Link>(), activeOnly)
                .Zip()
                .ToArray();

        }

        /// <summary>
        /// Gets the sources.
        /// </summary>
        /// <param name="link">The link.</param>
        /// <param name="activeOnly">if set to <c>true</c> [active only].</param>
        /// <returns>System.String[].</returns>
        public string[] GetSources(string link, bool activeOnly = true)
        {
            return TaxonomyProvider
                .Links
                .GetSources(link.Unzip<Link>(), activeOnly)
                .Zip()
                .ToArray();
        }
    }
}
