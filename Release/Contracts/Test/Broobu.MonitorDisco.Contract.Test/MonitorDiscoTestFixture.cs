// ***********************************************************************
// Assembly         : Broobu.MonitorDisco.Contract.Test
// Author           : ON8RL
// Created          : 12-04-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-04-2013
// ***********************************************************************
// <copyright file="MonitorDiscoTestFixture.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Broobu.MonitorDisco.Contract.Agent;
using Broobu.MonitorDisco.Contract.Domain;
using Broobu.MonitorDisco.Contract.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wulka.Agent;
using Wulka.Domain;

namespace Broobu.MonitorDisco.Contract.Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class MonitorDiscoTestFixture : IMonitorDisco
    {

        /// <summary>
        /// Tries the get all endpoints.
        /// </summary>
        [TestMethod]
        public void Try_GetAllEndpoints()
        {
            var res = GetAllEndpoints();
            Console.WriteLine("Contract\tEndpoint");
            Console.WriteLine("----------------------------");
            foreach (var discoInfo in res)
            {
                Console.WriteLine("{0}\t{1}",discoInfo.Contract, discoInfo.Endpoint);
            }
            Assert.IsNotNull(res);
        }


        [TestMethod]
        public void Try_GetMonitorDiscoEndpoints()
        {
            var res = GetEndpoints(String.Format("{0}:{1}", MonitorDiscoServiceConst.Namespace, "IMonitorDisco"));
            foreach (var serializableEndpoint in res)
            {
                Console.WriteLine(String.Format("Contract: {0}", serializableEndpoint.ContractName));
            }
        }

        /// <summary>
        /// Gets the endpoints.
        /// </summary>
        /// <param name="contractType">Type of the contract.</param>
        /// <returns>SerializableEndpoint[][].</returns>
        public SerializableEndpoint[] GetEndpoints(string contractType)
        {
            return DiscoPortal
                .Disco
                .GetEndpoints(contractType);
        }



        /// <summary>
        /// Gets all endpoints.
        /// </summary>
        /// <returns>DiscoViewItem[][].</returns>
        public DiscoInfo[] GetAllEndpoints()
        {
            return MonitorDiscoPortal
                .Agent
                .GetAllEndpoints();
        }
    }
}
