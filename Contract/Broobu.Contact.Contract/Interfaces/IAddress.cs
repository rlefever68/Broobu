//	========================================================================================
//	INFO: This file is generated from a T4 template.
//  !!!	Any changes made manually will be lost next time this file is regenerated !!!
//	========================================================================================

using System.ServiceModel;
using Broobu.Contact.Contract.Domain;

namespace Broobu.Contact.Contract.Interfaces
{
	[ServiceContract(Namespace = ContactServiceConst.Namespace)]
  	public partial interface IAddress
  	{
		#region Methods
		[TransactionFlow(TransactionFlowOption.Allowed)]
		[OperationContract]
		Address SaveAddressItem(Address addressItem);

		[TransactionFlow(TransactionFlowOption.Allowed)]
		[OperationContract]
		Address DeleteAddressItem(Address item);

		[OperationContract]
		Address GetAddressItem(string id);

		[OperationContract]
		Address GetAddressItemForRelation(string relationId, string addressId);

		[OperationContract]
		Address[] GetAddressItems();

		[OperationContract]
		Address[] GetAddressItemsForRelation(string relationId);

		#endregion

	}
}