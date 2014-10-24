using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Broobu.Disco.Service;
using Broobu.MonitorDisco.Service;
using NLog;
using Wulka.Exceptions;
using Wulka.Networking.Wcf;

namespace Broobu.Disco.Cons
{
    class Program
    {

        /// <summary>
        /// The _logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();


        private static ServiceHost _disco = null;

        private static ServiceHost Disco
        {
            get
            {
                return _disco
                       ?? (_disco = SentryHostFactory.CreateAnnouncingHost(typeof(DiscoSentry),
                           new[] { new Uri(ConfigurationHelper.DiscoUrl) }));
            }
        }

        private static ServiceHost _monitor = null;
        private static ServiceHost _cloudContract;

        private static ServiceHost Monitor
        {
            get
            {
                return _monitor
                       ?? (_monitor = SentryHostFactory.CreateAnnouncingHost(typeof(MonitorDiscoSentry),
                           new[] { new Uri(ConfigurationHelper.MonitorUrl) }));
            }
        }


        private static ServiceHost CloudContract
        {
            get
            {
                return _cloudContract
                    ?? (_cloudContract = SentryHostFactory.CreateAnnouncingHost(typeof(CloudContractSentry),

                    new[] { new Uri(ConfigurationHelper.CloudContractUrl) }));
            }
        }





        /// <summary>
        /// Starts the monitor disco.
        /// </summary>
        private static void StartMonitor()
        {
            try
            {
                Monitor.Open();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.GetCombinedMessages());
                throw;
            }
        }

        /// <summary>
        /// Starts the disco.
        /// </summary>
        private static void StartDisco()
        {
            try
            {
                Disco.Open();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.GetCombinedMessages());
                throw;
            }
        }





        private static void StopCloudContract()
        {
            CloudContract.Close();
        }

        private static void StopDisco()
        {
            Disco.Close();
        }

        private static void StopMonitor()
        {
            Monitor.Close();
        }

        public static void StartCloudContract()
        {
            try
            {
                CloudContract.Open();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.GetCombinedMessages());
                throw;
            }
        }



        static void Main(string[] args)
        {
            DiscoRunner.Run(args);
            Console.ReadLine();

            //StartCloudContract();
            //StartDisco();
            //StartMonitor();

            //Console.WriteLine("\nPress Enter to terminate the services.");
            //Console.ReadLine();
            
            //StopMonitor();
            //StopDisco();
            //StopCloudContract();

            //Console.WriteLine("\nServices are terminated.\n");

        }




    }
}
