using System.ServiceModel;
using Broobu.EcoSpace.Contract.Domain.Eco;

namespace Broobu.EcoSpace.Contract.Interfaces
{
    [ServiceContract(Namespace = EcoSpaceConst.Namespace)]
    public interface IEcoSpaceSentry
    {
        [OperationContract]
        string GetMenuForUser();
        [OperationContract]
        string GetAppletsForUser();
        [OperationContract]
        string GetUserInfo(string userId,string fullName);
        [OperationContract]
        string GetEcoSpace(string id);
        [OperationContract]
        string SaveEcoSpace(string ecoSpace);
        [OperationContract]
        string[] GetEcoSpaceMemberships(string ecoSpaceId = null);
        [OperationContract]
        string[] GetKnownEcoSpaces(string accountId);
        [OperationContract]
        string RegisterAccountForEcoSpace(string accountId, string ecoSpaceId=null);
        [OperationContract]
        string[] GetRoleMembershipsForRole(string role, string ecoSpaceId = null);
        [OperationContract]
        string GetRoleMembershipsForAccountId(string accountId, string ecoSpaceId = null);
        [OperationContract]
        string RegisterRoleMembership(string role, string accountId);
    }
}