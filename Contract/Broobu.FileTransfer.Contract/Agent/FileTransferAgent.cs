using System;
using Pms.FileTransfer.Contract.Domain;
using Pms.FileTransfer.Contract.Interfaces;
using Pms.Framework.Networking.Wcf;

namespace Pms.FileTransfer.Contract.Agent
{
    class FileTransferAgent : DiscoProxy<IFileTransferService>,IFileTransferAgent
    {

        #region IFileTransferAgent Members

        public void UploadFile(RemoteFileInfo request)
        {
            throw new NotImplementedException();
        }

        public RemoteFileInfo DownloadFile(DownloadRequest request)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
