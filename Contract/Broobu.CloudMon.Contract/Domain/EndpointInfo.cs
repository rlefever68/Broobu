using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Broobu.MonitorDisco.Contract.Domain;
using Iris.Fx.Domain;

namespace Broobu.CloudMon.Contract.Domain
{
    [DataContract]
    public class EndpointInfo 
    {

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string Protocol { get; set; }

        [DataMember]
        public string Host { get; set; }

        [DataMember]
        public string Port { get; set; }

        [DataMember]
        public string Layer { get; set; }

        [DataMember]
        public string Application { get; set; }

        [DataMember]
        public string Service { get; set; }

        [DataMember]
        public string Endpoint { get; set; }

        [DataMember]
        public string Contract { get; set; }

    }
}
