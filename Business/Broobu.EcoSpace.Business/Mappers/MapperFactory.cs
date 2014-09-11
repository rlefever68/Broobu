using Iris.Fx.Core;
using Iris.Fx.Domain;
using Iris.Fx.Contract.Domain;
using Iris.Fx.Repository.Contract.Domain;

namespace Iris.Fx.Business.Mappers
{
    public class MapperFactory
    {
        public static MapperBase<Account, AccountItem> CreateAccountMapper()
        {
            return new AccountMapper();
        }

        public static MapperBase<ApplicationFunction, ApplicationFunctionItem> CreateApplicationFunctionMapper()
        {
            return new ApplicationFunctionMapper();
        }

        public static MapperBase<Role, RoleItem> CreateRoleMapper()
        {
            return new RoleMapper();
        }
    }
}
