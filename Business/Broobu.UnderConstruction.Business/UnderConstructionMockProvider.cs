using System;
using System.Collections.Generic;
using Pms.Framework.Business;
using Pms.UnderConstruction.Business.Interfaces;
using Pms.UnderConstruction.Contract.Domain;

namespace Pms.UnderConstruction.Business
{
    class UnderConstructionMockProvider : ProviderBase, IUnderConstructionProvider
    {
        public IEnumerable<UnderConstructionInfo> GetInfo()
        {
            return new[]
                       {
                           new UnderConstructionInfo() {Header = "Under Construction Header 1", Image=null, Text ="This is the Text for Under Construction Header 1"}, 
                           new UnderConstructionInfo() {Header = "Under Construction Header 2", Image=null, Text ="This is the Text for Under Construction Header 2"}, 
                           new UnderConstructionInfo() {Header = "Under Construction Header 3", Image=null, Text ="This is the Text for Under Construction Header 3"}, 
                           new UnderConstructionInfo() {Header = "Under Construction Header 4", Image=null, Text ="This is the Text for Under Construction Header 4"} 
                       };
        }
    }
}
