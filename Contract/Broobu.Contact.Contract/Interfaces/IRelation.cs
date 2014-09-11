//	========================================================================================
//	INFO: This file is generated from a T4 template.
//  !!!	Any changes made manually will be lost next time this file is regenerated !!!
//	========================================================================================

using System.ServiceModel;
using Broobu.Contact.Contract.Domain;

namespace Broobu.Contact.Contract.Interfaces
{
	[ServiceContract(Namespace = Iris.Fx.Domain.ServiceConst.Namespace)]
  	public partial interface IRelation
  	{
		#region Methods
		[OperationContract]
		Relation GetRelationItem(string id);

		[OperationContract]
		Relation[] GetRelationItems();

		[TransactionFlow(TransactionFlowOption.Allowed)]
		[OperationContract]
		Relation SaveRelationItem(Relation relationItem);

		#endregion

	}
}