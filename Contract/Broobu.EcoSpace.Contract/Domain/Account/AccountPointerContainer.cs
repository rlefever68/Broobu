// ***********************************************************************
// Assembly         : Broobu.EcoSpace.Contract
// Author           : Rafael Lefever
// Created          : 07-20-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-11-2014
// ***********************************************************************
// <copyright file="AccountPointerContainer.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using Broobu.Taxonomy.Contract;
using Iris.Fx.Domain;
using Iris.Fx.Validation;

namespace Broobu.EcoSpace.Contract.Domain.Account
{
    /// <summary>
    /// Class AccountPointerContainer.
    /// </summary>
    public class AccountPointerContainer : Folder, IAccountPointerContainer
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
        /// Gets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        public IEnumerable<IAccountPointer> Accounts
        {
            get { return Parts.OfType<IAccountPointer>(); }
        }

        /// <summary>
        /// Adds the account pointer.
        /// </summary>
        /// <param name="pointer">The pointer.</param>
        /// <returns>IAccountPointer.</returns>
        public IAccountPointer AddAccountPointer(IAccountPointer pointer)
        {
            return AddPart(pointer) as IAccountPointer;
        }

        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<AccountPointerContainer>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<AccountPointerContainer>.Validate(this);
        }

        /// <summary>
        /// The identifier
        /// </summary>
        public const string ID = "ACCOUNT_POINTER_CONTAINER";
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountPointerContainer"/> class.
        /// </summary>
        public AccountPointerContainer()
        {
            Id = ID;
            DisplayName = "Account Pointers";
        }







    }
}
