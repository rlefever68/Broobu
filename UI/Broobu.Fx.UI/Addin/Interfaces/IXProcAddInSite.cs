using System.Windows.Input;
using System.Windows.Interop;

namespace Broobu.Fx.UI.Addin.Interfaces
{
    public interface IXProcAddInSite
    {
        int HostProcessId { get; }
        void SetAddIn(IXProcAddIn addin);
        bool TabOut(TraversalRequest request);
        bool TranslateAccelerator(MSG msg);
    };
}