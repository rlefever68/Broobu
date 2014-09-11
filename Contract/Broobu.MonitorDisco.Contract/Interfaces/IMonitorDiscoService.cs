using System;
using System.ServiceModel;
using Pms.Framework.Domain;
using Pms.MonitorDisco.Contract.Domain;


namespace Pms.MonitorDisco.Contract.Interfaces
{
    
    [ServiceKnownType(typeof(Result))]
    [ServiceKnownType(typeof(DomainObject<DiscoViewItem>))]
    [ServiceContract(Namespace = ServiceConst.Namespace)]
    public interface IMonitorDiscoService 
    {
        [OperationContract]
        DiscoViewItem[] GetAllEndpoints();
    }
}
