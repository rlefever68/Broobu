// ***********************************************************************
// Assembly         : Broobu.EcoSpace.UI.Controls
// Author           : Rafael Lefever
// Created          : 09-07-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 09-07-2014
// ***********************************************************************
// <copyright file="RoleViewModelBase.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Broobu.EcoSpace.Contract.Domain.Roles;
using Broobu.Fx.UI.MVVM;
using DevExpress.Mvvm;

namespace Broobu.EcoSpace.UI.Controls.Mvvm
{
    /// <summary>
    /// Class RoleViewModelBase.
    /// </summary>
    public abstract class RoleViewModelBase : FxViewModelBase
    {
        /// <summary>
        /// The _role
        /// </summary>
        private IRole _role;
        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>The role.</value>
        public IRole Role
        {
            get { return _role; }
            set {
                if (value == null) return;
                _role = value;
                RaisePropertyChanged("Role");
                OnRoleChanged();
            }
        }

        /// <summary>
        /// Called when [role changed].
        /// </summary>
        protected virtual void OnRoleChanged() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleViewModelBase"/> class.
        /// </summary>
        protected RoleViewModelBase()
        {
            Messenger.Default.Register<RoleMvvmMessage>(this, (x) =>
            {
                Role = x.Role;
            });
        }

    }
}
