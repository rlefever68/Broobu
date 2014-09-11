using System;
using System.Linq;
using Pms.Diagnostics.Contract.Domain;
using Pms.Framework.Interfaces;
using Pms.ManageDiagnostics.Contract.Domain;


namespace Pms.ManageDiagnostics.Business.Mappers
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public class DiagnosticsViewItemMapper : IMapper<DiagnosticsRunDetailItem, DiagnosticsViewItem>
    {
        /// <summary>
        /// Maps from business to service.
        /// </summary>
        /// <param name="businessEntity">The business entity.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public DiagnosticsRunDetailItem[] MapFromBusinessToService(DiagnosticsViewItem[] businessEntity)
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
        public DiagnosticsRunDetailItem MapFromBusinessToService(DiagnosticsViewItem businessEntity)
        {
            return new DiagnosticsRunDetailItem()
                       {
                           Id = businessEntity.Id,
                           Info =  businessEntity.Description,
                           StartedAt = businessEntity.StartTime,
                           EndedAt = businessEntity.EndTime,
                           ExtensionData = businessEntity.ExtensionData,
                           Method = businessEntity.Method,
                           Status = businessEntity.Status,
                           ServiceContract = businessEntity.Contract
                       };
        }

        /// <summary>
        /// Maps from service to business.
        /// </summary>
        /// <param name="serviceEntity">The service entity.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public DiagnosticsViewItem[] MapFromServiceToBusiness(DiagnosticsRunDetailItem[] serviceEntity)
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
        public DiagnosticsViewItem MapFromServiceToBusiness(DiagnosticsRunDetailItem serviceEntity)
        {
            return new DiagnosticsViewItem()
                       {
                           Id = serviceEntity.Id,
                           Description = serviceEntity.Info,
                           EndTime = serviceEntity.EndedAt,
                           ExtensionData = serviceEntity.ExtensionData,
                           Method = serviceEntity.Method,
                           StartTime = serviceEntity.StartedAt,
                           Status = serviceEntity.Status,
                           Contract = serviceEntity.ServiceContract

                       };
        }

        /// <summary>
        /// Gets the contract.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private string GetContract(string id)
        {
            var seg = id.ToLower().Split(new string[] {"contract"}, StringSplitOptions.None);
            if(seg.Count()>0)
                return seg[0] + "Contract";
            return id;
        }

    }
}
