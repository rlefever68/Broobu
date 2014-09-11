using Broobu.Authentication.Contract.Domain;
using Broobu.EcoSpace.Contract.Domain.Eco;
using Broobu.Taxonomy.Contract.Domain;
using Wulka.Domain.Interfaces;

namespace Broobu.EcoSpace.Contract.Domain.Links
{
    public interface IEcoSpaceMembership : ILink
    {
        IAccount Account { get; set; }
        IEcoSpaceDocument EcoSpace {get;set;}
    }
}