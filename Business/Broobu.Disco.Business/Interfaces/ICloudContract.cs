using System.ServiceModel;
using Iris.Fx.Domain;


namespace Iris.Fx.Interfaces
{
    [ServiceContract(Namespace = Broobu.Disco.Business.Interfaces.CloudContractServiceConst.Namespace)]
    [ServiceKnownType(typeof(Result))]
    [ServiceKnownType(typeof(CloudContract))]
    public interface ICloudContract
    {
        [OperationContract]
        CloudContract GetCloudContract(string contractId);
        [OperationContract]
        CloudContract[] SaveCloudContracts(CloudContract[] contract);
        [OperationContract]
        CloudContract SaveCloudContract(CloudContract contract);
    }
}
