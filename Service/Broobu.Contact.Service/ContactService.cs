// ***********************************************************************
// Assembly         : Iris.Contact.Service
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-20-2013
// ***********************************************************************
// <copyright file="ContactService.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ServiceModel;
using Broobu.Contact.Business;
using Broobu.Contact.Contract.Domain;
using Broobu.Contact.Contract.Interfaces;
using Broobu.Taxonomy.Contract.Domain;
using Iris.Fx.Domain;
using Iris.Fx.Networking.Wcf;

namespace Broobu.Contact.Service
{
    /// <summary>
    /// Class ContactService.
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class ContactService : SentryBase, IAddress,IContact,ICountry,IDocument,IRelation
    {

        /// <summary>
        /// Registers the required domain objects.
        /// </summary>
        protected override void RegisterRequiredDomainObjects()
        {
            ContactProviderFactory.CreateAddressProvider().RegisterRequiredObjects();
            ContactProviderFactory.CreateCountryProvider().RegisterRequiredObjects();
            ContactProviderFactory.CreateDocumentProvider().RegisterRequiredObjects();
            ContactProviderFactory.CreateRelationProvider().RegisterRequiredObjects();
        }

        /// <summary>
        /// Saves the address item.
        /// </summary>
        /// <param name="addressItem">The address item.</param>
        /// <returns>AddressItem.</returns>
        public Address SaveAddressItem(Address addressItem)
        {
            return ContactProviderFactory
                .CreateAddressProvider()
                .SaveAddressItem(addressItem);
        }

        /// <summary>
        /// Deletes the address item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>AddressItem.</returns>
        public Address DeleteAddressItem(Address item)
        {
            return ContactProviderFactory
                .CreateAddressProvider()
                .DeleteAddressItem(item);
        }

        /// <summary>
        /// Gets the address item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>AddressItem.</returns>
        public Address GetAddressItem(string id)
        {
            return ContactProviderFactory
                .CreateAddressProvider()
                .GetAddressItem(id);
        }

        /// <summary>
        /// Gets the address item for relation.
        /// </summary>
        /// <param name="relationId">The relation identifier.</param>
        /// <param name="addressId">The address identifier.</param>
        /// <returns>AddressItem.</returns>
        public Address GetAddressItemForRelation(string relationId, string addressId)
        {
            return ContactProviderFactory
                .CreateAddressProvider()
                .GetAddressItemForRelation(relationId, addressId);
        }

        /// <summary>
        /// Gets the address items.
        /// </summary>
        /// <returns>AddressItem[][].</returns>
        public Address[] GetAddressItems()
        {
            return ContactProviderFactory
                .CreateAddressProvider()
                .GetAddressItems();
        }

        /// <summary>
        /// Gets the address items for relation.
        /// </summary>
        /// <param name="relationId">The relation identifier.</param>
        /// <returns>AddressItem[][].</returns>
        public Address[] GetAddressItemsForRelation(string relationId)
        {
            return ContactProviderFactory
                .CreateAddressProvider()
                .GetAddressItemsForRelation(relationId);
        }


        /// <summary>
        /// Deletes the relation address item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Result.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Result DeleteRelationAddressItem(RelationXAddress item)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Deletes the relation document item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>RelationDocumentItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public RelationXDocumentI DeleteRelationDocumentItem(RelationXDocumentI item)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Deletes the relation item.
        /// </summary>
        /// <param name="itemm">The itemm.</param>
        /// <returns>RelationItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Relation DeleteRelationItem(Relation itemm)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the relation address item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>RelationAddressItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public RelationXAddress GetRelationAddressItem(string id)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the relation document item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>RelationDocumentItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public RelationXDocumentI GetRelationDocumentItem(string id)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the relation address items.
        /// </summary>
        /// <returns>RelationAddressItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public RelationXAddress[] GetRelationAddressItems()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the relation address items for relation.
        /// </summary>
        /// <param name="relationId">The relation identifier.</param>
        /// <returns>RelationAddressItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public RelationXAddress[] GetRelationAddressItemsForRelation(string relationId)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the relation document items.
        /// </summary>
        /// <returns>RelationDocumentItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public RelationXDocumentI[] GetRelationDocumentItems()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the relation document items by document identifier.
        /// </summary>
        /// <param name="documentId">The document identifier.</param>
        /// <returns>RelationDocumentItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public RelationXDocumentI[] GetRelationDocumentItemsByDocumentId(string documentId)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the relation document items by relation identifier.
        /// </summary>
        /// <param name="relationId">The relation identifier.</param>
        /// <returns>RelationDocumentItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public RelationXDocumentI[] GetRelationDocumentItemsByRelationId(string relationId)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Saves the relation address item.
        /// </summary>
        /// <param name="relationAddressItem">The relation address item.</param>
        /// <returns>RelationAddressItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public RelationXAddress SaveRelationAddressItem(RelationXAddress relationAddressItem)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Saves the relation document item.
        /// </summary>
        /// <param name="relationDocumentItem">The relation document item.</param>
        /// <returns>RelationDocumentItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public RelationXDocumentI SaveRelationDocumentItem(RelationXDocumentI relationDocumentItem)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Saves the country item.
        /// </summary>
        /// <param name="countryItem">The country item.</param>
        /// <returns>CountryItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Country SaveCountryItem(Country countryItem)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Deletes the country item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>CountryItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Country DeleteCountryItem(Country item)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the country item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>CountryItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Country GetCountryItem(string id)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the name of the country item by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>CountryItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Country GetCountryItemByName(string name)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the name of the country item by two letter iso region.
        /// </summary>
        /// <param name="twoLetterIsoRegionName">Name of the two letter iso region.</param>
        /// <returns>CountryItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Country GetCountryItemByTwoLetterIsoRegionName(string twoLetterIsoRegionName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the name of the country item by three letter iso region.
        /// </summary>
        /// <param name="threeLetterIsoRegionName">Name of the three letter iso region.</param>
        /// <returns>CountryItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Country GetCountryItemByThreeLetterIsoRegionName(string threeLetterIsoRegionName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the country items.
        /// </summary>
        /// <returns>CountryItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Country[] GetCountryItems()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the country items for culture.
        /// </summary>
        /// <param name="cultureName">Name of the culture.</param>
        /// <returns>CountryItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Country[] GetCountryItemsForCulture(string cultureName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Deletes the document item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>DocumentItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Document DeleteDocumentItem(Document item)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the document item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>DocumentItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Document GetDocumentItem(string id)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the document item for relation.
        /// </summary>
        /// <param name="relationId">The relation identifier.</param>
        /// <param name="documentId">The document identifier.</param>
        /// <returns>DocumentItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Document GetDocumentItemForRelation(string relationId, string documentId)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the document item by number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>DocumentItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Document GetDocumentItemByNumber(string number)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the document items.
        /// </summary>
        /// <returns>DocumentItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Document[] GetDocumentItems()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the document items for relation.
        /// </summary>
        /// <param name="relationId">The relation identifier.</param>
        /// <returns>DocumentItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Document[] GetDocumentItemsForRelation(string relationId)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Saves the document item.
        /// </summary>
        /// <param name="documentItem">The document item.</param>
        /// <returns>DocumentItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Document SaveDocumentItem(Document documentItem)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the relation item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>RelationItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Relation GetRelationItem(string id)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the relation items.
        /// </summary>
        /// <returns>RelationItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Relation[] GetRelationItems()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Saves the relation item.
        /// </summary>
        /// <param name="relationItem">The relation item.</param>
        /// <returns>RelationItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Relation SaveRelationItem(Relation relationItem)
        {
            throw new System.NotImplementedException();
        }
    }
}
