// ***********************************************************************
// Assembly         : Broobu.Authentication.Contract.Test
// Author           : ON8RL
// Created          : 12-16-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-17-2013
// ***********************************************************************
// <copyright file="AuthenticationTestFixture.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using Broobu.Authentication.Contract.Domain;
using Broobu.Authentication.Contract.Interfaces;
using Wulka.Authentication;
using Wulka.Domain;
using Wulka.Domain.Authentication;
using Wulka.Domain.Base;
using Wulka.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Broobu.Authentication.Contract.Test
{
    /// <summary>
    /// Class AuthenticationTestFixture.
    /// </summary>
    [TestClass]
    public class AuthenticationTestFixture : IAuthentication
    {


        /// <summary>
        /// Try_s the register new user.
        /// </summary>
        [TestMethod]
        public void Try_RegisterNewUser()
        {
            var nu = new UserRegistrationInfo()
            {
                Id = GuidUtils.NewCleanGuid,
                AuthMode = AuthenticationMode.Native,
                UserName = "rafael.lefever@gmail.com",
                Email = "rafael.lefever@gmail.com",
                Password = AuthenticationDefaults.GuestEncPwd,
                FirstName = "Rafael",
                LastName = "Lefever"
            };
            var re = RegisterNewUser(nu);
            Assert.AreEqual((object)nu.UserName, re.UserName);
            Console.WriteLine(re);
        }



        [TestMethod]
        public void Try_LoginGuest()
        {
            WulkaSession.Current = SessionFactory.CreateDefaultWulkaSession();
            WulkaCredentials.Current = WulkaSession.Current.Credentials;
            var sess = AuthenticationPortal
                .Authentication
                .TerminateSession();
        }



        /// <summary>
        /// Try_s the get Wulka session.
        /// </summary>
        [TestMethod]
        public void Try_GetWulkaSessionByCredentials()
        {
            try
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                    (se, cert, chain, sslerror) =>
                    {
                        Console.WriteLine("Certificate: {0}\nChain:{1}  \nError:{2}", cert.Subject, chain.ChainStatus[0].StatusInformation, sslerror);
                        return true;
                    };  
                var sess = AuthenticateUserCredentials();
                Assert.AreNotEqual(null, sess);
                Assert.AreEqual(AuthenticationDefaults.GuestUserName, sess.Username);
            }
            catch (Exception e)
            {

                Assert.Fail(e.Message);

            }
        }


        /// <summary>
        /// Try_s the get Wulka session by user name password.
        /// </summary>
        [TestMethod]
        public void Try_GetWulkaSessionByUserNamePassword()
        {
            try
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                    (se, cert, chain, sslerror) =>
                    {
                        Console.WriteLine("Certificate: {0}\nChain:{1}  \nError:{2}", cert.Subject, chain.ChainStatus[0].StatusInformation, sslerror);
                        return true;
                    };
                var sess = AuthenticateByUserNameAndPassword(AuthenticationDefaults.GuestUserName,AuthenticationDefaults.GuestEncPwd );
                Assert.AreNotEqual(null, sess);
                Assert.AreEqual(AuthenticationDefaults.GuestUserName, sess.Username);
                Console.WriteLine(sess);
            }
            catch (Exception e)
            {

                Assert.Fail(e.Message);

            }
        }



        /// <summary>
        /// Authenticates the user credentials.
        /// </summary>
        /// <returns>WulkaSession.</returns>
        public WulkaSession AuthenticateUserCredentials()
        {
            return AuthenticationPortal
                .CreateAgent(AuthenticationDefaults.Id, AuthenticationDefaults.GuestEncPwd)
                .AuthenticateUserCredentials();
        }

        /// <summary>
        /// Authenticates the by user name and password.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="passWord">The pass word.</param>
        /// <returns>WulkaSession.</returns>
        public WulkaSession AuthenticateByUserNameAndPassword(string userName, string passWord)
        {
            return AuthenticationPortal
                .Authentication
                .AuthenticateByUserNameAndPassword(userName, passWord);
        }

        /// <summary>
        /// Registers the new user.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>NewUserRegistrationViewItem.</returns>
        public UserRegistrationInfo RegisterNewUser(UserRegistrationInfo item)
        {
            return AuthenticationPortal
                .Authentication
                .RegisterNewUser(item);

        }


        /// <summary>
        /// Users the name exists.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>IdResult{System.Boolean}.</returns>
        public IdResult<bool> UserNameExists(string userName)
        {
            return AuthenticationPortal
                .Authentication
                .UserNameExists(userName);
        }

        /// <summary>
        /// Terminates the session.
        /// </summary>
        /// <returns>WulkaSession.</returns>
        public WulkaSession TerminateSession()
        {
            return AuthenticationPortal
                .Authentication
                .TerminateSession();
        }
    }
}
