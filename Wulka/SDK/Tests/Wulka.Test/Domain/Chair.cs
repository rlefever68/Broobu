using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Iris.Fx.Domain;
using Iris.Fx.Domain.Base;
using Iris.Fx.Validation;


namespace Iris.Fx.Test.Domain
{
    public class Chair : TaxonomyObject<Chair>
    {
        protected override Type GetTaxoFactoryType()
        {
            return GetType();
        }

        [DataMember]
        public int NumberOfLegs { get; set; }

        [DataMember]
        public Upholstry Upholstry { get; set; }

        [DataMember]
        public string Material { get; set; }

        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<Chair>.Validate(this,columnName);
        }

        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<Chair>.Validate(this);
        }
    }
}
