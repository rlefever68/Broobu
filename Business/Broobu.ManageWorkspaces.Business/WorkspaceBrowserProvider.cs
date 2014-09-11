using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Transactions;
using log4net;
using Pms.Explorer.Contract.Agent;
using Pms.Explorer.Contract.Domain;
using Pms.Explorer.Contract.Interfaces;
using Pms.Media.Contract.Agent;
using Pms.Media.Contract.Interfaces;
using Pms.ManageWorkspaces.Business.Interfaces;
using Pms.ManageWorkspaces.Contract.Domain;
using Pms.ManageWorkspaces.Contract.Constants;
using EnumBaseType = Pms.Explorer.Contract.Domain.ExplorerDomainGenerator.EnumBaseType;
using Pms.Framework.Domain;

namespace Pms.ManageWorkspaces.Business
{
    /// <summary>
    /// 
    /// </summary>
    /// Hierarchy_SelectByParentTypeIdPart => not found Tim ?
    /// HierarchyItem_SelectAllByParentId => found 
    /// HierarchyItem_SelectAllByTypeId => found
    /// HierarchyItem_SelectBySearchString => found
    /// HierarchyItem_SelectByTypeCultureAndParentProperty => zeker Tim
    /// HierarchyItem_SelectByTypeId => not found => not found => laten bestaan
    /// HierarchyItem_SelectByTypeIdAndCultureId => not found => laten bestaan
    /// HierarchyItem_SelectByTypeIdPart => not found => zeker Tim
    /// HierarchyItem_SelectByTypeIdAndCultureIdWithPropertyValue => zeker Tim
    /// HierarchyItem_SelectTopParentByParentId => found
    /// HierarchyItem_SelectTree => found
    /// HierarchyItem_SelectTreeByParentId => not found mag weg
    /// HierarchyItemProperty_SelectByItemId => not found laten bestaan
    /// HierarchyItemProperty_SelectByTypeIdPart => not found zeker Tim
    /// HierarchyItemProperty_SelectFirstByItemIdAndProperty => not found zeker Tim

    class WorkspaceBrowserProvider : IWorkspaceBrowserProvider
    {
        private const string DebugWriteLinePrefix = "Pms.ManageWorkspaces.Business.WorkspaceBrowserProvider : ";
        private readonly ILog _logger;

        [Flags]
        private enum Method
        {
            None = 0,               // 0000
            GetProperties = 1,      // 0001
            GetDescriptions = 2,    // 0010
            GetChildren = 4         // 0100
        }

        public WorkspaceBrowserProvider()
        {
            _logger = LogManager.GetLogger(GetType());
        }

        /// <summary>
        /// Initializes this instance. Must be called once during the lifetime of the application.
        /// The method checks different tables and inserts records if needed.
        /// Some of the methods in this class depends up the existing of these records to work 
        /// correctly.
        /// </summary>
        /// <returns></returns>
        public bool Initialize()
        {
            LogInfo("Initialize...");
            return WorkspaceBrowserBusinessGenerator.Generate();
        }

        /// <summary>
        /// Gets the workspace.
        /// </summary>
        /// <param name="workspaceId">The workspace id.</param>
        /// <returns></returns>
        public WorkspaceItem[] GetWorkspace(string workspaceId)
        {
            return GetWorkspaceItems(workspaceId, Method.GetChildren | Method.GetDescriptions | Method.GetProperties);
        }

        /// <summary>
        /// Gets the workspace items.
        /// </summary>
        /// <param name="workspaceId">The workspace id.</param>
        /// <param name="methodsToExecute"></param>
        /// <returns></returns>
        private WorkspaceItem[] GetWorkspaceItems(string workspaceId, Method methodsToExecute = Method.GetDescriptions | Method.GetProperties)
        {
            // []
            IExplorerAgent agentExplorer = ExplorerAgentFactory.CreateAgent(ExplorerAgentFactory.Key.Instance);
            if (agentExplorer != null)
            {
                PerspectiveItem[] perspectiveItems = agentExplorer.GetPerspectiveItemsForParentPerspective(workspaceId);
                EnumerationItem[] enumerationItems = agentExplorer.GetEnumerationItemsForParentPerspective(workspaceId);
                EnumerationItem[] enumerationTypes = agentExplorer.GetEnumerationItemsTypesForParentPerspective(workspaceId);
                return CreateWorkspaceItems(perspectiveItems, enumerationItems, enumerationTypes, methodsToExecute);
            }
            return new WorkspaceItem[] { };

            //var temp1 = result.ToArray();

            //IPerspectiveItemRepositoryAgent agent = MobiGuiderRepositoryAgentFactory.CreatePerspectiveItemRepositoryAgent();
            //MobiGuider.Repository.Contract.Domain.PerspectiveItem[] items = agent.SelectByParentId(workspaceId);
            ////var result = new List<WorkspaceItem>(items.Length);
            //result.AddRange(items.Select(item => CreateWorkspaceItem(item, methodsToExecute)));
            //var temp2 = result.ToArray();

            //return result.ToArray();
        }

        private WorkspaceItem[] CreateWorkspaceItems(PerspectiveItem[] perspectiveItems, EnumerationItem[] enumerationItems, EnumerationItem[] enumerationItemsTypes, Method methodsToExecute = Method.GetDescriptions | Method.GetProperties)
        {
            var workspaceItems = new List<WorkspaceItem>();
            foreach (PerspectiveItem perspectiveItem in perspectiveItems)
            {
                string id = perspectiveItem.EnumerationId;
                string typeId = perspectiveItem.EnumerationId;
                EnumerationItem enumerationItem = (from i in enumerationItems
                                                   where i.Id == id
                                                   select i).FirstOrDefault();
                EnumerationItem enumerationItemType = (from i in enumerationItemsTypes
                                                       where i.Id == typeId
                                                       select i).FirstOrDefault();

                workspaceItems.Add(CreateWorkspaceItem(perspectiveItem, enumerationItem, enumerationItemType, null, methodsToExecute));
            }
            return workspaceItems.ToArray();
        }

        private WorkspaceItem CreateWorkspaceItem(PerspectiveItem perspectiveItem, EnumerationItem enumerationItem, EnumerationItem enumerationItemType, EnumerationItem enumerationItemParent, Method methodsToExecute = Method.GetDescriptions | Method.GetProperties)
        {
            WorkspaceItem result =  new WorkspaceItem
                                        {
                                            Id = perspectiveItem == null ? String.Empty : perspectiveItem.Id,
                                            ParentId = perspectiveItem == null ? String.Empty : perspectiveItem.ParentId,
                                            ParentTitle = enumerationItemParent == null ? String.Empty : enumerationItemParent.Title,
                                            ItemId = perspectiveItem == null ? String.Empty : perspectiveItem.EnumerationId,
                                            ItemTitle = enumerationItem.Title,
                                            TypeId = enumerationItem.TypeId,
                                            TypeTitle = enumerationItemType == null ? String.Empty : enumerationItemType.Title,
                                            ItemImage = enumerationItem.Image ?? new byte[] { },
                                            TypeImage = enumerationItemType == null ? new byte[] { } : enumerationItemType.Image,
                                            SortOrder = enumerationItem.SortOrder,
                                            Descriptions = new WorkspaceItemDescription[] { },
                                            DateModified = enumerationItem.DateModified,
                                            Properties = new WorkspaceItemProperty[] { },
                                            Children = new WorkspaceItem[] { },
                                            AdditionalInfoUri = String.Empty,
                                            IsFolder = GetIsFolder(enumerationItem)
                                        };
            if (methodsToExecute.HasFlag(Method.GetChildren)) result.Children = GetWorkspaceItems(result.Id, Method.None).ToArray();
            if (methodsToExecute.HasFlag(Method.GetDescriptions)) result.Descriptions = GetDescriptions(result.ItemId).ToArray();
            if (methodsToExecute.HasFlag(Method.GetProperties)) result.Properties = GetProperties(result.ItemId).ToArray();
            return result;
        }


