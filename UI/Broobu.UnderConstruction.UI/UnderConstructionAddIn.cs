using System.ComponentModel.Composition;
using System.Windows.Controls;
using Broobu.Fx.UI.Addin;
using Broobu.Fx.UI.Addin.Interfaces;

namespace Broobu.UnderConstruction.UI
{
    [Export(typeof(IXProcAddIn))]
    public class UnderConstructionAddIn : AddInBase
    {
    }
}