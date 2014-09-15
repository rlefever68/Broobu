using System.ComponentModel.Composition;
using Broobu.Fx.UI.Addin;
using Broobu.Fx.UI.Addin.Interfaces;

namespace Broobu.EcoSpace.UI.Controls
{
    [Export(typeof(IXProcAddIn))]
    public class EcoSpaceAddIn : AddInBase
    {
    }
}
