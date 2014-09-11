// ***********************************************************************
// Assembly         : Broobu.Publisher.Business
// Author           : Rafael Lefever
// Created          : 08-09-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-10-2014
// ***********************************************************************
// <copyright file="TemplateBag.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Broobu.Publisher.Contract.Domain;
using Broobu.Taxonomy.Contract;
using Wulka.Data;


namespace Broobu.Publisher.Business.Bags
{
    /// <summary>
    /// Class TemplateBag.
    /// </summary>
    [DataContract]
    public class TemplateBag : Bag, ITemplateBag
    {

        protected override Type GetTaxoFactoryType()
        {
            return typeof(TaxonomyPortal);
        }


        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static TemplateBag Instance
        {
            get
            {
                var res = Provider<TemplateBag>.GetById(ID) 
                    ?? Provider<TemplateBag>.Save(CreateDefaultTemplateBag());
                return res;

            }
        }

        /// <summary>
        /// Creates the default template bag.
        /// </summary>
        /// <returns>TemplateBag.</returns>
        private static TemplateBag CreateDefaultTemplateBag()
        {
            var res = new TemplateBag();
            res.AddPart(new ConfirmationEmailTemplate());
            return res;
        }


        /// <summary>
        /// Gets the templates.
        /// </summary>
        /// <value>The templates.</value>
        public IEnumerable<ITemplate> Templates
        {
            get
            {
                return Parts.OfType<ITemplate>();
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateBag"/> class.
        /// </summary>
        public TemplateBag()
        {
            Id = ID;
            DisplayName = "Merging Templates";
        }


        /// <summary>
        /// The identifier
        /// </summary>
        public const string ID = "BAG_TEMPLATES";


        /// <summary>
        /// Saves this instance.
        /// </summary>
        protected override void Save()
        {
            
        }

        


    }
}
