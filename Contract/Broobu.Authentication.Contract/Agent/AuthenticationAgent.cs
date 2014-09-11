// ***********************************************************************
// Assembly         : Broobu.Authentication.Contract
// Author           : ON8RL
// Created          : 12-16-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-17-2013
// ***********************************************************************
// <copyright file="AuthenticationAgent.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Security;
using Broobu.Authentication.Contract.Domain;
using Broobu.Authentication.Contract.Interfaces;
using Wulka.Domain;
using Wulka.Domain.Authentication;
using Wulka.Domain.Base;
using Wulka.Exceptions;
using Wulka.Networking.Wcf;

namespace Broobu.Authentication.Contract.Agent
{
    /// <summary>
    /// Exposes the IAuthenticationAgent Interface to communicate
    /// with an AuthenticationService
    /// </summary>
    class AuthenticationAgent : DiscoProxy<IAuthentication>, IAuthenticationAgent
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationAgent"/> class.
        /// </summary>
        public AuthenticationAgent(string discoUrl):base(discoUrl)
        {
            ServicePointManager.ServerCertificateValidationCallback = ((p1, p2, p3, p4) => true);
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationAgent"/> class.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <param name="discoUrl"></param>
        public AuthenticationAgent(string userName, string password, string discoUrl=null) 
            : base(discoUrl)
        {
            UserName = userName;
            Password = password;
        }


        #region IAuthenticationAgent Members




        /// <summary>
        /// Authenticates the user credentials async.
        /// </summary>
        /// <param name="act">The act.</param>
        public void AuthenticateUserCredentialsAsync(Action<WulkaSession> act)
        {
            var res = (WulkaSession)null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, e) => 
                {
                    try
                    {
                        res = AuthenticateUserCredentials();
                    }
                    catch (Exception ex)
                    {
                        if (wrk != null) 
                            wrk.Dispose();
                        Logger.Error(ex.GetCombinedMessages);
                        throw ex;
                    }
                };
                wrk.RunWorkerCompleted += (s, e) =>
                {
                    wrk.Dispose();
                    if (act != null)
                        act(res);
                };
                wrk.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Authenticates the by user name and password asynchronous.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <param name="act">The act.</param>
        public void AuthenticateByUserNameAndPasswordAsync(string userName, string password, Action<WulkaSession> act = null)
        {
            var res = (WulkaSession)null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, e) =>
                {
                    try
                    {
                        res = AuthenticateByUserNameAndPassword(userName, password);
                    }
                    catch (Exception ex)
                    {
                        if (wrk != null)
                            wrk.Dispose();
                        throw ex;
                    }
                };
                wrk.RunWorkerCompleted += (s, e) =>
                {
                    wrk.Dispose();
                    if (act != null)
                        act(res);
                };
                wrk.RunWorkerAsync();
            }
        }

        #endregion

        #region IAuthentication Members

        /// <summary>
        /// Authenticates the user credentials.
        /// </summary>
        /// <returns>WulkaSession.</returns>
        public WulkaSession AuthenticateUserCredentials()
        {
            var clt = CreateClient();
            try
            {
                
                var cb = (clt as ClientBase<IAuthentication>);
                if (cb != null)
                {
                    if (cb.ClientCredentials != null)
                    {
                        cb.ClientCredentials.UserName.UserName = UserName;
                        cb.ClientCredentials.UserName.Password = Password;
                        cb.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                            X509CertificateValidationMode.None;
                    }
                    return clt.AuthenticateUserCredentials();
                }
                return null;
            }
            finally 
            {
               CloseClient(clt);
            }

        }

         //<summary>
         //Authenticates the by user name and password.
         //</summary>
         //<param name="userName">Name of the user.</param>
         //<param name="passWord">The pass word.</param>
         //<returns>WulkaSession.</returns>
        //public WulkaSession AuthenticateByUserNameAndPassword(string userName, string passWord)
        //{
        //    var clt = CreateClient();
        //    try
        //    {
        //        var cb = (clt as ClientBase<IAuthentication>);
        //        if (cb != null)
        //        {
        //            if (cb.ClientCredentials != null)
        //            {
        //                cb.ClientCredentials.UserName.UserName = userName;
        //                cb.ClientCredentials.UserName.Password = passWord;
        //                cb.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
        //                    X509CertificateValidationMode.None;
        //            }
        //            return clt.AuthenticateByUserNameAndPassword(userName, passWord);
        //        }
        //        return null;
        //    }
        //    finally
        //    {
        //        CloseClient(clt);
        //    }
        //}

        /////// <summary>
        /////// Authenticates the user credentials.
        /////// </summary>
        /////// <param name="userName">Name of the user.</param>
        /////// <param name="passWord">The pass word.</param>
        /////// <returns>WulkaSession.</returns>
        /// <summary>
        /// Authenticates the by user name and password.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="passWord">The pass word.</param>
        /// <returns>WulkaSession.</returns>
        public WulkaSession AuthenticateByUserNameAndPassword(string userName, string passWord)
        {
            var clt = CreateClient();
            try
            {
                return clt.AuthenticateByUserNameAndPassword(userName, passWord);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        #endregion





        //UnComment if you want to debug the Custom Authentication Bug
        //protected override IAuthentication CreateClientInternal(Binding binding,
        //    EndpointAddress endpointAddress,
        //    WulkaClientCredentialsBase credentials)
        //{
        //    return GetInstance(binding, endpointAddress, credentials);
        //}


        /// <summary>
        /// Registers the new user async.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="act">The act.</param>
        public void RegisterNewUserAsync(UserRegistrationInfo item, Action<UserRegistrationInfo> act = null)
        {
            var res = (UserRegistrationInfo)null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (s, e) =>
                {
                    try
                    {
                        res = RegisterNewUser(item);
                    }
                    catch (Exception ex)
                    {
                        wrk.Dispose();
                        throw ex;
                    }
                };
                wrk.RunWorkerCompleted += (sender, args) =>
                {
                    wrk.Dispose();
                    if (act != null)
                        act(res);
                };
                wrk.RunWorkerAsync();
            }
        }


        #region IBoutique Members


        /// <summary>
        /// Registers the new user.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>NewUserRegistrationViewItem.</returns>
        public UserRegistrationInfo RegisterNewUser(UserRegistrationInfo item)
        {
            var clt = CreateClient();
            try
            {
                return clt.RegisterNewUser(item);
            }
            finally
            {
                CloseClient(clt);
            }
        }

        /// <summary>
        /// Terminates the session.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <returns>WulkaSession.</returns>
        public WulkaSession TerminateSession(WulkaSession session)
        {
            var clt = CreateClient();
            try
            {
                return clt.TerminateSession();
            }
            finally
            {
                CloseClient(clt);
            }
        }

        #endregion


        /// <summary>
        /// Terminates the session async.
        /// </summary>
        /// <param name="act">The act.</param>
        public void TerminateSessionAsync(Action<WulkaSession> act)
        {
            var res = (WulkaSession)null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (sender, args) =>
                {
                    try
                    {
                        res = Client.TerminateSession();
                    }
                    catch (Exception ex)
                    {
                        wrk.Dispose();
                        Logger.Error(ex.GetCombinedMessages());
                    }
                };
                wrk.RunWorkerCompleted += (s, e) =>
                {
                    wrk.Dispose();
                    act(res);
                };
                wrk.RunWorkerAsync();
            }

        }

        public void UserNameExistsAsync(string userName, Action<bool> act)
        {
            var res = (IdResult<bool>)null;
            using (var wrk = new BackgroundWorker())
            {
                wrk.DoWork += (sender, args) =>
                {
                    try
                    {
                        res = UserNameExists(userName);
                    }
                    catch (Exception ex)
                    {
                        wrk.Dispose();
                        Logger.Error(ex.GetCombinedMessages());
                    }
                };
                wrk.RunWorkerCompleted += (sender, args) =>
                {
                    wrk.Dispose();
                    act(res.Id);
                };
                wrk.RunWorkerAsync();
            }
        }


        /// <summary>
        /// Users the name exists.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>IdResult{System.Boolean}.</returns>
        public IdResult<bool> UserNameExists(string userName)
        {
            var clt = CreateClient();
            try
            {
                return clt.UserNameExists(userName);
            }
            finally 
            {

                CloseClient(clt);
            }
        }

        /// <summary>
        /// Terminates the session.
        /// </summary>
        /// <returns>WulkaSession.</returns>
        public WulkaSession TerminateSession()
        {
            return Client.TerminateSession();
        }

        #region IAuthenticationAgent Members
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }

        #endregion


        protected override string GetContractNamespace()
        {
            return AuthenticationServiceConst.Namespace;
        }




    }
}