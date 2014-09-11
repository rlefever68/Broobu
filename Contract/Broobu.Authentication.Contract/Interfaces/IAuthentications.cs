using System.Security.Principal;
using Wulka.Domain;
using Wulka.Domain.Authentication;

namespace Broobu.Authentication.Contract.Interfaces
{
    public interface IAuthentications : IAuthentication
    {
        void RegisterRequiredDomainObjects();

        WulkaSession TerminateSession(WulkaSession session);

        WulkaSession AuthenticateUserCredentials(IIdentity identity);
    }
}
