using System;
using System.Windows.Input;

namespace AddIn.Interfaces
{
    public interface IXProcAddIn
    {
        IntPtr AddInWindow { get; }
        void OnAddInAttached();
        bool TabInto(TraversalRequest request);
        void ShutDown();
    };
}
