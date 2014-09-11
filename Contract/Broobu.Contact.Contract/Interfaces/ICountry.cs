//	========================================================================================
//	INFO: This file is generated from a T4 template.
//  !!!	Any changes made manually will be lost next time this file is regenerated !!!
//	========================================================================================

using System.ServiceModel;
using Broobu.Contact.Contract.Domain;
using Broobu.Taxonomy.Contract.Domain;

namespace Broobu.Contact.Contract.Interfaces
{
	[ServiceContract(Namespace = Iris.Fx.Domain.ServiceConst.Namespace)]
  	public partial interface ICountry
  	{
		#region Methods
		[TransactionFlow(TransactionFlowOption.Allowed)]
		[OperationContract]
		Country SaveCountryItem(Country countryItem);

		[TransactionFlow(TransactionFlowOption.Allowed)]
		[OperationContract]
		Country DeleteCountryItem(Country item);

		[OperationContract]
		Country GetCountryItem(string id);

		[OperationContract]
		Country GetCountryItemByName(string name);

		[OperationContract]
		Country GetCountryItemByTwoLetterIsoRegionName(string twoLetterIsoRegionName);

		[OperationContract]
		Country GetCountryItemByThreeLetterIsoRegionName(string threeLetterIsoRegionName);

		[OperationContract]
		Country[] GetCountryItems();

		[OperationContract]
		Country[] GetCountryItemsForCulture(string cultureName);

		#endregion

	}
}