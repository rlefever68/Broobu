using System;
using Wulka.Domain;
using Wulka.Domain.Authentication;

namespace Broobu.SessionProxy.Contract.Interfaces
{
    public interface IQuerySessionAgent : IQuerySession
    {
        void GetSessionsAsync();
        void GetSessionsAsync(Action<WulkaSession[]> act);
        event Action<WulkaSession[]> GetSessionsCompleted;
    }
}