using Broobu.EcoSpace.Contract.Domain.Menu;
using Broobu.EcoSpace.Contract.Domain.Roles;
using Broobu.Taxonomy.Contract.Domain;
using Wulka.Domain.Interfaces;

namespace Broobu.EcoSpace.Contract.Domain.Links
{
    public interface IRoleMenuLink : ILink
    {
        IRole Role { get; set; }
        IMenuButton Button { get; set; }
    }
}