using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using Broobu.Boutique.Contract.Interfaces;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Interfaces;
using Wulka.Validation;

namespace Broobu.Boutique.Contract.Domain
{
    public class BoutiqueRoleInfo: DomainObject<BoutiqueRoleInfo>,  IHierarchical
    {
        public class Property
        {
            public const string Id = "Id";
            public const string Title = "Title";
            public const string ParentId = "ParentId";
            public const string ToolTip = "ToolTip";
            public const string Children = "Children";
        }

        #region Public Properties

        private string _id;
        [DataMember]
        [DisplayName("Id")]
        [Browsable(false)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Id cannot be empty")]
        public new string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged(Property.Id);
                SetIsDirty();
            }
        }

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
                RaisePropertyChanged(Property.Title);
                SetIsDirty();
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
                RaisePropertyChanged(Property.ToolTip);
                SetIsDirty();
            }
        }

        private BoutiqueRoleInfo[] _children;
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        [DataMember]
        [Browsable(false)]
        public BoutiqueRoleInfo[] Children
        {
            get { return _children; }
            set
            {
                _children = value;
                RaisePropertyChanged(Property.Children);
            }
        }


        #endregion

        #region Domainobject properties

        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<BoutiqueRoleInfo>.Validate(this, columnName);
        }

        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<BoutiqueRoleInfo>.Validate(this);
        }

        #endregion



        #region Implementation of IHierarchical

        public IEnumerable<IHierarchical> ChildItems
        {
            get
            {
                if (Children != null)
                {
                    return Children.ToList();
                }
                return null;
            }
            set
            {
                if (value != null)
                {
                    Collection<BoutiqueRoleInfo> tmp = new Collection<BoutiqueRoleInfo>();
                    foreach (IHierarchical hierarchical in value)
                    {
                        tmp.Add((BoutiqueRoleInfo) hierarchical);
                    }
                    Children = tmp.ToArray();
                }
                else
                {
                    Children = null;
                }
            }
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return Title;
        }

        #endregion
    }
}
