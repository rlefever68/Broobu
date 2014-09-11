using System.Collections.Generic;
using System.Runtime.Serialization;
using Iris.Fx.Domain;
using Iris.Fx.Validation;

namespace Broobu.Contact.Contract.Domain
{
	public partial class Address: DomainObject<Address>
	{
		#region Fields
		private string _countryId;
		private string _stateId;
		private string _typeId;
		private string _address1;
		private string _address2;
		private string _number;
		private string _box;
		private string _zipCode;
		private string _city;
		private double _latitude;
		private double _longitude;
		private string _addressString;
		#endregion
		#region Properties
		[DataMember]
		public string CountryId
		{
			get
			{
				return _countryId;
				
			}
			set
			{
				if(ReferenceEquals(_countryId, value) != true)
				{
					_countryId = value;
					RaisePropertyChanged("CountryId");
					OnRaisePropertyChanged("CountryId");
				}
				
			}
		}
		[DataMember]
		public string StateId
		{
			get
			{
				return _stateId;
				
			}
			set
			{
				if(ReferenceEquals(_stateId, value) != true)
				{
					_stateId = value;
					RaisePropertyChanged("StateId");
					OnRaisePropertyChanged("StateId");
				}
				
			}
		}
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
		public string Address1
		{
			get
			{
				return _address1;
				
			}
			set
			{
				if(ReferenceEquals(_address1, value) != true)
				{
					_address1 = value;
					RaisePropertyChanged("Address1");
					OnRaisePropertyChanged("Address1");
				}
				
			}
		}
		[DataMember]
		public string Address2
		{
			get
			{
				return _address2;
				
			}
			set
			{
				if(ReferenceEquals(_address2, value) != true)
				{
					_address2 = value;
					RaisePropertyChanged("Address2");
					OnRaisePropertyChanged("Address2");
				}
				
			}
		}
		[DataMember]
		public string Number
		{
			get
			{
				return _number;
				
			}
			set
			{
				if(ReferenceEquals(_number, value) != true)
				{
					_number = value;
					RaisePropertyChanged("Number");
					OnRaisePropertyChanged("Number");
				}
				
			}
		}
		[DataMember]
		public string Box
		{
			get
			{
				return _box;
				
			}
			set
			{
				if(ReferenceEquals(_box, value) != true)
				{
					_box = value;
					RaisePropertyChanged("Box");
					OnRaisePropertyChanged("Box");
				}
				
			}
		}
		[DataMember]
		public string ZipCode
		{
			get
			{
				return _zipCode;
				
			}
			set
			{
				if(ReferenceEquals(_zipCode, value) != true)
				{
					_zipCode = value;
					RaisePropertyChanged("ZipCode");
					OnRaisePropertyChanged("ZipCode");
				}
				
			}
		}
		[DataMember]
		public string City
		{
			get
			{
				return _city;
				
			}
			set
			{
				if(ReferenceEquals(_city, value) != true)
				{
					_city = value;
					RaisePropertyChanged("City");
					OnRaisePropertyChanged("City");
				}
				
			}
		}
		[DataMember]
		public double Latitude
		{
			get
			{
				return _latitude;
				
			}
			set
			{
				if(_latitude != value)
				{
					_latitude = value;
					RaisePropertyChanged("Latitude");
					OnRaisePropertyChanged("Latitude");
				}
				
			}
		}
		[DataMember]
		public double Longitude
		{
			get
			{
				return _longitude;
				
			}
			set
			{
				if(_longitude != value)
				{
					_longitude = value;
					RaisePropertyChanged("Longitude");
					OnRaisePropertyChanged("Longitude");
				}
				
			}
		}
		[DataMember]
		public string AddressString
		{
			get
			{
				return _addressString;
				
			}
			set
			{
				if(ReferenceEquals(_addressString, value) != true)
				{
					_addressString = value;
					RaisePropertyChanged("AddressString");
					OnRaisePropertyChanged("AddressString");
				}
				
			}
		}
		#endregion
		#region Methods
		protected override string Validate(string columnName)
		{
			return DataErrorInfoValidator<Address>.Validate(this, columnName);
		}
		protected override ICollection<string> Validate()
		{
			return DataErrorInfoValidator<Address>.Validate(this);
		}
		partial void OnRaisePropertyChanged(string propertyName);			
		#endregion		
	}
}