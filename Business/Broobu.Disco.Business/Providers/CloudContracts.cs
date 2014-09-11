using System;
using System.Collections.Generic;
using Broobu.Disco.Business.Interfaces;
using Wulka.Data;
using Wulka.Domain;
using Wulka.Exceptions;
using Wulka.Logging;


namespace Broobu.Disco.Business.Providers
{
    public class CloudContracts : ICloudContracts
    {

       

        /// <summary>
        /// Gets the cloud contract.
        /// </summary>
        /// <param name="contractId">The contract identifier.</param>
        /// <returns>CloudContract.</returns>
        public CloudContract GetCloudContract(string contractId)
        {
            FxLog<CloudContracts>.DebugFormat("Get Cloud Contract: {0}", contractId);
            var res = Provider<CloudContract>.GetById(contractId);
            FxLog<CloudContracts>.DebugFormat("\t{0} | {1}", res.Id, res.Binding);
            return res;
        }

        /// <summary>
        /// Saves the cloud contracts.
        /// </summary>
        /// <param name="contracts">The contracts.</param>
        /// <returns>CloudContract[][].</returns>
        public CloudContract[] SaveCloudContracts(CloudContract[] contracts)
        {
            var lst = new List<CloudContract>();
            FxLog<CloudContracts>.DebugFormat("Registering Cloud Contracts:");
            foreach (var cloudContract in contracts)
            {
                try
                {
                    var res = SaveCloudContract(cloudContract);
                    lst.Add(res);
                }
                catch (Exception ex)
                {
                    FxLog<CloudContracts>.LogException(ex);
                    cloudContract.AddError(ex.Message);
                    lst.Add(cloudContract);
                }
            }
            return lst.ToArray();
        }

        /// <summary>
        /// Saves the cloud contract.
        /// </summary>
        /// <param name="contract">The contract.</param>
        /// <returns>CloudContract.</returns>
        public CloudContract SaveCloudContract(CloudContract contract)
        {
                FxLog<CloudContracts>.DebugFormat("Registering service contract for [{0}]", contract.Id);
                try
                {
                    contract = Provider<CloudContract>.Save(contract);
                }
                catch (Exception ex)
                {
                    FxLog<CloudContracts>.LogException(ex);
                    contract.AddError(ex.Message);
                }
                return contract;

        }

    }
}