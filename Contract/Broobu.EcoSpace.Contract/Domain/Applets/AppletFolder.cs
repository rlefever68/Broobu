// ***********************************************************************
// Assembly         : Broobu.EcoSpace.Contract
// Author           : Rafael Lefever
// Created          : 07-19-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-19-2014
// ***********************************************************************
// <copyright file="AppletFolder.cs" company="Broobu">
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

namespace Broobu.EcoSpace.Contract.Domain.Applets
{

    /// <summary>
    /// Class AppletFolder.
    /// </summary>
    [DataContract]
    public class AppletFolder : Folder
    {


        public AppletFolder()
        {
            Icon = Properties.Resources.Folder;
        }


        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<AppletFolder>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<AppletFolder>.Validate(this);
        }

        protected override Type GetTaxoFactoryType()
        {
            return typeof(TaxonomyPortal);
        }
    }
}
