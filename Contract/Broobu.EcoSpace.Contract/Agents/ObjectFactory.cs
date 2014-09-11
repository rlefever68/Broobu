using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wulka.Domain;
using Wulka.Domain.Interfaces;

namespace Broobu.EcoSpace.Contract.Agents
{
    [Export(typeof(IObjectFactory))]
    public class ObjectFactory : IObjectFactory
    {
        public IDomainObject GetById(string id)
        {
            return EcoSpacePortal
                .EcoSpace
                .GetEcoSpace(id);
        }
    }
}
