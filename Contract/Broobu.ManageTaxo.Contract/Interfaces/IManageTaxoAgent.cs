// ***********************************************************************
// Assembly         : Broobu.ManageTaxo.Contract
// Author           : Rafael Lefever
// Created          : 05-01-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 05-02-2014
// ***********************************************************************
// <copyright file="IManageTaxoAgent.cs" company="Insoft">
//     Copyright (c) Insoft. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Broobu.Fx.UI.MVVM;
using Broobu.ManageTaxo.Contract.Domain;
using Broobu.Taxonomy.Contract.Domain;

namespace Broobu.ManageTaxo.Contract.Interfaces
{
    /// <summary>
    /// Interface IManageTaxoAgent
    /// </summary>
    public interface IManageTaxoAgent : IManageTaxo
    {
        /// <summary>
        /// Gets the translations for object asynchronous.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="act">The act.</param>
        /// <param name="descriptionType">Type of the description.</param>
        void GetTranslationsForObjectAsync(HookItem filter,  Action<DescriptionItem[]> act);
        /// <summary>
        /// Gets the description types asynchronous.
        /// </summary>
        /// <param name="act">The act.</param>
        void GetDescriptionTypesAsync(Action<DescriptionItem[]> act);

        /// <summary>
        /// Gets the enumeration items asynchronous.
        /// </summary>
        /// <param name="root">The root.</param>
        /// <param name="act">The act.</param>
        void GetHookItemsAsync(HookItem root, Action<HookItem[]> act);


        /// <summary>
        /// Gets the hook asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="action">The action.</param>
        void GetHookAsync(string id, Action<Hook> action);


        /// <summary>
        /// Gets the description asynchronous.
        /// </summary>
        /// <param name="item">The document message.</param>
        /// <param name="action">The action.</param>
        void GetDescriptionAsync(DescriptionItem item, Action<Description> action);
    }
}