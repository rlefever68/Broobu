using Pms.Framework.Domain;
using Pms.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Pms.Diagnostics.Contract.Domain
{
	public partial class DiagnosticsRunDetailItem: DomainObject<DiagnosticsRunDetailItem>
	{
		#region Fields
		private string _runId;
		private string _status;
		private string _serviceContract;
		private string _method;
		private DateTime _startedAt;
		private DateTime _endedAt;
		private string _info;
		#endregion
		#region Properties
		[DataMember]
		public string RunId
		{
			get
			{
				return _runId;
				
			}
			set
			{
				if(ReferenceEquals(_runId, value) != true)
				{
					_runId = value;
					RaisePropertyChanged("RunId");
					OnRaisePropertyChanged("RunId");
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
		public string ServiceContract
		{
			get
			{
				return _serviceContract;
				
			}
			set
			{
				if(ReferenceEquals(_serviceContract, value) != true)
				{
					_serviceContract = value;
					RaisePropertyChanged("ServiceContract");
					OnRaisePropertyChanged("ServiceContract");
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
		public DateTime StartedAt
		{
			get
			{
				return _startedAt;
				
			}
			set
			{
				if(ReferenceEquals(_startedAt, value) != true)
				{
					_startedAt = value;
					RaisePropertyChanged("StartedAt");
					OnRaisePropertyChanged("StartedAt");
				}
				
			}
		}
		[DataMember]
		public DateTime EndedAt
		{
			get
			{
				return _endedAt;
				
			}
			set
			{
				if(ReferenceEquals(_endedAt, value) != true)
				{
					_endedAt = value;
					RaisePropertyChanged("EndedAt");
					OnRaisePropertyChanged("EndedAt");
				}
				
			}
		}
		[DataMember]
		public string Info
		{
			get
			{
				return _info;
				
			}
			set
			{
				if(ReferenceEquals(_info, value) != true)
				{
					_info = value;
					RaisePropertyChanged("Info");
					OnRaisePropertyChanged("Info");
				}
				
			}
		}
		#endregion
		#region Methods
		protected override string Validate(string columnName)		{
			return DataErrorInfoValidator<DiagnosticsRunDetailItem>.Validate(this, columnName);
		}
		protected override ICollection<string> Validate()		{
			return DataErrorInfoValidator<DiagnosticsRunDetailItem>.Validate(this);
		}
		partial void OnRaisePropertyChanged(string propertyName);			
		#endregion		
	}
}