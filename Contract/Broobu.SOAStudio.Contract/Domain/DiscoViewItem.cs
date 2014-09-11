using Pms.Framework.Domain;
using Pms.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Pms.SoaStudio.Contract.Domain
{
	public partial class DiscoViewItem: DomainObject<DiscoViewItem>
	{
		#region Fields
		private string _endpoint;
		private string _contract;
		#endregion
		#region Properties
		[DataMember]
		public string Endpoint
		{
			get
			{
				return _endpoint;
				
			}
			set
			{
				if(ReferenceEquals(_endpoint, value) != true)
				{
					_endpoint = value;
					RaisePropertyChanged("Endpoint");
					OnRaisePropertyChanged("Endpoint");
				}
				
			}
		}
		[DataMember]
		public string Contract
		{
			get
			{
				return _contract;
				
			}
			set
			{
				if(ReferenceEquals(_contract, value) != true)
				{
					_contract = value;
					RaisePropertyChanged("Contract");
					OnRaisePropertyChanged("Contract");
				}
				
			}
		}
		#endregion
		#region Methods
		protected override string Validate(string columnName)		{
			return DataErrorInfoValidator<DiscoViewItem>.Validate(this, columnName);
		}
		protected override ICollection<string> Validate()		{
			return DataErrorInfoValidator<DiscoViewItem>.Validate(this);
		}
		partial void OnRaisePropertyChanged(string propertyName);			
		#endregion		
	}
}