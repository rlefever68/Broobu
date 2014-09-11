using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Broobu.EcoSpace.Contract.Properties;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Utils;

namespace Broobu.EcoSpace.Contract.Domain.Menu
{
    [DataContract]
    public abstract class MenuItem : TaxonomyObject<MenuItem>, IMenuItem
    {

        /// <summary>
        /// Gets or sets the tool tip.
        /// </summary>
        /// <value>The tool tip.</value>
        [DataMember]
        public String ToolTip { get; set; }


        private string _title = string.Empty;
        
        [DataMember]
        public string Title
        {
            get { return this._title; }
            set 
            {
                _title = value;
                RaisePropertyChanged("Title");
            }
        }


        private string _groupHeader;
        private bool _isFlowBreak;
        private string _content = string.Empty;
        [DataMember]
        public string Content
        {
            get { return this._content; }
            set 
            { 
                _content = value;
                RaisePropertyChanged("Content");
            }
        }
        [DataMember]
        public bool IsFlowBreak
        {
            get { return _isFlowBreak; }
            set { _isFlowBreak = value;
                RaisePropertyChanged("IsFlowBreak");
            }
        }
        [DataMember]
        public string GroupHeader
        {
            get { return _groupHeader; }
            set {
                _groupHeader = value;
                RaisePropertyChanged("GroupHeader");
            }
        }


        private string _subtitle = string.Empty;
        [DataMember]
        public string Subtitle
        {
            get { return this._subtitle; }
            set 
            {
                _subtitle = value;
                RaisePropertyChanged("Subtitle");
            }
        }
        private string _description = string.Empty;

        [DataMember]
        public string Description
        {
            get { return this._description; }
            set 
            {
                _description = value;
                RaisePropertyChanged("Description");
            }
        }




       


    }
}
