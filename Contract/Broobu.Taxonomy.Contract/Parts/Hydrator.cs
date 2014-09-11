// ***********************************************************************
// Assembly         : Broobu.Taxonomy.Contract
// Author           : Rafael Lefever
// Created          : 01-09-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-09-2014
// ***********************************************************************
// <copyright file="Hydrator.cs" company="Broobu Systems Ltd.">
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
    /// Class Hydrator.
    /// </summary>
    [Export(typeof(IHydrate))]
    public class Hydrator : IHydrate
    {
        /// <summary>
        /// Hydrates the specified domain object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="domainObject">The domain object.</param>
        public virtual void Hydrate<T>(DomainObject<T> domainObject) 
            where T : IDomainObject
        {
            var l = (ILinkable)domainObject;
            if (l == null) return;
            try
            {
                l.HydrateLinks();
            }
            catch (Exception exception)
            {
                domainObject.AddError(exception.Message);
            }


            //var t = domainObject as ITranslatable;
            //if(t != null)
            //    t.HydrateTranslations();
        }
    }

}
