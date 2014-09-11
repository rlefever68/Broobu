using Pms.Diagnostics.Business.Interfaces;

namespace Pms.Diagnostics.Business
{
    public class DiagnosticsProviderFactory
    {

        public static IDiagnosticsProvider CreateProvider()
        {
            return new DiagnosticsProvider();
        }
    }
}