        ///// <summary>
        ///// Creates a workspace item from a hierarchy3 item.
        ///// </summary>
        ///// <param name="perspectiveItem">A hierarchy3 item.</param>
        ///// <param name="methodsToExecute">The methods to execute.</param>
        ///// <returns></returns>
        //private WorkspaceItem CreateWorkspaceItemFromHierarchyItem(HierarchyItem3 perspectiveItem, Method methodsToExecute = Method.GetProperties | Method.GetDescriptions)
        //{
        //    var result = new WorkspaceItem
        //    {
        //        Id = perspectiveItem == null ? String.Empty : perspectiveItem.HierarchyId,
        //        ParentId = perspectiveItem == null ? String.Empty : perspectiveItem.HierarchyParentId,
        //        ItemId = perspectiveItem == null ? String.Empty : perspectiveItem.ItemId,
        //        ItemTitle = perspectiveItem == null ? String.Empty : perspectiveItem.ItemTitle,
        //        ItemImage = perspectiveItem == null ? new byte[] { } : perspectiveItem.ItemImage,
        //        TypeId = perspectiveItem == null ? String.Empty : perspectiveItem.TypeId,
        //        TypeTitle = perspectiveItem == null ? String.Empty : perspectiveItem.TypeTitle,
        //        TypeImage = perspectiveItem == null ? new byte[] { } : perspectiveItem.TypeImage,
        //        SortOrder = perspectiveItem == null ? 0 : perspectiveItem.ItemSortOrder,
        //        Descriptions = new WorkspaceItemDescription[] { },
        //        Properties = new WorkspaceItemProperty[] { },
        //        Children = new WorkspaceItem[] { },
        //        AdditionalInfoUri = String.Empty,
        //        IsFolder = GetIsFolder(perspectiveItem)
        //    };
        //    return result;
        //}

        /// <summary>
        /// Creates a workspace item from a PerspectiveItem.
        /// </summary>
        /// <param name="perspectiveItem">A perspective item.</param>
        /// <param name="methodsToExecute">The methods to execute to fill properties on the object.</param>
        /// <returns></returns>
        private WorkspaceItem CreateWorkspaceItem(PerspectiveItem perspectiveItem, Method methodsToExecute = Method.GetProperties | Method.GetDescriptions)
        {
            IExplorerAgent agentExplorer = ExplorerAgentFactory.CreateAgent(ExplorerAgentFactory.Key.Instance);
            EnumerationItem enumerationItem = agentExplorer.GetEnumerationItem(perspectiveItem.EnumerationId);

            var result = new WorkspaceItem
                             {
                                 Id = perspectiveItem.Id,
                                 ParentId = perspectiveItem.ParentId,
                                 ParentTitle = String.Empty,
                                 ItemId = perspectiveItem.EnumerationId,
                                 ItemTitle = enumerationItem == null ? String.Empty : enumerationItem.Title,
                                 ItemImage = enumerationItem == null ? new byte[] { } : enumerationItem.Image,
                                 TypeId = enumerationItem == null ? String.Empty : enumerationItem.TypeId,
                                 TypeTitle = String.Empty,
                                 TypeImage = new byte[] { },
                                 SortOrder = enumerationItem == null ? 0 : enumerationItem.SortOrder,
                                 Descriptions = new WorkspaceItemDescription[] { },
                                 DateModified = enumerationItem == null ? DateTime.Now : enumerationItem.DateModified,
                                 Properties = new WorkspaceItemProperty[] { },
                                 Children = new WorkspaceItem[] { },
                                 AdditionalInfoUri = perspectiveItem.AdditionalInfoUri,
                                 IsFolder = GetIsFolder(enumerationItem)
                             };
            if (methodsToExecute.HasFlag(Method.GetChildren)) result.Children = GetWorkspaceItems(result.Id, Method.None).ToArray();
            if (methodsToExecute.HasFlag(Method.GetDescriptions)) result.Descriptions = GetDescriptions(result.ItemId).ToArray();
            if (methodsToExecute.HasFlag(Method.GetProperties)) result.Properties = GetProperties(result.ItemId).ToArray();
            return result;
        }

        private WorkspaceItem CreateWorkspaceItem(EnumerationItem enumerationItem, Method methodsToExecute = Method.GetProperties | Method.GetDescriptions)
        {
            IExplorerAgent agentExplorer = ExplorerAgentFactory.CreateAgent(ExplorerAgentFactory.Key.Instance);
            PerspectiveItem perspectiveItem = agentExplorer.GetPerspectiveItem(enumerationItem.Id);

            var result = new WorkspaceItem
            {
                Id = perspectiveItem == null ? String.Empty : perspectiveItem.Id,
                ParentId = perspectiveItem == null ? String.Empty : perspectiveItem.ParentId,
                ParentTitle = String.Empty,
                ItemId = enumerationItem.Id,
                ItemTitle = enumerationItem.Title,
                ItemImage = enumerationItem.Image ?? new byte[] { },
                TypeId = enumerationItem.TypeId,
                TypeTitle = enumerationItem.Title,
                TypeImage = enumerationItem.Image,
                SortOrder = enumerationItem.SortOrder,
                Descriptions = new WorkspaceItemDescription[] { },
                DateModified = enumerationItem.DateModified,
                Properties = new WorkspaceItemProperty[] { },
                Children = new WorkspaceItem[] { },
                AdditionalInfoUri = enumerationItem.AdditionalInfoUri,
                IsFolder = GetIsFolder(enumerationItem)
            };
            if (methodsToExecute.HasFlag(Method.GetChildren)) result.Children = GetWorkspaceItems(result.Id, Method.None).ToArray();
            if (methodsToExecute.HasFlag(Method.GetDescriptions)) result.Descriptions = GetDescriptions(result.ItemId).ToArray();
            if (methodsToExecute.HasFlag(Method.GetProperties)) result.Properties = GetProperties(result.ItemId).ToArray();
            return result;
        }

        /// <summary>
        /// Creates a workspace item from a store item.
        /// </summary>
        /// <returns></returns>
        //private WorkspaceItem CreateWorkspaceItem(StoreItem storeItem, Method methodsToExecute = Method.GetProperties | Method.GetDescriptions)
        //{
        //    var result = new WorkspaceItem
        //    {
        //        Id = String.Empty,
        //        ParentId = String.Empty,
        //        ParentTitle = String.Empty,
        //        ItemId = storeItem == null ? String.Empty : storeItem.Id,
        //        ItemTitle = storeItem == null ? String.Empty : storeItem.Title,
        //        ItemImage = storeItem == null ? new byte[] { } : storeItem.Image,
        //        TypeId = storeItem == null ? String.Empty : storeItem.TypeId,
        //        TypeTitle = String.Empty,
        //        TypeImage = new byte[] { },
        //        SortOrder = 0,
        //        Descriptions = new WorkspaceItemDescription[] { },
        //        Properties = new WorkspaceItemProperty[] { },
        //        Children = new WorkspaceItem[] { },
        //        AdditionalInfoUri = String.Empty,
        //        IsFolder = GetIsFolder(storeItem),
        //        DateModified = (DateTime)(storeItem == null || storeItem.DateModified == null ? DateTime.Now : storeItem.DateModified)
        //    };
        //    if (methodsToExecute.HasFlag(Method.GetChildren)) result.Children = GetWorkspaceItems(result.Id).ToArray();
        //    if (methodsToExecute.HasFlag(Method.GetDescriptions)) result.Descriptions = GetDescriptions(result.ItemId).ToArray();
        //    if (methodsToExecute.HasFlag(Method.GetProperties)) result.Properties = GetProperties(result.ItemId).ToArray();
        //    return result;
        //}

        /// <summary>
        /// Gets the perspective item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>MobiGuider.Repository.Contract.Domain.
        private PerspectiveItem GetPerspectiveItem(string id)
        {
            IExplorerAgent agent = ExplorerAgentFactory.CreateAgent(ExplorerAgentFactory.Key.Instance);
            if (agent != null) return agent.GetPerspectiveItem(id);
            return null;
        }

        /*
                /// <summary>
                /// Gets the perspective item.
                /// </summary>
                /// <param name="workspaceItem">The workspace item.</param>
                /// <returns></returns>
                private PerspectiveItem GetHierarchyItem(WorkspaceItem workspaceItem)
                {
                    return MobiGuiderRepositoryAgentFactory.CreateHierarchyItemRepositoryAgent().SelectById(workspaceItem.ItemId);
                }
        */

