//	========================================================================================
//	INFO: This file is generated from a T4 template.
//  !!!	Any changes made manually will be lost next time this file is regenerated !!!
//	========================================================================================

using System;
using Broobu.Contact.Contract.Domain;

namespace Broobu.Contact.Contract.Interfaces
{
  	public partial interface IAddressAgent: IAddress
  	{
		#region Events
		event Action<Address> SaveAddressItemCompleted;

		event Action<Address> DeleteAddressItemCompleted;

		event Action<Address> GetAddressItemCompleted;

		event Action<Address> GetAddressItemForRelationCompleted;

		event Action<Address[]> GetAddressItemsCompleted;

		event Action<Address[]> GetAddressItemsForRelationCompleted;

		#endregion
		#region Methods
		void SaveAddressItemAsync(Address addressItem, Action<Address> action = null);

		void DeleteAddressItemAsync(Address item, Action<Address> action = null);

		void GetAddressItemAsync(string id, Action<Address> action = null);

		void GetAddressItemForRelationAsync(string relationId, string addressId, Action<Address> action = null);

		void GetAddressItemsAsync(Action<Address[]> action = null);

		void GetAddressItemsForRelationAsync(string relationId, Action<Address[]> action = null);

		#endregion

	}
}