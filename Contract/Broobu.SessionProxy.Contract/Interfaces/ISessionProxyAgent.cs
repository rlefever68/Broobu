using System;
using Wulka.Domain;
using Wulka.Domain.Authentication;

namespace Broobu.SessionProxy.Contract.Interfaces
{
    public interface ISessionProxyAgent : ISessionProxy
    {
        void StartSessionAsync(WulkaSession session);
        void EndSessionAsync(WulkaSession session);
        event Action<WulkaSession> EndSessionCompleted;
        event Action<WulkaSession> StartSessionCompleted;
    }
}