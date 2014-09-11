using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iris.SimpleDb.Adapter.Domain
{
    public class ListDomainsInfo : SimpleDbDomainObject<ListDomainsInfo>
    {
        public string[] DomainNames;
        public string NextToken { get; set; }

        protected override string Validate(string columnName)
        {
            return null;
        }

        protected override ICollection<string> Validate()
        {
            return null;
        }

        public ServiceRef.ListDomains ListDomains { get; set; }
    }
}
