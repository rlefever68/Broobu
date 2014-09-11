using Broobu.Boutique.Contract.Domain;
using Broobu.EcoSpace.Contract.Domain.Account;

namespace Broobu.Boutique.Business.Interfaces
{
    public interface IBoutiques 
    {
        void InflateDomain();
        UserEnvironmentInfo GetUserEnvironmentInfo(string userName, string ecoSpaceId=null);
        BoutiqueMenuInfo GetAppletMenu(string userName, string appletId);
    }
}
