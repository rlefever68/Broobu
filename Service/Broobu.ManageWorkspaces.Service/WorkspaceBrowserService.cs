using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using Pms.ManageWorkspaces.Business;
using Pms.ManageWorkspaces.Business.Interfaces;
using Pms.ManageWorkspaces.Contract.Domain;
using Pms.ManageWorkspaces.Contract.Interfaces;
using Pms.Framework.Networking.Wcf;
using System.Diagnostics;

namespace Pms.ManageWorkspaces.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class WorkspaceBrowserService : BusinessServiceBase, IWorkspaceBrowserService
    {
        private const string DebugWriteLinePrefix = "Pms.ManageWorkspaces.Service.WorkspaceBrowserService";

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <returns></returns>
        public bool Initialize()
        {
            Logger.Info("Force initialize");
            IWorkspaceBrowserProvider provider = WorkspaceBrowserProviderFactory.CreateProvider(WorkspaceBrowserProviderFactory.Key.Instance);
            if(provider == null)
            {
                Logger.Error("IWorkspaceBrowserProvider == null");
                return false;
            }
            return provider.Initialize();
        }

        /// <summary>
        /// Gets the workspace items.
        /// </summary>
        /// <param name="workspaceId">The workspace id.</param>
        /// <returns></returns>
        public WorkspaceItem[] GetWorkspace(string workspaceId)
        {
            IWorkspaceBrowserProvider provider = WorkspaceBrowserProviderFactory.CreateProvider(WorkspaceBrowserProviderFactory.Key.Instance);
            if (provider != null) return provider.GetWorkspace(workspaceId);
            Debug.WriteLine(DebugWriteLinePrefix + ": IWorkspaceBrowserProvider == null"); return null;
        }

        /// <summary>
        /// Gets the full workspace item.
        /// </summary>
        /// <param name="itemId">The item id.</param>
        /// <returns></returns>
        public WorkspaceItem GetFullWorkspaceItem(string itemId)
        {
            IWorkspaceBrowserProvider provider = WorkspaceBrowserProviderFactory.CreateProvider(WorkspaceBrowserProviderFactory.Key.Instance);
            if (provider != null) return provider.GetFullWorkspaceItem(itemId);
            Debug.WriteLine(DebugWriteLinePrefix + ": IWorkspaceBrowserProvider == null"); return null;
        }

        /// <summary>
        /// Gets the properties.
        /// </summary>
        /// <param name="itemId">The item id.</param>
        /// <returns></returns>
        public WorkspaceItemProperty[] GetProperties(string itemId)
        {
            IWorkspaceBrowserProvider provider = WorkspaceBrowserProviderFactory.CreateProvider(WorkspaceBrowserProviderFactory.Key.Instance);
            if (provider != null) return provider.GetProperties(itemId);
            Debug.WriteLine(DebugWriteLinePrefix + ": IWorkspaceBrowserProvider == null"); return null;
        }

        public WorkspaceItemProperty[] GetPropertiesForTypeId(string typeId)
        {
            IWorkspaceBrowserProvider provider = WorkspaceBrowserProviderFactory.CreateProvider(WorkspaceBrowserProviderFactory.Key.Instance);
            if (provider != null) return provider.GetPropertiesForTypeId(typeId);
            Debug.WriteLine(DebugWriteLinePrefix + ": IWorkspaceBrowserProvider == null"); return null;
        }

        /// <summary>
        /// Gets the descriptions.
        /// </summary>
        /// <param name="itemId">The item id.</param>
        /// <returns></returns>
        public WorkspaceItemDescription[] GetDescriptions(string itemId)
        {
            IWorkspaceBrowserProvider provider = WorkspaceBrowserProviderFactory.CreateProvider(WorkspaceBrowserProviderFactory.Key.Instance);
            if (provider != null) return provider.GetDescriptions(itemId);
            Debug.WriteLine(DebugWriteLinePrefix + ": IWorkspaceBrowserProvider == null"); return null;
        }

        /// <summary>
        /// Gets the types.
        /// </summary>
        /// <returns></returns>
        public WorkspaceItem[] GetTypes()
        {
            IWorkspaceBrowserProvider provider = WorkspaceBrowserProviderFactory.CreateProvider(WorkspaceBrowserProviderFactory.Key.Instance);
            if (provider != null) return provider.GetTypes();
            Debug.WriteLine(DebugWriteLinePrefix + ": IWorkspaceBrowserProvider == null"); return null;
        }

        /// <summary>
        /// Gets the languages.
        /// </summary>
        /// <returns></returns>
        public WorkspaceItem[] GetLanguages()
        {
            IWorkspaceBrowserProvider provider = WorkspaceBrowserProviderFactory.CreateProvider(WorkspaceBrowserProviderFactory.Key.Instance);
            if (provider != null) return provider.GetLanguages();
            Debug.WriteLine(DebugWriteLinePrefix + ": IWorkspaceBrowserProvider == null"); return null;
        }

        /// <summary>
        /// Gets the workspace items by search string.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <returns></returns>
        public WorkspaceItem[] GetWorkspaceItemsBySearchString(string searchString)
        {
            IWorkspaceBrowserProvider provider = WorkspaceBrowserProviderFactory.CreateProvider(WorkspaceBrowserProviderFactory.Key.Instance);
            if (provider != null) return provider.GetWorkspaceItemsBySearchString(searchString);
            Debug.WriteLine(DebugWriteLinePrefix + ": IWorkspaceBrowserProvider == null"); return null;
        }

        /// <summary>
        /// Registers the description.
        /// </summary>
        /// <param name="workspaceItemDescription">The workspace item description.</param>
        /// <returns></returns>
        public string RegisterDescription(WorkspaceItemDescription workspaceItemDescription)
        {
            IWorkspaceBrowserProvider provider = WorkspaceBrowserProviderFactory.CreateProvider(WorkspaceBrowserProviderFactory.Key.Instance);
            if (provider != null) return provider.RegisterDescription(workspaceItemDescription);
            Debug.WriteLine(DebugWriteLinePrefix + ": IWorkspaceBrowserProvider == null"); return null;
        }

        /// <summary>
        /// Registers the property.
        /// </summary>
        /// <param name="workspaceItemProperty">The workspace item property.</param>
        /// <returns></returns>
        public string RegisterProperty(WorkspaceItemProperty workspaceItemProperty)
        {
            IWorkspaceBrowserProvider provider = WorkspaceBrowserProviderFactory.CreateProvider(WorkspaceBrowserProviderFactory.Key.Instance);
            if (provider != null) return provider.RegisterProperty(workspaceItemProperty);
            Debug.WriteLine(DebugWriteLinePrefix + ": IWorkspaceBrowserProvider == null"); return null;
        }

        /// <summary>
        /// Registers the workspace.
        /// </summary>
        /// <param name="workspaceItem">The workspace item.</param>
        /// <returns></returns>
        public String RegisterWorkspace(WorkspaceItem workspaceItem)
        {
            IWorkspaceBrowserProvider provider = WorkspaceBrowserProviderFactory.CreateProvider(WorkspaceBrowserProviderFactory.Key.Instance);
            if (provider != null) return provider.RegisterWorkspace(workspaceItem);
            Debug.WriteLine(DebugWriteLinePrefix + ": IWorkspaceBrowserProvider == null"); return null;
        }

        /// <summary>
        /// Gets the folders.
        /// </summary>
        /// <param name="workspaceId">The workspace id.</param>
        /// <returns></returns>
        public WorkspaceItem[] GetFolders(string workspaceId)
        {
            IWorkspaceBrowserProvider provider = WorkspaceBrowserProviderFactory.CreateProvider(WorkspaceBrowserProviderFactory.Key.Instance);
            if (provider != null) return provider.GetFolders(workspaceId);
            Debug.WriteLine(DebugWriteLinePrefix + ": IWorkspaceBrowserProvider == null"); return null;
        }

        /// <summary>
        /// Gets the items for type id.
        /// </summary>
        /// <param name="typeId">The type id.</param>
        /// <returns></returns>
        public WorkspaceItem[] GetItemsForTypeId(string typeId)
        {
            IWorkspaceBrowserProvider provider = WorkspaceBrowserProviderFactory.CreateProvider(WorkspaceBrowserProviderFactory.Key.Instance);
            if (provider != null) return provider.GetItemsForTypeId(typeId);
            Debug.WriteLine(DebugWriteLinePrefix + ": IWorkspaceBrowserProvider == null"); return null;
        }

        /// <summary>
        /// Gets the items for type id with properties.
        /// </summary>
        /// <param name="typeId">The type id.</param>
        /// <returns></returns>
        public WorkspaceItem[] GetItemsForTypeIdWithProperties(string typeId)
        {
            IWorkspaceBrowserProvider provider = WorkspaceBrowserProviderFactory.CreateProvider(WorkspaceBrowserProviderFactory.Key.Instance);
            if (provider != null) return provider.GetItemsForTypeIdWithProperties(typeId);
            Debug.WriteLine(DebugWriteLinePrefix + ": IWorkspaceBrowserProvider == null"); return null;
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
            IWorkspaceBrowserProvider provider = WorkspaceBrowserProviderFactory.CreateProvider(WorkspaceBrowserProviderFactory.Key.Instance);
            if (provider != null) return provider.SelectByItemIdAndCultureIdAndTypeId(itemId, cultureId, typeId);
            Debug.WriteLine(DebugWriteLinePrefix + ": IWorkspaceBrowserProvider == null"); return null;
        }

        public void DeleteWorkspaceItem(WorkspaceItem workspaceItem)
        {
            IWorkspaceBrowserProvider provider = WorkspaceBrowserProviderFactory.CreateProvider(WorkspaceBrowserProviderFactory.Key.Instance);
            if (provider != null)
            {
                provider.DeleteWorkspaceItem(workspaceItem);
                return;
            }
            Debug.WriteLine(DebugWriteLinePrefix + ": IWorkspaceBrowserProvider == null"); 
        }

        public void DeleteWorkspaceItems(WorkspaceItem[] workspaceItems)
        {
            IWorkspaceBrowserProvider provider = WorkspaceBrowserProviderFactory.CreateProvider(WorkspaceBrowserProviderFactory.Key.Instance);
            if (provider != null)
            {
                provider.DeleteWorkspaceItems(workspaceItems);
                return;
            }
            Debug.WriteLine(DebugWriteLinePrefix + ": IWorkspaceBrowserProvider == null");
        }

        protected override void RegisterRequiredDomainObjects()
        {
            Logger.Info("RegisterRequiredDomainObjects");
            IWorkspaceBrowserProvider provider = WorkspaceBrowserProviderFactory.CreateProvider(WorkspaceBrowserProviderFactory.Key.Instance);
            if (provider != null)
            {
                provider.Initialize();
                return;
            }
            Logger.Error("RegisterRequiredDomainObjects can not create provider from WorkspaceBrowserProviderFactory");
            Debug.WriteLine(DebugWriteLinePrefix + ": IWorkspaceBrowserProvider == null");
        }
    }
}