using System;
using System.Collections.Generic;
using Pms.Framework.Networking.Wcf;
using System.ComponentModel;
using Pms.ManageWorkspaces.Contract.Interfaces;
using Pms.ManageWorkspaces.Contract.Domain;
using Pms.ManageWorkspaces.Contract.Result;

namespace Pms.ManageWorkspaces.Contract.Agent
{
    class WorkspaceBrowserAgent : DiscoProxy<IWorkspaceBrowserService>, IWorkspaceBrowserAgent
    {
        #region IWorkspaceBrowserAgent Members
        
        //public event Action<WorkspaceItemResult<WorkspaceItem>> GetWorkspaceCompleted;
        //public event Action<WorkspaceItemResult<WorkspaceItem>> GetFoldersCompleted;
        //public event Action<WorkspaceItemResult<WorkspaceItem>> GetFullWorkspaceItemCompleted; // just called  GetFullWorkspaceItemAsync but not implemeted
        //public event Action<WorkspaceItemResult<WorkspaceItem>> GetLanguagesCompleted;
        public event Action<WorkspaceItemResult<WorkspaceItem>> AddFolderCompleted;
        //public event Action<WorkspaceItemResult<WorkspaceItem>> GetWorkspaceItemsBySearchStringCompleted;
        //public event Action<WorkspaceItemResult<WorkspaceItem>> RegisterDraggedDataCompleted;// just called  GetFullWorkspaceItemAsync but not implemeted
        //public event Action<WorkspaceItemResult<WorkspaceItemDescription>> GetDescriptionsCompleted;
        public event Action<WorkspaceItemResult<WorkspaceItemDescription>> RegisterDescriptionCompleted;
        //public event Action<WorkspaceItemResult<WorkspaceItemProperty>> GetPropertiesCompleted;
        public event Action<WorkspaceItemResult<WorkspaceItemProperty>> RegisterPropertyCompleted;