        /*
                /// <summary>
                /// Gets the perspective item.
                /// </summary>
                /// <param name="workspaceItem">The workspace item.</param>
                /// <param name="agent">The agent.</param>
                /// <returns></returns>
                private PerspectiveItem GetHierarchyItem(WorkspaceItem workspaceItem, IHierarchyItemRepositoryAgent agent)
                {
                    if (workspaceItem == null) throw new ArgumentNullException("workspaceItem");
                    if (agent == null) throw new ArgumentNullException("agent");
                    return agent.SelectById(workspaceItem.ItemId);
                }
        */

        /*
                /// <summary>
                /// Creates the perspective item.
                /// </summary>
                /// <param name="itemId">The id.</param>
                /// <param name="image">The image.</param>
                /// <param name="sortOrder">The sort order.</param>
                /// <param name="title">The title.</param>
                /// <param name="typeId">The type id.</param>
                /// <param name="isFolder"></param>
                /// <returns></returns>
                private PerspectiveItem CreateHierarchyItem(string itemId = null, byte[] image = null, int sortOrder = 0, string title = null, string typeId = null, bool isFolder = false)
                {
                    return new PerspectiveItem
                    {
                        Id = string.IsNullOrEmpty(itemId) ? Guid.NewGuid().ToString() : itemId,
                        Image = image,
                        SortOrder = sortOrder,
                        Title = title ?? String.Empty,
                        TypeId = isFolder ? WorkspaceBaseTypeUiTreeViewFolder.Id : typeId ?? String.Empty
                    };
                }
        */

        /*
                /// <summary>
                /// Creates the perspective item.
                /// </summary>
                /// <param name="workspaceItem">The workspace item.</param>
                /// <returns></returns>
                private PerspectiveItem CreateHierarchyItem(WorkspaceItem workspaceItem)
                {
                    return new PerspectiveItem()
                    {
                        Id = string.IsNullOrEmpty(workspaceItem.ItemId) ? Guid.NewGuid().ToString() : workspaceItem.ItemId,
                        Title = workspaceItem.ItemTitle ?? String.Empty,
                        TypeId = workspaceItem.IsFolder ? WorkspaceBaseTypeUiTreeViewFolder.Id : workspaceItem.TypeId,
                        SortOrder = workspaceItem.SortOrder,
                        Image = workspaceItem.ItemImage
                    };
                }
        */

        /*
                /// <summary>
                /// Gets the perspective.
                /// </summary>
                /// <param name="id">The id.</param>
                /// <returns></returns>
                private Perspective GetHierarchy(string id)
                {
                    return MobiGuiderRepositoryAgentFactory.CreateHierarchyRepositoryAgent().SelectById(id);
                }
        */

        /*
                /// <summary>
                /// Gets the perspective.
                /// </summary>
                /// <param name="workspaceItem">The workspace item.</param>
                /// <returns></returns>
                private Perspective GetHierarchy(WorkspaceItem workspaceItem)
                {
                    return MobiGuiderRepositoryAgentFactory.CreateHierarchyRepositoryAgent().SelectById(workspaceItem.Id);
                }
        */

        /*
                /// <summary>
                /// Gets the perspective.
                /// </summary>
                /// <param name="workspaceItem">The workspace item.</param>
                /// <param name="agent">The agent.</param>
                /// <returns></returns>
                private Perspective GetHierarchy(WorkspaceItem workspaceItem, IHierarchyRepositoryAgent agent)
                {
                    if (workspaceItem == null) throw new ArgumentNullException("workspaceItem");
                    if (agent == null) throw new ArgumentNullException("agent");
                    return agent.SelectById(workspaceItem.Id);
                }
        */

        /*
                /// <summary>
                /// Creates the perspective.
                /// </summary>
                /// <returns></returns>
                private Perspective CreateHierarchy(string id = null, string parentId = null, string itemId = null)
                {
                    return new Perspective
                    {
                        Id = string.IsNullOrEmpty(id) ? Guid.NewGuid().ToString() : id,
                        ParentId = parentId ?? String.Empty,
                        ItemId = itemId ?? String.Empty
                    };
                }
        */

        /*
                /// <summary>
                /// Creates the perspective.
                /// </summary>
                /// <param name="wItem">A workspace item.</param>
                /// <returns></returns>
                private Perspective CreateHierarchy(WorkspaceItem wItem)
                {
                    return new Perspective
                    {
                        Id = string.IsNullOrEmpty(wItem.Id) ? Guid.NewGuid().ToString() : wItem.Id,
                        ParentId = wItem.ParentId ?? String.Empty,
                        ItemId = wItem.ItemId ?? String.Empty
                    };
                }
        */

        // <summary>
        // Clears the table hierachy item.
        // </summary>
        // <param name="agentI">The agent I.</param>
        // <param name="sourceItems">The source items.</param>
        // <param name="parentItem">The parent item.</param>
        // <param name="i">The i.</param>
        // <param name="length">The length.</param>
        // <returns></returns>
        //public bool ClearTableHierachyItem(ref IHierarchyItemRepositoryAgent agentI, ref PerspectiveItem[] sourceItems, PerspectiveItem parentItem, int i, int length)
        //{
        //    PerspectiveItem[] childItems;
        //    string id = parentItem.Id;

        //    try
        //    {
        //        if (parentItem.Id == null && parentItem.TypeId == null)
        //        {
        //            childItems = (from item in sourceItems
        //                          where item.TypeId == item.Id
        //                          select item).ToArray();
        //        }
        //        else
        //        {
        //            childItems = (from item in sourceItems
        //                          where item.TypeId == id && item.TypeId != item.Id
        //                          select item).ToArray();
        //        }
        //        if (childItems.Length > 0)
        //        {
        //            foreach (var childItem in childItems)
        //            {
        //                if ((childItem.Id != childItem.TypeId) || (parentItem.Id == null && parentItem.TypeId == null))
        //                {
        //                    bool result = ClearTableHierachyItem(ref agentI, ref sourceItems, childItem, i, length);
        //                    if (!result) return false;
        //                    agentI.Delete(childItem.Id);
        //                }
        //            }
        //            return true;
        //        }

        //        PerspectiveItem itemToDelete = (from item in sourceItems
        //                                      where item.Id == parentItem.Id
        //                                      select item).FirstOrDefault();
        //        if (itemToDelete != null) agentI.Delete(itemToDelete.Id);

        //        return true;
        //    }

        //}

        /// <summary>
        /// Registers the description.
        /// </summary>
        /// <param name="workspaceItemDescription">The workspace item description.</param>
        /// <returns></returns>
        public string RegisterDescription(WorkspaceItemDescription workspaceItemDescription)
        {
            IMediaAgent agent = MediaAgentFactory.CreateMediaAgent();

            if (agent != null)
            {
                DescriptionItem item =  agent.SaveDescription(CreateDescriptionItem(workspaceItemDescription));
                return item.Id;
            }
            return String.Empty;
        }

        public string RegisterDescription(WorkspaceItemDescription workspaceItemDescription, IMediaAgent agent)
        {
            if (agent == null) throw new ArgumentNullException();
            DescriptionItem item = agent.SaveDescription(CreateDescriptionItem(workspaceItemDescription));
            return item.Id;
        }

        private DescriptionItem CreateDescriptionItem(WorkspaceItemDescription workspaceItemDescription)
        {
            return new DescriptionItem
                       {
                           Id = workspaceItemDescription.Id,
                           CultureId = workspaceItemDescription.CultureId,
                           ObjectId = workspaceItemDescription.ItemId,
                           TypeId = workspaceItemDescription.TypeId,
                           Title = workspaceItemDescription.Title,
                           Blob = workspaceItemDescription.Image,
                           Url = String.Empty,
                           AdditionalInfoUri = workspaceItemDescription.AdditionalInfoUri
                       };
        }

        private IEnumerable<DescriptionItem> RegisterWorkspaceDescriptions(WorkspaceItem workspaceItem)
        {
            var descriptions = new List<DescriptionItem>();
            if (workspaceItem.Descriptions != null)
            {
                IMediaAgent agent = MediaAgentFactory.CreateMediaAgent();
                if (agent != null)
                {
                    descriptions.AddRange(workspaceItem.Descriptions.Select(workspaceItemDescription => agent.SaveDescription(CreateDescriptionItem(workspaceItemDescription))));
                }
            }
            return descriptions;
        }

