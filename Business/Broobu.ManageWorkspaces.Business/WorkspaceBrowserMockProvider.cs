using System;
using Pms.ManageWorkspaces.Business.Interfaces;
using Pms.ManageWorkspaces.Contract.Constants;
using Pms.ManageWorkspaces.Contract.Domain;

namespace Pms.ManageWorkspaces.Business
{
    class WorkspaceBrowserMockProvider : IWorkspaceBrowserProvider
    {
        public WorkspaceItem[] GetWorkspace()
        {
            return WorkspaceBrowserDomainGenerator
                .GetMockWorkspace(WorkspaceRoot.Parent);
        }

        public WorkspaceItem[] GetWorkspace(string workspaceId)
        {
            return WorkspaceBrowserDomainGenerator
                .GetMockWorkspace(workspaceId);
        }

        public string RegisterDescription(WorkspaceItemDescription workspaceItemDescription)
        {
            return WorkspaceBrowserDomainGenerator
                .RegisterMockDescription(workspaceItemDescription);
        }

        public string RegisterProperty(WorkspaceItemProperty workspaceItemProperty)
        {
            return WorkspaceBrowserDomainGenerator
                .RegisterMockProperty(workspaceItemProperty);
        }

        public String RegisterWorkspace(WorkspaceItem workspaceItem)
        {
            return WorkspaceBrowserDomainGenerator
                .RegisterMockWorkspace(workspaceItem);
        }

        public WorkspaceItemProperty[] GetProperties(string workspaceItemId)
        {
            return WorkspaceBrowserDomainGenerator
                .GetMockProperties(workspaceItemId);
        }

        public WorkspaceItemProperty[] GetPropertiesForTypeId(string typeId)
        {
            return WorkspaceBrowserDomainGenerator
               .GetMockPropertiesForTypeId(typeId);
        }

        public WorkspaceItemDescription[] GetDescriptions(string itemId)
        {
            return WorkspaceBrowserDomainGenerator
                .GetMockDescriptions(itemId);
        }

        public WorkspaceItem[] GetLanguages()
        {
            return WorkspaceBrowserDomainGenerator
                .GetMockLanguages();
        }

        public WorkspaceItem[] GetTypes()
        {
            return WorkspaceBrowserDomainGenerator
                .GetMockTypes();
        }

        public WorkspaceItem[] GetWorkspaceItemsBySearchString(string searchString)
        {
            return WorkspaceBrowserDomainGenerator
                .GetMockWorkspaceItemsBySearchString(searchString);
        }

        public WorkspaceItem[] GetItemsForTypeId(string typeId)
        {
            return WorkspaceBrowserDomainGenerator
                .GetMockItemsForTypeId(typeId);
        }

        public WorkspaceItem[] GetItemsForTypeIdWithProperties(string typeId)
        {
            return WorkspaceBrowserDomainGenerator
                .GetMockItemsForTypeIdWithProperties(typeId);
        }

        public WorkspaceItemDescription[] SelectByItemIdAndCultureIdAndTypeId(string itemId, string cultureId, string typeId)
        {
            return WorkspaceBrowserDomainGenerator
                .SelectByItemIdAndCultureIdAndTypeId();
        }

        public void DeleteWorkspaceItem(WorkspaceItem workspaceItem)
        {
            throw new NotImplementedException();
        }

        public void DeleteWorkspaceItems(WorkspaceItem[] workspaceItems)
        {
            throw new NotImplementedException();
        }

        public WorkspaceItem GetFullWorkspaceItem(string itemId)
        {
            return WorkspaceBrowserDomainGenerator
                .GetMockFullWorkspaceItem(itemId);
        }

        public WorkspaceItem[] GetFolders(string workspaceId)
        {
            return WorkspaceBrowserDomainGenerator.GetMockWorkspace(workspaceId);
        }

        public bool Initialize()
        {
            return WorkspaceBrowserDomainGenerator.InitializeMock();
        }
    }
}
