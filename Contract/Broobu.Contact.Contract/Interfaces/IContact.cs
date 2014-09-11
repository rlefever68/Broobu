//	========================================================================================
//	INFO: This file is generated from a T4 template.
//  !!!	Any changes made manually will be lost next time this file is regenerated !!!
//	========================================================================================

using System.ServiceModel;
using Broobu.Contact.Contract.Domain;
using Iris.Fx.Domain;

namespace Broobu.Contact.Contract.Interfaces
{
	[ServiceContract(Namespace = Iris.Fx.Domain.ServiceConst.Namespace)]
  	public partial interface IContact
  	{
		#region Methods
		[TransactionFlow(TransactionFlowOption.Allowed)]
		[OperationContract]
		Result DeleteRelationAddressItem(RelationXAddress item);

		[TransactionFlow(TransactionFlowOption.Allowed)]
		[OperationContract]
		RelationXDocumentI DeleteRelationDocumentItem(RelationXDocumentI item);

		[TransactionFlow(TransactionFlowOption.Allowed)]
		[OperationContract]
		Relation DeleteRelationItem(Relation itemm);

		[OperationContract]
		RelationXAddress GetRelationAddressItem(string id);

		[OperationContract]
		RelationXDocumentI GetRelationDocumentItem(string id);

		[OperationContract]
		RelationXAddress[] GetRelationAddressItems();

		[OperationContract]
		RelationXAddress[] GetRelationAddressItemsForRelation(string relationId);

		[OperationContract]
		RelationXDocumentI[] GetRelationDocumentItems();

		[OperationContract]
		RelationXDocumentI[] GetRelationDocumentItemsByDocumentId(string documentId);

		[OperationContract]
		RelationXDocumentI[] GetRelationDocumentItemsByRelationId(string relationId);

		[TransactionFlow(TransactionFlowOption.Allowed)]
		[OperationContract]
		RelationXAddress SaveRelationAddressItem(RelationXAddress relationAddressItem);

		[TransactionFlow(TransactionFlowOption.Allowed)]
		[OperationContract]
		RelationXDocumentI SaveRelationDocumentItem(RelationXDocumentI relationDocumentItem);

		#endregion

	}
}