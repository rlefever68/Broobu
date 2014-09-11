
using Broobu.CloudMon.Contract.Agent;
using Broobu.CloudMon.Contract.Interfaces;

namespace Broobu.CloudMon.Contract
{

    public static class CloudMonPortal
    {
        public static ICloudMonAgent Agent 
        {
            get 
            { 
                return new CloudMonAgent();
            }
        }
    }
}
