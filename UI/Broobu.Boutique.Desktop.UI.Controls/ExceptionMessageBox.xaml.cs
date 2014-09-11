using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;

namespace Pms.MobiLauncher.UI.Controls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ExceptionMessageBox 
    {
        string userExceptionMessage;
        List<string> ExceptionInformationList = new List<string>();


        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionMessageBox"/> class.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <param name="userExceptionMessage">The user exception message.</param>
        public ExceptionMessageBox(Exception e, string userExceptionMessage)
        {
            InitializeComponent();

            this.userExceptionMessage = userExceptionMessage;
            txtException.Text = userExceptionMessage;

            TreeViewItem treeViewItem = new TreeViewItem();
            treeViewItem.Header = "Exception";
            treeViewItem.ExpandSubtree();
            buildTreeLayer(e, treeViewItem);
            treeView1.Items.Add(treeViewItem);            
        }

        /// <summary>
        /// Builds the tree layer.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <param name="parent">The parent.</param>
        void buildTreeLayer(Exception e, TreeViewItem parent)
        {
            String exceptionInformation = "\n\r\n\r" + e.GetType().ToString() + "\n\r\n\r";
            parent.DisplayMemberPath = "Header";
            parent.Items.Add(new TreeViewStringSet() { Header = "Type", Content = e.GetType().ToString() });
            System.Reflection.PropertyInfo[] memberList = e.GetType().GetProperties();
            foreach (PropertyInfo info in memberList)
            {
                var value = info.GetValue(e, null);
                if (value != null)
                {
                    if (info.Name == "InnerException")
                    {
                        TreeViewItem treeViewItem = new TreeViewItem();
                        treeViewItem.Header = info.Name;
                        buildTreeLayer(e.InnerException, treeViewItem);
                        parent.Items.Add(treeViewItem);
                    }
                    else 
                    {
                        TreeViewStringSet treeViewStringSet = new TreeViewStringSet() { Header = info.Name, Content = value.ToString() };
                        parent.Items.Add(treeViewStringSet);
                        exceptionInformation += treeViewStringSet.Header + "\n\r\n\r" + treeViewStringSet.Content + "\n\r\n\r";
                    }
                }
            }
            ExceptionInformationList.Add(exceptionInformation);
        }


        /// <summary>
        /// Handles the SelectedItemChanged event of the treeView1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Object&gt;"/> instance containing the event data.</param>
        private void treeView1_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue.GetType() == typeof(TreeViewItem) ) txtException.Text = "Exception";
            else txtException.Text = e.NewValue.ToString();
        }

        /// <summary>
        /// 
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

        /// <summary>
        /// Handles the Click event of the buttonClipboard control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonClipboard_Click(object sender, RoutedEventArgs e)
        {
            //This is dirty, but in this case it is allowed (Clipboard.SetText throws an exception
            // when another app is keeping the clipboard open
            try
            {
                string clipboardMessage = userExceptionMessage + "\n\r\n\r";
                foreach (string info in ExceptionInformationList) clipboardMessage += info;
                Clipboard.SetText(clipboardMessage);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
