//	========================================================================================
//	INFO: This file is generated from a T4 template.
//  !!!	Any changes made manually will be lost next time this file is regenerated !!!
//	========================================================================================

using System;
using Broobu.Contact.Contract.Domain;

namespace Broobu.Contact.Contract.Interfaces
{
  	public partial interface IDocumentAgent: IDocument
  	{
		#region Events
		event Action<Document> DeleteDocumentItemCompleted;

		event Action<Document> GetDocumentItemCompleted;

		event Action<Document> GetDocumentItemForRelationCompleted;

		event Action<Document> GetDocumentItemByNumberCompleted;

		event Action<Document[]> GetDocumentItemsCompleted;

		event Action<Document[]> GetDocumentItemsForRelationCompleted;

		event Action<Document> SaveDocumentItemCompleted;

		#endregion
		#region Methods
		void DeleteDocumentItemAsync(Document item, Action<Document> action = null);

		void GetDocumentItemAsync(string id, Action<Document> action = null);

		void GetDocumentItemForRelationAsync(string relationId, string documentId, Action<Document> action = null);

		void GetDocumentItemByNumberAsync(string number, Action<Document> action = null);

		void GetDocumentItemsAsync(Action<Document[]> action = null);

		void GetDocumentItemsForRelationAsync(string relationId, Action<Document[]> action = null);

		void SaveDocumentItemAsync(Document documentItem, Action<Document> action = null);

		#endregion

	}
}