using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Iris.Fx.Domain;
using Iris.Fx.Domain.Base;
using Iris.Fx.Validation;

namespace Iris.Fx.Test.Domain
{
    [DataContract]
    public class Sideboard : DomainObject<Sideboard>
    {
        [DataMember]
        public string Material { get; set; }

        [DataMember]
        public string CoverMaterial { get; set; }

        [DataMember]
        public int NumberOfDrawers { get; set; }

        [DataMember]
        public int NumberOfShelfs { get; set; }

        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<Sideboard>.Validate(this, columnName);
        }

        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<Sideboard>.Validate(this);}
    }

}

    
