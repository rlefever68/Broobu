using System;
using Broobu.Contact.Contract.Domain;
using Broobu.Contact.Contract.Interfaces;
using Iris.Fx.Networking.Wcf;
using log4net;

namespace Broobu.Contact.Contract.Agent
{
    /// <summary>
    /// Class DocumentAgent.
    /// </summary>
	partial class DocumentAgent: DiscoProxy<IDocument>, IDocumentAgent
	{
		#region Fields
        /// <summary>
        /// The logger
        /// </summary>
		private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		#endregion
		#region Events
        /// <summary>
        /// Occurs when [delete document item completed].
        /// </summary>
		public event Action<Document> DeleteDocumentItemCompleted;
        /// <summary>
        /// Occurs when [get document item completed].
        /// </summary>
		public event Action<Document> GetDocumentItemCompleted;
        /// <summary>
        /// Occurs when [get document item for relation completed].
        /// </summary>
		public event Action<Document> GetDocumentItemForRelationCompleted;
        /// <summary>
        /// Occurs when [get document item by number completed].
        /// </summary>
		public event Action<Document> GetDocumentItemByNumberCompleted;
        /// <summary>
        /// Occurs when [get document items completed].
        /// </summary>
		public event Action<Document[]> GetDocumentItemsCompleted;
        /// <summary>
        /// Occurs when [get document items for relation completed].
        /// </summary>
		public event Action<Document[]> GetDocumentItemsForRelationCompleted;
        /// <summary>
        /// Occurs when [save document item completed].
        /// </summary>
		public event Action<Document> SaveDocumentItemCompleted;
		
