// ***********************************************************************
// Assembly         : Broobu.Media.Contract
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-23-2013
// ***********************************************************************
// <copyright file="MediaAgent.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Broobu.Media.Contract.Interfaces;
using Iris.Fx.Domain;
using Iris.Fx.Networking.Wcf;
using log4net;

namespace Broobu.Media.Contract.Agent
{
    /// <summary>
    /// Class MediaAgent.
    /// </summary>
	class DescriptionAgent: DiscoProxy<IDescription>, IDescriptionAgent
	{
		#region Fields
        /// <summary>
        /// The logger
        /// </summary>
		private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		#endregion
		#region Events
        /// <summary>
        /// Occurs when [get description item completed].
        /// </summary>
		public event Action<DescriptionItem> GetDescriptionItemCompleted;
        /// <summary>
        /// Occurs when [get description items for object completed].
        /// </summary>
		public event Action<DescriptionItem[]> GetDescriptionItemsForObjectCompleted;
        /// <summary>
        /// Occurs when [get description items for type completed].
        /// </summary>
		public event Action<DescriptionItem[]> GetDescriptionItemsForTypeCompleted;
        /// <summary>
        /// Occurs when [get description items for culture completed].
        /// </summary>
		public event Action<DescriptionItem[]> GetDescriptionItemsForCultureCompleted;
        /// <summary>
        /// Occurs when [get description items for object and culture completed].
        /// </summary>
		public event Action<DescriptionItem[]> GetDescriptionItemsForObjectAndCultureCompleted;
        /// <summary>
        /// Occurs when [get description items for object and type completed].
        /// </summary>
		public event Action<DescriptionItem[]> GetDescriptionItemsForObjectAndTypeCompleted;
        /// <summary>
        /// Occurs when [get description items for object culture and type completed].
        /// </summary>
		public event Action<DescriptionItem[]> GetDescriptionItemsForObjectCultureAndTypeCompleted;
        /// <summary>
        /// Occurs when [get description items for culture and type completed].
        /// </summary>
		public event Action<DescriptionItem[]> GetDescriptionItemsForCultureAndTypeCompleted;
        /// <summary>
        /// Occurs when [get description items like title completed].
        /// </summary>
		public event Action<DescriptionItem[]> GetDescriptionItemsLikeTitleCompleted;
        /// <summary>
        /// Occurs when [save description completed].
        /// </summary>
		public event Action<DescriptionItem> SaveDescriptionCompleted;
        /// <summary>
        /// Occurs when [delete description completed].
        /// </summary>
		public event Action<DescriptionItem> DeleteDescriptionCompleted;
		
