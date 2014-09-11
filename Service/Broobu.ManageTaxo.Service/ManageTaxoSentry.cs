// ***********************************************************************
// Assembly         : Broobu.ManageTaxo.Service
// Author           : Rafael Lefever
// Created          : 05-01-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 05-06-2014
// ***********************************************************************
// <copyright file="ManageTaxoSentry.cs" company="Insoft">
//     Copyright (c) Insoft. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Broobu.ManageTaxo.Business;
using Broobu.ManageTaxo.Contract.Domain;
using Broobu.ManageTaxo.Contract.Interfaces;
using Broobu.Taxonomy.Contract.Domain;


namespace Broobu.ManageTaxo.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    /// <summary>
    /// Class ManageTaxoSentry.
    /// </summary>
    public class ManageTaxoSentry:IManageTaxo
    {
        /// <summary>
        /// Gets the enumerations.
        /// </summary>
        /// <param name="root">The root.</param>
        /// <returns>DescriptionItem[].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public HookItem[] GetHookItems(HookItem root)
        {
            return ManageTaxoProvider
                .Worker
                .GetHookItems(root);
        }

        /// <summary>
        /// Saves the hook.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>Hook.</returns>
        public Hook SaveHook(Hook document)
        {
            return ManageTaxoProvider
                .Worker
                .SaveHook(document);
        }

        /// <summary>
        /// Deletes the hook.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>Hook.</returns>
        public Hook DeleteHook(Hook document)
        {
            return ManageTaxoProvider
                .Worker
                .DeleteHook(document);
        }

        /// <summary>
        /// Gets the hook.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Hook.</returns>
        public Hook GetHook(string id)
        {
            return ManageTaxoProvider
                .Worker
                .GetHook(id);
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Description.</returns>
        public Description GetDescription(DescriptionItem item)
        {
            return ManageTaxoProvider
                .Worker
                .GetDescription(item);
        }

        /// <summary>
        /// Gets the translations for object.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>DescriptionItem[].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public DescriptionItem[] GetTranslationsForObject(HookItem filter)
        {
            return ManageTaxoProvider
                .Worker
                .GetTranslationsForObject(filter);
        }

        /// <summary>
        /// Gets the description types.
        /// </summary>
        /// <returns>DescriptionItem[].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public DescriptionItem[] GetDescriptionTypes()
        {
            return ManageTaxoProvider
                .Worker
                .GetDescriptionTypes();
        }

        /// <summary>
        /// Deletes the specified document.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>Description.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Description DeleteDescription(Description document)
        {
            return ManageTaxoProvider
                .Worker
                .DeleteDescription(document);
        }

        /// <summary>
        /// Saves the specified document.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>Description.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Description SaveDescription(Description document)
        {
            return ManageTaxoProvider
                .Worker
                .SaveDescription(document);
        }
    }
}
