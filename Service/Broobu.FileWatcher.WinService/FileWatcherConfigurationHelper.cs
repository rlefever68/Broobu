using System.Configuration;

namespace Pms.FileWatcher.WinService
{
    public class FileWatcherConfigurationHelper
    {

        public class AppSettingsKey
        {
            public const string InboxPath = "FileWatcher.InboxPath";
            public const string ReceivedPath = "FileWatcher.ReceivedPath";
            public const string ErrorPath = "FileWatcher.ErrorPath";
            public const string QueueName = "FileWatcher.QueueName";
        }



        public static string InboxPath
        {
            get
            {
                 return ConfigurationManager.AppSettings[AppSettingsKey.InboxPath];
            }
        }

        public static string ReceivedPath
        {
            get
            {
                return ConfigurationManager.AppSettings[AppSettingsKey.ReceivedPath];
            }
        }

        public static string ErrorPath
        {
            get
            {
                return ConfigurationManager.AppSettings[AppSettingsKey.ErrorPath];
            }
        }

        public static string QueueName
        {
            get
            {
                return ConfigurationManager.AppSettings[AppSettingsKey.QueueName];
            }
        }


    }
}
