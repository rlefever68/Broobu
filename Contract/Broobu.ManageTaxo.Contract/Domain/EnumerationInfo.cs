// ***********************************************************************
// Assembly         : Broobu.ManageTaxo.Contract
// Author           : Rafael Lefever
// Created          : 12-24-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 12-24-2013
// ***********************************************************************
// <copyright file="EnumerationInfo.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Runtime.Serialization;
using Iris.Fx.Domain;
using Iris.Fx.Validation;

namespace Broobu.ManageTaxo.Contract.Domain
{
    /// <summary>
    /// Class EnumerationInfo.
    /// </summary>
    [DataContract]
    public class EnumerationInfo : DomainObject<EnumerationInfo>
    {
        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<EnumerationInfo>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection{System.String}.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<EnumerationInfo>.Validate(this);
        }
    }
}