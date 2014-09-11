using Pms.FileTransfer.Contract.Domain;

namespace Pms.FileTransfer.Contract.Interfaces
{
    public interface IFileTransferAgent
    {
        void UploadFile(RemoteFileInfo request);
        RemoteFileInfo DownloadFile(DownloadRequest request);
    }
}
