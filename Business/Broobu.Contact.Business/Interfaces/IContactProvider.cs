using Broobu.Contact.Contract.Domain;
using Broobu.Taxonomy.Contract.Domain;
using Iris.Fx.Domain;

namespace Broobu.Contact.Business.Interfaces
{
    public interface IContactProvider
    {
        Result GenerateDefaultData();

        Result DeleteAddressItem(string id);
        Result DeleteCountryItem(string id);
        Result DeleteDocumentItem(string id);
        Result DeleteRelationAddressItem(string id);
        Result DeleteRelationDocumentItem(string id);
        Result DeleteRelationItem(string id);
        
        Address GetAddressItem(string id);
        Address GetAddressItemForRelation(string relationId, string addressId);
        Address[] GetAddressItems();
        Address[] GetAddressItemsForRelation(string relationId);

        Country GetCountryItem(string id);
        Country GetCountryItemByName(string name);
        Country GetCountryItemByTwoLetterIsoRegionName(string twoLetterIsoRegionName);
        Country GetCountryItemByThreeLetterIsoRegionName(string threeLetterIsoRegionName);
        Country[] GetCountryItems();
        Country[] GetCountryItemsForCulture(string cultureName);

        Document GetDocumentItem(string id);
        Document GetDocumentItemByNumber(string number);
        Document GetDocumentItemForRelation(string relationId, string documentId);
        Document[] GetDocumentItems();
        Document[] GetDocumentItemsForRelation(string relationId);

        Relation GetRelationItem(string id);
        Relation[] GetRelationItems();

        RelationXAddress GetRelationAddressItem(string id);
        RelationXAddress[] GetRelationAddressItems();
        RelationXAddress[] GetRelationAddressItemsForRelation(string relationId);

        RelationXDocumentI GetRelationDocumentItem(string id);
        RelationXDocumentI[] GetRelationDocumentItems();
        RelationXDocumentI[] GetRelationDocumentItemsByDocumentId(string documentId);
        RelationXDocumentI[] GetRelationDocumentItemsByRelationId(string relationId);

        Address SaveAddressItem(Address addressItem);
        Country SaveCountryItem(Country countryItem);
        Document SaveDocumentItem(Document documentItem);
        RelationXAddress SaveRelationAddressItem(RelationXAddress relationAddressItem);
        RelationXDocumentI SaveRelationDocumentItem(RelationXDocumentI relationDocumentItem);
        Relation SaveRelationItem(Relation relationItem);
    }
}
