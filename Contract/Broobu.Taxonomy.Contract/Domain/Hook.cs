// ***********************************************************************
// Assembly         : Wulka.Fx
// Author           : ON8RL
// Created          : 12-04-2013
//
// Last Modified By : ON8RL
// Last Modified On : 05-05-2014
// ***********************************************************************
// <copyright file="Enumeration.cs" company="Broobu">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Wulka.Domain;
using Wulka.Domain.Base;
using Wulka.Domain.Interfaces;
using Wulka.Validation;


namespace Broobu.Taxonomy.Contract.Domain
{
    /// <summary>
    /// Class Hook
    /// A Hook in a taxonomy is the placehorder object for the actual object in the 
    /// ecospace.
    /// </summary>
    [DataContract]
    public  partial class Hook : ComposedObject<Hook>,IHook
    {
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<Hook>.Validate(this, columnName);
        }

        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<Hook>.Validate(this);
        }

        /// <summary>
        /// Gets or sets the object identifier for the object that is attached to this hook.
        /// </summary>
        /// <value>The object identifier.</value>
        [DataMember]
        public string ObjectId { get; set; }

        /// <summary>
        /// Gets or sets the object home.
        /// </summary>
        /// <value>The object home.</value>
        [DataMember]
        public string ObjectHome { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [DataMember]
        public String Title { get; set; }
        /// <summary>
        /// Gets or sets the type identifier.
        /// </summary>
        /// <value>The type identifier.</value>
        [DataMember]
        public String TypeId { get; set; }

        /// <summary>
        /// Gets or sets the descriptions.
        /// </summary>
        /// <value>The descriptions.</value>
        public IEnumerable<IDescription> Descriptions
        {
            get 
            {
                if (!Parts.OfType<IDescription>().Any())
                    AddDefaultDescriptions();
                return Parts.OfType<IDescription>(); 
            }
        }

        /// <summary>
        /// Gets or sets the descriptions.
        /// </summary>
        /// <value>The descriptions.</value>
        public IEnumerable<IHookProperty> Properties
        {
            get { return Parts.OfType<IHookProperty>(); }
        }

        [DataMember]
        public string EcoSpaceId { get; set; }


        public Hook()
        {
        }



 


    }


}