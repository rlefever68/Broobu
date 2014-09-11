


using System;
using Wulka.Authentication;
using Wulka.Domain.Authentication;
using Wulka.Utils;

namespace Broobu.Authentication.Contract.Domain
{
    public class Generator
    {

        /// <summary>
        ///     Creates the administrator account.
        /// </summary>
        /// <returns>AccountItem.</returns>
        public static Account CreateAdministratorAccount()
        {
            return new Account
            {
                AuthModeId = AuthenticationMode.Native,
                Id = AuthenticationDefaults.AdminId,
                Username = AuthenticationDefaults.AdminId,
                Pwd = AuthenticationDefaults.RootEncPwd,
                Active = 1,
                FirstName = "Root",
                LastName = "",
                Image = Properties.Resources.root.ToByteArray()
            };
        }



        /// <summary>
        ///     Creates the new account item.
        /// </summary>
        /// <returns>AccountItem.</returns>
        public static Account CreateNewAccountItem()
        {
            return new Account
            {
                Id = GuidUtils.NewCleanGuid,
                Active = 0,
                AuthModeId = AuthenticationMode.Native,
                CardId = new byte[] { },
                DtEnd = DateTime.Now.AddYears(30),
                DtStart = DateTime.Now,
                Email = String.Empty,
                FirstName = "Unknown",
                LastName = "User",
                Pwd = String.Empty,
                Telephone1 = String.Empty,
                Telephone2 = String.Empty,
                Image = Properties.Resources.male.ToByteArray()
                
            };
        }



        /// <summary>
        ///     Creates the guest account.
        /// </summary>
        /// <returns>AccountItem.</returns>
        public static Account CreateGuestAccount()
        {
            return new Account
            {
                AuthModeId = AccountDefaults.AuthModeId,
                CardId = AccountDefaults.CardId,
                DtStart = AccountDefaults.StartDate,
                DtEnd = AccountDefaults.EndDate,
                Email = AccountDefaults.Email,
                FirstName = AccountDefaults.FirstName,
                LastName = AccountDefaults.LastName,
                MiddleName = AccountDefaults.MiddleName,
                Id = AccountDefaults.Id,
                Pwd = AuthenticationDefaults.GuestEncPwd,
                SessionId = AccountDefaults.SessionId,
                Telephone1 = AccountDefaults.Telephone1,
                Telephone2 = AccountDefaults.Telephone2,
                Username = AccountDefaults.UserName,
                Active = 1,
                Image = Properties.Resources.male.ToByteArray()
            };
        }


        /// <summary>
        ///     Creates the administrator account.
        /// </summary>
        /// <returns>AccountItem.</returns>
        public static Account CreateRootAccount()
        {
            return CreateAdministratorAccount();
        }


        
    }
}
