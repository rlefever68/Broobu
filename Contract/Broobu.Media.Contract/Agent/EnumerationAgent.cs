// ***********************************************************************
// Assembly         : Broobu.Media.Contract
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-23-2013
// ***********************************************************************
// <copyright file="EnumerationAgent.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Broobu.Media.Contract.Interfaces;
using Iris.Fx.Domain;
using Iris.Fx.Networking.Wcf;

namespace Broobu.Media.Contract.Agent
{
    /// <summary>
    /// Class EnumerationAgent.
    /// </summary>
    class EnumerationAgent : DiscoProxy<IEnumeration>, IEnumerationAgent
    {
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>EnumerationItem.</returns>
        public EnumerationItem GetById(string id)
        {
            var clt = CreateClient();
            try
            {
                return clt.GetById(id);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Saves the specified it.
        /// </summary>
        /// <param name="it">It.</param>
        /// <returns>EnumerationItem.</returns>
        public EnumerationItem Save(EnumerationItem it)
        {
            var clt = CreateClient();
            try
            {
                return clt.Save(it);
            }
            finally
            {
                CloseClient(clt);
            }

        }

        /// <summary>
        /// Registers the type of the enumeration.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>EnumerationItem.</returns>
        public EnumerationItem RegisterEnumerationType(EnumerationItem item)
        {
            var clt = CreateClient();
            try
            {
                return clt.RegisterEnumerationType(item);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Gets the type of the enumeration items for.
        /// </summary>
        /// <param name="baseTypeMedia">The base type media.</param>
        /// <returns>EnumerationItem[][].</returns>
        public EnumerationItem[] GetEnumerationItemsForType(string baseTypeMedia)
        {
            var clt = CreateClient();
            try
            {
                return clt.GetEnumerationItemsForType(baseTypeMedia);
            }
            finally
            {
                CloseClient(clt);
            }
           
        }

        /// <summary>
        /// Saves the enumerations.
        /// </summary>
        /// <param name="createRibbonTypeEnumeration">The create ribbon type enumeration.</param>
        /// <returns>EnumerationItem[][].</returns>
        public EnumerationItem[] SaveEnumerations(EnumerationItem[] createRibbonTypeEnumeration)
        {
            var clt = CreateClient();
            try
            {
                return clt.SaveEnumerations(createRibbonTypeEnumeration);
            }
            finally
            {
                CloseClient(clt);
            }

        }

        /// <summary>
        /// Deletes the enumerations.
        /// </summary>
        /// <param name="enums">The enums.</param>
        /// <returns>EnumerationItem[][].</returns>
        public EnumerationItem[] DeleteEnumerations(EnumerationItem[] enums)
        {
            var clt = CreateClient();
            try
            {
                return clt.DeleteEnumerations(enums);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Deletes the enumeration item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>EnumerationItem.</returns>
        public EnumerationItem DeleteEnumerationItem(EnumerationItem item)
        {
            var clt = CreateClient();
            try
            {
                return clt.DeleteEnumerationItem(item);
            }
            finally
            {
                CloseClient(clt);
            }
        }


        /// <summary>
        /// Gets the contract namespace.
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string GetContractNamespace()
        {
            return MediaServiceConst.Namespace;
        }
    }
}
