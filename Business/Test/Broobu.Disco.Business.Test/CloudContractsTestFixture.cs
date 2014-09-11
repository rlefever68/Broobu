using System;
using Broobu.Disco.Business;
using Broobu.Disco.Business.Interfaces;
using Iris.Fx.Data;
using Iris.Fx.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iris.Disco.Business.Test
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
