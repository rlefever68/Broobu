using System;
using Iris.MonitorSession.Contract.Domain;

namespace Iris.MonitorSession.Contract.Interfaces
{
    public interface IMonitorSessionAgent : IMonitorSession
    {
        event Action<SessionViewItem[]> GetSessionsCompleted;
        void GetSessionsAsync();
    }
}
