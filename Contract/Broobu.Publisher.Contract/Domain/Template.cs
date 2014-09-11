// ***********************************************************************
// Assembly         : Broobu.Publisher.Contract
// Author           : Rafael Lefever
// Created          : 08-09-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 09-05-2014
// ***********************************************************************
// <copyright file="PublishTemplate.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Broobu.Taxonomy.Contract;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Domain.Interfaces;
using Wulka.Exceptions;
using Wulka.Validation;


namespace Broobu.Publisher.Contract.Domain
{
    /// <summary>
    /// Class Template.
    /// </summary>
    [DataContract]
    public class Template : TaxonomyObject<Template>, ITemplate
    {
        /// <summary>
        /// Gets the type of the taxo factory.
        /// </summary>
        /// <returns>Type.</returns>
        protected override Type GetTaxoFactoryType()
        {
            return typeof(TaxonomyPortal);
        }

        /// <summary>
        /// Gets or sets the template body.
        /// </summary>
        /// <value>The template body.</value>
        [DataMember]
        public string TemplateBody { get; set; }



        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public IComposedObject Content { get; set; }


        /// <summary>
        /// Gets the body.
        /// </summary>
        /// <value>The body.</value>
        public string Body 
        {
            get { return GetBody(); }
        }







        /// <summary>
        /// Gets the body.
        /// </summary>
        /// <returns>System.String.</returns>
        private string GetBody()
        {
            var res = TemplateBody;
            if (Content == null) return res;
            foreach (var param in Content.Parameters)
            {
                try
                {
                    var oldStr = String.Format("%{0}%", param.Id);
                    var newStr = Convert.ToString(param.Value);
                    res = res.Replace(oldStr, newStr);
                }
                catch (Exception exception)
                {
                    Logger.Warn(exception.GetCombinedMessages());
                }
            }
            return res;
        }


        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<Template>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<Template>.Validate(this);
        }
    }
}
