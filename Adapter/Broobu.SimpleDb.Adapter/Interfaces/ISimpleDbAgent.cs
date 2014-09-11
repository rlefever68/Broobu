using Iris.SimpleDb.Adapter.Domain;

namespace Iris.SimpleDb.Adapter.Interfaces
{
    public interface ISimpleDbAgent
    {
        /// <summary>
        /// Creates the domain.
        /// </summary>
        /// <param name="domainName">Name of the domain.</param>
        /// <returns>DomainInfo.</returns>
        CreateDomainInfo CreateDomain(string domainName);

        /// <summary>
        /// Lists the domains.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>ListDomainsResponse1.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        ListDomainsInfo ListDomains();

        DomainMetadataInfo DomainMetadata(string domainName);
    }
}