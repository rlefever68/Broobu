using System.Collections.ObjectModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using DevExpress.Xpf.Editors;
using Pms.ManageWorkspaces.Contract.Domain;
using Pms.ManageWorkspaces.UI.Controls.ApplicationEventArgs;
using Pms.ManageWorkspaces.UI.Controls.ViewModel;

namespace Pms.ManageWorkspaces.UI.Controls
{
    /// <summary>
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem
    {

        #region  Constructor

        /// <summary>
        /// Constructor Declaration
        /// </summary>
        public AddItem()
        {
            InitializeComponent();
            EditorLocalizer.Active = new AddItemViewModel.CustomEditorLocalizer();
            grdWorkspaceDescriptions.ItemsSource = new ObservableCollection<WorkspaceItemDescription>();
            ListViewProperty.ItemsSource = new ObservableCollection<WorkspaceItemProperty>();
        }

       
        #endregion

        #region "Public Method"

        public void Initialize(AddItemViewModel vm)
        {
            DataContext = vm;
            vm.EventBroker.ApplicationName += EventBroker_ApplicationName;
            switch (vm.ApplicationName)
            {
                case Constants.ViewNames.ModifyDesc:
                    vm.Line = vm.GetData();
                    grdWorkspaceDescriptions.ItemsSource = vm.Line;
                    break;
                case Constants.ViewNames.ModifyProperty:
                    vm.ListViewProperty = vm.GetDataProperty();
                    ListViewProperty.ItemsSource = vm.ListViewProperty;
                    break;
                case Constants.ViewNames.ModifyItem:
                    vm.Line = vm.GetData();
                    vm.ListViewProperty = vm.GetDataProperty();
                    grdWorkspaceDescriptions.ItemsSource = vm.Line;
                    ListViewProperty.ItemsSource = vm.ListViewProperty;
                    break;
            }


            if (grdWorkspaceDescriptions != null)
            {
                DataContext = vm;
                ((AddItemViewModel)DataContext).GrdWorkspaceDescriptions = grdWorkspaceDescriptions;
                ((AddItemViewModel)DataContext).Addimage = addimage;
                vm.HandleWorkSapceDescriptionEvents();
            }
            if (ListViewProperty != null)
            {
                DataContext = vm;
                ((AddItemViewModel)DataContext).GrdListViewProperty = ListViewProperty;
                ((AddItemViewModel)DataContext).Addimage = addimage;
                vm.HandleWorkspacePropertyEvents();
            }
        }

        #endregion

        # region Private Methods
        

        /// <summary>
        /// Converting the Image 
        /// </summary>
        /// <param name="sender">grdWorkspaceDescriptions Grid</param>
        /// <param name="e">Image</param>
        private void PopupImageEditSettings_ConvertEditValue(DependencyObject sender, ConvertEditValueEventArgs e)
        {
            using (var stream = new MemoryStream())
            {
                var encoder = new JpegBitmapEncoder();
                if (e.ImageSource != null)
                {
                    encoder.Frames.Add(BitmapFrame.Create((BitmapSource)e.ImageSource));
                    encoder.Save(stream);
                    e.EditValue = stream.ToArray();
                    e.Handled = true;
                }
            }
        }
        
        /// <summary>
        /// Handle the keydown event.
        /// </summary>
        /// <param name="sender">Textbox orderofitem(txtOI)</param>
        /// <param name="e">KeyEventArgs</param>
        private void TxtOrderofItemKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.OemMinus || e.Key == Key.Subtract) && txtOrderofItem.Text.Trim().Length == 0) return;
            switch (e.Key)
            {
                case Key.Back:
                    return;
                case Key.Delete:
                    return;
                case Key.Left:
                    return;
                case Key.Right:
                    return;
                case Key.Home:
                    return;
                case Key.End:
                    return;
            }

            if (txtOrderofItem.Text.Trim() != string.Empty)
                if (txtOrderofItem.Text.Trim().IndexOf('-') == 0 && (e.Key == Key.OemMinus || e.Key == Key.Subtract))
                {
                    e.Handled = true;
                }
            if (IsAlphaPattern(e.Key.ToString()))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Check the given input is numeric.
        /// </summary>
        /// <param name="strTextEntry">Textbox input</param>
        /// <returns>True or False</returns>
        public bool IsAlphaPattern(string strTextEntry)
        {
            var objAlphaPattern = new Regex("[^a-zA-Z]");
            return !objAlphaPattern.IsMatch(strTextEntry);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventBroker_ApplicationName(object sender, LoadWorkspaceItemEventArgs e)
        {
            if (e.ApplicationName != Constants.ViewNames.DescriptionWindow) return;
            Close();
        }

        /// <summary>
        /// Called for when click the cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">RoutedEventArgs</param>
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Occurs when close the window.
        /// </summary>
        /// <param name="sender">Additem window</param>
        /// <param name="e">CancelEventArgs</param>
        private void RibbonWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (tabctrl.SelectedIndex == 1)
                grdWorkspaceDescriptions.View.CancelRowEdit();
            else
                ListViewProperty.View.CancelRowEdit();
        }

        #endregion
    }


}