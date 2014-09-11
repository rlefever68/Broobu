// ***********************************************************************
// Assembly         : Broobu.EcoSpace.Contract
// Author           : Rafael Lefever
// Created          : 07-20-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-24-2014
// ***********************************************************************
// <copyright file="Page.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Broobu.EcoSpace.Contract.Domain.Default;
using Broobu.EcoSpace.Contract.Properties;
using Broobu.Taxonomy.Contract;
using Wulka.Domain;
using Wulka.Domain.Interfaces;
using Wulka.Interfaces;
using Wulka.Validation;

namespace Broobu.EcoSpace.Contract.Domain.Menu
{
    /// <summary>
    /// Class Page.
    /// </summary>
    [DataContract]
    public class Page : MenuItem, IPage
    {


        protected override Type GetTaxoFactoryType()
        {
            return typeof(TaxonomyPortal);
        }



        /// <summary>
        /// The _default page group
        /// </summary>
        private IPageGroup _defaultPageGroup;

        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<Page>.Validate(this,columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<Page>.Validate(this);
        }

        /// <summary>
        /// Adds the part.
        /// </summary>
        /// <param name="part">The part.</param>
        /// <returns>IDomainObject.</returns>
        /// <exception cref="System.Exception">Pages may only contain Page Groups</exception>
        public override IDomainObject AddPart(IDomainObject part)
        {
            if (part is IPageGroup)
                return base.AddPart(part);
            throw new Exception("Pages may only contain Page Groups");
        }


        /// <summary>
        /// Adds the page group.
        /// </summary>
        /// <param name="pageGroup">The page group.</param>
        /// <returns>IDomainObject.</returns>
        public IDomainObject AddPageGroup(IPageGroup pageGroup)
        {
            if (pageGroup is DefaultPageGroup) return null;
            return AddPart(pageGroup);
        }

        /// <summary>
        /// Gets the default page group.
        /// </summary>
        /// <value>The default page group.</value>
        public IPageGroup DefaultPageGroup
        {
            get 
            { 
                if(Parts.OfType<DefaultPageGroup>().Any())
                {
                    return Parts.OfType<DefaultPageGroup>().First();
                }
                _defaultPageGroup = new DefaultPageGroup();
                AddPart(_defaultPageGroup);
                return _defaultPageGroup;
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Page"/> class.
        /// </summary>
        public Page()
        {
            Icon = Resources.MenuPage;
        }


        /// <summary>
        /// Adds the default page group button.
        /// </summary>
        /// <param name="button">The button.</param>
        /// <returns>IDomainObject.</returns>
        public IDomainObject AddDefaultPageGroupButton(IMenuButton button)
        {
            return DefaultPageGroup.AddPart(button);
        }
    }
}