        #region " Exists methods "

        #region " Business exists methods "

        #region " PerspectiveExists "

        /// <summary>
        /// Checks if the perspective exists.
        /// </summary>
        /// <param name="perspective">The perspective.</param>
        /// <param name="agent">The agent.</param>
        /// <returns></returns>
        private bool PerspectiveExists(PerspectiveItem perspective, IExplorerAgent agent)
        {
            if (perspective == null) throw new ArgumentNullException("perspective");
            if (agent == null) throw new ArgumentNullException("agent");
            if (String.IsNullOrEmpty(perspective.Id)) return false;
            return agent.GetPerspectiveItem(perspective.Id) != null;
        }

        /*
                /// <summary>
                /// Checks if the Perspective exists.
                /// </summary>
                /// <param name="perspective">The perspective.</param>
                /// <returns></returns>
                private bool PerspectiveExists(Perspective perspective)
                {
                    if (perspective == null) throw new ArgumentNullException("perspective");
                    if (String.IsNullOrEmpty(perspective.Id)) return false;
                    IPerspectiveRepositoryAgent agent = MobiGuiderRepositoryAgentFactory.CreatePerspectiveRepositoryAgent();
                    return PerspectiveExists(perspective, agent);
                }
        */
        #endregion // PerspectiveExists

        #region " StoreItemExists "
        /// <summary>
        /// Checks if the item exists.
        /// </summary>
        /// <param name="enumerationItem">The perspective item.</param>
        /// <param name="agent">The agent.</param>
        /// <returns></returns>
        private bool EnumerationItemExists(EnumerationItem enumerationItem, IExplorerAgent agent)
        {
            if (enumerationItem == null) throw new ArgumentNullException("enumerationItem");
            if (agent == null) throw new ArgumentNullException("agent");
            if (String.IsNullOrEmpty(enumerationItem.Id)) return false;
            return agent.GetEnumerationItem(enumerationItem.Id) != null;
        }

        /*
                /// <summary>
                /// Checks if the item exists.
                /// </summary>
                /// <param name="perspectiveItem">The perspective item.</param>
                /// <returns></returns>
                private bool PerspectiveItemExists(PerspectiveItem perspectiveItem)
                {
                    if (perspectiveItem == null) throw new ArgumentNullException("perspectiveItem");
                    if (String.IsNullOrEmpty(perspectiveItem.Id)) return false;
                    IPerspectiveItemRepositoryAgent agent = MobiGuiderRepositoryAgentFactory.CreatePerspectiveItemRepositoryAgent();
                    return PerspectiveItemExists(perspectiveItem, agent);
                }
        */
        #endregion // PerspectiveItemExists

        #region " ItemLinkExists "

        #endregion // ItemLinkExists

        #region " DescriptionExists "

        //private bool DescriptionExists(Description description, IDescriptionRepositoryAgent agent)
        //{
        //    if (description == null) throw new ArgumentNullException("description");
        //    if (agent == null) throw new ArgumentNullException("agent");
        //    if (String.IsNullOrEmpty(description.Id)) return false;
        //    return agent.SelectById(description.Id) != null;
        //}

        /*
                /// <summary>
                /// Descriptions the exists.
                /// </summary>
                /// <param name="description">The workspace item description.</param>
                /// <returns></returns>
                private bool DescriptionExists(Description description)
                {
                    if (description == null) throw new ArgumentNullException("description");
                    if (String.IsNullOrEmpty(description.Id)) return false;
                    IDescriptionRepositoryAgent agent = MobiGuiderRepositoryAgentFactory.CreateDescriptionRepositoryAgent();
                    return agent.SelectById(description.Id) != null;
                }
        */
        #endregion // DescriptionExists

        #region " ItemPropertyExists "

        /// <summary>
        /// Properties the exists.
        /// </summary>
        /// <param name="enumerationPropertyItem">The perspective item property.</param>
        /// <param name="agent">The agent.</param>
        /// <returns></returns>
        private bool EnumerationPropertyItemExists(EnumerationPropertyItem enumerationPropertyItem, IExplorerAgent agent)
        {
            if (enumerationPropertyItem == null) throw new ArgumentNullException("enumerationPropertyItem");
            if (agent == null) throw new ArgumentNullException("agent");
            if (String.IsNullOrEmpty(enumerationPropertyItem.Id)) return false;
            return agent.GetEnumerationPropertyItem(enumerationPropertyItem.Id) != null;
        }

        /*
                /// <summary>
                /// Properties the exists.
                /// </summary>
                /// <param name="itemProperty">The item property.</param>
                /// <returns></returns>
                private bool ItemPropertyExists(ItemProperty ItemProperty)
                {
                    if (itemProperty == null) throw new ArgumentNullException("itemProperty");
                    if (String.IsNullOrEmpty(itemProperty.Id)) return false;
                    IPerspectiveItemPropertyRepositoryAgent agent = MobiGuiderRepositoryAgentFactory.CreateItemPropertyRepositoryAgent();
                    return ItemPropertyExists(itemProperty, agent);
                }
        */

        #endregion // ItemPropertyExists

        #endregion // Business exists methods

        #region " Domain exists methods "

        /// <summary>
        /// Checks if the workspaceitem exists.
        /// </summary>
        /// <param name="workspaceItem">The workspace item.</param>
        /// <returns></returns>
        public bool WorkspaceItemExists(WorkspaceItem workspaceItem)
        {
            throw new NotImplementedException();
            //if (workspaceItem == null || String.IsNullOrEmpty(workspaceItem.Id)) return false;
            //return MobiGuiderRepositoryAgentFactory.CreatePerspectiveRepositoryAgent().SelectById(workspaceItem.Id) != null;
        }

        /// <summary>
        /// Checks if the item property exists.
        /// </summary>
        /// <param name="workspaceItemProperty">The workspace item property.</param>
        /// <returns></returns>
        public bool WorkspaceItemPropertyExists(WorkspaceItemProperty workspaceItemProperty)
        {
            if (workspaceItemProperty == null || String.IsNullOrEmpty(workspaceItemProperty.Id)) return false;
            IExplorerAgent agent = ExplorerAgentFactory.CreateAgent(ExplorerAgentFactory.Key.Instance);
            if (agent != null)
            {
                return agent.GetEnumerationPropertyItem(workspaceItemProperty.Id) != null;
            }
            return false;
        }

        /// <summary>
        /// Checks if the item description exists.
        /// </summary>
        /// <param name="workspaceItemDescription">The workspace item description.</param>
        /// <returns></returns>
        public bool WorkspaceItemDescriptionExists(WorkspaceItemDescription workspaceItemDescription)
        {
            if (workspaceItemDescription == null || String.IsNullOrEmpty(workspaceItemDescription.Id)) return false;
            return false;// MobiGuiderRepositoryAgentFactory.CreateDescriptionRepositoryAgent().SelectById(workspaceItemDescription.Id) != null;
        }
        #endregion

        #endregion // Exists methods

        /*
        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <param name="workspaceItemDescription">The workspace item description.</param>
        /// <param name="agent">The agent.</param>
        /// <returns></returns>
        private Description GetDescription(WorkspaceItemDescription workspaceItemDescription, IDescriptionRepositoryAgent agent)
        {
            if (workspaceItemDescription == null) throw new ArgumentNullException("workspaceItemDescription");
            if (agent == null) throw new ArgumentNullException("agent");
            return agent.SelectById(workspaceItemDescription.Id);
        }
*/

        /// <summary>
        /// Create a new workspace.
        /// </summary>
        /// <param name="workspaceItem">The workspace.</param>
        /// <returns></returns>
        public string RegisterWorkspace(WorkspaceItem workspaceItem)
        {
            string result;
            EnumerationItem enumeration = null;
            PerspectiveItem perspective = null;
            IEnumerable<DescriptionItem> descriptions = null;
            IEnumerable<EnumerationPropertyItem> properties = null;
            try
            {
                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    enumeration = RegisterWorkspaceItem(workspaceItem);
                    perspective = RegisterWorkspacePerspective(workspaceItem);
                    descriptions = RegisterWorkspaceDescriptions(workspaceItem);
                    properties = RegisterWorkspaceProperties(workspaceItem);
                    scope.Complete();

                    result = perspective.Id;
                }
            }
            catch (TransactionAbortedException ex)
            {
                DebugHelper(ex, workspaceItem);
                LogError(new object[] { enumeration, perspective, descriptions, properties });
                throw;
            }
            catch (Exception ex)
            {
                DebugHelper(ex, workspaceItem);
                LogError(new object[] { enumeration, perspective, descriptions, properties });
                throw;
            }
            return result;
        }


