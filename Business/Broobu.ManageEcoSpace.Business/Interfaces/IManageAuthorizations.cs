using Broobu.ManageAuthorization.Contract.Interfaces;

namespace Broobu.ManageAuthorization.Business.Interfaces
{
    public interface IManageAuthorizations : IManageAuthorization
    {
        void RegisterRequiredDomainObjects();
    }
}
