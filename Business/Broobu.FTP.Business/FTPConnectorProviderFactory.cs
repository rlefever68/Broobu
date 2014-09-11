using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pms.FTP.Business.Interfaces;

namespace Pms.FTP.Business
{
    public class FTPConnectorProviderFactory
    {

        public class Key
        {
            public const string Instance = "Instance";
        }

        public static IFTPConnectorProvider CreateProvider(string key)
        {
            switch (key)
            {
                case Key.Instance:
                default:
                    return new FTPConnectorProvider();
            }
        }
    }
}
