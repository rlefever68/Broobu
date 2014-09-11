// ***********************************************************************
// Assembly         : Broobu.ManageTaxo.UI.Controls
// Author           : Rafael Lefever
// Created          : 05-02-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 05-02-2014
// ***********************************************************************
// <copyright file="HookViewModel.cs" company="Insoft">
//     Copyright (c) Insoft. All rights reserved.
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
    /// Class HookViewModel.
    /// </summary>
    [POCOViewModel]
    public class HookViewModel : DocumentViewModelBase<Hook>
    {


        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>DescriptionViewModel.</returns>
        public static HookViewModel Create()
        {
            return ViewModelSource.Create(() => new HookViewModel());
        }




        /// <summary>
        /// Initializes a new instance of the <see cref="HookViewModel" /> class.
        /// </summary>
        public HookViewModel()
        {
            Messenger.Default.Register<DocumentMessage<HookItem>>( this, OnHookItemMessage);
        }

        /// <summary>
        /// Called when [hook item message].
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnHookItemMessage(DocumentMessage<HookItem> obj)
        {
            RefreshDocument(obj.Document.Id);
        }

        /// <summary>
        /// Refreshes the document.
        /// </summary>
        /// <param name="id">The identifier.</param>
        private void RefreshDocument(string id)
        {
            ManageTaxoPortal
                .Agent
                .GetHookAsync(id, (x) => { Document = x; });
        }


        /// <summary>
        /// Gets the document.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Hook.</returns>
        protected override Hook GetDocument(string id)
        {
            return ManageTaxoPortal
                .Agent
                .GetHook(id);
        }



        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>Hook.</returns>
        public override Hook Save()
        {
            return ManageTaxoPortal
                .Agent
                .SaveHook(Document);
        }

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        /// <returns>Hook.</returns>
        public override Hook Delete()
        {
            return ManageTaxoPortal
                .Agent
                .DeleteHook(Document);
        }

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>The title.</value>
        public override object Title
        {
            get { return "Edit Hook"; }
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
