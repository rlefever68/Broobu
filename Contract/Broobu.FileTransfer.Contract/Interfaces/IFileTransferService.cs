using System.ServiceModel;
using Pms.FileTransfer.Contract.Domain;
using Pms.Framework.Domain;

namespace Pms.FileTransfer.Contract.Interfaces
{
    [ServiceContract(Namespace = ServiceConst.Namespace)]
    public interface IFileTransferService
    {
        [OperationContract]
        void UploadFile(RemoteFileInfo request);

        [OperationContract]
        RemoteFileInfo DownloadFile(DownloadRequest request);
    }
}
