using Iris.Explorer.Contract.Interfaces;
using Iris.Fx.Domain;
using Iris.Fx.Networking.Wcf;

namespace Iris.Explorer.Contract.Agent
{
	public class ExplorerAgent : DiscoProxy<IExplorer>, IExplorerAgent
	{
	    public bool Initialize()
	    {
	        IExplorer clt = null;
	        try
	        {
	            clt = CreateClient();
	            return clt.Initialize();

	        }
	        finally
	        {
                CloseClient(clt);
	        }
	    }

	    public PerspectiveItem[] GetPerspectiveItems()
		{
            IExplorer clt = null;
            try
            {
                clt = CreateClient();
                return clt.GetPerspectiveItems();

            }
            finally
            {
                CloseClient(clt);
            }
		}

		public PerspectiveItem[] GetPerspectiveItemsTop()
		{
            IExplorer clt = null;
            try
            {
                clt = CreateClient();
                return clt.GetPerspectiveItemsTop();

            }
            finally
            {
                CloseClient(clt);
            }
		}

		public PerspectiveItem GetPerspectiveItem(string id)
		{
            IExplorer clt = null;
            try
            {
                clt = CreateClient();
                return clt.GetPerspectiveItem(id);

            }
            finally
            {
                CloseClient(clt);
            }
		}

		public PerspectiveItem[] GetPerspectiveItemsForEnumeration(string enumerationId)
		{
            IExplorer clt = null;
            try
            {
                clt = CreateClient();
                return clt.GetPerspectiveItemsForEnumeration(enumerationId);

            }
            finally
            {
                CloseClient(clt);
            }
		}

		public PerspectiveItem[] GetPerspectiveItemsForParentPerspective(string parentId)
		{
            IExplorer clt = null;
            try
            {
                clt = CreateClient();
                return clt.GetPerspectiveItemsForParentPerspective(parentId);

            }
            finally
            {
                CloseClient(clt);
            }
		}

		public PerspectiveItem[] GetPerspectiveItemsForParentPerspectiveAndEnumerationType(string parentId, string typeId)
		{
            IExplorer clt = null;
            try
            {
                clt = CreateClient();
                return clt.GetPerspectiveItemsForParentPerspectiveAndEnumerationType(parentId, typeId);

            }
            finally
            {
                CloseClient(clt);
            }
		}

		public PerspectiveItem[] GetPerspectiveItemsForType(string typeId)
		{
            IExplorer clt = null;
            try
            {
                clt = CreateClient();
                return clt.GetPerspectiveItemsForType(typeId);

            }
            finally
            {
                CloseClient(clt);
            }
		}

		public EnumerationItem[] GetEnumerationItemsTop()
		{
            IExplorer clt = null;
            try
            {
                clt = CreateClient();
                return clt.GetEnumerationItemsTop();

            }
            finally
            {
                CloseClient(clt);
            }
		}

		public EnumerationItem GetEnumerationItem(string id)
		{
            IExplorer clt = null;
            try
            {
                clt = CreateClient();
                return clt.GetEnumerationItem(id);

            }
            finally
            {
                CloseClient(clt);
            }
		}

		public EnumerationItem[] GetEnumerationItemsForType(string typeId)
		{
            IExplorer clt = null;
            try
            {
                clt = CreateClient();
                return clt.GetEnumerationItemsForType(typeId);

            }
            finally
            {
                CloseClient(clt);
            }
		}

		public EnumerationItem[] GetEnumerationItemsForParentPerspective(string parentId)
		{
            IExplorer clt = null;
            try
            {
                clt = CreateClient();
                return clt.GetEnumerationItemsForParentPerspective(parentId);

            }
            finally
            {
                CloseClient(clt);
            }
		}

		public EnumerationItem[] GetEnumerationItemsTypesForParentPerspective(string parentId)
		{
            IExplorer clt = null;
            try
            {
                clt = CreateClient();
                return clt.GetEnumerationItemsTypesForParentPerspective(parentId);

            }
            finally
            {
                CloseClient(clt);
            }
		}

		public EnumerationItem[] GetEnumerationItemsForSearch(string searchString)
		{
            IExplorer clt = null;
            try
            {
                clt = CreateClient();
                return clt.GetEnumerationItemsForSearch(searchString);

            }
            finally
            {
                CloseClient(clt);
            }
		}

