// ***********************************************************************
// Assembly         : Iris.SimpleDb.Adapter
// Author           : rlefever
// Created          : 11-20-2013
//
// Last Modified By : rlefever
// Last Modified On : 11-20-2013
// ***********************************************************************
// <copyright file="ListDomainsMapper.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iris.SimpleDb.Adapter.Domain;
using Iris.SimpleDb.Adapter.ServiceRef;

namespace Iris.SimpleDb.Adapter.Mappers
{
    /// <summary>
    /// Class ListDomainsMapper.
    /// </summary>
    public static class ListDomainsMapper
    {
        /// <summary>
        /// Maps to service.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <returns>ListDomainsRequest.</returns>
        public static ListDomainsRequest MapToService(ListDomainsInfo info)
        {
            var h = new ListDomainsMapperHelper();
            return h.MapToService(info);
        }


        /// <summary>
        /// Maps to information.
        /// </summary>
        /// <param name="resp">The resp.</param>
        /// <returns>ListDomainsInfo.</returns>
        public static ListDomainsInfo MapToInfo(ListDomainsResponse resp)
        {
            var h = new ListDomainsMapperHelper();
            return h.MapToInfo(resp);
        }
    }




}
