using System;
using Broobu.Contact.Contract.Domain;
using Broobu.Contact.Contract.Interfaces;
using Iris.Fx.Domain;
using Iris.Fx.Networking.Wcf;
using log4net;

namespace Broobu.Contact.Contract.Agent
{
    /// <summary>
    /// Class ContactAgent.
    /// </summary>
	partial class ContactAgent: DiscoProxy<IContact>, IContactAgent
	{
		#region Fields
        /// <summary>
        /// The logger
        /// </summary>
		private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		#endregion
		#region Events
        /// <summary>
        /// Occurs when [delete relation address item completed].
        /// </summary>
		public event Action<Result> DeleteRelationAddressItemCompleted;
        /// <summary>
        /// Occurs when [delete relation document item completed].
        /// </summary>
		public event Action<RelationXDocumentI> DeleteRelationDocumentItemCompleted;
        /// <summary>
        /// Occurs when [delete relation item completed].
        /// </summary>
		public event Action<Relation> DeleteRelationItemCompleted;
        /// <summary>
        /// Occurs when [get relation address item completed].
        /// </summary>
		public event Action<RelationXAddress> GetRelationAddressItemCompleted;
        /// <summary>
        /// Occurs when [get relation document item completed].
        /// </summary>
		public event Action<RelationXDocumentI> GetRelationDocumentItemCompleted;
        /// <summary>
        /// Occurs when [get relation address items completed].
        /// </summary>
		public event Action<RelationXAddress[]> GetRelationAddressItemsCompleted;
        /// <summary>
        /// Occurs when [get relation address items for relation completed].
        /// </summary>
		public event Action<RelationXAddress[]> GetRelationAddressItemsForRelationCompleted;
        /// <summary>
        /// Occurs when [get relation document items completed].
        /// </summary>
		public event Action<RelationXDocumentI[]> GetRelationDocumentItemsCompleted;
        /// <summary>
        /// Occurs when [get relation document items by document identifier completed].
        /// </summary>
		public event Action<RelationXDocumentI[]> GetRelationDocumentItemsByDocumentIdCompleted;
        /// <summary>
        /// Occurs when [get relation document items by relation identifier completed].
        /// </summary>
		public event Action<RelationXDocumentI[]> GetRelationDocumentItemsByRelationIdCompleted;
        /// <summary>
        /// Occurs when [save relation address item completed].
        /// </summary>
		public event Action<RelationXAddress> SaveRelationAddressItemCompleted;
        /// <summary>
        /// Occurs when [save relation document item completed].
        /// </summary>
		public event Action<RelationXDocumentI> SaveRelationDocumentItemCompleted;
		
