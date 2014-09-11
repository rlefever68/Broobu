using System.Runtime.Serialization;

namespace Broobu.Authentication.Contract.Domain
{
    [DataContract]
    public class ServiceVersion
    {
        [DataMember]
        public string Version;

        [DataMember]
        public string CompatibilityVersion;
    }
}