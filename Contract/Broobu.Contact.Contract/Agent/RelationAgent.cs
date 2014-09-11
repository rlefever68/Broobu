using System;
using Broobu.Contact.Contract.Domain;
using Broobu.Contact.Contract.Interfaces;
using Iris.Fx.Networking.Wcf;
using log4net;

namespace Broobu.Contact.Contract.Agent
{
    /// <summary>
    /// Class RelationAgent.
    /// </summary>
	partial class RelationAgent: DiscoProxy<IRelation>, IRelationAgent
	{
		#region Fields
        /// <summary>
        /// The logger
        /// </summary>
		private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		#endregion
		#region Events
        /// <summary>
        /// Occurs when [get relation item completed].
        /// </summary>
		public event Action<Relation> GetRelationItemCompleted;
        /// <summary>
        /// Occurs when [get relation items completed].
        /// </summary>
		public event Action<Relation[]> GetRelationItemsCompleted;
        /// <summary>
        /// Occurs when [save relation item completed].
        /// </summary>
		public event Action<Relation> SaveRelationItemCompleted;
		
		#endregion		
		#region Methods
        /// <summary>
        /// Gets the relation item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Broobu.Contact.Contract.Domain.RelationItem.</returns>
		public Relation GetRelationItem(string id)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IRelation.GetRelationItem started");
				timer.Start();
			}
			IRelation clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetRelationItem ({0})", timer.Elapsed);
				}
				return clt.GetRelationItem(id);
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
					Logger.DebugFormat("Method IRelation.GetRelationItem finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Gets the relation item asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="action">The action.</param>
		public void GetRelationItemAsync(string id, Action<Relation> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Relation)null;
				wrk.DoWork += (s, e) =>
				{
					res = GetRelationItem(id);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetRelationItemCompleted != null)
						GetRelationItemCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the relation items.
        /// </summary>
        /// <returns>Broobu.Contact.Contract.Domain.RelationItem[].</returns>
		public Relation[] GetRelationItems()
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IRelation.GetRelationItems started");
				timer.Start();
			}
			IRelation clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetRelationItems ({0})", timer.Elapsed);
				}
				return clt.GetRelationItems();
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
					Logger.DebugFormat("Method IRelation.GetRelationItems finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Gets the relation items asynchronous.
        /// </summary>
        /// <param name="action">The action.</param>
		public void GetRelationItemsAsync(Action<Relation[]> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Relation[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetRelationItems();
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetRelationItemsCompleted != null)
						GetRelationItemsCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Saves the relation item.
        /// </summary>
        /// <param name="relationItem">The relation item.</param>
        /// <returns>Broobu.Contact.Contract.Domain.RelationItem.</returns>
		public Relation SaveRelationItem(Relation relationItem)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IRelation.SaveRelationItem started");
				timer.Start();
			}
			IRelation clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.SaveRelationItem ({0})", timer.Elapsed);
				}
				return clt.SaveRelationItem(relationItem);
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
					Logger.DebugFormat("Method IRelation.SaveRelationItem finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Saves the relation item asynchronous.
        /// </summary>
        /// <param name="relationItem">The relation item.</param>
        /// <param name="action">The action.</param>
		public void SaveRelationItemAsync(Relation relationItem, Action<Relation> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Relation)null;
				wrk.DoWork += (s, e) =>
				{
					res = SaveRelationItem(relationItem);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (SaveRelationItemCompleted != null)
						SaveRelationItemCompleted(res);
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