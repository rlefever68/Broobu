using Broobu.Media.Business;
using Broobu.Media.Contract.Interfaces;
using Iris.Fx.Domain;
using Iris.Fx.Networking.Wcf;

namespace Broobu.Media.Service
{
    public class SettingService : BusinessServiceBase, ISetting
    {
        protected override void RegisterRequiredDomainObjects()
        {
             MediaProviderFactory
                 .CreateSettingProvider()
                .RegisterRequiredDomainObjects();
        }

        #region ISetting Members

        /// <summary>
        /// Saves the settings.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public SettingItem SaveSettings(SettingItem item)
        {
            return MediaProviderFactory
                .CreateSettingProvider()
                .SaveSettings(item);
        }

        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public SettingItem GetSettings(SettingItem request)
        {
            return MediaProviderFactory
                .CreateSettingProvider()
                .GetSettings(request);
        }

        public SettingItem GetSetting(string id)
        {
            return MediaProviderFactory
                           .CreateSettingProvider()
                           .GetSetting(id);
        }

        #endregion
    }
}
