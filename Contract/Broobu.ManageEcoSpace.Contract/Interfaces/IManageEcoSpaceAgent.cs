//	========================================================================================
//	INFO: This file is generated from a T4 template.
//  !!!	Any changes made manually will be lost next time this file is regenerated !!!
//	========================================================================================

using System;
using System.Collections.Generic;
using Broobu.EcoSpace.Contract.Domain.Links;


namespace Broobu.ManageEcoSpace.Contract.Interfaces
{
  	public interface IManageEcoSpaceAgent
  	{
        IEnumerable<IEcoSpaceMembership> GetKnownEcoSpaces(string accountId);
        IEcoSpaceMembership RegisterAccountForEcoSpace(string accountId, string ecoSpaceId);
        void GetKnownEcoSpacesAsync(string accountId, Action<IEnumerable<IEcoSpaceMembership>> act=null);
        void RegisterAccountForEcoSpaceAsync(string accountId, string ecoSpaceId, Action<IEcoSpaceMembership> act=null);
	}
}