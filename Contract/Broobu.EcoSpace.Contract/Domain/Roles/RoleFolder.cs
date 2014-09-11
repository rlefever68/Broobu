// ***********************************************************************
// Assembly         : Broobu.EcoSpace.Contract
// Author           : Rafael Lefever
// Created          : 07-19-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-19-2014
// ***********************************************************************
// <copyright file="RoleFolder.cs" company="Broobu">
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
using Wulka.Domain.Base;
using Wulka.Domain.Interfaces;
using Wulka.Validation;

namespace Broobu.EcoSpace.Contract.Domain.Roles
{
    /// <summary>
    /// Class RoleFolder.
    /// </summary>
    [DataContract]
    public class RoleFolder : Folder
    {

        protected override IDomainObject CreateFolder()
        {
            return new RoleFolder() { DisplayName = "New Role Folder" };
        }


        protected override IDomainObject CreateChild()
        {
            return new Role() { DisplayName = "New Role" };
        }


        protected override Type GetTaxoFactoryType()
        {
            return typeof(TaxonomyPortal);
        }

        public RoleFolder()
        {
            Icon = Resources.Folder;
        }
        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<RoleFolder>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<RoleFolder>.Validate(this);
        }

    }
}
