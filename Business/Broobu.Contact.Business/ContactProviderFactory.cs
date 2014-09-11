// ***********************************************************************
// Assembly         : Iris.Contact.Business
// Author           : rlefever
// Created          : 06-30-2011
//
// Last Modified By : rlefever
// Last Modified On : 11-25-2013
// ***********************************************************************
// <copyright file="ContactProviderFactory.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

/// <summary>
/// The Business namespace.
/// </summary>
using Broobu.Contact.Business.Interfaces;

namespace Broobu.Contact.Business
{
    /// <summary>
    /// Class ContactProviderFactory.
    /// </summary>
    public class ContactProviderFactory
    {
        /// <summary>
        /// Class Key.
        /// </summary>
        public class Key
        {
            /// <summary>
            /// The instance
            /// </summary>
            public const string Instance = "Instance";
            /// <summary>
            /// The mock
            /// </summary>
            public const string Mock = "Mock";
        }



        /// <summary>
        /// Creates the address provider.
        /// </summary>
        /// <returns>IAddressProvider.</returns>
        public static IAddressProvider CreateAddressProvider()
        {
            return new AddressProvider();
        }



        public static IRelationProvider CreateRelationProvider()
        {
            return new RelationProvider();
        }


        /// <summary>
        /// Creates the country provider.
        /// </summary>
        /// <returns>ICountryProvider.</returns>
        public static ICountryProvider CreateCountryProvider()
        {
            return new CountryProvider();
        }

        public static IDocumentProvider CreateDocumentProvider()
        {
            return new DocumentProvider();
        }


       
    }
}
