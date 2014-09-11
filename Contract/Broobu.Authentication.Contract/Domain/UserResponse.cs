using System.Runtime.Serialization;

namespace Broobu.Authentication.Contract.Domain
{
    [DataContract]
    public class UserResponse : ServiceResponse
    {
        [DataMember]
        public string Username;

        [DataMember]
        public string FirstName;

        [DataMember]
        public string LastName;
    }
}