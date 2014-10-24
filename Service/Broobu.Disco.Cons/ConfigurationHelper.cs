using System;
using System.Configuration;

namespace Broobu.Disco.Cons
{
    internal class ConfigurationHelper
    {
        public static string DiscoUrl 
        {
            get 
            {
                return String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["Console.Disco"])
                    ? "http://localhost/soa/disco"
                    : Convert.ToString(ConfigurationManager.AppSettings["Console.Disco"]);
            }
        }

        public static string MonitorUrl {
            get 
            {
                return String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["Console.Monitor"])
                    ? "http://localhost/soa/monitor"
                    : Convert.ToString(ConfigurationManager.AppSettings["Console.Monitor"]);
            }
        }

        public static string CloudContractUrl {
            get
            {
                return String.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["Console.CloudContract"])
                    ? "http://localhost/soa/cloudcontract"
                    : Convert.ToString(ConfigurationManager.AppSettings["Console.CloudContract"]);
            }

        }
    }
}