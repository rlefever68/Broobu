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
using Broobu.Taxonomy.Contract.Domain;
using Broobu.Taxonomy.Contract.Interfaces;
using Wulka.Networking.Wcf;
using Description = Broobu.Taxonomy.Contract.Domain.Description;

namespace Broobu.Taxonomy.Contract.Agent
{
    /// <summary>
    /// Class MediaAgent.
    /// </summary>
	class DescriptionAgent: DiscoProxy<ITranslate>, ITranslateAgent
	{
		#region Events

        public DescriptionAgent(string discoUrl) 
            : base(discoUrl)
        {
        }

        /// <summary>
        /// Occurs when [get description item completed].
        /// </summary>
		public event Action<Description> GetDescriptionCompleted;
        /// <summary>
        /// Occurs when [get description items for object completed].
        /// </summary>
		public event Action<Description[]> GetDescriptionsForObjectCompleted;
        /// <summary>
        /// Occurs when [get description items for type completed].
        /// </summary>
		public event Action<Description[]> GetDescriptionsForTypeCompleted;
        /// <summary>
        /// Occurs when [get description items for culture completed].
        /// </summary>
		public event Action<Description[]> GetDescriptionsForCultureCompleted;
        /// <summary>
        /// Occurs when [get description items for object and culture completed].
        /// </summary>
		public event Action<Description[]> GetDescriptionsForObjectAndCultureCompleted;
        /// <summary>
        /// Occurs when [get description items for object and type completed].
        /// </summary>
		public event Action<Description[]> GetDescriptionsForObjectAndTypeCompleted;
        /// <summary>
        /// Occurs when [get description items for object culture and type completed].
        /// </summary>
		public event Action<Description[]> GetDescriptionsForObjectCultureAndTypeCompleted;
        /// <summary>
        /// Occurs when [get description items for culture and type completed].
        /// </summary>
		public event Action<Description[]> GetDescriptionsForCultureAndTypeCompleted;
        /// <summary>
        /// Occurs when [get description items like title completed].
        /// </summary>
		public event Action<Description[]> GetDescriptionsLikeTitleCompleted;
        /// <summary>
        /// Occurs when [save description completed].
        /// </summary>
		public event Action<Description> SaveDescriptionCompleted;
        /// <summary>
        /// Occurs when [delete description completed].
        /// </summary>
		public event Action<Description> DeleteDescriptionCompleted;
		
		#endregion		
		#region Methods
        /// <summary>
        /// Gets the description item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Description.</returns>
		public Description GetDescription(string id)
		{
			var timer = new System.Diagnostics.Stopwatch();
			ITranslate clt = null;
			try
			{
				clt = CreateClient();
				return clt.GetDescription(id);
			}
			finally
			{
				CloseClient(clt);
			}
		}

       

