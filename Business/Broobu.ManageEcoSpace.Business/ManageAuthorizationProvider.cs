using Broobu.ManageAuthorization.Business.Interfaces;
using Broobu.ManageAuthorization.Business.Workers;

namespace Broobu.ManageAuthorization.Business
{
    public class ManageAuthorizationProvider
    {
        /// <summary>
        /// Creates the ManageAuthorization provider.
        /// </summary>
        /// <returns></returns>
        public static IManageAuthorizations Platform
        {
            get 
            {
                return new ManageAuthorizations();
            }
        }
    }
}
