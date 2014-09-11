//	========================================================================================
//	INFO: This file is generated from a T4 template.
//  !!!	Any changes made manually will be lost next time this file is regenerated !!!
//	========================================================================================

using System;
using Broobu.Contact.Contract.Domain;
using Iris.Fx.Domain;

namespace Broobu.Contact.Contract.Interfaces
{
  	public partial interface IContactAgent: IContact
  	{
		#region Events
		event Action<Result> DeleteRelationAddressItemCompleted;

		event Action<RelationXDocumentI> DeleteRelationDocumentItemCompleted;

		event Action<Relation> DeleteRelationItemCompleted;

		event Action<RelationXAddress> GetRelationAddressItemCompleted;

		event Action<RelationXDocumentI> GetRelationDocumentItemCompleted;

		event Action<RelationXAddress[]> GetRelationAddressItemsCompleted;

		event Action<RelationXAddress[]> GetRelationAddressItemsForRelationCompleted;

		event Action<RelationXDocumentI[]> GetRelationDocumentItemsCompleted;

		event Action<RelationXDocumentI[]> GetRelationDocumentItemsByDocumentIdCompleted;

		event Action<RelationXDocumentI[]> GetRelationDocumentItemsByRelationIdCompleted;

		event Action<RelationXAddress> SaveRelationAddressItemCompleted;

		event Action<RelationXDocumentI> SaveRelationDocumentItemCompleted;

		#endregion
		#region Methods
		void DeleteRelationAddressItemAsync(RelationXAddress item, Action<Result> action = null);

		void DeleteRelationDocumentItemAsync(RelationXDocumentI item, Action<RelationXDocumentI> action = null);

		void DeleteRelationItemAsync(Relation itemm, Action<Relation> action = null);

		void GetRelationAddressItemAsync(string id, Action<RelationXAddress> action = null);

		void GetRelationDocumentItemAsync(string id, Action<RelationXDocumentI> action = null);

		void GetRelationAddressItemsAsync(Action<RelationXAddress[]> action = null);

		void GetRelationAddressItemsForRelationAsync(string relationId, Action<RelationXAddress[]> action = null);

		void GetRelationDocumentItemsAsync(Action<RelationXDocumentI[]> action = null);

		void GetRelationDocumentItemsByDocumentIdAsync(string documentId, Action<RelationXDocumentI[]> action = null);

		void GetRelationDocumentItemsByRelationIdAsync(string relationId, Action<RelationXDocumentI[]> action = null);

		void SaveRelationAddressItemAsync(RelationXAddress relationAddressItem, Action<RelationXAddress> action = null);

		void SaveRelationDocumentItemAsync(RelationXDocumentI relationDocumentItem, Action<RelationXDocumentI> action = null);

		#endregion

	}
}