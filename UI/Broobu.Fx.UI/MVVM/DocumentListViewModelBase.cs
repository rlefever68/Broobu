// ***********************************************************************
// Assembly         : Broobu.Fx.UI
// Author           : Rafael Lefever
// Created          : 05-01-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 05-01-2014
// ***********************************************************************
// <copyright file="DocumentListViewModelBase.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using Wulka.Domain.Interfaces;

namespace Broobu.Fx.UI.MVVM
{
    /// <summary>
    ///     Class DocumentListViewModelBase.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [POCOViewModel]
    public abstract class DocumentListViewModelBase<T> : FxViewModelBase
        where T : IDomainObject
    {
        /// <summary>
        ///     The _current document
        /// </summary>
        private T _currentDocument;

        /// <summary>
        ///     The _documents
        /// </summary>
        private ObservableCollection<T> _documents = new ObservableCollection<T>();


        /// <summary>
        ///     The _filter
        /// </summary>
        private T _filter;

        /// <summary>
        ///     Gets the documents.
        /// </summary>
        /// <value>The documents.</value>
        public ObservableCollection<T> Documents
        {
            get { return _documents; }
            set
            {
                _documents = value;
                RaisePropertyChanged("Documents");
            }
        }


        /// <summary>
        ///     Gets or sets the current document.
        /// </summary>
        /// <value>The current document.</value>
        public T CurrentDocument
        {
            get { return _currentDocument; }
            set
            {
                if (_currentDocument.Id == value.Id) return;
                _currentDocument = value;
                Messenger.Default.Send(new DocumentMessage<T>
                {
                    Document = _currentDocument,
                    MessageType = DocumentMessageType.Update
                });
                RaisePropertyChanged("CurrentDocument");
            }
        }

        /// <summary>
        ///     Gets or sets the filter.
        /// </summary>
        /// <value>The filter.</value>
        public T Filter
        {
            get { return _filter; }
            set
            {
                _filter = value;
                RaisePropertyChanged("Filter");
            }
        }
    }
}