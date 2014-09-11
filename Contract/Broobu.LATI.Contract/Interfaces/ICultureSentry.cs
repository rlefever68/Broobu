using System.ServiceModel;

namespace Broobu.LATI.Contract.Interfaces
{
    [ServiceContract(Namespace = LatiServiceConst.Namespace)]
    public interface ICultureSentry
    {
        [OperationContract]
        string GetById(string id);

        [OperationContract]
        string[] GetCultures(string id);

        [OperationContract]
        string[] GetRegions(string id);

    }
}
