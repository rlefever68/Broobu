using System.Collections.Generic;
using System.Runtime.Serialization;
using Iris.Fx.Domain;
using Iris.Fx.Domain.Base;
using Iris.Fx.Validation;


namespace Iris.Fx.Test.Domain
{
    public class Upholstry : DomainObject<Upholstry>
    {

        [DataMember]
        public string Material { get; set; }

        [DataMember]
        public string Color { get; set; }


        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<Upholstry>.Validate(this,columnName);
        }

        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<Upholstry>.Validate(this);
        }
    }
}