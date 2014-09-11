using Iris.SimpleDb.Adapter.Domain;
using Iris.SimpleDb.Adapter.ServiceRef;

namespace Iris.SimpleDb.Adapter.Mappers
{
    public class ListDomainsMapperHelper : SimpleDbMapperHelperBase<ListDomainsInfo,ListDomainsRequest, ListDomainsResponse>
    {
        public override ListDomainsRequest MapToService(ListDomainsInfo info)
        {
            return new ListDomainsRequest();
        }

        public override ListDomainsInfo MapToInfo(ListDomainsResponse resp)
        {
            return new ListDomainsInfo()
            {
                Metadata = ResponseMetadataMapper.MapToInfo(resp.ResponseMetadata), 
                DomainNames = resp.ListDomainsResult.DomainName, 
                NextToken = resp.ListDomainsResult.NextToken
            };
        }
    }
}