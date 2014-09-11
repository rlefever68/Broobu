using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Pms.Framework.UI;
using Pms.ManageWorkspaces.Contract.Domain;
using Pms.ManageWorkspaces.UI.Controls.ApplicationEventArgs;

namespace Pms.ManageWorkspaces.UI.Controls.ViewModel
{
    public class PopUpListViewModel : WorkspaceBrowserViewModelBase
    {

        #region "Class"

        /// <summary>
        /// Declare the constants
        /// </summary>
        private new class Property
        {
            public const string ListItem = "ListItem";
            public const string SelectedItem = "SelectedItem";
        }
        #endregion

        #region"Constructor"
        
        public PopUpListViewModel()
        {
            _doubleClickCommand = new DelegateCommand(GetWorkspaceAsyncItem);
        }
        #endregion

        #region "Private Methods"
       
        /// <summary>
        /// Calls the Asynchronous method to get Workspace Item  
        /// </summary>
        private void GetWorkspaceAsyncItem()
        {
            EventBroker.RaiseDoubleClickListView(new LoadWorkspaceItemEventArgs { ItemId = SelectedItem.Id });
            EventBroker.RaiseApplicationName(new LoadWorkspaceItemEventArgs { ApplicationName = Constants.ViewNames.PopuUpListView });
           // EventBroker.RaiseLoadIsRefresh(new LoadDetailViewEventArgs { IsRefresh = true });
        }
        #endregion

        #region "Property"
        
        /// <summary>
        /// Gets and Sets Selected ListItem
        /// </summary>
        private WorkspaceItem _selectedItem;
        public WorkspaceItem SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                RaisePropertyChanged(Property.SelectedItem);
            }
        }
    

        /// <summary>
        /// Gets and Sets ListItem Data
        /// </summary>
        private IEnumerable<WorkspaceItem> _listItem;
        public IEnumerable<WorkspaceItem> ListItem
        {
            get
            {
                return _listItem;
            }
            set
            {
                _listItem = value;
                CheckAndPutImage();
                RaisePropertyChanged(Property.ListItem);
            }
        }

        private void CheckAndPutImage()
        {
            if (_listItem == null) return;
            foreach (var item in _listItem.Where(item => item.ItemImage == null || item.ItemImage.Length == 0))
                item.ItemImage = GetLocalItemImageForBreadCrumb();
        }

        /// <summary>
        /// A Method that will be called when no item image is found
        /// </summary>
        /// <returns>A Byte array that contains Image data</returns>
        private static byte[] GetLocalItemImageForBreadCrumb()
        {
            var bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.UriSource =
                new Uri(
                    "pack://application:,,,/Pms.ManageWorkspaces.Resources;component/Application-icons/CloseFolder.png",
                    UriKind.RelativeOrAbsolute);
            bmp.EndInit();
            MemoryStream memStream = null;
            try
            {
                memStream = new MemoryStream();
                var encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bmp));
                encoder.Save(memStream);
                return memStream.GetBuffer();
            }
            finally
            {
                if (memStream != null) memStream.Close();
            }
        }

        /// <summary>
        /// Gets the Listview DoubleClickCommand 
        /// </summary> 
        private readonly ICommand _doubleClickCommand;
        public ICommand DoubleClickCommand
        {
            get
            {
                return _doubleClickCommand;
            }
        }

        #endregion

        # region Protected Methods
        protected override void InitializeInternal(object[] parameters)
        {

        }
        #endregion

        protected override void StartAuthenticatedSession()
        {
            //throw new NotImplementedException();
        }

        public override void TerminateAuthenticatedSession(Action onSessionTerminated = null)
        {
            throw new NotImplementedException();
        }
    }
}

