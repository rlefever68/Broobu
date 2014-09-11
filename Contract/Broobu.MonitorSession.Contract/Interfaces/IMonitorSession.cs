using System.ServiceModel;
using Iris.Fx.Domain;
using Iris.MonitorSession.Contract.Domain;

namespace Iris.MonitorSession.Contract.Interfaces
{
    [ServiceContract(Namespace=ServiceConst.Namespace)]
    public interface IMonitorSession
    {
        [OperationContract]
        SessionViewItem[] GetSessions();
    }
}
