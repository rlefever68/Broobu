//	========================================================================================
//	INFO: This file is generated from a T4 template.
//  !!!	Any changes made manually will be lost next time this file is regenerated !!!
//	========================================================================================
using Pms.SoaStudio.Contract.Domain;
using System;

namespace Pms.SoaStudio.Contract.Interfaces
{
  	public partial interface ISoaStudioAgent: ISoaStudio
  	{
		#region Events
		event Action<DiscoViewItem[]> GetDiscoveredServicesCompleted;

		#endregion
		#region Methods
		void GetDiscoveredServicesAsync(Action<DiscoViewItem[]> action = null);

		#endregion

	}
}