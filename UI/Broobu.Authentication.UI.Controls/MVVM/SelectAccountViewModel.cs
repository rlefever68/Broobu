// ***********************************************************************
// Assembly         : Broobu.Authentication.UI.Controls
// Author           : Rafael Lefever
// Created          : 08-14-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-14-2014
// ***********************************************************************
// <copyright file="SelectAccountViewModel.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using Broobu.Authentication.Contract;
using Broobu.Authentication.Contract.Domain;
using Broobu.Fx.UI.MVVM;

namespace Broobu.Authentication.UI.Controls.MVVM
{
    /// <summary>
    ///     Class SelectAccountViewModel.
    /// </summary>
    public class SelectAccountViewModel : FxViewModelBase
    {
        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; RaisePropertyChanged("SearchText"); }
        }


        private IEnumerable<IAccount> _accounts;
        private string _searchText;

        /// <summary>
        ///     Gets or sets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        public IEnumerable<IAccount> Accounts
        {
            get { return _accounts; }
            set
            {
                _accounts = value;
                RaisePropertyChanged("Accounts");
            }
        }

        /// <summary>
        ///     Initializes the ViewModel the first time it is called.
        ///     This method will be called from the View that implements the
        ///     ViewModel
        /// </summary>
        /// <param name="parameters">The parameters used to initialize the ViewModel</param>
        protected override void InitializeInternal(object[] parameters)
        {
            GetAccounts();
        }

        /// <summary>
        ///     Gets the accounts.
        /// </summary>
        private void GetAccounts()
        {
            AuthenticationPortal
                .Accounts
                .GetAccountsAsync((x) => { Accounts = x; });
        }
    }
}