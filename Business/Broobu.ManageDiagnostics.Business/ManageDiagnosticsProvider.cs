using System.Collections.Generic;
using Pms.Diagnostics.Contract.Domain;
using Pms.DiagnosticsWorker.Contract.Agent;
using Pms.Framework.Domain;
using Pms.ManageDiagnostics.Business.Interfaces;
using Pms.Diagnostics.Contract.Agent;
using Pms.ManageDiagnostics.Business.Mappers;
using Pms.ManageDiagnostics.Contract.Domain;

namespace Pms.ManageDiagnostics.Business
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    class ManageDiagnosticsProvider : IManageDiagnosticsProvider
    {
        /// <summary>
        /// Registers the required domain objects.
        /// </summary>
        /// <remarks></remarks>
        public void RegisterRequiredDomainObjects()
        {
            
        }

        /// <summary>
        /// Starts the diagnostics.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public Result StartDiagnostics()
        {
            return DiagnosticsWorkerAgentFactory
                .CreateRunDiagnosticsAgent()
                .RunDiagnostics();
        }

        /// <summary>
        /// Adds the diagnostics package.
        /// </summary>
        /// <param name="package">The package.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public Result AddDiagnosticsPackage(byte[] package)
        {
            return DiagnosticsWorkerAgentFactory
                .CreateRunDiagnosticsAgent()
                .AddDiagnosticsPackage(package);
        }



        /// <summary>
        /// Gets the diagnostics reports by date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public DiagnosticsBatchViewItem[] GetDiagnosticsReportsByDate(System.DateTime date)
        {
            var map = new DiagnosticsBatchViewItemMapper();
            var res = DiagnosticsAgentFactory
                .CreateDiagnosticsAgent()
                .GetDiagnosticsRunItemsForDate(date);
            return map.MapFromBusinessToService(res);
        }


        /// <summary>
        /// Gets the diagnostics report.
        /// </summary>
        /// <param name="reportId">The report id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public DiagnosticsViewItem[] GetDiagnosticsReport(string reportId)
        {
            var map = new DiagnosticsViewItemMapper();
            var res = DiagnosticsAgentFactory
                .CreateDiagnosticsAgent()
                .GetDiagnosticsDetailsForRun(reportId);
            return map.MapFromServiceToBusiness(res);
        }
    }
}
