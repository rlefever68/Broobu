// ***********************************************************************
// Assembly         : Broobu.Taxonomy.Contract
// Author           : Rafael Lefever
// Created          : 01-09-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-12-2014
// ***********************************************************************
// <copyright file="GraphWriter.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel.Composition;
using Broobu.Taxonomy.Contract.Domain;
using Broobu.Taxonomy.Contract.Interfaces;
using Wulka.Data;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Domain.Interfaces;
using Wulka.Interfaces;

namespace Broobu.Taxonomy.Contract.Parts
{
    /// <summary>
    /// Class Dehydrator.
    /// </summary>
    [Export(typeof(IWriteEvents))]
    public class TaxonomyEvents : IWriteEvents
    {
        /// <summary>
        /// Dehydrates the specified domain object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="domainObject">The domain object.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual void OnSaved<T>(DomainObject<T> domainObject) 
            where T : IDomainObject
        {
            var t = domainObject as ITranslatable;
            if (t != null)
            {
                t.SaveTranslations();
            }
            var hasLinks = domainObject as ILinkable;
            if (hasLinks != null)
            {
                hasLinks.SaveLinks();
            }
        }

        /// <summary>
        /// Deletes the children.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="domainObject">The domain object.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual bool OnDeleting<T>(DomainObject<T> domainObject) 
            where T : IDomainObject
        {
            return true;
        }


        /// <summary>
        /// Called when [saving].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="domainObject">The domain object.</param>
        public virtual bool OnSaving<T>(DomainObject<T> domainObject) 
            where T : IDomainObject
        {
            var obj = domainObject as ITaxonomyObject;
            if (obj == null) return true;
            try
            {
                obj.HookId = GetHookId(obj);
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        /// <summary>
        /// Gets the hook identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="obj">the domain object for which we are retrieving  the Hook</param>
        /// <returns>System.String.</returns>
        private static string GetHookId(IDomainObject obj)
        {
            return TaxonomyPortal
                .Hooks
                .GetTaxonomyHookId(obj.Id, obj.DisplayName, obj.ParentId);
        }

        /// <summary>
        /// Called when [deleted].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="domainObject">The domain object.</param>
        public virtual void OnDeleted<T>(DomainObject<T> domainObject) 
            where T : IDomainObject
        {
           
        }
    }
}
