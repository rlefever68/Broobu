using Iris.SimpleDb.Adapter.Domain;
using Iris.SimpleDb.Adapter.ServiceRef;

namespace Iris.SimpleDb.Adapter.Mappers
{
    public class CreateDomainMapperHelper : SimpleDbMapperHelperBase<CreateDomainInfo,CreateDomainRequest, CreateDomainResponse>
    {

        public override CreateDomainRequest MapToService(CreateDomainInfo info)
        {
            return new CreateDomainRequest(new CreateDomain() {DomainName = info.DomainName});
        }

        public override CreateDomainInfo MapToInfo(CreateDomainResponse resp)
        {
            return new CreateDomainInfo()
            {
                Metadata = ResponseMetadataMapper.MapToInfo(resp.ResponseMetadata)
            };
        }


    }
}