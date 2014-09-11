using System.ServiceModel;
using Wulka.Domain;
using Wulka.Domain.Authentication;

namespace Broobu.SessionProxy.Contract.Interfaces
{
    [ServiceContract(Namespace = SessionServiceConst.Namespace)]
    public interface ISessionProxy
    {
        [OperationContract]
        WulkaSession EndSession(WulkaSession session);

        [OperationContract]
        WulkaSession StartSession(WulkaSession session);
    }
}