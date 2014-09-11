// ***********************************************************************
// Assembly         : Broobu.Authentication.Rest
// Author           : Rafael Lefever
// Created          : 07-24-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 07-24-2014
// ***********************************************************************
// <copyright file="ActivateController.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Http;
using Broobu.Authentication.Business;
using Broobu.Authentication.Contract.Domain;
using Broobu.Authentication.Rest.Domain;


namespace Broobu.Authentication.Rest.Controllers
{
    /// <summary>
    /// Class ActivateController.
    /// </summary>
    [RoutePrefix("api/activate")]
    public class ActivateController : ApiController
    {


        // Typed lambda expression for Select() method. 
        /// <summary>
        /// As account dto
        /// </summary>
        private static readonly Expression<Func<Account, AccountDto>> AsAccountDto =
            x => new AccountDto
            {
                IsActive = x.Active==1,
                UserName = x.Username
            };


        /// <summary>
        /// Activates the specified account identifier.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [Route("{accountId:string}")]
        public async Task<IHttpActionResult> Activate(string accountId)
        {
            var acc = ActivateAccount(accountId);
            if (acc == null)
                return NotFound();
            return Ok(acc);
        }

        /// <summary>
        /// Activates the account.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns>AccountDto.</returns>
        private AccountDto ActivateAccount(string accountId)
        {
            return AuthenticationProvider
                .Accounts
                .Activate(accountId)
                .ToAccountDto();
        }
    }
}