		#endregion		
		#region Methods
        /// <summary>
        /// Deletes the document item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Broobu.Contact.Contract.Domain.DocumentItem.</returns>
		public Document DeleteDocumentItem(Document item)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IDocument.DeleteDocumentItem started");
				timer.Start();
			}
			IDocument clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.DeleteDocumentItem ({0})", timer.Elapsed);
				}
				return clt.DeleteDocumentItem(item);
			}
			finally
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Closing client ({0})", timer.Elapsed);
				}
				CloseClient(clt);
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Method IDocument.DeleteDocumentItem finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Deletes the document item asynchronous.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="action">The action.</param>
		public void DeleteDocumentItemAsync(Document item, Action<Document> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Document)null;
				wrk.DoWork += (s, e) =>
				{
					res = DeleteDocumentItem(item);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (DeleteDocumentItemCompleted != null)
						DeleteDocumentItemCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the document item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Broobu.Contact.Contract.Domain.DocumentItem.</returns>
		public Document GetDocumentItem(string id)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IDocument.GetDocumentItem started");
				timer.Start();
			}
			IDocument clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetDocumentItem ({0})", timer.Elapsed);
				}
				return clt.GetDocumentItem(id);
			}
			finally
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Closing client ({0})", timer.Elapsed);
				}
				CloseClient(clt);
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Method IDocument.GetDocumentItem finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Gets the document item asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="action">The action.</param>
		public void GetDocumentItemAsync(string id, Action<Document> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Document)null;
				wrk.DoWork += (s, e) =>
				{
					res = GetDocumentItem(id);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetDocumentItemCompleted != null)
						GetDocumentItemCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the document item for relation.
        /// </summary>
        /// <param name="relationId">The relation identifier.</param>
        /// <param name="documentId">The document identifier.</param>
        /// <returns>Broobu.Contact.Contract.Domain.DocumentItem.</returns>
		public Document GetDocumentItemForRelation(string relationId, string documentId)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IDocument.GetDocumentItemForRelation started");
				timer.Start();
			}
			IDocument clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetDocumentItemForRelation ({0})", timer.Elapsed);
				}
				return clt.GetDocumentItemForRelation(relationId, documentId);
			}
			finally
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Closing client ({0})", timer.Elapsed);
				}
				CloseClient(clt);
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Method IDocument.GetDocumentItemForRelation finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Gets the document item for relation asynchronous.
        /// </summary>
        /// <param name="relationId">The relation identifier.</param>
        /// <param name="documentId">The document identifier.</param>
        /// <param name="action">The action.</param>
		public void GetDocumentItemForRelationAsync(string relationId, string documentId, Action<Document> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Document)null;
				wrk.DoWork += (s, e) =>
				{
					res = GetDocumentItemForRelation(relationId, documentId);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetDocumentItemForRelationCompleted != null)
						GetDocumentItemForRelationCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the document item by number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Broobu.Contact.Contract.Domain.DocumentItem.</returns>
		public Document GetDocumentItemByNumber(string number)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IDocument.GetDocumentItemByNumber started");
				timer.Start();
			}
			IDocument clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetDocumentItemByNumber ({0})", timer.Elapsed);
				}
				return clt.GetDocumentItemByNumber(number);
			}
			finally
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Closing client ({0})", timer.Elapsed);
				}
				CloseClient(clt);
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Method IDocument.GetDocumentItemByNumber finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Gets the document item by number asynchronous.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="action">The action.</param>
		public void GetDocumentItemByNumberAsync(string number, Action<Document> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Document)null;
				wrk.DoWork += (s, e) =>
				{
					res = GetDocumentItemByNumber(number);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetDocumentItemByNumberCompleted != null)
						GetDocumentItemByNumberCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the document items.
        /// </summary>
        /// <returns>Broobu.Contact.Contract.Domain.DocumentItem[].</returns>
		public Document[] GetDocumentItems()
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IDocument.GetDocumentItems started");
				timer.Start();
			}
			IDocument clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetDocumentItems ({0})", timer.Elapsed);
				}
				return clt.GetDocumentItems();
			}
			finally
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Closing client ({0})", timer.Elapsed);
				}
				CloseClient(clt);
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Method IDocument.GetDocumentItems finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Gets the document items asynchronous.
        /// </summary>
        /// <param name="action">The action.</param>
		public void GetDocumentItemsAsync(Action<Document[]> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Document[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetDocumentItems();
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetDocumentItemsCompleted != null)
						GetDocumentItemsCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the document items for relation.
        /// </summary>
        /// <param name="relationId">The relation identifier.</param>
        /// <returns>Broobu.Contact.Contract.Domain.DocumentItem[].</returns>
		public Document[] GetDocumentItemsForRelation(string relationId)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IDocument.GetDocumentItemsForRelation started");
				timer.Start();
			}
			IDocument clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetDocumentItemsForRelation ({0})", timer.Elapsed);
				}
				return clt.GetDocumentItemsForRelation(relationId);
			}
			finally
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Closing client ({0})", timer.Elapsed);
				}
				CloseClient(clt);
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Method IDocument.GetDocumentItemsForRelation finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Gets the document items for relation asynchronous.
        /// </summary>
        /// <param name="relationId">The relation identifier.</param>
        /// <param name="action">The action.</param>
		public void GetDocumentItemsForRelationAsync(string relationId, Action<Document[]> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Document[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetDocumentItemsForRelation(relationId);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetDocumentItemsForRelationCompleted != null)
						GetDocumentItemsForRelationCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Saves the document item.
        /// </summary>
        /// <param name="documentItem">The document item.</param>
        /// <returns>Broobu.Contact.Contract.Domain.DocumentItem.</returns>
		public Document SaveDocumentItem(Document documentItem)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IDocument.SaveDocumentItem started");
				timer.Start();
			}
			IDocument clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.SaveDocumentItem ({0})", timer.Elapsed);
				}
				return clt.SaveDocumentItem(documentItem);
			}
			finally
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Closing client ({0})", timer.Elapsed);
				}
				CloseClient(clt);
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Method IDocument.SaveDocumentItem finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Saves the document item asynchronous.
        /// </summary>
        /// <param name="documentItem">The document item.</param>
        /// <param name="action">The action.</param>
		public void SaveDocumentItemAsync(Document documentItem, Action<Document> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Document)null;
				wrk.DoWork += (s, e) =>
				{
					res = SaveDocumentItem(documentItem);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (SaveDocumentItemCompleted != null)
						SaveDocumentItemCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the contract namespace.
        /// </summary>
        /// <returns>System.String.</returns>
		protected override string GetContractNamespace()
		{
			return ContactServiceConst.Namespace;
		}
			
		#endregion		
	}
}