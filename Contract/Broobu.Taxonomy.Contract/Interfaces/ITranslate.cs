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
using Broobu.Taxonomy.Contract.Domain;
using Description = Broobu.Taxonomy.Contract.Domain.Description;


namespace Broobu.Taxonomy.Contract.Interfaces
{

    /// <summary>
    /// Interface IMedia
    /// </summary>
	[ServiceContract(Namespace = TaxonomyConst.Namespace)]
  	public interface ITranslate
  	{
		#region Methods
        /// <summary>
        /// Gets the description item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Description.</returns>
		[OperationContract]
		Description GetDescription(string id);

        /// <summary>
        /// Gets the description items for object.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <param name="displayName"></param>
        /// <returns>Description[][].</returns>
        [OperationContract]
		Description[] GetDescriptionsForObject(string objectId, string displayName="Unknown");

        /// <summary>
        /// Gets the type of the description items for.
        /// </summary>
        /// <param name="typeId">The type identifier.</param>
        /// <returns>Description[][].</returns>
		[OperationContract]
		Description[] GetDescriptionsForType(string typeId);

        /// <summary>
        /// Gets the description items for culture.
        /// </summary>
        /// <param name="cultureId">The object identifier.</param>
        /// <returns>Description[][].</returns>
		[OperationContract]
		Description[] GetDescriptionsForCulture(string cultureId);

        /// <summary>
        /// Gets the description items for object and culture.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <param name="cultureId">The culture identifier.</param>
        /// <returns>Description[][].</returns>
		[OperationContract]
		Description[] GetDescriptionsForObjectAndCulture(string objectId, string cultureId);

        /// <summary>
        /// Gets the type of the description items for object and.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <param name="typeId">The type identifier.</param>
        /// <returns>Description[][].</returns>
		[OperationContract]
		Description[] GetDescriptionsForObjectAndType(string objectId, string typeId);

        /// <summary>
        /// Gets the type of the description items for object culture and.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <param name="cultureId">The culture identifier.</param>
        /// <param name="typeId">The type identifier.</param>
        /// <returns>Description[][].</returns>
		[OperationContract]
		Description[] GetDescriptionsForObjectCultureAndType(string objectId, string cultureId, string typeId);

        /// <summary>
        /// Gets the type of the description items for culture and.
        /// </summary>
        /// <param name="cultureId">The culture identifier.</param>
        /// <param name="typeId">The type identifier.</param>
        /// <returns>Description[][].</returns>
		[OperationContract]
		Description[] GetDescriptionsForCultureAndType(string cultureId, string typeId);

        /// <summary>
        /// Gets the description items like title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>Description[][].</returns>
		[OperationContract]
		Description[] GetDescriptionsLikeTitle(string title);

        /// <summary>
        /// Saves the description.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns>Description.</returns>
		[TransactionFlow(TransactionFlowOption.Allowed)]
		[OperationContract]
		Description SaveDescription(Description description);

        /// <summary>
        /// Deletes the description.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns>Description.</returns>
		[TransactionFlow(TransactionFlowOption.Allowed)]
		[OperationContract]
		Description DeleteDescription(Description description);

        /// <summary>
        /// Saves the descriptions.
        /// </summary>
        /// <param name="descriptions">The descriptions.</param>
        /// <returns>Description[][].</returns>
        [TransactionFlow(TransactionFlowOption.Allowed)]
        [OperationContract]
        Description[] SaveDescriptions(Description[] descriptions);



		#endregion

	}
}