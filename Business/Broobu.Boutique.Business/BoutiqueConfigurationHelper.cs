using System.Configuration;

namespace Broobu.Boutique.Business
{
    /// <summary>
    /// Class BoutiqueConfiguration.
    /// </summary>
    public class BoutiqueConfigurationHelper
    {
        /// <summary>
        /// Gets the menu source.
        /// </summary>
        /// <value>The menu source.</value>
        public static string MenuSource 
        {
            get
            {
                return ConfigurationManager.AppSettings[AppSettingsKey.MenuSource] == null ? Const.Xml : Const.Store;
            }
        }

        /// <summary>
        /// Class AppSettingsKey.
        /// </summary>
        public class AppSettingsKey
        {
            /// <summary>
            /// The menu source
            /// </summary>
            public const string MenuSource = "Boutique.MenuSource";
        }

        /// <summary>
        /// Class Const.
        /// </summary>
        public class Const
        {
            /// <summary>
            /// The XML
            /// </summary>
            public const string Xml = "Xml";
            public const string Store = "Store";
        }
    }
}