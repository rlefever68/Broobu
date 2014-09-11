// ***********************************************************************
// Assembly         : Broobu.EcoSpace.Contract
// Author           : Rafael Lefever
// Created          : 07-19-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-16-2014
// ***********************************************************************
// <copyright file="AccountPointer.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Broobu.EcoSpace.Contract.Properties;
using Broobu.Taxonomy.Contract;
using Broobu.Taxonomy.Contract.Domain;
using Iris.Fx.Domain;
using Iris.Fx.Utils;
using Iris.Fx.Validation;


namespace Broobu.EcoSpace.Contract.Domain.Account
{
    /// <summary>
    /// Class AccountPointer.
    /// </summary>
    [DataContract]
    public class AccountPointer : Link,IAccountPointer
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountPointer"/> class.
        /// </summary>
        public AccountPointer()
        {
            DisplayName = "New Account";
            Icon = Resources.Account;
            TargetId = GuidUtils.NullGuid;
            SourceId = GuidUtils.NullGuid;
            RelationType = Relation;
            IsActive = true;
        }

        public const string Relation = "KnowsAccount";


        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<AccountPointer>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<AccountPointer>.Validate(this);
        }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        [DataMember]
        public string Username { get; set; }


        protected override Type GetTaxoFactoryType()
        {
            return typeof(TaxonomyPortal);
        }

        protected override Type GetSourceFactoryType()
        {
            throw new NotImplementedException();
        }

        protected override Type GetTargetFactoryType()
        {
            throw new NotImplementedException();
        }
    }
}
