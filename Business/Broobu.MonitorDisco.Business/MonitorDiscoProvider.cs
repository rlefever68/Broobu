using Broobu.MonitorDisco.Business.Interfaces;
using Broobu.MonitorDisco.Business.Provider;

namespace Broobu.MonitorDisco.Business
{
    public static class MonitorDiscoProvider
    {

        public static IDiscoViewItems DiscoViewItems 
        {
            get 
            { 
                return new DiscoViewItems();
            }
        }







    }
}
