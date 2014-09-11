using System.Runtime.Serialization;
using Broobu.EcoSpace.Contract.Domain.Menu;


namespace Broobu.EcoSpace.Contract.Domain.Default
{
    [DataContract]
    public class DefaultPageGroup : PageGroup
    {

        public DefaultPageGroup()
        {
            DisplayName = "Default";
        }
        
    }
}