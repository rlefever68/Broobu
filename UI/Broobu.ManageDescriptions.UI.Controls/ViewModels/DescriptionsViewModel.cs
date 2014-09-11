// ***********************************************************************
// Assembly         : Broobu.Taxonomy.UI.Controls
// Author           : Rafael Lefever
// Created          : 04-22-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 05-01-2014
// ***********************************************************************
// <copyright file="DescriptionsViewModel.cs" company="Insoft Pvt.Ltd.">
//     Copyright (c) Insoft Pvt.Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Broobu.Fx.UI.MVVM;
using Broobu.Taxonomy.Contract.Domain;
using Broobu.Taxonomy.Contract.Interfaces;
using DevExpress.Xpf.Core.DataSources;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;


namespace Broobu.Taxonomy.UI.Controls.ViewModels
{
    /// <summary>
    /// Class DescriptionsViewModel.
    /// </summary>
    /// <summary>
    /// Class DescriptionsViewModel.
    /// </summary>
    [POCOViewModel]
    public class DescriptionsViewModel : DocumentListViewModelBase<Description>
    {


        private readonly Description _filter;

        public IDescriptionFilter Filter {
            get { return _filter; }
        }


        /// <summary>
        /// The _description types
        /// </summary>
        private readonly ObservableCollection<Enumeration> _descriptionTypes;

        private ObservableCollection<Enumeration> _cultureTypes;

        /// <summary>
        /// Gets the description types.
        /// </summary>
        /// <value>The description types.</value>
        public ObservableCollection<Enumeration> DescriptionTypes {
            get {
                return _descriptionTypes;
            }
        }

        public ObservableCollection<Enumeration> CultureTypes
        {
            get { return _cultureTypes; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DescriptionsViewModel"/> class.
        /// </summary>
        public DescriptionsViewModel() 
        {
            _descriptionTypes = new ObservableCollection<Enumeration>();
            _filter = new Description();
            _cultureTypes = new ObservableCollection<Enumeration>();
        }







        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>DescriptionsViewModel.</returns>
        public static DescriptionsViewModel Create()
        {
            return ViewModelSource.Create(() => new DescriptionsViewModel());
        }

    }
}
