using System.Collections.Generic;
using Broobu.EcoSpace.Contract.Domain.Account;
using Broobu.EcoSpace.Contract.Domain.Applets;
using Broobu.EcoSpace.Contract.Domain.Eco;
using Broobu.EcoSpace.Contract.Domain.Links;
using Broobu.EcoSpace.Contract.Domain.Menu;
using Broobu.EcoSpace.Contract.Domain.Roles;

namespace Broobu.EcoSpace.Contract.Interfaces
{
    public interface IEcoSpaceBase
    {
        MenuContainer GetMenuForUser();
        AppletContainer GetAppletsForUser();
        UserEnvironmentInfo GetUserInfo(string userId, string fullName);
        EcoSpaceDocument GetEcoSpace(string id);
        EcoSpaceDocument SaveEcoSpace(EcoSpaceDocument doc);
        IEnumerable<IEcoSpaceMembership> GetEcoSpaceMemberships(string ecoSpaceId = null);
        RoleContainer GetRoleMemberships(string userId);
        IEnumerable<IEcoSpaceMembership> GetKnownEcoSpaces(string accountId);
        IEcoSpaceMembership RegisterAccountForEcoSpace(string accountId, string ecoSpaceId=null);
        IEnumerable<IRoleMembership> GetRoleMemberships(IRole role);
        IRoleMembership RegisterRoleMembership(IRole role, string accountId);
    }
}