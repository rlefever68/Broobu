// ***********************************************************************
// Assembly         : Broobu.Taxonomy.Business.Test
// Author           : Rafael Lefever
// Created          : 05-24-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 05-24-2014
// ***********************************************************************
// <copyright file="HooksWorkerTestFixture.cs" company="Insoft">
//     Copyright (c) Insoft. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Broobu.Taxonomy.Business.Interfaces;
using Broobu.Taxonomy.Contract.Constants;
using Broobu.Taxonomy.Contract.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Broobu.Taxonomy.Business.Test
{
    /// <summary>
    /// Class HooksWorkerTestFixture.
    /// </summary>
    [TestClass]
    public class HooksWorkerTestFixture : IHooks
    {

        [TestMethod]
        public void Try_InflateDomain()
        {
            var res = InflateDomain();
            foreach (var hook in res)
            {
                Console.WriteLine(hook.ToString());
            }
        }




        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestMethod]
        public void Try_GetHookId()
        {
            var id = GetTaxonomyHookId("TestId", "Test DisplayName", HookConst.EcoSpaceRoot);
            var res = GetById(id);
            Console.WriteLine(res.ToString());
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Hook.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Hook GetById(string id)
        {
            return TaxonomyProvider
                .Hooks
                .GetById(id);
        }

        /// <summary>
        /// Saves the specified it.
        /// </summary>
        /// <param name="it">It.</param>
        /// <returns>Hook.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Hook Save(Hook it)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Registers the type of the enumeration.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Hook.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Hook RegisterEnumerationType(Hook item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the type of the enumerations for.
        /// </summary>
        /// <param name="typeId">The type identifier.</param>
        /// <returns>Hook[].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Hook[] GetEnumerationsForType(string typeId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves the enumerations.
        /// </summary>
        /// <param name="enums">The enums.</param>
        /// <returns>Hook[].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Hook[] SaveEnumerations(Hook[] enums)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the enumerations.
        /// </summary>
        /// <param name="enums">The enums.</param>
        /// <returns>Hook[].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Hook[] DeleteEnumerations(Hook[] enums)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the enumeration.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Hook.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Hook DeleteEnumeration(Hook item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the taxonomy hook identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="displayName">The display name.</param>
        /// <param name="ecoSpace">The eco space.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string GetTaxonomyHookId(string id, string displayName, string ecoSpace)
        {
            return TaxonomyProvider
                .Hooks
                .GetTaxonomyHookId(id, displayName, ecoSpace);
        }

        public Hook GetHook(string id, string displayName, string ecoSpace)
        {
            return TaxonomyProvider
                .Hooks
                .GetHook(id, displayName, ecoSpace);
        }

        /// <summary>
        /// Gets the children.
        /// </summary>
        /// <param name="root">The root.</param>
        /// <param name="hydrate">if set to <c>true</c> [hydrate].</param>
        /// <returns>Hook[].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Hook[] GetChildren(Hook root, bool hydrate = false)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inflates the domain.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public Hook[] InflateDomain()
        {
            return TaxonomyProvider
                .Hooks
                .InflateDomain();
        }
    }
}
