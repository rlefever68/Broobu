// ***********************************************************************
// Assembly         : Broobu.EcoSpace.Contract
// Author           : Rafael Lefever
// Created          : 07-19-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-19-2014
// ***********************************************************************
// <copyright file="MenuContainer.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Broobu.Taxonomy.Contract;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Extensions;
using Wulka.Validation;

namespace Broobu.EcoSpace.Contract.Domain.Menu
{
    /// <summary>
    /// Class MenuContainer.
    /// </summary>
    [DataContract]
    public class MenuContainer : Folder, IMenuContainer
    {

        protected override Type GetTaxoFactoryType()
        {
            return typeof(TaxonomyPortal);
        }

        public const string ID = "MENU_CONTAINER";
        public MenuContainer()
        {
            Id = ID;
            DisplayName = "Menus";
        }

        public IEnumerable<IMenuButton> Buttons 
        {
            get { return Parts.OfType<IMenuButton>(); }
        }



        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<MenuContainer>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<MenuContainer>.Validate(this);
        }



        internal MenuContainer Filter(MenuContainer allowed)
        {
            var s = this.Zip();
            var clone = s.Unzip<MenuContainer>();
                foreach (var button in Buttons)
                {
                    button.IsAllowed = allowed.ContainsButton(button);
                }
            return clone;
        }

        private bool ContainsButton(IMenuButton button)
        {
            return Parts.Contains(button);
        }

        public void AddMenuButton(IMenuButton target)
        {
            AddPart(target);
        }
    }
}
