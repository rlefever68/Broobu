// ***********************************************************************
// Assembly         : Broobu.EcoSpace.Contract
// Author           : Rafael Lefever
// Created          : 07-19-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-20-2014
// ***********************************************************************
// <copyright file="CloudRolesFolder.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Runtime.Serialization;
using Broobu.EcoSpace.Contract.Properties;
using Wulka.Domain;
using Wulka.Domain.Interfaces;
using Wulka.Validation;

namespace Broobu.EcoSpace.Contract.Domain.Roles
{
    /// <summary>
    /// Class CloudRolesFolder.
    /// </summary>
    [DataContract]
    public class OrganizationsFolder : RoleFolder
    {
        public const string ID = "ORGANIZATION_ROLE_FOLDER";
        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationsFolder"/> class.
        /// </summary>
        public OrganizationsFolder()
        {
            Id = ID;
            DisplayName = "Organizations";
        }

        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<OrganizationsFolder>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<OrganizationsFolder>.Validate(this);
        }


        protected override Wulka.Domain.Interfaces.IDomainObject CreateChild()
        {
            return new Organization();
        }

    }
}