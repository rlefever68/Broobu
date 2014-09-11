using System.Collections.Generic;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Validation;

namespace Broobu.Boutique.Contract.Domain
{
    public class BoutiqueOption :DomainObject<BoutiqueOption>
    {
        public string Option { get; set; }
        public string OptionValue { get; set; }

        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<BoutiqueOption>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<BoutiqueOption>.Validate(this);
        }
    }
}
