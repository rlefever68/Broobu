using Pms.Diagnostics.Contract.Domain;
using Pms.Framework.Domain;

namespace Pms.Diagnostics.Business.Interfaces
{
    public interface IDiagnosticsProvider       
    {
        Result AddDiagnosticsPackage(byte[] package);
        Result RunDiagnostics();
        DiagnosticsRunItem SaveRun(DiagnosticsRunItem item);
        DiagnosticsRunDetailItem SaveRunDetail(DiagnosticsRunDetailItem item);
        DiagnosticsRunDetailItem FindRunDetail(string id);
        DiagnosticsRunItem FindRun(string id);
        DiagnosticsRunItem[] GetDiagnosticsRunItemsForDate(System.DateTime date);
        DiagnosticsRunDetailItem[] GetDiagnosticsDetailsForRun(string id);
    }
}