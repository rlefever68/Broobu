// ***********************************************************************
// Assembly         : Iris.Fx.Test
// Author           : Rafael Lefever
// Created          : 01-11-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-14-2014
// ***********************************************************************
// <copyright file="GraphWriter.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.Composition;
using Iris.Fx.Data;
using Iris.Fx.Domain;
using Iris.Fx.Domain.Base;
using Iris.Fx.Domain.Interfaces;
using Iris.Fx.Interfaces;

namespace Iris.Fx.Test.Parts
{
    /// <summary>
    /// Class GraphWriter.
    /// </summary>
    [Export(typeof(IWriteEvents))]
    internal class GraphWriter : IWriteEvents
    {
        /// <summary>
        /// Called when [saved].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="domainObject">The domain object.</param>
        public void OnSaved<T>(DomainObject<T> domainObject) 
            where T : IDomainObject
        {
            Console.WriteLine("OnSaved");
        }

        /// <summary>
        /// Called when [deleting].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="domainObject">The domain object.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool OnDeleting<T>(DomainObject<T> domainObject) 
            where T : IDomainObject
        {
            Console.WriteLine("OnDeleting");
            return true;
        }

        /// <summary>
        /// Called when [saving].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="domainObject">The domain object.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool OnSaving<T>(DomainObject<T> domainObject) 
            where T : IDomainObject
        {
            Console.WriteLine("OnSaving");
            return true;
        }

        /// <summary>
        /// Called when [deleted].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="domainObject">The domain object.</param>
        public void OnDeleted<T>(DomainObject<T> domainObject) 
            where T : IDomainObject
        {
            Console.WriteLine("OnDeleted");
        }
    }
}
