// ***********************************************************************
// Assembly         : Broobu.Media.Contract
// Author           : ON8RL
// Created          : 12-22-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-23-2013
// ***********************************************************************
// <copyright file="RelationAgent.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Broobu.Media.Contract.Domain;
using Broobu.Media.Contract.Interfaces;
using Iris.Fx.Networking.Wcf;


namespace Broobu.Media.Contract.Agent
{
    /// <summary>
    /// Class RelationAgent.
    /// </summary>
    class LinkAgent : DiscoProxy<ILink>, ILinkAgent
    {
        /// <summary>
        /// Links the specified from.
        /// </summary>
        /// <param name="fromItem">From.</param>
        /// <param name="toItem">To.</param>
        /// <param name="relationType">Type of the relation.</param>
        /// <returns>RelationItem.</returns>
        public LinkItem Link(string fromItem, string toItem, string relationType)
        {
            var clt = CreateClient();
            try
            {
                return clt.Link(fromItem, toItem, relationType);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Uns the link.
        /// </summary>
        /// <param name="fromItem">From.</param>
        /// <param name="toItem">To.</param>
        /// <param name="relationType">Type of the relation.</param>
        /// <returns>RelationItem.</returns>
        public LinkItem UnLink(string fromItem, string toItem, string relationType)
        {
            var clt = CreateClient();
            try
            {
                return clt.UnLink(fromItem, toItem, relationType);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Gets the relations to.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="relationType">Type of the relation.</param>
        /// <returns>RelationItem[][].</returns>
        public LinkItem[] GetRelationsTo(string id, string relationType)
        {
            var clt = CreateClient();
            try
            {
                return clt.GetRelationsTo(id, relationType);
            }
            finally
            {
                CloseClient(clt);
            }

        }

        /// <summary>
        /// Gets the relations from.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="relationType">Type of the relation.</param>
        /// <returns>RelationItem[][].</returns>
        public LinkItem[] GetRelationsFrom(string id, string relationType)
        {
            var clt = CreateClient();
            try
            {
                return clt.GetRelationsFrom(id, relationType);
            }
            finally
            {
                CloseClient(clt);
            }

        }

        /// <summary>
        /// Deletes the relations to.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="relationType">Type of the relation.</param>
        /// <returns>RelationItem[][].</returns>
        public LinkItem[] DeleteRelationsTo(string id, string relationType)
        {
            var clt = CreateClient();
            try
            {
                return clt.DeleteRelationsTo(id, relationType);
            }
            finally
            {
                CloseClient(clt);
            }

        }

        /// <summary>
        /// Deletes the get relations from.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="relationType">Type of the relation.</param>
        /// <returns>RelationItem[][].</returns>
        public LinkItem[] DeleteRelationsFrom(string id, string relationType)
        {
            var clt = CreateClient();
            try
            {
                return clt.DeleteRelationsFrom(id, relationType);
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
