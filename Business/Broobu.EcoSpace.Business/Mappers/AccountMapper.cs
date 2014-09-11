using Iris.Fx.Contract.Domain;
using Iris.Fx.Core;
using Iris.Fx.Repository.Contract.Domain;

namespace Iris.Fx.Business.Mappers
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    class AccountMapper : MapperBase<Account, AccountItem>
    {

        protected override AccountItem MapFromServiceToBusinessInternal(Account serviceEntity)
        {
            return new AccountItem
            {
                Id = serviceEntity.Id,
                SessionId = serviceEntity.SessionId,
                Username = serviceEntity.Username,
                LastName = serviceEntity.LastName,
                FirstName = serviceEntity.FirstName,
                Email = serviceEntity.Email,
                Active = serviceEntity.Active,
                AuthModeId = serviceEntity.AuthModeId,
                CardId = serviceEntity.CardId,
                DtEnd = serviceEntity.DtEnd,
                DtStart = serviceEntity.DtStart,
                MiddleName = serviceEntity.MiddleName,
                Pwd = serviceEntity.Pwd,
                Telephone1 = serviceEntity.Telephone1,
                Telephone2 = serviceEntity.Telephone2
            };

        }

        protected override Account MapFromBusinessToServiceInternal(AccountItem businessEntity)
        {
            return new Account
            {
                Id = businessEntity.Id,
                SessionId = businessEntity.SessionId,
                Username = businessEntity.Username,
                LastName = businessEntity.LastName,
                FirstName = businessEntity.FirstName,
                Email = businessEntity.Email,
                Active = businessEntity.Active,
                AuthModeId = businessEntity.AuthModeId,
                CardId = businessEntity.CardId,
                DtEnd = businessEntity.DtEnd,
                DtStart = businessEntity.DtStart,
                MiddleName = businessEntity.MiddleName,
                Pwd = businessEntity.Pwd,
                Telephone1 = businessEntity.Telephone1,
                Telephone2 = businessEntity.Telephone2
            };

        }
    }
}
