using Broobu.ManageAuthorization.Business;
using Broobu.ManageAuthorization.Contract.Domain;
using Broobu.ManageAuthorization.Contract.Interfaces;
using Iris.Fx.Domain;
using Iris.Fx.Networking.Wcf;

namespace Broobu.ManageAuthorization.Service
{
    public class BroobuSentry : SentryBase , IManageAuthorization
    {
        /// <summary>
        /// Gets all application functions.
        /// </summary>
        /// <returns>Broobu.ManageAuthorization.Contract.Domain.ApplicationFunctionViewItem[].</returns>
        public ApplicationFunctionInfo[] GetAllApplicationFunctions()
        {
            return ManageAuthorizationProvider
                .Platform
                .GetAllApplicationFunctions();
        }

        /// <summary>
        /// Saves the application functions.
        /// </summary>
        /// <param name="applicationFunctionViewItems">The application function view items.</param>
        /// <returns>Broobu.ManageAuthorization.Contract.Domain.ApplicationFunctionViewItem[].</returns>
        public ApplicationFunctionInfo[] SaveApplicationFunctions(ApplicationFunctionInfo[] applicationFunctionViewItems)
        {
            return ManageAuthorizationProvider
               .Platform
                .SaveApplicationFunctions(applicationFunctionViewItems);
        }

        /// <summary>
        /// Deletes the application functions.
        /// </summary>
        /// <param name="applicationFunctionViewItems">The application function view items.</param>
        /// <returns>Broobu.ManageAuthorization.Contract.Domain.ApplicationFunctionViewItem[].</returns>
        public ApplicationFunctionInfo[] DeleteApplicationFunctions(ApplicationFunctionInfo[] applicationFunctionViewItems)
        {
            return ManageAuthorizationProvider
               .Platform
                .DeleteApplicationFunctions(applicationFunctionViewItems);
        }

        /// <summary>
        /// Gets all roles.
        /// </summary>
        /// <returns>Broobu.ManageAuthorization.Contract.Domain.RoleViewItem[].</returns>
        public RoleInfo[] GetAllRoles()
        {
            return ManageAuthorizationProvider
               .Platform
                .GetAllRoles();
        }

        /// <summary>
        /// Saves the roles.
        /// </summary>
        /// <param name="roleInfos">The role view items.</param>
        /// <returns>Broobu.ManageAuthorization.Contract.Domain.RoleViewItem[].</returns>
        public RoleInfo[] SaveRoles(RoleInfo[] roleInfos)
        {
            return ManageAuthorizationProvider
               .Platform
                .SaveRoles(roleInfos);
        }

        /// <summary>
        /// Deletes the roles.
        /// </summary>
        /// <param name="roleInfos">The role view items.</param>
        /// <returns>Broobu.ManageAuthorization.Contract.Domain.RoleViewItem[].</returns>
        public RoleInfo[] DeleteRoles(RoleInfo[] roleInfos)
        {
            return ManageAuthorizationProvider
               .Platform
                .DeleteRoles(roleInfos);
        }

        /// <summary>
        /// Gets all accounts.
        /// </summary>
        /// <returns>Broobu.ManageAuthorization.Contract.Domain.AccountViewItem[].</returns>
        public AccountInfo[] GetAllAccounts()
        {
            return ManageAuthorizationProvider
               .Platform
                .GetAllAccounts();
        }

        /// <summary>
        /// Gets the accounts for role.
        /// </summary>
        /// <param name="roleId">The role id.</param>
        /// <returns>Broobu.ManageAuthorization.Contract.Domain.AccountViewItem[].</returns>
        public AccountInfo[] GetAccountsForRole(string roleId)
        {
            return ManageAuthorizationProvider
               .Platform
                .GetAccountsForRole(roleId);
        }

        /// <summary>
        /// Saves the accounts for role.
        /// </summary>
        /// <param name="roleId">The role id.</param>
        /// <param name="accounts">The accounts.</param>
        /// <returns>Broobu.ManageAuthorization.Contract.Domain.AccountViewItem[].</returns>
        public Result[] LinkAccountsToRole(string roleId, AccountInfo[] accounts)
        {
            return ManageAuthorizationProvider
               .Platform
                .LinkAccountsToRole(roleId, accounts);
        }

        /// <summary>
        /// Deletes the accounts for role.
        /// </summary>
        /// <param name="roleId">The role id.</param>
        /// <param name="accounts">The accounts.</param>
        /// <returns>Broobu.ManageAuthorization.Contract.Domain.AccountViewItem[].</returns>
        public Result[] UnlinkAccountsFromRole(string roleId, AccountInfo[] accounts)
        {
            return ManageAuthorizationProvider
               .Platform
                .UnlinkAccountsFromRole(roleId, accounts);
        }

        /// <summary>
        /// You MUST override this method, but you cannot use
        /// Initializing code in the constructor that references itself (since the object is not yet created) - Obsolete remark
        /// REMARK: since the code has been moved to the onOpen method of the servicehost; you can be certain now that
        /// the object has been created.
        /// </summary>
        protected override void RegisterRequiredDomainObjects()
        {
            ManageAuthorizationProvider
               .Platform
                .RegisterRequiredDomainObjects();
        }

        /// <summary>
        /// Gets the roles for application function.
        /// </summary>
        /// <param name="applicationFunctionId">The application function id.</param>
        /// <returns>Broobu.ManageAuthorization.Contract.Domain.RoleViewItem[].</returns>
        public RoleInfo[] GetRolesForApplicationFunction(string applicationFunctionId)
        {
            return ManageAuthorizationProvider
               .Platform
                .GetRolesForApplicationFunction(applicationFunctionId);
        }

        /// <summary>
        /// Saves the roles for application function.
        /// </summary>
        /// <param name="applicationFunctionId">The application function id.</param>
        /// <param name="roles">The roles.</param>
        /// <returns>Broobu.ManageAuthorization.Contract.Domain.RoleViewItem[].</returns>
        public Result[] LinkRolesToApplicationFunction(string applicationFunctionId, RoleInfo[] roles)
        {
            return ManageAuthorizationProvider
               .Platform
                .LinkRolesToApplicationFunction(applicationFunctionId, roles);
        }

        /// <summary>
        /// Deletes the roles for application function.
        /// </summary>
        /// <param name="apllicationFunctionId">The apllication function id.</param>
        /// <param name="roles">The roles.</param>
        /// <returns>Broobu.ManageAuthorization.Contract.Domain.RoleViewItem[].</returns>
        public Result[] UnlinkRolesFromApplicationFunction(string apllicationFunctionId, RoleInfo[] roles)
        {
            return ManageAuthorizationProvider
               .Platform
                .UnlinkRolesFromApplicationFunction(apllicationFunctionId, roles);
        }


        /// <summary>
        /// Gets the ribbon types.
        /// </summary>
        /// <returns>System.String[].</returns>
        public string[] GetRibbonTypes()
        {
            return ManageAuthorizationProvider
               .Platform
                .GetRibbonTypes();
        }
    }
}
