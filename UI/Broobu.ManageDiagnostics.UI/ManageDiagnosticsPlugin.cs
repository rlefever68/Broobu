using Pms.Framework.UI;
using Pms.Framework.UI.Interfaces;

namespace Pms.ManageDiagnostics.UI
{
    public class ManageDiagnosticsPlugin : PluginBase
    {
        protected override IPluginForm CreatePluginFormInternal()
        {
            return new ManageDiagnosticsWindow();
        }
    }
}
