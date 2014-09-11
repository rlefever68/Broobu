using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using log4net;
using Pms.FTP.Adapter.Contract.Domain;
using Pms.FTP.Business.Interfaces;

namespace Pms.FTP.Business
{
    class FTPConnectorProvider : IFTPConnectorProvider
    {
        #region String constants
        private const string FtpGatewayServiceErrorMessage = "POS Service error. See server log for details";

        #endregion

        private readonly ILog _logger;

        public FTPConnectorProvider()
        {
            _logger = LogManager.GetLogger(GetType());           
        }

        public FtpResponseStatus Append(FtpParameters ftpParameters, string ftpFilename, byte[] fileToSend)
        {
            #region Parameter validation
            if (ftpParameters == null)
                throw new ArgumentNullException("ftpParameters");
            if (String.IsNullOrEmpty(ftpFilename))
                throw new ArgumentNullException("ftpFilename");
            if (fileToSend == null)
                throw new ArgumentNullException("fileToSend");
            #endregion

            #region log4net
            _logger.DebugFormat("ftpParameters : {0}, ftpFilename : {1}, fileToSend : {2} ",ftpParameters, ftpFilename, fileToSend.Length);
            #endregion
            
            FtpResponseStatus returnValue = new FtpResponseStatus();

            try
            {                
                FtpWebRequest ftpWebRequest = GetFtpRequest(ftpParameters, ftpFilename);
                ftpWebRequest.Method = WebRequestMethods.Ftp.AppendFile;
                Stream stream = ftpWebRequest.GetRequestStream();
                stream.Write(fileToSend, 0, fileToSend.Length);
                stream.Close();

                FtpWebResponse ftpWebResponse = GetFtpResponse(ftpWebRequest);

                if (ftpWebResponse.StatusCode == FtpStatusCode.ClosingData)
                    returnValue.StatusType = StatusType.Succeeded;
                else
                {
                    returnValue.StatusType = StatusType.OtherError;
                    returnValue.ErrorDescription = FtpGatewayServiceErrorMessage;

                    #region log4net
                    _logger.ErrorFormat("ftpWebResponse.StatusCode = {0}, .StatusDescription = {1}", ftpWebResponse.StatusCode, ftpWebResponse.StatusDescription);
                    #endregion
                }
                ftpWebResponse.Close();
            }
            catch (WebException webException)
            {
                returnValue = GetResponseStatusFromWebException(webException);
            }

            
            return returnValue;
        }

        public FtpResponseStatus RetrieveSegment(FtpParameters ftpParameters, string ftpFilename, long offset, int segmentSize, out byte[] segment, out bool eof)
        {
            #region log4net
            _logger.DebugFormat("Parameters : ftpParameters={0}, segmentSize={1}", ftpParameters, segmentSize);
            #endregion

            FtpResponseStatus returnValue = new FtpResponseStatus();

            try
            {
                long fileLength = GetFileLengthFromFtp(ftpParameters, ftpFilename);
                
                if (offset > fileLength)
                {                    
                    returnValue.StatusType = StatusType.Succeeded;
                    eof = true;
                    segment = null;
                }
                else
                {
                    long remainingLength = fileLength - offset;
                    eof = remainingLength <= segmentSize;

                    // Get the size of the chunk.
                    // If this is the last chunk, the size maybe smaller than the requested chunk size.                    
                    int realSegmentSize = eof ? Convert.ToInt32(remainingLength) : segmentSize;

                    segment = GetFileSegmentFromFtp(ftpParameters, ftpFilename, offset, eof, realSegmentSize);
                }

                returnValue.StatusType = StatusType.Succeeded;                
            }
            catch (WebException webException)
            {
                returnValue = GetResponseStatusFromWebException(webException);
                segment = null;
                eof = false;
            }
            return returnValue;
        }

        /// <summary>
        /// See doc in the service interface. Basically, this is a 'wrapper' arrount the ftp nlst command
        /// </summary>
        /// <param name="ftpParameters"></param>
        /// <param name="fileList"></param>
        /// <returns></returns>
        public FtpResponseStatus NameListOfRemoteDirectory(FtpParameters ftpParameters, String filePath, out String[] fileList)
        {
            #region log4net
            _logger.DebugFormat("Parameters : ftpParameters={0}, filename={1}", ftpParameters,filePath);
            #endregion

            FtpResponseStatus returnValue = new FtpResponseStatus();

            List<String> localFileList = new List<string>();
            fileList = null;

            try
            {
                FtpWebRequest ftpWebRequest = GetFtpRequest(ftpParameters, filePath);

                ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectory;

                FtpWebResponse response = GetFtpResponse(ftpWebRequest);

                StreamReader reader = new StreamReader(response.GetResponseStream());

                string line = reader.ReadLine();
                while (!String.IsNullOrEmpty(line))
                {
                    localFileList.Add(line);
                    line = reader.ReadLine();
                }

                reader.Close();
                response.Close();

                fileList = localFileList.ToArray();
                returnValue.StatusType = StatusType.Succeeded;
                return returnValue;
            }
            catch (WebException webException)
            {
                returnValue = GetResponseStatusFromWebException(webException);
            }
            return returnValue;
        }


        
        public FtpResponseStatus DeleteIfExists(FtpParameters ftpParameters, string ftpFilename, out bool existing)
        {
            #region log4net

            _logger.DebugFormat("Parameters : ftpParameters={0}, ftpFilename={1}", ftpParameters, ftpFilename );

            #endregion

            FtpResponseStatus returnValue;
            string[] existingFiles;
            
            FtpResponseStatus intermediateResponse = NameListOfRemoteDirectory(ftpParameters, ftpFilename, out existingFiles);

            if (intermediateResponse.StatusType == StatusType.Succeeded)
            {
                
                
                if (Array.Exists(existingFiles, s => s == Path.GetFileName(ftpFilename)))
                {
                    existing = true;
                    FtpWebRequest ftpWebRequest = GetFtpRequest(ftpParameters, ftpFilename);
                    ftpWebRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                    FtpWebResponse webResponse = GetFtpResponse(ftpWebRequest);

                    if (webResponse.StatusCode == FtpStatusCode.FileActionOK)
                        returnValue = new FtpResponseStatus{StatusType = StatusType.Succeeded};
                    else
                        returnValue = new FtpResponseStatus{StatusType = StatusType.FtpError,FtpErrorCode =((int)webResponse.StatusCode), ErrorDescription = webResponse.StatusDescription};
                }else
                {
                    existing = false;
                    returnValue = new FtpResponseStatus{StatusType = StatusType.Succeeded};                    
                }
            }else
            {
                existing = false;
                if (intermediateResponse.FtpErrorCode == ((int) FtpStatusCode.ActionNotTakenFileUnavailable))
                    returnValue = new FtpResponseStatus{StatusType = StatusType.Succeeded};
                else
                    returnValue = intermediateResponse;
            }

            

            #region log4net
            _logger.DebugFormat("returnValue = {0}, existing = {1}",returnValue,existing);
            #endregion            

            return returnValue;
        }


