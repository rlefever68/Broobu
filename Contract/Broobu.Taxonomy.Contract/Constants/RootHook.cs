using System.Runtime.Serialization;
using Broobu.Taxonomy.Contract.Domain;

namespace Broobu.Taxonomy.Contract.Constants
{

    [DataContract]
    public class RootHook : Hook
    {

        public static string ID = "HOOK_ROOT";

        public RootHook()
        {
            Id = ID;
            DisplayName = "Root Hook";
        }
    }
}