// ***********************************************************************
// Assembly         : Broobu.Taxonomy.UI.Controls
// Author           : Rafael Lefever
// Created          : 04-22-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 05-06-2014
// ***********************************************************************
// <copyright file="DescriptionViewModel.cs" company="Insoft Pvt.Ltd.">
//     Copyright (c) Insoft Pvt.Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Broobu.Fx.UI.MVVM;
using Broobu.ManageTaxo.Contract;
using Broobu.ManageTaxo.Contract.Domain;
using Broobu.Taxonomy.Contract.Domain;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;



namespace Broobu.ManageTaxonomy.UI.Controls.ViewModels
{
    /// <summary>
    /// Class DescriptionViewModel.
    /// </summary>
    [POCOViewModel]
    public class DescriptionViewModel : DocumentViewModelBase<Description>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DescriptionViewModel" /> class.
        /// </summary>
        public DescriptionViewModel()
        {
            Messenger.Default.Register<DocumentMessage<DescriptionItem>>(this, OnDescriptionItemMessage);
        }

        /// <summary>
        /// Called when [description item message].
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnDescriptionItemMessage(DocumentMessage<DescriptionItem> obj)
        {
            if(obj.MessageType==DocumentMessageType.Update)
            {
                RefreshDescription(obj.Document);
            }
        }

        /// <summary>
        /// Refreshes the description.
        /// </summary>
        /// <param name="item">The item.</param>
        private void RefreshDescription(DescriptionItem item)
        {
            ManageTaxoPortal
                .Agent
                .GetDescriptionAsync(item, (x) => { Description = x; });
        }


        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>DescriptionViewModel.</returns>
        public static DescriptionViewModel Create()
        {
            return ViewModelSource.Create(() => new DescriptionViewModel());
        }


        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public Description Description 
        { 
            get; set; 
        }

        /// <summary>
        /// Gets the document.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Description.</returns>
        protected override Description GetDocument(string id)
        {
           // Todo: implepement GetDomcument
            return null;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>Description.</returns>
        public override Description Save()
        {
            return ManageTaxoPortal
                .Agent
                .SaveDescription(Description);
        }

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        /// <returns>Description.</returns>
        public override Description Delete()
        {
            return ManageTaxoPortal
                .Agent
                .DeleteDescription(Description);
        }

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>The title.</value>
        public override object Title
        {
            get { return "Edit Description"; }
        }


        /// <summary>
        /// Starts the authenticated session.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override void StartAuthenticatedSession()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Terminates the authenticated session.
        /// </summary>
        /// <param name="onSessionTerminated">The on session terminated.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void TerminateAuthenticatedSession(Action onSessionTerminated = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initializes the ViewModel the first time it is called.
        /// This method will be called from the View that implements the
        /// ViewModel
        /// </summary>
        /// <param name="parameters">The parameters used to initialize the ViewModel</param>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override void InitializeInternal(object[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}