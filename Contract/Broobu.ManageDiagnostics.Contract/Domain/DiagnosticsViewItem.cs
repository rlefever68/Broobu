using Pms.Framework.Domain;
using Pms.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Pms.ManageDiagnostics.Contract.Domain
{
	public partial class DiagnosticsViewItem: DomainObject<DiagnosticsViewItem>
	{
		#region Fields
		private string _contract;
		private string _method;
		private string _status;
		private string _description;
		private DateTime _startTime;
		private DateTime _endTime;
		#endregion
		#region Properties
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
		[DataMember]
		public string Method
		{
			get
			{
				return _method;
				
			}
			set
			{
				if(ReferenceEquals(_method, value) != true)
				{
					_method = value;
					RaisePropertyChanged("Method");
					OnRaisePropertyChanged("Method");
				}
				
			}
		}
		[DataMember]
		public string Status
		{
			get
			{
				return _status;
				
			}
			set
			{
				if(ReferenceEquals(_status, value) != true)
				{
					_status = value;
					RaisePropertyChanged("Status");
					OnRaisePropertyChanged("Status");
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
		[DataMember]
		public DateTime StartTime
		{
			get
			{
				return _startTime;
				
			}
			set
			{
				if(ReferenceEquals(_startTime, value) != true)
				{
					_startTime = value;
					RaisePropertyChanged("StartTime");
					OnRaisePropertyChanged("StartTime");
				}
				
			}
		}
		[DataMember]
		public DateTime EndTime
		{
			get
			{
				return _endTime;
				
			}
			set
			{
				if(ReferenceEquals(_endTime, value) != true)
				{
					_endTime = value;
					RaisePropertyChanged("EndTime");
					OnRaisePropertyChanged("EndTime");
				}
				
			}
		}
		#endregion
		#region Methods
		protected override string Validate(string columnName)		{
			return DataErrorInfoValidator<DiagnosticsViewItem>.Validate(this, columnName);
		}
		protected override ICollection<string> Validate()		{
			return DataErrorInfoValidator<DiagnosticsViewItem>.Validate(this);
		}
		partial void OnRaisePropertyChanged(string propertyName);			
		#endregion		
	}
}