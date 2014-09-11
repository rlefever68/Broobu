using System.ServiceModel;
using Iris.Fx.Domain;

namespace Broobu.Media.Contract.Interfaces
{

    [ServiceKnownType(typeof(Result))]
    [ServiceKnownType(typeof(DomainObject<EnumerationItem>))]
    [ServiceContract(Namespace = MediaServiceConst.Namespace)]
    public interface IEnumeration 
    {
        [OperationContract]
        EnumerationItem GetById(string id);

        [OperationContract]
        EnumerationItem Save(EnumerationItem it);


        [OperationContract]
        EnumerationItem RegisterEnumerationType(EnumerationItem item);


        [OperationContract]
        EnumerationItem[] GetEnumerationItemsForType(string typeId);

        [OperationContract]
        EnumerationItem[] SaveEnumerations(EnumerationItem[] enums);

        [OperationContract]
        EnumerationItem[] DeleteEnumerations(EnumerationItem[] enums);

        [OperationContract]
        EnumerationItem DeleteEnumerationItem(EnumerationItem item);


    }
}
