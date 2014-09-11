using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wulka.Domain;
using Wulka.Domain.Interfaces;

namespace Broobu.Taxonomy.Contract.Domain
{
    public interface ITaxoLinks
    {
        ILink Activate(ILink link);
        ILink Deactivate(ILink link);
        IEnumerable<ILink> GetTargets(ILink link, bool activeOnly = true);
        IEnumerable<ILink> GetSources(ILink link, bool activeOnly = true);
    }
}