        public void DeleteWorkspaceItemsAsync(WorkspaceItem[] workspaceItems, Action<WorkspaceItemResult<WorkspaceItem>> action)
        {
            var r = new WorkspaceItemResult<WorkspaceItem>();
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, e) =>DeleteWorkspaceItems(workspaceItems);
                wrk.RunWorkerCompleted += (s, e) => action(r);
                wrk.RunWorkerAsync();  
            }
        }

        public void GetWorkspaceItemsBySearchStringAsync(string searchString, Action<WorkspaceItemResult<WorkspaceItem>> action)
        {
            var r = new WorkspaceItemResult<WorkspaceItem>();
            using (var worker = new BackgroundWorker())
            {
                worker.DoWork += (s, e) =>
                {
                    r.Items = GetWorkspaceItemsBySearchString(searchString);
                };
                worker.RunWorkerCompleted += (s, e) => action(r);

                worker.RunWorkerAsync();
            }
        }
        public void AddFolderAsync(List<string> newFolderString)
        {
            throw new NotImplementedException();
        }
        public void GetLanguagesAsync(Action<WorkspaceItemResult<WorkspaceItem>> action)
        {
            var r = new WorkspaceItemResult<WorkspaceItem>();
            using (var worker = new BackgroundWorker())
            {
                worker.DoWork += (s, e) =>
                {
                    r.Items = GetLanguages();
                };
                worker.RunWorkerCompleted += (s, e) => action(r);
                worker.RunWorkerAsync();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workspaceId"></param>
        /// <param name="action"></param>
        public void GetWorkspaceAsync(string workspaceId, Action<WorkspaceItemResult<WorkspaceItem>> action)
        {
            var r = new WorkspaceItemResult<WorkspaceItem>();
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, e) =>
                                  {
                                      r.Items = GetWorkspace(workspaceId);
                                  };
                wrk.RunWorkerCompleted += (s, e) => action(r);
                wrk.RunWorkerAsync();
            }
        }
        /// <summary>
        /// Gets the folder aysne
        /// </summary>
        /// <param name="workspaceId"></param>
        public void GetFoldersAsync(string workspaceId, Action<WorkspaceItemResult<WorkspaceItem>> action)
        {
            var r = new WorkspaceItemResult<WorkspaceItem>();
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, e) => r.Items = GetFolders(workspaceId);
                wrk.RunWorkerCompleted += (s, e) => action(r);
                wrk.RunWorkerAsync();
            }
        }
        public void GetDescriptionsAsync(string itemId, Action<WorkspaceItemResult<WorkspaceItemDescription>> action)//[]
        {
            var r = new WorkspaceItemResult<WorkspaceItemDescription>();
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, e) => r.Descriptions = GetDescriptions(itemId);
                wrk.RunWorkerCompleted += (s, e) => action(r);
                wrk.RunWorkerAsync();
            }
        }
        public void GetPropertiesAsync(string itemId, Action<WorkspaceItemResult<WorkspaceItemProperty>> action)
        {
            var r = new WorkspaceItemResult<WorkspaceItemProperty>();
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, e) =>
                {
                    r.Properties = GetProperties(itemId);
                };
                wrk.RunWorkerCompleted += (s, e) => action(r);

                wrk.RunWorkerAsync();
            }
        }
        public void GetFullWorkspaceItemAsync(string itemId, Action<WorkspaceItemResult<WorkspaceItem>> action)
        {
            var r = new WorkspaceItemResult<WorkspaceItem>();
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, e) =>
                {
                    r.Item = GetFullWorkspaceItem(itemId);
                };
                wrk.RunWorkerCompleted += (s, e) => action(r);

                wrk.RunWorkerAsync();
            }
        }
        public void RegisterDraggedDataAsync(WorkspaceItem workspaceSource, WorkspaceItem workspaceTarget,Action<WorkspaceItemResult<WorkspaceItem>> action)
        {
            throw new NotImplementedException();
        }
        public void AddWorkspaceItemAync(WorkspaceItem workspace)
        {
            AddWorkspaceItemAync(workspace);
        }
        public void AddItemAsync(WorkspaceItem workspace)
        {
            var r = new WorkspaceItem();
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, e) =>
                {
                    r.Id = Client.RegisterWorkspace(workspace);
                };
                //wrk.RunWorkerCompleted += (s, e) =>
                //{
                //    if (RegisterWorkspaceCompleted != null)
                //        RegisterWorkspaceCompleted(res);
                //};
                wrk.RunWorkerAsync();
            }
        }
        public event Action<WorkspaceItemResult<WorkspaceItemDescription>> OnDeleteDescriptionCompleted;
        public void RegisterPropertyAsync(WorkspaceItemProperty workspaceItemProperty)
        {
            var r = new WorkspaceItemProperty();
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, e) => { r.Id = Client.RegisterProperty(workspaceItemProperty); };
                wrk.RunWorkerAsync();
            }
        }
        public void RegisterDescriptionAsync(WorkspaceItemDescription workspaceItemDescription)
        {
            var r = new WorkspaceItemDescription();
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, e) => { r.Id = Client.RegisterDescription(workspaceItemDescription); };
                wrk.RunWorkerAsync();
            }
        }

        #region  "Implemented Async with callback method"
        public void DeleteDescriptionAsync(string id, Action<WorkspaceItemResult<WorkspaceItemDescription>> action)
        {
            throw new NotImplementedException();
        }
        public void GetFolderTitleAsync(Action<WorkspaceItemResult<WorkspaceItem>> action)
        {
            //throw new NotImplementedException();
        }
        public void RenameWorkspaceItemAsync(WorkspaceItem renameInfo, Action<WorkspaceItemResult<WorkspaceItem>> action)
        {
            //throw new NotImplementedException();
        }

        

        public void DeleteWorkSpaceItemAsync(WorkspaceItem  workspaceItem, Action<WorkspaceItemResult<WorkspaceItem>> action)
        {
            var r = new WorkspaceItemResult<WorkspaceItem>();
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, e) =>DeleteWorkspaceItem(workspaceItem);
                                 
                wrk.RunWorkerCompleted += (s, e) => action(r);
                wrk.RunWorkerAsync();
            }
        }

        

        public void GetTypesAsync(Action<WorkspaceItemResult<WorkspaceItem>> action)
        {
            //var r = new WorkspaceItemResult<WorkspaceItem>();
            //using (var wrk = new BackgroundWorker())
            //{
            //    wrk.DoWork += (s, e) => GetTypes();
            //    wrk.RunWorkerAsync();
            //}
        }
        #endregion
     

        #endregion

        #region IWorkspaceBrowserService Members

        public bool Initialize()
        {
            return  Client.Initialize();
        }

        public WorkspaceItem[] GetWorkspace(string workspaceId)
        {
            return Client.GetWorkspace(workspaceId);
        }

        public WorkspaceItem GetFullWorkspaceItem(string itemId)
        {
            return Client.GetFullWorkspaceItem(itemId);
        }

        public WorkspaceItemProperty[] GetProperties(string itemId)
        {
            return Client.GetProperties(itemId);
        }

        public WorkspaceItemProperty[] GetPropertiesForTypeId(string typeId)
        {
            return Client.GetPropertiesForTypeId(typeId);
        }

        public WorkspaceItemDescription[] GetDescriptions(string itemId)
        {
            return Client.GetDescriptions(itemId);
        }

        public WorkspaceItem[] GetTypes()
        {
            return Client.GetTypes();
        }

        public WorkspaceItem[] GetLanguages()
        {
            return Client.GetLanguages();
        }

        public WorkspaceItem[] GetWorkspaceItemsBySearchString(string searchString)
        {
            return Client.GetWorkspaceItemsBySearchString(searchString);
        }

        public string RegisterDescription(WorkspaceItemDescription workspaceItemDescription)
        {
            return Client.RegisterDescription(workspaceItemDescription);
        }

        public string RegisterProperty(WorkspaceItemProperty workspaceItemProperty)
        {
            return Client.RegisterProperty(workspaceItemProperty);
        }

        public string RegisterWorkspace(WorkspaceItem workspaceItem)
        {
            return Client.RegisterWorkspace(workspaceItem);
        }

        public WorkspaceItem[] GetFolders(string workspaceId)
        {
            return Client.GetFolders(workspaceId);
        }

        public WorkspaceItem[] GetItemsForTypeId(string typeId)
        {
            return Client.GetItemsForTypeId(typeId);
        }

        public WorkspaceItem[] GetItemsForTypeIdWithProperties(string typeId)
        {
            return Client.GetItemsForTypeIdWithProperties(typeId);
        }

        public WorkspaceItemDescription[] SelectByItemIdAndCultureIdAndTypeId(string itemId, string cultureId, string typeId)
        {
            return Client.SelectByItemIdAndCultureIdAndTypeId(itemId, cultureId, typeId);
        }

        public void DeleteWorkspaceItems(WorkspaceItem[] workspaceItems)
        {
            Client.DeleteWorkspaceItems(workspaceItems);
        }

        public void DeleteWorkspaceItem(WorkspaceItem workspaceItem)
        {
            Client.DeleteWorkspaceItem(workspaceItem);
        }

        #endregion


        #region "Old Method"



        //public void GetFullWorkspaceItemAsync(string itemId)
        //{
        //    var r = new WorkspaceItemResult<WorkspaceItem>();
        //    using (var wrk = new BackgroundWorker())
        //    {
        //        wrk.DoWork += (s, e) =>
        //        {
        //            r.Item = GetFullWorkspaceItem(itemId);
        //        };
        //        wrk.RunWorkerCompleted += (s, e) =>
        //        {
        //            if (GetFullWorkspaceItemCompleted != null)
        //                GetFullWorkspaceItemCompleted(r);
        //        };
        //        wrk.RunWorkerAsync();
        //    }
        //}


        //public void GetWorkspaceAsync(string workspaceId)
        //{
        //    var r = new WorkspaceItemResult<WorkspaceItem>();
        //    using (var wrk = new BackgroundWorker())
        //    {
        //        wrk.DoWork += (s, e) =>
        //        {
        //            r.Items = GetWorkspace(workspaceId);
        //        };
        //        wrk.RunWorkerCompleted += (s, e) =>
        //        {
        //            if (GetWorkspaceCompleted != null)
        //                  GetWorkspaceCompleted(r);

        //        };
        //        wrk.RunWorkerAsync();
        //    }
        //}



        /// <summary>
        /// Gets the folders async.
        /// </summary>
        /// <param name="workspaceId">The workspace id.</param>
        //public void GetFoldersAsync(string workspaceId)
        //{
        //    var r = new WorkspaceItemResult<WorkspaceItem>();
        //    using (var wrk = new BackgroundWorker())
        //    {
        //        wrk.DoWork += (s, e) =>
        //        {
        //            r.Items = GetFolders(workspaceId);
        //        };
        //        wrk.RunWorkerCompleted += (s, e) =>
        //        {
        //            if (GetFoldersCompleted != null)
        //                GetFoldersCompleted(r);
        //        };
        //        wrk.RunWorkerAsync();
        //    }
        //}



        //public void GetDescriptionsAsync(string itemId)//[]
        //{
        //    var r = new WorkspaceItemResult<WorkspaceItemDescription>();
        //    using (var wrk = new BackgroundWorker())
        //    {
        //        wrk.DoWork += (s, e) =>
        //        {
        //            r.Descriptions = GetDescriptions(itemId);
        //        };
        //        wrk.RunWorkerCompleted += (s, e) =>
        //        {
        //            if (GetDescriptionsCompleted != null)
        //                GetDescriptionsCompleted(r);
        //        };
        //        wrk.RunWorkerAsync();
        //    }
        //}



        //public void GetPropertiesAsync(string itemId)
        //{
        //    var r = new WorkspaceItemResult<WorkspaceItemProperty>();
        //    using (var wrk = new BackgroundWorker())
        //    {
        //        wrk.DoWork += (s, e) =>
        //        {
        //            r.Properties = GetProperties(itemId);
        //        };
        //        wrk.RunWorkerCompleted += (s, e) =>
        //        {
        //            if (GetPropertiesCompleted != null)
        //                GetPropertiesCompleted(r);
        //        };
        //        wrk.RunWorkerAsync();
        //    }
        //}

        //public void GetWorkspaceItemsBySearchStringAsync(string searchString)
        //{
        //    var r = new WorkspaceItemResult<WorkspaceItem>();
        //    using (var worker = new BackgroundWorker())
        //    {
        //        worker.DoWork += (s, e) =>
        //        {
        //            r.Items = GetWorkspaceItemsBySearchString(searchString);
        //        };
        //        worker.RunWorkerCompleted += (s, e) =>
        //        {
        //            if (GetWorkspaceItemsBySearchStringCompleted != null)
        //                GetWorkspaceItemsBySearchStringCompleted(r);
        //        };
        //        worker.RunWorkerAsync();
        //    }
        //}

        //public void GetLanguagesAsync()
        //{
        //    var r = new WorkspaceItemResult<WorkspaceItem>();
        //    using (var worker = new BackgroundWorker())
        //    {
        //        worker.DoWork += (s, e) =>
        //        {
        //            r.Items = GetLanguages();
        //        };
        //        worker.RunWorkerCompleted += (s, e) =>
        //        {
        //            if (GetLanguagesCompleted != null)
        //                GetLanguagesCompleted(r);
        //        };
        //        worker.RunWorkerAsync();
        //    }
        //}

        #endregion
    }
}
