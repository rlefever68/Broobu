using System.ServiceModel;
using System.ServiceModel.Discovery;

namespace Broobu.Engine.Contract.Interfaces
{
  //  [ServiceKnownType(typeof (EndpointDiscoveryMetadata))]
    [ServiceContract]
    public interface IMirror
    {
    //    [OperationContract]
    //    void ReceiveAnnouncement(EndpointDiscoveryMetadata metadata);

        [OperationContract]
        void SubscribeToUpdates(string absoluteUri);


        [OperationContract]
        void AddMirrors(string[] mirrors);

    }
}