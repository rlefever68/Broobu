using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Broobu.Taxonomy.Contract;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Validation;

namespace Broobu.EcoSpace.Contract.Domain.Links
{
    [DataContract]
    public class MenuAppletLinkContainer : Folder
    {

        protected override Type GetTaxoFactoryType()
        {
            return typeof(TaxonomyPortal);
        }

        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<MenuAppletLinkContainer>.Validate(this, columnName);
        }

        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<MenuAppletLinkContainer>.Validate(this);
        }

        public const string ID = "MENU_APPLET_LINK_CONTAINER";
        public MenuAppletLinkContainer()
        {
            Id = ID;
            DisplayName = "Applet-Menu Links";
        }



    }
}
