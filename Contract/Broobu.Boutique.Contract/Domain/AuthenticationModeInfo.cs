using System.Runtime.Serialization;
using Wulka.Domain;
using Wulka.Domain.Base;

namespace Broobu.Boutique.Contract.Domain
{
    [DataContract]
    public class AuthenticationModeInfo : Result
    {
        [DataMember]
        public string Title { get; set; }
    }
}