		#endregion		
		#region Methods
        /// <summary>
        /// Deletes the relation address item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Iris.Fx.Domain.Result.</returns>
		public Result DeleteRelationAddressItem(RelationXAddress item)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IContact.DeleteRelationAddressItem started");
				timer.Start();
			}
			IContact clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.DeleteRelationAddressItem ({0})", timer.Elapsed);
				}
				return clt.DeleteRelationAddressItem(item);
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
					Logger.DebugFormat("Method IContact.DeleteRelationAddressItem finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Deletes the relation address item asynchronous.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="action">The action.</param>
		public void DeleteRelationAddressItemAsync(RelationXAddress item, Action<Result> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Result)null;
				wrk.DoWork += (s, e) =>
				{
					res = DeleteRelationAddressItem(item);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (DeleteRelationAddressItemCompleted != null)
						DeleteRelationAddressItemCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Deletes the relation document item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Broobu.Contact.Contract.Domain.RelationDocumentItem.</returns>
		public RelationXDocumentI DeleteRelationDocumentItem(RelationXDocumentI item)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IContact.DeleteRelationDocumentItem started");
				timer.Start();
			}
			IContact clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.DeleteRelationDocumentItem ({0})", timer.Elapsed);
				}
				return clt.DeleteRelationDocumentItem(item);
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
					Logger.DebugFormat("Method IContact.DeleteRelationDocumentItem finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Deletes the relation document item asynchronous.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="action">The action.</param>
		public void DeleteRelationDocumentItemAsync(RelationXDocumentI item, Action<RelationXDocumentI> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (RelationXDocumentI)null;
				wrk.DoWork += (s, e) =>
				{
					res = DeleteRelationDocumentItem(item);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (DeleteRelationDocumentItemCompleted != null)
						DeleteRelationDocumentItemCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Deletes the relation item.
        /// </summary>
        /// <param name="itemm">The itemm.</param>
        /// <returns>Broobu.Contact.Contract.Domain.RelationItem.</returns>
		public Relation DeleteRelationItem(Relation itemm)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IContact.DeleteRelationItem started");
				timer.Start();
			}
			IContact clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.DeleteRelationItem ({0})", timer.Elapsed);
				}
				return clt.DeleteRelationItem(itemm);
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
					Logger.DebugFormat("Method IContact.DeleteRelationItem finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Deletes the relation item asynchronous.
        /// </summary>
        /// <param name="itemm">The itemm.</param>
        /// <param name="action">The action.</param>
		public void DeleteRelationItemAsync(Relation itemm, Action<Relation> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Relation)null;
				wrk.DoWork += (s, e) =>
				{
					res = DeleteRelationItem(itemm);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (DeleteRelationItemCompleted != null)
						DeleteRelationItemCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the relation address item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Broobu.Contact.Contract.Domain.RelationAddressItem.</returns>
		public RelationXAddress GetRelationAddressItem(string id)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IContact.GetRelationAddressItem started");
				timer.Start();
			}
			IContact clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetRelationAddressItem ({0})", timer.Elapsed);
				}
				return clt.GetRelationAddressItem(id);
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
					Logger.DebugFormat("Method IContact.GetRelationAddressItem finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Gets the relation address item asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="action">The action.</param>
		public void GetRelationAddressItemAsync(string id, Action<RelationXAddress> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (RelationXAddress)null;
				wrk.DoWork += (s, e) =>
				{
					res = GetRelationAddressItem(id);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetRelationAddressItemCompleted != null)
						GetRelationAddressItemCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the relation document item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Broobu.Contact.Contract.Domain.RelationDocumentItem.</returns>
		public RelationXDocumentI GetRelationDocumentItem(string id)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IContact.GetRelationDocumentItem started");
				timer.Start();
			}
			IContact clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetRelationDocumentItem ({0})", timer.Elapsed);
				}
				return clt.GetRelationDocumentItem(id);
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
					Logger.DebugFormat("Method IContact.GetRelationDocumentItem finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Gets the relation document item asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="action">The action.</param>
		public void GetRelationDocumentItemAsync(string id, Action<RelationXDocumentI> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (RelationXDocumentI)null;
				wrk.DoWork += (s, e) =>
				{
					res = GetRelationDocumentItem(id);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetRelationDocumentItemCompleted != null)
						GetRelationDocumentItemCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the relation address items.
        /// </summary>
        /// <returns>Broobu.Contact.Contract.Domain.RelationAddressItem[].</returns>
		public RelationXAddress[] GetRelationAddressItems()
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IContact.GetRelationAddressItems started");
				timer.Start();
			}
			IContact clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetRelationAddressItems ({0})", timer.Elapsed);
				}
				return clt.GetRelationAddressItems();
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
					Logger.DebugFormat("Method IContact.GetRelationAddressItems finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Gets the relation address items asynchronous.
        /// </summary>
        /// <param name="action">The action.</param>
		public void GetRelationAddressItemsAsync(Action<RelationXAddress[]> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (RelationXAddress[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetRelationAddressItems();
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetRelationAddressItemsCompleted != null)
						GetRelationAddressItemsCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the relation address items for relation.
        /// </summary>
        /// <param name="relationId">The relation identifier.</param>
        /// <returns>Broobu.Contact.Contract.Domain.RelationAddressItem[].</returns>
		public RelationXAddress[] GetRelationAddressItemsForRelation(string relationId)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IContact.GetRelationAddressItemsForRelation started");
				timer.Start();
			}
			IContact clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetRelationAddressItemsForRelation ({0})", timer.Elapsed);
				}
				return clt.GetRelationAddressItemsForRelation(relationId);
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
					Logger.DebugFormat("Method IContact.GetRelationAddressItemsForRelation finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Gets the relation address items for relation asynchronous.
        /// </summary>
        /// <param name="relationId">The relation identifier.</param>
        /// <param name="action">The action.</param>
		public void GetRelationAddressItemsForRelationAsync(string relationId, Action<RelationXAddress[]> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (RelationXAddress[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetRelationAddressItemsForRelation(relationId);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetRelationAddressItemsForRelationCompleted != null)
						GetRelationAddressItemsForRelationCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the relation document items.
        /// </summary>
        /// <returns>Broobu.Contact.Contract.Domain.RelationDocumentItem[].</returns>
		public RelationXDocumentI[] GetRelationDocumentItems()
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IContact.GetRelationDocumentItems started");
				timer.Start();
			}
			IContact clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetRelationDocumentItems ({0})", timer.Elapsed);
				}
				return clt.GetRelationDocumentItems();
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
					Logger.DebugFormat("Method IContact.GetRelationDocumentItems finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Gets the relation document items asynchronous.
        /// </summary>
        /// <param name="action">The action.</param>
		public void GetRelationDocumentItemsAsync(Action<RelationXDocumentI[]> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (RelationXDocumentI[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetRelationDocumentItems();
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetRelationDocumentItemsCompleted != null)
						GetRelationDocumentItemsCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the relation document items by document identifier.
        /// </summary>
        /// <param name="documentId">The document identifier.</param>
        /// <returns>Broobu.Contact.Contract.Domain.RelationDocumentItem[].</returns>
		public RelationXDocumentI[] GetRelationDocumentItemsByDocumentId(string documentId)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IContact.GetRelationDocumentItemsByDocumentId started");
				timer.Start();
			}
			IContact clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetRelationDocumentItemsByDocumentId ({0})", timer.Elapsed);
				}
				return clt.GetRelationDocumentItemsByDocumentId(documentId);
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
					Logger.DebugFormat("Method IContact.GetRelationDocumentItemsByDocumentId finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Gets the relation document items by document identifier asynchronous.
        /// </summary>
        /// <param name="documentId">The document identifier.</param>
        /// <param name="action">The action.</param>
		public void GetRelationDocumentItemsByDocumentIdAsync(string documentId, Action<RelationXDocumentI[]> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (RelationXDocumentI[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetRelationDocumentItemsByDocumentId(documentId);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetRelationDocumentItemsByDocumentIdCompleted != null)
						GetRelationDocumentItemsByDocumentIdCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the relation document items by relation identifier.
        /// </summary>
        /// <param name="relationId">The relation identifier.</param>
        /// <returns>Broobu.Contact.Contract.Domain.RelationDocumentItem[].</returns>
		public RelationXDocumentI[] GetRelationDocumentItemsByRelationId(string relationId)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IContact.GetRelationDocumentItemsByRelationId started");
				timer.Start();
			}
			IContact clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetRelationDocumentItemsByRelationId ({0})", timer.Elapsed);
				}
				return clt.GetRelationDocumentItemsByRelationId(relationId);
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
					Logger.DebugFormat("Method IContact.GetRelationDocumentItemsByRelationId finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Gets the relation document items by relation identifier asynchronous.
        /// </summary>
        /// <param name="relationId">The relation identifier.</param>
        /// <param name="action">The action.</param>
		public void GetRelationDocumentItemsByRelationIdAsync(string relationId, Action<RelationXDocumentI[]> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (RelationXDocumentI[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetRelationDocumentItemsByRelationId(relationId);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetRelationDocumentItemsByRelationIdCompleted != null)
						GetRelationDocumentItemsByRelationIdCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Saves the relation address item.
        /// </summary>
        /// <param name="relationAddressItem">The relation address item.</param>
        /// <returns>Broobu.Contact.Contract.Domain.RelationAddressItem.</returns>
		public RelationXAddress SaveRelationAddressItem(RelationXAddress relationAddressItem)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IContact.SaveRelationAddressItem started");
				timer.Start();
			}
			IContact clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.SaveRelationAddressItem ({0})", timer.Elapsed);
				}
				return clt.SaveRelationAddressItem(relationAddressItem);
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
					Logger.DebugFormat("Method IContact.SaveRelationAddressItem finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Saves the relation address item asynchronous.
        /// </summary>
        /// <param name="relationAddressItem">The relation address item.</param>
        /// <param name="action">The action.</param>
		public void SaveRelationAddressItemAsync(RelationXAddress relationAddressItem, Action<RelationXAddress> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (RelationXAddress)null;
				wrk.DoWork += (s, e) =>
				{
					res = SaveRelationAddressItem(relationAddressItem);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (SaveRelationAddressItemCompleted != null)
						SaveRelationAddressItemCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Saves the relation document item.
        /// </summary>
        /// <param name="relationDocumentItem">The relation document item.</param>
        /// <returns>Broobu.Contact.Contract.Domain.RelationDocumentItem.</returns>
		public RelationXDocumentI SaveRelationDocumentItem(RelationXDocumentI relationDocumentItem)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IContact.SaveRelationDocumentItem started");
				timer.Start();
			}
			IContact clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.SaveRelationDocumentItem ({0})", timer.Elapsed);
				}
				return clt.SaveRelationDocumentItem(relationDocumentItem);
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
					Logger.DebugFormat("Method IContact.SaveRelationDocumentItem finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Saves the relation document item asynchronous.
        /// </summary>
        /// <param name="relationDocumentItem">The relation document item.</param>
        /// <param name="action">The action.</param>
		public void SaveRelationDocumentItemAsync(RelationXDocumentI relationDocumentItem, Action<RelationXDocumentI> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (RelationXDocumentI)null;
				wrk.DoWork += (s, e) =>
				{
					res = SaveRelationDocumentItem(relationDocumentItem);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (SaveRelationDocumentItemCompleted != null)
						SaveRelationDocumentItemCompleted(res);
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