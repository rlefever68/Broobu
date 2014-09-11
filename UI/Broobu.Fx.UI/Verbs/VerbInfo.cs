using System.Collections.Generic;
using Wulka.Domain.Base;
using Wulka.Validation;

namespace Broobu.Fx.UI.Verbs
{
    public class VerbInfo : DomainObject<VerbInfo>
    {
        public string Verb { get; set; }
        public object Sender { get; set; }

        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<VerbInfo>.Validate(this, columnName);
        }

        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<VerbInfo>.Validate(this);
        }
    }
}