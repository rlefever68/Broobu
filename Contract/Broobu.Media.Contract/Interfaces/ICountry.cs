//	========================================================================================
//	INFO: This file is generated from a T4 template.
//  !!!	Any changes made manually will be lost next time this file is regenerated !!!
//	========================================================================================

using System.ServiceModel;
using Broobu.Media.Contract.Domain;

namespace Broobu.Media.Contract.Interfaces
{
	[ServiceContract(Namespace = Iris.Fx.Domain.ServiceConst.Namespace)]
  	public partial interface ICountry
  	{
		#region Methods
		[TransactionFlow(TransactionFlowOption.Allowed)]
		[OperationContract]
		CountryItem SaveCountryItem(CountryItem countryItem);

		[TransactionFlow(TransactionFlowOption.Allowed)]
		[OperationContract]
		CountryItem DeleteCountryItem(CountryItem item);

		[OperationContract]
		CountryItem GetCountryItem(string id);

		[OperationContract]
		CountryItem GetCountryItemByName(string name);

		[OperationContract]
		CountryItem GetCountryItemByTwoLetterIsoRegionName(string twoLetterIsoRegionName);

		[OperationContract]
		CountryItem GetCountryItemByThreeLetterIsoRegionName(string threeLetterIsoRegionName);

		[OperationContract]
		CountryItem[] GetCountryItems();

		[OperationContract]
		CountryItem[] GetCountryItemsForCulture(string cultureName);

		#endregion

	}
}