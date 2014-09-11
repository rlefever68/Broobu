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
    public interface IExplorer
    {
        [OperationContract]
        bool Initialize();

        // get
        [OperationContract]
        PerspectiveItem[] GetPerspectiveItems();
        [OperationContract]
        PerspectiveItem[] GetPerspectiveItemsTop();
        [OperationContract]
        PerspectiveItem GetPerspectiveItem(string id);
        [OperationContract]
        PerspectiveItem[] GetPerspectiveItemsForEnumeration(string enumerationId);
        [OperationContract]
        PerspectiveItem[] GetPerspectiveItemsForParentPerspective(string parentId);
        [OperationContract]
        PerspectiveItem[] GetPerspectiveItemsForParentPerspectiveAndEnumerationType(string parentId, string typeId);
        [OperationContract]
        PerspectiveItem[] GetPerspectiveItemsForType(string typeId);
        [OperationContract]
        EnumerationItem[] GetEnumerationItemsTop();
        [OperationContract]
        EnumerationItem GetEnumerationItem(string id);
        [OperationContract]
        EnumerationItem[] GetEnumerationItemsForType(string typeId);
        [OperationContract]
        EnumerationItem[] GetEnumerationItemsForParentPerspective(string parentId);
        [OperationContract]
        EnumerationItem[] GetEnumerationItemsTypesForParentPerspective(string parentId);
        [OperationContract]
        EnumerationItem[] GetEnumerationItemsForSearch(string searchString);
        [OperationContract]
        EnumerationPropertyItem GetEnumerationPropertyItem(string id);
        [OperationContract]
        EnumerationPropertyItem[] GetEnumerationPropertyItemsForType(string typeId);
        [OperationContract]
        EnumerationPropertyItem[] GetEnumerationPropertyItemsForEnumeration(string enumerationId);
        [OperationContract]
        EnumerationLinkItem GetEnumerationLinkItem(string id);
        [OperationContract]
        EnumerationLinkItem[] GetEnumerationLinkItemsForTarget(string targetId);
        [OperationContract]
        EnumerationLinkItem[] GetEnumerationLinkItemsForType(string typeId);
        [OperationContract]
        EnumerationLinkItem[] GetEnumerationLinkItemsForSource(string sourceId);

        // save
        [OperationContract]
        EnumerationItem SaveEnumerationItem(EnumerationItem enumerationItem);
        [OperationContract]
        EnumerationPropertyItem SaveEnumerationPropertyItem(EnumerationPropertyItem enumerationPropertyItem);
        [OperationContract]
        EnumerationLinkItem SaveEnumerationLinkItem(EnumerationLinkItem enumerationLinkItem);
        [OperationContract]
        PerspectiveItem SavePerspectiveItem(PerspectiveItem perspectiveItem);

        // delete
        [OperationContract]
        EnumerationItem DeleteEnumerationItem(string id);
        [OperationContract]
        EnumerationPropertyItem DeleteEnumerationPropertyItem(string id);
        [OperationContract]
        EnumerationLinkItem DeleteEnumerationLinkItem(string id);
        [OperationContract]
        PerspectiveItem DeletePerspectiveItem(string id);
    }
}
