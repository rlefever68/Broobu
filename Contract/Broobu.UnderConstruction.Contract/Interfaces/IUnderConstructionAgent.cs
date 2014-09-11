using System.Collections.Generic;
using Pms.UnderConstruction.Contract.Domain;

namespace Pms.UnderConstruction.Contract.Interfaces
{
    public interface IUnderConstructionAgent 
    {
        IEnumerable<UnderConstructionInfo> GetInfo();
    }
}