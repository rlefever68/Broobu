using System.Collections.Generic;
using Broobu.Authentication.Contract.Domain;
using Broobu.EcoSpace.Contract.Domain.Account;
using Broobu.EcoSpace.Contract.Domain.Applets;
using Broobu.EcoSpace.Contract.Domain.Eco;
using Broobu.EcoSpace.Contract.Domain.Links;
using Broobu.EcoSpace.Contract.Domain.Menu;
using Broobu.EcoSpace.Contract.Domain.Roles;
using Broobu.EcoSpace.Contract.Interfaces;

namespace Broobu.EcoSpace.Business.Interfaces
{
    public interface IEcoSpaces 
    {
        void Inflate();
        MenuContainer GetMenuForUser(string userName, string userCulture);
        AppletContainer GetAppletsForUser(string userName);
        UserEnvironmentInfo GetUserInfo(string userId, string fullName, string ecoSpaceId = null);
        MembershipContainer GetRoleMemberships(string userId, string ecoSpaceId = null);
        IEcoSpaceMembership RegisterAccountForEcoSpace(string accountId, string ecoSpaceId);
        EcoSpaceDocument GetEcoSpace(string id);
        EcoSpaceDocument SaveEcoSpace(EcoSpaceDocument doc);
        
        IEnumerable<IEcoSpaceMembership> GetEcoSpaceMemberships(string ecoSpaceId = null);
        IEnumerable<IEcoSpaceMembership> GetKnownEcoSpaces(string accountId);
        IEnumerable<IRoleMembership> GetRoleMemberships(IRole role, string ecoSpaceId = null);

        IRoleMembership RegisterRoleMembership(IRole role, string accountId);
    }
}