// ***********************************************************************
// Assembly         : Broobu.ManageAuthorization.Business
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-24-2013
// ***********************************************************************
// <copyright file="MapperFactory.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Net.Mail;
using Broobu.Authorization.Contract.Domain;
using Broobu.ManageAuthorization.Contract.Domain;
using Iris.Fx.Domain;
using Iris.Fx.Interfaces;


namespace Broobu.ManageAuthorization.Business.Mappers
{
    /// <summary>
    /// Class MapperFactory.
    /// </summary>
    public static class MapperFactory
    {



        /// <summary>
        /// To the role item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>RoleItem.</returns>
        public static Role ToRoleItem(this RoleInfo item)
        {
            return CreateRoleMapper()
                .MapFromServiceToBusiness(item);
        }

        /// <summary>
        /// To the role item.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>RoleItem[][].</returns>
        public static Role[] ToRoleItem(this RoleInfo[] items)
        {
            return CreateRoleMapper()
                .MapFromServiceToBusiness(items);
        }


        /// <summary>
        /// To the role view item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>RoleViewItem.</returns>
        public static RoleInfo ToRoleViewItem(this Role item)
        {
            return CreateRoleMapper()
                .MapFromBusinessToService(item);
        }

        /// <summary>
        /// To the role view item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>RoleViewItem[][].</returns>
        public static RoleInfo[] ToRoleViewItem(this Role[] item)
        {
            return CreateRoleMapper()
                .MapFromBusinessToService(item);
        }



        /// <summary>
        /// To the application function view item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>ApplicationFunctionViewItem.</returns>
        public static ApplicationFunctionInfo ToApplicationFunctionViewItem(this ApplicationFunction item)
        {
            return CreateApplicationFunctionMapper()
                .MapFromBusinessToService(item);
        }

        /// <summary>
        /// To the application function view item.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>ApplicationFunctionViewItem[][].</returns>
        public static ApplicationFunctionInfo[] ToApplicationFunctionViewItem(this ApplicationFunction[] items)
        {
            return CreateApplicationFunctionMapper()
                .MapFromBusinessToService(items);
        }

        /// <summary>
        /// To the application function item.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>ApplicationFunctionItem[][].</returns>
        public static ApplicationFunction[] ToApplicationFunctionItem(this ApplicationFunctionInfo[] items)
        {
            return CreateApplicationFunctionMapper()
                .MapFromServiceToBusiness(items);
        }

        /// <summary>
        /// To the application function item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>ApplicationFunctionItem.</returns>
        public static ApplicationFunction ToApplicationFunctionItem(this ApplicationFunctionInfo item)
        {
            return CreateApplicationFunctionMapper()
                .MapFromServiceToBusiness(item);
        }


        public static AccountInfo ToAccountViewItem(this Account item)
        {
            return CreateAccountMapper()
                .MapFromBusinessToService(item);
        }

        public static AccountInfo[] ToAccountViewItem(this Account[] items)
        {
            return CreateAccountMapper()
                .MapFromBusinessToService(items);
        }

        public static Account ToAccountItem(this AccountInfo item)
        {
            return CreateAccountMapper()
                .MapFromServiceToBusiness(item);
        }

        public static Account[] ToAccountItem(this AccountInfo[] items)
        {
            return CreateAccountMapper()
                .MapFromServiceToBusiness(items);
        }


        /// <summary>
        /// Creates the account mapper.
        /// </summary>
        /// <returns>IMapper{AccountViewItemAccountItem}.</returns>
        private static IMapper<AccountInfo, Account> CreateAccountMapper()
        {
            return new AccountMapper();
        }

        /// <summary>
        /// Creates the application function mapper.
        /// </summary>
        /// <returns>IMapper{ApplicationFunctionViewItemApplicationFunctionItem}.</returns>
        private static IMapper<ApplicationFunctionInfo, ApplicationFunction> CreateApplicationFunctionMapper()
        {
            return new ApplicationFunctionMapper();
        }



        /// <summary>
        /// Creates the role mapper.
        /// </summary>
        /// <returns>IMapper{RoleViewItemRoleItem}.</returns>
        private static IMapper<RoleInfo, Role> CreateRoleMapper()
        {
            return new RoleMapper();
        }
    }
}
