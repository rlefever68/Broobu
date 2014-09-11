// ***********************************************************************
// Assembly         : Broobu.EcoSpace.Contract
// Author           : Rafael Lefever
// Created          : 07-19-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-19-2014
// ***********************************************************************
// <copyright file="MenuCategory.cs" company="Broobu">
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
    /// Class MenuCategory.
    /// </summary>
    [DataContract]
    public class PageGroup : MenuItem, IPageGroup
    {

        protected override Type GetTaxoFactoryType()
        {
            return typeof(TaxonomyPortal);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageGroup"/> class.
        /// </summary>
        public PageGroup()
        {
            Icon = Resources.MenuCategory;
            DisplayName = "New Page Group";
        }


        public override IDomainObject AddPart(IDomainObject part)
        {
            if(part is IMenuButton)
                return base.AddPart(part);
            throw new Exception("Page Groups may only contain Menu Buttons");
        }


        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<PageGroup>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<PageGroup>.Validate(this);
        }
    }
}