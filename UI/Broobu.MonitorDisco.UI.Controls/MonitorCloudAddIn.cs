using System.ComponentModel.Composition;
using Broobu.Fx.UI.Addin;
using Broobu.Fx.UI.Addin.Interfaces;

namespace Broobu.MonitorDisco.UI.Controls
{
    [Export(typeof(IXProcAddIn))]
    public class MonitorCloudAddIn : AddInBase
    {
    }
}