        /// <summary>
        /// Creates a WorkspaceItemDescription from a description.
        /// </summary>
        /// <param name="descriptions">The descriptions.</param>
        /// <returns></returns>
        private WorkspaceItemDescription[] CreateWorkspaceItemDescriptions(IEnumerable<DescriptionItem> descriptions)
        {
            return descriptions.Select(CreateWorkspaceItemDescription).ToArray();
        }

        /// <summary>
        /// Creates a WorkspaceItemProperty from a ItemProperty.
        /// </summary>
        /// <param name="enumerationPropertyItem">The perspective item property.</param>
        /// <returns></returns>
        private WorkspaceItemProperty CreateWorkspaceItemProperty(EnumerationPropertyItem enumerationPropertyItem)
        {
            return new WorkspaceItemProperty
            {
                AdditionalInfoUri = enumerationPropertyItem.AdditionalInfoUri,
                Id = enumerationPropertyItem.Id,
                ItemId = enumerationPropertyItem.Id,
                PropertyName = enumerationPropertyItem.Title,
                PropertyTypeDescription = GetPropertyTypeDescription(enumerationPropertyItem.EnumerationId),
                PropertyTypeId = enumerationPropertyItem.TypeId,
                PropertyValue = enumerationPropertyItem.Value
            };
        }

        /// <summary>
        /// Creates an IEnumerable of WorkspaceItemProperty from an IEnumerable of ItemProperty.
        /// </summary>
        /// <param name="enumerationPropertyItems">The perspective item properties.</param>
        /// <returns></returns>
        private IEnumerable<WorkspaceItemProperty> CreateWorkspaceItemProperties(IEnumerable<EnumerationPropertyItem> enumerationPropertyItems)
        {
            return enumerationPropertyItems.Select(CreateWorkspaceItemProperty);
        }

        /// <summary>
        /// Creates a WorkspaceItemDescription from a description.
        /// </summary>
        /// <returns></returns>
        private WorkspaceItemDescription CreateWorkspaceItemDescription(DescriptionItem descriptionItem)
        {
            return new WorkspaceItemDescription
            {
                AdditionalInfoUri = descriptionItem.AdditionalInfoUri,
                CultureId = descriptionItem.CultureId,
                Id = descriptionItem.Id,
                Image = descriptionItem.Blob ?? new byte[] { },
                ItemId = descriptionItem.ObjectId,
                Title = descriptionItem.Title,
                TypeId = descriptionItem.TypeId
            };
        }

        /// <summary>
        /// Register a Perspective from a WorkspaceItem.
        /// </summary>
        /// <param name="workspaceItem">The w item.</param>
        /// <returns></returns>
        private PerspectiveItem RegisterWorkspacePerspective(WorkspaceItem workspaceItem)
        {
            IExplorerAgent agent = ExplorerAgentFactory.CreateAgent(ExplorerAgentFactory.Key.Instance);
            if (agent != null)
            {
                PerspectiveItem perspectiveItem = new PerspectiveItem
                                                      {
                                                          Id = workspaceItem.Id,
                                                          ParentId = workspaceItem.ParentId,
                                                          EnumerationId = workspaceItem.ItemId
                                                      };
                return agent.SavePerspectiveItem(perspectiveItem);
            }
            return null;
        }

        /// <summary>
        /// Registers a StoreItem from a WorkspaceItem.
        /// </summary>
        /// <returns></returns>
        private EnumerationItem RegisterWorkspaceItem(WorkspaceItem workspaceItem)
        {
            IExplorerAgent agent = ExplorerAgentFactory.CreateAgent(ExplorerAgentFactory.Key.Instance);
            bool insert = String.IsNullOrEmpty(workspaceItem.ItemId);
            EnumerationItem enumerationItemSaved = null;
            EnumerationItem enumerationItem = new EnumerationItem
            {
                Id = insert ? Guid.NewGuid().ToString() : workspaceItem.ItemId,
                TypeId = workspaceItem.IsFolder ? ExplorerDomainGenerator.GetEnumerationTypeId(EnumBaseType.TreeViewFolder) : workspaceItem.TypeId,
                Title = workspaceItem.ItemTitle,
                Image = workspaceItem.ItemImage ?? new byte[] { },
                SortOrder = workspaceItem.SortOrder,
                DateModified = DateTime.Now
            };

            try
            {
                enumerationItemSaved = agent.SaveEnumerationItem(enumerationItem);
            }
            catch (TransactionAbortedException ex)
            {
                DebugHelper(ex, workspaceItem);
                Debug.WriteLine(DebugWriteLinePrefix + ": EnumerationItem ( " + enumerationItem + ")");
                Debug.WriteLine(DebugWriteLinePrefix + ": " + enumerationItemSaved == null ? "Error saving enumerationItem" : "EnumerationItemSaved ( " + enumerationItemSaved + ")");
                Debug.WriteLine(DebugWriteLinePrefix + ": " + ex);
                throw;
            }
            catch (Exception ex)
            {
                DebugHelper(ex, workspaceItem);
                Debug.WriteLine(DebugWriteLinePrefix + ": EnumerationItem ( " + enumerationItem + ")");
                Debug.WriteLine(DebugWriteLinePrefix + ": " + enumerationItemSaved == null ? "Error saving enumerationItem" : "EnumerationItemSaved ( " + enumerationItemSaved + ")");
                Debug.WriteLine(DebugWriteLinePrefix + ": " + ex);
                throw;
            }
            return enumerationItemSaved;
        }

        /// <summary>
        /// Registers a ItemProperty from a WorkspaceItemProperty.
        /// </summary>
        /// <param name="workspaceItemProperty">The workspace item property.</param>
        /// <returns></returns>
        public string RegisterProperty(WorkspaceItemProperty workspaceItemProperty)
        {
            IExplorerAgent agent = ExplorerAgentFactory.CreateAgent(ExplorerAgentFactory.Key.Instance);
            if (agent != null)
            {
                EnumerationPropertyItem enumerationPropertyItem = agent.SaveEnumerationPropertyItem(CreateEnumerationPropertyItem(workspaceItemProperty));
                return enumerationPropertyItem.Id;
            }
            return null;
        }

        private EnumerationPropertyItem CreateEnumerationPropertyItem(WorkspaceItemProperty workspaceItemProperty)
        {
            return new EnumerationPropertyItem
                       {
                           Id = workspaceItemProperty.Id,
                           EnumerationId = workspaceItemProperty.ItemId,
                           TypeId = workspaceItemProperty.PropertyTypeId,
                           Title = workspaceItemProperty.PropertyName,
                           Value = workspaceItemProperty.PropertyValue,
                           AdditionalInfoUri = workspaceItemProperty.AdditionalInfoUri
                       };
        }

