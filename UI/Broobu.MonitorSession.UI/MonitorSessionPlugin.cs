using Iris.Fx.UI;
using Iris.Fx.UI.Interfaces;

namespace Iris.MonitorSession.UI
{
    public class MonitorSessionPlugin : PluginBase
    {
        protected override IPluginForm CreatePluginFormInternal()
        {
            return new MonitorSessionWindow();
        }
    }
}
