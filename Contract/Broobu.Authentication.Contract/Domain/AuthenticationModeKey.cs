namespace Broobu.Authentication.Contract.Domain
{
    public class AuthenticationModeKey
    {
        public const string Windows = "WindowsAuthentication";
        public const string Native = "NativeAuthentication";
        public const string OpenId = "OpenIdAuthentication";
        public const string Kerberos = "KerberosAuthentication";
        public const string Mock = "MockAuthentication";
    }
}
