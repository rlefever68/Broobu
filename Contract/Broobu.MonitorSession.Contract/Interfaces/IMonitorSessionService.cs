using System;
using System.ServiceModel;
using Pms.MonitorSession.Contract.Domain;

namespace Pms.MonitorSession.Contract.Interfaces
{
    [ServiceContract]
    public interface IMonitorSessionService
    {
        [OperationContract]
        SessionViewItem[] GetSessions();
    }
}
