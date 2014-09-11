using Broobu.Taxonomy.Contract.Domain;
using Broobu.Taxonomy.Contract.Interfaces;
using Wulka.Domain;

namespace Broobu.Taxonomy.Business.Interfaces
{
    public interface IHooks : IHookSentry
    {
        Hook[] InflateDomain();
    }
}
