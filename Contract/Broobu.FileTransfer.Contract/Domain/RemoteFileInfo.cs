using System;
using System.ServiceModel;

namespace Pms.FileTransfer.Contract.Domain
{
    [MessageContract]
    public class RemoteFileInfo : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        [MessageHeader(MustUnderstand = true)]
        public string FileName;

        /// <summary>
        /// 
        /// </summary>
        [MessageHeader(MustUnderstand = true)]
        public long Length;

        /// <summary>
        /// 
        /// </summary>
        [MessageBodyMember(Order = 1)]
        public System.IO.Stream FileByteStream;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (FileByteStream == null) return;
            FileByteStream.Close();
            FileByteStream = null;
        }
    }
}
