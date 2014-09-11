using System.Runtime.Serialization;

namespace Pms.FTP.Adapter.Contract.Domain
{
    [DataContract(Namespace = FtpAdapterConstants.DefaultNamespace)]
    public class FtpResponseStatus
    {
        [DataMember]
        public StatusType StatusType { get; set; }

        [DataMember]
        public int  FtpErrorCode { get; set; }

        [DataMember]
        public string ErrorDescription { get; set; }
    }
}