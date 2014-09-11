using System.ServiceModel;
using Iris.Authentication.Business;
using Iris.Fx.Domain;
using Iris.WinAuthentication.Contract.Interfaces;


namespace Iris.WinAuthentication.Service
{
    [ServiceBehavior(IncludeExceptionDetailInFaults=true)]
    public class WinAuthenticationService :  IWinAuthentication
    {
        #region IWinAuthenticationService Members

        public IrisSession AuthenticateUserCredentials()
        {
                return AuthenticationProviderFactory
                    .CreateProvider()
                    .AuthenticateUserCredentials(ServiceSecurityContext.Current.WindowsIdentity);

        }

     
        #endregion
    }
}