		public EnumerationPropertyItem GetEnumerationPropertyItem(string id)
		{
            IExplorer clt = null;
            try
            {
                clt = CreateClient();
                return clt.GetEnumerationPropertyItem(id);

            }
            finally
            {
                CloseClient(clt);
            }
		}

		public EnumerationPropertyItem[] GetEnumerationPropertyItemsForType(string typeId)
		{
            IExplorer clt = null;
            try
            {
                clt = CreateClient();
                return clt.GetEnumerationPropertyItemsForType(typeId);

            }
            finally
            {
                CloseClient(clt);
            }
		}

		public EnumerationPropertyItem[] GetEnumerationPropertyItemsForEnumeration(string enumerationId)
		{
            IExplorer clt = null;
            try
            {
                clt = CreateClient();
                return clt.GetEnumerationPropertyItemsForEnumeration(enumerationId);

            }
            finally
            {
                CloseClient(clt);
            }
		}

		public EnumerationLinkItem GetEnumerationLinkItem(string id)
		{
            IExplorer clt = null;
            try
            {
                clt = CreateClient();
                return clt.GetEnumerationLinkItem(id);

            }
            finally
            {
                CloseClient(clt);
            }
		}

		public EnumerationLinkItem[] GetEnumerationLinkItemsForTarget(string targetId)
		{
            IExplorer clt = null;
            try
            {
                clt = CreateClient();
                return clt.GetEnumerationLinkItemsForTarget(targetId);

            }
            finally
            {
                CloseClient(clt);
            }
		}

		public EnumerationLinkItem[] GetEnumerationLinkItemsForType(string typeId)
		{
            IExplorer clt = null;
            try
            {
                clt = CreateClient();
                return clt.GetEnumerationLinkItemsForType(typeId);

            }
            finally
            {
                CloseClient(clt);
            }
		}

		public EnumerationLinkItem[] GetEnumerationLinkItemsForSource(string sourceId)
		{
            IExplorer clt = null;
            try
            {
                clt = CreateClient();
                return clt.GetEnumerationLinkItemsForSource(sourceId);

            }
            finally
            {
                CloseClient(clt);
            }
		}

		public EnumerationItem SaveEnumerationItem(EnumerationItem enumerationItem)
		{
            IExplorer clt = null;
            try
            {
                clt = CreateClient();
                return clt.SaveEnumerationItem(enumerationItem);

            }
            finally
            {
                CloseClient(clt);
            }
		}

		public EnumerationPropertyItem SaveEnumerationPropertyItem(EnumerationPropertyItem enumerationPropertyItem)
		{
            IExplorer clt = null;
            try
            {
                clt = CreateClient();
                return clt.SaveEnumerationPropertyItem(enumerationPropertyItem);

            }
            finally
            {
                CloseClient(clt);
            }
		}

		public EnumerationLinkItem SaveEnumerationLinkItem(EnumerationLinkItem enumerationLinkItem)
		{
            IExplorer clt = null;
            try
            {
                clt = CreateClient();
                return clt.SaveEnumerationLinkItem(enumerationLinkItem);

            }
            finally
            {
                CloseClient(clt);
            }
		}

		public PerspectiveItem SavePerspectiveItem(PerspectiveItem perspectiveItem)
		{
            IExplorer clt = null;
            try
            {
                clt = CreateClient();
                return clt.SavePerspectiveItem(perspectiveItem);

            }
            finally
            {
                CloseClient(clt);
            }
		}

		public EnumerationItem DeleteEnumerationItem(string id)
		{
            IExplorer clt = null;
            try
            {
                clt = CreateClient();
                return clt.DeleteEnumerationItem(id);

            }
            finally
            {
                CloseClient(clt);
            }
		}

		public EnumerationPropertyItem DeleteEnumerationPropertyItem(string id)
		{
            IExplorer clt = null;
            try
            {
                clt = CreateClient();
                return clt.DeleteEnumerationPropertyItem(id);

            }
            finally
            {
                CloseClient(clt);
            }
		}

		public EnumerationLinkItem DeleteEnumerationLinkItem(string id)
		{
            IExplorer clt = null;
            try
            {
                clt = CreateClient();
                return clt.DeleteEnumerationLinkItem(id);

            }
            finally
            {
                CloseClient(clt);
            }
		}

		public PerspectiveItem DeletePerspectiveItem(string id)
		{
            IExplorer clt = null;
            try
            {
                clt = CreateClient();
                return clt.DeletePerspectiveItem(id);

            }
            finally
            {
                CloseClient(clt);
            }
		}
    }
}