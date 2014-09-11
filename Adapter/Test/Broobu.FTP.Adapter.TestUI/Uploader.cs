using System;
using System.IO;
using Pms.FTP.Adapter.Contract.Agent;
using Pms.FTP.Adapter.Contract.Domain;
using Pms.FTP.Adapter.Contract.Interfaces;

namespace Pms.FTP.Adapter.TestUI
{
    public class Uploader
    {
        private FTPAgentFactory.AgentType _agentType;

        public Uploader(FTPAgentFactory.AgentType agentType)
        {
            _agentType = agentType;
        }
        

        public bool UploadFile(string localFilename, string serverFilename, FtpParameters ftpParameters, out string responseAsString)
        {
            if (!File.Exists(localFilename))
            {
                responseAsString = string.Format("The file {0} does not exists", localFilename);
                return false;
            }

            const int chunkSize = 16000;
            FileInfo fileToSendInfo = new FileInfo(localFilename);
            long fileSize = fileToSendInfo.Length;
            FtpResponseStatus lastResponse = null;
            FileStream fileStream = new FileStream(fileToSendInfo.FullName, FileMode.Open);

            bool returnValue;

            try
            {
                for (long currentIndex = 0; currentIndex < fileSize; currentIndex += chunkSize)
                {
                    lastResponse = SendFileChunk(fileStream, chunkSize, ftpParameters, serverFilename);
                    if (lastResponse.StatusType != StatusType.Succeeded)
                        break;
                }

                responseAsString  = ResponseFormatter.Format(lastResponse);
            }
            finally
            {
                fileStream.Close();
            }
            
            if (lastResponse == null)                            
                returnValue = false;            
            else
                returnValue = lastResponse.StatusType == StatusType.Succeeded;

            return returnValue;
        }
        
        private FtpResponseStatus SendFileChunk(Stream fileStream, int chunkSize, FtpParameters ftpParameters, string serverFilename)
        {
            FtpResponseStatus returnValue;
            try
            {
                IFTPAgent ftpAgent = FTPAgentFactory.CreateAgent(_agentType);
                
                byte[] tempBuffer = new byte[chunkSize];
                byte[] bytesToSend;
                int numberOfBytesTosend = fileStream.Read(tempBuffer, 0, chunkSize);

                if (numberOfBytesTosend < chunkSize)
                {
                    bytesToSend = new byte[numberOfBytesTosend];
                    Array.Copy(tempBuffer, bytesToSend, numberOfBytesTosend);
                }else
                {
                    bytesToSend = tempBuffer;
                }


                returnValue = ftpAgent.AppendFile(ftpParameters, serverFilename, bytesToSend);

                return returnValue;
            }
            catch (Exception e)
            // If the request can't be sent correctly, the procy client can generate various exceptions
            // for exeample if the chunk size is too big , wcf config issue, ....
            
            {
                returnValue = new FtpResponseStatus();
                returnValue.StatusType = StatusType.OtherError;
                returnValue.ErrorDescription = e.ToString();
            }
            return returnValue;
        }

    }
}
