using System;
using System.ServiceModel;
using Pms.FTP.Adapter.Contract.Domain;

namespace Pms.FTP.Adapter.Contract.Interfaces
{
    [ServiceContract(Namespace = FtpAdapterConstants.DefaultNamespace)]    
    [ServiceKnownType(typeof(FtpParameters))]
    [ServiceKnownType(typeof(FtpResponseStatus))]
    public interface IFTPAdapter
    {
        /// <summary>
        /// This (web)method appends a segment to a file.
        /// It's a 'wrapper' of the ftp APPE command
        /// </summary>
        /// <param name="ftpParameters">An object describing ftp connection parameters as url, username, password</param>
        /// <param name="ftpFilename">The remote (on the ftp server) file name</param>
        /// <param name="fileToSend">A byte array containing the file segment to append</param>
        /// <returns></returns>
        [OperationContract]
        FtpResponseStatus AppendFile(FtpParameters ftpParameters, string ftpFilename, byte[] fileToSend);


        /// <summary>
        /// This (web)method fetch a file segment from a ftp server.
        /// It's a 'wrapper' of the ftp 'RETRV' command
        /// </summary>
        /// <param name="ftpParameters">An object describing ftp connection parameters as url, username, password</param>
        /// <param name="ftpFilename">The remote (on the ftp server) file name</param>
        /// <param name="offset">The start index in the remote file where the download must be started</param>
        /// <param name="segmentSize">The size of the segment</param>
        /// <param name="data">The returned segment. The size of the array may be smaller than segmentSize when the last segment is downloaded.</param>
        /// <param name="eof">A boolean indicating whether or not the last segment was received</param>
        /// <returns></returns>
        [OperationContract]
        FtpResponseStatus RetrieveSegment(FtpParameters ftpParameters, string ftpFilename, long offset, int segmentSize, out byte[] data, out bool eof);

        /// <summary>
        /// This (web)method retrieve the list of files at the specified address
        /// It's a 'wrapper' of the ftp 'NLST' command
        /// </summary>
        /// <param name="ftpParameters">An object describing ftp connection parameters as url, username, password. It also includes the full address (including directory) upon which the request will be made</param>
        /// <param name="fileList">A list of strings of existing files</param>
        /// <returns></returns>
        [OperationContract]
        FtpResponseStatus NameListOfRemoteDirectory(FtpParameters ftpParameters, String filePath, out String[] fileList);

        /// <summary>
        /// This (web)method tries to delete a file. It first verifies if the file exists, using a NLIST command
        /// It's an 'advanced' wrapper of the ftp 'DELE' command
        /// </summary>
        /// <param name="ftpParameters"></param>
        /// <param name="fileName"></param>
        /// <param name="existing"></param>
        /// <returns></returns>
        [OperationContract]
        FtpResponseStatus DeleteIfExists(FtpParameters ftpParameters, string fileName, out bool existing);
    }
}
