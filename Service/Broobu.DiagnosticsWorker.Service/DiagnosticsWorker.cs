using System.ServiceModel;
using Pms.Diagnostics.Business;
using Pms.DiagnosticsWorker.Contract.Interfaces;
using Pms.Framework.Domain;
using Pms.Framework.Networking.Wcf;

namespace Pms.DiagnosticsWorker.Service
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class DiagnosticsWorker: BusinessServiceBase,IRunDiagnostics
    {
        
        /// <summary>
        /// Runs the diagnostics.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public Result RunDiagnostics()
        {
            return DiagnosticsProviderFactory
                .CreateProvider()
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
            return DiagnosticsProviderFactory
                .CreateProvider()
                .AddDiagnosticsPackage(package);
        }


        protected override void RegisterRequiredDomainObjects()
        {
            
        }
    }
}