        private byte[] GetFileSegmentFromFtp(FtpParameters ftpParameters, string ftpFilename, long offset, bool eof, int segmentSize)
        {
            FtpWebRequest ftpWebRequest = GetFtpRequest(ftpParameters, ftpFilename);
            ftpWebRequest.ContentOffset = offset;
            ftpWebRequest.Method = WebRequestMethods.Ftp.DownloadFile;
            FtpWebResponse response = GetFtpResponse(ftpWebRequest);
            
            Stream responseStream = response.GetResponseStream();
            if (responseStream == null)
                throw new ApplicationException("response.GetResponseStream() returned no stream");

            BinaryReader reader = new BinaryReader(responseStream);

            byte[] returnValue = reader.ReadBytes(segmentSize);

            if (!eof)
                ftpWebRequest.Abort();

            reader.Close();
            return returnValue;
        }

        private static long GetFileLengthFromFtp(FtpParameters ftpParameters, string ftpFilename)
        {
            FtpWebRequest ftpWebRequest = GetFtpRequest(ftpParameters, ftpFilename);
            ftpWebRequest.Method = WebRequestMethods.Ftp.GetFileSize;
            FtpWebResponse response = GetFtpResponse(ftpWebRequest);
            long fileLength = response.ContentLength;
            response.Close();
            return fileLength;
        }
        
        /// <summary>
        /// Returns an FtpWebRequest initialized with the parameters specified int the FtpParmaters data contract
        /// </summary>
        /// <param name="ftpParameters"></param>
        /// <param name="serverFilename"></param>
        /// <returns></returns>
        private static FtpWebRequest GetFtpRequest(FtpParameters ftpParameters, string serverFilename)
        {
            UriBuilder uriBuilder = new UriBuilder(ftpParameters.Address);
            uriBuilder.Port = ftpParameters.Port;

            if (String.IsNullOrWhiteSpace(serverFilename))
                uriBuilder.Path = VirtualPathUtility.RemoveTrailingSlah(uriBuilder.Path);
            else
                uriBuilder.Path = VirtualPathUtility.AppendTrailingSlash(uriBuilder.Path) + VirtualPathUtility.RemoveFirstSlash(serverFilename);

            FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(uriBuilder.Uri);
            ftpWebRequest.Credentials = new NetworkCredential(ftpParameters.User, ftpParameters.Password);
            ftpWebRequest.UsePassive = !ftpParameters.IsActive;
            ftpWebRequest.KeepAlive = true;
            ftpWebRequest.UseBinary = true;

            return ftpWebRequest;
        }

        /// <summary>
        /// This method returns the ftp response, making sure it's not null
        /// </summary>
        /// <param name="ftpWebRequest"></param>
        /// <returns></returns>
        private static FtpWebResponse GetFtpResponse(FtpWebRequest ftpWebRequest)
        {
            FtpWebResponse response = ftpWebRequest.GetResponse() as FtpWebResponse;
            if (response == null)
                throw new ApplicationException("ftpWebRequest.GetResponse() returned no reponse");
            return response;
        }

        private static FtpResponseStatus GetResponseStatusFromWebException(WebException webException)
        {
            FtpResponseStatus returnValue = new FtpResponseStatus();
            FtpWebResponse ftpWebResponse = webException.Response as FtpWebResponse;

            if (ftpWebResponse != null && ftpWebResponse.StatusCode != FtpStatusCode.Undefined)
            {
                returnValue.StatusType = StatusType.FtpError;
                returnValue.FtpErrorCode = ((int)ftpWebResponse.StatusCode);
                returnValue.ErrorDescription = ftpWebResponse.StatusDescription;
            }
            else
            {
                returnValue.StatusType = StatusType.OtherError;
                returnValue.ErrorDescription = FtpGatewayServiceErrorMessage;
            }

            return returnValue;
        }
    }
}
