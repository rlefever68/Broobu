using System;
using Broobu.Contact.Contract.Domain;
using Broobu.Contact.Contract.Interfaces;
using Broobu.Taxonomy.Contract.Domain;
using Iris.Fx.Networking.Wcf;
using log4net;

namespace Broobu.Contact.Contract.Agent
{
    /// <summary>
    /// Class CountryAgent.
    /// </summary>
	partial class CountryAgent: DiscoProxy<ICountry>, ICountryAgent
	{
		#region Fields
        /// <summary>
        /// The logger
        /// </summary>
		private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		#endregion
		#region Events
        /// <summary>
        /// Occurs when [save country item completed].
        /// </summary>
		public event Action<Country> SaveCountryItemCompleted;
        /// <summary>
        /// Occurs when [delete country item completed].
        /// </summary>
		public event Action<Country> DeleteCountryItemCompleted;
        /// <summary>
        /// Occurs when [get country item completed].
        /// </summary>
		public event Action<Country> GetCountryItemCompleted;
        /// <summary>
        /// Occurs when [get country item by name completed].
        /// </summary>
		public event Action<Country> GetCountryItemByNameCompleted;
        /// <summary>
        /// Occurs when [get country item by two letter iso region name completed].
        /// </summary>
		public event Action<Country> GetCountryItemByTwoLetterIsoRegionNameCompleted;
        /// <summary>
        /// Occurs when [get country item by three letter iso region name completed].
        /// </summary>
		public event Action<Country> GetCountryItemByThreeLetterIsoRegionNameCompleted;
        /// <summary>
        /// Occurs when [get country items completed].
        /// </summary>
		public event Action<Country[]> GetCountryItemsCompleted;
        /// <summary>
        /// Occurs when [get country items for culture completed].
        /// </summary>
		public event Action<Country[]> GetCountryItemsForCultureCompleted;
		
