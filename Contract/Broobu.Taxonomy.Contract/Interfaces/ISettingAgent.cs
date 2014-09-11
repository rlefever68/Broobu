using System;
using Broobu.Taxonomy.Contract.Domain;

namespace Broobu.Taxonomy.Contract.Interfaces
{
    public interface ISettingAgent : ISetting
    {
        void SaveSettingsAsync(Setting item, Action<Setting> action);
        void GetSettingsAsync(Setting request, Action<Setting> action);
    }
}
