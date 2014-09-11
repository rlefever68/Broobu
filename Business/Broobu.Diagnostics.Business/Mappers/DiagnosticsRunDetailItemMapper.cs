using System;
using System.Linq;
using Pms.Diagnostics.Contract.Domain;
using Pms.Diagnostics.Repository.Contract.Domain;
using Pms.Framework.Core;
using Pms.Framework.Interfaces;

namespace Pms.Diagnostics.Business.Mappers
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    class DiagnosticsRunDetailItemMapper : MapperBase<DiagnosticsRunDetail,DiagnosticsRunDetailItem>
    {
        /// <summary>
        /// Maps from service to business internal.
        /// </summary>
        /// <param name="businessEntity">The service entity.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected override DiagnosticsRunDetail MapFromBusinessToServiceInternal(DiagnosticsRunDetailItem businessEntity)
        {
            return new DiagnosticsRunDetail()
            {
                Id = businessEntity.Id,
                Description = businessEntity.Info,
                EndedAt = businessEntity.EndedAt,
                ExtensionData = businessEntity.ExtensionData,
                Method = businessEntity.Method,
                RunId = businessEntity.RunId,
                ServiceContract = businessEntity.ServiceContract,
                StartedAt = businessEntity.StartedAt,
                StatusId = businessEntity.Status
            };

        }

        /// <summary>
        /// Maps from business to service internal.
        /// </summary>
        /// <param name="serviceEntity">The business entity.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected override DiagnosticsRunDetailItem MapFromServiceToBusinessInternal(DiagnosticsRunDetail serviceEntity)
        {
            return new DiagnosticsRunDetailItem()
            {
                Id = serviceEntity.Id,
                EndedAt = Convert.ToDateTime(serviceEntity.EndedAt),
                ExtensionData = serviceEntity.ExtensionData,
                Info = serviceEntity.Description,
                Method = serviceEntity.Method,
                RunId = serviceEntity.RunId,
                ServiceContract = serviceEntity.ServiceContract,
                StartedAt = Convert.ToDateTime(serviceEntity.StartedAt),
                Status = serviceEntity.StatusId
            };
        }


    }
}
