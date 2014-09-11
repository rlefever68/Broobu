using System.Collections.ObjectModel;
using System.Linq;
using Broobu.Authorization.Contract.Domain;
using Broobu.ManageAuthorization.Contract.Domain;
using Iris.Fx.Interfaces;

namespace Broobu.ManageAuthorization.Business.Mappers
{
   
    internal class RoleMapper : IMapper<RoleInfo, Role>
    {


        /// <summary>
        /// Maps from business to service.
        /// </summary>
        /// <param name="businessEntity">The business entity.</param>
        /// <returns>Broobu.Authorization.Contract.Domain.RoleItem.</returns>
        public Role MapFromServiceToBusiness(RoleInfo businessEntity)
        {
            var newItem = new Role
            {
                AdditionalInfoUri = businessEntity.ToolTip,
                Id = businessEntity.Id,
                Name = businessEntity.Title,
                ParentId = businessEntity.ParentId
            };

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
        /// <returns>Broobu.Authorization.Contract.Domain.RoleItem[].</returns>
        public Role[] MapFromServiceToBusiness(RoleInfo[] businessEntity)
        {
            var items = new Collection<Role>();
            foreach (RoleInfo roleViewItem in businessEntity)
            {
                items.Add(MapFromServiceToBusiness(roleViewItem));
            }
            return items.ToArray();
        }

        /// <summary>
        /// Maps from service to business.
        /// </summary>
        /// <param name="serviceEntity">The service entity.</param>
        /// <returns>Broobu.ManageAuthorization.Contract.Domain.RoleViewItem.</returns>
        public RoleInfo MapFromBusinessToService(Role serviceEntity)
        {
            var newItem = new RoleInfo
            {
                ToolTip = serviceEntity.AdditionalInfoUri,
                Id = serviceEntity.Id,
                Title = serviceEntity.Name,
                ParentId = serviceEntity.ParentId
            };

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
        /// <returns>Broobu.ManageAuthorization.Contract.Domain.RoleViewItem[].</returns>
        public RoleInfo[] MapFromBusinessToService(Role[] serviceEntity)
        {
            var items = new Collection<RoleInfo>();
            foreach (Role roleItem in serviceEntity)
            {
                items.Add(MapFromBusinessToService(roleItem));
            }
            return items.ToArray();
        }
    }
}
