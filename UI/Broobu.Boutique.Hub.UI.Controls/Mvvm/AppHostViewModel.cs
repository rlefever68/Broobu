// ***********************************************************************
// Assembly         : Broobu.Fx.UI
// Author           : Rafael Lefever
// Created          : 07-31-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-02-2014
// ***********************************************************************
// <copyright file="AppHostViewModel.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Broobu.EcoSpace.Contract.Domain.Menu;
using Broobu.Fx.UI.MVVM;
using DevExpress.Xpf.WindowsUI.Navigation;
using NLog;

namespace Broobu.Boutique.Hub.UI.Controls.Mvvm
{
    /// <summary>
    /// Class AppHostViewModel.
    /// </summary>
    public class AppHostViewModel : FxViewModelBase, INavigationAware
    {


        /// <summary>
        /// The _logger
        /// </summary>
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// The _applet URL
        /// </summary>
        private string _appletUrl;
        /// <summary>
        /// The _applet feedback
        /// </summary>
        private string _appletFeedback;

        private MenuButton _appletInfo;

        /// <summary>
        /// Gets or sets the applet URL.
        /// </summary>
        /// <value>The applet URL.</value>
        public string AppletUrl
        {
            get { return _appletUrl; }
            set { _appletUrl = value; RaisePropertyChanged("AppletUrl");}
        }

        /// <summary>
        /// Initializes the ViewModel the first time it is called.
        /// This method will be called from the View that implements the
        /// ViewModel
        /// </summary>
        /// <param name="parameters">The parameters used to initialize the ViewModel</param>
        protected override void InitializeInternal(object[] parameters)
        {
            
        }


        /// <summary>
        /// Gets or sets the applet feedback.
        /// </summary>
        /// <value>The applet feedback.</value>
        public string AppletFeedback
        {
            get { return _appletFeedback; }
            set { _appletFeedback = value; RaisePropertyChanged("AppletFeedback"); }
        }


        /// <summary>
        /// Called automatically when an end-user navigates to a View that implements the INavigationAware interface.
        /// </summary>
        /// <param name="e">A NavigationEventArgs object that contains event data.</param>
        public void NavigatedTo(NavigationEventArgs e)
        {
            var btn = (MenuButton)e.Parameter;
            if (btn != null)
            {
                AppletInfo = btn;
            }
            _logger.Info("Navigated To AppHostView");
            var s = Convert.ToString(e.Parameter).ToLower();
            _logger.Info("Parameter: '{0}'", s);
        }


        public MenuButton AppletInfo
        {
            get { return _appletInfo; }
            set { _appletInfo = value; RaisePropertyChanged("AppletInfo");}
        }

        /// <summary>
        /// Called automatically when an application attempts to navigate from a View that implements the INavigationAware interface.
        /// </summary>
        /// <param name="e">A NavigatingEventArgs object that contains event data.</param>
        public void NavigatingFrom(NavigatingEventArgs e)
        {
            _logger.Info("Navigating from AppHostView");
        }

        /// <summary>
        /// Called automatically after an application has successfully navigated from a View that implements the INavigationAware interface.
        /// </summary>
        /// <param name="e">A NavigationEventArgs object that contains event data.</param>
        public void NavigatedFrom(NavigationEventArgs e)
        {
            _logger.Info("Navigated from AppHostView");
        }
    }


}
