using System;
using Broobu.Authentication.Contract.Domain;

using Wulka.Domain;
using Wulka.Domain.Authentication;

namespace Broobu.Authentication.Contract.Interfaces
{
    /// <summary>
    /// 
    /// </summary>

    public interface IAuthenticationAgent : IAuthentication
    {
        string UserName { get; set; }
        string Password { get; set; }
        void AuthenticateUserCredentialsAsync(Action<WulkaSession> act=null);
        void AuthenticateByUserNameAndPasswordAsync(string userName, string password, Action<WulkaSession> act=null);
        void RegisterNewUserAsync(UserRegistrationInfo item, Action<UserRegistrationInfo> act = null);
        void TerminateSessionAsync(Action<WulkaSession> act);
        void UserNameExistsAsync(string userName, Action<bool> action);
    }


    

}