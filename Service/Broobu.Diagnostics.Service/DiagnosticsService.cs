using System;
using System.ServiceModel;
using Pms.Diagnostics.Business;
using Pms.Diagnostics.Contract.Domain;
using Pms.Diagnostics.Contract.Interfaces;
using Pms.Framework.Networking.Wcf;

namespace Pms.Diagnostics.Service
{



    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
   //[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple, IncludeExceptionDetailInFaults = true)]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class DiagnosticsService :  BusinessServiceBase, IDiagnostics
    {




       /// <summary>
       /// Registers the required domain objects.
       /// </summary>
       /// <remarks></remarks>
        protected override void RegisterRequiredDomainObjects()
        {
            
        }



        /// <summary>
        /// Gets the diagnostics run items for date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public DiagnosticsRunItem[] GetDiagnosticsRunItemsForDate(DateTime date)
        {
            return DiagnosticsProviderFactory
                .CreateProvider()
                .GetDiagnosticsRunItemsForDate(date);
        }

        /// <summary>
        /// Gets the diagnostics details for run.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public DiagnosticsRunDetailItem[] GetDiagnosticsDetailsForRun(string id)
        {
            return DiagnosticsProviderFactory
                .CreateProvider()
                .GetDiagnosticsDetailsForRun(id);
        }

    }
}
