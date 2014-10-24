// ***********************************************************************
// Assembly         : Iris.Disco.Business.Test
// Author           : Rafael Lefever
// Created          : 09-11-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 10-23-2014
// ***********************************************************************
// <copyright file="DiscoTestFixture.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wulka.Domain;
using Wulka.Interfaces;

namespace Broobu.Disco.Business.Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class DiscoTestFixture : IDisco
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiscoTestFixture"/> class.
        /// </summary>
        public DiscoTestFixture()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        /// <value>The test context.</value>
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

        /// <summary>
        /// Try_s the get all endpoints.
        /// </summary>
        [TestMethod]
        public void Try_GetAllEndpoints()
        {
            SerializableEndpoint[] res = GetAllEndpoints();
            foreach (var serializableEndpoint in res)
            {
                Console.WriteLine(String.Format("Contract Name: {0} \t Address: {1}", serializableEndpoint.ContractName, serializableEndpoint.Address.Uri));
            }
        }

        /// <summary>
        /// Gets the endpoints.
        /// </summary>
        /// <param name="contractType">Type of the contract.</param>
        /// <returns>SerializableEndpoint[].</returns>
        public SerializableEndpoint[] GetEndpoints(string contractType)
        {
            return new SerializableEndpoint[] {};
        }

        /// <summary>
        /// Gets all endpoints.
        /// </summary>
        /// <returns>SerializableEndpoint[].</returns>
        public SerializableEndpoint[] GetAllEndpoints()
        {
            return DiscoProvider
                .Discos
                .GetAllEndpoints();
        }

        /// <summary>
        /// Gets all endpoint addresses.
        /// </summary>
        /// <returns>DiscoItem[].</returns>
        public DiscoItem[] GetAllEndpointAddresses()
        {
            return new DiscoItem[] {};
        }
    }
}
