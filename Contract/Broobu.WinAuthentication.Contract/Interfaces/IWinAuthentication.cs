using System.ServiceModel;
using Iris.Fx.Domain;

namespace Iris.WinAuthentication.Contract.Interfaces
{
    [ServiceContract(Namespace = ServiceConst.Namespace)]
    public interface IWinAuthentication
    {
        [OperationContract]
        IrisSession AuthenticateUserCredentials();
    }
}
