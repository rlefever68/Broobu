using System.ServiceModel;
using Pms.Framework.Domain;
using Pms.Shell.Domain;

namespace Pms.Shell.Service.Interfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract()]
    public interface IShellService 
    {
        [ServiceKnownType(typeof(Result))]
        [OperationContract]
        ShellUserInfo GetShellUserInfo(string userName, string password);


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

    }

   
}
