using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Validation;

namespace Broobu.Boutique.Contract.Domain
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class BoutiqueMenuInfo : DomainObject<BoutiqueMenuInfo>
    {

        public class Property
        {
            public const string Id = "Id";
            public const string Title = "Title";
            public const string FolderId = "FolderId";
            public const string ToolTip = "ToolTip";
            public const string Icon = "Icon";
            public const string Order = "Order";
            public const string PluginUrl = "PluginUrl";
            public const string ServiceUrl = "ServiceUrl";
            public const string RibbonType = "RibbonType";
        }



        //private string _id;
        //[DataMember]
        //[DisplayNameAttribute("Id")]
        //[BrowsableAttribute(false)]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Id cannot be empty")]
        //public new string Id
        //{
        //    get { return _id; }
        //    set
        //    {
        //        _id = value;
        //        RaisePropertyChanged("Id");
        //        SetIsDirty();
        //    }
        //}

        //private string _parentId;
        //[DataMember]
        //[DisplayNameAttribute("Folder Id")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Parent Id cannot be empty")]
        //public string ParentId
        //{
        //    get { return _parentId; }
        //    set
        //    {
        //        _parentId = value;
        //        RaisePropertyChanged("ParentId");
        //        SetIsDirty();
        //    }
        //}




        private string _title;
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [DataMember]
        [DisplayName("Title")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Title cannot be empty")]
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged("Title");
            }
        }

        private string _toolTip;
        /// <summary>
        /// Gets or sets the tool tip.
        /// </summary>
        /// <value>The tool tip.</value>
        [DataMember]
        [DisplayName("Tool Tip")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tooltip cannot be empty")]
        public string ToolTip
        {
            get { return _toolTip; }
            set
            {
                _toolTip = value;
                RaisePropertyChanged("ToolTip");
            }
        }

       
       

        private int _order;
        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        [DataMember]
        [DisplayName("Order")]
        public int Order
        {
            get { return _order; }
            set
            {
                _order = value;
                RaisePropertyChanged("Order");
            }
        }

        private string _pluginUrl;
        /// <summary>
        /// Gets or sets the plugin URL.
        /// </summary>
        /// <value>The plugin URL.</value>
        [DataMember]
        [DisplayName("Applet Url")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Plugin Url cannot be empty")]
        public string PluginUrl
        {
            get { return _pluginUrl; }
            set
            {
                _pluginUrl = value;
                RaisePropertyChanged("PluginUrl");
            }
        }

        private string _serviceUrl;
        /// <summary>
        /// Gets or sets the service URL.
        /// </summary>
        /// <value>The service URL.</value>
        [DataMember]
        [DisplayName("Help Url")]
        public string ServiceUrl
        {
            get { return _serviceUrl; }
            set
            {
                _serviceUrl = value;
                RaisePropertyChanged("ServiceUrl");
            }
        }

        private BoutiqueMenuInfo[] _items = {};
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        [DataMember]
        [Browsable(false)]
        public BoutiqueMenuInfo[] Items
        {
            get { return _items; }
            set
            {
                _items = value;
                RaisePropertyChanged("Items");
            }
        }


        private string _ribbonType;
        [DataMember]
        [DisplayName("Type")]
        //[Required(AllowEmptyStrings = true, ErrorMessage = "Ribbon Type cannot be empty")]
        public string RibbonType
        {
            get { return _ribbonType; }
            set
            {
                _ribbonType = value;
                RaisePropertyChanged("RibbonType");
            }
        }



        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<BoutiqueMenuInfo>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        protected override System.Collections.Generic.ICollection<string> Validate()
        {
            return DataErrorInfoValidator<BoutiqueMenuInfo>.Validate(this);
        }
        
    }
}
