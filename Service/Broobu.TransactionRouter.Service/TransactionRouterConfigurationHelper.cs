using System.Configuration;

namespace Pms.TransactionRouter.Service
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public class TransactionRouterConfigurationHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        public class AppSettingsKey
        {
            /// <summary>
            /// 
            /// </summary>
            public const string PluginAssemblyLocation = "Router.PluginAssemblyLocation";
        }

        /// <summary>
        /// Gets the plugin assembly location.
        /// </summary>
        /// <remarks></remarks>
        public static string PluginAssemblyLocation
        {
            get
            {
                return ConfigurationManager.AppSettings[AppSettingsKey.PluginAssemblyLocation];
            }
        }
    }
}