        /// <summary>
        /// Registers a ItemProperty from a WorkspaceItemProperty.
        /// </summary>
        /// <param name="workspaceItemProperty">The workspace item property.</param>
        /// <param name="agent">The agent.</param>
        /// <returns></returns>
        private EnumerationPropertyItem RegisterProperty(WorkspaceItemProperty workspaceItemProperty, IExplorerAgent agent)
        {
            if (agent == null) throw new ArgumentNullException("agent");
            EnumerationPropertyItem enumerationPropertyItemSaved = null;
            EnumerationPropertyItem enumerationPropertyItemNew = null;
            EnumerationPropertyItem enumerationPropertyItemOld = null;
            try
            {
                bool insert = String.IsNullOrEmpty(workspaceItemProperty.Id);
                enumerationPropertyItemNew = new EnumerationPropertyItem
                {
                    Id = insert ? Guid.NewGuid().ToString() : workspaceItemProperty.Id,
                    EnumerationId = workspaceItemProperty.ItemId,
                    Title = workspaceItemProperty.PropertyName,
                    Value = workspaceItemProperty.PropertyValue,
                    TypeId = workspaceItemProperty.PropertyTypeId,
                };

                if (insert || !EnumerationPropertyItemExists(enumerationPropertyItemNew, agent))
                {
                    enumerationPropertyItemSaved = agent.SaveEnumerationPropertyItem(enumerationPropertyItemNew);
                }
                else
                {
                    enumerationPropertyItemOld = GetItemProperty(workspaceItemProperty, agent);
                    enumerationPropertyItemNew.Title = enumerationPropertyItemOld.Title;// don't change the name of the property
                    enumerationPropertyItemSaved = agent.SaveEnumerationPropertyItem(enumerationPropertyItemNew);
                }
            }
            catch (TransactionAbortedException ex)
            {
                DebugHelper(ex, workspaceItemProperty);
                LogError("enumerationPropertyItemNew ({0})", enumerationPropertyItemNew);
                LogError("enumerationPropertyItemOld ({0})", enumerationPropertyItemOld);
                LogError("enumerationPropertyItemSaved ({0})", enumerationPropertyItemSaved);
                LogError(ex);
                throw;
            }
            catch (Exception ex)
            {
                DebugHelper(ex, workspaceItemProperty);
                LogError(new Object[] { enumerationPropertyItemNew, enumerationPropertyItemOld, enumerationPropertyItemSaved });
                LogError("enumerationPropertyItemNew ({0})", enumerationPropertyItemNew);
                LogError("enumerationPropertyItemOld ({0})", enumerationPropertyItemOld);
                LogError("enumerationPropertyItemSaved ({0})", enumerationPropertyItemSaved);
                LogError(ex);
                throw;
            }
            return enumerationPropertyItemSaved;
        }

        /// <summary>
        /// Gets the ItemProperty from a workspaceItemProperty.
        /// </summary>
        /// <param name="workspaceItemProperty">The workspace item property.</param>
        /// <param name="agent">The agent.</param>
        /// <returns></returns>
        private EnumerationPropertyItem GetItemProperty(WorkspaceItemProperty workspaceItemProperty, IExplorerAgent agent)
        {
            if (agent == null) throw new ArgumentNullException("agent");
            return agent.GetEnumerationPropertyItem(workspaceItemProperty.Id);
        }

        /// <summary>
        /// Registers the properties of a WorkspaceItem 
        /// </summary>
        /// <param name="workspaceItem">The w item.</param>
        /// <returns></returns>
        private IEnumerable<EnumerationPropertyItem> RegisterWorkspaceProperties(WorkspaceItem workspaceItem)
        {
            var properties = new List<EnumerationPropertyItem>();
            if (workspaceItem.Properties != null)
            {
                IExplorerAgent agent = ExplorerAgentFactory.CreateAgent(ExplorerAgentFactory.Key.Instance);
                try
                {
                    properties.AddRange(workspaceItem.Properties.Select(workspaceItemProperty => RegisterProperty(workspaceItemProperty, agent)));
                }
                catch (TransactionAbortedException ex)
                {
                    DebugHelper(ex, workspaceItem);
                    throw;
                }
                catch (Exception ex)
                {
                    DebugHelper(ex, workspaceItem);
                    throw;
                }
            }
            return properties;
        }

        /// <summary>
        /// Gets an IEnumerable of WorkspaceItemProperty for an ItemId.
        /// </summary>
        /// <param name="workspaceItemId">The item id.</param>
        /// <returns></returns>
        public WorkspaceItemProperty[] GetProperties(string workspaceItemId)
        {
            IExplorerAgent agent = ExplorerAgentFactory.CreateAgent(ExplorerAgentFactory.Key.Instance);
            EnumerationPropertyItem[] properties = agent.GetEnumerationPropertyItemsForEnumeration(workspaceItemId);
            var workspaceItemProperties = new List<WorkspaceItemProperty>(properties.Length);
            workspaceItemProperties.AddRange(properties.Select(CreateWorkspaceItemProperty));
            return workspaceItemProperties.ToArray();
        }

        /// <summary>
        /// Gets an IEnumerable of WorkspaceItemProperty for TypeId.
        /// </summary>
        /// <param name="typeId">The type id.</param>
        /// <returns></returns>
        public WorkspaceItemProperty[] GetPropertiesForTypeId(string typeId)
        {
            IExplorerAgent agent = ExplorerAgentFactory.CreateAgent(ExplorerAgentFactory.Key.Instance);
            EnumerationPropertyItem[] properties = agent.GetEnumerationPropertyItemsForType(typeId);
            var workspaceItemProperties = new List<WorkspaceItemProperty>(properties.Length);
            workspaceItemProperties.AddRange(properties.Select(CreateWorkspaceItemProperty));
            return workspaceItemProperties.ToArray();
        }

        /// <summary>
        /// Gets the property type description for an ItemId.
        /// </summary>
        /// <param name="itemId">The type id.</param>
        /// <returns></returns>
        private string GetPropertyTypeDescription(string itemId)
        {
            IMediaAgent mediaAgent = MediaAgentFactory.CreateMediaAgent();
            if (mediaAgent != null)
            {
                DescriptionItem[] descriptionItems = mediaAgent.GetDescriptionItemsForObjectAndCulture(itemId, CultureInfo.CurrentCulture.Name);
                if (descriptionItems != null && descriptionItems.Length > 0) return descriptionItems[0].Title;
            }
            IExplorerAgent explorerAgent = ExplorerAgentFactory.CreateAgent(ExplorerAgentFactory.Key.Instance);
            if (explorerAgent != null)
            {
                EnumerationItem enumerationItem = explorerAgent.GetEnumerationItem(itemId);
                return enumerationItem.Title;
            }
            return String.Empty;
        }

        /// <summary>
        /// Gets an IEnumerable of WorkspaceItemDescription for an ItemId.
        /// </summary>
        /// <param name="itemId">The item id.</param>
        /// <returns></returns>
        public WorkspaceItemDescription[] GetDescriptions(string itemId)
        {
            List<WorkspaceItemDescription> result;
            IMediaAgent agent = MediaAgentFactory.CreateMediaAgent();
            if (agent != null)
            {
                DescriptionItem[] items = agent.GetDescriptionItemsForObject(itemId);
                result = new List<WorkspaceItemDescription>(items.Length);
                result.AddRange(items.Select(CreateWorkspaceItemDescription));
                return result.ToArray();
            }
            return null;
        }

        /// <summary>
        /// Gets the languages.
        /// </summary>
        /// <returns></returns>
        public WorkspaceItem[] GetLanguages()
        {
            IExplorerAgent agentExplorer = ExplorerAgentFactory.CreateAgent(ExplorerAgentFactory.Key.Instance);
            EnumerationItem[] items = agentExplorer.GetEnumerationItemsForType(ExplorerDomainGenerator.GetEnumerationTypeId(EnumBaseType.Languages));
            var resultItems = new List<WorkspaceItem>();
            resultItems.AddRange(items.Select(item => CreateWorkspaceItem(item)));
            return resultItems.ToArray();
        }

        /// <summary>
        /// Gets the types.
        /// </summary>
        /// <returns></returns>
        public WorkspaceItem[] GetTypes()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the workspace items by search string.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <returns></returns>
        public WorkspaceItem[] GetWorkspaceItemsBySearchString(string searchString)
        {
            IExplorerAgent agentExplorer = ExplorerAgentFactory.CreateAgent(ExplorerAgentFactory.Key.Instance);
            EnumerationItem[] searchedItems = agentExplorer.GetEnumerationItemsForSearch(searchString);
            var resultItems = new List<WorkspaceItem>(searchedItems.Length);
            resultItems.AddRange(searchedItems.Select(item => CreateWorkspaceItem(item)));
            return resultItems.ToArray();
        }

        /// <summary>
        /// Gets an IEnumerable of WorkspaceItem for TypeId without properties.
        /// </summary>
        /// <param name="typeId">The type id.</param>
        /// <returns></returns>
        public WorkspaceItem[] GetItemsForTypeId(string typeId)
        {
            IExplorerAgent agentExplorer = ExplorerAgentFactory.CreateAgent(ExplorerAgentFactory.Key.Instance);
            EnumerationItem[] items = agentExplorer.GetEnumerationItemsForType(typeId);
            var result = new List<WorkspaceItem>();
            result.AddRange(items.Select(item => CreateWorkspaceItem(item, Method.GetDescriptions)));
            return result.ToArray();
        }

