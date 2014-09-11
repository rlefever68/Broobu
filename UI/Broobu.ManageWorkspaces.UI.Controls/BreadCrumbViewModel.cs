using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Pms.WorkspaceBrowser.Contract.Domain;

namespace Pms.WorkspaceBrowser.UI.Controls
{
   public class BreadCrumbViewModel :WorkspaceBrowserViewModelBase
    {

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

       public BreadCrumbViewModel()
       {
           Initialize();
           EventBroker.GetPreviousListItem += (snd, e) => PreviousListItem = e.PreviousListItem;
           EventBroker.LoadBreadCrumb += (snd, e) => CurrentListItem = e.BreadCrumbItem;
          // EventBroker.LoadWorkspaceItem += (snd, e) => Workspaceitems = e.WorkspaceItems;
           EventBroker.BreabCrumbTreeViewItem += (snd, e) => Treeviewitem = e.BreadCrumbtreeviewitem;
       }

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

       protected override void InitializeInternal(object[] parameters)
        {
            //throw new NotImplementedException();
        }


        private ObservableCollection<WorkspaceItem> _workspaceItems;
        /// <summary>
        /// Gets or sets the workspaceitems.
        /// </summary>
        /// <value>The workspaceitems.</value>
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
        /// Gets or Sets the PreviousListItem
        /// </summary>
        private List<WorkspaceItem> _perviouslistitem;
        public List<WorkspaceItem> PreviousListItem
        {
            get
            {
                return _perviouslistitem;
            }
            set
            {
                _perviouslistitem = value;
                //if (_perviouslistitem.Count > 1)
                //{
                //    CurrentListItem = _perviouslistitem[_perviouslistitem.Count - 2];
                //}
                RaisePropertyChanged(Property.PreviousListItem);
            }
        }

        private WorkspaceItem _currentListitem;
     
       public WorkspaceItem CurrentListItem
        {
            get { return _currentListitem; }
            set
            {
                _currentListitem = value;
              RaisePropertyChanged(Property.CurrentListItem);
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
                return "ROOT";
            }
           
        }

        /// <summary>
        /// Gets the image source.
        /// </summary>
        /// <value>The image source.</value>
        private BitmapImage imageSource;
        public BitmapSource ImageSource
        {
            get
            {
                if (null == this.imageSource)
                    this.imageSource = new BitmapImage(new Uri("pack://application:,,,/Pms.WorkspaceBrowser.Resources;component/Application-icons/Computer16.png"));
                return this.imageSource;
            }
        }
    }
}
