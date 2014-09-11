// ***********************************************************************
// Assembly         : Broobu.CloudStudio.UI
// Author           : Rafael Lefever
// Created          : 12-24-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 12-24-2013
// ***********************************************************************
// <copyright file="SOAStudioWindow.xaml.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using Microsoft.Win32;
using Broobu.Fx.UI;

namespace Iris.CloudStudio.UI
{

    /// <summary>
    /// Interaction logic for SOAStudioWindow.xaml.
    /// </summary>
    public partial class SOAStudioWindow 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SOAStudioWindow"/> class.
        /// </summary>
        public SOAStudioWindow()
        {
            ApplicationHelper.EnableExceptionHandling();
            InitializeComponent();
        }



        /// <summary>
        /// Handles the Click event of the btnRun control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ActiproSoftware.Windows.Controls.Ribbon.Controls.ExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private void btnRun_Click(object sender, ActiproSoftware.Windows.Controls.Ribbon.Controls.ExecuteRoutedEventArgs e)
        {
            vwSOAStudio.Run();
        }

        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ActiproSoftware.Windows.Controls.Ribbon.Controls.ExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, ActiproSoftware.Windows.Controls.Ribbon.Controls.ExecuteRoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = "*.xamlx";
            if(Convert.ToBoolean(dlg.ShowDialog()))
            {
                Stream  s = dlg.OpenFile();

            }
        }
    }
}