        /// <summary>
        /// Gets an IEnumerable of WorkspaceItem for TypeId with properties.
        /// </summary>
        /// <param name="typeId">The type id.</param>
        /// <returns></returns>
        public WorkspaceItem[] GetItemsForTypeIdWithProperties(string typeId)
        {
            IExplorerAgent agentExplorer = ExplorerAgentFactory.CreateAgent(ExplorerAgentFactory.Key.Instance);
            EnumerationItem[] items = agentExplorer.GetEnumerationItemsForType(typeId);
            var result = new List<WorkspaceItem>(items.Length);
            result.AddRange(items.Select(item => CreateWorkspaceItem(item))); // default = Method.GetProperties | Method.GetDescriptions
            return result.ToArray();
        }

        /// <summary>
        /// Selects the by item id and culture id and type id.
        /// </summary>
        /// <param name="itemId">The item id.</param>
        /// <param name="cultureId">The culture id.</param>
        /// <param name="typeId">The type id.</param>
        /// <returns></returns>
        public WorkspaceItemDescription[] SelectByItemIdAndCultureIdAndTypeId(string itemId, string cultureId, string typeId)
        {
            IMediaAgent agent = MediaAgentFactory.CreateMediaAgent();
            var result = new List<WorkspaceItemDescription>();
            if (agent != null)
            {
                DescriptionItem[] descriptions = agent.GetDescriptionItemsForObjectCultureAndType(itemId, cultureId, typeId);
                result.AddRange(descriptions.Select(CreateWorkspaceItemDescription));
            }
            return result.ToArray();
        }

