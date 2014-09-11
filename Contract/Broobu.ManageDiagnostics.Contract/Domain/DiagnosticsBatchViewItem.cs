using Pms.Framework.Domain;
using Pms.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Pms.ManageDiagnostics.Contract.Domain
{
	public partial class DiagnosticsBatchViewItem: DomainObject<DiagnosticsBatchViewItem>
	{
		#region Fields
		private string _batch;
		private string _status;
		private string _description;
		private DateTime _startTime;
		private DateTime _endTime;
		#endregion
		#region Properties
		[DataMember]
		public string Batch
		{
			get
			{
				return _batch;
				
			}
			set
			{
				if(ReferenceEquals(_batch, value) != true)
				{
					_batch = value;
					RaisePropertyChanged("Batch");
					OnRaisePropertyChanged("Batch");
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
			return DataErrorInfoValidator<DiagnosticsBatchViewItem>.Validate(this, columnName);
		}
		protected override ICollection<string> Validate()		{
			return DataErrorInfoValidator<DiagnosticsBatchViewItem>.Validate(this);
		}
		partial void OnRaisePropertyChanged(string propertyName);			
		#endregion		
	}
}