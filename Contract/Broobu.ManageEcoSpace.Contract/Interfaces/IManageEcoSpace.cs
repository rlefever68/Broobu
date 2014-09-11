//	========================================================================================
//	INFO: This file is generated from a T4 template.
//  !!!	Any changes made manually will be lost next time this file is regenerated !!!
//	========================================================================================

using System;
using System.ServiceModel;
using Wulka.Domain;

namespace Broobu.ManageEcoSpace.Contract.Interfaces
{
	[ServiceContract(Namespace = ManageEcoSpaceServiceConst.Namespace)]
  	public partial interface IManageEcoSpace
  	{
        [OperationContract]
        string[] GetKnownEcoSpaces(string accountId);
        [OperationContract]
        string RegisterAccountForEcoSpace(string accountId, string ecoSpaceId);
	}
}