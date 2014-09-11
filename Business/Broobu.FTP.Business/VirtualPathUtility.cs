using System;
using System.Text;

namespace Pms.FTP.Business
{
    internal static class VirtualPathUtility
    {
        const char Slash = '/';

        public static string AppendTrailingSlash(string originalPath)
        {
            if (String.IsNullOrWhiteSpace(originalPath))
                return Slash.ToString();

            if (originalPath[originalPath.Length - 1] == Slash)
                return originalPath;

            StringBuilder returnValue = new StringBuilder(originalPath);
            returnValue.Append(Slash);
            return returnValue.ToString();
        }

        public static string RemoveTrailingSlah(string source)
        {
            if (String.IsNullOrEmpty(source))
                return Slash.ToString();

            StringBuilder returnValue = new StringBuilder(source);

            while (returnValue[returnValue.Length - 1] == Slash)
            {
                returnValue.Remove(returnValue.Length - 1, 1);
                if (returnValue.Length == 0)
                    break;
            }

            return returnValue.ToString();
        }


        public static string RemoveFirstSlash(string source)
        {
            if (String.IsNullOrEmpty(source))
                return String.Empty;

            if (source.StartsWith(Slash.ToString()))
                return source.Substring(Slash.ToString().Length);
            else
                return source;            
        }

    }
}