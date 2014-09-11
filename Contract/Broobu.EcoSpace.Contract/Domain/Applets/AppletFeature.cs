// ***********************************************************************
// Assembly         : Broobu.EcoSpace.Contract
// Author           : Rafael Lefever
// Created          : 07-19-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-19-2014
// ***********************************************************************
// <copyright file="AppletFeature.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Interfaces;
using Wulka.Validation;

namespace Broobu.EcoSpace.Contract.Domain.Applets
{
    /// <summary>
    /// Class AppletFeature.
    /// </summary>
    public class AppletFeature : DomainObject<AppletFeature>
    {
        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<AppletFeature>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<AppletFeature>.Validate(this);
        }
    }
}