// ***********************************************************************
// Assembly         : Broobu.Casem.UI.Wpf.Controls
// Author           : Rafael Lefever
// Created          : 06-29-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-27-2014
// ***********************************************************************
// <copyright file="ComposedObjectFragment.xaml.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Grid.TreeList;
using NLog;
using Wulka.Domain.Base;
using Wulka.Domain.Interfaces;
using Wulka.Exceptions;

namespace Broobu.Fx.UI.Fragments
{
    /// <summary>
    ///     Interaction logic for ComposedObjectFragment.xaml
    /// </summary>
    public partial class TreeFragment
    {
        // Dependency Property
        /// <summary>
        ///     The root property
        /// </summary>
        public static readonly DependencyProperty RootProperty =
            DependencyProperty.Register("Root", typeof (IComposedObject),
                typeof (TreeFragment), new FrameworkPropertyMetadata());

        /// <summary>
        ///     The show root property
        /// </summary>
        public static readonly DependencyProperty ShowRootProperty =
            DependencyProperty.Register("ShowRoot", typeof (bool),
                typeof (TreeFragment), new FrameworkPropertyMetadata(false));


        /// <summary>
        ///     The folders only property
        /// </summary>
        public static readonly DependencyProperty FoldersOnlyProperty =
            DependencyProperty.Register("FoldersOnly", typeof (bool),
                typeof (TreeFragment), new FrameworkPropertyMetadata(false));


        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof (IDomainObject),
                typeof (TreeFragment), new FrameworkPropertyMetadata());

        /// <summary>
        ///     The _logger
        /// </summary>
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private TreeListNode _currentNode;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TreeFragment" /> class.
        /// </summary>
        public TreeFragment()
        {
            InitializeComponent();
            btnAddBranch.Command = new DelegateCommand(() =>
            {
                if (SelectedItem == null) return;
                if (Root == null) return;
                var brc = Root.AddBranch();
                CurrentNode=AddNode(null, brc);
            });
            btnAddChild.Command = new DelegateCommand(() => {
                if (SelectedItem == null) return;
                if (CurrentNode == null) return;
                var chld = SelectedItem.AddChild();
                CurrentNode = AddNode(CurrentNode, chld);
            });
            btnAddFolder.Command = new DelegateCommand(() => {
                if (SelectedItem == null) return;
                if (CurrentNode == null) return;
                var fld = SelectedItem.AddFolder();
                CurrentNode = AddNode(CurrentNode, fld);
            });
            DataContextChanged += (s, e) =>
            {
                if (e.NewValue is IComposedObject)
                {
                    Root = e.NewValue as IComposedObject;
                }
            };
        }

