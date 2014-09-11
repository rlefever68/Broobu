using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Web;
using Broobu.MonitorDisco.Business.Mappers;
using Broobu.MonitorDisco.Contract.Domain;

namespace Broobu.CloudMonitor.Rest
{
    [ServiceContract]
    public interface ICloudMonitor
    {

        [OperationContract]
        [WebGet(UriTemplate = "/GetAllEndpoints")]
        DiscoInfo[] GetAllEndpoints();
    }

}
