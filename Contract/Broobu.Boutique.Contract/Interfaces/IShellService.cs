using System.ServiceModel;
using Pms.Framework.Domain;
using Pms.Shell.Contract.Domain;


namespace Pms.Shell.Contract.Interfaces
{

   [ServiceContract(Namespace = ServiceConst.Namespace)]
   [ServiceKnownType(typeof(Result))]
   [ServiceKnownType(typeof(DomainObject<ShellUserInfo>))]
   [ServiceKnownType(typeof(DomainObject<ShellMenuInfo>))]
    public interface IShellService 
    {
       [OperationContract]
       ShellUserInfo GetShellUserInfo(string userName, string sessionId);
       [OperationContract]
       PMSSession LoginUser(PMSAuthRequest authRequest);
       [OperationContract]
       PMSSession ValidateSession(PMSSession pmsSession);
       [OperationContract]
       ShellMenuInfo[] GetAllMenuInfo();
       [OperationContract]
       ShellMenuInfo[] GetMenuInfoByFolderId(string folderId);
       [OperationContract]
       Result SaveMenuInfo(ShellMenuInfo appFunc);
       [OperationContract]
       Result RegisterException(ExceptionInfo info);
       [OperationContract]
       AuthenticationModeViewItem[] GetAuthenticationModes();
    }

   
}
