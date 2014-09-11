using Iris.SimpleDb.Adapter.Domain;
using Iris.SimpleDb.Adapter.ServiceRef;

namespace Iris.SimpleDb.Adapter.Mappers
{
    public static class DomainMetadataMapper
    {
        public static DomainMetadataRequest MapToService(DomainMetadataInfo info)
        {
            var helper = new DomainMetadataHelper();
            return helper.MapToService(info);
        }


        public static DomainMetadataInfo MapToInfo(DomainMetadataResponse resp)
        {
            var helper = new DomainMetadataHelper();
            return helper.MapToInfo(resp);
        }


    }
}