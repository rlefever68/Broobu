// ***********************************************************************
// Assembly         : Iris.Contact.Contract
// Author           : ON8RL
// Created          : 12-20-2013
//
// Last Modified By : ON8RL
// Last Modified On : 12-20-2013
// ***********************************************************************
// <copyright file="RelationItem.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Iris.Fx.Domain;
using Iris.Fx.Validation;

namespace Broobu.Contact.Contract.Domain
{
    /// <summary>
    /// Class RelationItem.
    /// </summary>
	public class Relation: DomainObject<Relation>
	{

        /// <summary>
        /// The _document identifier
        /// </summary>
		private string _documentId;
        /// <summary>
        /// The _gender identifier
        /// </summary>
		private string _genderId;
        /// <summary>
        /// The _type identifier
        /// </summary>
		private string _typeId;
        /// <summary>
        /// The _first name
        /// </summary>
		private string _firstName;
        /// <summary>
        /// The _middle name
        /// </summary>
		private string _middleName;
        /// <summary>
        /// The _last name
        /// </summary>
		private string _lastName;
        /// <summary>
        /// The _date of birth
        /// </summary>
		private DateTime _dateOfBirth;
        /// <summary>
        /// The _place of birth
        /// </summary>
		private string _placeOfBirth;

        
        /// <summary>
        /// Gets or sets the document identifier.
        /// </summary>
        /// <value>The document identifier.</value>
		[DataMember]
		public string DocumentId
		{
			get
			{
				return _documentId;
				
			}
			set
			{
				if(ReferenceEquals(_documentId, value) != true)
				{
					_documentId = value;
					RaisePropertyChanged("DocumentId");
				}
				
			}
		}
        /// <summary>
        /// Gets or sets the gender identifier.
        /// </summary>
        /// <value>The gender identifier.</value>
		[DataMember]
		public string GenderId
		{
			get
			{
				return _genderId;
				
			}
			set
			{
				if(ReferenceEquals(_genderId, value) != true)
				{
					_genderId = value;
					RaisePropertyChanged("GenderId");
				}
				
			}
		}
        /// <summary>
        /// Gets or sets the type identifier.
        /// </summary>
        /// <value>The type identifier.</value>
		[DataMember]
		public string TypeId
		{
			get
			{
				return _typeId;
				
			}
			set
			{
				if(ReferenceEquals(_typeId, value) != true)
				{
					_typeId = value;
					RaisePropertyChanged("TypeId");
				}
				
			}
		}
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
		[DataMember]
		public string FirstName
		{
			get
			{
				return _firstName;
				
			}
			set
			{
				if(ReferenceEquals(_firstName, value) != true)
				{
					_firstName = value;
					RaisePropertyChanged("FirstName");
				}
				
			}
		}
        /// <summary>
        /// Gets or sets the name of the middle.
        /// </summary>
        /// <value>The name of the middle.</value>
		[DataMember]
		public string MiddleName
		{
			get
			{
				return _middleName;
				
			}
			set
			{
				if(ReferenceEquals(_middleName, value) != true)
				{
					_middleName = value;
					RaisePropertyChanged("MiddleName");
				}
				
			}
		}
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
		[DataMember]
		public string LastName
		{
			get
			{
				return _lastName;
				
			}
			set
			{
				if(ReferenceEquals(_lastName, value) != true)
				{
					_lastName = value;
					RaisePropertyChanged("LastName");
				}
				
			}
		}
        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>The date of birth.</value>
		[DataMember]
		public DateTime DateOfBirth
		{
			get
			{
				return _dateOfBirth;
				
			}
			set
			{
				if(ReferenceEquals(_dateOfBirth, value) != true)
				{
					_dateOfBirth = value;
					RaisePropertyChanged("DateOfBirth");
				}
				
			}
		}
        /// <summary>
        /// Gets or sets the place of birth.
        /// </summary>
        /// <value>The place of birth.</value>
		[DataMember]
		public string PlaceOfBirth
		{
			get
			{
				return _placeOfBirth;
				
			}
			set
			{
				if(ReferenceEquals(_placeOfBirth, value) != true)
				{
					_placeOfBirth = value;
					RaisePropertyChanged("PlaceOfBirth");
				}
				
			}
		}
	
        /// <summary>
        /// Validates the specified column name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>System.String.</returns>
		protected override string Validate(string columnName)
		{
			return DataErrorInfoValidator<Relation>.Validate(this, columnName);
		}
        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>ICollection{System.String}.</returns>
		protected override ICollection<string> Validate()
		{
			return DataErrorInfoValidator<Relation>.Validate(this);
		}

	}
}