// ***********************************************************************
// Assembly         : Broobu.EcoSpace.UI.Controls
// Author           : Rafael Lefever
// Created          : 08-19-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-19-2014
// ***********************************************************************
// <copyright file="RoleDetailViewModel.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Broobu.EcoSpace.Contract.Domain.Roles;
using Broobu.Fx.UI.MVVM;
using DevExpress.Mvvm;

namespace Broobu.EcoSpace.UI.Controls.Mvvm
{
    /// <summary>
    /// Class RoleDetailViewModel.
    /// </summary>
    public class RoleDetailViewModel : RoleViewModelBase
    {
        /// <summary>
        /// Initializes the ViewModel the first time it is called.
        /// This method will be called from the View that implements the
        /// ViewModel
        /// </summary>
        /// <param name="parameters">The parameters used to initialize the ViewModel</param>
        protected override void InitializeInternal(object[] parameters) {}

    }
}
