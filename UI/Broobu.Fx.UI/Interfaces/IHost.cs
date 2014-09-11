using System.ServiceModel;
using Broobu.Fx.UI.Verbs;

namespace Broobu.Fx.UI.Interfaces
{
    [ServiceContract]
    public interface IHost
    {
        [OperationContract]
        void Broadcast(VerbInfo verbInfo);

        [OperationContract]
        void RequestShellContext();

        [OperationContract]
        void UnregisterApplet(string appletName, string id);

        [OperationContract]
        void RegisterApplet(string appletName, string id);

        [OperationContract]
        void NotifyAppletLoaded(string appletName, string appletId);
    }
}