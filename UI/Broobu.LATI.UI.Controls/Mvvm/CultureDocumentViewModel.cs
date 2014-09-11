using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Broobu.Fx.UI.MVVM;
using Broobu.LATI.Contract;
using Broobu.LATI.Contract.Domain;

namespace Broobu.LATI.UI.Controls.Mvvm
{
    public class CultureDocumentViewModel : FxViewModelBase
    {
        private ICultureDocument _document;
        private string _documentId;


        public ICultureDocument Document
        {
            get { return _document; }
            set { _document = value; RaisePropertyChanged("Document");}
        }


        public string DocumentId
        {
            get { return _documentId; }
            set 
            { 
                _documentId = value;
                GetDocument(_documentId);
            }
        }

        private void GetDocument(string documentId)
        {
            LatiPortal
                .Cultures
                .GetCultureDocumentAsync(documentId, (d) => { Document = d; });
        }

        protected override void InitializeInternal(object[] parameters)
        {
            DocumentId = CultureDocument.ID;
        }
    }
}
