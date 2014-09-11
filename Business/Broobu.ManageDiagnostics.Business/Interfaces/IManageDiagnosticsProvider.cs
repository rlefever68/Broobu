using Pms.ManageDiagnostics.Contract.Interfaces;

namespace Pms.ManageDiagnostics.Business.Interfaces
{
    public interface IManageDiagnosticsProvider : IManageDiagnostics
    {
        void RegisterRequiredDomainObjects();
    }
}