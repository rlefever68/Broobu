// ***********************************************************************
// Assembly         : Broobu.Authorization.Contract
// Author           : ON8RL
// Created          : 12-22-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-22-2013
// ***********************************************************************
// <copyright file="IRelation.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ServiceModel;
using Broobu.Authorization.Contract.Domain;
using Iris.Fx.Domain;

namespace Broobu.Authorization.Contract.Interfaces
{
    /// <summary>
    /// Interface IRelation
    /// </summary>
    [ServiceKnownType(typeof(Result))]
    [ServiceKnownType(typeof(DomainObject<RelationItem>))]
    [ServiceContract(Namespace = ServiceConst.Namespace)]
    public interface IRelation
    {
        /// <summary>
        /// Links the specified from.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        /// <param name="relationType">Type of the relation.</param>
        /// <returns>RelationItem.</returns>
        [OperationContract]
        RelationItem Link(Result from, Result to);
        /// <summary>
        /// Uns the link.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        /// <param name="relationType">Type of the relation.</param>
        /// <returns>RelationItem.</returns>
        [OperationContract]
        RelationItem UnLink(Result from, Result to);
    }
}
