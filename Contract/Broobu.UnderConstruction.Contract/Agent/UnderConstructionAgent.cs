using System.Collections.Generic;
using Pms.Framework.Networking.Wcf;
using Pms.UnderConstruction.Contract.Domain;
using Pms.UnderConstruction.Contract.Interfaces;

namespace Pms.UnderConstruction.Contract.Agent
{
    public class UnderConstructionAgent : DiscoProxy<IUnderConstructionService>, IUnderConstructionAgent
    {
        
        /// <summary>
        /// Gets the info.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UnderConstructionInfo> GetInfo()
        {
            return Client.GetInfo();
        }

    }
}