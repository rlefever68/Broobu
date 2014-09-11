//	========================================================================================
//	INFO: This file is generated from a T4 template.
//  !!!	Any changes made manually will be lost next time this file is regenerated !!!
//	========================================================================================
using Pms.Diagnostics.Contract.Domain;
using System;
using System.ServiceModel;

namespace Pms.Diagnostics.Contract.Interfaces
{
	[ServiceContract(Namespace = "http://pms.diagnostics/11/04")]
  	public partial interface IDiagnostics
  	{
		#region Methods
		[OperationContract]
		DiagnosticsRunItem[] GetDiagnosticsRunItemsForDate(DateTime date);

		[OperationContract]
		DiagnosticsRunDetailItem[] GetDiagnosticsDetailsForRun(string id);

		#endregion

	}
}