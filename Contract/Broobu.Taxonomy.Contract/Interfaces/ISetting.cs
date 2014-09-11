using System.ServiceModel;
using Broobu.Taxonomy.Contract.Domain;
using Wulka.Domain;
using Wulka.Domain.Base;

namespace Broobu.Taxonomy.Contract.Interfaces
{
    [ServiceContract(Namespace=TaxonomyConst.Namespace)]
    [ServiceKnownType(typeof(Result))]
    [ServiceKnownType(typeof(DomainObject<Setting>))]
    public interface ISetting
    {
        [OperationContract]
        Setting SaveSettings(Setting item);
        [OperationContract]
        Setting GetSettings(Setting request);

        [OperationContract]
        Setting GetSetting(string id);
    }
}
