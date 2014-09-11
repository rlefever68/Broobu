using Broobu.Disco.Business;
using Wulka.Domain;
using Wulka.Interfaces;
using Wulka.Networking.Wcf;

namespace Broobu.Disco.Service
{
    public class CloudContractSentry : SentryBase, ICloudContract
    {

        /// <summary>
        /// Gets the cloud contract.
        /// </summary>
        /// <param name="contractId">The contract identifier.</param>
        /// <returns>CloudContract.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public CloudContract GetCloudContract(string contractId)
        {
            return DiscoProvider
                .CloudContracts
                .GetCloudContract(contractId);
        }

        /// <summary>
        /// Saves the cloud contracts.
        /// </summary>
        /// <param name="contracts">The contract.</param>
        /// <returns>CloudContract[][].</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public CloudContract[] SaveCloudContracts(CloudContract[] contracts)
        {
            return DiscoProvider
                .CloudContracts
                .SaveCloudContracts(contracts);
        }

        /// <summary>
        /// Saves the cloud contract.
        /// </summary>
        /// <param name="contract">The contract.</param>
        /// <returns>CloudContract.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public CloudContract SaveCloudContract(CloudContract contract)
        {
            return DiscoProvider
                .CloudContracts
                .SaveCloudContract(contract);
        }


        protected override void RegisterRequiredDomainObjects()
        {
            
        }
    }
}
