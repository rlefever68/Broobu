using Iris.SimpleDb.Adapter.Domain;
using Iris.SimpleDb.Adapter.ServiceRef;

namespace Iris.SimpleDb.Adapter.Mappers
{
    public class DomainMetadataHelper : SimpleDbMapperHelperBase<DomainMetadataInfo, DomainMetadataRequest, DomainMetadataResponse >
    {
        public override DomainMetadataRequest MapToService(DomainMetadataInfo info)
        {
            return new DomainMetadataRequest()
            {
                DomainMetadata = new DomainMetadata() {DomainName = info.DomainName}
            };
        }
        
        public override DomainMetadataInfo MapToInfo(DomainMetadataResponse resp)
        {
            return new DomainMetadataInfo()
            {
                AttributeNameCount = resp.DomainMetadataResult.AttributeNameCount,
                ItemCount = resp.DomainMetadataResult.ItemCount,
                ItemNamesSizeBytes = resp.DomainMetadataResult.ItemNamesSizeBytes,
                AttributeNamesSizeBytes = resp.DomainMetadataResult.AttributeNamesSizeBytes,
                AttributeValueCount = resp.DomainMetadataResult.AttributeValueCount,
                AttributeValuesSizeBytes = resp.DomainMetadataResult.AttributeValuesSizeBytes,
                Timestamp = resp.DomainMetadataResult.Timestamp,
                Metadata = ResponseMetadataMapper.MapToInfo(resp.ResponseMetadata)
            };
        }
    }
}