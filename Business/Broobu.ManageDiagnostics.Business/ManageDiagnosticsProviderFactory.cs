using System;
using Pms.ManageDiagnostics.Business.Interfaces;

namespace Pms.ManageDiagnostics.Business
{
    public class ManageDiagnosticsProviderFactory
    {
        public static IManageDiagnosticsProvider CreateProvider()
        {
            return new ManageDiagnosticsProvider();
        }
    }
}
