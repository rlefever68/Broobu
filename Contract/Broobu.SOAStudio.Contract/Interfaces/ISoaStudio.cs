//	========================================================================================
//	INFO: This file is generated from a T4 template.
//  !!!	Any changes made manually will be lost next time this file is regenerated !!!
//	========================================================================================
using Pms.SoaStudio.Contract.Domain;
using System.ServiceModel;

namespace Pms.SoaStudio.Contract.Interfaces
{
	[ServiceContract(Namespace = Pms.Framework.Domain.ServiceConst.Namespace)]
  	public partial interface ISoaStudio
  	{
		#region Methods
		[OperationContract]
		DiscoViewItem[] GetDiscoveredServices();

		#endregion

	}
}