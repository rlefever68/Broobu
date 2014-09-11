
using Broobu.Taxonomy.Contract.Domain;


namespace Broobu.Taxonomy.Business.Interfaces
{
    public interface ILinks : ITaxoLinks
    {
        void RegisterRequiredDomainObject();
    }
}