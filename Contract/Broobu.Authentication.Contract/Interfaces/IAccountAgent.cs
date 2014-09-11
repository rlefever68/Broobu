using System;
using System.Collections.Generic;
using Broobu.Authentication.Contract.Domain;


namespace Broobu.Authentication.Contract.Interfaces
{
    public interface IAccountAgent : IAccounts
    {
        void GetAccountsAsync(Action<IEnumerable<IAccount>> act=null);
    }
}