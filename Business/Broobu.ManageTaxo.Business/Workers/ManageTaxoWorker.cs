// ***********************************************************************
// Assembly         : Broobu.ManageTaxo.Business
// Author           : Rafael Lefever
// Created          : 05-01-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 05-02-2014
// ***********************************************************************
// <copyright file="ManageTaxoWorker.cs" company="Insoft">
//     Copyright (c) Insoft. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Broobu.ManageTaxo.Contract.Domain;
using Broobu.ManageTaxo.Contract.Interfaces;
using Broobu.Taxonomy.Contract;
using Broobu.Taxonomy.Contract.Constants;
using Broobu.Taxonomy.Contract.Domain;
using Iris.Fx.Data;
using Iris.Fx.Domain;

namespace Broobu.ManageTaxo.Business.Workers
{
    /// <summary>
    /// Class ManageTaxoWorker.
    /// </summary>
    class ManageTaxoWorker : IManageTaxo
    {
        /// <summary>
        /// Gets the enumerations.
        /// </summary>
        /// <param name="root">The root.</param>
        /// <returns>DescriptionItem[].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public HookItem[] GetEnumerations(HookItem root)
        {
            return TaxonomyPortal
                .Hooks
                .GetEnumerationsForType(root.TypeId)
                .ToEnumerationItem();
        }

        /// <summary>
        /// Gets the translations for object.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="descriptionType">Type of the description.</param>
        /// <returns>DescriptionItem[].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public DescriptionItem[] GetTranslationsForObject(HookItem filter)
        {
            return TaxonomyPortal
                .Descriptions
                .GetDescriptionsForObject(filter.Id,filter.DisplayName)
                .ToDescriptionItem();
        }

        /// <summary>
        /// Gets the description types.
        /// </summary>
        /// <returns>DescriptionItem[].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        /// <exception cref="NotImplementedException"></exception>
        public DescriptionItem[] GetDescriptionTypes()
        {
            var res = TaxonomyPortal
                .Hooks
                .GetChildren(new Hook() { Id = HookConst.DescriptionTypeEnum }, true);
            return res.ToDescriptionItem();
        }

        /// <summary>
        /// Deletes the specified document.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>Description.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Description DeleteDescription(Description document)
        {
            return TaxonomyPortal
                .Descriptions
                .DeleteDescription(document);
        }

        /// <summary>
        /// Gets the hook items.
        /// </summary>
        /// <param name="root">The root.</param>
        /// <returns>HookItem[].</returns>
        /// <exception cref="NotImplementedException"></exception>
        public HookItem[] GetHookItems(HookItem root)
        {
            Hook[] res = TaxonomyPortal
                .Hooks
                .GetChildren(root.ToHook());
            return res.ToHookItem();
        }

        /// <summary>
        /// Saves the hook.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>Hook.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        /// <exception cref="NotImplementedException"></exception>
        public Hook SaveHook(Hook document)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the hook.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>Hook.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        /// <exception cref="NotImplementedException"></exception>
        public Hook DeleteHook(Hook document)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the hook.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Hook.</returns>
        public Hook GetHook(string id)
        {
            return TaxonomyPortal
                .Hooks
                .GetById(id);
        }

        public Description GetDescription(DescriptionItem item)
        {
            return TaxonomyPortal
                .Descriptions
                .GetDescription(item.Id);
        }


        /// <summary>
        /// Saves the specified document.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>Description.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Description SaveDescription(Description document)
        {
            return TaxonomyPortal
                .Descriptions
                .SaveDescription(document);
        }
    }
}
