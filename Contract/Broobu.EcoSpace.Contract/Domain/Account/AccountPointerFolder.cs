using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Broobu.Taxonomy.Contract;
using Iris.Fx.Domain;
using Iris.Fx.Validation;

namespace Broobu.EcoSpace.Contract.Domain.Account
{
    public class AccountPointerFolder : Folder
    {
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<AccountPointerFolder>.Validate(this, columnName);
        }

        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<AccountPointerFolder>.Validate(this);
        }

        protected override Type GetTaxoFactoryType()
        {
            return typeof(TaxonomyPortal);
        }
    }
}