        public void DeleteWorkspaceItem(WorkspaceItem workspaceItem)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required))
            {
                string enumerationId = workspaceItem.ItemId;
                IExplorerAgent explorerAgent = ExplorerAgentFactory.CreateAgent(ExplorerAgentFactory.Key.Instance);
                IMediaAgent mediaAgent = MediaAgentFactory.CreateMediaAgent();

                DescriptionItem[] descriptionItems = mediaAgent.GetDescriptionItemsForObject(enumerationId);
                EnumerationItem enumerationItem = explorerAgent.GetEnumerationItem(enumerationId);
                EnumerationPropertyItem[] enumerationPropertyItems = explorerAgent.GetEnumerationPropertyItemsForEnumeration(enumerationId);
                PerspectiveItem perspectiveItem = explorerAgent.GetPerspectiveItem(workspaceItem.Id);

                foreach (DescriptionItem descriptionItem in descriptionItems)
                {
                    mediaAgent.DeleteDescription(descriptionItem);
                }

                foreach (EnumerationPropertyItem propertyItem in enumerationPropertyItems)
                {
                    explorerAgent.DeleteEnumerationPropertyItem(propertyItem.Id);
                }

                explorerAgent.DeletePerspectiveItem(perspectiveItem.Id);
                explorerAgent.DeleteEnumerationItem(enumerationItem.Id);

                scope.Complete();
            }
        }

        public void DeleteWorkspaceItems(WorkspaceItem[] workspaceItems)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required))
            {
                foreach (var workspaceItem in workspaceItems)
                {
                    DeleteWorkspaceItem(workspaceItem);
                }
            }
        }

        /// <summary>
        /// Gets the full workspace item.
        /// </summary>
        /// <param name="itemId">The item id.</param>
        /// <returns></returns>
        public WorkspaceItem GetFullWorkspaceItem(string itemId)
        {
            IExplorerAgent explorerAgent = ExplorerAgentFactory.CreateAgent(ExplorerAgentFactory.Key.Instance);
            EnumerationItem enumerationItem =  explorerAgent.GetEnumerationItem(itemId);
            return CreateWorkspaceItem(enumerationItem, Method.GetChildren | Method.GetDescriptions | Method.GetProperties);
        }

        /// <summary>
        /// Gets the folders.
        /// </summary>
        /// <param name="workspaceId">The workspace id.</param>
        /// <returns></returns>
        public WorkspaceItem[] GetFolders(string workspaceId)
        {
            IExplorerAgent explorerAgent = ExplorerAgentFactory.CreateAgent(ExplorerAgentFactory.Key.Instance);
            PerspectiveItem[] items;
            var result = new List<WorkspaceItem>();
            if (explorerAgent != null)
            {
                if (workspaceId == WorkspaceRoot.Top)
                {
                    var item = explorerAgent.GetPerspectiveItem(WorkspaceRoot.Id);

                    if (item != null) result.Add(CreateWorkspaceItem(item));
                    return result.ToArray();
                }
                items = explorerAgent.GetPerspectiveItemsForParentPerspectiveAndEnumerationType(workspaceId, ExplorerDomainGenerator.GetEnumerationTypeId(EnumBaseType.TreeViewFolder));
                if (items != null) result.AddRange(items.Select(item => CreateWorkspaceItem(item)));
            }
            return result.ToArray();
        }

        /*
                /// <summary>
                /// Clears all tables.
                /// </summary>
                /// <returns></returns>
                private bool ClearAllTables()
                {
                    try
                    {
                        IDescriptionRepositoryAgent agentD = MobiGuiderRepositoryAgentFactory.CreateDescriptionRepositoryAgent();
                        Description[] descriptions = agentD.SelectAll();

                        if (descriptions.Length > 0)
                        {
                            foreach (var t in descriptions)
                            {
                                agentD.Delete(t.Id);
                            }
                        }

                        IPerspectiveItemPropertyRepositoryAgent agentP =
                        MobiGuiderRepositoryAgentFactory.CreateHierarchyItemPropertyRepositoryAgent();
                        ItemProperty[] properties = agentP.SelectAll();

                        if (properties.Length > 0)
                        {
                            int length = properties.Length;
                            for (int i = 0; i < length; i++)
                            {
                                agentP.Delete(properties[i].Id);
                            }
                        }

                        IHierarchyRepositoryAgent agentH = MobiGuiderRepositoryAgentFactory.CreateHierarchyRepositoryAgent();
                        Perspective[] hierarchies = agentH.SelectAll();

                        if (hierarchies.Length > 0)
                        {
                            int length = hierarchies.Length;
                            for (int i = 0; i < length; i++)
                            {
                                agentH.Delete(hierarchies[i].Id);
                            }
                        }

                        IHierarchyItemRepositoryAgent agentI = MobiGuiderRepositoryAgentFactory.CreateHierarchyItemRepositoryAgent();
                        PerspectiveItem[] sourceItems = agentI.SelectAll();
                        if (sourceItems.Length > 0)
                        {
                            int length = sourceItems.Length;
                            ClearTableHierachyItem(ref agentI, ref sourceItems, new PerspectiveItem { Id = null, TypeId = null }, 1, length);
                        }
                        return true;
                    }
                    
                }
        */

        /*
                /// <summary>
                /// Gets the workspace id.
                /// </summary>
                /// <returns></returns>
                private string GetWorkspaceId()
                {
                    IHierarchyRepositoryAgent agent = MobiGuiderRepositoryAgentFactory.CreateHierarchyRepositoryAgent();
                    Perspective[] hTop = agent.SelectRoot();
                    if (hTop != null && hTop.Length > 0)
                    {
                        return hTop[0].ParentId;
                    }
                    return null;
                }
        */

        /*
                /// <summary>
                /// Gets parent and child hierarchies.
                /// </summary>
                /// <param name="sourceItems">Collection of all hierarchyitems3</param>
                /// <param name="returnItems">The workspaceitems which will be returned to the method.</param>
                /// <param name="parentWorkspaceItem">Property of the workspaceItem where the children ( workspaceitems ) will be assigned to. 
                /// This is done in the next call of the recursive GetHierarchies method</param>
                /// <param name="parentHierarchyItems">The parent workspaceitems (if any).</param>
                private void GetHierarchies(ref HierarchyItem3[] sourceItems, ref WorkspaceItem[] returnItems, ref WorkspaceItem parentWorkspaceItem, IEnumerable<HierarchyItem3> parentHierarchyItems)
                {
                    var indexChildren = 0;

                    foreach (var parentHierarchyItem in parentHierarchyItems)
                    {
                        int returnItemLength = returnItems.Length;
                        var hierarchyId = parentHierarchyItem.HierarchyId;
                        var hierarchyParentId = parentHierarchyItem.HierarchyParentId;
                        Array.Resize(ref returnItems, returnItemLength + 1);
                        WorkspaceItem wItem = CreateWorkspaceItemFromHierarchyItem(parentHierarchyItem);

                        // properties
                        var properties = (from sourceItemProperty in sourceItems
                                          where
                                                sourceItemProperty.HierarchyId == hierarchyId &&
                                                sourceItemProperty.HierarchyParentId == hierarchyParentId &&
                                                sourceItemProperty.Entity == 1 &&
                                                sourceItemProperty.PropertyId.Length > 0
                                          select sourceItemProperty).Distinct().ToArray();

                        int indexProperty = 0;
                        var workspaceItemProperties = new WorkspaceItemProperty[properties.Length];
                        foreach (var p in properties)
                        {
                            workspaceItemProperties[indexProperty++] = new WorkspaceItemProperty { Id = p.PropertyId, ItemId = p.ItemId, PropertyName = p.PropertyName, PropertyTypeDescription = String.Empty, PropertyTypeId = p.TypeId, PropertyValue = p.PropertyValue, AdditionalInfoUri = String.Empty };
                        }
                        wItem.Properties = workspaceItemProperties;

                        // descriptions
                        var descriptions = (from sourceItemDescription in sourceItems
                                            where
                                                sourceItemDescription.HierarchyId == hierarchyId &&
                                                sourceItemDescription.HierarchyParentId == hierarchyParentId &&
                                                sourceItemDescription.Entity == 1 &&
                                                sourceItemDescription.ItemDescriptionId.Length > 0
                                            select sourceItemDescription).Distinct().ToArray();
                        int indexDescription = 0;
                        var workspaceItemDescriptions = new WorkspaceItemDescription[descriptions.Length];
                        foreach (var d in descriptions)
                        {
                            workspaceItemDescriptions[indexDescription++] = new WorkspaceItemDescription { CultureId = d.ItemDescriptionCultureId, Id = d.ItemDescriptionId, Image = d.ItemDescriptionImage, ItemId = d.ItemId, Title = d.ItemDescriptionTitle, TypeId = d.TypeId, AdditionalInfoUri = String.Empty };
                        }
                        wItem.Descriptions = workspaceItemDescriptions;

                        // assign child, workspaceitem and determine the 
                        // children of the current parent
                        if (parentWorkspaceItem != null && parentWorkspaceItem.Children != null) parentWorkspaceItem.Children[indexChildren++] = wItem;
                        returnItems[returnItemLength] = wItem;
                        HierarchyItem3[] childItems = (from item in sourceItems
                                                       where item.Entity == 0 && item.HierarchyParentId == hierarchyId
                                                       select item).ToArray();
                        wItem.Children = new WorkspaceItem[childItems.Length];

                        // if there are children present...
                        if (childItems.Length > 0) GetHierarchies(ref sourceItems, ref returnItems, ref wItem, childItems);
                    }
                }
        */
        /// <summary>
        /// Gets the is folder.
        /// </summary>
        /// <param name="enumerationPropertyItem">The perspective item.</param>
        /// <returns></returns>
        private bool GetIsFolder(EnumerationPropertyItem enumerationPropertyItem)
        {
            return enumerationPropertyItem == null ? false : GetIsFolder(enumerationPropertyItem.TypeId);
        }

        /// <summary>
        /// Gets the is folder.
        /// </summary>
        /// <param name="enumerationItem">The perspective item.</param>
        /// <returns></returns>MobiGuider.Repository.Contract.Domain.
        private bool GetIsFolder(EnumerationItem enumerationItem)
        {
            return enumerationItem == null ? false : GetIsFolder(enumerationItem.TypeId);
        }

        /// <summary>
        /// Gets the is folder.
        /// </summary>
        /// <param name="typeId">The type id.</param>
        /// <returns></returns>
        private bool GetIsFolder(string typeId)
        {
            return typeId == ExplorerDomainGenerator.GetEnumerationTypeId(EnumBaseType.TreeViewFolder);
        }

        private void DebugHelper(Exception ex)
        {
            if (ex is TransactionAbortedException)
            {
                Debug.WriteLine(DebugWriteLinePrefix + ": TransactionAbortedException");
                Debug.WriteLine(DebugWriteLinePrefix + ": ===========================");
            }
            Debug.WriteLine(DebugWriteLinePrefix + ": Exception");
            Debug.WriteLine(DebugWriteLinePrefix + ": =========");
            Debug.WriteLine(DebugWriteLinePrefix + ": InnerException = " + ex.InnerException);
            Debug.WriteLine(DebugWriteLinePrefix + ": Message = " + ex.Message);
        }

        private void DebugHelper(Exception ex, Object item)
        {
            DebugHelper(ex);
            LogInfo(item);
        }

        private void LogInfo(string message)
        {
            Debug.WriteLine(DebugWriteLinePrefix + message);
            _logger.Info(message);
        }

        private void LogInfo(string format, params object[] args)
        {
            Debug.WriteLine(DebugWriteLinePrefix + String.Format(format, args));
            _logger.InfoFormat(format, args);
        }

        private void LogError(string message)
        {
            Debug.WriteLine(DebugWriteLinePrefix + message);
            _logger.Error(message);
        }

        private void LogError(string format, params object[] args)
        {
            Debug.WriteLine(DebugWriteLinePrefix + String.Format(format, args));
            _logger.ErrorFormat(format, args);
        }

        private void LogError(Object[] objects, string[] formats)
        {
            foreach (object o in objects)
            {
                LogError(o);
            }
        }

        private void LogInfoObjects(Object[] objects)
        {
            foreach (object o in objects)
            {
                LogInfo(o.ToString());
            }
        }

        private void LogInfo(Object obj)
        {
            int i = 1;

            if (obj is EnumerationItem) LogInfo("Enumeration ({0})", (EnumerationItem)obj);
            if (obj is PerspectiveItem) LogInfo("Perspective ({0})", (PerspectiveItem)obj);
            if (obj is EnumerationPropertyItem[])
            {
                var items = (EnumerationPropertyItem[])obj;
                foreach (var item in items)
                {
                    LogInfo("Property #{0} : ({1})", i++, item);
                }
            }
            if (obj is DescriptionItem[])
            {
                var items = (DescriptionItem[])obj;
                foreach (var item in items)
                {
                    LogInfo("Description #{0} : ({1})", i++, item);
                }
            }
            if (obj is WorkspaceItem)
            {
                var item = (WorkspaceItem)obj;
                LogInfo("WorkspaceItem ({0})", item);
                i = 1;
                foreach (WorkspaceItemProperty property in item.Properties)
                {
                    LogInfo("\tProperty #{0} : ({1})", i++, property);
                }
                i = 1;
                foreach (WorkspaceItemDescription description in item.Descriptions)
                {
                    LogInfo("\tDescription #{0} : ({1})", i++, description);
                }
            }
            if (obj is WorkspaceItemProperty)
            {
                var item = (WorkspaceItemProperty)obj;
                LogInfo("WorkspaceItemProperty ({0})", item);
            }
            if (obj is WorkspaceItemDescription)
            {
                var item = (WorkspaceItemDescription)obj;
                LogInfo("WorkspaceItemDescription ({0})", item);
            }
        }

        private void LogError(Object obj, string format = "")
        {
            int i = 1;

            if (obj is EnumerationItem) LogError(format, (EnumerationItem)obj);
            if (obj is PerspectiveItem) LogError(format, (PerspectiveItem)obj);
            if (obj is EnumerationPropertyItem[])
            {
                var items = (EnumerationPropertyItem[])obj;
                foreach (var item in items)
                {
                    LogError(format, i, item);
                }
            }
            if (obj is DescriptionItem[])
            {
                var items = (DescriptionItem[])obj;
                foreach (var item in items)
                {
                    LogError(format, i, item);
                }
            }
        }
    }
}
