using System;
using Pms.FTP.Adapter.Contract.Domain;

namespace Pms.FTP.Business.Interfaces
{
    public interface IFTPConnectorProvider
    {
        FtpResponseStatus Append(FtpParameters ftpParameters, string ftpFilename, byte[] fileToSend);
        FtpResponseStatus RetrieveSegment(FtpParameters ftpParameters, string ftpFilename, long offset, int segmentSize, out byte[] segment, out bool eof);
        FtpResponseStatus NameListOfRemoteDirectory(FtpParameters ftpParameters, String filePath, out String[] fileList);
        FtpResponseStatus DeleteIfExists(FtpParameters ftpParameters, string ftpFilename, out bool existing);
    }
}