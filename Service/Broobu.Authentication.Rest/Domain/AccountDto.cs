using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Broobu.Authentication.Rest.Domain
{
    public class AccountDto
    {
        public string UserName { get; set; }
        public bool IsActive { get; set; }
    }
}