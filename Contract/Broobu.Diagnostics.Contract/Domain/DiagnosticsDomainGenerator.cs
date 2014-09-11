using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pms.Diagnostics.Contract.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public class DiagnosticsDomainGenerator
    {
        /// <summary>
        /// Creates the new batch.
        /// </summary>
        /// <param name="runId">The run id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static DiagnosticsRunItem CreateNewBatch(string runId)
        {
            return new DiagnosticsRunItem()
            {
                Id = runId,
                StartTime = DateTime.Now,
                Info = String.Format("Diagnostics Run [{0}]", runId),
                Status = DiagnosticsStatus.Pending,
                EndTime = DateTime.MaxValue
            };
        }

        /// <summary>
        /// Creates the run detail.
        /// </summary>
        /// <param name="runId">The run id.</param>
        /// <param name="id">The id.</param>
        /// <param name="contractName">Name of the contract.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static DiagnosticsRunDetailItem CreateRunDetail(string runId, string id, string contractName, string methodName)
        {
            return new DiagnosticsRunDetailItem()
                       {
                           Id=id,
                           RunId = runId,
                           Method = methodName,
                           ServiceContract = contractName,
                           StartedAt = DateTime.Now,
                           EndedAt = DateTime.MaxValue,
                           Status = DiagnosticsStatus.Pending
                       };
        }
    }
}
