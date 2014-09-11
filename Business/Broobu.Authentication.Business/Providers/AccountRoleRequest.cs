using System;
using System.Runtime.Serialization;
using Broobu.Authorization.Contract.Domain;
using Iris.Fx.Domain;

namespace Broobu.Authorization.Business.Workers
{
    [DataContract]
    internal class AccountRoleRequest : RequestBase
    {
        [DataMember]
        public string AccountId { get; set; }
        [DataMember]
        public string RoleId { get; set; }

        protected override string GetFunction()
        {
            return String.Format("if(doc.AccountId=='{0}' && doc.RoleId=='{1}') emit(doc.Id,doc)",
                AccountId,
                RoleId);
        }
    }
}