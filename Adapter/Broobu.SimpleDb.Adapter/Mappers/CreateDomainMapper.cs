using Iris.SimpleDb.Adapter.Domain;
using Iris.SimpleDb.Adapter.ServiceRef;

namespace Iris.SimpleDb.Adapter.Mappers
{
    public class CreateDomainMapper
    {
        public static CreateDomainRequest MapToService(CreateDomainInfo info)
        {
            var helper = new CreateDomainMapperHelper();
            return helper.MapToService(info);
        }

        public static CreateDomainInfo MapToInfo(CreateDomainResponse resp)
        {
            var helper = new CreateDomainMapperHelper();
            return helper.MapToInfo(resp);
        }

    }


}
