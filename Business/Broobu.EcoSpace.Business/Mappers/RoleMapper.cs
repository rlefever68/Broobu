using System;
using Iris.Fx.Core;
using Iris.Fx.Contract.Domain;
using Iris.Fx.Repository.Contract.Domain;

namespace Iris.Fx.Business.Mappers
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    internal class RoleMapper : MapperBase<Role, RoleItem>
    {




        /// <summary>
        /// Maps from service to business internal.
        /// </summary>
        /// <param name="serviceEntity">The service entity.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected override RoleItem MapFromServiceToBusinessInternal(Role serviceEntity)
        {
            return new RoleItem
            {
                AdditionalInfo = serviceEntity.AdditionalInfo,
                Name = serviceEntity.Name,
                ParentId = serviceEntity.ParentId
            };
        }

        /// <summary>
        /// Maps from business to service internal.
        /// </summary>
        /// <param name="businessEntity">The business entity.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected override Role MapFromBusinessToServiceInternal(RoleItem businessEntity)
        {
            return new Role
            {
                AdditionalInfo = businessEntity.AdditionalInfo,
                Id = businessEntity.Id,
                Name = businessEntity.Name,
                ParentId = businessEntity.ParentId
            };

        }
    }
}
