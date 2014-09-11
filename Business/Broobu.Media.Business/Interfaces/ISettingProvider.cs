using Broobu.Media.Contract.Interfaces;

namespace Broobu.Media.Business.Interfaces
{
    public interface ISettingProvider : ISetting
    {
        void RegisterRequiredDomainObjects();
    }
}
