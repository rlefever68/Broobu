using System.Collections.Generic;
using Pms.UnderConstruction.Contract.Domain;

namespace Pms.UnderConstruction.Business.Interfaces
{
    public interface IUnderConstructionProvider
    {
        IEnumerable<UnderConstructionInfo> GetInfo();
    }
}