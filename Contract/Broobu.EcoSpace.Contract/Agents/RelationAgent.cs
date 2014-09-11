// ***********************************************************************
// Assembly         : Broobu.Authorization.Contract
// Author           : ON8RL
// Created          : 12-22-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-22-2013
// ***********************************************************************
// <copyright file="RelationAgent.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Broobu.Authorization.Contract.Domain;
using Broobu.Authorization.Contract.Interfaces;
using Iris.Fx.Domain;
using Iris.Fx.Networking.Wcf;

namespace Broobu.Authorization.Contract.Agent
{
    /// <summary>
    /// Class RelationAgent.
    /// </summary>
    class RelationAgent : DiscoProxy<IRelation>, IRelationAgent
    {
        /// <summary>
        /// Links the specified from.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        /// <param name="relationType">Type of the relation.</param>
        /// <returns>RelationItem.</returns>
        public RelationItem Link(Result @from, Result to)
        {
            var clt = CreateClient();
            try
            {
                return clt.Link(from, to);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Uns the link.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        /// <param name="relationType">Type of the relation.</param>
        /// <returns>RelationItem.</returns>
        public RelationItem UnLink(Result @from, Result to)
        {
            var clt = CreateClient();
            try
            {
                return clt.UnLink(from, to);
            }
            finally
            {
                CloseClient(clt);
            }
        }
    }
}
