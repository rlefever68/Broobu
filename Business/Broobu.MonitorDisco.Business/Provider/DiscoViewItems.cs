using System;
using System.Linq;
using Broobu.MonitorDisco.Business.Interfaces;
using Broobu.MonitorDisco.Business.Mappers;
using Broobu.MonitorDisco.Contract.Domain;
using Wulka.Agent;
using Wulka.Exceptions;
using NLog;


namespace Broobu.MonitorDisco.Business.Provider
{
    class DiscoViewItems : IDiscoViewItems
    {

        private static readonly Logger Log = LogManager.GetLogger("DiscoViewItems");
        /// <summary>
        /// Gets all endpoints.
        /// </summary>
        /// <returns></returns>
        public DiscoInfo[] GetAllEndpoints()
        {
            try
            {
                return DiscoPortal
                    .Disco
                    .GetAllEndpointAddresses()
                    .Select(x=>x.ToDiscoInfo())
                    .ToArray();
            }
            catch (Exception ex)
            {
                Log.Error(ex.GetCombinedMessages());
                throw;
            }
        }

    }
}
