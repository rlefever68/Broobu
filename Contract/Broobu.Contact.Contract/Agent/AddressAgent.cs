using System;
using Broobu.Contact.Contract.Domain;
using Broobu.Contact.Contract.Interfaces;
using Iris.Fx.Networking.Wcf;
using log4net;

namespace Broobu.Contact.Contract.Agent
{
	partial class AddressAgent: DiscoProxy<IAddress>, IAddressAgent
	{
		#region Fields
		private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		#endregion
		#region Events
		public event Action<Address> SaveAddressItemCompleted;
		public event Action<Address> DeleteAddressItemCompleted;
		public event Action<Address> GetAddressItemCompleted;
		public event Action<Address> GetAddressItemForRelationCompleted;
		public event Action<Address[]> GetAddressItemsCompleted;
		public event Action<Address[]> GetAddressItemsForRelationCompleted;
		
		#endregion		
		#region Methods
		public Address SaveAddressItem(Address addressItem)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IAddress.SaveAddressItem started");
				timer.Start();
			}
			IAddress clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.SaveAddressItem ({0})", timer.Elapsed);
				}
				return clt.SaveAddressItem(addressItem);
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
					Logger.DebugFormat("Method IAddress.SaveAddressItem finished ({0})", timer.Elapsed);
				}
			}
		}
		public void SaveAddressItemAsync(Address addressItem, Action<Address> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Address)null;
				wrk.DoWork += (s, e) =>
				{
					res = SaveAddressItem(addressItem);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (SaveAddressItemCompleted != null)
						SaveAddressItemCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
		public Address DeleteAddressItem(Address item)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IAddress.DeleteAddressItem started");
				timer.Start();
			}
			IAddress clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.DeleteAddressItem ({0})", timer.Elapsed);
				}
				return clt.DeleteAddressItem(item);
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
					Logger.DebugFormat("Method IAddress.DeleteAddressItem finished ({0})", timer.Elapsed);
				}
			}
		}
		public void DeleteAddressItemAsync(Address item, Action<Address> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Address)null;
				wrk.DoWork += (s, e) =>
				{
					res = DeleteAddressItem(item);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (DeleteAddressItemCompleted != null)
						DeleteAddressItemCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
		public Address GetAddressItem(string id)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IAddress.GetAddressItem started");
				timer.Start();
			}
			IAddress clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetAddressItem ({0})", timer.Elapsed);
				}
				return clt.GetAddressItem(id);
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
					Logger.DebugFormat("Method IAddress.GetAddressItem finished ({0})", timer.Elapsed);
				}
			}
		}
		public void GetAddressItemAsync(string id, Action<Address> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Address)null;
				wrk.DoWork += (s, e) =>
				{
					res = GetAddressItem(id);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetAddressItemCompleted != null)
						GetAddressItemCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
		public Address GetAddressItemForRelation(string relationId, string addressId)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IAddress.GetAddressItemForRelation started");
				timer.Start();
			}
			IAddress clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetAddressItemForRelation ({0})", timer.Elapsed);
				}
				return clt.GetAddressItemForRelation(relationId, addressId);
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
					Logger.DebugFormat("Method IAddress.GetAddressItemForRelation finished ({0})", timer.Elapsed);
				}
			}
		}
		public void GetAddressItemForRelationAsync(string relationId, string addressId, Action<Address> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Address)null;
				wrk.DoWork += (s, e) =>
				{
					res = GetAddressItemForRelation(relationId, addressId);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetAddressItemForRelationCompleted != null)
						GetAddressItemForRelationCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
		public Address[] GetAddressItems()
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IAddress.GetAddressItems started");
				timer.Start();
			}
			IAddress clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetAddressItems ({0})", timer.Elapsed);
				}
				return clt.GetAddressItems();
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
					Logger.DebugFormat("Method IAddress.GetAddressItems finished ({0})", timer.Elapsed);
				}
			}
		}
		public void GetAddressItemsAsync(Action<Address[]> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Address[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetAddressItems();
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetAddressItemsCompleted != null)
						GetAddressItemsCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
		public Address[] GetAddressItemsForRelation(string relationId)
		{
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
			if (Logger.IsDebugEnabled)
			{
				Logger.Debug("Method IAddress.GetAddressItemsForRelation started");
				timer.Start();
			}
			IAddress clt = null;
			try
			{
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Creating client ({0})", timer.Elapsed);
				}
				clt = CreateClient();
				if (Logger.IsDebugEnabled)
				{
					Logger.DebugFormat("Calling client.GetAddressItemsForRelation ({0})", timer.Elapsed);
				}
				return clt.GetAddressItemsForRelation(relationId);
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
					Logger.DebugFormat("Method IAddress.GetAddressItemsForRelation finished ({0})", timer.Elapsed);
				}
			}
		}
		public void GetAddressItemsForRelationAsync(string relationId, Action<Address[]> action = null)
		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (Address[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetAddressItemsForRelation(relationId);
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetAddressItemsForRelationCompleted != null)
						GetAddressItemsForRelationCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
		protected override string GetContractNamespace()
		{
			return ContactServiceConst.Namespace;
		}
			
		#endregion		


	}
}