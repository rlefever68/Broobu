// ***********************************************************************
// Assembly         : Broobu.Media.Contract
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-23-2013
// ***********************************************************************
// <copyright file="IMedia.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ServiceModel;
using Iris.Fx.Domain;

namespace Broobu.Media.Contract.Interfaces
{

    /// <summary>
    /// Interface IMedia
    /// </summary>
	[ServiceContract(Namespace = MediaServiceConst.Namespace)]
  	public partial interface IDescription
  	{
		#region Methods
        /// <summary>
        /// Gets the description item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>DescriptionItem.</returns>
		[OperationContract]
		DescriptionItem GetDescriptionItem(string id);

        /// <summary>
        /// Gets the description items for object.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <returns>DescriptionItem[][].</returns>
		[OperationContract]
		DescriptionItem[] GetDescriptionItemsForObject(string objectId);

        /// <summary>
        /// Gets the type of the description items for.
        /// </summary>
        /// <param name="typeId">The type identifier.</param>
        /// <returns>DescriptionItem[][].</returns>
		[OperationContract]
		DescriptionItem[] GetDescriptionItemsForType(string typeId);

        /// <summary>
        /// Gets the description items for culture.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <returns>DescriptionItem[][].</returns>
		[OperationContract]
		DescriptionItem[] GetDescriptionItemsForCulture(string objectId);

        /// <summary>
        /// Gets the description items for object and culture.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <param name="cultureId">The culture identifier.</param>
        /// <returns>DescriptionItem[][].</returns>
		[OperationContract]
		DescriptionItem[] GetDescriptionItemsForObjectAndCulture(string objectId, string cultureId);

        /// <summary>
        /// Gets the type of the description items for object and.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <param name="typeId">The type identifier.</param>
        /// <returns>DescriptionItem[][].</returns>
		[OperationContract]
		DescriptionItem[] GetDescriptionItemsForObjectAndType(string objectId, string typeId);

        /// <summary>
        /// Gets the type of the description items for object culture and.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <param name="cultureId">The culture identifier.</param>
        /// <param name="typeId">The type identifier.</param>
        /// <returns>DescriptionItem[][].</returns>
		[OperationContract]
		DescriptionItem[] GetDescriptionItemsForObjectCultureAndType(string objectId, string cultureId, string typeId);

        /// <summary>
        /// Gets the type of the description items for culture and.
        /// </summary>
        /// <param name="cultureId">The culture identifier.</param>
        /// <param name="typeId">The type identifier.</param>
        /// <returns>DescriptionItem[][].</returns>
		[OperationContract]
		DescriptionItem[] GetDescriptionItemsForCultureAndType(string cultureId, string typeId);

        /// <summary>
        /// Gets the description items like title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>DescriptionItem[][].</returns>
		[OperationContract]
		DescriptionItem[] GetDescriptionItemsLikeTitle(string title);

        /// <summary>
        /// Saves the description.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns>DescriptionItem.</returns>
		[TransactionFlow(TransactionFlowOption.Allowed)]
		[OperationContract]
		DescriptionItem SaveDescription(DescriptionItem description);

        /// <summary>
        /// Deletes the description.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns>DescriptionItem.</returns>
		[TransactionFlow(TransactionFlowOption.Allowed)]
		[OperationContract]
		DescriptionItem DeleteDescription(DescriptionItem description);

        /// <summary>
        /// Saves the descriptions.
        /// </summary>
        /// <param name="descriptions">The descriptions.</param>
        /// <returns>DescriptionItem[][].</returns>
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [OperationContract]
        DescriptionItem[] SaveDescriptions(DescriptionItem[] descriptions);



		#endregion

	}
}