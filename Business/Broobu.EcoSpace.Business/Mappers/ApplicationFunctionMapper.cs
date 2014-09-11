using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Iris.Fx.Core;
using Iris.Fx.Domain;
using Iris.Fx.Contract.Domain;
using Iris.Fx.Repository.Contract.Domain;

namespace Iris.Fx.Business.Mappers
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    internal class ApplicationFunctionMapper : MapperBase<ApplicationFunction, ApplicationFunctionItem>
    {

        /// <summary>
        /// Maps from service to business internal.
        /// </summary>
        /// <param name="serviceEntity">The service entity.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected override ApplicationFunctionItem MapFromServiceToBusinessInternal(ApplicationFunction serviceEntity)
        {
            return new ApplicationFunctionItem
            {
                Id = serviceEntity.Id,
                SessionId = serviceEntity.SessionId,
                Icon = serviceEntity.Icon,
                Order = serviceEntity.SortOrder.ToString(),
                ParentId = serviceEntity.ParentId,
                PluginUrl = serviceEntity.AppletUri,
                RibbonType = serviceEntity.TypeId,
                ServiceUrl = serviceEntity.HelpUri,
                Title = serviceEntity.Name,
                ToolTip = serviceEntity.ToolTip,
                Code = serviceEntity.Code
            };


        }

        /// <summary>
        /// Maps from business to service internal.
        /// </summary>
        /// <param name="businessEntity">The business entity.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected override ApplicationFunction MapFromBusinessToServiceInternal(ApplicationFunctionItem businessEntity)
        {
            return new ApplicationFunction
            {
                Id = businessEntity.Id,
                SessionId = businessEntity.SessionId,
                Icon = businessEntity.Icon,
                SortOrder = int.Parse(businessEntity.Order),
                ParentId = businessEntity.ParentId,
                AppletUri = businessEntity.PluginUrl,
                TypeId = businessEntity.RibbonType,
                HelpUri = businessEntity.ServiceUrl,
                Name = businessEntity.Title,
                ToolTip = businessEntity.ToolTip,
                Code = businessEntity.Code
            };

        }
    }
}
