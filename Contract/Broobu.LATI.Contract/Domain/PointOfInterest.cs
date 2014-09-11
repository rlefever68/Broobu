// ***********************************************************************
// Assembly         : Broobu.LATI.Contract
// Author           : Rafael Lefever
// Created          : 07-20-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-13-2014
// ***********************************************************************
// <copyright file="PointOfInterest.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Broobu.Taxonomy.Contract;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Validation;

namespace Broobu.LATI.Contract.Domain
{
    /// <summary>
    /// Class PointOfInterest.
    /// </summary>
    [DataContract]
    public class PointOfInterest : TaxonomyObject<PointOfInterest>
    {
        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<PointOfInterest>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<PointOfInterest>.Validate(this);
        }

        /// <summary>
        /// Gets the type of the taxo factory.
        /// </summary>
        /// <returns>Type.</returns>
        protected override Type GetTaxoFactoryType()
        {
            return typeof(TaxonomyPortal);
        }
    }
}
