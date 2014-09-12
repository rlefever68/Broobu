using System;
using Broobu.Disco.Business.Interfaces;
using Wulka.Agent;
using Wulka.Domain;
using Wulka.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Broobu.Disco.Contract.Test
{
    [TestClass]
    public class CloudContractTestFixture : ICloudContract
    {
        [TestMethod]
        public void Try_SaveCloudContract()
        {
            var c = new CloudContract() { 
                Id = "Test:CloudContract-you-cant-touch-me:ITest",
                Address = "http://www.someaddress.com/Still",
                Behaviour = "IBehave",
                Binding = "Net.Pope",
                ContractName = "SomeContract"
            };
            var res = SaveCloudContract(c);
            Console.WriteLine(res);
        }

        public CloudContract GetCloudContract(string contractId)
        {
            return DiscoPortal
                .CloudContracts
                .GetCloudContract(contractId);
        }

        public CloudContract[] SaveCloudContracts(CloudContract[] contracts)
        {
            return DiscoPortal
                .CloudContracts
                .SaveCloudContracts(contracts);

        }

        public CloudContract SaveCloudContract(CloudContract contract)
        {
            return DiscoPortal
                .CloudContracts
                .SaveCloudContract(contract);
        }
    }
}
