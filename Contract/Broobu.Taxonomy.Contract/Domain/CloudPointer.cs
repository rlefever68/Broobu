// ***********************************************************************
// Assembly         : Iris.Fx
// Author           : Rafael Lefever
// Created          : 08-17-2014
//
// Last Modified By : Rafael Lefever
// Last Modified On : 08-17-2014
// ***********************************************************************
// <copyright file="CloudPointer.cs" company="Broobu">
//     Copyright (c) Broobu. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Runtime.Serialization;
using Iris.Fx.Domain;
using Iris.Fx.Utils;
using Iris.Fx.Validation;

namespace Broobu.Taxonomy.Contract.Domain
{
    /// <summary>
    /// Class CloudPointer.
    /// </summary>
    [DataContract]
    public abstract class CloudPointer : Link, ICloudPointer
    {
        /// <summary>
        /// The _object identifier
        /// </summary>
        private string _objectId;

        /// <summary>
        /// Gets or sets the object identifier.
        /// </summary>
        /// <value>The object identifier.</value>
        [DataMember]
        public string ObjectId
        {
            get { return _objectId; }
            set { _objectId = value; RaisePropertyChanged("ObjectId"); RaisePropertyChanged("Object"); }
        }


        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <value>The object.</value>
        public IDomainObject Object 
        {
            get 
            { 
                return GetObject(); 
            } 
            set
            {
                if (value != null)
                {
                    SetObject(value);
                }

            }
        }

        private void SetObject(IDomainObject value)
        {
            ObjectId = value.Id;
            DisplayName = value.DisplayName;
            Image = value.Image;
        }


        [Import(typeof(IObjectFactory))]
        public IObjectFactory ObjectFactory;

        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <returns>IDomainObject.</returns>
        private  IDomainObject GetObject()
        {
            CompositionHelper.ComposeParts(this, GetObjectFactoryType());
            return ObjectFactory == null 
                ? null 
                : ObjectFactory.GetById(ObjectId);
        }


        protected abstract Type GetObjectFactoryType();


        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<CloudPointer>.Validate(this, columnName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection&lt;System.String&gt;.</returns>
        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<CloudPointer>.Validate(this);
        }
    }
}