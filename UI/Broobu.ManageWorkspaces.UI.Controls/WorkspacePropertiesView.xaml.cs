using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using ActiproSoftware.Windows.Controls.PropertyGrid;
using ActiproSoftware.Windows.Controls.PropertyGrid.Primitives;
using Pms.ManageWorkspaces.Contract.Domain;
using Pms.ManageWorkspaces.UI.Controls.ViewModel;


namespace Pms.ManageWorkspaces.UI.Controls
{
    /// <summary>
    /// Interaction logic for WorkspaceProperties.xaml
    /// </summary>
    public partial class WorkspaceProperties
    {
        #region Class / Fields / Members
        /// <summary>
        /// Class Property Declaration
        /// </summary>
        public new class Property
        {
            public const string WorkspaceItemProperties = "WorkspaceItemProperties";
        }
        #endregion

        #region Properties

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
                BindProperty();
            }
        }

        /// <summary>
        /// Dependency Property for WorkspaceItems. 
        /// </summary>
        public static readonly DependencyProperty WorkspaceItemProperty =
            DependencyProperty.Register(Property.WorkspaceItemProperties, typeof(IEnumerable<WorkspaceItemProperty>), typeof(WorkspaceProperties), new PropertyMetadata((o, e) =>
            {
                ((WorkspaceProperties)o).WorkspaceItemProperties = (IEnumerable<WorkspaceItemProperty>)e.NewValue;

            }));

        /// <summary>
        /// Declares View Model
        /// </summary>
        public WorkspacePropertiesViewViewModel Vm
        {
            get { return (WorkspacePropertiesViewViewModel)FindResource("vm"); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor declaration
        /// </summary>
        public WorkspaceProperties()
        {
            InitializeComponent();
            ListViewProperty.Columns[0].Width = new GridLength(6, GridUnitType.Star);
            ListViewProperty.Columns[1].Width = new GridLength(4, GridUnitType.Star);
            PropertyMenu.Click += (snd, e) => Vm.ShowAddPropertyPopUp.Execute(null);
        }
        #endregion

        # region Private Methods
        /// <summary>
        /// Dynamic binding property item in to Property View 
        /// </summary>
        private void BindProperty()
        {
            try
            {

                ListViewProperty.Properties.Clear();

              
                if (WorkspaceItemProperties != null)
                    foreach (var poiproperty in WorkspaceItemProperties)
                    {
                        
                        var items = new PropertyGridPropertyItem
                                        {
                                            Value = poiproperty.PropertyValue,
                                            DisplayName = poiproperty.PropertyName,
                                            Category = "General Properties"
                                        };

                        ListViewProperty.Properties.Add(items);
                    }

              
               
                 
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButton.OK);
            }

        }

        # endregion

    }
}
