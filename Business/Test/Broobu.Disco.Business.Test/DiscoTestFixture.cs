using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Broobu.Disco.Business;
using Iris.Fx.Configuration;
using Iris.Fx.Domain;
using Iris.Fx.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iris.Disco.Business.Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class DiscoTestFixture : IDisco
    {
        public DiscoTestFixture()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Try_GetAllEndpoints()
        {
            SerializableEndpoint[] res = GetAllEndpoints();
            foreach (var serializableEndpoint in res)
            {
                Console.WriteLine(String.Format("Contract Name: {0} \t Address: {1}", serializableEndpoint.ContractName, serializableEndpoint.Address.Uri));
            }
        }

        public SerializableEndpoint[] GetEndpoints(string contractType)
        {
            return new SerializableEndpoint[] {};
        }

        public SerializableEndpoint[] GetAllEndpoints()
        {
            return DiscoProvider
                .Discos
                .GetAllEndpoints();
        }

        public DiscoItem[] GetAllEndpointAddresses()
        {
            return new DiscoItem[] {};
        }
    }
}
