using System.ServiceProcess;

namespace Broobu.CloudEngine.WinService
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var servicesToRun = new ServiceBase[] 
			{ 
				new CloudEngineHost() 
			};
            ServiceBase.Run(servicesToRun);
        }
    }
}
