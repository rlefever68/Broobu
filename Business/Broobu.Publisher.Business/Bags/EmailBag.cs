// ***********************************************************************
// Assembly         : Broobu.Publisher.Business
// Author           : Rafael Lefever
// Created          : 08-08-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-10-2014
// ***********************************************************************
// <copyright file="Publications.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Broobu.Publisher.Business.Smtp;
using Broobu.Publisher.Contract.Domain;
using Broobu.Taxonomy.Contract;
using Wulka.Data;
using Wulka.Exceptions;
using Wulka.Validation;
using NLog;

namespace Broobu.Publisher.Business.Bags
{
    /// <summary>
    /// Class Publications.
    /// </summary>
    [DataContract]
    public class EmailBag : Bag, IEmailBag
    {

        protected override Type GetTaxoFactoryType()
        {
            return typeof(TaxonomyPortal);
        }
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static EmailBag Instance
        {
            get 
            { 
                var res= Provider<EmailBag>.GetById(ID);
                if (res != null) return res;
                res = new EmailBag();
                res = Provider<EmailBag>.Save(res);
                return res;
            }
        }

        /// <summary>
        /// The logger
        /// </summary>
        private new static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        



        /// <summary>
        /// Initializes a new instance of the <see cref="EmailBag" /> class.
        /// </summary>
        public EmailBag()
        {
            Id = ID;
            DisplayName = "Emails";
        }

        /// <summary>
        /// The identifier
        /// </summary>
        public const string ID = "PUBL_DEFAULT_BAG";


        /// <summary>
        /// Saves this instance.
        /// </summary>
        protected override void Save()
        {
            Provider<EmailBag>.Save(this);
        }



        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<EmailBag>.Validate(this, columnName);
        }


        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<EmailBag>.Validate(this);
        }

        public static void AddEmail(PublishInfo info)
        {
            Instance.AddPart(info);
            Instance.Save();
        }
    }
}
