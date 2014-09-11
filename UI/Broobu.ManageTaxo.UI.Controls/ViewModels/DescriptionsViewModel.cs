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
using System.Collections.ObjectModel;
using Broobu.Fx.UI.MVVM;
using Broobu.ManageTaxo.Contract;
using Broobu.ManageTaxo.Contract.Domain;
using Broobu.Taxonomy.Contract.Domain;
using Broobu.Taxonomy.Contract.Interfaces;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;


namespace Broobu.ManageTaxonomy.UI.Controls.ViewModels
{
    /// <summary>
    /// Class DescriptionsViewModel.
    /// </summary>
    [POCOViewModel]
    public class DescriptionsViewModel : DocumentListViewModelBase<DescriptionItem>
    {

        /// <summary>
        /// The _filter
        /// </summary>
        private readonly DescriptionItem _filter;



        /// <summary>
        /// The _description types
        /// </summary>
        private readonly ObservableCollection<DescriptionItem> _descriptionTypes;

        /// <summary>
        /// The _culture types
        /// </summary>
        private readonly ObservableCollection<DescriptionItem> _cultureTypes;

        /// <summary>
        /// Gets the description types.
        /// </summary>
        /// <value>The description types.</value>
        public ObservableCollection<DescriptionItem> DescriptionTypes {
            get {
                return _descriptionTypes;
            }
        }

        /// <summary>
        /// Gets the culture types.
        /// </summary>
        /// <value>The culture types.</value>
        public ObservableCollection<DescriptionItem> CultureTypes
        {
            get { return _cultureTypes; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DescriptionsViewModel" /> class.
        /// </summary>
        public DescriptionsViewModel() 
        {
            _descriptionTypes = new ObservableCollection<DescriptionItem>();
            _filter = new DescriptionItem();
            _cultureTypes = new ObservableCollection<DescriptionItem>();
            Messenger.Default.Register<DescriptionMessage>(this,OnMessage);
        }


        /// <summary>
        /// Called when [message].
        /// </summary>
        /// <param name="msg">The MSG.</param>
        private void OnMessage(DescriptionMessage msg)
        {
            switch (msg.MessageType)
            {
                case DescriptionMessageType.Initialize:
                {
                    RefreshDescriptions(msg.Filter);
                    break;
                }
            }
        }

        /// <summary>
        /// Refreshes the descriptions.
        /// </summary>
        /// <param name="filter">The filter.</param>
        private void RefreshDescriptions(IDescriptionFilter filter)
        {
            ManageTaxoPortal
                .Agent
                .GetTranslationsForObjectAsync(filter.ObjectId,filter.TypeId, (x) => {
                    Documents = new ObservableCollection<DescriptionItem>(x);
                });
        }


        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>DescriptionsViewModel.</returns>
        public static DescriptionsViewModel Create()
        {
            return ViewModelSource.Create(() => new DescriptionsViewModel());
        }

        /// <summary>
        /// Starts the authenticated session.
        /// </summary>
        protected override void StartAuthenticatedSession()
        {
        }

        /// <summary>
        /// Terminates the authenticated session.
        /// </summary>
        /// <param name="onSessionTerminated">The on session terminated.</param>
        public override void TerminateAuthenticatedSession(Action onSessionTerminated = null)
        {
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
