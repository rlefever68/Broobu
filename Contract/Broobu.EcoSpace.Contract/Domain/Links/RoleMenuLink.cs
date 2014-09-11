using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Broobu.EcoSpace.Contract.Domain.Menu;
using Broobu.EcoSpace.Contract.Domain.Roles;
using Broobu.Taxonomy.Contract;
using Broobu.Taxonomy.Contract.Domain;
using Wulka.Domain;
using Wulka.Validation;

namespace Broobu.EcoSpace.Contract.Domain.Links
{
    [DataContract]
    public class RoleMenuLink : Link, IRoleMenuLink
    {
        protected override Type GetTaxoFactoryType()
        {
            return typeof(TaxonomyPortal);
        }

        public new IRole Role 
        {
            get { return base.Source as IRole; } 
            set { base.Source=value;} 
        }


        protected override Type GetSourceFactoryType()
        {
            return typeof(EcoSpacePortal);
        }

        public new IMenuButton Button 
        {
            get
            {
                return base.Target as IMenuButton;
            } 
            set
            {
                base.Target = value;
            }
        }

        protected override Type GetTargetFactoryType()
        {
            return typeof(EcoSpacePortal);
        }


        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<RoleMenuLink>.Validate(this, columnName);
        }

        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<RoleMenuLink>.Validate(this);
        }
    }
}
