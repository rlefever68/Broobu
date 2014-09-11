using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Broobu.Authentication.Contract.Domain
{
    [DataContract]
    public class FunctionsResponse : ServiceResponse
    {
        [DataMember]
        public List<UserFunction> Functions = new List<UserFunction>();
    }
}