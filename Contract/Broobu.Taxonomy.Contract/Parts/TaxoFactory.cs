using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wulka.Factories;

namespace Broobu.Taxonomy.Contract.Parts
{
    [Export(typeof(ITaxoFactory))]
    public class TaxoFactory : ITaxoFactory
    {
        public ITaxoProxy TaxoProxy 
        {
            get {
                return TaxonomyPortal
                    .Hooks;
            }
        }
    }
}
