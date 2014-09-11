using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Broobu.LATI.Contract.Domain;

namespace Broobu.LATI.Contract.Interfaces
{
    [ServiceContract(Namespace = LatiServiceConst.Namespace)]
    public interface IRegionSentry
    {
        [OperationContract]
        Region SaveRegion(Region region);

        [OperationContract]
        Region GetById(string id);

    }
}
