using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Broobu.EcoSpace.Contract.Domain.Applets;
using Broobu.EcoSpace.Contract.Domain.Roles;
using Broobu.Taxonomy.Contract;
using Broobu.Taxonomy.Contract.Domain;
using Wulka.Domain;
using Wulka.Validation;

namespace Broobu.EcoSpace.Contract.Domain.Links
{
    [DataContract]
    public  class PermissionLink : Link
    {
        
        public new IRole Source
        {
            get
            {
                return base.Source as IRole;
            }
            set
            {
                base.Source = value;
            }
        }


        protected override Type GetSourceFactoryType()
        {
            return typeof(EcoSpacePortal);
        }

        public new ICloudApplet Target
        {
            get { return base.Target as ICloudApplet; }
            set { base.Target = value; }
        }

        protected override Type GetTargetFactoryType()
        {
            return typeof(EcoSpacePortal);
        }


        public PermissionLink(ICloudApplet applet, IRole role)
        { 
        }



        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<PermissionLink>.Validate(this, columnName);
        }

        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<PermissionLink>.Validate(this);
        }

        protected override Type GetTaxoFactoryType()
        {
            return typeof(TaxonomyPortal);
        }
    }
}
