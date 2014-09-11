using System.Linq;
using Pms.UnderConstruction.Business;
using Pms.UnderConstruction.Contract.Domain;
using Pms.UnderConstruction.Contract.Interfaces;

namespace Pms.UnderConstruction.Service
{
    public class UnderConstructionService : IUnderConstructionService
    {
        public UnderConstructionInfo[] GetInfo()
        {
            return UnderConstructionProviderFactory
                .CreateProvider(UnderConstructionProviderFactory.Key.Mock)
                .GetInfo()
                .ToArray();
        }
    }
}
