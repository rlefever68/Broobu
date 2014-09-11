//	========================================================================================
//	INFO: This file is generated from a T4 template.
//  !!!	Any changes made manually will be lost next time this file is regenerated !!!
//	========================================================================================

using System.ServiceModel;
using Broobu.Contact.Contract.Domain;

namespace Broobu.Contact.Contract.Interfaces
{
	[ServiceContract(Namespace = Iris.Fx.Domain.ServiceConst.Namespace)]
  	public partial interface IDocument
  	{
		#region Methods
		[TransactionFlow(TransactionFlowOption.Allowed)]
		[OperationContract]
		Document DeleteDocumentItem(Document item);

		[OperationContract]
		Document GetDocumentItem(string id);

		[OperationContract]
		Document GetDocumentItemForRelation(string relationId, string documentId);

		[OperationContract]
		Document GetDocumentItemByNumber(string number);

		[OperationContract]
		Document[] GetDocumentItems();

		[OperationContract]
		Document[] GetDocumentItemsForRelation(string relationId);

		[TransactionFlow(TransactionFlowOption.Allowed)]
		[OperationContract]
		Document SaveDocumentItem(Document documentItem);

		#endregion

	}
}