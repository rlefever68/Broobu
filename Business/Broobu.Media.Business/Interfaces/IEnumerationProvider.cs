using Broobu.Media.Contract.Interfaces;

namespace Broobu.Media.Business.Interfaces
{
    public interface IEnumerationProvider : IEnumeration
    {
        void RegisterRequiredDomainObjects();
    }
}
