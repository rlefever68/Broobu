using System.ServiceModel;

namespace Pms.FileTransfer.Contract.Domain
{
    /// <summary>
    /// 
    /// </summary>
    [MessageContract]
    public class DownloadRequest
    {
        /// <summary>
        /// 
        /// </summary>
        [MessageBodyMember]
        public string FileName;
    }

}
