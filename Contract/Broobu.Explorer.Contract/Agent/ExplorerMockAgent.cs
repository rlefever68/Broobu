using System;
using Iris.Explorer.Contract.Interfaces;
using Iris.Fx.Domain;
using Iris.Fx.Networking.Wcf;

namespace Iris.Explorer.Contract.Agent
{
    public class ExplorerMockAgent : DiscoProxy<IExplorer>, IExplorerAgent
    {
        public bool Initialize()
        {
            throw new NotImplementedException();
        }

        public PerspectiveItem[] GetPerspectiveItems()
        {
            throw new NotImplementedException();
        }

        public PerspectiveItem[] GetPerspectiveItemsTop()
        {
            throw new NotImplementedException();
        }

        public PerspectiveItem GetPerspectiveItem(string id)
        {
            throw new NotImplementedException();
        }

        public PerspectiveItem[] GetPerspectiveItemsForEnumeration(string enumerationId)
        {
            throw new NotImplementedException();
        }

        public PerspectiveItem[] GetPerspectiveItemsForParentPerspective(string parentId)
        {
            throw new NotImplementedException();
        }

        public PerspectiveItem[] GetPerspectiveItemsForParentPerspectiveAndEnumerationType(string parentId, string typeId)
        {
            throw new NotImplementedException();
        }

        public PerspectiveItem[] GetPerspectiveItemsForType(string typeId)
        {
            throw new NotImplementedException();
        }

        public EnumerationItem[] GetEnumerationItemsTop()
        {
            throw new NotImplementedException();
        }

        public EnumerationItem GetEnumerationItem(string id)
        {
            throw new NotImplementedException();
        }

        public EnumerationItem[] GetEnumerationItemsForType(string typeId)
        {
            throw new NotImplementedException();
        }

        public EnumerationItem[] GetEnumerationItemsForParentPerspective(string parentId)
        {
            throw new NotImplementedException();
        }

        public EnumerationItem[] GetEnumerationItemsTypesForParentPerspective(string parentId)
        {
            throw new NotImplementedException();
        }

        public EnumerationItem[] GetEnumerationItemsForSearch(string searchString)
        {
            throw new NotImplementedException();
        }

        public EnumerationPropertyItem GetEnumerationPropertyItem(string id)
        {
            throw new NotImplementedException();
        }

        public EnumerationPropertyItem[] GetEnumerationPropertyItemsForType(string typeId)
        {
            throw new NotImplementedException();
        }

        public EnumerationPropertyItem[] GetEnumerationPropertyItemsForEnumeration(string enumerationId)
        {
            throw new NotImplementedException();
        }

        public EnumerationLinkItem GetEnumerationLinkItem(string id)
        {
            throw new NotImplementedException();
        }

        public EnumerationLinkItem[] GetEnumerationLinkItemsForTarget(string targetId)
        {
            throw new NotImplementedException();
        }

        public EnumerationLinkItem[] GetEnumerationLinkItemsForType(string typeId)
        {
            throw new NotImplementedException();
        }

        public EnumerationLinkItem[] GetEnumerationLinkItemsForSource(string sourceId)
        {
            throw new NotImplementedException();
        }

        public EnumerationItem SaveEnumerationItem(EnumerationItem enumerationItem)
        {
            throw new NotImplementedException();
        }

        public EnumerationPropertyItem SaveEnumerationPropertyItem(EnumerationPropertyItem enumerationPropertyItem)
        {
            throw new NotImplementedException();
        }

        public EnumerationLinkItem SaveEnumerationLinkItem(EnumerationLinkItem enumerationLinkItem)
        {
            throw new NotImplementedException();
        }

        public PerspectiveItem SavePerspectiveItem(PerspectiveItem perspectiveItem)
        {
            throw new NotImplementedException();
        }

        public EnumerationItem DeleteEnumerationItem(string id)
        {
            throw new NotImplementedException();
        }

        public EnumerationPropertyItem DeleteEnumerationPropertyItem(string id)
        {
            throw new NotImplementedException();
        }

        public EnumerationLinkItem DeleteEnumerationLinkItem(string id)
        {
            throw new NotImplementedException();
        }

        public PerspectiveItem DeletePerspectiveItem(string id)
        {
            throw new NotImplementedException();
        }
    }
}
