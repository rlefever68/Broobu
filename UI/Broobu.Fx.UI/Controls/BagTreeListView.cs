using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Broobu.Fx.UI.Fragments;
using DevExpress.Xpf.Grid;
using NLog;
using Wulka.Domain.Interfaces;

namespace Broobu.Fx.UI.Controls
{
    /// <summary>
    ///     Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///     Step 1a) Using this custom control in a XAML file that exists in the current project.
    ///     Add this XmlNamespace attribute to the root element of the markup file where it is
    ///     to be used:
    ///     xmlns:MyNamespace="clr-namespace:Broobu.Fx.UI.Controls"
    ///     Step 1b) Using this custom control in a XAML file that exists in a different project.
    ///     Add this XmlNamespace attribute to the root element of the markup file where it is
    ///     to be used:
    ///     xmlns:MyNamespace="clr-namespace:Broobu.Fx.UI.Controls;assembly=Broobu.Fx.UI.Controls"
    ///     You will also need to add a project reference from the project where the XAML file lives
    ///     to this project and Rebuild to avoid compilation errors:
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///     Step 2)
    ///     Go ahead and use your control in the XAML file.
    ///     <MyNamespace:BagTreeListView />
    /// </summary>
    public class BagTreeListView : TreeListView
    {
        // Dependency Property
        /// <summary>
        ///     The root property
        /// </summary>
        public static readonly DependencyProperty RootProperty =
            DependencyProperty.Register("Root", typeof (IComposedObject),
                typeof (BagTreeListView), new FrameworkPropertyMetadata());

        /// <summary>
        ///     The show root property
        /// </summary>
        public static readonly DependencyProperty ShowRootProperty =
            DependencyProperty.Register("ShowRoot", typeof (bool),
                typeof (BagTreeListView), new FrameworkPropertyMetadata(false));


        /// <summary>
        ///     The current item property
        /// </summary>
        public static readonly DependencyProperty CurrentItemProperty =
            DependencyProperty.Register("CurrentItem", typeof (IDomainObject),
                typeof (BagTreeListView), new FrameworkPropertyMetadata());

        /// <summary>
        ///     The folders only property
        /// </summary>
        public static readonly DependencyProperty FoldersOnlyProperty =
            DependencyProperty.Register("FoldersOnly", typeof (bool),
                typeof (BagTreeListView), new FrameworkPropertyMetadata(false));

        /// <summary>
        ///     The _logger
        /// </summary>
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        static BagTreeListView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (BagTreeListView),
                new FrameworkPropertyMetadata(typeof (BagTreeListView)));
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="TreeFragment" /> class.
        /// </summary>
        public BagTreeListView()
        {
            DataContextChanged += (s, e) =>
            {
                if (e.NewValue is IComposedObject)
                {
                    Root = e.NewValue as IComposedObject;
                }
            };
            NodeExpanding += (s, e) =>
            {
                var it = (IComposedObject) e.Node.Content;
                if (it == null) return;
                if (!it.Parts.Any()) return;
                foreach (var part in it.Parts)
                {
                    AddNode(e.Node, part);
                }
                e.Allow = true;
            };
            CustomUnboundColumnData += (s, e) =>
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
            };
        }


        /// <summary>
        ///     Gets or sets a value indicating whether [folders only].
        /// </summary>
        /// <value><c>true</c> if [folders only]; otherwise, <c>false</c>.</value>
        public bool FoldersOnly { get; set; }

        /// <summary>
        ///     Gets or sets the current item.
        /// </summary>
        /// <value>The current item.</value>
        public IDomainObject CurrentItem { get; set; }


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
                Nodes.Clear();
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
                Nodes.Add(newNode);
                return newNode;
            }
            rootNode.Nodes.Add(newNode);
            return newNode;
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
            foreach (var part in datas)
            {
                TreeListNode newNode = AddNode(rootNode, part);
                if (!(part is IComposedObject)) continue;
                var obj = (IComposedObject) part;
                if (obj.Parts == null) continue;
                if (!obj.Parts.Any()) continue;
                BuildTree(newNode, obj.Parts);
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
    }
}