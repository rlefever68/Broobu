using System.Collections.Generic;

namespace Iris.SimpleDb.Adapter.Domain
{
    public class CreateDomainInfo : SimpleDbDomainObject<CreateDomainInfo>
    {

        public string DomainName { get; set; }

        protected override string Validate(string columnName)
        {
            return null;
        }

        protected override ICollection<string> Validate()
        {
            return null;
        }
    }
}
