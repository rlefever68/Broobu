using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Iris.Fx.Domain;
using Iris.Shell.Contract.Agent;

namespace Iris.Shell.UI.Controls
{
    public class SettingsHost
    {



        public static readonly Dictionary<string, XElement> Settings = new Dictionary<string,XElement>();
        private static Action<SettingItem> _onSettingChanged;


        /// <summary>
        /// Saves the settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public static void SaveSettings(string accountId, string applicationFunctionId, string roleId, string objectId, XElement settings, Action<SettingItem> onSettingChanged=null)
        {
            _onSettingChanged = onSettingChanged;
            ShellAgentFactory
                .CreateAgent()
                .SaveSettingsAsync(new SettingItem() 
                { 
                    Id = Guid.NewGuid().ToString(),
                    AccountId = accountId, 
                    ApplicationFunctionId = applicationFunctionId,
                    RoleId = roleId,
                    ObjectId = objectId,
                    SettingInfo = settings 
                }, ChangeSetting);
        }



        


        /// <summary>
        /// Reads the settings.
        /// </summary>
        /// <returns></returns>
        public static void GetSettingsAsync(string accountId, string applicationFunctionId, string roleId, string objectId, Action<SettingItem> onSettingChanged)
        {
            _onSettingChanged = onSettingChanged;
            SettingItem req = new SettingItem() 
            {
                ApplicationFunctionId = applicationFunctionId,
                AccountId = accountId,
                RoleId = roleId,
                ObjectId = objectId
            };
            ShellAgentFactory
                .CreateAgent()
                .GetSettingsAsync(req, ChangeSetting);
        }


        public SettingItem GetSettings(string accountId, string applicationFunctionId, string roleId, string objectId)
        {
            SettingItem req = new SettingItem()
            {
                ApplicationFunctionId = applicationFunctionId,
                AccountId = accountId,
                RoleId = roleId,
                ObjectId = objectId
            };
            return ShellAgentFactory
                .CreateAgent()
                .GetSettings(req);
        }





        

        /// <summary>
        /// Changes the settings.
        /// </summary>
        /// <param name="item">The item.</param>
        private static void ChangeSetting(SettingItem item)
        {
            if(item!=null)
                Settings[item.ApplicationFunctionId] = item.SettingInfo;
            if (_onSettingChanged != null)
            {
                _onSettingChanged(item);
                _onSettingChanged = null;
            }
        }







        












    }
}
