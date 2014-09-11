using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Broobu.Fx.UI.Views
{
    /// <summary>
    ///     Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ExceptionView
    {
        public static string ID = "ExceptionView";
        private readonly List<string> _exceptionInformationList = new List<string>();
        private readonly string userExceptionMessage;


        /// <summary>
        ///     Initializes a new instance of the <see cref="ExceptionView" /> class.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <param name="userExceptionMessage">The user exception message.</param>
        public ExceptionView()
        {
            InitializeComponent();
            ExceptionGrid.DataContextChanged += (s, e) =>
            {
                var ex = e.NewValue as Exception;
                if (ex == null) return;
                TxtException.Text = ex.Message;
                var treeViewItem = new TreeViewItem {Header = "Exception"};
                treeViewItem.ExpandSubtree();
                BuildTreeLayer(ex, treeViewItem);
                TreeView1.Items.Add(treeViewItem);
            };
        }

        /// <summary>
        ///     Builds the tree layer.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <param name="parent">The parent.</param>
        private void BuildTreeLayer(Exception e, TreeViewItem parent)
        {
            String exceptionInformation = "\n\r\n\r" + e.GetType() + "\n\r\n\r";
            parent.DisplayMemberPath = "Header";
            parent.Items.Add(new TreeViewStringSet {Header = "Type", Content = e.GetType().ToString()});
            PropertyInfo[] memberList = e.GetType().GetProperties();
            foreach (PropertyInfo info in memberList)
            {
                object value = info.GetValue(e, null);
                if (value != null)
                {
                    if (info.Name == "InnerException")
                    {
                        var treeViewItem = new TreeViewItem {Header = info.Name};
                        BuildTreeLayer(e.InnerException, treeViewItem);
                        parent.Items.Add(treeViewItem);
                    }
                    else
                    {
                        var treeViewStringSet = new TreeViewStringSet {Header = info.Name, Content = value.ToString()};
                        parent.Items.Add(treeViewStringSet);
                        exceptionInformation += treeViewStringSet.Header + "\n\r\n\r" + treeViewStringSet.Content +
                                                "\n\r\n\r";
                    }
                }
            }
            _exceptionInformationList.Add(exceptionInformation);
        }


        /// <summary>
        ///     Handles the SelectedItemChanged event of the treeView1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">
        ///     The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Object&gt;" /> instance
        ///     containing the event data.
        /// </param>
        private void treeView1_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TxtException.Text = e.NewValue.GetType() == typeof (TreeViewItem)
                ? "Exception"
                : e.NewValue.ToString();
        }

        /// <summary>
        ///     Handles the Click event of the buttonClipboard control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs" /> instance containing the event data.</param>
        private void buttonClipboard_Click(object sender, RoutedEventArgs e)
        {
            //This is dirty, but in this case it is allowed (Clipboard.SetText throws an exception
            // when another app is keeping the clipboard open
            try
            {
                string clipboardMessage = userExceptionMessage + "\n\r\n\r";
                clipboardMessage = _exceptionInformationList.Aggregate(clipboardMessage,
                    (current, info) => current + info);
                Clipboard.SetText(clipboardMessage);
            }
            catch
            {
            }
        }


        /// <summary>
        /// </summary>
        private class TreeViewStringSet
        {
            public string Header { get; set; }
            public string Content { get; set; }

            public override string ToString()
            {
                return Content;
            }
        }
    }
}