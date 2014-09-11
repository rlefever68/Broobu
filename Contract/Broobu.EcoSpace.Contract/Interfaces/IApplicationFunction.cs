// ***********************************************************************
// Assembly         : Broobu.Authorization.Contract
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-20-2013
// ***********************************************************************
// <copyright file="IApplicationFunction.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ServiceModel;
using Broobu.EcoSpace.Contract.Domain;
using Broobu.EcoSpace.Contract.Domain.Menu;
using Wulka.Domain;
using Wulka.Domain.Base;

namespace Broobu.EcoSpace.Contract.Interfaces
{
    /// <summary>
    ///     Interface IApplicationFunction
    /// </summary>
    [ServiceKnownType(typeof (Result))]
    [ServiceKnownType(typeof (MenuButton))]
    [ServiceContract(Namespace = AuthorizationServiceConst.Namespace)]
    public interface IApplicationFunction
    {
        [OperationContract]
        MenuButton GetAppletInfo(string id);

        /// <summary>
        ///     Gets all application functions.
        /// </summary>
        /// <returns>ApplicationFunctionItem[][].</returns>
        [OperationContract]
        MenuButton[] GetAllApplicationFunctions();

        /// <summary>
        ///     Saves the application functions.
        /// </summary>
        /// <param name="applicationFunctionViewItems">The application function view items.</param>
        /// <returns>ApplicationFunctionItem[][].</returns>
        [OperationContract]
        MenuButton[] SaveApplicationFunctions(MenuButton[] applicationFunctionViewItems);

        /// <summary>
        ///     Deletes the application functions.
        /// </summary>
        /// <param name="applicationFunctionViewItems">The application function view items.</param>
        /// <returns>ApplicationFunctionItem[][].</returns>
        [OperationContract]
        MenuButton[] DeleteApplicationFunctions(MenuButton[] applicationFunctionViewItems);


        /// <summary>
        ///     Gets the menu for user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>ApplicationFunctionItem[][].</returns>
        [OperationContract]
        MenuButton[] GetMenuForUser(string userName);
    }
}