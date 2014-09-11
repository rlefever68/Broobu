// ***********************************************************************
// Assembly         : Broobu.ManageTaxo.UI.Controls
// Author           : Rafael Lefever
// Created          : 05-01-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 05-01-2014
// ***********************************************************************
// <copyright file="ManageDescriptionsViewModel.cs" company="Insoft">
//     Copyright (c) Insoft. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Broobu.Authentication.UI.Controls;
using Broobu.Taxonomy.Contract.Interfaces;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;



namespace Broobu.ManageTaxonomy.UI.Controls.ViewModels
{


    /// <summary>
    /// Class ManageDescriptionsViewModel.
    /// </summary>
    [POCOViewModel]
    public class ManageDescriptionsViewModel : AuthenticatedViewModel
    {

        /// <summary>
        /// The _object identifier
        /// </summary>
        private IDescriptionFilter _filter;



        /// <summary>
        /// Initializes a new instance of the <see cref="ManageDescriptionsViewModel"/> class.
        /// </summary>
        public ManageDescriptionsViewModel()
        {

        }


        /// <summary>
        /// Gets or sets the object identifier.
        /// </summary>
        /// <value>The object identifier.</value>
        public IDescriptionFilter Filter 
        { 
            get
            {
                return _filter;
            }
            set
            {
                if ((Filter.CultureId == value.CultureId) && (Filter.ObjectId == value.ObjectId) &&
                    (Filter.TypeId == value.TypeId)) return;
                _filter=value;
                AnnounceNewFilter();
            }
        }

        /// <summary>
        /// Announces the new filter.
        /// </summary>
        private void AnnounceNewFilter()
        {
            Messenger.Default.Send(new DescriptionMessage()
            {
                Filter = Filter,
                MessageType = DescriptionMessageType.Initialize
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
