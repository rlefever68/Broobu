using System.ServiceModel;
using Iris.Fx.Domain;


namespace Broobu.Media.Contract.Interfaces
{
    [ServiceContract(Namespace=MediaServiceConst.Namespace)]
    [ServiceKnownType(typeof(Result))]
    [ServiceKnownType(typeof(DomainObject<SettingItem>))]
    public interface ISetting
    {
        [OperationContract]
        SettingItem SaveSettings(SettingItem item);
        [OperationContract]
        SettingItem GetSettings(SettingItem request);

        [OperationContract]
        SettingItem GetSetting(string id);
    }
}
