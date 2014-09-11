using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ActiproSoftware.Windows.Controls.PropertyGrid;
using DevExpress.Xpf.Grid;
using Pms.WorkspaceBrowser.Domain;

namespace Pms.WorkspaceBrowser.UI.Controls
{
    /// <summary>
    /// Interaction logic for Property.xaml
    /// </summary>
    public partial class Property : UserControl
    {

        #region "Properties"

        /// <summary>
        /// Declares View Model
        /// </summary>
        public PropertyViewModel Vm
        {
            get { return (PropertyViewModel)FindResource("vm"); }
        }

        public ObservableCollection<WorkspaceItemProperty> Line { get; set; }


        /// <summary>
        /// Gets and Sets the DataGridCollectionView Property
        /// </summary>
        private IEnumerable<WorkspaceItemProperty> _workspaceItemProperties;
        public IEnumerable<WorkspaceItemProperty> WorkspaceItemProperties
        {
            get
            {
                return _workspaceItemProperties;
            }
            set
            {
                _workspaceItemProperties = value;
                Line = GetData();
                ListViewProperty.DataSource = Line;
            }
        }
      

       #endregion

        # region "Constructor"
        
        public Property()
        {
            InitializeComponent();
        }

        # endregion

        #region "Private Methods"
        
        private ObservableCollection<WorkspaceItemProperty> GetData()
        {
            var obj = new ObservableCollection<WorkspaceItemProperty>();
            foreach (var workspaceItemDescription in WorkspaceItemProperties)
            {
                obj.Add(workspaceItemDescription);
            }
            return (obj);
        }
        private void ViewShowingEditor(object sender, ShowingEditorEventArgs e)
        {
            if (e.RowHandle == GridControl.NewItemRowHandle) return;

            if (WorkspaceItemProperties != null)
            {

                if (WorkspaceItemProperties.Count() > (ListViewProperty.View).FocusedRowData.ControllerVisibleIndex)
                {
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                }
            }

        }

        #endregion

       

    
    }
}
