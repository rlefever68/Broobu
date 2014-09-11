using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pms.Framework.Business;
using Pms.UnderConstruction.Business.Interfaces;
using Pms.UnderConstruction.Contract.Domain;

namespace Pms.UnderConstruction.Business
{
    class UnderConstructionProvider : ProviderBase, IUnderConstructionProvider
    {
        public IEnumerable<UnderConstructionInfo> GetInfo()
        {
            throw new NotImplementedException();
        }
    }
}
