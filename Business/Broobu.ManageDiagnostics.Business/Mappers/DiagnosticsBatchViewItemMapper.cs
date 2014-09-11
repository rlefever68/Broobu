using System;
using Pms.Diagnostics.Contract.Domain;
using Pms.Framework.Interfaces;
using Pms.ManageDiagnostics.Contract.Domain;
using System.Linq;

namespace Pms.ManageDiagnostics.Business.Mappers
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public class DiagnosticsBatchViewItemMapper : IMapper<DiagnosticsBatchViewItem, DiagnosticsRunItem>
    {
        /// <summary>
        /// Maps from business to service.
        /// </summary>
        /// <param name="businessEntity">The business entity.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public DiagnosticsBatchViewItem[] MapFromBusinessToService(DiagnosticsRunItem[] businessEntity)
        {
            return businessEntity
                .Select(MapFromBusinessToService)
                .ToArray();
        }

        /// <summary>
        /// Maps from business to service.
        /// </summary>
        /// <param name="businessEntity">The business entity.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public DiagnosticsBatchViewItem MapFromBusinessToService(DiagnosticsRunItem businessEntity)
        {
            return new DiagnosticsBatchViewItem()
                       {
                           Id = businessEntity.Id,
                           Batch = businessEntity.Info,
                           Description = businessEntity.Info,
                           EndTime = businessEntity.EndTime,
                           ExtensionData = businessEntity.ExtensionData,
                           StartTime = businessEntity.StartTime,
                           Status = businessEntity.Status
                       };
        }

        /// <summary>
        /// Maps from service to business.
        /// </summary>
        /// <param name="serviceEntity">The service entity.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public DiagnosticsRunItem[] MapFromServiceToBusiness(DiagnosticsBatchViewItem[] serviceEntity)
        {
            return serviceEntity
                .Select(MapFromServiceToBusiness)
                .ToArray();
        }

        /// <summary>
        /// Maps from service to business.
        /// </summary>
        /// <param name="serviceEntity">The service entity.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public DiagnosticsRunItem MapFromServiceToBusiness(DiagnosticsBatchViewItem serviceEntity)
        {
            return new DiagnosticsRunItem()
                       {
                           Id=serviceEntity.Id,
                           EndTime = serviceEntity.EndTime,
                           ExtensionData = serviceEntity.ExtensionData,
                           Info = serviceEntity.Description,
                           StartTime = serviceEntity.StartTime,
                           Status = serviceEntity.Status
                       };
        }
    }
}
