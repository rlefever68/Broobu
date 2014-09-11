using Broobu.Contact.Contract.Domain;
using Broobu.Contact.Contract.Interfaces;
using Iris.Fx.Interfaces;

namespace Broobu.Contact.Business.Interfaces
{
    public interface IAddressProvider : IAddress
    {
        void RegisterRequiredObjects();
    }
}