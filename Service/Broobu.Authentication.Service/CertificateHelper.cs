using System.Configuration;
using System.Security.Cryptography.X509Certificates;

namespace Broobu.Authentication.Service
{
    public class CertificateHelper
    {

        internal static StoreLocation GetStoreLocation()
        {
            return StoreLocation.LocalMachine;
        }
        

        internal static StoreName GetStoreName()
        {
            string key = ConfigurationManager.AppSettings[AppSettingsKey.StoreName];
            switch(key)
            {
                case "My": 
                    return StoreName.My;
                case "AuthRoot": 
                    return StoreName.AuthRoot;
                case "CA": 
                    return StoreName.CertificateAuthority;
                case "Root":
                    return StoreName.Root;
                case "TrustedPublisher":
                default:
                    return StoreName.TrustedPublisher;
            }
        }

        internal static string GetCertificateSubject()
        {
            return ConfigurationManager.AppSettings[AppSettingsKey.Subject];
        }
    }
}
