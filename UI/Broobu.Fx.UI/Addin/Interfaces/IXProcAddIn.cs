// ***********************************************************************
// Assembly         : Broobu.Fx.UI
// Author           : Rafael Lefever
// Created          : 07-31-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-01-2014
// ***********************************************************************
// <copyright file="IXProcAddIn.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Windows.Input;

namespace Broobu.Fx.UI.Addin.Interfaces
{
    /// <summary>
    ///     Interface IXProcAddIn
    /// </summary>
    public interface IXProcAddIn
    {
        /// <summary>
        ///     Gets or sets the site.
        /// </summary>
        /// <value>The site.</value>
        IXProcAddInSite Site { get; set; }

        /// <summary>
        ///     Gets the add in window.
        /// </summary>
        /// <value>The add in window.</value>
        IntPtr AddInWindow { get; }

        /// <summary>
        ///     Called when [add in attached].
        /// </summary>
        void OnAddInAttached();

        /// <summary>
        ///     Tabs the into.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool TabInto(TraversalRequest request);

        /// <summary>
        ///     Shuts down.
        /// </summary>
        void ShutDown();
    };
}