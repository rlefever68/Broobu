using System;
using System.Collections.Generic;
using System.Linq;
using Iris.Explorer.Business.Interfaces;
using Iris.Fx.Business;
using log4net;

namespace Iris.Explorer.Business
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public class ExplorerProvider : ProviderBase<>, IExplorerProvider
    {
        /// <summary>
        /// 
        /// </summary>
        private const string DebugWriteLinePrefix = "Iris.Explorer.Business.ExplorerProvider";
        /// <summary>
        /// 
        /// </summary>
        private readonly ILog _logger;

        /// <summary>
        /// 
        /// </summary>
        private IEnumerationRepositoryAgent _enumerationAgent;
        /// <summary>
        /// Gets the agent enumeration.
        /// </summary>
        /// <remarks></remarks>
        private IEnumerationRepositoryAgent EnumerationAgent
        {
            get
            {
                return _enumerationAgent ??
                       (_enumerationAgent = ExplorerRepositoryAgentFactory.CreateEnumerationRepositoryAgent());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private IEnumerationWithPropertyValueRepositoryAgent _enumerationWithPropertyValueAgent;
        /// <summary>
        /// Gets the agent enumeration with property value.
        /// </summary>
        /// <remarks></remarks>
        private IEnumerationWithPropertyValueRepositoryAgent EnumerationWithPropertyValueAgent
        {
            get
            {
                return _enumerationWithPropertyValueAgent ??
                       (_enumerationWithPropertyValueAgent =
                        ExplorerRepositoryAgentFactory.CreateEnumerationWithPropertyValueRepositoryAgent());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private IEnumerationPropertyRepositoryAgent _enumerationPropertyAgent;
        /// <summary>
        /// Gets the agent enumeration property.
        /// </summary>
        /// <remarks></remarks>
        private IEnumerationPropertyRepositoryAgent EnumerationPropertyAgent
        {
            get
            {
                return _enumerationPropertyAgent ??
                       (_enumerationPropertyAgent =
                        ExplorerRepositoryAgentFactory.CreateEnumerationPropertyRepositoryAgent());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private IEnumerationLinkRepositoryAgent _enumerationLinkAgent;
        /// <summary>
        /// Gets the agent enumeration link.
        /// </summary>
        /// <remarks></remarks>
        private IEnumerationLinkRepositoryAgent EnumerationLinkAgent
        {
            get
            {
                if (_enumerationLinkAgent != null) return _enumerationLinkAgent;
                _enumerationLinkAgent = ExplorerRepositoryAgentFactory.CreateEnumerationLinkRepositoryAgent();
                return _enumerationLinkAgent;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        /// <remarks></remarks>
        public ExplorerProvider()
        {
            _logger = LogManager.GetLogger(GetType());
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool Initialize()
        {
            _logger.Info("Initialize...");
            var gen = new ExplorerBusinessGenerator();
            return gen.Generate();
        }

        /// <summary>
        /// Gets all the perspective items.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public PerspectiveItem[] GetPerspectiveItems()
        {
            return new PerspectiveItemMapper()
                .MapFromServiceToBusiness(ExplorerRepositoryAgentFactory
                .CreatePerspectiveRepositoryAgent()
                .SelectAll());
        }

        /// <summary>
        /// Gets the perspective items top.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public PerspectiveItem[] GetPerspectiveItemsTop()
        {
            return new PerspectiveItemMapper()
                .MapFromServiceToBusiness(ExplorerRepositoryAgentFactory
                .CreatePerspectiveRepositoryAgent()
                .SelectTop());
        }

        /// <summary>
        /// Deletes the perspective item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public PerspectiveItem DeletePerspectiveItem(string id)
        {
            var result = GetPerspectiveItem(id);
            ExplorerRepositoryAgentFactory
                .CreatePerspectiveRepositoryAgent()
                .Delete(id);
            return result;
        }


        /// <summary>
        /// Gets the perspective item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public PerspectiveItem GetPerspectiveItem(string id)
        {
            return new PerspectiveItemMapper()
                .MapFromServiceToBusiness(ExplorerRepositoryAgentFactory
                .CreatePerspectiveRepositoryAgent()
                .SelectById(id));
        }


        /// <summary>
        /// Saves the perspective item.
        /// </summary>
        /// <param name="perspectiveItem">The perspective item.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public PerspectiveItem SavePerspectiveItem(PerspectiveItem perspectiveItem)
        {
            PerspectiveItem result = perspectiveItem;
            result.ClearFeedback();
            Perspective perspective = new PerspectiveItemMapper()
                .MapFromBusinessToService(perspectiveItem);
            try
            {
                if (PerspectiveExists(perspective.Id))
                {
                    ExplorerRepositoryAgentFactory
                        .CreatePerspectiveRepositoryAgent()
                        .Update(perspective);
                }
                else
                {
                    ExplorerRepositoryAgentFactory
                        .CreatePerspectiveRepositoryAgent()
                        .Insert(perspective);
                }
                result.Id = perspective.Id;
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }



        /// <summary>
        /// Gets the perspective items for enumeration.
        /// </summary>
        /// <param name="enumerationId">The enumeration id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public PerspectiveItem[] GetPerspectiveItemsForEnumeration(string enumerationId)
        {
            return new PerspectiveItemMapper()
                .MapFromServiceToBusiness(ExplorerRepositoryAgentFactory
                .CreatePerspectiveRepositoryAgent()
                .SelectByEnumerationId(enumerationId));
        }

        /// <summary>
        /// Gets the perspective items for parent perspective.
        /// </summary>
        /// <param name="parentId">The parent id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public PerspectiveItem[] GetPerspectiveItemsForParentPerspective(string parentId)
        {
            return new PerspectiveItemMapper()
                .MapFromServiceToBusiness(ExplorerRepositoryAgentFactory
                .CreatePerspectiveRepositoryAgent()
                .SelectByParentId(parentId));
        }



        /// <summary>
        /// Exists the perspective.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private static bool PerspectiveExists(string id)
        {
            //return (!ExplorerRepositoryAgentFactory
            //    .CreatePerspectiveRepositoryAgent()
            //    .SelectById(id).IsUnknown);
            return (ExplorerRepositoryAgentFactory.CreatePerspectiveRepositoryAgent().SelectById(id) != null);
        }


        /// <summary>
        /// Gets the perspective items for parent perspective and enumeration type id.
        /// </summary>
        /// <param name="parentId">The parent id.</param>
        /// <param name="enumerationTypeId">The type id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public PerspectiveItem[] GetPerspectiveItemsForParentPerspectiveAndEnumerationType(string parentId, string enumerationTypeId)
        {
            return new PerspectiveItemMapper()
                .MapFromServiceToBusiness(ExplorerRepositoryAgentFactory
                .CreatePerspectiveRepositoryAgent()
                .SelectByParentIdAndEnumerationTypeId(parentId, enumerationTypeId));
        }

        /// <summary>
        /// Gets the type of the perspective items for.
        /// </summary>
        /// <param name="typeId">The type id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public PerspectiveItem[] GetPerspectiveItemsForType(string typeId)
        {
            return new PerspectiveItemMapper()
                .MapFromServiceToBusiness(ExplorerRepositoryAgentFactory
                .CreatePerspectiveRepositoryAgent()
                .SelectByEnumerationTypeId(typeId));
        }

        /// <summary>
        /// Gets the enumeration items top.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public EnumerationItem[] GetEnumerationItemsTop()
        {
            if (EnumerationAgent != null)
            {
                var items = EnumerationAgent.SelectTop();
                var result = new List<EnumerationItem>();
                result.AddRange(items.Select(CreateEnumerationItem));
                return result.ToArray();
            }
            return null;
        }

        /// <summary>
        /// Gets the enumeration item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public EnumerationItem GetEnumerationItem(string id)
        {
            if (EnumerationAgent != null)
            {
                Enumeration item = EnumerationAgent.SelectById(id);
                var result = CreateEnumerationItem(item);
                return result;
            }
            return null;
        }

        /// <summary>
        /// Gets the type of the enumerations for.
        /// </summary>
        /// <param name="typeId">The type id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public EnumerationItem[] GetEnumerationItemsForType(string typeId)
        {
            if (EnumerationAgent != null)
            {
                Enumeration[] items = EnumerationAgent.SelectByTypeId(typeId);
                var result = new List<EnumerationItem>();
                result.AddRange(items.Select(CreateEnumerationItem));
                return result.ToArray();
            }
            return null;
        }

        /// <summary>
        /// Gets the enumeration items for parent perspective.
        /// </summary>
        /// <param name="parentId">The parent id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public EnumerationItem[] GetEnumerationItemsForParentPerspective(string parentId)
        {
            if (EnumerationAgent != null)
            {
                Enumeration[] items = EnumerationAgent.SelectByPerspectiveParentId(parentId);
                var result = new List<EnumerationItem>();
                result.AddRange(items.Select(CreateEnumerationItem));
                return result.ToArray();
            }
            return null;
        }

        /// <summary>
        /// Gets the enumeration items types for parent perspective.
        /// </summary>
        /// <param name="parentId">The parent id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public EnumerationItem[] GetEnumerationItemsTypesForParentPerspective(string parentId)
        {
            if (EnumerationAgent != null)
            {
                Enumeration[] items = EnumerationAgent.SelectTypesByParentPerspective(parentId);
                var result = new List<EnumerationItem>();
                result.AddRange(items.Select(CreateEnumerationItem));
                return result.ToArray();
            }
            return null;
        }

        /// <summary>
        /// Gets the enumeration items for search.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public EnumerationItem[] GetEnumerationItemsForSearch(string searchString)
        {
            if (EnumerationAgent != null)
            {
                Enumeration[] items = EnumerationAgent.SelectLikeTitle(searchString);
                var result = new List<EnumerationItem>();
                result.AddRange(items.Select(CreateEnumerationItem));
                return result.ToArray();
            }
            return null;
        }

        /// <summary>
        /// Gets the property item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public EnumerationPropertyItem GetEnumerationPropertyItem(string id)
        {
            if (EnumerationPropertyAgent != null)
            {
                EnumerationProperty item = EnumerationPropertyAgent.SelectById(id);
                var result = CreateEnumerationPropertyItem(item);
                return result;
            }
            return null;
        }

        /// <summary>
        /// Gets the properties for enumeration.
        /// </summary>
        /// <param name="enumerationId">The enumeration id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public EnumerationPropertyItem[] GetEnumerationPropertyItemsForEnumeration(string enumerationId)
        {
            if (EnumerationPropertyAgent != null)
            {
                var items = EnumerationPropertyAgent.SelectByEnumerationId(enumerationId);
                var result = new List<EnumerationPropertyItem>();
                result.AddRange(items.Select(CreateEnumerationPropertyItem));
                return result.ToArray();
            }
            return null;
        }

        /// <summary>
        /// Gets the enumeration link item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public EnumerationLinkItem GetEnumerationLinkItem(string id)
        {
            if (EnumerationLinkAgent != null)
            {
                var enumerationLink = EnumerationLinkAgent.SelectById(id);
                var result = CreateEnumerationLinkItem(enumerationLink);
                return result;
            }
            return null;
        }

        /// <summary>
        /// Gets the enumeration link items for target.
        /// </summary>
        /// <param name="targetId">The target id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public EnumerationLinkItem[] GetEnumerationLinkItemsForTarget(string targetId)
        {
            if (EnumerationLinkAgent != null)
            {
                var items = EnumerationLinkAgent.SelectByTargetId(targetId);
                var result = new List<EnumerationLinkItem>();
                result.AddRange(items.Select(CreateEnumerationLinkItem));
                return result.ToArray();
            }
            return null;
        }

        /// <summary>
        /// Gets the type of the enumeration link items for.
        /// </summary>
        /// <param name="typeId">The type id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public EnumerationLinkItem[] GetEnumerationLinkItemsForType(string typeId)
        {
            if (EnumerationLinkAgent != null)
            {
                var items = EnumerationLinkAgent.SelectByTypeId(typeId);
                var result = new List<EnumerationLinkItem>();
                result.AddRange(items.Select(CreateEnumerationLinkItem));
                return result.ToArray();
            }
            return null;
        }

        /// <summary>
        /// Gets the enumeration link items for source.
        /// </summary>
        /// <param name="sourceId">The source id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public EnumerationLinkItem[] GetEnumerationLinkItemsForSource(string sourceId)
        {
            if (EnumerationLinkAgent != null)
            {
                var items = EnumerationLinkAgent.SelectBySourceId(sourceId);
                var result = new List<EnumerationLinkItem>();
                result.AddRange(items.Select(CreateEnumerationLinkItem));
                return result.ToArray();
            }
            return null;
        }

        /// <summary>
        /// Saves the enumeration item.
        /// </summary>
        /// <param name="enumerationItem">The enumeration item.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public EnumerationItem SaveEnumerationItem(EnumerationItem enumerationItem)
        {
            var result = enumerationItem;

            if (EnumerationAgent != null)
            {
                result.ClearFeedback();
                _logger.InfoFormat("Mapping enumeration: {0}", enumerationItem.Id);
                Enumeration enumeration = CreateEnumeration(enumerationItem);

                try
                {
                    enumeration.DateModified = DateTime.Now;
                    if (EnumerationExists(enumeration.Id))
                    {
                        _logger.InfoFormat("Updating enumeration: {0}", enumeration.Id);
                        EnumerationAgent.Update(enumeration);
                    }
                    else
                    {
                        _logger.InfoFormat("Creating enumeration: {0}", enumeration.Id);
                        EnumerationAgent.Insert(enumeration);
                    }
                    result.Id = enumeration.Id;
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                    result.AddError(ex.Message);
                }
            }

            return result;
        }

        /// <summary>
        /// Exists the enumerations.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private bool EnumerationExists(string id)
        {
            if (EnumerationAgent != null)
            {
                _logger.InfoFormat("Checking if enumeration exists: {0}", id);
                if (String.IsNullOrEmpty(id)) return false;
                return EnumerationAgent.SelectById(id) != null;
            }
            return false;
        }

        /// <summary>
        /// Exists the property.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private bool EnumerationPropertyExists(string id)
        {
            if (EnumerationPropertyAgent != null)
            {
                if (string.IsNullOrEmpty(id)) return false;
                return EnumerationPropertyAgent.SelectById(id) != null;
            }
            return false;
        }

        /// <summary>
        /// Exists the link.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private bool EnumerationLinkExists(string id)
        {
            if (EnumerationLinkAgent != null)
            {
                if (string.IsNullOrEmpty(id)) return false;
                return EnumerationLinkAgent.SelectById(id) != null;
            }
            return false;
        }



        /// <summary>
        /// Saves the enumeration property item.
        /// </summary>
        /// <param name="enumerationPropertyItem">The enumeration property item.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public EnumerationPropertyItem SaveEnumerationPropertyItem(EnumerationPropertyItem enumerationPropertyItem)
        {
            var result = enumerationPropertyItem;
            result.ClearFeedback();
            var enumerationProperty = CreateEnumerationProperty(enumerationPropertyItem);
            try
            {
                if (EnumerationPropertyExists(enumerationProperty.Id))
                {
                    EnumerationPropertyAgent.Update(enumerationProperty);
                }
                else
                {
                    EnumerationPropertyAgent.Insert(enumerationProperty);
                }
                result.Id = enumerationProperty.Id;
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// Saves the enumeration link item.
        /// </summary>
        /// <param name="enumerationLinkItem">The enumeration link item.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public EnumerationLinkItem SaveEnumerationLinkItem(EnumerationLinkItem enumerationLinkItem)
        {
            EnumerationLinkItem result = enumerationLinkItem;

            if (EnumerationLinkAgent != null)
            {
                result.ClearFeedback();
                EnumerationLink enumerationLink = CreateEnumerationLink(enumerationLinkItem);

                try
                {
                    if (EnumerationLinkExists(enumerationLink.Id))
                    {
                        EnumerationLinkAgent.Update(enumerationLink);
                    }
                    else
                    {
                        EnumerationLinkAgent.Insert(enumerationLink);
                    }
                    result.Id = enumerationLink.Id;
                }
                catch (Exception ex)
                {
                    result.AddError(ex.Message);
                }
            }

            return result;
        }


        /// <summary>
        /// Deletes the enumeration item.
        /// </summary>
        /// <param name="id">The id of the enumeration item.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public EnumerationItem DeleteEnumerationItem(string id)
        {
            EnumerationItem result = GetEnumerationItem(id);

            if (EnumerationAgent != null && result != null)
            {
                try
                {
                    EnumerationAgent.Delete(id);
                }
                catch (Exception ex)
                {
                    result.AddError(ex.Message);
                }
            }

            return result;
        }

        /// <summary>
        /// Deletes the enumeration property item.
        /// </summary>
        /// <param name="id">The id of the enumeration property item.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public EnumerationPropertyItem DeleteEnumerationPropertyItem(string id)
        {
            EnumerationPropertyItem result = GetEnumerationPropertyItem(id);
            if (EnumerationPropertyAgent != null && result != null)
            {
                try
                {
                    EnumerationPropertyAgent.Delete(id);
                }
                catch (Exception ex)
                {
                    result.AddError(ex.Message);
                }
            }
            return result;
        }

        /// <summary>
        /// Deletes the enumeration link item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public EnumerationLinkItem DeleteEnumerationLinkItem(string id)
        {
            EnumerationLinkItem result = GetEnumerationLinkItem(id);

            if (EnumerationLinkAgent != null && result != null)
            {
                try
                {
                    EnumerationLinkAgent.Delete(id);
                }
                catch (Exception ex)
                {
                    result.AddError(ex.Message);
                }
            }
            return result;
        }


        /// <summary>
        /// Gets the properties for a specific type.
        /// </summary>
        /// <param name="typeId">The type id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public EnumerationPropertyItem[] GetEnumerationPropertyItemsForType(string typeId)
        {
            if (EnumerationPropertyAgent != null)
            {
                EnumerationProperty[] items = EnumerationPropertyAgent.SelectByTypeId(typeId);
                var result = new List<EnumerationPropertyItem>();
                result.AddRange(items.Select(CreateEnumerationPropertyItem));
                return result.ToArray();
            }
            return null;
        }


        /// <summary>
        /// Creates an enumeration item from an enumeration.
        /// </summary>
        /// <param name="enumeration">The enumeration.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private EnumerationItem CreateEnumerationItem(Enumeration enumeration)
        {
            if (enumeration == null) return null;
            return new EnumerationItem
                       {
                           Id = enumeration.Id,
                           SortOrder = enumeration.SortOrder,
                           Title = enumeration.Title,
                           TypeId = enumeration.TypeId,
                           Image = enumeration.Image ?? new byte[] { },
                           DateModified = enumeration.DateModified,
                           AdditionalInfoUri = String.Empty
                       };
        }

        /// <summary>
        /// Creates the enumeration property item from an enumerationProperty.
        /// </summary>
        /// <param name="enumerationProperty">The enumeration property.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private EnumerationPropertyItem CreateEnumerationPropertyItem(EnumerationProperty enumerationProperty)
        {
            if (enumerationProperty == null) return null;
            return new EnumerationPropertyItem
                       {
                           Id = enumerationProperty.Id,
                           EnumerationId = enumerationProperty.EnumerationId,
                           Title = enumerationProperty.Property,
                           TypeId = enumerationProperty.TypeId,
                           Value = enumerationProperty.Value
                       };
        }

        /// <summary>
        /// Creates the enumeration link item.
        /// </summary>
        /// <param name="enumerationLink">The enumeration link.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private EnumerationLinkItem CreateEnumerationLinkItem(EnumerationLink enumerationLink)
        {
            if (enumerationLink == null) return null;
            return new EnumerationLinkItem
                       {
                           Id = String.IsNullOrEmpty(enumerationLink.Id) ? Guid.NewGuid().ToString() : enumerationLink.Id,
                           SourceId = enumerationLink.SourceId,
                           TargetId = enumerationLink.TargetId,
                           TypeId = enumerationLink.TypeId
                       };
        }

        /// <summary>
        /// Creates the enumeration.
        /// </summary>
        /// <param name="enumerationItem">The enumeration item.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private Enumeration CreateEnumeration(EnumerationItem enumerationItem)
        {
            return new Enumeration
                        {
                            Id = String.IsNullOrEmpty(enumerationItem.Id) ? Guid.NewGuid().ToString() : enumerationItem.Id,
                            SortOrder = enumerationItem.SortOrder,
                            Title = enumerationItem.Title,
                            TypeId = enumerationItem.TypeId,
                            Image = enumerationItem.Image,
                            DateModified = enumerationItem.DateModified
                        };
        }



        /// <summary>
        /// Creates the enumerationWithPropertyValueItem.
        /// </summary>
        /// <param name="enumerationWithPropertyValue">The enumerationWithPropertyValue.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private EnumerationWithPropertyValueItem CreateEnumerationWithPropertyValue(EnumerationWithPropertyValue enumerationWithPropertyValue)
        {
            return new EnumerationWithPropertyValueItem()
            {
                Id = String.IsNullOrEmpty(enumerationWithPropertyValue.Id) ? Guid.NewGuid().ToString() : enumerationWithPropertyValue.Id,
                SortOrder = enumerationWithPropertyValue.SortOrder,
                Title = enumerationWithPropertyValue.Title,
                TypeId = enumerationWithPropertyValue.TypeId,
                Image = enumerationWithPropertyValue.Image,
                DateModified = enumerationWithPropertyValue.DateModified,
                PropertyValue = enumerationWithPropertyValue.PropertyValue
            };
        }

        /// <summary>
        /// Creates the enumeration property.
        /// </summary>
        /// <param name="enumerationPropertyItem">The enumeration property item.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private EnumerationProperty CreateEnumerationProperty(EnumerationPropertyItem enumerationPropertyItem)
        {
            return new EnumerationProperty
                       {
                           Id = String.IsNullOrEmpty(enumerationPropertyItem.Id) ? Guid.NewGuid().ToString() : enumerationPropertyItem.Id,
                           EnumerationId = enumerationPropertyItem.EnumerationId,
                           Property = enumerationPropertyItem.Title,
                           Value = enumerationPropertyItem.Value,
                           TypeId = enumerationPropertyItem.TypeId
                       };
        }

        /// <summary>
        /// Creates the enumeration link.
        /// </summary>
        /// <param name="enumerationLinkItem">The enumeration link item.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private EnumerationLink CreateEnumerationLink(EnumerationLinkItem enumerationLinkItem)
        {
            return new EnumerationLink
                       {
                           Id = String.IsNullOrEmpty(enumerationLinkItem.Id) ? Guid.NewGuid().ToString() : enumerationLinkItem.Id,
                           SourceId = enumerationLinkItem.SourceId,
                           TargetId = enumerationLinkItem.TargetId,
                           TypeId = enumerationLinkItem.TypeId
                       };
        }

        /// <summary>
        /// Creates the perspective.
        /// </summary>
        /// <param name="perspectiveItem">The perspective item.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private Perspective CreatePerspective(PerspectiveItem perspectiveItem)
        {
            return new Perspective
                       {
                           Id = String.IsNullOrEmpty(perspectiveItem.Id) ? Guid.NewGuid().ToString() : perspectiveItem.Id,
                           ParentId = perspectiveItem.ParentId,
                           EnumerationId = perspectiveItem.EnumerationId
                       };
        }

        /// <summary>
        /// Gets the enumeration items for reason and advice titles.
        /// </summary>
        /// <param name="categoryId">The category id.</param>
        /// <param name="problemId">The problem id.</param>
        /// <param name="subjectId">The subject id.</param>
        /// <param name="adviceCode">The advice code.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public EnumerationItem[] GetEnumerationItemsForReasonAndAdviceTitles(string categoryId, string problemId, string subjectId, string adviceCode)
        {
            if (EnumerationAgent != null)
            {
                Enumeration[] items = EnumerationAgent.SelectReasonAndAdviceTitles(categoryId, problemId, subjectId, adviceCode);
                var result = new List<EnumerationItem>();
                result.AddRange(items.Select(CreateEnumerationItem));
                return result.ToArray();
            }
            return null;
        }

        /// <summary>
        /// Gets the type of the enumeration items like.
        /// </summary>
        /// <param name="typeId">The type id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public EnumerationItem[] GetEnumerationItemsLikeType(string typeId)
        {
            if (EnumerationAgent != null)
            {
                Enumeration[] items = EnumerationAgent.SelectLikeTypeId(typeId);
                var result = new List<EnumerationItem>();
                result.AddRange(items.Select(CreateEnumerationItem));
                return result.ToArray();
            }
            return null;
        }

        /// <summary>
        /// Gets the enumeration with property value items for type and enumeration property value.
        /// </summary>
        /// <param name="typeId">The type id.</param>
        /// <param name="property">The property.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public EnumerationWithPropertyValueItem[] GetEnumerationWithPropertyValueItemsForTypeAndEnumerationPropertyValue(string typeId, string property)
        {
            if (EnumerationWithPropertyValueAgent != null)
            {
                var items = EnumerationWithPropertyValueAgent.SelectByTypeIdAndPropertyValue(typeId, property);
                var result = new List<EnumerationWithPropertyValueItem>();
                result.AddRange(items.Select(CreateEnumerationWithPropertyValue));
                return result.ToArray();
            }
            return null;
        }

        /// <summary>
        /// Gets the enumeration with property value items for type and parent enumeration property.
        /// </summary>
        /// <param name="typeId">The type id.</param>
        /// <param name="property">The property.</param>
        /// <param name="propertyValue">The property value.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public EnumerationWithPropertyValueItem[] GetEnumerationWithPropertyValueItemsForTypeAndParentEnumerationProperty(string typeId, string property, string propertyValue)
        {
            if (EnumerationWithPropertyValueAgent != null)
            {
                EnumerationWithPropertyValue[] items = EnumerationWithPropertyValueAgent.SelectByTypeIdAndParentProperty(typeId, property, propertyValue);
                var result = new List<EnumerationWithPropertyValueItem>();
                result.AddRange(items.Select(CreateEnumerationWithPropertyValue));
                return result.ToArray();
            }
            return null;
        }

        /// <summary>
        /// Gets the type of the enumeration property items like.
        /// </summary>
        /// <param name="typeId">The type id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public EnumerationPropertyItem[] GetEnumerationPropertyItemsLikeType(string typeId)
        {
            if (EnumerationPropertyAgent != null)
            {
                EnumerationProperty[] items = EnumerationPropertyAgent.SelectLikeTypeId(typeId);
                var result = new List<EnumerationPropertyItem>();
                result.AddRange(items.Select(CreateEnumerationPropertyItem));
                return result.ToArray();
            }
            return null;
        }

        /// <summary>
        /// Gets the enumeration property item for enumeration and enumeration property title.
        /// </summary>
        /// <param name="enumerationId">The enumeration id.</param>
        /// <param name="property">The property.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public EnumerationPropertyItem GetEnumerationPropertyItemForEnumerationAndEnumerationPropertyTitle(string enumerationId, string property)
        {
            if (EnumerationPropertyAgent != null)
            {
                EnumerationProperty item = EnumerationPropertyAgent.SelectFirstByEnumerationIdAndProperty(
                    enumerationId, property);
                return CreateEnumerationPropertyItem(item);
            }
            return null;
        }
    }
}
