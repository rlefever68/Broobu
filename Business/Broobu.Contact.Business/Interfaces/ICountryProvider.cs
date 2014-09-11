using Broobu.Contact.Contract.Interfaces;

namespace Broobu.Contact.Business.Interfaces
{
    public interface ICountryProvider : ICountry
    {
        void RegisterRequiredObjects();
    }
}