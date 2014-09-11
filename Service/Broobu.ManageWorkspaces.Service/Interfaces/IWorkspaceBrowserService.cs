using System;
using System.Collections.Generic;
using System.ServiceModel;
using Pms.Framework.Domain;
using Pms.WorkspaceBrowser.Contract.Domain;

namespace Pms.WorkspaceBrowser.Service.Interfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IWorkspaceBrowserService
    {
        [OperationContract]
        WorkspaceItem[] GetWorkspace(string workspaceId);
        [OperationContract]
        WorkspaceItem GetFullWorkspaceItem(string itemId);
        [OperationContract]
        WorkspaceItemProperty[] GetProperties(string itemId);
        [OperationContract]
        WorkspaceItemProperty[] GetPropertiesForTypeId(string typeId);
        [OperationContract]
        WorkspaceItemDescription[] GetDescriptions(string itemId);
        [OperationContract]
        WorkspaceItem[] GetTypes();
        [OperationContract]
        WorkspaceItem[] GetLanguages();
        [OperationContract]
        WorkspaceItem[] GetWorkspaceItemsBySearchString(string searchString);
        [OperationContract]
        String RegisterDescription(WorkspaceItemDescription workspaceItemDescription);
        [OperationContract]
        String RegisterProperty(WorkspaceItemProperty workspaceItemProperty);
        [OperationContract]
        String RegisterWorkspace(WorkspaceItem workspaceItem);
        [OperationContract]
        WorkspaceItem[] GetFolders(string workspaceId);
        [OperationContract]
        bool Initialize();
        [OperationContract]
        WorkspaceItem[] GetItemsForTypeId(string typeId);
        [OperationContract]
        WorkspaceItem[] GetItemsForTypeIdWithProperties(string typeId);
    }
}
