// ***********************************************************************
// Assembly         : Iris.Contact.Business
// Author           : rlefever
// Created          : 11-25-2013
//
// Last Modified By : rlefever
// Last Modified On : 11-25-2013
// ***********************************************************************
// <copyright file="DocumentProvider.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Broobu.Contact.Business.Interfaces;
using Broobu.Contact.Contract.Domain;
using Iris.Fx.Data;

namespace Broobu.Contact.Business
{
    /// <summary>
    /// Class DocumentProvider.
    /// </summary>
    class DocumentProvider :  IDocumentProvider
    {
        /// <summary>
        /// Deletes the document item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>DocumentItem.</returns>
        public Document DeleteDocumentItem(Document item)
        {
            return Provider<Document>.Delete(item);
        }

        /// <summary>
        /// Gets the document item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>DocumentItem.</returns>
        public Document GetDocumentItem(string id)
        {
            return Provider<Document>.GetById(id);
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the document item by number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>DocumentItem.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Document GetDocumentItemByNumber(string number)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the document items.
        /// </summary>
        /// <returns>DocumentItem[][].</returns>
        public Document[] GetDocumentItems()
        {
            return Provider<Document>.GetAll();
        }

        /// <summary>
        /// Gets the document items for relation.
        /// </summary>
        /// <param name="relationId">The relation identifier.</param>
        /// <returns>DocumentItem[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Document[] GetDocumentItemsForRelation(string relationId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves the document item.
        /// </summary>
        /// <param name="documentItem">The document item.</param>
        /// <returns>DocumentItem.</returns>
        public Document SaveDocumentItem(Document documentItem)
        {
            return Provider<Document>.Save(documentItem);
        }

        public void RegisterRequiredObjects()
        {
            throw new NotImplementedException();
        }
    }
}
