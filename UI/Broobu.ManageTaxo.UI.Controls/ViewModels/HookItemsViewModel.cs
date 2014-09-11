// ***********************************************************************
// Assembly         : Broobu.ManageTaxo.UI.Controls
// Author           : Rafael Lefever
// Created          : 05-01-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 05-02-2014
// ***********************************************************************
// <copyright file="EnumerationsViewModel.cs" company="Insoft">
//     Copyright (c) Insoft. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Broobu.Fx.UI.MVVM;
using Broobu.ManageTaxo.Contract;
using Broobu.ManageTaxo.Contract.Domain;
using Broobu.Taxonomy.Contract.Constants;
using Broobu.Taxonomy.Contract.Domain;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Ribbon.Customization;
using Enumerable = System.Linq.Enumerable;


namespace Broobu.ManageTaxonomy.UI.Controls.ViewModels
{
    /// <summary>
    /// Class EnumerationsViewModel.
    /// </summary>
    [POCOViewModel]
    public class HookItemsViewModel : DocumentListViewModelBase<HookItem>
    {


        public static HookItemsViewModel Create()
        {
            return ViewModelSource.Create(() => new HookItemsViewModel());
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
            RefreshHookItems( new HookItem(){Id=HookConst.Root});
        }

        /// <summary>
        /// Refreshes the hook items.
        /// </summary>
        /// <param name="hook">The hook.</param>
        private void RefreshHookItems(HookItem hook)
        {
            ManageTaxoPortal
                .Agent
                .GetHookItemsAsync(hook,
                (x) =>
                {
                    if (x == null) return;
                    foreach (var hookItem in x)
                    {
                        var res = Documents.FirstOrDefault(d => d.Id == hookItem.Id);
                        if(res==null)
                            Documents.Add(hookItem);
                        else
                        {
                            Documents[Documents.IndexOf(res)]=hookItem;
                        }
                    }
                    
                    RaisePropertyChanged("Documents");
                });
            Messenger.Default.Send(new DocumentMessage<HookItem>()
            {
                Document = hook,
                MessageType = DocumentMessageType.Update
            });
        }


        /// <summary>
        /// Gets or sets the current hook item.
        /// </summary>
        /// <value>The current hook item.</value>
        public HookItem CurrentHookItem { get;set; }


        public void ExpandHookItem(object content)
        {
            var inp = (HookItem)content;
            if(inp!=null)
            {
                RefreshHookItems(inp);
            }
        }
    }

    
}
