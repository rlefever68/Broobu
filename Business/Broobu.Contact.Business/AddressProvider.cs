using System;
using Broobu.Contact.Business.Interfaces;
using Broobu.Contact.Contract.Domain;
using Iris.Fx.Data;

namespace Broobu.Contact.Business
{
    /// <summary>
    /// Class AddressProvider.
    /// </summary>
    class AddressProvider : IAddressProvider
    {
        /// <summary>
        /// Saves the address item.
        /// </summary>
        /// <param name="addressItem">The address item.</param>
        /// <returns>Broobu.Contact.Contract.Domain.AddressItem.</returns>
        public Address SaveAddressItem(Address addressItem)
        {
            return Provider<Address>.Save(addressItem);
        }

        /// <summary>
        /// Deletes the address item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Broobu.Contact.Contract.Domain.AddressItem.</returns>
        public Address DeleteAddressItem(Address item)
        {
            return Provider<Address>.Delete(item);
        }


        /// <summary>
        /// Gets the address item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Broobu.Contact.Contract.Domain.AddressItem.</returns>
        public Address GetAddressItem(string id)
        {
            return Provider<Address>.GetById(id);
        }

        /// <summary>
        /// Gets the address item for relation.
        /// </summary>
        /// <param name="relationId">The relation identifier.</param>
        /// <param name="addressId">The address identifier.</param>
        /// <returns>Broobu.Contact.Contract.Domain.AddressItem.</returns>
        public Address GetAddressItemForRelation(string relationId, string addressId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the address items.
        /// </summary>
        /// <returns>Broobu.Contact.Contract.Domain.AddressItem[].</returns>
        public Address[] GetAddressItems()
        {
            return Provider<Address>.GetAll();
        }

        /// <summary>
        /// Gets the address items for relation.
        /// </summary>
        /// <param name="relationId">The relation identifier.</param>
        /// <returns>Broobu.Contact.Contract.Domain.AddressItem[].</returns>
        public Address[] GetAddressItemsForRelation(string relationId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Registers the required objects.
        /// </summary>
        public void RegisterRequiredObjects()
        {
            
        }
    }
}
