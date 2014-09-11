using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using Broobu.EcoSpace.Contract.Properties;
using Broobu.Taxonomy.Contract;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Validation;

namespace Broobu.EcoSpace.Contract.Domain.Applets
{
    [DataContract]
    public class CloudApplet : TaxonomyObject<CloudApplet>, ICloudApplet
    {
        protected override Type GetTaxoFactoryType()
        {
            return typeof(TaxonomyPortal);
        }


        [DataMember]
        public string PublishUrl { get; set; }

        [DataMember]
        public bool IsEmbedded { get; set; }


        public IEnumerable<AppletFeature> Features
        {
            get
            {
                return Parts.OfType<AppletFeature>();
            }
        }


        public CloudApplet()
        {
            Icon = Resources.Applet2;
        }


        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<CloudApplet>.Validate(this,columnName);
        }

        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<CloudApplet>.Validate(this);
        }
    }
}