        /// <summary>
        /// Gets the description item asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="action">The action.</param>
		public void GetDescriptionAsync(string id, Action<Description> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Description)null;
				wrk.DoWork += (s, e) =>
				{
					res = GetDescription(id);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetDescriptionCompleted != null)
						GetDescriptionCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the description items for object.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <returns>Description[][].</returns>
		public Description[] GetDescriptionsForObject(string objectId, string displayName)
		{
			var timer = new System.Diagnostics.Stopwatch();
			ITranslate clt = null;
			try
			{
				clt = CreateClient();
				return clt.GetDescriptionsForObject(objectId, displayName);
			}
			finally
			{
				CloseClient(clt);
			}
		}
        /// <summary>
        /// Gets the description items for object asynchronous.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <param name="action">The action.</param>
		public void GetDescriptionsForObjectAsync(string objectId, string displayName, Action<Description[]> action = null)
		{
			using(var wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Description[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetDescriptionsForObject(objectId,displayName);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetDescriptionsForObjectCompleted != null)
						GetDescriptionsForObjectCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the type of the description items for.
        /// </summary>
        /// <param name="typeId">The type identifier.</param>
        /// <returns>Description[][].</returns>
		public Description[] GetDescriptionsForType(string typeId)
		{
			var timer = new System.Diagnostics.Stopwatch();
			ITranslate clt = null;
			try
			{
				clt = CreateClient();
				return clt.GetDescriptionsForType(typeId);
			}
			finally
			{
				CloseClient(clt);
			}
		}
        /// <summary>
        /// Gets the description items for type asynchronous.
        /// </summary>
        /// <param name="typeId">The type identifier.</param>
        /// <param name="action">The action.</param>
		public void GetDescriptionsForTypeAsync(string typeId, Action<Description[]> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Description[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetDescriptionsForType(typeId);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetDescriptionsForTypeCompleted != null)
						GetDescriptionsForTypeCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the description items for culture.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <returns>Description[][].</returns>
		public Description[] GetDescriptionsForCulture(string objectId)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			ITranslate clt = null;
			try
			{
				clt = CreateClient();
				return clt.GetDescriptionsForCulture(objectId);
			}
			finally
			{
				CloseClient(clt);
			}
		}
        /// <summary>
        /// Gets the description items for culture asynchronous.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <param name="action">The action.</param>
		public void GetDescriptionsForCultureAsync(string objectId, Action<Description[]> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Description[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetDescriptionsForCulture(objectId);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetDescriptionsForCultureCompleted != null)
						GetDescriptionsForCultureCompleted(res);
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
        /// <returns>Description[][].</returns>
		public Description[] GetDescriptionsForObjectAndCulture(string objectId, string cultureId)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			ITranslate clt = null;
			try
			{
				clt = CreateClient();
				return clt.GetDescriptionsForObjectAndCulture(objectId, cultureId);
			}
			finally
			{
				CloseClient(clt);
			}
		}
        /// <summary>
        /// Gets the description items for object and culture asynchronous.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <param name="cultureId">The culture identifier.</param>
        /// <param name="action">The action.</param>
		public void GetDescriptionsForObjectAndCultureAsync(string objectId, string cultureId, Action<Description[]> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Description[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetDescriptionsForObjectAndCulture(objectId, cultureId);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetDescriptionsForObjectAndCultureCompleted != null)
						GetDescriptionsForObjectAndCultureCompleted(res);
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
        /// <returns>Description[][].</returns>
		public Description[] GetDescriptionsForObjectAndType(string objectId, string typeId)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			ITranslate clt = null;
			try
			{
				clt = CreateClient();
				return clt.GetDescriptionsForObjectAndType(objectId, typeId);
			}
			finally
			{
				CloseClient(clt);
			}
		}
        /// <summary>
        /// Gets the description items for object and type asynchronous.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <param name="typeId">The type identifier.</param>
        /// <param name="action">The action.</param>
		public void GetDescriptionsForObjectAndTypeAsync(string objectId, string typeId, Action<Description[]> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Description[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetDescriptionsForObjectAndType(objectId, typeId);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetDescriptionsForObjectAndTypeCompleted != null)
						GetDescriptionsForObjectAndTypeCompleted(res);
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
        /// <returns>Description[][].</returns>
		public Description[] GetDescriptionsForObjectCultureAndType(string objectId, string cultureId, string typeId)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			ITranslate clt = null;
			try
			{
				clt = CreateClient();
				return clt.GetDescriptionsForObjectCultureAndType(objectId, cultureId, typeId);
			}
			finally
			{
				CloseClient(clt);
			}
		}
        /// <summary>
        /// Gets the description items for object culture and type asynchronous.
        /// </summary>
        /// <param name="objectId">The object identifier.</param>
        /// <param name="cultureId">The culture identifier.</param>
        /// <param name="typeId">The type identifier.</param>
        /// <param name="action">The action.</param>
		public void GetDescriptionsForObjectCultureAndTypeAsync(string objectId, string cultureId, string typeId, Action<Description[]> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Description[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetDescriptionsForObjectCultureAndType(objectId, cultureId, typeId);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetDescriptionsForObjectCultureAndTypeCompleted != null)
						GetDescriptionsForObjectCultureAndTypeCompleted(res);
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
        /// <returns>Description[][].</returns>
		public Description[] GetDescriptionsForCultureAndType(string cultureId, string typeId)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			ITranslate clt = null;
			try
			{
				clt = CreateClient();
				return clt.GetDescriptionsForCultureAndType(cultureId, typeId);
			}
			finally
			{
				CloseClient(clt);
			}
		}
        /// <summary>
        /// Gets the description items for culture and type asynchronous.
        /// </summary>
        /// <param name="cultureId">The culture identifier.</param>
        /// <param name="typeId">The type identifier.</param>
        /// <param name="action">The action.</param>
		public void GetDescriptionsForCultureAndTypeAsync(string cultureId, string typeId, Action<Description[]> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Description[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetDescriptionsForCultureAndType(cultureId, typeId);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetDescriptionsForCultureAndTypeCompleted != null)
						GetDescriptionsForCultureAndTypeCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the description items like title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>Description[][].</returns>
		public Description[] GetDescriptionsLikeTitle(string title)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			ITranslate clt = null;
			try
			{
				clt = CreateClient();
				return clt.GetDescriptionsLikeTitle(title);
			}
			finally
			{
				CloseClient(clt);
			}
		}
        /// <summary>
        /// Gets the description items like title asynchronous.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="action">The action.</param>
		public void GetDescriptionsLikeTitleAsync(string title, Action<Description[]> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Description[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetDescriptionsLikeTitle(title);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetDescriptionsLikeTitleCompleted != null)
						GetDescriptionsLikeTitleCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Saves the description.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns>Description.</returns>
		public Description SaveDescription(Description description)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			ITranslate clt = null;
			try
			{
				clt = CreateClient();
				return clt.SaveDescription(description);
			}
			finally
			{
				CloseClient(clt);
			}
		}
        /// <summary>
        /// Saves the description asynchronous.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <param name="action">The action.</param>
		public void SaveDescriptionAsync(Description description, Action<Description> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Description)null;
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
        /// <returns>Description.</returns>
		public Description DeleteDescription(Description description)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			ITranslate clt = null;
			try
			{
				clt = CreateClient();
				return clt.DeleteDescription(description);
			}
			finally
			{
				CloseClient(clt);
			}
		}

        /// <summary>
        /// Saves the descriptions.
        /// </summary>
        /// <param name="descriptions">The descriptions.</param>
        /// <returns>Description[][].</returns>
        public Description[] SaveDescriptions(Description[] descriptions)
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
		public void DeleteDescriptionAsync(Description description, Action<Description> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Description)null;
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
		    return TaxonomyConst.Namespace;
		}
			
		#endregion		


	}
}