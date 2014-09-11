using System;
using Pms.Framework.Networking.Wcf;
using Pms.FTP.Adapter.Contract.Domain;
using Pms.FTP.Adapter.Contract.Interfaces;

namespace Pms.FTP.Adapter.Contract.Agent
{
    public class FTPAgent : DiscoProxy<IFTPAdapter>, IFTPAgent
    {
        public FtpResponseStatus AppendFile(FtpParameters ftpParameters, string ftpFilename, byte[] fileToSend)
        {
            return Client.AppendFile(ftpParameters, ftpFilename, fileToSend);
        }

        public FtpResponseStatus RetrieveSegment(FtpParameters ftpParameters, string ftpFilename, long offset, int segmentSize, out byte[] data, out bool eof)
        {

            return Client.RetrieveSegment(ftpParameters,ftpFilename,offset,segmentSize,out data,out eof);

        }

        public FtpResponseStatus NameListOfRemoteDirectory(FtpParameters ftpParameters, String filePath, out String[] fileList)
        {
            return Client.NameListOfRemoteDirectory( ftpParameters, filePath,out fileList);

        }

        public FtpResponseStatus DeleteIfExists(FtpParameters ftpParameters, String fileName, out bool existing)
        {
            return Client.DeleteIfExists(ftpParameters, fileName,out existing);

        }
    }
}
