using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using DevExpress.Xpf.Grid;
using Pms.WorkspaceBrowser.Domain;

namespace Pms.WorkspaceBrowser.UI.Controls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Description : UserControl
    {
        #region "Properties"

        /// <summary>
        /// Declares View Model
        /// </summary>
        public DescriptionViewModel Vm
        {
            get { return (DescriptionViewModel)FindResource("vm"); }
        }

        public ObservableCollection<WorkspaceItemDescription> Line { get; set; }


        /// <summary>
        /// Gets and Sets the Description data
        /// </summary>
        private IEnumerable<WorkspaceItemDescription> _descriptionlistItem;
        public IEnumerable<WorkspaceItemDescription> DescriptionListItem
        {
            get
            {
                return _descriptionlistItem;
            }
            set
            {
                _descriptionlistItem = value;
                Line = GetData();
                grdOverview.DataSource = Line;    
            }
        }
        #endregion

        #region "Constructor"

        public Description()
        {
            InitializeComponent();
        }

        #endregion

        #region "Event Handler"


        private ObservableCollection<WorkspaceItemDescription> GetData()
        {
            
           var obj = new ObservableCollection<WorkspaceItemDescription>(DescriptionListItem.ToList());
            return (obj);
        }

        #endregion


        private void PopupImageEditSettings_ConvertEditValue(DependencyObject sender, DevExpress.Xpf.Editors.ConvertEditValueEventArgs e)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                if (e.ImageSource != null)
                {
                    encoder.Frames.Add(BitmapFrame.Create((BitmapSource)e.ImageSource));
                    encoder.Save(stream);
                    e.EditValue = stream.ToArray();
                    e.Handled = true;
                }
            }

        }

        private void DeleteFocusedRow_Click(object sender, RoutedEventArgs e)
        {
            if (DescriptionListItem != null)
            {
                foreach (
                    var poiInf in
                        DescriptionListItem.Cast<object>().Where(
                            poiInf => (grdOverview.View.FocusedRow) == ((WorkspaceItemDescription) (poiInf))))
                {
                    grdOverview.Columns["Delete"].IsEnabled = false;
                    break;
                }
            }
            if (grdOverview.Columns["Delete"].IsEnabled == true)
            {
                var result = MessageBox.Show("Do you really want to Delete?", "Delete Description",
                                             MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        if (DescriptionListItem.Count() <= (grdOverview.View).FocusedRowData.ControllerVisibleIndex)
                        {
                            view.DeleteRow(
                                Convert.ToInt32((grdOverview.View).FocusedRowData.ControllerVisibleIndex.ToString()));
                        }
                        else
                        {
                            MessageBox.Show("Can't Be deleted");
                        }
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            grdOverview.Columns["Delete"].IsEnabled = true;
        }

        private void ViewShowingEditor(object sender, ShowingEditorEventArgs e)
        {
            if (e.RowHandle == GridControl.NewItemRowHandle) return;

            if (DescriptionListItem != null)
            {
                foreach (
                    var poiInf in
                        DescriptionListItem.Cast<object>().Where(
                            poiInf => (grdOverview.View.FocusedRow) == ((WorkspaceItemDescription) (poiInf))))
                {
                    e.Cancel = true;
                    break;
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        private ObservableCollection<WorkspaceItemDescription> _savedItemDesc;
        public ObservableCollection<WorkspaceItemDescription> SavedItemDesc
        {
            get
            {
                return _savedItemDesc;
            }
            set
            {
                _savedItemDesc = value;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSaveDescClick(object sender, RoutedEventArgs e)
        {
            SavedItemDesc = new ObservableCollection<WorkspaceItemDescription>();
            //condition added for new item by SP on 23Dec2010
            if (DescriptionListItem != null)
            {

                for (int i = 1; i <= grdOverview.VisibleRowCount; i++)
                {
                    if (i > DescriptionListItem.Count())
                    {
                        SavedItemDesc.Add(grdOverview.GetRowByListIndex(i - 1) as WorkspaceItemDescription);
                    }
                }
                Vm.SavedItemDesc = SavedItemDesc;
            }
        }
        
        private void GrdOverviewColumnsPopulated(object sender, RoutedEventArgs e)
        {
            if (grdOverview.VisibleRowCount <= 0)
            {
                LanguageCombobox.ItemsSource = Vm.AllLanguages;
                TypeCombobox.ItemsSource = Vm.AllLanguages;
            }
        }

     
    


    }
}
