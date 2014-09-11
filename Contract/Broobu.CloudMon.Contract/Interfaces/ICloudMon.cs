using System.ServiceModel;
using System.ServiceModel.Web;
using Broobu.CloudMon.Contract.Domain;
using Broobu.MonitorDisco.Contract.Domain;
using Iris.Fx.Domain;

namespace Broobu.CloudMon.Contract.Interfaces
{

    [ServiceKnownType(typeof(DomainObject<DiscoInfo>))]
    [ServiceContract(Namespace = CloudMonSentryConst.Namespace)]
    public interface ICloudMon
    {
        [OperationContract]
        [WebGet(UriTemplate = "GetEndpoints", ResponseFormat = WebMessageFormat.Json)]
        EndpointInfo[] GetEndpoints();

    }
}
