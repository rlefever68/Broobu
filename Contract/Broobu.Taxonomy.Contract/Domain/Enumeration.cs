// ***********************************************************************
// Assembly         : Broobu.ManageTaxo.Contract
// Author           : Rafael Lefever
// Created          : 12-24-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-19-2014
// ***********************************************************************
// <copyright file="EnumerationInfo.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Validation;

namespace Broobu.Taxonomy.Contract.Domain
{
    /// <summary>
    /// Class EnumerationInfo.
    /// </summary>
    [DataContract]
    public class Enumeration : TaxonomyObject<Enumeration>
    {
        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>The sort order.</value>
        [DataMember]
        public int SortOrder { get; set; }


        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<Enumeration>.Validate(this, columnName);
        }

        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<Enumeration>.Validate(this);
        }

        protected override Type GetTaxoFactoryType()
        {
            return typeof(TaxonomyPortal);
        }
    }
}