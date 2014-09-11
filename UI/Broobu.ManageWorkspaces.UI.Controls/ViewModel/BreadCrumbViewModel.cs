using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Pms.ManageWorkspaces.Contract.Domain;
using Pms.ManageWorkspaces.Resources;

namespace Pms.ManageWorkspaces.UI.Controls.ViewModel
{
   public class BreadCrumbViewModel :WorkspaceBrowserViewModelBase
    {

        #region Class

        /// <summary>
        /// Declare the constants
        /// </summary>
        public new class Property
        {
            public const string PreviousListItem = "PreviousListItem";
            public const String Workspaceitems = "Workspaceitems";
            public const string CurrentListItem = "CurrentListItem";
            public const string Treeviewitem = "CurrentListItem";
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor Declaration
        /// </summary>
        public BreadCrumbViewModel()
        {
            Initialize();
            EventBroker.LoadWorkspaceItem += (snd, e) => Workspaceitems = e.WorkspaceItems;
            EventBroker.BreabCrumbTreeViewItem += (snd, e) => Treeviewitem = e.BreadCrumbtreeviewitem;
        }

        #endregion

        #region Protected Method

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="parameters"></param>
        protected override void InitializeInternal(object[] parameters){}

        #endregion

        #region Properties
        /// <summary>
        /// Gets or Sets the Treeviewitem
        /// </summary>
        private TreeViewItem _treeviewitem;
        public TreeViewItem Treeviewitem
        {
            get { return _treeviewitem; }
            set
            {
                _treeviewitem = value;
                RaisePropertyChanged(Property.Treeviewitem);
            }
        }

        /// <summary>
        /// Gets or sets the workspaceitems.
        /// </summary>
        /// <value>The workspaceitems.</value>
        private ObservableCollection<WorkspaceItem> _workspaceItems;
        public ObservableCollection<WorkspaceItem> Workspaceitems
        {
            get
            {
                return _workspaceItems;
            }
            set
            {
                _workspaceItems = value;
                RaisePropertyChanged(Property.Workspaceitems);
            }
        }

        /// <summary>
        /// Gets the item title.
        /// </summary>
        /// <value>The item title.</value>
        public string ItemTitle
        {
            get
            {
                return Constants.Root;
            }
        }

       /// <summary>
        /// Gets the root image source.
        /// </summary>
        /// <value>The image source.</value>
        private BitmapImage _imageSource;
        public BitmapSource ImageSource
        {
            get
            {
                return _imageSource ??
                       (_imageSource =
                        new BitmapImage(
                            new Uri(
                                "pack://application:,,,/Pms.ManageWorkspaces.Resources;component/Application-icons/Computer16.png")));
            }
        }

        #endregion

        #region Public Methods

   
        #endregion



        #region "Unused Methods"
        /// <summary>
        /// Loads the ListItem
        /// </summary>
        /// <param name="listitem">The Name of listitem</param>
        /// <returns>List of WorkspaceItem</returns>
        //public IEnumerable<WorkspaceItem> LoadListItem(IEnumerable<WorkspaceItem> listitem)
        //{
        //    var list = listitem;
        //    var data = new ObservableCollection<WorkspaceItem>();
        //    foreach (var item in list)
        //    {
        //        var info = new WorkspaceItem
        //        {
        //            AdditionalInfoUri = item.AdditionalInfoUri,
        //            Children = item.Children,
        //            DateModified = item.DateModified,
        //            Descriptions = item.Descriptions,
        //            Id = item.Id,
        //            IsFolder = item.IsFolder,
        //            ItemId = item.ItemId,
        //            ItemImage = item.ItemImage,
        //            ItemTitle = item.ItemTitle,
        //            ParentId = item.ParentId,
        //            Properties = item.Properties,
        //            SortOrder = item.SortOrder,
        //            TypeId = item.TypeId,
        //            TypeImage = item.TypeImage,
        //            TypeTitle = item.TypeTitle
        //        };

        //       info.ItemImage = item.IsFolder || item.ItemImage == null
        //                             ? Constants.GetEmbeddedFile("Pms.ManageWorkspaces.Resources", "CloseFolder.png")
        //      //                     : item.ItemImage;

        //        data.Add(info);
        //    }

        //    return data;
        //}

        #endregion
        protected override void StartAuthenticatedSession()
        {
            throw new NotImplementedException();
        }

        public override void TerminateAuthenticatedSession(Action onSessionTerminated = null)
        {
            throw new NotImplementedException();
        }
    }
}
