using System.ServiceModel;
using Pms.Framework.Domain;
using Pms.UnderConstruction.Contract.Domain;

namespace Pms.UnderConstruction.Contract.Interfaces
{
    [ServiceContract(Namespace = ServiceConst.Namespace)]
    public interface IUnderConstructionService
    {
        [OperationContract]
        UnderConstructionInfo[] GetInfo();
    }
  
}
