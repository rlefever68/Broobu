using System.Runtime.Serialization;
using Wulka.Domain;
using Wulka.Domain.Base;

namespace Broobu.Authentication.Contract.Domain
{
    [DataContract]
    public class ValidationResult : Result
    {
        [DataMember]
        public bool IsValid { get; set; }
    }
}