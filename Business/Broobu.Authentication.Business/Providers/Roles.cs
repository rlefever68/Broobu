using System;
using System.Linq;
using Broobu.Authorization.Business.Interfaces;
using Broobu.Authorization.Contract.Domain;
using Iris.Fx.Data;
using Iris.Fx.Domain;
using Iris.Fx.Exceptions;
using NLog;


namespace Broobu.Authorization.Business.Workers
{
    internal class Roles : IRoles
    {

        private readonly Logger _logger = LogManager.GetLogger("Roles");


        /// <summary>
        /// Gets the roles for application function.
        /// </summary>
        /// <param name="applicationFunctionId">The application function id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public Role[] GetRolesForApplicationFunction(string applicationFunctionId)
        {
            var req = new WhereRequest()
            {
                Field = "ApplicationFunctionId",
                Value = applicationFunctionId
            };
            return Provider<RoleXApplicationFunction>
                .Query(req)
                .Select(x => Provider<Role>.GetById(x.RoleId))
                .ToArray();
        }

        /// <summary>
        /// Registers the required domain objects.
        /// </summary>
        public void RegisterRequiredDomainObjects()
        {
            try
            {
                Provider<Role>.Save(AuthorizationDomainGenerator.InflateRoles());

            }
            catch (Exception exception)
            {
                _logger.Error(exception.GetCombinedMessages());
            }
        }

        /// <summary>
        /// Gets all roles.
        /// </summary>
        /// <returns></returns>
        public Role[] GetAllRoles()
        {
            return Provider<Role>.GetAll();
        }

        /// <summary>
        /// Saves the roles.
        /// </summary>
        /// <param name="roleItems">The role items.</param>
        /// <returns></returns>
        public Role[] SaveRoles(Role[] roleItems)
        {
            return Provider<Role>.Save(roleItems);
        }


   
        /// <summary>
        /// Deletes the roles.
        /// </summary>
        /// <param name="roleItems">The role items.</param>
        /// <returns></returns>
        public Role[] DeleteRoles(Role[] roleItems)
        {
            return Provider<Role>.Delete(roleItems);
        }


        /// <summary>
        /// Saves the roles for application function.
        /// </summary>
        /// <param name="applicationFunctionId">The application function id.</param>
        /// <param name="roles">The roles.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public RoleXApplicationFunction[] LinkRolesToApplicationFunction(string applicationFunctionId, Role[] roles)
        {
            return Provider<RoleXApplicationFunction>
                .Save(roles.Select(roleItem => new RoleXApplicationFunction()
                                               {
                                                   ApplicationFunctionId = applicationFunctionId,
                                                   RoleId = roleItem.Id
                                               }).ToArray());
        }

        /// <summary>
        /// Deletes the roles for application function.
        /// </summary>
        /// <param name="applicationFunctionId">The apllication function id.</param>
        /// <param name="roles">The roles.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public RoleXApplicationFunction[] UnlinkRolesFromApplicationFunction(string applicationFunctionId, Role[] roles)
        {
            return Provider<RoleXApplicationFunction>
                .Delete(roles.Select(roleItem => new RoleXApplicationFunction()
                                                 {
                                                     ApplicationFunctionId = applicationFunctionId,
                                                     RoleId = roleItem.Id
                                                 }).ToArray());
        }


        public Role RegisterPrivateCloud(Role role)
        {
            role.ParentId = RoleConst.Private;
            return Provider<Role>.Save(role);
        }
    }
}
