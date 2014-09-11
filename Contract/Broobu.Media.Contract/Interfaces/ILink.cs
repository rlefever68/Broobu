// ***********************************************************************
// Assembly         : Broobu.Media.Contract
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
using Broobu.Media.Contract.Domain;
using Iris.Fx.Domain;

namespace Broobu.Media.Contract.Interfaces
{
   
    [ServiceKnownType(typeof(Result))]
    [ServiceKnownType(typeof(DomainObject<LinkItem>))]
    [ServiceContract(Namespace = MediaServiceConst.Namespace)]
    public interface ILink
    {
        /// <summary>
        /// Links the specified from.
        /// </summary>
        /// <param name="fromItem">From item.</param>
        /// <param name="toItem">To item.</param>
        /// <param name="relationType">Type of the relation.</param>
        /// <returns>RelationItem.</returns>
        [OperationContract]
        LinkItem Link(string fromItem, string toItem, string relationType);
        /// <summary>
        /// Uns the link.
        /// </summary>
        /// <param name="fromItem">From item.</param>
        /// <param name="toItem">To item.</param>
        /// <param name="relationType">Type of the relation.</param>
        /// <returns>RelationItem.</returns>
        [OperationContract]
        LinkItem UnLink(string fromItem, string toItem, string relationType);


        /// <summary>
        /// Gets the relations to.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="relationType">Type of the relation.</param>
        /// <returns>RelationItem[][].</returns>
        [OperationContract]
        LinkItem[] GetRelationsTo(string id, string relationType);

        /// <summary>
        /// Gets the relations from.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="relationType">Type of the relation.</param>
        /// <returns>RelationItem[][].</returns>
        [OperationContract]
        LinkItem[] GetRelationsFrom(string id, string relationType);


        /// <summary>
        /// Deletes the relations to.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="relationType">Type of the relation.</param>
        /// <returns>RelationItem[][].</returns>
        [OperationContract]
        LinkItem[] DeleteRelationsTo(string id, string relationType);


        /// <summary>
        /// Deletes the get relations from.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="relationType">Type of the relation.</param>
        /// <returns>RelationItem[][].</returns>
        [OperationContract]
        LinkItem[] DeleteRelationsFrom(string id, string relationType);


    }
}
