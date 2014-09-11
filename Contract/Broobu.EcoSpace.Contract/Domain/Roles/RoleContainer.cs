// ***********************************************************************
// Assembly         : Broobu.EcoSpace.Contract
// Author           : Rafael Lefever
// Created          : 07-19-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-13-2014
// ***********************************************************************
// <copyright file="RoleContainer.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Broobu.Taxonomy.Contract;
using DevExpress.Mvvm;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Domain.Interfaces;
using Wulka.Validation;

namespace Broobu.EcoSpace.Contract.Domain.Roles
{

    /// <summary>
    /// Class RoleContainer.
    /// </summary>
    [DataContract]
    public class RoleContainer : Folder
    {
        /// <summary>
        /// The _selected role
        /// </summary>
        private IRole _selectedRole;

        /// <summary>
        /// Gets or sets the selected role.
        /// </summary>
        /// <value>The selected role.</value>
        public IRole SelectedRole
        {
            get 
            { 
                return _selectedRole; 
            }
            set 
            {
                if (value == null) return;
                _selectedRole = value; 
                RaisePropertyChanged("SelectedRole");
                Messenger.Default.Send(new RoleMvvmMessage() 
                { 
                    Role = _selectedRole 
                });
            }
        }

        /// <summary>
        /// Gets the type of the taxo factory.
        /// </summary>
        /// <returns>Type.</returns>
        protected override Type GetTaxoFactoryType()
        {
            return typeof(TaxonomyPortal);
        }

        /// <summary>
        /// The identifier
        /// </summary>
        public const string ID = "ROLE_CONTAINER";

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleContainer"/> class.
        /// </summary>
        public RoleContainer()
        {
            Id = ID;
            DisplayName = "Roles";
        }


        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <value>The roles.</value>
        public IEnumerable<IRole> Roles 
        {
            get { return Parts.OfType<IRole>(); }
        }


        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<RoleContainer>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<RoleContainer>.Validate(this);
        }

        /// <summary>
        /// Adds the role.
        /// </summary>
        /// <param name="role">The role.</param>
        public void AddRole(IRole role)
        {
            AddPart(role);
        }

        /// <summary>
        /// Determines whether the specified source contains role.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns><c>true</c> if the specified source contains role; otherwise, <c>false</c>.</returns>
        public bool ContainsRole(IRole source)
        {
            return Parts.Contains(source);
        }



        protected override IDomainObject CreateBranch()
        {
            return new RoleFolder() { DisplayName = "New Branch" };
        }





    }
}
