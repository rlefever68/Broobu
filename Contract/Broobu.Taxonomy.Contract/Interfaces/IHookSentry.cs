using System.ServiceModel;
using Broobu.Taxonomy.Contract.Domain;
using Wulka.Domain;
using Wulka.Domain.Base;

namespace Broobu.Taxonomy.Contract.Interfaces
{

    [ServiceKnownType(typeof(Result))]
    [ServiceKnownType(typeof(DomainObject<Hook>))]
    [ServiceContract(Namespace = TaxonomyConst.Namespace)]
    public interface IHookSentry
    {

        [OperationContract]
        Hook GetById(string id);

        [OperationContract]
        Hook Save(Hook it);


        [OperationContract]
        Hook RegisterEnumerationType(Hook item);


        [OperationContract]
        Hook[] GetEnumerationsForType(string typeId);

        [OperationContract]
        Hook[] SaveEnumerations(Hook[] enums);

        [OperationContract]
        Hook[] DeleteEnumerations(Hook[] enums);

        [OperationContract]
        Hook DeleteEnumeration(Hook item);

        [OperationContract]
        string GetTaxonomyHookId(string id, string displayName, string ecoSpace);

        //[OperationContract]
        //Hook[] GetChildren(Hook root, bool hydrate=false);

        [OperationContract]
        Hook GetHook(string id, string displayName, string ecoSpace);


    }
}
