using System;
using Iris.Fx.Domain;


namespace Broobu.Media.Contract.Interfaces
{
    public interface ISettingAgent : ISetting
    {
        void SaveSettingsAsync(SettingItem item, Action<SettingItem> action);
        void GetSettingsAsync(SettingItem request, Action<SettingItem> action);
    }
}
