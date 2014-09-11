using System;
using Broobu.MonitorDisco.Contract.Domain;

namespace Broobu.MonitorDisco.Contract.Interfaces
{
    public interface IMonitorDiscoAgent : IMonitorDisco
    {
        event Action<DiscoInfo[]> GetAllEndpointsCompleted;
        void GetAllEndpointsAsync();
        void GetAllEndpointsAsync(Action<DiscoInfo[]> action);
    }
}
