using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Broobu.Taxonomy.Contract;
using Broobu.Taxonomy.Contract.Domain;
using Wulka.Domain;
using Wulka.Validation;

namespace Broobu.LATI.Contract.Domain
{
    [DataContract]
    public class RegionCulture : Link, IRegionCulture
    {
        public RegionCulture(ICulture cult, IRegion region)
        {
            SourceId = region.Id;
            TargetId = cult.Id;
        }


        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<RegionCulture>.Validate(this, columnName);
        }

        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<RegionCulture>.Validate(this);
        }

        protected override Type GetTaxoFactoryType()
        {
            return typeof(TaxonomyPortal);
        }

        protected override Type GetSourceFactoryType()
        {
            return typeof(LatiPortal);
        }

        protected override Type GetTargetFactoryType()
        {
            return typeof(LatiPortal);
        }
    }
}
