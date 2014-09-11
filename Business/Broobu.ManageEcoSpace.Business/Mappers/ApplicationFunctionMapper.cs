using System.Collections.ObjectModel;
using System.Linq;
using Broobu.Authorization.Contract.Domain;
using Broobu.ManageAuthorization.Contract.Domain;
using Iris.Fx.Domain;
using Iris.Fx.Interfaces;

namespace Broobu.ManageAuthorization.Business.Mappers
{
    /// <summary>
    /// Class ApplicationFunctionMapper.
    /// </summary>
    class ApplicationFunctionMapper : IMapper<ApplicationFunctionInfo, ApplicationFunction>
    {
        /// <summary>
        /// Maps from business to service.
        /// </summary>
        /// <param name="businessEntity">The business entity.</param>
        /// <returns>ApplicationFunctionItem.</returns>
        public ApplicationFunction MapFromServiceToBusiness(ApplicationFunctionInfo businessEntity)
        {
            ApplicationFunction newItem = new ApplicationFunction();

            newItem.Id = businessEntity.Id;
            newItem.SessionId = businessEntity.SessionId;

            newItem.Order = businessEntity.Order;
            newItem.ParentId = businessEntity.ParentId;
            newItem.PluginUrl = businessEntity.PluginUrl;
          //  newItem.RibbonType = businessEntity.RibbonType;
            newItem.ServiceUrl = businessEntity.ServiceUrl;
            newItem.Title = businessEntity.Title;
            newItem.ToolTip = businessEntity.ToolTip;
            newItem.Code = businessEntity.Code;

            if (businessEntity.HasErrors)
            {
                newItem.AddError(businessEntity.Error);
            }

            return newItem;
        }

        /// <summary>
        /// Maps from business to service.
        /// </summary>
        /// <param name="businessEntity">The business entity.</param>
        /// <returns>ApplicationFunctionItem[].</returns>
        public ApplicationFunction[] MapFromServiceToBusiness(ApplicationFunctionInfo[] businessEntity)
        {
            var items = new Collection<ApplicationFunction>();
            foreach (ApplicationFunctionInfo applicationFunctionViewItem in businessEntity)
            {
                items.Add(MapFromServiceToBusiness(applicationFunctionViewItem));
            }
            return items.ToArray();
        }

        /// <summary>
        /// Maps from service to business.
        /// </summary>
        /// <param name="serviceEntity">The service entity.</param>
        /// <returns>Broobu.ManageAuthorization.Contract.Domain.ApplicationFunctionViewItem.</returns>
        public ApplicationFunctionInfo MapFromBusinessToService(ApplicationFunction serviceEntity)
        {
            ApplicationFunctionInfo newItem = new ApplicationFunctionInfo();

            newItem.Id = serviceEntity.Id;
            newItem.SessionId = serviceEntity.SessionId;

            newItem.Order = serviceEntity.Order;
            newItem.ParentId = serviceEntity.ParentId;
            newItem.PluginUrl = serviceEntity.PluginUrl;
        //    newItem.RibbonType = serviceEntity.RibbonType;
            newItem.ServiceUrl = serviceEntity.ServiceUrl;
            newItem.Title = serviceEntity.Title;
            newItem.ToolTip = serviceEntity.ToolTip;
            newItem.Code = serviceEntity.Code;

            if (serviceEntity.HasErrors)
            {
                newItem.AddError(serviceEntity.Error);
            }

            return newItem;
        }

        /// <summary>
        /// Maps from service to business.
        /// </summary>
        /// <param name="serviceEntity">The service entity.</param>
        /// <returns>Broobu.ManageAuthorization.Contract.Domain.ApplicationFunctionViewItem[].</returns>
        public ApplicationFunctionInfo[] MapFromBusinessToService(ApplicationFunction[] serviceEntity)
        {
            var items = new Collection<ApplicationFunctionInfo>();
            foreach (ApplicationFunction applicationFunctionItem in serviceEntity)
            {
                items.Add(MapFromBusinessToService(applicationFunctionItem));
            }
            return items.ToArray();
        }
    }
}
