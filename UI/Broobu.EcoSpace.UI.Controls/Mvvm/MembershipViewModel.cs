// ***********************************************************************
// Assembly         : Broobu.EcoSpace.UI.Controls
// Author           : Rafael Lefever
// Created          : 08-19-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-19-2014
// ***********************************************************************
// <copyright file="MembershipViewModel.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Broobu.Authentication.Contract.Domain;
using Broobu.EcoSpace.Contract;
using Broobu.EcoSpace.Contract.Domain.Links;

namespace Broobu.EcoSpace.UI.Controls.Mvvm
{
    /// <summary>
    /// Class MembershipViewModel.
    /// </summary>
    public class MembershipViewModel : RoleViewModelBase
    {

        private IList _droppedItems;
        private IEnumerable<IRoleMembership> _memberships;

        /// <summary>
        /// Initializes a new instance of the <see cref="MembershipViewModel"/> class.
        /// </summary>
        public MembershipViewModel()
        {
            IsEmpty = false;
        }

        protected override void OnRoleChanged()
        {
            RefreshMemberships();
        }


        public IList DroppedItems
        {
            get { return _droppedItems; }
            set 
            {
                if (Role == null) return;
                _droppedItems = value;
                if (_droppedItems == null) return;
                IsBusy = true;
                foreach (var acc in _droppedItems.Cast<IAccount>().Where(acc => acc != null))
                {
                    EcoSpacePortal
                        .EcoSpace
                        .RegisterRoleMembershipAsync(Role, acc.Id, m => RefreshMemberships());
                }
            }
        }


        /// <summary>
        /// Gets or sets the role memberships.
        /// </summary>
        /// <value>The role memberships.</value>
        public IEnumerable<IRoleMembership> Memberships
        {
            get { return _memberships; }
            set 
            {
                if (value == null) return;
                _memberships = value;
                RaisePropertyChanged("Memberships"); 
            }
        }

        /// <summary>
        /// Refreshes the memberships.
        /// </summary>
        /// <param name="role">The role.</param>
        private void RefreshMemberships()
        {

            Memberships = new IRoleMembership[] { };
            IsBusy      = true;
            if (Role    == null) return;
            EcoSpacePortal
                .EcoSpace
                .GetRoleMembershipsAsync(Role, (x) => 
                {
                    IsBusy = false;
                    Memberships = x; 
                });
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

    }
}
