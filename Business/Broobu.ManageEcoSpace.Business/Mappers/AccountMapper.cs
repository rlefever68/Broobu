using System.Collections.ObjectModel;
using System.Linq;
using Broobu.Authorization.Contract.Domain;
using Broobu.ManageAuthorization.Contract.Domain;
using Iris.Fx.Interfaces;

namespace Broobu.ManageAuthorization.Business.Mappers
{
    /// <summary>
    /// Class AccountMapper.
    /// </summary>
    internal class AccountMapper : IMapper<AccountInfo,Account>
    {

        /// <summary>
        /// Maps from business to service.
        /// </summary>
        /// <param name="businessEntity">The business entity.</param>
        /// <returns>Broobu.Authorization.Contract.Domain.AccountItem.</returns>
        public Account MapFromServiceToBusiness(AccountInfo businessEntity)
        {
            var newItem = new Account
            {
                Id = businessEntity.Id,
                SessionId = businessEntity.SessionId,
                Username = businessEntity.UserName,
                LastName = businessEntity.LastName,
                FirstName = businessEntity.FirstName,
                Email = businessEntity.EmailAddress
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
        /// <returns>Broobu.Authorization.Contract.Domain.AccountItem[].</returns>
        public Account[] MapFromServiceToBusiness(AccountInfo[] businessEntity)
        {
            var items = new Collection<Account>();
            foreach (AccountInfo accountViewItem in businessEntity)
            {
                items.Add(MapFromServiceToBusiness(accountViewItem));
            }
            return items.ToArray();
        }

        /// <summary>
        /// Maps from service to business.
        /// </summary>
        /// <param name="serviceEntity">The service entity.</param>
        /// <returns>Broobu.ManageAuthorization.Contract.Domain.AccountViewItem.</returns>
        public AccountInfo MapFromBusinessToService(Account serviceEntity)
        {
            var newItem = new AccountInfo
            {
                Id = serviceEntity.Id,
                SessionId = serviceEntity.SessionId,
                UserName = serviceEntity.Username,
                LastName = serviceEntity.LastName,
                FirstName = serviceEntity.FirstName,
                EmailAddress = serviceEntity.Email
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
        /// <returns>Broobu.ManageAuthorization.Contract.Domain.AccountViewItem[].</returns>
        public AccountInfo[] MapFromBusinessToService(Account[] serviceEntity)
        {
            var items = new Collection<AccountInfo>();
            foreach (var accountItem in serviceEntity)
            {
                items.Add(MapFromBusinessToService(accountItem));
            }
            return items.ToArray();
        }
    }
}
