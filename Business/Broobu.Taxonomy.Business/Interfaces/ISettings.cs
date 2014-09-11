using Broobu.Taxonomy.Contract.Interfaces;

namespace Broobu.Taxonomy.Business.Interfaces
{
    public interface ISettings : ISetting
    {
        void RegisterRequiredDomainObjects();
    }
}
