//	========================================================================================
//	INFO: This file is generated from a T4 template.
//  !!!	Any changes made manually will be lost next time this file is regenerated !!!
//	========================================================================================

using System;
using Broobu.Contact.Contract.Domain;
using Broobu.Taxonomy.Contract.Domain;

namespace Broobu.Contact.Contract.Interfaces
{
  	public partial interface ICountryAgent: ICountry
  	{
		#region Events
		event Action<Country> SaveCountryItemCompleted;

		event Action<Country> DeleteCountryItemCompleted;

		event Action<Country> GetCountryItemCompleted;

		event Action<Country> GetCountryItemByNameCompleted;

		event Action<Country> GetCountryItemByTwoLetterIsoRegionNameCompleted;

		event Action<Country> GetCountryItemByThreeLetterIsoRegionNameCompleted;

		event Action<Country[]> GetCountryItemsCompleted;

		event Action<Country[]> GetCountryItemsForCultureCompleted;

		#endregion
		#region Methods
		void SaveCountryItemAsync(Country countryItem, Action<Country> action = null);

		void DeleteCountryItemAsync(Country item, Action<Country> action = null);

		void GetCountryItemAsync(string id, Action<Country> action = null);

		void GetCountryItemByNameAsync(string name, Action<Country> action = null);

		void GetCountryItemByTwoLetterIsoRegionNameAsync(string twoLetterIsoRegionName, Action<Country> action = null);

		void GetCountryItemByThreeLetterIsoRegionNameAsync(string threeLetterIsoRegionName, Action<Country> action = null);

		void GetCountryItemsAsync(Action<Country[]> action = null);

		void GetCountryItemsForCultureAsync(string cultureName, Action<Country[]> action = null);

		#endregion

	}
}