using System;
using System.Text;
using Pms.FTP.Adapter.Contract.Domain;

namespace Pms.FTP.Adapter.TestUI
{
    public static class ResponseFormatter
    {
        public static string Format(FtpResponseStatus response)
        {
            StringBuilder returnValue = new StringBuilder();
            returnValue.AppendFormat("Transfer status : {0}", response.StatusType);
            returnValue.AppendLine();
            returnValue.AppendFormat("Ftp error code : {0}", response.FtpErrorCode);
            returnValue.AppendLine();
            returnValue.AppendFormat("Error description : {0}", String.IsNullOrEmpty(response.ErrorDescription)?"String.Empty":response.ErrorDescription);

            return returnValue.ToString();
        }
    }
}
