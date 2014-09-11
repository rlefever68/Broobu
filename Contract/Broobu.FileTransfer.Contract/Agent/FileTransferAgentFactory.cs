using Pms.FileTransfer.Contract.Interfaces;

namespace Pms.FileTransfer.Contract.Agent
{
    public class FileTransferAgentFactory
    {

     
        
        public IFileTransferAgent CreateAgent()
        {
            return new FileTransferAgent();
        }

    }
}
