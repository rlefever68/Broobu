using System;
using Pms.FTP.Adapter.Contract.Domain;
using Pms.FTP.Adapter.Contract.Interfaces;

namespace Pms.FTP.Adapter.Contract.Agent
{
    public class FTPMockAgent : IFTPAgent
    {
        public FtpResponseStatus AppendFile(FtpParameters ftpParameters, string ftpFilename, byte[] fileToSend)
        {
            FtpResponseStatus returnValue = new FtpResponseStatus();
            returnValue.StatusType = StatusType.Succeeded;
            return returnValue;
        }

        public FtpResponseStatus RetrieveSegment(FtpParameters ftpParameters, string ftpFilename, long offset, int segmentSize, out byte[] data, out bool eof)
        {
            FtpResponseStatus returnValue = new FtpResponseStatus();
            returnValue.StatusType = StatusType.Succeeded;
            
            data = new byte[segmentSize];
            data.Initialize();

            eof = true;
            return returnValue;
        }

        public FtpResponseStatus NameListOfRemoteDirectory(FtpParameters ftpParameters, String filePath, out string[] fileList)
        {
            FtpResponseStatus returnValue = new FtpResponseStatus();
            returnValue.StatusType = StatusType.Succeeded;

            fileList = new string[0];

            return returnValue;
        }

        public FtpResponseStatus DeleteIfExists(FtpParameters ftpParameters, string fileName, out bool existing)
        {
            FtpResponseStatus returnValue = new FtpResponseStatus();
            returnValue.StatusType = StatusType.Succeeded;
            existing = true;
            return returnValue;
        }
    }
}
