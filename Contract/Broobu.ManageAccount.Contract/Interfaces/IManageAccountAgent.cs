using System;
using Pms.ManageAccount.Contract.Domain;

namespace Pms.ManageAccount.Contract.Interfaces
{
    public interface IManageAccountAgent : IManageAccount
    {

        event Action<AccountViewItem[]> GetAccountsCompleted;
        void GetAccountsAsync();
        void GetAccountsAsync(Action<AccountViewItem[]> act);
    }
}
