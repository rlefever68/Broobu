using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Broobu.Authentication.Contract.Domain;

namespace Broobu.Authentication.Rest.Domain
{
    public static class DomainExtensions
    {
        public static AccountDto ToAccountDto(this Account acc)
        {
            return new AccountDto() { 
                IsActive = (acc.Active==1),
                UserName = acc.Username
            };
        }
    }
}