using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Broobu.LATI.Contract.Domain;
using Wulka.Domain;

namespace Broobu.LATI.Contract.Interfaces
{
    [ServiceContract(Namespace = LatiServiceConst.Namespace)]
    public interface ILatiSentry
    {

        [OperationContract]
        string RegisterLocation(string logItem);

        [OperationContract]
        string GetPointOfInterest(string poIId);

    }
}
