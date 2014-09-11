using System.ServiceModel;
using Iris.Fx.Domain;

namespace Iris.Explorer.Contract.Interfaces
{
    [ServiceContract(Namespace = ServiceConst.Namespace)]
    [ServiceKnownType(typeof(Result))]
    [ServiceKnownType(typeof(DomainObject<PerspectiveItem>))]
    [ServiceKnownType(typeof(DomainObject<EnumerationItem>))]
    [ServiceKnownType(typeof(DomainObject<EnumerationLinkItem>))]
    [ServiceKnownType(typeof(DomainObject<EnumerationPropertyItem>))]
    public interface IExplorer2
    {
        [OperationContract]
        EnumerationItem[] GetEnumerationItemsForReasonAndAdviceTitles(string categoryId, string problemId,
                                                                      string subjectId, string adviceCode);

        [OperationContract]
        EnumerationItem[] GetEnumerationItemsLikeType(string typeId);

        [OperationContract]
        EnumerationWithPropertyValueItem[] GetEnumerationWithPropertyValueItemsForTypeAndEnumerationPropertyValue(
            string typeId, string property);

        [OperationContract]
        EnumerationWithPropertyValueItem[] GetEnumerationWithPropertyValueItemsForTypeAndParentEnumerationProperty(
            string typeId, string property, string propertyValue);

        [OperationContract]
        EnumerationPropertyItem[] GetEnumerationPropertyItemsLikeType(string typeId);

        [OperationContract]
        EnumerationPropertyItem GetEnumerationPropertyItemForEnumerationAndEnumerationPropertyTitle(
            string enumerationId, string property);

    }
}
