using System;
using System.IO;
using Pms.FTP.Adapter.Contract.Agent;
using Pms.FTP.Adapter.Contract.Domain;
using Pms.FTP.Adapter.Contract.Interfaces;

namespace Pms.FTP.Adapter.TestUI
{
    public class Downloader
    {
        private FTPAgentFactory.AgentType _agentType;

        public Downloader(FTPAgentFactory.AgentType agentType)
        {
            _agentType = agentType;
        }

        // A quik test for the spell checker
        public bool DownloadFile(string localFilename, string serverFilename, FtpParameters ftpParameters, out string responseAsString)
        {
            #region check arguments

            if (String.IsNullOrEmpty(localFilename))
            {
                responseAsString = "The local file name is not specified";
                return false;
            }
            string directoryName = Path.GetDirectoryName(localFilename);
            if (String.IsNullOrEmpty(directoryName) || !Directory.Exists(directoryName))
            {
                responseAsString = string.Format("The directory {0} is invalid", directoryName);                
                return false;
            }

            #endregion
            
            bool returnValue;
            const int segmentSize = 16000;
            FtpResponseStatus response = null;
            FileStream fileStream = new FileStream(localFilename, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
            BinaryWriter binaryWriter = new BinaryWriter(fileStream);
            try
            {
                byte[] segment;
                bool eof = false;
                int offset = 0;
                while (!eof)
                {

                    IFTPAgent gatewayServiceClient = FTPAgentFactory.CreateAgent(_agentType);
                    response = gatewayServiceClient.RetrieveSegment(ftpParameters, serverFilename, offset, segmentSize, out segment, out eof);
                    if (response.StatusType != StatusType.Succeeded)
                        break;
                    binaryWriter.Write(segment);
                    offset += segment.Length;                    
                }
                
                returnValue = eof;
            }
            catch (Exception e)
            // If the request can't be sent correctly, the procy client can generate various exceptions
            // for exeample if the chunk size is too big , wcf config issue, ....
            {
                response = new FtpResponseStatus();
                response.StatusType = StatusType.OtherError;
                response.ErrorDescription = e.ToString();
                returnValue = false;
            }
            finally
            {
                binaryWriter.Close();                
            }
            responseAsString = ResponseFormatter.Format(response);

            return returnValue;

        }
    }
}
