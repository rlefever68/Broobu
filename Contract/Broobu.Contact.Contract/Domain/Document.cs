using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Iris.Fx.Domain;
using Iris.Fx.Validation;

namespace Broobu.Contact.Contract.Domain
{
	public partial class Document: DomainObject<Document>
	{
		#region Fields
		private string _typeId;
		private string _identificationNumber;
		private DateTime? _issueDate;
		private DateTime? _expiryDate;
		private string _description;
		#endregion
		#region Properties
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
					OnRaisePropertyChanged("TypeId");
				}
				
			}
		}
		[DataMember]
		public string IdentificationNumber
		{
			get
			{
				return _identificationNumber;
				
			}
			set
			{
				if(ReferenceEquals(_identificationNumber, value) != true)
				{
					_identificationNumber = value;
					RaisePropertyChanged("IdentificationNumber");
					OnRaisePropertyChanged("IdentificationNumber");
				}
				
			}
		}
		[DataMember]
		public DateTime? IssueDate
		{
			get
			{
				return _issueDate;
				
			}
			set
			{
				if(ReferenceEquals(_issueDate, value) != true)
				{
					_issueDate = value;
					RaisePropertyChanged("IssueDate");
					OnRaisePropertyChanged("IssueDate");
				}
				
			}
		}
		[DataMember]
		public DateTime? ExpiryDate
		{
			get
			{
				return _expiryDate;
				
			}
			set
			{
				if(ReferenceEquals(_expiryDate, value) != true)
				{
					_expiryDate = value;
					RaisePropertyChanged("ExpiryDate");
					OnRaisePropertyChanged("ExpiryDate");
				}
				
			}
		}
		[DataMember]
		public string Description
		{
			get
			{
				return _description;
				
			}
			set
			{
				if(ReferenceEquals(_description, value) != true)
				{
					_description = value;
					RaisePropertyChanged("Description");
					OnRaisePropertyChanged("Description");
				}
				
			}
		}
		#endregion
		#region Methods
		protected override string Validate(string columnName)
		{
			return DataErrorInfoValidator<Document>.Validate(this, columnName);
		}
		protected override ICollection<string> Validate()
		{
			return DataErrorInfoValidator<Document>.Validate(this);
		}
		partial void OnRaisePropertyChanged(string propertyName);			
		#endregion		
	}
}