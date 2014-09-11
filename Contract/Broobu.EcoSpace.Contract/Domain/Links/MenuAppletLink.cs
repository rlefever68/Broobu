// ***********************************************************************
// Assembly         : Broobu.EcoSpace.Contract
// Author           : Rafael Lefever
// Created          : 07-20-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-18-2014
// ***********************************************************************
// <copyright file="MenuAppletLink.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Broobu.Taxonomy.Contract;
using Broobu.Taxonomy.Contract.Domain;
using Wulka.Domain;
using Wulka.Validation;

namespace Broobu.EcoSpace.Contract.Domain.Links
{
    /// <summary>
    /// Class MenuAppletLink.
    /// </summary>
    [DataContract]
    public class MenuAppletLink : Link
    {


        /// <summary>
        /// Gets the type of the taxo factory.
        /// </summary>
        /// <returns>Type.</returns>
        protected override Type GetTaxoFactoryType()
        {
            return typeof(TaxonomyPortal);
        }

        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<MenuAppletLink>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<MenuAppletLink>.Validate(this);
        }

        /// <summary>
        /// Gets the type of the source factory.
        /// </summary>
        /// <returns>Type.</returns>
        protected override Type GetSourceFactoryType()
        {
            return typeof(EcoSpacePortal);
        }

        /// <summary>
        /// Gets the type of the target factory.
        /// </summary>
        /// <returns>Type.</returns>
        protected override Type GetTargetFactoryType()
        {
            return typeof(EcoSpacePortal);
        }
    }
}