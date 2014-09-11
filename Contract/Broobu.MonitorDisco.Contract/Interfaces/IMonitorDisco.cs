using System.ServiceModel;
using Broobu.MonitorDisco.Contract.Domain;
using Wulka.Domain;
using System;
using Wulka.Domain.Base;

namespace Broobu.MonitorDisco.Contract.Interfaces
{
    
    [ServiceKnownType(typeof(Result))]
    [ServiceKnownType(typeof(DomainObject<DiscoInfo>))]
    [ServiceContract(Namespace = MonitorDiscoServiceConst.Namespace)]
    public interface IMonitorDisco 
    {
        [OperationContract]
        DiscoInfo[] GetAllEndpoints();
    }
}
