// ***********************************************************************
// Assembly         : Broobu.Fx.UI
// Author           : Rafael Lefever
// Created          : 04-24-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 04-30-2014
// ***********************************************************************
// <copyright file="DocumentViewModelBase.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using Wulka.Domain.Interfaces;

namespace Broobu.Fx.UI.MVVM
{
    /// <summary>
    ///     Class DocumentViewModelBase.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [POCOViewModel]
    public abstract class DocumentViewModelBase<T> : FxViewModelBase, IDocumentViewModel
        where T : IDomainObject
    {
        private T _document;

        /// <summary>
        ///     Gets or sets the document.
        /// </summary>
        /// <value>The document.</value>
        public T Document
        {
            get { return _document; }
            set
            {
                _document = value;
                RaisePropertyChanged("Document");
            }
        }


        /// <summary>
        ///     [To be supplied]
        /// </summary>
        /// <returns>[To be supplied]</returns>
        public bool Close()
        {
            Messenger.Default.Send(new DocumentMessage<T>(), DocumentMessageType.Close);
            return true;
        }

        /// <summary>
        ///     [To be supplied]
        /// </summary>
        /// <value>[To be supplied]</value>
        public abstract object Title { get; }

        protected void Register()
        {
            Messenger.Default.Register<DocumentMessage<T>>(this, OnMessage);
        }


        protected virtual void OnMessage(DocumentMessage<T> documentMessage)
        {
            switch (documentMessage.MessageType)
            {
                case DocumentMessageType.Update:
                    Document = GetDocument(documentMessage.Document.Id);
                    break;
            }
        }

        protected abstract T GetDocument(string id);


        /// <summary>
        ///     Saves this instance.
        /// </summary>
        /// <returns>T.</returns>
        public abstract T Save();

        /// <summary>
        ///     Deletes this instance.
        /// </summary>
        /// <returns>T.</returns>
        public abstract T Delete();
    }
}