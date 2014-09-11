using Pms.Framework.Domain;
using Pms.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Pms.Diagnostics.Contract.Domain
{
	public partial class DiagnosticsRunItem: DomainObject<DiagnosticsRunItem>
	{
		#region Fields
		private string _status;
		private string _info;
		private DateTime _startTime;
		private DateTime _endTime;
		#endregion
		#region Properties
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
			return DataErrorInfoValidator<DiagnosticsRunItem>.Validate(this, columnName);
		}
		protected override ICollection<string> Validate()		{
			return DataErrorInfoValidator<DiagnosticsRunItem>.Validate(this);
		}
		partial void OnRaisePropertyChanged(string propertyName);			
		#endregion		
	}
}