        public IComposedObject SelectedItem
        {
            get { return (IComposedObject) GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }


        /// <summary>
        ///     Gets or sets a value indicating whether [folders only].
        /// </summary>
        /// <value><c>true</c> if [folders only]; otherwise, <c>false</c>.</value>
        public bool FoldersOnly { get; set; }


        /// <summary>
        ///     Gets or sets a value indicating whether [show root].
        /// </summary>
        /// <value><c>true</c> if [show root]; otherwise, <c>false</c>.</value>
        public bool ShowRoot
        {
            get { return (bool) GetValue(ShowRootProperty); }
            set { SetValue(ShowRootProperty, value); }
        }

        /// <summary>
        ///     Gets or sets the complexity.
        /// </summary>
        /// <value>The complexity.</value>
        public IComposedObject Root
        {
            get { return (IComposedObject) GetValue(RootProperty); }
            set
            {
                SetValue(RootProperty, value);
                TreeView.Nodes.Clear();
                BuildTree(null, value);
            }
        }

        /// <summary>
        ///     Adds the node.
        /// </summary>
        /// <param name="rootNode">The root node.</param>
        /// <param name="data">The data.</param>
        /// <returns>TreeListNode.</returns>
        private TreeListNode AddNode(TreeListNode rootNode, IDomainObject data)
        {
            var newNode = new TreeListNode(data) {Image = data.DisplayInfo.Icon};
            if (rootNode == null)
            {
                TreeView.Nodes.Add(newNode);
                return newNode;
            }
            rootNode.Nodes.Add(newNode);
            return newNode;
        }


        /// <summary>
        ///     Handles the OnNodeExpanding event of the ComposedObjectView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TreeListNodeAllowEventArgs" /> instance containing the event data.</param>
        private void ComposedObjectView_OnNodeExpanding(object sender, TreeListNodeAllowEventArgs e)
        {
            var it = (IComposedObject) e.Node.Content;
            if (it == null) return;
            if (!it.Parts.Any()) return;
            foreach (IDomainObject part in it.Parts)
            {
                AddNode(e.Node, part);
            }
            e.Allow = true;
        }


        /// <summary>
        ///     Builds the tree.
        /// </summary>
        /// <param name="rootNode">The root node.</param>
        /// <param name="data">The complexity.</param>
        private void BuildTree(TreeListNode rootNode, IDomainObject data)
        {
            if (FoldersOnly)
            {
                if (!(data is IFolder)) return;
            }
            if (!ShowRoot)
            {
                if (data is IComposedObject)
                {
                    var obj = (IComposedObject) data;
                    BuildTree(rootNode, obj.Parts);
                }
                else
                {
                    BuildTree(rootNode, new[] {data});
                }
            }
            else
            {
                BuildTree(rootNode, new[] {data});
            }
        }


        /// <summary>
        ///     Builds the tree.
        /// </summary>
        /// <param name="rootNode">The root node.</param>
        /// <param name="datas">The datas.</param>
        private void BuildTree(TreeListNode rootNode, IEnumerable<IDomainObject> datas)
        {
            if (datas == null) return;
            foreach (IDomainObject part in datas)
            {
                TreeListNode newNode = AddNode(rootNode, part);
                if (!(part is IComposedObject)) continue;
                var obj = (IComposedObject) part;
                if (obj.Parts == null) continue;
                if (!obj.Parts.Any()) continue;
                BuildTree(newNode, obj.Parts);
            }
        }

        ///// <summary>
        ///// Handles the OnCustomUnboundColumnData event of the ComposedObjectView control.
        ///// </summary>
        ///// <param name="sender">The source of the event.</param>
        ///// <param name="e">The <see cref="TreeListUnboundColumnDataEventArgs" /> instance containing the event data.</param>
        /// <summary>
        ///     Handles the OnCustomUnboundColumnData event of the TreeView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TreeListUnboundColumnDataEventArgs" /> instance containing the event data.</param>
        private void TreeView_OnCustomUnboundColumnData(object sender, TreeListUnboundColumnDataEventArgs e)
        {
            var comp = (e.Node.Content as IDomainObject);
            if (comp == null)
                return;
            if (e.IsGetData)
            {
                e.Value = comp.GetValue(e.Column.FieldName);
            }
            else
            {
                comp.SetValue(e.Column.FieldName, e.Value);
                RefreshParents(e.Node);
            }
        }

        /// <summary>
        ///     Refreshes the parents.
        /// </summary>
        /// <param name="node">The node.</param>
        private void RefreshParents(TreeListNode node)
        {
            while (true)
            {
                TreeListNode res = node.ParentNode;
                if (res == null) return;
                object c = res.Content;
                res.Content = null;
                res.Content = c;
                node = res;
            }
        }

        /// <summary>
        ///     Handles the OnImageFailed event of the Image control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ExceptionRoutedEventArgs" /> instance containing the event data.</param>
        private void Image_OnImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            _logger.Error(e.ErrorException.GetCombinedMessages());
        }


        /// <summary>
        ///     Handles the OnSelectedItemChanged event of the TreeListControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectedItemChangedEventArgs" /> instance containing the event data.</param>
        private void TreeListControl_OnSelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.NewItem is IDomainObject)) return;
            SelectedItem = e.NewItem as IComposedObject;
            Root.SelectedItem = e.NewItem as IDomainObject;
            _logger.Info("Selected Item has changed to : {0}", Root.SelectedItem.DisplayName);
            var composedObject = DataContext as IComposedObject;
            if (composedObject != null)
            {
                if (composedObject.SelectedItem == null)
                    _logger.Error("No Selected Item found for {0}", Root.SelectedItem.DisplayName);
                else
                    _logger.Info("Selected Item Property : {0}", composedObject.SelectedItem.DisplayName);
            }
            OnSelectedItemChanged(e);
        }




        private void OnNodeChanged(object sender, TreeListNodeChangedEventArgs e)
        {
            CurrentNode = e.Node;
        }

        public TreeListNode CurrentNode
        {
            get 
            { 
                return TreeView.FocusedNode; 
            }
            set { 
                _currentNode = value;
                TreeView.FocusedNode = _currentNode;
            }
        }


        /// <summary>
        ///     Occurs when [selected item changed].
        /// </summary>
        public event SelectedItemChangedEventHandler SelectedItemChanged;

        /// <summary>
        ///     Handles the <see cref="E:SelectedItemChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="SelectedItemChangedEventArgs" /> instance containing the event data.</param>
        protected virtual void OnSelectedItemChanged(SelectedItemChangedEventArgs e)
        {
            if (SelectedItemChanged != null)
                SelectedItemChanged(this, e);
        }
    }
}