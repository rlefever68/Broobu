using System;
using System.ServiceModel;
using Pms.Framework.Domain;

namespace Pms.SessionProxy.Contract.Interfaces
{
    [ServiceContract(Namespace=ServiceConst.Namespace)]
    public interface IValidateSession
    {
        [OperationContract]
        bool Validate(string userName, string sessionId);
    }
}
