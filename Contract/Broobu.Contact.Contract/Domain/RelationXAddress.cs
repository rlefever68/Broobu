using System.Collections.Generic;
using System.Runtime.Serialization;
using Iris.Fx.Domain;
using Iris.Fx.Validation;

namespace Broobu.Contact.Contract.Domain
{
	public partial class RelationXAddress: DomainObject<RelationXAddress>
	{
		#region Fields
		private string _relationId;
		private string _addressId;
		private string _typeId;
		#endregion
		#region Properties
		[DataMember]
		public string RelationId
		{
			get
			{
				return _relationId;
				
			}
			set
			{
				if(ReferenceEquals(_relationId, value) != true)
				{
					_relationId = value;
					RaisePropertyChanged("RelationId");
					OnRaisePropertyChanged("RelationId");
				}
				
			}
		}
		[DataMember]
		public string AddressId
		{
			get
			{
				return _addressId;
				
			}
			set
			{
				if(ReferenceEquals(_addressId, value) != true)
				{
					_addressId = value;
					RaisePropertyChanged("AddressId");
					OnRaisePropertyChanged("AddressId");
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
		#endregion
		#region Methods
		protected override string Validate(string columnName)
		{
			return DataErrorInfoValidator<RelationXAddress>.Validate(this, columnName);
		}
		protected override ICollection<string> Validate()
		{
			return DataErrorInfoValidator<RelationXAddress>.Validate(this);
		}
		partial void OnRaisePropertyChanged(string propertyName);			
		#endregion		
	}
}