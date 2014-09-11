using System;
using Iris.Fx.Domain;

namespace Iris.WinAuthentication.Contract.Interfaces
{
    public interface IWinAuthenticationAgent : IWinAuthentication
    {
        void AuthenticateUserCredentialsAsync(Action<IrisSession> act);
    }
}
