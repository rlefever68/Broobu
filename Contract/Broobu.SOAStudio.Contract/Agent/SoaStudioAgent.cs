using Pms.Framework.Networking.Wcf;
using Pms.SoaStudio.Contract.Domain;
using Pms.SoaStudio.Contract.Interfaces;
using System;

namespace Pms.SoaStudio.Contract.Agent
{
	partial class SoaStudioAgent: DiscoProxy<ISoaStudio>, ISoaStudioAgent
	{
		#region Events
		public event Action<DiscoViewItem[]> GetDiscoveredServicesCompleted;
		
		#endregion		
		#region Methods
		public DiscoViewItem[] GetDiscoveredServices()		{
			ISoaStudio clt = null;
			try
			{
				clt = CreateClient();
				return clt.GetDiscoveredServices();
			}
			finally
			{
				CloseClient(clt);
			}
		}
		public void GetDiscoveredServicesAsync(Action<DiscoViewItem[]> action = null)		{
			using(System.ComponentModel.BackgroundWorker wrk = new System.ComponentModel.BackgroundWorker())
			{
				var res = (DiscoViewItem[])null;
				wrk.DoWork += (s, e) =>
				{
					res = GetDiscoveredServices();
				};
				wrk.RunWorkerCompleted += (s, e) =>
				{
					if (action != null)
						action(res);
					else if (GetDiscoveredServicesCompleted != null)
						GetDiscoveredServicesCompleted(res);
					wrk.Dispose();
				};
				wrk.RunWorkerAsync();
			}
			
		}
			
		#endregion		
	}
}