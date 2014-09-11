// ***********************************************************************
// Assembly         : Broobu.MonitorDisco.UI.Controls
// Author           : Rafael Lefever
// Created          : 06-30-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-05-2014
// ***********************************************************************
// <copyright file="MonitorCloudView.xaml.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Broobu.Fx.UI.Addin;
using Broobu.MonitorDisco.UI.Controls.ViewModels;
using DevExpress.Xpf.Grid;


namespace Broobu.MonitorDisco.UI.Controls.Views
{
    /// <summary>
    /// Interaction logic for MonitorCloudView.xaml
    /// </summary>
     [Export(typeof(IAddInControl))]
    public partial class MonitorCloudView : IAddInControl
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="MonitorCloudView"/> class.
        /// </summary>
        public MonitorCloudView()
        {
            InitializeComponent();
            Vm.PropertyChanged += (s,e) => {
                var tableView = GrdDisco.View as TableView;
                if (tableView != null) 
                    tableView.BestFitColumns();
                GrdDisco.ExpandAllGroups();
            };
            Loaded += (s, e) => Vm.Initialize();
        }

    }
}
