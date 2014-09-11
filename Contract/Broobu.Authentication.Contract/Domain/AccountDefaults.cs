using System;
using Wulka.Authentication;

namespace Broobu.Authentication.Contract.Domain
{
    public class AccountDefaults
    {
        public const string Email = AuthenticationDefaults.Email;
        public const string AuthModeId = AuthenticationDefaults.AuthModeId;
        public const string UserName = AuthenticationDefaults.GuestUserName;
        public const string Pwd = AuthenticationDefaults.GuestPwd;
        public const string EncPwd = AuthenticationDefaults.GuestEncPwd;
        public static readonly string Id = AuthenticationDefaults.Id;
        public static byte[] CardId = AuthenticationDefaults.CardId;
        public static DateTime? StartDate = DateTime.UtcNow;
        public static DateTime? EndDate = DateTime.MaxValue;
        public static string FirstName = AuthenticationDefaults.FirstName;
        public static string LastName = AuthenticationDefaults.LastName;
        public static string MiddleName = AuthenticationDefaults.MiddleName;
        public static string SessionId = AuthenticationDefaults.SessionId;
        public static string Telephone1 = AuthenticationDefaults.Telephone1;
        public static string Telephone2 = AuthenticationDefaults.Telephone2;
        public static byte IsActive = AuthenticationDefaults.IsActive;
    }
}