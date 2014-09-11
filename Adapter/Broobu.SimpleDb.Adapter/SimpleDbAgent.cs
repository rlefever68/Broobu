using Iris.SimpleDb.Adapter.Domain;
using Iris.SimpleDb.Adapter.Interfaces;
using Iris.SimpleDb.Adapter.Mappers;
using Iris.SimpleDb.Adapter.ServiceRef;

namespace Iris.SimpleDb.Adapter
{
    class SimpleDbAgent : ISimpleDbAgent
    {

        /// <summary>
        /// Creates the domain.
        /// </summary>
        /// <param name="domainName">Name of the domain.</param>
        /// <returns>DomainInfo.</returns>
        public CreateDomainInfo CreateDomain(string domainName)
        {
            using (var clt = new AmazonSDBPortTypeClient())
            {
                try
                {
                    var info = new CreateDomainInfo() {DomainName = domainName};
                    var req = CreateDomainMapper.MapToService(info);
                    clt.Open();
                    var rsp = clt.CreateDomain(req);
                    return CreateDomainMapper.MapToInfo(rsp.CreateDomainResponse);
                }
                finally
                {
                    clt.Close();
                }
            }
        }


        /// <summary>
        /// Lists the domains.
        /// </summary>
        /// <returns>ListDomainsResponse1.</returns>
        public ListDomainsInfo ListDomains()
        {
            using (var clt = new AmazonSDBPortTypeClient())
            {
                try
                {
                    var req = new ListDomainsRequest();
                    clt.Open();
                    var rsp = clt.ListDomains(req);
                    return ListDomainsMapper.MapToInfo(rsp.ListDomainsResponse);
                }
                finally
                {
                    clt.Close();
                }
            }

        }

        public DomainMetadataInfo DomainMetadata(string domainName)
        {
            using (var clt = new AmazonSDBPortTypeClient())
            {
                try
                {
                    var req = new DomainMetadataRequest(new DomainMetadata() {DomainName = domainName});
                    clt.Open();
                    var rsp = clt.DomainMetadata(req);
                    return DomainMetadataMapper.MapToInfo(rsp.DomainMetadataResponse);
                }
                finally
                {
                    clt.Close();
                }
            }
        }
    }
}

