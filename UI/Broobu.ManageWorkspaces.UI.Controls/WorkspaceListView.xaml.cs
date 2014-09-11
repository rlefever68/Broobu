using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Pms.Framework.UI;
using Pms.ManageWorkspaces.Contract.Domain;
using Pms.ManageWorkspaces.UI.Controls.ApplicationEventArgs;
using Pms.ManageWorkspaces.UI.Controls.ViewModel;


namespace Pms.ManageWorkspaces.UI.Controls
{
    /// <summary>
    /// Interaction logic for WorkspaceListView.xaml
    /// </summary>
    public partial class WorkspaceListView
    {

        #region Field Members

        public TextBox FolderText;
        private bool _renameflag;
        public GridViewColumn Temp;

        #endregion

        #region  Events

        /// <summary>
        /// Gets the textbox using resource.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            FolderText = ((TextBox)sender);
            var s = (Style)Resources["TextBoxstyle2"];
            FolderText.Style = s;
        }

        /// <summary>
        /// Code for losing focus while using tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            FolderText = ((TextBox)sender);
            var s = (Style)Resources["TextBoxstyle"];
            FolderText.Style = s;
            FolderText = null;
        }

        /// <summary>
        /// Code for losing focus while clicking outside the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RenameFocusChanged();
        }

        /// <summary>
        /// Code for losing focus while presing enter key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                RenameFocusChanged();
        }

        /// <summary>
        /// Deletes a Folder item.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            //DeleteWorkspaceItems();
            Vm.DeleteWorkspaceItems();
        }

        /// <summary>
        /// Renames a Folder
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Rename_Click(object sender, RoutedEventArgs e)
        {
            RenameworkspaceItem();
        }

        /// <summary>
        /// Gets the textbox (for F2-Rename)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RenameFocusChanged();
            FolderText = ((TextBox)sender);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Declares View Model
        /// </summary>
        public WorkspaceListViewViewModel Vm
        {
            get { return (WorkspaceListViewViewModel)FindResource("vm"); }
        }


        /// <summary>
        /// Gets or sets the workspace id.
        /// </summary>
        /// <value>The workspace id.</value>
        private string _workspaceId;
        public string WorkspaceId
        {
            get { return _workspaceId; }
            set
            {
                if (_workspaceId == value) return;
                _workspaceId = value;

            }
        }


        #region "Command"

        public ICommand DeleteworkspaceItems { get; set; }
        public ICommand RenameworkspaceItems { get; set; }
        public ICommand CancelRename { get; set; }

        #endregion


        #endregion

        #region  Constructor

        /// <summary>
        /// Costructor Declaration
        /// </summary>
        public WorkspaceListView()
        {
            InitializeComponent();
            InitializeCommands();

            Vm.NewFolderString = new List<string>();
            Vm.EventBroker.VisibleListOrDetails += EventBroker_VisibleListOrDetails;

            Loaded += (s, e) =>
            {
                DataContext = Vm;
                ListViewControl.View = ListViewControl.FindResource("DetailView") as ViewBase;  // Initially loads the ListView in DetailViewMode.
                ((WorkspaceListViewViewModel)DataContext).ListViewControl = ListViewControl;
            };
            
        }
        #endregion

        # region Private Methods
        /// <summary>
        /// Deletes the selected workspaceitem.
        /// </summary>
        private void DeleteWorkspaceItems()
        {
            Vm.DeleteWorkspaceItems();
        }

        /// <summary>
        /// Initializes the commands
        /// </summary>
        private void InitializeCommands()
        {
            DeleteworkspaceItems = new DelegateCommand(DeleteWorkspaceItems);
            RenameworkspaceItems = new DelegateCommand(RenameworkspaceItem);
            CancelRename = new DelegateCommand(RenameFocusChanged);

            InputBindings.Add(new InputBinding(DeleteworkspaceItems, new KeyGesture(Key.Delete)));
            InputBindings.Add(new InputBinding(RenameworkspaceItems, new KeyGesture(Key.F2)));
            InputBindings.Add(new InputBinding(CancelRename, new KeyGesture(Key.Escape)));
        }

        /// <summary>
        /// Code for losing focus and style change
        /// </summary>
        private void RenameFocusChanged()
        {
            if (!_renameflag) return;
            var s = (Style)Resources["RenameFocusChanged"];
            if (FolderText != null)
                if (FolderText.Text != "")
                {
                    //FolderText.IsReadOnly = true;
                    //FolderText.Focusable = false;
                    _renameflag = false;
                    if (Vm.RenameListItem != null) Vm.RenameListItem.ItemTitle = FolderText.Text;
                    FolderText.Style = s;
                }
                else
                {
                    // MessageBox.Show("Foldername cannot be empty",Constants.ProjectTitle,MessageBoxButton.OK);
                    FolderText.Text = Vm.RenameListItem.ItemTitle;
                    RenameFocusChanged();
                }
            //------------------------------------------------------------
        }

        /// <summary>
        /// Code to change the style while clicking rename
        /// </summary>
        private void RenameworkspaceItem()
        {
            GetSelectedEditBox();
            var s = (Style)Resources["txtstyle"];
            if (FolderText != null)
            {
                FolderText.Style = s;
                // FolderText.IsReadOnly = false;
                // FolderText.Focusable = true;
                FolderText.Focus();
                FolderText.Select(0, FolderText.Text.Length);
                Vm.RenameListItem = (WorkspaceItem)ListViewControl.SelectedItem;
            }
            _renameflag = true;
        }

        /// <summary>
        /// Assigning the viewTypes based for the Listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventBroker_VisibleListOrDetails(object sender, LoadDetailViewEventArgs e)
        {
            if ((e.CurrentViewType == LoadDetailViewEventArgs.ListviewcontrolviewTypes.ListView))
            {
                ListViewControl.View = ListViewControl.FindResource("ListView") as ViewBase;
            }
            else if (e.CurrentViewType == LoadDetailViewEventArgs.ListviewcontrolviewTypes.DetailView)
            {
                ListViewControl.View = ListViewControl.FindResource("DetailView") as ViewBase;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private  void GetSelectedEditBox()
        {
            ItemContainerGenerator generator = ListViewControl.ItemContainerGenerator;
            var selectedItem = (ListViewItem)generator.ContainerFromIndex(Vm.SelectedIndex);
            FolderText = GetDescendantByType(selectedItem, typeof(TextBox), "EditBox") as TextBox;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Visual GetDescendantByType(Visual element, Type type, string name)
        {
            if (element == null) return null;
            if (element.GetType() == type)
            {
                FrameworkElement fe = element as FrameworkElement;
                if (fe != null)
                {
                    if (fe.Name == name)
                    {
                        return fe;
                    }
                }
            }
            Visual foundElement = null;
            if (element is FrameworkElement)
                (element as FrameworkElement).ApplyTemplate();
            for (int i = 0;
                i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                Visual visual = VisualTreeHelper.GetChild(element, i) as Visual;
                foundElement = GetDescendantByType(visual, type, name);
                if (foundElement != null)
                    break;
            }
            return foundElement;
        }

        # endregion
    }
}
