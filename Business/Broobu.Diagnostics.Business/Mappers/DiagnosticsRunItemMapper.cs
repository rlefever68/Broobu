using System;
using Pms.Diagnostics.Contract.Domain;
using Pms.Diagnostics.Repository.Contract.Domain;
using Pms.Framework.Core;


namespace Pms.Diagnostics.Business.Mappers
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    class DiagnosticsRunItemMapper : MapperBase<DiagnosticsRun,DiagnosticsRunItem>
    {

        /// <summary>
        /// Maps from business to service internal.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected override DiagnosticsRunItem MapFromServiceToBusinessInternal(DiagnosticsRun source)
        {
            return new DiagnosticsRunItem()
            {
                EndTime = Convert.ToDateTime(source.EndedAt),
                Info = source.Info,
                StartTime = Convert.ToDateTime(source.StartedAt),
                Status = source.StatusId
            };
        }

        /// <summary>
        /// Maps from service to business internal.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected override DiagnosticsRun MapFromBusinessToServiceInternal(DiagnosticsRunItem target)
        {
            return new DiagnosticsRun()
            {
                Id = target.Id,
                EndedAt = target.EndTime,
                ExtensionData = target.ExtensionData,
                Info = target.Info,
                StartedAt = target.StartTime,
                StatusId = target.Status
            };

        }

    }
}
