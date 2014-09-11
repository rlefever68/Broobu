// ***********************************************************************
// Assembly         : Broobu.EcoSpace.Contract
// Author           : Rafael Lefever
// Created          : 07-20-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-24-2014
// ***********************************************************************
// <copyright file="PageCategory.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Broobu.EcoSpace.Contract.Properties;
using Broobu.Taxonomy.Contract;
using Wulka.Domain;
using Wulka.Domain.Interfaces;
using Wulka.Interfaces;
using Wulka.Validation;

namespace Broobu.EcoSpace.Contract.Domain.Menu
{
    /// <summary>
    /// Class PageCategory.
    /// </summary>
    [DataContract]
    public class PageCategory : MenuItem, IPageCategory
    {

        protected override Type GetTaxoFactoryType()
        {
            return typeof(TaxonomyPortal);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageCategory"/> class.
        /// </summary>
        public PageCategory()
        {
            DisplayName = "New Page Category";
            Icon = Resources.PageCategory;
        }


        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<PageCategory>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<PageCategory>.Validate(this);
        }

        /// <summary>
        /// Adds the part.
        /// </summary>
        /// <param name="part">The part.</param>
        /// <returns>IDomainObject.</returns>
        /// <exception cref="System.Exception">Page Categories may only contain Pages</exception>
        public override IDomainObject AddPart(IDomainObject part)
        {
            if(part is IPage)
                return base.AddPart(part);
            throw new Exception("Page Categories may only contain Pages");
        }


        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string GetDisplayName()
        {
            return base.GetDisplayName().ToUpper();
        }
    }
}