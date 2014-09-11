
using log4net;
using Pms.Explorer.Business;

using Pms.Framework.Networking.Wcf;
using Pms.Framework.Domain;
using Pms.Explorer.Contract.Interfaces;

namespace Pms.Explorer.Service
{
    public class ExplorerService : BusinessServiceBase, IExplorer, IExplorer2
    {
        private const string DebugWriteLinePrefix = "Pms.Explorer.Service.ExplorerService";

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <returns></returns>
        public bool Initialize()
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance)
                .Initialize();
        }

        /// <summary>
        /// Gets the perspective items.
        /// </summary>
        /// <returns></returns>
        public PerspectiveItem[] GetPerspectiveItems()
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance)
                .GetPerspectiveItems();
        }

        /// <summary>
        /// Gets the perspective items top.
        /// </summary>
        /// <returns></returns>
        public PerspectiveItem[] GetPerspectiveItemsTop()
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance)
                .GetPerspectiveItemsTop();
        }

        /// <summary>
        /// Gets the perspective item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public PerspectiveItem GetPerspectiveItem(string id)
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance)
                .GetPerspectiveItem(id);
        }

        /// <summary>
        /// Gets the perspective items for enumeration.
        /// </summary>
        /// <param name="enumerationId">The enumeration id.</param>
        /// <returns></returns>
        public PerspectiveItem[] GetPerspectiveItemsForEnumeration(string enumerationId)
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance)
                .GetPerspectiveItemsForEnumeration(enumerationId);
        }

        /// <summary>
        /// Gets the perspective items for parent perspective.
        /// </summary>
        /// <param name="parentId">The parent id.</param>
        /// <returns></returns>
        public PerspectiveItem[] GetPerspectiveItemsForParentPerspective(string parentId)
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance)
                .GetPerspectiveItemsForParentPerspective(parentId);
        }

        /// <summary>
        /// Gets the type of the perspective items for parent perspective and enumeration.
        /// </summary>
        /// <param name="parentId">The parent id.</param>
        /// <param name="typeId">The type id.</param>
        /// <returns></returns>
        public PerspectiveItem[] GetPerspectiveItemsForParentPerspectiveAndEnumerationType(string parentId, string typeId)
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance)
                .GetPerspectiveItemsForParentPerspectiveAndEnumerationType(parentId, typeId);
        }

        /// <summary>
        /// Gets the type of the perspective items for.
        /// </summary>
        /// <param name="typeId">The type id.</param>
        /// <returns></returns>
        public PerspectiveItem[] GetPerspectiveItemsForType(string typeId)
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance)
                .GetPerspectiveItemsForType(typeId);
        }


        /// <summary>
        /// Gets the enumeration items top.
        /// </summary>
        /// <returns></returns>
        public EnumerationItem[] GetEnumerationItemsTop()
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance)
                .GetEnumerationItemsTop();
        }

        /// <summary>
        /// Gets the enumeration item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public EnumerationItem GetEnumerationItem(string id)
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance)
                .GetEnumerationItem(id);
        }

        /// <summary>
        /// Gets the type of the enumeration items for.
        /// </summary>
        /// <param name="typeId">The type id.</param>
        /// <returns></returns>
        public EnumerationItem[] GetEnumerationItemsForType(string typeId)
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance)
                .GetEnumerationItemsForType(typeId);
        }

        /// <summary>
        /// Gets the enumeration items for parent perspective.
        /// </summary>
        /// <param name="parentId">The parent id.</param>
        /// <returns></returns>
        public EnumerationItem[] GetEnumerationItemsForParentPerspective(string parentId)
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance)
                .GetEnumerationItemsForParentPerspective(parentId);
        }

        /// <summary>
        /// Gets the enumeration items types for parent perspective.
        /// </summary>
        /// <param name="parentId">The parent id.</param>
        /// <returns></returns>
        public EnumerationItem[] GetEnumerationItemsTypesForParentPerspective(string parentId)
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance)
                .GetEnumerationItemsTypesForParentPerspective(parentId);
        }

        /// <summary>
        /// Gets the enumeration items for search.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <returns></returns>
        public EnumerationItem[] GetEnumerationItemsForSearch(string searchString)
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance)
                .GetEnumerationItemsForSearch(searchString);
        }

        /// <summary>
        /// Gets the enumeration property item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public EnumerationPropertyItem GetEnumerationPropertyItem(string id)
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance)
                .GetEnumerationPropertyItem(id);
        }

        /// <summary>
        /// Gets the type of the enumeration property items for.
        /// </summary>
        /// <param name="typeId">The type id.</param>
        /// <returns></returns>
        public EnumerationPropertyItem[] GetEnumerationPropertyItemsForType(string typeId)
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance)
                .GetEnumerationPropertyItemsForType(typeId);
        }

        /// <summary>
        /// Gets the enumeration property items for enumeration.
        /// </summary>
        /// <param name="enumerationId">The enumeration id.</param>
        /// <returns></returns>
        public EnumerationPropertyItem[] GetEnumerationPropertyItemsForEnumeration(string enumerationId)
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance)
                .GetEnumerationPropertyItemsForEnumeration(enumerationId);
        }

        /// <summary>
        /// Gets the enumeration link item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public EnumerationLinkItem GetEnumerationLinkItem(string id)
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance)
                .GetEnumerationLinkItem(id);
        }

        /// <summary>
        /// Gets the enumeration link items for target.
        /// </summary>
        /// <param name="targetId">The target id.</param>
        /// <returns></returns>
        public EnumerationLinkItem[] GetEnumerationLinkItemsForTarget(string targetId)
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance)
                .GetEnumerationLinkItemsForTarget(targetId);
        }

        /// <summary>
        /// Gets the type of the enumeration link items for.
        /// </summary>
        /// <param name="typeId">The type id.</param>
        /// <returns></returns>
        public EnumerationLinkItem[] GetEnumerationLinkItemsForType(string typeId)
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance)
                .GetEnumerationLinkItemsForType(typeId);
        }

        /// <summary>
        /// Gets the enumeration link items for source.
        /// </summary>
        /// <param name="sourceId">The source id.</param>
        /// <returns></returns>
        public EnumerationLinkItem[] GetEnumerationLinkItemsForSource(string sourceId)
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance)
                .GetEnumerationLinkItemsForSource(sourceId);
        }

        /// <summary>
        /// Saves the enumeration item.
        /// </summary>
        /// <param name="enumerationItem">The enumeration item.</param>
        /// <returns></returns>
        public EnumerationItem SaveEnumerationItem(EnumerationItem enumerationItem)
        {
            Logger.InfoFormat("Received call to save enumeration: {0}", enumerationItem.Id);
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance)
                .SaveEnumerationItem(enumerationItem);
        }

        /// <summary>
        /// Saves the enumeration property item.
        /// </summary>
        /// <param name="enumerationPropertyItem">The enumeration property item.</param>
        /// <returns></returns>
        public EnumerationPropertyItem SaveEnumerationPropertyItem(EnumerationPropertyItem enumerationPropertyItem)
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance)
                .SaveEnumerationPropertyItem(enumerationPropertyItem);
        }

        /// <summary>
        /// Saves the enumeration link item.
        /// </summary>
        /// <param name="enumerationLinkItem">The enumeration link item.</param>
        /// <returns></returns>
        public EnumerationLinkItem SaveEnumerationLinkItem(EnumerationLinkItem enumerationLinkItem)
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance)
                .SaveEnumerationLinkItem(enumerationLinkItem);
        }

        /// <summary>
        /// Saves the perspective item.
        /// </summary>
        /// <param name="perspectiveItem">The perspective item.</param>
        /// <returns></returns>
        public PerspectiveItem SavePerspectiveItem(PerspectiveItem perspectiveItem)
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance)
                .SavePerspectiveItem(perspectiveItem);
        }

        /// <summary>
        /// Deletes the enumeration item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public EnumerationItem DeleteEnumerationItem(string id)
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance)
                .DeleteEnumerationItem(id);
        }

        /// <summary>
        /// Deletes the enumeration property item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public EnumerationPropertyItem DeleteEnumerationPropertyItem(string id)
        {
           return ExplorerProviderFactory
               .CreateProvider(ExplorerProviderFactory.Key.Instance)
               .DeleteEnumerationPropertyItem(id);
        }

        /// <summary>
        /// Deletes the enumeration link item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public EnumerationLinkItem DeleteEnumerationLinkItem(string id)
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance)
                .DeleteEnumerationLinkItem(id);
        }

        /// <summary>
        /// Deletes the perspective item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public PerspectiveItem DeletePerspectiveItem(string id)
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance)
                .DeletePerspectiveItem(id);
        }


        /// <summary>
        /// You MUST override this method, but you cannot use
        /// Initializing code in the constructor that references itself (since the object is not yet created) - Obsolete remark
        /// REMARK: since the code has been moved to the onOpen method of the servicehost; you can be certain now that
        /// the object has been created.
        /// </summary>
        protected override void RegisterRequiredDomainObjects()
        {
             ExplorerProviderFactory
                 .CreateProvider(ExplorerProviderFactory.Key.Instance)
                 .Initialize();
        }

        public EnumerationItem[] GetEnumerationItemsForReasonAndAdviceTitles(string categoryId, string problemId, string subjectId, string adviceCode)
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance).GetEnumerationItemsForReasonAndAdviceTitles(
                    categoryId, problemId, subjectId, adviceCode);
        }

        public EnumerationItem[] GetEnumerationItemsLikeType(string typeId)
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance).GetEnumerationItemsLikeType(typeId);
        }

        public EnumerationWithPropertyValueItem[] GetEnumerationWithPropertyValueItemsForTypeAndEnumerationPropertyValue(string typeId, string property)
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance).GetEnumerationWithPropertyValueItemsForTypeAndEnumerationPropertyValue(typeId, property);
        }

        public EnumerationWithPropertyValueItem[] GetEnumerationWithPropertyValueItemsForTypeAndParentEnumerationProperty(string typeId, string property, string propertyValue)
        {
            return ExplorerProviderFactory
                .CreateProvider(ExplorerProviderFactory.Key.Instance).GetEnumerationWithPropertyValueItemsForTypeAndParentEnumerationProperty(typeId, property, propertyValue);
        }

        public EnumerationPropertyItem[] GetEnumerationPropertyItemsLikeType(string typeId)
        {
            return ExplorerProviderFactory
               .CreateProvider(ExplorerProviderFactory.Key.Instance).GetEnumerationPropertyItemsLikeType(typeId);
        }

        public EnumerationPropertyItem GetEnumerationPropertyItemForEnumerationAndEnumerationPropertyTitle(string enumerationId, string property)
        {
            return ExplorerProviderFactory
               .CreateProvider(ExplorerProviderFactory.Key.Instance).GetEnumerationPropertyItemForEnumerationAndEnumerationPropertyTitle(enumerationId, property);
        }
    }
}
