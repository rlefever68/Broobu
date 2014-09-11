using System.ServiceModel;
using Broobu.Fx.UI.Verbs;
using Wulka.Core;

namespace Broobu.Fx.UI.Interfaces
{
    /// <summary>
    ///     Exposes an interface for the Plugins that can be run by an IPluginHost application.
    /// </summary>
    [ServiceContract]
    public interface IPlugin
    {
        [OperationContract]
        void Terminate();

        [OperationContract]
        void ProcessVerb(VerbInfo verbInfo);

        [OperationContract]
        void SetContext(WulkaContext context);
    }
}