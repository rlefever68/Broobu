using System;
using System.Collections.Generic;
using Broobu.EcoSpace.Contract.Domain.Account;
using Broobu.EcoSpace.Contract.Domain.Eco;
using Broobu.EcoSpace.Contract.Domain.Links;
using Broobu.EcoSpace.Contract.Domain.Roles;
using Wulka.Domain;


namespace Broobu.EcoSpace.Contract.Interfaces
{
    public interface IEcoSpaceAgent  : IEcoSpaceBase
    {
        void GetEcoSpaceMembershipsAsync(string ecoSpaceId = null, Action<IEnumerable<IEcoSpaceMembership>> act = null);
        void GetKnownEcoSpacesAsync(string accountId, Action<IEnumerable<IEcoSpaceMembership>> act = null);
        void RegisterAccountForEcoSpaceAsync(string accountId, string ecoSpaceId, Action<IEcoSpaceMembership> act = null);
        void GetRoleMembershipsAsync(IRole role, Action<IEnumerable<IRoleMembership>> action = null);
        void RegisterRoleMembershipAsync(IRole role, string id, Action<IRoleMembership> action=null);
        void GetEcoSpaceAsync(string ecoSpaceId, Action<IEcoSpaceDocument> action = null);
    }
}