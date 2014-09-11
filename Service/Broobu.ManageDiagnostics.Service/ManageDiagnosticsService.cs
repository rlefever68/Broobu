using Pms.Framework.Domain;
using Pms.Framework.Networking.Wcf;
using Pms.ManageDiagnostics.Contract.Domain;
using Pms.ManageDiagnostics.Business;
using Pms.ManageDiagnostics.Contract.Interfaces;

namespace Pms.ManageDiagnostics.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public class ManageDiagnosticsService : BusinessServiceBase, IManageDiagnostics
    {
        /// <summary>
        /// Starts the diagnostics.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public Result StartDiagnostics()
        {
            return ManageDiagnosticsProviderFactory
                .CreateProvider()
                .StartDiagnostics();
        }

        /// <summary>
        /// Adds the diagnostics package.
        /// </summary>
        /// <param name="package">The package.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public Result AddDiagnosticsPackage(byte[] package)
        {
            return ManageDiagnosticsProviderFactory
                .CreateProvider()
                .AddDiagnosticsPackage(package);
        }

      

        /// <summary>
        /// Registers the required domain objects.
        /// </summary>
        /// <remarks></remarks>
        protected override void RegisterRequiredDomainObjects()
        {
            ManageDiagnosticsProviderFactory
                .CreateProvider()
                .RegisterRequiredDomainObjects();
        }


        /// <summary>
        /// Gets the diagnostics reports by date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public DiagnosticsBatchViewItem[] GetDiagnosticsReportsByDate(System.DateTime date)
        {
            return ManageDiagnosticsProviderFactory
                .CreateProvider()
                .GetDiagnosticsReportsByDate(date);
        }

        /// <summary>
        /// Gets the diagnostics report.
        /// </summary>
        /// <param name="reportId">The report id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public DiagnosticsViewItem[] GetDiagnosticsReport(string reportId)
        {
            return ManageDiagnosticsProviderFactory
                .CreateProvider()
                .GetDiagnosticsReport(reportId);
        }
    }
}
