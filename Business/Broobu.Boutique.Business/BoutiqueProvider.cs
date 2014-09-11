// ***********************************************************************
// Assembly         : Broobu.Boutique.Business
// Author           : Rafael Lefever
// Created          : 12-24-2013
//
// Last Modified By : Rafael Lefever
// Last Modified On : 01-10-2014
// ***********************************************************************
// <copyright file="BoutiqueProvider.cs" company="Broobu Systems Ltd.">
//     Copyright (c) Broobu Systems Ltd.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Broobu.Boutique.Business.Interfaces;
using Broobu.Boutique.Business.Workers;

namespace Broobu.Boutique.Business
{
    /// <summary>
    /// Class BoutiqueProvider.
    /// </summary>
    public static class BoutiqueProvider
    {
        /// <summary>
        /// Gets the boutique.
        /// </summary>
        /// <value>The boutique.</value>
        public static IBoutiques Boutiques
        {
            get
            {
                if (BoutiqueConfigurationHelper.MenuSource == BoutiqueConfigurationHelper.Const.Xml)
                    return new BoutiqueXmlConfigWorker();
                return new Boutiques();
            }
        }
    }
}
