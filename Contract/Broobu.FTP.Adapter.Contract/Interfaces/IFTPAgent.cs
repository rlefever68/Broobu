using System;
using Pms.FTP.Adapter.Contract.Domain;

namespace Pms.FTP.Adapter.Contract.Interfaces
{
    public interface IFTPAgent
    {
        FtpResponseStatus AppendFile(FtpParameters ftpParameters, string ftpFilename, byte[] fileToSend);

        FtpResponseStatus RetrieveSegment(FtpParameters ftpParameters, string ftpFilename, long offset, int segmentSize, out byte[] data, out bool eof);

        FtpResponseStatus NameListOfRemoteDirectory(FtpParameters ftpParameters, String filePath, out String[] fileList);

        FtpResponseStatus DeleteIfExists(FtpParameters ftpParameters, String fileName, out bool existing);
    }
}