		#endregion		
		#region Methods
        /// <summary>
        /// Gets the description item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>DescriptionItem.</returns>
		public DescriptionItem GetDescriptionItem(string id)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IMedia.GetDescriptionItem started");
				timer.Start();
			}
			IDescription clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetDescriptionItem ({0})", timer.Elapsed);
				}
				return clt.GetDescriptionItem(id);
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
					Logger.DebugFormat("Method IMedia.GetDescriptionItem finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Gets the description item asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="action">The action.</param>
		public void GetDescriptionItemAsync(string id, Action<DescriptionItem> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (DescriptionItem)null;
				wrk.DoWork += (s, e) =>
				{
					res = GetDescriptionItem(id);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetDescriptionItemCompleted != null)
						GetDescriptionItemCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the description items for object.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <returns>DescriptionItem[][].</returns>
		public DescriptionItem[] GetDescriptionItemsForObject(string objectId)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IMedia.GetDescriptionItemsForObject started");
				timer.Start();
			}
			IDescription clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetDescriptionItemsForObject ({0})", timer.Elapsed);
				}
				return clt.GetDescriptionItemsForObject(objectId);
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
					Logger.DebugFormat("Method IMedia.GetDescriptionItemsForObject finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Gets the description items for object asynchronous.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <param name="action">The action.</param>
		public void GetDescriptionItemsForObjectAsync(string objectId, Action<DescriptionItem[]> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (DescriptionItem[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetDescriptionItemsForObject(objectId);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetDescriptionItemsForObjectCompleted != null)
						GetDescriptionItemsForObjectCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the type of the description items for.
        /// </summary>
        /// <param name="typeId">The type identifier.</param>
        /// <returns>DescriptionItem[][].</returns>
		public DescriptionItem[] GetDescriptionItemsForType(string typeId)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IMedia.GetDescriptionItemsForType started");
				timer.Start();
			}
			IDescription clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetDescriptionItemsForType ({0})", timer.Elapsed);
				}
				return clt.GetDescriptionItemsForType(typeId);
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
					Logger.DebugFormat("Method IMedia.GetDescriptionItemsForType finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Gets the description items for type asynchronous.
        /// </summary>
        /// <param name="typeId">The type identifier.</param>
        /// <param name="action">The action.</param>
		public void GetDescriptionItemsForTypeAsync(string typeId, Action<DescriptionItem[]> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (DescriptionItem[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetDescriptionItemsForType(typeId);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetDescriptionItemsForTypeCompleted != null)
						GetDescriptionItemsForTypeCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the description items for culture.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <returns>DescriptionItem[][].</returns>
		public DescriptionItem[] GetDescriptionItemsForCulture(string objectId)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IMedia.GetDescriptionItemsForCulture started");
				timer.Start();
			}
			IDescription clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetDescriptionItemsForCulture ({0})", timer.Elapsed);
				}
				return clt.GetDescriptionItemsForCulture(objectId);
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
					Logger.DebugFormat("Method IMedia.GetDescriptionItemsForCulture finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Gets the description items for culture asynchronous.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <param name="action">The action.</param>
		public void GetDescriptionItemsForCultureAsync(string objectId, Action<DescriptionItem[]> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (DescriptionItem[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetDescriptionItemsForCulture(objectId);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetDescriptionItemsForCultureCompleted != null)
						GetDescriptionItemsForCultureCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the description items for object and culture.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <param name="cultureId">The culture identifier.</param>
        /// <returns>DescriptionItem[][].</returns>
		public DescriptionItem[] GetDescriptionItemsForObjectAndCulture(string objectId, string cultureId)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IMedia.GetDescriptionItemsForObjectAndCulture started");
				timer.Start();
			}
			IDescription clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetDescriptionItemsForObjectAndCulture ({0})", timer.Elapsed);
				}
				return clt.GetDescriptionItemsForObjectAndCulture(objectId, cultureId);
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
					Logger.DebugFormat("Method IMedia.GetDescriptionItemsForObjectAndCulture finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Gets the description items for object and culture asynchronous.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <param name="cultureId">The culture identifier.</param>
        /// <param name="action">The action.</param>
		public void GetDescriptionItemsForObjectAndCultureAsync(string objectId, string cultureId, Action<DescriptionItem[]> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (DescriptionItem[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetDescriptionItemsForObjectAndCulture(objectId, cultureId);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetDescriptionItemsForObjectAndCultureCompleted != null)
						GetDescriptionItemsForObjectAndCultureCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the type of the description items for object and.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <param name="typeId">The type identifier.</param>
        /// <returns>DescriptionItem[][].</returns>
		public DescriptionItem[] GetDescriptionItemsForObjectAndType(string objectId, string typeId)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IMedia.GetDescriptionItemsForObjectAndType started");
				timer.Start();
			}
			IDescription clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetDescriptionItemsForObjectAndType ({0})", timer.Elapsed);
				}
				return clt.GetDescriptionItemsForObjectAndType(objectId, typeId);
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
					Logger.DebugFormat("Method IMedia.GetDescriptionItemsForObjectAndType finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Gets the description items for object and type asynchronous.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <param name="typeId">The type identifier.</param>
        /// <param name="action">The action.</param>
		public void GetDescriptionItemsForObjectAndTypeAsync(string objectId, string typeId, Action<DescriptionItem[]> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (DescriptionItem[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetDescriptionItemsForObjectAndType(objectId, typeId);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetDescriptionItemsForObjectAndTypeCompleted != null)
						GetDescriptionItemsForObjectAndTypeCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the type of the description items for object culture and.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <param name="cultureId">The culture identifier.</param>
        /// <param name="typeId">The type identifier.</param>
        /// <returns>DescriptionItem[][].</returns>
		public DescriptionItem[] GetDescriptionItemsForObjectCultureAndType(string objectId, string cultureId, string typeId)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IMedia.GetDescriptionItemsForObjectCultureAndType started");
				timer.Start();
			}
			IDescription clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetDescriptionItemsForObjectCultureAndType ({0})", timer.Elapsed);
				}
				return clt.GetDescriptionItemsForObjectCultureAndType(objectId, cultureId, typeId);
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
					Logger.DebugFormat("Method IMedia.GetDescriptionItemsForObjectCultureAndType finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Gets the description items for object culture and type asynchronous.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <param name="cultureId">The culture identifier.</param>
        /// <param name="typeId">The type identifier.</param>
        /// <param name="action">The action.</param>
		public void GetDescriptionItemsForObjectCultureAndTypeAsync(string objectId, string cultureId, string typeId, Action<DescriptionItem[]> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (DescriptionItem[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetDescriptionItemsForObjectCultureAndType(objectId, cultureId, typeId);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetDescriptionItemsForObjectCultureAndTypeCompleted != null)
						GetDescriptionItemsForObjectCultureAndTypeCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the type of the description items for culture and.
        /// </summary>
        /// <param name="cultureId">The culture identifier.</param>
        /// <param name="typeId">The type identifier.</param>
        /// <returns>DescriptionItem[][].</returns>
		public DescriptionItem[] GetDescriptionItemsForCultureAndType(string cultureId, string typeId)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IMedia.GetDescriptionItemsForCultureAndType started");
				timer.Start();
			}
			IDescription clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetDescriptionItemsForCultureAndType ({0})", timer.Elapsed);
				}
				return clt.GetDescriptionItemsForCultureAndType(cultureId, typeId);
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
					Logger.DebugFormat("Method IMedia.GetDescriptionItemsForCultureAndType finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Gets the description items for culture and type asynchronous.
        /// </summary>
        /// <param name="cultureId">The culture identifier.</param>
        /// <param name="typeId">The type identifier.</param>
        /// <param name="action">The action.</param>
		public void GetDescriptionItemsForCultureAndTypeAsync(string cultureId, string typeId, Action<DescriptionItem[]> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (DescriptionItem[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetDescriptionItemsForCultureAndType(cultureId, typeId);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetDescriptionItemsForCultureAndTypeCompleted != null)
						GetDescriptionItemsForCultureAndTypeCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the description items like title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>DescriptionItem[][].</returns>
		public DescriptionItem[] GetDescriptionItemsLikeTitle(string title)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IMedia.GetDescriptionItemsLikeTitle started");
				timer.Start();
			}
			IDescription clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetDescriptionItemsLikeTitle ({0})", timer.Elapsed);
				}
				return clt.GetDescriptionItemsLikeTitle(title);
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
					Logger.DebugFormat("Method IMedia.GetDescriptionItemsLikeTitle finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Gets the description items like title asynchronous.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="action">The action.</param>
		public void GetDescriptionItemsLikeTitleAsync(string title, Action<DescriptionItem[]> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (DescriptionItem[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetDescriptionItemsLikeTitle(title);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetDescriptionItemsLikeTitleCompleted != null)
						GetDescriptionItemsLikeTitleCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Saves the description.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns>DescriptionItem.</returns>
		public DescriptionItem SaveDescription(DescriptionItem description)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IMedia.SaveDescription started");
				timer.Start();
			}
			IDescription clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.SaveDescription ({0})", timer.Elapsed);
				}
				return clt.SaveDescription(description);
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
					Logger.DebugFormat("Method IMedia.SaveDescription finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Saves the description asynchronous.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <param name="action">The action.</param>
		public void SaveDescriptionAsync(DescriptionItem description, Action<DescriptionItem> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (DescriptionItem)null;
				wrk.DoWork += (s, e) =>
				{
					res = SaveDescription(description);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (SaveDescriptionCompleted != null)
						SaveDescriptionCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Deletes the description.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns>DescriptionItem.</returns>
		public DescriptionItem DeleteDescription(DescriptionItem description)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IMedia.DeleteDescription started");
				timer.Start();
			}
			IDescription clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.DeleteDescription ({0})", timer.Elapsed);
				}
				return clt.DeleteDescription(description);
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
					Logger.DebugFormat("Method IMedia.DeleteDescription finished ({0})", timer.Elapsed);
				}
			}
		}

        /// <summary>
        /// Saves the descriptions.
        /// </summary>
        /// <param name="descriptions">The descriptions.</param>
        /// <returns>DescriptionItem[][].</returns>
        public DescriptionItem[] SaveDescriptions(DescriptionItem[] descriptions)
        {
            var clt = CreateClient();
            try
            {
                return clt.SaveDescriptions(descriptions);
            }
            finally 
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Deletes the description asynchronous.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <param name="action">The action.</param>
		public void DeleteDescriptionAsync(DescriptionItem description, Action<DescriptionItem> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (DescriptionItem)null;
				wrk.DoWork += (s, e) =>
				{
					res = DeleteDescription(description);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (DeleteDescriptionCompleted != null)
						DeleteDescriptionCompleted(res);
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
		    return MediaServiceConst.Namespace;
		}
			
		#endregion		


	}
}