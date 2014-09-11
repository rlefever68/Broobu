// ***********************************************************************
// Assembly         : Broobu.Publisher.Contract
// Author           : Rafael Lefever
// Created          : 08-08-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-08-2014
// ***********************************************************************
// <copyright file="PublishInfo.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Net.Mail;
using System.Runtime.Serialization;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Domain.Interfaces;
using Wulka.Validation;



namespace Broobu.Publisher.Contract.Domain
{
    /// <summary>
    /// Class PublishInfo.
    /// </summary>
    [DataContract]
    public class PublishInfo : ComposedObject<PublishInfo>
    {
        private string[] _targets = {};
        private IComposedObject _content;


        [OnDeserialized]
        private void InitFields(StreamingContext context)
        {
            if(_targets==null) _targets = new string[]{};
        }

        /// <summary>
        /// Gets or sets the targets.
        /// </summary>
        /// <value>The targets.</value>
        [DataMember]
        public string[] Targets
        {
            get { return _targets; }
            set { _targets = value; }
        }

        /// <summary>
        /// Gets or sets the sources.
        /// </summary>
        /// <value>The sources.</value>
        [DataMember]
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the template identifier.
        /// </summary>
        /// <value>The template identifier.</value>
        [DataMember]
        public string TemplateId { get; set; }


        public IComposedObject Content
        {
            get { return _content; }
            set { _content = value; }
        }

        [DataMember]
        public string Subject { get; set; }

        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<PublishInfo>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<PublishInfo>.Validate(this);
        }

    }
}
