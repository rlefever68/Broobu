using Broobu.Disco.Business.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wulka.Data;
using Wulka.Domain;

namespace Broobu.Disco.Business.Test
{
    [TestClass]
    public class CloudContractsTestFixture : ICloudContracts
    {
        [TestMethod]
        public void Try_SaveCloudContract()
        {
            var cc = new CloudContract() 
            {
                Id="Test:Contract-some:test", 
                Address = "An Address", 
                Behaviour = "a Behavior",
                Binding = "BasicHttp"
            };
            Provider<CloudContract>.Save(cc);
        }

        public CloudContract GetCloudContract(string contractId)
        {
            return DiscoProvider
                .CloudContracts
                .GetCloudContract(contractId);
        }

        public CloudContract[] SaveCloudContracts(CloudContract[] contracts)
        {
            return DiscoProvider
                .CloudContracts
                .SaveCloudContracts(contracts);
        }

        public CloudContract SaveCloudContract(CloudContract contract)
        {
            return DiscoProvider
                .CloudContracts
                .SaveCloudContract(contract);
        }
    }
}
