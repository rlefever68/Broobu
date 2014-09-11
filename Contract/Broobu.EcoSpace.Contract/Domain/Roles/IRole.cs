using System.Collections.Generic;
using Broobu.Authentication.Contract.Domain;
using Broobu.EcoSpace.Contract.Domain.Applets;
using Broobu.EcoSpace.Contract.Domain.Links;
using Broobu.Taxonomy.Contract.Domain;
using Wulka.Domain;
using Wulka.Domain.Interfaces;

namespace Broobu.EcoSpace.Contract.Domain.Roles
{
    public interface IRole : IEcoObject
    {
        IEnumerable<ILink> Permissions { get; }
        ILink AddPermission(ICloudApplet applet);
        void RemovePermission(ICloudApplet applet);


        IEnumerable<ILink> Memberships { get; }
        IRoleMembership AddMembership(IRoleMembership membership);
        void RemoveMembership(IAccount account);
        

    }

}