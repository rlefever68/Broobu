using System.Runtime.Serialization;

namespace Broobu.EcoSpace.Contract.Domain.Applets
{
    [DataContract]
    public class BusinessAppletsFolder : AppletDomain
    {
        public BusinessAppletsFolder()
        {
            Id = "BUSINESS_APPLETS_FOLDER";
            DisplayName = "Business Applets";
        }
    }
}