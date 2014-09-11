using System.Runtime.Serialization;

namespace Broobu.EcoSpace.Contract.Domain.Applets
{
    [DataContract]
    public class BusinessAppletsFolder : AppletFolder
    {
        public BusinessAppletsFolder()
        {
            Id = "BUSINESS_APPLETS_FOLDER";
            DisplayName = "Business Applets";
        }
    }
}