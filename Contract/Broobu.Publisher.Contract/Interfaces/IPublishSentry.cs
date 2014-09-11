using System.ServiceModel;

namespace Broobu.Publisher.Contract.Interfaces
{
    [ServiceContract(Namespace = PublisherConst.ServiceNamespace)]
    public interface IPublishSentry 
    {

        [OperationContract]
        string Publish(string info);

    }

    public class PublisherConst
    {
        public const string ServiceNamespace = "http://broobu.com/pub/14/08";
    }
}