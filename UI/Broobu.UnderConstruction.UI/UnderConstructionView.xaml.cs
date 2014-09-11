using System.ComponentModel.Composition;
using Broobu.Fx.UI.Addin;

namespace Broobu.UnderConstruction.UI
{
    /// <summary>
    /// Interaction logic for UnderConstructionWindow.xaml
    /// </summary>
    [Export(typeof(IAddInControl))]
    public partial class UnderConstructionView : IAddInControl
    {
        public UnderConstructionView()
        {
            InitializeComponent();
        }
    }
}
