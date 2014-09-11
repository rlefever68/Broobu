using System;
using System.Collections.Generic;
using Pms.ManageWorkspaces.Contract.Domain;
using Pms.ManageWorkspaces.Contract.Result;

namespace Pms.ManageWorkspaces.Contract.Interfaces
{
    public interface IWorkspaceBrowserAgent : IWorkspaceBrowserService
    {

        void GetWorkspaceAsync(string workspaceId, Action<WorkspaceItemResult<WorkspaceItem>> action);
        //event Action<WorkspaceItemResult<WorkspaceItem>> GetWorkspaceCompleted;

        void GetFoldersAsync(string workspaceId, Action<WorkspaceItemResult<WorkspaceItem>> action);
        //  void GetFoldersAsync(string workspaceId);
        //  event Action<WorkspaceItemResult<WorkspaceItem>> GetFoldersCompleted;

        void GetDescriptionsAsync(string itemId, Action<WorkspaceItemResult<WorkspaceItemDescription>> action);
        //event Action<WorkspaceItemResult<WorkspaceItemDescription>> GetDescriptionsCompleted;

        void GetPropertiesAsync(string itemId, Action<WorkspaceItemResult<WorkspaceItemProperty>> action);
        //void GetPropertiesAsync(string itemId);
        //event Action<WorkspaceItemResult<WorkspaceItemProperty>> GetPropertiesCompleted;

        void GetFullWorkspaceItemAsync(string itemId, Action<WorkspaceItemResult<WorkspaceItem>> action);
        //void GetFullWorkspaceItemAsync(string itemId);
        // event Action<WorkspaceItemResult<WorkspaceItem>> GetFullWorkspaceItemCompleted;


        // new

        void GetLanguagesAsync(Action<WorkspaceItemResult<WorkspaceItem>> action);
        //void GetLanguagesAsync();
        //event Action<WorkspaceItemResult<WorkspaceItem>> GetLanguagesCompleted;

        void AddFolderAsync(List<String> newFolderString);
        event Action<WorkspaceItemResult<WorkspaceItem>> AddFolderCompleted;

        void GetWorkspaceItemsBySearchStringAsync(string searchString, Action<WorkspaceItemResult<WorkspaceItem>> action);
        //void GetWorkspaceItemsBySearchStringAsync(String searchString);
        //event Action<WorkspaceItemResult<WorkspaceItem>> GetWorkspaceItemsBySearchStringCompleted;

        // end new

        void RegisterDraggedDataAsync(WorkspaceItem workspaceSource, WorkspaceItem workspaceTarget, Action<WorkspaceItemResult<WorkspaceItem>> action);
        //void RegisterDraggedDataAsync(WorkspaceItem workspaceSource, WorkspaceItem workspaceTarget);
        //event Action<WorkspaceItemResult<WorkspaceItem>> RegisterDraggedDataCompleted;

        void RegisterPropertyAsync(WorkspaceItemProperty workspaceItemProperty);
        event Action<WorkspaceItemResult<WorkspaceItemProperty>> RegisterPropertyCompleted;
        void RegisterDescriptionAsync(WorkspaceItemDescription workspaceItemDescription);
        event Action<WorkspaceItemResult<WorkspaceItemDescription>> RegisterDescriptionCompleted;


        void AddWorkspaceItemAync(WorkspaceItem workspace);
        void AddItemAsync(WorkspaceItem workspace);

        void DeleteWorkspaceItemsAsync(WorkspaceItem[] workspaceItems,Action<WorkspaceItemResult<WorkspaceItem>> action);

        /// <summary>
        /// Call for delete description.
        /// </summary>
        /// <param name="id">Description Id(Primary key)</param>
        /// <returns>Result</returns>
        void DeleteDescriptionAsync(string id, Action<WorkspaceItemResult<WorkspaceItemDescription>> action);
        //event Action<WorkspaceItemResult<WorkspaceItemDescription>> OnDeleteDescriptionCompleted;

        /// <summary>
        /// Get the New Folder title
        /// </summary>
        /// <returns>Folder name</returns>
        void GetFolderTitleAsync(Action<WorkspaceItemResult<WorkspaceItem>> action);

        /// <summary>
        /// Rename folder/WorkspaceItem .Pass the foldername and id of the workspace item.
        /// </summary>
        /// <param name="renameInfo">Id,Title,Datemodified</param>
        /// <returns>Result</returns>
        void RenameWorkspaceItemAsync(WorkspaceItem renameInfo, Action<WorkspaceItemResult<WorkspaceItem>> action);


        /// <summary>
        /// Call for Delete workspaceItem/Folder.Pass the selected workspaceItem Id
        /// </summary>
        /// <param name="id">WorkspaceItem Id</param>
        /// <returns>Result</returns>
        void DeleteWorkSpaceItemAsync(WorkspaceItem workspaceItem, Action<WorkspaceItemResult<WorkspaceItem>> action);

        void GetTypesAsync(Action<WorkspaceItemResult<WorkspaceItem>> action);
    }
}