using Broobu.Media.Contract.Interfaces;

namespace Broobu.Media.Business.Interfaces
{
    public interface IDescriptionProvider : IDescription
    {
        void RegisterDomainObjects();
    }
}