		#endregion		
		#region Methods
        /// <summary>
        /// Saves the country item.
        /// </summary>
        /// <param name="countryItem">The country item.</param>
        /// <returns>Broobu.Contact.Contract.Domain.CountryItem.</returns>
		public Country SaveCountryItem(Country countryItem)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method ICountry.SaveCountryItem started");
				timer.Start();
			}
			ICountry clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.SaveCountryItem ({0})", timer.Elapsed);
				}
				return clt.SaveCountryItem(countryItem);
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
					Logger.DebugFormat("Method ICountry.SaveCountryItem finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Saves the country item asynchronous.
        /// </summary>
        /// <param name="countryItem">The country item.</param>
        /// <param name="action">The action.</param>
		public void SaveCountryItemAsync(Country countryItem, Action<Country> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Country)null;
				wrk.DoWork += (s, e) =>
				{
					res = SaveCountryItem(countryItem);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (SaveCountryItemCompleted != null)
						SaveCountryItemCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Deletes the country item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Broobu.Contact.Contract.Domain.CountryItem.</returns>
		public Country DeleteCountryItem(Country item)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method ICountry.DeleteCountryItem started");
				timer.Start();
			}
			ICountry clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.DeleteCountryItem ({0})", timer.Elapsed);
				}
				return clt.DeleteCountryItem(item);
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
					Logger.DebugFormat("Method ICountry.DeleteCountryItem finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Deletes the country item asynchronous.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="action">The action.</param>
		public void DeleteCountryItemAsync(Country item, Action<Country> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Country)null;
				wrk.DoWork += (s, e) =>
				{
					res = DeleteCountryItem(item);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (DeleteCountryItemCompleted != null)
						DeleteCountryItemCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the country item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Broobu.Contact.Contract.Domain.CountryItem.</returns>
		public Country GetCountryItem(string id)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method ICountry.GetCountryItem started");
				timer.Start();
			}
			ICountry clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetCountryItem ({0})", timer.Elapsed);
				}
				return clt.GetCountryItem(id);
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
					Logger.DebugFormat("Method ICountry.GetCountryItem finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Gets the country item asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="action">The action.</param>
		public void GetCountryItemAsync(string id, Action<Country> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Country)null;
				wrk.DoWork += (s, e) =>
				{
					res = GetCountryItem(id);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetCountryItemCompleted != null)
						GetCountryItemCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the name of the country item by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Broobu.Contact.Contract.Domain.CountryItem.</returns>
		public Country GetCountryItemByName(string name)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method ICountry.GetCountryItemByName started");
				timer.Start();
			}
			ICountry clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetCountryItemByName ({0})", timer.Elapsed);
				}
				return clt.GetCountryItemByName(name);
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
					Logger.DebugFormat("Method ICountry.GetCountryItemByName finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Gets the country item by name asynchronous.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="action">The action.</param>
		public void GetCountryItemByNameAsync(string name, Action<Country> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Country)null;
				wrk.DoWork += (s, e) =>
				{
					res = GetCountryItemByName(name);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetCountryItemByNameCompleted != null)
						GetCountryItemByNameCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the name of the country item by two letter iso region.
        /// </summary>
        /// <param name="twoLetterIsoRegionName">Name of the two letter iso region.</param>
        /// <returns>Broobu.Contact.Contract.Domain.CountryItem.</returns>
		public Country GetCountryItemByTwoLetterIsoRegionName(string twoLetterIsoRegionName)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method ICountry.GetCountryItemByTwoLetterIsoRegionName started");
				timer.Start();
			}
			ICountry clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetCountryItemByTwoLetterIsoRegionName ({0})", timer.Elapsed);
				}
				return clt.GetCountryItemByTwoLetterIsoRegionName(twoLetterIsoRegionName);
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
					Logger.DebugFormat("Method ICountry.GetCountryItemByTwoLetterIsoRegionName finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Gets the country item by two letter iso region name asynchronous.
        /// </summary>
        /// <param name="twoLetterIsoRegionName">Name of the two letter iso region.</param>
        /// <param name="action">The action.</param>
		public void GetCountryItemByTwoLetterIsoRegionNameAsync(string twoLetterIsoRegionName, Action<Country> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Country)null;
				wrk.DoWork += (s, e) =>
				{
					res = GetCountryItemByTwoLetterIsoRegionName(twoLetterIsoRegionName);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetCountryItemByTwoLetterIsoRegionNameCompleted != null)
						GetCountryItemByTwoLetterIsoRegionNameCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the name of the country item by three letter iso region.
        /// </summary>
        /// <param name="threeLetterIsoRegionName">Name of the three letter iso region.</param>
        /// <returns>Broobu.Contact.Contract.Domain.CountryItem.</returns>
		public Country GetCountryItemByThreeLetterIsoRegionName(string threeLetterIsoRegionName)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method ICountry.GetCountryItemByThreeLetterIsoRegionName started");
				timer.Start();
			}
			ICountry clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetCountryItemByThreeLetterIsoRegionName ({0})", timer.Elapsed);
				}
				return clt.GetCountryItemByThreeLetterIsoRegionName(threeLetterIsoRegionName);
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
					Logger.DebugFormat("Method ICountry.GetCountryItemByThreeLetterIsoRegionName finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Gets the country item by three letter iso region name asynchronous.
        /// </summary>
        /// <param name="threeLetterIsoRegionName">Name of the three letter iso region.</param>
        /// <param name="action">The action.</param>
		public void GetCountryItemByThreeLetterIsoRegionNameAsync(string threeLetterIsoRegionName, Action<Country> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Country)null;
				wrk.DoWork += (s, e) =>
				{
					res = GetCountryItemByThreeLetterIsoRegionName(threeLetterIsoRegionName);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetCountryItemByThreeLetterIsoRegionNameCompleted != null)
						GetCountryItemByThreeLetterIsoRegionNameCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the country items.
        /// </summary>
        /// <returns>Broobu.Contact.Contract.Domain.CountryItem[].</returns>
		public Country[] GetCountryItems()
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method ICountry.GetCountryItems started");
				timer.Start();
			}
			ICountry clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetCountryItems ({0})", timer.Elapsed);
				}
				return clt.GetCountryItems();
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
					Logger.DebugFormat("Method ICountry.GetCountryItems finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Gets the country items asynchronous.
        /// </summary>
        /// <param name="action">The action.</param>
		public void GetCountryItemsAsync(Action<Country[]> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Country[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetCountryItems();
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetCountryItemsCompleted != null)
						GetCountryItemsCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
        /// <summary>
        /// Gets the country items for culture.
        /// </summary>
        /// <param name="cultureName">Name of the culture.</param>
        /// <returns>Broobu.Contact.Contract.Domain.CountryItem[].</returns>
		public Country[] GetCountryItemsForCulture(string cultureName)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method ICountry.GetCountryItemsForCulture started");
				timer.Start();
			}
			ICountry clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetCountryItemsForCulture ({0})", timer.Elapsed);
				}
				return clt.GetCountryItemsForCulture(cultureName);
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
					Logger.DebugFormat("Method ICountry.GetCountryItemsForCulture finished ({0})", timer.Elapsed);
				}
			}
		}
        /// <summary>
        /// Gets the country items for culture asynchronous.
        /// </summary>
        /// <param name="cultureName">Name of the culture.</param>
        /// <param name="action">The action.</param>
		public void GetCountryItemsForCultureAsync(string cultureName, Action<Country[]> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Country[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetCountryItemsForCulture(cultureName);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetCountryItemsForCultureCompleted != null)
						GetCountryItemsForCultureCompleted(res);
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